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
	Public Class NXYZScatterStackUC
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.IContainer = Nothing
		Private WithEvents btnNewData As Nevron.UI.WinForm.Controls.NButton
		Private Const nItemsCount As Integer = 6

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
			Me.btnNewData = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' btnNewData
			' 
			Me.btnNewData.Location = New System.Drawing.Point(8, 8)
			Me.btnNewData.Name = "btnNewData"
			Me.btnNewData.Size = New System.Drawing.Size(164, 32)
			Me.btnNewData.TabIndex = 1
			Me.btnNewData.Text = "New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnNewData.Click += new System.EventHandler(this.btnNewData_Click);
			' 
			' NXYZScatterStackUC
			' 
			Me.Controls.Add(Me.btnNewData)
			Me.Name = "NXYZScatterStackUC"
			Me.Size = New System.Drawing.Size(180, 150)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			Dim chart As NChart = nChartControl1.Charts(0)

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XYZ Stack Bar")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' set predefined projection and lighting
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight)
			chart.Width = 50
			chart.Height = 35
			chart.Depth = 50
			chart.Enable3D = True

			' configure the axes
			Dim linearScale As New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)

			linearScale = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' add interlace stripes to the Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			linearScale = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)

			AddBarSeries(chart, MultiBarMode.Series)
			AddBarSeries(chart, MultiBarMode.Stacked)
			AddBarSeries(chart, MultiBarMode.Stacked)
			AddBarSeries(chart, MultiBarMode.Stacked)

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			GenerateData()
		End Sub

		Private Sub btnNewData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNewData.Click
			GenerateData()
			nChartControl1.Refresh()
		End Sub


		Private Sub AddBarSeries(ByVal chart As NChart, ByVal mode As MultiBarMode)
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.MultiBarMode = mode
			bar.UseXValues = True
			bar.UseZValues = True
			bar.DataLabelStyle.Visible = False
			bar.InflateMargins = True
		End Sub

		Private Sub GenerateData()
			Dim chart As NChart = nChartControl1.Charts(0)

			For i As Integer = 0 To chart.Series.Count - 1
				Dim bar As NBarSeries = CType(chart.Series(i), NBarSeries)

				If i = 0 Then
					' the master series needs Y, X and Z values
					GenerateXYZData(bar)
				Else
					' the other series need only Y values
					GenerateYData(bar)
				End If
			Next i
		End Sub

		Private Sub GenerateXYZData(ByVal bar As NBarSeries)
			bar.Values.Clear()
			bar.XValues.Clear()
			bar.ZValues.Clear()

			For i As Integer = 0 To nItemsCount - 1
				bar.Values.Add(Random.NextDouble())
				bar.XValues.Add(Random.NextDouble() * 5)
				bar.ZValues.Add(Random.NextDouble() * 5)
			Next i
		End Sub

		Private Sub GenerateYData(ByVal bar As NBarSeries)
			bar.Values.Clear()

			For i As Integer = 0 To nItemsCount - 1
				bar.Values.Add(Random.NextDouble())
			Next i
		End Sub
	End Class
End Namespace

