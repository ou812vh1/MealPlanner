Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Drawing.Printing
Public Class MPlanWeek
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
    Dim strName As String
    Dim lngItem As Long
    Dim lngCount As Long
    'Dim objNode As Node
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()

    End Sub

    Private Sub MPlanWeek_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Day(7) As Integer
        SQLstr = "Data Source=Server1;Initial Catalog=SimpleRecipeDB;Persist Security Info=True;User ID=sa;Password=F1ll3R01"
        SQLConn.ConnectionString = SQLstr
        SQLConn1.ConnectionString = SQLstr
        SQLConn2.ConnectionString = SQLstr
        SQLConn3.ConnectionString = SQLstr
        SQLConn4.ConnectionString = SQLstr
        SQLConn5.ConnectionString = SQLstr
        SQLConn6.ConnectionString = SQLstr

    End Sub
    Public Sub LoadNode1()
        Dim recordcount As Integer = 0
        Dim recordcount2 As Integer = 0
        TV1.Nodes.Clear()

        Try

            'Dim MyNode As String
            Dim Root_Level As TreeNode = Nothing
            Dim Level_One As TreeNode = Nothing
            Dim Level_Two As TreeNode = Nothing
            Dim twRoot As String = "Meal Plan For  " & Label4.Text
            Root_Level = TV1.Nodes.Add(twRoot)
            ' Adding Breakfast items
            SQLConn1.Open()
            SQLcmd1 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Breakfast' AND MyDate = '" & Label4.Text & "'", SQLConn1)
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
            SQLcmd2 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Morning Snack' AND MyDate = '" & Label4.Text & "'", SQLConn2)
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
            SQLcmd3 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Lunch' AND MyDate = '" & Label4.Text & "'", SQLConn3)
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
            SQLcmd4 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Afternoon Snack' AND MyDate = '" & Label4.Text & "'", SQLConn4)
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
            SQLcmd5 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Supper' AND MyDate = '" & Label4.Text & "'", SQLConn5)
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
            SQLcmd6 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Evening Snack' AND MyDate = '" & Label4.Text & "'", SQLConn6)
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
    Public Sub LoadNode2()
        Dim recordcount As Integer = 0
        Dim recordcount2 As Integer = 0
        TV2.Nodes.Clear()

        Try

            'Dim MyNode As String
            Dim Root_Level As TreeNode = Nothing
            Dim Level_One As TreeNode = Nothing
            Dim Level_Two As TreeNode = Nothing
            Dim twRoot As String = "Meal Plan For  " & Label5.Text
            Root_Level = TV2.Nodes.Add(twRoot)
            ' Adding Breakfast items
            SQLConn1.Open()
            SQLcmd1 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Breakfast' AND MyDate = '" & Label5.Text & "'", SQLConn1)
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
            SQLcmd2 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Morning Snack' AND MyDate = '" & Label5.Text & "'", SQLConn2)
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
            SQLcmd3 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Lunch' AND MyDate = '" & Label5.Text & "'", SQLConn3)
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
            SQLcmd4 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Afternoon Snack' AND MyDate = '" & Label5.Text & "'", SQLConn4)
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
            SQLcmd5 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Supper' AND MyDate = '" & Label5.Text & "'", SQLConn5)
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
            SQLcmd6 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Evening Snack' AND MyDate = '" & Label5.Text & "'", SQLConn6)
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
        TV2.ExpandAll()
    End Sub
    Public Sub LoadNode3()
        Dim recordcount As Integer = 0
        Dim recordcount2 As Integer = 0
        TV3.Nodes.Clear()

        Try

            'Dim MyNode As String
            Dim Root_Level As TreeNode = Nothing
            Dim Level_One As TreeNode = Nothing
            Dim Level_Two As TreeNode = Nothing
            Dim twRoot As String = "Meal Plan For  " & Label6.Text
            Root_Level = TV3.Nodes.Add(twRoot)
            ' Adding Breakfast items
            SQLConn1.Open()
            SQLcmd1 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Breakfast' AND MyDate = '" & Label6.Text & "'", SQLConn1)
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
            SQLcmd2 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Morning Snack' AND MyDate = '" & Label6.Text & "'", SQLConn2)
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
            SQLcmd3 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Lunch' AND MyDate = '" & Label6.Text & "'", SQLConn3)
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
            SQLcmd4 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Afternoon Snack' AND MyDate = '" & Label6.Text & "'", SQLConn4)
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
            SQLcmd5 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Supper' AND MyDate = '" & Label6.Text & "'", SQLConn5)
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
            SQLcmd6 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Evening Snack' AND MyDate = '" & Label6.Text & "'", SQLConn6)
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
        TV3.ExpandAll()
    End Sub
    Public Sub LoadNode4()
        Dim recordcount As Integer = 0
        Dim recordcount2 As Integer = 0
        TV4.Nodes.Clear()

        Try

            'Dim MyNode As String
            Dim Root_Level As TreeNode = Nothing
            Dim Level_One As TreeNode = Nothing
            Dim Level_Two As TreeNode = Nothing
            Dim twRoot As String = "Meal Plan For  " & Label7.Text
            Root_Level = TV4.Nodes.Add(twRoot)
            ' Adding Breakfast items
            SQLConn1.Open()
            SQLcmd1 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Breakfast' AND MyDate = '" & Label7.Text & "'", SQLConn1)
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
            SQLcmd2 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Morning Snack' AND MyDate = '" & Label7.Text & "'", SQLConn2)
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
            SQLcmd3 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Lunch' AND MyDate = '" & Label7.Text & "'", SQLConn3)
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
            SQLcmd4 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Afternoon Snack' AND MyDate = '" & Label7.Text & "'", SQLConn4)
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
            SQLcmd5 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Supper' AND MyDate = '" & Label7.Text & "'", SQLConn5)
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
            SQLcmd6 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Evening Snack' AND MyDate = '" & Label7.Text & "'", SQLConn6)
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
        TV4.ExpandAll()
    End Sub
    Public Sub LoadNode5()
        Dim recordcount As Integer = 0
        Dim recordcount2 As Integer = 0
        TV5.Nodes.Clear()

        Try

            'Dim MyNode As String
            Dim Root_Level As TreeNode = Nothing
            Dim Level_One As TreeNode = Nothing
            Dim Level_Two As TreeNode = Nothing
            Dim twRoot As String = "Meal Plan For  " & Label8.Text
            Root_Level = TV5.Nodes.Add(twRoot)
            ' Adding Breakfast items
            SQLConn1.Open()
            SQLcmd1 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Breakfast' AND MyDate = '" & Label8.Text & "'", SQLConn1)
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
            SQLcmd2 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Morning Snack' AND MyDate = '" & Label8.Text & "'", SQLConn2)
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
            SQLcmd3 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Lunch' AND MyDate = '" & Label8.Text & "'", SQLConn3)
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
            SQLcmd4 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Afternoon Snack' AND MyDate = '" & Label8.Text & "'", SQLConn4)
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
            SQLcmd5 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Supper' AND MyDate = '" & Label8.Text & "'", SQLConn5)
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
            SQLcmd6 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Evening Snack' AND MyDate = '" & Label8.Text & "'", SQLConn6)
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
        TV5.ExpandAll()
    End Sub
    Public Sub LoadNode6()
        Dim recordcount As Integer = 0
        Dim recordcount2 As Integer = 0
        TV6.Nodes.Clear()

        Try

            'Dim MyNode As String
            Dim Root_Level As TreeNode = Nothing
            Dim Level_One As TreeNode = Nothing
            Dim Level_Two As TreeNode = Nothing
            Dim twRoot As String = "Meal Plan For  " & Label9.Text
            Root_Level = TV6.Nodes.Add(twRoot)
            ' Adding Breakfast items
            SQLConn1.Open()
            SQLcmd1 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Breakfast' AND MyDate = '" & Label9.Text & "'", SQLConn1)
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
            SQLcmd2 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Morning Snack' AND MyDate = '" & Label9.Text & "'", SQLConn2)
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
            SQLcmd3 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Lunch' AND MyDate = '" & Label9.Text & "'", SQLConn3)
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
            SQLcmd4 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Afternoon Snack' AND MyDate = '" & Label9.Text & "'", SQLConn4)
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
            SQLcmd5 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Supper' AND MyDate = '" & Label9.Text & "'", SQLConn5)
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
            SQLcmd6 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Evening Snack' AND MyDate = '" & Label9.Text & "'", SQLConn6)
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
        TV6.ExpandAll()
    End Sub
    Public Sub LoadNode7()
        Dim recordcount As Integer = 0
        Dim recordcount2 As Integer = 0
        TV7.Nodes.Clear()

        Try

            'Dim MyNode As String
            Dim Root_Level As TreeNode = Nothing
            Dim Level_One As TreeNode = Nothing
            Dim Level_Two As TreeNode = Nothing
            Dim twRoot As String = "Meal Plan For  " & Label10.Text
            Root_Level = TV7.Nodes.Add(twRoot)
            ' Adding Breakfast items
            SQLConn1.Open()
            SQLcmd1 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Breakfast' AND MyDate = '" & Label10.Text & "'", SQLConn1)
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
            SQLcmd2 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Morning Snack' AND MyDate = '" & Label10.Text & "'", SQLConn2)
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
            SQLcmd3 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Lunch' AND MyDate = '" & Label10.Text & "'", SQLConn3)
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
            SQLcmd4 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Afternoon Snack' AND MyDate = '" & Label10.Text & "'", SQLConn4)
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
            SQLcmd5 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Supper' AND MyDate = '" & Label10.Text & "'", SQLConn5)
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
            SQLcmd6 = New SqlCommand("Select recipeid, recipeName From MealPlan WHERE Meal = 'Evening Snack' AND MyDate = '" & Label10.Text & "'", SQLConn6)
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
        TV7.ExpandAll()
    End Sub
    Private Sub Daysofweek()

        Select Case Label1.Text
            Case 0
                Label11.Text = Format(DateAdd(DateInterval.Day, -1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label4.Text = Format(DateTimePicker1.Value, ("M/d/yyyy"))
                Label5.Text = Format(DateAdd(DateInterval.Day, 1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label6.Text = Format(DateAdd(DateInterval.Day, 2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label7.Text = Format(DateAdd(DateInterval.Day, 3, DateTimePicker1.Value), ("M/d/yyyy"))
                Label8.Text = Format(DateAdd(DateInterval.Day, 4, DateTimePicker1.Value), ("M/d/yyyy"))
                Label9.Text = Format(DateAdd(DateInterval.Day, 5, DateTimePicker1.Value), ("M/d/yyyy"))
                Label10.Text = Format(DateAdd(DateInterval.Day, 6, DateTimePicker1.Value), ("M/d/yyyy"))
                Label12.Text = Format(DateAdd(DateInterval.Day, 7, DateTimePicker1.Value), ("M/d/yyyy"))
            Case 1
                Label11.Text = Format(DateAdd(DateInterval.Day, -2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label4.Text = Format(DateAdd(DateInterval.Day, -1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label5.Text = Format(DateTimePicker1.Value, ("M/d/yyyy"))
                Label6.Text = Format(DateAdd(DateInterval.Day, 1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label7.Text = Format(DateAdd(DateInterval.Day, 2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label8.Text = Format(DateAdd(DateInterval.Day, 3, DateTimePicker1.Value), ("M/d/yyyy"))
                Label9.Text = Format(DateAdd(DateInterval.Day, 4, DateTimePicker1.Value), ("M/d/yyyy"))
                Label10.Text = Format(DateAdd(DateInterval.Day, 5, DateTimePicker1.Value), ("M/d/yyyy"))
                Label12.Text = Format(DateAdd(DateInterval.Day, 6, DateTimePicker1.Value), ("M/d/yyyy"))
            Case 2
                Label11.Text = Format(DateAdd(DateInterval.Day, -3, DateTimePicker1.Value), ("M/d/yyyy"))
                Label4.Text = Format(DateAdd(DateInterval.Day, -2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label5.Text = Format(DateAdd(DateInterval.Day, -1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label6.Text = Format(DateTimePicker1.Value, ("M/d/yyyy"))
                Label7.Text = Format(DateAdd(DateInterval.Day, 1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label8.Text = Format(DateAdd(DateInterval.Day, 2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label9.Text = Format(DateAdd(DateInterval.Day, 3, DateTimePicker1.Value), ("M/d/yyyy"))
                Label10.Text = Format(DateAdd(DateInterval.Day, 4, DateTimePicker1.Value), ("M/d/yyyy"))
                Label12.Text = Format(DateAdd(DateInterval.Day, 5, DateTimePicker1.Value), ("M/d/yyyy"))
            Case 3
                Label11.Text = Format(DateAdd(DateInterval.Day, -4, DateTimePicker1.Value), ("M/d/yyyy"))
                Label4.Text = Format(DateAdd(DateInterval.Day, -3, DateTimePicker1.Value), ("M/d/yyyy"))
                Label5.Text = Format(DateAdd(DateInterval.Day, -2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label6.Text = Format(DateAdd(DateInterval.Day, -1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label7.Text = Format(DateTimePicker1.Value, ("M/d/yyyy"))
                Label8.Text = Format(DateAdd(DateInterval.Day, 1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label9.Text = Format(DateAdd(DateInterval.Day, 2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label10.Text = Format(DateAdd(DateInterval.Day, 3, DateTimePicker1.Value), ("M/d/yyyy"))
                Label12.Text = Format(DateAdd(DateInterval.Day, 4, DateTimePicker1.Value), ("M/d/yyyy"))
            Case 4
                Label11.Text = Format(DateAdd(DateInterval.Day, -5, DateTimePicker1.Value), ("M/d/yyyy"))
                Label4.Text = Format(DateAdd(DateInterval.Day, -4, DateTimePicker1.Value), ("M/d/yyyy"))
                Label5.Text = Format(DateAdd(DateInterval.Day, -3, DateTimePicker1.Value), ("M/d/yyyy"))
                Label6.Text = Format(DateAdd(DateInterval.Day, -2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label7.Text = Format(DateAdd(DateInterval.Day, -1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label8.Text = Format(DateTimePicker1.Value, ("M/d/yyyy"))
                Label9.Text = Format(DateAdd(DateInterval.Day, 1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label10.Text = Format(DateAdd(DateInterval.Day, 2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label12.Text = Format(DateAdd(DateInterval.Day, 3, DateTimePicker1.Value), ("M/d/yyyy"))
            Case 5
                Label11.Text = Format(DateAdd(DateInterval.Day, -6, DateTimePicker1.Value), ("M/d/yyyy"))
                Label4.Text = Format(DateAdd(DateInterval.Day, -5, DateTimePicker1.Value), ("M/d/yyyy"))
                Label5.Text = Format(DateAdd(DateInterval.Day, -4, DateTimePicker1.Value), ("M/d/yyyy"))
                Label6.Text = Format(DateAdd(DateInterval.Day, -3, DateTimePicker1.Value), ("M/d/yyyy"))
                Label7.Text = Format(DateAdd(DateInterval.Day, -2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label8.Text = Format(DateAdd(DateInterval.Day, -1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label9.Text = Format(DateTimePicker1.Value, ("M/d/yyyy"))
                Label10.Text = Format(DateAdd(DateInterval.Day, 1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label12.Text = Format(DateAdd(DateInterval.Day, 2, DateTimePicker1.Value), ("M/d/yyyy"))
            Case 6
                Label11.Text = Format(DateAdd(DateInterval.Day, -7, DateTimePicker1.Value), ("M/d/yyyy"))
                Label4.Text = Format(DateAdd(DateInterval.Day, -6, DateTimePicker1.Value), ("M/d/yyyy"))
                Label5.Text = Format(DateAdd(DateInterval.Day, -5, DateTimePicker1.Value), ("M/d/yyyy"))
                Label6.Text = Format(DateAdd(DateInterval.Day, -4, DateTimePicker1.Value), ("M/d/yyyy"))
                Label7.Text = Format(DateAdd(DateInterval.Day, -3, DateTimePicker1.Value), ("M/d/yyyy"))
                Label8.Text = Format(DateAdd(DateInterval.Day, -2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label9.Text = Format(DateAdd(DateInterval.Day, -1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label10.Text = Format(DateTimePicker1.Value, ("M/d/yyyy"))
                Label12.Text = Format(DateAdd(DateInterval.Day, 1, DateTimePicker1.Value), ("M/d/yyyy"))
        End Select
        TabControl1.SelectedIndex = Label1.Text
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Dim Dayofweek As Integer
        Dim MyDate As Date
        MyDate = DateTimePicker1.Text
        Dayofweek = MyDate.DayOfWeek
        Label1.Text = Dayofweek
        Daysofweek()
        LoadNode1()
        LoadNode2()
        LoadNode3()
        LoadNode4()
        LoadNode5()
        LoadNode6()
        LoadNode7()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Timer1.Enabled = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MealPlan.Show()
        MealPlan.Label1.Text = Label11.Text
        MealPlan.Label2.Text = Label12.Text
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()
        FillList()
        GetIngredients()
        LoadGrocList()
    End Sub
    Private Sub GetIngredients()
        Dim X As Integer
        Dim MyRecid As String
        Dim recordcount As Integer = 0
        Dim Ingred1 As String
        Dim Ingred2 As String
        Dim Ingred3 As String

        For X = 0 To ListBox1.Items.Count - 1
            MyRecid = ListBox1.Items(X)
            '=========================
            Try

                SQLConn1.Open()
                SQLcmd1 = New SqlCommand("Select recipeid, quantitytext, unittext, ingredienttext From recipeingredient WHERE recipeid = '" & ListBox1.Items(X) & "'", SQLConn1)
                Dim SQLDS1 As New DataSet
                Dim SQLDA1 As New SqlDataAdapter(SQLcmd1)
                recordcount = SQLDA1.Fill(SQLDS1)
                DGV1.ColumnCount = 3
                DGV1.Columns(0).Width = "70"
                DGV1.Columns(1).Width = "50"
                DGV1.Columns(2).Width = "250"
                DGV1.Columns(0).Name = "Quantity"        'quantitytext
                DGV1.Columns(1).Name = "Units"           'unittext
                DGV1.Columns(2).Name = "Ingredients"     'ingredienttext
                If recordcount > 0 Then
                    Dim Q As Integer
                    For Q = 0 To recordcount - 1

                        If IsDBNull(SQLDS1.Tables(0).Rows(Q).Item(1).ToString) Or SQLDS1.Tables(0).Rows(Q).Item(1).ToString = "" Then
                            Ingred1 = ""
                        Else
                            Ingred1 = SQLDS1.Tables(0).Rows(Q).Item(1)
                        End If
                        If IsDBNull(SQLDS1.Tables(0).Rows(Q).Item(2).ToString) Or SQLDS1.Tables(0).Rows(Q).Item(2).ToString = "" Then
                            Ingred2 = ""
                        Else
                            Ingred2 = SQLDS1.Tables(0).Rows(Q).Item(2)
                        End If
                        If IsDBNull(SQLDS1.Tables(0).Rows(Q).Item(3).ToString) Or SQLDS1.Tables(0).Rows(Q).Item(3).ToString = "" Then
                            Ingred3 = ""
                        Else
                            Ingred3 = SQLDS1.Tables(0).Rows(Q).Item(3)
                        End If


                        Dim row As String() = New String() {(Ingred1), (Ingred2), (Ingred3)}
                        DGV1.Rows.Add(row)

                    Next


                End If
                SQLConn1.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If SQLConn1.State = ConnectionState.Open Then SQLConn1.Close()
            End Try
            '=========================
        Next
    End Sub
    Private Sub RecurseNodes(ByVal col As TreeNodeCollection)
        Dim MyRep() As String
        For Each tn As TreeNode In col
            MyRep = Split(tn.Text, " ")

            If tn.Nodes.Count >= 0 Then
                If IsNumeric(MyRep(0)) Then
                    ListBox1.Items.Add(MyRep(0))
                End If
                RecurseNodes(tn.Nodes)
            End If
        Next tn
    End Sub

    Private Sub FillList()
        DGV1.Rows.Clear()
        RecurseNodes(TV1.Nodes)
        RecurseNodes(TV2.Nodes)
        RecurseNodes(TV3.Nodes)
        RecurseNodes(TV4.Nodes)
        RecurseNodes(TV5.Nodes)
        RecurseNodes(TV6.Nodes)
    End Sub
    Private Sub LoadGrocList()

        Try     ' Getting the tasks for (X) WO's
            SQLConn.Open()
            SQLcmd = New SqlCommand("DELETE From ShoppingList", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            SQLDA.Fill(SQLDS, "WOTasks")
            SQLConn.Close()

            '   writing new or newly ordered datagridview items to sql
            Dim MyName As String
            Dim MyUnit As String
            Dim MyCount As String
            If DGV1.RowCount > 1 Then
                For i As Integer = 0 To DGV1.Rows.Count - 1 'was -2
                    MyName = DGV1.Rows(i).Cells(2).Value
                    MyUnit = DGV1.Rows(i).Cells(1).Value
                    MyCount = DGV1.Rows(i).Cells(0).Value
                    '=================
                    Dim recordcount As Integer
                    SQLConn.Open()
                    SQLcmd = New SqlCommand("Select ingredname From ShoppingList WHERE [ingredname] = '" & MyName & "'", SQLConn)
                    Dim SQLDS1 As New DataSet
                    Dim SQLDA1 As New SqlDataAdapter(SQLcmd)
                    recordcount = SQLDA1.Fill(SQLDS1)
                    SQLConn.Close()

                    If recordcount = 0 Then
                        SQLConn.Open()
                        SQLcmd.CommandText = "INSERT INTO ShoppingList ([ingredname],[Units], [qty]) Values('" & MyName & "', '" & MyUnit & "', '" & MyCount & "')"
                        SQLcmd.ExecuteNonQuery()
                        SQLConn.Close()
                    Else
                        SQLConn.Open()
                        SQLcmd = New SqlCommand("Select ingredname,Units, qty From ShoppingList WHERE [ingredname] = '" & MyName & "'", SQLConn)
                        Dim SQLDS2 As New DataSet
                        Dim SQLDA2 As New SqlDataAdapter(SQLcmd)
                        recordcount = SQLDA2.Fill(SQLDS2)
                        MyUnit = DGV1.Rows(i).Cells(1).Value
                        MyCount = DGV1.Rows(i).Cells(0).Value
                        MyCount = MyCount + SQLDS2.Tables(0).Rows(0).Item(2)
                        '------------
                        SQLDA2.Fill(SQLDS2, "tblWO")
                        SQLDS2.Tables(0).Rows(0).Item(2) = MyCount ' Updating qty
                        SQLDA2.Update(SQLDS2, "tblWO")
                        '---------------
                        SQLConn.Close()

                    End If



                    '==================

                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub
End Class