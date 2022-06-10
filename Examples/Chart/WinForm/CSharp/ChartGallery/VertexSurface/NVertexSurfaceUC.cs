using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Nevron.Examples.Chart.WinForm
{
    [ToolboxItem(false)]
	public class NVertexSurfaceUC : NExampleBaseUC
    {
        private UI.WinForm.Controls.NComboBox VertexPrimitiveCombo;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.Container components = null;
		NVertexSurfaceSeries m_Surface;

		public NVertexSurfaceUC()
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
            this.VertexPrimitiveCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // VertexPrimitiveCombo
            // 
            this.VertexPrimitiveCombo.ListProperties.CheckBoxDataMember = "";
            this.VertexPrimitiveCombo.ListProperties.DataSource = null;
            this.VertexPrimitiveCombo.ListProperties.DisplayMember = "";
            this.VertexPrimitiveCombo.Location = new System.Drawing.Point(8, 27);
            this.VertexPrimitiveCombo.Name = "VertexPrimitiveCombo";
            this.VertexPrimitiveCombo.Size = new System.Drawing.Size(159, 21);
            this.VertexPrimitiveCombo.TabIndex = 11;
            this.VertexPrimitiveCombo.SelectedIndexChanged += new System.EventHandler(this.VertexPrimitiveCombo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Vertex Primitive:";
            // 
            // NVertexSurfaceUC
            // 
            this.Controls.Add(this.VertexPrimitiveCombo);
            this.Controls.Add(this.label4);
            this.Name = "NVertexSurfaceUC";
            this.Size = new System.Drawing.Size(180, 956);
            this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Settings.RenderSurface = RenderSurface.Window;

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 50.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);

			// setup axes
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleY.MaxTickCount = 5;

			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;

			linearScale = new NLinearScaleConfigurator();
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale;

			// setup surface series
			m_Surface = new NVertexSurfaceSeries();
			chart.Series.Add(m_Surface);

			m_Surface.Name = "Surface";
			m_Surface.SyncPaletteWithAxisScale = false;
			m_Surface.PaletteSteps = 8;
			m_Surface.ValueFormatter.FormatSpecifier = "0.00";
			m_Surface.FillMode = SurfaceFillMode.ZoneTexture;
			m_Surface.ShadingMode = ShadingMode.Smooth;
			m_Surface.SmoothPalette = true;

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			VertexPrimitiveCombo.FillFromEnum(typeof(VertexPrimitive));
			VertexPrimitiveCombo.SelectedIndex = (int)VertexPrimitive.Points;
		}

		private void VertexPrimitiveCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_Surface.Data.Clear();

			VertexPrimitive vertexPrimitive = (VertexPrimitive)VertexPrimitiveCombo.SelectedIndex;

			m_Surface.VertexPrimitive = vertexPrimitive;
			m_Surface.UseIndices = false;

			Random rand = new Random();
			string descriptionText = string.Empty;

			switch (vertexPrimitive)
			{
				case VertexPrimitive.Points:
					{
						descriptionText = "Each vertex represents a 3d point";

						m_Surface.FrameMode = SurfaceFrameMode.Dots;

						for (int i = 0; i < 10000; i++)
						{
							m_Surface.Data.AddValue(rand.Next(100),
													rand.Next(100),
													rand.Next(100));
						}
					}
					break;
                case VertexPrimitive.Lines:
                    {
						descriptionText = "Each consecutive pair of vertices represents a line segment";

						m_Surface.FrameMode = SurfaceFrameMode.Dots;

						for (int i = 0; i < 200; i++)
						{
							m_Surface.Data.AddValue(rand.Next(100),
													rand.Next(100),
													rand.Next(100));

							m_Surface.Data.AddValue(rand.Next(100),
													rand.Next(100),
													rand.Next(100));
						}
					}
					break;

				case VertexPrimitive.LineLoop:
				case VertexPrimitive.LineStrip:
					{
						descriptionText = "Adjacent vertices are connected with a line segment";

						for (int i = 0; i < 5; i++)
						{
							m_Surface.Data.AddValue(rand.Next(100),
													rand.Next(100),
													rand.Next(100));
						}
					}
					break;

				case VertexPrimitive.Triangles:
					{
						descriptionText = "Each three consequtive vertices are considered a triangle";

						m_Surface.FrameMode = SurfaceFrameMode.Mesh;

						NVector3DD top = new NVector3DD(0.5, 1, 0.5);
						NVector3DD baseA = new NVector3DD(0, 0, 0);
						NVector3DD baseB = new NVector3DD(1, 0, 0);
						NVector3DD baseC = new NVector3DD(1, 0, 1);
						NVector3DD baseD = new NVector3DD(0, 0, 1);

						m_Surface.Data.AddValue(top);
						m_Surface.Data.AddValue(baseA); 
						m_Surface.Data.AddValue(baseB);

						m_Surface.Data.AddValue(top);
						m_Surface.Data.AddValue(baseB);
						m_Surface.Data.AddValue(baseC);

						m_Surface.Data.AddValue(top);
						m_Surface.Data.AddValue(baseC);
						m_Surface.Data.AddValue(baseD);

						m_Surface.Data.AddValue(top);
						m_Surface.Data.AddValue(baseD);
						m_Surface.Data.AddValue(baseA);
					}
					break;
				case VertexPrimitive.TriangleStrip:
					{
						descriptionText = "A series of connected triangles that share common vertices";

						m_Surface.FrameMode = SurfaceFrameMode.Mesh;

						NVector3DD A = new NVector3DD(0, 0, 0);
						NVector3DD B = new NVector3DD(1, 0, 0);
						NVector3DD C = new NVector3DD(0, 1, 1);
						NVector3DD D = new NVector3DD(1, 1, 1);

						m_Surface.Data.AddValue(A);
						m_Surface.Data.AddValue(B);
						m_Surface.Data.AddValue(C);
						m_Surface.Data.AddValue(D);
					}
					break;
				case VertexPrimitive.TriangleFan:
					{
						descriptionText = "A series of connected triangles that share a common vertex";

						m_Surface.FrameMode = SurfaceFrameMode.Mesh;

						m_Surface.Data.AddValue(0, 100, 0);

						int steps = 10;

						for (int i = 0; i < 3000; i++)
						{
							double angle = i * 2 * Math.PI / steps;

							m_Surface.Data.AddValue(Math.Cos(angle) * 100,
														0,
														Math.Sin(angle) * 100);
						}
					}
                    break;
				case VertexPrimitive.Quads:
					{
						descriptionText = "Each for consecutive vertices form a quad";

						m_Surface.FrameMode = SurfaceFrameMode.Mesh;

						NVector3DD A = new NVector3DD(0, 0, 0);
						NVector3DD B = new NVector3DD(1, 0, 0);
						NVector3DD C = new NVector3DD(0, 1, 1);
						NVector3DD D = new NVector3DD(1, 1, 1);
						

						m_Surface.Data.AddValue(A);
						m_Surface.Data.AddValue(B);
						m_Surface.Data.AddValue(D);
						m_Surface.Data.AddValue(C);
					}
					break;
				case VertexPrimitive.QuadStrip:
					{
						descriptionText = "A series of connected quads that share common vertices";

						m_Surface.FrameMode = SurfaceFrameMode.Mesh;

						NVector3DD A = new NVector3DD(0, 0, 0);
						NVector3DD B = new NVector3DD(1, 0, 0);
						NVector3DD C = new NVector3DD(0, 1, 1);
						NVector3DD D = new NVector3DD(1, 1, 1);
						NVector3DD E = new NVector3DD(0, 2, 2);
						NVector3DD F = new NVector3DD(1, 2, 2);


						m_Surface.Data.AddValue(A);
						m_Surface.Data.AddValue(B);
						m_Surface.Data.AddValue(C);
						m_Surface.Data.AddValue(D);
						m_Surface.Data.AddValue(E);
						m_Surface.Data.AddValue(F);
					}

					break;
			}

			nChartControl1.Labels[0].Text = "Vertex Surface<br/><font size='10pt'>" + descriptionText + "</font>";

			nChartControl1.Refresh();
        }
	}
}