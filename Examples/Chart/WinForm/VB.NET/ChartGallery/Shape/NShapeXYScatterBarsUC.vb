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

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NShapeXYScatterBarsUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Shape As NShapeSeries
		Private WithEvents Bar1FillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents Bar2FillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents Bar3FillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private WithEvents StyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents InflateMarginsCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents AxesRoundToTickCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ChangeXValues As Nevron.UI.WinForm.Controls.NButton
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
			Me.Bar1FillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.Bar2FillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.Bar3FillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.StyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.InflateMarginsCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.AxesRoundToTickCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ChangeXValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' Bar1FillStyleButton
			' 
			Me.Bar1FillStyleButton.Location = New System.Drawing.Point(5, 9)
			Me.Bar1FillStyleButton.Name = "Bar1FillStyleButton"
			Me.Bar1FillStyleButton.Size = New System.Drawing.Size(170, 26)
			Me.Bar1FillStyleButton.TabIndex = 0
			Me.Bar1FillStyleButton.Text = "Bar1 Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Bar1FillStyleButton.Click += new System.EventHandler(this.Bar1FillStyleButton_Click);
			' 
			' Bar2FillStyleButton
			' 
			Me.Bar2FillStyleButton.Location = New System.Drawing.Point(5, 40)
			Me.Bar2FillStyleButton.Name = "Bar2FillStyleButton"
			Me.Bar2FillStyleButton.Size = New System.Drawing.Size(170, 26)
			Me.Bar2FillStyleButton.TabIndex = 1
			Me.Bar2FillStyleButton.Text = "Bar2 Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Bar2FillStyleButton.Click += new System.EventHandler(this.Bar2FillStyleButton_Click);
			' 
			' Bar3FillStyleButton
			' 
			Me.Bar3FillStyleButton.Location = New System.Drawing.Point(5, 71)
			Me.Bar3FillStyleButton.Name = "Bar3FillStyleButton"
			Me.Bar3FillStyleButton.Size = New System.Drawing.Size(170, 26)
			Me.Bar3FillStyleButton.TabIndex = 2
			Me.Bar3FillStyleButton.Text = "Bar3 Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Bar3FillStyleButton.Click += new System.EventHandler(this.Bar3FillStyleButton_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(5, 114)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(170, 18)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Bars Shape:"
			' 
			' StyleCombo
			' 
			Me.StyleCombo.ListProperties.CheckBoxDataMember = ""
			Me.StyleCombo.ListProperties.DataSource = Nothing
			Me.StyleCombo.ListProperties.DisplayMember = ""
			Me.StyleCombo.Location = New System.Drawing.Point(5, 132)
			Me.StyleCombo.Name = "StyleCombo"
			Me.StyleCombo.Size = New System.Drawing.Size(170, 21)
			Me.StyleCombo.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StyleCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			' 
			' InflateMarginsCheckBox
			' 
			Me.InflateMarginsCheckBox.ButtonProperties.BorderOffset = 2
			Me.InflateMarginsCheckBox.Location = New System.Drawing.Point(5, 197)
			Me.InflateMarginsCheckBox.Name = "InflateMarginsCheckBox"
			Me.InflateMarginsCheckBox.Size = New System.Drawing.Size(170, 24)
			Me.InflateMarginsCheckBox.TabIndex = 6
			Me.InflateMarginsCheckBox.Text = "Inflate Margins"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InflateMarginsCheckBox.CheckedChanged += new System.EventHandler(this.InflateMarginsCheckBox_CheckedChanged);
			' 
			' AxesRoundToTickCheck
			' 
			Me.AxesRoundToTickCheck.ButtonProperties.BorderOffset = 2
			Me.AxesRoundToTickCheck.Location = New System.Drawing.Point(5, 222)
			Me.AxesRoundToTickCheck.Name = "AxesRoundToTickCheck"
			Me.AxesRoundToTickCheck.Size = New System.Drawing.Size(170, 24)
			Me.AxesRoundToTickCheck.TabIndex = 7
			Me.AxesRoundToTickCheck.Text = "Axes Round To Tick"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AxesRoundToTickCheck.CheckedChanged += new System.EventHandler(this.AxesRoundToTickCheck_CheckedChanged);
			' 
			' ChangeXValues
			' 
			Me.ChangeXValues.Location = New System.Drawing.Point(5, 165)
			Me.ChangeXValues.Name = "ChangeXValues"
			Me.ChangeXValues.Size = New System.Drawing.Size(170, 23)
			Me.ChangeXValues.TabIndex = 5
			Me.ChangeXValues.Text = "Change X Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeXValues.Click += new System.EventHandler(this.ChangeXValues_Click);
			' 
			' NShapeXYScatterBarsUC
			' 
			Me.Controls.Add(Me.ChangeXValues)
			Me.Controls.Add(Me.AxesRoundToTickCheck)
			Me.Controls.Add(Me.InflateMarginsCheckBox)
			Me.Controls.Add(Me.StyleCombo)
			Me.Controls.Add(Me.Bar3FillStyleButton)
			Me.Controls.Add(Me.Bar2FillStyleButton)
			Me.Controls.Add(Me.Bar1FillStyleButton)
			Me.Controls.Add(Me.label1)
			Me.Name = "NShapeXYScatterBarsUC"
			Me.Size = New System.Drawing.Size(180, 265)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("XY Bars")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' switch the categories axis in numeric mode
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()

			' add interlaced stripe 
			Dim linearScale As New NLinearScaleConfigurator()
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale

			' create the shape series
			m_Shape = CType(m_Chart.Series.Add(SeriesType.Shape), NShapeSeries)

			' show information about the data points in the legend
			m_Shape.Legend.Mode = SeriesLegendMode.DataPoints

			' show the Y size and label in the legend
			m_Shape.Legend.Format = "<ysize> <label>"

			' show the Y size and label in the data point labels
			m_Shape.DataLabelStyle.Format = "<ysize> <label>"

			' use custom X positions
			m_Shape.UseXValues = True

			' X sizes are specified in Model units (the default is Scale)
			' this will make the bars size independant from the scale of the X axis 
			m_Shape.XSizesUnits = MeasurementUnits.Model

			' this will require to set the InflateMargins flag to true since in this mode
			' scale is determined only by the X positions of the shape and will not take 
			' into account the size of the bars.
			m_Shape.InflateMargins = True

			' position all shapes at the series Z order 
			m_Shape.UseZValues = False

			' add the bars
			' add Bar1
			m_Shape.AddDataPoint(New NShapeDataPoint(10, 12, 0, 10, 20, 0.66, "Bar1", New NColorFillStyle(Color.LightGreen))) ' label -  Z size - 2 thirds of series depth -  Y size of bar -  X size - 10 model units -  Z position - not used since UseZValue is set to false -  X position -  Y center of bar -> half its Y size

			' add Bar2
			m_Shape.AddDataPoint(New NShapeDataPoint(20, 34, 0, 10, 40, 0.33, "Bar2", New NColorFillStyle(Color.LightCoral))) ' label -  Z size - 1 third of series depth -  Y size of bar -  X size - 10 model units -  Z position - not used since UseZValue is set to false -  X position - not used since UseXValue is set to false -  Y center of bar -> half its Y size

			' add Bar3
			m_Shape.AddDataPoint(New NShapeDataPoint(15, 50, 0, 10, 30, 0.5, "Bar3", New NColorFillStyle(Color.LightSalmon))) ' label -  Z size - half series depth -  Y size of bar -  X size - 10 model units -  Z position - not used since UseZValue is set to false -  X position - not used since UseXValue is set to false -  Y center of bar -> half its Y size

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			InflateMarginsCheckBox.Checked = True
			AxesRoundToTickCheck.Checked = True
			StyleCombo.SelectedIndex = 0
		End Sub

		Private Sub Bar1FillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bar1FillStyleButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(DirectCast(m_Shape.FillStyles(0), NFillStyle), fillStyleResult) Then
				m_Shape.FillStyles(0) = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub Bar2FillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bar2FillStyleButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(DirectCast(m_Shape.FillStyles(1), NFillStyle), fillStyleResult) Then
				m_Shape.FillStyles(1) = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub Bar3FillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bar3FillStyleButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(DirectCast(m_Shape.FillStyles(2), NFillStyle), fillStyleResult) Then
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
			Dim standardScale As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			standardScale.RoundToTickMax = AxesRoundToTickCheck.Checked
			standardScale.RoundToTickMin = AxesRoundToTickCheck.Checked

			standardScale = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			standardScale.RoundToTickMax = AxesRoundToTickCheck.Checked
			standardScale.RoundToTickMin = AxesRoundToTickCheck.Checked

			nChartControl1.Refresh()
		End Sub
		Private Sub ChangeXValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeXValues.Click
			m_Shape.XValues.FillRandom(Random, 3)
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
