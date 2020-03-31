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
	Public Class NAxisValueCrossingUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private WithEvents LeftAxisScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents BottomAxisScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private LeftAxisLabel As System.Windows.Forms.Label
		Private BottomAxisLabel As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private WithEvents LeftUsePositionCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents BottomUsePositionCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
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
			Me.LeftAxisScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.LeftAxisLabel = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.LeftUsePositionCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.BottomUsePositionCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.BottomAxisLabel = New System.Windows.Forms.Label()
			Me.BottomAxisScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' LeftAxisScroll
			' 
			Me.LeftAxisScroll.LargeChange = 1
			Me.LeftAxisScroll.Location = New System.Drawing.Point(8, 71)
			Me.LeftAxisScroll.Maximum = 20
			Me.LeftAxisScroll.Minimum = -20
			Me.LeftAxisScroll.Name = "LeftAxisScroll"
			Me.LeftAxisScroll.Size = New System.Drawing.Size(118, 16)
			Me.LeftAxisScroll.TabIndex = 0
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftAxisScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftAxisScroll_Scroll);
			' 
			' LeftAxisLabel
			' 
			Me.LeftAxisLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.LeftAxisLabel.Location = New System.Drawing.Point(133, 71)
			Me.LeftAxisLabel.Name = "LeftAxisLabel"
			Me.LeftAxisLabel.Size = New System.Drawing.Size(32, 17)
			Me.LeftAxisLabel.TabIndex = 2
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 51)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(147, 15)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Position Value:"
			' 
			' LeftUsePositionCheck
			' 
			Me.LeftUsePositionCheck.Location = New System.Drawing.Point(8, 19)
			Me.LeftUsePositionCheck.Name = "LeftUsePositionCheck"
			Me.LeftUsePositionCheck.Size = New System.Drawing.Size(112, 20)
			Me.LeftUsePositionCheck.TabIndex = 6
			Me.LeftUsePositionCheck.Text = "Use Position"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftUsePositionCheck.CheckedChanged += new System.EventHandler(this.LeftUsePositionCheck_CheckedChanged);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.LeftAxisScroll)
			Me.groupBox1.Controls.Add(Me.LeftAxisLabel)
			Me.groupBox1.Controls.Add(Me.LeftUsePositionCheck)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(7, 7)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(176, 112)
			Me.groupBox1.TabIndex = 8
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Left Axis"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.BottomUsePositionCheck)
			Me.groupBox2.Controls.Add(Me.label4)
			Me.groupBox2.Controls.Add(Me.BottomAxisLabel)
			Me.groupBox2.Controls.Add(Me.BottomAxisScroll)
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(7, 128)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(176, 112)
			Me.groupBox2.TabIndex = 9
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Bottom Axis"
			' 
			' BottomUsePositionCheck
			' 
			Me.BottomUsePositionCheck.Location = New System.Drawing.Point(8, 19)
			Me.BottomUsePositionCheck.Name = "BottomUsePositionCheck"
			Me.BottomUsePositionCheck.Size = New System.Drawing.Size(91, 21)
			Me.BottomUsePositionCheck.TabIndex = 11
			Me.BottomUsePositionCheck.Text = "Use Position"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomUsePositionCheck.CheckedChanged += new System.EventHandler(this.BottomUsePositionCheck_CheckedChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 51)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(153, 16)
			Me.label4.TabIndex = 10
			Me.label4.Text = "Position Value:"
			' 
			' BottomAxisLabel
			' 
			Me.BottomAxisLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.BottomAxisLabel.Location = New System.Drawing.Point(133, 71)
			Me.BottomAxisLabel.Name = "BottomAxisLabel"
			Me.BottomAxisLabel.Size = New System.Drawing.Size(32, 17)
			Me.BottomAxisLabel.TabIndex = 9
			' 
			' BottomAxisScroll
			' 
			Me.BottomAxisScroll.LargeChange = 1
			Me.BottomAxisScroll.Location = New System.Drawing.Point(8, 71)
			Me.BottomAxisScroll.Maximum = 20
			Me.BottomAxisScroll.Minimum = -20
			Me.BottomAxisScroll.Name = "BottomAxisScroll"
			Me.BottomAxisScroll.Size = New System.Drawing.Size(118, 16)
			Me.BottomAxisScroll.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomAxisScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomAxisScroll_Scroll);
			' 
			' NAxisValueCrossingUC
			' 
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NAxisValueCrossingUC"
			Me.Size = New System.Drawing.Size(191, 250)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region


		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Axis Value Crossing <br/> <font size = '9pt'>Demonstrates how to use of the value cross anchor</font>")
			title.TextStyle.TextFormat = TextFormat.XML
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' turn off the legend
			nChartControl1.Legends(0).Mode = LegendMode.Disabled

			m_Chart = nChartControl1.Charts(0)
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights)

			' configure scales
			Dim yScaleConfigurator As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim yStripStyle As New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(40, Color.LightGray)), Nothing, True, 0, 0, 1, 1)
			yStripStyle.SetShowAtWall(ChartWallType.Back, True)
			yStripStyle.Interlaced = True
			yScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			yScaleConfigurator.StripStyles.Add(yStripStyle)

			Dim xScaleConfigurator As New NLinearScaleConfigurator()
			Dim xStripStyle As New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(40, Color.LightGray)), Nothing, True, 0, 0, 1, 1)
			xStripStyle.SetShowAtWall(ChartWallType.Back, True)
			xStripStyle.Interlaced = True
			xScaleConfigurator.StripStyles.Add(xStripStyle)
			xScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScaleConfigurator

			' cross X and Y axes
			m_Chart.Axis(StandardAxis.PrimaryX).Anchor = New NCrossAxisAnchor(AxisOrientation.Horizontal, New NValueAxisCrossing(m_Chart.Axis(StandardAxis.PrimaryY), 0))
			m_Chart.Axis(StandardAxis.PrimaryX).Anchor.RulerOrientation = RulerOrientation.Right
			m_Chart.Axis(StandardAxis.PrimaryY).Anchor = New NCrossAxisAnchor(AxisOrientation.Vertical, New NValueAxisCrossing(m_Chart.Axis(StandardAxis.PrimaryX), 0))

			m_Chart.Axis(StandardAxis.Depth).Visible = False
			m_Chart.Wall(ChartWallType.Floor).Visible = False
			m_Chart.Wall(ChartWallType.Left).Visible = False

			' setup bubble series
			Dim bubble As NBubbleSeries = CType(m_Chart.Series.Add(SeriesType.Bubble), NBubbleSeries)
			bubble.Name = "Bubble Series"
			bubble.InflateMargins = True
			bubble.DataLabelStyle.Visible = False
			bubble.UseXValues = True
			bubble.BubbleShape = PointShape.Sphere

			' fill with random data
			bubble.Values.FillRandomRange(Random, 10, -20, 20)
			bubble.XValues.FillRandomRange(Random, 10, -20, 20)
			bubble.Sizes.FillRandomRange(Random, 10, 1, 6)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			LeftAxisScroll.Minimum = -30
			LeftAxisScroll.Maximum = 30
			LeftAxisScroll.Value = 0

			BottomAxisScroll.Minimum = -30
			BottomAxisScroll.Maximum = 30
			BottomAxisScroll.Value = 0

			LeftAxisLabel.Text = LeftAxisScroll.Value.ToString()
			BottomAxisLabel.Text = BottomAxisScroll.Value.ToString()

			LeftUsePositionCheck.Checked = True
			BottomUsePositionCheck.Checked = True
		End Sub

		Private Sub LeftAxisScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles LeftAxisScroll.ValueChanged
			LeftAxisLabel.Text = LeftAxisScroll.Value.ToString()

			Dim posValue As Double = CDbl(LeftAxisScroll.Value)

			Dim crossAnchor As NCrossAxisAnchor = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).Anchor, NCrossAxisAnchor)

			If crossAnchor IsNot Nothing Then
				DirectCast(crossAnchor.Crossings(0), NValueAxisCrossing).Value = posValue
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BottomAxisScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles BottomAxisScroll.ValueChanged
			BottomAxisLabel.Text = BottomAxisScroll.Value.ToString()

			Dim posValue As Double = CDbl(BottomAxisScroll.Value)

			Dim crossAnchor As NCrossAxisAnchor = TryCast(m_Chart.Axis(StandardAxis.PrimaryX).Anchor, NCrossAxisAnchor)

			If crossAnchor IsNot Nothing Then
				DirectCast(crossAnchor.Crossings(0), NValueAxisCrossing).Value = posValue
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub LeftUsePositionCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftUsePositionCheck.CheckedChanged
			LeftAxisScroll.Enabled = LeftUsePositionCheck.Checked

			If LeftUsePositionCheck.Checked Then
				Dim posValue As Double = CDbl(LeftAxisScroll.Value)
				m_Chart.Axis(StandardAxis.PrimaryY).Anchor = New NCrossAxisAnchor(AxisOrientation.Vertical, New NValueAxisCrossing(m_Chart.Axis(StandardAxis.PrimaryX), posValue))
			Else
				m_Chart.Axis(StandardAxis.PrimaryY).Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, True)
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub BottomUsePositionCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BottomUsePositionCheck.CheckedChanged
			BottomAxisScroll.Enabled = BottomUsePositionCheck.Checked

			If BottomUsePositionCheck.Checked Then
				Dim posValue As Double = CDbl(BottomAxisScroll.Value)
				m_Chart.Axis(StandardAxis.PrimaryX).Anchor = New NCrossAxisAnchor(AxisOrientation.Horizontal, New NValueAxisCrossing(m_Chart.Axis(StandardAxis.PrimaryY), posValue))
				m_Chart.Axis(StandardAxis.PrimaryX).Anchor.RulerOrientation = RulerOrientation.Right
			Else
				m_Chart.Axis(StandardAxis.PrimaryX).Anchor = New NDockAxisAnchor(AxisDockZone.FrontBottom, True)
			End If

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace