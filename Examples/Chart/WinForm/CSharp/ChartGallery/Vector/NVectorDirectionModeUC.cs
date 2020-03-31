using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NVectorDirectionModeUC : NExampleBaseUC
	{
		private UI.WinForm.Controls.NNumericUpDown MinVectorLengthNumericUpDown;
		private Label label4;
		private UI.WinForm.Controls.NNumericUpDown MaxVectorLengthNumericUpDown;
		private Label label1;
		private NVectorSeries m_Vector;
		private System.ComponentModel.Container components = null;

		public NVectorDirectionModeUC()
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
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.MaxVectorLengthNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.MinVectorLengthNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.MaxVectorLengthNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MinVectorLengthNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 10);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(97, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Min Vector Length:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 65);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Max Vector Length:";
			// 
			// MaxVectorLengthNumericUpDown
			// 
			this.MaxVectorLengthNumericUpDown.Location = new System.Drawing.Point(11, 82);
			this.MaxVectorLengthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MaxVectorLengthNumericUpDown.Name = "MaxVectorLengthNumericUpDown";
			this.MaxVectorLengthNumericUpDown.Size = new System.Drawing.Size(151, 20);
			this.MaxVectorLengthNumericUpDown.TabIndex = 11;
			this.MaxVectorLengthNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.MaxVectorLengthNumericUpDown.ValueChanged += new System.EventHandler(this.MaxVectorLengthNumericUpDown_ValueChanged);
			// 
			// MinVectorLengthNumericUpDown
			// 
			this.MinVectorLengthNumericUpDown.Location = new System.Drawing.Point(8, 27);
			this.MinVectorLengthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MinVectorLengthNumericUpDown.Name = "MinVectorLengthNumericUpDown";
			this.MinVectorLengthNumericUpDown.Size = new System.Drawing.Size(151, 20);
			this.MinVectorLengthNumericUpDown.TabIndex = 9;
			this.MinVectorLengthNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.MinVectorLengthNumericUpDown.ValueChanged += new System.EventHandler(this.MinVectorLengthNumericUpDown_ValueChanged);
			// 
			// NVectorDirectionModeUC
			// 
			this.Controls.Add(this.MaxVectorLengthNumericUpDown);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.MinVectorLengthNumericUpDown);
			this.Controls.Add(this.label4);
			this.Name = "NVectorDirectionModeUC";
			this.Size = new System.Drawing.Size(174, 303);
			((System.ComponentModel.ISupportInitialize)(this.MaxVectorLengthNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MinVectorLengthNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("Vector Direction Mode");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			//chart.Enable3D = true;
			chart.Width = 55.0f;
			chart.Height = 55.0f;

			// setup X axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.RoundToTickMin = false;
			linearScale.RoundToTickMax = false;
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { };
			linearScale.InnerMajorTickStyle.Visible = false;

			// setup Y axis
			linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.RoundToTickMin = false;
			linearScale.RoundToTickMax = false;
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { };
			linearScale.InnerMajorTickStyle.Visible = false;

			// setup shape series
			m_Vector = (NVectorSeries)chart.Series.Add(SeriesType.Vector);
			m_Vector.FillStyle = new NColorFillStyle(Color.Red);
			m_Vector.BorderStyle.Color = Color.DarkRed;
			m_Vector.DataLabelStyle.Visible = false;
			m_Vector.InflateMargins = true;
			m_Vector.UseXValues = true;
			//m_Vector.UseZValues = true;
			m_Vector.MinArrowHeadSize = new NSizeL(2, 3);
			m_Vector.MaxArrowHeadSize = new NSizeL(4, 6);
			m_Vector.MinVectorLength = new NLength(8);
			m_Vector.MaxVectorLength = new NLength(30);
			m_Vector.Mode = VectorSeriesMode.Direction;

			// fill data
			FillData(m_Vector);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			MinVectorLengthNumericUpDown.Value = (decimal)m_Vector.MinVectorLength.Value;
			MaxVectorLengthNumericUpDown.Value = (decimal)m_Vector.MaxVectorLength.Value;
		}

		private void FillData(NVectorSeries vectorSeries)
		{
			double x = 0, y = 0;
			int k = 0;

			for (int i = 0; i < 10; i++)
			{
				x = 1;
				y += 1;

				for (int j = 0; j < 10; j++)
				{
					x += 1;

					double dx = Math.Sin(x / 3.0) * Math.Cos((x - y) / 4.0);
					double dy = Math.Cos(y / 8.0) * Math.Cos(y / 4.0);

					vectorSeries.XValues.Add(x);
					vectorSeries.Values.Add(y);
					vectorSeries.X2Values.Add(dx);
					vectorSeries.Y2Values.Add(dy);

					vectorSeries.ZValues.Add(y);
					vectorSeries.Z2Values.Add(dy);

					vectorSeries.BorderStyles[k] = new NStrokeStyle(1, ColorFromVector(dx, dy));
					k++;
				}
			}		
		}
		private Color ColorFromVector(double dx, double dy)
		{
			double length = Math.Sqrt(dx * dx + dy * dy);

			double sq2 = Math.Sqrt(2);

			int r = (int)((255 / sq2) * length);
			int g = 20;
			int b = (int)((255 / sq2) * (sq2 - length));

			return Color.FromArgb(r, g, b);
		}

		private void MinVectorLengthNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			m_Vector.MinVectorLength = new NLength((float)MinVectorLengthNumericUpDown.Value, NGraphicsUnit.Point);
			nChartControl1.Refresh();
		}

		private void MaxVectorLengthNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			m_Vector.MaxVectorLength = new NLength((float)MaxVectorLengthNumericUpDown.Value, NGraphicsUnit.Point);
			nChartControl1.Refresh();
		}
	}
}
