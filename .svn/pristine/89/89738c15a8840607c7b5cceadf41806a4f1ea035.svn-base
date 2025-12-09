
Imports System.Windows.Forms
Imports System.Reflection
Imports AutoCount.PlugIn

Public Class FreelyPlugIns
    Inherits AutoCount.PlugIn.BasePlugIn

    Public Const _ProductID As String = "40022"
    Public Const ProductName As String = "Autosoft: Item Inquiry"
    Public Const MinDevExpressVer As String = "22.2.7"
    Public Const SetMinAutoCountVer As String = ""
    Public Const FreelyFeedbackEmail As String = "ronas02@autosoftsolution.com.my"
    Public Const FreelyLicenseInformation As String = "License By Autosoft Solution Sdn Bhd"

    Public Shared Property FreelyGuid As Guid = New Guid("D596F099-FC53-48CE-B5AF-48D2B7DCC232")
    Sub New()
        MyBase.New(FreelyPlugIns.FreelyGuid, ProductName, GetType(FreelyPlugIns).Assembly.GetName.Version.ToString(), FreelyFeedbackEmail)
        'SetManufacturer(ToFreelyLocalication(Freely.Standard.FreelyManufatureInformation.FreelyInfo.Manufacturer))
        'SetManufacturerUrl(ToFreelyLocalication(Freely.Standard.FreelyManufatureInformation.FreelyInfo.CompanyURL))
        'SetCopyright(ToFreelyLocalication(Freely.Standard.FreelyManufatureInformation.FreelyInfo.CopyRight))
        'SetCopyright(ToFreelyLocalication(Freely.Standard.FreelyManufatureInformation.FreelyInfo.SalesPhoneNo))
        'SetCopyright(ToFreelyLocalication(Freely.Standard.FreelyManufatureInformation.FreelyInfo.SupportPhoneNo))

        SetCopyright("Copyright 2025 @ Autosoft Solution Sdn Bhd")
        SetManufacturer("Autosoft Solution Sdn Bhd")
        SetManufacturerUrl("https://autosoftsolution.com.my/")
        SetSalesPhone("+60 12-783 1357")
        SetSupportPhone("+60 17-773 1357")
        SetDevExpressComponentVersionRequired(MinDevExpressVer)
        SetMinimumAccountingVersionRequired(SetMinAutoCountVer)
        Me.SetIsFreeLicense(False)
    End Sub

    Public Overrides Sub AfterLogin(ByVal e As AutoCount.PlugIn.AfterLoginArgs)
        Dim AHelper As New Freely.Standard.PlugIns.FreelyPlugInsHelper(e.UserSession)
        MyBase.AfterLogin(e)
    End Sub

    Public Overrides Sub AfterLoad(e As AutoCount.PlugIn.AfterLoadArgs)
        MyBase.AfterLoad(e)
    End Sub

    Public Overrides Sub GetLicenseStatus(e As AutoCount.PlugIn.LicenseStatusArgs)
        e.LicenseStatus = AutoCount.PlugIn.LicenseStatus.Custom
        e.CustomLicenseStatus = FreelyPlugIns.FreelyLicenseInformation
    End Sub

    Public Overrides Function BeforeLoad(ByVal e As AutoCount.PlugIn.BeforeLoadArgs) As Boolean
        Try
            Dim AHelper As New Freely.Standard.PlugIns.FreelyPlugInsHelper(e.UserSession)
            e.MainMenuCaption = ProductName

            AccessRightsCommand.InitAccessRight()

            Dim registerScript As New FreelyRegisterAutoCountScript(AHelper)
            registerScript.Register()
        Catch ex As Exception
            Freely.Standard.MessageBox.FreelyMessageBox.ShowErrorMessage(ex.Message)
        End Try
        'Return (New LicenseController).IsValidLicense '<--- will use again once ronas has license generator
        Return True
    End Function
End Class
