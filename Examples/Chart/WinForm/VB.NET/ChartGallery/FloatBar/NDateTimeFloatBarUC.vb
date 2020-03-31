Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NDateTimeFloatBarUC
		Inherits NExampleBaseUC

		Private WithEvents btnChangeData As Nevron.UI.WinForm.Controls.NButton
		Private components As System.ComponentModel.IContainer = Nothing

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
			Me.btnChangeData = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' btnChangeData
			' 
			Me.btnChangeData.Location = New System.Drawing.Point(7, 8)
			Me.btnChangeData.Name = "btnChangeData"
			Me.btnChangeData.Size = New System.Drawing.Size(164, 32)
			Me.btnChangeData.TabIndex = 1
			Me.btnChangeData.Text = "Change Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnChangeData.Click += new System.EventHandler(this.btnChangeData_Click);
			' 
			' NDateTimeFloatBarUC
			' 
			Me.Controls.Add(Me.btnChangeData)
			Me.Name = "NDateTimeFloatBarUC"
			Me.Size = New System.Drawing.Size(180, 150)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("DateTime Float Bar")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' setup Y axis
			Dim linearScale As New NLinearScaleConfigurator()
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)

			' add interlaced stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale

			' setup x axis
			Dim dateTimeScale As New NDateTimeScaleConfigurator()
			dateTimeScale.LabelValueFormatter = New NDateTimeValueFormatter(DateTimeValueFormat.Date)
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale

			' create the float bar series
			Dim floatBar As New NFloatBarSeries()
			chart.Series.Add(floatBar)
			floatBar.UseXValues = True
			floatBar.UseZValues = False
			floatBar.InflateMargins = True
			floatBar.DataLabelStyle.Visible = False

			' bar appearance
			floatBar.BorderStyle.Color = Color.Bisque
			floatBar.ShadowStyle.Type = ShadowType.Solid
			floatBar.ShadowStyle.Color = Color.FromArgb(30, 0, 0, 0)

			floatBar.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			floatBar.EndValues.ValueFormatter = New NNumericValueFormatter("0.00")

			' show the begin end values in the legend
			floatBar.Legend.Format = "<begin> - <end>"
			floatBar.Legend.Mode = SeriesLegendMode.DataPoints

			GenerateData(floatBar)

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Sub GenerateData(ByVal floatBar As NFloatBarSeries)
			Const nCount As Integer = 6

			floatBar.Values.Clear()
			floatBar.EndValues.Clear()
			floatBar.XValues.Clear()

			' generate Y values
			For i As Integer = 0 To nCount - 1
				Dim dBeginValue As Double = Random.NextDouble() * 5
				Dim dEndValue As Double = dBeginValue + 2 + Random.NextDouble()
				floatBar.Values.Add(dBeginValue)
				floatBar.EndValues.Add(dEndValue)
			Next i

			' generate X values
			Dim dt As New Date(2007, 5, 24, 11, 0, 0)

			For i As Integer = 0 To nCount - 1
				dt = dt.AddHours(12 + Random.NextDouble() * 60)

				floatBar.XValues.Add(dt)
			Next i
		End Sub

		Private Sub btnChangeData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeData.Click
			Dim floatBar As NFloatBarSeries = CType(nChartControl1.Charts(0).Series(0), NFloatBarSeries)

			GenerateData(floatBar)

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace

