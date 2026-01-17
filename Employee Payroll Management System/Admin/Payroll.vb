Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Threading.Tasks
Imports System.Globalization

Public Class Payroll

    Private conn As New MySqlConnection("Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;")
    Private employeesTable As DataTable

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub Payroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True

        LoadEmployees()

        ' ===== TAB ORDER =====
        employee.TabIndex = 0
        Month.TabIndex = 1
        Year.TabIndex = 2
        Salary.TabIndex = 3
        Deduction.TabIndex = 4
        Notes.TabIndex = 5
        Pay.TabIndex = 6

        ' ===== EMPLOYEE DROPDOWN =====
        employee.DropDownStyle = ComboBoxStyle.DropDownList

        ' ===== MONTH PICKER (MONTH ONLY) =====
        Month.Format = DateTimePickerFormat.Custom
        Month.CustomFormat = "MMMM"
        Month.ShowUpDown = True

        ' ===== YEAR DOMAINUPDOWN =====
        Year.Items.Clear()
        Dim currentYear As Integer = DateTime.Now.Year
        For y As Integer = currentYear - 20 To currentYear + 1
            Year.Items.Add(y.ToString())
        Next
        Year.SelectedItem = currentYear.ToString()
        Year.ReadOnly = True      ' ❌ no typing
        Year.Wrap = True          ' optional (scroll loop)

        Salary.Clear()
        Deduction.Text = ""
    End Sub

    ' =========================
    ' KEYBEHAVIOR: ENTER AS TAB
    ' =========================
    Private Sub Year_KeyDown(sender As Object, e As KeyEventArgs) Handles Year.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.SelectNextControl(Year, True, True, True, True)
        End If
    End Sub

    Private Sub TextBox_EnterAsTab(sender As Object, e As KeyEventArgs) _
    Handles Salary.KeyDown, Deduction.KeyDown, Notes.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.SelectNextControl(DirectCast(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub Control_EnterBehavior(sender As Object, e As KeyEventArgs) _
    Handles employee.KeyDown, Year.KeyDown, Month.KeyDown

        If e.KeyCode <> Keys.Enter Then Exit Sub
        e.SuppressKeyPress = True

        ' ComboBox behavior
        If TypeOf sender Is ComboBox Then
            Dim cb As ComboBox = CType(sender, ComboBox)
            If Not cb.DroppedDown Then
                cb.DroppedDown = True
            Else
                Me.SelectNextControl(cb, True, True, True, True)
            End If
        ElseIf TypeOf sender Is DateTimePicker Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub Pay_KeyDown(sender As Object, e As KeyEventArgs) Handles Pay.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Pay.PerformClick()
        End If
    End Sub

    ' =========================
    ' LOAD EMPLOYEES (ACTIVE ONLY)
    ' =========================
    Private Sub LoadEmployees()
        Try
            Dim sql As String =
                "SELECT id, fullname, salary, job_position 
                 FROM employees 
                 WHERE status = 'Active'
                 ORDER BY fullname"

            Dim adapter As New MySqlDataAdapter(sql, conn)
            employeesTable = New DataTable()
            adapter.Fill(employeesTable)

            employee.Items.Clear()
            For Each row As DataRow In employeesTable.Rows
                employee.Items.Add(row("fullname").ToString())
            Next

        Catch ex As Exception
            ShowToast("⚠ Error loading employees: " & ex.Message, Color.Red)
        End Try
    End Sub

    ' =========================
    ' EMPLOYEE SELECTED
    ' =========================
    Private Sub employee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles employee.SelectedIndexChanged
        If employee.SelectedIndex = -1 Or Year.SelectedItem Is Nothing Then Exit Sub

        Dim empName As String = employee.SelectedItem.ToString()
        UpdateAttendanceCounts(empName)

        Dim row = employeesTable.Select("fullname='" & empName.Replace("'", "''") & "'").FirstOrDefault()
        If row IsNot Nothing Then
            Salary.Text = FormatNumberForTextbox(Convert.ToDecimal(row("salary")))
        End If
    End Sub

    ' =========================
    ' MONTH / YEAR CHANGED
    ' =========================
    Private Sub Month_ValueChanged(sender As Object, e As EventArgs) Handles Month.ValueChanged
        If employee.SelectedIndex <> -1 Then
            UpdateAttendanceCounts(employee.SelectedItem.ToString())
        End If
    End Sub

    Private Sub Year_SelectedItemChanged(sender As Object, e As EventArgs) Handles Year.SelectedItemChanged
        If employee.SelectedIndex <> -1 Then
            UpdateAttendanceCounts(employee.SelectedItem.ToString())
        End If
    End Sub

    ' =========================
    ' UPDATE ATTENDANCE
    ' =========================
    Private Sub UpdateAttendanceCounts(employeeName As String)
        Try
            Dim monthNum As Integer = Month.Value.Month
            Dim yearNum As Integer = CInt(Year.SelectedItem)

            Dim sql As String =
            "SELECT
                SUM(CASE WHEN status='Present' THEN 1 ELSE 0 END) AS PresentCount,
                SUM(CASE WHEN status='Absent' THEN 1 ELSE 0 END) AS AbsentCount,
                SUM(CASE WHEN status='Half Day' THEN 1 ELSE 0 END) AS HalfdayCount,
                SUM(CASE WHEN status='Late' THEN 1 ELSE 0 END) AS LateCount
             FROM attendance
             WHERE fullname=@name
             AND MONTH(attendance_date)=@m
             AND YEAR(attendance_date)=@y"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@name", employeeName)
                cmd.Parameters.AddWithValue("@m", monthNum)
                cmd.Parameters.AddWithValue("@y", yearNum)

                conn.Open()
                Using r = cmd.ExecuteReader()
                    If r.Read() Then
                        Present.Text = If(IsDBNull(r("PresentCount")), "0", r("PresentCount").ToString())
                        Absent.Text = If(IsDBNull(r("AbsentCount")), "0", r("AbsentCount").ToString())
                        Halfday.Text = If(IsDBNull(r("HalfdayCount")), "0", r("HalfdayCount").ToString())
                        late.Text = If(IsDBNull(r("LateCount")), "0", r("LateCount").ToString())
                    End If
                End Using
                conn.Close()
            End Using

        Catch ex As Exception
            If conn.State = ConnectionState.Open Then conn.Close()
            ShowToast("❌ Attendance error: " & ex.Message, Color.Red)
        End Try
    End Sub

    ' =========================
    ' PAY BUTTON
    ' =========================
    Private Sub Pay_Click(sender As Object, e As EventArgs) Handles Pay.Click
        If employee.SelectedIndex = -1 Then
            ShowToast("⚠ Select employee", Color.Red)
            Exit Sub
        End If

        Dim employeeName As String = employee.SelectedItem.ToString()
        Dim monthText As String = Month.Value.ToString("MMMM") & " " & Year.SelectedItem.ToString()
        Dim presentDays As Integer = CInt(Present.Text)

        Dim salaryAmount As Decimal = CDec(Salary.Text.Replace(",", ""))
        Dim deductionAmount As Decimal = CDec(Deduction.Text.Replace(",", ""))

        Dim row = employeesTable.Select("fullname='" & employeeName.Replace("'", "''") & "'").FirstOrDefault()
        Dim position As String = If(row IsNot Nothing, row("job_position").ToString(), "")

        Try
            Dim sql =
            "INSERT INTO payroll (employee_name, month, year, salary, deduction, notes)
             VALUES (@n,@m,@y,@s,@d,@no)"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@n", employeeName)
                cmd.Parameters.AddWithValue("@m", Month.Value.Month)
                cmd.Parameters.AddWithValue("@y", CInt(Year.SelectedItem))
                cmd.Parameters.AddWithValue("@s", salaryAmount)
                cmd.Parameters.AddWithValue("@d", deductionAmount)
                cmd.Parameters.AddWithValue("@no", Notes.Text)

                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
            End Using

            Dim net As Decimal = salaryAmount - deductionAmount
            Dim payslip As New Payslip(employeeName, position, monthText, presentDays, salaryAmount, deductionAmount, net)
            payslip.ShowDialog()

            ShowToast("✅ Payroll generated!", Color.Green)

        Catch ex As Exception
            If conn.State = ConnectionState.Open Then conn.Close()
            ShowToast("❌ Payroll error: " & ex.Message, Color.Red)
        End Try
    End Sub

    ' =========================
    ' TOAST
    ' =========================
    Private Async Sub ShowToast(msg As String, bg As Color)
        Dim p As New Panel With {.Size = New Size(360, 45), .BackColor = bg,
            .Location = New Point(Me.Width - 380, 10)}

        Dim l As New Label With {.Text = msg, .Dock = DockStyle.Fill,
            .ForeColor = Color.White, .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .TextAlign = ContentAlignment.MiddleLeft, .Padding = New Padding(10, 0, 0, 0)}

        p.Controls.Add(l)
        Me.Controls.Add(p)
        Await Task.Delay(3000)
        Me.Controls.Remove(p)
    End Sub

    ' =========================
    ' NUMBER ONLY + AUTO THOUSAND SEPARATOR
    ' =========================
    Private Sub Salary_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Salary.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub Deduction_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Deduction.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub Salary_TextChanged(sender As Object, e As EventArgs) Handles Salary.TextChanged
        FormatTextboxWithSeparator(Salary)
    End Sub

    Private Sub Deduction_TextChanged(sender As Object, e As EventArgs) Handles Deduction.TextChanged
        FormatTextboxWithSeparator(Deduction)
    End Sub

    ' =========================
    ' HELPER FUNCTION: FORMAT NUMBER
    ' =========================
    Private Sub FormatTextboxWithSeparator(tb As TextBox)
        If String.IsNullOrEmpty(tb.Text) Then Exit Sub

        Dim selStart As Integer = tb.SelectionStart
        Dim value As String = tb.Text.Replace(",", "").Replace(".", "")
        Dim number As Decimal
        If Decimal.TryParse(value, number) Then
            tb.Text = String.Format(CultureInfo.InvariantCulture, "{0:N0}", number)
            tb.SelectionStart = Math.Min(selStart + 1, tb.Text.Length)
        End If
    End Sub

    ' =========================
    ' FORMAT DECIMAL NUMBER
    ' =========================
    Private Function FormatNumberForTextbox(value As Decimal) As String
        Return String.Format(CultureInfo.InvariantCulture, "{0:N0}", value)
    End Function

End Class
