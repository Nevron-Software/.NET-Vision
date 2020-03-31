using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Collections;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NBoxAndWhiskers2DUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private Nevron.UI.WinForm.Controls.NCheckBox InflateMarginsCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox RoundToTickCheck;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NButton GenerateDataButton;
		private Nevron.UI.WinForm.Controls.NButton BoxBorderStyleButton;
		private Nevron.UI.WinForm.Controls.NButton BoxFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton OutliersFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton OutliersBorderStyleButton;
		private Nevron.UI.WinForm.Controls.NButton WhiskersBorderStyleButton;
		private Nevron.UI.WinForm.Controls.NButton shadowStyleButton;
		private Nevron.UI.WinForm.Controls.NHScrollBar WhiskersWidthScroll;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NHScrollBar BoxWidthScroll;
		private System.ComponentModel.Container components = null;

		public NBoxAndWhiskers2DUC()
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
			this.InflateMarginsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.RoundToTickCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.BoxBorderStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.BoxFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.WhiskersWidthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.GenerateDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.OutliersFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.OutliersBorderStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.WhiskersBorderStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.shadowStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.BoxWidthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.SuspendLayout();
			// 
			// InflateMarginsCheck
			// 
			this.InflateMarginsCheck.ButtonProperties.BorderOffset = 2;
			this.InflateMarginsCheck.Location = new System.Drawing.Point(10, 316);
			this.InflateMarginsCheck.Name = "InflateMarginsCheck";
			this.InflateMarginsCheck.Size = new System.Drawing.Size(154, 20);
			this.InflateMarginsCheck.TabIndex = 10;
			this.InflateMarginsCheck.Text = "Inflate Margins";
			this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			// 
			// RoundToTickCheck
			// 
			this.RoundToTickCheck.ButtonProperties.BorderOffset = 2;
			this.RoundToTickCheck.Location = new System.Drawing.Point(10, 340);
			this.RoundToTickCheck.Name = "RoundToTickCheck";
			this.RoundToTickCheck.Size = new System.Drawing.Size(154, 19);
			this.RoundToTickCheck.TabIndex = 11;
			this.RoundToTickCheck.Text = "Left Axis Round to Tick";
			this.RoundToTickCheck.CheckedChanged += new System.EventHandler(this.RoundToTickCheck_CheckedChanged);
			// 
			// BoxBorderStyleButton
			// 
			this.BoxBorderStyleButton.Location = new System.Drawing.Point(10, 134);
			this.BoxBorderStyleButton.Name = "BoxBorderStyleButton";
			this.BoxBorderStyleButton.Size = new System.Drawing.Size(154, 24);
			this.BoxBorderStyleButton.TabIndex = 5;
			this.BoxBorderStyleButton.Text = "Box Border Style ...";
			this.BoxBorderStyleButton.Click += new System.EventHandler(this.BoxBorderStyleButton_Click);
			// 
			// BoxFillStyleButton
			// 
			this.BoxFillStyleButton.Location = new System.Drawing.Point(10, 102);
			this.BoxFillStyleButton.Name = "BoxFillStyleButton";
			this.BoxFillStyleButton.Size = new System.Drawing.Size(154, 24);
			this.BoxFillStyleButton.TabIndex = 4;
			this.BoxFillStyleButton.Text = "Box Fill Style...";
			this.BoxFillStyleButton.Click += new System.EventHandler(this.BoxFillStyleButton_Click);
			// 
			// WhiskersWidthScroll
			// 
			this.WhiskersWidthScroll.Location = new System.Drawing.Point(11, 70);
			this.WhiskersWidthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.WhiskersWidthScroll.Name = "WhiskersWidthScroll";
			this.WhiskersWidthScroll.Size = new System.Drawing.Size(152, 16);
			this.WhiskersWidthScroll.TabIndex = 3;
			this.WhiskersWidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WhiskersWidthScroll_Scroll);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(154, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Whiskers Width:";
			// 
			// GenerateDataButton
			// 
			this.GenerateDataButton.Location = new System.Drawing.Point(10, 372);
			this.GenerateDataButton.Name = "GenerateDataButton";
			this.GenerateDataButton.Size = new System.Drawing.Size(154, 24);
			this.GenerateDataButton.TabIndex = 12;
			this.GenerateDataButton.Text = "Generate Data ...";
			this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			// 
			// OutliersFillStyleButton
			// 
			this.OutliersFillStyleButton.Location = new System.Drawing.Point(10, 166);
			this.OutliersFillStyleButton.Name = "OutliersFillStyleButton";
			this.OutliersFillStyleButton.Size = new System.Drawing.Size(154, 24);
			this.OutliersFillStyleButton.TabIndex = 6;
			this.OutliersFillStyleButton.Text = "Outliers Fill Style...";
			this.OutliersFillStyleButton.Click += new System.EventHandler(this.OutliersFillStyleButton_Click);
			// 
			// OutliersBorderStyleButton
			// 
			this.OutliersBorderStyleButton.Location = new System.Drawing.Point(10, 198);
			this.OutliersBorderStyleButton.Name = "OutliersBorderStyleButton";
			this.OutliersBorderStyleButton.Size = new System.Drawing.Size(154, 24);
			this.OutliersBorderStyleButton.TabIndex = 7;
			this.OutliersBorderStyleButton.Text = "Outliers Border Style ...";
			this.OutliersBorderStyleButton.Click += new System.EventHandler(this.OutliersBorderStyleButton_Click);
			// 
			// WhiskersBorderStyleButton
			// 
			this.WhiskersBorderStyleButton.Location = new System.Drawing.Point(10, 230);
			this.WhiskersBorderStyleButton.Name = "WhiskersBorderStyleButton";
			this.WhiskersBorderStyleButton.Size = new System.Drawing.Size(154, 24);
			this.WhiskersBorderStyleButton.TabIndex = 8;
			this.WhiskersBorderStyleButton.Text = "Whiskers Border Style ...";
			this.WhiskersBorderStyleButton.Click += new System.EventHandler(this.WhiskersBorderStyleButton_Click);
			// 
			// shadowStyleButton
			// 
			this.shadowStyleButton.Location = new System.Drawing.Point(10, 262);
			this.shadowStyleButton.Name = "shadowStyleButton";
			this.shadowStyleButton.Size = new System.Drawing.Size(154, 24);
			this.shadowStyleButton.TabIndex = 9;
			this.shadowStyleButton.Text = "Shadow Style ...";
			this.shadowStyleButton.Click += new System.EventHandler(this.ShadowStyleButton_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(154, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Box Width:";
			// 
			// BoxWidthScroll
			// 
			this.BoxWidthScroll.Location = new System.Drawing.Point(11, 24);
			this.BoxWidthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.BoxWidthScroll.Name = "BoxWidthScroll";
			this.BoxWidthScroll.Size = new System.Drawing.Size(152, 16);
			this.BoxWidthScroll.TabIndex = 1;
			this.BoxWidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BoxWidthScroll_ValueChanged);
			// 
			// NBoxAndWhiskers2DUC
			// 
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BoxWidthScroll);
			this.Controls.Add(this.shadowStyleButton);
			this.Controls.Add(this.WhiskersBorderStyleButton);
			this.Controls.Add(this.OutliersBorderStyleButton);
			this.Controls.Add(this.OutliersFillStyleButton);
			this.Controls.Add(this.GenerateDataButton);
			this.Controls.Add(this.BoxFillStyleButton);
			this.Controls.Add(this.RoundToTickCheck);
			this.Controls.Add(this.InflateMarginsCheck);
			this.Controls.Add(this.BoxBorderStyleButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.WhiskersWidthScroll);
			this.Name = "NBoxAndWhiskers2DUC";
			this.Size = new System.Drawing.Size(180, 413);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("Box and Whiskers");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// remove the legend
			nChartControl1.Legends.Clear();

			// setup the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			NBoxAndWhiskersSeries series = (NBoxAndWhiskersSeries)m_Chart.Series.Add(SeriesType.BoxAndWhiskers);
			series.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant4, LightOrange, DarkOrange);
			series.DataLabelStyle.Visible = false;
			series.MedianStrokeStyle = new NStrokeStyle(Color.Indigo);
			series.AverageStrokeStyle = new NStrokeStyle(1, Color.DarkRed, LinePattern.Dot);
			series.OutliersBorderStyle = new NStrokeStyle(DarkFuchsia);
			series.OutliersFillStyle = new NColorFillStyle(Red);

			GenerateData(series, 7);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

			BoxWidthScroll.Value = 70;
			WhiskersWidthScroll.Value = 50;
			RoundToTickCheck.Checked = true;
			InflateMarginsCheck.Checked = true;
		}

		private void GenerateData(NBoxAndWhiskersSeries series, int nCount)
		{
			series.ClearDataPoints();

			for(int i = 0; i < nCount; i++)
			{
				double boxLower = 1000 + Random.NextDouble() * 200;
				double boxUpper = boxLower + 200 + Random.NextDouble() * 200;
				double whiskersLower = boxLower - (20 + Random.NextDouble() * 300);
				double whiskersUpper = boxUpper + (20 + Random.NextDouble() * 300);

				double IQR = (boxUpper - boxLower);
				double median = boxLower + IQR * 0.25 + Random.NextDouble() * IQR * 0.5;
				double average = boxLower + IQR * 0.25 + Random.NextDouble() * IQR * 0.5;

				series.UpperBoxValues.Add(boxUpper);
				series.LowerBoxValues.Add(boxLower);
				series.UpperWhiskerValues.Add(whiskersUpper);
				series.LowerWhiskerValues.Add(whiskersLower);
				series.MedianValues.Add(median);
				series.AverageValues.Add(average);

				int outliersCount = Random.Next(5);

				NDoubleList outliers = new NDoubleList();

				for(int k = 0; k < outliersCount; k++)
				{
					double dOutlier = 0;

					if(Random.NextDouble() > 0.5)
					{
						dOutlier = boxUpper + IQR * 1.5 + Random.NextDouble() * 100;
					}
					else
					{
						dOutlier = boxLower - IQR * 1.5 - Random.NextDouble() * 100;
					}

					outliers.Add(dOutlier);
				}

				series.OutlierValues.Add(outliers);
			}
		}

		private void InflateMarginsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NSeries series = (NSeries)m_Chart.Series[0];
			series.InflateMargins = InflateMarginsCheck.Checked;
			nChartControl1.Refresh();
		}
		private void RoundToTickCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;

			linearScale.RoundToTickMin = RoundToTickCheck.Checked;
			linearScale.RoundToTickMax = RoundToTickCheck.Checked;

			nChartControl1.Refresh();
		}
		private void GenerateDataButton_Click(object sender, System.EventArgs e)
		{
			NBoxAndWhiskersSeries series = (NBoxAndWhiskersSeries)m_Chart.Series[0];
			GenerateData(series, 7);
			nChartControl1.Refresh();
		}
		private void BoxWidthScroll_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NBoxAndWhiskersSeries series = (NBoxAndWhiskersSeries)nChartControl1.Charts[0].Series[0];

			series.BoxWidthPercent = BoxWidthScroll.Value;

			nChartControl1.Refresh();
		}
		private void WhiskersWidthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NBoxAndWhiskersSeries series = (NBoxAndWhiskersSeries)nChartControl1.Charts[0].Series[0];

			series.WhiskersWidthPercent = WhiskersWidthScroll.Value;

			nChartControl1.Refresh();
		}
		private void BoxFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if (NFillStyleTypeEditor.Edit(series.FillStyle, out fillStyleResult))
			{
				series.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void BoxBorderStyleButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if (NStrokeStyleTypeEditor.Edit(series.BorderStyle, out strokeStyleResult))
			{
				series.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void OutliersFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;
			NBoxAndWhiskersSeries series = (NBoxAndWhiskersSeries)nChartControl1.Charts[0].Series[0];

			if (NFillStyleTypeEditor.Edit(series.OutliersFillStyle, out fillStyleResult))
			{
				series.OutliersFillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}					
		}
		private void OutliersBorderStyleButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;
			NBoxAndWhiskersSeries series = (NBoxAndWhiskersSeries)nChartControl1.Charts[0].Series[0];

			if (NStrokeStyleTypeEditor.Edit(series.OutliersBorderStyle, out strokeStyleResult))
			{
				series.OutliersBorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void WhiskersBorderStyleButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;
			NBoxAndWhiskersSeries series = (NBoxAndWhiskersSeries)nChartControl1.Charts[0].Series[0];

			if (NStrokeStyleTypeEditor.Edit(series.WhiskersStrokeStyle, out strokeStyleResult))
			{
				series.WhiskersStrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void ShadowStyleButton_Click(object sender, System.EventArgs e)
		{
			NShadowStyle shadowStyleResult;
			NBoxAndWhiskersSeries series = (NBoxAndWhiskersSeries)nChartControl1.Charts[0].Series[0];

			if (NShadowStyleTypeEditor.Edit(series.ShadowStyle, out shadowStyleResult))
			{
				series.ShadowStyle = shadowStyleResult;
				nChartControl1.Refresh();
			}		
		}
	}
}
