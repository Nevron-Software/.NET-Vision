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
Imports Nevron.Dom


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NClusterBarUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bar1 As NBarSeries
		Private m_Bar2 As NBarSeries
		Private WithEvents GapPercentScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents PositiveData As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PositiveNegativeData As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents Bar1FillStyle As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents Bar2FillStyle As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ScaleSecondCluster As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents WidthScroller As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents StyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label3 As System.Windows.Forms.Label
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
			Me.GapPercentScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.PositiveData = New Nevron.UI.WinForm.Controls.NButton()
			Me.PositiveNegativeData = New Nevron.UI.WinForm.Controls.NButton()
			Me.ScaleSecondCluster = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.WidthScroller = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.StyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.Bar1FillStyle = New Nevron.UI.WinForm.Controls.NButton()
			Me.Bar2FillStyle = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' GapPercentScrollBar
			' 
			Me.GapPercentScrollBar.Location = New System.Drawing.Point(12, 91)
			Me.GapPercentScrollBar.Maximum = 110
			Me.GapPercentScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.GapPercentScrollBar.Name = "GapPercentScrollBar"
			Me.GapPercentScrollBar.Size = New System.Drawing.Size(152, 16)
			Me.GapPercentScrollBar.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GapPercentScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.GapPercentScrollBar_Scroll);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(12, 73)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(152, 16)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Gap Percent:"
			' 
			' PositiveData
			' 
			Me.PositiveData.Location = New System.Drawing.Point(12, 221)
			Me.PositiveData.Name = "PositiveData"
			Me.PositiveData.Size = New System.Drawing.Size(152, 23)
			Me.PositiveData.TabIndex = 7
			Me.PositiveData.Text = "Positive Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositiveData.Click += new System.EventHandler(this.PositiveData_Click);
			' 
			' PositiveNegativeData
			' 
			Me.PositiveNegativeData.Location = New System.Drawing.Point(12, 248)
			Me.PositiveNegativeData.Name = "PositiveNegativeData"
			Me.PositiveNegativeData.Size = New System.Drawing.Size(152, 24)
			Me.PositiveNegativeData.TabIndex = 8
			Me.PositiveNegativeData.Text = "Positive and Negative Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositiveNegativeData.Click += new System.EventHandler(this.PositiveNegativeData_Click);
			' 
			' ScaleSecondCluster
			' 
			Me.ScaleSecondCluster.ButtonProperties.BorderOffset = 2
			Me.ScaleSecondCluster.ButtonProperties.ShowFocusRect = False
			Me.ScaleSecondCluster.ButtonProperties.WrapText = True
			Me.ScaleSecondCluster.Location = New System.Drawing.Point(14, 172)
			Me.ScaleSecondCluster.Name = "ScaleSecondCluster"
			Me.ScaleSecondCluster.Size = New System.Drawing.Size(150, 47)
			Me.ScaleSecondCluster.TabIndex = 6
			Me.ScaleSecondCluster.Text = "Scale the second cluster on the secondary Y axis"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ScaleSecondCluster.CheckedChanged += new System.EventHandler(this.ScaleSecondCluster_CheckedChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(12, 130)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(152, 16)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Width Percent:"
			' 
			' WidthScroller
			' 
			Me.WidthScroller.Location = New System.Drawing.Point(12, 148)
			Me.WidthScroller.Maximum = 110
			Me.WidthScroller.MinimumSize = New System.Drawing.Size(32, 16)
			Me.WidthScroller.Name = "WidthScroller"
			Me.WidthScroller.Size = New System.Drawing.Size(152, 16)
			Me.WidthScroller.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WidthScroller.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WidthScroller_Scroll);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(12, 14)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(152, 16)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Bar Style:"
			' 
			' StyleCombo
			' 
			Me.StyleCombo.ListProperties.CheckBoxDataMember = ""
			Me.StyleCombo.ListProperties.DataSource = Nothing
			Me.StyleCombo.ListProperties.DisplayMember = ""
			Me.StyleCombo.Location = New System.Drawing.Point(12, 30)
			Me.StyleCombo.Name = "StyleCombo"
			Me.StyleCombo.Size = New System.Drawing.Size(152, 21)
			Me.StyleCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StyleCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			' 
			' Bar1FillStyle
			' 
			Me.Bar1FillStyle.Location = New System.Drawing.Point(12, 292)
			Me.Bar1FillStyle.Name = "Bar1FillStyle"
			Me.Bar1FillStyle.Size = New System.Drawing.Size(152, 23)
			Me.Bar1FillStyle.TabIndex = 9
			Me.Bar1FillStyle.Text = "Bar1 Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Bar1FillStyle.Click += new System.EventHandler(this.Bar1FillStyle_Click);
			' 
			' Bar2FillStyle
			' 
			Me.Bar2FillStyle.Location = New System.Drawing.Point(12, 320)
			Me.Bar2FillStyle.Name = "Bar2FillStyle"
			Me.Bar2FillStyle.Size = New System.Drawing.Size(152, 23)
			Me.Bar2FillStyle.TabIndex = 10
			Me.Bar2FillStyle.Text = "Bar2 Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Bar2FillStyle.Click += new System.EventHandler(this.Bar2FillStyle_Click);
			' 
			' NClusterBarUC
			' 
			Me.Controls.Add(Me.Bar2FillStyle)
			Me.Controls.Add(Me.Bar1FillStyle)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.StyleCombo)
			Me.Controls.Add(Me.WidthScroller)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.ScaleSecondCluster)
			Me.Controls.Add(Me.PositiveNegativeData)
			Me.Controls.Add(Me.PositiveData)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.GapPercentScrollBar)
			Me.Name = "NClusterBarUC"
			Me.Size = New System.Drawing.Size(180, 358)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Cluster Bar Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' add a bar series
			m_Bar1 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar1.Name = "Bar1"
			m_Bar1.MultiBarMode = MultiBarMode.Series
			m_Bar1.DataLabelStyle.Format = "<value>"
			m_Bar1.Values.ValueFormatter = New NNumericValueFormatter("0.###")

			' add another bar series
			m_Bar2 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar2.Name = "Bar2"
			m_Bar2.MultiBarMode = MultiBarMode.Clustered
			m_Bar2.DataLabelStyle.Format = "<value>"
			m_Bar2.Values.ValueFormatter = New NNumericValueFormatter("0.###")

			' fill with random data
			m_Bar1.Values.FillRandomRange(Random, 5, 10, 100)
			m_Bar2.Values.FillRandomRange(Random, 5, 10, 500)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			StyleCombo.FillFromEnum(GetType(BarShape))
			StyleCombo.SelectedIndex = 0
		End Sub

		Private Sub GapPercentScrollBar_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles GapPercentScrollBar.ValueChanged
			m_Bar1.GapPercent = GapPercentScrollBar.Value
			m_Bar2.GapPercent = GapPercentScrollBar.Value
			nChartControl1.Refresh()
		End Sub
		Private Sub PositiveData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PositiveData.Click
			m_Bar1.Values.FillRandomRange(Random, 5, 10, 100)
			m_Bar2.Values.FillRandomRange(Random, 5, 10, 500)
			nChartControl1.Refresh()
		End Sub
		Private Sub PositiveNegativeData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PositiveNegativeData.Click
			m_Bar1.Values.FillRandomRange(Random, 5, -100, 100)
			m_Bar2.Values.FillRandomRange(Random, 5, -100, 100)
			nChartControl1.Refresh()
		End Sub
		Private Sub ScaleSecondCluster_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ScaleSecondCluster.CheckedChanged
			If ScaleSecondCluster.Checked = True Then
				m_Bar2.DisplayOnAxis(StandardAxis.PrimaryY, False)
				m_Bar2.DisplayOnAxis(StandardAxis.SecondaryY, True)

				m_Chart.Axis(StandardAxis.SecondaryY).Visible = True
			Else
				m_Bar2.DisplayOnAxis(StandardAxis.PrimaryY, True)
				m_Bar2.DisplayOnAxis(StandardAxis.SecondaryY, False)

				m_Chart.Axis(StandardAxis.SecondaryY).Visible = False
			End If

			nChartControl1.Refresh()
		End Sub
		Private Sub WidthScroller_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles WidthScroller.ValueChanged
			m_Bar1.WidthPercent = WidthScroller.Value
			m_Bar2.WidthPercent = WidthScroller.Value
			nChartControl1.Refresh()
		End Sub
		Private Sub StyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StyleCombo.SelectedIndexChanged
			m_Bar1.BarShape = CType(StyleCombo.SelectedIndex, BarShape)
			m_Bar2.BarShape = CType(StyleCombo.SelectedIndex, BarShape)

			nChartControl1.Refresh()
		End Sub
		Private Sub Bar1FillStyle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bar1FillStyle.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_Bar1.FillStyle, fillStyleResult) Then
				m_Bar1.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub Bar2FillStyle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bar2FillStyle.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_Bar2.FillStyle, fillStyleResult) Then
				m_Bar2.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
