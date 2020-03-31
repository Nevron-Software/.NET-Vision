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
	public class NShapeXYZScatterBarsUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NShapeSeries m_Shape;
		private Nevron.UI.WinForm.Controls.NButton Bar1FillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton Bar2FillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton Bar3FillStyleButton;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox StyleCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox InflateMarginsCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox AxesRoundToTickCheck;
		private Nevron.UI.WinForm.Controls.NButton ChangeXValues;
		private Nevron.UI.WinForm.Controls.NButton ChangeZValues;
		private System.ComponentModel.Container components = null;

		public NShapeXYZScatterBarsUC()
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
			this.Bar1FillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.Bar2FillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.Bar3FillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.StyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.InflateMarginsCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.AxesRoundToTickCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ChangeXValues = new Nevron.UI.WinForm.Controls.NButton();
			this.ChangeZValues = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// Bar1FillStyleButton
			// 
			this.Bar1FillStyleButton.Location = new System.Drawing.Point(5, 10);
			this.Bar1FillStyleButton.Name = "Bar1FillStyleButton";
			this.Bar1FillStyleButton.Size = new System.Drawing.Size(170, 26);
			this.Bar1FillStyleButton.TabIndex = 0;
			this.Bar1FillStyleButton.Text = "Bar1 Fill Style...";
			this.Bar1FillStyleButton.Click += new System.EventHandler(this.Bar1FillStyleButton_Click);
			// 
			// Bar2FillStyleButton
			// 
			this.Bar2FillStyleButton.Location = new System.Drawing.Point(5, 41);
			this.Bar2FillStyleButton.Name = "Bar2FillStyleButton";
			this.Bar2FillStyleButton.Size = new System.Drawing.Size(170, 26);
			this.Bar2FillStyleButton.TabIndex = 1;
			this.Bar2FillStyleButton.Text = "Bar2 Fill Style...";
			this.Bar2FillStyleButton.Click += new System.EventHandler(this.Bar2FillStyleButton_Click);
			// 
			// Bar3FillStyleButton
			// 
			this.Bar3FillStyleButton.Location = new System.Drawing.Point(5, 72);
			this.Bar3FillStyleButton.Name = "Bar3FillStyleButton";
			this.Bar3FillStyleButton.Size = new System.Drawing.Size(170, 26);
			this.Bar3FillStyleButton.TabIndex = 2;
			this.Bar3FillStyleButton.Text = "Bar3 Fill Style...";
			this.Bar3FillStyleButton.Click += new System.EventHandler(this.Bar3FillStyleButton_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 108);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(170, 18);
			this.label1.TabIndex = 3;
			this.label1.Text = "Bars Shape:";
			// 
			// StyleCombo
			// 
			this.StyleCombo.ListProperties.CheckBoxDataMember = "";
			this.StyleCombo.ListProperties.DataSource = null;
			this.StyleCombo.ListProperties.DisplayMember = "";
			this.StyleCombo.Location = new System.Drawing.Point(5, 125);
			this.StyleCombo.Name = "StyleCombo";
			this.StyleCombo.Size = new System.Drawing.Size(170, 21);
			this.StyleCombo.TabIndex = 4;
			this.StyleCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			// 
			// InflateMarginsCheckBox
			// 
			this.InflateMarginsCheckBox.ButtonProperties.BorderOffset = 2;
			this.InflateMarginsCheckBox.Location = new System.Drawing.Point(5, 222);
			this.InflateMarginsCheckBox.Name = "InflateMarginsCheckBox";
			this.InflateMarginsCheckBox.Size = new System.Drawing.Size(170, 24);
			this.InflateMarginsCheckBox.TabIndex = 7;
			this.InflateMarginsCheckBox.Text = "Inflate Margins";
			this.InflateMarginsCheckBox.CheckedChanged += new System.EventHandler(this.InflateMarginsCheckBox_CheckedChanged);
			// 
			// AxesRoundToTickCheck
			// 
			this.AxesRoundToTickCheck.ButtonProperties.BorderOffset = 2;
			this.AxesRoundToTickCheck.Location = new System.Drawing.Point(5, 251);
			this.AxesRoundToTickCheck.Name = "AxesRoundToTickCheck";
			this.AxesRoundToTickCheck.Size = new System.Drawing.Size(170, 24);
			this.AxesRoundToTickCheck.TabIndex = 8;
			this.AxesRoundToTickCheck.Text = "Axes Round To Tick";
			this.AxesRoundToTickCheck.CheckedChanged += new System.EventHandler(this.AxesRoundToTickCheck_CheckedChanged);
			// 
			// ChangeXValues
			// 
			this.ChangeXValues.Location = new System.Drawing.Point(5, 160);
			this.ChangeXValues.Name = "ChangeXValues";
			this.ChangeXValues.Size = new System.Drawing.Size(170, 23);
			this.ChangeXValues.TabIndex = 5;
			this.ChangeXValues.Text = "Change X Values";
			this.ChangeXValues.Click += new System.EventHandler(this.ChangeXValues_Click);
			// 
			// ChangeZValues
			// 
			this.ChangeZValues.Location = new System.Drawing.Point(5, 189);
			this.ChangeZValues.Name = "ChangeZValues";
			this.ChangeZValues.Size = new System.Drawing.Size(170, 23);
			this.ChangeZValues.TabIndex = 6;
			this.ChangeZValues.Text = "Change Z Values";
			this.ChangeZValues.Click += new System.EventHandler(this.ChangeZValues_Click);
			// 
			// NShapeXYZScatterBarsUC
			// 
			this.Controls.Add(this.ChangeZValues);
			this.Controls.Add(this.ChangeXValues);
			this.Controls.Add(this.AxesRoundToTickCheck);
			this.Controls.Add(this.InflateMarginsCheckBox);
			this.Controls.Add(this.StyleCombo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Bar3FillStyleButton);
			this.Controls.Add(this.Bar2FillStyleButton);
			this.Controls.Add(this.Bar1FillStyleButton);
			this.Name = "NShapeXYZScatterBarsUC";
			this.Size = new System.Drawing.Size(180, 296);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XYZ Bars");
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

			// show information about the data points in the legend
			m_Shape.Legend.Mode = SeriesLegendMode.DataPoints; 

			// show the Y size and label in the legend
			m_Shape.Legend.Format = "<ysize> <label>"; 

			// show the Y size and label in the data point labels
			m_Shape.DataLabelStyle.Format = "<ysize> <label>"; 

			// use custom X positions
			m_Shape.UseXValues = true;

			// use custom Z positions
			m_Shape.UseZValues = true;

			// X sizes are specified in Model units (the default is Scale)
			// this will make the bars size independant from the scale of the X axis 
			m_Shape.XSizesUnits = MeasurementUnits.Model;

			// Z sizes are specified in Model units (the default is Scale)
			// this will make the bars size independant from the scale of the Z axis 
			m_Shape.ZSizesUnits = MeasurementUnits.Model;

			// this will require to set the InflateMargins flag to true since in this mode
			// scale is determined only by the X positions of the shape and will not take 
			// into account the size of the bars.
			m_Shape.InflateMargins = true;

			// add the bars
			// add Bar1
			m_Shape.AddDataPoint(new NShapeDataPoint(
				20, // Y center of bar -> half its Y size
				12, // X position
				56, // Z position
				10, // X size - 10 model units
				40, // Y size of bar
				10, // Z size - 10 model units
				"Bar1" // label
				));

			// add Bar2
			m_Shape.AddDataPoint(new NShapeDataPoint(
				8, // Y center of bar -> half its Y size
				24, // X position
				12, // Z position
				10, // X size - 10 model units
				16, // Y size of bar
				10, // Z size - 10 model units
				"Bar2" // label
				));

			// add Bar3
			m_Shape.AddDataPoint(new NShapeDataPoint(
				15, // Y center of bar -> half its Y size
				50, // X position
				30, // Z position
				10, // X size - 10 model units
				30, // Y size of bar
				10, // Z size - 10 model units
				"Bar3" // label
				));

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			InflateMarginsCheckBox.Checked = true;
			AxesRoundToTickCheck.Checked = true;
			StyleCombo.SelectedIndex = 0;
		}

		private void Bar1FillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult = null;

			if(NFillStyleTypeEditor.Edit((NFillStyle)m_Shape.FillStyles[0], out fillStyleResult))
			{
				m_Shape.FillStyles[0] = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void Bar2FillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult = null;

			if(NFillStyleTypeEditor.Edit((NFillStyle)m_Shape.FillStyles[1], out fillStyleResult))
			{
				m_Shape.FillStyles[1] = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void Bar3FillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult = null;

			if(NFillStyleTypeEditor.Edit((NFillStyle)m_Shape.FillStyles[2], out fillStyleResult))
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
	}
}