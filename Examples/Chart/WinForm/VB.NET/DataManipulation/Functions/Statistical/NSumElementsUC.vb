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
	Public Class NSumElementsUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bar As NBarSeries
		Private m_Line As NLineSeries
		Private m_FuncCalculator As NFunctionCalculator
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private WithEvents m_BtnPosNegData As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_BtnPosData As Nevron.UI.WinForm.Controls.NButton
		Private m_ExpressionLabel As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents m_GroupingCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private m_LabelSum As Nevron.UI.WinForm.Controls.NTextBox
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
			Me.label3 = New System.Windows.Forms.Label()
			Me.m_GroupingCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.m_BtnPosNegData = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_BtnPosData = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_ExpressionLabel = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.m_LabelSum = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(7, 8)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(165, 16)
			Me.label3.TabIndex = 15
			Me.label3.Text = "Grouping:"
			' 
			' m_GroupingCombo
			' 
			Me.m_GroupingCombo.ListProperties.CheckBoxDataMember = ""
			Me.m_GroupingCombo.ListProperties.DataSource = Nothing
			Me.m_GroupingCombo.ListProperties.DisplayMember = ""
			Me.m_GroupingCombo.Location = New System.Drawing.Point(7, 27)
			Me.m_GroupingCombo.Name = "m_GroupingCombo"
			Me.m_GroupingCombo.Size = New System.Drawing.Size(165, 21)
			Me.m_GroupingCombo.TabIndex = 14
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_GroupingCombo.SelectedIndexChanged += new System.EventHandler(this.GroupingCombo_SelectedIndexChanged);
			' 
			' m_BtnPosNegData
			' 
			Me.m_BtnPosNegData.ButtonProperties.WrapText = True
			Me.m_BtnPosNegData.Location = New System.Drawing.Point(7, 226)
			Me.m_BtnPosNegData.Name = "m_BtnPosNegData"
			Me.m_BtnPosNegData.Size = New System.Drawing.Size(165, 24)
			Me.m_BtnPosNegData.TabIndex = 13
			Me.m_BtnPosNegData.Text = "Positive && Negative Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_BtnPosNegData.Click += new System.EventHandler(this.BtnPosNegData_Click);
			' 
			' m_BtnPosData
			' 
			Me.m_BtnPosData.Location = New System.Drawing.Point(7, 195)
			Me.m_BtnPosData.Name = "m_BtnPosData"
			Me.m_BtnPosData.Size = New System.Drawing.Size(165, 24)
			Me.m_BtnPosData.TabIndex = 12
			Me.m_BtnPosData.Text = "Positive Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_BtnPosData.Click += new System.EventHandler(this.BtnPosData_Click);
			' 
			' m_ExpressionLabel
			' 
			Me.m_ExpressionLabel.Location = New System.Drawing.Point(7, 82)
			Me.m_ExpressionLabel.Name = "m_ExpressionLabel"
			Me.m_ExpressionLabel.ReadOnly = True
			Me.m_ExpressionLabel.Size = New System.Drawing.Size(165, 18)
			Me.m_ExpressionLabel.TabIndex = 11
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(7, 64)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(165, 16)
			Me.label2.TabIndex = 10
			Me.label2.Text = "Expression:"
			' 
			' m_LabelSum
			' 
			Me.m_LabelSum.Location = New System.Drawing.Point(7, 137)
			Me.m_LabelSum.Name = "m_LabelSum"
			Me.m_LabelSum.ReadOnly = True
			Me.m_LabelSum.Size = New System.Drawing.Size(165, 18)
			Me.m_LabelSum.TabIndex = 16
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(7, 120)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(165, 16)
			Me.label1.TabIndex = 17
			Me.label1.Text = "Sum:"
			' 
			' NSumElementsUC
			' 
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.m_LabelSum)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.m_GroupingCombo)
			Me.Controls.Add(Me.m_BtnPosNegData)
			Me.Controls.Add(Me.m_BtnPosData)
			Me.Controls.Add(Me.m_ExpressionLabel)
			Me.Controls.Add(Me.label2)
			Me.Name = "NSumElementsUC"
			Me.Size = New System.Drawing.Size(180, 270)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()


			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Sum")
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
			m_Line.MarkerStyle.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			m_Line.MarkerStyle.FillStyle = New NColorFillStyle(Color.Crimson)
			m_Line.BorderStyle.Color = Color.Red
			m_Line.BorderStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
			m_Line.Legend.Mode = SeriesLegendMode.None
			m_Line.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			m_Line.DisplayOnAxis(StandardAxis.PrimaryX, False)
			m_Line.DisplayOnAxis(StandardAxis.SecondaryX, True)

			' add the bar series
			m_Bar = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar.Name = "Bar1"
			m_Bar.Values.Name = "values"
			m_Bar.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			m_Bar.MultiBarMode = MultiBarMode.Series
			m_Bar.DataLabelStyle.Visible = False
			m_Bar.Legend.Mode = SeriesLegendMode.DataPoints
			m_Bar.BarShape = BarShape.SmoothEdgeBar
			m_Bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			m_Bar.FillStyle = New NColorFillStyle(Color.Orange)
			m_Bar.Values.FillRandomRange(Random, 12, 0, 50)

			' set the function argument
			m_FuncCalculator.Arguments.Add(m_Bar.Values)

			' form controls
			m_GroupingCombo.Items.Add("Do not group")
			m_GroupingCombo.Items.Add("Group by every 2 values")
			m_GroupingCombo.Items.Add("Group by every 3 values")
			m_GroupingCombo.Items.Add("Group by every 4 values")
			m_GroupingCombo.SelectedIndex = 0
		End Sub

		Private Sub CalcFunction()
			Dim sb As New StringBuilder("SUM(values")

			Select Case m_GroupingCombo.SelectedIndex
				Case 0
					sb.Append(")")
				Case 1
					sb.Append("; 2)")
				Case 2
					sb.Append("; 3)")
				Case 3
					sb.Append("; 4)")
				Case Else
					Debug.Assert(False)
					Return
			End Select

			m_FuncCalculator.Expression = sb.ToString()
			m_ExpressionLabel.Text = m_FuncCalculator.Expression

			If m_GroupingCombo.SelectedIndex = 0 Then
				' draw a constline if there is no grouping
				SetConstline()
			Else
				' otherwise use the line series
				m_Chart.Axis(StandardAxis.PrimaryY).ConstLines.Clear()

				m_Line.Values = m_FuncCalculator.Calculate()
				m_Line.Values.ValueFormatter = New NNumericValueFormatter("0.00")
				m_Line.Visible = True

				m_LabelSum.Text = ""
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub SetConstline()
			Dim axis As NAxis = m_Chart.Axis(StandardAxis.PrimaryY)

			' add a constline if necessary
			If axis.ConstLines.Count = 0 Then
				axis.ConstLines.Add()
			End If

			' the line series won't be used
			m_Line.Visible = False

			' calc the sum of the elements
			Dim ds As NDataSeriesDouble = m_FuncCalculator.Calculate()

			' add a new constline
			Dim cl As NAxisConstLine = CType(axis.ConstLines(0), NAxisConstLine)
			cl.StrokeStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
			cl.StrokeStyle.Color = Color.Red
			cl.Value = DirectCast(ds.GetValueForIndex(0), Double)

			m_LabelSum.Text = cl.Value.ToString()

			' set proper scale for the axis, so that it includes the constline
			If cl.Value >= 0 Then
				' if the sum is positive - compare it to the largest value
				m_FuncCalculator.Expression = "MAX(values)"
				ds = m_FuncCalculator.Calculate()

				Dim dMax As Double = DirectCast(ds.GetValueForIndex(0), Double)

				If cl.Value > dMax Then
					dMax = cl.Value
				End If

				axis.View = New NRangeAxisView(New NRange1DD(0, dMax), False, True)
			Else
				' if the sum is negative - compare it to the smallest value
				m_FuncCalculator.Expression = "MIN(values)"
				ds = m_FuncCalculator.Calculate()

				Dim dMin As Double = DirectCast(ds.GetValueForIndex(0), Double)

				If cl.Value < dMin Then
					dMin = cl.Value
				End If

				axis.View = New NRangeAxisView(New NRange1DD(dMin, 0), True, False)
			End If
		End Sub

		Private Sub GroupingCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_GroupingCombo.SelectedIndexChanged
			CalcFunction()
		End Sub

		Private Sub BtnPosData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BtnPosData.Click
			m_Bar.Values.FillRandomRange(Random, 12, 0, 50)

			CalcFunction()
		End Sub

		Private Sub BtnPosNegData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BtnPosNegData.Click
			m_Bar.Values.FillRandomRange(Random, 12, -25, 25)

			CalcFunction()
		End Sub
	End Class
End Namespace