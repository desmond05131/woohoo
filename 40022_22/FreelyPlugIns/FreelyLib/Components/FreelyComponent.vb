Imports System.ComponentModel
Imports AutoCount.Authentication

Namespace Freely.Controls
    Public Class FreelyGridControl
        Inherits DevExpress.XtraGrid.GridControl

        Private _AConn As AutoCount.Data.DBSetting
        Private _UserSession As AutoCount.Authentication.UserSession
        Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
        Private _FormName As String = String.Empty
        Public Property DBConn As AutoCount.Data.DBSetting
            Get
                Return _AConn
            End Get
            Set(ByVal value As AutoCount.Data.DBSetting)
                _AConn = value
            End Set
        End Property

        Public ReadOnly Property UserSession As AutoCount.Authentication.UserSession
            Get
                Return _UserSession
            End Get
            
        End Property
        Public Property FormName As String
            Get
                Return _FormName
            End Get
            Set(ByVal value As String)
                _FormName = value
            End Set
        End Property


        Public ReadOnly Property CreateBy As String
            Get
                Return "Lai Wei Loong 2013"
            End Get
        End Property
        Public Sub New(ByVal AFormName As String)
            Me._FormName = AFormName
        End Sub
        Public Sub New(ByVal AUserSession As AutoCount.Authentication.UserSession)
            Me._UserSession = AUserSession
        End Sub

        Private Sub FreelyGridControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If sender IsNot Nothing Then

                Try
                    If Me.MainView IsNot Nothing Then
                        Console.WriteLine("Main View Found!")

                        For Each View As DevExpress.XtraGrid.Views.Grid.GridView In Me.Views
                            Console.WriteLine(String.Format("View Name : {0}", View.Name))

                            View.OptionsView.EnableAppearanceOddRow = True
                            View.OptionsView.EnableAppearanceEvenRow = False

                            Console.WriteLine(String.Format("View Column Count : {0}", View.Columns.Count))
                            If _AConn IsNot Nothing Then
                                Dim AFreely As New Freely.Utli.FreelyUtli(_UserSession, Me.DBConn)
                                AFreely.AddLayoutManager(View, Me.FormName)
                            End If
                        Next
                    End If
                Catch ex As Exception
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
                End Try
            End If
        End Sub

        Private Sub InitializeComponent()
            Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'GridView1
            '
            Me.GridView1.GridControl = Me
            Me.GridView1.Name = "GridView1"
            '
            'FreelyGridControl
            '
            Me.MainView = Me.GridView1
            Me.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
    End Class

    Public Class FreelyUDFTreeList
        Inherits DevExpress.XtraTreeList.TreeList

        Dim AccessRightList As String() = {"CMDID", "ParentID", "Description"}

    End Class
    Public Class FreelyAccessRightTreeList
        Inherits DevExpress.XtraTreeList.TreeList

        Const ARootID As Integer = AutoCount.Authentication.AccessRightStringId.ROOT

        Dim AccessRightList As String() = {"CMDID", "ParentID", "Description"}
        Dim _IsAutoCountAccessRight As Boolean = False

        Public ReadOnly Property CreateBy As String
            Get
                Return "Lai Wei Loong 2013"
            End Get
        End Property
        Public Property IsAutoCountAccessRight As Boolean

            Get
                Return _IsAutoCountAccessRight
            End Get
            Set(ByVal value As Boolean)
                _IsAutoCountAccessRight = value
                If _IsAutoCountAccessRight Then
                    GenerateAutoCountAccessRightColumns()
                Else
                    Me.Columns.Clear()
                End If
            End Set
        End Property

        Public Sub GenerateAutoCountAccessRightColumns()
            Dim ATreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn

            Me.Columns.Clear()
            For Each s As String In AccessRightList

                ATreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn
                ATreeListColumn = Me.Columns.Add()

                ATreeListColumn.Caption = s
                ATreeListColumn.FieldName = s
                ATreeListColumn.Name = String.Format("TreeList{0}", s)
                ATreeListColumn.Visible = True
                ATreeListColumn.VisibleIndex = Me.Columns.Count - 1
            Next



        End Sub
        Public Function RegisterAutoCountAccessRight() As Boolean
            Try
                Dim ARecord As AccessRightRecord
                For iTree As Integer = 0 To Me.RowCount - 1
                    If Me.Nodes(iTree) IsNot Nothing Then

                        'CMDID", "ParentID", "Description"
                        Dim sCMDID As String = String.Empty
                        Dim sParentID As String = String.Empty
                        Dim sDescription As String = String.Empty
                        For Each s As String In AccessRightList
                            If Me.Nodes(iTree).GetValue(s) IsNot Nothing Then
                                Select Case s
                                    Case "CMDID" : sCMDID = Me.Nodes(iTree).GetValue(s)
                                    Case "ParentID" : sParentID = Me.Nodes(iTree).GetValue(s)
                                    Case "Description" : sDescription = Me.Nodes(iTree).GetValue(s)
                                End Select
                                ' Console.WriteLine("Columns : " & s & " " & Me.Nodes(iTree).GetValue(s))
                            End If
                        Next
                        ARecord = New AccessRightRecord(sCMDID, sParentID, sDescription)
                        AutoCount.Authentication.AccessRightMap.AddAccessRightRecord(ARecord)

                    End If


                Next
            Catch ex As Exception
                Throw ex
            End Try
            Return True
        End Function
    End Class

    Public Class FreelyLookUp
        Inherits DevExpress.XtraEditors.LookUpEdit
        Implements IDisposable

        Private _SQLTableName As String = String.Empty
        Private _AConn As AutoCount.Data.DBSetting = Nothing
        Private _OnClickRefresh As Boolean = False
        Private _FieldList As New List(Of FreelyFieldList)
        Private _DisplayValue As String = String.Empty
        Private _ValueMember As String = String.Empty
        Private _ToLeftLayout As Boolean = False
        <Description("Define System Table"), Category("Freely Component")>
        Public Property SQLTableName As String
            Get
                Return _SQLTableName
            End Get
            Set(ByVal value As String)
                _SQLTableName = value
            End Set
        End Property
        <Description("Define Display Value"), Category("Freely Component")>
        Public Property DisplayValue As String
            Get
                Return _DisplayValue
            End Get
            Set(ByVal value As String)
                _DisplayValue = value
            End Set
        End Property

        <Description("Define Value Member"), Category("Freely Component")>
        Public Property ValueMember As String
            Get
                Return _ValueMember
            End Get
            Set(ByVal value As String)
                _ValueMember = value
            End Set
        End Property

        <Description("Define AutoCount DBConnection"), Category("Freely DB Conection")>
        Public Property DBConn As AutoCount.Data.DBSetting
            Get
                Return _AConn
            End Get
            Set(ByVal value As AutoCount.Data.DBSetting)
                _AConn = value
            End Set
        End Property
        <Description("Define Fire On Click"), Category("Freely Component")>
        Public Property OnClickRefresh As Boolean
            Get
                Return _OnClickRefresh
            End Get
            Set(ByVal value As Boolean)
                _OnClickRefresh = value
                If value Then
                    AddHandler Me.QueryPopUp, AddressOf OnClickRefreshEvent
                Else
                    RemoveHandler Me.QueryPopUp, AddressOf OnClickRefreshEvent
                End If
            End Set
        End Property
        <Description("Define Select Field To Binding"), Category("Freely Component"),
        System.ComponentModel.Browsable(False),
        System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
        Public Property FieldList As List(Of FreelyFieldList)
            Get
                Return _FieldList
            End Get
            Set(ByVal value As List(Of FreelyFieldList))
                _FieldList = value
            End Set
        End Property
        Public Property ToLeftLayout As Boolean
            Get
                Return _ToLeftLayout
            End Get
            Set(ByVal value As Boolean)
                _ToLeftLayout = value
                If value Then
                    AddHandler Me.Popup, AddressOf OnPopUpLocation
                Else
                    RemoveHandler Me.Popup, AddressOf OnPopUpLocation
                End If
            End Set
        End Property

        Public Sub DataInquiery()
            Try
                Using sqlConn As New SqlClient.SqlConnection(Me._AConn.ConnectionString)
                    sqlConn.Open()
                    Dim sSQLCol As String = String.Empty


                    sSQLCol = String.Format("Select * From {0}", Me.SQLTableName)


                    Using sqlCmd As New SqlClient.SqlCommand(sSQLCol, sqlConn)
                        Using dtRecord As New DataTable(Me.SQLTableName)
                            dtRecord.Load(sqlCmd.ExecuteReader)

                            Dim bsRecord As New BindingSource
                            bsRecord.DataMember = SQLTableName
                            bsRecord.DataSource = dtRecord

                            MyBase.Properties.DataSource = bsRecord
                            MyBase.Properties.DisplayMember = Me.DisplayValue
                            MyBase.Properties.ValueMember = Me.ValueMember

                            If Me._FieldList.Count = 0 Then
                                MyBase.Properties.PopulateColumns()
                            Else


                                For Each sCol As Freely.Controls.FreelyFieldList In Me._FieldList
                                    Dim ACol As New DevExpress.XtraEditors.Controls.LookUpColumnInfo
                                    ACol.FieldName = sCol.ColumnName
                                    ACol.Caption = sCol.Caption
                                    MyBase.Properties.Columns.Add(ACol)
                                Next
                            End If

                        End Using
                    End Using
                End Using

            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
            End Try
        End Sub
        Private Sub OnPopUpLocation(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim f As DevExpress.XtraEditors.Popup.PopupLookUpEditForm = TryCast((TryCast(sender, DevExpress.Utils.Win.IPopupControl)).PopupWindow, DevExpress.XtraEditors.Popup.PopupLookUpEditForm)
            If f IsNot Nothing Then
                Dim iFormWidth As Integer = f.Width

                f.StartPosition = FormStartPosition.Manual
                Dim p As System.Drawing.Point = f.Location
                iFormWidth = iFormWidth - TryCast(sender, DevExpress.XtraEditors.LookUpEdit).Width
                p.X = p.X - iFormWidth
                f.Location = p
            End If
        End Sub


        Private Sub OnClickRefreshEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Try
                Using sqlConn As New SqlClient.SqlConnection(Me._AConn.ConnectionString)
                    sqlConn.Open()
                    Dim sSQLCol As String = String.Empty

                    sSQLCol = String.Format("Select * From {0}", Me.SQLTableName)

                    Using sqlCmd As New SqlClient.SqlCommand(sSQLCol, sqlConn)
                        Using dtRecord As New DataTable(Me.SQLTableName)
                            dtRecord.Load(sqlCmd.ExecuteReader)
                            Dim dtDataSource As DataTable = TryCast(MyBase.Properties.DataSource, BindingSource).DataSource
                            dtDataSource.Clear()
                            dtDataSource.Merge(dtRecord)

                        End Using
                    End Using
                End Using

            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
            End Try
        End Sub

    End Class

    Public Class FreelyFieldList
        Public Property ColumnName As String = String.Empty
        Public Property Caption As String = String.Empty
    End Class



End Namespace

