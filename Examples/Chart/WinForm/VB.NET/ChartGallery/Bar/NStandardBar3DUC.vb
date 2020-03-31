Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NStandardBar3DUC
		Inherits NExampleBaseUC

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private WithEvents WidthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents DepthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents EdgePercentScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents DifferentFillStyles As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents InvertAxisRuler As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents HasTopEdge As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents HasBottomEdge As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents StyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents BarFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BarBorderButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.BarFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.StyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.WidthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.DepthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.DifferentFillStyles = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.InvertAxisRuler = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.EdgePercentScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label5 = New System.Windows.Forms.Label()
			Me.HasTopEdge = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.HasBottomEdge = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.BarBorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.LabelStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label4 = New System.Windows.Forms.Label()
			Me.OriginModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.OriginValueTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' BarFillStyleButton
			' 
			Me.BarFillStyleButton.Location = New System.Drawing.Point(7, 178)
			Me.BarFillStyleButton.Name = "BarFillStyleButton"
			Me.BarFillStyleButton.Size = New System.Drawing.Size(165, 24)
			Me.BarFillStyleButton.TabIndex = 7
			Me.BarFillStyleButton.Text = "Bar Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarFillStyleButton.Click += new System.EventHandler(this.BarFillStyleButton_Click);
			' 
			' StyleCombo
			' 
			Me.StyleCombo.ListProperties.CheckBoxDataMember = ""
			Me.StyleCombo.ListProperties.DataSource = Nothing
			Me.StyleCombo.ListProperties.DisplayMember = ""
			Me.StyleCombo.Location = New System.Drawing.Point(7, 23)
			Me.StyleCombo.Name = "StyleCombo"
			Me.StyleCombo.Size = New System.Drawing.Size(165, 21)
			Me.StyleCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StyleCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(7, 7)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(165, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Bar Style:"
			' 
			' WidthScroll
			' 
			Me.WidthScroll.Location = New System.Drawing.Point(7, 291)
			Me.WidthScroll.Maximum = 110
			Me.WidthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.WidthScroll.Name = "WidthScroll"
			Me.WidthScroll.Size = New System.Drawing.Size(165, 16)
			Me.WidthScroll.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WidthScroll_Scroll);
			' 
			' DepthScroll
			' 
			Me.DepthScroll.Location = New System.Drawing.Point(7, 333)
			Me.DepthScroll.Maximum = 110
			Me.DepthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.DepthScroll.Name = "DepthScroll"
			Me.DepthScroll.Size = New System.Drawing.Size(165, 16)
			Me.DepthScroll.TabIndex = 11
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.DepthScroll_Scroll);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(7, 275)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(165, 16)
			Me.label2.TabIndex = 8
			Me.label2.Text = "Width %:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(7, 317)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(165, 16)
			Me.label3.TabIndex = 10
			Me.label3.Text = "Depth %:"
			' 
			' DifferentFillStyles
			' 
			Me.DifferentFillStyles.ButtonProperties.BorderOffset = 2
			Me.DifferentFillStyles.Location = New System.Drawing.Point(7, 149)
			Me.DifferentFillStyles.Name = "DifferentFillStyles"
			Me.DifferentFillStyles.Size = New System.Drawing.Size(165, 21)
			Me.DifferentFillStyles.TabIndex = 6
			Me.DifferentFillStyles.Text = "Different Fill Styles"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DifferentFillStyles.CheckedChanged += new System.EventHandler(this.DifferentFillStyles_CheckedChanged);
			' 
			' InvertAxisRuler
			' 
			Me.InvertAxisRuler.ButtonProperties.BorderOffset = 2
			Me.InvertAxisRuler.Location = New System.Drawing.Point(8, 367)
			Me.InvertAxisRuler.Name = "InvertAxisRuler"
			Me.InvertAxisRuler.Size = New System.Drawing.Size(165, 19)
			Me.InvertAxisRuler.TabIndex = 15
			Me.InvertAxisRuler.Text = "Invert Y Axis Ruler"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InvertAxisRuler.CheckedChanged += new System.EventHandler(this.InvertAxisRuler_CheckedChanged);
			' 
			' EdgePercentScrollBar
			' 
			Me.EdgePercentScrollBar.Enabled = False
			Me.EdgePercentScrollBar.Location = New System.Drawing.Point(7, 69)
			Me.EdgePercentScrollBar.Maximum = 59
			Me.EdgePercentScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.EdgePercentScrollBar.Name = "EdgePercentScrollBar"
			Me.EdgePercentScrollBar.Size = New System.Drawing.Size(165, 16)
			Me.EdgePercentScrollBar.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EdgePercentScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.EdgePercentScrollBar_Scroll);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(7, 53)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(165, 14)
			Me.label5.TabIndex = 2
			Me.label5.Text = "Edge %:"
			' 
			' HasTopEdge
			' 
			Me.HasTopEdge.ButtonProperties.BorderOffset = 2
			Me.HasTopEdge.Enabled = False
			Me.HasTopEdge.Location = New System.Drawing.Point(7, 96)
			Me.HasTopEdge.Name = "HasTopEdge"
			Me.HasTopEdge.Size = New System.Drawing.Size(165, 20)
			Me.HasTopEdge.TabIndex = 4
			Me.HasTopEdge.Text = "Has Top Edge"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HasTopEdge.CheckedChanged += new System.EventHandler(this.HasTopEdge_CheckedChanged);
			' 
			' HasBottomEdge
			' 
			Me.HasBottomEdge.ButtonProperties.BorderOffset = 2
			Me.HasBottomEdge.Enabled = False
			Me.HasBottomEdge.Location = New System.Drawing.Point(7, 120)
			Me.HasBottomEdge.Name = "HasBottomEdge"
			Me.HasBottomEdge.Size = New System.Drawing.Size(165, 24)
			Me.HasBottomEdge.TabIndex = 5
			Me.HasBottomEdge.Text = "Has Bottom Edge"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HasBottomEdge.CheckedChanged += new System.EventHandler(this.HasBottomEdge_CheckedChanged);
			' 
			' BarBorderButton
			' 
			Me.BarBorderButton.Location = New System.Drawing.Point(7, 209)
			Me.BarBorderButton.Name = "BarBorderButton"
			Me.BarBorderButton.Size = New System.Drawing.Size(165, 24)
			Me.BarBorderButton.TabIndex = 19
			Me.BarBorderButton.Text = "Bar Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarBorderButton.Click += new System.EventHandler(this.BarBorderButton_Click);
			' 
			' LabelStyleButton
			' 
			Me.LabelStyleButton.Location = New System.Drawing.Point(7, 240)
			Me.LabelStyleButton.Name = "LabelStyleButton"
			Me.LabelStyleButton.Size = New System.Drawing.Size(165, 24)
			Me.LabelStyleButton.TabIndex = 36
			Me.LabelStyleButton.Text = "Data Label Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LabelStyleButton.Click += new System.EventHandler(this.LabelStyleButton_Click);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 397)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(165, 20)
			Me.label4.TabIndex = 40
			Me.label4.Text = "Origin Mode:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' OriginModeCombo
			' 
			Me.OriginModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.OriginModeCombo.ListProperties.DataSource = Nothing
			Me.OriginModeCombo.ListProperties.DisplayMember = ""
			Me.OriginModeCombo.Location = New System.Drawing.Point(8, 420)
			Me.OriginModeCombo.Name = "OriginModeCombo"
			Me.OriginModeCombo.Size = New System.Drawing.Size(165, 21)
			Me.OriginModeCombo.TabIndex = 39
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OriginModeCombo.SelectedIndexChanged += new System.EventHandler(this.OriginModeCombo_SelectedIndexChanged);
			' 
			' OriginValueTextBox
			' 
			Me.OriginValueTextBox.Location = New System.Drawing.Point(8, 470)
			Me.OriginValueTextBox.Name = "OriginValueTextBox"
			Me.OriginValueTextBox.Size = New System.Drawing.Size(165, 18)
			Me.OriginValueTextBox.TabIndex = 37
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OriginValueTextBox.TextChanged += new System.EventHandler(this.OriginValueTextBox_TextChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(8, 450)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(165, 20)
			Me.label6.TabIndex = 38
			Me.label6.Text = "Custom Origin Value:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' NStandardBar3DUC
			' 
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.OriginModeCombo)
			Me.Controls.Add(Me.OriginValueTextBox)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.LabelStyleButton)
			Me.Controls.Add(Me.DepthScroll)
			Me.Controls.Add(Me.BarBorderButton)
			Me.Controls.Add(Me.HasBottomEdge)
			Me.Controls.Add(Me.HasTopEdge)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.EdgePercentScrollBar)
			Me.Controls.Add(Me.InvertAxisRuler)
			Me.Controls.Add(Me.DifferentFillStyles)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.WidthScroll)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.StyleCombo)
			Me.Controls.Add(Me.BarFillStyleButton)
			Me.Name = "NStandardBar3DUC"
			Me.Size = New System.Drawing.Size(180, 505)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("3D Bar Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure chart
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.Enable3D = True
			chart.Width = 65
			chart.Height = 40
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' add interlaced stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' setup a bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar Series"
			bar.DataLabelStyle.Visible = True
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
			StyleCombo.SelectedIndex = CInt(BarShape.SmoothEdgeBar)
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

		Private Sub DepthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles DepthScroll.ValueChanged
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			bar.DepthPercent = DepthScroll.Value
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
	End Class
End Namespace
