using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NTimeSpanScaleUC : NExampleBaseUC
	{
		private NLineSeries m_Line;
		private TimeSpan m_TimeSpan;
		private Random m_Random;
		private Nevron.UI.WinForm.Controls.NCheckBox DayCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox WeekCheckBox;
		private NTimeSpanScaleConfigurator m_TimeSpanScale;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NGroupBox AllowedUnitsGroupBox;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableUnitSensitiveFormattingCheckBox;
		private Nevron.UI.WinForm.Controls.NButton StartStopTimerButton;
		private Nevron.UI.WinForm.Controls.NCheckBox MillisecondCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox SecondCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox MinuteCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox HourCheckBox;
		private System.Windows.Forms.Timer timer1;
		private UI.WinForm.Controls.NComboBox StepUnitComboBox;
		private System.Windows.Forms.Label label4;
		private UI.WinForm.Controls.NNumericUpDown StepCountUpDown;
		private UI.WinForm.Controls.NButton ClearDataButton;
		private IContainer components;

		public NTimeSpanScaleUC()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			m_Random = new Random();
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
			this.components = new System.ComponentModel.Container();
			this.DayCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.WeekCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.AllowedUnitsGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.HourCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SecondCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.MinuteCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.MillisecondCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.EnableUnitSensitiveFormattingCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.StartStopTimerButton = new Nevron.UI.WinForm.Controls.NButton();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.StepUnitComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.StepCountUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.ClearDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.AllowedUnitsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.StepCountUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// DayCheckBox
			// 
			this.DayCheckBox.ButtonProperties.BorderOffset = 2;
			this.DayCheckBox.Location = new System.Drawing.Point(16, 76);
			this.DayCheckBox.Name = "DayCheckBox";
			this.DayCheckBox.Size = new System.Drawing.Size(104, 24);
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
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			// 
			// AllowedUnitsGroupBox
			// 
			this.AllowedUnitsGroupBox.Controls.Add(this.HourCheckBox);
			this.AllowedUnitsGroupBox.Controls.Add(this.SecondCheckBox);
			this.AllowedUnitsGroupBox.Controls.Add(this.MinuteCheckBox);
			this.AllowedUnitsGroupBox.Controls.Add(this.MillisecondCheckBox);
			this.AllowedUnitsGroupBox.Controls.Add(this.WeekCheckBox);
			this.AllowedUnitsGroupBox.Controls.Add(this.DayCheckBox);
			this.AllowedUnitsGroupBox.ImageIndex = 0;
			this.AllowedUnitsGroupBox.Location = new System.Drawing.Point(8, 0);
			this.AllowedUnitsGroupBox.Name = "AllowedUnitsGroupBox";
			this.AllowedUnitsGroupBox.Size = new System.Drawing.Size(240, 109);
			this.AllowedUnitsGroupBox.TabIndex = 0;
			this.AllowedUnitsGroupBox.TabStop = false;
			this.AllowedUnitsGroupBox.Text = "Allowed Date Time Units";
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
			this.MinuteCheckBox.Size = new System.Drawing.Size(104, 24);
			this.MinuteCheckBox.TabIndex = 2;
			this.MinuteCheckBox.Text = "Minute";
			this.MinuteCheckBox.CheckedChanged += new System.EventHandler(this.MinuteCheckBox_CheckedChanged);
			// 
			// MillisecondCheckBox
			// 
			this.MillisecondCheckBox.ButtonProperties.BorderOffset = 2;
			this.MillisecondCheckBox.Location = new System.Drawing.Point(16, 16);
			this.MillisecondCheckBox.Name = "MillisecondCheckBox";
			this.MillisecondCheckBox.Size = new System.Drawing.Size(104, 24);
			this.MillisecondCheckBox.TabIndex = 0;
			this.MillisecondCheckBox.Text = "Millisecond";
			this.MillisecondCheckBox.CheckedChanged += new System.EventHandler(this.MillisecondCheckBox_CheckedChanged);
			// 
			// EnableUnitSensitiveFormattingCheckBox
			// 
			this.EnableUnitSensitiveFormattingCheckBox.ButtonProperties.BorderOffset = 2;
			this.EnableUnitSensitiveFormattingCheckBox.Location = new System.Drawing.Point(8, 115);
			this.EnableUnitSensitiveFormattingCheckBox.Name = "EnableUnitSensitiveFormattingCheckBox";
			this.EnableUnitSensitiveFormattingCheckBox.Size = new System.Drawing.Size(200, 24);
			this.EnableUnitSensitiveFormattingCheckBox.TabIndex = 1;
			this.EnableUnitSensitiveFormattingCheckBox.Text = "Enable Unit Sensitive Formatting";
			this.EnableUnitSensitiveFormattingCheckBox.CheckedChanged += new System.EventHandler(this.EnableUnitSensitiveFormattingCheckBox_CheckedChanged);
			// 
			// StartStopTimerButton
			// 
			this.StartStopTimerButton.Location = new System.Drawing.Point(8, 174);
			this.StartStopTimerButton.Name = "StartStopTimerButton";
			this.StartStopTimerButton.Size = new System.Drawing.Size(232, 23);
			this.StartStopTimerButton.TabIndex = 3;
			this.StartStopTimerButton.Text = "Stop Timer";
			this.StartStopTimerButton.Click += new System.EventHandler(this.StartStopTimerButton_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// StepUnitComboBox
			// 
			this.StepUnitComboBox.ListProperties.CheckBoxDataMember = "";
			this.StepUnitComboBox.ListProperties.DataSource = null;
			this.StepUnitComboBox.ListProperties.DisplayMember = "";
			this.StepUnitComboBox.Location = new System.Drawing.Point(124, 212);
			this.StepUnitComboBox.Name = "StepUnitComboBox";
			this.StepUnitComboBox.Size = new System.Drawing.Size(116, 21);
			this.StepUnitComboBox.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(5, 210);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "Step:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// StepCountUpDown
			// 
			this.StepCountUpDown.Location = new System.Drawing.Point(52, 213);
			this.StepCountUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.StepCountUpDown.Name = "StepCountUpDown";
			this.StepCountUpDown.Size = new System.Drawing.Size(66, 20);
			this.StepCountUpDown.TabIndex = 5;
			this.StepCountUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// ClearDataButton
			// 
			this.ClearDataButton.Location = new System.Drawing.Point(8, 145);
			this.ClearDataButton.Name = "ClearDataButton";
			this.ClearDataButton.Size = new System.Drawing.Size(232, 23);
			this.ClearDataButton.TabIndex = 2;
			this.ClearDataButton.Text = "Clear Data";
			this.ClearDataButton.Click += new System.EventHandler(this.ClearDataButton_Click);
			// 
			// NTimeSpanScaleUC
			// 
			this.Controls.Add(this.ClearDataButton);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.StepCountUpDown);
			this.Controls.Add(this.StepUnitComboBox);
			this.Controls.Add(this.StartStopTimerButton);
			this.Controls.Add(this.EnableUnitSensitiveFormattingCheckBox);
			this.Controls.Add(this.AllowedUnitsGroupBox);
			this.Name = "NTimeSpanScaleUC";
			this.Size = new System.Drawing.Size(256, 416);
			this.AllowedUnitsGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.StepCountUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Time Span Scale");
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// add a range selection, snapped to the vertical axis min/max values
			NRangeSelection rangeSelection = new NRangeSelection();
			rangeSelection.VerticalValueSnapper = new NAxisRulerMinMaxSnapper();
			chart.RangeSelections.Add(rangeSelection);

            // add interlaced stripe to the Y axis
            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// Add a line series
			m_Line = new NLineSeries();
			chart.Series.Add(m_Line);

			m_Line.UseXValues = true;

			m_Line.UseXValues = true;
			m_Line.DataLabelStyle.Visible = false;
			m_Line.SamplingMode = SeriesSamplingMode.Enabled;

			// create a date time scale
			m_TimeSpanScale = new NTimeSpanScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = m_TimeSpanScale;

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			NAxis xAxis = chart.Axis(StandardAxis.PrimaryX);
			xAxis.ScrollBar.Visible = true;

			// init form controls
			EnableUnitSensitiveFormattingCheckBox.Checked = true;
			MillisecondCheckBox.Checked = true;
			SecondCheckBox.Checked = true;
			MinuteCheckBox.Checked = true;
			HourCheckBox.Checked = true;
			DayCheckBox.Checked = true;
			WeekCheckBox.Checked = true;

			UpdateDateTimeScale();

			StepUnitComboBox.Items.Add("Millisecond");
			StepUnitComboBox.Items.Add("Second");
			StepUnitComboBox.Items.Add("Minute");
			StepUnitComboBox.Items.Add("Hour");
			StepUnitComboBox.Items.Add("Day");
			StepUnitComboBox.Items.Add("Week");
			StepUnitComboBox.SelectedIndex = 2;

			timer1.Start();
			nChartControl1.Refresh();
		}

		private void UpdateDateTimeScale()
		{
			if (m_TimeSpanScale == null)
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

			NTimeUnit[] autoUnits = new NTimeUnit[dateTimeUnits.Count];
			for (int i = 0; i < autoUnits.Length; i++)
			{
				autoUnits[i] = (NTimeUnit)dateTimeUnits[i];
			}

			m_TimeSpanScale.EnableUnitSensitiveFormatting = EnableUnitSensitiveFormattingCheckBox.Checked;

			m_TimeSpanScale.AutoDateTimeUnits = autoUnits;
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


		private void timer1_Tick(object sender, System.EventArgs e)
		{
			TimeSpan step = new TimeSpan();
			switch (StepUnitComboBox.SelectedIndex)
			{
				case 0: // Millisecond
					step = new TimeSpan(0, 0, 0, 0, (int)StepCountUpDown.Value);
					break;
				case 1: // Second
					step = new TimeSpan(0, 0, (int)StepCountUpDown.Value);
					break;
				case 2: // Minute
					step = new TimeSpan(0, (int)StepCountUpDown.Value, 0);
					break;
				case 3: // Hour
					step = new TimeSpan((int)StepCountUpDown.Value, 0, 0);
					break;
				case 4: // Day
					step = new TimeSpan((int)StepCountUpDown.Value, 0, 0, 0);
					break;
				case 5: // Week
					step = new TimeSpan(7 * (int)StepCountUpDown.Value, 0, 0, 0);
					break;
			}

			m_TimeSpan = m_TimeSpan.Add(step);

			m_Line.XValues.Add(m_TimeSpan);
			m_Line.Values.Add(m_Random.Next(100));

			if (m_Line.Values.Count > 1000)
			{
				m_Line.Values.RemoveAt(0);
				m_Line.XValues.RemoveAt(0);
			}

			nChartControl1.Refresh();
		}

		private void StartStopTimerButton_Click(object sender, System.EventArgs e)
		{
			if (timer1.Enabled)
			{
				m_TimeSpan = new TimeSpan();
				timer1.Stop();
				StartStopTimerButton.Text = "Start Timer";
			}
			else
			{
				timer1.Start();
				StartStopTimerButton.Text = "Stop Timer";
				nChartControl1.Refresh();
			}
		}

		private void ClearDataButton_Click(object sender, EventArgs e)
		{
			m_Line.Values.Clear();
			m_Line.XValues.Clear();

			nChartControl1.Refresh();
		}
	}
}
