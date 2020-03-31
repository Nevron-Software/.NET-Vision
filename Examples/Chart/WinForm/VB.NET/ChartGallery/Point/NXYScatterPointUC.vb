Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NXYScatterPointUC
		Inherits NExampleBaseUC

		Private WithEvents NewDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents AxesRoundToTick As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents InflateMarginsCheck As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.NewDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.AxesRoundToTick = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.InflateMarginsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' NewDataButton
			' 
			Me.NewDataButton.Location = New System.Drawing.Point(8, 8)
			Me.NewDataButton.Name = "NewDataButton"
			Me.NewDataButton.Size = New System.Drawing.Size(161, 24)
			Me.NewDataButton.TabIndex = 0
			Me.NewDataButton.Text = "New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.NewDataButton.Click += new System.EventHandler(this.NewDataButton_Click);
			' 
			' AxesRoundToTick
			' 
			Me.AxesRoundToTick.ButtonProperties.BorderOffset = 2
			Me.AxesRoundToTick.Location = New System.Drawing.Point(8, 46)
			Me.AxesRoundToTick.Name = "AxesRoundToTick"
			Me.AxesRoundToTick.Size = New System.Drawing.Size(161, 19)
			Me.AxesRoundToTick.TabIndex = 1
			Me.AxesRoundToTick.Text = "Axes Round To Tick"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AxesRoundToTick.CheckedChanged += new System.EventHandler(this.AxesRoundToTick_CheckedChanged);
			' 
			' InflateMarginsCheck
			' 
			Me.InflateMarginsCheck.ButtonProperties.BorderOffset = 2
			Me.InflateMarginsCheck.Location = New System.Drawing.Point(8, 72)
			Me.InflateMarginsCheck.Name = "InflateMarginsCheck"
			Me.InflateMarginsCheck.Size = New System.Drawing.Size(161, 20)
			Me.InflateMarginsCheck.TabIndex = 2
			Me.InflateMarginsCheck.Text = "Inflate Margins"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			' 
			' NXYScatterPointUC
			' 
			Me.Controls.Add(Me.InflateMarginsCheck)
			Me.Controls.Add(Me.AxesRoundToTick)
			Me.Controls.Add(Me.NewDataButton)
			Me.Name = "NXYScatterPointUC"
			Me.Size = New System.Drawing.Size(180, 106)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XY Scatter Point Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)

			' setup X axis
			Dim scaleX As New NLinearScaleConfigurator()
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' setup Y axis
			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' add a point series
			Dim point As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			point.Name = "Point Series"
			point.DataLabelStyle.Visible = False
			point.FillStyle = New NColorFillStyle(Color.FromArgb(160, DarkOrange))
			point.BorderStyle.Width = New NLength(0)
			point.Size = New NLength(1, NRelativeUnit.ParentPercentage)
			point.PointShape = PointShape.Ellipse
			point.UseXValues = True

			GenerateXYData(point)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' init form controls
			AxesRoundToTick.Checked = True
			InflateMarginsCheck.Checked = True
		End Sub
		Private Sub GenerateXYData(ByVal series As NPointSeries)
			series.ClearDataPoints()

			For i As Integer = 0 To 999
				Dim u1 As Double = Random.NextDouble()
				Dim u2 As Double = Random.NextDouble()

				If u1 = 0 Then
					u1 += 0.0001
				End If

				If u2 = 0 Then
					u2 += 0.0001
				End If

				Dim z0 As Double = Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2)
				Dim z1 As Double = Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2)

				series.XValues.Add(z0)
				series.Values.Add(z1)
			Next i
		End Sub

		Private Sub NewDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewDataButton.Click
			Dim point As NPointSeries = CType(nChartControl1.Charts(0).Series(0), NPointSeries)
			GenerateXYData(point)
			nChartControl1.Refresh()
		End Sub
		Private Sub InflateMarginsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InflateMarginsCheck.CheckedChanged
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)
			series.InflateMargins = InflateMarginsCheck.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub AxesRoundToTick_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AxesRoundToTick.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)

			Dim linearScale As NStandardScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			linearScale.RoundToTickMin = AxesRoundToTick.Checked
			linearScale.RoundToTickMax = AxesRoundToTick.Checked

			linearScale = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			linearScale.RoundToTickMin = AxesRoundToTick.Checked
			linearScale.RoundToTickMax = AxesRoundToTick.Checked

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
