Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Resources
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NChartAspect3DUC
		Inherits NExampleBaseUC

		Private label2 As Label
		Private WithEvents XProportionCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As Label
		Private label3 As Label
		Private WithEvents YProportionCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents FitAxisContentCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label4 As Label
		Private WithEvents ZProportionCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents ShowContentAreaCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.label2 = New System.Windows.Forms.Label()
			Me.XProportionCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.YProportionCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.FitAxisContentCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.ZProportionCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.ShowContentAreaCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(11, 14)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(80, 14)
			Me.label2.TabIndex = 6
			Me.label2.Text = "Proportion:"
			' 
			' XProportionCombo
			' 
			Me.XProportionCombo.ListProperties.CheckBoxDataMember = ""
			Me.XProportionCombo.ListProperties.DataSource = Nothing
			Me.XProportionCombo.ListProperties.DisplayMember = ""
			Me.XProportionCombo.Location = New System.Drawing.Point(47, 35)
			Me.XProportionCombo.Name = "XProportionCombo"
			Me.XProportionCombo.Size = New System.Drawing.Size(121, 21)
			Me.XProportionCombo.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XProportionCombo.SelectedIndexChanged += new System.EventHandler(this.XProportionCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(11, 42)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(29, 14)
			Me.label1.TabIndex = 7
			Me.label1.Text = "X:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(11, 69)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(29, 14)
			Me.label3.TabIndex = 9
			Me.label3.Text = "Y:"
			' 
			' YProportionCombo
			' 
			Me.YProportionCombo.ListProperties.CheckBoxDataMember = ""
			Me.YProportionCombo.ListProperties.DataSource = Nothing
			Me.YProportionCombo.ListProperties.DisplayMember = ""
			Me.YProportionCombo.Location = New System.Drawing.Point(47, 62)
			Me.YProportionCombo.Name = "YProportionCombo"
			Me.YProportionCombo.Size = New System.Drawing.Size(121, 21)
			Me.YProportionCombo.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YProportionCombo.SelectedIndexChanged += new System.EventHandler(this.YProportionCombo_SelectedIndexChanged);
			' 
			' FitAxisContentCheckBox
			' 
			Me.FitAxisContentCheckBox.ButtonProperties.BorderOffset = 2
			Me.FitAxisContentCheckBox.Location = New System.Drawing.Point(11, 126)
			Me.FitAxisContentCheckBox.Name = "FitAxisContentCheckBox"
			Me.FitAxisContentCheckBox.Size = New System.Drawing.Size(157, 21)
			Me.FitAxisContentCheckBox.TabIndex = 10
			Me.FitAxisContentCheckBox.Text = "Fit Axis Content"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FitAxisContentCheckBox.CheckedChanged += new System.EventHandler(this.Fit3DAxisContentCheckBox_CheckedChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(11, 96)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(29, 14)
			Me.label4.TabIndex = 12
			Me.label4.Text = "Z:"
			' 
			' ZProportionCombo
			' 
			Me.ZProportionCombo.ListProperties.CheckBoxDataMember = ""
			Me.ZProportionCombo.ListProperties.DataSource = Nothing
			Me.ZProportionCombo.ListProperties.DisplayMember = ""
			Me.ZProportionCombo.Location = New System.Drawing.Point(47, 89)
			Me.ZProportionCombo.Name = "ZProportionCombo"
			Me.ZProportionCombo.Size = New System.Drawing.Size(121, 21)
			Me.ZProportionCombo.TabIndex = 11
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ZProportionCombo.SelectedIndexChanged += new System.EventHandler(this.ZProportionCombo_SelectedIndexChanged);
			' 
			' ShowContentAreaCheckBox
			' 
			Me.ShowContentAreaCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowContentAreaCheckBox.Location = New System.Drawing.Point(11, 145)
			Me.ShowContentAreaCheckBox.Name = "ShowContentAreaCheckBox"
			Me.ShowContentAreaCheckBox.Size = New System.Drawing.Size(157, 21)
			Me.ShowContentAreaCheckBox.TabIndex = 13
			Me.ShowContentAreaCheckBox.Text = "Show Content Area"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowContentAreaCheckBox.CheckedChanged += new System.EventHandler(this.ShowContentAreaCheckBox_CheckedChanged);
			' 
			' NChartAspect3DUC
			' 
			Me.Controls.Add(Me.ShowContentAreaCheckBox)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.ZProportionCombo)
			Me.Controls.Add(Me.FitAxisContentCheckBox)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.YProportionCombo)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.XProportionCombo)
			Me.Name = "NChartAspect3DUC"
			Me.Size = New System.Drawing.Size(180, 238)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As New NLabel("Chart Aspect 3D")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.DockMode = PanelDockMode.Top
			title.Margins = New NMarginsL(10, 10, 10, 0)
			nChartControl1.Panels.Add(title)


			' setup chart
			Dim chart As New NCartesianChart()
			nChartControl1.Panels.Add(chart)

			chart.DockMode = PanelDockMode.Fill
			chart.Margins = New NMarginsL(New NLength(10))
			chart.Padding = New NMarginsL(2)

			chart.Enable3D = True
			chart.Width = 50
			chart.Height = 50
			chart.Depth = 50
			chart.BoundsMode = BoundsMode.Fit
			chart.ContentAlignment = ContentAlignment.BottomRight
			chart.Location = New NPointL(New NLength(15, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
			chart.Wall(ChartWallType.Back).Width = 0.01F
			chart.Wall(ChartWallType.Floor).Width = 0.01F
			chart.Wall(ChartWallType.Left).Width = 0.01F

			' apply predefined projection and lighting
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight)

			' add axis labels
			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.AutoLabels = False
			ordinalScale.Labels.Add("Miami")
			ordinalScale.Labels.Add("Chicago")
			ordinalScale.Labels.Add("Los Angeles")
			ordinalScale.Labels.Add("New York")
			ordinalScale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)

			ordinalScale = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' add interlace stripe to the Y axis
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			Dim barsCount As Integer = 7

			' add the first bar
			Dim bar1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar1.MultiBarMode = MultiBarMode.Series
			bar1.Name = "Bar1"
			bar1.DataLabelStyle.Visible = False
			bar1.BorderStyle.Color = Color.FromArgb(210, 210, 255)

			' add the second bar
			Dim bar2 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar2.MultiBarMode = MultiBarMode.Series
			bar2.Name = "Bar2"
			bar2.DataLabelStyle.Visible = False
			bar2.BorderStyle.Color = Color.FromArgb(210, 255, 210)

			' add the third bar
			Dim bar3 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar3.MultiBarMode = MultiBarMode.Series
			bar3.Name = "Bar3"
			bar3.DataLabelStyle.Visible = False
			bar3.BorderStyle.Color = Color.FromArgb(255, 255, 210)

			' add the second bar
			Dim bar4 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar4.MultiBarMode = MultiBarMode.Series
			bar4.Name = "Bar4"
			bar4.DataLabelStyle.Visible = False
			bar4.BorderStyle.Color = Color.FromArgb(255, 210, 210)

			' fill with random data
			bar1.Values.FillRandomRange(Random, barsCount, 10, 40)
			bar2.Values.FillRandomRange(Random, barsCount, 30, 60)
			bar3.Values.FillRandomRange(Random, barsCount, 50, 80)
			bar4.Values.FillRandomRange(Random, barsCount, 70, 100)

			' setup trackball interactivity
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			For i As Integer = 1 To 5
				XProportionCombo.Items.Add(i.ToString())
				YProportionCombo.Items.Add(i.ToString())
				ZProportionCombo.Items.Add(i.ToString())
			Next i

			XProportionCombo.SelectedIndex = 0
			YProportionCombo.SelectedIndex = 0
			ZProportionCombo.SelectedIndex = 0

			FitAxisContentCheckBox.Checked = True
			ShowContentAreaCheckBox.Checked = False
		End Sub

		Private Sub UpdateProportions()
			Dim chart As NChart = nChartControl1.Charts(0)

			chart.Width = (XProportionCombo.SelectedIndex + 1)
			chart.Height = (YProportionCombo.SelectedIndex + 1)
			chart.Depth = (ZProportionCombo.SelectedIndex + 1)

			Dim max As Single = Math.Max(Math.Max(chart.Width, chart.Height), chart.Depth)

'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As Single = 50 / max

			chart.Width *= scale_Renamed
			chart.Height *= scale_Renamed
			chart.Depth *= scale_Renamed

			nChartControl1.Refresh()
		End Sub

		Private Sub XProportionCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles XProportionCombo.SelectedIndexChanged
			UpdateProportions()
		End Sub

		Private Sub YProportionCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles YProportionCombo.SelectedIndexChanged
			UpdateProportions()
		End Sub

		Private Sub ZProportionCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ZProportionCombo.SelectedIndexChanged
			UpdateProportions()
		End Sub

		Private Sub Fit3DAxisContentCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FitAxisContentCheckBox.CheckedChanged
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.Fit3DAxisContent = FitAxisContentCheckBox.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub ShowContentAreaCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowContentAreaCheckBox.CheckedChanged
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)

			If ShowContentAreaCheckBox.Checked Then
				chart.BorderStyle = New NStrokeBorderStyle()
			Else
				chart.BorderStyle = Nothing
			End If

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
