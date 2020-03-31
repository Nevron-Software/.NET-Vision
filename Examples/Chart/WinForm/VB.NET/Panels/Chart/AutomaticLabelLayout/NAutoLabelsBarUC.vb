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
	Public Class NAutoLabelsBarUC
		Inherits NExampleBaseUC

		Private WithEvents GenerateDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents EnableInitialPositioningCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents EnableLabelAdjustmentCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents RemoveOverlappedLabelsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private label6 As Label
		Private WithEvents LocationsCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			LocationsCombo.Items.Add("Top")
			LocationsCombo.Items.Add("Top - Bottom")
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
			Me.GenerateDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.EnableInitialPositioningCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.EnableLabelAdjustmentCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.RemoveOverlappedLabelsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.LocationsCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' GenerateDataButton
			' 
			Me.GenerateDataButton.Location = New System.Drawing.Point(5, 9)
			Me.GenerateDataButton.Name = "GenerateDataButton"
			Me.GenerateDataButton.Size = New System.Drawing.Size(171, 24)
			Me.GenerateDataButton.TabIndex = 4
			Me.GenerateDataButton.Text = "Generate Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			' 
			' EnableInitialPositioningCheck
			' 
			Me.EnableInitialPositioningCheck.ButtonProperties.BorderOffset = 2
			Me.EnableInitialPositioningCheck.Location = New System.Drawing.Point(5, 47)
			Me.EnableInitialPositioningCheck.Name = "EnableInitialPositioningCheck"
			Me.EnableInitialPositioningCheck.Size = New System.Drawing.Size(170, 21)
			Me.EnableInitialPositioningCheck.TabIndex = 10
			Me.EnableInitialPositioningCheck.Text = "Enable Initial Positioning"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableInitialPositioningCheck.CheckedChanged += new System.EventHandler(this.EnableInitialPositioningCheck_CheckedChanged);
			' 
			' EnableLabelAdjustmentCheck
			' 
			Me.EnableLabelAdjustmentCheck.ButtonProperties.BorderOffset = 2
			Me.EnableLabelAdjustmentCheck.Location = New System.Drawing.Point(5, 118)
			Me.EnableLabelAdjustmentCheck.Name = "EnableLabelAdjustmentCheck"
			Me.EnableLabelAdjustmentCheck.Size = New System.Drawing.Size(170, 21)
			Me.EnableLabelAdjustmentCheck.TabIndex = 9
			Me.EnableLabelAdjustmentCheck.Text = "Enable Label Adjustment"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableLabelAdjustmentCheck.CheckedChanged += new System.EventHandler(this.EnableLabelAdjustmentCheck_CheckedChanged);
			' 
			' RemoveOverlappedLabelsCheck
			' 
			Me.RemoveOverlappedLabelsCheck.ButtonProperties.BorderOffset = 2
			Me.RemoveOverlappedLabelsCheck.ButtonProperties.WrapText = True
			Me.RemoveOverlappedLabelsCheck.Location = New System.Drawing.Point(5, 74)
			Me.RemoveOverlappedLabelsCheck.Name = "RemoveOverlappedLabelsCheck"
			Me.RemoveOverlappedLabelsCheck.Size = New System.Drawing.Size(170, 38)
			Me.RemoveOverlappedLabelsCheck.TabIndex = 11
			Me.RemoveOverlappedLabelsCheck.Text = "Remove Overlapped Labels After Initial Positioning"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RemoveOverlappedLabelsCheck.CheckedChanged += new System.EventHandler(this.RemoveOverlappedLabelsCheck_CheckedChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(3, 153)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(153, 15)
			Me.label6.TabIndex = 50
			Me.label6.Text = "Proposals for Label Location:"
			' 
			' LocationsCombo
			' 
			Me.LocationsCombo.ListProperties.CheckBoxDataMember = ""
			Me.LocationsCombo.ListProperties.DataSource = Nothing
			Me.LocationsCombo.ListProperties.DisplayMember = ""
			Me.LocationsCombo.Location = New System.Drawing.Point(3, 171)
			Me.LocationsCombo.Name = "LocationsCombo"
			Me.LocationsCombo.Size = New System.Drawing.Size(174, 21)
			Me.LocationsCombo.TabIndex = 49
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LocationsCombo.SelectedIndexChanged += new System.EventHandler(this.LocationsCombo_SelectedIndexChanged);
			' 
			' NAutoLabelsBarUC
			' 
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.LocationsCombo)
			Me.Controls.Add(Me.RemoveOverlappedLabelsCheck)
			Me.Controls.Add(Me.EnableInitialPositioningCheck)
			Me.Controls.Add(Me.EnableLabelAdjustmentCheck)
			Me.Controls.Add(Me.GenerateDataButton)
			Me.Name = "NAutoLabelsBarUC"
			Me.Size = New System.Drawing.Size(180, 277)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Bar Chart")
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

			' bar series
			Dim series1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			series1.FillStyle = New NColorFillStyle(DarkOrange)
			series1.DataLabelStyle.Visible = True
			series1.DataLabelStyle.VertAlign = VertAlign.Top
			series1.DataLabelStyle.ArrowLength = New NLength(10)

			' enable initial labels positioning
			chart.LabelLayout.EnableInitialPositioning = True

			' enable label adjustment
			chart.LabelLayout.EnableLabelAdjustment = True

			' use only "top" location for the labels
			series1.LabelLayout.UseLabelLocations = True
			series1.LabelLayout.LabelLocations = New LabelLocation() { LabelLocation.Top }
			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds
			series1.LabelLayout.InvertLocationsIfIgnored = True

			' protect data points from being overlapped
			series1.LabelLayout.EnableDataPointSafeguard = True
			series1.LabelLayout.DataPointSafeguardSize = New NSizeL(New NLength(1.3F, NRelativeUnit.ParentPercentage), New NLength(1.3F, NRelativeUnit.ParentPercentage))

			' fill with random data
			GenerateData(series1)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' init form controls			
			EnableInitialPositioningCheck.Checked = True
			RemoveOverlappedLabelsCheck.Checked = False
			EnableLabelAdjustmentCheck.Checked = True
			LocationsCombo.SelectedIndex = 0
		End Sub

		Private Sub GenerateData(ByVal series As NSeries)
			series.Values.Clear()

			For i As Integer = 0 To 29
				Dim value As Double = Math.Sin(i * 0.2) * 10 + Random.NextDouble() * 4
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
			RemoveOverlappedLabelsCheck.Enabled = EnableInitialPositioningCheck.Checked
			LocationsCombo.Enabled = EnableInitialPositioningCheck.Checked

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheck.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub RemoveOverlappedLabelsCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RemoveOverlappedLabelsCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.LabelLayout.RemoveOverlappedLabels = RemoveOverlappedLabelsCheck.Checked

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
			End Select

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Series(0).LabelLayout.LabelLocations = locations

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace