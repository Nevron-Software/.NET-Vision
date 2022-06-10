Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NTernaryPointUC
		Inherits NExampleBaseUC

		Private m_Point As NTernaryPointSeries
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents DifferentColorsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents PointStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents PointSizeScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents FillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LinePropertiesButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ShadowButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents dataLabelStyleButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.PointStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.PointSizeScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.FillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.DifferentColorsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.LinePropertiesButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShadowButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.dataLabelStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(4, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(172, 21)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Point Style:"
			' 
			' PointStyleCombo
			' 
			Me.PointStyleCombo.ListProperties.CheckBoxDataMember = ""
			Me.PointStyleCombo.ListProperties.DataSource = Nothing
			Me.PointStyleCombo.ListProperties.DisplayMember = ""
			Me.PointStyleCombo.Location = New System.Drawing.Point(4, 25)
			Me.PointStyleCombo.Name = "PointStyleCombo"
			Me.PointStyleCombo.Size = New System.Drawing.Size(172, 21)
			Me.PointStyleCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PointStyleCombo.SelectedIndexChanged += new System.EventHandler(this.PointStyleCombo_SelectedIndexChanged);
			' 
			' PointSizeScroll
			' 
			Me.PointSizeScroll.LargeChange = 1
			Me.PointSizeScroll.Location = New System.Drawing.Point(4, 73)
			Me.PointSizeScroll.Maximum = 12
			Me.PointSizeScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.PointSizeScroll.Name = "PointSizeScroll"
			Me.PointSizeScroll.Size = New System.Drawing.Size(172, 18)
			Me.PointSizeScroll.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PointSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.PointSizeScroll_Scroll);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(4, 57)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(172, 21)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Point Size:"
			' 
			' FillStyleButton
			' 
			Me.FillStyleButton.Location = New System.Drawing.Point(4, 145)
			Me.FillStyleButton.Name = "FillStyleButton"
			Me.FillStyleButton.Size = New System.Drawing.Size(172, 23)
			Me.FillStyleButton.TabIndex = 5
			Me.FillStyleButton.Text = "Point Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FillStyleButton.Click += new System.EventHandler(this.FillStyleButton_Click);
			' 
			' DifferentColorsCheck
			' 
			Me.DifferentColorsCheck.ButtonProperties.BorderOffset = 2
			Me.DifferentColorsCheck.Location = New System.Drawing.Point(4, 105)
			Me.DifferentColorsCheck.Name = "DifferentColorsCheck"
			Me.DifferentColorsCheck.Size = New System.Drawing.Size(172, 21)
			Me.DifferentColorsCheck.TabIndex = 4
			Me.DifferentColorsCheck.Text = "Different Colors"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DifferentColorsCheck.CheckedChanged += new System.EventHandler(this.DifferentColorsCheck_CheckedChanged);
			' 
			' LinePropertiesButton
			' 
			Me.LinePropertiesButton.Location = New System.Drawing.Point(4, 173)
			Me.LinePropertiesButton.Name = "LinePropertiesButton"
			Me.LinePropertiesButton.Size = New System.Drawing.Size(172, 23)
			Me.LinePropertiesButton.TabIndex = 6
			Me.LinePropertiesButton.Text = "Point Stroke Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LinePropertiesButton.Click += new System.EventHandler(this.LinePropertiesButton_Click);
			' 
			' ShadowButton
			' 
			Me.ShadowButton.Location = New System.Drawing.Point(4, 201)
			Me.ShadowButton.Name = "ShadowButton"
			Me.ShadowButton.Size = New System.Drawing.Size(172, 23)
			Me.ShadowButton.TabIndex = 7
			Me.ShadowButton.Text = "Point Shadow..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShadowButton.Click += new System.EventHandler(this.ShadowButton_Click);
			' 
			' dataLabelStyleButton
			' 
			Me.dataLabelStyleButton.Location = New System.Drawing.Point(4, 228)
			Me.dataLabelStyleButton.Name = "dataLabelStyleButton"
			Me.dataLabelStyleButton.Size = New System.Drawing.Size(172, 23)
			Me.dataLabelStyleButton.TabIndex = 8
			Me.dataLabelStyleButton.Text = "Data Label Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.dataLabelStyleButton.Click += new System.EventHandler(this.dataLabelStyleButton_Click);
			' 
			' NTernaryPointUC
			' 
			Me.Controls.Add(Me.dataLabelStyleButton)
			Me.Controls.Add(Me.ShadowButton)
			Me.Controls.Add(Me.LinePropertiesButton)
			Me.Controls.Add(Me.DifferentColorsCheck)
			Me.Controls.Add(Me.FillStyleButton)
			Me.Controls.Add(Me.PointSizeScroll)
			Me.Controls.Add(Me.PointStyleCombo)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Name = "NTernaryPointUC"
			Me.Size = New System.Drawing.Size(180, 320)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Ternary Point Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			Dim legend As New NLegend()
			nChartControl1.Panels.Add(legend)

			' setup chart
			Dim ternaryChart As New NTernaryChart()
			nChartControl1.Panels.Add(ternaryChart)
			ternaryChart.DisplayOnLegend = legend

			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryA))
			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryB))
			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryC))

			m_Point = New NTernaryPointSeries()
			ternaryChart.Series.Add(m_Point)

			' setup point series
			m_Point.Name = "Ternary Point Series"

			Dim rand As New Random()
			For i As Integer = 0 To 19
				' will be automatically normalized so that the sum of a, b, c value is 100
				Dim aValue As Double = rand.Next(100)
				Dim bValue As Double = rand.Next(100)
				Dim cValue As Double = rand.Next(100)

				m_Point.AValues.Add(aValue)
				m_Point.BValues.Add(bValue)
				m_Point.CValues.Add(cValue)
			Next i

			' apply layout
			ConfigureStandardLayout(ternaryChart, title, legend)

			' init form controls
			PointStyleCombo.FillFromEnum(GetType(PointShape))
			PointStyleCombo.SelectedIndex = 0
			DifferentColorsCheck.Checked = True
			PointSizeScroll.Value = 3
		End Sub

		Private Sub ConfigureAxis(ByVal axis As NAxis)
			Dim linearScale As NLinearScaleConfigurator = TryCast(axis.ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(25, Color.Beige)), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Ternary, True)
			linearScale.StripStyles.Add(stripStyle)

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Ternary, True)
		End Sub
		Private Sub PointStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PointStyleCombo.SelectedIndexChanged
			m_Point.Shape = CType(PointStyleCombo.SelectedIndex, PointShape)
			nChartControl1.Refresh()
		End Sub

		Private Sub PointSizeScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles PointSizeScroll.ValueChanged
			m_Point.Size = New NLength(PointSizeScroll.Value, NGraphicsUnit.Point)
			nChartControl1.Refresh()
		End Sub

		Private Sub FillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FillStyleButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_Point.FillStyle, fillStyleResult) Then
				m_Point.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub LinePropertiesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinePropertiesButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Point.BorderStyle, strokeStyleResult) Then
				m_Point.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub ShadowButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShadowButton.Click
			Dim shadowStyleResult As NShadowStyle = Nothing

			If NShadowStyleTypeEditor.Edit(m_Point.ShadowStyle, shadowStyleResult) Then
				m_Point.ShadowStyle = shadowStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub dataLabelStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dataLabelStyleButton.Click
			Dim result As NDataLabelStyle = Nothing

			If NDataLabelStyleTypeEditor.Edit(m_Point.DataLabelStyle, result) Then
				m_Point.DataLabelStyle = result
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub DifferentColorsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DifferentColorsCheck.CheckedChanged
			If DifferentColorsCheck.Checked Then
				FillStyleButton.Enabled = False

				m_Point.Legend.Mode = SeriesLegendMode.DataPoints

				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
				styleSheet.Apply(nChartControl1.Document)
			Else
				FillStyleButton.Enabled = True

				m_Point.Legend.Mode = SeriesLegendMode.Series

				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
				styleSheet.Apply(nChartControl1.Document)
			End If

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace