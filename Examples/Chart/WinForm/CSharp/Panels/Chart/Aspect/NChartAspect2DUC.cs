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

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NChartAspect2DUC : NExampleBaseUC
	{
        private Label label2;
        private Nevron.UI.WinForm.Controls.NComboBox XProportionCombo;
        private Label label1;
        private Label label3;
        private Nevron.UI.WinForm.Controls.NComboBox YProportionCombo;
        private Nevron.UI.WinForm.Controls.NCheckBox UsePlotAspectCheckBox;
        private Nevron.UI.WinForm.Controls.NCheckBox ShowContentAreaCheckBox;
		private Label label4;
		private UI.WinForm.Controls.NComboBox FitAxisContentModeComboBox;
		private System.ComponentModel.Container components = null;

		public NChartAspect2DUC()
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
			this.UsePlotAspectCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowContentAreaCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.FitAxisContentModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 14);
			this.label2.TabIndex = 3;
			this.label2.Text = "Proportion:";
			// 
			// XProportionCombo
			// 
			this.XProportionCombo.ListProperties.CheckBoxDataMember = "";
			this.XProportionCombo.ListProperties.DataSource = null;
			this.XProportionCombo.ListProperties.DisplayMember = "";
			this.XProportionCombo.Location = new System.Drawing.Point(41, 96);
			this.XProportionCombo.Name = "XProportionCombo";
			this.XProportionCombo.Size = new System.Drawing.Size(118, 21);
			this.XProportionCombo.TabIndex = 5;
			this.XProportionCombo.SelectedIndexChanged += new System.EventHandler(this.XProportionCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 103);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 14);
			this.label1.TabIndex = 4;
			this.label1.Text = "X:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 130);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 14);
			this.label3.TabIndex = 6;
			this.label3.Text = "Y:";
			// 
			// YProportionCombo
			// 
			this.YProportionCombo.ListProperties.CheckBoxDataMember = "";
			this.YProportionCombo.ListProperties.DataSource = null;
			this.YProportionCombo.ListProperties.DisplayMember = "";
			this.YProportionCombo.Location = new System.Drawing.Point(41, 123);
			this.YProportionCombo.Name = "YProportionCombo";
			this.YProportionCombo.Size = new System.Drawing.Size(118, 21);
			this.YProportionCombo.TabIndex = 7;
			this.YProportionCombo.SelectedIndexChanged += new System.EventHandler(this.YProportionCombo_SelectedIndexChanged);
			// 
			// UsePlotAspectCheckBox
			// 
			this.UsePlotAspectCheckBox.ButtonProperties.BorderOffset = 2;
			this.UsePlotAspectCheckBox.Location = new System.Drawing.Point(8, 51);
			this.UsePlotAspectCheckBox.Name = "UsePlotAspectCheckBox";
			this.UsePlotAspectCheckBox.Size = new System.Drawing.Size(157, 21);
			this.UsePlotAspectCheckBox.TabIndex = 2;
			this.UsePlotAspectCheckBox.Text = "Use Plot Aspect";
			this.UsePlotAspectCheckBox.CheckedChanged += new System.EventHandler(this.UsePlotAspectCheckBox_CheckedChanged);
			// 
			// ShowContentAreaCheckBox
			// 
			this.ShowContentAreaCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowContentAreaCheckBox.Location = new System.Drawing.Point(8, 150);
			this.ShowContentAreaCheckBox.Name = "ShowContentAreaCheckBox";
			this.ShowContentAreaCheckBox.Size = new System.Drawing.Size(157, 21);
			this.ShowContentAreaCheckBox.TabIndex = 8;
			this.ShowContentAreaCheckBox.Text = "Show Content Area";
			this.ShowContentAreaCheckBox.CheckedChanged += new System.EventHandler(this.ShowContentAreaCheckBox_CheckedChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(113, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Fit Axis Content Mode:";
			// 
			// FitAxisContentModeComboBox
			// 
			this.FitAxisContentModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.FitAxisContentModeComboBox.ListProperties.DataSource = null;
			this.FitAxisContentModeComboBox.ListProperties.DisplayMember = "";
			this.FitAxisContentModeComboBox.Location = new System.Drawing.Point(8, 24);
			this.FitAxisContentModeComboBox.Name = "FitAxisContentModeComboBox";
			this.FitAxisContentModeComboBox.Size = new System.Drawing.Size(151, 21);
			this.FitAxisContentModeComboBox.TabIndex = 1;
			this.FitAxisContentModeComboBox.SelectedIndexChanged += new System.EventHandler(this.FitAxisContentModeComboBox_SelectedIndexChanged);
			// 
			// NChartAspect2DUC
			// 
			this.Controls.Add(this.FitAxisContentModeComboBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ShowContentAreaCheckBox);
			this.Controls.Add(this.UsePlotAspectCheckBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.YProportionCombo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.XProportionCombo);
			this.Name = "NChartAspect2DUC";
			this.Size = new System.Drawing.Size(180, 370);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

            // set a chart title
            NLabel title = new NLabel("Chart Aspect 2D");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            title.DockMode = PanelDockMode.Top;
            title.Margins = new NMarginsL(10, 10, 10, 0);
            nChartControl1.Panels.Add(title);

            NCartesianChart chart = new NCartesianChart();
            nChartControl1.Panels.Add(chart);

            chart.DockMode = PanelDockMode.Fill;
            chart.Margins = new NMarginsL(new NLength(30));
            chart.Padding = new NMarginsL(0);
            chart.BoundsMode = BoundsMode.Stretch;
            chart.UsePlotAspect = true;
            chart.Width = chart.Height = 50;
            
            // switch all axes to linear mode
            NLinearScaleConfigurator xScale = new NLinearScaleConfigurator();
            xScale.Title.Text = "X Scale Title";
            xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            xScale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.View, 90, false);
            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale;

            NLinearScaleConfigurator yScale = new NLinearScaleConfigurator();
            yScale.Title.Text = "Y Scale Title";
            yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = yScale;

            chart.Axis(StandardAxis.SecondaryX).ScaleConfigurator = new NLinearScaleConfigurator();
            chart.Axis(StandardAxis.SecondaryY).ScaleConfigurator = new NLinearScaleConfigurator();

            // cross secondary X and Y axes
            chart.Axis(StandardAxis.SecondaryX).Anchor = new NCrossAxisAnchor(AxisOrientation.Horizontal, new NValueAxisCrossing(chart.Axis(StandardAxis.PrimaryY), 0));
            chart.Axis(StandardAxis.SecondaryY).Anchor = new NCrossAxisAnchor(AxisOrientation.Vertical, new NValueAxisCrossing(chart.Axis(StandardAxis.PrimaryX), 0));

            // show secondary axes
            chart.Axis(StandardAxis.SecondaryX).Visible = true;
            chart.Axis(StandardAxis.SecondaryY).Visible = true;

            // turn off labels for cross axes
			NLinearScaleConfigurator secondaryScaleX = chart.Axis(StandardAxis.SecondaryX).ScaleConfigurator as NLinearScaleConfigurator;
			secondaryScaleX.AutoLabels = false;

			NLinearScaleConfigurator secondaryScaleY = chart.Axis(StandardAxis.SecondaryY).ScaleConfigurator as NLinearScaleConfigurator;
			secondaryScaleY.AutoLabels = false;

            // add some dummy data
            NPointSeries point = new NPointSeries();
            chart.Series.Add(point);
            point.DataLabelStyle.Visible = false;
            point.UseXValues = true;

            point.DisplayOnAxis((int)StandardAxis.SecondaryX, true);
            point.DisplayOnAxis((int)StandardAxis.SecondaryY, true);
            point.Size = new NLength(1);
            point.BorderStyle.Width = new NLength(0);
            point.ClusterMode = ClusterMode.Enabled;

            // add some random data in the range [-100, 100]
            Random rand = new Random();

            for (int i = 0; i < 3000; i++)
            {
                point.Values.Add(rand.Next(200) - 100);
                point.XValues.Add(rand.Next(200) - 100);
            }

            // init form controls
            for (int i = 1; i <= 5; i++)
            {
                XProportionCombo.Items.Add(i.ToString());
                YProportionCombo.Items.Add(i.ToString());
            }
			FitAxisContentModeComboBox.FillFromEnum(typeof(Fit2DAxisContentMode));

			FitAxisContentModeComboBox.SelectedIndex = (int)chart.Fit2DAxisContentMode;
			XProportionCombo.SelectedIndex = 0;
            YProportionCombo.SelectedIndex = 0;

			UsePlotAspectCheckBox.Checked = false;
            ShowContentAreaCheckBox.Checked = true;
 		}

        private void UpdateChart()
        {
            NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];

            chart.DisableContentAreaPixelSnapping = true;

            chart.Width = (XProportionCombo.SelectedIndex + 1) * 10;
            chart.Height = (YProportionCombo.SelectedIndex + 1) * 10;
            chart.UsePlotAspect = UsePlotAspectCheckBox.Checked;

            if (ShowContentAreaCheckBox.Checked)
            {
                chart.BorderStyle = new NStrokeBorderStyle();
            }
            else
            {
                chart.BorderStyle = null;
            }

            chart.Fit2DAxisContentMode = (Fit2DAxisContentMode)FitAxisContentModeComboBox.SelectedIndex;

			bool fit2DAxisContent = chart.Fit2DAxisContentMode != Fit2DAxisContentMode.Disabled;
			
			XProportionCombo.Enabled = fit2DAxisContent && UsePlotAspectCheckBox.Checked;
            YProportionCombo.Enabled = fit2DAxisContent && UsePlotAspectCheckBox.Checked;
            UsePlotAspectCheckBox.Enabled = fit2DAxisContent;

            nChartControl1.Refresh();
        }

        private void XProportionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void YProportionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void UsePlotAspectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void ShowContentAreaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void FitAxisContentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }

		private void FitAxisContentModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateChart();
		}
	}
}
