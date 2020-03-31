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
	Public Class NSeriesLegendAttributeUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart

		Private m_Bar1 As NBarSeries
		Private m_Bar2 As NBarSeries
		Private m_Bar3 As NBarSeries

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private WithEvents LegendModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents FormatCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents BarStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
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
			Me.LegendModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.FormatCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.BarStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(6, 10)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(168, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Mode:"
			' 
			' LegendModeCombo
			' 
			Me.LegendModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.LegendModeCombo.ListProperties.DataSource = Nothing
			Me.LegendModeCombo.ListProperties.DisplayMember = ""
			Me.LegendModeCombo.Location = New System.Drawing.Point(6, 27)
			Me.LegendModeCombo.Name = "LegendModeCombo"
			Me.LegendModeCombo.Size = New System.Drawing.Size(168, 21)
			Me.LegendModeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LegendModeCombo.TextChanged += new System.EventHandler(this.FormatCombo_TextChanged);
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LegendModeCombo.SelectedIndexChanged += new System.EventHandler(this.LegendModeCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(6, 61)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(168, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Format:"
			' 
			' FormatCombo
			' 
			Me.FormatCombo.ListProperties.CheckBoxDataMember = ""
			Me.FormatCombo.ListProperties.DataSource = Nothing
			Me.FormatCombo.ListProperties.DisplayMember = ""
			Me.FormatCombo.Location = New System.Drawing.Point(6, 81)
			Me.FormatCombo.Name = "FormatCombo"
			Me.FormatCombo.Size = New System.Drawing.Size(168, 21)
			Me.FormatCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FormatCombo.TextChanged += new System.EventHandler(this.FormatCombo_TextChanged);
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FormatCombo.SelectedIndexChanged += new System.EventHandler(this.FormatCombo_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(6, 115)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(168, 16)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Bar Style:"
			' 
			' BarStyleCombo
			' 
			Me.BarStyleCombo.ListProperties.CheckBoxDataMember = ""
			Me.BarStyleCombo.ListProperties.DataSource = Nothing
			Me.BarStyleCombo.ListProperties.DisplayMember = ""
			Me.BarStyleCombo.Location = New System.Drawing.Point(6, 135)
			Me.BarStyleCombo.Name = "BarStyleCombo"
			Me.BarStyleCombo.Size = New System.Drawing.Size(168, 21)
			Me.BarStyleCombo.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarStyleCombo.SelectedIndexChanged += new System.EventHandler(this.BarStyleCombo_SelectedIndexChanged);
			' 
			' NSeriesLegendAttributeUC
			' 
			Me.Controls.Add(Me.BarStyleCombo)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.FormatCombo)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.LegendModeCombo)
			Me.Controls.Add(Me.label1)
			Me.Name = "NSeriesLegendAttributeUC"
			Me.Size = New System.Drawing.Size(180, 255)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Series Legend Attributes")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.DockMode = PanelDockMode.Top
			header.Margins = New NMarginsL(0, 10, 0, 10)

			nChartControl1.Panels.Add(header)

			Dim legend As New NLegend()
			legend.DockMode = PanelDockMode.Right
			legend.Data.ExpandMode = LegendExpandMode.ColsFixed
			legend.Data.ColCount = 2
			legend.Mode = LegendMode.Automatic
			legend.BoundsMode = BoundsMode.Fit
			legend.Margins = New NMarginsL(0, 0, 10, 0)
			nChartControl1.Panels.Add(legend)

			' create the chart
			m_Chart = New NCartesianChart()
			m_Chart.Enable3D = True
			nChartControl1.Panels.Add(m_Chart)
			m_Chart.DockMode = PanelDockMode.Fill
			m_Chart.BoundsMode = BoundsMode.Fit

			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			m_Chart.Margins = New NMarginsL(40, 10, 20, 30)
			m_Chart.DisplayOnLegend = legend
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' add the first bar
			m_Bar1 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar1.Name = "Bar1"
			m_Bar1.MultiBarMode = MultiBarMode.Series

			' add the second bar
			m_Bar2 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar2.Name = "Bar2"
			m_Bar2.MultiBarMode = MultiBarMode.Stacked

			' add the third bar
			m_Bar3 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar3.Name = "Bar3"
			m_Bar3.MultiBarMode = MultiBarMode.Stacked

			' position data labels in the center of the bars
			m_Bar1.DataLabelStyle.Visible = True
			m_Bar1.DataLabelStyle.VertAlign = VertAlign.Center
			m_Bar1.DataLabelStyle.Format = "<value>"

			m_Bar2.DataLabelStyle.Visible = True
			m_Bar2.DataLabelStyle.VertAlign = VertAlign.Center
			m_Bar2.DataLabelStyle.Format = "<value>"

			m_Bar3.DataLabelStyle.Visible = True
			m_Bar3.DataLabelStyle.VertAlign = VertAlign.Center
			m_Bar3.DataLabelStyle.Format = "<value>"

			' fill some random data
			m_Bar1.Values.FillRandomRange(Random, 6, 20, 100)
			m_Bar2.Values.FillRandomRange(Random, 6, 20, 100)
			m_Bar3.Values.FillRandomRange(Random, 6, 20, 100)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			FormatCombo.Items.Add("<value> <label>")
			FormatCombo.Items.Add("<index> <cumulative>")
			FormatCombo.Items.Add("<percent> <total>")
			FormatCombo.Text = m_Bar1.Legend.Format

			LegendModeCombo.FillFromEnum(GetType(SeriesLegendMode))
			LegendModeCombo.SelectedIndex = CInt(SeriesLegendMode.DataPoints)

			BarStyleCombo.FillFromEnum(GetType(BarShape))
			BarStyleCombo.SelectedIndex = CInt(BarShape.Bar)
		End Sub

		Private Sub LegendModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LegendModeCombo.SelectedIndexChanged
			m_Bar1.Legend.Mode = CType(LegendModeCombo.SelectedIndex, SeriesLegendMode)
			m_Bar2.Legend.Mode = CType(LegendModeCombo.SelectedIndex, SeriesLegendMode)
			m_Bar3.Legend.Mode = CType(LegendModeCombo.SelectedIndex, SeriesLegendMode)

			nChartControl1.Refresh()
		End Sub

		Private Sub FormatCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormatCombo.SelectedIndexChanged
			m_Bar1.Legend.Format = FormatCombo.Text
			m_Bar2.Legend.Format = FormatCombo.Text
			m_Bar3.Legend.Format = FormatCombo.Text

			nChartControl1.Refresh()
		End Sub

		Private Sub FormatCombo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LegendModeCombo.TextChanged, FormatCombo.TextChanged
			m_Bar1.Legend.Format = FormatCombo.Text
			m_Bar2.Legend.Format = FormatCombo.Text
			m_Bar3.Legend.Format = FormatCombo.Text

			nChartControl1.Refresh()
		End Sub

		Private Sub BarStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BarStyleCombo.SelectedIndexChanged
			m_Bar1.BarShape = CType(BarStyleCombo.SelectedIndex, BarShape)
			m_Bar2.BarShape = CType(BarStyleCombo.SelectedIndex, BarShape)
			m_Bar3.BarShape = CType(BarStyleCombo.SelectedIndex, BarShape)

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
