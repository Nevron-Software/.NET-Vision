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
	public class NXYScatterBubbleUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBubbleSeries m_Bubble;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NCheckBox InflateMargins;
		private Nevron.UI.WinForm.Controls.NHScrollBar MaxBubbleSizeScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar MinBubbleSizeScroll;
		private Nevron.UI.WinForm.Controls.NComboBox BubbleShapeCombo;
		private Nevron.UI.WinForm.Controls.NButton ChangeXValues;
		private Nevron.UI.WinForm.Controls.NButton ChangeYValues;
		private Nevron.UI.WinForm.Controls.NCheckBox AxesRoundToTick;
		private Nevron.UI.WinForm.Controls.NButton ShadowButton;
		private System.Windows.Forms.Label MaxBubbleSizeLabel;
		private System.Windows.Forms.Label MinBubbleSizeLabel;
		private System.ComponentModel.Container components = null;

		public NXYScatterBubbleUC()
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
			this.InflateMargins = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.MaxBubbleSizeScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.MinBubbleSizeScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.BubbleShapeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ChangeXValues = new Nevron.UI.WinForm.Controls.NButton();
			this.ChangeYValues = new Nevron.UI.WinForm.Controls.NButton();
			this.AxesRoundToTick = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.MaxBubbleSizeLabel = new System.Windows.Forms.Label();
			this.MinBubbleSizeLabel = new System.Windows.Forms.Label();
			this.ShadowButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// InflateMargins
			// 
			this.InflateMargins.ButtonProperties.BorderOffset = 2;
			this.InflateMargins.Location = new System.Drawing.Point(9, 172);
			this.InflateMargins.Name = "InflateMargins";
			this.InflateMargins.Size = new System.Drawing.Size(136, 20);
			this.InflateMargins.TabIndex = 45;
			this.InflateMargins.Text = "Inflate Margins";
			this.InflateMargins.CheckedChanged += new System.EventHandler(this.InflateMargins_CheckedChanged);
			// 
			// MaxBubbleSizeScroll
			// 
			this.MaxBubbleSizeScroll.LargeChange = 1;
			this.MaxBubbleSizeScroll.Location = new System.Drawing.Point(9, 135);
			this.MaxBubbleSizeScroll.Maximum = 50;
			this.MaxBubbleSizeScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.MaxBubbleSizeScroll.Name = "MaxBubbleSizeScroll";
			this.MaxBubbleSizeScroll.Size = new System.Drawing.Size(136, 16);
			this.MaxBubbleSizeScroll.TabIndex = 43;
			this.MaxBubbleSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.MaxBubbleSizeScroll_Scroll);
			// 
			// MinBubbleSizeScroll
			// 
			this.MinBubbleSizeScroll.LargeChange = 1;
			this.MinBubbleSizeScroll.Location = new System.Drawing.Point(9, 81);
			this.MinBubbleSizeScroll.Maximum = 50;
			this.MinBubbleSizeScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.MinBubbleSizeScroll.Name = "MinBubbleSizeScroll";
			this.MinBubbleSizeScroll.Size = new System.Drawing.Size(136, 16);
			this.MinBubbleSizeScroll.TabIndex = 42;
			this.MinBubbleSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.MinBubbleSizeScroll_Scroll);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(9, 117);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 18);
			this.label3.TabIndex = 41;
			this.label3.Text = "Max Bubble Size:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 18);
			this.label2.TabIndex = 40;
			this.label2.Text = "Min Bubble Size:";
			// 
			// BubbleShapeCombo
			// 
			this.BubbleShapeCombo.ListProperties.CheckBoxDataMember = "";
			this.BubbleShapeCombo.ListProperties.DataSource = null;
			this.BubbleShapeCombo.ListProperties.DisplayMember = "";
			this.BubbleShapeCombo.Location = new System.Drawing.Point(8, 27);
			this.BubbleShapeCombo.Name = "BubbleShapeCombo";
			this.BubbleShapeCombo.Size = new System.Drawing.Size(136, 21);
			this.BubbleShapeCombo.TabIndex = 39;
			this.BubbleShapeCombo.SelectedIndexChanged += new System.EventHandler(this.BubbleShapeCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 18);
			this.label1.TabIndex = 38;
			this.label1.Text = "Bubble Shape:";
			// 
			// ChangeXValues
			// 
			this.ChangeXValues.Location = new System.Drawing.Point(8, 265);
			this.ChangeXValues.Name = "ChangeXValues";
			this.ChangeXValues.Size = new System.Drawing.Size(136, 23);
			this.ChangeXValues.TabIndex = 46;
			this.ChangeXValues.Text = "Change X Values";
			this.ChangeXValues.Click += new System.EventHandler(this.ChangeXValues_Click);
			// 
			// ChangeYValues
			// 
			this.ChangeYValues.Location = new System.Drawing.Point(8, 233);
			this.ChangeYValues.Name = "ChangeYValues";
			this.ChangeYValues.Size = new System.Drawing.Size(136, 23);
			this.ChangeYValues.TabIndex = 47;
			this.ChangeYValues.Text = "Change Y Values";
			this.ChangeYValues.Click += new System.EventHandler(this.ChangeYValues_Click);
			// 
			// AxesRoundToTick
			// 
			this.AxesRoundToTick.ButtonProperties.BorderOffset = 2;
			this.AxesRoundToTick.Location = new System.Drawing.Point(9, 199);
			this.AxesRoundToTick.Name = "AxesRoundToTick";
			this.AxesRoundToTick.Size = new System.Drawing.Size(136, 19);
			this.AxesRoundToTick.TabIndex = 49;
			this.AxesRoundToTick.Text = "Axes Round To Tick";
			this.AxesRoundToTick.CheckedChanged += new System.EventHandler(this.AxesRoundToTick_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(9, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(136, 0);
			this.label4.TabIndex = 51;
			this.label4.Text = "label4";
			// 
			// MaxBubbleSizeLabel
			// 
			this.MaxBubbleSizeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MaxBubbleSizeLabel.Location = new System.Drawing.Point(153, 135);
			this.MaxBubbleSizeLabel.Name = "MaxBubbleSizeLabel";
			this.MaxBubbleSizeLabel.Size = new System.Drawing.Size(23, 15);
			this.MaxBubbleSizeLabel.TabIndex = 52;
			this.MaxBubbleSizeLabel.Text = "0";
			// 
			// MinBubbleSizeLabel
			// 
			this.MinBubbleSizeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MinBubbleSizeLabel.Location = new System.Drawing.Point(153, 81);
			this.MinBubbleSizeLabel.Name = "MinBubbleSizeLabel";
			this.MinBubbleSizeLabel.Size = new System.Drawing.Size(23, 15);
			this.MinBubbleSizeLabel.TabIndex = 53;
			this.MinBubbleSizeLabel.Text = "0";
			// 
			// ShadowButton
			// 
			this.ShadowButton.Location = new System.Drawing.Point(9, 314);
			this.ShadowButton.Name = "ShadowButton";
			this.ShadowButton.Size = new System.Drawing.Size(136, 23);
			this.ShadowButton.TabIndex = 54;
			this.ShadowButton.Text = "Bubble Shadow...";
			this.ShadowButton.Click += new System.EventHandler(this.ShadowButton_Click);
			// 
			// NXYScatterBubbleUC
			// 
			this.Controls.Add(this.ShadowButton);
			this.Controls.Add(this.MinBubbleSizeLabel);
			this.Controls.Add(this.MaxBubbleSizeLabel);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.AxesRoundToTick);
			this.Controls.Add(this.ChangeYValues);
			this.Controls.Add(this.ChangeXValues);
			this.Controls.Add(this.InflateMargins);
			this.Controls.Add(this.MaxBubbleSizeScroll);
			this.Controls.Add(this.MinBubbleSizeScroll);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.BubbleShapeCombo);
			this.Controls.Add(this.label1);
			this.Name = "NXYScatterBubbleUC";
			this.Size = new System.Drawing.Size(180, 357);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XY Bubble Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// setup chart
			m_Chart = nChartControl1.Charts[0];

			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

            // add interlace style
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(new NArgbColor(Color.Beige)), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            linearScale.StripStyles.Add(stripStyle);

			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			m_Bubble = (NBubbleSeries)m_Chart.Series.Add(SeriesType.Bubble);
			m_Bubble.DataLabelStyle.Visible = false;
			m_Bubble.Legend.Format = "<label>";
			m_Bubble.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Bubble.ShadowStyle.Type = ShadowType.Solid;
			m_Bubble.ShadowStyle.Offset = new NPointL(1.2f, 1.2f);
			m_Bubble.ShadowStyle.Color = Color.FromArgb(60, 0, 0, 0);
			m_Bubble.UseXValues = true;

			m_Bubble.AddDataPoint(new NBubbleDataPoint(27, 51, 1147995904, "India"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(50, 67, 1321851888, "China"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(76, 22, 109955400, "Mexico"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(210, 9, 142008838, "Russia"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(360, 4, 305843000, "USA"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(470, 5, 33560000, "Canada"));

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);

			// init form controls
			BubbleShapeCombo.FillFromEnum(typeof(PointShape));
			BubbleShapeCombo.SelectedIndex = 7;

			AxesRoundToTick.Checked = true;
			InflateMargins.Checked = true;
			MinBubbleSizeScroll.Value = 4;
			MaxBubbleSizeScroll.Value = 20;
		}

		private void ChangeXValues_Click(object sender, System.EventArgs e)
		{
			m_Bubble.XValues.FillRandom(Random, 4);
			m_Bubble.XValues[0] = -10;
			nChartControl1.Refresh();				
		}
		private void ChangeYValues_Click(object sender, System.EventArgs e)
		{
			m_Bubble.Values.FillRandom(Random, 4);
			nChartControl1.Refresh();				
		}
		private void BubbleShapeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Bubble.BubbleShape = (PointShape)BubbleShapeCombo.SelectedIndex;
			nChartControl1.Refresh();
		}
		private void MinBubbleSizeScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Bubble.MinSize = new NLength(MinBubbleSizeScroll.Value, NRelativeUnit.ParentPercentage);
			MinBubbleSizeLabel.Text = m_Bubble.MinSize.ToString();
			nChartControl1.Refresh();
		}
		private void MaxBubbleSizeScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Bubble.MaxSize = new NLength(MaxBubbleSizeScroll.Value, NRelativeUnit.ParentPercentage);
			MaxBubbleSizeLabel.Text = m_Bubble.MaxSize.ToString();
			nChartControl1.Refresh();
		}
		private void InflateMargins_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Bubble.InflateMargins = InflateMargins.Checked;
			nChartControl1.Refresh();
		}
		private void AxesRoundToTick_CheckedChanged(object sender, System.EventArgs e)
		{
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			linearScale.RoundToTickMin = AxesRoundToTick.Checked;
			linearScale.RoundToTickMax = AxesRoundToTick.Checked;

			linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;

			linearScale.RoundToTickMin = AxesRoundToTick.Checked;
			linearScale.RoundToTickMax = AxesRoundToTick.Checked;

			nChartControl1.Refresh();
		}
		private void ShadowButton_Click(object sender, System.EventArgs e)
		{
			NShadowStyle shadowStyleResult;

			if(NShadowStyleTypeEditor.Edit(m_Bubble.ShadowStyle, out shadowStyleResult))
			{
				m_Bubble.ShadowStyle = shadowStyleResult;
				nChartControl1.Refresh();
			}
		}
	}
}
