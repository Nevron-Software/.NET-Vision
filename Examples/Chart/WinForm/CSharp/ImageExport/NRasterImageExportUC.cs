using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NRasterImageExportUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox BarShapeCombo;
		private Nevron.UI.WinForm.Controls.NButton BarFEButton;
		private Nevron.UI.WinForm.Controls.NButton BarBorderButton;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowDataLabelsCheck;
		private Nevron.UI.WinForm.Controls.NButton ExportBMPButton;
		private Nevron.UI.WinForm.Controls.NButton ExportPNGButton;
		private Nevron.UI.WinForm.Controls.NButton ExportJPEGButton;
		private Nevron.UI.WinForm.Controls.NButton ExportGIFButton;
		private Nevron.UI.WinForm.Controls.NButton ExportTIFFButton;
		private System.ComponentModel.Container components = null;

		public NRasterImageExportUC()
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
			this.BarShapeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.BarFEButton = new Nevron.UI.WinForm.Controls.NButton();
			this.BarBorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ShowDataLabelsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ExportBMPButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ExportPNGButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ExportJPEGButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ExportGIFButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ExportTIFFButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(171, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Bar Shape:";
			// 
			// BarShapeCombo
			// 
			this.BarShapeCombo.ListProperties.CheckBoxDataMember = "";
			this.BarShapeCombo.ListProperties.DataSource = null;
			this.BarShapeCombo.ListProperties.DisplayMember = "";
			this.BarShapeCombo.Location = new System.Drawing.Point(5, 27);
			this.BarShapeCombo.Name = "BarShapeCombo";
			this.BarShapeCombo.Size = new System.Drawing.Size(171, 21);
			this.BarShapeCombo.TabIndex = 2;
			this.BarShapeCombo.SelectedIndexChanged += new System.EventHandler(this.BarStyleCombo_SelectedIndexChanged);
			// 
			// BarFEButton
			// 
			this.BarFEButton.Location = new System.Drawing.Point(5, 58);
			this.BarFEButton.Name = "BarFEButton";
			this.BarFEButton.Size = new System.Drawing.Size(171, 24);
			this.BarFEButton.TabIndex = 4;
			this.BarFEButton.Text = "Bar Fill Style...";
			this.BarFEButton.Click += new System.EventHandler(this.BarFEButton_Click);
			// 
			// BarBorderButton
			// 
			this.BarBorderButton.Location = new System.Drawing.Point(5, 89);
			this.BarBorderButton.Name = "BarBorderButton";
			this.BarBorderButton.Size = new System.Drawing.Size(171, 24);
			this.BarBorderButton.TabIndex = 18;
			this.BarBorderButton.Text = "Bar Border...";
			this.BarBorderButton.Click += new System.EventHandler(this.BarBorderButton_Click);
			// 
			// ShowDataLabelsCheck
			// 
			this.ShowDataLabelsCheck.ButtonProperties.BorderOffset = 2;
			this.ShowDataLabelsCheck.Location = new System.Drawing.Point(5, 131);
			this.ShowDataLabelsCheck.Name = "ShowDataLabelsCheck";
			this.ShowDataLabelsCheck.Size = new System.Drawing.Size(171, 21);
			this.ShowDataLabelsCheck.TabIndex = 27;
			this.ShowDataLabelsCheck.Text = "Show Data Labels";
			this.ShowDataLabelsCheck.CheckedChanged += new System.EventHandler(this.ShowDataLabelsCheck_CheckedChanged);
			// 
			// ExportBMPButton
			// 
			this.ExportBMPButton.Location = new System.Drawing.Point(5, 176);
			this.ExportBMPButton.Name = "ExportBMPButton";
			this.ExportBMPButton.Size = new System.Drawing.Size(171, 24);
			this.ExportBMPButton.TabIndex = 28;
			this.ExportBMPButton.Text = "Export BMP";
			this.ExportBMPButton.Click += new System.EventHandler(this.ExportBMPButton_Click);
			// 
			// ExportPNGButton
			// 
			this.ExportPNGButton.Location = new System.Drawing.Point(5, 208);
			this.ExportPNGButton.Name = "ExportPNGButton";
			this.ExportPNGButton.Size = new System.Drawing.Size(171, 24);
			this.ExportPNGButton.TabIndex = 29;
			this.ExportPNGButton.Text = "Export PNG";
			this.ExportPNGButton.Click += new System.EventHandler(this.ExportPNGButton_Click);
			// 
			// ExportJPEGButton
			// 
			this.ExportJPEGButton.Location = new System.Drawing.Point(5, 240);
			this.ExportJPEGButton.Name = "ExportJPEGButton";
			this.ExportJPEGButton.Size = new System.Drawing.Size(171, 24);
			this.ExportJPEGButton.TabIndex = 30;
			this.ExportJPEGButton.Text = "Export JPEG";
			this.ExportJPEGButton.Click += new System.EventHandler(this.ExportJPEGButton_Click);
			// 
			// ExportGIFButton
			// 
			this.ExportGIFButton.Location = new System.Drawing.Point(5, 272);
			this.ExportGIFButton.Name = "ExportGIFButton";
			this.ExportGIFButton.Size = new System.Drawing.Size(171, 24);
			this.ExportGIFButton.TabIndex = 31;
			this.ExportGIFButton.Text = "Export GIF";
			this.ExportGIFButton.Click += new System.EventHandler(this.ExportGIFButton_Click);
			// 
			// ExportTIFFButton
			// 
			this.ExportTIFFButton.Location = new System.Drawing.Point(5, 304);
			this.ExportTIFFButton.Name = "ExportTIFFButton";
			this.ExportTIFFButton.Size = new System.Drawing.Size(171, 24);
			this.ExportTIFFButton.TabIndex = 32;
			this.ExportTIFFButton.Text = "Export TIFF";
			this.ExportTIFFButton.Click += new System.EventHandler(this.ExportTIFFButton_Click);
			// 
			// NRasterImageExportUC
			// 
			this.Controls.Add(this.ExportTIFFButton);
			this.Controls.Add(this.ExportGIFButton);
			this.Controls.Add(this.ExportJPEGButton);
			this.Controls.Add(this.ExportPNGButton);
			this.Controls.Add(this.ExportBMPButton);
			this.Controls.Add(this.ShowDataLabelsCheck);
			this.Controls.Add(this.BarBorderButton);
			this.Controls.Add(this.BarFEButton);
			this.Controls.Add(this.BarShapeCombo);
			this.Controls.Add(this.label1);
			this.Name = "NRasterImageExportUC";
			this.Size = new System.Drawing.Size(180, 347);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("3D Floating Bars");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftTopLeft);

			// setup X axis
			NOrdinalScaleConfigurator scaleX = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			scaleX.AutoLabels = false;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleX.DisplayDataPointsBetweenTicks = false;
			for (int i = 0; i < monthLetters.Length; i++)
			{
				scaleX.CustomLabels.Add(new NCustomValueLabel(i, monthLetters[i]));
			}

            // add interlaced stripe to the Y axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
            stripStyle.Interlaced = true;
            linearScale.StripStyles.Add(stripStyle);

			// create the float bar series
			NFloatBarSeries floatBar = (NFloatBarSeries)chart.Series.Add(SeriesType.FloatBar);
			floatBar.DataLabelStyle.Visible = false;
			floatBar.DataLabelStyle.VertAlign = VertAlign.Center;
			floatBar.DataLabelStyle.Format = "<begin> - <end>";

			// add bars
			floatBar.AddDataPoint(new NFloatBarDataPoint(2, 10));
			floatBar.AddDataPoint(new NFloatBarDataPoint(5, 16));
			floatBar.AddDataPoint(new NFloatBarDataPoint(9, 17));
			floatBar.AddDataPoint(new NFloatBarDataPoint(12, 21));
			floatBar.AddDataPoint(new NFloatBarDataPoint(8, 18));
			floatBar.AddDataPoint(new NFloatBarDataPoint(7, 18));
			floatBar.AddDataPoint(new NFloatBarDataPoint(3, 11));
			floatBar.AddDataPoint(new NFloatBarDataPoint(5, 12));
			floatBar.AddDataPoint(new NFloatBarDataPoint(8, 17));
			floatBar.AddDataPoint(new NFloatBarDataPoint(6, 15));
			floatBar.AddDataPoint(new NFloatBarDataPoint(3, 10));
			floatBar.AddDataPoint(new NFloatBarDataPoint(1, 7));

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// init form controls
			BarShapeCombo.FillFromEnum(typeof(BarShape));
			BarShapeCombo.SelectedIndex = 0;
		}

		private void BarFEButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if (NFillStyleTypeEditor.Edit(series.FillStyle, out fillStyleResult))
			{
				series.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void BarBorderButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if (NStrokeStyleTypeEditor.Edit(series.BorderStyle, out strokeStyleResult))
			{
				series.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void BarStyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NFloatBarSeries floatBar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			floatBar.BarShape = (BarShape)BarShapeCombo.SelectedIndex;
			nChartControl1.Refresh();
		}
		private void ShowDataLabelsCheck_CheckedChanged(object sender, EventArgs e)
		{
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];
			series.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked;
			nChartControl1.Refresh();
		}

		private void ExportBMPButton_Click(object sender, EventArgs e)
		{
			try
			{
				string path = Application.StartupPath + "\\ChartExport.bmp";

				NBitmapImageFormat fmt = new NBitmapImageFormat();
				nChartControl1.ImageExporter.SaveToFile(path, fmt);

				Process.Start(path);
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message);
			}
		}

		private void ExportPNGButton_Click(object sender, EventArgs e)
		{
			try
			{
				string path = Application.StartupPath + "\\ChartExport.png";

				NPngImageFormat fmt = new NPngImageFormat();
				nChartControl1.ImageExporter.SaveToFile(path, fmt);

				Process.Start(path);
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message);
			}
		}

		private void ExportJPEGButton_Click(object sender, EventArgs e)
		{
			try
			{
				string path = Application.StartupPath + "\\ChartExport.jpg";

				NJpegImageFormat fmt = new NJpegImageFormat();
				nChartControl1.ImageExporter.SaveToFile(path, fmt);

				Process.Start(path);
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message);
			}
		}

		private void ExportGIFButton_Click(object sender, EventArgs e)
		{
			try
			{
				string path = Application.StartupPath + "\\ChartExport.gif";

				NGifImageFormat fmt = new NGifImageFormat();
				nChartControl1.ImageExporter.SaveToFile(path, fmt);

				Process.Start(path);
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message);
			}
		}

		private void ExportTIFFButton_Click(object sender, EventArgs e)
		{
			try
			{
				string path = Application.StartupPath + "\\ChartExport.tif";

				NTiffImageFormat fmt = new NTiffImageFormat();
				nChartControl1.ImageExporter.SaveToFile(path, fmt);

				Process.Start(path);
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message);
			}
		}
	}
}
