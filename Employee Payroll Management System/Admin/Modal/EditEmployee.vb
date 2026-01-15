Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class EditEmployee

    Private empId As Integer
    Private conn As New MySqlConnection("Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;")

    ' =========================
    ' CONSTRUCTOR
    ' =========================
    Public Sub New(ByVal id As Integer)
        InitializeComponent()
        empId = id
        LoadEmployeeData()
    End Sub

    ' =========================
    ' LOAD EMPLOYEE DATA
    ' =========================
    Private Sub LoadEmployeeData()
        Try
            conn.Open()

            Dim sql As String = "SELECT * FROM employees WHERE id=@id"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@id", empId)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        fullname.Text = reader("fullname").ToString()
                        email.Text = reader("email").ToString()
                        birthday.Value = CDate(reader("birthday"))

                        ' Position level
                        ComboBox1.Items.Clear()
                        ComboBox1.Items.AddRange(New String() {
                            "Intern Level", "Entry Level", "Junior Level",
                            "Mid Level", "Senior Level", "Lead Level",
                            "Supervisor Level", "Manager Level",
                            "Senior Manager Level", "Executive Level"
                        })
                        ComboBox1.SelectedItem = reader("position_level").ToString()

                        position.Text = reader("job_position").ToString()
                        salary.Text = reader("salary").ToString()
                        datehired.Value = CDate(reader("date_hired"))

                        ' Sex
                        sex.Items.Clear()
                        sex.Items.AddRange(New String() {"Male", "Female", "Other"})
                        sex.SelectedItem = reader("sex").ToString()

                        contactnumber.Text = reader("contact_number").ToString()

                        ' =========================
                        ' SHOW PASSWORD (PLAIN TEXT)
                        ' =========================
                        Passwordemployee.Text = reader("password").ToString()
                        Passwordemployee.UseSystemPasswordChar = True
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading employee: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' =========================
    ' SAVE / UPDATE EMPLOYEE
    ' =========================
    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        Try
            conn.Open()

            Dim sql As String

            ' If password textbox is empty → do NOT update password
            If Passwordemployee.Text.Trim() = "" Then
                sql = "
                    UPDATE employees SET
                        fullname=@fullname,
                        email=@email,
                        birthday=@birthday,
                        position_level=@role,
                        job_position=@job,
                        salary=@salary,
                        date_hired=@datehired,
                        sex=@sex,
                        contact_number=@contact
                    WHERE id=@id
                "
            Else
                sql = "
                    UPDATE employees SET
                        fullname=@fullname,
                        email=@email,
                        password=@password,
                        birthday=@birthday,
                        position_level=@role,
                        job_position=@job,
                        salary=@salary,
                        date_hired=@datehired,
                        sex=@sex,
                        contact_number=@contact
                    WHERE id=@id
                "
            End If

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@fullname", fullname.Text)
                cmd.Parameters.AddWithValue("@email", email.Text)
                cmd.Parameters.AddWithValue("@birthday", birthday.Value)
                cmd.Parameters.AddWithValue("@role", ComboBox1.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@job", position.Text)
                cmd.Parameters.AddWithValue("@salary", salary.Text)
                cmd.Parameters.AddWithValue("@datehired", datehired.Value)
                cmd.Parameters.AddWithValue("@sex", sex.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@contact", contactnumber.Text)
                cmd.Parameters.AddWithValue("@id", empId)

                ' Only add password parameter if updating password
                If Passwordemployee.Text.Trim() <> "" Then
                    cmd.Parameters.AddWithValue("@password", Passwordemployee.Text)
                End If

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MyBase.Close()

        Catch ex As Exception
            MessageBox.Show("Error saving employee: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' =========================
    ' SHOW / HIDE PASSWORD
    ' =========================
    Private Sub showpassword_CheckedChanged(sender As Object, e As EventArgs) Handles showpassword.CheckedChanged
        Passwordemployee.UseSystemPasswordChar = Not showpassword.Checked
    End Sub

    ' =========================
    ' CLOSE
    ' =========================
    Private Sub close_Click(sender As Object, e As EventArgs) Handles close.Click
        MyBase.Close()
    End Sub

End Class
