Imports System.IO
Imports System.Configuration
Imports System.Web
Imports System.Linq
Imports System.Collections.Generic
Imports Microsoft.Office
Imports System.Net
Imports System.Windows.Forms

Public Class FrmMain
    Private Const TfileName As String = "Teams.txt"
    Private Const KfileName As String = "KeyJSON.txt"
    Private ReadOnly filePath As String = "S:\Corp\CIS\BCD-DR\FRED\"
    Public _NewKey As DataTable
    Public _CurrentKey As DataTable
    Public _Team As DataTable

    Public Property NewKey As DataTable
        Get
            Return _NewKey
        End Get
        Set(value As DataTable)
            _NewKey = value
        End Set
    End Property
    Public Property CurrentKey As DataTable
        Get
            Return _CurrentKey
        End Get
        Set(value As DataTable)
            _CurrentKey = value
        End Set
    End Property
    Public Property Team As DataTable
        Get
            Return _Team
        End Get
        Set(value As DataTable)
            _Team = value
        End Set
    End Property
    'TEAM FILE
    Public Class Attributes
        Public Property type As String
        Public Property url As String
    End Class
    'TEAM FILE
    Public Class Record
        Public Property attributes As Attributes
        Public Property FF__Key_Contact__c As String
        Public Property FF__Team_Name__c As String
    End Class
    'TEAM FILE
    Public Class Example
        Public Property totalSize As Integer
        Public Property done As Boolean
        Public Property records As Record()
    End Class

    Public Class UserAttributes
        Public Property type As String
        Public Property url As String
    End Class

    Public Class UserRecord
        Public Property attributes As UserAttributes
        Public Property Name As String
        Public Property YID__c As String
        Public Property Status__c As String
        Public Property Cost_Center__c As String
        Public Property Level_1_Supervisor_ID__c As String
        Public Property Cost_Center_Name__c As String
        Public Property Level_1_Supervisor_Name__c As String
        Public Property Id As String
    End Class

    Public Class UserExample
        Public Property totalSize As Integer
        Public Property done As Boolean
        Public Property nextRecordsUrl As String
        Public Property records As UserRecord()
    End Class
    Public Function CreateClient() As SalesforceClient
        Return New SalesforceClient With {
            .Username = ConfigurationManager.AppSettings("username"),
            .Password = ConfigurationManager.AppSettings("password"),
            .Token = ConfigurationManager.AppSettings("token"),
            .ClientId = ConfigurationManager.AppSettings("clientId"),
            .ClientSecret = ConfigurationManager.AppSettings("clientSecret")
        }
    End Function
    '===========================================================================================================================

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        TeamFile()

        KeyFile()

        ConvertCSVToDataSet()

    End Sub

    Private Sub KeyFile()
        Dim client = CreateClient()
        client.Login()
        '=====================================================================================================================
        'Process query for basic User information to compare
        System.IO.File.WriteAllText("S:\Corp\CIS\BCD-DR\FRED\KeyJSON.txt", "")
        Using file As System.IO.StreamWriter = New System.IO.StreamWriter("S:\Corp\CIS\BCD-DR\FRED\KeyJSON.txt", True)

            If True Then
                file.WriteLine(client.Query("SELECT Name, YID__c, Status__c,Cost_Center__c,Level_1_Supervisor_ID__c,Cost_Center_Name__c,Level_1_Supervisor_Name__c,ID from FF__Key_Contact__c"))
            End If
        End Using

    End Sub

    Private Sub TeamFile()
        Dim Iindex As Integer = 0
        Dim i As Integer = 0

        Dim client = CreateClient()
        client.Login()
        '=====================================================================================================================
        'Process Team listion with Fusion ID and team name
        '=====================================================================================================================
        System.IO.File.WriteAllText("S:\Corp\CIS\BCD-DR\FRED\Teams.txt", "")
        Using file As System.IO.StreamWriter = New System.IO.StreamWriter("S:\Corp\CIS\BCD-DR\FRED\Teams.txt", True)

            If True Then
                file.WriteLine(client.Query("Select FF__Key_Contact__c,FF__Team_Name__c FROM FF__Team_Member__c "))
            End If
        End Using


    End Sub

    Private Sub ConvertCSVToDataSet()
        Dim reader As StreamReader
        reader = New StreamReader("H:\Fusion_Employee_Key_Contacts.csv")
        Dim dtKey As DataTable = New DataTable
        Dim id As Integer = 1
        Dim firstLine As Boolean = True
        Dim regex As Object
        regex = CreateObject("vbscript.regexp")
        regex.IgnoreCase = True
        regex.Global = True
        Dim splitline2 As String()
        Dim reader2 As StreamReader = New StreamReader(File.OpenRead("H:\Fusion_Employee_Key_Contacts.csv"))
        Dim lineCount As Integer = 0

        While reader2.ReadLine() IsNot Nothing
            lineCount += 1
            If lineCount Mod 1000 = 0 Then Console.WriteLine(lineCount)
        End While


        regex.Pattern = ",(?=([^" & Chr(34) & "]*" & Chr(34) & "[^" & Chr(34) & "]*" & Chr(34) & ")*(?![^" & Chr(34) & "]*" & Chr(34) & "))"
        'regex.Pattern = (",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))")

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("H:\Fusion_Employee_Key_Contacts.csv")
            MyReader.HasFieldsEnclosedInQuotes = True
            Dim x As Integer = 0
            While id < lineCount
                If firstLine Then
                    firstLine = False
                    Dim cols = reader.ReadLine.Split(","c)
                    For Each col In cols
                        col.Replace("""", "").Trim()
                        dtKey.Columns.Add(New DataColumn(col, GetType(String)))
                    Next
                Else
                    splitline2 = Split(regex.Replace((reader.ReadLine), ";"), ";")
                    For x = 0 To 70
                        splitline2(x) = splitline2(x).Replace(Chr(34), String.Empty).Trim()
                    Next
                    dtKey.Rows.Add(splitline2)
                    id += 1
                End If
            End While

            dtKey.Columns.Add("ID", GetType(String))
            dtKey.Columns("ID").DefaultValue = 0
            dtKey.Columns("ID").SetOrdinal(0)

            id = 2

            Dim i As Integer
            For i = 0 To dtKey.Rows.Count - 1 Step 1
                dtKey.Rows(i)("ID") = id
            Next
        End Using

        NewKey = dtKey.Copy()
        'dgCC.DataSource = NewKey

        reader.Dispose()
        dtKey.Dispose()

    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Dim dtTeam As New DataTable
        dtTeam.Columns.Add("id", GetType(Integer))
        dtTeam.Columns.Add("uID", GetType(String))
        dtTeam.Columns.Add("TeamName", GetType(String))

        Dim dtKey As New DataTable
        dtKey.Columns.Add("id", GetType(Integer))
        dtKey.Columns.Add("uID", GetType(String))
        dtKey.Columns.Add("YID", GetType(String))
        dtKey.Columns.Add("User", GetType(String))
        dtKey.Columns.Add("Status", GetType(String))
        dtKey.Columns.Add("CC", GetType(String))
        dtKey.Columns.Add("CC_Name", GetType(String))
        dtKey.Columns.Add("Level1", GetType(String))
        dtKey.Columns.Add("Level1_Name", GetType(String))

        '=====================================================================================================================
        ' Process Team JSON text file
        '=====================================================================================================================
        If IO.File.Exists(filePath & TfileName) Then
            Dim jText As String = IO.File.ReadAllText(filePath & TfileName)

            If Not String.IsNullOrWhiteSpace(jText) Then

                Dim teamObject As Example = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Example)(jText)

                For i = 0 To teamObject.totalSize - 1
                    dtTeam.Rows.Add((i + 1), teamObject.records(i).FF__Key_Contact__c.ToString, teamObject.records(i).FF__Team_Name__c.ToString)
                Next

                Team = dtTeam.Copy()

                dgTeam.DataSource = Team
                dtTeam.Dispose()

            End If
        End If

        '=====================================================================================================================
        ' Process Key JSON text file
        '=====================================================================================================================
        Dim L1_ID As String = ""
        Dim L1_Name As String = ""

        Dim CC_ID As String = ""
        Dim CC_Name As String = ""

        Dim KStatus As String = ""
        Dim KYid As String = ""


        If IO.File.Exists(filePath & KfileName) Then
            Dim jText As String = IO.File.ReadAllText(filePath & KfileName)

            If Not String.IsNullOrWhiteSpace(jText) Then

                Dim KteamObject As UserExample = Newtonsoft.Json.JsonConvert.DeserializeObject(Of UserExample)(jText)

                For i = 0 To 1999 'KteamObject.totalSize - 1

                    If IsNothing(KteamObject.records(i).YID__c) Then
                        KYid = ""
                    Else
                        KYid = KteamObject.records(i).YID__c.ToString()
                    End If

                    If IsNothing(KteamObject.records(i).Level_1_Supervisor_ID__c) Then
                        L1_ID = ""
                    Else
                        L1_ID = KteamObject.records(i).Level_1_Supervisor_ID__c.ToString()
                    End If

                    If IsNothing(KteamObject.records(i).Level_1_Supervisor_Name__c) Then
                        L1_Name = ""
                    Else
                        L1_Name = KteamObject.records(i).Level_1_Supervisor_Name__c.ToString
                    End If

                    If IsNothing(KteamObject.records(i).Cost_Center__c) Then
                        CC_ID = ""
                    Else
                        CC_ID = KteamObject.records(i).Cost_Center__c.ToString()
                    End If

                    If IsNothing(KteamObject.records(i).Cost_Center_Name__c) Then
                        CC_Name = ""
                    Else
                        CC_Name = KteamObject.records(i).Cost_Center_Name__c.ToString
                    End If

                    If IsNothing(KteamObject.records(i).Status__c) Then
                        KStatus = ""
                    Else
                        KStatus = KteamObject.records(i).Status__c.ToString
                    End If


                    dtKey.Rows.Add((i + 1), KteamObject.records(i).Id.ToString, KYid, KteamObject.records(i).Name.ToString, KStatus, CC_ID, CC_Name, L1_ID, L1_Name)
                Next

                CurrentKey = dtKey.Copy()

                dgTerm.DataSource = CurrentKey
                dtKey.Dispose()

            End If
        End If

        CompareDataTables(CurrentKey, NewKey)
    End Sub

    Private Sub CompareDataTables(ByVal CKey As DataTable, ByVal NKey As DataTable)
        Dim ChangesDataTable As New DataTable

        With ChangesDataTable
            .Columns.Add("UID")
            .Columns.Add("YID")
            .Columns.Add("NAME")
            .Columns.Add("STATUS")
            .Columns.Add("CC")
            .Columns.Add("CC_Name")
            .Columns.Add("Level1")
            .Columns.Add("Level1_Name")

        End With
        Dim rowArray As DataRow()
        Dim rowAdd As DataRow

        'If dt1 is the original
        For Each row In NKey.Rows
            rowArray = CKey.Select("YID = '" & row(1).ToString & "'")

            If rowArray.Length > 0 Then
                'compare fields
                'if changes
                If Mid(row(6).ToString, 2, 10) = "Terminated" Then
                    rowAdd = ChangesDataTable.NewRow
                    rowAdd("UID") = rowArray(0).Item(1).ToString
                    rowAdd("YID") = row(1).ToString
                    rowAdd("NAME") = row(5).ToString
                    rowAdd("STATUS") = row(6).ToString
                    ChangesDataTable.Rows.Add(rowAdd)
                End If

                If Mid(row(6).ToString, 2, 10) <> "Terminated" Then
                    If row(15).ToString <> rowArray(0).Item(5).ToString Then
                        rowAdd = ChangesDataTable.NewRow
                        rowAdd("UID") = rowArray(0).Item(1).ToString
                        rowAdd("YID") = row(1).ToString
                        rowAdd("NAME") = row(5).ToString
                        rowAdd("STATUS") = row(6).ToString
                        rowAdd("CC") = row(15).ToString
                        rowAdd("CC_Name") = row(16).ToString
                        ChangesDataTable.Rows.Add(rowAdd)
                    End If

                    If Mid(row(36).ToString, 2, 6) <> rowArray(0).Item(6).ToString Then
                        rowAdd = ChangesDataTable.NewRow
                        rowAdd("UID") = rowArray(0).Item(1).ToString
                        rowAdd("YID") = row(1).ToString
                        rowAdd("NAME") = row(5).ToString
                        rowAdd("STATUS") = row(6).ToString
                        rowAdd("LEVEL1") = row(36).ToString
                        rowAdd("LEVEL1_Name") = row(35).ToString
                        ChangesDataTable.Rows.Add(rowAdd)
                    End If
                End If

            End If
        Next
        dgCC.DataSource = ChangesDataTable
    End Sub
End Class
