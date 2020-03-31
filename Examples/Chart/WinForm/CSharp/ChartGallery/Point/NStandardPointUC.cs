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
	public class NStandardPointUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NPointSeries m_Point;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NCheckBox InflateMarginsCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox RoundToTickCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox DifferentColorsCheck;
		private Nevron.UI.WinForm.Controls.NComboBox PointStyleCombo;
		private Nevron.UI.WinForm.Controls.NHScrollBar PointSizeScroll;
		private Nevron.UI.WinForm.Controls.NButton FillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton LinePropertiesButton;
		private Nevron.UI.WinForm.Controls.NButton ShadowButton;
		private Nevron.UI.WinForm.Controls.NButton dataLabelStyleButton;
		private System.ComponentModel.Container components = null;

		public NStandardPointUC()
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
			this.PointStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.PointSizeScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.FillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.DifferentColorsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.InflateMarginsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.RoundToTickCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.LinePropertiesButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ShadowButton = new Nevron.UI.WinForm.Controls.NButton();
			this.dataLabelStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(172, 21);
			this.label1.TabIndex = 0;
			this.label1.Text = "Point Style:";
			// 
			// PointStyleCombo
			// 
			this.PointStyleCombo.ListProperties.CheckBoxDataMember = "";
			this.PointStyleCombo.ListProperties.DataSource = null;
			this.PointStyleCombo.ListProperties.DisplayMember = "";
			this.PointStyleCombo.Location = new System.Drawing.Point(4, 25);
			this.PointStyleCombo.Name = "PointStyleCombo";
			this.PointStyleCombo.Size = new System.Drawing.Size(172, 21);
			this.PointStyleCombo.TabIndex = 1;
			this.PointStyleCombo.SelectedIndexChanged += new System.EventHandler(this.PointStyleCombo_SelectedIndexChanged);
			// 
			// PointSizeScroll
			// 
			this.PointSizeScroll.LargeChange = 1;
			this.PointSizeScroll.Location = new System.Drawing.Point(4, 73);
			this.PointSizeScroll.Maximum = 12;
			this.PointSizeScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.PointSizeScroll.Name = "PointSizeScroll";
			this.PointSizeScroll.Size = new System.Drawing.Size(172, 18);
			this.PointSizeScroll.TabIndex = 3;
			this.PointSizeScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.PointSizeScroll_Scroll);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(172, 21);
			this.label2.TabIndex = 2;
			this.label2.Text = "Point Size:";
			// 
			// FillStyleButton
			// 
			this.FillStyleButton.Location = new System.Drawing.Point(4, 195);
			this.FillStyleButton.Name = "FillStyleButton";
			this.FillStyleButton.Size = new System.Drawing.Size(172, 23);
			this.FillStyleButton.TabIndex = 7;
			this.FillStyleButton.Text = "Point Fill Style...";
			this.FillStyleButton.Click += new System.EventHandler(this.FillStyleButton_Click);
			// 
			// DifferentColorsCheck
			// 
			this.DifferentColorsCheck.ButtonProperties.BorderOffset = 2;
			this.DifferentColorsCheck.Location = new System.Drawing.Point(4, 155);
			this.DifferentColorsCheck.Name = "DifferentColorsCheck";
			this.DifferentColorsCheck.Size = new System.Drawing.Size(172, 21);
			this.DifferentColorsCheck.TabIndex = 6;
			this.DifferentColorsCheck.Text = "Different Colors";
			this.DifferentColorsCheck.CheckedChanged += new System.EventHandler(this.DifferentColorsCheck_CheckedChanged);
			// 
			// InflateMarginsCheck
			// 
			this.InflateMarginsCheck.ButtonProperties.BorderOffset = 2;
			this.InflateMarginsCheck.Location = new System.Drawing.Point(4, 105);
			this.InflateMarginsCheck.Name = "InflateMarginsCheck";
			this.InflateMarginsCheck.Size = new System.Drawing.Size(172, 21);
			this.InflateMarginsCheck.TabIndex = 4;
			this.InflateMarginsCheck.Text = "Inflate Margins";
			this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			// 
			// RoundToTickCheck
			// 
			this.RoundToTickCheck.ButtonProperties.BorderOffset = 2;
			this.RoundToTickCheck.Location = new System.Drawing.Point(4, 130);
			this.RoundToTickCheck.Name = "RoundToTickCheck";
			this.RoundToTickCheck.Size = new System.Drawing.Size(172, 21);
			this.RoundToTickCheck.TabIndex = 5;
			this.RoundToTickCheck.Text = "Left Axis Round To Tick";
			this.RoundToTickCheck.CheckedChanged += new System.EventHandler(this.RoundToTickCheck_CheckedChanged);
			// 
			// LinePropertiesButton
			// 
			this.LinePropertiesButton.Location = new System.Drawing.Point(4, 223);
			this.LinePropertiesButton.Name = "LinePropertiesButton";
			this.LinePropertiesButton.Size = new System.Drawing.Size(172, 23);
			this.LinePropertiesButton.TabIndex = 8;
			this.LinePropertiesButton.Text = "Point Stroke Style...";
			this.LinePropertiesButton.Click += new System.EventHandler(this.LinePropertiesButton_Click);
			// 
			// ShadowButton
			// 
			this.ShadowButton.Location = new System.Drawing.Point(4, 251);
			this.ShadowButton.Name = "ShadowButton";
			this.ShadowButton.Size = new System.Drawing.Size(172, 23);
			this.ShadowButton.TabIndex = 9;
			this.ShadowButton.Text = "Point Shadow...";
			this.ShadowButton.Click += new System.EventHandler(this.ShadowButton_Click);
			// 
			// dataLabelStyleButton
			// 
			this.dataLabelStyleButton.Location = new System.Drawing.Point(4, 278);
			this.dataLabelStyleButton.Name = "dataLabelStyleButton";
			this.dataLabelStyleButton.Size = new System.Drawing.Size(172, 23);
			this.dataLabelStyleButton.TabIndex = 10;
			this.dataLabelStyleButton.Text = "Data Label Style...";
			this.dataLabelStyleButton.Click += new System.EventHandler(this.dataLabelStyleButton_Click);
			// 
			// NStandardPointUC
			// 
			this.Controls.Add(this.dataLabelStyleButton);
			this.Controls.Add(this.ShadowButton);
			this.Controls.Add(this.LinePropertiesButton);
			this.Controls.Add(this.RoundToTickCheck);
			this.Controls.Add(this.InflateMarginsCheck);
			this.Controls.Add(this.DifferentColorsCheck);
			this.Controls.Add(this.FillStyleButton);
			this.Controls.Add(this.PointSizeScroll);
			this.Controls.Add(this.PointStyleCombo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "NStandardPointUC";
			this.Size = new System.Drawing.Size(180, 320);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("2D Point Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlace stripe
            NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// setup point series
			m_Point = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);
			m_Point.Name = "Point Series";
			m_Point.InflateMargins = true;

			m_Point.AddDataPoint(new NDataPoint(23, "Item1"));
			m_Point.AddDataPoint(new NDataPoint(67, "Item2"));
			m_Point.AddDataPoint(new NDataPoint(78, "Item3"));
			m_Point.AddDataPoint(new NDataPoint(12, "Item4"));
			m_Point.AddDataPoint(new NDataPoint(56, "Item5"));
			m_Point.AddDataPoint(new NDataPoint(43, "Item6"));
			m_Point.AddDataPoint(new NDataPoint(37, "Item7"));
			m_Point.AddDataPoint(new NDataPoint(51, "Item8"));

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);
	
			// init form controls
			PointStyleCombo.FillFromEnum(typeof(PointShape));
			PointStyleCombo.SelectedIndex = 0;
			InflateMarginsCheck.Checked = true;
			RoundToTickCheck.Checked = true;
            DifferentColorsCheck.Checked = true;
			PointSizeScroll.Value = 3;
		}

		private void PointStyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Point.PointShape = (PointShape)PointStyleCombo.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void PointSizeScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Point.Size = new NLength(PointSizeScroll.Value, NRelativeUnit.ParentPercentage);
			nChartControl1.Refresh();
		}

		private void FillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_Point.FillStyle, out fillStyleResult))
			{
				m_Point.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void LinePropertiesButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Point.BorderStyle, out strokeStyleResult))
			{
				m_Point.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void ShadowButton_Click(object sender, System.EventArgs e)
		{
			NShadowStyle shadowStyleResult;

			if(NShadowStyleTypeEditor.Edit(m_Point.ShadowStyle, out shadowStyleResult))
			{
				m_Point.ShadowStyle = shadowStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void dataLabelStyleButton_Click(object sender, System.EventArgs e)
		{
			NDataLabelStyle result;

			if(NDataLabelStyleTypeEditor.Edit(m_Point.DataLabelStyle, out result))
			{
				m_Point.DataLabelStyle = result;
				nChartControl1.Refresh();
			}
		}

		private void DifferentColorsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (DifferentColorsCheck.Checked)
			{
				FillStyleButton.Enabled = false;

				m_Point.Legend.Mode = SeriesLegendMode.DataPoints;

                // apply style sheet
				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
                styleSheet.Apply(nChartControl1.Document);
			}
			else
			{
				FillStyleButton.Enabled = true;
				
				m_Point.Legend.Mode = SeriesLegendMode.Series;

                // apply style sheet
                NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
                styleSheet.Apply(nChartControl1.Document);
			}

			nChartControl1.Refresh();
		}

		private void InflateMarginsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (InflateMarginsCheck.Checked)
			{
				m_Point.InflateMargins = true;
			}
			else
			{
				m_Point.InflateMargins = false;
			}

			nChartControl1.Refresh();
		}

		private void RoundToTickCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator standardScale = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			standardScale.RoundToTickMin = RoundToTickCheck.Checked;
			standardScale.RoundToTickMax = RoundToTickCheck.Checked;

			nChartControl1.Refresh();
		}
	}
}