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
    ' LOAD HomeEmployee FORM INSIDE PANEL
    ' =========================
    Private Sub LoadHomeEmployee()
        ' Clear previous controls
        View.Controls.Clear()

        ' Create new instance of HomeEmployee
        Dim home As New HomeEmployee(LoggedInEmployee) ' Pass username
        home.TopLevel = False
        home.FormBorderStyle = FormBorderStyle.None
        home.Dock = DockStyle.Fill

        ' Add to panel
        View.Controls.Add(home)
        home.Show()
    End Sub

    ' =========================
    ' OTHER BUTTONS (optional)
    ' =========================
    Private Sub Salary_Click(sender As Object, e As EventArgs) Handles Salary.Click
        LoadTransactionHistory()
    End Sub

    ' =========================
    ' LOAD TransactionHistory FORM INSIDE PANEL
    ' =========================
    Private Sub LoadTransactionHistory()
        View.Controls.Clear()

        Dim history As New TransactionHistory(LoggedInEmployee) ' pass username
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
        ' Confirmation dialog
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to logout?",
            "Logout Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If result = DialogResult.Yes Then
            ' Close current form
            Me.Hide()

            ' Open LogIn form
            Dim login As New LogIn() ' Ensure LogIn.vb is included in the project
            login.Show()

            ' Optional: close the HomepageMonitor form completely
            Me.Close()
        End If
        ' If No, do nothing
    End Sub

    ' =========================
    ' ATTENDANCE BUTTON CLICK (optional)
    ' =========================
    Private Sub attendance_Click(sender As Object, e As EventArgs)
        ' TODO: Load Attendance form inside View panel
    End Sub

End Class
