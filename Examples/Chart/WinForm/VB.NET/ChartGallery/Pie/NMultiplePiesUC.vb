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
	Public Class NMultiplePiesUC
		Inherits NExampleBaseUC

		Private WithEvents Rotate As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_Timer As System.Windows.Forms.Timer
		Private components As System.ComponentModel.IContainer
		Private colors() As Color

		Public Sub New()
			InitializeComponent()

			colors = New Color() { DarkOrange, LightOrange, LightGreen, Turqoise }
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
			Me.components = New System.ComponentModel.Container()
			Me.Rotate = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_Timer = New System.Windows.Forms.Timer(Me.components)
			Me.SuspendLayout()
			' 
			' Rotate
			' 
			Me.Rotate.ButtonProperties.BorderOffset = 2
			Me.Rotate.Location = New System.Drawing.Point(9, 9)
			Me.Rotate.Name = "Rotate"
			Me.Rotate.Size = New System.Drawing.Size(122, 24)
			Me.Rotate.TabIndex = 1
			Me.Rotate.Text = "Rotate"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Rotate.CheckedChanged += new System.EventHandler(this.Rotate_CheckedChanged);
			' 
			' Timer1
			' 
			Me.m_Timer.Interval = 50
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_Timer.Tick += new System.EventHandler(this.Timer1_Tick);
			' 
			' NMultiplePiesUC
			' 
			Me.Controls.Add(Me.Rotate)
			Me.Name = "NMultiplePiesUC"
			Me.Size = New System.Drawing.Size(180, 41)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			ConfigureHeaderLabel()
			ConfigureLegend()
			ConfigurePieCharts()

			' apply style sheet
