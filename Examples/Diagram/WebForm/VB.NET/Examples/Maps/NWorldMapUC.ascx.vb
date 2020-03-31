Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Text
Imports System.Web

Imports Nevron.Diagram
Imports Nevron.Diagram.Maps
Imports Nevron.Diagram.ThinWeb
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	Public Partial Class NWorldMapUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If NThinDiagramControl1.Initialized Then
				Return
			End If

			' Init the diagram control
			NThinDiagramControl1.CustomRequestCallback = New CustomRequestCallback()

			' Set manual ID so that it can be referenced in JavaScript
			NThinDiagramControl1.StateId = "Diagram1"

			' Init the view
			NThinDiagramControl1.View.MinZoomFactor = 0.1f
			NThinDiagramControl1.View.MaxZoomFactor = 50
			NThinDiagramControl1.View.Layout = CanvasLayout.Fit

			' Configure the controller
			NThinDiagramControl1.Controller.Tools.Add(New NTooltipTool())
			NThinDiagramControl1.Controller.Tools.Add(New NCursorTool())
			NThinDiagramControl1.Controller.Tools.Add(New NRectZoomTool())
			Dim panTool As NPanTool = New NPanTool()
			panTool.Enabled = False
			NThinDiagramControl1.Controller.Tools.Add(panTool)

			' Configure the toolbar
			NThinDiagramControl1.Toolbar.Visible = True
			NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NZoomInAction()))
			NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NZoomOutAction()))
			NThinDiagramControl1.Toolbar.Items.Add(New NToolbarSeparator())

			Dim values As Array = System.Enum.GetValues(GetType(CanvasLayout))
			Dim i As Integer = 0
			Do While i < values.Length
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleViewLayoutAction(CType(values.GetValue(i), CanvasLayout))))
				i += 1
			Loop

			NThinDiagramControl1.Toolbar.Items.Add(New NToolbarSeparator())
			NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NTogglePanToolAction()))
			NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleRectZoomToolAction()))

			' Init the document
			Dim document As NDrawingDocument = NThinDiagramControl1.Document
			document.BeginInit()
			Dim cities As List(Of NCityInfo) = InitDocument(document)
			document.EndInit()

			' Populate the cities combo box
			PopulateCityComboBox(cities)
		End Sub

		#Region "Implementation"

		Private Function InitDocument(ByVal document As NDrawingDocument) As List(Of NCityInfo)
			document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
			document.Bounds = New NRectangleF(0, 0, 5000, 5000)
			document.BackgroundStyle.FillStyle = New NColorFillStyle(Color.LightBlue)

			CreateStyleSheets(document)
			CreateStarPointShape(document)

			Dim mapImporter As NEsriMapImporter = New NEsriMapImporter()
			mapImporter.MapBounds = NMapBounds.World

			' Add the countries shape file
			Dim countries As NEsriShapefile = New NEsriShapefile(HttpContext.Current.Server.MapPath(CountriesShapefileName))
			countries.NameColumn = "NAME"
			countries.TextColumn = "NAME"
			countries.MaxTextShowZoomFactor = 0.99f
			mapImporter.AddLayer(countries)

			' Add the cities shape file
			Dim cities As NEsriShapefile = New NEsriShapefile(HttpContext.Current.Server.MapPath(CitiesShapefileName))
			cities.NameColumn = "NAME"
			cities.TextColumn = "NAME"
			cities.MinShowZoomFactor = 1.0f

			cities.PointSizeColumn = "POPULATION"
			cities.MinPointShapeSize = New NSizeF(10, 10)
			cities.MaxPointShapeSize = New NSizeF(40, 40)

			mapImporter.AddLayer(cities)

			' Read the map data
			mapImporter.Read()

			' Set a fill rule for the countries
			countries.FillRule = New NMapFillRuleValue("ISO_NUM", MapColors)

			' Add a shape created listener
			mapImporter.ShapeCreatedListener = New NCustomShapeCreatedListener()

			' Import the map
			mapImporter.Import(document, document.Bounds)

			' Size the document to content
			document.SizeToContent()

			Return (CType(mapImporter.ShapeCreatedListener, NCustomShapeCreatedListener)).Cities
		End Function
		Private Sub CreateStyleSheets(ByVal document As NDrawingDocument)
			' Create the zoomed city style sheet
			Dim zoomedCity As NStyleSheet = New NStyleSheet()
			zoomedCity.Name = "ZoomedCity"
			Dim textStyle As NTextStyle = CType(document.ComposeTextStyle().Clone(), NTextStyle)
			textStyle.FontStyle = New NFontStyle(textStyle.FontStyle.Name, textStyle.FontStyle.EmSize, FontStyle.Bold)
			NStyle.SetTextStyle(zoomedCity, textStyle)
			NStyle.SetFillStyle(zoomedCity, New NColorFillStyle(Color.Red))
			document.StyleSheets.AddChild(zoomedCity)
		End Sub
		Private Sub CreateStarPointShape(ByVal document As NDrawingDocument)
			' create the graphics path representing the point shape
			Dim modelBounds As NRectangleF = New NRectangleF(-1, -1, 2, 2)
			Dim path As GraphicsPath = New GraphicsPath()
			CreateNGramPath(path, modelBounds, 5, - NMath.PIHalf, 0.5f)

			' wrap it in amodel and name it
			Dim customPath As NCustomPath = New NCustomPath(path, PathType.ClosedFigure)
			customPath.Name = "Star"

			' add it to the stencil
			document.PointShapeStencil.AddChild(customPath)
		End Sub
		Private Sub CreateNGramPath(ByVal path As GraphicsPath, ByVal rect As NRectangleF, ByVal edgeCount As Integer, ByVal startAngle As Single, ByVal innerRadius As Single)
			Dim i As Integer
			Dim angle As Single
			Dim halfWidth As Single = rect.Width / 2.0f
			Dim halfHeight As Single = rect.Height / 2.0f
			Dim centerX As Single = rect.X + halfWidth
			Dim centerY As Single = rect.Y + halfHeight
			Dim incAngle As Single = CSng(2 * Math.PI / edgeCount)
			Dim innerOffsetAngle As Single = CSng(Math.PI / edgeCount)

			Dim outer As PointF() = New PointF(edgeCount - 1){}
			Dim inner As PointF() = New PointF(edgeCount - 1){}

			i = 0
			Do While i < edgeCount
				angle = startAngle + i * incAngle
				outer(i).X = CSng(Math.Round(centerX + Math.Cos(angle) * halfWidth, 1))
				outer(i).Y = CSng(Math.Round(centerY + Math.Sin(angle) * halfHeight, 1))

				angle += innerOffsetAngle
				inner(i).X = CSng(Math.Round(centerX + Math.Cos(angle) * innerRadius, 1))
				inner(i).Y = CSng(Math.Round(centerY + Math.Sin(angle) * innerRadius, 1))
				i += 1
			Loop

			i = 0
			Do While i < (edgeCount - 1)
				path.AddLine(outer(i), inner(i))
				path.AddLine(inner(i), outer(i + 1))
				i += 1
			Loop

			path.AddLine(outer(i), inner(i))
			path.CloseAllFigures()
		End Sub
		Private Sub PopulateCityComboBox(ByVal cities As List(Of NCityInfo))
			cities.Sort()

			Dim sb As StringBuilder = New StringBuilder()
			sb.Append("<select id='citiesCombo'>")

			Dim i As Integer = 0
			Do While i < cities.Count
				Dim location As NPointF = cities(i).Location
				sb.AppendFormat(CultureInfo.InvariantCulture, "<option value=""{0},{1}"">{2}</option>", location.X, location.Y, cities(i).Name)
				i += 1
			Loop

			sb.Append("</select>")
			CitiesComboBox.Text = sb.ToString()
		End Sub

		#End Region

		#Region "Constants"

		Private Const CountriesShapefileName As String = "..\App_Data\Gis_Data\countries.shp"
		Private Const CitiesShapefileName As String = "..\App_Data\Gis_Data\cities.shp"
		Private Shared ReadOnly MapColors As Color() = New Color() { Color.OldLace, Color.PaleGreen, Color.Gold, Color.Gray, Color.Tan, Color.Khaki, Color.IndianRed, Color.Orange, Color.Tomato, Color.PaleGoldenrod, Color.Wheat }

		#End Region

		#Region "Nested Types"

		Private Class NCityInfo
			Implements IComparable(Of NCityInfo)
