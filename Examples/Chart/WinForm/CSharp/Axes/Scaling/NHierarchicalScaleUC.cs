using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.GraphicsCore;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NHierarchicalScaleUC : NExampleBaseUC
	{
		NBarSeries m_Bar1;
		NBarSeries m_Bar2;
		private Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox FirstRowIndividualModeComboBox;
		private Nevron.UI.WinForm.Controls.NCheckBox CreateSeparatorForEachLevelCheckBox;
		private Label label2;
		private Nevron.UI.WinForm.Controls.NComboBox FirstRowSeparatorModeComboBox;
		private Label label3;
		private Nevron.UI.WinForm.Controls.NComboBox GroupRowSeparatorModeComboBox;
		private Label label4;
		private Nevron.UI.WinForm.Controls.NComboBox GroupRowIndividualModeComboBox;
		private Nevron.UI.WinForm.Controls.NButton ChangeDataButton;

		public NHierarchicalScaleUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
			this.ChangeDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.FirstRowIndividualModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.CreateSeparatorForEachLevelCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.FirstRowSeparatorModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.GroupRowSeparatorModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.GroupRowIndividualModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// ChangeDataButton
			// 
			this.ChangeDataButton.Location = new System.Drawing.Point(10, 293);
			this.ChangeDataButton.Name = "ChangeDataButton";
			this.ChangeDataButton.Size = new System.Drawing.Size(153, 23);
			this.ChangeDataButton.TabIndex = 9;
			this.ChangeDataButton.Text = "Change Data";
			this.ChangeDataButton.UseVisualStyleBackColor = true;
			this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 57);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(108, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "First Row Tick Mode:";
			// 
			// FirstRowIndividualModeComboBox
			// 
			this.FirstRowIndividualModeComboBox.Location = new System.Drawing.Point(10, 76);
			this.FirstRowIndividualModeComboBox.Name = "FirstRowIndividualModeComboBox";
			this.FirstRowIndividualModeComboBox.Size = new System.Drawing.Size(153, 21);
			this.FirstRowIndividualModeComboBox.TabIndex = 3;
			this.FirstRowIndividualModeComboBox.SelectedIndexChanged += new System.EventHandler(this.LabelTickModeComboBox_SelectedIndexChanged);
			// 
			// CreateSeparatorForEachLevelCheckBox
			// 
			this.CreateSeparatorForEachLevelCheckBox.AutoSize = true;
			this.CreateSeparatorForEachLevelCheckBox.ButtonProperties.BorderOffset = 2;
			this.CreateSeparatorForEachLevelCheckBox.Location = new System.Drawing.Point(10, 270);
			this.CreateSeparatorForEachLevelCheckBox.Name = "CreateSeparatorForEachLevelCheckBox";
			this.CreateSeparatorForEachLevelCheckBox.Size = new System.Drawing.Size(153, 17);
			this.CreateSeparatorForEachLevelCheckBox.TabIndex = 8;
			this.CreateSeparatorForEachLevelCheckBox.Text = "Create Separator per Level";
			this.CreateSeparatorForEachLevelCheckBox.UseVisualStyleBackColor = true;
			this.CreateSeparatorForEachLevelCheckBox.CheckedChanged += new System.EventHandler(this.CreateSeparatorForEachLevelCheckBox_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(133, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "First Row Separator Mode:";
			// 
			// FirstRowSeparatorModeComboBox
			// 
			this.FirstRowSeparatorModeComboBox.Location = new System.Drawing.Point(10, 29);
			this.FirstRowSeparatorModeComboBox.Name = "FirstRowSeparatorModeComboBox";
			this.FirstRowSeparatorModeComboBox.Size = new System.Drawing.Size(153, 21);
			this.FirstRowSeparatorModeComboBox.TabIndex = 1;
			this.FirstRowSeparatorModeComboBox.SelectedIndexChanged += new System.EventHandler(this.FirstRowSeparatorModeComboBox_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 138);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(143, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Group Row Separator Mode:";
			// 
			// GroupRowSeparatorModeComboBox
			// 
			this.GroupRowSeparatorModeComboBox.Location = new System.Drawing.Point(10, 157);
			this.GroupRowSeparatorModeComboBox.Name = "GroupRowSeparatorModeComboBox";
			this.GroupRowSeparatorModeComboBox.Size = new System.Drawing.Size(153, 21);
			this.GroupRowSeparatorModeComboBox.TabIndex = 5;
			this.GroupRowSeparatorModeComboBox.SelectedIndexChanged += new System.EventHandler(this.SeparatorModeComboBox_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 183);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(118, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Group Row Tick Mode:";
			// 
			// GroupRowIndividualModeComboBox
			// 
			this.GroupRowIndividualModeComboBox.Location = new System.Drawing.Point(10, 202);
			this.GroupRowIndividualModeComboBox.Name = "GroupRowIndividualModeComboBox";
			this.GroupRowIndividualModeComboBox.Size = new System.Drawing.Size(153, 21);
			this.GroupRowIndividualModeComboBox.TabIndex = 7;
			this.GroupRowIndividualModeComboBox.SelectedIndexChanged += new System.EventHandler(this.GroupRowIndividualComboBox_SelectedIndexChanged);
			// 
			// NHierarchicalScaleUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label4);
			this.Controls.Add(this.GroupRowIndividualModeComboBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.GroupRowSeparatorModeComboBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.FirstRowSeparatorModeComboBox);
			this.Controls.Add(this.CreateSeparatorForEachLevelCheckBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.FirstRowIndividualModeComboBox);
			this.Controls.Add(this.ChangeDataButton);
			this.Name = "NHierarchicalScaleUC";
			this.Size = new System.Drawing.Size(174, 559);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Quarterly Company Sales<br/><font size = '9pt'>Demonstrates how to use hierarchical scale configurators as well as data zooming and scrolling</font>");
			header.DockMode = PanelDockMode.Top;
			header.Margins = new NMarginsL(0, 10, 0, 10);
			header.TextStyle.TextFormat = TextFormat.XML;
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
			nChartControl1.Panels.Add(header);

			NLegend legend = new NLegend();
			legend.Margins = new NMarginsL(10, 0, 10, 0);
			legend.DockMode = PanelDockMode.Right;
			legend.FitAlignment = ContentAlignment.TopCenter;
			nChartControl1.Panels.Add(legend);

			NCartesianChart chart = new NCartesianChart();
			nChartControl1.Panels.Add(chart);

			NRangeSelection rangeSelection = new NRangeSelection();
			rangeSelection.VerticalValueSnapper = new NAxisRulerMinMaxSnapper();
			chart.RangeSelections.Add(rangeSelection);

			chart.DisplayOnLegend = legend;
			chart.DockMode = PanelDockMode.Fill;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Margins = new NMarginsL(10, 0, 0, 10);
			chart.Axis(StandardAxis.Depth).Visible = false;

			// add the first bar
			m_Bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			m_Bar1.Name = "Coca Cola";
			m_Bar1.MultiBarMode = MultiBarMode.Series;
			m_Bar1.DataLabelStyle.Visible = false;

			// add the second bar
			m_Bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			m_Bar2.Name = "Pepsi";
			m_Bar2.MultiBarMode = MultiBarMode.Clustered;
			m_Bar2.DataLabelStyle.Visible = false;

			NAxis xAxis = chart.Axis(StandardAxis.PrimaryX);
			xAxis.ScrollBar.Visible = true;

			// add custom labels to the Y axis
			NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// configure interactivity
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
			nChartControl1.Controller.Tools.Add(new NDataZoomTool());

			// first row combo boxes
			FirstRowIndividualModeComboBox.FillFromEnum(typeof(RangeLabelTickMode));
			FirstRowIndividualModeComboBox.SelectedIndex = (int)RangeLabelTickMode.Separators;

			FirstRowSeparatorModeComboBox.FillFromEnum(typeof(FirstRowGridStyle));
			FirstRowSeparatorModeComboBox.SelectedIndex = (int)FirstRowGridStyle.Individual;

			GroupRowIndividualModeComboBox.FillFromEnum(typeof(RangeLabelTickMode));
			GroupRowIndividualModeComboBox.SelectedIndex = (int)RangeLabelTickMode.Separators;

			GroupRowSeparatorModeComboBox.FillFromEnum(typeof(GroupRowGridStyle));
			GroupRowSeparatorModeComboBox.SelectedIndex = (int)GroupRowGridStyle.Individual;

			CreateSeparatorForEachLevelCheckBox.Checked = true;

			ChangeDataButton_Click(null, null);
			UpdateScale();
		}

		private void UpdateScale()
		{
			// add custom labels to the X axis
			NHierarchicalScaleConfigurator scale = new NHierarchicalScaleConfigurator();
			NHierarchicalScaleNodeCollection nodes = scale.Nodes; ;

			scale.FirstRowGridStyle = (FirstRowGridStyle)FirstRowSeparatorModeComboBox.SelectedIndex;
			scale.GroupRowGridStyle = (GroupRowGridStyle)GroupRowSeparatorModeComboBox.SelectedIndex;
			scale.InnerMajorTickStyle.Visible = false;
			scale.OuterMajorTickStyle.Visible = false;

			string[] months = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

			for (int i = 0; i < 2; i++)
			{
				NHierarchicalScaleNode yearNode = new NHierarchicalScaleNode(0, (i + 2022).ToString());
				yearNode.LabelStyle.TickMode = (RangeLabelTickMode)GroupRowIndividualModeComboBox.SelectedIndex; 				
				nodes.AddChild(yearNode);

				for (int j = 0; j < 4; j++)
				{
					NHierarchicalScaleNode quarterNode = new NHierarchicalScaleNode(3, "Q" + (j + 1).ToString());
					quarterNode.LabelStyle.TickMode = (RangeLabelTickMode)GroupRowIndividualModeComboBox.SelectedIndex;
					yearNode.ChildNodes.AddChild(quarterNode);

					for (int k = 0; k < 3; k++)
					{
						NHierarchicalScaleNode monthNode = new NHierarchicalScaleNode(1, months[j * 3 + k]);
						monthNode.LabelStyle.Angle = new NScaleLabelAngle(90);
						monthNode.LabelStyle.TickMode = (RangeLabelTickMode)FirstRowIndividualModeComboBox.SelectedIndex;
						quarterNode.ChildNodes.AddChild(monthNode);
					}
				}
			}

			// update control state
			FirstRowIndividualModeComboBox.Enabled = ((FirstRowGridStyle)FirstRowSeparatorModeComboBox.SelectedIndex) == FirstRowGridStyle.Individual;
			GroupRowIndividualModeComboBox.Enabled = ((GroupRowGridStyle)GroupRowSeparatorModeComboBox.SelectedIndex) == GroupRowGridStyle.Individual;

			NScaleStripStyle stripStyle = new NScaleStripStyle();
			stripStyle.Length = 3;
			stripStyle.Interval = 3;
			stripStyle.FillStyle = new NColorFillStyle(Color.FromArgb(125, Color.LightGray));
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			scale.StripStyles.Add(stripStyle);

			scale.CreateSeparatorForEachLevel = CreateSeparatorForEachLevelCheckBox.Checked;

			nChartControl1.Charts[0].Axis(StandardAxis.PrimaryX).ScaleConfigurator = scale;
			nChartControl1.Refresh();
		}

		private void ChangeDataButton_Click(object sender, EventArgs e)
		{
			// fill with random data
			m_Bar1.Values.FillRandomRange(Random, 24, 10, 200);
			m_Bar2.Values.FillRandomRange(Random, 24, 10, 300);

			nChartControl1.Refresh();
		}

		private void CreateSeparatorForEachLevelCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void LabelTickModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void FirstRowSeparatorModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void SeparatorModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void GroupRowIndividualComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}
	}
}
