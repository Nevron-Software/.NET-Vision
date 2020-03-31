Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.UI.WinForm.Controls


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NAxisLabelsUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private label2 As System.Windows.Forms.Label
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label1 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private WithEvents YTicksPerLabelUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents YLabelGenerationModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents YLabelFitModesList As Nevron.UI.WinForm.Controls.NListBox
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private WithEvents XLabelFitModesList As Nevron.UI.WinForm.Controls.NListBox
		Private WithEvents XTicksPerLabelUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents XLabelGenerationModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
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
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.YLabelFitModesList = New Nevron.UI.WinForm.Controls.NListBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.YTicksPerLabelUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.YLabelGenerationModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.XLabelFitModesList = New Nevron.UI.WinForm.Controls.NListBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.XTicksPerLabelUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label6 = New System.Windows.Forms.Label()
			Me.XLabelGenerationModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nGroupBox1.SuspendLayout()
			DirectCast(Me.YTicksPerLabelUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGroupBox2.SuspendLayout()
			DirectCast(Me.XTicksPerLabelUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.label3)
			Me.nGroupBox1.Controls.Add(Me.YLabelFitModesList)
			Me.nGroupBox1.Controls.Add(Me.label7)
			Me.nGroupBox1.Controls.Add(Me.YTicksPerLabelUpDown)
			Me.nGroupBox1.Controls.Add(Me.label2)
			Me.nGroupBox1.Controls.Add(Me.YLabelGenerationModeComboBox)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(7, 8)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(172, 305)
			Me.nGroupBox1.TabIndex = 18
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Y Axis Labels"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(14, 136)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(144, 15)
			Me.label3.TabIndex = 26
			Me.label3.Text = "Label Fit Modes:"
			' 
			' YLabelFitModesList
			' 
			Me.YLabelFitModesList.CheckBoxes = True
			Me.YLabelFitModesList.Location = New System.Drawing.Point(16, 152)
			Me.YLabelFitModesList.Name = "YLabelFitModesList"
			Me.YLabelFitModesList.Size = New System.Drawing.Size(144, 124)
			Me.YLabelFitModesList.TabIndex = 25
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YLabelFitModesList.CheckedChanged += new Nevron.UI.WinForm.Controls.NListBoxItemCheckedEventHandler(this.YLabelFitModesList_CheckedChanged);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(16, 80)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(144, 15)
			Me.label7.TabIndex = 24
			Me.label7.Text = "Number of Ticks per Label:"
			' 
			' YTicksPerLabelUpDown
			' 
			Me.YTicksPerLabelUpDown.Location = New System.Drawing.Point(16, 97)
			Me.YTicksPerLabelUpDown.Minimum = New System.Decimal(New Integer() { 1, 0, 0, 0})
			Me.YTicksPerLabelUpDown.Name = "YTicksPerLabelUpDown"
			Me.YTicksPerLabelUpDown.Size = New System.Drawing.Size(144, 20)
			Me.YTicksPerLabelUpDown.TabIndex = 23
			Me.YTicksPerLabelUpDown.Value = New System.Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YTicksPerLabelUpDown.ValueChanged += new System.EventHandler(this.YTicksPerLabelUpDown_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(16, 24)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(137, 15)
			Me.label2.TabIndex = 21
			Me.label2.Text = "Label Generation Mode:"
			' 
			' YLabelGenerationModeComboBox
			' 
			Me.YLabelGenerationModeComboBox.Location = New System.Drawing.Point(16, 40)
			Me.YLabelGenerationModeComboBox.Name = "YLabelGenerationModeComboBox"
			Me.YLabelGenerationModeComboBox.Size = New System.Drawing.Size(144, 21)
			Me.YLabelGenerationModeComboBox.TabIndex = 19
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YLabelGenerationModeComboBox.SelectedIndexChanged += new System.EventHandler(this.YLabelGenerationModeComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(0, 0)
			Me.label1.Name = "label1"
			Me.label1.TabIndex = 0
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.label4)
			Me.nGroupBox2.Controls.Add(Me.XLabelFitModesList)
			Me.nGroupBox2.Controls.Add(Me.label5)
			Me.nGroupBox2.Controls.Add(Me.XTicksPerLabelUpDown)
			Me.nGroupBox2.Controls.Add(Me.label6)
			Me.nGroupBox2.Controls.Add(Me.XLabelGenerationModeComboBox)
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(7, 349)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(172, 305)
			Me.nGroupBox2.TabIndex = 23
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "X Axis Labels"
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(13, 138)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(144, 15)
			Me.label4.TabIndex = 32
			Me.label4.Text = "Label Fit Modes:"
			' 
			' XLabelFitModesList
			' 
			Me.XLabelFitModesList.CheckBoxes = True
			Me.XLabelFitModesList.Location = New System.Drawing.Point(15, 154)
			Me.XLabelFitModesList.Name = "XLabelFitModesList"
			Me.XLabelFitModesList.Size = New System.Drawing.Size(144, 124)
			Me.XLabelFitModesList.TabIndex = 31
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XLabelFitModesList.CheckedChanged += new Nevron.UI.WinForm.Controls.NListBoxItemCheckedEventHandler(this.XLabelFitModesList_CheckedChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(15, 82)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(144, 15)
			Me.label5.TabIndex = 30
			Me.label5.Text = "Number of Ticks per Label:"
			' 
			' XTicksPerLabelUpDown
			' 
			Me.XTicksPerLabelUpDown.Location = New System.Drawing.Point(15, 99)
			Me.XTicksPerLabelUpDown.Minimum = New System.Decimal(New Integer() { 1, 0, 0, 0})
			Me.XTicksPerLabelUpDown.Name = "XTicksPerLabelUpDown"
			Me.XTicksPerLabelUpDown.Size = New System.Drawing.Size(144, 20)
			Me.XTicksPerLabelUpDown.TabIndex = 29
			Me.XTicksPerLabelUpDown.Value = New System.Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XTicksPerLabelUpDown.ValueChanged += new System.EventHandler(this.XTicksPerLabelUpDown_ValueChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(15, 26)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(137, 15)
			Me.label6.TabIndex = 28
			Me.label6.Text = "Label Generation Mode:"
			' 
			' XLabelGenerationModeComboBox
			' 
			Me.XLabelGenerationModeComboBox.Location = New System.Drawing.Point(15, 42)
			Me.XLabelGenerationModeComboBox.Name = "XLabelGenerationModeComboBox"
			Me.XLabelGenerationModeComboBox.Size = New System.Drawing.Size(144, 21)
			Me.XLabelGenerationModeComboBox.TabIndex = 27
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XLabelGenerationModeComboBox.SelectedIndexChanged += new System.EventHandler(this.XLabelGenerationModeComboBox_SelectedIndexChanged);
			' 
			' NAxisLabelsUC
			' 
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Name = "NAxisLabelsUC"
			Me.Size = New System.Drawing.Size(188, 665)
			Me.nGroupBox1.ResumeLayout(False)
			DirectCast(Me.YTicksPerLabelUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGroupBox2.ResumeLayout(False)
			DirectCast(Me.XTicksPerLabelUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Axis Labels")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch

			Dim scaleConfiguratorY As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfiguratorY.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleConfiguratorY.MaxTickCount = 50

			' add interlaced stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			scaleConfiguratorY.StripStyles.Add(stripStyle)

			Dim scaleConfiguratorX As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfiguratorX.MajorTickMode = MajorTickMode.AutoMaxCount

			scaleConfiguratorX.AutoLabels = False
			scaleConfiguratorX.Labels.Add("France")
			scaleConfiguratorX.Labels.Add("Italy")
			scaleConfiguratorX.Labels.Add("Germany")
			scaleConfiguratorX.Labels.Add("Norway")
			scaleConfiguratorX.Labels.Add("Spain")
			scaleConfiguratorX.Labels.Add("Belgium")
			scaleConfiguratorX.Labels.Add("Greece")
			scaleConfiguratorX.Labels.Add("Austria")
			scaleConfiguratorX.Labels.Add("Sweden")
			scaleConfiguratorX.Labels.Add("Finland")
			scaleConfiguratorX.Labels.Add("Poland")
			scaleConfiguratorX.Labels.Add("Denmark")

			Dim series1 As NBarSeries = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			series1.FillStyle = New NColorFillStyle(Color.Crimson)
			series1.Name = "Product A"
			series1.DataLabelStyle.Visible = False
			GenerateData(series1.Values, 12)

			Dim series2 As NBarSeries = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			series2.MultiBarMode = MultiBarMode.Clustered
			series2.FillStyle = New NColorFillStyle(Color.Gold)
			series2.Name = "Product B"
			series2.DataLabelStyle.Visible = False
			GenerateData(series2.Values, 12)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			YTicksPerLabelUpDown.Value = 1
			YLabelGenerationModeComboBox.FillFromEnum(GetType(LabelGenerationMode))
			YLabelGenerationModeComboBox.SelectedIndex = CInt(LabelGenerationMode.SingleLevel)
			YLabelFitModesList.FillFromEnum(GetType(LabelFitMode))
			YLabelFitModesList.Items(CInt(LabelFitMode.AutoScale)).Checked = True

			XTicksPerLabelUpDown.Value = 1
			XLabelGenerationModeComboBox.FillFromEnum(GetType(LabelGenerationMode))
			XLabelGenerationModeComboBox.SelectedIndex = CInt(LabelGenerationMode.SingleLevel)
			XLabelFitModesList.FillFromEnum(GetType(LabelFitMode))
			XLabelFitModesList.Items(CInt(LabelFitMode.AutoScale)).Checked = True
		End Sub

		Private Sub GenerateData(ByVal dataSeries As NDataSeriesDouble, ByVal count As Integer)
			For i As Integer = 0 To count - 1
				dataSeries.Add(Random.NextDouble() * 99 + 1)
			Next i
		End Sub

		Private Function GetLabelFitModesFromListBox(ByVal listBox As NListBox) As LabelFitMode()
			Dim arrFitModes As New ArrayList()

			For i As Integer = 0 To listBox.Items.Count - 1
				Dim item As NListBoxItem = listBox.Items(i)

				If item.Checked Then
					arrFitModes.Add(CType(i, LabelFitMode))
				End If
			Next i

			Return DirectCast(arrFitModes.ToArray(GetType(LabelFitMode)), LabelFitMode())
		End Function


		Private Sub YLabelGenerationModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles YLabelGenerationModeComboBox.SelectedIndexChanged
			If m_Chart Is Nothing Then
				Return
			End If

			Dim scaleConfiguratorY As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)

			scaleConfiguratorY.LabelGenerationMode = CType(YLabelGenerationModeComboBox.SelectedIndex, LabelGenerationMode)

			nChartControl1.Refresh()
		End Sub

		Private Sub YTicksPerLabelUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles YTicksPerLabelUpDown.ValueChanged
			If m_Chart Is Nothing Then
				Return
			End If

			Dim scaleConfiguratorY As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)

			scaleConfiguratorY.NumberOfTicksPerLabel = CInt(Math.Truncate(YTicksPerLabelUpDown.Value))

			nChartControl1.Refresh()
		End Sub

		Private Sub YLabelFitModesList_CheckedChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.NListBoxItemCheckEventArgs) Handles YLabelFitModesList.CheckedChanged
			If m_Chart Is Nothing Then
				Return
			End If

			Dim scaleConfiguratorY As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)

			scaleConfiguratorY.LabelFitModes = GetLabelFitModesFromListBox(YLabelFitModesList)

			nChartControl1.Refresh()
		End Sub

		Private Sub XLabelGenerationModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles XLabelGenerationModeComboBox.SelectedIndexChanged
			If m_Chart Is Nothing Then
				Return
			End If

			Dim scaleConfiguratorX As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)

			scaleConfiguratorX.LabelGenerationMode = CType(XLabelGenerationModeComboBox.SelectedIndex, LabelGenerationMode)

			nChartControl1.Refresh()
		End Sub

		Private Sub XTicksPerLabelUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles XTicksPerLabelUpDown.ValueChanged
			If m_Chart Is Nothing Then
				Return
			End If

			Dim scaleConfiguratorX As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)

			scaleConfiguratorX.NumberOfTicksPerLabel = CInt(Math.Truncate(XTicksPerLabelUpDown.Value))

			nChartControl1.Refresh()
		End Sub

		Private Sub XLabelFitModesList_CheckedChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.NListBoxItemCheckEventArgs) Handles XLabelFitModesList.CheckedChanged
			If m_Chart Is Nothing Then
				Return
			End If

			Dim scaleConfiguratorX As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)

			scaleConfiguratorX.LabelFitModes = GetLabelFitModesFromListBox(XLabelFitModesList)

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
