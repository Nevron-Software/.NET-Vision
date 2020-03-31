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
	Public Class NXYScatterBubbleUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bubble As NBubbleSeries
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private WithEvents InflateMargins As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents MaxBubbleSizeScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents MinBubbleSizeScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents BubbleShapeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents ChangeXValues As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ChangeYValues As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents AxesRoundToTick As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShadowButton As Nevron.UI.WinForm.Controls.NButton
		Private MaxBubbleSizeLabel As System.Windows.Forms.Label
		Private MinBubbleSizeLabel As System.Windows.Forms.Label
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
			Me.InflateMargins = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.MaxBubbleSizeScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.MinBubbleSizeScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.BubbleShapeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.ChangeXValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.ChangeYValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.AxesRoundToTick = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.MaxBubbleSizeLabel = New System.Windows.Forms.Label()
			Me.MinBubbleSizeLabel = New System.Windows.Forms.Label()
			Me.ShadowButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' InflateMargins
			' 
			Me.InflateMargins.ButtonProperties.BorderOffset = 2
			Me.InflateMargins.Location = New System.Drawing.Point(9, 172)
			Me.InflateMargins.Name = "InflateMargins"
			Me.InflateMargins.Size = New System.Drawing.Size(136, 20)
			Me.InflateMargins.TabIndex = 45
			Me.InflateMargins.Text = "Inflate Margins"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InflateMargins.CheckedChanged += new System.EventHandler(this.InflateMargins_CheckedChanged);
			' 
			' MaxBubbleSizeScroll
			' 
			Me.MaxBubbleSizeScroll.LargeChange = 1
			Me.MaxBubbleSizeScroll.Location = New System.Drawing.Point(9, 135)
			Me.MaxBubbleSizeScroll.Maximum = 50
			Me.MaxBubbleSizeScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.MaxBubbleSizeScroll.Name = "MaxBubbleSizeScroll"
			Me.MaxBubbleSizeScroll.Size = New System.Drawing.Size(136, 16)
			Me.MaxBubbleSizeScroll.TabIndex = 43
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MaxBubbleSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.MaxBubbleSizeScroll_Scroll);
			' 
			' MinBubbleSizeScroll
			' 
			Me.MinBubbleSizeScroll.LargeChange = 1
			Me.MinBubbleSizeScroll.Location = New System.Drawing.Point(9, 81)
			Me.MinBubbleSizeScroll.Maximum = 50
			Me.MinBubbleSizeScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.MinBubbleSizeScroll.Name = "MinBubbleSizeScroll"
			Me.MinBubbleSizeScroll.Size = New System.Drawing.Size(136, 16)
			Me.MinBubbleSizeScroll.TabIndex = 42
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MinBubbleSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.MinBubbleSizeScroll_Scroll);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(9, 117)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(136, 18)
			Me.label3.TabIndex = 41
			Me.label3.Text = "Max Bubble Size:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 62)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(136, 18)
			Me.label2.TabIndex = 40
			Me.label2.Text = "Min Bubble Size:"
			' 
			' BubbleShapeCombo
			' 
			Me.BubbleShapeCombo.ListProperties.CheckBoxDataMember = ""
			Me.BubbleShapeCombo.ListProperties.DataSource = Nothing
			Me.BubbleShapeCombo.ListProperties.DisplayMember = ""
			Me.BubbleShapeCombo.Location = New System.Drawing.Point(8, 27)
			Me.BubbleShapeCombo.Name = "BubbleShapeCombo"
			Me.BubbleShapeCombo.Size = New System.Drawing.Size(136, 21)
			Me.BubbleShapeCombo.TabIndex = 39
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BubbleShapeCombo.SelectedIndexChanged += new System.EventHandler(this.BubbleShapeCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(136, 18)
			Me.label1.TabIndex = 38
			Me.label1.Text = "Bubble Shape:"
			' 
			' ChangeXValues
			' 
			Me.ChangeXValues.Location = New System.Drawing.Point(8, 265)
			Me.ChangeXValues.Name = "ChangeXValues"
			Me.ChangeXValues.Size = New System.Drawing.Size(136, 23)
			Me.ChangeXValues.TabIndex = 46
			Me.ChangeXValues.Text = "Change X Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeXValues.Click += new System.EventHandler(this.ChangeXValues_Click);
			' 
			' ChangeYValues
			' 
			Me.ChangeYValues.Location = New System.Drawing.Point(8, 233)
			Me.ChangeYValues.Name = "ChangeYValues"
			Me.ChangeYValues.Size = New System.Drawing.Size(136, 23)
			Me.ChangeYValues.TabIndex = 47
			Me.ChangeYValues.Text = "Change Y Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeYValues.Click += new System.EventHandler(this.ChangeYValues_Click);
			' 
			' AxesRoundToTick
			' 
			Me.AxesRoundToTick.ButtonProperties.BorderOffset = 2
			Me.AxesRoundToTick.Location = New System.Drawing.Point(9, 199)
			Me.AxesRoundToTick.Name = "AxesRoundToTick"
			Me.AxesRoundToTick.Size = New System.Drawing.Size(136, 19)
			Me.AxesRoundToTick.TabIndex = 49
			Me.AxesRoundToTick.Text = "Axes Round To Tick"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AxesRoundToTick.CheckedChanged += new System.EventHandler(this.AxesRoundToTick_CheckedChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(9, 67)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(136, 0)
			Me.label4.TabIndex = 51
			Me.label4.Text = "label4"
			' 
			' MaxBubbleSizeLabel
			' 
			Me.MaxBubbleSizeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.MaxBubbleSizeLabel.Location = New System.Drawing.Point(153, 135)
			Me.MaxBubbleSizeLabel.Name = "MaxBubbleSizeLabel"
			Me.MaxBubbleSizeLabel.Size = New System.Drawing.Size(23, 15)
			Me.MaxBubbleSizeLabel.TabIndex = 52
			Me.MaxBubbleSizeLabel.Text = "0"
			' 
			' MinBubbleSizeLabel
			' 
			Me.MinBubbleSizeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.MinBubbleSizeLabel.Location = New System.Drawing.Point(153, 81)
			Me.MinBubbleSizeLabel.Name = "MinBubbleSizeLabel"
			Me.MinBubbleSizeLabel.Size = New System.Drawing.Size(23, 15)
			Me.MinBubbleSizeLabel.TabIndex = 53
			Me.MinBubbleSizeLabel.Text = "0"
			' 
			' ShadowButton
			' 
			Me.ShadowButton.Location = New System.Drawing.Point(9, 314)
			Me.ShadowButton.Name = "ShadowButton"
			Me.ShadowButton.Size = New System.Drawing.Size(136, 23)
			Me.ShadowButton.TabIndex = 54
			Me.ShadowButton.Text = "Bubble Shadow..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShadowButton.Click += new System.EventHandler(this.ShadowButton_Click);
			' 
			' NXYScatterBubbleUC
			' 
			Me.Controls.Add(Me.ShadowButton)
			Me.Controls.Add(Me.MinBubbleSizeLabel)
			Me.Controls.Add(Me.MaxBubbleSizeLabel)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.AxesRoundToTick)
			Me.Controls.Add(Me.ChangeYValues)
			Me.Controls.Add(Me.ChangeXValues)
			Me.Controls.Add(Me.InflateMargins)
			Me.Controls.Add(Me.MaxBubbleSizeScroll)
			Me.Controls.Add(Me.MinBubbleSizeScroll)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.BubbleShapeCombo)
			Me.Controls.Add(Me.label1)
			Me.Name = "NXYScatterBubbleUC"
			Me.Size = New System.Drawing.Size(180, 357)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XY Bubble Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' setup chart
			m_Chart = nChartControl1.Charts(0)

			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlace style
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(New NArgbColor(Color.Beige)), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			m_Bubble = CType(m_Chart.Series.Add(SeriesType.Bubble), NBubbleSeries)
			m_Bubble.DataLabelStyle.Visible = False
			m_Bubble.Legend.Format = "<label>"
			m_Bubble.Legend.Mode = SeriesLegendMode.DataPoints
			m_Bubble.ShadowStyle.Type = ShadowType.Solid
			m_Bubble.ShadowStyle.Offset = New NPointL(1.2F, 1.2F)
			m_Bubble.ShadowStyle.Color = Color.FromArgb(60, 0, 0, 0)
			m_Bubble.UseXValues = True

			m_Bubble.AddDataPoint(New NBubbleDataPoint(27, 51, 1147995904, "India"))
			m_Bubble.AddDataPoint(New NBubbleDataPoint(50, 67, 1321851888, "China"))
			m_Bubble.AddDataPoint(New NBubbleDataPoint(76, 22, 109955400, "Mexico"))
			m_Bubble.AddDataPoint(New NBubbleDataPoint(210, 9, 142008838, "Russia"))
			m_Bubble.AddDataPoint(New NBubbleDataPoint(360, 4, 305843000, "USA"))
			m_Bubble.AddDataPoint(New NBubbleDataPoint(470, 5, 33560000, "Canada"))

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			BubbleShapeCombo.FillFromEnum(GetType(PointShape))
			BubbleShapeCombo.SelectedIndex = 7

			AxesRoundToTick.Checked = True
			InflateMargins.Checked = True
			MinBubbleSizeScroll.Value = 4
			MaxBubbleSizeScroll.Value = 20
		End Sub

		Private Sub ChangeXValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeXValues.Click
			m_Bubble.XValues.FillRandom(Random, 4)
			m_Bubble.XValues(0) = -10
			nChartControl1.Refresh()
		End Sub
		Private Sub ChangeYValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeYValues.Click
			m_Bubble.Values.FillRandom(Random, 4)
			nChartControl1.Refresh()
		End Sub
		Private Sub BubbleShapeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BubbleShapeCombo.SelectedIndexChanged
			m_Bubble.BubbleShape = CType(BubbleShapeCombo.SelectedIndex, PointShape)
			nChartControl1.Refresh()
		End Sub
		Private Sub MinBubbleSizeScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles MinBubbleSizeScroll.ValueChanged
			m_Bubble.MinSize = New NLength(MinBubbleSizeScroll.Value, NRelativeUnit.ParentPercentage)
			MinBubbleSizeLabel.Text = m_Bubble.MinSize.ToString()
			nChartControl1.Refresh()
		End Sub
		Private Sub MaxBubbleSizeScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles MaxBubbleSizeScroll.ValueChanged
			m_Bubble.MaxSize = New NLength(MaxBubbleSizeScroll.Value, NRelativeUnit.ParentPercentage)
			MaxBubbleSizeLabel.Text = m_Bubble.MaxSize.ToString()
			nChartControl1.Refresh()
		End Sub
		Private Sub InflateMargins_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InflateMargins.CheckedChanged
			m_Bubble.InflateMargins = InflateMargins.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub AxesRoundToTick_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AxesRoundToTick.CheckedChanged
			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			linearScale.RoundToTickMin = AxesRoundToTick.Checked
			linearScale.RoundToTickMax = AxesRoundToTick.Checked

			linearScale = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NLinearScaleConfigurator)

			linearScale.RoundToTickMin = AxesRoundToTick.Checked
			linearScale.RoundToTickMax = AxesRoundToTick.Checked

			nChartControl1.Refresh()
		End Sub
		Private Sub ShadowButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShadowButton.Click
			Dim shadowStyleResult As NShadowStyle = Nothing

			If NShadowStyleTypeEditor.Edit(m_Bubble.ShadowStyle, shadowStyleResult) Then
				m_Bubble.ShadowStyle = shadowStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
