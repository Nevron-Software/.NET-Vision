using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NThreeSetVennUC : NExampleBaseUC
	{
		private System.ComponentModel.IContainer components = null;

		public NThreeSetVennUC()
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
			this.SuspendLayout();
			// 
			// NThreeSetVennUC
			// 
			this.Name = "NThreeSetVennUC";
			this.Size = new System.Drawing.Size(180, 150);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// remove all panels
			nChartControl1.Panels.Clear();

			// create a Venn chart
			NChart chart = new NVennChart();

			// create a title
			NLabel title = new NLabel("Three Set Venn");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// create a Venn series
			NVennSeries venn = (NVennSeries)chart.Series.Add(SeriesType.Venn);

			ThreeSetVenn(venn);
			ThreeSetVennLabels(venn);
			ThreeSetVennInteractivity(venn);

			// set a tooltip tool
			nChartControl1.Controller.Selection.Add(chart);
			nChartControl1.Controller.Tools.Add(new NTooltipTool());

			// apply layout
			ConfigureStandardLayout(chart, title, null);
		}

		void ThreeSetVenn(NVennSeries venn)
		{
			const int nSetCount = 3;
			const float fStartAngle = -((float)Math.PI / 2);
			const float fScale = 14;
			const float fCenterX = 0;
			const float fCenterY = 0;
			float fIncrementAngle = (float)(2 * Math.PI / nSetCount);

			venn.ClearContours();

			for(int i = 0; i < nSetCount; i++)
			{
				float fAngle = fStartAngle + i * fIncrementAngle;
				float x = (float)Math.Round(fCenterX + Math.Cos(fAngle) * fScale, 1);
				float y = (float)Math.Round(fCenterY + Math.Sin(fAngle) * fScale, 1);

				venn.AddVennContour(VennShape.Ellipse, new NPointF(x, y), new NSizeF(50, 50), 0, i);
			}
		}

		void ThreeSetVennLabels(NVennSeries venn)
		{
			string[] s1 = new string[]{ "A", "B", "C" };
			string[] s2 = new string[]{ "BC", "AC", "AB" };

			venn.ClearLabels();
			venn.LabelsTextStyle.FontStyle = new NFontStyle("Verdana", 8);

			// add the center label
			venn.AddLabel("ABC", new NPointF(0, 0));

			// add outer labels
			NPointF[] points = CalculateLabelPositions(3, 30, (float)(-Math.PI/2));
			for(int i = 0; i < 3; i++)
			{
				venn.AddLabel(s1[i], points[i]);
			}

			// add middle labels
			points = CalculateLabelPositions(3, 17, (float)Math.PI/2);
			for(int i = 0; i < 3; i++)
			{
				venn.AddLabel(s2[i], points[i]);
			}
		}

		void ThreeSetVennInteractivity(NVennSeries venn)
		{
			int[] arrContourIds;
			NInteractivityStyle interactivity;

			// set the default tooltip
			venn.InteractivityStyle.Tooltip.Text = "Venn Diagram";
			venn.InteractivityStyle.Cursor.Type = CursorType.No;

			// clear previous interactivity objects
			venn.ClearSegmentInteractivityStyles();

			// Set tooltips and cursors for particular segments
			arrContourIds = new int[]{0};
			interactivity = new NInteractivityStyle();
			interactivity.Tooltip.Text = "Segment A";
			venn.SetInteractivityForSegment(arrContourIds, interactivity);

			arrContourIds = new int[]{1};
			interactivity = new NInteractivityStyle();
			interactivity.Tooltip.Text = "Segment B";
			venn.SetInteractivityForSegment(arrContourIds, interactivity);

			arrContourIds = new int[]{2};
			interactivity = new NInteractivityStyle();
			interactivity.Tooltip.Text = "Segment C";
			venn.SetInteractivityForSegment(arrContourIds, interactivity);

			arrContourIds = new int[]{0, 1};
			interactivity = new NInteractivityStyle();
			interactivity.Tooltip.Text = "Segment AB";
			venn.SetInteractivityForSegment(arrContourIds, interactivity);

			arrContourIds = new int[]{1, 2};
			interactivity = new NInteractivityStyle();
			interactivity.Tooltip.Text = "Segment BC";
			venn.SetInteractivityForSegment(arrContourIds, interactivity);

			arrContourIds = new int[]{0, 2};
			interactivity = new NInteractivityStyle();
			interactivity.Tooltip.Text = "Segment AC";
			venn.SetInteractivityForSegment(arrContourIds, interactivity);

			arrContourIds = new int[]{0, 1, 2};
			interactivity = new NInteractivityStyle();
			interactivity.Tooltip.Text = "Segment ABC";
			venn.SetInteractivityForSegment(arrContourIds, interactivity);
		}


		NPointF[] CalculateLabelPositions(int nSetCount, float fRadius, float fStartAngle)
		{
			float fIncrementAngle = (float)(2 * Math.PI / nSetCount);
			float fCenterX = 0;
			float fCenterY = 0;

			NPointF[] points = new NPointF[nSetCount];

			for(int i = 0; i < nSetCount; i++)
			{
				float fAngle = fStartAngle + i * fIncrementAngle;
				float x = (float)Math.Round(fCenterX + Math.Cos(fAngle) * fRadius, 1);
				float y = (float)Math.Round(fCenterY + Math.Sin(fAngle) * fRadius, 1);

				points[i] = new NPointF(x, y);
			}

			return points;
		}
	}
}

