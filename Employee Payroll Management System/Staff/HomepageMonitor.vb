Imports System.Windows.Forms

Public Class HomepageMonitor

    ' =========================
    ' STORE LOGGED-IN EMPLOYEE NAME
    ' =========================
    Private LoggedInEmployee As String

    ' =========================
    ' CONSTRUCTOR (RECEIVE FULLNAME)
    ' =========================
    Public Sub New(fullname As String)
        InitializeComponent()
        LoggedInEmployee = fullname
    End Sub

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub HomepageMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUsername.Text = LoggedInEmployee

        ' 🔥 AUTO LOAD HOME EMPLOYEE ON FORM LOAD
        LoadHomeEmployee()
    End Sub

    ' =========================
    ' HOME BUTTON CLICK
    ' =========================
    Private Sub Home_Click(sender As Object, e As EventArgs) Handles Home.Click
        LoadHomeEmployee()
    End Sub

    ' =========================
    ' MONITOR / ATTENDANCE BUTTON CLICK
    ' =========================
    Private Sub monitor_Click(sender As Object, e As EventArgs) Handles monitor.Click
        LoadAttendance()
    End Sub

    ' =========================
    ' SALARY BUTTON CLICK
    ' =========================
    Private Sub Salary_Click(sender As Object, e As EventArgs) Handles Salary.Click
        LoadTransactionHistory()
    End Sub

    ' =========================
    ' LOAD HomeEmployee FORM INSIDE PANEL
    ' =========================
    Private Sub LoadHomeEmployee()
        View.Controls.Clear()

        Dim home As New HomeEmployee(LoggedInEmployee)
        home.TopLevel = False
        home.FormBorderStyle = FormBorderStyle.None
        home.Dock = DockStyle.Fill

        View.Controls.Add(home)
        home.Show()
    End Sub

    ' =========================
    ' LOAD Attendance FORM INSIDE PANEL
    ' =========================
    Private Sub LoadAttendance()
        ' Linisin ang panel
        View.Controls.Clear()

        ' Gumawa ng instance ng Attendance form
        ' Siguraduhin na ang Attendance.vb ay may Constructor din kung papasahan ng fullname
        Dim att As New Attendance()
        att.TopLevel = False
        att.FormBorderStyle = FormBorderStyle.None
        att.Dock = DockStyle.Fill

        ' I-add sa panel at ipakita
        View.Controls.Add(att)
        att.Show()
    End Sub

    ' =========================
    ' LOAD TransactionHistory FORM INSIDE PANEL
    ' =========================
    Private Sub LoadTransactionHistory()
        View.Controls.Clear()

        Dim history As New TransactionHistory(LoggedInEmployee)
        history.TopLevel = False
        history.FormBorderStyle = FormBorderStyle.None
        history.Dock = DockStyle.Fill

        View.Controls.Add(history)
        history.Show()
    End Sub

    ' =========================
    ' LOGOUT BUTTON CLICK
    ' =========================
    Private Sub logout_Click(sender As Object, e As EventArgs) Handles logout.Click
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to logout?",
            "Logout Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If result = DialogResult.Yes Then
            Me.Hide()
            Dim login As New LogIn()
            login.Show()
            Me.Close()
        End If
    End Sub

End Class