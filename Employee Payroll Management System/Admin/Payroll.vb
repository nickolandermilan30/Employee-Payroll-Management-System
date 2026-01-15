Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Threading.Tasks

Public Class Payroll

    Private conn As New MySqlConnection("Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;")
    Private employeesTable As DataTable

    Private Sub Payroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadEmployees()

        ' Month picker
        Month.Format = DateTimePickerFormat.Custom
        Month.CustomFormat = "MMMM"
        Month.ShowUpDown = True

        ' Year dropdown
        Year.Items.Clear()
        Dim currentYear As Integer = DateTime.Now.Year
        For y As Integer = currentYear - 20 To currentYear + 1
            Year.Items.Add(y.ToString())
        Next
        Year.SelectedItem = currentYear.ToString()

        Salary.Clear()
        Deduction.Text = "0"
    End Sub

    ' LOAD EMPLOYEES (NAME ONLY)
    Private Sub LoadEmployees()
        Try
            Dim sql As String = "SELECT id, fullname, salary, job_position FROM employees ORDER BY fullname"
            Dim adapter As New MySqlDataAdapter(sql, conn)
            employeesTable = New DataTable()
            adapter.Fill(employeesTable)

            employee.Items.Clear()
            For Each row As DataRow In employeesTable.Rows
                employee.Items.Add(row("fullname").ToString())
            Next
        Catch ex As Exception
            ShowToast("⚠️ Error loading employees: " & ex.Message, Color.Red)
        End Try
    End Sub


    ' When an employee is selected
    Private Sub employee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles employee.SelectedIndexChanged
        If employee.SelectedIndex <> -1 Then
            Dim empName As String = employee.SelectedItem.ToString()

            ' 1️⃣ Update attendance counts
            UpdateAttendanceCounts(empName)

            ' 2️⃣ Auto-fill salary from employees table
            Dim selectedRow As DataRow = employeesTable.Select("fullname='" & empName.Replace("'", "''") & "'").FirstOrDefault()
            If selectedRow IsNot Nothing Then
                Salary.Text = Convert.ToDecimal(selectedRow("salary")).ToString("N2")
            End If
        End If
    End Sub

    ' UPDATE ATTENDANCE COUNTS
    Private Sub UpdateAttendanceCounts(employeeName As String)
        Try
            Dim sql As String = "
                SELECT 
                    SUM(CASE WHEN status = 'Present' THEN 1 ELSE 0 END) AS PresentCount,
                    SUM(CASE WHEN status = 'Absent' THEN 1 ELSE 0 END) AS AbsentCount,
                    SUM(CASE WHEN status = 'Half Day' THEN 1 ELSE 0 END) AS HalfdayCount,
                    SUM(CASE WHEN status = 'Late' THEN 1 ELSE 0 END) AS LateCount
                FROM attendance
                WHERE fullname = @name
            "

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@name", employeeName)
                conn.Open()
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Present.Text = reader("PresentCount").ToString()
                        Absent.Text = reader("AbsentCount").ToString()
                        Halfday.Text = reader("HalfdayCount").ToString()
                        late.Text = reader("LateCount").ToString()
                    End If
                End Using
                conn.Close()
            End Using

        Catch ex As Exception
            If conn.State = ConnectionState.Open Then conn.Close()
            ShowToast("⚠️ Error fetching attendance: " & ex.Message, Color.Red)
        End Try
    End Sub

    ' PAY BUTTON
    Private Sub Pay_Click(sender As Object, e As EventArgs) Handles Pay.Click
        If employee.SelectedIndex = -1 Then
            ShowToast("⚠️ Please select an employee.", Color.Red)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(Salary.Text) OrElse Not IsNumeric(Salary.Text.Replace(",", "")) Then
            ShowToast("⚠️ Invalid salary amount.", Color.Red)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(Deduction.Text) OrElse Not IsNumeric(Deduction.Text.Replace(",", "")) Then
            Deduction.Text = "0"
        End If

        If Year.SelectedItem Is Nothing Then
            ShowToast("⚠️ Please select a year.", Color.Red)
            Exit Sub
        End If

        ' Grab form values
        Dim employeeName As String = employee.SelectedItem.ToString()
        Dim monthText As String = Month.Value.ToString("MMMM") & " " & Year.SelectedItem.ToString()
        Dim monthNumber As Integer = Month.Value.Month
        Dim yearNumber As Integer = CInt(Year.SelectedItem)
        Dim salaryAmount As Decimal = CDec(Salary.Text.Replace(",", ""))
        Dim deductionAmount As Decimal = CDec(Deduction.Text.Replace(",", ""))
        Dim notesText As String = Notes.Text
        Dim presentDays As Integer = If(Present.Text = "", 0, CInt(Present.Text))

        ' Get Position from employees table
        Dim selectedRow As DataRow = employeesTable.Select("fullname='" & employeeName.Replace("'", "''") & "'").FirstOrDefault()
        Dim position As String = ""
        If selectedRow IsNot Nothing Then
            position = selectedRow("job_position").ToString()
        End If


        ' Save payroll to database
        Try
            Dim sql As String =
            "INSERT INTO payroll " &
            "(employee_name, month, year, salary, deduction, notes) " &
            "VALUES (@name, @mon, @yr, @sal, @ded, @notes)"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@name", employeeName)
                cmd.Parameters.AddWithValue("@mon", monthNumber)
                cmd.Parameters.AddWithValue("@yr", yearNumber)
                cmd.Parameters.AddWithValue("@sal", salaryAmount)
                cmd.Parameters.AddWithValue("@ded", deductionAmount)
                cmd.Parameters.AddWithValue("@notes", notesText)

                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
            End Using

            ' Generate Payslip
            Dim netSalary As Decimal = salaryAmount - deductionAmount
            Dim payslipForm As New Payslip(employeeName, position, monthText, presentDays, salaryAmount, deductionAmount, netSalary)
            payslipForm.ShowDialog() ' Open as modal

            ' Reset form
            Salary.Clear()
            Deduction.Text = "0"
            Notes.Clear()
            employee.SelectedIndex = -1
            Month.Value = DateTime.Now
            Year.SelectedItem = DateTime.Now.Year.ToString()

            ShowToast("✅ Payroll processed successfully!", Color.Green)

        Catch ex As Exception
            ShowToast("❌ Error saving payroll: " & ex.Message, Color.Red)
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub


    ' NUMERIC INPUT ONLY
    Private Sub Numeric_KeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles Salary.KeyPress, Deduction.KeyPress

        If Not Char.IsDigit(e.KeyChar) AndAlso
           e.KeyChar <> ControlChars.Back AndAlso
           e.KeyChar <> ","c Then
            e.Handled = True
        End If
    End Sub

    ' TOAST NOTIFICATION
    Private Async Sub ShowToast(message As String, bgColor As Color)
        Dim toast As New Panel With {
            .Size = New Size(360, 50),
            .BackColor = bgColor,
            .Location = New Point(Me.ClientSize.Width - 370, 10),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right
        }

        Dim lbl As New Label With {
            .Text = message,
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .Dock = DockStyle.Fill,
            .Padding = New Padding(10, 0, 0, 0),
            .TextAlign = ContentAlignment.MiddleLeft
        }

        toast.Controls.Add(lbl)
        Me.Controls.Add(toast)
        toast.BringToFront()

        For i As Integer = -toast.Width To 0 Step 20
            toast.Left = Me.ClientSize.Width - toast.Width + i
            Await Task.Delay(10)
        Next

        Await Task.Delay(3000)

        For i As Integer = 0 To -toast.Width Step -20
            toast.Left = Me.ClientSize.Width - toast.Width + i
            Await Task.Delay(10)
        Next

        Me.Controls.Remove(toast)
        toast.Dispose()
    End Sub

End Class
