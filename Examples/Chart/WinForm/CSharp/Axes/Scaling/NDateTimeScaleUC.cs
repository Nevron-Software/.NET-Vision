using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm 
{
	[ToolboxItem(false)]
	public class NDateTimeScaleUC : NExampleBaseUC
	{
		private NCartesianChart m_Chart;
		private Nevron.UI.WinForm.Controls.NCheckBox DayCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox WeekCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox MonthCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox QuarterCheckBox;
		private NDateTimeScaleConfigurator m_DateTimeScale;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NGroupBox AllowedUnitsGroupBox;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableUnitSensitiveFormattingCheckBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NButton GenerateDataButton;
		private Nevron.UI.WinForm.Controls.NDateTimePicker StartDateTimePicker;
		private Nevron.UI.WinForm.Controls.NDateTimePicker EndDateTimePicker;
		private Nevron.UI.WinForm.Controls.NCheckBox MillisecondCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox SecondCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox MinuteCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox HourCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox HalfYearCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox YearCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox DecadeCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox CenturyCheckBox;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NDateTimeScaleUC()
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
			this.DayCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.WeekCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.MonthCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.QuarterCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.AllowedUnitsGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.CenturyCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.DecadeCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.YearCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.HalfYearCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.HourCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SecondCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.MinuteCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.MillisecondCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.EnableUnitSensitiveFormattingCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.StartDateTimePicker = new Nevron.UI.WinForm.Controls.NDateTimePicker();
			this.EndDateTimePicker = new Nevron.UI.WinForm.Controls.NDateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.GenerateDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.AllowedUnitsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// DayCheckBox
			// 
			this.DayCheckBox.ButtonProperties.BorderOffset = 2;
			this.DayCheckBox.Location = new System.Drawing.Point(16, 76);
			this.DayCheckBox.Name = "DayCheckBox";
			this.DayCheckBox.TabIndex = 4;
			this.DayCheckBox.Text = "Day";
			this.DayCheckBox.CheckedChanged += new System.EventHandler(this.DayCheckBox_CheckedChanged);
			// 
			// WeekCheckBox
			// 
			this.WeekCheckBox.ButtonProperties.BorderOffset = 2;
			this.WeekCheckBox.Location = new System.Drawing.Point(136, 76);
			this.WeekCheckBox.Name = "WeekCheckBox";
			this.WeekCheckBox.Size = new System.Drawing.Size(80, 24);
			this.WeekCheckBox.TabIndex = 5;
			this.WeekCheckBox.Text = "Week";
			this.WeekCheckBox.CheckedChanged += new System.EventHandler(this.WeekCheckBox_CheckedChanged);
			// 
			// MonthCheckBox
			// 
			this.MonthCheckBox.ButtonProperties.BorderOffset = 2;
			this.MonthCheckBox.Location = new System.Drawing.Point(16, 106);
			this.MonthCheckBox.Name = "MonthCheckBox";
			this.MonthCheckBox.TabIndex = 6;
			this.MonthCheckBox.Text = "Month";
			this.MonthCheckBox.CheckedChanged += new System.EventHandler(this.MonthCheckBox_CheckedChanged);
			// 
			// QuarterCheckBox
			// 
			this.QuarterCheckBox.ButtonProperties.BorderOffset = 2;
			this.QuarterCheckBox.Location = new System.Drawing.Point(136, 106);
			this.QuarterCheckBox.Name = "QuarterCheckBox";
			this.QuarterCheckBox.Size = new System.Drawing.Size(80, 24);
			this.QuarterCheckBox.TabIndex = 7;
			this.QuarterCheckBox.Text = "Quarter";
			this.QuarterCheckBox.CheckedChanged += new System.EventHandler(this.QuarterCheckBox_CheckedChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			// 
			// AllowedUnitsGroupBox
			// 
			this.AllowedUnitsGroupBox.Controls.Add(this.CenturyCheckBox);
			this.AllowedUnitsGroupBox.Controls.Add(this.DecadeCheckBox);
			this.AllowedUnitsGroupBox.Controls.Add(this.YearCheckBox);
			this.AllowedUnitsGroupBox.Controls.Add(this.HalfYearCheckBox);
			this.AllowedUnitsGroupBox.Controls.Add(this.HourCheckBox);
			this.AllowedUnitsGroupBox.Controls.Add(this.SecondCheckBox);
			this.AllowedUnitsGroupBox.Controls.Add(this.MinuteCheckBox);
			this.AllowedUnitsGroupBox.Controls.Add(this.MillisecondCheckBox);
			this.AllowedUnitsGroupBox.Controls.Add(this.QuarterCheckBox);
			this.AllowedUnitsGroupBox.Controls.Add(this.MonthCheckBox);
			this.AllowedUnitsGroupBox.Controls.Add(this.WeekCheckBox);
			this.AllowedUnitsGroupBox.Controls.Add(this.DayCheckBox);
			this.AllowedUnitsGroupBox.ImageIndex = 0;
			this.AllowedUnitsGroupBox.Location = new System.Drawing.Point(8, 0);
			this.AllowedUnitsGroupBox.Name = "AllowedUnitsGroupBox";
			this.AllowedUnitsGroupBox.Size = new System.Drawing.Size(240, 200);
			this.AllowedUnitsGroupBox.TabIndex = 0;
			this.AllowedUnitsGroupBox.TabStop = false;
			this.AllowedUnitsGroupBox.Text = "Allowed Date Time Units";
			// 
			// CenturyCheckBox
			// 
			this.CenturyCheckBox.ButtonProperties.BorderOffset = 2;
			this.CenturyCheckBox.Location = new System.Drawing.Point(136, 166);
			this.CenturyCheckBox.Name = "CenturyCheckBox";
			this.CenturyCheckBox.Size = new System.Drawing.Size(80, 24);
			this.CenturyCheckBox.TabIndex = 11;
			this.CenturyCheckBox.Text = "Century";
			this.CenturyCheckBox.CheckedChanged += new System.EventHandler(this.CenturyCheckBox_CheckedChanged);
			// 
			// DecadeCheckBox
			// 
			this.DecadeCheckBox.ButtonProperties.BorderOffset = 2;
			this.DecadeCheckBox.Location = new System.Drawing.Point(16, 166);
			this.DecadeCheckBox.Name = "DecadeCheckBox";
			this.DecadeCheckBox.TabIndex = 10;
			this.DecadeCheckBox.Text = "Decade";
			this.DecadeCheckBox.CheckedChanged += new System.EventHandler(this.DecadeCheckBox_CheckedChanged);
			// 
			// YearCheckBox
			// 
			this.YearCheckBox.ButtonProperties.BorderOffset = 2;
			this.YearCheckBox.Location = new System.Drawing.Point(136, 136);
			this.YearCheckBox.Name = "YearCheckBox";
			this.YearCheckBox.Size = new System.Drawing.Size(80, 24);
			this.YearCheckBox.TabIndex = 9;
			this.YearCheckBox.Text = "Year";
			this.YearCheckBox.CheckedChanged += new System.EventHandler(this.YearCheckBox_CheckedChanged);
			// 
			// HalfYearCheckBox
			// 
			this.HalfYearCheckBox.ButtonProperties.BorderOffset = 2;
			this.HalfYearCheckBox.Location = new System.Drawing.Point(16, 136);
			this.HalfYearCheckBox.Name = "HalfYearCheckBox";
			this.HalfYearCheckBox.TabIndex = 8;
			this.HalfYearCheckBox.Text = "Half Year";
			this.HalfYearCheckBox.CheckedChanged += new System.EventHandler(this.HalfYearCheckBox_CheckedChanged);
			// 
			// HourCheckBox
			// 
			this.HourCheckBox.ButtonProperties.BorderOffset = 2;
			this.HourCheckBox.Location = new System.Drawing.Point(136, 46);
			this.HourCheckBox.Name = "HourCheckBox";
			this.HourCheckBox.Size = new System.Drawing.Size(80, 24);
			this.HourCheckBox.TabIndex = 3;
			this.HourCheckBox.Text = "Hour";
			this.HourCheckBox.CheckedChanged += new System.EventHandler(this.HourCheckBox_CheckedChanged);
			// 
			// SecondCheckBox
			// 
			this.SecondCheckBox.ButtonProperties.BorderOffset = 2;
			this.SecondCheckBox.Location = new System.Drawing.Point(136, 16);
			this.SecondCheckBox.Name = "SecondCheckBox";
			this.SecondCheckBox.Size = new System.Drawing.Size(80, 24);
			this.SecondCheckBox.TabIndex = 1;
			this.SecondCheckBox.Text = "Second";
			this.SecondCheckBox.CheckedChanged += new System.EventHandler(this.SecondCheckBox_CheckedChanged);
			// 
			// MinuteCheckBox
			// 
			this.MinuteCheckBox.ButtonProperties.BorderOffset = 2;
			this.MinuteCheckBox.Location = new System.Drawing.Point(16, 46);
			this.MinuteCheckBox.Name = "MinuteCheckBox";
			this.MinuteCheckBox.TabIndex = 2;
			this.MinuteCheckBox.Text = "Minute";
			this.MinuteCheckBox.CheckedChanged += new System.EventHandler(this.MinuteCheckBox_CheckedChanged);
			// 
			// MillisecondCheckBox
			// 
			this.MillisecondCheckBox.ButtonProperties.BorderOffset = 2;
			this.MillisecondCheckBox.Location = new System.Drawing.Point(16, 16);
			this.MillisecondCheckBox.Name = "MillisecondCheckBox";
			this.MillisecondCheckBox.TabIndex = 0;
			this.MillisecondCheckBox.Text = "Millisecond";
			this.MillisecondCheckBox.CheckedChanged += new System.EventHandler(this.MillisecondCheckBox_CheckedChanged);
			// 
			// EnableUnitSensitiveFormattingCheckBox
			// 
			this.EnableUnitSensitiveFormattingCheckBox.ButtonProperties.BorderOffset = 2;
			this.EnableUnitSensitiveFormattingCheckBox.Location = new System.Drawing.Point(8, 208);
			this.EnableUnitSensitiveFormattingCheckBox.Name = "EnableUnitSensitiveFormattingCheckBox";
			this.EnableUnitSensitiveFormattingCheckBox.Size = new System.Drawing.Size(200, 24);
			this.EnableUnitSensitiveFormattingCheckBox.TabIndex = 1;
			this.EnableUnitSensitiveFormattingCheckBox.Text = "Enable Unit Sensitive Formatting";
			this.EnableUnitSensitiveFormattingCheckBox.CheckedChanged += new System.EventHandler(this.EnableUnitSensitiveFormattingCheckBox_CheckedChanged);
			// 
			// StartDateTimePicker
			// 
			this.StartDateTimePicker.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.StartDateTimePicker.CalendarForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.StartDateTimePicker.CalendarMonthBackground = System.Drawing.Color.FromArgb(((System.Byte)(235)), ((System.Byte)(235)), ((System.Byte)(235)));
			this.StartDateTimePicker.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((System.Byte)(76)), ((System.Byte)(76)), ((System.Byte)(76)));
			this.StartDateTimePicker.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((System.Byte)(242)), ((System.Byte)(242)), ((System.Byte)(242)));
			this.StartDateTimePicker.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((System.Byte)(127)), ((System.Byte)(127)), ((System.Byte)(127)));
			this.StartDateTimePicker.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.StartDateTimePicker.Location = new System.Drawing.Point(8, 264);
			this.StartDateTimePicker.Name = "StartDateTimePicker";
			this.StartDateTimePicker.Size = new System.Drawing.Size(232, 21);
			this.StartDateTimePicker.TabIndex = 3;
			this.StartDateTimePicker.ValueChanged += new System.EventHandler(this.StartDateTimePicker_ValueChanged);
			// 
			// EndDateTimePicker
			// 
			this.EndDateTimePicker.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.EndDateTimePicker.CalendarForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.EndDateTimePicker.CalendarMonthBackground = System.Drawing.Color.FromArgb(((System.Byte)(235)), ((System.Byte)(235)), ((System.Byte)(235)));
			this.EndDateTimePicker.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((System.Byte)(76)), ((System.Byte)(76)), ((System.Byte)(76)));
			this.EndDateTimePicker.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((System.Byte)(242)), ((System.Byte)(242)), ((System.Byte)(242)));
			this.EndDateTimePicker.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((System.Byte)(127)), ((System.Byte)(127)), ((System.Byte)(127)));
			this.EndDateTimePicker.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.EndDateTimePicker.Location = new System.Drawing.Point(8, 312);
			this.EndDateTimePicker.Name = "EndDateTimePicker";
			this.EndDateTimePicker.Size = new System.Drawing.Size(232, 21);
			this.EndDateTimePicker.TabIndex = 5;
			this.EndDateTimePicker.ValueChanged += new System.EventHandler(this.EndDateTimePicker_ValueChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 240);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 2;
			this.label4.Text = "Start date:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 288);
			this.label5.Name = "label5";
			this.label5.TabIndex = 4;
			this.label5.Text = "End date:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// GenerateDataButton
			// 
			this.GenerateDataButton.Location = new System.Drawing.Point(8, 376);
			this.GenerateDataButton.Name = "GenerateDataButton";
			this.GenerateDataButton.Size = new System.Drawing.Size(232, 23);
			this.GenerateDataButton.TabIndex = 6;
			this.GenerateDataButton.Text = "Generate Random Data";
			this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			// 
			// NDateTimeScaleUC
			// 
			this.Controls.Add(this.GenerateDataButton);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.EndDateTimePicker);
			this.Controls.Add(this.StartDateTimePicker);
			this.Controls.Add(this.EnableUnitSensitiveFormattingCheckBox);
			this.Controls.Add(this.AllowedUnitsGroupBox);
			this.Name = "NDateTimeScaleUC";
			this.Size = new System.Drawing.Size(256, 416);
			this.AllowedUnitsGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Date Time Scale");
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			m_Chart = (NCartesianChart)nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;

			// add a range selection, snapped to the vertical axis min/max values
			NRangeSelection rangeSelection = new NRangeSelection();
			rangeSelection.VerticalValueSnapper = new NAxisRulerMinMaxSnapper();
			m_Chart.RangeSelections.Add(rangeSelection);

            // add interlaced stripe to the Y axis
            NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// Add a line series
			NLineSeries line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);

			line.UseXValues = true;

			line.DataLabelStyle.Visible = false;
			line.InflateMargins = true;
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.BorderStyle.Color = Color.DarkRed;
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.MarkerStyle.Width = new NLength(2, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Height = new NLength(2, NRelativeUnit.ParentPercentage);

            // create a date time scale
			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();

			m_DateTimeScale = dateTimeScale;
			m_DateTimeScale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 90);
			m_DateTimeScale.LabelStyle.ContentAlignment = ContentAlignment.MiddleLeft; 
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale;

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			NAxis xAxis = m_Chart.Axis(StandardAxis.PrimaryX);
			xAxis.ScrollBar.Visible = true;

			// configure interactivity
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
			nChartControl1.Controller.Tools.Add(new NDataZoomTool());

			// init form controls
			EndDateTimePicker.Value = CultureInfo.CurrentCulture.Calendar.AddYears(StartDateTimePicker.Value, 2);

			EnableUnitSensitiveFormattingCheckBox.Checked = true;
			DayCheckBox.Checked = true;
			WeekCheckBox.Checked = true;
			MonthCheckBox.Checked = true;
			QuarterCheckBox.Checked = true;
			YearCheckBox.Checked = true;

			UpdateDateTimeScale();
			GenerateDataButton_Click(null, null);

			nChartControl1.Refresh();
		}

		private void UpdateDateTimeScale()
		{
			if (m_DateTimeScale == null)
				return;

			ArrayList dateTimeUnits = new ArrayList();

			if (MillisecondCheckBox.Checked)
			{
				dateTimeUnits.Add(NDateTimeUnit.Millisecond);
			}

			if (SecondCheckBox.Checked)
			{
				dateTimeUnits.Add(NDateTimeUnit.Second);
			}

			if (MinuteCheckBox.Checked)
			{
				dateTimeUnits.Add(NDateTimeUnit.Minute);
			}

			if (HourCheckBox.Checked)
			{
				dateTimeUnits.Add(NDateTimeUnit.Hour);
			}

			if (DayCheckBox.Checked)
			{
				dateTimeUnits.Add(NDateTimeUnit.Day);
			}

			if (WeekCheckBox.Checked)
			{
				dateTimeUnits.Add(NDateTimeUnit.Week);
			}

			if (MonthCheckBox.Checked)
			{
				dateTimeUnits.Add(NDateTimeUnit.Month);
			}

			if (QuarterCheckBox.Checked)
			{
				dateTimeUnits.Add(NDateTimeUnit.Quarter);
			}

			if (HalfYearCheckBox.Checked)
			{
				dateTimeUnits.Add(NDateTimeUnit.HalfYear);
			}

			if (YearCheckBox.Checked)
			{
				dateTimeUnits.Add(NDateTimeUnit.Year);
			}

			if (DecadeCheckBox.Checked)
			{
				dateTimeUnits.Add(NDateTimeUnit.Decade);
			}

			if (CenturyCheckBox.Checked)
			{
				dateTimeUnits.Add(NDateTimeUnit.Century);
			}

			NDateTimeUnit[] autoUnits = new NDateTimeUnit[dateTimeUnits.Count];
			for (int i = 0; i < autoUnits.Length; i++)
			{
				autoUnits[i] = (NDateTimeUnit)dateTimeUnits[i];
			}

			m_DateTimeScale.EnableUnitSensitiveFormatting = EnableUnitSensitiveFormattingCheckBox.Checked;

			m_DateTimeScale.AutoDateTimeUnits = autoUnits;
			nChartControl1.Refresh();
		}

		private void DayCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateDateTimeScale();
		}

		private void WeekCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateDateTimeScale();
		}

		private void MonthCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateDateTimeScale();
		}

		private void QuarterCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateDateTimeScale();
		}

		private void MillisecondCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateDateTimeScale();		
		}

		private void SecondCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateDateTimeScale();
		}

		private void MinuteCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateDateTimeScale();
		}

		private void HourCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateDateTimeScale();
		}

		private void HalfYearCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateDateTimeScale();
		}

		private void YearCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateDateTimeScale();
		}

		private void DecadeCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateDateTimeScale();
		}

		private void CenturyCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateDateTimeScale();		
		}

		private void EnableUnitSensitiveFormattingCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateDateTimeScale();
		}

		private void GenerateDataButton_Click(object sender, System.EventArgs e)
		{
			DateTime startDate = StartDateTimePicker.Value;
			DateTime endDate = EndDateTimePicker.Value;

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

		private void EndDateTimePicker_ValueChanged(object sender, System.EventArgs e)
		{
			GenerateDataButton_Click(null, null);
		}

		private void StartDateTimePicker_ValueChanged(object sender, System.EventArgs e)
		{
			GenerateDataButton_Click(null, null);
		}
	}
}
