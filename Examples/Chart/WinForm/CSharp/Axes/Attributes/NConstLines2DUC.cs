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
	public class NConstLines2DUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NCheckBox LeftIncludeInAxisRangeCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox BottomUseBeginEndCheck;
		private Nevron.UI.WinForm.Controls.NButton BottomBorderButton;
		private Nevron.UI.WinForm.Controls.NButton LeftPropsButton;
		private Nevron.UI.WinForm.Controls.NHScrollBar LeftValue;
		private Nevron.UI.WinForm.Controls.NHScrollBar BottomValue;
		private Nevron.UI.WinForm.Controls.NHScrollBar LeftBeginScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar BottomBeginScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar LeftEndScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar BottomEndScroll;
		private UI.WinForm.Controls.NCheckBox LeftUseBeginEndCheck;
		private UI.WinForm.Controls.NCheckBox BottomIncludeInAxisRangeCheck;
		private System.ComponentModel.Container components = null;

		public NConstLines2DUC()
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
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.LeftUseBeginEndCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.LeftEndScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label7 = new System.Windows.Forms.Label();
			this.LeftIncludeInAxisRangeCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.LeftBeginScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.LeftValue = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label1 = new System.Windows.Forms.Label();
			this.LeftPropsButton = new Nevron.UI.WinForm.Controls.NButton();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.BottomIncludeInAxisRangeCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.BottomEndScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label8 = new System.Windows.Forms.Label();
			this.BottomUseBeginEndCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.BottomBeginScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.BottomBorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.BottomValue = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.LeftUseBeginEndCheck);
			this.groupBox1.Controls.Add(this.LeftEndScroll);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.LeftIncludeInAxisRangeCheck);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.LeftBeginScroll);
			this.groupBox1.Controls.Add(this.LeftValue);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.LeftPropsButton);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(174, 277);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Left Axis Const Line";
			// 
			// LeftUseBeginEndCheck
			// 
			this.LeftUseBeginEndCheck.ButtonProperties.BorderOffset = 2;
			this.LeftUseBeginEndCheck.Location = new System.Drawing.Point(13, 115);
			this.LeftUseBeginEndCheck.Name = "LeftUseBeginEndCheck";
			this.LeftUseBeginEndCheck.Size = new System.Drawing.Size(148, 21);
			this.LeftUseBeginEndCheck.TabIndex = 4;
			this.LeftUseBeginEndCheck.Text = "Use Begin-End Values";
			this.LeftUseBeginEndCheck.CheckedChanged += new System.EventHandler(this.LeftUseBeginEndCheck_CheckedChanged);
			// 
			// LeftEndScroll
			// 
			this.LeftEndScroll.Location = new System.Drawing.Point(13, 200);
			this.LeftEndScroll.Maximum = 110;
			this.LeftEndScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.LeftEndScroll.Name = "LeftEndScroll";
			this.LeftEndScroll.Size = new System.Drawing.Size(148, 18);
			this.LeftEndScroll.TabIndex = 8;
			this.LeftEndScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftEndScroll_Scroll);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(13, 182);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(148, 14);
			this.label7.TabIndex = 7;
			this.label7.Text = "End Value:";
			// 
			// LeftIncludeInAxisRangeCheck
			// 
			this.LeftIncludeInAxisRangeCheck.ButtonProperties.BorderOffset = 2;
			this.LeftIncludeInAxisRangeCheck.Location = new System.Drawing.Point(13, 65);
			this.LeftIncludeInAxisRangeCheck.Name = "LeftIncludeInAxisRangeCheck";
			this.LeftIncludeInAxisRangeCheck.Size = new System.Drawing.Size(148, 21);
			this.LeftIncludeInAxisRangeCheck.TabIndex = 2;
			this.LeftIncludeInAxisRangeCheck.Text = "Include in axis range";
			this.LeftIncludeInAxisRangeCheck.CheckedChanged += new System.EventHandler(this.LeftIncludeInAxisRangeCheck_CheckedChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(13, 140);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(148, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Begin Value:";
			// 
			// LeftBeginScroll
			// 
			this.LeftBeginScroll.Location = new System.Drawing.Point(13, 160);
			this.LeftBeginScroll.Maximum = 110;
			this.LeftBeginScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.LeftBeginScroll.Name = "LeftBeginScroll";
			this.LeftBeginScroll.Size = new System.Drawing.Size(148, 18);
			this.LeftBeginScroll.TabIndex = 6;
			this.LeftBeginScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftBeginScroll_Scroll);
			// 
			// LeftValue
			// 
			this.LeftValue.Location = new System.Drawing.Point(13, 44);
			this.LeftValue.Maximum = 130;
			this.LeftValue.Minimum = -20;
			this.LeftValue.MinimumSize = new System.Drawing.Size(32, 16);
			this.LeftValue.Name = "LeftValue";
			this.LeftValue.Size = new System.Drawing.Size(148, 17);
			this.LeftValue.TabIndex = 1;
			this.LeftValue.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftValue_Scroll);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(148, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Value:";
			// 
			// LeftPropsButton
			// 
			this.LeftPropsButton.Location = new System.Drawing.Point(13, 90);
			this.LeftPropsButton.Name = "LeftPropsButton";
			this.LeftPropsButton.Size = new System.Drawing.Size(148, 21);
			this.LeftPropsButton.TabIndex = 3;
			this.LeftPropsButton.Text = "Line Style...";
			this.LeftPropsButton.Click += new System.EventHandler(this.LeftPropsButton_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.BottomIncludeInAxisRangeCheck);
			this.groupBox2.Controls.Add(this.BottomEndScroll);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.BottomUseBeginEndCheck);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.BottomBeginScroll);
			this.groupBox2.Controls.Add(this.BottomBorderButton);
			this.groupBox2.Controls.Add(this.BottomValue);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.ImageIndex = 0;
			this.groupBox2.Location = new System.Drawing.Point(0, 277);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(174, 277);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Bottom Axis Const Line";
			// 
			// BottomIncludeInAxisRangeCheck
			// 
			this.BottomIncludeInAxisRangeCheck.ButtonProperties.BorderOffset = 2;
			this.BottomIncludeInAxisRangeCheck.Location = new System.Drawing.Point(13, 63);
			this.BottomIncludeInAxisRangeCheck.Name = "BottomIncludeInAxisRangeCheck";
			this.BottomIncludeInAxisRangeCheck.Size = new System.Drawing.Size(148, 21);
			this.BottomIncludeInAxisRangeCheck.TabIndex = 2;
			this.BottomIncludeInAxisRangeCheck.Text = "Include in axis range";
			this.BottomIncludeInAxisRangeCheck.CheckedChanged += new System.EventHandler(this.BottomIncludeInAxisRangeCheck_CheckedChanged);
			// 
			// BottomEndScroll
			// 
			this.BottomEndScroll.Location = new System.Drawing.Point(13, 199);
			this.BottomEndScroll.Maximum = 110;
			this.BottomEndScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.BottomEndScroll.Name = "BottomEndScroll";
			this.BottomEndScroll.Size = new System.Drawing.Size(140, 18);
			this.BottomEndScroll.TabIndex = 8;
			this.BottomEndScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomEndScroll_Scroll);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(13, 180);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(140, 15);
			this.label8.TabIndex = 7;
			this.label8.Text = "End Value:";
			// 
			// BottomUseBeginEndCheck
			// 
			this.BottomUseBeginEndCheck.ButtonProperties.BorderOffset = 2;
			this.BottomUseBeginEndCheck.Location = new System.Drawing.Point(13, 113);
			this.BottomUseBeginEndCheck.Name = "BottomUseBeginEndCheck";
			this.BottomUseBeginEndCheck.Size = new System.Drawing.Size(140, 21);
			this.BottomUseBeginEndCheck.TabIndex = 4;
			this.BottomUseBeginEndCheck.Text = "Use Begin-End Values";
			this.BottomUseBeginEndCheck.CheckedChanged += new System.EventHandler(this.BottomUseBeginEndCheck_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(13, 138);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(140, 16);
			this.label6.TabIndex = 5;
			this.label6.Text = "Begin Value:";
			// 
			// BottomBeginScroll
			// 
			this.BottomBeginScroll.Location = new System.Drawing.Point(13, 158);
			this.BottomBeginScroll.Maximum = 110;
			this.BottomBeginScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.BottomBeginScroll.Name = "BottomBeginScroll";
			this.BottomBeginScroll.Size = new System.Drawing.Size(140, 18);
			this.BottomBeginScroll.TabIndex = 6;
			this.BottomBeginScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomBeginScroll_Scroll);
			// 
			// BottomBorderButton
			// 
			this.BottomBorderButton.Location = new System.Drawing.Point(13, 88);
			this.BottomBorderButton.Name = "BottomBorderButton";
			this.BottomBorderButton.Size = new System.Drawing.Size(140, 21);
			this.BottomBorderButton.TabIndex = 3;
			this.BottomBorderButton.Text = "Line Props";
			this.BottomBorderButton.Click += new System.EventHandler(this.BottomBorderButton_Click);
			// 
			// BottomValue
			// 
			this.BottomValue.Location = new System.Drawing.Point(13, 42);
			this.BottomValue.Maximum = 130;
			this.BottomValue.Minimum = -20;
			this.BottomValue.MinimumSize = new System.Drawing.Size(32, 16);
			this.BottomValue.Name = "BottomValue";
			this.BottomValue.Size = new System.Drawing.Size(140, 17);
			this.BottomValue.TabIndex = 1;
			this.BottomValue.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomValue_Scroll);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(13, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(140, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Value:";
			// 
			// NConstLines2DUC
			// 
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "NConstLines2DUC";
			this.Size = new System.Drawing.Size(174, 561);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Axis Const Lines");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;

            // configure the x scale
            NLinearScaleConfigurator xScale = new NLinearScaleConfigurator();
            xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale;
            
            // configure the y scale
            NLinearScaleConfigurator yScale = new NLinearScaleConfigurator();
            
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			yScale.StripStyles.Add(stripStyle);

            yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = yScale;

			// Create a point series
			NPointSeries pnt = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);
			pnt.InflateMargins = true;
			pnt.UseXValues = true;
			pnt.Name = "Series 1";
			pnt.DataLabelStyle.Visible = false;

			// Add some data
			pnt.Values.Add(31);
			pnt.Values.Add(67);
			pnt.Values.Add(12);
			pnt.Values.Add(84);
			pnt.Values.Add(90);

			pnt.XValues.Add(5);
			pnt.XValues.Add(36);
			pnt.XValues.Add(51);
			pnt.XValues.Add(76);
			pnt.XValues.Add(93);

			// Add a constline for the left axis
			NAxisConstLine cl1 = m_Chart.Axis(StandardAxis.PrimaryY).ConstLines.Add();
			cl1.StrokeStyle.Color = Color.SteelBlue;
            cl1.StrokeStyle.Width = new NLength(1.5f);
            cl1.FillStyle = new NColorFillStyle(new NArgbColor(125, Color.SteelBlue));
			cl1.Value = 40;

			// Add a constline for the bottom axis
			NAxisConstLine cl2 = m_Chart.Axis(StandardAxis.PrimaryX).ConstLines.Add();
            cl2.StrokeStyle.Color = Color.SteelBlue;
            cl2.StrokeStyle.Width = new NLength(1.5f);
            cl2.FillStyle = new NColorFillStyle(new NArgbColor(125, Color.SteelBlue));
			cl2.Value = 60;

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			LeftValue.Value = (int)cl1.Value;
			BottomValue.Value = (int)cl2.Value;
			LeftBeginScroll.Value = 10;
			LeftEndScroll.Value = 80;
			BottomBeginScroll.Value = 10;
			BottomEndScroll.Value = 80;
			LeftBeginScroll.Enabled = false;
			LeftEndScroll.Enabled = false;
			BottomBeginScroll.Enabled = false;
			BottomEndScroll.Enabled = false;

			nChartControl1.Refresh();
		}

		private void LeftPropsButton_Click(object sender, System.EventArgs e)
		{
			NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryY).ConstLines[0];
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(cl.StrokeStyle, out strokeStyleResult))
			{
				cl.StrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void BottomBorderButton_Click(object sender, System.EventArgs e)
		{
			NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryX).ConstLines[0];
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(cl.StrokeStyle, out strokeStyleResult))
			{
				cl.StrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void LeftValue_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryY).ConstLines[0];

			cl.Value = LeftValue.Value;

			nChartControl1.Refresh();
		}

		private void BottomValue_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryX).ConstLines[0];

			cl.Value = BottomValue.Value;

			nChartControl1.Refresh();
		}

		private void LeftBeginScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryY).ConstLines[0];

			if(cl.ReferenceRanges.Count > 0)
			{
				NReferenceAxisRange refAxisRange = (NReferenceAxisRange)cl.ReferenceRanges[0];
				refAxisRange.BeginValue = LeftBeginScroll.Value;
				nChartControl1.Refresh();
			}
		}

		private void LeftEndScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryY).ConstLines[0];

			if(cl.ReferenceRanges.Count > 0)
			{
				NReferenceAxisRange refAxisRange = (NReferenceAxisRange)cl.ReferenceRanges[0];
				refAxisRange.EndValue = LeftEndScroll.Value;
				nChartControl1.Refresh();
			}
		}

		private void BottomBeginScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryX).ConstLines[0];

			if(cl.ReferenceRanges.Count > 0)
			{
				NReferenceAxisRange refAxisRange = (NReferenceAxisRange)cl.ReferenceRanges[0];
				refAxisRange.BeginValue = BottomBeginScroll.Value;
				nChartControl1.Refresh();
			}
		}

		private void BottomEndScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryX).ConstLines[0];

			if(cl.ReferenceRanges.Count > 0)
			{
				NReferenceAxisRange refAxisRange = (NReferenceAxisRange)cl.ReferenceRanges[0];
				refAxisRange.EndValue = BottomEndScroll.Value;
				nChartControl1.Refresh();
			}
		}

		private void BottomUseBeginEndCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryX).ConstLines[0];

			if(BottomUseBeginEndCheck.Checked)
			{
				NAxis referenceAxis = m_Chart.Axis(StandardAxis.PrimaryY);
				double refBeginValue = BottomBeginScroll.Value;
				double refEndValue = BottomEndScroll.Value;
				cl.ReferenceRanges.Add(new NReferenceAxisRange(referenceAxis, refBeginValue, refEndValue));

				BottomBeginScroll.Enabled = true;
				BottomEndScroll.Enabled = true;
			}
			else
			{
				cl.ReferenceRanges.Clear();

				BottomBeginScroll.Enabled = false;
				BottomEndScroll.Enabled = false;
			}

			nChartControl1.Refresh();
		}

		private void LeftUseBeginEndCheck_CheckedChanged(object sender, EventArgs e)
		{
			NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryY).ConstLines[0];

			if (LeftUseBeginEndCheck.Checked)
			{
				NAxis referenceAxis = m_Chart.Axis(StandardAxis.PrimaryX);
				double refBeginValue = LeftBeginScroll.Value;
				double refEndValue = LeftEndScroll.Value;
				cl.ReferenceRanges.Add(new NReferenceAxisRange(referenceAxis, refBeginValue, refEndValue));

				LeftBeginScroll.Enabled = true;
				LeftEndScroll.Enabled = true;
			}
			else
			{
				cl.ReferenceRanges.Clear();

				LeftBeginScroll.Enabled = false;
				LeftEndScroll.Enabled = false;
			}

			nChartControl1.Refresh();
		}

		private void LeftIncludeInAxisRangeCheck_CheckedChanged(object sender, EventArgs e)
		{
			NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryY).ConstLines[0];
			cl.IncludeInAxisRange = LeftIncludeInAxisRangeCheck.Checked;

			nChartControl1.Refresh();
		}

		private void BottomIncludeInAxisRangeCheck_CheckedChanged(object sender, EventArgs e)
		{
			NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryX).ConstLines[0];
			cl.IncludeInAxisRange = BottomIncludeInAxisRangeCheck.Checked;

			nChartControl1.Refresh();
		}
	}
}
