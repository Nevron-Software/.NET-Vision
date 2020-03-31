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
	Public Class NCovarianceCorrelationUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Line1, m_Line2 As NLineSeries
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
			Me.m_FunctionCombo.Location = New System.Drawing.Point(8, 24)
			Me.m_FunctionCombo.Name = "m_FunctionCombo"
			Me.m_FunctionCombo.Size = New System.Drawing.Size(162, 21)
			Me.m_FunctionCombo.TabIndex = 0
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_FunctionCombo.SelectedIndexChanged += new System.EventHandler(this.FunctionCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(162, 16)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Function:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 104)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(74, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Expression:"
			' 
			' m_ExpressionLabel
			' 
			Me.m_ExpressionLabel.Location = New System.Drawing.Point(8, 120)
			Me.m_ExpressionLabel.Name = "m_ExpressionLabel"
			Me.m_ExpressionLabel.ReadOnly = True
			Me.m_ExpressionLabel.Size = New System.Drawing.Size(162, 18)
			Me.m_ExpressionLabel.TabIndex = 3
			' 
			' m_BtnPosData
			' 
			Me.m_BtnPosData.Location = New System.Drawing.Point(8, 152)
			Me.m_BtnPosData.Name = "m_BtnPosData"
			Me.m_BtnPosData.Size = New System.Drawing.Size(162, 24)
			Me.m_BtnPosData.TabIndex = 4
			Me.m_BtnPosData.Text = "Positive Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_BtnPosData.Click += new System.EventHandler(this.BtnPosData_Click);
			' 
			' m_BtnPosNegData
			' 
			Me.m_BtnPosNegData.ButtonProperties.WrapText = True
			Me.m_BtnPosNegData.Location = New System.Drawing.Point(8, 184)
			Me.m_BtnPosNegData.Name = "m_BtnPosNegData"
			Me.m_BtnPosNegData.Size = New System.Drawing.Size(162, 24)
			Me.m_BtnPosNegData.TabIndex = 5
			Me.m_BtnPosNegData.Text = "Positive && Negative Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_BtnPosNegData.Click += new System.EventHandler(this.BtnPosNegData_Click);
			' 
			' m_GroupingCombo
			' 
			Me.m_GroupingCombo.ListProperties.CheckBoxDataMember = ""
			Me.m_GroupingCombo.ListProperties.DataSource = Nothing
			Me.m_GroupingCombo.ListProperties.DisplayMember = ""
			Me.m_GroupingCombo.Location = New System.Drawing.Point(8, 72)
			Me.m_GroupingCombo.Name = "m_GroupingCombo"
			Me.m_GroupingCombo.Size = New System.Drawing.Size(162, 21)
			Me.m_GroupingCombo.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_GroupingCombo.SelectedIndexChanged += new System.EventHandler(this.GroupingCombo_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 56)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(162, 16)
			Me.label3.TabIndex = 7
			Me.label3.Text = "Grouping:"
			' 
			' NCovarianceCorrelationUC
			' 
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.m_GroupingCombo)
			Me.Controls.Add(Me.m_BtnPosNegData)
			Me.Controls.Add(Me.m_BtnPosData)
			Me.Controls.Add(Me.m_ExpressionLabel)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.m_FunctionCombo)
			Me.Name = "NCovarianceCorrelationUC"
			Me.Size = New System.Drawing.Size(180, 240)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Covariance, Correlation")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' chart functions
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

			' add a line series for the function
			m_Line = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line.MarkerStyle.Visible = True
			m_Line.MarkerStyle.BorderStyle.Color = Color.DarkGreen
			m_Line.MarkerStyle.BorderStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
			m_Line.MarkerStyle.Width = New NLength(1F, NRelativeUnit.ParentPercentage)
			m_Line.MarkerStyle.Height = New NLength(1F, NRelativeUnit.ParentPercentage)
			m_Line.MarkerStyle.PointShape = PointShape.Cylinder
			m_Line.MarkerStyle.FillStyle = New NColorFillStyle(Color.Beige)
			m_Line.BorderStyle.Color = Color.Green
			m_Line.BorderStyle.Width = New NLength(3, NGraphicsUnit.Pixel)
			m_Line.Legend.Mode = SeriesLegendMode.None
			m_Line.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			m_Line.DisplayOnAxis(StandardAxis.PrimaryX, False)
			m_Line.DisplayOnAxis(StandardAxis.SecondaryX, True)

			' add the line series
			m_Line1 = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line1.Name = "Line1"
			m_Line1.Values.Name = "values1"
			m_Line1.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			m_Line1.DataLabelStyle.Visible = False
			m_Line1.BorderStyle.Color = Color.DarkKhaki
			m_Line1.BorderStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
			m_Line1.Legend.Mode = SeriesLegendMode.Series
			m_Line1.Values.FillRandomRange(Random, 12, 0, 50)

			' add the line series
			m_Line2 = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line2.Name = "Line2"
			m_Line2.Values.Name = "values2"
			m_Line2.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			m_Line2.DataLabelStyle.Visible = False
			m_Line2.BorderStyle.Color = Color.DarkCyan
			m_Line2.BorderStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
			m_Line2.Legend.Mode = SeriesLegendMode.Series
			m_Line2.Values.FillRandomRange(Random, 12, 0, 50)

			' form controls
			m_bSkipUpdate = True
			m_FunctionCombo.Items.Add("Covariance")
			m_FunctionCombo.Items.Add("Correlation")
			m_FunctionCombo.SelectedIndex = 0

			m_GroupingCombo.Items.Add("Do not group")
			m_GroupingCombo.Items.Add("Group by every 2 values")
			m_GroupingCombo.Items.Add("Group by every 3 values")
			m_GroupingCombo.Items.Add("Group by every 4 values")
			m_GroupingCombo.SelectedIndex = 0
			m_bSkipUpdate = False

			FunctionCombo_SelectedIndexChanged(Nothing, Nothing)
		End Sub

		Private Sub BuildExpression()
			Dim expr As New StringBuilder()

			' set the beginning of the expression according to the selected function
			Select Case m_FunctionCombo.SelectedIndex
				Case 0
					expr.Append("COVARIANCE(")
				Case 1
					expr.Append("CORRELATION(")
				Case Else
					Debug.Assert(False)
					Return
			End Select

			' append the first parameter
			expr.Append(m_Line1.Values.Name)
			expr.Append("; ")
			expr.Append(m_Line2.Values.Name)

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
			m_FuncCalculator.Arguments.Add(m_Line1.Values)
			m_FuncCalculator.Arguments.Add(m_Line2.Values)
			m_FuncCalculator.Expression = m_ExpressionLabel.Text
		End Sub

		Private Sub CalcFunction()
			Dim ds As NDataSeriesDouble = m_FuncCalculator.Calculate()

			If ds Is Nothing Then
				Return
			End If

			m_Chart.Axis(StandardAxis.PrimaryY).ConstLines.Clear()
			m_Line.Visible = False

			Dim axis As NAxis = m_Chart.Axis(StandardAxis.PrimaryY)

			axis.View = New NContentAxisView()

			If m_GroupingCombo.SelectedIndex = 0 Then
				SetConstline(ds)
			Else
				m_Line.Visible = True
				m_Line.Values = ds
				m_Line.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub SetConstline(ByVal ds As NDataSeriesDouble)
			Dim axis As NAxis = m_Chart.Axis(StandardAxis.PrimaryY)

			' add a constline if necessary
			If axis.ConstLines.Count = 0 Then
				axis.ConstLines.Add()
			End If

			' the line series won't be used
			m_Line.Visible = False

			' add a new constline
			Dim cl As NAxisConstLine = CType(axis.ConstLines(0), NAxisConstLine)
			cl.StrokeStyle.Width = New NLength(3, NGraphicsUnit.Pixel)
			cl.StrokeStyle.Color = Color.Green
			cl.Value = DirectCast(ds.GetValueForIndex(0), Double)

