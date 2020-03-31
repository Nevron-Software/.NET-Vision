using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NAxisStripLinesUC : NExampleBaseUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox HighLightRangeComboBox;
		private NChart m_Chart;

		public NAxisStripLinesUC()
		{
			// This call is required by the Windows.Forms Form Designer.
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
			this.label1 = new System.Windows.Forms.Label();
			this.HighLightRangeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Highlight Range:";
			// 
			// HighLightRangeComboBox
			// 
			this.HighLightRangeComboBox.Location = new System.Drawing.Point(8, 40);
			this.HighLightRangeComboBox.Name = "HighLightRangeComboBox";
			this.HighLightRangeComboBox.Size = new System.Drawing.Size(136, 21);
			this.HighLightRangeComboBox.TabIndex = 1;
			this.HighLightRangeComboBox.Text = "comboBox1";
			this.HighLightRangeComboBox.SelectedIndexChanged += new System.EventHandler(this.HighLightRangeComboBox_SelectedIndexChanged);
			// 
			// NAxisStripLinesUC
			// 
			this.Controls.Add(this.HighLightRangeComboBox);
			this.Controls.Add(this.label1);
			this.Name = "NAxisStripLinesUC";
			this.Size = new System.Drawing.Size(150, 328);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Strip Lines");
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;

			// Add a line series
			NLineSeries line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			line.UseXValues = true;
			line.BorderStyle.Color = Color.DarkRed;
			line.DataLabelStyle.Visible = false;
			line.InflateMargins = true;
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.MarkerStyle.Width = new NLength(2, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Height = new NLength(2, NRelativeUnit.ParentPercentage);

			// create a date time scale
			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();

			dateTimeScale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 90);
			dateTimeScale.LabelStyle.ContentAlignment = ContentAlignment.MiddleLeft; 
			dateTimeScale.EnableUnitSensitiveFormatting = false;
			dateTimeScale.MajorTickMode = MajorTickMode.CustomStep;
			dateTimeScale.CustomStep = new NDateTimeSpan(1, NDateTimeUnit.Day);
			dateTimeScale.LabelValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.WeekDayShortName);

			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale;

			// create a strip line highlighting the working days
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 2, 5);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);

			NDateTimeRangeSamplerProvider provider = new NDateTimeRangeSamplerProvider();
			provider.SamplingMode = SamplingMode.CustomStep;
			provider.UseOrigin = true;
			provider.Origin = new DateTime(2007, 2, 19);
			provider.CustomStep = new NDateTimeSpan(1, NDateTimeUnit.Day);
			stripStyle.RangeSamplerProvider = provider;

			// configure the x axis to use date time paging 
			NDateTimeAxisPagingView dateTimePagingView = new NDateTimeAxisPagingView(DateTime.Now, new NDateTimeSpan(10, NDateTimeUnit.Day));
			dateTimePagingView.Enabled = true;
			m_Chart.Axis(StandardAxis.PrimaryX).PagingView = dateTimePagingView;
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true;
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.ResetButton.Visible = false;
			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			HighLightRangeComboBox.Items.Add("Weekdays");
			HighLightRangeComboBox.Items.Add("Weekends");
			HighLightRangeComboBox.SelectedIndex = 0;

			GenerateData(null, null);
		}

		private void GenerateData(object sender, System.EventArgs e)
		{
			DateTime startDate = DateTime.Now;
			DateTime endDate = DateTime.Now.Add(new TimeSpan(30, 0, 0, 0, 0));

			if (startDate > endDate)
			{
				DateTime temp = startDate;

				startDate = endDate;
				endDate = temp;
			}

			// Get the line series from the chart
			NLineSeries line = (NLineSeries)m_Chart.Series[0];

			TimeSpan span = endDate - startDate;
			span = new TimeSpan(span.Ticks / 30);

			line.Values.Clear();
			line.XValues.Clear();

			if (span.Ticks > 0)
			{
				while (startDate < endDate)
				{
					line.XValues.Add(startDate);
					startDate += span;

					line.Values.Add(Random.Next(100));
				}
			}

			nChartControl1.Refresh();
		}

		private void HighLightRangeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NScaleStripStyle stripStyle;
			DateTime origin;

			// create a strip line highlighting the working days
			if (HighLightRangeComboBox.SelectedIndex == 0)
			{
				origin = new DateTime(2007, 2, 19);
				stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 2, 5);
			}
			else
			{
				origin = new DateTime(2007, 2, 17);
                stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 5, 2);
			}

			stripStyle.SetShowAtWall(ChartWallType.Back, true);

			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleConfigurator.StripStyles.Clear();
			scaleConfigurator.StripStyles.Add(stripStyle);

			NDateTimeRangeSamplerProvider provider = new NDateTimeRangeSamplerProvider();
			provider.SamplingMode = SamplingMode.CustomStep;
			provider.UseOrigin = true;
			provider.Origin = origin;
			provider.CustomStep = new NDateTimeSpan(1, NDateTimeUnit.Day);
			stripStyle.RangeSamplerProvider = provider;

			nChartControl1.Refresh();
		}
	}
}
