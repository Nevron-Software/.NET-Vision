Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Reflection
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NLegendGeneralUC
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.Container = Nothing
		Private label8 As System.Windows.Forms.Label
		Private WithEvents LegendModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As System.Windows.Forms.Label
		Private WithEvents HeaderTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents FooterTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private label3 As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
		Private WithEvents ExpandModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label4 As System.Windows.Forms.Label
		Private WithEvents RowCountUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private ColCountUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents PredefinedPositionsComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private WithEvents AddCustomLegendMark As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents DeleteCustomLegendMarkButton As Nevron.UI.WinForm.Controls.NButton
		Private ManualMarksGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private TitlesGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private LayoutGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents LegendItemPropertyGrid As System.Windows.Forms.PropertyGrid
		Private WithEvents CustomLegendMarksComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Public m_Legend As NLegend

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
			Me.label8 = New System.Windows.Forms.Label()
			Me.LegendModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.HeaderTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.FooterTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.ExpandModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.RowCountUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.ColCountUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.PredefinedPositionsComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.ManualMarksGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.CustomLegendMarksComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.LegendItemPropertyGrid = New System.Windows.Forms.PropertyGrid()
			Me.DeleteCustomLegendMarkButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.AddCustomLegendMark = New Nevron.UI.WinForm.Controls.NButton()
			Me.LayoutGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.TitlesGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			DirectCast(Me.RowCountUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.ColCountUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.ManualMarksGroupBox.SuspendLayout()
			Me.LayoutGroupBox.SuspendLayout()
			Me.TitlesGroupBox.SuspendLayout()
			Me.groupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' label8
			' 
			Me.label8.Anchor = System.Windows.Forms.AnchorStyles.None
			Me.label8.Location = New System.Drawing.Point(315, 174)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(105, 16)
			Me.label8.TabIndex = 16
			' 
			' LegendModeComboBox
			' 
			Me.LegendModeComboBox.Location = New System.Drawing.Point(109, 3)
			Me.LegendModeComboBox.Name = "LegendModeComboBox"
			Me.LegendModeComboBox.Size = New System.Drawing.Size(155, 21)
			Me.LegendModeComboBox.TabIndex = 34
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LegendModeComboBox.SelectedIndexChanged += new System.EventHandler(this.LegendModeComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 9)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(98, 15)
			Me.label2.TabIndex = 35
			Me.label2.Text = "Legend mode:"
			' 
			' HeaderTextBox
			' 
			Me.HeaderTextBox.Location = New System.Drawing.Point(90, 18)
			Me.HeaderTextBox.Name = "HeaderTextBox"
			Me.HeaderTextBox.Size = New System.Drawing.Size(157, 20)
			Me.HeaderTextBox.TabIndex = 40
			Me.HeaderTextBox.Text = ""
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HeaderTextBox.TextChanged += new System.EventHandler(this.HeaderTextBox_TextChanged);
			' 
			' FooterTextBox
			' 
			Me.FooterTextBox.Location = New System.Drawing.Point(90, 53)
			Me.FooterTextBox.Name = "FooterTextBox"
			Me.FooterTextBox.Size = New System.Drawing.Size(157, 20)
			Me.FooterTextBox.TabIndex = 41
			Me.FooterTextBox.Text = ""
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FooterTextBox.TextChanged += new System.EventHandler(this.FooterTextBox_TextChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 23)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(49, 15)
			Me.label3.TabIndex = 42
			Me.label3.Text = "Header:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 57)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(58, 15)
			Me.label1.TabIndex = 43
			Me.label1.Text = "Footer:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ExpandModeComboBox
			' 
			Me.ExpandModeComboBox.Location = New System.Drawing.Point(90, 19)
			Me.ExpandModeComboBox.Name = "ExpandModeComboBox"
			Me.ExpandModeComboBox.Size = New System.Drawing.Size(157, 21)
			Me.ExpandModeComboBox.TabIndex = 45
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ExpandModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ExpandModeComboBox_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 25)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(78, 15)
			Me.label4.TabIndex = 46
			Me.label4.Text = "Expand mode:"
			' 
			' RowCountUpDown
			' 
			Me.RowCountUpDown.Location = New System.Drawing.Point(90, 49)
			Me.RowCountUpDown.Minimum = New System.Decimal(New Integer() { 1, 0, 0, 0})
			Me.RowCountUpDown.Name = "RowCountUpDown"
			Me.RowCountUpDown.Size = New System.Drawing.Size(66, 20)
			Me.RowCountUpDown.TabIndex = 47
			Me.RowCountUpDown.Value = New System.Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RowCountUpDown.ValueChanged += new System.EventHandler(this.RowCountUpDown_ValueChanged);
			' 
			' ColCountUpDown
			' 
			Me.ColCountUpDown.Location = New System.Drawing.Point(90, 78)
			Me.ColCountUpDown.Minimum = New System.Decimal(New Integer() { 1, 0, 0, 0})
			Me.ColCountUpDown.Name = "ColCountUpDown"
			Me.ColCountUpDown.Size = New System.Drawing.Size(66, 20)
			Me.ColCountUpDown.TabIndex = 48
			Me.ColCountUpDown.Value = New System.Decimal(New Integer() { 1, 0, 0, 0})
			' 
			' PredefinedPositionsComboBox
			' 
			Me.PredefinedPositionsComboBox.Location = New System.Drawing.Point(8, 21)
			Me.PredefinedPositionsComboBox.Name = "PredefinedPositionsComboBox"
			Me.PredefinedPositionsComboBox.Size = New System.Drawing.Size(242, 21)
			Me.PredefinedPositionsComboBox.TabIndex = 49
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PredefinedPositionsComboBox.SelectedIndexChanged += new System.EventHandler(this.PredefinedPositionsComboBox_SelectedIndexChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 83)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(75, 15)
			Me.label5.TabIndex = 50
			Me.label5.Text = "Col count:"
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(8, 54)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(61, 15)
			Me.label6.TabIndex = 51
			Me.label6.Text = "Row count:"
			' 
			' ManualMarksGroupBox
			' 
			Me.ManualMarksGroupBox.Controls.Add(Me.CustomLegendMarksComboBox)
			Me.ManualMarksGroupBox.Controls.Add(Me.LegendItemPropertyGrid)
			Me.ManualMarksGroupBox.Controls.Add(Me.DeleteCustomLegendMarkButton)
			Me.ManualMarksGroupBox.Controls.Add(Me.AddCustomLegendMark)
			Me.ManualMarksGroupBox.Location = New System.Drawing.Point(8, 33)
			Me.ManualMarksGroupBox.Name = "ManualMarksGroupBox"
			Me.ManualMarksGroupBox.Size = New System.Drawing.Size(256, 354)
			Me.ManualMarksGroupBox.TabIndex = 55
			Me.ManualMarksGroupBox.TabStop = False
			Me.ManualMarksGroupBox.Text = "Custom Legend Data"
			' 
			' CustomLegendMarksComboBox
			' 
			Me.CustomLegendMarksComboBox.Location = New System.Drawing.Point(8, 17)
			Me.CustomLegendMarksComboBox.Name = "CustomLegendMarksComboBox"
			Me.CustomLegendMarksComboBox.Size = New System.Drawing.Size(242, 21)
			Me.CustomLegendMarksComboBox.TabIndex = 60
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.CustomLegendMarksComboBox.SelectedIndexChanged += new System.EventHandler(this.CustomLegendMarksComboBox_SelectedIndexChanged);
			' 
			' LegendItemPropertyGrid
			' 
			Me.LegendItemPropertyGrid.CommandsVisibleIfAvailable = True
			Me.LegendItemPropertyGrid.LargeButtons = False
			Me.LegendItemPropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar
			Me.LegendItemPropertyGrid.Location = New System.Drawing.Point(8, 75)
			Me.LegendItemPropertyGrid.Name = "LegendItemPropertyGrid"
			Me.LegendItemPropertyGrid.Size = New System.Drawing.Size(242, 271)
			Me.LegendItemPropertyGrid.TabIndex = 59
			Me.LegendItemPropertyGrid.Text = "propertyGrid1"
			Me.LegendItemPropertyGrid.ViewBackColor = System.Drawing.SystemColors.Window
			Me.LegendItemPropertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LegendItemPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.LegendItemPropertyGrid_PropertyValueChanged);
			' 
			' DeleteCustomLegendMarkButton
			' 
			Me.DeleteCustomLegendMarkButton.Location = New System.Drawing.Point(196, 44)
			Me.DeleteCustomLegendMarkButton.Name = "DeleteCustomLegendMarkButton"
			Me.DeleteCustomLegendMarkButton.Size = New System.Drawing.Size(53, 23)
			Me.DeleteCustomLegendMarkButton.TabIndex = 58
			Me.DeleteCustomLegendMarkButton.Text = "Delete"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DeleteCustomLegendMarkButton.Click += new System.EventHandler(this.DeleteCustomLegendMarkButton_Click);
			' 
			' AddCustomLegendMark
			' 
			Me.AddCustomLegendMark.Location = New System.Drawing.Point(140, 44)
			Me.AddCustomLegendMark.Name = "AddCustomLegendMark"
			Me.AddCustomLegendMark.Size = New System.Drawing.Size(53, 23)
			Me.AddCustomLegendMark.TabIndex = 57
			Me.AddCustomLegendMark.Text = "Add"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AddCustomLegendMark.Click += new System.EventHandler(this.AddCustomLegendMark_Click);
			' 
			' LayoutGroupBox
			' 
			Me.LayoutGroupBox.Controls.Add(Me.ExpandModeComboBox)
			Me.LayoutGroupBox.Controls.Add(Me.label4)
			Me.LayoutGroupBox.Controls.Add(Me.label6)
			Me.LayoutGroupBox.Controls.Add(Me.RowCountUpDown)
			Me.LayoutGroupBox.Controls.Add(Me.label5)
			Me.LayoutGroupBox.Controls.Add(Me.ColCountUpDown)
			Me.LayoutGroupBox.Location = New System.Drawing.Point(8, 482)
			Me.LayoutGroupBox.Name = "LayoutGroupBox"
			Me.LayoutGroupBox.Size = New System.Drawing.Size(256, 110)
			Me.LayoutGroupBox.TabIndex = 56
			Me.LayoutGroupBox.TabStop = False
			Me.LayoutGroupBox.Text = "Layout"
			' 
			' TitlesGroupBox
			' 
			Me.TitlesGroupBox.Controls.Add(Me.label3)
			Me.TitlesGroupBox.Controls.Add(Me.label1)
			Me.TitlesGroupBox.Controls.Add(Me.FooterTextBox)
			Me.TitlesGroupBox.Controls.Add(Me.HeaderTextBox)
			Me.TitlesGroupBox.Location = New System.Drawing.Point(8, 392)
			Me.TitlesGroupBox.Name = "TitlesGroupBox"
			Me.TitlesGroupBox.Size = New System.Drawing.Size(256, 87)
			Me.TitlesGroupBox.TabIndex = 57
			Me.TitlesGroupBox.TabStop = False
			Me.TitlesGroupBox.Text = "Titles"
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.PredefinedPositionsComboBox)
			Me.groupBox1.Location = New System.Drawing.Point(8, 598)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(256, 49)
			Me.groupBox1.TabIndex = 58
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Predefined style"
			' 
			' NLegendGeneralUC
			' 
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.TitlesGroupBox)
			Me.Controls.Add(Me.LayoutGroupBox)
			Me.Controls.Add(Me.ManualMarksGroupBox)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.LegendModeComboBox)
			Me.Controls.Add(Me.label8)
			Me.Name = "NLegendGeneralUC"
			Me.Size = New System.Drawing.Size(271, 656)
			DirectCast(Me.RowCountUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.ColCountUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ManualMarksGroupBox.ResumeLayout(False)
			Me.LayoutGroupBox.ResumeLayout(False)
			Me.TitlesGroupBox.ResumeLayout(False)
			Me.groupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Legend General")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' create a simple pie chart 
			Dim chart As NChart = New NPieChart()
			chart.Enable3D = True
			nChartControl1.Charts.Add(chart)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)
			chart.BoundsMode = BoundsMode.None
			chart.DisplayOnLegend = m_Legend

			Dim pie As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
			pie.LabelMode = PieLabelMode.Center
			pie.Legend.Mode = SeriesLegendMode.DataPoints
			pie.Legend.Format = "<label> <percent>"

			pie.AddDataPoint(New NDataPoint(12, "Cars"))
			pie.AddDataPoint(New NDataPoint(42, "Trains"))
			pie.AddDataPoint(New NDataPoint(36, "Airplanes"))
			pie.AddDataPoint(New NDataPoint(23, "Buses"))
			pie.AddDataPoint(New NDataPoint(29, "Ships"))
			pie.AddDataPoint(New NDataPoint(15, "Other"))

			' create a legend
			m_Legend = New NLegend()
			nChartControl1.Panels.Add(m_Legend)

			' tell the chart do display data on it
			chart.DisplayOnLegend = m_Legend

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			LegendModeComboBox.Items.Add("Disabled")
			LegendModeComboBox.Items.Add("Automatic")
			LegendModeComboBox.Items.Add("Manual")

			PredefinedPositionsComboBox.Items.Add("Top")
			PredefinedPositionsComboBox.Items.Add("Bottom")
			PredefinedPositionsComboBox.Items.Add("Left")
			PredefinedPositionsComboBox.Items.Add("Right")
			PredefinedPositionsComboBox.Items.Add("Top right")
			PredefinedPositionsComboBox.Items.Add("Top left")

			ExpandModeComboBox.Items.Add("Rows only")
			ExpandModeComboBox.Items.Add("Cols only")
			ExpandModeComboBox.Items.Add("Rows fixed")
			ExpandModeComboBox.Items.Add("Cols fixed")

			If m_Legend.Mode <> LegendMode.Manual Then
				ManualMarksGroupBox.Enabled = False
			End If

			UpdateControlsFromLegend()
			PredefinedPositionsComboBox.SelectedIndex = 4
		End Sub

		Private Sub UpdateControlsFromLegend()
			LegendModeComboBox.SelectedIndex = CInt(m_Legend.Mode)
			HeaderTextBox.Text = m_Legend.Header.Text
			FooterTextBox.Text = m_Legend.Footer.Text
			ExpandModeComboBox.SelectedIndex = CInt(m_Legend.Data.ExpandMode)
			RowCountUpDown.Value = m_Legend.Data.RowCount
			ColCountUpDown.Value = m_Legend.Data.ColCount
		End Sub

		Private Function GetSelectedMark() As NLegendItemCellData
			Dim nIndex As Integer = CustomLegendMarksComboBox.SelectedIndex

			If nIndex < 0 Then
				Return Nothing
			End If

			Return DirectCast(m_Legend.Data.Items(nIndex), NLegendItemCellData)
		End Function

		Private Sub LegendModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LegendModeComboBox.SelectedIndexChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_Legend.Mode = (CType(LegendModeComboBox.SelectedIndex, LegendMode))

			If m_Legend.Mode <> LegendMode.Manual Then
				ManualMarksGroupBox.Enabled = False
				CustomLegendMarksComboBox.Items.Clear()
				LegendItemPropertyGrid.SelectedObject = Nothing
			Else
				ManualMarksGroupBox.Enabled = True
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub ExpandModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExpandModeComboBox.SelectedIndexChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_Legend.Data.ExpandMode = CType(ExpandModeComboBox.SelectedIndex, LegendExpandMode)
			nChartControl1.Refresh()
		End Sub

		Private Sub HeaderTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HeaderTextBox.TextChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_Legend.Header.Text = HeaderTextBox.Text
			nChartControl1.Refresh()
		End Sub

		Private Sub FooterTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FooterTextBox.TextChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_Legend.Footer.Text = FooterTextBox.Text
			nChartControl1.Refresh()
		End Sub

		Private Sub PredefinedPositionsComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PredefinedPositionsComboBox.SelectedIndexChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_Legend.SetPredefinedLegendStyle(CType(PredefinedPositionsComboBox.SelectedIndex, PredefinedLegendStyle))
			UpdateControlsFromLegend()
			nChartControl1.Refresh()
		End Sub

		Private Sub RowCountUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RowCountUpDown.ValueChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_Legend.Data.RowCount = CInt(Math.Truncate(RowCountUpDown.Value))
			nChartControl1.Refresh()
		End Sub

		Private Sub ColCountUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_Legend.Data.ColCount = CInt(Math.Truncate(ColCountUpDown.Value))
			nChartControl1.Refresh()
		End Sub

		Private Sub AddCustomLegendMark_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddCustomLegendMark.Click
			Dim legendDataItem As New NLegendItemCellData()
			legendDataItem.Text = "Data item " & CustomLegendMarksComboBox.Items.Count.ToString()

			m_Legend.Data.Items.Add(legendDataItem)

			CustomLegendMarksComboBox.Items.Add(legendDataItem.Text)
			CustomLegendMarksComboBox.SelectedIndex = CustomLegendMarksComboBox.Items.Count - 1
			LegendItemPropertyGrid.Enabled = True

			nChartControl1.Refresh()
		End Sub

		Private Sub DeleteCustomLegendMarkButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteCustomLegendMarkButton.Click
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim nIndex As Integer = CustomLegendMarksComboBox.SelectedIndex

			If nIndex = -1 Then
				Return
			End If

			CustomLegendMarksComboBox.Items.RemoveAt(nIndex)
			m_Legend.Data.Items.RemoveAt(nIndex)

			nIndex -= 1

			If nIndex < 0 Then
				nIndex = CustomLegendMarksComboBox.Items.Count - 1
			End If

			CustomLegendMarksComboBox.SelectedIndex = nIndex
			LegendItemPropertyGrid.SelectedObject = GetSelectedMark()
			LegendItemPropertyGrid.Enabled = (LegendItemPropertyGrid.SelectedObject IsNot Nothing)

			nChartControl1.Refresh()
		End Sub

		Private Sub CustomLegendMarksComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CustomLegendMarksComboBox.SelectedIndexChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			LegendItemPropertyGrid.SelectedObject = GetSelectedMark()
		End Sub

		Private Sub LegendItemPropertyGrid_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles LegendItemPropertyGrid.PropertyValueChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
