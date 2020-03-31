using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using Nevron.UI;
using System.Drawing;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public partial class NTreeMapLegendUC : NExampleBaseUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private NTreeMapChart m_TreeMap;
		private Label label1;
		private Label label2;
		private UI.WinForm.Controls.NComboBox PaletteLegendModeComboBox;
		private UI.WinForm.Controls.NComboBox LegendModeComboBox;

		public NTreeMapLegendUC()
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
			this.label1 = new System.Windows.Forms.Label();
			this.LegendModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.PaletteLegendModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Legend Mode:";
			// 
			// LegendModeComboBox
			// 
			this.LegendModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.LegendModeComboBox.ListProperties.DataSource = null;
			this.LegendModeComboBox.ListProperties.DisplayMember = "";
			this.LegendModeComboBox.Location = new System.Drawing.Point(13, 28);
			this.LegendModeComboBox.Name = "LegendModeComboBox";
			this.LegendModeComboBox.Size = new System.Drawing.Size(151, 21);
			this.LegendModeComboBox.TabIndex = 1;
			this.LegendModeComboBox.SelectedIndexChanged += new System.EventHandler(this.LegendModeComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Palette Mode:";
			// 
			// PaletteLegendModeComboBox
			// 
			this.PaletteLegendModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.PaletteLegendModeComboBox.ListProperties.DataSource = null;
			this.PaletteLegendModeComboBox.ListProperties.DisplayMember = "";
			this.PaletteLegendModeComboBox.Location = new System.Drawing.Point(13, 81);
			this.PaletteLegendModeComboBox.Name = "PaletteLegendModeComboBox";
			this.PaletteLegendModeComboBox.Size = new System.Drawing.Size(151, 21);
			this.PaletteLegendModeComboBox.TabIndex = 3;
			this.PaletteLegendModeComboBox.SelectedIndexChanged += new System.EventHandler(this.PaletteLegendModeComboBox_SelectedIndexChanged);
			// 
			// NTreeMapLegendUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.PaletteLegendModeComboBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LegendModeComboBox);
			this.Name = "NTreeMapLegendUC";
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

			nChartControl1.Document.RootPanel.Margins = new NMarginsL(10);

			// set a chart title
			NLabel title = new NLabel("Tree Map - Legend Options");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.DockMode = PanelDockMode.Top;
			nChartControl1.Panels.Add(title);

			NLegend legend = new NLegend();
			legend.DockMode = PanelDockMode.Right;
			nChartControl1.Panels.Add(legend);

			m_TreeMap = new NTreeMapChart();
			nChartControl1.Panels.Add(m_TreeMap);
			m_TreeMap.DockMode = PanelDockMode.Fill;

			m_TreeMap.RootTreeMapNode.Legend.DisplayOnLegend = legend;

			XmlDocument document = LoadData();

			m_TreeMap.RootTreeMapNode.Label = "Tree Map by Industry Sector";
			m_TreeMap.RootTreeMapNode.Format = "";
			m_TreeMap.RootTreeMapNode.LegendFormat = "<label>";

			foreach (XmlElement industry in document.DocumentElement)
			{
				NGroupTreeMapNode groupNode = new NGroupTreeMapNode();

				groupNode.Padding = new NMarginsL(2.0f);

				m_TreeMap.RootTreeMapNode.ChildNodes.Add(groupNode);

				groupNode.Label = industry.Attributes["Name"].Value;

				groupNode.LabelTextStyle = new NTextStyle();
				groupNode.LabelTextStyle.FillStyle = new NColorFillStyle(Color.White);
				groupNode.FillStyle = new NColorFillStyle(Color.Black);

				groupNode.StrokeStyle = new NStrokeStyle(1, Color.Black);

				groupNode.InteractivityStyle = new NInteractivityStyle(groupNode.Label);

				foreach (XmlElement sector in industry.ChildNodes)
				{
					double value = double.Parse(sector.Attributes["Size"].Value);
					double change = double.Parse(sector.Attributes["Change"].Value);
					string label = sector.Attributes["Name"].Value;

					NValueTreeMapNode valueNode = new NValueTreeMapNode(value, change, label);

					valueNode.InteractivityStyle = new NInteractivityStyle(label);
					valueNode.StrokeStyle = new NStrokeStyle(1, Color.Black);
					valueNode.LabelTextStyle = new NTextStyle();
					valueNode.LabelTextStyle.FillStyle = new NColorFillStyle(Color.Black);

					groupNode.ChildNodes.Add(valueNode);
				}
			}

			LegendModeComboBox.FillFromEnum(typeof(TreeMapNodeLegendMode));
			LegendModeComboBox.SelectedIndex = (int)TreeMapNodeLegendMode.GroupAndChildNodes;

			PaletteLegendModeComboBox.FillFromEnum(typeof(PaletteLegendMode));
			PaletteLegendModeComboBox.Enabled = false;
			PaletteLegendModeComboBox.SelectedIndex = (int)PaletteLegendMode.GradientAxis;
		}
		/// <summary>
		/// Loads the data for the tree map
		/// </summary>
		/// <returns></returns>
		private XmlDocument LoadData()
		{
			Stream stream = NResourceHelper.GetResourceStream(GetType().Assembly, "TreeMapDataSmall.xml", "Nevron.Examples.Chart.WinForm.Resources");

			if (stream == null)
				return null;

			XmlDocument document = new XmlDocument();
			document.Load(stream);

			return document;
		}

		private void LegendModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			PaletteLegendModeComboBox.Enabled = ((TreeMapNodeLegendMode)LegendModeComboBox.SelectedIndex == TreeMapNodeLegendMode.Palette);
			m_TreeMap.RootTreeMapNode.Legend.Mode = (TreeMapNodeLegendMode)LegendModeComboBox.SelectedIndex;

			foreach (NGroupTreeMapNode node in m_TreeMap.RootTreeMapNode.ChildNodes)
			{
				node.Legend.Mode = (TreeMapNodeLegendMode)LegendModeComboBox.SelectedIndex;
			}

			nChartControl1.Refresh();
		}

		private void PaletteLegendModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_TreeMap.RootTreeMapNode.Legend.PaletteLegendMode = (PaletteLegendMode)PaletteLegendModeComboBox.SelectedIndex;

			foreach (NGroupTreeMapNode node in m_TreeMap.RootTreeMapNode.ChildNodes)
			{
				node.Legend.PaletteLegendMode = (PaletteLegendMode)PaletteLegendModeComboBox.SelectedIndex;
			}

			nChartControl1.Refresh();
		}
	}
}
