Public Class LicenseModule
    Private Property _IsLicense As Boolean

    Friend WriteOnly Property SetIsLicense As Boolean
        Set(ByVal value As Boolean)

            If value <> _IsLicense Then
                _IsLicense = value
            End If
        End Set
    End Property

    Public ReadOnly Property IsLicense As Boolean
        Get
            Return _IsLicense
        End Get
    End Property

    Private Property _Caption As String

    Friend WriteOnly Property SetCaption As String
        Set(ByVal value As String)

            If value <> _Caption Then
                _Caption = value
            End If
        End Set
    End Property

    Public ReadOnly Property Caption As String
        Get
            Return _Caption
        End Get
    End Property

    Private Property _ExpiredDate As String

    Friend WriteOnly Property SetExpiredDate As String
        Set(ByVal value As String)

            If value <> _ExpiredDate Then
                _ExpiredDate = value
            End If
        End Set
    End Property

    Public ReadOnly Property ExpiredDate As String
        Get
            Return _ExpiredDate
        End Get
    End Property

    Public Sub New()
        _IsLicense = False
        _Caption = String.Empty
        _ExpiredDate = DateTime.MinValue.ToString("s")
    End Sub


End Class
