
Namespace Freely.Layout


    Public Class FreelyOutLayoutPerform

        Public Property UDFTable As DataTable
        Dim _Document As Object
        Dim _Form As Object
        Public ReadOnly Property Document As Object
            Get
                Return _Document
            End Get
        End Property
        Public ReadOnly Property Form As Object
            Get
                Return _Form
            End Get
        End Property
        Public Sub New(ByVal ADocument As Object, ByVal AForm As Object)
            _Document = ADocument
            _Form = AForm
        End Sub
        Public Sub Process(ByVal ALayoutControl As DevExpress.XtraLayout.LayoutControl)
            Dim bFound As Boolean = False
            For i As Integer = 0 To ALayoutControl.Items.Count - 1
                Console.WriteLine(ALayoutControl.Items(i).Name)
                If ALayoutControl.Items(i).Name = "tabMaster" Then
                    bFound = True
                    Exit For

                End If

            Next

            If Form Is Nothing Then Return
            If Document Is Nothing Then Return
            If bFound Then Return

            Dim tabbedGroup As DevExpress.XtraLayout.TabbedControlGroup = ALayoutControl.Root.AddTabbedGroup()
            tabbedGroup.Name = "tabMaster"

            ' Add the Photo group as a tab.
            Dim tabPageDetail As DevExpress.XtraLayout.LayoutControlGroup = TryCast(tabbedGroup.AddTabPage(), DevExpress.XtraLayout.LayoutControlGroup)
            tabPageDetail.Name = "PageDetail"
            tabPageDetail.Text = "Detail"

            Dim tabPageMoreHeader As DevExpress.XtraLayout.LayoutControlGroup = TryCast(tabbedGroup.AddTabPage(), DevExpress.XtraLayout.LayoutControlGroup)
            tabPageMoreHeader.Name = "PageMoreHeader"
            tabPageMoreHeader.Text = "More Header"

            Dim tabDocInformation As DevExpress.XtraLayout.LayoutControlGroup = tabPageMoreHeader.AddGroup()
            tabDocInformation.Name = "Document Information"

            Dim tabCusInformation As DevExpress.XtraLayout.LayoutControlGroup = tabPageMoreHeader.AddGroup()
            tabCusInformation.Name = "Customer Information"



            Dim tabPageExternal As DevExpress.XtraLayout.LayoutControlGroup = TryCast(tabbedGroup.AddTabPage(), DevExpress.XtraLayout.LayoutControlGroup)
            tabPageExternal.Name = "PageExternalLink"
            tabPageExternal.Text = "External Link"

            Dim tabPageNotes As DevExpress.XtraLayout.LayoutControlGroup = TryCast(tabbedGroup.AddTabPage(), DevExpress.XtraLayout.LayoutControlGroup)
            tabPageNotes.Name = "PageNotes"
            tabPageNotes.Text = "Notes"

            Dim tabPageUDF As DevExpress.XtraLayout.LayoutControlGroup = Nothing
            If Me.UDFTable.Rows.Count > 0 Then
                tabPageUDF = TryCast(tabbedGroup.AddTabPage(), DevExpress.XtraLayout.LayoutControlGroup)
                tabPageUDF.Name = "PageUDF"
                tabPageUDF.Text = "User Define Field(s)"
            End If


            tabbedGroup.SelectedTabPageIndex = 0
            Dim lytGrid As DevExpress.XtraLayout.LayoutControlItem = Nothing

            Dim lytExternalLink As DevExpress.XtraLayout.LayoutControlItem = Nothing
            Dim lytNote As DevExpress.XtraLayout.LayoutControlItem = Nothing


            Try
                ALayoutControl.BeginUpdate()

                Dim dtMaster As New DataTable("FreelyLayoutControl")
                dtMaster.Columns.Add(New DataColumn("ControlName"))
                dtMaster.Columns.Add(New DataColumn("Seq", GetType(Integer)))
                dtMaster.Columns.Add(New DataColumn("IsHidden", GetType(String)))
                dtMaster.Columns.Add(New DataColumn("LayoutSeq", GetType(Integer)))
                dtMaster.Columns.Add(New DataColumn("ParentName", GetType(String)))
                dtMaster.Columns.Add(New DataColumn("Position", GetType(String)))
                dtMaster.Columns.Add(New DataColumn("NextControlName", GetType(String)))

                '
                For i As Integer = 0 To ALayoutControl.Items.Count - 1
                    Dim drNew As DataRow = dtMaster.NewRow
                    drNew.Item("ControlName") = ALayoutControl.Items(i).Name
                    drNew.Item("Seq") = 0
                    drNew.Item("IsHidden") = IIf(ALayoutControl.Items(i).IsHidden, "Y", "N")
                    drNew.Item("LayoutSeq") = i

                    'tabDocInformation
                    '----------- 
                    '‘Start
                    If ALayoutControl.Items(i).Name = "lytDescription" Then
                        drNew.Item("Seq") = 1
                        drNew.Item("ParentName") = "tabDocInformation"
                    End If
                    If ALayoutControl.Items(i).Name = "lytRef" Then
                        drNew.Item("Seq") = 2
                        drNew.Item("ParentName") = "tabDocInformation"
                    End If
                    If ALayoutControl.Items(i).Name = "lytRefDocNo" Then
                        drNew.Item("Seq") = 3
                        drNew.Item("ParentName") = "tabDocInformation"
                        drNew.Item("Position") = "Right"
                        drNew.Item("NextControlName") = "lytRef"
                    End If
                    If ALayoutControl.Items(i).Name = "lytRemark1" Then
                        drNew.Item("Seq") = 4
                        drNew.Item("ParentName") = "tabDocInformation"
                    End If
                    If ALayoutControl.Items(i).Name = "lytRemark2" Then
                        drNew.Item("Seq") = 5
                        drNew.Item("ParentName") = "tabDocInformation"
                    End If
                    If ALayoutControl.Items(i).Name = "lytRemark3" Then
                        drNew.Item("Seq") = 6
                        drNew.Item("ParentName") = "tabDocInformation"
                        drNew.Item("Position") = "Right"
                        drNew.Item("NextControlName") = "lytRemark1"
                    End If
                    If ALayoutControl.Items(i).Name = "lytRemark4" Then
                        drNew.Item("Seq") = 7
                        drNew.Item("ParentName") = "tabDocInformation"
                        drNew.Item("Position") = "Right"
                        drNew.Item("NextControlName") = "lytRemark2"
                    End If
                    'end


                    If ALayoutControl.Items(i).Name = "lytAttention" Then
                        drNew.Item("Seq") = 1
                        drNew.Item("ParentName") = "tabCusInformation"
                    End If


                    If ALayoutControl.Items(i).Name = "lytPhone" Then
                        drNew.Item("Seq") = 2
                        drNew.Item("ParentName") = "tabCusInformation"
                        drNew.Item("Position") = "Right"
                        drNew.Item("NextControlName") = "lytAttention"
                    End If
                    If ALayoutControl.Items(i).Name = "lytFax" Then
                        drNew.Item("Seq") = 3
                        drNew.Item("ParentName") = "tabCusInformation"
                        drNew.Item("Position") = "Right"
                        drNew.Item("NextControlName") = "lytAttention"
                    End If

                    If ALayoutControl.Items(i).Name = "lytDeliverAddr1" Then
                        drNew.Item("Seq") = 1
                        drNew.Item("ParentName") = "tabDelInformation"
                    End If
                    If ALayoutControl.Items(i).Name = "lytDeliverAddr2" Then
                        drNew.Item("Seq") = 2
                        drNew.Item("ParentName") = "tabDelInformation"
                    End If
                    If ALayoutControl.Items(i).Name = "lytDeliverAddr3" Then
                        drNew.Item("Seq") = 3
                        drNew.Item("ParentName") = "tabDelInformation"
                    End If
                    If ALayoutControl.Items(i).Name = "lytDeliverAddr4" Then
                        drNew.Item("Seq") = 4
                        drNew.Item("ParentName") = "tabDelInformation"
                    End If
                    If ALayoutControl.Items(i).Name = "lytDeliverContact" Then
                        drNew.Item("Seq") = 4
                        drNew.Item("ParentName") = "tabDelInformation"
                        drNew.Item("Position") = "Right"
                        drNew.Item("NextControlName") = "lytDeliverAddr1"
                    End If

                    If ALayoutControl.Items(i).Name = "lytDeliverPhone" Then
                        drNew.Item("Seq") = 5
                        drNew.Item("ParentName") = "tabDelInformation"
                        drNew.Item("Position") = "Right"
                        drNew.Item("NextControlName") = "lytDeliverAddr2"
                    End If

                    If ALayoutControl.Items(i).Name = "lytDeliverFax" Then
                        drNew.Item("Seq") = 6
                        drNew.Item("ParentName") = "tabDelInformation"
                        drNew.Item("Position") = "Right"
                        drNew.Item("NextControlName") = "lytDeliverAddr3"
                    End If


                    If ALayoutControl.Items(i).Name = "lytSalesExemptionNo" Then
                        drNew.Item("Seq") = 1
                        drNew.Item("ParentName") = "tabSalesTaxInformation"

                    End If

                    If ALayoutControl.Items(i).Name = "lytSalesExemptionExpiryDate" Then
                        drNew.Item("Seq") = 2
                        drNew.Item("ParentName") = "tabSalesTaxInformation"
                        drNew.Item("Position") = "Right"
                        drNew.Item("NextControlName") = "lytSalesExemptionNo"
                    End If
                    dtMaster.Rows.Add(drNew)
                Next
                dtMaster.AcceptChanges()

                Dim dvView As New DataView(dtMaster, "1=1", "ParentName,Seq", DataViewRowState.CurrentRows)
                Try
                    For Each drMaster As DataRow In dvView.ToTable.Rows
                        Dim sControlName As String = drMaster.Item("ControlName").ToString
                        Dim sParentName As String = drMaster.Item("ParentName").ToString
                        Dim sPosition As String = drMaster.Item("Position").ToString
                        Dim sNextControlName As String = drMaster.Item("NextControlName").ToString
                        Dim objNextControl As DevExpress.XtraLayout.LayoutControlItem = Nothing
                        If sNextControlName.Length > 0 Then
                            For i As Integer = 0 To ALayoutControl.Items.Count - 1
                                If ALayoutControl.Items(i).Name = sNextControlName.ToString Then
                                    objNextControl = ALayoutControl.Items(i)
                                    Exit For
                                End If
                            Next
                        End If

                        For i As Integer = 0 To ALayoutControl.Items.Count - 1
                            If ALayoutControl.Items(i).Name = drMaster.Item("ControlName").ToString Then

                                Dim objCurrent As DevExpress.XtraLayout.LayoutControlItem = Nothing
                                If TypeOf ALayoutControl.Items(i) Is DevExpress.XtraLayout.LayoutControlItem Then
                                    objCurrent = ALayoutControl.Items(i)
                                End If

                                Dim objParent As Object = Nothing
                                Dim tabDelInformation As DevExpress.XtraLayout.LayoutControlGroup = Nothing
                                Dim tabSalesTaxInformation As DevExpress.XtraLayout.LayoutControlGroup = Nothing
                                If sParentName = "tabDocInformation" Then
                                    objParent = tabDocInformation
                                ElseIf sParentName = "tabCusInformation" Then
                                    objParent = tabCusInformation
                                ElseIf sParentName = "tabDelInformation" Then

                                    Dim btabDelInformation As Boolean = False
                                    For j As Integer = 0 To tabCusInformation.Items.Count - 1
                                        If tabCusInformation.Items(j).Name = "tabDelInformation" Then
                                            btabDelInformation = True
                                            tabDelInformation = tabCusInformation.Items(j)
                                        End If
                                    Next
                                    If Not btabDelInformation Then
                                        tabDelInformation = tabCusInformation.AddGroup()
                                        tabDelInformation.Name = "tabDelInformation"
                                        tabDelInformation.Text = "Delivery Information"
                                    End If

                                    objParent = tabDelInformation

                                ElseIf sParentName = "tabSalesTaxInformation" Then

                                    Dim btabDelInformation As Boolean = False
                                    For j As Integer = 0 To tabCusInformation.Items.Count - 1
                                        If tabCusInformation.Items(j).Name = "tabSalesTaxInformation" Then
                                            btabDelInformation = True
                                            tabDelInformation = tabCusInformation.Items(j)
                                        End If
                                    Next
                                    If Not btabDelInformation Then
                                        tabSalesTaxInformation = tabCusInformation.AddGroup()
                                        tabSalesTaxInformation.Name = "tabSalesTaxInformation"
                                        tabSalesTaxInformation.Text = "Sales Tax Exemption"
                                    End If

                                    objParent = tabSalesTaxInformation
                                End If

                                If objParent Is Nothing Then Exit For

                                If objCurrent.IsHidden Then objCurrent.RestoreFromCustomization(objParent)
                                If objNextControl IsNot Nothing Then
                                    If sPosition = "Right" Then
                                        objCurrent.Move(objNextControl, DevExpress.XtraLayout.Utils.InsertType.Right, DevExpress.XtraLayout.Utils.MoveType.Inside)
                                    End If
                                End If
                                Exit For
                            End If
                        Next
                    Next
                Catch ex As Exception
                    Throw ex
                End Try

                If Me.UDFTable.Rows.Count > 0 Then
                    For Each drUDFTable As DataRow In Me.UDFTable.Select("1=1", "Seq")
                        Dim sFieldName As String = drUDFTable.Item("FieldName").ToString
                        For i As Integer = 0 To ALayoutControl.Items.Count - 1
                            If ALayoutControl.Items(i).Name.ToUpper = String.Format("lyt_UDF_{0}", sFieldName).ToUpper Then
                                If ALayoutControl.Items(i).IsHidden Then
                                    ALayoutControl.Items(i).RestoreFromCustomization(tabPageUDF)
                                Else
                                    ALayoutControl.Items(i).Parent = tabPageUDF
                                End If

                            End If
                        Next
                    Next
                End If

                For i As Integer = 0 To ALayoutControl.Items.Count - 1
                    If ALayoutControl.Items(i).Name = "lytGrid" Then
                        lytGrid = ALayoutControl.Items(i)
                        lytGrid.ControlAlignment = ContentAlignment.MiddleCenter
                    ElseIf ALayoutControl.Items(i).Name = "lytExternalLink" Then
                        lytExternalLink = ALayoutControl.Items(i)
                        If lytExternalLink.IsHidden Then lytExternalLink.RestoreFromCustomization(tabPageExternal)

                    ElseIf ALayoutControl.Items(i).Name = "lytNote" Then
                        lytNote = ALayoutControl.Items(i)
                        If lytNote.IsHidden Then lytNote.RestoreFromCustomization(tabPageNotes)
                    End If '
                Next

                Dim AFreelyAdd As New Controls.FreelyButtonPanel
                AFreelyAdd.RibbonImage = Form.Ribbon.Images
                AFreelyAdd.BunddleDocument = Document
                AFreelyAdd.BunddleForm = Form
                AFreelyAdd.Text = "+"

                Dim lyButtonAdd As New DevExpress.XtraLayout.LayoutControlItem()
                lyButtonAdd.Name = "FreelyButtonPanel"
                lyButtonAdd.Parent = tabPageDetail
                lyButtonAdd.Control = AFreelyAdd
                lyButtonAdd.Text = "Freely Add Button"
                lyButtonAdd.TextVisible = False
                lyButtonAdd.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom


                Dim newSize As Size = New Size(350, 45)
                lyButtonAdd.MaxSize = newSize
                lyButtonAdd.MinSize = newSize
                AddHandler AFreelyAdd.OnButtonClick, AddressOf onFreelyButtonClicked
                lytGrid.Parent = tabPageDetail

            Catch ex As Exception
                Throw ex
            Finally
                ALayoutControl.EndUpdate()
            End Try
        End Sub
        Private Sub onFreelyButtonClicked(ByVal sender As Object)

        End Sub

    End Class
End Namespace