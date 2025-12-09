Imports AutoCount.Utils

Namespace Freely.FormUI
    Public Class FreelyDeliveryTransfer

        Private _Title As String = "Transfer From Document"


        Public Property Title As String
            Get
                Return _Title
            End Get
            Set(value As String)
                _Title = value
                Me.Text = _Title
            End Set
        End Property
        Public Property DocumentDataSet As DataSet
        Public DBSetting As AutoCount.Data.DBSetting
        Public UserSession As AutoCount.Authentication.UserSession
        Private StockHelper As AutoCount.Stock.StockHelper
        Private DecimalSetting As AutoCount.Settings.DecimalSetting
        Public ItemUOMLookupEditBuilder As AutoCount.XtraUtils.LookupEditBuilder.ItemUOMLookupEditBuilder


        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Public Sub New(ByVal AUserSession As AutoCount.Authentication.UserSession, ByVal AConn As AutoCount.Data.DBSetting, ByVal ARecordTable As DataSet)

            ' This call is required by the designer.
            InitializeComponent()

            Try
                ' Add any initialization after the InitializeComponent() call.
                DocumentDataSet = ARecordTable
                DBSetting = AConn
                StockHelper = New AutoCount.Stock.StockHelper()
                DecimalSetting = AutoCount.Settings.DecimalSetting.GetOrCreate(AConn)
                UserSession = AUserSession


                Dim formControlUtil As New AutoCount.XtraUtils.FormControlUtil(Me.DBSetting, False)
                formControlUtil.AddField("Qty", "Quantity")
                formControlUtil.AddField("FOCQty", "Quantity")
                formControlUtil.AddField("RemainingFOCQty", "Quantity")
                formControlUtil.AddField("NewFOCQty", "Quantity")
                formControlUtil.AddField("NewQty", "Quantity")
                formControlUtil.AddField("DocDate", "Date")
                formControlUtil.AddField("DeliveryDate", "Date")
                formControlUtil.AddField("UnitPrice", "Price")
                formControlUtil.AddField("SubTotal", "Currency")
                formControlUtil.AddField("NetTotal", "Currency")
                formControlUtil.AddField("YourPODate", "Date")
                formControlUtil.AddField("Rate", "Quantity")
                formControlUtil.InitControls(Me)

                AddHandler Me.dtPartialDocument.ColumnChanged, AddressOf PartialColumnChanged


                Dim AIng As New Utli.FreelyUtli(UserSession, Me.DBSetting)
                AIng.AddLayoutManager(Me.gvFull, Me.Name)
                AIng.AddLayoutManager(Me.gvPartial, Me.Name)
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
            End Try

        End Sub





        Protected Overrides Sub Init()
            Dim iTabPageIndex As Integer = Me.TabMaster.SelectedTabPageIndex
            If (iTabPageIndex < 0 Or iTabPageIndex > 1) Then
                iTabPageIndex = 0
                Return
            End If
            Me.TabMaster.SelectedTabPageIndex = iTabPageIndex




            If iTabPageIndex = 0 Then
                InitFullTransfer()
            Else
                InitPartialTransfer()
            End If

        End Sub

        Protected Overrides Sub PartialColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If sender IsNot Nothing Then
                If (e.Column.ColumnName = "Transfer") Then
                    Dim bTransfer As Boolean = e.Row.Item("Transfer").ToString = "Y"
                    If Not bTransfer Then
                        e.Row.BeginEdit()
                        e.Row("NewQty") = DBNull.Value
                        e.Row.EndEdit()
                        Return
                    Else
                        If e.Row.Item("NewQty").ToString = "" Then
                            Dim iNewQty As Decimal = IIf(e.Row.Item("NewQty") Is DBNull.Value, 0, e.Row.Item("NewQty"))
                            e.Row.BeginEdit()
                            e.Row("NewQty") = e.Row("RemainingQty")
                        End If
                    End If
                ElseIf e.Column.ColumnName = "NewQty" Then
                    e.Row.Item("Transfer") = "Y"

                ElseIf e.Column.ColumnName = "NewUOM" Then
                    Dim sNewUOM As String = e.Row("NewUOM").ToString()
                    Dim sItemCode As String = e.Row("ItemCode").ToString()

                    Dim itemUOMRate As Decimal = AutoCount.Stock.StockHelper.GetItemUOMRate(Me.DBSetting, sItemCode, sNewUOM)
                    If (itemUOMRate = 0) Then
                        itemUOMRate = Convert.ToDecimal(e.Row("Rate"))
                    End If

                    Dim iRemainingSmallestQty As Decimal = IIf(e.Row("RemainingSmallestQty") Is DBNull.Value, 0, e.Row("RemainingSmallestQty"))
                    Dim iUnitPrice As Decimal = DecimalSetting.RoundSalesPrice(e.Row.Item("UnitPrice", DataRowVersion.Original))
                    Dim iRate As Decimal = IIf(e.Row.Item("Rate") Is DBNull.Value, 0, e.Row.Item("Rate"))

                    e.Row.BeginEdit()
                    e.Row("ModifiedUnitPrice") = CalculateModifiedUnitPrice(iRate, itemUOMRate, iUnitPrice)
                    e.Row("UnitPrice") = e.Row("ModifiedUnitPrice")
                    e.Row("RemainingQty") = CalculateRemainingQtyBaseRate(iRemainingSmallestQty, itemUOMRate)
                    e.Row("RemainingUOM") = e.Row("NewUOM")
                End If
            End If

        End Sub

        Protected Overrides Function CalculateModifiedUnitPrice(ByVal originalRate As Decimal, ByVal rate As Decimal, ByVal unitprice As Decimal) As Decimal
            If originalRate = 0 Then
                Return unitprice
            Else
                Return unitprice * rate / originalRate
            End If
        End Function

        Protected Overrides Function CalculateRemainingQtyBaseRate(ByVal remainingSmallestQty As Decimal, ByVal rate As Decimal) As Decimal
            If rate = 0 Then

                Return 0
            Else
                Return remainingSmallestQty / rate
            End If
        End Function
        Protected Overrides Sub InitFullTransfer()
            Try
                Using sqlConn As New SqlClient.SqlConnection(Me.DBSetting.ConnectionString)
                    sqlConn.Open()
                    'Using sqlCmd As New SqlClient.SqlCommand("SELECT  * FROM         DO WHERE     (Transferable = 'T') AND (Cancelled = 'F') And DO.DocKey NOT In( Select Dockey  From DODTL where DtlKey  in(Select FromDocDtlKey From PlugIns_PackingListDTL  Where FromDocType='DO' Group By FromDocType,FromDocDtlKey)) ORDER BY DocNo", sqlConn)
                    Using sqlCmd As New SqlClient.SqlCommand(Me.InitMasterSQL, sqlConn)
                        Dim dtRecord As New DataTable
                        dtRecord.Load(sqlCmd.ExecuteReader)
                        Me.dtFullDocument.Clear()
                        Me.dtFullDocument.Merge(dtRecord)

                        Me.FullDocument = Me.dtFullDocument

                        Me.gvFull.Columns("DebtorCode").Visible = dtRecord.Columns.Contains("DebtorCode")
                        Me.gvFull.Columns("DebtorName").Visible = dtRecord.Columns.Contains("DebtorName")
                        Me.gvFull.Columns("DisplayTerm").Visible = dtRecord.Columns.Contains("DisplayTerm")
                        Me.gvFull.Columns("SalesAgent").Visible = dtRecord.Columns.Contains("SalesAgent")

                    End Using
                End Using
            Catch ex As Exception

            End Try

        End Sub

        Protected Overrides Function GetPartialTransferDetailKeys() As List(Of Long)
            Dim nums As New List(Of Long)
            For Each dr As DataRow In Me.DocumentDataSet.Tables("Detail").Select(String.Format(" FromDocType='{0}' ", FromDocType))
                nums.Add(IIf(dr.Item("FromDocDtlKey") Is DBNull.Value, -1, dr.Item("FromDocDtlKey")))
            Next
            Return nums
        End Function


        Protected Overrides Sub InitPartialTransfer()
            Try


                Using sqlConn As New SqlClient.SqlConnection(Me.DBSetting.ConnectionString)
                    sqlConn.Open()

                    Dim commaString As String = StringHelper.IListToCommaString(GetPartialTransferDetailKeys.ToArray)


                    'Dim sSQL As New System.Text.StringBuilder
                    'sSQL.AppendLine(" SELECT  C.SmallestQty as  TransferedQty,A.*, B.DocNo, B.DebtorCode, B.DocDate, B.DebtorName, B.RefDocNo ")
                    'sSQL.AppendLine(" From DODTL as A left join DO as B On A.DocKey = B.DocKey left join  ")
                    'sSQL.AppendLine(" (Select FromDocDtlKey,SUM(Qty * Rate) as SmallestQty ")
                    'sSQL.AppendLine(" From PlugIns_PackingListDTL  ")
                    'sSQL.AppendLine(" Where FromDocType='DO' ")
                    'sSQL.AppendLine(" Group By FromDocType,FromDocDtlKey) as C on A.DtlKey = C.FromDocDtlKey ")
                    'sSQL.AppendLine(" Where  B.Transferable = 'T'  AND B.Cancelled = 'F' AND A.Transferable = 'T' AND A.Qty > 0 And ( (A.SmallestQty - ISNULL(C.SmallestQty,0) > 0)  OR A.DtlKey IN (SELECT * FROM LIST(@List))) ")

                    Using sqlCmd As New SqlClient.SqlCommand(InitDetailSQL.ToString, sqlConn)
                        sqlCmd.Parameters.AddWithValue("List", commaString)
                        Dim dtRecord As New DataTable
                        dtRecord.Load(sqlCmd.ExecuteReader)
                        Me.dtPartialDocument.Clear()
                        Me.dtPartialDocument.Merge(dtRecord)
                        Me.PartialDocument = Me.dtPartialDocument

                        For Each row As DataRow In dtPartialDocument.Rows
                            Dim iSmallestQty As Decimal = IIf(row.Item("SmallestQty") Is DBNull.Value, 0, row.Item("SmallestQty"))
                            Dim iTransferedQty As Decimal = IIf(row.Item("TransferedQty") Is DBNull.Value, 0, row.Item("TransferedQty"))
                            Dim iDtlKey As Long = IIf(row.Item("DtlKey") Is DBNull.Value, -1, row.Item("DtlKey"))

                            row.Item("RemainingSmallestQty") = iSmallestQty - iTransferedQty
                            row.Item("RemainingQty") = iSmallestQty - iTransferedQty
                            For Each drRow As DataRow In DocumentDataSet.Tables("Detail").Rows
                                If drRow.RowState = DataRowState.Deleted Then
                                    Try
                                        Dim sOriDocType As String = drRow.Item("FromDocType", DataRowVersion.Original)
                                        '   If sOriDocType = "DO" Then
                                        Dim iFromDocDtlKey As Long = drRow.Item("FromDocDtlKey", DataRowVersion.Original)
                                        If (iFromDocDtlKey = iDtlKey) Then
                                            Dim iRemainingQty As Decimal = IIf(row.Item("RemainingSmallestQty") Is DBNull.Value, 0, row.Item("RemainingSmallestQty"))
                                            row.Item("RemainingSmallestQty") = iRemainingQty + drRow.Item("SmallestQty", DataRowVersion.Original)
                                        End If
                                        ' End If
                                    Catch ex As Exception

                                    End Try
                                Else
                                    Dim iFromDocDtlKey As Long = IIf(drRow.Item("FromDocDtlKey") Is DBNull.Value, -1, drRow.Item("FromDocDtlKey"))
                                    If (iFromDocDtlKey = iDtlKey) Then
                                        If drRow.RowState = DataRowState.Added Then
                                            Dim iRemainingQty As Decimal = IIf(row.Item("RemainingSmallestQty") Is DBNull.Value, 0, row.Item("RemainingSmallestQty"))
                                            row.Item("RemainingSmallestQty") = iRemainingQty - IIf(drRow.Item("SmallestQty") Is DBNull.Value, 0, drRow.Item("SmallestQty"))
                                        Else
                                            If (drRow.RowState = DataRowState.Modified) Then
                                                Dim iSmallestQtyB4 As Decimal = IIf(drRow.Item("SmallestQty") Is DBNull.Value, 0, drRow.Item("SmallestQty"))
                                                Dim iOriSmallestQty As Decimal = drRow.Item("SmallestQty", DataRowVersion.Original)
                                                Dim iRemainingQty As Decimal = IIf(row.Item("RemainingSmallestQty") Is DBNull.Value, 0, row.Item("RemainingSmallestQty"))

                                                Dim iTotal As Decimal = iSmallestQtyB4 - iOriSmallestQty
                                                row.Item("RemainingSmallestQty") = iRemainingQty - iTotal
                                            End If
                                        End If
                                    End If

                                End If

                            Next
                        Next
                        SetupUOMValue()
                        SetupLookupEdit()
                        dtPartialDocument.DefaultView.RowFilter = DetailFilter
                        Me.gcPartial.DataSource = dtPartialDocument.DefaultView

                        Me.gvPartial.Columns("DebtorCode").Visible = dtRecord.Columns.Contains("DebtorCode")
                        Me.gvPartial.Columns("DebtorName").Visible = dtRecord.Columns.Contains("DebtorName")

                    End Using
                End Using
            Catch ex As Exception

            End Try
        End Sub
        Protected Overrides Sub FilterItemUOM()
            If Me.gvPartial.FocusedColumn IsNot Nothing And (Me.gvPartial.FocusedColumn.FieldName = "UOM" Or Me.gvPartial.FocusedColumn.FieldName = "NewUOM") Then
                Dim drItem As DataRow = gvPartial.GetDataRow(Me.gvPartial.FocusedRowHandle)
                ItemUOMLookupEditBuilder.FilterItemCode(drItem.Item("ItemCode").ToString)
            End If
        End Sub



        Protected Overrides Sub SetupLookupEdit()

            ItemUOMLookupEditBuilder = New AutoCount.XtraUtils.LookupEditBuilder.ItemUOMLookupEditBuilder()
            ItemUOMLookupEditBuilder.BuildLookupEdit(Me.lpUOM, Me.UserSession)

        End Sub
        Protected Overrides Sub SetupUOMValue()
            For Each drRow As DataRow In Me.dtPartialDocument.Rows
                drRow.Item("NewUOM") = drRow.Item("UOM")
            Next

        End Sub

        Protected Overrides Sub CloseEvent(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub
        Protected Overrides Function VerifyPartial() As Boolean
            Dim iError As Integer = 0
            For Each drRow As DataRow In Me.dtPartialDocument.Rows
                Dim iNewQty As Decimal = IIf(drRow.Item("NewQty") Is DBNull.Value, 0, drRow.Item("NewQty"))
                Dim iRemainingSmallestQty As Decimal = IIf(drRow.Item("RemainingSmallestQty") Is DBNull.Value, 0, drRow.Item("RemainingSmallestQty"))
                Dim sItemCode As String = IIf(drRow.Item("ItemCode") Is DBNull.Value, String.Empty, drRow.Item("ItemCode"))
                If iNewQty > iRemainingSmallestQty Then
                    iError = 1
                End If
                If iError = 1 Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("New quantity is more than remaining quantity in Item Code {0}", sItemCode), "Transfer Document")
                    Return False
                End If

            Next
            Return True
        End Function
        Protected Overrides Sub ApplyEvent(sender As Object, e As EventArgs) Handles btnApply.Click
            Me.bsFullTransfer.EndEdit()
            Me.bsPartialTransfer.EndEdit()

            If Me.TabMaster.SelectedTabPageIndex = 0 Then
                Mode = TransferMode.FullTransfer
            Else
                Mode = TransferMode.PartialTransfer
                If Not VerifyPartial() Then
                    Return
                End If
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
        End Sub

        Protected Overrides Sub TabMasterPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles TabMaster.SelectedPageChanged
            If (e.Page.Name = Me.PageFullTransfer.Name) Then
                InitFullTransfer()
            Else
                InitPartialTransfer()
            End If


        End Sub

        Protected Overrides Sub Partial_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles gvPartial.FocusedColumnChanged
            gvPartial.UpdateCurrentRow()

            Me.FilterItemUOM()
        End Sub

        Protected Overrides Sub Partial_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvPartial.FocusedRowChanged
            gvPartial.UpdateCurrentRow()
            Me.FilterItemUOM()
        End Sub
    End Class
End Namespace