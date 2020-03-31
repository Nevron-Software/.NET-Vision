Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.Functions

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NLegendDockingUC
		Inherits NExampleBaseUC

		Private m_Chart1 As NChart
		Private m_Chart2 As NChart
		Private m_Legend As NLegend
		Private m_bEnableUpdate As Boolean
		Private WithEvents DockStyleComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents DockPanelComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents LegendExpandModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents RowCountUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ColCountUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents BoundsModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents FitAlignmentComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
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
			Me.DockStyleComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.DockPanelComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.LegendExpandModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.RowCountUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label5 = New System.Windows.Forms.Label()
			Me.ColCountUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label7 = New System.Windows.Forms.Label()
			Me.BoundsModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.FitAlignmentComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			DirectCast(Me.RowCountUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.ColCountUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(168, 20)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Dock Style:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' DockStyleComboBox
			' 
			Me.DockStyleComboBox.ListProperties.CheckBoxDataMember = ""
			Me.DockStyleComboBox.ListProperties.DataSource = Nothing
			Me.DockStyleComboBox.ListProperties.DisplayMember = ""
			Me.DockStyleComboBox.Location = New System.Drawing.Point(8, 30)
			Me.DockStyleComboBox.Name = "DockStyleComboBox"
			Me.DockStyleComboBox.Size = New System.Drawing.Size(168, 21)
			Me.DockStyleComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DockStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.DockStyleComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 53)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(168, 20)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Dock Panel:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' DockPanelComboBox
			' 
			Me.DockPanelComboBox.ListProperties.CheckBoxDataMember = ""
			Me.DockPanelComboBox.ListProperties.DataSource = Nothing
			Me.DockPanelComboBox.ListProperties.DisplayMember = ""
			Me.DockPanelComboBox.Location = New System.Drawing.Point(8, 75)
			Me.DockPanelComboBox.Name = "DockPanelComboBox"
			Me.DockPanelComboBox.Size = New System.Drawing.Size(168, 21)
			Me.DockPanelComboBox.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DockPanelComboBox.SelectedIndexChanged += new System.EventHandler(this.DockPanelComboBox_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 188)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(168, 20)
			Me.label3.TabIndex = 8
			Me.label3.Text = "Legend Expand Mode:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' LegendExpandModeComboBox
			' 
			Me.LegendExpandModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.LegendExpandModeComboBox.ListProperties.DataSource = Nothing
			Me.LegendExpandModeComboBox.ListProperties.DisplayMember = ""
			Me.LegendExpandModeComboBox.Location = New System.Drawing.Point(8, 210)
			Me.LegendExpandModeComboBox.Name = "LegendExpandModeComboBox"
			Me.LegendExpandModeComboBox.Size = New System.Drawing.Size(168, 21)
			Me.LegendExpandModeComboBox.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LegendExpandModeComboBox.SelectedIndexChanged += new System.EventHandler(this.LegendExpandModeComboBox_SelectedIndexChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(8, 233)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(168, 20)
			Me.label6.TabIndex = 10
			Me.label6.Text = "Row Count:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' RowCountUpDown
			' 
			Me.RowCountUpDown.Location = New System.Drawing.Point(8, 255)
			Me.RowCountUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.RowCountUpDown.Name = "RowCountUpDown"
			Me.RowCountUpDown.Size = New System.Drawing.Size(168, 20)
			Me.RowCountUpDown.TabIndex = 11
			Me.RowCountUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RowCountUpDown.ValueChanged += new System.EventHandler(this.RowCountUpDown_ValueChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 277)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(168, 20)
			Me.label5.TabIndex = 12
			Me.label5.Text = "Col Count:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ColCountUpDown
			' 
			Me.ColCountUpDown.Location = New System.Drawing.Point(8, 299)
			Me.ColCountUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.ColCountUpDown.Name = "ColCountUpDown"
			Me.ColCountUpDown.Size = New System.Drawing.Size(168, 20)
			Me.ColCountUpDown.TabIndex = 13
			Me.ColCountUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ColCountUpDown.ValueChanged += new System.EventHandler(this.ColCountUpDown_ValueChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 143)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(168, 20)
			Me.label4.TabIndex = 6
			Me.label4.Text = "Legend Fit Alignment:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(8, 98)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(168, 20)
			Me.label7.TabIndex = 4
			Me.label7.Text = "Bounds Mode:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' BoundsModeComboBox
			' 
			Me.BoundsModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.BoundsModeComboBox.ListProperties.DataSource = Nothing
			Me.BoundsModeComboBox.ListProperties.DisplayMember = ""
			Me.BoundsModeComboBox.Location = New System.Drawing.Point(8, 120)
			Me.BoundsModeComboBox.Name = "BoundsModeComboBox"
			Me.BoundsModeComboBox.Size = New System.Drawing.Size(168, 21)
			Me.BoundsModeComboBox.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BoundsModeComboBox.SelectedIndexChanged += new System.EventHandler(this.BoundsModeComboBox_SelectedIndexChanged);
			' 
			' FitAlignmentComboBox
			' 
			Me.FitAlignmentComboBox.ListProperties.CheckBoxDataMember = ""
			Me.FitAlignmentComboBox.ListProperties.DataSource = Nothing
			Me.FitAlignmentComboBox.ListProperties.DisplayMember = ""
			Me.FitAlignmentComboBox.Location = New System.Drawing.Point(8, 165)
			Me.FitAlignmentComboBox.Name = "FitAlignmentComboBox"
			Me.FitAlignmentComboBox.Size = New System.Drawing.Size(168, 21)
			Me.FitAlignmentComboBox.TabIndex = 14
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FitAlignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.FitAlignmentComboBox_SelectedIndexChanged);
			' 
			' NLegendDockingUC
			' 
			Me.Controls.Add(Me.FitAlignmentComboBox)
			Me.Controls.Add(Me.BoundsModeComboBox)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.RowCountUpDown)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.ColCountUpDown)
			Me.Controls.Add(Me.LegendExpandModeComboBox)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.DockPanelComboBox)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.DockStyleComboBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NLegendDockingUC"
			Me.Size = New System.Drawing.Size(180, 432)
			DirectCast(Me.RowCountUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.ColCountUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' clear panels
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Legend Docking")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.DockMode = PanelDockMode.Top
			title.Margins = New NMarginsL(10, 10, 10, 10)
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			m_Legend = New NLegend()
			m_Legend.ContentAlignment = ContentAlignment.BottomRight
			m_Legend.Mode = LegendMode.Automatic
			m_Legend.Data.ExpandMode = LegendExpandMode.RowsFixed
			m_Legend.ShadowStyle.Type = ShadowType.Solid
			m_Legend.Margins = New NMarginsL(10, 10, 10, 10)

			m_Chart1 = New NCartesianChart()
			nChartControl1.Panels.Add(m_Chart1)

			' configure charts with explicit positioning
			m_Chart1.BoundsMode = BoundsMode.Stretch
			m_Chart1.DockMode = PanelDockMode.Top
			m_Chart1.ContentAlignment = ContentAlignment.MiddleCenter
			m_Chart1.Size = New NSizeL(New NLength(100, NRelativeUnit.ParentPercentage), New NLength(45, NRelativeUnit.ParentPercentage))
			m_Chart1.Margins = New NMarginsL(10, 10, 10, 10)
			ConfigureChart(m_Chart1, Color.YellowGreen)

			m_Chart2 = New NCartesianChart()
			m_Chart2.Margins = New NMarginsL(10, 10, 10, 10)
			nChartControl1.Panels.Add(m_Chart2)

			m_Chart2.BoundsMode = BoundsMode.Stretch
			m_Chart2.DockMode = PanelDockMode.Top
			m_Chart2.ContentAlignment = ContentAlignment.MiddleCenter
			m_Chart2.Size = New NSizeL(New NLength(100, NRelativeUnit.ParentPercentage), New NLength(45, NRelativeUnit.ParentPercentage))
			ConfigureChart(m_Chart2, Color.Orange)

			' configure combo boxes
			m_bEnableUpdate = False
			DockStyleComboBox.Items.Add("Left")
			DockStyleComboBox.Items.Add("Top")
			DockStyleComboBox.Items.Add("Right")
			DockStyleComboBox.Items.Add("Bottom")
			DockStyleComboBox.Items.Add("Fill")
			DockStyleComboBox.SelectedIndex = 0

			DockPanelComboBox.Items.Add("Control")
			DockPanelComboBox.Items.Add("Chart 1")
			DockPanelComboBox.Items.Add("Chart 2")
			DockPanelComboBox.SelectedIndex = 0

			LegendExpandModeComboBox.Items.Add("Rows only")
			LegendExpandModeComboBox.Items.Add("Cols only")
			LegendExpandModeComboBox.Items.Add("Rows fixed")
			LegendExpandModeComboBox.Items.Add("Cols fixed")
			LegendExpandModeComboBox.SelectedIndex = CInt(m_Legend.Data.ExpandMode)

			BoundsModeComboBox.Items.Add("None")
			BoundsModeComboBox.Items.Add("Fit")
			BoundsModeComboBox.Items.Add("Stretch")
			BoundsModeComboBox.SelectedIndex = CInt(m_Legend.BoundsMode)

			Dim names() As String = System.Enum.GetNames(GetType(ContentAlignment))
			For i As Integer = 0 To names.Length - 1
				FitAlignmentComboBox.Items.Add(names(i))
			Next i

			FitAlignmentComboBox.SelectedItem = m_Legend.ContentAlignment.ToString()

			RowCountUpDown.Value = CDec(m_Legend.Data.RowCount)
			ColCountUpDown.Value = CDec(m_Legend.Data.ColCount)

			m_bEnableUpdate = True

			ConfigureLegend()
		End Sub

		Private Sub ConfigureLegend()
			If m_bEnableUpdate = False Then
				Return
			End If

			' first remove the legend
			If nChartControl1.Panels.Contains(m_Legend) Then
				nChartControl1.Panels.Remove(m_Legend)
			End If

			m_Chart1.DisplayOnLegend = Nothing
			m_Chart1.ChildPanels.Clear()

			m_Chart2.DisplayOnLegend = Nothing
			m_Chart2.ChildPanels.Clear()

			' configure the legend dock style
			Select Case DockStyleComboBox.SelectedIndex
				Case 0 ' Left
					m_Legend.DockMode = PanelDockMode.Left
				Case 1 ' Top
					m_Legend.DockMode = PanelDockMode.Top
				Case 2 ' Right
					m_Legend.DockMode = PanelDockMode.Right
				Case 3 ' Bottom
					m_Legend.DockMode = PanelDockMode.Bottom
				Case 4 ' Fill
					m_Legend.DockMode = PanelDockMode.Fill
				Case Else
					Debug.Assert(False)
			End Select

			' pupulate the legend with data according to dock panels
			Select Case DockPanelComboBox.SelectedIndex
				Case 0
					' Control (insert the legend after the label which is first)
					nChartControl1.Panels.Insert(1, m_Legend)
					m_Chart1.DisplayOnLegend = m_Legend
					m_Chart2.DisplayOnLegend = m_Legend
				Case 1
					m_Chart1.ChildPanels.Add(m_Legend)
					m_Chart1.DisplayOnLegend = m_Legend
				Case 2
					m_Chart2.ChildPanels.Add(m_Legend)
					m_Chart2.DisplayOnLegend = m_Legend
				Case Else
					Debug.Assert(False)
			End Select

			' configure the legend dock style
			m_Legend.Data.ExpandMode = CType(LegendExpandModeComboBox.SelectedIndex, LegendExpandMode)

			Dim values As Array = System.Enum.GetValues(GetType(ContentAlignment))
			m_Legend.FitAlignment = DirectCast(values.GetValue(FitAlignmentComboBox.SelectedIndex), ContentAlignment)
			m_Legend.Data.RowCount = CInt(Math.Truncate(RowCountUpDown.Value))
			m_Legend.Data.ColCount = CInt(Math.Truncate(ColCountUpDown.Value))
			m_Legend.BoundsMode = CType(BoundsModeComboBox.SelectedIndex, BoundsMode)

			nChartControl1.Refresh()
		End Sub

		Private Sub ConfigureChart(ByVal chart As NChart, ByVal color As Color)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Wall(ChartWallType.Floor).Visible = False
			chart.Wall(ChartWallType.Left).Visible = False
			chart.Wall(ChartWallType.Back).Width = 0
			chart.Wall(ChartWallType.Back).FillStyle = New NColorFillStyle(System.Drawing.Color.FromArgb(239, 245, 239))
			chart.Wall(ChartWallType.Back).ShadowStyle.Type = ShadowType.Solid

			' create a bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar 1"
			bar.Legend.Mode = SeriesLegendMode.DataPoints
			bar.DataLabelStyle.Visible = False
			bar.InflateMargins = True
			bar.FillStyle = New NColorFillStyle(color)
			bar.Values.ValueFormatter = New NNumericValueFormatter("0.00")

			For i As Integer = 0 To 14
				bar.Values.Add(Random.NextDouble() * 900)
			Next i
		End Sub


		Private Sub DockStyleComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DockStyleComboBox.SelectedIndexChanged
			ConfigureLegend()
		End Sub

		Private Sub DockPanelComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DockPanelComboBox.SelectedIndexChanged
			ConfigureLegend()
		End Sub

		Private Sub LegendExpandModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LegendExpandModeComboBox.SelectedIndexChanged
			ConfigureLegend()

			Select Case CType(LegendExpandModeComboBox.SelectedIndex, LegendExpandMode)
				Case LegendExpandMode.RowsOnly
					RowCountUpDown.Enabled = False
					ColCountUpDown.Enabled = False
				Case LegendExpandMode.ColsOnly
					RowCountUpDown.Enabled = False
					ColCountUpDown.Enabled = False
				Case LegendExpandMode.RowsFixed
					RowCountUpDown.Enabled = True
					ColCountUpDown.Enabled = False
				Case LegendExpandMode.ColsFixed
					RowCountUpDown.Enabled = False
					ColCountUpDown.Enabled = True
			End Select
		End Sub

		Private Sub RowCountUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RowCountUpDown.ValueChanged
			ConfigureLegend()
		End Sub

		Private Sub ColCountUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ColCountUpDown.ValueChanged
			ConfigureLegend()
		End Sub

		Private Sub BoundsModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BoundsModeComboBox.SelectedIndexChanged
			ConfigureLegend()
		End Sub

		Private Sub FitAlignmentComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FitAlignmentComboBox.SelectedIndexChanged
			ConfigureLegend()
		End Sub
	End Class
End Namespace
