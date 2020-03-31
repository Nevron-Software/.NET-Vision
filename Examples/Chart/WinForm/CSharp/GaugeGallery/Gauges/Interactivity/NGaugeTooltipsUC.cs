using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NGaugeTooltipsUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NTextBox NeedleTooltipTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox MarkerTooltipTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox RangeTooltipTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox ScaleTooltipTextBox;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		NRangeIndicator m_Indicator1;
		NNeedleValueIndicator m_Indicator2;
		NMarkerValueIndicator m_Indicator3;
		NGaugeAxis m_Axis;

		public NGaugeTooltipsUC()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		public override void Initialize()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Gauge Tooltips");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
            
            nChartControl1.Panels.Add(header);

			// create the radial gauge
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();
            radialGauge.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
            radialGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
            radialGauge.PaintEffect = new NGlassEffectStyle();
            radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
            radialGauge.BackgroundFillStyle = new NAdvancedGradientFillStyle(AdvancedGradientScheme.WhiteOnBlack, 0);

            // configure scale
            NLinearScaleConfigurator scale = ((NGaugeAxis)radialGauge.Axes[0]).ScaleConfigurator as NLinearScaleConfigurator;
            scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
            scale.LabelFitModes = new LabelFitMode[0];
            scale.MinorTickCount = 3;
            scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.White));
            scale.OuterMajorTickStyle.FillStyle = new NColorFillStyle(Color.Orange);
            scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 12, FontStyle.Bold | FontStyle.Italic);
            scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);

            m_Axis = (NGaugeAxis)radialGauge.Axes[0];

            nChartControl1.Panels.Add(radialGauge);

			m_Indicator1 = new NRangeIndicator();
			m_Indicator1.Value = 50;
			m_Indicator1.FillStyle = new NColorFillStyle(Color.LightBlue);
			m_Indicator1.StrokeStyle.Color = Color.DarkBlue;
			m_Indicator1.EndWidth = new NLength(20);
			radialGauge.Indicators.Add(m_Indicator1);

			m_Indicator2 = new NNeedleValueIndicator();
			m_Indicator2.Value = 79;
			m_Indicator2.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			m_Indicator2.Shape.StrokeStyle.Color = Color.Red;
			radialGauge.Indicators.Add(m_Indicator2);
			radialGauge.SweepAngle = 270;

			m_Indicator3 = new NMarkerValueIndicator();
			m_Indicator3.Value = 90;
			radialGauge.Indicators.Add(m_Indicator3);

			nChartControl1.Controller.Tools.Add(new NTooltipTool());

			// init form controls
			UpdateTooltips();
		}

		private void UpdateTooltips()
		{
			if (m_Axis == null)
				return;

			m_Indicator1.InteractivityStyle.Tooltip.Text = RangeTooltipTextBox.Text;
			m_Indicator2.InteractivityStyle.Tooltip.Text = NeedleTooltipTextBox.Text;
			m_Indicator3.InteractivityStyle.Tooltip.Text = MarkerTooltipTextBox.Text;
			m_Axis.InteractivityStyle.Tooltip.Text = ScaleTooltipTextBox.Text;
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
			this.NeedleTooltipTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.RangeTooltipTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.ScaleTooltipTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.MarkerTooltipTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(171, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Needle Tooltip:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// NeedleTooltipTextBox
			// 
			this.NeedleTooltipTextBox.Location = new System.Drawing.Point(5, 45);
			this.NeedleTooltipTextBox.Name = "NeedleTooltipTextBox";
			this.NeedleTooltipTextBox.Size = new System.Drawing.Size(171, 18);
			this.NeedleTooltipTextBox.TabIndex = 1;
			this.NeedleTooltipTextBox.Text = "Needle Tooltip";
			this.NeedleTooltipTextBox.TextChanged += new System.EventHandler(this.NeedleTooltipTextBox_TextChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 126);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(171, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Range Tooltip:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// RangeTooltipTextBox
			// 
			this.RangeTooltipTextBox.Location = new System.Drawing.Point(5, 155);
			this.RangeTooltipTextBox.Name = "RangeTooltipTextBox";
			this.RangeTooltipTextBox.Size = new System.Drawing.Size(171, 18);
			this.RangeTooltipTextBox.TabIndex = 5;
			this.RangeTooltipTextBox.Text = "Range Tooltip";
			this.RangeTooltipTextBox.TextChanged += new System.EventHandler(this.RangeTooltipTextBox_TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(5, 181);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(171, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Scale Tooltip:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// ScaleTooltipTextBox
			// 
			this.ScaleTooltipTextBox.Location = new System.Drawing.Point(5, 210);
			this.ScaleTooltipTextBox.Name = "ScaleTooltipTextBox";
			this.ScaleTooltipTextBox.Size = new System.Drawing.Size(171, 18);
			this.ScaleTooltipTextBox.TabIndex = 7;
			this.ScaleTooltipTextBox.Text = "Scale Tooltip";
			this.ScaleTooltipTextBox.TextChanged += new System.EventHandler(this.ScaleTooltipTextBox_TextChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(5, 71);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(171, 23);
			this.label4.TabIndex = 2;
			this.label4.Text = "Marker Tooltip:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// MarkerTooltipTextBox
			// 
			this.MarkerTooltipTextBox.Location = new System.Drawing.Point(5, 100);
			this.MarkerTooltipTextBox.Name = "MarkerTooltipTextBox";
			this.MarkerTooltipTextBox.Size = new System.Drawing.Size(171, 18);
			this.MarkerTooltipTextBox.TabIndex = 3;
			this.MarkerTooltipTextBox.Text = "Marker Tooltip";
			this.MarkerTooltipTextBox.TextChanged += new System.EventHandler(this.MarkerTooltipTextBox_TextChanged);
			// 
			// NGaugeTooltipsUC
			// 
			this.Controls.Add(this.MarkerTooltipTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ScaleTooltipTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.RangeTooltipTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.NeedleTooltipTextBox);
			this.Controls.Add(this.label1);
			this.Name = "NGaugeTooltipsUC";
			this.Size = new System.Drawing.Size(180, 264);
			this.ResumeLayout(false);

		}
		#endregion

		private void NeedleTooltipTextBox_TextChanged(object sender, System.EventArgs e)
		{
			UpdateTooltips();
		}

		private void MarkerTooltipTextBox_TextChanged(object sender, System.EventArgs e)
		{
			UpdateTooltips();
		}

		private void RangeTooltipTextBox_TextChanged(object sender, System.EventArgs e)
		{
			UpdateTooltips();
		}

		private void ScaleTooltipTextBox_TextChanged(object sender, System.EventArgs e)
		{
			UpdateTooltips();
		}
	}
}
