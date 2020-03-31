Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NPatternUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bar As NFloatBarSeries
		Private m_bSkipUpdate As Boolean
		Private label1 As System.Windows.Forms.Label
		Private WithEvents EndColorBars As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BeginColorBars As Nevron.UI.WinForm.Controls.NButton
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents HatchComboBars As Nevron.UI.WinForm.Controls.NComboBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label2 As System.Windows.Forms.Label
		Private groupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label3 As System.Windows.Forms.Label
		Private WithEvents EndColorWalls As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BeginColorWalls As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents HatchComboWalls As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents EndColorBack As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BeginColorBack As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents HatchComboBack As Nevron.UI.WinForm.Controls.NComboBox
		Private colorDialog1 As Nevron.UI.WinForm.Controls.NColorDialog
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
			Me.HatchComboBars = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.EndColorWalls = New Nevron.UI.WinForm.Controls.NButton()
			Me.BeginColorWalls = New Nevron.UI.WinForm.Controls.NButton()
			Me.HatchComboWalls = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.groupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.EndColorBack = New Nevron.UI.WinForm.Controls.NButton()
			Me.BeginColorBack = New Nevron.UI.WinForm.Controls.NButton()
			Me.HatchComboBack = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.colorDialog1 = New Nevron.UI.WinForm.Controls.NColorDialog()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.groupBox3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.EndColorBars)
			Me.groupBox1.Controls.Add(Me.BeginColorBars)
			Me.groupBox1.Controls.Add(Me.HatchComboBars)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Location = New System.Drawing.Point(7, 7)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(189, 132)
			Me.groupBox1.TabIndex = 1
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Bars"
			' 
			' EndColorBars
			' 
			Me.EndColorBars.Location = New System.Drawing.Point(9, 98)
			Me.EndColorBars.Name = "EndColorBars"
			Me.EndColorBars.Size = New System.Drawing.Size(171, 24)
			Me.EndColorBars.TabIndex = 5
			Me.EndColorBars.Text = "End Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EndColorBars.Click += new System.EventHandler(this.EndColorBars_Click);
			' 
			' BeginColorBars
			' 
			Me.BeginColorBars.Location = New System.Drawing.Point(9, 68)
			Me.BeginColorBars.Name = "BeginColorBars"
			Me.BeginColorBars.Size = New System.Drawing.Size(171, 24)
			Me.BeginColorBars.TabIndex = 4
			Me.BeginColorBars.Text = "Begin Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BeginColorBars.Click += new System.EventHandler(this.BeginColorBars_Click);
			' 
			' HatchComboBars
			' 
			Me.HatchComboBars.DropDownWidth = 121
			Me.HatchComboBars.Location = New System.Drawing.Point(9, 36)
			Me.HatchComboBars.Name = "HatchComboBars"
			Me.HatchComboBars.Size = New System.Drawing.Size(171, 21)
			Me.HatchComboBars.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HatchComboBars.SelectedIndexChanged += new System.EventHandler(this.HatchComboBars_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(9, 19)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(121, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Pattern Style:"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.EndColorWalls)
			Me.groupBox2.Controls.Add(Me.BeginColorWalls)
			Me.groupBox2.Controls.Add(Me.HatchComboWalls)
			Me.groupBox2.Controls.Add(Me.label2)
			Me.groupBox2.Location = New System.Drawing.Point(7, 150)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(189, 132)
			Me.groupBox2.TabIndex = 6
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Walls"
			' 
			' EndColorWalls
			' 
			Me.EndColorWalls.Location = New System.Drawing.Point(9, 98)
			Me.EndColorWalls.Name = "EndColorWalls"
			Me.EndColorWalls.Size = New System.Drawing.Size(171, 24)
			Me.EndColorWalls.TabIndex = 5
			Me.EndColorWalls.Text = "End Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EndColorWalls.Click += new System.EventHandler(this.EndColorWalls_Click);
			' 
			' BeginColorWalls
			' 
			Me.BeginColorWalls.Location = New System.Drawing.Point(9, 68)
			Me.BeginColorWalls.Name = "BeginColorWalls"
			Me.BeginColorWalls.Size = New System.Drawing.Size(171, 24)
			Me.BeginColorWalls.TabIndex = 4
			Me.BeginColorWalls.Text = "Begin Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BeginColorWalls.Click += new System.EventHandler(this.BeginColorWalls_Click);
			' 
			' HatchComboWalls
			' 
			Me.HatchComboWalls.DropDownWidth = 121
			Me.HatchComboWalls.Location = New System.Drawing.Point(9, 36)
			Me.HatchComboWalls.Name = "HatchComboWalls"
			Me.HatchComboWalls.Size = New System.Drawing.Size(171, 21)
			Me.HatchComboWalls.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HatchComboWalls.SelectedIndexChanged += new System.EventHandler(this.HatchComboWalls_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 19)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(121, 16)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Pattern Style:"
			' 
			' groupBox3
			' 
			Me.groupBox3.Controls.Add(Me.EndColorBack)
			Me.groupBox3.Controls.Add(Me.BeginColorBack)
			Me.groupBox3.Controls.Add(Me.HatchComboBack)
			Me.groupBox3.Controls.Add(Me.label3)
			Me.groupBox3.Location = New System.Drawing.Point(7, 296)
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.Size = New System.Drawing.Size(189, 132)
			Me.groupBox3.TabIndex = 6
			Me.groupBox3.TabStop = False
			Me.groupBox3.Text = "Background"
			' 
			' EndColorBack
			' 
			Me.EndColorBack.Location = New System.Drawing.Point(9, 98)
			Me.EndColorBack.Name = "EndColorBack"
			Me.EndColorBack.Size = New System.Drawing.Size(171, 24)
			Me.EndColorBack.TabIndex = 5
			Me.EndColorBack.Text = "End Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EndColorBack.Click += new System.EventHandler(this.EndColorBack_Click);
			' 
			' BeginColorBack
			' 
			Me.BeginColorBack.Location = New System.Drawing.Point(9, 68)
			Me.BeginColorBack.Name = "BeginColorBack"
			Me.BeginColorBack.Size = New System.Drawing.Size(171, 24)
			Me.BeginColorBack.TabIndex = 4
			Me.BeginColorBack.Text = "Begin Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BeginColorBack.Click += new System.EventHandler(this.BeginColorBack_Click);
			' 
			' HatchComboBack
			' 
			Me.HatchComboBack.DropDownWidth = 121
			Me.HatchComboBack.Location = New System.Drawing.Point(9, 36)
			Me.HatchComboBack.Name = "HatchComboBack"
			Me.HatchComboBack.Size = New System.Drawing.Size(171, 21)
			Me.HatchComboBack.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HatchComboBack.SelectedIndexChanged += new System.EventHandler(this.HatchComboBack_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(9, 19)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(121, 16)
			Me.label3.TabIndex = 0
			Me.label3.Text = "Pattern Style:"
			' 
			' NPatternUC
			' 
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox3)
			Me.Name = "NPatternUC"
			Me.Size = New System.Drawing.Size(203, 489)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox3.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' Set background pattern
			nChartControl1.BackgroundStyle.FillStyle = New NHatchFillStyle(HatchStyle.ZigZag, Color.FromArgb(187,221,255), Color.White)

			' add label
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Hatch Fill Style")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' hide y axis grid lines
			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, False)
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Left, False)

			' hide x axis grid lines
			scaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, False)
			scaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Left, False)

			' set the projection to tilted
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)

			m_Chart.Projection.Rotation = -14
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)

			' Setup walls
			Dim c As Color = Color.FromArgb(128, 128, 192)
			Dim hatchFillstyle As New NHatchFillStyle(HatchStyle.Weave, Color.White, c)

			m_Chart.Wall(ChartWallType.Back).FillStyle = hatchFillstyle
			m_Chart.Wall(ChartWallType.Left).FillStyle = hatchFillstyle
			m_Chart.Wall(ChartWallType.Floor).FillStyle = hatchFillstyle

			' Create a bar series
			m_Bar = CType(m_Chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			m_Bar.DataLabelStyle.Visible = False
			m_Bar.BarShape = BarShape.Bar
			m_Bar.BarEdgePercent = 50
			m_Bar.WidthPercent = 60
			m_Bar.DepthPercent = 60
			m_Bar.Legend.Mode = SeriesLegendMode.DataPoints
			m_Bar.FillStyle = New NHatchFillStyle(HatchStyle.LargeConfetti, Color.Green, Color.Yellow)

			m_Bar.AddDataPoint(New NFloatBarDataPoint(2.0, 24.0))
			m_Bar.AddDataPoint(New NFloatBarDataPoint(21.0, 60.0))
			m_Bar.AddDataPoint(New NFloatBarDataPoint(22.0, 53.0))
			m_Bar.AddDataPoint(New NFloatBarDataPoint(34.0, 80.0))
			m_Bar.AddDataPoint(New NFloatBarDataPoint(11.0, 62.0))

			' init form controls
			Dim arrHatchNames() As String = System.Enum.GetNames(GetType(HatchStyle))

			HatchComboBars.Items.AddRange(arrHatchNames)
			HatchComboWalls.Items.AddRange(arrHatchNames)
			HatchComboBack.Items.AddRange(arrHatchNames)

			m_bSkipUpdate = True

			SetHatchStyleFromCombo(HatchComboBars, CType(m_Bar.FillStyle, NHatchFillStyle).Style)
			SetHatchStyleFromCombo(HatchComboWalls, CType(m_Chart.Wall(ChartWallType.Back).FillStyle, NHatchFillStyle).Style)
			SetHatchStyleFromCombo(HatchComboBack, CType(nChartControl1.BackgroundStyle.FillStyle, NHatchFillStyle).Style)

			m_bSkipUpdate = False
		End Sub

		Private Function GetHatchStyleFromCombo(ByVal combo As NComboBox) As HatchStyle
			Dim sHatchName As String = DirectCast(combo.SelectedItem, String)
			Return DirectCast(System.Enum.Parse(GetType(HatchStyle), sHatchName), HatchStyle)
		End Function

		Private Sub SetHatchStyleFromCombo(ByVal combo As NComboBox, ByVal style As HatchStyle)
			combo.SelectedItem = System.Enum.GetName(GetType(HatchStyle), style)
		End Sub

		Private Sub HatchComboBars_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HatchComboBars.SelectedIndexChanged
			If m_bSkipUpdate Then
				Return
			End If

			CType(m_Bar.FillStyle, NHatchFillStyle).Style = GetHatchStyleFromCombo(HatchComboBars)
			nChartControl1.Refresh()
		End Sub

		Private Sub BeginColorBars_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BeginColorBars.Click
			Dim hatchFillStyle As NHatchFillStyle = CType(m_Bar.FillStyle, NHatchFillStyle)
			colorDialog1.Color = hatchFillStyle.ForegroundColor

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				hatchFillStyle.ForegroundColor = colorDialog1.Color
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub EndColorBars_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EndColorBars.Click
			Dim hatchFillStyle As NHatchFillStyle = CType(m_Bar.FillStyle, NHatchFillStyle)
			colorDialog1.Color = hatchFillStyle.BackgroundColor

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				hatchFillStyle.BackgroundColor = colorDialog1.Color
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub HatchComboWalls_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HatchComboWalls.SelectedIndexChanged
			If m_bSkipUpdate Then
				Return
			End If

			Dim style As HatchStyle = GetHatchStyleFromCombo(HatchComboWalls)

			CType(m_Chart.Wall(ChartWallType.Back).FillStyle, NHatchFillStyle).Style = style
			CType(m_Chart.Wall(ChartWallType.Left).FillStyle, NHatchFillStyle).Style = style
			CType(m_Chart.Wall(ChartWallType.Floor).FillStyle, NHatchFillStyle).Style = style

			nChartControl1.Refresh()
		End Sub

		Private Sub BeginColorWalls_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BeginColorWalls.Click
			Dim hatchFillStyle As NHatchFillStyle = CType(m_Chart.Wall(ChartWallType.Back).FillStyle, NHatchFillStyle)
			colorDialog1.Color = hatchFillStyle.ForegroundColor

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				hatchFillStyle.ForegroundColor = colorDialog1.Color

				m_Chart.Wall(ChartWallType.Back).FillStyle = hatchFillStyle
				m_Chart.Wall(ChartWallType.Left).FillStyle = hatchFillStyle
				m_Chart.Wall(ChartWallType.Floor).FillStyle = hatchFillStyle

				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub EndColorWalls_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EndColorWalls.Click
			Dim hatchFillStyle As NHatchFillStyle = CType(m_Chart.Wall(ChartWallType.Back).FillStyle, NHatchFillStyle)
			colorDialog1.Color = hatchFillStyle.ForegroundColor

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				hatchFillStyle.ForegroundColor = colorDialog1.Color

				m_Chart.Wall(ChartWallType.Back).FillStyle = hatchFillStyle
				m_Chart.Wall(ChartWallType.Left).FillStyle = hatchFillStyle
				m_Chart.Wall(ChartWallType.Floor).FillStyle = hatchFillStyle

				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub HatchComboBack_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HatchComboBack.SelectedIndexChanged
			If m_bSkipUpdate Then
				Return
			End If

			Dim hatchFillStyle As NHatchFillStyle = CType(nChartControl1.BackgroundStyle.FillStyle, NHatchFillStyle)
			hatchFillStyle.Style = GetHatchStyleFromCombo(HatchComboBack)
			nChartControl1.Refresh()
		End Sub

		Private Sub BeginColorBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BeginColorBack.Click
			Dim hatchFillStyle As NHatchFillStyle = CType(nChartControl1.BackgroundStyle.FillStyle, NHatchFillStyle)
			colorDialog1.Color = hatchFillStyle.ForegroundColor

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				hatchFillStyle.ForegroundColor = colorDialog1.Color
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub EndColorBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EndColorBack.Click
			Dim hatchFillStyle As NHatchFillStyle = CType(nChartControl1.BackgroundStyle.FillStyle, NHatchFillStyle)
			colorDialog1.Color = hatchFillStyle.ForegroundColor

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				hatchFillStyle.ForegroundColor = colorDialog1.Color
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace