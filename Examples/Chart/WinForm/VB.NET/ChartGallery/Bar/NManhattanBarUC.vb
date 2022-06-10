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
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NManhattanBarUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bar1 As NBarSeries
		Private m_Bar2 As NBarSeries
		Private m_Bar3 As NBarSeries
		Private m_Bar4 As NBarSeries
		Private Const m_nBarsCount As Integer = 7
		Private WithEvents ChartDepthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private label1 As System.Windows.Forms.Label
		Private WithEvents PositiveNegativeData As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PositiveData As Nevron.UI.WinForm.Controls.NButton
		Private label3 As System.Windows.Forms.Label
		Private WithEvents StyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents BarsHaveBorders As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.ChartDepthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.PositiveNegativeData = New Nevron.UI.WinForm.Controls.NButton()
			Me.PositiveData = New Nevron.UI.WinForm.Controls.NButton()
			Me.label3 = New System.Windows.Forms.Label()
			Me.StyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.BarsHaveBorders = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' ChartDepthScroll
			' 
			Me.ChartDepthScroll.LargeChange = 1
			Me.ChartDepthScroll.Location = New System.Drawing.Point(10, 85)
			Me.ChartDepthScroll.Maximum = 50
			Me.ChartDepthScroll.Minimum = 1
			Me.ChartDepthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.ChartDepthScroll.Name = "ChartDepthScroll"
			Me.ChartDepthScroll.Size = New System.Drawing.Size(152, 16)
			Me.ChartDepthScroll.TabIndex = 3
			Me.ChartDepthScroll.Value = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChartDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ChartDepthScroll_Scroll);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(10, 69)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(152, 16)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Chart Depth:"
			' 
			' PositiveNegativeData
			' 
			Me.PositiveNegativeData.Location = New System.Drawing.Point(10, 187)
			Me.PositiveNegativeData.Name = "PositiveNegativeData"
			Me.PositiveNegativeData.Size = New System.Drawing.Size(152, 24)
			Me.PositiveNegativeData.TabIndex = 6
			Me.PositiveNegativeData.Text = "Positive and Negative Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositiveNegativeData.Click += new System.EventHandler(this.PositiveNegativeData_Click);
			' 
			' PositiveData
			' 
			Me.PositiveData.Location = New System.Drawing.Point(10, 155)
			Me.PositiveData.Name = "PositiveData"
			Me.PositiveData.Size = New System.Drawing.Size(152, 23)
			Me.PositiveData.TabIndex = 5
			Me.PositiveData.Text = "Positive Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositiveData.Click += new System.EventHandler(this.PositiveData_Click);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(10, 11)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(152, 16)
			Me.label3.TabIndex = 0
			Me.label3.Text = "Bar Style:"
			' 
			' StyleCombo
			' 
			Me.StyleCombo.ListProperties.CheckBoxDataMember = ""
			Me.StyleCombo.ListProperties.DataSource = Nothing
			Me.StyleCombo.ListProperties.DisplayMember = ""
			Me.StyleCombo.Location = New System.Drawing.Point(10, 32)
			Me.StyleCombo.Name = "StyleCombo"
			Me.StyleCombo.Size = New System.Drawing.Size(152, 21)
			Me.StyleCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StyleCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			' 
			' BarsHaveBorders
			' 
			Me.BarsHaveBorders.ButtonProperties.BorderOffset = 2
			Me.BarsHaveBorders.Location = New System.Drawing.Point(10, 121)
			Me.BarsHaveBorders.Name = "BarsHaveBorders"
			Me.BarsHaveBorders.Size = New System.Drawing.Size(152, 20)
			Me.BarsHaveBorders.TabIndex = 4
			Me.BarsHaveBorders.Text = "Bars Have Borders"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarsHaveBorders.CheckedChanged += new System.EventHandler(this.BarsHaveBorders_CheckedChanged);
			' 
			' NManhattanBarUC
			' 
			Me.Controls.Add(Me.BarsHaveBorders)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.StyleCombo)
			Me.Controls.Add(Me.PositiveNegativeData)
			Me.Controls.Add(Me.PositiveData)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.ChartDepthScroll)
			Me.Name = "NManhattanBarUC"
			Me.Size = New System.Drawing.Size(180, 294)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Manhattan Bar Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Width = 60
			m_Chart.Height = 25
			m_Chart.Depth = 45
			m_Chart.BoundsMode = BoundsMode.Fit
			m_Chart.ContentAlignment = ContentAlignment.BottomRight
			m_Chart.Location = New NPointL(New NLength(15, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			' apply predefined projection and lighting
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight)

			' add axis labels
			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.AutoLabels = False
			ordinalScale.Labels.Add("Miami")
			ordinalScale.Labels.Add("Chicago")
			ordinalScale.Labels.Add("Los Angeles")
			ordinalScale.Labels.Add("New York")
			ordinalScale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)

			ordinalScale = TryCast(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' add interlace stripe to the Y axis
			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' add the first bar
			m_Bar1 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar1.MultiBarMode = MultiBarMode.Series
			m_Bar1.Name = "Bar1"
			m_Bar1.DataLabelStyle.Visible = False
			m_Bar1.BorderStyle.Color = Color.FromArgb(210, 210, 255)

			' add the second bar
			m_Bar2 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar2.MultiBarMode = MultiBarMode.Series
			m_Bar2.Name = "Bar2"
			m_Bar2.DataLabelStyle.Visible = False
			m_Bar2.BorderStyle.Color = Color.FromArgb(210, 255, 210)

			' add the third bar
			m_Bar3 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar3.MultiBarMode = MultiBarMode.Series
			m_Bar3.Name = "Bar3"
			m_Bar3.DataLabelStyle.Visible = False
			m_Bar3.BorderStyle.Color = Color.FromArgb(255, 255, 210)

			' add the second bar
			m_Bar4 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar4.MultiBarMode = MultiBarMode.Series
			m_Bar4.Name = "Bar4"
			m_Bar4.DataLabelStyle.Visible = False
			m_Bar4.BorderStyle.Color = Color.FromArgb(255, 210, 210)

			' fill with random data
			m_Bar1.Values.FillRandomRange(Random, m_nBarsCount, 10, 40)
			m_Bar2.Values.FillRandomRange(Random, m_nBarsCount, 30, 60)
			m_Bar3.Values.FillRandomRange(Random, m_nBarsCount, 50, 80)
			m_Bar4.Values.FillRandomRange(Random, m_nBarsCount, 70, 100)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' update form controls
			StyleCombo.FillFromEnum(GetType(BarShape))
			StyleCombo.SelectedIndex = 0
			BarsHaveBorders.Checked = True
		End Sub

		Private Sub ChartDepthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles ChartDepthScroll.ValueChanged
			m_Chart.Depth = CSng(ChartDepthScroll.Value)
			nChartControl1.Refresh()
		End Sub

		Private Sub PositiveData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PositiveData.Click
			m_Bar1.Values.FillRandomRange(Random, m_nBarsCount, 10, 100)
			m_Bar2.Values.FillRandomRange(Random, m_nBarsCount, 10, 100)
			m_Bar3.Values.FillRandomRange(Random, m_nBarsCount, 10, 100)
			m_Bar4.Values.FillRandomRange(Random, m_nBarsCount, 10, 100)
			nChartControl1.Refresh()
		End Sub

		Private Sub PositiveNegativeData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PositiveNegativeData.Click
			m_Bar1.Values.FillRandomRange(Random, m_nBarsCount, -100, 100)
			m_Bar2.Values.FillRandomRange(Random, m_nBarsCount, -100, 100)
			m_Bar3.Values.FillRandomRange(Random, m_nBarsCount, -100, 100)
			m_Bar4.Values.FillRandomRange(Random, m_nBarsCount, -100, 100)
			nChartControl1.Refresh()
		End Sub

		Private Sub StyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StyleCombo.SelectedIndexChanged
			m_Bar1.BarShape = CType(StyleCombo.SelectedIndex, BarShape)
			m_Bar2.BarShape = CType(StyleCombo.SelectedIndex, BarShape)
			m_Bar3.BarShape = CType(StyleCombo.SelectedIndex, BarShape)
			m_Bar4.BarShape = CType(StyleCombo.SelectedIndex, BarShape)
			nChartControl1.Refresh()
		End Sub

		Private Sub BarsHaveBorders_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarsHaveBorders.CheckedChanged
			Dim length As NLength

			If BarsHaveBorders.Checked Then
				length = New NLength(1, NGraphicsUnit.Pixel)
			Else
				length = New NLength(0, NGraphicsUnit.Pixel)
			End If

			m_Bar1.BorderStyle.Width = length
			m_Bar2.BorderStyle.Width = length
			m_Bar3.BorderStyle.Width = length
			m_Bar4.BorderStyle.Width = length

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
