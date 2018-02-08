Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Connectors
    Public serverType As String = File.ReadAllText("ServerType.txt")
    Public con As Object
    Public cmd As Object
    Public tab As New DataTable
    Public conStr As String
    Public hosts As String = File.ReadAllText("host.txt")
    Public result As IAsyncResult

    Public Sub initiation(server As String, host As String, database As String, user As String, pwd As String)
        server = serverType
        host = hosts
        Select Case serverType
            Case "MSSQL"
                conStr = "Server=" + host + ";Database=" + database + ";User=" + user + ";Pwd=" + pwd + ";MultipleActiveResultSets=True"
                con = New SqlConnection()
            Case "MySQL", "MariaDB"
                conStr = "Server=" + host + ";Database=" + database + ";Uid=" + user + ";Pwd=" + pwd
                con = New MySqlConnection()
        End Select
        con.ConnectionString = conStr
    End Sub

    Public Sub SQL(str As String, Optional cmdObj As Object = Nothing)
        If IsNothing(cmdObj) Then
            Select Case serverType
                Case "MSSQL"
                    cmd = New SqlCommand(str, con)
                Case "MySQL", "MariaDB"
                    cmd = New MySqlCommand(str, con)
            End Select
        Else
            If IsNothing(cmdObj.Connection) Then cmdObj.Connection = con
            cmdObj.CommandText = str
        End If
    End Sub

    Public Function readTable() As String
        Dim result = Nothing
        Return result = cmd.executereader
    End Function

    Public Function Scalar() As String
        Dim result = Nothing
        Return result = cmd.executescalar
    End Function

    Public Function nonquery() As String
        Dim result = Nothing
        Return result = cmd.executenonquery
    End Function

    Public Sub addParam(paramValue As String, addValue As String)
        cmd.parameters.addwithvalue(paramValue, addValue)
    End Sub

    Public Function OpenCon() As Boolean
        Try
            con.open
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function CloseCon() As Boolean
        Try
            con.close
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
End Class
