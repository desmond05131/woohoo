Namespace Freely.Utli.PivotGrid
    Public Class DialogLoadLayout

        Public Property TitleName As String = ""
        Public Sub New(ByVal ADataTable As DataTable)

            ' This call is required by the designer.
            InitializeComponent()

            Me.dtSave.Merge(ADataTable)

            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Private Sub gvLoadLayout_DoubleClick(sender As Object, e As EventArgs) Handles gvLoadLayout.DoubleClick
            If gvLoadLayout.FocusedRowHandle > -1 Then
                TitleName = gvLoadLayout.GetDataRow(gvLoadLayout.FocusedRowHandle).Item("Title").ToString
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If

        End Sub
    End Class
End Namespace