'			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
'			styleSheet.Apply(nChartControl1.Document);
		End Sub

		Private Sub ConfigureHeaderLabel()
			Dim label As New NLabel("Product Revenue Percents 2002 - 2005")
			label.TextStyle.BackplaneStyle.Visible = False
			label.TextStyle.FontStyle.EmSize = New NLength(17, NGraphicsUnit.Point)
			label.ContentAlignment = ContentAlignment.MiddleCenter
			label.DockMode = PanelDockMode.Fill
			label.BoundsMode = BoundsMode.Fit
			label.TextStyle.StringFormatStyle.VertAlign = VertAlign.Center

			Dim labelHostPanel As New NDockPanel()
			labelHostPanel.DockMode = PanelDockMode.Top
			labelHostPanel.Size = New NSizeL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			labelHostPanel.ChildPanels.Add(label)

			nChartControl1.Panels.Add(labelHostPanel)
		End Sub
		Private Sub ConfigureLegend()
			Dim legend As New NLegend()
			legend.Mode = LegendMode.Manual
			legend.DockMode = PanelDockMode.Fill
			legend.BoundsMode = BoundsMode.Fit
			legend.ContentAlignment = ContentAlignment.MiddleCenter
			legend.Data.ExpandMode = LegendExpandMode.ColsOnly

			' add custom legend items
			legend.Data.Items.Add(CreateLegendItem("Charting", colors(0)))
			legend.Data.Items.Add(CreateLegendItem("Diagramming", colors(1)))
			legend.Data.Items.Add(CreateLegendItem("User Interface", colors(2)))
			legend.Data.Items.Add(CreateLegendItem("Help Authoring", colors(3)))

			Dim legendHostPanel As New NDockPanel()
			legendHostPanel.DockMode = PanelDockMode.Bottom
			legendHostPanel.Size = New NSizeL(New NLength(100, NRelativeUnit.ParentPercentage), New NLength(5, NRelativeUnit.ParentPercentage))
			legendHostPanel.ChildPanels.Add(legend)

			nChartControl1.Panels.Add(legendHostPanel)
		End Sub
		Private Sub ConfigurePieCharts()
			Dim contentPanel As New NDockPanel()
			contentPanel.DockMode = PanelDockMode.Fill
			nChartControl1.Panels.Add(contentPanel)

			' configure four pie 1
			Dim dockPanelLeftTop As New NDockPanel()
			dockPanelLeftTop.Size = New NSizeL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
			dockPanelLeftTop.Location = New NPointL(New NLength(0, NRelativeUnit.ParentPercentage), New NLength(0, NRelativeUnit.ParentPercentage))
			dockPanelLeftTop.ChildPanels.Add(ConfigureLabel("2002", 90, New NLength(12, NGraphicsUnit.Point), ContentAlignment.TopLeft, PanelDockMode.Left))
			dockPanelLeftTop.ChildPanels.Add(ConfigurePieChart())
			contentPanel.ChildPanels.Add(dockPanelLeftTop)

			' configure four pie 2
			Dim dockPanelRightTop As New NDockPanel()
			dockPanelRightTop.Size = New NSizeL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
			dockPanelRightTop.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(0, NRelativeUnit.ParentPercentage))
			dockPanelRightTop.ChildPanels.Add(ConfigureLabel("2003", 90, New NLength(12, NGraphicsUnit.Point), ContentAlignment.TopLeft, PanelDockMode.Left))
			dockPanelRightTop.ChildPanels.Add(ConfigurePieChart())
			contentPanel.ChildPanels.Add(dockPanelRightTop)

			' configure four pie 3
			Dim dockPanelLeftBottom As New NDockPanel()
			dockPanelLeftBottom.Size = New NSizeL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
			dockPanelLeftBottom.Location = New NPointL(New NLength(0, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
			dockPanelLeftBottom.ChildPanels.Add(ConfigureLabel("2004", 90, New NLength(12, NGraphicsUnit.Point), ContentAlignment.TopLeft, PanelDockMode.Left))
			dockPanelLeftBottom.ChildPanels.Add(ConfigurePieChart())
			contentPanel.ChildPanels.Add(dockPanelLeftBottom)

			' configure four pie 4
			Dim dockPanelRightBottom As New NDockPanel()
			dockPanelRightBottom.Size = New NSizeL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
			dockPanelRightBottom.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
			dockPanelRightBottom.ChildPanels.Add(ConfigureLabel("2005", 90, New NLength(12, NGraphicsUnit.Point), ContentAlignment.TopLeft, PanelDockMode.Left))
			dockPanelRightBottom.ChildPanels.Add(ConfigurePieChart())
			contentPanel.ChildPanels.Add(dockPanelRightBottom)
		End Sub

		Private Function ConfigureLabel(ByVal text As String, ByVal orientation As Single, ByVal fontSize As NLength, ByVal contentAlignment As ContentAlignment, ByVal dockMode As PanelDockMode) As NPanel
			Dim label As New NLabel(text)
			label.TextStyle.BackplaneStyle.Visible = False
			label.TextStyle.Orientation = orientation
			label.TextStyle.FontStyle.EmSize = fontSize
			label.ContentAlignment = contentAlignment
			label.DockMode = PanelDockMode.Fill
			label.BoundsMode = BoundsMode.Fit
			label.TextStyle.StringFormatStyle.VertAlign = VertAlign.Center

			Dim labelHostPanel As New NWatermark()
			labelHostPanel.DockMode = dockMode
			labelHostPanel.UseAutomaticSize = False
			labelHostPanel.Size = New NSizeL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			labelHostPanel.ChildPanels.Add(label)

			Return labelHostPanel
		End Function
		Private Function ConfigurePieChart() As NPanel
			' configure the chart bounds, contentalign, docking, light model and projection.
			Dim chart As NChart = New NPieChart()
			chart.Enable3D = True
			chart.BoundsMode = BoundsMode.Fit
			chart.ContentAlignment = ContentAlignment.MiddleCenter
			chart.DockMode = PanelDockMode.Fill
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated)

			' create the pie series
			Dim pie As New NPieSeries()
			chart.Series.Add(pie)
			pie.PieStyle = PieStyle.SmoothEdgePie
			pie.DataLabelStyle.Format = "<percent>"
			pie.LabelMode = PieLabelMode.Center
			pie.DataLabelStyle.TextStyle.BackplaneStyle.Visible = False
			pie.DataLabelStyle.TextStyle.FontStyle.Style = pie.DataLabelStyle.TextStyle.FontStyle.Style Or FontStyle.Bold
			pie.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(12, NGraphicsUnit.Point)

			For i As Integer = 0 To colors.Length - 1
				pie.AddDataPoint(New NDataPoint(Random.Next(10) + 5, New NColorFillStyle(colors(i))))
			Next i

			' create a watermark and nest the chart inside
			Dim chartHostPanel As New NWatermark()
			chartHostPanel.DockMode = PanelDockMode.Fill
			chartHostPanel.ChildPanels.Add(chart)

			Return chartHostPanel
		End Function
		Private Function CreateLegendItem(ByVal text As String, ByVal color As Color) As NLegendItemCellData
			Dim ldi As New NLegendItemCellData()
			ldi.Text = text
			ldi.MarkFillStyle = New NColorFillStyle(color)
			ldi.MarkLineStyle.Width = New NLength(0)
			Return ldi
		End Function

		Private Sub Rotate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rotate.CheckedChanged
			m_Timer.Enabled = Rotate.Checked
		End Sub
		Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_Timer.Tick
			Dim charts As NChartCollection = nChartControl1.Charts

			For i As Integer = 0 To charts.Count - 1
				Dim pieChart As NPieChart = CType(charts(i), NPieChart)
				Dim newBeginAngle As Single = pieChart.BeginAngle + 5

				If newBeginAngle > 360 Then
					newBeginAngle -= 360
				End If

				pieChart.BeginAngle = newBeginAngle
			Next i

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
