Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Globalization

Public Class History

    Private conn As New MySqlConnection("Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;")
    Private payrollTable As DataTable
    Private filteredTable As DataTable

    ' Layout
    Private headerHeight As Integer = 45
    Private rowHeight As Integer = 45
    Private padding As Integer = 10

    Private Sub History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        payrollhistorylist.AutoScroll = True
        payrollhistorylist.BackColor = Color.White

        payrollhistorylist.TabStop = False
        payrollhistorylist.Enabled = True

        search.TabIndex = 0

        LoadPayrollHistory()
        ApplySearch()

        AddHandler Me.Resize, AddressOf Form_Resized
        AddHandler payrollhistorylist.Resize, AddressOf Panel_Resized
    End Sub

    Private Sub search_KeyDown(sender As Object, e As KeyEventArgs) Handles search.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            payrollhistorylist.Focus()
        End If
    End Sub

    ' =========================
    ' LOAD DATA
    ' =========================
    Private Sub LoadPayrollHistory()
        Try
            Dim sql As String =
                "SELECT employee_name, month, year, salary, deduction, notes, created_at " &
                "FROM payroll ORDER BY created_at DESC"

            Dim adapter As New MySqlDataAdapter(sql, conn)
            payrollTable = New DataTable()
            adapter.Fill(payrollTable)

        Catch ex As Exception
            MessageBox.Show("Error loading payroll history: " & ex.Message)
        End Try
    End Sub

    ' =========================
    ' SEARCH
    ' =========================
    Private Sub ApplySearch()
        filteredTable = payrollTable.Copy()

        If Not String.IsNullOrWhiteSpace(search.Text) Then
            Dim rows = payrollTable.AsEnumerable().
                Where(Function(r) r("employee_name").ToString().
                ToLower().Contains(search.Text.ToLower())).ToList()

            If rows.Count > 0 Then
                filteredTable = rows.CopyToDataTable()
            Else
                filteredTable.Clear()
            End If
        End If

        payrollhistorylist.Invalidate()
    End Sub

    ' =========================
    ' PAINT TABLE
    ' =========================
    Private Sub payrollhistorylist_Paint(sender As Object, e As PaintEventArgs) Handles payrollhistorylist.Paint
        Dim g As Graphics = e.Graphics
        Dim fontHeader As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim fontRow As New Font("Segoe UI", 9)
        Dim penLine As New Pen(Color.LightGray)

        Dim panelWidth As Integer = payrollhistorylist.ClientSize.Width
        Dim panelHeight As Integer = payrollhistorylist.ClientSize.Height

        g.FillRectangle(Brushes.White, payrollhistorylist.ClientRectangle)

        ' Column widths
        Dim colEmployee As Integer = CInt(panelWidth * 0.2)
        Dim colMonth As Integer = CInt(panelWidth * 0.1)
        Dim colYear As Integer = CInt(panelWidth * 0.1)
        Dim colSalary As Integer = CInt(panelWidth * 0.15)
        Dim colDeduction As Integer = CInt(panelWidth * 0.15)
        Dim colNotes As Integer = CInt(panelWidth * 0.2)
        Dim colDate As Integer = panelWidth -
            (colEmployee + colMonth + colYear + colSalary + colDeduction + colNotes + padding * 2)

        ' HEADER
        g.FillRectangle(Brushes.LightGray, 0, 0, panelWidth, headerHeight)
        g.DrawRectangle(Pens.Gray, 0, 0, panelWidth, headerHeight)

        g.DrawString("Employee", fontHeader, Brushes.Black, padding, 12)
        g.DrawString("Month", fontHeader, Brushes.Black, colEmployee + padding, 12)
        g.DrawString("Year", fontHeader, Brushes.Black, colEmployee + colMonth + padding, 12)
        g.DrawString("Salary", fontHeader, Brushes.Black, colEmployee + colMonth + colYear + padding, 12)
        g.DrawString("Deduction", fontHeader, Brushes.Black, colEmployee + colMonth + colYear + colSalary + padding, 12)
        g.DrawString("Notes", fontHeader, Brushes.Black, colEmployee + colMonth + colYear + colSalary + colDeduction + padding, 12)
        g.DrawString("Date", fontHeader, Brushes.Black,
                     colEmployee + colMonth + colYear + colSalary + colDeduction + colNotes + padding, 12)

        ' ROWS
        If filteredTable Is Nothing OrElse filteredTable.Rows.Count = 0 Then Exit Sub

        For i As Integer = 0 To filteredTable.Rows.Count - 1
            Dim y As Integer = headerHeight + i * rowHeight
            If y + rowHeight > panelHeight Then Exit For

            Dim row = filteredTable.Rows(i)

            g.FillRectangle(If(i Mod 2 = 0, Brushes.WhiteSmoke, Brushes.White),
                            0, y, panelWidth, rowHeight)
            g.DrawLine(penLine, 0, y, panelWidth, y)

            g.DrawString(row("employee_name").ToString(), fontRow, Brushes.Black, padding, y + 14)
            g.DrawString(MonthName(CInt(row("month"))), fontRow, Brushes.Black, colEmployee + padding, y + 14)
            g.DrawString(row("year").ToString(), fontRow, Brushes.Black, colEmployee + colMonth + padding, y + 14)
            g.DrawString("₱ " & FormatNumber(row("salary"), 2), fontRow, Brushes.Black,
                         colEmployee + colMonth + colYear + padding, y + 14)
            g.DrawString("₱ " & FormatNumber(row("deduction"), 2), fontRow, Brushes.Black,
                         colEmployee + colMonth + colYear + colSalary + padding, y + 14)
            g.DrawString(row("notes").ToString(), fontRow, Brushes.Black,
                         colEmployee + colMonth + colYear + colSalary + colDeduction + padding, y + 14)
            g.DrawString(CDate(row("created_at")).ToString("yyyy-MM-dd HH:mm"),
                         fontRow, Brushes.Black,
                         colEmployee + colMonth + colYear + colSalary + colDeduction + colNotes + padding, y + 14)
        Next
    End Sub

    ' =========================
    ' SEARCH TEXT CHANGED
    ' =========================
    Private Sub search_TextChanged(sender As Object, e As EventArgs) Handles search.TextChanged
        ApplySearch()
    End Sub

    ' =========================
    ' RESIZE
    ' =========================
    Private Sub Form_Resized(sender As Object, e As EventArgs)
        payrollhistorylist.Invalidate()
    End Sub

    Private Sub Panel_Resized(sender As Object, e As EventArgs)
        payrollhistorylist.Invalidate()
    End Sub

End Class
