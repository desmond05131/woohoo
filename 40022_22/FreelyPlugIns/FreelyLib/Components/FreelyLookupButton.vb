Imports DevExpress.XtraEditors.Popup
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository
Imports System.ComponentModel

Namespace Freely.Controls

    Public Class FreelyButtonType
        Dim _ButtonName As String = String.Empty
        Dim _ButtonText As String = String.Empty
        Dim _Height As Integer = 16
        Dim _Width As Integer = 30
        Dim _FreelyButton As New DevExpress.XtraEditors.SimpleButton

        Public Property ButtonName As String
            Get
                Return _ButtonName
            End Get
            Set(value As String)
                _ButtonName = value
            End Set
        End Property

        Public Property ButtonText As String
            Get
                Return _ButtonText
            End Get
            Set(value As String)
                _ButtonText = value
            End Set
        End Property


        Public Property Width As Integer
            Get
                Return _Width
            End Get
            Set(value As Integer)
                _Width = value
            End Set
        End Property


        Public Property Height As Integer
            Get
                Return _Height
            End Get
            Set(value As Integer)
                _Height = value
            End Set
        End Property
        Public Property FreelyButton As DevExpress.XtraEditors.SimpleButton
            Get
                Return _FreelyButton
            End Get
            Set(value As DevExpress.XtraEditors.SimpleButton)
                _FreelyButton = value
            End Set
        End Property
    End Class


    '----Main Lookup Edit--------------
    Public Class FreelyLookupButton
        Inherits LookUpEdit
        Dim AForm As UserPopupLookUpEditForm
        Dim _ButtonList As New List(Of FreelyButtonType)

        Public Event OnPopUpButtomClick(ByVal Sender As Object, ByVal e As System.EventArgs)


        <Description("Freely Button"), Category("Freely"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(True)>
        Public Property ButtonList As List(Of FreelyButtonType)
            Get
                Return _ButtonList
            End Get
            Set(value As List(Of FreelyButtonType))
                _ButtonList = value
            End Set
        End Property
        Public Sub New()
            AForm = New UserPopupLookUpEditForm(Me)
            If AForm IsNot Nothing Then

                AddHandler AForm.OnPopUpButtomClick, AddressOf OnClickEvent
            End If

        End Sub

        Private Sub OnClickEvent(ByVal Sender As Object, ByVal e As System.EventArgs)
            RaiseEvent OnPopUpButtomClick(Sender, e)
        End Sub

        Protected Overrides Function CreatePopupForm() As DevExpress.XtraEditors.Popup.PopupBaseForm
            Return AForm
        End Function
    End Class
    '------End Main LookUp Edit-----------------------------------

    Public Class FreelyRepositoryLookupButton
        Inherits Repository.RepositoryItemLookUpEdit
        Dim AForm As UserPopupLookUpEditForm
        Dim _ButtonList As New List(Of FreelyButtonType)

        Public Event OnPopUpButtomClick(ByVal Sender As Object, ByVal e As System.EventArgs)


        <Description("Freely Button"), Category("Freely"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(True)>
        Public Property ButtonList As List(Of FreelyButtonType)
            Get
                Return _ButtonList
            End Get
            Set(value As List(Of FreelyButtonType))
                _ButtonList = value
            End Set
        End Property
        Public Sub New()


        End Sub
        Public Overrides Function CreateEditor() As DevExpress.XtraEditors.BaseEdit
            Dim AFreely As New FreelyLookupButton
            AFreely.ButtonList = _ButtonList

            AddHandler AFreely.OnPopUpButtomClick, AddressOf OnClickEvent
            Return AFreely ' MyBase.CreateEditor()
        End Function
        Private Sub OnClickEvent(ByVal Sender As Object, ByVal e As System.EventArgs)
            RaiseEvent OnPopUpButtomClick(Sender, e)
        End Sub

        Protected Overrides Sub OnOwnerEditChanged()

        End Sub

    End Class


    Public Class UserPopupLookUpEditForm
        Inherits PopupLookUpEditForm

        Dim ALookup As FreelyLookupButton
        Public Event OnPopUpButtomClick(ByVal Sender As Object, ByVal e As System.EventArgs)


        Private _Indent As Integer = 3
        Public Property Indent() As Integer
            Get
                Return _Indent
            End Get
            Set(ByVal value As Integer)
                _Indent = value
            End Set
        End Property


        Public Sub New(owner As FreelyLookupButton)


            MyBase.New(owner)
            ALookup = owner

        End Sub

        Protected Overrides Function CreateViewInfo() As DevExpress.XtraEditors.Popup.PopupBaseFormViewInfo
            Return New MyLookUpViewInfo(Me)
        End Function





        Public Overrides Sub ShowPopupForm()
            If Me.Controls.Count = 3 Then
                'to be sure that your controls are added one time
                If Me.ALookup.ButtonList.Count > 0 Then
                    Dim iCount As Integer = 0
                    For Each AFreelyButtonType As FreelyButtonType In Me.ALookup.ButtonList
                        Dim X As Integer = 0
                        Dim Y As Integer = 0
                        If iCount = 0 Then
                            X = Me.ViewInfo.CloseButtonRect.Location.X + Me.ViewInfo.CloseButtonRect.Width + Indent
                            Y = Me.ViewInfo.CloseButtonRect.Location.Y + Indent
                        Else
                            X = Me.ALookup.ButtonList(iCount - 1).FreelyButton.Location.X + Me.ALookup.ButtonList(iCount - 1).FreelyButton.Width + Indent
                            Y = Me.ALookup.ButtonList(iCount - 1).FreelyButton.Location.Y
                        End If
                        AFreelyButtonType.FreelyButton = New DevExpress.XtraEditors.SimpleButton
                        AFreelyButtonType.FreelyButton.Text = AFreelyButtonType.ButtonText
                        AFreelyButtonType.FreelyButton.Name = AFreelyButtonType.ButtonName

                        AFreelyButtonType.FreelyButton.Location = New Point(X, Y)
                        AFreelyButtonType.FreelyButton.Size = New Size(AFreelyButtonType.Width, AFreelyButtonType.Height)
                        AFreelyButtonType.FreelyButton.Anchor = AnchorStyles.Top + AnchorStyles.Left
                        AddHandler AFreelyButtonType.FreelyButton.Click, AddressOf OnClickEvent
                        Me.Controls.Add(AFreelyButtonType.FreelyButton)

                        iCount = iCount + 1
                    Next
                End If

            End If

            MyBase.ShowPopupForm()
        End Sub
        Private Sub OnClickEvent(ByVal Sender As Object, ByVal e As System.EventArgs)
            RaiseEvent OnPopUpButtomClick(Sender, e)
        End Sub
        Protected Overrides Sub UpdateControlPositionsCore()
            MyBase.UpdateControlPositionsCore()
            UpdateMyButton()
        End Sub



        Private Sub UpdateMyButton()
            'If NewButton IsNot Nothing Then
            '    NewButton.Location = New Point(Me.ViewInfo.CloseButtonRect.Location.X + Me.ViewInfo.CloseButtonRect.Width + 3, Me.ViewInfo.CloseButtonRect.Location.Y)
            'End If
            Dim iCount As Integer = 0
            For Each AFreelyButtonType As FreelyButtonType In Me.ALookup.ButtonList
                Dim X As Integer = 0
                Dim Y As Integer = 0
                If iCount = 0 Then
                    X = Me.ViewInfo.CloseButtonRect.Location.X + Me.ViewInfo.CloseButtonRect.Width + Indent
                    Y = Me.ViewInfo.CloseButtonRect.Location.Y + Indent
                Else
                    X = Me.ALookup.ButtonList(iCount - 1).FreelyButton.Location.X + Me.ALookup.ButtonList(iCount - 1).FreelyButton.Width + Indent
                    Y = Me.ALookup.ButtonList(iCount - 1).FreelyButton.Location.Y
                End If

                AFreelyButtonType.FreelyButton.Location = New Point(X, Y)

                iCount = iCount + 1
            Next

        End Sub
    End Class

    Public Class MyLookUpViewInfo
        Inherits DevExpress.XtraEditors.Popup.PopupLookUpEditFormViewInfo
        Public Sub New(form As DevExpress.XtraEditors.Popup.PopupLookUpEditForm)
            MyBase.New(form)
        End Sub
        Protected Overrides Sub CalcContentRect(bounds As Rectangle)
            '      bounds.Height -= 24
            MyBase.CalcContentRect(bounds)
        End Sub

        Public Overrides Sub CalcViewInfo(g As Graphics, bounds As Rectangle)
            MyBase.CalcViewInfo(g, bounds)

        End Sub

    End Class
End Namespace