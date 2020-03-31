Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NPolarPointUC
		Inherits NExampleBaseUC

		Private WithEvents AngleStepCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label3 As Label
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
			Me.AngleStepCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.BeginAngleUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label6 = New System.Windows.Forms.Label()
			DirectCast(Me.BeginAngleUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' AngleStepCombo
			' 
			Me.AngleStepCombo.ListProperties.CheckBoxDataMember = ""
			Me.AngleStepCombo.ListProperties.DataSource = Nothing
			Me.AngleStepCombo.ListProperties.DisplayMember = ""
			Me.AngleStepCombo.Location = New System.Drawing.Point(9, 78)
			Me.AngleStepCombo.Name = "AngleStepCombo"
			Me.AngleStepCombo.Size = New System.Drawing.Size(162, 21)
			Me.AngleStepCombo.TabIndex = 28
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AngleStepCombo.SelectedIndexChanged += new System.EventHandler(this.AngleStepCombo_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(9, 60)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(162, 16)
			Me.label3.TabIndex = 27
			Me.label3.Text = "Radian Angle Step:"
			' 
			' BeginAngleUpDown
			' 
			Me.BeginAngleUpDown.Location = New System.Drawing.Point(9, 30)
			Me.BeginAngleUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.BeginAngleUpDown.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
			Me.BeginAngleUpDown.Name = "BeginAngleUpDown"
			Me.BeginAngleUpDown.Size = New System.Drawing.Size(161, 20)
			Me.BeginAngleUpDown.TabIndex = 26
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BeginAngleUpDown.ValueChanged += new System.EventHandler(this.BeginAngleUpDown_ValueChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(9, 10)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(162, 17)
			Me.label6.TabIndex = 25
			Me.label6.Text = "Begin Angle:"
			' 
			' NPolarPointUC
			' 
			Me.Controls.Add(Me.AngleStepCombo)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.BeginAngleUpDown)
			Me.Controls.Add(Me.label6)
			Me.Name = "NPolarPointUC"
			Me.Size = New System.Drawing.Size(180, 266)
			DirectCast(Me.BeginAngleUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Polar Point")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			Dim chart As New NPolarChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(chart)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			chart.DisplayOnLegend = nChartControl1.Legends(0)
			chart.Depth = 5
			chart.Width = 70.0F
			chart.Height = 70.0F

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

			' add a const line
			Dim line As NAxisConstLine = chart.Axis(StandardAxis.Polar).ConstLines.Add()
			line.Value = 50
			line.StrokeStyle.Color = Color.SlateBlue
			line.StrokeStyle.Width = New NLength(1, NGraphicsUnit.Pixel)

			' create three polar point series
			Dim s1 As NSeries = CreatePolarPointSeries("Sample 1", PointShape.Sphere)
			Dim s2 As NSeries = CreatePolarPointSeries("Sample 2", PointShape.Bar)
			Dim s3 As NSeries = CreatePolarPointSeries("Sample 3", PointShape.Pyramid)

			' add the series to the chart
			chart.Series.Add(s1)
			chart.Series.Add(s2)
			chart.Series.Add(s3)

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

		Private Function CreatePolarPointSeries(ByVal name As String, ByVal shape As PointShape) As NSeries
			Dim series As New NPolarPointSeries()
			series.Name = name
			series.Angles.ValueFormatter = New NNumericValueFormatter("0.00")
			series.DataLabelStyle.Visible = False
			series.DataLabelStyle.Format = "<value> - <angle_in_degrees>"
			series.PointShape = shape
			series.Size = New NLength(1.5F, NRelativeUnit.ParentPercentage)

			' add data
			series.Values.FillRandomRange(Random, 10, 0, 100)
			series.Angles.FillRandomRange(Random, 10, 0, 360)

			Return series
		End Function

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
