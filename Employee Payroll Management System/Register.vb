Imports MySql.Data.MySqlClient

Public Class Register

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Password mask
        Password.PasswordChar = "*"c
        confirmpassword.PasswordChar = "*"c

        ' ===== TAB ORDER =====
        Username.TabIndex = 0
        Email.TabIndex = 1
        Password.TabIndex = 2
        confirmpassword.TabIndex = 3
        Signup.TabIndex = 4
        BackSignin.TabIndex = 5
    End Sub

    ' =========================
    ' SHOW / HIDE PASSWORD
    ' =========================
    Private Sub Showpassword1_CheckedChanged(sender As Object, e As EventArgs) Handles Showpassword1.CheckedChanged
        If Showpassword1.Checked Then
            Password.PasswordChar = ControlChars.NullChar
            confirmpassword.PasswordChar = ControlChars.NullChar
        Else
            Password.PasswordChar = "*"c
            confirmpassword.PasswordChar = "*"c
        End If
    End Sub

    ' =========================
    ' BACK TO LOGIN
    ' =========================
    Private Sub BackSignin_Click(sender As Object, e As EventArgs) Handles BackSignin.Click
        LogIn.Show()
        Me.Close()
    End Sub

    ' =========================
    ' SIGN UP BUTTON
    ' =========================
    Private Sub Signup_Click(sender As Object, e As EventArgs) Handles Signup.Click

        ' VALIDATION
        If Username.Text = "" Or Email.Text = "" Or Password.Text = "" Or confirmpassword.Text = "" Then
            MessageBox.Show("Please fill up all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Password.Text <> confirmpassword.Text Then
            MessageBox.Show("Password does not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            OpenConnection()

            ' Role fixed as "Admin"
            Dim query As String = "INSERT INTO users (username, email, password, role) VALUES (@username, @email, @password, 'Admin')"
            Dim cmd As New MySqlCommand(query, Conn)

            cmd.Parameters.AddWithValue("@username", Username.Text)
            cmd.Parameters.AddWithValue("@email", Email.Text)
            cmd.Parameters.AddWithValue("@password", Password.Text) ' pwede i-hash later

            cmd.ExecuteNonQuery()

            MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' balik sa login
            LogIn.Show()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            CloseConnection()
        End Try

    End Sub

    ' =========================
    ' TEXT CHANGED EVENTS
    ' =========================
    Private Sub Username_TextChanged(sender As Object, e As EventArgs) Handles Username.TextChanged
        ' optional logic
    End Sub

    Private Sub Email_TextChanged(sender As Object, e As EventArgs) Handles Email.TextChanged
        ' optional logic
    End Sub

    Private Sub Password_TextChanged(sender As Object, e As EventArgs) Handles Password.TextChanged
        ' optional logic
    End Sub

    Private Sub confirmpassword_TextChanged(sender As Object, e As EventArgs) Handles confirmpassword.TextChanged
        ' optional logic
    End Sub

End Class
