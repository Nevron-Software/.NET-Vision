using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NRadarLineUC : NExampleBaseUC
	{
		private NRadarSeries m_Radar1;
		private NRadarSeries m_Radar2;
		private NRadarChart m_Chart;
		private Nevron.UI.WinForm.Controls.NButton RadarLineButton;
		private Nevron.UI.WinForm.Controls.NButton RadarLine2Button;
		private Nevron.UI.WinForm.Controls.NButton MarkerStyleButton2;
		private Nevron.UI.WinForm.Controls.NButton MarkerStyleButton1;
		private Nevron.UI.WinForm.Controls.NNumericUpDown BeginAngleUpDown;
		private Label label2;
		private Label label1;
		private Nevron.UI.WinForm.Controls.NNumericUpDown TitleAngleNumericUpDown;
		private Label label3;
		private Nevron.UI.WinForm.Controls.NComboBox TitleAngleModeComboBox;
		private System.ComponentModel.Container components = null;

		public NRadarLineUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.RadarLineButton = new Nevron.UI.WinForm.Controls.NButton();
			this.RadarLine2Button = new Nevron.UI.WinForm.Controls.NButton();
			this.MarkerStyleButton2 = new Nevron.UI.WinForm.Controls.NButton();
			this.MarkerStyleButton1 = new Nevron.UI.WinForm.Controls.NButton();
			this.BeginAngleUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.TitleAngleNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.TitleAngleModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			((System.ComponentModel.ISupportInitialize)(this.BeginAngleUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TitleAngleNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// RadarLineButton
			// 
			this.RadarLineButton.Location = new System.Drawing.Point(9, 59);
			this.RadarLineButton.Name = "RadarLineButton";
			this.RadarLineButton.Size = new System.Drawing.Size(157, 24);
			this.RadarLineButton.TabIndex = 2;
			this.RadarLineButton.Text = "Radar Line 1...";
			this.RadarLineButton.Click += new System.EventHandler(this.RadarLineButton_Click);
			// 
			// RadarLine2Button
			// 
			this.RadarLine2Button.Location = new System.Drawing.Point(9, 90);
			this.RadarLine2Button.Name = "RadarLine2Button";
			this.RadarLine2Button.Size = new System.Drawing.Size(157, 24);
			this.RadarLine2Button.TabIndex = 3;
			this.RadarLine2Button.Text = "Radar Line 2...";
			this.RadarLine2Button.Click += new System.EventHandler(this.RadarLine2Button_Click);
			// 
			// MarkerStyleButton2
			// 
			this.MarkerStyleButton2.Location = new System.Drawing.Point(9, 152);
			this.MarkerStyleButton2.Name = "MarkerStyleButton2";
			this.MarkerStyleButton2.Size = new System.Drawing.Size(157, 24);
			this.MarkerStyleButton2.TabIndex = 5;
			this.MarkerStyleButton2.Text = "Radar 2 Marker Style...";
			this.MarkerStyleButton2.Click += new System.EventHandler(this.MarkerStyleButton2_Click);
			// 
			// MarkerStyleButton1
			// 
			this.MarkerStyleButton1.Location = new System.Drawing.Point(9, 121);
			this.MarkerStyleButton1.Name = "MarkerStyleButton1";
			this.MarkerStyleButton1.Size = new System.Drawing.Size(157, 24);
			this.MarkerStyleButton1.TabIndex = 4;
			this.MarkerStyleButton1.Text = "Radar 1 Marker Style...";
			this.MarkerStyleButton1.Click += new System.EventHandler(this.MarkerStyleButton1_Click);
			// 
			// BeginAngleUpDown
			// 
			this.BeginAngleUpDown.Location = new System.Drawing.Point(9, 29);
			this.BeginAngleUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.BeginAngleUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
			this.BeginAngleUpDown.Name = "BeginAngleUpDown";
			this.BeginAngleUpDown.Size = new System.Drawing.Size(157, 20);
			this.BeginAngleUpDown.TabIndex = 1;
			this.BeginAngleUpDown.ValueChanged += new System.EventHandler(this.BeginAngleUpDown_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(162, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "Begin Angle:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 230);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(157, 17);
			this.label1.TabIndex = 8;
			this.label1.Text = "Title Angle:";
			// 
			// TitleAngleNumericUpDown
			// 
			this.TitleAngleNumericUpDown.Location = new System.Drawing.Point(12, 249);
			this.TitleAngleNumericUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.TitleAngleNumericUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
			this.TitleAngleNumericUpDown.Name = "TitleAngleNumericUpDown";
			this.TitleAngleNumericUpDown.Size = new System.Drawing.Size(157, 20);
			this.TitleAngleNumericUpDown.TabIndex = 9;
			this.TitleAngleNumericUpDown.ValueChanged += new System.EventHandler(this.TitleAngleNumericUpDown_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 189);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Title Angle Mode:";
			// 
			// TitleAngleModeComboBox
			// 
			this.TitleAngleModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.TitleAngleModeComboBox.ListProperties.DataSource = null;
			this.TitleAngleModeComboBox.ListProperties.DisplayMember = "";
			this.TitleAngleModeComboBox.Location = new System.Drawing.Point(12, 206);
			this.TitleAngleModeComboBox.Name = "TitleAngleModeComboBox";
			this.TitleAngleModeComboBox.Size = new System.Drawing.Size(157, 21);
			this.TitleAngleModeComboBox.TabIndex = 7;
			this.TitleAngleModeComboBox.SelectedIndexChanged += new System.EventHandler(this.TitleAngleModeComboBox_SelectedIndexChanged);
			// 
			// NRadarLineUC
			// 
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TitleAngleNumericUpDown);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TitleAngleModeComboBox);
			this.Controls.Add(this.BeginAngleUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.MarkerStyleButton2);
			this.Controls.Add(this.MarkerStyleButton1);
			this.Controls.Add(this.RadarLine2Button);
			this.Controls.Add(this.RadarLineButton);
			this.Name = "NRadarLineUC";
			this.Size = new System.Drawing.Size(180, 459);
			((System.ComponentModel.ISupportInitialize)(this.BeginAngleUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TitleAngleNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Radar Line");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			m_Chart = new NRadarChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(m_Chart);
			m_Chart.Wall(ChartWallType.Radar).BorderStyle.Color = Color.White;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			m_Chart.DisplayOnLegend = nChartControl1.Legends[0];

			// set some axis labels
			AddAxis("Vitamin A");
			AddAxis("Vitamin B1");
			AddAxis("Vitamin B2");
			AddAxis("Vitamin B6");
			AddAxis("Vitamin B12");
			AddAxis("Vitamin C");
			AddAxis("Vitamin D");
			AddAxis("Vitamin E");

			m_Radar1 = new NRadarLineSeries();
			m_Chart.Series.Add(m_Radar1);
			m_Radar1.Name = "Series 1";
			m_Radar1.Values.FillRandomRange(Random, 8, 50, 90);
			m_Radar1.DataLabelStyle.Visible = false;
			m_Radar1.DataLabelStyle.Format = "<value>";
			m_Radar1.MarkerStyle.Visible = true;
			m_Radar1.MarkerStyle.PointShape = PointShape.Cylinder;
			m_Radar1.MarkerStyle.Width = new NLength(1.6f, NRelativeUnit.ParentPercentage);
			m_Radar1.MarkerStyle.Height = new NLength(1.6f, NRelativeUnit.ParentPercentage);

			m_Radar2 = new NRadarLineSeries();
			m_Chart.Series.Add(m_Radar2);
			m_Radar2.Name = "Series 2";
			m_Radar2.Values.FillRandomRange(Random, 8, 0, 100);
			m_Radar2.DataLabelStyle.Visible = false;
			m_Radar2.DataLabelStyle.Format = "<value>";
			m_Radar2.MarkerStyle.Visible = true;
			m_Radar2.MarkerStyle.PointShape = PointShape.Cylinder;
			m_Radar2.MarkerStyle.Width = new NLength(1.6f, NRelativeUnit.ParentPercentage);
			m_Radar2.MarkerStyle.Height = new NLength(1.6f, NRelativeUnit.ParentPercentage);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Charts[0].Series);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			// init form controls
			BeginAngleUpDown.Value = 90;

			TitleAngleModeComboBox.FillFromEnum(typeof(ScaleLabelAngleMode));
			TitleAngleModeComboBox.SelectedIndex = (int)ScaleLabelAngleMode.Scale;
		}

		private void UpdateTitleLabels()
		{
			ScaleLabelAngleMode mode = (ScaleLabelAngleMode)TitleAngleModeComboBox.SelectedIndex;
			float angle = (float)TitleAngleNumericUpDown.Value;

			for (int i = 0; i < m_Chart.Axes.Count; i++)
			{
				NRadarAxis axis = (NRadarAxis)m_Chart.Axes[i];
				axis.TitleAngle = new NScaleLabelAngle(mode, angle);
			}

			nChartControl1.Refresh();
		}

		private void AddAxis(string title)
		{
			NRadarAxis axis = new NRadarAxis();

			// set title
			axis.Title = title;

			// setup scale
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)axis.ScaleConfigurator;

			linearScale.RulerStyle.BorderStyle.Color = Color.Silver;
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Silver;
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Silver;
			linearScale.InnerMajorTickStyle.Length = new NLength(2, NGraphicsUnit.Point);
			linearScale.OuterMajorTickStyle.Length = new NLength(2, NGraphicsUnit.Point);

			if (m_Chart.Axes.Count == 0)
			{
				// if the first axis then configure grid style and stripes
				linearScale.MajorGridStyle.LineStyle.Color = Color.Gainsboro;
				linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
				linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Radar, true);

				// add interlaced stripe
				NScaleStripStyle strip = new NScaleStripStyle();
				strip.FillStyle = new NColorFillStyle(Color.FromArgb(64, 200, 200, 200));
				strip.Interlaced = true;
				strip.SetShowAtWall(ChartWallType.Radar, true);
				linearScale.StripStyles.Add(strip);
			}
			else
			{
				// hide labels
				linearScale.AutoLabels = false;
			}

			m_Chart.Axes.Add(axis);
		}

		private void RadarLineButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Radar1.BorderStyle, out strokeStyleResult))
			{
				m_Radar1.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void RadarLine2Button_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Radar2.BorderStyle, out strokeStyleResult))
			{
				m_Radar2.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void MarkerStyleButton1_Click(object sender, System.EventArgs e)
		{
			NMarkerStyle markerStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if (NMarkerStyleTypeEditor.Edit(series.MarkerStyle, out markerStyleResult))
			{
				series.MarkerStyle = markerStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void MarkerStyleButton2_Click(object sender, System.EventArgs e)
		{
			NMarkerStyle markerStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[1];

			if (NMarkerStyleTypeEditor.Edit(series.MarkerStyle, out markerStyleResult))
			{
				series.MarkerStyle = markerStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void BeginAngleUpDown_ValueChanged(object sender, EventArgs e)
		{
			m_Chart.BeginAngle = (float)BeginAngleUpDown.Value;
			nChartControl1.Refresh();
		}

		private void TitleAngleModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateTitleLabels();
		}

		private void TitleAngleNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateTitleLabels();
		}
	}
}
