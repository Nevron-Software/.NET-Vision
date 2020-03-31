using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NMultipleAxesZoomingAndScrollingUC : NExampleBaseUC
	{
		private System.ComponentModel.Container components = null;

		public NMultipleAxesZoomingAndScrollingUC()
		{
			InitializeComponent();
		}

		/// <summary 
		/// Clean up any resources being used.
		/// </summary
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
		/// <summary 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // NMultipleAxesZoomingAndScrollingUC
            // 
            this.Name = "NMultipleAxesZoomingAndScrollingUC";
            this.Size = new System.Drawing.Size(180, 664);
            this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Multiple Axes Zooming and Scrolling");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            title.ContentAlignment = ContentAlignment.BottomCenter;
            title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // configure chart
            NCartesianChart chart = (NCartesianChart)(nChartControl1.Charts[0]);
            chart.RangeSelections.Add(new NRangeSelection());

            // 2D line chart
            chart.BoundsMode = BoundsMode.Stretch;

            // configure axis paging and set a mimimum range length on the axisthis will prevent the user from zooming too much
            chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true;

            NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Fresh);
            Color color1 = palette.SeriesColors[0];
            Color color2 = palette.SeriesColors[3];

            NAxis primaryY = chart.Axis(StandardAxis.PrimaryY);
            primaryY.ScaleConfigurator.Title.Text = "Primary Y Axis";
            ApplyColorToAxis(primaryY, color1);
            primaryY.ScrollBar.Visible = true;
            primaryY.Scale.RulerRangeChanged += new EventHandler(Scale_RulerRangeChanged);

            NAxis secondaryY = chart.Axis(StandardAxis.SecondaryY);
            secondaryY.ScaleConfigurator.Title.Text = "Secondary Y Axis";
            ApplyColorToAxis(secondaryY, color2);
            secondaryY.Visible = true;
            
            NLineSeries line1 = new NLineSeries();
            line1.BorderStyle.Color = color1;
            line1.BorderStyle.Width = new NLength(2);
            chart.Series.Add(line1);

            line1.DataLabelStyle.Visible = false;

            NLineSeries line2 = new NLineSeries();
            line2.BorderStyle.Color = color2;
            line2.BorderStyle.Width = new NLength(2);
            chart.Series.Add(line2);

            line2.DataLabelStyle.Visible = false;
            line2.DisplayOnAxis(StandardAxis.PrimaryY, false);
            line2.DisplayOnAxis(StandardAxis.SecondaryY, true);

            for (int i = 0; i < 720; i++)
            {
                double angle = i * NMath.Degree2Rad;

                double value1 = Math.Sin(angle);
                double value2 = Math.Sin(angle + 40) * 100;

                line1.Values.Add(value1);
                line2.Values.Add(value2);
            }

            nChartControl1.Controller.Tools.Add(new NSelectorTool());
            nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
            nChartControl1.Controller.Tools.Add(new NDataZoomTool());
            nChartControl1.Controller.Tools.Add(new NDataPanTool());
		}

        void ApplyColorToAxis(NAxis axis, Color color)
        {
            NLinearScaleConfigurator scale = (NLinearScaleConfigurator)axis.ScaleConfigurator;

            scale.InnerMajorTickStyle.LineStyle.Color = color;
            scale.InnerMinorTickStyle.LineStyle.Color = color;
            scale.OuterMajorTickStyle.LineStyle.Color = color;
            scale.OuterMinorTickStyle.LineStyle.Color = color;
            scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(color);
            scale.Title.TextStyle.FillStyle = new NColorFillStyle(color);
            scale.RulerStyle.BorderStyle.Color = color;
        }

        void Scale_RulerRangeChanged(object sender, EventArgs e)
 		{
 			NChart chart = nChartControl1.Charts[0];

            NRange1DD contentRange = chart.Axis(StandardAxis.PrimaryY).ContentRange;
 			NRange1DD viewRange = chart.Axis(StandardAxis.PrimaryY).Scale.RulerRange;

 			// compute factors
 			double beginFactor = contentRange.GetValueFactor(viewRange.Begin);
 			double endFactor = contentRange.GetValueFactor(viewRange.End);

 			// then for all other y axes make sure their view range factor equals to begin/end factor
 			if (beginFactor == 0.0 && endFactor == 1.0)
 			{
 				// disable zoom
 				foreach (NAxis axis in chart.Axes)
 				{
 					if (axis.AxisId != (int)StandardAxis.PrimaryY && axis.AxisOrientation == AxisOrientation.Vertical)
 					{
 						axis.PagingView.Enabled = false;
 					}
 				}
 			}
 			else
 			{
 				// disable zoom
 				foreach (NAxis axis in chart.Axes)
 				{
 					if ((axis.AxisId != (int)StandardAxis.PrimaryY) && (axis.AxisOrientation == AxisOrientation.Vertical))
 					{
 						axis.PagingView.Enabled = true;

 						// compute the new range based on factor
 						NRange1DD axisContentRange = axis.ContentRange;
 						double rangeLength = axisContentRange.End - axisContentRange.Begin;

 						double begin = axisContentRange.Begin + beginFactor * rangeLength;
 						double end = axisContentRange.Begin + endFactor * rangeLength;

 						axis.PagingView.ZoomIn(new NRange1DD(begin, end), 0.0001);
 					}
 				}
 			}

 			nChartControl1.Refresh();
 		}
	}
}
