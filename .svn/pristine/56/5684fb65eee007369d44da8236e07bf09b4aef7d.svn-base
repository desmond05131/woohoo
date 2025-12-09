Namespace Freely.Threading
    Public Class Thread
        Public Delegate Sub AsyncDataSetUpdateDelegate(ds As DataSet, action As AsyncDataSetUpdateAction)

        Public Enum AsyncDataSetUpdateAction
            Update
            Delete
        End Enum


        Public MustInherit Class AsyncUpdate
            Protected myUpdateList As ArrayList

            Protected Sub New()
            End Sub

            Protected Sub AddDelegate(updateDelegate As MulticastDelegate)
                If Me.myUpdateList Is Nothing Then
                    Me.myUpdateList = New ArrayList()
                End If
                If Me.myUpdateList.IndexOf(updateDelegate) < 0 Then
                    Me.myUpdateList.Add(updateDelegate)
                End If
            End Sub

            Protected Sub RemoveDelegate(updateDelegate As MulticastDelegate)
                If Me.myUpdateList IsNot Nothing Then
                    For i As Integer = Me.myUpdateList.Count - 1 To 0 Step -1
                        If DirectCast(Me.myUpdateList(i), MulticastDelegate) = updateDelegate Then
                            Me.myUpdateList.RemoveAt(i)
                        End If
                    Next
                End If
            End Sub
        End Class

        Public Class AsyncDataSetUpdate
            Inherits AsyncUpdate
            Public Sub New()
            End Sub

            Public Sub Add(updateDelegate As AsyncDataSetUpdateDelegate)
                MyBase.AddDelegate(updateDelegate)
            End Sub

            Public Sub Remove(updateDelegate As AsyncDataSetUpdateDelegate)
                MyBase.RemoveDelegate(updateDelegate)
            End Sub

            Public Sub Update(ds As DataSet, action As AsyncDataSetUpdateAction)
                If Me.myUpdateList IsNot Nothing Then
                    For Each obj As Object In Me.myUpdateList
                        Dim multicastDelegate As MulticastDelegate = DirectCast(obj, MulticastDelegate)
                        If multicastDelegate Is Nothing OrElse Not (TypeOf multicastDelegate Is AsyncDataSetUpdateDelegate) Then
                            Continue For
                        End If
                        Try
                            Dim asyncDataSetUpdateDelegate As AsyncDataSetUpdateDelegate = DirectCast(multicastDelegate, AsyncDataSetUpdateDelegate)
                            If Not (TypeOf multicastDelegate.Target Is Control) Then
                                asyncDataSetUpdateDelegate(ds, action)
                            Else
                                Dim target As Control = DirectCast(multicastDelegate.Target, Control)
                                If Not target.InvokeRequired Then
                                    asyncDataSetUpdateDelegate(ds, action)
                                Else
                                    Dim asyncDataSetUpdateDelegate1 As New AsyncDataSetUpdateDelegate(AddressOf asyncDataSetUpdateDelegate.Invoke)
                                    Dim objArray As Object() = New Object() {ds, action}
                                    target.Invoke(asyncDataSetUpdateDelegate1, objArray)
                                End If
                            End If
                        Catch
                        End Try
                    Next
                End If
            End Sub
        End Class


    End Class

End Namespace

