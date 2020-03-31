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
	Public Partial Class NScaleBreakAppearanceUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Scale Break Appearance<br/> <font size = '9pt'>Demonstrates how to change the scale break appearance</font>")
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

			' Create some data with a peak in it
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.DataLabelStyle.Visible = False

			' fill in some data so that it contains several peaks of data
			Dim random As Random = New Random()
			For i As Integer = 0 To 7
				bar.Values.Add(random.Next(30))
			Next i
			For i As Integer = 0 To 4
				bar.Values.Add(300 + random.Next(50))
			Next i
			For i As Integer = 0 To 7
				bar.Values.Add(random.Next(30))
			Next i

			' update form controls
			If (Not IsPostBack) Then
				patternDropDownList.Items.Add(ScaleBreakPattern.CenterPowerBrake.ToString())
				patternDropDownList.Items.Add(ScaleBreakPattern.FreeHand.ToString())
				patternDropDownList.Items.Add(ScaleBreakPattern.LeftPowerBrake.ToString())
				patternDropDownList.Items.Add(ScaleBreakPattern.LongShort.ToString())
				patternDropDownList.Items.Add(ScaleBreakPattern.Regular.ToString())
				patternDropDownList.Items.Add(ScaleBreakPattern.RightPowerBrake.ToString())
				patternDropDownList.SelectedIndex = 4

				styleDropDownList.Items.Add("Line")
				styleDropDownList.Items.Add("Wave")
				styleDropDownList.Items.Add("ZigZag")
				styleDropDownList.SelectedIndex = 1 ' use wave by default
				lengthTextBox.Text = "5"
			End If

			UpdateScaleBreaks()
		End Sub


		Protected Sub UpdateScaleBreaks()
			' read the form control values
			Dim horzStep As Single
			If (Not Single.TryParse(horzStepTextBox.Text, horzStep)) OrElse horzStep < 0 OrElse horzStep > 50 Then
				horzStep = 20f
				horzStepTextBox.Text = horzStep.ToString()
			End If

			Dim vertStep As Single
			If (Not Single.TryParse(vertStepTextBox.Text, vertStep)) OrElse vertStep < 0 OrElse vertStep > 50 Then
				vertStep = 3f
				vertStepTextBox.Text = vertStep.ToString()
			End If

			Dim length As Single
			If (Not Single.TryParse(lengthTextBox.Text, length)) OrElse length < 0 OrElse length > 50 Then
				length = 0
				lengthTextBox.Text = length.ToString()
			End If

			' update scale breaks
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim scale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim oldScaleBreakStyle As NScaleBreakStyle = Nothing
			If scale.ScaleBreaks.Count > 0 Then
				oldScaleBreakStyle = (CType(scale.ScaleBreaks(0), NScaleBreak)).Style
			End If
			scale.ScaleBreaks.Clear()

			Dim newScaleBreakStyle As NScaleBreakStyle = Nothing

			Select Case styleDropDownList.SelectedIndex
				Case 0 ' Line
					newScaleBreakStyle = New NLineScaleBreakStyle()
				Case 1 ' Waves
					newScaleBreakStyle = New NWaveScaleBreakStyle()
				Case 2 ' ZigZag
					newScaleBreakStyle = New NZigZagScaleBreakStyle()
			End Select

			' try to preserve fill and stroke settings
			If Not newScaleBreakStyle Is Nothing Then
				If Not oldScaleBreakStyle Is Nothing Then
					newScaleBreakStyle.InitFrom(oldScaleBreakStyle)
				End If

				' update the length of the scale break
				newScaleBreakStyle.Length = New NLength(length, NGraphicsUnit.Point)

				' update paramers relevant to pattern scale break appearance
				Dim patternScaleBreakStyle As NPatternScaleBreakStyle = TryCast(newScaleBreakStyle, NPatternScaleBreakStyle)
				Dim enablePatternControls As Boolean = Not patternScaleBreakStyle Is Nothing
				If Not patternScaleBreakStyle Is Nothing Then
					patternScaleBreakStyle.HorzStep = New NLength(horzStep)
					patternScaleBreakStyle.VertStep = New NLength(vertStep)
					patternScaleBreakStyle.Pattern = CType(System.Enum.Parse(GetType(ScaleBreakPattern), patternDropDownList.SelectedItem.Text), ScaleBreakPattern)
				End If

				scale.ScaleBreaks.Add(New NAutoScaleBreak(newScaleBreakStyle, 0.4f))
			End If
		End Sub
	End Class
End Namespace
