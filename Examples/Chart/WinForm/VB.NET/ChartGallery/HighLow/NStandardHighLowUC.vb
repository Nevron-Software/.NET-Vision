Imports System
Imports System.Diagnostics
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
	Public Class NStandardHighLowUC
		Inherits NExampleBaseUC

		Private label3 As System.Windows.Forms.Label
		Private WithEvents DepthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents DropLinesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents HighAreaFEButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LowAreaFEButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents MarkerStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LabelStyleButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.HighAreaFEButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.DropLinesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.DepthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.LowAreaFEButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.MarkerStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.LabelStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' HighAreaFEButton
			' 
			Me.HighAreaFEButton.Location = New System.Drawing.Point(8, 87)
			Me.HighAreaFEButton.Name = "HighAreaFEButton"
			Me.HighAreaFEButton.Size = New System.Drawing.Size(163, 24)
			Me.HighAreaFEButton.TabIndex = 41
			Me.HighAreaFEButton.Text = "High Area Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HighAreaFEButton.Click += new System.EventHandler(this.AreaFEButton_Click);
			' 
			' DropLinesCheck
			' 
			Me.DropLinesCheck.ButtonProperties.BorderOffset = 2
			Me.DropLinesCheck.Location = New System.Drawing.Point(8, 47)
			Me.DropLinesCheck.Name = "DropLinesCheck"
			Me.DropLinesCheck.Size = New System.Drawing.Size(163, 23)
			Me.DropLinesCheck.TabIndex = 40
			Me.DropLinesCheck.Text = "Drop Lines"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DropLinesCheck.CheckedChanged += new System.EventHandler(this.DropLinesCheck_CheckedChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 9)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(163, 16)
			Me.label3.TabIndex = 33
			Me.label3.Text = "Depth %:"
			' 
			' DepthScroll
			' 
			Me.DepthScroll.Location = New System.Drawing.Point(8, 25)
			Me.DepthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.DepthScroll.Name = "DepthScroll"
			Me.DepthScroll.Size = New System.Drawing.Size(163, 16)
			Me.DepthScroll.TabIndex = 32
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.DepthScroll_Scroll);
			' 
			' LowAreaFEButton
			' 
			Me.LowAreaFEButton.Location = New System.Drawing.Point(8, 119)
			Me.LowAreaFEButton.Name = "LowAreaFEButton"
			Me.LowAreaFEButton.Size = New System.Drawing.Size(163, 24)
			Me.LowAreaFEButton.TabIndex = 0
			Me.LowAreaFEButton.Text = "Low Area Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LowAreaFEButton.Click += new System.EventHandler(this.LowAreaFEButton_Click);
			' 
			' MarkerStyleButton
			' 
			Me.MarkerStyleButton.Location = New System.Drawing.Point(8, 147)
			Me.MarkerStyleButton.Name = "MarkerStyleButton"
			Me.MarkerStyleButton.Size = New System.Drawing.Size(163, 24)
			Me.MarkerStyleButton.TabIndex = 52
			Me.MarkerStyleButton.Text = "Marker Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			' 
			' LabelStyleButton
			' 
			Me.LabelStyleButton.Location = New System.Drawing.Point(8, 178)
			Me.LabelStyleButton.Name = "LabelStyleButton"
			Me.LabelStyleButton.Size = New System.Drawing.Size(163, 24)
			Me.LabelStyleButton.TabIndex = 53
			Me.LabelStyleButton.Text = "Data Label Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LabelStyleButton.Click += new System.EventHandler(this.LabelStyleButton_Click);
			' 
			' NStandardHighLowUC
			' 
			Me.Controls.Add(Me.LabelStyleButton)
			Me.Controls.Add(Me.MarkerStyleButton)
			Me.Controls.Add(Me.HighAreaFEButton)
			Me.Controls.Add(Me.DropLinesCheck)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.DepthScroll)
			Me.Controls.Add(Me.LowAreaFEButton)
			Me.Name = "NStandardHighLowUC"
			Me.Size = New System.Drawing.Size(180, 229)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("3D High Low Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 65
			chart.Height = 40
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			Dim highLow As NHighLowSeries = CType(chart.Series.Add(SeriesType.HighLow), NHighLowSeries)
			highLow.Name = "High-Low Series"
			highLow.HighFillStyle = New NColorFillStyle(GreyBlue)
			highLow.LowFillStyle = New NColorFillStyle(DarkOrange)
			highLow.HighBorderStyle = New NStrokeStyle(GreyBlue)
			highLow.LowBorderStyle = New NStrokeStyle(DarkOrange)
			highLow.Legend.Mode = SeriesLegendMode.SeriesLogic
			highLow.DataLabelStyle.Visible = False
			highLow.DataLabelStyle.Format = "<high_value>:<low_value>"
			highLow.LowValues.ValueFormatter = New NNumericValueFormatter("0.#")
			highLow.HighValues.ValueFormatter = New NNumericValueFormatter("0.#")

			GenerateData(highLow)

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' init form controls
			DepthScroll.Value = CInt(Math.Truncate(highLow.DepthPercent))
		End Sub

		Private Sub GenerateData(ByVal highLow As NHighLowSeries)
			highLow.ClearDataPoints()

			For i As Integer = 0 To 19
				Dim d1 As Double = Math.Log(i + 1) + 0.1 * Random.NextDouble()
				Dim d2 As Double = d1 + Math.Cos(0.33 * i) + 0.1 * Random.NextDouble()

				highLow.HighValues.Add(d1)
				highLow.LowValues.Add(d2)
			Next i
		End Sub

		Private Sub DepthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles DepthScroll.ValueChanged
			Dim highLow As NHighLowSeries = CType(nChartControl1.Charts(0).Series(0), NHighLowSeries)
			highLow.DepthPercent = DepthScroll.Value
			nChartControl1.Refresh()
		End Sub
		Private Sub DropLinesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropLinesCheck.CheckedChanged
			Dim highLow As NHighLowSeries = CType(nChartControl1.Charts(0).Series(0), NHighLowSeries)
			highLow.DropLines = DropLinesCheck.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub AreaFEButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles HighAreaFEButton.Click
			Dim fillStyleResult As NFillStyle = Nothing
			Dim highLow As NHighLowSeries = CType(nChartControl1.Charts(0).Series(0), NHighLowSeries)

			If NFillStyleTypeEditor.Edit(highLow.HighFillStyle, fillStyleResult) Then
				highLow.HighFillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub LowAreaFEButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LowAreaFEButton.Click
			Dim fillStyleResult As NFillStyle = Nothing
			Dim highLow As NHighLowSeries = CType(nChartControl1.Charts(0).Series(0), NHighLowSeries)

			If NFillStyleTypeEditor.Edit(highLow.LowFillStyle, fillStyleResult) Then
				highLow.LowFillStyle = fillStyleResult
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