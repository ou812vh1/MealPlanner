Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class Steps
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand
    Dim cmdBuilder As New SqlCommandBuilder
    Private fromIndex As Integer
    Private dragIndex As Integer
    Private dragRect As Rectangle
    Private Sub Steps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLstr = "Data Source=Server1;Initial Catalog=SimpleRecipeDB;Persist Security Info=True;User ID=sa;Password=F1ll3R01"
        SQLConn.ConnectionString = SQLstr
    End Sub
    Private Sub SaveProcedures()
        Try     ' Getting the tasks for (X) WO's
            SQLConn.Open()
            SQLcmd = New SqlCommand("DELETE From recipeprocedure WHERE recipeid = '" & Label1.Text & "'", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            SQLDA.Fill(SQLDS, "WOTasks")
            SQLConn.Close()

            '   writing new or newly ordered datagridview items to sql
            Dim MyStep As String
            Dim MyStepNO As Integer
            If DataGridView1.RowCount > 1 Then

                For i As Integer = 0 To DataGridView1.Rows.Count - 2 'was -2
                    MyStepNO = i + 1
                    MyStep = DataGridView1.Rows(i).Cells(0).Value
                    SQLConn.Open()
                    SQLcmd.CommandText = "INSERT INTO recipeprocedure ([recipeid],[procedureindex], [proceduretext]) Values('" & Label1.Text & "', '" & MyStepNO & "', '" & MyStep & "')"
                    SQLcmd.ExecuteNonQuery()
                    SQLConn.Close()
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub
    Private Sub Loadprocedures()
        Dim MyWO As String = Label1.Text
        Dim MyCount As Integer
        Dim Recordcount As Integer
        Try

            SQLConn.Open()
            SQLcmd = New SqlCommand("Select proceduretext From recipeprocedure WHERE [recipeid] = '" & Label1.Text & "' ORDER BY procedureindex ASC", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            If SQLConn.State = 1 Then
                MyCount = SQLDA.Fill(SQLDS)
                If Recordcount <> 0 Then
                    If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
                    Exit Sub
                Else
                    Dim Y As Integer = 0
                    Dim X As Integer = 1
                    DataGridView1.ColumnCount = 1
                    DataGridView1.Columns(0).Name = "Recipe Steps"
                    For Each r As DataRow In SQLDS.Tables(0).Rows
                        Dim row As String() = New String() {r("proceduretext")}
                        DataGridView1.Rows.Add(row)
                        'DataGridView1.Rows.Add(X)
                        'DataGridView1.Rows.Insert(r("Task"))
                        X = X + 1
                    Next
                    'DataGridView1.DataSource = SQLDS.Tables(0)
                    'DataGridView1.Refresh()
                    DataGridView1.Columns(0).Width = "800"
                End If
            End If
            SQLConn.Close()
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub
    Private Sub DataGridView1_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles DataGridView1.DragDrop
        Dim p As Point = DataGridView1.PointToClient(New Point(e.X, e.Y))
        dragIndex = DataGridView1.HitTest(p.X, p.Y).RowIndex
        If (e.Effect = DragDropEffects.Move) Then
            Dim dragRow As DataGridViewRow = CType(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)
            If dragIndex < 0 Then dragIndex = DataGridView1.RowCount - 1
            If fromIndex >= DataGridView1.RowCount - 1 Then
                MsgBox("There must be data in the row before trying to drag it")
                Exit Sub 'dragIndex = DataGridView1.RowCount - 1
            End If
            If dragIndex >= DataGridView1.RowCount - 1 Then
                MsgBox("There must be data in the row before dragging a row into it")
                Exit Sub 'dragIndex = DataGridView1.RowCount - 1
            End If
            DataGridView1.Rows.RemoveAt(fromIndex)
            DataGridView1.Rows.Insert(dragIndex, dragRow)
        End If
    End Sub

    Private Sub DataGridView1_DragOver(ByVal sender As Object,
                                   ByVal e As DragEventArgs) _
                                   Handles DataGridView1.DragOver
        e.Effect = DragDropEffects.Move
    End Sub
    Private Sub DataGridView1_MouseDown(ByVal sender As Object,
                                    ByVal e As MouseEventArgs) _
                                    Handles DataGridView1.MouseDown
        fromIndex = DataGridView1.HitTest(e.X, e.Y).RowIndex
        If fromIndex > -1 Then
            Dim dragSize As Size = SystemInformation.DragSize
            dragRect = New Rectangle(New Point(e.X - (dragSize.Width / 2),
                                       e.Y - (dragSize.Height / 2)),
                             dragSize)
        Else
            dragRect = Rectangle.Empty
        End If
    End Sub

    Private Sub DataGridView1_MouseMove(ByVal sender As Object,
                                    ByVal e As MouseEventArgs) _
                                    Handles DataGridView1.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            If (dragRect <> Rectangle.Empty _
    AndAlso Not dragRect.Contains(e.X, e.Y)) Then
                DataGridView1.DoDragDrop(DataGridView1.Rows(fromIndex),
                               DragDropEffects.Move)
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Loadprocedures()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveProcedures()
        frmRight.LoadSteps()
        Me.Close()
    End Sub
End Class