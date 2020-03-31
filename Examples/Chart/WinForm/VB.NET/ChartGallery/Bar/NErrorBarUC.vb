Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports Nevron.UI
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NErrorBarUC
		Inherits NExampleBaseUC

		Private label2 As System.Windows.Forms.Label
		Private WithEvents ShowLowerErrorCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowUpperErrorCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents WidthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents ErrorStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents Enable3DCheckBox As UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.IContainer = Nothing

		Private m_BarSeries As NBarSeries
		Private m_Chart As NChart


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


		#Region "Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.ShowLowerErrorCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowUpperErrorCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.WidthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.ErrorStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.Enable3DCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' ShowLowerErrorCheckBox
			' 
			Me.ShowLowerErrorCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowLowerErrorCheckBox.Location = New System.Drawing.Point(8, 31)
			Me.ShowLowerErrorCheckBox.Name = "ShowLowerErrorCheckBox"
			Me.ShowLowerErrorCheckBox.Size = New System.Drawing.Size(163, 24)
			Me.ShowLowerErrorCheckBox.TabIndex = 1
			Me.ShowLowerErrorCheckBox.Text = "Show Lower Error"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowLowerErrorCheckBox.CheckedChanged += new System.EventHandler(this.ShowLowerErrorCheckBox_CheckedChanged);
			' 
			' ShowUpperErrorCheckBox
			' 
			Me.ShowUpperErrorCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowUpperErrorCheckBox.Location = New System.Drawing.Point(8, 8)
			Me.ShowUpperErrorCheckBox.Name = "ShowUpperErrorCheckBox"
			Me.ShowUpperErrorCheckBox.Size = New System.Drawing.Size(163, 21)
			Me.ShowUpperErrorCheckBox.TabIndex = 0
			Me.ShowUpperErrorCheckBox.Text = "Show Upper Error"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowUpperErrorCheckBox.CheckedChanged += new System.EventHandler(this.ShowUpperErrorCheckBox_CheckedChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 122)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(163, 16)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Error Width %:"
			' 
			' WidthScroll
			' 
			Me.WidthScroll.Location = New System.Drawing.Point(8, 138)
			Me.WidthScroll.Maximum = 110
			Me.WidthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.WidthScroll.Name = "WidthScroll"
			Me.WidthScroll.Size = New System.Drawing.Size(163, 16)
			Me.WidthScroll.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WidthScroll_ValueChanged);
			' 
			' ErrorStrokeStyleButton
			' 
			Me.ErrorStrokeStyleButton.Location = New System.Drawing.Point(8, 89)
			Me.ErrorStrokeStyleButton.Name = "ErrorStrokeStyleButton"
			Me.ErrorStrokeStyleButton.Size = New System.Drawing.Size(163, 24)
			Me.ErrorStrokeStyleButton.TabIndex = 3
			Me.ErrorStrokeStyleButton.Text = "Error Stroke Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ErrorStrokeStyleButton.Click += new System.EventHandler(this.ErrorStrokeStyleButton_Click);
			' 
			' Enable3DCheckBox
			' 
			Me.Enable3DCheckBox.ButtonProperties.BorderOffset = 2
			Me.Enable3DCheckBox.Location = New System.Drawing.Point(8, 57)
			Me.Enable3DCheckBox.Name = "Enable3DCheckBox"
			Me.Enable3DCheckBox.Size = New System.Drawing.Size(163, 24)
			Me.Enable3DCheckBox.TabIndex = 2
			Me.Enable3DCheckBox.Text = "Enable 3D"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Enable3DCheckBox.CheckedChanged += new System.EventHandler(this.Enable3DCheckBox_CheckedChanged);
			' 
			' NErrorBarUC
			' 
			Me.Controls.Add(Me.Enable3DCheckBox)
			Me.Controls.Add(Me.ShowLowerErrorCheckBox)
			Me.Controls.Add(Me.ShowUpperErrorCheckBox)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.WidthScroll)
			Me.Controls.Add(Me.ErrorStrokeStyleButton)
			Me.Name = "NErrorBarUC"
			Me.Size = New System.Drawing.Size(180, 505)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' create a title
			Dim title As New NLabel("Error Bar Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure chart
			Dim chart As NChart = nChartControl1.Charts(0)
			m_Chart = chart
			chart.Axis(StandardAxis.Depth).Visible = False

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' setup a bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar Series"
			bar.DataLabelStyle.Visible = False
			bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			bar.ShadowStyle.Type = ShadowType.GaussianBlur
			bar.ShadowStyle.Offset = New NPointL(2, 2)
			bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0)
			bar.ShadowStyle.FadeLength = New NLength(5)
			bar.HasBottomEdge = False

			' add some data to the bar series
			bar.Values.Add(15)
			bar.UpperErrors.Add(2)
			bar.LowerErrors.Add(1)

			bar.Values.Add(21)
			bar.UpperErrors.Add(2.4)
			bar.LowerErrors.Add(1.3)

			bar.Values.Add(23)
			bar.UpperErrors.Add(3.2)
			bar.LowerErrors.Add(1.7)

			bar.Values.Add(27)
			bar.UpperErrors.Add(1.4)
			bar.LowerErrors.Add(2.5)

			bar.Values.Add(29)
			bar.UpperErrors.Add(4.0)
			bar.LowerErrors.Add(2.0)

			bar.Values.Add(26)
			bar.UpperErrors.Add(2.1)
			bar.LowerErrors.Add(1.6)

			m_BarSeries = bar

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' init form controls
			ShowUpperErrorCheckBox.Checked = True
			ShowLowerErrorCheckBox.Checked = True
			WidthScroll.Value = CInt(Math.Truncate(bar.ErrorWidthPercent))
		End Sub

		Private Sub ShowUpperErrorCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowUpperErrorCheckBox.CheckedChanged
			m_BarSeries.ShowUpperError = ShowUpperErrorCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowLowerErrorCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowLowerErrorCheckBox.CheckedChanged
			m_BarSeries.ShowLowerError = ShowLowerErrorCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub Enable3DCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Enable3DCheckBox.CheckedChanged
			m_Chart.Enable3D = Enable3DCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub ErrorStrokeStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ErrorStrokeStyleButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_BarSeries.ErrorStrokeStyle, strokeStyleResult) Then
				m_BarSeries.ErrorStrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub WidthScroll_ValueChanged(ByVal sender As Object, ByVal e As UI.WinForm.Controls.ScrollBarEventArgs) Handles WidthScroll.ValueChanged
			m_BarSeries.ErrorWidthPercent = WidthScroll.Value
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace