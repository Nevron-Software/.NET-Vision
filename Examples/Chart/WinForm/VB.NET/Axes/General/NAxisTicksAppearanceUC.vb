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
	Public Class NAxisTicksAppearanceUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private colorDialog1 As Nevron.UI.WinForm.Controls.NColorDialog
		Private WithEvents TickFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private label4 As Label
		Private WithEvents TickShapeComboBox As NComboBox
		Private WithEvents TickStrokeStyleButton As UI.WinForm.Controls.NButton
		Private label5 As Label
		Private WithEvents TickWidthScrollBar As UI.WinForm.Controls.NHScrollBar
		Private label7 As Label
		Private WithEvents TickHeightScrollBar As UI.WinForm.Controls.NHScrollBar
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
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(NAxisTicksAppearanceUC))
			Me.colorDialog1 = New Nevron.UI.WinForm.Controls.NColorDialog()
			Me.TickFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label4 = New System.Windows.Forms.Label()
			Me.TickShapeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.TickStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label5 = New System.Windows.Forms.Label()
			Me.TickWidthScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label7 = New System.Windows.Forms.Label()
			Me.TickHeightScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.SuspendLayout()
			' 
			' colorDialog1
			' 
			Me.colorDialog1.ClientSize = New System.Drawing.Size(396, 324)
			Me.colorDialog1.Color = System.Drawing.Color.Empty
			Me.colorDialog1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.colorDialog1.Icon = (DirectCast(resources.GetObject("colorDialog1.Icon"), System.Drawing.Icon))
			Me.colorDialog1.Location = New System.Drawing.Point(88, 88)
			Me.colorDialog1.MaximizeBox = False
			Me.colorDialog1.MinimizeBox = False
			Me.colorDialog1.Name = "colorDialog1"
			Me.colorDialog1.ShowCaptionImage = False
			Me.colorDialog1.ShowInTaskbar = False
			Me.colorDialog1.Sizable = False
			Me.colorDialog1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.colorDialog1.Text = "Edit Color"
			Me.colorDialog1.Visible = False
			' 
			' TickFillStyleButton
			' 
			Me.TickFillStyleButton.Location = New System.Drawing.Point(10, 70)
			Me.TickFillStyleButton.Name = "TickFillStyleButton"
			Me.TickFillStyleButton.Size = New System.Drawing.Size(125, 22)
			Me.TickFillStyleButton.TabIndex = 3
			Me.TickFillStyleButton.Text = "Tick Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TickFillStyleButton.Click += new System.EventHandler(this.TickFillStyleButton_Click);
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(7, 19)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(65, 13)
			Me.label4.TabIndex = 20
			Me.label4.Text = "Tick Shape:"
			' 
			' TickShapeComboBox
			' 
			Me.TickShapeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.TickShapeComboBox.ListProperties.DataSource = Nothing
			Me.TickShapeComboBox.ListProperties.DisplayMember = ""
			Me.TickShapeComboBox.Location = New System.Drawing.Point(10, 36)
			Me.TickShapeComboBox.Name = "TickShapeComboBox"
			Me.TickShapeComboBox.Size = New System.Drawing.Size(125, 21)
			Me.TickShapeComboBox.TabIndex = 21
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TickShapeComboBox.SelectedIndexChanged += new System.EventHandler(this.TickShapeComboBox_SelectedIndexChanged);
			' 
			' TickStrokeStyleButton
			' 
			Me.TickStrokeStyleButton.Location = New System.Drawing.Point(10, 98)
			Me.TickStrokeStyleButton.Name = "TickStrokeStyleButton"
			Me.TickStrokeStyleButton.Size = New System.Drawing.Size(125, 22)
			Me.TickStrokeStyleButton.TabIndex = 22
			Me.TickStrokeStyleButton.Text = "Tick Stroke Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TickStrokeStyleButton.Click += new System.EventHandler(this.TickStrokeStyleButton_Click);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(10, 146)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(116, 19)
			Me.label5.TabIndex = 23
			Me.label5.Text = "Tick Width:"
			' 
			' TickWidthScrollBar
			' 
			Me.TickWidthScrollBar.LargeChange = 2
			Me.TickWidthScrollBar.Location = New System.Drawing.Point(10, 166)
			Me.TickWidthScrollBar.Maximum = 20
			Me.TickWidthScrollBar.MinimumSize = New System.Drawing.Size(34, 17)
			Me.TickWidthScrollBar.Name = "TickWidthScrollBar"
			Me.TickWidthScrollBar.Size = New System.Drawing.Size(125, 17)
			Me.TickWidthScrollBar.TabIndex = 24
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TickWidthScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.TickWidthScrollBar_ValueChanged);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(10, 190)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(116, 19)
			Me.label7.TabIndex = 25
			Me.label7.Text = "Tick Height:"
			' 
			' TickHeightScrollBar
			' 
			Me.TickHeightScrollBar.LargeChange = 2
			Me.TickHeightScrollBar.Location = New System.Drawing.Point(10, 211)
			Me.TickHeightScrollBar.Maximum = 20
			Me.TickHeightScrollBar.MinimumSize = New System.Drawing.Size(34, 17)
			Me.TickHeightScrollBar.Name = "TickHeightScrollBar"
			Me.TickHeightScrollBar.Size = New System.Drawing.Size(125, 17)
			Me.TickHeightScrollBar.TabIndex = 26
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TickHeightScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.TickHeightScrollBar_ValueChanged);
			' 
			' NAxisTicksAppearanceUC
			' 
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.TickHeightScrollBar)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.TickWidthScrollBar)
			Me.Controls.Add(Me.TickStrokeStyleButton)
			Me.Controls.Add(Me.TickShapeComboBox)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.TickFillStyleButton)
			Me.Name = "NAxisTicksAppearanceUC"
			Me.Size = New System.Drawing.Size(150, 264)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Axis Ticks Appearance")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' turn off the legend
			nChartControl1.Legends(0).Mode = LegendMode.Disabled

			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.OuterMajorTickStyle.FillStyle = New NColorFillStyle(Color.Red)

			' hide all tick except the outer major just to demonstrate the shape / fill / stroke control
			linearScale.InnerMajorTickStyle.Visible = False
			linearScale.InnerMinorTickStyle.Visible = False
			linearScale.OuterMinorTickStyle.Visible = False

			' add interlaced stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			Dim bar As NBarSeries = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Values.FillRandom(Random, 5)
			bar.FillStyle = New NColorFillStyle(Color.DarkOrchid)
			bar.DataLabelStyle.Format = "<value>"
			bar.Name = "Bars"

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			TickShapeComboBox.FillFromEnum(GetType(ScaleTickShape))
			TickShapeComboBox.SelectedIndex = CInt(ScaleTickShape.Triangle)

			TickWidthScrollBar.Value = 4
			TickHeightScrollBar.Value = 8
		End Sub

		Private Sub TickShapeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TickShapeComboBox.SelectedIndexChanged
			If m_Chart Is Nothing Then
				Return
			End If

