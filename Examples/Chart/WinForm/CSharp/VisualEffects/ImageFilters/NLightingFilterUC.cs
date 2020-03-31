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
	public class NLightingFilterUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBubbleSeries m_Bubble;
		private NLightingImageFilter m_LightingFilter;
		private bool m_Updating;

		private Nevron.UI.WinForm.Controls.NColorDialog colorDialog;
		private Nevron.UI.WinForm.Controls.NButton ChangeBubbleSizes;
		private Nevron.UI.WinForm.Controls.NButton ChangeYValues;
		private Nevron.UI.WinForm.Controls.NButton ChangeXValues;
		private Nevron.UI.WinForm.Controls.NCheckBox InflateMargins;
		private Nevron.UI.WinForm.Controls.NComboBox BubbleShapeCombo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NButton DiffuseColorButton;
		private Nevron.UI.WinForm.Controls.NButton SpecularColorButton;
		private Nevron.UI.WinForm.Controls.NNumericUpDown PositionXnumericUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown PositionYnumericUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown PositionZnumericUpDown;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NComboBox LightSourceTypeComboBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NComboBox BlurTypeComboBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private Nevron.UI.WinForm.Controls.NNumericUpDown SurfaceScaleNumericUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ShininessNumericUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown BevelDepthNumericUpDown;
		private System.ComponentModel.Container components = null;

		public NLightingFilterUC()
		{
			m_Updating = true;
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
			this.colorDialog = new Nevron.UI.WinForm.Controls.NColorDialog();
			this.ChangeBubbleSizes = new Nevron.UI.WinForm.Controls.NButton();
			this.ChangeYValues = new Nevron.UI.WinForm.Controls.NButton();
			this.ChangeXValues = new Nevron.UI.WinForm.Controls.NButton();
			this.InflateMargins = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.BubbleShapeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.PositionXnumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.PositionYnumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.PositionZnumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.DiffuseColorButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SpecularColorButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label3 = new System.Windows.Forms.Label();
			this.LightSourceTypeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.BevelDepthNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.BlurTypeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.SurfaceScaleNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.ShininessNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.PositionXnumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PositionYnumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PositionZnumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BevelDepthNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SurfaceScaleNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ShininessNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// ChangeBubbleSizes
			// 
			this.ChangeBubbleSizes.Location = new System.Drawing.Point(11, 520);
			this.ChangeBubbleSizes.Name = "ChangeBubbleSizes";
			this.ChangeBubbleSizes.Size = new System.Drawing.Size(153, 23);
			this.ChangeBubbleSizes.TabIndex = 17;
			this.ChangeBubbleSizes.Text = "Change Bubble Sizes";
			this.ChangeBubbleSizes.Click += new System.EventHandler(this.ChangeBubbleSizes_Click);
			// 
			// ChangeYValues
			// 
			this.ChangeYValues.Location = new System.Drawing.Point(11, 456);
			this.ChangeYValues.Name = "ChangeYValues";
			this.ChangeYValues.Size = new System.Drawing.Size(153, 23);
			this.ChangeYValues.TabIndex = 15;
			this.ChangeYValues.Text = "Change Y Values";
			this.ChangeYValues.Click += new System.EventHandler(this.ChangeYValues_Click);
			// 
			// ChangeXValues
			// 
			this.ChangeXValues.Location = new System.Drawing.Point(11, 488);
			this.ChangeXValues.Name = "ChangeXValues";
			this.ChangeXValues.Size = new System.Drawing.Size(153, 23);
			this.ChangeXValues.TabIndex = 16;
			this.ChangeXValues.Text = "Change X Values";
			this.ChangeXValues.Click += new System.EventHandler(this.ChangeXValues_Click);
			// 
			// InflateMargins
			// 
			this.InflateMargins.Location = new System.Drawing.Point(11, 427);
			this.InflateMargins.Name = "InflateMargins";
			this.InflateMargins.Size = new System.Drawing.Size(153, 18);
			this.InflateMargins.TabIndex = 14;
			this.InflateMargins.Text = "Inflate Margins";
			this.InflateMargins.CheckedChanged += new System.EventHandler(this.InflateMargins_CheckedChanged);
			// 
			// BubbleShapeCombo
			// 
			this.BubbleShapeCombo.Location = new System.Drawing.Point(11, 402);
			this.BubbleShapeCombo.Name = "BubbleShapeCombo";
			this.BubbleShapeCombo.Size = new System.Drawing.Size(153, 21);
			this.BubbleShapeCombo.TabIndex = 13;
			this.BubbleShapeCombo.SelectedIndexChanged += new System.EventHandler(this.BubbleShapeCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(11, 383);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(153, 18);
			this.label1.TabIndex = 12;
			this.label1.Text = "Bubble Style:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(11, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(153, 18);
			this.label2.TabIndex = 1;
			this.label2.Text = "Position:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PositionXnumericUpDown
			// 
			this.PositionXnumericUpDown.Location = new System.Drawing.Point(11, 73);
			this.PositionXnumericUpDown.Minimum = new System.Decimal(new int[] {
																				   						100,
																				   						0,
																				   						0,
																				   						-2147483648});
			this.PositionXnumericUpDown.Name = "PositionXnumericUpDown";
			this.PositionXnumericUpDown.Size = new System.Drawing.Size(153, 20);
			this.PositionXnumericUpDown.TabIndex = 2;
			this.PositionXnumericUpDown.ValueChanged += new System.EventHandler(this.PositionXnumericUpDown_ValueChanged);
			// 
			// PositionYnumericUpDown
			// 
			this.PositionYnumericUpDown.Location = new System.Drawing.Point(11, 95);
			this.PositionYnumericUpDown.Minimum = new System.Decimal(new int[] {
																				   						100,
																				   						0,
																				   						0,
																				   						-2147483648});
			this.PositionYnumericUpDown.Name = "PositionYnumericUpDown";
			this.PositionYnumericUpDown.Size = new System.Drawing.Size(153, 20);
			this.PositionYnumericUpDown.TabIndex = 3;
			this.PositionYnumericUpDown.ValueChanged += new System.EventHandler(this.PositionYnumericUpDown_ValueChanged);
			// 
			// PositionZnumericUpDown
			// 
			this.PositionZnumericUpDown.Location = new System.Drawing.Point(11, 117);
			this.PositionZnumericUpDown.Minimum = new System.Decimal(new int[] {
																				   						100,
																				   						0,
																				   						0,
																				   						-2147483648});
			this.PositionZnumericUpDown.Name = "PositionZnumericUpDown";
			this.PositionZnumericUpDown.Size = new System.Drawing.Size(153, 20);
			this.PositionZnumericUpDown.TabIndex = 4;
			this.PositionZnumericUpDown.ValueChanged += new System.EventHandler(this.PositionZnumericUpDown_ValueChanged);
			// 
			// DiffuseColorButton
			// 
			this.DiffuseColorButton.Location = new System.Drawing.Point(11, 139);
			this.DiffuseColorButton.Name = "DiffuseColorButton";
			this.DiffuseColorButton.Size = new System.Drawing.Size(153, 23);
			this.DiffuseColorButton.TabIndex = 10;
			this.DiffuseColorButton.Text = "Diffuse color...";
			this.DiffuseColorButton.Click += new System.EventHandler(this.DiffuseColorButton_Click);
			// 
			// SpecularColorButton
			// 
			this.SpecularColorButton.Location = new System.Drawing.Point(11, 164);
			this.SpecularColorButton.Name = "SpecularColorButton";
			this.SpecularColorButton.Size = new System.Drawing.Size(153, 23);
			this.SpecularColorButton.TabIndex = 11;
			this.SpecularColorButton.Text = "Specular color...";
			this.SpecularColorButton.Click += new System.EventHandler(this.SpecularColorButton_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(11, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(153, 18);
			this.label3.TabIndex = 18;
			this.label3.Text = "Light source type:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LightSourceTypeComboBox
			// 
			this.LightSourceTypeComboBox.Location = new System.Drawing.Point(11, 30);
			this.LightSourceTypeComboBox.Name = "LightSourceTypeComboBox";
			this.LightSourceTypeComboBox.Size = new System.Drawing.Size(153, 21);
			this.LightSourceTypeComboBox.TabIndex = 19;
			this.LightSourceTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.LightSourceTypeComboBox_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(11, 189);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(153, 18);
			this.label4.TabIndex = 20;
			this.label4.Text = "Bevel depth:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BevelDepthNumericUpDown
			// 
			this.BevelDepthNumericUpDown.Location = new System.Drawing.Point(11, 209);
			this.BevelDepthNumericUpDown.Name = "BevelDepthNumericUpDown";
			this.BevelDepthNumericUpDown.Size = new System.Drawing.Size(153, 20);
			this.BevelDepthNumericUpDown.TabIndex = 21;
			this.BevelDepthNumericUpDown.ValueChanged += new System.EventHandler(this.BevelDepthNumericUpDown_ValueChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(11, 231);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(153, 18);
			this.label5.TabIndex = 22;
			this.label5.Text = "Blur type:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BlurTypeComboBox
			// 
			this.BlurTypeComboBox.Location = new System.Drawing.Point(11, 251);
			this.BlurTypeComboBox.Name = "BlurTypeComboBox";
			this.BlurTypeComboBox.Size = new System.Drawing.Size(153, 21);
			this.BlurTypeComboBox.TabIndex = 23;
			this.BlurTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.BlurTypeComboBox_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(11, 274);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(153, 18);
			this.label6.TabIndex = 24;
			this.label6.Text = "Surface scale:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SurfaceScaleNumericUpDown
			// 
			this.SurfaceScaleNumericUpDown.DecimalPlaces = 2;
			this.SurfaceScaleNumericUpDown.Increment = new System.Decimal(new int[] {
																													1,
																													0,
																													0,
																													65536});
			this.SurfaceScaleNumericUpDown.Location = new System.Drawing.Point(11, 294);
			this.SurfaceScaleNumericUpDown.Minimum = new System.Decimal(new int[] {
																					  							1,
																					  							0,
																					  							0,
																					  							65536});
			this.SurfaceScaleNumericUpDown.Name = "SurfaceScaleNumericUpDown";
			this.SurfaceScaleNumericUpDown.Size = new System.Drawing.Size(153, 20);
			this.SurfaceScaleNumericUpDown.TabIndex = 25;
			this.SurfaceScaleNumericUpDown.Value = new System.Decimal(new int[] {
																											1,
																											0,
																											0,
																											0});
			this.SurfaceScaleNumericUpDown.ValueChanged += new System.EventHandler(this.SurfaceScaleNumericUpDown_ValueChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(11, 316);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(153, 18);
			this.label7.TabIndex = 26;
			this.label7.Text = "Shininess:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ShininessNumericUpDown
			// 
			this.ShininessNumericUpDown.Location = new System.Drawing.Point(11, 336);
			this.ShininessNumericUpDown.Name = "ShininessNumericUpDown";
			this.ShininessNumericUpDown.Size = new System.Drawing.Size(153, 20);
			this.ShininessNumericUpDown.TabIndex = 27;
			this.ShininessNumericUpDown.ValueChanged += new System.EventHandler(this.ShininessNumericUpDown_ValueChanged);
			// 
			// LightingFilterUC
			// 
			this.Controls.Add(this.ShininessNumericUpDown);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.SurfaceScaleNumericUpDown);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.BlurTypeComboBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.BevelDepthNumericUpDown);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.LightSourceTypeComboBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.SpecularColorButton);
			this.Controls.Add(this.DiffuseColorButton);
			this.Controls.Add(this.PositionZnumericUpDown);
			this.Controls.Add(this.PositionYnumericUpDown);
			this.Controls.Add(this.PositionXnumericUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ChangeBubbleSizes);
			this.Controls.Add(this.ChangeYValues);
			this.Controls.Add(this.ChangeXValues);
			this.Controls.Add(this.InflateMargins);
			this.Controls.Add(this.BubbleShapeCombo);
			this.Controls.Add(this.label1);
			this.Name = "LightingFilterUC";
			this.Size = new System.Drawing.Size(175, 555);
			((System.ComponentModel.ISupportInitialize)(this.PositionXnumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PositionYnumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PositionZnumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BevelDepthNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SurfaceScaleNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ShininessNumericUpDown)).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Lighting Filter");
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

			m_Bubble.ShadowStyle.Type = ShadowType.Solid;
			m_Bubble.ShadowStyle.Offset = new NPointL(3, 3);
			m_Bubble.ShadowStyle.Color = Color.FromArgb(60, 0, 0, 0);
			m_Bubble.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			m_Bubble.InflateMargins = true;

			m_LightingFilter = new NLightingImageFilter();

			NFillStyle fillStyle = new NColorFillStyle(Color.Gold);
			fillStyle.ImageFiltersStyle.Filters.Add(m_LightingFilter);
			m_Bubble.AddDataPoint(new NBubbleDataPoint(10, 34, 10, "Company1", fillStyle));

			fillStyle = new NColorFillStyle(Color.DarkOrange);
			fillStyle.ImageFiltersStyle.Filters.Add(m_LightingFilter);
			m_Bubble.AddDataPoint(new NBubbleDataPoint(15, 12, 20, "Company2", fillStyle));

			fillStyle = new NColorFillStyle(Color.Crimson);
			fillStyle.ImageFiltersStyle.Filters.Add(m_LightingFilter);
			m_Bubble.AddDataPoint(new NBubbleDataPoint(12, 24, 25, "Company3", fillStyle));

			fillStyle = new NColorFillStyle(Color.DarkOrchid);
			fillStyle.ImageFiltersStyle.Filters.Add(m_LightingFilter);
			m_Bubble.AddDataPoint(new NBubbleDataPoint(8, 56, 15, "Company4", fillStyle));

			BubbleShapeCombo.FillFromEnum(typeof(PointShape));
			BubbleShapeCombo.SelectedIndex = 7;

			InflateMargins.Checked = true;

			LightSourceTypeComboBox.FillFromEnum(typeof(LightSourceType));
			BlurTypeComboBox.FillFromEnum(typeof(BlurType));

			BevelDepthNumericUpDown.Value = (decimal)m_LightingFilter.BevelDepth.Value;
			BlurTypeComboBox.SelectedIndex = (int)m_LightingFilter.BlurType;
			SurfaceScaleNumericUpDown.Value = (decimal)m_LightingFilter.SurfaceScale;
			ShininessNumericUpDown.Value = (decimal)m_LightingFilter.Shininess;
			LightSourceTypeComboBox.SelectedIndex = (int)m_LightingFilter.LightSourceType;

			NVector3DF vector = m_LightingFilter.Position;
			PositionXnumericUpDown.Value = (decimal)vector.X;
			PositionYnumericUpDown.Value = (decimal)vector.Y;
			PositionZnumericUpDown.Value = (decimal)vector.Z;

			m_Updating = false;
		}

		private void ChangeXValues_Click(object sender, System.EventArgs e)
		{
			m_Bubble.XValues.FillRandom(Random, 4);
			nChartControl1.Refresh();
		}

		private void ChangeYValues_Click(object sender, System.EventArgs e)
		{
			m_Bubble.Values.FillRandom(Random, 4);
			nChartControl1.Refresh();
		}

		private void ChangeBubbleSizes_Click(object sender, System.EventArgs e)
		{
			m_Bubble.Sizes.FillRandom(Random, 4);
			nChartControl1.Refresh();				
		}

		private void BubbleShapeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (!m_Updating)
			{
				m_Bubble.BubbleShape = (PointShape)BubbleShapeCombo.SelectedIndex;
				nChartControl1.Refresh();
			}
		}

		private void InflateMargins_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!m_Updating)
			{
				m_Bubble.InflateMargins = InflateMargins.Checked;
				nChartControl1.Refresh();
			}
		}

		private void DiffuseColorButton_Click(object sender, System.EventArgs e)
		{
			colorDialog.Color = m_LightingFilter.DiffuseColor;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				m_LightingFilter.DiffuseColor = colorDialog.Color;
				nChartControl1.Refresh();
			}
		}

		private void SpecularColorButton_Click(object sender, System.EventArgs e)
		{
			colorDialog.Color = m_LightingFilter.SpecularColor;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				m_LightingFilter.SpecularColor = colorDialog.Color;
				nChartControl1.Refresh();
			}
		}

		private void UpdateFilter()
		{
			if (m_Updating)
				return;

			NVector3DF vector = new NVector3DF(
				(float)PositionXnumericUpDown.Value,
				(float)PositionYnumericUpDown.Value,
				(float)PositionZnumericUpDown.Value);

			m_LightingFilter.Position = vector;
			m_LightingFilter.LightSourceType = (LightSourceType)(LightSourceTypeComboBox.SelectedIndex);
			m_LightingFilter.BevelDepth = new NLength((int)BevelDepthNumericUpDown.Value);
			m_LightingFilter.BlurType = (BlurType)BlurTypeComboBox.SelectedIndex;
			m_LightingFilter.SurfaceScale = (float)SurfaceScaleNumericUpDown.Value;
			m_LightingFilter.Shininess = (float)ShininessNumericUpDown.Value;

			nChartControl1.Refresh();
		}


		private void PositionXnumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateFilter();
		}

		private void PositionYnumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateFilter();
		}

		private void PositionZnumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateFilter();
		}

		private void LightSourceTypeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateFilter();
		}

		private void BevelDepthNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateFilter();
		}

		private void BlurTypeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateFilter();
		}

		private void SurfaceScaleNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateFilter();
		}

		private void ShininessNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateFilter();
		}
	}
}
