Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NXYZScatterPointUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Point As NPointSeries
		Private WithEvents InflateMarginsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents AxesRoundToTick As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ChangeXValuesButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ChangeZValues As Nevron.UI.WinForm.Controls.NButton
		Private components As System.ComponentModel.Container = Nothing

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


		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.InflateMarginsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.AxesRoundToTick = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ChangeXValuesButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ChangeZValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' InflateMarginsCheck
			' 
			Me.InflateMarginsCheck.ButtonProperties.BorderOffset = 2
			Me.InflateMarginsCheck.Location = New System.Drawing.Point(5, 100)
			Me.InflateMarginsCheck.Name = "InflateMarginsCheck"
			Me.InflateMarginsCheck.Size = New System.Drawing.Size(170, 21)
			Me.InflateMarginsCheck.TabIndex = 3
			Me.InflateMarginsCheck.Text = "Inflate Margins"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			' 
			' AxesRoundToTick
			' 
			Me.AxesRoundToTick.ButtonProperties.BorderOffset = 2
			Me.AxesRoundToTick.Location = New System.Drawing.Point(5, 73)
			Me.AxesRoundToTick.Name = "AxesRoundToTick"
			Me.AxesRoundToTick.Size = New System.Drawing.Size(170, 20)
			Me.AxesRoundToTick.TabIndex = 2
			Me.AxesRoundToTick.Text = "Axes Round To Tick"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AxesRoundToTick.CheckedChanged += new System.EventHandler(this.AxesRoundToTick_CheckedChanged);
			' 
			' ChangeXValuesButton
			' 
			Me.ChangeXValuesButton.Location = New System.Drawing.Point(5, 9)
			Me.ChangeXValuesButton.Name = "ChangeXValuesButton"
			Me.ChangeXValuesButton.Size = New System.Drawing.Size(170, 24)
			Me.ChangeXValuesButton.TabIndex = 0
			Me.ChangeXValuesButton.Text = "Change X Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeXValuesButton.Click += new System.EventHandler(this.ChangeXValuesButton_Click);
			' 
			' ChangeZValues
			' 
			Me.ChangeZValues.Location = New System.Drawing.Point(5, 39)
			Me.ChangeZValues.Name = "ChangeZValues"
			Me.ChangeZValues.Size = New System.Drawing.Size(170, 23)
			Me.ChangeZValues.TabIndex = 1
			Me.ChangeZValues.Text = "Change Z Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeZValues.Click += new System.EventHandler(this.ChangeYValues_Click);
			' 
			' NXYZScatterPointUC
			' 
			Me.Controls.Add(Me.ChangeZValues)
			Me.Controls.Add(Me.InflateMarginsCheck)
			Me.Controls.Add(Me.AxesRoundToTick)
			Me.Controls.Add(Me.ChangeXValuesButton)
			Me.Name = "NXYZScatterPointUC"
			Me.Size = New System.Drawing.Size(180, 148)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XYZ Scatter Point Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			m_Chart.Depth = 55.0F
			m_Chart.Width = 55.0F
			m_Chart.Height = 55.0F

			' Configure all axes to use linear scale
			Dim linearScale As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)

			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)

			' add interlace stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)

			' setup point series
			m_Point = CType(m_Chart.Series.Add(SeriesType.Point), NPointSeries)
			m_Point.Name = "Point Series"
			m_Point.DataLabelStyle.Visible = False
			m_Point.Legend.Mode = SeriesLegendMode.DataPoints
			m_Point.Legend.Format = "<label>"
			m_Point.PointShape = PointShape.Sphere
			m_Point.BorderStyle.Width = New NLength(0)
			m_Point.UseXValues = True
			m_Point.UseZValues = True

			' add xyz values
			m_Point.AddDataPoint(New NDataPoint(10, 15, 34, "Item1"))
			m_Point.AddDataPoint(New NDataPoint(23, 25, -20, "Item2"))
			m_Point.AddDataPoint(New NDataPoint(12, 45, 45, "Item3"))
			m_Point.AddDataPoint(New NDataPoint(24, 35, -12, "Item4"))
			m_Point.AddDataPoint(New NDataPoint(16, 41, 3, "Item5"))
			m_Point.AddDataPoint(New NDataPoint(17, 15, -34, "Item6"))
			m_Point.AddDataPoint(New NDataPoint(13, -25, -20, "Item7"))
			m_Point.AddDataPoint(New NDataPoint(12, 45, 1, "Item8"))
			m_Point.AddDataPoint(New NDataPoint(4, -21, -12, "Item9"))
			m_Point.AddDataPoint(New NDataPoint(16, -24, 47, "Item10"))

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			AxesRoundToTick.Checked = True
			InflateMarginsCheck.Checked = True
		End Sub

		Private Sub ChangeXValuesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeXValuesButton.Click
			m_Point.XValues.FillRandomRange(Random, 10, -50, 50)
			nChartControl1.Refresh()
		End Sub

		Private Sub ChangeYValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeZValues.Click
			m_Point.ZValues.FillRandomRange(Random, 10, -50, 50)
			nChartControl1.Refresh()
		End Sub

		Private Sub AxesRoundToTick_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AxesRoundToTick.CheckedChanged
			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NLinearScaleConfigurator)

			linearScale.RoundToTickMin = AxesRoundToTick.Checked
			linearScale.RoundToTickMax = AxesRoundToTick.Checked

			linearScale = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			linearScale.RoundToTickMin = AxesRoundToTick.Checked
			linearScale.RoundToTickMax = AxesRoundToTick.Checked

			linearScale = CType(m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator, NLinearScaleConfigurator)

			linearScale.RoundToTickMin = AxesRoundToTick.Checked
			linearScale.RoundToTickMax = AxesRoundToTick.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub InflateMarginsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InflateMarginsCheck.CheckedChanged
			m_Point.InflateMargins = InflateMarginsCheck.Checked
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace