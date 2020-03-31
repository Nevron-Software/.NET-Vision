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
	public class NConstLineLabelsUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
        private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NHScrollBar LeftValue;
        private Nevron.UI.WinForm.Controls.NHScrollBar BottomValue;
        private Label label3;
        private Nevron.UI.WinForm.Controls.NComboBox LeftTitleAlignmentCombo;
        private Label label4;
        private Nevron.UI.WinForm.Controls.NTextBox LeftTitleTextBox;
        private Label label5;
        private Nevron.UI.WinForm.Controls.NTextBox BottomTitleTextBox;
        private Label label6;
        private Nevron.UI.WinForm.Controls.NComboBox BottomTitleAlignmentCombo;
        private Nevron.UI.WinForm.Controls.NButton BottomAxisTextStyleButton;
        private Nevron.UI.WinForm.Controls.NButton LeftAxisTextStyleButton;
		private System.ComponentModel.Container components = null;

		public NConstLineLabelsUC()
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
            this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.BottomAxisTextStyleButton = new Nevron.UI.WinForm.Controls.NButton();
            this.label5 = new System.Windows.Forms.Label();
            this.BottomValue = new Nevron.UI.WinForm.Controls.NHScrollBar();
            this.BottomTitleTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BottomTitleAlignmentCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.LeftAxisTextStyleButton = new Nevron.UI.WinForm.Controls.NButton();
            this.label4 = new System.Windows.Forms.Label();
            this.LeftTitleTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LeftTitleAlignmentCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.LeftValue = new Nevron.UI.WinForm.Controls.NHScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BottomAxisTextStyleButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.BottomValue);
            this.groupBox2.Controls.Add(this.BottomTitleTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.BottomTitleAlignmentCombo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.ImageIndex = 0;
            this.groupBox2.Location = new System.Drawing.Point(0, 241);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(174, 241);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bottom Axis Const Line";
            // 
            // BottomAxisTextStyleButton
            // 
            this.BottomAxisTextStyleButton.Location = new System.Drawing.Point(13, 148);
            this.BottomAxisTextStyleButton.Name = "BottomAxisTextStyleButton";
            this.BottomAxisTextStyleButton.Size = new System.Drawing.Size(148, 21);
            this.BottomAxisTextStyleButton.TabIndex = 49;
            this.BottomAxisTextStyleButton.Text = "Text Style...";
            this.BottomAxisTextStyleButton.Click += new System.EventHandler(this.BottomAxisTextStyleButton_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 48;
            this.label5.Text = "Text:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BottomValue
            // 
            this.BottomValue.Location = new System.Drawing.Point(13, 38);
            this.BottomValue.Maximum = 110;
            this.BottomValue.MinimumSize = new System.Drawing.Size(32, 16);
            this.BottomValue.Name = "BottomValue";
            this.BottomValue.Size = new System.Drawing.Size(140, 17);
            this.BottomValue.TabIndex = 3;
            this.BottomValue.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomValue_Scroll);
            // 
            // BottomTitleTextBox
            // 
            this.BottomTitleTextBox.Location = new System.Drawing.Point(11, 124);
            this.BottomTitleTextBox.Name = "BottomTitleTextBox";
            this.BottomTitleTextBox.Size = new System.Drawing.Size(150, 18);
            this.BottomTitleTextBox.TabIndex = 47;
            this.BottomTitleTextBox.TextChanged += new System.EventHandler(this.BottomTitleTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Value:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(13, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 15);
            this.label6.TabIndex = 46;
            this.label6.Text = "Content Alignment:";
            // 
            // BottomTitleAlignmentCombo
            // 
            this.BottomTitleAlignmentCombo.Location = new System.Drawing.Point(13, 82);
            this.BottomTitleAlignmentCombo.Name = "BottomTitleAlignmentCombo";
            this.BottomTitleAlignmentCombo.Size = new System.Drawing.Size(148, 21);
            this.BottomTitleAlignmentCombo.TabIndex = 45;
            this.BottomTitleAlignmentCombo.SelectedIndexChanged += new System.EventHandler(this.BottomTitleAlignmentCombo_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LeftAxisTextStyleButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.LeftTitleTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LeftTitleAlignmentCombo);
            this.groupBox1.Controls.Add(this.LeftValue);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ImageIndex = 0;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 241);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Left Axis Const Line";
            // 
            // LeftAxisTextStyleButton
            // 
            this.LeftAxisTextStyleButton.Location = new System.Drawing.Point(13, 141);
            this.LeftAxisTextStyleButton.Name = "LeftAxisTextStyleButton";
            this.LeftAxisTextStyleButton.Size = new System.Drawing.Size(148, 21);
            this.LeftAxisTextStyleButton.TabIndex = 45;
            this.LeftAxisTextStyleButton.Text = "Text Style...";
            this.LeftAxisTextStyleButton.Click += new System.EventHandler(this.LeftAxisTextStyleButton_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 44;
            this.label4.Text = "Text:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LeftTitleTextBox
            // 
            this.LeftTitleTextBox.Location = new System.Drawing.Point(11, 117);
            this.LeftTitleTextBox.Name = "LeftTitleTextBox";
            this.LeftTitleTextBox.Size = new System.Drawing.Size(150, 18);
            this.LeftTitleTextBox.TabIndex = 43;
            this.LeftTitleTextBox.TextChanged += new System.EventHandler(this.LeftTitleTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Content Alignment:";
            // 
            // LeftTitleAlignmentCombo
            // 
            this.LeftTitleAlignmentCombo.Location = new System.Drawing.Point(13, 75);
            this.LeftTitleAlignmentCombo.Name = "LeftTitleAlignmentCombo";
            this.LeftTitleAlignmentCombo.Size = new System.Drawing.Size(148, 21);
            this.LeftTitleAlignmentCombo.TabIndex = 6;
            this.LeftTitleAlignmentCombo.SelectedIndexChanged += new System.EventHandler(this.LeftTitleAlignmentCombo_SelectedIndexChanged);
            // 
            // LeftValue
            // 
            this.LeftValue.Location = new System.Drawing.Point(13, 38);
            this.LeftValue.Maximum = 110;
            this.LeftValue.MinimumSize = new System.Drawing.Size(32, 16);
            this.LeftValue.Name = "LeftValue";
            this.LeftValue.Size = new System.Drawing.Size(148, 17);
            this.LeftValue.TabIndex = 4;
            this.LeftValue.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftValue_Scroll);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Value:";
            // 
            // NConstLineLabelsUC
            // 
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "NConstLineLabelsUC";
            this.Size = new System.Drawing.Size(174, 539);
            this.groupBox2.ResumeLayout(false);
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

            LeftTitleAlignmentCombo.FillFromEnum(typeof(ContentAlignment));
			LeftTitleAlignmentCombo.SelectedIndex = 0;

            BottomTitleAlignmentCombo.FillFromEnum(typeof(ContentAlignment));
			BottomTitleAlignmentCombo.SelectedIndex = 0;

            LeftTitleTextBox.Text = "Left Axis Const Line Title";
            BottomTitleTextBox.Text = "Bottom Axis Const Line Title";

			nChartControl1.Refresh();
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

        private void LeftTitleAlignmentCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryY).ConstLines[0];
            cl.TextAlignment = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), LeftTitleAlignmentCombo.SelectedItem.ToString());

            nChartControl1.Refresh();
        }

        private void LeftTitleTextBox_TextChanged(object sender, EventArgs e)
        {
            NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryY).ConstLines[0];
            cl.Text = LeftTitleTextBox.Text;

            nChartControl1.Refresh();
        }

        private void LeftAxisTextStyleButton_Click(object sender, EventArgs e)
        {
            NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryY).ConstLines[0];

            NTextStyle textStyle;

            if (NTextStyleTypeEditor.Edit(cl.TextStyle, out textStyle))
            {
                cl.TextStyle = textStyle;
                nChartControl1.Refresh();
            }
        }

        private void BottomTitleAlignmentCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryX).ConstLines[0];
            cl.TextAlignment = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), BottomTitleAlignmentCombo.SelectedItem.ToString());

            nChartControl1.Refresh();
        }

        private void BottomTitleTextBox_TextChanged(object sender, EventArgs e)
        {
            NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryX).ConstLines[0];
            cl.Text = BottomTitleTextBox.Text;

            nChartControl1.Refresh();
        }

        private void BottomAxisTextStyleButton_Click(object sender, EventArgs e)
        {
            NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryX).ConstLines[0];
            NTextStyle textStyle;

            if (NTextStyleTypeEditor.Edit(cl.TextStyle, out textStyle))
            {
                cl.TextStyle = textStyle;
                nChartControl1.Refresh();
            }
        }
	}
}
