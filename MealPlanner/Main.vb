
Public Class Main
    Dim MyWidth As Integer = 1350
    Dim MyWidth2 As Integer = 815
    Dim MyHeight As Integer = 50
    Dim MyHeight2 As Integer = 619
    Dim MyLeft As Integer = 350

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmTop.MdiParent = Me
        frmTop.Show()
        frmTop.Size = New Size(MyWidth, MyHeight)

        frmLeft.MdiParent = Me
        frmLeft.Show()
        frmLeft.Location = New Point(0, MyHeight)
        frmLeft.Size = New Size(MyLeft, MyHeight2)
        frmLeft.TV1.Size = New Size(MyLeft, MyHeight2 - 20)

        frmRight.MdiParent = Me
        frmRight.Show()
        frmRight.Location = New Point(0 + MyLeft, MyHeight)
        frmRight.Size = New Size(MyWidth - MyLeft, MyHeight2)
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Recipes1.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmLeft.LoadNode1()
    End Sub
End Class
