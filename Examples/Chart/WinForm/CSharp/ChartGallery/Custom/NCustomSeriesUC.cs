using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NCustomSeriesUC : NExampleBaseUC
	{
		private System.ComponentModel.Container components = null;

		public NCustomSeriesUC()
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
			this.SuspendLayout();
			// 
			// NCustomSeriesUC
			// 
			this.Name = "NCustomSeriesUC";
			this.Size = new System.Drawing.Size(188, 181);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Custom Series");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// obtain a reference to the default chart
			NChart chart = nChartControl1.Charts[0];

            // configure X axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;

			// add a custom series and set its callback object
			NCustomSeries customSeries = new NCustomSeries();
			chart.Series.Add(customSeries);

			// create a paint callback object for the custom series
			MyCustomBezierSeries callback = new MyCustomBezierSeries(chart, customSeries);
			customSeries.Callback = callback;
			callback.Points = new NPointF[]
			{
				new NPointF(10, 20),
				new NPointF(55, 60),
				new NPointF(65, 180),
				new NPointF(110, 102),

				new NPointF(150, 99),
				new NPointF(225, 180),
				new NPointF(190, 202),

				new NPointF(160, 221),
				new NPointF(230, 45),
				new NPointF(200, 21),
			};

			// apply layout
			ConfigureStandardLayout(chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
		}

		[Serializable]
		class MyCustomBezierSeries : INCustomSeriesCallback
		{
			#region Constructors

			public MyCustomBezierSeries(NChart chart, NCustomSeries series)
			{
				m_Chart = chart;
				m_Series = series;

				PointFill = new NColorFillStyle(Color.Red);
				ControlPointFill = new NColorFillStyle(Color.DarkOliveGreen);
				BezierStroke = new NStrokeStyle(1, Color.Indigo);
				TangentStroke = new NStrokeStyle(1, Color.OliveDrab);
			}

			#endregion

			#region INCustomSeriesCallback

			/// <summary>
			/// Returns the X and Y axis ranges
			/// </summary>
			/// <param name="rangeX"></param>
			/// <param name="rangeY"></param>
			public void GetAxisRanges(out NRange1DD rangeX, out NRange1DD rangeY)
			{
				if ((Points == null) || (Points.Length == 0))
				{
					rangeX.Begin = Double.NaN;
					rangeX.End = Double.NaN;
					rangeY.Begin = Double.NaN;
					rangeY.End = Double.NaN;
				}
				else
				{
					rangeX.End = rangeX.Begin = Points[0].X;
					rangeY.End = rangeY.Begin = Points[0].Y;

					for (int i = 1; i < Points.Length; i++)
					{
						NPointF point = Points[i];

						if (point.X > rangeX.End)
						{
							rangeX.End = point.X;
						}
						else if (point.X < rangeX.Begin)
						{
							rangeX.Begin = point.X;
						}

						if (point.Y > rangeY.End)
						{
							rangeY.End = point.Y;
						}
						else if (point.Y < rangeY.Begin)
						{
							rangeY.Begin = point.Y;
						}
					}

					rangeX.Inflate(0.1 * rangeX.GetLength());
					rangeY.Inflate(0.1 * rangeY.GetLength());
				}
			}
			/// <summary>
			/// Performs custom painting
			/// </summary>
			/// <param name="context"></param>
			/// <param name="graphics"></param>
			public void Paint2D(NChartRenderingContext2D context, NGraphics graphics)
			{
				NVector3DF vecView = new NVector3DF();
				NVector3DF vecModel = new NVector3DF();
				NScaleRuler rulerX = m_Chart.Axis(m_Series.HorizontalAxes[0]).Scale.Ruler;
				NScaleRuler rulerY = m_Chart.Axis(m_Series.VerticalAxes[0]).Scale.Ruler;

				// current number of accumulated Bezier points
				int bpCount = 0;

				// accumulated Bezier points
				PointF[] bezierPoints = new PointF[4];

				for (int i = 0; i < Points.Length; i++)
				{
					// Transform values to chart model coorinates
					vecModel.X = rulerX.LogicalToScale(Points[i].X);
					vecModel.Y = rulerY.LogicalToScale(Points[i].Y);

					// Transform model coordinates to view coordinates
					m_Chart.TransformModelToClient(vecModel, ref vecView);

					// Draw the current point
					bool isControlPoint = (i % 3) != 0;
					if (isControlPoint)
					{
						NRectangleF rect = new NRectangleF(vecView.X - 3, vecView.Y - 3, 6, 6);
						graphics.PaintEllipse(ControlPointFill, null, rect);
					}
					else
					{
						NRectangleF rect = new NRectangleF(vecView.X - 5, vecView.Y - 5, 10, 10);
						graphics.PaintEllipse(PointFill, null, rect);
					}

					// Accumulate Bezier point
					bezierPoints[bpCount] = new PointF(vecView.X, vecView.Y);
					bpCount++;

					if (bpCount == 4)
					{
						// Draw tangents
						graphics.DrawLine(TangentStroke, new NPointF(bezierPoints[0]), new NPointF(bezierPoints[1]));
						graphics.DrawLine(TangentStroke, new NPointF(bezierPoints[2]), new NPointF(bezierPoints[3]));

						// Draw Bezier line
						GraphicsPath path = new GraphicsPath();
						path.AddBezier(bezierPoints[0], bezierPoints[1], bezierPoints[2], bezierPoints[3]);
						graphics.PaintPath(null, BezierStroke, path);
						path.Dispose();

						// Update accumultaed points
						bezierPoints[0] = bezierPoints[3];
						bpCount = 1;
					}
				}
			}

			#endregion

			#region Fields

			private NChart m_Chart;
			private NCustomSeries m_Series;
			public NPointF[] Points;
			public NFillStyle PointFill;
			public NFillStyle ControlPointFill;
			public NStrokeStyle BezierStroke;
			public NStrokeStyle TangentStroke;

			#endregion
		}
	}
}