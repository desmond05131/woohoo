Namespace Freely.Standard.MessageBox
    Public Class FreelyMessageBox
        Private Shared ReadOnly MessageBoxCaption As String = String.Format("Freely Creative Sdn. Bhd. - {0}", FreelyPlugIns.ProductName)
        Public Shared Sub ShowInfoMessage(ByVal AMessage As String)
            DevExpress.XtraEditors.XtraMessageBox.Show(AMessage, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
        Public Shared Sub ShowErrorMessage(ByVal AMessage As String)
            DevExpress.XtraEditors.XtraMessageBox.Show(AMessage, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub
        Public Shared Function ShowConfirmMessage(ByVal AMessage As String) As DialogResult
            Return DevExpress.XtraEditors.XtraMessageBox.Show(AMessage, MessageBoxCaption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        End Function
        Public Shared Function ShowYesNoCancelMEssage(ByVal AMessage As String) As DialogResult
            Return DevExpress.XtraEditors.XtraMessageBox.Show(AMessage, MessageBoxCaption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        End Function
    End Class
End Namespace