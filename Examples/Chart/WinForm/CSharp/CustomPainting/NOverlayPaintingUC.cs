using System;
using System.Collections;
using System.Collections.Generic;
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
	public class NOverlayPaintingUC : NExampleBaseUC, INPaintCallback
	{
		private Nevron.UI.WinForm.Controls.NButton NewDataButton;
		private IContainer components;
		private Timer m_Timer;
		List<MousePoint> m_Points = new List<MousePoint>();
		NStrokeStyle m_StrokeCrimson = new NStrokeStyle(1, Color.Crimson);
		NStrokeStyle m_StrokeMediumSeaGreen = new NStrokeStyle(1, Color.MediumSeaGreen);


		public NOverlayPaintingUC()
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
			this.components = new System.ComponentModel.Container();
			this.NewDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_Timer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// NewDataButton
			// 
			this.NewDataButton.Location = new System.Drawing.Point(4, 5);
			this.NewDataButton.Name = "NewDataButton";
			this.NewDataButton.Size = new System.Drawing.Size(171, 24);
			this.NewDataButton.TabIndex = 1;
			this.NewDataButton.Text = "New Data";
			this.NewDataButton.Click += new System.EventHandler(this.NewDataButton_Click);
			// 
			// timer1
			// 
			this.m_Timer.Interval = 50;
			this.m_Timer.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// NOverlayPaintingUC
			// 
			this.Controls.Add(this.NewDataButton);
			this.Name = "NOverlayPaintingUC";
			this.Size = new System.Drawing.Size(180, 106);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Overlay Painting <br /><font size = '12pt'>(Move the mouse over the chart and press the mouse buttons.)</font>");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.TextFormat = TextFormat.XML;

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.OverlayPaintCallback = this;

    		// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			scaleX.RoundToTickMin = true;
			scaleX.RoundToTickMax = true;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			scaleY.RoundToTickMin = true;
			scaleY.RoundToTickMax = true;
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// add a point series
			NPointSeries point = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point.Name = "Point Series";
			point.DataLabelStyle.Visible = false;
			point.FillStyle = new NColorFillStyle(Color.FromArgb(160, LightOrange));
			point.BorderStyle.Width = new NLength(0);
			point.Size = new NLength(1, NRelativeUnit.ParentPercentage);
			point.PointShape = PointShape.Ellipse;
			point.InflateMargins = true;
			point.UseXValues = true;

			GenerateXYData(point);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// attach mouse move handler
			nChartControl1.MouseMove += new MouseEventHandler(nChartControl1_MouseMove);

			// start the timer
			m_Timer.Start();
		}

		private void NewDataButton_Click(object sender, System.EventArgs e)
		{
			NPointSeries point = (NPointSeries)nChartControl1.Charts[0].Series[0];
			GenerateXYData(point);
			nChartControl1.Refresh();		
		}
		private void nChartControl1_MouseMove(object sender, MouseEventArgs e)
		{
			m_Points.Add(new MousePoint(e.Location, e.Button));

			DiminishPoints();

			nChartControl1.View.InvalidateOverlay();
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			DiminishPoints();

			nChartControl1.View.InvalidateOverlay();
		}

		private void GenerateXYData(NPointSeries series)
		{
			series.ClearDataPoints();

			for (int i = 0; i < 500; i++)
			{
				double u1 = Random.NextDouble();
				double u2 = Random.NextDouble();

				if (u1 == 0)
					u1 += 0.0001;

				if (u2 == 0)
					u2 += 0.0001;

				double z0 = Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2);
				double z1 = Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2);

				series.XValues.Add(z0);
				series.Values.Add(z1);
			}
		}
		private void DiminishPoints()
		{
			if (m_Points.Count == 0)
				return;

			for (int i = 0; i < m_Points.Count; i++)
			{
				MousePoint site = m_Points[i];
				site.Size -= 0.4f;
				m_Points[i] = site;
			}

			int removeCount = 0;

			for (int i = 0; i < m_Points.Count; i++)
			{
				if (m_Points[i].Size > 0)
					break;

				removeCount++;
			}

			if (removeCount > 0)
			{
				m_Points.RemoveRange(0, removeCount);
			}
		}

		#region INPaintCallback

		public void OnAfterPaint(NPanel panel, NPanelPaintEventArgs eventArgs)
		{
			// draw a circle for each point
			for (int i = 0; i < m_Points.Count; i++)
			{
				MousePoint site = m_Points[i];
				Point p = site.Location;
				float sz = site.Size;

				if (sz > 0)
				{
					NStrokeStyle strokeStyle = null;

					if ((site.MouseButtons & MouseButtons.Left) != 0)
					{
						strokeStyle = m_StrokeCrimson;
					}
					else
					{
						strokeStyle = m_StrokeMediumSeaGreen;
					}

					if ((site.MouseButtons & MouseButtons.Right) != 0)
					{
						sz *= 4;
					}

					eventArgs.Graphics.PaintEllipse(null, strokeStyle, new NRectangleF(p.X - sz / 2, p.Y - sz / 2, sz, sz));
				}
			}
		}
		public void OnBeforePaint(NPanel panel, NPanelPaintEventArgs eventArgs) { }

		#endregion

		#region Nested Types

		struct MousePoint
		{
			public MousePoint(Point location, MouseButtons buttons)
			{
				this.Location = location;
				this.MouseButtons = buttons;
				this.Size = 20;
			}

			public Point Location;
			public MouseButtons MouseButtons;
			public float Size;
		}

		#endregion
	}
}
