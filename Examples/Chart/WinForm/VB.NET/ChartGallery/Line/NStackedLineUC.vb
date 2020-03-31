Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NStackedLineUC
		Inherits NExampleBaseUC

		Private Const categoriesCount As Integer = 12
		Private m_Chart As NChart
		Private m_Line1 As NLineSeries
		Private m_Line2 As NLineSeries
		Private m_Line3 As NLineSeries
		Private WithEvents StackModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private WithEvents ThirdLineDataLabelsCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents SecondLineDataLabelsCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents FirstLineDataLabelsCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents PositiveOnlyButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PositiveAndNegativeValuesButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LineShapeCombo As Nevron.UI.WinForm.Controls.NComboBox
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
			Me.ThirdLineDataLabelsCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.SecondLineDataLabelsCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.FirstLineDataLabelsCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.PositiveOnlyButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.PositiveAndNegativeValuesButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label5 = New System.Windows.Forms.Label()
			Me.LineShapeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.ShowDataLabelsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' StackModeCombo
			' 
			Me.StackModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.StackModeCombo.ListProperties.DataSource = Nothing
			Me.StackModeCombo.ListProperties.DisplayMember = ""
			Me.StackModeCombo.Location = New System.Drawing.Point(4, 20)
			Me.StackModeCombo.Name = "StackModeCombo"
			Me.StackModeCombo.Size = New System.Drawing.Size(170, 21)
			Me.StackModeCombo.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StackModeCombo.SelectedIndexChanged += new System.EventHandler(this.StackModeCombo_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(4, 4)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(170, 16)
			Me.label4.TabIndex = 6
			Me.label4.Text = "Stack Mode:"
			' 
			' ThirdLineDataLabelsCombo
			' 
			Me.ThirdLineDataLabelsCombo.ListProperties.CheckBoxDataMember = ""
			Me.ThirdLineDataLabelsCombo.ListProperties.DataSource = Nothing
			Me.ThirdLineDataLabelsCombo.ListProperties.DisplayMember = ""
			Me.ThirdLineDataLabelsCombo.Location = New System.Drawing.Point(4, 356)
			Me.ThirdLineDataLabelsCombo.Name = "ThirdLineDataLabelsCombo"
			Me.ThirdLineDataLabelsCombo.Size = New System.Drawing.Size(170, 21)
			Me.ThirdLineDataLabelsCombo.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ThirdLineDataLabelsCombo.SelectedIndexChanged += new System.EventHandler(this.ThirdLineDataLabelsCombo_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(4, 340)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(170, 16)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Third Line Data Labels:"
			' 
			' SecondLineDataLabelsCombo
			' 
			Me.SecondLineDataLabelsCombo.ListProperties.CheckBoxDataMember = ""
			Me.SecondLineDataLabelsCombo.ListProperties.DataSource = Nothing
			Me.SecondLineDataLabelsCombo.ListProperties.DisplayMember = ""
			Me.SecondLineDataLabelsCombo.Location = New System.Drawing.Point(4, 308)
			Me.SecondLineDataLabelsCombo.Name = "SecondLineDataLabelsCombo"
			Me.SecondLineDataLabelsCombo.Size = New System.Drawing.Size(170, 21)
			Me.SecondLineDataLabelsCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SecondLineDataLabelsCombo.SelectedIndexChanged += new System.EventHandler(this.SecondLineDataLabelsCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(4, 292)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(170, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Second Line Data Labels:"
			' 
			' FirstLineDataLabelsCombo
			' 
			Me.FirstLineDataLabelsCombo.ListProperties.CheckBoxDataMember = ""
			Me.FirstLineDataLabelsCombo.ListProperties.DataSource = Nothing
			Me.FirstLineDataLabelsCombo.ListProperties.DisplayMember = ""
			Me.FirstLineDataLabelsCombo.Location = New System.Drawing.Point(4, 260)
			Me.FirstLineDataLabelsCombo.Name = "FirstLineDataLabelsCombo"
			Me.FirstLineDataLabelsCombo.Size = New System.Drawing.Size(170, 21)
			Me.FirstLineDataLabelsCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FirstLineDataLabelsCombo.SelectedIndexChanged += new System.EventHandler(this.FirstLineDataLabelsCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(4, 244)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(170, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "First Line Data Labels:"
			' 
			' PositiveOnlyButton
			' 
			Me.PositiveOnlyButton.Location = New System.Drawing.Point(4, 115)
			Me.PositiveOnlyButton.Name = "PositiveOnlyButton"
			Me.PositiveOnlyButton.Size = New System.Drawing.Size(170, 23)
			Me.PositiveOnlyButton.TabIndex = 8
			Me.PositiveOnlyButton.Text = "Positive Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositiveOnlyButton.Click += new System.EventHandler(this.PositiveDataButton_Click);
			' 
			' PositiveAndNegativeValuesButton
			' 
			Me.PositiveAndNegativeValuesButton.Location = New System.Drawing.Point(4, 150)
			Me.PositiveAndNegativeValuesButton.Name = "PositiveAndNegativeValuesButton"
			Me.PositiveAndNegativeValuesButton.Size = New System.Drawing.Size(170, 23)
			Me.PositiveAndNegativeValuesButton.TabIndex = 9
			Me.PositiveAndNegativeValuesButton.Text = "Positive And Negative Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositiveAndNegativeValuesButton.Click += new System.EventHandler(this.PositiveAndNegativeValuesButton_Click);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(4, 52)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(170, 16)
			Me.label5.TabIndex = 11
			Me.label5.Text = "Line Shape:"
			' 
			' LineShapeCombo
			' 
			Me.LineShapeCombo.ListProperties.CheckBoxDataMember = ""
			Me.LineShapeCombo.ListProperties.DataSource = Nothing
			Me.LineShapeCombo.ListProperties.DisplayMember = ""
			Me.LineShapeCombo.Location = New System.Drawing.Point(4, 68)
			Me.LineShapeCombo.Name = "LineShapeCombo"
			Me.LineShapeCombo.Size = New System.Drawing.Size(170, 21)
			Me.LineShapeCombo.TabIndex = 10
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineShapeCombo.SelectedIndexChanged += new System.EventHandler(this.LineShapeCombo_SelectedIndexChanged);
			' 
			' ShowDataLabelsCheck
			' 
			Me.ShowDataLabelsCheck.ButtonProperties.BorderOffset = 2
			Me.ShowDataLabelsCheck.Location = New System.Drawing.Point(4, 212)
			Me.ShowDataLabelsCheck.Name = "ShowDataLabelsCheck"
			Me.ShowDataLabelsCheck.Size = New System.Drawing.Size(170, 21)
			Me.ShowDataLabelsCheck.TabIndex = 25
			Me.ShowDataLabelsCheck.Text = "Show Data Labels"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowDataLabelsCheck.CheckedChanged += new System.EventHandler(this.ShowDataLabelsCheck_CheckedChanged);
			' 
			' NStackedLineUC
			' 
			Me.Controls.Add(Me.ShowDataLabelsCheck)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.LineShapeCombo)
			Me.Controls.Add(Me.PositiveAndNegativeValuesButton)
			Me.Controls.Add(Me.PositiveOnlyButton)
			Me.Controls.Add(Me.StackModeCombo)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.ThirdLineDataLabelsCombo)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.SecondLineDataLabelsCombo)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.FirstLineDataLabelsCombo)
			Me.Controls.Add(Me.label1)
			Me.Name = "NStackedLineUC"
			Me.Size = New System.Drawing.Size(180, 410)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Stacked Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' add interlaced stripe to the Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator).StripStyles.Add(stripStyle)

			' add the first line
			m_Line1 = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line1.Name = "Line 1"
			m_Line1.MultiLineMode = MultiLineMode.Series
			m_Line1.DataLabelStyle.ArrowLength = New NLength(0, NRelativeUnit.ParentPercentage)
			m_Line1.DataLabelStyle.ArrowStrokeStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			m_Line1.DataLabelStyle.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse
			m_Line1.DataLabelStyle.TextStyle.BackplaneStyle.Inflate = New NSizeL(6, 6)
			m_Line1.DataLabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)

			' add the second line
			m_Line2 = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line2.Name = "Line 2"
			m_Line2.MultiLineMode = MultiLineMode.Stacked
			m_Line2.DataLabelStyle.ArrowLength = New NLength(0)
			m_Line2.DataLabelStyle.ArrowStrokeStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			m_Line2.DataLabelStyle.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse
			m_Line2.DataLabelStyle.TextStyle.BackplaneStyle.Inflate = New NSizeL(6, 6)
			m_Line2.DataLabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)

			' add the third line
			m_Line3 = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line3.Name = "Line 3"
			m_Line3.MultiLineMode = MultiLineMode.Stacked
			m_Line3.DataLabelStyle.ArrowLength = New NLength(0)
			m_Line3.DataLabelStyle.ArrowStrokeStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			m_Line3.DataLabelStyle.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse
			m_Line3.DataLabelStyle.TextStyle.BackplaneStyle.Inflate = New NSizeL(6, 6)
			m_Line3.DataLabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Nature)
			styleSheet.Apply(nChartControl1.Document)

			' fill the data labels combos
			InitLabelsCombo(FirstLineDataLabelsCombo)
			InitLabelsCombo(SecondLineDataLabelsCombo)
			InitLabelsCombo(ThirdLineDataLabelsCombo)

			StackModeCombo.Items.Add("Stacked")
			StackModeCombo.Items.Add("Stacked %")
			StackModeCombo.SelectedIndex = 0

			LineShapeCombo.FillFromEnum(GetType(LineSegmentShape))
			LineShapeCombo.SelectedIndex = CInt(LineSegmentShape.Tape)

			PositiveDataButton_Click(Nothing, Nothing)
			ShowDataLabelsCheck_CheckedChanged(Nothing, Nothing)
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
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)

			Select Case StackModeCombo.SelectedIndex
				Case 0
					m_Line2.MultiLineMode = MultiLineMode.Stacked
					m_Line3.MultiLineMode = MultiLineMode.Stacked
					scale_Renamed.LabelValueFormatter = New NNumericValueFormatter(NumericValueFormat.General)

				Case 1
					m_Line2.MultiLineMode = MultiLineMode.StackedPercent
					m_Line3.MultiLineMode = MultiLineMode.StackedPercent
					scale_Renamed.LabelValueFormatter = New NNumericValueFormatter(NumericValueFormat.Percentage)
			End Select

			nChartControl1.Refresh()
		End Sub
		Private Sub LineShapeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LineShapeCombo.SelectedIndexChanged
			Dim style As LineSegmentShape = CType(LineShapeCombo.SelectedIndex, LineSegmentShape)

			m_Line1.LineSegmentShape = style
			m_Line2.LineSegmentShape = style
			m_Line3.LineSegmentShape = style

			Select Case style
				Case LineSegmentShape.Tape
					m_Line1.DepthPercent = 50
					m_Line2.DepthPercent = 50
					m_Line3.DepthPercent = 50

				Case LineSegmentShape.Tube, LineSegmentShape.Ellipsoid
					m_Line1.DepthPercent = 10
					m_Line2.DepthPercent = 10
					m_Line3.DepthPercent = 10
			End Select

			nChartControl1.Refresh()
		End Sub
		Private Sub PositiveDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PositiveOnlyButton.Click
			m_Line1.Values.FillRandomRange(Random, categoriesCount, 10, 100)
			m_Line2.Values.FillRandomRange(Random, categoriesCount, 10, 100)
			m_Line3.Values.FillRandomRange(Random, categoriesCount, 10, 100)

			nChartControl1.Refresh()
		End Sub
		Private Sub PositiveAndNegativeValuesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PositiveAndNegativeValuesButton.Click
			m_Line1.Values.FillRandomRange(Random, categoriesCount, -50, 50)
			m_Line2.Values.FillRandomRange(Random, categoriesCount, -50, 50)
			m_Line3.Values.FillRandomRange(Random, categoriesCount, -50, 50)

			nChartControl1.Refresh()
		End Sub
		Private Sub ShowDataLabelsCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowDataLabelsCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim line0 As NLineSeries = CType(chart.Series(0), NLineSeries)
			Dim line1 As NLineSeries = CType(chart.Series(1), NLineSeries)
			Dim line2 As NLineSeries = CType(chart.Series(2), NLineSeries)

			line0.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked
			line1.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked
			line2.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked

			FirstLineDataLabelsCombo.Enabled = ShowDataLabelsCheck.Checked
			SecondLineDataLabelsCombo.Enabled = ShowDataLabelsCheck.Checked
			ThirdLineDataLabelsCombo.Enabled = ShowDataLabelsCheck.Checked

			nChartControl1.Refresh()
		End Sub
		Private Sub FirstLineDataLabelsCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FirstLineDataLabelsCombo.SelectedIndexChanged
			m_Line1.DataLabelStyle.Format = GetFormatStringFromIndex(FirstLineDataLabelsCombo.SelectedIndex)
			nChartControl1.Refresh()
		End Sub
		Private Sub SecondLineDataLabelsCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SecondLineDataLabelsCombo.SelectedIndexChanged
			m_Line2.DataLabelStyle.Format = GetFormatStringFromIndex(SecondLineDataLabelsCombo.SelectedIndex)
			nChartControl1.Refresh()
		End Sub
		Private Sub ThirdLineDataLabelsCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ThirdLineDataLabelsCombo.SelectedIndexChanged
			m_Line3.DataLabelStyle.Format = GetFormatStringFromIndex(ThirdLineDataLabelsCombo.SelectedIndex)
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
