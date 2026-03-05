Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class Payslip

    Private DeductionItems As New List(Of String)
    Private SubjectItems As New List(Of String)
    Private TotalDeductionVal As Decimal
    Private TotalBaseSalaryVal As Decimal

    ' ============================================================
    ' CONSTRUCTOR
    ' ============================================================
    Public Sub New(empName As String, empPosition As String, monthYear As String,
                   empPresentDays As Integer, empBaseSalary As Decimal,
                   empDeduction As Decimal, empNetSalary As Decimal,
                   deductions As List(Of String), subjects As List(Of String))

        InitializeComponent()

        ' Mapping sa UI Labels
        ' Ang empPosition dito ay galing na sa database (job_position column)
        name.Text = empName
        Position.Text = empPosition
        MonthandYear.Text = monthYear
        Presentdays.Text = empPresentDays.ToString()

        Basesalary.Text = empBaseSalary.ToString("N2")
        Deduction.Text = empDeduction.ToString("N2")
        Basicsalary.Text = empBaseSalary.ToString("N2")
        deduct.Text = empDeduction.ToString("N2")
        NetSalary.Text = "₱ " & empNetSalary.ToString("N2")

        ' Pag-save ng lists para sa Graphics (Paint event)
        Me.DeductionItems = deductions
        Me.SubjectItems = subjects
        Me.TotalDeductionVal = empDeduction
        Me.TotalBaseSalaryVal = empBaseSalary
    End Sub

    ' ============================================================
    ' PAINT DEDUCTIONS (Rendering Logic)
    ' ============================================================
    Private Sub DeductionSlips_Paint(sender As Object, e As PaintEventArgs) Handles DeductionSlips.Paint
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim fontItem As New Font("Segoe UI", 9)
        Dim fontTotal As New Font("Segoe UI", 10, FontStyle.Bold)

        Dim startY = 10
        Dim leftX = 10
        Dim rightX = DeductionSlips.Width - 15

        If DeductionItems IsNot Nothing Then
            For Each item In DeductionItems
                Dim lastDashIndex As Integer = item.LastIndexOf("-"c)

                If lastDashIndex > 0 Then
                    Dim description As String = item.Substring(0, lastDashIndex).Trim().ToUpper()
                    Dim amount As String = item.Substring(lastDashIndex + 1).Trim()

                    g.DrawString(description, fontItem, Brushes.Black, leftX, startY)
                    g.DrawString(amount, fontItem, Brushes.Black,
                                 New RectangleF(leftX, startY, rightX - leftX, 20),
                                 New StringFormat With {.Alignment = StringAlignment.Far})
                    startY += 22
                Else
                    g.DrawString(item.ToUpper(), fontItem, Brushes.Black, leftX, startY)
                    startY += 22
                End If
            Next
        End If

        startY += 5
        g.DrawLine(New Pen(Color.Black, 1), leftX, startY, rightX, startY)
        startY += 8

        g.DrawString("TOTAL DEDUCTIONS", fontTotal, Brushes.Black, leftX, startY)
        g.DrawString("₱ " & TotalDeductionVal.ToString("N2"), fontTotal, Brushes.Black,
                     New RectangleF(leftX, startY, rightX - leftX, 25),
                     New StringFormat With {.Alignment = StringAlignment.Far})
    End Sub

    ' ============================================================
    ' PAINT SUBJECTS (Rendering Logic)
    ' ============================================================
    Private Sub SubjectPanel_Paint(sender As Object, e As PaintEventArgs) Handles SubjectPanel.Paint
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim fontHeader As New Font("Segoe UI", 9, FontStyle.Bold)
        Dim fontItem As New Font("Segoe UI", 8.5, FontStyle.Regular)

        Dim startY = 10
        Dim leftX = 10
        Dim rightX = SubjectPanel.Width - 15

        g.DrawString("SUBJECT DESCRIPTION", fontHeader, Brushes.DimGray, leftX, startY)
        g.DrawString("AMOUNT", fontHeader, Brushes.DimGray,
                     New RectangleF(leftX, startY, rightX - leftX, 20),
                     New StringFormat With {.Alignment = StringAlignment.Far})

        startY += 25
        g.DrawLine(New Pen(Color.LightGray, 1), leftX, startY, rightX, startY)
        startY += 10

        For Each item In SubjectItems
            Dim lastDashIndex As Integer = item.LastIndexOf("-"c)
            If lastDashIndex > 0 Then
                Dim subName As String = item.Substring(0, lastDashIndex).Trim().ToUpper()
                Dim subAmt As String = item.Substring(lastDashIndex + 1).Trim()

                g.DrawString(subName, fontItem, Brushes.Black, leftX, startY)
                g.DrawString(subAmt, fontItem, Brushes.Black,
                             New RectangleF(leftX, startY, rightX - leftX, 20),
                             New StringFormat With {.Alignment = StringAlignment.Far})
                startY += 20
            End If
        Next
    End Sub

    ' ============================================================
    ' PRINT ACTION
    ' ============================================================
    Private Sub PrintPayslip_Click(sender As Object, e As EventArgs) Handles PrintPayslip.Click
        Try
            Dim frmPrint As New Print(name.Text, Position.Text, MonthandYear.Text,
                                   Integer.Parse(Presentdays.Text),
                                   Decimal.Parse(Basesalary.Text),
                                   TotalDeductionVal,
                                   Decimal.Parse(NetSalary.Text.Replace("₱", "").Trim()),
                                   DeductionItems, SubjectItems)
            frmPrint.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Print Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Position_Click(sender As Object, e As EventArgs) Handles Position.Click
        ' Optional click event
    End Sub
End Class