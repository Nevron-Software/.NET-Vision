Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NAdvancedGradientUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bubble As NBubbleSeries
		Private m_nCurrentGradient As Integer
		Private WithEvents NewDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ChangeGradientButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.NewDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ChangeGradientButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' NewDataButton
			' 
			Me.NewDataButton.Location = New System.Drawing.Point(8, 7)
			Me.NewDataButton.Name = "NewDataButton"
			Me.NewDataButton.Size = New System.Drawing.Size(151, 32)
			Me.NewDataButton.TabIndex = 0
			Me.NewDataButton.Text = "New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.NewDataButton.Click += new System.EventHandler(this.NewDataButton_Click);
			' 
			' ChangeGradientButton
			' 
			Me.ChangeGradientButton.Location = New System.Drawing.Point(8, 54)
			Me.ChangeGradientButton.Name = "ChangeGradientButton"
			Me.ChangeGradientButton.Size = New System.Drawing.Size(151, 32)
			Me.ChangeGradientButton.TabIndex = 1
			Me.ChangeGradientButton.Text = "Change Gradient"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeGradientButton.Click += new System.EventHandler(this.ChangeGradientButton_Click);
			' 
			' NAdvancedGradientUC
			' 
			Me.Controls.Add(Me.ChangeGradientButton)
			Me.Controls.Add(Me.NewDataButton)
			Me.Name = "NAdvancedGradientUC"
			Me.Size = New System.Drawing.Size(167, 494)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.BackgroundStyle.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant2, Color.White, Color.FromArgb(230, 230, 244))

			' add label
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Advanced Gradient Fill Style")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart and axes
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftTopLeft)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			Dim linearScale As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.LineStyle.Color = Color.White

			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.LineStyle.Color = Color.White
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' set walls advanced gradient
			Dim ag As NAdvancedGradientFillStyle = AzureLight()

			m_Chart.Wall(ChartWallType.Back).FillStyle = ag
			m_Chart.Wall(ChartWallType.Left).FillStyle = ag
			m_Chart.Wall(ChartWallType.Floor).FillStyle = ag

			' create bubble chart
			m_Bubble = CType(m_Chart.Series.Add(SeriesType.Bubble), NBubbleSeries)
			m_Bubble.DataLabelStyle.Visible = False
			m_Bubble.Legend.Mode = SeriesLegendMode.DataPoints
			m_Bubble.BubbleShape = PointShape.Sphere
			m_Bubble.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			m_Bubble.UseXValues = True
			m_Bubble.InflateMargins = True
			m_Bubble.FillStyle = TheEye()

			GenerateData()
		End Sub

		Private Sub GenerateData()
			m_Bubble.Values.FillRandomRange(Random, 5, -20, 20)
			m_Bubble.XValues.FillRandomRange(Random, 5, -20, 20)
			m_Bubble.Sizes.FillRandomRange(Random, 5, 1, 100)
		End Sub

		Private Function TheEye() As NAdvancedGradientFillStyle
			Dim ag As New NAdvancedGradientFillStyle()

			ag.BackgroundColor = Color.FromArgb(64, 0, 128)

			ag.Points.Add(New NAdvancedGradientPoint(Color.FromArgb(128, 128, 255), 50, 50, 0, 51, AGPointShape.Circle))
			ag.Points.Add(New NAdvancedGradientPoint(Color.White, 50, 50, 0, 49, AGPointShape.Line))
			ag.Points.Add(New NAdvancedGradientPoint(Color.FromArgb(0, 0, 64), 50, 50, 0, 23, AGPointShape.Circle))
			ag.Points.Add(New NAdvancedGradientPoint(Color.Black, 50, 50, 0, 13, AGPointShape.Circle))

			Return ag
		End Function

		Private Function Medusa() As NAdvancedGradientFillStyle
			Dim ag As New NAdvancedGradientFillStyle()

			ag.BackgroundColor = Color.FromArgb(0, 0, 64)

			ag.Points.Add(New NAdvancedGradientPoint(Color.FromArgb(0, 128, 255), 12, 57, 0, 60, AGPointShape.Circle))
			ag.Points.Add(New NAdvancedGradientPoint(Color.White, 29, 29, 0, 35, AGPointShape.Circle))
			ag.Points.Add(New NAdvancedGradientPoint(Color.FromArgb(0, 128, 255), 57, 12, 0, 60, AGPointShape.Circle))
			ag.Points.Add(New NAdvancedGradientPoint(Color.FromArgb(128, 0, 255), 60, 60, 0, 37, AGPointShape.Circle))
			ag.Points.Add(New NAdvancedGradientPoint(Color.White, 84, 84, 0, 50, AGPointShape.Circle))

			Return ag
		End Function

		Private Function Reactor() As NAdvancedGradientFillStyle
			Dim ag As New NAdvancedGradientFillStyle()

			ag.BackgroundColor = Color.Black

			ag.Points.Add(New NAdvancedGradientPoint(Color.FromArgb(255, 128, 255), 50, 78, 0, 35, AGPointShape.Line))
			ag.Points.Add(New NAdvancedGradientPoint(Color.FromArgb(128, 128, 255), 50, 22, 0, 35, AGPointShape.Line))
			ag.Points.Add(New NAdvancedGradientPoint(Color.White, 50, 50, 0, 52, AGPointShape.Circle))

			Return ag
		End Function

		Private Function Flow() As NAdvancedGradientFillStyle
			Dim ag As New NAdvancedGradientFillStyle()

			ag.BackgroundColor = Color.FromArgb(64, 0, 128)

			ag.Points.Add(New NAdvancedGradientPoint(Color.FromArgb(255, 255, 128), 38, 17, 50, 48, AGPointShape.Line))
			ag.Points.Add(New NAdvancedGradientPoint(Color.FromArgb(255, 0, 128), 58, 74, 0, 100, AGPointShape.Line))

			Return ag
		End Function

		Private Function AzureLight() As NAdvancedGradientFillStyle
			Dim ag As New NAdvancedGradientFillStyle()

			ag.BackgroundColor = Color.White

			ag.Points.Add(New NAdvancedGradientPoint(Color.FromArgb(235, 168, 255), 87, 29, 0, 92, AGPointShape.Circle))
			ag.Points.Add(New NAdvancedGradientPoint(Color.FromArgb(64, 199, 255), 53, 82, 0, 81, AGPointShape.Circle))
			ag.Points.Add(New NAdvancedGradientPoint(Color.White, 16, 17, 0, 100, AGPointShape.Circle))

			Return ag
		End Function

		Private Sub NewDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewDataButton.Click
			GenerateData()
			nChartControl1.Refresh()
		End Sub

		Private Sub ChangeGradientButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeGradientButton.Click
			Dim ag As NAdvancedGradientFillStyle

			m_nCurrentGradient += 1

			If m_nCurrentGradient = 4 Then
				m_nCurrentGradient = 0
			End If

			Select Case m_nCurrentGradient
				Case 0
					ag = TheEye()
				Case 1
					ag = Medusa()
				Case 2
					ag = Reactor()
				Case 3
					ag = Flow()
				Case Else
					ag = TheEye()
			End Select

			m_Bubble.FillStyle = ag
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace