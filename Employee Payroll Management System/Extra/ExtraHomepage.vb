Public Class ExtraHomepage

    Private LoggedInUser As String

    ' =========================
    ' CONSTRUCTOR (RECEIVE USERNAME)
    ' =========================
    Public Sub New(userName As String)
        InitializeComponent()
        LoggedInUser = userName
    End Sub

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub ExtraHomepage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ipakita ang username
        username.Text = LoggedInUser

        ' Optional: default page (pwede mo alisin kung ayaw mo)
        ' LoadFormIntoPanel(New AttendanceChecker())
    End Sub

    ' =========================
    ' ATTENDANCE BUTTON
    ' =========================
    Private Sub Attendance_Click(sender As Object, e As EventArgs) Handles Attendance.Click
        LoadFormIntoPanel(New AttendanceChecker())
    End Sub

    ' =========================
    ' LOGOUT BUTTON
    ' =========================
    Private Sub logoutbtn_Click(sender As Object, e As EventArgs) Handles logoutbtn.Click
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to logout?",
            "Logout Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If result = DialogResult.Yes Then
            Me.Close()
            LogIn.Show()
        End If
    End Sub

    ' =========================
    ' LOAD FORM SA VIEW PANEL
    ' =========================
    Private Sub LoadFormIntoPanel(frm As Form)
        View.Controls.Clear()
        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        View.Controls.Add(frm)
        frm.Show()
    End Sub

    ' =========================
    ' USERNAME CLICK (OPTIONAL)
    ' =========================
    Private Sub username_Click(sender As Object, e As EventArgs) Handles username.Click
        MessageBox.Show("Logged in as: " & LoggedInUser)
    End Sub

    Private Sub Home_Click(sender As Object, e As EventArgs) Handles Home.Click

    End Sub

    Private Sub Employee_Click(sender As Object, e As EventArgs) Handles Employee.Click

    End Sub
End Class
