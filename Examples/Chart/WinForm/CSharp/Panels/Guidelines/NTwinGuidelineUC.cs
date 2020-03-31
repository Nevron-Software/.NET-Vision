using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NTwinGuidelineUC : NExampleBaseUC
	{
		private NCartesianChart m_ChartFemale;
		private NCartesianChart m_ChartMale;
		private NBarSeries m_barF;
		private NBarSeries m_barM;
		private System.ComponentModel.Container components = null;
		private UI.WinForm.Controls.NCheckBox TwinChartsCheckBox;

		private string[] AgeLabels = new string[]
		{
			"0 - 4",
			"5 - 9",
			"10 - 14",
			"15 - 19",
			"20 - 24",
			"25 - 29",
			"30 - 34",
			"35 - 39",
			"40 - 44",
			"45 - 49",
			"50 - 54",
			"55 - 59",
			"60 - 64",
			"65 - 69",
			"70 - 74",
			"75 - 79",
			"80 +"
		};

		public NTwinGuidelineUC()
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
			this.TwinChartsCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// TwinChartsCheckBox
			// 
			this.TwinChartsCheckBox.ButtonProperties.BorderOffset = 2;
			this.TwinChartsCheckBox.Location = new System.Drawing.Point(3, 16);
			this.TwinChartsCheckBox.Name = "TwinChartsCheckBox";
			this.TwinChartsCheckBox.Size = new System.Drawing.Size(119, 21);
			this.TwinChartsCheckBox.TabIndex = 8;
			this.TwinChartsCheckBox.Text = "Twin Charts";
			this.TwinChartsCheckBox.CheckedChanged += new System.EventHandler(this.TwinChartsCheckBox_CheckedChanged);
			// 
			// NTwinGuidelineUC
			// 
			this.Controls.Add(this.TwinChartsCheckBox);
			this.Name = "NTwinGuidelineUC";
			this.Size = new System.Drawing.Size(180, 206);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

			// header label
			NLabel headerLabel = nChartControl1.Labels.AddHeader("Population structure of New York for 2001");
			headerLabel.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			headerLabel.ContentAlignment = ContentAlignment.MiddleCenter;
			headerLabel.TextStyle.FontStyle.Name = "Times New Roman";
			headerLabel.TextStyle.FontStyle.Style = FontStyle.Italic;
			headerLabel.DockMode = PanelDockMode.Top;
			headerLabel.Margins = new NMarginsL(10, 10, 10, 10);

			// footer label
			NLabel footerLabel = nChartControl1.Labels.AddFooter("Population (in thousands)");
			footerLabel.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			footerLabel.ContentAlignment = ContentAlignment.MiddleCenter;
            footerLabel.TextStyle.FontStyle.Name = "Times New Roman";
			footerLabel.TextStyle.FontStyle.Style = FontStyle.Italic;
			footerLabel.Margins = new NMarginsL(10, 10, 10, 10);
			footerLabel.DockMode = PanelDockMode.Bottom;

			NDockPanel containerPanel = new NDockPanel();
			containerPanel.DockMode = PanelDockMode.Fill;
			containerPanel.Margins = new NMarginsL(10, 0, 10, 0);
			nChartControl1.Panels.Add(containerPanel);

			// create male chart
			m_ChartMale = new NCartesianChart();
			m_ChartMale.BoundsMode = BoundsMode.Stretch;
			m_ChartMale.ContentAlignment  = ContentAlignment.MiddleCenter;
			m_ChartMale.DockMode = PanelDockMode.Left;
			m_ChartMale.Size = new NSizeL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(100, NRelativeUnit.ParentPercentage));
			m_ChartMale.Margins = new NMarginsL(10, 10, 0, 10);
			SetupMaleChart();
			containerPanel.ChildPanels.Add(m_ChartMale);

			// create female chart
			m_ChartFemale = new NCartesianChart();
			m_ChartFemale.BoundsMode = BoundsMode.Stretch;
			m_ChartFemale.ContentAlignment  = ContentAlignment.MiddleCenter;
			m_ChartFemale.DockMode = PanelDockMode.Left;
			m_ChartFemale.Size = new NSizeL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(100, NRelativeUnit.ParentPercentage));
			m_ChartFemale.Margins = new NMarginsL(0, 10, 10, 10);
			SetupFemaleChart();
			containerPanel.ChildPanels.Add(m_ChartFemale);

			// add twin guide line
			NTwinGuideline twinGuideLine = new NTwinGuideline();

			twinGuideLine.Side = PanelSide.Left;
			twinGuideLine.Target1 = m_ChartFemale;
			twinGuideLine.Target2 = m_ChartMale;

			nChartControl1.Document.RootPanel.Guidelines.Add(twinGuideLine);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			TwinChartsCheckBox.Checked = true;
		}

		private void SetupFemaleChart()
		{
			// female chart setup
			m_ChartFemale.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalLeft);

			// setup Y axis
			NAxis axisY = m_ChartFemale.Axis(StandardAxis.PrimaryY);
			axisY.ScaleConfigurator.InnerMajorTickStyle.Visible = false;
			axisY.Anchor = new NDockAxisAnchor(AxisDockZone.FrontRight, false, 0, 100);

			// add manual labels to the female chart
			NOrdinalScaleConfigurator ordinalScale = m_ChartFemale.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.AutoLabels = false;
			ordinalScale.MajorTickMode = MajorTickMode.CustomStep;
			ordinalScale.CustomStep = 1;

			// populate the female chart
			m_barF = (NBarSeries)m_ChartFemale.Series.Add(SeriesType.Bar);
			m_barF.BorderStyle.Color = DarkOrange;
			m_barF.DataLabelStyle.Format = "<value>";
			m_barF.DataLabelStyle.VertAlign = VertAlign.Center;
			m_barF.DataLabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 7);
			m_barF.Values.Add(210);// 0 - 4
			m_barF.Values.Add(215);// 5 - 9
			m_barF.Values.Add(219);// 10 - 14
			m_barF.Values.Add(225);// 15 - 19
			m_barF.Values.Add(245);// 20 - 24
			m_barF.Values.Add(289);// 25 - 29
			m_barF.Values.Add(355);// 30 - 34
			m_barF.Values.Add(355);// 35 - 39
			m_barF.Values.Add(380);// 40 - 44
			m_barF.Values.Add(320);// 45 - 49
			m_barF.Values.Add(250);// 50 - 54
			m_barF.Values.Add(190);// 55 - 59
			m_barF.Values.Add(112);// 60 - 64
			m_barF.Values.Add(110);// 65 - 69
			m_barF.Values.Add(90);// 70 - 74
			m_barF.Values.Add(55);// 75 - 79
			m_barF.Values.Add(45);// 80 +
		}

		private void SetupMaleChart()
		{
			// chart setup
			m_ChartMale.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalRight);

			// setup Y axis
			NAxis axisY = m_ChartMale.Axis(StandardAxis.PrimaryY);
			axisY.ScaleConfigurator.InnerMajorTickStyle.Visible = false;

			// add labels to the male chart X axis
			NAxis axisX = m_ChartMale.Axis(StandardAxis.PrimaryX);
			NOrdinalScaleConfigurator scaleX = axisX.ScaleConfigurator as NOrdinalScaleConfigurator;
			scaleX.MajorTickMode = MajorTickMode.CustomStep;
			scaleX.LabelFitModes = new LabelFitMode[] { LabelFitMode.AutoScale };
			scaleX.AutoLabels = false;
			scaleX.Labels.AddRange(AgeLabels);

			// populate the male chart
			m_barM = (NBarSeries)m_ChartMale.Series.Add(SeriesType.Bar);
			m_barM.BorderStyle.Color = GreyBlue;
			m_barM.DataLabelStyle.Format = "<value>";
			m_barM.DataLabelStyle.VertAlign = VertAlign.Center;
			m_barM.DataLabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 7);
			m_barM.Values.Add(200);// 0 - 4
			m_barM.Values.Add(210);// 5 - 9
			m_barM.Values.Add(205);// 10 - 14
			m_barM.Values.Add(225);// 15 - 19
			m_barM.Values.Add(250);// 20 - 24
			m_barM.Values.Add(290);// 25 - 29
			m_barM.Values.Add(340);// 30 - 34
			m_barM.Values.Add(340);// 35 - 39
			m_barM.Values.Add(370);// 40 - 44
			m_barM.Values.Add(310);// 45 - 49
			m_barM.Values.Add(260);// 50 - 54
			m_barM.Values.Add(180);// 55 - 59
			m_barM.Values.Add(120);// 60 - 64
			m_barM.Values.Add(115);// 65 - 69
			m_barM.Values.Add(100);// 70 - 74
			m_barM.Values.Add(50);// 75 - 79
			m_barM.Values.Add(35);// 80 +
		}

		private void TwinChartsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			nChartControl1.Document.RootPanel.Guidelines.Clear();

			if (TwinChartsCheckBox.Checked)
			{
				// add twin guide line
				NTwinGuideline twinGuideLine = new NTwinGuideline();

				twinGuideLine.Side = PanelSide.Left;
				twinGuideLine.Target1 = m_ChartFemale;
				twinGuideLine.Target2 = m_ChartMale;

				nChartControl1.Document.RootPanel.Guidelines.Add(twinGuideLine);
			}

			nChartControl1.Refresh();
		}
	}
}