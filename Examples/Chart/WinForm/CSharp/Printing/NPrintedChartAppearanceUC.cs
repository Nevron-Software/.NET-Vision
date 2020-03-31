using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.IO;
using Nevron.Serialization;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NPrintedChartAppearanceUC : NExampleBaseUC 
	{
		private NChart m_Chart;
		private NPieSeries m_Pie;

		private Nevron.UI.WinForm.Controls.NButton PrintPreviewButton;
		private Nevron.UI.WinForm.Controls.NButton PrintButton;
		private Nevron.UI.WinForm.Controls.NCheckBox PrintBackgroundFrameCheckBox;
		private Nevron.UI.WinForm.Controls.NGroupBox FillStyleGroupBox;
		private Nevron.UI.WinForm.Controls.NRadioButton ConvertToGrayScaleRadioButton;
		private Nevron.UI.WinForm.Controls.NRadioButton radioButton3;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NPrintedChartAppearanceUC()
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
			this.PrintPreviewButton = new Nevron.UI.WinForm.Controls.NButton();
			this.PrintButton = new Nevron.UI.WinForm.Controls.NButton();
			this.PrintBackgroundFrameCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.FillStyleGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.radioButton3 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.ConvertToGrayScaleRadioButton = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.FillStyleGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// PrintPreviewButton
			// 
			this.PrintPreviewButton.Location = new System.Drawing.Point(8, 136);
			this.PrintPreviewButton.Name = "PrintPreviewButton";
			this.PrintPreviewButton.Size = new System.Drawing.Size(165, 23);
			this.PrintPreviewButton.TabIndex = 2;
			this.PrintPreviewButton.Text = "Print Preview...";
			this.PrintPreviewButton.Click += new System.EventHandler(this.PrintPreviewButton_Click);
			// 
			// PrintButton
			// 
			this.PrintButton.Location = new System.Drawing.Point(8, 168);
			this.PrintButton.Name = "PrintButton";
			this.PrintButton.Size = new System.Drawing.Size(165, 23);
			this.PrintButton.TabIndex = 3;
			this.PrintButton.Text = "Print";
			// 
			// PrintBackgroundFrameCheckBox
			// 
			this.PrintBackgroundFrameCheckBox.ButtonProperties.BorderOffset = 2;
			this.PrintBackgroundFrameCheckBox.Location = new System.Drawing.Point(8, 104);
			this.PrintBackgroundFrameCheckBox.Name = "PrintBackgroundFrameCheckBox";
			this.PrintBackgroundFrameCheckBox.Size = new System.Drawing.Size(144, 24);
			this.PrintBackgroundFrameCheckBox.TabIndex = 1;
			this.PrintBackgroundFrameCheckBox.Text = "Print background frame";
			// 
			// FillStyleGroupBox
			// 
			this.FillStyleGroupBox.Controls.Add(this.radioButton3);
			this.FillStyleGroupBox.Controls.Add(this.ConvertToGrayScaleRadioButton);
			this.FillStyleGroupBox.Location = new System.Drawing.Point(8, 8);
			this.FillStyleGroupBox.Name = "FillStyleGroupBox";
			this.FillStyleGroupBox.Size = new System.Drawing.Size(144, 88);
			this.FillStyleGroupBox.TabIndex = 0;
			this.FillStyleGroupBox.TabStop = false;
			this.FillStyleGroupBox.Text = "Fill styles";
			// 
			// radioButton3
			// 
			this.radioButton3.ButtonProperties.BorderOffset = 2;
			this.radioButton3.Checked = true;
			this.radioButton3.Location = new System.Drawing.Point(8, 56);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(112, 24);
			this.radioButton3.TabIndex = 1;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Grayscale (hatch)";
			// 
			// ConvertToGrayScaleRadioButton
			// 
			this.ConvertToGrayScaleRadioButton.ButtonProperties.BorderOffset = 2;
			this.ConvertToGrayScaleRadioButton.Location = new System.Drawing.Point(8, 24);
			this.ConvertToGrayScaleRadioButton.Name = "ConvertToGrayScaleRadioButton";
			this.ConvertToGrayScaleRadioButton.Size = new System.Drawing.Size(104, 24);
			this.ConvertToGrayScaleRadioButton.TabIndex = 0;
			this.ConvertToGrayScaleRadioButton.Text = "Grayscale";
			// 
			// NPrintedChartAppearanceUC
			// 
			this.Controls.Add(this.FillStyleGroupBox);
			this.Controls.Add(this.PrintBackgroundFrameCheckBox);
			this.Controls.Add(this.PrintButton);
			this.Controls.Add(this.PrintPreviewButton);
			this.Name = "NPrintedChartAppearanceUC";
			this.Size = new System.Drawing.Size(180, 384);
			this.FillStyleGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Printed Chart Appearance");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			NLegend legend = nChartControl1.Legends[0];
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.BottomRight);

			m_Chart = new NPieChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(m_Chart);
			m_Chart.Depth = 18;
			m_Chart.DisplayOnLegend = nChartControl1.Legends[0];

			m_Pie = (NPieSeries)m_Chart.Series.Add(SeriesType.Pie);
			m_Pie.BorderStyle.Color = Color.LemonChiffon;

			m_Pie.AddDataPoint(new NDataPoint(24, "Cars", new NColorFillStyle(Color.FromArgb(169,121,11))));
			m_Pie.AddDataPoint(new NDataPoint(18, "Airplanes", new NColorFillStyle(Color.FromArgb(157,157,92))));
			m_Pie.AddDataPoint(new NDataPoint(32, "Trains", new NColorFillStyle(Color.FromArgb(98,152,92))));
			m_Pie.AddDataPoint(new NDataPoint(23, "Ships", new NColorFillStyle(Color.FromArgb(111,134,181))));
			m_Pie.AddDataPoint(new NDataPoint(19, "Buses", new NColorFillStyle(Color.FromArgb(179,63,92))));

			m_Pie.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Pie.Legend.Format = "<label> <percent>";
		}

		private NChartControl CreateModifiedChartControl()
		{
			// create a duplicate of this chart control
			MemoryStream memoryStream = new MemoryStream();
			nChartControl1.Serializer.SaveControlStateToStream(memoryStream, PersistencyFormat.Binary, null);

			memoryStream.Seek(0, SeekOrigin.Begin);
			NChartControl chartControl = new NChartControl();
			chartControl.Serializer.LoadControlStateFromStream(memoryStream, PersistencyFormat.Binary, null);

			INObjectConverter fillStyleConverter = null;

			// apply a chart attribute converter
			if (ConvertToGrayScaleRadioButton.Checked)
			{
				fillStyleConverter = new NFillStyleToGrayScaleConverter();
			}
			else
			{
				fillStyleConverter = new NFillStyleColorToHatchConverter();
			}

			INObjectConverter[] converters = new INObjectConverter[] { 	 fillStyleConverter,
																		 new NStrokeStyleToGrayScaleConverter(),
																		 new NShadowStyleToGrayScaleConverter(),
																		 new NLightModelToGrayScaleConverter() };


			NNodeTreeAttributeConverter grayScaleConverter = new NNodeTreeAttributeConverter();
			grayScaleConverter.Converters = converters;
			grayScaleConverter.Convert(chartControl.Document);

			if (PrintBackgroundFrameCheckBox.Checked == false)
			{
				NStandardFrameStyle standardFrameStyle = new NStandardFrameStyle();
				standardFrameStyle.InnerBorderWidth = new NLength(0);

				chartControl.BackgroundStyle.FrameStyle = standardFrameStyle;
			}

			chartControl.Refresh();

			return chartControl;
		}

		private void PrintPreviewButton_Click(object sender, System.EventArgs e)
		{
			NChartControl chartControl = CreateModifiedChartControl();

			chartControl.PrintManager.ShowPrintPreview();
		}
	}
}
