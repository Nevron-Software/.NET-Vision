using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NAxisAppearanceUC : NExampleUC
	{

		private NChart nChart;
	
		protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithFontNames(YAxisFontDropDownList, "Arial");
				WebExamplesUtilities.FillComboWithFontNames(XAxisFontDropDownList, "Arial");
				WebExamplesUtilities.FillComboWithValues(YOffsetDropDownList, 0, 30, 5);
				WebExamplesUtilities.FillComboWithValues(XOffsetDropDownList, 0, 30, 5);
				YTitleTextBox.Text = "Y Axis Title";
				XTitleTextBox.Text = "X Axis Title";
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Axis Titles");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			nChart = nChartControl1.Charts[0];
			nChart.BoundsMode = BoundsMode.Stretch;
			nChart.Location = new NPointL(
				new NLength(4, NRelativeUnit.ParentPercentage),
				new NLength(12, NRelativeUnit.ParentPercentage));
			nChart.Size = new NSizeL(
				new NLength(90, NRelativeUnit.ParentPercentage),
				new NLength(84, NRelativeUnit.ParentPercentage));

			NStandardScaleConfigurator scaleConfiguratorY = (NStandardScaleConfigurator)nChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleConfiguratorY.Title.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.View, 90);

            // add interlaced stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle();
            stripStyle.FillStyle = new NColorFillStyle(Color.Beige);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            scaleConfiguratorY.StripStyles.Add(stripStyle);

			NStandardScaleConfigurator scaleConfiguratorX = (NStandardScaleConfigurator)nChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleConfiguratorX.Title.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.View, 0);

			NBarSeries bar = (NBarSeries)nChart.Series.Add(SeriesType.Bar);
			bar.Values.FillRandom(Random, 20);
			bar.Name = "Bars";
			bar.DataLabelStyle.Visible = false;
			bar.Legend.Mode = SeriesLegendMode.None;

			scaleConfiguratorY = (NStandardScaleConfigurator)nChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleConfiguratorY.Title.Text = YTitleTextBox.Text;

			scaleConfiguratorX = (NStandardScaleConfigurator)nChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleConfiguratorX.Title.Text = XTitleTextBox.Text;

			SetTitle();

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);
		}

		protected void YAxisFontDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetTitle();
		}

		protected void XAxisFontDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetTitle();
		}

		protected void YAlignmentDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetTitle();
		}

		protected void XAlignmentDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetTitle();
		}

		protected void YOffsetDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetTitle();
		}

		protected void XOffsetDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetTitle();
		}

		private void SetTitle()
		{
			NStandardScaleConfigurator scaleConfiguratorY = (NStandardScaleConfigurator)nChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			NStandardScaleConfigurator scaleConfiguratorX = (NStandardScaleConfigurator)nChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;

			NTextStyle textStyleResultY = new NTextStyle(new NFontStyle(YAxisFontDropDownList.SelectedValue));
			NTextStyle textStyleResultX = new NTextStyle(new NFontStyle(XAxisFontDropDownList.SelectedValue));

			scaleConfiguratorY.Title.TextStyle = textStyleResultY;
			scaleConfiguratorX.Title.TextStyle = textStyleResultX;

			switch(YAlignmentDropDownList.SelectedIndex)
			{
				case 0:
					scaleConfiguratorY.Title.ContentAlignment = ContentAlignment.MiddleRight;
					scaleConfiguratorY.Title.RulerAlignment = HorzAlign.Right;
					break;

				case 1:
					scaleConfiguratorY.Title.ContentAlignment = ContentAlignment.MiddleCenter;
					scaleConfiguratorY.Title.RulerAlignment = HorzAlign.Center;
					break;

				case 2:
					scaleConfiguratorY.Title.ContentAlignment = ContentAlignment.MiddleLeft;
					scaleConfiguratorY.Title.RulerAlignment = HorzAlign.Left;
					break;
			}

			switch(XAlignmentDropDownList.SelectedIndex)
			{
				case 0:
					scaleConfiguratorX.Title.ContentAlignment = ContentAlignment.MiddleLeft;
					scaleConfiguratorX.Title.RulerAlignment = HorzAlign.Left;
					break;

				case 1:
					scaleConfiguratorX.Title.ContentAlignment = ContentAlignment.MiddleCenter;
					scaleConfiguratorX.Title.RulerAlignment = HorzAlign.Center;
					break;

				case 2:
					scaleConfiguratorX.Title.ContentAlignment = ContentAlignment.MiddleRight;
					scaleConfiguratorX.Title.RulerAlignment = HorzAlign.Right;
					break;
			}

			scaleConfiguratorY.Title.Offset = new NLength(Convert.ToInt32(YOffsetDropDownList.SelectedValue), NGraphicsUnit.Pixel);
			scaleConfiguratorX.Title.Offset = new NLength(Convert.ToInt32(XOffsetDropDownList.SelectedValue), NGraphicsUnit.Pixel);
		}
	}
}
