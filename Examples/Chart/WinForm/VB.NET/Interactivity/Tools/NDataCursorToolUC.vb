Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NDataCursorToolUC
		Inherits NExampleBaseUC

		Private m_HorizontalAxisCursor As NAxisCursor
		Private m_VerticalAxisCursor As NAxisCursor
		Private m_Chart As NChart
		Private m_DataCursorTool As NDataCursorTool
		Private WithEvents VerticalAxisSnapModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents HorizontalAxisSnapModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents MouseDownCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents MouseUpCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents MouseMoveCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private XAxisTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private YAxisTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private WithEvents Enable3DCheckBox As NCheckBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			m_DataCursorTool = New NDataCursorTool()
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
			Me.label5 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.XAxisTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.YAxisTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.VerticalAxisSnapModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label7 = New System.Windows.Forms.Label()
			Me.HorizontalAxisSnapModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.MouseMoveCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.MouseUpCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.MouseDownCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.Enable3DCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(6, 236)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(100, 16)
			Me.label4.TabIndex = 6
			Me.label4.Text = "Axis coordinates:"
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(6, 260)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(56, 16)
			Me.label5.TabIndex = 7
			Me.label5.Text = "X Axis:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(6, 284)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(56, 16)
			Me.label6.TabIndex = 9
			Me.label6.Text = "Y Axis:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' XAxisTextBox
			' 
			Me.XAxisTextBox.Location = New System.Drawing.Point(78, 260)
			Me.XAxisTextBox.Name = "XAxisTextBox"
			Me.XAxisTextBox.ReadOnly = True
			Me.XAxisTextBox.Size = New System.Drawing.Size(88, 18)
			Me.XAxisTextBox.TabIndex = 8
			' 
			' YAxisTextBox
			' 
			Me.YAxisTextBox.Location = New System.Drawing.Point(78, 284)
			Me.YAxisTextBox.Name = "YAxisTextBox"
			Me.YAxisTextBox.ReadOnly = True
			Me.YAxisTextBox.Size = New System.Drawing.Size(88, 18)
			Me.YAxisTextBox.TabIndex = 10
			' 
			' VerticalAxisSnapModeComboBox
			' 
			Me.VerticalAxisSnapModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.VerticalAxisSnapModeComboBox.ListProperties.DataSource = Nothing
			Me.VerticalAxisSnapModeComboBox.ListProperties.DisplayMember = ""
			Me.VerticalAxisSnapModeComboBox.Location = New System.Drawing.Point(9, 100)
			Me.VerticalAxisSnapModeComboBox.Name = "VerticalAxisSnapModeComboBox"
			Me.VerticalAxisSnapModeComboBox.Size = New System.Drawing.Size(160, 21)
			Me.VerticalAxisSnapModeComboBox.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.VerticalAxisSnapModeComboBox.SelectedIndexChanged += new System.EventHandler(this.VerticalAxisSnapModeComboBox_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(9, 76)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(128, 23)
			Me.label3.TabIndex = 3
			Me.label3.Text = "Vertical axis snap mode:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(9, 28)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(152, 23)
			Me.label7.TabIndex = 1
			Me.label7.Text = "Horizontal axis snap mode:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' HorizontalAxisSnapModeComboBox
			' 
			Me.HorizontalAxisSnapModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.HorizontalAxisSnapModeComboBox.ListProperties.DataSource = Nothing
			Me.HorizontalAxisSnapModeComboBox.ListProperties.DisplayMember = ""
			Me.HorizontalAxisSnapModeComboBox.Location = New System.Drawing.Point(9, 52)
			Me.HorizontalAxisSnapModeComboBox.Name = "HorizontalAxisSnapModeComboBox"
			Me.HorizontalAxisSnapModeComboBox.Size = New System.Drawing.Size(160, 21)
			Me.HorizontalAxisSnapModeComboBox.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HorizontalAxisSnapModeComboBox.SelectedIndexChanged += new System.EventHandler(this.HorizontalAxisSnapModeComboBox_SelectedIndexChanged);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.MouseMoveCheckBox)
			Me.groupBox1.Controls.Add(Me.MouseUpCheckBox)
			Me.groupBox1.Controls.Add(Me.MouseDownCheckBox)
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(6, 132)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(168, 100)
			Me.groupBox1.TabIndex = 5
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Synchronize with:"
			' 
			' MouseMoveCheckBox
			' 
			Me.MouseMoveCheckBox.ButtonProperties.BorderOffset = 2
			Me.MouseMoveCheckBox.Location = New System.Drawing.Point(8, 64)
			Me.MouseMoveCheckBox.Name = "MouseMoveCheckBox"
			Me.MouseMoveCheckBox.Size = New System.Drawing.Size(104, 24)
			Me.MouseMoveCheckBox.TabIndex = 2
			Me.MouseMoveCheckBox.Text = "MouseMove"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MouseMoveCheckBox.CheckedChanged += new System.EventHandler(this.MouseMoveCheckBox_CheckedChanged);
			' 
			' MouseUpCheckBox
			' 
			Me.MouseUpCheckBox.ButtonProperties.BorderOffset = 2
			Me.MouseUpCheckBox.Location = New System.Drawing.Point(8, 40)
			Me.MouseUpCheckBox.Name = "MouseUpCheckBox"
			Me.MouseUpCheckBox.Size = New System.Drawing.Size(104, 24)
			Me.MouseUpCheckBox.TabIndex = 1
			Me.MouseUpCheckBox.Text = "Mouse Up"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MouseUpCheckBox.CheckedChanged += new System.EventHandler(this.MouseUpCheckBox_CheckedChanged);
			' 
			' MouseDownCheckBox
			' 
			Me.MouseDownCheckBox.ButtonProperties.BorderOffset = 2
			Me.MouseDownCheckBox.Location = New System.Drawing.Point(8, 16)
			Me.MouseDownCheckBox.Name = "MouseDownCheckBox"
			Me.MouseDownCheckBox.Size = New System.Drawing.Size(104, 24)
			Me.MouseDownCheckBox.TabIndex = 0
			Me.MouseDownCheckBox.Text = "Mouse down"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MouseDownCheckBox.CheckedChanged += new System.EventHandler(this.MouseDownCheckBox_CheckedChanged);
			' 
			' Enable3DCheckBox
			' 
			Me.Enable3DCheckBox.ButtonProperties.BorderOffset = 2
			Me.Enable3DCheckBox.Location = New System.Drawing.Point(9, 8)
			Me.Enable3DCheckBox.Name = "Enable3DCheckBox"
			Me.Enable3DCheckBox.Size = New System.Drawing.Size(104, 24)
			Me.Enable3DCheckBox.TabIndex = 0
			Me.Enable3DCheckBox.Text = "Enable 3D"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Enable3DCheckBox.CheckedChanged += new System.EventHandler(this.Enable3DCheckBox_CheckedChanged);
			' 
			' NDataCursorToolUC
			' 
			Me.Controls.Add(Me.Enable3DCheckBox)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.VerticalAxisSnapModeComboBox)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.HorizontalAxisSnapModeComboBox)
			Me.Controls.Add(Me.YAxisTextBox)
			Me.Controls.Add(Me.XAxisTextBox)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.label4)
			Me.Name = "NDataCursorToolUC"
			Me.Size = New System.Drawing.Size(180, 432)
			Me.groupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.AutoRefresh = False

			HorizontalAxisSnapModeComboBox.Items.Add("None")
			HorizontalAxisSnapModeComboBox.Items.Add("Ruler")
			HorizontalAxisSnapModeComboBox.Items.Add("Major ticks")
			HorizontalAxisSnapModeComboBox.Items.Add("Minor ticks")
			HorizontalAxisSnapModeComboBox.Items.Add("Ruler Min/Max")
			HorizontalAxisSnapModeComboBox.Items.Add("Nearest Value")

			VerticalAxisSnapModeComboBox.Items.Add("None")
			VerticalAxisSnapModeComboBox.Items.Add("Ruler")
			VerticalAxisSnapModeComboBox.Items.Add("Major ticks")
			VerticalAxisSnapModeComboBox.Items.Add("Minor ticks")
			VerticalAxisSnapModeComboBox.Items.Add("Ruler Min/Max")
			VerticalAxisSnapModeComboBox.Items.Add("Nearest Value")

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Data Cursor Tool")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Series.Clear()
			m_Chart.BoundsMode = BoundsMode.Stretch

			m_Chart.Depth = 55.0F
			m_Chart.Width = 55.0F
			m_Chart.Height = 55.0F

			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = GetScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = GetScaleConfigurator()
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = GetScaleConfigurator()

			m_Chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(12, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(78, NRelativeUnit.ParentPercentage))

			' add point series
			Dim point1 As NPointSeries = CType(m_Chart.Series.Add(SeriesType.Point), NPointSeries)
			point1.Name = "Point 1"
			point1.PointShape = PointShape.Bar
			point1.Size = New NLength(5, NGraphicsUnit.Point)
			point1.FillStyle = New NColorFillStyle(Color.Red)
			point1.BorderStyle.Color = Color.Pink
			point1.DataLabelStyle.Visible = False
			point1.UseXValues = True
			point1.UseZValues = True
			point1.InflateMargins = True

			' fill with random data
			Dim itemCount As Integer = 70
			point1.Values.FillRandomRange(Random, itemCount, 0, 50)
			point1.XValues.FillRandomRange(Random, itemCount, 0, 50)
			point1.ZValues.FillRandomRange(Random, itemCount, 0, 50)

			' add cursors
			m_HorizontalAxisCursor = New NAxisCursor()
			m_HorizontalAxisCursor.BeginEndAxis = CInt(StandardAxis.PrimaryY)
			AddHandler m_HorizontalAxisCursor.ValueChanged, AddressOf OnValueChanged

			m_VerticalAxisCursor = New NAxisCursor()
			m_VerticalAxisCursor.BeginEndAxis = CInt(StandardAxis.PrimaryX)
			AddHandler m_VerticalAxisCursor.ValueChanged, AddressOf OnValueChanged

			Dim primaryXAxis As NAxis = m_Chart.Axis(StandardAxis.PrimaryX)
			Dim primaryYAxis As NAxis = m_Chart.Axis(StandardAxis.PrimaryY)
			Dim depthAxis As NAxis = m_Chart.Axis(StandardAxis.Depth)

			primaryXAxis.Cursors.Add(m_HorizontalAxisCursor)
			primaryYAxis.Cursors.Add(m_VerticalAxisCursor)

			m_HorizontalAxisCursor.SynchronizeOnMouseAction = MouseAction.None
			m_VerticalAxisCursor.SynchronizeOnMouseAction = MouseAction.None

			nChartControl1.Controller.Selection.Add(m_Chart)
			nChartControl1.Controller.Tools.Add(New NDataCursorTool())

			MouseMoveCheckBox.Checked = True
			HorizontalAxisSnapModeComboBox.SelectedIndex = 0
			VerticalAxisSnapModeComboBox.SelectedIndex = 0
		End Sub

		Private Function GetScaleConfigurator() As NLinearScaleConfigurator
			Dim linearScale As New NLinearScaleConfigurator()

			linearScale.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific)
			linearScale.MinorTickCount = 4

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			Return linearScale
		End Function

		'private NAxisValueSnapper GetAxisValueSnapperFromIndex(int index, NDataSeriesDouble dataSeries)
		Private Function GetAxisValueSnapperFromIndex(ByVal index As Integer, ByVal xValues As Boolean) As NAxisValueSnapper
			Select Case index
				Case 0 'None, snapping is disabled
					Return Nothing
				Case 1 ' Ruler, values are constrained to the ruler begin and end values.
					Return New NAxisRulerClampSnapper()
				Case 2 ' Major ticks, values are snapped to axis major ticks
					Return New NAxisMajorTickSnapper()
				Case 3 ' Minor ticks, values are snapped to axis minor ticks
					Return New NAxisMinorTickSnapper()
				Case 4 ' Ruler Min Max, values are snapped to the ruler min and max values
					Return New NAxisRulerMinMaxSnapper()
				Case 5 ' Neasest value snapper
					Dim dataSeries As NDataSeriesDouble
					If xValues Then
						dataSeries = CType(m_Chart.Series(0), NPointSeries).XValues
					Else
						dataSeries = CType(m_Chart.Series(0), NPointSeries).Values
					End If

					Return New NNearestSeriesValueSnapper(dataSeries, False)
			End Select

			Return Nothing
		End Function

		Private Sub UpdateCursorFromControls()
			m_HorizontalAxisCursor.ValueSnapper = GetAxisValueSnapperFromIndex(HorizontalAxisSnapModeComboBox.SelectedIndex, True)
			m_VerticalAxisCursor.ValueSnapper = GetAxisValueSnapperFromIndex(VerticalAxisSnapModeComboBox.SelectedIndex, False)

			If MouseDownCheckBox.Checked Then
				m_HorizontalAxisCursor.SynchronizeOnMouseAction = m_HorizontalAxisCursor.SynchronizeOnMouseAction Or MouseAction.Down
				m_VerticalAxisCursor.SynchronizeOnMouseAction = m_VerticalAxisCursor.SynchronizeOnMouseAction Or MouseAction.Down
			End If

			If MouseUpCheckBox.Checked Then
				m_HorizontalAxisCursor.SynchronizeOnMouseAction = m_HorizontalAxisCursor.SynchronizeOnMouseAction Or MouseAction.Up
				m_VerticalAxisCursor.SynchronizeOnMouseAction = m_VerticalAxisCursor.SynchronizeOnMouseAction Or MouseAction.Up
			End If

			If MouseMoveCheckBox.Checked Then
				m_HorizontalAxisCursor.SynchronizeOnMouseAction = m_HorizontalAxisCursor.SynchronizeOnMouseAction Or MouseAction.Move
				m_VerticalAxisCursor.SynchronizeOnMouseAction = m_VerticalAxisCursor.SynchronizeOnMouseAction Or MouseAction.Move
			End If
		End Sub

		Private Sub OnValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			XAxisTextBox.Text = m_HorizontalAxisCursor.Value.ToString()
			YAxisTextBox.Text = m_VerticalAxisCursor.Value.ToString()
		End Sub

		Private Sub HorizontalAxisSnapModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles HorizontalAxisSnapModeComboBox.SelectedIndexChanged
			UpdateCursorFromControls()
		End Sub

		Private Sub VerticalAxisSnapModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles VerticalAxisSnapModeComboBox.SelectedIndexChanged
			UpdateCursorFromControls()
		End Sub

		Private Sub MouseDownCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MouseDownCheckBox.CheckedChanged
			UpdateCursorFromControls()
		End Sub

		Private Sub MouseUpCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MouseUpCheckBox.CheckedChanged
			UpdateCursorFromControls()
		End Sub

		Private Sub MouseMoveCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MouseMoveCheckBox.CheckedChanged
			UpdateCursorFromControls()
		End Sub

		Private Sub Enable3DCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Enable3DCheckBox.CheckedChanged
			m_Chart.Enable3D = Enable3DCheckBox.Checked

			If m_Chart.Enable3D Then
				m_Chart.BoundsMode = BoundsMode.Fit
			Else
				m_Chart.BoundsMode = BoundsMode.Stretch
			End If

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
