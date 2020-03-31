using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom; 
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NParetoUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBarSeries m_Bar;
		private NLineSeries m_Line;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NCheckBox DifferentFillStyles;
		private Nevron.UI.WinForm.Controls.NHScrollBar WidthScroll;		
		private Nevron.UI.WinForm.Controls.NComboBox StyleCombo;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NButton BarFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton MarkersBorderButton;
		private Nevron.UI.WinForm.Controls.NButton MarkersFillButton;
		private Nevron.UI.WinForm.Controls.NButton LineStyleButton;
		private Nevron.UI.WinForm.Controls.NButton BarBorderButton;
		private System.ComponentModel.Container components = null;

		public NParetoUC()
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
			this.DifferentFillStyles = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.WidthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label1 = new System.Windows.Forms.Label();
			this.StyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.BarFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.BarBorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.MarkersBorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.MarkersFillButton = new Nevron.UI.WinForm.Controls.NButton();
			this.LineStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// DifferentFillStyles
			// 
			this.DifferentFillStyles.ButtonProperties.BorderOffset = 2;
			this.DifferentFillStyles.Location = new System.Drawing.Point(11, 174);
			this.DifferentFillStyles.Name = "DifferentFillStyles";
			this.DifferentFillStyles.Size = new System.Drawing.Size(148, 22);
			this.DifferentFillStyles.TabIndex = 15;
			this.DifferentFillStyles.Text = "Different Fill Styles";
			this.DifferentFillStyles.CheckedChanged += new System.EventHandler(this.DifferentFillStyles_CheckedChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(11, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(148, 16);
			this.label2.TabIndex = 13;
			this.label2.Text = "Width %:";
			// 
			// WidthScroll
			// 
			this.WidthScroll.Location = new System.Drawing.Point(11, 82);
			this.WidthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.WidthScroll.Name = "WidthScroll";
			this.WidthScroll.Size = new System.Drawing.Size(148, 16);
			this.WidthScroll.TabIndex = 11;
			this.WidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WidthScroll_Scroll);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(11, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(148, 16);
			this.label1.TabIndex = 10;
			this.label1.Text = "Bar Style:";
			// 
			// StyleCombo
			// 
			this.StyleCombo.ListProperties.CheckBoxDataMember = "";
			this.StyleCombo.ListProperties.DataSource = null;
			this.StyleCombo.ListProperties.DisplayMember = "";
			this.StyleCombo.Location = new System.Drawing.Point(11, 34);
			this.StyleCombo.Name = "StyleCombo";
			this.StyleCombo.Size = new System.Drawing.Size(148, 21);
			this.StyleCombo.TabIndex = 9;
			this.StyleCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			// 
			// BarFillStyleButton
			// 
			this.BarFillStyleButton.Location = new System.Drawing.Point(11, 108);
			this.BarFillStyleButton.Name = "BarFillStyleButton";
			this.BarFillStyleButton.Size = new System.Drawing.Size(148, 25);
			this.BarFillStyleButton.TabIndex = 8;
			this.BarFillStyleButton.Text = "Bar Fill Style...";
			this.BarFillStyleButton.Click += new System.EventHandler(this.BarFillStyleButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.BarBorderButton);
			this.groupBox1.Controls.Add(this.DifferentFillStyles);
			this.groupBox1.Controls.Add(this.WidthScroll);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.StyleCombo);
			this.groupBox1.Controls.Add(this.BarFillStyleButton);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(4, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(173, 212);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Bar Properties";
			// 
			// BarBorderButton
			// 
			this.BarBorderButton.Location = new System.Drawing.Point(11, 139);
			this.BarBorderButton.Name = "BarBorderButton";
			this.BarBorderButton.Size = new System.Drawing.Size(148, 25);
			this.BarBorderButton.TabIndex = 16;
			this.BarBorderButton.Text = "Bar Border...";
			this.BarBorderButton.Click += new System.EventHandler(this.BarBorderButton_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.MarkersBorderButton);
			this.groupBox2.Controls.Add(this.MarkersFillButton);
			this.groupBox2.Controls.Add(this.LineStyleButton);
			this.groupBox2.ImageIndex = 0;
			this.groupBox2.Location = new System.Drawing.Point(4, 226);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(173, 119);
			this.groupBox2.TabIndex = 17;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Line Properties";
			// 
			// MarkersBorderButton
			// 
			this.MarkersBorderButton.Location = new System.Drawing.Point(9, 49);
			this.MarkersBorderButton.Name = "MarkersBorderButton";
			this.MarkersBorderButton.Size = new System.Drawing.Size(148, 24);
			this.MarkersBorderButton.TabIndex = 14;
			this.MarkersBorderButton.Text = "Markers Border ...";
			this.MarkersBorderButton.Click += new System.EventHandler(this.MarkersBorderButton_Click);
			// 
			// MarkersFillButton
			// 
			this.MarkersFillButton.Location = new System.Drawing.Point(9, 79);
			this.MarkersFillButton.Name = "MarkersFillButton";
			this.MarkersFillButton.Size = new System.Drawing.Size(148, 24);
			this.MarkersFillButton.TabIndex = 13;
			this.MarkersFillButton.Text = "Markers Fill Style ...";
			this.MarkersFillButton.Click += new System.EventHandler(this.MarkersFillButton_Click);
			// 
			// LineStyleButton
			// 
			this.LineStyleButton.Location = new System.Drawing.Point(9, 19);
			this.LineStyleButton.Name = "LineStyleButton";
			this.LineStyleButton.Size = new System.Drawing.Size(148, 24);
			this.LineStyleButton.TabIndex = 12;
			this.LineStyleButton.Text = "Line Style ...";
			this.LineStyleButton.Click += new System.EventHandler(this.LineStyleButton_Click);
			// 
			// NParetoUC
			// 
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "NParetoUC";
			this.Size = new System.Drawing.Size(180, 357);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Pareto Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// setup the X axis
			NAxis axisX = m_Chart.Axis(StandardAxis.PrimaryX);
			NOrdinalScaleConfigurator scaleX = (NOrdinalScaleConfigurator)axisX.ScaleConfigurator;
			scaleX.InnerMajorTickStyle.Visible = false;

			// Setup the primary Y axis
			NAxis axisY1 = m_Chart.Axis(StandardAxis.PrimaryY);
			NLinearScaleConfigurator scaleY1 = (NLinearScaleConfigurator)axisY1.ScaleConfigurator;
			scaleY1.InnerMajorTickStyle.Visible = false;
			scaleY1.Title.Text = "Number of Occurences";

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
			scaleY1.StripStyles.Add(stripStyle);

			// Setup the secondary Y axis
			NLinearScaleConfigurator scaleY2 = new NLinearScaleConfigurator();
			scaleY2.LabelValueFormatter = new NNumericValueFormatter("0%");
			scaleY2.InnerMajorTickStyle.Visible = false;
			scaleY2.Title.Text = "Cumulative Percent";
			NAxis axisY2 = m_Chart.Axis(StandardAxis.SecondaryY);
			axisY2.Visible = true;
			axisY2.ScaleConfigurator = scaleY2;
			axisY2.View = new NRangeAxisView(new NRange1DD(0, 1), true, true);

			// add the line series
			m_Line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line.Name = "Cumulative %";
			m_Line.DataLabelStyle.Visible = false;
			m_Line.MarkerStyle.Visible = true;
			m_Line.MarkerStyle.PointShape = PointShape.Cylinder;
			m_Line.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			m_Line.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			m_Line.ShadowStyle.Type = ShadowType.GaussianBlur;
			m_Line.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
			m_Line.ShadowStyle.Offset = new NPointL(2, 2);
			m_Line.ShadowStyle.FadeLength = new NLength(4);
			m_Line.DisplayOnAxis(StandardAxis.PrimaryY, false);
			m_Line.DisplayOnAxis(StandardAxis.SecondaryY, true);

			// add the bar series
			m_Bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar.Name = "Bar Series";
			m_Bar.DataLabelStyle.Visible = false;
			m_Bar.ShadowStyle.Type = ShadowType.GaussianBlur;
			m_Bar.ShadowStyle.Color = Color.FromArgb(60, 0, 0, 0);
			m_Bar.ShadowStyle.Offset = new NPointL(3, 3);
			m_Bar.ShadowStyle.FadeLength = new NLength(4);

			// fill with random data and sort in descending order
			m_Bar.Values.FillRandomRange(Random, 10, 100, 700);
			m_Bar.Values.Sort(DataSeriesSortOrder.Descending);

			// calculate cumulative sum of the bar values
			int count = m_Bar.Values.Count;
			double cs = 0;
			double[] arrCumulative = new double[count];

			for (int i = 0; i < count; i++)
			{
				cs += m_Bar.Values.GetDoubleValue(i);
				arrCumulative[i] = cs;
			}

			if (cs > 0)
			{
				for (int i = 0; i < count; i++)
				{
					arrCumulative[i] /= cs;
				}

				m_Line.Values.AddRange(arrCumulative);
			}

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// init form controls
			StyleCombo.FillFromEnum(typeof(BarShape));
			StyleCombo.SelectedIndex = 0;
		}

		private void StyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Bar.BarShape = (BarShape)StyleCombo.SelectedIndex;
			nChartControl1.Refresh();
		}
		private void DifferentFillStyles_CheckedChanged(object sender, System.EventArgs e)
		{
			if (DifferentFillStyles.Checked)
			{
				BarFillStyleButton.Enabled = false;

				for(int i = 0; i < m_Bar.Values.Count; i++)
				{
					m_Bar.FillStyles[i] = new NColorFillStyle(RandomColor());
				}

				m_Bar.Legend.Mode = SeriesLegendMode.DataPoints;
			}
			else
			{
				BarFillStyleButton.Enabled = true;

				m_Bar.FillStyles.Clear();
				m_Bar.Legend.Mode = SeriesLegendMode.Series;
			}

			nChartControl1.Refresh();
		}
		private void WidthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Bar.WidthPercent = WidthScroll.Value;
			nChartControl1.Refresh();
		}
		private void BarFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_Bar.FillStyle, out fillStyleResult))
			{
				m_Bar.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void BarBorderButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if(NStrokeStyleTypeEditor.Edit(m_Bar.BorderStyle, out strokeStyleResult))
			{
				m_Bar.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void LineStyleButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if(NStrokeStyleTypeEditor.Edit(m_Line.BorderStyle, out strokeStyleResult))
			{
				m_Line.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void MarkersFillButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_Line.MarkerStyle.FillStyle, out fillStyleResult))
			{
				m_Line.MarkerStyle.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void MarkersBorderButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Line.MarkerStyle.BorderStyle, out strokeStyleResult))
			{
				m_Line.MarkerStyle.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
	}
}