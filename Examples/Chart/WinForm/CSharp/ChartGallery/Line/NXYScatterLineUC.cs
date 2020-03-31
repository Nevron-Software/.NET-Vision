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
	public class NXYScatterLineUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NLineSeries m_Line;
		private Nevron.UI.WinForm.Controls.NButton ChangeXValuesButton;
		private System.ComponentModel.Container components = null;

		public NXYScatterLineUC()
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
			this.SuspendLayout();
			// 
			// ChangeXValuesButton
			// 
			this.ChangeXValuesButton.Location = new System.Drawing.Point(13, 13);
			this.ChangeXValuesButton.Name = "ChangeXValuesButton";
			this.ChangeXValuesButton.Size = new System.Drawing.Size(136, 24);
			this.ChangeXValuesButton.TabIndex = 0;
			this.ChangeXValuesButton.Text = "Change X Values";
			this.ChangeXValuesButton.Click += new System.EventHandler(this.ChangeXValuesButton_Click);
			// 
			// NXYScatterLineUC
			// 
			this.Controls.Add(this.ChangeXValuesButton);
			this.Name = "NXYScatterLineUC";
			this.Size = new System.Drawing.Size(180, 50);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XY Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlaced stripe to the Y axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            linearScale.StripStyles.Add(stripStyle);

			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			// add the line
			m_Line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line.LineSegmentShape = LineSegmentShape.Line;
			m_Line.DataLabelStyle.Visible = false;
			m_Line.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Line.InflateMargins = true;
			m_Line.MarkerStyle.Visible = true;
			m_Line.MarkerStyle.PointShape = PointShape.Cylinder;
			m_Line.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			m_Line.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			m_Line.Name = "Line Series";
			m_Line.UseXValues = true;

			// add xy values
			m_Line.AddDataPoint(new NDataPoint(15, 10));
			m_Line.AddDataPoint(new NDataPoint(25, 23));
			m_Line.AddDataPoint(new NDataPoint(45, 12));
			m_Line.AddDataPoint(new NDataPoint(55, 21));
			m_Line.AddDataPoint(new NDataPoint(61, 16));
			m_Line.AddDataPoint(new NDataPoint(67, 19));
			m_Line.AddDataPoint(new NDataPoint(72, 11));

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
		}

		private void ChangeXValuesButton_Click(object sender, System.EventArgs e)
		{
			m_Line.XValues[0] = (double)Random.Next(10);

			for (int i = 1; i < m_Line.XValues.Count; i++)
			{
				m_Line.XValues[i] = (double)m_Line.XValues[i - 1] + Random.Next(1, 10);
			}
			
			nChartControl1.Refresh();
		}
	}
}
