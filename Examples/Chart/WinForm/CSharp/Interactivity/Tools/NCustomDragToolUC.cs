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
using Nevron.Dom;
using Nevron.Chart.WinForm;
using System.Collections.Generic;
using Nevron.Chart.Windows;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NCustomDragToolUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private System.ComponentModel.Container components = null;

		public NCustomDragToolUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
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
			// NCustomDragToolUC
			// 
			this.Name = "NCustomDragToolUC";
			this.Size = new System.Drawing.Size(180, 358);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Custom Drag Tool");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;

			// configure the x scale
			NLinearScaleConfigurator xScale = new NLinearScaleConfigurator();
			xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale;

			// configure the y scale
			NLinearScaleConfigurator yScale = new NLinearScaleConfigurator();

			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			yScale.StripStyles.Add(stripStyle);

			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = yScale;

			// Create a point series
			NPointSeries pnt = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);
			pnt.InflateMargins = true;
			pnt.UseXValues = true;
			pnt.Name = "Series 1";
			pnt.DataLabelStyle.Visible = false;

			// Add some data
			pnt.Values.Add(31);
			pnt.Values.Add(67);
			pnt.Values.Add(12);
			pnt.Values.Add(84);
			pnt.Values.Add(90);

			pnt.XValues.Add(5);
			pnt.XValues.Add(36);
			pnt.XValues.Add(51);
			pnt.XValues.Add(76);
			pnt.XValues.Add(93);

			// Add a constline for the left axis
			NAxisConstLine cl1 = m_Chart.Axis(StandardAxis.PrimaryY).ConstLines.Add();
			cl1.StrokeStyle.Color = Color.SteelBlue;
			cl1.StrokeStyle.Width = new NLength(1.5f);
			cl1.FillStyle = new NColorFillStyle(new NArgbColor(125, Color.SteelBlue));
			cl1.Text = "Press the left mouse key and start dragging";
			cl1.Value = 40;

			NAxisConstLine cl2 = m_Chart.Axis(StandardAxis.PrimaryY).ConstLines.Add();
			cl2.StrokeStyle.Color = Color.OrangeRed;
			cl2.StrokeStyle.Width = new NLength(1.5f);
			cl2.FillStyle = new NColorFillStyle(new NArgbColor(125, Color.SteelBlue));
			cl2.Text = "Press the left mouse key and start dragging";
			cl2.Value = 60;

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			nChartControl1.Refresh();

			nChartControl1.Controller.Tools.Add(new NSelectorTool());
			nChartControl1.Controller.Tools.Add(new MyCustomDragTool());
		}

		[Serializable]
		public class MyCustomDragTool : NDragTool
		{
			#region Constructors

			/// <summary>
			/// Creates a new NTrackballTool operation.
			/// </summary>
			/// <remarks>
			/// You must add the object to the InteractivityCollection of 
			/// the control in order to enable the trackball feature.
			/// </remarks>
			public MyCustomDragTool()
			{

			}

			#endregion

			#region Properties


			#endregion

			#region Overrides

			/// <summary>
			/// Return true if dragging can start
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			/// <returns></returns>
			public override bool CanBeginDrag(object sender, Nevron.Chart.Windows.NMouseEventArgs e)
			{
				object[] constLines = GetSelectedObjectsOfType(typeof(NAxisConstLine));

				if (constLines.Length == 0)
					return false;

				m_ConstLine = (NAxisConstLine)constLines[0];
				m_OrgValue = m_ConstLine.Value;

				return true;
			}
			/// <summary>
			/// Overriden to perform dragging
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			public override void OnDoDrag(object sender, NMouseEventArgs e)
			{
				NChart chart = this.GetDocument().Charts[0];
				NViewToScale2DTransformation viewToScale = new NViewToScale2DTransformation(this.GetView().Context, chart, (int)StandardAxis.PrimaryX, (int)StandardAxis.PrimaryY);

				NVector2DD pointScale = new NVector2DD();
				if (viewToScale.Transform(new NPointF(e.X, e.Y), ref pointScale))
				{
					// clamp y value to ruler range
					double yValue = chart.Axis(StandardAxis.PrimaryY).Scale.RulerRange.GetValueInRange(pointScale.Y);
					m_ConstLine.Value = yValue;

					chart.Refresh();
					Repaint();
				}
			}
			/// <summary>
			/// Overriden to rever the state to the original one if the user presses Esc key
			/// </summary>
			public override void CancelOperation()
			{
				base.CancelOperation();

				m_ConstLine.Value = m_OrgValue;
				Repaint(); 				
			}

			#endregion

			#region Fields

			protected NAxisConstLine m_ConstLine;
			protected double m_OrgValue;

			#endregion

			#region Default values

			#endregion
		}
	}
}
