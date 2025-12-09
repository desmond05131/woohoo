Imports System.Runtime.CompilerServices
Imports System.Threading.Tasks
Imports System.Windows.Forms

Module ControlExtensions
    <Extension>
    Public Function InvokeAsync(control As Control, action As Action) As Task
        If control.InvokeRequired Then
            Dim tcs As New TaskCompletionSource(Of Object)()
            control.BeginInvoke(New MethodInvoker(Sub()
                                                      Try
                                                          action()
                                                          tcs.SetResult(Nothing)
                                                      Catch ex As Exception
                                                          tcs.SetException(ex)
                                                      End Try
                                                  End Sub))
            Return tcs.Task
        Else
            action()
            Return Task.CompletedTask
        End If
    End Function

End Module
