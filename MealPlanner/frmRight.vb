﻿Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class frmRight
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand
    Private Sub TabControl_DrawItem(sender As Object, e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem

        '  Identify which TabPage is currently selected
        Dim SelectedTab As TabPage = TabControl1.TabPages(e.Index)

        '  Get the area of the header of this TabPage
        Dim HeaderRect As Rectangle = TabControl1.GetTabRect(e.Index)

        '  Create two Brushes to paint the Text
        Dim BlackTextBrush As New SolidBrush(Color.Black)
        Dim RedTextBrush As New SolidBrush(Color.Red)

        '  Set the Alignment of the Text
        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        '  Paint the Text using the appropriate Bold and Color settings
        If Convert.ToBoolean(e.State And DrawItemState.Selected) Then

            Dim BiggerBoldFont As New Font(TabControl1.Font.Name, 10, FontStyle.Bold)
            e.Graphics.DrawString(SelectedTab.Text, BiggerBoldFont, RedTextBrush, HeaderRect, sf)
        Else
            e.Graphics.DrawString(SelectedTab.Text, e.Font, BlackTextBrush, HeaderRect, sf)
        End If


        '  Job done - dispose of the Brushes
        BlackTextBrush.Dispose()
        RedTextBrush.Dispose()

    End Sub
    Public Sub frmRight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLstr = "Data Source=Server1;Initial Catalog=SimpleRecipeDB;Persist Security Info=True;User ID=sa;Password=F1ll3R01"
        SQLConn.ConnectionString = SQLstr
        DGV1.Font = New Font("Arial", 11, FontStyle.Bold)
        DGV2.Font = New Font("Arial", 12, FontStyle.Bold)
    End Sub

    Public Sub LoadIngredients()
        Dim recordcount As Integer = 0

        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select quantitytext as Qty, unittext as Unit, ingredienttext as Ingredient From recipeingredient Where recipeid = '" & Label2.Text & "'", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            recordcount = SQLDA.Fill(SQLDS)

            If recordcount = 0 Then
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
                DGV1.DataSource = Nothing
                Exit Sub
            Else

                DGV1.DataSource = SQLDS.Tables(0)
                DGV1.Refresh()
                DGV1.Columns(0).Width = 60
                DGV1.Columns(1).Width = 60
                DGV1.Columns(2).Width = 680
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub
    Public Sub LoadSteps()
        Dim recordcount As Integer = 0

        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select proceduretext as Steps From recipeprocedure Where recipeid = '" & Label2.Text & "' ORDER BY procedureindex", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            recordcount = SQLDA.Fill(SQLDS)

            If recordcount = 0 Then
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
                DGV2.DataSource = Nothing
                Exit Sub
            Else

                DGV2.DataSource = SQLDS.Tables(0)
                DGV2.Refresh()
                DGV2.Columns(0).Width = 900

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        LoadRecipe()
        If Label2.Text <> "" And Label2.Text <> "0" Then
            LoadIngredients()
            LoadSteps()
            'LoadPic()
            Button1.Enabled = True
        Else
            ClearRecipe()
            Button1.Enabled = False
        End If
    End Sub
    Public Sub LoadPic()
        Dim recordcount As Integer = 0
        Dim ImageId As Integer

        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select recipeid From Recipe Where recipename = '" & frmTop.Label1.Text & "'", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            recordcount = SQLDA.Fill(SQLDS)

            If recordcount = 0 Then
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
                PictureBox1.Image = Image.FromFile("C:\ProgramData\MealPlanner\StandardPic.jpg")

                Exit Sub
            Else
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(0).ToString) Or SQLDS.Tables(0).Rows(0).Item(0).ToString = "" Then
                    PictureBox1.Image = Image.FromFile("C:\ProgramData\MealPlanner\StandardPic.jpg")
                Else
                    ImageId = SQLDS.Tables(0).Rows(0).Item(0)
                    If System.IO.File.Exists("\\SERVER1\Public\Radium Technologies\Living Cookbook\5.0\Images\" & ImageId & ".jpg") Then
                        PictureBox1.ImageLocation = "\\SERVER1\Public\Radium Technologies\Living Cookbook\5.0\Images\" & ImageId & ".jpg"
                        'PictureBox1.Image = Image.FromFile("\\SERVER1\Public\Radium Technologies\Living Cookbook\5.0\Images\" & ImageId & ".jpg")
                    Else
                        PictureBox1.Image = Image.FromFile("C:\ProgramData\MealPlanner\StandardPic.jpg")
                    End If
                End If



            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Steps.Show()
        Steps.Label1.Text = Label2.Text
        Steps.Timer1.Enabled = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If Label2.Text = "" Then
            MsgBox("No recipe loaded yet", vbOKOnly)
            Exit Sub
        Else
            EditIngredients.Show()
            EditIngredients.Label1.Text = Label2.Text
            EditIngredients.Timer1.Enabled = True
        End If

    End Sub


    Public Sub LoadRecipe()
        Dim recordcount As Integer = 0

        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select * From Recipe Where recipename = '" & frmTop.Label1.Text & "'", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            recordcount = SQLDA.Fill(SQLDS)

            If recordcount = 0 Then
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
                ClearRecipe()
                Exit Sub
            Else
                Label2.Text = SQLDS.Tables(0).Rows(0).Item(0)
                TextBox2.Text = SQLDS.Tables(0).Rows(0).Item(1)
                'Dim foo As String = If(IsDBNull(SQLDS.Tables(0).Rows(0).Item(2).ToString)), "0", SQLDS.Tables(0).Rows(0).Item(2).ToString)
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(2).ToString) Or SQLDS.Tables(0).Rows(0).Item(2).ToString = "" Then
                Else
                    Label6.Text = SQLDS.Tables(0).Rows(0).Item(2)
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(3).ToString) Or SQLDS.Tables(0).Rows(0).Item(3).ToString = "" Then
                    Else
                        Label7.Text = SQLDS.Tables(0).Rows(0).Item(3)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(4).ToString) Or SQLDS.Tables(0).Rows(0).Item(4).ToString = "" Then
                    Else
                        Label9.Text = SQLDS.Tables(0).Rows(0).Item(4)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(33).ToString) Or SQLDS.Tables(0).Rows(0).Item(33).ToString = "" Then
                    Else
                        Label19.Text = SQLDS.Tables(0).Rows(0).Item(33)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(109).ToString) Or SQLDS.Tables(0).Rows(0).Item(109).ToString = "" Then
                        Label45.Visible = False
                        Label46.Visible = False
                    Else
                        Label45.Visible = True
                        Label46.Visible = True
                        Label45.Text = SQLDS.Tables(0).Rows(0).Item(109)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(206).ToString) Or SQLDS.Tables(0).Rows(0).Item(206).ToString = "" Then
                    Else
                        TextBox1.Text = SQLDS.Tables(0).Rows(0).Item(206)
                    End If '****************************** Starts the nutrition
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(18).ToString) Or SQLDS.Tables(0).Rows(0).Item(18).ToString = "" Then
                        Label11.Text = ""
                    Else
                        Label11.Text = SQLDS.Tables(0).Rows(0).Item(18)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(26).ToString) Or SQLDS.Tables(0).Rows(0).Item(26).ToString = "" Then
                        Label13.Text = ""
                    Else
                        Label13.Text = SQLDS.Tables(0).Rows(0).Item(26)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(31).ToString) Or SQLDS.Tables(0).Rows(0).Item(31).ToString = "" Then
                        Label15.Text = ""
                    Else
                        Label15.Text = SQLDS.Tables(0).Rows(0).Item(31)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(32).ToString) Or SQLDS.Tables(0).Rows(0).Item(32).ToString = "" Then
                        Label17.Text = ""
                    Else
                        Label17.Text = SQLDS.Tables(0).Rows(0).Item(32)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(41).ToString) Or SQLDS.Tables(0).Rows(0).Item(41).ToString = "" Then
                        Label27.Text = ""
                    Else
                        Label27.Text = SQLDS.Tables(0).Rows(0).Item(41)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(43).ToString) Or SQLDS.Tables(0).Rows(0).Item(43).ToString = "" Then
                        Label25.Text = ""
                    Else
                        Label25.Text = SQLDS.Tables(0).Rows(0).Item(43)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(62).ToString) Or SQLDS.Tables(0).Rows(0).Item(62).ToString = "" Then
                        Label23.Text = ""
                    Else
                        Label23.Text = SQLDS.Tables(0).Rows(0).Item(62)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(65).ToString) Or SQLDS.Tables(0).Rows(0).Item(65).ToString = "" Then
                        Label21.Text = ""
                    Else
                        Label21.Text = SQLDS.Tables(0).Rows(0).Item(65)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(66).ToString) Or SQLDS.Tables(0).Rows(0).Item(66).ToString = "" Then
                        Label43.Text = ""
                    Else
                        Label43.Text = SQLDS.Tables(0).Rows(0).Item(66)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(79).ToString) Or SQLDS.Tables(0).Rows(0).Item(79).ToString = "" Then
                        Label41.Text = ""
                    Else
                        Label41.Text = SQLDS.Tables(0).Rows(0).Item(79)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(86).ToString) Or SQLDS.Tables(0).Rows(0).Item(86).ToString = "" Then
                        Label39.Text = ""
                    Else
                        Label39.Text = SQLDS.Tables(0).Rows(0).Item(86)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(87).ToString) Or SQLDS.Tables(0).Rows(0).Item(87).ToString = "" Then
                        Label85.Text = ""
                    Else
                        Label85.Text = SQLDS.Tables(0).Rows(0).Item(87)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(104).ToString) Or SQLDS.Tables(0).Rows(0).Item(104).ToString = "" Then
                        Label83.Text = ""
                    Else
                        Label83.Text = SQLDS.Tables(0).Rows(0).Item(104)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(106).ToString) Or SQLDS.Tables(0).Rows(0).Item(106).ToString = "" Then
                        Label81.Text = ""
                    Else
                        Label81.Text = SQLDS.Tables(0).Rows(0).Item(106)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(126).ToString) Or SQLDS.Tables(0).Rows(0).Item(126).ToString = "" Then
                        Label79.Text = ""
                    Else
                        Label79.Text = SQLDS.Tables(0).Rows(0).Item(126)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(128).ToString) Or SQLDS.Tables(0).Rows(0).Item(128).ToString = "" Then
                        Label77.Text = ""
                    Else
                        Label77.Text = SQLDS.Tables(0).Rows(0).Item(128)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(131).ToString) Or SQLDS.Tables(0).Rows(0).Item(131).ToString = "" Then
                        Label75.Text = ""
                    Else
                        Label75.Text = SQLDS.Tables(0).Rows(0).Item(131)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(132).ToString) Or SQLDS.Tables(0).Rows(0).Item(132).ToString = "" Then
                        Label73.Text = ""
                    Else
                        Label73.Text = SQLDS.Tables(0).Rows(0).Item(132)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(133).ToString) Or SQLDS.Tables(0).Rows(0).Item(133).ToString = "" Then
                        Label71.Text = ""
                    Else
                        Label71.Text = SQLDS.Tables(0).Rows(0).Item(133)
                    End If ' saturatedfat
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(148).ToString) Or SQLDS.Tables(0).Rows(0).Item(148).ToString = "" Then
                        Label69.Text = ""
                    Else
                        Label69.Text = SQLDS.Tables(0).Rows(0).Item(148)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(149).ToString) Or SQLDS.Tables(0).Rows(0).Item(149).ToString = "" Then
                        Label67.Text = ""
                    Else
                        Label67.Text = SQLDS.Tables(0).Rows(0).Item(149)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(151).ToString) Or SQLDS.Tables(0).Rows(0).Item(151).ToString = "" Then
                        Label65.Text = ""
                    Else
                        Label65.Text = SQLDS.Tables(0).Rows(0).Item(151)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(153).ToString) Or SQLDS.Tables(0).Rows(0).Item(153).ToString = "" Then
                        Label63.Text = ""
                    Else
                        Label63.Text = SQLDS.Tables(0).Rows(0).Item(153)
                    End If  ' starch
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(155).ToString) Or SQLDS.Tables(0).Rows(0).Item(155).ToString = "" Then
                        Label61.Text = ""
                    Else
                        Label61.Text = SQLDS.Tables(0).Rows(0).Item(155)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(156).ToString) Or SQLDS.Tables(0).Rows(0).Item(156).ToString = "" Then
                        Label59.Text = ""
                    Else
                        Label59.Text = SQLDS.Tables(0).Rows(0).Item(156)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(158).ToString) Or SQLDS.Tables(0).Rows(0).Item(158).ToString = "" Then
                        Label57.Text = ""
                    Else
                        Label57.Text = SQLDS.Tables(0).Rows(0).Item(158)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(159).ToString) Or SQLDS.Tables(0).Rows(0).Item(159).ToString = "" Then
                        Label55.Text = ""
                    Else
                        Label55.Text = SQLDS.Tables(0).Rows(0).Item(159)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(160).ToString) Or SQLDS.Tables(0).Rows(0).Item(160).ToString = "" Then
                        Label53.Text = ""
                    Else
                        Label53.Text = SQLDS.Tables(0).Rows(0).Item(160)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(161).ToString) Or SQLDS.Tables(0).Rows(0).Item(161).ToString = "" Then
                        Label51.Text = ""
                    Else
                        Label51.Text = SQLDS.Tables(0).Rows(0).Item(161)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(162).ToString) Or SQLDS.Tables(0).Rows(0).Item(162).ToString = "" Then
                        Label121.Text = ""
                    Else
                        Label121.Text = SQLDS.Tables(0).Rows(0).Item(162)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(163).ToString) Or SQLDS.Tables(0).Rows(0).Item(163).ToString = "" Then
                        Label119.Text = ""
                    Else
                        Label119.Text = SQLDS.Tables(0).Rows(0).Item(163)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(166).ToString) Or SQLDS.Tables(0).Rows(0).Item(166).ToString = "" Then
                        Label117.Text = ""
                    Else
                        Label117.Text = SQLDS.Tables(0).Rows(0).Item(166)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(167).ToString) Or SQLDS.Tables(0).Rows(0).Item(167).ToString = "" Then
                        Label115.Text = ""
                    Else
                        Label115.Text = SQLDS.Tables(0).Rows(0).Item(167)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(168).ToString) Or SQLDS.Tables(0).Rows(0).Item(168).ToString = "" Then
                        Label113.Text = ""
                    Else
                        Label113.Text = SQLDS.Tables(0).Rows(0).Item(168)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(169).ToString) Or SQLDS.Tables(0).Rows(0).Item(169).ToString = "" Then
                        Label157.Text = ""
                    Else
                        Label157.Text = SQLDS.Tables(0).Rows(0).Item(169)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(170).ToString) Or SQLDS.Tables(0).Rows(0).Item(170).ToString = "" Then
                        Label153.Text = ""
                    Else
                        Label153.Text = SQLDS.Tables(0).Rows(0).Item(170)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(171).ToString) Or SQLDS.Tables(0).Rows(0).Item(171).ToString = "" Then
                        Label155.Text = ""
                    Else
                        Label155.Text = SQLDS.Tables(0).Rows(0).Item(171)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(172).ToString) Or SQLDS.Tables(0).Rows(0).Item(172).ToString = "" Then
                        Label151.Text = ""
                    Else
                        Label151.Text = SQLDS.Tables(0).Rows(0).Item(172)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(173).ToString) Or SQLDS.Tables(0).Rows(0).Item(173).ToString = "" Then
                        Label149.Text = ""
                    Else
                        Label149.Text = SQLDS.Tables(0).Rows(0).Item(173)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(174).ToString) Or SQLDS.Tables(0).Rows(0).Item(174).ToString = "" Then
                        Label147.Text = ""
                    Else
                        Label147.Text = SQLDS.Tables(0).Rows(0).Item(174)
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(175).ToString) Or SQLDS.Tables(0).Rows(0).Item(175).ToString = "" Then
                        Label145.Text = ""
                    Else
                        Label145.Text = SQLDS.Tables(0).Rows(0).Item(175)
                    End If

                End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub
    Public Sub ClearRecipe()
        Label2.Text = "0"
        TextBox2.Text = ""
        Label6.Text = ""
        Label7.Text = ""
        Label9.Text = ""
        Label19.Text = ""
        Label45.Visible = False
        Label46.Visible = False
        Label45.Text = ""
        Label11.Text = ""
        Label13.Text = ""
        Label15.Text = ""
        Label17.Text = ""
        Label27.Text = ""
        Label25.Text = ""
        Label23.Text = ""
        Label21.Text = ""
        Label43.Text = ""
        Label41.Text = ""
        Label39.Text = ""
        Label85.Text = ""
        Label83.Text = ""
        Label81.Text = ""
        Label79.Text = ""
        Label77.Text = ""
        Label75.Text = ""
        Label73.Text = ""
        Label71.Text = ""
        Label69.Text = ""
        Label67.Text = ""
        Label65.Text = ""
        Label63.Text = ""
        Label61.Text = ""
        Label59.Text = ""
        Label57.Text = ""
        Label55.Text = ""
        Label53.Text = ""
        Label51.Text = ""
        Label121.Text = ""
        Label119.Text = ""
        Label117.Text = ""
        Label115.Text = ""
        Label113.Text = ""
        Label157.Text = ""
        Label153.Text = ""
        Label155.Text = ""
        Label151.Text = ""
        Label149.Text = ""
        Label147.Text = ""
        Label145.Text = ""
    End Sub
End Class