Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Employee

    ' =========================
    ' DATABASE CONNECTION
    ' =========================
    Private conn As New MySqlConnection(
        "Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;"
    )

    Private employeesTable As DataTable
    Private filteredTable As DataTable

    ' Store Edit button rectangles
    Private buttonRects As New Dictionary(Of Integer, Rectangle)

    ' UI layout
    Private headerHeight As Integer = 45
    Private rowHeight As Integer = 45
    Private padding As Integer = 10

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True

        LoadEmployees()
        PopulateRoles()
        ApplyFilters()

        ' ===== ROLE DROPDOWN SETTINGS =====
        Role.DropDownStyle = ComboBoxStyle.DropDownList
        Role.TabIndex = 0
        search.TabIndex = 1
        Refresh.TabIndex = 2

        AddHandler Me.Resize, AddressOf Form_Resized
        AddHandler employelist.Resize, AddressOf Panel_Resized
    End Sub


    ' =========================
    ' LOAD EMPLOYEES
    ' =========================
    Private Sub LoadEmployees()
        Try
            Dim sql As String = "
                SELECT 
                    id,
                    fullname,
                    email,
                    job_position,
                    position_level,
                    status
                FROM employees
                ORDER BY id
            "

            Dim adapter As New MySqlDataAdapter(sql, conn)
            employeesTable = New DataTable()
            adapter.Fill(employeesTable)

        Catch ex As Exception
            MessageBox.Show("Error loading employees: " & ex.Message)
        End Try
    End Sub

    ' =========================
    ' POPULATE ROLE FILTER
    ' =========================
    Private Sub PopulateRoles()
        Role.Items.Clear()
        Role.Items.Add("All")

        Dim roles = employeesTable.AsEnumerable().
            Select(Function(r) r.Field(Of String)("position_level")).
            Distinct()

        For Each r In roles
            Role.Items.Add(r)
        Next

        Role.SelectedIndex = 0
    End Sub

    ' =========================
    ' APPLY FILTERS
    ' =========================
    Private Sub ApplyFilters()
        filteredTable = employeesTable.Copy()

        Try
            If search.Text.Trim() <> "" Then
                Dim rows = filteredTable.AsEnumerable().
                    Where(Function(r) r.Field(Of String)("fullname").
                    ToLower().Contains(search.Text.ToLower())).
                    ToList()

                filteredTable = If(rows.Count > 0, rows.CopyToDataTable(), filteredTable.Clone())
            End If

            If Role.SelectedItem IsNot Nothing AndAlso Role.SelectedItem.ToString() <> "All" Then
                Dim rows = filteredTable.AsEnumerable().
                    Where(Function(r) r.Field(Of String)("position_level") = Role.SelectedItem.ToString()).
                    ToList()

                filteredTable = If(rows.Count > 0, rows.CopyToDataTable(), filteredTable.Clone())
            End If

        Catch
        End Try

        buttonRects.Clear()
        employelist.Invalidate()
    End Sub

    ' =========================
    ' DRAW ROUNDED RECTANGLE
    ' =========================
    Private Function RoundedRect(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    ' =========================
    ' PAINT EMPLOYEE LIST
    ' =========================
    Private Sub employelist_Paint(sender As Object, e As PaintEventArgs) Handles employelist.Paint
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.FillRectangle(Brushes.White, employelist.ClientRectangle)

        Dim fontHeader As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim fontRow As New Font("Segoe UI", 9, FontStyle.Bold)

        Dim panelWidth = employelist.Width

        ' Column widths
        Dim colJob = CInt(panelWidth * 0.16)
        Dim colName = CInt(panelWidth * 0.18)
        Dim colEmail = CInt(panelWidth * 0.22)
        Dim colRole = CInt(panelWidth * 0.16)
        Dim colStatus = CInt(panelWidth * 0.12)
        Dim colAction = panelWidth - (colJob + colName + colEmail + colRole + colStatus + padding * 2)

        ' HEADER
        g.FillRectangle(Brushes.LightGray, 0, 0, panelWidth, headerHeight)
        g.DrawString("Position", fontHeader, Brushes.Black, padding, 12)
        g.DrawString("Full Name", fontHeader, Brushes.Black, colJob + padding, 12)
        g.DrawString("Email", fontHeader, Brushes.Black, colJob + colName + padding, 12)
        g.DrawString("Role", fontHeader, Brushes.Black, colJob + colName + colEmail + padding, 12)
        g.DrawString("Status", fontHeader, Brushes.Black, colJob + colName + colEmail + colRole + padding, 12)
        g.DrawString("Action", fontHeader, Brushes.Black, colJob + colName + colEmail + colRole + colStatus + padding, 12)

        If filteredTable Is Nothing Then Return

        For i As Integer = 0 To filteredTable.Rows.Count - 1
            Dim y = headerHeight + i * rowHeight
            If y + rowHeight > employelist.Height Then Exit For

            g.FillRectangle(If(i Mod 2 = 0, Brushes.WhiteSmoke, Brushes.White), 0, y, panelWidth, rowHeight)

            Dim row = filteredTable.Rows(i)

            g.DrawString(row("job_position").ToString(), fontRow, Brushes.Black, padding, y + 14)
            g.DrawString(row("fullname").ToString(), fontRow, Brushes.Black, colJob + padding, y + 14)
            g.DrawString(row("email").ToString(), fontRow, Brushes.Black, colJob + colName + padding, y + 14)
            g.DrawString(row("position_level").ToString(), fontRow, Brushes.Black, colJob + colName + colEmail + padding, y + 14)

            ' =========================
            ' STATUS BADGE
            ' =========================
            Dim statusText = row("status").ToString()
            Dim badgeColor As Color = If(statusText = "Active",
                                         Color.FromArgb(46, 204, 113),   ' green
                                         Color.FromArgb(231, 76, 60))   ' red

            Dim badgeRect As New Rectangle(
                colJob + colName + colEmail + colRole + padding,
                y + 10, 80, 24
            )

            Using path = RoundedRect(badgeRect, 12)
                Using brush As New SolidBrush(badgeColor)
                    g.FillPath(brush, path)
                End Using
            End Using

            Dim textSize = g.MeasureString(statusText, fontRow)
            g.DrawString(
                statusText,
                fontRow,
                Brushes.White,
                badgeRect.X + (badgeRect.Width - textSize.Width) / 2,
                badgeRect.Y + (badgeRect.Height - textSize.Height) / 2
            )

            ' =========================
            ' EDIT BUTTON
            ' =========================
            Dim btnRect As New Rectangle(
                colJob + colName + colEmail + colRole + colStatus + padding,
                y + 8, 70, 28
            )

            g.FillRectangle(New SolidBrush(Color.FromArgb(38, 49, 64)), btnRect)
            g.DrawString("Edit", fontRow, Brushes.White, btnRect.X + 18, btnRect.Y + 6)

            If Not buttonRects.ContainsKey(i) Then
                buttonRects.Add(i, btnRect)
            End If
        Next
    End Sub

    ' =========================
    ' EDIT CLICK
    ' =========================
    Private Sub employelist_MouseClick(sender As Object, e As MouseEventArgs) Handles employelist.MouseClick
        For Each kvp In buttonRects
            If kvp.Value.Contains(e.Location) Then
                Dim empId = filteredTable.Rows(kvp.Key)("id")
                Dim frm As New EditEmployee(empId)
                frm.ShowDialog()

                LoadEmployees()
                PopulateRoles()
                ApplyFilters()
                Exit For
            End If
        Next
    End Sub

    ' =========================
    ' EVENTS
    ' =========================
    Private Sub search_TextChanged(sender As Object, e As EventArgs) Handles search.TextChanged
        ApplyFilters()
    End Sub

    Private Sub Role_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Role.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub Refresh_Click(sender As Object, e As EventArgs) Handles Refresh.Click
        search.Clear()
        Role.SelectedIndex = 0
        LoadEmployees()
        PopulateRoles()
        ApplyFilters()
    End Sub

    Private Sub Form_Resized(sender As Object, e As EventArgs)
        employelist.Invalidate()
    End Sub

    Private Sub Panel_Resized(sender As Object, e As EventArgs)
        employelist.Invalidate()
    End Sub

End Class
