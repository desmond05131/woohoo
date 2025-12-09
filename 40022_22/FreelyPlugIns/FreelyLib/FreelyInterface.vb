Namespace Freely.Interface
    Public Interface FreelyInterface
        Property AConn As AutoCount.Data.DBSetting
        ReadOnly Property sqlConn As SqlClient.SqlConnection
        Property TitleName As String
    End Interface

    Public Interface IFreelyBusinessForm
        Property UpdateAsyncDataSet As Freely.Threading.Thread.AsyncDataSetUpdate
    End Interface

    Public Interface IFreelyBaseForm
        ReadOnly Property Auther As String
    End Interface
    Public Interface IFreelyReportForm

    End Interface
    Public Interface IFreelyFormController
        Property FreelyCommandMasterHelper As Standard.Forms.FreelyFormHelper
        Property DBSetting As AutoCount.Data.DBSetting
        Property UserSession As AutoCount.Authentication.UserSession
        Property AccessRights As List(Of Standard.AccessRight.FreelyAccessRight)
        Property ReportType As String
        Sub InitFormLoad(ByVal AUsersession As AutoCount.Authentication.UserSession)
        Sub FormAction(ByVal AFormActionEnum As Enumeration.FreelyEnum.FormActionEnum)
        Sub ReportAction(ByVal ADockey As Long, ByVal AReportAction As Enumeration.FreelyEnum.ReportActionEnum)
        Function ReturnDataset(ByVal ADocKey As Long) As DataSet
    End Interface

End Namespace

