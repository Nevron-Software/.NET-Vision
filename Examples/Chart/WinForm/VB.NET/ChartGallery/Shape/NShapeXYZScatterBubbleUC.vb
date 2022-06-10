Imports System
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
	<ToolboxItem(False)>
	Public Class NShapeXYZScatterBubbleUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Shape As NShapeSeries
		Private WithEvents Bubble1FillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents Bubble2FillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents Bubble3FillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private WithEvents StyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents InflateMarginsCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents AxesRoundToTickCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ChangeXValues As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ChangeZValues As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ChangeYValues As Nevron.UI.WinForm.Controls.NButton
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			StyleCombo.FillFromEnum(GetType(BarShape))
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
			Me.Bubble1FillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.Bubble2FillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.Bubble3FillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.StyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.InflateMarginsCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.AxesRoundToTickCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ChangeXValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.ChangeZValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.ChangeYValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' Bubble1FillStyleButton
			' 
			Me.Bubble1FillStyleButton.Location = New System.Drawing.Point(5, 9)
			Me.Bubble1FillStyleButton.Name = "Bubble1FillStyleButton"
			Me.Bubble1FillStyleButton.Size = New System.Drawing.Size(171, 26)
			Me.Bubble1FillStyleButton.TabIndex = 0
			Me.Bubble1FillStyleButton.Text = "Bubble1 Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Bubble1FillStyleButton.Click += new System.EventHandler(this.Bubble1FillStyleButton_Click);
			' 
			' Bubble2FillStyleButton
			' 
			Me.Bubble2FillStyleButton.Location = New System.Drawing.Point(5, 40)
			Me.Bubble2FillStyleButton.Name = "Bubble2FillStyleButton"
			Me.Bubble2FillStyleButton.Size = New System.Drawing.Size(171, 26)
			Me.Bubble2FillStyleButton.TabIndex = 1
			Me.Bubble2FillStyleButton.Text = "Bubble2 Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Bubble2FillStyleButton.Click += new System.EventHandler(this.Bubble2FillStyleButton_Click);
			' 
			' Bubble3FillStyleButton
			' 
			Me.Bubble3FillStyleButton.Location = New System.Drawing.Point(5, 71)
			Me.Bubble3FillStyleButton.Name = "Bubble3FillStyleButton"
			Me.Bubble3FillStyleButton.Size = New System.Drawing.Size(171, 26)
			Me.Bubble3FillStyleButton.TabIndex = 2
			Me.Bubble3FillStyleButton.Text = "Bubble3 Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Bubble3FillStyleButton.Click += new System.EventHandler(this.Bubble3FillStyleButton_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(5, 115)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(171, 18)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Bubbles Shape:"
			' 
			' StyleCombo
			' 
			Me.StyleCombo.ListProperties.CheckBoxDataMember = ""
			Me.StyleCombo.ListProperties.DataSource = Nothing
			Me.StyleCombo.ListProperties.DisplayMember = ""
			Me.StyleCombo.Location = New System.Drawing.Point(5, 140)
			Me.StyleCombo.Name = "StyleCombo"
			Me.StyleCombo.Size = New System.Drawing.Size(171, 21)
			Me.StyleCombo.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StyleCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			' 
			' InflateMarginsCheckBox
			' 
			Me.InflateMarginsCheckBox.ButtonProperties.BorderOffset = 2
			Me.InflateMarginsCheckBox.Location = New System.Drawing.Point(5, 280)
			Me.InflateMarginsCheckBox.Name = "InflateMarginsCheckBox"
			Me.InflateMarginsCheckBox.Size = New System.Drawing.Size(171, 24)
			Me.InflateMarginsCheckBox.TabIndex = 6
			Me.InflateMarginsCheckBox.Text = "Inflate Margins"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InflateMarginsCheckBox.CheckedChanged += new System.EventHandler(this.InflateMarginsCheckBox_CheckedChanged);
			' 
			' AxesRoundToTickCheck
			' 
			Me.AxesRoundToTickCheck.ButtonProperties.BorderOffset = 2
			Me.AxesRoundToTickCheck.Location = New System.Drawing.Point(5, 309)
			Me.AxesRoundToTickCheck.Name = "AxesRoundToTickCheck"
			Me.AxesRoundToTickCheck.Size = New System.Drawing.Size(171, 24)
			Me.AxesRoundToTickCheck.TabIndex = 7
			Me.AxesRoundToTickCheck.Text = "Axes Round To Tick"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AxesRoundToTickCheck.CheckedChanged += new System.EventHandler(this.AxesRoundToTickCheck_CheckedChanged);
			' 
			' ChangeXValues
			' 
			Me.ChangeXValues.Location = New System.Drawing.Point(5, 178)
			Me.ChangeXValues.Name = "ChangeXValues"
			Me.ChangeXValues.Size = New System.Drawing.Size(171, 26)
			Me.ChangeXValues.TabIndex = 8
			Me.ChangeXValues.Text = "Change X Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeXValues.Click += new System.EventHandler(this.ChangeXValues_Click);
			' 
			' ChangeZValues
			' 
			Me.ChangeZValues.Location = New System.Drawing.Point(5, 209)
			Me.ChangeZValues.Name = "ChangeZValues"
			Me.ChangeZValues.Size = New System.Drawing.Size(171, 26)
			Me.ChangeZValues.TabIndex = 9
			Me.ChangeZValues.Text = "Change Z Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeZValues.Click += new System.EventHandler(this.ChangeZValues_Click);
			' 
			' ChangeYValues
			' 
			Me.ChangeYValues.Location = New System.Drawing.Point(5, 240)
			Me.ChangeYValues.Name = "ChangeYValues"
			Me.ChangeYValues.Size = New System.Drawing.Size(171, 26)
			Me.ChangeYValues.TabIndex = 10
			Me.ChangeYValues.Text = "Change Y Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeYValues.Click += new System.EventHandler(this.ChangeYValues_Click);
			' 
			' NShapeXYZScatterBubbleUC
			' 
			Me.Controls.Add(Me.ChangeYValues)
			Me.Controls.Add(Me.ChangeZValues)
			Me.Controls.Add(Me.ChangeXValues)
			Me.Controls.Add(Me.AxesRoundToTickCheck)
			Me.Controls.Add(Me.InflateMarginsCheckBox)
			Me.Controls.Add(Me.StyleCombo)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.Bubble3FillStyleButton)
			Me.Controls.Add(Me.Bubble2FillStyleButton)
			Me.Controls.Add(Me.Bubble1FillStyleButton)
			Me.Name = "NShapeXYZScatterBubbleUC"
			Me.Size = New System.Drawing.Size(180, 343)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XYZ Scatter Bubbles")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' chart settings
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			m_Chart.Projection.Elevation -= 10
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			m_Chart.Depth = 55.0F
			m_Chart.Width = 55.0F
			m_Chart.Height = 55.0F

			' switch the PrimaryX and Depth axes in numeric mode in order to correctly scale the custom X and Z positions
			Dim linearScale As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlaced stripe 
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)

			' create the shape series
			m_Shape = CType(m_Chart.Series.Add(SeriesType.Shape), NShapeSeries)
			m_Shape.DataLabelStyle.Visible = False
			m_Shape.DataLabelStyle.Format = "<ysize> <label>"

			' show information about the data points in the legend
			m_Shape.Legend.Mode = SeriesLegendMode.DataPoints

			' show the Y size and label in the legend
			m_Shape.Legend.Format = "<ysize> <label>"

			' use custom X positions
			m_Shape.UseXValues = True

			' use custom Z positions
			m_Shape.UseZValues = True

			' X sizes are specified in Model units (the default is Scale)
			' they will not depend on the X axis scale
			m_Shape.XSizesUnits = MeasurementUnits.Model

			' Z sizes are specified in Model units (the default is Scale)
			' they will not depend on the Z axis scale
			m_Shape.ZSizesUnits = MeasurementUnits.Model

			' Y sizes are specified in Model units (the default is Scale)
			' they will not depend on the Y axis scale
			m_Shape.YSizesUnits = MeasurementUnits.Model

			' this will require to set the InflateMargins flag to true since in this mode
			' scale is determined only by the X positions of the shape and will not take 
			' into account the size of the bubbles.
			m_Shape.InflateMargins = True

			' add the bubbles
			m_Shape.AddDataPoint(New NShapeDataPoint(10, 12, 56, 24, 24, 24, "bubble1"))
			m_Shape.AddDataPoint(New NShapeDataPoint(20, 14, 12, 10, 10, 10, "bubble2"))
			m_Shape.AddDataPoint(New NShapeDataPoint(15, 50, 45, 19, 19, 19, "bubble3"))

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			AxesRoundToTickCheck.Checked = True
			InflateMarginsCheckBox.Checked = True
			StyleCombo.SelectedIndex = 6
		End Sub

		Private Sub Bubble1FillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bubble1FillStyleButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(DirectCast(m_Shape.FillStyles(0), NFillStyle), fillStyleResult) Then
				m_Shape.FillStyles(0) = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub Bubble2FillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bubble2FillStyleButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit((DirectCast(m_Shape.FillStyles(1), NFillStyle)), fillStyleResult) Then
				m_Shape.FillStyles(1) = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub Bubble3FillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bubble3FillStyleButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit((DirectCast(m_Shape.FillStyles(2), NFillStyle)), fillStyleResult) Then
				m_Shape.FillStyles(2) = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub StyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StyleCombo.SelectedIndexChanged
			m_Shape.Shape = CType(StyleCombo.SelectedIndex, BarShape)
			nChartControl1.Refresh()
		End Sub
		Private Sub InflateMarginsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InflateMarginsCheckBox.CheckedChanged
			m_Shape.InflateMargins = InflateMarginsCheckBox.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub AxesRoundToTickCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AxesRoundToTickCheck.CheckedChanged
			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NLinearScaleConfigurator)

			linearScale.RoundToTickMin = AxesRoundToTickCheck.Checked
			linearScale.RoundToTickMax = AxesRoundToTickCheck.Checked

			linearScale = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			linearScale.RoundToTickMin = AxesRoundToTickCheck.Checked
			linearScale.RoundToTickMax = AxesRoundToTickCheck.Checked

			linearScale = CType(m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator, NLinearScaleConfigurator)

			linearScale.RoundToTickMin = AxesRoundToTickCheck.Checked
			linearScale.RoundToTickMax = AxesRoundToTickCheck.Checked

			nChartControl1.Refresh()
		End Sub
		Private Sub ChangeXValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeXValues.Click
			m_Shape.XValues.FillRandom(Random, 3)
			nChartControl1.Refresh()
		End Sub
		Private Sub ChangeZValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeZValues.Click
			m_Shape.ZValues.FillRandom(Random, 3)
			nChartControl1.Refresh()
		End Sub
		Private Sub ChangeYValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeYValues.Click
			m_Shape.Values.FillRandom(Random, 3)
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
