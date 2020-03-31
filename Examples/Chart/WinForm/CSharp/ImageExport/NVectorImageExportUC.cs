using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NVectorImageExportUC : NExampleBaseUC
	{
		private const int categoriesCount = 6;
		private NChart m_Chart;
		private NBarSeries m_Bar1;
		private NBarSeries m_Bar2;
		private NBarSeries m_Bar3;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NComboBox BarShapeCombo;
		private Nevron.UI.WinForm.Controls.NButton PositiveNegativeData;
		private Nevron.UI.WinForm.Controls.NButton PositiveData;
		private Nevron.UI.WinForm.Controls.NButton ExportPDFButton;
		private Nevron.UI.WinForm.Controls.NButton ExportFlashButton;
		private Nevron.UI.WinForm.Controls.NButton ExportSilverlightButton;
		private Nevron.UI.WinForm.Controls.NButton ExportEMFButton;
		private UI.WinForm.Controls.NButton ExportSVGButton;
		private System.ComponentModel.Container components = null;

		public NVectorImageExportUC()
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
			this.PositiveNegativeData = new Nevron.UI.WinForm.Controls.NButton();
			this.PositiveData = new Nevron.UI.WinForm.Controls.NButton();
			this.label5 = new System.Windows.Forms.Label();
			this.BarShapeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.ExportPDFButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ExportFlashButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ExportSilverlightButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ExportEMFButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ExportSVGButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// PositiveNegativeData
			// 
			this.PositiveNegativeData.Location = new System.Drawing.Point(5, 99);
			this.PositiveNegativeData.Name = "PositiveNegativeData";
			this.PositiveNegativeData.Size = new System.Drawing.Size(169, 32);
			this.PositiveNegativeData.TabIndex = 3;
			this.PositiveNegativeData.Text = "Positive and Negative Data";
			this.PositiveNegativeData.Click += new System.EventHandler(this.PositiveNegativeDataButton_Click);
			// 
			// PositiveData
			// 
			this.PositiveData.Location = new System.Drawing.Point(5, 61);
			this.PositiveData.Name = "PositiveData";
			this.PositiveData.Size = new System.Drawing.Size(169, 32);
			this.PositiveData.TabIndex = 2;
			this.PositiveData.Text = "Positive Data";
			this.PositiveData.Click += new System.EventHandler(this.PositiveDataButton_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(5, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(169, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "Bar Shape:";
			// 
			// BarShapeCombo
			// 
			this.BarShapeCombo.ListProperties.CheckBoxDataMember = "";
			this.BarShapeCombo.ListProperties.DataSource = null;
			this.BarShapeCombo.ListProperties.DisplayMember = "";
			this.BarShapeCombo.Location = new System.Drawing.Point(5, 24);
			this.BarShapeCombo.Name = "BarShapeCombo";
			this.BarShapeCombo.Size = new System.Drawing.Size(169, 21);
			this.BarShapeCombo.TabIndex = 1;
			this.BarShapeCombo.SelectedIndexChanged += new System.EventHandler(this.BarShapeCombo_SelectedIndexChanged);
			// 
			// ExportPDFButton
			// 
			this.ExportPDFButton.Location = new System.Drawing.Point(5, 184);
			this.ExportPDFButton.Name = "ExportPDFButton";
			this.ExportPDFButton.Size = new System.Drawing.Size(169, 32);
			this.ExportPDFButton.TabIndex = 4;
			this.ExportPDFButton.Text = "Export to PDF";
			this.ExportPDFButton.Click += new System.EventHandler(this.ExportPDFButton_Click);
			// 
			// ExportFlashButton
			// 
			this.ExportFlashButton.Location = new System.Drawing.Point(5, 276);
			this.ExportFlashButton.Name = "ExportFlashButton";
			this.ExportFlashButton.Size = new System.Drawing.Size(169, 32);
			this.ExportFlashButton.TabIndex = 6;
			this.ExportFlashButton.Text = "Export to Flash";
			this.ExportFlashButton.Click += new System.EventHandler(this.ExportFlashButton_Click);
			// 
			// ExportSilverlightButton
			// 
			this.ExportSilverlightButton.Location = new System.Drawing.Point(5, 322);
			this.ExportSilverlightButton.Name = "ExportSilverlightButton";
			this.ExportSilverlightButton.Size = new System.Drawing.Size(169, 32);
			this.ExportSilverlightButton.TabIndex = 7;
			this.ExportSilverlightButton.Text = "Export to Silverlight";
			this.ExportSilverlightButton.Click += new System.EventHandler(this.ExportSilverlightButton_Click);
			// 
			// ExportEMFButton
			// 
			this.ExportEMFButton.Location = new System.Drawing.Point(5, 368);
			this.ExportEMFButton.Name = "ExportEMFButton";
			this.ExportEMFButton.Size = new System.Drawing.Size(169, 32);
			this.ExportEMFButton.TabIndex = 8;
			this.ExportEMFButton.Text = "Export to Metafile";
			this.ExportEMFButton.Click += new System.EventHandler(this.ExportEMFButton_Click);
			// 
			// ExportSVGButton
			// 
			this.ExportSVGButton.Location = new System.Drawing.Point(6, 230);
			this.ExportSVGButton.Name = "ExportSVGButton";
			this.ExportSVGButton.Size = new System.Drawing.Size(169, 32);
			this.ExportSVGButton.TabIndex = 5;
			this.ExportSVGButton.Text = "Export to SVG";
			this.ExportSVGButton.Click += new System.EventHandler(this.ExportSVGButton_Click);
			// 
			// NVectorImageExportUC
			// 
			this.Controls.Add(this.ExportSVGButton);
			this.Controls.Add(this.ExportEMFButton);
			this.Controls.Add(this.ExportSilverlightButton);
			this.Controls.Add(this.ExportFlashButton);
			this.Controls.Add(this.ExportPDFButton);
			this.Controls.Add(this.BarShapeCombo);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.PositiveNegativeData);
			this.Controls.Add(this.PositiveData);
			this.Name = "NVectorImageExportUC";
			this.Size = new System.Drawing.Size(180, 484);
			this.ResumeLayout(false);

		}
		#endregion

		public NAnimationsStyle CreateAnimationsStyle()
		{
			NAnimationsStyle animationsStyle = new NAnimationsStyle();

			NScaleAnimation scaleAnimation = new NScaleAnimation();
			scaleAnimation.StartScale = new NPointF(1, 0);
			scaleAnimation.EndScale = new NPointF(1, 1);

			scaleAnimation.AnchorX = 0;
			scaleAnimation.AnchorY = 0;

			scaleAnimation.Duration = 3;
			animationsStyle.Animations.Add(scaleAnimation);

			return animationsStyle;
		}

		private void ApplyIndividualAnimation(NBarSeries series, int start, int duration)
		{
			for (int i = 0; i < series.Values.Count; i++)
			{
				NAnimationsStyle animationsStyle = new NAnimationsStyle();

				NScaleAnimation scaleAnimation = new NScaleAnimation();
				scaleAnimation.StartScale = new NPointF(1, 0);
				scaleAnimation.EndScale = new NPointF(1, 1);

				scaleAnimation.AnchorX = 0;
				scaleAnimation.AnchorY = 1;

				scaleAnimation.StartTime = start;
				scaleAnimation.Duration = 3;
				animationsStyle.Animations.Add(scaleAnimation);

				start += duration;

				series.AnimationsStyles[i] = animationsStyle;
			}
		}

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Vector Image Export");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = false;
			m_Chart.Axis(StandardAxis.Depth).Visible = false;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight);

			// add interlace stripe
			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			// add the first bar
			m_Bar1 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar1.Name = "Bar1";
			m_Bar1.MultiBarMode = MultiBarMode.Series;
			m_Bar1.DataLabelStyle.Visible = false;

			// add the second bar
			m_Bar2 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar2.Name = "Bar2";
			m_Bar2.MultiBarMode = MultiBarMode.Stacked;
			m_Bar2.DataLabelStyle.Visible = false;

			// add the third bar
			m_Bar3 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar3.Name = "Bar3";
			m_Bar3.MultiBarMode = MultiBarMode.Stacked;
			m_Bar3.DataLabelStyle.Visible = false;

			PositiveDataButton_Click(null, null);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// init form controls
			BarShapeCombo.FillFromEnum(typeof(BarShape));
			BarShapeCombo.SelectedIndex = 0;
		}

		private void PositiveDataButton_Click(object sender, System.EventArgs e)
		{
			m_Bar1.Values.FillRandomRange(Random, categoriesCount, 10, 100);
			m_Bar2.Values.FillRandomRange(Random, categoriesCount, 10, 100);
			m_Bar3.Values.FillRandomRange(Random, categoriesCount, 10, 100);

			nChartControl1.Refresh();
		}
		private void PositiveNegativeDataButton_Click(object sender, System.EventArgs e)
		{
			m_Bar1.Values.FillRandomRange(Random, categoriesCount, -100, 100);
			m_Bar2.Values.FillRandomRange(Random, categoriesCount, -100, 100);
			m_Bar3.Values.FillRandomRange(Random, categoriesCount, -100, 100);

			nChartControl1.Refresh();
		}
		private void BarShapeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Bar1.BarShape = (BarShape)BarShapeCombo.SelectedIndex;
			m_Bar2.BarShape = (BarShape)BarShapeCombo.SelectedIndex;
			m_Bar3.BarShape = (BarShape)BarShapeCombo.SelectedIndex;

			nChartControl1.Refresh();
		}

		private void ExportPDFButton_Click(object sender, EventArgs e)
		{
			try
			{
				string path = Application.StartupPath + "\\ChartExport.pdf";

				NPdfImageFormat fmt = new NPdfImageFormat();
				fmt.CompressContentStream = true;
				nChartControl1.ImageExporter.SaveToFile(path, fmt);

				Process.Start(path);
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message);
			}
		}
		private void ExportFlashButton_Click(object sender, EventArgs e)
		{
			try
			{
				string path = Application.StartupPath + "\\ChartExport.swf";

				NSwfImageFormat fmt = new NSwfImageFormat();
				nChartControl1.ImageExporter.SaveToFile(path, fmt);

				Process.Start(path);
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message);
			}
		}
		private void ExportSilverlightButton_Click(object sender, EventArgs e)
		{
			try
			{
				string path = Application.StartupPath + "\\ChartExport.xaml";

				NXamlImageFormat fmt = new NXamlImageFormat();
				nChartControl1.ImageExporter.SaveToFile(path, fmt);

				Process.Start(path);
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message);
			}
		}
		private void ExportEMFButton_Click(object sender, EventArgs e)
		{
			try
			{
				string path = Application.StartupPath + "\\ChartExport.emf";

				NEmfImageFormat fmt = new NEmfImageFormat();
				nChartControl1.ImageExporter.SaveToFile(path, fmt);

				Process.Start(path);
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message);
			}
		}

		private void ExportSVGButton_Click(object sender, EventArgs e)
		{
			string path = Application.StartupPath + "\\ChartExport.svg";

			NSvgImageFormat fmt = new NSvgImageFormat();
			nChartControl1.ImageExporter.SaveToFile(path, fmt);

			Process.Start(path);
		}
	}
}
