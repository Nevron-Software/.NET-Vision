Imports System
Imports System.Resources
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NOrdinalScaleUC
		Inherits NExampleBaseUC

		Private m_Chart As NCartesianChart
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents HorzDataPointsBetweenTicksCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents HorzAutoLabelsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents DepthAutoLabelsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents DepthDataPointsBetweenTicksCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.Container = Nothing
		Private m_Updating As Boolean

		Public Sub New()
			m_Updating = True

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
			Me.HorzDataPointsBetweenTicksCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.HorzAutoLabelsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.DepthAutoLabelsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.DepthDataPointsBetweenTicksCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' HorzDataPointsBetweenTicksCheck
			' 
			Me.HorzDataPointsBetweenTicksCheck.Location = New System.Drawing.Point(6, 20)
			Me.HorzDataPointsBetweenTicksCheck.Name = "HorzDataPointsBetweenTicksCheck"
			Me.HorzDataPointsBetweenTicksCheck.Size = New System.Drawing.Size(192, 22)
			Me.HorzDataPointsBetweenTicksCheck.TabIndex = 0
			Me.HorzDataPointsBetweenTicksCheck.Text = "Display Data Points Between Ticks"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HorzDataPointsBetweenTicksCheck.CheckedChanged += new System.EventHandler(this.HorzDataPointsBetweenTicksCheck_CheckedChanged);
			' 
			' HorzAutoLabelsCheck
			' 
			Me.HorzAutoLabelsCheck.Location = New System.Drawing.Point(7, 43)
			Me.HorzAutoLabelsCheck.Name = "HorzAutoLabelsCheck"
			Me.HorzAutoLabelsCheck.Size = New System.Drawing.Size(161, 19)
			Me.HorzAutoLabelsCheck.TabIndex = 1
			Me.HorzAutoLabelsCheck.Text = "Auto Labels"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HorzAutoLabelsCheck.CheckedChanged += new System.EventHandler(this.HorzAutoLabelsCheck_CheckedChanged);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.HorzAutoLabelsCheck)
			Me.groupBox1.Controls.Add(Me.HorzDataPointsBetweenTicksCheck)
			Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox1.Location = New System.Drawing.Point(0, 0)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(235, 72)
			Me.groupBox1.TabIndex = 0
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Horizontal Axis"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.DepthAutoLabelsCheck)
			Me.groupBox2.Controls.Add(Me.DepthDataPointsBetweenTicksCheck)
			Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox2.Location = New System.Drawing.Point(0, 72)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(235, 72)
			Me.groupBox2.TabIndex = 1
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Depth Axis"
			' 
			' DepthAutoLabelsCheck
			' 
			Me.DepthAutoLabelsCheck.Location = New System.Drawing.Point(7, 43)
			Me.DepthAutoLabelsCheck.Name = "DepthAutoLabelsCheck"
			Me.DepthAutoLabelsCheck.Size = New System.Drawing.Size(161, 19)
			Me.DepthAutoLabelsCheck.TabIndex = 1
			Me.DepthAutoLabelsCheck.Text = "Auto Labels"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DepthAutoLabelsCheck.CheckedChanged += new System.EventHandler(this.DepthAutoLabelsCheck_CheckedChanged);
			' 
			' DepthDataPointsBetweenTicksCheck
			' 
			Me.DepthDataPointsBetweenTicksCheck.Location = New System.Drawing.Point(6, 20)
			Me.DepthDataPointsBetweenTicksCheck.Name = "DepthDataPointsBetweenTicksCheck"
			Me.DepthDataPointsBetweenTicksCheck.Size = New System.Drawing.Size(192, 22)
			Me.DepthDataPointsBetweenTicksCheck.TabIndex = 0
			Me.DepthDataPointsBetweenTicksCheck.Text = "Display Data Points Between Ticks"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DepthDataPointsBetweenTicksCheck.CheckedChanged += new System.EventHandler(this.DepthDataPointsBetweenTicksCheck_CheckedChanged);
			' 
			' NOrdinalScaleUC
			' 
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NOrdinalScaleUC"
			Me.Size = New System.Drawing.Size(235, 364)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Ordinal Scale")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup the chart
			m_Chart = CType(nChartControl1.Charts(0), NCartesianChart)
			m_Chart.Enable3D = True
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			m_Chart.Depth = 50
			m_Chart.BoundsMode = BoundsMode.Fit

			m_Chart.Location = New NPointL(New NLength(15, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))

			' add interlaced stripe to the Y axis
			Dim linearScale As New NLinearScaleConfigurator()
			Dim stripStyle As New NScaleStripStyle()
			stripStyle.FillStyle = New NColorFillStyle(Color.Beige)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale

			' add some series
			Dim dataItemsCount As Integer = 6
			For i As Integer = 0 To 2
				Dim bar As NBarSeries = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)

				bar.Name = "Series " & i.ToString()
				bar.Values.FillRandomRange(Random, dataItemsCount, 10, 30)
				bar.InflateMargins = True
				bar.DataLabelStyle.Visible = False
			Next i

			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.LabelFitModes = New LabelFitMode() { LabelFitMode.AutoScale }
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			For j As Integer = 0 To dataItemsCount - 1
				ordinalScale.Labels.Add("Category " & j.ToString())
			Next j

			ordinalScale = TryCast(m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.Labels.Add("Series 1")
			ordinalScale.Labels.Add("Series 2")
			ordinalScale.Labels.Add("Series 3")
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.LabelFitModes = New LabelFitMode() { LabelFitMode.AutoScale }

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			HorzDataPointsBetweenTicksCheck.Checked = True
			DepthDataPointsBetweenTicksCheck.Checked = True
			HorzAutoLabelsCheck.Checked = True
			DepthAutoLabelsCheck.Checked = True
			m_Updating = False

			nChartControl1.Refresh()
		End Sub

		Private Sub UpdateScales()
			If m_Updating Then
				Return
			End If

			Dim ordinalScale As NOrdinalScaleConfigurator

			' configure the primary x axis
			ordinalScale = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)

			ordinalScale.DisplayDataPointsBetweenTicks = HorzDataPointsBetweenTicksCheck.Checked
			ordinalScale.AutoLabels = HorzAutoLabelsCheck.Checked

			' configure the depth axis
			ordinalScale = CType(m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)

			ordinalScale.DisplayDataPointsBetweenTicks = DepthDataPointsBetweenTicksCheck.Checked
			ordinalScale.AutoLabels = DepthAutoLabelsCheck.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub HorzDataPointsBetweenTicksCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HorzDataPointsBetweenTicksCheck.CheckedChanged
			UpdateScales()
		End Sub

		Private Sub HorzAutoLabelsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HorzAutoLabelsCheck.CheckedChanged
			UpdateScales()
		End Sub

		Private Sub DepthDataPointsBetweenTicksCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DepthDataPointsBetweenTicksCheck.CheckedChanged
			UpdateScales()
		End Sub

		Private Sub DepthAutoLabelsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DepthAutoLabelsCheck.CheckedChanged
			UpdateScales()
		End Sub
	End Class
End Namespace
