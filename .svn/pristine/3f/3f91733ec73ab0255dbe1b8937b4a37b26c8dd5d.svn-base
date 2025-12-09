Namespace Freely.Controls
    Public Class FreelyEmailComponent
        Public Const Prefix As String = "ING_"
        Public Const ING_EOutgoing As String = Prefix + "EOutgoing"
        Public Const ING_EPort As String = Prefix + "EPort"
        Public Const ING_EUseSSL As String = Prefix + "EUseSSL"
        Public Const ING_EUsePass As String = Prefix + "EUsePass"
        Public Const ING_ETimeOut As String = Prefix + "ETimeOut"
        Public Const ING_EUserName As String = Prefix + "EUserName"
        Public Const ING_EPasswrd As String = Prefix + "EPasswrd"


        Dim _UseDefaultDBSetting As Boolean = False
        Dim _UseDefaultDataBinding As Boolean = False

        Dim _EmailSetting As EmailProperty
        Private _AConn As AutoCount.Data.DBSetting = Nothing

        Dim dsEmail As DataSet
        Dim adpEmail As SqlClient.SqlDataAdapter
        Dim bsEmail As BindingSource
        Dim _BundleTableProperty As New BundleTableProperty
        Public Event OnSaveEmail(ByVal e As SaveEmailArgs)
        Public Event OnTestSentEmail(ByVal e As SaveEmailArgs)
        Public Event OnSendingEmail(ByVal e As OnSendingEmailArgs)


        Public Property BundleTableProperty As BundleTableProperty
            Get
                Return _BundleTableProperty
            End Get
            Set(ByVal value As BundleTableProperty)
                _BundleTableProperty = value
            End Set
        End Property


        Public ReadOnly Property EmailSetting As EmailProperty
            Get
                Return _EmailSetting
            End Get
        End Property
        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(ByVal DBConn As AutoCount.Data.DBSetting)
            InitializeComponent()
            Me.DBConn = DBConn
        End Sub

        Public Property DBConn As AutoCount.Data.DBSetting
            Get
                Return _AConn
            End Get
            Set(ByVal value As AutoCount.Data.DBSetting)
                _AConn = value
            End Set
        End Property

        Public ReadOnly Property CreateBy As String
            Get
                Return "Lai Wei Loong 2013"
            End Get
        End Property

        Public Property UseDefaultDBSetting As Boolean
            Get
                Return _UseDefaultDBSetting
            End Get
            Set(ByVal value As Boolean)
                _UseDefaultDBSetting = value
                If value Then
                    GenerateEmailQuery()
                End If
            End Set
        End Property

        Public Property UseDefaultDataBinding As Boolean
            Get
                Return _UseDefaultDataBinding
            End Get
            Set(ByVal value As Boolean)
                _UseDefaultDataBinding = value
                If value Then
                    GenerateDataBinding()
                End If
            End Set
        End Property

        Public Overridable Sub GenerateDataBinding()
            If _AConn Is Nothing Then Return
            Dim sqlConn As New SqlClient.SqlConnection(Me.DBConn.ConnectionString)
            sqlConn.Open()

            adpEmail = New SqlClient.SqlDataAdapter(String.Format("Select * From {0} Where 1=1 AND {1}", BundleTableProperty.BundleToTable, BundleTableProperty.FilterString), sqlConn)
            Dim AComm As New SqlClient.SqlCommandBuilder(adpEmail)
            Me.dsEmail = New DataSet
            adpEmail.UpdateCommand = AComm.GetUpdateCommand
            adpEmail.InsertCommand = AComm.GetInsertCommand
            adpEmail.DeleteCommand = AComm.GetDeleteCommand

            adpEmail.Fill(Me.dsEmail)
            bsEmail = New BindingSource

            bsEmail.DataSource = Me.dsEmail
            bsEmail.DataMember = Me.dsEmail.Tables(0).TableName

            If Me.dsEmail.Tables(0).Rows.Count = 0 Then
                bsEmail.AddNew()
            End If

            Dim dvView As DataRowView = Me.bsEmail.Current
            _EmailSetting = New EmailProperty(dvView.Row)
            ClearDataBinding()
            AddDataBinding()
        End Sub
        Public Sub Initialize(ByVal AConn As AutoCount.Data.DBSetting, ByVal AUseDefaultDataBinding As Boolean, ByVal AUseDefaultDBSettings As Boolean)
            Me.DBConn = AConn
            If AUseDefaultDataBinding Then
                GenerateEmailQuery()
            End If
            Me.UseDefaultDataBinding = AUseDefaultDataBinding
            Me.UseDefaultDBSetting = AUseDefaultDBSettings
            Me.GenerateDataBinding()
        End Sub
        Public Function SendEmail(ByVal ASetting As AutoCount.Settings.MailServerSetting,
                                    ByVal AReceiver As String, ByVal ASubject As String,
                                    ByVal ABody As String, ByVal AAttachmentList As List(Of String),
                                    ByVal AEnableSSL As Boolean, ByVal ADisplayName As String,
                                    Optional ByVal APirotory As System.Net.Mail.MailPriority = Net.Mail.MailPriority.High) As Boolean
            Me.bsEmail.EndEdit()

            Dim dvView As DataRowView = Me.bsEmail.Current
            _EmailSetting = New EmailProperty(dvView.Row)
            _EmailSetting.UserName = _EmailSetting.UserName

            Dim AEmailSetting As New OnSendingEmailArgs(Me.dsEmail, _EmailSetting)
            AEmailSetting.Message = "Start Sending...."
            RaiseEvent OnSendingEmail(AEmailSetting)

            Dim Server As New System.Net.Mail.SmtpClient
            Try
                Dim MyMail As Net.Mail.MailMessage = New Net.Mail.MailMessage

                If ASetting.HostName.ToString.Length > 0 _
                    And ASetting.Port.ToString.Length > 0 Then
                    MyMail.IsBodyHtml = True

                    If ASubject.Length > 0 Then
                        MyMail.Subject = ASubject
                    End If

                    If ABody.Length > 0 Then
                        MyMail.Body = ABody
                    End If

                    Server.Host = ASetting.HostName
                    Server.Port = ASetting.Port
                    Server.EnableSsl = AEnableSSL ' ASetting.EnableSsl
                    Server.Timeout = ASetting.ConnectionTimeout * 1000

                    If ASetting.UserName.ToString.Length > 0 _
                    And ASetting.Password.ToString.Length > 0 Then
                        Server.Credentials = New Net.NetworkCredential(ASetting.UserName, ASetting.Password)
                    Else
                        AEmailSetting.Message = "Email Does Not Setup Properly"
                        RaiseEvent OnSendingEmail(AEmailSetting)
                        Throw New Exception("Email Does Not Setup Properly")
                        Return False
                    End If
                End If
                Dim MailFrom As New Net.Mail.MailAddress(ASetting.UserName, ADisplayName)
                MyMail.From = MailFrom



                Dim ArrayName() = AReceiver.Split(";")
                Dim EmailTO As String = String.Empty
                Dim MailTo As Net.Mail.MailAddress
                For iName As Integer = 0 To ArrayName.Length - 1
                    MailTo = New Net.Mail.MailAddress(ArrayName(iName))
                    MyMail.To.Add(MailTo)
                Next

                If AAttachmentList IsNot Nothing Then
                    For Each AAttachment As String In AAttachmentList
                        If System.IO.File.Exists(AAttachment) Then
                            MyMail.Attachments.Add(New Net.Mail.Attachment(AAttachment))
                        ElseIf AAttachment.Length > 0 Then
                            MyMail.Body = "Sorry, Can't Found the Attachment File. Please Contact your System Administrator!"
                        End If
                    Next
                End If


                MyMail.Priority = APirotory

                Try
                    Net.ServicePointManager.CheckCertificateRevocationList = False
                    Net.ServicePointManager.ServerCertificateValidationCallback = Function(obj, certificate, chain, errors) True

                    Server.Send(MyMail)
                    MyMail.Attachments.Dispose()

                    Return True
                Catch ex As Exception
                    AEmailSetting.Message = "Exception: " + ex.Message
                    RaiseEvent OnSendingEmail(AEmailSetting)
                    Throw New Exception("Exception: " + ex.Message)
                    Return False
                End Try
            Catch ex As Exception
                Throw New Exception("Exception: " + ex.Message)
                AEmailSetting.Message = "Exception: " + ex.Message
                RaiseEvent OnSendingEmail(AEmailSetting)
                Return False
            End Try

            Return True
        End Function
        Public Sub RebuildTable()
            GenerateEmailQuery()
            GenerateDataBinding()
        End Sub
        Private Sub AddDataBinding()

            Me.txtEmailOutgoing.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", bsEmail, ING_EOutgoing, True))
            Me.txtPort.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", bsEmail, ING_EPort, True))
            Me.chkPassword.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", bsEmail, ING_EUsePass, True))
            Me.chkUseSSL.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", bsEmail, ING_EUseSSL, True))
            Me.txtUserName.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", bsEmail, ING_EUserName, True))
            Me.txtPassword.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", bsEmail, ING_EPasswrd, True))

        End Sub
        Private Sub ClearDataBinding()
            For Each Control As Control In Me.pcData.Controls
                Control.DataBindings.Clear()
            Next
        End Sub

        Public Overridable Sub GenerateEmailQuery()
            If Me._AConn Is Nothing Then Return
            Dim sSQL As New System.Text.StringBuilder
            sSQL.AppendLine(String.Format(" IF Not EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'U')) ", BundleTableProperty.BundleToTable))
            sSQL.AppendLine(" BEGIN ")
            sSQL.AppendLine(String.Format(" CREATE TABLE dbo.{0} ", BundleTableProperty.BundleToTable))
            sSQL.AppendLine(" ( PlugIn_ID nvarchar(10) not null,PlugIn_Licence varBinary(MAX),CompOption nvarchar(1)  )  ON [PRIMARY]; ")
            sSQL.AppendLine(String.Format(" ALTER TABLE dbo.{0} ADD CONSTRAINT ", BundleTableProperty.BundleToTable))
            sSQL.AppendLine(String.Format(" PK_{0} PRIMARY KEY CLUSTERED  ", BundleTableProperty.BundleToTable))
            sSQL.AppendLine(" ( PlugIn_ID) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,ALLOW_PAGE_LOCKS = ON) ON [PRIMARY];	  ")
            sSQL.AppendLine(" END ")

            Try
                Using sqlConn As New SqlClient.SqlConnection(_AConn.ConnectionString)
                    sqlConn.Open()
                    Using cmd As New SqlClient.SqlCommand(sSQL.ToString, sqlConn)
                        cmd.ExecuteScalar()


                        GenerateFreelyUDFFIeld(BundleTableProperty.BundleToTable, "EOutgoing", "EOutgoing", AutoCount.UDF.UDFType.Text, 50)
                        GenerateFreelyUDFFIeld(BundleTableProperty.BundleToTable, "EPort", "EPort", AutoCount.UDF.UDFType.Integer, 2)
                        GenerateFreelyUDFFIeld(BundleTableProperty.BundleToTable, "EUseSSL", "EUseSSL", AutoCount.UDF.UDFType.Text, 1)
                        GenerateFreelyUDFFIeld(BundleTableProperty.BundleToTable, "EUsePass", "EUsePass", AutoCount.UDF.UDFType.Text, 1)
                        GenerateFreelyUDFFIeld(BundleTableProperty.BundleToTable, "ETimeOut", "ETimeOut", AutoCount.UDF.UDFType.Integer, 2)
                        GenerateFreelyUDFFIeld(BundleTableProperty.BundleToTable, "EUserName", "EUserName", AutoCount.UDF.UDFType.Text, 20)
                        GenerateFreelyUDFFIeld(BundleTableProperty.BundleToTable, "EPasswrd", "EPasswrd", AutoCount.UDF.UDFType.Text, 50)

                    End Using
                End Using

            Catch ex As Exception

            End Try
        End Sub

        Private Sub GenerateFreelyUDFFIeld(ByVal TableName As String, ByVal RequiredUDF As String, ByVal UDFDisplayText As String,
                                    ByVal UType As Freely.UDF.IngUDFType,
                                    ByVal Size As Integer, Optional ByVal isUDFList As Boolean = False, Optional ByVal UDFListName As String = "")
            Dim AUDFTable As New Freely.UDF.FreelyUDFTable(TableName, _AConn)
            Dim drRow As DataRow = AUDFTable.Table.Rows.Find(New Object() {TableName, RequiredUDF.ToUpper})
            If drRow Is Nothing Then
                Dim AField As New Freely.UDF.FreelyField
                AField.Name = RequiredUDF
                AField.Caption = UDFDisplayText
                AField.UDFType = UType

                If (UType = AutoCount.UDF.UDFType.Text) Then
                    AField.TextProperties.Size = Size
                    AField.TextProperties.Unique = False
                    AField.TextProperties.Required = False
                ElseIf (UType = AutoCount.UDF.UDFType.Decimal) Then
                    AField.DecimalProperties.Scale = Size
                ElseIf (UType = AutoCount.UDF.UDFType.System) Then

                End If
                AUDFTable.Add(AField)
                AUDFTable.Save()
            End If
        End Sub


        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Me.bsEmail.EndEdit()

            Dim dvView As DataRowView = Me.bsEmail.Current
            _EmailSetting = New EmailProperty(dvView.Row)
            _EmailSetting.UserName = _EmailSetting.UserName
            Dim AOnSaveEmail As New SaveEmailArgs(Me.dsEmail, _EmailSetting)
            RaiseEvent OnSaveEmail(AOnSaveEmail)
        End Sub

        Public Overridable Sub Save()
            adpEmail.Update(Me.dsEmail)
        End Sub

        Private Sub lblTestSent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTestSent.Click

            Dim dvView As DataRowView = Me.bsEmail.Current
            _EmailSetting = New EmailProperty(dvView.Row)

            Dim AOnSaveEmail As New SaveEmailArgs(Me.dsEmail, _EmailSetting)
            RaiseEvent OnTestSentEmail(AOnSaveEmail)
        End Sub

        Private Sub FreelyEmailComponent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try

            Catch ex As Exception

            End Try
        End Sub
    End Class
    Public Class OnSendingEmailArgs
        Private _AEmailDataset As DataSet
        Private _EmailProperty As EmailProperty

        Public Sub New(ByVal ADataset As DataSet, ByVal AEmailSetting As EmailProperty)
            _AEmailDataset = ADataset
            _EmailProperty = AEmailSetting
        End Sub

        Public ReadOnly Property EmailSetting As EmailProperty
            Get
                Return _EmailProperty
            End Get
        End Property

        Public ReadOnly Property EmailDataset As DataSet
            Get
                Return _AEmailDataset
            End Get
        End Property
        Public Property Message As String


    End Class

    Public Class SaveEmailArgs
        Private _AEmailDataset As DataSet
        Private _EmailProperty As EmailProperty

        Public Sub New(ByVal ADataset As DataSet, ByVal AEmailSetting As EmailProperty)
            _AEmailDataset = ADataset
            _EmailProperty = AEmailSetting
        End Sub

        Public ReadOnly Property EmailSetting As EmailProperty
            Get
                Return _EmailProperty
            End Get
        End Property

        Public ReadOnly Property EmailDataset As DataSet
            Get
                Return _AEmailDataset
            End Get
        End Property
    End Class
    Public Class EmailProperty
        Private _OutGoingEmail As String
        Private _Port As Integer = 0
        Private _UseSSL As Boolean = False
        Private _UsePass As Boolean = False
        Private _TimeOut As Integer = 0
        Private _UserName As String = String.Empty
        Private _Password As String = String.Empty

        Private _drRow As DataRow = Nothing


        Public Property Password As String
            Get
                Return _Password
            End Get
            Set(ByVal value As String)
                _Password = value
                _drRow.Item(FreelyEmailComponent.ING_EPasswrd) = value
            End Set
        End Property


        Public Property UserName As String
            Get
                Return _UserName
            End Get
            Set(ByVal value As String)
                _UserName = value
                _drRow.Item(FreelyEmailComponent.ING_EUserName) = value
            End Set
        End Property

        Public Property TimeOut As Integer
            Get
                Return _TimeOut
            End Get
            Set(ByVal value As Integer)
                _TimeOut = value
                _drRow.Item(FreelyEmailComponent.ING_ETimeOut) = value
            End Set
        End Property

        Public Property UsePassword As Boolean
            Get
                Return _UsePass
            End Get
            Set(ByVal value As Boolean)
                _UsePass = value
                _drRow.Item(FreelyEmailComponent.ING_EUsePass) = value
            End Set
        End Property

        Public Property UseSSL As Boolean
            Get
                Return _UseSSL
            End Get
            Set(ByVal value As Boolean)
                _UseSSL = value
                _drRow.Item(FreelyEmailComponent.ING_EUseSSL) = value
            End Set
        End Property

        Public Property Port As Integer
            Get
                Return _Port
            End Get
            Set(ByVal value As Integer)
                _Port = value
                _drRow.Item(FreelyEmailComponent.ING_EPort) = value
            End Set
        End Property


        Public Property OutgoingEmail As String
            Get
                Return _OutGoingEmail
            End Get
            Set(ByVal value As String)
                _OutGoingEmail = value
                _drRow.Item(FreelyEmailComponent.ING_EOutgoing) = value
            End Set
        End Property

        Friend Sub New(ByVal ADataRow As DataRow)
            If ADataRow Is Nothing Then Return
            _drRow = ADataRow
            _OutGoingEmail = IIf(ADataRow.Item(FreelyEmailComponent.ING_EOutgoing) Is DBNull.Value, String.Empty, ADataRow.Item(FreelyEmailComponent.ING_EOutgoing))
            _Port = IIf(ADataRow.Item(FreelyEmailComponent.ING_EPort) Is DBNull.Value, 587, ADataRow.Item(FreelyEmailComponent.ING_EPort))
            _UseSSL = IIf(ADataRow.Item(FreelyEmailComponent.ING_EUseSSL) Is DBNull.Value, "N", ADataRow.Item(FreelyEmailComponent.ING_EUseSSL)) = "Y"
            _UsePass = IIf(ADataRow.Item(FreelyEmailComponent.ING_EUsePass) Is DBNull.Value, "N", ADataRow.Item(FreelyEmailComponent.ING_EUsePass)) = "Y"
            _TimeOut = IIf(ADataRow.Item(FreelyEmailComponent.ING_ETimeOut) Is DBNull.Value, 60, ADataRow.Item(FreelyEmailComponent.ING_ETimeOut))
            _UserName = IIf(ADataRow.Item(FreelyEmailComponent.ING_EUserName) Is DBNull.Value, String.Empty, ADataRow.Item(FreelyEmailComponent.ING_EUserName))
            _Password = IIf(ADataRow.Item(FreelyEmailComponent.ING_EPasswrd) Is DBNull.Value, String.Empty, ADataRow.Item(FreelyEmailComponent.ING_EPasswrd))
        End Sub

    End Class

    Public Class BundleTableProperty
        Dim _BundleTable As String = "PlugIn_GeneralTable"
        Dim _FilterString As String = "1=1"
        Public Property BundleToTable As String
            Get
                Return _BundleTable
            End Get
            Set(ByVal value As String)
                _BundleTable = value
            End Set
        End Property
        Public Property FilterString As String
            Get
                Return _FilterString
            End Get
            Set(ByVal value As String)
                _FilterString = value
            End Set
        End Property

    End Class
End Namespace

