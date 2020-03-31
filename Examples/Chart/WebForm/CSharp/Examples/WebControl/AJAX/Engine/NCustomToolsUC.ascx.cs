using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NCustomToolsUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			nChartControl1.AjaxToolsFactoryType = "NCustomToolFactory";

			if (nChartControl1.RequiresInitialization)
			{
				NCustomToolsData.NData data = NCustomToolsData.Read();
				
				nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
				nChartControl1.Charts.Clear();

				//	display the female population chart
				NCartesianChart fChart = new NCartesianChart();
				
				fChart.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalRight);
				fChart.Margins = new NMarginsL(9, 0, 0, 0);
				fChart.Location = new NPointL(
					new NLength(0, NRelativeUnit.ParentPercentage),
					new NLength(0, NRelativeUnit.ParentPercentage));
				fChart.Size = new NSizeL(
					new NLength(54.21f, NRelativeUnit.ParentPercentage),
					new NLength(100, NRelativeUnit.ParentPercentage));
				nChartControl1.Charts.Add(fChart);

				InitializeChartData(fChart, data.TotalFemaleData, true, Color.Pink);

				NAxis axisX = fChart.Axis(StandardAxis.PrimaryX);
				NLinearScaleConfigurator scaleX = axisX.ScaleConfigurator as NLinearScaleConfigurator;
				scaleX.CustomLabelsLevelOffset = new NLength(4);

				int nRowCount = data.TotalMaleData.Rows.Count;
				for (int i = 0; i < nRowCount; i++)
				{
					NCustomToolsData.NPopulationDataEntry en = data.TotalMaleData.Rows[i];
					double begin = en.AgeRange.Start;
					double end = en.AgeRange.End + 1;
					scaleX.CustomLabels.Add(new NCustomValueLabel((begin + end) / 2, en.AgeRange.Title));
				}

				//	display the male population chart
				NCartesianChart mChart = new NCartesianChart();

				mChart.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalLeft);
				mChart.Margins = new NMarginsL(0, 0, 9, 0);
				mChart.Location = new NPointL(
					new NLength(55.5f, NRelativeUnit.ParentPercentage),
					new NLength(0, NRelativeUnit.ParentPercentage));
				mChart.Size = new NSizeL(
					new NLength(44.8f, NRelativeUnit.ParentPercentage),
					new NLength(100, NRelativeUnit.ParentPercentage));
				nChartControl1.Charts.Add(mChart);

				InitializeChartData(mChart, data.TotalMaleData, false, Color.SkyBlue);
			}
		}

		protected void nChartControl1_QueryAjaxTools(object sender, EventArgs e)
		{
			//	configure the client side tools
			nChartControl1.AjaxTools.Add(new NAjaxDynamicCursorTool(true));
			nChartControl1.AjaxTools.Add(new NAjaxCustomTool(true));
		}

		#region Implementation

		void InitializeChartData(NCartesianChart chart, NCustomToolsData.NPopulationData data, bool invert, Color color)
		{
			chart.BoundsMode = BoundsMode.Stretch;
			
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;
			scaleX.Invert = invert;
			scaleX.AutoLabels = false;
			scaleX.CustomLabelFitModes = new LabelFitMode[] { LabelFitMode.AutoScale };
			scaleX.MajorTickMode = MajorTickMode.CustomTicks;

			NLinearScaleConfigurator scaleY = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			scaleY.LabelValueFormatter = new NNumericValueFormatter("0,,M");

			// add the shape chart
			NShapeSeries shape1 = new NShapeSeries();
			chart.Series.Add(shape1);

			shape1.FillStyle = new NColorFillStyle(color);
			shape1.DataLabelStyle.Visible = false;
			shape1.UseXValues = true;
			shape1.XSizesUnits = MeasurementUnits.Scale;
			shape1.YSizesUnits = MeasurementUnits.Scale;

			int nRowCount = data.Rows.Count;
			for (int i = 0; i < nRowCount; i++)
			{
				NCustomToolsData.NPopulationDataEntry en = data.Rows[i];

				double value = en.Value;
				double begin = en.AgeRange.Start;
				double end = en.AgeRange.End + 1;

				shape1.XValues.Add((begin + end) / 2);
				shape1.XSizes.Add(Math.Abs(begin - end));

				shape1.Values.Add(value / 2);
				shape1.YSizes.Add(value);

				shape1.ZSizes.Add(0);
				shape1.InteractivityStyles.Add(i, new NInteractivityStyle(true, string.Format("{0}:{1}", data.Id, i), null, CursorType.Hand));
			}
		}

		#endregion
	}

	/// <summary>
	/// Provides configuration for the client side NAjaxCustomTool tool.
	/// </summary>
	[Serializable]
	public class NAjaxCustomTool : NAjaxToolDefinition
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of NAjaxCustomTool with a given default enabled value.
		/// </summary>
		/// <param name="defaultEnabled">
		/// Selects the initial enabled state of the tool.
		/// </param>
		public NAjaxCustomTool(bool defaultEnabled)
			: base(@"NCustomTool", defaultEnabled)
		{
		}

		#endregion

		#region Overrides

		/// <summary>
		/// Generates JavaScript that will create a new tool configuration object at the client.
		/// </summary>
		/// <returns>Returns a JavaScript that will create a new tool configuration object at the client.</returns>
		protected override string GetConfigurationObjectJavaScript()
		{
			return "new NCustomToolConfig()";
		}

		#endregion
	}
}
