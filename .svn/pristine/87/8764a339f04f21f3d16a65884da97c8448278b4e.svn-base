Public Class PurchaseInvoiceScript
    Private ReadOnly _helper As New PriceHistoryHelper()
    Public Sub OnFormShow(e As AutoCount.Invoicing.Purchase.PurchaseInvoice.FormPurchaseInvoiceEntry.FormShowEventArgs)
        _helper.AddStockItemMaintenanceRibbon(e.Form, e.UserSession, e.DBSetting, e.EditWindowMode)
        _helper.AddCustomTabs(e.Form, e.UserSession, e.DBSetting)
    End Sub

    Public Sub OnSwitchToEditMode(e As AutoCount.Invoicing.Purchase.PurchaseInvoice.FormPurchaseInvoiceEntry.FormEventArgs)
        ' Find the ribbon group again
        Dim ribbonCtrl = e.Form.Ribbon
        Dim newGroup = ribbonCtrl.Pages("Home").Groups _
            .FirstOrDefault(Function(g) g.Name = "ribbonPageGroupStockItemMaintenance")

        If newGroup IsNot Nothing Then
            newGroup.Visible = (e.EditWindowMode <> AutoCount.Document.EditWindowMode.View)
        End If
    End Sub
End Class

#Region "<--- original code --->"
'Imports System.Data.SqlClient
'Imports System.Text
'Imports AutoCount.Application
'Imports AutoCount.Authentication
'Imports AutoCount.Data
'Imports DevExpress.XtraBars
'Imports DevExpress.XtraBars.Ribbon
'Imports DevExpress.XtraEditors
'Imports DevExpress.XtraGrid
'Imports DevExpress.XtraGrid.Views.Grid
'Imports FreelyCreative.StockItemInquiry.AutocountScript.PriceHistory.Model.PriceHistory

'Public Class PurchaseInvoiceController
'    Private Iterator Function GetAllControls(parent As Control) As IEnumerable(Of Control)
'        For Each control As Control In parent.Controls
'            Yield control

'            For Each child As Control In GetAllControls(control)
'                Yield child
'            Next
'        Next
'    End Function
'    Private Function GetTabControl(form As XtraForm) As DevExpress.XtraTab.XtraTabControl
'        Return GetAllControls(form) _
'        .OfType(Of DevExpress.XtraTab.XtraTabControl)() _
'        .FirstOrDefault(Function(tc) tc.Name = "tabctrInquiry")
'    End Function


'#Region "<--- add sales/purchase price history tab --->"
'    Public Sub AddCustomTabs(form As XtraForm, userSession As UserSession, dbSetting As DBSetting)
'        AttachEntryGridEvents(form, userSession, dbSetting)
'        AttachRibbonClick(form, userSession, dbSetting)
'    End Sub

'    Private Sub AttachEntryGridEvents(form As XtraForm, userSession As UserSession, dbSetting As DBSetting)
'        Dim entryGrid = GetAllControls(form) _
'        .OfType(Of DevExpress.XtraGrid.GridControl)() _
'        .FirstOrDefault(Function(g) g.Name = "gridControlDetail")

'        Dim entryView = TryCast(entryGrid?.MainView, DevExpress.XtraGrid.Views.Grid.GridView)
'        If entryView IsNot Nothing Then
'            AddHandler entryView.FocusedRowChanged,
'            Sub(s, args)
'                UpdateSalesPriceHistoryGrid(form, userSession, dbSetting, entryView)
'                UpdatePurchasePriceHistoryGrid(form, userSession, dbSetting, entryView)
'            End Sub

'            AddHandler entryView.CellValueChanged,
'            Sub(s, args)
'                If args.Column.FieldName = "ItemCode" Then
'                    UpdateSalesPriceHistoryGrid(form, userSession, dbSetting, entryView)
'                    UpdatePurchasePriceHistoryGrid(form, userSession, dbSetting, entryView)
'                End If
'            End Sub
'        End If
'    End Sub
'    Private Sub UpdateSalesPriceHistoryGrid(form As XtraForm,
'                                            userSession As UserSession,
'                                            dbSetting As DBSetting,
'                                            entryView As DevExpress.XtraGrid.Views.Grid.GridView)

'        Dim handle = entryView.FocusedRowHandle
'        Dim itemCode = If(handle >= 0, TryCast(entryView.GetRowCellValue(handle, "ItemCode"), String), Nothing)

