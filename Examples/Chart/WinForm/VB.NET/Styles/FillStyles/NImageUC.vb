Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Resources
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NImageUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bubble As NBubbleSeries
		Private WithEvents ChooseImageBars As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ChooseImageWalls As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents NewDataButton As Nevron.UI.WinForm.Controls.NButton
		Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
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
			Me.ChooseImageBars = New Nevron.UI.WinForm.Controls.NButton()
			Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
			Me.ChooseImageWalls = New Nevron.UI.WinForm.Controls.NButton()
			Me.NewDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' ChooseImageBars
			' 
			Me.ChooseImageBars.Location = New System.Drawing.Point(8, 59)
			Me.ChooseImageBars.Name = "ChooseImageBars"
			Me.ChooseImageBars.Size = New System.Drawing.Size(173, 23)
			Me.ChooseImageBars.TabIndex = 0
			Me.ChooseImageBars.Text = "Choose Bubbles Texture..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChooseImageBars.Click += new System.EventHandler(this.ChooseImageBars_Click);
			' 
			' ChooseImageWalls
			' 
			Me.ChooseImageWalls.Location = New System.Drawing.Point(8, 88)
			Me.ChooseImageWalls.Name = "ChooseImageWalls"
			Me.ChooseImageWalls.Size = New System.Drawing.Size(173, 23)
			Me.ChooseImageWalls.TabIndex = 1
			Me.ChooseImageWalls.Text = "Choose Walls Texture..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChooseImageWalls.Click += new System.EventHandler(this.ChooseImageWalls_Click);
			' 
			' NewDataButton
			' 
			Me.NewDataButton.Location = New System.Drawing.Point(8, 8)
			Me.NewDataButton.Name = "NewDataButton"
			Me.NewDataButton.Size = New System.Drawing.Size(173, 23)
			Me.NewDataButton.TabIndex = 2
			Me.NewDataButton.Text = "New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.NewDataButton.Click += new System.EventHandler(this.NewDataButton_Click);
			' 
			' NImageUC
			' 
			Me.Controls.Add(Me.NewDataButton)
			Me.Controls.Add(Me.ChooseImageWalls)
			Me.Controls.Add(Me.ChooseImageBars)
			Me.Name = "NImageUC"
			Me.Size = New System.Drawing.Size(188, 460)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' load textures from resources
			Dim bmp0 As Bitmap = NResourceHelper.BitmapFromResource(Me.GetType(), "Back.png", "Nevron.Examples.Chart.WinForm.Resources")
			Dim bmp1 As Bitmap = NResourceHelper.BitmapFromResource(Me.GetType(), "Leafs.png", "Nevron.Examples.Chart.WinForm.Resources")
			Dim bmp2 As Bitmap = NResourceHelper.BitmapFromResource(Me.GetType(), "Banner.png", "Nevron.Examples.Chart.WinForm.Resources")

			Dim imageFillStyle As New NImageFillStyle(bmp0)
			imageFillStyle.TextureMappingStyle.MapLayout = MapLayout.Tiled

			nChartControl1.BackgroundStyle.FillStyle = imageFillStyle

			' add label
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Image Fill Style")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))


			' setup chart and axes
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftTopLeft)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.LineStyle.Color = Color.White

			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale


			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.LineStyle.Color = Color.White
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' Setup walls
			Dim c As Color = Color.FromArgb(128, 128, 192)
			imageFillStyle = New NImageFillStyle(bmp1)
			imageFillStyle.TextureMappingStyle.MapLayout = MapLayout.Tiled

			m_Chart.Wall(ChartWallType.Back).FillStyle = imageFillStyle
			m_Chart.Wall(ChartWallType.Left).FillStyle = imageFillStyle
			m_Chart.Wall(ChartWallType.Floor).FillStyle = imageFillStyle

			' create bubble chart
			m_Bubble = CType(m_Chart.Series.Add(SeriesType.Bubble), NBubbleSeries)
			m_Bubble.DataLabelStyle.Visible = False
			m_Bubble.Legend.Mode = SeriesLegendMode.DataPoints
			m_Bubble.BubbleShape = PointShape.Ellipse
			m_Bubble.UseXValues = True
			m_Bubble.InflateMargins = True
			m_Bubble.BorderStyle.Width = New NLength(1, NGraphicsUnit.Pixel)
			m_Bubble.FillStyle = New NImageFillStyle(bmp2)

			GenerateData()
		End Sub

		Private Sub GenerateData()
			m_Bubble.Values.FillRandomRange(Random, 5, -20, 20)
			m_Bubble.XValues.FillRandomRange(Random, 5, -20, 20)
			m_Bubble.Sizes.FillRandomRange(Random, 5, 1, 100)
		End Sub

		Private Sub ChooseImageBars_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChooseImageBars.Click
			If openFileDialog1.ShowDialog() = DialogResult.OK Then
				m_Bubble.FillStyle = New NImageFillStyle(openFileDialog1.FileName)
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub ChooseImageWalls_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChooseImageWalls.Click
			If openFileDialog1.ShowDialog() = DialogResult.OK Then
				Dim imageFillStyle As New NImageFillStyle(openFileDialog1.FileName)

				m_Chart.Wall(ChartWallType.Back).FillStyle = imageFillStyle
				m_Chart.Wall(ChartWallType.Left).FillStyle = imageFillStyle
				m_Chart.Wall(ChartWallType.Floor).FillStyle = imageFillStyle

				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub NewDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewDataButton.Click
			GenerateData()
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace