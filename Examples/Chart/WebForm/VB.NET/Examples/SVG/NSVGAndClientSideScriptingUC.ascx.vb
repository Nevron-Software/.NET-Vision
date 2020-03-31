Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Text
Imports Nevron.Chart
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NSVGAndClientSideScriptingUC
		Inherits NExampleUC
		Private Sub AddWatermark(ByVal containerPanel As NDockPanel, ByVal sFileName As String)
			Dim watermark As NWatermark = New NWatermark()
			watermark.StandardFrameStyle.InnerBorderWidth = New NLength(0, NGraphicsUnit.Pixel)
			watermark.StandardFrameStyle.OuterBorderWidth = New NLength(0, NGraphicsUnit.Pixel)
			watermark.FillStyle = New NImageFillStyle(Me.MapPathSecure(Me.TemplateSourceDirectory & "\" & sFileName))

			watermark.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(55, NRelativeUnit.ParentPercentage))

			watermark.ContentAlignment = ContentAlignment.MiddleCenter
			watermark.UseAutomaticSize = False
			watermark.Size = New NSizeL(New NLength(100, NGraphicsUnit.Pixel), New NLength(100, NGraphicsUnit.Pixel))

			containerPanel.ChildPanels.Add(watermark)
		End Sub

		Private Function GetScript() As String
			Dim script As StringBuilder = New StringBuilder()

			script.AppendLine("function ShowWatermark(evt, watermarkID, divId)")
			script.AppendLine("{")
			script.AppendLine("var svgDocument = evt.target.ownerDocument;")
'			script.AppendLine("svgDocument = null;");

			Dim i As Integer = 0
			Do While i < nChartControl1.Watermarks.Count
				Dim watermarkId As String = New NElementIdentifier(nChartControl1.Watermarks(i).Id).ToString()
				script.AppendLine("svgDocument.getElementById(""" & watermarkId & """).setAttribute('style', 'visibility:hidden')")
				i += 1
			Loop

			script.AppendLine("if (svgDocument.getElementById(watermarkID))")
			script.AppendLine("{")
			script.AppendLine("	svgDocument.getElementById(watermarkID).setAttribute('style', 'visibility:visible')")
			script.AppendLine("}")

			script.AppendLine("parent.ShowDiv(divId);")
			script.AppendLine("}")

			Return script.ToString()
		End Function

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.Panels.Clear()

			' add watermarks

			Dim divIds As String() = New String() { "toyota", "chevrolet", "ford", "volkswagen", "hyundai", "nissan", "mazda" }

			nChartControl1.BackgroundStyle.FillStyle = New NColorFillStyle(Color.LightGray)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' add header
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Car Sales by Company")
			header.TextStyle.BackplaneStyle.Visible = False
			header.TextStyle.TextFormat = TextFormat.XML
			header.TextStyle.ShadowStyle.Type = ShadowType.GaussianBlur
			header.TextStyle.FillStyle = New NColorFillStyle(Color.Black)
			header.DockMode = PanelDockMode.Top
			header.Margins = New NMarginsL(0, 10, 0, 0)

			' by default the chart contains a cartesian chart which cannot display a pie series
			Dim dockPanel As NDockPanel = New NDockPanel()

			dockPanel.DockMode = PanelDockMode.Fill
			dockPanel.PositionChildPanelsInContentBounds = True
			dockPanel.Margins = New NMarginsL(10, 10, 10, 10)

			nChartControl1.Panels.Add(dockPanel)

			AddWatermark(dockPanel, "ToyotaLogo.png")
			AddWatermark(dockPanel, "ChevroletLogo.png")
			AddWatermark(dockPanel, "FordLogo.png")
			AddWatermark(dockPanel, "VolkswagenLogo.png")
			AddWatermark(dockPanel, "HyundaiLogo.png")
			AddWatermark(dockPanel, "NissanLogo.png")
			AddWatermark(dockPanel, "MazdaLogo.png")

			Dim pieChart As NPieChart = New NPieChart()
			dockPanel.ChildPanels.Add(pieChart)

			Dim pieSeries As NPieSeries = New NPieSeries()
			pieChart.Series.Add(pieSeries)

			' add some data
			pieSeries.AddDataPoint(New NDataPoint(11.6, "Toyota Corolla"))
			pieSeries.AddDataPoint(New NDataPoint(9.7, "Chevrolet Cruze"))
			pieSeries.AddDataPoint(New NDataPoint(9.3, "Ford Focus"))
			pieSeries.AddDataPoint(New NDataPoint(7.1, "Volkswagen Jetta"))
			pieSeries.AddDataPoint(New NDataPoint(7.0, "Hyundai Elantra"))
			pieSeries.AddDataPoint(New NDataPoint(6.1, "Nissan Versa"))
			pieSeries.AddDataPoint(New NDataPoint(5.9, "Mazda 3"))
			pieSeries.AddDataPoint(New NDataPoint(43.4, "Other"))

			pieSeries.PieStyle = PieStyle.Torus
			pieSeries.LabelMode = PieLabelMode.Center

			' configure interactivity for data points
			Dim i As Integer = 0
			Do While i < pieSeries.Values.Count
				Dim interactivityStyle As NInteractivityStyle = New NInteractivityStyle()

				If i < nChartControl1.Watermarks.Count Then
					Dim watermarkId As String = New NElementIdentifier(nChartControl1.Watermarks(i).Id).ToString()
					interactivityStyle.CustomMapAreaAttribute.JScriptAttribute = "onmouseover = 'ShowWatermark(evt, """ & watermarkId & """, """ & divIds(i) & """)'"
				Else
					interactivityStyle.CustomMapAreaAttribute.JScriptAttribute = "onmouseover = 'ShowWatermark(evt, null, null)'"
				End If

				pieSeries.InteractivityStyles.Add(i, interactivityStyle)
				i += 1
			Loop

			nChartControl1.InteractivityStyle.CustomMapAreaAttribute.JScriptAttribute = "onmouseover = 'ShowWatermark(evt, null, null)'"

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.BrightMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' configure the control to generate SVG.
			Dim imageResponse As NImageResponse = New NImageResponse()
			Dim svgImageFormat As NSvgImageFormat = New NSvgImageFormat()

			svgImageFormat.EnableInteractivity = True
			svgImageFormat.CustomScript = GetScript()
			svgImageFormat.EmbedImagesInSvg = True
			svgImageFormat.EmbeddedImageFormat = New NJpegImageFormat()

			Dim attributes As Hashtable = New Hashtable()
			attributes("preserveAspectRatio") = "yMid slice"
'			attributes["onload"] = "Initialize(evt)";
			svgImageFormat.Attributes = attributes
			imageResponse.ImageFormat = svgImageFormat

			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageResponse
		End Sub
	End Class
End Namespace

