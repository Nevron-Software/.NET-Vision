Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NLogarithmicScaleUC
		Inherits NExampleUC

		Private m_Chart As NChart
		Private m_Line As NLineSeries

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not IsPostBack) Then
				LogarithmBaseTextBox.Text = "10"

				LabelFormatDropDownList.Items.Add("Default")
				LabelFormatDropDownList.Items.Add("Scientific")
				LabelFormatDropDownList.SelectedIndex = 0
				RoundToTickMin.Checked = True
				RoundToTickMax.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Logarithmic Scale")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Fit

			m_Chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
			m_Chart.BoundsMode = BoundsMode.Stretch

			m_Chart.Axis(StandardAxis.Depth).Visible = False

			Dim logarithmicScale As NLogarithmicScaleConfigurator = New NLogarithmicScaleConfigurator()
			logarithmicScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			logarithmicScale.MinorGridStyle.LineStyle.Pattern = LinePattern.Dot
			logarithmicScale.MinorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			logarithmicScale.MinorTickCount = 3
			logarithmicScale.MajorTickMode = MajorTickMode.CustomStep

			' add a strip line style
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle()
			stripStyle.FillStyle = New NColorFillStyle(Color.Beige)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			logarithmicScale.StripStyles.Add(stripStyle)

			logarithmicScale.CustomStep = 1

			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = logarithmicScale

			m_Line = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line.Legend.Mode = SeriesLegendMode.None
			m_Line.InflateMargins = False
			m_Line.MarkerStyle.Visible = True
			m_Line.MarkerStyle.PointShape = PointShape.Cylinder
			m_Line.MarkerStyle.Width = New NLength(0.7f, NRelativeUnit.ParentPercentage)
			m_Line.MarkerStyle.Height = New NLength(0.7f, NRelativeUnit.ParentPercentage)
			m_Line.MarkerStyle.AutoDepth = True
			m_Line.DataLabelStyle.Format = "<value>"
			m_Line.DataLabelStyle.ArrowStrokeStyle.Color = Color.CornflowerBlue

			Dim frameStyle As NStandardFrameStyle = m_Line.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle
			frameStyle.InnerBorderColor = Color.CornflowerBlue

			m_Line.Values.Add(12)
			m_Line.Values.Add(100)
			m_Line.Values.Add(250)
			m_Line.Values.Add(500)
			m_Line.Values.Add(1500)
			m_Line.Values.Add(5500)
			m_Line.Values.Add(9090)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			UpdateScale()
		End Sub

		Private Sub UpdateScale()
			Dim axis As NAxis = m_Chart.Axis(StandardAxis.PrimaryY)
			Dim logarithmicScale As NLogarithmicScaleConfigurator = TryCast(axis.ScaleConfigurator, NLogarithmicScaleConfigurator)

			' check if null (user may have changed the scale with the editor)
			If logarithmicScale Is Nothing Then
				Return
			End If

			Dim logBase As Double = Convert.ToDouble(LogarithmBaseTextBox.Text)
			If logBase < 2 Then
				logBase = 2
			ElseIf logBase > 30 Then
				logBase = 30
			End If

			logarithmicScale.LogarithmBase = logBase

			Select Case LabelFormatDropDownList.SelectedIndex
			Case 0
				logarithmicScale.LabelValueFormatter = New NNumericValueFormatter(NumericValueFormat.General)

			Case 1
				logarithmicScale.LabelValueFormatter = New NNumericValueFormatter(NumericValueFormat.Scientific)
			End Select

			logarithmicScale.RoundToTickMax = RoundToTickMax.Checked
			logarithmicScale.RoundToTickMin = RoundToTickMin.Checked
		End Sub
	End Class
End Namespace
