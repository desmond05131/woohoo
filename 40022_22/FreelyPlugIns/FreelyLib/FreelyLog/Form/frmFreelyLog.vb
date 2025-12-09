Namespace Freely.Log.Form
    Public Class frmFreelyLog

        Dim _DBSetting As AutoCount.Data.DBSetting
        Dim _UserSession As AutoCount.Authentication.UserSession
        Dim _DocKey As Long = -1
        Dim _FreelyLogHelper As Freely.Log.Helper.FreelyLogHelper
        Public ReadOnly Property DocKey As Long
            Get
                Return _DocKey
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

        Public Sub New(ByVal AUserSession As AutoCount.Authentication.UserSession, ByVal ADocKey As Long)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _UserSession = AUserSession
            _DBSetting = AUserSession.DBSetting
            _DocKey = ADocKey
        End Sub

        Private Sub frmFreelyLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Try
                _FreelyLogHelper = New Freely.Log.Helper.FreelyLogHelper(Me.UserSession)
                Me.dtMaster.Clear()
                Me.dtMaster.Merge(_FreelyLogHelper.GetLog(Me.DocKey))
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub gvMaster_DoubleClick(sender As Object, e As EventArgs) Handles gvMaster.DoubleClick
            If gvMaster.FocusedRowHandle > -1 Then
                Try
                    Dim iDtlKey As Long = IIf(gvMaster.GetDataRow(gvMaster.FocusedRowHandle).Item("DtlKey") Is DBNull.Value, 0, gvMaster.GetDataRow(gvMaster.FocusedRowHandle).Item("DtlKey"))
                    Dim sEventCode As String = gvMaster.GetDataRow(gvMaster.FocusedRowHandle).Item("EventCode").ToString
                    _FreelyLogHelper.ViewLog(iDtlKey, sEventCode)
                Catch ex As Exception
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Freely")
                End Try
            
            End If
        End Sub
    End Class
End Namespace
