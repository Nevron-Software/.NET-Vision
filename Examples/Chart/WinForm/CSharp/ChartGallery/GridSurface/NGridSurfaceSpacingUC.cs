using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NGridSurfaceSpacingUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NCheckBox smoothShadingCheck;
		private UI.WinForm.Controls.NButton GenerateDataButton;
		private System.Windows.Forms.Label label1;
		private UI.WinForm.Controls.NComboBox SpacingModeComboBox;
		private UI.WinForm.Controls.NNumericUpDown XGridStepNumericUpDown;
		private System.Windows.Forms.Label label2;
		private UI.WinForm.Controls.NNumericUpDown XGridOriginNumericUpDown;
		private System.Windows.Forms.Label label3;
		private UI.WinForm.Controls.NNumericUpDown YGridStepNumericUpDown;
		private System.Windows.Forms.Label label4;
		private UI.WinForm.Controls.NNumericUpDown YGridOriginNumericUpDown;
		private System.Windows.Forms.Label label5;
		private System.ComponentModel.Container components = null;

		public NGridSurfaceSpacingUC()
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
			this.smoothShadingCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.GenerateDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.SpacingModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.XGridStepNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.XGridOriginNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.YGridStepNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.YGridOriginNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.XGridStepNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.XGridOriginNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.YGridStepNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.YGridOriginNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// smoothShadingCheck
			// 
			this.smoothShadingCheck.ButtonProperties.BorderOffset = 2;
			this.smoothShadingCheck.Location = new System.Drawing.Point(9, 48);
			this.smoothShadingCheck.Name = "smoothShadingCheck";
			this.smoothShadingCheck.Size = new System.Drawing.Size(158, 20);
			this.smoothShadingCheck.TabIndex = 3;
			this.smoothShadingCheck.Text = "Smooth Shading";
			this.smoothShadingCheck.CheckedChanged += new System.EventHandler(this.SmoothShadingCheck_CheckedChanged);
			// 
			// GenerateDataButton
			// 
			this.GenerateDataButton.Location = new System.Drawing.Point(9, 9);
			this.GenerateDataButton.Name = "GenerateDataButton";
			this.GenerateDataButton.Size = new System.Drawing.Size(158, 23);
			this.GenerateDataButton.TabIndex = 4;
			this.GenerateDataButton.Text = "Generate Data";
			this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 85);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Spacing Mode:";
			// 
			// SpacingModeComboBox
			// 
			this.SpacingModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.SpacingModeComboBox.ListProperties.DataSource = null;
			this.SpacingModeComboBox.ListProperties.DisplayMember = "";
			this.SpacingModeComboBox.Location = new System.Drawing.Point(9, 102);
			this.SpacingModeComboBox.Name = "SpacingModeComboBox";
			this.SpacingModeComboBox.Size = new System.Drawing.Size(158, 21);
			this.SpacingModeComboBox.TabIndex = 6;
			this.SpacingModeComboBox.SelectedIndexChanged += new System.EventHandler(this.SpacingModeComboBox_SelectedIndexChanged);
			// 
			// XGridStepNumericUpDown
			// 
			this.XGridStepNumericUpDown.Location = new System.Drawing.Point(12, 200);
			this.XGridStepNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.XGridStepNumericUpDown.Name = "XGridStepNumericUpDown";
			this.XGridStepNumericUpDown.Size = new System.Drawing.Size(120, 20);
			this.XGridStepNumericUpDown.TabIndex = 11;
			this.XGridStepNumericUpDown.ValueChanged += new System.EventHandler(this.XGridStepNumericUpDown_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 183);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "X Grid Step:";
			// 
			// XGridOriginNumericUpDown
			// 
			this.XGridOriginNumericUpDown.Location = new System.Drawing.Point(12, 154);
			this.XGridOriginNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.XGridOriginNumericUpDown.Name = "XGridOriginNumericUpDown";
			this.XGridOriginNumericUpDown.Size = new System.Drawing.Size(120, 20);
			this.XGridOriginNumericUpDown.TabIndex = 9;
			this.XGridOriginNumericUpDown.ValueChanged += new System.EventHandler(this.XGridOriginNumericUpDown_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 137);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "X Grid Origin:";
			// 
			// YGridStepNumericUpDown
			// 
			this.YGridStepNumericUpDown.Location = new System.Drawing.Point(12, 308);
			this.YGridStepNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.YGridStepNumericUpDown.Name = "YGridStepNumericUpDown";
			this.YGridStepNumericUpDown.Size = new System.Drawing.Size(120, 20);
			this.YGridStepNumericUpDown.TabIndex = 15;
			this.YGridStepNumericUpDown.ValueChanged += new System.EventHandler(this.YGridStepNumericUpDown_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 291);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Y Grid Step:";
			// 
			// YGridOriginNumericUpDown
			// 
			this.YGridOriginNumericUpDown.Location = new System.Drawing.Point(12, 262);
			this.YGridOriginNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.YGridOriginNumericUpDown.Name = "YGridOriginNumericUpDown";
			this.YGridOriginNumericUpDown.Size = new System.Drawing.Size(120, 20);
			this.YGridOriginNumericUpDown.TabIndex = 13;
			this.YGridOriginNumericUpDown.ValueChanged += new System.EventHandler(this.YGridOriginNumericUpDown_ValueChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 245);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(69, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Y Grid Origin:";
			// 
			// NGridSurfaceSpacingUC
			// 
			this.Controls.Add(this.YGridStepNumericUpDown);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.YGridOriginNumericUpDown);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.XGridStepNumericUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.XGridOriginNumericUpDown);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.SpacingModeComboBox);
			this.Controls.Add(this.GenerateDataButton);
			this.Controls.Add(this.smoothShadingCheck);
			this.Name = "NGridSurfaceSpacingUC";
			this.Size = new System.Drawing.Size(176, 378);
			((System.ComponentModel.ISupportInitialize)(this.XGridStepNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.XGridOriginNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.YGridStepNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.YGridOriginNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// Enable GPU acceleration
			nChartControl1.Settings.RenderSurface = RenderSurface.Window;

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = new NLabel("Surface Grid Spacing");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 50.0f;
			chart.Depth = 50.0f;
			chart.Height = 30.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftCameraLight);

			// setup axes
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Back };
			scaleX.InflateViewRangeBegin = false;
			scaleX.InflateViewRangeEnd = false;

			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ;
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Left };
			scaleZ.InflateViewRangeBegin = false;
			scaleZ.InflateViewRangeEnd = false;

			// add the surface series
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series.Add(SeriesType.GridSurface);
			surface.Name = "Surface";
			surface.PositionValue = 10.0;
			surface.SyncPaletteWithAxisScale = false;
			surface.PaletteSteps = 8;
			surface.ValueFormatter.FormatSpecifier = "0.000";
			surface.FillMode = SurfaceFillMode.Uniform;
			surface.FrameMode = SurfaceFrameMode.Mesh;
			surface.ShadingMode = ShadingMode.Flat;
			surface.FillStyle = new NColorFillStyle(Color.FromArgb(190, 210, 230));

			// specify that the surface should use custom X and Z values
			surface.XValuesMode = GridSurfaceValuesMode.CustomValues;
			surface.ZValuesMode = GridSurfaceValuesMode.CustomValues;

			surface.Data.SetGridSize(40, 40);

			GenerateXValues(surface);
			GenerateZValues(surface);
			FillData(surface);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			smoothShadingCheck.Checked = true;
			SpacingModeComboBox.FillFromEnum(typeof(GridSurfaceValuesMode));
			SpacingModeComboBox.SelectedIndex = (int)GridSurfaceValuesMode.CustomValues;

			XGridOriginNumericUpDown.Value = 0;
			XGridStepNumericUpDown.Value = 1;
			YGridOriginNumericUpDown.Value = 0;
			YGridStepNumericUpDown.Value = 1;
		}

		private void GenerateXValues(NGridSurfaceSeries surface)
		{
			int sizeX = surface.Data.GridSizeX;
			surface.XValues.Clear();

			double x = 0;

			for (int i = 0; i < sizeX; i++)
			{
				surface.XValues.Add(x);
				x += Random.NextDouble() * 10;
			}
		}

		private void GenerateZValues(NGridSurfaceSeries surface)
		{
			int sizeZ = surface.Data.GridSizeZ;
			surface.ZValues.Clear();

			double z = 0;

			for (int i = 0; i < sizeZ; i++)
			{
				surface.ZValues.Add(z);
				z += Random.NextDouble() * 10;
			}
		}

		private void FillData(NGridSurfaceSeries surface)
		{
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			double sizeXOrigin = -2.3;
			double sizeXScale = 4.6 / nCountX;


			for (int z = 0; z < nCountZ; z++)
			{
				for(int x = 0; x < nCountX; x++)
				{
					double xVal = (x * sizeXScale) + sizeXOrigin;
					double yVal = (z * sizeXScale) + sizeXOrigin;

					double zVal = xVal * Math.Exp(-(xVal * xVal + yVal * yVal));

					surface.Data.SetValue(x, z, zVal);
				}
			}
		}

		private void SmoothShadingCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			if (smoothShadingCheck.Checked)
			{
				surface.ShadingMode = ShadingMode.Smooth;
			}
			else
			{
				surface.ShadingMode = ShadingMode.Flat;
			}

			nChartControl1.Refresh();
		}

		private void GenerateDataButton_Click(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			GenerateXValues(surface);
			GenerateZValues(surface);

			nChartControl1.Refresh();
		}

		private void SpacingModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];
			surface.XValuesMode = (GridSurfaceValuesMode)SpacingModeComboBox.SelectedIndex;
			surface.ZValuesMode = (GridSurfaceValuesMode)SpacingModeComboBox.SelectedIndex;

			bool originAndStepMode = SpacingModeComboBox.SelectedIndex == (int)GridSurfaceValuesMode.OriginAndStep;

			XGridOriginNumericUpDown.Enabled = originAndStepMode;
			XGridStepNumericUpDown.Enabled = originAndStepMode;
			YGridOriginNumericUpDown.Enabled = originAndStepMode;
			YGridStepNumericUpDown.Enabled = originAndStepMode;

			nChartControl1.Refresh();
		}

		private void UpdateSurfaceOriginAndStep()
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			surface.OriginX = (float)XGridOriginNumericUpDown.Value;
			surface.StepX = (float)XGridStepNumericUpDown.Value;
			surface.OriginZ = (float)YGridOriginNumericUpDown.Value;
			surface.StepZ = (float)YGridStepNumericUpDown.Value;

			nChartControl1.Refresh();
		}

		private void XGridOriginNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateSurfaceOriginAndStep();
		}

		private void XGridStepNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateSurfaceOriginAndStep();
		}

		private void YGridOriginNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateSurfaceOriginAndStep();
		}

		private void YGridStepNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateSurfaceOriginAndStep();
		}
	}
}