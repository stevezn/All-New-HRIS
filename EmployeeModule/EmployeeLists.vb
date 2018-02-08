Imports ConnectionString
Public Class EmployeeLists
    Public connection As Connectors

    Private Sub EmployeeLists_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection.initiation("", "", "", "", "")
        connection.OpenCon()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click

    End Sub
End Class
