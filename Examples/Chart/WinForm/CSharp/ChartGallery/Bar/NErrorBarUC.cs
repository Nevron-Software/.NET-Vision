using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Nevron.UI;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NErrorBarUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowLowerErrorCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowUpperErrorCheckBox;
		private Nevron.UI.WinForm.Controls.NHScrollBar WidthScroll;
		private Nevron.UI.WinForm.Controls.NButton ErrorStrokeStyleButton;
		private UI.WinForm.Controls.NCheckBox Enable3DCheckBox;
		private System.ComponentModel.IContainer components = null;

		private NBarSeries m_BarSeries;
		private NChart m_Chart;


		public NErrorBarUC()
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
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ShowLowerErrorCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowUpperErrorCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.WidthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.ErrorStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.Enable3DCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// ShowLowerErrorCheckBox
			// 
			this.ShowLowerErrorCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowLowerErrorCheckBox.Location = new System.Drawing.Point(8, 31);
			this.ShowLowerErrorCheckBox.Name = "ShowLowerErrorCheckBox";
			this.ShowLowerErrorCheckBox.Size = new System.Drawing.Size(163, 24);
			this.ShowLowerErrorCheckBox.TabIndex = 1;
			this.ShowLowerErrorCheckBox.Text = "Show Lower Error";
			this.ShowLowerErrorCheckBox.CheckedChanged += new System.EventHandler(this.ShowLowerErrorCheckBox_CheckedChanged);
			// 
			// ShowUpperErrorCheckBox
			// 
			this.ShowUpperErrorCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowUpperErrorCheckBox.Location = new System.Drawing.Point(8, 8);
			this.ShowUpperErrorCheckBox.Name = "ShowUpperErrorCheckBox";
			this.ShowUpperErrorCheckBox.Size = new System.Drawing.Size(163, 21);
			this.ShowUpperErrorCheckBox.TabIndex = 0;
			this.ShowUpperErrorCheckBox.Text = "Show Upper Error";
			this.ShowUpperErrorCheckBox.CheckedChanged += new System.EventHandler(this.ShowUpperErrorCheckBox_CheckedChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 122);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(163, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Error Width %:";
			// 
			// WidthScroll
			// 
			this.WidthScroll.Location = new System.Drawing.Point(8, 138);
			this.WidthScroll.Maximum = 110;
			this.WidthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.WidthScroll.Name = "WidthScroll";
			this.WidthScroll.Size = new System.Drawing.Size(163, 16);
			this.WidthScroll.TabIndex = 5;
			this.WidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WidthScroll_ValueChanged);
			// 
			// ErrorStrokeStyleButton
			// 
			this.ErrorStrokeStyleButton.Location = new System.Drawing.Point(8, 89);
			this.ErrorStrokeStyleButton.Name = "ErrorStrokeStyleButton";
			this.ErrorStrokeStyleButton.Size = new System.Drawing.Size(163, 24);
			this.ErrorStrokeStyleButton.TabIndex = 3;
			this.ErrorStrokeStyleButton.Text = "Error Stroke Style...";
			this.ErrorStrokeStyleButton.Click += new System.EventHandler(this.ErrorStrokeStyleButton_Click);
			// 
			// Enable3DCheckBox
			// 
			this.Enable3DCheckBox.ButtonProperties.BorderOffset = 2;
			this.Enable3DCheckBox.Location = new System.Drawing.Point(8, 57);
			this.Enable3DCheckBox.Name = "Enable3DCheckBox";
			this.Enable3DCheckBox.Size = new System.Drawing.Size(163, 24);
			this.Enable3DCheckBox.TabIndex = 2;
			this.Enable3DCheckBox.Text = "Enable 3D";
			this.Enable3DCheckBox.CheckedChanged += new System.EventHandler(this.Enable3DCheckBox_CheckedChanged);
			// 
			// NErrorBarUC
			// 
			this.Controls.Add(this.Enable3DCheckBox);
			this.Controls.Add(this.ShowLowerErrorCheckBox);
			this.Controls.Add(this.ShowUpperErrorCheckBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.WidthScroll);
			this.Controls.Add(this.ErrorStrokeStyleButton);
			this.Name = "NErrorBarUC";
			this.Size = new System.Drawing.Size(180, 505);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// create a title
			NLabel title = new NLabel("Error Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure chart
			NChart chart = nChartControl1.Charts[0];
			m_Chart = chart;
			chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlace stripe
            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// setup a bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar Series";
			bar.DataLabelStyle.Visible = false;
			bar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			bar.ShadowStyle.Type = ShadowType.GaussianBlur;
			bar.ShadowStyle.Offset = new NPointL(2, 2);
			bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
			bar.ShadowStyle.FadeLength = new NLength(5);
			bar.HasBottomEdge = false;

			// add some data to the bar series
			bar.Values.Add(15);
			bar.UpperErrors.Add(2);
			bar.LowerErrors.Add(1);

			bar.Values.Add(21);
			bar.UpperErrors.Add(2.4);
			bar.LowerErrors.Add(1.3);

			bar.Values.Add(23);
			bar.UpperErrors.Add(3.2);
			bar.LowerErrors.Add(1.7);

			bar.Values.Add(27);
			bar.UpperErrors.Add(1.4);
			bar.LowerErrors.Add(2.5);

			bar.Values.Add(29);
			bar.UpperErrors.Add(4.0);
			bar.LowerErrors.Add(2.0);

			bar.Values.Add(26);
			bar.UpperErrors.Add(2.1);
			bar.LowerErrors.Add(1.6);

			m_BarSeries = bar;

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// init form controls
			ShowUpperErrorCheckBox.Checked = true;
			ShowLowerErrorCheckBox.Checked = true;
			WidthScroll.Value = (int)bar.ErrorWidthPercent;
		}

		private void ShowUpperErrorCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_BarSeries.ShowUpperError = ShowUpperErrorCheckBox.Checked;
			nChartControl1.Refresh();
		}

		private void ShowLowerErrorCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_BarSeries.ShowLowerError = ShowLowerErrorCheckBox.Checked;
			nChartControl1.Refresh();
		}

		private void Enable3DCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_Chart.Enable3D = Enable3DCheckBox.Checked;
			nChartControl1.Refresh();
		}

		private void ErrorStrokeStyleButton_Click(object sender, EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_BarSeries.ErrorStrokeStyle, out strokeStyleResult))
			{
				m_BarSeries.ErrorStrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void WidthScroll_ValueChanged(object sender, UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_BarSeries.ErrorWidthPercent = WidthScroll.Value;
			nChartControl1.Refresh();
		}
	}
}