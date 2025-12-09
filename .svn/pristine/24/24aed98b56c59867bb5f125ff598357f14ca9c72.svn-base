Namespace Freely.Standard.Script
    Public Class FreelyScriptStandardHelper
        'Created By Lai 2022/03/30
        Dim _UserSession As AutoCount.Authentication.UserSession
        Dim _DBSetting As AutoCount.Data.DBSetting
        Dim _Form As System.Windows.Forms.Form
        Dim _RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
        Dim _FreelyConstValue As FreelyConstValue



        Public Const layoutDetailUOMPrefix As String = "tabctrDetailUom_lyt_"
        Public Const layoutGroupMasterPrifix As String = "lytGrpMasterInfo_lyt_"

        Dim sAutoCountPosiblePrifix As String() = {layoutDetailUOMPrefix, layoutGroupMasterPrifix}
        Public ReadOnly Property FreelyConstValue As FreelyConstValue
            Get
                Return _FreelyConstValue
            End Get
        End Property
        Public ReadOnly Property DBSetting As AutoCount.Data.DBSetting
            Get
                Return _DBSetting
            End Get
        End Property
        Public ReadOnly Property UserSession As AutoCount.Authentication.UserSession
            Get
                Return _UserSession
            End Get
        End Property
        Public Sub New(ByVal AUserSession As AutoCount.Authentication.UserSession)
            _UserSession = AUserSession
            _DBSetting = _UserSession.DBSetting
            _FreelyConstValue = New FreelyConstValue
        End Sub

        Public Function AddBarItemToAutoCountGroups(ByVal ARibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl,
                                                    ByVal AutoCountRibbonGroupName As FreelyAutoCountRibbonGroupName.FreelyRibbonName,
                                                     ByVal ABarButtonName As String,
                                                    ByVal ACaption As String) As DevExpress.XtraBars.BarButtonItem
            _RibbonControl = ARibbonControl
            Dim ribbonPageGroupView As DevExpress.XtraBars.Ribbon.RibbonPageGroup
            Dim sGroupName As String = ToFreelyLocalication(AutoCountRibbonGroupName)
            If sGroupName.Length = 0 Then
                Throw (New FreelyStandardScriptException).InvalidRibbonGroupNameException
            Else
                ribbonPageGroupView = ARibbonControl.GetGroupByName(sGroupName)
            End If
            If ABarButtonName.Length = 0 Then
                Throw (New FreelyStandardScriptException).InvalidRibbonButtonNameException
            End If
            If ribbonPageGroupView IsNot Nothing Then
                Dim AItem As DevExpress.XtraBars.BarButtonItem = ARibbonControl.Items(ABarButtonName)
                If AItem IsNot Nothing Then
                    AItem.Dispose()
                End If

                Dim btnFreelyBarButtonItem As DevExpress.XtraBars.BarButtonItem = Nothing
                btnFreelyBarButtonItem = New DevExpress.XtraBars.BarButtonItem
                btnFreelyBarButtonItem.Name = ABarButtonName
                btnFreelyBarButtonItem.Caption = ACaption

                ARibbonControl.Items.Add(btnFreelyBarButtonItem)
                ribbonPageGroupView.ItemLinks.Add(btnFreelyBarButtonItem)
                Return btnFreelyBarButtonItem
            End If
            Return Nothing
        End Function
        Public Sub GridViewController(ByVal AGridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal AUDFListToDisableEdit As String(), ByVal AAllowEdit As Boolean)
            If AGridView IsNot Nothing Then
                For Each sDisableColumn As String In AUDFListToDisableEdit
                    If AGridView.Columns(sDisableColumn) IsNot Nothing Then
                        AGridView.Columns(sDisableColumn).OptionsColumn.AllowEdit = AAllowEdit
                        AGridView.Columns(sDisableColumn).AppearanceCell.BackColor = FreelyConstValue.FreelyReadOnlyBackColor
                    End If
                Next
            End If
        End Sub

        Public Function FindLayoutControls(ByVal ALayoutControl As DevExpress.XtraLayout.LayoutControl, ByVal AUDFName As String) As Object
            For Each sLayoutPrefix As String In sAutoCountPosiblePrifix
                Dim objItem As Object = ALayoutControl.Items.FindByName(String.Format("{0}{1}", sLayoutPrefix, AUDFName))
                If objItem IsNot Nothing Then
                    Return objItem
                End If
            Next
            Return Nothing
        End Function
    End Class

    Public Class FreelyAutoCountRibbonGroupName

        Public Enum FreelyRibbonName
            <FreelyLocalication.FreelyDefault(FreelyAutoCountRibbonGroupName.AutoCount_ribbonPageGroupEdit)>
            AutoCount_ribbonPageGroupEdit
            <FreelyLocalication.FreelyDefault(FreelyAutoCountRibbonGroupName.AutoCount_ribbonPageGroupTransfer)>
            AutoCount_ribbonPageGroupTransfer
            <FreelyLocalication.FreelyDefault(FreelyAutoCountRibbonGroupName.AutoCount_ribbonPageGroupView)>
            AutoCount_ribbonPageGroupView
            <FreelyLocalication.FreelyDefault(FreelyAutoCountRibbonGroupName.AutoCount_APInvoice_ribbonPageGroupSave)>
            AutoCount_APInvoice_ribbonPageGroupSave
            <FreelyLocalication.FreelyDefault(FreelyAutoCountRibbonGroupName.AutoCount_CB_ribbonPageGroupRecordFunction)>
            AutoCount_CB_ribbonPageGroupRecordFunction
            <FreelyLocalication.FreelyDefault(FreelyAutoCountRibbonGroupName.AutoCount_APInvoice_ribbonPageGroupRecordFunction)>
            AutoCount_APInvoice_ribbonPageGroupRecordFunction
            <FreelyLocalication.FreelyDefault(FreelyAutoCountRibbonGroupName.AutoCount_APInvoice_ribbonPageGroupView)>
            AutoCount_APInvoice_ribbonPageGroupView
            <FreelyLocalication.FreelyDefault(FreelyAutoCountRibbonGroupName.AutoCount_APInvoice_ribbonPageGroupCopyAPInvoice)>
            AutoCount_APInvoice_ribbonPageGroupCopyAPInvoice
            <FreelyLocalication.FreelyDefault(FreelyAutoCountRibbonGroupName.AutoCount_APInvoice_ribbonPageGroupClipboard)>
            AutoCount_APInvoice_ribbonPageGroupClipboard
            <FreelyLocalication.FreelyDefault(FreelyAutoCountRibbonGroupName.AutoCount_APInvoice_ribbonPageGroupEdit)>
            AutoCount_APInvoice_ribbonPageGroupEdit
            <FreelyLocalication.FreelyDefault(FreelyAutoCountRibbonGroupName.AutoCount_APInvoice_ribbonPageGroupCalculation)>
            AutoCount_APInvoice_ribbonPageGroupCalculation
            <FreelyLocalication.FreelyDefault(FreelyAutoCountRibbonGroupName.AutoCount_APInvoice_ribbonPageGroupViewPosting)>
            AutoCount_APInvoice_ribbonPageGroupViewPosting
        End Enum


        Private Const AutoCount_ribbonPageGroupEdit As String = "ribbonPageGroupEditing"
        Private Const AutoCount_ribbonPageGroupTransfer As String = "ribbonPageGroupTransfer"
        Private Const AutoCount_ribbonPageGroupView As String = "ribbonPageGroupView"

        '-2022/04/22 Lai Added AP Invoice and Cash book site group page name.
        '---AP invoice===
        Private Const AutoCount_APInvoice_ribbonPageGroupSave As String = "ribbonPageGroupSave"
        Private Const AutoCount_APInvoice_ribbonPageGroupView As String = "ribbonPageGroupView"

        '
        Private Const AutoCount_CB_ribbonPageGroupRecordFunction As String = "ribbonPageGroupPaymentEditing"

        Private Const AutoCount_APInvoice_ribbonPageGroupRecordFunction As String = "ribbonPageGroupRecordFunction"
        Private Const AutoCount_APInvoice_ribbonPageGroupCopyAPInvoice As String = "ribbonPageGroupCopyAPInvoice"
        Private Const AutoCount_APInvoice_ribbonPageGroupClipboard As String = "ribbonPageGroupClipboard"
        Private Const AutoCount_APInvoice_ribbonPageGroupEdit As String = "ribbonPageGroupEdit"
        Private Const AutoCount_APInvoice_ribbonPageGroupCalculation As String = "ribbonPageGroupCalculation"
        Private Const AutoCount_APInvoice_ribbonPageGroupViewPosting As String = "ribbonPageGroupViewPosting"
        '---AP invoice===
    End Class

    Public Class FreelyStandardScriptException
        Public Const InvalidRibbonGroupName As String = "Invalid Ribbon Group Name"
        Public Const InvalidRibbonButtonName As String = "Invalid Button Name"
        Public InvalidRibbonGroupNameException As New Exception(InvalidRibbonGroupName)
        Public InvalidRibbonButtonNameException As New Exception(InvalidRibbonButtonName)
    End Class
End Namespace