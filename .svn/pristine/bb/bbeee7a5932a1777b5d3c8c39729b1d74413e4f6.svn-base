Imports DevExpress.XtraLayout
Imports DevExpress.XtraEditors

Namespace Freely.Controls



    Public Class FreelyButtonPanel
        Public Event OnAddClick(ByVal Sender As Object)
        Public Event OnButtonClick(ByVal Sender As Object)

        Public Property RibbonImage As DevExpress.Utils.ImageCollection
        Public Property BunddleDocument As Object

        Public Property BunddleForm As Object
        Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
            RaiseEvent OnAddClick(sender)
            RaiseEvent OnButtonClick(sender)

            Try
                If BunddleForm IsNot Nothing Then
                    If TryCast(BunddleForm, DevExpress.XtraBars.Ribbon.RibbonForm).Ribbon.Items("barBtnAddDTL") IsNot Nothing Then
                        TryCast(TryCast(BunddleForm, DevExpress.XtraBars.Ribbon.RibbonForm).Ribbon.Items("barBtnAddDTL"), DevExpress.XtraBars.BarButtonItem).PerformClick()
                    End If
                End If
            Catch ex As Exception

            End Try

        End Sub

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            'Me.btnAdd.Image = 
            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Private Sub FreelyButtonPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If Me.RibbonImage IsNot Nothing Then
                Me.btnAdd.ImageOptions.ImageList = RibbonImage
                Me.btnAdd.ImageOptions.ImageIndex = 0

                Me.btnInsertBefore.ImageOptions.ImageList = RibbonImage
                Me.btnInsertBefore.ImageOptions.ImageIndex = 1

                Me.btnDelete.ImageOptions.ImageList = RibbonImage
                Me.btnDelete.ImageOptions.ImageIndex = 2

                Me.btnUp.ImageOptions.ImageList = RibbonImage
                Me.btnUp.ImageOptions.ImageIndex = 3

                Me.btnDown.ImageOptions.ImageList = RibbonImage
                Me.btnDown.ImageOptions.ImageIndex = 4

                Me.btnUndo.ImageOptions.ImageList = RibbonImage
                Me.btnUndo.ImageOptions.ImageIndex = 5

                Me.btnSelectAll.ImageOptions.ImageList = RibbonImage
                Me.btnSelectAll.ImageOptions.ImageIndex = 6

                Me.btnRangeSet.ImageOptions.ImageList = RibbonImage
                Me.btnRangeSet.ImageOptions.ImageIndex = 7

            End If
        End Sub

        Private Sub btnInsertBefore_Click(sender As Object, e As EventArgs) Handles btnInsertBefore.Click
            If TryCast(BunddleForm, DevExpress.XtraBars.Ribbon.RibbonForm).Ribbon.Items("barBtnInsertBefore") IsNot Nothing Then
                TryCast(TryCast(BunddleForm, DevExpress.XtraBars.Ribbon.RibbonForm).Ribbon.Items("barBtnInsertBefore"), DevExpress.XtraBars.BarButtonItem).PerformClick()
            End If
        End Sub


        Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
            If TryCast(BunddleForm, DevExpress.XtraBars.Ribbon.RibbonForm).Ribbon.Items("barBtnDeleteDTL") IsNot Nothing Then
                TryCast(TryCast(BunddleForm, DevExpress.XtraBars.Ribbon.RibbonForm).Ribbon.Items("barBtnDeleteDTL"), DevExpress.XtraBars.BarButtonItem).PerformClick()
            End If
        End Sub

        Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
            If TryCast(BunddleForm, DevExpress.XtraBars.Ribbon.RibbonForm).Ribbon.Items("barBtnUp") IsNot Nothing Then
                TryCast(TryCast(BunddleForm, DevExpress.XtraBars.Ribbon.RibbonForm).Ribbon.Items("barBtnUp"), DevExpress.XtraBars.BarButtonItem).PerformClick()
            End If
        End Sub

        Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
            If TryCast(BunddleForm, DevExpress.XtraBars.Ribbon.RibbonForm).Ribbon.Items("barBtnDown") IsNot Nothing Then
                TryCast(TryCast(BunddleForm, DevExpress.XtraBars.Ribbon.RibbonForm).Ribbon.Items("barBtnDown"), DevExpress.XtraBars.BarButtonItem).PerformClick()
            End If
        End Sub

        Private Sub btnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click
            If TryCast(BunddleForm, DevExpress.XtraBars.Ribbon.RibbonForm).Ribbon.Items("barBtnUndo") IsNot Nothing Then
                TryCast(TryCast(BunddleForm, DevExpress.XtraBars.Ribbon.RibbonForm).Ribbon.Items("barBtnUndo"), DevExpress.XtraBars.BarButtonItem).PerformClick()
            End If
        End Sub

        Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
            If TryCast(BunddleForm, DevExpress.XtraBars.Ribbon.RibbonForm).Ribbon.Items("barBtnSelectAll") IsNot Nothing Then
                TryCast(TryCast(BunddleForm, DevExpress.XtraBars.Ribbon.RibbonForm).Ribbon.Items("barBtnSelectAll"), DevExpress.XtraBars.BarButtonItem).PerformClick()
            End If
        End Sub

        Private Sub btnRangeSet_Click(sender As Object, e As EventArgs) Handles btnRangeSet.Click
            If TryCast(BunddleForm, DevExpress.XtraBars.Ribbon.RibbonForm).Ribbon.Items("barBtnRangeSet") IsNot Nothing Then
                TryCast(TryCast(BunddleForm, DevExpress.XtraBars.Ribbon.RibbonForm).Ribbon.Items("barBtnRangeSet"), DevExpress.XtraBars.BarButtonItem).PerformClick()
            End If
        End Sub
    End Class
End Namespace