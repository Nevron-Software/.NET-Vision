Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NBackgroundDecoratorUC
		Inherits NExampleBaseUC

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents DockTitleComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents DockLegendComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private m_LabelBackgroundPanel As NBackgroundDecoratorPanel
		Private m_LegendBackgroundPanel As NBackgroundDecoratorPanel
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
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
			Me.label2 = New System.Windows.Forms.Label()
			Me.DockTitleComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.DockLegendComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(5, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(150, 23)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Dock Title:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(5, 88)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(150, 23)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Dock Legend:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' DockTitleComboBox
			' 
			Me.DockTitleComboBox.ListProperties.CheckBoxDataMember = ""
			Me.DockTitleComboBox.ListProperties.DataSource = Nothing
			Me.DockTitleComboBox.ListProperties.DisplayMember = ""
			Me.DockTitleComboBox.Location = New System.Drawing.Point(5, 40)
			Me.DockTitleComboBox.Name = "DockTitleComboBox"
			Me.DockTitleComboBox.Size = New System.Drawing.Size(171, 21)
			Me.DockTitleComboBox.TabIndex = 1
			Me.DockTitleComboBox.Text = "comboBox1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DockTitleComboBox.SelectedIndexChanged += new System.EventHandler(this.DockTitleComboBox_SelectedIndexChanged);
			' 
			' DockLegendComboBox
			' 
			Me.DockLegendComboBox.ListProperties.CheckBoxDataMember = ""
			Me.DockLegendComboBox.ListProperties.DataSource = Nothing
			Me.DockLegendComboBox.ListProperties.DisplayMember = ""
			Me.DockLegendComboBox.Location = New System.Drawing.Point(5, 112)
			Me.DockLegendComboBox.Name = "DockLegendComboBox"
			Me.DockLegendComboBox.Size = New System.Drawing.Size(171, 21)
			Me.DockLegendComboBox.TabIndex = 3
			Me.DockLegendComboBox.Text = "comboBox2"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DockLegendComboBox.SelectedIndexChanged += new System.EventHandler(this.DockLegendComboBox_SelectedIndexChanged);
			' 
			' NBackgroundDecoratorUC
			' 
			Me.Controls.Add(Me.DockLegendComboBox)
			Me.Controls.Add(Me.DockTitleComboBox)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Name = "NBackgroundDecoratorUC"
			Me.Size = New System.Drawing.Size(180, 256)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			Dim palette As Nevron.UI.WinForm.Controls.NPalette = Nevron.UI.WinForm.Controls.NUIManager.Palette

			' Clear the chart panels
			nChartControl1.Panels.Clear()
			' Create a background style to assign to the new panels
			Dim backroundStyle As New NBackgroundStyle()
			backroundStyle.FillStyle = New NColorFillStyle(Color.Transparent)
			Dim frameStyle As New NImageFrameStyle()
			frameStyle.BorderStyle.Color = palette.ControlDark
			frameStyle.BackgroundColor = Color.Transparent
			frameStyle.Type = ImageFrameType.Raised
			backroundStyle.FrameStyle = frameStyle

			' Create the label background panel
			m_LabelBackgroundPanel = New NBackgroundDecoratorPanel()
			m_LabelBackgroundPanel.Size = New NSizeL(New NLength(0, NGraphicsUnit.Pixel), New NLength(10, NRelativeUnit.ParentPercentage))
			m_LabelBackgroundPanel.DockMode = PanelDockMode.Top
			m_LabelBackgroundPanel.DockMargins = New NMarginsL(New NLength(5, NGraphicsUnit.Point), New NLength(5, NGraphicsUnit.Point), New NLength(5, NGraphicsUnit.Point), New NLength(5, NGraphicsUnit.Point))
			m_LabelBackgroundPanel.BackgroundStyle = DirectCast(backroundStyle.Clone(), NBackgroundStyle)
			nChartControl1.Panels.Add(m_LabelBackgroundPanel)

			' Create the legend background panel
			m_LegendBackgroundPanel = New NBackgroundDecoratorPanel()
			m_LegendBackgroundPanel.Size = New NSizeL(New NLength(20, NRelativeUnit.ParentPercentage), New NLength(0, NGraphicsUnit.Pixel))
			m_LegendBackgroundPanel.DockMode = PanelDockMode.Right
			m_LegendBackgroundPanel.BackgroundStyle = DirectCast(backroundStyle.Clone(), NBackgroundStyle)
			m_LegendBackgroundPanel.DockMargins = New NMarginsL(New NLength(5, NGraphicsUnit.Point), New NLength(5, NGraphicsUnit.Point), New NLength(5, NGraphicsUnit.Point), New NLength(5, NGraphicsUnit.Point))
			nChartControl1.Panels.Add(m_LegendBackgroundPanel)

			' Create the chart background panel
			Dim chartBackgroundPanel As New NBackgroundDecoratorPanel()
			chartBackgroundPanel.BackgroundStyle = DirectCast(backroundStyle.Clone(), NBackgroundStyle)
			chartBackgroundPanel.DockMode = PanelDockMode.Fill
			chartBackgroundPanel.DockMargins = New NMarginsL(New NLength(5, NGraphicsUnit.Point), New NLength(5, NGraphicsUnit.Point), New NLength(5, NGraphicsUnit.Point), New NLength(5, NGraphicsUnit.Point))
			nChartControl1.Panels.Add(chartBackgroundPanel)

			' Create the header label and host it in the label background panel
			Dim title As New NLabel("Background Decorator Panel")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(Color.SlateGray)
			title.ContentAlignment = ContentAlignment.MiddleCenter
			title.DockMode = PanelDockMode.Fill
			title.BoundsMode = BoundsMode.Fit
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			title.DockMargins = New NMarginsL(frameStyle.LightEffectSize, frameStyle.LightEffectSize, frameStyle.LightEffectSize, frameStyle.LightEffectSize)

			m_LabelBackgroundPanel.ChildPanels.Add(title)

			' Create the legend and host it in the legend background panel
			Dim legend As New NLegend()
			legend.DockMode = PanelDockMode.Fill
			legend.ContentAlignment = ContentAlignment.MiddleCenter
			legend.DockMargins = New NMarginsL(frameStyle.LightEffectSize, frameStyle.LightEffectSize, frameStyle.LightEffectSize, frameStyle.LightEffectSize)
			m_LegendBackgroundPanel.ChildPanels.Add(legend)

			' Create a cartesian chart and host it in the chart background panel
			Dim chart As NChart = New NCartesianChart()
			chartBackgroundPanel.ChildPanels.Add(chart)
			chart.DisplayOnLegend = legend
			chart.BoundsMode = BoundsMode.Stretch

			' add bar and change bar color
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar Series"
			bar.Legend.Mode = SeriesLegendMode.DataPoints
			bar.ShadowStyle.Type = ShadowType.GaussianBlur
			bar.ShadowStyle.Offset = New NPointL(3, 3)
			bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0)
			bar.ShadowStyle.FadeLength = New NLength(5)

			' add some data to the bar series
			bar.AddDataPoint(New NDataPoint(18, "C++"))
			bar.AddDataPoint(New NDataPoint(15, "Ruby"))
			bar.AddDataPoint(New NDataPoint(21, "Python"))
			bar.AddDataPoint(New NDataPoint(23, "Java"))
			bar.AddDataPoint(New NDataPoint(27, "Javascript"))
			bar.AddDataPoint(New NDataPoint(29, "C#"))
			bar.AddDataPoint(New NDataPoint(26, "PHP"))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			DockTitleComboBox.Items.Add("Top")
			DockTitleComboBox.Items.Add("Bottom")
			DockTitleComboBox.SelectedIndex = 0

			DockLegendComboBox.Items.Add("Left")
			DockLegendComboBox.Items.Add("Right")
			DockLegendComboBox.SelectedIndex = 1
		End Sub

		Private Sub DockTitleComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DockTitleComboBox.SelectedIndexChanged
			If DockTitleComboBox.SelectedIndex = 0 Then
				m_LabelBackgroundPanel.DockMode = PanelDockMode.Top
			Else
				m_LabelBackgroundPanel.DockMode = PanelDockMode.Bottom
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub DockLegendComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DockLegendComboBox.SelectedIndexChanged
			If DockLegendComboBox.SelectedIndex = 0 Then
				m_LegendBackgroundPanel.DockMode = PanelDockMode.Left
			Else
				m_LegendBackgroundPanel.DockMode = PanelDockMode.Right
			End If

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
