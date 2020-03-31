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
	public class NStandardFrameStyleUC : NExampleBaseUC
	{
		private NStandardFrameStyle m_StandardFrameStyle;
		private System.Windows.Forms.Label label6;
		private Nevron.UI.WinForm.Controls.NComboBox BackgroundFillStyleComboBox;
		private Nevron.Editors.NStandardFrameStyleEditorUC nStandardFrameStyleEditorUC1;
		private System.ComponentModel.Container components = null;

		public NStandardFrameStyleUC()
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
			this.label6 = new System.Windows.Forms.Label();
			this.BackgroundFillStyleComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nStandardFrameStyleEditorUC1 = new Nevron.Editors.NStandardFrameStyleEditorUC();
			this.SuspendLayout();
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Top;
			this.label6.Location = new System.Drawing.Point(0, 21);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(298, 16);
			this.label6.TabIndex = 0;
			this.label6.Text = "Background fill style:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BackgroundFillStyleComboBox
			// 
			this.BackgroundFillStyleComboBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.BackgroundFillStyleComboBox.Location = new System.Drawing.Point(0, 0);
			this.BackgroundFillStyleComboBox.Name = "BackgroundFillStyleComboBox";
			this.BackgroundFillStyleComboBox.Size = new System.Drawing.Size(298, 21);
			this.BackgroundFillStyleComboBox.TabIndex = 1;
			this.BackgroundFillStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.BackgroundFillStyleComboBox_SelectedIndexChanged);
			// 
			// nStandardFrameStyleEditorUC1
			// 
			this.nStandardFrameStyleEditorUC1.Dock = System.Windows.Forms.DockStyle.Top;
			this.nStandardFrameStyleEditorUC1.Location = new System.Drawing.Point(0, 37);
			this.nStandardFrameStyleEditorUC1.Name = "nStandardFrameStyleEditorUC1";
			this.nStandardFrameStyleEditorUC1.Size = new System.Drawing.Size(298, 329);
			this.nStandardFrameStyleEditorUC1.TabIndex = 2;
			this.nStandardFrameStyleEditorUC1.StyleChanged += new System.EventHandler(this.nStandardFrameStyleEditorUC1_StandardFrameStyleChanged);
			// 
			// NStandardFrameStyleUC
			// 
			this.Controls.Add(this.nStandardFrameStyleEditorUC1);
			this.Controls.Add(this.BackgroundFillStyleComboBox);
			this.Controls.Add(this.label6);
			this.Name = "NStandardFrameStyleUC";
			this.Size = new System.Drawing.Size(298, 507);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			m_StandardFrameStyle = new NStandardFrameStyle();
			nChartControl1.BackgroundStyle.FrameStyle = m_StandardFrameStyle;

			NLabel title = new NLabel("Standard Background Frame");
			title.TextStyle.FillStyle = new NColorFillStyle(Color.Navy);
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			nChartControl1.BackgroundStyle.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant2, Color.AliceBlue, Color.LightGray);

			NChart chart  = nChartControl1.Charts[0];

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

			nStandardFrameStyleEditorUC1.Style = (NStandardFrameStyle)nChartControl1.BackgroundStyle.FrameStyle;
			nStandardFrameStyleEditorUC1.StyleChanged += new EventHandler(this.OnStandardFrameStyleChanged);
		}

		private void OnStandardFrameStyleChanged(object sender, System.EventArgs e)
		{
			nChartControl1.Refresh();
		}

		private void BackgroundFillStyleComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
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

		private void nStandardFrameStyleEditorUC1_StandardFrameStyleChanged(object sender, System.EventArgs e)
		{
			nChartControl1.BackgroundStyle.FrameStyle = (NStandardFrameStyle)nStandardFrameStyleEditorUC1.Style;
			nChartControl1.Refresh();
		}
	}
}
