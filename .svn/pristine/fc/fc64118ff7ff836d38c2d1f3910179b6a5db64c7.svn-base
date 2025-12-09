Imports System.Threading
Imports System.Reflection
Public Class FreelyLocalication
    Public Shared Function GetString(ByVal AEnumID As [Enum], ByVal ParamArray args As Object()) As String
        Try
            Dim AIDType As Type = AEnumID.GetType()

            Dim stringFromResource As String = String.Empty

            If Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName <> "en" Then

            End If

            If stringFromResource.Length = 0 Then
                Dim member As MemberInfo() = AIDType.GetMember(AEnumID.ToString())
                Dim defaultStringAttribute As FreelyDefaultAttribute = TryCast(Attribute.GetCustomAttribute(member(0), GetType(FreelyDefaultAttribute)), FreelyDefaultAttribute)
                stringFromResource = (If(defaultStringAttribute Is Nothing, String.Empty, defaultStringAttribute.Text))
            End If

            Dim stringBuilder As New System.Text.StringBuilder()

            If args Is Nothing Then
                Return stringFromResource.ToString
            End If
            Return String.Format(stringFromResource, args)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try
        Return ""
    End Function
    Public NotInheritable Class FreelyStringAttribute
        Inherits Attribute

        Dim _Text As String = String.Empty
        Public ReadOnly Property Text As String
            Get
                Return _Text
            End Get
        End Property

        Public Sub New(ByVal AString As String)
            _Text = AString
        End Sub
    End Class

    Public NotInheritable Class FreelyDefaultAttribute
        Inherits Attribute

        Dim _Text As String = String.Empty
        Public ReadOnly Property Text As String
            Get
                Return _Text
            End Get
        End Property

        Public Sub New(ByVal AString As String)
            _Text = AString
        End Sub
    End Class
End Class

Public Module FreelyEnumEx
    <Runtime.CompilerServices.Extension()>
    Public Function ToFreelyLocalication(ByVal AFreelyManufatureString As [Enum]) As String
        Return FreelyLocalication.GetString(AFreelyManufatureString)
    End Function
End Module
