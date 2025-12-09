Public Class UcFilter
    Public Property DocNo As New List(Of String)
    Public Property List As String = ""
    Private Sub comboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboType.SelectedIndexChanged
        Dim sSelected As String = comboType.EditValue

        If sSelected = "No Filter" Then
            lblFromPart.Visible = False
            luFromPart.Visible = False
            lblToPart.Visible = False
            luToPart.Visible = False
            lblMultiSelectPart.Visible = False
        ElseIf sSelected = "Filter By Range" Then
            lblFromPart.Visible = True
            luFromPart.Visible = True
            lblToPart.Visible = True
            luToPart.Visible = True
            lblMultiSelectPart.Visible = False
        ElseIf sSelected = "Filter By Multi-Select" Then
            lblFromPart.Visible = False
            luFromPart.Visible = False
            lblToPart.Visible = False
            luToPart.Visible = False
            lblMultiSelectPart.Visible = True

            MultiSelectPart()
        End If
    End Sub
    Public Sub MultiSelectPart()
        Try
            Dim oSearchForm As New Freely.FormUI.FreelySeachForm
            oSearchForm.MultiSelect = True
            oSearchForm.sSQL = "SELECT ItemCode, (UDF_CustPartNo) AS CustomerPartNo, Description FROM Item"
            oSearchForm.ReturnField = "CustomerPartNo"
            oSearchForm.FieldValue = DocNo
            oSearchForm.ShowDialog()

            If oSearchForm.DialogResult = Windows.Forms.DialogResult.OK Then
                If oSearchForm.FieldValue.Count = 0 Then
                    oSearchForm.Text = "0 Record was Selected"
                ElseIf oSearchForm.FieldValue.Count > 0 Then
                    DocNo = oSearchForm.FieldValue
                    lblMultiSelectPart.Text = String.Format("{0} Record was Selected", oSearchForm.FieldValue.Count)
                    List = ""
                    For i As Integer = 0 To oSearchForm.FieldValue.Count - 1
                        Dim sDocNo As String = String.Format("'{0}',", oSearchForm.FieldValue(i))
                        List = List + sDocNo
                    Next
                    List = List.Substring(0, List.Length - 1)
                End If

            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
