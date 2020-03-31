using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NBasicChartSVGUC : NExampleUC
	{

		protected NLineSeries m_Line1;
		protected NLineSeries m_Line2;
		protected NBarSeries m_Bar;

		private void GenerateData()
		{
			m_Line1.Values.Clear();
			m_Line2.Values.Clear();
			m_Bar.Values.Clear();

			for(int i = 0; i < 9; i++)
			{
				m_Line1.Values.Add( Math.Sin(0.6 * i) + 0.5 * Random.NextDouble());
				m_Line2.Values.Add( Math.Cos(0.6 * i) + 0.5 * Random.NextDouble());
				m_Bar.Values.Add( Math.Cos(0.6 * i) + 0.5 * Random.NextDouble());
			}
		}
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
			}

			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			NChart chart = nChartControl1.Charts[0];
			chart.Width = 100;
			chart.Height = 60;
			chart.BoundsMode = BoundsMode.Fit;
			chart.Location = new NPointL(
				new NLength(10, NRelativeUnit.ParentPercentage),
				new NLength(20, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(80, NRelativeUnit.ParentPercentage),
				new NLength(70, NRelativeUnit.ParentPercentage));


			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Wall(ChartWallType.Back).Visible = false;

			m_Line1 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			m_Line1.Name = "Line 1";
			m_Line1.DataLabelStyle.Visible = false;
			m_Line1.BorderStyle.Color = Color.DodgerBlue;
			m_Line1.FillStyle = new NColorFillStyle(Color.DodgerBlue);
			m_Line1.MarkerStyle.FillStyle = new NColorFillStyle(Color.DodgerBlue);
			m_Line1.MarkerStyle.BorderStyle.Color = Color.DodgerBlue;
			m_Line1.MarkerStyle.PointShape = PointShape.Cylinder;
			m_Line1.MarkerStyle.Visible = true;
			m_Line1.ShadowStyle.Type = ShadowType.GaussianBlur;

			m_Line2 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			m_Line2.Name = "Line 2";
			m_Line2.MultiLineMode = MultiLineMode.Overlapped;
			m_Line2.DataLabelStyle.Visible = false;
			m_Line2.BorderStyle.Color = Color.Orange;
			m_Line2.FillStyle = new NColorFillStyle(Color.Orange);
			m_Line2.MarkerStyle.FillStyle = new NColorFillStyle(Color.Orange);
			m_Line2.MarkerStyle.BorderStyle.Color = Color.Orange;
			m_Line2.MarkerStyle.PointShape = PointShape.Cylinder;
			m_Line2.MarkerStyle.Visible = true;
			m_Line2.ShadowStyle.Type = ShadowType.GaussianBlur;

			m_Bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			m_Bar.DataLabelStyle.Visible = false;
			for (int i = 0; i < m_Bar.Values.Count; i++)
			{
				m_Bar.FillStyles[i] = new NColorFillStyle(WebExamplesUtilities.RandomColor());
			}
			m_Bar.Name = "Bar 1";

			GenerateData();

			// add header
			NLabel header = nChartControl1.Labels.AddHeader("Basic SVG Chart");
			header.TextStyle.BackplaneStyle.Visible = false;
			header.TextStyle.ShadowStyle.Type = ShadowType.GaussianBlur;
			header.TextStyle.FillStyle = new NColorFillStyle(Color.Black);
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(3, NRelativeUnit.ParentPercentage),
											new NLength(3, NRelativeUnit.ParentPercentage));


			NImageResponse svgImageResponse = new NImageResponse();
			NSvgImageFormat svgImageFormat = new NSvgImageFormat();

			svgImageResponse.ImageFormat = svgImageFormat;
			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = svgImageResponse;
		}
	}
}
