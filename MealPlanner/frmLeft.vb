Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class frmLeft
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand
    Dim SQLConn2 As New SqlConnection
    Dim SQLcmd2 As New SqlCommand
    Private Sub frmLeft_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLstr = "Data Source=Server1;Initial Catalog=SimpleRecipeDB;Persist Security Info=True;User ID=sa;Password=F1ll3R01"
        SQLConn.ConnectionString = SQLstr
        SQLConn2.ConnectionString = SQLstr
        Label1.Width = Me.Width
        'LoadCat()
        LoadNode1()
        'LoadNode2()
    End Sub
    Public Sub LoadNode1()
        Dim recordcount As Integer = 0
        Dim recordcount2 As Integer = 0
        TV1.Nodes.Clear()

        Try
            Dim MyNode As String
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select distinct Category From Recipe WHERE Category <> '' ORDER BY Category ASC", SQLConn)
            'SQLcmd = New SqlCommand("Select Category, Recipename From Recipe ORDER BY Category, Recipename ASC", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            recordcount = SQLDA.Fill(SQLDS)

            Dim Root_Level As TreeNode = Nothing
            Dim Level_One As TreeNode = Nothing
            Dim Level_Two As TreeNode = Nothing
            Dim twRoot As String = "Recipe Catalog"
            Root_Level = TV1.Nodes.Add(twRoot)

            For Each r As DataRow In SQLDS.Tables(0).Rows
                Level_One = Root_Level.Nodes.Add(r.Item(0).ToString())
                MyNode = r.Item(0).ToString()

                SQLConn2.Open()
                SQLcmd2 = New SqlCommand("Select Category, Recipename From Recipe WHERE Category = '" & MyNode & "' ORDER BY Recipename ASC", SQLConn2)
                Dim SQLDS2 As New DataSet
                Dim SQLDA2 As New SqlDataAdapter(SQLcmd2)
                recordcount2 = SQLDA2.Fill(SQLDS2)

                For Each s As DataRow In SQLDS2.Tables(0).Rows
                    Level_Two = Level_One.Nodes.Add(s.Item(1).ToString())


                Next
                SQLConn2.Close()
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub



    Private Sub TV1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TV1.AfterSelect
        frmTop.Label1.Text = TV1.SelectedNode.Text
        frmRight.Timer1.Enabled = True

    End Sub
End Class