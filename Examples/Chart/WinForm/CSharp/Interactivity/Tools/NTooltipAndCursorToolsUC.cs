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
	public class NTooltipAndCursorToolsUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBarSeries m_Bar;
		private bool m_bUpdating;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private Nevron.UI.WinForm.Controls.NComboBox ChartObjectComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox CursorComboBox;
		private Nevron.UI.WinForm.Controls.NCheckBox CursorChangeCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableTooltipChangeCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox UseWindowRenderSurfaceCheckBox;
		private Nevron.UI.WinForm.Controls.NTextBox TooltipTextBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown AutoPopDelayUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ReshowDelayUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown InitialDelayUpDown;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private System.ComponentModel.Container components = null;

		public NTooltipAndCursorToolsUC()
		{
			m_bUpdating = true;
			InitializeComponent();

			m_bUpdating = false;
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.ChartObjectComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.CursorComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.TooltipTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.CursorChangeCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.EnableTooltipChangeCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.AutoPopDelayUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.InitialDelayUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.ReshowDelayUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.UseWindowRenderSurfaceCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			((System.ComponentModel.ISupportInitialize)(this.AutoPopDelayUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.InitialDelayUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ReshowDelayUpDown)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Chart object:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(157, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Tooltip:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(152, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Cursor:";
			// 
			// ChartObjectComboBox
			// 
			this.ChartObjectComboBox.ListProperties.CheckBoxDataMember = "";
			this.ChartObjectComboBox.ListProperties.DataSource = null;
			this.ChartObjectComboBox.ListProperties.DisplayMember = "";
			this.ChartObjectComboBox.Location = new System.Drawing.Point(11, 30);
			this.ChartObjectComboBox.Name = "ChartObjectComboBox";
			this.ChartObjectComboBox.Size = new System.Drawing.Size(157, 21);
			this.ChartObjectComboBox.TabIndex = 3;
			this.ChartObjectComboBox.SelectedIndexChanged += new System.EventHandler(this.ChartObjectComboBox_SelectedIndexChanged);
			// 
			// CursorComboBox
			// 
			this.CursorComboBox.ListProperties.CheckBoxDataMember = "";
			this.CursorComboBox.ListProperties.DataSource = null;
			this.CursorComboBox.ListProperties.DisplayMember = "";
			this.CursorComboBox.Location = new System.Drawing.Point(6, 56);
			this.CursorComboBox.Name = "CursorComboBox";
			this.CursorComboBox.Size = new System.Drawing.Size(157, 21);
			this.CursorComboBox.TabIndex = 4;
			this.CursorComboBox.SelectedIndexChanged += new System.EventHandler(this.CursorComboBox_SelectedIndexChanged);
			// 
			// TooltipTextBox
			// 
			this.TooltipTextBox.Location = new System.Drawing.Point(6, 65);
			this.TooltipTextBox.Name = "TooltipTextBox";
			this.TooltipTextBox.Size = new System.Drawing.Size(157, 18);
			this.TooltipTextBox.TabIndex = 5;
			this.TooltipTextBox.TextChanged += new System.EventHandler(this.TooltipTextBox_TextChanged);
			// 
			// CursorChangeCheckBox
			// 
			this.CursorChangeCheckBox.ButtonProperties.BorderOffset = 2;
			this.CursorChangeCheckBox.Location = new System.Drawing.Point(6, 16);
			this.CursorChangeCheckBox.Name = "CursorChangeCheckBox";
			this.CursorChangeCheckBox.Size = new System.Drawing.Size(152, 24);
			this.CursorChangeCheckBox.TabIndex = 6;
			this.CursorChangeCheckBox.Text = "Enable cursor change";
			this.CursorChangeCheckBox.CheckedChanged += new System.EventHandler(this.CursorChangeCheckBox_CheckedChanged);
			// 
			// EnableTooltipChangeCheckBox
			// 
			this.EnableTooltipChangeCheckBox.ButtonProperties.BorderOffset = 2;
			this.EnableTooltipChangeCheckBox.Location = new System.Drawing.Point(6, 17);
			this.EnableTooltipChangeCheckBox.Name = "EnableTooltipChangeCheckBox";
			this.EnableTooltipChangeCheckBox.Size = new System.Drawing.Size(157, 24);
			this.EnableTooltipChangeCheckBox.TabIndex = 7;
			this.EnableTooltipChangeCheckBox.Text = "Enable tooltip change";
			this.EnableTooltipChangeCheckBox.CheckedChanged += new System.EventHandler(this.EnableTooltipChangeCheckBox_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 89);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(157, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "Auto pop delay (ms):";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 133);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(157, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "Initial delay (ms):";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 177);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(157, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "Reshow delay (ms):";
			// 
			// AutoPopDelayUpDown
			// 
			this.AutoPopDelayUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.AutoPopDelayUpDown.Location = new System.Drawing.Point(6, 109);
			this.AutoPopDelayUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.AutoPopDelayUpDown.Name = "AutoPopDelayUpDown";
			this.AutoPopDelayUpDown.Size = new System.Drawing.Size(157, 20);
			this.AutoPopDelayUpDown.TabIndex = 11;
			this.AutoPopDelayUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.AutoPopDelayUpDown.ValueChanged += new System.EventHandler(this.AutoPopDelayUpDown_ValueChanged);
			// 
			// InitialDelayUpDown
			// 
			this.InitialDelayUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.InitialDelayUpDown.Location = new System.Drawing.Point(6, 153);
			this.InitialDelayUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.InitialDelayUpDown.Name = "InitialDelayUpDown";
			this.InitialDelayUpDown.Size = new System.Drawing.Size(157, 20);
			this.InitialDelayUpDown.TabIndex = 12;
			this.InitialDelayUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.InitialDelayUpDown.ValueChanged += new System.EventHandler(this.InitialDelayUpDown_ValueChanged);
			// 
			// ReshowDelayUpDown
			// 
			this.ReshowDelayUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.ReshowDelayUpDown.Location = new System.Drawing.Point(6, 197);
			this.ReshowDelayUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.ReshowDelayUpDown.Name = "ReshowDelayUpDown";
			this.ReshowDelayUpDown.Size = new System.Drawing.Size(157, 20);
			this.ReshowDelayUpDown.TabIndex = 13;
			this.ReshowDelayUpDown.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
			this.ReshowDelayUpDown.ValueChanged += new System.EventHandler(this.ReshowDelayUpDown_ValueChanged);
			// 
			// UseWindowRenderSurfaceCheckBox
			// 
			this.UseWindowRenderSurfaceCheckBox.ButtonProperties.BorderOffset = 2;
			this.UseWindowRenderSurfaceCheckBox.Location = new System.Drawing.Point(11, 383);
			this.UseWindowRenderSurfaceCheckBox.Name = "UseWindowRenderSurfaceCheckBox";
			this.UseWindowRenderSurfaceCheckBox.Size = new System.Drawing.Size(120, 24);
			this.UseWindowRenderSurfaceCheckBox.TabIndex = 16;
			this.UseWindowRenderSurfaceCheckBox.Text = "Render to window";
			this.UseWindowRenderSurfaceCheckBox.CheckedChanged += new System.EventHandler(this.UseWindowRenderSurfaceCheckBox_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.CursorComboBox);
			this.groupBox1.Controls.Add(this.CursorChangeCheckBox);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(5, 55);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(172, 89);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Mouse cursor";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.TooltipTextBox);
			this.groupBox2.Controls.Add(this.EnableTooltipChangeCheckBox);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.AutoPopDelayUpDown);
			this.groupBox2.Controls.Add(this.InitialDelayUpDown);
			this.groupBox2.Controls.Add(this.ReshowDelayUpDown);
			this.groupBox2.Location = new System.Drawing.Point(4, 148);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(174, 229);
			this.groupBox2.TabIndex = 18;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tooltips";
			// 
			// NTooltipAndCursorToolsUC
			// 
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.UseWindowRenderSurfaceCheckBox);
			this.Controls.Add(this.ChartObjectComboBox);
			this.Controls.Add(this.label1);
			this.Name = "NTooltipAndCursorToolsUC";
			this.Size = new System.Drawing.Size(180, 645);
			((System.ComponentModel.ISupportInitialize)(this.AutoPopDelayUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.InitialDelayUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ReshowDelayUpDown)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Tooltips and Cursor");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// init the values for the tooltip properties
			NTooltipTool tooltip = new NTooltipTool();
			AutoPopDelayUpDown.Value = tooltip.AutoPopDelay;
			InitialDelayUpDown.Value = tooltip.InitialDelay;
			ReshowDelayUpDown.Value = tooltip.ReshowDelay;

			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// Add stripes for the left and the bottom axes
			NAxisStripe s1 = m_Chart.Axis(StandardAxis.PrimaryY).Stripes.Add(50, 60);
			NAxisStripe s2 = m_Chart.Axis(StandardAxis.PrimaryX).Stripes.Add(2, 3);
			s1.FillStyle = new NColorFillStyle(Color.CornflowerBlue);
			s1.SetShowAtWall(ChartWallType.Left, true);
			s2.FillStyle = new NColorFillStyle(Color.DarkOrange);

			// Create a bar series
			m_Bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);

			m_Bar.BarShape = BarShape.Bar;
			m_Bar.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Bar.Values.Add(20.0);
			m_Bar.Values.Add(60.0);
			m_Bar.Values.Add(50.0);
			m_Bar.Values.Add(80.0);
			m_Bar.Values.Add(60.0);

			m_Bar.InteractivityStyles.Add(0, new NInteractivityStyle("Data item 0", CursorType.Default));
			m_Bar.InteractivityStyles.Add(1, new NInteractivityStyle("Data item 1", CursorType.Default));
			m_Bar.InteractivityStyles.Add(2, new NInteractivityStyle("Data item 2", CursorType.Default));
			m_Bar.InteractivityStyles.Add(3, new NInteractivityStyle("Data item 3", CursorType.Default));
			m_Bar.InteractivityStyles.Add(4, new NInteractivityStyle("Data item 4", CursorType.Default));

			// set some fill styles in the collection.
			NFillStyle fillStyle;

			fillStyle = new NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant3, Color.Chocolate, Color.WhiteSmoke);
			m_Bar.FillStyles.Add(0, fillStyle);

			fillStyle = new NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant3, Color.Goldenrod, Color.WhiteSmoke);
			m_Bar.FillStyles.Add(1, fillStyle);

			fillStyle = new NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant3, Color.OliveDrab, Color.WhiteSmoke);
			m_Bar.FillStyles.Add(2, fillStyle);

			fillStyle = new NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant3, Color.SteelBlue, Color.WhiteSmoke);
			m_Bar.FillStyles.Add(3, fillStyle);

			fillStyle = new NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant3, Color.BlueViolet, Color.WhiteSmoke);
			m_Bar.FillStyles.Add(4, fillStyle);

			// init form controls
			EnableTooltipChangeCheckBox.Checked = true;
			CursorChangeCheckBox.Checked = true;
			
			ChartObjectComboBox.Items.Add("Background");
			ChartObjectComboBox.Items.Add("Back chart wall");
			ChartObjectComboBox.Items.Add("Left chart wall");
			ChartObjectComboBox.Items.Add("Floor chart wall");
			ChartObjectComboBox.Items.Add("Primary Y axis");
			ChartObjectComboBox.Items.Add("Primary X axis");
			ChartObjectComboBox.Items.Add("Horizontal stripe");
			ChartObjectComboBox.Items.Add("Vertical stripe");
			ChartObjectComboBox.Items.Add("Legend");
			ChartObjectComboBox.Items.Add("Data item 0");
			ChartObjectComboBox.Items.Add("Data item 1");
			ChartObjectComboBox.Items.Add("Data item 2");
			ChartObjectComboBox.Items.Add("Data item 3");
			ChartObjectComboBox.Items.Add("Data item 4");
			ChartObjectComboBox.SelectedIndex = 0;

            CursorComboBox.FillFromEnum(typeof(CursorType));
            CursorComboBox.SelectedIndex = 0;
		}


		private void UpdateChartInteractivity()
		{
			if (nChartControl1 == null)
				return;

			nChartControl1.Controller.Tools.Clear();

			if (EnableTooltipChangeCheckBox.Checked == true)
			{
				NTooltipTool tooltip = new NTooltipTool();

				tooltip.AutoPopDelay = (int)AutoPopDelayUpDown.Value;
				tooltip.ReshowDelay = (int)ReshowDelayUpDown.Value;
				tooltip.InitialDelay = (int)InitialDelayUpDown.Value;

				nChartControl1.Controller.Tools.Add(tooltip);
			}

			if (CursorChangeCheckBox.Checked == true)
			{
				NCursorTool cursorTool = new NCursorTool();
				nChartControl1.Controller.Tools.Add(cursorTool);
			}
		}

		private NInteractivityStyle GetCurrentInteractivityStyle()
		{
			NInteractivityStyle interactivityStyle  = null;

			switch (ChartObjectComboBox.SelectedIndex)
			{
					// Background
				case 0:
					interactivityStyle = nChartControl1.InteractivityStyle;
					break;
					// Back chart wall
				case 1:
					interactivityStyle = m_Chart.Wall(ChartWallType.Back).InteractivityStyle;
					break;
					// Left chart wall
				case 2:
					interactivityStyle = m_Chart.Wall(ChartWallType.Left).InteractivityStyle;
					break;
					/// Floor chart wall
				case 3:
					interactivityStyle = m_Chart.Wall(ChartWallType.Floor).InteractivityStyle;
					break;
					// Primary Y axis
				case 4:
					interactivityStyle = m_Chart.Axis(StandardAxis.PrimaryY).InteractivityStyle;
					break;
					// Primary X axis
				case 5:
					interactivityStyle = m_Chart.Axis(StandardAxis.PrimaryX).InteractivityStyle;
					break;
					// Horizontal stripe
				case 6:
					interactivityStyle = ((NAxisStripe)(m_Chart.Axis(StandardAxis.PrimaryY).Stripes[0])).InteractivityStyle;
					break;
					// Vertical stripe
				case 7:
					interactivityStyle = ((NAxisStripe)(m_Chart.Axis(StandardAxis.PrimaryX).Stripes[0])).InteractivityStyle;
					break;
					// Legend
				case 8:
					interactivityStyle = ((NLegend)(nChartControl1.Legends[0])).InteractivityStyle;
					break;
				case 9: 
				case 10: 
				case 11:
				case 12:
				case 13:
					NSeries series = (NSeries)m_Chart.Series[0];
					interactivityStyle = (NInteractivityStyle)(series.InteractivityStyles[ChartObjectComboBox.SelectedIndex - 9]);

					break;
			}
			
			return interactivityStyle;
		}

		private void UpdateControls(bool bSave)
		{
			if (m_bUpdating == true)
				return;

			m_bUpdating = true;

			NInteractivityStyle interactivityStyle = GetCurrentInteractivityStyle();

			if (bSave)
			{
				interactivityStyle.Tooltip.Text = TooltipTextBox.Text;
				interactivityStyle.Cursor.Type = (CursorType)(CursorComboBox.SelectedIndex);
			}
			else
			{
				TooltipTextBox.Text = interactivityStyle.Tooltip.Text;
				CursorComboBox.SelectedIndex = (int)(interactivityStyle.Cursor.Type);
			}

			m_bUpdating = false;
		}

		private void EnableTooltipChangeCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateChartInteractivity();

			TooltipTextBox.Enabled = EnableTooltipChangeCheckBox.Checked;
			AutoPopDelayUpDown.Enabled = EnableTooltipChangeCheckBox.Checked;
			InitialDelayUpDown.Enabled = EnableTooltipChangeCheckBox.Checked;
			ReshowDelayUpDown.Enabled = EnableTooltipChangeCheckBox.Checked;
		}

		private void CursorChangeCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateChartInteractivity();

			CursorComboBox.Enabled = CursorChangeCheckBox.Checked;
		}

		private void AutoPopDelayUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateChartInteractivity();
		}

		private void InitialDelayUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateChartInteractivity();
		}

		private void ReshowDelayUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateChartInteractivity();
		}

		private void ChartObjectComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateControls(false);
		}

		private void TooltipTextBox_TextChanged(object sender, System.EventArgs e)
		{
			UpdateControls(true);
		}

		private void CursorComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateControls(true);
		}

		private void UseWindowRenderSurfaceCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			if(UseWindowRenderSurfaceCheckBox.Checked)
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			}
			else
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap;
			}
		}
	}
}
