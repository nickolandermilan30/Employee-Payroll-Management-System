Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Drawing.Imaging
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Print

    Private WithEvents PrintDoc As New PrintDocument()

    ' ================= DATABASE =================
    Private conn As New MySqlConnection(
        "Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;"
    )

    ' ================= DATA =================
    Private empName As String
    Private empPosition As String
    Private monthYear As String
    Private presentDays As Integer
    Private baseSalary As Decimal
    Private deduction As Decimal
    Private netSalary As Decimal
    Private DeductionItems As New List(Of String)
    Private TotalDeduction As Decimal

    Private payGroup As String = "Monthly 1"
    Private dateHired As String = ""

    Private logoPath As String = Path.Combine(Application.StartupPath, "Image\Logo.png")

    ' ================= CONSTRUCTOR =================
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

        GetDateHired()

        PrintDoc.DefaultPageSettings.PaperSize = New PaperSize("A4", 827, 1169)
    End Sub

    ' ================= GET DATE HIRED =================
    Private Sub GetDateHired()
        Try
            conn.Open()
            Dim query As String = "SELECT date_hired FROM employees WHERE fullname=@name LIMIT 1"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@name", empName)

            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing Then
                dateHired = Convert.ToDateTime(result).ToString("MMMM dd, yyyy")
            Else
                dateHired = "N/A"
            End If
        Catch ex As Exception
            MessageBox.Show("DB Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' ================= PRINT =================
    Private Sub PrintDoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDoc.PrintPage
        DrawPayslip(e.Graphics, e.PageBounds.Width)
    End Sub

    ' ================= DRAW =================
    Private Sub DrawPayslip(g As Graphics, pageWidth As Integer)

        Dim margin As Integer = 50
        Dim contentWidth As Integer = pageWidth - (margin * 2)
        Dim y As Integer = 40

        Dim fTitle As New Font("Segoe UI", 18, FontStyle.Bold)
        Dim fHeader As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim fBody As New Font("Segoe UI", 10)
        Dim fBold As New Font("Segoe UI", 11, FontStyle.Bold)

        g.Clear(Color.White)

        ' ===== WATERMARK =====
        If File.Exists(logoPath) Then
            Using logo As Image = Image.FromFile(logoPath)
                Dim cm As New ColorMatrix()
                cm.Matrix33 = 0.05F
                Dim ia As New ImageAttributes()
                ia.SetColorMatrix(cm)

                g.DrawImage(logo,
                    New Rectangle((pageWidth - 350) \ 2, 350, 350, 350),
                    0, 0, logo.Width, logo.Height,
                    GraphicsUnit.Pixel, ia)
            End Using
        End If

        ' ===== HEADER =====
        If File.Exists(logoPath) Then
            Using logo As Image = Image.FromFile(logoPath)
                g.DrawImage(logo, margin, y, 80, 80)
            End Using
        End If

        DrawCentered(g, "Saint Augustine Colleges Foundation Inc.", fBold, Brushes.Black, pageWidth, y + 10)
        DrawCentered(g, "EMPLOYEE PAYSLIP", fTitle, Brushes.Black, pageWidth, y + 35)

        y += 110

        ' ===== EMPLOYEE INFO CARD =====
        Dim boxHeight As Integer = 35
        Dim halfWidth As Integer = contentWidth \ 2

        DrawInfoBox(g, margin, y, halfWidth, boxHeight, "Employee Name", empName)
        DrawInfoBox(g, margin + halfWidth, y, halfWidth, boxHeight, "Position", empPosition)
        y += boxHeight

        DrawInfoBox(g, margin, y, halfWidth, boxHeight, "Payroll Month", monthYear)
        DrawInfoBox(g, margin + halfWidth, y, halfWidth, boxHeight, "Pay Group", payGroup)
        y += boxHeight

        DrawInfoBox(g, margin, y, halfWidth, boxHeight, "Date Hired", dateHired)
        DrawInfoBox(g, margin + halfWidth, y, halfWidth, boxHeight, "Present Days", presentDays.ToString())
        y += boxHeight + 20

        ' ===== EARNINGS =====
        DrawSectionHeader(g, "EARNINGS", margin, y, contentWidth)
        y += 30
        DrawRow(g, margin, y, contentWidth, "Base Salary", baseSalary)
        y += 35

        ' ===== DEDUCTIONS =====
        DrawSectionHeader(g, "DEDUCTIONS", margin, y, contentWidth)
        y += 30

        For Each item In DeductionItems
            Dim parts = item.Split("-"c)
            If parts.Length = 2 Then
                DrawRowText(g, margin, y, contentWidth, parts(0).Trim(), parts(1).Trim())
                y += 35
            End If
        Next

        DrawRow(g, margin, y, contentWidth, "TOTAL DEDUCTION", TotalDeduction, True)
        y += 40

        ' ===== NET SALARY =====
        DrawSectionHeader(g, "NET SALARY", margin, y, contentWidth)
        y += 30
        DrawRow(g, margin, y, contentWidth, "Net Salary", netSalary, True)
        y += 40

        g.DrawString("Date of Pay: " & DateTime.Now.ToString("MMMM dd, yyyy"), fBody, Brushes.Black, margin, y)

    End Sub

    ' ================= UI HELPERS =================
    Private Sub DrawInfoBox(g As Graphics, x As Integer, y As Integer, w As Integer, h As Integer, title As String, value As String)
        g.DrawRectangle(Pens.Black, x, y, w, h)
        g.DrawString(title, New Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, x + 5, y + 3)
        g.DrawString(value, New Font("Segoe UI", 10), Brushes.Black, x + 5, y + 15)
    End Sub

    Private Sub DrawSectionHeader(g As Graphics, text As String, x As Integer, y As Integer, w As Integer)
        g.FillRectangle(New SolidBrush(Color.FromArgb(240, 240, 240)), x, y, w, 25)
        g.DrawRectangle(Pens.Black, x, y, w, 25)
        g.DrawString(text, New Font("Segoe UI", 10, FontStyle.Bold), Brushes.Black, x + 10, y + 5)
    End Sub

    Private Sub DrawRow(g As Graphics, x As Integer, y As Integer, w As Integer, label As String, amount As Decimal, Optional bold As Boolean = False)
        Dim f As Font = If(bold, New Font("Segoe UI", 10, FontStyle.Bold), New Font("Segoe UI", 10))
        g.DrawRectangle(Pens.Black, x, y, w, 30)
        g.DrawString(label, f, Brushes.Black, x + 10, y + 7)

        Dim amountText As String = "₱ " & amount.ToString("N2")
        Dim size = g.MeasureString(amountText, f)
        g.DrawString(amountText, f, Brushes.Black, x + w - size.Width - 10, y + 7)
    End Sub

    Private Sub DrawRowText(g As Graphics, x As Integer, y As Integer, w As Integer, label As String, amount As String)
        g.DrawRectangle(Pens.Black, x, y, w, 30)
        g.DrawString(label, New Font("Segoe UI", 10), Brushes.Black, x + 10, y + 7)

        Dim size = g.MeasureString(amount, New Font("Segoe UI", 10))
        g.DrawString(amount, New Font("Segoe UI", 10), Brushes.Black, x + w - size.Width - 10, y + 7)
    End Sub

    Private Sub DrawCentered(g As Graphics, text As String, font As Font, brush As Brush, pageWidth As Integer, y As Integer)
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Center}
        g.DrawString(text, font, brush, pageWidth \ 2, y, sf)
    End Sub

    ' ================= BUTTONS =================
    Private Sub btn_Print_Click(sender As Object, e As EventArgs) Handles btn_Print.Click
        Dim pd As New PrintDialog()
        pd.Document = PrintDoc
        If pd.ShowDialog() = DialogResult.OK Then PrintDoc.Print()
    End Sub

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
            MessageBox.Show("Payslip saved successfully!")
        End If
    End Sub


    Private Sub Preview_Click(sender As Object, e As EventArgs) Handles Preview.Click
        Dim preview As New PrintPreviewDialog()
        preview.Document = PrintDoc
        preview.WindowState = FormWindowState.Maximized
        preview.ShowDialog()
    End Sub

End Class
