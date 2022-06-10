Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports System.Collections.Generic


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NStepLineIntersectionsUC
		Inherits NExampleBaseUC

		Private m_Line As NStepLineSeries
		Private m_Point As NPointSeries
		Private m_XCursor As NAxisCursor
		Private m_YCursor As NAxisCursor
		Private label1 As System.Windows.Forms.Label
		Private WithEvents LineSegmentRouteCombo As Nevron.UI.WinForm.Controls.NComboBox
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
			Me.LineSegmentRouteCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' LineSegmentRouteCombo
			' 
			Me.LineSegmentRouteCombo.ListProperties.CheckBoxDataMember = ""
			Me.LineSegmentRouteCombo.ListProperties.DataSource = Nothing
			Me.LineSegmentRouteCombo.ListProperties.DisplayMember = ""
			Me.LineSegmentRouteCombo.Location = New System.Drawing.Point(5, 25)
			Me.LineSegmentRouteCombo.Name = "LineSegmentRouteCombo"
			Me.LineSegmentRouteCombo.Size = New System.Drawing.Size(169, 21)
			Me.LineSegmentRouteCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineSegmentRouteCombo.SelectedIndexChanged += new System.EventHandler(this.LineSegmentRouteCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(5, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(169, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Line Segment Route:"
			' 
			' NStepLineIntersectionsUC
			' 
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.LineSegmentRouteCombo)
			Me.Name = "NStepLineIntersectionsUC"
			Me.Size = New System.Drawing.Size(180, 364)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("Step Line Intersections")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)

			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			' add interlace stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			m_Line = CType(chart.Series.Add(SeriesType.StepLine), NStepLineSeries)
			m_Line.Name = "Series 1"
			m_Line.DepthPercent = 50
			m_Line.LineSize = 2
			m_Line.DataLabelStyle.Visible = False
			m_Line.MarkerStyle.Visible = False
			m_Line.Values.FillRandom(Random, 12)

			m_Point = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			m_Point.UseXValues = True
			m_Point.DataLabelStyle.Visible = False
			m_Point.Size = New NLength(6)

			m_XCursor = New NAxisCursor()
			m_XCursor.BeginEndAxis = CInt(StandardAxis.PrimaryY)
			m_YCursor = New NAxisCursor()
			m_YCursor.BeginEndAxis = CInt(StandardAxis.PrimaryX)

			chart.Axis(StandardAxis.PrimaryX).Cursors.Add(m_XCursor)
			chart.Axis(StandardAxis.PrimaryY).Cursors.Add(m_YCursor)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			LineSegmentRouteCombo.FillFromEnum(GetType(LineSegmentRoute))
			LineSegmentRouteCombo.SelectedIndex = 1

			AddHandler nChartControl1.MouseMove, AddressOf OnChartControl1MouseMove
		End Sub

		Private Sub OnChartControl1MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			nChartControl1.RecalcLayout()
			Dim viewScale As New NViewToScale2DTransformation(nChartControl1.Charts(0), CInt(StandardAxis.PrimaryX), CInt(StandardAxis.PrimaryY))

			Dim value As New NVector2DD()
			viewScale.Transform(New Nevron.GraphicsCore.NPointF(e.X, e.Y), value)

			m_XCursor.Value = value.X
			m_YCursor.Value = value.Y

			m_Point.Values.Clear()
			m_Point.XValues.Clear()
			m_Point.FillStyles.Clear()

			Dim xIntersections As List(Of Double) = m_Line.IntersectWithXValue(value.X)

			For i As Integer = 0 To xIntersections.Count - 1
				m_Point.XValues.Add(value.X)
				m_Point.Values.Add(xIntersections(i))
				m_Point.FillStyles(m_Point.Values.Count - 1) = New NColorFillStyle(Color.Red)
			Next i

			Dim yIntersections As List(Of Double) = m_Line.IntersectWithYValue(value.Y)

			For i As Integer = 0 To yIntersections.Count - 1
				m_Point.Values.Add(value.Y)
				m_Point.XValues.Add(yIntersections(i))
				m_Point.FillStyles(m_Point.Values.Count - 1) = New NColorFillStyle(Color.Blue)
			Next i

			nChartControl1.Refresh()
		End Sub

		Private Sub LineSegmentRouteCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LineSegmentRouteCombo.SelectedIndexChanged
			m_Line.LineSegmentRoute = CType(LineSegmentRouteCombo.SelectedIndex, LineSegmentRoute)
		End Sub
	End Class
End Namespace
