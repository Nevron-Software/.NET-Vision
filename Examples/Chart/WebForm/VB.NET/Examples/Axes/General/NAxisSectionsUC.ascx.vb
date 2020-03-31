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
	Public Partial Class NAxisSectionsUC
		Inherits NExampleUC

		Private m_Chart As NCartesianChart

		Private m_FirstVerticalSection As NScaleSectionStyle
		Private m_SecondVerticalSection As NScaleSectionStyle
		Private m_FirstHorizontalSection As NScaleSectionStyle
		Private m_SecondHorizontalSection As NScaleSectionStyle

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Axis Sections")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			m_Chart = CType(nChartControl1.Charts(0), NCartesianChart)
			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(12, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(93, NRelativeUnit.ParentPercentage), New NLength(85, NRelativeUnit.ParentPercentage))

			' create a point series
			Dim point As NPointSeries = CType(m_Chart.Series.Add(SeriesType.Point), NPointSeries)
			point.Name = "Point Series"
			point.Legend.Mode = SeriesLegendMode.None
			point.DataLabelStyle.Visible = False
			point.MarkerStyle.Visible = False
			point.Size = New NLength(5, NGraphicsUnit.Point)
			point.Values.FillRandom(Random, 30)
			point.ShadowStyle.Type = ShadowType.GaussianBlur
			point.ShadowStyle.Offset = New NPointL(3, 3)
			point.ShadowStyle.FadeLength = New NLength(5)
			point.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0)
			point.InflateMargins = True

			' tell the x axis to display major and minor grid lines
			Dim linearScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MinorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MinorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MinorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MinorTickCount = 1

			' tell the y axis to display major and minor grid lines
			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MinorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MinorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MinorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MinorTickCount = 1

			Dim labelStyle As NTextStyle

			' configure the first horizontal section
			m_FirstHorizontalSection = New NScaleSectionStyle()
			m_FirstHorizontalSection.Range = New NRange1DD(2, 8)
			m_FirstHorizontalSection.SetShowAtWall(ChartWallType.Back, True)
			m_FirstHorizontalSection.SetShowAtWall(ChartWallType.Floor, True)
			m_FirstHorizontalSection.RangeFillStyle = New NColorFillStyle(Color.FromArgb(125, Color.Red))
			m_FirstHorizontalSection.MajorGridStrokeStyle = New NStrokeStyle(Color.Red)
			m_FirstHorizontalSection.MajorTickStrokeStyle = New NStrokeStyle(Color.DarkRed)
			m_FirstHorizontalSection.MinorTickStrokeStyle = New NStrokeStyle(1, Color.Red, LinePattern.Dot, 0, 1)

			labelStyle = New NTextStyle()
			labelStyle.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.Red, Color.DarkRed)
			labelStyle.FontStyle.Style = FontStyle.Bold
			m_FirstHorizontalSection.LabelTextStyle = labelStyle

			' configure the second horizontal section
			m_SecondHorizontalSection = New NScaleSectionStyle()
			m_SecondHorizontalSection.Range = New NRange1DD(14, 18)
			m_SecondHorizontalSection.SetShowAtWall(ChartWallType.Back, True)
			m_SecondHorizontalSection.SetShowAtWall(ChartWallType.Floor, True)
			m_SecondHorizontalSection.RangeFillStyle = New NColorFillStyle(Color.FromArgb(125, Color.Green))
			m_SecondHorizontalSection.MajorGridStrokeStyle = New NStrokeStyle(Color.Green)
			m_SecondHorizontalSection.MajorTickStrokeStyle = New NStrokeStyle(Color.DarkGreen)
			m_SecondHorizontalSection.MinorTickStrokeStyle = New NStrokeStyle(1, Color.Green, LinePattern.Dot, 0, 2)

			labelStyle = New NTextStyle()
			labelStyle.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.Green, Color.DarkGreen)
			labelStyle.FontStyle.Style = FontStyle.Bold
			m_SecondHorizontalSection.LabelTextStyle = labelStyle

			' configure the first vertical section
			m_FirstVerticalSection = New NScaleSectionStyle()
			m_FirstVerticalSection.Range = New NRange1DD(20, 40)
			m_FirstVerticalSection.SetShowAtWall(ChartWallType.Back, True)
			m_FirstVerticalSection.SetShowAtWall(ChartWallType.Left, True)
			m_FirstVerticalSection.RangeFillStyle = New NColorFillStyle(Color.FromArgb(125, Color.Blue))
			m_FirstVerticalSection.MajorGridStrokeStyle = New NStrokeStyle(Color.Blue)
			m_FirstVerticalSection.MajorTickStrokeStyle = New NStrokeStyle(Color.DarkBlue)
			m_FirstVerticalSection.MinorTickStrokeStyle = New NStrokeStyle(1, Color.Blue, LinePattern.Dot, 0, 2)

			labelStyle = New NTextStyle()
			labelStyle.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.Blue, Color.DarkBlue)
			labelStyle.FontStyle.Style = FontStyle.Bold
			m_FirstVerticalSection.LabelTextStyle = labelStyle

			' configure the second vertical section
			m_SecondVerticalSection = New NScaleSectionStyle()
			m_SecondVerticalSection.Range = New NRange1DD(70, 90)
			m_SecondVerticalSection.SetShowAtWall(ChartWallType.Back, True)
			m_SecondVerticalSection.SetShowAtWall(ChartWallType.Left, True)
			m_SecondVerticalSection.RangeFillStyle = New NColorFillStyle(Color.FromArgb(125, Color.Orange))
			m_SecondVerticalSection.MajorGridStrokeStyle = New NStrokeStyle(Color.Orange)
			m_SecondVerticalSection.MajorTickStrokeStyle = New NStrokeStyle(Color.DarkOrange)
			m_SecondVerticalSection.MinorTickStrokeStyle = New NStrokeStyle(1, Color.Orange, LinePattern.Dot, 0, 2)

			labelStyle = New NTextStyle()
			labelStyle.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.Orange, Color.DarkOrange)
			labelStyle.FontStyle.Style = FontStyle.Bold
			m_SecondVerticalSection.LabelTextStyle = labelStyle

			If (Not Page.IsPostBack) Then
				ShowFirstHorizontalSectionCheck.Checked = True
				ShowSecondHorizontalSectionCheck.Checked = True
				ShowFirstVerticalSectionCheck.Checked = True
				ShowSecondVerticalSectionCheck.Checked = True
			End If
			UpdateSections()
		End Sub

		Private Sub UpdateSections()
			Dim standardScale As NStandardScaleConfigurator

			' configure horizontal axis sections
			standardScale = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			standardScale.Sections.Clear()

			If ShowFirstHorizontalSectionCheck.Checked Then
				standardScale.Sections.Add(m_FirstHorizontalSection)
			End If

			If ShowSecondHorizontalSectionCheck.Checked Then
				standardScale.Sections.Add(m_SecondHorizontalSection)
			End If

			' configure vertical axis sections
			standardScale = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			standardScale.Sections.Clear()

			If ShowFirstVerticalSectionCheck.Checked Then
				standardScale.Sections.Add(m_FirstVerticalSection)
			End If

			If ShowSecondVerticalSectionCheck.Checked Then
				standardScale.Sections.Add(m_SecondVerticalSection)
			End If
		End Sub

		Protected Sub ShowFirstVerticalSectionCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateSections()
		End Sub

		Protected Sub ShowSecondVerticalSectionCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateSections()
		End Sub

		Protected Sub ShowFirstHorizontalSectionCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateSections()
		End Sub

		Protected Sub ShowSecondHorizontalSectionCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateSections()
		End Sub
	End Class
End Namespace