'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scale_Renamed.OuterMajorTickStyle.Shape = CType(TickShapeComboBox.SelectedIndex, ScaleTickShape)

			nChartControl1.Refresh()
		End Sub

		Private Sub TickFillStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TickFillStyleButton.Click
			If m_Chart Is Nothing Then
				Return
			End If

'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			Dim fillStyle As NFillStyle = Nothing

			If NFillStyleTypeEditorNoAutomatic.Edit(scale_Renamed.OuterMajorTickStyle.FillStyle, False, fillStyle) Then
				scale_Renamed.OuterMajorTickStyle.FillStyle = fillStyle
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub TickStrokeStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TickStrokeStyleButton.Click
			If m_Chart Is Nothing Then
				Return
			End If

'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			Dim strokeStyle As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditorNoAutomatic.Edit(scale_Renamed.OuterMajorTickStyle.LineStyle, False, strokeStyle) Then
				scale_Renamed.OuterMajorTickStyle.LineStyle = strokeStyle
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub TickWidthScrollBar_ValueChanged(ByVal sender As Object, ByVal e As ScrollBarEventArgs) Handles TickWidthScrollBar.ValueChanged
			If m_Chart Is Nothing Then
				Return
			End If

'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scale_Renamed.OuterMajorTickStyle.Width = New NLength(TickWidthScrollBar.Value)

			nChartControl1.Refresh()
		End Sub

		Private Sub TickHeightScrollBar_ValueChanged(ByVal sender As Object, ByVal e As ScrollBarEventArgs) Handles TickHeightScrollBar.ValueChanged
			If m_Chart Is Nothing Then
				Return
			End If

'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scale_Renamed.OuterMajorTickStyle.Length = New NLength(TickHeightScrollBar.Value)

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
