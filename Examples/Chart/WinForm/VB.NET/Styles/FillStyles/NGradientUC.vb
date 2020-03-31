Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NGradientUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bar As NFloatBarSeries
		Private m_bSkipUpdate As Boolean
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private colorDialog1 As Nevron.UI.WinForm.Controls.NColorDialog
		Private WithEvents BeginColorBars As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents EndColorBars As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents EndColorWalls As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BeginColorWalls As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents EndColorBack As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BeginColorBack As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents StyleComboBars As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents VariantComboBars As Nevron.UI.WinForm.Controls.NComboBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents VariantComboWalls As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents StyleComboWalls As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents VariantComboBack As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents StyleComboBack As Nevron.UI.WinForm.Controls.NComboBox
		Private components As System.ComponentModel.IContainer = Nothing

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


		#Region "Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.EndColorBars = New Nevron.UI.WinForm.Controls.NButton()
			Me.BeginColorBars = New Nevron.UI.WinForm.Controls.NButton()
			Me.VariantComboBars = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.StyleComboBars = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.colorDialog1 = New Nevron.UI.WinForm.Controls.NColorDialog()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.EndColorWalls = New Nevron.UI.WinForm.Controls.NButton()
			Me.BeginColorWalls = New Nevron.UI.WinForm.Controls.NButton()
			Me.VariantComboWalls = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.StyleComboWalls = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.groupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.EndColorBack = New Nevron.UI.WinForm.Controls.NButton()
			Me.BeginColorBack = New Nevron.UI.WinForm.Controls.NButton()
			Me.VariantComboBack = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.StyleComboBack = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.groupBox3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.EndColorBars)
			Me.groupBox1.Controls.Add(Me.BeginColorBars)
			Me.groupBox1.Controls.Add(Me.VariantComboBars)
			Me.groupBox1.Controls.Add(Me.StyleComboBars)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Location = New System.Drawing.Point(7, 7)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(140, 177)
			Me.groupBox1.TabIndex = 0
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Bars"
			' 
			' EndColorBars
			' 
			Me.EndColorBars.Location = New System.Drawing.Point(9, 144)
			Me.EndColorBars.Name = "EndColorBars"
			Me.EndColorBars.Size = New System.Drawing.Size(121, 24)
			Me.EndColorBars.TabIndex = 5
			Me.EndColorBars.Text = "End Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EndColorBars.Click += new System.EventHandler(this.EndColorBars_Click);
			' 
			' BeginColorBars
			' 
			Me.BeginColorBars.Location = New System.Drawing.Point(9, 114)
			Me.BeginColorBars.Name = "BeginColorBars"
			Me.BeginColorBars.Size = New System.Drawing.Size(121, 24)
			Me.BeginColorBars.TabIndex = 4
			Me.BeginColorBars.Text = "Begin Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BeginColorBars.Click += new System.EventHandler(this.BeginColorBars_Click);
			' 
			' VariantComboBars
			' 
			Me.VariantComboBars.Location = New System.Drawing.Point(9, 82)
			Me.VariantComboBars.Name = "VariantComboBars"
			Me.VariantComboBars.Size = New System.Drawing.Size(121, 21)
			Me.VariantComboBars.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.VariantComboBars.SelectedIndexChanged += new System.EventHandler(this.VariantComboBars_SelectedIndexChanged);
			' 
			' StyleComboBars
			' 
			Me.StyleComboBars.Location = New System.Drawing.Point(9, 36)
			Me.StyleComboBars.Name = "StyleComboBars"
			Me.StyleComboBars.Size = New System.Drawing.Size(121, 21)
			Me.StyleComboBars.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StyleComboBars.SelectedIndexChanged += new System.EventHandler(this.StyleComboBars_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(9, 19)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(121, 21)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Gradient Style:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 65)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(121, 21)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Gradient Variant:"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.EndColorWalls)
			Me.groupBox2.Controls.Add(Me.BeginColorWalls)
			Me.groupBox2.Controls.Add(Me.VariantComboWalls)
			Me.groupBox2.Controls.Add(Me.StyleComboWalls)
			Me.groupBox2.Controls.Add(Me.label3)
			Me.groupBox2.Controls.Add(Me.label4)
			Me.groupBox2.Location = New System.Drawing.Point(7, 190)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(140, 177)
			Me.groupBox2.TabIndex = 1
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Walls"
			' 
			' EndColorWalls
			' 
			Me.EndColorWalls.Location = New System.Drawing.Point(9, 144)
			Me.EndColorWalls.Name = "EndColorWalls"
			Me.EndColorWalls.Size = New System.Drawing.Size(121, 24)
			Me.EndColorWalls.TabIndex = 5
			Me.EndColorWalls.Text = "End Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EndColorWalls.Click += new System.EventHandler(this.EndColorWalls_Click);
			' 
			' BeginColorWalls
			' 
			Me.BeginColorWalls.Location = New System.Drawing.Point(9, 114)
			Me.BeginColorWalls.Name = "BeginColorWalls"
			Me.BeginColorWalls.Size = New System.Drawing.Size(121, 24)
			Me.BeginColorWalls.TabIndex = 4
			Me.BeginColorWalls.Text = "Begin Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BeginColorWalls.Click += new System.EventHandler(this.BeginColorWalls_Click);
			' 
			' VariantComboWalls
			' 
			Me.VariantComboWalls.Location = New System.Drawing.Point(9, 82)
			Me.VariantComboWalls.Name = "VariantComboWalls"
			Me.VariantComboWalls.Size = New System.Drawing.Size(121, 21)
			Me.VariantComboWalls.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.VariantComboWalls.SelectedIndexChanged += new System.EventHandler(this.VariantComboWalls_SelectedIndexChanged);
			' 
			' StyleComboWalls
			' 
			Me.StyleComboWalls.Location = New System.Drawing.Point(9, 36)
			Me.StyleComboWalls.Name = "StyleComboWalls"
			Me.StyleComboWalls.Size = New System.Drawing.Size(121, 21)
			Me.StyleComboWalls.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StyleComboWalls.SelectedIndexChanged += new System.EventHandler(this.StyleComboWalls_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(9, 19)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(121, 21)
			Me.label3.TabIndex = 0
			Me.label3.Text = "Gradient Style:"
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(9, 65)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(121, 21)
			Me.label4.TabIndex = 2
			Me.label4.Text = "Gradient Variant:"
			' 
			' groupBox3
			' 
			Me.groupBox3.Controls.Add(Me.EndColorBack)
			Me.groupBox3.Controls.Add(Me.BeginColorBack)
			Me.groupBox3.Controls.Add(Me.VariantComboBack)
			Me.groupBox3.Controls.Add(Me.StyleComboBack)
			Me.groupBox3.Controls.Add(Me.label5)
			Me.groupBox3.Controls.Add(Me.label6)
			Me.groupBox3.Location = New System.Drawing.Point(7, 375)
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.Size = New System.Drawing.Size(140, 177)
			Me.groupBox3.TabIndex = 2
			Me.groupBox3.TabStop = False
			Me.groupBox3.Text = "Background"
			' 
			' EndColorBack
			' 
			Me.EndColorBack.Location = New System.Drawing.Point(9, 144)
			Me.EndColorBack.Name = "EndColorBack"
			Me.EndColorBack.Size = New System.Drawing.Size(121, 24)
			Me.EndColorBack.TabIndex = 5
			Me.EndColorBack.Text = "End Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EndColorBack.Click += new System.EventHandler(this.EndColorBack_Click);
			' 
			' BeginColorBack
			' 
			Me.BeginColorBack.Location = New System.Drawing.Point(9, 114)
			Me.BeginColorBack.Name = "BeginColorBack"
			Me.BeginColorBack.Size = New System.Drawing.Size(121, 24)
			Me.BeginColorBack.TabIndex = 4
			Me.BeginColorBack.Text = "Begin Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BeginColorBack.Click += new System.EventHandler(this.BeginColorBack_Click);
			' 
			' VariantComboBack
			' 
			Me.VariantComboBack.Location = New System.Drawing.Point(9, 82)
			Me.VariantComboBack.Name = "VariantComboBack"
			Me.VariantComboBack.Size = New System.Drawing.Size(121, 21)
			Me.VariantComboBack.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.VariantComboBack.SelectedIndexChanged += new System.EventHandler(this.VariantComboBack_SelectedIndexChanged);
			' 
			' StyleComboBack
			' 
			Me.StyleComboBack.Location = New System.Drawing.Point(9, 36)
			Me.StyleComboBack.Name = "StyleComboBack"
			Me.StyleComboBack.Size = New System.Drawing.Size(121, 21)
			Me.StyleComboBack.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StyleComboBack.SelectedIndexChanged += new System.EventHandler(this.StyleComboBack_SelectedIndexChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(9, 19)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(121, 21)
			Me.label5.TabIndex = 0
			Me.label5.Text = "Gradient Style:"
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(9, 65)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(121, 21)
			Me.label6.TabIndex = 2
			Me.label6.Text = "Gradient Variant:"
			' 
			' NGradientUC
			' 
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox3)
			Me.Name = "NGradientUC"
			Me.Size = New System.Drawing.Size(155, 559)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox3.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' Set background gradient
			nChartControl1.BackgroundStyle.FillStyle = New NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.DiagonalUp, GradientVariant.Variant3, Color.FromArgb(187,221,255), Color.White)

			' add label
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Gradient Fill Style")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Horizontal, GradientVariant.Variant1, Color.MidnightBlue, Color.PaleVioletRed)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			linearScale.MajorGridStyle.LineStyle.Color = Color.White
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			Dim ordinalScale As NOrdinalScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.LineStyle.Color = Color.White
			ordinalScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			m_Chart.Projection.Rotation = -14
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)

			' Setup walls
			Dim c As Color = Color.FromArgb(128, 128, 192)
			Dim wallGradientFillStyle As New NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Horizontal, GradientVariant.Variant1, c, Color.White)
			m_Chart.Wall(ChartWallType.Back).FillStyle = wallGradientFillStyle
			m_Chart.Wall(ChartWallType.Left).FillStyle = wallGradientFillStyle
			m_Chart.Wall(ChartWallType.Floor).FillStyle = wallGradientFillStyle

			' Create a bar series
			m_Bar = CType(m_Chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			m_Bar.DataLabelStyle.Visible = False
			m_Bar.BarShape = BarShape.Bar
			m_Bar.BarEdgePercent = 50
			m_Bar.WidthPercent = 60
			m_Bar.DepthPercent = 60
			m_Bar.Legend.Mode = SeriesLegendMode.DataPoints
			m_Bar.FillStyle = New NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Horizontal, GradientVariant.Variant1, Color.Green, Color.Yellow)

			m_Bar.AddDataPoint(New NFloatBarDataPoint(2.0, 24.0))
			m_Bar.AddDataPoint(New NFloatBarDataPoint(21.0, 60.0))
			m_Bar.AddDataPoint(New NFloatBarDataPoint(22.0, 53.0))
			m_Bar.AddDataPoint(New NFloatBarDataPoint(34.0, 80.0))
			m_Bar.AddDataPoint(New NFloatBarDataPoint(11.0, 62.0))

			' init form controls
			FillStyleCombo(StyleComboBars)
			FillStyleCombo(StyleComboWalls)
			FillStyleCombo(StyleComboBack)
			FillVariantCombo(VariantComboBars)
			FillVariantCombo(VariantComboWalls)
			FillVariantCombo(VariantComboBack)

			m_bSkipUpdate = True

			StyleComboBars.SelectedIndex = CInt(CType(m_Bar.FillStyle, NGradientFillStyle).Style)
			VariantComboBars.SelectedIndex = CInt(CType(m_Bar.FillStyle, NGradientFillStyle).Variant)

			StyleComboWalls.SelectedIndex = CInt(CType(m_Chart.Wall(ChartWallType.Back).FillStyle, NGradientFillStyle).Style)
			VariantComboWalls.SelectedIndex = CInt(CType(m_Chart.Wall(ChartWallType.Back).FillStyle, NGradientFillStyle).Variant)

			StyleComboBack.SelectedIndex = CInt(CType(nChartControl1.BackgroundStyle.FillStyle, NGradientFillStyle).Style)
			VariantComboBack.SelectedIndex = CInt(CType(nChartControl1.BackgroundStyle.FillStyle, NGradientFillStyle).Variant)

			m_bSkipUpdate = False
		End Sub

		Private Sub FillStyleCombo(ByVal combo As NComboBox)
			combo.Items.Clear()
			combo.Items.Add("Horizontal")
			combo.Items.Add("Vertical")
			combo.Items.Add("DiagonalUp")
			combo.Items.Add("DiagonalDown")
			combo.Items.Add("FromCorner")
			combo.Items.Add("FromCenter")
		End Sub

		Private Sub FillVariantCombo(ByVal combo As NComboBox)
			combo.Items.Clear()
			combo.Items.Add("Variant 1")
			combo.Items.Add("Variant 2")
			combo.Items.Add("Variant 3")
			combo.Items.Add("Variant 4")
		End Sub

		Private Sub StyleComboBars_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StyleComboBars.SelectedIndexChanged
			If m_bSkipUpdate Then
				Return
			End If

			Dim gradientFillStyle As NGradientFillStyle = CType(m_Bar.FillStyle, NGradientFillStyle)
			gradientFillStyle.Style = CType(StyleComboBars.SelectedIndex, Nevron.GraphicsCore.GradientStyle)

			nChartControl1.Refresh()
		End Sub

		Private Sub VariantComboBars_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VariantComboBars.SelectedIndexChanged
			If m_bSkipUpdate Then
				Return
			End If

			CType(m_Bar.FillStyle, NGradientFillStyle).Variant = CType(VariantComboBars.SelectedIndex, GradientVariant)
			nChartControl1.Refresh()
		End Sub

		Private Sub BeginColorBars_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BeginColorBars.Click
			Dim gradientFillStyle As NGradientFillStyle = CType(m_Bar.FillStyle, NGradientFillStyle)
			colorDialog1.Color = gradientFillStyle.BeginColor

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				gradientFillStyle.BeginColor = colorDialog1.Color
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub EndColorBars_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EndColorBars.Click
			Dim gradientFillStyle As NGradientFillStyle = CType(nChartControl1.BackgroundStyle.FillStyle, NGradientFillStyle)
			colorDialog1.Color = gradientFillStyle.EndColor

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				gradientFillStyle.EndColor = colorDialog1.Color
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub StyleComboWalls_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StyleComboWalls.SelectedIndexChanged
			If m_bSkipUpdate Then
				Return
			End If

			Dim gradientFillStyle As NGradientFillStyle = CType(m_Chart.Wall(ChartWallType.Back).FillStyle, NGradientFillStyle)
			gradientFillStyle.Style = CType(StyleComboWalls.SelectedIndex, Nevron.GraphicsCore.GradientStyle)

			m_Chart.Wall(ChartWallType.Back).FillStyle = gradientFillStyle
			m_Chart.Wall(ChartWallType.Left).FillStyle = gradientFillStyle
			m_Chart.Wall(ChartWallType.Floor).FillStyle = gradientFillStyle

			nChartControl1.Refresh()
		End Sub

		Private Sub VariantComboWalls_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VariantComboWalls.SelectedIndexChanged
			If m_bSkipUpdate Then
				Return
			End If

			Dim gradientFillStyle As NGradientFillStyle = CType(m_Chart.Wall(ChartWallType.Back).FillStyle, NGradientFillStyle)
			gradientFillStyle.Variant = CType(VariantComboWalls.SelectedIndex, GradientVariant)

			m_Chart.Wall(ChartWallType.Back).FillStyle = gradientFillStyle
			m_Chart.Wall(ChartWallType.Left).FillStyle = gradientFillStyle
			m_Chart.Wall(ChartWallType.Floor).FillStyle = gradientFillStyle

			nChartControl1.Refresh()
		End Sub

		Private Sub BeginColorWalls_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BeginColorWalls.Click
			Dim gradientFillStyle As NGradientFillStyle = CType(m_Chart.Wall(ChartWallType.Back).FillStyle, NGradientFillStyle)
			colorDialog1.Color = gradientFillStyle.BeginColor

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				gradientFillStyle.BeginColor = colorDialog1.Color

				m_Chart.Wall(ChartWallType.Back).FillStyle = gradientFillStyle
				m_Chart.Wall(ChartWallType.Left).FillStyle = gradientFillStyle
				m_Chart.Wall(ChartWallType.Floor).FillStyle = gradientFillStyle

				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub EndColorWalls_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EndColorWalls.Click
			Dim gradientFillStyle As NGradientFillStyle = CType(m_Chart.Wall(ChartWallType.Back).FillStyle, NGradientFillStyle)

			colorDialog1.Color = gradientFillStyle.EndColor

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				gradientFillStyle.EndColor = colorDialog1.Color

				m_Chart.Wall(ChartWallType.Back).FillStyle = gradientFillStyle
				m_Chart.Wall(ChartWallType.Left).FillStyle = gradientFillStyle
				m_Chart.Wall(ChartWallType.Floor).FillStyle = gradientFillStyle
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub StyleComboBack_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StyleComboBack.SelectedIndexChanged
			If m_bSkipUpdate Then
				Return
			End If

			Dim gradientFillStyle As NGradientFillStyle = CType(nChartControl1.BackgroundStyle.FillStyle, NGradientFillStyle)
			gradientFillStyle.Style = CType(StyleComboBack.SelectedIndex, Nevron.GraphicsCore.GradientStyle)
			nChartControl1.Refresh()
		End Sub

		Private Sub VariantComboBack_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VariantComboBack.SelectedIndexChanged
			If m_bSkipUpdate Then
				Return
			End If

			Dim gradientFillStyle As NGradientFillStyle = CType(nChartControl1.BackgroundStyle.FillStyle, NGradientFillStyle)
			gradientFillStyle.Variant = CType(VariantComboBack.SelectedIndex, GradientVariant)
			nChartControl1.Refresh()
		End Sub

		Private Sub BeginColorBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BeginColorBack.Click
			Dim gradientFillStyle As NGradientFillStyle = CType(nChartControl1.BackgroundStyle.FillStyle, NGradientFillStyle)
			colorDialog1.Color = gradientFillStyle.BeginColor

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				gradientFillStyle.BeginColor = colorDialog1.Color
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub EndColorBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EndColorBack.Click
			Dim gradientFillStyle As NGradientFillStyle = CType(nChartControl1.BackgroundStyle.FillStyle, NGradientFillStyle)
			colorDialog1.Color = gradientFillStyle.EndColor

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				gradientFillStyle.EndColor = colorDialog1.Color
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace

