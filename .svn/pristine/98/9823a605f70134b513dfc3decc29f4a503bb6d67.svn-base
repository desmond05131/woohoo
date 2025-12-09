Public Class StockItem
    Public itemCodeDV As DevExpress.XtraGrid.Views.Grid.GridView
    Public Shared sItemCode As String
    Public Sub OnFormInitialize(ByVal e As AutoCount.Stock.Item.FormItemCmd.FormInitializeEventArgs)
        '  FreelyLibrary.Freely.Application.FreelyApplication.FindControl(e.Form, True, True, True)
        Try
            itemCodeDV = e.GridView
            Dim bAllowItemInquiry As Boolean
            bAllowItemInquiry = e.UserSession.AccessRight.IsAccessible(ScriptAccessRight.Allow_ItemInquiry)
            If bAllowItemInquiry Then
                Dim sbtnRefresh As DevExpress.XtraEditors.SimpleButton = e.Form.Controls.Find("btnRefresh", True)(0)
                Dim btnStockItemInqury As DevExpress.XtraEditors.SimpleButton = New DevExpress.XtraEditors.SimpleButton
                btnStockItemInqury.Text = "ItemInquiryForm"
                btnStockItemInqury.Name = "ItemInquiryFormBtn"
                btnStockItemInqury.TabIndex = 100
                btnStockItemInqury.Visible = True
                btnStockItemInqury.Tag = 100

                btnStockItemInqury.Width = sbtnRefresh.Width + 35
                btnStockItemInqury.Height = sbtnRefresh.Height
                btnStockItemInqury.Location = New Point(sbtnRefresh.Location.X + sbtnRefresh.Width + 5, sbtnRefresh.Location.Y)
                btnStockItemInqury.Parent = sbtnRefresh.Parent
                AddHandler btnStockItemInqury.Click, AddressOf btnStockItemInqury_Click
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Autosoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnStockItemInqury_Click(sender As Object, e As EventArgs)
        Dim formInquiry As New AutoCount.Stock.ItemInquiry.FormItemInquiry(AutoCount.Authentication.UserSession.CurrentUserSession)
        sItemCode = itemCodeDV.GetDataRow(itemCodeDV.FocusedRowHandle).Item("ItemCode")
        formInquiry.Show()
        formInquiry.Inquire(sItemCode)
    End Sub
End Class

Public Class StockItemEdit
    Public Shared sItemCode As String
    Dim lyButtonAdd As New DevExpress.XtraLayout.LayoutControlItem
    Public Sub OnDataBinding(ByVal e As AutoCount.Stock.Item.FormStockItem.LayoutFormDataBindingEventArgs)

        sItemCode = e.MasterTable.Rows.Item(0).Item("ItemCode").ToString
        If e.ItemLayoutControl.Controls.Find("ItemInquiryFormBtn", True).Length > 0 Then

            lyButtonAdd = e.ItemLayoutControl.Items.FindByName("btnStockItemInqury")
            Return
        End If
        Dim bAllowItemInquiry As Boolean
        bAllowItemInquiry = e.UserSession.AccessRight.IsAccessible(ScriptAccessRight.Allow_ItemInquiry)
        If bAllowItemInquiry Then
            Dim sbtnRefresh As DevExpress.XtraEditors.ComboBoxEdit = e.Form.Controls.Find("cbedtCostingMethod", True)(0)
            Dim btnStockItemInqury As DevExpress.XtraEditors.SimpleButton = New DevExpress.XtraEditors.SimpleButton
            btnStockItemInqury.Text = "Stock Item Inqury"
            btnStockItemInqury.Name = "ItemInquiryFormBtn"
            btnStockItemInqury.TabIndex = 100
            btnStockItemInqury.Visible = True
            btnStockItemInqury.Tag = 100
            btnStockItemInqury.Width = sbtnRefresh.Width + 35
            btnStockItemInqury.Height = sbtnRefresh.Height + 5
            AddHandler btnStockItemInqury.Click, AddressOf btnStockItemInqury_Click

            lyButtonAdd.Name = "btnStockItemInqury"
            lyButtonAdd.Control = btnStockItemInqury
            lyButtonAdd.Text = "Stock Item Inqury"
            lyButtonAdd.TextVisible = False
            lyButtonAdd.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
            e.ItemLayoutControl.AddItem(lyButtonAdd)
            sItemCode = e.MasterTable.Rows.Item(0).Item("ItemCode").ToString
            If e.EditWindowMode = AutoCount.Document.EditWindowMode.View Then
                lyButtonAdd.Enabled = True
            End If
        End If
    End Sub

    Public Sub OnFormShow(ByVal e As AutoCount.Stock.Item.FormStockItem.LayoutFormShowEventArgs)
        If e.EditWindowMode = AutoCount.Document.EditWindowMode.View Then
            If lyButtonAdd.Control Is Nothing Then Return
            lyButtonAdd.Enabled = True
            lyButtonAdd.Control.Enabled = True
        End If
    End Sub
    Private Sub btnStockItemInqury_Click(sender As Object, e As EventArgs)
        Dim formInquiry As New AutoCount.Stock.ItemInquiry.FormItemInquiry(AutoCount.Authentication.UserSession.CurrentUserSession)
        formInquiry.Show()
        formInquiry.Inquire(sItemCode)
    End Sub
End Class

