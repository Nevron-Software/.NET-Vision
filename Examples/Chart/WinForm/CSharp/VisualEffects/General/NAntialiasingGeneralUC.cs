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
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NAntialiasingGeneralUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NHScrollBar WidthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar DepthScroll;
		private Nevron.UI.WinForm.Controls.NCheckBox LightsCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableAntialiasingCheckBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.ComponentModel.Container components = null;

		public NAntialiasingGeneralUC()
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
			this.WidthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.DepthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.LightsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.EnableAntialiasingCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// WidthScroll
			// 
			this.WidthScroll.Location = new System.Drawing.Point(11, 95);
			this.WidthScroll.Name = "WidthScroll";
			this.WidthScroll.Size = new System.Drawing.Size(128, 16);
			this.WidthScroll.TabIndex = 3;
			this.WidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WidthScroll_Scroll);
			// 
			// DepthScroll
			// 
			this.DepthScroll.Location = new System.Drawing.Point(11, 146);
			this.DepthScroll.Name = "DepthScroll";
			this.DepthScroll.Size = new System.Drawing.Size(128, 16);
			this.DepthScroll.TabIndex = 4;
			this.DepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.DepthScroll_Scroll);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(11, 78);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Width %:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(11, 130);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Depth %:";
			// 
			// LightsCheck
			// 
			this.LightsCheck.Location = new System.Drawing.Point(11, 41);
			this.LightsCheck.Name = "LightsCheck";
			this.LightsCheck.Size = new System.Drawing.Size(128, 22);
			this.LightsCheck.TabIndex = 8;
			this.LightsCheck.Text = "Lights";
			this.LightsCheck.CheckedChanged += new System.EventHandler(this.LightsCheck_CheckedChanged);
			// 
			// EnableAntialiasingCheckBox
			// 
			this.EnableAntialiasingCheckBox.Location = new System.Drawing.Point(11, 10);
			this.EnableAntialiasingCheckBox.Name = "EnableAntialiasingCheckBox";
			this.EnableAntialiasingCheckBox.Size = new System.Drawing.Size(128, 22);
			this.EnableAntialiasingCheckBox.TabIndex = 15;
			this.EnableAntialiasingCheckBox.Text = "Enable antialiasing";
			this.EnableAntialiasingCheckBox.CheckedChanged += new System.EventHandler(this.EnableAntialiasingCheckBox_CheckedChanged);
			// 
			// NAntialiasingGeneralUC
			// 
			this.Controls.Add(this.EnableAntialiasingCheckBox);
			this.Controls.Add(this.LightsCheck);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.DepthScroll);
			this.Controls.Add(this.WidthScroll);
			this.Name = "NAntialiasingGeneralUC";
			this.Size = new System.Drawing.Size(153, 203);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Line Antialiasing");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.Axis(StandardAxis.Depth).Visible = false;

			// create a bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "My Bar Series";
			bar.DataLabelStyle.Visible = false;
			bar.Values.AddRange(monthValues);

			// apply stylesheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.AutumnMultiColor);
			styleSheet.Apply(nChartControl1.Document);

			// enable mouse trackball
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// form controls
			EnableAntialiasingCheckBox.Checked = true;
			LightsCheck.Checked = true;
		}

		private void WidthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.WidthPercent = WidthScroll.Value;
			nChartControl1.Refresh();
		}

		private void DepthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.DepthPercent = DepthScroll.Value;
			nChartControl1.Refresh();
		}

		private void LightsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = (NChart)nChartControl1.Charts[0];

			if (LightsCheck.Checked)
			{
				chart.LightModel.EnableLighting = true;
				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftCameraLight);
			}
			else
			{
				chart.LightModel.EnableLighting = false;
			}

			nChartControl1.Refresh();
		}

		private void EnableAntialiasingCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			nChartControl1.Settings.ShapeRenderingMode = EnableAntialiasingCheckBox.Checked ? ShapeRenderingMode.AntiAlias : ShapeRenderingMode.None;
			nChartControl1.Refresh();
		}
	}
}

