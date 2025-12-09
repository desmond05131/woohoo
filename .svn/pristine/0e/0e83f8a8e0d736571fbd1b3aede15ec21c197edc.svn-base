Imports AutoCount.Application
Imports AutoCount.Authentication
Imports AutoCount.MainEntry
Imports AutoCount.PlugIn
Imports AutoCount.Scripting
Imports AutoCount.XtraUtils
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports FreelyCreative.StockItemInquiry.StockInquiryItem
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Reflection
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace StockInquiryItem
    Public Class AutoCountController
        Private _autoCountPlugInModel As AutocountPluginModel

        Public Shared Sub RegisterPlugIns()
            Dim script = ScriptManager.GetOrCreate(UserSession.CurrentUserSession.DBSetting)
            script.RegisterByType("MainForm", GetType(AutoCountController))
        End Sub

        Public Shared ReadOnly Property AllBindings As BindingFlags
            Get
                Return BindingFlags.IgnoreCase Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Static
            End Get
        End Property

        Public Sub OnFormInitialize(e As FormMain.FormInitializeEventArgs)
            Dim info As New PlugInInfo() With {
                .MenuCaption = FreelyPlugIns.ProductName
            }

            _autoCountPlugInModel = New AutocountPluginModel With {
                .FormMain = e.Form,
                .UserSession = AutoCount.Authentication.UserSession.CurrentUserSession,
                .PlugInInfo = info
            }

            _autoCountPlugInModel.BarMenuTools = DirectCast(_autoCountPlugInModel.BarManager.Items("barMenuTools"), DevExpress.XtraBars.BarSubItem)

            FindMenuItemAttribute()
            FindMenuItemInterface()
            InstallPlugInMenu(_autoCountPlugInModel.BarMenuTools)
        End Sub

        Public Sub FindMenuItemAttribute()
            Dim types As Type() = Assembly.GetExecutingAssembly().GetTypes()
            Dim menuList As List(Of AutoCount.PlugIn.MenuItem) = _autoCountPlugInModel.PlugInInfo.MenuItems

            For Each type As Type In types
                Dim customAttributes As Object() = type.GetCustomAttributes(GetType(MenuItemAttribute), False)
                If customAttributes.Length = 0 Then Continue For

                Dim menuItemAttribute As MenuItemAttribute = DirectCast(customAttributes(0), MenuItemAttribute)
                Dim menu As New AutoCount.PlugIn.MenuItem With {
                    .MenuCaption = menuItemAttribute.MenuCaption,
                    .MenuOrder = menuItemAttribute.MenuOrder,
                    .BeginNewGroup = menuItemAttribute.BeginNewGroup,
                    .PlugInInfo = _autoCountPlugInModel.PlugInInfo,
                    .ReferenceType = type
                }

                If String.IsNullOrEmpty(menuItemAttribute.ParentMenuCaption) Then
                    menuList.Add(menu)
                Else
                    Dim parentMenu As AutoCount.PlugIn.MenuItem = Nothing
                    For Each item As AutoCount.PlugIn.MenuItem In menuList
                        If item.IsSubMenu AndAlso item.MenuCaption = menuItemAttribute.ParentMenuCaption Then
                            parentMenu = item
                            Exit For
                        End If
                    Next

                    If parentMenu Is Nothing Then
                        parentMenu = New AutoCount.PlugIn.MenuItem With {
                            .MenuCaption = menuItemAttribute.ParentMenuCaption,
                            .MenuOrder = menuItemAttribute.ParentMenuOrder,
                            .BeginNewGroup = menuItemAttribute.ParentBeginNewGroup
                        }
                        menuList.Add(parentMenu)
                    End If

                    parentMenu.SubItems.Add(menu)
                End If
            Next
        End Sub

        Public Sub FindMenuItemInterface()
            Dim types As Type() = Assembly.GetExecutingAssembly().GetTypes()
            Dim menuList As List(Of AutoCount.PlugIn.MenuItem) = _autoCountPlugInModel.PlugInInfo.MenuItems

            For Each type As Type In types
                If Not GetType(IMenuItem).IsAssignableFrom(type) Then Continue For

                Dim instance As IMenuItem = DirectCast(Activator.CreateInstance(type), IMenuItem)
                Dim menu As New AutoCount.PlugIn.MenuItem With {
                    .MenuCaption = instance.MenuCaption,
                    .MenuOrder = instance.MenuOrder,
                    .BeginNewGroup = instance.BeginNewGroup,
                    .PlugInInfo = _autoCountPlugInModel.PlugInInfo,
                    .ReferenceType = type,
                    .IMenuItem = instance
                }

                If String.IsNullOrEmpty(instance.ParentMenuCaption) Then
                    menuList.Add(menu)
                Else
                    Dim parentMenu As AutoCount.PlugIn.MenuItem = Nothing
                    For Each item As AutoCount.PlugIn.MenuItem In menuList
                        If item.IsSubMenu AndAlso item.MenuCaption = instance.ParentMenuCaption Then
                            parentMenu = item
                            Exit For
                        End If
                    Next

                    If parentMenu Is Nothing Then
                        parentMenu = New AutoCount.PlugIn.MenuItem With {
                            .MenuCaption = instance.ParentMenuCaption,
                            .MenuOrder = instance.ParentMenuOrder,
                            .BeginNewGroup = instance.ParentBeginNewGroup
                        }
                        menuList.Add(parentMenu)
                    End If

                    parentMenu.SubItems.Add(menu)
                End If
            Next
        End Sub

        Public Sub InstallPlugInMenu(referenceMenu As DevExpress.XtraBars.BarSubItem)
            Dim topBar As Bar = Nothing
            For Each bar As Bar In _autoCountPlugInModel.BarManager.Bars
                If bar.DockStyle = BarDockStyle.Top Then
                    topBar = bar
                    Exit For
                End If
            Next

            _autoCountPlugInModel.BarManager.BeginUpdate()
            Dim myPlugInBeforeLink As BarItemLink = topBar.LinksPersistInfo(0).Link
            For Each item As LinkPersistInfo In topBar.LinksPersistInfo
                If item.Item Is referenceMenu Then
                    myPlugInBeforeLink = item.Link
                    Exit For
                End If
            Next

            Dim plugInMenu As New BarSubItem() With {
                .Caption = _autoCountPlugInModel.PlugInInfo.MenuCaption,
                .Tag = _autoCountPlugInModel.PlugInInfo
            }

            topBar.InsertItem(myPlugInBeforeLink, plugInMenu)
            InstallMenu(plugInMenu, _autoCountPlugInModel.PlugInInfo.MenuItems.ToArray())
            _autoCountPlugInModel.BarManager.EndUpdate()
        End Sub

        Public Sub InstallMenu(menu As BarSubItem, mItems As AutoCount.PlugIn.MenuItem())
            Array.Sort(mItems, New MenuItemComparer())

            For Each mItem As AutoCount.PlugIn.MenuItem In mItems
                If mItem.IsSubMenu Then
                    Dim menu1 As New BarSubItem() With {
                        .Caption = mItem.MenuCaption,
                        .Id = menu.Manager.GetNewItemId()
                    }

                    Dim subItems = mItem.SubItems.ToArray()
                    menu.AddItem(menu1).BeginGroup = mItem.BeginNewGroup

                    If menu.Visibility <> BarItemVisibility.Always Then
                        menu.Visibility = BarItemVisibility.Always
                    End If

                    InstallMenu(menu1, subItems)
                Else
                    Dim barButtonItem As New BarButtonItem() With {
                        .Caption = mItem.MenuCaption,
                        .Id = menu.Manager.GetNewItemId(),
                        .Tag = mItem
                    }

                    If mItem.IMenuItem Is Nothing Then
                        AddHandler barButtonItem.ItemClick, AddressOf PlugInsMenu_ItemClick
                    Else
                        AddHandler barButtonItem.ItemClick, AddressOf PlugInsMenuInterfaceType_ItemClick
                    End If

                    menu.AddItem(barButtonItem).BeginGroup = mItem.BeginNewGroup
                    If menu.Visibility <> BarItemVisibility.Always Then
                        menu.Visibility = BarItemVisibility.Always
                    End If
                End If
            Next
        End Sub

        Public Sub PlugInsMenuInterfaceType_ItemClick(sender As Object, e As ItemClickEventArgs)
            If e.Item.Tag Is Nothing OrElse Not TypeOf e.Item.Tag Is AutoCount.PlugIn.MenuItem Then Return

            Dim tag As AutoCount.PlugIn.MenuItem = DirectCast(e.Item.Tag, AutoCount.PlugIn.MenuItem)

            If tag Is Nothing OrElse tag.IMenuItem Is Nothing OrElse
               (Not String.IsNullOrEmpty(tag.IMenuItem.OpenAccessRight) AndAlso
               Not AccessRightUI.GetOrCreate(_autoCountPlugInModel.UserSession).IsAccessible(tag.IMenuItem.OpenAccessRight, _autoCountPlugInModel.FormMain)) Then Return

            tag.IMenuItem.MenuItemClick(_autoCountPlugInModel.MainFormHelper, _autoCountPlugInModel.UserSession)
        End Sub

        Public Sub PlugInsMenu_ItemClick(sender As Object, e As ItemClickEventArgs)
            InvokePlugInsMenuItem(e)
        End Sub

        Public Sub InvokePlugInsMenuItem(e As ItemClickEventArgs)
            Dim referenceType = DirectCast(e.Item.Tag, AutoCount.PlugIn.MenuItem).ReferenceType
            Dim menuItemAttribute As MenuItemAttribute = Nothing

            Dim customAttributes As Object() = referenceType.GetCustomAttributes(GetType(MenuItemAttribute), False)

            If customAttributes.Length <> 0 Then
                menuItemAttribute = DirectCast(customAttributes(0), MenuItemAttribute)

                If Not String.IsNullOrEmpty(menuItemAttribute.OpenAccessRight) AndAlso
                   Not AccessRightUI.GetOrCreate(_autoCountPlugInModel.UserSession).IsAccessible(menuItemAttribute.OpenAccessRight) Then Return

                Dim constructor As ConstructorInfo = referenceType.GetConstructor(New Type() {_autoCountPlugInModel.UserSession.GetType()})
                If constructor Is Nothing Then
                    XtraMessageBox.Show("Cannot find a public constructor which accepts a single parameter UserSession object",
                                        "Autosoft Solution Sdn Bhd", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Else
                    Dim type As Type = referenceType
                    While type IsNot Nothing AndAlso Not type.Equals(GetType(Form))
                        type = type.BaseType
                    End While

                    If type Is Nothing Then
                        constructor.Invoke(New Object() {_autoCountPlugInModel.UserSession})
                    ElseIf menuItemAttribute?.ShowAsDialog = True Then
                        Dim form As Form = DirectCast(constructor.Invoke(New Object() {_autoCountPlugInModel.UserSession}), Form)
                        If form.Disposing OrElse form.IsDisposed Then Return
                        form.ShowDialog()
                    Else
                        LaunchAppForm(referenceType.AssemblyQualifiedName)
                    End If
                End If
            End If
        End Sub

        Public Sub LaunchAppForm(className As String)
            Dim threadForm As New ThreadForm(
                className,
                New Type() {_autoCountPlugInModel.UserSession.GetType()},
                New Object() {_autoCountPlugInModel.UserSession},
                New ThreadForm.InitForm(AddressOf InitForm)
            )
            threadForm.Show()
        End Sub

        Public Sub LaunchAppForm(userSession As UserSession, className As String)
            Dim threadForm As New ThreadForm(
                className,
                New Type() {userSession.GetType()},
                New Object() {userSession},
                New ThreadForm.InitForm(AddressOf InitForm)
            )
            threadForm.Show()
        End Sub

        Private Sub InitForm(form As Form)
            Dim singleInstance As Boolean = False
            Dim mergeMainMenu As Boolean = True
            Dim windowState As FormWindowState = FormWindowState.Maximized

            If _autoCountPlugInModel.BarManager IsNot Nothing Then
                Dim t As Type = form.GetType()
                Dim attrs As Object() = t.GetCustomAttributes(GetType(ThreadFormAttribute), False)

                If attrs.Length = 0 Then
                    Dim attributes As Object() = t.GetCustomAttributes(GetType(SingleInstanceThreadFormAttribute), False)
                    If attributes.Length <> 0 Then
                        Dim singleInstanceAttribute As SingleInstanceThreadFormAttribute = DirectCast(attributes(0), SingleInstanceThreadFormAttribute)
                        windowState = singleInstanceAttribute.WindowState
                        mergeMainMenu = singleInstanceAttribute.MergeMainMenu
                        singleInstance = True
                    End If
                Else
                    Dim attr As ThreadFormAttribute = DirectCast(attrs(0), ThreadFormAttribute)
                    windowState = attr.WindowState
                    mergeMainMenu = attr.MergeMainMenu
                    singleInstance = attr.SingleInstance
                End If
            End If

            If mergeMainMenu Then
                XtraBars.MergeMainMenu(form, _autoCountPlugInModel.BarManager, _autoCountPlugInModel.FormMain.Text)
            ElseIf Not singleInstance Then
                XtraBars.AddWindowMenu(form)
                form.Text = String.Concat(form.Text, " - ", _autoCountPlugInModel.FormMain.Text)
            End If

            form.WindowState = windowState
        End Sub
    End Class
End Namespace

