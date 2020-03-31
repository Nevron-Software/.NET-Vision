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
	public class NXYScatterAreaUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NAreaSeries m_Area;
		private Nevron.UI.WinForm.Controls.NButton ChangeXValuesButton;
		private Nevron.UI.WinForm.Controls.NCheckBox PrimaryXRoundToTick;
		private Nevron.UI.WinForm.Controls.NCheckBox InvertXCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox InvertYCheck;
		private System.ComponentModel.Container components = null;

		public NXYScatterAreaUC()
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
			this.ChangeXValuesButton = new Nevron.UI.WinForm.Controls.NButton();
			this.PrimaryXRoundToTick = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.InvertXCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.InvertYCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// ChangeXValuesButton
			// 
			this.ChangeXValuesButton.Location = new System.Drawing.Point(8, 10);
			this.ChangeXValuesButton.Name = "ChangeXValuesButton";
			this.ChangeXValuesButton.Size = new System.Drawing.Size(158, 24);
			this.ChangeXValuesButton.TabIndex = 1;
			this.ChangeXValuesButton.Text = "Change X Values";
			this.ChangeXValuesButton.Click += new System.EventHandler(this.ChangeXValuesButton_Click);
			// 
			// PrimaryXRoundToTick
			// 
			this.PrimaryXRoundToTick.ButtonProperties.BorderOffset = 2;
			this.PrimaryXRoundToTick.Location = new System.Drawing.Point(8, 53);
			this.PrimaryXRoundToTick.Name = "PrimaryXRoundToTick";
			this.PrimaryXRoundToTick.Size = new System.Drawing.Size(171, 19);
			this.PrimaryXRoundToTick.TabIndex = 2;
			this.PrimaryXRoundToTick.Text = "X Axis Round To Tick";
			this.PrimaryXRoundToTick.CheckedChanged += new System.EventHandler(this.PrimaryXRoundToTick_CheckedChanged);
			// 
			// InvertXCheck
			// 
			this.InvertXCheck.ButtonProperties.BorderOffset = 2;
			this.InvertXCheck.Location = new System.Drawing.Point(8, 84);
			this.InvertXCheck.Name = "InvertXCheck";
			this.InvertXCheck.Size = new System.Drawing.Size(171, 19);
			this.InvertXCheck.TabIndex = 3;
			this.InvertXCheck.Text = "Invert X Axis Ruler";
			this.InvertXCheck.CheckedChanged += new System.EventHandler(this.InvertXCheck_CheckedChanged);
			// 
			// InvertYCheck
			// 
			this.InvertYCheck.ButtonProperties.BorderOffset = 2;
			this.InvertYCheck.Location = new System.Drawing.Point(8, 107);
			this.InvertYCheck.Name = "InvertYCheck";
			this.InvertYCheck.Size = new System.Drawing.Size(171, 19);
			this.InvertYCheck.TabIndex = 4;
			this.InvertYCheck.Text = "Invert Y Axis Ruler";
			this.InvertYCheck.CheckedChanged += new System.EventHandler(this.InvertYCheck_CheckedChanged);
			// 
			// NXYScatterAreaUC
			// 
			this.Controls.Add(this.InvertYCheck);
			this.Controls.Add(this.InvertXCheck);
			this.Controls.Add(this.PrimaryXRoundToTick);
			this.Controls.Add(this.ChangeXValuesButton);
			this.Name = "NXYScatterAreaUC";
			this.Size = new System.Drawing.Size(180, 277);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XY Area Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// setup the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlace stripe
            NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

            // apply linear scaling to the x axis
			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add the area series
			m_Area = (NAreaSeries)m_Chart.Series.Add(SeriesType.Area);
			m_Area.Name = "Area Series";
			m_Area.DataLabelStyle.ArrowStrokeStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			m_Area.DataLabelStyle.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse;
			m_Area.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = Color.Crimson;
			m_Area.DataLabelStyle.Format = "<value>";
			m_Area.UseXValues = true;

			// add xy values
			m_Area.AddDataPoint(new NDataPoint(12, 10));
			m_Area.AddDataPoint(new NDataPoint(25, 23));
			m_Area.AddDataPoint(new NDataPoint(45, 12));
			m_Area.AddDataPoint(new NDataPoint(55, 24));
			m_Area.AddDataPoint(new NDataPoint(61, 16));
			m_Area.AddDataPoint(new NDataPoint(69, 19));
			m_Area.AddDataPoint(new NDataPoint(78, 17));

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			PrimaryXRoundToTick.Checked = true;
		}


		private void ChangeXValuesButton_Click(object sender, System.EventArgs e)
		{
			m_Area.XValues[0] = (double)Random.Next(10);

			for (int i = 1; i < m_Area.XValues.Count; i++)
			{
				m_Area.XValues[i] = (double)m_Area.XValues[i - 1] + Random.Next(1, 10);
			}

			nChartControl1.Refresh();
		}

		private void PrimaryXRoundToTick_CheckedChanged(object sender, System.EventArgs e)
		{
			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NLinearScaleConfigurator;
			linearScale.RoundToTickMax = PrimaryXRoundToTick.Checked;
			linearScale.RoundToTickMin = PrimaryXRoundToTick.Checked;

			nChartControl1.Refresh();
		}

		private void InvertXCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NLinearScaleConfigurator;
			linearScale.Invert = InvertXCheck.Checked;

			nChartControl1.Refresh();
		}

		private void InvertYCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			linearScale.Invert = InvertYCheck.Checked;

			nChartControl1.Refresh();
		}
	}
}