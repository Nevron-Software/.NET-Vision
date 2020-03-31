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
	public class NTwoSetVennUC : NExampleBaseUC
	{
		private System.ComponentModel.IContainer components = null;

		public NTwoSetVennUC()
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
			// NTwoSetVennUC
			// 
			this.Name = "NTwoSetVennUC";
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
			NLabel title = new NLabel("Two Set Venn");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// create a Venn series
			NVennSeries venn = (NVennSeries)chart.Series.Add(SeriesType.Venn);

			TwoSetVenn(venn);
			TwoSetVennLabels(venn);
			TwoSetVennInteractivity(venn);

			// set a tooltip tool
			nChartControl1.Controller.Selection.Add(chart);
			nChartControl1.Controller.Tools.Add(new NTooltipTool());

			// apply layout
			ConfigureStandardLayout(chart, title, null);
		}

		void TwoSetVenn(NVennSeries venn)
		{
			venn.ClearContours();

			venn.AddVennContour(VennShape.Ellipse, new NPointF(-15, 0), new NSizeF(50, 50), 0, 0);
			venn.AddVennContour(VennShape.Ellipse, new NPointF(15, 0), new NSizeF(50, 50), 0, 1);
		}

		void TwoSetVennLabels(NVennSeries venn)
		{
			string[] s1 = new string[]{ "A", "AB", "B"};

			venn.ClearLabels();
			venn.LabelsTextStyle.FontStyle = new NFontStyle("Verdana", 8);

			// add labels
			venn.AddLabel(s1[0], new NPointF(-25, 0));
			venn.AddLabel(s1[1], new NPointF(0, 0));
			venn.AddLabel(s1[2], new NPointF(25, 0));
		}

		void TwoSetVennInteractivity(NVennSeries venn)
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

			arrContourIds = new int[]{0, 1};
			interactivity = new NInteractivityStyle();
			interactivity.Tooltip.Text = "Segment AB";
			venn.SetInteractivityForSegment(arrContourIds, interactivity);
		}
	}
}

