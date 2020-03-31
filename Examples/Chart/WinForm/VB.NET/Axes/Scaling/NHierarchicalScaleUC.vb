Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NHierarchicalScaleUC
		Inherits NExampleBaseUC

		Private m_Bar1 As NBarSeries
		Private m_Bar2 As NBarSeries
		Private label1 As Label
		Private WithEvents FirstRowIndividualModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents CreateSeparatorForEachLevelCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label2 As Label
		Private WithEvents FirstRowSeparatorModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label3 As Label
		Private WithEvents GroupRowSeparatorModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label4 As Label
		Private WithEvents GroupRowIndividualModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents ChangeDataButton As Nevron.UI.WinForm.Controls.NButton

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.ChangeDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.FirstRowIndividualModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.CreateSeparatorForEachLevelCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.FirstRowSeparatorModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.GroupRowSeparatorModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.GroupRowIndividualModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' ChangeDataButton
			' 
			Me.ChangeDataButton.Location = New System.Drawing.Point(10, 293)
			Me.ChangeDataButton.Name = "ChangeDataButton"
			Me.ChangeDataButton.Size = New System.Drawing.Size(153, 23)
			Me.ChangeDataButton.TabIndex = 9
			Me.ChangeDataButton.Text = "Change Data"
			Me.ChangeDataButton.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(10, 57)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(108, 13)
			Me.label1.TabIndex = 2
			Me.label1.Text = "First Row Tick Mode:"
			' 
			' FirstRowIndividualModeComboBox
			' 
			Me.FirstRowIndividualModeComboBox.Location = New System.Drawing.Point(10, 76)
			Me.FirstRowIndividualModeComboBox.Name = "FirstRowIndividualModeComboBox"
			Me.FirstRowIndividualModeComboBox.Size = New System.Drawing.Size(153, 21)
			Me.FirstRowIndividualModeComboBox.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FirstRowIndividualModeComboBox.SelectedIndexChanged += new System.EventHandler(this.LabelTickModeComboBox_SelectedIndexChanged);
			' 
			' CreateSeparatorForEachLevelCheckBox
			' 
			Me.CreateSeparatorForEachLevelCheckBox.AutoSize = True
			Me.CreateSeparatorForEachLevelCheckBox.ButtonProperties.BorderOffset = 2
			Me.CreateSeparatorForEachLevelCheckBox.Location = New System.Drawing.Point(10, 270)
			Me.CreateSeparatorForEachLevelCheckBox.Name = "CreateSeparatorForEachLevelCheckBox"
			Me.CreateSeparatorForEachLevelCheckBox.Size = New System.Drawing.Size(153, 17)
			Me.CreateSeparatorForEachLevelCheckBox.TabIndex = 8
			Me.CreateSeparatorForEachLevelCheckBox.Text = "Create Separator per Level"
			Me.CreateSeparatorForEachLevelCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.CreateSeparatorForEachLevelCheckBox.CheckedChanged += new System.EventHandler(this.CreateSeparatorForEachLevelCheckBox_CheckedChanged);
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(10, 10)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(133, 13)
			Me.label2.TabIndex = 0
			Me.label2.Text = "First Row Separator Mode:"
			' 
			' FirstRowSeparatorModeComboBox
			' 
			Me.FirstRowSeparatorModeComboBox.Location = New System.Drawing.Point(10, 29)
			Me.FirstRowSeparatorModeComboBox.Name = "FirstRowSeparatorModeComboBox"
			Me.FirstRowSeparatorModeComboBox.Size = New System.Drawing.Size(153, 21)
			Me.FirstRowSeparatorModeComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FirstRowSeparatorModeComboBox.SelectedIndexChanged += new System.EventHandler(this.FirstRowSeparatorModeComboBox_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(10, 138)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(143, 13)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Group Row Separator Mode:"
			' 
			' GroupRowSeparatorModeComboBox
			' 
			Me.GroupRowSeparatorModeComboBox.Location = New System.Drawing.Point(10, 157)
			Me.GroupRowSeparatorModeComboBox.Name = "GroupRowSeparatorModeComboBox"
			Me.GroupRowSeparatorModeComboBox.Size = New System.Drawing.Size(153, 21)
			Me.GroupRowSeparatorModeComboBox.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GroupRowSeparatorModeComboBox.SelectedIndexChanged += new System.EventHandler(this.SeparatorModeComboBox_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(10, 183)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(118, 13)
			Me.label4.TabIndex = 6
			Me.label4.Text = "Group Row Tick Mode:"
			' 
			' GroupRowIndividualModeComboBox
			' 
			Me.GroupRowIndividualModeComboBox.Location = New System.Drawing.Point(10, 202)
			Me.GroupRowIndividualModeComboBox.Name = "GroupRowIndividualModeComboBox"
			Me.GroupRowIndividualModeComboBox.Size = New System.Drawing.Size(153, 21)
			Me.GroupRowIndividualModeComboBox.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GroupRowIndividualModeComboBox.SelectedIndexChanged += new System.EventHandler(this.GroupRowIndividualComboBox_SelectedIndexChanged);
			' 
			' NHierarchicalScaleUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.GroupRowIndividualModeComboBox)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.GroupRowSeparatorModeComboBox)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.FirstRowSeparatorModeComboBox)
			Me.Controls.Add(Me.CreateSeparatorForEachLevelCheckBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.FirstRowIndividualModeComboBox)
			Me.Controls.Add(Me.ChangeDataButton)
			Me.Name = "NHierarchicalScaleUC"
			Me.Size = New System.Drawing.Size(174, 559)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Quarterly Company Sales<br/><font size = '9pt'>Demonstrates how to use hierarchical scale configurators as well as data zooming and scrolling</font>")
			header.DockMode = PanelDockMode.Top
			header.Margins = New NMarginsL(0, 10, 0, 10)
			header.TextStyle.TextFormat = TextFormat.XML
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			nChartControl1.Panels.Add(header)

			Dim legend As New NLegend()
			legend.Margins = New NMarginsL(10, 0, 10, 0)
			legend.DockMode = PanelDockMode.Right
			legend.FitAlignment = ContentAlignment.TopCenter
			nChartControl1.Panels.Add(legend)

			Dim chart As New NCartesianChart()
			nChartControl1.Panels.Add(chart)

			Dim rangeSelection As New NRangeSelection()
			rangeSelection.VerticalValueSnapper = New NAxisRulerMinMaxSnapper()
			chart.RangeSelections.Add(rangeSelection)

			chart.DisplayOnLegend = legend
			chart.DockMode = PanelDockMode.Fill
			chart.BoundsMode = BoundsMode.Stretch
			chart.Margins = New NMarginsL(10, 0, 0, 10)
			chart.Axis(StandardAxis.Depth).Visible = False

			' add the first bar
			m_Bar1 = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar1.Name = "Coca Cola"
			m_Bar1.MultiBarMode = MultiBarMode.Series
			m_Bar1.DataLabelStyle.Visible = False

			' add the second bar
			m_Bar2 = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar2.Name = "Pepsi"
			m_Bar2.MultiBarMode = MultiBarMode.Clustered
			m_Bar2.DataLabelStyle.Visible = False

			Dim xAxis As NAxis = chart.Axis(StandardAxis.PrimaryX)
			xAxis.ScrollBar.Visible = True

			' add custom labels to the Y axis
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			' add interlace stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' configure interactivity
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())
			nChartControl1.Controller.Tools.Add(New NDataZoomTool())

			' first row combo boxes
			FirstRowIndividualModeComboBox.FillFromEnum(GetType(RangeLabelTickMode))
			FirstRowIndividualModeComboBox.SelectedIndex = CInt(RangeLabelTickMode.Separators)

			FirstRowSeparatorModeComboBox.FillFromEnum(GetType(FirstRowGridStyle))
			FirstRowSeparatorModeComboBox.SelectedIndex = CInt(FirstRowGridStyle.Individual)

			GroupRowIndividualModeComboBox.FillFromEnum(GetType(RangeLabelTickMode))
			GroupRowIndividualModeComboBox.SelectedIndex = CInt(RangeLabelTickMode.Separators)

			GroupRowSeparatorModeComboBox.FillFromEnum(GetType(GroupRowGridStyle))
			GroupRowSeparatorModeComboBox.SelectedIndex = CInt(GroupRowGridStyle.Individual)

			CreateSeparatorForEachLevelCheckBox.Checked = True

			ChangeDataButton_Click(Nothing, Nothing)
			UpdateScale()
		End Sub

		Private Sub UpdateScale()
			' add custom labels to the X axis
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As New NHierarchicalScaleConfigurator()
			Dim nodes As NHierarchicalScaleNodeCollection = scale_Renamed.Nodes


			scale_Renamed.FirstRowGridStyle = CType(FirstRowSeparatorModeComboBox.SelectedIndex, FirstRowGridStyle)
			scale_Renamed.GroupRowGridStyle = CType(GroupRowSeparatorModeComboBox.SelectedIndex, GroupRowGridStyle)
			scale_Renamed.InnerMajorTickStyle.Visible = False
			scale_Renamed.OuterMajorTickStyle.Visible = False

			Dim months() As String = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }

			For i As Integer = 0 To 1
				Dim yearNode As New NHierarchicalScaleNode(0, (i + 2007).ToString())
				yearNode.LabelStyle.TickMode = CType(GroupRowIndividualModeComboBox.SelectedIndex, RangeLabelTickMode)
				nodes.AddChild(yearNode)

				For j As Integer = 0 To 3
					Dim quarterNode As New NHierarchicalScaleNode(3, "Q" & (j + 1).ToString())
					quarterNode.LabelStyle.TickMode = CType(GroupRowIndividualModeComboBox.SelectedIndex, RangeLabelTickMode)
					yearNode.ChildNodes.AddChild(quarterNode)

					For k As Integer = 0 To 2
						Dim monthNode As New NHierarchicalScaleNode(1, months(j * 3 + k))
						monthNode.LabelStyle.Angle = New NScaleLabelAngle(90)
						monthNode.LabelStyle.TickMode = CType(FirstRowIndividualModeComboBox.SelectedIndex, RangeLabelTickMode)
						quarterNode.ChildNodes.AddChild(monthNode)
					Next k
				Next j
			Next i

			' update control state
			FirstRowIndividualModeComboBox.Enabled = (CType(FirstRowSeparatorModeComboBox.SelectedIndex, FirstRowGridStyle)) = FirstRowGridStyle.Individual
			GroupRowIndividualModeComboBox.Enabled = (CType(GroupRowSeparatorModeComboBox.SelectedIndex, GroupRowGridStyle)) = GroupRowGridStyle.Individual

			Dim stripStyle As New NScaleStripStyle()
			stripStyle.Length = 3
			stripStyle.Interval = 3
			stripStyle.FillStyle = New NColorFillStyle(Color.FromArgb(125, Color.LightGray))
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			scale_Renamed.StripStyles.Add(stripStyle)

			scale_Renamed.CreateSeparatorForEachLevel = CreateSeparatorForEachLevelCheckBox.Checked

			nChartControl1.Charts(0).Axis(StandardAxis.PrimaryX).ScaleConfigurator = scale_Renamed
			nChartControl1.Refresh()
		End Sub

		Private Sub ChangeDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ChangeDataButton.Click
			' fill with random data
			m_Bar1.Values.FillRandomRange(Random, 24, 10, 200)
			m_Bar2.Values.FillRandomRange(Random, 24, 10, 300)

			nChartControl1.Refresh()
		End Sub

		Private Sub CreateSeparatorForEachLevelCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CreateSeparatorForEachLevelCheckBox.CheckedChanged
			UpdateScale()
		End Sub

		Private Sub LabelTickModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FirstRowIndividualModeComboBox.SelectedIndexChanged
			UpdateScale()
		End Sub

		Private Sub FirstRowSeparatorModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FirstRowSeparatorModeComboBox.SelectedIndexChanged
			UpdateScale()
		End Sub

		Private Sub SeparatorModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GroupRowSeparatorModeComboBox.SelectedIndexChanged
			UpdateScale()
		End Sub

		Private Sub GroupRowIndividualComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GroupRowIndividualModeComboBox.SelectedIndexChanged
			UpdateScale()
		End Sub
	End Class
End Namespace
