Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NPolarVectorUC
		Inherits NExampleBaseUC

		Private WithEvents BeginAngleUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label6 As Label
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
			Me.BeginAngleUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label6 = New System.Windows.Forms.Label()
			DirectCast(Me.BeginAngleUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' BeginAngleUpDown
			' 
			Me.BeginAngleUpDown.Location = New System.Drawing.Point(9, 30)
			Me.BeginAngleUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.BeginAngleUpDown.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
			Me.BeginAngleUpDown.Name = "BeginAngleUpDown"
			Me.BeginAngleUpDown.Size = New System.Drawing.Size(161, 20)
			Me.BeginAngleUpDown.TabIndex = 19
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BeginAngleUpDown.ValueChanged += new System.EventHandler(this.BeginAngleUpDown_ValueChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(9, 10)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(162, 17)
			Me.label6.TabIndex = 17
			Me.label6.Text = "Begin Angle:"
			' 
			' NPolarVectorUC
			' 
			Me.Controls.Add(Me.BeginAngleUpDown)
			Me.Controls.Add(Me.label6)
			Me.Name = "NPolarVectorUC"
			Me.Size = New System.Drawing.Size(180, 222)
			DirectCast(Me.BeginAngleUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' configure chart
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Polar Vector")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup polar chart
			Dim chart As New NPolarChart()
			nChartControl1.Panels.Add(chart)

			' setup polar axis
			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.Polar).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.ViewRangeInflateMode = ScaleViewRangeInflateMode.MajorTick
			linearScale.InflateViewRangeBegin = True
			linearScale.InflateViewRangeEnd = True

			Dim strip As New NScaleStripStyle()
			strip.FillStyle = New NColorFillStyle(Color.FromArgb(125, Color.Beige))
			strip.Interlaced = True
			strip.SetShowAtWall(ChartWallType.Polar, True)
			linearScale.StripStyles.Add(strip)

			' setup polar angle axis
			Dim angularScale As NAngularScaleConfigurator = CType(chart.Axis(StandardAxis.PolarAngle).ScaleConfigurator, NAngularScaleConfigurator)
			strip = New NScaleStripStyle()
			strip.FillStyle = New NColorFillStyle(Color.FromArgb(125, 192, 192, 192))
			strip.Interlaced = True
			strip.SetShowAtWall(ChartWallType.Polar, True)
			angularScale.StripStyles.Add(strip)

			' create a polar line series
			Dim vectorSeries As New NPolarVectorSeries()
			chart.Series.Add(vectorSeries)
			vectorSeries.Name = "Series 1"
			vectorSeries.DataLabelStyle.Visible = False
			vectorSeries.ShadowStyle.Type = ShadowType.LinearBlur
			vectorSeries.ShadowStyle.Color = Color.Red

			Dim dataPointIndex As Integer = 0

			For i As Integer = 0 To 359 Step 30
				For j As Integer = 10 To 100 Step 10
					vectorSeries.Angles.Add(i)
					vectorSeries.Values.Add(j)

					vectorSeries.X2Values.Add(i + j \ 10)
					vectorSeries.Y2Values.Add(j)

					vectorSeries.BorderStyles(dataPointIndex) = New NStrokeStyle(1.0F, ColorFromValue(j))
					dataPointIndex += 1
				Next j
			Next i

		End Sub

		''' <summary>
		''' 
		''' </summary>
		''' <param name="value"></param>
		''' <returns></returns>
		Private Shared Function ColorFromValue(ByVal value As Double) As Color
			Dim color1 As Color = Color.Red
			Dim color2 As Color = Color.Blue

			Dim factor As Double = value / 100.0
			Dim oneMinusFactor As Double = 1 - factor

			Return Color.FromArgb(CByte(color1.A * oneMinusFactor + color2.A * factor), CByte(color1.R * oneMinusFactor + color2.R * factor), CByte(color1.G * oneMinusFactor + color2.G * factor), CByte(color1.B * oneMinusFactor + color2.B * factor))
		End Function

		Private Sub BeginAngleUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BeginAngleUpDown.ValueChanged
			Dim polarChart As NPolarChart = TryCast(nChartControl1.Charts(0), NPolarChart)
			If polarChart IsNot Nothing Then
				polarChart.BeginAngle = CSng(BeginAngleUpDown.Value)
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace