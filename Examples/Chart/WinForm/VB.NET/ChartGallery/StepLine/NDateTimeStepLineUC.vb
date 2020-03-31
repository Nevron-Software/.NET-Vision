Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NDateTimeStepLineUC
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.IContainer = Nothing
		Private WithEvents btnChangeYValues As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents btnChangeXValues As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ShowMarkersCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private Const nValuesCount As Integer = 10

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
			Me.btnChangeYValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.btnChangeXValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShowMarkersCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' btnChangeYValues
			' 
			Me.btnChangeYValues.Location = New System.Drawing.Point(5, 8)
			Me.btnChangeYValues.Name = "btnChangeYValues"
			Me.btnChangeYValues.Size = New System.Drawing.Size(170, 32)
			Me.btnChangeYValues.TabIndex = 0
			Me.btnChangeYValues.Text = "Change Y Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnChangeYValues.Click += new System.EventHandler(this.btnChangeYValues_Click);
			' 
			' btnChangeXValues
			' 
			Me.btnChangeXValues.Location = New System.Drawing.Point(5, 48)
			Me.btnChangeXValues.Name = "btnChangeXValues"
			Me.btnChangeXValues.Size = New System.Drawing.Size(170, 32)
			Me.btnChangeXValues.TabIndex = 1
			Me.btnChangeXValues.Text = "Change X Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnChangeXValues.Click += new System.EventHandler(this.btnChangeXValues_Click);
			' 
			' ShowMarkersCheck
			' 
			Me.ShowMarkersCheck.ButtonProperties.BorderOffset = 2
			Me.ShowMarkersCheck.Location = New System.Drawing.Point(5, 96)
			Me.ShowMarkersCheck.Name = "ShowMarkersCheck"
			Me.ShowMarkersCheck.Size = New System.Drawing.Size(162, 24)
			Me.ShowMarkersCheck.TabIndex = 2
			Me.ShowMarkersCheck.Text = "Show Markers"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowMarkersCheck.CheckedChanged += new System.EventHandler(this.ShowMarkersCheck_CheckedChanged);
			' 
			' NDateTimeStepLineUC
			' 
			Me.Controls.Add(Me.ShowMarkersCheck)
			Me.Controls.Add(Me.btnChangeXValues)
			Me.Controls.Add(Me.btnChangeYValues)
			Me.Name = "NDateTimeStepLineUC"
			Me.Size = New System.Drawing.Size(180, 150)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("DateTime Step Line")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Width = 90
			chart.BoundsMode = BoundsMode.Stretch

			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			' add interlace stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' switch the X axis in date time scale mode
			Dim dateTimeScale As New NDateTimeScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale
			dateTimeScale.LabelGenerationMode = LabelGenerationMode.Stagger2
			dateTimeScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' setup step line series
			Dim line As NStepLineSeries = CType(chart.Series.Add(SeriesType.StepLine), NStepLineSeries)
			line.Name = "Step Line Series"
			line.InflateMargins = True
			line.UseXValues = True
			line.UseZValues = False
			line.DataLabelStyle.Visible = False
			line.ShadowStyle.Type = ShadowType.Solid
			line.ShadowStyle.Color = Color.FromArgb(15, 0, 0, 0)
			line.MarkerStyle.PointShape = PointShape.Cylinder
			line.MarkerStyle.Width = New NLength(1.2F, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Height = New NLength(1.2F, NRelativeUnit.ParentPercentage)

			GenerateYValues(nValuesCount)
			GenerateXValues(nValuesCount)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Sub btnChangeYValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeYValues.Click
			GenerateYValues(nValuesCount)
			nChartControl1.Refresh()
		End Sub

		Private Sub btnChangeXValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeXValues.Click
			GenerateXValues(nValuesCount)
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowMarkersCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowMarkersCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim line As NStepLineSeries = CType(chart.Series(0), NStepLineSeries)

			line.MarkerStyle.Visible = ShowMarkersCheck.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub GenerateYValues(ByVal nCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim line As NStepLineSeries = CType(chart.Series(0), NStepLineSeries)

			line.Values.Clear()

			For i As Integer = 0 To nCount - 1
				line.Values.Add(Random.NextDouble() * 20)
			Next i
		End Sub

		Private Sub GenerateXValues(ByVal nCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim line As NStepLineSeries = CType(chart.Series(0), NStepLineSeries)

			line.XValues.Clear()

			Dim dt As New Date(2005, 5, 24, 11, 0, 0)

			For i As Integer = 0 To nCount - 1
				dt = dt.AddHours(12 + Random.NextDouble() * 60)

				line.XValues.Add(dt)
			Next i
		End Sub
	End Class
End Namespace

