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
	Public Partial Class NMapProjectionsUC
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
			CreateStyleSheets(document)
			CreateStarPointShape(document)
			Dim mapRenderer As MapRenderer = New MapRenderer()
			mapRenderer.InitDocument(document, MapProjections(16))
			document.EndInit()

			' Populate the cities combo box
			PopulateProjectionsComboBox(16)
		End Sub

		#Region "Implementation"

		Private Sub CreateStyleSheets(ByVal document As NDrawingDocument)
			' Create the zoomed city style sheet
			Dim zoomedCity As NStyleSheet = New NStyleSheet()
			zoomedCity.Name = "Zoomed City"
			zoomedCity.Style.FillStyle = New NGradientFillStyle(GradientStyle.FromCenter, GradientVariant.Variant1, Color.DarkRed, Color.Red)
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
		Private Sub PopulateProjectionsComboBox(ByVal checkedIndex As Integer)
			Dim sb As StringBuilder = New StringBuilder()
			Dim i As Integer = 0
			Dim count As Integer = MapProjections.Length
			Do While i < count
				sb.Append("<input type=""radio"" name=""ProjectionRadioButton"" value=""")
				sb.Append(i)
				sb.Append(""" ")
				sb.Append("onclick=""ChangeProjection(this.value)""")
				If i = checkedIndex Then
					sb.Append(" checked=""checked"">")
				Else
					sb.Append(">")
				End If
				sb.Append(MapProjections(i).ToString())
				sb.AppendLine("<br />")
				i += 1
			Loop

			ProjectionsRadioGroup.Text = sb.ToString()
		End Sub

		#End Region

		#Region "Constants"

		Private Const CountriesShapefileName As String = "..\App_Data\Gis_Data\countries.shp"
		Private Shared ReadOnly MapColors As Color() = New Color() { Color.OldLace, Color.PaleGreen, Color.Gold, Color.Gray, Color.Tan, Color.Khaki, Color.IndianRed, Color.Orange, Color.Tomato, Color.PaleGoldenrod, Color.Wheat }

		Private Shared ReadOnly MapProjections As NMapProjection() = New NMapProjection(){ New NAitoffProjection(), New NBonneProjection(), New NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Lambert), New NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Behrmann), New NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.TristanEdwards), New NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Peters), New NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Gall), New NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Balthasart), New NEckertIVProjection(), New NEckertVIProjection(), New NEquirectangularProjection(), New NHammerProjection(), New NKavrayskiyVIIProjection(), New NMercatorProjection(), New NMillerCylindricalProjection(), New NMollweideProjection(), New NOrthographicProjection(), New NRobinsonProjection(), New NStereographicProjection(), New NVanDerGrintenProjection(), New NWagnerVIProjection(), New NWinkelTripelProjection() }

		#End Region

		#Region "Nested Types"

		<Serializable> _
		Private Class CustomRequestCallback
			Implements INCustomRequestCallback
			Private Sub OnCustomRequestCallback(ByVal control As NAspNetThinWebControl, ByVal context As NRequestContext, ByVal argument As String) Implements INCustomRequestCallback.OnCustomRequestCallback
				Dim diagramControl As NThinDiagramControl = CType(control, NThinDiagramControl)
				Dim document As NDrawingDocument = diagramControl.Document
				Dim index As Integer = Int32.Parse(argument)
				Dim mapRenderer As MapRenderer = New MapRenderer()
				mapRenderer.InitDocument(document, MapProjections(index))
				diagramControl.UpdateView()
			End Sub
		End Class

		Private Class MapRenderer
			Public Sub InitDocument(ByVal document As NDrawingDocument, ByVal mapProjection As NMapProjection)
				document.Layers.RemoveAllChildren()
				document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
				document.Bounds = New NRectangleF(0, 0, 5000, 5000)
				document.BackgroundStyle.FillStyle = New NColorFillStyle(Color.LightBlue)

				Dim mapImporter As NEsriMapImporter = New NEsriMapImporter()
				mapImporter.MapBounds = NMapBounds.World

				' Add the countries shape file
				Dim countries As NEsriShapefile = New NEsriShapefile(HttpContext.Current.Server.MapPath(CountriesShapefileName))
				countries.NameColumn = "NAME"
				mapImporter.AddLayer(countries)

				' Read the map data
				mapImporter.Read()

				mapImporter.Projection = mapProjection
				mapImporter.Parallels.ArcRenderMode = ArcRenderMode.Fine
				mapImporter.Meridians.ArcRenderMode = ArcRenderMode.Fine

				' Add a fill rule
				countries.FillRule = New NMapFillRuleValue("ISO_NUM", MapColors)

				' Import the map
				mapImporter.Import(document, document.Bounds)

				' Size the document to content
				document.SizeToContent()
			End Sub
		End Class

		#End Region
	End Class
End Namespace