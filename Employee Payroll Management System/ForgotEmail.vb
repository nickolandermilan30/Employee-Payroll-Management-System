Imports MySql.Data.MySqlClient
Imports System.Drawing

Public Class ForgotEmail

    ' =========================
    ' DATABASE CONNECTION
    ' =========================
    Private conn As New MySqlConnection(
        "Server=127.0.0.1;Database=payroll_system;Uid=root;Pwd=;"
    )

    ' =========================
    ' FLAGS
    ' =========================
    Private verified As Boolean = False

    ' =========================
    ' VALIDATE SECURITY ANSWER
    ' =========================
    Private Sub Valid_Click_1(sender As Object, e As EventArgs) Handles Valid.Click

        If Mothersname.Text.Trim = "" Then
            MessageBox.Show("Please enter security answer", "Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            conn.Open()

            Dim query As String =
                "SELECT id FROM users WHERE security_answer = @answer LIMIT 1"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@answer", Mothersname.Text.Trim)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                verified = True

                lblStatusssssss.Text = "VALID"
                lblStatusssssss.ForeColor = Color.Green

                Newemail.Enabled = True
                setemail.Enabled = True
            Else
                verified = False

                lblStatusssssss.Text = "NOT VALID"
                lblStatusssssss.ForeColor = Color.Red

                Newemail.Enabled = False
                setemail.Enabled = False
            End If

            reader.Close()
            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try

    End Sub

    ' =========================
    ' UPDATE EMAIL (GMAIL ONLY)
    ' =========================
    Private Sub setemail_Click(sender As Object, e As EventArgs) Handles setemail.Click

        If Not verified Then
            MessageBox.Show("Please validate security answer first")
            Exit Sub
        End If

        If Newemail.Text.Trim = "" Then
            MessageBox.Show("Please enter new email")
            Exit Sub
        End If

        ' ===== GMAIL VALIDATION =====
        If Not Newemail.Text.Trim.ToLower().EndsWith("@gmail.com") Then
            MessageBox.Show("Email must be a valid Gmail address (@gmail.com only)",
                            "Invalid Email",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            conn.Open()

            Dim updateQuery As String =
                "UPDATE users SET email = @newEmail WHERE security_answer = @answer"

            Dim cmd As New MySqlCommand(updateQuery, conn)
            cmd.Parameters.AddWithValue("@newEmail", Newemail.Text.Trim)
            cmd.Parameters.AddWithValue("@answer", Mothersname.Text.Trim)

            cmd.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Email successfully updated!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' RESET FORM
            Mothersname.Clear()
            Newemail.Clear()
            lblStatusssssss.Text = ""

            verified = False
            Newemail.Enabled = False
            setemail.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try

    End Sub

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub ForgotEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Newemail.Enabled = False
        setemail.Enabled = False
        lblStatusssssss.Text = ""
    End Sub

    Private Sub Signup_Click(sender As Object, e As EventArgs) Handles Signup.Click
        Dim loginForm As New LogIn
        loginForm.Show()
        Me.Hide()
    End Sub

End Class
