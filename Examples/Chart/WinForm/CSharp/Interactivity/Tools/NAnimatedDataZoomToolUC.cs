using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
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
	public class NAnimatedDataZoomToolUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton ResetAxesButton;
		private Nevron.UI.WinForm.Controls.NCheckBox AnimateZoomingCheckBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown AnimationStepsNumericUpDown;
		private Label label5;
		private Nevron.UI.WinForm.Controls.NNumericUpDown AnimationIntervalNumericUpDown;
		private Label label6;
		private System.ComponentModel.Container components = null;

		public NAnimatedDataZoomToolUC()
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
			this.ResetAxesButton = new Nevron.UI.WinForm.Controls.NButton();
			this.AnimateZoomingCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.AnimationStepsNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.AnimationIntervalNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.AnimationStepsNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.AnimationIntervalNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// ResetAxesButton
			// 
			this.ResetAxesButton.Location = new System.Drawing.Point(11, 104);
			this.ResetAxesButton.Name = "ResetAxesButton";
			this.ResetAxesButton.Size = new System.Drawing.Size(160, 23);
			this.ResetAxesButton.TabIndex = 20;
			this.ResetAxesButton.Text = "Reset axes";
			this.ResetAxesButton.Click += new System.EventHandler(this.ResetAxesButton_Click);
			// 
			// AnimateZoomingCheckBox
			// 
			this.AnimateZoomingCheckBox.ButtonProperties.BorderOffset = 2;
			this.AnimateZoomingCheckBox.Location = new System.Drawing.Point(11, 11);
			this.AnimateZoomingCheckBox.Name = "AnimateZoomingCheckBox";
			this.AnimateZoomingCheckBox.Size = new System.Drawing.Size(152, 24);
			this.AnimateZoomingCheckBox.TabIndex = 11;
			this.AnimateZoomingCheckBox.Text = "Animate Zooming";
			this.AnimateZoomingCheckBox.CheckedChanged += new System.EventHandler(this.AnimateZoomingCheckBox_CheckedChanged);
			// 
			// AnimationStepsNumericUpDown
			// 
			this.AnimationStepsNumericUpDown.Location = new System.Drawing.Point(109, 40);
			this.AnimationStepsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.AnimationStepsNumericUpDown.Name = "AnimationStepsNumericUpDown";
			this.AnimationStepsNumericUpDown.Size = new System.Drawing.Size(62, 20);
			this.AnimationStepsNumericUpDown.TabIndex = 0;
			this.AnimationStepsNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.AnimationStepsNumericUpDown.ValueChanged += new System.EventHandler(this.AnimationStepsNumericUpDown_ValueChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(11, 44);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(92, 16);
			this.label5.TabIndex = 12;
			this.label5.Text = "Steps:";
			// 
			// AnimationIntervalNumericUpDown
			// 
			this.AnimationIntervalNumericUpDown.Location = new System.Drawing.Point(109, 66);
			this.AnimationIntervalNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.AnimationIntervalNumericUpDown.Name = "AnimationIntervalNumericUpDown";
			this.AnimationIntervalNumericUpDown.Size = new System.Drawing.Size(62, 20);
			this.AnimationIntervalNumericUpDown.TabIndex = 15;
			this.AnimationIntervalNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.AnimationIntervalNumericUpDown.ValueChanged += new System.EventHandler(this.AnimationIntervalNumericUpDown_ValueChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(11, 70);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(92, 16);
			this.label6.TabIndex = 14;
			this.label6.Text = "Interval (ms):";
			// 
			// NAnimatedDataZoomToolUC
			// 
			this.Controls.Add(this.AnimationIntervalNumericUpDown);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.AnimationStepsNumericUpDown);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.AnimateZoomingCheckBox);
			this.Controls.Add(this.ResetAxesButton);
			this.Name = "NAnimatedDataZoomToolUC";
			this.Size = new System.Drawing.Size(180, 664);
			((System.ComponentModel.ISupportInitialize)(this.AnimationStepsNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.AnimationIntervalNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Animated Data Zoom");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// configure chart
			NCartesianChart chart = (NCartesianChart)(nChartControl1.Charts[0]);

			chart.RangeSelections.Add(new NRangeSelection());

			// 2D line chart
			chart.BoundsMode = BoundsMode.Stretch;

			// configure axis pagin and set a mimimum range length on the axis
			// this will prevent the user from zooming too much
			chart.Axis(StandardAxis.PrimaryX).PagingView = new NNumericAxisPagingView();
			chart.Axis(StandardAxis.PrimaryX).PagingView.MinPageLength = 0.00001;
			chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = CreateLinearScale();

			chart.Axis(StandardAxis.PrimaryY).PagingView = new NNumericAxisPagingView();
			chart.Axis(StandardAxis.PrimaryY).PagingView.MinPageLength = 0.00001f;
			chart.Axis(StandardAxis.PrimaryY).ScrollBar.Visible = true;
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = CreateLinearScale();

			// add point series
			chart.Series.Clear();
			NPointSeries point1 = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point1.Name = "Point 1";
			point1.PointShape = PointShape.Bar;
			point1.Size = new NLength(5, NGraphicsUnit.Point);
			point1.FillStyle = new NColorFillStyle(Color.Red);
			point1.BorderStyle.Color = Color.Pink;
			point1.DataLabelStyle.Visible = false;
			point1.UseXValues = true;
			point1.UseZValues = true;
			point1.InflateMargins = true;

			NPointSeries point2 = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point2.Name = "Point 2";
			point2.PointShape = PointShape.Bar;
			point2.Size = new NLength(5, NGraphicsUnit.Point);
			point2.FillStyle = new NColorFillStyle(Color.CornflowerBlue);
			point2.BorderStyle.Color = Color.LightCyan;
			point2.DataLabelStyle.Visible = false;
			point2.UseXValues = true;
			point2.UseZValues = true;
			point2.InflateMargins = true;

			NPointSeries point3 = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point3.Name = "Point 3";
			point3.PointShape = PointShape.Bar;
			point3.Size = new NLength(5, NGraphicsUnit.Point);
			point3.FillStyle = new NColorFillStyle(Color.Green);
			point3.BorderStyle.Color = Color.Chartreuse;
			point3.DataLabelStyle.Visible = false;
			point3.UseXValues = true;
			point3.UseZValues = true;
			point3.InflateMargins = true;

			// fill with random data
			point1.Values.FillRandomRange(Random, 10, 0, 50);
			point1.XValues.FillRandomRange(Random, 10, 0, 50);
			point1.ZValues.FillRandomRange(Random, 10, 0, 50);

			point2.Values.FillRandomRange(Random, 10, 25, 75);
			point2.XValues.FillRandomRange(Random, 10, 25, 75);
			point2.ZValues.FillRandomRange(Random, 10, 25, 75);

			point3.Values.FillRandomRange(Random, 10, 75, 125);
			point3.XValues.FillRandomRange(Random, 10, 75, 125);
			point3.ZValues.FillRandomRange(Random, 10, 75, 125);

			AnimateZoomingCheckBox.Checked = true;
			
			UpdateDataZoomTool();
		}
		
		private void UpdateDataZoomTool()
		{
			if (nChartControl1 == null)
				return;

			nChartControl1.Controller.Tools.Clear();
			NDataZoomTool dataZoomTool  = new NDataZoomTool();

			dataZoomTool.AnimateZooming = AnimateZoomingCheckBox.Checked;
			dataZoomTool.AnimationSteps = (int)AnimationStepsNumericUpDown.Value;

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
			nChartControl1.Controller.Tools.Add(dataZoomTool);
		}
		
		private NLinearScaleConfigurator CreateLinearScale()
		{
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();

			linearScale.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific);
			linearScale.MinorTickCount = 4;

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			return linearScale;
		}

		private void ResetAxesButton_Click(object sender, System.EventArgs e)
		{
			NChart chart = (NChart)(nChartControl1.Charts[0]);

			chart.Axis(StandardAxis.PrimaryX).PagingView.Enabled = false;
			chart.Axis(StandardAxis.PrimaryY).PagingView.Enabled = false;
			chart.Axis(StandardAxis.Depth).PagingView.Enabled = false;

			nChartControl1.Refresh();
		}

		private void AnimateZoomingCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateDataZoomTool();
		}

		private void AnimationStepsNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateDataZoomTool();
		}

		private void AnimationIntervalNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateDataZoomTool();
		}
	}
}
