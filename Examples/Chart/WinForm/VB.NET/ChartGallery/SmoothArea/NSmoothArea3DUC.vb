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
	<ToolboxItem(False)>
	Public Class NSmoothArea3DUC
		Inherits NExampleBaseUC

		Private Const nValuesCount As Integer = 6
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
			Me.btnChangeYValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShowMarkersCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowDropLinesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.OriginValueTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.AreaOriginModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' btnChangeYValues
			' 
			Me.btnChangeYValues.Location = New System.Drawing.Point(6, 8)
			Me.btnChangeYValues.Name = "btnChangeYValues"
			Me.btnChangeYValues.Size = New System.Drawing.Size(170, 32)
			Me.btnChangeYValues.TabIndex = 0
			Me.btnChangeYValues.Text = "Change Y Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnChangeYValues.Click += new System.EventHandler(this.btnChangeYValues_Click);
			' 
			' ShowMarkersCheck
			' 
			Me.ShowMarkersCheck.ButtonProperties.BorderOffset = 2
			Me.ShowMarkersCheck.Location = New System.Drawing.Point(5, 48)
			Me.ShowMarkersCheck.Name = "ShowMarkersCheck"
			Me.ShowMarkersCheck.Size = New System.Drawing.Size(170, 24)
			Me.ShowMarkersCheck.TabIndex = 1
			Me.ShowMarkersCheck.Text = "Show Markers"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowMarkersCheck.CheckedChanged += new System.EventHandler(this.checkShowMarkers_CheckedChanged);
			' 
			' ShowDropLinesCheck
			' 
			Me.ShowDropLinesCheck.ButtonProperties.BorderOffset = 2
			Me.ShowDropLinesCheck.Location = New System.Drawing.Point(5, 72)
			Me.ShowDropLinesCheck.Name = "ShowDropLinesCheck"
			Me.ShowDropLinesCheck.Size = New System.Drawing.Size(170, 24)
			Me.ShowDropLinesCheck.TabIndex = 2
			Me.ShowDropLinesCheck.Text = "Show Drop Lines"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowDropLinesCheck.CheckedChanged += new System.EventHandler(this.ShowDropLinesCheck_CheckedChanged);
			' 
			' OriginValueTextBox
			' 
			Me.OriginValueTextBox.Location = New System.Drawing.Point(6, 180)
			Me.OriginValueTextBox.Name = "OriginValueTextBox"
			Me.OriginValueTextBox.Size = New System.Drawing.Size(170, 18)
			Me.OriginValueTextBox.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OriginValueTextBox.TextChanged += new System.EventHandler(this.OriginValueTextBox_TextChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(6, 159)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(106, 20)
			Me.label1.TabIndex = 5
			Me.label1.Text = "Origin Value:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' AreaOriginModeCombo
			' 
			Me.AreaOriginModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.AreaOriginModeCombo.ListProperties.DataSource = Nothing
			Me.AreaOriginModeCombo.ListProperties.DisplayMember = ""
			Me.AreaOriginModeCombo.Location = New System.Drawing.Point(6, 128)
			Me.AreaOriginModeCombo.Name = "AreaOriginModeCombo"
			Me.AreaOriginModeCombo.Size = New System.Drawing.Size(170, 21)
			Me.AreaOriginModeCombo.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AreaOriginModeCombo.SelectedIndexChanged += new System.EventHandler(this.AreaOriginModeCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(6, 112)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(162, 16)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Area Origin Mode:"
			' 
			' NSmoothArea3DUC
			' 
			Me.Controls.Add(Me.AreaOriginModeCombo)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.OriginValueTextBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.ShowDropLinesCheck)
			Me.Controls.Add(Me.ShowMarkersCheck)
			Me.Controls.Add(Me.btnChangeYValues)
			Me.Name = "NSmoothArea3DUC"
			Me.Size = New System.Drawing.Size(180, 212)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("3D Smooth Area")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legends
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 65
			chart.Height = 40
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' add interlaced stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' add the area series
			Dim area As NSmoothAreaSeries = CType(chart.Series.Add(SeriesType.SmoothArea), NSmoothAreaSeries)
			area.DataLabelStyle.Visible = False
			area.MarkerStyle.Visible = False
			area.MarkerStyle.PointShape = PointShape.Cylinder
			area.MarkerStyle.AutoDepth = True
			area.MarkerStyle.Width = New NLength(1.4F, NRelativeUnit.ParentPercentage)
			area.MarkerStyle.Height = New NLength(1.4F, NRelativeUnit.ParentPercentage)

			GenerateYValues(nValuesCount)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form conrols
			ShowMarkersCheck.Checked = False
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

			Dim dt As New Date(2005, 5, 24, 11, 0, 0)

			For i As Integer = 0 To nCount - 1
				dt = dt.AddHours(12 + Random.NextDouble() * 60)

				series.XValues.Add(dt)
			Next i
		End Sub

		Private Sub btnChangeYValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeYValues.Click
			GenerateYValues(nValuesCount)
			nChartControl1.Refresh()
		End Sub
		Private Sub btnChangeXValues_Click(ByVal sender As Object, ByVal e As System.EventArgs)
			GenerateXValues(nValuesCount)
			nChartControl1.Refresh()
		End Sub
		Private Sub checkShowMarkers_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowMarkersCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim series As NSeries = CType(chart.Series(0), NSeries)

			series.MarkerStyle.Visible = ShowMarkersCheck.Checked

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

