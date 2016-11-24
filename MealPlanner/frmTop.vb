Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class frmTop
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand
    Dim cmdBuilder As New SqlCommandBuilder
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmLeft.LoadNode1()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Recipes1.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        End
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmRight.ClearRecipe()
        AddCat.Show()
        AddCat.Label2.Text = 0
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If frmRight.Label2.Text <> 0 And frmRight.Label2.Text <> "" Then
            Dim X As Integer
            X = MsgBox("Confirm Recipe Deletion Of """ & frmRight.TextBox2.Text & """ This Cannot Be Undone", vbYesNo, "Confirm Deletions")
            If X = 6 Then
                DelSteps()
                DelIng()
                DelRecipe()
            End If


        Else
            MsgBox("Nothing To Delete, Make Sure You Highlighted A Recipe", vbOKOnly)
            Exit Sub
        End If
    End Sub
    Private Sub DelIng()
        Dim recordcount As Integer = 0

        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Delete From recipeingredient Where recipeid = '" & frmRight.Label2.Text & "'", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            SQLcmd.ExecuteNonQuery()

            SQLConn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
        frmRight.DGV2.DataSource = Nothing
        frmRight.DGV2.Refresh()
    End Sub
    Private Sub DelSteps()
        Dim recordcount As Integer = 0

        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Delete From recipeprocedure Where recipeid = '" & frmRight.Label2.Text & "'", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            SQLcmd.ExecuteNonQuery()

            SQLConn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
        frmRight.DGV1.DataSource = Nothing
        frmRight.DGV1.Refresh()
    End Sub
    Private Sub DelRecipe()
        Dim recordcount As Integer = 0

        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Delete From recipe Where recipeid = '" & frmRight.Label2.Text & "'", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            SQLcmd.ExecuteNonQuery()

            SQLConn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
        Me.Button1.PerformClick()
        frmRight.ClearRecipe()

    End Sub

    Private Sub frmTop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLstr = "Data Source=Server1;Initial Catalog=SimpleRecipeDB;Persist Security Info=True;User ID=sa;Password=F1ll3R01"
        SQLConn.ConnectionString = SQLstr
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If frmRight.Label2.Text <> "" And frmRight.Label2.Text <> 0 Then
            frmMenu.Show()
            frmMenu.Label2.Text = frmRight.Label2.Text
            frmMenu.Label3.Text = Label1.Text
        Else
            MsgBox("You Haven't Selected A Recipe To Add Yet", vbOKOnly)
            Exit Sub
        End If



    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        MPlanDay.Show()
        MPlanDay.Label1.Text = Today
        MPlanDay.Timer1.Enabled = True
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        MPlanWeek.Show()
        MPlanWeek.DateTimePicker1.Text = Today
    End Sub
End Class