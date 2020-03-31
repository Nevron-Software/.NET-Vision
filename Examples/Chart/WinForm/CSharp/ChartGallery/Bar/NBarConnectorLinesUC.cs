using Nevron.Chart;
using Nevron.Editors;
using Nevron.GraphicsCore;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NBarConnectorLinesUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton ConnectorLinesStrokeButton;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowConnectorLinesCheckBox;
		private System.ComponentModel.IContainer components = null;

		public NBarConnectorLinesUC()
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
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ConnectorLinesStrokeButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ShowConnectorLinesCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// ConnectorLinesStrokeButton
			// 
			this.ConnectorLinesStrokeButton.Location = new System.Drawing.Point(6, 39);
			this.ConnectorLinesStrokeButton.Name = "ConnectorLinesStrokeButton";
			this.ConnectorLinesStrokeButton.Size = new System.Drawing.Size(163, 24);
			this.ConnectorLinesStrokeButton.TabIndex = 8;
			this.ConnectorLinesStrokeButton.Text = "Connector Lines Stoke..";
			this.ConnectorLinesStrokeButton.Click += new System.EventHandler(this.ConnectorLinesStrokeButton_Click);
			// 
			// ShowConnectorLinesCheckBox
			// 
			this.ShowConnectorLinesCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowConnectorLinesCheckBox.Location = new System.Drawing.Point(6, 12);
			this.ShowConnectorLinesCheckBox.Name = "ShowConnectorLinesCheckBox";
			this.ShowConnectorLinesCheckBox.Size = new System.Drawing.Size(163, 21);
			this.ShowConnectorLinesCheckBox.TabIndex = 4;
			this.ShowConnectorLinesCheckBox.Text = "Show Connector Lines";
			this.ShowConnectorLinesCheckBox.CheckedChanged += new System.EventHandler(this.ShowConnectorLinesCheckBox_CheckedChanged);
			// 
			// NBarConnectorLinesUC
			// 
			this.Controls.Add(this.ConnectorLinesStrokeButton);
			this.Controls.Add(this.ShowConnectorLinesCheckBox);
			this.Name = "NBarConnectorLinesUC";
			this.Size = new System.Drawing.Size(180, 505);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// create a title
			NLabel title = new NLabel("2D Bar Chart Connector Lines");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure chart
			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlace stripe
            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// setup a bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar Series";
			bar.ShadowStyle.Type = ShadowType.GaussianBlur;
			bar.ShadowStyle.Offset = new NPointL(2, 2);
			bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
			bar.ShadowStyle.FadeLength = new NLength(5);
			bar.DataLabelStyle.Visible = false;

			// add some data to the bar series
			bar.Values.Add(18);
			bar.Values.Add(15);
			bar.Values.Add(21);
			bar.Values.Add(23);
			bar.Values.Add(27);
			bar.Values.Add(29);
			bar.Values.Add(26);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);
			ShowConnectorLinesCheckBox.Checked = true;
		}

		private void ShowConnectorLinesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.ShowConnectorLines = ShowConnectorLinesCheckBox.Checked;
			nChartControl1.Refresh();
		}

		private void ConnectorLinesStrokeButton_Click(object sender, EventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(bar.ConnectorLineStrokeStyle, out strokeStyleResult))
			{
				bar.ConnectorLineStrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
	}
}