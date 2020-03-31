Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NAxisModelCrossingUC
		Inherits NExampleUC

		Private m_Chart As NChart

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithPercents(LengthBottomAxisDropDownList, 10)
				WebExamplesUtilities.FillComboWithPercents(LengthLeftAxisDropDownList, 10)
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Axis Model Crossing <br/> <font size = '9pt'>Demonstrates how to use the model cross anchor</font>")
			header.TextStyle.TextFormat = TextFormat.XML
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(7, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.Location = New NPointL(New NLength(7, NRelativeUnit.ParentPercentage), New NLength(18, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(86, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

			' configure scales
			Dim yScaleConfigurator As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim yStripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(40, Color.LightGray)), Nothing, True, 0, 0, 1, 1)
			yStripStyle.SetShowAtWall(ChartWallType.Back, True)
			yStripStyle.Interlaced = True
			yScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			yScaleConfigurator.StripStyles.Add(yStripStyle)

			Dim xScaleConfigurator As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			Dim xStripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(40, Color.LightGray)), Nothing, True, 0, 0, 1, 1)
			xStripStyle.SetShowAtWall(ChartWallType.Back, True)
			xStripStyle.Interlaced = True
			xScaleConfigurator.StripStyles.Add(xStripStyle)
			xScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScaleConfigurator

			' cross X and Y axes
			m_Chart.Axis(StandardAxis.PrimaryX).Anchor = New NCrossAxisAnchor(AxisOrientation.Horizontal, New NValueAxisCrossing(m_Chart.Axis(StandardAxis.PrimaryY), 0))
			m_Chart.Axis(StandardAxis.PrimaryX).Anchor.RulerOrientation = RulerOrientation.Right
			m_Chart.Axis(StandardAxis.PrimaryY).Anchor = New NCrossAxisAnchor(AxisOrientation.Vertical, New NValueAxisCrossing(m_Chart.Axis(StandardAxis.PrimaryX), 0))

			m_Chart.Axis(StandardAxis.Depth).Visible = False
			m_Chart.Wall(ChartWallType.Floor).Visible = False
			m_Chart.Wall(ChartWallType.Left).Visible = False

			' setup bubble series
			Dim bubble As NBubbleSeries = CType(m_Chart.Series.Add(SeriesType.Bubble), NBubbleSeries)
			bubble.Name = "Bubble Series"
			bubble.InflateMargins = True
			bubble.DataLabelStyle.Visible = False
			bubble.UseXValues = True
			bubble.ShadowStyle.Type = ShadowType.GaussianBlur
			bubble.BubbleShape = PointShape.Sphere
			bubble.Legend.Mode = SeriesLegendMode.None

			' fill with random data
			bubble.Values.FillRandomRange(Random, 10, -20, 20)
			bubble.XValues.FillRandomRange(Random, 10, -20, 20)
			bubble.Sizes.FillRandomRange(Random, 10, 1, 6)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			UpdateCrossings()
		End Sub

		Private Sub UpdateCrossings()
			Dim xAxis As NAxis = m_Chart.Axis(StandardAxis.PrimaryX)
			Dim yAxis As NAxis = m_Chart.Axis(StandardAxis.PrimaryY)

			Dim crossAnchor As NCrossAxisAnchor

			' update the x axis anchor
			crossAnchor = New NCrossAxisAnchor()
			xAxis.Anchor = crossAnchor
			crossAnchor.AxisOrientation = AxisOrientation.Horizontal
			crossAnchor.Crossings.Add(New NModelAxisCrossing(yAxis, CType(BottomAxisDropDownList.SelectedIndex, HorzAlign), New NLength(LengthBottomAxisDropDownList.SelectedIndex *10, NRelativeUnit.ParentPercentage)))

			' update the y axis anchor
			crossAnchor = New NCrossAxisAnchor()
			crossAnchor.AxisOrientation = AxisOrientation.Vertical
			yAxis.Anchor = crossAnchor
			crossAnchor.Crossings.Add(New NModelAxisCrossing(xAxis, CType(LeftAxisAligmentDropDownList.SelectedIndex, HorzAlign), New NLength(LengthLeftAxisDropDownList.SelectedIndex*10, NRelativeUnit.ParentPercentage)))
		End Sub
	End Class
End Namespace
