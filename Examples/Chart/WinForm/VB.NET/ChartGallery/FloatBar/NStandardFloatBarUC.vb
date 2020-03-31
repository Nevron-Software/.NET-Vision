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
	Public Class NStandardFloatBarUC
		Inherits NExampleBaseUC

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private WithEvents BarShapeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents DepthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents WidthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents BarFEButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BarBorderButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ShowDataLabelsCheck As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.BarShapeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.BarFEButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.DepthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.WidthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.BarBorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShowDataLabelsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(10, 10)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(159, 16)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Bar Shape:"
			' 
			' BarShapeCombo
			' 
			Me.BarShapeCombo.ListProperties.CheckBoxDataMember = ""
			Me.BarShapeCombo.ListProperties.DataSource = Nothing
			Me.BarShapeCombo.ListProperties.DisplayMember = ""
			Me.BarShapeCombo.Location = New System.Drawing.Point(10, 27)
			Me.BarShapeCombo.Name = "BarShapeCombo"
			Me.BarShapeCombo.Size = New System.Drawing.Size(159, 21)
			Me.BarShapeCombo.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarShapeCombo.SelectedIndexChanged += new System.EventHandler(this.BarStyleCombo_SelectedIndexChanged);
			' 
			' BarFEButton
			' 
			Me.BarFEButton.Location = New System.Drawing.Point(10, 162)
			Me.BarFEButton.Name = "BarFEButton"
			Me.BarFEButton.Size = New System.Drawing.Size(159, 24)
			Me.BarFEButton.TabIndex = 4
			Me.BarFEButton.Text = "Bar Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarFEButton.Click += new System.EventHandler(this.BarFEButton_Click);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(10, 108)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(159, 16)
			Me.label3.TabIndex = 10
			Me.label3.Text = "Depth %:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(10, 62)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(159, 16)
			Me.label2.TabIndex = 9
			Me.label2.Text = "Width %:"
			' 
			' DepthScroll
			' 
			Me.DepthScroll.Location = New System.Drawing.Point(10, 126)
			Me.DepthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.DepthScroll.Name = "DepthScroll"
			Me.DepthScroll.Size = New System.Drawing.Size(159, 16)
			Me.DepthScroll.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.DepthScroll_Scroll);
			' 
			' WidthScroll
			' 
			Me.WidthScroll.Location = New System.Drawing.Point(10, 80)
			Me.WidthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.WidthScroll.Name = "WidthScroll"
			Me.WidthScroll.Size = New System.Drawing.Size(159, 16)
			Me.WidthScroll.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WidthScroll_Scroll);
			' 
			' BarBorderButton
			' 
			Me.BarBorderButton.Location = New System.Drawing.Point(10, 193)
			Me.BarBorderButton.Name = "BarBorderButton"
			Me.BarBorderButton.Size = New System.Drawing.Size(159, 24)
			Me.BarBorderButton.TabIndex = 18
			Me.BarBorderButton.Text = "Bar Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarBorderButton.Click += new System.EventHandler(this.BarBorderButton_Click);
			' 
			' ShowDataLabelsCheck
			' 
			Me.ShowDataLabelsCheck.ButtonProperties.BorderOffset = 2
			Me.ShowDataLabelsCheck.Location = New System.Drawing.Point(10, 235)
			Me.ShowDataLabelsCheck.Name = "ShowDataLabelsCheck"
			Me.ShowDataLabelsCheck.Size = New System.Drawing.Size(159, 21)
			Me.ShowDataLabelsCheck.TabIndex = 27
			Me.ShowDataLabelsCheck.Text = "Show Data Labels"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowDataLabelsCheck.CheckedChanged += new System.EventHandler(this.ShowDataLabelsCheck_CheckedChanged);
			' 
			' NStandardFloatBarUC
			' 
			Me.Controls.Add(Me.ShowDataLabelsCheck)
			Me.Controls.Add(Me.BarBorderButton)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.DepthScroll)
			Me.Controls.Add(Me.WidthScroll)
			Me.Controls.Add(Me.BarFEButton)
			Me.Controls.Add(Me.BarShapeCombo)
			Me.Controls.Add(Me.label1)
			Me.Name = "NStandardFloatBarUC"
			Me.Size = New System.Drawing.Size(180, 304)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("3D Floating Bars")
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
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftTopLeft)

			' setup X axis
			Dim scaleX As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.AutoLabels = False
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleX.DisplayDataPointsBetweenTicks = False
			For i As Integer = 0 To monthLetters.Length - 1
				scaleX.CustomLabels.Add(New NCustomValueLabel(i, monthLetters(i)))
			Next i

			' add interlaced stripe to the Y axis
			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			' create the float bar series
			Dim floatBar As NFloatBarSeries = CType(chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			floatBar.DataLabelStyle.Visible = False
			floatBar.DataLabelStyle.VertAlign = VertAlign.Center
			floatBar.DataLabelStyle.Format = "<begin> - <end>"

			' add bars
			floatBar.AddDataPoint(New NFloatBarDataPoint(2, 10))
			floatBar.AddDataPoint(New NFloatBarDataPoint(5, 16))
			floatBar.AddDataPoint(New NFloatBarDataPoint(9, 17))
			floatBar.AddDataPoint(New NFloatBarDataPoint(12, 21))
			floatBar.AddDataPoint(New NFloatBarDataPoint(8, 18))
			floatBar.AddDataPoint(New NFloatBarDataPoint(7, 18))
			floatBar.AddDataPoint(New NFloatBarDataPoint(3, 11))
			floatBar.AddDataPoint(New NFloatBarDataPoint(5, 12))
			floatBar.AddDataPoint(New NFloatBarDataPoint(8, 17))
			floatBar.AddDataPoint(New NFloatBarDataPoint(6, 15))
			floatBar.AddDataPoint(New NFloatBarDataPoint(3, 10))
			floatBar.AddDataPoint(New NFloatBarDataPoint(1, 7))

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			BarShapeCombo.FillFromEnum(GetType(BarShape))
			BarShapeCombo.SelectedIndex = 0
		End Sub

		Private Sub BarFEButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarFEButton.Click
			Dim fillStyleResult As NFillStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NFillStyleTypeEditor.Edit(series.FillStyle, fillStyleResult) Then
				series.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub BarBorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarBorderButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NStrokeStyleTypeEditor.Edit(series.BorderStyle, strokeStyleResult) Then
				series.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub BarStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarShapeCombo.SelectedIndexChanged
			Dim floatBar As NFloatBarSeries = CType(nChartControl1.Charts(0).Series(0), NFloatBarSeries)
			floatBar.BarShape = CType(BarShapeCombo.SelectedIndex, BarShape)
			nChartControl1.Refresh()
		End Sub
		Private Sub WidthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles WidthScroll.ValueChanged
			Dim floatBar As NFloatBarSeries = CType(nChartControl1.Charts(0).Series(0), NFloatBarSeries)
			floatBar.WidthPercent = WidthScroll.Value
			nChartControl1.Refresh()
		End Sub
		Private Sub DepthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles DepthScroll.ValueChanged
			Dim floatBar As NFloatBarSeries = CType(nChartControl1.Charts(0).Series(0), NFloatBarSeries)
			floatBar.DepthPercent = DepthScroll.Value
			nChartControl1.Refresh()
		End Sub
		Private Sub ShowDataLabelsCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowDataLabelsCheck.CheckedChanged
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)
			series.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
