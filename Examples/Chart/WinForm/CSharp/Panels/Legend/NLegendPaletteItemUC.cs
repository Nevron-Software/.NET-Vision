using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NLegendPaletteItemUC : NExampleBaseUC
    {
		private Label label1;
		private UI.WinForm.Controls.NComboBox OrientationComboBox;
		private System.ComponentModel.Container components = null;
		private Label label2;
		private UI.WinForm.Controls.NComboBox ScalePositionComboBox;
		NLegendPaletteCellData m_PaletteCellData;

		public NLegendPaletteItemUC()
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
			this.label1 = new System.Windows.Forms.Label();
			this.OrientationComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.ScalePositionComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(156, 20);
			this.label1.TabIndex = 11;
			this.label1.Text = "Orientation:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// OrientationComboBox
			// 
			this.OrientationComboBox.ListProperties.CheckBoxDataMember = "";
			this.OrientationComboBox.ListProperties.DataSource = null;
			this.OrientationComboBox.ListProperties.DisplayMember = "";
			this.OrientationComboBox.Location = new System.Drawing.Point(7, 28);
			this.OrientationComboBox.Name = "OrientationComboBox";
			this.OrientationComboBox.Size = new System.Drawing.Size(153, 21);
			this.OrientationComboBox.TabIndex = 10;
			this.OrientationComboBox.SelectedIndexChanged += new System.EventHandler(this.OrientationComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(156, 20);
			this.label2.TabIndex = 13;
			this.label2.Text = "Orientation:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ScalePositionComboBox
			// 
			this.ScalePositionComboBox.ListProperties.CheckBoxDataMember = "";
			this.ScalePositionComboBox.ListProperties.DataSource = null;
			this.ScalePositionComboBox.ListProperties.DisplayMember = "";
			this.ScalePositionComboBox.Location = new System.Drawing.Point(7, 77);
			this.ScalePositionComboBox.Name = "ScalePositionComboBox";
			this.ScalePositionComboBox.Size = new System.Drawing.Size(153, 21);
			this.ScalePositionComboBox.TabIndex = 12;
			this.ScalePositionComboBox.SelectedIndexChanged += new System.EventHandler(this.ScalePositionComboBox_SelectedIndexChanged);
			// 
			// NLegendPaletteItemUC
			// 
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ScalePositionComboBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.OrientationComboBox);
			this.Name = "NLegendPaletteItemUC";
			this.Size = new System.Drawing.Size(180, 680);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
        {
            base.Initialize();

            // confgigure chart
            nChartControl1.Panels.Clear();

            // set a chart title
            NLabel header = new NLabel("Legend Custom Items");
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
			NLegend legend = CreateLegend(container, "Legend Palette Item");

			NPalette palette = new NPalette();

			palette.Mode = PaletteMode.AutoFixedEntryCount;
			//palette.SmoothPalette = true;

			m_PaletteCellData = new NLegendPaletteCellData(palette, new NRange1DD(0, 100));

			legend.Data.Items.Add(m_PaletteCellData);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			OrientationComboBox.Items.Add("Horizontal");
			OrientationComboBox.Items.Add("Vertical");
			OrientationComboBox.SelectedIndex = 0;

			ScalePositionComboBox.Items.Add("Left");
			ScalePositionComboBox.Items.Add("Right");
			ScalePositionComboBox.SelectedIndex = 0;
        }

        private NLegend CreateLegend(NDockPanel container, string title)
        {
            // configure the legend
            NLegend legend = new NLegend();
            legend.Header.Text = title;
            legend.Mode = LegendMode.Manual;
            legend.Data.ExpandMode = LegendExpandMode.HorzWrap;
            legend.DockMode = PanelDockMode.Top;
            legend.Margins = new NMarginsL(20, 20, 20, 20);
            container.ChildPanels.Add(legend);

            return legend;
        }

		private void OrientationComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_PaletteCellData.Orientation = (PaletteOrientation)OrientationComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void ScalePositionComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_PaletteCellData.ScalePosition = (PaletteScalePosition)ScalePositionComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}

	}
}
