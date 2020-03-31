Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.Chart
Imports Nevron.Chart.Windows
Imports Nevron.GraphicsCore


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NStandardPieUC
		Inherits NExampleBaseUC
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private WithEvents PieShapeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents PieLabelModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents BeginAngleScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents TotalAngleScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents ArrowLengthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents ArrowPointerLengthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents EdgePercentScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents InnerRadiusScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents OuterRadiusScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label10 As Label
		Private WithEvents ConnectorLengthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private label11 As Label
		Private WithEvents LeadOffLengthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
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
			Me.PieShapeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.BeginAngleScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label5 = New System.Windows.Forms.Label()
			Me.TotalAngleScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label6 = New System.Windows.Forms.Label()
			Me.PieLabelModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.ArrowLengthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label8 = New System.Windows.Forms.Label()
			Me.ArrowPointerLengthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.EdgePercentScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label3 = New System.Windows.Forms.Label()
			Me.InnerRadiusScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.OuterRadiusScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label9 = New System.Windows.Forms.Label()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label10 = New System.Windows.Forms.Label()
			Me.ConnectorLengthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label11 = New System.Windows.Forms.Label()
			Me.LeadOffLengthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nGroupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.groupBox1.SuspendLayout()
			Me.nGroupBox1.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			Me.nGroupBox3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(12, 21)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(178, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Shape:"
			' 
			' PieShapeCombo
			' 
			Me.PieShapeCombo.ListProperties.CheckBoxDataMember = ""
			Me.PieShapeCombo.ListProperties.DataSource = Nothing
			Me.PieShapeCombo.ListProperties.DisplayMember = ""
			Me.PieShapeCombo.Location = New System.Drawing.Point(12, 37)
			Me.PieShapeCombo.Name = "PieShapeCombo"
			Me.PieShapeCombo.Size = New System.Drawing.Size(151, 21)
			Me.PieShapeCombo.TabIndex = 1
			'			Me.PieShapeCombo.SelectedIndexChanged += New System.EventHandler(Me.PieShapeCombo_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(12, 20)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(178, 15)
			Me.label4.TabIndex = 6
			Me.label4.Text = "Begin Angle:"
			' 
			' BeginAngleScroll
			' 
			Me.BeginAngleScroll.Location = New System.Drawing.Point(12, 37)
			Me.BeginAngleScroll.Maximum = 370
			Me.BeginAngleScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.BeginAngleScroll.Name = "BeginAngleScroll"
			Me.BeginAngleScroll.Size = New System.Drawing.Size(151, 16)
			Me.BeginAngleScroll.TabIndex = 7
			'			Me.BeginAngleScroll.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.BeginAngleScroll_Scroll);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(12, 67)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(178, 15)
			Me.label5.TabIndex = 8
			Me.label5.Text = "Total Angle:"
			' 
			' TotalAngleScroll
			' 
			Me.TotalAngleScroll.Location = New System.Drawing.Point(12, 82)
			Me.TotalAngleScroll.Maximum = 370
			Me.TotalAngleScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.TotalAngleScroll.Name = "TotalAngleScroll"
			Me.TotalAngleScroll.Size = New System.Drawing.Size(151, 16)
			Me.TotalAngleScroll.TabIndex = 9
			'			Me.TotalAngleScroll.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.TotalAngleScroll_Scroll);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(12, 22)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(153, 16)
			Me.label6.TabIndex = 10
			Me.label6.Text = "Label Mode:"
			' 
			' PieLabelModeCombo
			' 
			Me.PieLabelModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.PieLabelModeCombo.ListProperties.DataSource = Nothing
			Me.PieLabelModeCombo.ListProperties.DisplayMember = ""
			Me.PieLabelModeCombo.Location = New System.Drawing.Point(12, 41)
			Me.PieLabelModeCombo.Name = "PieLabelModeCombo"
			Me.PieLabelModeCombo.Size = New System.Drawing.Size(153, 21)
			Me.PieLabelModeCombo.TabIndex = 11
			'			Me.PieLabelModeCombo.SelectedIndexChanged += New System.EventHandler(Me.PieLabelModeCombo_SelectedIndexChanged);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(12, 69)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(153, 16)
			Me.label7.TabIndex = 15
			Me.label7.Text = "Arrow Length:"
			' 
			' ArrowLengthScroll
			' 
			Me.ArrowLengthScroll.LargeChange = 1
			Me.ArrowLengthScroll.Location = New System.Drawing.Point(12, 86)
			Me.ArrowLengthScroll.Maximum = 20
			Me.ArrowLengthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.ArrowLengthScroll.Name = "ArrowLengthScroll"
			Me.ArrowLengthScroll.Size = New System.Drawing.Size(153, 16)
			Me.ArrowLengthScroll.TabIndex = 16
			'			Me.ArrowLengthScroll.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.ArrowLengthScroll_Scroll);
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(12, 112)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(153, 15)
			Me.label8.TabIndex = 17
			Me.label8.Text = "Pointer Length:"
			' 
			' ArrowPointerLengthScroll
			' 
			Me.ArrowPointerLengthScroll.LargeChange = 1
			Me.ArrowPointerLengthScroll.Location = New System.Drawing.Point(12, 127)
			Me.ArrowPointerLengthScroll.Maximum = 20
			Me.ArrowPointerLengthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.ArrowPointerLengthScroll.Name = "ArrowPointerLengthScroll"
			Me.ArrowPointerLengthScroll.Size = New System.Drawing.Size(153, 16)
			Me.ArrowPointerLengthScroll.TabIndex = 18
			'			Me.ArrowPointerLengthScroll.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.ArrowPointerLengthScroll_Scroll);
			' 
			' EdgePercentScroll
			' 
			Me.EdgePercentScroll.Enabled = False
			Me.EdgePercentScroll.LargeChange = 1
			Me.EdgePercentScroll.Location = New System.Drawing.Point(12, 82)
			Me.EdgePercentScroll.Maximum = 51
			Me.EdgePercentScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.EdgePercentScroll.Name = "EdgePercentScroll"
			Me.EdgePercentScroll.Size = New System.Drawing.Size(151, 16)
			Me.EdgePercentScroll.TabIndex = 23
			'			Me.EdgePercentScroll.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.PieEdgeScrollBar_Scroll);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(12, 66)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(178, 15)
			Me.label3.TabIndex = 22
			Me.label3.Text = "Edge Percent:"
			' 
			' InnerRadiusScroll
			' 
			Me.InnerRadiusScroll.LargeChange = 1
			Me.InnerRadiusScroll.Location = New System.Drawing.Point(12, 78)
			Me.InnerRadiusScroll.Maximum = 60
			Me.InnerRadiusScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.InnerRadiusScroll.Name = "InnerRadiusScroll"
			Me.InnerRadiusScroll.Size = New System.Drawing.Size(151, 16)
			Me.InnerRadiusScroll.TabIndex = 27
			'			Me.InnerRadiusScroll.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.InnerRadiusScroll_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(12, 63)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(178, 15)
			Me.label2.TabIndex = 26
			Me.label2.Text = "Inner Radius:"
			' 
			' OuterRadiusScroll
			' 
			Me.OuterRadiusScroll.LargeChange = 1
			Me.OuterRadiusScroll.Location = New System.Drawing.Point(12, 39)
			Me.OuterRadiusScroll.Maximum = 60
			Me.OuterRadiusScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.OuterRadiusScroll.Name = "OuterRadiusScroll"
			Me.OuterRadiusScroll.Size = New System.Drawing.Size(151, 16)
			Me.OuterRadiusScroll.TabIndex = 25
			'			Me.OuterRadiusScroll.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.OuterRadiusScroll_ValueChanged);
			' 
			' label9
			' 
			Me.label9.Location = New System.Drawing.Point(12, 22)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(178, 16)
			Me.label9.TabIndex = 24
			Me.label9.Text = "Outer Radius:"
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.OuterRadiusScroll)
			Me.groupBox1.Controls.Add(Me.label9)
			Me.groupBox1.Controls.Add(Me.InnerRadiusScroll)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Location = New System.Drawing.Point(3, 117)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(177, 101)
			Me.groupBox1.TabIndex = 30
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Pie Dimensions"
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.label10)
			Me.nGroupBox1.Controls.Add(Me.ConnectorLengthScroll)
			Me.nGroupBox1.Controls.Add(Me.label11)
			Me.nGroupBox1.Controls.Add(Me.LeadOffLengthScroll)
			Me.nGroupBox1.Controls.Add(Me.PieLabelModeCombo)
			Me.nGroupBox1.Controls.Add(Me.label6)
			Me.nGroupBox1.Controls.Add(Me.label7)
			Me.nGroupBox1.Controls.Add(Me.ArrowLengthScroll)
			Me.nGroupBox1.Controls.Add(Me.label8)
			Me.nGroupBox1.Controls.Add(Me.ArrowPointerLengthScroll)
			Me.nGroupBox1.Location = New System.Drawing.Point(3, 228)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(177, 241)
			Me.nGroupBox1.TabIndex = 31
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Pie Labels"
			' 
			' label10
			' 
			Me.label10.Location = New System.Drawing.Point(11, 155)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(153, 16)
			Me.label10.TabIndex = 19
			Me.label10.Text = "Label Connector Length:"
			' 
			' ConnectorLengthScroll
			' 
			Me.ConnectorLengthScroll.LargeChange = 1
			Me.ConnectorLengthScroll.Location = New System.Drawing.Point(11, 172)
			Me.ConnectorLengthScroll.Maximum = 50
			Me.ConnectorLengthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.ConnectorLengthScroll.Name = "ConnectorLengthScroll"
			Me.ConnectorLengthScroll.Size = New System.Drawing.Size(153, 16)
			Me.ConnectorLengthScroll.TabIndex = 20
			'			Me.ConnectorLengthScroll.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.ConnectorLengthScroll_ValueChanged);
			' 
			' label11
			' 
			Me.label11.Location = New System.Drawing.Point(11, 198)
			Me.label11.Name = "label11"
			Me.label11.Size = New System.Drawing.Size(153, 15)
			Me.label11.TabIndex = 21
			Me.label11.Text = "Lead-off Arrow Length:"
			' 
			' LeadOffLengthScroll
			' 
			Me.LeadOffLengthScroll.LargeChange = 1
			Me.LeadOffLengthScroll.Location = New System.Drawing.Point(11, 213)
			Me.LeadOffLengthScroll.Maximum = 50
			Me.LeadOffLengthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.LeadOffLengthScroll.Name = "LeadOffLengthScroll"
			Me.LeadOffLengthScroll.Size = New System.Drawing.Size(153, 16)
			Me.LeadOffLengthScroll.TabIndex = 22
			'			Me.LeadOffLengthScroll.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.LeadOffLengthScroll_ValueChanged);
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.TotalAngleScroll)
			Me.nGroupBox2.Controls.Add(Me.label4)
			Me.nGroupBox2.Controls.Add(Me.BeginAngleScroll)
			Me.nGroupBox2.Controls.Add(Me.label5)
			Me.nGroupBox2.Location = New System.Drawing.Point(3, 472)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(177, 105)
			Me.nGroupBox2.TabIndex = 31
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Angles"
			' 
			' nGroupBox3
			' 
			Me.nGroupBox3.Controls.Add(Me.PieShapeCombo)
			Me.nGroupBox3.Controls.Add(Me.label1)
			Me.nGroupBox3.Controls.Add(Me.label3)
			Me.nGroupBox3.Controls.Add(Me.EdgePercentScroll)
			Me.nGroupBox3.Location = New System.Drawing.Point(3, 3)
			Me.nGroupBox3.Name = "nGroupBox3"
			Me.nGroupBox3.Size = New System.Drawing.Size(177, 109)
			Me.nGroupBox3.TabIndex = 32
			Me.nGroupBox3.TabStop = False
			Me.nGroupBox3.Text = "Pie Shape"
			' 
			' NStandardPieUC
			' 
			Me.Controls.Add(Me.nGroupBox3)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NStandardPieUC"
			Me.Size = New System.Drawing.Size(180, 585)
			Me.groupBox1.ResumeLayout(False)
			Me.nGroupBox1.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			Me.nGroupBox3.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Clear()
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("3D Pie Chart Shapes")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup the legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.BottomRight)

			Dim pieChart As NPieChart = New NPieChart()
			pieChart.Enable3D = True

			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(pieChart)

			Dim ls As NPointLightSource = New NPointLightSource()
			ls.CoordinateMode = LightSourceCoordinateMode.Camera
			ls.Position = New NVector3DF(0, 0, 50)
			ls.Ambient = Color.FromArgb(30, 30, 30)
			ls.Diffuse = Color.FromArgb(180, 180, 180)
			ls.Specular = Color.FromArgb(100, 100, 100)

			pieChart.LightModel.LightSources.Clear()
			pieChart.LightModel.LightSources.Add(ls)

			pieChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated)
			pieChart.Depth = 10
			pieChart.DisplayOnLegend = nChartControl1.Legends(0)
			pieChart.Location = New NPointL(New NLength(20, NRelativeUnit.ParentPercentage), New NLength(20, NRelativeUnit.ParentPercentage))
			pieChart.Size = New NSizeL(New NLength(60, NRelativeUnit.ParentPercentage), New NLength(60, NRelativeUnit.ParentPercentage))

			Dim pieSeries As NPieSeries = CType(pieChart.Series.Add(SeriesType.Pie), NPieSeries)
			pieSeries.BorderStyle.Color = Color.LemonChiffon
			pieChart.InnerRadius = New NLength(20, NRelativeUnit.ParentPercentage)
			pieSeries.DataLabelStyle.ArrowLength = New NLength(10, NGraphicsUnit.Point)
			pieSeries.DataLabelStyle.ArrowPointerLength = New NLength(0, NGraphicsUnit.Point)

			pieSeries.Legend.Mode = SeriesLegendMode.DataPoints
			pieSeries.Legend.Format = "<label> <percent>"

			pieSeries.AddDataPoint(New NDataPoint(24, "Cars", New NColorFillStyle(Color.FromArgb(169, 121, 11))))
			pieSeries.AddDataPoint(New NDataPoint(18, "Airplanes", New NColorFillStyle(Color.FromArgb(157, 157, 92))))
			pieSeries.AddDataPoint(New NDataPoint(32, "Trains", New NColorFillStyle(Color.FromArgb(98, 152, 92))))
			pieSeries.AddDataPoint(New NDataPoint(23, "Ships", New NColorFillStyle(Color.FromArgb(111, 134, 181))))
			pieSeries.AddDataPoint(New NDataPoint(19, "Buses", New NColorFillStyle(Color.FromArgb(179, 63, 92))))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			PieShapeCombo.FillFromEnum(GetType(PieStyle))
			PieShapeCombo.SelectedIndex = CInt(Fix(PieStyle.Ring))

			PieLabelModeCombo.FillFromEnum(GetType(PieLabelMode))
			PieLabelModeCombo.SelectedIndex = 0

			EdgePercentScroll.Value = CInt(Fix(pieSeries.PieEdgePercent))
			OuterRadiusScroll.Value = CInt(Fix(pieChart.Radius.Value))
			InnerRadiusScroll.Value = CInt(Fix(pieChart.InnerRadius.Value))

			ArrowLengthScroll.Value = CInt(Fix(pieSeries.DataLabelStyle.ArrowLength.Value))
			ArrowPointerLengthScroll.Value = CInt(Fix(pieSeries.DataLabelStyle.ArrowPointerLength.Value))
			ConnectorLengthScroll.Value = CInt(Fix(pieSeries.ConnectorLength.Value))
			LeadOffLengthScroll.Value = CInt(Fix(pieSeries.LeadOffArrowLength.Value))

			BeginAngleScroll.Value = CInt(Fix(pieChart.BeginAngle))
			TotalAngleScroll.Value = CInt(Fix(pieChart.TotalAngle))
		End Sub

		Private Sub PieShapeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PieShapeCombo.SelectedIndexChanged
			Dim pie As NPieSeries = CType(nChartControl1.Charts(0).Series(0), NPieSeries)

			pie.PieStyle = CType(PieShapeCombo.SelectedIndex, PieStyle)

			Select Case pie.PieStyle
				Case PieStyle.Pie, PieStyle.Ring, PieStyle.Torus
					EdgePercentScroll.Enabled = False

				Case PieStyle.SmoothEdgePie, PieStyle.SmoothEdgeRing, PieStyle.CutEdgePie, PieStyle.CutEdgeRing
					EdgePercentScroll.Enabled = True

				Case Else
					Debug.Assert(False)
			End Select

			Select Case pie.PieStyle
				Case PieStyle.Pie, PieStyle.SmoothEdgePie, PieStyle.CutEdgePie
					InnerRadiusScroll.Enabled = False

				Case PieStyle.Ring, PieStyle.Torus, PieStyle.SmoothEdgeRing, PieStyle.CutEdgeRing
					InnerRadiusScroll.Enabled = True

				Case Else
					Debug.Assert(False)
			End Select

			nChartControl1.Refresh()
		End Sub
		Private Sub BeginAngleScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles BeginAngleScroll.ValueChanged
			Dim pie As NPieChart = CType(nChartControl1.Charts(0), NPieChart)
			pie.BeginAngle = BeginAngleScroll.Value
			nChartControl1.Refresh()
		End Sub
		Private Sub TotalAngleScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles TotalAngleScroll.ValueChanged
			Dim pie As NPieChart = CType(nChartControl1.Charts(0), NPieChart)
			pie.TotalAngle = TotalAngleScroll.Value
			nChartControl1.Refresh()
		End Sub
		Private Sub PieLabelModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PieLabelModeCombo.SelectedIndexChanged
			Dim pie As NPieSeries = CType(nChartControl1.Charts(0).Series(0), NPieSeries)

			pie.LabelMode = CType(PieLabelModeCombo.SelectedIndex, PieLabelMode)

			Select Case pie.LabelMode
				Case PieLabelMode.Center
					ArrowLengthScroll.Enabled = False
					ArrowPointerLengthScroll.Enabled = False
					ConnectorLengthScroll.Enabled = False
					LeadOffLengthScroll.Enabled = False

				Case PieLabelMode.Rim, PieLabelMode.Spider
					ArrowLengthScroll.Enabled = True
					ArrowPointerLengthScroll.Enabled = True
					ConnectorLengthScroll.Enabled = False
					LeadOffLengthScroll.Enabled = False

				Case PieLabelMode.SpiderNoOverlap
					ArrowLengthScroll.Enabled = False
					ArrowPointerLengthScroll.Enabled = False
					ConnectorLengthScroll.Enabled = True
					LeadOffLengthScroll.Enabled = True
			End Select

			nChartControl1.Refresh()
		End Sub
		Private Sub ArrowLengthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles ArrowLengthScroll.ValueChanged
			Dim pie As NPieSeries = CType(nChartControl1.Charts(0).Series(0), NPieSeries)
			pie.DataLabelStyle.ArrowLength = New NLength(ArrowLengthScroll.Value, NGraphicsUnit.Point)
			nChartControl1.Refresh()
		End Sub
		Private Sub ArrowPointerLengthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles ArrowPointerLengthScroll.ValueChanged
			Dim pie As NPieSeries = CType(nChartControl1.Charts(0).Series(0), NPieSeries)
			pie.DataLabelStyle.ArrowPointerLength = New NLength(ArrowPointerLengthScroll.Value, NGraphicsUnit.Point)
			nChartControl1.Refresh()
		End Sub
		Private Sub ConnectorLengthScroll_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles ConnectorLengthScroll.ValueChanged
			Dim pie As NPieSeries = CType(nChartControl1.Charts(0).Series(0), NPieSeries)
			pie.ConnectorLength = New NLength(ConnectorLengthScroll.Value, NGraphicsUnit.Point)
			nChartControl1.Refresh()
		End Sub
		Private Sub LeadOffLengthScroll_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles LeadOffLengthScroll.ValueChanged
			Dim pie As NPieSeries = CType(nChartControl1.Charts(0).Series(0), NPieSeries)
			pie.LeadOffArrowLength = New NLength(LeadOffLengthScroll.Value, NGraphicsUnit.Point)
			nChartControl1.Refresh()
		End Sub
		Private Sub PieEdgeScrollBar_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles EdgePercentScroll.ValueChanged
			Dim pie As NPieSeries = CType(nChartControl1.Charts(0).Series(0), NPieSeries)
			pie.PieEdgePercent = EdgePercentScroll.Value
			nChartControl1.Refresh()
		End Sub
		Private Sub OuterRadiusScroll_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles OuterRadiusScroll.ValueChanged
			Dim pie As NPieChart = CType(nChartControl1.Charts(0), NPieChart)
			pie.Radius = New NLength(OuterRadiusScroll.Value, NRelativeUnit.ParentPercentage)
			nChartControl1.Refresh()
		End Sub
		Private Sub InnerRadiusScroll_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles InnerRadiusScroll.ValueChanged
			Dim pie As NPieChart = CType(nChartControl1.Charts(0), NPieChart)
			pie.InnerRadius = New NLength(InnerRadiusScroll.Value, NRelativeUnit.ParentPercentage)
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace