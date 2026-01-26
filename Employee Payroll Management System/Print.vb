Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Drawing.Imaging
Imports System.IO

Public Class Print

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
    Private DeductionItems As New List(Of String)
    Private TotalDeduction As Decimal

    ' =========================
    ' LOGO PATH
    ' =========================
    Private logoPath As String = Path.Combine(Application.StartupPath, "Image\Logo.png")

    ' =========================
    ' CONSTRUCTOR
    ' =========================
    Public Sub New(name As String, position As String, month As String,
                   days As Integer, base As Decimal, deduct As Decimal,
                   net As Decimal, deductions As List(Of String))

        InitializeComponent()

        empName = name
        empPosition = position
        monthYear = month
        presentDays = days
        baseSalary = base
        deduction = deduct
        netSalary = net

        DeductionItems = deductions
        TotalDeduction = deduct

        PrintDoc.DefaultPageSettings.PaperSize = New PaperSize("A4", 827, 1169)
    End Sub

    ' =========================
    ' PRINT PAGE
    ' =========================
    Private Sub PrintDoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDoc.PrintPage
        DrawPayslip(e.Graphics, e.PageBounds.Width)
        e.HasMorePages = False
    End Sub

    ' =========================
    ' DRAW PAYSLIP
    ' =========================
    Private Sub DrawPayslip(g As Graphics, pageWidth As Integer)
        Dim margin As Integer = 80
        Dim y As Integer = 50

        ' WHITE BACKGROUND
        g.Clear(Color.White)

        Dim fTitle As New Font("Arial", 18, FontStyle.Bold)
        Dim fHeader As New Font("Arial", 11, FontStyle.Bold)
        Dim fBody As New Font("Arial", 11)
        Dim fBold As New Font("Arial", 11, FontStyle.Bold)
        Dim fSchool As New Font("Arial", 13, FontStyle.Bold)
        Dim brush As Brush = Brushes.Black

        ' ===== WATERMARK LOGO =====
        If File.Exists(logoPath) Then
            Using logo As Image = Image.FromFile(logoPath)
                Dim cm As New ColorMatrix()
                cm.Matrix33 = 0.08F ' transparency
                Dim ia As New ImageAttributes()
                ia.SetColorMatrix(cm)
                g.DrawImage(logo,
                            New Rectangle((pageWidth - 300) \ 2, 350, 300, 300),
                            0, 0, logo.Width, logo.Height,
                            GraphicsUnit.Pixel, ia)
            End Using
        End If

        ' ===== HEADER LOGO =====
        If File.Exists(logoPath) Then
            Using logo As Image = Image.FromFile(logoPath)
                g.DrawImage(logo, margin, y, 90, 90)
            End Using
        End If

        DrawCentered(g, "Saint Augustine Colleges Foundation Inc.",
                     fSchool, brush, pageWidth, y + 15)

        DrawCentered(g, "EMPLOYEE PAYSLIP",
                     fTitle, brush, pageWidth, y + 50)

        y += 140

        ' ===== EMPLOYEE INFO =====
        g.DrawString("Employee Name:", fHeader, brush, margin, y)
        g.DrawString(empName, fBody, brush, margin + 180, y)
        y += 30

        g.DrawString("Position:", fHeader, brush, margin, y)
        g.DrawString(empPosition, fBody, brush, margin + 180, y)
        y += 30

        g.DrawString("Payroll Month:", fHeader, brush, margin, y)
        g.DrawString(monthYear, fBody, brush, margin + 180, y)
        y += 40

        g.DrawLine(Pens.Black, margin, y, pageWidth - margin, y)
        y += 25

        ' ===== SALARY =====
        g.DrawString("Base Salary", fBody, brush, margin, y)
        g.DrawString("₱ " & baseSalary.ToString("N2"),
                     fBody, brush, pageWidth - margin - 150, y)
        y += 30

        g.DrawString("Total Deduction", fBody, brush, margin, y)
        g.DrawString("₱ " & deduction.ToString("N2"),
                     fBody, brush, pageWidth - margin - 150, y)
        y += 30

        ' ===== DEDUCTION LIST =====
        g.DrawString("Deduction Details:", fHeader, brush, margin, y)
        y += 25

        Dim fontItem As New Font("Arial", 10)
        Dim startX As Integer = margin
        Dim endX As Integer = pageWidth - margin

        For Each item As String In DeductionItems
            Dim parts = item.Split("-"c)
            If parts.Length = 2 Then
                g.DrawString(parts(0).Trim(), fontItem, brush, startX, y)
                g.DrawString(parts(1).Trim(), fontItem, brush,
                             New RectangleF(startX, y, endX - startX, 20),
                             New StringFormat With {.Alignment = StringAlignment.Far})
                y += 20
            End If
        Next

        ' ===== TOTAL HIGHLIGHT =====
        y += 5
        Dim highlightBrush As Brush = New SolidBrush(Color.LightBlue)
        g.FillRectangle(highlightBrush, startX, y, endX - startX, 25)

        g.DrawString("TOTAL", fBold, Brushes.Blue, startX, y)
        g.DrawString("₱ " & TotalDeduction.ToString("N2"), fBold, Brushes.Blue,
                     New RectangleF(startX, y, endX - startX, 25),
                     New StringFormat With {.Alignment = StringAlignment.Far})

        y += 35
        g.DrawLine(Pens.Black, startX, y, endX, y)
        y += 20

        ' ===== NET SALARY =====
        g.DrawString("NET SALARY", fBold, brush, startX, y)
        g.DrawString("₱ " & netSalary.ToString("N2"),
                     fBold, brush, pageWidth - margin - 150, y)
        y += 60

        ' ===== FOOTER =====
        g.DrawString("Present Days: " & presentDays, fBody, brush, startX, y)
        y += 25

        g.DrawString("Generated on: " & DateTime.Now.ToString("MMMM dd, yyyy"), fBody, brush, startX, y)

    End Sub

    ' =========================
    ' CENTER TEXT
    ' =========================
    Private Sub DrawCentered(g As Graphics, text As String, font As Font,
                             brush As Brush, pageWidth As Integer, y As Integer)
        Dim sf As New StringFormat() With {.Alignment = StringAlignment.Center}
        g.DrawString(text, font, brush, pageWidth \ 2, y, sf)
    End Sub

    ' =========================
    ' PRINT BUTTON
    ' =========================
    Private Sub btn_Print_Click(sender As Object, e As EventArgs) Handles btn_Print.Click
        Dim pd As New PrintDialog()
        pd.Document = PrintDoc
        If pd.ShowDialog() = DialogResult.OK Then PrintDoc.Print()
    End Sub

    ' =========================
    ' SAVE BUTTON
    ' =========================
    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        Dim sfd As New SaveFileDialog()
        sfd.Filter = "PNG Image (*.png)|*.png"
        sfd.FileName = "Payslip_" & empName.Replace(" ", "_")

        If sfd.ShowDialog() = DialogResult.OK Then
            Dim bmp As New Bitmap(827, 1169)
            Using g As Graphics = Graphics.FromImage(bmp)
                DrawPayslip(g, bmp.Width)
            End Using

            bmp.Save(sfd.FileName, Imaging.ImageFormat.Png)
            MessageBox.Show("Payslip saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' =========================
    ' PREVIEW BUTTON
    ' =========================
    Private Sub Preview_Click(sender As Object, e As EventArgs) Handles Preview.Click
        Dim preview As New PrintPreviewDialog()
        preview.Document = PrintDoc
        preview.WindowState = FormWindowState.Maximized
        preview.ShowDialog()
    End Sub

End Class
