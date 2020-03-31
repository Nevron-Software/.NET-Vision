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
	public class NStandardStepLineUC : NExampleBaseUC
	{
		private NStepLineSeries m_Line;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NComboBox LineStyleCombo;
		private Nevron.UI.WinForm.Controls.NHScrollBar LineDepthScroll;
		private Nevron.UI.WinForm.Controls.NButton LineFillColorButton;
		private Nevron.UI.WinForm.Controls.NCheckBox InflateMarginsCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox RoundToTickCheck;
		private Nevron.UI.WinForm.Controls.NButton MarkerStyleButton;
		private Nevron.UI.WinForm.Controls.NButton DataLabelStyleButton;
		private Nevron.UI.WinForm.Controls.NHScrollBar LineSizeScroll;
		private Nevron.UI.WinForm.Controls.NButton BorderStyleButton;
		private System.ComponentModel.Container components = null;

		public NStandardStepLineUC()
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
			this.LineStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.LineDepthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.BorderStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.LineFillColorButton = new Nevron.UI.WinForm.Controls.NButton();
			this.InflateMarginsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.RoundToTickCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.MarkerStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label3 = new System.Windows.Forms.Label();
			this.LineSizeScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.DataLabelStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// LineStyleCombo
			// 
			this.LineStyleCombo.ListProperties.CheckBoxDataMember = "";
			this.LineStyleCombo.ListProperties.DataSource = null;
			this.LineStyleCombo.ListProperties.DisplayMember = "";
			this.LineStyleCombo.Location = new System.Drawing.Point(5, 25);
			this.LineStyleCombo.Name = "LineStyleCombo";
			this.LineStyleCombo.Size = new System.Drawing.Size(169, 21);
			this.LineStyleCombo.TabIndex = 1;
			this.LineStyleCombo.SelectedIndexChanged += new System.EventHandler(this.LineStyleCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(169, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Line Style:";
			// 
			// LineDepthScroll
			// 
			this.LineDepthScroll.Location = new System.Drawing.Point(5, 86);
			this.LineDepthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.LineDepthScroll.Name = "LineDepthScroll";
			this.LineDepthScroll.Size = new System.Drawing.Size(169, 16);
			this.LineDepthScroll.TabIndex = 3;
			this.LineDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LineDepthScroll_Scroll);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(169, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Line Depth %:";
			// 
			// BorderStyleButton
			// 
			this.BorderStyleButton.Location = new System.Drawing.Point(5, 163);
			this.BorderStyleButton.Name = "BorderStyleButton";
			this.BorderStyleButton.Size = new System.Drawing.Size(169, 24);
			this.BorderStyleButton.TabIndex = 6;
			this.BorderStyleButton.Text = "Border Style ...";
			this.BorderStyleButton.Click += new System.EventHandler(this.BorderPropsButton_Click);
			// 
			// LineFillColorButton
			// 
			this.LineFillColorButton.Location = new System.Drawing.Point(5, 194);
			this.LineFillColorButton.Name = "LineFillColorButton";
			this.LineFillColorButton.Size = new System.Drawing.Size(169, 24);
			this.LineFillColorButton.TabIndex = 7;
			this.LineFillColorButton.Text = "Line Fill Style...";
			this.LineFillColorButton.Click += new System.EventHandler(this.LineFillColorButton_Click);
			// 
			// InflateMarginsCheck
			// 
			this.InflateMarginsCheck.ButtonProperties.BorderOffset = 2;
			this.InflateMarginsCheck.Location = new System.Drawing.Point(5, 297);
			this.InflateMarginsCheck.Name = "InflateMarginsCheck";
			this.InflateMarginsCheck.Size = new System.Drawing.Size(169, 20);
			this.InflateMarginsCheck.TabIndex = 10;
			this.InflateMarginsCheck.Text = "Inflate Margins";
			this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			// 
			// RoundToTickCheck
			// 
			this.RoundToTickCheck.ButtonProperties.BorderOffset = 2;
			this.RoundToTickCheck.Location = new System.Drawing.Point(5, 324);
			this.RoundToTickCheck.Name = "RoundToTickCheck";
			this.RoundToTickCheck.Size = new System.Drawing.Size(169, 19);
			this.RoundToTickCheck.TabIndex = 11;
			this.RoundToTickCheck.Text = "Left Axis Round to Tick";
			this.RoundToTickCheck.CheckedChanged += new System.EventHandler(this.RoundToTickCheck_CheckedChanged);
			// 
			// MarkerStyleButton
			// 
			this.MarkerStyleButton.Location = new System.Drawing.Point(5, 225);
			this.MarkerStyleButton.Name = "MarkerStyleButton";
			this.MarkerStyleButton.Size = new System.Drawing.Size(169, 24);
			this.MarkerStyleButton.TabIndex = 8;
			this.MarkerStyleButton.Text = "Marker Style...";
			this.MarkerStyleButton.Click += new System.EventHandler(this.MarkerStyleButton_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(5, 113);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(169, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Line Size:";
			// 
			// LineSizeScroll
			// 
			this.LineSizeScroll.Location = new System.Drawing.Point(5, 129);
			this.LineSizeScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.LineSizeScroll.Name = "LineSizeScroll";
			this.LineSizeScroll.Size = new System.Drawing.Size(169, 16);
			this.LineSizeScroll.TabIndex = 5;
			this.LineSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LineSizeScroll_ValueChanged);
			// 
			// DataLabelStyleButton
			// 
			this.DataLabelStyleButton.Location = new System.Drawing.Point(5, 256);
			this.DataLabelStyleButton.Name = "DataLabelStyleButton";
			this.DataLabelStyleButton.Size = new System.Drawing.Size(169, 24);
			this.DataLabelStyleButton.TabIndex = 9;
			this.DataLabelStyleButton.Text = "Data Label Style...";
			this.DataLabelStyleButton.Click += new System.EventHandler(this.DataLabelStyleButton_Click);
			// 
			// NStandardStepLineUC
			// 
			this.Controls.Add(this.DataLabelStyleButton);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.LineSizeScroll);
			this.Controls.Add(this.MarkerStyleButton);
			this.Controls.Add(this.RoundToTickCheck);
			this.Controls.Add(this.InflateMarginsCheck);
			this.Controls.Add(this.LineFillColorButton);
			this.Controls.Add(this.BorderStyleButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.LineDepthScroll);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LineStyleCombo);
			this.Name = "NStandardStepLineUC";
			this.Size = new System.Drawing.Size(180, 364);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("3D Step Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 65;
			chart.Height = 40;
			chart.Axis(StandardAxis.Depth).Visible = false;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			m_Line = (NStepLineSeries)chart.Series.Add(SeriesType.StepLine);
			m_Line.Name = "Series 1";
			m_Line.DepthPercent = 50;
			m_Line.LineSize = 2;
			m_Line.DataLabelStyle.Visible = false;
			m_Line.DataLabelStyle.Format = "<value>";
			m_Line.MarkerStyle.Visible = true;
			m_Line.Values.FillRandom(Random, 8);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			LineStyleCombo.FillFromEnum(typeof(LineSegmentShape));
			LineStyleCombo.SelectedIndex = 1;
			RoundToTickCheck.Checked = true;
			InflateMarginsCheck.Checked = true;
		}

		private void SetupTapeMarkers(NMarkerStyle marker)
		{
			marker.PointShape = PointShape.Cylinder;
			marker.AutoDepth = true;
			marker.Width = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			marker.Height = new NLength(1.2f, NRelativeUnit.ParentPercentage);
		}

		private void SetupTubeMarkers(NMarkerStyle marker)
		{
			marker.PointShape = PointShape.Sphere;
			marker.AutoDepth = false;
			marker.Width = new NLength(3.5f, NRelativeUnit.ParentPercentage);
			marker.Height = new NLength(3.5f, NRelativeUnit.ParentPercentage);
			marker.Depth = new NLength(3.5f, NRelativeUnit.ParentPercentage);
		}

		private void LineStyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch (LineStyleCombo.SelectedIndex)
			{
				case 0: // simple line
					m_Line.LineSegmentShape = LineSegmentShape.Line; 
					LineDepthScroll.Enabled = false;
					LineSizeScroll.Enabled = false;
					LineFillColorButton.Enabled = false;
					BorderStyleButton.Enabled = true;
					SetupTapeMarkers(m_Line.MarkerStyle);
					break;

				case 1: // tape
					m_Line.LineSegmentShape = LineSegmentShape.Tape; 
					LineDepthScroll.Enabled = true;
					LineSizeScroll.Enabled = false;
					LineFillColorButton.Enabled = true;
					BorderStyleButton.Enabled = true;
					SetupTapeMarkers(m_Line.MarkerStyle);
					break;

				case 2: // tube
					m_Line.LineSegmentShape = LineSegmentShape.Tube; 
					LineDepthScroll.Enabled = false;
					LineSizeScroll.Enabled = true;
					LineFillColorButton.Enabled = true;
					BorderStyleButton.Enabled = false;
					SetupTubeMarkers(m_Line.MarkerStyle);
					break;

				case 3: // elipsoid
					m_Line.LineSegmentShape = LineSegmentShape.Ellipsoid; 
					LineDepthScroll.Enabled = false;
					LineSizeScroll.Enabled = true;
					LineFillColorButton.Enabled = true;
					BorderStyleButton.Enabled = false;
					SetupTubeMarkers(m_Line.MarkerStyle);
					break;
			}

			nChartControl1.Refresh();
		}

		private void BorderPropsButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Line.BorderStyle, out strokeStyleResult))
			{
				m_Line.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void LineDepthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Line.DepthPercent = LineDepthScroll.Value;
			nChartControl1.Refresh();
		}

		private void LineSizeScroll_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Line.LineSize = LineSizeScroll.Value / 10.0f;
			nChartControl1.Refresh();		
		}

		private void LineFillColorButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_Line.FillStyle, out fillStyleResult))
			{
				m_Line.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void InflateMarginsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Line.InflateMargins = InflateMarginsCheck.Checked;
			nChartControl1.Refresh();
		}

		private void RoundToTickCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NStandardScaleConfigurator standardScale = (NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			standardScale.RoundToTickMax = RoundToTickCheck.Checked;
			standardScale.RoundToTickMin = RoundToTickCheck.Checked;

			nChartControl1.Refresh();
		}

		private void MarkerBorderButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Line.MarkerStyle.BorderStyle, out strokeStyleResult))
			{
				m_Line.MarkerStyle.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void MarkerFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_Line.MarkerStyle.FillStyle, out fillStyleResult))
			{
				m_Line.MarkerStyle.FillStyle = fillStyleResult;
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
