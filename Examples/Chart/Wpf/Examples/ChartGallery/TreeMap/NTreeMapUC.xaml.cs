using System.Drawing;
using System.IO;
using System.Xml;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using Nevron.UI;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NTreeMapUC : NExampleBaseUC
	{
		NTreeMapChart m_TreeMap;

		public NTreeMapUC()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets the title of this example
		/// </summary>
		public override string Title
		{
			get
			{
				return "Three Map";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "Treemaps display hierarchical (tree-structured) data as a set of nested rectangles. Each branch of the tree is represented by NTreeMapGroupNode object which is given a rectangle proportional to the aggregate value of its sub nodes. A leaf node's rectangle has an area proportional to its value compared to the total area of all leaf nodes. \r\nLeaf nodes can be colored using a palette or have their own custom colors.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Panels.Clear();
			nChartControl1.Controller.Tools.Add(new NTooltipTool());

			// set a chart title
			NLabel title = new NLabel("Tree Map");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.DockMode = PanelDockMode.Top;
			nChartControl1.Panels.Add(title);

			m_TreeMap = new NTreeMapChart();
			nChartControl1.Panels.Add(m_TreeMap);
			m_TreeMap.DockMode = PanelDockMode.Fill;

			XmlDocument document = LoadData();

			foreach (XmlElement industry in document.DocumentElement)
			{
				NGroupTreeMapNode treeMapSeries = new NGroupTreeMapNode();

				treeMapSeries.StrokeStyle = new NStrokeStyle(4, Color.Black);
				treeMapSeries.Padding = new NMarginsL(2.0f);

				m_TreeMap.RootTreeMapNode.ChildNodes.Add(treeMapSeries);

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

			NExampleHelpers.FillComboWithEnumValues(VerticalFillModeComboBox, typeof(TreeMapVerticalFillMode));
			VerticalFillModeComboBox.SelectedIndex = (int)TreeMapVerticalFillMode.Default;

			NExampleHelpers.FillComboWithEnumValues(HorizontalFillModeComboBox, typeof(TreeMapHorizontalFillMode));
			HorizontalFillModeComboBox.SelectedIndex = (int)TreeMapVerticalFillMode.Default;

			ColorFillModeComboBox.Items.Add("Custom");
			ColorFillModeComboBox.Items.Add("Common Palette");
			ColorFillModeComboBox.Items.Add("Group Palette");
			ColorFillModeComboBox.SelectedIndex = 1;
		}
		/// <summary>
		/// Loads the data for the tree map
		/// </summary>
		/// <returns></returns>
		private XmlDocument LoadData()
		{
			Stream stream = NResourceHelper.GetResourceStream(GetType().Assembly, "TreeMapData.xml", "Nevron.Examples.Chart.Wpf.Resources");

			if (stream == null)
				return null;

			XmlDocument document = new XmlDocument();
			document.Load(stream);

			return document;
		}

		private void VerticalFillModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			m_TreeMap.RootTreeMapNode.VerticalFillMode = (TreeMapVerticalFillMode)VerticalFillModeComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void HorizontalFillModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			m_TreeMap.RootTreeMapNode.HorizontalFillMode = (TreeMapHorizontalFillMode)HorizontalFillModeComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void ColorFillModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			switch (ColorFillModeComboBox.SelectedIndex)
			{
				case 0:
					{
						// custom color filling -> assign colors to each group (child nodes will inherit that fill)
						NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Bright);

						int industryIndex = 0;
						foreach (NGroupTreeMapNode industryTreeMapNode in m_TreeMap.RootTreeMapNode.ChildNodes)
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
						foreach (NGroupTreeMapNode industryTreeMapNode in m_TreeMap.RootTreeMapNode.ChildNodes)
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
						foreach (NGroupTreeMapNode industryTreeMapNode in m_TreeMap.RootTreeMapNode.ChildNodes)
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

			nChartControl1.Refresh();
		}
	}
}
