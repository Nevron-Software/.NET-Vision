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
	Public Class NPolarAreaUC
		Inherits NExampleBaseUC

		Private WithEvents BeginAngleUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label6 As Label
		Private WithEvents AngleStepCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label3 As Label
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
			Me.AngleStepCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
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
			' AngleStepCombo
			' 
			Me.AngleStepCombo.ListProperties.CheckBoxDataMember = ""
			Me.AngleStepCombo.ListProperties.DataSource = Nothing
			Me.AngleStepCombo.ListProperties.DisplayMember = ""
			Me.AngleStepCombo.Location = New System.Drawing.Point(9, 78)
			Me.AngleStepCombo.Name = "AngleStepCombo"
			Me.AngleStepCombo.Size = New System.Drawing.Size(162, 21)
			Me.AngleStepCombo.TabIndex = 24
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AngleStepCombo.SelectedIndexChanged += new System.EventHandler(this.AngleStepCombo_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(9, 60)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(162, 16)
			Me.label3.TabIndex = 23
			Me.label3.Text = "Radian Angle Step:"
			' 
			' NPolarAreaUC
			' 
			Me.Controls.Add(Me.AngleStepCombo)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.BeginAngleUpDown)
			Me.Controls.Add(Me.label6)
			Me.Name = "NPolarAreaUC"
			Me.Size = New System.Drawing.Size(180, 222)
			DirectCast(Me.BeginAngleUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Polar Area")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			Dim chart As New NPolarChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(chart)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			chart.DisplayOnLegend = nChartControl1.Legends(0)
			chart.Width = 70.0F
			chart.Height = 70.0F
			chart.Depth = 5

			' setup polar axis
			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.Polar).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RoundToTickMax = True
			linearScale.RoundToTickMin = True
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)

			Dim strip As New NScaleStripStyle()
			strip.FillStyle = New NColorFillStyle(Color.FromArgb(125, Color.Beige))
			strip.Interlaced = True
			strip.SetShowAtWall(ChartWallType.Polar, True)
			linearScale.StripStyles.Add(strip)

			' setup polar angle axis
			Dim angularScale As NAngularScaleConfigurator = CType(chart.Axis(StandardAxis.PolarAngle).ScaleConfigurator, NAngularScaleConfigurator)
			angularScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)
			strip = New NScaleStripStyle()
			strip.FillStyle = New NColorFillStyle(Color.FromArgb(125, 192, 192, 192))
			strip.Interlaced = True
			strip.SetShowAtWall(ChartWallType.Polar, True)
			angularScale.StripStyles.Add(strip)

			' polar area series 1
			Dim series1 As New NPolarAreaSeries()
			chart.Series.Add(series1)
			series1.Name = "Theoretical"
			series1.DataLabelStyle.Visible = False
			GenerateData(series1, 100, 15.0)

			' polar area series 2
			Dim series2 As New NPolarAreaSeries()
			chart.Series.Add(series2)
			series2.Name = "Experimental"
			series2.DataLabelStyle.Visible = False
			GenerateData(series2, 100, 10.0)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			AngleStepCombo.Items.Add("15")
			AngleStepCombo.Items.Add("30")
			AngleStepCombo.Items.Add("45")
			AngleStepCombo.Items.Add("90")
			AngleStepCombo.SelectedIndex = 0
		End Sub

		Private Sub GenerateData(ByVal series As NPolarSeries, ByVal count As Integer, ByVal scale As Double)
			series.Values.Clear()
			series.Angles.Clear()

			Dim angleStep As Double = 2 * Math.PI / count

			For i As Integer = 0 To count - 1
				Dim angle As Double = i * angleStep
				Dim c1 As Double = 1.0 * Math.Sin(angle * 3)
				Dim c2 As Double = 0.3 * Math.Sin(angle * 1.5)
				Dim c3 As Double = 0.05 * Math.Cos(angle * 26)
				Dim c4 As Double = 0.05 * (0.5 - Random.NextDouble())
				Dim value As Double = scale * (Math.Abs(c1 + c2 + c3) + c4)

				If value < 0 Then
					value = 0
				End If

				series.Values.Add(value)
				series.Angles.Add(angle * 180 / Math.PI)
			Next i
		End Sub

		Private Sub AxisRoundToTickCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
'			if (nChartControl1 == null)
'				return;
'
'			NStandardScaleConfigurator standardScale = m_Chart.Axis(StandardAxis.Polar).ScaleConfigurator as NStandardScaleConfigurator;
'
'			if (standardScale != null)
'			{
'				standardScale.RoundToTickMax = AxisRoundToTickCheck.Checked;
'				standardScale.RoundToTickMin = AxisRoundToTickCheck.Checked;
'			}
'
'			nChartControl1.Refresh();
		End Sub
		Private Sub BeginAngleUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BeginAngleUpDown.ValueChanged
			Dim polarChart As NPolarChart = TryCast(nChartControl1.Charts(0), NPolarChart)
			If polarChart IsNot Nothing Then
				polarChart.BeginAngle = CSng(BeginAngleUpDown.Value)
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub AngleStepCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AngleStepCombo.SelectedIndexChanged
			Dim polarChart As NPolarChart = TryCast(nChartControl1.Charts(0), NPolarChart)
			If polarChart Is Nothing Then
				Return
			End If

			Dim angleScale As NAngularScaleConfigurator = TryCast(polarChart.Axis(StandardAxis.PolarAngle).ScaleConfigurator, NAngularScaleConfigurator)

			Select Case AngleStepCombo.SelectedIndex
				Case 0
					angleScale.MajorTickMode = MajorTickMode.CustomStep
					angleScale.CustomStep = New NAngle(15, NAngleUnit.Degree)

				Case 1
					angleScale.MajorTickMode = MajorTickMode.CustomStep
					angleScale.CustomStep = New NAngle(30, NAngleUnit.Degree)

				Case 2
					angleScale.MajorTickMode = MajorTickMode.CustomStep
					angleScale.CustomStep = New NAngle(45, NAngleUnit.Degree)

				Case 3
					angleScale.MajorTickMode = MajorTickMode.CustomStep
					angleScale.CustomStep = New NAngle(90, NAngleUnit.Degree)

				Case Else
					Debug.Assert(False)
			End Select

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace