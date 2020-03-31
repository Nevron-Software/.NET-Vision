Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Text
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NTrackingMouseEventsUC
		Inherits NExampleBaseUC

		Private m_bMouseDownRegistered As Boolean
		Private m_bMouseUpRegistered As Boolean
		Private m_bMouseMoveRegistered As Boolean
		Private m_bMouseLeaveRegistered As Boolean
		Private m_bMouseEnterRegistered As Boolean
		Private m_bMouseHoverRegistered As Boolean
		Private m_bMouseWheelRegistered As Boolean

		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private ButtonTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private label5 As System.Windows.Forms.Label
		Private ClicksTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents MouseDownCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents MouseUpCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents MouseMoveCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents MouseLeaveCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents MouseEnterCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents MouseHoverCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents MouseWheelCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label6 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private ChartObjectTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private MouseEventTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private XYTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents UseWindowRenderSurfaceCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label2 As System.Windows.Forms.Label
		Private groupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private ChartElementTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private label8 As System.Windows.Forms.Label
		Private textBox1 As Nevron.UI.WinForm.Controls.NTextBox
		Private DescriptionTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			m_bMouseDownRegistered = False
			m_bMouseUpRegistered = False
			m_bMouseMoveRegistered = False
			m_bMouseLeaveRegistered = False
			m_bMouseEnterRegistered = False
			m_bMouseHoverRegistered = False
			m_bMouseWheelRegistered = False
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
			Me.MouseDownCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.MouseUpCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.MouseMoveCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.MouseLeaveCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.MouseEnterCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.MouseHoverCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.MouseWheelCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.XYTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.ButtonTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.ClicksTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.ChartObjectTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.MouseEventTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.UseWindowRenderSurfaceCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.groupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.DescriptionTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label8 = New System.Windows.Forms.Label()
			Me.ChartElementTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.textBox1 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.groupBox3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' MouseDownCheckBox
			' 
			Me.MouseDownCheckBox.ButtonProperties.BorderOffset = 2
			Me.MouseDownCheckBox.Location = New System.Drawing.Point(7, 16)
			Me.MouseDownCheckBox.Name = "MouseDownCheckBox"
			Me.MouseDownCheckBox.Size = New System.Drawing.Size(96, 20)
			Me.MouseDownCheckBox.TabIndex = 0
			Me.MouseDownCheckBox.Text = "Mouse down"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MouseDownCheckBox.CheckedChanged += new System.EventHandler(this.MouseDownCheckBox_CheckedChanged);
			' 
			' MouseUpCheckBox
			' 
			Me.MouseUpCheckBox.ButtonProperties.BorderOffset = 2
			Me.MouseUpCheckBox.Location = New System.Drawing.Point(7, 35)
			Me.MouseUpCheckBox.Name = "MouseUpCheckBox"
			Me.MouseUpCheckBox.Size = New System.Drawing.Size(96, 20)
			Me.MouseUpCheckBox.TabIndex = 1
			Me.MouseUpCheckBox.Text = "Mouse up"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MouseUpCheckBox.CheckedChanged += new System.EventHandler(this.MouseUpCheckBox_CheckedChanged);
			' 
			' MouseMoveCheckBox
			' 
			Me.MouseMoveCheckBox.ButtonProperties.BorderOffset = 2
			Me.MouseMoveCheckBox.Location = New System.Drawing.Point(7, 54)
			Me.MouseMoveCheckBox.Name = "MouseMoveCheckBox"
			Me.MouseMoveCheckBox.Size = New System.Drawing.Size(96, 20)
			Me.MouseMoveCheckBox.TabIndex = 2
			Me.MouseMoveCheckBox.Text = "Mouse move"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MouseMoveCheckBox.CheckedChanged += new System.EventHandler(this.MouseMoveCheckBox_CheckedChanged);
			' 
			' MouseLeaveCheckBox
			' 
			Me.MouseLeaveCheckBox.ButtonProperties.BorderOffset = 2
			Me.MouseLeaveCheckBox.Location = New System.Drawing.Point(7, 73)
			Me.MouseLeaveCheckBox.Name = "MouseLeaveCheckBox"
			Me.MouseLeaveCheckBox.Size = New System.Drawing.Size(96, 20)
			Me.MouseLeaveCheckBox.TabIndex = 3
			Me.MouseLeaveCheckBox.Text = "Mouse leave"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MouseLeaveCheckBox.CheckedChanged += new System.EventHandler(this.MouseLeaveCheckBox_CheckedChanged);
			' 
			' MouseEnterCheckBox
			' 
			Me.MouseEnterCheckBox.ButtonProperties.BorderOffset = 2
			Me.MouseEnterCheckBox.Location = New System.Drawing.Point(7, 92)
			Me.MouseEnterCheckBox.Name = "MouseEnterCheckBox"
			Me.MouseEnterCheckBox.Size = New System.Drawing.Size(96, 20)
			Me.MouseEnterCheckBox.TabIndex = 4
			Me.MouseEnterCheckBox.Text = "Mouse enter"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MouseEnterCheckBox.CheckedChanged += new System.EventHandler(this.MouseEnterCheckBox_CheckedChanged);
			' 
			' MouseHoverCheckBox
			' 
			Me.MouseHoverCheckBox.ButtonProperties.BorderOffset = 2
			Me.MouseHoverCheckBox.Location = New System.Drawing.Point(7, 111)
			Me.MouseHoverCheckBox.Name = "MouseHoverCheckBox"
			Me.MouseHoverCheckBox.Size = New System.Drawing.Size(96, 20)
			Me.MouseHoverCheckBox.TabIndex = 5
			Me.MouseHoverCheckBox.Text = "Mouse hover"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MouseHoverCheckBox.CheckedChanged += new System.EventHandler(this.MouseHoverCheckBox_CheckedChanged);
			' 
			' MouseWheelCheckBox
			' 
			Me.MouseWheelCheckBox.ButtonProperties.BorderOffset = 2
			Me.MouseWheelCheckBox.Location = New System.Drawing.Point(7, 130)
			Me.MouseWheelCheckBox.Name = "MouseWheelCheckBox"
			Me.MouseWheelCheckBox.Size = New System.Drawing.Size(96, 20)
			Me.MouseWheelCheckBox.TabIndex = 6
			Me.MouseWheelCheckBox.Text = "Mouse wheel"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MouseWheelCheckBox.CheckedChanged += new System.EventHandler(this.MouseWheelCheckBox_CheckedChanged);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.MouseWheelCheckBox)
			Me.groupBox1.Controls.Add(Me.MouseLeaveCheckBox)
			Me.groupBox1.Controls.Add(Me.MouseMoveCheckBox)
			Me.groupBox1.Controls.Add(Me.MouseEnterCheckBox)
			Me.groupBox1.Controls.Add(Me.MouseHoverCheckBox)
			Me.groupBox1.Controls.Add(Me.MouseDownCheckBox)
			Me.groupBox1.Controls.Add(Me.MouseUpCheckBox)
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(5, 3)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(172, 153)
			Me.groupBox1.TabIndex = 7
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Track mouse events"
			' 
			' XYTextBox
			' 
			Me.XYTextBox.Location = New System.Drawing.Point(95, 41)
			Me.XYTextBox.Name = "XYTextBox"
			Me.XYTextBox.ReadOnly = True
			Me.XYTextBox.Size = New System.Drawing.Size(72, 18)
			Me.XYTextBox.TabIndex = 9
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(7, 41)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(32, 16)
			Me.label3.TabIndex = 12
			Me.label3.Text = "XY:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(7, 65)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(48, 16)
			Me.label4.TabIndex = 13
			Me.label4.Text = "Button:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ButtonTextBox
			' 
			Me.ButtonTextBox.Location = New System.Drawing.Point(95, 65)
			Me.ButtonTextBox.Name = "ButtonTextBox"
			Me.ButtonTextBox.ReadOnly = True
			Me.ButtonTextBox.Size = New System.Drawing.Size(72, 18)
			Me.ButtonTextBox.TabIndex = 14
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(7, 89)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(40, 16)
			Me.label5.TabIndex = 15
			Me.label5.Text = "Clicks:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ClicksTextBox
			' 
			Me.ClicksTextBox.Location = New System.Drawing.Point(95, 89)
			Me.ClicksTextBox.Name = "ClicksTextBox"
			Me.ClicksTextBox.ReadOnly = True
			Me.ClicksTextBox.Size = New System.Drawing.Size(72, 18)
			Me.ClicksTextBox.TabIndex = 16
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(7, 113)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(48, 16)
			Me.label6.TabIndex = 17
			Me.label6.Text = "Sender:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ChartObjectTextBox
			' 
			Me.ChartObjectTextBox.Location = New System.Drawing.Point(71, 113)
			Me.ChartObjectTextBox.Name = "ChartObjectTextBox"
			Me.ChartObjectTextBox.ReadOnly = True
			Me.ChartObjectTextBox.Size = New System.Drawing.Size(96, 18)
			Me.ChartObjectTextBox.TabIndex = 18
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(7, 17)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(72, 16)
			Me.label7.TabIndex = 19
			Me.label7.Text = "Mouse event:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' MouseEventTextBox
			' 
			Me.MouseEventTextBox.Location = New System.Drawing.Point(95, 17)
			Me.MouseEventTextBox.Name = "MouseEventTextBox"
			Me.MouseEventTextBox.ReadOnly = True
			Me.MouseEventTextBox.Size = New System.Drawing.Size(72, 18)
			Me.MouseEventTextBox.TabIndex = 20
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.XYTextBox)
			Me.groupBox2.Controls.Add(Me.label3)
			Me.groupBox2.Controls.Add(Me.label4)
			Me.groupBox2.Controls.Add(Me.ButtonTextBox)
			Me.groupBox2.Controls.Add(Me.label5)
			Me.groupBox2.Controls.Add(Me.ClicksTextBox)
			Me.groupBox2.Controls.Add(Me.label6)
			Me.groupBox2.Controls.Add(Me.ChartObjectTextBox)
			Me.groupBox2.Controls.Add(Me.label7)
			Me.groupBox2.Controls.Add(Me.MouseEventTextBox)
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(5, 162)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(172, 142)
			Me.groupBox2.TabIndex = 21
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Last mouse event"
			' 
			' UseWindowRenderSurfaceCheckBox
			' 
			Me.UseWindowRenderSurfaceCheckBox.ButtonProperties.BorderOffset = 2
			Me.UseWindowRenderSurfaceCheckBox.Location = New System.Drawing.Point(12, 485)
			Me.UseWindowRenderSurfaceCheckBox.Name = "UseWindowRenderSurfaceCheckBox"
			Me.UseWindowRenderSurfaceCheckBox.Size = New System.Drawing.Size(120, 24)
			Me.UseWindowRenderSurfaceCheckBox.TabIndex = 26
			Me.UseWindowRenderSurfaceCheckBox.Text = "Render to window"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UseWindowRenderSurfaceCheckBox.CheckedChanged += new System.EventHandler(this.UseWindowRenderSurfaceCheckBox_CheckedChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 15)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(117, 17)
			Me.label2.TabIndex = 26
			Me.label2.Text = "Chart element name:"
			' 
			' groupBox3
			' 
			Me.groupBox3.Controls.Add(Me.DescriptionTextBox)
			Me.groupBox3.Controls.Add(Me.label8)
			Me.groupBox3.Controls.Add(Me.ChartElementTextBox)
			Me.groupBox3.Controls.Add(Me.label2)
			Me.groupBox3.ImageIndex = 0
			Me.groupBox3.Location = New System.Drawing.Point(6, 299)
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.Size = New System.Drawing.Size(171, 187)
			Me.groupBox3.TabIndex = 27
			Me.groupBox3.TabStop = False
			Me.groupBox3.Text = "Hit test results"
			' 
			' DescriptionTextBox
			' 
			Me.DescriptionTextBox.Location = New System.Drawing.Point(9, 78)
			Me.DescriptionTextBox.Multiline = True
			Me.DescriptionTextBox.Name = "DescriptionTextBox"
			Me.DescriptionTextBox.Size = New System.Drawing.Size(152, 102)
			Me.DescriptionTextBox.TabIndex = 29
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(9, 58)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(147, 17)
			Me.label8.TabIndex = 28
			Me.label8.Text = "Chart element description:"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ChartElementTextBox
			' 
			Me.ChartElementTextBox.Location = New System.Drawing.Point(9, 33)
			Me.ChartElementTextBox.Name = "ChartElementTextBox"
			Me.ChartElementTextBox.Size = New System.Drawing.Size(153, 18)
			Me.ChartElementTextBox.TabIndex = 27
			' 
			' textBox1
			' 
			Me.textBox1.Location = New System.Drawing.Point(0, 0)
			Me.textBox1.Name = "textBox1"
			Me.textBox1.Size = New System.Drawing.Size(100, 20)
			Me.textBox1.TabIndex = 0
			' 
			' NTrackingMouseEventsUC
			' 
			Me.Controls.Add(Me.groupBox3)
			Me.Controls.Add(Me.UseWindowRenderSurfaceCheckBox)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NTrackingMouseEventsUC"
			Me.Size = New System.Drawing.Size(180, 579)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox3.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			CreateSampleChart()

			UpdateMouseEventsOperation()
		End Sub

		Private Sub CreateSampleChart()
			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Tracking Mouse Events")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim chart As NChart = nChartControl1.Charts(0)

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' apply lighting and projection
			chart.Enable3D = True
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)

			' add line series
			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line.Name = "Line"
			line.LineSegmentShape = LineSegmentShape.Tape
			line.DataLabelStyle.Visible = False
			line.Values.FillRandomRange(Random, 10, 10, 30)

			' add bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar"
			bar.DataLabelStyle.Visible = False
			bar.Values.FillRandomRange(Random, 10, 40, 60)

			' add area series 			
			Dim area As NAreaSeries = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			area.Name = "Area"
			area.DataLabelStyle.Visible = False
			area.Values.FillRandomRange(Random, 10, 60, 100)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			nChartControl1.Refresh()
		End Sub

		Private Sub UpdateMouseEventsOperation()
			If MouseDownCheckBox.Checked Then
				If m_bMouseDownRegistered = False Then
					m_bMouseDownRegistered = True
					AddHandler nChartControl1.MouseDown, AddressOf OnChartMouseDown
				End If
			Else
				If m_bMouseDownRegistered = True Then
					RemoveHandler nChartControl1.MouseDown, AddressOf OnChartMouseDown
					m_bMouseDownRegistered = False
				End If
			End If

			If MouseUpCheckBox.Checked Then
				If m_bMouseUpRegistered = False Then
					m_bMouseUpRegistered = True
					AddHandler nChartControl1.MouseUp, AddressOf OnChartMouseUp
				End If
			Else
				If m_bMouseUpRegistered = True Then
					m_bMouseUpRegistered = False
					RemoveHandler nChartControl1.MouseUp, AddressOf OnChartMouseUp
				End If
			End If

			If MouseWheelCheckBox.Checked Then
				If m_bMouseWheelRegistered = False Then
					m_bMouseWheelRegistered = True
					AddHandler nChartControl1.MouseWheel, AddressOf OnChartMouseWheel
				End If
			Else
				If m_bMouseWheelRegistered = True Then
					m_bMouseWheelRegistered = False
					RemoveHandler nChartControl1.MouseWheel, AddressOf OnChartMouseWheel
				End If
			End If

			If MouseMoveCheckBox.Checked Then
				If m_bMouseMoveRegistered = False Then
					m_bMouseMoveRegistered = True
					AddHandler nChartControl1.MouseMove, AddressOf OnChartMouseMove
				End If
			Else
				If m_bMouseMoveRegistered = True Then
					m_bMouseMoveRegistered = False
					RemoveHandler nChartControl1.MouseMove, AddressOf OnChartMouseMove
				End If
			End If

			If MouseEnterCheckBox.Checked Then
				If m_bMouseEnterRegistered = False Then
					m_bMouseEnterRegistered = True
					AddHandler nChartControl1.MouseEnter, AddressOf OnChartMouseEnter
				End If
			Else
				If m_bMouseEnterRegistered = True Then
					m_bMouseEnterRegistered = False
					RemoveHandler nChartControl1.MouseEnter, AddressOf OnChartMouseEnter
				End If
			End If

			If MouseLeaveCheckBox.Checked Then
				If m_bMouseLeaveRegistered = False Then
					m_bMouseLeaveRegistered = True
					AddHandler nChartControl1.MouseLeave, AddressOf OnChartMouseLeave
				End If
			Else
				If m_bMouseLeaveRegistered = True Then
					m_bMouseLeaveRegistered = False
					RemoveHandler nChartControl1.MouseLeave, AddressOf OnChartMouseLeave
				End If
			End If

			If MouseHoverCheckBox.Checked Then
				If m_bMouseHoverRegistered = False Then
					m_bMouseHoverRegistered = True
					AddHandler nChartControl1.MouseHover, AddressOf OnChartMouseHover
				End If
			Else
				If m_bMouseHoverRegistered = True Then
					m_bMouseHoverRegistered = False
					RemoveHandler nChartControl1.MouseHover, AddressOf OnChartMouseHover
				End If
			End If
		End Sub

		Protected Sub ProcessMouseEvent(ByVal mouseEvent As String, ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim strBuild As New StringBuilder()
			MouseEventTextBox.Text = mouseEvent
			ButtonTextBox.Text = e.Button.ToString()
			ChartObjectTextBox.Text = sender.GetType().ToString()

			strBuild.AppendFormat("{0}, ", e.X)
			strBuild.AppendFormat("{0}", e.Y)
			XYTextBox.Text = strBuild.ToString()
			strBuild.Remove(0, strBuild.Length)

			strBuild.AppendFormat("{0}", e.Clicks)
			ClicksTextBox.Text = strBuild.ToString()

			Dim sInfo As String = GetResultDescription(nChartControl1.HitTest(e.X, e.Y))
			DescriptionTextBox.Text = sInfo
		End Sub

		Protected Sub ProcessEvent(ByVal mouseEvent As String, ByVal sender As Object, ByVal e As EventArgs)
			Dim strBuild As New StringBuilder()
			MouseEventTextBox.Text = mouseEvent
			ButtonTextBox.Text = ""
			ChartObjectTextBox.Text = sender.GetType().ToString()

			XYTextBox.Text = ""
			ClicksTextBox.Text = ""
		End Sub

		Private Function GetResultDescription(ByVal hitTestResult As NHitTestResult) As String
			Dim nChartElement As Integer = CInt(hitTestResult.ChartElement)
			Dim sInfo As String = ""
			ChartElementTextBox.Text = hitTestResult.ChartElement.ToString()

			Select Case hitTestResult.ChartElement
				Case ChartElement.Nothing
					sInfo = "Nothing"
				Case ChartElement.ControlBackground
					sInfo = "Control background"
				Case ChartElement.DataPoint
					sInfo = "Data point [" & hitTestResult.DataPointIndex.ToString() & "] from series [" & CType(hitTestResult.Object.ParentNode, NSeriesBase).Name & "]"
				Case ChartElement.SurfaceDataPoint
					sInfo = "Surface data point [" & hitTestResult.SurfaceDataPointX.ToString() & ", " & hitTestResult.SurfaceDataPointZ.ToString()
				Case ChartElement.Axis
					sInfo = "Axis [" & hitTestResult.ObjectIndex & "]"
				Case ChartElement.ChartWall
					sInfo = "Wall [" & hitTestResult.ObjectIndex & "]"
				Case ChartElement.Legend
					sInfo = "Legend"
				Case ChartElement.LegendDataItem
					sInfo = "Legend data item [" & hitTestResult.ObjectIndex.ToString() & "]"
				Case ChartElement.LegendHeader
					sInfo = "Legend header"
				Case ChartElement.LegendFooter
					sInfo = "Legend footer"
				Case ChartElement.AxisStripe
					sInfo = "Axis stripe"
				Case ChartElement.Label
					sInfo = "Label"
				Case ChartElement.Watermark
					sInfo = "Watermark"
				Case ChartElement.Annotation
					sInfo = "Annotation"
				Case ChartElement.Chart
					sInfo = "Chart"
				Case Else
					Debug.Assert(False) ' new chart element?
			End Select

			Return sInfo
		End Function

		Public Sub FillParamsList(ByVal hitTestResult As NHitTestResult)

		End Sub

		Public Sub OnChartMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
			ProcessMouseEvent("MouseDown", sender, e)
		End Sub

		Public Sub OnChartMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
			ProcessMouseEvent("MouseUp", sender, e)
		End Sub

		Public Sub OnChartMouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)
			ProcessMouseEvent("MouseWheel", sender, e)
		End Sub

		Public Sub OnChartMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			ProcessMouseEvent("MouseMove", sender, e)
		End Sub

		Public Sub OnChartMouseEnter(ByVal sender As Object, ByVal e As EventArgs)
			ProcessEvent("MouseEnter", sender, e)
		End Sub

		Public Sub OnChartMouseLeave(ByVal sender As Object, ByVal e As EventArgs)
			ProcessEvent("MouseLeave", sender, e)
		End Sub

		Public Sub OnChartMouseHover(ByVal sender As Object, ByVal e As EventArgs)
			ProcessEvent("MouseHover", sender, e)
		End Sub

		Private Sub MouseDownCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MouseDownCheckBox.CheckedChanged
			UpdateMouseEventsOperation()
		End Sub

		Private Sub MouseUpCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MouseUpCheckBox.CheckedChanged
			UpdateMouseEventsOperation()
		End Sub

		Private Sub MouseMoveCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MouseMoveCheckBox.CheckedChanged
			UpdateMouseEventsOperation()
		End Sub

		Private Sub MouseLeaveCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MouseLeaveCheckBox.CheckedChanged
			UpdateMouseEventsOperation()
		End Sub

		Private Sub MouseEnterCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MouseEnterCheckBox.CheckedChanged
			UpdateMouseEventsOperation()
		End Sub

		Private Sub MouseHoverCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MouseHoverCheckBox.CheckedChanged
			UpdateMouseEventsOperation()
		End Sub

		Private Sub MouseWheelCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MouseWheelCheckBox.CheckedChanged
			UpdateMouseEventsOperation()
		End Sub

		Private Sub UseWindowRenderSurfaceCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UseWindowRenderSurfaceCheckBox.CheckedChanged
			If UseWindowRenderSurfaceCheckBox.Checked Then
				nChartControl1.Settings.RenderSurface = RenderSurface.Window
			Else
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap
			End If
		End Sub
	End Class
End Namespace

