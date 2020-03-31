Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Diagnostics
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NAdvancedFunnel3DUC
		Inherits NExampleBaseUC

		Private label2 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private WithEvents ArrowLengthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents FunnelGapScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents FunnelRadiusScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents LabelModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents NewDataButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.label6 = New System.Windows.Forms.Label()
			Me.LabelModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.ArrowLengthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.FunnelGapScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.FunnelRadiusScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label9 = New System.Windows.Forms.Label()
			Me.NewDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(7, 112)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(164, 16)
			Me.label6.TabIndex = 4
			Me.label6.Text = "Funnel Label Mode:"
			' 
			' LabelModeCombo
			' 
			Me.LabelModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.LabelModeCombo.ListProperties.DataSource = Nothing
			Me.LabelModeCombo.ListProperties.DisplayMember = ""
			Me.LabelModeCombo.Location = New System.Drawing.Point(7, 130)
			Me.LabelModeCombo.Name = "LabelModeCombo"
			Me.LabelModeCombo.Size = New System.Drawing.Size(164, 21)
			Me.LabelModeCombo.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LabelModeCombo.SelectedIndexChanged += new System.EventHandler(this.LabelModeCombo_SelectedIndexChanged);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(7, 164)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(164, 16)
			Me.label7.TabIndex = 6
			Me.label7.Text = "Label Arrow Length:"
			' 
			' ArrowLengthScroll
			' 
			Me.ArrowLengthScroll.LargeChange = 1
			Me.ArrowLengthScroll.Location = New System.Drawing.Point(7, 182)
			Me.ArrowLengthScroll.Maximum = 20
			Me.ArrowLengthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.ArrowLengthScroll.Name = "ArrowLengthScroll"
			Me.ArrowLengthScroll.Size = New System.Drawing.Size(164, 16)
			Me.ArrowLengthScroll.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ArrowLengthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ArrowLengthScroll_Scroll);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(7, 49)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(164, 15)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Funnel Point Gap:"
			' 
			' FunnelGapScroll
			' 
			Me.FunnelGapScroll.Location = New System.Drawing.Point(7, 66)
			Me.FunnelGapScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.FunnelGapScroll.Name = "FunnelGapScroll"
			Me.FunnelGapScroll.Size = New System.Drawing.Size(164, 16)
			Me.FunnelGapScroll.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FunnelGapScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.FunnelGapScroll_Scroll);
			' 
			' FunnelRadiusScroll
			' 
			Me.FunnelRadiusScroll.Location = New System.Drawing.Point(7, 27)
			Me.FunnelRadiusScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.FunnelRadiusScroll.Name = "FunnelRadiusScroll"
			Me.FunnelRadiusScroll.Size = New System.Drawing.Size(164, 16)
			Me.FunnelRadiusScroll.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FunnelRadiusScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.FunnelRadiusScroll_Scroll);
			' 
			' label9
			' 
			Me.label9.Location = New System.Drawing.Point(7, 9)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(164, 15)
			Me.label9.TabIndex = 0
			Me.label9.Text = "Funnel Radius:"
			' 
			' NewDataButton
			' 
			Me.NewDataButton.Location = New System.Drawing.Point(7, 240)
			Me.NewDataButton.Name = "NewDataButton"
			Me.NewDataButton.Size = New System.Drawing.Size(164, 28)
			Me.NewDataButton.TabIndex = 8
			Me.NewDataButton.Text = "New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.NewDataButton.Click += new System.EventHandler(this.NewDataButton_Click);
			' 
			' NAdvancedFunnel3DUC
			' 
			Me.Controls.Add(Me.NewDataButton)
			Me.Controls.Add(Me.FunnelRadiusScroll)
			Me.Controls.Add(Me.label9)
			Me.Controls.Add(Me.FunnelGapScroll)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.ArrowLengthScroll)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.LabelModeCombo)
			Me.Controls.Add(Me.label6)
			Me.Name = "NAdvancedFunnel3DUC"
			Me.Size = New System.Drawing.Size(180, 290)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("3D Funnel Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.BottomRight)

			Dim chart As New NFunnelChart()
			chart.Enable3D = True
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight)
			chart.Projection.Elevation = 15

			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(chart)

			Dim funnel As NFunnelSeries = CType(chart.Series.Add(SeriesType.Funnel), NFunnelSeries)
			funnel.BorderStyle.Color = Color.LemonChiffon
			funnel.Legend.DisplayOnLegend = legend
			funnel.Legend.Format = "<percent>"
			funnel.Legend.Mode = SeriesLegendMode.DataPoints
			funnel.DataLabelStyle.Format = "<value> [<xsize>]"
			funnel.UseXSizes = True
			funnel.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			funnel.XSizes.ValueFormatter = New NNumericValueFormatter("0.00")

			GenerateData(funnel)

			' init form controls
			LabelModeCombo.FillFromEnum(GetType(FunnelLabelMode))
			LabelModeCombo.SelectedIndex = 4

			FunnelGapScroll.Value = 6
			FunnelRadiusScroll.Value = CInt(chart.Width)
			ArrowLengthScroll.Value = CInt(Math.Truncate(funnel.DataLabelStyle.ArrowLength.Value))
		End Sub


		Private Sub GenerateData(ByVal funnel As NFunnelSeries)
			funnel.ClearDataPoints()

			Dim dSizeX As Double = 100
			Dim palette As New NChartPalette(ChartPredefinedPalette.Fresh)

			For i As Integer = 0 To 9
				funnel.Values.Add(Random.NextDouble() + 1)
				funnel.XSizes.Add(dSizeX)
				funnel.FillStyles(i) = New NColorFillStyle(palette.SeriesColors(i Mod palette.SeriesColors.Count))

				dSizeX -= Random.NextDouble() * 9
			Next i

			funnel.Values.Add(0.0)
			funnel.XSizes.Add(dSizeX)
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

		Private Sub FunnelRadiusScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles FunnelRadiusScroll.ValueChanged
			nChartControl1.Charts(0).Width = FunnelRadiusScroll.Value
			nChartControl1.Refresh()
		End Sub

		Private Sub FunnelGapScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles FunnelGapScroll.ValueChanged
			Dim funnel As NFunnelSeries = CType(nChartControl1.Charts(0).Series(0), NFunnelSeries)

			funnel.FunnelPointGap = FunnelGapScroll.Value / 10.0F

			nChartControl1.Refresh()
		End Sub

		Private Sub NewDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewDataButton.Click
			Dim funnel As NFunnelSeries = CType(nChartControl1.Charts(0).Series(0), NFunnelSeries)

			GenerateData(funnel)

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace