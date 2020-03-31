Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NEvaluatingUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				FunctionDropDownList.Items.Add("MIN")
				FunctionDropDownList.Items.Add("MAX")
				FunctionDropDownList.Items.Add("AVE")
				FunctionDropDownList.Items.Add("SUM")
				FunctionDropDownList.Items.Add("ABSSUM")
				FunctionDropDownList.Items.Add("FIRST")
				FunctionDropDownList.Items.Add("LAST")
				FunctionDropDownList.SelectedIndex = 0
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' add header
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Evaluating Data")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.TextStyle.FillStyle = New NColorFillStyle(Color.FromArgb(60, 90, 108))
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure the legend
			nChartControl1.Legends.Clear()

			' setup the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Values.FillRandom(Random, 10)

			Dim subset As NDataSeriesSubset = New NDataSeriesSubset()
			subset.AddRange(0, 9)

			Dim [function] As String = FunctionDropDownList.SelectedItem.Text
			Dim result As Double = bar.Values.Evaluate([function], subset)

			ResultTextBox.Text = result.ToString()
		End Sub
	End Class
End Namespace
