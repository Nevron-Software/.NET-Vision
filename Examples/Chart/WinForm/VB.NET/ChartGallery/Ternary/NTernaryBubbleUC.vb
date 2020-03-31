Imports Nevron.Chart
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports System
Imports System.ComponentModel
Imports System.Drawing


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NTernaryBubbleUC
		Inherits NExampleBaseUC

		Private m_BubbleSeries As NTernaryBubbleSeries
		Private label1 As System.Windows.Forms.Label
		Private WithEvents BubbleShapeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private WithEvents MinBubbleSizeScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents MaxBubbleSizeScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents DifferentColors As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents BubbleFE As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BubbleBorderButton As Nevron.UI.WinForm.Controls.NButton
		Private groupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.BubbleShapeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.MinBubbleSizeScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.MaxBubbleSizeScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.DifferentColors = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.BubbleFE = New Nevron.UI.WinForm.Controls.NButton()
			Me.BubbleBorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.groupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.groupBox3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(9, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(150, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Bubble Shape:"
			' 
			' BubbleShapeCombo
			' 
			Me.BubbleShapeCombo.ListProperties.CheckBoxDataMember = ""
			Me.BubbleShapeCombo.ListProperties.DataSource = Nothing
			Me.BubbleShapeCombo.ListProperties.DisplayMember = ""
			Me.BubbleShapeCombo.Location = New System.Drawing.Point(9, 28)
			Me.BubbleShapeCombo.Name = "BubbleShapeCombo"
			Me.BubbleShapeCombo.Size = New System.Drawing.Size(150, 21)
			Me.BubbleShapeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BubbleShapeCombo.SelectedIndexChanged += new System.EventHandler(this.BubbleShapeCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 58)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(150, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Min Bubble Size:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(9, 103)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(150, 16)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Max Bubble Size:"
			' 
			' MinBubbleSizeScroll
			' 
			Me.MinBubbleSizeScroll.Location = New System.Drawing.Point(9, 75)
			Me.MinBubbleSizeScroll.Maximum = 60
			Me.MinBubbleSizeScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.MinBubbleSizeScroll.Name = "MinBubbleSizeScroll"
			Me.MinBubbleSizeScroll.Size = New System.Drawing.Size(150, 16)
			Me.MinBubbleSizeScroll.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MinBubbleSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.MinBubbleSizeScroll_Scroll);
			' 
			' MaxBubbleSizeScroll
			' 
			Me.MaxBubbleSizeScroll.Location = New System.Drawing.Point(9, 120)
			Me.MaxBubbleSizeScroll.Maximum = 60
			Me.MaxBubbleSizeScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.MaxBubbleSizeScroll.Name = "MaxBubbleSizeScroll"
			Me.MaxBubbleSizeScroll.Size = New System.Drawing.Size(150, 16)
			Me.MaxBubbleSizeScroll.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MaxBubbleSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.MaxBubbleSizeScroll_Scroll);
			' 
			' DifferentColors
			' 
			Me.DifferentColors.ButtonProperties.BorderOffset = 2
			Me.DifferentColors.Location = New System.Drawing.Point(9, 16)
			Me.DifferentColors.Name = "DifferentColors"
			Me.DifferentColors.Size = New System.Drawing.Size(132, 20)
			Me.DifferentColors.TabIndex = 0
			Me.DifferentColors.Text = "Different Colors"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DifferentColors.CheckedChanged += new System.EventHandler(this.DifferentColors_CheckedChanged);
			' 
			' BubbleFE
			' 
			Me.BubbleFE.Location = New System.Drawing.Point(9, 39)
			Me.BubbleFE.Name = "BubbleFE"
			Me.BubbleFE.Size = New System.Drawing.Size(132, 23)
			Me.BubbleFE.TabIndex = 1
			Me.BubbleFE.Text = "Bubble Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BubbleFE.Click += new System.EventHandler(this.BubbleFE_Click);
			' 
			' BubbleBorderButton
			' 
			Me.BubbleBorderButton.Location = New System.Drawing.Point(9, 68)
			Me.BubbleBorderButton.Name = "BubbleBorderButton"
			Me.BubbleBorderButton.Size = New System.Drawing.Size(132, 23)
			Me.BubbleBorderButton.TabIndex = 2
			Me.BubbleBorderButton.Text = "Bubble Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BubbleBorderButton.Click += new System.EventHandler(this.BubbleBorderButton_Click);
			' 
			' groupBox3
			' 
			Me.groupBox3.Controls.Add(Me.BubbleFE)
			Me.groupBox3.Controls.Add(Me.BubbleBorderButton)
			Me.groupBox3.Controls.Add(Me.DifferentColors)
			Me.groupBox3.ImageIndex = 0
			Me.groupBox3.Location = New System.Drawing.Point(9, 151)
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.Size = New System.Drawing.Size(150, 100)
			Me.groupBox3.TabIndex = 8
			Me.groupBox3.TabStop = False
			Me.groupBox3.Text = "Appearance"
			' 
			' NTernaryBubbleUC
			' 
			Me.Controls.Add(Me.groupBox3)
			Me.Controls.Add(Me.MaxBubbleSizeScroll)
			Me.Controls.Add(Me.MinBubbleSizeScroll)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.BubbleShapeCombo)
			Me.Controls.Add(Me.label1)
			Me.Name = "NTernaryBubbleUC"
			Me.Size = New System.Drawing.Size(180, 389)
			Me.groupBox3.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Ternary Bubble Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic)

			Dim legend As New NLegend()
			nChartControl1.Panels.Add(legend)

			' setup chart
			Dim ternaryChart As New NTernaryChart()
			nChartControl1.Panels.Add(ternaryChart)
			ternaryChart.DisplayOnLegend = legend

			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryA))
			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryB))
			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryC))

			' add a bubble series
			m_BubbleSeries = New NTernaryBubbleSeries()
			ternaryChart.Series.Add(m_BubbleSeries)
			m_BubbleSeries.DataLabelStyle.VertAlign = VertAlign.Center
			m_BubbleSeries.DataLabelStyle.Visible = False
			m_BubbleSeries.Legend.Mode = SeriesLegendMode.DataPoints
			m_BubbleSeries.MinSize = New NLength(2.0F, NGraphicsUnit.Point)
			m_BubbleSeries.MaxSize = New NLength(20, NGraphicsUnit.Point)
			m_BubbleSeries.Legend.Mode = SeriesLegendMode.DataPoints
			m_BubbleSeries.Legend.Format = "<size>"

			Dim rand As New Random()
			For i As Integer = 0 To 19
				' will be automatically normalized so that the sum of a, b, c value is 100
				Dim aValue As Double = rand.Next(100)
				Dim bValue As Double = rand.Next(100)
				Dim cValue As Double = rand.Next(100)

				m_BubbleSeries.AValues.Add(aValue)
				m_BubbleSeries.BValues.Add(bValue)
				m_BubbleSeries.CValues.Add(cValue)
				m_BubbleSeries.Sizes.Add(10 + rand.Next(90))
			Next i

			' apply layout
			ConfigureStandardLayout(ternaryChart, title, nChartControl1.Legends(0))

			' init form controls
			BubbleShapeCombo.FillFromEnum(GetType(PointShape))
			BubbleShapeCombo.SelectedIndex = 6

			DifferentColors.Checked = True
		End Sub

		Private Sub ConfigureAxis(ByVal axis As NAxis)
			Dim linearScale As NLinearScaleConfigurator = TryCast(axis.ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(25, Color.Beige)), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Ternary, True)
			linearScale.StripStyles.Add(stripStyle)

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Ternary, True)
		End Sub

		Private Sub BubbleShapeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BubbleShapeCombo.SelectedIndexChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_BubbleSeries.Shape = CType(BubbleShapeCombo.SelectedIndex, PointShape)
			nChartControl1.Refresh()
		End Sub
		Private Sub MinBubbleSizeScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles MinBubbleSizeScroll.ValueChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_BubbleSeries.MinSize = New NLength(MinBubbleSizeScroll.Value, NRelativeUnit.ParentPercentage)
			nChartControl1.Refresh()
		End Sub
		Private Sub MaxBubbleSizeScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles MaxBubbleSizeScroll.ValueChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_BubbleSeries.MaxSize = New NLength(MaxBubbleSizeScroll.Value, NRelativeUnit.ParentPercentage)
			nChartControl1.Refresh()
		End Sub
		Private Sub DifferentColors_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DifferentColors.CheckedChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			If DifferentColors.Checked Then
				BubbleFE.Enabled = False
				BubbleBorderButton.Enabled = False

				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
				styleSheet.Apply(nChartControl1.Document)
			Else
				BubbleFE.Enabled = True
				BubbleBorderButton.Enabled = True

				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
				styleSheet.Apply(nChartControl1.Document)
			End If

			nChartControl1.Refresh()
		End Sub
		Private Sub BubbleFE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BubbleFE.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_BubbleSeries.FillStyle, fillStyleResult) Then
				m_BubbleSeries.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub BubbleBorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BubbleBorderButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_BubbleSeries.BorderStyle, strokeStyleResult) Then
				m_BubbleSeries.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub LabelStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim styleResult As NDataLabelStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NDataLabelStyleTypeEditor.Edit(series.DataLabelStyle, styleResult) Then
				series.DataLabelStyle = styleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
