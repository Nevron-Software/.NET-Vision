using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.UI.WinForm.Controls;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NLegendItemTextFitModeUC : NExampleBaseUC
    {
		private Label label8;
		private UI.WinForm.Controls.NNumericUpDown MaximumLegendItemWidthUpDown;
		private NComboBox TextFitModeComboBox;
		private Label label1;
		private System.ComponentModel.Container components = null;

		public NLegendItemTextFitModeUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label8 = new System.Windows.Forms.Label();
			this.MaximumLegendItemWidthUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.TextFitModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.MaximumLegendItemWidthUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(9, 65);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(156, 20);
			this.label8.TabIndex = 7;
			this.label8.Text = "Maximum Legend Item Width:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaximumLegendItemWidthUpDown
			// 
			this.MaximumLegendItemWidthUpDown.Location = new System.Drawing.Point(12, 88);
			this.MaximumLegendItemWidthUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.MaximumLegendItemWidthUpDown.Name = "MaximumLegendItemWidthUpDown";
			this.MaximumLegendItemWidthUpDown.Size = new System.Drawing.Size(153, 20);
			this.MaximumLegendItemWidthUpDown.TabIndex = 6;
			this.MaximumLegendItemWidthUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.MaximumLegendItemWidthUpDown.ValueChanged += new System.EventHandler(this.MaximumLegendItemWidthUpDown_ValueChanged);
			// 
			// TextFitModeComboBox
			// 
			this.TextFitModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.TextFitModeComboBox.ListProperties.DataSource = null;
			this.TextFitModeComboBox.ListProperties.DisplayMember = "";
			this.TextFitModeComboBox.Location = new System.Drawing.Point(12, 36);
			this.TextFitModeComboBox.Name = "TextFitModeComboBox";
			this.TextFitModeComboBox.Size = new System.Drawing.Size(153, 21);
			this.TextFitModeComboBox.TabIndex = 8;
			this.TextFitModeComboBox.SelectedIndexChanged += new System.EventHandler(this.TextFitModeComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(156, 20);
			this.label1.TabIndex = 9;
			this.label1.Text = "Text Fit Mode:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NLegendItemTextFitModeUC
			// 
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TextFitModeComboBox);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.MaximumLegendItemWidthUpDown);
			this.Name = "NLegendItemTextFitModeUC";
			this.Size = new System.Drawing.Size(180, 680);
			((System.ComponentModel.ISupportInitialize)(this.MaximumLegendItemWidthUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// confgigure chart
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Legend Item Text Fit Mode");
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			header.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			header.DockMode = PanelDockMode.Top;
			header.Margins = new NMarginsL(0, 10, 0, 10);
			nChartControl1.Panels.Add(header);

			NDockPanel container = new NDockPanel();
			container.DockMode = PanelDockMode.Fill;
			container.Margins = new NMarginsL(10, 10, 10, 10);
			container.PositionChildPanelsInContentBounds = true;
			nChartControl1.Panels.Add(container);

			// configure the legend
			// configure the legend
			NLegend legend = new NLegend();
			legend.Header.Text = "Maximum Legend Item Text Size";
			legend.Mode = LegendMode.Manual;
			legend.Data.ExpandMode = LegendExpandMode.HorzWrap;
			legend.DockMode = PanelDockMode.Top;
			legend.Margins = new NMarginsL(20, 20, 20, 20);
			container.ChildPanels.Add(legend);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// init controls
			TextFitModeComboBox.FillFromEnum(typeof(LegendTextFitMode));
			TextFitModeComboBox.SelectedIndex = (int)LegendTextFitMode.None;
			MaximumLegendItemWidthUpDown.Enabled = false;
		}
		/// <summary>
		/// 
		/// </summary>
		private void UpdateLegendItems()
		{
			if (nChartControl1 == null)
				return;

			NLegend legend = nChartControl1.Legends[0];

			legend.Data.Items.Clear();

			Array markShapes = Enum.GetValues(typeof(LegendMarkShape));
			NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Fresh);

			for (int i = 0; i < markShapes.Length; i++)
			{
				NLegendItemCellData licd = new NLegendItemCellData();
				LegendMarkShape markShape = (LegendMarkShape)markShapes.GetValue(i);

				licd.Text = "Some very long text about mark shape [" + markShape.ToString() + "]";
				licd.MarkShape = markShape;
				licd.MarkFillStyle = new NColorFillStyle(palette.SeriesColors[i % palette.SeriesColors.Count]);

				licd.TextFitMode = (LegendTextFitMode)TextFitModeComboBox.SelectedIndex;
				licd.MaxTextWidth = new NLength((float)MaximumLegendItemWidthUpDown.Value);

				legend.Data.Items.Add(licd);
			}

			nChartControl1.Refresh();
		}

		private void MaximumLegendItemWidthUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateLegendItems();
		}

		private void TextFitModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			MaximumLegendItemWidthUpDown.Enabled = ((LegendTextFitMode)TextFitModeComboBox.SelectedIndex) == LegendTextFitMode.Wrap;
			UpdateLegendItems();
		}
	}
}
