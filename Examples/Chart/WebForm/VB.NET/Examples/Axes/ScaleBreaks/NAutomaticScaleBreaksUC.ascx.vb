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
	Public Partial Class NAutomaticScaleBreaksUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Automatic Scale Breaks<br/> <font size = '9pt'>Demonstrates how to apply automatic scale breaks to the chart axes</font>")
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
			chart.Size = New NSizeL(New NLength(96, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
			chart.BoundsMode = BoundsMode.Stretch

			' configure scale
			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RoundToTickMax = True
			linearScale.RoundToTickMin = True
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MinTickDistance = New NLength(15)

			' add an interlaced strip to the Y axis
			Dim interlacedStrip As NScaleStripStyle = New NScaleStripStyle()
			interlacedStrip.SetShowAtWall(ChartWallType.Back, True)
			interlacedStrip.Interlaced = True
			interlacedStrip.FillStyle = New NColorFillStyle(Color.Beige)
			linearScale.StripStyles.Add(interlacedStrip)

			' update form controls
			If (Not IsPostBack) Then
				enableBreaksCheckBox.Checked = True

				positionModeDropDownList.Items.Add("Range")
				positionModeDropDownList.Items.Add("Percent")
				positionModeDropDownList.Items.Add("Content")
				positionModeDropDownList.SelectedIndex = 2 ' use content mode by default
			End If

			' feed some random data
			FeedRandomData()
			UpdateScaleBreaks()
		End Sub

		Protected Sub enableBreaksCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			UpdateScaleBreaks()
		End Sub


		Protected Sub FeedRandomData()
			Dim chart As NChart = nChartControl1.Charts(0)

			chart.Series.Clear()

			' setup bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.DataLabelStyle.Visible = False
			bar.BorderStyle.Width = New NLength(1.5f)
			bar.BorderStyle.Color = Color.DarkGreen

			' fill in some data so that it contains several peaks of data
			Dim random As Random = New Random()
			Dim value As Double = 0

			For i As Integer = 0 To 24
				If i < 6 Then
					value = random.Next(30)
				ElseIf i < 11 Then
					value = 200 + random.Next(50)
				ElseIf i < 16 Then
					value = 400 + random.Next(50)
				ElseIf i < 21 Then
					value = random.Next(30)
				Else
					value = 600 + random.Next(50)
				End If

				bar.Values.Add(value)
				bar.FillStyles(i) = New NGradientFillStyle(ColorFromValue(value), Color.DarkSlateBlue)
			Next i
		End Sub

		Protected Sub UpdateScaleBreaks()
			' read the form control values
			Dim threshold As Single
			If (Not Single.TryParse(thresholdTextBox.Text, threshold)) OrElse threshold < 0 OrElse threshold > 1 Then
				threshold = 0.25f
				thresholdTextBox.Text = threshold.ToString()
			End If

			Dim maxBreaks As Integer
			If (Not Integer.TryParse(maxBreaksTextBox.Text, maxBreaks)) OrElse maxBreaks < 0 OrElse maxBreaks > 3 Then
				maxBreaks = 1
				maxBreaksTextBox.Text = maxBreaks.ToString()
			End If

			Dim length As Single
			If (Not Single.TryParse(lengthTextBox.Text, length)) OrElse length < 0 OrElse length > 1000 Then
				length = 5
				lengthTextBox.Text = length.ToString()
			End If

			Dim positionPercent As Integer
			If (Not Integer.TryParse(positionPercentTextBox.Text, positionPercent)) OrElse positionPercent < 0 OrElse positionPercent > 1000 Then
				positionPercent = 50
				positionPercentTextBox.Text = positionPercent.ToString()
			End If

			' recreate scale breaks
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim scale As NStandardScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			scale.ScaleBreaks.Clear()

			If enableBreaksCheckBox.Checked Then
				Dim scaleBreak As NAutoScaleBreak = New NAutoScaleBreak(threshold)
				scaleBreak.Style = New NWaveScaleBreakStyle()
				scaleBreak.Style.Length = New NLength(length, NGraphicsUnit.Point)
				scaleBreak.MaxScaleBreakCount = maxBreaks

				Dim scaleBreakPosition As NScaleBreakPosition = New NRangeScaleBreakPosition()
				Select Case positionModeDropDownList.SelectedIndex
					Case 0 ' Range
						scaleBreakPosition = New NRangeScaleBreakPosition()
					Case 1 ' percent
						scaleBreakPosition = New NPercentScaleBreakPosition(CSng(positionPercent))
					Case 2 ' content
						scaleBreakPosition = New NContentScaleBreakPosition()
				End Select

				scaleBreak.Position = scaleBreakPosition

				scale.ScaleBreaks.Add(scaleBreak)
			End If
		End Sub

		Protected Function ColorFromValue(ByVal value As Double) As Color
			Dim beginColor As Color = Color.LightBlue
			Dim endColor As Color = Color.DarkSlateBlue

			Dim factor As Single = CSng(value / 650.0f)
			Dim oneMinusFactor As Single = 1.0f - factor

			Return Color.FromArgb(CByte(CSng(beginColor.R) * factor + CSng(endColor.R) * oneMinusFactor), CByte(CSng(beginColor.G) * factor + CSng(endColor.G) * oneMinusFactor), CByte(CSng(beginColor.B) * factor + CSng(endColor.B) * oneMinusFactor))
		End Function
	End Class
End Namespace
