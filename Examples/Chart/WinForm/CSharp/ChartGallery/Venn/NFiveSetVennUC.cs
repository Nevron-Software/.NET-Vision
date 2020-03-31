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
	public class NFiveSetVennUC : NExampleBaseUC
	{
		private System.ComponentModel.IContainer components = null;

		public NFiveSetVennUC()
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
			// NFiveSetVennUC
			// 
			this.Name = "NFiveSetVennUC";
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
			NLabel title = new NLabel("Five Set Venn");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// create a Venn series
			NVennSeries venn = (NVennSeries)chart.Series.Add(SeriesType.Venn);

			FiveSetVenn(venn);
			FiveSetVennLabels(venn);
			FiveSetVennInteractivity(venn);

			// set a tooltip tool
			nChartControl1.Controller.Selection.Add(chart);
			nChartControl1.Controller.Tools.Add(new NTooltipTool());

			// apply layout
			ConfigureStandardLayout(chart, title, null);
		}

		void FiveSetVenn(NVennSeries venn)
		{
			const int nSetCount = 5;
			const float fStartAngle = -((float)Math.PI / 2);
			const float fScale = 7;
			const float fCenterX = 0;
			const float fCenterY = 0;
			float fIncrementAngle = (float)(2 * Math.PI / nSetCount);

			venn.ClearContours();

			for(int i = 0; i < nSetCount; i++)
			{
				float fAngle = fStartAngle + i * fIncrementAngle;
				float x = (float)Math.Round(fCenterX + Math.Cos(fAngle) * fScale, 1);
				float y = (float)Math.Round(fCenterY + Math.Sin(fAngle) * fScale, 1);

				float fVennAngle = Rad2Degree(fAngle - 2 * fIncrementAngle);
				venn.AddVennContour(VennShape.Ellipse, new NPointF(x, y), new NSizeF(70, 35), fVennAngle, i);
			}
		}
		void FiveSetVennLabels(NVennSeries venn)
		{
			const int nCount = 5;
			string[] s1 = new string[]{ "A", "B", "C", "D", "E" };
			string[] s2 = new string[]{ "AC", "BD", "CE", "DA", "EB" };
			string[] s3 = new string[]{ "ABCD", "BCDE", "CDEA", "DEAB", "EABC" };

			venn.ClearLabels();
			venn.LabelsTextStyle.FontStyle = new NFontStyle("Verdana", 8);

			// add the center label
			venn.AddLabel("ABCDE", new NPointF(0, 0));

			// add layer 1 labels, angle is in radians
			NPointF[] points = CalculateLabelPositions(nCount, 35, -1.1f  );
			for(int i = 0; i < nCount; i++)
			{
				venn.AddLabel(s1[i], points[i]);
			}

			// add layer 2 labels, angle is in radians
			points = CalculateLabelPositions(nCount, 25, -1.3f);
			for(int i = 0; i < nCount; i++)
			{
				venn.AddLabel(s2[i], points[i]);
			}

			// add layer 4 labels, angle is in radians
			points = CalculateLabelPositions(nCount, 17.5f, -0.5f);
			for(int i = 0; i < nCount; i++)
			{
				venn.AddLabel(s3[i], points[i]);
			}
		}
		void FiveSetVennInteractivity(NVennSeries venn)
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

			arrContourIds = new int[]{3};
			interactivity = new NInteractivityStyle();
			interactivity.Tooltip.Text = "Segment D";
			venn.SetInteractivityForSegment(arrContourIds, interactivity);

			arrContourIds = new int[]{4};
			interactivity = new NInteractivityStyle();
			interactivity.Tooltip.Text = "Segment E";
			venn.SetInteractivityForSegment(arrContourIds, interactivity);

			arrContourIds = new int[]{0, 1, 2, 3, 4};
			interactivity = new NInteractivityStyle();
			interactivity.Tooltip.Text = "Segment ABCDE";
			venn.SetInteractivityForSegment(arrContourIds, interactivity);
		}

		NPointF[] CalculateLabelPositions(int nSetCount, float fRadius, float fStartAngleInRadians)
		{
			float fIncrementAngle = (float)(2 * Math.PI / nSetCount);
			float fCenterX = 0;
			float fCenterY = 0;

			NPointF[] points = new NPointF[nSetCount];

			for(int i = 0; i < nSetCount; i++)
			{
				float fAngle = fStartAngleInRadians + i * fIncrementAngle;
				float x = (float)Math.Round(fCenterX + Math.Cos(fAngle) * fRadius, 1);
				float y = (float)Math.Round(fCenterY + Math.Sin(fAngle) * fRadius, 1);

				points[i] = new NPointF(x, y);
			}

			return points;
		}

		float Rad2Degree(float fRadians)
		{
			return (float)(((fRadians) * 180.0f) / (3.1415926535f));
		}
	}
}

