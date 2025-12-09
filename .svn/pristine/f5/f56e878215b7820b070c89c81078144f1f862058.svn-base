Namespace Freely.Log.Helper

    Public Class FreelyLogDAL
        Public Class FreelyLog

            Dim _MasterRow As DataRow = Nothing
            Public Property DtlKey As Long
                Get
                    Return IIf(_MasterRow.Item("DtlKey") Is DBNull.Value, -1, _MasterRow.Item("DtlKey"))
                End Get
                Set(value As Long)
                    _MasterRow.Item("DtlKey") = value
                End Set
            End Property
            Public Property EventCode As String
                Get
                    Return _MasterRow.Item("EventCode").ToString
                End Get
                Set(value As String)
                    _MasterRow.Item("EventCode") = value
                End Set
            End Property
            Public Property DocKey As Long
                Get
                    Return IIf(_MasterRow.Item("DocKey") Is DBNull.Value, -1, _MasterRow.Item("DocKey"))
                End Get
                Set(value As Long)
                    _MasterRow.Item("DocKey") = value
                End Set
            End Property

            Public Property DocType As String
                Get
                    Return _MasterRow.Item("DocType").ToString
                End Get
                Set(value As String)
                    _MasterRow.Item("DocType") = value
                End Set
            End Property
            Public Property Log As String
                Get
                    Return _MasterRow.Item("Log").ToString
                End Get
                Set(value As String)
                    _MasterRow.Item("Log") = value
                End Set
            End Property
            Public Property DocNo As String
                Get
                    Return _MasterRow.Item("DocNo").ToString
                End Get
                Set(value As String)
                    _MasterRow.Item("DocNo") = value
                End Set
            End Property
            Public Property EventDescription As String
                Get
                    Return _MasterRow.Item("EventDescription").ToString
                End Get
                Set(value As String)
                    _MasterRow.Item("EventDescription") = value
                End Set
            End Property
            Public Property LastModified As DateTime
                Get
                    Return IIf(_MasterRow.Item("LastModified") Is DBNull.Value, Now, _MasterRow.Item("LastModified"))
                End Get
                Set(value As DateTime)
                    _MasterRow.Item("LastModified") = value
                End Set
            End Property

            Public Property LastModifiedUserID As String
                Get
                    Return _MasterRow.Item("LastModifiedUserID").ToString
                End Get
                Set(value As String)
                    _MasterRow.Item("LastModifiedUserID") = value
                End Set
            End Property

            Public Property CreatedTimeStamp As DateTime
                Get
                    Return IIf(_MasterRow.Item("CreatedTimeStamp") Is DBNull.Value, Now, _MasterRow.Item("CreatedTimeStamp"))
                End Get
                Set(value As DateTime)
                    _MasterRow.Item("CreatedTimeStamp") = value
                End Set
            End Property

            Public Property CreatedUserID As String
                Get
                    Return _MasterRow.Item("CreatedUserID").ToString
                End Get
                Set(value As String)
                    _MasterRow.Item("CreatedUserID") = value
                End Set
            End Property

            Private ReadOnly Property MasterRow As DataRow
                Get
                    Return _MasterRow
                End Get
            End Property

            Public Sub New(ByVal ADataRow As DataRow)
                _MasterRow = ADataRow
            End Sub
        End Class
    End Class

End Namespace