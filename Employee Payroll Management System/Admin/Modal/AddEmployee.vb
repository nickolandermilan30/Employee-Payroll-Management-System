Imports MySql.Data.MySqlClient

Public Class AddEmployee

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub AddEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Position Level Items
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Intern Level")
        ComboBox1.Items.Add("Entry Level")
        ComboBox1.Items.Add("Junior Level")
        ComboBox1.Items.Add("Mid Level")
        ComboBox1.Items.Add("Senior Level")
        ComboBox1.Items.Add("Lead Level")
        ComboBox1.Items.Add("Supervisor Level")
        ComboBox1.Items.Add("Manager Level")
        ComboBox1.Items.Add("Senior Manager Level")
        ComboBox1.Items.Add("Executive Level")

        ' Sex Items
        sex.Items.Clear()
        sex.Items.Add("Male")
        sex.Items.Add("Female")
        sex.Items.Add("Other")

        ' Password settings
        Passwordemployee.UseSystemPasswordChar = True
    End Sub

    ' =========================
    ' CLOSE BUTTON
    ' =========================
    Private Sub close_Click(sender As Object, e As EventArgs) Handles close.Click
        MyBase.Close()
    End Sub

    ' =========================
    ' SAVE BUTTON
    ' =========================
    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click

        ' BASIC VALIDATION
        If fullname.Text = "" Or email.Text = "" Or position.Text = "" _
            Or salary.Text = "" Or contactnumber.Text = "" _
            Or Passwordemployee.Text = "" Then

            MessageBox.Show("Please fill up all required fields.", "Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Password length validation
        If Passwordemployee.Text.Length < 3 Then
            MessageBox.Show("Password must be at least 3 characters.",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            OpenConnection()

            Dim query As String = "
                INSERT INTO employees 
                (fullname, email, password, birthday, position_level, job_position, salary, date_hired, sex, contact_number)
                VALUES
                (@fullname, @email, @password, @birthday, @position_level, @job_position, @salary, @date_hired, @sex, @contact_number)
            "

            Using cmd As New MySqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@fullname", fullname.Text)
                cmd.Parameters.AddWithValue("@email", email.Text)
                ' DIRECT PLAIN TEXT PASSWORD
                cmd.Parameters.AddWithValue("@password", Passwordemployee.Text)
                cmd.Parameters.AddWithValue("@birthday", birthday.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@position_level", ComboBox1.Text)
                cmd.Parameters.AddWithValue("@job_position", position.Text)
                cmd.Parameters.AddWithValue("@salary", Convert.ToDecimal(salary.Text))
                cmd.Parameters.AddWithValue("@date_hired", datehired.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@sex", sex.Text)
                cmd.Parameters.AddWithValue("@contact_number", contactnumber.Text)

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Employee saved successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ClearFields()

        Catch ex As Exception
            MessageBox.Show("Error saving data: " & ex.Message)
        Finally
            CloseConnection()
        End Try

    End Sub

    ' =========================
    ' CLEAR FIELDS
    ' =========================
    Private Sub ClearFields()
        fullname.Clear()
        email.Clear()
        position.Clear()
        salary.Clear()
        contactnumber.Clear()
        Passwordemployee.Clear()

        ComboBox1.SelectedIndex = -1
        sex.SelectedIndex = -1
        birthday.Value = Date.Now
        datehired.Value = Date.Now
    End Sub

    ' =========================
    ' SHOW / HIDE PASSWORD
    ' =========================
    Private Sub showpassword_CheckedChanged(sender As Object, e As EventArgs) Handles showpassword.CheckedChanged
        Passwordemployee.UseSystemPasswordChar = Not showpassword.Checked
    End Sub

    Private Sub Passwordemployee_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class
