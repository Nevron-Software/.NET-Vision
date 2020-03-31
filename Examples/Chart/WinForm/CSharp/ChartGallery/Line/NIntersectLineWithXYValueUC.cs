using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using System.Collections.Generic;
using Nevron.Chart.Windows;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NIntersectLineWithXYValueUC : NExampleBaseUC
	{
		NAxisCursor m_HorizontalAxisCursor;
		NAxisCursor m_VerticalAxisCursor;
		NLineSeries m_Line;
		NPointSeries m_Point;

		private System.ComponentModel.Container components = null;

		public NIntersectLineWithXYValueUC()
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
			// NIntersectLineWithXYValueUC
			// 
			this.Name = "NIntersectLineWithXYValueUC";
			this.Size = new System.Drawing.Size(180, 50);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// turn off the legend
			nChartControl1.Legends[0].Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Intersect Line with X/Y Value");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// configure the chart
			NChart m_Chart = nChartControl1.Charts[0];

			m_HorizontalAxisCursor = new NAxisCursor();
			m_HorizontalAxisCursor.BeginEndAxis = (int)StandardAxis.PrimaryY;
			m_HorizontalAxisCursor.ValueChanged += new EventHandler(OnAxisCursorValueChanged);

			m_VerticalAxisCursor = new NAxisCursor();
			m_VerticalAxisCursor.BeginEndAxis = (int)StandardAxis.PrimaryX;
			m_VerticalAxisCursor.ValueChanged += new EventHandler(OnAxisCursorValueChanged);

			m_Chart.Axis(StandardAxis.PrimaryX).Cursors.Add(m_HorizontalAxisCursor);
			m_Chart.Axis(StandardAxis.PrimaryY).Cursors.Add(m_VerticalAxisCursor);

			m_HorizontalAxisCursor.SynchronizeOnMouseAction |= MouseAction.Move;
			m_VerticalAxisCursor.SynchronizeOnMouseAction |= MouseAction.Move;

			// 2D line chart
			m_Chart.Series.Clear();
			m_Chart.BoundsMode = BoundsMode.Stretch;

			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = GetScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = GetScaleConfigurator();
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NAxisCollection axes = m_Chart.Axes;

			m_Chart.Location = new NPointL(
				  new NLength(10, NRelativeUnit.ParentPercentage),
				  new NLength(12, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(
				  new NLength(80, NRelativeUnit.ParentPercentage),
				  new NLength(78, NRelativeUnit.ParentPercentage));

			// add point series
			m_Point = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);
			m_Point.UseXValues = true;
			m_Point.FillStyle = new NColorFillStyle(Color.Red);
			m_Point.DataLabelStyle.Visible = false;
			m_Point.Size = new NLength(2);

			m_Line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line.Name = "Point 1";
			m_Line.FillStyle = new NColorFillStyle(Color.Red);
			m_Line.BorderStyle.Color = Color.Pink;
			m_Line.DataLabelStyle.Visible = false;
			m_Line.UseXValues = true;
			m_Line.InflateMargins = true;

			// fill with random data
			Random rand = new Random();
			double radius = 1000;
			double angle = 0;

			double rStep = 10;
			double aStep = 10;

			for (int i = 0; i < 1000; i++)
			{
				double y = Math.Sin(angle * 0.0174533f) * radius;
				double x = Math.Cos(angle * 0.0174533f) * radius;

				m_Line.XValues.Add(x);
				m_Line.Values.Add(y);

				radius += rStep;
				angle += aStep;
			}

			nChartControl1.Controller.Tools.Clear();
			nChartControl1.Controller.Selection.SelectedObjects.Add(m_Chart);
			nChartControl1.Controller.Tools.Add(new NDataCursorTool());
		}

		void OnAxisCursorValueChanged(object sender, EventArgs e)
		{
			m_Point.XValues.Clear();
			m_Point.Values.Clear();

			double xValue = m_HorizontalAxisCursor.Value;
			List<double> intersections = m_Line.IntersectWithXValue(xValue);

			for (int i = 0; i < intersections.Count; i++)
			{
				m_Point.XValues.Add(xValue);
				m_Point.Values.Add(intersections[i]);
			}

			double yValue = m_VerticalAxisCursor.Value;
			intersections = m_Line.IntersectWithYValue(yValue);

			for (int i = 0; i < intersections.Count; i++)
			{
				m_Point.XValues.Add(intersections[i]);
				m_Point.Values.Add(yValue);
			}

			nChartControl1.Refresh();
		}

		private NLinearScaleConfigurator GetScaleConfigurator()
		{
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();

			linearScale.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific);
			linearScale.MinorTickCount = 4;

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			return linearScale;
		}
	}
}
