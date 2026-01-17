Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data
Imports System.Linq

Public Class TransactionHistory

    ' =========================
    ' STORE LOGGED-IN EMPLOYEE
    ' =========================
    Private LoggedInEmployee As String

    ' =========================
    ' DATABASE CONNECTION
    ' =========================
    Private conn As New MySqlConnection(
        "Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;"
    )

    ' =========================
    ' DATA TABLES
    ' =========================
    Private payrollTable As DataTable
    Private filteredTable As DataTable

    ' =========================
    ' LAYOUT SETTINGS
    ' =========================
    Private headerHeight As Integer = 50
    Private rowHeight As Integer = 48
    Private padding As Integer = 12

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

        Historyview.AutoScroll = True
        Historyview.BackColor = Color.White
        Historyview.TabStop = False

        LoadPayrollHistory()
        filteredTable = payrollTable.Copy() ' initial copy
        Historyview.Invalidate()

        AddHandler Me.Resize, AddressOf Resize_Invalidate
        AddHandler Historyview.Resize, AddressOf Resize_Invalidate
    End Sub

    ' =========================
    ' LOAD PAYROLL (USER ONLY)
    ' =========================
    Private Sub LoadPayrollHistory()
        Try
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
    ' SEARCH (MONTH / YEAR / NOTES / NAME)
    ' =========================
    Private Sub ApplySearch()
        filteredTable = payrollTable.Copy()

        If Not String.IsNullOrWhiteSpace(search.Text) Then
            Dim keyword As String = search.Text.ToLower()

            Dim rows = payrollTable.AsEnumerable().Where(Function(r) _
                r("employee_name").ToString().ToLower().Contains(keyword) Or
                MonthName(CInt(r("month"))).ToLower().Contains(keyword) Or
                r("year").ToString().Contains(keyword) Or
                r("notes").ToString().ToLower().Contains(keyword)
            ).ToList()

            If rows.Count > 0 Then
                filteredTable = rows.CopyToDataTable()
            Else
                filteredTable.Clear()
            End If
        End If

        Historyview.AutoScrollPosition = New Point(0, 0)
        Historyview.Invalidate()
    End Sub

    ' =========================
    ' SEARCH EVENT
    ' =========================
    Private Sub search_TextChanged(sender As Object, e As EventArgs) Handles search.TextChanged
        ApplySearch()
    End Sub

    ' =========================
    ' REFRESH BUTTON - LOAD ALL, PANEL PRESERVED
    ' =========================
    Private Sub refresh_Click(sender As Object, e As EventArgs) Handles refresh.Click
        LoadPayrollHistory()
        filteredTable = payrollTable.Copy()
        Historyview.AutoScrollPosition = New Point(0, 0)
        Historyview.Invalidate()
    End Sub

    ' =========================
    ' TODAY BUTTON - FILTER TODAY, SORT DESCENDING
    ' =========================
    Private Sub today_Click(sender As Object, e As EventArgs) Handles today.Click
        If payrollTable Is Nothing Then Exit Sub

        Dim today As Date = Date.Today

        ' Filter today only and sort descending by created_at
        Dim rows = payrollTable.AsEnumerable().
            Where(Function(r) CDate(r("created_at")).Date = today).
            OrderByDescending(Function(r) CDate(r("created_at"))).
            ToList()

        If rows.Count > 0 Then
            filteredTable = rows.CopyToDataTable()
        Else
            filteredTable = payrollTable.Clone()
        End If

        Historyview.AutoScrollPosition = New Point(0, 0)
        Historyview.Invalidate()
    End Sub

    ' =========================
    ' PAINT PANEL WITH TIME COLUMN
    ' =========================
    Private Sub Historyview_Paint(sender As Object, e As PaintEventArgs) Handles Historyview.Paint
        Dim g As Graphics = e.Graphics
        g.Clear(Color.White)

        If filteredTable Is Nothing Then Exit Sub

        Dim fontHeader As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim fontRow As New Font("Segoe UI", 9)
        Dim penLine As New Pen(Color.LightGray)

        Dim panelWidth As Integer = Historyview.ClientSize.Width
        Dim panelHeight As Integer = Historyview.ClientSize.Height

        ' COLUMN WIDTHS INCLUDING TIME
        Dim colName = CInt(panelWidth * 0.16)
        Dim colMonth = CInt(panelWidth * 0.08)
        Dim colYear = CInt(panelWidth * 0.07)
        Dim colSalary = CInt(panelWidth * 0.12)
        Dim colDeduction = CInt(panelWidth * 0.12)
        Dim colNotes = CInt(panelWidth * 0.18)
        Dim colDate = CInt(panelWidth * 0.15)
        Dim colTime = panelWidth - (colName + colMonth + colYear + colSalary + colDeduction + colNotes + colDate + padding * 2)

        ' HEADER
        g.FillRectangle(New SolidBrush(Color.FromArgb(240, 240, 240)), 0, 0, panelWidth, headerHeight)
        g.DrawLine(Pens.Gray, 0, headerHeight, panelWidth, headerHeight)

        Dim x As Integer = padding
        g.DrawString("Name", fontHeader, Brushes.Black, x, 15) : x += colName
        g.DrawString("Month", fontHeader, Brushes.Black, x, 15) : x += colMonth
        g.DrawString("Year", fontHeader, Brushes.Black, x, 15) : x += colYear
        g.DrawString("Salary", fontHeader, Brushes.Black, x, 15) : x += colSalary
        g.DrawString("Deduction", fontHeader, Brushes.Black, x, 15) : x += colDeduction
        g.DrawString("Notes", fontHeader, Brushes.Black, x, 15) : x += colNotes
        g.DrawString("Date", fontHeader, Brushes.Black, x, 15) : x += colDate
        g.DrawString("Time", fontHeader, Brushes.Black, x, 15)

        ' ROWS
        For i As Integer = 0 To filteredTable.Rows.Count - 1
            Dim y As Integer = headerHeight + i * rowHeight
            If y + rowHeight > panelHeight Then Exit For

            Dim row = filteredTable.Rows(i)
            g.FillRectangle(If(i Mod 2 = 0, Brushes.WhiteSmoke, Brushes.White), 0, y, panelWidth, rowHeight)
            g.DrawLine(penLine, 0, y + rowHeight, panelWidth, y + rowHeight)

            x = padding
            g.DrawString(row("employee_name").ToString(), fontRow, Brushes.Black, x, y + 15) : x += colName
            g.DrawString(MonthName(CInt(row("month"))), fontRow, Brushes.Black, x, y + 15) : x += colMonth
            g.DrawString(row("year").ToString(), fontRow, Brushes.Black, x, y + 15) : x += colYear
            g.DrawString("₱ " & FormatNumber(row("salary"), 2), fontRow, Brushes.Black, x, y + 15) : x += colSalary
            g.DrawString("₱ " & FormatNumber(row("deduction"), 2), fontRow, Brushes.Black, x, y + 15) : x += colDeduction
            g.DrawString(row("notes").ToString(), fontRow, Brushes.Black, x, y + 15) : x += colNotes
            g.DrawString(CDate(row("created_at")).ToString("MMMM dd, yyyy"), fontRow, Brushes.Black, x, y + 15) : x += colDate
            g.DrawString(CDate(row("created_at")).ToString("HH:mm:ss"), fontRow, Brushes.Black, x, y + 15)
        Next

        ' EMPTY
        If filteredTable.Rows.Count = 0 Then
            g.DrawString("No transaction history found.", fontRow, Brushes.Gray, padding, headerHeight + 20)
        End If
    End Sub

    ' =========================
    ' RESIZE
    ' =========================
    Private Sub Resize_Invalidate(sender As Object, e As EventArgs)
        Historyview.Invalidate()
    End Sub

    ' =========================
    ' USERNAME CLICK
    ' =========================
    Private Sub username_Click(sender As Object, e As EventArgs) Handles username.Click
        MessageBox.Show("Logged in as: " & LoggedInEmployee)
    End Sub

End Class
