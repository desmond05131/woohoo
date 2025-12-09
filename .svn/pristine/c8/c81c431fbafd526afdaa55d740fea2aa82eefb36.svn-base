Namespace Freely.Controls

    Public Class FreelyControlHelper
        Implements IDisposable

        Dim _X As Integer = -1
        Dim _Y As Integer = -1
        Dim _RegKeyID As String = ""
        Dim _Location As String = ""
        Public ReadOnly Property X As Integer
            Get
                Return _X
            End Get
        End Property
        Public ReadOnly Property Location As String
            Get
                Return _Location
            End Get
        End Property

        Public ReadOnly Property Y As Integer
            Get
                Return _Y
            End Get
        End Property
        Public ReadOnly Property RegKeyID As String
            Get
                Return _RegKeyID
            End Get
        End Property

        Public Property DBSetting As AutoCount.Data.DBSetting

        Public Property FormName As String

        Public ReadOnly Property GroupPanel As DevExpress.XtraEditors.PanelControl
            Get
                Return _groupPanel
            End Get
        End Property

        Public ReadOnly Property PanelHeader As DevExpress.XtraEditors.PanelControl
            Get
                Return _panelHeader
            End Get
        End Property

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
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
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

        Dim _sPlugInName As String = String.Empty
        Dim _panelHeader As DevExpress.XtraEditors.PanelControl
        Dim _groupPanel As DevExpress.XtraEditors.PanelControl
        Dim _sGroupPanelName = "ING_GroupPanel"
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="PluginName">this plugin name will show in the control Group text, use short and meaningful name</param>
        ''' <param name="HeaderPanel"></param>
        ''' <param name="DocType"></param>
        ''' <param name="IsEditForm"></param>
        ''' <remarks></remarks>
        Sub New(ByVal PluginName As String, ByVal HeaderPanel As DevExpress.XtraEditors.PanelControl, ByVal DocType As String, Optional ByVal IsEditForm As Boolean = True)
            _sPlugInName = PluginName
            _panelHeader = HeaderPanel
            Dim RegKeyID = String.Empty
            If IsEditForm Then
                RegKeyID = DocType.ToString() + "_EditForm"
            Else
                RegKeyID = DocType.ToString() + "_CmdForm"
            End If

            _RegKeyID = RegKeyID

            Dim AKeyCmd As Freely.Registry.FreelyRegistry
            If Me.DBSetting Is Nothing Then
                AKeyCmd = New Freely.Registry.FreelyRegistry(AutoCount.Authentication.UserSession.CurrentUserSession.DBSetting)
            Else
                AKeyCmd = New Registry.FreelyRegistry(Me.DBSetting)
            End If

            ' 
            Dim ADocumentTypeKey = AKeyCmd.GetRegistryKey(RegKeyID)
            If Not ADocumentTypeKey.HasValue Then
                ADocumentTypeKey = Freely.Registry.FreelyRegistryKey.Create(RegKeyID, Enumeration.FreelyEnum.FreelyRegistryType.String, "10,145")
            End If

            Dim X As Integer = 10
            Dim Y As Integer = 165
            _Location = ADocumentTypeKey.RegistryValue
            If ADocumentTypeKey.RegistryValue.Split(",").Length > 1 Then
                Try
                    X = ADocumentTypeKey.RegistryValue.Split(",")(0)
                    Y = ADocumentTypeKey.RegistryValue.Split(",")(1)
                Catch ex As Exception
                    DevExpress.XtraEditors.XtraMessageBox.Show("Please check special control location setting in General Setting")
                    X = 10
                    Y = 165
                End Try
                _X = X
                _Y = Y
            End If


            PrepareControlForHeader(X, Y)
        End Sub
        'Public Sub Init()
        '    Dim sqlConn As New SqlClient.SqlConnection(Me.DBSetting.ConnectionString)

        '    adpProperty = New SqlClient.SqlDataAdapter("Select * From FreelyLayout Where FormName=@FormName", sqlConn)
        '    adpProperty.SelectCommand.Parameters.AddWithValue("FormName", Me.FormName)
        '    Dim ABuilder As New SqlClient.SqlCommandBuilder(adpProperty)
        '    ABuilder.ConflictOption = ConflictOption.OverwriteChanges
        '    adpProperty.DeleteCommand = ABuilder.GetDeleteCommand
        '    adpProperty.InsertCommand = ABuilder.GetInsertCommand
        '    adpProperty.UpdateCommand = ABuilder.GetUpdateCommand

        '    adpProperty.Fill(dsProperty)

        '    Dim AProperty As New DevExpress.XtraVerticalGrid.PropertyGridControl
        '    For Each drProperty As DataRow In dsProperty.Tables(0).Rows
        '        'ObjectName, ObjectType, FormName, PropertyName, PropertyType, Value
        '        Dim sObjectName As String = drProperty.Item("ObjectName").ToString
        '        Dim sObjectType As String = drProperty.Item("ObjectType").ToString
        '        Dim sFormName As String = drProperty.Item("FormName").ToString
        '        Dim sPropertyName As String = drProperty.Item("PropertyName").ToString
        '        Dim sPropertyType As String = drProperty.Item("PropertyType").ToString
        '        Dim sValue As String = drProperty.Item("Value").ToString
        '        Dim objName As Object() = TryCast(_groupPanel, DevExpress.XtraEditors.PanelControl).Controls.Find(sObjectName, True)
        '        If objName.Length > 0 Then
        '            Try
        '                AProperty.SelectedObject = objName(0)
        '                AProperty.Rows(sPropertyName).Properties.Value = sValue
        '            Catch ex As Exception

        '            End Try
        '        End If
        '    Next
        'End Sub
        Private Sub PrepareControlForHeader(ByVal X As Integer, ByVal Y As Integer)
            Try


                'Dim X = 10
                'Dim Y = 145

                Dim GroupPanel As New DevExpress.XtraEditors.PanelControl
                GroupPanel.Name = _sGroupPanelName
                GroupPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Left
                GroupPanel.Location = New Point(X, Y)
                GroupPanel.Height = 55
                'GroupPanel.Width = 600
                GroupPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder



                Dim tempCtrl As Control() = _panelHeader.Controls.Find(_sGroupPanelName, True)
                If tempCtrl.Length > 0 Then
                    GroupPanel = tempCtrl(0)
                    Dim tempCtrl2 As Control() = GroupPanel.Controls.Find(_sPlugInName, True)
                    If tempCtrl2.Length > 0 Then
                        TryCast(tempCtrl2(0), System.Windows.Forms.Control).Dispose()
                        'For Each ctrl In tempCtrl2(0).Controls
                        '    TryCast(ctrl, System.Windows.Forms.Control).Dispose()
                        'Next
                    End If
                End If
                _groupPanel = GroupPanel
            Catch ex As Exception

            End Try
        End Sub


        Public Sub InitControl()
            If _groupPanel.Controls.Count > 0 Then
                _panelHeader.Controls.Add(_groupPanel)
                'set group control width here
                Dim TtlWidth = 0
                For Each ctrls In _groupPanel.Controls
                    TtlWidth += TryCast(ctrls, DevExpress.XtraEditors.PanelControl).Width + 1
                Next
                _groupPanel.Width = TtlWidth
            End If
        End Sub

        Public Sub AddControl(ByVal Ctrl As Control)
            Dim W = 80
            Dim GroupCtrl As New DevExpress.XtraEditors.GroupControl
            GroupCtrl.Dock = DockStyle.Left
            GroupCtrl.Height = _groupPanel.Height
            GroupCtrl.Name = _sPlugInName
            GroupCtrl.Text = _sPlugInName

            Dim tempCtrl As Control() = _groupPanel.Controls.Find(_sPlugInName, True)
            If tempCtrl.Length > 0 Then
                GroupCtrl = tempCtrl(0)
            End If
            _groupPanel.Controls.Add(GroupCtrl)

            Dim _panelCtrl As New DevExpress.XtraEditors.PanelControl
            _panelCtrl.Dock = DockStyle.Left
            _panelCtrl.Width = Ctrl.Width + 2
            _panelCtrl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            _panelCtrl.Margin = New Padding(0)
            _panelCtrl.Height = Ctrl.Height + 10
            Ctrl.Location = New Point(1, 5)
            _panelCtrl.Controls.Add(Ctrl)


            GroupCtrl.Controls.Add(_panelCtrl)
            'set Group Ctrl width
            Dim TtlWidth = 0
            For Each ctrls In GroupCtrl.Controls
                TtlWidth += TryCast(ctrls, DevExpress.XtraEditors.PanelControl).Width + 1
            Next
            GroupCtrl.Width = TtlWidth + 5
        End Sub

    End Class

End Namespace
