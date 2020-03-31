using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Nevron.GraphicsCore;
using Nevron.Dom;
using Nevron.Diagram;
using Nevron.UI.WebForm.Controls;
using Nevron.Examples.Framework.WebForm;

namespace Nevron.Examples.Diagram.Webform.GettingStarted
{
	/// <summary>
	///		Summary description for NImageMapResponseUC.
	/// </summary>
	public partial class NImageMapResponseUC : System.Web.UI.UserControl
	{
		protected NDrawingDocument Document;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			NHtmlImageMapResponse imageMapResponse = new NHtmlImageMapResponse();
			NDrawingView1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageMapResponse;

            NDrawingView1.ViewLayout = CanvasLayout.Fit;
			this.Document = NDrawingView1.Document;

			// start document initialization
			Document.BeginInit();

			Document.Width = 800;
			Document.Height = 700;
			Document.Style.TextStyle.TextFormat = TextFormat.XML;
			Document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None;
			Document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None;

			// configure shadow (inherited by all objects)
			Document.Style.ShadowStyle = new NShadowStyle(
				ShadowType.GaussianBlur,
				Color.FromArgb(150, Color.Black),
				new Nevron.GraphicsCore.NPointL(3, 3),
				1,
				new NLength(4)
				);

			Document.ShadowsZOrder = ShadowsZOrder.BehindDocument;
			
			// init scene
			CreateScene();

			// end document initialization
			Document.EndInit();

			Document.Style.InteractivityStyle.Tooltip.Text = "Diagram Background";
		}

		#region Implementation

		protected void CreateScene()
		{
			// configure title
			NTextShape title = new NTextShape("The Business Company", 0, 0, Document.Width, 60);
			Document.ActiveLayer.AddChild(title);
			
			NTextStyle textStyle = title.ComposeTextStyle().Clone() as NTextStyle;
			textStyle.FontStyle.InitFromFont(new Font("Arial Black", 22, FontStyle.Bold | FontStyle.Italic));

			// set gradient fill style
			textStyle.FillStyle = new NGradientFillStyle(
				GradientStyle.Horizontal, 
				GradientVariant.Variant1, 
				Color.FromArgb(241, 100, 34), 
				Color.FromArgb(255, 247, 151));

			// add shadow
			textStyle.ShadowStyle = new NShadowStyle(
				ShadowType.GaussianBlur, 
				Color.FromArgb(50, 122, 122, 122), 
				new Nevron.GraphicsCore.NPointL(5, 5), 
				1, 
				new NLength(3));
			
			title.Style.TextStyle = textStyle;

			NPersonalInfo[] personalInfos = NPersonalInfo.CreateCompanyInfo();


			// create an Org chart shape for each person in the Org chart
			NCompositeShape presidentShape = CreateOrgChartShape(personalInfos[0]);
			
			NCompositeShape vpMarketingShape =	CreateOrgChartShape(personalInfos[1]);
			NCompositeShape vpSalesShape = CreateOrgChartShape(personalInfos[2]);
			NCompositeShape vpProductionShape = CreateOrgChartShape(personalInfos[3]);

			NCompositeShape mm01Shape = CreateOrgChartShape(personalInfos[4]);
			NCompositeShape mm02Shape = CreateOrgChartShape(personalInfos[5]);
			
			NCompositeShape sm01Shape = CreateOrgChartShape(personalInfos[6]);
			NCompositeShape sm02Shape = CreateOrgChartShape(personalInfos[7]);
			
			NCompositeShape pm01Shape = CreateOrgChartShape(personalInfos[8]);
			NCompositeShape pm02Shape = CreateOrgChartShape(personalInfos[9]);
			
			//	connect the Org chart shapes
			// 1. President to VPs
			NShape ge = null;
			ge = new NStep3Connector(true, 50, 0, true);
			Document.ActiveLayer.AddChild(ge);
			ge.StartPlug.Connect(presidentShape.Ports.GetChildByName("Bottom", 0) as NPort);
			ge.EndPlug.Connect(vpMarketingShape.Ports.GetChildByName("Top", 0) as NPort);

			ge = new NStep3Connector(true, 50, 0, true);
			Document.ActiveLayer.AddChild(ge);
			ge.StartPlug.Connect(presidentShape.Ports.GetChildByName("Bottom", 0) as NPort);
			ge.EndPlug.Connect(vpSalesShape.Ports.GetChildByName("Top", 0) as NPort);

			ge = new NStep3Connector(true, 50, 0, true);
			Document.ActiveLayer.AddChild(ge);
			ge.StartPlug.Connect(presidentShape.Ports.GetChildByName("Bottom", 0) as NPort);
			ge.EndPlug.Connect(vpProductionShape.Ports.GetChildByName("Top", 0) as NPort);
			
			// 1. VPs to managers
			ge = new NStep2Connector(true);
			Document.ActiveLayer.AddChild(ge);
			ge.StartPlug.Connect(vpMarketingShape.Ports.GetChildByName("Bottom", 0) as NPort);
			ge.EndPlug.Connect(mm01Shape.Ports.GetChildByName("Left", 0) as NPort);
			
			ge = new NStep2Connector(true);
			Document.ActiveLayer.AddChild(ge);
			ge.StartPlug.Connect(vpMarketingShape.Ports.GetChildByName("Bottom", 0) as NPort);
			ge.EndPlug.Connect(mm02Shape.Ports.GetChildByName("Left", 0) as NPort);
			
			ge = new NStep2Connector(true);
			Document.ActiveLayer.AddChild(ge);
			ge.StartPlug.Connect(vpSalesShape.Ports.GetChildByName("Bottom", 0) as NPort);
			ge.EndPlug.Connect(sm01Shape.Ports.GetChildByName("Left", 0) as NPort);
			
			ge = new NStep2Connector(true);
			Document.ActiveLayer.AddChild(ge);
			ge.StartPlug.Connect(vpSalesShape.Ports.GetChildByName("Bottom", 0) as NPort);
			ge.EndPlug.Connect(sm02Shape.Ports.GetChildByName("Left", 0) as NPort);
			
			ge = new NStep2Connector(true);
			Document.ActiveLayer.AddChild(ge);
			ge.StartPlug.Connect(vpProductionShape.Ports.GetChildByName("Bottom", 0) as NPort);
			ge.EndPlug.Connect(pm01Shape.Ports.GetChildByName("Left", 0) as NPort);
			
			ge = new NStep2Connector(true);
			Document.ActiveLayer.AddChild(ge);
			ge.StartPlug.Connect(vpProductionShape.Ports.GetChildByName("Bottom", 0) as NPort);
			ge.EndPlug.Connect(pm02Shape.Ports.GetChildByName("Left", 0) as NPort);
		}

