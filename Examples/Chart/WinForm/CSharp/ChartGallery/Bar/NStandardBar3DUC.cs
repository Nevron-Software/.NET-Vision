using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NStandardBar3DUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private Nevron.UI.WinForm.Controls.NHScrollBar WidthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar DepthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar EdgePercentScrollBar;
		private Nevron.UI.WinForm.Controls.NCheckBox DifferentFillStyles;
		private Nevron.UI.WinForm.Controls.NCheckBox InvertAxisRuler;
		private Nevron.UI.WinForm.Controls.NCheckBox HasTopEdge;
		private Nevron.UI.WinForm.Controls.NCheckBox HasBottomEdge;
		private Nevron.UI.WinForm.Controls.NComboBox StyleCombo;
		private Nevron.UI.WinForm.Controls.NButton BarFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton BarBorderButton;
		private Nevron.UI.WinForm.Controls.NButton LabelStyleButton;
		private Nevron.UI.WinForm.Controls.NComboBox OriginModeCombo;
		private Nevron.UI.WinForm.Controls.NTextBox OriginValueTextBox;
		private System.ComponentModel.Container components = null;

		public NStandardBar3DUC()
		{
			InitializeComponent();

			OriginModeCombo.FillFromEnum(typeof(SeriesOriginMode));
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
			this.BarFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.StyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.WidthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.DepthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.DifferentFillStyles = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.InvertAxisRuler = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.EdgePercentScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label5 = new System.Windows.Forms.Label();
			this.HasTopEdge = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.HasBottomEdge = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.BarBorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.LabelStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label4 = new System.Windows.Forms.Label();
			this.OriginModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.OriginValueTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// BarFillStyleButton
			// 
			this.BarFillStyleButton.Location = new System.Drawing.Point(7, 178);
			this.BarFillStyleButton.Name = "BarFillStyleButton";
			this.BarFillStyleButton.Size = new System.Drawing.Size(165, 24);
			this.BarFillStyleButton.TabIndex = 7;
			this.BarFillStyleButton.Text = "Bar Fill Style...";
			this.BarFillStyleButton.Click += new System.EventHandler(this.BarFillStyleButton_Click);
			// 
			// StyleCombo
			// 
			this.StyleCombo.ListProperties.CheckBoxDataMember = "";
			this.StyleCombo.ListProperties.DataSource = null;
			this.StyleCombo.ListProperties.DisplayMember = "";
			this.StyleCombo.Location = new System.Drawing.Point(7, 23);
			this.StyleCombo.Name = "StyleCombo";
			this.StyleCombo.Size = new System.Drawing.Size(165, 21);
			this.StyleCombo.TabIndex = 1;
			this.StyleCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(165, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Bar Style:";
			// 
			// WidthScroll
			// 
			this.WidthScroll.Location = new System.Drawing.Point(7, 291);
			this.WidthScroll.Maximum = 110;
			this.WidthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.WidthScroll.Name = "WidthScroll";
			this.WidthScroll.Size = new System.Drawing.Size(165, 16);
			this.WidthScroll.TabIndex = 9;
			this.WidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WidthScroll_Scroll);
			// 
			// DepthScroll
			// 
			this.DepthScroll.Location = new System.Drawing.Point(7, 333);
			this.DepthScroll.Maximum = 110;
			this.DepthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.DepthScroll.Name = "DepthScroll";
			this.DepthScroll.Size = new System.Drawing.Size(165, 16);
			this.DepthScroll.TabIndex = 11;
			this.DepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.DepthScroll_Scroll);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 275);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(165, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "Width %:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 317);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(165, 16);
			this.label3.TabIndex = 10;
			this.label3.Text = "Depth %:";
			// 
			// DifferentFillStyles
			// 
			this.DifferentFillStyles.ButtonProperties.BorderOffset = 2;
			this.DifferentFillStyles.Location = new System.Drawing.Point(7, 149);
			this.DifferentFillStyles.Name = "DifferentFillStyles";
			this.DifferentFillStyles.Size = new System.Drawing.Size(165, 21);
			this.DifferentFillStyles.TabIndex = 6;
			this.DifferentFillStyles.Text = "Different Fill Styles";
			this.DifferentFillStyles.CheckedChanged += new System.EventHandler(this.DifferentFillStyles_CheckedChanged);
			// 
			// InvertAxisRuler
			// 
			this.InvertAxisRuler.ButtonProperties.BorderOffset = 2;
			this.InvertAxisRuler.Location = new System.Drawing.Point(8, 367);
			this.InvertAxisRuler.Name = "InvertAxisRuler";
			this.InvertAxisRuler.Size = new System.Drawing.Size(165, 19);
			this.InvertAxisRuler.TabIndex = 15;
			this.InvertAxisRuler.Text = "Invert Y Axis Ruler";
			this.InvertAxisRuler.CheckedChanged += new System.EventHandler(this.InvertAxisRuler_CheckedChanged);
			// 
			// EdgePercentScrollBar
			// 
			this.EdgePercentScrollBar.Enabled = false;
			this.EdgePercentScrollBar.Location = new System.Drawing.Point(7, 69);
			this.EdgePercentScrollBar.Maximum = 59;
			this.EdgePercentScrollBar.MinimumSize = new System.Drawing.Size(32, 16);
			this.EdgePercentScrollBar.Name = "EdgePercentScrollBar";
			this.EdgePercentScrollBar.Size = new System.Drawing.Size(165, 16);
			this.EdgePercentScrollBar.TabIndex = 3;
			this.EdgePercentScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.EdgePercentScrollBar_Scroll);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(7, 53);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(165, 14);
			this.label5.TabIndex = 2;
			this.label5.Text = "Edge %:";
			// 
			// HasTopEdge
			// 
			this.HasTopEdge.ButtonProperties.BorderOffset = 2;
			this.HasTopEdge.Enabled = false;
			this.HasTopEdge.Location = new System.Drawing.Point(7, 96);
			this.HasTopEdge.Name = "HasTopEdge";
			this.HasTopEdge.Size = new System.Drawing.Size(165, 20);
			this.HasTopEdge.TabIndex = 4;
			this.HasTopEdge.Text = "Has Top Edge";
			this.HasTopEdge.CheckedChanged += new System.EventHandler(this.HasTopEdge_CheckedChanged);
			// 
			// HasBottomEdge
			// 
			this.HasBottomEdge.ButtonProperties.BorderOffset = 2;
			this.HasBottomEdge.Enabled = false;
			this.HasBottomEdge.Location = new System.Drawing.Point(7, 120);
			this.HasBottomEdge.Name = "HasBottomEdge";
			this.HasBottomEdge.Size = new System.Drawing.Size(165, 24);
			this.HasBottomEdge.TabIndex = 5;
			this.HasBottomEdge.Text = "Has Bottom Edge";
			this.HasBottomEdge.CheckedChanged += new System.EventHandler(this.HasBottomEdge_CheckedChanged);
			// 
			// BarBorderButton
			// 
			this.BarBorderButton.Location = new System.Drawing.Point(7, 209);
			this.BarBorderButton.Name = "BarBorderButton";
			this.BarBorderButton.Size = new System.Drawing.Size(165, 24);
			this.BarBorderButton.TabIndex = 19;
			this.BarBorderButton.Text = "Bar Border...";
			this.BarBorderButton.Click += new System.EventHandler(this.BarBorderButton_Click);
			// 
			// LabelStyleButton
			// 
			this.LabelStyleButton.Location = new System.Drawing.Point(7, 240);
			this.LabelStyleButton.Name = "LabelStyleButton";
			this.LabelStyleButton.Size = new System.Drawing.Size(165, 24);
			this.LabelStyleButton.TabIndex = 36;
			this.LabelStyleButton.Text = "Data Label Style...";
			this.LabelStyleButton.Click += new System.EventHandler(this.LabelStyleButton_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 397);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(165, 20);
			this.label4.TabIndex = 40;
			this.label4.Text = "Origin Mode:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// OriginModeCombo
			// 
			this.OriginModeCombo.ListProperties.CheckBoxDataMember = "";
			this.OriginModeCombo.ListProperties.DataSource = null;
			this.OriginModeCombo.ListProperties.DisplayMember = "";
			this.OriginModeCombo.Location = new System.Drawing.Point(8, 420);
			this.OriginModeCombo.Name = "OriginModeCombo";
			this.OriginModeCombo.Size = new System.Drawing.Size(165, 21);
			this.OriginModeCombo.TabIndex = 39;
			this.OriginModeCombo.SelectedIndexChanged += new System.EventHandler(this.OriginModeCombo_SelectedIndexChanged);
			// 
			// OriginValueTextBox
			// 
			this.OriginValueTextBox.Location = new System.Drawing.Point(8, 470);
			this.OriginValueTextBox.Name = "OriginValueTextBox";
			this.OriginValueTextBox.Size = new System.Drawing.Size(165, 18);
			this.OriginValueTextBox.TabIndex = 37;
			this.OriginValueTextBox.TextChanged += new System.EventHandler(this.OriginValueTextBox_TextChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 450);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(165, 20);
			this.label6.TabIndex = 38;
			this.label6.Text = "Custom Origin Value:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NStandardBar3DUC
			// 
			this.Controls.Add(this.label4);
			this.Controls.Add(this.OriginModeCombo);
			this.Controls.Add(this.OriginValueTextBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.LabelStyleButton);
			this.Controls.Add(this.DepthScroll);
			this.Controls.Add(this.BarBorderButton);
			this.Controls.Add(this.HasBottomEdge);
			this.Controls.Add(this.HasTopEdge);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.EdgePercentScrollBar);
			this.Controls.Add(this.InvertAxisRuler);
			this.Controls.Add(this.DifferentFillStyles);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.WidthScroll);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.StyleCombo);
			this.Controls.Add(this.BarFillStyleButton);
			this.Name = "NStandardBar3DUC";
			this.Size = new System.Drawing.Size(180, 505);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("3D Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure chart
			NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 65;
			chart.Height = 40;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

            // add interlaced stripe
			NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			// setup a bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar Series";
			bar.DataLabelStyle.Visible = true;
			bar.HasBottomEdge = false;

			// add some data to the bar series
			bar.AddDataPoint(new NDataPoint(18, "C++"));
			bar.AddDataPoint(new NDataPoint(15, "Ruby"));
			bar.AddDataPoint(new NDataPoint(21, "Python"));
			bar.AddDataPoint(new NDataPoint(23, "Java"));
			bar.AddDataPoint(new NDataPoint(27, "Javascript"));
			bar.AddDataPoint(new NDataPoint(29, "C#"));
			bar.AddDataPoint(new NDataPoint(26, "PHP"));

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// init form controls
			StyleCombo.FillFromEnum(typeof(BarShape));
            StyleCombo.SelectedIndex = (int)BarShape.SmoothEdgeBar;
			OriginModeCombo.SelectedIndex = 0;
			OriginValueTextBox.Text = "0";
			EdgePercentScrollBar.Value = (int)bar.BarEdgePercent;
			HasTopEdge.Checked = bar.HasTopEdge;
            HasBottomEdge.Checked = bar.HasBottomEdge;
            DifferentFillStyles.Checked = true;
		}

		private void StyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.BarShape = (BarShape)StyleCombo.SelectedIndex;

			bool bHasEdge = (bar.BarShape == BarShape.SmoothEdgeBar || bar.BarShape == BarShape.CutEdgeBar);
			EdgePercentScrollBar.Enabled = bHasEdge;
			HasTopEdge.Enabled = bHasEdge;
			HasBottomEdge.Enabled = bHasEdge;

			nChartControl1.Refresh();
		}

		private void WidthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.WidthPercent = WidthScroll.Value;
			nChartControl1.Refresh();
		}

		private void DepthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.DepthPercent = DepthScroll.Value;
			nChartControl1.Refresh();
		}

		private void DifferentFillStyles_CheckedChanged(object sender, System.EventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];

			if (DifferentFillStyles.Checked)
			{
				BarFillStyleButton.Enabled = false;

				bar.Legend.Mode = SeriesLegendMode.DataPoints;

				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
                styleSheet.Apply(nChartControl1.Document);
			}
			else
			{
				BarFillStyleButton.Enabled = true;

				bar.Legend.Mode = SeriesLegendMode.Series;

				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
                styleSheet.Apply(nChartControl1.Document);
			}

			nChartControl1.Refresh();
		}

		private void BarFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(bar.FillStyle, out fillStyleResult))
			{
				bar.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void BarBorderButton_Click(object sender, System.EventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(bar.BorderStyle, out strokeStyleResult))
			{
				bar.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void OriginValueTextBox_TextChanged(object sender, EventArgs e)
		{
			try
			{
				NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
				bar.Origin = Double.Parse(OriginValueTextBox.Text);
				nChartControl1.Refresh();
			}
			catch
			{
			}
		}

		private void OriginModeCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];

			bar.OriginMode = (SeriesOriginMode)OriginModeCombo.SelectedIndex;

			nChartControl1.Refresh();

			OriginValueTextBox.Enabled = (bar.OriginMode == SeriesOriginMode.CustomOrigin);
		}

		private void InvertAxisRuler_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Invert = InvertAxisRuler.Checked;
			nChartControl1.Refresh();
		}

		private void EdgePercentScrollBar_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.BarEdgePercent = EdgePercentScrollBar.Value;
			nChartControl1.Refresh();
		}

		private void HasTopEdge_CheckedChanged(object sender, System.EventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.HasTopEdge = HasTopEdge.Checked;
			nChartControl1.Refresh();
		}

		private void HasBottomEdge_CheckedChanged(object sender, System.EventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.HasBottomEdge = HasBottomEdge.Checked;
			nChartControl1.Refresh();
		}

		private void LabelStyleButton_Click(object sender, System.EventArgs e)
		{
			NDataLabelStyle styleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if(NDataLabelStyleTypeEditor.Edit(series.DataLabelStyle, out styleResult))
			{
				series.DataLabelStyle = styleResult;
				nChartControl1.Refresh();
			}
		}
	}
}
