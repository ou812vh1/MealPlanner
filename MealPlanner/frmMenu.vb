Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class frmMenu


    Private Sub frmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MonthCalendar1.TodayDate = Today

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then
            MsgBox("You have not selected a mealtime", vbOKOnly)
            ComboBox1.Focus()
            Exit Sub
        Else
            Dim SQLstr As String
            Dim SQLConn As New SqlConnection
            Dim SQLcmd As New SqlCommand
            Dim MyDate1 As String
            Dim str As String

            MyDate1 = Format(MonthCalendar1.SelectionStart, "MM/dd/yyyy")

            SQLstr = "Data Source=Server1;Initial Catalog=SimpleRecipeDB;Persist Security Info=True;User ID=sa;Password=F1ll3R01"
            SQLConn.ConnectionString = SQLstr
            str = "INSERT INTO MealPlan ([MyDate], [Meal], [recipeid],[recipename]) Values('" & MyDate1 & "','" & ComboBox1.Text & "','" & Label2.Text & "','" & Label3.Text & "')"

            Try     ' Inserting recipeid into meal planner table


                SQLstr = "Data Source=Server1;Initial Catalog=SimpleRecipeDB;Persist Security Info=True;User ID=sa;Password=F1ll3R01"
                SQLConn.ConnectionString = SQLstr

                SQLConn.Open()
                SQLcmd = New SqlCommand(str, SQLConn)

                SQLcmd.ExecuteNonQuery()
                SQLConn.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
            End Try
        End If
        MPlanDay.Show()
        MPlanDay.Label1.Text = MonthCalendar1.SelectionStart
        MPlanDay.Text = "Meal Plan For " & MonthCalendar1.SelectionStart
        MPlanDay.Timer1.Enabled = True
        Me.Close()

    End Sub

End Class