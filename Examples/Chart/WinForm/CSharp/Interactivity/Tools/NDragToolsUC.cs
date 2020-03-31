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
	public class NDragToolsUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox DragModeComboBox;
		private Nevron.UI.WinForm.Controls.NGroupBox ProjectionParametersGroupBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label9;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RotationUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ElevationUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ZoomUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ViewerRotationUpDown;
		private Nevron.UI.WinForm.Controls.NCheckBox UseWindowRenderSurfaceCheckBox;
		private System.ComponentModel.Container components = null;

		public NDragToolsUC()
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
			this.label1 = new System.Windows.Forms.Label();
			this.DragModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.ProjectionParametersGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.ViewerRotationUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.ZoomUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.ElevationUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.RotationUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.UseWindowRenderSurfaceCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ProjectionParametersGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ViewerRotationUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ZoomUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ElevationUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RotationUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Drag mode:";
			// 
			// DragModeComboBox
			// 
			this.DragModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.DragModeComboBox.ListProperties.DataSource = null;
			this.DragModeComboBox.ListProperties.DisplayMember = "";
			this.DragModeComboBox.Location = new System.Drawing.Point(4, 30);
			this.DragModeComboBox.Name = "DragModeComboBox";
			this.DragModeComboBox.Size = new System.Drawing.Size(172, 21);
			this.DragModeComboBox.TabIndex = 1;
			this.DragModeComboBox.SelectedIndexChanged += new System.EventHandler(this.DragModeComboBox_SelectedIndexChanged);
			// 
			// ProjectionParametersGroupBox
			// 
			this.ProjectionParametersGroupBox.Controls.Add(this.ViewerRotationUpDown);
			this.ProjectionParametersGroupBox.Controls.Add(this.label9);
			this.ProjectionParametersGroupBox.Controls.Add(this.ZoomUpDown);
			this.ProjectionParametersGroupBox.Controls.Add(this.ElevationUpDown);
			this.ProjectionParametersGroupBox.Controls.Add(this.RotationUpDown);
			this.ProjectionParametersGroupBox.Controls.Add(this.label4);
			this.ProjectionParametersGroupBox.Controls.Add(this.label3);
			this.ProjectionParametersGroupBox.Controls.Add(this.label2);
			this.ProjectionParametersGroupBox.ImageIndex = 0;
			this.ProjectionParametersGroupBox.Location = new System.Drawing.Point(4, 58);
			this.ProjectionParametersGroupBox.Name = "ProjectionParametersGroupBox";
			this.ProjectionParametersGroupBox.Size = new System.Drawing.Size(172, 120);
			this.ProjectionParametersGroupBox.TabIndex = 2;
			this.ProjectionParametersGroupBox.TabStop = false;
			this.ProjectionParametersGroupBox.Text = "Projection parameters";
			// 
			// ViewerRotationUpDown
			// 
			this.ViewerRotationUpDown.DecimalPlaces = 2;
			this.ViewerRotationUpDown.Location = new System.Drawing.Point(94, 88);
			this.ViewerRotationUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.ViewerRotationUpDown.Name = "ViewerRotationUpDown";
			this.ViewerRotationUpDown.Size = new System.Drawing.Size(64, 20);
			this.ViewerRotationUpDown.TabIndex = 9;
			this.ViewerRotationUpDown.ValueChanged += new System.EventHandler(this.ViewerRotationUpDown_ValueChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(6, 92);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(88, 16);
			this.label9.TabIndex = 8;
			this.label9.Text = "Viewer rotation:";
			// 
			// ZoomUpDown
			// 
			this.ZoomUpDown.DecimalPlaces = 2;
			this.ZoomUpDown.Location = new System.Drawing.Point(94, 64);
			this.ZoomUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.ZoomUpDown.Name = "ZoomUpDown";
			this.ZoomUpDown.Size = new System.Drawing.Size(64, 20);
			this.ZoomUpDown.TabIndex = 7;
			this.ZoomUpDown.ValueChanged += new System.EventHandler(this.ZoomUpDown_ValueChanged);
			// 
			// ElevationUpDown
			// 
			this.ElevationUpDown.DecimalPlaces = 2;
			this.ElevationUpDown.Location = new System.Drawing.Point(94, 40);
			this.ElevationUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.ElevationUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.ElevationUpDown.Name = "ElevationUpDown";
			this.ElevationUpDown.Size = new System.Drawing.Size(64, 20);
			this.ElevationUpDown.TabIndex = 6;
			this.ElevationUpDown.ValueChanged += new System.EventHandler(this.ElevationUpDown_ValueChanged);
			// 
			// RotationUpDown
			// 
			this.RotationUpDown.Cursor = System.Windows.Forms.Cursors.Default;
			this.RotationUpDown.DecimalPlaces = 2;
			this.RotationUpDown.Location = new System.Drawing.Point(94, 16);
			this.RotationUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.RotationUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.RotationUpDown.Name = "RotationUpDown";
			this.RotationUpDown.Size = new System.Drawing.Size(64, 20);
			this.RotationUpDown.TabIndex = 5;
			this.RotationUpDown.ValueChanged += new System.EventHandler(this.RotationUpDown_ValueChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 68);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "Zoom:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 44);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 1;
			this.label3.Text = "Elevation:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Rotation:";
			// 
			// UseWindowRenderSurfaceCheckBox
			// 
			this.UseWindowRenderSurfaceCheckBox.ButtonProperties.BorderOffset = 2;
			this.UseWindowRenderSurfaceCheckBox.Location = new System.Drawing.Point(4, 186);
			this.UseWindowRenderSurfaceCheckBox.Name = "UseWindowRenderSurfaceCheckBox";
			this.UseWindowRenderSurfaceCheckBox.Size = new System.Drawing.Size(120, 24);
			this.UseWindowRenderSurfaceCheckBox.TabIndex = 15;
			this.UseWindowRenderSurfaceCheckBox.Text = "Render to window";
			this.UseWindowRenderSurfaceCheckBox.CheckedChanged += new System.EventHandler(this.UseWindowRenderSurfaceCheckBox_CheckedChanged);
			// 
			// NDragToolsUC
			// 
			this.Controls.Add(this.UseWindowRenderSurfaceCheckBox);
			this.Controls.Add(this.ProjectionParametersGroupBox);
			this.Controls.Add(this.DragModeComboBox);
			this.Controls.Add(this.label1);
			this.Name = "NDragToolsUC";
			this.Size = new System.Drawing.Size(180, 221);
			this.ProjectionParametersGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ViewerRotationUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ZoomUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ElevationUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RotationUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Drag Operations");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // disable legend
            nChartControl1.Legends[0].Mode = LegendMode.Disabled;

            // configure chart
            NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftCameraLight);
			chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlace stripe
            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

            // setup bar series
            NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            bar.Name = "Bar Series";
            bar.DataLabelStyle.Visible = true;

			// add some data to the bar series
			bar.AddDataPoint(new NDataPoint(18, "C++"));
			bar.AddDataPoint(new NDataPoint(15, "Ruby"));
			bar.AddDataPoint(new NDataPoint(21, "Python"));
			bar.AddDataPoint(new NDataPoint(23, "Java"));
			bar.AddDataPoint(new NDataPoint(27, "Javascript"));
			bar.AddDataPoint(new NDataPoint(29, "C#"));
			bar.AddDataPoint(new NDataPoint(26, "PHP"));

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.AutumnMultiColor);
            styleSheet.Apply(nChartControl1.Document);

            // init form controls
			DragModeComboBox.Items.Add("Disabled");
			DragModeComboBox.Items.Add("Trackball");
			DragModeComboBox.Items.Add("Zoom");
			DragModeComboBox.Items.Add("Offset");
			DragModeComboBox.SelectedIndex = 0;

			nChartControl1.Controller.Selection.Add(chart);
			
			UpdateControlsFromChart();
		}


		private void OnViewChange(object sender, EventArgs eventArgs)
		{
			UpdateControlsFromChart();
		}

		private void UpdateControlsFromChart()
		{
            NProjection projection = nChartControl1.Charts[0].Projection;

            RotationUpDown.Value = (decimal)projection.Rotation;
            ElevationUpDown.Value = (decimal)projection.Elevation;
            ZoomUpDown.Value = (decimal)projection.Zoom;
            ViewerRotationUpDown.Value = (decimal)projection.ViewerRotation;
		}

		private void ViewerRotationUpDown_ValueChanged(object sender, System.EventArgs e)
		{
            nChartControl1.Charts[0].Projection.ViewerRotation = (float)ViewerRotationUpDown.Value;
			nChartControl1.Refresh();
		}

		private void ZoomUpDown_ValueChanged(object sender, System.EventArgs e)
		{
            nChartControl1.Charts[0].Projection.Zoom = (float)ZoomUpDown.Value;		
			nChartControl1.Refresh();				
		}

		private void ElevationUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			nChartControl1.Charts[0].Projection.Elevation = (float)ElevationUpDown.Value;		
			nChartControl1.Refresh();		
		}

		private void RotationUpDown_ValueChanged(object sender, System.EventArgs e)
		{
            nChartControl1.Charts[0].Projection.Rotation = (float)RotationUpDown.Value;		
			nChartControl1.Refresh();
		}

		private void DragModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NDragTool dragTool = null;

			if (nChartControl1.Controller.Tools.Count > 0)
			{	
				dragTool = nChartControl1.Controller.Tools[0] as NDragTool;
			}

			if (dragTool != null)
			{
				dragTool.Drag -= new EventHandler(OnViewChange);
				dragTool = null;
			}

			nChartControl1.Controller.Tools.Clear();
			
			switch (DragModeComboBox.SelectedIndex)
			{
				// Trackball
				case 1:
					dragTool = new NTrackballTool();
					break;
				// Zoom 
				case 2:
					dragTool = new NZoomTool();
					break;
				// Offset
				case 3:
					dragTool = new NOffsetTool();
					break;
			}

			if (dragTool != null)
			{
				dragTool.Drag += new EventHandler(OnViewChange);
				nChartControl1.Controller.Tools.Add(dragTool);
			}
		}

		private void UseWindowRenderSurfaceCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
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
