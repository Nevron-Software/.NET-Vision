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
using Nevron.UI.WinForm.Controls;
using System.Text;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NRenkoUC : NExampleBaseUC
	{
		private NButton UpBorderStyleButton;
		private NButton DownBorderStyleButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NButton UpFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton DownFillStyleButton;
		private Nevron.UI.WinForm.Controls.NComboBox BoxWidthPercentCombo;
		private Nevron.UI.WinForm.Controls.NComboBox BoxSizeCombo;
		private Nevron.UI.WinForm.Controls.NTextBox textBox1;
		private Label label3;
		private System.ComponentModel.Container components = null;

		public NRenkoUC()
		{
			InitializeComponent();

			BoxSizeCombo.Items.AddRange(new string[]{ "0.5", "1", "2", "2%", "5%", "10%" });
			BoxWidthPercentCombo.Items.AddRange(new string[]{ "50%", "75%", "100%" });
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
			this.UpBorderStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.UpFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.DownFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.DownBorderStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.BoxWidthPercentCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.BoxSizeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.textBox1 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// UpBorderStyleButton
			// 
			this.UpBorderStyleButton.Location = new System.Drawing.Point(5, 10);
			this.UpBorderStyleButton.Name = "UpBorderStyleButton";
			this.UpBorderStyleButton.Size = new System.Drawing.Size(170, 24);
			this.UpBorderStyleButton.TabIndex = 0;
			this.UpBorderStyleButton.Text = "Up Border Style ...";
			this.UpBorderStyleButton.Click += new System.EventHandler(this.UpBorderPropsButton_Click);
			// 
			// UpFillStyleButton
			// 
			this.UpFillStyleButton.Location = new System.Drawing.Point(5, 72);
			this.UpFillStyleButton.Name = "UpFillStyleButton";
			this.UpFillStyleButton.Size = new System.Drawing.Size(170, 24);
			this.UpFillStyleButton.TabIndex = 2;
			this.UpFillStyleButton.Text = "Up Fill Style...";
			this.UpFillStyleButton.Click += new System.EventHandler(this.UpFillStyleStyleButton_Click);
			// 
			// DownFillStyleButton
			// 
			this.DownFillStyleButton.Location = new System.Drawing.Point(5, 103);
			this.DownFillStyleButton.Name = "DownFillStyleButton";
			this.DownFillStyleButton.Size = new System.Drawing.Size(170, 24);
			this.DownFillStyleButton.TabIndex = 3;
			this.DownFillStyleButton.Text = "Down Fill Style...";
			this.DownFillStyleButton.Click += new System.EventHandler(this.DownFillStyleButton_Click);
			// 
			// DownBorderStyleButton
			// 
			this.DownBorderStyleButton.Location = new System.Drawing.Point(5, 41);
			this.DownBorderStyleButton.Name = "DownBorderStyleButton";
			this.DownBorderStyleButton.Size = new System.Drawing.Size(170, 24);
			this.DownBorderStyleButton.TabIndex = 1;
			this.DownBorderStyleButton.Text = "Down Border Style ...";
			this.DownBorderStyleButton.Click += new System.EventHandler(this.DownBorderStyleButton_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 142);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Box Size:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 203);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Box Width Percent:";
			// 
			// BoxWidthPercentCombo
			// 
			this.BoxWidthPercentCombo.ListProperties.CheckBoxDataMember = "";
			this.BoxWidthPercentCombo.ListProperties.DataSource = null;
			this.BoxWidthPercentCombo.ListProperties.DisplayMember = "";
			this.BoxWidthPercentCombo.Location = new System.Drawing.Point(5, 221);
			this.BoxWidthPercentCombo.Name = "BoxWidthPercentCombo";
			this.BoxWidthPercentCombo.Size = new System.Drawing.Size(167, 21);
			this.BoxWidthPercentCombo.TabIndex = 7;
			this.BoxWidthPercentCombo.SelectedIndexChanged += new System.EventHandler(this.BoxWidthPercentCombo_SelectedIndexChanged);
			// 
			// BoxSizeCombo
			// 
			this.BoxSizeCombo.ListProperties.CheckBoxDataMember = "";
			this.BoxSizeCombo.ListProperties.DataSource = null;
			this.BoxSizeCombo.ListProperties.DisplayMember = "";
			this.BoxSizeCombo.Location = new System.Drawing.Point(5, 161);
			this.BoxSizeCombo.Name = "BoxSizeCombo";
			this.BoxSizeCombo.Size = new System.Drawing.Size(167, 21);
			this.BoxSizeCombo.TabIndex = 5;
			this.BoxSizeCombo.SelectedIndexChanged += new System.EventHandler(this.BoxSizeCombo_SelectedIndexChanged);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(5, 271);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(167, 213);
			this.textBox1.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 254);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Current Data:";
			// 
			// NRenkoUC
			// 
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.BoxSizeCombo);
			this.Controls.Add(this.BoxWidthPercentCombo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.DownBorderStyleButton);
			this.Controls.Add(this.DownFillStyleButton);
			this.Controls.Add(this.UpFillStyleButton);
			this.Controls.Add(this.UpBorderStyleButton);
			this.Name = "NRenkoUC";
			this.Size = new System.Drawing.Size(180, 554);
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
			NLabel title = nChartControl1.Labels.AddHeader("Renko Chart");
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

			// setup Renko series
			NRenkoSeries renko = (NRenkoSeries)chart.Series.Add(SeriesType.Renko);
			renko.UseXValues = true;

			GenerateData(renko);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			BoxSizeCombo.SelectedIndex = 1;
			BoxWidthPercentCombo.SelectedIndex = 2;

			nChartControl1.MouseMove += new MouseEventHandler(nChartControl1_MouseMove);
		}

		void nChartControl1_MouseMove(object sender, MouseEventArgs e)
		{
			NHitTestResult result = nChartControl1.HitTest(e.X, e.Y);

			if (result.ChartElement == ChartElement.RenkoData)
			{
				NRenkoData renkoData = result.RenkoData;

				StringBuilder builder = new StringBuilder();

				builder.AppendLine("BeginY:" + renkoData.BeginY.ToString());
				builder.AppendLine("EndY:" + renkoData.EndY.ToString());
				builder.AppendLine("BoxCount:" + renkoData.BoxCount.ToString());
				builder.AppendLine("Direction:" + renkoData.Direction.ToString());
				builder.AppendLine("DirectionChanged:" + renkoData.DirectionChanged.ToString());

				textBox1.Text = builder.ToString();
			}
			else
			{
				textBox1.Text = string.Empty;
			}
		}

		private void GenerateData(NRenkoSeries renko)
		{
			NStockDataGenerator dataGenerator = new NStockDataGenerator(new NRange1DD(50, 350), 0.02, 10);
			dataGenerator.Reset();

			DateTime dt = new DateTime(2022, 1, 1);

			for(int i = 0; i < 20; i++)
			{
				renko.Values.Add(dataGenerator.GetNextValue());
				renko.XValues.Add(dt);

				dt = dt.AddDays(1);
			}
		}

		private void UpBorderPropsButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;
			NRenkoSeries renko = (NRenkoSeries)nChartControl1.Charts[0].Series[0];

			if (NStrokeStyleTypeEditor.Edit(renko.BorderStyle, out strokeStyleResult))
			{
				renko.UpStrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void DownBorderStyleButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;
			NRenkoSeries renko = (NRenkoSeries)nChartControl1.Charts[0].Series[0];

			if (NStrokeStyleTypeEditor.Edit(renko.BorderStyle, out strokeStyleResult))
			{
				renko.DownStrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void UpFillStyleStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle upFillStyleResult;
			NRenkoSeries renko = (NRenkoSeries)nChartControl1.Charts[0].Series[0];

			if(NFillStyleTypeEditor.Edit(renko.UpFillStyle, out upFillStyleResult))
			{
				renko.UpFillStyle = upFillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void DownFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle downFillStyleResult;
			NRenkoSeries renko = (NRenkoSeries)nChartControl1.Charts[0].Series[0];

			if(NFillStyleTypeEditor.Edit(renko.DownFillStyle, out downFillStyleResult))
			{
				renko.DownFillStyle = downFillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void BoxSizeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NRenkoSeries renko = (NRenkoSeries)nChartControl1.Charts[0].Series[0];

			switch(BoxSizeCombo.SelectedIndex)
			{
				case 0:
					renko.BoxSize = 0.5;
					renko.BoxSizeInPercents = false;
					break;

				case 1:
					renko.BoxSize = 1;
					renko.BoxSizeInPercents = false;
					break;

				case 2:
					renko.BoxSize = 2;
					renko.BoxSizeInPercents = false;
					break;

				case 3:
					renko.BoxSize = 2;
					renko.BoxSizeInPercents = true;
					break;

				case 4:
					renko.BoxSize = 5;
					renko.BoxSizeInPercents = true;
					break;

				case 5:
					renko.BoxSize = 10;
					renko.BoxSizeInPercents = true;
					break;
			}

			nChartControl1.Refresh();
		}

		private void BoxWidthPercentCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NRenkoSeries renko = (NRenkoSeries)nChartControl1.Charts[0].Series[0];

			switch(BoxWidthPercentCombo.SelectedIndex)
			{
				case 0:
					renko.BoxWidthPercent = 50;
					break;

				case 1:
					renko.BoxWidthPercent = 75;
					break;

				case 2:
					renko.BoxWidthPercent = 100;
					break;
			}

			nChartControl1.Refresh();
		}
	}
}