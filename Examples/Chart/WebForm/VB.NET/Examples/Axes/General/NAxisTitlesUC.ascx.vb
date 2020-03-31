Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NAxisAppearanceUC
		Inherits NExampleUC

		Private nChart As NChart

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithFontNames(YAxisFontDropDownList, "Arial")
				WebExamplesUtilities.FillComboWithFontNames(XAxisFontDropDownList, "Arial")
				WebExamplesUtilities.FillComboWithValues(YOffsetDropDownList, 0, 30, 5)
				WebExamplesUtilities.FillComboWithValues(XOffsetDropDownList, 0, 30, 5)
				YTitleTextBox.Text = "Y Axis Title"
				XTitleTextBox.Text = "X Axis Title"
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Axis Titles")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			nChart = nChartControl1.Charts(0)
			nChart.BoundsMode = BoundsMode.Stretch
			nChart.Location = New NPointL(New NLength(4, NRelativeUnit.ParentPercentage), New NLength(12, NRelativeUnit.ParentPercentage))
			nChart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(84, NRelativeUnit.ParentPercentage))

			Dim scaleConfiguratorY As NStandardScaleConfigurator = CType(nChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfiguratorY.Title.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.View, 90)

			' add interlaced stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle()
			stripStyle.FillStyle = New NColorFillStyle(Color.Beige)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			scaleConfiguratorY.StripStyles.Add(stripStyle)

			Dim scaleConfiguratorX As NStandardScaleConfigurator = CType(nChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfiguratorX.Title.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.View, 0)

			Dim bar As NBarSeries = CType(nChart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Values.FillRandom(Random, 20)
			bar.Name = "Bars"
			bar.DataLabelStyle.Visible = False
			bar.Legend.Mode = SeriesLegendMode.None

			scaleConfiguratorY = CType(nChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfiguratorY.Title.Text = YTitleTextBox.Text

			scaleConfiguratorX = CType(nChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfiguratorX.Title.Text = XTitleTextBox.Text

			SetTitle()

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Protected Sub YAxisFontDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			SetTitle()
		End Sub

		Protected Sub XAxisFontDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			SetTitle()
		End Sub

		Protected Sub YAlignmentDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			SetTitle()
		End Sub

		Protected Sub XAlignmentDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			SetTitle()
		End Sub

		Protected Sub YOffsetDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			SetTitle()
		End Sub

		Protected Sub XOffsetDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			SetTitle()
		End Sub

		Private Sub SetTitle()
			Dim scaleConfiguratorY As NStandardScaleConfigurator = CType(nChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			Dim scaleConfiguratorX As NStandardScaleConfigurator = CType(nChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)

			Dim textStyleResultY As NTextStyle = New NTextStyle(New NFontStyle(YAxisFontDropDownList.SelectedValue))
			Dim textStyleResultX As NTextStyle = New NTextStyle(New NFontStyle(XAxisFontDropDownList.SelectedValue))

			scaleConfiguratorY.Title.TextStyle = textStyleResultY
			scaleConfiguratorX.Title.TextStyle = textStyleResultX

			Select Case YAlignmentDropDownList.SelectedIndex
				Case 0
					scaleConfiguratorY.Title.ContentAlignment = ContentAlignment.MiddleRight
					scaleConfiguratorY.Title.RulerAlignment = HorzAlign.Right

				Case 1
					scaleConfiguratorY.Title.ContentAlignment = ContentAlignment.MiddleCenter
					scaleConfiguratorY.Title.RulerAlignment = HorzAlign.Center

				Case 2
					scaleConfiguratorY.Title.ContentAlignment = ContentAlignment.MiddleLeft
					scaleConfiguratorY.Title.RulerAlignment = HorzAlign.Left
			End Select

			Select Case XAlignmentDropDownList.SelectedIndex
				Case 0
					scaleConfiguratorX.Title.ContentAlignment = ContentAlignment.MiddleLeft
					scaleConfiguratorX.Title.RulerAlignment = HorzAlign.Left

				Case 1
					scaleConfiguratorX.Title.ContentAlignment = ContentAlignment.MiddleCenter
					scaleConfiguratorX.Title.RulerAlignment = HorzAlign.Center

				Case 2
					scaleConfiguratorX.Title.ContentAlignment = ContentAlignment.MiddleRight
					scaleConfiguratorX.Title.RulerAlignment = HorzAlign.Right
			End Select

			scaleConfiguratorY.Title.Offset = New NLength(Convert.ToInt32(YOffsetDropDownList.SelectedValue), NGraphicsUnit.Pixel)
			scaleConfiguratorX.Title.Offset = New NLength(Convert.ToInt32(XOffsetDropDownList.SelectedValue), NGraphicsUnit.Pixel)
		End Sub
	End Class
End Namespace
