Imports DevExpress.XtraEditors.Popup
Imports System.Reflection

Namespace Freely.FreelyEvent
    Public Class FreelyLookupFilteringHandler
        Implements IDisposable

        Private _MasterTable As New DataTable
        Private _AClone As DataView

        Public Property GridView As DevExpress.XtraGrid.Views.Grid.GridView
        ''' <summary>
        '''  This Is Focus On With Field To Triggle This Event
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>GridView.FocusedColumn.FieldName = FocusField</remarks>
        Public Property FocusField As String = "UOM"

        ''' <summary>
        ''' This Filter Will Get From GridView Focus Row
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Example : GridView.GetDataRow(GridView.FocusedRowHandle).Item(FilterField)</remarks>
        Public Property FilterField As String = "ItemCode"

        ''' <summary>
        ''' Effect For Master Table Which Column Are Needed For Filter
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>      Master.RowFilter = "[TableFileter] = RESULT OF [FilterField]"</remarks>
        Public Property TableFilterField As String = "ItemCode"

        ''' <summary>
        ''' This Table For Execute Filtering 
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        Public WriteOnly Property MasterTable As DataTable
            Set(ByVal value As DataTable)
                _MasterTable = value
            End Set
        End Property

        ''' <summary>
        ''' Master Table Will as A Dataview , Filter Row Like Master Table's [TableFilterField] =gridview.GetDataRow [Filter Field].
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Sub ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs)

            Try
                If (GridView.FocusedColumn.FieldName = FocusField) And (TypeOf GridView.ActiveEditor Is DevExpress.XtraEditors.LookUpEdit) Then
                    Dim sItemCode As Object = IIf(GridView.GetDataRow(GridView.FocusedRowHandle).Item(FilterField) Is DBNull.Value, Nothing, GridView.GetDataRow(GridView.FocusedRowHandle).Item(FilterField))
                    Dim ALookUp As DevExpress.XtraEditors.LookUpEdit = TryCast(GridView.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
                    _AClone = New DataView(_MasterTable)

                    If _MasterTable.Columns.Contains(TableFilterField) Then
                        Select Case _MasterTable.Columns(TableFilterField).DataType
                            Case GetType(Decimal) : If (sItemCode Is Nothing) Then sItemCode = 0
                            Case GetType(Integer) : If (sItemCode Is Nothing) Then sItemCode = -1
                            Case GetType(Long) : If (sItemCode Is Nothing) Then sItemCode = -1
                            Case Else
                                If (sItemCode Is Nothing) Then sItemCode = String.Empty
                        End Select
                    End If
                        _AClone.RowFilter = String.Format("{1}='{0}'", sItemCode, TableFilterField)
                        ALookUp.Properties.DataSource = _AClone
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not _AClone Is Nothing Then
                _AClone.Dispose()
                _AClone = Nothing
            End If
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Public Class FreelyListBoxWriteLog
        Private _AListBox As DevExpress.XtraEditors.ListBoxControl
        Private _bUseColor As Boolean = False
        Private _MessageMask As String = "[{0}] - {1}"

        Public Event WriteLog(ByVal AMessage As String)
        Public Property MessageMask As String
            Get
                Return _MessageMask
            End Get
            Set(ByVal value As String)
                _MessageMask = value
            End Set
        End Property
        Public ReadOnly Property ListBox As DevExpress.XtraEditors.ListBoxControl
            Get
                Return _AListBox
            End Get
        End Property

        Public Property ListOfMessage As New List(Of OnDrawProperty)

        Public Property UseFontColor As Boolean
            Get
                Return _bUseColor
            End Get
            Set(ByVal value As Boolean)
                _bUseColor = value

                If _AListBox IsNot Nothing Then
                    If value Then
                        AddHandler _AListBox.DrawItem, AddressOf OnDraw
                    Else
                        RemoveHandler _AListBox.DrawItem, AddressOf OnDraw
                    End If
                End If
            End Set
        End Property


        Friend Sub New()

        End Sub

        Public Sub New(ByVal AListBox As DevExpress.XtraEditors.ListBoxControl)
            _AListBox = AListBox
        End Sub
        Private Sub OnDraw(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.ListBoxDrawItemEventArgs)
            If ListOfMessage IsNot Nothing Then
                For Each AMessage As OnDrawProperty In ListOfMessage
                    If e.Item.ToString.Contains(AMessage.MessageContent) Then
                        e.Appearance.ForeColor = AMessage.Color
                    End If
                Next
            End If
        End Sub

        Public Sub Write(ByVal AMessage As String)
            Me._AListBox.Items.Add(String.Format(MessageMask, Now.ToString, AMessage))
            Me._AListBox.SelectedIndex = Me._AListBox.Items.Count - 1
            System.Windows.Forms.Application.DoEvents()
            RaiseEvent WriteLog(AMessage)
        End Sub

        Public Class OnDrawProperty
            Public MessageContent As String
            Public Color As System.Drawing.Color
            Public Sub New(ByVal AMessage As String, ByVal AColor As System.Drawing.Color)
                MessageContent = AMessage
                Color = AColor
            End Sub
        End Class

    End Class


    Public Class FreelyLookupEditEx

        Public Shared Sub Build(ByVal ALookup As DevExpress.XtraEditors.LookUpEdit)
            If ALookup IsNot Nothing Then
                AddHandler ALookup.Popup, AddressOf PopupEvent
                AddHandler ALookup.CloseUp, AddressOf CloseUpEvent

            End If
        End Sub

        Private Shared Sub OnMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim APopupLookUpEditFormViewInfo As PopupLookUpEditFormViewInfo = GetPopupFormViewInfo(TryCast(sender, PopupLookUpEditForm))
            If APopupLookUpEditFormViewInfo IsNot Nothing Then

                Dim APoint As New System.Drawing.Point
                APoint.X = e.X
                APoint.Y = e.Y

                Dim AhitTest As LookUpPopupHitTest = APopupLookUpEditFormViewInfo.GetHitTest(APoint)
                Dim pressInfo As DevExpress.XtraEditors.Popup.LookUpPopupHitTest = GetPressInfo(TryCast(sender, PopupLookUpEditForm))
                If (AhitTest.HitType = pressInfo.HitType And pressInfo.Index = pressInfo.Index And _
           Math.Abs(pressInfo.Point.X - pressInfo.Point.X) < SystemInformation.DragSize.Width And _
           Math.Abs(pressInfo.Point.Y - pressInfo.Point.Y) < SystemInformation.DragSize.Height And _
           pressInfo.HitType = DevExpress.XtraEditors.Popup.LookUpPopupHitType.Header) Then
                    APopupLookUpEditFormViewInfo.AutoSearchHeaderIndex = pressInfo.Index
                    APopupLookUpEditFormViewInfo.SortHeaderIndex = pressInfo.Index
                    SavePopupParams(TryCast(sender, PopupLookUpEditForm))
                End If
            End If
        End Sub

        Private Shared Sub SavePopupParams(ByVal popupForm As PopupLookUpEditForm)
            Dim Amethod As MethodInfo = GetType(PopupLookUpEditForm).GetMethod("SavePopupParams", BindingFlags.Instance Or BindingFlags.NonPublic)
            If Amethod IsNot Nothing Then
                Amethod.Invoke(popupForm, Nothing)
            End If
        End Sub

        Private Shared APopupForm As PopupLookUpEditForm
        Private Shared Sub PopupEvent(sender As System.Object, e As System.EventArgs)
            APopupForm = GetPopupForm(sender)

            If APopupForm IsNot Nothing Then
                AddHandler APopupForm.MouseUp, AddressOf OnMouseUp
            End If
        End Sub

        Protected Shared Function GetPopupForm(ByVal edit As DevExpress.XtraEditors.LookUpEdit) As PopupLookUpEditForm
            Dim field As FieldInfo = GetType(DevExpress.XtraEditors.PopupBaseEdit).GetField("_popupForm", BindingFlags.Instance Or BindingFlags.NonPublic)
            Return TryCast(field.GetValue(edit), PopupLookUpEditForm)
        End Function

        Protected Shared Function GetPopupFormViewInfo(ByVal popupForm As PopupLookUpEditForm) As PopupLookUpEditFormViewInfo
            Dim field As FieldInfo = GetType(PopupBaseForm).GetField("_viewInfo", BindingFlags.NonPublic Or BindingFlags.Instance)
            Return CType(field.GetValue(popupForm), DevExpress.XtraEditors.Popup.PopupLookUpEditFormViewInfo)
        End Function

        Protected Shared Function GetPressInfo(ByVal popupForm As PopupLookUpEditForm) As DevExpress.XtraEditors.Popup.LookUpPopupHitTest
            Dim field As FieldInfo = GetType(PopupLookUpEditForm).GetField("_pressInfo", BindingFlags.NonPublic Or BindingFlags.Instance)
            Return CType(field.GetValue(popupForm), DevExpress.XtraEditors.Popup.LookUpPopupHitTest)

        End Function

        Private Shared Sub CloseUpEvent(sender As System.Object, e As DevExpress.XtraEditors.Controls.CloseUpEventArgs)
            If APopupForm IsNot Nothing Then
                RemoveHandler APopupForm.MouseUp, AddressOf OnMouseUp
            End If
        End Sub
    End Class
End Namespace
