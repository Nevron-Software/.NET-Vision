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
	Public Class NRealTimeAreaUC
		Inherits NRealTimeExampleBaseUC

		Private m_nCounter As Integer
		Private m_nDirectionChangeCounter As Integer
		Private m_Direction As Double
		Private m_Value As Double
		Private WithEvents UseHardwareAccelerationCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents StopStartTimerButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ResetButton As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private WithEvents NumberOfDataPointsComboBox As UI.WinForm.Controls.NComboBox
		Private label6 As Label
		Private WithEvents NewDataPointsPerTickComboBox As UI.WinForm.Controls.NComboBox
		Private components As System.ComponentModel.IContainer

		Public Sub New()
			InitializeComponent()

			m_nCounter = 0
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
			Me.NumberOfDataPointsComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.NewDataPointsPerTickComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(10, 103)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(153, 16)
			Me.label1.TabIndex = 12
			Me.label1.Text = "Number of Data Points:"
			' 
			' ResetButton
			' 
			Me.ResetButton.Location = New System.Drawing.Point(10, 71)
			Me.ResetButton.Name = "ResetButton"
			Me.ResetButton.Size = New System.Drawing.Size(153, 23)
			Me.ResetButton.TabIndex = 11
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
			Me.StopStartTimerButton.Location = New System.Drawing.Point(10, 42)
			Me.StopStartTimerButton.Name = "StopStartTimerButton"
			Me.StopStartTimerButton.Size = New System.Drawing.Size(153, 23)
			Me.StopStartTimerButton.TabIndex = 15
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
			Me.UseHardwareAccelerationCheckBox.TabIndex = 17
			Me.UseHardwareAccelerationCheckBox.Text = "Use Hardware Acceleration"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UseHardwareAccelerationCheckBox.CheckedChanged += new System.EventHandler(this.UseHardwareAccelerationCheckBox_CheckedChanged);
			' 
			' NumberOfDataPointsComboBox
			' 
			Me.NumberOfDataPointsComboBox.ListProperties.CheckBoxDataMember = ""
			Me.NumberOfDataPointsComboBox.ListProperties.DataSource = Nothing
			Me.NumberOfDataPointsComboBox.ListProperties.DisplayMember = ""
			Me.NumberOfDataPointsComboBox.Location = New System.Drawing.Point(13, 122)
			Me.NumberOfDataPointsComboBox.Name = "NumberOfDataPointsComboBox"
			Me.NumberOfDataPointsComboBox.Size = New System.Drawing.Size(147, 21)
			Me.NumberOfDataPointsComboBox.TabIndex = 18
			Me.NumberOfDataPointsComboBox.Text = "comboBox2"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.NumberOfDataPointsComboBox.SelectedIndexChanged += new System.EventHandler(this.OnNumberOfDataPointsComboBoxSelectedIndexChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(10, 160)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(153, 16)
			Me.label6.TabIndex = 19
			Me.label6.Text = "New Data Points per Tick:"
			' 
			' NewDataPointsPerTickComboBox
			' 
			Me.NewDataPointsPerTickComboBox.ListProperties.CheckBoxDataMember = ""
			Me.NewDataPointsPerTickComboBox.ListProperties.DataSource = Nothing
			Me.NewDataPointsPerTickComboBox.ListProperties.DisplayMember = ""
			Me.NewDataPointsPerTickComboBox.Location = New System.Drawing.Point(13, 179)
			Me.NewDataPointsPerTickComboBox.Name = "NewDataPointsPerTickComboBox"
			Me.NewDataPointsPerTickComboBox.Size = New System.Drawing.Size(147, 21)
			Me.NewDataPointsPerTickComboBox.TabIndex = 20
			Me.NewDataPointsPerTickComboBox.Text = "comboBox2"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.NewDataPointsPerTickComboBox.SelectedIndexChanged += new System.EventHandler(this.OnNewDataPointsPerTickComboBoxSelectedIndexChanged);
			' 
			' NRealTimeAreaUC
			' 
			Me.Controls.Add(Me.NewDataPointsPerTickComboBox)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.NumberOfDataPointsComboBox)
			Me.Controls.Add(Me.UseHardwareAccelerationCheckBox)
			Me.Controls.Add(Me.StopStartTimerButton)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.ResetButton)
			Me.Name = "NRealTimeAreaUC"
			Me.Size = New System.Drawing.Size(180, 442)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Real Time Area")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			chart.BoundsMode = BoundsMode.Stretch

			' configure the y axis
			Dim yAxis As NAxis = chart.Axis(StandardAxis.PrimaryY)
			yAxis.View = New NRangeAxisView(New NRange1DD(0, 100))

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

			' configure the x axis
			Dim xAxis As NAxis = chart.Axis(StandardAxis.PrimaryX)
			linearScale = New NLinearScaleConfigurator()
			linearScale.LabelFitModes = New LabelFitMode(){}
			xAxis.ScaleConfigurator = linearScale
			linearScale.RoundToTickMax = False
			linearScale.RoundToTickMin = False
			linearScale.InnerMinorTickStyle.Visible = False
			linearScale.InnerMajorTickStyle.Visible = False

			chart.Axis(StandardAxis.Depth).Visible = False

			' add the first line
			Dim area As New NAreaSeries()
			chart.Series.Add(area)
			area.SamplingMode = SeriesSamplingMode.Enabled
			area.UseXValues = True
			area.DataLabelStyle.Visible = False
			area.Values.ValueFormatter = New NNumericValueFormatter("0.0")
			area.Values.EmptyDataPoints.ValueMode = EmptyDataPointsValueMode.Skip

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' turn off area border to improve performance after you apply the style sheet
			area.BorderStyle.Width = New NLength(0)

			NumberOfDataPointsComboBox.Items.Add("1000")
			NumberOfDataPointsComboBox.Items.Add("5000")
			NumberOfDataPointsComboBox.Items.Add("10000")
			NumberOfDataPointsComboBox.SelectedIndex = 0

			NewDataPointsPerTickComboBox.Items.Add("10")
			NewDataPointsPerTickComboBox.Items.Add("50")
			NewDataPointsPerTickComboBox.Items.Add("100")
			NewDataPointsPerTickComboBox.SelectedIndex = 1


			UseHardwareAccelerationCheckBox.Checked = True

			StartTimer()
		End Sub
		Protected Overrides Sub UpdateTitle(ByVal working As Boolean, ByVal cpuUsage As Single)
			Dim title As String = "Real Time Area"

			If working Then
				title &= " [CPU Usage - " & cpuUsage.ToString("0.") & "%]"
			End If

			nChartControl1.Labels(0).Text = title
		End Sub

		Private Function GetNewDataPointsPerTick() As Integer
			Select Case NewDataPointsPerTickComboBox.SelectedIndex
				Case 0
					Return 10
				Case 1
					Return 50
				Case 2
					Return 100
				Case Else
					Return 10
			End Select
		End Function

		Private Function GetNumberOfDataPoints() As Integer
			Select Case NumberOfDataPointsComboBox.SelectedIndex
				Case 0
					Return 1000
				Case 1
					Return 5000
				Case 2
					Return 10000
				Case Else
					Return 1000
			End Select
		End Function

		Private Function GetXAxisCustomMax() As Double
			Return CDbl(GetNumberOfDataPoints() - 1)
		End Function

		Private Sub ResetButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ResetButton.Click
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim nMaxCount As Integer = GetNumberOfDataPoints()

			Dim chart As NChart = nChartControl1.Charts(0)
			Dim area As NAreaSeries = CType(chart.Series(0), NAreaSeries)
			area.Values.Clear()
			area.XValues.Clear()
			area.DataPointOriginIndex = 0

			m_nCounter = 0
			m_nDirectionChangeCounter = 0
			m_Direction = 0
			m_Value = 0

			nChartControl1.Refresh()
		End Sub

		Private Sub OnNumberOfDataPointsComboBoxSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles NumberOfDataPointsComboBox.SelectedIndexChanged
			ResetButton_Click(Nothing, Nothing)
		End Sub

		Protected Overrides Sub OnTimerTick(ByVal sender As Object, ByVal e As EventArgs)
			 MyBase.OnTimerTick(sender, e)

			Dim nMaxCount As Integer = GetNumberOfDataPoints()

			If nMaxCount = 0 Then
				Return
			End If

			Dim newDataPoints As Integer = GetNewDataPointsPerTick()

			Dim dValueX As Double = 0
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim area As NAreaSeries = CType(chart.Series(0), NAreaSeries)
			Dim axisX As NAxis = chart.Axis(StandardAxis.PrimaryX)

			Dim minValue As Double = 0
			Dim maxValue As Double = 100

			' add 100 new random points
			For i As Integer = 0 To newDataPoints - 1
				If m_nDirectionChangeCounter = 0 Then
					m_nDirectionChangeCounter = 100
					m_Direction = (m_Direction + Random.NextDouble() - 0.5) / 4.0
				End If

				m_nDirectionChangeCounter -= 1

				If m_Value + m_Direction > maxValue Then
					m_Value = maxValue
					m_Direction = 0
					m_nDirectionChangeCounter = 0
				ElseIf m_Value + m_Direction < minValue Then
					m_Value = minValue
					m_Direction = 0
					m_nDirectionChangeCounter = 0
				Else
					m_Value += m_Direction
				End If

				Dim dValueY As Double = m_Value

				Dim nIndex As Integer = m_nCounter Mod nMaxCount
				dValueX = m_nCounter

				If nIndex >= area.Values.Count Then
					area.Values.Add(dValueY)
					area.XValues.Add(dValueX)
				Else
					area.Values(area.DataPointOriginIndex) = dValueY
					area.XValues(area.DataPointOriginIndex) = dValueX
					area.DataPointOriginIndex += 1

					If area.DataPointOriginIndex >= area.Values.Count Then
						area.DataPointOriginIndex = 0
					End If
				End If

				m_nCounter += 1
			Next i

			nChartControl1.Refresh()
		End Sub

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

		Private Sub OnNewDataPointsPerTickComboBoxSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles NewDataPointsPerTickComboBox.SelectedIndexChanged
			ResetButton_Click(Nothing, Nothing)
		End Sub
	End Class
End Namespace
