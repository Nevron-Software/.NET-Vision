Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WinForm

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NStackFloatBarUC
		Inherits NExampleBaseUC

		Private Const dataPointCount As Integer = 8
		Private WithEvents PosDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PosNegDataButton As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private WithEvents BarShapeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private components As System.ComponentModel.IContainer = Nothing

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

		#Region "Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.PosDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.PosNegDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.BarShapeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' PosDataButton
			' 
			Me.PosDataButton.Location = New System.Drawing.Point(6, 72)
			Me.PosDataButton.Name = "PosDataButton"
			Me.PosDataButton.Size = New System.Drawing.Size(162, 24)
			Me.PosDataButton.TabIndex = 2
			Me.PosDataButton.Text = "Positive Data..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PosDataButton.Click += new System.EventHandler(this.PosDataButton_Click);
			' 
			' PosNegDataButton
			' 
			Me.PosNegDataButton.Location = New System.Drawing.Point(6, 104)
			Me.PosNegDataButton.Name = "PosNegDataButton"
			Me.PosNegDataButton.Size = New System.Drawing.Size(162, 24)
			Me.PosNegDataButton.TabIndex = 3
			Me.PosNegDataButton.Text = "Positive and Negative Data..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PosNegDataButton.Click += new System.EventHandler(this.PosNegDataButton_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(128, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Bar Shape:"
			' 
			' BarShapeCombo
			' 
			Me.BarShapeCombo.ListProperties.CheckBoxDataMember = ""
			Me.BarShapeCombo.ListProperties.DataSource = Nothing
			Me.BarShapeCombo.ListProperties.DisplayMember = ""
			Me.BarShapeCombo.Location = New System.Drawing.Point(8, 24)
			Me.BarShapeCombo.Name = "BarShapeCombo"
			Me.BarShapeCombo.Size = New System.Drawing.Size(160, 21)
			Me.BarShapeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarShapeCombo.SelectedIndexChanged += new System.EventHandler(this.BarShapeCombo_SelectedIndexChanged);
			' 
			' NStackFloatBarUC
			' 
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.BarShapeCombo)
			Me.Controls.Add(Me.PosNegDataButton)
			Me.Controls.Add(Me.PosDataButton)
			Me.Name = "NStackFloatBarUC"
			Me.Size = New System.Drawing.Size(180, 192)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("Stack Float Bar")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 65
			chart.Height = 40
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' add interlaced stripe to the Y axis
			Dim scaleY As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }
			stripStyle.Interlaced = True
			scaleY.StripStyles.Add(stripStyle)

			' setup the floatbar series
			Dim floatbar As NFloatBarSeries = CType(chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			floatbar.MultiFloatBarMode = MultiFloatBarMode.Series
			floatbar.Name = "Floatbar series"
			floatbar.FillStyle = New NColorFillStyle(Color.SandyBrown)
			floatbar.DataLabelStyle.Visible = False

			' setup the bar series
			Dim bar1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar1.Name = "Bar series"
			bar1.MultiBarMode = MultiBarMode.Stacked
			bar1.FillStyle = New NColorFillStyle(Color.Green)
			bar1.DataLabelStyle.Visible = False

			' setup the bar series
			Dim bar2 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar2.Name = "Bar series"
			bar2.MultiBarMode = MultiBarMode.Stacked
			bar2.FillStyle = New NColorFillStyle(Color.CornflowerBlue)
			bar2.DataLabelStyle.Visible = False

			GeneratePosData()

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' init form controls
			BarShapeCombo.FillFromEnum(GetType(BarShape))
			BarShapeCombo.SelectedIndex = 0

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Function GetRandValue(ByVal min As Double, ByVal max As Double) As Double
			If max < min Then
				Dim temp As Double = min
				min = max
				max = temp
			End If

			Return min + Random.NextDouble() * (max - min)
		End Function

		Private Function SetRandSign(ByVal val As Double) As Double
			If Random.NextDouble() > 0.5 Then
				Return val
			End If

			Return -val
		End Function

		Private Sub PosDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PosDataButton.Click
			GeneratePosData()
			nChartControl1.Refresh()
		End Sub

		Private Sub PosNegDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PosNegDataButton.Click
			GeneratePosNegData()
			nChartControl1.Refresh()
		End Sub

		Private Sub GeneratePosData()
			Dim floatbar As NFloatBarSeries = CType(nChartControl1.Charts(0).Series(0), NFloatBarSeries)
			Dim bar1 As NBarSeries = CType(nChartControl1.Charts(0).Series(1), NBarSeries)
			Dim bar2 As NBarSeries = CType(nChartControl1.Charts(0).Series(2), NBarSeries)

			floatbar.BeginValues.Clear()
			floatbar.EndValues.Clear()
			bar1.Values.Clear()
			bar2.Values.Clear()

			For i As Integer = 0 To dataPointCount - 1
				floatbar.BeginValues.Add(GetRandValue(1, 4))
				floatbar.EndValues.Add(GetRandValue(6, 9))
				bar1.Values.Add(GetRandValue(3, 7))
				bar2.Values.Add(GetRandValue(3, 7))
			Next i
		End Sub

		Private Sub GeneratePosNegData()
			Dim floatbar As NFloatBarSeries = CType(nChartControl1.Charts(0).Series(0), NFloatBarSeries)
			Dim bar1 As NBarSeries = CType(nChartControl1.Charts(0).Series(1), NBarSeries)
			Dim bar2 As NBarSeries = CType(nChartControl1.Charts(0).Series(2), NBarSeries)

			floatbar.BeginValues.Clear()
			floatbar.EndValues.Clear()
			bar1.Values.Clear()
			bar2.Values.Clear()

			For i As Integer = 0 To dataPointCount - 1
				floatbar.BeginValues.Add(GetRandValue(-10, 10))
				floatbar.EndValues.Add(SetRandSign(GetRandValue(10, 20)))
				bar1.Values.Add(SetRandSign(GetRandValue(5, 10)))
				bar2.Values.Add(SetRandSign(GetRandValue(5, 10)))
			Next i
		End Sub

		Private Sub BarShapeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarShapeCombo.SelectedIndexChanged
			Dim floatbar As NFloatBarSeries = CType(nChartControl1.Charts(0).Series(0), NFloatBarSeries)
			Dim bar1 As NBarSeries = CType(nChartControl1.Charts(0).Series(1), NBarSeries)
			Dim bar2 As NBarSeries = CType(nChartControl1.Charts(0).Series(2), NBarSeries)

			Dim selectedShape As BarShape = CType(BarShapeCombo.SelectedIndex, BarShape)

			floatbar.BarShape = selectedShape
			bar1.BarShape = selectedShape
			bar2.BarShape = selectedShape

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace

