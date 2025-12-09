Imports AutoCount.Authentication
Imports AutoCount.MainEntry
Imports AutoCount.PlugIn
Imports DevExpress.XtraBars
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace StockInquiryItem
    Friend Class AutocountPluginModel
        Public Property PlugInInfo As PlugInInfo
        Public Property FormMain As Form
        Public Property UserSession As UserSession
        Public Property BarMenuTools As BarSubItem

        Public ReadOnly Property BarManager As BarManager
            Get
                Dim field = FormMain.GetType().GetField("myBarManager", AutoCountController.AllBindings)
                Return TryCast(field?.GetValue(FormMain), BarManager)
            End Get
        End Property

        Public ReadOnly Property MainFormHelper As MainFormHelper
            Get
                Dim field = FormMain.GetType().GetField("myMainFormHelper", AutoCountController.AllBindings)
                Return DirectCast(field?.GetValue(FormMain), MainFormHelper)
            End Get
        End Property
    End Class
End Namespace

