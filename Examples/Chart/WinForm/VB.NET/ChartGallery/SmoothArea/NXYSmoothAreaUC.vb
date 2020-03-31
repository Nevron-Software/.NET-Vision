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
	Public Class NXYSmoothAreaUC
		Inherits NExampleBaseUC

		Private Const nValuesCount As Integer = 6
		Private WithEvents btnChangeXValues As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents RoundToTickCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowMarkersCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowDropLinesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents AreaOriginModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents OriginValueTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents btnChangeYValues As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
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
			Me.btnChangeXValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.btnChangeYValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.RoundToTickCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowMarkersCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowDropLinesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.OriginValueTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.AreaOriginModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' btnChangeXValues
			' 
			Me.btnChangeXValues.Location = New System.Drawing.Point(4, 48)
			Me.btnChangeXValues.Name = "btnChangeXValues"
			Me.btnChangeXValues.Size = New System.Drawing.Size(173, 32)
			Me.btnChangeXValues.TabIndex = 1
			Me.btnChangeXValues.Text = "Change X Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnChangeXValues.Click += new System.EventHandler(this.btnChangeXValues_Click);
			' 
			' btnChangeYValues
			' 
			Me.btnChangeYValues.Location = New System.Drawing.Point(4, 8)
			Me.btnChangeYValues.Name = "btnChangeYValues"
			Me.btnChangeYValues.Size = New System.Drawing.Size(173, 32)
			Me.btnChangeYValues.TabIndex = 0
			Me.btnChangeYValues.Text = "Change Y Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnChangeYValues.Click += new System.EventHandler(this.btnChangeYValues_Click);
			' 
			' RoundToTickCheck
			' 
			Me.RoundToTickCheck.ButtonProperties.BorderOffset = 2
			Me.RoundToTickCheck.Location = New System.Drawing.Point(3, 275)
			Me.RoundToTickCheck.Name = "RoundToTickCheck"
			Me.RoundToTickCheck.Size = New System.Drawing.Size(173, 24)
			Me.RoundToTickCheck.TabIndex = 8
			Me.RoundToTickCheck.Text = "Axis Round To Tick "
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RoundToTickCheck.CheckedChanged += new System.EventHandler(this.checkRoundToTick_CheckedChanged);
			' 
			' ShowMarkersCheck
			' 
			Me.ShowMarkersCheck.ButtonProperties.BorderOffset = 2
			Me.ShowMarkersCheck.Location = New System.Drawing.Point(3, 96)
			Me.ShowMarkersCheck.Name = "ShowMarkersCheck"
			Me.ShowMarkersCheck.Size = New System.Drawing.Size(173, 24)
			Me.ShowMarkersCheck.TabIndex = 2
			Me.ShowMarkersCheck.Text = "Show Markers"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowMarkersCheck.CheckedChanged += new System.EventHandler(this.checkShowMarkers_CheckedChanged);
			' 
			' ShowDropLinesCheck
			' 
			Me.ShowDropLinesCheck.ButtonProperties.BorderOffset = 2
			Me.ShowDropLinesCheck.Location = New System.Drawing.Point(3, 120)
			Me.ShowDropLinesCheck.Name = "ShowDropLinesCheck"
			Me.ShowDropLinesCheck.Size = New System.Drawing.Size(173, 24)
			Me.ShowDropLinesCheck.TabIndex = 3
			Me.ShowDropLinesCheck.Text = "Show Drop Lines"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowDropLinesCheck.CheckedChanged += new System.EventHandler(this.ShowDropLinesCheck_CheckedChanged);
			' 
			' OriginValueTextBox
			' 
			Me.OriginValueTextBox.Location = New System.Drawing.Point(4, 231)
			Me.OriginValueTextBox.Name = "OriginValueTextBox"
			Me.OriginValueTextBox.Size = New System.Drawing.Size(173, 18)
			Me.OriginValueTextBox.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OriginValueTextBox.TextChanged += new System.EventHandler(this.OriginValueTextBox_TextChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(4, 208)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(109, 20)
			Me.label1.TabIndex = 6
			Me.label1.Text = "Origin Value:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' AreaOriginModeCombo
			' 
			Me.AreaOriginModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.AreaOriginModeCombo.ListProperties.DataSource = Nothing
			Me.AreaOriginModeCombo.ListProperties.DisplayMember = ""
			Me.AreaOriginModeCombo.Location = New System.Drawing.Point(4, 176)
			Me.AreaOriginModeCombo.Name = "AreaOriginModeCombo"
			Me.AreaOriginModeCombo.Size = New System.Drawing.Size(173, 21)
			Me.AreaOriginModeCombo.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AreaOriginModeCombo.SelectedIndexChanged += new System.EventHandler(this.AreaOriginModeCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(4, 160)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(165, 16)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Area Origin Mode:"
			' 
			' NXYSmoothAreaUC
			' 
			Me.Controls.Add(Me.AreaOriginModeCombo)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.OriginValueTextBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.ShowDropLinesCheck)
			Me.Controls.Add(Me.RoundToTickCheck)
			Me.Controls.Add(Me.ShowMarkersCheck)
			Me.Controls.Add(Me.btnChangeXValues)
			Me.Controls.Add(Me.btnChangeYValues)
			Me.Name = "NXYSmoothAreaUC"
			Me.Size = New System.Drawing.Size(180, 320)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XY Smooth Area")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legends
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 65
			chart.Height = 40
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Axis(StandardAxis.Depth).Visible = False

			' setup axes
			Dim linearScaleX As New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleX

			Dim linearScaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScaleY.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' add interlaced stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleY.StripStyles.Add(stripStyle)

			' add the area series
			Dim area As NSmoothAreaSeries = CType(chart.Series.Add(SeriesType.SmoothArea), NSmoothAreaSeries)
			area.DataLabelStyle.Visible = False
			area.MarkerStyle.Visible = True
			area.MarkerStyle.PointShape = PointShape.Cylinder
			area.MarkerStyle.AutoDepth = True
			area.MarkerStyle.Width = New NLength(1.4F, NRelativeUnit.ParentPercentage)
			area.MarkerStyle.Height = New NLength(1.4F, NRelativeUnit.ParentPercentage)
			area.UseXValues = True

			GenerateYValues(nValuesCount)
			GenerateXValues(nValuesCount)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			ShowMarkersCheck.Checked = True
			RoundToTickCheck.Checked = True
			ShowDropLinesCheck.Checked = False
			AreaOriginModeCombo.FillFromEnum(GetType(SeriesOriginMode))
			AreaOriginModeCombo.SelectedIndex = 0
			OriginValueTextBox.Text = "0"
		End Sub

		Private Sub GenerateYValues(ByVal nCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim series As NSeries = CType(chart.Series(0), NSeries)

			series.Values.Clear()

			For i As Integer = 0 To nCount - 1
				series.Values.Add(5 + Random.NextDouble() * 10)
			Next i
		End Sub
		Private Sub GenerateXValues(ByVal nCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim series As NXYScatterSeries = CType(chart.Series(0), NXYScatterSeries)

			series.XValues.Clear()

			Dim x As Double = 120

			For i As Integer = 0 To nCount - 1
				x += 10 + Random.NextDouble() * 10

				series.XValues.Add(x)
			Next i
		End Sub

		Private Sub btnChangeYValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeYValues.Click
			GenerateYValues(nValuesCount)
			nChartControl1.Refresh()
		End Sub
		Private Sub btnChangeXValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeXValues.Click
			GenerateXValues(nValuesCount)
			nChartControl1.Refresh()
		End Sub
		Private Sub checkShowMarkers_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowMarkersCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim series As NSeries = CType(chart.Series(0), NSeries)

			series.MarkerStyle.Visible = ShowMarkersCheck.Checked

			nChartControl1.Refresh()
		End Sub
		Private Sub checkRoundToTick_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RoundToTickCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)

			Dim bRoundToTick As Boolean = RoundToTickCheck.Checked

			Dim standardScale As NStandardScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			standardScale.RoundToTickMin = bRoundToTick
			standardScale.RoundToTickMax = bRoundToTick

			standardScale = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			standardScale.RoundToTickMin = bRoundToTick
			standardScale.RoundToTickMax = bRoundToTick

			nChartControl1.Refresh()
		End Sub
		Private Sub ShowDropLinesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowDropLinesCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim area As NSmoothAreaSeries = CType(chart.Series(0), NSmoothAreaSeries)

			area.DropLines = ShowDropLinesCheck.Checked

			nChartControl1.Refresh()
		End Sub
		Private Sub AreaOriginModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AreaOriginModeCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim area As NSmoothAreaSeries = CType(chart.Series(0), NSmoothAreaSeries)

			area.OriginMode = CType(AreaOriginModeCombo.SelectedIndex, SeriesOriginMode)

			nChartControl1.Refresh()

			OriginValueTextBox.Enabled = (area.OriginMode = SeriesOriginMode.CustomOrigin)
		End Sub
		Private Sub OriginValueTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OriginValueTextBox.TextChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim area As NSmoothAreaSeries = CType(chart.Series(0), NSmoothAreaSeries)

			Try
				area.Origin = Double.Parse(OriginValueTextBox.Text)
				nChartControl1.Refresh()
			Catch
			End Try
		End Sub
	End Class
End Namespace

