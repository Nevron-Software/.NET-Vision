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
	Public Class NStandardBubbleUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bubble As NBubbleSeries
		Private label1 As System.Windows.Forms.Label
		Private WithEvents BubbleShapeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private WithEvents MinBubbleSizeScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents MaxBubbleSizeScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents DifferentColors As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents InflateMargins As Nevron.UI.WinForm.Controls.NCheckBox
		Private label5 As System.Windows.Forms.Label
		Private WithEvents LegendFormatCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents BubbleFE As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents InvertAxisRuler As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents BubbleBorderButton As Nevron.UI.WinForm.Controls.NButton
		Private groupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
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
			Me.BubbleShapeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.MinBubbleSizeScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.MaxBubbleSizeScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.DifferentColors = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.BubbleFE = New Nevron.UI.WinForm.Controls.NButton()
			Me.InflateMargins = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.LegendFormatCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.InvertAxisRuler = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.BubbleBorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.groupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.groupBox3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(9, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(150, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Bubble Shape:"
			' 
			' BubbleShapeCombo
			' 
			Me.BubbleShapeCombo.ListProperties.CheckBoxDataMember = ""
			Me.BubbleShapeCombo.ListProperties.DataSource = Nothing
			Me.BubbleShapeCombo.ListProperties.DisplayMember = ""
			Me.BubbleShapeCombo.Location = New System.Drawing.Point(9, 28)
			Me.BubbleShapeCombo.Name = "BubbleShapeCombo"
			Me.BubbleShapeCombo.Size = New System.Drawing.Size(150, 21)
			Me.BubbleShapeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BubbleShapeCombo.SelectedIndexChanged += new System.EventHandler(this.BubbleShapeCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 58)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(150, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Min Bubble Size:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(9, 103)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(150, 16)
			Me.label3.TabIndex = 3
			Me.label3.Text = "Max Bubble Size:"
			' 
			' MinBubbleSizeScroll
			' 
			Me.MinBubbleSizeScroll.Location = New System.Drawing.Point(9, 75)
			Me.MinBubbleSizeScroll.Maximum = 60
			Me.MinBubbleSizeScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.MinBubbleSizeScroll.Name = "MinBubbleSizeScroll"
			Me.MinBubbleSizeScroll.Size = New System.Drawing.Size(150, 16)
			Me.MinBubbleSizeScroll.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MinBubbleSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.MinBubbleSizeScroll_Scroll);
			' 
			' MaxBubbleSizeScroll
			' 
			Me.MaxBubbleSizeScroll.Location = New System.Drawing.Point(9, 120)
			Me.MaxBubbleSizeScroll.Maximum = 60
			Me.MaxBubbleSizeScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.MaxBubbleSizeScroll.Name = "MaxBubbleSizeScroll"
			Me.MaxBubbleSizeScroll.Size = New System.Drawing.Size(150, 16)
			Me.MaxBubbleSizeScroll.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MaxBubbleSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.MaxBubbleSizeScroll_Scroll);
			' 
			' DifferentColors
			' 
			Me.DifferentColors.ButtonProperties.BorderOffset = 2
			Me.DifferentColors.Location = New System.Drawing.Point(9, 16)
			Me.DifferentColors.Name = "DifferentColors"
			Me.DifferentColors.Size = New System.Drawing.Size(132, 20)
			Me.DifferentColors.TabIndex = 6
			Me.DifferentColors.Text = "Different Colors"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DifferentColors.CheckedChanged += new System.EventHandler(this.DifferentColors_CheckedChanged);
			' 
			' BubbleFE
			' 
			Me.BubbleFE.Location = New System.Drawing.Point(9, 39)
			Me.BubbleFE.Name = "BubbleFE"
			Me.BubbleFE.Size = New System.Drawing.Size(132, 23)
			Me.BubbleFE.TabIndex = 7
			Me.BubbleFE.Text = "Bubble Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BubbleFE.Click += new System.EventHandler(this.BubbleFE_Click);
			' 
			' InflateMargins
			' 
			Me.InflateMargins.ButtonProperties.BorderOffset = 2
			Me.InflateMargins.Location = New System.Drawing.Point(9, 150)
			Me.InflateMargins.Name = "InflateMargins"
			Me.InflateMargins.Size = New System.Drawing.Size(150, 21)
			Me.InflateMargins.TabIndex = 37
			Me.InflateMargins.Text = "Inflate Margins"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InflateMargins.CheckedChanged += new System.EventHandler(this.InflateMargins_CheckedChanged);
			' 
			' LegendFormatCombo
			' 
			Me.LegendFormatCombo.ListProperties.CheckBoxDataMember = ""
			Me.LegendFormatCombo.ListProperties.DataSource = Nothing
			Me.LegendFormatCombo.ListProperties.DisplayMember = ""
			Me.LegendFormatCombo.Location = New System.Drawing.Point(9, 232)
			Me.LegendFormatCombo.Name = "LegendFormatCombo"
			Me.LegendFormatCombo.Size = New System.Drawing.Size(150, 21)
			Me.LegendFormatCombo.TabIndex = 39
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LegendFormatCombo.SelectedIndexChanged += new System.EventHandler(this.LegendFormatCombo_SelectedIndexChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(9, 211)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(133, 16)
			Me.label5.TabIndex = 40
			Me.label5.Text = "Legend Format:"
			' 
			' InvertAxisRuler
			' 
			Me.InvertAxisRuler.ButtonProperties.BorderOffset = 2
			Me.InvertAxisRuler.Location = New System.Drawing.Point(9, 173)
			Me.InvertAxisRuler.Name = "InvertAxisRuler"
			Me.InvertAxisRuler.Size = New System.Drawing.Size(150, 21)
			Me.InvertAxisRuler.TabIndex = 39
			Me.InvertAxisRuler.Text = "Invert Y Axis Ruler"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InvertAxisRuler.CheckedChanged += new System.EventHandler(this.InvertAxisRuler_CheckedChanged);
			' 
			' BubbleBorderButton
			' 
			Me.BubbleBorderButton.Location = New System.Drawing.Point(9, 68)
			Me.BubbleBorderButton.Name = "BubbleBorderButton"
			Me.BubbleBorderButton.Size = New System.Drawing.Size(132, 23)
			Me.BubbleBorderButton.TabIndex = 40
			Me.BubbleBorderButton.Text = "Bubble Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BubbleBorderButton.Click += new System.EventHandler(this.BubbleBorderButton_Click);
			' 
			' groupBox3
			' 
			Me.groupBox3.Controls.Add(Me.BubbleFE)
			Me.groupBox3.Controls.Add(Me.BubbleBorderButton)
			Me.groupBox3.Controls.Add(Me.DifferentColors)
			Me.groupBox3.ImageIndex = 0
			Me.groupBox3.Location = New System.Drawing.Point(9, 271)
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.Size = New System.Drawing.Size(150, 100)
			Me.groupBox3.TabIndex = 41
			Me.groupBox3.TabStop = False
			Me.groupBox3.Text = "Appearance"
			' 
			' NStandardBubbleUC
			' 
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.LegendFormatCombo)
			Me.Controls.Add(Me.groupBox3)
			Me.Controls.Add(Me.InvertAxisRuler)
			Me.Controls.Add(Me.InflateMargins)
			Me.Controls.Add(Me.MaxBubbleSizeScroll)
			Me.Controls.Add(Me.MinBubbleSizeScroll)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.BubbleShapeCombo)
			Me.Controls.Add(Me.label1)
			Me.Name = "NStandardBubbleUC"
			Me.Size = New System.Drawing.Size(180, 389)
			Me.groupBox3.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("2D Bubble Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlace stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' add a bubble series
			m_Bubble = CType(m_Chart.Series.Add(SeriesType.Bubble), NBubbleSeries)
			m_Bubble.DataLabelStyle.VertAlign = VertAlign.Center
			m_Bubble.DataLabelStyle.Visible = False
			m_Bubble.Legend.Mode = SeriesLegendMode.DataPoints
			m_Bubble.MinSize = New NLength(7.0F, NRelativeUnit.ParentPercentage)
			m_Bubble.MaxSize = New NLength(16.0F, NRelativeUnit.ParentPercentage)

			m_Bubble.AddDataPoint(New NBubbleDataPoint(10, 10, "Company 1"))
			m_Bubble.AddDataPoint(New NBubbleDataPoint(15, 20, "Company 2"))
			m_Bubble.AddDataPoint(New NBubbleDataPoint(12, 25, "Company 3"))
			m_Bubble.AddDataPoint(New NBubbleDataPoint(8, 15, "Company 4"))
			m_Bubble.AddDataPoint(New NBubbleDataPoint(14, 17, "Company 5"))
			m_Bubble.AddDataPoint(New NBubbleDataPoint(11, 12, "Company 6"))

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' init form controls
			BubbleShapeCombo.FillFromEnum(GetType(PointShape))
			BubbleShapeCombo.SelectedIndex = 6

			LegendFormatCombo.Items.Add("Value and Label")
			LegendFormatCombo.Items.Add("Value")
			LegendFormatCombo.Items.Add("Label")
			LegendFormatCombo.Items.Add("Size")
			LegendFormatCombo.SelectedIndex = 2

			InflateMargins.Checked = True
			DifferentColors.Checked = True
		End Sub

		Private Sub BubbleShapeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BubbleShapeCombo.SelectedIndexChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_Bubble.BubbleShape = CType(BubbleShapeCombo.SelectedIndex, PointShape)
			nChartControl1.Refresh()
		End Sub
		Private Sub MinBubbleSizeScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles MinBubbleSizeScroll.ValueChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_Bubble.MinSize = New NLength(MinBubbleSizeScroll.Value, NRelativeUnit.ParentPercentage)
			nChartControl1.Refresh()
		End Sub
		Private Sub MaxBubbleSizeScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles MaxBubbleSizeScroll.ValueChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_Bubble.MaxSize = New NLength(MaxBubbleSizeScroll.Value, NRelativeUnit.ParentPercentage)
			nChartControl1.Refresh()
		End Sub
		Private Sub DifferentColors_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DifferentColors.CheckedChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			If DifferentColors.Checked Then
				BubbleFE.Enabled = False
				BubbleBorderButton.Enabled = False

				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
				styleSheet.Apply(nChartControl1.Document)
			Else
				BubbleFE.Enabled = True
				BubbleBorderButton.Enabled = True

				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
				styleSheet.Apply(nChartControl1.Document)
			End If

			nChartControl1.Refresh()
		End Sub
		Private Sub BubbleFE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BubbleFE.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_Bubble.FillStyle, fillStyleResult) Then
				m_Bubble.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub BubbleBorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BubbleBorderButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Bubble.BorderStyle, strokeStyleResult) Then
				m_Bubble.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub InflateMargins_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InflateMargins.CheckedChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_Bubble.InflateMargins = InflateMargins.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub LegendFormatCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LegendFormatCombo.SelectedIndexChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim sFormat As String = ""
			Select Case LegendFormatCombo.SelectedIndex
				Case 0
					sFormat = "<value> <label>"
				Case 1
					sFormat = "<value>"
				Case 2
					sFormat = "<label>"
				Case 3
					sFormat = "<size>"
			End Select
			m_Bubble.Legend.Format = sFormat
			nChartControl1.Refresh()
		End Sub
		Private Sub InvertAxisRuler_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InvertAxisRuler.CheckedChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfigurator.Invert = InvertAxisRuler.Checked

			nChartControl1.Refresh()
		End Sub
		Private Sub LabelStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim styleResult As NDataLabelStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NDataLabelStyleTypeEditor.Edit(series.DataLabelStyle, styleResult) Then
				series.DataLabelStyle = styleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
