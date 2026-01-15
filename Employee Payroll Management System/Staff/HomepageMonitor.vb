Public Class HomepageMonitor

    ' =========================
    ' STORE LOGGED-IN EMPLOYEE NAME
    ' =========================
    Private LoggedInEmployee As String

    ' =========================
    ' CONSTRUCTOR (RECEIVE FULLNAME)
    ' =========================
    Public Sub New(fullname As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Store the employee name
        LoggedInEmployee = fullname
    End Sub

    ' =========================
    ' FORM LOAD EVENT
    ' =========================
    Private Sub HomepageMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ipakita ang fullname sa Label (gawin mo na lang label sa form, halimbawa: lblUsername)
        lblUsername.Text = LoggedInEmployee
    End Sub

End Class
