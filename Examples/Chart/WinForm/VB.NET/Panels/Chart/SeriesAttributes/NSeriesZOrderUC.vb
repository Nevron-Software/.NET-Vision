Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports System.Diagnostics

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NSeriesZOrderUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart

		Private m_Bar1 As NBarSeries
		Private m_Bar2 As NBarSeries
		Private m_Bar3 As NBarSeries

		Private label1 As System.Windows.Forms.Label
		Private WithEvents ZOrderModeCombo As Nevron.UI.WinForm.Controls.NComboBox
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
			Me.ZOrderModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(6, 10)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(168, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Z Order:"
			' 
			' ZOrderModeCombo
			' 
			Me.ZOrderModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.ZOrderModeCombo.ListProperties.DataSource = Nothing
			Me.ZOrderModeCombo.ListProperties.DisplayMember = ""
			Me.ZOrderModeCombo.Location = New System.Drawing.Point(6, 27)
			Me.ZOrderModeCombo.Name = "ZOrderModeCombo"
			Me.ZOrderModeCombo.Size = New System.Drawing.Size(168, 21)
			Me.ZOrderModeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ZOrderModeCombo.SelectedIndexChanged += new System.EventHandler(this.ZOrderModeCombo_SelectedIndexChanged);
			' 
			' NSeriesZOrderUC
			' 
			Me.Controls.Add(Me.ZOrderModeCombo)
			Me.Controls.Add(Me.label1)
			Me.Name = "NSeriesZOrderUC"
			Me.Size = New System.Drawing.Size(180, 255)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Series Z Order")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.DockMode = PanelDockMode.Top
			header.Margins = New NMarginsL(0, 10, 0, 10)

			nChartControl1.Panels.Add(header)

			Dim legend As New NLegend()
			legend.DockMode = PanelDockMode.Right
			legend.Margins = New NMarginsL(0, 0, 10, 0)
			nChartControl1.Panels.Add(legend)

			' create the chart
			m_Chart = New NCartesianChart()
			nChartControl1.Panels.Add(m_Chart)
			m_Chart.DockMode = PanelDockMode.Fill
			m_Chart.BoundsMode = BoundsMode.Stretch

			m_Chart.Margins = New NMarginsL(40, 10, 20, 30)
			m_Chart.DisplayOnLegend = legend
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' add the first bar
			m_Bar1 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar1.WidthPercent = 80
			m_Bar1.Name = "Bar1"

			' add the second bar
			m_Bar2 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar2.WidthPercent = 60
			m_Bar2.Name = "Bar2"

			' add the third bar
			m_Bar3 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar3.WidthPercent = 40
			m_Bar3.Name = "Bar3"

			' position data labels in the center of the bars
			m_Bar1.DataLabelStyle.Visible = False
			m_Bar2.DataLabelStyle.Visible = False
			m_Bar3.DataLabelStyle.Visible = False

			' fill some random data
			m_Bar1.Values.FillRandomRange(Random, 6, 20, 100)
			m_Bar2.Values.FillRandomRange(Random, 6, 20, 100)
			m_Bar3.Values.FillRandomRange(Random, 6, 20, 100)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			ZOrderModeCombo.Items.Add("123")
			ZOrderModeCombo.Items.Add("321")
			ZOrderModeCombo.SelectedIndex = 0
		End Sub

		Private Sub ZOrderModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ZOrderModeCombo.SelectedIndexChanged
			Select Case ZOrderModeCombo.SelectedIndex
				Case 0
					m_Bar1.ZOrder = 1
					m_Bar2.ZOrder = 2
					m_Bar3.ZOrder = 3
				Case 1
					m_Bar1.ZOrder = 3
					m_Bar2.ZOrder = 2
					m_Bar3.ZOrder = 1
				Case Else
					Debug.Assert(False)
			End Select

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
