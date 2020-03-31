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
	public class NStandardStepLine2DUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NStepLineSeries m_StepLine;
		private Nevron.UI.WinForm.Controls.NCheckBox InflateMarginsCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox RoundToTickCheck;
		private Nevron.UI.WinForm.Controls.NButton LineShadowButton;
		private Nevron.UI.WinForm.Controls.NButton MarkerStyleButton;
		private Nevron.UI.WinForm.Controls.NButton DataLabelStyleButton;
		private Nevron.UI.WinForm.Controls.NButton BorderStyleButton;
		private System.ComponentModel.Container components = null;

		public NStandardStepLine2DUC()
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
			this.BorderStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.InflateMarginsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.RoundToTickCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.LineShadowButton = new Nevron.UI.WinForm.Controls.NButton();
			this.MarkerStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.DataLabelStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// BorderStyleButton
			// 
			this.BorderStyleButton.Location = new System.Drawing.Point(5, 8);
			this.BorderStyleButton.Name = "BorderStyleButton";
			this.BorderStyleButton.Size = new System.Drawing.Size(170, 24);
			this.BorderStyleButton.TabIndex = 2;
			this.BorderStyleButton.Text = "Border Style ...";
			this.BorderStyleButton.Click += new System.EventHandler(this.BorderPropsButton_Click);
			// 
			// InflateMarginsCheck
			// 
			this.InflateMarginsCheck.ButtonProperties.BorderOffset = 2;
			this.InflateMarginsCheck.Location = new System.Drawing.Point(5, 142);
			this.InflateMarginsCheck.Name = "InflateMarginsCheck";
			this.InflateMarginsCheck.Size = new System.Drawing.Size(170, 20);
			this.InflateMarginsCheck.TabIndex = 5;
			this.InflateMarginsCheck.Text = "Inflate Margins";
			this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			// 
			// RoundToTickCheck
			// 
			this.RoundToTickCheck.ButtonProperties.BorderOffset = 2;
			this.RoundToTickCheck.Location = new System.Drawing.Point(5, 170);
			this.RoundToTickCheck.Name = "RoundToTickCheck";
			this.RoundToTickCheck.Size = new System.Drawing.Size(170, 20);
			this.RoundToTickCheck.TabIndex = 6;
			this.RoundToTickCheck.Text = "Left Axis Round to Tick";
			this.RoundToTickCheck.CheckedChanged += new System.EventHandler(this.RoundToTickCheck_CheckedChanged);
			// 
			// LineShadowButton
			// 
			this.LineShadowButton.Location = new System.Drawing.Point(5, 39);
			this.LineShadowButton.Name = "LineShadowButton";
			this.LineShadowButton.Size = new System.Drawing.Size(170, 24);
			this.LineShadowButton.TabIndex = 4;
			this.LineShadowButton.Text = "Line Shadow...";
			this.LineShadowButton.Click += new System.EventHandler(this.LineShadowButton_Click);
			// 
			// MarkerStyleButton
			// 
			this.MarkerStyleButton.Location = new System.Drawing.Point(5, 71);
			this.MarkerStyleButton.Name = "MarkerStyleButton";
			this.MarkerStyleButton.Size = new System.Drawing.Size(170, 24);
			this.MarkerStyleButton.TabIndex = 36;
			this.MarkerStyleButton.Text = "Marker Style...";
			this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			// 
			// DataLabelStyleButton
			// 
			this.DataLabelStyleButton.Location = new System.Drawing.Point(5, 102);
			this.DataLabelStyleButton.Name = "DataLabelStyleButton";
			this.DataLabelStyleButton.Size = new System.Drawing.Size(170, 24);
			this.DataLabelStyleButton.TabIndex = 37;
			this.DataLabelStyleButton.Text = "Data Label Style...";
			this.DataLabelStyleButton.Click += new System.EventHandler(this.DataLabelStyleButton_Click);
			// 
			// NStandardStepLine2DUC
			// 
			this.Controls.Add(this.DataLabelStyleButton);
			this.Controls.Add(this.MarkerStyleButton);
			this.Controls.Add(this.LineShadowButton);
			this.Controls.Add(this.RoundToTickCheck);
			this.Controls.Add(this.InflateMarginsCheck);
			this.Controls.Add(this.BorderStyleButton);
			this.Name = "NStandardStepLine2DUC";
			this.Size = new System.Drawing.Size(180, 208);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("2D Step Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

            NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			m_StepLine = (NStepLineSeries)m_Chart.Series.Add(SeriesType.StepLine);
			m_StepLine.Name = "Series 1";
			m_StepLine.BorderStyle.Color = Color.SlateBlue;
			m_StepLine.BorderStyle.Width = new NLength(2);
			m_StepLine.DataLabelStyle.VertAlign = VertAlign.Center;
			m_StepLine.DataLabelStyle.Format = "<value>";
			m_StepLine.DataLabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
			m_StepLine.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(1.4f, NRelativeUnit.RootPercentage);
			m_StepLine.DataLabelStyle.TextStyle.BackplaneStyle.Visible = false;
			m_StepLine.MarkerStyle.Visible = true;
			m_StepLine.MarkerStyle.PointShape = PointShape.Cylinder;
			m_StepLine.MarkerStyle.BorderStyle.Color = Color.SlateBlue;
			m_StepLine.ShadowStyle.Type = ShadowType.GaussianBlur;
			m_StepLine.ShadowStyle.Offset = new NPointL(3, 3);
			m_StepLine.ShadowStyle.FadeLength = new NLength(5);
			m_StepLine.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0);
			m_StepLine.Values.FillRandom(Random, 8);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			RoundToTickCheck.Checked = true;
			InflateMarginsCheck.Checked = true;
		}

		private void BorderPropsButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_StepLine.BorderStyle, out strokeStyleResult))
			{
				m_StepLine.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void LineFillColorButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_StepLine.FillStyle, out fillStyleResult))
			{
				m_StepLine.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void LineShadowButton_Click(object sender, System.EventArgs e)
		{
			NShadowStyle shadowStyleResult;

			if(NShadowStyleTypeEditor.Edit(m_StepLine.ShadowStyle, out shadowStyleResult))
			{
				m_StepLine.ShadowStyle = shadowStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void InflateMarginsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			m_StepLine.InflateMargins = InflateMarginsCheck.Checked;
			nChartControl1.Refresh();
		}
		private void RoundToTickCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator standardScale = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			standardScale.RoundToTickMax = RoundToTickCheck.Checked;
			standardScale.RoundToTickMin = RoundToTickCheck.Checked;

			nChartControl1.Refresh();
		}
		private void MarkerBorderButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_StepLine.MarkerStyle.BorderStyle, out strokeStyleResult))
			{
				m_StepLine.MarkerStyle.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void MarkerFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_StepLine.MarkerStyle.FillStyle, out fillStyleResult))
			{
				m_StepLine.MarkerStyle.FillStyle = fillStyleResult;
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
		private void DataLabelStyleButton_Click(object sender, System.EventArgs e)
		{
			NDataLabelStyle dataLabelStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if(NDataLabelStyleTypeEditor.Edit(series.DataLabelStyle, out dataLabelStyleResult))
			{
				series.DataLabelStyle = dataLabelStyleResult;
				nChartControl1.Refresh();
			}
		}
	}
}