Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class ForgotEmail
    ' =========================
    ' DATABASE CONNECTION
    ' =========================
    Private Conn As New MySqlConnection("Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;")

    ' =========================
    ' VARIABLES
    ' =========================
    Private wrongAttempts As Integer = 0
    Private nextTimerSeconds As Integer = 3 ' first timer 3s
    Private countdown As Integer = 0
    Private WithEvents AttemptTimer As New Timer() ' Timer object

    ' =========================
    ' FORM CONTROLS
    ' =========================
    ' Phonenumber TextBox: Phonenumber
    ' New email TextBox: Newemail
    ' Label to show countdown: Timer_Click
    ' Button to set email: setemail
    ' Button to signup: Signup

    ' =========================
    ' PHONENUMBER TEXT CHANGED
    ' =========================
    Private Sub Phonenumber_TextChanged(sender As Object, e As EventArgs) Handles Phonenumber.TextChanged
        ' Optional: validate phone number
    End Sub

    ' =========================
    ' NEW EMAIL TEXT CHANGED
    ' =========================
    Private Sub Newemail_TextChanged(sender As Object, e As EventArgs) Handles Newemail.TextChanged
        ' Optional: validate email format
    End Sub

    ' =========================
    ' SET EMAIL BUTTON CLICK
    ' =========================
    Private Sub setemail_Click(sender As Object, e As EventArgs) Handles setemail.Click
        ' Prevent clicking if timer is running
        If AttemptTimer.Enabled Then
            MessageBox.Show($"Please wait {countdown} seconds before trying again.", "Wait", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim phone As String = Phonenumber.Text.Trim()
        Dim newEmailText As String = Newemail.Text.Trim()

        ' Check empty fields
        If phone = "" Or newEmailText = "" Then
            MessageBox.Show("Please enter both phone number and new email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Basic email format validation
        If Not Regex.IsMatch(newEmailText, "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
            MessageBox.Show("Invalid email format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            HandleWrongAttempt()
            Return
        End If

        Try
            Conn.Open()
            ' Check if phone number exists
            Dim cmd As New MySqlCommand("SELECT * FROM users WHERE phone_number=@phone", Conn)
            cmd.Parameters.AddWithValue("@phone", phone)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.HasRows Then
                reader.Close()
                ' Update email
                Dim updateCmd As New MySqlCommand("UPDATE users SET email=@newEmail WHERE phone_number=@phone", Conn)
                updateCmd.Parameters.AddWithValue("@newEmail", newEmailText)
                updateCmd.Parameters.AddWithValue("@phone", phone)
                updateCmd.ExecuteNonQuery()

                MessageBox.Show("Email updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                wrongAttempts = 0 ' reset after success
                Timer.Text = "" ' clear countdown label
            Else
                reader.Close()
                MessageBox.Show("Phone number not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                HandleWrongAttempt()
            End If

        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
    End Sub

    ' =========================
    ' HANDLE WRONG ATTEMPTS
    ' =========================
    Private Sub HandleWrongAttempt()
        wrongAttempts += 1
        If wrongAttempts Mod 3 = 0 Then
            countdown = nextTimerSeconds
            Timer.Text = $"Wait {countdown} seconds..."
            AttemptTimer.Interval = 1000 ' tick every second
            AttemptTimer.Start()

            ' Increase timer or close app on next round
            If nextTimerSeconds = 3 Then
                nextTimerSeconds = 5
            ElseIf nextTimerSeconds = 5 Then
                nextTimerSeconds = 0 ' next time system will close
            End If
        End If
    End Sub

    ' =========================
    ' TIMER TICK
    ' =========================
    Private Sub AttemptTimer_Tick(sender As Object, e As EventArgs) Handles AttemptTimer.Tick
        countdown -= 1
        If countdown > 0 Then
            Timer.Text = $"Wait {countdown} seconds..."
        Else
            AttemptTimer.Stop()
            Timer.Text = "" ' clear label
            ' If nextTimerSeconds = 0, close system
            If nextTimerSeconds = 0 Then
                MessageBox.Show("System will now close due to repeated wrong attempts.", "System Exit", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Application.Exit()
            Else
                MessageBox.Show("You can try again now.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    ' =========================
    ' OPTIONAL SIGNUP BUTTON
    ' =========================
    Private Sub Signup_Click(sender As Object, e As EventArgs) Handles Signup.Click
        ' Open ForgotPassword form
        Dim forgotForm As New LogIn
        forgotForm.Show()
        Close() ' hide login form
    End Sub

End Class
