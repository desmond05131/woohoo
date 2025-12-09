Namespace Freely.Log.Helper


    Public Class FreelyLogHelper
        Public Const Freely_Log As String = "Freely_Log"

        Public Const Message_Yes As String = "Yes"
        Public Const Message_No As String = "No"


        Dim _DBSetting As AutoCount.Data.DBSetting
        Dim _UserSession As AutoCount.Authentication.UserSession
        Dim adpMaster As SqlClient.SqlDataAdapter
        Dim sqlConn As SqlClient.SqlConnection
        Dim _UserID As String = ""
        Dim _Log As New System.Text.StringBuilder
        Dim _dtLog As DataTable
        Dim _FreelyLogDAL As FreelyLogDAL.FreelyLog
        Dim _IsClearLog As Boolean = False
        Public ReadOnly Property IsClearLog As Boolean
            Get
                Return _IsClearLog
            End Get
        End Property

        Public ReadOnly Property FreelyLog As FreelyLogDAL.FreelyLog
            Get
                Return _FreelyLogDAL
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

        Public ReadOnly Property UserID As String
            Get
                Return _UserID
            End Get
        End Property
        Public Sub New(ByVal AUserSession As AutoCount.Authentication.UserSession)
            _UserSession = AUserSession
            _DBSetting = _UserSession.DBSetting
            _UserID = _UserSession.LoginUserID
            sqlConn = New SqlClient.SqlConnection(_DBSetting.ConnectionString)
            sqlConn.Open()
        End Sub

        Public Sub ClearLog()
            _Log = New System.Text.StringBuilder
        End Sub
        Public Sub WriteLog(ByVal AMessage As String)
            _Log.AppendLine(String.Format("{0}-{1}", Now.ToString("yyyy/MMM/dd HH:mm:ss"), AMessage))
        End Sub

        Public Function BoolToString(ByVal Abool As Boolean) As String
            Return IIf(Abool, "Yes", "No")
        End Function
        Public Sub Commit()
            Try
                For Each drLog As DataRow In _dtLog.Rows
                    drLog.Item("Log") = _Log.ToString
                Next
                For Each drLog As DataRow In _dtLog.Rows
                    drLog.Item("LastModified") = Now
                    drLog.Item("LastModifiedUserID") = AutoCount.Authentication.UserSession.CurrentUserSession.LoginUserID
                Next
                adpMaster.Update(Me._dtLog)
            Catch ex As Exception

            End Try
        End Sub

        Public Function GetLog(ByVal ADocKey As Long) As DataTable
            Using sqlConn As New SqlClient.SqlConnection(Me.DBSetting.ConnectionString)
                sqlConn.Open()
                Using sqlCmd As New SqlClient.SqlCommand(String.Format("Select * From {0} WHERE DocKey=@DocKey", Freely_Log), sqlConn)
                    sqlCmd.Parameters.AddWithValue("DocKey", ADocKey)
                    Using dtLog As New DataTable
                        dtLog.Load(sqlCmd.ExecuteReader)
                        Return dtLog
                    End Using
                End Using
            End Using
        End Function
        Public Sub ViewLog(ByVal ADtlKey As Long, ByVal AEventCode As String)
            If ADtlKey = -1 Then Return
            If AEventCode.Length = 0 Then Return
            Using sqlConn As New SqlClient.SqlConnection(Me.DBSetting.ConnectionString)
                sqlConn.Open()
                Using sqlCmd As New SqlClient.SqlCommand(String.Format("Select * From {0} WHERE DtlKey=@DtlKey AND EventCode=@EventCode", Freely_Log), sqlConn)
                    sqlCmd.Parameters.AddWithValue("DtlKey", ADtlKey)
                    sqlCmd.Parameters.AddWithValue("EventCode", AEventCode)
                    Using dtLog As New DataTable
                        dtLog.Load(sqlCmd.ExecuteReader)
                        If dtLog.Rows.Count = 0 Then Throw New Exception("No Log Record Found!")
                        Dim ARichText As New AutoCount.Forms.FormRichTextEditor(_DBSetting, dtLog, 0,
                                                          "Log", "Log Record.", False)
                        If ARichText.ShowDialog = Windows.Forms.DialogResult.OK Then

                        End If
                    End Using
                End Using
            End Using
        End Sub
        Public Sub Init(ByVal ADocKey As Long, ByVal ADocType As String, ByVal AEventCode As String, Optional ByVal NeedClearLog As Boolean = True)

            If ADocKey = -1 Then Return
            If ADocType.Length = 0 Then Throw New Exception("Doc Type Not Allow Empty")
            If AEventCode.Length = 0 Then Throw New Exception("Event Code Not Allow Empty")
            _IsClearLog = NeedClearLog

            adpMaster = New SqlClient.SqlDataAdapter(String.Format("Select * From {0} WHERE DocKey=@DocKey AND DocType=@DocType AND EventCode=@EventCode", Freely_Log), sqlConn)
            adpMaster.SelectCommand.Parameters.AddWithValue("DocKey", ADocKey)
            adpMaster.SelectCommand.Parameters.AddWithValue("DocType", ADocType)
            adpMaster.SelectCommand.Parameters.AddWithValue("EventCode", AEventCode)


            Dim ACmdBuilder As New SqlClient.SqlCommandBuilder(adpMaster)
            ACmdBuilder.ConflictOption = ConflictOption.OverwriteChanges
            adpMaster.DeleteCommand = ACmdBuilder.GetDeleteCommand
            adpMaster.InsertCommand = ACmdBuilder.GetInsertCommand
            adpMaster.UpdateCommand = ACmdBuilder.GetUpdateCommand

            _dtLog = New DataTable
            adpMaster.Fill(_dtLog)
            If _dtLog.Rows.Count = 0 Then
                Dim ASerialNumber As New AutoCount.SerialNumber.SerialNumberHelper(Me._UserSession, Me.DBSetting)

                Dim drNew As DataRow = _dtLog.NewRow
                _FreelyLogDAL = New FreelyLogDAL.FreelyLog(drNew)
                '---This 3 is Primary Key
                _FreelyLogDAL.DocKey = ADocKey
                _FreelyLogDAL.DtlKey = ASerialNumber.GetNextDocKey
                _FreelyLogDAL.EventCode = AEventCode
                '-------------------------

                _FreelyLogDAL.DocType = ADocType
                _FreelyLogDAL.CreatedTimeStamp = Now
                _FreelyLogDAL.CreatedUserID = Me.UserID

                _FreelyLogDAL.DocNo = GetDocumentNo(ADocType, ADocKey)
                _dtLog.Rows.Add(drNew)
            Else
                _FreelyLogDAL = New FreelyLogDAL.FreelyLog(_dtLog.Rows(0))
                _FreelyLogDAL.DocNo = GetDocumentNo(ADocType, ADocKey)
                _Log = New System.Text.StringBuilder
                If Not _IsClearLog Then

                    _Log.AppendLine(_FreelyLogDAL.Log)
                    _Log.AppendLine("=================")
                End If
            End If
        End Sub
        Private Function GetDocumentNo(ByVal ADocType As String, ByVal ADocKey As Long) As String
            Try
                Dim sTableName As String = ADocType
                If ADocType = "PQ" Then
                    sTableName = "PurchaseRequest"
                ElseIf ADocType = "SP" Then
                    sTableName = "Freely_Shipment"
                End If
                Using sqlCmd As New SqlClient.SqlCommand(String.Format("Select DocNo From {0} WHERE DocKey=@DocKey", sTableName), sqlConn)
                    sqlCmd.Parameters.AddWithValue("DocKey", ADocKey)
                    Using dtRecord As New DataTable
                        dtRecord.Load(sqlCmd.ExecuteReader)
                        For Each drRecord As DataRow In dtRecord.Rows
                            Return drRecord.Item("DocNo").ToString
                        Next
                    End Using
                End Using
            Catch ex As Exception

            End Try
            Return ""
        End Function
        'This is Similar like Plugin Generate Custom Query
        Public Sub GenerateLogTable()
            Dim sSQL As New System.Text.StringBuilder
            sSQL.AppendLine("  IF Not EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Freely_Log]') AND type in (N'U')) ")
            sSQL.AppendLine(" BEGIN ")
            sSQL.AppendLine("CREATE TABLE [dbo].[Freely_Log](")
            sSQL.AppendLine("	[DtlKey] [bigint] NOT NULL,")
            sSQL.AppendLine("	[EventCode] [nvarchar](50) NOT NULL,")
            sSQL.AppendLine("	[DocKey] [bigint] NULL,")
            sSQL.AppendLine("	[DocType] [nvarchar](50) NULL,")
            sSQL.AppendLine("	[Log] [ntext] NULL,")
            sSQL.AppendLine("	[DocNo] [nvarchar](50) NULL,")
            sSQL.AppendLine("	[EventDescription] [nvarchar](150) NULL,")
            sSQL.AppendLine("	[LastModified] [datetime] NULL,")
            sSQL.AppendLine("	[LastModifiedUserID] [dbo].[d_UserID] NULL,")
            sSQL.AppendLine("	[CreatedTimeStamp] [datetime] NULL,")
            sSQL.AppendLine("	[CreatedUserID] [dbo].[d_UserID] NULL,")
            sSQL.AppendLine(" CONSTRAINT [PK_Freely_Log] PRIMARY KEY CLUSTERED ")
            sSQL.AppendLine("(")
            sSQL.AppendLine("	[DtlKey] ASC,")
            sSQL.AppendLine("	[EventCode] ASC")
            sSQL.AppendLine(")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]")
            sSQL.AppendLine(") ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]")
            sSQL.AppendLine(" END ")

            Try
                Using sqlConn As New SqlClient.SqlConnection(Me.DBSetting.ConnectionString)
                    sqlConn.Open()
                    Using cmd As New SqlClient.SqlCommand(sSQL.ToString, sqlConn)
                        cmd.ExecuteScalar()
                    End Using
                End Using
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Freely")
            End Try
        End Sub
    End Class

    Public Class FreelyToolTipsHelper

        Public Property DecimalPointScale As Integer = 2

        Public Sub AddControlTips(ByVal ATextEdit As DevExpress.XtraEditors.TextEdit, ByVal AFreelyToolsTipsDAL As FreelyToolsTipsDAL)
            Dim AFreelyTips As New DevExpress.Utils.SuperToolTip
            ATextEdit.SuperTip = AFreelyTips
            InitSuperTips(ATextEdit.SuperTip, AFreelyToolsTipsDAL)
        End Sub

        Public Sub AddControlTips(ByVal ASimpleButton As DevExpress.XtraEditors.SimpleButton, ByVal AFreelyToolsTipsDAL As FreelyToolsTipsDAL)
            Dim AFreelyTips As New DevExpress.Utils.SuperToolTip
            ASimpleButton.SuperTip = AFreelyTips
            InitSuperTips(ASimpleButton.SuperTip, AFreelyToolsTipsDAL)
        End Sub

        Public Sub AddControlTips(ByVal ALabelControl As DevExpress.XtraEditors.LabelControl, ByVal AFreelyToolsTipsDAL As FreelyToolsTipsDAL)
            Dim AFreelyTips As New DevExpress.Utils.SuperToolTip
            ALabelControl.SuperTip = AFreelyTips
            InitSuperTips(ALabelControl.SuperTip, AFreelyToolsTipsDAL)
        End Sub

        Public Sub AddControlTips(ByVal AGridControl As DevExpress.XtraGrid.GridControl,
                                  ByVal AGridView As DevExpress.XtraGrid.Views.Grid.GridView,
                                  ByVal AFreelyToolsTipsDAL As List(Of FreelyToolsTipsDAL))
            Dim AToolTipController As New DevExpress.Utils.ToolTipController
            AToolTipController.ShowBeak = True
            AToolTipController.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip

            AGridControl.ToolTipController = AToolTipController
            AGridView.Tag = AFreelyToolsTipsDAL

            RemoveHandler AToolTipController.GetActiveObjectInfo, AddressOf GridControlToolTipObjectEvent
            AddHandler AToolTipController.GetActiveObjectInfo, AddressOf GridControlToolTipObjectEvent
        End Sub

        Private Sub GridControlToolTipObjectEvent(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs)
            Try
                If sender IsNot Nothing Then

                    Dim gcControl As DevExpress.XtraGrid.GridControl = e.SelectedControl
                    Dim gvView As DevExpress.XtraGrid.Views.Grid.GridView = gcControl.FocusedView
                    If gvView IsNot Nothing Then
                        If gvView.Tag Is Nothing Then Return
                        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = gvView.CalcHitInfo(e.ControlMousePosition)
                        If info.InRowCell Then
                            Dim AFreelyTipsDAL As List(Of FreelyToolsTipsDAL) = gvView.Tag
                            For i As Integer = 0 To AFreelyTipsDAL.Count - 1
                                AFreelyTipsDAL(i).FormulaRow = Nothing
                                If AFreelyTipsDAL(i).FieldName.Length = 0 Then Continue For
                                If AFreelyTipsDAL(i).FieldName.ToUpper = info.Column.FieldName.ToUpper Then
                                    If info.RowHandle > -1 Then
                                        AFreelyTipsDAL(i).FormulaRow = gvView.GetDataRow(info.RowHandle)
                                        Dim AFreelySuperTips As New DevExpress.Utils.SuperToolTip
                                        e.Info = New DevExpress.Utils.ToolTipControlInfo()
                                        Dim cellKey As String = info.RowHandle.ToString() & " - " & info.Column.ToString()
                                        e.Info.Object = cellKey
                                        e.Info.SuperTip = AFreelySuperTips
                                        InitSuperTips(e.Info.SuperTip, AFreelyTipsDAL(i))
                                    End If                                                            
                                End If
                            Next
                        End If
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub
        Private Sub InitSuperTips(ByVal ASuperTips As DevExpress.Utils.SuperToolTip, ByVal AFreelyToolsTipsDAL As FreelyToolsTipsDAL)
            Dim AHeaderItems As New DevExpress.Utils.ToolTipTitleItem
            AHeaderItems.Text = AFreelyToolsTipsDAL.Title

            Dim AContentItems As New DevExpress.Utils.ToolTipItem
            AContentItems.Text = AFreelyToolsTipsDAL.Content + vbCrLf

            ASuperTips.Items.Add(AHeaderItems)
            ASuperTips.Items.Add(AContentItems)
            If AFreelyToolsTipsDAL.FormulaRow IsNot Nothing And AFreelyToolsTipsDAL.FormulaContent.Length > 0 Then
                AContentItems.Text = AContentItems.Text + String.Format("{0}", DataRowToValue(AFreelyToolsTipsDAL.FormulaRow, AFreelyToolsTipsDAL.FormulaContent)) + vbCrLf
            End If
        End Sub

        Private Function DataRowToValue(ByVal ADataRow As DataRow, ByVal AExpression As String) As String
            Dim sContent As String = AExpression
            Try
                Dim Prefix As String = ""
                For Each dcCol As DataColumn In ADataRow.Table.Columns
                    Dim sColmnName As String = dcCol.ColumnName
                    If ADataRow.Table.Columns.Contains(sColmnName) Then
                        If ADataRow.Table.Columns(sColmnName).DataType.ToString.ToUpper = "SYSTEM.DATETIME".ToUpper Then
                        ElseIf ADataRow.Table.Columns(sColmnName).DataType.ToString.ToUpper = "SYSTEM.DECIMAL".ToUpper Then
                            Dim iDecimal As Decimal = IIf(ADataRow.Item(sColmnName) Is DBNull.Value, 0, ADataRow.Item(sColmnName))
                            sContent = sContent.Replace(String.Format("%{0}%", sColmnName), String.Format("{0}", iDecimal.ToString(String.Format("n{0}", DecimalPointScale))))
                        ElseIf ADataRow.Table.Columns(sColmnName).DataType.ToString.ToUpper = "SYSTEM.INT32".ToUpper Then
                            sContent = sContent.Replace(String.Format("%{0}%", sColmnName), "0")
                        ElseIf ADataRow.Table.Columns(sColmnName).DataType.ToString.ToUpper = "SYSTEM.STRING".ToUpper Then
                            sContent = sContent.Replace(String.Format("%{0}%", sColmnName), String.Format("'{0}'", ADataRow.Item(sColmnName).ToString))
                        End If
                    End If
                Next
            Catch ex As Exception
                Throw ex
            End Try
            Return sContent
        End Function

        Public Class FreelyToolsTipsDAL

            Public Property FieldName As String = ""
            Public Property Title As String = ""
            Public Property Content As String = ""
            Public Property FormulaContent As String = ""
            Public Property FormulaRow As DataRow = Nothing
        End Class
    End Class
End Namespace