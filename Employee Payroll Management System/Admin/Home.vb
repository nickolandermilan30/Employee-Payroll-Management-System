Imports MySql.Data.MySqlClient

Public Class Home

    ' ==============================
    ' FORM LOAD (AUTO LOAD DATA)
    ' ==============================
    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadEmployeeCount()
        LoadLatestEmployeeDate()
        LoadAdminCount()
        LoadLatestAdminDate()
    End Sub

    ' OPEN ADD EMPLOYEE FORM
    Private Sub Addemployee_Click(sender As Object, e As EventArgs) Handles Addemployee.Click
        Dim addEmp As New AddEmployee()
        addEmp.ShowDialog()

        ' Refresh dashboard after adding employee
        LoadEmployeeCount()
        LoadLatestEmployeeDate()
    End Sub

    ' ==============================
    ' LOAD EMPLOYEE COUNT (%)
    ' ==============================
    Private Sub LoadEmployeeCount()
        Try
            OpenConnection()

            Dim query As String = "SELECT COUNT(*) FROM employees"
            Using cmd As New MySqlCommand(query, Conn)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                employeecount.Text = count.ToString() & "%"
            End Using

        Catch ex As Exception
            employeecount.Text = "0%"
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ==============================
    ' LOAD LATEST EMPLOYEE DATE
    ' ==============================
    Private Sub LoadLatestEmployeeDate()
        Try
            OpenConnection()

            Dim query As String = "SELECT MAX(created_at) FROM employees"
            Using cmd As New MySqlCommand(query, Conn)
                Dim result = cmd.ExecuteScalar()

                If result IsNot DBNull.Value Then
                    employeedateadded.Text = Convert.ToDateTime(result).ToString("MMMM dd, yyyy")
                Else
                    employeedateadded.Text = "No record"
                End If
            End Using

        Catch ex As Exception
            employeedateadded.Text = "No record"
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ==============================
    ' LOAD ADMIN COUNT (%)
    ' ==============================
    Private Sub LoadAdminCount()
        Try
            OpenConnection()

            Dim query As String = "SELECT COUNT(*) FROM users WHERE role = 'Admin'"
            Using cmd As New MySqlCommand(query, Conn)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Admincount.Text = count.ToString() & "%"
            End Using

        Catch ex As Exception
            Admincount.Text = "0%"
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ==============================
    ' LOAD LATEST ADMIN DATE
    ' ==============================
    Private Sub LoadLatestAdminDate()
        Try
            OpenConnection()

            Dim query As String = "SELECT MAX(created_at) FROM users WHERE role = 'Admin'"
            Using cmd As New MySqlCommand(query, Conn)
                Dim result = cmd.ExecuteScalar()

                If result IsNot DBNull.Value Then
                    adminlatestdate.Text = Convert.ToDateTime(result).ToString("MMMM dd, yyyy")
                Else
                    adminlatestdate.Text = "No record"
                End If
            End Using

        Catch ex As Exception
            adminlatestdate.Text = "No record"
        Finally
            CloseConnection()
        End Try
    End Sub

End Class
