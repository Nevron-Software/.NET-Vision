Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.UI.WinForm.Controls

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NRealTimePolarUC
		Inherits NRealTimeExampleBaseUC
		Private WithEvents StopStartTimerButton As NButton
		Private WithEvents UseHardwareAccelerationCheckBox As NCheckBox
		Private components As IContainer
		Private m_PolarSeries As NPolarPointSeries
		Private m_RadarRay As NAxisConstLine()

		Public Sub New()
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
			Me.StopStartTimerButton = New NButton()
			Me.UseHardwareAccelerationCheckBox = New NCheckBox()
			Me.SuspendLayout()

			' 
			' StopStartTimerButton
			' 
			Me.StopStartTimerButton.Location = New System.Drawing.Point(14, 42)
			Me.StopStartTimerButton.Name = "StopStartTimerButton"
			Me.StopStartTimerButton.Size = New System.Drawing.Size(169, 23)
			Me.StopStartTimerButton.TabIndex = 1
			Me.StopStartTimerButton.Text = "Stop Timer"
			Me.StopStartTimerButton.UseVisualStyleBackColor = True
'			Me.StopStartTimerButton.Click += New System.EventHandler(Me.StopStartTimerButton_Click);
			' 
			' UseHardwareAccelerationCheckBox
			' 
			Me.UseHardwareAccelerationCheckBox.AutoSize = True
			Me.UseHardwareAccelerationCheckBox.Location = New System.Drawing.Point(14, 19)
			Me.UseHardwareAccelerationCheckBox.Name = "UseHardwareAccelerationCheckBox"
			Me.UseHardwareAccelerationCheckBox.Size = New System.Drawing.Size(156, 17)
			Me.UseHardwareAccelerationCheckBox.TabIndex = 0
			Me.UseHardwareAccelerationCheckBox.Text = "Use Hardware Acceleration"
			Me.UseHardwareAccelerationCheckBox.UseVisualStyleBackColor = True
