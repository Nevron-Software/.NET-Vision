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
	public partial class NTreeMapDrillDownUC : NExampleBaseUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private Nevron.UI.WinForm.Controls.NButton GoBackToTopLevelButton;
		private NTreeMapChart m_TreeMap;
		private NGroupTreeMapNode m_OrgRootNode;

		public NTreeMapDrillDownUC()
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
			this.GoBackToTopLevelButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// GoBackToTopLevelButton
			// 
			this.GoBackToTopLevelButton.Location = new System.Drawing.Point(12, 17);
			this.GoBackToTopLevelButton.Name = "GoBackToTopLevelButton";
			this.GoBackToTopLevelButton.Size = new System.Drawing.Size(152, 23);
			this.GoBackToTopLevelButton.TabIndex = 0;
			this.GoBackToTopLevelButton.Text = "Go Back To Top Level";
			this.GoBackToTopLevelButton.UseVisualStyleBackColor = true;
			this.GoBackToTopLevelButton.Click += new System.EventHandler(this.GoBackToTopLevelButton_Click);
			// 
			// NTreeMapDrillDownUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.GoBackToTopLevelButton);
			this.Name = "NTreeMapDrillDownUC";
			this.Size = new System.Drawing.Size(178, 350);
			this.ResumeLayout(false);

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();
			nChartControl1.Controller.Tools.Add(new NTooltipTool());

			// set a chart title
			NLabel title = new NLabel("Tree Map - Drill Down");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.DockMode = PanelDockMode.Top;
			nChartControl1.Panels.Add(title);
			
			m_TreeMap = new NTreeMapChart();
			nChartControl1.Panels.Add(m_TreeMap);
			m_TreeMap.DockMode = PanelDockMode.Fill;

			m_OrgRootNode = m_TreeMap.RootTreeMapNode;

			XmlDocument document = LoadData();

			foreach (XmlElement industry in document.DocumentElement)
			{
				NGroupTreeMapNode groupNode = new NGroupTreeMapNode();
				groupNode.StrokeStyle = new NStrokeStyle(1.0f, Color.Green);
				groupNode.Padding = new NMarginsL(2.0f);

				m_TreeMap.RootTreeMapNode.ChildNodes.Add(groupNode);

				groupNode.Label = industry.Attributes["Name"].Value;
				groupNode.InteractivityStyle = new NInteractivityStyle(groupNode.Label);

				foreach (XmlElement company in industry.ChildNodes)
				{
					double value = double.Parse(company.Attributes["Size"].Value);
					double change = double.Parse(company.Attributes["Change"].Value);
					string label = company.Attributes["Name"].Value;

					NValueTreeMapNode valueNode = new NValueTreeMapNode(value, change, label);
					valueNode.InteractivityStyle = new NInteractivityStyle(label);
					groupNode.ChildNodes.Add(valueNode);
				}
			}

			nChartControl1.MouseClick += new MouseEventHandler(nChartControl1_MouseClick);
		}

		void nChartControl1_MouseClick(object sender, MouseEventArgs e)
		{
			NHitTestResult result = nChartControl1.HitTest(e.X, e.Y);

			if (result.ChartElement == ChartElement.TreeMapNode)
			{
				NGroupTreeMapNode groupNode = result.GroupTreeMapNode;

				if (groupNode != null && groupNode.ParentNode != null)
				{
					m_TreeMap.RootTreeMapNode = (NGroupTreeMapNode)groupNode.Clone();

					// assign palette to this node
					NPalette palette = new NPalette();

					palette.Mode = PaletteMode.AutoMinMaxColor;
					palette.SmoothPalette = true;
					m_TreeMap.RootTreeMapNode.Palette = palette;

					nChartControl1.Refresh();
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GoBackToTopLevelButton_Click(object sender, EventArgs e)
		{
			m_TreeMap.RootTreeMapNode = m_OrgRootNode;
			nChartControl1.Refresh();
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
	}
}
