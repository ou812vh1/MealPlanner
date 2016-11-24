Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class MPlanWeek
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()

    End Sub

    Private Sub MPlanWeek_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Day(7) As Integer

    End Sub
    Private Sub Daysofweek()

        Select Case Label1.Text
            Case 0
                Label4.Text = Format(DateTimePicker1.Value, ("M/d/yyyy"))
                Label5.Text = Format(DateAdd(DateInterval.Day, 1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label6.Text = Format(DateAdd(DateInterval.Day, 2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label7.Text = Format(DateAdd(DateInterval.Day, 3, DateTimePicker1.Value), ("M/d/yyyy"))
                Label8.Text = Format(DateAdd(DateInterval.Day, 4, DateTimePicker1.Value), ("M/d/yyyy"))
                Label9.Text = Format(DateAdd(DateInterval.Day, 5, DateTimePicker1.Value), ("M/d/yyyy"))
                Label10.Text = Format(DateAdd(DateInterval.Day, 6, DateTimePicker1.Value), ("M/d/yyyy"))
            Case 1
                Label4.Text = Format(DateAdd(DateInterval.Day, -1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label5.Text = Format(DateTimePicker1.Value, ("M/d/yyyy"))
                Label6.Text = Format(DateAdd(DateInterval.Day, 1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label7.Text = Format(DateAdd(DateInterval.Day, 2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label8.Text = Format(DateAdd(DateInterval.Day, 3, DateTimePicker1.Value), ("M/d/yyyy"))
                Label9.Text = Format(DateAdd(DateInterval.Day, 4, DateTimePicker1.Value), ("M/d/yyyy"))
                Label10.Text = Format(DateAdd(DateInterval.Day, 5, DateTimePicker1.Value), ("M/d/yyyy"))
            Case 2
                Label4.Text = Format(DateAdd(DateInterval.Day, -2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label5.Text = Format(DateAdd(DateInterval.Day, -1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label6.Text = Format(DateTimePicker1.Value, ("M/d/yyyy"))
                Label7.Text = Format(DateAdd(DateInterval.Day, 1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label8.Text = Format(DateAdd(DateInterval.Day, 2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label9.Text = Format(DateAdd(DateInterval.Day, 3, DateTimePicker1.Value), ("M/d/yyyy"))
                Label10.Text = Format(DateAdd(DateInterval.Day, 4, DateTimePicker1.Value), ("M/d/yyyy"))
            Case 3
                Label4.Text = Format(DateAdd(DateInterval.Day, -3, DateTimePicker1.Value), ("M/d/yyyy"))
                Label5.Text = Format(DateAdd(DateInterval.Day, -2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label6.Text = Format(DateAdd(DateInterval.Day, -1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label7.Text = Format(DateTimePicker1.Value, ("M/d/yyyy"))
                Label8.Text = Format(DateAdd(DateInterval.Day, 1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label9.Text = Format(DateAdd(DateInterval.Day, 2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label10.Text = Format(DateAdd(DateInterval.Day, 3, DateTimePicker1.Value), ("M/d/yyyy"))
            Case 4
                Label4.Text = Format(DateAdd(DateInterval.Day, -4, DateTimePicker1.Value), ("M/d/yyyy"))
                Label5.Text = Format(DateAdd(DateInterval.Day, -3, DateTimePicker1.Value), ("M/d/yyyy"))
                Label6.Text = Format(DateAdd(DateInterval.Day, -2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label7.Text = Format(DateAdd(DateInterval.Day, -1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label8.Text = Format(DateTimePicker1.Value, ("M/d/yyyy"))
                Label9.Text = Format(DateAdd(DateInterval.Day, 1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label10.Text = Format(DateAdd(DateInterval.Day, 2, DateTimePicker1.Value), ("M/d/yyyy"))
            Case 5
                Label4.Text = Format(DateAdd(DateInterval.Day, -5, DateTimePicker1.Value), ("M/d/yyyy"))
                Label5.Text = Format(DateAdd(DateInterval.Day, -4, DateTimePicker1.Value), ("M/d/yyyy"))
                Label6.Text = Format(DateAdd(DateInterval.Day, -3, DateTimePicker1.Value), ("M/d/yyyy"))
                Label7.Text = Format(DateAdd(DateInterval.Day, -2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label8.Text = Format(DateAdd(DateInterval.Day, -1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label9.Text = Format(DateTimePicker1.Value, ("M/d/yyyy"))
                Label10.Text = Format(DateAdd(DateInterval.Day, 1, DateTimePicker1.Value), ("M/d/yyyy"))
            Case 6
                Label4.Text = Format(DateAdd(DateInterval.Day, -6, DateTimePicker1.Value), ("M/d/yyyy"))
                Label5.Text = Format(DateAdd(DateInterval.Day, -5, DateTimePicker1.Value), ("M/d/yyyy"))
                Label6.Text = Format(DateAdd(DateInterval.Day, -4, DateTimePicker1.Value), ("M/d/yyyy"))
                Label7.Text = Format(DateAdd(DateInterval.Day, -3, DateTimePicker1.Value), ("M/d/yyyy"))
                Label8.Text = Format(DateAdd(DateInterval.Day, -2, DateTimePicker1.Value), ("M/d/yyyy"))
                Label9.Text = Format(DateAdd(DateInterval.Day, -1, DateTimePicker1.Value), ("M/d/yyyy"))
                Label10.Text = Format(DateTimePicker1.Value, ("M/d/yyyy"))
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
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Timer1.Enabled = True

    End Sub
End Class