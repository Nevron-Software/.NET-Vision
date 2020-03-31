Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NParetoUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bar As NBarSeries
		Private m_Line As NLineSeries
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents DifferentFillStyles As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents WidthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents StyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents BarFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents MarkersBorderButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents MarkersFillButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LineStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BarBorderButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.DifferentFillStyles = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.WidthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.StyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.BarFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.BarBorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.MarkersBorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.MarkersFillButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.LineStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' DifferentFillStyles
			' 
			Me.DifferentFillStyles.ButtonProperties.BorderOffset = 2
			Me.DifferentFillStyles.Location = New System.Drawing.Point(11, 174)
			Me.DifferentFillStyles.Name = "DifferentFillStyles"
			Me.DifferentFillStyles.Size = New System.Drawing.Size(148, 22)
			Me.DifferentFillStyles.TabIndex = 15
			Me.DifferentFillStyles.Text = "Different Fill Styles"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DifferentFillStyles.CheckedChanged += new System.EventHandler(this.DifferentFillStyles_CheckedChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(11, 66)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(148, 16)
			Me.label2.TabIndex = 13
			Me.label2.Text = "Width %:"
			' 
			' WidthScroll
			' 
			Me.WidthScroll.Location = New System.Drawing.Point(11, 82)
			Me.WidthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.WidthScroll.Name = "WidthScroll"
			Me.WidthScroll.Size = New System.Drawing.Size(148, 16)
			Me.WidthScroll.TabIndex = 11
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WidthScroll_Scroll);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(11, 18)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(148, 16)
			Me.label1.TabIndex = 10
			Me.label1.Text = "Bar Style:"
			' 
			' StyleCombo
			' 
			Me.StyleCombo.ListProperties.CheckBoxDataMember = ""
			Me.StyleCombo.ListProperties.DataSource = Nothing
			Me.StyleCombo.ListProperties.DisplayMember = ""
			Me.StyleCombo.Location = New System.Drawing.Point(11, 34)
			Me.StyleCombo.Name = "StyleCombo"
			Me.StyleCombo.Size = New System.Drawing.Size(148, 21)
			Me.StyleCombo.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StyleCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			' 
			' BarFillStyleButton
			' 
			Me.BarFillStyleButton.Location = New System.Drawing.Point(11, 108)
			Me.BarFillStyleButton.Name = "BarFillStyleButton"
			Me.BarFillStyleButton.Size = New System.Drawing.Size(148, 25)
			Me.BarFillStyleButton.TabIndex = 8
			Me.BarFillStyleButton.Text = "Bar Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarFillStyleButton.Click += new System.EventHandler(this.BarFillStyleButton_Click);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.BarBorderButton)
			Me.groupBox1.Controls.Add(Me.DifferentFillStyles)
			Me.groupBox1.Controls.Add(Me.WidthScroll)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Controls.Add(Me.StyleCombo)
			Me.groupBox1.Controls.Add(Me.BarFillStyleButton)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(4, 7)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(173, 212)
			Me.groupBox1.TabIndex = 16
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Bar Properties"
			' 
			' BarBorderButton
			' 
			Me.BarBorderButton.Location = New System.Drawing.Point(11, 139)
			Me.BarBorderButton.Name = "BarBorderButton"
			Me.BarBorderButton.Size = New System.Drawing.Size(148, 25)
			Me.BarBorderButton.TabIndex = 16
			Me.BarBorderButton.Text = "Bar Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarBorderButton.Click += new System.EventHandler(this.BarBorderButton_Click);
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.MarkersBorderButton)
			Me.groupBox2.Controls.Add(Me.MarkersFillButton)
			Me.groupBox2.Controls.Add(Me.LineStyleButton)
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(4, 226)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(173, 119)
			Me.groupBox2.TabIndex = 17
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Line Properties"
			' 
			' MarkersBorderButton
			' 
			Me.MarkersBorderButton.Location = New System.Drawing.Point(9, 49)
			Me.MarkersBorderButton.Name = "MarkersBorderButton"
			Me.MarkersBorderButton.Size = New System.Drawing.Size(148, 24)
			Me.MarkersBorderButton.TabIndex = 14
			Me.MarkersBorderButton.Text = "Markers Border ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkersBorderButton.Click += new System.EventHandler(this.MarkersBorderButton_Click);
			' 
			' MarkersFillButton
			' 
			Me.MarkersFillButton.Location = New System.Drawing.Point(9, 79)
			Me.MarkersFillButton.Name = "MarkersFillButton"
			Me.MarkersFillButton.Size = New System.Drawing.Size(148, 24)
			Me.MarkersFillButton.TabIndex = 13
			Me.MarkersFillButton.Text = "Markers Fill Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkersFillButton.Click += new System.EventHandler(this.MarkersFillButton_Click);
			' 
			' LineStyleButton
			' 
			Me.LineStyleButton.Location = New System.Drawing.Point(9, 19)
			Me.LineStyleButton.Name = "LineStyleButton"
			Me.LineStyleButton.Size = New System.Drawing.Size(148, 24)
			Me.LineStyleButton.TabIndex = 12
			Me.LineStyleButton.Text = "Line Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineStyleButton.Click += new System.EventHandler(this.LineStyleButton_Click);
			' 
			' NParetoUC
			' 
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NParetoUC"
			Me.Size = New System.Drawing.Size(180, 357)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Pareto Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' setup the X axis
			Dim axisX As NAxis = m_Chart.Axis(StandardAxis.PrimaryX)
			Dim scaleX As NOrdinalScaleConfigurator = CType(axisX.ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.InnerMajorTickStyle.Visible = False

			' Setup the primary Y axis
			Dim axisY1 As NAxis = m_Chart.Axis(StandardAxis.PrimaryY)
			Dim scaleY1 As NLinearScaleConfigurator = CType(axisY1.ScaleConfigurator, NLinearScaleConfigurator)
			scaleY1.InnerMajorTickStyle.Visible = False
			scaleY1.Title.Text = "Number of Occurences"

			' add interlace stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			scaleY1.StripStyles.Add(stripStyle)

			' Setup the secondary Y axis
			Dim scaleY2 As New NLinearScaleConfigurator()
			scaleY2.LabelValueFormatter = New NNumericValueFormatter("0%")
			scaleY2.InnerMajorTickStyle.Visible = False
			scaleY2.Title.Text = "Cumulative Percent"
			Dim axisY2 As NAxis = m_Chart.Axis(StandardAxis.SecondaryY)
			axisY2.Visible = True
			axisY2.ScaleConfigurator = scaleY2
			axisY2.View = New NRangeAxisView(New NRange1DD(0, 1), True, True)

			' add the line series
			m_Line = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line.Name = "Cumulative %"
			m_Line.DataLabelStyle.Visible = False
			m_Line.MarkerStyle.Visible = True
			m_Line.MarkerStyle.PointShape = PointShape.Cylinder
			m_Line.MarkerStyle.Width = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			m_Line.MarkerStyle.Height = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			m_Line.ShadowStyle.Type = ShadowType.GaussianBlur
			m_Line.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0)
			m_Line.ShadowStyle.Offset = New NPointL(2, 2)
			m_Line.ShadowStyle.FadeLength = New NLength(4)
			m_Line.DisplayOnAxis(StandardAxis.PrimaryY, False)
			m_Line.DisplayOnAxis(StandardAxis.SecondaryY, True)

			' add the bar series
			m_Bar = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar.Name = "Bar Series"
			m_Bar.DataLabelStyle.Visible = False
			m_Bar.ShadowStyle.Type = ShadowType.GaussianBlur
			m_Bar.ShadowStyle.Color = Color.FromArgb(60, 0, 0, 0)
			m_Bar.ShadowStyle.Offset = New NPointL(3, 3)
			m_Bar.ShadowStyle.FadeLength = New NLength(4)

			' fill with random data and sort in descending order
			m_Bar.Values.FillRandomRange(Random, 10, 100, 700)
			m_Bar.Values.Sort(DataSeriesSortOrder.Descending)

			' calculate cumulative sum of the bar values
			Dim count As Integer = m_Bar.Values.Count
			Dim cs As Double = 0
			Dim arrCumulative(count - 1) As Double

			For i As Integer = 0 To count - 1
				cs += m_Bar.Values.GetDoubleValue(i)
				arrCumulative(i) = cs
			Next i

			If cs > 0 Then
				For i As Integer = 0 To count - 1
					arrCumulative(i) /= cs
				Next i

				m_Line.Values.AddRange(arrCumulative)
			End If

			' apply layout
			ConfigureStandardLayout(m_Chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			StyleCombo.FillFromEnum(GetType(BarShape))
			StyleCombo.SelectedIndex = 0
		End Sub

		Private Sub StyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StyleCombo.SelectedIndexChanged
			m_Bar.BarShape = CType(StyleCombo.SelectedIndex, BarShape)
			nChartControl1.Refresh()
		End Sub
		Private Sub DifferentFillStyles_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DifferentFillStyles.CheckedChanged
			If DifferentFillStyles.Checked Then
				BarFillStyleButton.Enabled = False

				For i As Integer = 0 To m_Bar.Values.Count - 1
					m_Bar.FillStyles(i) = New NColorFillStyle(RandomColor())
				Next i

				m_Bar.Legend.Mode = SeriesLegendMode.DataPoints
			Else
				BarFillStyleButton.Enabled = True

				m_Bar.FillStyles.Clear()
				m_Bar.Legend.Mode = SeriesLegendMode.Series
			End If

			nChartControl1.Refresh()
		End Sub
		Private Sub WidthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles WidthScroll.ValueChanged
			m_Bar.WidthPercent = WidthScroll.Value
			nChartControl1.Refresh()
		End Sub
		Private Sub BarFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarFillStyleButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_Bar.FillStyle, fillStyleResult) Then
				m_Bar.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub BarBorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarBorderButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Bar.BorderStyle, strokeStyleResult) Then
				m_Bar.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub LineStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LineStyleButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Line.BorderStyle, strokeStyleResult) Then
				m_Line.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub MarkersFillButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MarkersFillButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_Line.MarkerStyle.FillStyle, fillStyleResult) Then
				m_Line.MarkerStyle.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub MarkersBorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MarkersBorderButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Line.MarkerStyle.BorderStyle, strokeStyleResult) Then
				m_Line.MarkerStyle.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace