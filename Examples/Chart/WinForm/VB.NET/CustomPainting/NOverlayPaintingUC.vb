Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NOverlayPaintingUC
		Inherits NExampleBaseUC
		Implements INPaintCallback

		Private WithEvents NewDataButton As Nevron.UI.WinForm.Controls.NButton
		Private components As IContainer
		Private WithEvents m_Timer As Timer
		Private m_Points As New List(Of MousePoint)()
		Private m_StrokeCrimson As New NStrokeStyle(1, Color.Crimson)
		Private m_StrokeMediumSeaGreen As New NStrokeStyle(1, Color.MediumSeaGreen)


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
			Me.components = New System.ComponentModel.Container()
			Me.NewDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_Timer = New System.Windows.Forms.Timer(Me.components)
			Me.SuspendLayout()
			' 
			' NewDataButton
			' 
			Me.NewDataButton.Location = New System.Drawing.Point(4, 5)
			Me.NewDataButton.Name = "NewDataButton"
			Me.NewDataButton.Size = New System.Drawing.Size(171, 24)
			Me.NewDataButton.TabIndex = 1
			Me.NewDataButton.Text = "New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.NewDataButton.Click += new System.EventHandler(this.NewDataButton_Click);
			' 
			' timer1
			' 
			Me.m_Timer.Interval = 50
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_Timer.Tick += new System.EventHandler(this.timer1_Tick);
			' 
			' NOverlayPaintingUC
			' 
			Me.Controls.Add(Me.NewDataButton)
			Me.Name = "NOverlayPaintingUC"
			Me.Size = New System.Drawing.Size(180, 106)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Overlay Painting <br /><font size = '12pt'>(Move the mouse over the chart and press the mouse buttons.)</font>")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.TextFormat = TextFormat.XML

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.OverlayPaintCallback = Me

			' setup X axis
			Dim scaleX As New NLinearScaleConfigurator()
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleX.RoundToTickMin = True
			scaleX.RoundToTickMax = True
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' setup Y axis
			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleY.RoundToTickMin = True
			scaleY.RoundToTickMax = True
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' add a point series
			Dim point As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			point.Name = "Point Series"
			point.DataLabelStyle.Visible = False
			point.FillStyle = New NColorFillStyle(Color.FromArgb(160, LightOrange))
			point.BorderStyle.Width = New NLength(0)
			point.Size = New NLength(1, NRelativeUnit.ParentPercentage)
			point.PointShape = PointShape.Ellipse
			point.InflateMargins = True
			point.UseXValues = True

			GenerateXYData(point)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' attach mouse move handler
			AddHandler nChartControl1.MouseMove, AddressOf nChartControl1_MouseMove

			' start the timer
			m_Timer.Start()
		End Sub

		Private Sub NewDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewDataButton.Click
			Dim point As NPointSeries = CType(nChartControl1.Charts(0).Series(0), NPointSeries)
			GenerateXYData(point)
			nChartControl1.Refresh()
		End Sub
		Private Sub nChartControl1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			m_Points.Add(New MousePoint(e.Location, e.Button))

			DiminishPoints()

			nChartControl1.View.InvalidateOverlay()
		End Sub
		Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles m_Timer.Tick
			DiminishPoints()

			nChartControl1.View.InvalidateOverlay()
		End Sub

		Private Sub GenerateXYData(ByVal series As NPointSeries)
			series.ClearDataPoints()

			For i As Integer = 0 To 499
				Dim u1 As Double = Random.NextDouble()
				Dim u2 As Double = Random.NextDouble()

				If u1 = 0 Then
					u1 += 0.0001
				End If

				If u2 = 0 Then
					u2 += 0.0001
				End If

				Dim z0 As Double = Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2)
				Dim z1 As Double = Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2)

				series.XValues.Add(z0)
				series.Values.Add(z1)
			Next i
		End Sub
		Private Sub DiminishPoints()
			If m_Points.Count = 0 Then
				Return
			End If

			For i As Integer = 0 To m_Points.Count - 1
'INSTANT VB NOTE: The variable site was renamed since Visual Basic does not handle local variables named the same as class members well:
				Dim site_Renamed As MousePoint = m_Points(i)
				site_Renamed.Size -= 0.4F
				m_Points(i) = site_Renamed
			Next i

			Dim removeCount As Integer = 0

			For i As Integer = 0 To m_Points.Count - 1
				If m_Points(i).Size > 0 Then
					Exit For
				End If

				removeCount += 1
			Next i

			If removeCount > 0 Then
				m_Points.RemoveRange(0, removeCount)
			End If
		End Sub

		#Region "INPaintCallback"

		Public Sub OnAfterPaint(ByVal panel As NPanel, ByVal eventArgs As NPanelPaintEventArgs) Implements INPaintCallback.OnAfterPaint
			' draw a circle for each point
			For i As Integer = 0 To m_Points.Count - 1
'INSTANT VB NOTE: The variable site was renamed since Visual Basic does not handle local variables named the same as class members well:
				Dim site_Renamed As MousePoint = m_Points(i)
				Dim p As Point = site_Renamed.Location
				Dim sz As Single = site_Renamed.Size

				If sz > 0 Then
					Dim strokeStyle As NStrokeStyle = Nothing

					If (site_Renamed.MouseButtons And MouseButtons.Left) <> 0 Then
						strokeStyle = m_StrokeCrimson
					Else
						strokeStyle = m_StrokeMediumSeaGreen
					End If

					If (site_Renamed.MouseButtons And MouseButtons.Right) <> 0 Then
						sz *= 4
					End If

					eventArgs.Graphics.PaintEllipse(Nothing, strokeStyle, New NRectangleF(p.X - sz / 2, p.Y - sz / 2, sz, sz))
				End If
			Next i
		End Sub
		Public Sub OnBeforePaint(ByVal panel As NPanel, ByVal eventArgs As NPanelPaintEventArgs) Implements INPaintCallback.OnBeforePaint
		End Sub

		#End Region

		#Region "Nested Types"

		Private Structure MousePoint
			Public Sub New(ByVal location As Point, ByVal buttons As MouseButtons)
				Me.Location = location
				Me.MouseButtons = buttons
				Me.Size = 20
			End Sub

			Public Location As Point
			Public MouseButtons As MouseButtons
			Public Size As Single
		End Structure

		#End Region
	End Class
End Namespace
