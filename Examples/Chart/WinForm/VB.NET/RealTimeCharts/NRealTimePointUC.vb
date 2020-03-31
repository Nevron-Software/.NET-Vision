Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NRealTimePointUC
		Inherits NRealTimeExampleBaseUC

		Private WithEvents UseHardwareAccelerationCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents StopStartTimerButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ResetButton As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private components As System.ComponentModel.IContainer
		Private WithEvents DataPointsPerSphereComboBox As UI.WinForm.Controls.NComboBox
		Private m_Counter As Integer

		''' <summary>
		''' Helper class that represents a random sphere
		''' </summary>
        <Serializable()> _
  Private Class NSphereInfo
            ''' <summary>
            ''' Default constructor
            ''' </summary>
            Public Sub New()
            End Sub
            ''' <summary>
            ''' Initializer constructor
            ''' </summary>
            ''' <param name="factor"></param>
            Public Sub New(ByVal factor As Integer)
                Dim rand As Random = New System.Random()

                m_CenterX = rand.NextDouble() * 200.0 - 100.0
                m_CenterY = rand.NextDouble() * 200.0 - 100.0
                m_CenterZ = rand.NextDouble() * 200.0 - 100.0

                m_BeginColor = Color.FromArgb(CByte(rand.NextDouble() * 255), CByte(rand.NextDouble() * 255), CByte(rand.NextDouble() * 255))
                m_EndColor = Color.FromArgb(CByte(rand.NextDouble() * 255), CByte(rand.NextDouble() * 255), CByte(rand.NextDouble() * 255))

                m_Radius = 1
                m_RadiusIncrement = rand.NextDouble() * 3.0 + 0.1

                m_MaxLongitude = 10 * (factor + 1)
                m_MaxLatitude = 10 * (factor + 1)

                Dim numDataPoints As Integer = 2 + (m_MaxLatitude * m_MaxLongitude)

                m_XValues = New Double(numDataPoints - 1) {}
                m_YValues = New Double(numDataPoints - 1) {}
                m_ZValues = New Double(numDataPoints - 1) {}
            End Sub
            ''' <summary>
            ''' Adds the sphere to the specified point series
            ''' </summary>
            ''' <param name="point"></param>
            Public Sub AddSphere(ByVal point As NPointSeries)
                m_Radius += m_RadiusIncrement
                m_Counter += 1

                Dim x, y, z As Double

                point.FillStyle = New NColorFillStyle(InterpolateColors(m_BeginColor, m_EndColor, CSng(m_Counter / 100.0)))
                point.Values.Clear()
                point.XValues.Clear()
                point.ZValues.Clear()

                Dim dataPointIndex As Integer = 0

                Dim xValues() As Double = m_XValues
                Dim yValues() As Double = m_YValues
                Dim zValues() As Double = m_ZValues

                ' top vertex
                yValues(dataPointIndex) = (m_CenterY + m_Radius)
                xValues(dataPointIndex) = m_CenterX
                zValues(dataPointIndex) = m_CenterZ
                dataPointIndex += 1

                ' bottom vertex
                yValues(dataPointIndex) = m_CenterY - m_Radius
                xValues(dataPointIndex) = m_CenterX
                zValues(dataPointIndex) = m_CenterZ
                dataPointIndex += 1

                Dim nPitch As Integer = m_MaxLongitude + 1

                Dim pitchInc As Double = (180.0 / CDbl(m_MaxLongitude)) * NMath.Degree2Rad
                Dim rotInc As Double = (360.0 / CDbl(m_MaxLatitude)) * NMath.Degree2Rad

                For pitch As Integer = 1 To m_MaxLongitude ' Generate all "intermediate vertices":
                    Dim res As Double = m_Radius * Math.Sin(CSng(pitch) * pitchInc)

                    If res < 0 Then
                        res = -res
                    End If

                    y = m_Radius * Math.Cos(pitch * pitchInc)

                    For latitude As Integer = 0 To m_MaxLatitude - 1
                        x = res * Math.Cos(latitude * rotInc)
                        z = res * Math.Sin(latitude * rotInc)

                        yValues(dataPointIndex) = m_CenterY + y
                        xValues(dataPointIndex) = m_CenterX + x
                        zValues(dataPointIndex) = m_CenterZ + z

                        dataPointIndex += 1
                    Next latitude
                Next pitch

                If point.XValues.Count > 0 Then
                    point.Values.SetRange(0, yValues)
                    point.XValues.SetRange(0, xValues)
                    point.ZValues.SetRange(0, zValues)
                Else
                    point.Values.AddRange(yValues)
                    point.XValues.AddRange(xValues)
                    point.ZValues.AddRange(zValues)
                End If
            End Sub

            Public Shared Function InterpolateColors(ByVal color1 As Color, ByVal color2 As Color, ByVal factor As Single) As Color
                Dim num1 As Integer = (CInt(color1.R))
                Dim num2 As Integer = (CInt(color1.G))
                Dim num3 As Integer = (CInt(color1.B))

                Dim num4 As Integer = (CInt(color2.R))
                Dim num5 As Integer = (CInt(color2.G))
                Dim num6 As Integer = (CInt(color2.B))

                Dim num7 As Byte = CByte(((CSng(num1)) + ((CSng(num4 - num1)) * factor)))
                Dim num8 As Byte = CByte(((CSng(num2)) + ((CSng(num5 - num2)) * factor)))
                Dim num9 As Byte = CByte(((CSng(num3)) + ((CSng(num6 - num3)) * factor)))

                Return Color.FromArgb(num7, num8, num9)
            End Function

            Private m_CenterX As Double
            Private m_CenterY As Double
            Private m_CenterZ As Double
            Private m_Radius As Double
            Private m_RadiusIncrement As Double
            Private m_BeginColor As Color
            Private m_EndColor As Color
            Public m_Counter As Integer

            Private m_MaxLongitude As Integer
            Private m_MaxLatitude As Integer

            Private m_XValues() As Double
            Private m_YValues() As Double
            Private m_ZValues() As Double
        End Class

		Public Sub New()
			InitializeComponent()

			m_Counter = 0
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
			Me.ResetButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.StopStartTimerButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.UseHardwareAccelerationCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.DataPointsPerSphereComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(4, 103)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(150, 16)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Data Points Per Sphere:"
			' 
			' ResetButton
			' 
			Me.ResetButton.Location = New System.Drawing.Point(7, 71)
			Me.ResetButton.Name = "ResetButton"
			Me.ResetButton.Size = New System.Drawing.Size(153, 23)
			Me.ResetButton.TabIndex = 2
			Me.ResetButton.Text = "Reset"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 132)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(47, 16)
			Me.label4.TabIndex = 8
			Me.label4.Text = "Bottom:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 94)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(47, 16)
			Me.label3.TabIndex = 7
			Me.label3.Text = "Right:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 56)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(47, 16)
			Me.label2.TabIndex = 6
			Me.label2.Text = "Top:"
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 19)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(47, 16)
			Me.label5.TabIndex = 5
			Me.label5.Text = "Left:"
			' 
			' StopStartTimerButton
			' 
			Me.StopStartTimerButton.Location = New System.Drawing.Point(7, 42)
			Me.StopStartTimerButton.Name = "StopStartTimerButton"
			Me.StopStartTimerButton.Size = New System.Drawing.Size(153, 23)
			Me.StopStartTimerButton.TabIndex = 1
			Me.StopStartTimerButton.Text = "Stop Timer"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StopStartTimerButton.Click += new System.EventHandler(this.StopStartTimerButton_Click);
			' 
			' UseHardwareAccelerationCheckBox
			' 
			Me.UseHardwareAccelerationCheckBox.ButtonProperties.BorderOffset = 2
			Me.UseHardwareAccelerationCheckBox.Location = New System.Drawing.Point(7, 12)
			Me.UseHardwareAccelerationCheckBox.Name = "UseHardwareAccelerationCheckBox"
			Me.UseHardwareAccelerationCheckBox.Size = New System.Drawing.Size(153, 24)
			Me.UseHardwareAccelerationCheckBox.TabIndex = 0
			Me.UseHardwareAccelerationCheckBox.Text = "Use Hardware Acceleration"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UseHardwareAccelerationCheckBox.CheckedChanged += new System.EventHandler(this.UseHardwareAccelerationCheckBox_CheckedChanged);
			' 
			' DataPointsPerSphereComboBox
			' 
			Me.DataPointsPerSphereComboBox.ListProperties.CheckBoxDataMember = ""
			Me.DataPointsPerSphereComboBox.ListProperties.DataSource = Nothing
			Me.DataPointsPerSphereComboBox.ListProperties.DisplayMember = ""
			Me.DataPointsPerSphereComboBox.Location = New System.Drawing.Point(7, 122)
			Me.DataPointsPerSphereComboBox.Name = "DataPointsPerSphereComboBox"
			Me.DataPointsPerSphereComboBox.Size = New System.Drawing.Size(153, 21)
			Me.DataPointsPerSphereComboBox.TabIndex = 4
			Me.DataPointsPerSphereComboBox.Text = "comboBox2"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DataPointsPerSphereComboBox.SelectedIndexChanged += new System.EventHandler(this.DataPointsPerSphereComboBox_SelectedIndexChanged);
			' 
			' NRealTimePointUC
			' 
			Me.Controls.Add(Me.DataPointsPerSphereComboBox)
			Me.Controls.Add(Me.UseHardwareAccelerationCheckBox)
			Me.Controls.Add(Me.StopStartTimerButton)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.ResetButton)
			Me.Name = "NRealTimePointUC"
			Me.Size = New System.Drawing.Size(178, 442)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Real Time Point")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' do not update automatic legends
			nChartControl1.ServiceManager.LegendUpdateService.UpdateAutoLegends()
			nChartControl1.ServiceManager.LegendUpdateService.Stop()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.BoundsMode = BoundsMode.Fit
			chart.Enable3D = True

			' make the aspect 1:1:1
			chart.Width = 50.0F
			chart.Height = 50.0F
			chart.Depth = 50.0F

			' configure the y axis
			Dim yAxis As NAxis = chart.Axis(StandardAxis.PrimaryY)
			Dim linearScale As NLinearScaleConfigurator = TryCast(yAxis.ScaleConfigurator, NLinearScaleConfigurator)

			' add interlace stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			linearScale.MajorGridStyle.LineStyle.Color = Color.LightSteelBlue
			linearScale.InnerMinorTickStyle.Visible = False
			linearScale.InnerMajorTickStyle.Visible = False
			linearScale.LabelFitModes = New LabelFitMode(){}

			' configure the axes
			ConfigureAxis(chart.Axis(StandardAxis.PrimaryX))
			ConfigureAxis(chart.Axis(StandardAxis.PrimaryY))
			ConfigureAxis(chart.Axis(StandardAxis.Depth))

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			DataPointsPerSphereComboBox.Items.Add("100")
			DataPointsPerSphereComboBox.Items.Add("1000")
			DataPointsPerSphereComboBox.Items.Add("10000")
			DataPointsPerSphereComboBox.SelectedIndex = 0

			UseHardwareAccelerationCheckBox.Checked = True
			StartTimer()
		End Sub
		''' <summary>
		''' 
		''' </summary>
		''' <param name="axis"></param>
		Private Shared Sub ConfigureAxis(ByVal axis As NAxis)
			' configure the x axis
			Dim linearScale As New NLinearScaleConfigurator()
			linearScale.LabelFitModes = New LabelFitMode(){}

			axis.ScaleConfigurator = linearScale
			axis.View = New NRangeAxisView(New NRange1DD(-200, 200), True, True)
		End Sub

		Protected Overrides Sub UpdateTitle(ByVal working As Boolean, ByVal cpuUsage As Single)
			Dim title As String = "Real Time Point"

			If working Then
				title &= " [CPU Usage - " & cpuUsage.ToString("0.") & "%]"
			End If

			nChartControl1.Labels(0).Text = title
		End Sub

		Private Sub ResetButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ResetButton.Click
			Dim chart As NChart = nChartControl1.Charts(0)

			chart.Series.Clear()

			nChartControl1.Refresh()
		End Sub

		Private Sub NumberOfDataPointsUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			If nChartControl1 Is Nothing Then
				Return
			End If

			ResetButton_Click(Nothing, Nothing)
		End Sub

		Protected Overrides Sub OnTimerTick(ByVal sender As Object, ByVal e As EventArgs)
			 MyBase.OnTimerTick(sender, e)

			Dim chart As NChart = nChartControl1.Charts(0)

			Dim axisX As NAxis = chart.Axis(StandardAxis.PrimaryX)

			If m_Counter = 0 Then
				Dim point As New NPointSeries()

				point.Size = New NLength(2)
				point.EnableDepthSort = False
				point.DataLabelStyle.Visible = False
				point.UseXValues = True
				point.UseZValues = True

				' turn off point border to improve performance
				point.BorderStyle.Width = New NLength(0)
				point.PointShape = PointShape.Bar

				point.Tag = New NSphereInfo(DataPointsPerSphereComboBox.SelectedIndex)

				chart.Series.Add(point)
				m_Counter = 10
			End If

			m_Counter -= 1

			Dim count As Integer = chart.Series.Count

			For i As Integer = count - 1 To 0 Step -1
				Dim point As NPointSeries = CType(chart.Series(i), NPointSeries)

				Dim info As NSphereInfo = DirectCast(point.Tag, NSphereInfo)

				If info.m_Counter = 100 Then
					chart.Series.RemoveAt(i)
				Else
					info.AddSphere(point)
				End If
			Next i

			nChartControl1.Refresh()
		End Sub

		Private Shared Function ColorFromValue(ByVal value As Double) As Color
			Return Color.FromArgb(CByte(value * 25), CByte(value * 25), CByte(value * 25))
		End Function

		Private Sub UseHardwareAccelerationCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UseHardwareAccelerationCheckBox.CheckedChanged
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

		Private Sub DataPointsPerSphereComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataPointsPerSphereComboBox.SelectedIndexChanged
			ResetButton_Click(Nothing, Nothing)
		End Sub
	End Class
End Namespace
