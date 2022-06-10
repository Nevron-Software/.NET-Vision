using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Nevron.UI;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NTriangulatedSurfaceUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox3;
		private Nevron.UI.WinForm.Controls.NCheckBox smoothPaletteCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox drawFlatCheck;
		private Nevron.UI.WinForm.Controls.NComboBox positionModeCombo;
		private Nevron.UI.WinForm.Controls.NHScrollBar customValueScroll;
		private Nevron.UI.WinForm.Controls.NComboBox frameModeCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox smoothShadingCheck;
		private Nevron.UI.WinForm.Controls.NComboBox fillModeCombo;
		private Nevron.UI.WinForm.Controls.NComboBox frameColorModeCombo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox4;
		private System.ComponentModel.Container components = null;

		public NTriangulatedSurfaceUC()
		{
			InitializeComponent();

			fillModeCombo.Items.Add("None");
			fillModeCombo.Items.Add("Uniform");
			fillModeCombo.Items.Add("Zone");

			frameModeCombo.Items.Add("None");
			frameModeCombo.Items.Add("Mesh");
			frameModeCombo.Items.Add("Contour");
			frameModeCombo.Items.Add("Mesh-Contour");
			frameModeCombo.Items.Add("Dots");

			frameColorModeCombo.Items.Add("Uniform");
			frameColorModeCombo.Items.Add("Zone");

			positionModeCombo.Items.Add("Axis Begin");
			positionModeCombo.Items.Add("Axis End");
			positionModeCombo.Items.Add("Custom Value");
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
			this.smoothPaletteCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.drawFlatCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.frameModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nGroupBox4 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.customValueScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label1 = new System.Windows.Forms.Label();
			this.positionModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.frameColorModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.smoothShadingCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.fillModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nGroupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nGroupBox4.SuspendLayout();
			this.nGroupBox1.SuspendLayout();
			this.nGroupBox2.SuspendLayout();
			this.nGroupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// smoothPaletteCheck
			// 
			this.smoothPaletteCheck.ButtonProperties.BorderOffset = 2;
			this.smoothPaletteCheck.Location = new System.Drawing.Point(15, 32);
			this.smoothPaletteCheck.Name = "smoothPaletteCheck";
			this.smoothPaletteCheck.Size = new System.Drawing.Size(108, 21);
			this.smoothPaletteCheck.TabIndex = 0;
			this.smoothPaletteCheck.Text = "Smooth Palette";
			this.smoothPaletteCheck.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheck_CheckedChanged);
			// 
			// drawFlatCheck
			// 
			this.drawFlatCheck.ButtonProperties.BorderOffset = 2;
			this.drawFlatCheck.Location = new System.Drawing.Point(15, 24);
			this.drawFlatCheck.Name = "drawFlatCheck";
			this.drawFlatCheck.Size = new System.Drawing.Size(118, 20);
			this.drawFlatCheck.TabIndex = 0;
			this.drawFlatCheck.Text = "Draw Flat";
			this.drawFlatCheck.CheckedChanged += new System.EventHandler(this.DrawFlatCheck_CheckedChanged);
			// 
			// frameModeCombo
			// 
			this.frameModeCombo.ListProperties.CheckBoxDataMember = "";
			this.frameModeCombo.ListProperties.DataSource = null;
			this.frameModeCombo.ListProperties.DisplayMember = "";
			this.frameModeCombo.Location = new System.Drawing.Point(15, 40);
			this.frameModeCombo.Name = "frameModeCombo";
			this.frameModeCombo.Size = new System.Drawing.Size(139, 21);
			this.frameModeCombo.TabIndex = 1;
			this.frameModeCombo.SelectedIndexChanged += new System.EventHandler(this.FrameModeCombo_SelectedIndexChanged);
			// 
			// nGroupBox4
			// 
			this.nGroupBox4.Controls.Add(this.label3);
			this.nGroupBox4.Controls.Add(this.customValueScroll);
			this.nGroupBox4.Controls.Add(this.label1);
			this.nGroupBox4.Controls.Add(this.positionModeCombo);
			this.nGroupBox4.Controls.Add(this.drawFlatCheck);
			this.nGroupBox4.ImageIndex = 0;
			this.nGroupBox4.Location = new System.Drawing.Point(3, 331);
			this.nGroupBox4.Name = "nGroupBox4";
			this.nGroupBox4.Size = new System.Drawing.Size(175, 136);
			this.nGroupBox4.TabIndex = 3;
			this.nGroupBox4.TabStop = false;
			this.nGroupBox4.Text = "Flat Mode";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(15, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(118, 15);
			this.label3.TabIndex = 3;
			this.label3.Text = "Custom Value:";
			// 
			// customValueScroll
			// 
			this.customValueScroll.Enabled = false;
			this.customValueScroll.LargeChange = 1;
			this.customValueScroll.Location = new System.Drawing.Point(15, 112);
			this.customValueScroll.Maximum = 250;
			this.customValueScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.customValueScroll.Name = "customValueScroll";
			this.customValueScroll.Size = new System.Drawing.Size(140, 17);
			this.customValueScroll.TabIndex = 4;
			this.customValueScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.CustomValueScroll_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(15, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(118, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Position Mode:";
			// 
			// positionModeCombo
			// 
			this.positionModeCombo.Enabled = false;
			this.positionModeCombo.ListProperties.CheckBoxDataMember = "";
			this.positionModeCombo.ListProperties.DataSource = null;
			this.positionModeCombo.ListProperties.DisplayMember = "";
			this.positionModeCombo.Location = new System.Drawing.Point(15, 64);
			this.positionModeCombo.Name = "positionModeCombo";
			this.positionModeCombo.Size = new System.Drawing.Size(140, 21);
			this.positionModeCombo.TabIndex = 2;
			this.positionModeCombo.SelectedIndexChanged += new System.EventHandler(this.PositionModeCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(15, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(139, 14);
			this.label2.TabIndex = 0;
			this.label2.Text = "Frame Mode:";
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.label5);
			this.nGroupBox1.Controls.Add(this.frameColorModeCombo);
			this.nGroupBox1.Controls.Add(this.label2);
			this.nGroupBox1.Controls.Add(this.frameModeCombo);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(3, 115);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(175, 120);
			this.nGroupBox1.TabIndex = 1;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Surface Frame";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(15, 72);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(139, 14);
			this.label5.TabIndex = 2;
			this.label5.Text = "Frame Color Mode:";
			// 
			// frameColorModeCombo
			// 
			this.frameColorModeCombo.ListProperties.CheckBoxDataMember = "";
			this.frameColorModeCombo.ListProperties.DataSource = null;
			this.frameColorModeCombo.ListProperties.DisplayMember = "";
			this.frameColorModeCombo.Location = new System.Drawing.Point(15, 88);
			this.frameColorModeCombo.Name = "frameColorModeCombo";
			this.frameColorModeCombo.Size = new System.Drawing.Size(139, 21);
			this.frameColorModeCombo.TabIndex = 3;
			this.frameColorModeCombo.SelectedIndexChanged += new System.EventHandler(this.FrameColorModeCombo_SelectedIndexChanged);
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.smoothShadingCheck);
			this.nGroupBox2.Controls.Add(this.label4);
			this.nGroupBox2.Controls.Add(this.fillModeCombo);
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(3, 3);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(174, 96);
			this.nGroupBox2.TabIndex = 0;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Surface Filling";
			// 
			// smoothShadingCheck
			// 
			this.smoothShadingCheck.ButtonProperties.BorderOffset = 2;
			this.smoothShadingCheck.Location = new System.Drawing.Point(15, 72);
			this.smoothShadingCheck.Name = "smoothShadingCheck";
			this.smoothShadingCheck.Size = new System.Drawing.Size(124, 20);
			this.smoothShadingCheck.TabIndex = 2;
			this.smoothShadingCheck.Text = "Smooth Shading";
			this.smoothShadingCheck.CheckedChanged += new System.EventHandler(this.SmoothShadingCheck_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(15, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(124, 14);
			this.label4.TabIndex = 0;
			this.label4.Text = "Fill Mode:";
			// 
			// fillModeCombo
			// 
			this.fillModeCombo.ListProperties.CheckBoxDataMember = "";
			this.fillModeCombo.ListProperties.DataSource = null;
			this.fillModeCombo.ListProperties.DisplayMember = "";
			this.fillModeCombo.Location = new System.Drawing.Point(15, 40);
			this.fillModeCombo.Name = "fillModeCombo";
			this.fillModeCombo.Size = new System.Drawing.Size(140, 21);
			this.fillModeCombo.TabIndex = 1;
			this.fillModeCombo.SelectedIndexChanged += new System.EventHandler(this.FillModeCombo_SelectedIndexChanged);
			// 
			// nGroupBox3
			// 
			this.nGroupBox3.Controls.Add(this.smoothPaletteCheck);
			this.nGroupBox3.ImageIndex = 0;
			this.nGroupBox3.Location = new System.Drawing.Point(3, 251);
			this.nGroupBox3.Name = "nGroupBox3";
			this.nGroupBox3.Size = new System.Drawing.Size(175, 64);
			this.nGroupBox3.TabIndex = 2;
			this.nGroupBox3.TabStop = false;
			this.nGroupBox3.Text = "Palette";
			// 
			// NTriangulatedSurfaceUC
			// 
			this.Controls.Add(this.nGroupBox3);
			this.Controls.Add(this.nGroupBox2);
			this.Controls.Add(this.nGroupBox1);
			this.Controls.Add(this.nGroupBox4);
			this.Name = "NTriangulatedSurfaceUC";
			this.Size = new System.Drawing.Size(180, 496);
			this.nGroupBox4.ResumeLayout(false);
			this.nGroupBox1.ResumeLayout(false);
			this.nGroupBox2.ResumeLayout(false);
			this.nGroupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

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
			NLabel title = nChartControl1.Labels.AddHeader("Surface Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.BoundsMode = BoundsMode.Fit;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 10.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.Projection.Elevation = 45;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.RoundToTickMax = false;
			scaleY.RoundToTickMin = false;
			scaleY.MinTickDistance = new NLength(10, NGraphicsUnit.Point);
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Left, ChartWallType.Back };
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.RoundToTickMax = false;
			scaleX.RoundToTickMin = false;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Floor, ChartWallType.Back };
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup Z axis
			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			scaleZ.RoundToTickMax = false;
			scaleZ.RoundToTickMin = false;
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Floor, ChartWallType.Left };
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ;

			// add the surface series
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series.Add(SeriesType.TriangulatedSurface);
			surface.Name = "Surface";
			surface.Legend.Mode = SeriesLegendMode.None;
			surface.SyncPaletteWithAxisScale = false;
			surface.ValueFormatter.FormatSpecifier = "0.00";
			surface.FillStyle = new NColorFillStyle(Color.YellowGreen);

			FillData();

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// form controls
			fillModeCombo.SelectedIndex = 2;
			smoothShadingCheck.Checked = true;
			frameModeCombo.SelectedIndex = 0;
			frameColorModeCombo.SelectedIndex = 0;
			smoothPaletteCheck.Checked = true;
			positionModeCombo.SelectedIndex = 0;
			customValueScroll.Value = 100;
		}

		private void FillData()
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			Stream stream = null;
			BinaryReader reader = null;

			try
			{
				// fill the XYZ data from a binary resource
				stream = NResourceHelper.GetResourceStream(GetType().Assembly, "DataXYZ.bin", "Nevron.Examples.Chart.WinForm.Resources");
				reader = new BinaryReader(stream);

				int nDataPointsCount = (int)stream.Length / 12;

				//surface.Data.SetCapacity(nDataPointsCount);
				NVector3DF[] data = new NVector3DF[nDataPointsCount];

				// fill Y values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					data[i].Y = reader.ReadSingle();
				}

				// fill X values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					data[i].X = reader.ReadSingle();
				}

				// fill Z values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					data[i].Z = reader.ReadSingle();
				}

				for (int i = 0; i < nDataPointsCount; i++)
				{
					surface.Data.AddValue(data[i]);
				}
			}
			finally
			{
				if(reader != null)
					reader.Close();

				if(stream != null)
					stream.Close();
			}
		}

		private void SmoothShadingCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			if(smoothShadingCheck.Checked)
			{
				surface.ShadingMode = ShadingMode.Smooth;
			}
			else
			{
				surface.ShadingMode = ShadingMode.Flat;
			}

			nChartControl1.Refresh();
		}
		private void FillModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			switch(fillModeCombo.SelectedIndex)
			{
				case 0:
					surface.FillMode = SurfaceFillMode.None;
					smoothShadingCheck.Enabled = false;
					break;

				case 1:
					surface.FillMode = SurfaceFillMode.Uniform;
					smoothShadingCheck.Enabled = true;
					break;

				case 2:
					surface.FillMode = SurfaceFillMode.Zone;
					smoothShadingCheck.Enabled = true;
					break;
			}

			nChartControl1.Refresh();
		}
		private void FrameModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			surface.FrameMode = (SurfaceFrameMode)frameModeCombo.SelectedIndex;
			nChartControl1.Refresh();

			// form controls
			frameColorModeCombo.Enabled = (surface.FrameMode != SurfaceFrameMode.None);
		}
		private void FrameColorModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			switch(frameColorModeCombo.SelectedIndex)
			{
				case 0:
					surface.FrameColorMode = SurfaceFrameColorMode.Uniform;
					break;

				case 1:
					surface.FrameColorMode = SurfaceFrameColorMode.Zone;
					break;
			}

			nChartControl1.Refresh();		
		}
		private void SmoothPaletteCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			if(smoothPaletteCheck.Checked)
			{
				surface.SmoothPalette = true;
				surface.PaletteSteps = 7;
				surface.Legend.Format = "<zone_value>";
			}
			else
			{
				surface.SmoothPalette = false;
				surface.PaletteSteps = 8;
				surface.Legend.Format = "<zone_begin> - <zone_end>";
			}

			nChartControl1.Refresh();
		}
		private void DrawFlatCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			surface.DrawFlat = drawFlatCheck.Checked;
			nChartControl1.Refresh();

			// form controls
			positionModeCombo.Enabled = drawFlatCheck.Checked;
			customValueScroll.Enabled = drawFlatCheck.Checked;
		}
		private void PositionModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			surface.PositionMode = (SurfacePositionMode)positionModeCombo.SelectedIndex;
			nChartControl1.Refresh();
		}
		private void CustomValueScroll_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			surface.PositionValue = customValueScroll.Value;
			nChartControl1.Refresh();
		}
	}
}
