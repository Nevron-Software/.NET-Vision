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
	Public Partial Class NOrdinalScaleUC
		Inherits NExampleUC
		Private m_Chart As NChart

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			' init form controls
			If (Not IsPostBack) Then
				PrimaryXAxisAutoLabelsCheckBox.Checked = True
				PrimaryXAxisInvertCheckBox.Checked = True

				DepthAxisAutoLabelsCheckBox.Checked = True
				DepthAxisInvertAxisCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Ordinal Scale")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True

			' set projection and lighting
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)

			' set sizes
			m_Chart.Depth = 50
			m_Chart.BoundsMode = BoundsMode.Fit

			m_Chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' add series
			Dim seriesColors As Color() = New Color() { Color.Crimson, Color.Orange, Color.OliveDrab }
			Dim dataItemsCount As Integer = 6
			Dim i As Integer = 0
			Do While i < seriesColors.Length
				Dim bar As NBarSeries = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)

				bar.FillStyle = New NColorFillStyle(seriesColors(i))
				bar.Name = "Series " & i.ToString()
				bar.Values.FillRandomRange(Random, dataItemsCount, 10, 30)
				bar.InflateMargins = True
				bar.DataLabelStyle.Visible = False
				i += 1
			Loop

			Dim oridnalScale As NOrdinalScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			oridnalScale.LabelFitModes = New LabelFitMode() { LabelFitMode.AutoScale }

			i = 0
			Do While i < dataItemsCount
				oridnalScale.Labels.Add("Category " & i.ToString())
				i += 1
			Loop

			oridnalScale = TryCast(m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)
			oridnalScale.Labels.Add("Series 1")
			oridnalScale.Labels.Add("Series 2")
			oridnalScale.Labels.Add("Series 3")
			oridnalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			oridnalScale.LabelFitModes = New LabelFitMode() { LabelFitMode.AutoScale }

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Sub UpdateScales()
			Dim ordinalScale As NOrdinalScaleConfigurator

			' configure the primary x axis
			ordinalScale = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)

			ordinalScale.DisplayDataPointsBetweenTicks = PrimaryXAxisInvertCheckBox.Checked
			ordinalScale.AutoLabels = PrimaryXAxisAutoLabelsCheckBox.Checked

			' configure the depth axis
			ordinalScale = CType(m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)

			ordinalScale.DisplayDataPointsBetweenTicks = DepthAxisInvertAxisCheckBox.Checked
			ordinalScale.AutoLabels = DepthAxisAutoLabelsCheckBox.Checked
		End Sub

		Protected Sub PrimaryXAxisInvertCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateScales()
		End Sub

		Protected Sub PrimaryXAxisAutoLabelsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateScales()
		End Sub

		Protected Sub DepthAxisInvertAxisCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateScales()
		End Sub

		Protected Sub DepthAxisAutoLabelsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateScales()
		End Sub
	End Class
End Namespace
