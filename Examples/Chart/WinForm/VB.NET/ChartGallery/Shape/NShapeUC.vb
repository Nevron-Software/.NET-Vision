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
	<ToolboxItem(False)> _
	Public Class NShapeUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Shape As NShapeSeries
		Private label1 As System.Windows.Forms.Label
		Private WithEvents ShapeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents UseXValuesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents UseZValuesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents DifferentColorsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShapesColorButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ShapesBorderButton As Nevron.UI.WinForm.Controls.NButton
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			ShapeCombo.FillFromEnum(GetType(BarShape))
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
			Me.ShapeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.UseXValuesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.UseZValuesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShapesColorButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.DifferentColorsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShapesBorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(5, 10)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(170, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Shape:"
			' 
			' ShapeCombo
			' 
			Me.ShapeCombo.ListProperties.CheckBoxDataMember = ""
			Me.ShapeCombo.ListProperties.DataSource = Nothing
			Me.ShapeCombo.ListProperties.DisplayMember = ""
			Me.ShapeCombo.Location = New System.Drawing.Point(5, 26)
			Me.ShapeCombo.Name = "ShapeCombo"
			Me.ShapeCombo.Size = New System.Drawing.Size(170, 21)
			Me.ShapeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShapeCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			' 
			' UseXValuesCheck
			' 
			Me.UseXValuesCheck.ButtonProperties.BorderOffset = 2
			Me.UseXValuesCheck.Location = New System.Drawing.Point(5, 54)
			Me.UseXValuesCheck.Name = "UseXValuesCheck"
			Me.UseXValuesCheck.Size = New System.Drawing.Size(170, 21)
			Me.UseXValuesCheck.TabIndex = 2
			Me.UseXValuesCheck.Text = "Use X Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UseXValuesCheck.CheckedChanged += new System.EventHandler(this.UseXValuesCheck_CheckedChanged);
			' 
			' UseZValuesCheck
			' 
			Me.UseZValuesCheck.ButtonProperties.BorderOffset = 2
			Me.UseZValuesCheck.Location = New System.Drawing.Point(5, 80)
			Me.UseZValuesCheck.Name = "UseZValuesCheck"
			Me.UseZValuesCheck.Size = New System.Drawing.Size(170, 19)
			Me.UseZValuesCheck.TabIndex = 3
			Me.UseZValuesCheck.Text = "Use Z Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UseZValuesCheck.CheckedChanged += new System.EventHandler(this.UseZValuesCheck_CheckedChanged);
			' 
			' ShapesColorButton
			' 
			Me.ShapesColorButton.Location = New System.Drawing.Point(5, 136)
			Me.ShapesColorButton.Name = "ShapesColorButton"
			Me.ShapesColorButton.Size = New System.Drawing.Size(170, 23)
			Me.ShapesColorButton.TabIndex = 5
			Me.ShapesColorButton.Text = "Shapes Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShapesColorButton.Click += new System.EventHandler(this.ShapesColorButton_Click);
			' 
			' DifferentColorsCheck
			' 
			Me.DifferentColorsCheck.ButtonProperties.BorderOffset = 2
			Me.DifferentColorsCheck.Location = New System.Drawing.Point(5, 104)
			Me.DifferentColorsCheck.Name = "DifferentColorsCheck"
			Me.DifferentColorsCheck.Size = New System.Drawing.Size(170, 21)
			Me.DifferentColorsCheck.TabIndex = 4
			Me.DifferentColorsCheck.Text = "Different Colors"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DifferentColorsCheck.CheckedChanged += new System.EventHandler(this.DifferentColorsCheck_CheckedChanged);
			' 
			' ShapesBorderButton
			' 
			Me.ShapesBorderButton.Location = New System.Drawing.Point(5, 166)
			Me.ShapesBorderButton.Name = "ShapesBorderButton"
			Me.ShapesBorderButton.Size = New System.Drawing.Size(170, 23)
			Me.ShapesBorderButton.TabIndex = 6
			Me.ShapesBorderButton.Text = "Shapes Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShapesBorderButton.Click += new System.EventHandler(this.ShapesBorderButton_Click);
			' 
			' NShapeUC
			' 
			Me.Controls.Add(Me.ShapesBorderButton)
			Me.Controls.Add(Me.DifferentColorsCheck)
			Me.Controls.Add(Me.ShapesColorButton)
			Me.Controls.Add(Me.UseZValuesCheck)
			Me.Controls.Add(Me.UseXValuesCheck)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.ShapeCombo)
			Me.Name = "NShapeUC"
			Me.Size = New System.Drawing.Size(180, 227)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Shape Series")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			m_Chart.Projection.Elevation -= 10
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			m_Chart.Depth = 55.0F
			m_Chart.Width = 55.0F
			m_Chart.Height = 55.0F

			' setup X axis
			Dim scaleX As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back, ChartWallType.Floor }
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' setup Y axis
			Dim scaleY As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back, ChartWallType.Left }
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlaced stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back, ChartWallType.Left }
			stripStyle.Interlaced = True
			scaleY.StripStyles.Add(stripStyle)

			' setup Z axis
			Dim scaleZ As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ
			scaleZ.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Left, ChartWallType.Floor }
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' setup shape series
			m_Shape = CType(m_Chart.Series.Add(SeriesType.Shape), NShapeSeries)
			m_Shape.FillStyle = New NColorFillStyle(Color.Red)
			m_Shape.BorderStyle.Color = Color.DarkRed
			m_Shape.DataLabelStyle.Visible = False
			m_Shape.UseXValues = True
			m_Shape.UseZValues = True

			' populate with random data
			m_Shape.Values.FillRandomRange(Random, 10, -100, 100)
			m_Shape.XValues.FillRandomRange(Random, 10, -100, 100)
			m_Shape.ZValues.FillRandomRange(Random, 10, -100, 100)

			m_Shape.YSizes.FillRandomRange(Random, 10, 5, 20)
			m_Shape.XSizes.FillRandomRange(Random, 10, 5, 20)
			m_Shape.ZSizes.FillRandomRange(Random, 10, 5, 20)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, Nothing)

			' init form controls
			ShapeCombo.SelectedIndex = 0
			UseXValuesCheck.Checked = True
			UseZValuesCheck.Checked = True
			DifferentColorsCheck.Checked = True
		End Sub

		Private Sub StyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShapeCombo.SelectedIndexChanged
			m_Shape.Shape = CType(ShapeCombo.SelectedIndex, BarShape)
			nChartControl1.Refresh()
		End Sub
		Private Sub UseXValuesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UseXValuesCheck.CheckedChanged
			If UseXValuesCheck.Checked Then
				m_Shape.UseXValues = True
			Else
				m_Shape.UseXValues = False
			End If

			nChartControl1.Refresh()
		End Sub
		Private Sub UseZValuesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UseZValuesCheck.CheckedChanged
			If UseZValuesCheck.Checked Then
				m_Shape.UseZValues = True
			Else
				m_Shape.UseZValues = False
			End If

			nChartControl1.Refresh()
		End Sub
		Private Sub DifferentColorsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DifferentColorsCheck.CheckedChanged
			If DifferentColorsCheck.Checked Then
				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
				styleSheet.Apply(nChartControl1.Document)

				ShapesColorButton.Enabled = False
				ShapesBorderButton.Enabled = False
			Else
				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
				styleSheet.Apply(nChartControl1.Document)

				ShapesColorButton.Enabled = True
				ShapesBorderButton.Enabled = True
			End If

			nChartControl1.Refresh()
		End Sub
		Private Sub ShapesColorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShapesColorButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_Shape.FillStyle, fillStyleResult) Then
				m_Shape.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub ShapesBorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShapesBorderButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Shape.BorderStyle, strokeStyleResult) Then
				m_Shape.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
