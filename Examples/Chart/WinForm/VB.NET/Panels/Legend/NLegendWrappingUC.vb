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
	Public Class NLegendWrappingUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Legend As NLegend

		Private m_Bar1 As NBarSeries
		Private m_Bar2 As NBarSeries
		Private m_Bar3 As NBarSeries

		Private label8 As Label
		Private WithEvents LegendWidthNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents FitAlignmentComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As Label
		Private WithEvents VertWrapRadioButton As Nevron.UI.WinForm.Controls.NRadioButton
		Private WithEvents HorzWrapRadioButton As Nevron.UI.WinForm.Controls.NRadioButton
		Private label2 As Label
		Private WithEvents DataPointsPerSeriesNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
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
			Me.label8 = New System.Windows.Forms.Label()
			Me.LegendWidthNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.FitAlignmentComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.VertWrapRadioButton = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.HorzWrapRadioButton = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.label2 = New System.Windows.Forms.Label()
			Me.DataPointsPerSeriesNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			DirectCast(Me.LegendWidthNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.DataPointsPerSeriesNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(6, 15)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(171, 20)
			Me.label8.TabIndex = 0
			Me.label8.Text = "Legend Width (in percents):"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' LegendWidthNumericUpDown
			' 
			Me.LegendWidthNumericUpDown.Location = New System.Drawing.Point(6, 38)
			Me.LegendWidthNumericUpDown.Name = "LegendWidthNumericUpDown"
			Me.LegendWidthNumericUpDown.Size = New System.Drawing.Size(171, 20)
			Me.LegendWidthNumericUpDown.TabIndex = 1
			Me.LegendWidthNumericUpDown.Value = New Decimal(New Integer() { 10, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LegendWidthNumericUpDown.ValueChanged += new System.EventHandler(this.LegendWidthNumericUpDown_ValueChanged);
			' 
			' FitAlignmentComboBox
			' 
			Me.FitAlignmentComboBox.ListProperties.CheckBoxDataMember = ""
			Me.FitAlignmentComboBox.ListProperties.DataSource = Nothing
			Me.FitAlignmentComboBox.ListProperties.DisplayMember = ""
			Me.FitAlignmentComboBox.Location = New System.Drawing.Point(3, 202)
			Me.FitAlignmentComboBox.Name = "FitAlignmentComboBox"
			Me.FitAlignmentComboBox.Size = New System.Drawing.Size(171, 21)
			Me.FitAlignmentComboBox.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FitAlignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.FitAlignmentComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(3, 180)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(175, 20)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Fit Alignement:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' VertWrapRadioButton
			' 
			Me.VertWrapRadioButton.ButtonProperties.BorderOffset = 2
			Me.VertWrapRadioButton.Location = New System.Drawing.Point(3, 144)
			Me.VertWrapRadioButton.Name = "VertWrapRadioButton"
			Me.VertWrapRadioButton.Size = New System.Drawing.Size(175, 24)
			Me.VertWrapRadioButton.TabIndex = 3
			Me.VertWrapRadioButton.Text = "Vertical Wrap"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.VertWrapRadioButton.CheckedChanged += new System.EventHandler(this.VertWrapRadioButton_CheckedChanged);
			' 
			' HorzWrapRadioButton
			' 
			Me.HorzWrapRadioButton.ButtonProperties.BorderOffset = 2
			Me.HorzWrapRadioButton.Location = New System.Drawing.Point(3, 124)
			Me.HorzWrapRadioButton.Name = "HorzWrapRadioButton"
			Me.HorzWrapRadioButton.Size = New System.Drawing.Size(175, 24)
			Me.HorzWrapRadioButton.TabIndex = 2
			Me.HorzWrapRadioButton.Text = "Horizontal Wrap"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HorzWrapRadioButton.CheckedChanged += new System.EventHandler(this.HorzWrapRadioButton_CheckedChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(6, 65)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(171, 20)
			Me.label2.TabIndex = 6
			Me.label2.Text = "Data Points Per Series:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' DataPointsPerSeriesNumericUpDown
			' 
			Me.DataPointsPerSeriesNumericUpDown.Location = New System.Drawing.Point(6, 88)
			Me.DataPointsPerSeriesNumericUpDown.Name = "DataPointsPerSeriesNumericUpDown"
			Me.DataPointsPerSeriesNumericUpDown.Size = New System.Drawing.Size(171, 20)
			Me.DataPointsPerSeriesNumericUpDown.TabIndex = 7
			Me.DataPointsPerSeriesNumericUpDown.Value = New Decimal(New Integer() { 10, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DataPointsPerSeriesNumericUpDown.ValueChanged += new System.EventHandler(this.DataPointsPerSeriesNumericUpDown_ValueChanged);
			' 
			' NLegendWrappingUC
			' 
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.DataPointsPerSeriesNumericUpDown)
			Me.Controls.Add(Me.VertWrapRadioButton)
			Me.Controls.Add(Me.HorzWrapRadioButton)
			Me.Controls.Add(Me.FitAlignmentComboBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.label8)
			Me.Controls.Add(Me.LegendWidthNumericUpDown)
			Me.Name = "NLegendWrappingUC"
			Me.Size = New System.Drawing.Size(180, 680)
			DirectCast(Me.LegendWidthNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.DataPointsPerSeriesNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' confgigure chart
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Legend Horizontal and Vertical Wrapping")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			header.DockMode = PanelDockMode.Top
			header.Margins = New NMarginsL(0, 10, 0, 10)
			nChartControl1.Panels.Add(header)

'INSTANT VB NOTE: The variable container was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim container_Renamed As New NDockPanel()
			container_Renamed.DockMode = PanelDockMode.Fill
			container_Renamed.Margins = New NMarginsL(10, 10, 10, 10)
			container_Renamed.PositionChildPanelsInContentBounds = True
			nChartControl1.Panels.Add(container_Renamed)

			' configure the legend
			m_Legend = New NLegend()
			m_Legend.Data.ExpandMode = LegendExpandMode.HorzWrap
			m_Legend.Location = New NPointL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(0))
			m_Legend.BoundsMode = BoundsMode.None
			m_Legend.Size = New NSizeL(New NLength(20, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))
			m_Legend.UseAutomaticSize = False
			container_Renamed.ChildPanels.Add(m_Legend)

			' configure the chart
			m_Chart = New NCartesianChart()
			container_Renamed.ChildPanels.Add(m_Chart)
			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.Margins = New NMarginsL(0, 0, 10, 0)
			m_Chart.Location = New NPointL(New NLength(0), New NLength(0))
			m_Chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))
			m_Chart.DisplayOnLegend = m_Legend
			m_Chart.Axis(StandardAxis.Depth).Visible = False
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight)

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' add the first bar
			m_Bar1 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar1.Name = "Bar1"
			m_Bar1.MultiBarMode = MultiBarMode.Series
			m_Bar1.Legend.Mode = SeriesLegendMode.DataPoints
			m_Bar1.DataLabelStyle.Visible = False

			' add the second bar
			m_Bar2 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar2.Name = "Bar2"
			m_Bar2.MultiBarMode = MultiBarMode.Stacked
			m_Bar2.Legend.Mode = SeriesLegendMode.DataPoints
			m_Bar2.DataLabelStyle.Visible = False

			' add the third bar
			m_Bar3 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar3.Name = "Bar3"
			m_Bar3.Legend.Mode = SeriesLegendMode.DataPoints
			m_Bar3.DataLabelStyle.Visible = False

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			Dim names() As String = System.Enum.GetNames(GetType(ContentAlignment))
			For i As Integer = 0 To names.Length - 1
				FitAlignmentComboBox.Items.Add(names(i))
			Next i

			FitAlignmentComboBox.SelectedItem = ContentAlignment.TopCenter.ToString()
			LegendWidthNumericUpDown.Value = 30
			DataPointsPerSeriesNumericUpDown.Value = 10
			HorzWrapRadioButton.Checked = True

			DataPointsPerSeriesNumericUpDown_ValueChanged(Nothing, Nothing)
		End Sub

		Private Sub LegendWidthNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LegendWidthNumericUpDown.ValueChanged
			If m_Legend Is Nothing Then
				Return
			End If

			Dim legendWidth As New NLength(CSng(LegendWidthNumericUpDown.Value), NRelativeUnit.ParentPercentage)
			Dim chartWidth As New NLength(100 - CSng(LegendWidthNumericUpDown.Value), NRelativeUnit.ParentPercentage)

			m_Legend.Size = New NSizeL(legendWidth, m_Legend.Size.Height)
			m_Legend.Location = New NPointL(chartWidth, m_Legend.Location.Y)
			m_Chart.Size = New NSizeL(chartWidth, m_Chart.Size.Height)

			nChartControl1.Refresh()
		End Sub

		Private Sub FitAlignmentComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FitAlignmentComboBox.SelectedIndexChanged
			If m_Legend Is Nothing Then
				Return
			End If

			Dim values As Array = System.Enum.GetValues(GetType(ContentAlignment))
			m_Legend.FitAlignment = DirectCast(values.GetValue(FitAlignmentComboBox.SelectedIndex), ContentAlignment)

			nChartControl1.Refresh()
		End Sub

		Private Sub HorzWrapRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles HorzWrapRadioButton.CheckedChanged
			If m_Legend Is Nothing Then
				Return
			End If

			m_Legend.Data.ExpandMode = LegendExpandMode.HorzWrap
			nChartControl1.Refresh()
		End Sub

		Private Sub VertWrapRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles VertWrapRadioButton.CheckedChanged
			If m_Legend Is Nothing Then
				Return
			End If

			m_Legend.Data.ExpandMode = LegendExpandMode.VertWrap
			nChartControl1.Refresh()
		End Sub

		Private Sub DataPointsPerSeriesNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataPointsPerSeriesNumericUpDown.ValueChanged
			If m_Bar1 Is Nothing OrElse m_Bar2 Is Nothing OrElse m_Bar3 Is Nothing Then
				Return
			End If

			' add some random data
			Dim nDataPointCount As Integer = CInt(Math.Truncate(DataPointsPerSeriesNumericUpDown.Value))

			m_Bar1.Values.FillRandomRange(Random, nDataPointCount, 20, 100)
			m_Bar2.Values.FillRandomRange(Random, nDataPointCount, 20, 100)
			m_Bar3.Values.FillRandomRange(Random, nDataPointCount, 20, 100)

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
