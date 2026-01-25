Imports MySql.Data.MySqlClient
Imports Employee_Payroll_Management_System.Admin
Imports Employee_Payroll_Management_System.Staff

Public Class LogIn

    ' =========================
    ' DATABASE CONNECTION
    ' =========================
    Private Conn As New MySqlConnection(
        "Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;"
    )

    ' =========================
    ' LOGIN CONTROL VARIABLES
    ' =========================
    Private failedAttempts As Integer = 0          ' Counts failed login attempts
    Private lockoutAttempts As Integer = 0         ' Counts how many times user got locked out
    Private cooldownSeconds As Integer = 15        ' Seconds to wait after lockout

    ' =========================
    ' TIMER CONTROL
    ' =========================
    Private WithEvents TimerLogin As New Timer()

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Password.UseSystemPasswordChar = True
        Email.Select()

        ' Setup timer
        TimerLogin.Interval = 1000 ' 1 second
        TimerLogin.Enabled = False

        ' Clear Timer label initially
        Timer.Text = ""
    End Sub

    ' =========================
    ' EMAIL NAVIGATION
    ' =========================
    Private Sub Email_KeyDown(sender As Object, e As KeyEventArgs) Handles Email.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Then
            e.SuppressKeyPress = True
            Password.Focus()
        End If
    End Sub

    ' =========================
    ' PASSWORD NAVIGATION
    ' =========================
    Private Sub Password_KeyDown(sender As Object, e As KeyEventArgs) Handles Password.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Then
            e.SuppressKeyPress = True
            Showpassword.Focus()
        End If
    End Sub

    ' =========================
    ' SHOW PASSWORD NAVIGATION
    ' =========================
    Private Sub Showpassword_KeyDown(sender As Object, e As KeyEventArgs) Handles Showpassword.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Then
            e.SuppressKeyPress = True
            Signin.Focus()
        End If
    End Sub

    ' =========================
    ' SIGNIN ENTER KEY
    ' =========================
    Private Sub Signin_KeyDown(sender As Object, e As KeyEventArgs) Handles Signin.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Signin.PerformClick()
        End If
    End Sub

    ' =========================
    ' SIGNIN CLICK
    ' =========================
    Private Sub Signin_Click(sender As Object, e As EventArgs) Handles Signin.Click
        ' Disable button if timer is running
        If TimerLogin.Enabled Then
            MessageBox.Show("Please wait for the cooldown to finish.", "Locked Out", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim emailInput As String = Email.Text.Trim()
        Dim passwordInput As String = Password.Text.Trim()

        If emailInput = "" Or passwordInput = "" Then
            MessageBox.Show("Please enter your email and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Conn.Open()

            ' ========== ADMIN LOGIN ==========
            Using cmdAdmin As New MySqlCommand("SELECT username, password FROM users WHERE email=@Email LIMIT 1", Conn)
                cmdAdmin.Parameters.AddWithValue("@Email", emailInput)
                Using readerAdmin = cmdAdmin.ExecuteReader()
                    If readerAdmin.Read() Then
                        If passwordInput = readerAdmin("password").ToString() Then
                            Dim adminHome As New Homepage(readerAdmin("username").ToString())
                            adminHome.Show()
                            Me.Hide()
                            failedAttempts = 0
                            Return
                        Else
                            HandleFailedAttempt()
                            Return
                        End If
                    End If
                End Using
            End Using

            ' ========== EMPLOYEE LOGIN ==========
            Using cmdEmp As New MySqlCommand("SELECT fullname, password, status FROM employees WHERE email=@Email LIMIT 1", Conn)
                cmdEmp.Parameters.AddWithValue("@Email", emailInput)
                Using readerEmp = cmdEmp.ExecuteReader()
                    If readerEmp.Read() Then
                        If readerEmp("status").ToString() = "Inactive" Then
                            MessageBox.Show("Your account is inactive. Please contact admin.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If

                        If passwordInput = readerEmp("password").ToString() Then
                            Dim staffHome As New HomepageMonitor(readerEmp("fullname").ToString())
                            staffHome.Show()
                            Me.Hide()
                            failedAttempts = 0
                            Return
                        Else
                            HandleFailedAttempt()
                            Return
                        End If
                    Else
                        MessageBox.Show("Email not found.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        HandleFailedAttempt()
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message)
        Finally
            Conn.Close()
        End Try
    End Sub

    ' =========================
    ' HANDLE FAILED ATTEMPTS
    ' =========================
    Private Sub HandleFailedAttempt()
        failedAttempts += 1
        If failedAttempts >= 3 Then
            lockoutAttempts += 1
            failedAttempts = 0

            If lockoutAttempts >= 3 Then
                MessageBox.Show("Too many failed attempts. System will close.", "System Lockout", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Application.Exit()
            Else
                cooldownSeconds = 15
                Timer.Text = "Cooldown: " & cooldownSeconds & "s"
                TimerLogin.Enabled = True
                Signin.Enabled = False
                Email.Enabled = False
                Password.Enabled = False
            End If
        Else
            MessageBox.Show("Incorrect email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' =========================
    ' TIMER TICK
    ' =========================
    Private Sub TimerLogin_Tick(sender As Object, e As EventArgs) Handles TimerLogin.Tick
        cooldownSeconds -= 1
        Timer.Text = "Cooldown: " & cooldownSeconds & "s"

        If cooldownSeconds <= 0 Then
            TimerLogin.Enabled = False
            Signin.Enabled = True
            Email.Enabled = True
            Password.Enabled = True
            Timer.Text = ""
        End If
    End Sub

    ' =========================
    ' SHOW / HIDE PASSWORD
    ' =========================
    Private Sub Showpassword_CheckedChanged(sender As Object, e As EventArgs) Handles Showpassword.CheckedChanged
        Password.UseSystemPasswordChar = Not Showpassword.Checked
    End Sub

    ' =========================
    ' SIGN UP
    ' =========================
    Private Sub Signup_Click(sender As Object, e As EventArgs) Handles Signup.Click
        Dim registerForm As New Register()
        registerForm.Show()
        Me.Hide()
    End Sub

    ' =========================
    ' FORGOT PASSWORD CLICK
    ' =========================
    Private Sub forget_Click(sender As Object, e As EventArgs) Handles forget.Click
        ' Open ForgotPassword form
        Dim forgotForm As New ForgotPassword
        forgotForm.Show
        Hide ' hide login form
    End Sub

    Private Sub Forgotemail_Click(sender As Object, e As EventArgs) Handles Forgotemail.Click
        ' Open ForgotPassword form
        Dim forgotForm As New ForgotEmail
        forgotForm.Show()
        Hide() ' hide login form
    End Sub
End Class
