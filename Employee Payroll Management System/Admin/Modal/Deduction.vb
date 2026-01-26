Imports System.Globalization

Public Class Deduction

    ' =========================
    ' PUBLIC DATA (IPAPASA)
    ' =========================
    Public Property TotalDeduction As Decimal
    Public Property DeductionDetails As New List(Of String)

    ' =========================
    ' INTERNAL STORAGE
    ' =========================
    Private deductionList As New List(Of Tuple(Of String, Decimal))

    Private Sub Deduction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        total.Text = "0"
    End Sub

    ' =========================
    ' NUMBER ONLY + FORMAT
    ' =========================
    Private Sub Money_KeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles sss.KeyPress, pagibig.KeyPress, philhealth.KeyPress, howmuch.KeyPress

        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Money_TextChanged(sender As Object, e As EventArgs) _
        Handles sss.TextChanged, pagibig.TextChanged, philhealth.TextChanged, howmuch.TextChanged

        Dim tb As TextBox = CType(sender, TextBox)
        If tb.Text = "" Then Exit Sub

        Dim value As Decimal
        If Decimal.TryParse(tb.Text.Replace(",", ""), value) Then
            tb.Text = value.ToString("#,##0")
            tb.SelectionStart = tb.Text.Length
        End If

        ComputeTotal()
    End Sub

    ' =========================
    ' ADD CUSTOM DEDUCTION
    ' =========================
    Private Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click

        If name.Text.Trim = "" Or howmuch.Text.Trim = "" Then
            MessageBox.Show("Enter deduction name and amount.")
            Exit Sub
        End If

        Dim amount = Decimal.Parse(howmuch.Text.Replace(",", ""))
        deductionList.Add(Tuple.Create(name.Text.Trim, amount))

        name.Clear()
        howmuch.Clear()

        Panel4.Invalidate()
        ComputeTotal()
    End Sub

    ' =========================
    ' PANEL DISPLAY
    ' =========================
    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint
        Dim y As Integer = 10
        For Each d In deductionList
            e.Graphics.DrawString(
                $"{d.Item1} - ₱{d.Item2:N0}",
                New Font("Segoe UI", 10),
                Brushes.Black, 10, y)
            y += 25
        Next
    End Sub

    ' =========================
    ' TOTAL COMPUTATION
    ' =========================
    Private Sub ComputeTotal()

        DeductionDetails.Clear()
        TotalDeduction = 0

        AddFixed("SSS", sss)
        AddFixed("Pag-IBIG", pagibig)
        AddFixed("PhilHealth", philhealth)

        For Each d In deductionList
            TotalDeduction += d.Item2
            DeductionDetails.Add($"{d.Item1} - ₱{d.Item2:N0}")
        Next

        total.Text = TotalDeduction.ToString("#,##0")
    End Sub

    Private Sub AddFixed(name As String, tb As TextBox)
        If tb.Text = "" Then Exit Sub
        Dim val = Decimal.Parse(tb.Text.Replace(",", ""))
        TotalDeduction += val
        DeductionDetails.Add($"{name} - ₱{val:N0}")
    End Sub

    ' =========================
    ' DEDUCT NOW
    ' =========================
    Private Sub Deductnow_Click(sender As Object, e As EventArgs) Handles Deductnow.Click
        ComputeTotal()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

End Class
