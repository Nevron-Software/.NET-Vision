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
	public class NNumericAxisPagingUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown LeftAxisPageSizeNumericUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown LeftAxisPageValueNumericUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown BottomAxisPageSizeNumericUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown BottomAxisPageValueNumericUpDown;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowLeftScrollBarCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowBottomScrollbarCheckBox;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NNumericUpDown LeftAxisSmallChangeNumericUpDown;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NNumericUpDown BottomAxisSmallChangeNumericUpDown;
		private Nevron.UI.WinForm.Controls.NCheckBox BottomUseAutoSmallChangeCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox LeftUseAutoSmallChangeCheckBox;
		private System.ComponentModel.Container components = null;

		public NNumericAxisPagingUC()
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
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.LeftAxisSmallChangeNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.LeftUseAutoSmallChangeCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowLeftScrollBarCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.LeftAxisPageValueNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.LeftAxisPageSizeNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.BottomAxisPageValueNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.BottomAxisPageSizeNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.ShowBottomScrollbarCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.BottomAxisSmallChangeNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.BottomUseAutoSmallChangeCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LeftAxisSmallChangeNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftAxisPageValueNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftAxisPageSizeNumericUpDown)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BottomAxisPageValueNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BottomAxisPageSizeNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BottomAxisSmallChangeNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.LeftAxisSmallChangeNumericUpDown);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.LeftUseAutoSmallChangeCheckBox);
			this.groupBox1.Controls.Add(this.ShowLeftScrollBarCheckBox);
			this.groupBox1.Controls.Add(this.LeftAxisPageValueNumericUpDown);
			this.groupBox1.Controls.Add(this.LeftAxisPageSizeNumericUpDown);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(192, 176);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Left Axis";
			// 
			// LeftAxisSmallChangeNumericUpDown
			// 
			this.LeftAxisSmallChangeNumericUpDown.Location = new System.Drawing.Point(100, 130);
			this.LeftAxisSmallChangeNumericUpDown.Maximum = new System.Decimal(new int[] {
																							 20,
																							 0,
																							 0,
																							 0});
			this.LeftAxisSmallChangeNumericUpDown.Minimum = new System.Decimal(new int[] {
																							 1,
																							 0,
																							 0,
																							 0});
			this.LeftAxisSmallChangeNumericUpDown.Name = "LeftAxisSmallChangeNumericUpDown";
			this.LeftAxisSmallChangeNumericUpDown.Size = new System.Drawing.Size(85, 20);
			this.LeftAxisSmallChangeNumericUpDown.TabIndex = 7;
			this.LeftAxisSmallChangeNumericUpDown.Value = new System.Decimal(new int[] {
																						   1,
																						   0,
																						   0,
																						   0});
			this.LeftAxisSmallChangeNumericUpDown.ValueChanged += new System.EventHandler(this.LeftAxisSmallChangeNumericUpDown_ValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 136);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Small Change:";
			// 
			// LeftUseAutoSmallChangeCheckBox
			// 
			this.LeftUseAutoSmallChangeCheckBox.Location = new System.Drawing.Point(8, 108);
			this.LeftUseAutoSmallChangeCheckBox.Name = "LeftUseAutoSmallChangeCheckBox";
			this.LeftUseAutoSmallChangeCheckBox.Size = new System.Drawing.Size(136, 24);
			this.LeftUseAutoSmallChangeCheckBox.TabIndex = 5;
			this.LeftUseAutoSmallChangeCheckBox.Text = "Auto Small Change";
			this.LeftUseAutoSmallChangeCheckBox.CheckedChanged += new System.EventHandler(this.LeftUseAutoSmallChangeCheckBox_CheckedChanged);
			// 
			// ShowLeftScrollBarCheckBox
			// 
			this.ShowLeftScrollBarCheckBox.Location = new System.Drawing.Point(8, 86);
			this.ShowLeftScrollBarCheckBox.Name = "ShowLeftScrollBarCheckBox";
			this.ShowLeftScrollBarCheckBox.TabIndex = 4;
			this.ShowLeftScrollBarCheckBox.Text = "Show Scrollbar";
			this.ShowLeftScrollBarCheckBox.CheckedChanged += new System.EventHandler(this.ShowLeftScrollBarCheckBox_CheckedChanged);
			// 
			// LeftAxisPageValueNumericUpDown
			// 
			this.LeftAxisPageValueNumericUpDown.Location = new System.Drawing.Point(100, 52);
			this.LeftAxisPageValueNumericUpDown.Name = "LeftAxisPageValueNumericUpDown";
			this.LeftAxisPageValueNumericUpDown.Size = new System.Drawing.Size(85, 20);
			this.LeftAxisPageValueNumericUpDown.TabIndex = 3;
			this.LeftAxisPageValueNumericUpDown.ValueChanged += new System.EventHandler(this.LeftAxisPageValueNumericUpDown_ValueChanged);
			// 
			// LeftAxisPageSizeNumericUpDown
			// 
			this.LeftAxisPageSizeNumericUpDown.Location = new System.Drawing.Point(100, 25);
			this.LeftAxisPageSizeNumericUpDown.Name = "LeftAxisPageSizeNumericUpDown";
			this.LeftAxisPageSizeNumericUpDown.Size = new System.Drawing.Size(85, 20);
			this.LeftAxisPageSizeNumericUpDown.TabIndex = 1;
			this.LeftAxisPageSizeNumericUpDown.ValueChanged += new System.EventHandler(this.LeftAxisPageSizeNumericUpDown_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Page Value:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Page Size:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.BottomAxisPageValueNumericUpDown);
			this.groupBox2.Controls.Add(this.BottomAxisPageSizeNumericUpDown);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.ShowBottomScrollbarCheckBox);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.BottomAxisSmallChangeNumericUpDown);
			this.groupBox2.Controls.Add(this.BottomUseAutoSmallChangeCheckBox);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.ImageIndex = 0;
			this.groupBox2.Location = new System.Drawing.Point(0, 176);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(192, 183);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Bottom Axis";
			// 
			// BottomAxisPageValueNumericUpDown
			// 
			this.BottomAxisPageValueNumericUpDown.Location = new System.Drawing.Point(100, 47);
			this.BottomAxisPageValueNumericUpDown.Name = "BottomAxisPageValueNumericUpDown";
			this.BottomAxisPageValueNumericUpDown.Size = new System.Drawing.Size(85, 20);
			this.BottomAxisPageValueNumericUpDown.TabIndex = 3;
			this.BottomAxisPageValueNumericUpDown.ValueChanged += new System.EventHandler(this.BottomAxisPageValueNumericUpDown_ValueChanged);
			// 
			// BottomAxisPageSizeNumericUpDown
			// 
			this.BottomAxisPageSizeNumericUpDown.Location = new System.Drawing.Point(100, 19);
			this.BottomAxisPageSizeNumericUpDown.Name = "BottomAxisPageSizeNumericUpDown";
			this.BottomAxisPageSizeNumericUpDown.Size = new System.Drawing.Size(85, 20);
			this.BottomAxisPageSizeNumericUpDown.TabIndex = 1;
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
			this.label14.Size = new System.Drawing.Size(66, 16);
			this.label14.TabIndex = 0;
			this.label14.Text = "Page Size:";
			// 
			// ShowBottomScrollbarCheckBox
			// 
			this.ShowBottomScrollbarCheckBox.Location = new System.Drawing.Point(8, 86);
			this.ShowBottomScrollbarCheckBox.Name = "ShowBottomScrollbarCheckBox";
			this.ShowBottomScrollbarCheckBox.TabIndex = 4;
			this.ShowBottomScrollbarCheckBox.Text = "Show Scrollbar";
			this.ShowBottomScrollbarCheckBox.CheckedChanged += new System.EventHandler(this.ShowBottomScrollbarCheckBox_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 134);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(83, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Small Change:";
			// 
			// BottomAxisSmallChangeNumericUpDown
			// 
			this.BottomAxisSmallChangeNumericUpDown.Location = new System.Drawing.Point(100, 130);
			this.BottomAxisSmallChangeNumericUpDown.Maximum = new System.Decimal(new int[] {
																							   20,
																							   0,
																							   0,
																							   0});
			this.BottomAxisSmallChangeNumericUpDown.Minimum = new System.Decimal(new int[] {
																							   1,
																							   0,
																							   0,
																							   0});
			this.BottomAxisSmallChangeNumericUpDown.Name = "BottomAxisSmallChangeNumericUpDown";
			this.BottomAxisSmallChangeNumericUpDown.Size = new System.Drawing.Size(85, 20);
			this.BottomAxisSmallChangeNumericUpDown.TabIndex = 7;
			this.BottomAxisSmallChangeNumericUpDown.Value = new System.Decimal(new int[] {
																							 1,
																							 0,
																							 0,
																							 0});
			this.BottomAxisSmallChangeNumericUpDown.ValueChanged += new System.EventHandler(this.BottomAxisSmallChangeNumericUpDown_ValueChanged);
			// 
			// BottomUseAutoSmallChangeCheckBox
			// 
			this.BottomUseAutoSmallChangeCheckBox.Location = new System.Drawing.Point(8, 106);
			this.BottomUseAutoSmallChangeCheckBox.Name = "BottomUseAutoSmallChangeCheckBox";
			this.BottomUseAutoSmallChangeCheckBox.Size = new System.Drawing.Size(136, 24);
			this.BottomUseAutoSmallChangeCheckBox.TabIndex = 5;
			this.BottomUseAutoSmallChangeCheckBox.Text = "Auto Small Change";
			this.BottomUseAutoSmallChangeCheckBox.CheckedChanged += new System.EventHandler(this.BottomUseAutoSmallChangeCheckBox_CheckedChanged);
			// 
			// NNumericAxisPagingUC
			// 
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "NNumericAxisPagingUC";
			this.Size = new System.Drawing.Size(192, 593);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.LeftAxisSmallChangeNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftAxisPageValueNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftAxisPageSizeNumericUpDown)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.BottomAxisPageValueNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BottomAxisPageSizeNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BottomAxisSmallChangeNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Numeric Axis Paging");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;

			// configure the X and Y axes to use linear scale without tick rounding
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;

            // add interlace stripe to the X axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(40, Color.LightGray)), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.ResetButton.Visible = false;
			linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			linearScale.RoundToTickMin = false;
			linearScale.RoundToTickMax = false;

            // add interlace stripe to the Y axis
            stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(40, Color.LightGray)), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			m_Chart.Axis(StandardAxis.PrimaryY).ScrollBar.ResetButton.Visible = false;

			// configure a XY scatter point chart
			NPointSeries point = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);
			point.UseXValues = true;
			point.Size = new NLength(5, NGraphicsUnit.Point);
			point.DataLabelStyle.Visible = false;

			point.Values.FillRandomRange(Random, 200, 0, 100);
			point.XValues.FillRandomRange(Random, 200, 0, 100);

			// configure the x and y axis paging
			NNumericAxisPagingView numericPagingView;

			numericPagingView = new NNumericAxisPagingView(new NRange1DD(0, 20));
			m_Chart.Axis(StandardAxis.PrimaryX).PagingView = numericPagingView;

			numericPagingView = new NNumericAxisPagingView(new NRange1DD(0, 20));
			m_Chart.Axis(StandardAxis.PrimaryY).PagingView = numericPagingView;

			// subscribe for the scrollbar value changed event
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.BeginValueChanged += new EventHandler(BottomAxisScrollbarValueChanged);
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.ShowSliders = false;
			m_Chart.Axis(StandardAxis.PrimaryY).ScrollBar.BeginValueChanged += new EventHandler(LeftAxisScrollbarValueChanged);
			m_Chart.Axis(StandardAxis.PrimaryY).ScrollBar.ShowSliders = false;

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			LeftAxisPageSizeNumericUpDown.Value = 20;
			LeftAxisPageValueNumericUpDown.Value = 10;
			BottomAxisPageSizeNumericUpDown.Value = 20;
			BottomAxisPageValueNumericUpDown.Value = 10;

			ShowLeftScrollBarCheckBox.Checked = true;
			ShowBottomScrollbarCheckBox.Checked = true;
			LeftUseAutoSmallChangeCheckBox.Checked = true;
			BottomUseAutoSmallChangeCheckBox.Checked = true;

			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
			nChartControl1.Refresh();
		}

		private void UpdateAxes()
		{
			if (m_Chart == null)
				return;

			NNumericAxisPagingView pagingView;
			NAxis axis;
			
			axis = m_Chart.Axis(StandardAxis.PrimaryY);
			pagingView = axis.PagingView as NNumericAxisPagingView;

			if (pagingView != null)
			{
				axis.ScrollBar.Visible = ShowLeftScrollBarCheckBox.Checked;
				pagingView.Length = (double)LeftAxisPageSizeNumericUpDown.Value;
				pagingView.Begin = (double)LeftAxisPageValueNumericUpDown.Value;
				pagingView.AutoSmallChange = LeftUseAutoSmallChangeCheckBox.Checked;
				pagingView.SmallChange = (double)LeftAxisSmallChangeNumericUpDown.Value;
			}

			axis = m_Chart.Axis(StandardAxis.PrimaryX);
			pagingView = axis.PagingView as NNumericAxisPagingView;

			if (pagingView != null)
			{
				axis.ScrollBar.Visible = ShowBottomScrollbarCheckBox.Checked;
				pagingView.Begin = (double)BottomAxisPageValueNumericUpDown.Value;
				pagingView.Length = (double)BottomAxisPageSizeNumericUpDown.Value;
				pagingView.AutoSmallChange = BottomUseAutoSmallChangeCheckBox.Checked;
				pagingView.SmallChange = (double)BottomAxisSmallChangeNumericUpDown.Value;
			}

			nChartControl1.Refresh();
		}

		private void LeftAxisPageSizeNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateAxes();
		}

		private void LeftAxisPageValueNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateAxes();
		}

		private void BottomAxisPageSizeNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateAxes();
		}

		private void BottomAxisPageValueNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateAxes();
		}

		private void ShowLeftScrollBarCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateAxes();
		}

		private void ShowBottomScrollbarCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateAxes();
		}

		private void LeftUseAutoSmallChangeCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateAxes();
			LeftAxisSmallChangeNumericUpDown.Enabled = !LeftUseAutoSmallChangeCheckBox.Checked;
		}

		private void LeftAxisSmallChangeNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateAxes();
		}

		private void BottomUseAutoSmallChangeCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateAxes();
			BottomAxisSmallChangeNumericUpDown.Enabled = !BottomUseAutoSmallChangeCheckBox.Checked;
		}

		private void BottomAxisSmallChangeNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateAxes();
		}

		private void BottomAxisScrollbarValueChanged(object sender, System.EventArgs e)
		{
			if (m_Chart == null)
				return;

			this.BottomAxisPageValueNumericUpDown.Value = (decimal)m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.BeginValue;
		}

		private void LeftAxisScrollbarValueChanged(object sender, System.EventArgs e)
		{
			if (m_Chart == null)
				return;

			this.LeftAxisPageValueNumericUpDown.Value = (decimal)m_Chart.Axis(StandardAxis.PrimaryY).ScrollBar.BeginValue;
		}
	}
}
