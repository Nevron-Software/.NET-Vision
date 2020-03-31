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
	Public Partial Class NAxisTicksUC
		Inherits NExampleUC
		Private m_Chart As NChart

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not Page.IsPostBack) Then
				ShowOuterMajorTicksCheckBox.Checked = True
				ShowInnerMajorTicksCheckBox.Checked = True
				ShowOuterMinorTicksCheckBox.Checked = True
				ShowInnerMinorTicksCheckBox.Checked = True
				WebExamplesUtilities.FillComboWithValues(OuterMajorTickLengthDropDownList, 0, 10, 1)
				OuterMajorTickLengthDropDownList.SelectedIndex = 4
				WebExamplesUtilities.FillComboWithValues(InnerMajorTickLengthDropDownList, 0, 10, 1)
				InnerMajorTickLengthDropDownList.SelectedIndex = 4
				WebExamplesUtilities.FillComboWithValues(OuterMinorTickLengthDropDownList, 0, 10, 1)
				OuterMinorTickLengthDropDownList.SelectedIndex = 2
				WebExamplesUtilities.FillComboWithValues(InnerMinorTickLengthDropDownList, 0, 10, 1)
				InnerMinorTickLengthDropDownList.SelectedIndex = 2
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Axis Ticks")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False
			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			' add interlaced stripe
			Dim scaleConfiguratorY As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle()
			stripStyle.FillStyle = New NColorFillStyle(Color.Beige)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			scaleConfiguratorY.StripStyles.Add(stripStyle)

			Dim bar As NBarSeries = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Values.FillRandom(Random, 6)
			bar.DataLabelStyle.Format = "<value>"
			bar.Legend.Mode = SeriesLegendMode.None
			bar.Name = "Bars"

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			SetTicks()
		End Sub

		Protected Sub ShowOuterMajorTicksCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			SetTicks()
		End Sub

		Protected Sub ShowInnerMajorTicksCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			SetTicks()
		End Sub

		Protected Sub ShowOuterMinorTicksCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			SetTicks()
		End Sub

		Protected Sub ShowInnerMinorTicksCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			SetTicks()
		End Sub

		Protected Sub OuterMajorTickLengthDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			SetTicks()
		End Sub

		Protected Sub InnerMajorTickLengthDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			SetTicks()
		End Sub

		Protected Sub OuterMinorTickLengthDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			SetTicks()
		End Sub

		Protected Sub InnerMinorTickLengthDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			SetTicks()
		End Sub

		Private Sub SetTicks()
			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MinorTickCount = 3

			If ShowOuterMajorTicksCheckBox.Checked Then
				linearScale.OuterMajorTickStyle.Length = New NLength(Convert.ToInt32(OuterMajorTickLengthDropDownList.SelectedValue), linearScale.OuterMajorTickStyle.Length.MeasurementUnit)
			Else
				linearScale.OuterMajorTickStyle.Length = New NLength(0, linearScale.OuterMajorTickStyle.Length.MeasurementUnit)
			End If

			If ShowInnerMajorTicksCheckBox.Checked Then
				linearScale.InnerMajorTickStyle.Length = New NLength(Convert.ToInt32(InnerMajorTickLengthDropDownList.SelectedValue), linearScale.InnerMajorTickStyle.Length.MeasurementUnit)
			Else
				linearScale.InnerMajorTickStyle.Length = New NLength(0, linearScale.InnerMajorTickStyle.Length.MeasurementUnit)
			End If

			If ShowOuterMinorTicksCheckBox.Checked Then
				linearScale.OuterMinorTickStyle.Length = New NLength(Convert.ToInt32(OuterMinorTickLengthDropDownList.SelectedValue), linearScale.OuterMinorTickStyle.Length.MeasurementUnit)
			Else
				linearScale.OuterMinorTickStyle.Length = New NLength(0, linearScale.OuterMinorTickStyle.Length.MeasurementUnit)
			End If

			If ShowInnerMinorTicksCheckBox.Checked Then
				linearScale.InnerMinorTickStyle.Length = New NLength(Convert.ToInt32(InnerMinorTickLengthDropDownList.SelectedValue), linearScale.InnerMinorTickStyle.Length.MeasurementUnit)
			Else
				linearScale.InnerMinorTickStyle.Length = New NLength(0, linearScale.InnerMinorTickStyle.Length.MeasurementUnit)
			End If
		End Sub
	End Class
End Namespace
