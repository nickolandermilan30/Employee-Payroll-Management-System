Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.Globalization

Public Class EditEmployee

    Private empId As Integer
    Private conn As New MySqlConnection("Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;")

    ' List para i-track ang bawat "Subject Card" para sa Editing
    Private SubjectRows As New List(Of SubjectRow)

    ' Helper class para sa dynamic rows
    Private Class SubjectRow
        Public CardPanel As Panel
        Public txtSubject As TextBox
        Public btnAddSalaryUnit As Button
        Public btnRemoveRow As Button
        Public SalaryUnitContainer As FlowLayoutPanel
        Public SalaryUnitCount As Integer = 0
    End Class

    ' =========================
    ' CONSTRUCTOR
    ' =========================
    Public Sub New(ByVal id As Integer)
        InitializeComponent()
        empId = id
    End Sub

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub EditEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.FromArgb(245, 246, 250)

        ' UI Settings
        salary.ReadOnly = True
        age.ReadOnly = True
        Tableperunit.AutoScroll = True
        Tableperunit.Controls.Clear()
        Passwordemployee.UseSystemPasswordChar = True

        ' Setup Dropdowns
        SetupDropdowns()

        ' LOAD DATA FROM DATABASE
        LoadEmployeeData()
    End Sub

    Private Sub SetupDropdowns()
        semester.Items.Clear()
        semester.Items.AddRange(New String() {"1st Semester", "2nd Semester"})
        semester.DropDownStyle = ComboBoxStyle.DropDownList

        ComboBox1.Items.Clear()
        ' Ginawang "Part-time" ang "Extra" base sa iyong hiling
        ComboBox1.Items.AddRange(New String() {"Regular", "Part-time", "Faculties"})
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList

        sex.Items.Clear()
        sex.Items.AddRange(New String() {"Male", "Female", "Other"})
        sex.DropDownStyle = ComboBoxStyle.DropDownList

        Status.Items.Clear()
        Status.Items.AddRange(New String() {"Active", "Inactive"})
        Status.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    ' =========================
    ' LOGIC PARA SA PART-TIME SELECTION
    ' =========================
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Part-time" Then
            ' I-disable ang Semester at Add Unit button
            semester.SelectedIndex = -1
            semester.Enabled = False
            btnAddUnit2.Enabled = False

            ' Linisin ang existing subjects
            SubjectRows.Clear()
            Tableperunit.Controls.Clear()
            salary.Text = "0"
        Else
            ' I-enable ulit kung hindi Part-time
            semester.Enabled = True
            btnAddUnit2.Enabled = True
        End If
    End Sub

    ' =========================
    ' LOAD EMPLOYEE DATA & DYNAMIC PANELS
    ' =========================
    Private Sub LoadEmployeeData()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim sql As String = "SELECT * FROM employees WHERE id=@id"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@id", empId)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Basic Information
                        fullname.Text = reader("fullname").ToString()
                        email.Text = reader("email").ToString()
                        Passwordemployee.Text = reader("password").ToString()
                        birthday.Value = Convert.ToDateTime(reader("birthday"))
                        age.Text = reader("age").ToString()

                        ' I-set ang position level muna para gumana ang IndexChanged logic
                        Dim posLevel As String = reader("position_level").ToString()
                        If posLevel = "Extra" Then posLevel = "Part-time" ' Fallback kung "Extra" pa ang nasa DB
                        ComboBox1.SelectedItem = posLevel

                        position.Text = reader("job_position").ToString()
                        salary.Text = String.Format("{0:N0}", reader("salary"))
                        datehired.Value = Convert.ToDateTime(reader("date_hired"))
                        sex.SelectedItem = reader("sex").ToString()
                        contactnumber.Text = reader("contact_number").ToString()
                        Status.SelectedItem = reader("status").ToString()

                        If ComboBox1.Text <> "Part-time" Then
                            semester.SelectedItem = reader("semester").ToString()

                            ' Reconstruct Subjects and Units
                            Dim rawSubjects As String = reader("subject_names").ToString()
                            Dim rawSalaries As String = reader("unit_salaries_breakdown").ToString()

                            If Not String.IsNullOrEmpty(rawSubjects) AndAlso rawSubjects <> "N/A" Then
                                ParseAndLoadSubjects(rawSubjects, rawSalaries)
                            End If
                        End If
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading employee: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub ParseAndLoadSubjects(subjectNames As String, salaryBreakdown As String)
        Dim subjects() As String = subjectNames.Split(New String() {", "}, StringSplitOptions.None)
        Dim salaryGroups() As String = salaryBreakdown.Split(New String() {" ; "}, StringSplitOptions.None)

        For i As Integer = 0 To subjects.Length - 1
            Dim newRow As SubjectRow = CreateSubjectRowControl()
            newRow.txtSubject.Text = subjects(i)

            If i < salaryGroups.Length Then
                Dim cleanSalaries As String = salaryGroups(i).Trim("["c, "]"c)
                Dim individualUnits() As String = cleanSalaries.Split("|"c)

                newRow.SalaryUnitContainer.Controls.Clear()
                newRow.SalaryUnitCount = 0

                For Each unitSal In individualUnits
                    AddSalaryUnitInput(newRow, unitSal)
                Next
            End If
        Next
    End Sub

    ' =========================
    ' DYNAMIC UI LOGIC
    ' =========================
    Private Function CreateSubjectRowControl() As SubjectRow
        Dim newRow As New SubjectRow()
        newRow.CardPanel = New Panel With {
            .Size = New Size(Tableperunit.Width - 25, 150),
            .BackColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle,
            .Dock = DockStyle.Top,
            .Padding = New Padding(10),
            .Margin = New Padding(0, 0, 0, 10)
        }

        Dim lblSubTitle As New Label With {.Text = "SUBJECT NAME:", .Font = New Font("Segoe UI", 8, FontStyle.Bold), .Location = New Point(10, 5), .AutoSize = True}
        newRow.txtSubject = New TextBox With {.Width = 250, .Location = New Point(10, 25)}

        newRow.btnAddSalaryUnit = New Button With {
            .Text = "+ Add Unit", .Size = New Size(100, 28), .Location = New Point(270, 23),
            .BackColor = Color.SeaGreen, .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat
        }
        AddHandler newRow.btnAddSalaryUnit.Click, Sub() AddSalaryUnitInput(newRow, "0")

        newRow.btnRemoveRow = New Button With {
            .Text = "Remove Subject", .Size = New Size(110, 28), .Location = New Point(newRow.CardPanel.Width - 120, 5),
            .BackColor = Color.IndianRed, .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat
        }
        AddHandler newRow.btnRemoveRow.Click, Sub()
                                                  Tableperunit.Controls.Remove(newRow.CardPanel)
                                                  SubjectRows.Remove(newRow)
                                                  CalculateTotalSalary()
                                              End Sub

        newRow.SalaryUnitContainer = New FlowLayoutPanel With {.Size = New Size(newRow.CardPanel.Width - 20, 75), .Location = New Point(10, 60), .AutoScroll = True, .BackColor = Color.WhiteSmoke}

        newRow.CardPanel.Controls.AddRange({lblSubTitle, newRow.txtSubject, newRow.btnAddSalaryUnit, newRow.btnRemoveRow, newRow.SalaryUnitContainer})
        Tableperunit.Controls.Add(newRow.CardPanel)
        newRow.CardPanel.BringToFront()
        SubjectRows.Add(newRow)
        Return newRow
    End Function

    Private Sub AddSalaryUnitInput(row As SubjectRow, initialValue As String)
        If row.SalaryUnitCount >= 10 Then Return

        Dim unitWrapper As New FlowLayoutPanel With {.FlowDirection = FlowDirection.TopDown, .Size = New Size(85, 55), .Margin = New Padding(3)}
        Dim lblUnit As New Label With {.Text = "Unit " & (row.SalaryUnitCount + 1), .Font = New Font("Segoe UI", 7, FontStyle.Bold), .AutoSize = True}

        Dim valDecimal As Decimal
        Decimal.TryParse(initialValue, valDecimal)
        Dim txtUnit As New TextBox With {.Width = 75, .Text = String.Format("{0:N0}", valDecimal), .TextAlign = HorizontalAlignment.Center}

        AddHandler txtUnit.KeyPress, Sub(s, ev)
                                         If Not Char.IsDigit(ev.KeyChar) AndAlso Not Char.IsControl(ev.KeyChar) Then ev.Handled = True
                                     End Sub
        AddHandler txtUnit.TextChanged, AddressOf DynamicSalary_Format

        unitWrapper.Controls.Add(lblUnit)
        unitWrapper.Controls.Add(txtUnit)
        row.SalaryUnitContainer.Controls.Add(unitWrapper)
        row.SalaryUnitCount += 1
    End Sub

    Private Sub DynamicSalary_Format(sender As Object, e As EventArgs)
        Dim tb = DirectCast(sender, TextBox)
        If String.IsNullOrEmpty(tb.Text) Then Return
        RemoveHandler tb.TextChanged, AddressOf DynamicSalary_Format
        Dim val As Decimal
        If Decimal.TryParse(tb.Text.Replace(",", ""), val) Then
            tb.Text = String.Format("{0:N0}", val)
            tb.SelectionStart = tb.Text.Length
        End If
        AddHandler tb.TextChanged, AddressOf DynamicSalary_Format
        CalculateTotalSalary()
    End Sub

    Private Sub CalculateTotalSalary()
        Dim total As Decimal = 0
        For Each row In SubjectRows
            For Each wrapper As Control In row.SalaryUnitContainer.Controls
                For Each ctrl In wrapper.Controls
                    If TypeOf ctrl Is TextBox Then
                        Dim v As Decimal
                        If Decimal.TryParse(DirectCast(ctrl, TextBox).Text.Replace(",", ""), v) Then total += v
                    End If
                Next
            Next
        Next
        salary.Text = String.Format("{0:N0}", total)
    End Sub

    ' =========================
    ' SAVE / UPDATE BUTTON
    ' =========================
    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        ' Validation check depende sa position level
        If ComboBox1.Text <> "Part-time" Then
            If semester.SelectedIndex = -1 Then
                MessageBox.Show("Please select a Semester!")
                Return
            End If
            If SubjectRows.Count = 0 Then
                MessageBox.Show("Please add at least one subject!")
                Return
            End If
        End If

        ' Prepare dynamic data
        Dim allSubjectNames As New List(Of String)
        Dim allUnitCounts As New List(Of String)
        Dim allSalariesRaw As New List(Of String)
        Dim grandTotalUnits As Integer = 0

        For Each row In SubjectRows
            allSubjectNames.Add(row.txtSubject.Text.Trim())
            allUnitCounts.Add(row.SalaryUnitCount.ToString())
            grandTotalUnits += row.SalaryUnitCount

            Dim currentSubSalaries As New List(Of String)
            For Each wrapper As Control In row.SalaryUnitContainer.Controls
                For Each ctrl In wrapper.Controls
                    If TypeOf ctrl Is TextBox Then
                        currentSubSalaries.Add(DirectCast(ctrl, TextBox).Text.Replace(",", ""))
                    End If
                Next
            Next
            allSalariesRaw.Add("[" & String.Join("|", currentSubSalaries) & "]")
        Next

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim sql As String = "UPDATE employees SET " &
                                "fullname=@fn, email=@em, password=@pw, birthday=@bd, age=@age, " &
                                "position_level=@pl, job_position=@jp, salary=@sal, date_hired=@dh, " &
                                "sex=@sex, contact_number=@cn, status=@st, semester=@sem, " &
                                "subject_names=@sn, unit_counts=@uc, unit_salaries_breakdown=@usb, total_units_overall=@tuo " &
                                "WHERE id=@id"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@fn", fullname.Text.Trim)
                cmd.Parameters.AddWithValue("@em", email.Text.Trim)
                cmd.Parameters.AddWithValue("@pw", Passwordemployee.Text)
                cmd.Parameters.AddWithValue("@bd", birthday.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@age", age.Text)
                cmd.Parameters.AddWithValue("@pl", ComboBox1.Text)
                cmd.Parameters.AddWithValue("@jp", position.Text.Trim)
                cmd.Parameters.AddWithValue("@sal", Decimal.Parse(salary.Text.Replace(",", "")))
                cmd.Parameters.AddWithValue("@dh", datehired.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@sex", sex.Text)
                cmd.Parameters.AddWithValue("@cn", contactnumber.Text.Trim)
                cmd.Parameters.AddWithValue("@st", Status.Text)

                ' Logic para sa database values kung Part-time
                cmd.Parameters.AddWithValue("@sem", If(ComboBox1.Text = "Part-time", "N/A", semester.Text))
                cmd.Parameters.AddWithValue("@sn", If(allSubjectNames.Count > 0, String.Join(", ", allSubjectNames), "N/A"))
                cmd.Parameters.AddWithValue("@uc", If(allUnitCounts.Count > 0, String.Join(", ", allUnitCounts), "0"))
                cmd.Parameters.AddWithValue("@usb", If(allSalariesRaw.Count > 0, String.Join(" ; ", allSalariesRaw), "N/A"))
                cmd.Parameters.AddWithValue("@tuo", grandTotalUnits)
                cmd.Parameters.AddWithValue("@id", empId)

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MyBase.Close()

        Catch ex As Exception
            MessageBox.Show("Error updating employee: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnAddUnit2_Click(sender As Object, e As EventArgs) Handles btnAddUnit2.Click
        If semester.SelectedIndex = -1 Then
            MessageBox.Show("Please select a semester first.")
            Return
        End If
        CreateSubjectRowControl()
    End Sub

    Private Sub close_Click(sender As Object, e As EventArgs) Handles close.Click
        MyBase.Close()
    End Sub

    Private Sub showpassword_CheckedChanged(sender As Object, e As EventArgs) Handles showpassword.CheckedChanged
        Passwordemployee.UseSystemPasswordChar = Not showpassword.Checked
    End Sub

    Private Sub birthday_ValueChanged(sender As Object, e As EventArgs) Handles birthday.ValueChanged
        Dim birthDate As DateTime = birthday.Value
        Dim today As DateTime = DateTime.Today
        Dim calculatedAge As Integer = today.Year - birthDate.Year
        If birthDate > today.AddYears(-calculatedAge) Then calculatedAge -= 1
        age.Text = If(calculatedAge < 0, "0", calculatedAge.ToString())
    End Sub

End Class