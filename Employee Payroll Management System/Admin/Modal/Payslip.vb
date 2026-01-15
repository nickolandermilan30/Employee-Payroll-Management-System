Public Class Payslip
    ' Constructor to receive data
    Public Sub New(empName As String, empPosition As String, monthYear As String,
                   empPresentDays As Integer, empBaseSalary As Decimal,
                   empDeduction As Decimal, empNetSalary As Decimal)

        InitializeComponent()

        ' Fill the controls
        name.Text = empName
        Position.Text = empPosition
        MonthandYear.Text = monthYear
        Presentdays.Text = empPresentDays.ToString()
        Basesalary.Text = empBaseSalary.ToString("N2")
        Deduction.Text = empDeduction.ToString("N2")
        Basicsalary.Text = empBaseSalary.ToString("N2")
        deduct.Text = empDeduction.ToString("N2")
        NetSalary.Text = "₱ " & empNetSalary.ToString("N2")
    End Sub

    ' Optional: handle clicks if you want to do something when user clicks the fields
    Private Sub MonthandYear_Click(sender As Object, e As EventArgs) Handles MonthandYear.Click
        ' Optional: do something when clicked
    End Sub

    Private Sub Position_Click(sender As Object, e As EventArgs) Handles Position.Click
    End Sub

    Private Sub Presentdays_Click(sender As Object, e As EventArgs) Handles Presentdays.Click
    End Sub

    Private Sub Basesalary_Click(sender As Object, e As EventArgs) Handles Basesalary.Click
    End Sub

    Private Sub Deduction_Click(sender As Object, e As EventArgs) Handles Deduction.Click
    End Sub

    Private Sub Basicsalary_Click(sender As Object, e As EventArgs) Handles Basicsalary.Click
    End Sub

    Private Sub deduct_Click(sender As Object, e As EventArgs) Handles deduct.Click
    End Sub

    Private Sub NetSalary_Click(sender As Object, e As EventArgs) Handles NetSalary.Click
    End Sub

    Private Sub name_Click(sender As Object, e As EventArgs) Handles name.Click
    End Sub
End Class
