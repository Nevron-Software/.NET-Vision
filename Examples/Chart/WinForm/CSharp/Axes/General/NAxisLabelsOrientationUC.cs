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
	public class NAxisLabelsOrientationUC : NExampleBaseUC
	{
		private const int categoriesCount = 6;
		private NCartesianChart m_Chart;
		private Nevron.UI.WinForm.Controls.NHScrollBar RotationScrollBar;
		private Nevron.UI.WinForm.Controls.NHScrollBar ElevationScrollBar;
		private Nevron.UI.WinForm.Controls.NCheckBox Use3DCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox AllowTextFlipCheckBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown CustomAngleNumericUpDown;
		private Nevron.UI.WinForm.Controls.NComboBox AngleModeComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NCheckBox Fit3DChartCheckBox;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public NAxisLabelsOrientationUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
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
			this.AllowTextFlipCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.CustomAngleNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.AngleModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.RotationScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.ElevationScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.Use3DCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.Fit3DChartCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.CustomAngleNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// AllowTextFlipCheckBox
			// 
			this.AllowTextFlipCheckBox.AutoSize = true;
			this.AllowTextFlipCheckBox.ButtonProperties.BorderOffset = 2;
			this.AllowTextFlipCheckBox.Location = new System.Drawing.Point(11, 108);
			this.AllowTextFlipCheckBox.Name = "AllowTextFlipCheckBox";
			this.AllowTextFlipCheckBox.Size = new System.Drawing.Size(109, 17);
			this.AllowTextFlipCheckBox.TabIndex = 4;
			this.AllowTextFlipCheckBox.Text = "Allow labels to flip";
			this.AllowTextFlipCheckBox.UseVisualStyleBackColor = true;
			this.AllowTextFlipCheckBox.CheckedChanged += new System.EventHandler(this.AllowTextFlipCheckBox_CheckedChanged);
			// 
			// CustomAngleNumericUpDown
			// 
			this.CustomAngleNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.CustomAngleNumericUpDown.Location = new System.Drawing.Point(11, 71);
			this.CustomAngleNumericUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.CustomAngleNumericUpDown.Name = "CustomAngleNumericUpDown";
			this.CustomAngleNumericUpDown.Size = new System.Drawing.Size(154, 20);
			this.CustomAngleNumericUpDown.TabIndex = 3;
			this.CustomAngleNumericUpDown.ValueChanged += new System.EventHandler(this.CustomAngleNumericUpDown_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Custom Angle:";
			// 
			// AngleModeComboBox
			// 
			this.AngleModeComboBox.Location = new System.Drawing.Point(11, 26);
			this.AngleModeComboBox.Name = "AngleModeComboBox";
			this.AngleModeComboBox.Size = new System.Drawing.Size(154, 21);
			this.AngleModeComboBox.TabIndex = 1;
			this.AngleModeComboBox.SelectedIndexChanged += new System.EventHandler(this.AngleModeComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Angle Mode:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 198);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Rotation:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 247);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Elevation:";
			// 
			// RotationScrollBar
			// 
			this.RotationScrollBar.Location = new System.Drawing.Point(11, 217);
			this.RotationScrollBar.Maximum = 360;
			this.RotationScrollBar.Minimum = -360;
			this.RotationScrollBar.MinimumSize = new System.Drawing.Size(32, 16);
			this.RotationScrollBar.Name = "RotationScrollBar";
			this.RotationScrollBar.Size = new System.Drawing.Size(154, 16);
			this.RotationScrollBar.TabIndex = 7;
			this.RotationScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.RotationScrollBar_ValueChanged);
			// 
			// ElevationScrollBar
			// 
			this.ElevationScrollBar.Location = new System.Drawing.Point(11, 265);
			this.ElevationScrollBar.Maximum = 360;
			this.ElevationScrollBar.Minimum = -360;
			this.ElevationScrollBar.MinimumSize = new System.Drawing.Size(32, 16);
			this.ElevationScrollBar.Name = "ElevationScrollBar";
			this.ElevationScrollBar.Size = new System.Drawing.Size(154, 16);
			this.ElevationScrollBar.TabIndex = 9;
			this.ElevationScrollBar.Value = -360;
			this.ElevationScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ElevationScrollBar_ValueChanged);
			// 
			// Use3DCheckBox
			// 
			this.Use3DCheckBox.AutoSize = true;
			this.Use3DCheckBox.ButtonProperties.BorderOffset = 2;
			this.Use3DCheckBox.Location = new System.Drawing.Point(11, 135);
			this.Use3DCheckBox.Name = "Use3DCheckBox";
			this.Use3DCheckBox.Size = new System.Drawing.Size(90, 17);
			this.Use3DCheckBox.TabIndex = 5;
			this.Use3DCheckBox.Text = "Use 3D Chart";
			this.Use3DCheckBox.UseVisualStyleBackColor = true;
			this.Use3DCheckBox.CheckedChanged += new System.EventHandler(this.Use3DCheckBox_CheckedChanged);
			// 
			// Fit3DChartCheckBox
			// 
			this.Fit3DChartCheckBox.AutoSize = true;
			this.Fit3DChartCheckBox.ButtonProperties.BorderOffset = 2;
			this.Fit3DChartCheckBox.Location = new System.Drawing.Point(11, 163);
			this.Fit3DChartCheckBox.Name = "Fit3DChartCheckBox";
			this.Fit3DChartCheckBox.Size = new System.Drawing.Size(113, 17);
			this.Fit3DChartCheckBox.TabIndex = 10;
			this.Fit3DChartCheckBox.Text = "Fit 3D Chart in box";
			this.Fit3DChartCheckBox.UseVisualStyleBackColor = true;
			this.Fit3DChartCheckBox.CheckedChanged += new System.EventHandler(this.Fit3DChartCheckBox_CheckedChanged);
			// 
			// NAxisLabelsOrientationUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.Fit3DChartCheckBox);
			this.Controls.Add(this.Use3DCheckBox);
			this.Controls.Add(this.ElevationScrollBar);
			this.Controls.Add(this.RotationScrollBar);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.AllowTextFlipCheckBox);
			this.Controls.Add(this.CustomAngleNumericUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.AngleModeComboBox);
			this.Controls.Add(this.label1);
			this.Name = "NAxisLabelsOrientationUC";
			this.Size = new System.Drawing.Size(178, 323);
			((System.ComponentModel.ISupportInitialize)(this.CustomAngleNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// configure the trackball
			NTrackballTool trackballTool = new NTrackballTool();
			trackballTool.ProjectionChanged += new EventHandler(OnProjectionChanged);
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(trackballTool);

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Axis Labels Orientation");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.DockMode = PanelDockMode.Top;
			title.Margins = new NMarginsL(10, 10, 10, 10);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
			title.SendToBack();

			// no legend
			nChartControl1.Legends.Clear();

			// setup the chart
			m_Chart = (NCartesianChart)nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			m_Chart.Depth = 50;
			m_Chart.Width = 50;
			m_Chart.Height = 50;
			m_Chart.BorderStyle = new NStrokeBorderStyle(BorderShape.RoundedRect);
			m_Chart.BoundsMode = BoundsMode.Fit;
			m_Chart.DockMode = PanelDockMode.Fill;
			m_Chart.Margins = new NMarginsL(30, 0, 30, 30);
			m_Chart.Padding = new NMarginsL(5, 5, 5, 5);
			m_Chart.BackgroundFillStyle = new NGradientFillStyle(Color.White, Color.LightGray);

			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.Title.Text = "Values";

			// add interlaced stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back, ChartWallType.Left };
			stripStyle.Interlaced = true;
			scaleY.StripStyles.Add(stripStyle);

			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// configure the x axis labels (categories)
			NOrdinalScaleConfigurator scaleX = (NOrdinalScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleX.AutoLabels = false;
			scaleX.Title.Text = "Categories Title";
			scaleX.MajorTickMode = MajorTickMode.CustomStep;
			scaleX.LabelFitModes = new LabelFitMode[] { LabelFitMode.Stagger2, LabelFitMode.AutoScale };

			for (int j = 0; j < categoriesCount; j++)
			{
				scaleX.Labels.Add("Category " + j.ToString());
			}

			// configure the depth axis labels (series)
			NOrdinalScaleConfigurator scaleZ = m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator as NOrdinalScaleConfigurator;
			scaleZ.AutoLabels = false;
			scaleZ.Title.Text = "Series Title";
			scaleZ.MajorTickMode = MajorTickMode.CustomStep;
			scaleZ.Labels.Add("Series 1");
			scaleZ.Labels.Add("Series 2");
			scaleZ.Labels.Add("Series 3");
			scaleZ.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			scaleZ.LabelFitModes = new LabelFitMode[] { LabelFitMode.Stagger2, LabelFitMode.AutoScale };

			// add series
			for (int i = 0; i < 3; i++)
			{
				NBarSeries bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
				bar.InflateMargins = true;
				bar.BarShape = BarShape.SmoothEdgeBar;
				bar.DataLabelStyle.Visible = false;
				bar.Name = "Series " + i.ToString();
				bar.Values.FillRandomRange(Random, categoriesCount, 10, 30);
			}

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);
			
			// initialize controls on the form
			AngleModeComboBox.FillFromEnum(typeof(ScaleLabelAngleMode));
			AngleModeComboBox.SelectedIndex = (int)ScaleLabelAngleMode.Scale;
			Use3DCheckBox.Checked = true;

			OnProjectionChanged(null, null);
		}

		private void OnProjectionChanged(object sender, EventArgs e)
		{
			float elevation = m_Chart.Projection.Elevation;
			float rotation = m_Chart.Projection.Rotation;

			ElevationScrollBar.Value = (int)elevation;
			RotationScrollBar.Value = (int)rotation;
		}

		private void UpdateScaleLabelAngle()
		{
			if (m_Chart != null)
			{
				int count = m_Chart.Axes.Count;

				NScaleLabelAngle angle = new NScaleLabelAngle((ScaleLabelAngleMode)AngleModeComboBox.SelectedIndex,
															   (float)CustomAngleNumericUpDown.Value,
															   AllowTextFlipCheckBox.Checked);

				// update the x axis
				NAxis axis = (NAxis)m_Chart.Axes[(int)StandardAxis.PrimaryX];
				NStandardScaleConfigurator scale = axis.ScaleConfigurator as NStandardScaleConfigurator;
				scale.LabelStyle.Angle = angle;

				// update the depth axis
				axis = (NAxis)m_Chart.Axes[(int)StandardAxis.Depth];
				scale = axis.ScaleConfigurator as NStandardScaleConfigurator;
				scale.LabelStyle.Angle = angle;

				nChartControl1.Refresh();
			}
		}

		private void UpdateProjection()
		{
			if (m_Chart != null)
			{
				m_Chart.Projection.Rotation = (float)RotationScrollBar.Value;
				m_Chart.Projection.Elevation = (float)ElevationScrollBar.Value;

				nChartControl1.Refresh();
			}
		}

		private void AngleModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateScaleLabelAngle();
		}

		private void CustomAngleNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateScaleLabelAngle();
		}

		private void AllowTextFlipCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateScaleLabelAngle();
		}

		private void ElevationScrollBar_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			UpdateProjection();
		}

		private void RotationScrollBar_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			UpdateProjection();
		}

		private void Use3DCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_Chart.Enable3D = Use3DCheckBox.Checked;

			RotationScrollBar.Enabled = Use3DCheckBox.Checked;
			ElevationScrollBar.Enabled = Use3DCheckBox.Checked;
			Fit3DChartCheckBox.Enabled = Use3DCheckBox.Checked;
		}

		private void Fit3DChartCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_Chart.Fit3DAxisContent = Fit3DChartCheckBox.Checked;

			nChartControl1.Refresh();
		}
	}
}
