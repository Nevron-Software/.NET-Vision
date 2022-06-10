Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NXYScatterSmoothLineUC
		Inherits NExampleBaseUC

		Private WithEvents btnChangeData As Nevron.UI.WinForm.Controls.NButton
		Private components As System.ComponentModel.IContainer = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#Region "Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.btnChangeData = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' btnChangeData
			' 
			Me.btnChangeData.Location = New System.Drawing.Point(5, 8)
			Me.btnChangeData.Name = "btnChangeData"
			Me.btnChangeData.Size = New System.Drawing.Size(170, 32)
			Me.btnChangeData.TabIndex = 1
			Me.btnChangeData.Text = "Change Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnChangeData.Click += new System.EventHandler(this.btnChangeData_Click);
			' 
			' NXYScatterSmoothLineUC
			' 
			Me.Controls.Add(Me.btnChangeData)
			Me.Name = "NXYScatterSmoothLineUC"
			Me.Size = New System.Drawing.Size(180, 150)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			Dim chart As NChart = nChartControl1.Charts(0)

			nChartControl1.Controller.Selection.Add(chart)
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As New NLabel("XY Smooth Line")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			chart.Enable3D = True
			chart.Width = 70
			chart.Height = 70
			chart.Depth = 15
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' configure axes
			chart.Axis(StandardAxis.Depth).Visible = False

			Dim linearScale As New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			linearScale = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlaced stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' add the line
			Dim line As NSmoothLineSeries = CType(chart.Series.Add(SeriesType.SmoothLine), NSmoothLineSeries)
			line.Name = "Smooth Line"
			line.InflateMargins = True
			line.Legend.Mode = SeriesLegendMode.Series
			line.DataLabelStyle.Visible = False
			line.MarkerStyle.Visible = True
			line.MarkerStyle.PointShape = PointShape.Cylinder
			line.MarkerStyle.AutoDepth = False
			line.MarkerStyle.Width = New NLength(1.4F, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Height = New NLength(1.4F, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Depth = New NLength(1.4F, NRelativeUnit.ParentPercentage)
			line.UseXValues = True
			line.UseZValues = False
			line.Use1DInterpolationForXYScatter = False

			ChangeData()

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Sub ChangeData()
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim line As NSmoothLineSeries = CType(chart.Series(0), NSmoothLineSeries)

			line.Values.Clear()
			line.XValues.Clear()
			line.ZValues.Clear()

			Dim r As Double = 5

			For i As Integer = 0 To 9
				Dim dY As Double = r * Math.Sin(i) + Random.NextDouble()
				Dim dX As Double = r * Math.Cos(i) + Random.NextDouble()

				line.Values.Add(dY)
				line.XValues.Add(dX)

				r -= 0.3
			Next i
		End Sub

		Private Sub btnChangeData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeData.Click
			ChangeData()
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace

