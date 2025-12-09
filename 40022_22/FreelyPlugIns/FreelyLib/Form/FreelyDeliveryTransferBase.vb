Public MustInherit Class FreelyDeliveryTransferBase
    Inherits DevExpress.XtraEditors.XtraForm

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'FreelyDeliveryTransferBase
        '
        Me.ClientSize = New System.Drawing.Size(420, 300)
        Me.Name = "FreelyDeliveryTransferBase"
        Me.ResumeLayout(False)

    End Sub

    Public Enum TransferMode
        FullTransfer = 0
        PartialTransfer = 1
        None = -1
    End Enum

    Public Enum TransferDocument
        DeliveryOder = 0
        Custom = 1
    End Enum

    Public Property PartialDocument As DataTable
    Public Property FullDocument As DataTable

    Public Property PartilDataTable As DataTable
    Public Property InitMasterSQL As String = ""
    Public Property InitDetailSQL As String = ""
    Public Property Mode As TransferMode = TransferMode.None
    Public Property TransferDoc As TransferDocument = TransferDocument.DeliveryOder
    Public Property DetailFilter As String = "RemainingSmallestQty  > 0"

    Public Property FromDocType As String = ""

 
    Protected MustOverride Function GetPartialTransferDetailKeys() As List(Of Long)
    Protected MustOverride Sub SetupUOMValue()
    Protected MustOverride Sub InitFullTransfer()
    Protected MustOverride Sub SetupLookupEdit()

    Protected MustOverride Sub FilterItemUOM()

    Protected MustOverride Sub InitPartialTransfer()

    Protected MustOverride Sub Init()
    Protected MustOverride Function VerifyPartial() As Boolean
    Protected MustOverride Sub PartialColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
    Protected MustOverride Sub TabMasterPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs)

    Protected MustOverride Sub Partial_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs)

    Protected MustOverride Sub Partial_FocusedRowChanged(ByVal sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)

    Protected MustOverride Sub ApplyEvent(sender As Object, e As EventArgs)
    Protected MustOverride Sub CloseEvent(sender As Object, e As EventArgs)
    Protected MustOverride Function CalculateModifiedUnitPrice(ByVal originalRate As Decimal, ByVal rate As Decimal, ByVal unitprice As Decimal) As Decimal
    Protected MustOverride Function CalculateRemainingQtyBaseRate(ByVal remainingSmallestQty As Decimal, ByVal rate As Decimal) As Decimal
End Class
