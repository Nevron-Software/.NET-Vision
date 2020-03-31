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
	Public Class NStandardStepLine2DUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_StepLine As NStepLineSeries
		Private WithEvents InflateMarginsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents RoundToTickCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents LineShadowButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents MarkerStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents DataLabelStyleButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.BorderStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.InflateMarginsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.RoundToTickCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.LineShadowButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.MarkerStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.DataLabelStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' BorderStyleButton
			' 
			Me.BorderStyleButton.Location = New System.Drawing.Point(5, 8)
			Me.BorderStyleButton.Name = "BorderStyleButton"
			Me.BorderStyleButton.Size = New System.Drawing.Size(170, 24)
			Me.BorderStyleButton.TabIndex = 2
			Me.BorderStyleButton.Text = "Border Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BorderStyleButton.Click += new System.EventHandler(this.BorderPropsButton_Click);
			' 
			' InflateMarginsCheck
			' 
			Me.InflateMarginsCheck.ButtonProperties.BorderOffset = 2
			Me.InflateMarginsCheck.Location = New System.Drawing.Point(5, 142)
			Me.InflateMarginsCheck.Name = "InflateMarginsCheck"
			Me.InflateMarginsCheck.Size = New System.Drawing.Size(170, 20)
			Me.InflateMarginsCheck.TabIndex = 5
			Me.InflateMarginsCheck.Text = "Inflate Margins"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			' 
			' RoundToTickCheck
			' 
			Me.RoundToTickCheck.ButtonProperties.BorderOffset = 2
			Me.RoundToTickCheck.Location = New System.Drawing.Point(5, 170)
			Me.RoundToTickCheck.Name = "RoundToTickCheck"
			Me.RoundToTickCheck.Size = New System.Drawing.Size(170, 20)
			Me.RoundToTickCheck.TabIndex = 6
			Me.RoundToTickCheck.Text = "Left Axis Round to Tick"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RoundToTickCheck.CheckedChanged += new System.EventHandler(this.RoundToTickCheck_CheckedChanged);
			' 
			' LineShadowButton
			' 
			Me.LineShadowButton.Location = New System.Drawing.Point(5, 39)
			Me.LineShadowButton.Name = "LineShadowButton"
			Me.LineShadowButton.Size = New System.Drawing.Size(170, 24)
			Me.LineShadowButton.TabIndex = 4
			Me.LineShadowButton.Text = "Line Shadow..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineShadowButton.Click += new System.EventHandler(this.LineShadowButton_Click);
			' 
			' MarkerStyleButton
			' 
			Me.MarkerStyleButton.Location = New System.Drawing.Point(5, 71)
			Me.MarkerStyleButton.Name = "MarkerStyleButton"
			Me.MarkerStyleButton.Size = New System.Drawing.Size(170, 24)
			Me.MarkerStyleButton.TabIndex = 36
			Me.MarkerStyleButton.Text = "Marker Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			' 
			' DataLabelStyleButton
			' 
			Me.DataLabelStyleButton.Location = New System.Drawing.Point(5, 102)
			Me.DataLabelStyleButton.Name = "DataLabelStyleButton"
			Me.DataLabelStyleButton.Size = New System.Drawing.Size(170, 24)
			Me.DataLabelStyleButton.TabIndex = 37
			Me.DataLabelStyleButton.Text = "Data Label Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DataLabelStyleButton.Click += new System.EventHandler(this.DataLabelStyleButton_Click);
			' 
			' NStandardStepLine2DUC
			' 
			Me.Controls.Add(Me.DataLabelStyleButton)
			Me.Controls.Add(Me.MarkerStyleButton)
			Me.Controls.Add(Me.LineShadowButton)
			Me.Controls.Add(Me.RoundToTickCheck)
			Me.Controls.Add(Me.InflateMarginsCheck)
			Me.Controls.Add(Me.BorderStyleButton)
			Me.Name = "NStandardStepLine2DUC"
			Me.Size = New System.Drawing.Size(180, 208)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("2D Step Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			' add interlace stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			m_StepLine = CType(m_Chart.Series.Add(SeriesType.StepLine), NStepLineSeries)
			m_StepLine.Name = "Series 1"
			m_StepLine.BorderStyle.Color = Color.SlateBlue
			m_StepLine.BorderStyle.Width = New NLength(2)
			m_StepLine.DataLabelStyle.VertAlign = VertAlign.Center
			m_StepLine.DataLabelStyle.Format = "<value>"
			m_StepLine.DataLabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			m_StepLine.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(1.4F, NRelativeUnit.RootPercentage)
			m_StepLine.DataLabelStyle.TextStyle.BackplaneStyle.Visible = False
			m_StepLine.MarkerStyle.Visible = True
			m_StepLine.MarkerStyle.PointShape = PointShape.Cylinder
			m_StepLine.MarkerStyle.BorderStyle.Color = Color.SlateBlue
			m_StepLine.ShadowStyle.Type = ShadowType.GaussianBlur
			m_StepLine.ShadowStyle.Offset = New NPointL(3, 3)
			m_StepLine.ShadowStyle.FadeLength = New NLength(5)
			m_StepLine.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0)
			m_StepLine.Values.FillRandom(Random, 8)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			RoundToTickCheck.Checked = True
			InflateMarginsCheck.Checked = True
		End Sub

		Private Sub BorderPropsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BorderStyleButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_StepLine.BorderStyle, strokeStyleResult) Then
				m_StepLine.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub LineFillColorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_StepLine.FillStyle, fillStyleResult) Then
				m_StepLine.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub LineShadowButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LineShadowButton.Click
			Dim shadowStyleResult As NShadowStyle = Nothing

			If NShadowStyleTypeEditor.Edit(m_StepLine.ShadowStyle, shadowStyleResult) Then
				m_StepLine.ShadowStyle = shadowStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub InflateMarginsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InflateMarginsCheck.CheckedChanged
			m_StepLine.InflateMargins = InflateMarginsCheck.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub RoundToTickCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RoundToTickCheck.CheckedChanged
			Dim standardScale As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)

			standardScale.RoundToTickMax = RoundToTickCheck.Checked
			standardScale.RoundToTickMin = RoundToTickCheck.Checked

			nChartControl1.Refresh()
		End Sub
		Private Sub MarkerBorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_StepLine.MarkerStyle.BorderStyle, strokeStyleResult) Then
				m_StepLine.MarkerStyle.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub MarkerFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_StepLine.MarkerStyle.FillStyle, fillStyleResult) Then
				m_StepLine.MarkerStyle.FillStyle = fillStyleResult
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
		Private Sub DataLabelStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataLabelStyleButton.Click
			Dim dataLabelStyleResult As NDataLabelStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NDataLabelStyleTypeEditor.Edit(series.DataLabelStyle, dataLabelStyleResult) Then
				series.DataLabelStyle = dataLabelStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace