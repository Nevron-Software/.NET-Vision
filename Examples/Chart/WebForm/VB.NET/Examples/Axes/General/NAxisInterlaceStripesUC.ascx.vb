Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NAxisInterlaceStripesUC
		Inherits NExampleUC
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private m_YAxisInterlaceStyle As NScaleStripStyle
		Private m_XAxisInterlaceStyle As NScaleStripStyle
		Private m_Chart As NCartesianChart

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Interlaced Stripes")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			m_Chart = CType(nChartControl1.Charts(0), NCartesianChart)
			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			Dim ordinalScale As NOrdinalScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.DisplayDataPointsBetweenTicks = False

			Dim line As NLineSeries = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			line.Name = "Line Series"
			line.DataLabelStyle.Format = "<value>"
			line.MarkerStyle.Visible = True
			line.MarkerStyle.PointShape = PointShape.Sphere
			line.MarkerStyle.FillStyle = New NColorFillStyle(Color.Red)
			line.LineSegmentShape = LineSegmentShape.Tape
			line.BorderStyle.Width = New NLength(2, NGraphicsUnit.Point)
			line.BorderStyle.Color = Color.DarkSlateBlue
			line.DataLabelStyle.Visible = False
			line.Legend.Mode = SeriesLegendMode.None
			line.Values.FillRandom(Random, 20)
			line.ShadowStyle.Type = ShadowType.GaussianBlur
			line.ShadowStyle.Offset = New NPointL(3, 3)
			line.ShadowStyle.FadeLength = New NLength(5)
			line.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0)

			m_YAxisInterlaceStyle = New NScaleStripStyle()
			m_YAxisInterlaceStyle.SetShowAtWall(ChartWallType.Back, True)
			m_YAxisInterlaceStyle.SetShowAtWall(ChartWallType.Left, True)
			m_YAxisInterlaceStyle.Interlaced = True
			m_YAxisInterlaceStyle.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant1, Color.FromArgb(125, Color.PaleTurquoise), Color.FromArgb(125, Color.MediumAquamarine))
			m_YAxisInterlaceStyle.Begin = 0
			m_YAxisInterlaceStyle.End = 10
			m_YAxisInterlaceStyle.Infinite = True
			m_YAxisInterlaceStyle.Interval = 1
			m_YAxisInterlaceStyle.Length = 1

			m_XAxisInterlaceStyle = New NScaleStripStyle()
			m_XAxisInterlaceStyle.SetShowAtWall(ChartWallType.Back, True)
			m_XAxisInterlaceStyle.SetShowAtWall(ChartWallType.Floor, True)
			m_XAxisInterlaceStyle.Interlaced = True
			m_XAxisInterlaceStyle.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(125, Color.SteelBlue), Color.FromArgb(125, Color.SlateGray))
			m_XAxisInterlaceStyle.Begin = 0
			m_XAxisInterlaceStyle.End = 10
			m_XAxisInterlaceStyle.Infinite = True
			m_XAxisInterlaceStyle.Interval = 1
			m_XAxisInterlaceStyle.Length = 1

			If (Not Page.IsPostBack) Then
				YAxisInterlacedStripesCheckBox.Checked = True
			End If

			UpdateInterlaceStirpes()
		End Sub

		Private Sub UpdateInterlaceStirpes()
			Dim standardScale As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)

			standardScale.StripStyles.Clear()
			If YAxisInterlacedStripesCheckBox.Checked Then
				standardScale.StripStyles.Add(m_YAxisInterlaceStyle)
			End If

			m_YAxisInterlaceStyle.Begin = 0
			m_YAxisInterlaceStyle.End = 10
			m_YAxisInterlaceStyle.Infinite = True
			m_YAxisInterlaceStyle.Length = 1
			m_YAxisInterlaceStyle.Interval = 1

			standardScale = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)

			standardScale.StripStyles.Clear()
			If XAxisInterlacedStripesCheckBox.Checked Then
				standardScale.StripStyles.Add(m_XAxisInterlaceStyle)
			End If

			m_XAxisInterlaceStyle.Begin = 0
			m_XAxisInterlaceStyle.End = 10
			m_XAxisInterlaceStyle.Infinite = True
			m_XAxisInterlaceStyle.Length = 1
			m_XAxisInterlaceStyle.Interval = 1

		End Sub
	End Class
End Namespace
