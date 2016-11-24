Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class EditIngredients
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand
    Dim cmdBuilder As New SqlCommandBuilder
    Private Sub LoadIngredients()
        Dim recordcount As Integer = 0

        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select quantitytext as Qty, unittext as Unit, ingredienttext as Ingredient, Id From recipeingredient Where recipeid = '" & Label1.Text & "'", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            recordcount = SQLDA.Fill(SQLDS)

            If recordcount = 0 Then
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
                'DGV1.DataSource = Nothing
                Exit Sub
            Else

                DGV1.DataSource = SQLDS.Tables(0)
                DGV1.Refresh()
                DGV1.Columns(0).Width = 60
                DGV1.Columns(1).Width = 60
                DGV1.Columns(2).Width = 500
                DGV1.Columns(3).Width = 40
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub
    Private Sub DGV1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV1.CellContentDoubleClick
        If e.RowIndex >= 0 Then
            Dim selectedRow = DGV1.Rows(e.RowIndex)
            Dim MyRow As Integer = DGV1.CurrentRow.Cells(3).Value
            Dim MyRow1 As String = DGV1.CurrentRow.Cells(2).Value
            Label2.Text = MyRow
            Label3.Text = MyRow1
        End If
    End Sub
    Private Sub EditIngredients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLstr = "Data Source=Server1;Initial Catalog=SimpleRecipeDB;Persist Security Info=True;User ID=sa;Password=F1ll3R01"
        SQLConn.ConnectionString = SQLstr
        LoadUnits()
        LoadIngredlist()
    End Sub
    Private Sub LoadIngredlist()
        Dim recordcount As Integer = 0

        Try
            SQLConn.Open()
            'SQLcmd = New SqlCommand("Select name, ingredientid  From ingredients order by name asc", SQLConn)
            SQLcmd = New SqlCommand("Select Shrt_Desc, NDB_No  From ABBREV order by Shrt_Desc asc", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            recordcount = SQLDA.Fill(SQLDS)

            If recordcount = 0 Then
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
                'DGV1.DataSource = Nothing
                Exit Sub
            Else
                For Each r As DataRow In SQLDS.Tables(0).Rows

                    'ComboBox3.Items.Add(r("name"))
                    ComboBox3.Items.Add(r("Shrt_Desc"))

                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub
    Private Sub LoadUnits()
        Dim recordcount As Integer = 0

        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select name From units order by name asc", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            recordcount = SQLDA.Fill(SQLDS)

            If recordcount = 0 Then
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
                'DGV1.DataSource = Nothing
                Exit Sub
            Else
                For Each r As DataRow In SQLDS.Tables(0).Rows
                    'Dim row As String() = New String() {r("name")}
                    ComboBox2.Items.Add(r("Name"))

                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        LoadIngredients()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("Please fill in all boxes above", vbOKOnly)
            Exit Sub
        Else
            Try     ' Getting the tasks for (X) WO's
                SQLConn.Open()

                SQLcmd.CommandText = "INSERT INTO recipeingredient ([recipeid], [quantitytext], [unittext], [ingredienttext]) Values('" & Label1.Text & "', '" & TextBox1.Text & "', '" & ComboBox2.Text & "', '" & ComboBox3.Text & "')"
                SQLcmd.ExecuteNonQuery()
                SQLConn.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
            End Try
            LoadIngredients()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmRight.LoadIngredients()
        Me.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim x As Integer
        x = MsgBox("Sure you want to delete '" & Label3.Text & "' ? This cannot be undone. You will need to readd it.", vbYesNo)
        If x = 7 Then
            Exit Sub
        Else
            Try     ' Getting the tasks for (X) WO's
                SQLConn.Open()
                SQLcmd = New SqlCommand("DELETE From recipeingredient WHERE id = '" & Label2.Text & "' AND recipeid = '" & Label1.Text & "'", SQLConn)
                Dim SQLDS As New DataSet
                Dim SQLDA As New SqlDataAdapter(SQLcmd)
                SQLDA.Fill(SQLDS)
                SQLConn.Close()

                LoadIngredients()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
            End Try
        End If
    End Sub


End Class