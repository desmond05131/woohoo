'2022/04/26 Lai Added New form Tools
Public Class FreelyStandardFormTools

    Public ReadOnly Property Author As String
        Get
            Return "Lai Wei Loong 2022"
        End Get
    End Property

    Public Function CopyDataSetToClipBoard(ByVal ADataSet As System.Data.DataSet, Optional ByVal mode As System.Data.XmlWriteMode = XmlWriteMode.WriteSchema) As Boolean
        Try
            Dim stringWriter As System.IO.StringWriter = New System.IO.StringWriter()
            ADataSet.WriteXml(stringWriter, mode)
            FreelyClipboardHelper.SetDataObject(stringWriter.ToString())
            Return True
        Catch ex As Exception
            Freely.Standard.MessageBox.FreelyMessageBox.ShowErrorMessage(ex.Message)
        End Try
        Return False
    End Function
    Public Function PasteDataSetFromClipBoard(Optional ByVal mode As System.Data.XmlReadMode = XmlReadMode.Auto) As DataSet
        Try
            Dim dataObject As IDataObject = Nothing
            Try
                dataObject = Clipboard.GetDataObject()
            Catch ex As System.Exception

            End Try
            If (dataObject.GetDataPresent(DataFormats.UnicodeText)) Then
                Dim xmlString As String = CStr(dataObject.GetData(DataFormats.UnicodeText))
                Try
                    Dim dataSet As System.Data.DataSet = New System.Data.DataSet()
                    dataSet.ReadXml(New IO.StringReader(xmlString), mode)
                    Return dataSet
                Catch ex As System.Xml.XmlException
                    Throw ex
                Finally
                    'Clear Clipboard
                    FreelyClipboardHelper.SetDataObject("")
                End Try
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function


    Public Class FreelyClipboardHelper
        Const TryCopy As Integer = 5
        Const TryDelay As Integer = 300
        Public Shared Sub SetDataObject(ByVal data As Object)
            Try
                Clipboard.SetDataObject(data, True, TryCopy, TryDelay)
            Catch ex As System.Exception
                Throw ex

            End Try
        End Sub
    End Class
End Class
