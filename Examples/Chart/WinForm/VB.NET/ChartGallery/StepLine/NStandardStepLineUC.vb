Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NStandardStepLineUC
		Inherits NExampleBaseUC

		Private m_Line As NStepLineSeries
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private WithEvents LineStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents LineDepthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents LineFillColorButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents InflateMarginsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents RoundToTickCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents MarkerStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents DataLabelStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LineSizeScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents BorderStyleButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.LineStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.LineDepthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.BorderStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.LineFillColorButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.InflateMarginsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.RoundToTickCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.MarkerStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label3 = New System.Windows.Forms.Label()
			Me.LineSizeScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.DataLabelStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' LineStyleCombo
			' 
			Me.LineStyleCombo.ListProperties.CheckBoxDataMember = ""
			Me.LineStyleCombo.ListProperties.DataSource = Nothing
			Me.LineStyleCombo.ListProperties.DisplayMember = ""
			Me.LineStyleCombo.Location = New System.Drawing.Point(5, 25)
			Me.LineStyleCombo.Name = "LineStyleCombo"
			Me.LineStyleCombo.Size = New System.Drawing.Size(169, 21)
			Me.LineStyleCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineStyleCombo.SelectedIndexChanged += new System.EventHandler(this.LineStyleCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(5, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(169, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Line Style:"
			' 
			' LineDepthScroll
			' 
			Me.LineDepthScroll.Location = New System.Drawing.Point(5, 86)
			Me.LineDepthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.LineDepthScroll.Name = "LineDepthScroll"
			Me.LineDepthScroll.Size = New System.Drawing.Size(169, 16)
			Me.LineDepthScroll.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LineDepthScroll_Scroll);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(5, 70)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(169, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Line Depth %:"
			' 
			' BorderStyleButton
			' 
			Me.BorderStyleButton.Location = New System.Drawing.Point(5, 163)
			Me.BorderStyleButton.Name = "BorderStyleButton"
			Me.BorderStyleButton.Size = New System.Drawing.Size(169, 24)
			Me.BorderStyleButton.TabIndex = 6
			Me.BorderStyleButton.Text = "Border Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BorderStyleButton.Click += new System.EventHandler(this.BorderPropsButton_Click);
			' 
			' LineFillColorButton
			' 
			Me.LineFillColorButton.Location = New System.Drawing.Point(5, 194)
			Me.LineFillColorButton.Name = "LineFillColorButton"
			Me.LineFillColorButton.Size = New System.Drawing.Size(169, 24)
			Me.LineFillColorButton.TabIndex = 7
			Me.LineFillColorButton.Text = "Line Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineFillColorButton.Click += new System.EventHandler(this.LineFillColorButton_Click);
			' 
			' InflateMarginsCheck
			' 
			Me.InflateMarginsCheck.ButtonProperties.BorderOffset = 2
			Me.InflateMarginsCheck.Location = New System.Drawing.Point(5, 297)
			Me.InflateMarginsCheck.Name = "InflateMarginsCheck"
			Me.InflateMarginsCheck.Size = New System.Drawing.Size(169, 20)
			Me.InflateMarginsCheck.TabIndex = 10
			Me.InflateMarginsCheck.Text = "Inflate Margins"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			' 
			' RoundToTickCheck
			' 
			Me.RoundToTickCheck.ButtonProperties.BorderOffset = 2
			Me.RoundToTickCheck.Location = New System.Drawing.Point(5, 324)
			Me.RoundToTickCheck.Name = "RoundToTickCheck"
			Me.RoundToTickCheck.Size = New System.Drawing.Size(169, 19)
			Me.RoundToTickCheck.TabIndex = 11
			Me.RoundToTickCheck.Text = "Left Axis Round to Tick"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RoundToTickCheck.CheckedChanged += new System.EventHandler(this.RoundToTickCheck_CheckedChanged);
			' 
			' MarkerStyleButton
			' 
			Me.MarkerStyleButton.Location = New System.Drawing.Point(5, 225)
			Me.MarkerStyleButton.Name = "MarkerStyleButton"
			Me.MarkerStyleButton.Size = New System.Drawing.Size(169, 24)
			Me.MarkerStyleButton.TabIndex = 8
			Me.MarkerStyleButton.Text = "Marker Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(5, 113)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(169, 16)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Line Size:"
			' 
			' LineSizeScroll
			' 
			Me.LineSizeScroll.Location = New System.Drawing.Point(5, 129)
			Me.LineSizeScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.LineSizeScroll.Name = "LineSizeScroll"
			Me.LineSizeScroll.Size = New System.Drawing.Size(169, 16)
			Me.LineSizeScroll.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LineSizeScroll_ValueChanged);
			' 
			' DataLabelStyleButton
			' 
			Me.DataLabelStyleButton.Location = New System.Drawing.Point(5, 256)
			Me.DataLabelStyleButton.Name = "DataLabelStyleButton"
			Me.DataLabelStyleButton.Size = New System.Drawing.Size(169, 24)
			Me.DataLabelStyleButton.TabIndex = 9
			Me.DataLabelStyleButton.Text = "Data Label Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DataLabelStyleButton.Click += new System.EventHandler(this.DataLabelStyleButton_Click);
			' 
			' NStandardStepLineUC
			' 
			Me.Controls.Add(Me.DataLabelStyleButton)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.LineSizeScroll)
			Me.Controls.Add(Me.MarkerStyleButton)
			Me.Controls.Add(Me.RoundToTickCheck)
			Me.Controls.Add(Me.InflateMarginsCheck)
			Me.Controls.Add(Me.LineFillColorButton)
			Me.Controls.Add(Me.BorderStyleButton)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.LineDepthScroll)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.LineStyleCombo)
			Me.Name = "NStandardStepLineUC"
			Me.Size = New System.Drawing.Size(180, 364)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("3D Step Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 65
			chart.Height = 40
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			' add interlace stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			m_Line = CType(chart.Series.Add(SeriesType.StepLine), NStepLineSeries)
			m_Line.Name = "Series 1"
			m_Line.DepthPercent = 50
			m_Line.LineSize = 2
			m_Line.DataLabelStyle.Visible = False
			m_Line.DataLabelStyle.Format = "<value>"
			m_Line.MarkerStyle.Visible = True
			m_Line.Values.FillRandom(Random, 8)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			LineStyleCombo.FillFromEnum(GetType(LineSegmentShape))
			LineStyleCombo.SelectedIndex = 1
			RoundToTickCheck.Checked = True
			InflateMarginsCheck.Checked = True
		End Sub

		Private Sub SetupTapeMarkers(ByVal marker As NMarkerStyle)
			marker.PointShape = PointShape.Cylinder
			marker.AutoDepth = True
			marker.Width = New NLength(1.2F, NRelativeUnit.ParentPercentage)
			marker.Height = New NLength(1.2F, NRelativeUnit.ParentPercentage)
		End Sub

		Private Sub SetupTubeMarkers(ByVal marker As NMarkerStyle)
			marker.PointShape = PointShape.Sphere
			marker.AutoDepth = False
			marker.Width = New NLength(3.5F, NRelativeUnit.ParentPercentage)
			marker.Height = New NLength(3.5F, NRelativeUnit.ParentPercentage)
			marker.Depth = New NLength(3.5F, NRelativeUnit.ParentPercentage)
		End Sub

		Private Sub LineStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LineStyleCombo.SelectedIndexChanged
			Select Case LineStyleCombo.SelectedIndex
				Case 0 ' simple line
					m_Line.LineSegmentShape = LineSegmentShape.Line
					LineDepthScroll.Enabled = False
					LineSizeScroll.Enabled = False
					LineFillColorButton.Enabled = False
					BorderStyleButton.Enabled = True
					SetupTapeMarkers(m_Line.MarkerStyle)

				Case 1 ' tape
					m_Line.LineSegmentShape = LineSegmentShape.Tape
					LineDepthScroll.Enabled = True
					LineSizeScroll.Enabled = False
					LineFillColorButton.Enabled = True
					BorderStyleButton.Enabled = True
					SetupTapeMarkers(m_Line.MarkerStyle)

				Case 2 ' tube
					m_Line.LineSegmentShape = LineSegmentShape.Tube
					LineDepthScroll.Enabled = False
					LineSizeScroll.Enabled = True
					LineFillColorButton.Enabled = True
					BorderStyleButton.Enabled = False
					SetupTubeMarkers(m_Line.MarkerStyle)

				Case 3 ' elipsoid
					m_Line.LineSegmentShape = LineSegmentShape.Ellipsoid
					LineDepthScroll.Enabled = False
					LineSizeScroll.Enabled = True
					LineFillColorButton.Enabled = True
					BorderStyleButton.Enabled = False
					SetupTubeMarkers(m_Line.MarkerStyle)
			End Select

			nChartControl1.Refresh()
		End Sub

		Private Sub BorderPropsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BorderStyleButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Line.BorderStyle, strokeStyleResult) Then
				m_Line.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub LineDepthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles LineDepthScroll.ValueChanged
			m_Line.DepthPercent = LineDepthScroll.Value
			nChartControl1.Refresh()
		End Sub

		Private Sub LineSizeScroll_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles LineSizeScroll.ValueChanged
			m_Line.LineSize = LineSizeScroll.Value / 10.0F
			nChartControl1.Refresh()
		End Sub

		Private Sub LineFillColorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LineFillColorButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_Line.FillStyle, fillStyleResult) Then
				m_Line.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub InflateMarginsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InflateMarginsCheck.CheckedChanged
			m_Line.InflateMargins = InflateMarginsCheck.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub RoundToTickCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RoundToTickCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim standardScale As NStandardScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)

			standardScale.RoundToTickMax = RoundToTickCheck.Checked
			standardScale.RoundToTickMin = RoundToTickCheck.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub MarkerBorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Line.MarkerStyle.BorderStyle, strokeStyleResult) Then
				m_Line.MarkerStyle.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub MarkerFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_Line.MarkerStyle.FillStyle, fillStyleResult) Then
				m_Line.MarkerStyle.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub MarkerStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MarkerStyleButton.Click
			Dim markerStyleResult As NMarkerStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NMarkerStyleTypeEditor.Edit(series.MarkerStyle, markerStyleResult) Then
				series.MarkerStyle = markerStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub DataLabelStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataLabelStyleButton.Click
			Dim dataLabelStyleResult As NDataLabelStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NDataLabelStyleTypeEditor.Edit(series.DataLabelStyle, dataLabelStyleResult) Then
				series.DataLabelStyle = dataLabelStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