'			Me.UseHardwareAccelerationCheckBox.CheckedChanged += New System.EventHandler(Me.UseHardwareAccelerationCheckBox_CheckedChanged);
			' 
			' NRealTimePolarUC
			' 
			Me.Controls.Add(Me.UseHardwareAccelerationCheckBox)
			Me.Controls.Add(Me.StopStartTimerButton)
			Me.Name = "NRealTimePolarUC"
			Me.Size = New System.Drawing.Size(192, 266)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Real Time Polar")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			Dim chart As NPolarChart = New NPolarChart()

			nChartControl1.Panels.Add(chart)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			chart.InnerRadius = New NLength(10, NGraphicsUnit.Point)
			chart.Width = 70.0f
			chart.Height = 70.0f

			Dim gridColor As Color = Color.Green

			Dim polarAngleAxis As NPolarAxis = CType(chart.Axis(StandardAxis.PolarAngle), NPolarAxis)
			Dim angleScale As NAngularScaleConfigurator = CType(polarAngleAxis.ScaleConfigurator, NAngularScaleConfigurator)
			angleScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)
			angleScale.MajorGridStyle.LineStyle.Color = gridColor
			angleScale.OuterMajorTickStyle.LineStyle.Color = gridColor
			angleScale.InnerMajorTickStyle.LineStyle.Color = gridColor
			angleScale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(gridColor)
			angleScale.RulerStyle.BorderStyle.Color = gridColor
			angleScale.LabelFitModes = New LabelFitMode(){}

			m_RadarRay = New NAxisConstLine(9){}

			Dim i As Integer = 0
			Do While i < m_RadarRay.Length
				m_RadarRay(i) = New NAxisConstLine()
				m_RadarRay(i).StrokeStyle.Color = Color.FromArgb(CByte((1.0 - (CSng(i) / m_RadarRay.Length)) * 255), gridColor)
				polarAngleAxis.ConstLines.Add(m_RadarRay(i))
				i += 1
			Loop

			' setup polar axis
			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.Polar).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RoundToTickMax = True
			linearScale.RoundToTickMin = True
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.AutoLabels = False
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)
			linearScale.MajorGridStyle.LineStyle.Color = gridColor
			linearScale.InnerMajorTickStyle.Width = New NLength(0)
			linearScale.OuterMajorTickStyle.Width = New NLength(0)
			linearScale.RulerStyle.BorderStyle.Width = New NLength(0)

			' create three polar point series
			m_PolarSeries = New NPolarPointSeries()
			m_PolarSeries.Name = "Polar"
			m_PolarSeries.BorderStyle.Width = New NLength(0)
			m_PolarSeries.PointShape = PointShape.Bar
			m_PolarSeries.Size = New NLength(4, NGraphicsUnit.Point)
			m_PolarSeries.Angles.ValueFormatter = New NNumericValueFormatter("0.00")
			m_PolarSeries.DataLabelStyle.Visible = False
			m_PolarSeries.DataLabelStyle.Format = "<value> - <angle_in_degrees>"

			' change the storage type to array to increase performance
			m_PolarSeries.FillStyles.StorageType = IndexedStorageType.Array

			Dim rand As Random = New Random()

			For i = 0 To 359
				m_PolarSeries.Values.Add(rand.Next(100))
				m_PolarSeries.Angles.Add(i)
				m_PolarSeries.FillStyles(i) = New NColorFillStyle(Color.FromArgb(0, Color.Green))
			Next i

			' add the series to the chart
			chart.Series.Add(m_PolarSeries)

			ConfigureStandardLayout(chart, title, Nothing)

			UseHardwareAccelerationCheckBox.Checked = True
			StartTimer()
		End Sub

		Protected Overrides Sub UpdateTitle(ByVal working As Boolean, ByVal cpuUsage As Single)
			Dim title As String = "Real Time Polar"

			If working Then
				title &= " [CPU Usage - " & cpuUsage.ToString("0.") & "%]"
			End If

			nChartControl1.Labels(0).Text = title
		End Sub

		Protected Overrides Sub OnTimerTick(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.OnTimerTick(sender, e)

			' decrease the alpha of all colors
			Dim count As Integer = m_PolarSeries.Values.Count
			Dim speed As Integer = 5
			Dim colorFill As NColorFillStyle

			Dim i As Integer = 0
			Do While i < count
				colorFill = CType(m_PolarSeries.FillStyles(i), NColorFillStyle)
				Dim color As Color = colorFill.Color

				If color.A > 0 Then
					colorFill.Color = Color.FromArgb(CByte(Math.Max(0, color.A - speed)), color)
				End If
				i += 1
			Loop

			i = 0
			Do While i < speed
				' first shift the value of all others
				For j As Integer = m_RadarRay.Length - 1 To 1 Step -1
					m_RadarRay(j).Value = m_RadarRay(j - 1).Value
				Next j

				m_RadarRay(0).Value += 1

				If m_RadarRay(0).Value >= 360 Then
					m_RadarRay(0).Value = 0
				End If

				colorFill = CType(m_PolarSeries.FillStyles(CInt(Fix(m_RadarRay(0).Value))), NColorFillStyle)
				colorFill.Color = Color.FromArgb(255, colorFill.Color)
				i += 1
			Loop

			nChartControl1.Refresh()
		End Sub

		Private Sub UseHardwareAccelerationCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles UseHardwareAccelerationCheckBox.CheckedChanged
			If UseHardwareAccelerationCheckBox.Checked Then
				nChartControl1.Settings.RenderSurface = RenderSurface.Window
			Else
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap
			End If
		End Sub

		Private Sub StopStartTimerButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StopStartTimerButton.Click
			ToggleTimer()

			If IsTimerRunning() Then
				StopStartTimerButton.Text = "Stop Timer"
			Else
				StopStartTimerButton.Text = "Start Timer"
			End If
		End Sub
	End Class
End Namespace
