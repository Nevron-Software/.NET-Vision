using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Nevron.Chart;
using Nevron.Chart.WebForm;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm 
{
	public partial class NAxisDockingUC : NExampleUC
	{
		private NChart m_Chart;
		private NAxis m_RedAxis;
		private NAxis m_GreenAxis;
		private NAxis m_BlueAxis;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				RedAxisZoneDropDownList.Items.Add("Front Left");
				RedAxisZoneDropDownList.Items.Add("Front Right");

				GreenAxisZoneDropDownList.Items.Add("Front Left");
				GreenAxisZoneDropDownList.Items.Add("Front Right");

				BlueAxisZoneDropDownList.Items.Add("Front Left");
				BlueAxisZoneDropDownList.Items.Add("Front Right");
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Axis Docking<br/> <font size = '9pt'>Demonstrates how to use of the dock axis anchor and how to add custom axes</font>");
			header.TextStyle.TextFormat = TextFormat.XML;
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left;
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// remove all legends
			nChartControl1.Legends.Clear();

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;
			m_Chart.Location = new NPointL(
				new NLength(5, NRelativeUnit.ParentPercentage),
				new NLength(17, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(
				new NLength(90, NRelativeUnit.ParentPercentage),
				new NLength(80, NRelativeUnit.ParentPercentage));

			m_RedAxis = m_Chart.Axis(StandardAxis.PrimaryY);
			m_GreenAxis = m_Chart.Axis(StandardAxis.SecondaryY);
			m_GreenAxis.Visible = true;

			// Add a custom vertical axis
			m_BlueAxis = ((NCartesianAxisCollection)m_Chart.Axes).AddCustomAxis(AxisOrientation.Vertical, AxisDockZone.FrontLeft);
            
			// create three line series and dispay them on three vertical axes (red, green and blue axis)
			NLineSeries line1 = CreateLineSeries(Color.Red, Color.DarkRed, 10, 20);
			NLineSeries line2 = CreateLineSeries(Color.Green, Color.DarkGreen, 50, 100);
			NLineSeries line3 = CreateLineSeries(Color.Blue, Color.DarkBlue, 100, 200);

			line1.DisplayOnAxis(StandardAxis.PrimaryY, true);

			line2.DisplayOnAxis(StandardAxis.PrimaryY, false);
			line2.DisplayOnAxis(StandardAxis.SecondaryY, true);

			line3.DisplayOnAxis(StandardAxis.PrimaryY, false);
			line3.DisplayOnAxis(m_BlueAxis.AxisId, true);

			// now configure the axis appearance
			NLinearScaleConfigurator linearScale;

			// setup the red axis
			linearScale = new NLinearScaleConfigurator();
			m_RedAxis.ScaleConfigurator = linearScale;

			linearScale.RulerStyle.FillStyle = new NColorFillStyle(Color.DarkRed);
			linearScale.RulerStyle.BorderStyle.Color = Color.Red;
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Red;
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Red;
			linearScale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.DarkRed);

			// setup the green axis
			linearScale = new NLinearScaleConfigurator();
			m_GreenAxis.ScaleConfigurator = linearScale;

			linearScale.RulerStyle.FillStyle = new NColorFillStyle(Color.DarkGreen);
			linearScale.RulerStyle.BorderStyle.Color = Color.Green;
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Green;
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Green;
			linearScale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.DarkGreen);

			// setup the blue axis
			linearScale = new NLinearScaleConfigurator();
			m_BlueAxis.ScaleConfigurator = linearScale;

			linearScale.RulerStyle.FillStyle = new NColorFillStyle(Color.DarkBlue);
			linearScale.RulerStyle.BorderStyle.Color = Color.Blue;
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Blue;
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Blue;
			linearScale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.DarkBlue);

			UpdateAxisAnchors();
		}

		private NLineSeries CreateLineSeries(Color lightColor, Color darkColor, int begin, int end)
		{
			// Add a line series
			NLineSeries line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			line.Values.FillRandomRange(Random, 5, begin, end);
			line.Name = "Line "+ lightColor.Name;
			line.BorderStyle.Color = darkColor;
			line.DataLabelStyle.Format = "<value>";
			line.DataLabelStyle.TextStyle.BackplaneStyle.Visible = false;
			line.DataLabelStyle.ArrowStrokeStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			line.DataLabelStyle.ArrowLength = new NLength(2.5f, NRelativeUnit.ParentPercentage);
			line.DataLabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);
			line.InflateMargins = true;
            line.MarkerStyle.Visible = true;
			line.MarkerStyle.BorderStyle.Color = darkColor;
			line.MarkerStyle.FillStyle = new NColorFillStyle(lightColor);
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.MarkerStyle.Width = new NLength(2, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Height = new NLength(2, NRelativeUnit.ParentPercentage);

			return line;
		}

		private void UpdateAxisAnchors()
		{
			if (RedAxisZoneDropDownList.SelectedIndex == 0)
			{
				m_RedAxis.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, true);
			}
			else
			{
				m_RedAxis.Anchor = new NDockAxisAnchor(AxisDockZone.FrontRight, true);
			}

			if (GreenAxisZoneDropDownList.SelectedIndex == 0)
			{
				m_GreenAxis.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, true);
			}
			else
			{
				m_GreenAxis.Anchor = new NDockAxisAnchor(AxisDockZone.FrontRight, true);
			}

			if (BlueAxisZoneDropDownList.SelectedIndex == 0)
			{
				m_BlueAxis.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, true);
			}
			else
			{
				m_BlueAxis.Anchor = new NDockAxisAnchor(AxisDockZone.FrontRight, true);
			}
		}

		protected void RedAxisZoneDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateAxisAnchors();
		}

		protected void GreenAxisZoneDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateAxisAnchors();
		}

		protected void BlueAxisZoneDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateAxisAnchors();
		}
	}
}
