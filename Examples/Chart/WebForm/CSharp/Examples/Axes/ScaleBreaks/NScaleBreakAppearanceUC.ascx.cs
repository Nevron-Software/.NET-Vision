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
	public partial class NScaleBreakAppearanceUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Scale Break Appearance<br/> <font size = '9pt'>Demonstrates how to change the scale break appearance</font>");
			header.TextStyle.TextFormat = TextFormat.XML;
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left;
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// turn off the legend
			NLegend legend = nChartControl1.Legends[0];
			legend.Mode = LegendMode.Disabled;

			NChart chart = nChartControl1.Charts[0];
			chart.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(19, NRelativeUnit.ParentPercentage));
            chart.Size = new NSizeL(new NLength(96, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
            chart.BoundsMode = BoundsMode.Stretch;

			// configure scale
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.RoundToTickMax = true;
			linearScale.RoundToTickMin = true;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MinTickDistance = new NLength(15);

			// add an interlaced strip to the Y axis
			NScaleStripStyle interlacedStrip = new NScaleStripStyle();
			interlacedStrip.SetShowAtWall(ChartWallType.Back, true);
			interlacedStrip.Interlaced = true;
			interlacedStrip.FillStyle = new NColorFillStyle(Color.Beige);
			linearScale.StripStyles.Add(interlacedStrip);

			// Create some data with a peak in it
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.DataLabelStyle.Visible = false;

			// fill in some data so that it contains several peaks of data
			Random random = new Random();
			for (int i = 0; i < 8; i++)
			{
				bar.Values.Add(random.Next(30));
			}
			for (int i = 0; i < 5; i++)
			{
				bar.Values.Add(300 + random.Next(50));
			}
			for (int i = 0; i < 8; i++)
			{
				bar.Values.Add(random.Next(30));
			}

			// update form controls
			if (!IsPostBack)
			{
				patternDropDownList.Items.Add(ScaleBreakPattern.CenterPowerBrake.ToString());
				patternDropDownList.Items.Add(ScaleBreakPattern.FreeHand.ToString());
				patternDropDownList.Items.Add(ScaleBreakPattern.LeftPowerBrake.ToString());
				patternDropDownList.Items.Add(ScaleBreakPattern.LongShort.ToString());
				patternDropDownList.Items.Add(ScaleBreakPattern.Regular.ToString());
				patternDropDownList.Items.Add(ScaleBreakPattern.RightPowerBrake.ToString());
				patternDropDownList.SelectedIndex = 4;

				styleDropDownList.Items.Add("Line");
				styleDropDownList.Items.Add("Wave");
				styleDropDownList.Items.Add("ZigZag");
				styleDropDownList.SelectedIndex = 1; // use wave by default
                lengthTextBox.Text = "5";
			}

			UpdateScaleBreaks();
		}


		protected void UpdateScaleBreaks()
		{
			// read the form control values
			float horzStep;
			if (!float.TryParse(horzStepTextBox.Text, out horzStep) || horzStep < 0 || horzStep > 50)
			{
				horzStep = 20f;
				horzStepTextBox.Text = horzStep.ToString();
			}

			float vertStep;
			if (!float.TryParse(vertStepTextBox.Text, out vertStep) || vertStep < 0 || vertStep > 50)
			{
				vertStep = 3f;
				vertStepTextBox.Text = vertStep.ToString();
			}

			float length;
			if (!float.TryParse(lengthTextBox.Text, out length) || length < 0 || length > 50)
			{
				length = 0;
				lengthTextBox.Text = length.ToString();
			}

			// update scale breaks
			NChart chart = nChartControl1.Charts[0];
			NLinearScaleConfigurator scale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			NScaleBreakStyle oldScaleBreakStyle = null;
			if (scale.ScaleBreaks.Count > 0)
			{
				oldScaleBreakStyle = ((NScaleBreak)scale.ScaleBreaks[0]).Style;
			}
			scale.ScaleBreaks.Clear();

			NScaleBreakStyle newScaleBreakStyle = null;

			switch (styleDropDownList.SelectedIndex)
			{
				case 0: // Line
					newScaleBreakStyle = new NLineScaleBreakStyle();
					break;
				case 1: // Waves
					newScaleBreakStyle = new NWaveScaleBreakStyle();
					break;
				case 2: // ZigZag
					newScaleBreakStyle = new NZigZagScaleBreakStyle();
					break;
			}

			// try to preserve fill and stroke settings
			if (newScaleBreakStyle != null)
			{
				if (oldScaleBreakStyle != null)
				{
					newScaleBreakStyle.InitFrom(oldScaleBreakStyle);
				}

				// update the length of the scale break
				newScaleBreakStyle.Length = new NLength(length, NGraphicsUnit.Point);

				// update paramers relevant to pattern scale break appearance
				NPatternScaleBreakStyle patternScaleBreakStyle = newScaleBreakStyle as NPatternScaleBreakStyle;
				bool enablePatternControls = patternScaleBreakStyle != null;
				if (patternScaleBreakStyle != null)
				{
					patternScaleBreakStyle.HorzStep = new NLength(horzStep);
					patternScaleBreakStyle.VertStep = new NLength(vertStep);
					patternScaleBreakStyle.Pattern = (ScaleBreakPattern)Enum.Parse(typeof(ScaleBreakPattern), patternDropDownList.SelectedItem.Text);
				}

				scale.ScaleBreaks.Add(new NAutoScaleBreak(newScaleBreakStyle, 0.4f));
			}
		}
	}
}
