Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class ViewportToScaleUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Point As NPointSeries
		Private WithEvents XZPlaneValueNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents XYPlaneValueNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ResetPointsButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents CreatePointAtPlaneComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents MouseModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private ClampValuesToRulerCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private components As System.ComponentModel.Container = Nothing

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
			Me.CreatePointAtPlaneComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.XZPlaneValueNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.XYPlaneValueNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.ResetPointsButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label4 = New System.Windows.Forms.Label()
			Me.MouseModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.ClampValuesToRulerCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			DirectCast(Me.XZPlaneValueNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.XYPlaneValueNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' CreatePointAtPlaneComboBox
			' 
			Me.CreatePointAtPlaneComboBox.ListProperties.CheckBoxDataMember = ""
			Me.CreatePointAtPlaneComboBox.ListProperties.DataSource = Nothing
			Me.CreatePointAtPlaneComboBox.ListProperties.DisplayMember = ""
			Me.CreatePointAtPlaneComboBox.Location = New System.Drawing.Point(5, 79)
			Me.CreatePointAtPlaneComboBox.Name = "CreatePointAtPlaneComboBox"
			Me.CreatePointAtPlaneComboBox.Size = New System.Drawing.Size(171, 21)
			Me.CreatePointAtPlaneComboBox.TabIndex = 0
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.CreatePointAtPlaneComboBox.SelectedIndexChanged += new System.EventHandler(this.CreatePointAtPlaneComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(5, 57)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(171, 16)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Create point at plane:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(5, 106)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(171, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "XZ plane value:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(5, 154)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(171, 16)
			Me.label3.TabIndex = 3
			Me.label3.Text = "XY plane value:"
			' 
			' XZPlaneValueNumericUpDown
			' 
			Me.XZPlaneValueNumericUpDown.Location = New System.Drawing.Point(5, 128)
			Me.XZPlaneValueNumericUpDown.Name = "XZPlaneValueNumericUpDown"
			Me.XZPlaneValueNumericUpDown.Size = New System.Drawing.Size(171, 20)
			Me.XZPlaneValueNumericUpDown.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XZPlaneValueNumericUpDown.ValueChanged += new System.EventHandler(this.XZPlaneValueNumericUpDown_ValueChanged);
			' 
			' XYPlaneValueNumericUpDown
			' 
			Me.XYPlaneValueNumericUpDown.Location = New System.Drawing.Point(5, 176)
			Me.XYPlaneValueNumericUpDown.Name = "XYPlaneValueNumericUpDown"
			Me.XYPlaneValueNumericUpDown.Size = New System.Drawing.Size(171, 20)
			Me.XYPlaneValueNumericUpDown.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XYPlaneValueNumericUpDown.ValueChanged += new System.EventHandler(this.XYPlaneValueNumericUpDown_ValueChanged);
			' 
			' ResetPointsButton
			' 
			Me.ResetPointsButton.Location = New System.Drawing.Point(5, 232)
			Me.ResetPointsButton.Name = "ResetPointsButton"
			Me.ResetPointsButton.Size = New System.Drawing.Size(171, 23)
			Me.ResetPointsButton.TabIndex = 6
			Me.ResetPointsButton.Text = "Reset points"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ResetPointsButton.Click += new System.EventHandler(this.ResetPointsButton_Click);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(5, 8)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(171, 16)
			Me.label4.TabIndex = 7
			Me.label4.Text = "Mouse mode:"
			' 
			' MouseModeComboBox
			' 
			Me.MouseModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.MouseModeComboBox.ListProperties.DataSource = Nothing
			Me.MouseModeComboBox.ListProperties.DisplayMember = ""
			Me.MouseModeComboBox.Location = New System.Drawing.Point(5, 30)
			Me.MouseModeComboBox.Name = "MouseModeComboBox"
			Me.MouseModeComboBox.Size = New System.Drawing.Size(171, 21)
			Me.MouseModeComboBox.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MouseModeComboBox.SelectedIndexChanged += new System.EventHandler(this.MouseModeComboBox_SelectedIndexChanged);
			' 
			' ClampValuesToRulerCheckBox
			' 
			Me.ClampValuesToRulerCheckBox.ButtonProperties.BorderOffset = 2
			Me.ClampValuesToRulerCheckBox.Checked = True
			Me.ClampValuesToRulerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
			Me.ClampValuesToRulerCheckBox.Location = New System.Drawing.Point(5, 202)
			Me.ClampValuesToRulerCheckBox.Name = "ClampValuesToRulerCheckBox"
			Me.ClampValuesToRulerCheckBox.Size = New System.Drawing.Size(171, 24)
			Me.ClampValuesToRulerCheckBox.TabIndex = 9
			Me.ClampValuesToRulerCheckBox.Text = "Clamp values to ruler"
			' 
			' ViewportToScaleUC
			' 
			Me.Controls.Add(Me.ClampValuesToRulerCheckBox)
			Me.Controls.Add(Me.MouseModeComboBox)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.ResetPointsButton)
			Me.Controls.Add(Me.XYPlaneValueNumericUpDown)
			Me.Controls.Add(Me.XZPlaneValueNumericUpDown)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.CreatePointAtPlaneComboBox)
			Me.Name = "ViewportToScaleUC"
			Me.Size = New System.Drawing.Size(180, 494)
			DirectCast(Me.XZPlaneValueNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.XYPlaneValueNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Converting from viewport to scale coordinates")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' configure a free xyz point chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.BoundsMode = BoundsMode.Fit
			m_Chart.Location = New NPointL(New NLength(8, NRelativeUnit.ParentPercentage), New NLength(8, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(84, NRelativeUnit.ParentPercentage), New NLength(84, NRelativeUnit.ParentPercentage))

			m_Chart.Depth = 55.0F
			m_Chart.Width = 55.0F
			m_Chart.Height = 55.0F
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' configure x axis to scale in numeric linear mode
			Dim linearScale As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' configure y axis to scale in numeric linear mode
			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' configure depth axis to scale in numeric linear mode
			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			nChartControl1.Controller.Selection.Clear()
			nChartControl1.Controller.Selection.Add(m_Chart)

			m_Point = CType(m_Chart.Series.Add(SeriesType.Point), NPointSeries)
			m_Point.Name = "Point Series"
			m_Point.DataLabelStyle.Visible = False
			m_Point.Legend.Mode = SeriesLegendMode.DataPoints
			m_Point.Legend.Format = "<label>"
			m_Point.PointShape = PointShape.Sphere
			m_Point.FillStyle = New NColorFillStyle(Color.Red)
			m_Point.UseXValues = True
			m_Point.UseZValues = True

			' limit the axes to show the range [0, 100]
			m_Chart.Axis(StandardAxis.PrimaryX).View = New NRangeAxisView(New NRange1DD(0, 100))
			m_Chart.Axis(StandardAxis.PrimaryY).View = New NRangeAxisView(New NRange1DD(0, 100))
			m_Chart.Axis(StandardAxis.Depth).View = New NRangeAxisView(New NRange1DD(0, 100))

			' create the point creation planes
			Dim xzPlane As New NAxisConstLine()
			xzPlane.Mode = ConstLineMode.Plane
			xzPlane.FillStyle = New NColorFillStyle(Color.FromArgb(125, 255, 0, 0))
			xzPlane.Value = 0
			m_Chart.Axis(StandardAxis.PrimaryY).ConstLines.Add(xzPlane)

			Dim xyPlane As New NAxisConstLine()
			xyPlane.Mode = ConstLineMode.Plane
			xyPlane.FillStyle = New NColorFillStyle(Color.FromArgb(125, 0, 0, 255))
			xyPlane.Value = 0
			m_Chart.Axis(StandardAxis.Depth).ConstLines.Add(xyPlane)

			' init form controls
			CreatePointAtPlaneComboBox.Items.Add("XZ plane")
			CreatePointAtPlaneComboBox.Items.Add("XY plane")
			CreatePointAtPlaneComboBox.SelectedIndex = 0

			MouseModeComboBox.Items.Add("Create Point")
			MouseModeComboBox.Items.Add("Trackball")
			MouseModeComboBox.Items.Add("Zoom")
			MouseModeComboBox.Items.Add("Offset")
			MouseModeComboBox.SelectedIndex = 0

			XYPlaneValueNumericUpDown.Value = CDec(50)
			XZPlaneValueNumericUpDown.Value = CDec(50)

			' register for the mouse down event
			AddHandler nChartControl1.MouseDown, AddressOf OnChartMouseDown
		End Sub

		Private Sub XYPlaneValueNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles XYPlaneValueNumericUpDown.ValueChanged
			Dim xyPlane As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.Depth).ConstLines(0), NAxisConstLine)
			xyPlane.Value = CDbl(XYPlaneValueNumericUpDown.Value)

			nChartControl1.Refresh()
		End Sub

		Private Sub XZPlaneValueNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles XZPlaneValueNumericUpDown.ValueChanged
			Dim xzPlane As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryY).ConstLines(0), NAxisConstLine)
			xzPlane.Value = CDbl(XZPlaneValueNumericUpDown.Value)

			nChartControl1.Refresh()
		End Sub

		Private Sub CreatePointAtPlaneComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CreatePointAtPlaneComboBox.SelectedIndexChanged
			Dim xyPlane As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.Depth).ConstLines(0), NAxisConstLine)
			Dim xzPlane As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryY).ConstLines(0), NAxisConstLine)

			If CreatePointAtPlaneComboBox.SelectedIndex = 0 Then
				xzPlane.FillStyle = New NColorFillStyle(Color.FromArgb(125, 255, 0, 0))
				xyPlane.FillStyle = New NColorFillStyle(Color.FromArgb(125, 0, 0, 255))

				XZPlaneValueNumericUpDown.Enabled = True
				XYPlaneValueNumericUpDown.Enabled = False
			Else
				xzPlane.FillStyle = New NColorFillStyle(Color.FromArgb(125, 0, 0, 255))
				xyPlane.FillStyle = New NColorFillStyle(Color.FromArgb(125, 255, 0, 0))

				XZPlaneValueNumericUpDown.Enabled = False
				XYPlaneValueNumericUpDown.Enabled = True
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub ResetPointsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ResetPointsButton.Click
			m_Point.XValues.Clear()
			m_Point.ZValues.Clear()
			m_Point.Values.Clear()
			m_Point.Labels.Clear()

			nChartControl1.Refresh()
		End Sub

		Private Sub MouseModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MouseModeComboBox.SelectedIndexChanged
			Dim tool As NTool = Nothing
			Dim bEnableCreatePointControls As Boolean = False

			Select Case MouseModeComboBox.SelectedIndex
				' Create Point
				Case 0
					bEnableCreatePointControls = True
				' Trackball
				Case 1
					tool = New NTrackballTool()
				' Zoom
				Case 2
					tool = New NZoomTool()
				' Offset
				Case 3
					tool = New NOffsetTool()
			End Select

			nChartControl1.Controller.Tools.Clear()

			If tool IsNot Nothing Then
				nChartControl1.Controller.Tools.Add(tool)
			End If

			CreatePointAtPlaneComboBox.Enabled = bEnableCreatePointControls

			If CreatePointAtPlaneComboBox.SelectedIndex = 0 Then
				XZPlaneValueNumericUpDown.Enabled = bEnableCreatePointControls
				XYPlaneValueNumericUpDown.Enabled = False
			Else
				XZPlaneValueNumericUpDown.Enabled = False
				XYPlaneValueNumericUpDown.Enabled = bEnableCreatePointControls
			End If
		End Sub
		Private Sub OnChartMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
			If MouseModeComboBox.SelectedIndex <> 0 Then
				Return
			End If

			Dim ptViewPoint As New NPointF(CSng(e.X), CSng(e.Y))
			Dim vecScalePoint As New NVector3DD()
			Dim viewToScale As NViewToScale3DTransformation

			Dim xAxis As NAxis = m_Chart.Axis(StandardAxis.PrimaryX)
			Dim yAxis As NAxis = m_Chart.Axis(StandardAxis.PrimaryY)
			Dim zAxis As NAxis = m_Chart.Axis(StandardAxis.Depth)

			If CreatePointAtPlaneComboBox.SelectedIndex = 0 Then
				viewToScale = New NViewToScale3DTransformation(nChartControl1.View.Context, m_Chart, CInt(StandardAxis.PrimaryX), CInt(StandardAxis.Depth), CInt(StandardAxis.PrimaryY), CDbl(XZPlaneValueNumericUpDown.Value))

				If viewToScale.Transform(ptViewPoint, vecScalePoint) Then
					If ClampValuesToRulerCheckBox.Checked Then
						vecScalePoint.X = xAxis.Scale.ViewRange.GetValueInRange(vecScalePoint.X)
						vecScalePoint.Z = yAxis.Scale.ViewRange.GetValueInRange(vecScalePoint.Z)
						vecScalePoint.Y = zAxis.Scale.ViewRange.GetValueInRange(vecScalePoint.Y)
					End If

					m_Point.AddDataPoint(New NDataPoint(vecScalePoint.X, vecScalePoint.Z, vecScalePoint.Y, "Point" & m_Point.Values.Count.ToString()))
					nChartControl1.Refresh()
				End If
			Else
				viewToScale = New NViewToScale3DTransformation(nChartControl1.View.Context, m_Chart, CInt(StandardAxis.PrimaryX), CInt(StandardAxis.PrimaryY), CInt(StandardAxis.Depth), CDbl(XYPlaneValueNumericUpDown.Value))

				If viewToScale.Transform(ptViewPoint, vecScalePoint) Then
					If ClampValuesToRulerCheckBox.Checked Then
						vecScalePoint.X = xAxis.Scale.ViewRange.GetValueInRange(vecScalePoint.X)
						vecScalePoint.Y = yAxis.Scale.ViewRange.GetValueInRange(vecScalePoint.Y)
						vecScalePoint.Z = zAxis.Scale.ViewRange.GetValueInRange(vecScalePoint.Z)
					End If

					m_Point.AddDataPoint(New NDataPoint(vecScalePoint.X, vecScalePoint.Y, vecScalePoint.Z, "Point" & m_Point.Values.Count.ToString()))
					nChartControl1.Refresh()
				End If
			End If
		End Sub
	End Class
End Namespace
