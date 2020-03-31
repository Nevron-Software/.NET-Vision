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
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm 
{
	[ToolboxItem(false)]
	public class NDateTimeAxisPagingUC : NExampleBaseUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown BottomAxisPageSizeNumericUpDown;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NNumericUpDown SmallChangeNumericUpDown;
		private Nevron.UI.WinForm.Controls.NCheckBox AutoSmallChangeCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowScrollbarCheckBox;
		private Nevron.UI.WinForm.Controls.NDateTimePicker StartDateTimePicker;

		private NChart m_Chart;
		private bool m_Updating;

		public NDateTimeAxisPagingUC()
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
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.StartDateTimePicker = new Nevron.UI.WinForm.Controls.NDateTimePicker();
			this.BottomAxisPageSizeNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.ShowScrollbarCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SmallChangeNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.AutoSmallChangeCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BottomAxisPageSizeNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SmallChangeNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.StartDateTimePicker);
			this.groupBox2.Controls.Add(this.BottomAxisPageSizeNumericUpDown);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.ShowScrollbarCheckBox);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.SmallChangeNumericUpDown);
			this.groupBox2.Controls.Add(this.AutoSmallChangeCheckBox);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.ImageIndex = 0;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(248, 216);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Bottom Axis";
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
			this.StartDateTimePicker.Location = new System.Drawing.Point(8, 72);
			this.StartDateTimePicker.Name = "StartDateTimePicker";
			this.StartDateTimePicker.Size = new System.Drawing.Size(232, 20);
			this.StartDateTimePicker.TabIndex = 3;
			this.StartDateTimePicker.ValueChanged += new System.EventHandler(this.StartDateTimePicker_ValueChanged);
			// 
			// BottomAxisPageSizeNumericUpDown
			// 
			this.BottomAxisPageSizeNumericUpDown.Location = new System.Drawing.Point(160, 19);
			this.BottomAxisPageSizeNumericUpDown.Maximum = new System.Decimal(new int[] {
																							30,
																							0,
																							0,
																							0});
			this.BottomAxisPageSizeNumericUpDown.Minimum = new System.Decimal(new int[] {
																							1,
																							0,
																							0,
																							0});
			this.BottomAxisPageSizeNumericUpDown.Name = "BottomAxisPageSizeNumericUpDown";
			this.BottomAxisPageSizeNumericUpDown.Size = new System.Drawing.Size(85, 20);
			this.BottomAxisPageSizeNumericUpDown.TabIndex = 1;
			this.BottomAxisPageSizeNumericUpDown.Value = new System.Decimal(new int[] {
																						  1,
																						  0,
																						  0,
																						  0});
			this.BottomAxisPageSizeNumericUpDown.ValueChanged += new System.EventHandler(this.BottomAxisPageSizeNumericUpDown_ValueChanged);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 51);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(66, 16);
			this.label11.TabIndex = 2;
			this.label11.Text = "Page Value:";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(8, 23);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(136, 16);
			this.label14.TabIndex = 0;
			this.label14.Text = "Page Size (in months)";
			// 
			// ShowScrollbarCheckBox
			// 
			this.ShowScrollbarCheckBox.Location = new System.Drawing.Point(8, 120);
			this.ShowScrollbarCheckBox.Name = "ShowScrollbarCheckBox";
			this.ShowScrollbarCheckBox.TabIndex = 4;
			this.ShowScrollbarCheckBox.Text = "Show Scrollbar";
			this.ShowScrollbarCheckBox.CheckedChanged += new System.EventHandler(this.ShowScrollbarCheckBox_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 172);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(136, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Small Change (in days):";
			// 
			// SmallChangeNumericUpDown
			// 
			this.SmallChangeNumericUpDown.Location = new System.Drawing.Point(160, 168);
			this.SmallChangeNumericUpDown.Minimum = new System.Decimal(new int[] {
																					 1,
																					 0,
																					 0,
																					 0});
			this.SmallChangeNumericUpDown.Name = "SmallChangeNumericUpDown";
			this.SmallChangeNumericUpDown.Size = new System.Drawing.Size(85, 20);
			this.SmallChangeNumericUpDown.TabIndex = 7;
			this.SmallChangeNumericUpDown.Value = new System.Decimal(new int[] {
																				   1,
																				   0,
																				   0,
																				   0});
			this.SmallChangeNumericUpDown.ValueChanged += new System.EventHandler(this.SmallChangeNumericUpDown_ValueChanged);
			// 
			// AutoSmallChangeCheckBox
			// 
			this.AutoSmallChangeCheckBox.Location = new System.Drawing.Point(8, 144);
			this.AutoSmallChangeCheckBox.Name = "AutoSmallChangeCheckBox";
			this.AutoSmallChangeCheckBox.Size = new System.Drawing.Size(136, 24);
			this.AutoSmallChangeCheckBox.TabIndex = 5;
			this.AutoSmallChangeCheckBox.Text = "Auto Small Change";
			this.AutoSmallChangeCheckBox.CheckedChanged += new System.EventHandler(this.AutoSmallChangeCheckBox_CheckedChanged);
			// 
			// NDateTimeAxisPagingUC
			// 
			this.Controls.Add(this.groupBox2);
			this.Name = "NDateTimeAxisPagingUC";
			this.Size = new System.Drawing.Size(248, 288);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.BottomAxisPageSizeNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SmallChangeNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Date / Time Axis Paging");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;

			// configure the X and Y axes to use linear scale without tick rounding
			NValueTimelineScaleConfigurator timelineScale = new NValueTimelineScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = timelineScale;
			timelineScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.ResetButton.Visible = false;
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.ShowSliders = false;

            // add interlace stripe to the X axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(40, Color.LightGray)), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            timelineScale.StripStyles.Add(stripStyle);

            NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
            m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
            linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            linearScale.RoundToTickMax = false;
            linearScale.RoundToTickMin = false;

            // add interlace stripe to the Y axis
            stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(40, Color.LightGray)), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// configure a XY scatter point chart
			NPointSeries point = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);
			point.UseXValues = true;
			point.Size = new NLength(5, NGraphicsUnit.Point);
			point.DataLabelStyle.Visible = false;

			point.Values.FillRandomRange(Random, 100, 0, 100);

			DateTime now = DateTime.Now;

			// add data for ten thousand days from now
			for (int i = 0; i < 1000; i++)
			{
				point.XValues.Add(now + new TimeSpan(i * 10, 0, 0, 0, 0));
			}

			// configure the x and y axis paging
			NDateTimeAxisPagingView dateTimePagingView = new NDateTimeAxisPagingView(now, new NDateTimeSpan(1, NDateTimeUnit.Month));
			dateTimePagingView.Enabled = true;
			m_Chart.Axis(StandardAxis.PrimaryX).PagingView = dateTimePagingView;

			// subscribe for the scrollbar value changed event
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.BeginValueChanged += new EventHandler(ScrollbarValueChanged);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			m_Updating = true;
			StartDateTimePicker.Value = now;
			BottomAxisPageSizeNumericUpDown.Value = 2;
			ShowScrollbarCheckBox.Checked = true;
			AutoSmallChangeCheckBox.Checked = true;
			m_Updating = false;

			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
			nChartControl1.Refresh();

			UpdateAxis();
		}

		private void UpdateAxis()
		{
			if (m_Chart == null || m_Updating)
				return;

			m_Updating = true;
			NAxis axis = m_Chart.Axis(StandardAxis.PrimaryX);
			NDateTimeAxisPagingView pagingView = axis.PagingView as NDateTimeAxisPagingView;

			if (pagingView != null)
			{
				axis.ScrollBar.Visible = ShowScrollbarCheckBox.Checked;
				pagingView.Begin = StartDateTimePicker.Value;
				pagingView.Length = new NDateTimeSpan((int)BottomAxisPageSizeNumericUpDown.Value, NDateTimeUnit.Month);
				pagingView.AutoSmallChange = AutoSmallChangeCheckBox.Checked;
				pagingView.SmallChange = new NDateTimeSpan((long)SmallChangeNumericUpDown.Value, NDateTimeUnit.Day);
			}

			nChartControl1.Refresh();
			m_Updating = false;
		}

		private void ScrollbarValueChanged(object sender, System.EventArgs e)
		{
			this.StartDateTimePicker.Value = DateTime.FromOADate(m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.BeginValue);
		}

		private void ShowScrollbarCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateAxis();		
		}

		private void AutoSmallChangeCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateAxis();
			SmallChangeNumericUpDown.Enabled = !AutoSmallChangeCheckBox.Checked;
		}

		private void SmallChangeNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateAxis();
		}

		private void BottomAxisPageSizeNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateAxis();
		}

		private void StartDateTimePicker_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateAxis();
		}
	}
}
