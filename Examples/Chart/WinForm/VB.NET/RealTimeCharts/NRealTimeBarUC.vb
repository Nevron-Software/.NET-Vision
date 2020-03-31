Imports Microsoft.VisualBasic
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
Imports System.Collections.Generic
Imports System.Diagnostics


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NRealTimeBarUC
		Inherits NRealTimeExampleBaseUC

		''' <summary>
		''' Helper class that represents a random sphere
		''' </summary>
		Private Class NSphereInfo
			#Region "Constructors"

			''' <summary>
			''' Initializer constructor
			''' </summary>
			''' <param name="x"></param>
			''' <param name="y"></param>
			''' <param name="radius"></param>
			Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal radius As Integer)
				m_X = x
				m_Y = y
				m_Radius = radius
			End Sub

			#End Region

			#Region "Methods"

			''' <summary>
			''' Applies the sphere to the grid
			''' </summary>
			''' <param name="grid"></param>
			Public Sub ApplyToGrid(ByVal grid()() As Double)
				Dim minX As Integer = m_X - m_Radius
				Dim maxX As Integer = m_X + m_Radius

				Dim minY As Integer = m_Y - m_Radius
				Dim maxY As Integer = m_Y + m_Radius

				Dim countY As Integer = grid.Length
				Dim countX As Integer = grid(0).Length

				Dim radiusSquare As Double = m_Radius * m_Radius

				For x As Integer = minX To maxX
					If x >= 0 AndAlso x < countX Then
						For y As Integer = minY To maxY
							If y >= 0 AndAlso y < countY Then
								Dim dx As Integer = x - m_X
								Dim dy As Integer = y - m_Y

								Dim temp As Double = Math.Sqrt(dx * dx + dy * dy)
								temp = radiusSquare - temp * temp

								If temp > 0 Then
									Dim curValue As Double = grid(y)(x)
									Dim sphereValue As Double = Math.Sqrt(temp)

									grid(y)(x) = Math.Min(NRealTimeBarUC.m_MaxValue, curValue + sphereValue)
								End If
							End If
						Next y
					End If
				Next x
			End Sub

			#End Region

			#Region "Fields"

			Public m_X As Integer
			Public m_Y As Integer
			Public m_Radius As Integer

			#End Region
		End Class

		Private WithEvents UseHardwareAccelerationCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents StopStartTimerButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ResetButton As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private WithEvents GridSizeXComboBox As UI.WinForm.Controls.NComboBox
		Private WithEvents GridSizeYComboBox As UI.WinForm.Controls.NComboBox
		Private label6 As Label
		Private components As System.ComponentModel.IContainer

		Private m_Matrix()() As Double
		Friend Shared ReadOnly m_MaxValue As Double = 255.0
		Private m_SphereList As List(Of NSphereInfo)
		Private m_SphereCreationCounter As Integer
		Private m_ColorTable() As Color

		Public Sub New()
			InitializeComponent()

			m_SphereList = New List(Of NSphereInfo)()

			m_ColorTable = New Color(255){}

			For i As Integer = 0 To 255
				m_ColorTable(i) = InterpolateColors(Color.Blue, Color.Red, i / 255.0F)
			Next i
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
			Me.label4 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.UseHardwareAccelerationCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.StopStartTimerButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.ResetButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.GridSizeXComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.GridSizeYComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
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
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(7, 103)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(83, 16)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Grid Size X:"
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
			' GridSizeXComboBox
			' 
			Me.GridSizeXComboBox.ListProperties.CheckBoxDataMember = ""
			Me.GridSizeXComboBox.ListProperties.DataSource = Nothing
			Me.GridSizeXComboBox.ListProperties.DisplayMember = ""
			Me.GridSizeXComboBox.Location = New System.Drawing.Point(7, 122)
			Me.GridSizeXComboBox.Name = "GridSizeXComboBox"
			Me.GridSizeXComboBox.Size = New System.Drawing.Size(153, 21)
			Me.GridSizeXComboBox.TabIndex = 19
			Me.GridSizeXComboBox.Text = "comboBox2"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GridSizeXComboBox.SelectedIndexChanged += new System.EventHandler(this.GridSizeXComboBox_SelectedIndexChanged);
			' 
			' GridSizeYComboBox
			' 
			Me.GridSizeYComboBox.ListProperties.CheckBoxDataMember = ""
			Me.GridSizeYComboBox.ListProperties.DataSource = Nothing
			Me.GridSizeYComboBox.ListProperties.DisplayMember = ""
			Me.GridSizeYComboBox.Location = New System.Drawing.Point(7, 175)
			Me.GridSizeYComboBox.Name = "GridSizeYComboBox"
			Me.GridSizeYComboBox.Size = New System.Drawing.Size(153, 21)
			Me.GridSizeYComboBox.TabIndex = 20
			Me.GridSizeYComboBox.Text = "comboBox2"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GridSizeYComboBox.SelectedIndexChanged += new System.EventHandler(this.GridSizeYComboBox_SelectedIndexChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(7, 156)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(83, 16)
			Me.label6.TabIndex = 21
			Me.label6.Text = "Grid Size Y:"
			' 
			' NRealTimeBarUC
			' 
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.GridSizeYComboBox)
			Me.Controls.Add(Me.GridSizeXComboBox)
			Me.Controls.Add(Me.UseHardwareAccelerationCheckBox)
			Me.Controls.Add(Me.StopStartTimerButton)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.ResetButton)
			Me.Name = "NRealTimeBarUC"
			Me.Size = New System.Drawing.Size(180, 442)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Real Time Bar")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' do not update automatic legends
			nChartControl1.ServiceManager.LegendUpdateService.UpdateAutoLegends()
			nChartControl1.ServiceManager.LegendUpdateService.Stop()

			' configure the chart
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.BoundsMode = BoundsMode.Fit
			chart.Enable3D = True
			chart.Fit3DAxisContent = False

			' make the aspect 6:1:2
			chart.Width = 60
			chart.Height = 20
			chart.Depth = 20

			' configure the y axis
			Dim yAxis As NAxis = chart.Axis(StandardAxis.PrimaryY)
			yAxis.View = New NRangeAxisView(New NRange1DD(0, m_MaxValue))

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

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			GridSizeXComboBox.Items.Add("10")
			GridSizeXComboBox.Items.Add("50")
			GridSizeXComboBox.Items.Add("100")

			GridSizeYComboBox.Items.Add("10")
			GridSizeYComboBox.Items.Add("50")
			GridSizeYComboBox.Items.Add("100")

			GridSizeXComboBox.SelectedIndex = 2
			GridSizeYComboBox.SelectedIndex = 2

			UseHardwareAccelerationCheckBox.Checked = True
			StartTimer()
		End Sub

		Private Function GetGridSizeX() As Integer
			Select Case GridSizeXComboBox.SelectedIndex
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

		Private Function GetGridSizeY() As Integer
			Select Case GridSizeYComboBox.SelectedIndex
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

		Protected Overrides Sub UpdateTitle(ByVal working As Boolean, ByVal cpuUsage As Single)
			Dim title As String = "Real Time Bar"

			If working Then
				title &= " [CPU Usage - " & cpuUsage.ToString("0.") & "%]"
			End If

			nChartControl1.Labels(0).Text = title
		End Sub

		Private Sub ResetButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ResetButton.Click
			Dim gridSizeX As Integer = GetGridSizeX()
			Dim gridSizeY As Integer = GetGridSizeY()

			Dim chart As NChart = nChartControl1.Charts(0)

			chart.Width = gridSizeX
			chart.Depth = gridSizeY

			chart.Series.Clear()

			m_Matrix = New Double(gridSizeY - 1)(){}

			For i As Integer = 0 To gridSizeY - 1
				m_Matrix(i) = New Double(gridSizeX - 1){}
			Next i

			Dim palette As New NChartPalette(ChartPredefinedPalette.Fresh)

			For i As Integer = 0 To gridSizeY - 1
				' add the first line
				Dim bar As New NBarSeries()
				chart.Series.Add(bar)

				bar.WidthPercent = 100.0F
				bar.DepthPercent = 100.0F

				bar.EnableDepthSort = False
				bar.DataLabelStyle.Visible = False

				bar.Values.ValueFormatter = New NNumericValueFormatter("0.0")
				bar.Values.EmptyDataPoints.ValueMode = EmptyDataPointsValueMode.Skip

				bar.Values.Clear()
				bar.FillStyles.StorageType = IndexedStorageType.Array
				bar.DataPointOriginIndex = 0

				' turn off bar border to improve performance
				bar.BorderStyle.Width = New NLength(0)
			Next i

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

			' clear the list
			For i As Integer = 0 To m_Matrix.Length - 1
				Dim arr() As Double = m_Matrix(i)
				Array.Clear(arr, 0, arr.Length)
			Next i

			For i As Integer = m_SphereList.Count - 1 To 0 Step -1
				Dim sphere As NSphereInfo = m_SphereList(i)

				sphere.ApplyToGrid(m_Matrix)

				sphere.m_X -= 1

				If sphere.m_X + sphere.m_Radius < 0 Then
					m_SphereList.RemoveAt(i)
				End If
			Next i

			' fill grid to bars
			Dim chart As NChart = nChartControl1.Charts(0)
			For i As Integer = 0 To m_Matrix.Length - 1
				Dim bar As NBarSeries = TryCast(chart.Series(i), NBarSeries)
				Dim barValues() As Double = m_Matrix(i)
				Dim barValueCount As Integer = barValues.Length

				If bar.Values.Count = 0 Then
					bar.Values.AddRange(barValues)
				Else
					bar.Values.SetRange(0, barValues)
				End If

				Dim fillStyleCount As Integer = bar.FillStyles.Count

				For j As Integer = 0 To barValueCount - 1
					If j >= fillStyleCount Then
						bar.FillStyles(j) = New NColorFillStyle(m_ColorTable(CInt(Fix(barValues(j)))))
					Else
						DirectCast(bar.FillStyles(j), NColorFillStyle).Color = m_ColorTable(CInt(Fix(barValues(j))))
					End If
				Next j
			Next i


			If m_SphereCreationCounter = 0 Then
				m_SphereCreationCounter = 5

				Dim radius As Integer = CInt(Math.Max(1, Random.NextDouble() * 50))
				Dim y As Integer = CInt(Fix(Random.NextDouble() * GetGridSizeY()))
				Dim x As Integer = GetGridSizeX() + radius

				Dim sphere As New NSphereInfo(x, y, radius)
				m_SphereList.Add(sphere)
			End If

			m_SphereCreationCounter -= 1

			nChartControl1.Refresh()
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

		Private Sub GridSizeXComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridSizeXComboBox.SelectedIndexChanged
			ResetButton_Click(Nothing, Nothing)
		End Sub

		Private Sub GridSizeYComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridSizeYComboBox.SelectedIndexChanged
			ResetButton_Click(Nothing, Nothing)
		End Sub
	End Class
End Namespace
