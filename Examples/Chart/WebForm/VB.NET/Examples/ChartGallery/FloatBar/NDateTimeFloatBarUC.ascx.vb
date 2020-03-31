Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NDateTimeFloatBarUC
		Inherits NExampleUC
' protected Label Label1;
'protected Label Label2;
'protected Label Label3;
'protected DropDownList BarStyleDropDownList;
'protected DropDownList WidthPercentDropDownList;
'protected DropDownList DepthPercentDropDownList;

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("DateTime Float Bar")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' setup Y axis
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			scaleY.StripStyles.Add(stripStyle)

			' setup X axis
			Dim scaleX As NDateTimeScaleConfigurator = New NDateTimeScaleConfigurator()
			scaleX.LabelStyle.Angle = New NScaleLabelAngle(90)
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' create the float bar series
			Dim floatBar As NFloatBarSeries = CType(chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			floatBar.UseXValues = True
			floatBar.UseZValues = False
			floatBar.InflateMargins = True
			floatBar.DataLabelStyle.Visible = False
			floatBar.ShadowStyle.Type = ShadowType.Solid
			floatBar.ShadowStyle.Color = Color.FromArgb(30, 0, 0, 0)
			floatBar.Values.ValueFormatter = New NNumericValueFormatter("0.0")
			floatBar.EndValues.ValueFormatter = New NNumericValueFormatter("0.0")

			' show the begin end values in the legend
			floatBar.Legend.Format = "<begin> - <end>"
			floatBar.Legend.Mode = SeriesLegendMode.DataPoints

			GenerateData(floatBar)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub

		Private Sub GenerateData(ByVal floatBar As NFloatBarSeries)
			Const nCount As Integer = 6

			floatBar.Values.Clear()
			floatBar.EndValues.Clear()
			floatBar.XValues.Clear()

			' generate Y values
			For i As Integer = 0 To nCount - 1
				Dim dBeginValue As Double = Random.NextDouble() * 5
				Dim dEndValue As Double = dBeginValue + 2 + Random.NextDouble()
				floatBar.Values.Add(dBeginValue)
				floatBar.EndValues.Add(dEndValue)
			Next i

			' generate X values
			Dim dt As DateTime = New DateTime(2005, 5, 24, 11, 0, 0)

			For i As Integer = 0 To nCount - 1
				dt = dt.AddHours(12 + Random.NextDouble() * 60)

				floatBar.XValues.Add(dt)
			Next i
		End Sub
	End Class
End Namespace
