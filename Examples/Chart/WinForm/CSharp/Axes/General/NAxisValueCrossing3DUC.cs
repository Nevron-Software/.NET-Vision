using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NAxisValueCrossing3DUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private UI.WinForm.Controls.NCheckBox ZUsePositionCheck;
		private UI.WinForm.Controls.NCheckBox YUsePositionCheck;
		private UI.WinForm.Controls.NCheckBox XUsePositionCheck;
		private System.ComponentModel.Container components = null;

		public NAxisValueCrossing3DUC()
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
			this.ZUsePositionCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.YUsePositionCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.XUsePositionCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// ZUsePositionCheck
			// 
			this.ZUsePositionCheck.ButtonProperties.BorderOffset = 2;
			this.ZUsePositionCheck.Location = new System.Drawing.Point(13, 68);
			this.ZUsePositionCheck.Name = "ZUsePositionCheck";
			this.ZUsePositionCheck.Size = new System.Drawing.Size(91, 21);
			this.ZUsePositionCheck.TabIndex = 14;
			this.ZUsePositionCheck.Text = "Z Use Position";
			this.ZUsePositionCheck.CheckedChanged += new System.EventHandler(this.ZUsePositionCheck_CheckedChanged);
			// 
			// YUsePositionCheck
			// 
			this.YUsePositionCheck.ButtonProperties.BorderOffset = 2;
			this.YUsePositionCheck.Location = new System.Drawing.Point(13, 41);
			this.YUsePositionCheck.Name = "YUsePositionCheck";
			this.YUsePositionCheck.Size = new System.Drawing.Size(91, 21);
			this.YUsePositionCheck.TabIndex = 13;
			this.YUsePositionCheck.Text = "Y Use Position";
			this.YUsePositionCheck.CheckedChanged += new System.EventHandler(this.YUsePositionCheck_CheckedChanged);
			// 
			// XUsePositionCheck
			// 
			this.XUsePositionCheck.ButtonProperties.BorderOffset = 2;
			this.XUsePositionCheck.Location = new System.Drawing.Point(13, 15);
			this.XUsePositionCheck.Name = "XUsePositionCheck";
			this.XUsePositionCheck.Size = new System.Drawing.Size(112, 20);
			this.XUsePositionCheck.TabIndex = 12;
			this.XUsePositionCheck.Text = "X Use Position";
			this.XUsePositionCheck.CheckedChanged += new System.EventHandler(this.XUsePositionCheck_CheckedChanged);
			// 
			// NAxisValueCrossing3DUC
			// 
			this.Controls.Add(this.ZUsePositionCheck);
			this.Controls.Add(this.YUsePositionCheck);
			this.Controls.Add(this.XUsePositionCheck);
			this.Name = "NAxisValueCrossing3DUC";
			this.Size = new System.Drawing.Size(191, 365);
			this.ResumeLayout(false);

		}
		#endregion


		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Axis Value Crossing <br/> <font size = '9pt'>Demonstrates how to use of the value cross anchor</font>");
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // turn off the legend
            nChartControl1.Legends[0].Mode = LegendMode.Disabled;

			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Width = m_Chart.Height = m_Chart.Depth = 50;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights);

			NAxis xAxis = m_Chart.Axis(StandardAxis.PrimaryX);
			NAxis yAxis = m_Chart.Axis(StandardAxis.PrimaryY);
			NAxis zAxis = m_Chart.Axis(StandardAxis.Depth);


			// cross X and Y axes
			xAxis.Anchor = new NCrossAxisAnchor(AxisOrientation.Horizontal);
			((NCrossAxisAnchor)xAxis.Anchor).Crossings.Add(new NValueAxisCrossing(yAxis, 0));
			((NCrossAxisAnchor)xAxis.Anchor).Crossings.Add(new NValueAxisCrossing(zAxis, 0));

			yAxis.Anchor = new NCrossAxisAnchor(AxisOrientation.Vertical);
			((NCrossAxisAnchor)yAxis.Anchor).Crossings.Add(new NValueAxisCrossing(xAxis, 0));
			((NCrossAxisAnchor)yAxis.Anchor).Crossings.Add(new NValueAxisCrossing(zAxis, 0));

			zAxis.Anchor = new NCrossAxisAnchor(AxisOrientation.Depth);
			((NCrossAxisAnchor)zAxis.Anchor).Crossings.Add(new NValueAxisCrossing(xAxis, 0));
			((NCrossAxisAnchor)zAxis.Anchor).Crossings.Add(new NValueAxisCrossing(yAxis, 0));

			m_Chart.Wall(ChartWallType.Back).Visible = false;
			m_Chart.Wall(ChartWallType.Floor).Visible = false;
			m_Chart.Wall(ChartWallType.Left).Visible = false;

			// setup bubble series
			NBubbleSeries bubble = (NBubbleSeries)m_Chart.Series.Add(SeriesType.Bubble);
			bubble.Name = "Bubble Series";
			bubble.InflateMargins = true;
			bubble.DataLabelStyle.Visible = false;
			bubble.UseXValues = true;
			bubble.UseZValues = true;
			bubble.BubbleShape = PointShape.Sphere;

			// fill with random data
			bubble.Values.FillRandomRange(Random, 10, -20, 20);
			bubble.XValues.FillRandomRange(Random, 10, -20, 20);
			bubble.ZValues.FillRandomRange(Random, 10, -20, 20);
			bubble.Sizes.FillRandomRange(Random, 10, 1, 6);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			XUsePositionCheck.Checked = true;
			YUsePositionCheck.Checked = true;
			ZUsePositionCheck.Checked = true;

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());
		}


		private void XUsePositionCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NAxis xAxis = m_Chart.Axis(StandardAxis.PrimaryX);

			if (XUsePositionCheck.Checked)
			{
				xAxis.Anchor = new NCrossAxisAnchor(AxisOrientation.Horizontal);
				((NCrossAxisAnchor)xAxis.Anchor).Crossings.Add(new NValueAxisCrossing(m_Chart.Axis(StandardAxis.PrimaryY), 0));
				((NCrossAxisAnchor)xAxis.Anchor).Crossings.Add(new NValueAxisCrossing(m_Chart.Axis(StandardAxis.Depth), 0));
			}
			else
			{
				xAxis.Anchor = new NDockAxisAnchor(AxisDockZone.FrontBottom, true);
			}

			nChartControl1.Refresh();
		}

		private void YUsePositionCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NAxis yAxis = m_Chart.Axis(StandardAxis.PrimaryY);

			if (YUsePositionCheck.Checked)
			{
				yAxis.Anchor = new NCrossAxisAnchor(AxisOrientation.Vertical);
				((NCrossAxisAnchor)yAxis.Anchor).Crossings.Add(new NValueAxisCrossing(m_Chart.Axis(StandardAxis.PrimaryX), 0));
				((NCrossAxisAnchor)yAxis.Anchor).Crossings.Add(new NValueAxisCrossing(m_Chart.Axis(StandardAxis.Depth), 0));
			}
			else
			{
				yAxis.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, true);
			}

			nChartControl1.Refresh();
		}

		private void ZUsePositionCheck_CheckedChanged(object sender, EventArgs e)
		{
			NAxis zAxis = m_Chart.Axis(StandardAxis.Depth);

			if (YUsePositionCheck.Checked)
			{
				zAxis.Anchor = new NCrossAxisAnchor(AxisOrientation.Depth);
				((NCrossAxisAnchor)zAxis.Anchor).Crossings.Add(new NValueAxisCrossing(m_Chart.Axis(StandardAxis.PrimaryY), 0));
				((NCrossAxisAnchor)zAxis.Anchor).Crossings.Add(new NValueAxisCrossing(m_Chart.Axis(StandardAxis.Depth), 0));
			}
			else
			{
				zAxis.Anchor = new NDockAxisAnchor(AxisDockZone.BottomRight, true);
			}

			nChartControl1.Refresh();
		}
	}
}