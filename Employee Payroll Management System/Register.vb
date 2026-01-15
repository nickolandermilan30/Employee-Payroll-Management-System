Imports MySql.Data.MySqlClient

Public Class Register

    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Roles
        Roledropdown.Items.Add("Admin")

        ' Password mask
        Password.PasswordChar = "*"c
        confirmpassword.PasswordChar = "*"c
    End Sub

    ' SHOW PASSWORD
    Private Sub Showpassword1_CheckedChanged(sender As Object, e As EventArgs) Handles Showpassword1.CheckedChanged
        If Showpassword1.Checked Then
            Password.PasswordChar = ControlChars.NullChar
            confirmpassword.PasswordChar = ControlChars.NullChar
        Else
            Password.PasswordChar = "*"c
            confirmpassword.PasswordChar = "*"c
        End If
    End Sub

    ' BACK TO LOGIN
    Private Sub BackSignin_Click(sender As Object, e As EventArgs) Handles BackSignin.Click
        Form1.Show()
        Me.Close()
    End Sub

    ' SIGN UP BUTTON
    Private Sub Signup_Click(sender As Object, e As EventArgs) Handles Signup.Click

        ' VALIDATION
        If Username.Text = "" Or Email.Text = "" Or Password.Text = "" Or confirmpassword.Text = "" Or Roledropdown.Text = "" Then
            MessageBox.Show("Please fill up all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Password.Text <> confirmpassword.Text Then
            MessageBox.Show("Password does not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            OpenConnection()

            Dim query As String = "INSERT INTO users (username, email, password, role) VALUES (@username, @email, @password, @role)"
            Dim cmd As New MySqlCommand(query, Conn)

            cmd.Parameters.AddWithValue("@username", Username.Text)
            cmd.Parameters.AddWithValue("@email", Email.Text)
            cmd.Parameters.AddWithValue("@password", Password.Text) ' pwede natin i-hash later
            cmd.Parameters.AddWithValue("@role", Roledropdown.Text)

            cmd.ExecuteNonQuery()

            MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' balik sa login
            Form1.Show()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            CloseConnection()
        End Try

    End Sub

End Class
