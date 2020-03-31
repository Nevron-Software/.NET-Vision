Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.GraphicsCore
Imports Nevron.Diagram.Visio
Imports Nevron.Dom
Imports Nevron.Diagram.Filters
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NVisioImportUC.
	''' </summary>
	Public Partial Class NVisioImportUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim imageMapResponse As NHtmlImageMapResponse = New NHtmlImageMapResponse()
			NDrawingView1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageMapResponse

			' init document
			NDrawingView1.Document.BeginInit()
			InitDocument()
			NDrawingView1.Document.EndInit()

			' size view control to content
			NDrawingView1.SizeToContent()
		End Sub
		Protected Sub InitDocument()
			Dim document As NDrawingDocument = NDrawingView1.Document

			' Import the Visio stencil
			Dim libDocument As NLibraryDocument = New NLibraryDocument()
			Dim importer As NVisioImporter = New NVisioImporter(libDocument)
			importer.Import(Server.MapPath("~\Examples\Import\Computers.vsx"))

			' Set drawing preferences
			document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
			document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
			document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
			document.BackgroundStyle.FrameStyle.Visible = False

			' Determine the shape size
			Dim maxOrdinal As Integer = 0
			Dim scale As Integer = 1
			Select Case shapeSizeDropDownList.SelectedValue
				Case "Small"
					scale = 1
					maxOrdinal = 5

				Case "Medium"
					scale = 2
					maxOrdinal = 3

				Case "Large"
					scale = 4
					maxOrdinal = 1

				Case Else
					Throw New NotImplementedException(shapeSizeDropDownList.SelectedValue)
			End Select

			' Determine the shapes size and layout options
			Dim masters As NNodeList = libDocument.Children(NFilters.TypeNMaster)
			Dim i As Integer = 0
			Dim count As Integer = masters.Count
			Do While i < count
				Dim master As NMaster = CType(masters(i), NMaster)
				Dim shapes As NNodeList = master.CreateInstance(document, New NPointF(0, 0))

				Dim shape As NShape = CType(shapes(0), NShape)
				shape.Width *= scale
				shape.Height *= scale
				NStyle.SetInteractivityStyle(shape, New NInteractivityStyle(master.Name))
				i += 1
			Loop

			' Layout the shapes in the active layer using a table layout
			Dim layout As NTableLayout = New NTableLayout()

			layout.Direction = LayoutDirection.LeftToRight
			layout.ConstrainMode = CellConstrainMode.Ordinal
			layout.MaxOrdinal = maxOrdinal
			layout.VerticalSpacing = 20
			layout.HorizontalSpacing = 20
			layout.HorizontalContentPlacement = ContentPlacement.Center
			layout.VerticalContentPlacement = ContentPlacement.Center

			layout.Layout(document.ActiveLayer.Children(Nothing), New NDrawingLayoutContext(document))

			' Resize document to fit all shapes
			document.SizeToContent()
		End Sub
	End Class
End Namespace
