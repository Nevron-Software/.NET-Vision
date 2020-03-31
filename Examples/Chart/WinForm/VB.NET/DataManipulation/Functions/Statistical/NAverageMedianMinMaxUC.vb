﻿Imports System
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
	Public Class NAverageMedianMinMaxUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bar As NBarSeries
		Private m_Line As NLineSeries
		Private m_FuncCalculator As NFunctionCalculator
		Private m_bSkipUpdate As Boolean
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private m_ExpressionLabel As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents m_BtnPosData As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_BtnPosNegData As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_GroupingCombo As Nevron.UI.WinForm.Controls.NComboBox
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
			Me.m_FunctionCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.m_ExpressionLabel = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.m_BtnPosData = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_BtnPosNegData = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_GroupingCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' m_FunctionCombo
			' 
			Me.m_FunctionCombo.ListProperties.CheckBoxDataMember = ""
			Me.m_FunctionCombo.ListProperties.DataSource = Nothing
			Me.m_FunctionCombo.ListProperties.DisplayMember = ""
			Me.m_FunctionCombo.Location = New System.Drawing.Point(4, 26)
			Me.m_FunctionCombo.Name = "m_FunctionCombo"
			Me.m_FunctionCombo.Size = New System.Drawing.Size(170, 21)
			Me.m_FunctionCombo.TabIndex = 0
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_FunctionCombo.SelectedIndexChanged += new System.EventHandler(this.m_FunctionCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(4, 10)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(170, 16)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Function:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(4, 106)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(170, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Expression:"
			' 
			' m_ExpressionLabel
			' 
			Me.m_ExpressionLabel.Location = New System.Drawing.Point(4, 122)
			Me.m_ExpressionLabel.Name = "m_ExpressionLabel"
			Me.m_ExpressionLabel.ReadOnly = True
			Me.m_ExpressionLabel.Size = New System.Drawing.Size(170, 18)
			Me.m_ExpressionLabel.TabIndex = 3
			' 
			' m_BtnPosData
			' 
			Me.m_BtnPosData.Location = New System.Drawing.Point(4, 162)
			Me.m_BtnPosData.Name = "m_BtnPosData"
			Me.m_BtnPosData.Size = New System.Drawing.Size(170, 24)
			Me.m_BtnPosData.TabIndex = 4
			Me.m_BtnPosData.Text = "Positive Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_BtnPosData.Click += new System.EventHandler(this.m_BtnPosData_Click);
			' 
			' m_BtnPosNegData
			' 
			Me.m_BtnPosNegData.ButtonProperties.WrapText = True
			Me.m_BtnPosNegData.Location = New System.Drawing.Point(4, 194)
			Me.m_BtnPosNegData.Name = "m_BtnPosNegData"
			Me.m_BtnPosNegData.Size = New System.Drawing.Size(170, 24)
			Me.m_BtnPosNegData.TabIndex = 5
			Me.m_BtnPosNegData.Text = "Positive && Negative Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_BtnPosNegData.Click += new System.EventHandler(this.m_BtnPosNegData_Click);
			' 
			' m_GroupingCombo
			' 
			Me.m_GroupingCombo.ListProperties.CheckBoxDataMember = ""
			Me.m_GroupingCombo.ListProperties.DataSource = Nothing
			Me.m_GroupingCombo.ListProperties.DisplayMember = ""
			Me.m_GroupingCombo.Location = New System.Drawing.Point(4, 74)
			Me.m_GroupingCombo.Name = "m_GroupingCombo"
			Me.m_GroupingCombo.Size = New System.Drawing.Size(170, 21)
			Me.m_GroupingCombo.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_GroupingCombo.SelectedIndexChanged += new System.EventHandler(this.m_GroupingCombo_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(4, 58)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(170, 16)
			Me.label3.TabIndex = 7
			Me.label3.Text = "Grouping:"
			' 
			' NAverageMedianMinMaxUC
			' 
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.m_GroupingCombo)
			Me.Controls.Add(Me.m_BtnPosNegData)
			Me.Controls.Add(Me.m_BtnPosData)
			Me.Controls.Add(Me.m_ExpressionLabel)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.m_FunctionCombo)
			Me.Name = "NAverageMedianMinMaxUC"
			Me.Size = New System.Drawing.Size(180, 232)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Average, Median, Min, Max")
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
			m_Bar.BarShape = BarShape.Cylinder
			m_Bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			m_Bar.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant1, Color.LightSteelBlue, Color.MidnightBlue)
			m_Bar.Values.FillRandomRange(Random, 12, 0, 50)

			' form controls
			m_bSkipUpdate = True
			m_FunctionCombo.Items.Add("Average")
			m_FunctionCombo.Items.Add("Median")
			m_FunctionCombo.Items.Add("Min")
			m_FunctionCombo.Items.Add("Max")
			m_FunctionCombo.SelectedIndex = 0

			m_GroupingCombo.Items.Add("Do not group")
			m_GroupingCombo.Items.Add("Group by every 2 values")
			m_GroupingCombo.Items.Add("Group by every 3 values")
			m_GroupingCombo.Items.Add("Group by every 4 values")
			m_GroupingCombo.SelectedIndex = 0
			m_bSkipUpdate = False

			m_FunctionCombo_SelectedIndexChanged(Nothing, Nothing)
		End Sub

		Private Sub BuildExpression()
			Dim expr As New StringBuilder()

			' set the beginning of the expression according to the selected function
			Select Case m_FunctionCombo.SelectedIndex
				Case 0
					expr.Append("AVERAGE(")
				Case 1
					expr.Append("MEDIAN(")
				Case 2
					expr.Append("MIN(")
				Case 3
					expr.Append("MAX(")
				Case Else
					Debug.Assert(False)
					Return
			End Select

			' append the first parameter
			expr.Append(m_Bar.Values.Name)

			' append the second parameter if needed
			Select Case m_GroupingCombo.SelectedIndex
				Case 0
					expr.Append(")")
				Case 1
					expr.Append("; 2)")
				Case 2
					expr.Append("; 3)")
				Case 3
					expr.Append("; 4)")
				Case Else
					Debug.Assert(False)
					Return
			End Select

			m_ExpressionLabel.Text = expr.ToString()

			' update the function calculator
			m_FuncCalculator.Arguments.Clear()
			m_FuncCalculator.Arguments.Add(m_Bar.Values)
			m_FuncCalculator.Expression = m_ExpressionLabel.Text
		End Sub

		Private Sub CalcFunction()
			Dim ds As NDataSeriesDouble = m_FuncCalculator.Calculate()

			If ds Is Nothing Then
				Return
			End If

			m_Chart.Axis(StandardAxis.PrimaryY).ConstLines.Clear()
			m_Line.Visible = False

			If m_GroupingCombo.SelectedIndex = 0 Then
				' add a constline if there is no grouping
				Dim cl As NAxisConstLine = m_Chart.Axis(StandardAxis.PrimaryY).ConstLines.Add()
				cl.StrokeStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
				cl.StrokeStyle.Color = Color.Red
				cl.Value = DirectCast(ds.GetValueForIndex(0), Double)
			Else
				m_Line.Visible = True
				m_Line.Values = ds
				m_Line.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub m_FunctionCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_FunctionCombo.SelectedIndexChanged
			If m_bSkipUpdate Then
				Return
			End If

			BuildExpression()
			CalcFunction()
		End Sub

		Private Sub m_GroupingCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_GroupingCombo.SelectedIndexChanged
			If m_bSkipUpdate Then
				Return
			End If

			BuildExpression()
			CalcFunction()
		End Sub

		Private Sub m_BtnPosData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BtnPosData.Click
			m_Bar.Values.FillRandomRange(Random, 12, 0, 50)

			CalcFunction()
		End Sub

		Private Sub m_BtnPosNegData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BtnPosNegData.Click
			m_Bar.Values.FillRandomRange(Random, 12, -25, 25)

			CalcFunction()
		End Sub
	End Class
End Namespace