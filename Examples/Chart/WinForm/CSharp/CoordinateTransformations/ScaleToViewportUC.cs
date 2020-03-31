using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
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
	public class ScaleToViewportUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NPointSeries m_Point;
		private bool m_bUpdateWatermark;

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NNumericUpDown XPositionNumericUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown YPositionNumericUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ZPositionNumericUpDown;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox WatermarkPositionComboBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown DataPointNumericUpDown;
		private Nevron.UI.WinForm.Controls.NGroupBox ScaleUnitsGroupBox;
		private Nevron.UI.WinForm.Controls.NGroupBox DataPointGroupBox;
		private System.ComponentModel.Container components = null;

		public ScaleToViewportUC()
		{
			InitializeComponent();

			m_bUpdateWatermark = false;
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.ScaleUnitsGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.ZPositionNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.YPositionNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.XPositionNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.WatermarkPositionComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.DataPointGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.DataPointNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.ScaleUnitsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ZPositionNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.YPositionNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.XPositionNumericUpDown)).BeginInit();
			this.DataPointGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataPointNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(14, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "X:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(14, 49);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(33, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Y:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(14, 84);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(33, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "Z:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ScaleUnitsGroupBox
			// 
			this.ScaleUnitsGroupBox.Controls.Add(this.ZPositionNumericUpDown);
			this.ScaleUnitsGroupBox.Controls.Add(this.YPositionNumericUpDown);
			this.ScaleUnitsGroupBox.Controls.Add(this.XPositionNumericUpDown);
			this.ScaleUnitsGroupBox.Controls.Add(this.label4);
			this.ScaleUnitsGroupBox.Controls.Add(this.label3);
			this.ScaleUnitsGroupBox.Controls.Add(this.label2);
			this.ScaleUnitsGroupBox.Location = new System.Drawing.Point(6, 64);
			this.ScaleUnitsGroupBox.Name = "ScaleUnitsGroupBox";
			this.ScaleUnitsGroupBox.Size = new System.Drawing.Size(169, 112);
			this.ScaleUnitsGroupBox.TabIndex = 2;
			this.ScaleUnitsGroupBox.TabStop = false;
			this.ScaleUnitsGroupBox.Text = "Position in scale units";
			// 
			// ZPositionNumericUpDown
			// 
			this.ZPositionNumericUpDown.Location = new System.Drawing.Point(46, 80);
			this.ZPositionNumericUpDown.Name = "ZPositionNumericUpDown";
			this.ZPositionNumericUpDown.Size = new System.Drawing.Size(113, 20);
			this.ZPositionNumericUpDown.TabIndex = 5;
			this.ZPositionNumericUpDown.ValueChanged += new System.EventHandler(this.ZPositionNumericUpDown_ValueChanged);
			// 
			// YPositionNumericUpDown
			// 
			this.YPositionNumericUpDown.Location = new System.Drawing.Point(46, 52);
			this.YPositionNumericUpDown.Name = "YPositionNumericUpDown";
			this.YPositionNumericUpDown.Size = new System.Drawing.Size(113, 20);
			this.YPositionNumericUpDown.TabIndex = 3;
			this.YPositionNumericUpDown.ValueChanged += new System.EventHandler(this.YPositionNumericUpDown_ValueChanged);
			// 
			// XPositionNumericUpDown
			// 
			this.XPositionNumericUpDown.Location = new System.Drawing.Point(46, 24);
			this.XPositionNumericUpDown.Name = "XPositionNumericUpDown";
			this.XPositionNumericUpDown.Size = new System.Drawing.Size(113, 20);
			this.XPositionNumericUpDown.TabIndex = 1;
			this.XPositionNumericUpDown.ValueChanged += new System.EventHandler(this.XPositionNumericUpDown_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(129, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Watermark position:";
			// 
			// WatermarkPositionComboBox
			// 
			this.WatermarkPositionComboBox.ListProperties.CheckBoxDataMember = "";
			this.WatermarkPositionComboBox.ListProperties.DataSource = null;
			this.WatermarkPositionComboBox.ListProperties.DisplayMember = "";
			this.WatermarkPositionComboBox.Location = new System.Drawing.Point(6, 32);
			this.WatermarkPositionComboBox.Name = "WatermarkPositionComboBox";
			this.WatermarkPositionComboBox.Size = new System.Drawing.Size(169, 21);
			this.WatermarkPositionComboBox.TabIndex = 1;
			this.WatermarkPositionComboBox.SelectedIndexChanged += new System.EventHandler(this.WatermarkPositionComboBox_SelectedIndexChanged);
			// 
			// DataPointGroupBox
			// 
			this.DataPointGroupBox.Controls.Add(this.DataPointNumericUpDown);
			this.DataPointGroupBox.Location = new System.Drawing.Point(6, 184);
			this.DataPointGroupBox.Name = "DataPointGroupBox";
			this.DataPointGroupBox.Size = new System.Drawing.Size(169, 56);
			this.DataPointGroupBox.TabIndex = 3;
			this.DataPointGroupBox.TabStop = false;
			this.DataPointGroupBox.Text = "At data point:";
			// 
			// DataPointNumericUpDown
			// 
			this.DataPointNumericUpDown.Location = new System.Drawing.Point(2, 19);
			this.DataPointNumericUpDown.Name = "DataPointNumericUpDown";
			this.DataPointNumericUpDown.Size = new System.Drawing.Size(169, 20);
			this.DataPointNumericUpDown.TabIndex = 0;
			this.DataPointNumericUpDown.ValueChanged += new System.EventHandler(this.DataPointNumericUpDown_ValueChanged);
			// 
			// ScaleToViewportUC
			// 
			this.Controls.Add(this.DataPointGroupBox);
			this.Controls.Add(this.WatermarkPositionComboBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ScaleUnitsGroupBox);
			this.Name = "ScaleToViewportUC";
			this.Size = new System.Drawing.Size(180, 494);
			this.ScaleUnitsGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ZPositionNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.YPositionNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.XPositionNumericUpDown)).EndInit();
			this.DataPointGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DataPointNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Converting from scale to viewport coordinates");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// create the watermark that we're about to position in the AfterPaint event of the chart
			NWatermark watermark = new NWatermark();
			Bitmap bitmap = GetWatermarkBitmap();

			watermark.FillStyle = new NImageFillStyle(bitmap);
			watermark.StandardFrameStyle.InnerBorderWidth = new NLength(0, NGraphicsUnit.Pixel);
			watermark.ContentAlignment = ContentAlignment.MiddleCenter;

			nChartControl1.Panels.Add(watermark);

			// configure a free xyz point chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.BoundsMode = BoundsMode.Fit;

			m_Chart.Location = new NPointL(new NLength(8, NRelativeUnit.ParentPercentage),
				new NLength(8, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(84, NRelativeUnit.ParentPercentage),
				new NLength(84, NRelativeUnit.ParentPercentage));

			m_Chart.Depth = 55.0f;
			m_Chart.Width = 55.0f;
			m_Chart.Height = 55.0f;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			nChartControl1.Controller.Selection.Add(m_Chart);

			m_Point = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);
			m_Point.Name = "Point Series";
			m_Point.DataLabelStyle.Visible = false;
			m_Point.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Point.Legend.Format = "<label>";
			m_Point.PointShape = PointShape.Sphere;
			m_Point.FillStyle = new NColorFillStyle(Color.Red);
			m_Point.UseXValues = true;
			m_Point.UseZValues = true;

			// add xyz values
			m_Point.AddDataPoint(new NDataPoint(10, 15, 34, "Item1"));
			m_Point.AddDataPoint(new NDataPoint(23, 25, -20, "Item2"));
			m_Point.AddDataPoint(new NDataPoint(12, 45, 45, "Item3"));
			m_Point.AddDataPoint(new NDataPoint(24, 35, -12, "Item4"));
			m_Point.AddDataPoint(new NDataPoint(16, 41, 3, "Item5"));
			m_Point.AddDataPoint(new NDataPoint(17, 15, -34, "Item6"));
			m_Point.AddDataPoint(new NDataPoint(13, -25, -20, "Item7"));
			m_Point.AddDataPoint(new NDataPoint(12, 45, 1, "Item8"));
			m_Point.AddDataPoint(new NDataPoint(4, -21, -12, "Item9"));
			m_Point.AddDataPoint(new NDataPoint(16, -24, 47, "Item10"));

            m_Chart.PaintCallback = new CustomPaintCallback(this);

			// init form controls
			DataPointNumericUpDown.Minimum = 0;
			DataPointNumericUpDown.Maximum = m_Point.Values.Count - 1;
			DataPointNumericUpDown.Value = 0;

			WatermarkPositionComboBox.Items.Add("Position in scale Units");
			WatermarkPositionComboBox.Items.Add("Position from Data Point");
			WatermarkPositionComboBox.SelectedIndex = 1;

			m_bUpdateWatermark = true;

			nChartControl1.Refresh();
		}

		private PointF[] GetPolygonPoints(RectangleF rect)
		{
			float fX13 = rect.X + (1.0f / 3.0f) * rect.Width;
			float fX23 = rect.X + (2.0f / 3.0f) * rect.Width;
			float fY13 = rect.Y + (1.0f / 3.0f) * rect.Height;
			float fY23 = rect.Y + (2.0f / 3.0f) * rect.Height;

			PointF[] arr = new PointF[12];
			arr[0] = new PointF(fX13, rect.Y);
			arr[1] = new PointF(fX23, rect.Y);
			arr[2] = new PointF(fX23, fY13);
			arr[3] = new PointF(rect.Right, fY13);
			arr[4] = new PointF(rect.Right, fY23);
			arr[5] = new PointF(fX23, fY23);
			arr[6] = new PointF(fX23, rect.Bottom);
			arr[7] = new PointF(fX13, rect.Bottom);
			arr[8] = new PointF(fX13, fY23);
			arr[9] = new PointF(rect.X, fY23);
			arr[10] = new PointF(rect.X, fY13);
			arr[11] = new PointF(fX13, fY13);

			return arr;
		}

		private Bitmap GetWatermarkBitmap()
		{
			Bitmap bitmap = new Bitmap(41, 41, PixelFormat.Format32bppArgb);
			Graphics graphics = Graphics.FromImage(bitmap);

			Brush solidBrush = new SolidBrush(Color.FromArgb(125, 255, 0, 0));
			graphics.FillPolygon(solidBrush, GetPolygonPoints(new RectangleF(0, 0, 40, 40)));

			solidBrush.Dispose();
			graphics.Dispose();

			return bitmap;
		}

		private void WatermarkPositionComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			bool bEnableScaleUnitsGroupBox = (WatermarkPositionComboBox.SelectedIndex == 0);
			
			ScaleUnitsGroupBox.Enabled = bEnableScaleUnitsGroupBox;
			DataPointGroupBox.Enabled = !bEnableScaleUnitsGroupBox;

			nChartControl1.Refresh();
		}

		private void DataPointNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			nChartControl1.Refresh();
		}

		private void XPositionNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			nChartControl1.Refresh();
		}

		private void YPositionNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			nChartControl1.Refresh();
		}

		private void ZPositionNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			nChartControl1.Refresh();
		}

        class CustomPaintCallback : NPaintCallback
        {
            ScaleToViewportUC m_Parent;

            public CustomPaintCallback(ScaleToViewportUC parentUserControl)
            {
                m_Parent = parentUserControl;
            }

            public override void OnAfterPaint(NPanel panel, NPanelPaintEventArgs eventArgs)
            {
			    if (m_Parent.m_bUpdateWatermark == false)
				    return;

			    // intercepts the on chart after paint event and converts
			    // point or XYZ coordniates to chart viewport coordinates
			    // used to position the custom watermark
                NChartControl chartControl = m_Parent.nChartControl1;
                NWatermark watermark = chartControl.Watermarks[0];
                NChart chart = m_Parent.nChartControl1.Charts[0];

			    NPointF viewPoint = new NPointF();
			    NVector3DF vecModelPoint = new NVector3DF();

				NModel3DToViewTransformation model3DToViewTransformation = new NModel3DToViewTransformation(chartControl.View.Context, chart.Projection);

                switch (m_Parent.WatermarkPositionComboBox.SelectedIndex)
			    {
				    case 0:
					    vecModelPoint.X = chart.Axis(StandardAxis.PrimaryX).TransformScaleToModel(false, (double)m_Parent.XPositionNumericUpDown.Value);
                        vecModelPoint.Y = chart.Axis(StandardAxis.PrimaryY).TransformScaleToModel(false, (double)m_Parent.YPositionNumericUpDown.Value);
                        vecModelPoint.Z = chart.Axis(StandardAxis.Depth).TransformScaleToModel(false, (double)m_Parent.ZPositionNumericUpDown.Value);
					    break;
				    case 1:
					    NVector3DF vecPoint = new NVector3DF();
                        int nIndex = (int)m_Parent.DataPointNumericUpDown.Value;

                        vecPoint.X = (float)(double)(m_Parent.m_Point.XValues[nIndex]);
                        vecPoint.Y = (float)(double)(m_Parent.m_Point.Values[nIndex]);
                        vecPoint.Z = (float)(double)(m_Parent.m_Point.ZValues[nIndex]);

					    vecModelPoint.X = chart.Axis(StandardAxis.PrimaryX).TransformScaleToModel(false, vecPoint.X);
					    vecModelPoint.Y = chart.Axis(StandardAxis.PrimaryY).TransformScaleToModel(false, vecPoint.Y);
					    vecModelPoint.Z = chart.Axis(StandardAxis.Depth).TransformScaleToModel(false, vecPoint.Z);
					    break;
			    }

			    model3DToViewTransformation.Transform(vecModelPoint, ref viewPoint);

			    // convert the view point to parent pixel coordinates
			    watermark.TransformViewPointToParent(ref viewPoint);

			    watermark.Location = new NPointL(
				    new NLength(viewPoint.X, NGraphicsUnit.Pixel), 
				    new NLength(viewPoint.Y, NGraphicsUnit.Pixel));

                m_Parent.nChartControl1.RecalcLayout();
            }
        }
	}
}
