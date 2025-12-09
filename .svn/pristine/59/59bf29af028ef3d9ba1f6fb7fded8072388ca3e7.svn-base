Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports AutoCount.Authentication
Imports AutoCount.MainEntry
Imports AutoCount.PlugIn
Imports FreelyCreative.StockItemInquiry.StockInquiryItem

Module Program
    <STAThread()>
    Sub Main()
        Try
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)

            ' Start AutoCount login
            MainStartup.Default.SubProjectStartupWithLogin("", "")

            If UserSession.CurrentUserSession IsNot Nothing Then
                Dim eBeforeLoadEvent As New BeforeLoadArgs(UserSession.CurrentUserSession, FreelyPlugIns.FreelyGuid, "", AutoCount.CompanyProfile.Create(UserSession.CurrentUserSession.DBSetting))
                Dim eAfterLoadEvent As New AfterLoginArgs(UserSession.CurrentUserSession, FreelyPlugIns.FreelyGuid, "", AutoCount.CompanyProfile.Create(UserSession.CurrentUserSession.DBSetting))

                Dim APlugIn As New FreelyPlugIns()
                APlugIn.BeforeLoad(eBeforeLoadEvent)
                APlugIn.AfterLogin(eAfterLoadEvent)

                ' Register custom plug-ins / menus
                AutoCountController.RegisterPlugIns()

                ' Launch AutoCount main form
                Application.Run(New FormMain(UserSession.CurrentUserSession))
            End If

        Catch ex As Exception
            Freely.Standard.MessageBox.FreelyMessageBox.ShowErrorMessage(ex.Message)
        End Try
    End Sub
End Module



'Module Program
'    <STAThread()>
'    Sub Main()
'        Try
'            AutoCount.MainEntry.MainStartup.Default.SubProjectStartupWithLogin("", "")
'            If AutoCount.Authentication.UserSession.CurrentUserSession IsNot Nothing Then
'                Dim eBeforeLoadEvent As New AutoCount.PlugIn.BeforeLoadArgs(AutoCount.Authentication.UserSession.CurrentUserSession, FreelyPlugIns.FreelyGuid, "", AutoCount.CompanyProfile.Create(AutoCount.Authentication.UserSession.CurrentUserSession.DBSetting))
'                Dim eAfterLoadEvent As New AutoCount.PlugIn.AfterLoginArgs(AutoCount.Authentication.UserSession.CurrentUserSession, FreelyPlugIns.FreelyGuid, "", AutoCount.CompanyProfile.Create(AutoCount.Authentication.UserSession.CurrentUserSession.DBSetting))
'                Dim APlugIn As New FreelyPlugIns()
'                APlugIn.BeforeLoad(eBeforeLoadEvent)
'                APlugIn.AfterLogin(eAfterLoadEvent)
'                System.Windows.Forms.Application.Run(New frmMain(AutoCount.Authentication.UserSession.CurrentUserSession))
'            End If
'        Catch ex As Exception
'            Freely.Standard.MessageBox.FreelyMessageBox.ShowErrorMessage(ex.Message)
'        End Try
'    End Sub
'End Module
