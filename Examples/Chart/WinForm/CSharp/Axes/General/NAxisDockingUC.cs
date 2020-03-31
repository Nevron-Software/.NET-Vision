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
	public class NAxisDockingUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NAxis m_RedAxis;
		private NAxis m_GreenAxis;
		private NAxis m_BlueAxis;

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NComboBox RedAxisZoneCombo;
		private Nevron.UI.WinForm.Controls.NComboBox GreenAxisZoneCombo;
		private Nevron.UI.WinForm.Controls.NComboBox BlueAxisZoneCombo;
		private System.ComponentModel.Container components = null;

		public NAxisDockingUC()
		{
			InitializeComponent();

			RedAxisZoneCombo.Items.Add("Front Left");
			RedAxisZoneCombo.Items.Add("Front Right");

			GreenAxisZoneCombo.Items.Add("Front Left");
			GreenAxisZoneCombo.Items.Add("Front Right");

			BlueAxisZoneCombo.Items.Add("Front Left");
			BlueAxisZoneCombo.Items.Add("Front Right");
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
			this.label2 = new System.Windows.Forms.Label();
			this.RedAxisZoneCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.GreenAxisZoneCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.BlueAxisZoneCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(171, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Dock Red Axis To:";
			// 
			// RedAxisZoneCombo
			// 
			this.RedAxisZoneCombo.Location = new System.Drawing.Point(7, 32);
			this.RedAxisZoneCombo.Name = "RedAxisZoneCombo";
			this.RedAxisZoneCombo.Size = new System.Drawing.Size(161, 21);
			this.RedAxisZoneCombo.TabIndex = 3;
			this.RedAxisZoneCombo.SelectedIndexChanged += new System.EventHandler(this.RedAxisZoneCombo_SelectedIndexChanged);
			// 
			// GreenAxisZoneCombo
			// 
			this.GreenAxisZoneCombo.Location = new System.Drawing.Point(7, 91);
			this.GreenAxisZoneCombo.Name = "GreenAxisZoneCombo";
			this.GreenAxisZoneCombo.Size = new System.Drawing.Size(161, 21);
			this.GreenAxisZoneCombo.TabIndex = 5;
			this.GreenAxisZoneCombo.SelectedIndexChanged += new System.EventHandler(this.GreenAxisZoneCombo_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(4, 70);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(171, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Dock Green Axis To:";
			// 
			// BlueAxisZoneCombo
			// 
			this.BlueAxisZoneCombo.Location = new System.Drawing.Point(8, 149);
			this.BlueAxisZoneCombo.Name = "BlueAxisZoneCombo";
			this.BlueAxisZoneCombo.Size = new System.Drawing.Size(161, 21);
			this.BlueAxisZoneCombo.TabIndex = 7;
			this.BlueAxisZoneCombo.SelectedIndexChanged += new System.EventHandler(this.BlueAxisZoneCombo_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(171, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Dock Red Blue Axis To:";
			// 
			// NAxisDockingUC
			// 
			this.Controls.Add(this.BlueAxisZoneCombo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.GreenAxisZoneCombo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.RedAxisZoneCombo);
			this.Controls.Add(this.label2);
			this.Name = "NAxisDockingUC";
			this.Size = new System.Drawing.Size(184, 284);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Axis Docking<br/> <font size = '9pt'>Demonstrates how to use of the dock axis anchor and how to add custom axes</font>");
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;
			m_Chart.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));

			m_RedAxis = m_Chart.Axis(StandardAxis.PrimaryY);
			m_GreenAxis = m_Chart.Axis(StandardAxis.SecondaryY);
			m_GreenAxis.Visible = true;

			// Add a custom vertical axis
			m_BlueAxis = ((NCartesianAxisCollection)m_Chart.Axes).AddCustomAxis(AxisOrientation.Vertical, AxisDockZone.FrontLeft);

			// create three line series and dispay them on three vertical axes (red, green and blue axis)
			NLineSeries line1 = CreateLineSeries(Color.Red, Color.DarkRed, 10, 20);
			NLineSeries line2 = CreateLineSeries(Color.Green, Color.DarkGreen, 50, 100);
			NLineSeries line3 = CreateLineSeries(Color.Blue, Color.DarkBlue, 100, 200);

			line1.DisplayOnAxis(StandardAxis.PrimaryY, true);

			line2.DisplayOnAxis(StandardAxis.PrimaryY, false);
			line2.DisplayOnAxis(StandardAxis.SecondaryY, true);

			line3.DisplayOnAxis(StandardAxis.PrimaryY, false);
			line3.DisplayOnAxis(m_BlueAxis.AxisId, true);

			// now configure the axis appearance
			NLinearScaleConfigurator linearScale;

			// setup the red axis
			linearScale = new NLinearScaleConfigurator();
			m_RedAxis.ScaleConfigurator = linearScale;

			linearScale.RulerStyle.FillStyle = new NColorFillStyle(Color.DarkRed);
			linearScale.RulerStyle.BorderStyle.Color = Color.Red;
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Red;
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Red;
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
			linearScale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.DarkRed);

			// setup the green axis
			linearScale = new NLinearScaleConfigurator();
			m_GreenAxis.ScaleConfigurator = linearScale;

			linearScale.RulerStyle.FillStyle = new NColorFillStyle(Color.DarkGreen);
			linearScale.RulerStyle.BorderStyle.Color = Color.Green;
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Green;
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Green;
			linearScale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.DarkGreen);

			linearScale.RulerStyle.FillStyle = new NColorFillStyle(Color.DarkBlue);
			linearScale.RulerStyle.BorderStyle.Color = Color.Blue;
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Blue;
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Blue;
			linearScale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.DarkBlue);

			RedAxisZoneCombo.SelectedIndex = 0;
			GreenAxisZoneCombo.SelectedIndex = 0;
			BlueAxisZoneCombo.SelectedIndex = 0;

			UpdateAxisAnchors();
        }

		private NLineSeries CreateLineSeries(Color lightColor, Color darkColor, int begin, int end)
		{
			// Add a line series
			NLineSeries line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			line.Values.FillRandomRange(Random, 5, begin, end);
			line.BorderStyle.Color = darkColor;
			line.DataLabelStyle.Format = "<value>";
			line.DataLabelStyle.TextStyle.BackplaneStyle.Visible = false;
			line.DataLabelStyle.ArrowStrokeStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			line.DataLabelStyle.ArrowLength = new NLength(2.5f, NRelativeUnit.ParentPercentage);
			line.DataLabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.BorderStyle.Color = darkColor;
			line.MarkerStyle.FillStyle = new NColorFillStyle(lightColor);
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.MarkerStyle.Width = new NLength(2, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Height = new NLength(2, NRelativeUnit.ParentPercentage);

			return line;
		}

		private void UpdateAxisAnchors()
		{
			if (RedAxisZoneCombo.SelectedIndex == 0)
			{
				m_RedAxis.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, true);
			}
			else
			{
				m_RedAxis.Anchor = new NDockAxisAnchor(AxisDockZone.FrontRight, true);
			}

			if (GreenAxisZoneCombo.SelectedIndex == 0)
			{
				m_GreenAxis.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, true);
			}
			else
			{
				m_GreenAxis.Anchor = new NDockAxisAnchor(AxisDockZone.FrontRight, true);
			}

			if (BlueAxisZoneCombo.SelectedIndex == 0)
			{
				m_BlueAxis.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, true);
			}
			else
			{
				m_BlueAxis.Anchor = new NDockAxisAnchor(AxisDockZone.FrontRight, true);
			}

			nChartControl1.Refresh();
		}

		private void RedAxisZoneCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateAxisAnchors();
		}

		private void GreenAxisZoneCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateAxisAnchors();
		}

		private void BlueAxisZoneCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateAxisAnchors();
		}
	}
}
