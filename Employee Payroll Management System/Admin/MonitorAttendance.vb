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
        viewemployeedata.AutoScroll = True
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

        Employedropdown.SelectedIndex = -1
        checkin.SelectedIndex = -1
        checkout.SelectedIndex = -1
        status.SelectedIndex = -1

        monthofdate.Format = DateTimePickerFormat.Custom
        monthofdate.CustomFormat = "MMMM dd yyyy"

        attendanceTable = Nothing
        viewemployeedata.Invalidate()

        ' Reset counters
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
            Dim sql As String = "SELECT id, fullname, email FROM employees"
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
        If Employedropdown.SelectedIndex <> -1 Then
            Dim drv As DataRowView = CType(Employedropdown.SelectedItem, DataRowView)
            nameemployee.Text = drv("fullname").ToString()
            emailofemployee.Text = drv("email").ToString()

            ' 🔥 LOAD ONLY ATTENDANCE OF SELECTED EMPLOYEE
            LoadAttendance(CInt(drv("id")))
        Else
            SetDefaultValues()
        End If
    End Sub

    ' =========================
    ' TIMES + STATUS
    ' =========================
    Private Sub LoadCheckInTimes()
        checkin.Items.Clear()
        checkin.Items.AddRange({"08:00 AM", "08:30 AM", "09:00 AM", "09:30 AM"})
    End Sub

    Private Sub LoadCheckOutTimes()
        checkout.Items.Clear()
        checkout.Items.AddRange({"04:00 PM", "05:00 PM", "06:00 PM"})
    End Sub

    Private Sub LoadStatus()
        status.Items.Clear()
        status.Items.AddRange({"Present", "Absent", "Late", "Half Day"})
    End Sub

    ' =========================
    ' SAVE ATTENDANCE
    ' =========================
    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        If Employedropdown.SelectedIndex = -1 Or status.SelectedIndex = -1 Then
            MessageBox.Show("Please complete all fields")
            Exit Sub
        End If

        Try
            conn.Open()

            Dim sql =
                "INSERT INTO attendance 
                (employee_id, fullname, email, attendance_date, checkin_time, checkout_time, status)
                VALUES (@eid,@fn,@em,@dt,@cin,@cout,@st)"

            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@eid", Employedropdown.SelectedValue)
            cmd.Parameters.AddWithValue("@fn", nameemployee.Text)
            cmd.Parameters.AddWithValue("@em", emailofemployee.Text)
            cmd.Parameters.AddWithValue("@dt", monthofdate.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@cin", If(checkin.SelectedIndex = -1, "N/A", checkin.Text))
            cmd.Parameters.AddWithValue("@cout", If(checkout.SelectedIndex = -1, "N/A", checkout.Text))
            cmd.Parameters.AddWithValue("@st", status.Text)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Attendance saved")

            ' 🔥 REFRESH TABLE FOR SELECTED EMPLOYEE ONLY
            LoadAttendance(CInt(Employedropdown.SelectedValue))

            ' Reset only checkin/checkout/status, keep employee selected
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
    ' LOAD ATTENDANCE FOR SPECIFIC EMPLOYEE
    ' =========================
    Private Sub LoadAttendance(empId As Integer)
        Try
            Dim sql As String =
                "SELECT fullname, email, attendance_date, checkin_time, checkout_time, status 
                 FROM attendance WHERE employee_id = @eid ORDER BY id DESC"

            Dim da As New MySqlDataAdapter(sql, conn)
            da.SelectCommand.Parameters.AddWithValue("@eid", empId)

            attendanceTable = New DataTable
            da.Fill(attendanceTable)

            ' 🔥 UPDATE COUNTERS AUTOMATICALLY
            UpdateAttendanceCounts()

            ' 🔥 CALCULATE TOTAL HEIGHT FOR SCROLL
            Dim totalHeight As Integer = headerHeight + (attendanceTable.Rows.Count * rowHeight) + 20
            viewemployeedata.AutoScrollMinSize = New Size(0, totalHeight)

            ' 🔥 AUTO SCROLL TO BOTTOM IF NEEDED
            Dim maxScroll As Integer = totalHeight - viewemployeedata.ClientSize.Height
            If maxScroll > 0 Then
                viewemployeedata.AutoScrollPosition = New Point(0, maxScroll)
            Else
                viewemployeedata.AutoScrollPosition = New Point(0, 0)
            End If

            viewemployeedata.Invalidate()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ' =========================
    ' UPDATE ATTENDANCE COUNTERS
    ' =========================
    Private Sub UpdateAttendanceCounts()
        If attendanceTable Is Nothing OrElse attendanceTable.Rows.Count = 0 Then
            presentcount.Text = "0"
            absentcount.Text = "0"
            latedayscount.Text = "0"
            halfdaycount.Text = "0"
            Exit Sub
        End If

        presentcount.Text = attendanceTable.AsEnumerable().Count(Function(r) r("status").ToString() = "Present").ToString()
        absentcount.Text = attendanceTable.AsEnumerable().Count(Function(r) r("status").ToString() = "Absent").ToString()
        latedayscount.Text = attendanceTable.AsEnumerable().Count(Function(r) r("status").ToString() = "Late").ToString()
        halfdaycount.Text = attendanceTable.AsEnumerable().Count(Function(r) r("status").ToString() = "Half Day").ToString()
    End Sub

    ' =========================
    ' DRAW TABLE WITH SCROLL
    ' =========================
    Private Sub viewemployeedata_Paint(sender As Object, e As PaintEventArgs) Handles viewemployeedata.Paint
        Dim g As Graphics = e.Graphics
        Dim scrollY As Integer = viewemployeedata.AutoScrollPosition.Y

        g.TranslateTransform(0, scrollY)
        g.FillRectangle(Brushes.White, 0, -scrollY,
                        viewemployeedata.Width, viewemployeedata.Height)

        Dim fontHeader As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim fontRow As New Font("Segoe UI", 9)

        Dim w As Integer = viewemployeedata.Width

        ' HEADER
        g.FillRectangle(Brushes.LightGray, 0, 0, w, headerHeight)
        g.DrawString("Name", fontHeader, Brushes.Black, padding, 12)
        g.DrawString("Email", fontHeader, Brushes.Black, CSng(w * 0.25), 12)
        g.DrawString("Date", fontHeader, Brushes.Black, CSng(w * 0.48), 12)
        g.DrawString("In", fontHeader, Brushes.Black, CSng(w * 0.63), 12)
        g.DrawString("Out", fontHeader, Brushes.Black, CSng(w * 0.73), 12)
        g.DrawString("Status", fontHeader, Brushes.Black, CSng(w * 0.83), 12)

        If attendanceTable Is Nothing Then Exit Sub

        ' ROWS
        For i As Integer = 0 To attendanceTable.Rows.Count - 1
            Dim y As Integer = headerHeight + i * rowHeight

            If i Mod 2 = 0 Then
                g.FillRectangle(Brushes.WhiteSmoke, 0, y, w, rowHeight)
            End If

            Dim r = attendanceTable.Rows(i)

            g.DrawString(r("fullname").ToString(), fontRow, Brushes.Black, padding, y + 14)
            g.DrawString(r("email").ToString(), fontRow, Brushes.Black, CSng(w * 0.25), y + 14)
            g.DrawString(CDate(r("attendance_date")).ToString("MMMM dd yyyy"),
                         fontRow, Brushes.Black, CSng(w * 0.48), y + 14)
            g.DrawString(r("checkin_time").ToString(), fontRow, Brushes.Black, CSng(w * 0.63), y + 14)
            g.DrawString(r("checkout_time").ToString(), fontRow, Brushes.Black, CSng(w * 0.73), y + 14)
            g.DrawString(r("status").ToString(), fontRow, Brushes.Black, CSng(w * 0.83), y + 14)
        Next

        g.ResetTransform()
    End Sub

End Class
