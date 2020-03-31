using System;
using System.Drawing;
using System.Web.UI;
using System.Xml;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Chart.WebForm
{
    public partial class NThreeMapUC : NExampleUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
				WebExamplesUtilities.FillComboWithEnumNames(VerticalFillModeDropDownList, typeof(TreeMapVerticalFillMode));
				VerticalFillModeDropDownList.SelectedIndex = (int)TreeMapVerticalFillMode.Default;

				WebExamplesUtilities.FillComboWithEnumNames(HorizontalFillModeDropDownList, typeof(TreeMapHorizontalFillMode));
				HorizontalFillModeDropDownList.SelectedIndex = (int)TreeMapVerticalFillMode.Default;

				ColorModeDropDownList.Items.Add("Custom");
				ColorModeDropDownList.Items.Add("Common Palette");
				ColorModeDropDownList.Items.Add("Group Palette");
				ColorModeDropDownList.SelectedIndex = 1;
            }

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			

			// set a chart title
			NLabel title = new NLabel("Tree Map");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.DockMode = PanelDockMode.Top;
			nChartControl1.Panels.Add(title);

			NTreeMapChart treeMap = new NTreeMapChart();
			nChartControl1.Panels.Add(treeMap);
			treeMap.DockMode = PanelDockMode.Fill;

			XmlDocument document = LoadData();

			foreach (XmlElement industry in document.DocumentElement)
			{
				NGroupTreeMapNode treeMapSeries = new NGroupTreeMapNode();

				treeMapSeries.StrokeStyle = new NStrokeStyle(4, Color.Black);
				treeMapSeries.Padding = new NMarginsL(2.0f);

				treeMap.RootTreeMapNode.ChildNodes.Add(treeMapSeries);

				treeMapSeries.Label = industry.Attributes["Name"].Value;
				treeMapSeries.InteractivityStyle = new NInteractivityStyle(treeMapSeries.Label);

				foreach (XmlElement company in industry.ChildNodes)
				{
					double value = double.Parse(company.Attributes["Size"].Value);
					double change = double.Parse(company.Attributes["Change"].Value);
					string label = company.Attributes["Name"].Value;

					NValueTreeMapNode node = new NValueTreeMapNode(value, change, label);
					node.InteractivityStyle = new NInteractivityStyle(label);
					//						node.FillStyle = new NColorFillStyle(Color.Green);
					treeMapSeries.ChildNodes.Add(node);
				}
			}

			nChartControl1.Controller.Tools.Add(new NTooltipTool());

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, treeMap, title, null);

			// update from from controls
			treeMap.RootTreeMapNode.HorizontalFillMode = (TreeMapHorizontalFillMode)HorizontalFillModeDropDownList.SelectedIndex;
			treeMap.RootTreeMapNode.VerticalFillMode = (TreeMapVerticalFillMode)VerticalFillModeDropDownList.SelectedIndex;

			switch (ColorModeDropDownList.SelectedIndex)
			{
				case 0:
					{
						// custom color filling -> assign colors to each group (child nodes will inherit that fill)
						NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Bright);

						int industryIndex = 0;
						foreach (NGroupTreeMapNode industryTreeMapNode in treeMap.RootTreeMapNode.ChildNodes)
						{
							foreach (NTreeMapNode companyTreeMapNode in industryTreeMapNode.ChildNodes)
							{
								companyTreeMapNode.FillStyle = new NColorFillStyle(palette.SeriesColors[(industryIndex) % palette.SeriesColors.Count]);
							}

							industryIndex++;
						}
					}
					break;
				case 1:
					{
						// palette filling -> remove all fill styles assigned to nodes
						foreach (NGroupTreeMapNode industryTreeMapNode in treeMap.RootTreeMapNode.ChildNodes)
						{
							industryTreeMapNode.Palette = null;

							foreach (NTreeMapNode companyTreeMapNode in industryTreeMapNode.ChildNodes)
							{
								companyTreeMapNode.FillStyle = null;
							}
						}
					}
					break;
				case 2:
					{
						// palette filling -> remove all fill styles assigned to nodes
						foreach (NGroupTreeMapNode industryTreeMapNode in treeMap.RootTreeMapNode.ChildNodes)
						{
							NPalette palette = new NPalette();
							palette.Mode = PaletteMode.AutoMinMaxColor;
							industryTreeMapNode.Palette = palette;

							foreach (NTreeMapNode companyTreeMapNode in industryTreeMapNode.ChildNodes)
							{
								companyTreeMapNode.FillStyle = null;
							}
						}
					}
					break;
			}
        }

		/// <summary>
		/// Loads the data for the tree map
		/// </summary>
		/// <returns></returns>
		private XmlDocument LoadData()
		{
			XmlDocument document = new XmlDocument();

			document.Load(this.MapPathSecure(this.TemplateSourceDirectory + "\\TreeMapDataSmall.xml"));

			return document;
		}

        private void GenerateData(NThreeLineBreakSeries threeLineBreak)
        {
            NStockDataGenerator dataGenerator = new NStockDataGenerator(new NRange1DD(50, 350), 0.002, 2);
            dataGenerator.Reset();

            DateTime dt = new DateTime(2007, 1, 1);

            for (int i = 0; i < 100; i++)
            {
                threeLineBreak.Values.Add(dataGenerator.GetNextValue());
                threeLineBreak.XValues.Add(dt);

                dt = dt.AddDays(1);
            }
        }
    }
}