Imports MySql.Data.MySqlClient

Public Class ForgotPassword

    ' =========================
    ' DATABASE CONNECTION
    ' =========================
    Private conn As New MySqlConnection("Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;")

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub ForgotPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Hide password by default
        NewPassword.UseSystemPasswordChar = True
    End Sub

    ' =========================
    ' SHOW / HIDE PASSWORD
    ' =========================
    Private Sub Showpassword_CheckedChanged(sender As Object, e As EventArgs) Handles Showpassword.CheckedChanged
        NewPassword.UseSystemPasswordChar = Not Showpassword.Checked
    End Sub

    ' =========================
    ' SET NEW PASSWORD
    ' =========================
    Private Sub SetNewpassword_Click(sender As Object, e As EventArgs) Handles SetNewpassword.Click
        Dim emailText As String = Email.Text.Trim()
        Dim newPass As String = NewPassword.Text.Trim()

        ' BASIC VALIDATION
        If emailText = "" Or newPass = "" Then
            MessageBox.Show("Please enter both Email and New Password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' OPTIONAL: Minimum password length
        If newPass.Length < 3 Then
            MessageBox.Show("Password must be at least 3 characters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            conn.Open()

            ' CHECK IF EMAIL EXISTS
            Dim checkSql As String = "SELECT COUNT(*) FROM users WHERE email=@e"
            Using checkCmd As New MySqlCommand(checkSql, conn)
                checkCmd.Parameters.AddWithValue("@e", emailText)
                Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                If count = 0 Then
                    MessageBox.Show("Email not found in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End Using

            ' UPDATE PASSWORD
            Dim updateSql As String = "UPDATE users SET password=@p WHERE email=@e"
            Using cmd As New MySqlCommand(updateSql, conn)
                cmd.Parameters.AddWithValue("@p", newPass)
                cmd.Parameters.AddWithValue("@e", emailText)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' CLEAR FIELDS
            Email.Clear()
            NewPassword.Clear()
            Showpassword.Checked = False

        Catch ex As Exception
            MessageBox.Show("Error updating password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' =========================
    ' BACK BUTTON
    ' =========================
    Private Sub BackBtn_Click(sender As Object, e As EventArgs) Handles BackBtn.Click
        Dim LogIn As New LogIn
        LogIn.Show()
        Hide()
    End Sub

End Class
