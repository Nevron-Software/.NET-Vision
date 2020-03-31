Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NAnalogClockUC
		Inherits NExampleBaseUC
		Private components As System.ComponentModel.IContainer

		Private m_Stock As NStockSeries
		Private m_LondonClock As NDockPanel
		Private m_TokyoClock As NDockPanel
		Private WithEvents m_Timer As System.Windows.Forms.Timer
		Private m_NewYorkClock As NDockPanel

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()

		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
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
			Me.components = New System.ComponentModel.Container()
			Me.m_Timer = New System.Windows.Forms.Timer(Me.components)
			Me.SuspendLayout()
			' 
			' timer1
			' 
'			Me.m_Timer.Tick += New System.EventHandler(Me.timer1_Tick);
			' 
			' NAnalogClockUC
			' 
			Me.Name = "NAnalogClockUC"
			Me.Size = New System.Drawing.Size(180, 320)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			nChartControl1.Panels.Clear()
			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Financial Dashboard")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup Stock chart
			Dim stockChart As NCartesianChart = New NCartesianChart()
			SetupStockChart(stockChart)

			stockChart.Size = New NSizeL(New NLength(96, NRelativeUnit.ParentPercentage), New NLength(55, NRelativeUnit.ParentPercentage))
			stockChart.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			nChartControl1.Panels.Add(stockChart)

			' create London clock
			Dim londonPanel As NDockPanel = New NDockPanel()
			londonPanel.Size = New NSizeL(New NLength(30, NRelativeUnit.ParentPercentage), New NLength(30, NRelativeUnit.ParentPercentage))
			londonPanel.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(66, NRelativeUnit.ParentPercentage))

			m_LondonClock = CreateClockPanel(1)
			londonPanel.ChildPanels.Add(CreateClockLabel("London"))
			londonPanel.ChildPanels.Add(m_LondonClock)
			nChartControl1.Panels.Add(londonPanel)

			' create Tokyo clock
			Dim tokyoPanel As NDockPanel = New NDockPanel()
			tokyoPanel.Size = New NSizeL(New NLength(30, NRelativeUnit.ParentPercentage), New NLength(30, NRelativeUnit.ParentPercentage))
			tokyoPanel.Location = New NPointL(New NLength(35, NRelativeUnit.ParentPercentage), New NLength(66, NRelativeUnit.ParentPercentage))
			m_TokyoClock = CreateClockPanel(10)
			tokyoPanel.ChildPanels.Add(CreateClockLabel("Tokyo"))
			tokyoPanel.ChildPanels.Add(m_TokyoClock)
			nChartControl1.Panels.Add(tokyoPanel)

			' create New York clock
			Dim newYorkPanel As NDockPanel = New NDockPanel()
			newYorkPanel.Size = New NSizeL(New NLength(30, NRelativeUnit.ParentPercentage), New NLength(30, NRelativeUnit.ParentPercentage))
			newYorkPanel.Location = New NPointL(New NLength(68, NRelativeUnit.ParentPercentage), New NLength(66, NRelativeUnit.ParentPercentage))
			m_NewYorkClock = CreateClockPanel(-4)
			newYorkPanel.ChildPanels.Add(CreateClockLabel("New York"))
			newYorkPanel.ChildPanels.Add(m_NewYorkClock)
			nChartControl1.Panels.Add(newYorkPanel)

			GenerateOHLCData(m_Stock, 100, 200, New NRange1DD(50, 350))
			nChartControl1.Refresh()

			m_Timer.Interval = 4000
			m_Timer.Start()
		End Sub

		Private Function CreateClockLabel(ByVal text As String) As NLabel
			Dim label As NLabel = New NLabel(text)

			label.TextStyle.FillStyle = New NColorFillStyle(Color.DarkBlue)
			label.DockMode = PanelDockMode.Bottom
			label.ContentAlignment = ContentAlignment.MiddleCenter
			label.BoundsMode = BoundsMode.Fit

			Return label
		End Function

		Private Function CreateIndicator() As NNeedleValueIndicator
			Dim indicator As NNeedleValueIndicator = New NNeedleValueIndicator()

			indicator.Shape.FillStyle = New NGradientFillStyle(Color.White, Color.Red)

			Return indicator
		End Function

		Private Function CreateClockPanel(ByVal timeZone As Integer) As NDockPanel
			' create the radial gauge
			Dim clock As NAnalogClockPanel = New NAnalogClockPanel()
			clock.ContentAlignment = ContentAlignment.MiddleCenter
			clock.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
			clock.Size = New NSizeL(New NLength(100, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))
			clock.ClockDisplayMode = ClockDisplayMode.HourMinute
			clock.ClockTimeMode = ClockTimeMode.UTC
			clock.TimeZone = timeZone
			clock.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			clock.Margins = New NMarginsL(5, 5, 5, 5)
			clock.DockMode = PanelDockMode.Fill

			Return clock
		End Function

		Private Function CreateBackgroundPanel() As NBackgroundDecoratorPanel
			Dim backroundStyle As NBackgroundStyle = New NBackgroundStyle()
			backroundStyle.FillStyle = New NGradientFillStyle(Color.White, Color.LightGray)

			Dim backgroundPanel As NBackgroundDecoratorPanel = New NBackgroundDecoratorPanel()
			backgroundPanel.DockMargins = New NMarginsL(New NLength(5, NGraphicsUnit.Point), New NLength(5, NGraphicsUnit.Point), New NLength(5, NGraphicsUnit.Point), New NLength(5, NGraphicsUnit.Point))
			backgroundPanel.BackgroundStyle = CType(backroundStyle.Clone(), NBackgroundStyle)

			Return backgroundPanel
		End Function

		Private Sub SetupStockChart(ByVal chart As NCartesianChart)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			chart.LightModel.EnableLighting = False
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Wall(ChartWallType.Floor).Visible = False
			chart.Wall(ChartWallType.Left).Visible = False
			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))

			' setup X axis
			Dim axis As NAxis = chart.Axis(StandardAxis.PrimaryX)
			Dim ordinalScale As NOrdinalScaleConfigurator = CType(axis.ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, False)
			ordinalScale.InnerMajorTickStyle.Length = New NLength(0)

			' setup Y axis
			axis = chart.Axis(StandardAxis.PrimaryY)
			Dim linearScale As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, False)
			linearScale.InnerMajorTickStyle.Length = New NLength(0)

			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.StripStyles.Add(stripStyle)

			' setup the stock series
			m_Stock = CType(chart.Series.Add(SeriesType.Stock), NStockSeries)
			m_Stock.Name = "Price"
			m_Stock.Legend.Mode = SeriesLegendMode.None
			m_Stock.DataLabelStyle.Visible = False
			m_Stock.CandleStyle = CandleStyle.Stick
			m_Stock.UpStrokeStyle.Color = Color.RoyalBlue
			m_Stock.OpenValues.Name = "open"
			m_Stock.HighValues.Name = "high"
			m_Stock.LowValues.Name = "low"
			m_Stock.CloseValues.Name = "close"
			m_Stock.CandleWidth = New NLength(0.5f, NRelativeUnit.ParentPercentage)
		End Sub

		Private Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_Timer.Tick
			GenerateOHLCData(m_Stock, 100, 200, New NRange1DD(50, 350))
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
