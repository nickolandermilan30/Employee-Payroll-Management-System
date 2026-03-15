Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class MonitorAttendance

    ' =========================
    ' DATABASE CONNECTION
    ' =========================
    Private conn As New MySqlConnection("Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;")
    Private attendanceTable As DataTable

    ' UI Layout for Drawing
    Private headerHeight As Integer = 45
    Private rowHeight As Integer = 45
    Private padding As Integer = 10

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub MonitorAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        viewemployeedata.AutoScroll = True

        ' ===== TIME PICKER SETUP (MANUAL SETTING) =====
        ' Siguraduhin na ang Format property sa Designer ay Custom
        checkin.Format = DateTimePickerFormat.Custom
        checkin.CustomFormat = "hh:mm tt" ' Oras at AM/PM lang
        checkin.ShowUpDown = True ' Para madaling i-scroll ang oras
        checkin.Enabled = True ' Enabled na siya para makapag-set ka

        checkout.Format = DateTimePickerFormat.Custom
        checkout.CustomFormat = "hh:mm tt"
        checkout.ShowUpDown = True
        checkout.Enabled = True

        ' ===== DATE PICKER =====
        monthofdate.Format = DateTimePickerFormat.Custom
        monthofdate.CustomFormat = "MMMM dd, yyyy"

        ' ===== DROPDOWNS =====
        Employedropdown.DropDownStyle = ComboBoxStyle.DropDownList
        status.DropDownStyle = ComboBoxStyle.DropDownList

        ' ===== LOAD INITIAL DATA =====
        LoadEmployees()
        LoadStatus()
        ResetUI()
    End Sub

    ' =========================
    ' SAVE ATTENDANCE
    ' =========================
    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        ' Validation
        If Not TypeOf Employedropdown.SelectedValue Is Integer Or status.SelectedIndex = -1 Then
            MessageBox.Show("Please select an Employee and Status.")
            Exit Sub
        End If

        Try
            conn.Open()

            ' Kukunin ang piniling oras mula sa DateTimePickers
            Dim timeInStr As String = checkin.Value.ToString("hh:mm tt")
            Dim timeOutStr As String = checkout.Value.ToString("hh:mm tt")

            ' SQL Query
            Dim sql = "INSERT INTO attendance " &
                      "(employee_id, fullname, email, attendance_date, checkin_time, checkout_time, status) " &
                      "VALUES (@eid, @fn, @em, @dt, @cin, @cout, @st)"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@eid", CInt(Employedropdown.SelectedValue))
                cmd.Parameters.AddWithValue("@fn", nameemployee.Text)
                cmd.Parameters.AddWithValue("@em", emailofemployee.Text)
                cmd.Parameters.AddWithValue("@dt", monthofdate.Value.Date)
                cmd.Parameters.AddWithValue("@cin", timeInStr)
                cmd.Parameters.AddWithValue("@cout", timeOutStr)
                cmd.Parameters.AddWithValue("@st", status.Text)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Attendance saved successfully!")
            LoadAttendance() ' Refresh table view

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' =========================
    ' LOAD DATA & UI UPDATES
    ' =========================
    Private Sub LoadEmployees()
        Try
            Dim da As New MySqlDataAdapter("SELECT id, fullname, email FROM employees", conn)
            Dim dt As New DataTable
            da.Fill(dt)
            Employedropdown.DataSource = dt
            Employedropdown.DisplayMember = "fullname"
            Employedropdown.ValueMember = "id"
            Employedropdown.SelectedIndex = -1
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadStatus()
        status.Items.Clear()
        status.Items.AddRange({"Present", "Absent", "Late", "Half Day"})
    End Sub

    Private Sub Employedropdown_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Employedropdown.SelectedIndexChanged
        If Employedropdown.SelectedIndex <> -1 AndAlso TypeOf Employedropdown.SelectedValue Is Integer Then
            Dim drv As DataRowView = CType(Employedropdown.SelectedItem, DataRowView)
            nameemployee.Text = drv("fullname").ToString()
            emailofemployee.Text = drv("email").ToString()
            LoadAttendance()
        End If
    End Sub

    Private Sub monthofdate_ValueChanged(sender As Object, e As EventArgs) Handles monthofdate.ValueChanged
        If TypeOf Employedropdown.SelectedValue Is Integer Then
            LoadAttendance()
        End If
    End Sub

    ' =========================
    ' ATTENDANCE LOGIC (MONTHLY)
    ' =========================
    Private Sub LoadAttendance()
        If Not TypeOf Employedropdown.SelectedValue Is Integer Then Exit Sub

        Try
            Dim sql = "SELECT fullname, email, attendance_date, checkin_time, checkout_time, status " &
                      "FROM attendance WHERE employee_id=@eid AND MONTH(attendance_date)=@m " &
                      "AND YEAR(attendance_date)=@y ORDER BY attendance_date DESC"

            Dim da As New MySqlDataAdapter(sql, conn)
            da.SelectCommand.Parameters.AddWithValue("@eid", CInt(Employedropdown.SelectedValue))
            da.SelectCommand.Parameters.AddWithValue("@m", monthofdate.Value.Month)
            da.SelectCommand.Parameters.AddWithValue("@y", monthofdate.Value.Year)

            attendanceTable = New DataTable()
            da.Fill(attendanceTable)

            UpdateAttendanceCounts()
            UpdateScroll()
            viewemployeedata.Invalidate()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub UpdateAttendanceCounts()
        presentcount.Text = "0" : absentcount.Text = "0"
        latedayscount.Text = "0" : halfdaycount.Text = "0"

        If attendanceTable IsNot Nothing Then
            presentcount.Text = attendanceTable.Select("status='Present'").Length.ToString()
            absentcount.Text = attendanceTable.Select("status='Absent'").Length.ToString()
            latedayscount.Text = attendanceTable.Select("status='Late'").Length.ToString()
            halfdaycount.Text = attendanceTable.Select("status='Half Day'").Length.ToString()
        End If
    End Sub

    Private Sub ResetUI()
        nameemployee.Text = "None"
        emailofemployee.Text = "None"
        status.SelectedIndex = -1
        checkin.Value = DateTime.Now
        checkout.Value = DateTime.Now
        attendanceTable = Nothing
        UpdateAttendanceCounts()
        viewemployeedata.Invalidate()
    End Sub

    ' =========================
    ' DRAWING & TABLE DISPLAY
    ' =========================
    Private Sub UpdateScroll()
        If attendanceTable IsNot Nothing Then
            viewemployeedata.AutoScrollMinSize = New Size(0, headerHeight + (attendanceTable.Rows.Count * rowHeight) + 20)
        End If
    End Sub

    Private Sub viewemployeedata_Paint(sender As Object, e As PaintEventArgs) Handles viewemployeedata.Paint
        If attendanceTable Is Nothing Then Exit Sub

        Dim g = e.Graphics
        g.TranslateTransform(0, viewemployeedata.AutoScrollPosition.Y)

        Dim fontHeader As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim fontRow As New Font("Segoe UI", 9)
        Dim w = viewemployeedata.Width

        ' Header
        g.FillRectangle(Brushes.LightGray, 0, 0, w, headerHeight)
        g.DrawString("Name", fontHeader, Brushes.Black, padding, 12)
        g.DrawString("Email", fontHeader, Brushes.Black, w * 0.25F, 12)
        g.DrawString("Date", fontHeader, Brushes.Black, w * 0.48F, 12)
        g.DrawString("In", fontHeader, Brushes.Black, w * 0.63F, 12)
        g.DrawString("Out", fontHeader, Brushes.Black, w * 0.73F, 12)
        g.DrawString("Status", fontHeader, Brushes.Black, w * 0.83F, 12)

        ' Rows
        For i = 0 To attendanceTable.Rows.Count - 1
            Dim y = headerHeight + (i * rowHeight)
            If i Mod 2 = 0 Then g.FillRectangle(Brushes.WhiteSmoke, 0, y, w, rowHeight)

            Dim r = attendanceTable.Rows(i)
            g.DrawString(r("fullname").ToString(), fontRow, Brushes.Black, padding, y + 14)
            g.DrawString(r("email").ToString(), fontRow, Brushes.Black, w * 0.25F, y + 14)
            g.DrawString(CDate(r("attendance_date")).ToString("MMMM dd, yyyy"), fontRow, Brushes.Black, w * 0.48F, y + 14)
            g.DrawString(r("checkin_time").ToString(), fontRow, Brushes.Black, w * 0.63F, y + 14)
            g.DrawString(r("checkout_time").ToString(), fontRow, Brushes.Black, w * 0.73F, y + 14)
            g.DrawString(r("status").ToString(), fontRow, Brushes.Black, w * 0.83F, y + 14)
        Next

        g.ResetTransform()
    End Sub

    Private Sub Notification_Click(sender As Object, e As EventArgs) Handles Notification.Click
        Dim notif As New Notification()
        notif.Owner = Me
        notif.ShowDialog()
    End Sub

End Class