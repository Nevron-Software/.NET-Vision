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
	Public Class NStandardHighLow2DUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_HighLow As NHighLowSeries
		Private WithEvents DropLinesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents HighAreaFEButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LowAreaFEButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ShadowButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.LowAreaFEButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShadowButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.MarkerStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.LabelStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' HighAreaFEButton
			' 
			Me.HighAreaFEButton.Location = New System.Drawing.Point(9, 9)
			Me.HighAreaFEButton.Name = "HighAreaFEButton"
			Me.HighAreaFEButton.Size = New System.Drawing.Size(161, 24)
			Me.HighAreaFEButton.TabIndex = 41
			Me.HighAreaFEButton.Text = "High Area Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HighAreaFEButton.Click += new System.EventHandler(this.AreaFEButton_Click);
			' 
			' DropLinesCheck
			' 
			Me.DropLinesCheck.ButtonProperties.BorderOffset = 2
			Me.DropLinesCheck.Location = New System.Drawing.Point(9, 166)
			Me.DropLinesCheck.Name = "DropLinesCheck"
			Me.DropLinesCheck.Size = New System.Drawing.Size(161, 21)
			Me.DropLinesCheck.TabIndex = 40
			Me.DropLinesCheck.Text = "Drop Lines"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DropLinesCheck.CheckedChanged += new System.EventHandler(this.DropLinesCheck_CheckedChanged);
			' 
			' LowAreaFEButton
			' 
			Me.LowAreaFEButton.Location = New System.Drawing.Point(9, 40)
			Me.LowAreaFEButton.Name = "LowAreaFEButton"
			Me.LowAreaFEButton.Size = New System.Drawing.Size(161, 24)
			Me.LowAreaFEButton.TabIndex = 0
			Me.LowAreaFEButton.Text = "Low Area Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LowAreaFEButton.Click += new System.EventHandler(this.LowAreaFEButton_Click);
			' 
			' ShadowButton
			' 
			Me.ShadowButton.Location = New System.Drawing.Point(9, 71)
			Me.ShadowButton.Name = "ShadowButton"
			Me.ShadowButton.Size = New System.Drawing.Size(161, 24)
			Me.ShadowButton.TabIndex = 50
			Me.ShadowButton.Text = "Shadow ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShadowButton.Click += new System.EventHandler(this.ShadowButton_Click);
			' 
			' MarkerStyleButton
			' 
			Me.MarkerStyleButton.Location = New System.Drawing.Point(9, 102)
			Me.MarkerStyleButton.Name = "MarkerStyleButton"
			Me.MarkerStyleButton.Size = New System.Drawing.Size(161, 24)
			Me.MarkerStyleButton.TabIndex = 51
			Me.MarkerStyleButton.Text = "Marker Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			' 
			' LabelStyleButton
			' 
			Me.LabelStyleButton.Location = New System.Drawing.Point(9, 133)
			Me.LabelStyleButton.Name = "LabelStyleButton"
			Me.LabelStyleButton.Size = New System.Drawing.Size(161, 24)
			Me.LabelStyleButton.TabIndex = 52
			Me.LabelStyleButton.Text = "Data Label Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LabelStyleButton.Click += new System.EventHandler(this.LabelStyleButton_Click);
			' 
			' NStandardHighLow2DUC
			' 
			Me.Controls.Add(Me.LabelStyleButton)
			Me.Controls.Add(Me.MarkerStyleButton)
			Me.Controls.Add(Me.ShadowButton)
			Me.Controls.Add(Me.HighAreaFEButton)
			Me.Controls.Add(Me.DropLinesCheck)
			Me.Controls.Add(Me.LowAreaFEButton)
			Me.Name = "NStandardHighLow2DUC"
			Me.Size = New System.Drawing.Size(180, 270)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("2D High Low Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' add a High-Low series
			m_HighLow = CType(m_Chart.Series.Add(SeriesType.HighLow), NHighLowSeries)
			m_HighLow.Name = "High-Low Series"
			m_HighLow.Legend.Mode = SeriesLegendMode.SeriesLogic
			m_HighLow.HighFillStyle = New NColorFillStyle(GreyBlue)
			m_HighLow.LowFillStyle = New NColorFillStyle(DarkOrange)
			m_HighLow.DataLabelStyle.Visible = False
			m_HighLow.DataLabelStyle.Format = "<high_value>:<low_value>"
			m_HighLow.LowValues.ValueFormatter = New NNumericValueFormatter("0.#")
			m_HighLow.HighValues.ValueFormatter = New NNumericValueFormatter("0.#")

			GenerateData()

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))
		End Sub

		Private Sub GenerateData()
			m_HighLow.ClearDataPoints()

			For i As Integer = 0 To 19
				Dim d1 As Double = Math.Log(i + 1) + 0.1 * Random.NextDouble()
				Dim d2 As Double = d1 + Math.Cos(0.33 * i) + 0.1 * Random.NextDouble()

				m_HighLow.HighValues.Add(d1)
				m_HighLow.LowValues.Add(d2)
			Next i
		End Sub

		Private Sub AreaFEButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles HighAreaFEButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_HighLow.HighFillStyle, fillStyleResult) Then
				m_HighLow.HighFillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub LowAreaFEButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LowAreaFEButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_HighLow.LowFillStyle, fillStyleResult) Then
				m_HighLow.LowFillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub ShadowButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShadowButton.Click
			Dim shadowStyleResult As NShadowStyle = Nothing

			If NShadowStyleTypeEditor.Edit(m_HighLow.ShadowStyle, shadowStyleResult) Then
				m_HighLow.ShadowStyle = shadowStyleResult
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
		Private Sub DropLinesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropLinesCheck.CheckedChanged
			m_HighLow.DropLines = DropLinesCheck.Checked
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace