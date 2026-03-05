Imports System.Drawing.Printing
Imports System.Drawing.Imaging
Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D

Public Class Print

    Private WithEvents PrintDoc As New PrintDocument()

    ' ================= DATABASE =================
    Private conn As New MySqlConnection("Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;")

    ' ================= DATA =================
    Private empName As String
    Private empPosition As String
    Private monthYear As String
    Private presentDays As Integer
    Private baseSalary As Decimal
    Private netSalary As Decimal
    Private DeductionItems As New List(Of String)
    Private SubjectItems As New List(Of String)
    Private TotalDeduction As Decimal

    Private payGroup As String = "FACULTY / MONTHLY"
    Private modeOfPayment As String = "CASH"
    Private dateHired As String = ""
    Private logoPath As String = Path.Combine(Application.StartupPath, "Image\Logo.png")

    ' ================= CONSTRUCTOR =================
    Public Sub New(name As String, position As String, month As String,
                   days As Integer, base As Decimal, deduct As Decimal,
                   net As Decimal, deductions As List(Of String), subjects As List(Of String))

        InitializeComponent()

        empName = name
        empPosition = position
        monthYear = month
        presentDays = days
        baseSalary = base
        netSalary = net
        DeductionItems = deductions
        SubjectItems = subjects
        TotalDeduction = deduct

        GetDateHired()

        ' Set to A4 Portrait (8.27in x 11.69in)
        PrintDoc.DefaultPageSettings.PaperSize = New PaperSize("A4", 827, 1169)
        PrintDoc.DefaultPageSettings.Landscape = False
    End Sub

    ' ================= DATABASE FETCH =================
    Private Sub GetDateHired()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim query As String = "SELECT date_hired FROM employees WHERE fullname=@name LIMIT 1"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@name", empName)

            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                dateHired = Convert.ToDateTime(result).ToString("MMMM dd, yyyy")
            Else
                dateHired = "N/A"
            End If
        Catch ex As Exception
            dateHired = "N/A"
        Finally
            conn.Close()
        End Try
    End Sub

    ' ================= PRINTING LOGIC =================
    Private Sub PrintDoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDoc.PrintPage
        DrawPayslip(e.Graphics, e.PageBounds.Width)
    End Sub

    Private Sub DrawPayslip(g As Graphics, pageWidth As Integer)
        ' High quality rendering settings
        g.SmoothingMode = SmoothingMode.HighQuality
        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim margin As Integer = 50
        Dim contentWidth As Integer = pageWidth - (margin * 2)
        Dim y As Integer = 80 ' Dagdag na spacing sa pinakataas

        ' Define Fonts
        Dim fTitle As New Font("Arial", 18, FontStyle.Bold)
        Dim fCompany As New Font("Arial", 14, FontStyle.Bold)
        Dim fSubHeader As New Font("Arial", 9, FontStyle.Regular)
        Dim fLabel As New Font("Arial", 7, FontStyle.Bold)
        Dim fValue As New Font("Arial", 9, FontStyle.Bold)
        Dim fTableHead As New Font("Arial", 8, FontStyle.Bold)
        Dim fFooter As New Font("Arial", 7, FontStyle.Italic)

        ' ===== 1. BACKGROUND LOGO (WATERMARK) =====
        If File.Exists(logoPath) Then
            Using logo As Image = Image.FromFile(logoPath)
                Dim cm As New ColorMatrix() With {.Matrix33 = 0.04F} ' Super faint
                Dim ia As New ImageAttributes()
                ia.SetColorMatrix(cm)
                ' Center watermark in the middle of A4 page
                g.DrawImage(logo, New Rectangle((pageWidth - 500) \ 2, 400, 500, 500), 0, 0, logo.Width, logo.Height, GraphicsUnit.Pixel, ia)
            End Using
        End If

        ' ===== 2. HEADER SECTION =====
        If File.Exists(logoPath) Then
            Using logo As Image = Image.FromFile(logoPath)
                g.DrawImage(logo, margin, y, 85, 85)
            End Using
        End If

        ' Center-ish text alignment beside logo
        Dim textX As Integer = margin + 100
        g.DrawString("SAINT AUGUSTINE COLLEGES FOUNDATION INC.", fCompany, Brushes.Black, textX, y + 10)
        g.DrawString("San Agustin, Hagonoy, Bulacan", fSubHeader, Brushes.DimGray, textX, y + 35)
        g.DrawString("EMPLOYEE PAY ADVICE (CONFIDENTIAL)", fTitle, Brushes.DarkRed, textX, y + 55)

        y += 110 ' Spacing after header

        ' ===== 3. EMPLOYEE INFO BOXES (GRID STYLE) =====
        Dim boxH As Integer = 38
        Dim quarterW As Integer = contentWidth \ 4
        Dim halfW As Integer = contentWidth \ 2

        ' Row 1: Name and Date
        DrawGridCell(g, margin, y, halfW, boxH, "EMPLOYEE NAME", empName.ToUpper(), fLabel, fValue)
        DrawGridCell(g, margin + halfW, y, quarterW, boxH, "DATE HIRED", dateHired, fLabel, fValue)
        DrawGridCell(g, margin + halfW + quarterW, y, quarterW, boxH, "PAY DATE", DateTime.Now.ToString("MM/dd/yyyy"), fLabel, fValue)
        y += boxH

        ' Row 2: Designation and Period
        DrawGridCell(g, margin, y, halfW, boxH, "DESIGNATION / POSITION", empPosition.ToUpper(), fLabel, fValue)
        DrawGridCell(g, margin + halfW, y, quarterW, boxH, "PAYROLL GROUP", payGroup, fLabel, fValue)
        DrawGridCell(g, margin + halfW + quarterW, y, quarterW, boxH, "PAYROLL PERIOD", monthYear, fLabel, fValue)
        y += boxH

        ' Row 3: Mode of Payment and Attendance
        DrawGridCell(g, margin, y, halfW, boxH, "MODE OF PAYMENT", modeOfPayment, fLabel, fValue)
        DrawGridCell(g, margin + halfW, y, halfW, boxH, "TOTAL RENDERED DAYS", presentDays.ToString(), fLabel, fValue)

        y += boxH + 35 ' Spacing before tables

        ' ===== 4. EARNINGS & DEDUCTIONS (SIDE-BY-SIDE) =====
        Dim tableWidth As Integer = (contentWidth \ 2) - 5
        Dim tableStartTop As Integer = y

        ' --- EARNINGS TABLE ---
        g.FillRectangle(New SolidBrush(Color.FromArgb(52, 73, 94)), margin, y, tableWidth, 25)
        g.DrawString("DESCRIPTION / EARNINGS", fTableHead, Brushes.White, margin + 5, y + 6)
        g.DrawString("AMOUNT", fTableHead, Brushes.White, margin + tableWidth - 55, y + 6)

        Dim earnY As Integer = y + 25
        If SubjectItems IsNot Nothing Then
            For Each item In SubjectItems
                Dim parts = item.Split("-"c)
                Dim desc As String = parts(0).Trim()
                Dim amt As String = If(parts.Length > 1, parts(1).Trim(), "0.00")

                g.DrawRectangle(Pens.LightGray, margin, earnY, tableWidth, 25)
                g.DrawString(desc, fSubHeader, Brushes.Black, margin + 5, earnY + 6)
                g.DrawString("₱ " & amt, fValue, Brushes.Black, New RectangleF(margin, earnY + 6, tableWidth - 5, 20), New StringFormat With {.Alignment = StringAlignment.Far})
                earnY += 25
            Next
        End If
        ' Filler for Gross
        DrawSummaryRow(g, margin, earnY, tableWidth, "GROSS SALARY", baseSalary, Color.FromArgb(245, 245, 245), fValue)

        ' --- DEDUCTIONS TABLE ---
        Dim deducX As Integer = margin + tableWidth + 10
        g.FillRectangle(New SolidBrush(Color.FromArgb(192, 57, 43)), deducX, y, tableWidth, 25)
        g.DrawString("DEDUCTIONS", fTableHead, Brushes.White, deducX + 5, y + 6)
        g.DrawString("AMOUNT", fTableHead, Brushes.White, deducX + tableWidth - 55, y + 6)

        Dim deducY As Integer = y + 25
        If DeductionItems IsNot Nothing AndAlso DeductionItems.Count > 0 Then
            For Each item In DeductionItems
                Dim parts = item.Split("-"c)
                Dim desc As String = parts(0).Trim().ToUpper()
                Dim amt As String = If(parts.Length > 1, parts(1).Trim(), "0.00")

                g.DrawRectangle(Pens.LightGray, deducX, deducY, tableWidth, 25)
                g.DrawString(desc, fSubHeader, Brushes.Black, deducX + 5, deducY + 6)
                g.DrawString("₱ " & amt, fValue, Brushes.Black, New RectangleF(deducX, deducY + 6, tableWidth - 5, 20), New StringFormat With {.Alignment = StringAlignment.Far})
                deducY += 25
            Next
        Else
            g.DrawRectangle(Pens.LightGray, deducX, deducY, tableWidth, 25)
            g.DrawString("NO DEDUCTIONS", fSubHeader, Brushes.Gray, deducX + 5, deducY + 6)
            deducY += 25
        End If
        ' Filler for Total Deduc
        DrawSummaryRow(g, deducX, deducY, tableWidth, "TOTAL DEDUCTION", TotalDeduction, Color.FromArgb(255, 240, 240), fValue)

        y = Math.Max(earnY, deducY) + 40

        ' ===== 5. NET PAY HIGHLIGHT =====
        Dim netBoxW As Integer = contentWidth \ 2
        Dim netX As Integer = margin + (contentWidth - netBoxW)
        g.FillRectangle(New SolidBrush(Color.FromArgb(39, 174, 96)), netX, y, netBoxW, 45)
        g.DrawRectangle(New Pen(Color.DarkGreen, 2), netX, y, netBoxW, 45)
        g.DrawString("NET TAKE HOME PAY:", fTableHead, Brushes.White, netX + 15, y + 15)

        Dim netText As String = "₱ " & netSalary.ToString("N2")
        Dim netSize = g.MeasureString(netText, fTitle)
        g.DrawString(netText, fTitle, Brushes.White, netX + netBoxW - netSize.Width - 15, y + 8)

        y += 90

        ' ===== 6. SIGNATURES & FOOTER =====
        g.DrawString("I hereby acknowledge the receipt of the sum stated above as full payment for my services rendered.", fFooter, Brushes.Black, margin, y)
        y += 70

        ' Sig lines
        Dim sigW As Integer = 220
        g.DrawLine(Pens.Black, margin, y, margin + sigW, y)
        g.DrawString(empName.ToUpper(), fValue, Brushes.Black, margin + (sigW \ 2), y + 5, New StringFormat With {.Alignment = StringAlignment.Center})
        g.DrawString("Employee Signature", fSubHeader, Brushes.DimGray, margin + (sigW \ 2), y + 22, New StringFormat With {.Alignment = StringAlignment.Center})

        g.DrawLine(Pens.Black, margin + contentWidth - sigW, y, margin + contentWidth, y)
        g.DrawString("ADMINISTRATOR / FINANCE", fValue, Brushes.Black, margin + contentWidth - (sigW \ 2), y + 5, New StringFormat With {.Alignment = StringAlignment.Center})
        g.DrawString("Authorized Signatory", fSubHeader, Brushes.DimGray, margin + contentWidth - (sigW \ 2), y + 22, New StringFormat With {.Alignment = StringAlignment.Center})

        y += 80
        g.DrawString("Computer Generated: " & DateTime.Now.ToString("f"), fFooter, Brushes.Gray, margin, y)
    End Sub

    ' ================= DRAWING HELPERS =================
    Private Sub DrawGridCell(g As Graphics, x As Integer, y As Integer, w As Integer, h As Integer, title As String, val As String, fL As Font, fV As Font)
        g.DrawRectangle(Pens.Black, x, y, w, h)
        g.DrawString(title, fL, Brushes.DimGray, x + 6, y + 5)
        g.DrawString(val, fV, Brushes.Black, x + 6, y + 17)
    End Sub

    Private Sub DrawSummaryRow(g As Graphics, x As Integer, y As Integer, w As Integer, label As String, amt As Decimal, bg As Color, font As Font)
        g.FillRectangle(New SolidBrush(bg), x, y, w, 28)
        g.DrawRectangle(Pens.Black, x, y, w, 28)
        g.DrawString(label, font, Brushes.Black, x + 5, y + 7)
        Dim amtStr As String = "₱ " & amt.ToString("N2")
        Dim sz = g.MeasureString(amtStr, font)
        g.DrawString(amtStr, font, Brushes.Black, x + w - sz.Width - 5, y + 7)
    End Sub

    ' ================= BUTTON ACTIONS =================
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
                g.Clear(Color.White)
                DrawPayslip(g, bmp.Width)
            End Using
            bmp.Save(sfd.FileName, Imaging.ImageFormat.Png)
            MessageBox.Show("Saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Preview_Click(sender As Object, e As EventArgs) Handles Preview.Click
        Dim previewDlg As New PrintPreviewDialog()
        previewDlg.Document = PrintDoc
        previewDlg.WindowState = FormWindowState.Maximized
        previewDlg.ShowDialog()
    End Sub
End Class