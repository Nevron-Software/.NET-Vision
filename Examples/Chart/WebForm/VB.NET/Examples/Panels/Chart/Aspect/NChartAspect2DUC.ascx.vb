Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NChartAspect2DUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = New NLabel("Chart Aspect 2D")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.DockMode = PanelDockMode.Top
			title.Margins = New NMarginsL(10, 10, 10, 0)
			nChartControl1.Panels.Add(title)

			Dim chart As NCartesianChart = New NCartesianChart()
			nChartControl1.Panels.Add(chart)

			chart.DockMode = PanelDockMode.Fill
			chart.Margins = New NMarginsL(30, 10, 10, 30)
			chart.Padding = New NMarginsL(0)
			chart.BoundsMode = BoundsMode.Stretch
			chart.UsePlotAspect = True
'TODO: INSTANT VB TODO TASK: Assignments within expressions are not supported in VB.NET
'ORIGINAL LINE: chart.Width = chart.Height = 50;
			chart.Width = chart.Height = 50

			' switch all axes to linear mode
			Dim xScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			xScale.Title.Text = "X Scale Title"
			xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			xScale.LabelStyle.KeepInsideRuler = True
			xScale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.View, 90, False)
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale

			Dim yScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			yScale.Title.Text = "Y Scale Title"
			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			yScale.LabelStyle.KeepInsideRuler = True
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = yScale

			chart.Axis(StandardAxis.SecondaryX).ScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.SecondaryY).ScaleConfigurator = New NLinearScaleConfigurator()

			' cross secondary X and Y axes
			chart.Axis(StandardAxis.SecondaryX).Anchor = New NCrossAxisAnchor(AxisOrientation.Horizontal, New NValueAxisCrossing(chart.Axis(StandardAxis.PrimaryY), 0))
			chart.Axis(StandardAxis.SecondaryY).Anchor = New NCrossAxisAnchor(AxisOrientation.Vertical, New NValueAxisCrossing(chart.Axis(StandardAxis.PrimaryX), 0))

			' show secondary axes
			chart.Axis(StandardAxis.SecondaryX).Visible = True
			chart.Axis(StandardAxis.SecondaryY).Visible = True

			' turn off labels for cross axes
			Dim secondaryScaleX As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.SecondaryX).ScaleConfigurator, NLinearScaleConfigurator)
			secondaryScaleX.AutoLabels = False

			Dim secondaryScaleY As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.SecondaryY).ScaleConfigurator, NLinearScaleConfigurator)
			secondaryScaleY.AutoLabels = False

			' add some dummy data
			Dim point As NPointSeries = New NPointSeries()
			chart.Series.Add(point)
			point.DataLabelStyle.Visible = False
			point.UseXValues = True

			point.DisplayOnAxis(CInt(Fix(StandardAxis.SecondaryX)), True)
			point.DisplayOnAxis(CInt(Fix(StandardAxis.SecondaryY)), True)
			point.Size = New NLength(1)
			point.BorderStyle.Width = New NLength(0)
			point.ClusterMode = ClusterMode.Enabled

			' add some random data in the range [-100, 100]
			Dim rand As Random = New Random()

			For i As Integer = 0 To 2999
				point.Values.Add(rand.Next(200) - 100)
				point.XValues.Add(rand.Next(200) - 100)
			Next i


			If (Not IsPostBack) Then
				' init form controls
				WebExamplesUtilities.FillComboWithValues(XProportionDropDownList, 1, 5, 1)
				XProportionDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithValues(YProportionDropDownList, 1, 5, 1)
				YProportionDropDownList.SelectedIndex = 0

				FitAxisContentCheckBox.Checked = True
				UsePlotAspectCheckBox.Checked = True
				ShowContentAreaCheckBox.Checked = False
			End If

			chart.Width = (XProportionDropDownList.SelectedIndex + 1) * 10
			chart.Height = (YProportionDropDownList.SelectedIndex + 1) * 10
			chart.UsePlotAspect = UsePlotAspectCheckBox.Checked
			chart.Fit2DAxisContent = FitAxisContentCheckBox.Checked

			UsePlotAspectCheckBox.Enabled = FitAxisContentCheckBox.Checked
			Dim enableProportion As Boolean = UsePlotAspectCheckBox.Checked AndAlso Not FitAxisContentCheckBox.Checked
			XProportionDropDownList.Enabled = enableProportion
			YProportionDropDownList.Enabled = enableProportion

			If ShowContentAreaCheckBox.Checked Then
				chart.BorderStyle = New NStrokeBorderStyle()
			Else
				chart.BorderStyle = Nothing
			End If
		End Sub
	End Class
End Namespace
