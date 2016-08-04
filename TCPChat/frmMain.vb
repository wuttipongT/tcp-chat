

Public Class frmApp
    Private Sub SetTimeGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetTimeGetData.Click
        Dim frm As New frmPickToLight
        frm.ShowDialog()
    End Sub

    Private Sub frmApp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim appSet As New Configuration.AppSettingsReader()
        WMS_STD_Formula.W_Module.WV_ConnectionString = appSet.GetValue("ConnectionString", GetType(String))
    End Sub
End Class
