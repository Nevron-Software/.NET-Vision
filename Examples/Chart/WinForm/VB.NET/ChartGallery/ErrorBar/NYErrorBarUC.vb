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
	<ToolboxItem(False)> _
	Public Class NYErrorBarUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private WithEvents InflateMarginsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents RoundToTickCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents MarkerStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private label2 As System.Windows.Forms.Label
		Private WithEvents GenerateDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents YErrorSizeScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents ShowUpperErrorCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowLowerErrorCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents BorderStyleButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.BorderStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.MarkerStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.YErrorSizeScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.GenerateDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShowUpperErrorCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowLowerErrorCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' InflateMarginsCheck
			' 
			Me.InflateMarginsCheck.ButtonProperties.BorderOffset = 2
			Me.InflateMarginsCheck.Location = New System.Drawing.Point(10, 168)
			Me.InflateMarginsCheck.Name = "InflateMarginsCheck"
			Me.InflateMarginsCheck.Size = New System.Drawing.Size(154, 20)
			Me.InflateMarginsCheck.TabIndex = 6
			Me.InflateMarginsCheck.Text = "Inflate Margins"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			' 
			' RoundToTickCheck
			' 
			Me.RoundToTickCheck.ButtonProperties.BorderOffset = 2
			Me.RoundToTickCheck.Location = New System.Drawing.Point(10, 195)
			Me.RoundToTickCheck.Name = "RoundToTickCheck"
			Me.RoundToTickCheck.Size = New System.Drawing.Size(154, 19)
			Me.RoundToTickCheck.TabIndex = 7
			Me.RoundToTickCheck.Text = "Left Axis Round to Tick"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RoundToTickCheck.CheckedChanged += new System.EventHandler(this.RoundToTickCheck_CheckedChanged);
			' 
			' BorderStyleButton
			' 
			Me.BorderStyleButton.Location = New System.Drawing.Point(10, 103)
			Me.BorderStyleButton.Name = "BorderStyleButton"
			Me.BorderStyleButton.Size = New System.Drawing.Size(154, 24)
			Me.BorderStyleButton.TabIndex = 4
			Me.BorderStyleButton.Text = "Border Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BorderStyleButton.Click += new System.EventHandler(this.BorderPropsButton_Click);
			' 
			' MarkerStyleButton
			' 
			Me.MarkerStyleButton.Location = New System.Drawing.Point(10, 135)
			Me.MarkerStyleButton.Name = "MarkerStyleButton"
			Me.MarkerStyleButton.Size = New System.Drawing.Size(154, 24)
			Me.MarkerStyleButton.TabIndex = 5
			Me.MarkerStyleButton.Text = "Marker Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			' 
			' YErrorSizeScroll
			' 
			Me.YErrorSizeScroll.Location = New System.Drawing.Point(10, 24)
			Me.YErrorSizeScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.YErrorSizeScroll.Name = "YErrorSizeScroll"
			Me.YErrorSizeScroll.Size = New System.Drawing.Size(154, 16)
			Me.YErrorSizeScroll.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YErrorSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.YErrorSizeScroll_Scroll);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(10, 8)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(154, 16)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Error Whiskers Size:"
			' 
			' GenerateDataButton
			' 
			Me.GenerateDataButton.Location = New System.Drawing.Point(10, 238)
			Me.GenerateDataButton.Name = "GenerateDataButton"
			Me.GenerateDataButton.Size = New System.Drawing.Size(154, 24)
			Me.GenerateDataButton.TabIndex = 8
			Me.GenerateDataButton.Text = "Generate Data ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			' 
			' ShowUpperErrorCheck
			' 
			Me.ShowUpperErrorCheck.ButtonProperties.BorderOffset = 2
			Me.ShowUpperErrorCheck.Location = New System.Drawing.Point(10, 45)
			Me.ShowUpperErrorCheck.Name = "ShowUpperErrorCheck"
			Me.ShowUpperErrorCheck.Size = New System.Drawing.Size(147, 24)
			Me.ShowUpperErrorCheck.TabIndex = 2
			Me.ShowUpperErrorCheck.Text = "Show Upper Error"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowUpperErrorCheck.CheckedChanged += new System.EventHandler(this.ShowUpperErrorCheck_CheckedChanged);
			' 
			' ShowLowerErrorCheck
			' 
			Me.ShowLowerErrorCheck.ButtonProperties.BorderOffset = 2
			Me.ShowLowerErrorCheck.Location = New System.Drawing.Point(10, 70)
			Me.ShowLowerErrorCheck.Name = "ShowLowerErrorCheck"
			Me.ShowLowerErrorCheck.Size = New System.Drawing.Size(148, 24)
			Me.ShowLowerErrorCheck.TabIndex = 3
			Me.ShowLowerErrorCheck.Text = "Show Lower Error"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowLowerErrorCheck.CheckedChanged += new System.EventHandler(this.ShowLowerErrorCheck_CheckedChanged);
			' 
			' NYErrorBarUC
			' 
			Me.Controls.Add(Me.ShowLowerErrorCheck)
			Me.Controls.Add(Me.ShowUpperErrorCheck)
			Me.Controls.Add(Me.GenerateDataButton)
			Me.Controls.Add(Me.MarkerStyleButton)
			Me.Controls.Add(Me.RoundToTickCheck)
			Me.Controls.Add(Me.InflateMarginsCheck)
			Me.Controls.Add(Me.BorderStyleButton)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.YErrorSizeScroll)
			Me.Name = "NYErrorBarUC"
			Me.Size = New System.Drawing.Size(180, 272)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Error Bar Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' remove the legend
			nChartControl1.Legends.Clear()

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			' add interlace stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			Dim series As NErrorBarSeries = CType(m_Chart.Series.Add(SeriesType.ErrorBar), NErrorBarSeries)
			series.DataLabelStyle.Visible = False
			series.BorderStyle = New NStrokeStyle(GreyBlue)
			series.MarkerStyle.Visible = True
			series.MarkerStyle.AutoDepth = False
			series.MarkerStyle.FillStyle = New NColorFillStyle(DarkOrange)
			series.MarkerStyle.BorderStyle = New NStrokeStyle(GreyBlue)
			series.MarkerStyle.Width = New NLength(1.2F, NRelativeUnit.ParentPercentage)
			series.MarkerStyle.Height = New NLength(1.2F, NRelativeUnit.ParentPercentage)
			series.MarkerStyle.Depth = New NLength(1.2F, NRelativeUnit.ParentPercentage)

			GenerateData(series)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, Nothing)

			' init form controls
			YErrorSizeScroll.Value = 40
			ShowLowerErrorCheck.Checked = True
			ShowUpperErrorCheck.Checked = True
			RoundToTickCheck.Checked = True
			InflateMarginsCheck.Checked = True
		End Sub

		Private Sub GenerateData(ByVal series As NErrorBarSeries)
			series.ClearDataPoints()

			Dim y As Double = 20.0
			Dim p As Double = Random.NextDouble() * 10

			For i As Integer = 0 To 14
				y = Math.Sin(p + i / 6.0) * 8 + Random.NextDouble()

				series.Values.Add(y)
				series.LowerErrorsY.Add(1 + Random.NextDouble())
				series.UpperErrorsY.Add(1 + Random.NextDouble())
			Next i
		End Sub

		Private Sub YErrorSizeScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles YErrorSizeScroll.ValueChanged
			Dim series As NErrorBarSeries = CType(m_Chart.Series(0), NErrorBarSeries)

			series.SizeY = New NLength(YErrorSizeScroll.Value / 20.0F, NRelativeUnit.ParentPercentage)

			nChartControl1.Refresh()
		End Sub
		Private Sub ShowUpperErrorCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowUpperErrorCheck.CheckedChanged
			Dim series As NErrorBarSeries = CType(m_Chart.Series(0), NErrorBarSeries)
			series.ShowUpperErrorY = ShowUpperErrorCheck.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub ShowLowerErrorCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowLowerErrorCheck.CheckedChanged
			Dim series As NErrorBarSeries = CType(m_Chart.Series(0), NErrorBarSeries)
			series.ShowLowerErrorY = ShowLowerErrorCheck.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub BorderPropsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BorderStyleButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing
			Dim series As NSeries = CType(m_Chart.Series(0), NSeries)

			If NStrokeStyleTypeEditor.Edit(series.BorderStyle, strokeStyleResult) Then
				series.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub MarkerStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MarkerStyleButton.Click
			Dim markerStyleResult As NMarkerStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NMarkerStyleTypeEditor.Edit(series.MarkerStyle, markerStyleResult) Then
				series.MarkerStyle = markerStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub DataLabelStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim dataLabelStyleResult As NDataLabelStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NDataLabelStyleTypeEditor.Edit(series.DataLabelStyle, dataLabelStyleResult) Then
				series.DataLabelStyle = dataLabelStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub InflateMarginsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InflateMarginsCheck.CheckedChanged
			Dim series As NSeries = CType(m_Chart.Series(0), NSeries)
			series.InflateMargins = InflateMarginsCheck.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub RoundToTickCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RoundToTickCheck.CheckedChanged
			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			linearScale.RoundToTickMin = RoundToTickCheck.Checked
			linearScale.RoundToTickMax = RoundToTickCheck.Checked

			nChartControl1.Refresh()
		End Sub
		Private Sub GenerateDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GenerateDataButton.Click
			Dim series As NErrorBarSeries = CType(m_Chart.Series(0), NErrorBarSeries)
			GenerateData(series)
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
