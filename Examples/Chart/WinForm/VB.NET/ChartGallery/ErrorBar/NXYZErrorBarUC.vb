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
	Public Class NXYZErrorBarUC
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
		Private WithEvents ShowLowerErrorXCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowUpperErrorXCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents XErrorSizeScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents ShowLowerErrorZCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowUpperErrorZCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private label3 As System.Windows.Forms.Label
		Private WithEvents ZErrorSizeScroll As Nevron.UI.WinForm.Controls.NHScrollBar
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
			Me.ShowLowerErrorXCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowUpperErrorXCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.XErrorSizeScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.ShowLowerErrorZCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowUpperErrorZCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.ZErrorSizeScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.SuspendLayout()
			' 
			' InflateMarginsCheck
			' 
			Me.InflateMarginsCheck.ButtonProperties.BorderOffset = 2
			Me.InflateMarginsCheck.Location = New System.Drawing.Point(10, 411)
			Me.InflateMarginsCheck.Name = "InflateMarginsCheck"
			Me.InflateMarginsCheck.Size = New System.Drawing.Size(154, 20)
			Me.InflateMarginsCheck.TabIndex = 14
			Me.InflateMarginsCheck.Text = "Inflate Margins"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			' 
			' RoundToTickCheck
			' 
			Me.RoundToTickCheck.ButtonProperties.BorderOffset = 2
			Me.RoundToTickCheck.Location = New System.Drawing.Point(10, 438)
			Me.RoundToTickCheck.Name = "RoundToTickCheck"
			Me.RoundToTickCheck.Size = New System.Drawing.Size(154, 19)
			Me.RoundToTickCheck.TabIndex = 15
			Me.RoundToTickCheck.Text = "Left Axis Round to Tick"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RoundToTickCheck.CheckedChanged += new System.EventHandler(this.RoundToTickCheck_CheckedChanged);
			' 
			' BorderStyleButton
			' 
			Me.BorderStyleButton.Location = New System.Drawing.Point(10, 346)
			Me.BorderStyleButton.Name = "BorderStyleButton"
			Me.BorderStyleButton.Size = New System.Drawing.Size(154, 24)
			Me.BorderStyleButton.TabIndex = 12
			Me.BorderStyleButton.Text = "Border Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BorderStyleButton.Click += new System.EventHandler(this.BorderPropsButton_Click);
			' 
			' MarkerStyleButton
			' 
			Me.MarkerStyleButton.Location = New System.Drawing.Point(10, 378)
			Me.MarkerStyleButton.Name = "MarkerStyleButton"
			Me.MarkerStyleButton.Size = New System.Drawing.Size(154, 24)
			Me.MarkerStyleButton.TabIndex = 13
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
			Me.label2.Text = "Y Error Whiskers Size:"
			' 
			' GenerateDataButton
			' 
			Me.GenerateDataButton.Location = New System.Drawing.Point(10, 481)
			Me.GenerateDataButton.Name = "GenerateDataButton"
			Me.GenerateDataButton.Size = New System.Drawing.Size(154, 24)
			Me.GenerateDataButton.TabIndex = 16
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
			Me.ShowUpperErrorCheck.Text = "Show Upper Y Error"
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
			Me.ShowLowerErrorCheck.Text = "Show Lower Y Error"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowLowerErrorCheck.CheckedChanged += new System.EventHandler(this.ShowLowerErrorCheck_CheckedChanged);
			' 
			' ShowLowerErrorXCheck
			' 
			Me.ShowLowerErrorXCheck.ButtonProperties.BorderOffset = 2
			Me.ShowLowerErrorXCheck.Location = New System.Drawing.Point(11, 175)
			Me.ShowLowerErrorXCheck.Name = "ShowLowerErrorXCheck"
			Me.ShowLowerErrorXCheck.Size = New System.Drawing.Size(148, 24)
			Me.ShowLowerErrorXCheck.TabIndex = 7
			Me.ShowLowerErrorXCheck.Text = "Show Lower X Error"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowLowerErrorXCheck.CheckedChanged += new System.EventHandler(this.ShowLowerErrorXCheck_CheckedChanged);
			' 
			' ShowUpperErrorXCheck
			' 
			Me.ShowUpperErrorXCheck.ButtonProperties.BorderOffset = 2
			Me.ShowUpperErrorXCheck.Location = New System.Drawing.Point(11, 150)
			Me.ShowUpperErrorXCheck.Name = "ShowUpperErrorXCheck"
			Me.ShowUpperErrorXCheck.Size = New System.Drawing.Size(147, 24)
			Me.ShowUpperErrorXCheck.TabIndex = 6
			Me.ShowUpperErrorXCheck.Text = "Show Upper X Error"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowUpperErrorXCheck.CheckedChanged += new System.EventHandler(this.ShowUpperErrorXCheck_CheckedChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(11, 113)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(154, 16)
			Me.label1.TabIndex = 4
			Me.label1.Text = "X Error Whiskers Size:"
			' 
			' XErrorSizeScroll
			' 
			Me.XErrorSizeScroll.Location = New System.Drawing.Point(11, 129)
			Me.XErrorSizeScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.XErrorSizeScroll.Name = "XErrorSizeScroll"
			Me.XErrorSizeScroll.Size = New System.Drawing.Size(154, 16)
			Me.XErrorSizeScroll.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XErrorSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.XErrorSizeScroll_ValueChanged);
			' 
			' ShowLowerErrorZCheck
			' 
			Me.ShowLowerErrorZCheck.ButtonProperties.BorderOffset = 2
			Me.ShowLowerErrorZCheck.Location = New System.Drawing.Point(10, 287)
			Me.ShowLowerErrorZCheck.Name = "ShowLowerErrorZCheck"
			Me.ShowLowerErrorZCheck.Size = New System.Drawing.Size(148, 24)
			Me.ShowLowerErrorZCheck.TabIndex = 11
			Me.ShowLowerErrorZCheck.Text = "Show Lower Z Error"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowLowerErrorZCheck.CheckedChanged += new System.EventHandler(this.ShowLowerErrorZCheck_CheckedChanged);
			' 
			' ShowUpperErrorZCheck
			' 
			Me.ShowUpperErrorZCheck.ButtonProperties.BorderOffset = 2
			Me.ShowUpperErrorZCheck.Location = New System.Drawing.Point(10, 262)
			Me.ShowUpperErrorZCheck.Name = "ShowUpperErrorZCheck"
			Me.ShowUpperErrorZCheck.Size = New System.Drawing.Size(147, 24)
			Me.ShowUpperErrorZCheck.TabIndex = 10
			Me.ShowUpperErrorZCheck.Text = "Show Upper Z Error"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowUpperErrorZCheck.CheckedChanged += new System.EventHandler(this.ShowUpperErrorZCheck_CheckedChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(10, 225)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(154, 16)
			Me.label3.TabIndex = 8
			Me.label3.Text = "Z Error Whiskers Size:"
			' 
			' ZErrorSizeScroll
			' 
			Me.ZErrorSizeScroll.Location = New System.Drawing.Point(10, 241)
			Me.ZErrorSizeScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.ZErrorSizeScroll.Name = "ZErrorSizeScroll"
			Me.ZErrorSizeScroll.Size = New System.Drawing.Size(154, 16)
			Me.ZErrorSizeScroll.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ZErrorSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ZErrorSizeScroll_ValueChanged);
			' 
			' NXYZErrorBarUC
			' 
			Me.Controls.Add(Me.ShowLowerErrorZCheck)
			Me.Controls.Add(Me.ShowUpperErrorZCheck)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.ZErrorSizeScroll)
			Me.Controls.Add(Me.ShowLowerErrorXCheck)
			Me.Controls.Add(Me.ShowUpperErrorXCheck)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.XErrorSizeScroll)
			Me.Controls.Add(Me.ShowLowerErrorCheck)
			Me.Controls.Add(Me.ShowUpperErrorCheck)
			Me.Controls.Add(Me.GenerateDataButton)
			Me.Controls.Add(Me.MarkerStyleButton)
			Me.Controls.Add(Me.RoundToTickCheck)
			Me.Controls.Add(Me.InflateMarginsCheck)
			Me.Controls.Add(Me.BorderStyleButton)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.YErrorSizeScroll)
			Me.Name = "NXYZErrorBarUC"
			Me.Size = New System.Drawing.Size(180, 517)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XYZ Error Bar")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' remove the legend
			nChartControl1.Legends.Clear()

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			m_Chart.BoundsMode = BoundsMode.Fit
			m_Chart.ContentAlignment = ContentAlignment.BottomRight
			m_Chart.Location = New NPointL(New NLength(8, NRelativeUnit.ParentPercentage), New NLength(8, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(84, NRelativeUnit.ParentPercentage), New NLength(84, NRelativeUnit.ParentPercentage))
			m_Chart.Depth = 55.0F
			m_Chart.Width = 55.0F
			m_Chart.Height = 55.0F

			' setup the x axis
			Dim linearScale As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)

			' setup the y axis
			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' add interlace stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' setup the z axis
			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale

			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)

			' add an error bar series
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
			series.UseXValues = True
			series.UseZValues = True

			GenerateData(series)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, Nothing)

			' form controls
			YErrorSizeScroll.Value = 20
			ShowLowerErrorCheck.Checked = True
			ShowUpperErrorCheck.Checked = True

			XErrorSizeScroll.Value = 20
			ShowLowerErrorXCheck.Checked = True
			ShowUpperErrorXCheck.Checked = True

			ZErrorSizeScroll.Value = 20
			ShowLowerErrorZCheck.Checked = True
			ShowUpperErrorZCheck.Checked = True

			RoundToTickCheck.Checked = True
			InflateMarginsCheck.Checked = True
		End Sub

		Private Sub GenerateData(ByVal series As NErrorBarSeries)
			series.ClearDataPoints()

			Dim v As New NVector3DF()

			For i As Integer = 0 To 14
				v.X = CSng(0.5 - Random.NextDouble())
				v.Y = CSng(0.5 - Random.NextDouble())
				v.Z = CSng(0.5 - Random.NextDouble())

				v.Normalize(40.0F)

				series.Values.Add(v.X)
				series.XValues.Add(v.Y)
				series.ZValues.Add(v.Z)

				series.LowerErrorsX.Add(2 + 5 * Random.NextDouble())
				series.UpperErrorsX.Add(2 + 5 * Random.NextDouble())
				series.LowerErrorsY.Add(2 + 5 * Random.NextDouble())
				series.UpperErrorsY.Add(2 + 5 * Random.NextDouble())
				series.LowerErrorsZ.Add(2 + 5 * Random.NextDouble())
				series.UpperErrorsZ.Add(2 + 5 * Random.NextDouble())
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

		Private Sub XErrorSizeScroll_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles XErrorSizeScroll.ValueChanged
			Dim series As NErrorBarSeries = CType(m_Chart.Series(0), NErrorBarSeries)
			series.SizeX = New NLength(XErrorSizeScroll.Value / 20.0F, NRelativeUnit.ParentPercentage)
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowUpperErrorXCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowUpperErrorXCheck.CheckedChanged
			Dim series As NErrorBarSeries = CType(m_Chart.Series(0), NErrorBarSeries)
			series.ShowUpperErrorX = ShowUpperErrorXCheck.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowLowerErrorXCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowLowerErrorXCheck.CheckedChanged
			Dim series As NErrorBarSeries = CType(m_Chart.Series(0), NErrorBarSeries)
			series.ShowLowerErrorX = ShowLowerErrorXCheck.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub ZErrorSizeScroll_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles ZErrorSizeScroll.ValueChanged
			Dim series As NErrorBarSeries = CType(m_Chart.Series(0), NErrorBarSeries)
			series.SizeZ = New NLength(ZErrorSizeScroll.Value / 20.0F, NRelativeUnit.ParentPercentage)
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowUpperErrorZCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowUpperErrorZCheck.CheckedChanged
			Dim series As NErrorBarSeries = CType(m_Chart.Series(0), NErrorBarSeries)
			series.ShowUpperErrorZ = ShowUpperErrorZCheck.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowLowerErrorZCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowLowerErrorZCheck.CheckedChanged
			Dim series As NErrorBarSeries = CType(m_Chart.Series(0), NErrorBarSeries)
			series.ShowLowerErrorZ = ShowLowerErrorZCheck.Checked
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
