Namespace Freely.Application


    Public Class FreelyConstMessage

        Private _DefaultCompanyName As String = "Freely Creative Sdn. Bhd."
        Private _DefaultShortCompanyName As String = "Freely"

        Private Shared _LongTitleName As String = ""
        Private Shared _ShortTitleName As String = ""
        Private Shared _DateFormatString As String = ""
        Private Shared _FormatNumberN2 As String = ""
        Private Shared _FormatNumber2 As String = ""
        Private Shared _UserID As String = ""
        Private Shared _SQlConnString As String = ""
        Private Shared _CompanyName As String = ""
        Private Shared _ProductVersion As String = ""
        Private Shared _ProductName As String = ""

        Public Shared ReadOnly Property CompanyName As String
            Get
                Return _CompanyName
            End Get
        End Property

        Public Shared ReadOnly Property ProductVersion As String
            Get
                Return _ProductVersion
            End Get
        End Property

        Public Shared ReadOnly Property ProductName As String
            Get
                Return _ProductName
            End Get
        End Property

        Public Shared ReadOnly Property UserID As String
            Get
                Return _UserID
            End Get
        End Property
        Public Shared ReadOnly Property SQLConnString As String
            Get
                Return _SQlConnString
            End Get
        End Property

        Public Shared ReadOnly Property FormatNumber2 As String
            Get
                Return _FormatNumber2
            End Get
        End Property

        Public Shared ReadOnly Property FormatNumberN2 As String
            Get
                Return _FormatNumberN2
            End Get
        End Property

        Public Shared ReadOnly Property DateFormatString As String
            Get
                Return _DateFormatString
            End Get
        End Property


        Public Shared ReadOnly Property LongTitleName As String
            Get
                Return _LongTitleName
            End Get
        End Property

        Public Shared ReadOnly Property ShortTitleName As String
            Get
                Return _ShortTitleName
            End Get
        End Property


        Public ReadOnly Property DefaultCompanyName As String
            Get
                Return _DefaultCompanyName
            End Get
        End Property

        Public ReadOnly Property DefaultShortCompanyName As String
            Get
                Return _DefaultShortCompanyName
            End Get
        End Property

        ''' <summary>
        ''' This Const Message is Created By Lai Wei Loong
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Author As String
            Get
                Return "Created By Lai Wei Loong"
            End Get
        End Property
        Public Sub New(ByVal ACommand As FreelyMessageCommand)
            _LongTitleName = ACommand.LongTitleName
            _ShortTitleName = ACommand.ShortTitleName
            _DateFormatString = ACommand.DateFormatString
            _FormatNumberN2 = ACommand.FormatNumberN2
            _FormatNumber2 = ACommand.FormatNumber2
            _UserID = ACommand.UserID
            _SQlConnString = ACommand.SQLConnString
            _CompanyName = ACommand.CompanyName
            _ProductVersion = ACommand.ProgramVersion
            _ProductName = ACommand.ProgramName
        End Sub

        Public Const sDefaultUserCannotDelete As String = "Default User Could Not Be Deleted !"
        Public Const sDefaultGroupCannotDelete As String = "Default Group Could Not Be Deleted !"
        Public Const sDefaultUserCannotUntickInAccessRights As String = "Default User Could Not Unticked in Access Rights !"
        Public Const sDefaultGroupCannotUntickInAccessRights As String = "Default Group Could Not Unticked in Access Rights !"
        Public Const sDefaultReportCannotDelete As String = "Default Report Could Not Be Deleted !"
        Public Const sDuplicateReportName As String = "Report Name Duplicated!!"
        Public Const sReportNameExist As String = "Report Name Exist in List!!"
        Public Const sReportSave As String = "Report Saved!"
        Public Const sSystemReportNoSave As String = "System Report Could Not Be Saved!!"
        Public Const sDetailRecordEmpty As String = "Detail record is empty !"
        Public Const sMasterKeyEmpty As String = "Master key is empty !"
        Public Const sDetailKeyEmpty As String = "in detail table is empty !"
        Public Const sDupKeyInDetail As String = "Duplicate record in detail table !"
        Public Const sNoDataFound As String = "No Data Found !"

        Public Const sExitApplication As String = "Exit Program ?"
        Public Const sLoginFail As String = "Login Fail, Application Terminated !!"
        Public Const sMaxWindowOpen As String = "Maximum No. Of Windows Has Been Opened !"
        Public Const sPlsCloseAllForm As String = "All forms, beside main form must be closed before perform this operation !"

        Public Const sDuplicateRecord As String = "Duplicate Record !"
        Public Const sRecordSave As String = "Record Saved."
        Public Const sRecordCalculated As String = "Record Calculated."
        Public Const sRecordModified As String = "Record Modified, Do you want to continue ?"
        Public Const sRecordWant2Save As String = "Record has been Modified, Do you want to save ?"
        Public Const sRecordOfXWant2Save As String = "Record of {0} has been Modified, Do you want to save ?"

        Public Const sRecordDelete As String = "Confirm to delete the record ?"
        Public Const sRecordDeleteTitle As String = " Confirm deletion"
        Public Const sRecordDeleteSuccess As String = "Record deleted."
        Public Const sRecordDeleteFail As String = "Record delete fail !"
        Public Const sCloseEditForm As String = "Please close the edit form first !"
        Public Const sUserAbort As String = "User Abort !"
        Public Const sProcessComplete As String = "Process Completed !"
        Public Const sDoesNotExists As String = "Does Not Exists !"

        Public Const sCouldNotBeEmptyOrNull As String = "Could Not Be Empty Or Null !"
        Public Const sCouldNotBeZeroOrEmpty As String = "Could Not Be Empty Or Zero !"
        Public Const sCompanyActive As String = "Want to make this Company Code Active Now?"
        Public Const sIsInUse As String = " {0} Exists And Is IN USE !"
        Public Const sClearInUseData As String = "Please Clear IN USE Data before Deletion!"
        Public Const sRecordCancelled As String = "Record Cancelled !"
        Public Const sRecordWant2Cancel As String = "Confirm to Cancel Record ?"
        Public Const sRecordWant2CancelAll As String = "Confirm to Cancel All Record ?"
        Public Const sRecordDeleteAll As String = "Confirm to Delete All Record ?"
        Public Const sUpdateSuccess As String = "Update Successfully !"

        Public Const sRefreshEmployeeServiceInfo As String = "Refresh Employee Service Information ?"
        Public Const sShiftGroupChangeComplete As String = "Shift Group {0} Successfully Change To {1} Effective From Date {2}."
        Public Const sCompanyChangeComplete As String = "Company Code {0} Successfully Change To {1} Effective From Date {2}."
        Public Const sPleaseReprocessAttendance As String = "Please Reprocess Your Attendance !"
        Public Const sCouldNotSameAsSource As String = "Changes That Want To Apply Could Not Same As Source !"
        Public Const sBackupNotAllowRootDirectory As String = "Backup Not Allow Save In Root Directory !"
        Public Const sDefaultKeyCouldNotDelete As String = "Default Key Could Not Be Deleted !"
        Public Const sInvalidDateSelect As String = "Invalid selection for date range !"
        Public Const sErrorSelectExportFile As String = "Please select the export file !"
        Public Const sCodeInUseCouldNotDelete As String = "Code In Use Could Not Be Deleted !"
        Public Const sInvalidPeriod As String = "Invalid Period Range !"
        Public Const sDatasetModified As String = "Dataset has changed, Do you want to save ?"
        Public Const sCompanyEmpty As String = "No Company Selected!"

        Public Const sDataNotPermitted As String = "Data Not Permitted to Change!"
        Public Const sDBNotMatchProgramVer As String = "Database not matched Program Version, System Abort!"
        Public Const sVFPOleDBNotInstall As String = "Please install Microsoft OLE DB Provider for Visual Foxpro !"
        Public Const sErrorLocateDBServer As String = "Sorry, cannot locate the DB server !"
        Public Const sErrorLocateDB As String = "Sorry, cannot locate the database !"
        Public Const sErrorLocateXML As String = "Sorry, cannot locate {0} !"
        Public Const sWaitLoadForm As String = "Please wait while the form is loading .."
        Public Const sWaitExportForm As String = "Please wait while exporting .."
        Public Const sWaitSavingRecord As String = "Please wait while saving .."
    End Class

    Public Class FreelyMessageCommand

        Public Property UserID As String = String.Empty
        Public Property SQLConnString As String = String.Empty
        Public Property CompanyName As String = String.Empty

        Public Property LongTitleName As String = String.Empty
        Public Property ShortTitleName As String = String.Empty
        Public Property DateFormatString As String = "dd/MM/yyyy"
        Public Property FormatNumberN2 As String = "{0:#,0.00}"
        Public Property FormatNumber2 As String = "{0:#0.00}"
        Public Property ProgramVersion As String = "1.0.0.0"
        Public Property ProgramName As String = ""

    End Class

End Namespace