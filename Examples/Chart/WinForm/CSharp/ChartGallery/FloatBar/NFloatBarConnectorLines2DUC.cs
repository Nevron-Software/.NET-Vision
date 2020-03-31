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

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NFloatBarConnectorLines2DUC : NExampleBaseUC
	{
		private UI.WinForm.Controls.NButton ConnectorLinesStrokeButton;
		private UI.WinForm.Controls.NCheckBox ShowConnectorLinesCheckBox;
		private UI.WinForm.Controls.NButton GanttConnectLinesStrokeButton;
		private UI.WinForm.Controls.NCheckBox ShowGanttConnectorLinesCheckBox;
		private System.ComponentModel.Container components = null;

		public NFloatBarConnectorLines2DUC()
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
			this.ConnectorLinesStrokeButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ShowConnectorLinesCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.GanttConnectLinesStrokeButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ShowGanttConnectorLinesCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// ConnectorLinesStrokeButton
			// 
			this.ConnectorLinesStrokeButton.Location = new System.Drawing.Point(3, 33);
			this.ConnectorLinesStrokeButton.Name = "ConnectorLinesStrokeButton";
			this.ConnectorLinesStrokeButton.Size = new System.Drawing.Size(163, 24);
			this.ConnectorLinesStrokeButton.TabIndex = 10;
			this.ConnectorLinesStrokeButton.Text = "Connector Lines Stoke..";
			this.ConnectorLinesStrokeButton.Click += new System.EventHandler(this.ConnectorLinesStrokeButton_Click);
			// 
			// ShowConnectorLinesCheckBox
			// 
			this.ShowConnectorLinesCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowConnectorLinesCheckBox.Location = new System.Drawing.Point(3, 6);
			this.ShowConnectorLinesCheckBox.Name = "ShowConnectorLinesCheckBox";
			this.ShowConnectorLinesCheckBox.Size = new System.Drawing.Size(163, 21);
			this.ShowConnectorLinesCheckBox.TabIndex = 9;
			this.ShowConnectorLinesCheckBox.Text = "Show Connector Lines";
			this.ShowConnectorLinesCheckBox.CheckedChanged += new System.EventHandler(this.ShowConnectorLinesCheckBox_CheckedChanged);
			// 
			// GanntConnectLinesStrokeButton
			// 
			this.GanttConnectLinesStrokeButton.Location = new System.Drawing.Point(3, 100);
			this.GanttConnectLinesStrokeButton.Name = "GanttConnectLinesStrokeButton";
			this.GanttConnectLinesStrokeButton.Size = new System.Drawing.Size(163, 24);
			this.GanttConnectLinesStrokeButton.TabIndex = 12;
			this.GanttConnectLinesStrokeButton.Text = "Gantt Connector Lines Stoke..";
			this.GanttConnectLinesStrokeButton.Click += new System.EventHandler(this.GanntConnectLinesStrokeButton_Click);
			// 
			// ShowGanttConnectorLinesCheckBox
			// 
			this.ShowGanttConnectorLinesCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowGanttConnectorLinesCheckBox.Location = new System.Drawing.Point(3, 73);
			this.ShowGanttConnectorLinesCheckBox.Name = "ShowGanttConnectorLinesCheckBox";
			this.ShowGanttConnectorLinesCheckBox.Size = new System.Drawing.Size(163, 21);
			this.ShowGanttConnectorLinesCheckBox.TabIndex = 11;
			this.ShowGanttConnectorLinesCheckBox.Text = "Show Gantt Connector Lines";
			this.ShowGanttConnectorLinesCheckBox.CheckedChanged += new System.EventHandler(this.ShowGanttConnectorLinesCheckBox_CheckedChanged);
			// 
			// NFloatBarConnectorLines2DUC
			// 
			this.Controls.Add(this.GanttConnectLinesStrokeButton);
			this.Controls.Add(this.ShowGanttConnectorLinesCheckBox);
			this.Controls.Add(this.ConnectorLinesStrokeButton);
			this.Controls.Add(this.ShowConnectorLinesCheckBox);
			this.Name = "NFloatBarConnectorLines2DUC";
			this.Size = new System.Drawing.Size(180, 305);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Float Bar Connector Lines");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.Depth).Visible = false;

			// setup X axis
			NOrdinalScaleConfigurator scaleX = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			scaleX.AutoLabels = false;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleX.DisplayDataPointsBetweenTicks = false;
			for (int i = 0; i < monthLetters.Length; i++)
			{
				scaleX.CustomLabels.Add(new NCustomValueLabel(i, monthLetters[i]));
			}

			// add interlaced stripe to the Y axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
			stripStyle.Interlaced = true;
			linearScale.StripStyles.Add(stripStyle);

			// create the float bar series
			NFloatBarSeries floatBar = (NFloatBarSeries)chart.Series.Add(SeriesType.FloatBar);
			floatBar.DataLabelStyle.Visible = false;
			floatBar.DataLabelStyle.VertAlign = VertAlign.Center;
			floatBar.DataLabelStyle.Format = "<begin> - <end>";

			// add bars
			floatBar.AddDataPoint(new NFloatBarDataPoint(2, 10));
			floatBar.NextTasks.Add(0, new uint[] { 1 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(5, 16));
			floatBar.NextTasks.Add(1, new uint[] { 2 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(9, 17));
			floatBar.NextTasks.Add(2, new uint[] { 3 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(12, 21));
			floatBar.NextTasks.Add(3, new uint[] { 4 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(8, 18));
			floatBar.NextTasks.Add(4, new uint[] { 5 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(7, 18));
			floatBar.NextTasks.Add(5, new uint[] { 6 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(3, 11));
			floatBar.NextTasks.Add(6, new uint[] { 7 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(5, 12));
			floatBar.NextTasks.Add(7, new uint[] { 8 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(8, 17));
			floatBar.NextTasks.Add(8, new uint[] { 9 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(6, 15));
			floatBar.NextTasks.Add(9, new uint[] { 10 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(3, 10));
			floatBar.NextTasks.Add(10, new uint[] { 11 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(1, 7));

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			ShowConnectorLinesCheckBox.Checked = true;
		}
		private void ShowConnectorLinesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			NFloatBarSeries floatBar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			floatBar.ShowConnectorLines = ShowConnectorLinesCheckBox.Checked;
			nChartControl1.Refresh();
		}
		private void ConnectorLinesStrokeButton_Click(object sender, EventArgs e)
		{
			NFloatBarSeries floatBar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(floatBar.ConnectorLineStrokeStyle, out strokeStyleResult))
			{
				floatBar.ConnectorLineStrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void ShowGanttConnectorLinesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			NFloatBarSeries floatBar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			floatBar.ShowGanttConnectorLines = ShowGanttConnectorLinesCheckBox.Checked;
			nChartControl1.Refresh();
		}

		private void GanntConnectLinesStrokeButton_Click(object sender, EventArgs e)
		{
			NFloatBarSeries floatBar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(floatBar.GanttConnectorLineStrokeStyle, out strokeStyleResult))
			{
				floatBar.GanttConnectorLineStrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
	}
}
