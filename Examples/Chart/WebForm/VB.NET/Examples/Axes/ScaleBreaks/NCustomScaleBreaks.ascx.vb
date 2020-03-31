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
	Public Partial Class NCustomScaleBreaks
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Custom Scale Breaks<br/> <font size = '9pt'>Demonstrates how to apply custom scale breaks to the chart axes</font>")
			header.TextStyle.TextFormat = TextFormat.XML
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' turn off the legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Mode = LegendMode.Disabled

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(19, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(92, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
			chart.BoundsMode = BoundsMode.Stretch
			Dim random As Random = New Random()

			' create three random point series
			For i As Integer = 0 To 2
				Dim point As NPointSeries = New NPointSeries()
				point.UseXValues = True
				point.DataLabelStyle.Visible = False
				point.Size = New NLength(5)
				point.BorderStyle.Width = New NLength(0)

				' fill in some random data
				For j As Integer = 0 To 29
					point.Values.Add(5 + random.Next(90))
					point.XValues.Add(5 + random.Next(90))
				Next j

				chart.Series.Add(point)
			Next i

			' create scale breaks
			m_FirstHorzScaleBreak = New NCustomScaleBreak(New NLineScaleBreakStyle(New NColorFillStyle(Color.FromArgb(124, Color.Orange)), Nothing, New NLength(10)), New NRange1DD(10, 20))
			m_SecondHorzScaleBreak = New NCustomScaleBreak(New NLineScaleBreakStyle(New NColorFillStyle(Color.FromArgb(124, Color.Green)), Nothing, New NLength(10)), New NRange1DD(80, 90))
			m_FirstVertScaleBreak = New NCustomScaleBreak(New NLineScaleBreakStyle(New NColorFillStyle(Color.FromArgb(124, Color.Red)), Nothing, New NLength(10)), New NRange1DD(10, 20))
			m_SecondVertScaleBreak = New NCustomScaleBreak(New NLineScaleBreakStyle(New NColorFillStyle(Color.FromArgb(124, Color.Blue)), Nothing, New NLength(10)), New NRange1DD(80, 90))

			' configure scales
			Dim xScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			xScale.RoundToTickMax = True
			xScale.RoundToTickMin = True
			xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			xScale.ScaleBreaks.Add(m_FirstHorzScaleBreak)
			xScale.ScaleBreaks.Add(m_SecondHorzScaleBreak)

			' add an interlaced strip to the X axis
			Dim xInterlacedStrip As NScaleStripStyle = New NScaleStripStyle()
			xInterlacedStrip.SetShowAtWall(ChartWallType.Back, True)
			xInterlacedStrip.Interlaced = True
			xInterlacedStrip.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.LightGray))
			xScale.StripStyles.Add(xInterlacedStrip)

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale
			chart.Axis(StandardAxis.PrimaryX).View = New NRangeAxisView(New NRange1DD(0, 100))

			Dim yScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			yScale.RoundToTickMax = True
			yScale.RoundToTickMin = True
			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			yScale.ScaleBreaks.Add(m_FirstVertScaleBreak)
			yScale.ScaleBreaks.Add(m_SecondVertScaleBreak)

			' add an interlaced strip to the Y axis
			Dim yInterlacedStrip As NScaleStripStyle = New NScaleStripStyle()
			yInterlacedStrip.SetShowAtWall(ChartWallType.Back, True)
			yInterlacedStrip.Interlaced = True
			yInterlacedStrip.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.LightGray))
			yScale.StripStyles.Add(yInterlacedStrip)

			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = yScale
			chart.Axis(StandardAxis.PrimaryY).View = New NRangeAxisView(New NRange1DD(0, 100))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' feed some random data
			UpdateScaleBreaks()
		End Sub

		Protected Sub UpdateScaleBreaks()
			' read the form control values
			Dim sb1Begin As Double
			If (Not Double.TryParse(sb1BeginTextBox.Text, sb1Begin)) OrElse sb1Begin < 0 OrElse sb1Begin > 100 Then
				sb1Begin = 10
				sb1BeginTextBox.Text = sb1Begin.ToString()
			End If

			Dim sb1End As Double
			If (Not Double.TryParse(sb1EndTextBox.Text, sb1End)) OrElse sb1End < 0 OrElse sb1End > 100 Then
				sb1End = 20
				sb1EndTextBox.Text = sb1End.ToString()
			End If

			Dim sb2Begin As Double
			If (Not Double.TryParse(sb2BeginTextBox.Text, sb2Begin)) OrElse sb2Begin < 0 OrElse sb2Begin > 100 Then
				sb2Begin = 80
				sb2BeginTextBox.Text = sb2Begin.ToString()
			End If

			Dim sb2End As Double
			If (Not Double.TryParse(sb2EndTextBox.Text, sb2End)) OrElse sb2End < 0 OrElse sb2End > 100 Then
				sb2End = 90
				sb2EndTextBox.Text = sb2End.ToString()
			End If

			Dim sb3Begin As Double
			If (Not Double.TryParse(sb3BeginTextBox.Text, sb3Begin)) OrElse sb3Begin < 0 OrElse sb3Begin > 100 Then
				sb3Begin = 10
				sb3BeginTextBox.Text = sb3Begin.ToString()
			End If

			Dim sb3End As Double
			If (Not Double.TryParse(sb3EndTextBox.Text, sb3End)) OrElse sb3End < 0 OrElse sb3End > 100 Then
				sb3End = 20
				sb3EndTextBox.Text = sb3End.ToString()
			End If

			Dim sb4Begin As Double
			If (Not Double.TryParse(sb4BeginTextBox.Text, sb4Begin)) OrElse sb4Begin < 0 OrElse sb4Begin > 100 Then
				sb4Begin = 80
				sb4BeginTextBox.Text = sb4Begin.ToString()
			End If

			Dim sb4End As Double
			If (Not Double.TryParse(sb4EndTextBox.Text, sb4End)) OrElse sb4End < 0 OrElse sb4End > 100 Then
				sb4End = 90
				sb4EndTextBox.Text = sb4End.ToString()
			End If

			' adjust scale breaks
			m_FirstHorzScaleBreak.Range = New NRange1DD(sb1Begin, sb1End)
			m_SecondHorzScaleBreak.Range = New NRange1DD(sb2Begin, sb2End)
			m_FirstVertScaleBreak.Range = New NRange1DD(sb3Begin, sb3End)
			m_SecondVertScaleBreak.Range = New NRange1DD(sb4Begin, sb4End)
		End Sub

		Private m_FirstHorzScaleBreak As NCustomScaleBreak
		Private m_SecondHorzScaleBreak As NCustomScaleBreak
		Private m_FirstVertScaleBreak As NCustomScaleBreak
		Private m_SecondVertScaleBreak As NCustomScaleBreak
	End Class
End Namespace
