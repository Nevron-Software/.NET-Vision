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
	Public Partial Class NConstLinesUC
		Inherits NExampleUC

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			' disable frame
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Axis Const Lines")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim chart As NChart = nChartControl1.Charts(0)

			chart.Enable3D = True

			' configure the chart margins
			chart.BoundsMode = BoundsMode.Fit
			chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(78, NRelativeUnit.ParentPercentage))

			' set projection and lighting
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)

			' disable the depth axis
			chart.Axis(StandardAxis.Depth).Visible = False
			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' switch the X axis to linear as well
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()

			' Create a point series
			Dim pnt As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			pnt.InflateMargins = True
			pnt.UseXValues = True
			pnt.Name = "Series 1"
			pnt.DataLabelStyle.Format = "<value>"

			' Add some data
			pnt.Values.Add(31)
			pnt.Values.Add(67)
			pnt.Values.Add(12)
			pnt.Values.Add(84)
			pnt.Values.Add(90)
			pnt.XValues.Add(10)
			pnt.XValues.Add(36)
			pnt.XValues.Add(52)
			pnt.XValues.Add(62)
			pnt.XValues.Add(88)

			' Add a constline for the left axis
			Dim cl1 As NAxisConstLine = chart.Axis(StandardAxis.PrimaryY).ConstLines.Add()
			cl1.StrokeStyle.Color = Color.SlateGray
			cl1.FillStyle = New NColorFillStyle(Color.FromArgb(60, Color.SlateGray))
			cl1.Value = 90

			' Add a constline for the bottom axis
			Dim cl2 As NAxisConstLine = chart.Axis(StandardAxis.PrimaryX).ConstLines.Add()
			cl2.StrokeStyle.Color = Color.LightSkyBlue
			cl2.FillStyle = New NColorFillStyle(Color.FromArgb(60, Color.LightSkyBlue))
			cl2.Value = 40

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			If (Not IsPostBack) Then
				' init the form controls
				WebExamplesUtilities.FillComboWithValues(LAValueDropDownList, 0, 100, 10)
				LAStyleDropDownList.Items.Add("Line")
				LAStyleDropDownList.Items.Add("Plane")
				LAStyleDropDownList.SelectedIndex = 1

				WebExamplesUtilities.FillComboWithValues(LABeginValueDropDownList, 0, 100, 10)
				WebExamplesUtilities.FillComboWithValues(LAEndValueDropDownList, 0, 100, 10)

				WebExamplesUtilities.FillComboWithValues(BAValueDropDownList, 0, 100, 10)
				BAStyleDropDownList.Items.Add("Line")
				BAStyleDropDownList.Items.Add("Plane")
				BAStyleDropDownList.SelectedIndex = 1

				WebExamplesUtilities.FillComboWithValues(BABeginValueDropDownList, 0, 100, 10)
				WebExamplesUtilities.FillComboWithValues(BAEndValueDropDownList, 0, 100, 10)

				LAValueDropDownList.SelectedIndex = CInt(Fix(cl1.Value / 10))
				BAValueDropDownList.SelectedIndex = CInt(Fix(cl2.Value / 10))

				LABeginValueDropDownList.SelectedIndex = 0
				LAEndValueDropDownList.SelectedIndex = 10
				BABeginValueDropDownList.SelectedIndex = 0
				BAEndValueDropDownList.SelectedIndex = 10

				LABeginValueDropDownList.Enabled = False
				LAEndValueDropDownList.Enabled = False
				BABeginValueDropDownList.Enabled = False
				BAEndValueDropDownList.Enabled = False
			End If

			Dim leftAxisConstLine As NAxisConstLine = chart.Axis(StandardAxis.PrimaryY).ConstLines(0)

			leftAxisConstLine.Value = (LAValueDropDownList.SelectedIndex * 10)

			Select Case LAStyleDropDownList.SelectedIndex
				Case 0
					leftAxisConstLine.Mode = ConstLineMode.Line

				Case 1
					leftAxisConstLine.Mode = ConstLineMode.Plane
			End Select

			Dim cl As NAxisConstLine = chart.Axis(StandardAxis.PrimaryY).ConstLines(0)
			If LAUseBeginEndValueCheckBox.Checked Then
				Dim referenceAxis As NAxis = chart.Axis(StandardAxis.PrimaryX)
				Dim refBeginValue As Double = Convert.ToDouble(LABeginValueDropDownList.SelectedIndex) * 10
				Dim refEndValue As Double = Convert.ToDouble(LAEndValueDropDownList.SelectedIndex) * 10
				cl.ReferenceRanges.Add(New NReferenceAxisRange(referenceAxis, refBeginValue, refEndValue))

				LABeginValueDropDownList.Enabled = True
				LAEndValueDropDownList.Enabled = True
			Else
				cl.ReferenceRanges.Clear()
				LABeginValueDropDownList.Enabled = False
				LAEndValueDropDownList.Enabled = False
			End If

			' bottom axis
			Dim bottomAxisConstline As NAxisConstLine = chart.Axis(StandardAxis.PrimaryX).ConstLines(0)
			bottomAxisConstline.Value = (BAValueDropDownList.SelectedIndex * 10)

			Select Case BAStyleDropDownList.SelectedIndex
				Case 0
					bottomAxisConstline.Mode = ConstLineMode.Line

				Case 1
					bottomAxisConstline.Mode = ConstLineMode.Plane
			End Select

			cl = chart.Axis(StandardAxis.PrimaryX).ConstLines(0)

			If BAUseBeginEndValueCheckBox.Checked Then
				Dim referenceAxis As NAxis = chart.Axis(StandardAxis.PrimaryY)
				Dim refBeginValue As Double = Convert.ToDouble(BABeginValueDropDownList.SelectedIndex) * 10
				Dim refEndValue As Double = Convert.ToDouble(BAEndValueDropDownList.SelectedIndex) * 10
				cl.ReferenceRanges.Add(New NReferenceAxisRange(referenceAxis, refBeginValue, refEndValue))

				BABeginValueDropDownList.Enabled = True
				BAEndValueDropDownList.Enabled = True
			Else
				cl.ReferenceRanges.Clear()
				BABeginValueDropDownList.Enabled = False
				BAEndValueDropDownList.Enabled = False
			End If


		End Sub
	End Class
End Namespace
