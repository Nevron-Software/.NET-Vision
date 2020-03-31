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
	public class NHitTestingScaleElementsUC : NExampleBaseUC
	{
		private Label label7;
		private UI.WinForm.Controls.NTextBox AxisElementTextBox;
		private System.ComponentModel.Container components = null;

		public NHitTestingScaleElementsUC()
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
			this.label7 = new System.Windows.Forms.Label();
			this.AxisElementTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.SuspendLayout();
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(3, 11);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(191, 16);
			this.label7.TabIndex = 21;
			this.label7.Text = "Axis Element:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AxisElementTextBox
			// 
			this.AxisElementTextBox.Location = new System.Drawing.Point(6, 30);
			this.AxisElementTextBox.Name = "AxisElementTextBox";
			this.AxisElementTextBox.ReadOnly = true;
			this.AxisElementTextBox.Size = new System.Drawing.Size(171, 18);
			this.AxisElementTextBox.TabIndex = 22;
			// 
			// NHitTestingScaleElementsUC
			// 
			this.Controls.Add(this.label7);
			this.Controls.Add(this.AxisElementTextBox);
			this.Name = "NHitTestingScaleElementsUC";
			this.Size = new System.Drawing.Size(180, 495);
			this.ResumeLayout(false);

		}
		#endregion


        struct NLabelInfo
        {
            #region Constructors

            public NLabelInfo(double value, string text, Color foreColor, Color backColor)
            {
                Value = value;
                Text = text;
                ForeColor = foreColor;
                BackColor = backColor;
            }

            #endregion

            #region Fields

            public double Value;
            public string Text;
            public Color ForeColor;
            public Color BackColor;

            #endregion
        }

		public override void Initialize()
		{
			base.Initialize();

			// create a title
			NLabel title = new NLabel("Hit Testing Scale Elements");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// hide the legend
			nChartControl1.Legends[0].Visible = false;

			// configure chart
			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.Depth).Visible = false;

			// add interlace stripe
			NLinearScaleConfigurator scaleY = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			scaleY.Title.Text = "Y Axis Title";
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			scaleY.StripStyles.Add(stripStyle);

			// add the line
			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line.LineSegmentShape = LineSegmentShape.Line;
			line.DataLabelStyle.Visible = false;
			line.Legend.Mode = SeriesLegendMode.DataPoints;
			line.InflateMargins = true;
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			line.Name = "Line Series";
			line.UseXValues = true;

			// add xy values
			line.AddDataPoint(new NDataPoint(15, 10));
			line.AddDataPoint(new NDataPoint(25, 23));
			line.AddDataPoint(new NDataPoint(45, 12));

			ConfigureAxis(chart.Axis(StandardAxis.PrimaryX));
			ConfigureAxis(chart.Axis(StandardAxis.PrimaryY));

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			nChartControl1.MouseMove += new MouseEventHandler(nChartControl1_MouseMove);
		}

		void nChartControl1_MouseMove(object sender, MouseEventArgs e)
		{
			NHitTestResult result = nChartControl1.HitTest(e.X, e.Y);

			if (result.Axis == null)
			{
				AxisElementTextBox.Text = "The mouse is not over an axis.";
			}
			else
			{
				string text = "The mouse is over ";

				switch (result.AxisScalePartId)
				{
					case 1:
						text += "an inner major tick.";
						break;
					case 2:
						text += "an outer major tick.";
						break;
					case 3:
						text += "an inner minor tick.";
						break;
					case 4:
						text += "an outer minor tick.";
						break;
					case 5:
						text += "a ruler.";
						break;
					case 6:
						text += "an auto label.";
						break;
					case 7:
						text += "a title.";
						break;
				}

				AxisElementTextBox.Text = text;
			}
		}

		private void ConfigureAxis(NAxis axis)
		{
			NLinearScaleConfigurator scale = new NLinearScaleConfigurator();
			axis.ScaleConfigurator = scale;

			scale.InnerMajorTickStyle.LineStyle.Color = Color.Red;
			scale.InnerMajorTickStyle.Length = new NLength(10);
			scale.InnerMajorTickStyle.Visible = true;
			scale.InnerMajorTickStyle.PartId = 1;

			scale.OuterMajorTickStyle.Length = new NLength(10);
			scale.OuterMajorTickStyle.PartId = 2;

			scale.InnerMinorTickStyle.LineStyle.Color = Color.Red;
			scale.InnerMinorTickStyle.Length = new NLength(5);
			scale.InnerMinorTickStyle.Visible = true;
			scale.InnerMinorTickStyle.PartId = 3;

			scale.OuterMinorTickStyle.Length = new NLength(5);
			scale.OuterMinorTickStyle.PartId = 4;

			scale.RulerStyle.PartId = 5;

			scale.LabelStyle.PartId = 6;
			scale.LabelStyle.TextStyle.FontStyle.EmSize = new NLength(15);

			scale.Title.Text = "Axis Title";
			scale.Title.TextStyle.FontStyle.EmSize = new NLength(18);
			scale.Title.PartId = 7;
		}
	}
}