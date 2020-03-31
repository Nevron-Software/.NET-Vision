using System;
using System.Collections;
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
	public class NCustomScaleDecorations2UC : NExampleBaseUC
	{
		private System.ComponentModel.Container components = null;

		public NCustomScaleDecorations2UC()
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
            // NCustomScaleDecorations2UC
            // 
            this.Name = "NCustomScaleDecorations2UC";
            this.Size = new System.Drawing.Size(201, 495);
            this.ResumeLayout(false);

		}
		#endregion


        struct NLabelInfo
        {
            #region Constructors

            public NLabelInfo(double value, string text, Color foreColor, Color backColor)
            {
                Value = value;
                Text = text;
                ForeColor = foreColor;
                BackColor = backColor;
            }

            #endregion

            #region Fields

            public double Value;
            public string Text;
            public Color ForeColor;
            public Color BackColor;

            #endregion
        }

		public override void Initialize()
		{
			base.Initialize();

   		    nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Custom Scale Decorations");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.SendToBack();
			title.Margins = new NMarginsL(20, 10, 20, 20);
			title.DockMode = PanelDockMode.Top;

			NCartesianChart chart = new NCartesianChart();
			nChartControl1.Panels.Add(chart);
			chart.BoundsMode = BoundsMode.Stretch;
			chart.DockMode = PanelDockMode.Fill;
			chart.Margins = new NMarginsL(20, 2, 20, 20);
			chart.BackgroundFillStyle = new NColorFillStyle(Color.FromArgb(231, 231, 233));
			chart.MaxDockZoneMargins = new NMarginsL(100000, 100000, 100000, 100000);

			NStrokeBorderStyle strokeBorder = new NStrokeBorderStyle();
			strokeBorder.StrokeStyle.Color = Color.FromArgb(192, 192, 192);
			chart.BorderStyle =strokeBorder;

            int dpCount = 8;
            double[] bar1Values = new double[dpCount];
            double[] bar2Values = new double[dpCount];
            NLabelInfo[] xLabels = new NLabelInfo[dpCount];

            // add some dummy data
            Random rand = new Random();
            for (int i = 0; i < dpCount; i++)
            {
                bar1Values[i] = rand.Next(100);
                bar2Values[i] = rand.Next(100);
                xLabels[i] = new NLabelInfo(i, "Label" + i.ToString(), Color.FromArgb(100, 100, 100), i % 2 == 0 ? Color.Red : Color.Orange);
            }

            NLabelInfo[] yLabels = new NLabelInfo[9];
            for (int i = 0; i < 9; i++)
            {
                yLabels[i].Text = ((i + 1) * 10).ToString() + "%";
                yLabels[i].Value = (i + 1) * 10;
                yLabels[i].ForeColor = Color.FromArgb(100, 100, 100);
                yLabels[i].BackColor = Color.Transparent;
            }

			// add two bars series in cluster mode
			NBarSeries bar1 = new NBarSeries();
			bar1.Values.AddRange(bar1Values);
			bar1.DataLabelStyle.Visible = false;
			bar1.MultiBarMode = MultiBarMode.Clustered;
			bar1.FillStyle = new NColorFillStyle(Color.FromArgb(21, 153, 215));
			bar1.FillStyle.ImageFiltersStyle.Filters.Add(new NBevelAndEmbossImageFilter());
			bar1.WidthPercent = 50;
			bar1.GapPercent = 20;
			chart.Series.Add(bar1);

			NBarSeries bar2 = new NBarSeries();
			bar2.Values.AddRange(bar2Values);
			bar2.DataLabelStyle.Visible = false;
			bar2.MultiBarMode = MultiBarMode.Clustered;
			bar2.FillStyle = new NColorFillStyle(Color.FromArgb(113, 127, 138));
			bar2.FillStyle.ImageFiltersStyle.Filters.Add(new NBevelAndEmbossImageFilter());
			bar2.WidthPercent = 50;
			bar2.GapPercent = 20;
			chart.Series.Add(bar2);

			// add custom labels to the x axis
			NLinearScaleConfigurator xScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale;
			chart.Axis(StandardAxis.PrimaryX).View = new NRangeAxisView(new NRange1DD(-0.5, xLabels.Length - 0.5), true, true);
			xScale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.FromArgb(100, 100, 100));
			xScale.AutoLabels = false;
			xScale.OuterMajorTickStyle.Visible = false;
			xScale.InnerMajorTickStyle.Visible = false;
			xScale.LabelStyle.Offset = new NLength(10);
			xScale.RulerStyle.BorderStyle.Width = new NLength(0);
			xScale.RulerStyle.Height = new NLength(0);

			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(240, 240, 240)), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			xScale.StripStyles.Add(stripStyle);

			// hide the back wall
			chart.Wall(ChartWallType.Back).Visible = false;

			// configure the Y axis
			chart.Axis(StandardAxis.PrimaryY).View = new NRangeAxisView(new NRange1DD(0, 100), true, true);
			NLinearScaleConfigurator yScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator; 
			yScale.AutoLabels  = false;
			yScale.MajorTickMode = MajorTickMode.CustomTicks;
			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			yScale.MajorGridStyle.LineStyle.Color = Color.FromArgb(192, 192, 192);
			yScale.OuterMajorTickStyle.Visible = false;
			yScale.InnerMajorTickStyle.Visible = false;
			yScale.RulerStyle.BorderStyle.Width = new NLength(0);
			yScale.RulerStyle.Height = new NLength(0);
			yScale.CreateNewLevelForCustomLabels = true;

			// add labels 
			NAxis xAxis = chart.Axis(StandardAxis.PrimaryX);
			NAxis yAxis = chart.Axis(StandardAxis.PrimaryY);

			AddLabels(xAxis, true, xLabels);
			AddLabels(yAxis, true, yLabels);

			// create cross
			NCustomWallDecorator xDecorator = new NCustomWallDecorator();
			xDecorator.WallDecorations.Add(new NGridLine(-0.5, new NStrokeStyle(Color.FromArgb(190, 190, 190)), new ChartWallType[] { ChartWallType.Back }, true));
			xAxis.Scale.WallDecorators.Add(xDecorator);

			NCustomWallDecorator yDecorator = new NCustomWallDecorator();
			yDecorator.WallDecorations.Add(new NGridLine(0, new NStrokeStyle(Color.FromArgb(190, 190, 190)), new ChartWallType[] { ChartWallType.Back }, true));
			yAxis.Scale.WallDecorators.Add(yDecorator);			
		}

        private static void AddLabels(NAxis axis, bool addTicks, NLabelInfo[] labels)
		{
			// First add custom labels
			NLinearScaleConfigurator scale = axis.ScaleConfigurator as NLinearScaleConfigurator;

			for (int i = 0; i < labels.Length; i++)
			{
				NLabelInfo labelInfo = labels[i];

				NCustomValueLabel label = new NCustomValueLabel();
				label.Value = labelInfo.Value;
				label.Text = labelInfo.Text;
				label.Style.Offset = new NLength(10);
				label.Style.TextStyle.FillStyle = new NColorFillStyle(labelInfo.ForeColor);

				scale.CustomLabels.Add(label);

				if (addTicks)
				{
					scale.CustomMajorTicks.Add(labelInfo.Value - 0.5);
				}
			}

			axis.UpdateScale();

			// then add background coloring
			NScaleLevel level = (NScaleLevel)axis.Scale.Levels[axis.Scale.Levels.Count - 1];

			level.TopPadding = new NLength(-1);

			NScaleLevel rulerLevel = (NScaleLevel)axis.Scale.Levels[0];
			rulerLevel.TopPadding = new NLength(0);
			rulerLevel.BottomPadding = new NLength(0);
			NCustomScaleDecorator scaleDecorator = new NCustomScaleDecorator();

			for (int i = 0; i < labels.Length ; i++)
			{
				NLabelInfo labelInfo = labels[i];

				if (labelInfo.BackColor != Color.Transparent)
				{
					scaleDecorator.Decorations.Add(new NScaleRange(0, new NScaleRangeDecorationAnchor(new NRange1DD(labelInfo.Value - 0.5, labelInfo.Value  + 0.5)), new NColorFillStyle(labelInfo.BackColor), new NLength(0), new NLength(20), new NLength(20)));
				}
			}

			level.Decorators.Add(scaleDecorator);
		}
	}
}