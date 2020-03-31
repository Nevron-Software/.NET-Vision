Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Collections
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NBoxAndWhiskers2DUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private WithEvents InflateMarginsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents RoundToTickCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private label2 As System.Windows.Forms.Label
		Private WithEvents GenerateDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BoxBorderStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BoxFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents OutliersFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents OutliersBorderStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents WhiskersBorderStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents shadowStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents WhiskersWidthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private label1 As System.Windows.Forms.Label
		Private WithEvents BoxWidthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
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
			Me.InflateMarginsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.RoundToTickCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.BoxBorderStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.BoxFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.WhiskersWidthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.GenerateDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.OutliersFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.OutliersBorderStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.WhiskersBorderStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.shadowStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.BoxWidthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.SuspendLayout()
			' 
			' InflateMarginsCheck
			' 
			Me.InflateMarginsCheck.ButtonProperties.BorderOffset = 2
			Me.InflateMarginsCheck.Location = New System.Drawing.Point(10, 316)
			Me.InflateMarginsCheck.Name = "InflateMarginsCheck"
			Me.InflateMarginsCheck.Size = New System.Drawing.Size(154, 20)
			Me.InflateMarginsCheck.TabIndex = 10
			Me.InflateMarginsCheck.Text = "Inflate Margins"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			' 
			' RoundToTickCheck
			' 
			Me.RoundToTickCheck.ButtonProperties.BorderOffset = 2
			Me.RoundToTickCheck.Location = New System.Drawing.Point(10, 340)
			Me.RoundToTickCheck.Name = "RoundToTickCheck"
			Me.RoundToTickCheck.Size = New System.Drawing.Size(154, 19)
			Me.RoundToTickCheck.TabIndex = 11
			Me.RoundToTickCheck.Text = "Left Axis Round to Tick"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RoundToTickCheck.CheckedChanged += new System.EventHandler(this.RoundToTickCheck_CheckedChanged);
			' 
			' BoxBorderStyleButton
			' 
			Me.BoxBorderStyleButton.Location = New System.Drawing.Point(10, 134)
			Me.BoxBorderStyleButton.Name = "BoxBorderStyleButton"
			Me.BoxBorderStyleButton.Size = New System.Drawing.Size(154, 24)
			Me.BoxBorderStyleButton.TabIndex = 5
			Me.BoxBorderStyleButton.Text = "Box Border Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BoxBorderStyleButton.Click += new System.EventHandler(this.BoxBorderStyleButton_Click);
			' 
			' BoxFillStyleButton
			' 
			Me.BoxFillStyleButton.Location = New System.Drawing.Point(10, 102)
			Me.BoxFillStyleButton.Name = "BoxFillStyleButton"
			Me.BoxFillStyleButton.Size = New System.Drawing.Size(154, 24)
			Me.BoxFillStyleButton.TabIndex = 4
			Me.BoxFillStyleButton.Text = "Box Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BoxFillStyleButton.Click += new System.EventHandler(this.BoxFillStyleButton_Click);
			' 
			' WhiskersWidthScroll
			' 
			Me.WhiskersWidthScroll.Location = New System.Drawing.Point(11, 70)
			Me.WhiskersWidthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.WhiskersWidthScroll.Name = "WhiskersWidthScroll"
			Me.WhiskersWidthScroll.Size = New System.Drawing.Size(152, 16)
			Me.WhiskersWidthScroll.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WhiskersWidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WhiskersWidthScroll_Scroll);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 54)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(154, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Whiskers Width:"
			' 
			' GenerateDataButton
			' 
			Me.GenerateDataButton.Location = New System.Drawing.Point(10, 372)
			Me.GenerateDataButton.Name = "GenerateDataButton"
			Me.GenerateDataButton.Size = New System.Drawing.Size(154, 24)
			Me.GenerateDataButton.TabIndex = 12
			Me.GenerateDataButton.Text = "Generate Data ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			' 
			' OutliersFillStyleButton
			' 
			Me.OutliersFillStyleButton.Location = New System.Drawing.Point(10, 166)
			Me.OutliersFillStyleButton.Name = "OutliersFillStyleButton"
			Me.OutliersFillStyleButton.Size = New System.Drawing.Size(154, 24)
			Me.OutliersFillStyleButton.TabIndex = 6
			Me.OutliersFillStyleButton.Text = "Outliers Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OutliersFillStyleButton.Click += new System.EventHandler(this.OutliersFillStyleButton_Click);
			' 
			' OutliersBorderStyleButton
			' 
			Me.OutliersBorderStyleButton.Location = New System.Drawing.Point(10, 198)
			Me.OutliersBorderStyleButton.Name = "OutliersBorderStyleButton"
			Me.OutliersBorderStyleButton.Size = New System.Drawing.Size(154, 24)
			Me.OutliersBorderStyleButton.TabIndex = 7
			Me.OutliersBorderStyleButton.Text = "Outliers Border Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OutliersBorderStyleButton.Click += new System.EventHandler(this.OutliersBorderStyleButton_Click);
			' 
			' WhiskersBorderStyleButton
			' 
			Me.WhiskersBorderStyleButton.Location = New System.Drawing.Point(10, 230)
			Me.WhiskersBorderStyleButton.Name = "WhiskersBorderStyleButton"
			Me.WhiskersBorderStyleButton.Size = New System.Drawing.Size(154, 24)
			Me.WhiskersBorderStyleButton.TabIndex = 8
			Me.WhiskersBorderStyleButton.Text = "Whiskers Border Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WhiskersBorderStyleButton.Click += new System.EventHandler(this.WhiskersBorderStyleButton_Click);
			' 
			' shadowStyleButton
			' 
			Me.shadowStyleButton.Location = New System.Drawing.Point(10, 262)
			Me.shadowStyleButton.Name = "shadowStyleButton"
			Me.shadowStyleButton.Size = New System.Drawing.Size(154, 24)
			Me.shadowStyleButton.TabIndex = 9
			Me.shadowStyleButton.Text = "Shadow Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.shadowStyleButton.Click += new System.EventHandler(this.ShadowStyleButton_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(9, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(154, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Box Width:"
			' 
			' BoxWidthScroll
			' 
			Me.BoxWidthScroll.Location = New System.Drawing.Point(11, 24)
			Me.BoxWidthScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.BoxWidthScroll.Name = "BoxWidthScroll"
			Me.BoxWidthScroll.Size = New System.Drawing.Size(152, 16)
			Me.BoxWidthScroll.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BoxWidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BoxWidthScroll_ValueChanged);
			' 
			' NBoxAndWhiskers2DUC
			' 
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.BoxWidthScroll)
			Me.Controls.Add(Me.shadowStyleButton)
			Me.Controls.Add(Me.WhiskersBorderStyleButton)
			Me.Controls.Add(Me.OutliersBorderStyleButton)
			Me.Controls.Add(Me.OutliersFillStyleButton)
			Me.Controls.Add(Me.GenerateDataButton)
			Me.Controls.Add(Me.BoxFillStyleButton)
			Me.Controls.Add(Me.RoundToTickCheck)
			Me.Controls.Add(Me.InflateMarginsCheck)
			Me.Controls.Add(Me.BoxBorderStyleButton)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.WhiskersWidthScroll)
			Me.Name = "NBoxAndWhiskers2DUC"
			Me.Size = New System.Drawing.Size(180, 413)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("Box and Whiskers")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' remove the legend
			nChartControl1.Legends.Clear()

			' setup the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			' add interlace stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			Dim series As NBoxAndWhiskersSeries = CType(m_Chart.Series.Add(SeriesType.BoxAndWhiskers), NBoxAndWhiskersSeries)
			series.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant4, LightOrange, DarkOrange)
			series.DataLabelStyle.Visible = False
			series.MedianStrokeStyle = New NStrokeStyle(Color.Indigo)
			series.AverageStrokeStyle = New NStrokeStyle(1, Color.DarkRed, LinePattern.Dot)
			series.OutliersBorderStyle = New NStrokeStyle(DarkFuchsia)
			series.OutliersFillStyle = New NColorFillStyle(Red)

			GenerateData(series, 7)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, Nothing)

			BoxWidthScroll.Value = 70
			WhiskersWidthScroll.Value = 50
			RoundToTickCheck.Checked = True
			InflateMarginsCheck.Checked = True
		End Sub

		Private Sub GenerateData(ByVal series As NBoxAndWhiskersSeries, ByVal nCount As Integer)
			series.ClearDataPoints()

			For i As Integer = 0 To nCount - 1
				Dim boxLower As Double = 1000 + Random.NextDouble() * 200
				Dim boxUpper As Double = boxLower + 200 + Random.NextDouble() * 200
				Dim whiskersLower As Double = boxLower - (20 + Random.NextDouble() * 300)
				Dim whiskersUpper As Double = boxUpper + (20 + Random.NextDouble() * 300)

				Dim IQR As Double = (boxUpper - boxLower)
				Dim median As Double = boxLower + IQR * 0.25 + Random.NextDouble() * IQR * 0.5
				Dim average As Double = boxLower + IQR * 0.25 + Random.NextDouble() * IQR * 0.5

				series.UpperBoxValues.Add(boxUpper)
				series.LowerBoxValues.Add(boxLower)
				series.UpperWhiskerValues.Add(whiskersUpper)
				series.LowerWhiskerValues.Add(whiskersLower)
				series.MedianValues.Add(median)
				series.AverageValues.Add(average)

				Dim outliersCount As Integer = Random.Next(5)

				Dim outliers As New NDoubleList()

				For k As Integer = 0 To outliersCount - 1
					Dim dOutlier As Double = 0

					If Random.NextDouble() > 0.5 Then
						dOutlier = boxUpper + IQR * 1.5 + Random.NextDouble() * 100
					Else
						dOutlier = boxLower - IQR * 1.5 - Random.NextDouble() * 100
					End If

					outliers.Add(dOutlier)
				Next k

				series.OutlierValues.Add(outliers)
			Next i
		End Sub

		Private Sub InflateMarginsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InflateMarginsCheck.CheckedChanged
			Dim series As NSeries = CType(m_Chart.Series(0), NSeries)
			series.InflateMargins = InflateMarginsCheck.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub RoundToTickCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RoundToTickCheck.CheckedChanged
			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			linearScale.RoundToTickMin = RoundToTickCheck.Checked
			linearScale.RoundToTickMax = RoundToTickCheck.Checked

			nChartControl1.Refresh()
		End Sub
		Private Sub GenerateDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GenerateDataButton.Click
			Dim series As NBoxAndWhiskersSeries = CType(m_Chart.Series(0), NBoxAndWhiskersSeries)
			GenerateData(series, 7)
			nChartControl1.Refresh()
		End Sub
		Private Sub BoxWidthScroll_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles BoxWidthScroll.ValueChanged
			Dim series As NBoxAndWhiskersSeries = CType(nChartControl1.Charts(0).Series(0), NBoxAndWhiskersSeries)

			series.BoxWidthPercent = BoxWidthScroll.Value

			nChartControl1.Refresh()
		End Sub
		Private Sub WhiskersWidthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles WhiskersWidthScroll.ValueChanged
			Dim series As NBoxAndWhiskersSeries = CType(nChartControl1.Charts(0).Series(0), NBoxAndWhiskersSeries)

			series.WhiskersWidthPercent = WhiskersWidthScroll.Value

			nChartControl1.Refresh()
		End Sub
		Private Sub BoxFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BoxFillStyleButton.Click
			Dim fillStyleResult As NFillStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NFillStyleTypeEditor.Edit(series.FillStyle, fillStyleResult) Then
				series.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub BoxBorderStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BoxBorderStyleButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NStrokeStyleTypeEditor.Edit(series.BorderStyle, strokeStyleResult) Then
				series.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub OutliersFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OutliersFillStyleButton.Click
			Dim fillStyleResult As NFillStyle = Nothing
			Dim series As NBoxAndWhiskersSeries = CType(nChartControl1.Charts(0).Series(0), NBoxAndWhiskersSeries)

			If NFillStyleTypeEditor.Edit(series.OutliersFillStyle, fillStyleResult) Then
				series.OutliersFillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub OutliersBorderStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OutliersBorderStyleButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing
			Dim series As NBoxAndWhiskersSeries = CType(nChartControl1.Charts(0).Series(0), NBoxAndWhiskersSeries)

			If NStrokeStyleTypeEditor.Edit(series.OutliersBorderStyle, strokeStyleResult) Then
				series.OutliersBorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub WhiskersBorderStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles WhiskersBorderStyleButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing
			Dim series As NBoxAndWhiskersSeries = CType(nChartControl1.Charts(0).Series(0), NBoxAndWhiskersSeries)

			If NStrokeStyleTypeEditor.Edit(series.WhiskersStrokeStyle, strokeStyleResult) Then
				series.WhiskersStrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub ShadowStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles shadowStyleButton.Click
			Dim shadowStyleResult As NShadowStyle = Nothing
			Dim series As NBoxAndWhiskersSeries = CType(nChartControl1.Charts(0).Series(0), NBoxAndWhiskersSeries)

			If NShadowStyleTypeEditor.Edit(series.ShadowStyle, shadowStyleResult) Then
				series.ShadowStyle = shadowStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
