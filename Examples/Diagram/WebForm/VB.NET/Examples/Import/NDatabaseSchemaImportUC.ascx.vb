Imports Microsoft.VisualBasic
Imports System.Web
Imports System.Web.UI.WebControls

Imports Nevron.Diagram
Imports Nevron.Diagram.Extensions
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	''' Summary description for NDatabaseSchemaImportUC.
	''' </summary>
	Public Partial Class NDatabaseSchemaImportUC
		Inherits NDiagramExampleUC
		#Region "Implementation"

		Private Sub InitDocument()
			Dim document As NDrawingDocument = NDrawingView1.Document
			document.BackgroundStyle.FrameStyle.Visible = False

			Dim databasePath As String = HttpContext.Current.Server.MapPath("..\App_Data\Northwind.xml")

			Dim importer As NDatabaseImporter = New NDatabaseImporter(document)
			importer.ImportInActiveLayer = True
			importer.Import(databasePath)

			NDrawingView1.Document.SizeToContent()
			NDrawingView1.Width = New Unit(NDrawingView1.Document.Bounds.Width, System.Web.UI.WebControls.UnitType.Pixel)
			NDrawingView1.Height = New Unit(NDrawingView1.Document.Bounds.Height, System.Web.UI.WebControls.UnitType.Pixel)
		End Sub

		#End Region

		#Region "Event Handlers"

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			' begin view init
			MyBase.DefaultGridOrigin = New NPointF(30, 30)
			MyBase.DefaultGridCellSize = New NSizeF(100, 50)
			MyBase.DefaultGridSpacing = New NSizeF(50, 40)

			' view init
			NDrawingView1.ViewLayout = CanvasLayout.Normal

			' init document
			NDrawingView1.Document.BeginInit()
			InitDocument()
			NDrawingView1.Document.EndInit()
		End Sub

		#End Region
	End Class
End Namespace