'INSTANT VB NOTE: The parameter name was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter location was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
			Public Sub New(ByVal name_Renamed As String, ByVal location_Renamed As NPointF)
				Name = name_Renamed
				Location = location_Renamed
			End Sub

			Public Function CompareTo(ByVal other As NCityInfo) As Integer Implements IComparable(Of NCityInfo).CompareTo
				Return Me.Name.CompareTo(other.Name)
			End Function

			Public Name As String
			Public Location As NPointF
		End Class

		Private Class NCustomShapeCreatedListener
			Inherits NShapeCreatedListener
			#Region "Constructors"

			Public Sub New()
				Cities = New List(Of NCityInfo)()
			End Sub

			#End Region

			#Region "INShapeCreatedListener"

			Public Overrides Function OnPointCreated(ByVal pointLabel As NMapPointLabel, ByVal mapFeature As NMapFeature) As Boolean
				Dim name As String = mapFeature.GetAttributeValue("NAME").ToString()
				Cities.Add(New NCityInfo(name, pointLabel.PinPoint))

				If mapFeature.GetAttributeValue("CAPITAL").Equals("Y") Then
					pointLabel.ShapeType = PointShape.Custom
					pointLabel.CustomShapeName = "Star"
				End If

				Return True
			End Function

			#End Region

			#Region "Fields"

			Public Cities As List(Of NCityInfo)

			#End Region

			#Region "Constants"

			Private Shared ReadOnly cityPopulationScales As Single(,) = New Single(, ){ {1000000, 1.3f}, {2000000, 1.6f}, {5000000, 2.0f}, {10000000, 2.5f}, {20000000, 3.0f} }

			#End Region
		End Class

		<Serializable> _
		Private Class CustomRequestCallback
			Implements INCustomRequestCallback
			Private Sub OnCustomRequestCallback(ByVal control As NAspNetThinWebControl, ByVal context As NRequestContext, ByVal argument As String) Implements INCustomRequestCallback.OnCustomRequestCallback
				Dim diagramControl As NThinDiagramControl = CType(control, NThinDiagramControl)
				Dim document As NDrawingDocument = diagramControl.Document

				Dim args As String() = argument.Split(","c)
				Dim cityName As String = args(0)
				Dim x As Single = Single.Parse(args(1), CultureInfo.InvariantCulture)
				Dim y As Single = Single.Parse(args(2), CultureInfo.InvariantCulture)

				If TypeOf document.Tag Is NPointElement Then
					CType(document.Tag, NPointElement).StyleSheetName = String.Empty
					document.Tag = Nothing
				End If

				Dim cityLayer As NLayer = TryCast(diagramControl.Document.Layers.GetChildByName("cities"), NLayer)
				If Not cityLayer Is Nothing Then
					' Apply the new style to the newly zoomed city
					Dim labelsShape As NMapLabelsShape = CType(cityLayer.GetChildAt(0), NMapLabelsShape)
					Dim city As NMapPointLabel = CType(labelsShape.MapLabels.GetChildByName(cityName), NMapPointLabel)
					city.StyleSheetName = "ZoomedCity"

					' Remember the currently highlighted city in the document's tag
					document.Tag = city
				End If

				diagramControl.View.Layout = CanvasLayout.Normal
				diagramControl.Zoom(2, New NPointF(x, y))
			End Sub
		End Class

		#End Region
	End Class
End Namespace