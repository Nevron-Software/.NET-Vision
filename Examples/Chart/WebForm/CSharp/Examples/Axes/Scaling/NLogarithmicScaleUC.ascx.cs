

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Nevron.Examples.Framework.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NLogarithmicScaleUC : NExampleUC
	{

		private NChart m_Chart;
		private NLineSeries m_Line;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				LogarithmBaseTextBox.Text = "10";

				LabelFormatDropDownList.Items.Add("Default");
				LabelFormatDropDownList.Items.Add("Scientific");
				LabelFormatDropDownList.SelectedIndex = 0;
				RoundToTickMin.Checked = true;
				RoundToTickMax.Checked = true;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Logarithmic Scale");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Fit;

			m_Chart.Location = new NPointL(
				new NLength(5, NRelativeUnit.ParentPercentage), 
				new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(
				new NLength(90, NRelativeUnit.ParentPercentage), 
				new NLength(80, NRelativeUnit.ParentPercentage));
			m_Chart.BoundsMode = BoundsMode.Stretch;

			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NLogarithmicScaleConfigurator logarithmicScale = new NLogarithmicScaleConfigurator();
			logarithmicScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			logarithmicScale.MinorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			logarithmicScale.MinorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			logarithmicScale.MinorTickCount = 3;
			logarithmicScale.MajorTickMode = MajorTickMode.CustomStep;

            // add a strip line style
            NScaleStripStyle stripStyle = new NScaleStripStyle();
            stripStyle.FillStyle = new NColorFillStyle(Color.Beige);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            logarithmicScale.StripStyles.Add(stripStyle);
			
			logarithmicScale.CustomStep = 1;
			
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = logarithmicScale;

			m_Line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line.Legend.Mode = SeriesLegendMode.None;
			m_Line.InflateMargins = false;
			m_Line.MarkerStyle.Visible = true;
			m_Line.MarkerStyle.PointShape = PointShape.Cylinder;
			m_Line.MarkerStyle.Width = new NLength(0.7f, NRelativeUnit.ParentPercentage);
			m_Line.MarkerStyle.Height = new NLength(0.7f, NRelativeUnit.ParentPercentage);
			m_Line.MarkerStyle.AutoDepth = true;
			m_Line.DataLabelStyle.Format = "<value>";
			m_Line.DataLabelStyle.ArrowStrokeStyle.Color = Color.CornflowerBlue;

			NStandardFrameStyle  frameStyle = m_Line.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle;
			frameStyle.InnerBorderColor = Color.CornflowerBlue;

			m_Line.Values.Add(12);
			m_Line.Values.Add(100);
			m_Line.Values.Add(250);
			m_Line.Values.Add(500);
			m_Line.Values.Add(1500);
			m_Line.Values.Add(5500);
			m_Line.Values.Add(9090);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			UpdateScale();
		}

		private void UpdateScale()
		{
			NAxis axis = m_Chart.Axis(StandardAxis.PrimaryY);
			NLogarithmicScaleConfigurator logarithmicScale = axis.ScaleConfigurator as NLogarithmicScaleConfigurator;

			// check if null (user may have changed the scale with the editor)
			if (logarithmicScale == null)
				return;

			double logBase = Convert.ToDouble(LogarithmBaseTextBox.Text);
			if (logBase < 2)
			{
				logBase = 2;
			}
			else if (logBase > 30)
			{
				logBase = 30;
			}

			logarithmicScale.LogarithmBase = logBase;

			switch (LabelFormatDropDownList.SelectedIndex)
			{
			case 0:
				logarithmicScale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.General);
				break;

			case 1:
				logarithmicScale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.Scientific);
				break;
			}

			logarithmicScale.RoundToTickMax = RoundToTickMax.Checked;
			logarithmicScale.RoundToTickMin = RoundToTickMin.Checked;
		}
	}
}
