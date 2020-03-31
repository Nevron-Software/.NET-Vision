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
	Public Class NAnchorPanelsUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_PointSeries As NPointSeries
		Private m_bLockUpdate As Boolean
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents PointStyleComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents MiniChartTypeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			m_bLockUpdate = True
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
			Me.MiniChartTypeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.PointStyleComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(128, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Mini chart type:"
			' 
			' MiniChartTypeComboBox
			' 
			Me.MiniChartTypeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.MiniChartTypeComboBox.ListProperties.DataSource = Nothing
			Me.MiniChartTypeComboBox.ListProperties.DisplayMember = ""
			Me.MiniChartTypeComboBox.Location = New System.Drawing.Point(8, 24)
			Me.MiniChartTypeComboBox.Name = "MiniChartTypeComboBox"
			Me.MiniChartTypeComboBox.Size = New System.Drawing.Size(128, 21)
			Me.MiniChartTypeComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MiniChartTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.MiniChartTypeComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 67)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(128, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Shapes style:"
			' 
			' PointStyleComboBox
			' 
			Me.PointStyleComboBox.ListProperties.CheckBoxDataMember = ""
			Me.PointStyleComboBox.ListProperties.DataSource = Nothing
			Me.PointStyleComboBox.ListProperties.DisplayMember = ""
			Me.PointStyleComboBox.Location = New System.Drawing.Point(8, 88)
			Me.PointStyleComboBox.Name = "PointStyleComboBox"
			Me.PointStyleComboBox.Size = New System.Drawing.Size(128, 21)
			Me.PointStyleComboBox.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PointStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.PointStyleComboBox_SelectedIndexChanged);
			' 
			' NAnchorPanelsUC
			' 
			Me.Controls.Add(Me.PointStyleComboBox)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.MiniChartTypeComboBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NAnchorPanelsUC"
			Me.Size = New System.Drawing.Size(150, 232)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			m_bLockUpdate = True

			' set a chart title
			Dim title As New NLabel("Anchor panels")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' form controls
			MiniChartTypeComboBox.Items.Add("Pie")
			MiniChartTypeComboBox.Items.Add("Doughnut")
			MiniChartTypeComboBox.Items.Add("Bar")
			MiniChartTypeComboBox.Items.Add("Area")
			MiniChartTypeComboBox.SelectedIndex = 0

			PointStyleComboBox.FillFromEnum(GetType(BarShape))
			PointStyleComboBox.SelectedIndex = 0

			m_bLockUpdate = False

			UpdateMiniCharts()

			' apply layout
			ConfigureStandardLayout(m_Chart, title, Nothing)
		End Sub

		Private Sub UpdateMiniCharts()
			If m_bLockUpdate = True Then
				Return
			End If

			m_Chart.RemoveDescendantsOfType(GetType(NAnchorPanel))
			m_Chart.Series.Clear()

			' add bar and change bar color
			m_PointSeries = CType(m_Chart.Series.Add(SeriesType.Point), NPointSeries)

			' use custom X positions
			m_PointSeries.UseXValues = True

			m_PointSeries.Size = New NLength(12, NRelativeUnit.ParentPercentage)

			' this will require to set the InflateMargins flag to true since in this mode
			' scale is determined only by the X positions of the shape and will not take 
			' into account the size of the bubbles.
			m_PointSeries.InflateMargins = True

			m_PointSeries.PointShape = CType(PointStyleComboBox.SelectedIndex, PointShape)
			m_PointSeries.DataLabelStyle.Visible = False

			' populate the shape series of the master chart
			Dim i As Integer = 0

			For i = 0 To 4
				Dim fShapeSize As Single = 40 + Random.Next(5)

				m_PointSeries.XValues.Add(Random.Next(10))
				m_PointSeries.Values.Add(Random.Next(10))
				m_PointSeries.FillStyles(i) = New NColorFillStyle(RandomColor())
			Next i

			' create anchor panels attached to the shape series data points
			For i = 0 To m_PointSeries.Values.Count - 1
				Dim anchorPanel As New NAnchorPanel()
				m_Chart.ChildPanels.Add(anchorPanel)

				anchorPanel.Size = New NSizeL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))

				anchorPanel.Anchor = New NDataPointAnchor(m_PointSeries, i, ContentAlignment.MiddleCenter, StringAlignment.Near)
				anchorPanel.ContentAlignment = ContentAlignment.MiddleCenter
				anchorPanel.ChildPanels.Add(CreateAnchorPanelChart())
			Next i

			nChartControl1.Refresh()
		End Sub

		Private Function CreateAnchorPanelChart() As NChart
			Dim chart As NChart = Nothing
			Dim series As NSeries = Nothing

			Select Case MiniChartTypeComboBox.SelectedIndex
				Case 0 ' Pie
					chart = New NPieChart()
					series = CType(chart.Series.Add(SeriesType.Pie), NSeries)

				Case 1 ' Doughnut
					chart = New NPieChart()
					Dim pie As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
					pie.PieStyle = PieStyle.Torus
					series = pie
					Exit Select

				Case 2 ' Bar
					chart = New NCartesianChart()
					chart.Wall(ChartWallType.Back).Visible = False
					chart.Axis(StandardAxis.PrimaryX).Visible = False
					chart.Axis(StandardAxis.PrimaryY).Visible = False
					chart.Axis(StandardAxis.Depth).Visible = False
					series = CType(chart.Series.Add(SeriesType.Bar), NSeries)

				Case 3 ' Area
					chart = New NCartesianChart()
					chart.Wall(ChartWallType.Back).Visible = False
					chart.Axis(StandardAxis.PrimaryX).Visible = False
					chart.Axis(StandardAxis.PrimaryY).Visible = False
					chart.Axis(StandardAxis.Depth).Visible = False
					series = CType(chart.Series.Add(SeriesType.Area), NSeries)
			End Select

			chart.BoundsMode = BoundsMode.Fit
			chart.DockMode = PanelDockMode.Fill
			series.DataLabelStyle.Visible = False

			Dim dp As New NDataPoint()

			For i As Integer = 0 To 4
				dp(DataPointValue.Value) = 5 + Random.Next(10)
				dp(DataPointValue.FillStyle) = New NColorFillStyle(RandomColor())
				series.AddDataPoint(dp)
			Next i

			Return chart
		End Function

		Private Sub MiniChartTypeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MiniChartTypeComboBox.SelectedIndexChanged
			UpdateMiniCharts()
		End Sub

		Private Sub PointStyleComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PointStyleComboBox.SelectedIndexChanged
			UpdateMiniCharts()
		End Sub
	End Class
End Namespace
