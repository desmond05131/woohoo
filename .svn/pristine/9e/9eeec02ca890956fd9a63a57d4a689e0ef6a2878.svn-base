Namespace Freely.Standard.Forms.LookUpBuilder

    Public Class FreelyLookupBuilder
        Dim _UserSession As AutoCount.Authentication.UserSession
        Dim _DBSetting As AutoCount.Data.DBSetting

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
        End Sub
        ''' <summary>
        ''' How To use
        '''    Dim ALookupList As Freely.Standard.Forms.LookUpBuilder.FreelyInitLookUpEditBuilder() = {
        '''New Freely.Standard.Forms.LookUpBuilder.FreelyInitLookUpEditBuilder With {.RepositoryItemLookUpEdit = Me.LookUpEdit1.Properties, .LookupType = Freely.Standard.Forms.LookUpBuilder.FreelyLookupBuilder.LookupType.DisplayTerm}
        '''                                                        }
        '''        AFreelyFormHelper.FreelyLookupBuilder.BuildLookupBuilder(ALookupList.ToArray)
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub BuildLookupBuilder(ByVal AFreelyLookUpEditBuilders As FreelyInitLookUpEditBuilder())
            For Each objBuilder As FreelyInitLookUpEditBuilder In AFreelyLookUpEditBuilders
                Me.BuildLookupBuilder(objBuilder)
            Next
        End Sub
        Public Sub BuildLookupBuilder(ByVal AFreelyLookUpEditBuilder As FreelyInitLookUpEditBuilder)
            Me.BuildLookupBuilder(AFreelyLookUpEditBuilder.RepositoryItemLookUpEdit,
                                  AFreelyLookUpEditBuilder.LookupType,
                                  AFreelyLookUpEditBuilder.AccNo,
                                  AFreelyLookUpEditBuilder.CurrencyCode)
        End Sub
        Public Sub BuildLookupBuilder(ByVal AItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit,
                                      ByVal ALookupType As LookupType,
                                      Optional AAccNo As String = "",
                                       Optional ACurrencyCode As String = "")
            Select Case ALookupType
                Case LookupType.Account
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.AccountLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.AccType
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.AccTypeLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.AccumulatedDepreciationAccount
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.AccumulatedDepreciationAccountLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.Address
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.AddressLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.AllAccount
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.AllAccountLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.AllControlAccount
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.AllControlAccountLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.AllDepartments
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.AllDepartmentsLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.AllLocations
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.AllLocationsLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.AllProjects
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.AllProjectsLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.APCN
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.APCNLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.APDeposit
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.APDepositLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.APDN
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.APDNLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.APInvoice
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.APInvoiceLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.APPayment
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.APPaymentLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.APRefund
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.APRefundLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.ARAPContra
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.ARAPContraLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.ARCN
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.ARCNLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.ARDeposit
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.ARDepositLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.ARDN
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.ARDNLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.Area
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.AreaLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.ARInvoice
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.ARInvoiceLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.ARPayment
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.ARPaymentLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.ARRefund
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.ARRefundLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.BalanceStockAccount
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.BalanceStockAccountLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.BankAccount
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.BankAccountLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.BankCashPaymentMethod
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.BankCashPaymentMethodLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.BaseAccount
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.BaseAccountLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.BaseItem
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.BaseItemLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.BasicItem
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.BasicItemLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.BasicItemLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.BatchItem
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.BatchItemLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.BatchItemLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.BOMItem
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.BOMItemLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.BOMItemLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.BOMItem
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.BOMItemSelectorLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.BOMItemSelectorLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.BOMSubItem
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.BOMSubItemLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.BOMSubItemLookupEditBuilder.Create()
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.BonusPointAdjustment
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.BonusPointAdjustmentLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.BonusPointAdjustmentLookupEditBuilder.Create()
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.BonusPointRedemption
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.BonusPointRedemptionLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.BonusPointRedemptionLookupEditBuilder.Create()
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.BranchAddress
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.BranchAddressLookupEditBuilder(AAccNo)
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.CancelPO
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.CancelPOLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.CancelPOLookupEditBuilder.Create()
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.CancelSO
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.CancelSOLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.CancelSOLookupEditBuilder.Create()
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.CashBookEntryAccount
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.CashBookEntryAccountLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.CashBookEntrySearchAccount
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.CashBookEntrySearchAccountLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.CashBook
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.CashBookLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.CashFlowCategory
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.CashFlowCategoryLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.CashPurchase
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.CashPurchaseLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.CashPurchaseLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.CashSale
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.CashSaleLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.CashSaleLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.CloseStockAccount
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.CloseStockAccountLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.CNType
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.CNTypeLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.Consignment
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.ConsignmentLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.ConsignmentLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.ConsignmentReturn
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.ConsignmentReturnLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.ConsignmentReturnLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.CostControlAccount
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.CostControlAccountLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.CreditNote
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.CreditNoteLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.CreditNoteLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.CreditorControl
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.CreditorControlLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.Creditor
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.CreditorLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.CreditorType
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.CreditorTypeLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.CreditorTypeSelector
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.CreditorTypeSelectorLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.CurrencyGainLossAccount
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.CurrencyGainLossAccountLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.Currency
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.CurrencyLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.DebtorAndCreditor
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.DebtorAndCreditorLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.DebtorControl
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.DebtorControlLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.DebtorNCreditor
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.DebtorNCreditorBaseLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.DebtorType
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.DebtorTypeLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.DeliveryOrder
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.DeliveryOrderLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.DeliveryOrderLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.DeliveryReturn
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.DeliveryReturnLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.DeliveryReturnLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.Department
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.DepartmentLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.DepartmentSelector
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.DepartmentSelectorLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.DepositPaymentMethod
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.DepositPaymentMethodLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.DiscontinueItem
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.DiscontinueItemLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.DiscontinueItemLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.DisplayTerm
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.DisplayTermLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.DistinctItemBatch
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.DistinctItemBatchLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.DNType
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.DNTypeLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.DocNoFormat
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.DocNoFormatLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.DocumentType
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.DocumentTypeLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.ItemDescSelector
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.ItemDescSelectorLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.ItemDescSelectorLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.ItemGroup
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.ItemGroupLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.ItemGroupLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.Item
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.ItemLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.ItemLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.ItemPackage
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.ItemPackageLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.ItemSelector
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.ItemSelectorLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.ItemSelectorLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.ItemType
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.ItemTypeLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.ItemTypeLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.ItemUOM
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.ItemUOMLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.MultiUOMItem
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.MultiUOMItemLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.MyBranchAddress
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.MyBranchAddressLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.PaymentMethodAccount
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.PaymentMethodAccountLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.PostingAccountGroup
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.PostingAccountGroupLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.PriceCategory
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.PriceCategoryLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.Project
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.ProjectLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.ProjectSelector
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.ProjectSelectorLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.PurchaseAgent
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.PurchaseAgentLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.PurchaseAgentSelector
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.PurchaseAgentSelectorLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.PurchaseConsignment
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.PurchaseConsignmentLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.PurchaseConsignmentLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.PurchaseConsignmentReturn
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.PurchaseConsignmentReturnLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.PurchaseConsignmentReturnLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.PurchaseCurrency
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.PurchaseCurrencyLookupEditBuilder(ACurrencyCode)
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.PurchaseInvoice
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.PurchaseInvoiceLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.PurchaseInvoiceLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.PurchaseOrder
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.PurchaseOrderLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.PurchaseOrderLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.PurchaseRequest
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.PurchaseRequestLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.PurchaseRequestLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.PurchaseReturn
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.PurchaseReturnLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.PurchaseReturnLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.OpenStockAccount
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.OpenStockAccountLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.SalesAgent
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.SalesAgentLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.SalesAgentSelector
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.SalesAgentSelectorLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.SalesCurrency
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.SalesCurrencyLookupEditBuilder(ACurrencyCode)
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.SalesOrder
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.SalesOrderLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.SalesOrderLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.SerialNumberItem
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.SerialNumberItemLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.SerialNumberItemLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.ShippingMethod
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.ShippingMethodLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.StockAdjustment
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.StockAdjustmentLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.StockAdjustmentLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.StockAssembly
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.StockAssemblyLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.StockAssemblyOrder
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.StockAssemblyOrderLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.StockDisassembly
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.StockDisassemblyLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.StockIssue
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.StockIssueLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.StockIssueLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.StockReceive
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.StockReceiveLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.StockReceiveLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.StockSet
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.StockSetLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.StockTake
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.StockTakeLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.StockTransfer
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.StockTransferLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.StockTransferLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.StockUOMConversion
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.StockUOMConversionLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.StockUOMConversionLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.StockWriteOff
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.StockWriteOffLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.StockWriteOffLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.SupplyPurchase
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.SupplyPurchaseLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.SystemCurrency
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.SystemCurrencyLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.TaxCode
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.TaxCodeLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.TaxDocNoFormat
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.TaxDocNoFormatLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.Tariff
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.TariffLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.UpdateStockCost
                    Dim ABuilder As AutoCount.XtraUtils.LookupEditBuilder.UpdateStockCostLookupEditBuilder
                    ABuilder = AutoCount.XtraUtils.LookupEditBuilder.UpdateStockCostLookupEditBuilder.Create
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.UserGroup
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.UserGroupLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.User
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.UserLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)
                Case LookupType.UsersTemplateLookupEditBuilder
                    Dim ABuilder As New AutoCount.XtraUtils.LookupEditBuilder.UsersTemplateLookupEditBuilder
                    ABuilder.BuildLookupEdit(AItemLookUpEdit, Me.UserSession)

            End Select
        End Sub


        Public Enum LookupType
            None
            Account
            AccType
            AccumulatedDepreciationAccount
            Address
            AllAccount
            AllControlAccount
            AllDepartments
            AllLocations
            AllProjects
            APCN
            APDeposit
            APDN
            APInvoice
            APPayment
            APRefund
            ARAPContra
            ARCN
            ARDeposit
            ARDN
            Area
            ARInvoice
            ARPayment
            ARRefund
            BalanceStockAccount
            BankAccount
            BankCashPaymentMethod
            BaseAccount
            BaseItem
            BasicItem
            BatchItem
            BOMItem
            BOMItemSelector
            BOMSubItem
            BonusPointAdjustment
            BonusPointRedemption
            BranchAddress
            CancelPO
            CancelSO
            CashBookEntryAccount
            CashBookEntrySearchAccount
            CashBook
            CashFlowCategory
            CashPurchase
            CashSale
            CloseStockAccount
            CNType
            Consignment
            ConsignmentReturn
            CostControlAccount
            CreditNote
            CreditorControl
            Creditor
            CreditorType
            CreditorTypeSelector
            CurrencyGainLossAccount
            Currency
            DebtorAndCreditor
            DebtorControl
            DebtorNCreditor
            DebtorType
            DeliveryOrder
            DeliveryReturn
            Department
            DepartmentSelector
            DepositPaymentMethod
            DiscontinueItem
            DisplayTerm
            DistinctItemBatch
            DNType
            DocNoFormat
            DocumentType
            ItemDescSelector
            ItemGroup
            Item
            ItemPackage
            ItemSelector
            ItemType
            ItemUOM
            MultiUOMItem
            MyBranchAddress
            OpenStockAccount
            PaymentMethodAccount
            PostingAccountGroup
            PriceCategory
            Project
            ProjectSelector
            PurchaseAgent
            PurchaseAgentSelector
            PurchaseConsignment
            PurchaseConsignmentReturn
            PurchaseCurrency
            PurchaseInvoice
            PurchaseOrder
            PurchaseRequest
            PurchaseReturn
            SalesAgent
            SalesAgentSelector
            SalesCurrency
            SalesOrder
            SerialNumberItem
            ShippingMethod
            StockAdjustment
            StockAssembly
            StockAssemblyOrder
            StockDisassembly
            StockIssue
            StockReceive
            StockSet
            StockTake
            StockTransfer
            StockUOMConversion
            StockWriteOff
            SupplyPurchase
            SystemCurrency
            TaxCode
            TaxDocNoFormat
            Tariff
            UpdateStockCost
            UserGroup
            User
            UsersTemplateLookupEditBuilder

        End Enum
    End Class
    Public Class FreelyInitLookUpEditBuilder
        Public Property RepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Public Property LookupType As FreelyLookupBuilder.LookupType
        Public Property AccNo As String = ""
        Public Property CurrencyCode As String = ""
        Public Sub New()

        End Sub
        Public Sub New(ByVal ALookupEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit,
                       ByVal ALookupType As FreelyLookupBuilder.LookupType,
                       Optional ByVal AAccNo As String = "",
                       Optional ByVal ACurrencyCode As String = "")
            RepositoryItemLookUpEdit = ALookupEdit
            LookupType = ALookupType
            AccNo = AAccNo
            CurrencyCode = ACurrencyCode
        End Sub
    End Class

End Namespace