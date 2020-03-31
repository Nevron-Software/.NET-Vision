Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.UI.WebForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NBasicChartSVGUC
		Inherits NExampleUC

		Protected m_Line1 As NLineSeries
		Protected m_Line2 As NLineSeries
		Protected m_Bar As NBarSeries

		Private Sub GenerateData()
			m_Line1.Values.Clear()
			m_Line2.Values.Clear()
			m_Bar.Values.Clear()

			For i As Integer = 0 To 8
				m_Line1.Values.Add(Math.Sin(0.6 * i) + 0.5 * Random.NextDouble())
				m_Line2.Values.Add(Math.Cos(0.6 * i) + 0.5 * Random.NextDouble())
				m_Bar.Values.Add(Math.Cos(0.6 * i) + 0.5 * Random.NextDouble())
			Next i
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Width = 100
			chart.Height = 60
			chart.BoundsMode = BoundsMode.Fit
			chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(20, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))


			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Wall(ChartWallType.Back).Visible = False

			m_Line1 = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line1.Name = "Line 1"
			m_Line1.DataLabelStyle.Visible = False
			m_Line1.BorderStyle.Color = Color.DodgerBlue
			m_Line1.FillStyle = New NColorFillStyle(Color.DodgerBlue)
			m_Line1.MarkerStyle.FillStyle = New NColorFillStyle(Color.DodgerBlue)
			m_Line1.MarkerStyle.BorderStyle.Color = Color.DodgerBlue
			m_Line1.MarkerStyle.PointShape = PointShape.Cylinder
			m_Line1.MarkerStyle.Visible = True
			m_Line1.ShadowStyle.Type = ShadowType.GaussianBlur

			m_Line2 = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line2.Name = "Line 2"
			m_Line2.MultiLineMode = MultiLineMode.Overlapped
			m_Line2.DataLabelStyle.Visible = False
			m_Line2.BorderStyle.Color = Color.Orange
			m_Line2.FillStyle = New NColorFillStyle(Color.Orange)
			m_Line2.MarkerStyle.FillStyle = New NColorFillStyle(Color.Orange)
			m_Line2.MarkerStyle.BorderStyle.Color = Color.Orange
			m_Line2.MarkerStyle.PointShape = PointShape.Cylinder
			m_Line2.MarkerStyle.Visible = True
			m_Line2.ShadowStyle.Type = ShadowType.GaussianBlur

			m_Bar = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar.DataLabelStyle.Visible = False
			Dim i As Integer = 0
			Do While i < m_Bar.Values.Count
				m_Bar.FillStyles(i) = New NColorFillStyle(WebExamplesUtilities.RandomColor())
				i += 1
			Loop
			m_Bar.Name = "Bar 1"

			GenerateData()

			' add header
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Basic SVG Chart")
			header.TextStyle.BackplaneStyle.Visible = False
			header.TextStyle.ShadowStyle.Type = ShadowType.GaussianBlur
			header.TextStyle.FillStyle = New NColorFillStyle(Color.Black)
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage))


			Dim svgImageResponse As NImageResponse = New NImageResponse()
			Dim svgImageFormat As NSvgImageFormat = New NSvgImageFormat()

			svgImageResponse.ImageFormat = svgImageFormat
			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = svgImageResponse
		End Sub
	End Class
End Namespace
