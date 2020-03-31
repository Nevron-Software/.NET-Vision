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
	Public Class NStandardLineUC
		Inherits NExampleBaseUC

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private WithEvents LineStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents LineDepthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents LineFillColorButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents InflateMarginsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents RoundToTickCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents MarkerStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BorderStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LineSizeScroll As Nevron.UI.WinForm.Controls.NHScrollBar
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
			Me.SuspendLayout()
			' 
			' LineStyleCombo
			' 
			Me.LineStyleCombo.ListProperties.CheckBoxDataMember = ""
			Me.LineStyleCombo.ListProperties.DataSource = Nothing
			Me.LineStyleCombo.ListProperties.DisplayMember = ""
			Me.LineStyleCombo.Location = New System.Drawing.Point(6, 24)
			Me.LineStyleCombo.Name = "LineStyleCombo"
			Me.LineStyleCombo.Size = New System.Drawing.Size(168, 21)
			Me.LineStyleCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineStyleCombo.SelectedIndexChanged += new System.EventHandler(this.LineStyleCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(6, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(168, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Line Style:"
			' 
			' LineDepthScroll
			' 
			Me.LineDepthScroll.Location = New System.Drawing.Point(6, 74)
			Me.LineDepthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.LineDepthScroll.Name = "LineDepthScroll"
			Me.LineDepthScroll.Size = New System.Drawing.Size(168, 16)
			Me.LineDepthScroll.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LineDepthScroll_Scroll);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(6, 58)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(168, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Line Depth Percent:"
			' 
			' BorderStyleButton
			' 
			Me.BorderStyleButton.Location = New System.Drawing.Point(6, 149)
			Me.BorderStyleButton.Name = "BorderStyleButton"
			Me.BorderStyleButton.Size = New System.Drawing.Size(168, 24)
			Me.BorderStyleButton.TabIndex = 6
			Me.BorderStyleButton.Text = "Border Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BorderStyleButton.Click += new System.EventHandler(this.BorderPropsButton_Click);
			' 
			' LineFillColorButton
			' 
			Me.LineFillColorButton.Location = New System.Drawing.Point(6, 180)
			Me.LineFillColorButton.Name = "LineFillColorButton"
			Me.LineFillColorButton.Size = New System.Drawing.Size(168, 24)
			Me.LineFillColorButton.TabIndex = 7
			Me.LineFillColorButton.Text = "Line Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineFillColorButton.Click += new System.EventHandler(this.LineFillColorButton_Click);
			' 
			' InflateMarginsCheck
			' 
			Me.InflateMarginsCheck.ButtonProperties.BorderOffset = 2
			Me.InflateMarginsCheck.Location = New System.Drawing.Point(6, 247)
			Me.InflateMarginsCheck.Name = "InflateMarginsCheck"
			Me.InflateMarginsCheck.Size = New System.Drawing.Size(168, 20)
			Me.InflateMarginsCheck.TabIndex = 9
			Me.InflateMarginsCheck.Text = "Inflate Margins"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			' 
			' RoundToTickCheck
			' 
			Me.RoundToTickCheck.ButtonProperties.BorderOffset = 2
			Me.RoundToTickCheck.Location = New System.Drawing.Point(6, 274)
			Me.RoundToTickCheck.Name = "RoundToTickCheck"
			Me.RoundToTickCheck.Size = New System.Drawing.Size(168, 19)
			Me.RoundToTickCheck.TabIndex = 10
			Me.RoundToTickCheck.Text = "Left Axis Round to Tick"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RoundToTickCheck.CheckedChanged += new System.EventHandler(this.RoundToTickCheck_CheckedChanged);
			' 
			' MarkerStyleButton
			' 
			Me.MarkerStyleButton.Location = New System.Drawing.Point(6, 211)
			Me.MarkerStyleButton.Name = "MarkerStyleButton"
			Me.MarkerStyleButton.Size = New System.Drawing.Size(168, 24)
			Me.MarkerStyleButton.TabIndex = 8
			Me.MarkerStyleButton.Text = "Marker Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(6, 99)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(168, 16)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Line Size:"
			' 
			' LineSizeScroll
			' 
			Me.LineSizeScroll.Location = New System.Drawing.Point(6, 115)
			Me.LineSizeScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.LineSizeScroll.Name = "LineSizeScroll"
			Me.LineSizeScroll.Size = New System.Drawing.Size(168, 16)
			Me.LineSizeScroll.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LineSizeScroll_ValueChanged);
			' 
			' NStandardLineUC
			' 
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
			Me.Name = "NStandardLineUC"
			Me.Size = New System.Drawing.Size(180, 322)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("3D Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 65
			chart.Height = 40
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective2)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' add interlaced stripe to the Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator).StripStyles.Add(stripStyle)

			' add a line series
			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line.Name = "Line Series"
			line.InflateMargins = True
			line.DataLabelStyle.Visible = False
			line.MarkerStyle.Visible = True
			line.MarkerStyle.PointShape = PointShape.Cylinder
			line.MarkerStyle.Width = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Height = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			line.Values.FillRandom(Random, 8)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			LineStyleCombo.FillFromEnum(GetType(LineSegmentShape))
			LineStyleCombo.SelectedIndex = 0
			RoundToTickCheck.Checked = True
			InflateMarginsCheck.Checked = True
		End Sub

		Private Sub LineStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LineStyleCombo.SelectedIndexChanged
			Dim line As NLineSeries = CType(nChartControl1.Charts(0).Series(0), NLineSeries)

			Select Case LineStyleCombo.SelectedIndex
				Case 0 ' simple line
					line.LineSegmentShape = LineSegmentShape.Line
					LineDepthScroll.Enabled = False
					LineSizeScroll.Enabled = False
					LineFillColorButton.Enabled = False

				Case 1 ' tape
					line.LineSegmentShape = LineSegmentShape.Tape
					LineDepthScroll.Enabled = True
					LineSizeScroll.Enabled = False
					LineFillColorButton.Enabled = True

				Case 2 ' tube
					line.LineSegmentShape = LineSegmentShape.Tube
					LineDepthScroll.Enabled = False
					LineSizeScroll.Enabled = True
					LineFillColorButton.Enabled = True

				Case 3 ' ellipsoid
					line.LineSegmentShape = LineSegmentShape.Ellipsoid
					LineDepthScroll.Enabled = False
					LineSizeScroll.Enabled = True
					LineFillColorButton.Enabled = True
			End Select

			nChartControl1.Refresh()
		End Sub
		Private Sub BorderPropsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BorderStyleButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NStrokeStyleTypeEditor.Edit(series.BorderStyle, strokeStyleResult) Then
				series.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub LineDepthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles LineDepthScroll.ValueChanged
			Dim line As NLineSeries = CType(nChartControl1.Charts(0).Series(0), NLineSeries)
			line.DepthPercent = LineDepthScroll.Value
			nChartControl1.Refresh()
		End Sub
		Private Sub LineSizeScroll_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles LineSizeScroll.ValueChanged
			Dim line As NLineSeries = CType(nChartControl1.Charts(0).Series(0), NLineSeries)
			line.LineSize = New NLength(LineSizeScroll.Value / 40.0F, NRelativeUnit.ParentPercentage)
			nChartControl1.Refresh()
		End Sub
		Private Sub LineFillColorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LineFillColorButton.Click
			Dim fillStyleResult As NFillStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NFillStyleTypeEditor.Edit(series.FillStyle, fillStyleResult) Then
				series.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub InflateMarginsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InflateMarginsCheck.CheckedChanged
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)
			series.InflateMargins = InflateMarginsCheck.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub RoundToTickCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RoundToTickCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim scaleConfigurator As NStandardScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)

			If scaleConfigurator IsNot Nothing Then
				scaleConfigurator.RoundToTickMin = RoundToTickCheck.Checked
				scaleConfigurator.RoundToTickMax = RoundToTickCheck.Checked

				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub MarkerBorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim strokeStyleResult As NStrokeStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NStrokeStyleTypeEditor.Edit(series.MarkerStyle.BorderStyle, strokeStyleResult) Then
				series.MarkerStyle.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub MarkerFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim fillStyleResult As NFillStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NFillStyleTypeEditor.Edit(series.MarkerStyle.FillStyle, fillStyleResult) Then
				series.MarkerStyle.FillStyle = fillStyleResult
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
	End Class
End Namespace
