Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Data
Imports System.IO
Imports System.Windows.Forms
Imports System.Reflection
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.UI

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NLabelImageEmbeddingUC
		Inherits NExampleBaseUC

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

				' IMPORTANT! - you have to clear the repository once done with the control in order to 
				' prevent memory leaks from images stored in it
				NImageRepository.Instance.Clear()
			End If

			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.SuspendLayout()
			' 
			' NLabelImageEmbeddingUC
			' 
			Me.Name = "NLabelImageEmbeddingUC"
			Me.Size = New System.Drawing.Size(180, 542)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' create chart title
			Dim label As New NLabel()
			nChartControl1.Panels.Add(label)

			label.Text = "Verified CO<sub>2</sub> Emissions for 2005<br/>Proposed and Allowed Emissions Caps for 2008-2012"
			label.TextStyle.FontStyle = New NFontStyle("Sylfaen", 13)
			label.TextStyle.TextFormat = TextFormat.XML
			label.TextStyle.ShadowStyle.Type = ShadowType.GaussianBlur
			label.TextStyle.ShadowStyle.FadeLength = New NLength(4)
			label.TextStyle.ShadowStyle.Offset = New NPointL(New NLength(1, NGraphicsUnit.Pixel), New NLength(1, NGraphicsUnit.Pixel))
			label.ContentAlignment = ContentAlignment.BottomCenter
			label.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(1, NRelativeUnit.ParentPercentage))

			' create a legend
			Dim legend As New NLegend()
			nChartControl1.Panels.Add(legend)

			legend.ContentAlignment = ContentAlignment.TopRight
			legend.Location = New NPointL(New NLength(0.8F, NRelativeUnit.ParentPercentage), New NLength(99, NRelativeUnit.ParentPercentage))
			legend.Data.MarkSize = New NSizeL(New NLength(4, NGraphicsUnit.Point), New NLength(4, NGraphicsUnit.Point))

			Dim chart As NChart = New NCartesianChart()
			nChartControl1.Charts.Add(chart)

			chart.BoundsMode = BoundsMode.Stretch
			chart.DisplayOnLegend = legend

			Dim scaleY As New NLinearScaleConfigurator()

			' setup title
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.Title.Text = "MMTCO<sub>2</sub> Eq."
			scaleY.Title.TextStyle.TextFormat = TextFormat.XML
			scaleY.Title.Angle = New NScaleLabelAngle(90)

			' add interlace stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			scaleY.StripStyles.Add(stripStyle)

			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			Dim table As DataTable = CreateDataTable()

			Dim scaleX As New NOrdinalScaleConfigurator()
			scaleX.AutoLabels = False

			' register images in the repository. You can later access the image
			' from it's alias in XML formatted text
			Dim countlyFlagResourceName() As String = { "Austria.png", "Finland.png", "France.png", "Germany.png", "Greece.png", "Italy.png", "Poland.png", "Spain.png", "Sweden.png", "UK.png" }
			Dim countlyFlagAlias() As String = { "Austria", "Finland", "France", "Germany", "Greece", "Italy", "Poland", "Spain", "Sweden", "UK" }

			For i As Integer = 0 To countlyFlagResourceName.Length - 1
				Dim bmp As Bitmap = GetCountrlyFlagImage(countlyFlagResourceName(i))
				NImageRepository.Instance.RegisterImage(countlyFlagAlias(i), bmp)
			Next i

			scaleX.LabelStyle.TextStyle.TextFormat = TextFormat.XML

			' add labels from data table
			For i As Integer = 0 To table.Rows.Count - 1
				Dim row As DataRow = table.Rows(i)
				scaleX.Labels.Add(row(0))
			Next i

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			CreateClusterBars(chart, table)

			' apply layout
			ConfigureStandardLayout(chart, label, legend)

			nChartControl1.Refresh()
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
			For i As Integer = 0 To table.Rows.Count - 1
				Dim row As DataRow = table.Rows(i)

				proposed.Labels.Add(row(0))

				electricEmissions.Values.Add(row(3))
				transportationEmissions.Values.Add(row(4))
				industrialEmissions.Values.Add(row(5))
				proposed.Values.Add(row(6))
				allowed.Values.Add(row(7))
			Next i
		End Sub

		Private Function GetCountrlyFlagImage(ByVal countryFlag As String) As Bitmap
			Return NResourceHelper.BitmapFromResource(Me.GetType(), countryFlag, "Nevron.Examples.Chart.WinForm.Resources")
		End Function

		Private Function CreateDataTable() As DataTable
			Dim table As New DataTable()

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

			rows.Add("Austria <br/> <img size = '40, 20' alias ='Austria' />", 14.3, 47.3, 18.5, 10.1, 4.8, 25.2, 22.8)
			rows.Add("Finland <br/> <img size = '40, 20' alias ='Finland' />", 20.0, 63.0, 16.9, 9.5, 6.7, 39.6, 37.6)
			rows.Add("France <br/> <img size = '40, 20' alias ='France' />", 4.0, 46.0, 55.8, 38.1, 37.4, 132.8, 132.8)
			rows.Add("Germany <br/> <img size = '40, 20' alias ='Germany' />", 10.5, 50.5, 212.4, 140.4, 121.2, 482, 453.1)
			rows.Add("Greece <br/> <img size = '40, 20' alias ='Greece' />", 22.5, 39.9, 30.7, 23, 17.6, 75.5, 69.1)
			rows.Add("Italy <br/> <img size = '40, 20' alias ='Italy' />", 12.0, 43.0, 98.9, 69.7, 56.9, 209, 195.8)
			rows.Add("Poland <br/> <img size = '40, 20' alias ='Poland' />", 17.3, 51.8, 101.3, 64.2, 37.6, 284.6, 208.5)
			rows.Add("Spain <br/> <img size = '40, 20' alias ='Spain' />", -3.0, 40.0, 97.1, 52.8, 33, 152.7, 152.3)
			rows.Add("Sweden <br/> <img size = '40, 20' alias ='Sweden' />", 13.3, 62.0, 9.2, 6.1, 4, 25.2, 22.8)
			rows.Add("UK <br/> <img size = '40, 20' alias ='UK' />", 1.2, 52.0, 114.4, 71.3, 56.7, 246.2, 246.2)

			Return table
		End Function
	End Class
End Namespace
