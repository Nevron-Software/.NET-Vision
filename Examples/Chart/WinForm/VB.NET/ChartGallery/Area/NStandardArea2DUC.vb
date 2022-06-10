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
	<ToolboxItem(False)>
	Public Class NStandardArea2DUC
		Inherits NExampleBaseUC

		Private WithEvents OriginValueTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents DropLinesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents AreaFEButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents AreaBorderButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents AreaShadowButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents MarkerStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LabelStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents OriginModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
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
			Me.OriginValueTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.DropLinesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.AreaFEButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.AreaBorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.AreaShadowButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.MarkerStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.LabelStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.OriginModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' OriginValueTextBox
			' 
			Me.OriginValueTextBox.Location = New System.Drawing.Point(9, 278)
			Me.OriginValueTextBox.Name = "OriginValueTextBox"
			Me.OriginValueTextBox.Size = New System.Drawing.Size(157, 18)
			Me.OriginValueTextBox.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OriginValueTextBox.TextChanged += new System.EventHandler(this.OriginValueTextBox_TextChanged);
			' 
			' DropLinesCheck
			' 
			Me.DropLinesCheck.ButtonProperties.BorderOffset = 2
			Me.DropLinesCheck.Location = New System.Drawing.Point(9, 174)
			Me.DropLinesCheck.Name = "DropLinesCheck"
			Me.DropLinesCheck.Size = New System.Drawing.Size(157, 21)
			Me.DropLinesCheck.TabIndex = 2
			Me.DropLinesCheck.Text = "Drop Lines"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DropLinesCheck.CheckedChanged += new System.EventHandler(this.DropLinesCheck_CheckedChanged);
			' 
			' AreaFEButton
			' 
			Me.AreaFEButton.Location = New System.Drawing.Point(9, 10)
			Me.AreaFEButton.Name = "AreaFEButton"
			Me.AreaFEButton.Size = New System.Drawing.Size(157, 24)
			Me.AreaFEButton.TabIndex = 0
			Me.AreaFEButton.Text = "Area Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AreaFEButton.Click += new System.EventHandler(this.AreaFEButton_Click);
			' 
			' AreaBorderButton
			' 
			Me.AreaBorderButton.Location = New System.Drawing.Point(9, 40)
			Me.AreaBorderButton.Name = "AreaBorderButton"
			Me.AreaBorderButton.Size = New System.Drawing.Size(157, 24)
			Me.AreaBorderButton.TabIndex = 1
			Me.AreaBorderButton.Text = "Area Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AreaBorderButton.Click += new System.EventHandler(this.AreaBorderButton_Click);
			' 
			' AreaShadowButton
			' 
			Me.AreaShadowButton.Location = New System.Drawing.Point(9, 70)
			Me.AreaShadowButton.Name = "AreaShadowButton"
			Me.AreaShadowButton.Size = New System.Drawing.Size(157, 24)
			Me.AreaShadowButton.TabIndex = 7
			Me.AreaShadowButton.Text = "Area Shadow..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AreaShadowButton.Click += new System.EventHandler(this.AreaShadowButton_Click);
			' 
			' MarkerStyleButton
			' 
			Me.MarkerStyleButton.Location = New System.Drawing.Point(9, 100)
			Me.MarkerStyleButton.Name = "MarkerStyleButton"
			Me.MarkerStyleButton.Size = New System.Drawing.Size(157, 24)
			Me.MarkerStyleButton.TabIndex = 14
			Me.MarkerStyleButton.Text = "Marker Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(9, 258)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(157, 20)
			Me.label1.TabIndex = 15
			Me.label1.Text = "Custom Origin Value:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' LabelStyleButton
			' 
			Me.LabelStyleButton.Location = New System.Drawing.Point(9, 131)
			Me.LabelStyleButton.Name = "LabelStyleButton"
			Me.LabelStyleButton.Size = New System.Drawing.Size(157, 24)
			Me.LabelStyleButton.TabIndex = 16
			Me.LabelStyleButton.Text = "Data Label Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LabelStyleButton.Click += new System.EventHandler(this.LabelStyleButton_Click);
			' 
			' OriginModeCombo
			' 
			Me.OriginModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.OriginModeCombo.ListProperties.DataSource = Nothing
			Me.OriginModeCombo.ListProperties.DisplayMember = ""
			Me.OriginModeCombo.Location = New System.Drawing.Point(9, 228)
			Me.OriginModeCombo.Name = "OriginModeCombo"
			Me.OriginModeCombo.Size = New System.Drawing.Size(157, 21)
			Me.OriginModeCombo.TabIndex = 17
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OriginModeCombo.SelectedIndexChanged += new System.EventHandler(this.OriginModeCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 205)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(157, 20)
			Me.label2.TabIndex = 18
			Me.label2.Text = "Origin Mode:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' NStandardArea2DUC
			' 
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.OriginModeCombo)
			Me.Controls.Add(Me.LabelStyleButton)
			Me.Controls.Add(Me.MarkerStyleButton)
			Me.Controls.Add(Me.AreaShadowButton)
			Me.Controls.Add(Me.AreaBorderButton)
			Me.Controls.Add(Me.AreaFEButton)
			Me.Controls.Add(Me.DropLinesCheck)
			Me.Controls.Add(Me.OriginValueTextBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NStandardArea2DUC"
			Me.Size = New System.Drawing.Size(180, 309)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("2D Area Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' setup the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Axis(StandardAxis.Depth).Visible = False

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
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }

			Dim scaleY As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.StripStyles.Add(stripStyle)

			' setup area series
			Dim area As NAreaSeries = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			area.Name = "Area Series"
			area.DataLabelStyle.Visible = False
			area.DataLabelStyle.Format = "<value>"
			area.ShadowStyle.Type = ShadowType.Solid
			area.ShadowStyle.Offset = New NPointL(3, 0)
			area.ShadowStyle.Color = Color.FromArgb(60, 0, 0, 0)

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

		Private Sub AreaShadowButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AreaShadowButton.Click
			Dim shadowStyleResult As NShadowStyle = Nothing
			Dim area As NAreaSeries = CType(nChartControl1.Charts(0).Series(0), NAreaSeries)

			If NShadowStyleTypeEditor.Edit(area.ShadowStyle, shadowStyleResult) Then
				area.ShadowStyle = shadowStyleResult
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
