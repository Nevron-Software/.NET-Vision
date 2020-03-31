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
	Public Class NPolarRangeUC
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
			' NPolarRangeUC
			' 
			Me.Controls.Add(Me.BeginAngleUpDown)
			Me.Controls.Add(Me.label6)
			Me.Name = "NPolarRangeUC"
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
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Polar Range")
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
			strip.FillStyle = New NColorFillStyle(Color.FromArgb(100, Color.Gray))
			strip.Interlaced = True
			strip.SetShowAtWall(ChartWallType.Polar, True)
			linearScale.StripStyles.Add(strip)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)

			' setup polar angle axis			
			Dim angleAxis As NPolarAxis = CType(chart.Axis(StandardAxis.PolarAngle), NPolarAxis)

			Dim ordinalScale As New NOrdinalScaleConfigurator()

			strip = New NScaleStripStyle()
			strip.FillStyle = New NColorFillStyle(Color.FromArgb(100, Color.DarkGray))
			strip.Interlaced = True
			strip.SetShowAtWall(ChartWallType.Polar, True)
			ordinalScale.StripStyles.Add(strip)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)

			ordinalScale.InflateContentRange = False
			ordinalScale.MajorTickMode = MajorTickMode.CustomTicks
			ordinalScale.DisplayDataPointsBetweenTicks = False

			ordinalScale.MajorTickMode = MajorTickMode.CustomStep
			ordinalScale.CustomStep = 1
			Dim labels() As String = { "E", "NE", "N", "NW", "W", "SW", "S", "SE" }

			ordinalScale.AutoLabels = False
			ordinalScale.Labels.AddRange(labels)
			ordinalScale.DisplayLastLabel = False

			angleAxis.ScaleConfigurator = ordinalScale
			angleAxis.View = New NRangeAxisView(New NRange1DD(0, 8))

			Dim polarRange As New NPolarRangeSeries()
			polarRange.DataLabelStyle.Visible = False
			chart.Series.Add(polarRange)

			Dim rand As New Random()

			For i As Integer = 0 To 7
				polarRange.Values.Add(0)
				polarRange.Angles.Add(i - 0.4)

				polarRange.Y2Values.Add(rand.Next(80) + 20.0)
				polarRange.X2Values.Add(i + 0.4)
			Next i
		End Sub

		Private Sub BeginAngleUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BeginAngleUpDown.ValueChanged
			Dim polarChart As NPolarChart = TryCast(nChartControl1.Charts(0), NPolarChart)
			If polarChart IsNot Nothing Then
				polarChart.BeginAngle = CSng(BeginAngleUpDown.Value)
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace