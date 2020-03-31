using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.View;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NCustomPrintingUC : NExampleBaseUC
	{
		private PrintDocument m_PrintDocument;
		private Nevron.UI.WinForm.Controls.NButton PrintButton;
		private Nevron.UI.WinForm.Controls.NButton PrintPreviewButton;
		private Nevron.UI.WinForm.Controls.NButton PrinterSetupButton;
		private Nevron.UI.WinForm.Controls.NButton PageSetupButton;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NCustomPrintingUC()
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
			this.PrintButton = new Nevron.UI.WinForm.Controls.NButton();
			this.PrintPreviewButton = new Nevron.UI.WinForm.Controls.NButton();
			this.PrinterSetupButton = new Nevron.UI.WinForm.Controls.NButton();
			this.PageSetupButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// PrintButton
			// 
			this.PrintButton.Location = new System.Drawing.Point(5, 120);
			this.PrintButton.Name = "PrintButton";
			this.PrintButton.Size = new System.Drawing.Size(170, 23);
			this.PrintButton.TabIndex = 7;
			this.PrintButton.Text = "Print";
			this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
			// 
			// PrintPreviewButton
			// 
			this.PrintPreviewButton.Location = new System.Drawing.Point(5, 88);
			this.PrintPreviewButton.Name = "PrintPreviewButton";
			this.PrintPreviewButton.Size = new System.Drawing.Size(170, 23);
			this.PrintPreviewButton.TabIndex = 6;
			this.PrintPreviewButton.Text = "Print Preview...";
			this.PrintPreviewButton.Click += new System.EventHandler(this.PrintPreviewButton_Click);
			// 
			// PrinterSetupButton
			// 
			this.PrinterSetupButton.Location = new System.Drawing.Point(5, 48);
			this.PrinterSetupButton.Name = "PrinterSetupButton";
			this.PrinterSetupButton.Size = new System.Drawing.Size(170, 23);
			this.PrinterSetupButton.TabIndex = 5;
			this.PrinterSetupButton.Text = "Printer setup...";
			this.PrinterSetupButton.Click += new System.EventHandler(this.PrinterSetupButton_Click);
			// 
			// PageSetupButton
			// 
			this.PageSetupButton.Location = new System.Drawing.Point(5, 16);
			this.PageSetupButton.Name = "PageSetupButton";
			this.PageSetupButton.Size = new System.Drawing.Size(170, 23);
			this.PageSetupButton.TabIndex = 4;
			this.PageSetupButton.Text = "Page setup...";
			this.PageSetupButton.Click += new System.EventHandler(this.PageSetupButton_Click);
			// 
			// NCustomPrintingUC
			// 
			this.Controls.Add(this.PrintButton);
			this.Controls.Add(this.PrintPreviewButton);
			this.Controls.Add(this.PrinterSetupButton);
			this.Controls.Add(this.PageSetupButton);
			this.Name = "NCustomPrintingUC";
			this.Size = new System.Drawing.Size(180, 392);
			this.ResumeLayout(false);

		}
		#endregion

		private void InitChart()
		{
			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.Depth).Visible = false;

			nChartControl1.Controller.Selection.Add(chart);
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Custom Printing");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup the bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar series";
			bar.FillStyle = new NColorFillStyle(Color.Green);
			bar.DataLabelStyle.Visible = false;
			bar.Values.FillRandomRange(Random, 8, 7, 15);

			// setup the floatbar series
			NFloatBarSeries floatbar = (NFloatBarSeries)chart.Series.Add(SeriesType.FloatBar);
			floatbar.MultiFloatBarMode = MultiFloatBarMode.Clustered;
			floatbar.Name = "Floatbar series";
			floatbar.FillStyle = new NColorFillStyle(Color.SandyBrown);
			floatbar.DataLabelStyle.Visible = false;

			floatbar.AddDataPoint(new NFloatBarDataPoint(3.1, 5.2));
			floatbar.AddDataPoint(new NFloatBarDataPoint(4.0, 6.1));
			floatbar.AddDataPoint(new NFloatBarDataPoint(2.0, 6.4));
			floatbar.AddDataPoint(new NFloatBarDataPoint(5.3, 7.3));
			floatbar.AddDataPoint(new NFloatBarDataPoint(3.8, 8.4));
			floatbar.AddDataPoint(new NFloatBarDataPoint(4.0, 7.7));
			floatbar.AddDataPoint(new NFloatBarDataPoint(2.9, 4.1));
			floatbar.AddDataPoint(new NFloatBarDataPoint(5.0, 7.2));
		}

		public override void Initialize()
		{
			InitChart();

			m_PrintDocument = new PrintDocument();
			m_PrintDocument.PrintPage += new PrintPageEventHandler(OnPrintPage);
		}

		private void OnPrintPage(object sender, PrintPageEventArgs ev)
		{
			RectangleF marginBounds = new RectangleF(ev.MarginBounds.Left, ev.MarginBounds.Top, ev.MarginBounds.Width, ev.MarginBounds.Height);

			// create header and footer
			string header = "Custom Header";
			string footer = "Custom Footer";

			Font font = new Font("Arial", 15);
			Brush brush = new SolidBrush(Color.Black);

			// measure them
            SizeF headerSize = ev.Graphics.MeasureString(header, font);
			SizeF footerSize = ev.Graphics.MeasureString(footer, font);

			// draw header
			RectangleF headerBounds = new RectangleF(marginBounds.Left, marginBounds.Top, marginBounds.Width, headerSize.Height);
			ev.Graphics.DrawString(header, font, brush, headerBounds);

			// draw chart
			NRectangleF chartBounds = new NRectangleF(marginBounds.Left, headerBounds.Bottom, marginBounds.Width, marginBounds.Height - headerSize.Height - footerSize.Height);
            NChartPrintView printView = new NChartPrintView(nChartControl1.PrintManager, nChartControl1.Document, ev.Graphics);
			printView.Print(chartBounds);
			printView.Dispose();

			// draw footer
			RectangleF footerBounds = new RectangleF(marginBounds.Left, marginBounds.Bottom - footerSize.Height, marginBounds.Width, footerSize.Height);
			ev.Graphics.DrawString(footer, font, brush, footerBounds);

			// dispose objects
			font.Dispose();
			brush.Dispose();
		}

		private void PageSetupButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				// show page setup dialog
				PageSetupDialog pageSetupDialog = new PageSetupDialog();

				pageSetupDialog.PrinterSettings = m_PrintDocument.PrinterSettings;
				pageSetupDialog.PageSettings = m_PrintDocument.DefaultPageSettings;

				if (pageSetupDialog.ShowDialog() == DialogResult.Cancel)
					return;

				// save changes
				m_PrintDocument.PrinterSettings = pageSetupDialog.PrinterSettings;
				m_PrintDocument.DefaultPageSettings = pageSetupDialog.PageSettings;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void PrinterSetupButton_Click(object sender, System.EventArgs e)
		{
			// show page setup dialog
			PrintDialog printDialog = new PrintDialog();
			printDialog.PrinterSettings = m_PrintDocument.PrinterSettings;

			if (printDialog.ShowDialog() == DialogResult.Cancel)
				return;

			// save changes
			m_PrintDocument.PrinterSettings = printDialog.PrinterSettings;
		}

		private void PrintPreviewButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

				printPreviewDialog.Document = m_PrintDocument;

				printPreviewDialog.ShowDialog();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void PrintButton_Click(object sender, System.EventArgs e)
		{
			m_PrintDocument.Print();
		}
	}
}
