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
	public class NAxisTitlesUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NHScrollBar YOffsetScrollBar;
		private Nevron.UI.WinForm.Controls.NComboBox YAlignmentComboBox;
		private Nevron.UI.WinForm.Controls.NButton YTitleStyleButton;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NTextBox YTitleTextBox;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NHScrollBar XOffsetScrollBar;
		private Nevron.UI.WinForm.Controls.NComboBox XAlignmentComboBox;
		private Nevron.UI.WinForm.Controls.NButton XTitleStyleButton;
		private System.Windows.Forms.Label label6;
		private Nevron.UI.WinForm.Controls.NTextBox XTitleTextBox;
		private System.ComponentModel.Container components = null;

		public NAxisTitlesUC()
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
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.YOffsetScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.YAlignmentComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.YTitleStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.YTitleTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.XOffsetScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.XAlignmentComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.XTitleStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label6 = new System.Windows.Forms.Label();
			this.XTitleTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.nGroupBox1.SuspendLayout();
			this.nGroupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.label3);
			this.nGroupBox1.Controls.Add(this.label2);
			this.nGroupBox1.Controls.Add(this.YOffsetScrollBar);
			this.nGroupBox1.Controls.Add(this.YAlignmentComboBox);
			this.nGroupBox1.Controls.Add(this.YTitleStyleButton);
			this.nGroupBox1.Controls.Add(this.label1);
			this.nGroupBox1.Controls.Add(this.YTitleTextBox);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(7, 8);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(172, 214);
			this.nGroupBox1.TabIndex = 18;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Y Axis Title";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 168);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(137, 15);
			this.label3.TabIndex = 22;
			this.label3.Text = "Title Offset:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(137, 15);
			this.label2.TabIndex = 21;
			this.label2.Text = "Title Alignment:";
			// 
			// YOffsetScrollBar
			// 
			this.YOffsetScrollBar.LargeChange = 2;
			this.YOffsetScrollBar.Location = new System.Drawing.Point(16, 184);
			this.YOffsetScrollBar.Maximum = 30;
			this.YOffsetScrollBar.Name = "YOffsetScrollBar";
			this.YOffsetScrollBar.Size = new System.Drawing.Size(137, 16);
			this.YOffsetScrollBar.TabIndex = 20;
			this.YOffsetScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.YOffsetScrollBar_ValueChanged);
			// 
			// YAlignmentComboBox
			// 
			this.YAlignmentComboBox.Location = new System.Drawing.Point(16, 128);
			this.YAlignmentComboBox.Name = "YAlignmentComboBox";
			this.YAlignmentComboBox.Size = new System.Drawing.Size(137, 21);
			this.YAlignmentComboBox.TabIndex = 19;
			this.YAlignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.YAlignmentComboBox_SelectedIndexChanged);
			// 
			// YTitleStyleButton
			// 
			this.YTitleStyleButton.Location = new System.Drawing.Point(16, 72);
			this.YTitleStyleButton.Name = "YTitleStyleButton";
			this.YTitleStyleButton.Size = new System.Drawing.Size(137, 24);
			this.YTitleStyleButton.TabIndex = 18;
			this.YTitleStyleButton.Text = "Title Text Style...";
			this.YTitleStyleButton.Click += new System.EventHandler(this.YTitleStyleButton_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(137, 15);
			this.label1.TabIndex = 17;
			this.label1.Text = "Title Text:";
			// 
			// YTitleTextBox
			// 
			this.YTitleTextBox.ErrorMessage = null;
			this.YTitleTextBox.Location = new System.Drawing.Point(16, 40);
			this.YTitleTextBox.Name = "YTitleTextBox";
			this.YTitleTextBox.Size = new System.Drawing.Size(137, 18);
			this.YTitleTextBox.TabIndex = 16;
			this.YTitleTextBox.TextChanged += new System.EventHandler(this.YTitleTextBox_TextChanged);
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.label4);
			this.nGroupBox2.Controls.Add(this.label5);
			this.nGroupBox2.Controls.Add(this.XOffsetScrollBar);
			this.nGroupBox2.Controls.Add(this.XAlignmentComboBox);
			this.nGroupBox2.Controls.Add(this.XTitleStyleButton);
			this.nGroupBox2.Controls.Add(this.label6);
			this.nGroupBox2.Controls.Add(this.XTitleTextBox);
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(7, 235);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(172, 214);
			this.nGroupBox2.TabIndex = 23;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "X Axis Title";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(137, 15);
			this.label4.TabIndex = 22;
			this.label4.Text = "Title Offset:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(137, 15);
			this.label5.TabIndex = 21;
			this.label5.Text = "Title Alignment:";
			// 
			// XOffsetScrollBar
			// 
			this.XOffsetScrollBar.LargeChange = 2;
			this.XOffsetScrollBar.Location = new System.Drawing.Point(16, 184);
			this.XOffsetScrollBar.Maximum = 30;
			this.XOffsetScrollBar.Name = "XOffsetScrollBar";
			this.XOffsetScrollBar.Size = new System.Drawing.Size(137, 16);
			this.XOffsetScrollBar.TabIndex = 20;
			this.XOffsetScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.XOffsetScrollBar_ValueChanged);
			// 
			// XAlignmentComboBox
			// 
			this.XAlignmentComboBox.Location = new System.Drawing.Point(16, 128);
			this.XAlignmentComboBox.Name = "XAlignmentComboBox";
			this.XAlignmentComboBox.Size = new System.Drawing.Size(137, 21);
			this.XAlignmentComboBox.TabIndex = 19;
			this.XAlignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.XAlignmentComboBox_SelectedIndexChanged);
			// 
			// XTitleStyleButton
			// 
			this.XTitleStyleButton.Location = new System.Drawing.Point(16, 72);
			this.XTitleStyleButton.Name = "XTitleStyleButton";
			this.XTitleStyleButton.Size = new System.Drawing.Size(137, 24);
			this.XTitleStyleButton.TabIndex = 18;
			this.XTitleStyleButton.Text = "Title Text Style...";
			this.XTitleStyleButton.Click += new System.EventHandler(this.XTitleStyleButton_Click);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(137, 15);
			this.label6.TabIndex = 17;
			this.label6.Text = "Title Text:";
			// 
			// XTitleTextBox
			// 
			this.XTitleTextBox.ErrorMessage = null;
			this.XTitleTextBox.Location = new System.Drawing.Point(16, 40);
			this.XTitleTextBox.Name = "XTitleTextBox";
			this.XTitleTextBox.Size = new System.Drawing.Size(137, 18);
			this.XTitleTextBox.TabIndex = 16;
			this.XTitleTextBox.TextChanged += new System.EventHandler(this.XTitleTextBox_TextChanged);
			// 
			// NAxisTitlesUC
			// 
			this.Controls.Add(this.nGroupBox1);
			this.Controls.Add(this.nGroupBox2);
			this.Name = "NAxisTitlesUC";
			this.Size = new System.Drawing.Size(188, 470);
			this.nGroupBox1.ResumeLayout(false);
			this.nGroupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Axis Titles");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            nChartControl1.Legends[0].Mode = LegendMode.Disabled;

			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;

			NStandardScaleConfigurator scaleConfiguratorY = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

            // add interlaced stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            scaleConfiguratorY.StripStyles.Add(stripStyle);

			NStandardScaleConfigurator scaleConfiguratorX = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;

			NBarSeries bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			bar.Values.FillRandom(Random, 20);
			bar.Name = "Bars";
			bar.DataLabelStyle.Visible = false;

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			YTitleTextBox.Text = "Y Axis Title";
			XTitleTextBox.Text = "X Axis Title";

			YOffsetScrollBar.Value = 10;
			XOffsetScrollBar.Value = 10;

			YAlignmentComboBox.Items.Add("Top");
			YAlignmentComboBox.Items.Add("Middle");
			YAlignmentComboBox.Items.Add("Bottom");
			YAlignmentComboBox.SelectedIndex = 1;

			XAlignmentComboBox.Items.Add("Left");
			XAlignmentComboBox.Items.Add("Center");
			XAlignmentComboBox.Items.Add("Right");
			XAlignmentComboBox.SelectedIndex = 1;
		}


		private void YTitleStyleButton_Click(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			NTextStyle textStyleResult;

			if (NTextStyleTypeEditor.Edit(scaleConfigurator.Title.TextStyle, out textStyleResult))
			{
				scaleConfigurator.Title.TextStyle = textStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void XTitleStyleButton_Click(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			NTextStyle textStyleResult;

			if (NTextStyleTypeEditor.Edit(scaleConfigurator.Title.TextStyle, out textStyleResult))
			{
				scaleConfigurator.Title.TextStyle = textStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void YOffsetScrollBar_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			scaleConfigurator.Title.Offset = new NLength(YOffsetScrollBar.Value, NGraphicsUnit.Pixel);

			nChartControl1.Refresh();
		}

		private void XOffsetScrollBar_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;

			scaleConfigurator.Title.Offset = new NLength(XOffsetScrollBar.Value, NGraphicsUnit.Pixel);

			nChartControl1.Refresh();
		}

		private void YTitleTextBox_TextChanged(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfiguratorY = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			scaleConfiguratorY.Title.Text = YTitleTextBox.Text;

			nChartControl1.Refresh();
		}

		private void XTitleTextBox_TextChanged(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfiguratorX = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;

			scaleConfiguratorX.Title.Text = XTitleTextBox.Text;

			nChartControl1.Refresh();
		}

		private void YAlignmentComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfiguratorY = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			switch(YAlignmentComboBox.SelectedIndex)
			{
				case 0:
					scaleConfiguratorY.Title.ContentAlignment = ContentAlignment.MiddleRight;
					scaleConfiguratorY.Title.RulerAlignment = HorzAlign.Right;
					break;

				case 1:
					scaleConfiguratorY.Title.ContentAlignment = ContentAlignment.MiddleCenter;
					scaleConfiguratorY.Title.RulerAlignment = HorzAlign.Center;
					break;

				case 2:
					scaleConfiguratorY.Title.ContentAlignment = ContentAlignment.MiddleLeft;
					scaleConfiguratorY.Title.RulerAlignment = HorzAlign.Left;
					break;
			}

			nChartControl1.Refresh();
		}

		private void XAlignmentComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scaleConfiguratorX = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;

			switch(XAlignmentComboBox.SelectedIndex)
			{
				case 0:
					scaleConfiguratorX.Title.ContentAlignment = ContentAlignment.MiddleLeft;
					scaleConfiguratorX.Title.RulerAlignment = HorzAlign.Left;
					break;

				case 1:
					scaleConfiguratorX.Title.ContentAlignment = ContentAlignment.MiddleCenter;
					scaleConfiguratorX.Title.RulerAlignment = HorzAlign.Center;
					break;

				case 2:
					scaleConfiguratorX.Title.ContentAlignment = ContentAlignment.MiddleRight;
					scaleConfiguratorX.Title.RulerAlignment = HorzAlign.Right;
					break;
			}

			nChartControl1.Refresh();
		}
	}
}
