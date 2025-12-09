Namespace Freely.Enumeration
    Public Class FreelyEnum

        Public Enum FormActionEnum
            None = -1
            AddAction
            AddDetailAction
            EditAction
            EditDetailAction
            DeleteAction
            DeleteDetailAction
            RefreshAction  '2022/03/22 lai Added Refresh Action.
            ViewAction
            SaveAction
            Other
        End Enum
        Public Enum ReportActionEnum
            None = -1
            PreviewReport
            PrintReport
            DesignReport
        End Enum

        Public Enum AccessRightActionEnum
            None = -1
            Add
            AddDetail
            Edit
            EditDetail
            View
            Delete
            DeleteDetail
            Print
            PreviewReport
            ExportReport
            Other
        End Enum

        Public Enum NotificationType
            Grid = 0
            SingleLine = 1
        End Enum
        Public Enum ButtonType
            None = -1
            Create = 0
            Edit = 1
            Delete = 2
            Save = 3
            Refresh = 4
            DesignReport = 5
            PreviewReport = 6
            PrintReport = 7
            CancelDocument = 8
            View = 9
        End Enum

        Public Enum DocumentTypeGroup
            None = -1
            GL = 0
            AR = 1
            AP = 2
            Stock = 3
            Sales = 4
            Purchase = 5
            General = 6
            Tools = 7
            Others = 8
        End Enum
        Public Enum EnumDocType


            None = -1
            DODoc = 0 'DO
            IVDoc = 1 'IV
            CSDoc = 2 'CS
            XCSDoc = 3
            XCSPDoc = 4
            ARInvoice = 5
            APInvoice = 6


            QTDoc = 7 'QT
            CNDoc = 8 'CN
            DNDoc = 9 'DN
            DRDoc = 10 'DR

            RQDoc = 11 'RQ
            PODoc = 12 'PO
            GRDoc = 13 'GR
            PIDoc = 14 'PI
            CPDoc = 15 'CP

            SODoc = 16 'SO
            XSDoc = 17 'XS
            CSGNDoc = 18 'CSGN
            PRDoc = 19  'PR
            XPDoc = 20 'XP
            GTDoc = 21 'GT

            ADJDoc = 22
            ISSDoc = 23
            RCVDoc = 24
            XFERDoc = 25
            UCostDoc = 26
            UOMConvDoc = 27
            WOFFDoc = 28


        End Enum

        Public Enum FreelyRegistryType
            [Integer] = 0
            [Decimal] = 1
            [DateTime] = 2
            [Date] = 3
            [Time] = 4
            [String] = 5
            [Binary] = 6
            [Object] = 7
        End Enum
    End Class
End Namespace

