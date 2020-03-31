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
	Public Class NRealTimeLineUC
		Inherits NRealTimeExampleBaseUC

		Private components As IContainer

		Private m_Line1 As NLineSeries
		Private m_Line2 As NLineSeries
		Private m_Line3 As NLineSeries
		Private m_Random As New Random()

		Private m_ValueArray1() As Double
		Private m_ValueArray2() As Double
		Private m_ValueArray3() As Double

		Private m_MaxCount As Integer = 25000
		Private m_NewDataPointsPerTick As Integer = 4000
		Private m_Angle1 As Double
		Private m_Angle2 As Double
		Private m_Angle3 As Double

		Private WithEvents UseHardwareAccelerationCheckBox As NCheckBox
		Private WithEvents StopStartTimerButton As NButton
		Private label1 As Label
		Private label2 As Label
		Private label3 As Label
		Private Frequency1NumericUpDown As NNumericUpDown
		Private Frequency2NumericUpDown As NNumericUpDown
		Private Frequency3NumericUpDown As NNumericUpDown
		Private Amplitude3NumericUpDown As NNumericUpDown
		Private Amplitude2NumericUpDown As NNumericUpDown
		Private Amplitude1NumericUpDown As NNumericUpDown
		Private label4 As Label
		Private label5 As Label
		Private Noise3NumericUpDown As NNumericUpDown
		Private Noise2NumericUpDown As NNumericUpDown
		Private Noise1NumericUpDown As NNumericUpDown
		Private label7 As Label
		Private label8 As Label
		Private label9 As Label
		Private label6 As Label


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
			Me.UseHardwareAccelerationCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.StopStartTimerButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.Frequency1NumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.Frequency2NumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.Frequency3NumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.Amplitude3NumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.Amplitude2NumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.Amplitude1NumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.Noise3NumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.Noise2NumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.Noise1NumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label7 = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			Me.label9 = New System.Windows.Forms.Label()
			DirectCast(Me.Frequency1NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.Frequency2NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.Frequency3NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.Amplitude3NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.Amplitude2NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.Amplitude1NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.Noise3NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.Noise2NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.Noise1NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' UseHardwareAccelerationCheckBox
			' 
			Me.UseHardwareAccelerationCheckBox.AutoSize = True
			Me.UseHardwareAccelerationCheckBox.ButtonProperties.BorderOffset = 2
			Me.UseHardwareAccelerationCheckBox.Location = New System.Drawing.Point(10, 11)
			Me.UseHardwareAccelerationCheckBox.Name = "UseHardwareAccelerationCheckBox"
			Me.UseHardwareAccelerationCheckBox.Size = New System.Drawing.Size(156, 17)
			Me.UseHardwareAccelerationCheckBox.TabIndex = 0
			Me.UseHardwareAccelerationCheckBox.Text = "Use Hardware Acceleration"
			Me.UseHardwareAccelerationCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UseHardwareAccelerationCheckBox.CheckedChanged += new System.EventHandler(this.UseHardwareAccelerationCheckBox_CheckedChanged);
			' 
			' StopStartTimerButton
			' 
			Me.StopStartTimerButton.Location = New System.Drawing.Point(10, 34)
			Me.StopStartTimerButton.Name = "StopStartTimerButton"
			Me.StopStartTimerButton.Size = New System.Drawing.Size(161, 23)
			Me.StopStartTimerButton.TabIndex = 0
			Me.StopStartTimerButton.Text = "Stop Timer"
			Me.StopStartTimerButton.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StopStartTimerButton.Click += new System.EventHandler(this.StopStartTimerButton_Click);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(7, 112)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(69, 13)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Frequency 1:"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(7, 140)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(69, 13)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Frequency 2:"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(7, 166)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(69, 13)
			Me.label3.TabIndex = 6
			Me.label3.Text = "Frequency 3:"
			' 
			' Frequency1NumericUpDown
			' 
			Me.Frequency1NumericUpDown.Location = New System.Drawing.Point(92, 105)
			Me.Frequency1NumericUpDown.Name = "Frequency1NumericUpDown"
			Me.Frequency1NumericUpDown.Size = New System.Drawing.Size(83, 20)
			Me.Frequency1NumericUpDown.TabIndex = 3
			Me.Frequency1NumericUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
			' 
			' Frequency2NumericUpDown
			' 
			Me.Frequency2NumericUpDown.Location = New System.Drawing.Point(92, 133)
			Me.Frequency2NumericUpDown.Name = "Frequency2NumericUpDown"
			Me.Frequency2NumericUpDown.Size = New System.Drawing.Size(83, 20)
			Me.Frequency2NumericUpDown.TabIndex = 5
			Me.Frequency2NumericUpDown.Value = New Decimal(New Integer() { 4, 0, 0, 0})
			' 
			' Frequency3NumericUpDown
			' 
			Me.Frequency3NumericUpDown.Location = New System.Drawing.Point(92, 159)
			Me.Frequency3NumericUpDown.Name = "Frequency3NumericUpDown"
			Me.Frequency3NumericUpDown.Size = New System.Drawing.Size(83, 20)
			Me.Frequency3NumericUpDown.TabIndex = 7
			Me.Frequency3NumericUpDown.Value = New Decimal(New Integer() { 16, 0, 0, 0})
			' 
			' Amplitude3NumericUpDown
			' 
			Me.Amplitude3NumericUpDown.Location = New System.Drawing.Point(92, 270)
			Me.Amplitude3NumericUpDown.Name = "Amplitude3NumericUpDown"
			Me.Amplitude3NumericUpDown.Size = New System.Drawing.Size(83, 20)
			Me.Amplitude3NumericUpDown.TabIndex = 13
			Me.Amplitude3NumericUpDown.Value = New Decimal(New Integer() { 70, 0, 0, 0})
			' 
			' Amplitude2NumericUpDown
			' 
			Me.Amplitude2NumericUpDown.Location = New System.Drawing.Point(92, 244)
			Me.Amplitude2NumericUpDown.Name = "Amplitude2NumericUpDown"
			Me.Amplitude2NumericUpDown.Size = New System.Drawing.Size(83, 20)
			Me.Amplitude2NumericUpDown.TabIndex = 11
			Me.Amplitude2NumericUpDown.Value = New Decimal(New Integer() { 50, 0, 0, 0})
			' 
			' Amplitude1NumericUpDown
			' 
			Me.Amplitude1NumericUpDown.Location = New System.Drawing.Point(92, 216)
			Me.Amplitude1NumericUpDown.Name = "Amplitude1NumericUpDown"
			Me.Amplitude1NumericUpDown.Size = New System.Drawing.Size(83, 20)
			Me.Amplitude1NumericUpDown.TabIndex = 9
			Me.Amplitude1NumericUpDown.Value = New Decimal(New Integer() { 30, 0, 0, 0})
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(7, 277)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(65, 13)
			Me.label4.TabIndex = 12
			Me.label4.Text = "Amplitude 3:"
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(7, 251)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(65, 13)
			Me.label5.TabIndex = 10
			Me.label5.Text = "Amplitude 2:"
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(7, 223)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(65, 13)
			Me.label6.TabIndex = 8
			Me.label6.Text = "Amplitude 1:"
			' 
			' Noise3NumericUpDown
			' 
			Me.Noise3NumericUpDown.Location = New System.Drawing.Point(92, 389)
			Me.Noise3NumericUpDown.Name = "Noise3NumericUpDown"
			Me.Noise3NumericUpDown.Size = New System.Drawing.Size(83, 20)
			Me.Noise3NumericUpDown.TabIndex = 19
			Me.Noise3NumericUpDown.Value = New Decimal(New Integer() { 70, 0, 0, 0})
			' 
			' Noise2NumericUpDown
			' 
			Me.Noise2NumericUpDown.Location = New System.Drawing.Point(92, 363)
			Me.Noise2NumericUpDown.Name = "Noise2NumericUpDown"
			Me.Noise2NumericUpDown.Size = New System.Drawing.Size(83, 20)
			Me.Noise2NumericUpDown.TabIndex = 17
			Me.Noise2NumericUpDown.Value = New Decimal(New Integer() { 50, 0, 0, 0})
			' 
			' Noise1NumericUpDown
			' 
			Me.Noise1NumericUpDown.Location = New System.Drawing.Point(92, 335)
			Me.Noise1NumericUpDown.Name = "Noise1NumericUpDown"
			Me.Noise1NumericUpDown.Size = New System.Drawing.Size(83, 20)
			Me.Noise1NumericUpDown.TabIndex = 15
			Me.Noise1NumericUpDown.Value = New Decimal(New Integer() { 30, 0, 0, 0})
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(7, 396)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(46, 13)
			Me.label7.TabIndex = 18
			Me.label7.Text = "Noise 3:"
			' 
			' label8
			' 
			Me.label8.AutoSize = True
			Me.label8.Location = New System.Drawing.Point(7, 370)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(46, 13)
			Me.label8.TabIndex = 16
			Me.label8.Text = "Noise 2:"
			' 
			' label9
			' 
			Me.label9.AutoSize = True
			Me.label9.Location = New System.Drawing.Point(7, 342)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(46, 13)
			Me.label9.TabIndex = 14
			Me.label9.Text = "Noise 1:"
			' 
			' NRealTimeLineUC
			' 
			Me.Controls.Add(Me.Noise3NumericUpDown)
			Me.Controls.Add(Me.Noise2NumericUpDown)
			Me.Controls.Add(Me.Noise1NumericUpDown)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.label8)
			Me.Controls.Add(Me.label9)
			Me.Controls.Add(Me.Amplitude3NumericUpDown)
			Me.Controls.Add(Me.Amplitude2NumericUpDown)
			Me.Controls.Add(Me.Amplitude1NumericUpDown)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.Frequency3NumericUpDown)
			Me.Controls.Add(Me.Frequency2NumericUpDown)
			Me.Controls.Add(Me.Frequency1NumericUpDown)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.UseHardwareAccelerationCheckBox)
			Me.Controls.Add(Me.StopStartTimerButton)
			Me.Name = "NRealTimeLineUC"
			Me.Size = New System.Drawing.Size(180, 506)
			DirectCast(Me.Frequency1NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.Frequency2NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.Frequency3NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.Amplitude3NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.Amplitude2NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.Amplitude1NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.Noise3NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.Noise2NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.Noise1NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Real Time Line")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			Dim chart As New NCartesianChart()

			nChartControl1.Panels.Add(chart)
			chart.BoundsMode = BoundsMode.Stretch

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Black)
'			styleSheet.Apply(nChartControl1.Document);

			Dim axis1 As NAxis = chart.Axis(StandardAxis.PrimaryY)
			ConfigureAxis(axis1, 0, 30, "Signal 1")

			Dim axis2 As NAxis = chart.Axis(StandardAxis.SecondaryY)
			ConfigureAxis(axis2, 35, 65, "Signal 2")

			Dim axis3 As NAxis = CType(chart.Axes, NCartesianAxisCollection).AddCustomAxis(AxisOrientation.Vertical, AxisDockZone.FrontRight)
			ConfigureAxis(axis3, 70, 100, "Signal 3")

			m_Line1 = CreateLineSeries()
			chart.Series.Add(m_Line1)

			m_Line2 = CreateLineSeries()
			chart.Series.Add(m_Line2)
			m_Line2.DisplayOnAxis(StandardAxis.PrimaryY, False)
			m_Line2.DisplayOnAxis(StandardAxis.SecondaryY, True)

			m_Line3 = CreateLineSeries()
			chart.Series.Add(m_Line3)
			m_Line3.DisplayOnAxis(StandardAxis.PrimaryY, False)
			m_Line3.DisplayOnAxis(axis3.AxisId, True)

			m_ValueArray1 = New Double(m_NewDataPointsPerTick - 1){}
			m_ValueArray2 = New Double(m_NewDataPointsPerTick - 1){}
			m_ValueArray3 = New Double(m_NewDataPointsPerTick - 1){}

			ConfigureStandardLayout(chart, title, Nothing)

			UseHardwareAccelerationCheckBox.Checked = True
			StartTimer()
		End Sub

		Private Sub ConfigureAxis(ByVal axis As NAxis, ByVal beginPercent As Single, ByVal endPercent As Single, ByVal title As String)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As New NLinearScaleConfigurator()
			scale_Renamed.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			axis.ScaleConfigurator = scale_Renamed
			axis.View = New NRangeAxisView(New NRange1DD(-1.5, 1.5), True, True)
			axis.ScaleConfigurator.Title.Text = title
			axis.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, False)
			axis.Anchor.BeginPercent = beginPercent
			axis.Anchor.EndPercent = endPercent
			axis.Visible = True
		End Sub

		Private Function CreateLineSeries() As NLineSeries
			Dim lineSeries As New NLineSeries()

			lineSeries.Values.Capacity = m_MaxCount
			lineSeries.XValues.Capacity = m_MaxCount
			lineSeries.DataLabelStyle.Visible = False
			lineSeries.SamplingMode = SeriesSamplingMode.Enabled
			lineSeries.SampleDistance = New NLength(1, NGraphicsUnit.Pixel)

			Return lineSeries
		End Function

		Protected Overrides Sub UpdateTitle(ByVal working As Boolean, ByVal cpuUsage As Single)
			Dim title As String = "Real Time Line"

			If working Then
				title &= " [CPU Usage - " & cpuUsage.ToString("0.") & "%]"
			End If

			nChartControl1.Labels(0).Text = title
		End Sub



		Protected Overrides Sub OnTimerTick(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.OnTimerTick(sender, e)

			' first accumulate the new data in arrays for faster processing
			Dim newDataPoints As Integer = m_NewDataPointsPerTick

			Dim angleStep1 As Double = (Math.PI * 2 / m_MaxCount) * CInt(Fix(Frequency1NumericUpDown.Value))
			Dim angleStep2 As Double = (Math.PI * 2 / m_MaxCount) * CInt(Fix(Frequency2NumericUpDown.Value))
			Dim angleStep3 As Double = (Math.PI * 2 / m_MaxCount) * CInt(Fix(Frequency3NumericUpDown.Value))

			Dim amplitude1 As Double = Math.Min(1, CDbl(Amplitude1NumericUpDown.Value) * 0.01)
			Dim amplitude2 As Double = Math.Min(1, CDbl(Amplitude2NumericUpDown.Value) * 0.01)
			Dim amplitude3 As Double = Math.Min(1, CDbl(Amplitude3NumericUpDown.Value) * 0.01)

			Dim noise1 As Double = CDbl(Noise1NumericUpDown.Value) * 0.02
			Dim noise2 As Double = CDbl(Noise2NumericUpDown.Value) * 0.02
			Dim noise3 As Double = CDbl(Noise3NumericUpDown.Value) * 0.02

			' generate new data
'INSTANT VB NOTE: The variable random was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim random_Renamed As Random = m_Random
			Dim valueArray1() As Double = m_ValueArray1
			Dim valueArray2() As Double = m_ValueArray2
			Dim valueArray3() As Double = m_ValueArray3

			For i As Integer = 0 To newDataPoints - 1
				valueArray1(i) = (Math.Sin(m_Angle1) + (random_Renamed.NextDouble() - 0.5) * noise1) * amplitude1
				valueArray2(i) = (Math.Sin(m_Angle2) + (random_Renamed.NextDouble() - 0.5) * noise2) * amplitude2
				valueArray3(i) = (Math.Sin(m_Angle3) + (random_Renamed.NextDouble() - 0.5) * noise3) * amplitude3

				m_Angle1 += angleStep1
				m_Angle2 += angleStep2
				m_Angle3 += angleStep3
			Next i

			Dim valueIndex As Integer = 0
			Dim itemsToAdd As Integer = newDataPoints
			Dim originShift As Integer = newDataPoints

			' then add the new data
			If m_Line1.Values.Count < m_MaxCount Then
				' the line series can accumulate the new data
				Dim valueCount As Integer = Math.Min(m_MaxCount - m_Line1.Values.Count, newDataPoints)

				m_Line1.Values.AddRange(m_ValueArray1, valueIndex, valueCount)
				m_Line2.Values.AddRange(m_ValueArray2, valueIndex, valueCount)
				m_Line3.Values.AddRange(m_ValueArray3, valueIndex, valueCount)

				valueIndex += valueCount
				itemsToAdd -= valueCount
				originShift -= valueCount
			End If

			If itemsToAdd > 0 Then
				' capacity reached
				Dim count As Integer = m_Line1.Values.Count - m_Line1.DataPointOriginIndex
				Dim valueCount As Integer = Math.Min(count, itemsToAdd)

				m_Line1.Values.SetRange(m_Line1.DataPointOriginIndex, m_ValueArray1, valueIndex, valueCount)
				m_Line2.Values.SetRange(m_Line2.DataPointOriginIndex, m_ValueArray2, valueIndex, valueCount)
				m_Line3.Values.SetRange(m_Line3.DataPointOriginIndex, m_ValueArray3, valueIndex, valueCount)

				itemsToAdd -= valueCount

				If itemsToAdd > 0 Then
					valueIndex += valueCount

					m_Line1.Values.SetRange(0, m_ValueArray1, valueIndex, itemsToAdd)
					m_Line2.Values.SetRange(0, m_ValueArray2, valueIndex, itemsToAdd)
					m_Line3.Values.SetRange(0, m_ValueArray3, valueIndex, itemsToAdd)
				End If
			End If

			m_Line1.DataPointOriginIndex += originShift
			m_Line2.DataPointOriginIndex += originShift
			m_Line3.DataPointOriginIndex += originShift

			m_Line1.DataPointOriginIndex = m_Line1.DataPointOriginIndex Mod m_MaxCount
			m_Line2.DataPointOriginIndex = m_Line2.DataPointOriginIndex Mod m_MaxCount
			m_Line3.DataPointOriginIndex = m_Line3.DataPointOriginIndex Mod m_MaxCount

			nChartControl1.Refresh()
		End Sub

		Private Sub StopStartTimerButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StopStartTimerButton.Click
			ToggleTimer()

			If IsTimerRunning() Then
				StopStartTimerButton.Text = "Stop Timer"
			Else
				StopStartTimerButton.Text = "Start Timer"
			End If
		End Sub

		Private Sub UseHardwareAccelerationCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles UseHardwareAccelerationCheckBox.CheckedChanged
			If UseHardwareAccelerationCheckBox.Checked Then
				nChartControl1.Settings.RenderSurface = RenderSurface.Window
			Else
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap
			End If
		End Sub
	End Class
End Namespace
