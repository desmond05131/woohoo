Public MustInherit Class frmSeachDialogBase
    Dim _SeachKeyWord As String = ""
    Dim _TitleName As String = ""
    Dim _DBSetting As AutoCount.Data.DBSetting

    Public ReadOnly Property DBSetting As AutoCount.Data.DBSetting
        Get
            Return _DBSetting
        End Get
    End Property

    Public Property PrimaryKeyField As String
    Public Property SelectedRecord As New List(Of Object)

    Public Property TableName As String
    Public Property TitleName As String
        Get
            Return _TitleName
        End Get
        Set(value As String)
            Me.PanelHeader1.Header = value
            Me.Text = value

            _TitleName = value
        End Set
    End Property
    Public Property SeachKeyWord As String
        Get
            _SeachKeyWord = txtKeyword.Text
            Return _SeachKeyWord
        End Get
        Set(value As String)

            txtKeyword.Text = value
            _SeachKeyWord = value
        End Set
    End Property
    Public ReadOnly Property RepoCheckBox As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Get
            Return Me.chkIsSelect
        End Get
    End Property
    Public ReadOnly Property GridView As DevExpress.XtraGrid.Views.Grid.GridView
        Get
            Return Me.gvData
        End Get
    End Property

    Public ReadOnly Property SeachCreterialGroupBox As DevExpress.XtraEditors.GroupControl
        Get
            Return Me.gcSeach
        End Get
    End Property

    Public Sub New(ByVal ADBSetting As AutoCount.Data.DBSetting)
        _DBSetting = ADBSetting
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected MustOverride Sub OnPopulateGridColumn()
    Protected MustOverride Sub CloseEvent(ByVal Sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click

    Protected MustOverride Sub SearchEvent(ByVal Sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click

    Protected MustOverride Sub ApplyEvent(ByVal Sender As Object, ByVal e As System.EventArgs) Handles btnApply.Click

    Protected MustOverride Sub FormLoadEvent(ByVal Sender As Object, ByVal e As System.EventArgs) Handles Me.Load


End Class