Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NXYZScatterBubbleUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bubble As NBubbleSeries
		Private WithEvents buttonChangeData As Nevron.UI.WinForm.Controls.NButton
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
			Me.buttonChangeData = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' buttonChangeData
			' 
			Me.buttonChangeData.Location = New System.Drawing.Point(8, 8)
			Me.buttonChangeData.Name = "buttonChangeData"
			Me.buttonChangeData.Size = New System.Drawing.Size(158, 32)
			Me.buttonChangeData.TabIndex = 2
			Me.buttonChangeData.Text = "Change Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.buttonChangeData.Click += new System.EventHandler(this.buttonChangeData_Click);
			' 
			' NXYZScatterBubbleUC
			' 
			Me.Controls.Add(Me.buttonChangeData)
			Me.Name = "NXYZScatterBubbleUC"
			Me.Size = New System.Drawing.Size(180, 150)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As New NLabel("XYZ Bubble Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Width = 50
			m_Chart.Depth = 50
			m_Chart.Height = 50
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			Dim depthScale As New NLinearScaleConfigurator()
			depthScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			depthScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			depthScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = depthScale

			Dim yScale As New NLinearScaleConfigurator()
			yScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)

			' add interlace style
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(New NArgbColor(Color.Beige)), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			yScale.StripStyles.Add(stripStyle)
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = yScale

			' switch the x axis in linear mode
			Dim xScale As New NLinearScaleConfigurator()
			xScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale

			m_Bubble = CType(m_Chart.Series.Add(SeriesType.Bubble), NBubbleSeries)
			m_Bubble.InflateMargins = True
			m_Bubble.DataLabelStyle.Visible = False
			m_Bubble.BubbleShape = PointShape.Sphere
			m_Bubble.Legend.Format = "x:<xvalue> y:<value> z:<zvalue> sz:<size>"
			m_Bubble.Legend.Mode = SeriesLegendMode.DataPoints
			m_Bubble.MinSize = New NLength(10.0F, NRelativeUnit.ParentPercentage)
			m_Bubble.MaxSize = New NLength(20.0F, NRelativeUnit.ParentPercentage)
			m_Bubble.UseXValues = True
			m_Bubble.UseZValues = True
			m_Bubble.Values.ValueFormatter = New NNumericValueFormatter("0.#")
			m_Bubble.XValues.ValueFormatter = New NNumericValueFormatter("0.#")
			m_Bubble.ZValues.ValueFormatter = New NNumericValueFormatter("0.#")
			m_Bubble.Sizes.ValueFormatter = New NNumericValueFormatter("0.#")

			GenerateData()

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Sub GenerateData()
			m_Bubble.Values.Clear()
			m_Bubble.XValues.Clear()
			m_Bubble.ZValues.Clear()
			m_Bubble.Sizes.Clear()

			For i As Integer = 0 To 3
				m_Bubble.Values.Add(Random.NextDouble() * 5)
				m_Bubble.XValues.Add(Random.NextDouble() * 5)
				m_Bubble.ZValues.Add(Random.NextDouble() * 5)
				m_Bubble.Sizes.Add(Random.NextDouble())
			Next i
		End Sub

		Private Sub buttonChangeData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonChangeData.Click
			GenerateData()
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace

