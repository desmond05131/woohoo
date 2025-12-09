Namespace Freely.Document
    Public Class FreelyDocument
        Private _AConn As AutoCount.Data.DBSetting
        Public Sub New(ByVal AConn As AutoCount.Data.DBSetting)
            Me._AConn = AConn
        End Sub

        Private _DefaultDocumentType As String = "PR"
        Private _DefaultDocumentName As String = "PR Default 2"
        Const _DefaultNewDocNo As String = "<<New>>"
        Const _FormDocument As String = "Purchase Requisition"

        Public Sub GenerateNewDocumentType(ByVal ADocType As String, ByVal ADocName As String, ByVal AFormat As String)
            Try
                '"Select COUNT(*) From DocNoFormat Where Name=@Name",s
                Using sqlConn As New SqlClient.SqlConnection(Me._AConn.ConnectionString)
                    sqlConn.Open()
                    Using sqlCmd As New SqlClient.SqlCommand("Select COUNT(*) as iCount From DocNoFormat Where Name=@Name", sqlConn)
                        sqlCmd.Parameters.AddWithValue("Name", ADocName)
                        Using dtCount As New DataTable
                            dtCount.Load(sqlCmd.ExecuteReader)
                            For Each drCount As DataRow In dtCount.Rows
                                Dim iCount As Integer = IIf(drCount.Item("iCount") Is DBNull.Value, -1, drCount.Item("iCount"))
                                If iCount = 0 Then
                                    '        sSQL.AppendLine(" INSERT INTO DocNoFormat (Name, DocType, NextNumber, Format, Sample, IsDefault, OneMonthOneSet, MaxNumber) VALUES     ('AO Default', 'AD', 1, 'AO-<00000>', 'AO-<00001>', 'T', 'F', 0) ")
                                    Using sqlInsert As New SqlClient.SqlCommand("INSERT INTO DocNoFormat (Name, DocType, NextNumber, Format, Sample, IsDefault, OneMonthOneSet, MaxNumber)  " &
                                                                                " VALUES     (@Name, @DocType, 1, @Format, @Format, 'T', 'F', 0) ", sqlConn)
                                        sqlInsert.Parameters.AddWithValue("Name", ADocName)
                                        sqlInsert.Parameters.AddWithValue("DocType", ADocType)
                                        sqlInsert.Parameters.AddWithValue("Format", AFormat)
                                        sqlInsert.ExecuteNonQuery()
                                    End Using
                                End If
                            Next
                        End Using

                    End Using
                End Using
            Catch ex As Exception
                Throw ex
            End Try
        End Sub


        Public Shared Function ConvertTheFormatToText(ByVal AString As String) As String
            Dim iCountInteger As Integer = 0
            Dim ProcessString As String = String.Empty
            Dim ATempString As String = String.Empty
            Dim iNum As Integer = 0
            Dim ProText As String = String.Empty

            If Not AString.Contains("<") And Not AString.Contains(">") And Not AString.Contains("{") And Not AString.Contains("}") Then Return AString

            If AString.Contains("<") And AString.Contains(">") Then
                ProcessString = AString
                Dim StartCount As Boolean = False
                For i As Integer = 0 To AString.Length - 1
                    If AString(i) = "<" Then
                        StartCount = True
                    End If
                    If AString(i) = ">" Then
                        StartCount = False
                        ATempString = ATempString + AString(i)
                    End If
                    If StartCount Then
                        iNum = iNum + 1
                        ATempString = ATempString + AString(i)
                    End If
                Next
                ATempString = ATempString
                Dim AstringReplaced As String = String.Empty
                AstringReplaced = ProcessString.Replace(ATempString, "@")
                If iNum > 0 Then
                    iNum = iNum - 1
                End If
                Dim formattype As String = "{" + String.Format("0:D{0}", iNum) + "}"
                ProText = AstringReplaced.Replace("@", String.Format(formattype, 1))
            End If

            If AString.Contains("{") And AString.Contains("}") Then
                ProcessString = AString
                If ProText.Length > 0 Then
                    ProcessString = ProText
                End If
                iNum = 0
                ATempString = String.Empty
                Dim StartCount As Boolean = False
                For i As Integer = 0 To AString.Length - 1
                    If AString(i) = "{" Then
                        StartCount = True
                    End If
                    If AString(i) = "}" Then
                        StartCount = False
                        'ATempString = ATempString + TextEdit1.Text(i)
                    End If
                    If StartCount Then
                        iNum = iNum + 1
                        If iNum > 1 Then
                            ATempString = ATempString + AString(i)
                        End If
                    End If
                Next
                ATempString = ATempString
                Dim AtempReplaceString As String = "{" + ATempString + "}"
                Dim AstringReplaced As String = String.Empty
                AstringReplaced = ProcessString.Replace(AtempReplaceString, "$")
                If iNum > 0 Then
                    iNum = iNum - 1
                End If
                'Dim formattype As String = "{" + String.Format("0:D{0}", iNum) + "}"
                Try
                    Dim formattype As String = Now.ToString(ATempString)
                    ProText = AstringReplaced.Replace("$", formattype)
                Catch ex As Exception
                    ProText = AstringReplaced.Replace("$", String.Empty)
                End Try

            End If

            Return ProText
        End Function
    End Class
End Namespace

