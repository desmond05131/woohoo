Imports AutoCount.Authentication

Public Class AccessRightsCommand
    ''TODO: add CMD ID for access rights
    Public Const Allow_Edit_YourForm As String = "Allow_Edit_YourForm"

    Public Shared Function InitAccessRight() As Boolean
        Try
            '---Implement Access Right Here--
            Dim AccessRightRecordList As New List(Of AccessRightRecord)

            Dim root_StockItemInquiry As String = "root_StockItemInquiry"

            AccessRightRecordList.Add(New AccessRightRecord(root_StockItemInquiry, "0", FreelyPlugIns.ProductName))
            AccessRightRecordList.Add(New AccessRightRecord(ScriptAccessRight.Allow_ItemInquiry, root_StockItemInquiry, "Allows Stock Item Inquiry Show In Item"))

            'AccessRight_Menu_ImportARInovice_Open
            '---Implement Access Right Here--


            For Each AccessRightRecord As AccessRightRecord In AccessRightRecordList
                AccessRightMap.AddAccessRightRecord(AccessRightRecord)
            Next
        Catch ex As Exception
            Freely.Standard.MessageBox.FreelyMessageBox.ShowErrorMessage(ex.Message)            
        End Try
        Return False
    End Function



End Class

