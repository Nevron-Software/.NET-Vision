using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Resources;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NChartAspect3DUC : NExampleBaseUC
	{
        private Label label2;
        private Nevron.UI.WinForm.Controls.NComboBox XProportionCombo;
        private Label label1;
        private Label label3;
        private Nevron.UI.WinForm.Controls.NComboBox YProportionCombo;
        private Nevron.UI.WinForm.Controls.NCheckBox FitAxisContentCheckBox;
        private Label label4;
        private Nevron.UI.WinForm.Controls.NComboBox ZProportionCombo;
        private Nevron.UI.WinForm.Controls.NCheckBox ShowContentAreaCheckBox;
		private System.ComponentModel.Container components = null;

		public NChartAspect3DUC()
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
			this.label2 = new System.Windows.Forms.Label();
			this.XProportionCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.YProportionCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.FitAxisContentCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.ZProportionCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.ShowContentAreaCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(11, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 14);
			this.label2.TabIndex = 6;
			this.label2.Text = "Proportion:";
			// 
			// XProportionCombo
			// 
			this.XProportionCombo.ListProperties.CheckBoxDataMember = "";
			this.XProportionCombo.ListProperties.DataSource = null;
			this.XProportionCombo.ListProperties.DisplayMember = "";
			this.XProportionCombo.Location = new System.Drawing.Point(47, 35);
			this.XProportionCombo.Name = "XProportionCombo";
			this.XProportionCombo.Size = new System.Drawing.Size(121, 21);
			this.XProportionCombo.TabIndex = 5;
			this.XProportionCombo.SelectedIndexChanged += new System.EventHandler(this.XProportionCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(11, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 14);
			this.label1.TabIndex = 7;
			this.label1.Text = "X:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(11, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 14);
			this.label3.TabIndex = 9;
			this.label3.Text = "Y:";
			// 
			// YProportionCombo
			// 
			this.YProportionCombo.ListProperties.CheckBoxDataMember = "";
			this.YProportionCombo.ListProperties.DataSource = null;
			this.YProportionCombo.ListProperties.DisplayMember = "";
			this.YProportionCombo.Location = new System.Drawing.Point(47, 62);
			this.YProportionCombo.Name = "YProportionCombo";
			this.YProportionCombo.Size = new System.Drawing.Size(121, 21);
			this.YProportionCombo.TabIndex = 8;
			this.YProportionCombo.SelectedIndexChanged += new System.EventHandler(this.YProportionCombo_SelectedIndexChanged);
			// 
			// FitAxisContentCheckBox
			// 
			this.FitAxisContentCheckBox.ButtonProperties.BorderOffset = 2;
			this.FitAxisContentCheckBox.Location = new System.Drawing.Point(11, 126);
			this.FitAxisContentCheckBox.Name = "FitAxisContentCheckBox";
			this.FitAxisContentCheckBox.Size = new System.Drawing.Size(157, 21);
			this.FitAxisContentCheckBox.TabIndex = 10;
			this.FitAxisContentCheckBox.Text = "Fit Axis Content";
			this.FitAxisContentCheckBox.CheckedChanged += new System.EventHandler(this.Fit3DAxisContentCheckBox_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(11, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 14);
			this.label4.TabIndex = 12;
			this.label4.Text = "Z:";
			// 
			// ZProportionCombo
			// 
			this.ZProportionCombo.ListProperties.CheckBoxDataMember = "";
			this.ZProportionCombo.ListProperties.DataSource = null;
			this.ZProportionCombo.ListProperties.DisplayMember = "";
			this.ZProportionCombo.Location = new System.Drawing.Point(47, 89);
			this.ZProportionCombo.Name = "ZProportionCombo";
			this.ZProportionCombo.Size = new System.Drawing.Size(121, 21);
			this.ZProportionCombo.TabIndex = 11;
			this.ZProportionCombo.SelectedIndexChanged += new System.EventHandler(this.ZProportionCombo_SelectedIndexChanged);
			// 
			// ShowContentAreaCheckBox
			// 
			this.ShowContentAreaCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowContentAreaCheckBox.Location = new System.Drawing.Point(11, 145);
			this.ShowContentAreaCheckBox.Name = "ShowContentAreaCheckBox";
			this.ShowContentAreaCheckBox.Size = new System.Drawing.Size(157, 21);
			this.ShowContentAreaCheckBox.TabIndex = 13;
			this.ShowContentAreaCheckBox.Text = "Show Content Area";
			this.ShowContentAreaCheckBox.CheckedChanged += new System.EventHandler(this.ShowContentAreaCheckBox_CheckedChanged);
			// 
			// NChartAspect3DUC
			// 
			this.Controls.Add(this.ShowContentAreaCheckBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ZProportionCombo);
			this.Controls.Add(this.FitAxisContentCheckBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.YProportionCombo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.XProportionCombo);
			this.Name = "NChartAspect3DUC";
			this.Size = new System.Drawing.Size(180, 238);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

            nChartControl1.Controller.Tools.Add(new NTrackballTool());

            nChartControl1.Panels.Clear();

            // set a chart title
            NLabel title = new NLabel("Chart Aspect 3D");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            title.DockMode = PanelDockMode.Top;
            title.Margins = new NMarginsL(10, 10, 10, 0);
            nChartControl1.Panels.Add(title);


            // setup chart
            NCartesianChart chart = new NCartesianChart();
            nChartControl1.Panels.Add(chart);

            chart.DockMode = PanelDockMode.Fill;
            chart.Margins = new NMarginsL(new NLength(10));
            chart.Padding = new NMarginsL(2);

            chart.Enable3D = true;
            chart.Width = 50;
            chart.Height = 50;
            chart.Depth = 50;
            chart.BoundsMode = BoundsMode.Fit;
            chart.ContentAlignment = ContentAlignment.BottomRight;
            chart.Location = new NPointL(new NLength(15, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
            chart.Size = new NSizeL(new NLength(70, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
            chart.Wall(ChartWallType.Back).Width = 0.01f;
            chart.Wall(ChartWallType.Floor).Width = 0.01f;
            chart.Wall(ChartWallType.Left).Width = 0.01f;

            // apply predefined projection and lighting
            chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight);

            // add axis labels
            NOrdinalScaleConfigurator ordinalScale = chart.Axis(StandardAxis.Depth).ScaleConfigurator as NOrdinalScaleConfigurator;
            ordinalScale.AutoLabels = false;
            ordinalScale.Labels.Add("Miami");
            ordinalScale.Labels.Add("Chicago");
            ordinalScale.Labels.Add("Los Angeles");
            ordinalScale.Labels.Add("New York");
            ordinalScale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);

            ordinalScale = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

            // add interlace stripe to the Y axis
            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

            int barsCount = 7;

            // add the first bar
            NBarSeries bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            bar1.MultiBarMode = MultiBarMode.Series;
            bar1.Name = "Bar1";
            bar1.DataLabelStyle.Visible = false;
            bar1.BorderStyle.Color = Color.FromArgb(210, 210, 255);

            // add the second bar
            NBarSeries bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            bar2.MultiBarMode = MultiBarMode.Series;
            bar2.Name = "Bar2";
            bar2.DataLabelStyle.Visible = false;
            bar2.BorderStyle.Color = Color.FromArgb(210, 255, 210);

            // add the third bar
            NBarSeries bar3 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            bar3.MultiBarMode = MultiBarMode.Series;
            bar3.Name = "Bar3";
            bar3.DataLabelStyle.Visible = false;
            bar3.BorderStyle.Color = Color.FromArgb(255, 255, 210);

            // add the second bar
            NBarSeries bar4 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            bar4.MultiBarMode = MultiBarMode.Series;
            bar4.Name = "Bar4";
            bar4.DataLabelStyle.Visible = false;
            bar4.BorderStyle.Color = Color.FromArgb(255, 210, 210);

            // fill with random data
            bar1.Values.FillRandomRange(Random, barsCount, 10, 40);
            bar2.Values.FillRandomRange(Random, barsCount, 30, 60);
            bar3.Values.FillRandomRange(Random, barsCount, 50, 80);
            bar4.Values.FillRandomRange(Random, barsCount, 70, 100);

            // setup trackball interactivity
            nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
            nChartControl1.Controller.Tools.Add(new NTrackballTool());

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

            // init form controls
            for (int i = 1; i <= 5; i++)
            {
                XProportionCombo.Items.Add(i.ToString());
                YProportionCombo.Items.Add(i.ToString());
                ZProportionCombo.Items.Add(i.ToString());
            }

            XProportionCombo.SelectedIndex = 0;
            YProportionCombo.SelectedIndex = 0;
            ZProportionCombo.SelectedIndex = 0;

            FitAxisContentCheckBox.Checked = true;
            ShowContentAreaCheckBox.Checked = false;
 		}

        private void UpdateProportions()
        {
            NChart chart = nChartControl1.Charts[0];

            chart.Width = (XProportionCombo.SelectedIndex + 1);
            chart.Height = (YProportionCombo.SelectedIndex + 1);
            chart.Depth = (ZProportionCombo.SelectedIndex + 1);

            float max = Math.Max(Math.Max(chart.Width, chart.Height), chart.Depth);

            float scale = 50 / max;

            chart.Width *= scale;
            chart.Height *= scale;
            chart.Depth *= scale;
            
            nChartControl1.Refresh();
        }

        private void XProportionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProportions();
        }

        private void YProportionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProportions();
        }

        private void ZProportionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProportions();
        }

        private void Fit3DAxisContentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];
            chart.Fit3DAxisContent = FitAxisContentCheckBox.Checked;

            nChartControl1.Refresh();
        }

        private void ShowContentAreaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];

            if (ShowContentAreaCheckBox.Checked)
            {
                chart.BorderStyle = new NStrokeBorderStyle();
            }
            else
            {
                chart.BorderStyle = null;
            }

            nChartControl1.Refresh();
        }
	}
}
