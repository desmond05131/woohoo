Namespace Freely.FormUI


    Public NotInheritable Class FreelySeachForm
        Private _Field As List(Of String)
        Private _Caption As String = String.Empty
        Private _AConn As AutoCount.Data.DBSetting = Nothing
        Private _AUserSession As AutoCount.Authentication.UserSession

        Private _MultiSelect As Boolean = False
        Public Property sSQL As String = String.Empty
        Public Property ReturnField As String = String.Empty
        Public Property _UserSession As AutoCount.Authentication.UserSession
            Get
                Return _AUserSession
            End Get

            Set(value As AutoCount.Authentication.UserSession)
                _AUserSession = value
            End Set
        End Property
        Public Property DBSetting As AutoCount.Data.DBSetting
            Get
                Return _AConn
            End Get
            Set(ByVal value As AutoCount.Data.DBSetting)
                _AConn = value
            End Set
        End Property

        Public Property MultiSelect As Boolean
            Get
                Return _MultiSelect
            End Get
            Set(ByVal value As Boolean)
                _MultiSelect = value
            End Set
        End Property


        Public Property Caption As String
            Get
                Return _Caption
            End Get
            Set(ByVal value As String)
                _Caption = value
                Me.Text = _Caption
            End Set
        End Property
        Public Property FieldValue As List(Of String)
            Get
                Return _Field
            End Get
            Set(ByVal value As List(Of String))
                _Field = value
            End Set
        End Property


        Private Sub frmSeachForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim sConn As String = String.Empty
            Dim Aulti As Utli.FreelyUtli
            If _AUserSession Is Nothing Then
                _AUserSession = AutoCount.Authentication.UserSession.CurrentUserSession
            End If
            If _AConn IsNot Nothing Then
                sConn = _AConn.ConnectionString
                Aulti = New Utli.FreelyUtli(_AUserSession, _AConn)
            Else
                sConn = AutoCount.Authentication.UserSession.CurrentUserSession.DBSetting.ConnectionString

                Aulti = New Utli.FreelyUtli(_AUserSession, AutoCount.Authentication.UserSession.CurrentUserSession.DBSetting)
            End If

            lblSelectAll.Visible = MultiSelect
            lblUnCheckAll.Visible = MultiSelect

            Aulti.AddLayoutManager(Me.gvFilter, Me.Name)

            Using sqlConn As New SqlClient.SqlConnection(sConn)
                sqlConn.Open()
                Using sqlCmd As New SqlClient.SqlCommand(sSQL, sqlConn)
                    Using dt As New DataTable
                        dt.Load(sqlCmd.ExecuteReader)
                        Me.dtFilterMaster.Merge(dt)
                        Me.gvFilter.PopulateColumns(dtFilterMaster)

                        For Each dcCol As DevExpress.XtraGrid.Columns.GridColumn In gvFilter.Columns
                            dcCol.OptionsColumn.AllowEdit = False
                        Next
                        Me.gvFilter.Columns("IsSelect").ColumnEdit = Me.chkSelect
                        Me.gvFilter.Columns("IsSelect").OptionsColumn.AllowEdit = True
                        Me.gvFilter.Columns("IsSelect").Caption = String.Empty

                        If Me._Field IsNot Nothing Then
                            For Each s As String In Me._Field
                                Dim drLength As DataRow() = dtFilterMaster.Select(String.Format("{0}='{1}'", Me.ReturnField, s.Replace("'", "''")))
                                For Each dr As DataRow In drLength
                                    dr.Item("IsSelect") = "Y"
                                Next
                            Next
                        End If

                        If Not _MultiSelect Then
                            Me.gvFilter.Columns("IsSelect").Visible = False
                        End If
                    End Using
                End Using

            End Using
        End Sub

        Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Sub

        Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
            Try
                _Field = New List(Of String)
                If _MultiSelect Then
                    For Each drRow As DataRow In Me.dtFilterMaster.Rows
                        If drRow.Item("IsSelect") = "Y" Then
                            _Field.Add(IIf(drRow.Item(ReturnField) Is DBNull.Value, String.Empty, drRow.Item(ReturnField)))
                        End If

                    Next
                Else
                    If gvFilter.FocusedRowHandle > -1 Then
                        _Field.Add(IIf(gvFilter.GetDataRow(gvFilter.FocusedRowHandle).Item(ReturnField) Is DBNull.Value, String.Empty, gvFilter.GetDataRow(gvFilter.FocusedRowHandle).Item(ReturnField)))
                    End If
                End If


                Me.DialogResult = Windows.Forms.DialogResult.OK
            Catch ex As Exception

            End Try
        End Sub

        Private Sub lblSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSelectAll.Click, lblUnCheckAll.Click
            Dim bSelectAll As Boolean = TryCast(sender, DevExpress.XtraEditors.LabelControl).Name = "lblSelectAll"
            For iCount As Integer = 0 To gvFilter.DataRowCount - 1
                gvFilter.GetDataRow(iCount).Item("IsSelect") = IIf(bSelectAll, "Y", "N")
            Next

        End Sub
    End Class
    Namespace FreelyFilterClass
        Public Class FilterMasterClass
            Public Property AFilterClass As New FilterClass
            Public Property ListofResult As New List(Of String)
        End Class
        Public Class FilterClass
            Public Property FieldName As String
            Public Property UDFFieldName As String
            Public Property Caption As String
        End Class
    End Namespace
End Namespace