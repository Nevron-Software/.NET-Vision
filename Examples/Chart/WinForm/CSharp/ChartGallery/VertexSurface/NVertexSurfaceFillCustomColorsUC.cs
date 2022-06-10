using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Nevron.Examples.Chart.WinForm
{
    [ToolboxItem(false)]
    public class NVertexSurfaceFillCustomColorsUC : NExampleBaseUC
    {
        private UI.WinForm.Controls.NComboBox CubeSideSizeComboBox;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.Container components = null;

        public NVertexSurfaceFillCustomColorsUC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.CubeSideSizeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CubeSideSizeComboBox
            // 
            this.CubeSideSizeComboBox.ListProperties.CheckBoxDataMember = "";
            this.CubeSideSizeComboBox.ListProperties.DataSource = null;
            this.CubeSideSizeComboBox.ListProperties.DisplayMember = "";
            this.CubeSideSizeComboBox.Location = new System.Drawing.Point(3, 28);
            this.CubeSideSizeComboBox.Name = "CubeSideSizeComboBox";
            this.CubeSideSizeComboBox.Size = new System.Drawing.Size(159, 21);
            this.CubeSideSizeComboBox.TabIndex = 13;
            this.CubeSideSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.CubeSideSizeComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 21);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cube Size:";
            // 
            // NVertexSurfaceFillCustomColorsUC
            // 
            this.Controls.Add(this.CubeSideSizeComboBox);
            this.Controls.Add(this.label4);
            this.Name = "NVertexSurfaceFillCustomColorsUC";
            this.Size = new System.Drawing.Size(180, 956);
            this.ResumeLayout(false);

        }
        #endregion

        public override void Initialize()
        {
            base.Initialize();

            nChartControl1.Settings.RenderSurface = RenderSurface.Window;
            nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.HighSpeed;
            nChartControl1.Settings.JitterMode = JitterMode.Disabled;
            nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
            nChartControl1.Controller.Tools.Add(new NTrackballTool());

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Vertex Surface Series<br/><font size='10pt'>Used to draw objects with with custom color per vertex</font>");
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
            scaleY.RoundToTickMax = false;
            scaleY.RoundToTickMin = false;

            NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
            scaleX.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
            scaleX.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            scaleX.RoundToTickMax = false;
            scaleX.RoundToTickMin = false;
            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

            NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
            scaleZ.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
            scaleZ.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
            scaleZ.RoundToTickMax = false;
            scaleZ.RoundToTickMin = false;
            chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ;

            for (int i = 1; i < 10; i++)
            {
                CubeSideSizeComboBox.Items.Add(i.ToString() + "x" + i.ToString());
            }

            CubeSideSizeComboBox.SelectedIndex = 4;

            // apply layout
            ConfigureStandardLayout(chart, title, null);

            UpdateData();
        }

        private void UpdateData()
        {
            NChart chart = nChartControl1.Charts[0];
            chart.Series.Clear();
            Random random = new Random();

            // setup surface series
            NVertexSurfaceSeries surface = new NVertexSurfaceSeries();
            chart.Series.Add(surface);

            surface.Name = "Surface";
            surface.SyncPaletteWithAxisScale = false;
            surface.PaletteSteps = 8;
            surface.ValueFormatter.FormatSpecifier = "0.00";
            surface.FillMode = SurfaceFillMode.CustomColors;
            surface.FrameMode = SurfaceFrameMode.None;
            surface.VertexPrimitive = VertexPrimitive.Triangles;
            surface.Data.UseColors = true;
            surface.UseIndices = true;


            int cubeSide = (CubeSideSizeComboBox.SelectedIndex + 1);

            int dataPointCount = 8 * (int)Math.Pow(cubeSide, 3);
            Random rand = new Random();

            surface.Data.SetCapacity(dataPointCount);

            uint currentIndex = 0;

            uint[] cubeIndices = new uint[] {   // bottom
                                                0, 1, 3,
                                                0, 3, 2,

                                                // left
                                                2, 0, 4,
                                                2, 4, 6,

                                                // right
                                                1, 3, 5,
                                                3, 7, 5,

                                                // front
                                                0, 1, 4,
                                                1, 5, 4,

                                                // back
                                                2, 6, 3,
                                                3,6, 7,

                                                // top
                                                4, 5, 6,
                                                5, 7, 6 };

            // generate all vertexes and colors
            for (int x = 0; x < cubeSide; x++)
            {
                double x1 = x + 0.1;
                double x2 = x + 1 - 0.1;

                int r1 = (byte)(x1 * 255.0 / cubeSide);
                int r2 = (byte)(x1 * 255.0 / cubeSide);

                for (int y = 0; y < cubeSide; y++)
                {
                    double y1 = y + 0.1;
                    double y2 = y + 1 - 0.1;

                    int g1 = (byte)(y1 * 255.0 / cubeSide);
                    int g2 = (byte)(y1 * 255.0 / cubeSide);

                    for (int z = 0; z < cubeSide; z++)
                    {
                        double z1 = z + 0.1;
                        double z2 = z + 1 - 0.1;

                        int b1 = (byte)(z1 * 255.0 / cubeSide);
                        int b2 = (byte)(z1 * 255.0 / cubeSide);

                        surface.Data.AddValueColor(new NVector3DD(x1, y1, z1), Color.FromArgb(r1, g1, b1));
                        surface.Data.AddValueColor(new NVector3DD(x2, y1, z1), Color.FromArgb(r2, g1, b1));
                        surface.Data.AddValueColor(new NVector3DD(x1, y2, z1), Color.FromArgb(r1, g2, b1));
                        surface.Data.AddValueColor(new NVector3DD(x2, y2, z1), Color.FromArgb(r2, g2, b1));
                        surface.Data.AddValueColor(new NVector3DD(x1, y1, z2), Color.FromArgb(r1, g1, b2));
                        surface.Data.AddValueColor(new NVector3DD(x2, y1, z2), Color.FromArgb(r2, g1, b2));
                        surface.Data.AddValueColor(new NVector3DD(x1, y2, z2), Color.FromArgb(r1, g2, b2));
                        surface.Data.AddValueColor(new NVector3DD(x2, y2, z2), Color.FromArgb(r2, g2, b2));

                        // add indicess
                        for (int i = 0; i < cubeIndices.Length; i++)
                        {
                            surface.Indices.Add(currentIndex + cubeIndices[i]);
                        }

                        currentIndex += 8;
                    }
                }
            }

            nChartControl1.Refresh();
        }

        private void CubeSideSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateData();
        }
    }
}