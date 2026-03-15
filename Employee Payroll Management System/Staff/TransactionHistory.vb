Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Globalization
Imports System.Reflection

Public Class TransactionHistory

    ' =========================
    ' STORE LOGGED-IN EMPLOYEE
    ' =========================
    Private LoggedInEmployee As String

    ' =========================
    ' DATABASE CONNECTION
    ' =========================
    Private conn As New MySqlConnection("Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;")
    Private payrollTable As DataTable
    Private filteredTable As DataTable

    ' Layout settings
    Private headerHeight As Integer = 50
    Private rowHeight As Integer = 65 ' Itinaas ng konti para sa wrapped units
    Private padding As Integer = 15

    ' =========================
    ' CONSTRUCTOR
    ' =========================
    Public Sub New(fullname As String)
        InitializeComponent()
        LoggedInEmployee = fullname
    End Sub

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub TransactionHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        username.Text = LoggedInEmployee

        ' --- DOUBLE BUFFERED FIX PARA HINDI MA-LAG ---
        GetType(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic,
            Nothing, Historyview, New Object() {True})

        Historyview.AutoScroll = True
        Historyview.BackColor = Color.White
        Historyview.TabStop = False

        LoadPayrollHistory()
        ApplySearch()

        AddHandler Me.Resize, AddressOf Resize_Invalidate
        AddHandler Historyview.Resize, AddressOf Resize_Invalidate
    End Sub

    ' =========================
    ' LOAD PAYROLL (USER ONLY)
    ' =========================
    Private Sub LoadPayrollHistory()
        Try
            ' Kinukuha lahat pati created_at para sa Date/Time columns
            Dim sql As String =
                "SELECT employee_name, month, year, salary, deduction, notes, created_at
                 FROM payroll
                 WHERE employee_name = @name
                 ORDER BY created_at DESC"

            Dim adapter As New MySqlDataAdapter(sql, conn)
            adapter.SelectCommand.Parameters.AddWithValue("@name", LoggedInEmployee)

            payrollTable = New DataTable()
            adapter.Fill(payrollTable)
        Catch ex As Exception
            MessageBox.Show("Error loading transaction history: " & ex.Message)
        End Try
    End Sub

    ' =========================
    ' SEARCH LOGIC
    ' =========================
    Private Sub ApplySearch()
        If payrollTable Is Nothing Then Exit Sub
        filteredTable = payrollTable.Copy()

        If Not String.IsNullOrWhiteSpace(search.Text) Then
            Dim keyword As String = search.Text.ToLower()

            Try
                Dim rows = payrollTable.AsEnumerable().Where(Function(r) _
                    r("notes").ToString().ToLower().Contains(keyword) OrElse
                    r("year").ToString().Contains(keyword)
                ).ToList()

                If rows.Count > 0 Then
                    filteredTable = rows.CopyToDataTable()
                Else
                    filteredTable.Clear()
                End If
            Catch ex As Exception
                filteredTable.Clear()
            End Try
        End If

        Historyview.AutoScrollPosition = New Point(0, 0)
        Historyview.Invalidate()
    End Sub

    Private Sub search_TextChanged(sender As Object, e As EventArgs) Handles search.TextChanged
        ApplySearch()
    End Sub

    ' =========================
    ' BUTTON EVENTS
    ' =========================
    Private Sub refresh_Click(sender As Object, e As EventArgs) Handles refresh.Click
        LoadPayrollHistory()
        ApplySearch()
    End Sub

    Private Sub today_Click(sender As Object, e As EventArgs) Handles today.Click
        If payrollTable Is Nothing Then Exit Sub

        Dim todayDate As Date = Date.Today
        Dim rows = payrollTable.AsEnumerable().
            Where(Function(r) CDate(r("created_at")).Date = todayDate).ToList()

        If rows.Count > 0 Then
            filteredTable = rows.CopyToDataTable()
        Else
            filteredTable = payrollTable.Clone()
        End If

        Historyview.AutoScrollPosition = New Point(0, 0)
        Historyview.Invalidate()
    End Sub

    ' =========================
    ' PAINT PANEL (CUSTOM DRAWING)
    ' =========================
    Private Sub Historyview_Paint(sender As Object, e As PaintEventArgs) Handles Historyview.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        If filteredTable Is Nothing Then Exit Sub

        Dim fontHeader As New Font("Segoe UI", 9, FontStyle.Bold)
        Dim fontRow As New Font("Segoe UI", 9)
        Dim fontSmall As New Font("Segoe UI", 8)
        Dim penLine As New Pen(Color.FromArgb(230, 230, 230))

        ' I-sync ang drawing sa scroll position
        g.TranslateTransform(Historyview.AutoScrollPosition.X, Historyview.AutoScrollPosition.Y)

        Dim panelWidth As Integer = Math.Max(Historyview.ClientSize.Width, 950)

        ' --- COLUMN CALCULATIONS (HINIWALAY ANG SEMESTER AT UNITS) ---
        Dim colPeriod = CInt(panelWidth * 0.12)
        Dim colSalary = CInt(panelWidth * 0.1)
        Dim colDeduction = CInt(panelWidth * 0.1)
        Dim colSemester = CInt(panelWidth * 0.15) ' Hiniwalay na column
        Dim colUnits = CInt(panelWidth * 0.25)    ' Hiniwalay na column
        Dim colDateTime = panelWidth - (colPeriod + colSalary + colDeduction + colSemester + colUnits + padding)

        ' --- DRAW HEADER ---
        Dim headerY As Integer = Math.Abs(Historyview.AutoScrollPosition.Y)
        g.FillRectangle(New SolidBrush(Color.FromArgb(245, 246, 247)), 0, headerY, panelWidth, headerHeight)
        g.DrawLine(Pens.LightGray, 0, headerY + headerHeight, panelWidth, headerY + headerHeight)

        Dim x As Integer = padding
        g.DrawString("PERIOD", fontHeader, Brushes.DimGray, x, headerY + 15) : x += colPeriod
        g.DrawString("SALARY", fontHeader, Brushes.DimGray, x, headerY + 15) : x += colSalary
        g.DrawString("DEDUCTION", fontHeader, Brushes.DimGray, x, headerY + 15) : x += colDeduction
        g.DrawString("SEMESTER", fontHeader, Brushes.DimGray, x, headerY + 15) : x += colSemester
        g.DrawString("UNITS/SUBJECTS", fontHeader, Brushes.DimGray, x, headerY + 15) : x += colUnits
        g.DrawString("DATE RECORDED", fontHeader, Brushes.DimGray, x, headerY + 15)

        ' --- DRAW ROWS ---
        For i As Integer = 0 To filteredTable.Rows.Count - 1
            Dim y As Integer = headerHeight + (i * rowHeight)
            Dim row = filteredTable.Rows(i)

            ' Alternating background
            If i Mod 2 = 0 Then
                g.FillRectangle(New SolidBrush(Color.FromArgb(252, 252, 252)), 0, y, panelWidth, rowHeight)
            End If
            g.DrawLine(penLine, 0, y + rowHeight, panelWidth, y + rowHeight)

            x = padding

            ' 1. Period
            Dim mValue As String = row("month").ToString()
            Dim monthName As String = If(mValue = "0", "Jan", DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(Math.Max(1, CInt(mValue))))
            g.DrawString(monthName & " " & row("year").ToString(), fontRow, Brushes.Black, x, y + 20)
            x += colPeriod

            ' 2. Salary & Deduction
            g.DrawString("₱" & CDec(row("salary")).ToString("N2"), fontRow, Brushes.Green, x, y + 20)
            x += colSalary
            g.DrawString("₱" & CDec(row("deduction")).ToString("N2"), fontRow, Brushes.Firebrick, x, y + 20)
            x += colDeduction

            ' --- NOTES PARSING (Hinihiwalay ang Sem at Units) ---
            Dim notes As String = row("notes").ToString()
            Dim semPart As String = ""
            Dim unitsPart As String = ""

            If notes.Contains("|") Then
                Dim parts = notes.Split("|"c)
                semPart = parts(0).Replace("Sem:", "").Trim()
                unitsPart = parts(1).Replace("Units:", "").Trim()
            Else
                semPart = notes
            End If

            ' 3. Semester Column
            g.DrawString(semPart, fontSmall, Brushes.Black, x, y + 20)
            x += colSemester

            ' 4. Units Column (Text Wrapping)
            Dim unitsRect As New RectangleF(x, y + 10, colUnits - 10, rowHeight - 15)
            g.DrawString(unitsPart, fontSmall, Brushes.DimGray, unitsRect)
            x += colUnits

            ' 5. Date & Time Column
            Dim dt = CDate(row("created_at"))
            g.DrawString(dt.ToString("MMM dd, yyyy") & vbCrLf & dt.ToString("hh:mm tt"), fontSmall, Brushes.Gray, x, y + 15)
        Next

        Historyview.AutoScrollMinSize = New Size(0, headerHeight + (filteredTable.Rows.Count * rowHeight))
    End Sub

    Private Sub Resize_Invalidate(sender As Object, e As EventArgs)
        Historyview.Invalidate()
    End Sub

    Private Sub username_Click(sender As Object, e As EventArgs) Handles username.Click
        MessageBox.Show("Logged in as: " & LoggedInEmployee)
    End Sub

End Class