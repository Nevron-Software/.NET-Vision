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
	public class NConstLines3DUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NComboBox LeftStyleCombo;
		private Nevron.UI.WinForm.Controls.NButton LeftPropsButton;
		private Nevron.UI.WinForm.Controls.NButton LeftFillFillStyleButton;
		private Nevron.UI.WinForm.Controls.NHScrollBar LeftValue;
		private Nevron.UI.WinForm.Controls.NHScrollBar EndXScroll;
		private Nevron.UI.WinForm.Controls.NCheckBox UseBeginEndXCheck;
		private Nevron.UI.WinForm.Controls.NHScrollBar BeginXScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar EndZScroll;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NCheckBox UseBeginEndZCheck;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NHScrollBar BeginZScroll;
		private System.ComponentModel.Container components = null;

		public NConstLines3DUC()
		{
			InitializeComponent();

			LeftStyleCombo.FillFromEnum(typeof(ConstLineMode));
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
			this.EndZScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.UseBeginEndZCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.BeginZScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.EndXScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label7 = new System.Windows.Forms.Label();
			this.UseBeginEndXCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.BeginXScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.LeftFillFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label3 = new System.Windows.Forms.Label();
			this.LeftValue = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label1 = new System.Windows.Forms.Label();
			this.LeftPropsButton = new Nevron.UI.WinForm.Controls.NButton();
			this.LeftStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.EndZScroll);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.UseBeginEndZCheck);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.BeginZScroll);
			this.groupBox1.Controls.Add(this.EndXScroll);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.UseBeginEndXCheck);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.BeginXScroll);
			this.groupBox1.Controls.Add(this.LeftFillFillStyleButton);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.LeftValue);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.LeftPropsButton);
			this.groupBox1.Controls.Add(this.LeftStyleCombo);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(187, 418);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Left Axis Const Line";
			// 
			// EndZScroll
			// 
			this.EndZScroll.Location = new System.Drawing.Point(7, 383);
			this.EndZScroll.Maximum = 110;
			this.EndZScroll.Name = "EndZScroll";
			this.EndZScroll.Size = new System.Drawing.Size(148, 18);
			this.EndZScroll.TabIndex = 16;
			this.EndZScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.EndZScroll_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 367);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(148, 14);
			this.label2.TabIndex = 15;
			this.label2.Text = "End X Value:";
			// 
			// UseBeginEndZCheck
			// 
			this.UseBeginEndZCheck.ButtonProperties.BorderOffset = 2;
			this.UseBeginEndZCheck.Location = new System.Drawing.Point(7, 298);
			this.UseBeginEndZCheck.Name = "UseBeginEndZCheck";
			this.UseBeginEndZCheck.Size = new System.Drawing.Size(148, 21);
			this.UseBeginEndZCheck.TabIndex = 14;
			this.UseBeginEndZCheck.Text = "Use Begin-End Z Values";
			this.UseBeginEndZCheck.CheckedChanged += new System.EventHandler(this.UseBeginEndZCheck_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(7, 323);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(148, 16);
			this.label4.TabIndex = 13;
			this.label4.Text = "Begin Z Value:";
			// 
			// BeginZScroll
			// 
			this.BeginZScroll.Location = new System.Drawing.Point(7, 341);
			this.BeginZScroll.Maximum = 110;
			this.BeginZScroll.Name = "BeginZScroll";
			this.BeginZScroll.Size = new System.Drawing.Size(148, 18);
			this.BeginZScroll.TabIndex = 12;
			this.BeginZScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BeginZScroll_ValueChanged);
			// 
			// EndXScroll
			// 
			this.EndXScroll.Location = new System.Drawing.Point(7, 252);
			this.EndXScroll.Maximum = 110;
			this.EndXScroll.Name = "EndXScroll";
			this.EndXScroll.Size = new System.Drawing.Size(148, 18);
			this.EndXScroll.TabIndex = 11;
			this.EndXScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.EndXScroll_Scroll);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(7, 236);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(148, 14);
			this.label7.TabIndex = 10;
			this.label7.Text = "End X Value:";
			// 
			// UseBeginEndXCheck
			// 
			this.UseBeginEndXCheck.ButtonProperties.BorderOffset = 2;
			this.UseBeginEndXCheck.Location = new System.Drawing.Point(7, 167);
			this.UseBeginEndXCheck.Name = "UseBeginEndXCheck";
			this.UseBeginEndXCheck.Size = new System.Drawing.Size(148, 21);
			this.UseBeginEndXCheck.TabIndex = 9;
			this.UseBeginEndXCheck.Text = "Use Begin-End X Values";
			this.UseBeginEndXCheck.CheckedChanged += new System.EventHandler(this.UseBeginEndXCheck_CheckedChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(7, 192);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(148, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "Begin X Value:";
			// 
			// BeginXScroll
			// 
			this.BeginXScroll.Location = new System.Drawing.Point(7, 210);
			this.BeginXScroll.Maximum = 110;
			this.BeginXScroll.Name = "BeginXScroll";
			this.BeginXScroll.Size = new System.Drawing.Size(148, 18);
			this.BeginXScroll.TabIndex = 7;
			this.BeginXScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BeginXScroll_Scroll);
			// 
			// LeftFillFillStyleButton
			// 
			this.LeftFillFillStyleButton.Location = new System.Drawing.Point(7, 108);
			this.LeftFillFillStyleButton.Name = "LeftFillFillStyleButton";
			this.LeftFillFillStyleButton.Size = new System.Drawing.Size(148, 21);
			this.LeftFillFillStyleButton.TabIndex = 6;
			this.LeftFillFillStyleButton.Text = "Fill Style...";
			this.LeftFillFillStyleButton.Click += new System.EventHandler(this.LeftFillFillStyleButton_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(148, 15);
			this.label3.TabIndex = 5;
			this.label3.Text = "Style:";
			// 
			// LeftValue
			// 
			this.LeftValue.Location = new System.Drawing.Point(7, 38);
			this.LeftValue.Maximum = 110;
			this.LeftValue.Name = "LeftValue";
			this.LeftValue.Size = new System.Drawing.Size(148, 17);
			this.LeftValue.TabIndex = 4;
			this.LeftValue.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftValue_Scroll);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(148, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Value:";
			// 
			// LeftPropsButton
			// 
			this.LeftPropsButton.Location = new System.Drawing.Point(7, 131);
			this.LeftPropsButton.Name = "LeftPropsButton";
			this.LeftPropsButton.Size = new System.Drawing.Size(148, 21);
			this.LeftPropsButton.TabIndex = 2;
			this.LeftPropsButton.Text = "Line Style...";
			this.LeftPropsButton.Click += new System.EventHandler(this.LeftPropsButton_Click);
			// 
			// LeftStyleCombo
			// 
			this.LeftStyleCombo.Location = new System.Drawing.Point(7, 80);
			this.LeftStyleCombo.Name = "LeftStyleCombo";
			this.LeftStyleCombo.Size = new System.Drawing.Size(148, 21);
			this.LeftStyleCombo.TabIndex = 1;
			this.LeftStyleCombo.SelectedIndexChanged += new System.EventHandler(this.LeftStyleCombo_SelectedIndexChanged);
			// 
			// NConstLines3DUC
			// 
			this.Controls.Add(this.groupBox1);
			this.Name = "NConstLines3DUC";
			this.Size = new System.Drawing.Size(187, 573);
			this.groupBox1.ResumeLayout(false);
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
			m_Chart.Enable3D = true;

            // configure the axes
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = new NLinearScaleConfigurator();

            NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();

            // add interlaced stripe to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            linearScale.StripStyles.Add(stripStyle);

            m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;

            // apply predefined lighting and projection
            m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
            m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

            // apply 1:1:1 aspect
			m_Chart.Depth = 70;
			m_Chart.Width = 70;
			m_Chart.Height = 70;
			m_Chart.BoundsMode = BoundsMode.Fit;

			// Create a point series
			NPointSeries pnt = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);
			pnt.InflateMargins = true;
			pnt.UseXValues = true;
			pnt.UseZValues = true;
			pnt.Name = "Series 1";
			pnt.DataLabelStyle.Visible = false;

			// Add some data
			pnt.Values.Add(31);
			pnt.Values.Add(67);
			pnt.Values.Add(12);
			pnt.Values.Add(84);
			pnt.Values.Add(90);

			pnt.XValues.Add(5);
			pnt.XValues.Add(27);
			pnt.XValues.Add(49);
			pnt.XValues.Add(78);
			pnt.XValues.Add(93);

			pnt.ZValues.Add(9);
			pnt.ZValues.Add(57);
			pnt.ZValues.Add(89);
			pnt.ZValues.Add(31);
			pnt.ZValues.Add(49);

			// Add a constline for the left axis
			NAxisConstLine constLine = m_Chart.Axis(StandardAxis.PrimaryY).ConstLines.Add();
			constLine.StrokeStyle.Color = Color.Blue;
            constLine.FillStyle = new NColorFillStyle(new NArgbColor(125, Color.SteelBlue));
			constLine.Value = 50.0;

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			LeftStyleCombo.SelectedIndex = (int)ConstLineMode.Plane;
			LeftValue.Value = (int)constLine.Value;

			BeginXScroll.Value = 10;
			EndXScroll.Value = 80;
			BeginXScroll.Enabled = false;
			EndXScroll.Enabled = false;

			BeginZScroll.Value = 10;
			EndZScroll.Value = 80;
			BeginZScroll.Enabled = false;
			EndZScroll.Enabled = false;

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

		private void LeftValue_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryY).ConstLines[0];

			cl.Value = LeftValue.Value;

			nChartControl1.Refresh();
		}

		private void LeftFillFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryY).ConstLines[0];
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(cl.FillStyle, out fillStyleResult))
			{
				cl.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void LeftStyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryY).ConstLines[0];

			switch(LeftStyleCombo.SelectedIndex)
			{
				case 0:
					cl.Mode = ConstLineMode.Line;
					LeftFillFillStyleButton.Enabled = false;
					break;

				case 1:
					cl.Mode = ConstLineMode.Plane;
					LeftFillFillStyleButton.Enabled = true;
					break;
			}

			nChartControl1.Refresh();
		}


		private void UseBeginEndXCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateReferenceAxisRanges();
			nChartControl1.Refresh();
		}

		private void BeginXScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			UpdateReferenceAxisRanges();
			nChartControl1.Refresh();
		}

		private void EndXScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			UpdateReferenceAxisRanges();
			nChartControl1.Refresh();
		}

		private void UseBeginEndZCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateReferenceAxisRanges();
			nChartControl1.Refresh();		
		}

		private void BeginZScroll_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			UpdateReferenceAxisRanges();
			nChartControl1.Refresh();		
		}

		private void EndZScroll_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			UpdateReferenceAxisRanges();
			nChartControl1.Refresh();		
		}


		private void UpdateReferenceAxisRanges()
		{
			NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryY).ConstLines[0];

			cl.ReferenceRanges.Clear();

			if(UseBeginEndXCheck.Checked)
			{
				NAxis axisX = m_Chart.Axis(StandardAxis.PrimaryX);
				double refBeginValue = BeginXScroll.Value;
				double refEndValue = EndXScroll.Value;
				cl.ReferenceRanges.Add(new NReferenceAxisRange(axisX, refBeginValue, refEndValue));

				BeginXScroll.Enabled = true;
				EndXScroll.Enabled = true;
			}
			else
			{
				BeginXScroll.Enabled = false;
				EndXScroll.Enabled = false;
			}

			if(UseBeginEndZCheck.Checked)
			{
				NAxis axisZ = m_Chart.Axis(StandardAxis.Depth);
				double refBeginValue = BeginZScroll.Value;
				double refEndValue = EndZScroll.Value;
				cl.ReferenceRanges.Add(new NReferenceAxisRange(axisZ, refBeginValue, refEndValue));

				BeginZScroll.Enabled = true;
				EndZScroll.Enabled = true;
			}
			else
			{
				BeginZScroll.Enabled = false;
				EndZScroll.Enabled = false;
			}
		}

	}
}
