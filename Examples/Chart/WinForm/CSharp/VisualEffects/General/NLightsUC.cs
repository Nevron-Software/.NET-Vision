using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NLightsUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NComboBox CustomLightModelCombo;
		private Nevron.UI.WinForm.Controls.NComboBox PredefinedLightModelCombo;
		private Nevron.UI.WinForm.Controls.NRadioButton UseCustomLightModelButton;
		private Nevron.UI.WinForm.Controls.NRadioButton UsePredefinedLightModelButton;
		private System.ComponentModel.Container components = null;

		public NLightsUC()
		{
			InitializeComponent();

			CustomLightModelCombo.Items.Add("Directional Light");
			CustomLightModelCombo.Items.Add("Point Light");
			CustomLightModelCombo.Items.Add("Point Light in Camera Space");
			CustomLightModelCombo.Items.Add("Spot Light");
			CustomLightModelCombo.Items.Add("Multiple Light Sources");

			PredefinedLightModelCombo.FillFromEnum(typeof(PredefinedLightModel));
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
			this.CustomLightModelCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.PredefinedLightModelCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.UseCustomLightModelButton = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.UsePredefinedLightModelButton = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.SuspendLayout();
			// 
			// CustomLightModelCombo
			// 
			this.CustomLightModelCombo.Location = new System.Drawing.Point(11, 37);
			this.CustomLightModelCombo.Name = "CustomLightModelCombo";
			this.CustomLightModelCombo.Size = new System.Drawing.Size(189, 21);
			this.CustomLightModelCombo.TabIndex = 1;
			this.CustomLightModelCombo.SelectedIndexChanged += new System.EventHandler(this.CustomLightModelCombo_SelectedIndexChanged);
			// 
			// PredefinedLightModelCombo
			// 
			this.PredefinedLightModelCombo.Location = new System.Drawing.Point(11, 94);
			this.PredefinedLightModelCombo.Name = "PredefinedLightModelCombo";
			this.PredefinedLightModelCombo.Size = new System.Drawing.Size(189, 21);
			this.PredefinedLightModelCombo.TabIndex = 3;
			this.PredefinedLightModelCombo.SelectedIndexChanged += new System.EventHandler(this.PredefinedLightModelCombo_SelectedIndexChanged);
			// 
			// UseCustomLightModelButton
			// 
			this.UseCustomLightModelButton.ButtonProperties.BorderOffset = 2;
			this.UseCustomLightModelButton.Location = new System.Drawing.Point(11, 7);
			this.UseCustomLightModelButton.Name = "UseCustomLightModelButton";
			this.UseCustomLightModelButton.Size = new System.Drawing.Size(189, 24);
			this.UseCustomLightModelButton.TabIndex = 0;
			this.UseCustomLightModelButton.Text = "Use Custom Light Model:";
			this.UseCustomLightModelButton.CheckedChanged += new System.EventHandler(this.UseCustomLightModelButton_CheckedChanged);
			// 
			// UsePredefinedLightModelButton
			// 
			this.UsePredefinedLightModelButton.ButtonProperties.BorderOffset = 2;
			this.UsePredefinedLightModelButton.Location = new System.Drawing.Point(11, 67);
			this.UsePredefinedLightModelButton.Name = "UsePredefinedLightModelButton";
			this.UsePredefinedLightModelButton.Size = new System.Drawing.Size(189, 24);
			this.UsePredefinedLightModelButton.TabIndex = 2;
			this.UsePredefinedLightModelButton.Text = "Use Predefined Light Model:";
			this.UsePredefinedLightModelButton.CheckedChanged += new System.EventHandler(this.UsePredefinedLightModelButton_CheckedChanged);
			// 
			// NLightsUC
			// 
			this.Controls.Add(this.UsePredefinedLightModelButton);
			this.Controls.Add(this.UseCustomLightModelButton);
			this.Controls.Add(this.PredefinedLightModelCombo);
			this.Controls.Add(this.CustomLightModelCombo);
			this.Name = "NLightsUC";
			this.Size = new System.Drawing.Size(213, 157);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Lighting in 3D");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// remove legends
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.Width = 60;
			chart.Height = 30;
			chart.Depth = 60;

			// setup X axis
			NAxis axisX = chart.Axis(StandardAxis.PrimaryX);
			axisX.Anchor = new NBestVisibilityAxisAnchor(AxisOrientation.Horizontal);
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.RoundToTickMin = false;
			scaleX.RoundToTickMax = false;
			axisX.ScaleConfigurator = scaleX;

			// setup Y axis
			NAxis axisY = chart.Axis(StandardAxis.PrimaryY);
			axisY.Anchor = new NBestVisibilityAxisAnchor(AxisOrientation.Vertical);
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)axisY.ScaleConfigurator;
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[]{};
			scaleY.RoundToTickMin = false;
			scaleY.RoundToTickMax = false;
			scaleY.MinTickDistance = new NLength(15, NGraphicsUnit.Point);

			// setup Z axis
			NAxis axisZ = chart.Axis(StandardAxis.Depth);
			axisZ.Anchor = new NBestVisibilityAxisAnchor(AxisOrientation.Depth);
			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			scaleZ.RoundToTickMin = false;
			scaleZ.RoundToTickMax = false;
			axisZ.ScaleConfigurator = scaleZ;

			// setup chart walls
			foreach (NChartWall wall in chart.Walls)
			{
				wall.VisibilityMode = WallVisibilityMode.Auto;
			}

			// create chart series
			CreateSurface(chart);
			CreateSpheres(chart);
			CreateBoxes(chart);
			

			CustomLightModelCombo.SelectedIndex = 1;
			PredefinedLightModelCombo.SelectedIndex = 1;
			UseCustomLightModelButton.Checked = true;
		}

		private void CreateBoxes(NChart chart)
		{
			NShapeSeries shape = new NShapeSeries();
			chart.Series.Add(shape);
			shape.DataLabelStyle.Visible = false;
			shape.InflateMargins = true;
			shape.Shape = BarShape.Bar;
			shape.UseXValues = true;
			shape.UseZValues = true;
			shape.XSizesUnits = MeasurementUnits.Model;
			shape.YSizesUnits = MeasurementUnits.Model;
			shape.ZSizesUnits = MeasurementUnits.Model;

			Color color = Color.FromArgb(147, 120, 197);

			shape.FillStyle = new NColorFillStyle(color);
			shape.BorderStyle.Color = color;

			shape.Values.Add(440);
			shape.XValues.Add(20);
			shape.ZValues.Add(25);
			shape.XSizes.Add(4);
			shape.YSizes.Add(4);
			shape.ZSizes.Add(4);

			shape.Values.Add(480);
			shape.XValues.Add(14);
			shape.ZValues.Add(25);
			shape.XSizes.Add(3);
			shape.YSizes.Add(3);
			shape.ZSizes.Add(3);

			shape.Values.Add(500);
			shape.XValues.Add(8);
			shape.ZValues.Add(25);
			shape.XSizes.Add(2);
			shape.YSizes.Add(2);
			shape.ZSizes.Add(2);
		}
		private void CreateSpheres(NChart chart)
		{
			NShapeSeries shape = new NShapeSeries();
			chart.Series.Add(shape);
			shape.DataLabelStyle.Visible = false;
			shape.InflateMargins = true;
			shape.Shape = BarShape.Ellipsoid;
			shape.UseXValues = true;
			shape.UseZValues = true;
			shape.XSizesUnits = MeasurementUnits.Model;
			shape.YSizesUnits = MeasurementUnits.Model;
			shape.ZSizesUnits = MeasurementUnits.Model;
			shape.FillStyle = new NColorFillStyle(Color.FromArgb(202, 100, 92));
			shape.BorderStyle = new NStrokeStyle(0, Color.White);

			shape.Values.Add(200);
			shape.XValues.Add(10);
			shape.ZValues.Add(10);
			shape.XSizes.Add(8);
			shape.YSizes.Add(8);
			shape.ZSizes.Add(8);
		}
		private void CreateSurface(NChart chart)
		{
			NGridSurfaceSeries surface = new NGridSurfaceSeries();
			chart.Series.Add(surface);
			surface.Name = "Surface";
			surface.FillMode = SurfaceFillMode.Uniform;
			surface.FrameMode = SurfaceFrameMode.None;
			surface.ShadingMode = ShadingMode.Smooth;
			surface.Data.SetGridSize(30, 30);
			surface.SyncPaletteWithAxisScale = false;
			surface.ValueFormatter.FormatSpecifier = "0.00";

			Color color = Color.FromArgb(190, 130, 189);

			NFillStyle fillStyle = new NColorFillStyle();
			NMaterialStyle material = fillStyle.MaterialStyle;
			material.Ambient = color;
			material.Diffuse = color;
			material.Specular = Color.FromArgb(120, 120, 120);
			material.Emissive = Color.Black;
			material.Shininess = 10;

			surface.FillStyle = fillStyle;

			FillSurfaceData(surface);
		}
		private void FillSurfaceData(NGridSurfaceSeries surface)
		{
			double y, x, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 30.0;
			const double dIntervalZ = 30.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			for (int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for (int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					y = (x * x) - (z * z);
					y += 200 * Math.Sin(x / 4.0) * Math.Cos(z / 4.0);

					surface.Data.SetValue(i, j, y);
				}
			}
		}

		private void DirectionalLight(NChart chart)
		{
			NDirectionalLightSource light = new NDirectionalLightSource();

			light.CoordinateMode = LightSourceCoordinateMode.Model;
			light.Direction = new NVector3DF(-2, -4, -3);
			light.Ambient = Color.FromArgb(60, 60, 60);
			light.Diffuse = Color.FromArgb(230, 230, 230);
			light.Specular = Color.FromArgb(50, 50, 50);

			chart.LightModel.LightSources.Clear();
			chart.LightModel.LightSources.Add(light);
			chart.LightModel.EnableLighting = true;
			chart.LightModel.LocalViewpointLighting = true;
			chart.LightModel.GlobalAmbientLight = Color.FromArgb(60, 60, 60);
		}
		private void PointLight(NChart chart)
		{
			NPointLightSource light = new NPointLightSource();

			light.CoordinateMode = LightSourceCoordinateMode.Model;
			light.Position = new NVector3DF(9, 36, 14);
			light.Ambient = Color.FromArgb(100, 100, 100);
			light.Diffuse = Color.FromArgb(210, 210, 210);
			light.Specular = Color.FromArgb(70, 70, 70);
			light.ConstantAttenuation = 0.6f;
			light.LinearAttenuation = 0.004f;
			light.QuadraticAttenuation = 0.0002f;

			chart.LightModel.LightSources.Clear();
			chart.LightModel.LightSources.Add(light);
			chart.LightModel.EnableLighting = true;
			chart.LightModel.LocalViewpointLighting = true;
			chart.LightModel.GlobalAmbientLight = Color.FromArgb(60, 60, 60);
		}
		private void PointLightInCameraSpace(NChart chart)
		{
			NPointLightSource light = new NPointLightSource();

			light.CoordinateMode = LightSourceCoordinateMode.Camera;
			light.Position = new NVector3DF(0, 0, 0);
			light.Ambient = Color.FromArgb(100, 100, 100);
			light.Diffuse = Color.FromArgb(210, 210, 210);
			light.Specular = Color.FromArgb(90, 90, 90);
			light.ConstantAttenuation = 0.3f;
			light.LinearAttenuation = 0.0003f;
			light.QuadraticAttenuation = 0.00003f;

			chart.LightModel.LightSources.Clear();
			chart.LightModel.LightSources.Add(light);
			chart.LightModel.EnableLighting = true;
			chart.LightModel.LocalViewpointLighting = true;
			chart.LightModel.GlobalAmbientLight = Color.FromArgb(60, 60, 60);
		}
		private void MultipleLightSources(NChart chart)
		{
			NPointLightSource light1 = new NPointLightSource();
			light1.CoordinateMode = LightSourceCoordinateMode.Model;
			light1.Position = new NVector3DF(0, 36, 16);
			light1.Ambient = Color.FromArgb(60, 0, 0);
			light1.Diffuse = Color.FromArgb(110, 20, 20);
			light1.Specular = Color.FromArgb(80, 60, 60);
			light1.ConstantAttenuation = 0.6f;
			light1.LinearAttenuation = 0.004f;
			light1.QuadraticAttenuation = 0.0002f;

			NPointLightSource light2 = new NPointLightSource();
			light2.CoordinateMode = LightSourceCoordinateMode.Model;
			light2.Position = new NVector3DF(13.85f, 36, -8);
			light2.Ambient = Color.FromArgb(0, 60, 0);
			light2.Diffuse = Color.FromArgb(20, 110, 20);
			light2.Specular = Color.FromArgb(60, 80, 60);
			light2.ConstantAttenuation = 0.6f;
			light2.LinearAttenuation = 0.004f;
			light2.QuadraticAttenuation = 0.0002f;

			NPointLightSource light3 = new NPointLightSource();
			light3.CoordinateMode = LightSourceCoordinateMode.Model;
			light3.Position = new NVector3DF(-13.85f, 36, -8);
			light3.Ambient = Color.FromArgb(0, 0, 60);
			light3.Diffuse = Color.FromArgb(20, 20, 110);
			light3.Specular = Color.FromArgb(60, 60, 80);
			light3.ConstantAttenuation = 0.6f;
			light3.LinearAttenuation = 0.004f;
			light3.QuadraticAttenuation = 0.0002f;

			NPointLightSource light4 = new NPointLightSource();
			light4.CoordinateMode = LightSourceCoordinateMode.Camera;
			light4.Position = new NVector3DF(0, 0, 0);
			light4.Ambient = Color.FromArgb(0, 0, 0);
			light4.Diffuse = Color.FromArgb(90, 90, 90);
			light4.Specular = Color.FromArgb(80, 80, 80);
			light4.ConstantAttenuation = 0.9f;
			light4.LinearAttenuation = 0.0004f;
			light4.QuadraticAttenuation = 0.0f;

			chart.LightModel.LightSources.Clear();
			chart.LightModel.LightSources.Add(light1);
			chart.LightModel.LightSources.Add(light2);
			chart.LightModel.LightSources.Add(light3);
			chart.LightModel.LightSources.Add(light4);
			chart.LightModel.EnableLighting = true;
			chart.LightModel.LocalViewpointLighting = true;
			chart.LightModel.GlobalAmbientLight = Color.FromArgb(60, 60, 60);
		}
		private void SpotLight(NChart chart)
		{
			NSpotLightSource light = new NSpotLightSource();

			light.CoordinateMode = LightSourceCoordinateMode.Model;
			light.Position = new NVector3DF(14, 30, 14);
			light.Direction = new NVector3DF(-0.5f, -1, -0.4f);
			light.Ambient = Color.FromArgb(50, 50, 50);
			light.Diffuse = Color.FromArgb(180, 180, 210);
			light.Specular = Color.FromArgb(80, 80, 80);
			light.ConstantAttenuation = 0.3f;
			light.LinearAttenuation = 0.001f;
			light.QuadraticAttenuation = 0.0001f;
			light.SpotCutoff = 45;
			light.SpotExponent = 15;

			chart.LightModel.LightSources.Clear();
			chart.LightModel.LightSources.Add(light);
			chart.LightModel.EnableLighting = true;
			chart.LightModel.LocalViewpointLighting = true;
			chart.LightModel.GlobalAmbientLight = Color.FromArgb(100, 100, 100);
		}

		private void CustomLightModelCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];

			switch (CustomLightModelCombo.SelectedIndex)
			{
				case 0:
					DirectionalLight(chart);
					break;

				case 1:
					PointLight(chart);
					break;

				case 2:
					PointLightInCameraSpace(chart);
					break;

				case 3:
					SpotLight(chart);
					break;

				case 4:
					MultipleLightSources(chart);
					break;
			}

			nChartControl1.Refresh();
		}
		private void PredefinedLightModelCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];

			PredefinedLightModel lm = (PredefinedLightModel)PredefinedLightModelCombo.SelectedIndex;

			chart.LightModel.SetPredefinedLightModel(lm);

			nChartControl1.Refresh();
		}
		private void UseCustomLightModelButton_CheckedChanged(object sender, EventArgs e)
		{
			CustomLightModelCombo.Enabled = true;
			PredefinedLightModelCombo.Enabled = false;

			CustomLightModelCombo_SelectedIndexChanged(null, null);

			nChartControl1.Refresh();
		}
		private void UsePredefinedLightModelButton_CheckedChanged(object sender, EventArgs e)
		{
			CustomLightModelCombo.Enabled = false;
			PredefinedLightModelCombo.Enabled = true;

			PredefinedLightModelCombo_SelectedIndexChanged(null, null);

			nChartControl1.Refresh();
		}
	}
}
