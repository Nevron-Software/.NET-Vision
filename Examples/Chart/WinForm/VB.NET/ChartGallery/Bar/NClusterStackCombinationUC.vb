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
	<ToolboxItem(False)> _
	Public Class NClusterStackCombinationUC
		Inherits NExampleBaseUC

		Private m_Bar1 As NBarSeries
		Private m_Bar2 As NBarSeries
		Private m_Bar3 As NBarSeries
		Private WithEvents WidthScroller As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents GapPercentScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents ScaleSecondCluster As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents PositiveNegativeData As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PositiveData As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents StyleCombo1 As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents StyleCombo2 As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents StyleCombo3 As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private WithEvents ShowDataLabelsCheck As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.WidthScroller = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.GapPercentScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.ScaleSecondCluster = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.PositiveNegativeData = New Nevron.UI.WinForm.Controls.NButton()
			Me.PositiveData = New Nevron.UI.WinForm.Controls.NButton()
			Me.label2 = New System.Windows.Forms.Label()
			Me.StyleCombo1 = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.StyleCombo2 = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.StyleCombo3 = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.ShowDataLabelsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' WidthScroller
			' 
			Me.WidthScroller.LargeChange = 1
			Me.WidthScroller.Location = New System.Drawing.Point(7, 70)
			Me.WidthScroller.MinimumSize = New System.Drawing.Size(32, 16)
			Me.WidthScroller.Name = "WidthScroller"
			Me.WidthScroller.Size = New System.Drawing.Size(160, 16)
			Me.WidthScroller.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WidthScroller.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WidthScroller_Scroll);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(7, 52)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(160, 16)
			Me.label5.TabIndex = 2
			Me.label5.Text = "Width Percent:"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(7, 7)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(160, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Gap Percent:"
			' 
			' GapPercentScrollBar
			' 
			Me.GapPercentScrollBar.LargeChange = 1
			Me.GapPercentScrollBar.Location = New System.Drawing.Point(7, 26)
			Me.GapPercentScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.GapPercentScrollBar.Name = "GapPercentScrollBar"
			Me.GapPercentScrollBar.Size = New System.Drawing.Size(160, 16)
			Me.GapPercentScrollBar.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GapPercentScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.GapPercentScrollBar_Scroll);
			' 
			' ScaleSecondCluster
			' 
			Me.ScaleSecondCluster.ButtonProperties.BorderOffset = 2
			Me.ScaleSecondCluster.ButtonProperties.WrapText = True
			Me.ScaleSecondCluster.Location = New System.Drawing.Point(9, 103)
			Me.ScaleSecondCluster.Name = "ScaleSecondCluster"
			Me.ScaleSecondCluster.Size = New System.Drawing.Size(160, 33)
			Me.ScaleSecondCluster.TabIndex = 4
			Me.ScaleSecondCluster.Text = "Scale the second cluster on the secondary Y axis"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ScaleSecondCluster.CheckedChanged += new System.EventHandler(this.ScaleSecondCluster_CheckedChanged);
			' 
			' PositiveNegativeData
			' 
			Me.PositiveNegativeData.Location = New System.Drawing.Point(7, 212)
			Me.PositiveNegativeData.Name = "PositiveNegativeData"
			Me.PositiveNegativeData.Size = New System.Drawing.Size(160, 24)
			Me.PositiveNegativeData.TabIndex = 6
			Me.PositiveNegativeData.Text = "Positive and Negative Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositiveNegativeData.Click += new System.EventHandler(this.PositiveNegativeData_Click);
			' 
			' PositiveData
			' 
			Me.PositiveData.Location = New System.Drawing.Point(7, 182)
			Me.PositiveData.Name = "PositiveData"
			Me.PositiveData.Size = New System.Drawing.Size(160, 23)
			Me.PositiveData.TabIndex = 5
			Me.PositiveData.Text = "Positive Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositiveData.Click += new System.EventHandler(this.PositiveData_Click);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(7, 265)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(160, 16)
			Me.label2.TabIndex = 7
			Me.label2.Text = "Bar1 Style:"
			' 
			' StyleCombo1
			' 
			Me.StyleCombo1.ListProperties.CheckBoxDataMember = ""
			Me.StyleCombo1.ListProperties.DataSource = Nothing
			Me.StyleCombo1.ListProperties.DisplayMember = ""
			Me.StyleCombo1.Location = New System.Drawing.Point(7, 281)
			Me.StyleCombo1.Name = "StyleCombo1"
			Me.StyleCombo1.Size = New System.Drawing.Size(160, 21)
			Me.StyleCombo1.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StyleCombo1.SelectedIndexChanged += new System.EventHandler(this.StyleCombo1_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(7, 321)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(160, 16)
			Me.label3.TabIndex = 9
			Me.label3.Text = "Bar2 Style:"
			' 
			' StyleCombo2
			' 
			Me.StyleCombo2.ListProperties.CheckBoxDataMember = ""
			Me.StyleCombo2.ListProperties.DataSource = Nothing
			Me.StyleCombo2.ListProperties.DisplayMember = ""
			Me.StyleCombo2.Location = New System.Drawing.Point(7, 337)
			Me.StyleCombo2.Name = "StyleCombo2"
			Me.StyleCombo2.Size = New System.Drawing.Size(160, 21)
			Me.StyleCombo2.TabIndex = 10
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StyleCombo2.SelectedIndexChanged += new System.EventHandler(this.StyleCombo2_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(7, 378)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(160, 16)
			Me.label4.TabIndex = 11
			Me.label4.Text = "Bar3 Style:"
			' 
			' StyleCombo3
			' 
			Me.StyleCombo3.ListProperties.CheckBoxDataMember = ""
			Me.StyleCombo3.ListProperties.DataSource = Nothing
			Me.StyleCombo3.ListProperties.DisplayMember = ""
			Me.StyleCombo3.Location = New System.Drawing.Point(7, 394)
			Me.StyleCombo3.Name = "StyleCombo3"
			Me.StyleCombo3.Size = New System.Drawing.Size(160, 21)
			Me.StyleCombo3.TabIndex = 12
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StyleCombo3.SelectedIndexChanged += new System.EventHandler(this.StyleCombo3_SelectedIndexChanged);
			' 
			' ShowDataLabelsCheck
			' 
			Me.ShowDataLabelsCheck.ButtonProperties.BorderOffset = 2
			Me.ShowDataLabelsCheck.ButtonProperties.WrapText = True
			Me.ShowDataLabelsCheck.Location = New System.Drawing.Point(9, 146)
			Me.ShowDataLabelsCheck.Name = "ShowDataLabelsCheck"
			Me.ShowDataLabelsCheck.Size = New System.Drawing.Size(160, 19)
			Me.ShowDataLabelsCheck.TabIndex = 13
			Me.ShowDataLabelsCheck.Text = "Show Data Labels"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowDataLabelsCheck.CheckedChanged += new System.EventHandler(this.ShowDataLabelsCheck_CheckedChanged);
			' 
			' NClusterStackCombinationUC
			' 
			Me.Controls.Add(Me.ShowDataLabelsCheck)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.StyleCombo3)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.StyleCombo2)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.StyleCombo1)
			Me.Controls.Add(Me.ScaleSecondCluster)
			Me.Controls.Add(Me.PositiveNegativeData)
			Me.Controls.Add(Me.PositiveData)
			Me.Controls.Add(Me.WidthScroller)
			Me.Controls.Add(Me.GapPercentScrollBar)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.label1)
			Me.Name = "NClusterStackCombinationUC"
			Me.Size = New System.Drawing.Size(180, 438)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Cluster Stack Bar Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' setup the chart
			Dim m_Chart As NChart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Width = 65
			m_Chart.Height = 40
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' add interlaced stripe to the Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator).StripStyles.Add(stripStyle)

			' add the first bar
			m_Bar1 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar1.Name = "Bar1"
			m_Bar1.MultiBarMode = MultiBarMode.Series
			m_Bar1.DataLabelStyle.Format = "<value>"
			m_Bar1.DataLabelStyle.Visible = False

			' add the second bar
			m_Bar2 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar2.Name = "Bar2"
			m_Bar2.MultiBarMode = MultiBarMode.Clustered
			m_Bar2.DataLabelStyle.Format = "<value>"
			m_Bar2.DataLabelStyle.VertAlign = VertAlign.Center
			m_Bar2.DataLabelStyle.Visible = False

			' add the third bar
			m_Bar3 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar3.Name = "Bar2"
			m_Bar3.MultiBarMode = MultiBarMode.Stacked
			m_Bar3.DataLabelStyle.Format = "<value>"
			m_Bar3.DataLabelStyle.VertAlign = VertAlign.Center
			m_Bar3.DataLabelStyle.Visible = False

			' fill with random data
			m_Bar1.Values.FillRandomRange(Random, 5, 10, 100)
			m_Bar2.Values.FillRandomRange(Random, 5, 10, 500)
			m_Bar3.Values.FillRandomRange(Random, 5, 10, 500)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			StyleCombo1.FillFromEnum(GetType(BarShape))
			StyleCombo2.FillFromEnum(GetType(BarShape))
			StyleCombo3.FillFromEnum(GetType(BarShape))

			StyleCombo1.SelectedIndex = CInt(BarShape.Cylinder)
			StyleCombo2.SelectedIndex = CInt(BarShape.Pyramid)
			StyleCombo3.SelectedIndex = CInt(BarShape.Pyramid)

			GapPercentScrollBar.Value = 5
			WidthScroller.Value = 70
		End Sub

		Private Sub GapPercentScrollBar_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles GapPercentScrollBar.ValueChanged
			m_Bar1.GapPercent = GapPercentScrollBar.Value
			m_Bar2.GapPercent = GapPercentScrollBar.Value
			m_Bar3.GapPercent = GapPercentScrollBar.Value
			nChartControl1.Refresh()
		End Sub

		Private Sub WidthScroller_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles WidthScroller.ValueChanged
			m_Bar1.WidthPercent = WidthScroller.Value
			m_Bar2.WidthPercent = WidthScroller.Value
			m_Bar3.WidthPercent = WidthScroller.Value

			nChartControl1.Refresh()
		End Sub

		Private Sub ScaleSecondCluster_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ScaleSecondCluster.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)

			If ScaleSecondCluster.Checked = True Then
				m_Bar2.DisplayOnAxis(StandardAxis.PrimaryY, False)
				m_Bar2.DisplayOnAxis(StandardAxis.SecondaryY, True)

				m_Bar3.DisplayOnAxis(StandardAxis.PrimaryY, False)
				m_Bar3.DisplayOnAxis(StandardAxis.SecondaryY, True)

				chart.Axis(StandardAxis.SecondaryY).Visible = True
			Else
				m_Bar2.DisplayOnAxis(StandardAxis.PrimaryY, True)
				m_Bar2.DisplayOnAxis(StandardAxis.SecondaryY, False)

				m_Bar3.DisplayOnAxis(StandardAxis.PrimaryY, True)
				m_Bar3.DisplayOnAxis(StandardAxis.SecondaryY, False)

				chart.Axis(StandardAxis.SecondaryY).Visible = False
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub PositiveData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PositiveData.Click
			m_Bar1.Values.FillRandomRange(Random, 5, 10, 100)
			m_Bar2.Values.FillRandomRange(Random, 5, 10, 500)
			m_Bar3.Values.FillRandomRange(Random, 5, 10, 500)

			nChartControl1.Refresh()
		End Sub

		Private Sub PositiveNegativeData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PositiveNegativeData.Click
			m_Bar1.Values.FillRandomRange(Random, 5, -100, 100)
			m_Bar2.Values.FillRandomRange(Random, 5, -100, 100)
			m_Bar3.Values.FillRandomRange(Random, 5, -100, 100)

			nChartControl1.Refresh()
		End Sub

		Private Sub StyleCombo1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StyleCombo1.SelectedIndexChanged
			m_Bar1.BarShape = CType(StyleCombo1.SelectedIndex, BarShape)
			nChartControl1.Refresh()
		End Sub

		Private Sub StyleCombo2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StyleCombo2.SelectedIndexChanged
			m_Bar2.BarShape = CType(StyleCombo2.SelectedIndex, BarShape)
			nChartControl1.Refresh()
		End Sub

		Private Sub StyleCombo3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StyleCombo3.SelectedIndexChanged
			m_Bar3.BarShape = CType(StyleCombo3.SelectedIndex, BarShape)
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowDataLabelsCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowDataLabelsCheck.CheckedChanged
			m_Bar1.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked
			m_Bar2.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked
			m_Bar3.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
