Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class MonitorAttendance

    ' =========================
    ' DATABASE CONNECTION
    ' =========================
    Private conn As New MySqlConnection(
        "Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;"
    )

    Private attendanceTable As DataTable

    ' UI layout
    Private headerHeight As Integer = 45
    Private rowHeight As Integer = 45
    Private padding As Integer = 10

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub MonitorAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        viewemployeedata.AutoScroll = True

        ' ===== TAB ORDER =====
        Employedropdown.TabIndex = 0
        monthofdate.TabIndex = 1
        checkin.TabIndex = 2
        checkout.TabIndex = 3
        status.TabIndex = 4
        save.TabIndex = 5

        ' ===== DROPDOWN = SELECT ONLY =====
        Employedropdown.DropDownStyle = ComboBoxStyle.DropDownList
        checkin.DropDownStyle = ComboBoxStyle.DropDownList
        checkout.DropDownStyle = ComboBoxStyle.DropDownList
        status.DropDownStyle = ComboBoxStyle.DropDownList

        LoadEmployees()
        SetDefaultValues()
        LoadCheckInTimes()
        LoadCheckOutTimes()
        LoadStatus()
    End Sub

    ' =========================
    ' DEFAULT VALUES
    ' =========================
    Private Sub SetDefaultValues()
        nameemployee.Text = "None"
        emailofemployee.Text = "None"

        checkin.SelectedIndex = -1
        checkout.SelectedIndex = -1
        status.SelectedIndex = -1

        ' MONTH PICKER (MONTH + YEAR ONLY)
        monthofdate.Format = DateTimePickerFormat.Custom
        monthofdate.CustomFormat = "MMMM yyyy"
        monthofdate.ShowUpDown = True

        attendanceTable = Nothing
        viewemployeedata.Invalidate()
        ResetCounters()
    End Sub

    ' =========================
    ' RESET COUNTERS
    ' =========================
    Private Sub ResetCounters()
        presentcount.Text = "0"
        absentcount.Text = "0"
        latedayscount.Text = "0"
        halfdaycount.Text = "0"
    End Sub

    ' =========================
    ' LOAD EMPLOYEES
    ' =========================
    Private Sub LoadEmployees()
        Try
            Dim sql = "SELECT id, fullname, email FROM employees"
            Dim da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable
            da.Fill(dt)

            Employedropdown.DataSource = dt
            Employedropdown.DisplayMember = "fullname"
            Employedropdown.ValueMember = "id"
            Employedropdown.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ' =========================
    ' EMPLOYEE SELECTED
    ' =========================
    Private Sub Employedropdown_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Employedropdown.SelectedIndexChanged

        If TypeOf Employedropdown.SelectedValue Is Integer Then
            Dim drv As DataRowView = CType(Employedropdown.SelectedItem, DataRowView)
            nameemployee.Text = drv("fullname").ToString()
            emailofemployee.Text = drv("email").ToString()
            LoadAttendance()
        End If

    End Sub

    ' =========================
    ' MONTH CHANGED
    ' =========================
    Private Sub monthofdate_ValueChanged(sender As Object, e As EventArgs) Handles monthofdate.ValueChanged
        If TypeOf Employedropdown.SelectedValue Is Integer Then
            LoadAttendance()
        End If
    End Sub

    Private Sub monthofdate_KeyDown(sender As Object, e As KeyEventArgs) Handles monthofdate.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.SelectNextControl(monthofdate, True, True, True, True)
        End If
    End Sub

    ' =========================
    ' TIMES + STATUS
    ' =========================
    Private Sub LoadCheckInTimes()
        checkin.Items.Clear()
        checkin.Items.AddRange(GenerateTimeList())
    End Sub

    Private Sub LoadCheckOutTimes()
        checkout.Items.Clear()
        checkout.Items.AddRange(GenerateTimeList())
    End Sub

    Private Sub LoadStatus()
        status.Items.Clear()
        status.Items.AddRange({"Present", "Absent", "Late", "Half Day"})
    End Sub

    ' =========================
    ' GENERATE TIME LIST 1:00 AM - 12:30 PM, AM/PM
    ' =========================
    Private Function GenerateTimeList() As String()
        Dim times As New List(Of String)
        ' AM hours
        For h As Integer = 1 To 12
            times.Add($"{h}:00 AM")
            times.Add($"{h}:30 AM")
        Next
        ' PM hours
        For h As Integer = 1 To 12
            times.Add($"{h}:00 PM")
            times.Add($"{h}:30 PM")
        Next
        Return times.ToArray()
    End Function

    Private Sub ComboBox_EnterBehavior(sender As Object, e As KeyEventArgs) _
    Handles Employedropdown.KeyDown, checkin.KeyDown, checkout.KeyDown, status.KeyDown

        Dim cb As ComboBox = CType(sender, ComboBox)

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If Not cb.DroppedDown Then
                cb.DroppedDown = True
            Else
                Me.SelectNextControl(cb, True, True, True, True)
            End If
        End If
    End Sub

    ' =========================
    ' SAVE ATTENDANCE
    ' =========================
    Private Sub save_KeyDown(sender As Object, e As KeyEventArgs) Handles save.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            save.PerformClick()
        End If
    End Sub

    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        If Not TypeOf Employedropdown.SelectedValue Is Integer Or status.SelectedIndex = -1 Then
            MessageBox.Show("Please complete all fields")
            Exit Sub
        End If

        Try
            conn.Open()

            Dim sql =
                "INSERT INTO attendance
                (employee_id, fullname, email, attendance_date, checkin_time, checkout_time, status)
                VALUES (@eid,@fn,@em,@dt,@cin,@cout,@st)"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@eid", CInt(Employedropdown.SelectedValue))
                cmd.Parameters.AddWithValue("@fn", nameemployee.Text)
                cmd.Parameters.AddWithValue("@em", emailofemployee.Text)
                cmd.Parameters.AddWithValue("@dt", monthofdate.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@cin", If(checkin.SelectedIndex = -1, "N/A", checkin.Text))
                cmd.Parameters.AddWithValue("@cout", If(checkout.SelectedIndex = -1, "N/A", checkout.Text))
                cmd.Parameters.AddWithValue("@st", status.Text)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Attendance saved")
            LoadAttendance()

            checkin.SelectedIndex = -1
            checkout.SelectedIndex = -1
            status.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' =========================
    ' LOAD ATTENDANCE (MONTHLY)
    ' =========================
    Private Sub LoadAttendance()
        If Not TypeOf Employedropdown.SelectedValue Is Integer Then Exit Sub

        Try
            Dim empId As Integer = CInt(Employedropdown.SelectedValue)
            Dim m As Integer = monthofdate.Value.Month
            Dim y As Integer = monthofdate.Value.Year

            Dim sql =
                "SELECT fullname,email,attendance_date,checkin_time,checkout_time,status
                 FROM attendance
                 WHERE employee_id=@eid
                 AND MONTH(attendance_date)=@m
                 AND YEAR(attendance_date)=@y
                 ORDER BY attendance_date DESC"

            Dim da As New MySqlDataAdapter(sql, conn)
            da.SelectCommand.Parameters.AddWithValue("@eid", empId)
            da.SelectCommand.Parameters.AddWithValue("@m", m)
            da.SelectCommand.Parameters.AddWithValue("@y", y)

            attendanceTable = New DataTable
            da.Fill(attendanceTable)

            UpdateAttendanceCounts()
            UpdateScroll()
            viewemployeedata.Invalidate()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ' =========================
    ' COUNTERS (MONTH ONLY)
    ' =========================
    Private Sub UpdateAttendanceCounts()
        ResetCounters()
        If attendanceTable Is Nothing Then Exit Sub

        presentcount.Text = attendanceTable.Select("status='Present'").Length
        absentcount.Text = attendanceTable.Select("status='Absent'").Length
        latedayscount.Text = attendanceTable.Select("status='Late'").Length
        halfdaycount.Text = attendanceTable.Select("status='Half Day'").Length
    End Sub

    ' =========================
    ' SCROLL
    ' =========================
    Private Sub UpdateScroll()
        viewemployeedata.AutoScrollMinSize =
            New Size(0, headerHeight + attendanceTable.Rows.Count * rowHeight + 20)
    End Sub

    ' =========================
    ' DRAW TABLE
    ' =========================
    Private Sub viewemployeedata_Paint(sender As Object, e As PaintEventArgs) Handles viewemployeedata.Paint
        If attendanceTable Is Nothing Then Exit Sub

        Dim g = e.Graphics
        Dim scrollY = viewemployeedata.AutoScrollPosition.Y
        g.TranslateTransform(0, scrollY)

        Dim fontHeader As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim fontRow As New Font("Segoe UI", 9)
        Dim w = viewemployeedata.Width

        g.FillRectangle(Brushes.LightGray, 0, 0, w, headerHeight)

        g.DrawString("Name", fontHeader, Brushes.Black, padding, 12)
        g.DrawString("Email", fontHeader, Brushes.Black, w * 0.25F, 12)
        g.DrawString("Date", fontHeader, Brushes.Black, w * 0.48F, 12)
        g.DrawString("In", fontHeader, Brushes.Black, w * 0.63F, 12)
        g.DrawString("Out", fontHeader, Brushes.Black, w * 0.73F, 12)
        g.DrawString("Status", fontHeader, Brushes.Black, w * 0.83F, 12)

        For i = 0 To attendanceTable.Rows.Count - 1
            Dim y = headerHeight + i * rowHeight
            If i Mod 2 = 0 Then g.FillRectangle(Brushes.WhiteSmoke, 0, y, w, rowHeight)

            Dim r = attendanceTable.Rows(i)
            g.DrawString(r("fullname").ToString(), fontRow, Brushes.Black, padding, y + 14)
            g.DrawString(r("email").ToString(), fontRow, Brushes.Black, w * 0.25F, y + 14)
            g.DrawString(CDate(r("attendance_date")).ToString("MMMM dd yyyy"), fontRow, Brushes.Black, w * 0.48F, y + 14)
            g.DrawString(r("checkin_time").ToString(), fontRow, Brushes.Black, w * 0.63F, y + 14)
            g.DrawString(r("checkout_time").ToString(), fontRow, Brushes.Black, w * 0.73F, y + 14)
            g.DrawString(r("status").ToString(), fontRow, Brushes.Black, w * 0.83F, y + 14)
        Next

        g.ResetTransform()
    End Sub

End Class
