Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NAxisMinMaxUC
		Inherits NExampleBaseUC

		Private WithEvents btnGenerateData As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private labelMinValue As Nevron.UI.WinForm.Controls.NTextBox
		Private labelMaxValue As Nevron.UI.WinForm.Controls.NTextBox
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
			Me.btnGenerateData = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.labelMinValue = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.labelMaxValue = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.SuspendLayout()
			' 
			' btnGenerateData
			' 
			Me.btnGenerateData.Location = New System.Drawing.Point(8, 8)
			Me.btnGenerateData.Name = "btnGenerateData"
			Me.btnGenerateData.Size = New System.Drawing.Size(136, 32)
			Me.btnGenerateData.TabIndex = 0
			Me.btnGenerateData.Text = "Generate Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnGenerateData.Click += new System.EventHandler(this.btnGenerateData_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 120)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(104, 16)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Y Axis Min Value:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 56)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(104, 16)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Y Axis Max Value:"
			' 
			' labelMinValue
			' 
			Me.labelMinValue.ErrorMessage = Nothing
			Me.labelMinValue.Location = New System.Drawing.Point(8, 144)
			Me.labelMinValue.Name = "labelMinValue"
			Me.labelMinValue.ReadOnly = True
			Me.labelMinValue.Size = New System.Drawing.Size(128, 18)
			Me.labelMinValue.TabIndex = 1
			Me.labelMinValue.Text = ""
			' 
			' labelMaxValue
			' 
			Me.labelMaxValue.ErrorMessage = Nothing
			Me.labelMaxValue.Location = New System.Drawing.Point(8, 80)
			Me.labelMaxValue.Name = "labelMaxValue"
			Me.labelMaxValue.ReadOnly = True
			Me.labelMaxValue.Size = New System.Drawing.Size(128, 18)
			Me.labelMaxValue.TabIndex = 0
			Me.labelMaxValue.Text = ""
			' 
			' NAxisMinMaxUC
			' 
			Me.Controls.Add(Me.labelMaxValue)
			Me.Controls.Add(Me.labelMinValue)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.btnGenerateData)
			Me.Name = "NAxisMinMaxUC"
			Me.Size = New System.Drawing.Size(150, 224)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Axis Min Max")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim chart As NChart = nChartControl1.Charts(0)

			' subscribe for the BeforePaint event of the chart
			chart.PaintCallback = New PaintCallback(Me)

			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RoundToTickMin = False
			linearScale.RoundToTickMax = False
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dash

			' add interlace stripe to the Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			Dim ordinalScale As NOrdinalScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dash

			NewPointSeries(chart)
			NewPointSeries(chart)

			GenerateData(6)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Function NewPointSeries(ByVal chart As NChart) As NPointSeries
			Dim point As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			point.Name = "Point Series"
			point.PointShape = PointShape.Ellipse
			point.Size = New NLength(10, NGraphicsUnit.Point)
			point.DataLabelStyle.Visible = False
			point.Legend.Mode = SeriesLegendMode.Series
			Return point
		End Function

		Private Sub GenerateData(ByVal itemCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)

			Dim seriesCount As Integer = chart.Series.Count

			For i As Integer = 0 To seriesCount - 1
				Dim series As NSeries = CType(chart.Series(i), NSeries)
				series.Values.FillRandomRange(Random, itemCount, -100, 100)
			Next i
		End Sub

		Private Sub btnGenerateData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerateData.Click
			GenerateData(6)
			nChartControl1.Refresh()
		End Sub

		Private Class PaintCallback
			Inherits NPaintCallback

			''' <summary>
			''' 
			''' </summary>
			''' <param name="userControl"></param>
			Public Sub New(ByVal userControl As NAxisMinMaxUC)
				m_UserControl = userControl
			End Sub
			''' <summary>
			''' Occurs before the panel is painted.
			''' </summary>
			''' <param name="panel"></param>
			''' <param name="eventArgs"></param>
			Public Overrides Sub OnBeforePaint(ByVal panel As NPanel, ByVal eventArgs As NPanelPaintEventArgs)
				Dim chart As NChart = CType(panel, NChart)

				Dim dAxisMin As Double = chart.Axis(StandardAxis.PrimaryY).Scale.RulerRange.Begin
				Dim dAxisMax As Double = chart.Axis(StandardAxis.PrimaryY).Scale.RulerRange.End

				m_UserControl.labelMinValue.Text = dAxisMin.ToString()
				m_UserControl.labelMaxValue.Text = dAxisMax.ToString()
			End Sub

			Private m_UserControl As NAxisMinMaxUC
		End Class
	End Class
End Namespace

