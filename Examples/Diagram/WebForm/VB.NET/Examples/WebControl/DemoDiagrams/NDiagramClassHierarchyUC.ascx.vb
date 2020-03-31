Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Reflection

Imports Nevron.Dom
Imports Nevron.Diagram.Filters
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WebForm
Imports Nevron.UI.WebForm.Controls
Imports Nevron.Diagram.Extensions

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''		Summary description for NDiagramClassHierarchyUC.
	''' </summary>
	Public Partial Class NDiagramClassHierarchyUC
		Inherits NDiagramExampleUC
		#Region "Implementation"

		Protected Sub InitFormControls()
			RootTypesDropDownList.DataSource = TYPES
			RootTypesDropDownList.DataMember = "Name"
			RootTypesDropDownList.DataTextField = "Name"
			RootTypesDropDownList.DataBind()
			RootTypesDropDownList.SelectedIndex = 2
		End Sub
		Private Sub RebuildDocument()
			If RootTypesDropDownList.SelectedItem Is Nothing Then
				Return
			End If

			NDrawingView1.Document.BeginInit()
			RecreateDocument(TYPES(RootTypesDropDownList.SelectedIndex))
			NDrawingView1.Document.EndInit()
		End Sub
		Protected Sub RecreateDocument(ByVal type As Type)
			' set up visual formatting
			NDrawingView1.Document.BackgroundStyle.FrameStyle.Visible = False
			NDrawingView1.Document.ActiveLayer.RemoveAllChildren()
			NDrawingView1.Document.BeginInit()

			Dim importer As NClassImporter = New NClassImporter(NDrawingView1.Document)
			importer.ImportInActiveLayer = True
			importer.Import(type)

			NDrawingView1.Document.EndInit()
			NDrawingView1.Document.SizeToContent()
			NDrawingView1.Width = New Unit(NDrawingView1.Document.Bounds.Width, System.Web.UI.WebControls.UnitType.Pixel)
			NDrawingView1.Height = New Unit(NDrawingView1.Document.Bounds.Height, System.Web.UI.WebControls.UnitType.Pixel)
		End Sub

		#End Region

		#Region "Event Handlers"

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not IsPostBack) Then
				InitFormControls()
			End If

			' begin view init
			NDrawingView1.ViewLayout = CanvasLayout.Fit

			If (Not IsPostBack) Then
				RebuildDocument()
			End If

			Dim response As NHtmlImageMapResponse = New NHtmlImageMapResponse()
			NDrawingView1.ServerSettings.BrowserResponseSettings.DefaultResponse = response
			NDrawingView1.ServerSettings.ControlStateSettings.PersistControlState = True
			NDrawingView1.EnableViewState = True
		End Sub
		Protected Sub RootTypesDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			RebuildDocument()
		End Sub

		#End Region

		#Region "Static"

		Private Shared ReadOnly TYPES As Type() = New Type(){ GetType(NLayout), GetType(NPrimitiveShape), GetType(NShapePoint) }

		#End Region
	End Class
End Namespace