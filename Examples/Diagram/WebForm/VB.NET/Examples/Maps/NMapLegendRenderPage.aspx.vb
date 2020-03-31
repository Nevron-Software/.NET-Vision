Imports Microsoft.VisualBasic
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.Maps
Imports Nevron.Diagram.WebForm
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	''' Summary description for NMapLegendRenderPage.
	''' </summary>
	Public Partial Class NMapLegendRenderPage
		Inherits NDrawingViewHostPage
		Public Sub New()
			Me.DrawingView = New NDrawingView()
			Me.DrawingView.ViewLayout = CanvasLayout.Stretch

			Dim document As NDrawingDocument = Me.DrawingView.Document

			' init document
			document.BeginInit()
			CreateScene(document)
			document.EndInit()

			Me.DrawingView.SizeToContent()
		End Sub

		Private Sub CreateScene(ByVal document As NDrawingDocument)
			document.BackgroundStyle.FrameStyle.Visible = False
			document.BackgroundStyle.FillStyle = New NColorFillStyle(BackgroundColor)

			If Not MapLegend Is Nothing Then
				Dim tableShape As NTableShape = MapLegend.Create(document.ActiveLayer)
				Dim colorColumn As NTableColumn = CType(tableShape.Columns.GetChildAt(0), NTableColumn)
				colorColumn.SizeMode = TableColumnSizeMode.Fixed
				colorColumn.Width = 24

				Dim textColumn As NTableColumn = CType(tableShape.Columns.GetChildAt(1), NTableColumn)
				textColumn.SizeMode = TableColumnSizeMode.Fixed
				textColumn.Width = 180
			End If
		End Sub

		Public Shared MapLegend As NMapLegend = Nothing
		Public Shared BackgroundColor As Color = Color.FromArgb(&HF4, &HF2, &HF4)
	End Class
End Namespace