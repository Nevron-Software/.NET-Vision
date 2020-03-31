using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Resources;
using Nevron.GraphicsCore;
using Nevron.UI;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NShapeHomeUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private Nevron.UI.WinForm.Controls.NButton HouseFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton RoofFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton ChimneyFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton DoorFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton WindowFillStyleButton;
		private System.Windows.Forms.OpenFileDialog openFileDlg;
		private System.ComponentModel.Container components = null;

		public NShapeHomeUC()
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
			this.HouseFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.RoofFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ChimneyFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.DoorFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.WindowFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// HouseFillStyleButton
			// 
			this.HouseFillStyleButton.Location = new System.Drawing.Point(5, 9);
			this.HouseFillStyleButton.Name = "HouseFillStyleButton";
			this.HouseFillStyleButton.Size = new System.Drawing.Size(169, 26);
			this.HouseFillStyleButton.TabIndex = 0;
			this.HouseFillStyleButton.Text = "House Fill Style";
			this.HouseFillStyleButton.Click += new System.EventHandler(this.HouseFillStyleButton_Click);
			// 
			// RoofFillStyleButton
			// 
			this.RoofFillStyleButton.Location = new System.Drawing.Point(5, 40);
			this.RoofFillStyleButton.Name = "RoofFillStyleButton";
			this.RoofFillStyleButton.Size = new System.Drawing.Size(169, 26);
			this.RoofFillStyleButton.TabIndex = 1;
			this.RoofFillStyleButton.Text = "Roof Fill Style...";
			this.RoofFillStyleButton.Click += new System.EventHandler(this.RoofFillStyleButton_Click);
			// 
			// ChimneyFillStyleButton
			// 
			this.ChimneyFillStyleButton.Location = new System.Drawing.Point(5, 71);
			this.ChimneyFillStyleButton.Name = "ChimneyFillStyleButton";
			this.ChimneyFillStyleButton.Size = new System.Drawing.Size(169, 26);
			this.ChimneyFillStyleButton.TabIndex = 2;
			this.ChimneyFillStyleButton.Text = "Chimney Fill Style...";
			this.ChimneyFillStyleButton.Click += new System.EventHandler(this.ChimneyFillStyleButton_Click);
			// 
			// DoorFillStyleButton
			// 
			this.DoorFillStyleButton.Location = new System.Drawing.Point(5, 102);
			this.DoorFillStyleButton.Name = "DoorFillStyleButton";
			this.DoorFillStyleButton.Size = new System.Drawing.Size(169, 26);
			this.DoorFillStyleButton.TabIndex = 3;
			this.DoorFillStyleButton.Text = "Door Fill Style...";
			this.DoorFillStyleButton.Click += new System.EventHandler(this.DoorFillStyleButton_Click);
			// 
			// WindowFillStyleButton
			// 
			this.WindowFillStyleButton.Location = new System.Drawing.Point(5, 133);
			this.WindowFillStyleButton.Name = "WindowFillStyleButton";
			this.WindowFillStyleButton.Size = new System.Drawing.Size(169, 26);
			this.WindowFillStyleButton.TabIndex = 4;
			this.WindowFillStyleButton.Text = "Window Fill Style...";
			this.WindowFillStyleButton.Click += new System.EventHandler(this.WindowFillStyleButton_Click);
			// 
			// NShapeHomeUC
			// 
			this.Controls.Add(this.WindowFillStyleButton);
			this.Controls.Add(this.DoorFillStyleButton);
			this.Controls.Add(this.ChimneyFillStyleButton);
			this.Controls.Add(this.RoofFillStyleButton);
			this.Controls.Add(this.HouseFillStyleButton);
			this.Name = "NShapeHomeUC";
			this.Size = new System.Drawing.Size(180, 197);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Shape Series used to display a house");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Depth = 55.0f;
			m_Chart.Width = 55.0f;
			m_Chart.Height = 55.0f;
			m_Chart.Projection.Type = ProjectionType.Perspective;
			m_Chart.Projection.Rotation = -19.0f;
			m_Chart.Projection.Elevation = 20.0f;

			// configure axes
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorTickMode = MajorTickMode.AutoMaxCount;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);

			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.MajorTickMode = MajorTickMode.AutoMaxCount;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);

			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale;
			linearScale.MajorTickMode = MajorTickMode.AutoMaxCount;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);

			NLegend legend = (NLegend)nChartControl1.Legends[0];
			legend.Data.MarkSize = new NSizeL(20, 20);

			// create the door
			NShapeSeries shape = (NShapeSeries)m_Chart.Series.Add(SeriesType.Shape);
			shape.Name = "door";
			shape.DataLabelStyle.Visible = false;						
			shape.UseXValues = true;
			shape.UseZValues = true;
			shape.Shape = BarShape.Bar;
			shape.AddDataPoint(new NShapeDataPoint(-0.5, -0.25, -1.0, 0.5, 1.5, 0.02));

			NImageFillStyle doorFS = new NImageFillStyle(NResourceHelper.BitmapFromResource(this.GetType(), "Door.jpg", "Nevron.Examples.Chart.WinForm.Resources"));
			shape.FillStyle = doorFS;

			// create the window
			shape = (NShapeSeries)m_Chart.Series.Add(SeriesType.Shape);
			shape.Name = "window";
			shape.DataLabelStyle.Visible = false;						
			shape.UseXValues = true;
			shape.UseZValues = true;
			shape.Shape = BarShape.Bar;
			shape.AddDataPoint(new NShapeDataPoint(0.4, 0.0, -1.0, 0.75, 1.0, 0.02));

			NImageFillStyle windowFS = new NImageFillStyle(NResourceHelper.BitmapFromResource(this.GetType(), "Window.jpg", "Nevron.Examples.Chart.WinForm.Resources"));
			shape.FillStyle = windowFS;

			// create the house
			shape = (NShapeSeries)m_Chart.Series.Add(SeriesType.Shape);			
			shape.Name = "house";
			shape.DataLabelStyle.Visible = false;
			shape.UseXValues = true;
			shape.UseZValues = true;
			shape.Shape = BarShape.Bar;
			shape.AddDataPoint(new NShapeDataPoint(0.0, 0.0, 0.0, 2.0, 2.0, 2.0));
			shape.FillStyle = new NColorFillStyle(Color.White);

			NImageFillStyle houseFS = new NImageFillStyle(NResourceHelper.BitmapFromResource(this.GetType(), "Cobblestone.jpg", "Nevron.Examples.Chart.WinForm.Resources"));

			houseFS.TextureMappingStyle.MapLayout = MapLayout.Tiled;
			houseFS.TextureMappingStyle.HorizontalScale = 0.1f;
			houseFS.TextureMappingStyle.VerticalScale = 0.1f;

			shape.FillStyle = houseFS;

			// create the roof
			shape = (NShapeSeries)m_Chart.Series.Add(SeriesType.Shape);
			shape.Name = "roof";
			shape.DataLabelStyle.Visible = false;						
			shape.UseXValues = true;
			shape.UseZValues = true;
			shape.Shape = BarShape.Pyramid;
			shape.AddDataPoint(new NShapeDataPoint(0.0, 1.5, 0.0, 2.4, 1.0, 2.4));

			NImageFillStyle roofFS = new NImageFillStyle(NResourceHelper.BitmapFromResource(this.GetType(), "Rooftile.jpg", "Nevron.Examples.Chart.WinForm.Resources"));

			roofFS.TextureMappingStyle.MapLayout = MapLayout.Tiled;
			roofFS.TextureMappingStyle.HorizontalScale = 0.2f;
			roofFS.TextureMappingStyle.VerticalScale = 0.2f;

			shape.FillStyle = roofFS;

			// create the chimney
			shape = (NShapeSeries)m_Chart.Series.Add(SeriesType.Shape);
			shape.Name = "chimney";
			shape.DataLabelStyle.Visible = false;						
			shape.UseXValues = true;
			shape.UseZValues = true;
			shape.Shape = BarShape.Cylinder;
			shape.AddDataPoint(new NShapeDataPoint(0.75, 1.5, 0.0, 0.2, 1.0, 0.2));

			NImageFillStyle chimneyFS = new NImageFillStyle(NResourceHelper.BitmapFromResource(this.GetType(), "Bricks.jpg", "Nevron.Examples.Chart.WinForm.Resources"));

			chimneyFS.TextureMappingStyle.MapLayout = MapLayout.Tiled;
			chimneyFS.TextureMappingStyle.HorizontalScale = 0.1f;
			chimneyFS.TextureMappingStyle.VerticalScale = 0.1f;

			shape.FillStyle = chimneyFS;

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);
		}

		private void DoorFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NShapeSeries shape = (NShapeSeries)m_Chart.Series[0];
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(shape.FillStyle, out fillStyleResult))
			{
				shape.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void WindowFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NShapeSeries shape = (NShapeSeries)m_Chart.Series[1];
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(shape.FillStyle, out fillStyleResult))
			{
				shape.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void HouseFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NShapeSeries shape = (NShapeSeries)m_Chart.Series[2];
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(shape.FillStyle, out fillStyleResult))
			{
				shape.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void RoofFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NShapeSeries shape = (NShapeSeries)m_Chart.Series[3];
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(shape.FillStyle, out fillStyleResult))
			{
				shape.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void ChimneyFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NShapeSeries shape = (NShapeSeries)m_Chart.Series[4];
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(shape.FillStyle, out fillStyleResult))
			{
				shape.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
	}
}
