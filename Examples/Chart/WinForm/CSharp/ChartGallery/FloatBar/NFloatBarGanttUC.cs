using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.Dom;
using Nevron.GraphicsCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NFloatBarGanttUC : NExampleBaseUC
	{
		private UI.WinForm.Controls.NCheckBox ShowGanttConnectorLinesCheckBox;
		private System.ComponentModel.Container components = null;

		public NFloatBarGanttUC()
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
			this.ShowGanttConnectorLinesCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// ShowGanttConnectorLinesCheckBox
			// 
			this.ShowGanttConnectorLinesCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowGanttConnectorLinesCheckBox.Location = new System.Drawing.Point(0, 0);
			this.ShowGanttConnectorLinesCheckBox.Name = "ShowGanttConnectorLinesCheckBox";
			this.ShowGanttConnectorLinesCheckBox.Size = new System.Drawing.Size(163, 21);
			this.ShowGanttConnectorLinesCheckBox.TabIndex = 14;
			this.ShowGanttConnectorLinesCheckBox.Text = "Show Gantt Connector Lines";
			this.ShowGanttConnectorLinesCheckBox.CheckedChanged += new System.EventHandler(this.ShowGanttConnectorLinesCheckBox_CheckedChanged);
			// 
			// NFloatBarGanntUC
			// 
			this.Controls.Add(this.ShowGanttConnectorLinesCheckBox);
			this.Name = "NFloatBarGanntUC";
			this.Size = new System.Drawing.Size(180, 86);
			this.ResumeLayout(false);

		}
		#endregion

		class Task
		{
			public Task(string label, DateTime begin, DateTime end, uint[] nextTasks)
			{
				Begin = begin;
				End = end;
				Label = label;
				NextTasks = nextTasks;
			}

			public int Index;
			public string Label;
			public DateTime Begin;
			public DateTime End;

			public uint[] NextTasks;
		}

		class TaskCollection
		{
			public TaskCollection()
			{
				m_Tasks = new List<Task>();
			}
			public void Add(Task task)
			{
				task.Index = m_Tasks.Count - 1;
				m_Tasks.Add(task);
			}

			public void ConfigureChart(NCartesianChart chart)
			{
				NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
				ordinalScale.MajorTickMode = MajorTickMode.CustomStep;
				ordinalScale.LabelStyle.ContentAlignment = ContentAlignment.TopCenter;
				ordinalScale.CustomStep = 1;
				ordinalScale.AutoLabels = false;

				NFloatBarSeries floatBar = new NFloatBarSeries();
				floatBar.DataLabelStyle.Visible = false;
				floatBar.WidthPercent = 50;
				chart.Series.Add(floatBar);

				for (int i = 0; i < m_Tasks.Count; i++)
				{
					Task task = m_Tasks[i];

					ordinalScale.Labels.Add(task.Label);
					floatBar.BeginValues.Add(task.Begin.ToOADate());
					floatBar.EndValues.Add(task.End.ToOADate());

					if (task.NextTasks != null)
					{
						floatBar.NextTasks.Add(i, task.NextTasks);
					}
				}
			}

			List<Task> m_Tasks;
		}


		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("Gantt Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;
			chart.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalLeft);
			chart.Axis(StandardAxis.Depth).Visible = false;

			// setup the value axis
			NRangeTimelineScaleConfigurator dateTimeScale = new NRangeTimelineScaleConfigurator();
			dateTimeScale.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back };

			// add interlaced stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back };
			stripStyle.Interlaced = true;
			dateTimeScale.StripStyles.Add(stripStyle);

			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = dateTimeScale;
			chart.Axis(StandardAxis.PrimaryY).Anchor = new NDockAxisAnchor(AxisDockZone.FrontRight, true, 0, 100);

			// fill data
			DateTime start = DateTime.Now;
			DateTime end = start + new TimeSpan(10, 0, 0, 0);

			TaskCollection tasks = new TaskCollection();
			tasks.Add(new Task("Write Proposal",
										new DateTime(2001, 4, 1),
										new DateTime(2001, 4, 5), 
										new uint[] { 1, 2 } ));

			tasks.Add(new Task("Obtain Approval",
								new DateTime(2001, 4, 12),
								new DateTime(2001, 9, 4),
								new uint[] { 9 }));

			tasks.Add(new Task("Requirements Analysis",
								new DateTime(2001, 4, 9),
								new DateTime(2001, 5, 5),
								new uint[] { 3 }));

			tasks.Add(new Task("Design Phase",
								new DateTime(2001, 5, 6),
								new DateTime(2001, 5, 30),
								new uint[] { 4 }));

			tasks.Add(new Task("Design Signoff",
								new DateTime(2001, 6, 2),
								new DateTime(2001, 6, 2),
								new uint[] { 5 }));

			tasks.Add(new Task("Alpha Implementation",
								new DateTime(2001, 6, 3),
								new DateTime(2001, 7, 31),
								new uint[] { 6 }));

			tasks.Add(new Task("Design Review",
								new DateTime(2001, 8, 1),
								new DateTime(2001, 8, 8),
								new uint[] { 7 }));

			tasks.Add(new Task("Revised Design Signoff",
								new DateTime(2001, 8, 10),
								new DateTime(2001, 8, 10),
								new uint[] { 8 }));

			tasks.Add(new Task("Beta Implementation",
								new DateTime(2001, 8, 12),
								new DateTime(2001, 9, 12),
								new uint[] { 9 }));

			tasks.Add(new Task("Testing",
								new DateTime(2001, 9, 13),
								new DateTime(2001, 10, 31),
								new uint[] { 10 }));

			tasks.Add(new Task("Final Implementation",
								new DateTime(2001, 11, 1),
								new DateTime(2001, 11, 15),
								new uint[] { 11 }));

			tasks.Add(new Task("Signoff",
								new DateTime(2001, 11, 28),
								new DateTime(2001, 11, 30),
								new uint[] { 12 }));

			tasks.ConfigureChart(chart);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NFloatBarDragPointTool());

			// init form controls
			ShowGanttConnectorLinesCheckBox.Checked = true;
		}

		private void ShowGanttConnectorLinesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			NFloatBarSeries floatBar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			floatBar.ShowGanttConnectorLines = ShowGanttConnectorLinesCheckBox.Checked;
			nChartControl1.Refresh();
		}
	}
}