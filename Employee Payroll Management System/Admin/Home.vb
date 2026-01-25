Imports MySql.Data.MySqlClient

Public Class Home

    ' ==============================
    ' FORM LOAD (AUTO LOAD LAHAT)
    ' ==============================
    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadEmployeeCount()
        LoadLatestEmployeeDate()
        LoadAdminCount()
        LoadLatestAdminDate()
        LoadTotalPayroll()
        LoadLastPayrollDate()
        LoadDeleteCount()
        LoadHistoryDate()
    End Sub

    ' ==============================
    ' ADD EMPLOYEE
    ' ==============================
    Private Sub Addemployee_Click(sender As Object, e As EventArgs) Handles Addemployee.Click
        Dim addEmp As New AddEmployee()
        addEmp.ShowDialog()

        ' Refresh all dashboard stats
        LoadEmployeeCount()
        LoadLatestEmployeeDate()
        LoadTotalPayroll()
        LoadLastPayrollDate()
        LoadDeleteCount()
        LoadHistoryDate()
    End Sub

    ' ==============================
    ' EMPLOYEE COUNT
    ' ==============================
    Private Sub LoadEmployeeCount()
        Try
            OpenConnection()
            Using cmd As New MySqlCommand("SELECT COUNT(*) FROM employees", Conn)
                employeecount.Text = cmd.ExecuteScalar().ToString()
            End Using
        Catch
            employeecount.Text = "0"
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ==============================
    ' LATEST EMPLOYEE DATE
    ' ==============================
    Private Sub LoadLatestEmployeeDate()
        Try
            OpenConnection()
            Using cmd As New MySqlCommand("SELECT MAX(created_at) FROM employees", Conn)
                Dim r = cmd.ExecuteScalar()
                employeedateadded.Text =
                    If(r Is DBNull.Value, "No record",
                    Convert.ToDateTime(r).ToString("MMMM dd, yyyy"))
            End Using
        Catch
            employeedateadded.Text = "No record"
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ==============================
    ' ADMIN COUNT
    ' ==============================
    Private Sub LoadAdminCount()
        Try
            OpenConnection()
            Using cmd As New MySqlCommand("SELECT COUNT(*) FROM users WHERE role='Admin'", Conn)
                Admincount.Text = cmd.ExecuteScalar().ToString()
            End Using
        Catch
            Admincount.Text = "0"
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ==============================
    ' LATEST ADMIN DATE
    ' ==============================
    Private Sub LoadLatestAdminDate()
        Try
            OpenConnection()
            Using cmd As New MySqlCommand("SELECT MAX(created_at) FROM users WHERE role='Admin'", Conn)
                Dim r = cmd.ExecuteScalar()
                adminlatestdate.Text =
                    If(r Is DBNull.Value, "No record",
                    Convert.ToDateTime(r).ToString("MMMM dd, yyyy"))
            End Using
        Catch
            adminlatestdate.Text = "No record"
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ==============================
    ' TOTAL PAYROLL (AUTO LOAD)
    ' ==============================
    Private Sub LoadTotalPayroll()
        Try
            OpenConnection()
            Using cmd As New MySqlCommand("SELECT SUM(salary) FROM payroll", Conn)
                Dim total = cmd.ExecuteScalar()
                totalcountpayroll.Text =
                    If(total Is DBNull.Value, "₱0",
                    "₱" & FormatMoney(CDec(total)))
            End Using
        Catch
            totalcountpayroll.Text = "₱0"
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ==============================
    ' LAST PAYROLL DATE (AUTO LOAD)
    ' ==============================
    Private Sub LoadLastPayrollDate()
        Try
            OpenConnection()
            Using cmd As New MySqlCommand("SELECT MAX(created_at) FROM payroll", Conn)
                Dim r = cmd.ExecuteScalar()
                lasttransactiondate.Text =
                    If(r Is DBNull.Value, "No record",
                    Convert.ToDateTime(r).ToString("MMMM dd, yyyy"))
            End Using
        Catch
            lasttransactiondate.Text = "No record"
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ==============================
    ' DELETE COUNT (PAYROLL ROWS)
    ' ==============================
    Private Sub LoadDeleteCount()
        Try
            OpenConnection()
            Using cmd As New MySqlCommand("SELECT COUNT(*) FROM payroll", Conn)
                deletecount.Text = cmd.ExecuteScalar().ToString()
            End Using
        Catch
            deletecount.Text = "0"
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ==============================
    ' HISTORY DATE (LATEST PAYROLL ENTRY)
    ' ==============================
    Private Sub LoadHistoryDate()
        Try
            OpenConnection()
            Using cmd As New MySqlCommand("SELECT MAX(created_at) FROM payroll", Conn)
                Dim r = cmd.ExecuteScalar()
                historydate.Text =
                    If(r Is DBNull.Value, "No record",
                    Convert.ToDateTime(r).ToString("MMMM dd, yyyy"))
            End Using
        Catch
            historydate.Text = "No record"
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ==============================
    ' OPTIONAL CLICK (BACKUP)
    ' ==============================
    Private Sub totalcountpayroll_Click(sender As Object, e As EventArgs) Handles totalcountpayroll.Click
        LoadTotalPayroll()
    End Sub

    Private Sub lasttransactiondate_Click(sender As Object, e As EventArgs) Handles lasttransactiondate.Click
        LoadLastPayrollDate()
    End Sub

    Private Sub deletecount_Click(sender As Object, e As EventArgs) Handles deletecount.Click
        LoadDeleteCount()
    End Sub

    Private Sub historydate_Click(sender As Object, e As EventArgs) Handles historydate.Click
        LoadHistoryDate()
    End Sub

    ' ==============================
    ' FORMAT MONEY (K / M / B)
    ' ==============================
    Private Function FormatMoney(amount As Decimal) As String
        If amount >= 1000000000D Then
            Return (amount / 1000000000D).ToString("0.#") & "B"
        ElseIf amount >= 1000000D Then
            Return (amount / 1000000D).ToString("0.#") & "M"
        ElseIf amount >= 1000D Then
            Return (amount / 1000D).ToString("0.#") & "K"
        Else
            Return amount.ToString("N0")
        End If
    End Function

End Class
