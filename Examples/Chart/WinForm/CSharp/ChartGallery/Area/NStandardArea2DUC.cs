using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NStandardArea2DUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NTextBox OriginValueTextBox;
		private Nevron.UI.WinForm.Controls.NCheckBox DropLinesCheck;
		private Nevron.UI.WinForm.Controls.NButton AreaFEButton;
		private Nevron.UI.WinForm.Controls.NButton AreaBorderButton;
		private Nevron.UI.WinForm.Controls.NButton AreaShadowButton;
		private Nevron.UI.WinForm.Controls.NButton MarkerStyleButton;
		private Nevron.UI.WinForm.Controls.NButton LabelStyleButton;
		private Nevron.UI.WinForm.Controls.NComboBox OriginModeCombo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.ComponentModel.Container components = null;

		public NStandardArea2DUC()
		{
			InitializeComponent();

			OriginModeCombo.FillFromEnum(typeof(SeriesOriginMode));
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
			this.OriginValueTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.DropLinesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.AreaFEButton = new Nevron.UI.WinForm.Controls.NButton();
			this.AreaBorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.AreaShadowButton = new Nevron.UI.WinForm.Controls.NButton();
			this.MarkerStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.LabelStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.OriginModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// OriginValueTextBox
			// 
			this.OriginValueTextBox.Location = new System.Drawing.Point(9, 278);
			this.OriginValueTextBox.Name = "OriginValueTextBox";
			this.OriginValueTextBox.Size = new System.Drawing.Size(157, 18);
			this.OriginValueTextBox.TabIndex = 4;
			this.OriginValueTextBox.TextChanged += new System.EventHandler(this.OriginValueTextBox_TextChanged);
			// 
			// DropLinesCheck
			// 
			this.DropLinesCheck.ButtonProperties.BorderOffset = 2;
			this.DropLinesCheck.Location = new System.Drawing.Point(9, 174);
			this.DropLinesCheck.Name = "DropLinesCheck";
			this.DropLinesCheck.Size = new System.Drawing.Size(157, 21);
			this.DropLinesCheck.TabIndex = 2;
			this.DropLinesCheck.Text = "Drop Lines";
			this.DropLinesCheck.CheckedChanged += new System.EventHandler(this.DropLinesCheck_CheckedChanged);
			// 
			// AreaFEButton
			// 
			this.AreaFEButton.Location = new System.Drawing.Point(9, 10);
			this.AreaFEButton.Name = "AreaFEButton";
			this.AreaFEButton.Size = new System.Drawing.Size(157, 24);
			this.AreaFEButton.TabIndex = 0;
			this.AreaFEButton.Text = "Area Fill Style...";
			this.AreaFEButton.Click += new System.EventHandler(this.AreaFEButton_Click);
			// 
			// AreaBorderButton
			// 
			this.AreaBorderButton.Location = new System.Drawing.Point(9, 40);
			this.AreaBorderButton.Name = "AreaBorderButton";
			this.AreaBorderButton.Size = new System.Drawing.Size(157, 24);
			this.AreaBorderButton.TabIndex = 1;
			this.AreaBorderButton.Text = "Area Border...";
			this.AreaBorderButton.Click += new System.EventHandler(this.AreaBorderButton_Click);
			// 
			// AreaShadowButton
			// 
			this.AreaShadowButton.Location = new System.Drawing.Point(9, 70);
			this.AreaShadowButton.Name = "AreaShadowButton";
			this.AreaShadowButton.Size = new System.Drawing.Size(157, 24);
			this.AreaShadowButton.TabIndex = 7;
			this.AreaShadowButton.Text = "Area Shadow...";
			this.AreaShadowButton.Click += new System.EventHandler(this.AreaShadowButton_Click);
			// 
			// MarkerStyleButton
			// 
			this.MarkerStyleButton.Location = new System.Drawing.Point(9, 100);
			this.MarkerStyleButton.Name = "MarkerStyleButton";
			this.MarkerStyleButton.Size = new System.Drawing.Size(157, 24);
			this.MarkerStyleButton.TabIndex = 14;
			this.MarkerStyleButton.Text = "Marker Style...";
			this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 258);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(157, 20);
			this.label1.TabIndex = 15;
			this.label1.Text = "Custom Origin Value:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LabelStyleButton
			// 
			this.LabelStyleButton.Location = new System.Drawing.Point(9, 131);
			this.LabelStyleButton.Name = "LabelStyleButton";
			this.LabelStyleButton.Size = new System.Drawing.Size(157, 24);
			this.LabelStyleButton.TabIndex = 16;
			this.LabelStyleButton.Text = "Data Label Style...";
			this.LabelStyleButton.Click += new System.EventHandler(this.LabelStyleButton_Click);
			// 
			// OriginModeCombo
			// 
			this.OriginModeCombo.ListProperties.CheckBoxDataMember = "";
			this.OriginModeCombo.ListProperties.DataSource = null;
			this.OriginModeCombo.ListProperties.DisplayMember = "";
			this.OriginModeCombo.Location = new System.Drawing.Point(9, 228);
			this.OriginModeCombo.Name = "OriginModeCombo";
			this.OriginModeCombo.Size = new System.Drawing.Size(157, 21);
			this.OriginModeCombo.TabIndex = 17;
			this.OriginModeCombo.SelectedIndexChanged += new System.EventHandler(this.OriginModeCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 205);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(157, 20);
			this.label2.TabIndex = 18;
			this.label2.Text = "Origin Mode:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NStandardArea2DUC
			// 
			this.Controls.Add(this.label2);
			this.Controls.Add(this.OriginModeCombo);
			this.Controls.Add(this.LabelStyleButton);
			this.Controls.Add(this.MarkerStyleButton);
			this.Controls.Add(this.AreaShadowButton);
			this.Controls.Add(this.AreaBorderButton);
			this.Controls.Add(this.AreaFEButton);
			this.Controls.Add(this.DropLinesCheck);
			this.Controls.Add(this.OriginValueTextBox);
			this.Controls.Add(this.label1);
			this.Name = "NStandardArea2DUC";
			this.Size = new System.Drawing.Size(180, 309);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("2D Area Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// setup the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.Depth).Visible = false;

			// setup X axis
			NOrdinalScaleConfigurator scaleX = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			scaleX.AutoLabels = false;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleX.DisplayDataPointsBetweenTicks = false;
			for (int i = 0; i < monthLetters.Length; i++)
			{
				scaleX.CustomLabels.Add(new NCustomValueLabel(i, monthLetters[i]));
			}

			// add interlaced stripe for Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };

			NLinearScaleConfigurator scaleY = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			scaleY.StripStyles.Add(stripStyle);

			// setup area series
			NAreaSeries area = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area.Name = "Area Series";
			area.DataLabelStyle.Visible = false;
			area.DataLabelStyle.Format = "<value>";
			area.ShadowStyle.Type = ShadowType.Solid;
			area.ShadowStyle.Offset = new NPointL(3, 0);
			area.ShadowStyle.Color = Color.FromArgb(60, 0, 0, 0);

			area.Values.AddRange(monthValues);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// form controls
			OriginModeCombo.SelectedIndex = 0;
			OriginValueTextBox.Text = "0";
		}

		private void OriginValueTextBox_TextChanged(object sender, EventArgs e)
		{
			try
			{
				NAreaSeries area = (NAreaSeries)nChartControl1.Charts[0].Series[0];
				area.Origin = Double.Parse(OriginValueTextBox.Text);
				nChartControl1.Refresh();
			}
			catch
			{
			}
		}

		private void OriginModeCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			NAreaSeries area = (NAreaSeries)nChartControl1.Charts[0].Series[0];
			area.OriginMode = (SeriesOriginMode)OriginModeCombo.SelectedIndex;

			nChartControl1.Refresh();

			OriginValueTextBox.Enabled = (area.OriginMode == SeriesOriginMode.CustomOrigin);
		}

		private void DropLinesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NAreaSeries area = (NAreaSeries)nChartControl1.Charts[0].Series[0];
			area.DropLines = DropLinesCheck.Checked;
			nChartControl1.Refresh();
		}

		private void AreaFEButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;
			NAreaSeries area = (NAreaSeries)nChartControl1.Charts[0].Series[0];

			if (NFillStyleTypeEditor.Edit(area.FillStyle, out fillStyleResult))
			{
				area.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void AreaBorderButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;
			NAreaSeries area = (NAreaSeries)nChartControl1.Charts[0].Series[0];

			if (NStrokeStyleTypeEditor.Edit(area.BorderStyle, out strokeStyleResult))
			{
				area.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void AreaShadowButton_Click(object sender, System.EventArgs e)
		{
			NShadowStyle shadowStyleResult;
			NAreaSeries area = (NAreaSeries)nChartControl1.Charts[0].Series[0];

			if (NShadowStyleTypeEditor.Edit(area.ShadowStyle, out shadowStyleResult))
			{
				area.ShadowStyle = shadowStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void MarkerStyleButton_Click(object sender, System.EventArgs e)
		{
			NMarkerStyle markerStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if(NMarkerStyleTypeEditor.Edit(series.MarkerStyle, out markerStyleResult))
			{
				series.MarkerStyle = markerStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void LabelStyleButton_Click(object sender, System.EventArgs e)
		{
			NDataLabelStyle styleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if(NDataLabelStyleTypeEditor.Edit(series.DataLabelStyle, out styleResult))
			{
				series.DataLabelStyle = styleResult;
				nChartControl1.Refresh();
			}
		}
	}
}
