using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using System.Text;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NKagiUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton UpStrokeStyleButton;
		private Nevron.UI.WinForm.Controls.NButton DownStrokeStyleButton;
		private Nevron.UI.WinForm.Controls.NComboBox ReversalAmountCombo;
		private System.Windows.Forms.Label label2;
		private Label label1;
		private Nevron.UI.WinForm.Controls.NTextBox textBox1;
		private System.ComponentModel.Container components = null;

		public NKagiUC()
		{
			InitializeComponent();

			ReversalAmountCombo.Items.AddRange(new string[]{ "0.5", "1", "2", "1%", "2%", "5%" });
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
			this.UpStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.DownStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ReversalAmountCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.SuspendLayout();
			// 
			// UpStrokeStyleButton
			// 
			this.UpStrokeStyleButton.Location = new System.Drawing.Point(8, 10);
			this.UpStrokeStyleButton.Name = "UpStrokeStyleButton";
			this.UpStrokeStyleButton.Size = new System.Drawing.Size(163, 24);
			this.UpStrokeStyleButton.TabIndex = 0;
			this.UpStrokeStyleButton.Text = "Up Stroke Style ...";
			this.UpStrokeStyleButton.Click += new System.EventHandler(this.UpStrokeStyleButton_Click);
			// 
			// DownStrokeStyleButton
			// 
			this.DownStrokeStyleButton.Location = new System.Drawing.Point(8, 41);
			this.DownStrokeStyleButton.Name = "DownStrokeStyleButton";
			this.DownStrokeStyleButton.Size = new System.Drawing.Size(163, 24);
			this.DownStrokeStyleButton.TabIndex = 1;
			this.DownStrokeStyleButton.Text = "Down Stroke Style...";
			this.DownStrokeStyleButton.Click += new System.EventHandler(this.DownStrokeStyleButton_Click);
			// 
			// ReversalAmountCombo
			// 
			this.ReversalAmountCombo.ListProperties.CheckBoxDataMember = "";
			this.ReversalAmountCombo.ListProperties.DataSource = null;
			this.ReversalAmountCombo.ListProperties.DisplayMember = "";
			this.ReversalAmountCombo.Location = new System.Drawing.Point(9, 104);
			this.ReversalAmountCombo.Name = "ReversalAmountCombo";
			this.ReversalAmountCombo.Size = new System.Drawing.Size(160, 21);
			this.ReversalAmountCombo.TabIndex = 3;
			this.ReversalAmountCombo.SelectedIndexChanged += new System.EventHandler(this.ReversalAmountCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 84);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(113, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Reversal Amount:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 147);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Current Data:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(9, 163);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(161, 213);
			this.textBox1.TabIndex = 5;
			// 
			// NKagiUC
			// 
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ReversalAmountCombo);
			this.Controls.Add(this.DownStrokeStyleButton);
			this.Controls.Add(this.UpStrokeStyleButton);
			this.Name = "NKagiUC";
			this.Size = new System.Drawing.Size(180, 454);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// remove all legends
			nChartControl1.Legends.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Kagi Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			NChart chart = nChartControl1.Charts[0];

			// setup X axis
			NPriceScaleConfigurator priceConfigurator = new NPriceScaleConfigurator();
			priceConfigurator.InnerMajorTickStyle.LineStyle.Width = new NLength(0);
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = priceConfigurator;

			// setup Y axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.StripStyles.Add(stripStyle);

			// setup Kagi series
			NKagiSeries kagi = (NKagiSeries)chart.Series.Add(SeriesType.Kagi);
			kagi.UpStrokeStyle.Color = Color.MidnightBlue;
			kagi.DownStrokeStyle.Color = Color.MidnightBlue;
			kagi.UseXValues = true;

			GenerateData(kagi);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			ReversalAmountCombo.SelectedIndex = 0;

			nChartControl1.MouseMove += new MouseEventHandler(nChartControl1_MouseMove);
		}

		void nChartControl1_MouseMove(object sender, MouseEventArgs e)
		{
			NHitTestResult result = nChartControl1.HitTest(e.X, e.Y);

			if (result.ChartElement == ChartElement.KagiData)
			{
				NKagiData kagiData = result.KagiData;

				StringBuilder builder = new StringBuilder();

				builder.AppendLine("DataIndex:" + kagiData.DataIndex.ToString());
				builder.AppendLine("TrendDirection:" + kagiData.TrendDirection.ToString());
				builder.AppendLine("PriorHigh:" + kagiData.PriorHigh.ToString());
				builder.AppendLine("PriorLow:" + kagiData.PriorLow.ToString());
				builder.AppendLine("X:" + kagiData.X.ToString());
				builder.AppendLine("Y:" + kagiData.Y.ToString());

				textBox1.Text = builder.ToString();
			}				  
			else
			{
				textBox1.Text = string.Empty;
			}
		}

		private void GenerateData(NKagiSeries series)
		{
			NStockDataGenerator dataGenerator = new NStockDataGenerator(new NRange1DD(50, 350), 0.002, 2);
			dataGenerator.Reset();

			DateTime dt = new DateTime(2022, 1, 1);

			for(int i = 0; i < 100; i++)
			{
				series.Values.Add(dataGenerator.GetNextValue());
				series.XValues.Add(dt);

				dt = dt.AddDays(1);
			}
		}

		private void UpStrokeStyleButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;
			NKagiSeries kagi = (NKagiSeries)nChartControl1.Charts[0].Series[0];


			if (NStrokeStyleTypeEditor.Edit(kagi.UpStrokeStyle, out strokeStyleResult))
			{
				kagi.UpStrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void DownStrokeStyleButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;
			NKagiSeries kagi = (NKagiSeries)nChartControl1.Charts[0].Series[0];


			if (NStrokeStyleTypeEditor.Edit(kagi.DownStrokeStyle, out strokeStyleResult))
			{
				kagi.DownStrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void ReversalAmountCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NKagiSeries kagi = (NKagiSeries)nChartControl1.Charts[0].Series[0];

			switch(ReversalAmountCombo.SelectedIndex)
			{
				case 0:
					kagi.ReversalAmount = 0.5;
					kagi.ReversalAmountInPercents = false;
					break;

				case 1:
					kagi.ReversalAmount = 1;
					kagi.ReversalAmountInPercents = false;
					break;

				case 2:
					kagi.ReversalAmount = 2;
					kagi.ReversalAmountInPercents = false;
					break;

				case 3:
					kagi.ReversalAmount = 1;
					kagi.ReversalAmountInPercents = true;
					break;

				case 4:
					kagi.ReversalAmount = 2;
					kagi.ReversalAmountInPercents = true;
					break;

				case 5:
					kagi.ReversalAmount = 5;
					kagi.ReversalAmountInPercents = true;
					break;
			}

			nChartControl1.Refresh();
		}
	}
}