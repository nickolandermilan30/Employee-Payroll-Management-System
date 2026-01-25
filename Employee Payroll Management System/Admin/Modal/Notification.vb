Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Data

Public Class Notification

    ' =========================
    ' DATABASE CONNECTION
    ' =========================
    Private conn As New MySqlConnection(
        "Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;"
    )

    ' =========================
    ' SCHEDULE TABLE
    ' =========================
    Private scheduleTable As DataTable
    Private filteredTable As DataTable ' For search/filtering

    ' =========================
    ' UI SETTINGS
    ' =========================
    Private headerHeight As Integer = 40
    Private rowHeight As Integer = 35
    Private padding As Integer = 10

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub Notification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadScheduleData()
        filteredTable = scheduleTable.Copy()
        ListNotif.Invalidate()
    End Sub

    ' =========================
    ' LOAD DATA FROM DATABASE
    ' =========================
    Private Sub LoadScheduleData()
        Try
            conn.Open()
            Dim sql As String = "SELECT id, fullname, schedule_date, status, time_in, time_out FROM set_schedule ORDER BY schedule_date DESC"
            Dim adapter As New MySqlDataAdapter(sql, conn)
            scheduleTable = New DataTable()
            adapter.Fill(scheduleTable)
        Catch ex As Exception
            MessageBox.Show("Error loading schedule: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' =========================
    ' SEARCH FUNCTION
    ' =========================
    Private Sub search_TextChanged(sender As Object, e As EventArgs) Handles search.TextChanged
        If scheduleTable Is Nothing Then Return
        Dim query = search.Text.Trim().ToLower()
        If query = "" Then
            filteredTable = scheduleTable.Copy()
        Else
            filteredTable = scheduleTable.Clone()
            For Each r As DataRow In scheduleTable.Rows
                If r("fullname").ToString().ToLower().Contains(query) Then
                    filteredTable.ImportRow(r)
                End If
            Next
        End If
        ListNotif.Invalidate()
    End Sub

    ' =========================
    ' PAINT PANEL
    ' =========================
    Private Sub ListNotif_Paint(sender As Object, e As PaintEventArgs) Handles ListNotif.Paint
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.Clear(Color.White)

        If filteredTable Is Nothing OrElse filteredTable.Rows.Count = 0 Then Return

        Dim panelWidth = ListNotif.Width
        Dim fontHeader As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim fontRow As New Font("Segoe UI", 9)

        ' Column widths
        Dim colFullname = CInt(panelWidth * 0.2)
        Dim colDate = CInt(panelWidth * 0.15)
        Dim colStatus = CInt(panelWidth * 0.15)
        Dim colTimeIn = CInt(panelWidth * 0.15)
        Dim colTimeOut = CInt(panelWidth * 0.15)
        Dim colButton = panelWidth - (colFullname + colDate + colStatus + colTimeIn + colTimeOut + padding * 2)

        ' HEADER
        g.FillRectangle(Brushes.LightGray, 0, 0, panelWidth, headerHeight)
        g.DrawString("Fullname", fontHeader, Brushes.Black, padding, 10)
        g.DrawString("Date", fontHeader, Brushes.Black, colFullname + padding, 10)
        g.DrawString("Status", fontHeader, Brushes.Black, colFullname + colDate + padding, 10)
        g.DrawString("Time In", fontHeader, Brushes.Black, colFullname + colDate + colStatus + padding, 10)
        g.DrawString("Time Out", fontHeader, Brushes.Black, colFullname + colDate + colStatus + colTimeIn + padding, 10)
        g.DrawString("Action", fontHeader, Brushes.Black, colFullname + colDate + colStatus + colTimeIn + colTimeOut + padding, 10)

        ' ROWS
        For i = 0 To filteredTable.Rows.Count - 1
            Dim y = headerHeight + i * rowHeight
            g.FillRectangle(If(i Mod 2 = 0, Brushes.WhiteSmoke, Brushes.White), 0, y, panelWidth, rowHeight)

            Dim row = filteredTable.Rows(i)
            Dim fullname = row("fullname").ToString()
            Dim d As Date = row("schedule_date")
            Dim status = row("status").ToString()
            Dim timeIn = row("time_in").ToString()
            Dim timeOut = row("time_out").ToString()

            ' DRAW TEXT
            g.DrawString(fullname, fontRow, Brushes.Black, padding, y + 8)
            g.DrawString(d.ToString("yyyy-MM-dd"), fontRow, Brushes.Black, colFullname + padding, y + 8)
            g.DrawString(status, fontRow, Brushes.Black, colFullname + colDate + padding, y + 8)
            g.DrawString(timeIn, fontRow, Brushes.Black, colFullname + colDate + colStatus + padding, y + 8)
            g.DrawString(timeOut, fontRow, Brushes.Black, colFullname + colDate + colStatus + colTimeIn + padding, y + 8)

            ' DRAW "SET" BUTTON
            Dim buttonRect As New Rectangle(colFullname + colDate + colStatus + colTimeIn + colTimeOut + padding, y + 5, colButton - 10, 25)
            Using path = RoundedRect(buttonRect, 8)
                Using br As New SolidBrush(Color.FromArgb(52, 152, 219))
                    g.FillPath(br, path)
                End Using
            End Using

            Dim ts = g.MeasureString("Set", fontRow)
            g.DrawString("Set", fontRow, Brushes.White,
                         buttonRect.X + (buttonRect.Width - ts.Width) / 2,
                         buttonRect.Y + (buttonRect.Height - ts.Height) / 2)
        Next
    End Sub

    ' =========================
    ' ROUNDED RECTANGLE FUNCTION
    ' =========================
    Private Function RoundedRect(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    ' =========================
    ' CLICK PANEL TO SELECT ROW
    ' =========================
    Private Sub ListNotif_MouseClick(sender As Object, e As MouseEventArgs) Handles ListNotif.MouseClick
        If filteredTable Is Nothing OrElse filteredTable.Rows.Count = 0 Then Return

        Dim rowIndex As Integer = (e.Y - headerHeight) \ rowHeight
        If rowIndex < 0 Or rowIndex >= filteredTable.Rows.Count Then Return

        Dim selectedRow As DataRow = filteredTable.Rows(rowIndex)

        ' =========================
        ' SET MONITOR ATTENDANCE FIELDS
        ' =========================
        If TypeOf Owner Is MonitorAttendance Then
            Dim monitor As MonitorAttendance = CType(Owner, MonitorAttendance)

            ' ===== SET EMPLOYEE DROPDOWN =====
            For i As Integer = 0 To monitor.Employedropdown.Items.Count - 1
                Dim drv As DataRowView = CType(monitor.Employedropdown.Items(i), DataRowView)
                If drv("fullname").ToString() = selectedRow("fullname").ToString() Then
                    monitor.Employedropdown.SelectedIndex = i
                    Exit For
                End If
            Next

            ' ===== SET DATE =====
            monitor.monthofdate.Value = CDate(selectedRow("schedule_date"))

            ' ===== SET STATUS =====
            Dim statIndex As Integer = monitor.status.FindString(selectedRow("status").ToString())
            If statIndex <> -1 Then monitor.status.SelectedIndex = statIndex

            ' ===== SET CHECK-IN / CHECK-OUT TIMES =====
            Dim cin = selectedRow("time_in").ToString()
            Dim cout = selectedRow("time_out").ToString()

            ' Add missing times to dropdown if they are not already there
            If monitor.checkin.Items.IndexOf(cin) = -1 Then monitor.checkin.Items.Add(cin)
            If monitor.checkout.Items.IndexOf(cout) = -1 Then monitor.checkout.Items.Add(cout)

            ' Select the times
            monitor.checkin.SelectedItem = cin
            monitor.checkout.SelectedItem = cout
        End If

        Me.Close() ' close notification after selection
    End Sub

End Class
