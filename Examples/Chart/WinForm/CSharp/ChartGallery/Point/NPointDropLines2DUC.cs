using Nevron.Chart;
using Nevron.Editors;
using Nevron.GraphicsCore;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NPointDropLines2DUC : NExampleBaseUC
	{
		private NPointSeries m_Point;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowVerticalDropLinesCheckBox;
		private Nevron.UI.WinForm.Controls.NComboBox VerticalDropLinesOriginModeComboBox;
		private Nevron.UI.WinForm.Controls.NButton VerticalDropLinesButton;
		private UI.WinForm.Controls.NNumericUpDown VerticalDropLinesOriginUpDown;
		private Label label3;
		private Label label1;
		private UI.WinForm.Controls.NNumericUpDown HorizontalDropLinesOriginUpDown;
		private UI.WinForm.Controls.NButton HorizontalDropLinesButton;
		private UI.WinForm.Controls.NCheckBox ShowHorizontalDropLinesCheckBox;
		private UI.WinForm.Controls.NComboBox HorizontalDropLinesOriginModeComboBox;
		private Label label2;
		private Label label4;
		private System.ComponentModel.Container components = null;

		public NPointDropLines2DUC()
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
			this.VerticalDropLinesOriginModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.ShowVerticalDropLinesCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.VerticalDropLinesButton = new Nevron.UI.WinForm.Controls.NButton();
			this.VerticalDropLinesOriginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.HorizontalDropLinesOriginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.HorizontalDropLinesButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ShowHorizontalDropLinesCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.HorizontalDropLinesOriginModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.VerticalDropLinesOriginUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.HorizontalDropLinesOriginUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// VerticalDropLinesOriginModeComboBox
			// 
			this.VerticalDropLinesOriginModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.VerticalDropLinesOriginModeComboBox.ListProperties.DataSource = null;
			this.VerticalDropLinesOriginModeComboBox.ListProperties.DisplayMember = "";
			this.VerticalDropLinesOriginModeComboBox.Location = new System.Drawing.Point(75, 43);
			this.VerticalDropLinesOriginModeComboBox.Name = "VerticalDropLinesOriginModeComboBox";
			this.VerticalDropLinesOriginModeComboBox.Size = new System.Drawing.Size(101, 21);
			this.VerticalDropLinesOriginModeComboBox.TabIndex = 2;
			this.VerticalDropLinesOriginModeComboBox.SelectedIndexChanged += new System.EventHandler(this.VerticalDropLinesOriginModeComboBox_SelectedIndexChanged);
			// 
			// ShowVerticalDropLinesCheckBox
			// 
			this.ShowVerticalDropLinesCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowVerticalDropLinesCheckBox.Location = new System.Drawing.Point(3, 16);
			this.ShowVerticalDropLinesCheckBox.Name = "ShowVerticalDropLinesCheckBox";
			this.ShowVerticalDropLinesCheckBox.Size = new System.Drawing.Size(172, 21);
			this.ShowVerticalDropLinesCheckBox.TabIndex = 0;
			this.ShowVerticalDropLinesCheckBox.Text = "Show Vertical Drop Lines";
			this.ShowVerticalDropLinesCheckBox.CheckedChanged += new System.EventHandler(this.ShowVerticalDropLinesCheckBox_CheckedChanged);
			// 
			// VerticalDropLinesButton
			// 
			this.VerticalDropLinesButton.Location = new System.Drawing.Point(4, 96);
			this.VerticalDropLinesButton.Name = "VerticalDropLinesButton";
			this.VerticalDropLinesButton.Size = new System.Drawing.Size(172, 23);
			this.VerticalDropLinesButton.TabIndex = 5;
			this.VerticalDropLinesButton.Text = "Vertical Drop Lines Stroke Style...";
			this.VerticalDropLinesButton.Click += new System.EventHandler(this.VerticalDropLinesButton_Click);
			// 
			// VerticalDropLinesOriginUpDown
			// 
			this.VerticalDropLinesOriginUpDown.DecimalPlaces = 5;
			this.VerticalDropLinesOriginUpDown.Location = new System.Drawing.Point(75, 67);
			this.VerticalDropLinesOriginUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.VerticalDropLinesOriginUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.VerticalDropLinesOriginUpDown.Name = "VerticalDropLinesOriginUpDown";
			this.VerticalDropLinesOriginUpDown.Size = new System.Drawing.Size(101, 20);
			this.VerticalDropLinesOriginUpDown.TabIndex = 4;
			this.VerticalDropLinesOriginUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.VerticalDropLinesOriginUpDown.ValueChanged += new System.EventHandler(this.VericalDropLinesOriginUpDown_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Origin Mode:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 74);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Origin:";
			// 
			// HorizontalDropLinesOriginUpDown
			// 
			this.HorizontalDropLinesOriginUpDown.DecimalPlaces = 5;
			this.HorizontalDropLinesOriginUpDown.Location = new System.Drawing.Point(77, 190);
			this.HorizontalDropLinesOriginUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.HorizontalDropLinesOriginUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.HorizontalDropLinesOriginUpDown.Name = "HorizontalDropLinesOriginUpDown";
			this.HorizontalDropLinesOriginUpDown.Size = new System.Drawing.Size(101, 20);
			this.HorizontalDropLinesOriginUpDown.TabIndex = 10;
			this.HorizontalDropLinesOriginUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.HorizontalDropLinesOriginUpDown.ValueChanged += new System.EventHandler(this.HorizontalDropLinesOriginUpDown_ValueChanged);
			// 
			// HorizontalDropLinesButton
			// 
			this.HorizontalDropLinesButton.Location = new System.Drawing.Point(6, 219);
			this.HorizontalDropLinesButton.Name = "HorizontalDropLinesButton";
			this.HorizontalDropLinesButton.Size = new System.Drawing.Size(172, 23);
			this.HorizontalDropLinesButton.TabIndex = 11;
			this.HorizontalDropLinesButton.Text = "Horizontal Drop Lines Stroke Style...";
			this.HorizontalDropLinesButton.Click += new System.EventHandler(this.HorizontalDropLinesButton_Click);
			// 
			// ShowHorizontalDropLinesCheckBox
			// 
			this.ShowHorizontalDropLinesCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowHorizontalDropLinesCheckBox.Location = new System.Drawing.Point(5, 139);
			this.ShowHorizontalDropLinesCheckBox.Name = "ShowHorizontalDropLinesCheckBox";
			this.ShowHorizontalDropLinesCheckBox.Size = new System.Drawing.Size(172, 21);
			this.ShowHorizontalDropLinesCheckBox.TabIndex = 6;
			this.ShowHorizontalDropLinesCheckBox.Text = "Show Horizontal Drop Lines";
			this.ShowHorizontalDropLinesCheckBox.CheckedChanged += new System.EventHandler(this.ShowHorizontalDropLinesCheckBox_CheckedChanged);
			// 
			// HorizontalDropLinesOriginModeComboBox
			// 
			this.HorizontalDropLinesOriginModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.HorizontalDropLinesOriginModeComboBox.ListProperties.DataSource = null;
			this.HorizontalDropLinesOriginModeComboBox.ListProperties.DisplayMember = "";
			this.HorizontalDropLinesOriginModeComboBox.Location = new System.Drawing.Point(77, 166);
			this.HorizontalDropLinesOriginModeComboBox.Name = "HorizontalDropLinesOriginModeComboBox";
			this.HorizontalDropLinesOriginModeComboBox.Size = new System.Drawing.Size(101, 21);
			this.HorizontalDropLinesOriginModeComboBox.TabIndex = 8;
			this.HorizontalDropLinesOriginModeComboBox.SelectedIndexChanged += new System.EventHandler(this.HorizontalDropLinesOriginModeComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 174);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Origin Mode:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(4, 197);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Origin:";
			// 
			// NPointDropLines2DUC
			// 
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.HorizontalDropLinesOriginUpDown);
			this.Controls.Add(this.HorizontalDropLinesButton);
			this.Controls.Add(this.ShowHorizontalDropLinesCheckBox);
			this.Controls.Add(this.HorizontalDropLinesOriginModeComboBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.VerticalDropLinesOriginUpDown);
			this.Controls.Add(this.VerticalDropLinesButton);
			this.Controls.Add(this.ShowVerticalDropLinesCheckBox);
			this.Controls.Add(this.VerticalDropLinesOriginModeComboBox);
			this.Name = "NPointDropLines2DUC";
			this.Size = new System.Drawing.Size(180, 320);
			((System.ComponentModel.ISupportInitialize)(this.VerticalDropLinesOriginUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.HorizontalDropLinesOriginUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("2D Point Chart Droplines");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

            // add interlace stripe
            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// setup point series
			m_Point = (NPointSeries)chart.Series.Add(SeriesType.Point);
			m_Point.Name = "Point Series";
			m_Point.InflateMargins = true;
			m_Point.UseXValues = true;
			m_Point.Size = new NLength(10, NGraphicsUnit.Point);
			m_Point.DataLabelStyle.Visible = false;

			for (int i = 0; i < 360; i += 5)
			{
				double value = Math.Sin(NMath.Degree2Rad * i) * 20;

				m_Point.XValues.Add(i);
				m_Point.Values.Add(value);
			}

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// init form controls
			ShowVerticalDropLinesCheckBox.Checked = true;
			HorizontalDropLinesOriginUpDown.Value = 0;
			VerticalDropLinesOriginModeComboBox.FillFromEnum(typeof(DropLineOriginMode));
			VerticalDropLinesOriginModeComboBox.SelectedIndex = (int)DropLineOriginMode.ScaleMin;

			ShowHorizontalDropLinesCheckBox.Checked = true;
			VerticalDropLinesOriginUpDown.Value = 0;
			HorizontalDropLinesOriginModeComboBox.FillFromEnum(typeof(DropLineOriginMode));
			HorizontalDropLinesOriginModeComboBox.SelectedIndex = (int)DropLineOriginMode.ScaleMin;
		}

		private void ShowVerticalDropLinesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (m_Point == null)
				return;

			m_Point.ShowVerticalDropLines = ShowVerticalDropLinesCheckBox.Checked;
			nChartControl1.Refresh();

			VerticalDropLinesOriginModeComboBox.Enabled = ShowVerticalDropLinesCheckBox.Checked;
			VerticalDropLinesOriginUpDown.Enabled = ShowVerticalDropLinesCheckBox.Checked;
			VerticalDropLinesButton.Enabled = ShowVerticalDropLinesCheckBox.Checked;
		}

		private void VerticalDropLinesOriginModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_Point == null)
				return;

			m_Point.VerticalDropLineOriginMode = (DropLineOriginMode)VerticalDropLinesOriginModeComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void VericalDropLinesOriginUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (m_Point == null)
				return;

			m_Point.VerticalDropLineOrigin = (double)VerticalDropLinesOriginUpDown.Value;
			nChartControl1.Refresh();
		}

		private void VerticalDropLinesButton_Click(object sender, EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Point.VerticalDropLinesStrokeStyle, out strokeStyleResult))
			{
				m_Point.VerticalDropLinesStrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void ShowHorizontalDropLinesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (m_Point == null)
				return;

			m_Point.ShowHorizontalDropLines = ShowHorizontalDropLinesCheckBox.Checked;
			nChartControl1.Refresh();

			HorizontalDropLinesOriginModeComboBox.Enabled = ShowHorizontalDropLinesCheckBox.Checked;
			HorizontalDropLinesOriginUpDown.Enabled = ShowHorizontalDropLinesCheckBox.Checked;
			HorizontalDropLinesButton.Enabled = ShowHorizontalDropLinesCheckBox.Checked;
		}

		private void HorizontalDropLinesOriginModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_Point == null)
				return;

			m_Point.HorizontalDropLineOriginMode = (DropLineOriginMode)HorizontalDropLinesOriginModeComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void HorizontalDropLinesOriginUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (m_Point == null)
				return;

			m_Point.HorizontalDropLineOrigin = (double)HorizontalDropLinesOriginUpDown.Value;
			nChartControl1.Refresh();
		}

		private void HorizontalDropLinesButton_Click(object sender, EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Point.HorizontalDropLinesStrokeStyle, out strokeStyleResult))
			{
				m_Point.HorizontalDropLinesStrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
	}
}