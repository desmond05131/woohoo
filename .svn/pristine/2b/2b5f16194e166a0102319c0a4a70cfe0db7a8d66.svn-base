Public Class EmailClass

    Dim _DBSetting As AutoCount.Data.DBSetting
    Public ReadOnly Property DBSetting As AutoCount.Data.DBSetting
        Get
            Return _DBSetting
        End Get
    End Property

    Dim _EmailAcc As String
    Public ReadOnly Property EmailAcc As String
        Get
            Return _EmailAcc
        End Get
    End Property

    Dim _EmailPasswd As String
    Public ReadOnly Property EmailPasswd As String
        Get
            Return _EmailPasswd
        End Get
    End Property

    Dim _EmailOutgoing As String
    Public ReadOnly Property EmailOutgoing As String
        Get
            Return _EmailOutgoing
        End Get
    End Property

    Dim _EmailPort As Integer
    Public ReadOnly Property EmailPort As Integer
        Get
            Return _EmailPort
        End Get
    End Property

    Dim _EmailTimeOut As Integer
    Public ReadOnly Property EmailTimeOut As Integer
        Get
            Return _EmailTimeOut
        End Get
    End Property

    Dim _EmailDomainName As String
    Public ReadOnly Property EmailDomainName As String
        Get
            Return _EmailDomainName
        End Get
    End Property

    Dim _EmailDefaulSub As String
    Public ReadOnly Property EmailDefaulSub As String
        Get
            Return _EmailDefaulSub
        End Get
    End Property

    Dim _EmailDefaultName As String
    Public ReadOnly Property EmailDefaultName As String
        Get
            Return _EmailDefaultName
        End Get
    End Property

    Dim _EmailSecurity As String
    Public ReadOnly Property EmailSecurity As String
        Get
            Return _EmailSecurity
        End Get
    End Property

    Dim _EmailSSL As Boolean
    Public ReadOnly Property EmailSSL As Boolean
        Get
            Return _EmailSSL
        End Get
    End Property

    Dim _EmailUsePass As String
    Public ReadOnly Property EmailUsePass As String
        Get
            Return _EmailUsePass
        End Get
    End Property

    Public Sub New(ByVal DBSetting As AutoCount.Data.DBSetting, ByVal oDataTable As DataTable)
        _DBSetting = DBSetting
        For Each dc As DataColumn In oDataTable.Columns
            Dim colNames As String = dc.ColumnName
            Select Case colNames
                Case "EmailAcc"
                    Me._EmailAcc = oDataTable.Rows(0).Item("EmailAcc").ToString
                Case "EmailPasswd"
                    Me._EmailPasswd = oDataTable.Rows(0).Item("EmailPasswd").ToString
                Case "EmailOutgoing"
                    Me._EmailOutgoing = oDataTable.Rows(0).Item("EmailOutgoing").ToString
                Case "EmailPort"
                    Me._EmailPort = oDataTable.Rows(0).Item("EmailPort")
                Case "EmailTimeOut"
                    Me._EmailTimeOut = oDataTable.Rows(0).Item("EmailTimeOut")
                Case "EmailDomainName"
                    Me._EmailDomainName = oDataTable.Rows(0).Item("EmailDomainName").ToString
                Case "EmailDefaulSub"
                    Me._EmailDefaulSub = oDataTable.Rows(0).Item("EmailDefaulSub").ToString
                Case "EmailDefaultName"
                    Me._EmailDefaultName = oDataTable.Rows(0).Item("EmailDefaultName").ToString
                Case "EmailSecurity"
                    Me._EmailSecurity = oDataTable.Rows(0).Item("EmailSecurity").ToString
                Case "EmailSSL"
                    Me._EmailSSL = IIf(oDataTable.Rows(0).Item("EmailSSL").ToString = String.Empty, False, True)
                Case "EmailUsePass"
                    Me._EmailUsePass = IIf(oDataTable.Rows(0).Item("EmailUsePass").ToString = String.Empty, False, True)
            End Select
        Next
    End Sub
    Public Function SendEmail(ByVal oReceiver As String, ByVal oEmailSubject As String, ByVal oEmailBody As String, ByVal oEmailAttach As List(Of String), ByVal oCCList As List(Of String), ByVal oSentCC As Boolean, ByVal IsHighImportance As Boolean) As Boolean
        Dim Server As New System.Net.Mail.SmtpClient
        Try
            Dim Mail As System.Net.Mail.MailMessage = New Net.Mail.MailMessage
            If Me.EmailOutgoing.ToString.Length > 0 And Me.EmailPort.ToString.Length > 0 Then
                Mail.IsBodyHtml = True
                If oEmailSubject.ToString.Length > 0 Then
                    Mail.Subject = oEmailSubject
                End If
                If oEmailBody.ToString.Length > 0 Then
                    Mail.Body = oEmailBody
                End If

                Server.Host = Me.EmailOutgoing
                Server.Port = Me.EmailPort
                Server.EnableSsl = Me.EmailSSL
                Server.Timeout = Me.EmailTimeOut * 1000 '1000 Mean CPU tick 1000 time = 1 sec
            End If
            Dim MailFrom As New System.Net.Mail.MailAddress(Me.EmailAcc, Me.EmailDefaultName)
            Mail.From = MailFrom

            Dim ArrayEmailTo() = oReceiver.Split(";")
            Dim EmailTo As System.Net.Mail.MailAddress
            For iEmailAdd As Integer = 0 To ArrayEmailTo.Length - 1
                If ArrayEmailTo(iEmailAdd).Trim <> String.Empty Then
                    EmailTo = New System.Net.Mail.MailAddress(ArrayEmailTo(iEmailAdd))
                    Mail.To.Add(EmailTo)
                End If
            Next
            If oCCList IsNot Nothing Then
                If oSentCC Then
                    Dim MailCC As System.Net.Mail.MailAddress
                    For Each sCC As String In oCCList
                        MailCC = New Net.Mail.MailAddress(sCC)
                        Mail.To.Add(MailCC)
                    Next
                Else
                    For Each sCC As String In oCCList
                        EmailTo = New Net.Mail.MailAddress(sCC)
                        Mail.To.Add(EmailTo)
                    Next
                End If
            End If

            If Mail.Body.ToArray.Length > 0 Then
                Mail.Body = Mail.Body
            End If


            If oEmailAttach IsNot Nothing Then
                For Each AAttachment As String In oEmailAttach
                    If System.IO.File.Exists(AAttachment) Then
                        Mail.Attachments.Add(New Net.Mail.Attachment(AAttachment))
                    ElseIf AAttachment.Length > 0 Then
                        Mail.Body = "Sorry, Can't Found the Attachment File. Please Contact your System Administrator!"
                    End If
                Next
                'Dim htmlView As Net.Mail.AlternateView = Net.Mail.AlternateView.CreateAlternateViewFromString(Mail.Body, Nothing, "text/html")
                'For Each sAttachment As String In oEmailAttach
                '    If System.IO.File.Exists(sAttachment) Then
                '        Dim LinkedImage As Net.Mail.LinkedResource = New Net.Mail.LinkedResource(sAttachment)
                '        LinkedImage.ContentType = New Net.Mime.ContentType(Net.Mime.MediaTypeNames.Image.Jpeg)

                '        Dim sFileName As String = IO.Path.GetFileNameWithoutExtension(sAttachment)
                '        Dim sSplit As String() = sFileName.Split(" ")
                '        Dim sNewFileName As String = ""
                '        For Each s As String In sSplit
                '            sNewFileName = sNewFileName & s
                '        Next

                '        LinkedImage.ContentId = sNewFileName

                '        htmlView.LinkedResources.Add(LinkedImage)

                '    ElseIf sAttachment.ToString.Length > 0 Then
                '        Mail.Body = "Couldn't found Attach File, Please Contact your System Administrator!"
                '    End If
                'Next
                'Mail.AlternateViews.Add(htmlView)
            End If

            If IsHighImportance Then
                Mail.Priority = Net.Mail.MailPriority.High
            Else
                Mail.Priority = Net.Mail.MailPriority.Normal
            End If

            Try
                System.Net.ServicePointManager.CheckCertificateRevocationList = False
                System.Net.ServicePointManager.ServerCertificateValidationCallback = Function(obj, certificate, chain, errors) True

                System.Net.ServicePointManager.SecurityProtocol = Me.EmailSecurity

                If Me.EmailAcc.ToString.Length > 0 And Me.EmailPasswd.ToString.Length > 0 Then
                    If Me.EmailDomainName.ToString.Length > 0 Then
                        Server.Credentials = New System.Net.NetworkCredential(Me.EmailAcc, Me.EmailPasswd, Me.EmailDomainName)
                    Else
                        Server.Credentials = New System.Net.NetworkCredential(Me.EmailAcc, Me.EmailPasswd)
                    End If
                Else
                    Throw New Exception("Email doesn't configure properly!")
                    Return False
                End If

                Server.Send(Mail)
                Mail.Attachments.Dispose()

                Return True
            Catch ex As Exception
                Throw New Exception("Exception: " + ex.Message, ex.InnerException)
                Return False
            End Try
        Catch ex As Exception
            Throw New Exception("Exception: " + ex.Message, ex.InnerException)
            Return False
        End Try
        Return True
    End Function
End Class