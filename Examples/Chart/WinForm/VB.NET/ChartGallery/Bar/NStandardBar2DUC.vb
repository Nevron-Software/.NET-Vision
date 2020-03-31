Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports Nevron.UI
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NStandardBar2DUC
		Inherits NExampleBaseUC

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private WithEvents BarBorderButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents HasBottomEdge As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents HasTopEdge As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents EdgePercentScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents InvertAxisRuler As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents DifferentFillStyles As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents WidthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents StyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents BarFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BarShadowButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LabelStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents OriginModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents OriginValueTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private components As System.ComponentModel.IContainer = Nothing

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


		#Region "Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.BarBorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.HasBottomEdge = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.HasTopEdge = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.EdgePercentScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.InvertAxisRuler = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.DifferentFillStyles = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.WidthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.StyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.BarFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.BarShadowButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.LabelStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label3 = New System.Windows.Forms.Label()
			Me.OriginModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.OriginValueTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' BarBorderButton
			' 
			Me.BarBorderButton.Location = New System.Drawing.Point(7, 210)
			Me.BarBorderButton.Name = "BarBorderButton"
			Me.BarBorderButton.Size = New System.Drawing.Size(163, 24)
			Me.BarBorderButton.TabIndex = 8
			Me.BarBorderButton.Text = "Bar Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarBorderButton.Click += new System.EventHandler(this.BarBorderButton_Click);
			' 
			' HasBottomEdge
			' 
			Me.HasBottomEdge.ButtonProperties.BorderOffset = 2
			Me.HasBottomEdge.Enabled = False
			Me.HasBottomEdge.Location = New System.Drawing.Point(7, 120)
			Me.HasBottomEdge.Name = "HasBottomEdge"
			Me.HasBottomEdge.Size = New System.Drawing.Size(163, 24)
			Me.HasBottomEdge.TabIndex = 5
			Me.HasBottomEdge.Text = "Has Bottom Edge"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HasBottomEdge.CheckedChanged += new System.EventHandler(this.HasBottomEdge_CheckedChanged);
			' 
			' HasTopEdge
			' 
			Me.HasTopEdge.ButtonProperties.BorderOffset = 2
			Me.HasTopEdge.Enabled = False
			Me.HasTopEdge.Location = New System.Drawing.Point(7, 97)
			Me.HasTopEdge.Name = "HasTopEdge"
			Me.HasTopEdge.Size = New System.Drawing.Size(163, 21)
			Me.HasTopEdge.TabIndex = 4
			Me.HasTopEdge.Text = "Has Top Edge"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HasTopEdge.CheckedChanged += new System.EventHandler(this.HasTopEdge_CheckedChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(7, 53)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(163, 14)
			Me.label5.TabIndex = 2
			Me.label5.Text = "Edge %:"
			' 
			' EdgePercentScrollBar
			' 
			Me.EdgePercentScrollBar.Enabled = False
			Me.EdgePercentScrollBar.Location = New System.Drawing.Point(7, 69)
			Me.EdgePercentScrollBar.Maximum = 59
			Me.EdgePercentScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.EdgePercentScrollBar.Name = "EdgePercentScrollBar"
			Me.EdgePercentScrollBar.Size = New System.Drawing.Size(163, 16)
			Me.EdgePercentScrollBar.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EdgePercentScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.EdgePercentScrollBar_Scroll);
			' 
			' InvertAxisRuler
			' 
			Me.InvertAxisRuler.ButtonProperties.BorderOffset = 2
			Me.InvertAxisRuler.Location = New System.Drawing.Point(7, 365)
			Me.InvertAxisRuler.Name = "InvertAxisRuler"
			Me.InvertAxisRuler.Size = New System.Drawing.Size(163, 19)
			Me.InvertAxisRuler.TabIndex = 13
			Me.InvertAxisRuler.Text = "Invert Y Axis Ruler"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InvertAxisRuler.CheckedChanged += new System.EventHandler(this.InvertAxisRuler_CheckedChanged);
			' 
			' DifferentFillStyles
			' 
			Me.DifferentFillStyles.ButtonProperties.BorderOffset = 2
			Me.DifferentFillStyles.Location = New System.Drawing.Point(7, 147)
			Me.DifferentFillStyles.Name = "DifferentFillStyles"
			Me.DifferentFillStyles.Size = New System.Drawing.Size(163, 20)
			Me.DifferentFillStyles.TabIndex = 6
			Me.DifferentFillStyles.Text = "Different Fill Styles"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DifferentFillStyles.CheckedChanged += new System.EventHandler(this.DifferentFillStyles_CheckedChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(7, 311)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(163, 16)
			Me.label2.TabIndex = 11
			Me.label2.Text = "Width %:"
			' 
			' WidthScroll
			' 
			Me.WidthScroll.Location = New System.Drawing.Point(7, 327)
			Me.WidthScroll.Maximum = 110
			Me.WidthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.WidthScroll.Name = "WidthScroll"
			Me.WidthScroll.Size = New System.Drawing.Size(163, 16)
			Me.WidthScroll.TabIndex = 12
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WidthScroll_Scroll);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(7, 7)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(163, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Bar Style:"
			' 
			' StyleCombo
			' 
			Me.StyleCombo.ListProperties.CheckBoxDataMember = ""
			Me.StyleCombo.ListProperties.DataSource = Nothing
			Me.StyleCombo.ListProperties.DisplayMember = ""
			Me.StyleCombo.Location = New System.Drawing.Point(7, 23)
			Me.StyleCombo.Name = "StyleCombo"
			Me.StyleCombo.Size = New System.Drawing.Size(163, 21)
			Me.StyleCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StyleCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			' 
			' BarFillStyleButton
			' 
			Me.BarFillStyleButton.Location = New System.Drawing.Point(7, 178)
			Me.BarFillStyleButton.Name = "BarFillStyleButton"
			Me.BarFillStyleButton.Size = New System.Drawing.Size(163, 24)
			Me.BarFillStyleButton.TabIndex = 7
			Me.BarFillStyleButton.Text = "Bar Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarFillStyleButton.Click += new System.EventHandler(this.BarFillStyleButton_Click);
			' 
			' BarShadowButton
			' 
			Me.BarShadowButton.Location = New System.Drawing.Point(7, 242)
			Me.BarShadowButton.Name = "BarShadowButton"
			Me.BarShadowButton.Size = New System.Drawing.Size(163, 24)
			Me.BarShadowButton.TabIndex = 9
			Me.BarShadowButton.Text = "Bar Shadow..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarShadowButton.Click += new System.EventHandler(this.BarShadowButton_Click);
			' 
			' LabelStyleButton
			' 
			Me.LabelStyleButton.Location = New System.Drawing.Point(7, 273)
			Me.LabelStyleButton.Name = "LabelStyleButton"
			Me.LabelStyleButton.Size = New System.Drawing.Size(163, 24)
			Me.LabelStyleButton.TabIndex = 10
			Me.LabelStyleButton.Text = "Data Label Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LabelStyleButton.Click += new System.EventHandler(this.LabelStyleButton_Click);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 399)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(163, 20)
			Me.label3.TabIndex = 14
			Me.label3.Text = "Origin Mode:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' OriginModeCombo
			' 
			Me.OriginModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.OriginModeCombo.ListProperties.DataSource = Nothing
			Me.OriginModeCombo.ListProperties.DisplayMember = ""
			Me.OriginModeCombo.Location = New System.Drawing.Point(8, 422)
			Me.OriginModeCombo.Name = "OriginModeCombo"
			Me.OriginModeCombo.Size = New System.Drawing.Size(163, 21)
			Me.OriginModeCombo.TabIndex = 15
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OriginModeCombo.SelectedIndexChanged += new System.EventHandler(this.OriginModeCombo_SelectedIndexChanged);
			' 
			' OriginValueTextBox
			' 
			Me.OriginValueTextBox.Location = New System.Drawing.Point(8, 472)
			Me.OriginValueTextBox.Name = "OriginValueTextBox"
			Me.OriginValueTextBox.Size = New System.Drawing.Size(163, 18)
			Me.OriginValueTextBox.TabIndex = 17
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OriginValueTextBox.TextChanged += new System.EventHandler(this.OriginValueTextBox_TextChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 452)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(163, 20)
			Me.label4.TabIndex = 16
			Me.label4.Text = "Custom Origin Value:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' NStandardBar2DUC
			' 
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.OriginModeCombo)
			Me.Controls.Add(Me.OriginValueTextBox)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.LabelStyleButton)
			Me.Controls.Add(Me.BarShadowButton)
			Me.Controls.Add(Me.BarBorderButton)
			Me.Controls.Add(Me.HasBottomEdge)
			Me.Controls.Add(Me.HasTopEdge)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.EdgePercentScrollBar)
			Me.Controls.Add(Me.InvertAxisRuler)
			Me.Controls.Add(Me.DifferentFillStyles)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.WidthScroll)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.StyleCombo)
			Me.Controls.Add(Me.BarFillStyleButton)
			Me.Name = "NStandardBar2DUC"
			Me.Size = New System.Drawing.Size(180, 505)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' create a title
			Dim title As New NLabel("2D Bar Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Axis(StandardAxis.Depth).Visible = False

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' setup a bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar Series"
			bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			bar.ShadowStyle.Type = ShadowType.GaussianBlur
			bar.ShadowStyle.Offset = New NPointL(2, 2)
			bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0)
			bar.ShadowStyle.FadeLength = New NLength(5)
			bar.HasBottomEdge = False

			' add some data to the bar series
			bar.AddDataPoint(New NDataPoint(18, "C++"))
			bar.AddDataPoint(New NDataPoint(15, "Ruby"))
			bar.AddDataPoint(New NDataPoint(21, "Python"))
			bar.AddDataPoint(New NDataPoint(23, "Java"))
			bar.AddDataPoint(New NDataPoint(27, "Javascript"))
			bar.AddDataPoint(New NDataPoint(29, "C#"))
			bar.AddDataPoint(New NDataPoint(26, "PHP"))

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' init form controls
			StyleCombo.FillFromEnum(GetType(BarShape))
			StyleCombo.SelectedIndex = 0
			OriginModeCombo.SelectedIndex = 0
			OriginValueTextBox.Text = "0"
			EdgePercentScrollBar.Value = CInt(Math.Truncate(bar.BarEdgePercent))
			HasTopEdge.Checked = bar.HasTopEdge
			HasBottomEdge.Checked = bar.HasBottomEdge
			DifferentFillStyles.Checked = True
		End Sub

		Private Sub StyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StyleCombo.SelectedIndexChanged
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			bar.BarShape = CType(StyleCombo.SelectedIndex, BarShape)

			Dim bHasEdge As Boolean = (bar.BarShape = BarShape.SmoothEdgeBar OrElse bar.BarShape = BarShape.CutEdgeBar)
			EdgePercentScrollBar.Enabled = bHasEdge
			HasTopEdge.Enabled = bHasEdge
			HasBottomEdge.Enabled = bHasEdge

			nChartControl1.Refresh()
		End Sub

		Private Sub WidthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles WidthScroll.ValueChanged
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			bar.WidthPercent = WidthScroll.Value
			nChartControl1.Refresh()
		End Sub

		Private Sub DifferentFillStyles_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DifferentFillStyles.CheckedChanged
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)

			If DifferentFillStyles.Checked Then
				BarFillStyleButton.Enabled = False

				bar.Legend.Mode = SeriesLegendMode.DataPoints

				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
				styleSheet.Apply(nChartControl1.Document)
			Else
				BarFillStyleButton.Enabled = True

				bar.Legend.Mode = SeriesLegendMode.Series

				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
				styleSheet.Apply(nChartControl1.Document)
			End If
			nChartControl1.Refresh()
		End Sub

		Private Sub BarFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarFillStyleButton.Click
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(bar.FillStyle, fillStyleResult) Then
				bar.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BarBorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarBorderButton.Click
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(bar.BorderStyle, strokeStyleResult) Then
				bar.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BarShadowButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarShadowButton.Click
			Dim shadowStyleResult As NShadowStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NShadowStyleTypeEditor.Edit(series.ShadowStyle, shadowStyleResult) Then
				series.ShadowStyle = shadowStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub OriginValueTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles OriginValueTextBox.TextChanged
			Try
				Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
				bar.Origin = Double.Parse(OriginValueTextBox.Text)
				nChartControl1.Refresh()
			Catch
			End Try
		End Sub

		Private Sub OriginModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles OriginModeCombo.SelectedIndexChanged
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)

			bar.OriginMode = CType(OriginModeCombo.SelectedIndex, SeriesOriginMode)

			nChartControl1.Refresh()

			OriginValueTextBox.Enabled = (bar.OriginMode = SeriesOriginMode.CustomOrigin)
		End Sub

		Private Sub InvertAxisRuler_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InvertAxisRuler.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Invert = InvertAxisRuler.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub EdgePercentScrollBar_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles EdgePercentScrollBar.ValueChanged
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			bar.BarEdgePercent = EdgePercentScrollBar.Value
			nChartControl1.Refresh()
		End Sub

		Private Sub HasTopEdge_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HasTopEdge.CheckedChanged
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			bar.HasTopEdge = HasTopEdge.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub HasBottomEdge_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HasBottomEdge.CheckedChanged
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			bar.HasBottomEdge = HasBottomEdge.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub LabelStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LabelStyleButton.Click
			Dim styleResult As NDataLabelStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NDataLabelStyleTypeEditor.Edit(series.DataLabelStyle, styleResult) Then
				series.DataLabelStyle = styleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub nButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.Projection.ViewerRotation = 90.0F
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace