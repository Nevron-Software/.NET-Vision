using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NCustomPaintingUsingNevronDeviceUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				ShowDownwardArrowsCheckBox.Checked = true;
				ShowUpwardArrowsCheckBox.Checked = true;
				ShowEqualSignsCheckBox.Checked = true;
			}

			ConfigureChart("Custom Painting with Nevron Device");
			ChangeData();
		}

		#region Drawing Helpers

		protected static float CalcEdgeRectSize(float fWidth, float fHeight)
		{
			float fEdgePercent = 30.0f;
			float fMinDimension = Math.Min(fWidth, fHeight);

			return fMinDimension * (fEdgePercent / 50.0f);
		}

		protected static GraphicsPath GetArrowPath(RectangleF rect, bool bUpArrow)
		{
			PointF[] lines = new PointF[7];

			RectangleF rcArrowModel = new RectangleF(-50, -50, 100, 100);

			float fArrowHeadWidth = rcArrowModel.Width * 30.0f / 100.0f;
			float fArrowRectHeight = rcArrowModel.Height * 30.0f / 100.0f;
			float fArrowHeadEnd = rcArrowModel.Left + fArrowHeadWidth;

			lines[0] = new PointF(rcArrowModel.Right, rcArrowModel.Bottom - (rcArrowModel.Height - fArrowRectHeight) / 2);
			lines[1] = new PointF(fArrowHeadEnd, lines[0].Y);
			lines[2] = new PointF(fArrowHeadEnd, rcArrowModel.Bottom);
			lines[3] = new PointF(rcArrowModel.Left, rcArrowModel.Top + rcArrowModel.Height / 2);
			lines[4] = new PointF(fArrowHeadEnd, rcArrowModel.Top);
			lines[5] = new PointF(fArrowHeadEnd, rcArrowModel.Top + (rcArrowModel.Height - fArrowRectHeight) / 2);
			lines[6] = new PointF(rcArrowModel.Right, lines[5].Y);

			GraphicsPath path = new GraphicsPath();

			path.AddLines(lines);
			path.CloseAllFigures();

			Matrix matrix = new Matrix();
			matrix.Reset();

			if (bUpArrow)
			{
				matrix.Rotate(90, MatrixOrder.Append);
			}
			else
			{
				matrix.Rotate(-90, MatrixOrder.Append);
			}

			matrix.Scale(rect.Width / rcArrowModel.Width, rect.Height / rcArrowModel.Height);
			matrix.Translate(rect.Left + rect.Width / 2.0f, rect.Top + rect.Height / 2.0f, MatrixOrder.Append);

			path.Transform(matrix);
			matrix.Dispose();

			return path;
		}

		protected static GraphicsPath GetRoundRectanglePath(RectangleF rect)
		{
			float fEdgeM2 = CalcEdgeRectSize(rect.Width, rect.Height);

			GraphicsPath path = new GraphicsPath();
 
			path.AddArc(rect.Right - fEdgeM2, rect.Bottom - fEdgeM2, fEdgeM2, fEdgeM2, 0, 90);
			path.AddArc(rect.Left, rect.Bottom - fEdgeM2, fEdgeM2, fEdgeM2, 90, 90);
			path.AddArc(rect.Left, rect.Top, fEdgeM2, fEdgeM2, 180, 90);
			path.AddArc(rect.Right - fEdgeM2, rect.Top, fEdgeM2, fEdgeM2, 270, 90);

			path.CloseAllFigures();

			return path;
		}

		#endregion

		#region Chart Configuration

		protected void ChangeData()
		{
            int nBarCount = 10;
            NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
            bar.ClearDataPoints();

			NDataPoint dp = new NDataPoint();

			for (int i = 0; i < nBarCount; i++)
			{
				dp[DataPointValue.Value] = nBarCount / 2 - Random.Next(nBarCount);

				bar.AddDataPoint(dp);
			}
		}

		protected void ConfigureChart(string title)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader(title);
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			header.ContentAlignment = ContentAlignment.BottomCenter;
            header.Location = new NPointL(
                new NLength(50, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			nChartControl1.Legends.Clear();

			// configure chart
			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.Depth).Visible = false;

            chart.BoundsMode = BoundsMode.Stretch;
            chart.Location = new NPointL(
                new NLength(5, NRelativeUnit.ParentPercentage),
                new NLength(15, NRelativeUnit.ParentPercentage));
            chart.Size = new NSizeL(
                new NLength(90, NRelativeUnit.ParentPercentage),
                new NLength(80, NRelativeUnit.ParentPercentage));
            
			// add bar and change bar color
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar Series";
			bar.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.DarkRed, Color.Red);
			bar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			bar.BarShape = BarShape.Cylinder;
			bar.ShadowStyle.Offset = new NPointL(3, 3);
			bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
			bar.ShadowStyle.FadeLength = new NLength(5);
			bar.DataLabelStyle.Visible = false;

			chart.PaintCallback = new PaintCallback(ShowDownwardArrowsCheckBox.Checked, ShowUpwardArrowsCheckBox.Checked, ShowEqualSignsCheckBox.Checked);
		}

		#endregion

		#region Nested Classes

		public class PaintCallback : NPaintCallback
		{
			#region Constructors

			public PaintCallback(bool showDownwardArrows, bool showUpwardArrows, bool showEqualSigns)
			{
				this.showDownwardArrows = showDownwardArrows;
				this.showUpwardArrows = showUpwardArrows;
				this.showEqualSigns = showEqualSigns;
			}

			#endregion

			#region NPaintCallback Members

			public override void OnAfterPaint(NPanel panel, NPanelPaintEventArgs eventArgs)
			{
				NGraphics graphics = eventArgs.Graphics;

				double dPreviousValue, dCurrentValue;
				int nBarCount = 10;
				NChart chart = panel as NChart;
				NBarSeries bar = (NBarSeries)chart.Series[0];

				NAxis horzAxis = chart.Axis(StandardAxis.PrimaryX);
				NAxis vertAxis = chart.Axis(StandardAxis.PrimaryY);

				NVector3DF vecClientPoint = new NVector3DF();
				NVector3DF vecModelPoint = new NVector3DF();

				int nBarSize = (int)(chart.ContentArea.Width * (int)bar.WidthPercent) / (nBarCount * 200);

				// init pens and brushes
				NStrokeStyle rectStrokeStyle = new NStrokeStyle(1, Color.DarkBlue);
				NFillStyle rectFillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(125, Color.LightBlue), Color.FromArgb(125, Color.DarkBlue));

				NLightingImageFilter lightingFilter = new NLightingImageFilter();

				NStrokeStyle positiveArrowStrokeStyle = new NStrokeStyle(1, Color.DarkGreen);
				NFillStyle positiveArrowFillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.Green, Color.DarkGreen);
				positiveArrowFillStyle.ImageFiltersStyle.Filters.Add(lightingFilter);

				NStrokeStyle equalSignStrokeStyle = new NStrokeStyle(1, Color.DarkGray);
				NFillStyle equalSignFillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.Gray, Color.DarkGray);
				positiveArrowFillStyle.ImageFiltersStyle.Filters.Add(lightingFilter);

				NStrokeStyle negativeArrowStrokeStyle = new NStrokeStyle(1, Color.DarkRed);
				NFillStyle negativeArrowFillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.Red, Color.DarkRed);
				positiveArrowFillStyle.ImageFiltersStyle.Filters.Add(lightingFilter);

				for (int i = 1; i < bar.Values.Count; i++)
				{
					dPreviousValue = (double)bar.Values[i - 1];
					dCurrentValue = (double)bar.Values[i];

					vecModelPoint.X = horzAxis.TransformScaleToModel(false, i);
					vecModelPoint.Y = vertAxis.TransformScaleToModel(false, (float)(double)bar.Values[i]);
					vecModelPoint.Z = 0;

					if (!chart.TransformModelToView(vecModelPoint, ref vecClientPoint))
						continue;

					RectangleF rcArrowRect = new RectangleF(vecClientPoint.X - nBarSize, vecClientPoint.Y - nBarSize, 2 * nBarSize, 2 * nBarSize);

					if (rcArrowRect.Width <= 0 || rcArrowRect.Height <= 0)
						continue;

					if (!DisplayMark(dCurrentValue, dPreviousValue))
						continue;

					// draw arrow background
					GraphicsPath path = GetRoundRectanglePath(rcArrowRect);

					graphics.PaintPath(rectFillStyle, rectStrokeStyle, path);

					path.Dispose();

					rcArrowRect.Inflate(-5, -5);

					// draw the arrow itself
					if (rcArrowRect.Width <= 0 || rcArrowRect.Height <= 0)
						continue;

					if (dCurrentValue < dPreviousValue)
					{
						// draw negative arrow
						path = GetArrowPath(rcArrowRect, false);

						graphics.PaintPath(negativeArrowFillStyle, negativeArrowStrokeStyle, path);

						path.Dispose();
					}
					else if (dCurrentValue > dPreviousValue)
					{
						// draw positive arrow
						path = GetArrowPath(rcArrowRect, true);

						graphics.PaintPath(positiveArrowFillStyle, positiveArrowStrokeStyle, path);

						path.Dispose();
					}
					else
					{
						// draw equal sign
						NRectangleF rect = new NRectangleF(rcArrowRect.Left, rcArrowRect.Top, rcArrowRect.Width, rcArrowRect.Height / 3.0f);

						graphics.PaintRectangle(equalSignFillStyle, equalSignStrokeStyle, rect);

						rect = new NRectangleF(rcArrowRect.Left, rcArrowRect.Bottom - rect.Height, rcArrowRect.Width, rect.Height);

						graphics.PaintRectangle(equalSignFillStyle, equalSignStrokeStyle, rect);
					}
				}
			}

			#endregion

			#region Implementation

			private bool DisplayMark(double dCurrentValue, double dPreviousValue)
			{
				if (dCurrentValue < dPreviousValue)
				{
					return showDownwardArrows;
				}
				else if (dCurrentValue > dPreviousValue)
				{
					return showUpwardArrows;
				}
				else
				{
					return showEqualSigns;
				}
			}

			#endregion

			#region Fields

			private bool showDownwardArrows;
			private bool showUpwardArrows;
			private bool showEqualSigns;

			#endregion
		}

		#endregion
	}
}

