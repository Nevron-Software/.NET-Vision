Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Text
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.Functions


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NCountStdDevRmsUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bar As NBarSeries
		Private m_FuncCalculator As NFunctionCalculator
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private m_LabelResult As Nevron.UI.WinForm.Controls.NTextBox
		Private m_ExpressionLabel As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents m_BtnData As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_FunctionCombo As Nevron.UI.WinForm.Controls.NComboBox
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
			Me.m_BtnData = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_ExpressionLabel = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.m_FunctionCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.m_LabelResult = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.SuspendLayout()
			' 
			' m_BtnData
			' 
			Me.m_BtnData.Location = New System.Drawing.Point(9, 200)
			Me.m_BtnData.Name = "m_BtnData"
			Me.m_BtnData.Size = New System.Drawing.Size(161, 24)
			Me.m_BtnData.TabIndex = 13
			Me.m_BtnData.Text = "New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_BtnData.Click += new System.EventHandler(this.BtnData_Click);
			' 
			' m_ExpressionLabel
			' 
			Me.m_ExpressionLabel.Location = New System.Drawing.Point(9, 92)
			Me.m_ExpressionLabel.Name = "m_ExpressionLabel"
			Me.m_ExpressionLabel.ReadOnly = True
			Me.m_ExpressionLabel.Size = New System.Drawing.Size(161, 18)
			Me.m_ExpressionLabel.TabIndex = 12
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 72)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(161, 16)
			Me.label2.TabIndex = 11
			Me.label2.Text = "Expression:"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(9, 13)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(161, 16)
			Me.label1.TabIndex = 10
			Me.label1.Text = "Function:"
			' 
			' m_FunctionCombo
			' 
			Me.m_FunctionCombo.ListProperties.CheckBoxDataMember = ""
			Me.m_FunctionCombo.ListProperties.DataSource = Nothing
			Me.m_FunctionCombo.ListProperties.DisplayMember = ""
			Me.m_FunctionCombo.Location = New System.Drawing.Point(9, 32)
			Me.m_FunctionCombo.Name = "m_FunctionCombo"
			Me.m_FunctionCombo.Size = New System.Drawing.Size(161, 21)
			Me.m_FunctionCombo.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_FunctionCombo.SelectedIndexChanged += new System.EventHandler(this.FunctionCombo_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(9, 133)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(161, 16)
			Me.label3.TabIndex = 19
			Me.label3.Text = "Result:"
			' 
			' m_LabelResult
			' 
			Me.m_LabelResult.Location = New System.Drawing.Point(9, 152)
			Me.m_LabelResult.Name = "m_LabelResult"
			Me.m_LabelResult.ReadOnly = True
			Me.m_LabelResult.Size = New System.Drawing.Size(161, 18)
			Me.m_LabelResult.TabIndex = 18
			' 
			' NCountStdDevRmsUC
			' 
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.m_LabelResult)
			Me.Controls.Add(Me.m_BtnData)
			Me.Controls.Add(Me.m_ExpressionLabel)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.m_FunctionCombo)
			Me.Name = "NCountStdDevRmsUC"
			Me.Size = New System.Drawing.Size(180, 243)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Count, Standard Deviation, RMS")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

			' add a constline to diplay the function result
			Dim cl As NAxisConstLine = m_Chart.Axis(StandardAxis.PrimaryY).ConstLines.Add()
			cl.StrokeStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
			cl.StrokeStyle.Color = Color.Red
			cl.Value = 0

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
			m_Bar.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant1, Color.DarkSeaGreen, Color.DarkGreen)
			m_Bar.Values.FillRandomRange(Random, 10, 0, 20)

			' add argument
			m_FuncCalculator.Arguments.Add(m_Bar.Values)

			' form controls
			m_FunctionCombo.Items.Add("Count")
			m_FunctionCombo.Items.Add("Standard Deviation")
			m_FunctionCombo.Items.Add("Root Mean Square")
			m_FunctionCombo.SelectedIndex = 0
		End Sub

		Private Sub BuildExpression()
			Select Case m_FunctionCombo.SelectedIndex
				Case 0
					m_FuncCalculator.Expression = "COUNT(values)"

				Case 1
					m_FuncCalculator.Expression = "STDDEV(values)"

				Case 2
					m_FuncCalculator.Expression = "POW(AVERAGE(POW(values; 2)); 0.5)"

				Case Else
					Debug.Assert(False)
					Return
			End Select

			m_ExpressionLabel.Text = m_FuncCalculator.Expression
		End Sub

		Private Sub CalculateFunction()
			Dim cl As NAxisConstLine = CType(m_Chart.Axis(StandardAxis.PrimaryY).ConstLines(0), NAxisConstLine)
			Dim ds As NDataSeriesDouble = m_FuncCalculator.Calculate()

			cl.Value = DirectCast(ds.GetValueForIndex(0), Double)

			m_LabelResult.Text = cl.Value.ToString()
		End Sub

		Private Sub FunctionCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_FunctionCombo.SelectedIndexChanged
			BuildExpression()
			CalculateFunction()
			nChartControl1.Refresh()
		End Sub

		Private Sub BtnData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BtnData.Click
			m_Bar.Values.FillRandomRange(Random, 10, 0, 20)
			CalculateFunction()
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace