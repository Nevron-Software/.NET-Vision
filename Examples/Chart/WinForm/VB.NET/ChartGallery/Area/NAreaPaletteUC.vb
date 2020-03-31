Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Dom


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NAreaPaletteUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Area As NAreaSeries
		Private m_IndicatorPhase() As Double
		Private m_AxisRange As NRange1DD
		Private WithEvents timer1 As Timer
		Private WithEvents InvertAxisCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents SmoothPaletteCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents StartStopTimerButton As UI.WinForm.Controls.NButton
		Private WithEvents Enable3DCheckBox As UI.WinForm.Controls.NCheckBox
		Private components As IContainer

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
			Me.components = New System.ComponentModel.Container()
			Me.timer1 = New System.Windows.Forms.Timer(Me.components)
			Me.InvertAxisCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SmoothPaletteCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.StartStopTimerButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.Enable3DCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' timer1
			' 
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			' 
			' InvertAxisCheckBox
			' 
			Me.InvertAxisCheckBox.ButtonProperties.BorderOffset = 2
			Me.InvertAxisCheckBox.ButtonProperties.ShowFocusRect = False
			Me.InvertAxisCheckBox.ButtonProperties.WrapText = True
			Me.InvertAxisCheckBox.Location = New System.Drawing.Point(9, 12)
			Me.InvertAxisCheckBox.Name = "InvertAxisCheckBox"
			Me.InvertAxisCheckBox.Size = New System.Drawing.Size(139, 18)
			Me.InvertAxisCheckBox.TabIndex = 2
			Me.InvertAxisCheckBox.Text = "Invert Axis"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InvertAxisCheckBox.CheckedChanged += new System.EventHandler(this.InvertAxisCheckBox_CheckedChanged);
			' 
			' SmoothPaletteCheckBox
			' 
			Me.SmoothPaletteCheckBox.ButtonProperties.BorderOffset = 2
			Me.SmoothPaletteCheckBox.ButtonProperties.ShowFocusRect = False
			Me.SmoothPaletteCheckBox.ButtonProperties.WrapText = True
			Me.SmoothPaletteCheckBox.Location = New System.Drawing.Point(9, 34)
			Me.SmoothPaletteCheckBox.Name = "SmoothPaletteCheckBox"
			Me.SmoothPaletteCheckBox.Size = New System.Drawing.Size(139, 18)
			Me.SmoothPaletteCheckBox.TabIndex = 3
			Me.SmoothPaletteCheckBox.Text = "Smooth Palette"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SmoothPaletteCheckBox.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheckBox_CheckedChanged);
			' 
			' StartStopTimerButton
			' 
			Me.StartStopTimerButton.Location = New System.Drawing.Point(9, 91)
			Me.StartStopTimerButton.Name = "StartStopTimerButton"
			Me.StartStopTimerButton.Size = New System.Drawing.Size(152, 32)
			Me.StartStopTimerButton.TabIndex = 5
			Me.StartStopTimerButton.Text = "Stop Timer"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StartStopTimerButton.Click += new System.EventHandler(this.StartStopTimerButton_Click);
			' 
			' Enable3DCheckBox
			' 
			Me.Enable3DCheckBox.ButtonProperties.BorderOffset = 2
			Me.Enable3DCheckBox.ButtonProperties.ShowFocusRect = False
			Me.Enable3DCheckBox.ButtonProperties.WrapText = True
			Me.Enable3DCheckBox.Location = New System.Drawing.Point(9, 56)
			Me.Enable3DCheckBox.Name = "Enable3DCheckBox"
			Me.Enable3DCheckBox.Size = New System.Drawing.Size(139, 18)
			Me.Enable3DCheckBox.TabIndex = 4
			Me.Enable3DCheckBox.Text = "Enable 3D"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Enable3DCheckBox.CheckedChanged += new System.EventHandler(this.Enable3DCheckBox_CheckedChanged);
			' 
			' NAreaPaletteUC
			' 
			Me.Controls.Add(Me.Enable3DCheckBox)
			Me.Controls.Add(Me.StartStopTimerButton)
			Me.Controls.Add(Me.SmoothPaletteCheckBox)
			Me.Controls.Add(Me.InvertAxisCheckBox)
			Me.Name = "NAreaPaletteUC"
			Me.Size = New System.Drawing.Size(170, 358)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Area Palette")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' add interlace stripe
			Dim yAxis As NAxis = m_Chart.Axis(StandardAxis.PrimaryY)
			Dim linearScale As NLinearScaleConfigurator = TryCast(yAxis.ScaleConfigurator, NLinearScaleConfigurator)
			Dim strip As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			strip.Interlaced = True
			'linearScale.Strips.Add(strip);

			' setup a area series
			m_Area = New NAreaSeries()
			m_Area.InflateMargins = True
			m_Area.DataLabelStyle.Visible = False
			m_Area.BorderStyle.Width = New NLength(0)
			m_Area.Legend.Mode = SeriesLegendMode.None

			Dim palette As New NPalette()
			palette.Clear()
			palette.Mode = PaletteMode.Custom
			palette.Add(0, Color.Green)
			palette.Add(60, Color.Yellow)
			palette.Add(120, Color.Red)

			m_Area.Palette = palette

			m_AxisRange = New NRange1DD(0, 130)

			' limit the axis range to 0, 130
			yAxis.View = New NRangeAxisView(m_AxisRange, True, True)
			m_Chart.Series.Add(m_Area)

			Dim indicatorCount As Integer = 10
			m_IndicatorPhase = New Double(indicatorCount - 1){}

			' add some data to the area series
			For i As Integer = 0 To indicatorCount - 1
				m_IndicatorPhase(i) = i * 30
				m_Area.Values.Add(0)
			Next i

			SmoothPaletteCheckBox.Checked = True

			timer1.Start()
		End Sub

		Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
'INSTANT VB NOTE: The variable random was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim random_Renamed As New Random()

			For i As Integer = 0 To m_Area.Values.Count - 1
				Dim value As Double = (m_AxisRange.Begin + m_AxisRange.End) / 2.0 + Math.Sin(m_IndicatorPhase(i) * NMath.Degree2Rad) * m_AxisRange.GetLength() / 2 + random_Renamed.Next(20)
				value = m_AxisRange.GetValueInRange(value)

				m_Area.Values(i) = value
				m_IndicatorPhase(i) += 10
			Next i

			nChartControl1.Refresh()
		End Sub

		Private Sub StartStopTimerButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StartStopTimerButton.Click
			If StartStopTimerButton.Text.StartsWith("Stop") Then
				StartStopTimerButton.Text = "Start Timer"
				timer1.Stop()
			Else
				timer1.Start()
				StartStopTimerButton.Text = "Stop Timer"
			End If
		End Sub

		Private Sub SmoothPaletteCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SmoothPaletteCheckBox.CheckedChanged
			m_Area.Palette.SmoothPalette = SmoothPaletteCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub InvertAxisCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InvertAxisCheckBox.CheckedChanged
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Invert = InvertAxisCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub Enable3DCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Enable3DCheckBox.CheckedChanged
			m_Chart.Enable3D = Enable3DCheckBox.Checked
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
