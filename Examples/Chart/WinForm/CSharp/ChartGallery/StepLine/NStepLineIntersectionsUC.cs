using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using System.Collections.Generic;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NStepLineIntersectionsUC : NExampleBaseUC
	{
		private NStepLineSeries m_Line;
		private NPointSeries m_Point;
		NAxisCursor m_XCursor;
		NAxisCursor m_YCursor;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox LineSegmentRouteCombo;
		private System.ComponentModel.Container components = null;

		public NStepLineIntersectionsUC()
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
			this.LineSegmentRouteCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// LineSegmentRouteCombo
			// 
			this.LineSegmentRouteCombo.ListProperties.CheckBoxDataMember = "";
			this.LineSegmentRouteCombo.ListProperties.DataSource = null;
			this.LineSegmentRouteCombo.ListProperties.DisplayMember = "";
			this.LineSegmentRouteCombo.Location = new System.Drawing.Point(5, 25);
			this.LineSegmentRouteCombo.Name = "LineSegmentRouteCombo";
			this.LineSegmentRouteCombo.Size = new System.Drawing.Size(169, 21);
			this.LineSegmentRouteCombo.TabIndex = 1;
			this.LineSegmentRouteCombo.SelectedIndexChanged += new System.EventHandler(this.LineSegmentRouteCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(169, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Line Segment Route:";
			// 
			// NStepLineIntersectionsUC
			// 
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LineSegmentRouteCombo);
			this.Name = "NStepLineIntersectionsUC";
			this.Size = new System.Drawing.Size(180, 364);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("Step Line Intersections");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];

            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			m_Line = (NStepLineSeries)chart.Series.Add(SeriesType.StepLine);
			m_Line.Name = "Series 1";
			m_Line.DepthPercent = 50;
			m_Line.LineSize = 2;
			m_Line.DataLabelStyle.Visible = false;
			m_Line.MarkerStyle.Visible = false;
			m_Line.Values.FillRandom(Random, 12);

			m_Point = (NPointSeries)chart.Series.Add(SeriesType.Point);
			m_Point.UseXValues = true;
			m_Point.DataLabelStyle.Visible = false;
			m_Point.Size = new NLength(6);

			m_XCursor = new NAxisCursor();
			m_XCursor.BeginEndAxis = (int)StandardAxis.PrimaryY;
			m_YCursor = new NAxisCursor();
			m_YCursor.BeginEndAxis = (int)StandardAxis.PrimaryX;

			chart.Axis(StandardAxis.PrimaryX).Cursors.Add(m_XCursor);
			chart.Axis(StandardAxis.PrimaryY).Cursors.Add(m_YCursor);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			LineSegmentRouteCombo.FillFromEnum(typeof(LineSegmentRoute));
			LineSegmentRouteCombo.SelectedIndex = 1;

			nChartControl1.MouseMove += new MouseEventHandler(OnChartControl1MouseMove);
		}

		void OnChartControl1MouseMove(object sender, MouseEventArgs e)
		{
			nChartControl1.RecalcLayout();
			NViewToScale2DTransformation viewScale = new NViewToScale2DTransformation(nChartControl1.Charts[0], (int)StandardAxis.PrimaryX, (int)StandardAxis.PrimaryY);

			NVector2DD value = new NVector2DD();
			viewScale.Transform(new Nevron.GraphicsCore.NPointF(e.X, e.Y), ref value);

			m_XCursor.Value = value.X;
			m_YCursor.Value = value.Y;

			m_Point.Values.Clear();
			m_Point.XValues.Clear();
			m_Point.FillStyles.Clear();

			List<double> xIntersections = m_Line.IntersectWithXValue(value.X);

			for (int i = 0; i < xIntersections.Count; i++)
			{
				m_Point.XValues.Add(value.X);
				m_Point.Values.Add(xIntersections[i]);
				m_Point.FillStyles[m_Point.Values.Count - 1] = new NColorFillStyle(Color.Red);
			}

			List<double> yIntersections = m_Line.IntersectWithYValue(value.Y);

			for (int i = 0; i < yIntersections.Count; i++)
			{
				m_Point.Values.Add(value.Y);
				m_Point.XValues.Add(yIntersections[i]);
				m_Point.FillStyles[m_Point.Values.Count - 1] = new NColorFillStyle(Color.Blue);
			}

			nChartControl1.Refresh();
		}

		private void LineSegmentRouteCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_Line.LineSegmentRoute = (LineSegmentRoute)LineSegmentRouteCombo.SelectedIndex;
		}
	}
}
