Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NStandardAreaUC
		Inherits NExampleBaseUC

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private WithEvents DepthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents DropLinesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents AreaFEButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents AreaBorderButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents MarkerStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LabelStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents OriginModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents OriginValueTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			OriginModeCombo.FillFromEnum(GetType(SeriesOriginMode))
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
			Me.label3 = New System.Windows.Forms.Label()
			Me.DepthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.DropLinesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.AreaFEButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.AreaBorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.MarkerStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.LabelStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label2 = New System.Windows.Forms.Label()
			Me.OriginModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.OriginValueTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(9, 9)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(157, 16)
			Me.label3.TabIndex = 0
			Me.label3.Text = "Depth %:"
			' 
			' DepthScroll
			' 
			Me.DepthScroll.Location = New System.Drawing.Point(9, 25)
			Me.DepthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.DepthScroll.Name = "DepthScroll"
			Me.DepthScroll.Size = New System.Drawing.Size(157, 16)
			Me.DepthScroll.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.DepthScroll_Scroll);
			' 
			' DropLinesCheck
			' 
			Me.DropLinesCheck.ButtonProperties.BorderOffset = 2
			Me.DropLinesCheck.Location = New System.Drawing.Point(9, 180)
			Me.DropLinesCheck.Name = "DropLinesCheck"
			Me.DropLinesCheck.Size = New System.Drawing.Size(157, 21)
			Me.DropLinesCheck.TabIndex = 6
			Me.DropLinesCheck.Text = "Drop Lines"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DropLinesCheck.CheckedChanged += new System.EventHandler(this.DropLinesCheck_CheckedChanged);
			' 
			' AreaFEButton
			' 
			Me.AreaFEButton.Location = New System.Drawing.Point(9, 49)
			Me.AreaFEButton.Name = "AreaFEButton"
			Me.AreaFEButton.Size = New System.Drawing.Size(157, 24)
			Me.AreaFEButton.TabIndex = 2
			Me.AreaFEButton.Text = "Area Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AreaFEButton.Click += new System.EventHandler(this.AreaFEButton_Click);
			' 
			' AreaBorderButton
			' 
			Me.AreaBorderButton.Location = New System.Drawing.Point(9, 79)
			Me.AreaBorderButton.Name = "AreaBorderButton"
			Me.AreaBorderButton.Size = New System.Drawing.Size(157, 24)
			Me.AreaBorderButton.TabIndex = 3
			Me.AreaBorderButton.Text = "Area Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AreaBorderButton.Click += new System.EventHandler(this.AreaBorderButton_Click);
			' 
			' MarkerStyleButton
			' 
			Me.MarkerStyleButton.Location = New System.Drawing.Point(9, 109)
			Me.MarkerStyleButton.Name = "MarkerStyleButton"
			Me.MarkerStyleButton.Size = New System.Drawing.Size(157, 24)
			Me.MarkerStyleButton.TabIndex = 4
			Me.MarkerStyleButton.Text = "Marker Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			' 
			' LabelStyleButton
			' 
			Me.LabelStyleButton.Location = New System.Drawing.Point(9, 140)
			Me.LabelStyleButton.Name = "LabelStyleButton"
			Me.LabelStyleButton.Size = New System.Drawing.Size(157, 24)
			Me.LabelStyleButton.TabIndex = 5
			Me.LabelStyleButton.Text = "Data Label Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LabelStyleButton.Click += new System.EventHandler(this.LabelStyleButton_Click);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 210)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(157, 20)
			Me.label2.TabIndex = 7
			Me.label2.Text = "Origin Mode:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' OriginModeCombo
			' 
			Me.OriginModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.OriginModeCombo.ListProperties.DataSource = Nothing
			Me.OriginModeCombo.ListProperties.DisplayMember = ""
			Me.OriginModeCombo.Location = New System.Drawing.Point(9, 233)
			Me.OriginModeCombo.Name = "OriginModeCombo"
			Me.OriginModeCombo.Size = New System.Drawing.Size(157, 21)
			Me.OriginModeCombo.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OriginModeCombo.SelectedIndexChanged += new System.EventHandler(this.OriginModeCombo_SelectedIndexChanged);
			' 
			' OriginValueTextBox
			' 
			Me.OriginValueTextBox.Location = New System.Drawing.Point(9, 283)
			Me.OriginValueTextBox.Name = "OriginValueTextBox"
			Me.OriginValueTextBox.Size = New System.Drawing.Size(157, 18)
			Me.OriginValueTextBox.TabIndex = 10
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OriginValueTextBox.TextChanged += new System.EventHandler(this.OriginValueTextBox_TextChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(9, 263)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(157, 20)
			Me.label1.TabIndex = 9
			Me.label1.Text = "Custom Origin Value:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' NStandardAreaUC
			' 
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.OriginModeCombo)
			Me.Controls.Add(Me.OriginValueTextBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.LabelStyleButton)
			Me.Controls.Add(Me.MarkerStyleButton)
			Me.Controls.Add(Me.AreaBorderButton)
			Me.Controls.Add(Me.AreaFEButton)
			Me.Controls.Add(Me.DropLinesCheck)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.DepthScroll)
			Me.Name = "NStandardAreaUC"
			Me.Size = New System.Drawing.Size(180, 336)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("3D Area Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' setup the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 65
			chart.Height = 40
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' setup X axis
			Dim scaleX As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.AutoLabels = False
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleX.DisplayDataPointsBetweenTicks = False
			For i As Integer = 0 To monthLetters.Length - 1
				scaleX.CustomLabels.Add(New NCustomValueLabel(i, monthLetters(i)))
			Next i

			' add interlaced stripe for Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back, ChartWallType.Left }

			Dim scaleY As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.StripStyles.Add(stripStyle)

			' hide Z axis
			chart.Axis(StandardAxis.Depth).Visible = False

			' setup area series
			Dim area As NAreaSeries = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			area.DataLabelStyle.Visible = False
			area.DataLabelStyle.Format = "<value>"
			area.Name = "Area Series"
			area.Values.AddRange(monthValues)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' form controls
			OriginModeCombo.SelectedIndex = 0
			OriginValueTextBox.Text = "0"
		End Sub

		Private Sub DepthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles DepthScroll.ValueChanged
			Dim area As NAreaSeries = CType(nChartControl1.Charts(0).Series(0), NAreaSeries)
			area.DepthPercent = DepthScroll.Value
			nChartControl1.Refresh()
		End Sub

		Private Sub OriginValueTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles OriginValueTextBox.TextChanged
			Try
				Dim area As NAreaSeries = CType(nChartControl1.Charts(0).Series(0), NAreaSeries)
				area.Origin = Double.Parse(OriginValueTextBox.Text)
				nChartControl1.Refresh()
			Catch
			End Try
		End Sub

		Private Sub OriginModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles OriginModeCombo.SelectedIndexChanged
			Dim area As NAreaSeries = CType(nChartControl1.Charts(0).Series(0), NAreaSeries)
			area.OriginMode = CType(OriginModeCombo.SelectedIndex, SeriesOriginMode)

			nChartControl1.Refresh()

			OriginValueTextBox.Enabled = (area.OriginMode = SeriesOriginMode.CustomOrigin)
		End Sub

		Private Sub DropLinesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropLinesCheck.CheckedChanged
			Dim area As NAreaSeries = CType(nChartControl1.Charts(0).Series(0), NAreaSeries)
			area.DropLines = DropLinesCheck.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub AreaFEButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AreaFEButton.Click
			Dim fillStyleResult As NFillStyle = Nothing
			Dim area As NAreaSeries = CType(nChartControl1.Charts(0).Series(0), NAreaSeries)

			If NFillStyleTypeEditor.Edit(area.FillStyle, fillStyleResult) Then
				area.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub AreaBorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AreaBorderButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing
			Dim area As NAreaSeries = CType(nChartControl1.Charts(0).Series(0), NAreaSeries)

			If NStrokeStyleTypeEditor.Edit(area.BorderStyle, strokeStyleResult) Then
				area.BorderStyle = strokeStyleResult
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

		Private Sub LabelStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LabelStyleButton.Click
			Dim styleResult As NDataLabelStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NDataLabelStyleTypeEditor.Edit(series.DataLabelStyle, styleResult) Then
				series.DataLabelStyle = styleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
