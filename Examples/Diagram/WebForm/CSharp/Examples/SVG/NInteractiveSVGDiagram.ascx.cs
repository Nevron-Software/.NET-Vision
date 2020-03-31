using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Xml;

using Nevron.GraphicsCore;
using Nevron.Dom;
using Nevron.Diagram;
using Nevron.UI.WebForm.Controls;
using Nevron.Examples.Framework.WebForm;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///		Summary description for NInteractiveSVGDiagram.
	/// </summary>
	public partial class NInteractiveSVGDiagram : System.Web.UI.UserControl
	{
		protected NDrawingDocument Document;

		private string ColorToSVG(Color color)
		{
			char [] arrHexDigit = new char[6];
			string sHexNumbers = "0123456789ABCDEF";

			arrHexDigit[0] = sHexNumbers[(int)Math.Floor(color.R / 16.0)];
			arrHexDigit[1] = sHexNumbers[color.R % 16];

			arrHexDigit[2] = sHexNumbers[(int)Math.Floor(color.G / 16.0)];
			arrHexDigit[3] = sHexNumbers[color.G % 16];

			arrHexDigit[4] = sHexNumbers[(int)Math.Floor(color.B / 16.0)];
			arrHexDigit[5] = sHexNumbers[color.B % 16];
			
			string svgColor = "";

			for (int i = 0; i < arrHexDigit.Length; i++)
			{
				svgColor += arrHexDigit[i];
			}

			return "#" + svgColor;
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// start document initialization
			Document = NDrawingView1.Document;
			Document.BeginInit();

			Document.Width = NDrawingView1.Dimensions.Width;
			Document.Height = NDrawingView1.Dimensions.Height;

            XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.MapPathSecure(this.TemplateSourceDirectory + "\\MapOfUSA.xml"));

			XmlElement map = (XmlElement)xmlDocument.ChildNodes[0];

			Color[] stateColorTable = new Color[6];

			stateColorTable[0] = Color.LightPink;
			stateColorTable[1] = Color.Bisque;
			stateColorTable[2] = Color.Moccasin;
			stateColorTable[3] = Color.MistyRose;
			stateColorTable[4] = Color.PowderBlue;
			stateColorTable[5] = Color.Ivory;

			int stateCounter = 0;
			Color stateHighlighColor = Color.Orange;

			foreach (XmlElement state in map.ChildNodes)
			{
				string stateId = state.Attributes["Id"].Value.ToString();

				NCompositeShape stateShape = CreateState(state);
				// add to active layer
				Document.ActiveLayer.AddChild(stateShape); 

//				NRotatedBoundsLabel label = new NRotatedBoundsLabel("Click to go to :" + stateId + " webpage", stateShape.UniqueId, new Nevron.Diagram.NMargins());
//				stateShape.Labels.AddChild(label);
				
				// set fill and stroke styles
				Color stateColor = stateColorTable[stateCounter % 6];

				stateShape.Style.FillStyle = new NColorFillStyle(stateColor);
				stateShape.Style.StrokeStyle = new NStrokeStyle(1, Color.Black);
				
				NInteractivityStyle interactivityStyle = new NInteractivityStyle();
				stateShape.Style.InteractivityStyle = interactivityStyle;

				string elementId = new NElementIdentifier(((INElement)stateShape.Primitives.GetChildAt(0)).Id).ToString();
				string stateScript = "onmouseover = 'HighlightState(\"" + elementId + "\", \"" + ColorToSVG(stateHighlighColor) + "\")' onmouseout = 'HighlightState(\"" + elementId + "\", \"" + ColorToSVG(stateColor) + "\")'";
				interactivityStyle.CustomMapAreaAttribute.JScriptAttribute = stateScript;
				interactivityStyle.UrlLink.Url = "http://worldatlas.com/webimage/countrys/namerica/usstates/" + stateId.ToString() + ".htm";
                interactivityStyle.UrlLink.OpenInNewWindow = true;

				NElementIdentifier identifier = new NElementIdentifier(stateShape.Id);
				stateCounter++;
			}

			Document.BackgroundStyle.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.LightSeaGreen, Color.LightBlue);

			// change the response type to SVG
			NImageResponse response = new NImageResponse();

			NSvgImageFormat svgImageFormat = new NSvgImageFormat();
			svgImageFormat.EnableInteractivity = true;
			svgImageFormat.CustomScript = GetScript();

			Hashtable attributes = new Hashtable();
			attributes["onload"] = "Initialize(evt)";
			svgImageFormat.Attributes = attributes;
			response.ImageFormat = svgImageFormat;

			NDrawingView1.ServerSettings.BrowserResponseSettings.DefaultResponse = response;
		}

		protected string GetScript()
		{
			StringBuilder sScript = new StringBuilder();

			sScript.Append("SVGDocument = null \r\n");

			sScript.Append("function Initialize(LoadEvent)\r\n");
			sScript.Append("{\r\n");
			sScript.Append("SVGDocument = LoadEvent.getTarget().getOwnerDocument()\r\n");
			sScript.Append("}\r\n");
			sScript.Append("\r\n");

			// SetColor
			sScript.Append("function SetColor(element, color)\r\n");
			sScript.Append("{\r\n");

				sScript.Append("element = element.firstChild;");
				sScript.Append("\r\n");

				sScript.Append("while (element != null)\r\n");
				sScript.Append("{\r\n");
					sScript.Append("SetColor(element, color);");
					sScript.Append("\r\n");

					sScript.Append("if (new String(element.style) != \"undefined\")\r\n");
					sScript.Append("{\r\n");
						sScript.Append("var st = element.getStyle();");
						sScript.Append("\r\n");
						sScript.Append("st.setProperty('fill', color);");
						sScript.Append("\r\n");
					sScript.Append("}\r\n");

					sScript.Append("element = element.nextSibling;");
					sScript.Append("\r\n");
				sScript.Append("}\r\n");
			sScript.Append("}\r\n");

			sScript.Append("function HighlightState(stateID, color)\r\n");
			sScript.Append("{\r\n");

				sScript.Append("element = SVGDocument.getElementById(stateID);");
				sScript.Append("\r\n");
				sScript.Append("SetColor(element, color);");
				sScript.Append("\r\n");

			sScript.Append("}\r\n");

			return sScript.ToString();
		}

		protected NCompositeShape CreateState(XmlElement state)
		{
			string pathPoints = state.Attributes["PathPoints"].Value.ToString();
			string pathTypes = state.Attributes["PathTypes"].Value.ToString();

			string[] pathPointsStr = pathPoints.Split(' ');
			NPointF[] pathPointsF = new NPointF[pathPointsStr.Length];

			float scaleX = NDrawingView1.Dimensions.Width;
			float scaleY = NDrawingView1.Dimensions.Height;

			for (int i = 0; i < pathPointsStr.Length; i++)
			{
				string[] xyStr = pathPointsStr[i].Split(',');

				pathPointsF[i].X = (Single.Parse(xyStr[0])) * scaleX;
				pathPointsF[i].Y = (Single.Parse(xyStr[1])) * scaleY;
			}

			string[] pathTypesStr = pathTypes.Split(' ');
			byte[] pathTypesB = new byte[pathTypesStr.Length];

			for (int i = 0; i < pathTypesStr.Length; i++)
			{
				pathTypesB[i] = Byte.Parse(pathTypesStr[i]);
			}

			NCustomPath path = new NCustomPath(pathPointsF, pathTypesB, PathType.ClosedFigure);
			NCompositeShape shape = new NCompositeShape();
			shape.Primitives.AddChild(path);
			shape.UpdateModelBounds();

			return shape;
		}
	}
}
