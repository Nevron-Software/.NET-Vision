using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.UI.WinForm.Controls;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NAxisLabelsUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label7;
		private Nevron.UI.WinForm.Controls.NNumericUpDown YTicksPerLabelUpDown;
		private Nevron.UI.WinForm.Controls.NComboBox YLabelGenerationModeComboBox;
		private Nevron.UI.WinForm.Controls.NListBox YLabelFitModesList;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private Nevron.UI.WinForm.Controls.NListBox XLabelFitModesList;
		private Nevron.UI.WinForm.Controls.NNumericUpDown XTicksPerLabelUpDown;
		private Nevron.UI.WinForm.Controls.NComboBox XLabelGenerationModeComboBox;
		private System.ComponentModel.Container components = null;

		public NAxisLabelsUC()
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
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.YLabelFitModesList = new Nevron.UI.WinForm.Controls.NListBox();
			this.label7 = new System.Windows.Forms.Label();
			this.YTicksPerLabelUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.YLabelGenerationModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.XLabelFitModesList = new Nevron.UI.WinForm.Controls.NListBox();
			this.label5 = new System.Windows.Forms.Label();
			this.XTicksPerLabelUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.XLabelGenerationModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.YTicksPerLabelUpDown)).BeginInit();
			this.nGroupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.XTicksPerLabelUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.label3);
			this.nGroupBox1.Controls.Add(this.YLabelFitModesList);
			this.nGroupBox1.Controls.Add(this.label7);
			this.nGroupBox1.Controls.Add(this.YTicksPerLabelUpDown);
			this.nGroupBox1.Controls.Add(this.label2);
			this.nGroupBox1.Controls.Add(this.YLabelGenerationModeComboBox);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(7, 8);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(172, 305);
			this.nGroupBox1.TabIndex = 18;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Y Axis Labels";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(14, 136);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(144, 15);
			this.label3.TabIndex = 26;
			this.label3.Text = "Label Fit Modes:";
			// 
			// YLabelFitModesList
			// 
			this.YLabelFitModesList.CheckBoxes = true;
			this.YLabelFitModesList.Location = new System.Drawing.Point(16, 152);
			this.YLabelFitModesList.Name = "YLabelFitModesList";
			this.YLabelFitModesList.Size = new System.Drawing.Size(144, 124);
			this.YLabelFitModesList.TabIndex = 25;
			this.YLabelFitModesList.CheckedChanged += new Nevron.UI.WinForm.Controls.NListBoxItemCheckedEventHandler(this.YLabelFitModesList_CheckedChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 80);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(144, 15);
			this.label7.TabIndex = 24;
			this.label7.Text = "Number of Ticks per Label:";
			// 
			// YTicksPerLabelUpDown
			// 
			this.YTicksPerLabelUpDown.Location = new System.Drawing.Point(16, 97);
			this.YTicksPerLabelUpDown.Minimum = new System.Decimal(new int[] {
																				 1,
																				 0,
																				 0,
																				 0});
			this.YTicksPerLabelUpDown.Name = "YTicksPerLabelUpDown";
			this.YTicksPerLabelUpDown.Size = new System.Drawing.Size(144, 20);
			this.YTicksPerLabelUpDown.TabIndex = 23;
			this.YTicksPerLabelUpDown.Value = new System.Decimal(new int[] {
																			   1,
																			   0,
																			   0,
																			   0});
			this.YTicksPerLabelUpDown.ValueChanged += new System.EventHandler(this.YTicksPerLabelUpDown_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(137, 15);
			this.label2.TabIndex = 21;
			this.label2.Text = "Label Generation Mode:";
			// 
			// YLabelGenerationModeComboBox
			// 
			this.YLabelGenerationModeComboBox.Location = new System.Drawing.Point(16, 40);
			this.YLabelGenerationModeComboBox.Name = "YLabelGenerationModeComboBox";
			this.YLabelGenerationModeComboBox.Size = new System.Drawing.Size(144, 21);
			this.YLabelGenerationModeComboBox.TabIndex = 19;
			this.YLabelGenerationModeComboBox.SelectedIndexChanged += new System.EventHandler(this.YLabelGenerationModeComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.label4);
			this.nGroupBox2.Controls.Add(this.XLabelFitModesList);
			this.nGroupBox2.Controls.Add(this.label5);
			this.nGroupBox2.Controls.Add(this.XTicksPerLabelUpDown);
			this.nGroupBox2.Controls.Add(this.label6);
			this.nGroupBox2.Controls.Add(this.XLabelGenerationModeComboBox);
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(7, 349);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(172, 305);
			this.nGroupBox2.TabIndex = 23;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "X Axis Labels";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(13, 138);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(144, 15);
			this.label4.TabIndex = 32;
			this.label4.Text = "Label Fit Modes:";
			// 
			// XLabelFitModesList
			// 
			this.XLabelFitModesList.CheckBoxes = true;
			this.XLabelFitModesList.Location = new System.Drawing.Point(15, 154);
			this.XLabelFitModesList.Name = "XLabelFitModesList";
			this.XLabelFitModesList.Size = new System.Drawing.Size(144, 124);
			this.XLabelFitModesList.TabIndex = 31;
			this.XLabelFitModesList.CheckedChanged += new Nevron.UI.WinForm.Controls.NListBoxItemCheckedEventHandler(this.XLabelFitModesList_CheckedChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(15, 82);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(144, 15);
			this.label5.TabIndex = 30;
			this.label5.Text = "Number of Ticks per Label:";
			// 
			// XTicksPerLabelUpDown
			// 
			this.XTicksPerLabelUpDown.Location = new System.Drawing.Point(15, 99);
			this.XTicksPerLabelUpDown.Minimum = new System.Decimal(new int[] {
																				 1,
																				 0,
																				 0,
																				 0});
			this.XTicksPerLabelUpDown.Name = "XTicksPerLabelUpDown";
			this.XTicksPerLabelUpDown.Size = new System.Drawing.Size(144, 20);
			this.XTicksPerLabelUpDown.TabIndex = 29;
			this.XTicksPerLabelUpDown.Value = new System.Decimal(new int[] {
																			   1,
																			   0,
																			   0,
																			   0});
			this.XTicksPerLabelUpDown.ValueChanged += new System.EventHandler(this.XTicksPerLabelUpDown_ValueChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(15, 26);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(137, 15);
			this.label6.TabIndex = 28;
			this.label6.Text = "Label Generation Mode:";
			// 
			// XLabelGenerationModeComboBox
			// 
			this.XLabelGenerationModeComboBox.Location = new System.Drawing.Point(15, 42);
			this.XLabelGenerationModeComboBox.Name = "XLabelGenerationModeComboBox";
			this.XLabelGenerationModeComboBox.Size = new System.Drawing.Size(144, 21);
			this.XLabelGenerationModeComboBox.TabIndex = 27;
			this.XLabelGenerationModeComboBox.SelectedIndexChanged += new System.EventHandler(this.XLabelGenerationModeComboBox_SelectedIndexChanged);
			// 
			// NAxisLabelsUC
			// 
			this.Controls.Add(this.nGroupBox1);
			this.Controls.Add(this.nGroupBox2);
			this.Name = "NAxisLabelsUC";
			this.Size = new System.Drawing.Size(188, 665);
			this.nGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.YTicksPerLabelUpDown)).EndInit();
			this.nGroupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.XTicksPerLabelUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Axis Labels");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;

			NStandardScaleConfigurator scaleConfiguratorY = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleConfiguratorY.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleConfiguratorY.MaxTickCount = 50;

            // add interlaced stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            scaleConfiguratorY.StripStyles.Add(stripStyle);

			NStandardScaleConfigurator scaleConfiguratorX = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleConfiguratorX.MajorTickMode = MajorTickMode.AutoMaxCount;

			scaleConfiguratorX.AutoLabels = false;
			scaleConfiguratorX.Labels.Add("France");
			scaleConfiguratorX.Labels.Add("Italy");
			scaleConfiguratorX.Labels.Add("Germany");
			scaleConfiguratorX.Labels.Add("Norway");
			scaleConfiguratorX.Labels.Add("Spain");
			scaleConfiguratorX.Labels.Add("Belgium");
			scaleConfiguratorX.Labels.Add("Greece");
			scaleConfiguratorX.Labels.Add("Austria");
			scaleConfiguratorX.Labels.Add("Sweden");
			scaleConfiguratorX.Labels.Add("Finland");
			scaleConfiguratorX.Labels.Add("Poland");
			scaleConfiguratorX.Labels.Add("Denmark");

			NBarSeries series1 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			series1.FillStyle = new NColorFillStyle(Color.Crimson);
			series1.Name = "Product A";
			series1.DataLabelStyle.Visible = false;
			GenerateData(series1.Values, 12);

			NBarSeries series2 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			series2.MultiBarMode = MultiBarMode.Clustered;
			series2.FillStyle = new NColorFillStyle(Color.Gold);
			series2.Name = "Product B";
			series2.DataLabelStyle.Visible = false;
			GenerateData(series2.Values, 12);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			YTicksPerLabelUpDown.Value = 1;
			YLabelGenerationModeComboBox.FillFromEnum(typeof(LabelGenerationMode));
			YLabelGenerationModeComboBox.SelectedIndex = (int)LabelGenerationMode.SingleLevel; 
			YLabelFitModesList.FillFromEnum(typeof(LabelFitMode));
			YLabelFitModesList.Items[(int)LabelFitMode.AutoScale].Checked = true;

			XTicksPerLabelUpDown.Value = 1;
			XLabelGenerationModeComboBox.FillFromEnum(typeof(LabelGenerationMode));
			XLabelGenerationModeComboBox.SelectedIndex = (int)LabelGenerationMode.SingleLevel; 
			XLabelFitModesList.FillFromEnum(typeof(LabelFitMode));
			XLabelFitModesList.Items[(int)LabelFitMode.AutoScale].Checked = true;
		}

        private void GenerateData(NDataSeriesDouble dataSeries, int count)
		{
			for(int i = 0; i < count; i++)
			{
				dataSeries.Add(Random.NextDouble() * 99 + 1);
			}
		}

		private LabelFitMode[] GetLabelFitModesFromListBox(NListBox listBox)
		{
			ArrayList arrFitModes = new ArrayList();

			for(int i = 0; i < listBox.Items.Count; i++)
			{
				NListBoxItem item = listBox.Items[i];

				if(item.Checked)
					arrFitModes.Add((LabelFitMode)i);
			}

			return (LabelFitMode[])arrFitModes.ToArray(typeof(LabelFitMode));
		}


		private void YLabelGenerationModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (m_Chart == null)
				return;

			NStandardScaleConfigurator scaleConfiguratorY = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			scaleConfiguratorY.LabelGenerationMode = (LabelGenerationMode)YLabelGenerationModeComboBox.SelectedIndex;

			nChartControl1.Refresh();
		}

		private void YTicksPerLabelUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			if (m_Chart == null)
				return;

			NStandardScaleConfigurator scaleConfiguratorY = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			scaleConfiguratorY.NumberOfTicksPerLabel = (int)YTicksPerLabelUpDown.Value;

			nChartControl1.Refresh();
		}

		private void YLabelFitModesList_CheckedChanged(object sender, Nevron.UI.WinForm.Controls.NListBoxItemCheckEventArgs e)
		{
			if (m_Chart == null)
				return;

			NStandardScaleConfigurator scaleConfiguratorY = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			scaleConfiguratorY.LabelFitModes = GetLabelFitModesFromListBox(YLabelFitModesList);

			nChartControl1.Refresh();
		}

		private void XLabelGenerationModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (m_Chart == null)
				return;

			NStandardScaleConfigurator scaleConfiguratorX = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;

			scaleConfiguratorX.LabelGenerationMode = (LabelGenerationMode)XLabelGenerationModeComboBox.SelectedIndex;

			nChartControl1.Refresh();		
		}

		private void XTicksPerLabelUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			if (m_Chart == null)
				return;

			NStandardScaleConfigurator scaleConfiguratorX = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;

			scaleConfiguratorX.NumberOfTicksPerLabel = (int)XTicksPerLabelUpDown.Value;

			nChartControl1.Refresh();
		}

		private void XLabelFitModesList_CheckedChanged(object sender, Nevron.UI.WinForm.Controls.NListBoxItemCheckEventArgs e)
		{
			if (m_Chart == null)
				return;

			NStandardScaleConfigurator scaleConfiguratorX = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;

			scaleConfiguratorX.LabelFitModes = GetLabelFitModesFromListBox(XLabelFitModesList);

			nChartControl1.Refresh();
		}
	}
}
