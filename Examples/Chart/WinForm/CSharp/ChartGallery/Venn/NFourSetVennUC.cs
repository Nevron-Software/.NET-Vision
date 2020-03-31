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
	public class NFourSetVennUC : NExampleBaseUC
	{
		private System.ComponentModel.IContainer components = null;

		public NFourSetVennUC()
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
			// NFourSetVennUC
			// 
			this.Name = "NFourSetVennUC";
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
			NLabel title = new NLabel("Four Set Venn");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// create a Venn series
			NVennSeries venn = (NVennSeries)chart.Series.Add(SeriesType.Venn);

			FourSetVenn(venn);
			FourSetVennLabels(venn);
			FourSetVennInteractivity(venn);

			// set a tooltip tool
			nChartControl1.Controller.Selection.Add(chart);
			nChartControl1.Controller.Tools.Add(new NTooltipTool());

			// apply layout
			ConfigureStandardLayout(chart, title, null);
		}

		void FourSetVenn(NVennSeries venn)
		{
			venn.ClearContours();

			venn.AddVennContour(VennShape.Ellipse, new NPointF(-12.5f, -10f), new NSizeF(60, 35), 135, 0);
			venn.AddVennContour(VennShape.Ellipse, new NPointF(12.5f, -10f), new NSizeF(60, 35), 45, 1);
			venn.AddVennContour(VennShape.Ellipse, new NPointF(-2.5f, 5), new NSizeF(60, 35), 135, 2);
			venn.AddVennContour(VennShape.Ellipse, new NPointF(2.5f, 5), new NSizeF(60, 35), 45, 3);
		}
		void FourSetVennLabels(NVennSeries venn)
		{
			string centreLabel = "ABCD";
			string[] s1 = new string[]{ "A", "B", "C", "D" };
			string[] s2 = new string[]{ "AC", "CD", "BD", "AD", "AB", "BC" };
			string[] s3 = new string[]{ "ACD", "BCD", "ABD", "ABC"};

			venn.ClearLabels();
			venn.LabelsTextStyle.FontStyle = new NFontStyle("Verdana", 8);

			// add centre label
			venn.AddLabel(centreLabel, new NPointF(0, -8));

			// add layer 1 labels
			venn.AddLabel(s1[0], new NPointF(-12.5f - 15f, -10f + 10f));
			venn.AddLabel(s1[1], new NPointF(12.5f + 15f, -10f + 10f));
			venn.AddLabel(s1[2], new NPointF(-2.5f - 15f, 5f + 16f));
			venn.AddLabel(s1[3], new NPointF(2.5f + 15f, 5f + 16f));

			// add layer 2 labels
			venn.AddLabel(s2[0], new NPointF(-12.5f - 9f, -10f + 19f));
			venn.AddLabel(s2[1], new NPointF(0, -10f + 24f));
			venn.AddLabel(s2[2], new NPointF(12.5f + 9f, -10f + 19f));
			venn.AddLabel(s2[3], new NPointF(2.5f - 18f, 5f - 18f));
			venn.AddLabel(s2[4], new NPointF(0, -10f - 16f));
			venn.AddLabel(s2[5], new NPointF(-2.5f + 18f, 5f - 18f));

			// add layer 3 labels
			venn.AddLabel(s3[0], new NPointF(-12.5f + 1f, -10f + 10f));
			venn.AddLabel(s3[1], new NPointF(12.5f - 1f, -10f + 10f));
			venn.AddLabel(s3[2], new NPointF(2.5f - 10f, 5f - 21.5f));
			venn.AddLabel(s3[3], new NPointF(-2.5f + 10f, 5f - 21.5f));
		}
		void FourSetVennInteractivity(NVennSeries venn)
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

			arrContourIds = new int[]{0, 1, 2, 3};
			interactivity = new NInteractivityStyle();
			interactivity.Tooltip.Text = "Segment ABCD";
			venn.SetInteractivityForSegment(arrContourIds, interactivity);
		}
	}
}

