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
	Public Class NRulerSizeUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_CustomAxisId As Integer
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents hScrollBar1 As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents hScrollBar2 As Nevron.UI.WinForm.Controls.NHScrollBar
		Private Scroll1BeginLabel As System.Windows.Forms.Label
		Private Scroll2BeginLabel As System.Windows.Forms.Label
		Private Scroll1EndLabel As System.Windows.Forms.Label
		Private Scroll2EndLabel As System.Windows.Forms.Label
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.hScrollBar1 = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.hScrollBar2 = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.Scroll1BeginLabel = New System.Windows.Forms.Label()
			Me.Scroll2BeginLabel = New System.Windows.Forms.Label()
			Me.Scroll1EndLabel = New System.Windows.Forms.Label()
			Me.Scroll2EndLabel = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(12, 11)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(141, 17)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Red Axis End Percent:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(12, 96)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(141, 17)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Blue Axis Begin Percent:"
			' 
			' hScrollBar1
			' 
			Me.hScrollBar1.LargeChange = 1
			Me.hScrollBar1.Location = New System.Drawing.Point(46, 37)
			Me.hScrollBar1.Name = "hScrollBar1"
			Me.hScrollBar1.Size = New System.Drawing.Size(106, 19)
			Me.hScrollBar1.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.hScrollBar1.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.hScrollBar1_Scroll);
			' 
			' hScrollBar2
			' 
			Me.hScrollBar2.LargeChange = 1
			Me.hScrollBar2.Location = New System.Drawing.Point(46, 121)
			Me.hScrollBar2.Name = "hScrollBar2"
			Me.hScrollBar2.Size = New System.Drawing.Size(106, 19)
			Me.hScrollBar2.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.hScrollBar2.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.hScrollBar2_Scroll);
			' 
			' Scroll1BeginLabel
			' 
			Me.Scroll1BeginLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.Scroll1BeginLabel.Location = New System.Drawing.Point(12, 38)
			Me.Scroll1BeginLabel.Name = "Scroll1BeginLabel"
			Me.Scroll1BeginLabel.Size = New System.Drawing.Size(28, 17)
			Me.Scroll1BeginLabel.TabIndex = 7
			Me.Scroll1BeginLabel.Text = "0"
			' 
			' Scroll2BeginLabel
			' 
			Me.Scroll2BeginLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.Scroll2BeginLabel.Location = New System.Drawing.Point(12, 123)
			Me.Scroll2BeginLabel.Name = "Scroll2BeginLabel"
			Me.Scroll2BeginLabel.Size = New System.Drawing.Size(28, 17)
			Me.Scroll2BeginLabel.TabIndex = 8
			' 
			' Scroll1EndLabel
			' 
			Me.Scroll1EndLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.Scroll1EndLabel.Location = New System.Drawing.Point(158, 38)
			Me.Scroll1EndLabel.Name = "Scroll1EndLabel"
			Me.Scroll1EndLabel.Size = New System.Drawing.Size(28, 17)
			Me.Scroll1EndLabel.TabIndex = 9
			' 
			' Scroll2EndLabel
			' 
			Me.Scroll2EndLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.Scroll2EndLabel.Location = New System.Drawing.Point(158, 122)
			Me.Scroll2EndLabel.Name = "Scroll2EndLabel"
			Me.Scroll2EndLabel.Size = New System.Drawing.Size(28, 17)
			Me.Scroll2EndLabel.TabIndex = 10
			Me.Scroll2EndLabel.Text = "100"
			' 
			' NRulerSizeUC
			' 
			Me.Controls.Add(Me.Scroll2EndLabel)
			Me.Controls.Add(Me.Scroll1EndLabel)
			Me.Controls.Add(Me.Scroll2BeginLabel)
			Me.Controls.Add(Me.Scroll1BeginLabel)
			Me.Controls.Add(Me.hScrollBar1)
			Me.Controls.Add(Me.hScrollBar2)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Name = "NRulerSizeUC"
			Me.Size = New System.Drawing.Size(202, 182)
			Me.ResumeLayout(False)

		End Sub
		#End Region


		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Axis Docking and Anchor Percentages<br/> <font size = '9pt'>Demonstrates how to dock axes without creating a new zone level</font>")
			title.TextStyle.TextFormat = TextFormat.XML
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' turn off the legend
			nChartControl1.Legends(0).Mode = LegendMode.Disabled

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.BoundsMode = BoundsMode.Fit

			' apply predefined lighting and projection
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' configure primary Y
			Dim primaryY As NAxis = m_Chart.Axis(StandardAxis.PrimaryY)
			primaryY.Anchor.BeginPercent = 0
			primaryY.Anchor.EndPercent = 30

			' configure secondary Y
			Dim secondaryY As NAxis = m_Chart.Axis(StandardAxis.SecondaryY)
			secondaryY.Visible = True
			secondaryY.Anchor.BeginPercent = 30
			secondaryY.Anchor.EndPercent = 70

			' configure a custom axis docked to the front left left chart zone
			Dim customY As NAxis = CType(m_Chart.Axes, NCartesianAxisCollection).AddCustomAxis(AxisOrientation.Vertical, AxisDockZone.FrontLeft)
			customY.Visible = True
			customY.Anchor.BeginPercent = 70
			customY.Anchor.EndPercent = 100
			m_CustomAxisId = customY.AxisId

			' Setup the line series
			Dim l1 As NLineSeries = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			l1.Values.FillRandom(Random, 5)
			l1.LineSegmentShape = LineSegmentShape.Tape
			l1.DataLabelStyle.Format = "<value>"

			Dim l2 As NLineSeries = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			l2.Values.FillRandom(Random, 5)
			l2.LineSegmentShape = LineSegmentShape.Tape
			l2.DataLabelStyle.Format = "<value>"
			l2.DisplayOnAxis(StandardAxis.SecondaryY, True)
			l2.DisplayOnAxis(StandardAxis.PrimaryY, False)

			Dim l3 As NLineSeries = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			l3.Values.FillRandom(Random, 5)
			l3.LineSegmentShape = LineSegmentShape.Tape
			l3.DataLabelStyle.Format = "<value>"
			l3.DisplayOnAxis(m_CustomAxisId, True)
			l3.DisplayOnAxis(StandardAxis.PrimaryY, False)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' set up the appearance of the axes according to the filling/stroke 
			' applied to the line series from the style sheet
			primaryY.ScaleConfigurator = ConfigureScale(l1.FillStyle, l1.BorderStyle.Color)
			secondaryY.ScaleConfigurator = ConfigureScale(l2.FillStyle, l2.BorderStyle.Color)
			customY.ScaleConfigurator = ConfigureScale(l3.FillStyle, l3.BorderStyle.Color)

			' init form controls
			hScrollBar1.Value = 30
			hScrollBar2.Value = 70

			hScrollBar2.Minimum = hScrollBar1.Value + 10
			hScrollBar1.Maximum = hScrollBar2.Value - 10

			Scroll2BeginLabel.Text = hScrollBar2.Minimum.ToString()
			Scroll1EndLabel.Text = hScrollBar1.Maximum.ToString()
		End Sub

		Private Function ConfigureScale(ByVal rulerFillStyle As NFillStyle, ByVal tickColor As Color) As NLinearScaleConfigurator
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As New NLinearScaleConfigurator()

			scale_Renamed.RulerStyle.FillStyle = DirectCast(rulerFillStyle.Clone(), NFillStyle)
			scale_Renamed.RulerStyle.Shape = ScaleLevelShape.Bar
			scale_Renamed.RulerStyle.Height = New NLength(5, NGraphicsUnit.Point)
			scale_Renamed.RulerStyle.BorderStyle.Color = tickColor
			scale_Renamed.OuterMajorTickStyle.LineStyle.Color = tickColor
			scale_Renamed.InnerMajorTickStyle.LineStyle.Color = tickColor
			scale_Renamed.MajorGridStyle.LineStyle.Color = tickColor

			Dim strip As New NScaleStripStyle()
			strip.StrokeStyle = Nothing
			strip.FillStyle = DirectCast(rulerFillStyle.Clone(), NFillStyle)
			strip.FillStyle.SetTransparencyPercent(80)
			strip.SetShowAtWall(ChartWallType.Back, True)
			strip.SetShowAtWall(ChartWallType.Left, True)
			scale_Renamed.StripStyles.Add(strip)

			scale_Renamed.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			scale_Renamed.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)

			Return scale_Renamed
		End Function

		Private Sub RecalcAxes()
			Dim bottomAxisEnd As Integer = hScrollBar1.Value
			Dim middleAxisBegin As Integer = hScrollBar1.Value
			Dim middleAxisEnd As Integer = hScrollBar2.Value
			Dim topAxisBegin As Integer = hScrollBar2.Value

			' red axis
			Dim axis As NAxis = m_Chart.Axis(StandardAxis.PrimaryY)
			axis.Anchor.EndPercent = hScrollBar1.Value

			' green axis
			axis = m_Chart.Axis(StandardAxis.SecondaryY)
			axis.Anchor.BeginPercent = middleAxisBegin
			axis.Anchor.EndPercent = middleAxisEnd

			' blue axis
			axis = m_Chart.Axis(m_CustomAxisId)
			axis.Anchor.BeginPercent = topAxisBegin

			nChartControl1.Refresh()
		End Sub

		Private Sub hScrollBar1_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles hScrollBar1.ValueChanged
			hScrollBar2.Minimum = hScrollBar1.Value + 10

			Scroll2BeginLabel.Text = hScrollBar2.Minimum.ToString()

			RecalcAxes()
		End Sub

		Private Sub hScrollBar2_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles hScrollBar2.ValueChanged
			hScrollBar1.Maximum = hScrollBar2.Value - 10

			Scroll1EndLabel.Text = hScrollBar1.Maximum.ToString()

			RecalcAxes()
		End Sub
	End Class
End Namespace
