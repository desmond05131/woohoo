Imports System.ComponentModel
Imports System.Drawing.Design
Imports DevExpress.Utils.Editors

Namespace Freely.Controls


    Public MustInherit Class FreelyBaseControl
        Inherits DevExpress.XtraEditors.XtraUserControl

        Dim _EditValue As Object = String.Empty
        Dim _IsModifed As Boolean = False

        Public ReadOnly Property CreatedBy
            Get
                Return "Lai Wei Loong 2014"
            End Get
        End Property

        <Browsable(False)> _
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property BindingManager() As BindingManagerBase
            Get
                If MyBase.DataBindings("EditValue") Is Nothing Then
                    Return Nothing
                End If
                Return MyBase.DataBindings("EditValue").BindingManagerBase
            End Get
        End Property

        <Bindable(True)> _
        <Category("Data")> _
        <Description("Gets or sets the editor's value.")> _
        <Editor("DevExpress.Utils.Editors.UIObjectEditor, DevExpress.Utils3", GetType(UITypeEditor))> _
        <Localizable(True)> _
        <RefreshProperties(RefreshProperties.All)> _
        <TypeConverter(GetType(ObjectEditorTypeConverter))> _
        Public Overridable Property EditValue() As Object
            Get
                Return _EditValue
            End Get
            Set(value As Object)

                Dim sValue As String = IIf(value Is Nothing, "", value).ToString

                If Me.CompareEditValue(Me._EditValue, value) Then
                    Me._EditValue = value
                    Me.OnEditValueChanged(EventArgs.Empty)
                End If
            End Set
        End Property

        Protected Overridable Sub OnEditValueChanged(e As EventArgs)
            Me._IsModifed = True
            RaiseEvent EditValueChanged(Me, e)
        End Sub

        Protected Overridable Function CompareEditValue(ByVal val1 As Object, ByVal val2 As Object) As Boolean
            If val1 IsNot Nothing AndAlso val2 IsNot Nothing AndAlso val1.Equals(val2) Then
                Return True
            End If
            If val1 Is val2 Then
                Return True
            End If
            Return False
        End Function

        <Category("Property Changed")> _
       <Description("Fires after the edit value has been changed.")> _
        Public Event EditValueChanged As EventHandler


    End Class
End Namespace