Namespace Freely.Global
    Public Class FreelyAutoCountScript
        Public Shared Sub RegisterAutocountScript(ByVal ADBSetting As AutoCount.Data.DBSetting, ByVal AFreely As Type)
            Try
                'Sales'
                '------------------------------------------------------------------
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("QT", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("SO", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("DO", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("IV", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("CS", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("CN", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("DN", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("XS", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("CSGN", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("DR", AFreely)
                '------------------------------------------------------------------

                'Purchase'
                '------------------------------------------------------------------
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("RQ", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("PO", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("GR", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("PI", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("CP", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("PR", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("XP", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("GT", AFreely)
                '------------------------------------------------------------------

                'Stock'
                '------------------------------------------------------------------
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("ADJ", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("ISS", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("RCV", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("XFER", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("UCost", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("UOMConv", AFreely)
                AutoCount.Scripting.ScriptManager.GetOrCreate(ADBSetting).RegisterByType("WOFF", AFreely)
                '------------------------------------------------------------------
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
            End Try
        End Sub

    End Class


    Public MustInherit Class FreelyScriptInheritanceBase

#Region "Event"
        Private Event FreelyFormInitializeEvent(ByVal Sender As Object, ByVal e As FreelyInitializeEvent)
        Private Event FreelyOnFormShowEvent(ByVal e As FreelyOnFormShowEvent)
        Private Event FreelyDetailColumnChangedEvent(ByVal e As FreelyDetailChangedEvent)
        Private Event FreelyMasterColumnChangedEvent(ByVal e As FreelyMasterChangedEvent)
        Private Event FreelyBeforeSaveEvent(ByVal e As FreelyBeforeSaveEvent)
        Private Event FreelyAfterSaveEvent(ByVal e As FreelyAfterSaveEvent)
        Private Event FreelyPackageDetailColumnChangedEvent(ByVal e As FreelyPackageDetailChangedEvent)
        Private Event FreelyNewItemPackageEvent(ByVal e As FreelyOnNewItemPackageEvent)
        Private Event FreelyOnSwtichEditModeEvent(ByVal e As FreelyOnSwtichEditModeEvent)

#End Region

#Region "Sales Document"

#Region "Quotation"
        Public Sub OnFormShow(ByVal e As AutoCount.Invoicing.Sales.Quotation.FormQuotationEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = Nothing
            'AInit.TabControl = Nothing
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.Quotation
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.QTDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub OnNewItemPackage(ByVal e As AutoCount.Invoicing.Sales.Quotation.QuotationNewItemPackageEventArgs)
            'FreelyOnNewItemPackage
            Dim AInit As New FreelyOnNewItemPackageEvent
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.QTDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyNewItemPackageEvent(AInit)
        End Sub

        Public Sub OnPackageDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.Quotation.QuotationPackageDetailColumnChangedEventArgs)
            Dim AInit As New FreelyPackageDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.QTDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyPackageDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Invoicing.Sales.Quotation.QuotationEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.QTDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub

        Public Sub BeforeSave(ByVal e As AutoCount.Invoicing.Sales.Quotation.QuotationBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.QTDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub

        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Invoicing.Sales.Quotation.QuotationMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.QTDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub OnFormInitialize(ByVal e As AutoCount.Invoicing.Sales.Quotation.FormQuotationEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            '   AInit.LayoutControl = e.LayoutControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Form = e.Form
            AInit.Document = e.Quotation
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.QTDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyFormInitializeEvent(e.Form, AInit)
        End Sub

        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.Quotation.QuotationDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord

            AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.QTDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Invoicing.Sales.Quotation.FormQuotationEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            AInit.HeaderPanel = Nothing
            AInit.TabControl = Nothing
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.Quotation
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.QTDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
#End Region

#Region "Sales Order"
        Public Sub OnFormShow(ByVal e As AutoCount.Invoicing.Sales.SalesOrder.FormSalesOrderEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = Nothing
            'AInit.TabControl = Nothing
            AInit.Document = e.SalesOrder
            AInit.LayoutControl = e.LayoutControl
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.SODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub OnNewItemPackage(ByVal e As AutoCount.Invoicing.Sales.SalesOrder.SalesOrderNewItemPackageEventArgs)
            'FreelyOnNewItemPackage
            Dim AInit As New FreelyOnNewItemPackageEvent
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.SODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyNewItemPackageEvent(AInit)
        End Sub
        Public Sub OnPackageDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.SalesOrder.SalesOrderPackageDetailColumnChangedEventArgs)
            Dim AInit As New FreelyPackageDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.SODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyPackageDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Invoicing.Sales.SalesOrder.SalesOrderEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.SODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Invoicing.Sales.SalesOrder.SalesOrderBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.SODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.SalesOrder.SalesOrderDetailColumnChangedEventArgs)

            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord

            AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.SODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub

        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Invoicing.Sales.SalesOrder.SalesOrderMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.SODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub OnFormInitialize(ByVal e As AutoCount.Invoicing.Sales.SalesOrder.FormSalesOrderEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            '  AInit.HeaderPanel = e.HeaderPanel
            '       AInit.TabControl = e.TabContro
            AInit.Form = e.Form
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.SalesOrder
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.SODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyFormInitializeEvent(e.Form, AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Invoicing.Sales.SalesOrder.FormSalesOrderEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            AInit.HeaderPanel = Nothing
            AInit.TabControl = Nothing
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.SalesOrder
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.SODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
#End Region

#Region "Delivery Order"
        Public Sub OnFormShow(ByVal e As AutoCount.Invoicing.Sales.DeliveryOrder.FormDeliveryOrderEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = Nothing
            'AInit.TabControl = Nothing
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.DeliveryOrder
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub OnNewItemPackage(ByVal e As AutoCount.Invoicing.Sales.DeliveryOrder.DeliveryOrderNewItemPackageEventArgs)
            'FreelyOnNewItemPackage
            Dim AInit As New FreelyOnNewItemPackageEvent
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyNewItemPackageEvent(AInit)
        End Sub
        Public Sub OnPackageDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.DeliveryOrder.DeliveryOrderPackageDetailColumnChangedEventArgs)
            Dim AInit As New FreelyPackageDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyPackageDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Invoicing.Sales.DeliveryOrder.DeliveryOrderEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.DeliveryOrder.DeliveryOrderDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord

            AInit.DetailRow = e.CurrentDetailRecord.DataRow


            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Invoicing.Sales.DeliveryOrder.DeliveryOrderBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Invoicing.Sales.DeliveryOrder.DeliveryOrderMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub OnFormInitialize(ByVal e As AutoCount.Invoicing.Sales.DeliveryOrder.FormDeliveryOrderEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Form = e.Form
            AInit.Document = e.DeliveryOrder
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyFormInitializeEvent(e.Form, AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Invoicing.Sales.DeliveryOrder.FormDeliveryOrderEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            AInit.HeaderPanel = Nothing
            AInit.TabControl = Nothing
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.DeliveryOrder
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub

#End Region

#Region "Invoice"
        Public Sub OnFormShow(ByVal e As AutoCount.Invoicing.Sales.Invoice.FormInvoiceEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.LayoutControl
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.Invoice
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.IVDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub OnNewItemPackage(ByVal e As AutoCount.Invoicing.Sales.Invoice.InvoiceNewItemPackageEventArgs)
            'FreelyOnNewItemPackage
            Dim AInit As New FreelyOnNewItemPackageEvent
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.IVDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyNewItemPackageEvent(AInit)
        End Sub
        Public Sub OnPackageDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.Invoice.InvoicePackageDetailColumnChangedEventArgs)
            Dim AInit As New FreelyPackageDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.IVDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyPackageDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Invoicing.Sales.Invoice.InvoiceEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.IVDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Invoicing.Sales.Invoice.InvoiceMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.IVDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Invoicing.Sales.Invoice.InvoiceBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.IVDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnFormInitialize(ByVal e As AutoCount.Invoicing.Sales.Invoice.FormInvoiceEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            '     AInit.HeaderPanel = e.HeaderPanel
            '        AInit.TabControl = e.TabControl
            AInit.Form = e.Form
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.Invoice
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.IVDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyFormInitializeEvent(e.Form, AInit)
        End Sub

        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.Invoice.InvoiceDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.IVDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Invoicing.Sales.Invoice.FormInvoiceEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.Invoice
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.IVDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub


#End Region

#Region "Cash Sales"
        Public Sub OnFormShow(ByVal e As AutoCount.Invoicing.Sales.CashSale.FormCashSaleEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.CashSale
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub OnNewItemPackage(ByVal e As AutoCount.Invoicing.Sales.CashSale.CashSaleNewItemPackageEventArgs)
            'FreelyOnNewItemPackage
            Dim AInit As New FreelyOnNewItemPackageEvent
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyNewItemPackageEvent(AInit)
        End Sub
        Public Sub OnPackageDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.CashSale.CashSalePackageDetailColumnChangedEventArgs)
            Dim AInit As New FreelyPackageDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyPackageDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Invoicing.Sales.CashSale.CashSaleEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Invoicing.Sales.CashSale.CashSaleMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.CashSale.CashSaleDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Invoicing.Sales.CashSale.CashSaleBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnFormInitialize(ByVal e As AutoCount.Invoicing.Sales.CashSale.FormCashSaleEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Form = e.Form
            AInit.Document = e.CashSale
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyFormInitializeEvent(e.Form, AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Invoicing.Sales.CashSale.FormCashSaleEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.CashSale
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
#End Region

#Region "Credit Note"
        Public Sub OnFormShow(ByVal e As AutoCount.Invoicing.Sales.CreditNote.FormCreditNoteEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.CreditNote
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub OnNewItemPackage(ByVal e As AutoCount.Invoicing.Sales.CreditNote.CreditNoteNewItemPackageEventArgs)
            'FreelyOnNewItemPackage
            Dim AInit As New FreelyOnNewItemPackageEvent
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyNewItemPackageEvent(AInit)
        End Sub
        Public Sub OnPackageDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.CreditNote.CreditNotePackageDetailColumnChangedEventArgs)
            Dim AInit As New FreelyPackageDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyPackageDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Invoicing.Sales.CreditNote.CreditNoteEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.CreditNote.CreditNoteDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.CurrentDetailRecord.DataRow


            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Invoicing.Sales.CreditNote.CreditNoteBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Invoicing.Sales.CreditNote.CreditNoteMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub OnFormInitialize(ByVal e As AutoCount.Invoicing.Sales.CreditNote.FormCreditNoteEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl

            AInit.LayoutControl = e.LayoutControl
            'AInit.TabControl = e.TabControl
            AInit.Form = e.Form
            AInit.Document = e.CreditNote
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyFormInitializeEvent(e.Form, AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Invoicing.Sales.CreditNote.FormCreditNoteEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.CreditNote
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
#End Region

#Region "Debit Note"
        Public Sub OnFormShow(ByVal e As AutoCount.Invoicing.Sales.DebitNote.FormDebitNoteEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.Document = e.DebitNote
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub OnNewItemPackage(ByVal e As AutoCount.Invoicing.Sales.DebitNote.DebitNoteNewItemPackageEventArgs)
            'FreelyOnNewItemPackage
            Dim AInit As New FreelyOnNewItemPackageEvent
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyNewItemPackageEvent(AInit)
        End Sub
        Public Sub OnPackageDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.DebitNote.DebitNotePackageDetailColumnChangedEventArgs)
            Dim AInit As New FreelyPackageDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyPackageDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Invoicing.Sales.DebitNote.DebitNoteEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.DebitNote.DebitNoteDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Invoicing.Sales.DebitNote.DebitNoteMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub OnFormInitialize(ByVal e As AutoCount.Invoicing.Sales.DebitNote.FormDebitNoteEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            ' AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Form = e.Form
            AInit.Document = e.DebitNote
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyFormInitializeEvent(e.Form, AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Invoicing.Sales.DebitNote.DebitNoteBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Invoicing.Sales.DebitNote.FormDebitNoteEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.DebitNote
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
#End Region

#Region "CancelSO"
        Public Sub OnFormShow(ByVal e As AutoCount.Invoicing.Sales.CancelSO.FormCancelSOEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.CancelSO
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub OnNewItemPackage(ByVal e As AutoCount.Invoicing.Sales.CancelSO.CancelSONewItemPackageEventArgs)
            'FreelyOnNewItemPackage
            Dim AInit As New FreelyOnNewItemPackageEvent
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyNewItemPackageEvent(AInit)
        End Sub
        Public Sub OnPackageDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.CancelSO.CancelSOPackageDetailColumnChangedEventArgs)
            Dim AInit As New FreelyPackageDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyPackageDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Invoicing.Sales.CancelSO.CancelSOEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Invoicing.Sales.CancelSO.CancelSOBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Invoicing.Sales.CancelSO.CancelSOMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub OnFormInitialize(ByVal e As AutoCount.Invoicing.Sales.CancelSO.FormCancelSOEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Form = e.Form
            AInit.Document = e.CancelSO
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyFormInitializeEvent(e.Form, AInit)
        End Sub

        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.CancelSO.CancelSODetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Invoicing.Sales.CancelSO.FormCancelSOEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.CancelSO
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
#End Region

#Region "Consignment"
        Public Sub OnFormShow(ByVal e As AutoCount.Invoicing.Sales.Consignment.FormConsignmentEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.Consignment
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CSGNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Invoicing.Sales.Consignment.ConsignmentEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CSGNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Invoicing.Sales.Consignment.ConsignmentBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CSGNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Invoicing.Sales.Consignment.ConsignmentMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CSGNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.Consignment.ConsignmentDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            '     AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CSGNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Invoicing.Sales.Consignment.FormConsignmentEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.Consignment
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CSGNDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
#End Region

#Region "Delivery Return"
        Public Sub OnFormShow(ByVal e As AutoCount.Invoicing.Sales.DeliveryReturn.FormDeliveryReturnEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.DeliveryReturn
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub OnNewItemPackage(ByVal e As AutoCount.Invoicing.Sales.DeliveryReturn.DeliveryReturnNewItemPackageEventArgs)
            'FreelyOnNewItemPackage
            Dim AInit As New FreelyOnNewItemPackageEvent
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyNewItemPackageEvent(AInit)
        End Sub
        Public Sub OnPackageDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.DeliveryReturn.DeliveryReturnPackageDetailColumnChangedEventArgs)
            Dim AInit As New FreelyPackageDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyPackageDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Invoicing.Sales.DeliveryReturn.DeliveryReturnEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Invoicing.Sales.DeliveryReturn.DeliveryReturnBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Invoicing.Sales.DeliveryReturn.DeliveryReturnMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.DeliveryReturn.DeliveryReturnDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub OnFormInitialize(ByVal e As AutoCount.Invoicing.Sales.DeliveryReturn.FormDeliveryReturnEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Form = e.Form

            AInit.Document = e.DeliveryReturn
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyFormInitializeEvent(e.Form, AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Invoicing.Sales.DeliveryReturn.FormDeliveryReturnEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.DeliveryReturn
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.DRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Sales
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
        '---------------------
#End Region
#End Region

#Region "Purchase Document"

#Region "Goods Return"
        Public Sub OnFormShow(ByVal e As AutoCount.Invoicing.Purchase.GoodsReturn.FormGoodsReturnEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.GoodsReturn
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.GTDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub OnNewItemPackage(ByVal e As AutoCount.Invoicing.Purchase.GoodsReturn.GoodsReturnNewItemPackageEventArgs)
            'FreelyOnNewItemPackage
            Dim AInit As New FreelyOnNewItemPackageEvent
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.GTDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyNewItemPackageEvent(AInit)
        End Sub
        Public Sub OnPackageDetailColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.GoodsReturn.GoodsReturnPackageDetailColumnChangedEventArgs)
            Dim AInit As New FreelyPackageDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.GTDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyPackageDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Invoicing.Purchase.GoodsReturn.GoodsReturnEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.GTDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub

        Public Sub BeforeSave(ByVal e As AutoCount.Invoicing.Purchase.GoodsReturn.GoodsReturnBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.GTDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.GoodsReturn.GoodsReturnMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.GTDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.GoodsReturn.GoodsReturnDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.GTDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub

        Public Sub OnFormInitialize(ByVal e As AutoCount.Invoicing.Purchase.GoodsReturn.FormGoodsReturnEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.GoodsReturn

            AInit.Form = e.Form
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.GTDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyFormInitializeEvent(e.Form, AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Invoicing.Purchase.GoodsReturn.FormGoodsReturnEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.GoodsReturn
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.GTDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
#End Region

#Region "Cancel PO"
        Public Sub OnFormShow(ByVal e As AutoCount.Invoicing.Purchase.CancelPO.FormCancelPOEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.CancelPO
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XPDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub OnNewItemPackage(ByVal e As AutoCount.Invoicing.Purchase.CancelPO.CancelPONewItemPackageEventArgs)
            'FreelyOnNewItemPackage
            Dim AInit As New FreelyOnNewItemPackageEvent
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XPDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyNewItemPackageEvent(AInit)
        End Sub
        Public Sub OnPackageDetailColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.CancelPO.CancelPOPackageDetailColumnChangedEventArgs)
            Dim AInit As New FreelyPackageDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XPDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyPackageDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Invoicing.Purchase.CancelPO.CancelPOEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XPDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.CancelPO.CancelPODetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XPDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.CancelPO.CancelPOMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XPDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Invoicing.Purchase.CancelPO.CancelPOBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XPDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnFormInitialize(ByVal e As AutoCount.Invoicing.Purchase.CancelPO.FormCancelPOEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Form = e.Form
            AInit.Document = e.CancelPO
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XPDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyFormInitializeEvent(e.Form, AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Invoicing.Purchase.CancelPO.FormCancelPOEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.CancelPO
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XPDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
#End Region

#Region "Purchase Return"
        Public Sub OnFormShow(ByVal e As AutoCount.Invoicing.Purchase.PurchaseReturn.FormPurchaseReturnEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.PurchaseReturn
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub OnNewItemPackage(ByVal e As AutoCount.Invoicing.Purchase.PurchaseReturn.PurchaseReturnNewItemPackageEventArgs)
            'FreelyOnNewItemPackage
            Dim AInit As New FreelyOnNewItemPackageEvent
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyNewItemPackageEvent(AInit)
        End Sub
        Public Sub OnPackageDetailColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.PurchaseReturn.PurchaseReturnPackageDetailColumnChangedEventArgs)
            Dim AInit As New FreelyPackageDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyPackageDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Invoicing.Purchase.PurchaseReturn.PurchaseReturnEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub OnFormInitialize(ByVal e As AutoCount.Invoicing.Purchase.PurchaseReturn.FormPurchaseReturnEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Form = e.Form
            AInit.Document = e.PurchaseReturn
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyFormInitializeEvent(e.Form, AInit)
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.PurchaseReturn.PurchaseReturnMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.PurchaseReturn.PurchaseReturnDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Invoicing.Purchase.PurchaseReturn.PurchaseReturnBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Invoicing.Purchase.PurchaseReturn.FormPurchaseReturnEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.PurchaseReturn
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
#End Region

#Region "Cash Purchase"
        Public Sub OnFormShow(ByVal e As AutoCount.Invoicing.Purchase.CashPurchase.FormCashPurchaseEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.CashPurchase
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CPDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub OnNewItemPackage(ByVal e As AutoCount.Invoicing.Purchase.CashPurchase.CashPurchaseNewItemPackageEventArgs)
            'FreelyOnNewItemPackage
            Dim AInit As New FreelyOnNewItemPackageEvent
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CPDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyNewItemPackageEvent(AInit)
        End Sub
        Public Sub OnPackageDetailColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.CashPurchase.CashPurchasePackageDetailColumnChangedEventArgs)
            Dim AInit As New FreelyPackageDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CPDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyPackageDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Invoicing.Purchase.CashPurchase.CashPurchaseEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CPDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Invoicing.Purchase.CashPurchase.CashPurchaseBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CPDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.CashPurchase.CashPurchaseDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CPDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.CashPurchase.CashPurchaseMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CPDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub

        Public Sub OnFormInitialize(ByVal e As AutoCount.Invoicing.Purchase.CashPurchase.FormCashPurchaseEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Form = e.Form
            AInit.Document = e.CashPurchase
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CPDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyFormInitializeEvent(e.Form, AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Invoicing.Purchase.CashPurchase.FormCashPurchaseEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.CashPurchase
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.CPDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
#End Region

#Region "Purchase Invoice"
        Public Sub OnFormShow(ByVal e As AutoCount.Invoicing.Purchase.PurchaseInvoice.FormPurchaseInvoiceEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.PurchaseInvoice
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PIDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub OnNewItemPackage(ByVal e As AutoCount.Invoicing.Purchase.PurchaseInvoice.PurchaseInvoiceNewItemPackageEventArgs)
            'FreelyOnNewItemPackage
            Dim AInit As New FreelyOnNewItemPackageEvent
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PIDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyNewItemPackageEvent(AInit)
        End Sub
        Public Sub OnPackageDetailColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.PurchaseInvoice.PurchaseInvoicePackageDetailColumnChangedEventArgs)
            Dim AInit As New FreelyPackageDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PIDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyPackageDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Invoicing.Purchase.PurchaseInvoice.PurchaseInvoiceEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PIDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Invoicing.Purchase.PurchaseInvoice.PurchaseInvoiceBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PIDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.PurchaseInvoice.PurchaseInvoiceMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PIDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub

        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.PurchaseInvoice.PurchaseInvoiceDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PIDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub

        Public Sub OnFormInitialize(ByVal e As AutoCount.Invoicing.Purchase.PurchaseInvoice.FormPurchaseInvoiceEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.PurchaseInvoice
            AInit.Form = e.Form
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PIDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyFormInitializeEvent(e.Form, AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Invoicing.Purchase.PurchaseInvoice.FormPurchaseInvoiceEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.PurchaseInvoice
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PIDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
#End Region

#Region "Goods Received Note"
        Public Sub OnFormShow(ByVal e As AutoCount.Invoicing.Purchase.GoodsReceivedNote.FormGoodsReceivedNoteEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.GoodsReceivedNote
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.GRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub OnNewItemPackage(ByVal e As AutoCount.Invoicing.Purchase.GoodsReceivedNote.GoodsReceivedNoteNewItemPackageEventArgs)
            'FreelyOnNewItemPackage
            Dim AInit As New FreelyOnNewItemPackageEvent
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.GRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyNewItemPackageEvent(AInit)
        End Sub
        Public Sub OnPackageDetailColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.GoodsReceivedNote.GoodsReceivedNotePackageDetailColumnChangedEventArgs)
            Dim AInit As New FreelyPackageDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.GRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyPackageDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Invoicing.Purchase.GoodsReceivedNote.GoodsReceivedNoteEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.GRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Invoicing.Purchase.GoodsReceivedNote.GoodsReceivedNoteBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.GRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.GoodsReceivedNote.GoodsReceivedNoteMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.GRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub OnFormInitialize(ByVal e As AutoCount.Invoicing.Purchase.GoodsReceivedNote.FormGoodsReceivedNoteEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Form = e.Form
            AInit.Document = e.GoodsReceivedNote
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.GRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyFormInitializeEvent(e.Form, AInit)
        End Sub

        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.GoodsReceivedNote.GoodsReceivedNoteDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.GRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Invoicing.Purchase.GoodsReceivedNote.FormGoodsReceivedNoteEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.GoodsReceivedNote
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.GRDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
#End Region

#Region "Purchase Order"
        Public Sub OnFormShow(ByVal e As AutoCount.Invoicing.Purchase.PurchaseOrder.FormPurchaseOrderEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.PurchaseOrder
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub OnNewItemPackage(ByVal e As AutoCount.Invoicing.Purchase.PurchaseOrder.PurchaseOrderNewItemPackageEventArgs)
            'FreelyOnNewItemPackage
            Dim AInit As New FreelyOnNewItemPackageEvent
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyNewItemPackageEvent(AInit)
        End Sub
        Public Sub OnPackageDetailColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.PurchaseOrder.PurchaseOrderPackageDetailColumnChangedEventArgs)
            Dim AInit As New FreelyPackageDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyPackageDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Invoicing.Purchase.PurchaseOrder.PurchaseOrderEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.PurchaseOrder.PurchaseOrderMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub OnFormInitialize(ByVal e As AutoCount.Invoicing.Purchase.PurchaseOrder.FormPurchaseOrderEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.PurchaseOrder
            AInit.Form = e.Form
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyFormInitializeEvent(e.Form, AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Invoicing.Purchase.PurchaseOrder.PurchaseOrderBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.PurchaseOrder.PurchaseOrderDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Invoicing.Purchase.PurchaseOrder.FormPurchaseOrderEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.PurchaseOrder
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.PODoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub

#End Region

#Region "Request Quotation"
        Public Sub OnFormShow(ByVal e As AutoCount.Invoicing.Purchase.RequestQuotation.FormRequestQuotationEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.RequestQuotation
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.RQDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub OnNewItemPackage(ByVal e As AutoCount.Invoicing.Purchase.RequestQuotation.RequestQuotationNewItemPackageEventArgs)
            'FreelyOnNewItemPackage
            Dim AInit As New FreelyOnNewItemPackageEvent
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.RQDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyNewItemPackageEvent(AInit)
        End Sub
        Public Sub OnPackageDetailColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.RequestQuotation.RequestQuotationPackageDetailColumnChangedEventArgs)
            Dim AInit As New FreelyPackageDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.PackageDetailRecord = e.PackageMasterRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.PackageMasterRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.RQDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyPackageDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Invoicing.Purchase.RequestQuotation.RequestQuotationEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.RQDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Invoicing.Purchase.RequestQuotation.RequestQuotationBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.RQDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.RequestQuotation.RequestQuotationMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.RQDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub OnFormInitialize(ByVal e As AutoCount.Invoicing.Purchase.RequestQuotation.FormRequestQuotationEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.RequestQuotation
            AInit.Form = e.Form
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.RQDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyFormInitializeEvent(e.Form, AInit)
        End Sub

        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.RequestQuotation.RequestQuotationDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.RQDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Invoicing.Purchase.RequestQuotation.FormRequestQuotationEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.RequestQuotation
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.RQDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Purchase
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
#End Region

#End Region

#Region "Stock Document"
        'XFER
        '----------------

#Region "Stock Write Off"
        Public Sub OnFormShow(ByVal e As AutoCount.Stock.StockWriteOff.FormStockWriteOffEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.StockWriteOff
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.WOFFDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Stock.StockWriteOff.StockWriteOffEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.WOFFDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Stock.StockWriteOff.StockWriteOffBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.WOFFDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Stock.StockWriteOff.StockWriteOffMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.WOFFDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Stock.StockWriteOff.StockWriteOffDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            '   AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.WOFFDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub

        Public Sub OnFormInitialize(ByVal e As AutoCount.Stock.StockWriteOff.FormStockWriteOffEntry.FormInitializeEventArgs)

            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Form = e.Form
            AInit.Document = Nothing
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.WOFFDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyFormInitializeEvent(e.Form, AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Stock.StockWriteOff.FormStockWriteOffEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.StockWriteOff
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.WOFFDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
#End Region

#Region "Stock Transfer"
        Public Sub OnFormShow(ByVal e As AutoCount.Stock.StockTransfer.FormStockTransferEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.StockTransfer
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XFERDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Stock.StockTransfer.StockTransferEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XFERDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Stock.StockTransfer.StockTransferBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XFERDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Stock.StockTransfer.StockTransferMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XFERDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Stock.StockTransfer.StockTransferDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            '  AInit.DetailRow = e.CurrentDetailRecord.DataRow


            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XFERDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub

        Public Sub OnFormInitialize(ByVal e As AutoCount.Stock.StockTransfer.FormStockTransferEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Form = e.Form
            AInit.Document = e.StockTransfer
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XFERDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyFormInitializeEvent(AInit, AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Stock.StockTransfer.FormStockTransferEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.StockTransfer
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.XFERDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
#End Region

#Region "Stock Receive"
        Public Sub OnFormShow(ByVal e As AutoCount.Stock.StockReceive.FormStockReceiveEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.StockReceive
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.RCVDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Stock.StockReceive.StockReceiveEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.RCVDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Stock.StockReceive.StockReceiveBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.RCVDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Stock.StockReceive.StockReceiveMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.RCVDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub OnFormInitialize(ByVal e As AutoCount.Stock.StockReceive.FormStockReceiveEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            AInit.LayoutControl = e.LayoutControl
            '  AInit.TabControl = e.TabControl
            AInit.Form = e.Form
            AInit.Document = e.StockReceive
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.RCVDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyFormInitializeEvent(AInit, AInit)
        End Sub
        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Stock.StockReceive.StockReceiveDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            '  AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.RCVDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Stock.StockReceive.FormStockReceiveEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.StockReceive
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.RCVDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
#End Region

#Region "Stock Issue"
        Public Sub OnFormShow(ByVal e As AutoCount.Stock.StockIssue.FormStockIssueEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.StockIssue
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.ISSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Stock.StockIssue.StockIssueEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.ISSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Stock.StockIssue.StockIssueBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.ISSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Stock.StockIssue.StockIssueMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.ISSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub OnFormInitialize(ByVal e As AutoCount.Stock.StockIssue.FormStockIssueEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            '           AInit.HeaderPanel = e.HeaderPanel
            '     AInit.TabControl = e.TabControl
            AInit.Form = e.Form
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.StockIssue
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.ISSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyFormInitializeEvent(AInit, AInit)
        End Sub
        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Stock.StockIssue.StockIssueDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            ' AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.ISSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Stock.StockIssue.FormStockIssueEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.StockIssue
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.ISSDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
#End Region

#Region "Stock Adjustment"
        Public Sub OnFormShow(ByVal e As AutoCount.Stock.StockAdjustment.FormStockAdjustmentEntry.FormShowEventArgs)
            Dim AInit As New FreelyOnFormShowEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.StockAdjustment
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.ADJDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyOnFormShowEvent(AInit)
        End Sub
        Public Sub AfterSave(ByVal e As AutoCount.Stock.StockAdjustment.StockAdjustmentEventArgs)
            Dim AInit As New FreelyAfterSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.ADJDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyAfterSaveEvent(AInit)
        End Sub
        Public Sub BeforeSave(ByVal e As AutoCount.Stock.StockAdjustment.StockAdjustmentBeforeSaveEventArgs)
            Dim AInit As New FreelyBeforeSaveEvent
            AInit.DBSetting = e.DBSetting
            AInit.MasterRecord = e.MasterRecord
            AddHandler AInit.RaiseAbortSave, AddressOf e.AbortSave
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.ADJDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyBeforeSaveEvent(AInit)
            e.ErrorMessage = AInit.ErrorMessage
        End Sub
        Public Sub OnMasterColumnChanged(ByVal e As AutoCount.Stock.StockAdjustment.StockAdjustmentMasterColumnChangedEventArgs)
            Dim AInit As New FreelyMasterChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.MasterRecord = e.MasterRecord

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.ADJDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyMasterColumnChangedEvent(AInit)
        End Sub
        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Stock.StockAdjustment.StockAdjustmentDetailColumnChangedEventArgs)
            Dim AInit As New FreelyDetailChangedEvent
            AInit.DBSetting = e.DBSetting
            AInit.ColumnName = e.ChangedColumnName
            AInit.DetailRecord = e.CurrentDetailRecord
            AInit.MasterRecord = e.MasterRecord
            '    AInit.DetailRow = e.CurrentDetailRecord.DataRow

            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.ADJDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyDetailColumnChangedEvent(AInit)
        End Sub

        Public Sub OnFormInitialize(ByVal e As AutoCount.Stock.StockAdjustment.FormStockAdjustmentEntry.FormInitializeEventArgs)
            Dim AInit As New FreelyInitializeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            '  AInit.HeaderPanel = e.HeaderPanel
            ' AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Form = e.Form
            AInit.Document = e.StockAdjustment
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.ADJDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyFormInitializeEvent(AInit, AInit)
        End Sub
        Public Sub OnSwitchToEditMode(ByVal e As AutoCount.Stock.StockAdjustment.FormStockAdjustmentEntry.FormEventArgs)
            Dim AInit As New FreelyOnSwtichEditModeEvent
            AInit.DBSetting = e.DBSetting
            AInit.DetailTable = e.DetailTable
            AInit.EditMode = e.EditWindowMode
            AInit.GridControl = e.GridControl
            'AInit.HeaderPanel = e.HeaderPanel
            'AInit.TabControl = e.TabControl
            AInit.LayoutControl = e.LayoutControl
            AInit.Document = e.StockAdjustment
            AInit.AutoCountSource = e
            AInit.DocumentType = Enumeration.FreelyEnum.EnumDocType.ADJDoc
            AInit.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.Stock
            RaiseEvent FreelyOnSwtichEditModeEvent(AInit)
        End Sub
#End Region
#End Region
        Protected MustOverride Sub FreelyInitializeEvent(ByVal Sender As Object, ByVal e As FreelyInitializeEvent) Handles Me.FreelyFormInitializeEvent
        Protected MustOverride Sub FreelyOnFormShow(ByVal e As FreelyOnFormShowEvent) Handles Me.FreelyOnFormShowEvent
        Protected MustOverride Sub FreelyDetailChangedEvent(ByVal e As FreelyDetailChangedEvent) Handles Me.FreelyDetailColumnChangedEvent
        Protected MustOverride Sub FreelyMasterChangedEvent(ByVal e As FreelyMasterChangedEvent) Handles Me.FreelyMasterColumnChangedEvent
        Protected MustOverride Sub FreelyBeforeSaveEventArgs(ByVal e As FreelyBeforeSaveEvent) Handles Me.FreelyBeforeSaveEvent
        Protected MustOverride Sub FreelyAfterSaveEventArgs(ByVal e As FreelyAfterSaveEvent) Handles Me.FreelyAfterSaveEvent
        Protected MustOverride Sub FreelyPackageDetailChangedEvent(ByVal e As FreelyPackageDetailChangedEvent) Handles Me.FreelyPackageDetailColumnChangedEvent
        Protected MustOverride Sub FreelyOnNewItemPackageEvent(ByVal e As FreelyOnNewItemPackageEvent) Handles Me.FreelyNewItemPackageEvent
        Protected MustOverride Sub FreelyOnSwtichEditMode(ByVal e As FreelyOnSwtichEditModeEvent) Handles Me.FreelyOnSwtichEditModeEvent
    End Class

    Public Class FreelyPackageDetailChangedEvent
        Public Property ColumnName As String = String.Empty
        Public Property PackageDetailRecord As Object = Nothing
        Public Property DBSetting As AutoCount.Data.DBSetting = Nothing
        Public Property MasterRecord As Object = Nothing
        Public Property DetailRow As DataRow
        Public Property DocumentType As Freely.Enumeration.FreelyEnum.EnumDocType = Enumeration.FreelyEnum.EnumDocType.None
        Public Property DocumentTypeGroup As Freely.Enumeration.FreelyEnum.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.None
        Public Property AutoCountSource As Object = Nothing
        Public ReadOnly Property CreatedBy As String
            Get
                Return "Lai Wei Loong 2015"
            End Get
        End Property
    End Class
    Public Class FreelyOnFormShowEvent
        Public Property DBSetting As AutoCount.Data.DBSetting
        Public Property DetailTable As DataTable
        Public Property EditMode As AutoCount.Document.EditWindowMode
        Public Property GridControl As DevExpress.XtraGrid.GridControl
        Public Property HeaderPanel As DevExpress.XtraEditors.PanelControl
        Public Property TabControl As DevExpress.XtraTab.XtraTabControl
        Public Property Document As Object
        Public Property AutoCountSource As Object
        Public Property DocumentType As Freely.Enumeration.FreelyEnum.EnumDocType = Enumeration.FreelyEnum.EnumDocType.None
        Public Property DocumentTypeGroup As Freely.Enumeration.FreelyEnum.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.None
        Public Property LayoutControl As DevExpress.XtraLayout.LayoutControl
        Public ReadOnly Property CreatedBy As String
            Get
                Return "Lai Wei Loong 2015"
            End Get
        End Property
    End Class
    Public Class FreelyOnNewItemPackageEvent
        Public Property PackageDetailRecord As Object = Nothing
        Public Property DetailRow As DataRow
        Public Property DocumentType As Freely.Enumeration.FreelyEnum.EnumDocType = Enumeration.FreelyEnum.EnumDocType.None
        Public Property DocumentTypeGroup As Freely.Enumeration.FreelyEnum.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.None
        Public Property AutoCountSource As Object = Nothing
        Public ReadOnly Property CreatedBy As String
            Get
                Return "Lai Wei Loong 2015"
            End Get
        End Property
    End Class
    Public Class FreelyAfterSaveEvent
        Public Property DBSetting As AutoCount.Data.DBSetting = Nothing
        Public Property MasterRecord As Object = Nothing
        Public Property DocumentType As Freely.Enumeration.FreelyEnum.EnumDocType = Enumeration.FreelyEnum.EnumDocType.None
        Public Property DocumentTypeGroup As Freely.Enumeration.FreelyEnum.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.None
        Public Property AutoCountSource As Object = Nothing
        Public ReadOnly Property CreatedBy As String
            Get
                Return "Lai Wei Loong 2015"
            End Get
        End Property
    End Class
    Public Class FreelyBeforeSaveEvent
        Public Event RaiseAbortSave()
        Public Sub AbortSave()
            RaiseEvent RaiseAbortSave()
        End Sub
        Public Property ErrorMessage As String
        Public Property DBSetting As AutoCount.Data.DBSetting = Nothing
        Public Property MasterRecord As Object = Nothing
        Public Property DocumentType As Freely.Enumeration.FreelyEnum.EnumDocType = Enumeration.FreelyEnum.EnumDocType.None
        Public Property DocumentTypeGroup As Freely.Enumeration.FreelyEnum.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.None
        Public Property AutoCountSource As Object = Nothing
        Public ReadOnly Property CreatedBy As String
            Get
                Return "Lai Wei Loong 2015"
            End Get
        End Property
    End Class
    Public Class FreelyMasterChangedEvent
        Public Property ColumnName As String = String.Empty
        Public Property DBSetting As AutoCount.Data.DBSetting = Nothing
        Public Property MasterRecord As Object = Nothing
        Public Property DocumentType As Freely.Enumeration.FreelyEnum.EnumDocType = Enumeration.FreelyEnum.EnumDocType.None
        Public Property DocumentTypeGroup As Freely.Enumeration.FreelyEnum.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.None
        Public Property AutoCountSource As Object = Nothing
        Public ReadOnly Property CreatedBy As String
            Get
                Return "Lai Wei Loong 2015"
            End Get
        End Property
    End Class
    Public Class FreelyDetailChangedEvent
        Public Property ColumnName As String = String.Empty
        Public Property DetailRecord As Object = Nothing
        Public Property DBSetting As AutoCount.Data.DBSetting = Nothing
        Public Property MasterRecord As Object = Nothing
        Public Property DetailRow As DataRow
        Public Property DocumentType As Freely.Enumeration.FreelyEnum.EnumDocType = Enumeration.FreelyEnum.EnumDocType.None
        Public Property DocumentTypeGroup As Freely.Enumeration.FreelyEnum.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.None
        Public Property AutoCountSource As Object = Nothing
        Public ReadOnly Property CreatedBy As String
            Get
                Return "Lai Wei Loong 2015"
            End Get
        End Property
    End Class
    Public Class FreelyInitializeEvent
        Public Property DBSetting As AutoCount.Data.DBSetting
        Public Property DetailTable As DataTable
        Public Property EditMode As AutoCount.Document.EditWindowMode
        Public Property GridControl As DevExpress.XtraGrid.GridControl
        Public Property HeaderPanel As DevExpress.XtraEditors.PanelControl
        Public Property TabControl As DevExpress.XtraTab.XtraTabControl
        Public Property Document As Object
        Public Property LayoutControl As Object
        Public Property Form As Object
        Public Property AutoCountSource As Object
        Public Property DocumentType As Freely.Enumeration.FreelyEnum.EnumDocType = Enumeration.FreelyEnum.EnumDocType.None
        Public Property DocumentTypeGroup As Freely.Enumeration.FreelyEnum.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.None
        Public ReadOnly Property CreatedBy As String
            Get
                Return "Lai Wei Loong 2015"
            End Get
        End Property
    End Class
    Public Class FreelyOnSwtichEditModeEvent
        Public Property DBSetting As AutoCount.Data.DBSetting
        Public Property DetailTable As DataTable
        Public Property EditMode As AutoCount.Document.EditWindowMode
        Public Property GridControl As DevExpress.XtraGrid.GridControl
        Public Property HeaderPanel As DevExpress.XtraEditors.PanelControl
        Public Property TabControl As DevExpress.XtraTab.XtraTabControl
        Public Property Document As Object
        Public Property AutoCountSource As Object
        Public Property DocumentType As Freely.Enumeration.FreelyEnum.EnumDocType = Enumeration.FreelyEnum.EnumDocType.None
        Public Property DocumentTypeGroup As Freely.Enumeration.FreelyEnum.DocumentTypeGroup = Enumeration.FreelyEnum.DocumentTypeGroup.None
        Public Property LayoutControl As DevExpress.XtraLayout.LayoutControl
        Public ReadOnly Property CreatedBy As String
            Get
                Return "Lai Wei Loong 2015"
            End Get
        End Property
    End Class
End Namespace