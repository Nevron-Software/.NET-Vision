using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Resources;
using Nevron.GraphicsCore;
using Nevron.UI;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NImageFrameStyleUC : NExampleBaseUC
	{
		private NImageFrameStyle m_ImageFrameStyle;
		private Nevron.UI.WinForm.Controls.NComboBox BackgroundFillStyleComboBox;
		private Nevron.Editors.NImageFrameStyleEditorUC ImageFrameStyleEditorUC;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.Container components = null;

		public NImageFrameStyleUC()
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
			this.BackgroundFillStyleComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.ImageFrameStyleEditorUC = new Nevron.Editors.NImageFrameStyleEditorUC();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(302, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Background fill style:";
			// 
			// BackgroundFillStyleComboBox
			// 
			this.BackgroundFillStyleComboBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.BackgroundFillStyleComboBox.Location = new System.Drawing.Point(0, 19);
			this.BackgroundFillStyleComboBox.Name = "BackgroundFillStyleComboBox";
			this.BackgroundFillStyleComboBox.Size = new System.Drawing.Size(302, 21);
			this.BackgroundFillStyleComboBox.TabIndex = 1;
			this.BackgroundFillStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.BackgroundFillStyleComboBox_SelectedIndexChanged_1);
			// 
			// ImageFrameStyleEditorUC
			// 
			this.ImageFrameStyleEditorUC.Dock = System.Windows.Forms.DockStyle.Top;
			this.ImageFrameStyleEditorUC.Location = new System.Drawing.Point(0, 40);
			this.ImageFrameStyleEditorUC.Name = "ImageFrameStyleEditorUC";
			this.ImageFrameStyleEditorUC.Size = new System.Drawing.Size(302, 384);
			this.ImageFrameStyleEditorUC.TabIndex = 2;
			this.ImageFrameStyleEditorUC.StyleChanged += new System.EventHandler(this.ImageFrameStyleEditorUC_ImageFrameStyleChanged);
			// 
			// NImageFrameStyleUC
			// 
			this.Controls.Add(this.ImageFrameStyleEditorUC);
			this.Controls.Add(this.BackgroundFillStyleComboBox);
			this.Controls.Add(this.label1);
			this.Name = "NImageFrameStyleUC";
			this.Size = new System.Drawing.Size(302, 496);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			m_ImageFrameStyle = new NImageFrameStyle();
			nChartControl1.BackgroundStyle.FrameStyle = m_ImageFrameStyle;
			ImageFrameStyleEditorUC.Style = m_ImageFrameStyle;

			nChartControl1.BackgroundStyle.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant2, Color.AliceBlue, Color.LightGray);

			NLabel title = new NLabel("Image Background Frame");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(Color.Navy);
			title.TextStyle.BackplaneStyle.Visible = false;

			NChart chart = nChartControl1.Charts[0];

			NAreaSeries area = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area.DataLabelStyle.Visible = false;
			area.FillStyle = new NColorFillStyle(DarkOrange);
			area.Values.AddRange(monthValues);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			BackgroundFillStyleComboBox.Items.Add("Solid color");
			BackgroundFillStyleComboBox.Items.Add("Gradient");
			BackgroundFillStyleComboBox.Items.Add("Image");
			BackgroundFillStyleComboBox.Items.Add("Pattern");
			BackgroundFillStyleComboBox.Items.Add("AdvancedGradient");
			BackgroundFillStyleComboBox.SelectedIndex = 1;
		}

		private void ImageFrameStyleEditorUC_ImageFrameStyleChanged(object sender, System.EventArgs e)
		{
			nChartControl1.BackgroundStyle.FrameStyle = (NImageFrameStyle)ImageFrameStyleEditorUC.Style;
			nChartControl1.Refresh();
		}

		private void BackgroundFillStyleComboBox_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			switch (BackgroundFillStyleComboBox.SelectedIndex)
			{
				case 0: // Solid color
					nChartControl1.BackgroundStyle.FillStyle = new NColorFillStyle(Color.BlanchedAlmond);
					break;
				case 1: // Gradient
					nChartControl1.BackgroundStyle.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant2, Color.AliceBlue, Color.BlanchedAlmond);
					break;
				case 2: // Image
				{
					NImageFillStyle imageFillStyle = new NImageFillStyle(NResourceHelper.BitmapFromResource(this.GetType(), "Back.png", "Nevron.Examples.Chart.WinForm.Resources"));
					imageFillStyle.TextureMappingStyle.MapLayout = MapLayout.Tiled;

					nChartControl1.BackgroundStyle.FillStyle = imageFillStyle;
				}
					break;
				case 3: // Pattern
					nChartControl1.BackgroundStyle.FillStyle = new NHatchFillStyle(HatchStyle.Divot, Color.BlueViolet, Color.Beige);
					break;
				case 4: // Advanced gradient
					nChartControl1.BackgroundStyle.FillStyle = new NAdvancedGradientFillStyle(AdvancedGradientScheme.Ocean3, 12);
					break;
			}

			nChartControl1.Refresh();
		}
	}
}
