using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Resources;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NAutoWallsAndAxesVisibilityUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NCheckBox AutoWallVisibilityCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox LightsInCameraSpaceCheck;
		private Nevron.UI.WinForm.Controls.NComboBox AxisAnchorsModeCombo;
		private Label label2;
		private System.ComponentModel.Container components = null;

		public NAutoWallsAndAxesVisibilityUC()
		{
			InitializeComponent();

			AxisAnchorsModeCombo.Items.Add("Best Visibility");
			AxisAnchorsModeCombo.Items.Add("Auto Side");
			AxisAnchorsModeCombo.Items.Add("Manual");
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
			this.AutoWallVisibilityCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.LightsInCameraSpaceCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.AxisAnchorsModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// AutoWallVisibilityCheck
			// 
			this.AutoWallVisibilityCheck.ButtonProperties.BorderOffset = 2;
			this.AutoWallVisibilityCheck.Location = new System.Drawing.Point(12, 14);
			this.AutoWallVisibilityCheck.Name = "AutoWallVisibilityCheck";
			this.AutoWallVisibilityCheck.Size = new System.Drawing.Size(157, 21);
			this.AutoWallVisibilityCheck.TabIndex = 0;
			this.AutoWallVisibilityCheck.Text = "Enable Auto Wall Visibility";
			this.AutoWallVisibilityCheck.CheckedChanged += new System.EventHandler(this.AutoWallVisibilityCheck_CheckedChanged);
			// 
			// LightsInCameraSpaceCheck
			// 
			this.LightsInCameraSpaceCheck.ButtonProperties.BorderOffset = 2;
			this.LightsInCameraSpaceCheck.Location = new System.Drawing.Point(12, 48);
			this.LightsInCameraSpaceCheck.Name = "LightsInCameraSpaceCheck";
			this.LightsInCameraSpaceCheck.Size = new System.Drawing.Size(157, 21);
			this.LightsInCameraSpaceCheck.TabIndex = 2;
			this.LightsInCameraSpaceCheck.Text = "Lights in Camera Space";
			this.LightsInCameraSpaceCheck.CheckedChanged += new System.EventHandler(this.LightsInCameraSpaceCheck_CheckedChanged);
			// 
			// AxisAnchorsModeCombo
			// 
			this.AxisAnchorsModeCombo.ListProperties.CheckBoxDataMember = "";
			this.AxisAnchorsModeCombo.ListProperties.DataSource = null;
			this.AxisAnchorsModeCombo.ListProperties.DisplayMember = "";
			this.AxisAnchorsModeCombo.Location = new System.Drawing.Point(12, 99);
			this.AxisAnchorsModeCombo.Name = "AxisAnchorsModeCombo";
			this.AxisAnchorsModeCombo.Size = new System.Drawing.Size(142, 21);
			this.AxisAnchorsModeCombo.TabIndex = 3;
			this.AxisAnchorsModeCombo.SelectedIndexChanged += new System.EventHandler(this.AxisAnchorsModeCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 82);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 14);
			this.label2.TabIndex = 4;
			this.label2.Text = "Axis Anchors Mode:";
			// 
			// NAutoWallsAndAxesVisibilityUC
			// 
			this.Controls.Add(this.label2);
			this.Controls.Add(this.AxisAnchorsModeCombo);
			this.Controls.Add(this.LightsInCameraSpaceCheck);
			this.Controls.Add(this.AutoWallVisibilityCheck);
			this.Name = "NAutoWallsAndAxesVisibilityUC";
			this.Size = new System.Drawing.Size(180, 238);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			nChartControl1.Legends.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Chart Walls");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(3, NRelativeUnit.ParentPercentage));

			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 55;
			chart.Height = 25;
			chart.Depth = 40;
			chart.BoundsMode = BoundsMode.Fit;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.GlobalAmbientLight = Color.FromArgb(20, 20, 20);

            // add interlaced stripe to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[]{
				ChartWallType.Back,
				ChartWallType.Left,
				ChartWallType.Right,
				ChartWallType.Front };

			NStandardScaleConfigurator scaleY = (NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.StripStyles.Add(stripStyle);

			// create several series
			for (int i = 0; i < 4; i++)
			{
				NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
				bar.Values.FillRandom(Random, 6);
				bar.DataLabelStyle.Visible = false;
			}

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			AutoWallVisibilityCheck.Checked = true;
			LightsInCameraSpaceCheck.Checked = true;
			AxisAnchorsModeCombo.SelectedIndex = 0;
		}

		private void AutoWallVisibilityCheck_CheckedChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];

			if (AutoWallVisibilityCheck.Checked)
			{
				foreach (NChartWall wall in chart.Walls)
				{
					wall.VisibilityMode = WallVisibilityMode.Auto;
				}
			}
			else
			{
				chart.Wall(ChartWallType.Left).VisibilityMode = WallVisibilityMode.Visible;
				chart.Wall(ChartWallType.Back).VisibilityMode = WallVisibilityMode.Visible;
				chart.Wall(ChartWallType.Floor).VisibilityMode = WallVisibilityMode.Visible;
				chart.Wall(ChartWallType.Front).VisibilityMode = WallVisibilityMode.Hidden;
				chart.Wall(ChartWallType.Top).VisibilityMode = WallVisibilityMode.Hidden;
				chart.Wall(ChartWallType.Right).VisibilityMode = WallVisibilityMode.Hidden;
			}

			nChartControl1.Refresh();
		}

		private void LightsInCameraSpaceCheck_CheckedChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];

			NPointLightSource light = new NPointLightSource();
			light.Ambient = Color.FromArgb(64, 64, 64);
			light.Diffuse = Color.FromArgb(230, 230, 230);
			light.Specular = Color.FromArgb(10, 10, 10);

			if (LightsInCameraSpaceCheck.Checked)
			{
				light.CoordinateMode = LightSourceCoordinateMode.Camera;
				light.Position = new NVector3DF(0, 0, 50);
			}
			else
			{
				light.CoordinateMode = LightSourceCoordinateMode.Model;
				light.Position = new NVector3DF(30, 20, 50);
			}

			chart.LightModel.LightSources.Clear();
			chart.LightModel.LightSources.Add(light);

			nChartControl1.Refresh();
		}

		private void AxisAnchorsModeCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];

			NAxisAnchor anchorY = null;
			NAxisAnchor anchorX = null;
			NAxisAnchor anchorZ = null;

			switch (AxisAnchorsModeCombo.SelectedIndex)
			{
				case 0:
					anchorY = new NBestVisibilityAxisAnchor(AxisOrientation.Vertical);
					anchorX = new NBestVisibilityAxisAnchor(AxisOrientation.Horizontal);
					anchorZ = new NBestVisibilityAxisAnchor(AxisOrientation.Depth);
					break;

				case 1:
					anchorY = new NAutoSideAxisAnchor(AxisOrientation.Vertical);
					anchorX = new NAutoSideAxisAnchor(AxisOrientation.Horizontal);
					anchorZ = new NAutoSideAxisAnchor(AxisOrientation.Depth);
					break;

				case 2:
					anchorY = new NDockAxisAnchor(AxisDockZone.FrontLeft);
					anchorX = new NDockAxisAnchor(AxisDockZone.FrontBottom);
					anchorZ = new NDockAxisAnchor(AxisDockZone.BottomRight);
					break;
			}

			chart.Axis(StandardAxis.PrimaryY).Anchor = anchorY;
			chart.Axis(StandardAxis.PrimaryX).Anchor = anchorX;
			chart.Axis(StandardAxis.Depth).Anchor = anchorZ;

			nChartControl1.Refresh();
		}
	}
}
