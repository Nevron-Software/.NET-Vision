using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NAxisMinMaxUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton btnGenerateData;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NTextBox labelMinValue;
		private Nevron.UI.WinForm.Controls.NTextBox labelMaxValue;
		private System.ComponentModel.IContainer components = null;

		public NAxisMinMaxUC()
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
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnGenerateData = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.labelMinValue = new Nevron.UI.WinForm.Controls.NTextBox();
			this.labelMaxValue = new Nevron.UI.WinForm.Controls.NTextBox();
			this.SuspendLayout();
			// 
			// btnGenerateData
			// 
			this.btnGenerateData.Location = new System.Drawing.Point(8, 8);
			this.btnGenerateData.Name = "btnGenerateData";
			this.btnGenerateData.Size = new System.Drawing.Size(136, 32);
			this.btnGenerateData.TabIndex = 0;
			this.btnGenerateData.Text = "Generate Data";
			this.btnGenerateData.Click += new System.EventHandler(this.btnGenerateData_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 120);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Y Axis Min Value:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Y Axis Max Value:";
			// 
			// labelMinValue
			// 
			this.labelMinValue.ErrorMessage = null;
			this.labelMinValue.Location = new System.Drawing.Point(8, 144);
			this.labelMinValue.Name = "labelMinValue";
			this.labelMinValue.ReadOnly = true;
			this.labelMinValue.Size = new System.Drawing.Size(128, 18);
			this.labelMinValue.TabIndex = 1;
			this.labelMinValue.Text = "";
			// 
			// labelMaxValue
			// 
			this.labelMaxValue.ErrorMessage = null;
			this.labelMaxValue.Location = new System.Drawing.Point(8, 80);
			this.labelMaxValue.Name = "labelMaxValue";
			this.labelMaxValue.ReadOnly = true;
			this.labelMaxValue.Size = new System.Drawing.Size(128, 18);
			this.labelMaxValue.TabIndex = 0;
			this.labelMaxValue.Text = "";
			// 
			// NAxisMinMaxUC
			// 
			this.Controls.Add(this.labelMaxValue);
			this.Controls.Add(this.labelMinValue);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnGenerateData);
			this.Name = "NAxisMinMaxUC";
			this.Size = new System.Drawing.Size(150, 224);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Axis Min Max");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			NChart chart = nChartControl1.Charts[0];

			// subscribe for the BeforePaint event of the chart
            chart.PaintCallback = new PaintCallback(this);

			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.RoundToTickMin = false;
			linearScale.RoundToTickMax = false;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dash;

            // add interlace stripe to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			ordinalScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dash;

			NewPointSeries(chart);
			NewPointSeries(chart);

			GenerateData(6);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
		}

		private NPointSeries NewPointSeries(NChart chart)
		{
			NPointSeries point = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point.Name = "Point Series";
			point.PointShape = PointShape.Ellipse;
			point.Size = new NLength(10, NGraphicsUnit.Point);
			point.DataLabelStyle.Visible = false;
			point.Legend.Mode = SeriesLegendMode.Series;
			return point;
		}

		private void GenerateData(int itemCount)
		{
			NChart chart = nChartControl1.Charts[0];

			int seriesCount = chart.Series.Count;

			for(int i = 0; i < seriesCount; i++)
			{
				NSeries series = (NSeries)chart.Series[i];
				series.Values.FillRandomRange(Random, itemCount, -100, 100);
			}
		}

		private void btnGenerateData_Click(object sender, System.EventArgs e)
		{
			GenerateData(6);
			nChartControl1.Refresh();
		}

        class PaintCallback : NPaintCallback
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="userControl"></param>
            public PaintCallback(NAxisMinMaxUC userControl)
            {
                m_UserControl = userControl;
            }
            /// <summary>
            /// Occurs before the panel is painted.
            /// </summary>
            /// <param name="panel"></param>
            /// <param name="eventArgs"></param>
            public override void OnBeforePaint(NPanel panel, NPanelPaintEventArgs eventArgs)
            {
                NChart chart = (NChart)panel;

                double dAxisMin = chart.Axis(StandardAxis.PrimaryY).Scale.RulerRange.Begin;
                double dAxisMax = chart.Axis(StandardAxis.PrimaryY).Scale.RulerRange.End;

                m_UserControl.labelMinValue.Text = dAxisMin.ToString();
                m_UserControl.labelMaxValue.Text = dAxisMax.ToString();
            }

            NAxisMinMaxUC m_UserControl;
        }
	}
}

