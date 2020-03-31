using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Printing;
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
	public class NPrintingUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NFloatBarSeries m_FloatBar;
		private NPrintManager m_PrintManager;

		private Nevron.UI.WinForm.Controls.NButton PageSetupButton;
		private Nevron.UI.WinForm.Controls.NButton PrinterSetupButton;
		private Nevron.UI.WinForm.Controls.NButton PrintPreviewButton;
		private Nevron.UI.WinForm.Controls.NButton PrintButton;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NPrintingUC()
		{
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
			this.PageSetupButton = new Nevron.UI.WinForm.Controls.NButton();
			this.PrinterSetupButton = new Nevron.UI.WinForm.Controls.NButton();
			this.PrintPreviewButton = new Nevron.UI.WinForm.Controls.NButton();
			this.PrintButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// PageSetupButton
			// 
			this.PageSetupButton.Location = new System.Drawing.Point(5, 16);
			this.PageSetupButton.Name = "PageSetupButton";
			this.PageSetupButton.Size = new System.Drawing.Size(169, 23);
			this.PageSetupButton.TabIndex = 0;
			this.PageSetupButton.Text = "Page setup...";
			this.PageSetupButton.Click += new System.EventHandler(this.PageSetupButton_Click);
			// 
			// PrinterSetupButton
			// 
			this.PrinterSetupButton.Location = new System.Drawing.Point(5, 48);
			this.PrinterSetupButton.Name = "PrinterSetupButton";
			this.PrinterSetupButton.Size = new System.Drawing.Size(169, 23);
			this.PrinterSetupButton.TabIndex = 1;
			this.PrinterSetupButton.Text = "Printer setup...";
			this.PrinterSetupButton.Click += new System.EventHandler(this.PrinterSetupButton_Click);
			// 
			// PrintPreviewButton
			// 
			this.PrintPreviewButton.Location = new System.Drawing.Point(5, 88);
			this.PrintPreviewButton.Name = "PrintPreviewButton";
			this.PrintPreviewButton.Size = new System.Drawing.Size(169, 23);
			this.PrintPreviewButton.TabIndex = 2;
			this.PrintPreviewButton.Text = "Print Preview...";
			this.PrintPreviewButton.Click += new System.EventHandler(this.PrintPreviewButton_Click);
			// 
			// PrintButton
			// 
			this.PrintButton.Location = new System.Drawing.Point(5, 120);
			this.PrintButton.Name = "PrintButton";
			this.PrintButton.Size = new System.Drawing.Size(169, 23);
			this.PrintButton.TabIndex = 3;
			this.PrintButton.Text = "Print";
			this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
			// 
			// NPrintingUC
			// 
			this.Controls.Add(this.PrintButton);
			this.Controls.Add(this.PrintPreviewButton);
			this.Controls.Add(this.PrinterSetupButton);
			this.Controls.Add(this.PageSetupButton);
			this.Name = "NPrintingUC";
			this.Size = new System.Drawing.Size(180, 456);
			this.ResumeLayout(false);

		}
		#endregion

		private void InitChart()
		{
			m_Chart = nChartControl1.Charts[0];

			nChartControl1.Controller.Selection.Add(m_Chart);
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Printing");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			m_Chart.Width = 90;
			m_Chart.BoundsMode = BoundsMode.Stretch;
			m_Chart.Location = new NPointL(
				new NLength(15, NRelativeUnit.ParentPercentage),
				new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(
				new NLength(70, NRelativeUnit.ParentPercentage),
				new NLength(70, NRelativeUnit.ParentPercentage));

			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale;
			dateTimeScale.LabelValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.Date);
			dateTimeScale.LabelGenerationMode = LabelGenerationMode.Stagger2;

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
		}

		private void PageSetupButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_PrintManager.ShowPageSetupDialog();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void PrinterSetupButton_Click(object sender, System.EventArgs e)
		{
			m_PrintManager.ShowPrintDialog();
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
