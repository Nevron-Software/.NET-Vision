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
	Public Class NXYZScatterClusterUC
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.IContainer = Nothing
		Private WithEvents buttonNewData As Nevron.UI.WinForm.Controls.NButton
		Private Const nItemsCount As Integer = 5

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
			Me.buttonNewData = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' buttonNewData
			' 
			Me.buttonNewData.Location = New System.Drawing.Point(8, 8)
			Me.buttonNewData.Name = "buttonNewData"
			Me.buttonNewData.Size = New System.Drawing.Size(163, 32)
			Me.buttonNewData.TabIndex = 0
			Me.buttonNewData.Text = "New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.buttonNewData.Click += new System.EventHandler(this.buttonNewData_Click);
			' 
			' NXYZScatterClusterUC
			' 
			Me.Controls.Add(Me.buttonNewData)
			Me.Name = "NXYZScatterClusterUC"
			Me.Size = New System.Drawing.Size(180, 150)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True

			nChartControl1.Controller.Selection.Add(chart)

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XYZ Cluster Bar")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' set predefined projection and lighting
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight)
			chart.Width = 50
			chart.Height = 35
			chart.Depth = 50

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

			' add some data
			AddBarSeries(chart, MultiBarMode.Series)
			AddBarSeries(chart, MultiBarMode.Clustered)
			AddBarSeries(chart, MultiBarMode.Stacked)
			AddBarSeries(chart, MultiBarMode.Clustered)
			AddBarSeries(chart, MultiBarMode.Stacked)

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			GenerateData()
			nChartControl1.Refresh()
		End Sub

		Private Sub AddBarSeries(ByVal chart As NChart, ByVal mode As MultiBarMode)
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.MultiBarMode = mode
			bar.UseXValues = True
			bar.UseZValues = True
			bar.GapPercent = 30
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

			Dim dValueX As Double = Random.NextDouble() * 5

			For i As Integer = 0 To nItemsCount - 1
				bar.Values.Add(Random.NextDouble())
				bar.XValues.Add(dValueX)
				bar.ZValues.Add(Random.NextDouble() * 5)

				dValueX += 0.2 + Random.NextDouble()
			Next i
		End Sub

		Private Sub GenerateYData(ByVal bar As NBarSeries)
			bar.Values.Clear()

			For i As Integer = 0 To nItemsCount - 1
				bar.Values.Add(Random.NextDouble())
			Next i
		End Sub

		Private Sub buttonNewData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonNewData.Click
			GenerateData()
			nChartControl1.Refresh()
		End Sub

	End Class
End Namespace

