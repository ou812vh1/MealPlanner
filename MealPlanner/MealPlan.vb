Public Class MealPlan


    Private Sub MealPlan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'WindowState.Maximized = 2
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False

        'TODO: This line of code loads data into the 'DataSet1.MealPlan' table. You can move, or remove it, as needed.
        Me.MealPlanTableAdapter.Fill(Me.DataSet1.MealPlan, Label1.Text, Label2.Text)
        'Me.MealPlanTableAdapter.Fill(Me.DataSet1.MealPlan, textbox21.Text, textbox23.Text)
        'Me.MealPlanTableAdapter.Fill(Me.DataSet1.MealPlan)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class