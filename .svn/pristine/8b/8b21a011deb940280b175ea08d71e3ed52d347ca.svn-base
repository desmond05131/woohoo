Namespace Freely.Application
    Public Class FreelyApplication
        ''' <summary>
        ''' This Function Is Group The Data in The DataTable Logic like SQL Command [GROUP]
        ''' </summary>
        ''' <param name="AGroupCol">Group By Column</param>
        ''' <param name="AColumn">Column As</param>
        ''' <param name="ASourceTable">From Data Table</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GroupBy(ByVal AGroupCol As String(), ByVal AColumn As String, ByVal ASourceTable As DataTable) As DataTable
            Dim dv As New DataView(ASourceTable)
            Dim dtGroup As DataTable = dv.ToTable(True, AGroupCol)

            dtGroup.Columns.Add("Count", GetType(Integer))
            For Each dr As DataRow In dtGroup.Rows
                Dim sCompute As String = String.Empty
                For Each s As String In AGroupCol
                    sCompute = sCompute & String.Format(" {0} = '{1}' AND", s, dr(s))
                Next
                If sCompute.Length > 0 Then
                    sCompute = sCompute.Substring(0, sCompute.Length - 3)
                End If
                dr("Count") = ASourceTable.Compute("Count(" & AColumn & ")", sCompute)
            Next
            Return dtGroup

        End Function

        ''' <summary>
        ''' This is A Function To Find All The Control in The Control and List All The Name.
        ''' </summary>
        ''' <param name="AControl">Window Control Type</param>
        ''' <param name="bWriteControlName"> Need To Write Control Name?</param>
        ''' <remarks>This Function Created By Lai</remarks>
        Public Shared Sub FindControl(ByVal AControl As Control,
                                      Optional ByVal bWriteControlName As Boolean = True,
                                      Optional ByVal bWriteObjectType As Boolean = False, Optional ByVal bShowHints As Boolean = False)

            For Each tempControl In AControl.Controls
                If tempControl.Controls.Count > 0 Then
                    FindControl(tempControl, bWriteControlName, bWriteObjectType)
                End If
                If bShowHints Then
                    If TypeOf tempControl Is DevExpress.XtraEditors.LabelControl Then TryCast(tempControl, DevExpress.XtraEditors.LabelControl).ToolTip = String.Format("Control Name : [{0}] ", tempControl.Name)
                    If TypeOf tempControl Is DevExpress.XtraEditors.SimpleButton Then TryCast(tempControl, DevExpress.XtraEditors.SimpleButton).ToolTip = String.Format("Control Name : [{0}] ", tempControl.Name)
                    If TypeOf tempControl Is DevExpress.XtraEditors.CheckEdit Then TryCast(tempControl, DevExpress.XtraEditors.CheckEdit).ToolTip = String.Format("Control Name : [{0}] ", tempControl.Name)

                End If
                Dim sWrite As String = String.Empty
                If bWriteControlName Then sWrite = String.Format("Control Name : [{0}] ", tempControl.Name)
                If bWriteObjectType Then sWrite = sWrite & String.Format(" , Object Type : [{0}] ", tempControl.ToString)

                Console.WriteLine(sWrite)
            Next
        End Sub

    End Class
End Namespace
