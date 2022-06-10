Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NStandardSmoothLineUC
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.IContainer = Nothing
		Private WithEvents ChangeYValuesButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LineShadowButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents RoundToTickCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents InflateMarginsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents MarkerStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BorderStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private Const nValuesCount As Integer = 8

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


		#Region "Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.ChangeYValuesButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.LineShadowButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.RoundToTickCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.InflateMarginsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.BorderStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.MarkerStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' ChangeYValuesButton
			' 
			Me.ChangeYValuesButton.Location = New System.Drawing.Point(6, 7)
			Me.ChangeYValuesButton.Name = "ChangeYValuesButton"
			Me.ChangeYValuesButton.Size = New System.Drawing.Size(169, 24)
			Me.ChangeYValuesButton.TabIndex = 0
			Me.ChangeYValuesButton.Text = "Change Y Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeYValuesButton.Click += new System.EventHandler(this.btnChangeYValues_Click);
			' 
			' LineShadowButton
			' 
			Me.LineShadowButton.Location = New System.Drawing.Point(6, 71)
			Me.LineShadowButton.Name = "LineShadowButton"
			Me.LineShadowButton.Size = New System.Drawing.Size(169, 24)
			Me.LineShadowButton.TabIndex = 2
			Me.LineShadowButton.Text = "Line Shadow..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineShadowButton.Click += new System.EventHandler(this.LineShadowButton_Click);
			' 
			' RoundToTickCheck
			' 
			Me.RoundToTickCheck.ButtonProperties.BorderOffset = 2
			Me.RoundToTickCheck.Location = New System.Drawing.Point(6, 172)
			Me.RoundToTickCheck.Name = "RoundToTickCheck"
			Me.RoundToTickCheck.Size = New System.Drawing.Size(169, 24)
			Me.RoundToTickCheck.TabIndex = 5
			Me.RoundToTickCheck.Text = "Left Axis Round to Tick"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RoundToTickCheck.CheckedChanged += new System.EventHandler(this.RoundToTickCheck_CheckedChanged);
			' 
			' InflateMarginsCheck
			' 
			Me.InflateMarginsCheck.ButtonProperties.BorderOffset = 2
			Me.InflateMarginsCheck.Location = New System.Drawing.Point(6, 144)
			Me.InflateMarginsCheck.Name = "InflateMarginsCheck"
			Me.InflateMarginsCheck.Size = New System.Drawing.Size(169, 24)
			Me.InflateMarginsCheck.TabIndex = 4
			Me.InflateMarginsCheck.Text = "Inflate Margins"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			' 
			' BorderStyleButton
			' 
			Me.BorderStyleButton.Location = New System.Drawing.Point(6, 39)
			Me.BorderStyleButton.Name = "BorderStyleButton"
			Me.BorderStyleButton.Size = New System.Drawing.Size(169, 24)
			Me.BorderStyleButton.TabIndex = 1
			Me.BorderStyleButton.Text = "Border Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BorderStyleButton.Click += new System.EventHandler(this.BorderPropsButton_Click);
			' 
			' MarkerStyleButton
			' 
			Me.MarkerStyleButton.Location = New System.Drawing.Point(6, 104)
			Me.MarkerStyleButton.Name = "MarkerStyleButton"
			Me.MarkerStyleButton.Size = New System.Drawing.Size(169, 24)
			Me.MarkerStyleButton.TabIndex = 3
			Me.MarkerStyleButton.Text = "Marker Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			' 
			' NStandardSmoothLineUC
			' 
			Me.Controls.Add(Me.MarkerStyleButton)
			Me.Controls.Add(Me.LineShadowButton)
			Me.Controls.Add(Me.RoundToTickCheck)
			Me.Controls.Add(Me.InflateMarginsCheck)
			Me.Controls.Add(Me.BorderStyleButton)
			Me.Controls.Add(Me.ChangeYValuesButton)
			Me.Name = "NStandardSmoothLineUC"
			Me.Size = New System.Drawing.Size(180, 212)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Smooth Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' setup the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' add interlaced stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' add the line
			Dim line As NSmoothLineSeries = CType(chart.Series.Add(SeriesType.SmoothLine), NSmoothLineSeries)
			line.Name = "Smooth Line"
			line.Legend.Mode = SeriesLegendMode.Series
			line.UseXValues = False
			line.UseZValues = False
			line.DataLabelStyle.Visible = False
			line.MarkerStyle.Visible = True
			line.MarkerStyle.PointShape = PointShape.Cylinder
			line.MarkerStyle.AutoDepth = False
			line.MarkerStyle.Width = New NLength(1.4F, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Height = New NLength(1.4F, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Depth = New NLength(1.4F, NRelativeUnit.ParentPercentage)

			GenerateYValues(nValuesCount)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			InflateMarginsCheck.Checked = True
			RoundToTickCheck.Checked = True
		End Sub

		Private Sub GenerateYValues(ByVal nCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim series As NSeries = CType(chart.Series(0), NSeries)

			series.Values.Clear()

			For i As Integer = 0 To nCount - 1
				series.Values.Add(Random.NextDouble() * 20)
			Next i
		End Sub

		Private Sub btnChangeYValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeYValuesButton.Click
			GenerateYValues(nValuesCount)
			nChartControl1.Refresh()
		End Sub

		Private Sub BorderPropsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BorderStyleButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim line As NSmoothLineSeries = CType(chart.Series(0), NSmoothLineSeries)

			If NStrokeStyleTypeEditor.Edit(line.BorderStyle, strokeStyleResult) Then
				line.BorderStyle = strokeStyleResult
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

		Private Sub MarkerStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MarkerStyleButton.Click
			Dim markerStyleResult As NMarkerStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NMarkerStyleTypeEditor.Edit(series.MarkerStyle, markerStyleResult) Then
				series.MarkerStyle = markerStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub InflateMarginsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InflateMarginsCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim line As NSmoothLineSeries = CType(chart.Series(0), NSmoothLineSeries)

			line.InflateMargins = InflateMarginsCheck.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub RoundToTickCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RoundToTickCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)

			Dim standardScale As NStandardScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)

			standardScale.RoundToTickMin = RoundToTickCheck.Checked
			standardScale.RoundToTickMax = RoundToTickCheck.Checked

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
