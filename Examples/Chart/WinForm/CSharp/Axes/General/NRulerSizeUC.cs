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
	public class NRulerSizeUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private int m_CustomAxisId;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NHScrollBar hScrollBar1;
		private Nevron.UI.WinForm.Controls.NHScrollBar hScrollBar2;
		private System.Windows.Forms.Label Scroll1BeginLabel;
		private System.Windows.Forms.Label Scroll2BeginLabel;
		private System.Windows.Forms.Label Scroll1EndLabel;
		private System.Windows.Forms.Label Scroll2EndLabel;
		private System.ComponentModel.Container components = null;

		public NRulerSizeUC()
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.hScrollBar1 = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.hScrollBar2 = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.Scroll1BeginLabel = new System.Windows.Forms.Label();
			this.Scroll2BeginLabel = new System.Windows.Forms.Label();
			this.Scroll1EndLabel = new System.Windows.Forms.Label();
			this.Scroll2EndLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(141, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Red Axis End Percent:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(141, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "Blue Axis Begin Percent:";
			// 
			// hScrollBar1
			// 
			this.hScrollBar1.LargeChange = 1;
			this.hScrollBar1.Location = new System.Drawing.Point(46, 37);
			this.hScrollBar1.Name = "hScrollBar1";
			this.hScrollBar1.Size = new System.Drawing.Size(106, 19);
			this.hScrollBar1.TabIndex = 6;
			this.hScrollBar1.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.hScrollBar1_Scroll);
			// 
			// hScrollBar2
			// 
			this.hScrollBar2.LargeChange = 1;
			this.hScrollBar2.Location = new System.Drawing.Point(46, 121);
			this.hScrollBar2.Name = "hScrollBar2";
			this.hScrollBar2.Size = new System.Drawing.Size(106, 19);
			this.hScrollBar2.TabIndex = 5;
			this.hScrollBar2.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.hScrollBar2_Scroll);
			// 
			// Scroll1BeginLabel
			// 
			this.Scroll1BeginLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Scroll1BeginLabel.Location = new System.Drawing.Point(12, 38);
			this.Scroll1BeginLabel.Name = "Scroll1BeginLabel";
			this.Scroll1BeginLabel.Size = new System.Drawing.Size(28, 17);
			this.Scroll1BeginLabel.TabIndex = 7;
			this.Scroll1BeginLabel.Text = "0";
			// 
			// Scroll2BeginLabel
			// 
			this.Scroll2BeginLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Scroll2BeginLabel.Location = new System.Drawing.Point(12, 123);
			this.Scroll2BeginLabel.Name = "Scroll2BeginLabel";
			this.Scroll2BeginLabel.Size = new System.Drawing.Size(28, 17);
			this.Scroll2BeginLabel.TabIndex = 8;
			// 
			// Scroll1EndLabel
			// 
			this.Scroll1EndLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Scroll1EndLabel.Location = new System.Drawing.Point(158, 38);
			this.Scroll1EndLabel.Name = "Scroll1EndLabel";
			this.Scroll1EndLabel.Size = new System.Drawing.Size(28, 17);
			this.Scroll1EndLabel.TabIndex = 9;
			// 
			// Scroll2EndLabel
			// 
			this.Scroll2EndLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Scroll2EndLabel.Location = new System.Drawing.Point(158, 122);
			this.Scroll2EndLabel.Name = "Scroll2EndLabel";
			this.Scroll2EndLabel.Size = new System.Drawing.Size(28, 17);
			this.Scroll2EndLabel.TabIndex = 10;
			this.Scroll2EndLabel.Text = "100";
			// 
			// NRulerSizeUC
			// 
			this.Controls.Add(this.Scroll2EndLabel);
			this.Controls.Add(this.Scroll1EndLabel);
			this.Controls.Add(this.Scroll2BeginLabel);
			this.Controls.Add(this.Scroll1BeginLabel);
			this.Controls.Add(this.hScrollBar1);
			this.Controls.Add(this.hScrollBar2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "NRulerSizeUC";
			this.Size = new System.Drawing.Size(202, 182);
			this.ResumeLayout(false);

		}
		#endregion


		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Axis Docking and Anchor Percentages<br/> <font size = '9pt'>Demonstrates how to dock axes without creating a new zone level</font>");
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // turn off the legend
            nChartControl1.Legends[0].Mode = LegendMode.Disabled;

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
            m_Chart.BoundsMode = BoundsMode.Fit;

            // apply predefined lighting and projection
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

            // configure primary Y
            NAxis primaryY = m_Chart.Axis(StandardAxis.PrimaryY);
            primaryY.Anchor.BeginPercent = 0;
            primaryY.Anchor.EndPercent = 30;

            // configure secondary Y
            NAxis secondaryY = m_Chart.Axis(StandardAxis.SecondaryY);
            secondaryY.Visible = true;
            secondaryY.Anchor.BeginPercent = 30;
            secondaryY.Anchor.EndPercent = 70;
            
            // configure a custom axis docked to the front left left chart zone
            NAxis customY = ((NCartesianAxisCollection)m_Chart.Axes).AddCustomAxis(AxisOrientation.Vertical, AxisDockZone.FrontLeft);
            customY.Visible = true;
            customY.Anchor.BeginPercent = 70;
            customY.Anchor.EndPercent = 100;
            m_CustomAxisId = customY.AxisId;

			// Setup the line series
			NLineSeries l1 = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			l1.Values.FillRandom(Random, 5);
            l1.LineSegmentShape = LineSegmentShape.Tape;
			l1.DataLabelStyle.Format = "<value>";

			NLineSeries l2 = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			l2.Values.FillRandom(Random, 5);
            l2.LineSegmentShape = LineSegmentShape.Tape;
			l2.DataLabelStyle.Format = "<value>";
			l2.DisplayOnAxis(StandardAxis.SecondaryY, true);
			l2.DisplayOnAxis(StandardAxis.PrimaryY, false);

			NLineSeries l3 = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			l3.Values.FillRandom(Random, 5);
            l3.LineSegmentShape = LineSegmentShape.Tape;
			l3.DataLabelStyle.Format = "<value>";
			l3.DisplayOnAxis(m_CustomAxisId, true);
			l3.DisplayOnAxis(StandardAxis.PrimaryY, false);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

            // set up the appearance of the axes according to the filling/stroke 
            // applied to the line series from the style sheet
            primaryY.ScaleConfigurator = ConfigureScale(l1.FillStyle, l1.BorderStyle.Color);
            secondaryY.ScaleConfigurator = ConfigureScale(l2.FillStyle, l2.BorderStyle.Color);
            customY.ScaleConfigurator = ConfigureScale(l3.FillStyle, l3.BorderStyle.Color);

			// init form controls
			hScrollBar1.Value = 30;
			hScrollBar2.Value = 70;

			hScrollBar2.Minimum = hScrollBar1.Value + 10;
			hScrollBar1.Maximum = hScrollBar2.Value - 10;

			Scroll2BeginLabel.Text = hScrollBar2.Minimum.ToString();
			Scroll1EndLabel.Text = hScrollBar1.Maximum.ToString();
		}

        private NLinearScaleConfigurator ConfigureScale(NFillStyle rulerFillStyle, Color tickColor)
        {
            NLinearScaleConfigurator scale = new NLinearScaleConfigurator();

            scale.RulerStyle.FillStyle = (NFillStyle)rulerFillStyle.Clone();
            scale.RulerStyle.Shape = ScaleLevelShape.Bar;
            scale.RulerStyle.Height = new NLength(5, NGraphicsUnit.Point);
            scale.RulerStyle.BorderStyle.Color = tickColor;
            scale.OuterMajorTickStyle.LineStyle.Color = tickColor;
            scale.InnerMajorTickStyle.LineStyle.Color = tickColor;
            scale.MajorGridStyle.LineStyle.Color = tickColor;

            NScaleStripStyle strip = new NScaleStripStyle();
            strip.StrokeStyle = null;
            strip.FillStyle = (NFillStyle)rulerFillStyle.Clone();
            strip.FillStyle.SetTransparencyPercent(80);
            strip.SetShowAtWall(ChartWallType.Back, true);
            strip.SetShowAtWall(ChartWallType.Left, true);
            scale.StripStyles.Add(strip);

            scale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            scale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);

            return scale;
        }

		private void RecalcAxes()
		{
			int bottomAxisEnd = hScrollBar1.Value;
			int middleAxisBegin = hScrollBar1.Value;
			int middleAxisEnd = hScrollBar2.Value;
			int topAxisBegin = hScrollBar2.Value;

			// red axis
			NAxis axis = m_Chart.Axis(StandardAxis.PrimaryY);
			axis.Anchor.EndPercent = hScrollBar1.Value;

			// green axis
			axis = m_Chart.Axis(StandardAxis.SecondaryY);
			axis.Anchor.BeginPercent = middleAxisBegin;
			axis.Anchor.EndPercent = middleAxisEnd;

			// blue axis
			axis = m_Chart.Axis(m_CustomAxisId);
			axis.Anchor.BeginPercent = topAxisBegin;

			nChartControl1.Refresh();
		}

		private void hScrollBar1_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			hScrollBar2.Minimum = hScrollBar1.Value + 10;

			Scroll2BeginLabel.Text = hScrollBar2.Minimum.ToString();

			RecalcAxes();
		}

		private void hScrollBar2_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			hScrollBar1.Maximum = hScrollBar2.Value - 10;

			Scroll1EndLabel.Text = hScrollBar1.Maximum.ToString();

			RecalcAxes();
		}
	}
}
