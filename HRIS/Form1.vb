Imports System.IO
Imports System.Reflection

Public Class Form1
    Private Modules As New Dictionary(Of String, List(Of Object))
    Private toUpdate As New Dictionary(Of String, String)
    Private menus As New Dictionary(Of Integer, TreeNode)
    Public dsPrint As DataSet
    Public dicPrint As List(Of Dictionary(Of String, Object))
    Public reportPrint As String = ""

    Private Sub loadmodule(ByVal modulesform As String, ByVal formcontrol As String, ByVal Optional controllname As String = Nothing)
        Try
            Dim oAssembly As Assembly
            Dim tp As TabPage
            Dim oControl As Object
            Dim l As List(Of Object)
            Dim b As Byte()
            b = File.ReadAllBytes("modules\" & modulesform & ".dll")
            oAssembly = Assembly.Load(b)
            oControl = oAssembly.CreateInstance(modulesform & "." & formcontrol)
            tcMain.TabPages.Add(controllname)
            tp = tcMain.TabPages(tcMain.TabPages.Count - 1)
            tp.Name = "dll" & modulesform & "-" & "form" & formcontrol
            tp.Controls.Add(oControl)
            DirectCast(oControl, UserControl).Dock = DockStyle.Fill
            l = New List(Of Object)
            l.Add(oControl)
            l.Add(tp)
            Modules.Add("", l)
            tcMain.SelectedTab = tp
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub NavBarItem1_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem1.LinkClicked
        loadmodule("RecruitmentModule", "RecruitmentControl", "Create New Recruitment")
    End Sub

    Private Sub tcmain_Selected(sender As Object, e As TabControlEventArgs)
        Dim c As Object
        Dim tn As TreeNode = Nothing
        c = (From m In Modules Where m.Value(1) Is e.TabPage Select m.Value(0)).FirstOrDefault
        Try
            tn = (From m In menus Where m.Value.Name = e.TabPage.Name Select m.Value).FirstOrDefault
        Catch ex As Exception
        End Try
        If Not IsNothing(tn) Then
        End If
    End Sub

    Private Sub CalculateSalaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculateSalaryToolStripMenuItem.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub NavBarItem22_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem22.LinkClicked
        loadmodule("RecruitmentModule", "Other_Income", "Other Income or Deduction")
    End Sub

    Private Sub NavBarItem2_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem2.LinkClicked
        loadmodule("RecruitmentModule", "RecruitmentLists", "Recruitment List")
    End Sub

    Private Sub NavBarItem3_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem3.LinkClicked
        loadmodule("EmployeeModule", "EmployeeControl", "Create New Employee")
    End Sub

    Private Sub NavBarItem4_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem4.LinkClicked
        loadmodule("EmployeeModule", "EmployeeLists", "Employee Lists")
    End Sub

    Private Sub NavBarItem5_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem5.LinkClicked
        loadmodule("EmployeeModule", "Warning_Notice", "Warning Notice")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub NavBarItem20_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem20.LinkClicked
        loadmodule("EmployeeModule", "StatusChange", "Status Change")
    End Sub

    Private Sub NavBarItem27_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem27.LinkClicked
        loadmodule("EmployeeModule", "Termination", "Termination")
    End Sub
End Class
