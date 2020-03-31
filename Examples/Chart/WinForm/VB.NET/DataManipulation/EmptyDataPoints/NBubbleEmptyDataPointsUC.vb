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
	Public Class NBubbleEmptyDataPointsUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bubble As NBubbleSeries
		Private WithEvents ShowLabelsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private groupBox4 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents AppearanceModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents BorderButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents FillButton As Nevron.UI.WinForm.Controls.NButton
		Private label2 As System.Windows.Forms.Label
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents MarkerModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents EDPMarkerButton As Nevron.UI.WinForm.Controls.NButton
		Private label4 As System.Windows.Forms.Label
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents SeriesDataLabelButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ShadowStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents SeriesFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents SeriesStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents SeriesMarkerStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents NewDataButton As Nevron.UI.WinForm.Controls.NButton
		Private components As System.ComponentModel.IContainer = Nothing

		Public Sub New()
			InitializeComponent()

			AppearanceModeCombo.FillFromEnum(GetType(EmptyDataPointsAppearanceMode))
			MarkerModeCombo.FillFromEnum(GetType(EmptyDataPointsMarkerMode))
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
			Dim resources As New System.Resources.ResourceManager(GetType(NBubbleEmptyDataPointsUC))
			Me.ShowLabelsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox4 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.AppearanceModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.BorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.FillButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label2 = New System.Windows.Forms.Label()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.MarkerModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.EDPMarkerButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label4 = New System.Windows.Forms.Label()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.SeriesDataLabelButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShadowStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SeriesFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SeriesStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SeriesMarkerStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.NewDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.groupBox4.SuspendLayout()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' ShowLabelsCheck
			' 
			Me.ShowLabelsCheck.Location = New System.Drawing.Point(16, 238)
			Me.ShowLabelsCheck.Name = "ShowLabelsCheck"
			Me.ShowLabelsCheck.Size = New System.Drawing.Size(200, 21)
			Me.ShowLabelsCheck.TabIndex = 20
			Me.ShowLabelsCheck.Text = "Show labels for empty data points"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowLabelsCheck.CheckedChanged += new System.EventHandler(this.ShowLabelsCheck_CheckedChanged);
			' 
			' groupBox4
			' 
			Me.groupBox4.Controls.Add(Me.AppearanceModeCombo)
			Me.groupBox4.Controls.Add(Me.BorderButton)
			Me.groupBox4.Controls.Add(Me.FillButton)
			Me.groupBox4.Controls.Add(Me.label2)
			Me.groupBox4.ImageIndex = 0
			Me.groupBox4.Location = New System.Drawing.Point(8, 8)
			Me.groupBox4.Name = "groupBox4"
			Me.groupBox4.Size = New System.Drawing.Size(216, 104)
			Me.groupBox4.TabIndex = 17
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
			Me.groupBox1.Location = New System.Drawing.Point(8, 128)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(216, 104)
			Me.groupBox1.TabIndex = 18
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
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.SeriesDataLabelButton)
			Me.groupBox2.Controls.Add(Me.ShadowStyleButton)
			Me.groupBox2.Controls.Add(Me.SeriesFillStyleButton)
			Me.groupBox2.Controls.Add(Me.SeriesStrokeStyleButton)
			Me.groupBox2.Controls.Add(Me.SeriesMarkerStyleButton)
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(8, 264)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(216, 120)
			Me.groupBox2.TabIndex = 19
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
			' NewDataButton
			' 
			Me.NewDataButton.Location = New System.Drawing.Point(16, 400)
			Me.NewDataButton.Name = "NewDataButton"
			Me.NewDataButton.Size = New System.Drawing.Size(200, 32)
			Me.NewDataButton.TabIndex = 21
			Me.NewDataButton.Text = "New Data..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.NewDataButton.Click += new System.EventHandler(this.NewDataButton_Click);
			' 
			' NBubbleEmptyDataPointsUC
			' 
			Me.Controls.Add(Me.NewDataButton)
			Me.Controls.Add(Me.ShowLabelsCheck)
			Me.Controls.Add(Me.groupBox4)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.groupBox2)
			Me.Name = "NBubbleEmptyDataPointsUC"
			Me.Size = New System.Drawing.Size(232, 440)
			Me.groupBox4.ResumeLayout(False)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Bubble with Empty Data Points")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			m_Chart.Axis(StandardAxis.Depth).Visible = False
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()

			m_Bubble = CType(m_Chart.Series.Add(SeriesType.Bubble), NBubbleSeries)
			m_Bubble.InflateMargins = True
			m_Bubble.DataLabelStyle.Visible = False
			m_Bubble.BubbleShape = PointShape.Sphere
			m_Bubble.Legend.Format = "Size:<size>"
			m_Bubble.Legend.Mode = SeriesLegendMode.DataPoints
			m_Bubble.UseXValues = True
			m_Bubble.UseZValues = False

			m_Bubble.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			m_Bubble.Values.EmptyDataPoints.ValueMode = EmptyDataPointsValueMode.Average

			m_Bubble.XValues.ValueFormatter = New NNumericValueFormatter("0.00")
			m_Bubble.XValues.EmptyDataPoints.ValueMode = EmptyDataPointsValueMode.Average

			m_Bubble.Sizes.ValueFormatter = New NNumericValueFormatter("0.00")
			m_Bubble.Sizes.EmptyDataPoints.ValueMode = EmptyDataPointsValueMode.Average

			GenerateData()

			AppearanceModeCombo.SelectedIndex = 0
			MarkerModeCombo.SelectedIndex = 0
			ShowLabelsCheck.Checked = False
		End Sub

		Private Sub GenerateData()
			m_Bubble.Values.Clear()
			m_Bubble.XValues.Clear()
			m_Bubble.Sizes.Clear()

			For i As Integer = 0 To 7
				If (i = 2) OrElse (i = 5) Then
					m_Bubble.Values.Add(DBNull.Value)
					m_Bubble.XValues.Add(DBNull.Value)
					m_Bubble.Sizes.Add(DBNull.Value)
				Else
					m_Bubble.Values.Add(Random.NextDouble() * 5)
					m_Bubble.XValues.Add(Random.NextDouble() * 5)
					m_Bubble.Sizes.Add(Random.NextDouble())
				End If
			Next i
		End Sub

		Private Sub AppearanceModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AppearanceModeCombo.SelectedIndexChanged
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			series.EmptyDataPointsAppearance.AppearanceMode = CType(AppearanceModeCombo.SelectedIndex, EmptyDataPointsAppearanceMode)

			nChartControl1.Refresh()
		End Sub

		Private Sub MarkerModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MarkerModeCombo.SelectedIndexChanged
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			series.EmptyDataPointsAppearance.MarkerMode = CType(MarkerModeCombo.SelectedIndex, EmptyDataPointsMarkerMode)

			nChartControl1.Refresh()
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
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If ShowLabelsCheck.Checked Then
				series.EmptyDataPointsAppearance.DataLabelMode = EmptyDataPointsLabelMode.Normal
			Else
				series.EmptyDataPointsAppearance.DataLabelMode = EmptyDataPointsLabelMode.Special
				series.EmptyDataPointsAppearance.DataLabelStyle.Visible = False
			End If

			nChartControl1.Refresh()
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

		Private Sub NewDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewDataButton.Click
			GenerateData()
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace

