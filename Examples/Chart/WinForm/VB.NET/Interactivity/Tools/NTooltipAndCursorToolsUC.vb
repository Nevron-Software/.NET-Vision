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
	Public Class NTooltipAndCursorToolsUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bar As NBarSeries
		Private m_bUpdating As Boolean
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private WithEvents ChartObjectComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents CursorComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents CursorChangeCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents EnableTooltipChangeCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents UseWindowRenderSurfaceCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents TooltipTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents AutoPopDelayUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ReshowDelayUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents InitialDelayUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			m_bUpdating = True
			InitializeComponent()

			m_bUpdating = False
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
			Me.label3 = New System.Windows.Forms.Label()
			Me.ChartObjectComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.CursorComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.TooltipTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.CursorChangeCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.EnableTooltipChangeCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.AutoPopDelayUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.InitialDelayUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.ReshowDelayUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.UseWindowRenderSurfaceCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			DirectCast(Me.AutoPopDelayUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.InitialDelayUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.ReshowDelayUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(6, 10)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(72, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Chart object:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(6, 45)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(157, 16)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Tooltip:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(6, 40)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(152, 16)
			Me.label3.TabIndex = 2
			Me.label3.Text = "Cursor:"
			' 
			' ChartObjectComboBox
			' 
			Me.ChartObjectComboBox.ListProperties.CheckBoxDataMember = ""
			Me.ChartObjectComboBox.ListProperties.DataSource = Nothing
			Me.ChartObjectComboBox.ListProperties.DisplayMember = ""
			Me.ChartObjectComboBox.Location = New System.Drawing.Point(11, 30)
			Me.ChartObjectComboBox.Name = "ChartObjectComboBox"
			Me.ChartObjectComboBox.Size = New System.Drawing.Size(157, 21)
			Me.ChartObjectComboBox.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChartObjectComboBox.SelectedIndexChanged += new System.EventHandler(this.ChartObjectComboBox_SelectedIndexChanged);
			' 
			' CursorComboBox
			' 
			Me.CursorComboBox.ListProperties.CheckBoxDataMember = ""
			Me.CursorComboBox.ListProperties.DataSource = Nothing
			Me.CursorComboBox.ListProperties.DisplayMember = ""
			Me.CursorComboBox.Location = New System.Drawing.Point(6, 56)
			Me.CursorComboBox.Name = "CursorComboBox"
			Me.CursorComboBox.Size = New System.Drawing.Size(157, 21)
			Me.CursorComboBox.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.CursorComboBox.SelectedIndexChanged += new System.EventHandler(this.CursorComboBox_SelectedIndexChanged);
			' 
			' TooltipTextBox
			' 
			Me.TooltipTextBox.Location = New System.Drawing.Point(6, 65)
			Me.TooltipTextBox.Name = "TooltipTextBox"
			Me.TooltipTextBox.Size = New System.Drawing.Size(157, 18)
			Me.TooltipTextBox.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TooltipTextBox.TextChanged += new System.EventHandler(this.TooltipTextBox_TextChanged);
			' 
			' CursorChangeCheckBox
			' 
			Me.CursorChangeCheckBox.ButtonProperties.BorderOffset = 2
			Me.CursorChangeCheckBox.Location = New System.Drawing.Point(6, 16)
			Me.CursorChangeCheckBox.Name = "CursorChangeCheckBox"
			Me.CursorChangeCheckBox.Size = New System.Drawing.Size(152, 24)
			Me.CursorChangeCheckBox.TabIndex = 6
			Me.CursorChangeCheckBox.Text = "Enable cursor change"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.CursorChangeCheckBox.CheckedChanged += new System.EventHandler(this.CursorChangeCheckBox_CheckedChanged);
			' 
			' EnableTooltipChangeCheckBox
			' 
			Me.EnableTooltipChangeCheckBox.ButtonProperties.BorderOffset = 2
			Me.EnableTooltipChangeCheckBox.Location = New System.Drawing.Point(6, 17)
			Me.EnableTooltipChangeCheckBox.Name = "EnableTooltipChangeCheckBox"
			Me.EnableTooltipChangeCheckBox.Size = New System.Drawing.Size(157, 24)
			Me.EnableTooltipChangeCheckBox.TabIndex = 7
			Me.EnableTooltipChangeCheckBox.Text = "Enable tooltip change"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableTooltipChangeCheckBox.CheckedChanged += new System.EventHandler(this.EnableTooltipChangeCheckBox_CheckedChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(6, 89)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(157, 16)
			Me.label4.TabIndex = 8
			Me.label4.Text = "Auto pop delay (ms):"
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(6, 133)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(157, 16)
			Me.label5.TabIndex = 9
			Me.label5.Text = "Initial delay (ms):"
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(6, 177)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(157, 16)
			Me.label6.TabIndex = 10
			Me.label6.Text = "Reshow delay (ms):"
			' 
			' AutoPopDelayUpDown
			' 
			Me.AutoPopDelayUpDown.Increment = New Decimal(New Integer() { 10, 0, 0, 0})
			Me.AutoPopDelayUpDown.Location = New System.Drawing.Point(6, 109)
			Me.AutoPopDelayUpDown.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
			Me.AutoPopDelayUpDown.Name = "AutoPopDelayUpDown"
			Me.AutoPopDelayUpDown.Size = New System.Drawing.Size(157, 20)
			Me.AutoPopDelayUpDown.TabIndex = 11
			Me.AutoPopDelayUpDown.Value = New Decimal(New Integer() { 10, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AutoPopDelayUpDown.ValueChanged += new System.EventHandler(this.AutoPopDelayUpDown_ValueChanged);
			' 
			' InitialDelayUpDown
			' 
			Me.InitialDelayUpDown.Increment = New Decimal(New Integer() { 10, 0, 0, 0})
			Me.InitialDelayUpDown.Location = New System.Drawing.Point(6, 153)
			Me.InitialDelayUpDown.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
			Me.InitialDelayUpDown.Name = "InitialDelayUpDown"
			Me.InitialDelayUpDown.Size = New System.Drawing.Size(157, 20)
			Me.InitialDelayUpDown.TabIndex = 12
			Me.InitialDelayUpDown.Value = New Decimal(New Integer() { 10, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InitialDelayUpDown.ValueChanged += new System.EventHandler(this.InitialDelayUpDown_ValueChanged);
			' 
			' ReshowDelayUpDown
			' 
			Me.ReshowDelayUpDown.Increment = New Decimal(New Integer() { 10, 0, 0, 0})
			Me.ReshowDelayUpDown.Location = New System.Drawing.Point(6, 197)
			Me.ReshowDelayUpDown.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
			Me.ReshowDelayUpDown.Name = "ReshowDelayUpDown"
			Me.ReshowDelayUpDown.Size = New System.Drawing.Size(157, 20)
			Me.ReshowDelayUpDown.TabIndex = 13
			Me.ReshowDelayUpDown.Value = New Decimal(New Integer() { 40, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ReshowDelayUpDown.ValueChanged += new System.EventHandler(this.ReshowDelayUpDown_ValueChanged);
			' 
			' UseWindowRenderSurfaceCheckBox
			' 
			Me.UseWindowRenderSurfaceCheckBox.ButtonProperties.BorderOffset = 2
			Me.UseWindowRenderSurfaceCheckBox.Location = New System.Drawing.Point(11, 383)
			Me.UseWindowRenderSurfaceCheckBox.Name = "UseWindowRenderSurfaceCheckBox"
			Me.UseWindowRenderSurfaceCheckBox.Size = New System.Drawing.Size(120, 24)
			Me.UseWindowRenderSurfaceCheckBox.TabIndex = 16
			Me.UseWindowRenderSurfaceCheckBox.Text = "Render to window"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UseWindowRenderSurfaceCheckBox.CheckedChanged += new System.EventHandler(this.UseWindowRenderSurfaceCheckBox_CheckedChanged);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.CursorComboBox)
			Me.groupBox1.Controls.Add(Me.CursorChangeCheckBox)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Location = New System.Drawing.Point(5, 55)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(172, 89)
			Me.groupBox1.TabIndex = 17
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Mouse cursor"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.label2)
			Me.groupBox2.Controls.Add(Me.TooltipTextBox)
			Me.groupBox2.Controls.Add(Me.EnableTooltipChangeCheckBox)
			Me.groupBox2.Controls.Add(Me.label4)
			Me.groupBox2.Controls.Add(Me.label5)
			Me.groupBox2.Controls.Add(Me.label6)
			Me.groupBox2.Controls.Add(Me.AutoPopDelayUpDown)
			Me.groupBox2.Controls.Add(Me.InitialDelayUpDown)
			Me.groupBox2.Controls.Add(Me.ReshowDelayUpDown)
			Me.groupBox2.Location = New System.Drawing.Point(4, 148)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(174, 229)
			Me.groupBox2.TabIndex = 18
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Tooltips"
			' 
			' NTooltipAndCursorToolsUC
			' 
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.UseWindowRenderSurfaceCheckBox)
			Me.Controls.Add(Me.ChartObjectComboBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NTooltipAndCursorToolsUC"
			Me.Size = New System.Drawing.Size(180, 645)
			DirectCast(Me.AutoPopDelayUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.InitialDelayUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.ReshowDelayUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Tooltips and Cursor")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' init the values for the tooltip properties
			Dim tooltip As New NTooltipTool()
			AutoPopDelayUpDown.Value = tooltip.AutoPopDelay
			InitialDelayUpDown.Value = tooltip.InitialDelay
			ReshowDelayUpDown.Value = tooltip.ReshowDelay

			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' Add stripes for the left and the bottom axes
			Dim s1 As NAxisStripe = m_Chart.Axis(StandardAxis.PrimaryY).Stripes.Add(50, 60)
			Dim s2 As NAxisStripe = m_Chart.Axis(StandardAxis.PrimaryX).Stripes.Add(2, 3)
			s1.FillStyle = New NColorFillStyle(Color.CornflowerBlue)
			s1.SetShowAtWall(ChartWallType.Left, True)
			s2.FillStyle = New NColorFillStyle(Color.DarkOrange)

			' Create a bar series
			m_Bar = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)

			m_Bar.BarShape = BarShape.Bar
			m_Bar.Legend.Mode = SeriesLegendMode.DataPoints
			m_Bar.Values.Add(20.0)
			m_Bar.Values.Add(60.0)
			m_Bar.Values.Add(50.0)
			m_Bar.Values.Add(80.0)
			m_Bar.Values.Add(60.0)

			m_Bar.InteractivityStyles.Add(0, New NInteractivityStyle("Data item 0", CursorType.Default))
			m_Bar.InteractivityStyles.Add(1, New NInteractivityStyle("Data item 1", CursorType.Default))
			m_Bar.InteractivityStyles.Add(2, New NInteractivityStyle("Data item 2", CursorType.Default))
			m_Bar.InteractivityStyles.Add(3, New NInteractivityStyle("Data item 3", CursorType.Default))
			m_Bar.InteractivityStyles.Add(4, New NInteractivityStyle("Data item 4", CursorType.Default))

			' set some fill styles in the collection.
			Dim fillStyle As NFillStyle

			fillStyle = New NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant3, Color.Chocolate, Color.WhiteSmoke)
			m_Bar.FillStyles.Add(0, fillStyle)

			fillStyle = New NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant3, Color.Goldenrod, Color.WhiteSmoke)
			m_Bar.FillStyles.Add(1, fillStyle)

			fillStyle = New NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant3, Color.OliveDrab, Color.WhiteSmoke)
			m_Bar.FillStyles.Add(2, fillStyle)

			fillStyle = New NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant3, Color.SteelBlue, Color.WhiteSmoke)
			m_Bar.FillStyles.Add(3, fillStyle)

			fillStyle = New NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant3, Color.BlueViolet, Color.WhiteSmoke)
			m_Bar.FillStyles.Add(4, fillStyle)

			' init form controls
			EnableTooltipChangeCheckBox.Checked = True
			CursorChangeCheckBox.Checked = True

			ChartObjectComboBox.Items.Add("Background")
			ChartObjectComboBox.Items.Add("Back chart wall")
			ChartObjectComboBox.Items.Add("Left chart wall")
			ChartObjectComboBox.Items.Add("Floor chart wall")
			ChartObjectComboBox.Items.Add("Primary Y axis")
			ChartObjectComboBox.Items.Add("Primary X axis")
			ChartObjectComboBox.Items.Add("Horizontal stripe")
			ChartObjectComboBox.Items.Add("Vertical stripe")
			ChartObjectComboBox.Items.Add("Legend")
			ChartObjectComboBox.Items.Add("Data item 0")
			ChartObjectComboBox.Items.Add("Data item 1")
			ChartObjectComboBox.Items.Add("Data item 2")
			ChartObjectComboBox.Items.Add("Data item 3")
			ChartObjectComboBox.Items.Add("Data item 4")
			ChartObjectComboBox.SelectedIndex = 0

			CursorComboBox.FillFromEnum(GetType(CursorType))
			CursorComboBox.SelectedIndex = 0
		End Sub


		Private Sub UpdateChartInteractivity()
			If nChartControl1 Is Nothing Then
				Return
			End If

			nChartControl1.Controller.Tools.Clear()

			If EnableTooltipChangeCheckBox.Checked = True Then
				Dim tooltip As New NTooltipTool()

				tooltip.AutoPopDelay = CInt(Math.Truncate(AutoPopDelayUpDown.Value))
				tooltip.ReshowDelay = CInt(Math.Truncate(ReshowDelayUpDown.Value))
				tooltip.InitialDelay = CInt(Math.Truncate(InitialDelayUpDown.Value))

				nChartControl1.Controller.Tools.Add(tooltip)
			End If

			If CursorChangeCheckBox.Checked = True Then
				Dim cursorTool As New NCursorTool()
				nChartControl1.Controller.Tools.Add(cursorTool)
			End If
		End Sub

		Private Function GetCurrentInteractivityStyle() As NInteractivityStyle
			Dim interactivityStyle As NInteractivityStyle = Nothing

			Select Case ChartObjectComboBox.SelectedIndex
					' Background
				Case 0
					interactivityStyle = nChartControl1.InteractivityStyle
					' Back chart wall
				Case 1
					interactivityStyle = m_Chart.Wall(ChartWallType.Back).InteractivityStyle
					' Left chart wall
				Case 2
					interactivityStyle = m_Chart.Wall(ChartWallType.Left).InteractivityStyle
					''' Floor chart wall
				Case 3
					interactivityStyle = m_Chart.Wall(ChartWallType.Floor).InteractivityStyle
					' Primary Y axis
				Case 4
					interactivityStyle = m_Chart.Axis(StandardAxis.PrimaryY).InteractivityStyle
					' Primary X axis
				Case 5
					interactivityStyle = m_Chart.Axis(StandardAxis.PrimaryX).InteractivityStyle
					' Horizontal stripe
				Case 6
					interactivityStyle = CType(m_Chart.Axis(StandardAxis.PrimaryY).Stripes(0), NAxisStripe).InteractivityStyle
					' Vertical stripe
				Case 7
					interactivityStyle = CType(m_Chart.Axis(StandardAxis.PrimaryX).Stripes(0), NAxisStripe).InteractivityStyle
					' Legend
				Case 8
					interactivityStyle = CType(nChartControl1.Legends(0), NLegend).InteractivityStyle
				Case 9, 10, 11, 12, 13
					Dim series As NSeries = CType(m_Chart.Series(0), NSeries)
					interactivityStyle = DirectCast(series.InteractivityStyles(ChartObjectComboBox.SelectedIndex - 9), NInteractivityStyle)

			End Select

			Return interactivityStyle
		End Function

		Private Sub UpdateControls(ByVal bSave As Boolean)
			If m_bUpdating = True Then
				Return
			End If

			m_bUpdating = True

			Dim interactivityStyle As NInteractivityStyle = GetCurrentInteractivityStyle()

			If bSave Then
				interactivityStyle.Tooltip.Text = TooltipTextBox.Text
				interactivityStyle.Cursor.Type = CType(CursorComboBox.SelectedIndex, CursorType)
			Else
				TooltipTextBox.Text = interactivityStyle.Tooltip.Text
				CursorComboBox.SelectedIndex = CInt(interactivityStyle.Cursor.Type)
			End If

			m_bUpdating = False
		End Sub

		Private Sub EnableTooltipChangeCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EnableTooltipChangeCheckBox.CheckedChanged
			UpdateChartInteractivity()

			TooltipTextBox.Enabled = EnableTooltipChangeCheckBox.Checked
			AutoPopDelayUpDown.Enabled = EnableTooltipChangeCheckBox.Checked
			InitialDelayUpDown.Enabled = EnableTooltipChangeCheckBox.Checked
			ReshowDelayUpDown.Enabled = EnableTooltipChangeCheckBox.Checked
		End Sub

		Private Sub CursorChangeCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CursorChangeCheckBox.CheckedChanged
			UpdateChartInteractivity()

			CursorComboBox.Enabled = CursorChangeCheckBox.Checked
		End Sub

		Private Sub AutoPopDelayUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoPopDelayUpDown.ValueChanged
			UpdateChartInteractivity()
		End Sub

		Private Sub InitialDelayUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InitialDelayUpDown.ValueChanged
			UpdateChartInteractivity()
		End Sub

		Private Sub ReshowDelayUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReshowDelayUpDown.ValueChanged
			UpdateChartInteractivity()
		End Sub

		Private Sub ChartObjectComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChartObjectComboBox.SelectedIndexChanged
			UpdateControls(False)
		End Sub

		Private Sub TooltipTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TooltipTextBox.TextChanged
			UpdateControls(True)
		End Sub

		Private Sub CursorComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CursorComboBox.SelectedIndexChanged
			UpdateControls(True)
		End Sub

		Private Sub UseWindowRenderSurfaceCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UseWindowRenderSurfaceCheckBox.CheckedChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			If UseWindowRenderSurfaceCheckBox.Checked Then
				nChartControl1.Settings.RenderSurface = RenderSurface.Window
			Else
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap
			End If
		End Sub
	End Class
End Namespace