'        Dim history = LoadSalesPriceHistory(dbSetting, If(String.IsNullOrEmpty(itemCode), Nothing, itemCode))

'        Dim salesGrid = GetAllControls(form) _
'        .OfType(Of DevExpress.XtraGrid.GridControl)() _
'        .FirstOrDefault(Function(g) g.Name = "gctrSalesPriceHistory")

'        If salesGrid IsNot Nothing Then
'            salesGrid.DataSource = history
'        End If
'    End Sub
'    Private Sub UpdatePurchasePriceHistoryGrid(form As XtraForm,
'                                               userSession As UserSession,
'                                               dbSetting As DBSetting,
'                                               entryView As DevExpress.XtraGrid.Views.Grid.GridView)

'        Dim handle = entryView.FocusedRowHandle
'        Dim itemCode = If(handle >= 0, TryCast(entryView.GetRowCellValue(handle, "ItemCode"), String), Nothing)

'        Dim history = LoadPurchasePriceHistory(dbSetting, If(String.IsNullOrEmpty(itemCode), Nothing, itemCode))

'        Dim tabControl = GetTabControl(form)
'        If tabControl Is Nothing Then Return

'        ' Must check tab name manually because AutoCount reuses same names
'        Dim myTab = tabControl.TabPages.FirstOrDefault(Function(p) p.Name = "tabPurchasePriceHistory1")
'        If myTab Is Nothing Then Return

'        Dim purchaseGrid = myTab.Controls _
'        .OfType(Of DevExpress.XtraGrid.GridControl)() _
'        .FirstOrDefault(Function(g) g.Name = "gctrPurchasePriceHistory")

'        If purchaseGrid IsNot Nothing Then
'            purchaseGrid.DataSource = history
'        End If
'    End Sub

'    Public Sub AttachRibbonClick(form As XtraForm, userSession As UserSession, dbSetting As DBSetting)
'        ' Wait until the form is fully loaded
'        form.BeginInvoke(CType(Sub()
'                                   Dim ribbonForm = TryCast(form, DevExpress.XtraBars.Ribbon.RibbonForm)
'                                   If ribbonForm Is Nothing OrElse ribbonForm.Ribbon Is Nothing Then Return

'                                   Dim ribbonCtrl = ribbonForm.Ribbon
'                                   Dim barBtn = ribbonCtrl.Items _
'                                   .OfType(Of DevExpress.XtraBars.BarButtonItem)() _
'                                   .FirstOrDefault(Function(b) b.Name = "barBtnShowInstantInfo")
'                                   If barBtn Is Nothing Then Return

'                                   ' Attach only once
'                                   If Not Object.Equals(barBtn.Tag, "PriceHistoryHandlerAttached") Then
'                                       AddHandler barBtn.ItemClick,
'                                       Sub(sender As Object, args As DevExpress.XtraBars.ItemClickEventArgs)
'                                           Dim tabControl = GetTabControl(form)
'                                           If tabControl Is Nothing Then Return

'                                           CreateSalesPriceHistoryTab(tabControl, userSession, dbSetting)
'                                           CreatePurchasePriceHistoryTab(tabControl, userSession, dbSetting)

'                                           Dim entryGrid = GetAllControls(form) _
'                                                .OfType(Of DevExpress.XtraGrid.GridControl)() _
'                                                .FirstOrDefault(Function(g) g.Name = "gridControlDetail")

'                                           Dim entryView = TryCast(If(entryGrid IsNot Nothing, entryGrid.MainView, Nothing), DevExpress.XtraGrid.Views.Grid.GridView)
'                                           If entryView IsNot Nothing Then
'                                               UpdateSalesPriceHistoryGrid(form, userSession, dbSetting, entryView)
'                                               UpdatePurchasePriceHistoryGrid(form, userSession, dbSetting, entryView)
'                                           End If
'                                       End Sub
'                                       barBtn.Tag = "PriceHistoryHandlerAttached"
'                                   End If

'                               End Sub, MethodInvoker))
'    End Sub

'    Private Sub CreateSalesPriceHistoryTab(tabControl As DevExpress.XtraTab.XtraTabControl, session As UserSession, dbSetting As DBSetting)

'        If tabControl.TabPages.Cast(Of DevExpress.XtraTab.XtraTabPage)().Any(Function(p) p.Name = "tabSalesPriceHistory") Then Return

