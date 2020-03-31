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
	public class NBevelAndEmbossFilterUC : NExampleBaseUC
	{
		private bool m_bUpdating;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private Nevron.UI.WinForm.Controls.NColorDialog colorDialog;
		private Nevron.UI.WinForm.Controls.NButton LightColorButton;
		private Nevron.UI.WinForm.Controls.NButton ShadowColorButton;
		private Nevron.UI.WinForm.Controls.NComboBox BevelTypeComboBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown AngleNumericUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown DepthNumericUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown SoftenNumericUpDown;
		private Nevron.UI.WinForm.Controls.NComboBox BlurTypeComboBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown OriginalOpacityNumericUpDown;
		private Nevron.UI.WinForm.Controls.NComboBox BarStyleComboBox;
		private System.ComponentModel.Container components = null;

		public NBevelAndEmbossFilterUC()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NBevelAndEmbossFilterUC));
			this.label1 = new System.Windows.Forms.Label();
			this.BevelTypeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.AngleNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.DepthNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.SoftenNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.BlurTypeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.OriginalOpacityNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.LightColorButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ShadowColorButton = new Nevron.UI.WinForm.Controls.NButton();
			this.colorDialog = new Nevron.UI.WinForm.Controls.NColorDialog();
			this.label7 = new System.Windows.Forms.Label();
			this.BarStyleComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			((System.ComponentModel.ISupportInitialize)(this.AngleNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DepthNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SoftenNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.OriginalOpacityNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(145, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Bevel type:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BevelTypeComboBox
			// 
			this.BevelTypeComboBox.Location = new System.Drawing.Point(14, 28);
			this.BevelTypeComboBox.Name = "BevelTypeComboBox";
			this.BevelTypeComboBox.Size = new System.Drawing.Size(145, 21);
			this.BevelTypeComboBox.TabIndex = 1;
			this.BevelTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.BevelTypeComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(14, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(145, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Angle:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AngleNumericUpDown
			// 
			this.AngleNumericUpDown.Location = new System.Drawing.Point(14, 70);
			this.AngleNumericUpDown.Maximum = new System.Decimal(new int[] {
																			   360,
																			   0,
																			   0,
																			   0});
			this.AngleNumericUpDown.Name = "AngleNumericUpDown";
			this.AngleNumericUpDown.Size = new System.Drawing.Size(145, 20);
			this.AngleNumericUpDown.TabIndex = 3;
			this.AngleNumericUpDown.ValueChanged += new System.EventHandler(this.AngleNumericUpDown_ValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(14, 92);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(145, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Depth:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DepthNumericUpDown
			// 
			this.DepthNumericUpDown.Location = new System.Drawing.Point(14, 111);
			this.DepthNumericUpDown.Name = "DepthNumericUpDown";
			this.DepthNumericUpDown.Size = new System.Drawing.Size(145, 20);
			this.DepthNumericUpDown.TabIndex = 5;
			this.DepthNumericUpDown.ValueChanged += new System.EventHandler(this.DepthNumericUpDown_ValueChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(14, 133);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(145, 17);
			this.label4.TabIndex = 6;
			this.label4.Text = "Soften (blur depth):";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SoftenNumericUpDown
			// 
			this.SoftenNumericUpDown.Location = new System.Drawing.Point(14, 152);
			this.SoftenNumericUpDown.Maximum = new System.Decimal(new int[] {
																				20,
																				0,
																				0,
																				0});
			this.SoftenNumericUpDown.Name = "SoftenNumericUpDown";
			this.SoftenNumericUpDown.Size = new System.Drawing.Size(145, 20);
			this.SoftenNumericUpDown.TabIndex = 7;
			this.SoftenNumericUpDown.ValueChanged += new System.EventHandler(this.SoftenNumericUpDown_ValueChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(14, 174);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(145, 17);
			this.label5.TabIndex = 8;
			this.label5.Text = "BlurType:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BlurTypeComboBox
			// 
			this.BlurTypeComboBox.Location = new System.Drawing.Point(14, 193);
			this.BlurTypeComboBox.Name = "BlurTypeComboBox";
			this.BlurTypeComboBox.Size = new System.Drawing.Size(145, 21);
			this.BlurTypeComboBox.TabIndex = 9;
			this.BlurTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.BlurTypeComboBox_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(14, 216);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(145, 17);
			this.label6.TabIndex = 10;
			this.label6.Text = "Original opacity:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// OriginalOpacityNumericUpDown
			// 
			this.OriginalOpacityNumericUpDown.Location = new System.Drawing.Point(14, 235);
			this.OriginalOpacityNumericUpDown.Name = "OriginalOpacityNumericUpDown";
			this.OriginalOpacityNumericUpDown.Size = new System.Drawing.Size(145, 20);
			this.OriginalOpacityNumericUpDown.TabIndex = 11;
			this.OriginalOpacityNumericUpDown.ValueChanged += new System.EventHandler(this.OriginalOpacityNumericUpDown_ValueChanged);
			// 
			// LightColorButton
			// 
			this.LightColorButton.Location = new System.Drawing.Point(14, 267);
			this.LightColorButton.Name = "LightColorButton";
			this.LightColorButton.Size = new System.Drawing.Size(145, 24);
			this.LightColorButton.TabIndex = 12;
			this.LightColorButton.Text = "Light Color...";
			this.LightColorButton.Click += new System.EventHandler(this.LightColorButton_Click);
			// 
			// ShadowColorButton
			// 
			this.ShadowColorButton.Location = new System.Drawing.Point(14, 296);
			this.ShadowColorButton.Name = "ShadowColorButton";
			this.ShadowColorButton.Size = new System.Drawing.Size(145, 24);
			this.ShadowColorButton.TabIndex = 13;
			this.ShadowColorButton.Text = "Shadow color...";
			this.ShadowColorButton.Click += new System.EventHandler(this.ShadowColorButton_Click);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(14, 343);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(145, 17);
			this.label7.TabIndex = 14;
			this.label7.Text = "Bar style:";
			// 
			// BarStyleComboBox
			// 
			this.BarStyleComboBox.Location = new System.Drawing.Point(14, 366);
			this.BarStyleComboBox.Name = "BarStyleComboBox";
			this.BarStyleComboBox.Size = new System.Drawing.Size(145, 21);
			this.BarStyleComboBox.TabIndex = 15;
			this.BarStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.BarStyleComboBox_SelectedIndexChanged);
			// 
			// bevelAndEmbossImageFilterFilterUC
			// 
			this.Controls.Add(this.BarStyleComboBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.ShadowColorButton);
			this.Controls.Add(this.LightColorButton);
			this.Controls.Add(this.OriginalOpacityNumericUpDown);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.BlurTypeComboBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.SoftenNumericUpDown);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.DepthNumericUpDown);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.AngleNumericUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.BevelTypeComboBox);
			this.Controls.Add(this.label1);
			this.Name = "bevelAndEmbossImageFilterFilterUC";
			this.Size = new System.Drawing.Size(175, 424);
			((System.ComponentModel.ISupportInitialize)(this.AngleNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DepthNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SoftenNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.OriginalOpacityNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Bevel and Emboss Filter");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// configure chart
			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Wall(ChartWallType.Back).Visible = false;

			// add bar and change bar color
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar Series";
			bar.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.DarkRed, Color.Red);
			bar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			bar.DataLabelStyle.Visible = false;
			bar.Values.Add(18);
			bar.Values.Add(15);
			bar.Values.Add(21);
			bar.Values.Add(23);
			bar.Values.Add(28);
			bar.Values.Add(29);

			NBevelAndEmbossImageFilter bevelAndEmbossImageFilter = new NBevelAndEmbossImageFilter();
			bevelAndEmbossImageFilter.BlurType = BlurType.Gaussian;
			bar.FillStyle.ImageFiltersStyle.Filters.Add(bevelAndEmbossImageFilter);

			// init form controls
			m_bUpdating = true;

			BevelTypeComboBox.FillFromEnum(typeof(BevelType));
			BlurTypeComboBox.FillFromEnum(typeof(BlurType));
			BarStyleComboBox.FillFromEnum(typeof(BarShape));
			BarStyleComboBox.SelectedIndex = 0;

			BevelTypeComboBox.SelectedIndex = (int)bevelAndEmbossImageFilter.BevelType;
			AngleNumericUpDown.Value = (decimal)bevelAndEmbossImageFilter.Angle;
			DepthNumericUpDown.Value = (decimal)bevelAndEmbossImageFilter.Depth.Value;
			SoftenNumericUpDown.Value = (decimal)bevelAndEmbossImageFilter.Soften.Value;
			BlurTypeComboBox.SelectedIndex = (int)bevelAndEmbossImageFilter.BlurType;
			OriginalOpacityNumericUpDown.Value = (decimal)bevelAndEmbossImageFilter.OriginalOpacity;

			m_bUpdating = false;
		}

		private void UpdateFilter()
		{
			if (m_bUpdating)
				return;

			m_bUpdating = true;

			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			NBevelAndEmbossImageFilter bevelAndEmbossImageFilter = ((NBevelAndEmbossImageFilter)bar.FillStyle.ImageFiltersStyle.Filters[0]);

			bevelAndEmbossImageFilter.BevelType = (BevelType)BevelTypeComboBox.SelectedIndex;
			bevelAndEmbossImageFilter.Angle = (float)AngleNumericUpDown.Value;
			bevelAndEmbossImageFilter.Depth = new NLength((int)DepthNumericUpDown.Value);
			bevelAndEmbossImageFilter.Soften = new NLength((int)SoftenNumericUpDown.Value);
			bevelAndEmbossImageFilter.BlurType = (BlurType)BlurTypeComboBox.SelectedIndex;
			bevelAndEmbossImageFilter.OriginalOpacity = (int)OriginalOpacityNumericUpDown.Value;

			m_bUpdating = false;

			nChartControl1.Refresh();
		}

		private void BevelTypeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateFilter();
		}

		private void AngleNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateFilter();
		}

		private void DepthNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateFilter();
		}

		private void SoftenNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateFilter();
		}

		private void BlurTypeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateFilter();
		}

		private void OriginalOpacityNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateFilter();
		}

		private void LightColorButton_Click(object sender, System.EventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			NBevelAndEmbossImageFilter bevelAndEmbossImageFilter = ((NBevelAndEmbossImageFilter)bar.FillStyle.ImageFiltersStyle.Filters[0]);
			colorDialog.Color = bevelAndEmbossImageFilter.LightColor;

			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				bevelAndEmbossImageFilter.LightColor = colorDialog.Color;
				nChartControl1.Refresh();
			}
		}

		private void ShadowColorButton_Click(object sender, System.EventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			NBevelAndEmbossImageFilter bevelAndEmbossImageFilter = ((NBevelAndEmbossImageFilter)bar.FillStyle.ImageFiltersStyle.Filters[0]);
			colorDialog.Color = bevelAndEmbossImageFilter.ShadowColor;

			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				bevelAndEmbossImageFilter.ShadowColor = colorDialog.Color;
				nChartControl1.Refresh();
			}
		}

		private void BarStyleComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.BarShape = (BarShape)BarStyleComboBox.SelectedIndex;

			nChartControl1.Refresh();
		}
	}
}
