Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NStandardFunnel2DUC
		Inherits NExampleBaseUC

		Private label2 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private WithEvents ArrowLengthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents NeckWidthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents NeckHeightScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents FunnelGapScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents LabelModeCombo As Nevron.UI.WinForm.Controls.NComboBox
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
			Me.label4 = New System.Windows.Forms.Label()
			Me.NeckWidthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label5 = New System.Windows.Forms.Label()
			Me.NeckHeightScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label6 = New System.Windows.Forms.Label()
			Me.LabelModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.ArrowLengthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.FunnelGapScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.SuspendLayout()
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(6, 46)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(169, 16)
			Me.label4.TabIndex = 4
			Me.label4.Text = "Neck Width:"
			' 
			' NeckWidthScroll
			' 
			Me.NeckWidthScroll.Location = New System.Drawing.Point(6, 61)
			Me.NeckWidthScroll.Maximum = 50
			Me.NeckWidthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.NeckWidthScroll.Name = "NeckWidthScroll"
			Me.NeckWidthScroll.Size = New System.Drawing.Size(169, 16)
			Me.NeckWidthScroll.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.NeckWidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.NeckWidthScroll_Scroll);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(6, 87)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(169, 15)
			Me.label5.TabIndex = 6
			Me.label5.Text = "Neck Height:"
			' 
			' NeckHeightScroll
			' 
			Me.NeckHeightScroll.Location = New System.Drawing.Point(6, 103)
			Me.NeckHeightScroll.Maximum = 50
			Me.NeckHeightScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.NeckHeightScroll.Name = "NeckHeightScroll"
			Me.NeckHeightScroll.Size = New System.Drawing.Size(169, 16)
			Me.NeckHeightScroll.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.NeckHeightScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.NeckHeightScroll_Scroll);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(6, 158)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(169, 16)
			Me.label6.TabIndex = 8
			Me.label6.Text = "Funnel Label Mode:"
			' 
			' LabelModeCombo
			' 
			Me.LabelModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.LabelModeCombo.ListProperties.DataSource = Nothing
			Me.LabelModeCombo.ListProperties.DisplayMember = ""
			Me.LabelModeCombo.Location = New System.Drawing.Point(6, 176)
			Me.LabelModeCombo.Name = "LabelModeCombo"
			Me.LabelModeCombo.Size = New System.Drawing.Size(169, 21)
			Me.LabelModeCombo.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LabelModeCombo.SelectedIndexChanged += new System.EventHandler(this.LabelModeCombo_SelectedIndexChanged);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(6, 210)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(169, 16)
			Me.label7.TabIndex = 10
			Me.label7.Text = "Label Arrow Length:"
			' 
			' ArrowLengthScroll
			' 
			Me.ArrowLengthScroll.LargeChange = 1
			Me.ArrowLengthScroll.Location = New System.Drawing.Point(6, 228)
			Me.ArrowLengthScroll.Maximum = 20
			Me.ArrowLengthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.ArrowLengthScroll.Name = "ArrowLengthScroll"
			Me.ArrowLengthScroll.Size = New System.Drawing.Size(169, 16)
			Me.ArrowLengthScroll.TabIndex = 11
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ArrowLengthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ArrowLengthScroll_Scroll);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(6, 6)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(169, 15)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Funnel Point Gap:"
			' 
			' FunnelGapScroll
			' 
			Me.FunnelGapScroll.Location = New System.Drawing.Point(6, 23)
			Me.FunnelGapScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.FunnelGapScroll.Name = "FunnelGapScroll"
			Me.FunnelGapScroll.Size = New System.Drawing.Size(169, 16)
			Me.FunnelGapScroll.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FunnelGapScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.FunnelGapScroll_Scroll);
			' 
			' NStandardFunnel2DUC
			' 
			Me.Controls.Add(Me.FunnelGapScroll)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.ArrowLengthScroll)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.LabelModeCombo)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.NeckHeightScroll)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.NeckWidthScroll)
			Me.Controls.Add(Me.label4)
			Me.Name = "NStandardFunnel2DUC"
			Me.Size = New System.Drawing.Size(180, 285)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("2D Funnel Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.BottomRight)

			Dim chart As New NFunnelChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(chart)

			Dim funnel As NFunnelSeries = CType(chart.Series.Add(SeriesType.Funnel), NFunnelSeries)
			funnel.BorderStyle.Color = Color.LemonChiffon
			funnel.Legend.DisplayOnLegend = legend
			funnel.Legend.Mode = SeriesLegendMode.DataPoints
			funnel.DataLabelStyle.Format = "<percent>"
			funnel.ShadowStyle.Type = ShadowType.GaussianBlur
			funnel.ShadowStyle.Color = Color.FromArgb(50, 0, 0, 0)
			funnel.ShadowStyle.Offset = New NPointL(5, 5)
			funnel.ShadowStyle.FadeLength = New NLength(6)

			funnel.Values.Add(20.0)
			funnel.Values.Add(10.0)
			funnel.Values.Add(15.0)
			funnel.Values.Add(7.0)
			funnel.Values.Add(28.0)

			funnel.Labels.Add("Awareness")
			funnel.Labels.Add("First Hear")
			funnel.Labels.Add("Further Learn")
			funnel.Labels.Add("Liking")
			funnel.Labels.Add("Decision")

			' apply palette to funnel segments
			Dim palette As New NChartPalette(ChartPredefinedPalette.Fresh)
			For i As Integer = 0 To funnel.Values.Count - 1
				funnel.FillStyles(i) = New NColorFillStyle(palette.SeriesColors(i Mod palette.SeriesColors.Count))
			Next i

			' init form controls
			LabelModeCombo.FillFromEnum(GetType(FunnelLabelMode))
			LabelModeCombo.SelectedIndex = 0

			FunnelGapScroll.Value = CInt(Math.Truncate(funnel.FunnelPointGap))
			NeckWidthScroll.Value = CInt(Math.Truncate(funnel.NeckWidthPercent))
			NeckHeightScroll.Value = CInt(Math.Truncate(funnel.NeckHeightPercent))
			ArrowLengthScroll.Value = CInt(Math.Truncate(funnel.DataLabelStyle.ArrowLength.Value))
		End Sub

		Private Sub LabelModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LabelModeCombo.SelectedIndexChanged
			Dim funnel As NFunnelSeries = CType(nChartControl1.Charts(0).Series(0), NFunnelSeries)

			funnel.LabelMode = CType(LabelModeCombo.SelectedIndex, FunnelLabelMode)

			Dim ha As HorzAlign = HorzAlign.Center

			Select Case funnel.LabelMode
				Case FunnelLabelMode.Left, FunnelLabelMode.LeftAligned
					ha = HorzAlign.Right

				Case FunnelLabelMode.Right, FunnelLabelMode.RightAligned
					ha = HorzAlign.Left
			End Select

			funnel.DataLabelStyle.TextStyle.StringFormatStyle.HorzAlign = ha

			nChartControl1.Refresh()
		End Sub

		Private Sub ArrowLengthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles ArrowLengthScroll.ValueChanged
			Dim funnel As NFunnelSeries = CType(nChartControl1.Charts(0).Series(0), NFunnelSeries)

			funnel.DataLabelStyle.ArrowLength = New NLength(ArrowLengthScroll.Value, NRelativeUnit.ParentPercentage)

			nChartControl1.Refresh()
		End Sub

		Private Sub FunnelGapScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles FunnelGapScroll.ValueChanged
			Dim funnel As NFunnelSeries = CType(nChartControl1.Charts(0).Series(0), NFunnelSeries)

			funnel.FunnelPointGap = FunnelGapScroll.Value / 10.0F

			nChartControl1.Refresh()
		End Sub

		Private Sub NeckWidthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles NeckWidthScroll.ValueChanged
			Dim funnel As NFunnelSeries = CType(nChartControl1.Charts(0).Series(0), NFunnelSeries)

			funnel.NeckWidthPercent = NeckWidthScroll.Value

			nChartControl1.Refresh()
		End Sub

		Private Sub NeckHeightScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles NeckHeightScroll.ValueChanged
			Dim funnel As NFunnelSeries = CType(nChartControl1.Charts(0).Series(0), NFunnelSeries)

			funnel.NeckHeightPercent = NeckHeightScroll.Value

			nChartControl1.Refresh()
		End Sub

	End Class
End Namespace