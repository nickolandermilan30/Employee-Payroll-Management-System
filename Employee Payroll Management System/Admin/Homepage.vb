Imports Org.BouncyCastle.Utilities.Collections

Public Class Homepage

    Private LoggedInUser As String

    ' =========================
    ' CONSTRUCTOR (RECEIVE USERNAME)
    ' =========================
    Public Sub New(userName As String)
        InitializeComponent()
        LoggedInUser = userName
    End Sub

    Private Sub Homepage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ipakita ang username
        username.Text = LoggedInUser

        ' Optional: auto load Home page
        LoadFormIntoPanel(New Home())
    End Sub

    ' =========================
    ' HOME BUTTON
    ' =========================
    Private Sub Home_Click(sender As Object, e As EventArgs) Handles Home.Click
        LoadFormIntoPanel(New Home())
    End Sub

    ' =========================
    ' EMPLOYEE BUTTON
    ' =========================
    Private Sub Employee_Click(sender As Object, e As EventArgs) Handles Employee.Click
        LoadFormIntoPanel(New Employee())
    End Sub

    ' =========================
    ' PAYROLL BUTTON
    ' =========================
    Private Sub History_Click(sender As Object, e As EventArgs) Handles History.Click
        LoadFormIntoPanel(New History)
    End Sub

    ' =========================
    ' PAYROLL BUTTON
    ' =========================
    Private Sub Payroll_Click(sender As Object, e As EventArgs) Handles Payroll.Click
        LoadFormIntoPanel(New Payroll)
    End Sub

    Private Sub Attendance_Click(sender As Object, e As EventArgs) Handles Attendance.Click
        LoadFormIntoPanel(New MonitorAttendance)
    End Sub

    ' =========================
    ' LOGOUT BUTTON
    ' =========================
    Private Sub logout_Click(sender As Object, e As EventArgs) Handles logout.Click
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to logout?",
            "Logout Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If result = DialogResult.Yes Then
            Me.Close()
            Form1.Show()
        End If
    End Sub

    ' =========================
    ' LOAD FORM SA PANEL
    ' =========================
    Private Sub LoadFormIntoPanel(frm As Form)
        View.Controls.Clear()
        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        View.Controls.Add(frm)
        frm.Show()
    End Sub

    Private Sub username_Click(sender As Object, e As EventArgs) Handles username.Click
        MessageBox.Show("Logged in as: " & LoggedInUser)
    End Sub


End Class
