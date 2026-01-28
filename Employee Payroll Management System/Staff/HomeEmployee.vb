Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Data

Public Class HomeEmployee

    Private EmployeeName As String

    Private conn As New MySqlConnection(
        "Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;"
    )

    Private attendanceTable As DataTable

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

        LoadAttendanceCounts()
        LoadAttendanceData()
        attendancePanel.Invalidate()

        InitializeTimeComboBoxes()
        InitializeStatusComboBox()
    End Sub

    ' =========================
    ' LOAD COUNTS (HALF DAY / ABSENT)
    ' =========================
    Private Sub LoadAttendanceCounts()
        Try
            conn.Open()

            Dim sql As String =
                "SELECT 
                    SUM(CASE WHEN status='Half Day' THEN 1 ELSE 0 END) AS HalfdayCount,
                    SUM(CASE WHEN status='Absent' THEN 1 ELSE 0 END) AS AbsentCount
                 FROM attendance
                 WHERE fullname=@fullname"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@fullname", EmployeeName)
                Using r = cmd.ExecuteReader()
                    If r.Read() Then
                        halfday.Text = If(IsDBNull(r("HalfdayCount")), "0", r("HalfdayCount").ToString())
                        absentday.Text = If(IsDBNull(r("AbsentCount")), "0", r("AbsentCount").ToString())
                        presentday.Text = "0"
                        late.Text = "0"
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
                 AND status IN ('Half Day','Absent')
                 ORDER BY attendance_date DESC"

            Dim da As New MySqlDataAdapter(sql, conn)
            da.SelectCommand.Parameters.AddWithValue("@fullname", EmployeeName)

            attendanceTable = New DataTable()
            da.Fill(attendanceTable)

        Catch ex As Exception
            MessageBox.Show("Error loading attendance: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' =========================
    ' PAINT PANEL
    ' =========================
    Private Sub attendancePanel_Paint(sender As Object, e As PaintEventArgs) Handles attendancePanel.Paint
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.Clear(Color.White)

        If attendanceTable Is Nothing Then Exit Sub

        Dim w = attendancePanel.Width
        Dim fontHeader As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim fontRow As New Font("Segoe UI", 9)

        Dim colName = CInt(w * 0.3)
        Dim colDate = CInt(w * 0.3)
        Dim colStatus = CInt(w * 0.2)
        Dim colEmpStatus = w - (colName + colDate + colStatus + padding * 2)

        g.FillRectangle(Brushes.LightGray, 0, 0, w, headerHeight)
        g.DrawString("Name", fontHeader, Brushes.Black, padding, 10)
        g.DrawString("Date", fontHeader, Brushes.Black, colName + padding, 10)
        g.DrawString("Status", fontHeader, Brushes.Black, colName + colDate + padding, 10)
        g.DrawString("Employee Status", fontHeader, Brushes.Black,
                     colName + colDate + colStatus + padding, 10)

        For i = 0 To attendanceTable.Rows.Count - 1
            Dim y = headerHeight + i * rowHeight
            g.FillRectangle(If(i Mod 2 = 0, Brushes.WhiteSmoke, Brushes.White),
                            0, y, w, rowHeight)

            Dim r = attendanceTable.Rows(i)
            Dim empStatus = If(r("status").ToString() = "Absent", "Inactive", "Active")

            g.DrawString(r("fullname").ToString(), fontRow, Brushes.Black, padding, y + 8)
            g.DrawString(CDate(r("attendance_date")).ToString("MMMM d, yyyy"),
                         fontRow, Brushes.Black, colName + padding, y + 8)
            g.DrawString(r("status").ToString(),
                         fontRow, Brushes.Black, colName + colDate + padding, y + 8)

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
    Private Function RoundedRect(r As Rectangle, rad As Integer) As GraphicsPath
        Dim p As New GraphicsPath()
        p.AddArc(r.X, r.Y, rad, rad, 180, 90)
        p.AddArc(r.Right - rad, r.Y, rad, rad, 270, 90)
        p.AddArc(r.Right - rad, r.Bottom - rad, rad, rad, 0, 90)
        p.AddArc(r.X, r.Bottom - rad, rad, rad, 90, 90)
        p.CloseFigure()
        Return p
    End Function

    ' =========================
    ' TIME COMBOS
    ' =========================
    Private Sub InitializeTimeComboBoxes()
        TimeIn.DropDownStyle = ComboBoxStyle.DropDownList
        TimeOut.DropDownStyle = ComboBoxStyle.DropDownList

        TimeIn.Items.Clear()
        TimeOut.Items.Clear()

        For h = 0 To 23
            Dim ampm = If(h < 12, "AM", "PM")
            Dim hr = If(h Mod 12 = 0, 12, h Mod 12)
            Dim t = hr.ToString("00") & ":00 " & ampm
            TimeIn.Items.Add(t)
            TimeOut.Items.Add(t)
        Next

        TimeIn.SelectedIndex = 0
        TimeOut.SelectedIndex = 0
    End Sub

    ' =========================
    ' STATUS COMBO (ONLY 2)
    ' =========================
    Private Sub InitializeStatusComboBox()
        Status.DropDownStyle = ComboBoxStyle.DropDownList
        Status.Items.Clear()
        Status.Items.AddRange(New String() {"Half Day", "Absent"})
        Status.SelectedIndex = 0
    End Sub

    ' =========================
    ' AUTO ZERO TIME IF ABSENT
    ' =========================
    Private Sub Status_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Status.SelectedIndexChanged
        If Status.SelectedItem.ToString() = "Absent" Then
            Dim idx = TimeIn.Items.IndexOf("12:00 AM")
            If idx >= 0 Then
                TimeIn.SelectedIndex = idx
                TimeOut.SelectedIndex = idx
            End If
        End If
    End Sub

    ' =========================
    ' SAVE SCHEDULE
    ' =========================
    Private Sub Setscedule_Click(sender As Object, e As EventArgs) Handles Setscedule.Click
        Try
            conn.Open()

            Dim sql As String =
                "INSERT INTO set_schedule
                (fullname, schedule_date, status, time_in, time_out)
                VALUES (@fn,@dt,@st,@ti,@to)"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@fn", EmployeeName)
                cmd.Parameters.AddWithValue("@dt", DateTimePicker1.Value.Date)
                cmd.Parameters.AddWithValue("@st", Status.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@ti", TimeIn.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@to", TimeOut.SelectedItem.ToString())
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Schedule saved successfully")

        Catch ex As Exception
            MessageBox.Show("Error saving schedule: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

End Class
