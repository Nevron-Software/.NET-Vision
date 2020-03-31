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
	<ToolboxItem(False)> _
	Public Class NXYZMultiSeriesPointUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Point1 As NPointSeries
		Private m_Point2 As NPointSeries
		Private m_Point3 As NPointSeries
		Private WithEvents ShowPoint1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowPoint2 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowPoint3 As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.ShowPoint1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowPoint2 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowPoint3 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' ShowPoint1
			' 
			Me.ShowPoint1.ButtonProperties.BorderOffset = 2
			Me.ShowPoint1.Location = New System.Drawing.Point(10, 10)
			Me.ShowPoint1.Name = "ShowPoint1"
			Me.ShowPoint1.Size = New System.Drawing.Size(132, 24)
			Me.ShowPoint1.TabIndex = 0
			Me.ShowPoint1.Text = "Show Point 1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowPoint1.CheckedChanged += new System.EventHandler(this.ShowPoint1_CheckedChanged);
			' 
			' ShowPoint2
			' 
			Me.ShowPoint2.ButtonProperties.BorderOffset = 2
			Me.ShowPoint2.Location = New System.Drawing.Point(10, 37)
			Me.ShowPoint2.Name = "ShowPoint2"
			Me.ShowPoint2.Size = New System.Drawing.Size(132, 24)
			Me.ShowPoint2.TabIndex = 1
			Me.ShowPoint2.Text = "Show Point 2"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowPoint2.CheckedChanged += new System.EventHandler(this.ShowPoint2_CheckedChanged);
			' 
			' ShowPoint3
			' 
			Me.ShowPoint3.ButtonProperties.BorderOffset = 2
			Me.ShowPoint3.Location = New System.Drawing.Point(10, 64)
			Me.ShowPoint3.Name = "ShowPoint3"
			Me.ShowPoint3.Size = New System.Drawing.Size(132, 24)
			Me.ShowPoint3.TabIndex = 2
			Me.ShowPoint3.Text = "Show Point 3"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowPoint3.CheckedChanged += new System.EventHandler(this.ShowPoint3_CheckedChanged);
			' 
			' NXYZMultiSeriesPointUC
			' 
			Me.Controls.Add(Me.ShowPoint3)
			Me.Controls.Add(Me.ShowPoint2)
			Me.Controls.Add(Me.ShowPoint1)
			Me.Name = "NXYZMultiSeriesPointUC"
			Me.Size = New System.Drawing.Size(180, 115)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Multiple XYZ Scatter Point Series")
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

			' add point series
			m_Point1 = CType(m_Chart.Series.Add(SeriesType.Point), NPointSeries)
			m_Point1.Name = "Point 1"
			m_Point1.PointShape = PointShape.Bar
			m_Point1.Size = New NLength(2.4F, NRelativeUnit.ParentPercentage)
			m_Point1.DataLabelStyle.Visible = False
			m_Point1.UseXValues = True
			m_Point1.UseZValues = True
			m_Point1.InflateMargins = True

			m_Point2 = CType(m_Chart.Series.Add(SeriesType.Point), NPointSeries)
			m_Point2.Name = "Point 2"
			m_Point2.PointShape = PointShape.Bar
			m_Point2.Size = New NLength(2.4F, NRelativeUnit.ParentPercentage)
			m_Point2.DataLabelStyle.Visible = False
			m_Point2.UseXValues = True
			m_Point2.UseZValues = True
			m_Point2.InflateMargins = True

			m_Point3 = CType(m_Chart.Series.Add(SeriesType.Point), NPointSeries)
			m_Point3.Name = "Point 3"
			m_Point3.PointShape = PointShape.Bar
			m_Point3.Size = New NLength(2.4F, NRelativeUnit.ParentPercentage)
			m_Point3.DataLabelStyle.Visible = False
			m_Point3.UseXValues = True
			m_Point3.UseZValues = True
			m_Point3.InflateMargins = True

			' fill with random data 
			m_Point1.Values.FillRandomRange(Random, 10, 0, 50)
			m_Point1.XValues.FillRandomRange(Random, 10, 0, 50)
			m_Point1.ZValues.FillRandomRange(Random, 10, 0, 50)

			m_Point2.Values.FillRandomRange(Random, 10, 25, 75)
			m_Point2.XValues.FillRandomRange(Random, 10, 25, 75)
			m_Point2.ZValues.FillRandomRange(Random, 10, 25, 75)

			m_Point3.Values.FillRandomRange(Random, 10, 75, 125)
			m_Point3.XValues.FillRandomRange(Random, 10, 75, 125)
			m_Point3.ZValues.FillRandomRange(Random, 10, 75, 125)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			ShowPoint1.Checked = True
			ShowPoint2.Checked = True
			ShowPoint3.Checked = True
		End Sub

		Private Sub ShowPoint1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowPoint1.CheckedChanged
			m_Point1.Visible = ShowPoint1.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub ShowPoint2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowPoint2.CheckedChanged
			m_Point2.Visible = ShowPoint2.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub ShowPoint3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowPoint3.CheckedChanged
			m_Point3.Visible = ShowPoint3.Checked
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
