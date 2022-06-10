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
	<ToolboxItem(False)>
	Public Class NXYZScatterLineUC
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.Container = Nothing
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents ComplexityNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents WindingsNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown

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
			Me.ComplexityNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.WindingsNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			DirectCast(Me.ComplexityNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.WindingsNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(5, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(169, 20)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Complexity:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ComplexityNumericUpDown
			' 
			Me.ComplexityNumericUpDown.Location = New System.Drawing.Point(5, 24)
			Me.ComplexityNumericUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.ComplexityNumericUpDown.Name = "ComplexityNumericUpDown"
			Me.ComplexityNumericUpDown.Size = New System.Drawing.Size(169, 20)
			Me.ComplexityNumericUpDown.TabIndex = 1
			Me.ComplexityNumericUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ComplexityNumericUpDown.ValueChanged += new System.EventHandler(this.ComplexityNumericUpDown_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(5, 48)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(169, 20)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Windings:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' WindingsNumericUpDown
			' 
			Me.WindingsNumericUpDown.Location = New System.Drawing.Point(5, 64)
			Me.WindingsNumericUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.WindingsNumericUpDown.Name = "WindingsNumericUpDown"
			Me.WindingsNumericUpDown.Size = New System.Drawing.Size(169, 20)
			Me.WindingsNumericUpDown.TabIndex = 3
			Me.WindingsNumericUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WindingsNumericUpDown.ValueChanged += new System.EventHandler(this.WindingsNumericUpDown_ValueChanged);
			' 
			' NXYZScatterLineUC
			' 
			Me.Controls.Add(Me.WindingsNumericUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.ComplexityNumericUpDown)
			Me.Controls.Add(Me.label1)
			Me.Name = "NXYZScatterLineUC"
			Me.Size = New System.Drawing.Size(180, 224)
			DirectCast(Me.ComplexityNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.WindingsNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XYZ Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 70
			chart.Height = 70
			chart.Depth = 70
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Axis(StandardAxis.Depth).Visible = True

			' configure the depth axis
			Dim linearScale As New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' configure the horz axis
			linearScale = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale

			linearScale.LabelFitModes = New LabelFitMode(){}

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' configure the y axis
			linearScale = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add the line
			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line.LineSegmentShape = LineSegmentShape.Line
			line.DataLabelStyle.Visible = False
			line.Legend.Mode = SeriesLegendMode.Series
			line.InflateMargins = True
			line.MarkerStyle.Visible = False
			line.Name = "Line Series"
			line.UseXValues = True
			line.UseZValues = True

			ComplexityNumericUpDown.Value = 20
			WindingsNumericUpDown.Value = 5

			ChangeData()

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Sub ChangeData()
			If nChartControl1 Is Nothing Then
				Return
			End If

			' add xy values
			Dim fSpringHeight As Single = 20
			Dim nWindings As Integer = CInt(Math.Truncate(WindingsNumericUpDown.Value))
			Dim nComplexity As Integer = CInt(Math.Truncate(ComplexityNumericUpDown.Value))

			Dim dCurrentAngle As Double = 0
			Dim dCurrentHeight As Double = 0
			Dim dX, dY, dZ As Double

			Dim fHeightStep As Single = fSpringHeight / (nWindings * nComplexity)
			Dim fAngleStepRad As Single = CSng(((360 \ nComplexity) * 3.1415926535F) / 180.0F)

			Dim line As NLineSeries = CType(nChartControl1.Charts(0).Series(0), NLineSeries)
			line.ClearDataPoints()

			Do While nWindings > 0
				For i As Integer = 0 To nComplexity - 1
					dZ = Math.Cos(dCurrentAngle) * (dCurrentHeight)
					dX = Math.Sin(dCurrentAngle) * (dCurrentHeight)
					dY = dCurrentHeight

					line.Values.Add(dY)
					line.XValues.Add(dX)
					line.ZValues.Add(dZ)

					dCurrentAngle += fAngleStepRad
					dCurrentHeight += fHeightStep
				Next i

				nWindings -= 1
			Loop

			nChartControl1.Refresh()
		End Sub

		Private Sub ComplexityNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComplexityNumericUpDown.ValueChanged
			ChangeData()
		End Sub
		Private Sub WindingsNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WindingsNumericUpDown.ValueChanged
			ChangeData()
		End Sub
	End Class
End Namespace
