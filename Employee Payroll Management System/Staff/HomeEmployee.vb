Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class HomeEmployee

    ' =========================
    ' STORE PASSED EMPLOYEE NAME
    ' =========================
    Private EmployeeName As String

    ' =========================
    ' DATABASE CONNECTION
    ' =========================
    Private conn As New MySqlConnection(
        "Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;"
    )

    ' =========================
    ' ATTENDANCE DATA TABLE
    ' =========================
    Private attendanceTable As DataTable

    ' =========================
    ' UI LAYOUT
    ' =========================
    Private headerHeight As Integer = 40
    Private rowHeight As Integer = 35
    Private padding As Integer = 10

    ' =========================
    ' CONSTRUCTOR
    ' =========================
    Public Sub New(fullname As String)
        InitializeComponent()
        EmployeeName = fullname
    End Sub

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub HomeEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = EmployeeName

        LoadAttendanceCounts()   ' ✅ balik count
        LoadAttendanceData()     ' panel data
        attendancePanel.Invalidate()

        ' Initialize ComboBoxes
        InitializeTimeComboBoxes()
        InitializeStatusComboBox()
    End Sub

    ' =========================
    ' LOAD ATTENDANCE COUNTS
    ' =========================
    Private Sub LoadAttendanceCounts()
        Try
            conn.Open()
            Dim sql As String =
                "SELECT 
                    SUM(CASE WHEN status='Present' THEN 1 ELSE 0 END) AS PresentCount,
                    SUM(CASE WHEN status='Absent' THEN 1 ELSE 0 END) AS AbsentCount,
                    SUM(CASE WHEN status='Half Day' THEN 1 ELSE 0 END) AS HalfdayCount,
                    SUM(CASE WHEN status='Late' THEN 1 ELSE 0 END) AS LateCount
                 FROM attendance
                 WHERE fullname=@fullname"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@fullname", EmployeeName)
                Using r = cmd.ExecuteReader()
                    If r.Read() Then
                        presentday.Text = If(IsDBNull(r("PresentCount")), "0", r("PresentCount").ToString())
                        absentday.Text = If(IsDBNull(r("AbsentCount")), "0", r("AbsentCount").ToString())
                        halfday.Text = If(IsDBNull(r("HalfdayCount")), "0", r("HalfdayCount").ToString())
                        late.Text = If(IsDBNull(r("LateCount")), "0", r("LateCount").ToString())
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading counts: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' =========================
    ' LOAD ATTENDANCE TABLE
    ' =========================
    Private Sub LoadAttendanceData()
        Try
            conn.Open()
            Dim sql As String =
                "SELECT fullname, attendance_date, status
                 FROM attendance
                 WHERE fullname=@fullname
                 ORDER BY attendance_date DESC"

            Dim adapter As New MySqlDataAdapter(sql, conn)
            adapter.SelectCommand.Parameters.AddWithValue("@fullname", EmployeeName)

            attendanceTable = New DataTable()
            adapter.Fill(attendanceTable)
        Catch ex As Exception
            MessageBox.Show("Error loading attendance: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' =========================
    ' PAINT ATTENDANCE PANEL
    ' =========================
    Private Sub attendancePanel_Paint(sender As Object, e As PaintEventArgs) Handles attendancePanel.Paint
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.Clear(Color.White)

        If attendanceTable Is Nothing Then Return

        Dim panelWidth = attendancePanel.Width
        Dim fontHeader As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim fontRow As New Font("Segoe UI", 9)

        Dim colName = CInt(panelWidth * 0.25)
        Dim colDate = CInt(panelWidth * 0.25)
        Dim colStatus = CInt(panelWidth * 0.2)
        Dim colEmpStatus = panelWidth - (colName + colDate + colStatus + padding * 2)

        ' HEADER
        g.FillRectangle(Brushes.LightGray, 0, 0, panelWidth, headerHeight)
        g.DrawString("Name", fontHeader, Brushes.Black, padding, 10)
        g.DrawString("Date", fontHeader, Brushes.Black, colName + padding, 10)
        g.DrawString("Status", fontHeader, Brushes.Black, colName + colDate + padding, 10)
        g.DrawString("Employee Status", fontHeader, Brushes.Black, colName + colDate + colStatus + padding, 10)

        ' ROWS
        For i = 0 To attendanceTable.Rows.Count - 1
            Dim y = headerHeight + i * rowHeight
            g.FillRectangle(If(i Mod 2 = 0, Brushes.WhiteSmoke, Brushes.White),
                            0, y, panelWidth, rowHeight)

            Dim row = attendanceTable.Rows(i)
            Dim fullname = row("fullname").ToString
            Dim d As Date = row("attendance_date")
            Dim status = row("status").ToString
            Dim empStatus = If(status = "Absent", "Inactive", "Active")

            g.DrawString(fullname, fontRow, Brushes.Black, padding, y + 8)
            g.DrawString(d.ToString("MMMM d, yyyy"), fontRow, Brushes.Black, colName + padding, y + 8)
            g.DrawString(status, fontRow, Brushes.Black, colName + colDate + padding, y + 8)

            ' STATUS BADGE
            Dim badgeRect As New Rectangle(
                colName + colDate + colStatus + padding,
                y + 5,
                colEmpStatus - 10,
                25
            )

            Dim badgeColor = If(empStatus = "Active",
                                 Color.FromArgb(46, 204, 113),
                                 Color.FromArgb(231, 76, 60))

            Using path = RoundedRect(badgeRect, 12)
                Using br As New SolidBrush(badgeColor)
                    g.FillPath(br, path)
                End Using
            End Using

            Dim ts = g.MeasureString(empStatus, fontRow)
            g.DrawString(empStatus, fontRow, Brushes.White,
                         badgeRect.X + (badgeRect.Width - ts.Width) / 2,
                         badgeRect.Y + (badgeRect.Height - ts.Height) / 2)
        Next
    End Sub

    ' =========================
    ' ROUNDED RECT
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
    ' INITIALIZE DROPDOWNS
    ' =========================
    Private Sub InitializeTimeComboBoxes()
        ' Make dropdown-only
        TimeIn.DropDownStyle = ComboBoxStyle.DropDownList
        TimeOut.DropDownStyle = ComboBoxStyle.DropDownList

        TimeIn.Items.Clear()
        TimeOut.Items.Clear()

        For h = 0 To 23
            Dim ampm As String = If(h < 12, "AM", "PM")
            Dim hour = If(h Mod 12 = 0, 12, h Mod 12)
            Dim t As String = hour.ToString("00") & ":00 " & ampm
            TimeIn.Items.Add(t)
            TimeOut.Items.Add(t)
        Next
        TimeIn.SelectedIndex = 0
        TimeOut.SelectedIndex = 0
    End Sub

    Private Sub InitializeStatusComboBox()
        ' Make dropdown-only
        Status.DropDownStyle = ComboBoxStyle.DropDownList

        Status.Items.Clear()
        Status.Items.AddRange(New String() {"Present", "Absent", "Half Day", "Late"})
        Status.SelectedIndex = 0
    End Sub

    ' =========================
    ' DROPDOWN EVENTS
    ' =========================
    Private Sub TimeIn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TimeIn.SelectedIndexChanged
    End Sub

    Private Sub TimeOut_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TimeOut.SelectedIndexChanged
    End Sub

    ' === SET TIME TO 00:00 IF ABSENT ===
    Private Sub Status_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Status.SelectedIndexChanged
        If Status.SelectedItem.ToString() = "Absent" Then
            ' Find index of "12:00 AM" in TimeIn/TimeOut
            Dim zeroIndex As Integer = TimeIn.Items.IndexOf("12:00 AM")
            If zeroIndex >= 0 Then
                TimeIn.SelectedIndex = zeroIndex
                TimeOut.SelectedIndex = zeroIndex
            End If
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
    End Sub

    ' =========================
    ' SAVE SCHEDULE TO DATABASE
    ' =========================
    Private Sub Setscedule_Click(sender As Object, e As EventArgs) Handles Setscedule.Click
        Try
            conn.Open()

            Dim sql As String =
                "INSERT INTO set_schedule (fullname, schedule_date, status, time_in, time_out)
                 VALUES (@fullname, @schedule_date, @status, @time_in, @time_out)"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@fullname", EmployeeName)
                cmd.Parameters.AddWithValue("@schedule_date", DateTimePicker1.Value.Date)
                cmd.Parameters.AddWithValue("@status", Status.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@time_in", TimeIn.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@time_out", TimeOut.SelectedItem.ToString())

                Dim result = cmd.ExecuteNonQuery()
                If result > 0 Then
                    MessageBox.Show("Schedule saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Failed to save schedule.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving schedule: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

End Class
