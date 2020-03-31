Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports System.IO

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NLabelsImageEmbeddingUC
		Inherits NExampleUC
		Protected LabelsGeneral As HtmlForm
		Protected m_CountryToBase64EncodedImage As Dictionary(Of String, String)

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.Panels.Clear()
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' create a map for country name equals base64 encoded data (must start with "data:"
			Dim countlyFlagResourceName As String() = New String() { "Austria.png", "Finland.png", "France.png", "Germany.png", "Greece.png"}
			m_CountryToBase64EncodedImage = New Dictionary(Of String, String)()

			Dim i As Integer = 0
			Do While i < countlyFlagResourceName.Length
				Dim countryFlagFile As String = countlyFlagResourceName(i)
				Dim [alias] As String = countlyFlagResourceName(i).Split("."c)(0)

				Dim countryFlagBytes As Byte() = File.ReadAllBytes(Me.MapPathSecure("~\Images\" & countryFlagFile))

				m_CountryToBase64EncodedImage([alias]) = "data:" & System.Convert.ToBase64String(countryFlagBytes)
				i += 1
			Loop

			' create chart title
			Dim label As NLabel = New NLabel()
			nChartControl1.Panels.Add(label)

			label.Text = "Verified CO<sub>2</sub> Emissions for 2005<br/>Proposed and Allowed Emissions Caps for 2008-2012"
			label.TextStyle.FontStyle = New NFontStyle("Sylfaen", 10)
			label.TextStyle.TextFormat = TextFormat.XML
			label.TextStyle.ShadowStyle.Type = ShadowType.GaussianBlur
			label.TextStyle.ShadowStyle.FadeLength = New NLength(4)
			label.TextStyle.ShadowStyle.Offset = New NPointL(New NLength(1, NGraphicsUnit.Pixel), New NLength(1, NGraphicsUnit.Pixel))
			label.DockMode = PanelDockMode.Top
			label.Margins = New NMarginsL(2, 2, 2, 0)

			' create a chart
			Dim chart As NChart = New NCartesianChart()
			nChartControl1.Charts.Add(chart)

			' create a legend
			Dim legend As NLegend = New NLegend()
			chart.ChildPanels.Add(legend)

			legend.ContentAlignment = ContentAlignment.BottomRight
			legend.Margins = New NMarginsL(4, 4, 4, 2)
			legend.Location = New NPointL(New NLength(0, NRelativeUnit.ParentPercentage), New NLength(0, NRelativeUnit.ParentPercentage))
			legend.Data.MarkSize = New NSizeL(New NLength(4, NGraphicsUnit.Point), New NLength(4, NGraphicsUnit.Point))
			legend.FillStyle = New NColorFillStyle(Color.FromArgb(100, Color.White))
			legend.OuterBottomBorderStyle.Width = New NLength(0)
			legend.OuterTopBorderStyle.Width = New NLength(0)
			legend.OuterLeftBorderStyle.Width = New NLength(0)
			legend.OuterRightBorderStyle.Width = New NLength(0)
			legend.VerticalBorderStyle.Width = New NLength(0)

			' configure chart
			chart.DisplayOnLegend = legend

			chart.BoundsMode = BoundsMode.Stretch
			chart.DockMode = PanelDockMode.Fill
			chart.Margins = New NMarginsL(4, 4, 4, 4)
			chart.PositionChildPanelsInContentBounds = True

			Dim scaleY As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleY.InnerMajorTickStyle.Visible = False

			' setup title
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.Title.Text = "MMTCO<sub>2</sub> Eq."
			scaleY.Title.TextStyle.TextFormat = TextFormat.XML
			scaleY.Title.Angle = New NScaleLabelAngle(90)

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back, ChartWallType.Left }
			scaleY.StripStyles.Add(stripStyle)
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			Dim table As DataTable = CreateDataTable()

			Dim scaleX As NOrdinalScaleConfigurator = New NOrdinalScaleConfigurator()
			scaleX.AutoLabels = False
			scaleX.LabelStyle.TextStyle.TextFormat = TextFormat.XML

			' add labels from data table
			i = 0
			Do While i < table.Rows.Count
				Dim row As DataRow = table.Rows(i)
				scaleX.Labels.Add(row(0))
				i += 1
			Loop

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			CreateClusterBars(chart, table)
		End Sub

		Private Sub CreateClusterBars(ByVal chart As NChart, ByVal table As DataTable)
			Dim electricEmissions As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			electricEmissions.Name = "2005 Emissions - Electric Power"
			electricEmissions.FillStyle = New NColorFillStyle(Color.FromArgb(195, 193, 27))
			electricEmissions.MultiBarMode = MultiBarMode.Series
			electricEmissions.DataLabelStyle.Visible = False
			electricEmissions.BorderStyle.Width = New NLength(0)

			Dim transportationEmissions As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			transportationEmissions.Name = "2005 Emissions - Transportation"
			transportationEmissions.FillStyle = New NColorFillStyle(Color.FromArgb(182, 98, 17))
			transportationEmissions.MultiBarMode = MultiBarMode.Stacked
			transportationEmissions.DataLabelStyle.Visible = False
			transportationEmissions.BorderStyle.Width = New NLength(0)

			Dim industrialEmissions As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			industrialEmissions.Name = "2005 Emissions - Industrial & Other"
			industrialEmissions.FillStyle = New NColorFillStyle(Color.FromArgb(144, 47, 79))
			industrialEmissions.MultiBarMode = MultiBarMode.Stacked
			industrialEmissions.DataLabelStyle.Visible = False
			industrialEmissions.BorderStyle.Width = New NLength(0)

			Dim proposed As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			proposed.Name = "Proposed Cap 2008-2012"
			proposed.FillStyle = New NColorFillStyle(Color.FromArgb(94, 129, 179))
			proposed.MultiBarMode = MultiBarMode.Clustered
			proposed.DataLabelStyle.Visible = False
			proposed.BorderStyle.Width = New NLength(0)

			Dim allowed As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			allowed.Name = "Allowed Cap 2008-2012"
			allowed.FillStyle = New NColorFillStyle(Color.FromArgb(141, 77, 232))
			allowed.MultiBarMode = MultiBarMode.Clustered
			allowed.DataLabelStyle.Visible = False
			allowed.BorderStyle.Width = New NLength(0)

			' fill the data
			Dim i As Integer = 0
			Do While i < table.Rows.Count
				Dim row As DataRow = table.Rows(i)

				proposed.Labels.Add(row(0))

				electricEmissions.Values.Add(row(3))
				transportationEmissions.Values.Add(row(4))
				industrialEmissions.Values.Add(row(5))
				proposed.Values.Add(row(6))
				allowed.Values.Add(row(7))
				i += 1
			Loop
		End Sub

		Private Function CreateDataTable() As DataTable
			Dim table As DataTable = New DataTable()

			Dim cols As DataColumnCollection = table.Columns
			Dim rows As DataRowCollection = table.Rows

			cols.Add("Country", GetType(String))
			cols.Add("Longitude", GetType(Double))
			cols.Add("Latitude", GetType(Double))
			cols.Add("2005 Electric", GetType(Double))
			cols.Add("2005 Transport", GetType(Double))
			cols.Add("2005 Industrial", GetType(Double))
			cols.Add("ProposedCap", GetType(Double))
			cols.Add("AllowedCap", GetType(Double))

			rows.Add("Austria <br/> <img size = '40, 20' src ='" & m_CountryToBase64EncodedImage("Austria") & "' />", 14.3, 47.3, 18.5, 10.1, 4.8, 25.2, 22.8)
			rows.Add("Finland <br/> <img size = '40, 20' src ='" & m_CountryToBase64EncodedImage("Finland") & "' />", 20.0, 63.0, 16.9, 9.5, 6.7, 39.6, 37.6)
			rows.Add("France <br/> <img size = '40, 20' src ='" & m_CountryToBase64EncodedImage("France") & "' />", 4.0, 46.0, 55.8, 38.1, 37.4, 132.8, 132.8)
			rows.Add("Germany <br/> <img size = '40, 20' src ='" & m_CountryToBase64EncodedImage("Germany") & "' />", 10.5, 50.5, 212.4, 140.4, 121.2, 482, 453.1)
			rows.Add("Greece <br/> <img size = '40, 20' src ='" & m_CountryToBase64EncodedImage("Greece") & "' />", 22.5, 39.9, 30.7, 23, 17.6, 75.5, 69.1)

			Return table
		End Function
	End Class
End Namespace
