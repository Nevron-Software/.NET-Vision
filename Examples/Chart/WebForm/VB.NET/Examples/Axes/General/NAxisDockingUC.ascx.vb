Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NAxisDockingUC
		Inherits NExampleUC
		Private m_Chart As NChart
		Private m_RedAxis As NAxis
		Private m_GreenAxis As NAxis
		Private m_BlueAxis As NAxis

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not Page.IsPostBack) Then
				RedAxisZoneDropDownList.Items.Add("Front Left")
				RedAxisZoneDropDownList.Items.Add("Front Right")

				GreenAxisZoneDropDownList.Items.Add("Front Left")
				GreenAxisZoneDropDownList.Items.Add("Front Right")

				BlueAxisZoneDropDownList.Items.Add("Front Left")
				BlueAxisZoneDropDownList.Items.Add("Front Right")
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Axis Docking<br/> <font size = '9pt'>Demonstrates how to use of the dock axis anchor and how to add custom axes</font>")
			header.TextStyle.TextFormat = TextFormat.XML
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' remove all legends
			nChartControl1.Legends.Clear()

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(17, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			m_RedAxis = m_Chart.Axis(StandardAxis.PrimaryY)
			m_GreenAxis = m_Chart.Axis(StandardAxis.SecondaryY)
			m_GreenAxis.Visible = True

			' Add a custom vertical axis
			m_BlueAxis = (CType(m_Chart.Axes, NCartesianAxisCollection)).AddCustomAxis(AxisOrientation.Vertical, AxisDockZone.FrontLeft)

			' create three line series and dispay them on three vertical axes (red, green and blue axis)
			Dim line1 As NLineSeries = CreateLineSeries(Color.Red, Color.DarkRed, 10, 20)
			Dim line2 As NLineSeries = CreateLineSeries(Color.Green, Color.DarkGreen, 50, 100)
			Dim line3 As NLineSeries = CreateLineSeries(Color.Blue, Color.DarkBlue, 100, 200)

			line1.DisplayOnAxis(StandardAxis.PrimaryY, True)

			line2.DisplayOnAxis(StandardAxis.PrimaryY, False)
			line2.DisplayOnAxis(StandardAxis.SecondaryY, True)

			line3.DisplayOnAxis(StandardAxis.PrimaryY, False)
			line3.DisplayOnAxis(m_BlueAxis.AxisId, True)

			' now configure the axis appearance
			Dim linearScale As NLinearScaleConfigurator

			' setup the red axis
			linearScale = New NLinearScaleConfigurator()
			m_RedAxis.ScaleConfigurator = linearScale

			linearScale.RulerStyle.FillStyle = New NColorFillStyle(Color.DarkRed)
			linearScale.RulerStyle.BorderStyle.Color = Color.Red
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Red
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Red
			linearScale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.DarkRed)

			' setup the green axis
			linearScale = New NLinearScaleConfigurator()
			m_GreenAxis.ScaleConfigurator = linearScale

			linearScale.RulerStyle.FillStyle = New NColorFillStyle(Color.DarkGreen)
			linearScale.RulerStyle.BorderStyle.Color = Color.Green
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Green
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Green
			linearScale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.DarkGreen)

			' setup the blue axis
			linearScale = New NLinearScaleConfigurator()
			m_BlueAxis.ScaleConfigurator = linearScale

			linearScale.RulerStyle.FillStyle = New NColorFillStyle(Color.DarkBlue)
			linearScale.RulerStyle.BorderStyle.Color = Color.Blue
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Blue
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Blue
			linearScale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.DarkBlue)

			UpdateAxisAnchors()
		End Sub

		Private Function CreateLineSeries(ByVal lightColor As Color, ByVal darkColor As Color, ByVal begin As Integer, ByVal [end] As Integer) As NLineSeries
			' Add a line series
			Dim line As NLineSeries = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			line.Values.FillRandomRange(Random, 5, begin, [end])
			line.Name = "Line " & lightColor.Name
			line.BorderStyle.Color = darkColor
			line.DataLabelStyle.Format = "<value>"
			line.DataLabelStyle.TextStyle.BackplaneStyle.Visible = False
			line.DataLabelStyle.ArrowStrokeStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			line.DataLabelStyle.ArrowLength = New NLength(2.5f, NRelativeUnit.ParentPercentage)
			line.DataLabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)
			line.InflateMargins = True
			line.MarkerStyle.Visible = True
			line.MarkerStyle.BorderStyle.Color = darkColor
			line.MarkerStyle.FillStyle = New NColorFillStyle(lightColor)
			line.MarkerStyle.PointShape = PointShape.Cylinder
			line.MarkerStyle.Width = New NLength(2, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Height = New NLength(2, NRelativeUnit.ParentPercentage)

			Return line
		End Function

		Private Sub UpdateAxisAnchors()
			If RedAxisZoneDropDownList.SelectedIndex = 0 Then
				m_RedAxis.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, True)
			Else
				m_RedAxis.Anchor = New NDockAxisAnchor(AxisDockZone.FrontRight, True)
			End If

			If GreenAxisZoneDropDownList.SelectedIndex = 0 Then
				m_GreenAxis.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, True)
			Else
				m_GreenAxis.Anchor = New NDockAxisAnchor(AxisDockZone.FrontRight, True)
			End If

			If BlueAxisZoneDropDownList.SelectedIndex = 0 Then
				m_BlueAxis.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, True)
			Else
				m_BlueAxis.Anchor = New NDockAxisAnchor(AxisDockZone.FrontRight, True)
			End If
		End Sub

		Protected Sub RedAxisZoneDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateAxisAnchors()
		End Sub

		Protected Sub GreenAxisZoneDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateAxisAnchors()
		End Sub

		Protected Sub BlueAxisZoneDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateAxisAnchors()
		End Sub
	End Class
End Namespace
