Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NDateTimeSmoothLineUC
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.IContainer = Nothing
		Private Const nValuesCount As Integer = 8
		Private WithEvents btnChangeXValues As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents btnChangeYValues As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents checkRoundToTick As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents checkShowMarkers As Nevron.UI.WinForm.Controls.NCheckBox

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
			Me.btnChangeXValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.btnChangeYValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.checkRoundToTick = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.checkShowMarkers = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' btnChangeXValues
			' 
			Me.btnChangeXValues.Location = New System.Drawing.Point(6, 47)
			Me.btnChangeXValues.Name = "btnChangeXValues"
			Me.btnChangeXValues.Size = New System.Drawing.Size(169, 32)
			Me.btnChangeXValues.TabIndex = 1
			Me.btnChangeXValues.Text = "Change X Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnChangeXValues.Click += new System.EventHandler(this.btnChangeXValues_Click);
			' 
			' btnChangeYValues
			' 
			Me.btnChangeYValues.Location = New System.Drawing.Point(6, 7)
			Me.btnChangeYValues.Name = "btnChangeYValues"
			Me.btnChangeYValues.Size = New System.Drawing.Size(169, 32)
			Me.btnChangeYValues.TabIndex = 0
			Me.btnChangeYValues.Text = "Change Y Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnChangeYValues.Click += new System.EventHandler(this.btnChangeYValues_Click);
			' 
			' checkRoundToTick
			' 
			Me.checkRoundToTick.ButtonProperties.BorderOffset = 2
			Me.checkRoundToTick.Location = New System.Drawing.Point(5, 135)
			Me.checkRoundToTick.Name = "checkRoundToTick"
			Me.checkRoundToTick.Size = New System.Drawing.Size(169, 24)
			Me.checkRoundToTick.TabIndex = 3
			Me.checkRoundToTick.Text = "Axis Round To Tick "
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.checkRoundToTick.CheckedChanged += new System.EventHandler(this.checkRoundToTick_CheckedChanged);
			' 
			' checkShowMarkers
			' 
			Me.checkShowMarkers.ButtonProperties.BorderOffset = 2
			Me.checkShowMarkers.Location = New System.Drawing.Point(5, 95)
			Me.checkShowMarkers.Name = "checkShowMarkers"
			Me.checkShowMarkers.Size = New System.Drawing.Size(169, 24)
			Me.checkShowMarkers.TabIndex = 2
			Me.checkShowMarkers.Text = "Show Markers"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.checkShowMarkers.CheckedChanged += new System.EventHandler(this.checkShowMarkers_CheckedChanged);
			' 
			' NDateTimeSmoothLineUC
			' 
			Me.Controls.Add(Me.checkRoundToTick)
			Me.Controls.Add(Me.checkShowMarkers)
			Me.Controls.Add(Me.btnChangeXValues)
			Me.Controls.Add(Me.btnChangeYValues)
			Me.Name = "NDateTimeSmoothLineUC"
			Me.Size = New System.Drawing.Size(180, 176)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("DateTime Smooth Line")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			Dim dateTimeScale As New NDateTimeScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale
			dateTimeScale.LabelValueFormatter = New NDateTimeValueFormatter(DateTimeValueFormat.Date)
			dateTimeScale.LabelGenerationMode = LabelGenerationMode.Stagger2

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
			line.InflateMargins = True
			line.Legend.Mode = SeriesLegendMode.Series
			line.DataLabelStyle.Visible = False
			line.MarkerStyle.Visible = True
			line.MarkerStyle.PointShape = PointShape.Cylinder
			line.MarkerStyle.AutoDepth = False
			line.MarkerStyle.Width = New NLength(1.4F, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Height = New NLength(1.4F, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Depth = New NLength(1.4F, NRelativeUnit.ParentPercentage)
			line.UseXValues = True
			line.UseZValues = False
			line.Use1DInterpolationForXYScatter = True

			checkShowMarkers.Checked = True
			checkRoundToTick.Checked = True

			GenerateYValues(nValuesCount)
			GenerateXValues(nValuesCount)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Sub GenerateYValues(ByVal nCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim series As NSeries = CType(chart.Series(0), NSeries)

			series.Values.Clear()

			For i As Integer = 0 To nCount - 1
				series.Values.Add(Random.NextDouble() * 20)
			Next i
		End Sub

		Private Sub GenerateXValues(ByVal nCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim series As NXYScatterSeries = CType(chart.Series(0), NXYScatterSeries)

			series.XValues.Clear()

			Dim dt As New Date(2005, 5, 24, 11, 0, 0)

			For i As Integer = 0 To nCount - 1
				dt = dt.AddHours(12 + Random.NextDouble() * 60)

				series.XValues.Add(dt)
			Next i
		End Sub


		Private Sub btnChangeYValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeYValues.Click
			GenerateYValues(nValuesCount)
			nChartControl1.Refresh()
		End Sub

		Private Sub btnChangeXValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeXValues.Click
			GenerateXValues(nValuesCount)
			nChartControl1.Refresh()
		End Sub

		Private Sub checkShowMarkers_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkShowMarkers.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim line As NSmoothLineSeries = CType(chart.Series(0), NSmoothLineSeries)

			line.MarkerStyle.Visible = checkShowMarkers.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub checkRoundToTick_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkRoundToTick.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)

			Dim bRoundToTick As Boolean = checkRoundToTick.Checked

			Dim standardScale As NStandardScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			standardScale.RoundToTickMin = bRoundToTick
			standardScale.RoundToTickMax = bRoundToTick

			standardScale = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			standardScale.RoundToTickMin = bRoundToTick
			standardScale.RoundToTickMax = bRoundToTick

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace

