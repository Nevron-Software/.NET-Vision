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
	Public Class NAutoLabelsStepLineUC
		Inherits NExampleBaseUC

		Private WithEvents EnableLabelAdjustmentCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents GenerateDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents EnableInitialPositioningCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private label6 As Label
		Private WithEvents LocationsCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents InvertForDownwardDPCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents InvertIfOutOfBoundsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			LocationsCombo.Items.Add("Top")
			LocationsCombo.Items.Add("Top - Bottom")
			LocationsCombo.Items.Add("Top - Bottom - Left - Right")
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
			Me.EnableLabelAdjustmentCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.GenerateDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.EnableInitialPositioningCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.LocationsCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.InvertForDownwardDPCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.InvertIfOutOfBoundsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' EnableLabelAdjustmentCheck
			' 
			Me.EnableLabelAdjustmentCheck.ButtonProperties.BorderOffset = 2
			Me.EnableLabelAdjustmentCheck.Location = New System.Drawing.Point(7, 78)
			Me.EnableLabelAdjustmentCheck.Name = "EnableLabelAdjustmentCheck"
			Me.EnableLabelAdjustmentCheck.Size = New System.Drawing.Size(159, 21)
			Me.EnableLabelAdjustmentCheck.TabIndex = 6
			Me.EnableLabelAdjustmentCheck.Text = "Enable Label Adjustment"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableLabelAdjustmentCheck.CheckedChanged += new System.EventHandler(this.EnableLabelAdjustmentCheck_CheckedChanged);
			' 
			' GenerateDataButton
			' 
			Me.GenerateDataButton.Location = New System.Drawing.Point(4, 9)
			Me.GenerateDataButton.Name = "GenerateDataButton"
			Me.GenerateDataButton.Size = New System.Drawing.Size(172, 24)
			Me.GenerateDataButton.TabIndex = 4
			Me.GenerateDataButton.Text = "Generate Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			' 
			' EnableInitialPositioningCheck
			' 
			Me.EnableInitialPositioningCheck.ButtonProperties.BorderOffset = 2
			Me.EnableInitialPositioningCheck.Location = New System.Drawing.Point(7, 46)
			Me.EnableInitialPositioningCheck.Name = "EnableInitialPositioningCheck"
			Me.EnableInitialPositioningCheck.Size = New System.Drawing.Size(159, 21)
			Me.EnableInitialPositioningCheck.TabIndex = 8
			Me.EnableInitialPositioningCheck.Text = "Enable Initial Positioning"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableInitialPositioningCheck.CheckedChanged += new System.EventHandler(this.EnableInitialPositioningCheck_CheckedChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(4, 135)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(138, 15)
			Me.label6.TabIndex = 48
			Me.label6.Text = "Proposals for Label Location:"
			' 
			' LocationsCombo
			' 
			Me.LocationsCombo.ListProperties.CheckBoxDataMember = ""
			Me.LocationsCombo.ListProperties.DataSource = Nothing
			Me.LocationsCombo.ListProperties.DisplayMember = ""
			Me.LocationsCombo.Location = New System.Drawing.Point(4, 153)
			Me.LocationsCombo.Name = "LocationsCombo"
			Me.LocationsCombo.Size = New System.Drawing.Size(172, 21)
			Me.LocationsCombo.TabIndex = 47
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LocationsCombo.SelectedIndexChanged += new System.EventHandler(this.LocationsCombo_SelectedIndexChanged);
			' 
			' InvertForDownwardDPCheck
			' 
			Me.InvertForDownwardDPCheck.ButtonProperties.BorderOffset = 2
			Me.InvertForDownwardDPCheck.ButtonProperties.WrapText = True
			Me.InvertForDownwardDPCheck.Location = New System.Drawing.Point(4, 189)
			Me.InvertForDownwardDPCheck.Name = "InvertForDownwardDPCheck"
			Me.InvertForDownwardDPCheck.Size = New System.Drawing.Size(172, 34)
			Me.InvertForDownwardDPCheck.TabIndex = 49
			Me.InvertForDownwardDPCheck.Text = "Invert Locations for Downward Data Points"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InvertForDownwardDPCheck.CheckedChanged += new System.EventHandler(this.InvertForDownwardDPCheck_CheckedChanged);
			' 
			' InvertIfOutOfBoundsCheck
			' 
			Me.InvertIfOutOfBoundsCheck.ButtonProperties.BorderOffset = 2
			Me.InvertIfOutOfBoundsCheck.ButtonProperties.WrapText = True
			Me.InvertIfOutOfBoundsCheck.Location = New System.Drawing.Point(4, 233)
			Me.InvertIfOutOfBoundsCheck.Name = "InvertIfOutOfBoundsCheck"
			Me.InvertIfOutOfBoundsCheck.Size = New System.Drawing.Size(172, 35)
			Me.InvertIfOutOfBoundsCheck.TabIndex = 50
			Me.InvertIfOutOfBoundsCheck.Text = "Invert Locations If All Are Out of Bounds"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InvertIfOutOfBoundsCheck.CheckedChanged += new System.EventHandler(this.InvertIfOutOfBoundsCheck_CheckedChanged);
			' 
			' NAutoLabelsStepLineUC
			' 
			Me.Controls.Add(Me.InvertIfOutOfBoundsCheck)
			Me.Controls.Add(Me.InvertForDownwardDPCheck)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.LocationsCombo)
			Me.Controls.Add(Me.EnableInitialPositioningCheck)
			Me.Controls.Add(Me.EnableLabelAdjustmentCheck)
			Me.Controls.Add(Me.GenerateDataButton)
			Me.Name = "NAutoLabelsStepLineUC"
			Me.Size = New System.Drawing.Size(180, 292)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Step Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)

			' configure Y axis
			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' add interlaced stripe for Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.StripStyles.Add(stripStyle)

			' step line series
			Dim series1 As NStepLineSeries = CType(chart.Series.Add(SeriesType.StepLine), NStepLineSeries)
			series1.InflateMargins = True
			series1.BorderStyle = New NStrokeStyle(New NLength(1.2F, NGraphicsUnit.Point), GreyBlue)

			series1.DataLabelStyle.Visible = True
			series1.DataLabelStyle.VertAlign = VertAlign.Top
			series1.DataLabelStyle.ArrowLength = New NLength(12)
			series1.DataLabelStyle.ArrowStrokeStyle.Color = DarkOrange
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange

			' label layout settings
			chart.LabelLayout.EnableInitialPositioning = True
			chart.LabelLayout.EnableLabelAdjustment = True

			series1.LabelLayout.UseLabelLocations = True
			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds
			series1.LabelLayout.EnableDataPointSafeguard = True
			series1.LabelLayout.DataPointSafeguardSize = New NSizeL(New NLength(1.3F, NRelativeUnit.ParentPercentage), New NLength(1.3F, NRelativeUnit.ParentPercentage))

			' fill with random data 
			GenerateData(series1)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' init form controls
			EnableInitialPositioningCheck.Checked = True
			EnableLabelAdjustmentCheck.Checked = True
			LocationsCombo.SelectedIndex = 1
			InvertForDownwardDPCheck.Checked = True
			InvertIfOutOfBoundsCheck.Checked = True
		End Sub

		Private Sub GenerateData(ByVal series As NSeries)
			series.Values.Clear()

			For i As Integer = 0 To 29
				Dim value As Double = Math.Sin(i * 0.2) * 10 + Random.NextDouble() * 2
				series.Values.Add(value)
			Next i
		End Sub

		Private Sub GenerateDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GenerateDataButton.Click
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim series As NSeries = CType(chart.Series(0), NSeries)

			GenerateData(series)

			nChartControl1.Refresh()
		End Sub


		Private Sub EnableInitialPositioningCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EnableInitialPositioningCheck.CheckedChanged
			Dim enableInitialPositioningSettings As Boolean = EnableInitialPositioningCheck.Checked
			LocationsCombo.Enabled = enableInitialPositioningSettings
			InvertForDownwardDPCheck.Enabled = enableInitialPositioningSettings
			InvertIfOutOfBoundsCheck.Enabled = enableInitialPositioningSettings

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheck.Checked

			nChartControl1.Refresh()
		End Sub
		Private Sub EnableLabelAdjustmentCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EnableLabelAdjustmentCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheck.Checked

			nChartControl1.Refresh()
		End Sub
		Private Sub LocationsCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LocationsCombo.SelectedIndexChanged
			Dim locations() As LabelLocation = Nothing

			Select Case LocationsCombo.SelectedIndex
				Case 0
					locations = New LabelLocation() { LabelLocation.Top }

				Case 1
					locations = New LabelLocation() { LabelLocation.Top, LabelLocation.Bottom }

				Case 2
					locations = New LabelLocation() { LabelLocation.Top, LabelLocation.Bottom, LabelLocation.Left, LabelLocation.Right }
			End Select

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Series(0).LabelLayout.LabelLocations = locations

			nChartControl1.Refresh()
		End Sub

		Private Sub InvertForDownwardDPCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InvertForDownwardDPCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Series(0).LabelLayout.InvertLocationsForInvertedDataPoints = InvertForDownwardDPCheck.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub InvertIfOutOfBoundsCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InvertIfOutOfBoundsCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Series(0).LabelLayout.InvertLocationsIfIgnored = InvertIfOutOfBoundsCheck.Checked

			nChartControl1.Refresh()
		End Sub

	End Class
End Namespace