'        Dim salesTab As New DevExpress.XtraTab.XtraTabPage With {
'            .Name = "tabSalesPriceHistory",
'            .Text = "Sales Price History"
'        }

'        Dim grid As New DevExpress.XtraGrid.GridControl With {
'            .Dock = DockStyle.Fill,
'            .Name = "gctrSalesPriceHistory"
'        }

'        Dim view As New DevExpress.XtraGrid.Views.Grid.GridView(grid) With {
'            .Name = "gvSalesPriceHistory"
'        }
'        view.OptionsBehavior.Editable = False
'        view.OptionsView.ShowGroupPanel = False

'        grid.MainView = view
'        grid.ViewCollection.Add(view)

'        Dim dt = LoadSalesPriceHistory(dbSetting, Nothing)
'        Dim historyList = MapToPriceHistoryEntities(dt)
'        grid.DataSource = historyList

'        salesTab.Controls.Add(grid)
'        tabControl.TabPages.Add(salesTab)

'        salesTab.BeginInvoke(CType(Sub() PriceHistoryColumnProperties(grid), MethodInvoker))

'        AddHandler view.DoubleClick, Sub(sender2, e2) HandleSalesPriceHistoryDoubleClick(session, sender2)
'    End Sub
'    Private Function LoadSalesPriceHistory(dbSetting As DBSetting, itemCode As String) As DataTable
'        Dim dt As New DataTable()
'        Dim sb As New StringBuilder()

'        Dim docTypes() As String = {"SO", "DO", "IV", "CS", "CN", "DN"}
'        Dim docTypeDocStatus As New HashSet(Of String) From {"SO", "DO", "IV", "CN", "DN"}

'        sb.AppendLine(";WITH AllDocs AS (")

'        For i As Integer = 0 To docTypes.Length - 1
'            Dim docType = docTypes(i)
'            If i > 0 Then sb.AppendLine("UNION ALL")

'            Dim header = docType
'            Dim detail = docType & "DTL"
'            Dim hasStatus = docTypeDocStatus.Contains(docType)

'            sb.AppendLine($"
'            SELECT A.DocKey,
'                   A.DebtorCode AS AccNo,
'                   A.DebtorName AS CompanyName,
'                   A.DocNo,
'                   '{docType}' AS DocType,
'                   A.DocDate,
'                   A.BranchCode,
'                   B.ItemCode,
'                   B.Description,
'                   B.Desc2,
'                   ISNULL(B.BatchNo, '') AS BatchNo,
'                   B.UOM,
'                   g.CurrencyCode,
'                   B.Location,
'                   B.Qty,
'                   B.UnitPrice,
'                   B.SubTotal,
'                   D.AreaCode,
'                   A.LastModified,
'                   A.CreatedTimeStamp
'              FROM {header} A
'              INNER JOIN {detail} B ON A.DocKey = B.DocKey
'              INNER JOIN Debtor D ON A.DebtorCode = D.AccNo
'              LEFT JOIN GLMast g ON g.AccNo = A.DebtorCode
'              {(If(hasStatus, "WHERE A.DocStatus IN ('A','V')", ""))}")
'        Next

'        sb.AppendLine("),")
'        sb.AppendLine("Ranked AS (")
'        sb.AppendLine("    SELECT *,")
'        sb.AppendLine("           ROW_NUMBER() OVER (")
'        sb.AppendLine("               PARTITION BY ItemCode")
'        sb.AppendLine("               ORDER BY DocDate DESC, DocKey DESC")
'        sb.AppendLine("           ) AS rn")
'        sb.AppendLine("      FROM AllDocs")
'        sb.AppendLine(")")
'        sb.AppendLine("SELECT DocKey, AccNo, CompanyName, DocNo, DocType, DocDate, BranchCode,")
'        sb.AppendLine("       ItemCode, Description, Desc2, BatchNo, UOM, CurrencyCode,")
'        sb.AppendLine("       Location, Qty, UnitPrice, SubTotal, AreaCode, LastModified, CreatedTimeStamp")
'        sb.AppendLine("  FROM Ranked")
'        sb.AppendLine(" WHERE rn <= 5")
'        If Not String.IsNullOrEmpty(itemCode) Then
'            sb.AppendLine("     AND ItemCode = @ItemCode")
'        End If
'        sb.AppendLine(" ORDER BY ItemCode, DocDate DESC, DocNo DESC, AccNo;")

