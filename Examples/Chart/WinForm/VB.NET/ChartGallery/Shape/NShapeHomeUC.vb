Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Resources
Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NShapeHomeUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private WithEvents HouseFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents RoofFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ChimneyFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents DoorFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents WindowFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private openFileDlg As System.Windows.Forms.OpenFileDialog
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
			Me.HouseFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.RoofFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ChimneyFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.DoorFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.WindowFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.openFileDlg = New System.Windows.Forms.OpenFileDialog()
			Me.SuspendLayout()
			' 
			' HouseFillStyleButton
			' 
			Me.HouseFillStyleButton.Location = New System.Drawing.Point(5, 9)
			Me.HouseFillStyleButton.Name = "HouseFillStyleButton"
			Me.HouseFillStyleButton.Size = New System.Drawing.Size(169, 26)
			Me.HouseFillStyleButton.TabIndex = 0
			Me.HouseFillStyleButton.Text = "House Fill Style"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HouseFillStyleButton.Click += new System.EventHandler(this.HouseFillStyleButton_Click);
			' 
			' RoofFillStyleButton
			' 
			Me.RoofFillStyleButton.Location = New System.Drawing.Point(5, 40)
			Me.RoofFillStyleButton.Name = "RoofFillStyleButton"
			Me.RoofFillStyleButton.Size = New System.Drawing.Size(169, 26)
			Me.RoofFillStyleButton.TabIndex = 1
			Me.RoofFillStyleButton.Text = "Roof Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RoofFillStyleButton.Click += new System.EventHandler(this.RoofFillStyleButton_Click);
			' 
			' ChimneyFillStyleButton
			' 
			Me.ChimneyFillStyleButton.Location = New System.Drawing.Point(5, 71)
			Me.ChimneyFillStyleButton.Name = "ChimneyFillStyleButton"
			Me.ChimneyFillStyleButton.Size = New System.Drawing.Size(169, 26)
			Me.ChimneyFillStyleButton.TabIndex = 2
			Me.ChimneyFillStyleButton.Text = "Chimney Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChimneyFillStyleButton.Click += new System.EventHandler(this.ChimneyFillStyleButton_Click);
			' 
			' DoorFillStyleButton
			' 
			Me.DoorFillStyleButton.Location = New System.Drawing.Point(5, 102)
			Me.DoorFillStyleButton.Name = "DoorFillStyleButton"
			Me.DoorFillStyleButton.Size = New System.Drawing.Size(169, 26)
			Me.DoorFillStyleButton.TabIndex = 3
			Me.DoorFillStyleButton.Text = "Door Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DoorFillStyleButton.Click += new System.EventHandler(this.DoorFillStyleButton_Click);
			' 
			' WindowFillStyleButton
			' 
			Me.WindowFillStyleButton.Location = New System.Drawing.Point(5, 133)
			Me.WindowFillStyleButton.Name = "WindowFillStyleButton"
			Me.WindowFillStyleButton.Size = New System.Drawing.Size(169, 26)
			Me.WindowFillStyleButton.TabIndex = 4
			Me.WindowFillStyleButton.Text = "Window Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WindowFillStyleButton.Click += new System.EventHandler(this.WindowFillStyleButton_Click);
			' 
			' NShapeHomeUC
			' 
			Me.Controls.Add(Me.WindowFillStyleButton)
			Me.Controls.Add(Me.DoorFillStyleButton)
			Me.Controls.Add(Me.ChimneyFillStyleButton)
			Me.Controls.Add(Me.RoofFillStyleButton)
			Me.Controls.Add(Me.HouseFillStyleButton)
			Me.Name = "NShapeHomeUC"
			Me.Size = New System.Drawing.Size(180, 197)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Shape Series used to display a house")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Depth = 55.0F
			m_Chart.Width = 55.0F
			m_Chart.Height = 55.0F
			m_Chart.Projection.Type = ProjectionType.Perspective
			m_Chart.Projection.Rotation = -19.0F
			m_Chart.Projection.Elevation = 20.0F

			' configure axes
			Dim linearScale As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorTickMode = MajorTickMode.AutoMaxCount
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)

			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.MajorTickMode = MajorTickMode.AutoMaxCount
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)

			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale
			linearScale.MajorTickMode = MajorTickMode.AutoMaxCount
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)

			Dim legend As NLegend = CType(nChartControl1.Legends(0), NLegend)
			legend.Data.MarkSize = New NSizeL(20, 20)

			' create the door
			Dim shape As NShapeSeries = CType(m_Chart.Series.Add(SeriesType.Shape), NShapeSeries)
			shape.Name = "door"
			shape.DataLabelStyle.Visible = False
			shape.UseXValues = True
			shape.UseZValues = True
			shape.Shape = BarShape.Bar
			shape.AddDataPoint(New NShapeDataPoint(-0.5, -0.25, -1.0, 0.5, 1.5, 0.02))

			Dim doorFS As New NImageFillStyle(NResourceHelper.BitmapFromResource(Me.GetType(), "Door.jpg", "Nevron.Examples.Chart.WinForm.Resources"))
			shape.FillStyle = doorFS

			' create the window
			shape = CType(m_Chart.Series.Add(SeriesType.Shape), NShapeSeries)
			shape.Name = "window"
			shape.DataLabelStyle.Visible = False
			shape.UseXValues = True
			shape.UseZValues = True
			shape.Shape = BarShape.Bar
			shape.AddDataPoint(New NShapeDataPoint(0.4, 0.0, -1.0, 0.75, 1.0, 0.02))

			Dim windowFS As New NImageFillStyle(NResourceHelper.BitmapFromResource(Me.GetType(), "Window.jpg", "Nevron.Examples.Chart.WinForm.Resources"))
			shape.FillStyle = windowFS

			' create the house
			shape = CType(m_Chart.Series.Add(SeriesType.Shape), NShapeSeries)
			shape.Name = "house"
			shape.DataLabelStyle.Visible = False
			shape.UseXValues = True
			shape.UseZValues = True
			shape.Shape = BarShape.Bar
			shape.AddDataPoint(New NShapeDataPoint(0.0, 0.0, 0.0, 2.0, 2.0, 2.0))
			shape.FillStyle = New NColorFillStyle(Color.White)

			Dim houseFS As New NImageFillStyle(NResourceHelper.BitmapFromResource(Me.GetType(), "Cobblestone.jpg", "Nevron.Examples.Chart.WinForm.Resources"))

			houseFS.TextureMappingStyle.MapLayout = MapLayout.Tiled
			houseFS.TextureMappingStyle.HorizontalScale = 0.1F
			houseFS.TextureMappingStyle.VerticalScale = 0.1F

			shape.FillStyle = houseFS

			' create the roof
			shape = CType(m_Chart.Series.Add(SeriesType.Shape), NShapeSeries)
			shape.Name = "roof"
			shape.DataLabelStyle.Visible = False
			shape.UseXValues = True
			shape.UseZValues = True
			shape.Shape = BarShape.Pyramid
			shape.AddDataPoint(New NShapeDataPoint(0.0, 1.5, 0.0, 2.4, 1.0, 2.4))

			Dim roofFS As New NImageFillStyle(NResourceHelper.BitmapFromResource(Me.GetType(), "Rooftile.jpg", "Nevron.Examples.Chart.WinForm.Resources"))

			roofFS.TextureMappingStyle.MapLayout = MapLayout.Tiled
			roofFS.TextureMappingStyle.HorizontalScale = 0.2F
			roofFS.TextureMappingStyle.VerticalScale = 0.2F

			shape.FillStyle = roofFS

			' create the chimney
			shape = CType(m_Chart.Series.Add(SeriesType.Shape), NShapeSeries)
			shape.Name = "chimney"
			shape.DataLabelStyle.Visible = False
			shape.UseXValues = True
			shape.UseZValues = True
			shape.Shape = BarShape.Cylinder
			shape.AddDataPoint(New NShapeDataPoint(0.75, 1.5, 0.0, 0.2, 1.0, 0.2))

			Dim chimneyFS As New NImageFillStyle(NResourceHelper.BitmapFromResource(Me.GetType(), "Bricks.jpg", "Nevron.Examples.Chart.WinForm.Resources"))

			chimneyFS.TextureMappingStyle.MapLayout = MapLayout.Tiled
			chimneyFS.TextureMappingStyle.HorizontalScale = 0.1F
			chimneyFS.TextureMappingStyle.VerticalScale = 0.1F

			shape.FillStyle = chimneyFS

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))
		End Sub

		Private Sub DoorFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DoorFillStyleButton.Click
			Dim shape As NShapeSeries = CType(m_Chart.Series(0), NShapeSeries)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(shape.FillStyle, fillStyleResult) Then
				shape.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub WindowFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles WindowFillStyleButton.Click
			Dim shape As NShapeSeries = CType(m_Chart.Series(1), NShapeSeries)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(shape.FillStyle, fillStyleResult) Then
				shape.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub HouseFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles HouseFillStyleButton.Click
			Dim shape As NShapeSeries = CType(m_Chart.Series(2), NShapeSeries)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(shape.FillStyle, fillStyleResult) Then
				shape.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub RoofFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RoofFillStyleButton.Click
			Dim shape As NShapeSeries = CType(m_Chart.Series(3), NShapeSeries)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(shape.FillStyle, fillStyleResult) Then
				shape.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub ChimneyFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChimneyFillStyleButton.Click
			Dim shape As NShapeSeries = CType(m_Chart.Series(4), NShapeSeries)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(shape.FillStyle, fillStyleResult) Then
				shape.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
