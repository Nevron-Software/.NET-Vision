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
	<ToolboxItem(False)>
	Public Class NPointChartAndBoxPlotUC
		Inherits NExampleBaseUC

		Private WithEvents ShowAverageCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowOutliersCheck As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.ShowAverageCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowOutliersCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' ShowAverageCheck
			' 
			Me.ShowAverageCheck.ButtonProperties.BorderOffset = 2
			Me.ShowAverageCheck.Location = New System.Drawing.Point(9, 8)
			Me.ShowAverageCheck.Name = "ShowAverageCheck"
			Me.ShowAverageCheck.Size = New System.Drawing.Size(144, 21)
			Me.ShowAverageCheck.TabIndex = 0
			Me.ShowAverageCheck.Text = "Show Average"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowAverageCheck.CheckedChanged += new System.EventHandler(this.ShowAverageCheck_CheckedChanged);
			' 
			' ShowOutliersCheck
			' 
			Me.ShowOutliersCheck.ButtonProperties.BorderOffset = 2
			Me.ShowOutliersCheck.Location = New System.Drawing.Point(9, 32)
			Me.ShowOutliersCheck.Name = "ShowOutliersCheck"
			Me.ShowOutliersCheck.Size = New System.Drawing.Size(144, 21)
			Me.ShowOutliersCheck.TabIndex = 1
			Me.ShowOutliersCheck.Text = "Show Outliers"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowOutliersCheck.CheckedChanged += new System.EventHandler(this.ShowOutliersCheck_CheckedChanged);
			' 
			' NPointChartAndBoxPlotUC
			' 
			Me.Controls.Add(Me.ShowOutliersCheck)
			Me.Controls.Add(Me.ShowAverageCheck)
			Me.Name = "NPointChartAndBoxPlotUC"
			Me.Size = New System.Drawing.Size(180, 129)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' create a guide line to align the chart bottoms
			Dim bottomChartGuideline As New NSideGuideline(PanelSide.Bottom)
			nChartControl1.Document.RootPanel.Guidelines.Add(bottomChartGuideline)

			' top panel
			Dim topPanel As New NDockPanel()
			topPanel.DockMode = PanelDockMode.Top
			topPanel.Size = New NSizeL(New NLength(0), New NLength(20, NRelativeUnit.ParentPercentage))

			' bottom panel
			Dim bottomPanel As New NDockPanel()
			bottomPanel.DockMode = PanelDockMode.Bottom
			bottomPanel.Size = New NSizeL(New NLength(0), New NLength(20, NRelativeUnit.ParentPercentage))

			' center panel
			Dim centerPanel As New NDockPanel()
			centerPanel.DockMode = PanelDockMode.Fill

			' left panel
			Dim leftPanel As New NDockPanel()
			leftPanel.DockMode = PanelDockMode.Left
			leftPanel.Size = New NSizeL(New NLength(40.0F, NGraphicsUnit.Point), New NLength(0))

			' right panel
			Dim rightPanel As New NDockPanel()
			rightPanel.DockMode = PanelDockMode.Right
			rightPanel.Size = New NSizeL(New NLength(40.0F, NGraphicsUnit.Point), New NLength(0))

			' middle panel
			Dim middlePanel As New NDockPanel()
			middlePanel.DockMode = PanelDockMode.Right
			middlePanel.Size = New NSizeL(New NLength(10.0F, NGraphicsUnit.Point), New NLength(0))

			' right chart panel
			Dim rightChartPanel As New NDockPanel()
			rightChartPanel.Size = New NSizeL(New NLength(10.0F, NRelativeUnit.ParentPercentage), New NLength(0))
			rightChartPanel.DockMode = PanelDockMode.Right

			' left chart panel
			Dim leftChartPanel As New NDockPanel()
			leftChartPanel.Size = New NSizeL(New NLength(10.0F, NRelativeUnit.ParentPercentage), New NLength(0))
			leftChartPanel.DockMode = PanelDockMode.Fill

			' chart title
			Dim title As New NLabel("Data Distribution")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid
			title.TextStyle.ShadowStyle.Color = Color.White
			title.DockMode = PanelDockMode.Top
			title.Padding = New NMarginsL(5, 8, 5, 4)

			' create point chart
			Dim pointChart As NChart = New NCartesianChart()
			pointChart.BoundsMode = BoundsMode.Stretch
			pointChart.DockMode = PanelDockMode.Fill
			bottomChartGuideline.Targets.Add(pointChart)

			' create box and whiskers chart
			Dim boxChart As NChart = New NCartesianChart()
			boxChart.BoundsMode = BoundsMode.Stretch
			boxChart.DockMode = PanelDockMode.Fill
			bottomChartGuideline.Targets.Add(boxChart)

			' arrange panels
			nChartControl1.Panels.Add(topPanel)
			nChartControl1.Panels.Add(bottomPanel)
			nChartControl1.Panels.Add(centerPanel)

			centerPanel.ChildPanels.Add(rightPanel)
			centerPanel.ChildPanels.Add(rightChartPanel)
			centerPanel.ChildPanels.Add(middlePanel)
			centerPanel.ChildPanels.Add(leftPanel)
			centerPanel.ChildPanels.Add(leftChartPanel)

			topPanel.ChildPanels.Add(title)
			leftChartPanel.ChildPanels.Add(pointChart)
			rightChartPanel.ChildPanels.Add(boxChart)

			SetupCharts(pointChart, boxChart)

			ShowAverageCheck.Checked = True
			ShowOutliersCheck.Checked = True
		End Sub

		Private Sub SetupCharts(ByVal pointChart As NChart, ByVal boxChart As NChart)
			' data
			Dim arrValues() As Double = { 204.5, 190.6, 199.7, 131.8, 143.4, 215.1, 228.0, 209.2, 183.8, 169.5, 212.0, 254.9, 222.3, 201.0, 215.4, 191.3, 181.5, 207.0, 199.0, 210.0 }

			' setup point chart
			Dim scaleConfigurator As NStandardScaleConfigurator
			scaleConfigurator = TryCast(pointChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfigurator.InnerMajorTickStyle.LineStyle.Width = New NLength(0)

			scaleConfigurator = TryCast(pointChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfigurator.InnerMajorTickStyle.LineStyle.Width = New NLength(0)

			' setup point series
			Dim point As NPointSeries = CType(pointChart.Series.Add(SeriesType.Point), NPointSeries)
			point.InflateMargins = True
			point.DataLabelStyle.Visible = False
			point.Size = New NLength(10, NGraphicsUnit.Point)
			point.PointShape = PointShape.Ellipse
			point.FillStyle = New NColorFillStyle(Color.Yellow)
			point.BorderStyle = New NStrokeStyle(GreyBlue)
			point.Values.AddRange(arrValues)

			' setup box and whiskers chart
			boxChart.Width = 10
			boxChart.Axis(StandardAxis.PrimaryY).Anchor = New NDockAxisAnchor(AxisDockZone.FrontRight, False)
			boxChart.Axis(StandardAxis.PrimaryX).Visible = False

			' setup box and whiskers series
			Dim boxSeries As NBoxAndWhiskersSeries = CType(boxChart.Series.Add(SeriesType.BoxAndWhiskers), NBoxAndWhiskersSeries)
			boxSeries.InflateMargins = True
			boxSeries.DataLabelStyle.Visible = False
			boxSeries.FillStyle = New NColorFillStyle(DarkOrange)
			boxSeries.OutliersSize = New NLength(3, NGraphicsUnit.Point)

			' create a box and whiskers data point and initialize it from the point series
			Dim bwdp As New NBoxAndWhiskersDataPoint(point.Values, True, True)
			boxSeries.AddDataPoint(bwdp)

			' synchronize axes
			Dim axis1 As NAxis = pointChart.Axis(StandardAxis.PrimaryY)
			Dim axis2 As NAxis = boxChart.Axis(StandardAxis.PrimaryY)
			axis1.Slaves.Add(axis2)
			axis2.Slaves.Add(axis1)

			' set an axis stripe for the interquartile range
			Dim dQ1 As Double = DirectCast(bwdp(DataPointValue.LowerBoxValue), Double)
			Dim dQ3 As Double = DirectCast(bwdp(DataPointValue.UpperBoxValue), Double)

			Dim boxStripe As NAxisStripe = axis1.Stripes.Add(dQ1, dQ3)
			boxStripe.FillStyle = New NColorFillStyle(Color.FromArgb(150, LightGreen))

			' set an axis stripe for the min / max range
			Dim dMin As Double = DirectCast(bwdp(DataPointValue.LowerWhiskerValue), Double)
			Dim dMax As Double = DirectCast(bwdp(DataPointValue.UpperWhiskerValue), Double)
			Dim whiskersStripe As NAxisStripe = axis1.Stripes.Add(dMin, dMax)
			whiskersStripe.FillStyle = New NColorFillStyle(Color.FromArgb(70, LightGreen))
		End Sub

		Private Sub UpdateBoxAndWhiskers()
			Dim pointChart As NChart = nChartControl1.Charts(0)
			Dim boxChart As NChart = nChartControl1.Charts(1)

			Dim pointSeries As NPointSeries = CType(pointChart.Series(0), NPointSeries)
			Dim boxSeries As NBoxAndWhiskersSeries = CType(boxChart.Series(0), NBoxAndWhiskersSeries)

			Dim showAverage As Boolean = ShowAverageCheck.Checked
			Dim showOutliers As Boolean = ShowOutliersCheck.Checked

			Dim bwdp As New NBoxAndWhiskersDataPoint(pointSeries.Values, showAverage, showOutliers)
			boxSeries.ClearDataPoints()
			boxSeries.AddDataPoint(bwdp)
		End Sub


		Private Sub ShowAverageCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowAverageCheck.CheckedChanged
			UpdateBoxAndWhiskers()

			nChartControl1.Refresh()
		End Sub

		Private Sub ShowOutliersCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowOutliersCheck.CheckedChanged
			UpdateBoxAndWhiskers()

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace