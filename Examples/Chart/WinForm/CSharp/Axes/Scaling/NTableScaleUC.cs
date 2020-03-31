using System;
using System.ComponentModel;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using System.Diagnostics;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NTableScaleUC : NExampleBaseUC
	{
		private NChart m_Chart;
        private NTableScaleConfigurator m_TableScale;
        private UI.WinForm.Controls.NCheckBox ShowRowInterlacingCheckBox;
        private UI.WinForm.Controls.NCheckBox ShowColumnInterlacingCheckBox;
        private UI.WinForm.Controls.NCheckBox ShowRowHeadersCheckBox;
        private UI.WinForm.Controls.NComboBox LabelFormatComboBox;
        private System.Windows.Forms.Label label12;
		private System.ComponentModel.Container components = null;

		public NTableScaleUC()
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
            this.ShowRowInterlacingCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ShowColumnInterlacingCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ShowRowHeadersCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.LabelFormatComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ShowRowInterlacingCheckBox
            // 
            this.ShowRowInterlacingCheckBox.AutoSize = true;
            this.ShowRowInterlacingCheckBox.ButtonProperties.BorderOffset = 2;
            this.ShowRowInterlacingCheckBox.Location = new System.Drawing.Point(8, 8);
            this.ShowRowInterlacingCheckBox.Name = "ShowRowInterlacingCheckBox";
            this.ShowRowInterlacingCheckBox.Size = new System.Drawing.Size(130, 17);
            this.ShowRowInterlacingCheckBox.TabIndex = 14;
            this.ShowRowInterlacingCheckBox.Text = "Show Row Interlacing";
            this.ShowRowInterlacingCheckBox.UseVisualStyleBackColor = true;
            this.ShowRowInterlacingCheckBox.CheckedChanged += new System.EventHandler(this.ShowRowInterlacingCheckBox_CheckedChanged);
            // 
            // ShowColumnInterlacingCheckBox
            // 
            this.ShowColumnInterlacingCheckBox.AutoSize = true;
            this.ShowColumnInterlacingCheckBox.ButtonProperties.BorderOffset = 2;
            this.ShowColumnInterlacingCheckBox.Location = new System.Drawing.Point(8, 33);
            this.ShowColumnInterlacingCheckBox.Name = "ShowColumnInterlacingCheckBox";
            this.ShowColumnInterlacingCheckBox.Size = new System.Drawing.Size(143, 17);
            this.ShowColumnInterlacingCheckBox.TabIndex = 15;
            this.ShowColumnInterlacingCheckBox.Text = "Show Column Interlacing";
            this.ShowColumnInterlacingCheckBox.UseVisualStyleBackColor = true;
            this.ShowColumnInterlacingCheckBox.CheckedChanged += new System.EventHandler(this.ShowColumnInterlacingCheckBox_CheckedChanged);
            // 
            // ShowRowHeadersCheckBox
            // 
            this.ShowRowHeadersCheckBox.AutoSize = true;
            this.ShowRowHeadersCheckBox.ButtonProperties.BorderOffset = 2;
            this.ShowRowHeadersCheckBox.Location = new System.Drawing.Point(8, 58);
            this.ShowRowHeadersCheckBox.Name = "ShowRowHeadersCheckBox";
            this.ShowRowHeadersCheckBox.Size = new System.Drawing.Size(121, 17);
            this.ShowRowHeadersCheckBox.TabIndex = 16;
            this.ShowRowHeadersCheckBox.Text = "Show Row Headers";
            this.ShowRowHeadersCheckBox.UseVisualStyleBackColor = true;
            this.ShowRowHeadersCheckBox.CheckedChanged += new System.EventHandler(this.ShowRowHeadersCheckBox_CheckedChanged);
            // 
            // LabelFormatComboBox
            // 
            this.LabelFormatComboBox.ListProperties.CheckBoxDataMember = "";
            this.LabelFormatComboBox.ListProperties.DataSource = null;
            this.LabelFormatComboBox.ListProperties.DisplayMember = "";
            this.LabelFormatComboBox.Location = new System.Drawing.Point(8, 105);
            this.LabelFormatComboBox.Name = "LabelFormatComboBox";
            this.LabelFormatComboBox.Size = new System.Drawing.Size(143, 21);
            this.LabelFormatComboBox.TabIndex = 18;
            this.LabelFormatComboBox.SelectedIndexChanged += new System.EventHandler(this.LabelFormatComboBox_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Label Format:";
            // 
            // NTableScaleUC
            // 
            this.Controls.Add(this.LabelFormatComboBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ShowRowHeadersCheckBox);
            this.Controls.Add(this.ShowColumnInterlacingCheckBox);
            this.Controls.Add(this.ShowRowInterlacingCheckBox);
            this.Name = "NTableScaleUC";
            this.Size = new System.Drawing.Size(162, 304);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Table Scale");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;

			m_Chart.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));

			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// configure the y axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);

			// add a strip line style
			NScaleStripStyle stripStyle = new NScaleStripStyle();
			stripStyle.FillStyle = new NColorFillStyle(Color.Beige);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			linearScale.StripStyles.Add(stripStyle);

            Random random = new Random();

            // create two series with random data
            NBarSeries alcoholSales = new NBarSeries();
            alcoholSales.Name = "Alcohol";
            alcoholSales.MultiBarMode = MultiBarMode.Stacked;
            alcoholSales.Values.FillRandom(random, 12);
            alcoholSales.DataLabelStyle.Visible = false;
            m_Chart.Series.Add(alcoholSales);

            NBarSeries beveragesSales = new NBarSeries();
            beveragesSales.Name = "Beverages";
            beveragesSales.MultiBarMode = MultiBarMode.Stacked;
            beveragesSales.Values.FillRandom(random, 12);
            beveragesSales.DataLabelStyle.Visible = false;
            m_Chart.Series.Add(beveragesSales);

            // create a table scale
            m_TableScale = new NTableScaleConfigurator();

            m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = m_TableScale;

            NCustomTableScaleRow customRow = new NCustomTableScaleRow();
            customRow.Items = new object[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            m_TableScale.Rows.Add(customRow);

            for (int i = 0; i < m_Chart.Series.Count; i++)
            {
                NSeriesTableScaleRow row = new NSeriesTableScaleRow();

                row.Series = m_Chart.Series[i];
                m_TableScale.Rows.Add(row);
            }

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

            // apply layout
            ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

            // init form controls
            LabelFormatComboBox.Items.Add("<value>");
            LabelFormatComboBox.Items.Add("<percent>");
            LabelFormatComboBox.SelectedIndex = 0;

            ShowRowHeadersCheckBox.Checked = true;
            ShowColumnInterlacingCheckBox.Checked = true;
            ShowRowInterlacingCheckBox.Checked = true;
		}

        private void ShowRowInterlacingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // row interlacing
            if (ShowRowInterlacingCheckBox.Checked)
            {
                NTableInterlaceStyle interlaceStyle = new NTableInterlaceStyle();

                interlaceStyle.Type = TableInterlaceStyleType.Row;
                interlaceStyle.Length = 1;
                interlaceStyle.Interval = 1;
                interlaceStyle.FillStyle = new NColorFillStyle(Color.FromArgb(124, Color.Beige));

                m_TableScale.InterlaceStyles.Add(interlaceStyle);
            }
            else
            {
                foreach (NTableInterlaceStyle interlaceStyle in m_TableScale.InterlaceStyles)
                {
                    if (interlaceStyle.Type == TableInterlaceStyleType.Row)
                    {
                        m_TableScale.InterlaceStyles.Remove(interlaceStyle);
                        break;
                    }
                }
            }

            nChartControl1.Refresh();
        }

        private void ShowColumnInterlacingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // col interlacing
            if (ShowColumnInterlacingCheckBox.Checked)
            {
                NTableInterlaceStyle interlaceStyle = new NTableInterlaceStyle();

                interlaceStyle.Type = TableInterlaceStyleType.Col;
                interlaceStyle.Length = 1;
                interlaceStyle.Interval = 1;
                interlaceStyle.FillStyle = new NColorFillStyle(Color.FromArgb(124, Color.Red));

                m_TableScale.InterlaceStyles.Add(interlaceStyle);
            }
            else
            {
                foreach (NTableInterlaceStyle interlaceStyle in m_TableScale.InterlaceStyles)
                {
                    if (interlaceStyle.Type == TableInterlaceStyleType.Col)
                    {
                        m_TableScale.InterlaceStyles.Remove(interlaceStyle);
                        break;
                    }
                }
            }

            nChartControl1.Refresh();
        }

        private void ShowRowHeadersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (NTableScaleRow row in m_TableScale.Rows)
            {
                NSeriesTableScaleRow seriesRow = row as NSeriesTableScaleRow;

                if (seriesRow != null)
                {
                    seriesRow.ShowLeftRowHeader = ShowRowHeadersCheckBox.Checked;
                }
            }

            nChartControl1.Refresh();
        }

        private void LabelFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (LabelFormatComboBox.SelectedIndex)
            {
                case 0: // value
                    foreach (NSeriesBase series in m_Chart.Series)
                    {
                        series.Legend.Format = "<value>";
                    }
                    break;
                case 1: // percent
                    foreach (NSeriesBase series in m_Chart.Series)
                    {
                        series.Legend.Format = "<percent>";
                    }
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            nChartControl1.Refresh();
        }
	}
}
