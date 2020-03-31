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
	public class NStripeLabelsUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NHScrollBar LeftBeginScroll;
        private Nevron.UI.WinForm.Controls.NHScrollBar LeftEndScroll;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NHScrollBar BottomEndScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar BottomBeginScroll;
        private Nevron.UI.WinForm.Controls.NButton BottomTitleTextStyleButton;
        private Label label5;
        private Nevron.UI.WinForm.Controls.NTextBox BottomTitleTextBox;
        private Label label6;
        private Nevron.UI.WinForm.Controls.NComboBox BottomTitleAlignmentCombo;
        private Nevron.UI.WinForm.Controls.NButton LeftTitleTextStyleButton;
        private Label label7;
        private Nevron.UI.WinForm.Controls.NTextBox LeftTitleTextBox;
        private Label label8;
        private Nevron.UI.WinForm.Controls.NComboBox LeftTitleAlignmentCombo;
		private System.ComponentModel.Container components = null;

		public NStripeLabelsUC()
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
            this.LeftBeginScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
            this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.LeftTitleTextStyleButton = new Nevron.UI.WinForm.Controls.NButton();
            this.label7 = new System.Windows.Forms.Label();
            this.LeftTitleTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.LeftTitleAlignmentCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LeftEndScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
            this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.BottomTitleTextStyleButton = new Nevron.UI.WinForm.Controls.NButton();
            this.label5 = new System.Windows.Forms.Label();
            this.BottomTitleTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BottomTitleAlignmentCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BottomEndScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
            this.BottomBeginScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftBeginScroll
            // 
            this.LeftBeginScroll.Location = new System.Drawing.Point(9, 41);
            this.LeftBeginScroll.Maximum = 110;
            this.LeftBeginScroll.MinimumSize = new System.Drawing.Size(32, 16);
            this.LeftBeginScroll.Name = "LeftBeginScroll";
            this.LeftBeginScroll.Size = new System.Drawing.Size(148, 16);
            this.LeftBeginScroll.TabIndex = 0;
            this.LeftBeginScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftBeginScroll_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LeftTitleTextStyleButton);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.LeftTitleTextBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.LeftTitleAlignmentCombo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LeftEndScroll);
            this.groupBox1.Controls.Add(this.LeftBeginScroll);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ImageIndex = 0;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 240);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Left Axis Stripe";
            // 
            // LeftTitleTextStyleButton
            // 
            this.LeftTitleTextStyleButton.Location = new System.Drawing.Point(9, 201);
            this.LeftTitleTextStyleButton.Name = "LeftTitleTextStyleButton";
            this.LeftTitleTextStyleButton.Size = new System.Drawing.Size(148, 21);
            this.LeftTitleTextStyleButton.TabIndex = 54;
            this.LeftTitleTextStyleButton.Text = "Text Style...";
            this.LeftTitleTextStyleButton.Click += new System.EventHandler(this.LeftTitleTextStyleButton_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 15);
            this.label7.TabIndex = 53;
            this.label7.Text = "Text:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LeftTitleTextBox
            // 
            this.LeftTitleTextBox.Location = new System.Drawing.Point(7, 177);
            this.LeftTitleTextBox.Name = "LeftTitleTextBox";
            this.LeftTitleTextBox.Size = new System.Drawing.Size(150, 18);
            this.LeftTitleTextBox.TabIndex = 52;
            this.LeftTitleTextBox.TextChanged += new System.EventHandler(this.LeftTitleTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(9, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 15);
            this.label8.TabIndex = 51;
            this.label8.Text = "Content Alignment:";
            // 
            // LeftTitleAlignmentCombo
            // 
            this.LeftTitleAlignmentCombo.Location = new System.Drawing.Point(9, 135);
            this.LeftTitleAlignmentCombo.Name = "LeftTitleAlignmentCombo";
            this.LeftTitleAlignmentCombo.Size = new System.Drawing.Size(148, 21);
            this.LeftTitleAlignmentCombo.TabIndex = 50;
            this.LeftTitleAlignmentCombo.SelectedIndexChanged += new System.EventHandler(this.LeftTitleAlignmentCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "End Value:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Begin Value:";
            // 
            // LeftEndScroll
            // 
            this.LeftEndScroll.Location = new System.Drawing.Point(9, 86);
            this.LeftEndScroll.Maximum = 110;
            this.LeftEndScroll.MinimumSize = new System.Drawing.Size(32, 16);
            this.LeftEndScroll.Name = "LeftEndScroll";
            this.LeftEndScroll.Size = new System.Drawing.Size(148, 16);
            this.LeftEndScroll.TabIndex = 1;
            this.LeftEndScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftEndScroll_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BottomTitleTextStyleButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.BottomTitleTextBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.BottomTitleAlignmentCombo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.BottomEndScroll);
            this.groupBox2.Controls.Add(this.BottomBeginScroll);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.ImageIndex = 0;
            this.groupBox2.Location = new System.Drawing.Point(0, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(174, 263);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bottom Axis Stripe";
            // 
            // BottomTitleTextStyleButton
            // 
            this.BottomTitleTextStyleButton.Location = new System.Drawing.Point(9, 211);
            this.BottomTitleTextStyleButton.Name = "BottomTitleTextStyleButton";
            this.BottomTitleTextStyleButton.Size = new System.Drawing.Size(148, 21);
            this.BottomTitleTextStyleButton.TabIndex = 54;
            this.BottomTitleTextStyleButton.Text = "Text Style...";
            this.BottomTitleTextStyleButton.Click += new System.EventHandler(this.BottomTitleTextStyleButton_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 53;
            this.label5.Text = "Text:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BottomTitleTextBox
            // 
            this.BottomTitleTextBox.Location = new System.Drawing.Point(7, 187);
            this.BottomTitleTextBox.Name = "BottomTitleTextBox";
            this.BottomTitleTextBox.Size = new System.Drawing.Size(150, 18);
            this.BottomTitleTextBox.TabIndex = 52;
            this.BottomTitleTextBox.TextChanged += new System.EventHandler(this.BottomTitleTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 15);
            this.label6.TabIndex = 51;
            this.label6.Text = "Content Alignment:";
            // 
            // BottomTitleAlignmentCombo
            // 
            this.BottomTitleAlignmentCombo.Location = new System.Drawing.Point(9, 145);
            this.BottomTitleAlignmentCombo.Name = "BottomTitleAlignmentCombo";
            this.BottomTitleAlignmentCombo.Size = new System.Drawing.Size(148, 21);
            this.BottomTitleAlignmentCombo.TabIndex = 50;
            this.BottomTitleAlignmentCombo.SelectedIndexChanged += new System.EventHandler(this.BottomTitleAlignmentCombo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "End Value:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Begin Value:";
            // 
            // BottomEndScroll
            // 
            this.BottomEndScroll.Location = new System.Drawing.Point(9, 99);
            this.BottomEndScroll.Maximum = 110;
            this.BottomEndScroll.MinimumSize = new System.Drawing.Size(32, 16);
            this.BottomEndScroll.Name = "BottomEndScroll";
            this.BottomEndScroll.Size = new System.Drawing.Size(148, 16);
            this.BottomEndScroll.TabIndex = 8;
            this.BottomEndScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomEndScroll_Scroll);
            // 
            // BottomBeginScroll
            // 
            this.BottomBeginScroll.Location = new System.Drawing.Point(9, 41);
            this.BottomBeginScroll.Maximum = 110;
            this.BottomBeginScroll.MinimumSize = new System.Drawing.Size(32, 16);
            this.BottomBeginScroll.Name = "BottomBeginScroll";
            this.BottomBeginScroll.Size = new System.Drawing.Size(148, 16);
            this.BottomBeginScroll.TabIndex = 7;
            this.BottomBeginScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomBeginScroll_Scroll);
            // 
            // NStripeLabelsUC
            // 
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "NStripeLabelsUC";
            this.Size = new System.Drawing.Size(174, 539);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Axis Stripes");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = new NLinearScaleConfigurator();

            // configure the x and y scales
            NLinearScaleConfigurator yScale = new NLinearScaleConfigurator();

            // add interlaced stripe to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            yScale.StripStyles.Add(stripStyle);

            // display major grid lines at back and left walls
            yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
            yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

            m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = yScale;

            NLinearScaleConfigurator xScale = new NLinearScaleConfigurator();
            xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
            xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale;

			// Create a point series
			NPointSeries pnt = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);
			pnt.InflateMargins = true;
			pnt.UseXValues = true;
			pnt.Name = "Series 1";
			pnt.DataLabelStyle.Format = "<value>";

			// Add some data
			pnt.Values.Add(3.1);
			pnt.Values.Add(6.7);
			pnt.Values.Add(1.2);
			pnt.Values.Add(8.4);
			pnt.Values.Add(9.0);
			pnt.XValues.Add(0.5);
			pnt.XValues.Add(1.8);
			pnt.XValues.Add(2.6);
			pnt.XValues.Add(3.1);
			pnt.XValues.Add(4.4);

			// Add stripes for the left and the bottom axes
			NAxisStripe s1 = m_Chart.Axis(StandardAxis.PrimaryY).Stripes.Add(2, 3);
            s1.FillStyle = new NColorFillStyle(Color.FromArgb(125, Color.SteelBlue));

			NAxisStripe s2 = m_Chart.Axis(StandardAxis.PrimaryX).Stripes.Add(2, 3);
            s2.FillStyle = new NColorFillStyle(Color.FromArgb(125, Color.SteelBlue));

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			LeftBeginScroll.Value = (int)(s1.From * 10);
			LeftEndScroll.Value = (int)(s1.To * 10);
			BottomBeginScroll.Value = (int)(s2.From * 20);
			BottomEndScroll.Value = (int)(s2.To * 20);

            LeftTitleAlignmentCombo.FillFromEnum(typeof(ContentAlignment));
            LeftTitleAlignmentCombo.SelectedItem = ContentAlignment.TopLeft.ToString();

            BottomTitleAlignmentCombo.FillFromEnum(typeof(ContentAlignment));
            BottomTitleAlignmentCombo.SelectedItem = ContentAlignment.TopLeft.ToString();

            LeftTitleTextBox.Text = "Left Axis Const Line Title";
            BottomTitleTextBox.Text = "Bottom Axis Const Line Title";

			nChartControl1.Refresh();
		}

		private void LeftBeginScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryY).Stripes[0];

			stripe.From = LeftBeginScroll.Value / 10.0;

			nChartControl1.Refresh();
		}

		private void LeftEndScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryY).Stripes[0];

			stripe.To = LeftEndScroll.Value / 10.0;

			nChartControl1.Refresh();
		}

		private void BottomBeginScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryX).Stripes[0];

			stripe.From = BottomBeginScroll.Value / 20.0;

			nChartControl1.Refresh();
		}

		private void BottomEndScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryX).Stripes[0];

			stripe.To = BottomEndScroll.Value / 20.0;

			nChartControl1.Refresh();
		}

		private void LeftFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryY).Stripes[0];
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(stripe.FillStyle, out fillStyleResult))
			{
				stripe.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void BottomFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryX).Stripes[0];
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(stripe.FillStyle, out fillStyleResult))
			{
				stripe.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

        private void LeftTitleAlignmentCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryY).Stripes[0];
            stripe.TextAlignment = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), LeftTitleAlignmentCombo.SelectedItem.ToString());

            nChartControl1.Refresh();
        }

        private void LeftTitleTextBox_TextChanged(object sender, EventArgs e)
        {
            NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryY).Stripes[0];
            stripe.Text = LeftTitleTextBox.Text;

            nChartControl1.Refresh();
        }

        private void LeftTitleTextStyleButton_Click(object sender, EventArgs e)
        {
            NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryY).Stripes[0];

            NTextStyle textStyle;

            if (NTextStyleTypeEditor.Edit(stripe.TextStyle, out textStyle))
            {
                stripe.TextStyle = textStyle;
                nChartControl1.Refresh();
            }
        }

        private void BottomTitleAlignmentCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryX).Stripes[0];
            stripe.TextAlignment = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), BottomTitleAlignmentCombo.SelectedItem.ToString());

            nChartControl1.Refresh();
        }

        private void BottomTitleTextBox_TextChanged(object sender, EventArgs e)
        {
            NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryX).Stripes[0];
            stripe.Text = BottomTitleTextBox.Text;

            nChartControl1.Refresh();
        }

        private void BottomTitleTextStyleButton_Click(object sender, EventArgs e)
        {
            NAxisStripe stripe = (NAxisStripe)m_Chart.Axis(StandardAxis.PrimaryX).Stripes[0];
            NTextStyle textStyle;

            if (NTextStyleTypeEditor.Edit(stripe.TextStyle, out textStyle))
            {
                stripe.TextStyle = textStyle;
                nChartControl1.Refresh();
            }
        }
	}
}