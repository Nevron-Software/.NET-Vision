using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NRealTimeAreaUC : NRealTimeExampleBaseUC
	{
		private int m_nCounter;
		private int m_nDirectionChangeCounter;
		private double m_Direction;
		private double m_Value;
		private Nevron.UI.WinForm.Controls.NCheckBox UseHardwareAccelerationCheckBox;
		private Nevron.UI.WinForm.Controls.NButton StopStartTimerButton;
		private Nevron.UI.WinForm.Controls.NButton ResetButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private UI.WinForm.Controls.NComboBox NumberOfDataPointsComboBox;
		private Label label6;
		private UI.WinForm.Controls.NComboBox NewDataPointsPerTickComboBox;
		private System.ComponentModel.IContainer components;

		public NRealTimeAreaUC()
		{
			InitializeComponent();

			m_nCounter = 0;
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
			this.ResetButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.StopStartTimerButton = new Nevron.UI.WinForm.Controls.NButton();
			this.UseHardwareAccelerationCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.NumberOfDataPointsComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.NewDataPointsPerTickComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 103);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(153, 16);
			this.label1.TabIndex = 12;
			this.label1.Text = "Number of Data Points:";
			// 
			// ResetButton
			// 
			this.ResetButton.Location = new System.Drawing.Point(10, 71);
			this.ResetButton.Name = "ResetButton";
			this.ResetButton.Size = new System.Drawing.Size(153, 23);
			this.ResetButton.TabIndex = 11;
			this.ResetButton.Text = "Reset";
			this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 132);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "Bottom:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "Right:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Top:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Left:";
			// 
			// StopStartTimerButton
			// 
			this.StopStartTimerButton.Location = new System.Drawing.Point(10, 42);
			this.StopStartTimerButton.Name = "StopStartTimerButton";
			this.StopStartTimerButton.Size = new System.Drawing.Size(153, 23);
			this.StopStartTimerButton.TabIndex = 15;
			this.StopStartTimerButton.Text = "Stop Timer";
			this.StopStartTimerButton.Click += new System.EventHandler(this.StopStartTimerButton_Click);
			// 
			// UseHardwareAccelerationCheckBox
			// 
			this.UseHardwareAccelerationCheckBox.ButtonProperties.BorderOffset = 2;
			this.UseHardwareAccelerationCheckBox.Location = new System.Drawing.Point(7, 12);
			this.UseHardwareAccelerationCheckBox.Name = "UseHardwareAccelerationCheckBox";
			this.UseHardwareAccelerationCheckBox.Size = new System.Drawing.Size(153, 24);
			this.UseHardwareAccelerationCheckBox.TabIndex = 17;
			this.UseHardwareAccelerationCheckBox.Text = "Use Hardware Acceleration";
			this.UseHardwareAccelerationCheckBox.CheckedChanged += new System.EventHandler(this.UseHardwareAccelerationCheckBox_CheckedChanged);
			// 
			// NumberOfDataPointsComboBox
			// 
			this.NumberOfDataPointsComboBox.ListProperties.CheckBoxDataMember = "";
			this.NumberOfDataPointsComboBox.ListProperties.DataSource = null;
			this.NumberOfDataPointsComboBox.ListProperties.DisplayMember = "";
			this.NumberOfDataPointsComboBox.Location = new System.Drawing.Point(13, 122);
			this.NumberOfDataPointsComboBox.Name = "NumberOfDataPointsComboBox";
			this.NumberOfDataPointsComboBox.Size = new System.Drawing.Size(147, 21);
			this.NumberOfDataPointsComboBox.TabIndex = 18;
			this.NumberOfDataPointsComboBox.Text = "comboBox2";
			this.NumberOfDataPointsComboBox.SelectedIndexChanged += new System.EventHandler(this.OnNumberOfDataPointsComboBoxSelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(10, 160);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(153, 16);
			this.label6.TabIndex = 19;
			this.label6.Text = "New Data Points per Tick:";
			// 
			// NewDataPointsPerTickComboBox
			// 
			this.NewDataPointsPerTickComboBox.ListProperties.CheckBoxDataMember = "";
			this.NewDataPointsPerTickComboBox.ListProperties.DataSource = null;
			this.NewDataPointsPerTickComboBox.ListProperties.DisplayMember = "";
			this.NewDataPointsPerTickComboBox.Location = new System.Drawing.Point(13, 179);
			this.NewDataPointsPerTickComboBox.Name = "NewDataPointsPerTickComboBox";
			this.NewDataPointsPerTickComboBox.Size = new System.Drawing.Size(147, 21);
			this.NewDataPointsPerTickComboBox.TabIndex = 20;
			this.NewDataPointsPerTickComboBox.Text = "comboBox2";
			this.NewDataPointsPerTickComboBox.SelectedIndexChanged += new System.EventHandler(this.OnNewDataPointsPerTickComboBoxSelectedIndexChanged);
			// 
			// NRealTimeAreaUC
			// 
			this.Controls.Add(this.NewDataPointsPerTickComboBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.NumberOfDataPointsComboBox);
			this.Controls.Add(this.UseHardwareAccelerationCheckBox);
			this.Controls.Add(this.StopStartTimerButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ResetButton);
			this.Name = "NRealTimeAreaUC";
			this.Size = new System.Drawing.Size(180, 442);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Real Time Area");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			chart.BoundsMode = BoundsMode.Stretch;

			// configure the y axis
			NAxis yAxis = chart.Axis(StandardAxis.PrimaryY);
			yAxis.View = new NRangeAxisView(new NRange1DD(0, 100));

			NLinearScaleConfigurator linearScale = yAxis.ScaleConfigurator as NLinearScaleConfigurator;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			linearScale.MajorGridStyle.LineStyle.Color = Color.LightSteelBlue;
			linearScale.InnerMinorTickStyle.Visible = false;
			linearScale.InnerMajorTickStyle.Visible = false;
			linearScale.LabelFitModes = new LabelFitMode[0];

			// configure the x axis
			NAxis xAxis = chart.Axis(StandardAxis.PrimaryX);
			linearScale = new NLinearScaleConfigurator();
			linearScale.LabelFitModes = new LabelFitMode[0];
			xAxis.ScaleConfigurator = linearScale;
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;
			linearScale.InnerMinorTickStyle.Visible = false;
			linearScale.InnerMajorTickStyle.Visible = false;
			
			chart.Axis(StandardAxis.Depth).Visible = false;

			// add the first line
			NAreaSeries area = new NAreaSeries();
			chart.Series.Add(area);
			area.SamplingMode = SeriesSamplingMode.Enabled;
			area.UseXValues = true;
			area.DataLabelStyle.Visible = false;
			area.Values.ValueFormatter = new NNumericValueFormatter("0.0");
			area.Values.EmptyDataPoints.ValueMode = EmptyDataPointsValueMode.Skip;

			// apply layout
			ConfigureStandardLayout(chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// turn off area border to improve performance after you apply the style sheet
			area.BorderStyle.Width = new NLength(0);

			NumberOfDataPointsComboBox.Items.Add("1000");
			NumberOfDataPointsComboBox.Items.Add("5000");
			NumberOfDataPointsComboBox.Items.Add("10000");
			NumberOfDataPointsComboBox.SelectedIndex = 0;

			NewDataPointsPerTickComboBox.Items.Add("10");
			NewDataPointsPerTickComboBox.Items.Add("50");
			NewDataPointsPerTickComboBox.Items.Add("100");
			NewDataPointsPerTickComboBox.SelectedIndex = 1;


			UseHardwareAccelerationCheckBox.Checked = true;

			StartTimer();
		}
		protected override void UpdateTitle(bool working, float cpuUsage)
		{
			string title = "Real Time Area";

			if (working)
			{
				title += " [CPU Usage - " + cpuUsage.ToString("0.") + "%]";
			}

			nChartControl1.Labels[0].Text = title;
		}

		private int GetNewDataPointsPerTick()
		{
			switch (NewDataPointsPerTickComboBox.SelectedIndex)
			{
				case 0:
					return 10;
				case 1:
					return 50;
				case 2:
					return 100;
				default:
					return 10;
			}
		}

		private int GetNumberOfDataPoints()
		{
			switch (NumberOfDataPointsComboBox.SelectedIndex)
			{
				case 0:
					return 1000;
				case 1:
					return 5000;
				case 2:
					return 10000;
				default:
					return 1000;
			}
		}

		private double GetXAxisCustomMax()
		{
			return (double)(GetNumberOfDataPoints() - 1);
		}

		private void ResetButton_Click(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			int nMaxCount = GetNumberOfDataPoints();

			NChart chart = nChartControl1.Charts[0];
			NAreaSeries area = (NAreaSeries)chart.Series[0];
			area.Values.Clear();
			area.XValues.Clear();
			area.DataPointOriginIndex = 0;

			m_nCounter = 0;
			m_nDirectionChangeCounter = 0;
			m_Direction = 0;
			m_Value = 0;

			nChartControl1.Refresh();
		}

		private void OnNumberOfDataPointsComboBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			ResetButton_Click(null, null);
		}

		protected override void  OnTimerTick(object sender, EventArgs e)
		{
 			base.OnTimerTick(sender, e);

			int nMaxCount = GetNumberOfDataPoints();

			if (nMaxCount == 0)
				return;

			int newDataPoints = GetNewDataPointsPerTick();

			double dValueX = 0;
			NChart chart = nChartControl1.Charts[0];
			NAreaSeries area = (NAreaSeries)chart.Series[0];
			NAxis axisX = chart.Axis(StandardAxis.PrimaryX);

			double minValue = 0;
			double maxValue = 100;

			// add 100 new random points
			for (int i = 0; i < newDataPoints; i++)
			{
				if (m_nDirectionChangeCounter == 0)
				{
					m_nDirectionChangeCounter = 100;
					m_Direction = (m_Direction + Random.NextDouble() - 0.5) / 4.0;
				}

				m_nDirectionChangeCounter--;

				if (m_Value + m_Direction > maxValue)
				{
					m_Value = maxValue;
					m_Direction = 0;
					m_nDirectionChangeCounter = 0;
				}
				else if (m_Value + m_Direction < minValue)
				{
					m_Value = minValue;
					m_Direction = 0;
					m_nDirectionChangeCounter = 0;
				}
				else
				{
					m_Value += m_Direction;
				}				
				
				double dValueY = m_Value;

				int nIndex = m_nCounter % nMaxCount;
				dValueX = m_nCounter;
						
				if (nIndex >= area.Values.Count)
				{
					area.Values.Add(dValueY);
					area.XValues.Add(dValueX);
				}
				else
				{
					area.Values[area.DataPointOriginIndex] = dValueY;
					area.XValues[area.DataPointOriginIndex] = dValueX;
					area.DataPointOriginIndex++;

					if (area.DataPointOriginIndex >= area.Values.Count)
					{
						area.DataPointOriginIndex = 0;
					}
				}

				m_nCounter++;
			}

			nChartControl1.Refresh();
		}

		private void UseHardwareAccelerationCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if(UseHardwareAccelerationCheckBox.Checked)
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			}
			else
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap;
			}
		}

		private void StopStartTimerButton_Click(object sender, EventArgs e)
		{
			ToggleTimer();

			if (IsTimerRunning())
			{
				StopStartTimerButton.Text = "Stop Timer";
			}
			else
			{
				StopStartTimerButton.Text = "Start Timer";
			}
		}

		private void OnNewDataPointsPerTickComboBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			ResetButton_Click(null, null);
		}
	}
}