'INSTANT VB NOTE: The variable text was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim text_Renamed As String = cl.Value.ToString()

			If text_Renamed.Length > 7 Then
				text_Renamed = text_Renamed.Substring(0, 7)
			End If

'			NAxisCustomLabel axisLabel = axis.CustomLabels.Add();
'			axisLabel.Offset = 3;
'			axisLabel.TextStyle.BackplaneStyle.Visible = true;
'			axisLabel.Angle = 180;
'			axisLabel.Text = text;
'			axisLabel.Value = cl.Value;

			' set proper scale for the axis, so that it includes the constline
			Dim subset As New NDataSeriesSubset()
			subset.AddRange(0, ds.Count - 1)

			Dim max1 As Double = m_Line1.Values.Evaluate("MAX", subset)
			Dim min1 As Double = m_Line1.Values.Evaluate("MIN", subset)

			Dim max2 As Double = m_Line2.Values.Evaluate("MAX", subset)
			Dim min2 As Double = m_Line2.Values.Evaluate("MIN", subset)

			If max1 < max2 Then
				max1 = max2
			End If

			If min1 > min2 Then
				min1 = min2
			End If

			If cl.Value > max1 Then
				axis.View = New NRangeAxisView(New NRange1DD(Double.MinValue, cl.Value), False, True)
			ElseIf cl.Value < min1 Then
				axis.View = New NRangeAxisView(New NRange1DD(cl.Value, Double.MaxValue), True, False)
			End If
		End Sub

		Private Sub FunctionCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_FunctionCombo.SelectedIndexChanged
			If m_bSkipUpdate Then
				Return
			End If

			BuildExpression()
			CalcFunction()
		End Sub

		Private Sub GroupingCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_GroupingCombo.SelectedIndexChanged
			If m_bSkipUpdate Then
				Return
			End If

			BuildExpression()
			CalcFunction()
		End Sub

		Private Sub BtnPosData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BtnPosData.Click
			m_Line1.Values.FillRandomRange(Random, 12, 0, 50)
			m_Line2.Values.FillRandomRange(Random, 12, 0, 50)

			CalcFunction()
		End Sub

		Private Sub BtnPosNegData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BtnPosNegData.Click
			m_Line1.Values.FillRandomRange(Random, 12, -25, 25)
			m_Line2.Values.FillRandomRange(Random, 12, -25, 25)

			CalcFunction()
		End Sub
	End Class
End Namespace