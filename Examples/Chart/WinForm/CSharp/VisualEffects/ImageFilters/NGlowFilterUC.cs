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
	public class NGlowFilterUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBubbleSeries m_Bubble;
		private NGlowImageFilter m_GlowFilter;
		private bool m_bUpdate;

		private Nevron.UI.WinForm.Controls.NNumericUpDown OriginalOpacityNumericUpDown;
		private Nevron.UI.WinForm.Controls.NComboBox BlurTypeComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox GlowTypeComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox BubbleShapeCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox InflateMargins;
		private Nevron.UI.WinForm.Controls.NButton ChangeBubbleSizes;
		private Nevron.UI.WinForm.Controls.NButton ChangeYValues;
		private Nevron.UI.WinForm.Controls.NButton ChangeXValues;
		private Nevron.UI.WinForm.Controls.NButton GlowColorButton;
		private Nevron.UI.WinForm.Controls.NNumericUpDown DepthNumericUpDown;
		private Nevron.UI.WinForm.Controls.NColorDialog colorDialog;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.ComponentModel.Container components = null;
		

		public NGlowFilterUC()
		{
			InitializeComponent();

			BubbleShapeCombo.FillFromEnum(typeof(PointShape));
			BlurTypeComboBox.FillFromEnum(typeof(BlurType));
			GlowTypeComboBox.FillFromEnum(typeof(GlowType));
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NGlowFilterUC));
			this.BubbleShapeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.colorDialog = new Nevron.UI.WinForm.Controls.NColorDialog();
			this.GlowColorButton = new Nevron.UI.WinForm.Controls.NButton();
			this.OriginalOpacityNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.BlurTypeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.DepthNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.GlowTypeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.ChangeBubbleSizes = new Nevron.UI.WinForm.Controls.NButton();
			this.ChangeYValues = new Nevron.UI.WinForm.Controls.NButton();
			this.ChangeXValues = new Nevron.UI.WinForm.Controls.NButton();
			this.InflateMargins = new Nevron.UI.WinForm.Controls.NCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.OriginalOpacityNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DepthNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// BubbleShapeCombo
			// 
			this.BubbleShapeCombo.Location = new System.Drawing.Point(8, 256);
			this.BubbleShapeCombo.Name = "BubbleShapeCombo";
			this.BubbleShapeCombo.Size = new System.Drawing.Size(145, 21);
			this.BubbleShapeCombo.TabIndex = 31;
			this.BubbleShapeCombo.SelectedIndexChanged += new System.EventHandler(this.BubbleStyleCombo_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 232);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(145, 17);
			this.label7.TabIndex = 30;
			this.label7.Text = "Bubble style:";
			// 
			// GlowColorButton
			// 
			this.GlowColorButton.Location = new System.Drawing.Point(8, 192);
			this.GlowColorButton.Name = "GlowColorButton";
			this.GlowColorButton.Size = new System.Drawing.Size(145, 24);
			this.GlowColorButton.TabIndex = 28;
			this.GlowColorButton.Text = "Color...";
			this.GlowColorButton.Click += new System.EventHandler(this.GlowColorButton_Click);
			// 
			// OriginalOpacityNumericUpDown
			// 
			this.OriginalOpacityNumericUpDown.Location = new System.Drawing.Point(8, 166);
			this.OriginalOpacityNumericUpDown.Name = "OriginalOpacityNumericUpDown";
			this.OriginalOpacityNumericUpDown.Size = new System.Drawing.Size(145, 20);
			this.OriginalOpacityNumericUpDown.TabIndex = 27;
			this.OriginalOpacityNumericUpDown.ValueChanged += new System.EventHandler(this.OriginalOpacityNumericUpDown_ValueChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 145);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(145, 17);
			this.label6.TabIndex = 26;
			this.label6.Text = "Original opacity:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BlurTypeComboBox
			// 
			this.BlurTypeComboBox.Location = new System.Drawing.Point(8, 120);
			this.BlurTypeComboBox.Name = "BlurTypeComboBox";
			this.BlurTypeComboBox.Size = new System.Drawing.Size(145, 21);
			this.BlurTypeComboBox.TabIndex = 25;
			this.BlurTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.BlurTypeComboBox_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 99);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(145, 17);
			this.label5.TabIndex = 24;
			this.label5.Text = "BlurType:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DepthNumericUpDown
			// 
			this.DepthNumericUpDown.Location = new System.Drawing.Point(8, 75);
			this.DepthNumericUpDown.Name = "DepthNumericUpDown";
			this.DepthNumericUpDown.Size = new System.Drawing.Size(145, 20);
			this.DepthNumericUpDown.TabIndex = 21;
			this.DepthNumericUpDown.ValueChanged += new System.EventHandler(this.DepthNumericUpDown_ValueChanged);
			// 
			// GlowTypeComboBox
			// 
			this.GlowTypeComboBox.Location = new System.Drawing.Point(8, 29);
			this.GlowTypeComboBox.Name = "GlowTypeComboBox";
			this.GlowTypeComboBox.Size = new System.Drawing.Size(145, 21);
			this.GlowTypeComboBox.TabIndex = 17;
			this.GlowTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.GlowTypeComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(145, 17);
			this.label1.TabIndex = 16;
			this.label1.Text = "Glow type:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 54);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(145, 17);
			this.label8.TabIndex = 20;
			this.label8.Text = "Depth:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ChangeBubbleSizes
			// 
			this.ChangeBubbleSizes.Location = new System.Drawing.Point(8, 384);
			this.ChangeBubbleSizes.Name = "ChangeBubbleSizes";
			this.ChangeBubbleSizes.Size = new System.Drawing.Size(153, 23);
			this.ChangeBubbleSizes.TabIndex = 35;
			this.ChangeBubbleSizes.Text = "Change Bubble Sizes";
			this.ChangeBubbleSizes.Click += new System.EventHandler(this.ChangeBubbleSizes_Click);
			// 
			// ChangeYValues
			// 
			this.ChangeYValues.Location = new System.Drawing.Point(8, 320);
			this.ChangeYValues.Name = "ChangeYValues";
			this.ChangeYValues.Size = new System.Drawing.Size(153, 23);
			this.ChangeYValues.TabIndex = 33;
			this.ChangeYValues.Text = "Change Y Values";
			this.ChangeYValues.Click += new System.EventHandler(this.ChangeYValues_Click);
			// 
			// ChangeXValues
			// 
			this.ChangeXValues.Location = new System.Drawing.Point(8, 352);
			this.ChangeXValues.Name = "ChangeXValues";
			this.ChangeXValues.Size = new System.Drawing.Size(153, 23);
			this.ChangeXValues.TabIndex = 34;
			this.ChangeXValues.Text = "Change X Values";
			this.ChangeXValues.Click += new System.EventHandler(this.ChangeXValues_Click);
			// 
			// InflateMargins
			// 
			this.InflateMargins.Location = new System.Drawing.Point(8, 288);
			this.InflateMargins.Name = "InflateMargins";
			this.InflateMargins.Size = new System.Drawing.Size(153, 25);
			this.InflateMargins.TabIndex = 32;
			this.InflateMargins.Text = "Inflate Margins";
			this.InflateMargins.CheckedChanged += new System.EventHandler(this.InflateMargins_CheckedChanged);
			// 
			// GlowFilterUC
			// 
			this.Controls.Add(this.ChangeBubbleSizes);
			this.Controls.Add(this.ChangeYValues);
			this.Controls.Add(this.ChangeXValues);
			this.Controls.Add(this.InflateMargins);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.GlowColorButton);
			this.Controls.Add(this.OriginalOpacityNumericUpDown);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.BlurTypeComboBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.DepthNumericUpDown);
			this.Controls.Add(this.GlowTypeComboBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BubbleShapeCombo);
			this.Controls.Add(this.label8);
			this.Name = "GlowFilterUC";
			this.Size = new System.Drawing.Size(175, 555);
			((System.ComponentModel.ISupportInitialize)(this.OriginalOpacityNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DepthNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Glow filter - Inner and Outer glow");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			m_Bubble = (NBubbleSeries)m_Chart.Series.Add(SeriesType.Bubble);
			m_Bubble.DataLabelStyle.Visible = false;
			m_Bubble.Legend.Format = "<label> X:<xvalue> Y:<value> Size:<size>";
			m_Bubble.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Bubble.MinSize = new NLength(10.0f, NRelativeUnit.ParentPercentage);
			m_Bubble.MaxSize = new NLength(20.0f, NRelativeUnit.ParentPercentage);
			m_Bubble.UseXValues = true;
			m_Bubble.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);

			m_GlowFilter = new NGlowImageFilter();

			NFillStyle fillStyle = new NColorFillStyle(Color.Gold);
			fillStyle.ImageFiltersStyle.Filters.Add(m_GlowFilter);
			m_Bubble.AddDataPoint(new NBubbleDataPoint(10, 34, 10, "Company1", fillStyle));

			fillStyle = new NColorFillStyle(Color.DarkOrange);
			fillStyle.ImageFiltersStyle.Filters.Add(m_GlowFilter);
			m_Bubble.AddDataPoint(new NBubbleDataPoint(15, 12, 20, "Company2", fillStyle));

			fillStyle = new NColorFillStyle(Color.Crimson);
			fillStyle.ImageFiltersStyle.Filters.Add(m_GlowFilter);
			m_Bubble.AddDataPoint(new NBubbleDataPoint(12, 24, 25, "Company3", fillStyle));

			fillStyle = new NColorFillStyle(Color.DarkOrchid);
			fillStyle.ImageFiltersStyle.Filters.Add(m_GlowFilter);
			m_Bubble.AddDataPoint(new NBubbleDataPoint(8, 56, 15, "Company4", fillStyle));

			BubbleShapeCombo.SelectedIndex = 7;
			InflateMargins.Checked = true;

			m_bUpdate = true;

			GlowTypeComboBox.SelectedIndex = (int)m_GlowFilter.GlowType;
			DepthNumericUpDown.Value = (decimal)m_GlowFilter.Depth.Value;
			BlurTypeComboBox.SelectedIndex = (int)m_GlowFilter.BlurType;
			OriginalOpacityNumericUpDown.Value = (decimal)m_GlowFilter.OriginalOpacity;

			m_bUpdate = false;
		}

		private void UpdateFilter()
		{
			if (m_bUpdate)
				return;

			m_bUpdate = true;

			m_GlowFilter.GlowType = (GlowType)GlowTypeComboBox.SelectedIndex;
			m_GlowFilter.Depth = new NLength((int)DepthNumericUpDown.Value);
			m_GlowFilter.BlurType = (BlurType)BlurTypeComboBox.SelectedIndex;
			m_GlowFilter.OriginalOpacity = (int)OriginalOpacityNumericUpDown.Value;

			m_bUpdate = false;

			nChartControl1.Refresh();
		}

		private void GlowTypeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateFilter();
		}

		private void DepthNumericUpDown_ValueChanged(object sender, System.EventArgs e)
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

		private void BubbleStyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Bubble.BubbleShape = (PointShape)BubbleShapeCombo.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void GlowColorButton_Click(object sender, System.EventArgs e)
		{
			colorDialog.Color = m_GlowFilter.Color;

			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				m_GlowFilter.Color = colorDialog.Color;
				nChartControl1.Refresh();
			}
		}

		private void ChangeYValues_Click(object sender, System.EventArgs e)
		{
			m_Bubble.XValues.FillRandom(Random, 4);
			nChartControl1.Refresh();						
		}

		private void ChangeXValues_Click(object sender, System.EventArgs e)
		{
			m_Bubble.Values.FillRandom(Random, 4);
			nChartControl1.Refresh();				
		}

		private void ChangeBubbleSizes_Click(object sender, System.EventArgs e)
		{
			m_Bubble.Sizes.FillRandom(Random, 4);
			nChartControl1.Refresh();				
		}

		private void InflateMargins_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Bubble.InflateMargins = InflateMargins.Checked;
			nChartControl1.Refresh();		
		}
	}
}
