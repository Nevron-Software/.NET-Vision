Imports Nevron.Chart
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NPointDropLines2DUC
		Inherits NExampleBaseUC

		Private m_Point As NPointSeries
		Private WithEvents ShowVerticalDropLinesCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents VerticalDropLinesOriginModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents VerticalDropLinesButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents VerticalDropLinesOriginUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label3 As Label
		Private label1 As Label
		Private WithEvents HorizontalDropLinesOriginUpDown As UI.WinForm.Controls.NNumericUpDown
		Private WithEvents HorizontalDropLinesButton As UI.WinForm.Controls.NButton
		Private WithEvents ShowHorizontalDropLinesCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents HorizontalDropLinesOriginModeComboBox As UI.WinForm.Controls.NComboBox
		Private label2 As Label
		Private label4 As Label
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
			Me.VerticalDropLinesOriginModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.ShowVerticalDropLinesCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.VerticalDropLinesButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.VerticalDropLinesOriginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.HorizontalDropLinesOriginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.HorizontalDropLinesButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShowHorizontalDropLinesCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.HorizontalDropLinesOriginModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			DirectCast(Me.VerticalDropLinesOriginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.HorizontalDropLinesOriginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' VerticalDropLinesOriginModeComboBox
			' 
			Me.VerticalDropLinesOriginModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.VerticalDropLinesOriginModeComboBox.ListProperties.DataSource = Nothing
			Me.VerticalDropLinesOriginModeComboBox.ListProperties.DisplayMember = ""
			Me.VerticalDropLinesOriginModeComboBox.Location = New System.Drawing.Point(75, 43)
			Me.VerticalDropLinesOriginModeComboBox.Name = "VerticalDropLinesOriginModeComboBox"
			Me.VerticalDropLinesOriginModeComboBox.Size = New System.Drawing.Size(101, 21)
			Me.VerticalDropLinesOriginModeComboBox.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.VerticalDropLinesOriginModeComboBox.SelectedIndexChanged += new System.EventHandler(this.VerticalDropLinesOriginModeComboBox_SelectedIndexChanged);
			' 
			' ShowVerticalDropLinesCheckBox
			' 
			Me.ShowVerticalDropLinesCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowVerticalDropLinesCheckBox.Location = New System.Drawing.Point(3, 16)
			Me.ShowVerticalDropLinesCheckBox.Name = "ShowVerticalDropLinesCheckBox"
			Me.ShowVerticalDropLinesCheckBox.Size = New System.Drawing.Size(172, 21)
			Me.ShowVerticalDropLinesCheckBox.TabIndex = 0
			Me.ShowVerticalDropLinesCheckBox.Text = "Show Vertical Drop Lines"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowVerticalDropLinesCheckBox.CheckedChanged += new System.EventHandler(this.ShowVerticalDropLinesCheckBox_CheckedChanged);
			' 
			' VerticalDropLinesButton
			' 
			Me.VerticalDropLinesButton.Location = New System.Drawing.Point(4, 96)
			Me.VerticalDropLinesButton.Name = "VerticalDropLinesButton"
			Me.VerticalDropLinesButton.Size = New System.Drawing.Size(172, 23)
			Me.VerticalDropLinesButton.TabIndex = 5
			Me.VerticalDropLinesButton.Text = "Vertical Drop Lines Stroke Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.VerticalDropLinesButton.Click += new System.EventHandler(this.VerticalDropLinesButton_Click);
			' 
			' VerticalDropLinesOriginUpDown
			' 
			Me.VerticalDropLinesOriginUpDown.DecimalPlaces = 5
			Me.VerticalDropLinesOriginUpDown.Location = New System.Drawing.Point(75, 67)
			Me.VerticalDropLinesOriginUpDown.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
			Me.VerticalDropLinesOriginUpDown.Minimum = New Decimal(New Integer() { 10000, 0, 0, -2147483648})
			Me.VerticalDropLinesOriginUpDown.Name = "VerticalDropLinesOriginUpDown"
			Me.VerticalDropLinesOriginUpDown.Size = New System.Drawing.Size(101, 20)
			Me.VerticalDropLinesOriginUpDown.TabIndex = 4
			Me.VerticalDropLinesOriginUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.VerticalDropLinesOriginUpDown.ValueChanged += new System.EventHandler(this.VericalDropLinesOriginUpDown_ValueChanged);
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(4, 51)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(67, 13)
			Me.label3.TabIndex = 1
			Me.label3.Text = "Origin Mode:"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(4, 74)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(37, 13)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Origin:"
			' 
			' HorizontalDropLinesOriginUpDown
			' 
			Me.HorizontalDropLinesOriginUpDown.DecimalPlaces = 5
			Me.HorizontalDropLinesOriginUpDown.Location = New System.Drawing.Point(77, 190)
			Me.HorizontalDropLinesOriginUpDown.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
			Me.HorizontalDropLinesOriginUpDown.Minimum = New Decimal(New Integer() { 10000, 0, 0, -2147483648})
			Me.HorizontalDropLinesOriginUpDown.Name = "HorizontalDropLinesOriginUpDown"
			Me.HorizontalDropLinesOriginUpDown.Size = New System.Drawing.Size(101, 20)
			Me.HorizontalDropLinesOriginUpDown.TabIndex = 10
			Me.HorizontalDropLinesOriginUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HorizontalDropLinesOriginUpDown.ValueChanged += new System.EventHandler(this.HorizontalDropLinesOriginUpDown_ValueChanged);
			' 
			' HorizontalDropLinesButton
			' 
			Me.HorizontalDropLinesButton.Location = New System.Drawing.Point(6, 219)
			Me.HorizontalDropLinesButton.Name = "HorizontalDropLinesButton"
			Me.HorizontalDropLinesButton.Size = New System.Drawing.Size(172, 23)
			Me.HorizontalDropLinesButton.TabIndex = 11
			Me.HorizontalDropLinesButton.Text = "Horizontal Drop Lines Stroke Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HorizontalDropLinesButton.Click += new System.EventHandler(this.HorizontalDropLinesButton_Click);
			' 
			' ShowHorizontalDropLinesCheckBox
			' 
			Me.ShowHorizontalDropLinesCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowHorizontalDropLinesCheckBox.Location = New System.Drawing.Point(5, 139)
			Me.ShowHorizontalDropLinesCheckBox.Name = "ShowHorizontalDropLinesCheckBox"
			Me.ShowHorizontalDropLinesCheckBox.Size = New System.Drawing.Size(172, 21)
			Me.ShowHorizontalDropLinesCheckBox.TabIndex = 6
			Me.ShowHorizontalDropLinesCheckBox.Text = "Show Horizontal Drop Lines"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowHorizontalDropLinesCheckBox.CheckedChanged += new System.EventHandler(this.ShowHorizontalDropLinesCheckBox_CheckedChanged);
			' 
			' HorizontalDropLinesOriginModeComboBox
			' 
			Me.HorizontalDropLinesOriginModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.HorizontalDropLinesOriginModeComboBox.ListProperties.DataSource = Nothing
			Me.HorizontalDropLinesOriginModeComboBox.ListProperties.DisplayMember = ""
			Me.HorizontalDropLinesOriginModeComboBox.Location = New System.Drawing.Point(77, 166)
			Me.HorizontalDropLinesOriginModeComboBox.Name = "HorizontalDropLinesOriginModeComboBox"
			Me.HorizontalDropLinesOriginModeComboBox.Size = New System.Drawing.Size(101, 21)
			Me.HorizontalDropLinesOriginModeComboBox.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HorizontalDropLinesOriginModeComboBox.SelectedIndexChanged += new System.EventHandler(this.HorizontalDropLinesOriginModeComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(4, 174)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(67, 13)
			Me.label2.TabIndex = 7
			Me.label2.Text = "Origin Mode:"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(4, 197)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(37, 13)
			Me.label4.TabIndex = 9
			Me.label4.Text = "Origin:"
			' 
			' NPointDropLines2DUC
			' 
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.HorizontalDropLinesOriginUpDown)
			Me.Controls.Add(Me.HorizontalDropLinesButton)
			Me.Controls.Add(Me.ShowHorizontalDropLinesCheckBox)
			Me.Controls.Add(Me.HorizontalDropLinesOriginModeComboBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.VerticalDropLinesOriginUpDown)
			Me.Controls.Add(Me.VerticalDropLinesButton)
			Me.Controls.Add(Me.ShowVerticalDropLinesCheckBox)
			Me.Controls.Add(Me.VerticalDropLinesOriginModeComboBox)
			Me.Name = "NPointDropLines2DUC"
			Me.Size = New System.Drawing.Size(180, 320)
			DirectCast(Me.VerticalDropLinesOriginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.HorizontalDropLinesOriginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("2D Point Chart Droplines")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' setup point series
			m_Point = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			m_Point.Name = "Point Series"
			m_Point.InflateMargins = True
			m_Point.UseXValues = True
			m_Point.Size = New NLength(10, NGraphicsUnit.Point)
			m_Point.DataLabelStyle.Visible = False

			For i As Integer = 0 To 359 Step 5
				Dim value As Double = Math.Sin(NMath.Degree2Rad * i) * 20

				m_Point.XValues.Add(i)
				m_Point.Values.Add(value)
			Next i

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' init form controls
			ShowVerticalDropLinesCheckBox.Checked = True
			HorizontalDropLinesOriginUpDown.Value = 0
			VerticalDropLinesOriginModeComboBox.FillFromEnum(GetType(DropLineOriginMode))
			VerticalDropLinesOriginModeComboBox.SelectedIndex = CInt(DropLineOriginMode.ScaleMin)

			ShowHorizontalDropLinesCheckBox.Checked = True
			VerticalDropLinesOriginUpDown.Value = 0
			HorizontalDropLinesOriginModeComboBox.FillFromEnum(GetType(DropLineOriginMode))
			HorizontalDropLinesOriginModeComboBox.SelectedIndex = CInt(DropLineOriginMode.ScaleMin)
		End Sub

		Private Sub ShowVerticalDropLinesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowVerticalDropLinesCheckBox.CheckedChanged
			If m_Point Is Nothing Then
				Return
			End If

			m_Point.ShowVerticalDropLines = ShowVerticalDropLinesCheckBox.Checked
			nChartControl1.Refresh()

			VerticalDropLinesOriginModeComboBox.Enabled = ShowVerticalDropLinesCheckBox.Checked
			VerticalDropLinesOriginUpDown.Enabled = ShowVerticalDropLinesCheckBox.Checked
			VerticalDropLinesButton.Enabled = ShowVerticalDropLinesCheckBox.Checked
		End Sub

		Private Sub VerticalDropLinesOriginModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles VerticalDropLinesOriginModeComboBox.SelectedIndexChanged
			If m_Point Is Nothing Then
				Return
			End If

			m_Point.VerticalDropLineOriginMode = CType(VerticalDropLinesOriginModeComboBox.SelectedIndex, DropLineOriginMode)
			nChartControl1.Refresh()
		End Sub

		Private Sub VericalDropLinesOriginUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles VerticalDropLinesOriginUpDown.ValueChanged
			If m_Point Is Nothing Then
				Return
			End If

			m_Point.VerticalDropLineOrigin = CDbl(VerticalDropLinesOriginUpDown.Value)
			nChartControl1.Refresh()
		End Sub

		Private Sub VerticalDropLinesButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles VerticalDropLinesButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Point.VerticalDropLinesStrokeStyle, strokeStyleResult) Then
				m_Point.VerticalDropLinesStrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub ShowHorizontalDropLinesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowHorizontalDropLinesCheckBox.CheckedChanged
			If m_Point Is Nothing Then
				Return
			End If

			m_Point.ShowHorizontalDropLines = ShowHorizontalDropLinesCheckBox.Checked
			nChartControl1.Refresh()

			HorizontalDropLinesOriginModeComboBox.Enabled = ShowHorizontalDropLinesCheckBox.Checked
			HorizontalDropLinesOriginUpDown.Enabled = ShowHorizontalDropLinesCheckBox.Checked
			HorizontalDropLinesButton.Enabled = ShowHorizontalDropLinesCheckBox.Checked
		End Sub

		Private Sub HorizontalDropLinesOriginModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles HorizontalDropLinesOriginModeComboBox.SelectedIndexChanged
			If m_Point Is Nothing Then
				Return
			End If

			m_Point.HorizontalDropLineOriginMode = CType(HorizontalDropLinesOriginModeComboBox.SelectedIndex, DropLineOriginMode)
			nChartControl1.Refresh()
		End Sub

		Private Sub HorizontalDropLinesOriginUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles HorizontalDropLinesOriginUpDown.ValueChanged
			If m_Point Is Nothing Then
				Return
			End If

			m_Point.HorizontalDropLineOrigin = CDbl(HorizontalDropLinesOriginUpDown.Value)
			nChartControl1.Refresh()
		End Sub

		Private Sub HorizontalDropLinesButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles HorizontalDropLinesButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Point.HorizontalDropLinesStrokeStyle, strokeStyleResult) Then
				m_Point.HorizontalDropLinesStrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace