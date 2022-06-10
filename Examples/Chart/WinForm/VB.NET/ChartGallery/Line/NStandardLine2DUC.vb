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
	<ToolboxItem(False)>
	Public Class NStandardLine2DUC
		Inherits NExampleBaseUC

		Private label1 As System.Windows.Forms.Label
		Private WithEvents LineStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents InflateMarginsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents RoundToTickCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents LineFillColorButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LineShadowButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents MarkerStyleButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.BorderStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.LineFillColorButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.InflateMarginsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.RoundToTickCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.LineShadowButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.MarkerStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' LineStyleCombo
			' 
			Me.LineStyleCombo.ListProperties.CheckBoxDataMember = ""
			Me.LineStyleCombo.ListProperties.DataSource = Nothing
			Me.LineStyleCombo.ListProperties.DisplayMember = ""
			Me.LineStyleCombo.Location = New System.Drawing.Point(8, 22)
			Me.LineStyleCombo.Name = "LineStyleCombo"
			Me.LineStyleCombo.Size = New System.Drawing.Size(164, 21)
			Me.LineStyleCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineStyleCombo.SelectedIndexChanged += new System.EventHandler(this.LineStyleCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 6)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(164, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Line Style:"
			' 
			' BorderStyleButton
			' 
			Me.BorderStyleButton.Location = New System.Drawing.Point(8, 62)
			Me.BorderStyleButton.Name = "BorderStyleButton"
			Me.BorderStyleButton.Size = New System.Drawing.Size(164, 24)
			Me.BorderStyleButton.TabIndex = 2
			Me.BorderStyleButton.Text = "Border Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BorderStyleButton.Click += new System.EventHandler(this.BorderPropsButton_Click);
			' 
			' LineFillColorButton
			' 
			Me.LineFillColorButton.Location = New System.Drawing.Point(8, 93)
			Me.LineFillColorButton.Name = "LineFillColorButton"
			Me.LineFillColorButton.Size = New System.Drawing.Size(164, 24)
			Me.LineFillColorButton.TabIndex = 3
			Me.LineFillColorButton.Text = "Line Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineFillColorButton.Click += new System.EventHandler(this.LineFillColorButton_Click);
			' 
			' InflateMarginsCheck
			' 
			Me.InflateMarginsCheck.ButtonProperties.BorderOffset = 2
			Me.InflateMarginsCheck.Location = New System.Drawing.Point(8, 194)
			Me.InflateMarginsCheck.Name = "InflateMarginsCheck"
			Me.InflateMarginsCheck.Size = New System.Drawing.Size(164, 20)
			Me.InflateMarginsCheck.TabIndex = 6
			Me.InflateMarginsCheck.Text = "Inflate Margins"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			' 
			' RoundToTickCheck
			' 
			Me.RoundToTickCheck.ButtonProperties.BorderOffset = 2
			Me.RoundToTickCheck.Location = New System.Drawing.Point(8, 222)
			Me.RoundToTickCheck.Name = "RoundToTickCheck"
			Me.RoundToTickCheck.Size = New System.Drawing.Size(164, 20)
			Me.RoundToTickCheck.TabIndex = 7
			Me.RoundToTickCheck.Text = "Left Axis Round to Tick"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RoundToTickCheck.CheckedChanged += new System.EventHandler(this.RoundToTickCheck_CheckedChanged);
			' 
			' LineShadowButton
			' 
			Me.LineShadowButton.Location = New System.Drawing.Point(8, 124)
			Me.LineShadowButton.Name = "LineShadowButton"
			Me.LineShadowButton.Size = New System.Drawing.Size(164, 24)
			Me.LineShadowButton.TabIndex = 4
			Me.LineShadowButton.Text = "Line Shadow..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineShadowButton.Click += new System.EventHandler(this.LineShadowButton_Click);
			' 
			' MarkerStyleButton
			' 
			Me.MarkerStyleButton.Location = New System.Drawing.Point(8, 156)
			Me.MarkerStyleButton.Name = "MarkerStyleButton"
			Me.MarkerStyleButton.Size = New System.Drawing.Size(164, 24)
			Me.MarkerStyleButton.TabIndex = 5
			Me.MarkerStyleButton.Text = "Marker Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			' 
			' NStandardLine2DUC
			' 
			Me.Controls.Add(Me.MarkerStyleButton)
			Me.Controls.Add(Me.LineShadowButton)
			Me.Controls.Add(Me.RoundToTickCheck)
			Me.Controls.Add(Me.InflateMarginsCheck)
			Me.Controls.Add(Me.LineFillColorButton)
			Me.Controls.Add(Me.BorderStyleButton)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.LineStyleCombo)
			Me.Name = "NStandardLine2DUC"
			Me.Size = New System.Drawing.Size(180, 266)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("2D Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Axis(StandardAxis.Depth).Visible = False

			' add interlaced stripe to the Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator).StripStyles.Add(stripStyle)

			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line.Name = "Line Series"
			line.InflateMargins = True
			line.DataLabelStyle.Format = "<value>"
			line.MarkerStyle.Visible = True
			line.MarkerStyle.PointShape = PointShape.Cylinder
			line.MarkerStyle.Width = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Height = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			line.ShadowStyle.Type = ShadowType.GaussianBlur
			line.ShadowStyle.Offset = New NPointL(3, 3)
			line.ShadowStyle.FadeLength = New NLength(5)
			line.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0)
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
			Dim bSimpleLine As Boolean = (LineStyleCombo.SelectedIndex = 0)

			Select Case LineStyleCombo.SelectedIndex
				Case 0 ' simple line
					line.LineSegmentShape = LineSegmentShape.Line
					line.DepthPercent = 0

				Case 1 ' tape
					line.LineSegmentShape = LineSegmentShape.Tape
					line.DepthPercent = 50

				Case 2 ' tube
					line.LineSegmentShape = LineSegmentShape.Tube
					line.DepthPercent = 10

				Case 3 ' ellipsoid
					line.LineSegmentShape = LineSegmentShape.Ellipsoid
					line.DepthPercent = 10
			End Select

			LineFillColorButton.Enabled = Not bSimpleLine

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
		Private Sub LineFillColorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LineFillColorButton.Click
			Dim fillStyleResult As NFillStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NFillStyleTypeEditor.Edit(series.FillStyle, fillStyleResult) Then
				series.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub LineShadowButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LineShadowButton.Click
			Dim shadowStyleResult As NShadowStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NShadowStyleTypeEditor.Edit(series.ShadowStyle, shadowStyleResult) Then
				series.ShadowStyle = shadowStyleResult
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