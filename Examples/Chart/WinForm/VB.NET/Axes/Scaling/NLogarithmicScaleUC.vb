Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Resources
Imports Nevron.Dom
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NLogarithmicScaleUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Line As NLineSeries
		Private m_Updating As Boolean
		Private WithEvents RoundToTickMin As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents RoundToTickMax As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents LabelFormatCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private UseCustomMax As Nevron.UI.WinForm.Controls.NCheckBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label10 As System.Windows.Forms.Label
		Private MaxTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents LogarithBaseUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			m_Updating = True

			InitializeComponent()

			LabelFormatCombo.Items.Add("Default")
			LabelFormatCombo.Items.Add("Scientific")
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
			Me.label10 = New System.Windows.Forms.Label()
			Me.LabelFormatCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.UseCustomMax = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.MaxTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.RoundToTickMin = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.RoundToTickMax = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.LogarithBaseUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			DirectCast(Me.LogarithBaseUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(168, -16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(88, 16)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Logarihm Base:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(16, 14)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(88, 16)
			Me.label2.TabIndex = 6
			Me.label2.Text = "Logarithm Base:"
			' 
			' label10
			' 
			Me.label10.Location = New System.Drawing.Point(16, 71)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(80, 16)
			Me.label10.TabIndex = 7
			Me.label10.Text = "Label Format:"
			' 
			' LabelFormatCombo
			' 
			Me.LabelFormatCombo.Location = New System.Drawing.Point(16, 93)
			Me.LabelFormatCombo.Name = "LabelFormatCombo"
			Me.LabelFormatCombo.Size = New System.Drawing.Size(153, 21)
			Me.LabelFormatCombo.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LabelFormatCombo.SelectedIndexChanged += new System.EventHandler(this.LabelFormatCombo_SelectedIndexChanged);
			' 
			' UseCustomMax
			' 
			Me.UseCustomMax.Location = New System.Drawing.Point(32, 464)
			Me.UseCustomMax.Name = "UseCustomMax"
			Me.UseCustomMax.Size = New System.Drawing.Size(113, 21)
			Me.UseCustomMax.TabIndex = 14
			Me.UseCustomMax.Text = "Use Custom Max"
			' 
			' MaxTextBox
			' 
			Me.MaxTextBox.ErrorMessage = Nothing
			Me.MaxTextBox.Location = New System.Drawing.Point(34, 494)
			Me.MaxTextBox.Name = "MaxTextBox"
			Me.MaxTextBox.Size = New System.Drawing.Size(96, 18)
			Me.MaxTextBox.TabIndex = 15
			Me.MaxTextBox.Text = "100"
			' 
			' RoundToTickMin
			' 
			Me.RoundToTickMin.Location = New System.Drawing.Point(17, 131)
			Me.RoundToTickMin.Name = "RoundToTickMin"
			Me.RoundToTickMin.Size = New System.Drawing.Size(130, 19)
			Me.RoundToTickMin.TabIndex = 16
			Me.RoundToTickMin.Text = "Round To Tick Min"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RoundToTickMin.CheckedChanged += new System.EventHandler(this.RoundToTickMin_CheckedChanged);
			' 
			' RoundToTickMax
			' 
			Me.RoundToTickMax.Location = New System.Drawing.Point(17, 155)
			Me.RoundToTickMax.Name = "RoundToTickMax"
			Me.RoundToTickMax.Size = New System.Drawing.Size(128, 19)
			Me.RoundToTickMax.TabIndex = 17
			Me.RoundToTickMax.Text = "Round To Tick Max"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RoundToTickMax.CheckedChanged += new System.EventHandler(this.RoundToTickMax_CheckedChanged);
			' 
			' LogarithBaseUpDown
			' 
			Me.LogarithBaseUpDown.Location = New System.Drawing.Point(19, 38)
			Me.LogarithBaseUpDown.Maximum = New System.Decimal(New Integer() { 30, 0, 0, 0})
			Me.LogarithBaseUpDown.Minimum = New System.Decimal(New Integer() { 2, 0, 0, 0})
			Me.LogarithBaseUpDown.Name = "LogarithBaseUpDown"
			Me.LogarithBaseUpDown.Size = New System.Drawing.Size(149, 20)
			Me.LogarithBaseUpDown.TabIndex = 18
			Me.LogarithBaseUpDown.Value = New System.Decimal(New Integer() { 10, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LogarithBaseUpDown.ValueChanged += new System.EventHandler(this.LogarithBaseUpDown_ValueChanged);
			' 
			' NLogarithmicScaleUC
			' 
			Me.Controls.Add(Me.LogarithBaseUpDown)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.RoundToTickMin)
			Me.Controls.Add(Me.RoundToTickMax)
			Me.Controls.Add(Me.label10)
			Me.Controls.Add(Me.LabelFormatCombo)
			Me.Controls.Add(Me.MaxTextBox)
			Me.Controls.Add(Me.UseCustomMax)
			Me.Name = "NLogarithmicScaleUC"
			Me.Size = New System.Drawing.Size(191, 466)
			DirectCast(Me.LogarithBaseUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Logarithmic Scale")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Fit

			m_Chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))
			m_Chart.BoundsMode = BoundsMode.Stretch

			m_Chart.Axis(StandardAxis.Depth).Visible = False

			Dim logarithmicScale As New NLogarithmicScaleConfigurator()
			logarithmicScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			logarithmicScale.MinorGridStyle.LineStyle.Pattern = LinePattern.Dot
			logarithmicScale.MinorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			logarithmicScale.MinorTickCount = 3
			logarithmicScale.MajorTickMode = MajorTickMode.CustomStep

			' add interlaced stripe 
			Dim stripStyle As New NScaleStripStyle()
			stripStyle.FillStyle = New NColorFillStyle(Color.Beige)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			logarithmicScale.StripStyles.Add(stripStyle)

			logarithmicScale.CustomStep = 1

			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = logarithmicScale

			m_Line = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line.Legend.Mode = SeriesLegendMode.None
			m_Line.InflateMargins = False
			m_Line.BorderStyle.Color = Color.Navy
			m_Line.MarkerStyle.Visible = True
			m_Line.MarkerStyle.PointShape = PointShape.Cylinder
			m_Line.MarkerStyle.Width = New NLength(0.7F, NRelativeUnit.ParentPercentage)
			m_Line.MarkerStyle.Height = New NLength(0.7F, NRelativeUnit.ParentPercentage)
			m_Line.MarkerStyle.AutoDepth = True
			m_Line.DataLabelStyle.Format = "<value>"

			m_Line.Values.Add(12)
			m_Line.Values.Add(100)
			m_Line.Values.Add(250)
			m_Line.Values.Add(500)
			m_Line.Values.Add(1500)
			m_Line.Values.Add(5500)
			m_Line.Values.Add(9090)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			LabelFormatCombo.SelectedIndex = 0
			RoundToTickMin.Checked = True
			RoundToTickMax.Checked = True

			m_Updating = False
		End Sub

		Private Sub UpdateScale()
			If m_Updating Then
				Return
			End If

			Dim axis As NAxis = m_Chart.Axis(StandardAxis.PrimaryY)
			Dim logarithmicScale As NLogarithmicScaleConfigurator = TryCast(axis.ScaleConfigurator, NLogarithmicScaleConfigurator)

			' check if null (user may have changed the scale with the editor)
			If logarithmicScale Is Nothing Then
				Return
			End If

			logarithmicScale.LogarithmBase = CDbl(LogarithBaseUpDown.Value)

			Select Case LabelFormatCombo.SelectedIndex
				Case 0
					logarithmicScale.LabelValueFormatter = New NNumericValueFormatter(NumericValueFormat.General)

				Case 1
					logarithmicScale.LabelValueFormatter = New NNumericValueFormatter(NumericValueFormat.Scientific)
			End Select

			logarithmicScale.RoundToTickMax = RoundToTickMax.Checked
			logarithmicScale.RoundToTickMin = RoundToTickMin.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub LogarithBaseUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LogarithBaseUpDown.ValueChanged
			UpdateScale()
		End Sub

		Private Sub LabelFormatCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LabelFormatCombo.SelectedIndexChanged
			UpdateScale()
		End Sub

		Private Sub RoundToTickMin_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RoundToTickMin.CheckedChanged
			UpdateScale()
		End Sub

		Private Sub RoundToTickMax_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RoundToTickMax.CheckedChanged
			UpdateScale()
		End Sub
	End Class
End Namespace
