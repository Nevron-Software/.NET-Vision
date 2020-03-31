Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Text
Imports System.Xml

Imports Nevron.GraphicsCore
Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.UI.WebForm.Controls
Imports Nevron.Examples.Framework.WebForm

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''		Summary description for NInteractiveSVGDiagram.
	''' </summary>
	Public Partial Class NInteractiveSVGDiagram
		Inherits System.Web.UI.UserControl
		Protected Document As NDrawingDocument

		Private Function ColorToSVG(ByVal color As Color) As String
			Dim arrHexDigit As Char() = New Char(5){}
			Dim sHexNumbers As String = "0123456789ABCDEF"

			arrHexDigit(0) = sHexNumbers.Chars(CInt(Fix(Math.Floor(color.R / 16.0))))
			arrHexDigit(1) = sHexNumbers.Chars(color.R Mod 16)

			arrHexDigit(2) = sHexNumbers.Chars(CInt(Fix(Math.Floor(color.G / 16.0))))
			arrHexDigit(3) = sHexNumbers.Chars(color.G Mod 16)

			arrHexDigit(4) = sHexNumbers.Chars(CInt(Fix(Math.Floor(color.B / 16.0))))
			arrHexDigit(5) = sHexNumbers.Chars(color.B Mod 16)

			Dim svgColor As String = ""

			Dim i As Integer = 0
			Do While i < arrHexDigit.Length
				svgColor &= arrHexDigit(i)
				i += 1
			Loop

			Return "#" & svgColor
		End Function

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			' start document initialization
			Document = NDrawingView1.Document
			Document.BeginInit()

			Document.Width = NDrawingView1.Dimensions.Width
			Document.Height = NDrawingView1.Dimensions.Height

			Dim xmlDocument As XmlDocument = New XmlDocument()
			xmlDocument.Load(Me.MapPathSecure(Me.TemplateSourceDirectory & "\MapOfUSA.xml"))

			Dim map As XmlElement = CType(xmlDocument.ChildNodes(0), XmlElement)

			Dim stateColorTable As Color() = New Color(5){}

			stateColorTable(0) = Color.LightPink
			stateColorTable(1) = Color.Bisque
			stateColorTable(2) = Color.Moccasin
			stateColorTable(3) = Color.MistyRose
			stateColorTable(4) = Color.PowderBlue
			stateColorTable(5) = Color.Ivory

			Dim stateCounter As Integer = 0
			Dim stateHighlighColor As Color = Color.Orange

			For Each state As XmlElement In map.ChildNodes
				Dim stateId As String = state.Attributes("Id").Value.ToString()

				Dim stateShape As NCompositeShape = CreateState(state)
				' add to active layer
				Document.ActiveLayer.AddChild(stateShape)

'				NRotatedBoundsLabel label = new NRotatedBoundsLabel("Click to go to :" + stateId + " webpage", stateShape.UniqueId, new Nevron.Diagram.NMargins());
'				stateShape.Labels.AddChild(label);

				' set fill and stroke styles
				Dim stateColor As Color = stateColorTable(stateCounter Mod 6)

				stateShape.Style.FillStyle = New NColorFillStyle(stateColor)
				stateShape.Style.StrokeStyle = New NStrokeStyle(1, Color.Black)

				Dim interactivityStyle As NInteractivityStyle = New NInteractivityStyle()
				stateShape.Style.InteractivityStyle = interactivityStyle

				Dim stateScript As String = "onmouseover = 'HighlightState(evt, """ & ColorToSVG(stateHighlighColor) & """)' onmouseout = 'HighlightState(evt, """ & ColorToSVG(stateColor) & """)'"
				interactivityStyle.CustomMapAreaAttribute.JScriptAttribute = stateScript
				interactivityStyle.UrlLink.Url = "http://www.worldatlas.com/webimage/countrys/namerica/usstates/" & stateId.ToLower().ToString() & ".htm"
				interactivityStyle.UrlLink.OpenInNewWindow = True

				Dim identifier As NElementIdentifier = New NElementIdentifier(stateShape.Id)
				stateCounter += 1
			Next state

			Document.BackgroundStyle.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.LightSeaGreen, Color.LightBlue)

			' change the response type to SVG
			Dim response As NImageResponse = New NImageResponse()

			Dim svgImageFormat As NSvgImageFormat = New NSvgImageFormat()
			svgImageFormat.EnableInteractivity = True
			svgImageFormat.CustomScript = GetScript()
			response.ImageFormat = svgImageFormat

			NDrawingView1.ServerSettings.BrowserResponseSettings.DefaultResponse = response
		End Sub


		Protected Function CreateState(ByVal state As XmlElement) As NCompositeShape
			Dim pathPoints As String = state.Attributes("PathPoints").Value.ToString()
			Dim pathTypes As String = state.Attributes("PathTypes").Value.ToString()

			Dim pathPointsStr As String() = pathPoints.Split(" "c)
			Dim pathPointsF As NPointF() = New NPointF(pathPointsStr.Length - 1){}

			Dim scaleX As Single = NDrawingView1.Dimensions.Width
			Dim scaleY As Single = NDrawingView1.Dimensions.Height

			Dim i As Integer = 0
			Do While i < pathPointsStr.Length
				Dim xyStr As String() = pathPointsStr(i).Split(","c)

				pathPointsF(i).X = (Single.Parse(xyStr(0))) * scaleX
				pathPointsF(i).Y = (Single.Parse(xyStr(1))) * scaleY
				i += 1
			Loop

			Dim pathTypesStr As String() = pathTypes.Split(" "c)
			Dim pathTypesB As Byte() = New Byte(pathTypesStr.Length - 1){}

			i = 0
			Do While i < pathTypesStr.Length
				pathTypesB(i) = Byte.Parse(pathTypesStr(i))
				i += 1
			Loop

			Dim path As NCustomPath = New NCustomPath(pathPointsF, pathTypesB, PathType.ClosedFigure)
			Dim shape As NCompositeShape = New NCompositeShape()
			shape.Primitives.AddChild(path)
			shape.UpdateModelBounds()

			Return shape
		End Function


		Protected Function GetScript() As String
			Dim sScript As StringBuilder = New StringBuilder()

			sScript.Append("SVGDocument = null " & Constants.vbCrLf)
			' SetColor
			sScript.Append("function SetColor(element, color)" & Constants.vbCrLf)
			sScript.Append("{" & Constants.vbCrLf)

			sScript.AppendLine("element.setAttribute('fill', color);")
			sScript.Append("element = element.firstChild;")
			sScript.Append(Constants.vbCrLf)

			sScript.Append("while (element != null)" & Constants.vbCrLf)
			sScript.Append("{" & Constants.vbCrLf)
			sScript.Append("SetColor(element, color);")
			sScript.Append(Constants.vbCrLf)

			sScript.AppendLine("element.setAttribute('fill', color);")

			sScript.AppendLine("element = element.nextSibling;")
			sScript.AppendLine("}")
			sScript.AppendLine("}")

			sScript.Append("function HighlightState(evt, color)" & Constants.vbCrLf)
			sScript.Append("{" & Constants.vbCrLf)
			sScript.Append(Constants.vbCrLf)
			sScript.Append("SetColor(evt.target, color);")
			sScript.Append(Constants.vbCrLf)

			sScript.Append("}" & Constants.vbCrLf)

			Return sScript.ToString()
		End Function
	End Class
End Namespace
