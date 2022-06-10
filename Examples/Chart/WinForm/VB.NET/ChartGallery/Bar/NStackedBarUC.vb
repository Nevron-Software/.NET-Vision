Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NStackedBarUC
		Inherits NExampleBaseUC

		Private Const categoriesCount As Integer = 6
		Private m_Bar1 As NBarSeries
		Private m_Bar2 As NBarSeries
		Private m_Bar3 As NBarSeries
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private WithEvents FirstBarDataLabelsCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents SecondBarDataLabelsCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents ThirdBarDataLabelsCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents StackModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents BarShapeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents PositiveNegativeData As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PositiveData As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents FHTE As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents SHTE As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents THTE As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents FHBE As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents SHBE As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents THBE As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.FirstBarDataLabelsCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SecondBarDataLabelsCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.ThirdBarDataLabelsCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.StackModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.PositiveNegativeData = New Nevron.UI.WinForm.Controls.NButton()
			Me.PositiveData = New Nevron.UI.WinForm.Controls.NButton()
			Me.label5 = New System.Windows.Forms.Label()
			Me.BarShapeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.FHTE = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SHTE = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.THTE = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.FHBE = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SHBE = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.THBE = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowDataLabelsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 387)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(160, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "First Bar Data Labels:"
			' 
			' FirstBarDataLabelsCombo
			' 
			Me.FirstBarDataLabelsCombo.ListProperties.CheckBoxDataMember = ""
			Me.FirstBarDataLabelsCombo.ListProperties.DataSource = Nothing
			Me.FirstBarDataLabelsCombo.ListProperties.DisplayMember = ""
			Me.FirstBarDataLabelsCombo.Location = New System.Drawing.Point(8, 403)
			Me.FirstBarDataLabelsCombo.Name = "FirstBarDataLabelsCombo"
			Me.FirstBarDataLabelsCombo.Size = New System.Drawing.Size(160, 21)
			Me.FirstBarDataLabelsCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FirstBarDataLabelsCombo.SelectedIndexChanged += new System.EventHandler(this.FirstBarDataLabelsCombo_SelectedIndexChanged);
			' 
			' SecondBarDataLabelsCombo
			' 
			Me.SecondBarDataLabelsCombo.ListProperties.CheckBoxDataMember = ""
			Me.SecondBarDataLabelsCombo.ListProperties.DataSource = Nothing
			Me.SecondBarDataLabelsCombo.ListProperties.DisplayMember = ""
			Me.SecondBarDataLabelsCombo.Location = New System.Drawing.Point(8, 451)
			Me.SecondBarDataLabelsCombo.Name = "SecondBarDataLabelsCombo"
			Me.SecondBarDataLabelsCombo.Size = New System.Drawing.Size(160, 21)
			Me.SecondBarDataLabelsCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SecondBarDataLabelsCombo.SelectedIndexChanged += new System.EventHandler(this.SecondBarDataLabelsCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 435)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(160, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Second Bar Data Labels:"
			' 
			' ThirdBarDataLabelsCombo
			' 
			Me.ThirdBarDataLabelsCombo.ListProperties.CheckBoxDataMember = ""
			Me.ThirdBarDataLabelsCombo.ListProperties.DataSource = Nothing
			Me.ThirdBarDataLabelsCombo.ListProperties.DisplayMember = ""
			Me.ThirdBarDataLabelsCombo.Location = New System.Drawing.Point(8, 499)
			Me.ThirdBarDataLabelsCombo.Name = "ThirdBarDataLabelsCombo"
			Me.ThirdBarDataLabelsCombo.Size = New System.Drawing.Size(160, 21)
			Me.ThirdBarDataLabelsCombo.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ThirdBarDataLabelsCombo.SelectedIndexChanged += new System.EventHandler(this.ThirdBarDataLabelsCombo_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 483)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(160, 16)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Third Bar Data Labels:"
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 7)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(160, 16)
			Me.label4.TabIndex = 6
			Me.label4.Text = "Stack Mode:"
			' 
			' StackModeCombo
			' 
			Me.StackModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.StackModeCombo.ListProperties.DataSource = Nothing
			Me.StackModeCombo.ListProperties.DisplayMember = ""
			Me.StackModeCombo.Location = New System.Drawing.Point(8, 23)
			Me.StackModeCombo.Name = "StackModeCombo"
			Me.StackModeCombo.Size = New System.Drawing.Size(160, 21)
			Me.StackModeCombo.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StackModeCombo.SelectedIndexChanged += new System.EventHandler(this.StackModeCombo_SelectedIndexChanged);
			' 
			' PositiveNegativeData
			' 
			Me.PositiveNegativeData.Location = New System.Drawing.Point(8, 104)
			Me.PositiveNegativeData.Name = "PositiveNegativeData"
			Me.PositiveNegativeData.Size = New System.Drawing.Size(160, 32)
			Me.PositiveNegativeData.TabIndex = 9
			Me.PositiveNegativeData.Text = "Positive and Negative Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositiveNegativeData.Click += new System.EventHandler(this.PositiveNegativeDataButton_Click);
			' 
			' PositiveData
			' 
			Me.PositiveData.Location = New System.Drawing.Point(8, 66)
			Me.PositiveData.Name = "PositiveData"
			Me.PositiveData.Size = New System.Drawing.Size(160, 32)
			Me.PositiveData.TabIndex = 8
			Me.PositiveData.Text = "Positive Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositiveData.Click += new System.EventHandler(this.PositiveDataButton_Click);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 155)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(160, 16)
			Me.label5.TabIndex = 10
			Me.label5.Text = "Bar Shape:"
			' 
			' BarShapeCombo
			' 
			Me.BarShapeCombo.ListProperties.CheckBoxDataMember = ""
			Me.BarShapeCombo.ListProperties.DataSource = Nothing
			Me.BarShapeCombo.ListProperties.DisplayMember = ""
			Me.BarShapeCombo.Location = New System.Drawing.Point(8, 171)
			Me.BarShapeCombo.Name = "BarShapeCombo"
			Me.BarShapeCombo.Size = New System.Drawing.Size(160, 21)
			Me.BarShapeCombo.TabIndex = 11
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarShapeCombo.SelectedIndexChanged += new System.EventHandler(this.BarShapeCombo_SelectedIndexChanged);
			' 
			' FHTE
			' 
			Me.FHTE.ButtonProperties.BorderOffset = 2
			Me.FHTE.Location = New System.Drawing.Point(8, 205)
			Me.FHTE.Name = "FHTE"
			Me.FHTE.Size = New System.Drawing.Size(160, 22)
			Me.FHTE.TabIndex = 12
			Me.FHTE.Text = "First Has Top Edge"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FHTE.CheckedChanged += new System.EventHandler(this.FHTE_CheckedChanged);
			' 
			' SHTE
			' 
			Me.SHTE.ButtonProperties.BorderOffset = 2
			Me.SHTE.Location = New System.Drawing.Point(8, 245)
			Me.SHTE.Name = "SHTE"
			Me.SHTE.Size = New System.Drawing.Size(160, 22)
			Me.SHTE.TabIndex = 13
			Me.SHTE.Text = "Second Has Top Edge"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SHTE.CheckedChanged += new System.EventHandler(this.SHTE_CheckedChanged);
			' 
			' THTE
			' 
			Me.THTE.ButtonProperties.BorderOffset = 2
			Me.THTE.Location = New System.Drawing.Point(8, 285)
			Me.THTE.Name = "THTE"
			Me.THTE.Size = New System.Drawing.Size(160, 22)
			Me.THTE.TabIndex = 14
			Me.THTE.Text = "Third Has Top Edge"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.THTE.CheckedChanged += new System.EventHandler(this.THTE_CheckedChanged);
			' 
			' FHBE
			' 
			Me.FHBE.ButtonProperties.BorderOffset = 2
			Me.FHBE.Location = New System.Drawing.Point(8, 225)
			Me.FHBE.Name = "FHBE"
			Me.FHBE.Size = New System.Drawing.Size(160, 22)
			Me.FHBE.TabIndex = 15
			Me.FHBE.Text = "First Has Bottom Edge"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FHBE.CheckedChanged += new System.EventHandler(this.FHBE_CheckedChanged);
			' 
			' SHBE
			' 
			Me.SHBE.ButtonProperties.BorderOffset = 2
			Me.SHBE.Location = New System.Drawing.Point(8, 265)
			Me.SHBE.Name = "SHBE"
			Me.SHBE.Size = New System.Drawing.Size(160, 22)
			Me.SHBE.TabIndex = 16
			Me.SHBE.Text = "Second Has Bottom Edge"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SHBE.CheckedChanged += new System.EventHandler(this.SHBE_CheckedChanged);
			' 
			' THBE
			' 
			Me.THBE.ButtonProperties.BorderOffset = 2
			Me.THBE.Location = New System.Drawing.Point(8, 306)
			Me.THBE.Name = "THBE"
			Me.THBE.Size = New System.Drawing.Size(160, 22)
			Me.THBE.TabIndex = 17
			Me.THBE.Text = "Third Has Bottom Edge"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.THBE.CheckedChanged += new System.EventHandler(this.THBE_CheckedChanged);
			' 
			' ShowDataLabelsCheck
			' 
			Me.ShowDataLabelsCheck.ButtonProperties.BorderOffset = 2
			Me.ShowDataLabelsCheck.Location = New System.Drawing.Point(8, 355)
			Me.ShowDataLabelsCheck.Name = "ShowDataLabelsCheck"
			Me.ShowDataLabelsCheck.Size = New System.Drawing.Size(160, 21)
			Me.ShowDataLabelsCheck.TabIndex = 25
			Me.ShowDataLabelsCheck.Text = "Show Data Labels"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowDataLabelsCheck.CheckedChanged += new System.EventHandler(this.ShowDataLabelsCheck_CheckedChanged);
			' 
			' NStackedBarUC
			' 
			Me.Controls.Add(Me.ShowDataLabelsCheck)
			Me.Controls.Add(Me.THBE)
			Me.Controls.Add(Me.SHBE)
			Me.Controls.Add(Me.FHBE)
			Me.Controls.Add(Me.THTE)
			Me.Controls.Add(Me.SHTE)
			Me.Controls.Add(Me.FHTE)
			Me.Controls.Add(Me.BarShapeCombo)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.PositiveNegativeData)
			Me.Controls.Add(Me.PositiveData)
			Me.Controls.Add(Me.StackModeCombo)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.ThirdBarDataLabelsCombo)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.SecondBarDataLabelsCombo)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.FirstBarDataLabelsCombo)
			Me.Controls.Add(Me.label1)
			Me.Name = "NStackedBarUC"
			Me.Size = New System.Drawing.Size(180, 538)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Stacked Bar Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 65
			chart.Height = 40
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight)

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' add the first bar
			m_Bar1 = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar1.Name = "Bar1"
			m_Bar1.MultiBarMode = MultiBarMode.Series

			' add the second bar
			m_Bar2 = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar2.Name = "Bar2"
			m_Bar2.MultiBarMode = MultiBarMode.Stacked

			' add the third bar
			m_Bar3 = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar3.Name = "Bar3"
			m_Bar3.MultiBarMode = MultiBarMode.Stacked

			' setup value formatting
			m_Bar1.Values.ValueFormatter = New NNumericValueFormatter("0.###")
			m_Bar2.Values.ValueFormatter = New NNumericValueFormatter("0.###")
			m_Bar3.Values.ValueFormatter = New NNumericValueFormatter("0.###")

			' position data labels in the center of the bars
			m_Bar1.DataLabelStyle.VertAlign = VertAlign.Center
			m_Bar2.DataLabelStyle.VertAlign = VertAlign.Center
			m_Bar3.DataLabelStyle.VertAlign = VertAlign.Center

			m_Bar1.DataLabelStyle.ArrowLength = New NLength(0)
			m_Bar2.DataLabelStyle.ArrowLength = New NLength(0)
			m_Bar3.DataLabelStyle.ArrowLength = New NLength(0)

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			InitLabelsCombo(FirstBarDataLabelsCombo)
			InitLabelsCombo(SecondBarDataLabelsCombo)
			InitLabelsCombo(ThirdBarDataLabelsCombo)

			StackModeCombo.Items.Add("Stacked")
			StackModeCombo.Items.Add("Stacked %")
			StackModeCombo.SelectedIndex = 0

			BarShapeCombo.FillFromEnum(GetType(BarShape))
			BarShapeCombo.SelectedIndex = 0

			FHTE.Checked = True
			SHTE.Checked = True
			THTE.Checked = True
			FHBE.Checked = True
			SHBE.Checked = True
			THBE.Checked = True

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
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim scale As NStandardScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)

			Select Case StackModeCombo.SelectedIndex
				Case 0
					m_Bar2.MultiBarMode = MultiBarMode.Stacked
					m_Bar3.MultiBarMode = MultiBarMode.Stacked
					scale.LabelValueFormatter = New NNumericValueFormatter(NumericValueFormat.General)

				Case 1
					m_Bar2.MultiBarMode = MultiBarMode.StackedPercent
					m_Bar3.MultiBarMode = MultiBarMode.StackedPercent
					scale.LabelValueFormatter = New NNumericValueFormatter(NumericValueFormat.Percentage)
			End Select

			nChartControl1.Refresh()
		End Sub
		Private Sub PositiveDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PositiveData.Click
			m_Bar1.Values.FillRandomRange(Random, categoriesCount, 10, 100)
			m_Bar2.Values.FillRandomRange(Random, categoriesCount, 10, 100)
			m_Bar3.Values.FillRandomRange(Random, categoriesCount, 10, 100)

			nChartControl1.Refresh()
		End Sub
		Private Sub PositiveNegativeDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PositiveNegativeData.Click
			m_Bar1.Values.FillRandomRange(Random, categoriesCount, -100, 100)
			m_Bar2.Values.FillRandomRange(Random, categoriesCount, -100, 100)
			m_Bar3.Values.FillRandomRange(Random, categoriesCount, -100, 100)
			nChartControl1.Refresh()
		End Sub
		Private Sub BarShapeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarShapeCombo.SelectedIndexChanged
			m_Bar1.BarShape = CType(BarShapeCombo.SelectedIndex, BarShape)
			m_Bar2.BarShape = CType(BarShapeCombo.SelectedIndex, BarShape)
			m_Bar3.BarShape = CType(BarShapeCombo.SelectedIndex, BarShape)

			Dim bEnable As Boolean = False
			If m_Bar3.BarShape = BarShape.SmoothEdgeBar OrElse m_Bar3.BarShape = BarShape.CutEdgeBar Then
				bEnable = True
			End If

			Dim arrControls As New ArrayList()
			arrControls.Add(FHTE)
			arrControls.Add(FHBE)

			arrControls.Add(SHTE)
			arrControls.Add(SHBE)

			arrControls.Add(THTE)
			arrControls.Add(THBE)

			For Each check As Nevron.UI.WinForm.Controls.NCheckBox In arrControls
				check.Enabled = bEnable
			Next check

			nChartControl1.Refresh()
		End Sub
		Private Sub FHTE_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FHTE.CheckedChanged
			m_Bar1.HasTopEdge = FHTE.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub FHBE_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FHBE.CheckedChanged
			m_Bar1.HasBottomEdge = FHBE.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub SHTE_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SHTE.CheckedChanged
			m_Bar2.HasTopEdge = SHTE.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub SHBE_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SHBE.CheckedChanged
			m_Bar2.HasBottomEdge = SHBE.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub THTE_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles THTE.CheckedChanged
			m_Bar3.HasTopEdge = THTE.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub THBE_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles THBE.CheckedChanged
			m_Bar3.HasBottomEdge = THBE.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub ShowDataLabelsCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowDataLabelsCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim s0 As NSeries = CType(chart.Series(0), NSeries)
			Dim s1 As NSeries = CType(chart.Series(1), NSeries)
			Dim s2 As NSeries = CType(chart.Series(2), NSeries)

			s0.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked
			s1.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked
			s2.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked

			FirstBarDataLabelsCombo.Enabled = ShowDataLabelsCheck.Checked
			SecondBarDataLabelsCombo.Enabled = ShowDataLabelsCheck.Checked
			ThirdBarDataLabelsCombo.Enabled = ShowDataLabelsCheck.Checked

			nChartControl1.Refresh()
		End Sub
		Private Sub FirstBarDataLabelsCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FirstBarDataLabelsCombo.SelectedIndexChanged
			m_Bar1.DataLabelStyle.Format = GetFormatStringFromIndex(FirstBarDataLabelsCombo.SelectedIndex)
			nChartControl1.Refresh()
		End Sub
		Private Sub SecondBarDataLabelsCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SecondBarDataLabelsCombo.SelectedIndexChanged
			m_Bar2.DataLabelStyle.Format = GetFormatStringFromIndex(SecondBarDataLabelsCombo.SelectedIndex)
			nChartControl1.Refresh()
		End Sub
		Private Sub ThirdBarDataLabelsCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ThirdBarDataLabelsCombo.SelectedIndexChanged
			m_Bar3.DataLabelStyle.Format = GetFormatStringFromIndex(ThirdBarDataLabelsCombo.SelectedIndex)
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
