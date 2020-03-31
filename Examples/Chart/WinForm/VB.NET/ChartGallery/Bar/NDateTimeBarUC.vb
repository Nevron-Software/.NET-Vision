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
	Public Class NDateTimeBarUC
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.IContainer = Nothing
		Private WithEvents btnChangeYValues As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents btnChangeXValues As Nevron.UI.WinForm.Controls.NButton
		Private Const nValuesCount As Integer = 10

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
			Me.btnChangeYValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.btnChangeXValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' btnChangeYValues
			' 
			Me.btnChangeYValues.Location = New System.Drawing.Point(8, 8)
			Me.btnChangeYValues.Name = "btnChangeYValues"
			Me.btnChangeYValues.Size = New System.Drawing.Size(161, 32)
			Me.btnChangeYValues.TabIndex = 0
			Me.btnChangeYValues.Text = "Change Y Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnChangeYValues.Click += new System.EventHandler(this.btnChangeYValues_Click);
			' 
			' btnChangeXValues
			' 
			Me.btnChangeXValues.Location = New System.Drawing.Point(8, 48)
			Me.btnChangeXValues.Name = "btnChangeXValues"
			Me.btnChangeXValues.Size = New System.Drawing.Size(161, 32)
			Me.btnChangeXValues.TabIndex = 1
			Me.btnChangeXValues.Text = "Change X Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnChangeXValues.Click += new System.EventHandler(this.btnChangeXValues_Click);
			' 
			' NDateTimeBarUC
			' 
			Me.Controls.Add(Me.btnChangeXValues)
			Me.Controls.Add(Me.btnChangeYValues)
			Me.Name = "NDateTimeBarUC"
			Me.Size = New System.Drawing.Size(180, 150)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("DateTime Bars")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlace stripes to the Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 2, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			Dim dateTimeScale As New NDateTimeScaleConfigurator()
			dateTimeScale.LabelFitModes = New LabelFitMode() { LabelFitMode.AutoScale }
			dateTimeScale.LabelGenerationMode = LabelGenerationMode.Stagger2
			 chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale

			' setup bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar Series"
			bar.InflateMargins = True
			bar.UseXValues = True
			bar.UseZValues = False
			bar.DataLabelStyle.Visible = False
			bar.ShadowStyle.Type = ShadowType.Solid
			bar.ShadowStyle.Color = Color.FromArgb(30, 0, 0, 0)

			GenerateYValues(nValuesCount)
			GenerateXValues(nValuesCount)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Sub btnChangeYValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeYValues.Click
			GenerateYValues(nValuesCount)
			nChartControl1.Refresh()
		End Sub

		Private Sub btnChangeXValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeXValues.Click
			GenerateXValues(nValuesCount)
			nChartControl1.Refresh()
		End Sub

		Private Sub GenerateYValues(ByVal nCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim bar As NBarSeries = CType(chart.Series(0), NBarSeries)

			bar.Values.Clear()

			For i As Integer = 0 To nCount - 1
				bar.Values.Add(Random.NextDouble() * 20)
			Next i
		End Sub

		Private Sub GenerateXValues(ByVal nCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim bar As NBarSeries = CType(chart.Series(0), NBarSeries)

			bar.XValues.Clear()

			Dim dt As New Date(2005, 5, 24, 11, 0, 0)

			For i As Integer = 0 To nCount - 1
				dt = dt.AddHours(12 + Random.NextDouble() * 60)

				bar.XValues.Add(dt)
			Next i
		End Sub
	End Class
End Namespace

