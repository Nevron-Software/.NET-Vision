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
	Public Class NSeriesDataLabelAttributeUC
		Inherits NExampleBaseUC

		Private m_DataLabelStyle As NDataLabelStyle
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private WithEvents DataLabelModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents FormatCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents VertAlignCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents TextFont As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ArrowLengthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents ArrowLineButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.DataLabelModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.ArrowLengthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label3 = New System.Windows.Forms.Label()
			Me.ArrowLineButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label4 = New System.Windows.Forms.Label()
			Me.TextFont = New Nevron.UI.WinForm.Controls.NButton()
			Me.FormatCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.VertAlignCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' DataLabelModeCombo
			' 
			Me.DataLabelModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.DataLabelModeCombo.ListProperties.DataSource = Nothing
			Me.DataLabelModeCombo.ListProperties.DisplayMember = ""
			Me.DataLabelModeCombo.Location = New System.Drawing.Point(4, 10)
			Me.DataLabelModeCombo.Name = "DataLabelModeCombo"
			Me.DataLabelModeCombo.Size = New System.Drawing.Size(172, 21)
			Me.DataLabelModeCombo.TabIndex = 0
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DataLabelModeCombo.SelectedIndexChanged += new System.EventHandler(this.DataLabelModeCombo_SelectedIndexChanged);
			' 
			' ArrowLengthScroll
			' 
			Me.ArrowLengthScroll.LargeChange = 1
			Me.ArrowLengthScroll.Location = New System.Drawing.Point(4, 207)
			Me.ArrowLengthScroll.Maximum = 31
			Me.ArrowLengthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.ArrowLengthScroll.Name = "ArrowLengthScroll"
			Me.ArrowLengthScroll.Size = New System.Drawing.Size(172, 16)
			Me.ArrowLengthScroll.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ArrowLengthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ArrowLengthScroll_Scroll);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(4, 190)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(172, 16)
			Me.label3.TabIndex = 5
			Me.label3.Text = "Arrow Length:"
			' 
			' ArrowLineButton
			' 
			Me.ArrowLineButton.Location = New System.Drawing.Point(4, 238)
			Me.ArrowLineButton.Name = "ArrowLineButton"
			Me.ArrowLineButton.Size = New System.Drawing.Size(172, 24)
			Me.ArrowLineButton.TabIndex = 7
			Me.ArrowLineButton.Text = "Arrow Properties..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ArrowLineButton.Click += new System.EventHandler(this.ArrowLineButton_Click);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(4, 136)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(172, 16)
			Me.label4.TabIndex = 3
			Me.label4.Text = "Format:"
			' 
			' TextFont
			' 
			Me.TextFont.Location = New System.Drawing.Point(4, 268)
			Me.TextFont.Name = "TextFont"
			Me.TextFont.Size = New System.Drawing.Size(172, 23)
			Me.TextFont.TabIndex = 8
			Me.TextFont.Text = "Text Properties..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TextFont.Click += new System.EventHandler(this.TextFont_Click);
			' 
			' FormatCombo
			' 
			Me.FormatCombo.ListProperties.CheckBoxDataMember = ""
			Me.FormatCombo.ListProperties.DataSource = Nothing
			Me.FormatCombo.ListProperties.DisplayMember = ""
			Me.FormatCombo.Location = New System.Drawing.Point(4, 155)
			Me.FormatCombo.Name = "FormatCombo"
			Me.FormatCombo.Size = New System.Drawing.Size(172, 21)
			Me.FormatCombo.TabIndex = 4
			Me.FormatCombo.Text = "comboBox1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FormatCombo.TextChanged += new System.EventHandler(this.FormatCombo_TextChanged);
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FormatCombo.SelectedIndexChanged += new System.EventHandler(this.FormatCombo_SelectedIndexChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(4, 84)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(172, 16)
			Me.label5.TabIndex = 1
			Me.label5.Text = "Vertical Align:"
			' 
			' VertAlignCombo
			' 
			Me.VertAlignCombo.ListProperties.CheckBoxDataMember = ""
			Me.VertAlignCombo.ListProperties.DataSource = Nothing
			Me.VertAlignCombo.ListProperties.DisplayMember = ""
			Me.VertAlignCombo.Location = New System.Drawing.Point(4, 103)
			Me.VertAlignCombo.Name = "VertAlignCombo"
			Me.VertAlignCombo.Size = New System.Drawing.Size(172, 21)
			Me.VertAlignCombo.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.VertAlignCombo.SelectedIndexChanged += new System.EventHandler(this.VertAlignCombo_SelectedIndexChanged);
			' 
			' NSeriesDataLabelAttributeUC
			' 
			Me.Controls.Add(Me.VertAlignCombo)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.FormatCombo)
			Me.Controls.Add(Me.TextFont)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.ArrowLineButton)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.ArrowLengthScroll)
			Me.Controls.Add(Me.DataLabelModeCombo)
			Me.Name = "NSeriesDataLabelAttributeUC"
			Me.Size = New System.Drawing.Size(180, 334)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Series Data Label Attribute")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Axis(StandardAxis.Depth).Visible = False

			' add interlaced stripe to the Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator).StripStyles.Add(stripStyle)

			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.FillStyle = New NGradientFillStyle(Color.LightGray, Color.SlateBlue)
			bar.ShadowStyle.Type = ShadowType.LinearBlur
			bar.ShadowStyle.Offset = New NPointL(3, 3)
			bar.ShadowStyle.Color = Color.FromArgb(40, 0, 0, 0)
			bar.ShadowStyle.FadeLength = New NLength(2)

			bar.AddDataPoint(New NDataPoint(10, "Item 0"))
			bar.AddDataPoint(New NDataPoint(20, "Item 1"))
			bar.AddDataPoint(New NDataPoint(30, "Item 2"))
			bar.AddDataPoint(New NDataPoint(25, "Item 3"))
			bar.AddDataPoint(New NDataPoint(29, "Item 4"))
			bar.AddDataPoint(New NDataPoint(27, "Item 5"))

			' apply style sheet
			Dim fillStyleSheet As New NFillStyleSheetConfigurator()
			fillStyleSheet.SeriesFillTemplate = New NGradientFillStyleTemplate(GradientStyle.Horizontal, GradientVariant.Variant1)
			fillStyleSheet.MultiColorSeries = True
			fillStyleSheet.Palette.SetPredefinedPalette(ChartPredefinedPalette.Nature)
			Dim strokeStyleSheet As New NStrokeStyleSheetConfigurator()
			strokeStyleSheet.MultiColorSeries = True
			strokeStyleSheet.ApplyToDataLabels = False
			strokeStyleSheet.Palette.SetPredefinedPalette(ChartPredefinedPalette.Nature)

			Dim styleSheet As New NStyleSheet()
			fillStyleSheet.ConfigureSheet(styleSheet)
			strokeStyleSheet.ConfigureSheet(styleSheet)
			styleSheet.Apply(bar)

			' add a different data label for data point 3
			Dim label As New NDataLabelStyle()
			label.Format = "Individual"
			label.TextStyle.FontStyle.Style = FontStyle.Bold
			label.TextStyle.FillStyle = New NColorFillStyle(Color.Crimson)
			label.TextStyle.BackplaneStyle.Inflate = New NSizeL(3, 3)
			label.TextStyle.BackplaneStyle.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant2, Color.White, Color.Lavender)
			bar.DataLabelStyles(3) = label

			' init form controls
			FormatCombo.Items.Add("<value> <label>")
			FormatCombo.Items.Add("<index> <cumulative>")
			FormatCombo.Items.Add("<percent> <total>")

			VertAlignCombo.Items.Add("Center")
			VertAlignCombo.Items.Add("Top")
			VertAlignCombo.Items.Add("Bottom")

			DataLabelModeCombo.Items.Add("Edit Default Label")
			DataLabelModeCombo.Items.Add("Edit Data Label #3")
			DataLabelModeCombo.SelectedIndex = 0

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)
		End Sub

		Private Sub DataLabelModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataLabelModeCombo.SelectedIndexChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)

			Select Case DataLabelModeCombo.SelectedIndex
				Case 0
					m_DataLabelStyle = bar.DataLabelStyle

				Case 1
					m_DataLabelStyle = DirectCast(bar.DataLabelStyles(3), NDataLabelStyle)
			End Select

			' init controls from data label
			ArrowLengthScroll.Value = CInt(Math.Truncate(m_DataLabelStyle.ArrowLength.Value))
			FormatCombo.Text = m_DataLabelStyle.Format
			VertAlignCombo.SelectedIndex = CInt(m_DataLabelStyle.VertAlign)
		End Sub

		Private Sub ArrowLengthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles ArrowLengthScroll.ValueChanged
			If nChartControl1 IsNot Nothing Then
				m_DataLabelStyle.ArrowLength = New NLength(ArrowLengthScroll.Value, NGraphicsUnit.Point)
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub ArrowLineButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ArrowLineButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_DataLabelStyle.ArrowStrokeStyle, strokeStyleResult) Then
				m_DataLabelStyle.ArrowStrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub TextFont_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextFont.Click
			Dim textStyleResult As NTextStyle = Nothing

			If NTextStyleTypeEditor.Edit(m_DataLabelStyle.TextStyle, textStyleResult) Then
				m_DataLabelStyle.TextStyle = textStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub FormatCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormatCombo.SelectedIndexChanged
			If nChartControl1 IsNot Nothing Then
				m_DataLabelStyle.Format = FormatCombo.Text
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub FormatCombo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormatCombo.TextChanged
			If nChartControl1 IsNot Nothing Then
				m_DataLabelStyle.Format = FormatCombo.Text
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub VertAlignCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VertAlignCombo.SelectedIndexChanged
			If nChartControl1 IsNot Nothing Then
				m_DataLabelStyle.VertAlign = CType(VertAlignCombo.SelectedIndex, VertAlign)
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
