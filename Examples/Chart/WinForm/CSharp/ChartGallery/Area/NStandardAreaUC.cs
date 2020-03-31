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
	public class NStandardAreaUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NHScrollBar DepthScroll;
		private Nevron.UI.WinForm.Controls.NCheckBox DropLinesCheck;
		private Nevron.UI.WinForm.Controls.NButton AreaFEButton;
		private Nevron.UI.WinForm.Controls.NButton AreaBorderButton;
		private Nevron.UI.WinForm.Controls.NButton MarkerStyleButton;
		private Nevron.UI.WinForm.Controls.NButton LabelStyleButton;
		private Nevron.UI.WinForm.Controls.NComboBox OriginModeCombo;
		private Nevron.UI.WinForm.Controls.NTextBox OriginValueTextBox;
		private System.ComponentModel.Container components = null;

		public NStandardAreaUC()
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
			this.label3 = new System.Windows.Forms.Label();
			this.DepthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.DropLinesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.AreaFEButton = new Nevron.UI.WinForm.Controls.NButton();
			this.AreaBorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.MarkerStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.LabelStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label2 = new System.Windows.Forms.Label();
			this.OriginModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.OriginValueTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(9, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(157, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Depth %:";
			// 
			// DepthScroll
			// 
			this.DepthScroll.Location = new System.Drawing.Point(9, 25);
			this.DepthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.DepthScroll.Name = "DepthScroll";
			this.DepthScroll.Size = new System.Drawing.Size(157, 16);
			this.DepthScroll.TabIndex = 1;
			this.DepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.DepthScroll_Scroll);
			// 
			// DropLinesCheck
			// 
			this.DropLinesCheck.ButtonProperties.BorderOffset = 2;
			this.DropLinesCheck.Location = new System.Drawing.Point(9, 180);
			this.DropLinesCheck.Name = "DropLinesCheck";
			this.DropLinesCheck.Size = new System.Drawing.Size(157, 21);
			this.DropLinesCheck.TabIndex = 6;
			this.DropLinesCheck.Text = "Drop Lines";
			this.DropLinesCheck.CheckedChanged += new System.EventHandler(this.DropLinesCheck_CheckedChanged);
			// 
			// AreaFEButton
			// 
			this.AreaFEButton.Location = new System.Drawing.Point(9, 49);
			this.AreaFEButton.Name = "AreaFEButton";
			this.AreaFEButton.Size = new System.Drawing.Size(157, 24);
			this.AreaFEButton.TabIndex = 2;
			this.AreaFEButton.Text = "Area Fill Style...";
			this.AreaFEButton.Click += new System.EventHandler(this.AreaFEButton_Click);
			// 
			// AreaBorderButton
			// 
			this.AreaBorderButton.Location = new System.Drawing.Point(9, 79);
			this.AreaBorderButton.Name = "AreaBorderButton";
			this.AreaBorderButton.Size = new System.Drawing.Size(157, 24);
			this.AreaBorderButton.TabIndex = 3;
			this.AreaBorderButton.Text = "Area Border...";
			this.AreaBorderButton.Click += new System.EventHandler(this.AreaBorderButton_Click);
			// 
			// MarkerStyleButton
			// 
			this.MarkerStyleButton.Location = new System.Drawing.Point(9, 109);
			this.MarkerStyleButton.Name = "MarkerStyleButton";
			this.MarkerStyleButton.Size = new System.Drawing.Size(157, 24);
			this.MarkerStyleButton.TabIndex = 4;
			this.MarkerStyleButton.Text = "Marker Style...";
			this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			// 
			// LabelStyleButton
			// 
			this.LabelStyleButton.Location = new System.Drawing.Point(9, 140);
			this.LabelStyleButton.Name = "LabelStyleButton";
			this.LabelStyleButton.Size = new System.Drawing.Size(157, 24);
			this.LabelStyleButton.TabIndex = 5;
			this.LabelStyleButton.Text = "Data Label Style...";
			this.LabelStyleButton.Click += new System.EventHandler(this.LabelStyleButton_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 210);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(157, 20);
			this.label2.TabIndex = 7;
			this.label2.Text = "Origin Mode:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// OriginModeCombo
			// 
			this.OriginModeCombo.ListProperties.CheckBoxDataMember = "";
			this.OriginModeCombo.ListProperties.DataSource = null;
			this.OriginModeCombo.ListProperties.DisplayMember = "";
			this.OriginModeCombo.Location = new System.Drawing.Point(9, 233);
			this.OriginModeCombo.Name = "OriginModeCombo";
			this.OriginModeCombo.Size = new System.Drawing.Size(157, 21);
			this.OriginModeCombo.TabIndex = 8;
			this.OriginModeCombo.SelectedIndexChanged += new System.EventHandler(this.OriginModeCombo_SelectedIndexChanged);
			// 
			// OriginValueTextBox
			// 
			this.OriginValueTextBox.Location = new System.Drawing.Point(9, 283);
			this.OriginValueTextBox.Name = "OriginValueTextBox";
			this.OriginValueTextBox.Size = new System.Drawing.Size(157, 18);
			this.OriginValueTextBox.TabIndex = 10;
			this.OriginValueTextBox.TextChanged += new System.EventHandler(this.OriginValueTextBox_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 263);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(157, 20);
			this.label1.TabIndex = 9;
			this.label1.Text = "Custom Origin Value:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NStandardAreaUC
			// 
			this.Controls.Add(this.label2);
			this.Controls.Add(this.OriginModeCombo);
			this.Controls.Add(this.OriginValueTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LabelStyleButton);
			this.Controls.Add(this.MarkerStyleButton);
			this.Controls.Add(this.AreaBorderButton);
			this.Controls.Add(this.AreaFEButton);
			this.Controls.Add(this.DropLinesCheck);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.DepthScroll);
			this.Name = "NStandardAreaUC";
			this.Size = new System.Drawing.Size(180, 336);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("3D Area Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// setup the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 65;
			chart.Height = 40;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

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
			stripStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back, ChartWallType.Left };

			NLinearScaleConfigurator scaleY = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			scaleY.StripStyles.Add(stripStyle);

			// hide Z axis
			chart.Axis(StandardAxis.Depth).Visible = false;

			// setup area series
			NAreaSeries area = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area.DataLabelStyle.Visible = false;
			area.DataLabelStyle.Format = "<value>";
			area.Name = "Area Series";
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

		private void DepthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NAreaSeries area = (NAreaSeries)nChartControl1.Charts[0].Series[0];
			area.DepthPercent = DepthScroll.Value;
			nChartControl1.Refresh();
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
