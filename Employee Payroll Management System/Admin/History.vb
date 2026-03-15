Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Globalization
Imports System.Reflection

Public Class History

    Private conn As New MySqlConnection("Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;")
    Private payrollTable As DataTable
    Private filteredTable As DataTable

    ' Layout settings
    Private headerHeight As Integer = 45
    Private rowHeight As Integer = 60
    Private padding As Integer = 15

    Private Sub History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' --- DOUBLE BUFFERED FIX ---
        GetType(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic,
            Nothing, payrollhistorylist, New Object() {True})

        payrollhistorylist.AutoScroll = True
        payrollhistorylist.BackColor = Color.White
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

    Private Sub LoadPayrollHistory()
        Try
            Dim sql As String = "SELECT id, employee_name, month, year, salary, deduction, notes, created_at FROM payroll ORDER BY created_at DESC"
            Dim adapter As New MySqlDataAdapter(sql, conn)
            payrollTable = New DataTable()
            adapter.Fill(payrollTable)
        Catch ex As Exception
            MessageBox.Show("Error loading payroll history: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ApplySearch()
        If payrollTable Is Nothing Then Exit Sub
        filteredTable = payrollTable.Copy()

        If Not String.IsNullOrWhiteSpace(search.Text) Then
            Try
                Dim searchText As String = search.Text.ToLower()
                Dim rows = payrollTable.AsEnumerable().Where(Function(r) _
                    r("employee_name").ToString().ToLower().Contains(searchText) OrElse
                    r("notes").ToString().ToLower().Contains(searchText)
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
        payrollhistorylist.Invalidate()
    End Sub

    ' =========================
    ' PAINT TABLE (Custom Drawing)
    ' =========================
    Private Sub payrollhistorylist_Paint(sender As Object, e As PaintEventArgs) Handles payrollhistorylist.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim fontHeader As New Font("Segoe UI", 9, FontStyle.Bold)
        Dim fontRow As New Font("Segoe UI", 9)
        Dim fontSmall As New Font("Segoe UI", 8)
        Dim penLine As New Pen(Color.FromArgb(230, 230, 230))

        g.TranslateTransform(payrollhistorylist.AutoScrollPosition.X, payrollhistorylist.AutoScrollPosition.Y)

        Dim panelWidth As Integer = Math.Max(payrollhistorylist.ClientSize.Width, 900)

        ' --- BAGONG COLUMN WIDTHS (Hiniwalay ang Semester at Units) ---
        Dim colEmployee As Integer = CInt(panelWidth * 0.18)
        Dim colPeriod As Integer = CInt(panelWidth * 0.12)
        Dim colSalary As Integer = CInt(panelWidth * 0.1)
        Dim colDeduction As Integer = CInt(panelWidth * 0.1)
        Dim colSemester As Integer = CInt(panelWidth * 0.15) ' Hiniwalay
        Dim colUnits As Integer = CInt(panelWidth * 0.2)    ' Hiniwalay
        Dim colDate As Integer = panelWidth - (colEmployee + colPeriod + colSalary + colDeduction + colSemester + colUnits + padding)

        ' --- DRAW HEADER ---
        Dim headerY As Integer = Math.Abs(payrollhistorylist.AutoScrollPosition.Y)
        Dim headerRect As New Rectangle(0, headerY, panelWidth, headerHeight)

        Using sb As New SolidBrush(Color.FromArgb(245, 246, 247))
            g.FillRectangle(sb, headerRect)
        End Using
        g.DrawLine(Pens.LightGray, 0, headerY + headerHeight, panelWidth, headerY + headerHeight)

        g.DrawString("EMPLOYEE", fontHeader, Brushes.DimGray, padding, headerY + 14)
        g.DrawString("PERIOD", fontHeader, Brushes.DimGray, colEmployee + padding, headerY + 14)
        g.DrawString("SALARY", fontHeader, Brushes.DimGray, colEmployee + colPeriod + padding, headerY + 14)
        g.DrawString("DEDUCTION", fontHeader, Brushes.DimGray, colEmployee + colPeriod + colSalary + padding, headerY + 14)
        g.DrawString("SEMESTER", fontHeader, Brushes.DimGray, colEmployee + colPeriod + colSalary + colDeduction + padding, headerY + 14)
        g.DrawString("UNITS/SUBJECT", fontHeader, Brushes.DimGray, colEmployee + colPeriod + colSalary + colDeduction + colSemester + padding, headerY + 14)
        g.DrawString("DATE", fontHeader, Brushes.DimGray, colEmployee + colPeriod + colSalary + colDeduction + colSemester + colUnits + padding, headerY + 14)

        ' --- DRAW ROWS ---
        If filteredTable Is Nothing OrElse filteredTable.Rows.Count = 0 Then
            g.DrawString("No payroll records found.", fontRow, Brushes.Gray, padding, headerHeight + headerY + 20)
            Exit Sub
        End If

        For i As Integer = 0 To filteredTable.Rows.Count - 1
            Dim y As Integer = headerHeight + (i * rowHeight)
            Dim row = filteredTable.Rows(i)

            If i Mod 2 = 0 Then
                g.FillRectangle(New SolidBrush(Color.FromArgb(252, 252, 252)), 0, y, panelWidth, rowHeight)
            End If
            g.DrawLine(penLine, 0, y + rowHeight, panelWidth, y + rowHeight)

            ' 1. Employee Name
            g.DrawString(row("employee_name").ToString(), fontRow, Brushes.Black, padding, y + 15)

            ' 2. Period Logic
            Dim mValue As String = row("month").ToString()
            Dim displayMonth As String = If(mValue = "0", "January", DateTimeFormatInfo.CurrentInfo.GetMonthName(Math.Max(1, CInt(mValue))))
            g.DrawString(displayMonth & " " & row("year").ToString(), fontRow, Brushes.Black, colEmployee + padding, y + 15)

            ' 3. Salary & Deduction
            Dim sal As Decimal = If(IsDBNull(row("salary")), 0, CDec(row("salary")))
            Dim ded As Decimal = If(IsDBNull(row("deduction")), 0, CDec(row("deduction")))
            g.DrawString("₱" & sal.ToString("N2"), fontRow, Brushes.Green, colEmployee + colPeriod + padding, y + 15)
            g.DrawString("₱" & ded.ToString("N2"), fontRow, Brushes.Firebrick, colEmployee + colPeriod + colSalary + padding, y + 15)

            ' --- PARSING NOTES (Sem: ... | Units: ...) ---
            Dim rawNotes As String = row("notes").ToString()
            Dim semText As String = ""
            Dim unitsText As String = ""

            If rawNotes.Contains("|") Then
                Dim parts = rawNotes.Split("|"c)
                semText = parts(0).Replace("Sem:", "").Trim()
                unitsText = parts(1).Replace("Units:", "").Trim()
            Else
                semText = rawNotes ' Fallback kung walang separator
            End If

            ' 4. Semester
            g.DrawString(semText, fontSmall, Brushes.Black, colEmployee + colPeriod + colSalary + colDeduction + padding, y + 15)

            ' 5. Units (Wrapped)
            Dim unitsRect As New RectangleF(colEmployee + colPeriod + colSalary + colDeduction + colSemester + padding, y + 10, colUnits - 10, rowHeight - 15)
            g.DrawString(unitsText, fontSmall, Brushes.DimGray, unitsRect)

            ' 6. Date
            Dim createdAt As String = If(IsDBNull(row("created_at")), "", CDate(row("created_at")).ToString("MM/dd/yy HH:mm"))
            g.DrawString(createdAt, fontRow, Brushes.Black, colEmployee + colPeriod + colSalary + colDeduction + colSemester + colUnits + padding, y + 15)
        Next

        payrollhistorylist.AutoScrollMinSize = New Size(0, headerHeight + (filteredTable.Rows.Count * rowHeight))
    End Sub

    Private Sub search_TextChanged(sender As Object, e As EventArgs) Handles search.TextChanged
        ApplySearch()
    End Sub

    Private Sub Form_Resized(sender As Object, e As EventArgs)
        payrollhistorylist.Invalidate()
    End Sub

    Private Sub Panel_Resized(sender As Object, e As EventArgs)
        payrollhistorylist.Invalidate()
    End Sub

End Class