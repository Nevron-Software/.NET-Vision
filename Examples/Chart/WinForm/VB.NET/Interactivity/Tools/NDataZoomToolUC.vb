Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Diagnostics
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NDataZoomToolUC
		Inherits NExampleBaseUC

		Private m_DataZoomTool As NDataZoomTool
		Private label1 As System.Windows.Forms.Label
		Private WithEvents ResetAxesButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents SampleChartComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents SelectionAxesComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents InteractivityToolComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label8 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private WithEvents ZoomInFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ZoomOutFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ZoomOutResetsAxesCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private WithEvents HorizontalAxisSnapModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents VerticalAxisSnapModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents AlwaysZoomInCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents PreserveAspectRatioCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents WheelZoomCheckBox As UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			m_DataZoomTool = New NDataZoomTool()
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
			Me.ResetAxesButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.SampleChartComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SelectionAxesComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.InteractivityToolComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label8 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.ZoomInFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ZoomOutFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ZoomOutResetsAxesCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.HorizontalAxisSnapModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.VerticalAxisSnapModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.AlwaysZoomInCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.PreserveAspectRatioCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.WheelZoomCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' ResetAxesButton
			' 
			Me.ResetAxesButton.Location = New System.Drawing.Point(8, 567)
			Me.ResetAxesButton.Name = "ResetAxesButton"
			Me.ResetAxesButton.Size = New System.Drawing.Size(160, 23)
			Me.ResetAxesButton.TabIndex = 20
			Me.ResetAxesButton.Text = "Reset axes"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ResetAxesButton.Click += new System.EventHandler(this.ResetAxesButton_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 64)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(160, 16)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Sample chart:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' SampleChartComboBox
			' 
			Me.SampleChartComboBox.ListProperties.CheckBoxDataMember = ""
			Me.SampleChartComboBox.ListProperties.DataSource = Nothing
			Me.SampleChartComboBox.ListProperties.DisplayMember = ""
			Me.SampleChartComboBox.Location = New System.Drawing.Point(8, 80)
			Me.SampleChartComboBox.Name = "SampleChartComboBox"
			Me.SampleChartComboBox.Size = New System.Drawing.Size(160, 21)
			Me.SampleChartComboBox.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SampleChartComboBox.SelectedIndexChanged += new System.EventHandler(this.SampleChartComboBox_SelectedIndexChanged);
			' 
			' SelectionAxesComboBox
			' 
			Me.SelectionAxesComboBox.ListProperties.CheckBoxDataMember = ""
			Me.SelectionAxesComboBox.ListProperties.DataSource = Nothing
			Me.SelectionAxesComboBox.ListProperties.DisplayMember = ""
			Me.SelectionAxesComboBox.Location = New System.Drawing.Point(8, 120)
			Me.SelectionAxesComboBox.Name = "SelectionAxesComboBox"
			Me.SelectionAxesComboBox.Size = New System.Drawing.Size(160, 21)
			Me.SelectionAxesComboBox.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SelectionAxesComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectionAxesComboBox_SelectedIndexChanged);
			' 
			' InteractivityToolComboBox
			' 
			Me.InteractivityToolComboBox.ListProperties.CheckBoxDataMember = ""
			Me.InteractivityToolComboBox.ListProperties.DataSource = Nothing
			Me.InteractivityToolComboBox.ListProperties.DisplayMember = ""
			Me.InteractivityToolComboBox.Location = New System.Drawing.Point(8, 32)
			Me.InteractivityToolComboBox.Name = "InteractivityToolComboBox"
			Me.InteractivityToolComboBox.Size = New System.Drawing.Size(160, 21)
			Me.InteractivityToolComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InteractivityToolComboBox.SelectedIndexChanged += new System.EventHandler(this.InteractivityToolComboBox_SelectedIndexChanged);
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(8, 16)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(160, 16)
			Me.label8.TabIndex = 0
			Me.label8.Text = "Interactivity tool:"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 104)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(160, 16)
			Me.label4.TabIndex = 4
			Me.label4.Text = "Selection axes:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ZoomInFillStyleButton
			' 
			Me.ZoomInFillStyleButton.Location = New System.Drawing.Point(8, 152)
			Me.ZoomInFillStyleButton.Name = "ZoomInFillStyleButton"
			Me.ZoomInFillStyleButton.Size = New System.Drawing.Size(160, 23)
			Me.ZoomInFillStyleButton.TabIndex = 6
			Me.ZoomInFillStyleButton.Text = "Zoom In Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ZoomInFillStyleButton.Click += new System.EventHandler(this.ZoomInFillStyleButton_Click);
			' 
			' ZoomOutFillStyleButton
			' 
			Me.ZoomOutFillStyleButton.Location = New System.Drawing.Point(8, 184)
			Me.ZoomOutFillStyleButton.Name = "ZoomOutFillStyleButton"
			Me.ZoomOutFillStyleButton.Size = New System.Drawing.Size(160, 23)
			Me.ZoomOutFillStyleButton.TabIndex = 7
			Me.ZoomOutFillStyleButton.Text = "Zoom Out Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ZoomOutFillStyleButton.Click += new System.EventHandler(this.ZoomOutFillStyleButton_Click);
			' 
			' ZoomOutResetsAxesCheckBox
			' 
			Me.ZoomOutResetsAxesCheckBox.ButtonProperties.BorderOffset = 2
			Me.ZoomOutResetsAxesCheckBox.Location = New System.Drawing.Point(8, 216)
			Me.ZoomOutResetsAxesCheckBox.Name = "ZoomOutResetsAxesCheckBox"
			Me.ZoomOutResetsAxesCheckBox.Size = New System.Drawing.Size(152, 24)
			Me.ZoomOutResetsAxesCheckBox.TabIndex = 8
			Me.ZoomOutResetsAxesCheckBox.Text = "Zoom out resets axes"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ZoomOutResetsAxesCheckBox.CheckedChanged += new System.EventHandler(this.ZoomOutResetsAxesCheckBox_CheckedChanged);
			' 
			' HorizontalAxisSnapModeComboBox
			' 
			Me.HorizontalAxisSnapModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.HorizontalAxisSnapModeComboBox.ListProperties.DataSource = Nothing
			Me.HorizontalAxisSnapModeComboBox.ListProperties.DisplayMember = ""
			Me.HorizontalAxisSnapModeComboBox.Location = New System.Drawing.Point(8, 472)
			Me.HorizontalAxisSnapModeComboBox.Name = "HorizontalAxisSnapModeComboBox"
			Me.HorizontalAxisSnapModeComboBox.Size = New System.Drawing.Size(160, 21)
			Me.HorizontalAxisSnapModeComboBox.TabIndex = 17
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HorizontalAxisSnapModeComboBox.SelectedIndexChanged += new System.EventHandler(this.HorizontalAxisSnapModeComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 448)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(152, 23)
			Me.label2.TabIndex = 16
			Me.label2.Text = "Horizontal axis snap mode:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 496)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(128, 23)
			Me.label3.TabIndex = 18
			Me.label3.Text = "Vertical axis snap mode:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' VerticalAxisSnapModeComboBox
			' 
			Me.VerticalAxisSnapModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.VerticalAxisSnapModeComboBox.ListProperties.DataSource = Nothing
			Me.VerticalAxisSnapModeComboBox.ListProperties.DisplayMember = ""
			Me.VerticalAxisSnapModeComboBox.Location = New System.Drawing.Point(8, 520)
			Me.VerticalAxisSnapModeComboBox.Name = "VerticalAxisSnapModeComboBox"
			Me.VerticalAxisSnapModeComboBox.Size = New System.Drawing.Size(160, 21)
			Me.VerticalAxisSnapModeComboBox.TabIndex = 19
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.VerticalAxisSnapModeComboBox.SelectedIndexChanged += new System.EventHandler(this.VerticalAxisSnapModeComboBox_SelectedIndexChanged);
			' 
			' AlwaysZoomInCheckBox
			' 
			Me.AlwaysZoomInCheckBox.ButtonProperties.BorderOffset = 2
			Me.AlwaysZoomInCheckBox.Location = New System.Drawing.Point(8, 240)
			Me.AlwaysZoomInCheckBox.Name = "AlwaysZoomInCheckBox"
			Me.AlwaysZoomInCheckBox.Size = New System.Drawing.Size(152, 24)
			Me.AlwaysZoomInCheckBox.TabIndex = 9
			Me.AlwaysZoomInCheckBox.Text = "Always zoom in"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AlwaysZoomInCheckBox.CheckedChanged += new System.EventHandler(this.AlwaysZoomInCheckBox_CheckedChanged);
			' 
			' PreserveAspectRatioCheckBox
			' 
			Me.PreserveAspectRatioCheckBox.ButtonProperties.BorderOffset = 2
			Me.PreserveAspectRatioCheckBox.Location = New System.Drawing.Point(8, 264)
			Me.PreserveAspectRatioCheckBox.Name = "PreserveAspectRatioCheckBox"
			Me.PreserveAspectRatioCheckBox.Size = New System.Drawing.Size(152, 24)
			Me.PreserveAspectRatioCheckBox.TabIndex = 10
			Me.PreserveAspectRatioCheckBox.Text = "Preserve aspect ratio"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PreserveAspectRatioCheckBox.CheckedChanged += new System.EventHandler(this.PreserveAspectRatioCheckBox_CheckedChanged);
			' 
			' WheelZoomCheckBox
			' 
			Me.WheelZoomCheckBox.ButtonProperties.BorderOffset = 2
			Me.WheelZoomCheckBox.Location = New System.Drawing.Point(8, 288)
			Me.WheelZoomCheckBox.Name = "WheelZoomCheckBox"
			Me.WheelZoomCheckBox.Size = New System.Drawing.Size(152, 24)
			Me.WheelZoomCheckBox.TabIndex = 21
			Me.WheelZoomCheckBox.Text = "Wheel Zoom"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WheelZoomCheckBox.CheckedChanged += new System.EventHandler(this.WheelZoomCheckBox_CheckedChanged);
			' 
			' NDataZoomToolUC
			' 
			Me.Controls.Add(Me.WheelZoomCheckBox)
			Me.Controls.Add(Me.PreserveAspectRatioCheckBox)
			Me.Controls.Add(Me.AlwaysZoomInCheckBox)
			Me.Controls.Add(Me.VerticalAxisSnapModeComboBox)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.HorizontalAxisSnapModeComboBox)
			Me.Controls.Add(Me.ZoomOutResetsAxesCheckBox)
			Me.Controls.Add(Me.ZoomOutFillStyleButton)
			Me.Controls.Add(Me.ZoomInFillStyleButton)
			Me.Controls.Add(Me.InteractivityToolComboBox)
			Me.Controls.Add(Me.label8)
			Me.Controls.Add(Me.SelectionAxesComboBox)
			Me.Controls.Add(Me.SampleChartComboBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.ResetAxesButton)
			Me.Controls.Add(Me.label4)
			Me.Name = "NDataZoomToolUC"
			Me.Size = New System.Drawing.Size(180, 664)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			SampleChartComboBox.Items.Add("XY Scatter Chart")
			SampleChartComboBox.Items.Add("XYZ Scatter Chart")

			SelectionAxesComboBox.Items.Add("Primary X - Primary Y")
			SelectionAxesComboBox.Items.Add("Primary Z - Primary Y")

			InteractivityToolComboBox.Items.Add("Data Zoom")
			InteractivityToolComboBox.Items.Add("Trackball")
			InteractivityToolComboBox.Items.Add("Zoom")
			InteractivityToolComboBox.Items.Add("Offset")

			HorizontalAxisSnapModeComboBox.Items.Add("None")
			HorizontalAxisSnapModeComboBox.Items.Add("Ruler")
			HorizontalAxisSnapModeComboBox.Items.Add("Major ticks")
			HorizontalAxisSnapModeComboBox.Items.Add("Minor ticks")
			HorizontalAxisSnapModeComboBox.Items.Add("Ruler Min/Max")

			VerticalAxisSnapModeComboBox.Items.Add("None")
			VerticalAxisSnapModeComboBox.Items.Add("Ruler")
			VerticalAxisSnapModeComboBox.Items.Add("Major ticks")
			VerticalAxisSnapModeComboBox.Items.Add("Minor ticks")
			VerticalAxisSnapModeComboBox.Items.Add("Ruler Min/Max")

			HorizontalAxisSnapModeComboBox.SelectedIndex = 0
			VerticalAxisSnapModeComboBox.SelectedIndex = 0

			SampleChartComboBox.SelectedIndex = 0
			SelectionAxesComboBox.SelectedIndex = 0
			InteractivityToolComboBox.SelectedIndex = 0
			ZoomOutResetsAxesCheckBox.Checked = False
			WheelZoomCheckBox.Checked = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Data Zoom Tool")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' update form controls
			UpdateDataZoomTool()
		End Sub

		Private Function GetAxisValueSnapperFromIndex(ByVal index As Integer) As NAxisValueSnapper
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
			End Select

			Return Nothing
		End Function

		Private Sub UpdateDataZoomTool()
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)

			chart.RangeSelections.Clear()

			Dim rangeSelection As New NRangeSelection()

			rangeSelection.MinHorizontalPageSize = 0
			rangeSelection.MinVerticalPageSize = 0
			rangeSelection.ZoomOutResetsAxis = ZoomOutResetsAxesCheckBox.Checked

			If SelectionAxesComboBox.SelectedIndex = 0 Then
				rangeSelection.HorizontalAxisId = CInt(StandardAxis.PrimaryX)
				rangeSelection.VerticalAxisId = CInt(StandardAxis.PrimaryY)
			Else
				rangeSelection.HorizontalAxisId = CInt(StandardAxis.Depth)
				rangeSelection.VerticalAxisId = CInt(StandardAxis.PrimaryY)
			End If

			rangeSelection.PreserveAspectRatio = PreserveAspectRatioCheckBox.Checked
			rangeSelection.HorizontalValueSnapper = GetAxisValueSnapperFromIndex(HorizontalAxisSnapModeComboBox.SelectedIndex)
			rangeSelection.VerticalValueSnapper = GetAxisValueSnapperFromIndex(VerticalAxisSnapModeComboBox.SelectedIndex)
			rangeSelection.ZoomOutResetsAxis = ZoomOutResetsAxesCheckBox.Checked

			chart.RangeSelections.Add(rangeSelection)

			m_DataZoomTool.AlwaysZoomIn = AlwaysZoomInCheckBox.Checked

			If WheelZoomCheckBox.Checked Then
				m_DataZoomTool.WheelZoomAtMouse = True
				m_DataZoomTool.BeginDragMouseCommand = New NMouseCommand(MouseAction.Wheel, MouseButton.None, 0)
			Else
				m_DataZoomTool.BeginDragMouseCommand = New NMouseCommand(MouseAction.Down, MouseButton.Left, 1)
			End If
		End Sub

		Private Sub AddSeries(ByVal chart As NChart)
			' add point series
			chart.Series.Clear()
			Dim point1 As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			point1.Name = "Point 1"
			point1.PointShape = PointShape.Bar
			point1.Size = New NLength(5, NGraphicsUnit.Point)
			point1.FillStyle = New NColorFillStyle(Color.Red)
			point1.BorderStyle.Color = Color.Pink
			point1.DataLabelStyle.Visible = False
			point1.UseXValues = True
			point1.UseZValues = True
			point1.InflateMargins = True

			Dim point2 As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			point2.Name = "Point 2"
			point2.PointShape = PointShape.Bar
			point2.Size = New NLength(5, NGraphicsUnit.Point)
			point2.FillStyle = New NColorFillStyle(Color.CornflowerBlue)
			point2.BorderStyle.Color = Color.LightCyan
			point2.DataLabelStyle.Visible = False
			point2.UseXValues = True
			point2.UseZValues = True
			point2.InflateMargins = True

			Dim point3 As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			point3.Name = "Point 3"
			point3.PointShape = PointShape.Bar
			point3.Size = New NLength(5, NGraphicsUnit.Point)
			point3.FillStyle = New NColorFillStyle(Color.Green)
			point3.BorderStyle.Color = Color.Chartreuse
			point3.DataLabelStyle.Visible = False
			point3.UseXValues = True
			point3.UseZValues = True
			point3.InflateMargins = True

			' fill with random data
			point1.Values.FillRandomRange(Random, 10, 0, 50)
			point1.XValues.FillRandomRange(Random, 10, 0, 50)
			point1.ZValues.FillRandomRange(Random, 10, 0, 50)

			point2.Values.FillRandomRange(Random, 10, 25, 75)
			point2.XValues.FillRandomRange(Random, 10, 25, 75)
			point2.ZValues.FillRandomRange(Random, 10, 25, 75)

			point3.Values.FillRandomRange(Random, 10, 75, 125)
			point3.XValues.FillRandomRange(Random, 10, 75, 125)
			point3.ZValues.FillRandomRange(Random, 10, 75, 125)
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

		Private Sub ConfigureXYScatterChart()
			' 2D line chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Axis(StandardAxis.Depth).Visible = False

			chart.Enable3D = False
			chart.BoundsMode = BoundsMode.Stretch

			chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(12, NRelativeUnit.ParentPercentage))

			chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(78, NRelativeUnit.ParentPercentage))

			chart.Series.Clear()

			' configure axis pagin and set a mimimum range length on the axis
			' this will prevent the user from zooming too much
			chart.Axis(StandardAxis.PrimaryX).PagingView = New NNumericAxisPagingView()
			chart.Axis(StandardAxis.PrimaryX).PagingView.MinPageLength = 0.00001
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = GetScaleConfigurator()

			chart.Axis(StandardAxis.PrimaryY).PagingView = New NNumericAxisPagingView()
			chart.Axis(StandardAxis.PrimaryY).PagingView.MinPageLength = 0.00001F
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = GetScaleConfigurator()

			AddSeries(chart)
		End Sub

		Private Sub ConfigureXYZScatterChart()
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.BoundsMode = BoundsMode.Fit

			chart.Location = New NPointL(New NLength(8, NRelativeUnit.ParentPercentage), New NLength(8, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(84, NRelativeUnit.ParentPercentage), New NLength(84, NRelativeUnit.ParentPercentage))

			' set chart proportions
			chart.Depth = 55.0F
			chart.Width = 55.0F
			chart.Height = 55.0F

			' configure the primary X axis
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = GetScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).PagingView = New NNumericAxisPagingView()

			' configure the primary Y axis
			chart.Axis(StandardAxis.PrimaryY).PagingView = New NNumericAxisPagingView()
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = GetScaleConfigurator()

			' configure the depth axis
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = GetScaleConfigurator()
			chart.Axis(StandardAxis.Depth).PagingView = New NNumericAxisPagingView()

			AddSeries(chart)
		End Sub

		Private Sub ResetAxesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ResetAxesButton.Click
			Dim chart As NChart = CType(nChartControl1.Charts(0), NChart)

			chart.Axis(StandardAxis.PrimaryX).PagingView.Enabled = False
			chart.Axis(StandardAxis.PrimaryY).PagingView.Enabled = False
			chart.Axis(StandardAxis.Depth).PagingView.Enabled = False

			nChartControl1.Refresh()
		End Sub

		Private Sub SampleChartComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SampleChartComboBox.SelectedIndexChanged
			If SampleChartComboBox.SelectedIndex = 0 Then
				ConfigureXYScatterChart()
				SelectionAxesComboBox.SelectedIndex = 0
				SelectionAxesComboBox.Enabled = False
			Else
				ConfigureXYZScatterChart()
				SelectionAxesComboBox.Enabled = True
			End If

			ResetAxesButton_Click(Nothing, Nothing)
		End Sub

		Private Sub SelectionAxesComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectionAxesComboBox.SelectedIndexChanged
			UpdateDataZoomTool()
		End Sub

		Private Sub InteractivityToolComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InteractivityToolComboBox.SelectedIndexChanged
			nChartControl1.Controller.Tools.Clear()

			Select Case InteractivityToolComboBox.SelectedIndex
				Case 0
					Dim selector As New NPanelSelectorTool()
					selector.Focus = True

					nChartControl1.Controller.Tools.Add(selector)
					nChartControl1.Controller.Tools.Add(New NAxisScrollTool())
					nChartControl1.Controller.Tools.Add(m_DataZoomTool)
				Case 1
					nChartControl1.Controller.Tools.Add(New NTrackballTool())
				Case 2
					nChartControl1.Controller.Tools.Add(New NZoomTool())
				Case 3
					nChartControl1.Controller.Tools.Add(New NOffsetTool())
			End Select
		End Sub

		Private Sub ZoomInFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ZoomInFillStyleButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_DataZoomTool.ZoomInFillStyle, fillStyleResult) Then
				m_DataZoomTool.ZoomInFillStyle = fillStyleResult
			End If
		End Sub

		Private Sub ZoomOutFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ZoomOutFillStyleButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_DataZoomTool.ZoomOutFillStyle, fillStyleResult) Then
				m_DataZoomTool.ZoomOutFillStyle = fillStyleResult
			End If
		End Sub

		Private Sub ZoomOutResetsAxesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ZoomOutResetsAxesCheckBox.CheckedChanged
			UpdateDataZoomTool()
		End Sub

		Private Sub ClampValuesToRulerCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateDataZoomTool()
		End Sub

		Private Sub HorizontalAxisSnapModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HorizontalAxisSnapModeComboBox.SelectedIndexChanged
			UpdateDataZoomTool()
		End Sub

		Private Sub VerticalAxisSnapModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VerticalAxisSnapModeComboBox.SelectedIndexChanged
			UpdateDataZoomTool()
		End Sub

		Private Sub PreserveAspectRatioCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PreserveAspectRatioCheckBox.CheckedChanged
			UpdateDataZoomTool()

			HorizontalAxisSnapModeComboBox.Enabled = Not PreserveAspectRatioCheckBox.Checked
			VerticalAxisSnapModeComboBox.Enabled = Not PreserveAspectRatioCheckBox.Checked
		End Sub

		Private Sub AlwaysZoomInCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AlwaysZoomInCheckBox.CheckedChanged
			UpdateDataZoomTool()
		End Sub

		Private Sub WheelZoomCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles WheelZoomCheckBox.CheckedChanged
			UpdateDataZoomTool()
		End Sub
	End Class
End Namespace
