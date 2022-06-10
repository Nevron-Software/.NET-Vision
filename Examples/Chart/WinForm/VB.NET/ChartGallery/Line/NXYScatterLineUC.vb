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
	Public Class NXYScatterLineUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Line As NLineSeries
		Private WithEvents ChangeXValuesButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.ChangeXValuesButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' ChangeXValuesButton
			' 
			Me.ChangeXValuesButton.Location = New System.Drawing.Point(13, 13)
			Me.ChangeXValuesButton.Name = "ChangeXValuesButton"
			Me.ChangeXValuesButton.Size = New System.Drawing.Size(136, 24)
			Me.ChangeXValuesButton.TabIndex = 0
			Me.ChangeXValuesButton.Text = "Change X Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeXValuesButton.Click += new System.EventHandler(this.ChangeXValuesButton_Click);
			' 
			' NXYScatterLineUC
			' 
			Me.Controls.Add(Me.ChangeXValuesButton)
			Me.Name = "NXYScatterLineUC"
			Me.Size = New System.Drawing.Size(180, 50)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XY Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' add interlaced stripe to the Y axis
			Dim linearScale As New NLinearScaleConfigurator()
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' add the line
			m_Line = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line.LineSegmentShape = LineSegmentShape.Line
			m_Line.DataLabelStyle.Visible = False
			m_Line.Legend.Mode = SeriesLegendMode.DataPoints
			m_Line.InflateMargins = True
			m_Line.MarkerStyle.Visible = True
			m_Line.MarkerStyle.PointShape = PointShape.Cylinder
			m_Line.MarkerStyle.Width = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			m_Line.MarkerStyle.Height = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			m_Line.Name = "Line Series"
			m_Line.UseXValues = True

			' add xy values
			m_Line.AddDataPoint(New NDataPoint(15, 10))
			m_Line.AddDataPoint(New NDataPoint(25, 23))
			m_Line.AddDataPoint(New NDataPoint(45, 12))
			m_Line.AddDataPoint(New NDataPoint(55, 21))
			m_Line.AddDataPoint(New NDataPoint(61, 16))
			m_Line.AddDataPoint(New NDataPoint(67, 19))
			m_Line.AddDataPoint(New NDataPoint(72, 11))

			' apply layout
			ConfigureStandardLayout(m_Chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Sub ChangeXValuesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeXValuesButton.Click
			m_Line.XValues(0) = CDbl(Random.Next(10))

			For i As Integer = 1 To m_Line.XValues.Count - 1
				m_Line.XValues(i) = DirectCast(m_Line.XValues(i - 1), Double) + Random.Next(1, 10)
			Next i

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
