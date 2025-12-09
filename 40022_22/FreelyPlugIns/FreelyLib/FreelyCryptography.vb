Imports System.Security.Cryptography

Namespace Freely.Cryptography
    Public Class FreelyCryptography
        Private Const KeyForEncrypt As String = "Lai7888"

        Public ReadOnly Property CryptographyCipherMode As System.Security.Cryptography.CipherMode
            Get
                Return CipherMode.ECB
            End Get
        End Property

        ''' <summary>
        ''' This Function Is Created By Lai Wei Loong
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Author As String
            Get
                Return "Created By Lai Wei Loong"
            End Get
        End Property



        Public Function EncryptPassword(ByVal strToEncrypt As String) As String
            Try
                Dim objDESCrypto As New TripleDESCryptoServiceProvider()
                Dim objHashMD5 As New MD5CryptoServiceProvider()

                Dim byteHash As Byte(), byteBuff As Byte()
                Dim strTempKey As String = KeyForEncrypt

                byteHash = objHashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(strTempKey))
                objHashMD5 = Nothing
                objDESCrypto.Key = byteHash
                objDESCrypto.Mode = CryptographyCipherMode

                byteBuff = System.Text.ASCIIEncoding.ASCII.GetBytes(strToEncrypt)
                Return Convert.ToBase64String(objDESCrypto.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length))
            Catch ex As Exception
                Return "Wrong Input. " + ex.Message
            End Try
        End Function

        Public Function DecryptPassword(ByVal strEncrypted As String) As String
            Try
                Dim objDESCrypto As New TripleDESCryptoServiceProvider()
                Dim objHashMD5 As New MD5CryptoServiceProvider()

                Dim byteHash As Byte(), byteBuff As Byte()
                Dim strTempKey As String = KeyForEncrypt

                byteHash = objHashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(strTempKey))
                objHashMD5 = Nothing
                objDESCrypto.Key = byteHash
                objDESCrypto.Mode = CryptographyCipherMode
                'CBC, CFB
                byteBuff = Convert.FromBase64String(strEncrypted)
                Dim strDecrypted As String = System.Text.ASCIIEncoding.ASCII.GetString(objDESCrypto.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length))
                objDESCrypto = Nothing

                Return strDecrypted
            Catch ex As Exception
                Return "Wrong Input. " + ex.Message
            End Try
        End Function

    End Class

End Namespace

Namespace Freely.Licensing
    Public Class LicenseClass
        Public Property DocType As String = String.Empty
        Public Property DocDesc As String = String.Empty
    End Class

    Public Class License
        Private AListOfLicenseClass As List(Of LicenseClass)
        Private sLicenseList As String() = {"PR", "PI", "CP", "PO", "GRN", "SO", "DO", "IV", "CS", "CN", "QT", "ARIV", "ARDN", "ARCN", "APIV", "APDN", "APCN", "CB", "JE"}
        Public ReadOnly Property LicenseList As List(Of LicenseClass)
            Get
                AListOfLicenseClass = New List(Of LicenseClass)
                Dim AClass As LicenseClass
                For Each sList As String In sLicenseList
                    AClass = New LicenseClass
                    AClass.DocType = sList

                    Select Case sList
                        Case "PR"
                            AClass.DocDesc = "Purchase Return"
                        Case "PI"
                            AClass.DocDesc = "Purchase Invoice"
                        Case "CP"
                            AClass.DocDesc = "Cash Purchase"
                        Case "PO"
                            AClass.DocDesc = "Purchase Order"
                        Case "GRN"
                            AClass.DocDesc = "Goods Received Note"
                        Case "SO"
                            AClass.DocDesc = "Sales Order"
                        Case "DO"
                            AClass.DocDesc = "Delivery Order"
                        Case "IV"
                            AClass.DocDesc = "Invoice"
                        Case "CS"
                            AClass.DocDesc = "Cash Sales"
                        Case "CN"
                            AClass.DocDesc = "Credit Note"
                        Case "QT"
                            AClass.DocDesc = "Quatation"
                        Case "ARIV"
                            AClass.DocDesc = "AR-Invoice"
                        Case "ARDN"
                            AClass.DocDesc = "AR-Debit Note"
                        Case "ARCN"
                            AClass.DocDesc = "AR-Credit Note"
                        Case "APIV"
                            AClass.DocDesc = "AP-Invoice"
                        Case "APDN"
                            AClass.DocDesc = "AP-Debit Note"
                        Case "APCN"
                            AClass.DocDesc = "AP-Credit Note"
                        Case "CB"
                            AClass.DocDesc = "Cash Book"
                        Case "JE"
                            AClass.DocDesc = "Journal Entry"
                        Case Else
                            Continue For
                    End Select
                    AListOfLicenseClass.Add(AClass)
                Next
                Return AListOfLicenseClass
            End Get
        End Property
    End Class


End Namespace
