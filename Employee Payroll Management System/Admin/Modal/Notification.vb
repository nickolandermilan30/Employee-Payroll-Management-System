Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Notification

    ' =========================
    ' DATABASE CONNECTION
    ' =========================
    Private conn As New MySqlConnection(
        "Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;"
    )

    ' =========================
    ' DATA TABLES
    ' =========================
    Private scheduleTable As DataTable
    Private filteredTable As DataTable

    ' =========================
    ' UI LAYOUT
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
    ' LOAD SCHEDULE DATA
    ' =========================
    Private Sub LoadScheduleData()
        Try
            conn.Open()

            Dim sql As String =
                "SELECT s.id, s.fullname, s.schedule_date, s.status, s.time_in, s.time_out,
                 CASE 
                    WHEN EXISTS (
                        SELECT 1 FROM attendance a
                        WHERE a.employee_id = s.id
                        AND a.attendance_date = s.schedule_date
                    ) THEN 1 ELSE 0
                 END AS is_set
                 FROM set_schedule s
                 ORDER BY s.schedule_date DESC"

            Dim da As New MySqlDataAdapter(sql, conn)
            scheduleTable = New DataTable()
            da.Fill(scheduleTable)

        Catch ex As Exception
            MessageBox.Show("Error loading schedule: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' =========================
    ' HANDLE SET BUTTON CLICK
    ' =========================
    Private Sub ListNotif_MouseClick(sender As Object, e As MouseEventArgs) Handles ListNotif.MouseClick
        Dim rowIndex As Integer = (e.Y - headerHeight) \ rowHeight
        If rowIndex < 0 OrElse rowIndex >= filteredTable.Rows.Count Then Exit Sub

        Dim row As DataRow = filteredTable.Rows(rowIndex)
        If Convert.ToBoolean(row("is_set")) Then Exit Sub ' Already set, do nothing

        ' =========================
        ' HANDLE ATTENDANCECHECKER
        ' =========================
        If TypeOf Owner Is AttendanceChecker Then
            Dim ac As AttendanceChecker = CType(Owner, AttendanceChecker)

            ' Select Employee
            For i As Integer = 0 To ac.Employedropdown.Items.Count - 1
                Dim drv As DataRowView = CType(ac.Employedropdown.Items(i), DataRowView)
                If drv("fullname").ToString() = row("fullname").ToString() Then
                    ac.Employedropdown.SelectedIndex = i
                    Exit For
                End If
            Next

            ' Set Date
            ac.monthofdate.Value = CDate(row("schedule_date"))

            ' Set Status
            ac.status.SelectedItem = row("status").ToString()

            ' Set CheckIn / CheckOut
            SetComboTime(ac.checkin, row("time_in"))
            SetComboTime(ac.checkout, row("time_out"))
        End If

        ' =========================
        ' HANDLE MONITORATTENDANCE
        ' =========================
        If TypeOf Owner Is MonitorAttendance Then
            Dim ma As MonitorAttendance = CType(Owner, MonitorAttendance)

            ' Select Employee
            For i As Integer = 0 To ma.Employedropdown.Items.Count - 1
                Dim drv As DataRowView = CType(ma.Employedropdown.Items(i), DataRowView)
                If drv("fullname").ToString() = row("fullname").ToString() Then
                    ma.Employedropdown.SelectedIndex = i
                    Exit For
                End If
            Next

            ' Set Date
            ma.monthofdate.Value = CDate(row("schedule_date"))

            ' Set Status
            ma.status.SelectedItem = row("status").ToString()

            ' Set CheckIn / CheckOut
            SetComboTime(ma.checkin, row("time_in"))
            SetComboTime(ma.checkout, row("time_out"))
        End If

        Me.Close()
    End Sub

    ' =========================
    ' MATCH TIME IN COMBOBOX
    ' =========================
    Private Sub SetComboTime(cb As ComboBox, dbValue As Object)
        If dbValue Is DBNull.Value Then Exit Sub

        Dim t As DateTime
        If DateTime.TryParse(dbValue.ToString(), t) Then
            Dim formatted As String = t.ToString("h:mm tt")
            Dim idx As Integer = cb.FindStringExact(formatted)
            If idx >= 0 Then cb.SelectedIndex = idx
        End If
    End Sub

    ' =========================
    ' DRAW LIST
    ' =========================
    Private Sub ListNotif_Paint(sender As Object, e As PaintEventArgs) Handles ListNotif.Paint
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.Clear(Color.White)

        If filteredTable Is Nothing OrElse filteredTable.Rows.Count = 0 Then Exit Sub

        Dim w = ListNotif.Width
        Dim fontHeader As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim fontRow As New Font("Segoe UI", 9)

        ' Column widths
        Dim colFull = CInt(w * 0.2)
        Dim colDate = CInt(w * 0.15)
        Dim colStat = CInt(w * 0.15)
        Dim colIn = CInt(w * 0.15)
        Dim colOut = CInt(w * 0.15)
        Dim colBtn = w - (colFull + colDate + colStat + colIn + colOut + padding * 2)

        ' Header
        g.FillRectangle(Brushes.LightGray, 0, 0, w, headerHeight)
        g.DrawString("Fullname", fontHeader, Brushes.Black, padding, 10)
        g.DrawString("Date", fontHeader, Brushes.Black, colFull + padding, 10)
        g.DrawString("Status", fontHeader, Brushes.Black, colFull + colDate + padding, 10)
        g.DrawString("Time In", fontHeader, Brushes.Black, colFull + colDate + colStat + padding, 10)
        g.DrawString("Time Out", fontHeader, Brushes.Black, colFull + colDate + colStat + colIn + padding, 10)
        g.DrawString("Action", fontHeader, Brushes.Black, colFull + colDate + colStat + colIn + colOut + padding, 10)

        ' Rows
        For i As Integer = 0 To filteredTable.Rows.Count - 1
            Dim y = headerHeight + i * rowHeight
            g.FillRectangle(If(i Mod 2 = 0, Brushes.WhiteSmoke, Brushes.White), 0, y, w, rowHeight)

            Dim r = filteredTable.Rows(i)

            g.DrawString(r("fullname").ToString(), fontRow, Brushes.Black, padding, y + 8)
            g.DrawString(CDate(r("schedule_date")).ToString("yyyy-MM-dd"), fontRow, Brushes.Black, colFull + padding, y + 8)
            g.DrawString(r("status").ToString(), fontRow, Brushes.Black, colFull + colDate + padding, y + 8)
            g.DrawString(r("time_in").ToString(), fontRow, Brushes.Black, colFull + colDate + colStat + padding, y + 8)
            g.DrawString(r("time_out").ToString(), fontRow, Brushes.Black, colFull + colDate + colStat + colIn + padding, y + 8)

            ' Draw Set Button
            Dim isSet As Boolean = Convert.ToBoolean(r("is_set"))
            Dim btnRect As New Rectangle(colFull + colDate + colStat + colIn + colOut + padding, y + 5, colBtn - 10, 25)

            Using path = RoundedRect(btnRect, 8)
                g.FillPath(New SolidBrush(If(isSet, Color.Gray, Color.FromArgb(52, 152, 219))), path)
            End Using

            Dim txt = If(isSet, "Already Set", "Set")
            Dim ts = g.MeasureString(txt, fontRow)
            g.DrawString(txt, fontRow, Brushes.White, btnRect.X + (btnRect.Width - ts.Width) / 2, btnRect.Y + (btnRect.Height - ts.Height) / 2)
        Next
    End Sub

    ' =========================
    ' ROUNDED RECTANGLE
    ' =========================
    Private Function RoundedRect(r As Rectangle, rad As Integer) As GraphicsPath
        Dim p As New GraphicsPath()
        p.AddArc(r.X, r.Y, rad, rad, 180, 90)
        p.AddArc(r.Right - rad, r.Y, rad, rad, 270, 90)
        p.AddArc(r.Right - rad, r.Bottom - rad, rad, rad, 0, 90)
        p.AddArc(r.X, r.Bottom - rad, rad, rad, 90, 90)
        p.CloseFigure()
        Return p
    End Function

End Class
