Imports System.Drawing
Imports System.Globalization

Public Class Payslip

    ' =========================
    ' STORE DEDUCTION LIST
    ' =========================
    Private DeductionItems As New List(Of String)
    Private TotalDeduction As Decimal

    ' =========================
    ' CONSTRUCTOR
    ' =========================
    Public Sub New(empName As String, empPosition As String, monthYear As String,
                   empPresentDays As Integer, empBaseSalary As Decimal,
                   empDeduction As Decimal, empNetSalary As Decimal,
                   deductions As List(Of String))

        InitializeComponent()

        ' BASIC INFO
        name.Text = empName
        Position.Text = empPosition
        MonthandYear.Text = monthYear
        Presentdays.Text = empPresentDays.ToString()

        Basesalary.Text = empBaseSalary.ToString("N2")
        Deduction.Text = empDeduction.ToString("N2")
        Basicsalary.Text = empBaseSalary.ToString("N2")
        deduct.Text = empDeduction.ToString("N2")
        NetSalary.Text = "₱ " & empNetSalary.ToString("N2")

        ' DEDUCTION LIST
        DeductionItems = deductions
        TotalDeduction = empDeduction
    End Sub

    ' =========================
    ' DRAW DEDUCTIONS
    ' =========================
    Private Sub DeductionSlips_Paint(sender As Object, e As PaintEventArgs) Handles DeductionSlips.Paint

        Dim g As Graphics = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim fontItem As New Font("Segoe UI", 9)
        Dim fontTotal As New Font("Segoe UI", 10, FontStyle.Bold)

        Dim startY As Integer = 10
        Dim leftX As Integer = 10
        Dim rightX As Integer = DeductionSlips.Width - 15

        ' =========================
        ' DRAW EACH DEDUCTION
        ' =========================
        For Each item As String In DeductionItems
            ' Expected format: "SSS - ₱1,000"
            Dim parts = item.Split("-"c)
            If parts.Length = 2 Then
                g.DrawString(parts(0).Trim(), fontItem, Brushes.Black, leftX, startY)
                g.DrawString(parts(1).Trim(), fontItem, Brushes.Black,
                             New RectangleF(leftX, startY, rightX - leftX, 20),
                             New StringFormat With {.Alignment = StringAlignment.Far})
                startY += 20
            End If
        Next

        startY += 5

        ' =========================
        ' LINE ABOVE TOTAL
        ' =========================
        g.DrawLine(New Pen(Color.Black, 1),
                   leftX, startY,
                   rightX, startY)

        startY += 8

        ' =========================
        ' TOTAL
        ' =========================
        g.DrawString("TOTAL", fontTotal, Brushes.Black, leftX, startY)
        g.DrawString("₱ " & TotalDeduction.ToString("N2"),
                     fontTotal, Brushes.Black,
                     New RectangleF(leftX, startY, rightX - leftX, 25),
                     New StringFormat With {.Alignment = StringAlignment.Far})
    End Sub

    ' =========================
    ' PRINT BUTTON (PASS DEDUCTION LIST)
    ' =========================
    Private Sub PrintPayslip_Click(sender As Object, e As EventArgs) Handles PrintPayslip.Click

        ' ========== Pasa ang deduction list sa Print ==========
        Dim frmPrint As New Print(
            name.Text,
            Position.Text,
            MonthandYear.Text,
            Integer.Parse(Presentdays.Text),
            Decimal.Parse(Basesalary.Text),
            Decimal.Parse(Deduction.Text),
            Decimal.Parse(NetSalary.Text.Replace("₱", "").Trim()),
            DeductionItems ' ← dito pumapasok ang list ng deductions
        )

        frmPrint.ShowDialog()

    End Sub

End Class
