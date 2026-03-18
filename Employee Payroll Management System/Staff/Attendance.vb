Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D

Public Class Attendance
    ' Database Connection String
    Dim connString As String = "server=127.0.0.1;user=root;password=;database=payroll_system"

    ' Variable para sa login filter
    Dim currentUserName As String = "Albert Rosales"

    Private Sub attendancePanel_Paint(sender As Object, e As PaintEventArgs) Handles attendancePanel.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        ' --- UI COLORS & FONTS ---
        Dim cardColor As Color = Color.White
        Dim shadowColor As Color = Color.FromArgb(230, 230, 230)
        Dim headerLabelColor As Color = Color.FromArgb(120, 130, 150)
        Dim dataTextColor As Color = Color.FromArgb(40, 45, 60)

        Dim fontTitle As New Font("Segoe UI Black", 16)
        Dim fontColumnHeader As New Font("Segoe UI Bold", 9)
        Dim fontMainData As New Font("Segoe UI Semibold", 10)
        Dim fontSubData As New Font("Segoe UI", 9)

        ' --- TABLE COLUMN POSITIONS (In-adjust para mas malawak ang gap) ---
        Dim colName As Integer = 40
        Dim colEmail As Integer = 240
        Dim colDate As Integer = 480
        Dim colIn As Integer = 640
        Dim colOut As Integer = 780
        Dim colStatus As Integer = 920

        ' --- LAYOUT SETTINGS ---
        Dim startX As Integer = 20
        Dim currentY As Integer = 100 ' Binabaan para sa mas malaking header
        Dim cardWidth As Integer = attendancePanel.Width - 40
        Dim cardHeight As Integer = 60 ' Mas mataas na row para sa vertical space
        Dim cornerRadius As Integer = 12

        ' 1. DRAW HEADER TITLE
        g.DrawString("EMPLOYEE ATTENDANCE LOG", fontTitle, New SolidBrush(Color.FromArgb(44, 62, 80)), startX + 20, 20)

        ' 2. DRAW TABLE COLUMN HEADERS (Pantay sa bawat column data)
        Dim headerY As Integer = 70
        g.DrawString("FULL NAME", fontColumnHeader, New SolidBrush(headerLabelColor), colName, headerY)
        g.DrawString("EMAIL ADDRESS", fontColumnHeader, New SolidBrush(headerLabelColor), colEmail, headerY)
        g.DrawString("DATE", fontColumnHeader, New SolidBrush(headerLabelColor), colDate, headerY)
        g.DrawString("TIME IN", fontColumnHeader, New SolidBrush(headerLabelColor), colIn, headerY)
        g.DrawString("TIME OUT", fontColumnHeader, New SolidBrush(headerLabelColor), colOut, headerY)
        g.DrawString("STATUS", fontColumnHeader, New SolidBrush(headerLabelColor), colStatus, headerY)

        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()

                Dim query As String = "SELECT fullname, email, attendance_date, checkin_time, checkout_time, status FROM attendance WHERE fullname = @name ORDER BY created_at DESC"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", currentUserName)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If Not reader.HasRows Then
                            g.DrawString("No records found.", fontMainData, Brushes.Gray, startX + 20, currentY)
                        End If

                        While reader.Read()
                            ' --- DRAW CARD (ROW) BACKGROUND ---
                            Dim cardRect As New Rectangle(startX, currentY, cardWidth, cardHeight)

                            ' Shadow (Soft Look)
                            Dim shadowRect As New Rectangle(startX + 1, currentY + 2, cardWidth, cardHeight)
                            g.FillPath(New SolidBrush(shadowColor), GetRoundedPath(shadowRect, cornerRadius))

                            ' Main Body Card
                            g.FillPath(New SolidBrush(cardColor), GetRoundedPath(cardRect, cornerRadius))

                            ' --- DATA EXTRACTION ---
                            Dim fName As String = reader("fullname").ToString()
                            Dim email As String = reader("email").ToString()
                            Dim aDate As String = Convert.ToDateTime(reader("attendance_date")).ToString("MMMM dd, yyyy")
                            Dim tIn As String = reader("checkin_time").ToString()
                            Dim tOut As String = reader("checkout_time").ToString()
                            Dim status As String = reader("status").ToString()

                            ' --- DRAW DATA PER COLUMN (Centered vertically in card) ---
                            Dim textY As Integer = currentY + (cardHeight / 2) - 10

                            g.DrawString(fName, fontMainData, New SolidBrush(dataTextColor), colName, textY)
                            g.DrawString(email, fontSubData, Brushes.DimGray, colEmail, textY)
                            g.DrawString(aDate, fontMainData, New SolidBrush(dataTextColor), colDate, textY)

                            ' Time colors (Blue accent)
                            Dim timeBrush As New SolidBrush(Color.FromArgb(52, 152, 219))
                            g.DrawString(tIn, fontMainData, timeBrush, colIn, textY)
                            g.DrawString(tOut, fontMainData, timeBrush, colOut, textY)

                            ' --- STATUS PILL (Centered) ---
                            Dim statusRect As New Rectangle(colStatus - 10, currentY + (cardHeight / 2) - 13, 100, 26)
                            Dim statusColor As Color = Color.Gray

                            Select Case status
                                Case "Present" : statusColor = Color.FromArgb(46, 204, 113)
                                Case "Absent" : statusColor = Color.FromArgb(231, 76, 60)
                                Case "Half Day" : statusColor = Color.FromArgb(241, 196, 15)
                            End Select

                            Using sb As New SolidBrush(statusColor)
                                g.FillPath(sb, GetRoundedPath(statusRect, 13))

                                Dim sf As New StringFormat()
                                sf.Alignment = StringAlignment.Center
                                sf.LineAlignment = StringAlignment.Center
                                g.DrawString(status.ToUpper(), fontColumnHeader, Brushes.White, statusRect, sf)
                            End Using

                            ' --- GAP BETWEEN ROWS ---
                            ' In-adjust natin para may malaking hingahan ang bawat row
                            currentY += cardHeight + 15
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            g.DrawString("Error: " & ex.Message, fontSubData, Brushes.Red, startX + 20, currentY)
        End Try
    End Sub

    ' Rounded Path Helper
    Private Function GetRoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim d As Integer = radius * 2
        If d <= 0 Then d = 1
        path.AddArc(rect.X, rect.Y, d, d, 180, 90)
        path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90)
        path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90)
        path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Sub Attendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        ' Light background para mag-pop ang white cards
        attendancePanel.BackColor = Color.FromArgb(242, 245, 248)
        attendancePanel.Invalidate()
    End Sub
End Class