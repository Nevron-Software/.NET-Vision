Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Text
Imports System.Globalization
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.Functions


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NPowerCumulativeExpAverageUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bar As NBarSeries
		Private m_Line As NLineSeries
		Private m_FuncCalculator As NFunctionCalculator
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private m_ExpressionLabel As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents m_FunctionCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents m_BtnData As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_PowerScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents m_ExpWeightScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			m_FuncCalculator = New NFunctionCalculator()
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
			Me.m_ExpressionLabel = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.m_FunctionCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.m_BtnData = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_PowerScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.m_ExpWeightScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' m_ExpressionLabel
			' 
			Me.m_ExpressionLabel.Location = New System.Drawing.Point(6, 88)
			Me.m_ExpressionLabel.Name = "m_ExpressionLabel"
			Me.m_ExpressionLabel.ReadOnly = True
			Me.m_ExpressionLabel.Size = New System.Drawing.Size(167, 18)
			Me.m_ExpressionLabel.TabIndex = 7
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(6, 72)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(167, 16)
			Me.label2.TabIndex = 6
			Me.label2.Text = "Expression:"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(6, 13)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(167, 16)
			Me.label1.TabIndex = 5
			Me.label1.Text = "Function:"
			' 
			' m_FunctionCombo
			' 
			Me.m_FunctionCombo.ListProperties.CheckBoxDataMember = ""
			Me.m_FunctionCombo.ListProperties.DataSource = Nothing
			Me.m_FunctionCombo.ListProperties.DisplayMember = ""
			Me.m_FunctionCombo.Location = New System.Drawing.Point(6, 37)
			Me.m_FunctionCombo.Name = "m_FunctionCombo"
			Me.m_FunctionCombo.Size = New System.Drawing.Size(167, 21)
			Me.m_FunctionCombo.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_FunctionCombo.SelectedIndexChanged += new System.EventHandler(this.FunctionCombo_SelectedIndexChanged);
			' 
			' m_BtnData
			' 
			Me.m_BtnData.Location = New System.Drawing.Point(6, 240)
			Me.m_BtnData.Name = "m_BtnData"
			Me.m_BtnData.Size = New System.Drawing.Size(167, 24)
			Me.m_BtnData.TabIndex = 8
			Me.m_BtnData.Text = "New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_BtnData.Click += new System.EventHandler(this.BtnData_Click);
			' 
			' m_PowerScroll
			' 
			Me.m_PowerScroll.LargeChange = 1
			Me.m_PowerScroll.Location = New System.Drawing.Point(6, 144)
			Me.m_PowerScroll.Maximum = 30
			Me.m_PowerScroll.Minimum = -30
			Me.m_PowerScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.m_PowerScroll.Name = "m_PowerScroll"
			Me.m_PowerScroll.Size = New System.Drawing.Size(167, 17)
			Me.m_PowerScroll.TabIndex = 9
			Me.m_PowerScroll.Value = 20
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_PowerScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.PowerScroll_Scroll);
			' 
			' m_ExpWeightScroll
			' 
			Me.m_ExpWeightScroll.LargeChange = 1
			Me.m_ExpWeightScroll.Location = New System.Drawing.Point(6, 200)
			Me.m_ExpWeightScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.m_ExpWeightScroll.Name = "m_ExpWeightScroll"
			Me.m_ExpWeightScroll.Size = New System.Drawing.Size(167, 17)
			Me.m_ExpWeightScroll.TabIndex = 10
			Me.m_ExpWeightScroll.Value = 50
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_ExpWeightScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ExpWeightScroll_Scroll);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(6, 128)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(167, 16)
			Me.label3.TabIndex = 11
			Me.label3.Text = "Power:"
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(6, 176)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(167, 14)
			Me.label4.TabIndex = 12
			Me.label4.Text = "Exponential Weight:"
			' 
			' NPowerCumulativeExpAverageUC
			' 
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.m_ExpWeightScroll)
			Me.Controls.Add(Me.m_PowerScroll)
			Me.Controls.Add(Me.m_BtnData)
			Me.Controls.Add(Me.m_ExpressionLabel)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.m_FunctionCombo)
			Me.Name = "NPowerCumulativeExpAverageUC"
			Me.Size = New System.Drawing.Size(180, 282)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()


			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Power, Cumulative, Exponential Average")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

			' add a line series for the function
			m_Line = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line.MarkerStyle.Visible = True
			m_Line.MarkerStyle.BorderStyle.Color = Color.DarkGreen
			m_Line.MarkerStyle.BorderStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
			m_Line.MarkerStyle.Width = New NLength(1.2F, NRelativeUnit.ParentPercentage)
			m_Line.MarkerStyle.Height = New NLength(1.2F, NRelativeUnit.ParentPercentage)
			m_Line.MarkerStyle.PointShape = PointShape.Cylinder
			m_Line.MarkerStyle.FillStyle = New NColorFillStyle(Color.Gold)
			m_Line.BorderStyle.Color = Color.DarkGreen
			m_Line.BorderStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
			m_Line.Legend.Mode = SeriesLegendMode.None
			m_Line.DataLabelStyle.Format = "<value>"
			m_Line.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			m_Line.ShadowStyle.Type = ShadowType.GaussianBlur
			m_Line.ShadowStyle.Offset = New NPointL(2, 2)
			m_Line.ShadowStyle.Color = Color.FromArgb(120, 0, 0, 0)
			m_Line.ShadowStyle.FadeLength = New NLength(5)

			' add the bar series
			m_Bar = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar.Name = "Bar1"
			m_Bar.Values.Name = "values"
			m_Bar.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			m_Bar.MultiBarMode = MultiBarMode.Series
			m_Bar.DataLabelStyle.Visible = False
			m_Bar.Legend.Mode = SeriesLegendMode.DataPoints
			m_Bar.BarShape = BarShape.Cylinder
			m_Bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			m_Bar.FillStyle = New NColorFillStyle(Color.DarkKhaki)
			m_Bar.ShadowStyle.Type = ShadowType.Solid
			m_Bar.ShadowStyle.Offset = New NPointL(2, 2)
			m_Bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0)
			m_Bar.Values.FillRandomRange(Random, 10, 0, 10)

			m_FuncCalculator.Arguments.Add(m_Bar.Values)

			' form controls
			m_FunctionCombo.Items.Add("Power")
			m_FunctionCombo.Items.Add("Cumulative")
			m_FunctionCombo.Items.Add("Exponential Average")
			m_FunctionCombo.SelectedIndex = 0
		End Sub

		Private Sub BuildExpression()
			Dim sb As New StringBuilder()

			Select Case m_FunctionCombo.SelectedIndex
				Case 0
					m_PowerScroll.Enabled = True
					m_ExpWeightScroll.Enabled = False
					sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "POW(values; {0})", (CDbl(m_PowerScroll.Value)) / 10)

				Case 1
					m_PowerScroll.Enabled = False
					m_ExpWeightScroll.Enabled = False
					sb.Append("CUMSUM(values)")

				Case 2
					m_PowerScroll.Enabled = False
					m_ExpWeightScroll.Enabled = True
					sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "EXPAVG(values; {0})", (CDbl(m_ExpWeightScroll.Value)) / 100)
			End Select

			m_FuncCalculator.Expression = sb.ToString()
			m_ExpressionLabel.Text = m_FuncCalculator.Expression
		End Sub

		Private Sub CalculateFunction()
			m_Line.Values = m_FuncCalculator.Calculate()
			m_Line.Values.ValueFormatter = New NNumericValueFormatter("0.00")
		End Sub

		Private Sub FunctionCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_FunctionCombo.SelectedIndexChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			BuildExpression()
			CalculateFunction()
			nChartControl1.Refresh()
		End Sub

		Private Sub BtnData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BtnData.Click
			m_Bar.Values.FillRandomRange(Random, 10, 0, 10)

			CalculateFunction()

			nChartControl1.Refresh()
		End Sub

		Private Sub PowerScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles m_PowerScroll.ValueChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			BuildExpression()
			CalculateFunction()
			nChartControl1.Refresh()
		End Sub

		Private Sub ExpWeightScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles m_ExpWeightScroll.ValueChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			BuildExpression()
			CalculateFunction()
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace