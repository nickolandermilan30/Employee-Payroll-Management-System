Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class Form1

    ' =========================
    ' DATABASE CONNECTION
    ' =========================
    Private Conn As New MySqlConnection(
        "Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;"
    )

    ' =========================
    ' SHOW / HIDE PASSWORD
    ' =========================
    Private Sub Showpassword_CheckedChanged(sender As Object, e As EventArgs) Handles Showpassword.CheckedChanged
        Password.UseSystemPasswordChar = Not Showpassword.Checked
    End Sub

    ' =========================
    ' SIGNUP BUTTON → REGISTER FORM
    ' =========================
    Private Sub Signup_Click(sender As Object, e As EventArgs) Handles Signup.Click
        Dim reg As New Register()
        reg.Show()
        Me.Hide()
    End Sub

    ' =========================
    ' SIGNIN BUTTON
    ' =========================
    Private Sub Signin_Click(sender As Object, e As EventArgs) Handles Signin.Click

        If Email.Text.Trim() = "" Or Password.Text.Trim() = "" Then
            MessageBox.Show("Please enter email and password", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Conn.Open()

            ' ==================================================
            ' 1️⃣ ADMIN LOGIN (users TABLE)
            ' ==================================================
            Dim adminCmd As New MySqlCommand(
                "SELECT username FROM users 
                 WHERE email=@email AND password=@password AND role='admin'",
                Conn
            )
            adminCmd.Parameters.AddWithValue("@email", Email.Text.Trim())
            adminCmd.Parameters.AddWithValue("@password", Password.Text.Trim())

            Dim adminReader As MySqlDataReader = adminCmd.ExecuteReader()

            If adminReader.Read() Then
                Dim username As String = adminReader("username").ToString()
                adminReader.Close()
                Conn.Close()

                MessageBox.Show("Admin login successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim adminHome As New Homepage(username)
                adminHome.Show()
                Me.Hide()
                Exit Sub
            End If

            adminReader.Close()

            ' ==================================================
            ' 2️⃣ EMPLOYEE LOGIN (employees TABLE)
            ' ==================================================
            Dim empCmd As New MySqlCommand(
                "SELECT fullname, email FROM employees 
                 WHERE email=@email AND password=@password",
                Conn
            )
            empCmd.Parameters.AddWithValue("@email", Email.Text.Trim())
            empCmd.Parameters.AddWithValue("@password", Password.Text.Trim())

            Dim empReader As MySqlDataReader = empCmd.ExecuteReader()

            If empReader.Read() Then
                Dim fullname As String = empReader("fullname").ToString()
                empReader.Close()
                Conn.Close()

                MessageBox.Show("Employee login successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' ✅ STAFF HOMEPAGE
                Dim staffHome As New HomepageMonitor(fullname)
                staffHome.Show()
                Me.Hide()
                Exit Sub
            End If

            empReader.Close()
            Conn.Close()

            MessageBox.Show("Invalid email or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ' =========================
    ' OPTIONAL EVENTS
    ' =========================
    Private Sub Email_TextChanged(sender As Object, e As EventArgs) Handles Email.TextChanged
    End Sub

    Private Sub Password_TextChanged(sender As Object, e As EventArgs) Handles Password.TextChanged
    End Sub

End Class
