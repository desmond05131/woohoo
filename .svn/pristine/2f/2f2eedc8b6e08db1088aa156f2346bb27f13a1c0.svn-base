Imports DevExpress.XtraEditors

Namespace Freely.Utli
    Public Class FreelyUtli
        Private _AConn As AutoCount.Data.DBSetting

        Private _UserSession As AutoCount.Authentication.UserSession
        Public ReadOnly Property DBConn As AutoCount.Data.DBSetting
            Get
                Return _AConn
            End Get
        End Property
        Public ReadOnly Property UserSession As AutoCount.Authentication.UserSession
            Get
                Return _UserSession
            End Get
        End Property
        Public Sub New(ByVal AUserSession As AutoCount.Authentication.UserSession, ByVal AConn As AutoCount.Data.DBSetting)
            Me._AConn = AConn
            Me._UserSession = AUserSession
        End Sub

        Public Sub AddLayoutManager(ByVal AGridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal AFormName As String)
            Dim ALayout As New AutoCount.XtraUtils.CustomizeGridLayout(_UserSession, AFormName, AGridView)
            If ALayout.HasDefaultLayout Then
                Dim ALayout2 As New AutoCount.XtraUtils.LayoutMaintenance(_UserSession)

                Dim iLastUpdate As Long = -1
                Dim sTitle As String = String.Empty
                Dim sXML As String = ALayout2.LoadDefaulLayout(AFormName, AGridView.Name, iLastUpdate, sTitle)
                If sXML.Length > 0 Then
                    Dim AIOStream As New IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(sXML))
                    AGridView.RestoreLayoutFromStream(AIOStream)
                End If
            End If

        End Sub

        Public Sub AddLayoutManager(ByVal AMultiDimensinoal As DevExpress.XtraPivotGrid.PivotGridControl, ByVal AFormName As String)
            If AMultiDimensinoal IsNot Nothing Then
                '      Me._AConn = New AutoCount.Data.DBSetting(BCE.Data.DBServerType.SQL2000, "packet size=4096;user id=sa;password=@ppleCut387;data source=FREELYLAI-PC\ENTERPRICE;initial catalog=AED_Absolute")
                Dim ALayout As New Freely.Utli.PivotGrid.PivotLayoutMaintenance(Me.DBConn, AFormName, AMultiDimensinoal)
            End If
        End Sub




        Public Shared Sub SetFormControlEditMode(ByVal AEditMode As AutoCount.Document.EditWindowMode, ByVal AFormControl As Control, ByVal ADataTable As DataTable, ByVal AFocusControl As Control)
            ' To set the control for from according for the state
            Dim sField As String = ""
            Dim tempControl As Control
            Dim iLength As Integer
            Dim boolReadOnly As Boolean

            Select Case AEditMode
                Case AutoCount.Document.EditWindowMode.View
                    ' View Mode
                    ADataTable.Clear()
                    For Each tempControl In AFormControl.Controls
                        If ((TypeOf tempControl Is System.Windows.Forms.GroupBox) Or _
                        (TypeOf tempControl Is System.Windows.Forms.Panel) Or _
                        (TypeOf tempControl Is System.Windows.Forms.TabControl) Or _
                        (TypeOf tempControl Is System.Windows.Forms.TabPage) Or _
                        (TypeOf tempControl Is DevExpress.XtraEditors.GroupControl) Or _
                        (TypeOf tempControl Is DevExpress.XtraTab.XtraTabPage) Or _
                        (TypeOf tempControl Is DevExpress.XtraTab.XtraTabControl) Or _
                         (TypeOf tempControl Is DevExpress.XtraEditors.PanelControl)) And _
                        (tempControl.Controls.Count > 0) Then
                            SetFormControlEditMode(AEditMode, tempControl, ADataTable, AFocusControl)
                        End If

                        If ((tempControl.DataBindings IsNot Nothing) And (tempControl.DataBindings.Count > 0)) Then

                            sField = tempControl.DataBindings.Item(0).BindingMemberInfo.BindingField.ToString
                            If (sField.Length > 0) And (ADataTable.Columns(sField) IsNot Nothing) Then
                                'Set Max Length of Fields
                                If ADataTable.Columns(sField).MaxLength > -1 Then
                                    iLength = ADataTable.Columns(sField).MaxLength
                                    If TypeOf tempControl Is TextEdit Then
                                        DirectCast(tempControl, TextEdit).Properties.MaxLength = iLength
                                    ElseIf (TypeOf tempControl Is Windows.Forms.ComboBox) Then
                                        DirectCast(tempControl, Windows.Forms.ComboBox).MaxLength = iLength
                                    ElseIf (TypeOf tempControl Is DevExpress.XtraEditors.LookUpEdit) Then
                                        DirectCast(tempControl, DevExpress.XtraEditors.LookUpEdit).Properties.MaxLength = iLength
                                    ElseIf (TypeOf tempControl Is DevExpress.XtraEditors.ComboBoxEdit) Then
                                        DirectCast(tempControl, DevExpress.XtraEditors.ComboBoxEdit).Properties.MaxLength = iLength
                                    ElseIf (TypeOf tempControl Is DevExpress.XtraEditors.ButtonEdit) Then
                                        DirectCast(tempControl, DevExpress.XtraEditors.ButtonEdit).Properties.MaxLength = iLength
                                    End If
                                End If

                            End If
                        End If
                        boolReadOnly = True

                        If TypeOf tempControl Is TextEdit Then
                            DirectCast(tempControl, TextEdit).Properties.ReadOnly = boolReadOnly
                            DirectCast(tempControl, TextEdit).Enabled = True
                        ElseIf TypeOf tempControl Is RadioButton Then
                            DirectCast(tempControl, RadioButton).Enabled = boolReadOnly
                        ElseIf TypeOf tempControl Is LookUpEdit Then
                            DirectCast(tempControl, LookUpEdit).Properties.ReadOnly = boolReadOnly
                            DirectCast(tempControl, LookUpEdit).Enabled = True
                        ElseIf TypeOf tempControl Is DateEdit Then
                            DirectCast(tempControl, DateEdit).Properties.ReadOnly = boolReadOnly
                            DirectCast(tempControl, DateEdit).Enabled = True
                        ElseIf TypeOf tempControl Is ComboBoxEdit Then
                            DirectCast(tempControl, ComboBoxEdit).Properties.ReadOnly = boolReadOnly
                            DirectCast(tempControl, ComboBoxEdit).Enabled = True
                        ElseIf TypeOf tempControl Is ButtonEdit Then
                            DirectCast(tempControl, ButtonEdit).Properties.ReadOnly = boolReadOnly
                            DirectCast(tempControl, ButtonEdit).Enabled = True
                        ElseIf TypeOf tempControl Is DevExpress.XtraGrid.GridControl Then
                            For Each View As DevExpress.XtraGrid.Views.Grid.GridView In DirectCast(tempControl, DevExpress.XtraGrid.GridControl).Views
                                View.OptionsBehavior.Editable = False
                            Next
                        End If
                    Next

                    If AFocusControl IsNot Nothing Then
                        AFocusControl.Focus()
                    End If
                Case AutoCount.Document.EditWindowMode.Edit
                    ' Edit Mode
                    ADataTable.Clear()
                    For Each tempControl In AFormControl.Controls
                        If ((TypeOf tempControl Is System.Windows.Forms.GroupBox) Or _
                        (TypeOf tempControl Is System.Windows.Forms.Panel) Or _
                        (TypeOf tempControl Is System.Windows.Forms.TabControl) Or _
                        (TypeOf tempControl Is System.Windows.Forms.TabPage) Or _
                        (TypeOf tempControl Is DevExpress.XtraEditors.GroupControl) Or _
                        (TypeOf tempControl Is DevExpress.XtraTab.XtraTabPage) Or _
                        (TypeOf tempControl Is DevExpress.XtraTab.XtraTabControl) Or _
                         (TypeOf tempControl Is DevExpress.XtraEditors.PanelControl)) And _
                        (tempControl.Controls.Count > 0) Then
                            SetFormControlEditMode(AEditMode, tempControl, ADataTable, AFocusControl)
                        End If

                        If ((tempControl.DataBindings IsNot Nothing) And (tempControl.DataBindings.Count > 0)) Then

                            sField = tempControl.DataBindings.Item(0).BindingMemberInfo.BindingField.ToString
                            If (sField.Length > 0) And (ADataTable.Columns(sField) IsNot Nothing) Then
                                'Set Max Length of Fields
                                If ADataTable.Columns(sField).MaxLength > -1 Then
                                    iLength = ADataTable.Columns(sField).MaxLength
                                    If TypeOf tempControl Is TextEdit Then
                                        DirectCast(tempControl, TextEdit).Properties.MaxLength = iLength
                                    ElseIf (TypeOf tempControl Is Windows.Forms.ComboBox) Then
                                        DirectCast(tempControl, Windows.Forms.ComboBox).MaxLength = iLength
                                    ElseIf (TypeOf tempControl Is DevExpress.XtraEditors.LookUpEdit) Then
                                        DirectCast(tempControl, DevExpress.XtraEditors.LookUpEdit).Properties.MaxLength = iLength
                                    ElseIf (TypeOf tempControl Is DevExpress.XtraEditors.ComboBoxEdit) Then
                                        DirectCast(tempControl, DevExpress.XtraEditors.ComboBoxEdit).Properties.MaxLength = iLength
                                    ElseIf (TypeOf tempControl Is DevExpress.XtraEditors.ButtonEdit) Then
                                        DirectCast(tempControl, DevExpress.XtraEditors.ButtonEdit).Properties.MaxLength = iLength
                                    End If
                                End If

                                If ADataTable.Columns(sField).Unique Then
                                    ' Key Field
                                    If TypeOf tempControl Is TextEdit Then
                                        tempControl.BackColor = SystemColors.Info
                                        DirectCast(tempControl, TextEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                        DirectCast(tempControl, TextEdit).Properties.ReadOnly = True
                                        DirectCast(tempControl, TextEdit).Properties.CharacterCasing = CharacterCasing.Upper
                                    ElseIf TypeOf tempControl Is DateEdit Then
                                        tempControl.BackColor = SystemColors.Info
                                        DirectCast(tempControl, DateEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                        DirectCast(tempControl, DateEdit).Properties.ReadOnly = True
                                    ElseIf TypeOf tempControl Is DevExpress.XtraEditors.ComboBoxEdit Then
                                        tempControl.BackColor = SystemColors.Info
                                        DirectCast(tempControl, DevExpress.XtraEditors.ComboBoxEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                        DirectCast(tempControl, DevExpress.XtraEditors.ComboBoxEdit).Properties.ReadOnly = True
                                    ElseIf TypeOf tempControl Is DevExpress.XtraEditors.LookUpEdit Then
                                        tempControl.BackColor = SystemColors.Info
                                        DirectCast(tempControl, DevExpress.XtraEditors.LookUpEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                        DirectCast(tempControl, DevExpress.XtraEditors.LookUpEdit).Properties.ReadOnly = True
                                    ElseIf TypeOf tempControl Is DevExpress.XtraEditors.ButtonEdit Then
                                        tempControl.BackColor = SystemColors.Info
                                        DirectCast(tempControl, DevExpress.XtraEditors.ButtonEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                        DirectCast(tempControl, DevExpress.XtraEditors.ButtonEdit).Properties.ReadOnly = True
                                    End If
                                Else
                                    boolReadOnly = ADataTable.Columns(sField).ReadOnly
                                    If TypeOf tempControl Is TextEdit Then
                                        DirectCast(tempControl, TextEdit).Properties.ReadOnly = boolReadOnly
                                    ElseIf TypeOf tempControl Is RadioButton Then
                                        DirectCast(tempControl, RadioButton).Enabled = boolReadOnly
                                    ElseIf TypeOf tempControl Is LookUpEdit Then
                                        DirectCast(tempControl, LookUpEdit).Properties.ReadOnly = boolReadOnly
                                    ElseIf TypeOf tempControl Is DateEdit Then
                                        DirectCast(tempControl, DateEdit).Properties.ReadOnly = boolReadOnly
                                    ElseIf TypeOf tempControl Is ComboBoxEdit Then
                                        DirectCast(tempControl, ComboBoxEdit).Properties.ReadOnly = boolReadOnly
                                    ElseIf TypeOf tempControl Is ButtonEdit Then
                                        DirectCast(tempControl, ButtonEdit).Properties.ReadOnly = boolReadOnly
                                    End If

                                    If Not ADataTable.Columns(sField).AllowDBNull Then
                                        If TypeOf tempControl Is TextEdit Then
                                            tempControl.BackColor = SystemColors.Info
                                            DirectCast(tempControl, TextEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                            DirectCast(tempControl, TextEdit).Properties.ReadOnly = True
                                        ElseIf TypeOf tempControl Is LookUpEdit Then
                                            tempControl.BackColor = SystemColors.Info
                                            DirectCast(tempControl, LookUpEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                            DirectCast(tempControl, LookUpEdit).Properties.ReadOnly = True
                                        ElseIf TypeOf tempControl Is DateEdit Then
                                            tempControl.BackColor = SystemColors.Info
                                            DirectCast(tempControl, DateEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                            DirectCast(tempControl, DateEdit).Properties.ReadOnly = True
                                        ElseIf TypeOf tempControl Is ComboBoxEdit Then
                                            tempControl.BackColor = SystemColors.Info
                                            DirectCast(tempControl, ComboBoxEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                            DirectCast(tempControl, ComboBoxEdit).Properties.ReadOnly = True
                                        ElseIf TypeOf tempControl Is ButtonEdit Then
                                            tempControl.BackColor = SystemColors.Info
                                            DirectCast(tempControl, ButtonEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                            DirectCast(tempControl, ButtonEdit).Properties.ReadOnly = True
                                        End If
                                    End If

                                End If
                            End If
                        End If

                        If TypeOf tempControl Is DevExpress.XtraGrid.GridControl Then
                            For Each View As DevExpress.XtraGrid.Views.Grid.GridView In DirectCast(tempControl, DevExpress.XtraGrid.GridControl).Views
                                View.OptionsBehavior.Editable = True
                            Next
                        End If

                    Next


                    If AFocusControl IsNot Nothing Then
                        AFocusControl.Focus()
                    End If
                Case AutoCount.Document.EditWindowMode.New
                    ' Append Mode
                    ADataTable.Clear()
                    For Each tempControl In AFormControl.Controls
                        If ((TypeOf tempControl Is System.Windows.Forms.GroupBox) Or _
                            (TypeOf tempControl Is System.Windows.Forms.Panel) Or _
                            (TypeOf tempControl Is System.Windows.Forms.TabControl) Or _
                            (TypeOf tempControl Is System.Windows.Forms.TabPage) Or _
                            (TypeOf tempControl Is DevExpress.XtraEditors.GroupControl) Or _
                            (TypeOf tempControl Is DevExpress.XtraTab.XtraTabPage) Or _
                            (TypeOf tempControl Is DevExpress.XtraTab.XtraTabControl) Or _
                            (TypeOf tempControl Is DevExpress.XtraEditors.PanelControl)) And _
                            (tempControl.Controls.Count > 0) Then
                            SetFormControlEditMode(AEditMode, tempControl, ADataTable, AFocusControl)
                        End If

                        If ((tempControl.DataBindings IsNot Nothing) And (tempControl.DataBindings.Count > 0)) Then

                            sField = tempControl.DataBindings.Item(0).BindingMemberInfo.BindingField.ToString

                            If (sField.Length > 0) And (ADataTable.Columns(sField) IsNot Nothing) Then
                                If ADataTable.Columns(sField).MaxLength > -1 Then
                                    iLength = ADataTable.Columns(sField).MaxLength

                                    If TypeOf tempControl Is TextEdit Then
                                        DirectCast(tempControl, TextEdit).Properties.MaxLength = iLength
                                    ElseIf (TypeOf tempControl Is Windows.Forms.ComboBox) Then
                                        DirectCast(tempControl, Windows.Forms.ComboBox).MaxLength = iLength
                                    ElseIf (TypeOf tempControl Is DevExpress.XtraEditors.LookUpEdit) Then
                                        DirectCast(tempControl, DevExpress.XtraEditors.LookUpEdit).Properties.MaxLength = iLength
                                    ElseIf (TypeOf tempControl Is DevExpress.XtraEditors.ComboBoxEdit) Then
                                        DirectCast(tempControl, DevExpress.XtraEditors.ComboBoxEdit).Properties.MaxLength = iLength
                                    ElseIf (TypeOf tempControl Is DevExpress.XtraEditors.ButtonEdit) Then
                                        DirectCast(tempControl, DevExpress.XtraEditors.ButtonEdit).Properties.MaxLength = iLength
                                    End If
                                End If

                                If ADataTable.Columns(sField).Unique Then
                                    ' Key Field    
                                    If TypeOf tempControl Is TextEdit Then
                                        tempControl.BackColor = SystemColors.Info
                                        DirectCast(tempControl, TextEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                        DirectCast(tempControl, TextEdit).Properties.ReadOnly = False
                                        DirectCast(tempControl, TextEdit).Properties.CharacterCasing = CharacterCasing.Upper
                                    ElseIf TypeOf tempControl Is DateEdit Then
                                        tempControl.BackColor = SystemColors.Info
                                        DirectCast(tempControl, DateEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                        DirectCast(tempControl, DateEdit).Properties.ReadOnly = False
                                    ElseIf TypeOf tempControl Is DevExpress.XtraEditors.ComboBoxEdit Then
                                        tempControl.BackColor = SystemColors.Info
                                        DirectCast(tempControl, DevExpress.XtraEditors.ComboBoxEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                        DirectCast(tempControl, DevExpress.XtraEditors.ComboBoxEdit).Properties.ReadOnly = False
                                    ElseIf TypeOf tempControl Is DevExpress.XtraEditors.LookUpEdit Then
                                        tempControl.BackColor = SystemColors.Info
                                        DirectCast(tempControl, DevExpress.XtraEditors.LookUpEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                        DirectCast(tempControl, DevExpress.XtraEditors.LookUpEdit).Properties.ReadOnly = False
                                    ElseIf TypeOf tempControl Is DevExpress.XtraEditors.ButtonEdit Then
                                        tempControl.BackColor = SystemColors.Info
                                        DirectCast(tempControl, DevExpress.XtraEditors.ButtonEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                        DirectCast(tempControl, DevExpress.XtraEditors.ButtonEdit).Properties.ReadOnly = False
                                    End If
                                Else
                                    boolReadOnly = ADataTable.Columns(sField).ReadOnly
                                    If TypeOf tempControl Is TextEdit Then
                                        DirectCast(tempControl, TextEdit).Properties.ReadOnly = boolReadOnly
                                    ElseIf TypeOf tempControl Is LookUpEdit Then
                                        DirectCast(tempControl, LookUpEdit).Properties.ReadOnly = boolReadOnly
                                    ElseIf TypeOf tempControl Is DateEdit Then
                                        DirectCast(tempControl, DateEdit).Properties.ReadOnly = boolReadOnly
                                    ElseIf TypeOf tempControl Is ComboBoxEdit Then
                                        DirectCast(tempControl, ComboBoxEdit).Properties.ReadOnly = boolReadOnly
                                    ElseIf TypeOf tempControl Is ButtonEdit Then
                                        DirectCast(tempControl, ButtonEdit).Properties.ReadOnly = boolReadOnly
                                    End If

                                    If Not ADataTable.Columns(sField).AllowDBNull Then
                                        If TypeOf tempControl Is TextEdit Then
                                            tempControl.BackColor = SystemColors.Info
                                            DirectCast(tempControl, TextEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                        ElseIf TypeOf tempControl Is LookUpEdit Then
                                            tempControl.BackColor = SystemColors.Info
                                            DirectCast(tempControl, LookUpEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                        ElseIf TypeOf tempControl Is DateEdit Then
                                            tempControl.BackColor = SystemColors.Info
                                            DirectCast(tempControl, DateEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                        ElseIf TypeOf tempControl Is ComboBoxEdit Then
                                            tempControl.BackColor = SystemColors.Info
                                            DirectCast(tempControl, ComboBoxEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                        ElseIf TypeOf tempControl Is ButtonEdit Then
                                            tempControl.BackColor = SystemColors.Info
                                            DirectCast(tempControl, ButtonEdit).Font = New Font(tempControl.Font, tempControl.Font.Style Or FontStyle.Bold)
                                        End If
                                    End If

                                End If
                            End If
                        End If
                    Next

                    If AFocusControl IsNot Nothing Then
                        AFocusControl.Focus()
                    End If
            End Select
        End Sub

    End Class
End Namespace

