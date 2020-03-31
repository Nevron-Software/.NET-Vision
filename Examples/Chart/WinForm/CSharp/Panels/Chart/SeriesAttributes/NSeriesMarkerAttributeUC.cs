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
	public class NSeriesMarkerAttributeUC : NExampleBaseUC
	{
		private NMarkerStyle m_MarkerStyle;
		private NLineSeries m_Line;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NComboBox StyleCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox AutoDepth;
		private Nevron.UI.WinForm.Controls.NCheckBox VisibleCheck;
		private Nevron.UI.WinForm.Controls.NButton MarkerColor;
		private Nevron.UI.WinForm.Controls.NButton MarkerBorderColor;
		private Nevron.UI.WinForm.Controls.NHScrollBar WidthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar HeightScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar DepthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar LineDepthScroll;
		private Nevron.UI.WinForm.Controls.NComboBox SelectMarkerCombo;
		private System.ComponentModel.Container components = null;

		public NSeriesMarkerAttributeUC()
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
			this.StyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.AutoDepth = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.WidthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.HeightScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.DepthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.LineDepthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.VisibleCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.MarkerColor = new Nevron.UI.WinForm.Controls.NButton();
			this.MarkerBorderColor = new Nevron.UI.WinForm.Controls.NButton();
			this.SelectMarkerCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 299);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Style:";
			// 
			// StyleCombo
			// 
			this.StyleCombo.Location = new System.Drawing.Point(9, 318);
			this.StyleCombo.Name = "StyleCombo";
			this.StyleCombo.Size = new System.Drawing.Size(160, 21);
			this.StyleCombo.TabIndex = 1;
			this.StyleCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			// 
			// AutoDepth
			// 
			this.AutoDepth.Location = new System.Drawing.Point(9, 168);
			this.AutoDepth.Name = "AutoDepth";
			this.AutoDepth.Size = new System.Drawing.Size(160, 20);
			this.AutoDepth.TabIndex = 2;
			this.AutoDepth.Text = "Auto Depth";
			this.AutoDepth.CheckedChanged += new System.EventHandler(this.AutoDepth_CheckedChanged);
			// 
			// WidthScroll
			// 
			this.WidthScroll.LargeChange = 1;
			this.WidthScroll.Location = new System.Drawing.Point(9, 92);
			this.WidthScroll.Name = "WidthScroll";
			this.WidthScroll.Size = new System.Drawing.Size(160, 16);
			this.WidthScroll.TabIndex = 3;
			this.WidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WidthScroll_Scroll);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 74);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(160, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Width:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(9, 121);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(160, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Height:";
			// 
			// HeightScroll
			// 
			this.HeightScroll.LargeChange = 1;
			this.HeightScroll.Location = new System.Drawing.Point(9, 139);
			this.HeightScroll.Name = "HeightScroll";
			this.HeightScroll.Size = new System.Drawing.Size(160, 16);
			this.HeightScroll.TabIndex = 6;
			this.HeightScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.HeightScroll_Scroll);
			// 
			// DepthScroll
			// 
			this.DepthScroll.LargeChange = 1;
			this.DepthScroll.Location = new System.Drawing.Point(9, 216);
			this.DepthScroll.Name = "DepthScroll";
			this.DepthScroll.Size = new System.Drawing.Size(160, 16);
			this.DepthScroll.TabIndex = 7;
			this.DepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.DepthScroll_Scroll);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(9, 198);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(160, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "Depth:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(9, 247);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(160, 16);
			this.label5.TabIndex = 10;
			this.label5.Text = "Line Depth %:";
			// 
			// LineDepthScroll
			// 
			this.LineDepthScroll.Location = new System.Drawing.Point(9, 264);
			this.LineDepthScroll.Name = "LineDepthScroll";
			this.LineDepthScroll.Size = new System.Drawing.Size(160, 16);
			this.LineDepthScroll.TabIndex = 9;
			this.LineDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LineDepthScroll_Scroll);
			// 
			// VisibleCheck
			// 
			this.VisibleCheck.Location = new System.Drawing.Point(9, 49);
			this.VisibleCheck.Name = "VisibleCheck";
			this.VisibleCheck.Size = new System.Drawing.Size(160, 18);
			this.VisibleCheck.TabIndex = 11;
			this.VisibleCheck.Text = "Visible";
			this.VisibleCheck.CheckedChanged += new System.EventHandler(this.Visible_CheckedChanged);
			// 
			// MarkerColor
			// 
			this.MarkerColor.Location = new System.Drawing.Point(9, 369);
			this.MarkerColor.Name = "MarkerColor";
			this.MarkerColor.Size = new System.Drawing.Size(160, 23);
			this.MarkerColor.TabIndex = 12;
			this.MarkerColor.Text = "Marker Fill Style...";
			this.MarkerColor.Click += new System.EventHandler(this.MarkerColor_Click);
			// 
			// MarkerBorderColor
			// 
			this.MarkerBorderColor.Location = new System.Drawing.Point(9, 400);
			this.MarkerBorderColor.Name = "MarkerBorderColor";
			this.MarkerBorderColor.Size = new System.Drawing.Size(160, 23);
			this.MarkerBorderColor.TabIndex = 13;
			this.MarkerBorderColor.Text = "Marker Border...";
			this.MarkerBorderColor.Click += new System.EventHandler(this.MarkerBorderColor_Click);
			// 
			// SelectMarkerCombo
			// 
			this.SelectMarkerCombo.Location = new System.Drawing.Point(9, 8);
			this.SelectMarkerCombo.Name = "SelectMarkerCombo";
			this.SelectMarkerCombo.Size = new System.Drawing.Size(160, 21);
			this.SelectMarkerCombo.TabIndex = 14;
			this.SelectMarkerCombo.SelectedIndexChanged += new System.EventHandler(this.SelectMarkerCombo_SelectedIndexChanged);
			// 
			// NSeriesAttribsMarkersUC
			// 
			this.Controls.Add(this.SelectMarkerCombo);
			this.Controls.Add(this.MarkerBorderColor);
			this.Controls.Add(this.MarkerColor);
			this.Controls.Add(this.VisibleCheck);
			this.Controls.Add(this.LineDepthScroll);
			this.Controls.Add(this.DepthScroll);
			this.Controls.Add(this.HeightScroll);
			this.Controls.Add(this.WidthScroll);
			this.Controls.Add(this.AutoDepth);
			this.Controls.Add(this.StyleCombo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label2);
			this.Name = "NSeriesAttribsMarkersUC";
			this.Size = new System.Drawing.Size(180, 437);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Series Marker Attribute");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
            NChart chart = nChartControl1.Charts[0];
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			chart.Enable3D = true;

            // add interlaced stripe to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            ((NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

            chart.Axis(StandardAxis.Depth).Visible = false;

			m_Line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			m_Line.LineSegmentShape = LineSegmentShape.Tape;
			m_Line.InflateMargins = true;
			m_Line.DepthPercent = 50;
			m_Line.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Line.Name = "Line Series";
			m_Line.Values.FillRandom(Random, 6);
			m_Line.DataLabelStyle.Visible = false;
			m_Line.ShadowStyle.Type = ShadowType.GaussianBlur;
			m_Line.ShadowStyle.Offset = new NPointL(2, 2);
			m_Line.ShadowStyle.Color = Color.FromArgb(88, 0, 0, 0);
			m_Line.ShadowStyle.FadeLength = new NLength(5);
			m_Line.MarkerStyle.Visible = true;

			NMarkerStyle marker = new NMarkerStyle();
			marker.FillStyle = new NColorFillStyle(Color.Red);
			marker.PointShape = PointShape.Cylinder;
			marker.Visible = true;
			m_Line.MarkerStyles[3] = marker;

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			StyleCombo.FillFromEnum(typeof(PointShape));

			SelectMarkerCombo.Items.Add("Edit Default Marker");
			SelectMarkerCombo.Items.Add("Edit Marker #3");
			SelectMarkerCombo.SelectedIndex = 0;

			VisibleCheck.Checked = true;
		}

		private void StyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_MarkerStyle.PointShape = (PointShape)StyleCombo.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void AutoDepth_CheckedChanged(object sender, System.EventArgs e)
		{
			DepthScroll.Enabled = !AutoDepth.Checked;

			m_MarkerStyle.AutoDepth = AutoDepth.Checked;
			nChartControl1.Refresh();
		}

		private void DepthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_MarkerStyle.Depth = new NLength((float)DepthScroll.Value / 10.0f, NRelativeUnit.ParentPercentage);
			nChartControl1.Refresh();
		}

		private void HeightScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_MarkerStyle.Height = new NLength((float)HeightScroll.Value / 20.0f, NRelativeUnit.ParentPercentage);
			nChartControl1.Refresh();
		}

		private void WidthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_MarkerStyle.Width = new NLength((float)WidthScroll.Value / 20.0f, NRelativeUnit.ParentPercentage);
			nChartControl1.Refresh();
		}

		private void LineDepthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Line.DepthPercent = LineDepthScroll.Value;
			nChartControl1.Refresh();
		}

		private void Visible_CheckedChanged(object sender, System.EventArgs e)
		{
			m_MarkerStyle.Visible = VisibleCheck.Checked;
			nChartControl1.Refresh();
		}

		private void MarkerColor_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_MarkerStyle.FillStyle, out fillStyleResult))
			{
				m_MarkerStyle.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void MarkerBorderColor_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_MarkerStyle.BorderStyle, out strokeStyleResult))
			{
				m_MarkerStyle.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void SelectMarkerCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch(SelectMarkerCombo.SelectedIndex)
			{
				case 0:
					m_MarkerStyle = m_Line.MarkerStyle;
					break;

				case 1:
					m_MarkerStyle = (NMarkerStyle)m_Line.MarkerStyles[3];
					break;
			}

			VisibleCheck.Checked = m_MarkerStyle.Visible;
			WidthScroll.Value = (int)(m_MarkerStyle.Width.Value * 20);
			HeightScroll.Value = (int)(m_MarkerStyle.Height.Value * 20);
			DepthScroll.Value = (int)(m_MarkerStyle.Depth.Value * 10);
			AutoDepth.Checked = m_MarkerStyle.AutoDepth;
			StyleCombo.SelectedIndex = (int)m_MarkerStyle.PointShape;
		}
	}
}
