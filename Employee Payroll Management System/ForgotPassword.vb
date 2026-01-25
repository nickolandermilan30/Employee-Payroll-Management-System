Imports MySql.Data.MySqlClient
Imports System.Threading.Tasks

Public Class ForgotPassword

    ' =========================
    ' DATABASE CONNECTION
    ' =========================
    Private conn As New MySqlConnection("Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;")

    ' =========================
    ' ATTEMPT COUNTERS
    ' =========================
    Private wrongAttempts As Integer = 0       ' Current series of wrong attempts
    Private lockStage As Integer = 0           ' Step of the lock (0..5)
    Private lockTime As Integer = 0            ' Timer for lock
    Private cooldowns As Integer() = {3, 5, 8, 10, 13} ' Cooldown for each stage

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub ForgotPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Hide password by default
        NewPassword.UseSystemPasswordChar = True

        ' Setup typeofinfo combo
        typeofinfo.Items.Clear()
        typeofinfo.Items.Add("Email")
        typeofinfo.Items.Add("Phone Number")
        typeofinfo.DropDownStyle = ComboBoxStyle.DropDownList
        typeofinfo.SelectedIndex = 0 ' default Email

        ' Hide attempt timer label initially
        AttemptTimerLabel.Visible = False
    End Sub

    ' =========================
    ' SHOW/HIDE PASSWORD
    ' =========================
    Private Sub Showpassword_CheckedChanged(sender As Object, e As EventArgs) Handles Showpassword.CheckedChanged
        NewPassword.UseSystemPasswordChar = Not Showpassword.Checked
    End Sub

    ' =========================
    ' DISPLAY USERNAME & CREATED_AT
    ' =========================
    Private Sub Email_TextChanged(sender As Object, e As EventArgs) Handles Email.TextChanged
        If Email.Text.Trim = "" Then
            Username.Text = ""
            Datecreated.Text = ""
            Return
        End If

        Try
            conn.Open()
            Dim column As String = If(typeofinfo.SelectedItem.ToString() = "Email", "email", "phone_number")
            Dim sql As String = $"SELECT username, created_at FROM users WHERE {column}=@value LIMIT 1"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@value", Email.Text.Trim)
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Username.Text = reader("username").ToString()
                        Datecreated.Text = Convert.ToDateTime(reader("created_at")).ToString("MMMM dd yyyy")
                    Else
                        Username.Text = ""
                        Datecreated.Text = ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching user info: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' =========================
    ' PHONE NUMBER ONLY INPUT
    ' =========================
    Private Sub Email_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Email.KeyPress
        If typeofinfo.SelectedItem.ToString() = "Phone Number" Then
            If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    ' =========================
    ' SET NEW PASSWORD
    ' =========================
    Private Async Sub SetNewpassword_Click(sender As Object, e As EventArgs) Handles SetNewpassword.Click
        Dim inputValue As String = Email.Text.Trim
        Dim newPass As String = NewPassword.Text.Trim
        Dim method As String = typeofinfo.SelectedItem.ToString()

        ' VALIDATION
        If inputValue = "" Or newPass = "" Then
            MessageBox.Show("Please fill all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If newPass.Length < 3 Then
            MessageBox.Show("Password must be at least 3 characters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Phone validation
        If method = "Phone Number" AndAlso Not IsNumeric(inputValue) Then
            MessageBox.Show("Phone Number must be digits only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            conn.Open()
            Dim column As String = If(method = "Email", "email", "phone_number")

            ' Check if account exists
            Dim checkSql As String = $"SELECT COUNT(*) FROM users WHERE {column}=@value"
            Using checkCmd As New MySqlCommand(checkSql, conn)
                checkCmd.Parameters.AddWithValue("@value", inputValue)
                Dim count = Convert.ToInt32(checkCmd.ExecuteScalar())

                If count = 0 Then
                    wrongAttempts += 1
                    Await HandleWrongAttempt()
                    Exit Sub
                End If
            End Using

            ' Update password
            Dim updateSql As String = $"UPDATE users SET password=@p WHERE {column}=@value"
            Using cmd As New MySqlCommand(updateSql, conn)
                cmd.Parameters.AddWithValue("@p", newPass)
                cmd.Parameters.AddWithValue("@value", inputValue)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' CLEAR FIELDS
            Email.Text = ""
            NewPassword.Text = ""
            Username.Text = ""
            Datecreated.Text = ""
            Showpassword.Checked = False

            ' Reset counters
            wrongAttempts = 0
            lockStage = 0
            AttemptTimerLabel.Visible = False

        Catch ex As Exception
            MessageBox.Show("Error updating password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' =========================
    ' HANDLE WRONG ATTEMPTS WITH PROGRESSIVE COOLDOWN
    ' =========================
    Private Async Function HandleWrongAttempt() As Task
        ' Check if lockStage exceeds maximum
        If lockStage >= cooldowns.Length Then
            MessageBox.Show("Too many incorrect attempts. Form will close in 5 seconds.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lockTime = 5
            AttemptTimerLabel.Visible = True
            Await LockCountdown()
            Me.Close()
            Return
        End If

        ' If 3 wrong attempts in current stage
        If wrongAttempts >= 3 Then
            lockTime = cooldowns(lockStage)
            AttemptTimerLabel.Visible = True
            Await LockCountdown()
            wrongAttempts = 0
            lockStage += 1
        Else
            MessageBox.Show("Account not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    ' =========================
    ' LOCK COUNTDOWN TIMER
    ' =========================
    Private Async Function LockCountdown() As Task
        While lockTime > 0
            AttemptTimerLabel.Text = $"Please wait {lockTime} second(s)..."
            Await Task.Delay(1000)
            lockTime -= 1
        End While
        AttemptTimerLabel.Visible = False
    End Function

    ' =========================
    ' BACK BUTTON
    ' =========================
    Private Sub BackBtn_Click(sender As Object, e As EventArgs) Handles BackBtn.Click
        Dim loginForm As New LogIn
        loginForm.Show()
        Me.Hide()
    End Sub

End Class
