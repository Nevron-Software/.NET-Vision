Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NStackedAreaUC
		Inherits NExampleBaseUC

		Private Const categoriesCount As Integer = 10
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private WithEvents StackModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents FirstAreaDataLabelsCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents ThirdAreaDataLabelsCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents SecondAreaDataLabelsCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents ShowDataLabelsCheck As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.StackModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.ThirdAreaDataLabelsCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.SecondAreaDataLabelsCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.FirstAreaDataLabelsCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.ShowDataLabelsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' StackModeCombo
			' 
			Me.StackModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.StackModeCombo.ListProperties.DataSource = Nothing
			Me.StackModeCombo.ListProperties.DisplayMember = ""
			Me.StackModeCombo.Location = New System.Drawing.Point(9, 27)
			Me.StackModeCombo.Name = "StackModeCombo"
			Me.StackModeCombo.Size = New System.Drawing.Size(159, 21)
			Me.StackModeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StackModeCombo.SelectedIndexChanged += new System.EventHandler(this.StackModeCombo_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(9, 11)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(159, 21)
			Me.label4.TabIndex = 0
			Me.label4.Text = "Stack Mode:"
			' 
			' ThirdAreaDataLabelsCombo
			' 
			Me.ThirdAreaDataLabelsCombo.ListProperties.CheckBoxDataMember = ""
			Me.ThirdAreaDataLabelsCombo.ListProperties.DataSource = Nothing
			Me.ThirdAreaDataLabelsCombo.ListProperties.DisplayMember = ""
			Me.ThirdAreaDataLabelsCombo.Location = New System.Drawing.Point(9, 228)
			Me.ThirdAreaDataLabelsCombo.Name = "ThirdAreaDataLabelsCombo"
			Me.ThirdAreaDataLabelsCombo.Size = New System.Drawing.Size(159, 21)
			Me.ThirdAreaDataLabelsCombo.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ThirdAreaDataLabelsCombo.SelectedIndexChanged += new System.EventHandler(this.ThirdAreaDataLabelsCombo_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(9, 212)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(159, 21)
			Me.label3.TabIndex = 7
			Me.label3.Text = "Third Area Data Labels:"
			' 
			' SecondAreaDataLabelsCombo
			' 
			Me.SecondAreaDataLabelsCombo.ListProperties.CheckBoxDataMember = ""
			Me.SecondAreaDataLabelsCombo.ListProperties.DataSource = Nothing
			Me.SecondAreaDataLabelsCombo.ListProperties.DisplayMember = ""
			Me.SecondAreaDataLabelsCombo.Location = New System.Drawing.Point(9, 180)
			Me.SecondAreaDataLabelsCombo.Name = "SecondAreaDataLabelsCombo"
			Me.SecondAreaDataLabelsCombo.Size = New System.Drawing.Size(159, 21)
			Me.SecondAreaDataLabelsCombo.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SecondAreaDataLabelsCombo.SelectedIndexChanged += new System.EventHandler(this.SecondAreaDataLabelsCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 164)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(159, 21)
			Me.label2.TabIndex = 5
			Me.label2.Text = "Second Area Data Labels:"
			' 
			' FirstAreaDataLabelsCombo
			' 
			Me.FirstAreaDataLabelsCombo.ListProperties.CheckBoxDataMember = ""
			Me.FirstAreaDataLabelsCombo.ListProperties.DataSource = Nothing
			Me.FirstAreaDataLabelsCombo.ListProperties.DisplayMember = ""
			Me.FirstAreaDataLabelsCombo.Location = New System.Drawing.Point(9, 132)
			Me.FirstAreaDataLabelsCombo.Name = "FirstAreaDataLabelsCombo"
			Me.FirstAreaDataLabelsCombo.Size = New System.Drawing.Size(159, 21)
			Me.FirstAreaDataLabelsCombo.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FirstAreaDataLabelsCombo.SelectedIndexChanged += new System.EventHandler(this.FirstAreaDataLabelsCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(9, 116)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(159, 21)
			Me.label1.TabIndex = 3
			Me.label1.Text = "First Area Data Labels:"
			' 
			' ShowDataLabelsCheck
			' 
			Me.ShowDataLabelsCheck.ButtonProperties.BorderOffset = 2
			Me.ShowDataLabelsCheck.Location = New System.Drawing.Point(9, 79)
			Me.ShowDataLabelsCheck.Name = "ShowDataLabelsCheck"
			Me.ShowDataLabelsCheck.Size = New System.Drawing.Size(159, 21)
			Me.ShowDataLabelsCheck.TabIndex = 2
			Me.ShowDataLabelsCheck.Text = "Show Data Labels"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowDataLabelsCheck.CheckedChanged += new System.EventHandler(this.ShowDataLabelsCheck_CheckedChanged);
			' 
			' NStackedAreaUC
			' 
			Me.Controls.Add(Me.ShowDataLabelsCheck)
			Me.Controls.Add(Me.StackModeCombo)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.ThirdAreaDataLabelsCombo)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.SecondAreaDataLabelsCombo)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.FirstAreaDataLabelsCombo)
			Me.Controls.Add(Me.label1)
			Me.Name = "NStackedAreaUC"
			Me.Size = New System.Drawing.Size(180, 334)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Stacked Area Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' setup the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 65
			chart.Height = 40
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective2)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' setup X axis
			Dim scaleX As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.AutoLabels = False
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleX.DisplayDataPointsBetweenTicks = False
			For i As Integer = 0 To categoriesCount - 1
				scaleX.CustomLabels.Add(New NCustomValueLabel(i, (2000 + i).ToString()))
			Next i

			' add interlaced stripe for Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }

			Dim scaleY As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.StripStyles.Add(stripStyle)

			' hide Z axis
			chart.Axis(StandardAxis.Depth).Visible = False

			' add the first area
			Dim area0 As NAreaSeries = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			area0.MultiAreaMode = MultiAreaMode.Series
			area0.Name = "Product A"
			SetupDataLabels(area0)

			' add the second Area
			Dim area1 As NAreaSeries = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			area1.MultiAreaMode = MultiAreaMode.Stacked
			area1.Name = "Product B"
			SetupDataLabels(area1)

			' add the third Area
			Dim area2 As NAreaSeries = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			area2.MultiAreaMode = MultiAreaMode.Stacked
			area2.Name = "Product C"
			SetupDataLabels(area2)

			' fill with random data
			area0.Values.FillRandomRange(Random, categoriesCount, 20, 50)
			area1.Values.FillRandomRange(Random, categoriesCount, 20, 50)
			area2.Values.FillRandomRange(Random, categoriesCount, 20, 50)

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			InitLabelsCombo(FirstAreaDataLabelsCombo)
			InitLabelsCombo(SecondAreaDataLabelsCombo)
			InitLabelsCombo(ThirdAreaDataLabelsCombo)

			StackModeCombo.Items.Add("Stack")
			StackModeCombo.Items.Add("Stack 100%")
			StackModeCombo.SelectedIndex = 0

			ShowDataLabelsCheck_CheckedChanged(Nothing, Nothing)
		End Sub

		Private Sub SetupDataLabels(ByVal area As NAreaSeries)
			Dim dataLabel As NDataLabelStyle = area.DataLabelStyle
			dataLabel.ArrowLength = New NLength(0)
			dataLabel.VertAlign = VertAlign.Center
			dataLabel.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse
			dataLabel.TextStyle.BackplaneStyle.Inflate = New NSizeL(5, 5)
			dataLabel.TextStyle.FontStyle = New NFontStyle("Arial", New NLength(8, NGraphicsUnit.Point), FontStyle.Bold)
		End Sub
		Private Function GetFormatStringFromIndex(ByVal index As Integer) As String
			Select Case index
				Case 0
					Return "<value>"

				Case 1
					Return "<total>"

				Case 2
					Return "<cumulative>"

				Case 3
					Return "<percent>"

				Case Else
					Return ""
			End Select
		End Function
		Private Sub InitLabelsCombo(ByVal comboBox As Nevron.UI.WinForm.Controls.NComboBox)
			comboBox.Items.Add("Value")
			comboBox.Items.Add("Total")
			comboBox.Items.Add("Cumulative")
			comboBox.Items.Add("Percent")
			comboBox.SelectedIndex = 0
		End Sub

		Private Sub StackModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StackModeCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim area1 As NAreaSeries = CType(chart.Series(1), NAreaSeries)
			Dim area2 As NAreaSeries = CType(chart.Series(2), NAreaSeries)
			Dim scale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			Select Case StackModeCombo.SelectedIndex
				Case 0
					area1.MultiAreaMode = MultiAreaMode.Stacked
					area2.MultiAreaMode = MultiAreaMode.Stacked
					scale.LabelValueFormatter = New NNumericValueFormatter(NumericValueFormat.General)

				Case 1
					area1.MultiAreaMode = MultiAreaMode.StackedPercent
					area2.MultiAreaMode = MultiAreaMode.StackedPercent
					scale.LabelValueFormatter = New NNumericValueFormatter(NumericValueFormat.Percentage)
			End Select

			nChartControl1.Refresh()
		End Sub
		Private Sub ShowDataLabelsCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowDataLabelsCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim area0 As NAreaSeries = CType(chart.Series(0), NAreaSeries)
			Dim area1 As NAreaSeries = CType(chart.Series(1), NAreaSeries)
			Dim area2 As NAreaSeries = CType(chart.Series(2), NAreaSeries)

			area0.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked
			area1.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked
			area2.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked

			FirstAreaDataLabelsCombo.Enabled = ShowDataLabelsCheck.Checked
			SecondAreaDataLabelsCombo.Enabled = ShowDataLabelsCheck.Checked
			ThirdAreaDataLabelsCombo.Enabled = ShowDataLabelsCheck.Checked

			nChartControl1.Refresh()
		End Sub
		Private Sub FirstAreaDataLabelsCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FirstAreaDataLabelsCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim area0 As NAreaSeries = CType(chart.Series(0), NAreaSeries)

			area0.DataLabelStyle.Format = GetFormatStringFromIndex(FirstAreaDataLabelsCombo.SelectedIndex)

			nChartControl1.Refresh()
		End Sub
		Private Sub SecondAreaDataLabelsCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SecondAreaDataLabelsCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim area1 As NAreaSeries = CType(chart.Series(1), NAreaSeries)

			area1.DataLabelStyle.Format = GetFormatStringFromIndex(SecondAreaDataLabelsCombo.SelectedIndex)

			nChartControl1.Refresh()
		End Sub
		Private Sub ThirdAreaDataLabelsCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ThirdAreaDataLabelsCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim area2 As NAreaSeries = CType(chart.Series(2), NAreaSeries)

			area2.DataLabelStyle.Format = GetFormatStringFromIndex(ThirdAreaDataLabelsCombo.SelectedIndex)

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
