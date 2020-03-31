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
	public partial class NCustomScaleBreaks : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Custom Scale Breaks<br/> <font size = '9pt'>Demonstrates how to apply custom scale breaks to the chart axes</font>");
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
            chart.Size = new NSizeL(new NLength(92, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
            chart.BoundsMode = BoundsMode.Stretch;
			Random random = new Random();

			// create three random point series
			for (int i = 0; i < 3; i++)
			{
				NPointSeries point = new NPointSeries();
				point.UseXValues = true;
				point.DataLabelStyle.Visible = false;
				point.Size = new NLength(5);
				point.BorderStyle.Width = new NLength(0);

				// fill in some random data
				for (int j = 0; j < 30; j++)
				{
					point.Values.Add(5 + random.Next(90));
					point.XValues.Add(5 + random.Next(90));
				}

				chart.Series.Add(point);
			}

			// create scale breaks
			m_FirstHorzScaleBreak = new NCustomScaleBreak(new NLineScaleBreakStyle(new NColorFillStyle(Color.FromArgb(124, Color.Orange)), null, new NLength(10)), new NRange1DD(10, 20));
			m_SecondHorzScaleBreak = new NCustomScaleBreak(new NLineScaleBreakStyle(new NColorFillStyle(Color.FromArgb(124, Color.Green)), null, new NLength(10)), new NRange1DD(80, 90));
			m_FirstVertScaleBreak = new NCustomScaleBreak(new NLineScaleBreakStyle(new NColorFillStyle(Color.FromArgb(124, Color.Red)), null, new NLength(10)), new NRange1DD(10, 20));
			m_SecondVertScaleBreak = new NCustomScaleBreak(new NLineScaleBreakStyle(new NColorFillStyle(Color.FromArgb(124, Color.Blue)), null, new NLength(10)), new NRange1DD(80, 90));

			// configure scales
			NLinearScaleConfigurator xScale = new NLinearScaleConfigurator();
			xScale.RoundToTickMax = true;
			xScale.RoundToTickMin = true;
			xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			xScale.ScaleBreaks.Add(m_FirstHorzScaleBreak);
			xScale.ScaleBreaks.Add(m_SecondHorzScaleBreak);

            // add an interlaced strip to the X axis
            NScaleStripStyle xInterlacedStrip = new NScaleStripStyle();
            xInterlacedStrip.SetShowAtWall(ChartWallType.Back, true);
            xInterlacedStrip.Interlaced = true;
            xInterlacedStrip.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.LightGray));
            xScale.StripStyles.Add(xInterlacedStrip);

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale;
			chart.Axis(StandardAxis.PrimaryX).View = new NRangeAxisView(new NRange1DD(0, 100));

			NLinearScaleConfigurator yScale = new NLinearScaleConfigurator();
			yScale.RoundToTickMax = true;
			yScale.RoundToTickMin = true;
			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			yScale.ScaleBreaks.Add(m_FirstVertScaleBreak);
			yScale.ScaleBreaks.Add(m_SecondVertScaleBreak);

			// add an interlaced strip to the Y axis
            NScaleStripStyle yInterlacedStrip = new NScaleStripStyle();
            yInterlacedStrip.SetShowAtWall(ChartWallType.Back, true);
            yInterlacedStrip.Interlaced = true;
            yInterlacedStrip.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.LightGray));
            yScale.StripStyles.Add(yInterlacedStrip);

			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = yScale;
			chart.Axis(StandardAxis.PrimaryY).View = new NRangeAxisView(new NRange1DD(0, 100));

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// feed some random data
			UpdateScaleBreaks();
		}

		protected void UpdateScaleBreaks()
		{
			// read the form control values
			double sb1Begin;
			if (!double.TryParse(sb1BeginTextBox.Text, out sb1Begin) || sb1Begin < 0 || sb1Begin > 100)
			{
				sb1Begin = 10;
				sb1BeginTextBox.Text = sb1Begin.ToString();
			}

			double sb1End;
			if (!double.TryParse(sb1EndTextBox.Text, out sb1End) || sb1End < 0 || sb1End > 100)
			{
				sb1End = 20;
				sb1EndTextBox.Text = sb1End.ToString();
			}

			double sb2Begin;
			if (!double.TryParse(sb2BeginTextBox.Text, out sb2Begin) || sb2Begin < 0 || sb2Begin > 100)
			{
				sb2Begin = 80;
				sb2BeginTextBox.Text = sb2Begin.ToString();
			}

			double sb2End;
			if (!double.TryParse(sb2EndTextBox.Text, out sb2End) || sb2End < 0 || sb2End > 100)
			{
				sb2End = 90;
				sb2EndTextBox.Text = sb2End.ToString();
			}

			double sb3Begin;
			if (!double.TryParse(sb3BeginTextBox.Text, out sb3Begin) || sb3Begin < 0 || sb3Begin > 100)
			{
				sb3Begin = 10;
				sb3BeginTextBox.Text = sb3Begin.ToString();
			}

			double sb3End;
			if (!double.TryParse(sb3EndTextBox.Text, out sb3End) || sb3End < 0 || sb3End > 100)
			{
				sb3End = 20;
				sb3EndTextBox.Text = sb3End.ToString();
			}

			double sb4Begin;
			if (!double.TryParse(sb4BeginTextBox.Text, out sb4Begin) || sb4Begin < 0 || sb4Begin > 100)
			{
				sb4Begin = 80;
				sb4BeginTextBox.Text = sb4Begin.ToString();
			}

			double sb4End;
			if (!double.TryParse(sb4EndTextBox.Text, out sb4End) || sb4End < 0 || sb4End > 100)
			{
				sb4End = 90;
				sb4EndTextBox.Text = sb4End.ToString();
			}

			// adjust scale breaks
			m_FirstHorzScaleBreak.Range = new NRange1DD(sb1Begin, sb1End);
			m_SecondHorzScaleBreak.Range = new NRange1DD(sb2Begin, sb2End);
			m_FirstVertScaleBreak.Range = new NRange1DD(sb3Begin, sb3End);
			m_SecondVertScaleBreak.Range = new NRange1DD(sb4Begin, sb4End);
		}

		private NCustomScaleBreak m_FirstHorzScaleBreak;
		private NCustomScaleBreak m_SecondHorzScaleBreak;
		private NCustomScaleBreak m_FirstVertScaleBreak;
		private NCustomScaleBreak m_SecondVertScaleBreak;
	}
}
