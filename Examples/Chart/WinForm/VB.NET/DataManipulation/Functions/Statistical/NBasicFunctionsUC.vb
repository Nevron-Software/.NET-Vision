Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Diagnostics
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.Functions

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NBasicFunctionsUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Line As NLineSeries
		Private m_Bar1 As NBarSeries
		Private m_Bar2 As NBarSeries
		Private m_FuncCalculator As NFunctionCalculator
		Private label1 As System.Windows.Forms.Label
		Private WithEvents m_BtnNewData As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_ExpressionCombo As Nevron.UI.WinForm.Controls.NComboBox
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.m_ExpressionCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.m_BtnNewData = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(164, 16)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Function Expression:"
			' 
			' m_ExpressionCombo
			' 
			Me.m_ExpressionCombo.ListProperties.CheckBoxDataMember = ""
			Me.m_ExpressionCombo.ListProperties.DataSource = Nothing
			Me.m_ExpressionCombo.ListProperties.DisplayMember = ""
			Me.m_ExpressionCombo.Location = New System.Drawing.Point(8, 24)
			Me.m_ExpressionCombo.Name = "m_ExpressionCombo"
			Me.m_ExpressionCombo.Size = New System.Drawing.Size(164, 21)
			Me.m_ExpressionCombo.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_ExpressionCombo.SelectedIndexChanged += new System.EventHandler(this.ExpressionCombo_SelectedIndexChanged);
			' 
			' m_BtnNewData
			' 
			Me.m_BtnNewData.Location = New System.Drawing.Point(8, 71)
			Me.m_BtnNewData.Name = "m_BtnNewData"
			Me.m_BtnNewData.Size = New System.Drawing.Size(164, 24)
			Me.m_BtnNewData.TabIndex = 3
			Me.m_BtnNewData.Text = "New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_BtnNewData.Click += new System.EventHandler(this.BtnNewData_Click);
			' 
			' NBasicFunctionsUC
			' 
			Me.Controls.Add(Me.m_BtnNewData)
			Me.Controls.Add(Me.m_ExpressionCombo)
			Me.Controls.Add(Me.label1)
			Me.Name = "NBasicFunctionsUC"
			Me.Size = New System.Drawing.Size(180, 153)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Basic Functions")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch

			m_Chart.Location = New NPointL(New NLength(15, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(67, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))

			' add a line series for the function
			m_Line = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line.Name = "Function"
			m_Line.DataLabelStyle.Format = "<value>"
			m_Line.Legend.Mode = SeriesLegendMode.Series
			m_Line.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			m_Line.BorderStyle.Color = Color.Red
			m_Line.BorderStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
			m_Line.MarkerStyle.Visible = True
			m_Line.MarkerStyle.BorderStyle.Color = Color.Red
			m_Line.MarkerStyle.BorderStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
			m_Line.MarkerStyle.PointShape = PointShape.Cylinder
			m_Line.MarkerStyle.FillStyle = New NColorFillStyle(Color.Gold)
			m_Line.MarkerStyle.Width = New NLength(2, NRelativeUnit.ParentPercentage)
			m_Line.MarkerStyle.Height = New NLength(2, NRelativeUnit.ParentPercentage)
			m_Line.ShadowStyle.Type = ShadowType.GaussianBlur
			m_Line.ShadowStyle.Offset = New NPointL(2, 2)
			m_Line.ShadowStyle.Color = Color.FromArgb(88, 0, 0, 0)
			m_Line.ShadowStyle.FadeLength = New NLength(5)

			' add the first bar
			m_Bar1 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar1.Name = "Bar1"
			m_Bar1.Values.Name = "Green"
			m_Bar1.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			m_Bar1.MultiBarMode = MultiBarMode.Series
			m_Bar1.DataLabelStyle.Visible = False
			m_Bar1.Legend.Mode = SeriesLegendMode.DataPoints
			m_Bar1.FillStyle = New NColorFillStyle(Color.FromArgb(80, Color.SeaGreen))
			m_Bar1.BorderStyle.Width = New NLength(1, NGraphicsUnit.Pixel)
			m_Bar1.ShadowStyle.Type = ShadowType.GaussianBlur
			m_Bar1.ShadowStyle.Offset = New NPointL(3, 3)
			m_Bar1.ShadowStyle.Color = Color.FromArgb(88, 0, 0, 0)
			m_Bar1.ShadowStyle.FadeLength = New NLength(3)

			' add the second bar
			m_Bar2 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar2.Name = "Bar2"
			m_Bar2.Values.Name = "Blue"
			m_Bar2.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			m_Bar2.MultiBarMode = MultiBarMode.Clustered
			m_Bar2.DataLabelStyle.Visible = False
			m_Bar2.Legend.Mode = SeriesLegendMode.DataPoints
			m_Bar2.FillStyle = New NColorFillStyle(Color.FromArgb(80, Color.CornflowerBlue))
			m_Bar2.BorderStyle.Width = New NLength(1, NGraphicsUnit.Pixel)
			m_Bar2.ShadowStyle.Type = ShadowType.GaussianBlur
			m_Bar2.ShadowStyle.Offset = New NPointL(3, 3)
			m_Bar2.ShadowStyle.Color = Color.FromArgb(88, 0, 0, 0)
			m_Bar2.ShadowStyle.FadeLength = New NLength(3)

			' fill with random data
			FillDataSeries(m_Bar1.Values, 5)
			FillDataSeries(m_Bar2.Values, 5)

			' form controls
			m_ExpressionCombo.Items.Add("ADD(Green; Blue)")
			m_ExpressionCombo.Items.Add("SUB(Green; Blue)")
			m_ExpressionCombo.Items.Add("MUL(Green; Blue)")
			m_ExpressionCombo.Items.Add("DIV(Green; Blue)")
			m_ExpressionCombo.Items.Add("HIGH(Green; Blue)")
			m_ExpressionCombo.Items.Add("LOW(Green; Blue)")
			m_ExpressionCombo.SelectedIndex = 0
		End Sub


		Private Sub FillDataSeries(ByVal ds As NDataSeriesDouble, ByVal nCount As Integer)
			ds.Clear()

			For i As Integer = 0 To nCount - 1
				ds.Add(Random.NextDouble() * 3)
			Next i
		End Sub

		Private Sub UpdateFunctionLine()
			Dim ds As NDataSeriesDouble = m_FuncCalculator.Calculate()

			If ds Is Nothing Then
				m_Line.Values.Clear()
			Else
				m_Line.Values = ds
				m_Line.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub ExpressionCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ExpressionCombo.SelectedIndexChanged
			m_FuncCalculator.Arguments.Clear()
			m_FuncCalculator.Arguments.Add(m_Bar1.Values)
			m_FuncCalculator.Arguments.Add(m_Bar2.Values)
			m_FuncCalculator.Expression = DirectCast(m_ExpressionCombo.SelectedItem, String)

			UpdateFunctionLine()
		End Sub

		Private Sub BtnNewData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BtnNewData.Click
			FillDataSeries(m_Bar1.Values, 5)
			FillDataSeries(m_Bar2.Values, 5)

			UpdateFunctionLine()
		End Sub
	End Class
End Namespace