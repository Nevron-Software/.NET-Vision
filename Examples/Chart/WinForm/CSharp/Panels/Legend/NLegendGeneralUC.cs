using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NLegendGeneralUC : NExampleBaseUC
	{
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label8;
		private Nevron.UI.WinForm.Controls.NComboBox LegendModeComboBox;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NTextBox HeaderTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox FooterTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox ExpandModeComboBox;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RowCountUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ColCountUpDown;
		private Nevron.UI.WinForm.Controls.NComboBox PredefinedPositionsComboBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private Nevron.UI.WinForm.Controls.NButton AddCustomLegendMark;
		private Nevron.UI.WinForm.Controls.NButton DeleteCustomLegendMarkButton;
		private Nevron.UI.WinForm.Controls.NGroupBox ManualMarksGroupBox;
		private Nevron.UI.WinForm.Controls.NGroupBox TitlesGroupBox;
		private Nevron.UI.WinForm.Controls.NGroupBox LayoutGroupBox;
		private System.Windows.Forms.PropertyGrid LegendItemPropertyGrid;
		private Nevron.UI.WinForm.Controls.NComboBox CustomLegendMarksComboBox;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		public NLegend m_Legend;

		public NLegendGeneralUC()
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
			this.label8 = new System.Windows.Forms.Label();
			this.LegendModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.HeaderTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.FooterTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.ExpandModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.RowCountUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.ColCountUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.PredefinedPositionsComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.ManualMarksGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.CustomLegendMarksComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.LegendItemPropertyGrid = new System.Windows.Forms.PropertyGrid();
			this.DeleteCustomLegendMarkButton = new Nevron.UI.WinForm.Controls.NButton();
			this.AddCustomLegendMark = new Nevron.UI.WinForm.Controls.NButton();
			this.LayoutGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.TitlesGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			((System.ComponentModel.ISupportInitialize)(this.RowCountUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ColCountUpDown)).BeginInit();
			this.ManualMarksGroupBox.SuspendLayout();
			this.LayoutGroupBox.SuspendLayout();
			this.TitlesGroupBox.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label8.Location = new System.Drawing.Point(315, 174);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(105, 16);
			this.label8.TabIndex = 16;
			// 
			// LegendModeComboBox
			// 
			this.LegendModeComboBox.Location = new System.Drawing.Point(109, 3);
			this.LegendModeComboBox.Name = "LegendModeComboBox";
			this.LegendModeComboBox.Size = new System.Drawing.Size(155, 21);
			this.LegendModeComboBox.TabIndex = 34;
			this.LegendModeComboBox.SelectedIndexChanged += new System.EventHandler(this.LegendModeComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 15);
			this.label2.TabIndex = 35;
			this.label2.Text = "Legend mode:";
			// 
			// HeaderTextBox
			// 
			this.HeaderTextBox.Location = new System.Drawing.Point(90, 18);
			this.HeaderTextBox.Name = "HeaderTextBox";
			this.HeaderTextBox.Size = new System.Drawing.Size(157, 20);
			this.HeaderTextBox.TabIndex = 40;
			this.HeaderTextBox.Text = "";
			this.HeaderTextBox.TextChanged += new System.EventHandler(this.HeaderTextBox_TextChanged);
			// 
			// FooterTextBox
			// 
			this.FooterTextBox.Location = new System.Drawing.Point(90, 53);
			this.FooterTextBox.Name = "FooterTextBox";
			this.FooterTextBox.Size = new System.Drawing.Size(157, 20);
			this.FooterTextBox.TabIndex = 41;
			this.FooterTextBox.Text = "";
			this.FooterTextBox.TextChanged += new System.EventHandler(this.FooterTextBox_TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 23);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 15);
			this.label3.TabIndex = 42;
			this.label3.Text = "Header:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 57);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 15);
			this.label1.TabIndex = 43;
			this.label1.Text = "Footer:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ExpandModeComboBox
			// 
			this.ExpandModeComboBox.Location = new System.Drawing.Point(90, 19);
			this.ExpandModeComboBox.Name = "ExpandModeComboBox";
			this.ExpandModeComboBox.Size = new System.Drawing.Size(157, 21);
			this.ExpandModeComboBox.TabIndex = 45;
			this.ExpandModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ExpandModeComboBox_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 25);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 15);
			this.label4.TabIndex = 46;
			this.label4.Text = "Expand mode:";
			// 
			// RowCountUpDown
			// 
			this.RowCountUpDown.Location = new System.Drawing.Point(90, 49);
			this.RowCountUpDown.Minimum = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			this.RowCountUpDown.Name = "RowCountUpDown";
			this.RowCountUpDown.Size = new System.Drawing.Size(66, 20);
			this.RowCountUpDown.TabIndex = 47;
			this.RowCountUpDown.Value = new System.Decimal(new int[] {
																		 1,
																		 0,
																		 0,
																		 0});
			this.RowCountUpDown.ValueChanged += new System.EventHandler(this.RowCountUpDown_ValueChanged);
			// 
			// ColCountUpDown
			// 
			this.ColCountUpDown.Location = new System.Drawing.Point(90, 78);
			this.ColCountUpDown.Minimum = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			this.ColCountUpDown.Name = "ColCountUpDown";
			this.ColCountUpDown.Size = new System.Drawing.Size(66, 20);
			this.ColCountUpDown.TabIndex = 48;
			this.ColCountUpDown.Value = new System.Decimal(new int[] {
																		 1,
																		 0,
																		 0,
																		 0});
			// 
			// PredefinedPositionsComboBox
			// 
			this.PredefinedPositionsComboBox.Location = new System.Drawing.Point(8, 21);
			this.PredefinedPositionsComboBox.Name = "PredefinedPositionsComboBox";
			this.PredefinedPositionsComboBox.Size = new System.Drawing.Size(242, 21);
			this.PredefinedPositionsComboBox.TabIndex = 49;
			this.PredefinedPositionsComboBox.SelectedIndexChanged += new System.EventHandler(this.PredefinedPositionsComboBox_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 83);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(75, 15);
			this.label5.TabIndex = 50;
			this.label5.Text = "Col count:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 54);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(61, 15);
			this.label6.TabIndex = 51;
			this.label6.Text = "Row count:";
			// 
			// ManualMarksGroupBox
			// 
			this.ManualMarksGroupBox.Controls.Add(this.CustomLegendMarksComboBox);
			this.ManualMarksGroupBox.Controls.Add(this.LegendItemPropertyGrid);
			this.ManualMarksGroupBox.Controls.Add(this.DeleteCustomLegendMarkButton);
			this.ManualMarksGroupBox.Controls.Add(this.AddCustomLegendMark);
			this.ManualMarksGroupBox.Location = new System.Drawing.Point(8, 33);
			this.ManualMarksGroupBox.Name = "ManualMarksGroupBox";
			this.ManualMarksGroupBox.Size = new System.Drawing.Size(256, 354);
			this.ManualMarksGroupBox.TabIndex = 55;
			this.ManualMarksGroupBox.TabStop = false;
			this.ManualMarksGroupBox.Text = "Custom Legend Data";
			// 
			// CustomLegendMarksComboBox
			// 
			this.CustomLegendMarksComboBox.Location = new System.Drawing.Point(8, 17);
			this.CustomLegendMarksComboBox.Name = "CustomLegendMarksComboBox";
			this.CustomLegendMarksComboBox.Size = new System.Drawing.Size(242, 21);
			this.CustomLegendMarksComboBox.TabIndex = 60;
			this.CustomLegendMarksComboBox.SelectedIndexChanged += new System.EventHandler(this.CustomLegendMarksComboBox_SelectedIndexChanged);
			// 
			// LegendItemPropertyGrid
			// 
			this.LegendItemPropertyGrid.CommandsVisibleIfAvailable = true;
			this.LegendItemPropertyGrid.LargeButtons = false;
			this.LegendItemPropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.LegendItemPropertyGrid.Location = new System.Drawing.Point(8, 75);
			this.LegendItemPropertyGrid.Name = "LegendItemPropertyGrid";
			this.LegendItemPropertyGrid.Size = new System.Drawing.Size(242, 271);
			this.LegendItemPropertyGrid.TabIndex = 59;
			this.LegendItemPropertyGrid.Text = "propertyGrid1";
			this.LegendItemPropertyGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.LegendItemPropertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			this.LegendItemPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.LegendItemPropertyGrid_PropertyValueChanged);
			// 
			// DeleteCustomLegendMarkButton
			// 
			this.DeleteCustomLegendMarkButton.Location = new System.Drawing.Point(196, 44);
			this.DeleteCustomLegendMarkButton.Name = "DeleteCustomLegendMarkButton";
			this.DeleteCustomLegendMarkButton.Size = new System.Drawing.Size(53, 23);
			this.DeleteCustomLegendMarkButton.TabIndex = 58;
			this.DeleteCustomLegendMarkButton.Text = "Delete";
			this.DeleteCustomLegendMarkButton.Click += new System.EventHandler(this.DeleteCustomLegendMarkButton_Click);
			// 
			// AddCustomLegendMark
			// 
			this.AddCustomLegendMark.Location = new System.Drawing.Point(140, 44);
			this.AddCustomLegendMark.Name = "AddCustomLegendMark";
			this.AddCustomLegendMark.Size = new System.Drawing.Size(53, 23);
			this.AddCustomLegendMark.TabIndex = 57;
			this.AddCustomLegendMark.Text = "Add";
			this.AddCustomLegendMark.Click += new System.EventHandler(this.AddCustomLegendMark_Click);
			// 
			// LayoutGroupBox
			// 
			this.LayoutGroupBox.Controls.Add(this.ExpandModeComboBox);
			this.LayoutGroupBox.Controls.Add(this.label4);
			this.LayoutGroupBox.Controls.Add(this.label6);
			this.LayoutGroupBox.Controls.Add(this.RowCountUpDown);
			this.LayoutGroupBox.Controls.Add(this.label5);
			this.LayoutGroupBox.Controls.Add(this.ColCountUpDown);
			this.LayoutGroupBox.Location = new System.Drawing.Point(8, 482);
			this.LayoutGroupBox.Name = "LayoutGroupBox";
			this.LayoutGroupBox.Size = new System.Drawing.Size(256, 110);
			this.LayoutGroupBox.TabIndex = 56;
			this.LayoutGroupBox.TabStop = false;
			this.LayoutGroupBox.Text = "Layout";
			// 
			// TitlesGroupBox
			// 
			this.TitlesGroupBox.Controls.Add(this.label3);
			this.TitlesGroupBox.Controls.Add(this.label1);
			this.TitlesGroupBox.Controls.Add(this.FooterTextBox);
			this.TitlesGroupBox.Controls.Add(this.HeaderTextBox);
			this.TitlesGroupBox.Location = new System.Drawing.Point(8, 392);
			this.TitlesGroupBox.Name = "TitlesGroupBox";
			this.TitlesGroupBox.Size = new System.Drawing.Size(256, 87);
			this.TitlesGroupBox.TabIndex = 57;
			this.TitlesGroupBox.TabStop = false;
			this.TitlesGroupBox.Text = "Titles";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.PredefinedPositionsComboBox);
			this.groupBox1.Location = new System.Drawing.Point(8, 598);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(256, 49);
			this.groupBox1.TabIndex = 58;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Predefined style";
			// 
			// NLegendGeneralUC
			// 
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.TitlesGroupBox);
			this.Controls.Add(this.LayoutGroupBox);
			this.Controls.Add(this.ManualMarksGroupBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.LegendModeComboBox);
			this.Controls.Add(this.label8);
			this.Name = "NLegendGeneralUC";
			this.Size = new System.Drawing.Size(271, 656);
			((System.ComponentModel.ISupportInitialize)(this.RowCountUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ColCountUpDown)).EndInit();
			this.ManualMarksGroupBox.ResumeLayout(false);
			this.LayoutGroupBox.ResumeLayout(false);
			this.TitlesGroupBox.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

            nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Legend General");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // create a simple pie chart 
            NChart chart = new NPieChart();
			chart.Enable3D = true;
            nChartControl1.Charts.Add(chart);
            chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);
            chart.BoundsMode = BoundsMode.None;
            chart.DisplayOnLegend = m_Legend;

            NPieSeries pie = (NPieSeries)chart.Series.Add(SeriesType.Pie);
            pie.LabelMode = PieLabelMode.Center;
            pie.Legend.Mode = SeriesLegendMode.DataPoints;
            pie.Legend.Format = "<label> <percent>";

            pie.AddDataPoint(new NDataPoint(12, "Cars"));
            pie.AddDataPoint(new NDataPoint(42, "Trains"));
            pie.AddDataPoint(new NDataPoint(36, "Airplanes"));
            pie.AddDataPoint(new NDataPoint(23, "Buses"));
            pie.AddDataPoint(new NDataPoint(29, "Ships"));
            pie.AddDataPoint(new NDataPoint(15, "Other"));

            // create a legend
            m_Legend = new NLegend();
            nChartControl1.Panels.Add(m_Legend);

            // tell the chart do display data on it
            chart.DisplayOnLegend = m_Legend;

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

            // init form controls
			LegendModeComboBox.Items.Add("Disabled");
			LegendModeComboBox.Items.Add("Automatic");
			LegendModeComboBox.Items.Add("Manual");

			PredefinedPositionsComboBox.Items.Add("Top");
			PredefinedPositionsComboBox.Items.Add("Bottom");
			PredefinedPositionsComboBox.Items.Add("Left");
			PredefinedPositionsComboBox.Items.Add("Right");
			PredefinedPositionsComboBox.Items.Add("Top right");
			PredefinedPositionsComboBox.Items.Add("Top left");

			ExpandModeComboBox.Items.Add("Rows only");
			ExpandModeComboBox.Items.Add("Cols only");
			ExpandModeComboBox.Items.Add("Rows fixed");
			ExpandModeComboBox.Items.Add("Cols fixed");

			if (m_Legend.Mode != LegendMode.Manual)
			{
				ManualMarksGroupBox.Enabled = false;
			}

			UpdateControlsFromLegend();
			PredefinedPositionsComboBox.SelectedIndex = 4;
		}

		private void UpdateControlsFromLegend()
		{
			LegendModeComboBox.SelectedIndex = (int)m_Legend.Mode;
			HeaderTextBox.Text = m_Legend.Header.Text;
			FooterTextBox.Text = m_Legend.Footer.Text;
			ExpandModeComboBox.SelectedIndex  = (int)m_Legend.Data.ExpandMode;
			RowCountUpDown.Value = m_Legend.Data.RowCount;
			ColCountUpDown.Value = m_Legend.Data.ColCount;
		}

		private NLegendItemCellData GetSelectedMark()
		{
			int nIndex = CustomLegendMarksComboBox.SelectedIndex;

			if (nIndex < 0)
				return null;
			
			return (NLegendItemCellData)(m_Legend.Data.Items[nIndex]);
		}

		private void LegendModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_Legend.Mode = ((LegendMode)LegendModeComboBox.SelectedIndex);

			if (m_Legend.Mode != LegendMode.Manual)
			{
				ManualMarksGroupBox.Enabled = false;
				CustomLegendMarksComboBox.Items.Clear();
				LegendItemPropertyGrid.SelectedObject = null;
			}
			else
			{
				ManualMarksGroupBox.Enabled = true;
			}

			nChartControl1.Refresh();
		}

		private void ExpandModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_Legend.Data.ExpandMode = (LegendExpandMode)ExpandModeComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void HeaderTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_Legend.Header.Text = HeaderTextBox.Text;
			nChartControl1.Refresh();
		}

		private void FooterTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_Legend.Footer.Text = FooterTextBox.Text;
			nChartControl1.Refresh();
		}

		private void PredefinedPositionsComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_Legend.SetPredefinedLegendStyle((PredefinedLegendStyle)PredefinedPositionsComboBox.SelectedIndex);
			UpdateControlsFromLegend();
			nChartControl1.Refresh();
		}

		private void RowCountUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_Legend.Data.RowCount = (int)RowCountUpDown.Value;
			nChartControl1.Refresh();
		}

		private void ColCountUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_Legend.Data.ColCount = (int)ColCountUpDown.Value;
			nChartControl1.Refresh();
		}

		private void AddCustomLegendMark_Click(object sender, System.EventArgs e)
		{
			NLegendItemCellData legendDataItem = new NLegendItemCellData();
			legendDataItem.Text = "Data item " + CustomLegendMarksComboBox.Items.Count.ToString();

			m_Legend.Data.Items.Add(legendDataItem);

			CustomLegendMarksComboBox.Items.Add(legendDataItem.Text);
			CustomLegendMarksComboBox.SelectedIndex = CustomLegendMarksComboBox.Items.Count - 1;
			LegendItemPropertyGrid.Enabled = true;

			nChartControl1.Refresh();
		}

		private void DeleteCustomLegendMarkButton_Click(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			int nIndex = CustomLegendMarksComboBox.SelectedIndex;

			if (nIndex == -1)
				return;

			CustomLegendMarksComboBox.Items.RemoveAt(nIndex);
			m_Legend.Data.Items.RemoveAt(nIndex);

			nIndex--;

			if (nIndex < 0)
				nIndex = CustomLegendMarksComboBox.Items.Count - 1;
			
			CustomLegendMarksComboBox.SelectedIndex = nIndex;
			LegendItemPropertyGrid.SelectedObject = GetSelectedMark();
			LegendItemPropertyGrid.Enabled = (LegendItemPropertyGrid.SelectedObject != null);
			
			nChartControl1.Refresh();
		}

		private void CustomLegendMarksComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			LegendItemPropertyGrid.SelectedObject = GetSelectedMark();
		}

		private void LegendItemPropertyGrid_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
		{
			if (nChartControl1 == null)
				return;

			nChartControl1.Refresh();
		}
	}
}
