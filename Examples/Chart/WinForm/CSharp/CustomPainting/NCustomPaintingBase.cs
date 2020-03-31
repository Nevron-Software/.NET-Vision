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
using Nevron.Chart.Functions;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NCustomPaintingBase : NExampleBaseUC, INPaintCallback
	{
		private System.ComponentModel.Container components = null;
		protected NChart m_Chart;
		protected NBarSeries m_Bar;
		protected int m_nBarCount = 10;

		public NCustomPaintingBase()
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
			// NCustomPaintingBase
			// 
			this.Name = "NCustomPaintingBase";
			this.Size = new System.Drawing.Size(180, 150);
			this.ResumeLayout(false);

		}
		#endregion

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
			m_Bar.ClearDataPoints();

			NDataPoint dp = new NDataPoint();

			for (int i = 0; i < m_nBarCount; i++)
			{
				dp[DataPointValue.Value] = m_nBarCount / 2 - Random.Next(m_nBarCount);

				m_Bar.AddDataPoint(dp);
			}

			nChartControl1.Refresh();
		}

		protected void ConfigureChart(string titleText)
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader(titleText);
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.TextFormat = TextFormat.XML;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// configure chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// add interlace stripe to the Y axis
            NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);
            
			// add bar and change bar color
			m_Bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);

			m_Bar.Name = "Bar Series";
			m_Bar.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.DarkRed, Color.Red);
			m_Bar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			m_Bar.BarShape = BarShape.Cylinder;
			m_Bar.ShadowStyle.Offset = new NPointL(3, 3);
			m_Bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
			m_Bar.ShadowStyle.FadeLength = new NLength(5);
			m_Bar.DataLabelStyle.Visible = false;

			m_Chart.PaintCallback = this;
			// Configure interactivity
			nChartControl1.Controller.Selection.Add(m_Chart);
			nChartControl1.Controller.Tools.Add(new NTrackballTool());
		}

        /// <summary>
        /// Occurs before the panel is painted.
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="eventArgs"></param>
        public virtual void OnBeforePaint(NPanel panel, NPanelPaintEventArgs eventArgs)
        {
        }

        /// <summary>
        /// Occurs after the panel is painted.
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="eventArgs"></param>
        public virtual void OnAfterPaint(NPanel panel, NPanelPaintEventArgs eventArgs)
        {

        }


		#endregion
	}
}
