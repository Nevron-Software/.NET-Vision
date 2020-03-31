Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NEmptyDataPointsGeneralUC
		Inherits NExampleBaseUC

		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox4 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents CustomValue As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents ValueModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents AppearanceModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents MarkerModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents ShowLabelsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents BorderButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents FillButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents SeriesStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents SeriesFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents SeriesMarkerStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents EDPMarkerButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ShadowStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents SeriesTypeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents SeriesDataLabelButton As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private components As System.ComponentModel.IContainer = Nothing

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

		#Region "Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As New System.Resources.ResourceManager(GetType(NEmptyDataPointsGeneralUC))
			Me.groupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.CustomValue = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.ValueModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.groupBox4 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.AppearanceModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.BorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.FillButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label2 = New System.Windows.Forms.Label()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.MarkerModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.EDPMarkerButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label4 = New System.Windows.Forms.Label()
			Me.ShowLabelsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SeriesStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SeriesFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SeriesMarkerStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.SeriesDataLabelButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShadowStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SeriesTypeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.groupBox3.SuspendLayout()
			Me.groupBox4.SuspendLayout()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupBox3
			' 
			Me.groupBox3.Controls.Add(Me.CustomValue)
			Me.groupBox3.Controls.Add(Me.label3)
			Me.groupBox3.Controls.Add(Me.label1)
			Me.groupBox3.Controls.Add(Me.ValueModeCombo)
			Me.groupBox3.ImageIndex = 0
			Me.groupBox3.Location = New System.Drawing.Point(8, 48)
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.Size = New System.Drawing.Size(216, 120)
			Me.groupBox3.TabIndex = 13
			Me.groupBox3.TabStop = False
			Me.groupBox3.Text = "Empty Data Point Analisys"
			' 
			' CustomValue
			' 
			Me.CustomValue.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.CustomValue.Enabled = False
			Me.CustomValue.Location = New System.Drawing.Point(8, 88)
			Me.CustomValue.Name = "CustomValue"
			Me.CustomValue.Size = New System.Drawing.Size(197, 20)
			Me.CustomValue.TabIndex = 3
			Me.CustomValue.Text = "0"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.CustomValue.TextChanged += new System.EventHandler(this.CustomValue_TextChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 72)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(100, 13)
			Me.label3.TabIndex = 2
			Me.label3.Text = "Custom Value:"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(166, 14)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Empty Data Points Value Mode:"
			' 
			' ValueModeCombo
			' 
			Me.ValueModeCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.ValueModeCombo.Location = New System.Drawing.Point(8, 40)
			Me.ValueModeCombo.Name = "ValueModeCombo"
			Me.ValueModeCombo.Size = New System.Drawing.Size(197, 21)
			Me.ValueModeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ValueModeCombo.SelectedIndexChanged += new System.EventHandler(this.ValueModeCombo_SelectedIndexChanged);
			' 
			' groupBox4
			' 
			Me.groupBox4.Controls.Add(Me.AppearanceModeCombo)
			Me.groupBox4.Controls.Add(Me.BorderButton)
			Me.groupBox4.Controls.Add(Me.FillButton)
			Me.groupBox4.Controls.Add(Me.label2)
			Me.groupBox4.ImageIndex = 0
			Me.groupBox4.Location = New System.Drawing.Point(8, 184)
			Me.groupBox4.Name = "groupBox4"
			Me.groupBox4.Size = New System.Drawing.Size(216, 104)
			Me.groupBox4.TabIndex = 14
			Me.groupBox4.TabStop = False
			Me.groupBox4.Text = "Empty Data Points Apperance"
			' 
			' AppearanceModeCombo
			' 
			Me.AppearanceModeCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.AppearanceModeCombo.Location = New System.Drawing.Point(8, 43)
			Me.AppearanceModeCombo.Name = "AppearanceModeCombo"
			Me.AppearanceModeCombo.Size = New System.Drawing.Size(200, 21)
			Me.AppearanceModeCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AppearanceModeCombo.SelectedIndexChanged += new System.EventHandler(this.AppearanceModeCombo_SelectedIndexChanged);
			' 
			' BorderButton
			' 
			Me.BorderButton.Location = New System.Drawing.Point(112, 74)
			Me.BorderButton.Name = "BorderButton"
			Me.BorderButton.Size = New System.Drawing.Size(93, 23)
			Me.BorderButton.TabIndex = 10
			Me.BorderButton.Text = "Stroke Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BorderButton.Click += new System.EventHandler(this.BorderButton_Click);
			' 
			' FillButton
			' 
			Me.FillButton.Location = New System.Drawing.Point(8, 74)
			Me.FillButton.Name = "FillButton"
			Me.FillButton.Size = New System.Drawing.Size(93, 23)
			Me.FillButton.TabIndex = 9
			Me.FillButton.Text = "Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FillButton.Click += new System.EventHandler(this.FillButton_Click);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(12, 22)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(188, 19)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Appearance Mode: "
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.MarkerModeCombo)
			Me.groupBox1.Controls.Add(Me.EDPMarkerButton)
			Me.groupBox1.Controls.Add(Me.label4)
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(8, 304)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(216, 104)
			Me.groupBox1.TabIndex = 15
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Empty Data Points Marker"
			' 
			' MarkerModeCombo
			' 
			Me.MarkerModeCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.MarkerModeCombo.Location = New System.Drawing.Point(8, 40)
			Me.MarkerModeCombo.Name = "MarkerModeCombo"
			Me.MarkerModeCombo.Size = New System.Drawing.Size(197, 21)
			Me.MarkerModeCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerModeCombo.SelectedIndexChanged += new System.EventHandler(this.MarkerModeCombo_SelectedIndexChanged);
			' 
			' EDPMarkerButton
			' 
			Me.EDPMarkerButton.Location = New System.Drawing.Point(8, 72)
			Me.EDPMarkerButton.Name = "EDPMarkerButton"
			Me.EDPMarkerButton.Size = New System.Drawing.Size(93, 23)
			Me.EDPMarkerButton.TabIndex = 9
			Me.EDPMarkerButton.Text = "Marker..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EDPMarkerButton.Click += new System.EventHandler(this.EDPMarkerButton_Click);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 24)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(197, 19)
			Me.label4.TabIndex = 2
			Me.label4.Text = "Marker Mode:"
			' 
			' ShowLabelsCheck
			' 
			Me.ShowLabelsCheck.Location = New System.Drawing.Point(16, 416)
			Me.ShowLabelsCheck.Name = "ShowLabelsCheck"
			Me.ShowLabelsCheck.Size = New System.Drawing.Size(200, 19)
			Me.ShowLabelsCheck.TabIndex = 16
			Me.ShowLabelsCheck.Text = "Show labels for empty data points"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowLabelsCheck.CheckedChanged += new System.EventHandler(this.ShowLabelsCheck_CheckedChanged);
			' 
			' SeriesStrokeStyleButton
			' 
			Me.SeriesStrokeStyleButton.Location = New System.Drawing.Point(112, 24)
			Me.SeriesStrokeStyleButton.Name = "SeriesStrokeStyleButton"
			Me.SeriesStrokeStyleButton.Size = New System.Drawing.Size(93, 23)
			Me.SeriesStrokeStyleButton.TabIndex = 19
			Me.SeriesStrokeStyleButton.Text = "Stroke Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SeriesStrokeStyleButton.Click += new System.EventHandler(this.SeriesStrokeStyleButton_Click);
			' 
			' SeriesFillStyleButton
			' 
			Me.SeriesFillStyleButton.Location = New System.Drawing.Point(8, 24)
			Me.SeriesFillStyleButton.Name = "SeriesFillStyleButton"
			Me.SeriesFillStyleButton.Size = New System.Drawing.Size(93, 23)
			Me.SeriesFillStyleButton.TabIndex = 18
			Me.SeriesFillStyleButton.Text = "Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SeriesFillStyleButton.Click += new System.EventHandler(this.SeriesFillStyleButton_Click);
			' 
			' SeriesMarkerStyleButton
			' 
			Me.SeriesMarkerStyleButton.Location = New System.Drawing.Point(8, 56)
			Me.SeriesMarkerStyleButton.Name = "SeriesMarkerStyleButton"
			Me.SeriesMarkerStyleButton.Size = New System.Drawing.Size(93, 23)
			Me.SeriesMarkerStyleButton.TabIndex = 20
			Me.SeriesMarkerStyleButton.Text = "Marker..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SeriesMarkerStyleButton.Click += new System.EventHandler(this.SeriesMarkerStyleButton_Click);
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.SeriesDataLabelButton)
			Me.groupBox2.Controls.Add(Me.ShadowStyleButton)
			Me.groupBox2.Controls.Add(Me.SeriesFillStyleButton)
			Me.groupBox2.Controls.Add(Me.SeriesStrokeStyleButton)
			Me.groupBox2.Controls.Add(Me.SeriesMarkerStyleButton)
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(8, 440)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(216, 120)
			Me.groupBox2.TabIndex = 16
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Series Styles"
			' 
			' SeriesDataLabelButton
			' 
			Me.SeriesDataLabelButton.Location = New System.Drawing.Point(112, 56)
			Me.SeriesDataLabelButton.Name = "SeriesDataLabelButton"
			Me.SeriesDataLabelButton.Size = New System.Drawing.Size(93, 23)
			Me.SeriesDataLabelButton.TabIndex = 22
			Me.SeriesDataLabelButton.Text = "Data Label..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SeriesDataLabelButton.Click += new System.EventHandler(this.SeriesDataLabelButton_Click);
			' 
			' ShadowStyleButton
			' 
			Me.ShadowStyleButton.Location = New System.Drawing.Point(8, 88)
			Me.ShadowStyleButton.Name = "ShadowStyleButton"
			Me.ShadowStyleButton.Size = New System.Drawing.Size(93, 23)
			Me.ShadowStyleButton.TabIndex = 21
			Me.ShadowStyleButton.Text = "Shadow Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShadowStyleButton.Click += new System.EventHandler(this.ShadowStyleButton_Click);
			' 
			' SeriesTypeCombo
			' 
			Me.SeriesTypeCombo.Location = New System.Drawing.Point(16, 16)
			Me.SeriesTypeCombo.Name = "SeriesTypeCombo"
			Me.SeriesTypeCombo.Size = New System.Drawing.Size(200, 21)
			Me.SeriesTypeCombo.TabIndex = 17
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SeriesTypeCombo.SelectedIndexChanged += new System.EventHandler(this.SeriesTypeCombo_SelectedIndexChanged);
			' 
			' NEmptyDataPointsGeneralUC
			' 
			Me.Controls.Add(Me.SeriesTypeCombo)
			Me.Controls.Add(Me.ShowLabelsCheck)
			Me.Controls.Add(Me.groupBox4)
			Me.Controls.Add(Me.groupBox3)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.groupBox2)
			Me.Name = "NEmptyDataPointsGeneralUC"
			Me.Size = New System.Drawing.Size(232, 568)
			Me.groupBox3.ResumeLayout(False)
			Me.groupBox4.ResumeLayout(False)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Empty Data Points")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))


			SeriesTypeCombo.Items.Add("Bar")
			SeriesTypeCombo.Items.Add("Line")
			SeriesTypeCombo.Items.Add("Area")
			SeriesTypeCombo.Items.Add("SmoothLine")
			SeriesTypeCombo.Items.Add("Point")

			ValueModeCombo.FillFromEnum(GetType(EmptyDataPointsValueMode))
			AppearanceModeCombo.FillFromEnum(GetType(EmptyDataPointsAppearanceMode))
			MarkerModeCombo.FillFromEnum(GetType(EmptyDataPointsMarkerMode))

			SeriesTypeCombo.SelectedIndex = 0
		End Sub

		Private Sub GenerateData(ByVal series As NSeries, ByVal nTotalCount As Integer, ByVal nMaxEmptyCount As Integer)
			Dim arrEmptyIndices As New SortedList()

			For i As Integer = 0 To nMaxEmptyCount - 1
				Dim nEmptyIndex As Integer = Random.Next(0, nTotalCount)
				arrEmptyIndices(nEmptyIndex) = Nothing
			Next i

			For k As Integer = 0 To nTotalCount - 1
				If arrEmptyIndices.ContainsKey(k) Then
					series.Values.Add(DBNull.Value)
				Else
					series.Values.Add(Random.NextDouble() * 10)
				End If
			Next k
		End Sub

		Private Sub SeriesTypeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SeriesTypeCombo.SelectedIndexChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim seriesType As SeriesType = Nevron.Chart.SeriesType.Bar

			Select Case SeriesTypeCombo.SelectedIndex
				Case 0
					seriesType = Nevron.Chart.SeriesType.Bar
				Case 1
					seriesType = Nevron.Chart.SeriesType.Line
				Case 2
					seriesType = Nevron.Chart.SeriesType.Area
				Case 3
					seriesType = Nevron.Chart.SeriesType.SmoothLine
				Case 4
					seriesType = Nevron.Chart.SeriesType.Point
			End Select

			Dim chart As NChart = nChartControl1.Charts(0)

			chart.Series.Clear()

			Dim series As NSeries = CType(chart.Series.Add(seriesType), NSeries)
			series.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			series.Legend.Mode = SeriesLegendMode.DataPoints
			series.EmptyDataPointsAppearance.MarkerMode = EmptyDataPointsMarkerMode.Normal

			GenerateData(series, 10, 3)

			nChartControl1.Refresh()

			ValueModeCombo.SelectedIndex = 0
			AppearanceModeCombo.SelectedIndex = 0
			MarkerModeCombo.SelectedIndex = 0
			ShowLabelsCheck.Checked = False
			CustomValue.Text = "0"
		End Sub

		Private Sub ValueModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValueModeCombo.SelectedIndexChanged
			If nChartControl1 IsNot Nothing Then
				CustomValue.Enabled = (ValueModeCombo.SelectedIndex = 2)

				Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)
				series.Values.EmptyDataPoints.ValueMode = CType(ValueModeCombo.SelectedIndex, EmptyDataPointsValueMode)

				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub CustomValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CustomValue.TextChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim dValue As Double = 0

			Try
				dValue = Double.Parse(CustomValue.Text)
			Catch
				Return
			End Try

			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)
			series.Values.EmptyDataPoints.CustomValue = dValue

			nChartControl1.Refresh()
		End Sub

		Private Sub AppearanceModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AppearanceModeCombo.SelectedIndexChanged
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			series.EmptyDataPointsAppearance.AppearanceMode = CType(AppearanceModeCombo.SelectedIndex, EmptyDataPointsAppearanceMode)

			nChartControl1.Refresh()
		End Sub

		Private Sub MarkerModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MarkerModeCombo.SelectedIndexChanged
			If nChartControl1 IsNot Nothing Then
				Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

				series.EmptyDataPointsAppearance.MarkerMode = CType(MarkerModeCombo.SelectedIndex, EmptyDataPointsMarkerMode)

				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub FillButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FillButton.Click
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(series.EmptyDataPointsAppearance.FillStyle, fillStyleResult) Then
				series.EmptyDataPointsAppearance.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BorderButton.Click
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(series.EmptyDataPointsAppearance.BorderStyle, strokeStyleResult) Then
				series.EmptyDataPointsAppearance.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub ShowLabelsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowLabelsCheck.CheckedChanged
			If nChartControl1 IsNot Nothing Then
				Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

				If ShowLabelsCheck.Checked Then
					series.EmptyDataPointsAppearance.DataLabelMode = EmptyDataPointsLabelMode.Normal
				Else
					series.EmptyDataPointsAppearance.DataLabelMode = EmptyDataPointsLabelMode.Special
					series.EmptyDataPointsAppearance.DataLabelStyle.Visible = False
				End If

				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub EDPMarkerButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EDPMarkerButton.Click
			Dim markerStyleResult As NMarkerStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NMarkerStyleTypeEditor.Edit(series.EmptyDataPointsAppearance.MarkerStyle, markerStyleResult) Then
				series.EmptyDataPointsAppearance.MarkerStyle = markerStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub SeriesFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SeriesFillStyleButton.Click
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(series.FillStyle, fillStyleResult) Then
				series.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub SeriesStrokeStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SeriesStrokeStyleButton.Click
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(series.BorderStyle, strokeStyleResult) Then
				series.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub SeriesMarkerStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SeriesMarkerStyleButton.Click
			Dim markerStyleResult As NMarkerStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NMarkerStyleTypeEditor.Edit(series.MarkerStyle, markerStyleResult) Then
				series.MarkerStyle = markerStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub SeriesDataLabelButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SeriesDataLabelButton.Click
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)
			Dim dataLabelStyleResult As NDataLabelStyle = Nothing

			If NDataLabelStyleTypeEditor.Edit(series.DataLabelStyle, dataLabelStyleResult) Then
				series.DataLabelStyle = dataLabelStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub ShadowStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShadowStyleButton.Click
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)
			Dim shadowStyleResult As NShadowStyle = Nothing

			If NShadowStyleTypeEditor.Edit(series.ShadowStyle, shadowStyleResult) Then
				series.ShadowStyle = shadowStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace

