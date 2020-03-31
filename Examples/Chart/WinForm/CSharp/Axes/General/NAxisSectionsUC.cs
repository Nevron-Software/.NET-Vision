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
	public class NAxisSectionsUC : NExampleBaseUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private NCartesianChart m_Chart;

		private NScaleSectionStyle m_FirstVerticalSection;
		private NScaleSectionStyle m_SecondVerticalSection;
		private NScaleSectionStyle m_FirstHorizontalSection;
		private NScaleSectionStyle m_SecondHorizontalSection;

		private Nevron.UI.WinForm.Controls.NCheckBox ShowFirstHorizontalSectionCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowSecondHorizontalSectionCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowFirstVerticalSectionCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowSecondVerticalSectionCheck;
		
		public NAxisSectionsUC()
		{
			// This call is required by the Windows.Forms Form Designer.
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
			this.ShowFirstHorizontalSectionCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowSecondHorizontalSectionCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowFirstVerticalSectionCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowSecondVerticalSectionCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// ShowFirstHorizontalSectionCheck
			// 
			this.ShowFirstHorizontalSectionCheck.Location = new System.Drawing.Point(8, 64);
			this.ShowFirstHorizontalSectionCheck.Name = "ShowFirstHorizontalSectionCheck";
			this.ShowFirstHorizontalSectionCheck.Size = new System.Drawing.Size(144, 20);
			this.ShowFirstHorizontalSectionCheck.TabIndex = 7;
			this.ShowFirstHorizontalSectionCheck.Text = "Show X Section [2, 8]";
			this.ShowFirstHorizontalSectionCheck.CheckedChanged += new System.EventHandler(this.ShowFirstHorizontalSectionCheck_CheckedChanged);
			// 
			// ShowSecondHorizontalSectionCheck
			// 
			this.ShowSecondHorizontalSectionCheck.Location = new System.Drawing.Point(8, 88);
			this.ShowSecondHorizontalSectionCheck.Name = "ShowSecondHorizontalSectionCheck";
			this.ShowSecondHorizontalSectionCheck.Size = new System.Drawing.Size(144, 20);
			this.ShowSecondHorizontalSectionCheck.TabIndex = 8;
			this.ShowSecondHorizontalSectionCheck.Text = "Show X Section [14, 18]";
			this.ShowSecondHorizontalSectionCheck.CheckedChanged += new System.EventHandler(this.ShowSecondHorizontalSectionCheck_CheckedChanged);
			// 
			// ShowFirstVerticalSectionCheck
			// 
			this.ShowFirstVerticalSectionCheck.Location = new System.Drawing.Point(8, 8);
			this.ShowFirstVerticalSectionCheck.Name = "ShowFirstVerticalSectionCheck";
			this.ShowFirstVerticalSectionCheck.Size = new System.Drawing.Size(144, 20);
			this.ShowFirstVerticalSectionCheck.TabIndex = 9;
			this.ShowFirstVerticalSectionCheck.Text = "Show Y Section [20, 40]";
			this.ShowFirstVerticalSectionCheck.CheckedChanged += new System.EventHandler(this.ShowFirstVerticalSectionCheck_CheckedChanged);
			// 
			// ShowSecondVerticalSectionCheck
			// 
			this.ShowSecondVerticalSectionCheck.Location = new System.Drawing.Point(8, 32);
			this.ShowSecondVerticalSectionCheck.Name = "ShowSecondVerticalSectionCheck";
			this.ShowSecondVerticalSectionCheck.Size = new System.Drawing.Size(136, 20);
			this.ShowSecondVerticalSectionCheck.TabIndex = 10;
			this.ShowSecondVerticalSectionCheck.Text = "Show Y Section [70, 90]";
			this.ShowSecondVerticalSectionCheck.CheckedChanged += new System.EventHandler(this.ShowSecondVerticalSectionCheck_CheckedChanged);
			// 
			// NAxisSectionsUC
			// 
			this.Controls.Add(this.ShowSecondVerticalSectionCheck);
			this.Controls.Add(this.ShowFirstVerticalSectionCheck);
			this.Controls.Add(this.ShowSecondHorizontalSectionCheck);
			this.Controls.Add(this.ShowFirstHorizontalSectionCheck);
			this.Name = "NAxisSectionsUC";
			this.Size = new System.Drawing.Size(160, 264);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Axis Sections");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			m_Chart = (NCartesianChart)nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;

			// create a point series
			NPointSeries point = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);
			point.Name = "Point Series";
			point.DataLabelStyle.Visible = false;
			point.MarkerStyle.Visible = false;
			point.Size = new NLength(5, NGraphicsUnit.Point);
			point.Values.FillRandom(Random, 30);
			point.ShadowStyle.Type = ShadowType.GaussianBlur;
			point.ShadowStyle.Offset = new NPointL(3, 3);
			point.ShadowStyle.FadeLength = new NLength(5);
			point.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0);
			point.InflateMargins = true;

			// tell the x axis to display major and minor grid lines
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MinorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MinorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MinorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MinorTickCount = 1;

			// tell the y axis to display major and minor grid lines
			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MinorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MinorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MinorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MinorTickCount = 1;

			NTextStyle labelStyle;

			// configure the first horizontal section
			m_FirstHorizontalSection = new NScaleSectionStyle();
			m_FirstHorizontalSection.Range = new NRange1DD(2, 8);
			m_FirstHorizontalSection.SetShowAtWall(ChartWallType.Back, true);
			m_FirstHorizontalSection.SetShowAtWall(ChartWallType.Floor, true);
            m_FirstHorizontalSection.RangeFillStyle = new NColorFillStyle(Color.FromArgb(60, Color.Red));
			m_FirstHorizontalSection.MajorGridStrokeStyle = new NStrokeStyle(Color.Red);
			m_FirstHorizontalSection.MajorTickStrokeStyle = new NStrokeStyle(Color.DarkRed);
			m_FirstHorizontalSection.MinorTickStrokeStyle = new NStrokeStyle(1, Color.Red, LinePattern.Dot, 0, 2);

			labelStyle = new NTextStyle();
			labelStyle.FillStyle = new NGradientFillStyle(Color.Red, Color.DarkRed);
			labelStyle.FontStyle.Style = FontStyle.Bold;
			m_FirstHorizontalSection.LabelTextStyle = labelStyle;

			// configure the second horizontal section
			m_SecondHorizontalSection = new NScaleSectionStyle();
			m_SecondHorizontalSection.Range = new NRange1DD(14, 18);
			m_SecondHorizontalSection.SetShowAtWall(ChartWallType.Back, true);
			m_SecondHorizontalSection.SetShowAtWall(ChartWallType.Floor, true);
			m_SecondHorizontalSection.RangeFillStyle = new NColorFillStyle(Color.FromArgb(60, Color.Green));
			m_SecondHorizontalSection.MajorGridStrokeStyle = new NStrokeStyle(Color.Green);
			m_SecondHorizontalSection.MajorTickStrokeStyle = new NStrokeStyle(Color.DarkGreen);
			m_SecondHorizontalSection.MinorTickStrokeStyle = new NStrokeStyle(1, Color.Green, LinePattern.Dot, 0, 2);

			labelStyle = new NTextStyle();
			labelStyle.FillStyle = new NGradientFillStyle(Color.Green, Color.DarkGreen);
			labelStyle.FontStyle.Style = FontStyle.Bold;
			m_SecondHorizontalSection.LabelTextStyle = labelStyle;

			// configure the first vertical section
			m_FirstVerticalSection = new NScaleSectionStyle();
			m_FirstVerticalSection.Range = new NRange1DD(20, 40);
			m_FirstVerticalSection.SetShowAtWall(ChartWallType.Back, true);
			m_FirstVerticalSection.SetShowAtWall(ChartWallType.Left, true);
			m_FirstVerticalSection.RangeFillStyle = new NColorFillStyle(Color.FromArgb(60, Color.Blue));
			m_FirstVerticalSection.MajorGridStrokeStyle = new NStrokeStyle(Color.Blue);
			m_FirstVerticalSection.MajorTickStrokeStyle = new NStrokeStyle(Color.DarkBlue);
			m_FirstVerticalSection.MinorTickStrokeStyle = new NStrokeStyle(1, Color.Blue, LinePattern.Dot, 0, 2);

			labelStyle = new NTextStyle();
			labelStyle.FillStyle = new NGradientFillStyle(Color.Blue, Color.DarkBlue);
			labelStyle.FontStyle.Style = FontStyle.Bold;
			m_FirstVerticalSection.LabelTextStyle = labelStyle;

			// configure the second vertical section
			m_SecondVerticalSection = new NScaleSectionStyle();
			m_SecondVerticalSection.Range = new NRange1DD(70, 90);
			m_SecondVerticalSection.SetShowAtWall(ChartWallType.Back, true);
			m_SecondVerticalSection.SetShowAtWall(ChartWallType.Left, true);
			m_SecondVerticalSection.RangeFillStyle = new NColorFillStyle(Color.FromArgb(60, Color.Orange));
			m_SecondVerticalSection.MajorGridStrokeStyle = new NStrokeStyle(Color.Orange);
			m_SecondVerticalSection.MajorTickStrokeStyle = new NStrokeStyle(Color.DarkOrange);
			m_SecondVerticalSection.MinorTickStrokeStyle = new NStrokeStyle(1, Color.Orange, LinePattern.Dot, 0, 2);

			labelStyle = new NTextStyle();
			labelStyle.FillStyle = new NGradientFillStyle(Color.Orange, Color.DarkOrange);
			labelStyle.FontStyle.Style = FontStyle.Bold;
			m_SecondVerticalSection.LabelTextStyle = labelStyle;

			ShowFirstHorizontalSectionCheck.Checked = true;
			ShowSecondHorizontalSectionCheck.Checked = true;
			ShowFirstVerticalSectionCheck.Checked = true;
			ShowSecondVerticalSectionCheck.Checked = true;
		}

		private void UpdateSections()
		{
			NStandardScaleConfigurator standardScale;
				
			// configure horizontal axis sections
			standardScale = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			standardScale.Sections.Clear();

			if (ShowFirstHorizontalSectionCheck.Checked)
			{
				standardScale.Sections.Add(m_FirstHorizontalSection);
			}

			if (ShowSecondHorizontalSectionCheck.Checked)
			{
				standardScale.Sections.Add(m_SecondHorizontalSection);
			}

			// configure vertical axis sections
			standardScale = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			standardScale.Sections.Clear();

			if (ShowFirstVerticalSectionCheck.Checked)
			{
				standardScale.Sections.Add(m_FirstVerticalSection);
			}

			if (ShowSecondVerticalSectionCheck.Checked)
			{
				standardScale.Sections.Add(m_SecondVerticalSection);
			}

			nChartControl1.Refresh();
		}

		private void ShowFirstVerticalSectionCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateSections();
		}

		private void ShowSecondVerticalSectionCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateSections();
		}

		private void ShowFirstHorizontalSectionCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateSections();
		}

		private void ShowSecondHorizontalSectionCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateSections();
		}
	}
}
