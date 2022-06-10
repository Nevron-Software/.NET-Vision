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
	Public Class NRange3DUC
		Inherits NExampleBaseUC

		Private label1 As System.Windows.Forms.Label
		Private WithEvents ShapeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			ShapeCombo.FillFromEnum(GetType(BarShape))
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.ShapeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(5, 10)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(169, 16)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Shape:"
			' 
			' ShapeCombo
			' 
			Me.ShapeCombo.ListProperties.CheckBoxDataMember = ""
			Me.ShapeCombo.ListProperties.DataSource = Nothing
			Me.ShapeCombo.ListProperties.DisplayMember = ""
			Me.ShapeCombo.Location = New System.Drawing.Point(5, 27)
			Me.ShapeCombo.Name = "ShapeCombo"
			Me.ShapeCombo.Size = New System.Drawing.Size(169, 21)
			Me.ShapeCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShapeCombo.SelectedIndexChanged += new System.EventHandler(this.ShapeCombo_SelectedIndexChanged);
			' 
			' NRange3DUC
			' 
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.ShapeCombo)
			Me.Name = "NRange3DUC"
			Me.Size = New System.Drawing.Size(180, 364)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As New NLabel("3D Range Series")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Projection.Type = ProjectionType.Perspective
			chart.Projection.Rotation = -18
			chart.Projection.Elevation = 13
			chart.Depth = 55.0F
			chart.Width = 55.0F
			chart.Height = 55.0F

			' setup X axis
			Dim linearScale As New NLinearScaleConfigurator()
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			chart.Axis(StandardAxis.PrimaryX).View = New NRangeAxisView(New NRange1DD(0, 20), True, True)

			' setup Y axis
			linearScale = New NLinearScaleConfigurator()
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlaced stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			chart.Axis(StandardAxis.PrimaryY).View = New NRangeAxisView(New NRange1DD(0, 20), True, True)

			' setup Depth axis
			linearScale = New NLinearScaleConfigurator()
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale
			chart.Axis(StandardAxis.Depth).View = New NRangeAxisView(New NRange1DD(0, 20), True, True)

			' setup shape series
			Dim rangeSeries As NRangeSeries = CType(chart.Series.Add(SeriesType.Range), NRangeSeries)
			rangeSeries.FillStyle = New NColorFillStyle(Color.Red)
			rangeSeries.BorderStyle.Color = Color.DarkRed
			rangeSeries.Legend.Mode = SeriesLegendMode.None
			rangeSeries.DataLabelStyle.Visible = False
			rangeSeries.UseXValues = True
			rangeSeries.UseZValues = True

			' add data
			AddDataPoint(rangeSeries, 1, 5, 11, 17, 5, 9)
			AddDataPoint(rangeSeries, 4, 7, 15, 19, 16, 19)
			AddDataPoint(rangeSeries, 5, 15, 6, 11, 12, 18)
			AddDataPoint(rangeSeries, 9, 14, 2, 5, 3, 5)
			AddDataPoint(rangeSeries, 15, 19, 2, 5, 3, 5)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			ShapeCombo.SelectedIndex = 0
		End Sub

		Private Sub AddDataPoint(ByVal series As NRangeSeries, ByVal x1 As Double, ByVal x2 As Double, ByVal y1 As Double, ByVal y2 As Double, ByVal z1 As Double, ByVal z2 As Double)
			series.XValues.Add(x1)
			series.X2Values.Add(x2)
			series.Values.Add(y1)
			series.Y2Values.Add(y2)
			series.ZValues.Add(z1)
			series.Z2Values.Add(z2)
		End Sub

		Private Sub ShapeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShapeCombo.SelectedIndexChanged
			Dim rangeSeries As NRangeSeries = CType(nChartControl1.Charts(0).Series(0), NRangeSeries)
			rangeSeries.Shape = CType(ShapeCombo.SelectedIndex, BarShape)
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
