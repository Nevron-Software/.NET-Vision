using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NShapeXYZScatterBubbleUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NShapeSeries m_Shape;
		private Nevron.UI.WinForm.Controls.NButton Bubble1FillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton Bubble2FillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton Bubble3FillStyleButton;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox StyleCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox InflateMarginsCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox AxesRoundToTickCheck;
		private Nevron.UI.WinForm.Controls.NButton ChangeXValues;
		private Nevron.UI.WinForm.Controls.NButton ChangeZValues;
		private Nevron.UI.WinForm.Controls.NButton ChangeYValues;
		private System.ComponentModel.Container components = null;

		public NShapeXYZScatterBubbleUC()
		{
			InitializeComponent();

			StyleCombo.FillFromEnum(typeof(BarShape));
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
			this.Bubble1FillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.Bubble2FillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.Bubble3FillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.StyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.InflateMarginsCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.AxesRoundToTickCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ChangeXValues = new Nevron.UI.WinForm.Controls.NButton();
			this.ChangeZValues = new Nevron.UI.WinForm.Controls.NButton();
			this.ChangeYValues = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// Bubble1FillStyleButton
			// 
			this.Bubble1FillStyleButton.Location = new System.Drawing.Point(5, 9);
			this.Bubble1FillStyleButton.Name = "Bubble1FillStyleButton";
			this.Bubble1FillStyleButton.Size = new System.Drawing.Size(171, 26);
			this.Bubble1FillStyleButton.TabIndex = 0;
			this.Bubble1FillStyleButton.Text = "Bubble1 Fill Style...";
			this.Bubble1FillStyleButton.Click += new System.EventHandler(this.Bubble1FillStyleButton_Click);
			// 
			// Bubble2FillStyleButton
			// 
			this.Bubble2FillStyleButton.Location = new System.Drawing.Point(5, 40);
			this.Bubble2FillStyleButton.Name = "Bubble2FillStyleButton";
			this.Bubble2FillStyleButton.Size = new System.Drawing.Size(171, 26);
			this.Bubble2FillStyleButton.TabIndex = 1;
			this.Bubble2FillStyleButton.Text = "Bubble2 Fill Style...";
			this.Bubble2FillStyleButton.Click += new System.EventHandler(this.Bubble2FillStyleButton_Click);
			// 
			// Bubble3FillStyleButton
			// 
			this.Bubble3FillStyleButton.Location = new System.Drawing.Point(5, 71);
			this.Bubble3FillStyleButton.Name = "Bubble3FillStyleButton";
			this.Bubble3FillStyleButton.Size = new System.Drawing.Size(171, 26);
			this.Bubble3FillStyleButton.TabIndex = 2;
			this.Bubble3FillStyleButton.Text = "Bubble3 Fill Style...";
			this.Bubble3FillStyleButton.Click += new System.EventHandler(this.Bubble3FillStyleButton_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 115);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(171, 18);
			this.label1.TabIndex = 4;
			this.label1.Text = "Bubbles Shape:";
			// 
			// StyleCombo
			// 
			this.StyleCombo.ListProperties.CheckBoxDataMember = "";
			this.StyleCombo.ListProperties.DataSource = null;
			this.StyleCombo.ListProperties.DisplayMember = "";
			this.StyleCombo.Location = new System.Drawing.Point(5, 140);
			this.StyleCombo.Name = "StyleCombo";
			this.StyleCombo.Size = new System.Drawing.Size(171, 21);
			this.StyleCombo.TabIndex = 5;
			this.StyleCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			// 
			// InflateMarginsCheckBox
			// 
			this.InflateMarginsCheckBox.ButtonProperties.BorderOffset = 2;
			this.InflateMarginsCheckBox.Location = new System.Drawing.Point(5, 280);
			this.InflateMarginsCheckBox.Name = "InflateMarginsCheckBox";
			this.InflateMarginsCheckBox.Size = new System.Drawing.Size(171, 24);
			this.InflateMarginsCheckBox.TabIndex = 6;
			this.InflateMarginsCheckBox.Text = "Inflate Margins";
			this.InflateMarginsCheckBox.CheckedChanged += new System.EventHandler(this.InflateMarginsCheckBox_CheckedChanged);
			// 
			// AxesRoundToTickCheck
			// 
			this.AxesRoundToTickCheck.ButtonProperties.BorderOffset = 2;
			this.AxesRoundToTickCheck.Location = new System.Drawing.Point(5, 309);
			this.AxesRoundToTickCheck.Name = "AxesRoundToTickCheck";
			this.AxesRoundToTickCheck.Size = new System.Drawing.Size(171, 24);
			this.AxesRoundToTickCheck.TabIndex = 7;
			this.AxesRoundToTickCheck.Text = "Axes Round To Tick";
			this.AxesRoundToTickCheck.CheckedChanged += new System.EventHandler(this.AxesRoundToTickCheck_CheckedChanged);
			// 
			// ChangeXValues
			// 
			this.ChangeXValues.Location = new System.Drawing.Point(5, 178);
			this.ChangeXValues.Name = "ChangeXValues";
			this.ChangeXValues.Size = new System.Drawing.Size(171, 26);
			this.ChangeXValues.TabIndex = 8;
			this.ChangeXValues.Text = "Change X Values";
			this.ChangeXValues.Click += new System.EventHandler(this.ChangeXValues_Click);
			// 
			// ChangeZValues
			// 
			this.ChangeZValues.Location = new System.Drawing.Point(5, 209);
			this.ChangeZValues.Name = "ChangeZValues";
			this.ChangeZValues.Size = new System.Drawing.Size(171, 26);
			this.ChangeZValues.TabIndex = 9;
			this.ChangeZValues.Text = "Change Z Values";
			this.ChangeZValues.Click += new System.EventHandler(this.ChangeZValues_Click);
			// 
			// ChangeYValues
			// 
			this.ChangeYValues.Location = new System.Drawing.Point(5, 240);
			this.ChangeYValues.Name = "ChangeYValues";
			this.ChangeYValues.Size = new System.Drawing.Size(171, 26);
			this.ChangeYValues.TabIndex = 10;
			this.ChangeYValues.Text = "Change Y Values";
			this.ChangeYValues.Click += new System.EventHandler(this.ChangeYValues_Click);
			// 
			// NShapeXYZScatterBubbleUC
			// 
			this.Controls.Add(this.ChangeYValues);
			this.Controls.Add(this.ChangeZValues);
			this.Controls.Add(this.ChangeXValues);
			this.Controls.Add(this.AxesRoundToTickCheck);
			this.Controls.Add(this.InflateMarginsCheckBox);
			this.Controls.Add(this.StyleCombo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Bubble3FillStyleButton);
			this.Controls.Add(this.Bubble2FillStyleButton);
			this.Controls.Add(this.Bubble1FillStyleButton);
			this.Name = "NShapeXYZScatterBubbleUC";
			this.Size = new System.Drawing.Size(180, 343);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XYZ Scatter Bubbles");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// chart settings
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
            m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
            m_Chart.Projection.Elevation -= 10;
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			m_Chart.Depth = 55.0f;
			m_Chart.Width = 55.0f;
			m_Chart.Height = 55.0f;

			// switch the PrimaryX and Depth axes in numeric mode in order to correctly scale the custom X and Z positions
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

            // add interlaced stripe 
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            linearScale.StripStyles.Add(stripStyle);

			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);

			// create the shape series
			m_Shape = (NShapeSeries)m_Chart.Series.Add(SeriesType.Shape);
			m_Shape.DataLabelStyle.Visible = false;
			m_Shape.DataLabelStyle.Format = "<ysize> <label>"; 

			// show information about the data points in the legend
			m_Shape.Legend.Mode = SeriesLegendMode.DataPoints; 

			// show the Y size and label in the legend
			m_Shape.Legend.Format = "<ysize> <label>"; 

			// use custom X positions
			m_Shape.UseXValues = true;

			// use custom Z positions
			m_Shape.UseZValues = true;

			// X sizes are specified in Model units (the default is Scale)
			// they will not depend on the X axis scale
			m_Shape.XSizesUnits = MeasurementUnits.Model;

			// Z sizes are specified in Model units (the default is Scale)
			// they will not depend on the Z axis scale
			m_Shape.ZSizesUnits = MeasurementUnits.Model;

			// Y sizes are specified in Model units (the default is Scale)
			// they will not depend on the Y axis scale
			m_Shape.YSizesUnits = MeasurementUnits.Model;

			// this will require to set the InflateMargins flag to true since in this mode
			// scale is determined only by the X positions of the shape and will not take 
			// into account the size of the bubbles.
			m_Shape.InflateMargins = true;

			// add the bubbles
			m_Shape.AddDataPoint(new NShapeDataPoint(10, 12, 56, 24, 24, 24, "bubble1"));
			m_Shape.AddDataPoint(new NShapeDataPoint(20, 14, 12, 10, 10, 10, "bubble2"));
			m_Shape.AddDataPoint(new NShapeDataPoint(15, 50, 45, 19, 19, 19, "bubble3"));

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			AxesRoundToTickCheck.Checked = true;
			InflateMarginsCheckBox.Checked = true;
			StyleCombo.SelectedIndex = 6;
		}

		private void Bubble1FillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult = null;

			if (NFillStyleTypeEditor.Edit((NFillStyle)m_Shape.FillStyles[0], out fillStyleResult))
			{
				m_Shape.FillStyles[0] = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void Bubble2FillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult = null;

			if (NFillStyleTypeEditor.Edit(((NFillStyle)m_Shape.FillStyles[1]), out fillStyleResult))
			{
				m_Shape.FillStyles[1] = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void Bubble3FillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult = null;

			if (NFillStyleTypeEditor.Edit(((NFillStyle)m_Shape.FillStyles[2]), out fillStyleResult))
			{
				m_Shape.FillStyles[2] = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void StyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Shape.Shape = (BarShape)StyleCombo.SelectedIndex;
			nChartControl1.Refresh();
		}
		private void InflateMarginsCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Shape.InflateMargins = InflateMarginsCheckBox.Checked;
			nChartControl1.Refresh();
		}
		private void AxesRoundToTickCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;

			linearScale.RoundToTickMin = AxesRoundToTickCheck.Checked;
			linearScale.RoundToTickMax = AxesRoundToTickCheck.Checked;

			linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			linearScale.RoundToTickMin = AxesRoundToTickCheck.Checked;
			linearScale.RoundToTickMax = AxesRoundToTickCheck.Checked;

			linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator;

			linearScale.RoundToTickMin = AxesRoundToTickCheck.Checked;
			linearScale.RoundToTickMax = AxesRoundToTickCheck.Checked;
			
			nChartControl1.Refresh();
		}
		private void ChangeXValues_Click(object sender, System.EventArgs e)
		{
			m_Shape.XValues.FillRandom(Random, 3);
			nChartControl1.Refresh();
		}
		private void ChangeZValues_Click(object sender, System.EventArgs e)
		{
			m_Shape.ZValues.FillRandom(Random, 3);
			nChartControl1.Refresh();
		}
		private void ChangeYValues_Click(object sender, System.EventArgs e)
		{
			m_Shape.Values.FillRandom(Random, 3);
			nChartControl1.Refresh();
		}
	}
}
