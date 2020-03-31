Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NFloatBarConnectorLines2DUC
		Inherits NExampleBaseUC

		Private WithEvents ConnectorLinesStrokeButton As UI.WinForm.Controls.NButton
		Private WithEvents ShowConnectorLinesCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents GanttConnectLinesStrokeButton As UI.WinForm.Controls.NButton
		Private WithEvents ShowGanttConnectorLinesCheckBox As UI.WinForm.Controls.NCheckBox
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
			Me.ConnectorLinesStrokeButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShowConnectorLinesCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.GanttConnectLinesStrokeButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShowGanttConnectorLinesCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' ConnectorLinesStrokeButton
			' 
			Me.ConnectorLinesStrokeButton.Location = New System.Drawing.Point(3, 33)
			Me.ConnectorLinesStrokeButton.Name = "ConnectorLinesStrokeButton"
			Me.ConnectorLinesStrokeButton.Size = New System.Drawing.Size(163, 24)
			Me.ConnectorLinesStrokeButton.TabIndex = 10
			Me.ConnectorLinesStrokeButton.Text = "Connector Lines Stoke.."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ConnectorLinesStrokeButton.Click += new System.EventHandler(this.ConnectorLinesStrokeButton_Click);
			' 
			' ShowConnectorLinesCheckBox
			' 
			Me.ShowConnectorLinesCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowConnectorLinesCheckBox.Location = New System.Drawing.Point(3, 6)
			Me.ShowConnectorLinesCheckBox.Name = "ShowConnectorLinesCheckBox"
			Me.ShowConnectorLinesCheckBox.Size = New System.Drawing.Size(163, 21)
			Me.ShowConnectorLinesCheckBox.TabIndex = 9
			Me.ShowConnectorLinesCheckBox.Text = "Show Connector Lines"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowConnectorLinesCheckBox.CheckedChanged += new System.EventHandler(this.ShowConnectorLinesCheckBox_CheckedChanged);
			' 
			' GanntConnectLinesStrokeButton
			' 
			Me.GanttConnectLinesStrokeButton.Location = New System.Drawing.Point(3, 100)
			Me.GanttConnectLinesStrokeButton.Name = "GanttConnectLinesStrokeButton"
			Me.GanttConnectLinesStrokeButton.Size = New System.Drawing.Size(163, 24)
			Me.GanttConnectLinesStrokeButton.TabIndex = 12
			Me.GanttConnectLinesStrokeButton.Text = "Gantt Connector Lines Stoke.."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GanttConnectLinesStrokeButton.Click += new System.EventHandler(this.GanntConnectLinesStrokeButton_Click);
			' 
			' ShowGanttConnectorLinesCheckBox
			' 
			Me.ShowGanttConnectorLinesCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowGanttConnectorLinesCheckBox.Location = New System.Drawing.Point(3, 73)
			Me.ShowGanttConnectorLinesCheckBox.Name = "ShowGanttConnectorLinesCheckBox"
			Me.ShowGanttConnectorLinesCheckBox.Size = New System.Drawing.Size(163, 21)
			Me.ShowGanttConnectorLinesCheckBox.TabIndex = 11
			Me.ShowGanttConnectorLinesCheckBox.Text = "Show Gantt Connector Lines"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowGanttConnectorLinesCheckBox.CheckedChanged += new System.EventHandler(this.ShowGanttConnectorLinesCheckBox_CheckedChanged);
			' 
			' NFloatBarConnectorLines2DUC
			' 
			Me.Controls.Add(Me.GanttConnectLinesStrokeButton)
			Me.Controls.Add(Me.ShowGanttConnectorLinesCheckBox)
			Me.Controls.Add(Me.ConnectorLinesStrokeButton)
			Me.Controls.Add(Me.ShowConnectorLinesCheckBox)
			Me.Name = "NFloatBarConnectorLines2DUC"
			Me.Size = New System.Drawing.Size(180, 305)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Float Bar Connector Lines")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Axis(StandardAxis.Depth).Visible = False

			' setup X axis
			Dim scaleX As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.AutoLabels = False
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleX.DisplayDataPointsBetweenTicks = False
			For i As Integer = 0 To monthLetters.Length - 1
				scaleX.CustomLabels.Add(New NCustomValueLabel(i, monthLetters(i)))
			Next i

			' add interlaced stripe to the Y axis
			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			' create the float bar series
			Dim floatBar As NFloatBarSeries = CType(chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			floatBar.DataLabelStyle.Visible = False
			floatBar.DataLabelStyle.VertAlign = VertAlign.Center
			floatBar.DataLabelStyle.Format = "<begin> - <end>"

			' add bars
			floatBar.AddDataPoint(New NFloatBarDataPoint(2, 10))
			floatBar.NextTasks.Add(0, New UInteger() { 1 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(5, 16))
			floatBar.NextTasks.Add(1, New UInteger() { 2 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(9, 17))
			floatBar.NextTasks.Add(2, New UInteger() { 3 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(12, 21))
			floatBar.NextTasks.Add(3, New UInteger() { 4 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(8, 18))
			floatBar.NextTasks.Add(4, New UInteger() { 5 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(7, 18))
			floatBar.NextTasks.Add(5, New UInteger() { 6 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(3, 11))
			floatBar.NextTasks.Add(6, New UInteger() { 7 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(5, 12))
			floatBar.NextTasks.Add(7, New UInteger() { 8 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(8, 17))
			floatBar.NextTasks.Add(8, New UInteger() { 9 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(6, 15))
			floatBar.NextTasks.Add(9, New UInteger() { 10 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(3, 10))
			floatBar.NextTasks.Add(10, New UInteger() { 11 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(1, 7))

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			ShowConnectorLinesCheckBox.Checked = True
		End Sub
		Private Sub ShowConnectorLinesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowConnectorLinesCheckBox.CheckedChanged
			Dim floatBar As NFloatBarSeries = CType(nChartControl1.Charts(0).Series(0), NFloatBarSeries)
			floatBar.ShowConnectorLines = ShowConnectorLinesCheckBox.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub ConnectorLinesStrokeButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ConnectorLinesStrokeButton.Click
			Dim floatBar As NFloatBarSeries = CType(nChartControl1.Charts(0).Series(0), NFloatBarSeries)
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(floatBar.ConnectorLineStrokeStyle, strokeStyleResult) Then
				floatBar.ConnectorLineStrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub ShowGanttConnectorLinesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowGanttConnectorLinesCheckBox.CheckedChanged
			Dim floatBar As NFloatBarSeries = CType(nChartControl1.Charts(0).Series(0), NFloatBarSeries)
			floatBar.ShowGanttConnectorLines = ShowGanttConnectorLinesCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub GanntConnectLinesStrokeButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles GanttConnectLinesStrokeButton.Click
			Dim floatBar As NFloatBarSeries = CType(nChartControl1.Charts(0).Series(0), NFloatBarSeries)
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(floatBar.GanttConnectorLineStrokeStyle, strokeStyleResult) Then
				floatBar.GanttConnectorLineStrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
