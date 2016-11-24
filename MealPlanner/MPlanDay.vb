Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class MPlanDay
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand
    Dim SQLConn1 As New SqlConnection
    Dim SQLcmd1 As New SqlCommand
    Dim SQLConn2 As New SqlConnection
    Dim SQLcmd2 As New SqlCommand
    Dim SQLConn3 As New SqlConnection
    Dim SQLcmd3 As New SqlCommand
    Dim SQLConn4 As New SqlConnection
    Dim SQLcmd4 As New SqlCommand
    Dim SQLConn5 As New SqlConnection
    Dim SQLcmd5 As New SqlCommand
    Dim SQLConn6 As New SqlConnection
    Dim SQLcmd6 As New SqlCommand
    Dim myRecipe() As String
    Public Sub LoadNode1()
        Dim recordcount As Integer = 0
        Dim recordcount2 As Integer = 0
        TV1.Nodes.Clear()

        Try

            'Dim MyNode As String
            Dim Root_Level As TreeNode = Nothing
            Dim Level_One As TreeNode = Nothing
            Dim Level_Two As TreeNode = Nothing
            Dim twRoot As String = "Meal Plan For  " & Label1.Text
            Root_Level = TV1.Nodes.Add(twRoot)
            ' Adding Breakfast items
            SQLConn1.Open()
            SQLcmd1 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Breakfast' AND MyDate = '" & Label1.Text & "'", SQLConn1)
            Dim SQLDS1 As New DataSet
            Dim SQLDA1 As New SqlDataAdapter(SQLcmd1)
            recordcount = SQLDA1.Fill(SQLDS1)
            Level_One = Root_Level.Nodes.Add("Breakfast")
            If recordcount > 0 Then
                For Each s As DataRow In SQLDS1.Tables(0).Rows
                    Level_Two = Level_One.Nodes.Add(s.Item(0).ToString() & " " & s.Item(1).ToString())
                Next
            End If
            SQLConn1.Close()


            ' Adding Morning Snack items
            SQLConn2.Open()
            SQLcmd2 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Morning Snack' AND MyDate = '" & Label1.Text & "'", SQLConn2)
            Dim SQLDS2 As New DataSet
            Dim SQLDA2 As New SqlDataAdapter(SQLcmd2)
            recordcount = SQLDA2.Fill(SQLDS2)
            Level_One = Root_Level.Nodes.Add("Morning Snack")
            If recordcount > 0 Then
                For Each s As DataRow In SQLDS2.Tables(0).Rows
                    Level_Two = Level_One.Nodes.Add(s.Item(0).ToString() & " " & s.Item(1).ToString())
                Next
            End If
            SQLConn2.Close()


            ' Adding Lunch items
            SQLConn3.Open()
            SQLcmd3 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Lunch' AND MyDate = '" & Label1.Text & "'", SQLConn3)
            Dim SQLDS3 As New DataSet
            Dim SQLDA3 As New SqlDataAdapter(SQLcmd3)
            recordcount = SQLDA3.Fill(SQLDS3)
            Level_One = Root_Level.Nodes.Add("Lunch")
            If recordcount > 0 Then
                For Each s As DataRow In SQLDS3.Tables(0).Rows
                    Level_Two = Level_One.Nodes.Add(s.Item(0).ToString() & " " & s.Item(1).ToString())
                Next
            End If
            SQLConn3.Close()


            ' Adding Afternoon Snack items
            SQLConn4.Open()
            SQLcmd4 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Afternoon Snack' AND MyDate = '" & Label1.Text & "'", SQLConn4)
            Dim SQLDS4 As New DataSet
            Dim SQLDA4 As New SqlDataAdapter(SQLcmd4)
            recordcount = SQLDA4.Fill(SQLDS4)
            Level_One = Root_Level.Nodes.Add("Afternoon Snack")
            If recordcount > 0 Then
                For Each s As DataRow In SQLDS4.Tables(0).Rows
                    Level_Two = Level_One.Nodes.Add(s.Item(0).ToString() & " " & s.Item(1).ToString())
                Next
            End If
            SQLConn4.Close()


            ' Adding Supper items
            SQLConn5.Open()
            SQLcmd5 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Supper' AND MyDate = '" & Label1.Text & "'", SQLConn5)
            Dim SQLDS5 As New DataSet
            Dim SQLDA5 As New SqlDataAdapter(SQLcmd5)
            recordcount = SQLDA5.Fill(SQLDS5)
            Level_One = Root_Level.Nodes.Add("Supper")
            If recordcount > 0 Then
                For Each s As DataRow In SQLDS5.Tables(0).Rows
                    Level_Two = Level_One.Nodes.Add(s.Item(0).ToString() & " " & s.Item(1).ToString())
                Next
            End If
            SQLConn5.Close()


            ' Adding Evening Snack items
            SQLConn6.Open()
            SQLcmd6 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Evening Snack' AND MyDate = '" & Label1.Text & "'", SQLConn6)
            Dim SQLDS6 As New DataSet
            Dim SQLDA6 As New SqlDataAdapter(SQLcmd6)
            recordcount = SQLDA6.Fill(SQLDS6)
            Level_One = Root_Level.Nodes.Add("Evening Snack")
            If recordcount > 0 Then
                For Each s As DataRow In SQLDS6.Tables(0).Rows
                    Level_Two = Level_One.Nodes.Add(s.Item(0).ToString() & " " & s.Item(1).ToString())
                Next
            End If
            SQLConn6.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn1.State = ConnectionState.Open Then SQLConn1.Close()
            If SQLConn2.State = ConnectionState.Open Then SQLConn2.Close()
            If SQLConn3.State = ConnectionState.Open Then SQLConn3.Close()
            If SQLConn4.State = ConnectionState.Open Then SQLConn4.Close()
            If SQLConn5.State = ConnectionState.Open Then SQLConn5.Close()
            If SQLConn6.State = ConnectionState.Open Then SQLConn6.Close()
        End Try
        TV1.ExpandAll()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        LoadNode1()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MPlanWeek.Show()
        MPlanWeek.Label1.Text = Label1.Text
        MPlanWeek.DateTimePicker1.Value = Label1.Text
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub
    Private Sub TV1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TV1.AfterSelect
        If TV1.SelectedNode.Text <> "Breakfast" And TV1.SelectedNode.Text <> "Morning Snack" And TV1.SelectedNode.Text <> "Lunch" And TV1.SelectedNode.Text <> "Afternoon Snack" And TV1.SelectedNode.Text <> "Supper" And TV1.SelectedNode.Text <> "Evening Snack" Then
            myRecipe = Split(TV1.SelectedNode.Text, " ")
            Label2.Text = myRecipe(0)
            If (e.Node.Parent IsNot Nothing) Then
                If (e.Node.Parent.GetType() Is GetType(TreeNode)) Then
                    Label3.Text = e.Node.Parent.Text
                End If
            Else
                Label3.Text = ""
            End If
        Else
            Label2.Text = ""
            Label3.Text = ""
        End If

    End Sub
    Private Sub MPlanDay_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SQLstr = "Data Source=Server1;Initial Catalog=SimpleRecipeDB;Persist Security Info=True;User ID=sa;Password=F1ll3R01"
        SQLConn1.ConnectionString = SQLstr
        SQLConn2.ConnectionString = SQLstr
        SQLConn3.ConnectionString = SQLstr
        SQLConn4.ConnectionString = SQLstr
        SQLConn5.ConnectionString = SQLstr
        SQLConn6.ConnectionString = SQLstr
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Label2.Text = "" Then
            MsgBox("Please hight a recipe from the list first", vbOKOnly)
        Else
            Dim x As Integer
            x = MsgBox("Are you sure you want to remove this recipe?", vbYesNo)
            Dim SQLstr As String
            Dim SQLConn As New SqlConnection
            Dim SQLcmd As New SqlCommand
            Dim MyDate1 As String
            Dim str As String

            MyDate1 = Label1.Text

            SQLstr = "Data Source=Server1;Initial Catalog=SimpleRecipeDB;Persist Security Info=True;User ID=sa;Password=F1ll3R01"
            SQLConn.ConnectionString = SQLstr
            str = "DELETE From mealplan WHERE Meal= '" & Label3.Text & "' AND recipeid =  '" & Label2.Text & "' AND MyDate = '" & MyDate1 & "'"

            Try     ' deleting recipeid into meal planner table


                SQLstr = "Data Source=Server1;Initial Catalog=SimpleRecipeDB;Persist Security Info=True;User ID=sa;Password=F1ll3R01"
                SQLConn.ConnectionString = SQLstr

                SQLConn.Open()
                SQLcmd = New SqlCommand(str, SQLConn)

                SQLcmd.ExecuteNonQuery()
                SQLConn.Close()
                LoadNode1()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
            End Try

        End If

    End Sub
End Class