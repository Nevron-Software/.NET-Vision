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
	Public Class NSeriesMarkerAttributeUC
		Inherits NExampleBaseUC

		Private m_MarkerStyle As NMarkerStyle
		Private m_Line As NLineSeries
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private WithEvents StyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents AutoDepth As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents VisibleCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents MarkerColor As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents MarkerBorderColor As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents WidthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents HeightScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents DepthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents LineDepthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents SelectMarkerCombo As Nevron.UI.WinForm.Controls.NComboBox
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
			Me.StyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.AutoDepth = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.WidthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.HeightScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.DepthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.LineDepthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.VisibleCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.MarkerColor = New Nevron.UI.WinForm.Controls.NButton()
			Me.MarkerBorderColor = New Nevron.UI.WinForm.Controls.NButton()
			Me.SelectMarkerCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(9, 299)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(160, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Style:"
			' 
			' StyleCombo
			' 
			Me.StyleCombo.Location = New System.Drawing.Point(9, 318)
			Me.StyleCombo.Name = "StyleCombo"
			Me.StyleCombo.Size = New System.Drawing.Size(160, 21)
			Me.StyleCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StyleCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			' 
			' AutoDepth
			' 
			Me.AutoDepth.Location = New System.Drawing.Point(9, 168)
			Me.AutoDepth.Name = "AutoDepth"
			Me.AutoDepth.Size = New System.Drawing.Size(160, 20)
			Me.AutoDepth.TabIndex = 2
			Me.AutoDepth.Text = "Auto Depth"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AutoDepth.CheckedChanged += new System.EventHandler(this.AutoDepth_CheckedChanged);
			' 
			' WidthScroll
			' 
			Me.WidthScroll.LargeChange = 1
			Me.WidthScroll.Location = New System.Drawing.Point(9, 92)
			Me.WidthScroll.Name = "WidthScroll"
			Me.WidthScroll.Size = New System.Drawing.Size(160, 16)
			Me.WidthScroll.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WidthScroll_Scroll);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 74)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(160, 16)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Width:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(9, 121)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(160, 16)
			Me.label3.TabIndex = 5
			Me.label3.Text = "Height:"
			' 
			' HeightScroll
			' 
			Me.HeightScroll.LargeChange = 1
			Me.HeightScroll.Location = New System.Drawing.Point(9, 139)
			Me.HeightScroll.Name = "HeightScroll"
			Me.HeightScroll.Size = New System.Drawing.Size(160, 16)
			Me.HeightScroll.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HeightScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.HeightScroll_Scroll);
			' 
			' DepthScroll
			' 
			Me.DepthScroll.LargeChange = 1
			Me.DepthScroll.Location = New System.Drawing.Point(9, 216)
			Me.DepthScroll.Name = "DepthScroll"
			Me.DepthScroll.Size = New System.Drawing.Size(160, 16)
			Me.DepthScroll.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.DepthScroll_Scroll);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(9, 198)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(160, 16)
			Me.label4.TabIndex = 8
			Me.label4.Text = "Depth:"
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(9, 247)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(160, 16)
			Me.label5.TabIndex = 10
			Me.label5.Text = "Line Depth %:"
			' 
			' LineDepthScroll
			' 
			Me.LineDepthScroll.Location = New System.Drawing.Point(9, 264)
			Me.LineDepthScroll.Name = "LineDepthScroll"
			Me.LineDepthScroll.Size = New System.Drawing.Size(160, 16)
			Me.LineDepthScroll.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LineDepthScroll_Scroll);
			' 
			' VisibleCheck
			' 
			Me.VisibleCheck.Location = New System.Drawing.Point(9, 49)
			Me.VisibleCheck.Name = "VisibleCheck"
			Me.VisibleCheck.Size = New System.Drawing.Size(160, 18)
			Me.VisibleCheck.TabIndex = 11
			Me.VisibleCheck.Text = "Visible"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.VisibleCheck.CheckedChanged += new System.EventHandler(this.Visible_CheckedChanged);
			' 
			' MarkerColor
			' 
			Me.MarkerColor.Location = New System.Drawing.Point(9, 369)
			Me.MarkerColor.Name = "MarkerColor"
			Me.MarkerColor.Size = New System.Drawing.Size(160, 23)
			Me.MarkerColor.TabIndex = 12
			Me.MarkerColor.Text = "Marker Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerColor.Click += new System.EventHandler(this.MarkerColor_Click);
			' 
			' MarkerBorderColor
			' 
			Me.MarkerBorderColor.Location = New System.Drawing.Point(9, 400)
			Me.MarkerBorderColor.Name = "MarkerBorderColor"
			Me.MarkerBorderColor.Size = New System.Drawing.Size(160, 23)
			Me.MarkerBorderColor.TabIndex = 13
			Me.MarkerBorderColor.Text = "Marker Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerBorderColor.Click += new System.EventHandler(this.MarkerBorderColor_Click);
			' 
			' SelectMarkerCombo
			' 
			Me.SelectMarkerCombo.Location = New System.Drawing.Point(9, 8)
			Me.SelectMarkerCombo.Name = "SelectMarkerCombo"
			Me.SelectMarkerCombo.Size = New System.Drawing.Size(160, 21)
			Me.SelectMarkerCombo.TabIndex = 14
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SelectMarkerCombo.SelectedIndexChanged += new System.EventHandler(this.SelectMarkerCombo_SelectedIndexChanged);
			' 
			' NSeriesAttribsMarkersUC
			' 
			Me.Controls.Add(Me.SelectMarkerCombo)
			Me.Controls.Add(Me.MarkerBorderColor)
			Me.Controls.Add(Me.MarkerColor)
			Me.Controls.Add(Me.VisibleCheck)
			Me.Controls.Add(Me.LineDepthScroll)
			Me.Controls.Add(Me.DepthScroll)
			Me.Controls.Add(Me.HeightScroll)
			Me.Controls.Add(Me.WidthScroll)
			Me.Controls.Add(Me.AutoDepth)
			Me.Controls.Add(Me.StyleCombo)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.label2)
			Me.Name = "NSeriesAttribsMarkersUC"
			Me.Size = New System.Drawing.Size(180, 437)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Series Marker Attribute")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Enable3D = True

			' add interlaced stripe to the Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator).StripStyles.Add(stripStyle)

			chart.Axis(StandardAxis.Depth).Visible = False

			m_Line = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line.LineSegmentShape = LineSegmentShape.Tape
			m_Line.InflateMargins = True
			m_Line.DepthPercent = 50
			m_Line.Legend.Mode = SeriesLegendMode.DataPoints
			m_Line.Name = "Line Series"
			m_Line.Values.FillRandom(Random, 6)
			m_Line.DataLabelStyle.Visible = False
			m_Line.ShadowStyle.Type = ShadowType.GaussianBlur
			m_Line.ShadowStyle.Offset = New NPointL(2, 2)
			m_Line.ShadowStyle.Color = Color.FromArgb(88, 0, 0, 0)
			m_Line.ShadowStyle.FadeLength = New NLength(5)
			m_Line.MarkerStyle.Visible = True

			Dim marker As New NMarkerStyle()
			marker.FillStyle = New NColorFillStyle(Color.Red)
			marker.PointShape = PointShape.Cylinder
			marker.Visible = True
			m_Line.MarkerStyles(3) = marker

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			StyleCombo.FillFromEnum(GetType(PointShape))

			SelectMarkerCombo.Items.Add("Edit Default Marker")
			SelectMarkerCombo.Items.Add("Edit Marker #3")
			SelectMarkerCombo.SelectedIndex = 0

			VisibleCheck.Checked = True
		End Sub

		Private Sub StyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StyleCombo.SelectedIndexChanged
			m_MarkerStyle.PointShape = CType(StyleCombo.SelectedIndex, PointShape)
			nChartControl1.Refresh()
		End Sub

		Private Sub AutoDepth_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoDepth.CheckedChanged
			DepthScroll.Enabled = Not AutoDepth.Checked

			m_MarkerStyle.AutoDepth = AutoDepth.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub DepthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles DepthScroll.ValueChanged
			m_MarkerStyle.Depth = New NLength(CSng(DepthScroll.Value) / 10.0F, NRelativeUnit.ParentPercentage)
			nChartControl1.Refresh()
		End Sub

		Private Sub HeightScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles HeightScroll.ValueChanged
			m_MarkerStyle.Height = New NLength(CSng(HeightScroll.Value) / 20.0F, NRelativeUnit.ParentPercentage)
			nChartControl1.Refresh()
		End Sub

		Private Sub WidthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles WidthScroll.ValueChanged
			m_MarkerStyle.Width = New NLength(CSng(WidthScroll.Value) / 20.0F, NRelativeUnit.ParentPercentage)
			nChartControl1.Refresh()
		End Sub

		Private Sub LineDepthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles LineDepthScroll.ValueChanged
			m_Line.DepthPercent = LineDepthScroll.Value
			nChartControl1.Refresh()
		End Sub

		Private Sub Visible_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VisibleCheck.CheckedChanged
			m_MarkerStyle.Visible = VisibleCheck.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub MarkerColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MarkerColor.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_MarkerStyle.FillStyle, fillStyleResult) Then
				m_MarkerStyle.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub MarkerBorderColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MarkerBorderColor.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_MarkerStyle.BorderStyle, strokeStyleResult) Then
				m_MarkerStyle.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub SelectMarkerCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectMarkerCombo.SelectedIndexChanged
			Select Case SelectMarkerCombo.SelectedIndex
				Case 0
					m_MarkerStyle = m_Line.MarkerStyle

				Case 1
					m_MarkerStyle = DirectCast(m_Line.MarkerStyles(3), NMarkerStyle)
			End Select

			VisibleCheck.Checked = m_MarkerStyle.Visible
			WidthScroll.Value = CInt(Math.Truncate(m_MarkerStyle.Width.Value * 20))
			HeightScroll.Value = CInt(Math.Truncate(m_MarkerStyle.Height.Value * 20))
			DepthScroll.Value = CInt(Math.Truncate(m_MarkerStyle.Depth.Value * 10))
			AutoDepth.Checked = m_MarkerStyle.AutoDepth
			StyleCombo.SelectedIndex = CInt(m_MarkerStyle.PointShape)
		End Sub
	End Class
End Namespace
