Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.Globalization

Public Class AddEmployee

    ' List para i-track ang bawat "Subject Card"
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
    ' FORM LOAD
    ' =========================
    Private Sub AddEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.FromArgb(245, 246, 250)

        salary.ReadOnly = True
        salary.Text = "0"
        age.ReadOnly = True

        ' ETO ANG PAG-SET NG 1998 AS MINIMUM YEAR PARA SA DATE HIRED
        datehired.MinDate = New DateTime(1998, 1, 1)

        ' Table UI Setup
        Tableperunit.AutoScroll = True
        Tableperunit.Controls.Clear()

        SetupDropdowns()
        Passwordemployee.UseSystemPasswordChar = True
    End Sub

    Private Sub SetupDropdowns()
        semester.Items.Clear()
        semester.Items.AddRange(New String() {"1st Semester", "2nd Semester"})
        semester.DropDownStyle = ComboBoxStyle.DropDownList

        ComboBox1.Items.Clear()
        ' Idinagdag ang Teacher at Attendance Staff dito
        ComboBox1.Items.AddRange(New String() {"Regular", "Part-time", "Faculties", "Teacher", "Attendance Staff"})
        ComboBox1.SelectedIndex = -1 ' Para walang default na nakapili agad
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList

        sex.Items.Clear()
        sex.Items.AddRange(New String() {"Male", "Female", "Other"})
        sex.DropDownStyle = ComboBoxStyle.DropDownList

        Status.Items.Clear()
        Status.Items.AddRange(New String() {"Active", "Inactive"})
        Status.SelectedIndex = 0
        Status.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    ' LOGIC PARA SA "EXTRA" SELECTION
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Listahan ng mga roles na walang subjects/units
        Dim noSubjectRoles As String() = {"Part-time", "Attendance Staff"}

        If noSubjectRoles.Contains(ComboBox1.Text) Then
            semester.SelectedIndex = -1
            semester.Enabled = False
            btnAddUnit.Enabled = False
            SubjectRows.Clear()
            Tableperunit.Controls.Clear()
            salary.Text = "0"
        Else
            semester.Enabled = True
            btnAddUnit.Enabled = True
        End If
    End Sub

    ' Validation: Numbers only for contact number
    Private Sub contactnumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles contactnumber.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Show/Hide Password
    Private Sub showpassword_CheckedChanged(sender As Object, e As EventArgs) Handles showpassword.CheckedChanged
        Passwordemployee.UseSystemPasswordChar = Not showpassword.Checked
    End Sub

    ' Age Calculation
    Private Sub birthday_ValueChanged(sender As Object, e As EventArgs) Handles birthday.ValueChanged
        Dim birthDate As DateTime = birthday.Value
        Dim today As DateTime = DateTime.Today
        Dim calculatedAge As Integer = today.Year - birthDate.Year
        If birthDate > today.AddYears(-calculatedAge) Then calculatedAge -= 1
        age.Text = If(calculatedAge < 0, "0", calculatedAge.ToString())
    End Sub

    ' =========================
    ' DYNAMIC SUBJECTS LOGIC
    ' =========================
    Private Sub btnAddUnit_Click(sender As Object, e As EventArgs) Handles btnAddUnit.Click
        If semester.SelectedIndex = -1 Then
            MessageBox.Show("Please select a Semester first!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

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
        newRow.txtSubject = New TextBox With {.Width = 250, .Location = New Point(10, 25), .PlaceholderText = "Enter Subject (e.g. English)"}

        newRow.btnAddSalaryUnit = New Button With {
            .Text = "+ Add Unit", .Size = New Size(100, 28), .Location = New Point(270, 23),
            .BackColor = Color.SeaGreen, .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat
        }
        AddHandler newRow.btnAddSalaryUnit.Click, Sub() AddSalaryUnitInput(newRow)

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

        AddSalaryUnitInput(newRow)

        newRow.CardPanel.Controls.AddRange({lblSubTitle, newRow.txtSubject, newRow.btnAddSalaryUnit, newRow.btnRemoveRow, newRow.SalaryUnitContainer})
        Tableperunit.Controls.Add(newRow.CardPanel)
        newRow.CardPanel.BringToFront()
        SubjectRows.Add(newRow)
    End Sub

    Private Sub AddSalaryUnitInput(row As SubjectRow)
        If row.SalaryUnitCount >= 10 Then Return

        Dim unitWrapper As New FlowLayoutPanel With {.FlowDirection = FlowDirection.TopDown, .Size = New Size(85, 55), .Margin = New Padding(3)}
        Dim lblUnit As New Label With {.Text = "Unit " & (row.SalaryUnitCount + 1), .Font = New Font("Segoe UI", 7, FontStyle.Bold), .AutoSize = True}
        Dim txtUnit As New TextBox With {.Width = 75, .Text = "0", .TextAlign = HorizontalAlignment.Center}

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
    ' SAVE TO DATABASE
    ' =========================
    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        ' LOGIC PARA SA VALIDATION (Updated)
        ' Dito natin idedetalye kung sino ang HINDI kailangan mag-input ng subjects/units
        If ComboBox1.Text <> "Part-time" AndAlso ComboBox1.Text <> "Attendance Staff" Then
            If semester.SelectedIndex = -1 Then
                MessageBox.Show("Please select a Semester!", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If SubjectRows.Count = 0 Then
                MessageBox.Show("Please add at least one Subject!", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        ' Paghahanda ng data
        Dim allSubjectNames As New List(Of String)
        Dim allUnitCounts As New List(Of String)
        Dim allSalariesRaw As New List(Of String)
        Dim grandTotalUnits As Integer = 0

        For Each row In SubjectRows
            If String.IsNullOrWhiteSpace(row.txtSubject.Text) Then
                MessageBox.Show("Please fill all subject names.")
                Return
            End If

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
            OpenConnection()
            Dim transaction = Conn.BeginTransaction()

            Try
                ' 1. I-update ang Query String (Idinagdag ang mothers_name)
                Dim empQuery = "INSERT INTO employees (fullname, email, password, birthday, age, position_level, job_position, " &
               "salary, date_hired, sex, contact_number, mothers_name, status, semester, " &
               "subject_names, unit_counts, unit_salaries_breakdown, total_units_overall) " &
               "VALUES (@fn, @em, @pw, @bd, @age, @pl, @jp, @sal, @dh, @sex, @cn, @mn, @st, @sem, @sn, @uc, @usb, @tuo)"

                Dim totalSalVal As Decimal = Decimal.Parse(salary.Text.Replace(",", ""))

                Using cmd As New MySqlCommand(empQuery, Conn, transaction)
                    cmd.Parameters.AddWithValue("@fn", fullname.Text.Trim)
                    cmd.Parameters.AddWithValue("@em", email.Text.Trim)
                    cmd.Parameters.AddWithValue("@pw", Passwordemployee.Text)
                    cmd.Parameters.AddWithValue("@bd", birthday.Value.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@age", age.Text)
                    cmd.Parameters.AddWithValue("@pl", ComboBox1.Text)
                    cmd.Parameters.AddWithValue("@jp", position.Text.Trim)
                    cmd.Parameters.AddWithValue("@sal", totalSalVal)
                    cmd.Parameters.AddWithValue("@dh", datehired.Value.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@sex", sex.Text)
                    cmd.Parameters.AddWithValue("@cn", contactnumber.Text.Trim)

                    ' --- ETO ANG DAGDAG PARA SA MOTHERS NAME ---
                    cmd.Parameters.AddWithValue("@mn", mothersname.Text.Trim)

                    cmd.Parameters.AddWithValue("@st", Status.Text)
                    cmd.Parameters.AddWithValue("@sem", If(ComboBox1.Text = "Part-time" Or ComboBox1.Text = "Attendance Staff", "N/A", semester.Text))

                    cmd.Parameters.AddWithValue("@sn", If(allSubjectNames.Count > 0, String.Join(", ", allSubjectNames), "N/A"))
                    cmd.Parameters.AddWithValue("@uc", If(allUnitCounts.Count > 0, String.Join(", ", allUnitCounts), "0"))
                    cmd.Parameters.AddWithValue("@usb", If(allSalariesRaw.Count > 0, String.Join(" ; ", allSalariesRaw), "N/A"))
                    cmd.Parameters.AddWithValue("@tuo", grandTotalUnits)

                    cmd.ExecuteNonQuery()
                End Using

                transaction.Commit()
                MessageBox.Show("Employee Successfully Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearFields()

            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Error during saving: " & ex.Message)
            End Try

        Catch ex As Exception
            MessageBox.Show("Connection Error: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub ClearFields()
        fullname.Clear() : email.Clear() : Passwordemployee.Clear() : position.Clear() : contactnumber.Clear()
        mothersname.Clear()
        salary.Text = "0" : age.Clear()
        SubjectRows.Clear()
        Tableperunit.Controls.Clear()
        semester.SelectedIndex = -1
        ComboBox1.SelectedIndex = -1
        semester.Enabled = True
        btnAddUnit.Enabled = True
    End Sub

    Private Sub close_Click(sender As Object, e As EventArgs) Handles close.Click
        MyBase.Close()
    End Sub

    Private Sub Status_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Status.SelectedIndexChanged

    End Sub

    Private Sub positionlist_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub mothersname_TextChanged(sender As Object, e As EventArgs) Handles mothersname.TextChanged

    End Sub
End Class