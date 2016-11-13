Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class AddCat
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Label2.Text = 0 Then
            AddRec()
        Else
            EditRec()
        End If
    End Sub
    Private Sub EditRec()
        If ComboBox1.Text <> "" Then
            Recipes1.Label2.Text = ComboBox1.Text
            Recipes1.TextBox1.Text = TextBox1.Text
            Recipes1.SaveCat()
            Me.Close()
        End If
    End Sub
    Private Sub AddRec()
        Dim recordcount As Integer = 0
        Dim MyRecipeID As Integer
        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select TOP 1 recipeid From Recipe order by recipeid desc", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            recordcount = SQLDA.Fill(SQLDS)

            If recordcount = 0 Then
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
                Exit Sub
            Else
                MyRecipeID = SQLDS.Tables(0).Rows(0).Item(0)
                SQLConn.Close()

                '   writing new recipe to sql
                MyRecipeID = MyRecipeID + 1
                SQLConn.Open()
                SQLcmd.CommandText = "INSERT INTO recipe ([recipeid],[recipename], [category]) Values('" & MyRecipeID & "', '" & TextBox1.Text & "', '" & ComboBox1.Text & "')"
                SQLcmd.ExecuteNonQuery()
                SQLConn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
        Main.Button1.PerformClick()
        Me.Close()

    End Sub

    Private Sub AddCat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLstr = "Data Source=Server1;Initial Catalog=SimpleRecipeDB;Persist Security Info=True;User ID=sa;Password=F1ll3R01"
        SQLConn.ConnectionString = SQLstr
        LoadCat()
    End Sub
    Private Sub LoadCat()
        Dim recordcount As Integer = 0
        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select Cat From Category order by Cat asc", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            recordcount = SQLDA.Fill(SQLDS)

            If recordcount = 0 Then
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
                Exit Sub
            Else
                For Each r As DataRow In SQLDS.Tables(0).Rows
                    ComboBox1.Items.Add(r.Item(0).ToString())
                Next
                SQLConn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub
End Class