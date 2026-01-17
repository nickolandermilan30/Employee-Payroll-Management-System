Imports System.Drawing
Imports System.Drawing.Printing

Public Class Print

    ' =========================
    ' PRINT DOCUMENT
    ' =========================
    Private WithEvents PrintDoc As New PrintDocument()

    ' =========================
    ' PAYSLIP DATA
    ' =========================
    Private empName As String
    Private empPosition As String
    Private monthYear As String
    Private presentDays As Integer
    Private baseSalary As Decimal
    Private deduction As Decimal
    Private netSalary As Decimal

    ' =========================
    ' CONSTRUCTOR (RECEIVE DATA)
    ' =========================
    Public Sub New(name As String, position As String, month As String,
                   days As Integer, base As Decimal, deduct As Decimal, net As Decimal)

        InitializeComponent()

        empName = name
        empPosition = position
        monthYear = month
        presentDays = days
        baseSalary = base
        deduction = deduct
        netSalary = net

        ' A4 SIZE
        PrintDoc.DefaultPageSettings.PaperSize =
            New PaperSize("A4", 827, 1169)

        ' SHOW PREVIEW AUTOMATICALLY
        Dim preview As New PrintPreviewDialog()
        preview.Document = PrintDoc
        preview.WindowState = FormWindowState.Maximized
        preview.ShowDialog()

    End Sub

    ' =========================
    ' PRINT PAGE (PAYSLIP LAYOUT)
    ' =========================
    Private Sub PrintDoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDoc.PrintPage

        Dim g As Graphics = e.Graphics
        Dim pageWidth As Integer = e.PageBounds.Width
        Dim margin As Integer = 80
        Dim y As Integer = 100

        ' ===== FONTS =====
        Dim fTitle As New Font("Arial", 16, FontStyle.Bold)
        Dim fHeader As New Font("Arial", 11, FontStyle.Bold)
        Dim fBody As New Font("Arial", 11)
        Dim fBold As New Font("Arial", 11, FontStyle.Bold)
        Dim brush As Brush = Brushes.Black

        ' ===== BORDER =====
        g.DrawRectangle(Pens.Black, margin - 20, y - 40, pageWidth - margin * 2 + 40, 420)

        ' ===== TITLE =====
        DrawCentered(g, "EMPLOYEE PAYSLIP", fTitle, brush, pageWidth, y)
        y += 50

        ' ===== BASIC INFO =====
        g.DrawString("Employee Name:", fHeader, brush, margin, y)
        g.DrawString(empName, fBody, brush, margin + 180, y)
        y += 30

        g.DrawString("Position:", fHeader, brush, margin, y)
        g.DrawString(empPosition, fBody, brush, margin + 180, y)
        y += 30

        g.DrawString("Payroll Month:", fHeader, brush, margin, y)
        g.DrawString(monthYear, fBody, brush, margin + 180, y)
        y += 40

        ' ===== TABLE HEADER =====
        g.DrawLine(Pens.Black, margin, y, pageWidth - margin, y)
        y += 10

        g.DrawString("Description", fBold, brush, margin, y)
        g.DrawString("Amount", fBold, brush, pageWidth - margin - 150, y)

        y += 25
        g.DrawLine(Pens.Black, margin, y, pageWidth - margin, y)
        y += 15

        ' ===== BASE SALARY =====
        g.DrawString("Base Salary", fBody, brush, margin, y)
        g.DrawString("₱ " & baseSalary.ToString("N2"), fBody, brush, pageWidth - margin - 150, y)
        y += 30

        ' ===== DEDUCTION =====
        g.DrawString("Total Deduction", fBody, brush, margin, y)
        g.DrawString("₱ " & deduction.ToString("N2"), fBody, brush, pageWidth - margin - 150, y)
        y += 30

        ' ===== LINE =====
        g.DrawLine(Pens.Black, margin, y, pageWidth - margin, y)
        y += 15

        ' ===== NET SALARY =====
        g.DrawString("NET SALARY", fBold, brush, margin, y)
        g.DrawString("₱ " & netSalary.ToString("N2"), fBold, brush, pageWidth - margin - 150, y)
        y += 50

        ' ===== FOOTER =====
        g.DrawString("Present Days: " & presentDays, fBody, brush, margin, y)
        y += 30

        g.DrawString("Generated on: " & DateTime.Now.ToString("MMMM dd, yyyy"),
                     fBody, brush, margin, y)

        e.HasMorePages = False

    End Sub

    ' =========================
    ' CENTER TEXT HELPER
    ' =========================
    Private Sub DrawCentered(g As Graphics, text As String, font As Font, brush As Brush, pageWidth As Integer, y As Integer)
        Dim sf As New StringFormat() With {.Alignment = StringAlignment.Center}
        g.DrawString(text, font, brush, pageWidth \ 2, y, sf)
    End Sub

    ' =========================
    ' PRINT BUTTON (LIKE VIEW_FORM)
    ' =========================
    Private Sub btn_Print_Click(sender As Object, e As EventArgs) Handles btn_Print.Click
        Try
            Dim pd As New PrintDialog()
            pd.Document = PrintDoc

            If pd.ShowDialog() = DialogResult.OK Then
                PrintDoc.Print()
            End If

        Catch ex As Exception
            MessageBox.Show("❌ Printing failed: " & ex.Message,
                            "Print Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try
    End Sub

End Class
