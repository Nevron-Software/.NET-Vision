using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Resources;
using Nevron.Dom;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NLogarithmicScaleUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NLineSeries m_Line;
		private bool m_Updating;
		private Nevron.UI.WinForm.Controls.NCheckBox RoundToTickMin;
		private Nevron.UI.WinForm.Controls.NCheckBox RoundToTickMax;
		private Nevron.UI.WinForm.Controls.NComboBox LabelFormatCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox UseCustomMax;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label10;
		private Nevron.UI.WinForm.Controls.NTextBox MaxTextBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown LogarithBaseUpDown;
		private System.ComponentModel.Container components = null;

		public NLogarithmicScaleUC()
		{
			m_Updating = true;

			InitializeComponent();

			LabelFormatCombo.Items.Add("Default");
			LabelFormatCombo.Items.Add("Scientific");
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
			this.label2 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.LabelFormatCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.UseCustomMax = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.MaxTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.RoundToTickMin = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.RoundToTickMax = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.LogarithBaseUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.LogarithBaseUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(168, -16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Logarihm Base:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Logarithm Base:";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(16, 71);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(80, 16);
			this.label10.TabIndex = 7;
			this.label10.Text = "Label Format:";
			// 
			// LabelFormatCombo
			// 
			this.LabelFormatCombo.Location = new System.Drawing.Point(16, 93);
			this.LabelFormatCombo.Name = "LabelFormatCombo";
			this.LabelFormatCombo.Size = new System.Drawing.Size(153, 21);
			this.LabelFormatCombo.TabIndex = 9;
			this.LabelFormatCombo.SelectedIndexChanged += new System.EventHandler(this.LabelFormatCombo_SelectedIndexChanged);
			// 
			// UseCustomMax
			// 
			this.UseCustomMax.Location = new System.Drawing.Point(32, 464);
			this.UseCustomMax.Name = "UseCustomMax";
			this.UseCustomMax.Size = new System.Drawing.Size(113, 21);
			this.UseCustomMax.TabIndex = 14;
			this.UseCustomMax.Text = "Use Custom Max";
			// 
			// MaxTextBox
			// 
			this.MaxTextBox.ErrorMessage = null;
			this.MaxTextBox.Location = new System.Drawing.Point(34, 494);
			this.MaxTextBox.Name = "MaxTextBox";
			this.MaxTextBox.Size = new System.Drawing.Size(96, 18);
			this.MaxTextBox.TabIndex = 15;
			this.MaxTextBox.Text = "100";
			// 
			// RoundToTickMin
			// 
			this.RoundToTickMin.Location = new System.Drawing.Point(17, 131);
			this.RoundToTickMin.Name = "RoundToTickMin";
			this.RoundToTickMin.Size = new System.Drawing.Size(130, 19);
			this.RoundToTickMin.TabIndex = 16;
			this.RoundToTickMin.Text = "Round To Tick Min";
			this.RoundToTickMin.CheckedChanged += new System.EventHandler(this.RoundToTickMin_CheckedChanged);
			// 
			// RoundToTickMax
			// 
			this.RoundToTickMax.Location = new System.Drawing.Point(17, 155);
			this.RoundToTickMax.Name = "RoundToTickMax";
			this.RoundToTickMax.Size = new System.Drawing.Size(128, 19);
			this.RoundToTickMax.TabIndex = 17;
			this.RoundToTickMax.Text = "Round To Tick Max";
			this.RoundToTickMax.CheckedChanged += new System.EventHandler(this.RoundToTickMax_CheckedChanged);
			// 
			// LogarithBaseUpDown
			// 
			this.LogarithBaseUpDown.Location = new System.Drawing.Point(19, 38);
			this.LogarithBaseUpDown.Maximum = new System.Decimal(new int[] {
																			   30,
																			   0,
																			   0,
																			   0});
			this.LogarithBaseUpDown.Minimum = new System.Decimal(new int[] {
																			   2,
																			   0,
																			   0,
																			   0});
			this.LogarithBaseUpDown.Name = "LogarithBaseUpDown";
			this.LogarithBaseUpDown.Size = new System.Drawing.Size(149, 20);
			this.LogarithBaseUpDown.TabIndex = 18;
			this.LogarithBaseUpDown.Value = new System.Decimal(new int[] {
																			 10,
																			 0,
																			 0,
																			 0});
			this.LogarithBaseUpDown.ValueChanged += new System.EventHandler(this.LogarithBaseUpDown_ValueChanged);
			// 
			// NLogarithmicScaleUC
			// 
			this.Controls.Add(this.LogarithBaseUpDown);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.RoundToTickMin);
			this.Controls.Add(this.RoundToTickMax);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.LabelFormatCombo);
			this.Controls.Add(this.MaxTextBox);
			this.Controls.Add(this.UseCustomMax);
			this.Name = "NLogarithmicScaleUC";
			this.Size = new System.Drawing.Size(191, 466);
			((System.ComponentModel.ISupportInitialize)(this.LogarithBaseUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Logarithmic Scale");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Fit;

			m_Chart.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));
			m_Chart.BoundsMode = BoundsMode.Stretch;

			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NLogarithmicScaleConfigurator logarithmicScale = new NLogarithmicScaleConfigurator();
			logarithmicScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			logarithmicScale.MinorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			logarithmicScale.MinorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			logarithmicScale.MinorTickCount = 3;
			logarithmicScale.MajorTickMode = MajorTickMode.CustomStep;

            // add interlaced stripe 
            NScaleStripStyle stripStyle = new NScaleStripStyle();
            stripStyle.FillStyle = new NColorFillStyle(Color.Beige);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            logarithmicScale.StripStyles.Add(stripStyle);
			
			logarithmicScale.CustomStep = 1;
			
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = logarithmicScale;

			m_Line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line.Legend.Mode = SeriesLegendMode.None;
			m_Line.InflateMargins = false;
			m_Line.BorderStyle.Color = Color.Navy;
			m_Line.MarkerStyle.Visible = true;
			m_Line.MarkerStyle.PointShape = PointShape.Cylinder;
			m_Line.MarkerStyle.Width = new NLength(0.7f, NRelativeUnit.ParentPercentage);
			m_Line.MarkerStyle.Height = new NLength(0.7f, NRelativeUnit.ParentPercentage);
			m_Line.MarkerStyle.AutoDepth = true;
			m_Line.DataLabelStyle.Format = "<value>";

			m_Line.Values.Add(12);
			m_Line.Values.Add(100);
			m_Line.Values.Add(250);
			m_Line.Values.Add(500);
			m_Line.Values.Add(1500);
			m_Line.Values.Add(5500);
			m_Line.Values.Add(9090);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			LabelFormatCombo.SelectedIndex = 0;
			RoundToTickMin.Checked = true;
			RoundToTickMax.Checked = true;

			m_Updating = false;
		}

		private void UpdateScale()
		{
			if (m_Updating)
				return;

			NAxis axis = m_Chart.Axis(StandardAxis.PrimaryY);
			NLogarithmicScaleConfigurator logarithmicScale = axis.ScaleConfigurator as NLogarithmicScaleConfigurator;

			// check if null (user may have changed the scale with the editor)
			if (logarithmicScale == null)
				return;

			logarithmicScale.LogarithmBase = (double)LogarithBaseUpDown.Value;

			switch (LabelFormatCombo.SelectedIndex)
			{
				case 0:
					logarithmicScale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.General);
					break;

				case 1:
					logarithmicScale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.Scientific);
					break;
			}

			logarithmicScale.RoundToTickMax = RoundToTickMax.Checked;
			logarithmicScale.RoundToTickMin = RoundToTickMin.Checked;

			nChartControl1.Refresh();
		}

		private void LogarithBaseUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}

		private void LabelFormatCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}

		private void RoundToTickMin_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}

		private void RoundToTickMax_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}
	}
}
