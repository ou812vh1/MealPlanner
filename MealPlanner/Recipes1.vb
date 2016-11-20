Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class Recipes1
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand

    Dim cmdBuilder As New SqlCommandBuilder
    Public Sub Recipes1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SQLstr = "Data Source=Server1;Initial Catalog=SimpleRecipeDB;Persist Security Info=True;User ID=sa;Password=F1ll3R01"
        SQLConn.ConnectionString = SQLstr
        SQLConn.Open()
        SQLcmd = New SqlCommand("Select recipeid, Category, Recipename From Recipe ORDER BY Category ASC", SQLConn)
        Dim SQLDS As New DataSet
        Dim SQLDA As New SqlDataAdapter(SQLcmd)
        cmdBuilder = New SqlCommandBuilder(SQLDA)
        SQLDA.Fill(SQLDS, "Data1")
        DataGridView1.DataSource = SQLDS.Tables(0)
        DataGridView1.Refresh()
        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Columns(2).Width = 400
        SQLConn.Close()
    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AddCat.Show()
        AddCat.TextBox1.Text = TextBox1.Text
        AddCat.Label2.Text = Label1.Text
    End Sub
    Public Sub SaveCat()
        'SQLstr = "Data Source=Server1;Initial Catalog=SimpleRecipeDB;Persist Security Info=True;User ID=sa;Password=F1ll3R01"
        'SQLConn.ConnectionString = SQLstr
        'Dim X As String
        'Dim MyCount As Integer
        'X = InputBox("Enter Cat", "CAT")
        'SQLConn.Open()
        'SQLcmd = New SqlCommand("Select recipeid, Category, Recipename From Recipe where recipeid= '" & Label1.Text & "'", SQLConn)
        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select recipeid, Category, ID, Recipename From Recipe where recipeid= '" & Label1.Text & "'", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            cmdBuilder = New SqlCommandBuilder(SQLDA)
            SQLDA.Fill(SQLDS, "tblWO")

            SQLDS.Tables(0).Rows(0).Item(1) = Label2.Text ' ReqStatus
            SQLDS.Tables(0).Rows(0).Item(3) = TextBox1.Text

            SQLDA.Update(SQLDS, "tblWO")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub
    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        If e.RowIndex >= 0 Then
            Dim selectedRow = DataGridView1.Rows(e.RowIndex)
            Dim MyRow As Integer = DataGridView1.CurrentRow.Cells(0).Value
            Dim MyRow1 As String = DataGridView1.CurrentRow.Cells(2).Value
            Label1.Text = MyRow
            TextBox1.Text = MyRow1
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class