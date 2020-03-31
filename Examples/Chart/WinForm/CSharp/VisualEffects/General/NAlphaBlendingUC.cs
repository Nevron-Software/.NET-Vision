using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NAlphaBlendingUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private int seriesId;
		private Nevron.UI.WinForm.Controls.NListBox seriesListBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NButton btnAddSeries;
		private Nevron.UI.WinForm.Controls.NButton btnDeleteSeries;
		private Nevron.UI.WinForm.Controls.NComboBox comboMultiBarMode;
		private Nevron.UI.WinForm.Controls.NHScrollBar scrollTransparency;
		private Nevron.UI.WinForm.Controls.NButton btnColor;
		private System.ComponentModel.Container components = null;

		public NAlphaBlendingUC()
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
			this.seriesListBox = new Nevron.UI.WinForm.Controls.NListBox();
			this.btnAddSeries = new Nevron.UI.WinForm.Controls.NButton();
			this.btnDeleteSeries = new Nevron.UI.WinForm.Controls.NButton();
			this.comboMultiBarMode = new Nevron.UI.WinForm.Controls.NComboBox();
			this.scrollTransparency = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.btnColor = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// seriesListBox
			// 
			this.seriesListBox.Location = new System.Drawing.Point(7, 8);
			this.seriesListBox.Name = "seriesListBox";
			this.seriesListBox.Size = new System.Drawing.Size(147, 173);
			this.seriesListBox.TabIndex = 0;
			this.seriesListBox.SelectedIndexChanged += new System.EventHandler(this.seriesListBox_SelectedIndexChanged);
			// 
			// btnAddSeries
			// 
			this.btnAddSeries.Location = new System.Drawing.Point(8, 193);
			this.btnAddSeries.Name = "btnAddSeries";
			this.btnAddSeries.Size = new System.Drawing.Size(99, 25);
			this.btnAddSeries.TabIndex = 1;
			this.btnAddSeries.Text = "Add Bar Series";
			this.btnAddSeries.Click += new System.EventHandler(this.btnAddSeries_Click);
			// 
			// btnDeleteSeries
			// 
			this.btnDeleteSeries.Location = new System.Drawing.Point(8, 226);
			this.btnDeleteSeries.Name = "btnDeleteSeries";
			this.btnDeleteSeries.Size = new System.Drawing.Size(99, 23);
			this.btnDeleteSeries.TabIndex = 2;
			this.btnDeleteSeries.Text = "Delete Series";
			this.btnDeleteSeries.Click += new System.EventHandler(this.btnDeleteSeries_Click);
			// 
			// comboMultiBarMode
			// 
			this.comboMultiBarMode.Location = new System.Drawing.Point(8, 44);
			this.comboMultiBarMode.Name = "comboMultiBarMode";
			this.comboMultiBarMode.Size = new System.Drawing.Size(132, 21);
			this.comboMultiBarMode.TabIndex = 3;
			this.comboMultiBarMode.SelectedIndexChanged += new System.EventHandler(this.comboMultiBarMode_SelectedIndexChanged);
			// 
			// scrollTransparency
			// 
			this.scrollTransparency.LargeChange = 1;
			this.scrollTransparency.Location = new System.Drawing.Point(8, 103);
			this.scrollTransparency.Name = "scrollTransparency";
			this.scrollTransparency.Size = new System.Drawing.Size(128, 16);
			this.scrollTransparency.TabIndex = 4;
			this.scrollTransparency.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.scrollTransparency_Scroll);
			// 
			// btnColor
			// 
			this.btnColor.Location = new System.Drawing.Point(8, 134);
			this.btnColor.Name = "btnColor";
			this.btnColor.Size = new System.Drawing.Size(99, 23);
			this.btnColor.TabIndex = 5;
			this.btnColor.Text = "Color";
			this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 17);
			this.label1.TabIndex = 6;
			this.label1.Text = "Multi Bar Mode:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 82);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 15);
			this.label2.TabIndex = 7;
			this.label2.Text = "Transparency:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnColor);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.comboMultiBarMode);
			this.groupBox1.Controls.Add(this.scrollTransparency);
			this.groupBox1.Location = new System.Drawing.Point(7, 264);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(147, 174);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Bar Properties";
			// 
			// AlphaBlendingUC
			// 
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnDeleteSeries);
			this.Controls.Add(this.btnAddSeries);
			this.Controls.Add(this.seriesListBox);
			this.Name = "AlphaBlendingUC";
			this.Size = new System.Drawing.Size(164, 454);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Alpha Blending / Transparency");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Depth = 30;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			AddSeries(MultiBarMode.Series, Color.Plum, 210);
			AddSeries(MultiBarMode.Clustered, Color.Red, 210);
			AddSeries(MultiBarMode.Series, Color.CornflowerBlue, 210);
			AddSeries(MultiBarMode.Stacked, Color.Gold, 210);

			comboMultiBarMode.Items.Add("Series");
			comboMultiBarMode.Items.Add("Clustered");
			comboMultiBarMode.Items.Add("Stacked");
			comboMultiBarMode.Items.Add("StackedPercent");

			for(int i = 0; i < m_Chart.Series.Count; i++)
			{
				NSeriesBase series = (NSeriesBase)m_Chart.Series[i];
				seriesListBox.Items.Add(series.Name);
			}

			seriesListBox.SelectedIndex = 0;
		}

		private NBarSeries AddSeries(MultiBarMode mode, Color color, int alpha)
		{
			seriesId++;

			NBarSeries bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar " + seriesId.ToString();
			bar.DataLabelStyle.Visible = false;
			bar.Legend.Mode = SeriesLegendMode.Series;
			bar.FillStyle = new NColorFillStyle(Color.FromArgb(alpha, color));
			bar.BorderStyle.Width = new NLength(0);
			bar.Values.FillRandom(Random, 7);
			bar.MultiBarMode = mode;

			return bar;
		}

		private NBarSeries GetSelectedSeries()
		{
			int selectedIndex = seriesListBox.SelectedIndex;

			if((selectedIndex < 0) || (selectedIndex >= m_Chart.Series.Count))
				return null;

			return (NBarSeries)m_Chart.Series[selectedIndex];
		}

		private void btnAddSeries_Click(object sender, System.EventArgs e)
		{
			NBarSeries bar = AddSeries(MultiBarMode.Series, RandomColor(), 210);

			seriesListBox.Items.Add(bar.Name);

			seriesListBox.SelectedIndex = seriesListBox.Items.Count - 1;

			nChartControl1.Refresh();
		}

		private void btnDeleteSeries_Click(object sender, System.EventArgs e)
		{
			int selectedIndex = seriesListBox.SelectedIndex;

			if(selectedIndex < 0)
				return;

			m_Chart.Series.RemoveAt(selectedIndex);
			nChartControl1.Refresh();

			// delete the selected list box item
			seriesListBox.Items.RemoveAt(selectedIndex);

			// select another item in the list box
			int nNewSelectedIndex = selectedIndex;

			if(nNewSelectedIndex == seriesListBox.Items.Count)
				nNewSelectedIndex--;

			if(nNewSelectedIndex >= 0)
				seriesListBox.SelectedIndex = nNewSelectedIndex;
		}

		private void comboMultiBarMode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NBarSeries bar = GetSelectedSeries();

			if(bar != null)
			{
				bar.MultiBarMode = (MultiBarMode)comboMultiBarMode.SelectedIndex;
				nChartControl1.Refresh();
			}
		}

		private void scrollTransparency_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NBarSeries bar = GetSelectedSeries();

			if(bar != null)
			{
				bar.FillStyle.SetTransparencyPercent(scrollTransparency.Value);
				nChartControl1.Refresh();
			}
		}

		private void btnColor_Click(object sender, System.EventArgs e)
		{
			NBarSeries bar = GetSelectedSeries();

			ColorDialog colorDialog = new ColorDialog();

			// get the current color of the bar series
			colorDialog.Color = bar.FillStyle.GetPrimaryColor().ToColor();
			int alpha = colorDialog.Color.A;

			if(colorDialog.ShowDialog() == DialogResult.OK)
			{
				// set new color for the bar series, keep the transparency
				Color newColor = Color.FromArgb(alpha, colorDialog.Color);
				bar.FillStyle = new NColorFillStyle(newColor);

				nChartControl1.Refresh();
			}
		}

		private void seriesListBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int selectedIndex = seriesListBox.SelectedIndex;

			if(selectedIndex < 0)
			{
				groupBox1.Enabled = false;
			}
			else
			{
				groupBox1.Enabled = true;
			}

			NBarSeries bar = GetSelectedSeries();

			if(bar != null)
			{
				comboMultiBarMode.SelectedIndex = (int)bar.MultiBarMode;

				int nCurrentAlpha = bar.FillStyle.GetPrimaryColor().ToColor().A;

				scrollTransparency.Value = 100 - (int)(100 * (nCurrentAlpha / 255.0));
			}
		}

	}
}
