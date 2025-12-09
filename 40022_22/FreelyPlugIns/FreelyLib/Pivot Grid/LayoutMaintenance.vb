Namespace Freely.Utli.PivotGrid
    Public Class PivotLayoutMaintenance
        Dim _APivotGrid As DevExpress.XtraPivotGrid.PivotGridControl
        Dim _DBConn As AutoCount.Data.DBSetting
        Dim _FormName As String = ""
        Const _ExportToExcel As String = "Export to Excel"
        Const _SaveLayout As String = "Save Layout"
        Const _LoadLayout As String = "Load Layout"

        Public ReadOnly Property DBSetting As AutoCount.Data.DBSetting
            Get
                Return _DBConn
            End Get
        End Property
        Public ReadOnly Property PivotGrid As DevExpress.XtraPivotGrid.PivotGridControl
            Get
                Return _APivotGrid
            End Get
        End Property

        Public ReadOnly Property FormName As String
            Get
                Return _FormName
            End Get
        End Property
        Public Sub New(ByVal ADBConn As AutoCount.Data.DBSetting, ByVal AFormName As String, ByVal APivot As DevExpress.XtraPivotGrid.PivotGridControl)
            _DBConn = ADBConn
            _APivotGrid = APivot
            _FormName = AFormName
            Init()

        End Sub

        Private Sub Init()
            AddHandler Me.PivotGrid.PopupMenuShowing, AddressOf OnPopupmenuShowing

        End Sub

        Private Sub OnPopupmenuShowing(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PopupMenuShowingEventArgs)

            Dim AMenu As DevExpress.Utils.Menu.DXPopupMenu = e.Menu
            If AMenu IsNot Nothing Then
                Dim MenuExportToXLS As New DevExpress.Utils.Menu.DXMenuItem(_ExportToExcel, AddressOf onExportToExcel)
                AMenu.Items.Add(MenuExportToXLS)

                Dim MenuSaveLayout As New DevExpress.Utils.Menu.DXMenuItem(_SaveLayout, AddressOf OnSaveLayout)
                AMenu.Items.Add(MenuSaveLayout)

                Dim MenuLoadLayout As New DevExpress.Utils.Menu.DXMenuItem(_LoadLayout, AddressOf OnLoadLayout)
                AMenu.Items.Add(MenuLoadLayout)

            End If


        End Sub
        Private Sub OnLoadLayout(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim dtLayout As DataTable = Me.LoadLayoutList(Me.FormName, Me.PivotGrid.Name)
            Try
                Using ASaveDialog As New DialogLoadLayout(dtLayout)
                    If ASaveDialog.ShowDialog = DialogResult.OK Then
                        If ASaveDialog.TitleName.Length > 0 Then
                            Dim sLayout As String = LoadLayout(ASaveDialog.TitleName)
                            If sLayout.Length > 0 Then
                                RestoreLayoutFromString(sLayout)
                            End If
                        End If
                    End If
                End Using
            Catch ex As Exception
            End Try

        End Sub

        Private Function LoadLayout(ByVal title As String) As String
            Dim str As String = DBSetting.ExecuteScalar("SELECT Template FROM Layout WHERE Title=?", title)
            Return str
        End Function

        Private Sub RestoreLayoutFromString(ByVal template As String)
            Try
                Using memoryStream As New IO.MemoryStream((New System.Text.UTF8Encoding()).GetBytes(template))
                    Me.PivotGrid.RestoreLayoutFromStream(memoryStream)
                End Using
            Catch ex As Exception

            End Try
        End Sub


        Private Sub OnSaveLayout(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim dtLayout As DataTable = Me.LoadLayoutList(Me.FormName, Me.PivotGrid.Name)
            Try
                Using ASaveDialog As New DialogSaveLayout(dtLayout)
                    If ASaveDialog.ShowDialog = DialogResult.OK Then
                        Dim uTF8Encoding As New System.Text.UTF8Encoding
                        Using memoryStream As New IO.MemoryStream()
                            Me.PivotGrid.SaveLayoutToStream(memoryStream, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                            Dim numArray(memoryStream.Length - 1) As Byte

                            memoryStream.Position = 0
                            memoryStream.Read(numArray, 0, numArray.Length)
                            memoryStream.Close()
                            Dim str As String = uTF8Encoding.GetString(numArray)
                            SaveLayout(Me.FormName, Me.PivotGrid.Name, str, ASaveDialog.TitleName, True)
                        End Using
                    End If
                End Using
            Catch ex As Exception

            End Try

        End Sub


        Private Sub SaveLayout(ByVal formName As String, ByVal componentName As String, ByVal xmlData As String, ByVal title As String, ByVal saveAsDefault As Boolean)
            Try
                Using sqlConn As New SqlClient.SqlConnection(DBSetting.ConnectionString)
                    sqlConn.Open()
                    Using adpLayout As New SqlClient.SqlDataAdapter("SELECT * FROM Layout", sqlConn)
                        Dim aBuilder As New SqlClient.SqlCommandBuilder(adpLayout)
                        aBuilder.ConflictOption = ConflictOption.OverwriteChanges

                        adpLayout.UpdateCommand = aBuilder.GetUpdateCommand
                        adpLayout.InsertCommand = aBuilder.GetInsertCommand
                        adpLayout.DeleteCommand = aBuilder.GetDeleteCommand


                        If (saveAsDefault) Then
                            DBSetting.ExecuteNonQuery("UPDATE Layout SET IsDefault='F' WHERE FormName=? AND ComponentName=?", formName, componentName)
                        End If
                        Dim dtRecord As DataTable = DBSetting.GetDataTable("SELECT * FROM Layout WHERE Title=?", False, title)

                        Dim drLayout As DataRow
                        If dtRecord.Rows.Count = 0 Then
                            drLayout = dtRecord.NewRow
                            drLayout.Item("Title") = title
                            dtRecord.Rows.Add(drLayout)
                        Else
                            drLayout = dtRecord.Rows(0)
                        End If
                        drLayout("FormName") = formName
                        drLayout("ComponentName") = componentName
                        drLayout("Template") = xmlData
                        drLayout("IsDefault") = AutoCount.Converter.BooleanToText(saveAsDefault)
                        drLayout("LastUpdate") = 0

                        drLayout.EndEdit()
                        adpLayout.Update(dtRecord)



                    End Using
                End Using
            Catch ex As Exception

            End Try
        End Sub
        Private Function LoadLayoutList(ByVal AFormName As String, ByVal APivotName As String) As DataTable
            Dim dtRecord As New DataTable
            Me.DBSetting.LoadDataTable(dtRecord, "SELECT Title, IsDefault FROM Layout WHERE FormName=? AND ComponentName=? ORDER BY Title", False, AFormName, APivotName)
            Return dtRecord
        End Function
        Private Sub onExportToExcel(ByVal sender As Object, ByVal e As System.EventArgs)
            Using saveDialog As New SaveFileDialog
                saveDialog.InitialDirectory = "C:\"
                saveDialog.Filter = String.Format("{0} (*.xlsx)|*.xlsx", "Microsoft Excel files")
                saveDialog.FilterIndex = 0
                saveDialog.RestoreDirectory = True
                If saveDialog.ShowDialog = DialogResult.OK Then
                    Try
                        Cursor.Current = Cursor.Current
                        Cursor.Current = Cursors.WaitCursor
                        Dim AOption As New DevExpress.XtraPrinting.XlsxExportOptions
                        AOption.ExportMode = DevExpress.XtraPrinting.XlsxExportMode.SingleFile
                        AOption.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Value
                        AOption.ExportHyperlinks = True
                        AOption.ShowGridLines = True
                        Me.PivotGrid.ExportToXlsx(saveDialog.FileName, AOption)

                        If DevExpress.XtraEditors.XtraMessageBox.Show("Do You Want To Open Excel File?", "Freely", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                            Process.Start(saveDialog.FileName)
                        End If
                    Catch ex As Exception
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
                    Finally
                        Cursor.Current = Cursors.Default
                    End Try
                End If

            End Using


        End Sub
    End Class


End Namespace