'        Dim sql As String = sb.ToString()

'        Using sqlconn As New SqlConnection(dbSetting.ConnectionString)
'            Using cmd As New SqlCommand(sql, sqlconn)
'                Using da As New SqlDataAdapter(cmd)
'                    If Not String.IsNullOrEmpty(itemCode) Then
'                        cmd.Parameters.AddWithValue("@ItemCode", itemCode)
'                    End If

'                    da.Fill(dt)
'                End Using
'            End Using
'        End Using

'        Return dt
'    End Function
'    Private Sub HandleSalesPriceHistoryDoubleClick(session As UserSession, sender2 As Object)
'        Dim gv = TryCast(sender2, DevExpress.XtraGrid.Views.Grid.GridView)
'        If gv Is Nothing Then Return

'        Dim pt = gv.GridControl.PointToClient(Control.MousePosition)
'        Dim hitInfo = gv.CalcHitInfo(pt)
'        If Not (hitInfo.InRow OrElse hitInfo.InRowCell) Then Return

'        Dim docKeyObj = gv.GetRowCellValue(hitInfo.RowHandle, "DocKey")
'        Dim docType As String = Convert.ToString(gv.GetRowCellValue(hitInfo.RowHandle, "DocType"))

'        If docKeyObj Is Nothing OrElse String.IsNullOrEmpty(docType) Then Return

'        Dim docKey As Long = Convert.ToInt64(docKeyObj)

'        Select Case docType
'            Case "SO"
'                AutoCount.Invoicing.Sales.SalesOrder.FormSalesOrderCmd.ViewDocument(session, docKey)
'            Case "DO"
'                AutoCount.Invoicing.Sales.DeliveryOrder.FormDeliveryOrderCmd.ViewDocument(session, docKey)
'            Case "IV"
'                AutoCount.Invoicing.Sales.Invoice.FormInvoiceCmd.ViewDocument(session, docKey)
'            Case "CS"
'                AutoCount.Invoicing.Sales.CashSale.FormCashSaleCmd.ViewDocument(session, docKey)
'            Case "CN"
'                AutoCount.Invoicing.Sales.CreditNote.FormCreditNoteCmd.ViewDocument(session, docKey)
'            Case "DN"
'                AutoCount.Invoicing.Sales.DebitNote.FormDebitNoteCmd.ViewDocument(session, docKey)
'        End Select
'    End Sub

'    Private Sub CreatePurchasePriceHistoryTab(tabControl As DevExpress.XtraTab.XtraTabControl, session As UserSession, dbSetting As DBSetting)

'        ' Prevent duplicate tab creation
'        If tabControl.TabPages.Cast(Of DevExpress.XtraTab.XtraTabPage)().Any(Function(p) p.Name = "tabPurchasePriceHistory1") Then Return

'        ' Create new tab page
'        Dim purchaseTab As New DevExpress.XtraTab.XtraTabPage With {
'            .Name = "tabPurchasePriceHistory1",
'            .Text = "Purchase Price History"
'        }

'        ' Create grid control
'        Dim grid As New DevExpress.XtraGrid.GridControl With {
'            .Dock = DockStyle.Fill,
'            .Name = "gctrPurchasePriceHistory"
'        }

'        ' Create grid view
'        Dim view As New DevExpress.XtraGrid.Views.Grid.GridView(grid) With {
'            .Name = "gvPurchasePriceHistory"
'        }
'        view.OptionsBehavior.Editable = False
'        view.OptionsView.ShowGroupPanel = False

'        grid.MainView = view
'        grid.ViewCollection.Add(view)

'        ' Load data and bind
'        Dim dt = LoadPurchasePriceHistory(dbSetting, Nothing)
'        Dim historyList = MapToPriceHistoryEntities(dt)
'        grid.DataSource = historyList

'        purchaseTab.Controls.Add(grid)
'        tabControl.TabPages.Add(purchaseTab)

'        ' Apply column properties after rendering
'        purchaseTab.BeginInvoke(DirectCast(Sub()
'                                               PriceHistoryColumnProperties(grid)
'                                           End Sub, MethodInvoker))

'        ' Handle double-click
'        AddHandler view.DoubleClick, Sub(sender2, e2) HandlePurchasePriceHistoryDoubleClick(session, sender2)
'    End Sub
'    Private Function LoadPurchasePriceHistory(dbSetting As DBSetting, itemCode As String) As DataTable
'        Dim dt As New DataTable()
'        Dim sb As New StringBuilder()

