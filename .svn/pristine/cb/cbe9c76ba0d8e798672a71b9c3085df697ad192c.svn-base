Namespace Freely.Utli.PivotGrid


    Public Class DialogSaveLayout
        Public Property TitleName As String

        Public Sub New(ByVal ADataTable As DataTable)

            InitializeComponent()

            Me.dtSave.Merge(ADataTable)
        End Sub
        Private Sub gvSaveLayout_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvSaveLayout.FocusedRowChanged
            If gvSaveLayout.FocusedRowHandle > -1 Then
                Dim sTitle As String = Me.gvSaveLayout.GetDataRow(gvSaveLayout.FocusedRowHandle).Item("Title").ToString()
                Me.txtTitle.Text = sTitle
            End If
        End Sub

        Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
            If Me.txtTitle.Text.Length = 0 Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Please provide a layout name.", "Freely", MessageBoxButtons.OK)
                Return
            End If
            For Each drTitle As DataRow In Me.dtSave.Rows
                Dim sTitle As String = drTitle.Item("Title").ToString
                If sTitle.ToUpper = txtTitle.Text.ToUpper Then
                    If DevExpress.XtraEditors.XtraMessageBox.Show("Layout name already exists, do you want to overwrite?", "Freely", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then

                    End If
                End If
            Next
            TitleName = txtTitle.Text
            Me.DialogResult = DialogResult.OK
        End Sub
    End Class
End Namespace