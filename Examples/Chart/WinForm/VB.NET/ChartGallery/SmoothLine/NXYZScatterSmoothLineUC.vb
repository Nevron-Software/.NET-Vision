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
	Public Class NXYZScatterSmoothLineUC
		Inherits NExampleBaseUC

		Private WithEvents btnChangeData As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents checkShowMarkers As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents checkRoundToTick As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.checkShowMarkers = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.checkRoundToTick = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' btnChangeData
			' 
			Me.btnChangeData.Location = New System.Drawing.Point(5, 8)
			Me.btnChangeData.Name = "btnChangeData"
			Me.btnChangeData.Size = New System.Drawing.Size(170, 32)
			Me.btnChangeData.TabIndex = 0
			Me.btnChangeData.Text = "Change Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnChangeData.Click += new System.EventHandler(this.btnChangeData_Click);
			' 
			' checkShowMarkers
			' 
			Me.checkShowMarkers.ButtonProperties.BorderOffset = 2
			Me.checkShowMarkers.Location = New System.Drawing.Point(5, 56)
			Me.checkShowMarkers.Name = "checkShowMarkers"
			Me.checkShowMarkers.Size = New System.Drawing.Size(170, 24)
			Me.checkShowMarkers.TabIndex = 1
			Me.checkShowMarkers.Text = "Show Markers"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.checkShowMarkers.CheckedChanged += new System.EventHandler(this.checkShowMarkers_CheckedChanged);
			' 
			' checkRoundToTick
			' 
			Me.checkRoundToTick.ButtonProperties.BorderOffset = 2
			Me.checkRoundToTick.Location = New System.Drawing.Point(5, 96)
			Me.checkRoundToTick.Name = "checkRoundToTick"
			Me.checkRoundToTick.Size = New System.Drawing.Size(170, 24)
			Me.checkRoundToTick.TabIndex = 2
			Me.checkRoundToTick.Text = "Axis Round To Tick "
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.checkRoundToTick.CheckedChanged += new System.EventHandler(this.checkRoundToTick_CheckedChanged);
			' 
			' NXYZScatterSmoothLineUC
			' 
			Me.Controls.Add(Me.checkRoundToTick)
			Me.Controls.Add(Me.checkShowMarkers)
			Me.Controls.Add(Me.btnChangeData)
			Me.Name = "NXYZScatterSmoothLineUC"
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
			Dim title As New NLabel("XYZ Smooth Line")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			chart.Enable3D = True
			chart.Depth = 55.0F
			chart.Width = 55.0F
			chart.Height = 55.0F
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' setup axes
			Dim linearScale As New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			linearScale = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlaced stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			linearScale = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.Depth).Visible = True
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add the smooth line
			Dim line As NSmoothLineSeries = CType(chart.Series.Add(SeriesType.SmoothLine), NSmoothLineSeries)
			line.Name = "Smooth Line"
			line.InflateMargins = True
			line.Legend.Mode = SeriesLegendMode.Series
			line.BorderStyle.Color = Color.Indigo
			line.BorderStyle.Width = New NLength(1, NGraphicsUnit.Pixel)
			line.DataLabelStyle.Visible = False
			line.MarkerStyle.Visible = True
			line.MarkerStyle.PointShape = PointShape.Sphere
			line.MarkerStyle.AutoDepth = False
			line.MarkerStyle.Width = New NLength(1.4F, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Height = New NLength(1.4F, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Depth = New NLength(1.4F, NRelativeUnit.ParentPercentage)
			line.UseXValues = True
			line.UseZValues = True

			ChangeData()

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			checkShowMarkers.Checked = True
			checkRoundToTick.Checked = True
		End Sub

		Private Sub ChangeData()
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim line As NSmoothLineSeries = CType(chart.Series(0), NSmoothLineSeries)

			Dim fSpringHeight As Single = 10
			Dim nWindings As Integer = CInt(3)
			Dim nComplexity As Integer = CInt(4)

			Dim dCurrentAngle As Double = 0
			Dim dCurrentHeight As Double = 0
			Dim dCurrentRadius As Double = 5
			Dim dX As Double = 0, dY As Double = 0, dZ As Double = 0

			Dim fHeightStep As Single = fSpringHeight / (nWindings * nComplexity)
			Dim fAngleStepRad As Single = CSng(((360 \ nComplexity) * 3.1415926535F) / 180.0F)

			line.Values.Clear()
			line.XValues.Clear()
			line.ZValues.Clear()

			Do While nWindings > 0
				For i As Integer = 0 To nComplexity - 1
					dX = Math.Cos(dCurrentAngle) * dCurrentRadius
					dZ = Math.Sin(dCurrentAngle) * dCurrentRadius
					dY = dCurrentHeight

					line.Values.Add(dY)
					line.XValues.Add(dX)
					line.ZValues.Add(dZ)

					dCurrentAngle += fAngleStepRad
					dCurrentHeight += fHeightStep
					dCurrentRadius = 2 + Random.NextDouble() * 5
				Next i

				nWindings -= 1
			Loop
		End Sub

		Private Sub btnChangeData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeData.Click
			ChangeData()
			nChartControl1.Refresh()
		End Sub

		Private Sub checkShowMarkers_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkShowMarkers.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim line As NSmoothLineSeries = CType(chart.Series(0), NSmoothLineSeries)

			line.MarkerStyle.Visible = checkShowMarkers.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub checkRoundToTick_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkRoundToTick.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)

			Dim bRoundToTick As Boolean = checkRoundToTick.Checked

			Dim standardScale As NStandardScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			standardScale.RoundToTickMin = bRoundToTick
			standardScale.RoundToTickMax = bRoundToTick

			standardScale = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			standardScale.RoundToTickMin = bRoundToTick
			standardScale.RoundToTickMax = bRoundToTick

			standardScale = CType(chart.Axis(StandardAxis.Depth).ScaleConfigurator, NStandardScaleConfigurator)
			standardScale.RoundToTickMin = bRoundToTick
			standardScale.RoundToTickMax = bRoundToTick

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace

