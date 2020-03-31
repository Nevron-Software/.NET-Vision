using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Nevron.Chart;
using System.Xml;
using System.Reflection;
using System.IO;
using Nevron.UI;
using Nevron.GraphicsCore;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public partial class NTreeMapUC : NExampleBaseUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private UI.WinForm.Controls.NComboBox VerticalFillModeComboBox;
		private UI.WinForm.Controls.NComboBox HorizontalFillModeComboBox;
		private Label label1;
		private Label label2;
		private Label label3;
		private UI.WinForm.Controls.NComboBox ColorFillModeComboBox;
		private NTreeMapChart m_TreeMap;

		public NTreeMapUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.VerticalFillModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.HorizontalFillModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.ColorFillModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// VerticalFillModeComboBox
			// 
			this.VerticalFillModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.VerticalFillModeComboBox.ListProperties.DataSource = null;
			this.VerticalFillModeComboBox.ListProperties.DisplayMember = "";
			this.VerticalFillModeComboBox.Location = new System.Drawing.Point(12, 34);
			this.VerticalFillModeComboBox.Name = "VerticalFillModeComboBox";
			this.VerticalFillModeComboBox.Size = new System.Drawing.Size(151, 21);
			this.VerticalFillModeComboBox.TabIndex = 6;
			this.VerticalFillModeComboBox.SelectedIndexChanged += new System.EventHandler(this.VerticalFillModeCombo_SelectedIndexChanged);
			// 
			// HorizontalFillModeComboBox
			// 
			this.HorizontalFillModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.HorizontalFillModeComboBox.ListProperties.DataSource = null;
			this.HorizontalFillModeComboBox.ListProperties.DisplayMember = "";
			this.HorizontalFillModeComboBox.Location = new System.Drawing.Point(12, 85);
			this.HorizontalFillModeComboBox.Name = "HorizontalFillModeComboBox";
			this.HorizontalFillModeComboBox.Size = new System.Drawing.Size(151, 21);
			this.HorizontalFillModeComboBox.TabIndex = 7;
			this.HorizontalFillModeComboBox.SelectedIndexChanged += new System.EventHandler(this.HorizontalFillModeComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Vertical Fill Mode:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 65);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(102, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Horizontal Fill Mode:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 118);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Color Fill Mode:";
			// 
			// ColorFillModeComboBox
			// 
			this.ColorFillModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.ColorFillModeComboBox.ListProperties.DataSource = null;
			this.ColorFillModeComboBox.ListProperties.DisplayMember = "";
			this.ColorFillModeComboBox.Location = new System.Drawing.Point(12, 138);
			this.ColorFillModeComboBox.Name = "ColorFillModeComboBox";
			this.ColorFillModeComboBox.Size = new System.Drawing.Size(151, 21);
			this.ColorFillModeComboBox.TabIndex = 10;
			this.ColorFillModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ColorFillModeComboBox_SelectedIndexChanged);
			// 
			// NTreeMapUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.ColorFillModeComboBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.HorizontalFillModeComboBox);
			this.Controls.Add(this.VerticalFillModeComboBox);
			this.Name = "NTreeMapUC";
			this.Size = new System.Drawing.Size(178, 350);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();
			nChartControl1.Controller.Tools.Add(new NTooltipTool());

			// set a chart title
			NLabel title = new NLabel("Tree Map");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
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

			VerticalFillModeComboBox.FillFromEnum(typeof(TreeMapVerticalFillMode));
			VerticalFillModeComboBox.SelectedIndex = (int)TreeMapVerticalFillMode.Default;

			HorizontalFillModeComboBox.FillFromEnum(typeof(TreeMapHorizontalFillMode));
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
			Stream stream = NResourceHelper.GetResourceStream(GetType().Assembly, "TreeMapData.xml", "Nevron.Examples.Chart.WinForm.Resources");

			if (stream == null)
				return null;

			XmlDocument document = new XmlDocument();
			document.Load(stream);

			return document;
		}
	
		private void VerticalFillModeCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_TreeMap.RootTreeMapNode.VerticalFillMode = (TreeMapVerticalFillMode)VerticalFillModeComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void HorizontalFillModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_TreeMap.RootTreeMapNode.HorizontalFillMode = (TreeMapHorizontalFillMode)HorizontalFillModeComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void ColorFillModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
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
