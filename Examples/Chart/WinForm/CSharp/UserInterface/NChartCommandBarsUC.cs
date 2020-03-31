using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.UI;
using System.Collections.Generic;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NChartCommandBarsUC : NExampleBaseUC
	{
		#region Constructor

		public NChartCommandBarsUC()
		{
			InitializeComponent();
		}


		#endregion

		#region Overrides

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

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			m_Manager = ((NMainForm)base.m_MainForm).chartCommandBarsManager;


			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Command Bars");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
			
			// hide the legend
			((NLegend)nChartControl1.Legends[0]).Mode = LegendMode.Disabled;

			// create chart 1
			NChart chart1 = nChartControl1.Charts[0];
			chart1.Enable3D = true;
			chart1.Name = "Bar Chart";
			chart1.Location = new NPointL(new NLength(5, NRelativeUnit.ParentPercentage), new NLength(5, NRelativeUnit.ParentPercentage));
			chart1.Size = new NSizeL(new NLength(40, NRelativeUnit.ParentPercentage), new NLength(95, NRelativeUnit.ParentPercentage));
			chart1.BoundsMode = BoundsMode.Fit;
			chart1.Axis(StandardAxis.Depth).Visible = false;

			// create chart 2
			NChart chart2 = new NPieChart();
			chart2.Enable3D = true;
			nChartControl1.Charts.Add(chart2);
			chart2.Name = "Pie Chart";
			chart2.Location = new NPointL(new NLength(55, NRelativeUnit.ParentPercentage), new NLength(5, NRelativeUnit.ParentPercentage));
			chart2.Size = new NSizeL(new NLength(40, NRelativeUnit.ParentPercentage), new NLength(95, NRelativeUnit.ParentPercentage));
			chart2.BoundsMode = BoundsMode.Fit;
			chart2.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);

			// add series to first chart
			NBarSeries bar = (NBarSeries)chart1.Series.Add(SeriesType.Bar);
			bar.Name = "Bar";
			bar.Values.FillRandom(Random, 10);
			bar.DataLabelStyle.Visible = false;

			// add series to second chart
			NPieSeries pie = (NPieSeries)chart2.Series.Add(SeriesType.Pie);
			pie.Name = "Pie";
			pie.Values.FillRandom(Random, 5);
			pie.PieStyle = PieStyle.SmoothEdgePie;
			pie.FillStyles[0] = new NColorFillStyle(Color.FromArgb(169,121,11));
			pie.FillStyles[1] = new NColorFillStyle(Color.FromArgb(157,157,92));
			pie.FillStyles[2] = new NColorFillStyle(Color.FromArgb(98,152,92));
			pie.FillStyles[3] = new NColorFillStyle(Color.FromArgb(111,134,181));
			pie.FillStyles[4] = new NColorFillStyle(Color.FromArgb(179,63,92));
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.UpDownOffset = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.UpDownRotation = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.UpDownZoom = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.UpDownElevation = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.UpDownOffset)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownRotation)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownZoom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownElevation)).BeginInit();
			this.SuspendLayout();
			// 
			// UpDownOffset
			// 
			this.UpDownOffset.DecimalPlaces = 2;
			this.UpDownOffset.Location = new System.Drawing.Point(8, 192);
			this.UpDownOffset.Name = "UpDownOffset";
			this.UpDownOffset.Size = new System.Drawing.Size(100, 20);
			this.UpDownOffset.TabIndex = 20;
			// 
			// UpDownRotation
			// 
			this.UpDownRotation.DecimalPlaces = 2;
			this.UpDownRotation.Location = new System.Drawing.Point(8, 136);
			this.UpDownRotation.Name = "UpDownRotation";
			this.UpDownRotation.Size = new System.Drawing.Size(100, 20);
			this.UpDownRotation.TabIndex = 19;
			// 
			// UpDownZoom
			// 
			this.UpDownZoom.DecimalPlaces = 2;
			this.UpDownZoom.Location = new System.Drawing.Point(8, 80);
			this.UpDownZoom.Name = "UpDownZoom";
			this.UpDownZoom.Size = new System.Drawing.Size(100, 20);
			this.UpDownZoom.TabIndex = 18;
			// 
			// UpDownElevation
			// 
			this.UpDownElevation.DecimalPlaces = 2;
			this.UpDownElevation.Location = new System.Drawing.Point(8, 24);
			this.UpDownElevation.Name = "UpDownElevation";
			this.UpDownElevation.Size = new System.Drawing.Size(100, 20);
			this.UpDownElevation.TabIndex = 17;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 176);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 15);
			this.label4.TabIndex = 16;
			this.label4.Text = "Offset Step:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 15);
			this.label3.TabIndex = 15;
			this.label3.Text = "Zoom Step:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 12);
			this.label2.TabIndex = 14;
			this.label2.Text = "Elevation Step:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 120);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "Rotation Step:";
			// 
			// NChartCommandBarsUC
			// 
			this.Controls.Add(this.UpDownOffset);
			this.Controls.Add(this.UpDownRotation);
			this.Controls.Add(this.UpDownZoom);
			this.Controls.Add(this.UpDownElevation);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "NChartCommandBarsUC";
			this.Size = new System.Drawing.Size(120, 232);
			((System.ComponentModel.ISupportInitialize)(this.UpDownOffset)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownRotation)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownZoom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownElevation)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		internal NChartCommandBarsManager m_Manager;
		private Nevron.UI.WinForm.Controls.NNumericUpDown UpDownOffset;
		private Nevron.UI.WinForm.Controls.NNumericUpDown UpDownRotation;
		private Nevron.UI.WinForm.Controls.NNumericUpDown UpDownZoom;
		private Nevron.UI.WinForm.Controls.NNumericUpDown UpDownElevation;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;

		#endregion
	}
}