		protected NCompositeShape CreateOrgChartShape(NPersonalInfo info)
		{
			NRectangleF bounds = info.Bounds;
			float bottomPortAlignment = info.BottomPortAlignment;
			Bitmap photo = new Bitmap(this.MapPathSecure(info.Picture));

			// compose a new graph vertex from a frame and an image
			NRectanglePath frame = new NRectanglePath(bounds);
			NRectanglePath image = new NRectanglePath(new NPointF(bounds.X + 5, bounds.Y + 5), new NSizeF(photo.Size));
            NImageFillStyle imgageFillStyle = new NImageFillStyle(photo, 0xff);
			NStyle.SetFillStyle(image, imgageFillStyle);

			NCompositeShape shape = new NCompositeShape(); 
			shape.Primitives.AddChild(frame);
			shape.Primitives.AddChild(image);
			shape.UpdateModelBounds();
			Document.ActiveLayer.AddChild(shape);

			// set the vertex fill style
			NColorFillStyle fillStyle = null;
			switch (info.Level)
			{
				case 0:
					fillStyle = new NColorFillStyle(Color.FromArgb(241, 100, 34));
					break;
				case 1:
					fillStyle = new NColorFillStyle(Color.FromArgb(249, 167, 26));
					break;
				case 2:
					fillStyle = new NColorFillStyle(Color.FromArgb(255, 247, 151));
					break;
			}

			fillStyle.ImageFiltersStyle.Filters.Add(new NLightingImageFilter());
			shape.Style.FillStyle = fillStyle;

			NInteractivityStyle interactivityStyle = new NInteractivityStyle();
			interactivityStyle.Tooltip.Text = "Click to show " + info.Name + " personal information";
			interactivityStyle.UrlLink.Url = "../Examples/WebControl/GettingStarted/NPersonalInfoPage.aspx?" + info.Id.ToString();
			shape.Style.InteractivityStyle = interactivityStyle;

			// add a new label for the person name
			NRotatedBoundsLabel nameLabel = new NRotatedBoundsLabel(info.Name, shape.UniqueId, new Nevron.Diagram.NMargins(40, 1, 50, 1));
			shape.Labels.AddChild(nameLabel);
			NStyle.SetTextStyle(nameLabel, nameLabel.ComposeTextStyle().Clone() as NTextStyle);
			nameLabel.Style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Right;
			nameLabel.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Top;
		
			// configure default label (used for the person position)
			NRotatedBoundsLabel positionLabel = shape.Labels.DefaultLabel as NRotatedBoundsLabel;
			NStyle.SetTextStyle(positionLabel, positionLabel.ComposeTextStyle().Clone() as NTextStyle);
			positionLabel.Style.TextStyle.FontStyle.InitFromFont(new Font("Arial", 10, FontStyle.Bold));
			positionLabel.Style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Right;
			positionLabel.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Bottom;
			positionLabel.Margins = new Nevron.Diagram.NMargins(40, 5, 1, 50);
			positionLabel.Text = info.Position;

			// create the optional ports of the shape
			shape.CreateShapeElements(ShapeElementsMask.Ports);

			// add rotated bounds ports
			NPort leftPort = new NRotatedBoundsPort(shape.UniqueId, new NContentAlignment(ContentAlignment.MiddleLeft));
			leftPort.Name = "Left";
			shape.Ports.AddChild(leftPort);

			NPort rightPort = new NRotatedBoundsPort(shape.UniqueId, new NContentAlignment(ContentAlignment.MiddleRight));
			rightPort.Name = "Right";
			shape.Ports.AddChild(rightPort);

			NPort topPort = new NRotatedBoundsPort(shape.UniqueId, new NContentAlignment(ContentAlignment.TopCenter));
			topPort.Name = "Top";
			shape.Ports.AddChild(topPort);

			NRotatedBoundsPort bottomPort = new NRotatedBoundsPort(shape.UniqueId, new NContentAlignment(bottomPortAlignment, 50));
			bottomPort.Name = "Bottom";
			shape.Ports.AddChild(bottomPort);
			
			return shape;
		}

		#endregion
	}
}
