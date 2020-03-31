Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NLegendCustomItemsUC
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.SuspendLayout()
			' 
			' NLegendCustomItemsUC
			' 
			Me.Name = "NLegendCustomItemsUC"
			Me.Size = New System.Drawing.Size(180, 680)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' confgigure chart
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Legend Custom Items")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			header.DockMode = PanelDockMode.Top
			header.Margins = New NMarginsL(0, 10, 0, 10)
			nChartControl1.Panels.Add(header)

'INSTANT VB NOTE: The variable container was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim container_Renamed As New NDockPanel()
			container_Renamed.DockMode = PanelDockMode.Fill
			container_Renamed.Margins = New NMarginsL(10, 10, 10, 10)
			container_Renamed.PositionChildPanelsInContentBounds = True
			nChartControl1.Panels.Add(container_Renamed)

			' configure the legend
			CreateCustomLegend1(container_Renamed)
			CreateCustomLegend2(container_Renamed)
			CreateCustomLegend3(container_Renamed)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Sub CreateCustomLegend1(ByVal container As NDockPanel)
			Dim markShapesLegend As NLegend = CreateLegend(container, "Mark Shapes")

			Dim markShapes As Array = System.Enum.GetValues(GetType(LegendMarkShape))
			Dim palette As New NChartPalette(ChartPredefinedPalette.Fresh)

			For i As Integer = 0 To markShapes.Length - 1
				Dim licd As New NLegendItemCellData()
				Dim markShape As LegendMarkShape = DirectCast(markShapes.GetValue(i), LegendMarkShape)

				licd.Text = markShape.ToString()
				licd.MarkShape = markShape
				licd.MarkFillStyle = New NColorFillStyle(palette.SeriesColors(i Mod palette.SeriesColors.Count))

				markShapesLegend.Data.Items.Add(licd)
			Next i

		End Sub

		Private Sub CreateCustomLegend2(ByVal container As NDockPanel)
			Dim markShapesNoStroke As NLegend = CreateLegend(container, "Mark Shapes (No stroke)")

			Dim markShapes As Array = System.Enum.GetValues(GetType(LegendMarkShape))
			Dim palette As New NChartPalette(ChartPredefinedPalette.Fresh)

			For i As Integer = 0 To markShapes.Length - 1
				Dim licd As New NLegendItemCellData()
				Dim markShape As LegendMarkShape = DirectCast(markShapes.GetValue(i), LegendMarkShape)

				licd.Text = markShape.ToString()
				licd.MarkShape = markShape
				licd.MarkFillStyle = New NColorFillStyle(palette.SeriesColors(i Mod palette.SeriesColors.Count))
				licd.MarkBorderStyle.Width = New NLength(0)
				licd.MarkLineStyle.Width = New NLength(0)

				markShapesNoStroke.Data.Items.Add(licd)
			Next i

		End Sub

		Private Sub CreateCustomLegend3(ByVal container As NDockPanel)
			Dim markShapesBackground As NLegend = CreateLegend(container, "Mark Shapes (Margins, Background)")

			Dim markShapes As Array = System.Enum.GetValues(GetType(LegendMarkShape))
			Dim palette As New NChartPalette(ChartPredefinedPalette.Fresh)

			For i As Integer = 0 To markShapes.Length - 1
				Dim licd As New NLegendItemCellData()
				Dim markShape As LegendMarkShape = DirectCast(markShapes.GetValue(i), LegendMarkShape)

				licd.Text = markShape.ToString()
				licd.TextStyle.FillStyle = New NColorFillStyle(Color.White)
				licd.TextStyle.FontStyle.EmSize = New NLength(10 + i)
				licd.MarkShape = markShape
				licd.MarkFillStyle = New NColorFillStyle(Color.White)
				licd.MarkBorderStyle.Width = New NLength(0)
				licd.MarkLineStyle.Width = New NLength(0)
				licd.BackgroundFillStyle = New NColorFillStyle(palette.SeriesColors(i Mod palette.SeriesColors.Count))

				markShapesBackground.Data.Items.Add(licd)
			Next i

			' increase teh margins around each cell
			markShapesBackground.Data.CellMargins = New NMarginsL(10, 10, 10, 10)
		End Sub

		Private Function CreateLegend(ByVal container As NDockPanel, ByVal title As String) As NLegend
			' configure the legend
			Dim legend As New NLegend()
			legend.Header.Text = title
			legend.Mode = LegendMode.Manual
			legend.Data.ExpandMode = LegendExpandMode.HorzWrap
			legend.DockMode = PanelDockMode.Top
			legend.Margins = New NMarginsL(20, 20, 20, 20)
			container.ChildPanels.Add(legend)

			Return legend
		End Function

	End Class
End Namespace
