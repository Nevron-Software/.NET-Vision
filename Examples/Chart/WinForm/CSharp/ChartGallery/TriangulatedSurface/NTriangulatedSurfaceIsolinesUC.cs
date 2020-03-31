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
	public class NTriangulatedSurfaceIsolinesUC : NExampleBaseUC
	{
		private Label label1;
		private NumericUpDown RedIsolineValueNumericUpDown;
		private NumericUpDown BlueIsolineValueNumericUpDown;
		private Label label2;
		private System.ComponentModel.Container components = null;

		private NSurfaceIsoline m_RedIsoline;
		private NSurfaceIsoline m_BlueIsoline;

		public NTriangulatedSurfaceIsolinesUC()
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
			this.RedIsolineValueNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.BlueIsolineValueNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.RedIsolineValueNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BlueIsolineValueNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Red Isoline Value:";
			// 
			// RedIsolineValueNumericUpDown
			// 
			this.RedIsolineValueNumericUpDown.Location = new System.Drawing.Point(13, 27);
			this.RedIsolineValueNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.RedIsolineValueNumericUpDown.Name = "RedIsolineValueNumericUpDown";
			this.RedIsolineValueNumericUpDown.Size = new System.Drawing.Size(120, 20);
			this.RedIsolineValueNumericUpDown.TabIndex = 1;
			this.RedIsolineValueNumericUpDown.ValueChanged += new System.EventHandler(this.RedIsolineValueNumericUpDown_ValueChanged);
			// 
			// BlueIsolineValueNumericUpDown
			// 
			this.BlueIsolineValueNumericUpDown.Location = new System.Drawing.Point(13, 73);
			this.BlueIsolineValueNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.BlueIsolineValueNumericUpDown.Name = "BlueIsolineValueNumericUpDown";
			this.BlueIsolineValueNumericUpDown.Size = new System.Drawing.Size(120, 20);
			this.BlueIsolineValueNumericUpDown.TabIndex = 3;
			this.BlueIsolineValueNumericUpDown.ValueChanged += new System.EventHandler(this.BlueIsolineValueNumericUpDown_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Blue Isoline Value:";
			// 
			// NTriangulatedSurfaceIsolinesUC
			// 
			this.Controls.Add(this.BlueIsolineValueNumericUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.RedIsolineValueNumericUpDown);
			this.Controls.Add(this.label1);
			this.Name = "NTriangulatedSurfaceIsolinesUC";
			this.Size = new System.Drawing.Size(180, 496);
			((System.ComponentModel.ISupportInitialize)(this.RedIsolineValueNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BlueIsolineValueNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Triangulated Surface Isolines");
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
			surface.FrameMode = SurfaceFrameMode.None;
			surface.Palette.SmoothPalette = true;
			surface.FillStyle = new NColorFillStyle(Color.YellowGreen);

			FillData();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			m_RedIsoline = new NSurfaceIsoline();
			m_RedIsoline.StrokeStyle = new NStrokeStyle(2.0f, Color.Red);
			surface.Isolines.Add(m_RedIsoline);

			m_BlueIsoline = new NSurfaceIsoline();
			m_BlueIsoline.StrokeStyle = new NStrokeStyle(2.0f, Color.Blue);
			surface.Isolines.Add(m_BlueIsoline);

			RedIsolineValueNumericUpDown.Value = 100;
			BlueIsolineValueNumericUpDown.Value = 50;
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

				// fill Y values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					surface.Values.Add(reader.ReadSingle());
				}

				// fill X values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					surface.XValues.Add(reader.ReadSingle());
				}

				// fill Z values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					surface.ZValues.Add(reader.ReadSingle());
				}
			}
			finally
			{
				if (reader != null)
					reader.Close();

				if (stream != null)
					stream.Close();
			}
		}

		private void RedIsolineValueNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			m_RedIsoline.Value = (double)RedIsolineValueNumericUpDown.Value;
			nChartControl1.Refresh();
		}

		private void BlueIsolineValueNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			m_BlueIsoline.Value = (double)BlueIsolineValueNumericUpDown.Value;
			nChartControl1.Refresh();
		}
	}
}
