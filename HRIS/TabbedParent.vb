Imports System.Reflection
Imports System.IO

Public Class TabbedParent
    Private Modules As New Dictionary(Of String, List(Of Object))
    Private toUpdate As New Dictionary(Of String, String)
    Private menus As New Dictionary(Of Integer, TreeNode)

    Public dsPrint As DataSet
    Public dicPrint As List(Of Dictionary(Of String, Object))
    Public reportPrint As String = ""

    Private Sub loadmodule(modulesform As String, formcontrol As String, controlname As String)
        Try
            Dim oAssembly As Assembly
            Dim tp As TabPage
            Dim oControl As Object
            Dim l As List(Of Object)
            Dim b As Byte()
            b = File.ReadAllBytes("modules\" & modulesform & ".dll")
            oAssembly = Assembly.Load(b)
            oControl = oAssembly.CreateInstance(modulesform & "." & formcontrol)
            tcMain.TabPages.Add(controlname)
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
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub SplitContainer2_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer2.Panel2.Paint

    End Sub

    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub SplitContainer2_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer2.Panel1.Paint

    End Sub

    Private Sub NavBarItem1_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem1.LinkClicked
        loadmodule("RecruitmentModule", "RecruitmentControl", "Recruitment")
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
End Class