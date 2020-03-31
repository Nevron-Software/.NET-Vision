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
	public partial class NAxisTicksUC : NExampleUC
	{
		private NChart m_Chart;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				ShowOuterMajorTicksCheckBox.Checked = true;
				ShowInnerMajorTicksCheckBox.Checked = true;
				ShowOuterMinorTicksCheckBox.Checked = true;
				ShowInnerMinorTicksCheckBox.Checked = true;
				WebExamplesUtilities.FillComboWithValues(OuterMajorTickLengthDropDownList, 0, 10, 1);
				OuterMajorTickLengthDropDownList.SelectedIndex = 4;
				WebExamplesUtilities.FillComboWithValues(InnerMajorTickLengthDropDownList, 0, 10, 1);
				InnerMajorTickLengthDropDownList.SelectedIndex = 4;
				WebExamplesUtilities.FillComboWithValues(OuterMinorTickLengthDropDownList, 0, 10, 1);
				OuterMinorTickLengthDropDownList.SelectedIndex = 2;
				WebExamplesUtilities.FillComboWithValues(InnerMinorTickLengthDropDownList, 0, 10, 1);
				InnerMinorTickLengthDropDownList.SelectedIndex = 2;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Axis Ticks");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

            // setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;
			m_Chart.BoundsMode = BoundsMode.Stretch;
			m_Chart.Location = new NPointL(
				new NLength(5, NRelativeUnit.ParentPercentage),
				new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(
				new NLength(90, NRelativeUnit.ParentPercentage),
				new NLength(80, NRelativeUnit.ParentPercentage));

            // add interlaced stripe
            NStandardScaleConfigurator scaleConfiguratorY = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle();
            stripStyle.FillStyle = new NColorFillStyle(Color.Beige);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            scaleConfiguratorY.StripStyles.Add(stripStyle);

			NBarSeries bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			bar.Values.FillRandom(Random, 6);
			bar.DataLabelStyle.Format = "<value>";
			bar.Legend.Mode = SeriesLegendMode.None;
			bar.Name = "Bars";

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			SetTicks();
		}

		protected void ShowOuterMajorTicksCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			SetTicks();
		}

		protected void ShowInnerMajorTicksCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			SetTicks();
		}

		protected void ShowOuterMinorTicksCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			SetTicks();
		}

		protected void ShowInnerMinorTicksCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			SetTicks();
		}

		protected void OuterMajorTickLengthDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetTicks();
		}

		protected void InnerMajorTickLengthDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetTicks();
		}

		protected void OuterMinorTickLengthDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetTicks();
		}

		protected void InnerMinorTickLengthDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetTicks();
		}

		private void SetTicks()
		{
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.MinorTickCount = 3;

			if (ShowOuterMajorTicksCheckBox.Checked)
			{
				linearScale.OuterMajorTickStyle.Length = new NLength(Convert.ToInt32(OuterMajorTickLengthDropDownList.SelectedValue), linearScale.OuterMajorTickStyle.Length.MeasurementUnit);	
			}
			else
			{
				linearScale.OuterMajorTickStyle.Length = new NLength(0, linearScale.OuterMajorTickStyle.Length.MeasurementUnit);	
			}

			if(ShowInnerMajorTicksCheckBox.Checked)
			{
				linearScale.InnerMajorTickStyle.Length = new NLength(Convert.ToInt32(InnerMajorTickLengthDropDownList.SelectedValue), linearScale.InnerMajorTickStyle.Length.MeasurementUnit);
			}
			else
			{
				linearScale.InnerMajorTickStyle.Length = new NLength(0, linearScale.InnerMajorTickStyle.Length.MeasurementUnit);
			}

			if(ShowOuterMinorTicksCheckBox.Checked)
			{
				linearScale.OuterMinorTickStyle.Length = new NLength(Convert.ToInt32(OuterMinorTickLengthDropDownList.SelectedValue), linearScale.OuterMinorTickStyle.Length.MeasurementUnit);
			}
			else
			{
				linearScale.OuterMinorTickStyle.Length = new NLength(0, linearScale.OuterMinorTickStyle.Length.MeasurementUnit);
			}

			if(ShowInnerMinorTicksCheckBox.Checked)
			{
				linearScale.InnerMinorTickStyle.Length = new NLength(Convert.ToInt32(InnerMinorTickLengthDropDownList.SelectedValue), linearScale.InnerMinorTickStyle.Length.MeasurementUnit);
			}
			else
			{
				linearScale.InnerMinorTickStyle.Length = new NLength(0, linearScale.InnerMinorTickStyle.Length.MeasurementUnit);	
			}
		}
	}
}
