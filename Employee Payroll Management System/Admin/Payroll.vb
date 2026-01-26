Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Threading.Tasks
Imports System.Globalization

Public Class Payroll

    Private conn As New MySqlConnection("Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;")
    Private employeesTable As DataTable
    Private deductionDetails As New List(Of String)

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub Payroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        LoadEmployees()

        employee.TabIndex = 0
        Month.TabIndex = 1
        Year.TabIndex = 2
        Salary.TabIndex = 3
        Deduction.TabIndex = 4
        Notes.TabIndex = 5
        daysdate.TabIndex = 6
        Pay.TabIndex = 7

        employee.DropDownStyle = ComboBoxStyle.DropDownList

        Month.Format = DateTimePickerFormat.Custom
        Month.CustomFormat = "MMMM"
        Month.ShowUpDown = True

        Year.Items.Clear()
        Dim currentYear As Integer = DateTime.Now.Year
        For y As Integer = currentYear - 50 To currentYear + 1
            Year.Items.Add(y.ToString())
        Next
        Year.SelectedItem = currentYear.ToString()
        Year.ReadOnly = True
        Year.Wrap = True

        Salary.Clear()
        Deduction.Clear()
        daysdate.Clear()
    End Sub

    ' =========================
    ' LOAD EMPLOYEES
    ' =========================
    Private Sub LoadEmployees()
        Try
            Dim sql As String =
                "SELECT id, fullname, salary, job_position 
                 FROM employees 
                 WHERE status='Active'
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
        If employee.SelectedIndex = -1 OrElse Year.SelectedItem Is Nothing Then Exit Sub

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
        If employee.SelectedIndex <> -1 Then UpdateAttendanceCounts(employee.SelectedItem.ToString())
    End Sub

    Private Sub Year_SelectedItemChanged(sender As Object, e As EventArgs) Handles Year.SelectedItemChanged
        If employee.SelectedIndex <> -1 Then UpdateAttendanceCounts(employee.SelectedItem.ToString())
    End Sub

    ' =========================
    ' UPDATE ATTENDANCE
    ' =========================
    Private Sub UpdateAttendanceCounts(employeeName As String)
        Try
            Dim sql As String =
                "SELECT
                    SUM(CASE WHEN status='Present' THEN 1 ELSE 0 END) AS PresentCount
                 FROM attendance
                 WHERE fullname=@name
                 AND MONTH(attendance_date)=@m
                 AND YEAR(attendance_date)=@y"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@name", employeeName)
                cmd.Parameters.AddWithValue("@m", Month.Value.Month)
                cmd.Parameters.AddWithValue("@y", CInt(Year.SelectedItem))

                conn.Open()
                Present.Text = cmd.ExecuteScalar().ToString()
                conn.Close()
            End Using
        Catch
            If conn.State = ConnectionState.Open Then conn.Close()
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

        Dim presentDays As Integer = 0
        If Not String.IsNullOrWhiteSpace(Present.Text) Then Integer.TryParse(Present.Text, presentDays)

        Dim salaryAmount As Decimal = 0D
        If Not String.IsNullOrWhiteSpace(Salary.Text) Then Decimal.TryParse(Salary.Text.Replace(",", ""), salaryAmount)

        Dim deductionAmount As Decimal = 0D
        If Not String.IsNullOrWhiteSpace(Deduction.Text) Then Decimal.TryParse(Deduction.Text.Replace(",", ""), deductionAmount)

        Dim notesText As String = If(String.IsNullOrWhiteSpace(Notes.Text), "N/A", Notes.Text)

        Dim employeeName As String = employee.SelectedItem.ToString()
        Dim monthText As String = Month.Value.ToString("MMMM") & " " & Year.SelectedItem.ToString()

        Dim row = employeesTable.Select("fullname='" & employeeName.Replace("'", "''") & "'").FirstOrDefault()
        Dim position As String = If(row IsNot Nothing, row("job_position").ToString(), "")

        Try
            Dim sql =
            "INSERT INTO payroll (employee_name, month, year, salary, deduction, notes)
             VALUES (@n,@m,@y,@s,@d,@no)"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@n", employeeName)
                cmd.Parameters.AddWithValue("@m", Month.Value.Month)
                cmd.Parameters.AddWithValue("@y", If(Year.SelectedItem IsNot Nothing, CInt(Year.SelectedItem), DateTime.Now.Year))
                cmd.Parameters.AddWithValue("@s", salaryAmount)
                cmd.Parameters.AddWithValue("@d", deductionAmount)
                cmd.Parameters.AddWithValue("@no", notesText)

                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
            End Using

            Dim net As Decimal = salaryAmount - deductionAmount

            ' PAYSLIP - PASS DEDUCTION DETAILS
            Dim payslip As New Payslip(
                employeeName,
                position,
                monthText,
                presentDays,
                salaryAmount,
                deductionAmount,
                net,
                deductionDetails
            )

            payslip.ShowDialog()
            ShowToast("✅ Payroll generated!", Color.Green)

        Catch ex As Exception
            If conn.State = ConnectionState.Open Then conn.Close()
            ShowToast("❌ Payroll error: " & ex.Message, Color.Red)
        End Try
    End Sub

    ' =========================
    ' NUMBER FORMATTING
    ' =========================
    Private Sub Salary_TextChanged(sender As Object, e As EventArgs) Handles Salary.TextChanged
        FormatTextboxWithSeparator(Salary)
    End Sub

    Private Sub Deduction_TextChanged(sender As Object, e As EventArgs) Handles Deduction.TextChanged
        FormatTextboxWithSeparator(Deduction)
    End Sub

    Private Sub FormatTextboxWithSeparator(tb As TextBox)
        If String.IsNullOrEmpty(tb.Text) Then Exit Sub
        Dim value As String = tb.Text.Replace(",", "")
        Dim number As Decimal
        If Decimal.TryParse(value, number) Then
            tb.Text = number.ToString("N0")
            tb.SelectionStart = tb.Text.Length
        End If
    End Sub

    Private Function FormatNumberForTextbox(value As Decimal) As String
        Return value.ToString("N0")
    End Function

    ' =========================
    ' TOAST MESSAGE
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
    ' DEDUCTION BUTTON
    ' =========================
    Private Sub deductionbtn_Click(sender As Object, e As EventArgs) Handles deductionbtn.Click
        Using d As New Deduction()
            If d.ShowDialog() = DialogResult.OK Then
                Deduction.Text = d.TotalDeduction.ToString("N0")

                Listofdeduction.Items.Clear()
                deductionDetails.Clear()

                For Each item In d.DeductionDetails
                    Listofdeduction.Items.Add(item)
                    deductionDetails.Add(item) ' ← STORE FOR PAYSLIP
                Next
            End If
        End Using
    End Sub

    ' =========================
    ' SELECT DEDUCTION ITEM
    ' =========================
    Private Sub Listofdeduction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Listofdeduction.SelectedIndexChanged
        If Listofdeduction.SelectedIndex <> -1 Then
            MessageBox.Show(Listofdeduction.SelectedItem.ToString(),
                            "Deduction Detail",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
        End If
    End Sub

End Class
