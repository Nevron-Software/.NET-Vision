Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NAxisStripLinesUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing
		Private label1 As System.Windows.Forms.Label
		Private WithEvents HighLightRangeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private m_Chart As NChart

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
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
			Me.HighLightRangeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 16)
			Me.label1.Name = "label1"
			Me.label1.TabIndex = 0
			Me.label1.Text = "Highlight Range:"
			' 
			' HighLightRangeComboBox
			' 
			Me.HighLightRangeComboBox.Location = New System.Drawing.Point(8, 40)
			Me.HighLightRangeComboBox.Name = "HighLightRangeComboBox"
			Me.HighLightRangeComboBox.Size = New System.Drawing.Size(136, 21)
			Me.HighLightRangeComboBox.TabIndex = 1
			Me.HighLightRangeComboBox.Text = "comboBox1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HighLightRangeComboBox.SelectedIndexChanged += new System.EventHandler(this.HighLightRangeComboBox_SelectedIndexChanged);
			' 
			' NAxisStripLinesUC
			' 
			Me.Controls.Add(Me.HighLightRangeComboBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NAxisStripLinesUC"
			Me.Size = New System.Drawing.Size(150, 328)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Strip Lines")
			title.TextStyle.TextFormat = TextFormat.XML
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch

			' Add a line series
			Dim line As NLineSeries = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			line.UseXValues = True
			line.BorderStyle.Color = Color.DarkRed
			line.DataLabelStyle.Visible = False
			line.InflateMargins = True
			line.MarkerStyle.Visible = True
			line.MarkerStyle.PointShape = PointShape.Cylinder
			line.MarkerStyle.Width = New NLength(2, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Height = New NLength(2, NRelativeUnit.ParentPercentage)

			' create a date time scale
			Dim dateTimeScale As New NDateTimeScaleConfigurator()

			dateTimeScale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 90)
			dateTimeScale.LabelStyle.ContentAlignment = ContentAlignment.MiddleLeft
			dateTimeScale.EnableUnitSensitiveFormatting = False
			dateTimeScale.MajorTickMode = MajorTickMode.CustomStep
			dateTimeScale.CustomStep = New NDateTimeSpan(1, NDateTimeUnit.Day)
			dateTimeScale.LabelValueFormatter = New NDateTimeValueFormatter(DateTimeValueFormat.WeekDayShortName)

			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale

			' create a strip line highlighting the working days
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 2, 5)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)

			Dim provider As New NDateTimeRangeSamplerProvider()
			provider.SamplingMode = SamplingMode.CustomStep
			provider.UseOrigin = True
			provider.Origin = New Date(2007, 2, 19)
			provider.CustomStep = New NDateTimeSpan(1, NDateTimeUnit.Day)
			stripStyle.RangeSamplerProvider = provider

			' configure the x axis to use date time paging 
			Dim dateTimePagingView As New NDateTimeAxisPagingView(Date.Now, New NDateTimeSpan(10, NDateTimeUnit.Day))
			dateTimePagingView.Enabled = True
			m_Chart.Axis(StandardAxis.PrimaryX).PagingView = dateTimePagingView
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = True
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.ResetButton.Visible = False
			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			HighLightRangeComboBox.Items.Add("Weekdays")
			HighLightRangeComboBox.Items.Add("Weekends")
			HighLightRangeComboBox.SelectedIndex = 0

			GenerateData(Nothing, Nothing)
		End Sub

		Private Sub GenerateData(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim startDate As Date = Date.Now
			Dim endDate As Date = Date.Now.Add(New TimeSpan(30, 0, 0, 0, 0))

			If startDate > endDate Then
				Dim temp As Date = startDate

				startDate = endDate
				endDate = temp
			End If

			' Get the line series from the chart
			Dim line As NLineSeries = CType(m_Chart.Series(0), NLineSeries)

			Dim span As TimeSpan = endDate.Subtract(startDate)
			span = New TimeSpan(span.Ticks \ 30)

			line.Values.Clear()
			line.XValues.Clear()

			If span.Ticks > 0 Then
				Do While startDate < endDate
					line.XValues.Add(startDate)
					startDate = startDate.Add(span)

					line.Values.Add(Random.Next(100))
				Loop
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub HighLightRangeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HighLightRangeComboBox.SelectedIndexChanged
			Dim stripStyle As NScaleStripStyle
			Dim origin As Date

			' create a strip line highlighting the working days
			If HighLightRangeComboBox.SelectedIndex = 0 Then
				origin = New Date(2007, 2, 19)
				stripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 2, 5)
			Else
				origin = New Date(2007, 2, 17)
				stripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 5, 2)
			End If

			stripStyle.SetShowAtWall(ChartWallType.Back, True)

			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfigurator.StripStyles.Clear()
			scaleConfigurator.StripStyles.Add(stripStyle)

			Dim provider As New NDateTimeRangeSamplerProvider()
			provider.SamplingMode = SamplingMode.CustomStep
			provider.UseOrigin = True
			provider.Origin = origin
			provider.CustomStep = New NDateTimeSpan(1, NDateTimeUnit.Day)
			stripStyle.RangeSamplerProvider = provider

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