'        Dim docTypes() As String = {"PO", "GR", "PI"}

'        sb.AppendLine(";WITH AllDocs AS (")

'        For i As Integer = 0 To docTypes.Length - 1
'            Dim docType = docTypes(i)
'            If i > 0 Then sb.AppendLine("UNION ALL")

'            Dim header = docType
'            Dim detail = docType & "DTL"

'            sb.AppendLine($"
'            SELECT 
'                A.DocKey,
'                A.CreditorCode AS AccNo,
'                A.CreditorName AS CompanyName,
'                A.DocNo,
'                '{docType}' AS DocType,
'                A.DocDate,
'                A.BranchCode,
'                B.ItemCode,
'                B.Description,
'                B.Desc2,
'                ISNULL(B.BatchNo, '') AS BatchNo,
'                B.UOM,
'                g.CurrencyCode,
'                B.Location,
'                B.Qty,
'                B.UnitPrice,
'                B.SubTotal,
'                C.AreaCode,
'                A.LastModified,
'                A.CreatedTimeStamp
'            FROM {header} A
'            INNER JOIN {detail} B ON A.DocKey = B.DocKey
'            INNER JOIN Creditor C ON A.CreditorCode = C.AccNo
'            LEFT JOIN GLMast g ON g.AccNo = A.CreditorCode")
'        Next

'        sb.AppendLine("),")
'        sb.AppendLine("Ranked AS (")
'        sb.AppendLine("    SELECT *,")
'        sb.AppendLine("           ROW_NUMBER() OVER (")
'        sb.AppendLine("               PARTITION BY ItemCode")
'        sb.AppendLine("               ORDER BY DocDate DESC, DocKey DESC")
'        sb.AppendLine("           ) AS rn")
'        sb.AppendLine("    FROM AllDocs")
'        sb.AppendLine(")")
'        sb.AppendLine("SELECT DocKey, AccNo, CompanyName, DocNo, DocType, DocDate, BranchCode,")
'        sb.AppendLine("       ItemCode, Description, Desc2, BatchNo, UOM, CurrencyCode,")
'        sb.AppendLine("       Location, Qty, UnitPrice, SubTotal, AreaCode, LastModified, CreatedTimeStamp")
'        sb.AppendLine("  FROM Ranked")
'        sb.AppendLine(" WHERE rn <= 5")

'        If Not String.IsNullOrEmpty(itemCode) Then
'            sb.AppendLine("     AND ItemCode = @ItemCode")
'        End If

'        sb.AppendLine(" ORDER BY ItemCode, DocDate DESC, DocNo DESC, AccNo;")

'        Dim sql As String = sb.ToString()

'        Using sqlconn As New SqlConnection(dbSetting.ConnectionString)
'            Using cmd As New SqlCommand(sql, sqlconn)
'                Using da As New SqlDataAdapter(cmd)
'                    If Not String.IsNullOrEmpty(itemCode) Then
'                        cmd.Parameters.AddWithValue("@ItemCode", itemCode)
'                    End If

'                    da.Fill(dt)
'                End Using
'            End Using
'        End Using

'        Return dt
'    End Function
'    Private Sub HandlePurchasePriceHistoryDoubleClick(session As UserSession, sender2 As Object)
'        Dim gv = TryCast(sender2, DevExpress.XtraGrid.Views.Grid.GridView)
'        If gv Is Nothing Then Return

'        Dim pt = gv.GridControl.PointToClient(Control.MousePosition)
'        Dim hitInfo = gv.CalcHitInfo(pt)
'        If Not (hitInfo.InRow OrElse hitInfo.InRowCell) Then Return

'        Dim docKeyObj = gv.GetRowCellValue(hitInfo.RowHandle, "DocKey")
'        Dim docType = TryCast(gv.GetRowCellValue(hitInfo.RowHandle, "DocType"), String)
'        If docKeyObj Is Nothing OrElse String.IsNullOrEmpty(docType) Then Return

'        Dim docKey As Long = Convert.ToInt64(docKeyObj)

'        Select Case docType
'            Case "PO"
'                AutoCount.Invoicing.Purchase.PurchaseOrder.FormPurchaseOrderCmd.ViewDocument(session, docKey)
'            Case "GR"
'                AutoCount.Invoicing.Purchase.GoodsReceivedNote.FormGoodsReceivedNoteCmd.ViewDocument(session, docKey)
'            Case "PI"
'                AutoCount.Invoicing.Purchase.PurchaseInvoice.FormPurchaseInvoiceCmd.ViewDocument(session, docKey)
'        End Select
'    End Sub

'    Public Shared Function MapToPriceHistoryEntities(dt As DataTable) As List(Of PriceHistoryEntity)
'        Dim list As New List(Of PriceHistoryEntity)()
'        For Each row As DataRow In dt.Rows
'            Dim entity As New PriceHistoryEntity With {
'            .DocKey = If(row("DocKey") IsNot DBNull.Value, Convert.ToInt64(row("DocKey")), 0),
'            .DocNo = TryCast(row("DocNo"), String),
'            .DocType = TryCast(row("DocType"), String),
'            .DocDate = If(row("DocDate") IsNot DBNull.Value, Convert.ToDateTime(row("DocDate")), DateTime.MinValue),
'            .BranchCode = TryCast(row("BranchCode"), String),
'            .AreaCode = TryCast(row("AreaCode"), String),
'            .LastModified = If(row("LastModified") IsNot DBNull.Value, Convert.ToDateTime(row("LastModified")), DateTime.MinValue),
'            .CreatedTimeStamp = If(row("CreatedTimeStamp") IsNot DBNull.Value, Convert.ToDateTime(row("CreatedTimeStamp")), DateTime.MinValue),
'            .AccNo = TryCast(row("AccNo"), String),
'            .CompanyName = TryCast(row("CompanyName"), String),
'            .ItemCode = TryCast(row("ItemCode"), String),
'            .Description = TryCast(row("Description"), String),
'            .Desc2 = TryCast(row("Desc2"), String),
'            .BatchNo = TryCast(row("BatchNo"), String),
'            .UOM = TryCast(row("UOM"), String),
'            .Location = TryCast(row("Location"), String),
'            .Qty = If(row("Qty") IsNot DBNull.Value, Convert.ToDecimal(row("Qty")), 0D),
'            .UnitPrice = If(row("UnitPrice") IsNot DBNull.Value, Convert.ToDecimal(row("UnitPrice")), 0D),
'            .SubTotal = If(row("SubTotal") IsNot DBNull.Value, Convert.ToDecimal(row("SubTotal")), 0D),
'            .CurrencyCode = TryCast(row("CurrencyCode"), String)
'        }
'            list.Add(entity)
'        Next
'        Return list
'    End Function
'    Private Sub PriceHistoryColumnProperties(grid As DevExpress.XtraGrid.GridControl)
'        Dim gv = TryCast(grid.MainView, DevExpress.XtraGrid.Views.Grid.GridView)
'        If gv Is Nothing Then Return

'        gv.PopulateColumns()

'        SetColumn(gv, NameOf(PriceHistoryEntity.DocKey), False, True)
'        SetColumn(gv, NameOf(PriceHistoryEntity.Desc2), False, True)
'        SetColumn(gv, NameOf(PriceHistoryEntity.BranchCode), False, True)
'        SetColumn(gv, NameOf(PriceHistoryEntity.AreaCode), False, True)
'        SetColumn(gv, NameOf(PriceHistoryEntity.CurrencyCode), False, True)
'        SetColumn(gv, NameOf(PriceHistoryEntity.DocDate), True, True, "yyyy/MM/dd")
'        SetColumn(gv, NameOf(PriceHistoryEntity.CreatedTimeStamp), False, True, "yyyy/MM/dd HH:mm:ss")
'        SetColumn(gv, NameOf(PriceHistoryEntity.LastModified), False, True, "yyyy/MM/dd HH:mm:ss")
'    End Sub
'    Private Sub SetColumn(gv As DevExpress.XtraGrid.Views.Grid.GridView, fieldName As String, visible As Boolean, showInCustomizationForm As Boolean, Optional format As String = Nothing)
'        Dim col = gv.Columns.ColumnByFieldName(fieldName)
'        If col Is Nothing Then Return

'        col.Visible = visible
'        col.OptionsColumn.ShowInCustomizationForm = showInCustomizationForm

'        If Not String.IsNullOrEmpty(format) Then
'            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
'            col.DisplayFormat.FormatString = format
'        End If
'    End Sub

'#End Region
'End Class
#End Region