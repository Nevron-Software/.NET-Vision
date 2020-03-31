using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NSeriesDataLabelAttributeUC : NExampleBaseUC
	{
		private NDataLabelStyle m_DataLabelStyle;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NComboBox DataLabelModeCombo;
		private Nevron.UI.WinForm.Controls.NComboBox FormatCombo;
		private Nevron.UI.WinForm.Controls.NComboBox VertAlignCombo;
		private Nevron.UI.WinForm.Controls.NButton TextFont;
		private Nevron.UI.WinForm.Controls.NHScrollBar ArrowLengthScroll;
		private Nevron.UI.WinForm.Controls.NButton ArrowLineButton;
		private System.ComponentModel.Container components = null;

		public NSeriesDataLabelAttributeUC()
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
			this.DataLabelModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.ArrowLengthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label3 = new System.Windows.Forms.Label();
			this.ArrowLineButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label4 = new System.Windows.Forms.Label();
			this.TextFont = new Nevron.UI.WinForm.Controls.NButton();
			this.FormatCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.VertAlignCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// DataLabelModeCombo
			// 
			this.DataLabelModeCombo.ListProperties.CheckBoxDataMember = "";
			this.DataLabelModeCombo.ListProperties.DataSource = null;
			this.DataLabelModeCombo.ListProperties.DisplayMember = "";
			this.DataLabelModeCombo.Location = new System.Drawing.Point(4, 10);
			this.DataLabelModeCombo.Name = "DataLabelModeCombo";
			this.DataLabelModeCombo.Size = new System.Drawing.Size(172, 21);
			this.DataLabelModeCombo.TabIndex = 0;
			this.DataLabelModeCombo.SelectedIndexChanged += new System.EventHandler(this.DataLabelModeCombo_SelectedIndexChanged);
			// 
			// ArrowLengthScroll
			// 
			this.ArrowLengthScroll.LargeChange = 1;
			this.ArrowLengthScroll.Location = new System.Drawing.Point(4, 207);
			this.ArrowLengthScroll.Maximum = 31;
			this.ArrowLengthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.ArrowLengthScroll.Name = "ArrowLengthScroll";
			this.ArrowLengthScroll.Size = new System.Drawing.Size(172, 16);
			this.ArrowLengthScroll.TabIndex = 6;
			this.ArrowLengthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ArrowLengthScroll_Scroll);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(4, 190);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(172, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Arrow Length:";
			// 
			// ArrowLineButton
			// 
			this.ArrowLineButton.Location = new System.Drawing.Point(4, 238);
			this.ArrowLineButton.Name = "ArrowLineButton";
			this.ArrowLineButton.Size = new System.Drawing.Size(172, 24);
			this.ArrowLineButton.TabIndex = 7;
			this.ArrowLineButton.Text = "Arrow Properties...";
			this.ArrowLineButton.Click += new System.EventHandler(this.ArrowLineButton_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(4, 136);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(172, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Format:";
			// 
			// TextFont
			// 
			this.TextFont.Location = new System.Drawing.Point(4, 268);
			this.TextFont.Name = "TextFont";
			this.TextFont.Size = new System.Drawing.Size(172, 23);
			this.TextFont.TabIndex = 8;
			this.TextFont.Text = "Text Properties...";
			this.TextFont.Click += new System.EventHandler(this.TextFont_Click);
			// 
			// FormatCombo
			// 
			this.FormatCombo.ListProperties.CheckBoxDataMember = "";
			this.FormatCombo.ListProperties.DataSource = null;
			this.FormatCombo.ListProperties.DisplayMember = "";
			this.FormatCombo.Location = new System.Drawing.Point(4, 155);
			this.FormatCombo.Name = "FormatCombo";
			this.FormatCombo.Size = new System.Drawing.Size(172, 21);
			this.FormatCombo.TabIndex = 4;
			this.FormatCombo.Text = "comboBox1";
			this.FormatCombo.TextChanged += new System.EventHandler(this.FormatCombo_TextChanged);
			this.FormatCombo.SelectedIndexChanged += new System.EventHandler(this.FormatCombo_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(4, 84);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(172, 16);
			this.label5.TabIndex = 1;
			this.label5.Text = "Vertical Align:";
			// 
			// VertAlignCombo
			// 
			this.VertAlignCombo.ListProperties.CheckBoxDataMember = "";
			this.VertAlignCombo.ListProperties.DataSource = null;
			this.VertAlignCombo.ListProperties.DisplayMember = "";
			this.VertAlignCombo.Location = new System.Drawing.Point(4, 103);
			this.VertAlignCombo.Name = "VertAlignCombo";
			this.VertAlignCombo.Size = new System.Drawing.Size(172, 21);
			this.VertAlignCombo.TabIndex = 2;
			this.VertAlignCombo.SelectedIndexChanged += new System.EventHandler(this.VertAlignCombo_SelectedIndexChanged);
			// 
			// NSeriesDataLabelAttributeUC
			// 
			this.Controls.Add(this.VertAlignCombo);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.FormatCombo);
			this.Controls.Add(this.TextFont);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ArrowLineButton);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.ArrowLengthScroll);
			this.Controls.Add(this.DataLabelModeCombo);
			this.Name = "NSeriesDataLabelAttributeUC";
			this.Size = new System.Drawing.Size(180, 334);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Series Data Label Attribute");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage)); 

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlaced stripe to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            ((NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.FillStyle = new NGradientFillStyle(Color.LightGray, Color.SlateBlue);
			bar.ShadowStyle.Type = ShadowType.LinearBlur;
			bar.ShadowStyle.Offset = new NPointL(3, 3);
			bar.ShadowStyle.Color = Color.FromArgb(40, 0, 0, 0);
			bar.ShadowStyle.FadeLength = new NLength(2);

			bar.AddDataPoint(new NDataPoint(10, "Item 0"));
			bar.AddDataPoint(new NDataPoint(20, "Item 1"));
			bar.AddDataPoint(new NDataPoint(30, "Item 2"));
			bar.AddDataPoint(new NDataPoint(25, "Item 3"));
			bar.AddDataPoint(new NDataPoint(29, "Item 4"));
			bar.AddDataPoint(new NDataPoint(27, "Item 5"));

            // apply style sheet
            NFillStyleSheetConfigurator fillStyleSheet = new NFillStyleSheetConfigurator();
            fillStyleSheet.SeriesFillTemplate = new NGradientFillStyleTemplate(GradientStyle.Horizontal, GradientVariant.Variant1);
            fillStyleSheet.MultiColorSeries = true;
            fillStyleSheet.Palette.SetPredefinedPalette(ChartPredefinedPalette.Nature);
            NStrokeStyleSheetConfigurator strokeStyleSheet = new NStrokeStyleSheetConfigurator();
            strokeStyleSheet.MultiColorSeries = true;
            strokeStyleSheet.ApplyToDataLabels = false;
            strokeStyleSheet.Palette.SetPredefinedPalette(ChartPredefinedPalette.Nature);

            NStyleSheet styleSheet = new NStyleSheet();
            fillStyleSheet.ConfigureSheet(styleSheet);
            strokeStyleSheet.ConfigureSheet(styleSheet);
            styleSheet.Apply(bar);

			// add a different data label for data point 3
			NDataLabelStyle label = new NDataLabelStyle();
			label.Format = "Individual";
			label.TextStyle.FontStyle.Style = FontStyle.Bold;
			label.TextStyle.FillStyle = new NColorFillStyle(Color.Crimson);
			label.TextStyle.BackplaneStyle.Inflate = new NSizeL(3, 3);
			label.TextStyle.BackplaneStyle.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant2, Color.White, Color.Lavender);
			bar.DataLabelStyles[3] = label;

			// init form controls
			FormatCombo.Items.Add("<value> <label>");
			FormatCombo.Items.Add("<index> <cumulative>");
			FormatCombo.Items.Add("<percent> <total>");

			VertAlignCombo.Items.Add("Center");
			VertAlignCombo.Items.Add("Top");
			VertAlignCombo.Items.Add("Bottom");

			DataLabelModeCombo.Items.Add("Edit Default Label");
			DataLabelModeCombo.Items.Add("Edit Data Label #3");
			DataLabelModeCombo.SelectedIndex = 0;

			// apply layout
			ConfigureStandardLayout(chart, title, null);
		}

		private void DataLabelModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];

			switch(DataLabelModeCombo.SelectedIndex)
			{
				case 0:
					m_DataLabelStyle = bar.DataLabelStyle;
					break;

				case 1:
					m_DataLabelStyle = (NDataLabelStyle)bar.DataLabelStyles[3];
					break;
			}

			// init controls from data label
			ArrowLengthScroll.Value = (int)(m_DataLabelStyle.ArrowLength.Value);
			FormatCombo.Text = m_DataLabelStyle.Format;
			VertAlignCombo.SelectedIndex = (int)m_DataLabelStyle.VertAlign;
		}

		private void ArrowLengthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			if (nChartControl1 != null)
			{
				m_DataLabelStyle.ArrowLength = new NLength(ArrowLengthScroll.Value, NGraphicsUnit.Point);
				nChartControl1.Refresh();
			}
		}

		private void ArrowLineButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_DataLabelStyle.ArrowStrokeStyle, out strokeStyleResult))
			{
				m_DataLabelStyle.ArrowStrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void TextFont_Click(object sender, System.EventArgs e)
		{
			NTextStyle textStyleResult;

			if (NTextStyleTypeEditor.Edit(m_DataLabelStyle.TextStyle, out textStyleResult))
			{
				m_DataLabelStyle.TextStyle = textStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void FormatCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 != null)
			{
				m_DataLabelStyle.Format = FormatCombo.Text;
				nChartControl1.Refresh();
			}
		}

		private void FormatCombo_TextChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 != null)
			{
				m_DataLabelStyle.Format = FormatCombo.Text;
				nChartControl1.Refresh();
			}
		}

		private void VertAlignCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 != null)
			{
				m_DataLabelStyle.VertAlign = (VertAlign)VertAlignCombo.SelectedIndex;
				nChartControl1.Refresh();
			}
		}
	}
}
