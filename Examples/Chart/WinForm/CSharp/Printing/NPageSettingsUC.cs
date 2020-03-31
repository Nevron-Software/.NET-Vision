using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NPageSettingsUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NFloatBarSeries m_FloatBar;
		private NPrintManager m_PrintManager;
		private bool m_Updating;
		private Nevron.UI.WinForm.Controls.NGroupBox PageOrientationGroupBox;
		private Nevron.UI.WinForm.Controls.NRadioButton PortraitRadioButton;
		private Nevron.UI.WinForm.Controls.NRadioButton LandscapeRadioButton;
		private Nevron.UI.WinForm.Controls.NGroupBox PageMarginsGroupBox;
		private Nevron.Editors.NMarginsEditorUC PageMarginsEditorUC;
		private Nevron.UI.WinForm.Controls.NGroupBox PaperGroupBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NComboBox PagePaperSizeComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox PagePaperSourceComboBox;
		private Nevron.UI.WinForm.Controls.NButton PrintButton;
		private Nevron.UI.WinForm.Controls.NButton PrintPreviewButton;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NPageSettingsUC()
		{
			m_Updating = true;
			// This call is required by the Windows.Forms Form Designer.
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
			this.PageOrientationGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.LandscapeRadioButton = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.PortraitRadioButton = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.PageMarginsGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.PageMarginsEditorUC = new Nevron.Editors.NMarginsEditorUC();
			this.PaperGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.PagePaperSourceComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.PagePaperSizeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.PrintPreviewButton = new Nevron.UI.WinForm.Controls.NButton();
			this.PrintButton = new Nevron.UI.WinForm.Controls.NButton();
			this.PageOrientationGroupBox.SuspendLayout();
			this.PageMarginsGroupBox.SuspendLayout();
			this.PaperGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// PageOrientationGroupBox
			// 
			this.PageOrientationGroupBox.Controls.Add(this.LandscapeRadioButton);
			this.PageOrientationGroupBox.Controls.Add(this.PortraitRadioButton);
			this.PageOrientationGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.PageOrientationGroupBox.ImageIndex = 0;
			this.PageOrientationGroupBox.Location = new System.Drawing.Point(0, 0);
			this.PageOrientationGroupBox.Name = "PageOrientationGroupBox";
			this.PageOrientationGroupBox.Size = new System.Drawing.Size(272, 72);
			this.PageOrientationGroupBox.TabIndex = 0;
			this.PageOrientationGroupBox.TabStop = false;
			this.PageOrientationGroupBox.Text = "Page Orientation";
			// 
			// LandscapeRadioButton
			// 
			this.LandscapeRadioButton.Location = new System.Drawing.Point(8, 40);
			this.LandscapeRadioButton.Name = "LandscapeRadioButton";
			this.LandscapeRadioButton.TabIndex = 1;
			this.LandscapeRadioButton.Text = "Landscape";
			this.LandscapeRadioButton.CheckedChanged += new System.EventHandler(this.LandscapeRadioButton_CheckedChanged);
			// 
			// PortraitRadioButton
			// 
			this.PortraitRadioButton.Location = new System.Drawing.Point(8, 16);
			this.PortraitRadioButton.Name = "PortraitRadioButton";
			this.PortraitRadioButton.TabIndex = 0;
			this.PortraitRadioButton.Text = "Portrait";
			this.PortraitRadioButton.CheckedChanged += new System.EventHandler(this.PortraitRadioButton_CheckedChanged);
			// 
			// PageMarginsGroupBox
			// 
			this.PageMarginsGroupBox.Controls.Add(this.PageMarginsEditorUC);
			this.PageMarginsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.PageMarginsGroupBox.ImageIndex = 0;
			this.PageMarginsGroupBox.Location = new System.Drawing.Point(0, 72);
			this.PageMarginsGroupBox.Name = "PageMarginsGroupBox";
			this.PageMarginsGroupBox.Size = new System.Drawing.Size(272, 128);
			this.PageMarginsGroupBox.TabIndex = 1;
			this.PageMarginsGroupBox.TabStop = false;
			this.PageMarginsGroupBox.Text = "Page Margins";
			// 
			// PageMarginsEditorUC
			// 
			this.PageMarginsEditorUC.BackColor = System.Drawing.SystemColors.Control;
			this.PageMarginsEditorUC.ForeColor = System.Drawing.SystemColors.ControlText;
			this.PageMarginsEditorUC.Location = new System.Drawing.Point(8, 24);
			this.PageMarginsEditorUC.Name = "PageMarginsEditorUC";
			this.PageMarginsEditorUC.Size = new System.Drawing.Size(256, 96);
			this.PageMarginsEditorUC.TabIndex = 0;
			this.PageMarginsEditorUC.MarginsChanged += new System.EventHandler(this.PageMarginsEditorUC_MarginsChanged);
			// 
			// PaperGroupBox
			// 
			this.PaperGroupBox.Controls.Add(this.PagePaperSourceComboBox);
			this.PaperGroupBox.Controls.Add(this.PagePaperSizeComboBox);
			this.PaperGroupBox.Controls.Add(this.label2);
			this.PaperGroupBox.Controls.Add(this.label1);
			this.PaperGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.PaperGroupBox.ImageIndex = 0;
			this.PaperGroupBox.Location = new System.Drawing.Point(0, 200);
			this.PaperGroupBox.Name = "PaperGroupBox";
			this.PaperGroupBox.Size = new System.Drawing.Size(272, 80);
			this.PaperGroupBox.TabIndex = 2;
			this.PaperGroupBox.TabStop = false;
			this.PaperGroupBox.Text = "Page Paper";
			// 
			// PagePaperSourceComboBox
			// 
			this.PagePaperSourceComboBox.Location = new System.Drawing.Point(64, 48);
			this.PagePaperSourceComboBox.Name = "PagePaperSourceComboBox";
			this.PagePaperSourceComboBox.Size = new System.Drawing.Size(192, 21);
			this.PagePaperSourceComboBox.TabIndex = 3;
			this.PagePaperSourceComboBox.Text = "comboBox2";
			this.PagePaperSourceComboBox.SelectedIndexChanged += new System.EventHandler(this.PagePaperSourceComboBox_SelectedIndexChanged);
			// 
			// PagePaperSizeComboBox
			// 
			this.PagePaperSizeComboBox.Location = new System.Drawing.Point(64, 16);
			this.PagePaperSizeComboBox.Name = "PagePaperSizeComboBox";
			this.PagePaperSizeComboBox.Size = new System.Drawing.Size(192, 21);
			this.PagePaperSizeComboBox.TabIndex = 2;
			this.PagePaperSizeComboBox.Text = "comboBox1";
			this.PagePaperSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.PagePaperSizeComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Source:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Size:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PrintPreviewButton
			// 
			this.PrintPreviewButton.Location = new System.Drawing.Point(8, 304);
			this.PrintPreviewButton.Name = "PrintPreviewButton";
			this.PrintPreviewButton.Size = new System.Drawing.Size(256, 23);
			this.PrintPreviewButton.TabIndex = 3;
			this.PrintPreviewButton.Text = "Print Preview...";
			this.PrintPreviewButton.Click += new System.EventHandler(this.PrintPreviewButton_Click);
			// 
			// PrintButton
			// 
			this.PrintButton.Location = new System.Drawing.Point(8, 336);
			this.PrintButton.Name = "PrintButton";
			this.PrintButton.Size = new System.Drawing.Size(256, 23);
			this.PrintButton.TabIndex = 4;
			this.PrintButton.Text = "Print";
			this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
			// 
			// NPageSettingsUC
			// 
			this.Controls.Add(this.PrintButton);
			this.Controls.Add(this.PrintPreviewButton);
			this.Controls.Add(this.PaperGroupBox);
			this.Controls.Add(this.PageMarginsGroupBox);
			this.Controls.Add(this.PageOrientationGroupBox);
			this.Name = "NPageSettingsUC";
			this.Size = new System.Drawing.Size(272, 384);
			this.PageOrientationGroupBox.ResumeLayout(false);
			this.PageMarginsGroupBox.ResumeLayout(false);
			this.PaperGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void InitChart()
		{
			m_Chart = nChartControl1.Charts[0];

			nChartControl1.Controller.Selection.Add(m_Chart);
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Page Settings");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			m_Chart.Width = 90;
			m_Chart.BoundsMode = BoundsMode.Fit;
			m_Chart.Location = new NPointL(
				new NLength(15, NRelativeUnit.ParentPercentage),
				new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(
				new NLength(70, NRelativeUnit.ParentPercentage),
				new NLength(70, NRelativeUnit.ParentPercentage));

			// switch the X axis to date time scale
			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();
			dateTimeScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale;

			// create the float bar series
			m_FloatBar = (NFloatBarSeries)m_Chart.Series.Add(SeriesType.FloatBar);
			m_FloatBar.UseXValues = true;
			m_FloatBar.UseZValues = false;
			m_FloatBar.InflateMargins = true;
			m_FloatBar.DataLabelStyle.Visible = false;

			// bar appearance
			m_FloatBar.BorderStyle.Color = Color.Bisque;
			m_FloatBar.FillStyle = new NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Horizontal, GradientVariant.Variant1, Color.LightGray, Color.DarkBlue);
			m_FloatBar.ShadowStyle.Type = ShadowType.Solid;
			m_FloatBar.ShadowStyle.Color = Color.FromArgb(30, 0, 0, 0);

			m_FloatBar.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			m_FloatBar.EndValues.ValueFormatter = new NNumericValueFormatter("0.00");

			// show the begin end values in the legend
			m_FloatBar.Legend.Format = "<begin> - <end>";
			m_FloatBar.Legend.Mode = SeriesLegendMode.DataPoints;

			nChartControl1.Controller.Tools.Add(new NDataPanTool());
			m_PrintManager = new NPrintManager(nChartControl1.Document);

			GenerateData();
		}

		private void GenerateData()
		{
			const int nCount = 6;

			m_FloatBar.Values.Clear();
			m_FloatBar.EndValues.Clear();
			m_FloatBar.XValues.Clear();

			// generate Y values
			for(int i = 0; i < nCount; i++)
			{
				double dBeginValue = Random.NextDouble() * 5;
				double dEndValue = dBeginValue + 2 + Random.NextDouble();
				m_FloatBar.Values.Add(dBeginValue);
				m_FloatBar.EndValues.Add(dEndValue);
			}

			// generate X values
			DateTime dt = new DateTime(2005, 5, 24, 11, 0, 0);

			for(int i = 0; i < nCount; i++)
			{
				dt = dt.AddHours(12 + Random.NextDouble() * 60);

				m_FloatBar.XValues.Add(dt);
			}
		}

		public override void Initialize()
		{
			InitChart();
			UpdateControlsFromPageSettings();
		}

		private void UpdateControlsFromPageSettings()
		{
			if (PrinterSettings.InstalledPrinters.Count == 0)
			{
				PortraitRadioButton.Enabled = false;
				LandscapeRadioButton.Enabled = false;
				PageMarginsEditorUC.Enabled = false;
				PagePaperSizeComboBox.Enabled = false;

				return;
			}

			m_Updating = true;
			PageSettings pageSettings = m_PrintManager.PageSettings;

			// portrait / landscape
			if (pageSettings.Landscape)
			{
				PortraitRadioButton.Checked = false;
				LandscapeRadioButton.Checked = true;
			}
			else
			{
				PortraitRadioButton.Checked = true;
				LandscapeRadioButton.Checked = false;
			}

			// margins
			NMarginsL margins = new NMarginsL(
				new NLength(pageSettings.Margins.Left / 100.0f, NGraphicsUnit.Inch),
				new NLength(pageSettings.Margins.Top / 100.0f, NGraphicsUnit.Inch),
				new NLength(pageSettings.Margins.Right / 100.0f, NGraphicsUnit.Inch),
				new NLength(pageSettings.Margins.Bottom / 100.0f, NGraphicsUnit.Inch));

			this.PageMarginsEditorUC.Margins = margins;

			// paper sizes
			for (int i = 0; i < pageSettings.PrinterSettings.PaperSizes.Count; i++)
			{
				string paperName = pageSettings.PrinterSettings.PaperSizes[i].PaperName;
				PagePaperSizeComboBox.Items.Add(paperName);

				if (paperName == pageSettings.PaperSize.PaperName)
				{
					PagePaperSizeComboBox.SelectedIndex = i;
				}
			}

			// paper sources
			for (int i = 0; i < pageSettings.PrinterSettings.PaperSources.Count; i++)
			{
				string paperSourceName = pageSettings.PrinterSettings.PaperSources[i].SourceName;
				PagePaperSourceComboBox.Items.Add(paperSourceName);

				if (paperSourceName == pageSettings.PaperSource.SourceName)
				{
					PagePaperSourceComboBox.SelectedIndex = i;
				}
			}

			PagePaperSizeComboBox.SelectedItem = pageSettings.PaperSource;

			m_Updating = false;
		}

		private void UpdatePageSettingsFromControls()
		{
			if (m_Updating)
				return;

			if (PrinterSettings.InstalledPrinters.Count == 0)
				return;

			m_Updating = true;

			PageSettings pageSettings = m_PrintManager.PageSettings;

			// portrait / landscape
			pageSettings.Landscape = LandscapeRadioButton.Checked;

			// margins
			NMarginsL margins = this.PageMarginsEditorUC.Margins;

			NMeasurementUnitConverter converter = new NMeasurementUnitConverter(pageSettings.PrinterResolution.X, pageSettings.PrinterResolution.Y);

			float left = converter.ConvertX(margins.Left.MeasurementUnit, NGraphicsUnit.Inch, margins.Left.Value) * 100;
			float top = converter.ConvertY(margins.Top.MeasurementUnit, NGraphicsUnit.Inch, margins.Top.Value) * 100;
			float right = converter.ConvertX(margins.Right.MeasurementUnit, NGraphicsUnit.Inch, margins.Right.Value) * 100;
			float bottom = converter.ConvertY(margins.Bottom.MeasurementUnit, NGraphicsUnit.Inch, margins.Bottom.Value) * 100;

			pageSettings.Margins = new Margins((int)left, (int)right, (int)top, (int)bottom);

			// paper sizes
			if (PagePaperSizeComboBox.SelectedIndex != -1)
			{
				string paperName = PagePaperSizeComboBox.SelectedItem.ToString();

				for (int i = 0; i < pageSettings.PrinterSettings.PaperSizes.Count; i++)
				{
					if (pageSettings.PrinterSettings.PaperSizes[i].PaperName == paperName)
					{
						pageSettings.PaperSize = pageSettings.PrinterSettings.PaperSizes[i];
						break;
					}
				}
			}

			// paper source
			if (PagePaperSourceComboBox.SelectedIndex != -1)
			{
				string paperSourceName = PagePaperSourceComboBox.SelectedItem.ToString();

				for (int i = 0; i < pageSettings.PrinterSettings.PaperSources.Count; i++)
				{
					if (paperSourceName == pageSettings.PrinterSettings.PaperSources[i].SourceName)
					{
						pageSettings.PaperSource = pageSettings.PrinterSettings.PaperSources[i];
						break;
					}
				}
			}

			nChartControl1.PrintManager.PageSettings = pageSettings;

			m_Updating = false;
		}

		private void PortraitRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdatePageSettingsFromControls();
		}

		private void LandscapeRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdatePageSettingsFromControls();
		}

		private void PageMarginsEditorUC_MarginsChanged(object sender, System.EventArgs e)
		{
			UpdatePageSettingsFromControls();
		}

		private void PagePaperSourceComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdatePageSettingsFromControls();
		}

		private void PagePaperSizeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdatePageSettingsFromControls();
		}

		private void PrintPreviewButton_Click(object sender, System.EventArgs e)
		{
			m_PrintManager.ShowPrintPreview();
		}

		private void PrintButton_Click(object sender, System.EventArgs e)
		{
			m_PrintManager.Print();
		}
	}
}
