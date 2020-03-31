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
	public class NOverlappedLineUC : NExampleBaseUC
	{
		private NLineSeries m_Line1;
		private NLineSeries m_Line2;
		private Nevron.UI.WinForm.Controls.NButton Line1ColorButton1;
		private Nevron.UI.WinForm.Controls.NButton Line2ColorButton;
		private Nevron.UI.WinForm.Controls.NColorDialog colorDlg;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NComboBox LineStyleCombo;
		private Nevron.UI.WinForm.Controls.NButton NewDataButton;
		private System.ComponentModel.Container components = null;

		public NOverlappedLineUC()
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NOverlappedLineUC));
			this.Line1ColorButton1 = new Nevron.UI.WinForm.Controls.NButton();
			this.Line2ColorButton = new Nevron.UI.WinForm.Controls.NButton();
			this.colorDlg = new Nevron.UI.WinForm.Controls.NColorDialog();
			this.label5 = new System.Windows.Forms.Label();
			this.LineStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.NewDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// Line1ColorButton1
			// 
			this.Line1ColorButton1.Location = new System.Drawing.Point(9, 63);
			this.Line1ColorButton1.Name = "Line1ColorButton1";
			this.Line1ColorButton1.Size = new System.Drawing.Size(162, 24);
			this.Line1ColorButton1.TabIndex = 0;
			this.Line1ColorButton1.Text = "Line 1 Color";
			this.Line1ColorButton1.Click += new System.EventHandler(this.Line1ColorButton1_Click);
			// 
			// Line2ColorButton
			// 
			this.Line2ColorButton.Location = new System.Drawing.Point(9, 94);
			this.Line2ColorButton.Name = "Line2ColorButton";
			this.Line2ColorButton.Size = new System.Drawing.Size(162, 24);
			this.Line2ColorButton.TabIndex = 1;
			this.Line2ColorButton.Text = "Line 2 Color";
			this.Line2ColorButton.Click += new System.EventHandler(this.Line2ColorButton_Click);
			// 
			// colorDlg
			// 
			this.colorDlg.ClientSize = new System.Drawing.Size(413, 351);
			this.colorDlg.Color = System.Drawing.Color.Empty;
			this.colorDlg.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.colorDlg.Icon = ((System.Drawing.Icon)(resources.GetObject("colorDlg.Icon")));
			this.colorDlg.Location = new System.Drawing.Point(176, 184);
			this.colorDlg.MaximizeBox = false;
			this.colorDlg.MinimizeBox = false;
			this.colorDlg.Name = "colorDlg";
			this.colorDlg.ShowCaptionImage = false;
			this.colorDlg.ShowInTaskbar = false;
			this.colorDlg.Sizable = false;
			this.colorDlg.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.colorDlg.Text = "Edit Color";
			this.colorDlg.Visible = false;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(9, 6);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(162, 16);
			this.label5.TabIndex = 13;
			this.label5.Text = "Line Style:";
			// 
			// LineStyleCombo
			// 
			this.LineStyleCombo.ListProperties.CheckBoxDataMember = "";
			this.LineStyleCombo.ListProperties.DataSource = null;
			this.LineStyleCombo.ListProperties.DisplayMember = "";
			this.LineStyleCombo.Location = new System.Drawing.Point(9, 24);
			this.LineStyleCombo.Name = "LineStyleCombo";
			this.LineStyleCombo.Size = new System.Drawing.Size(162, 21);
			this.LineStyleCombo.TabIndex = 12;
			this.LineStyleCombo.SelectedIndexChanged += new System.EventHandler(this.LineStyleCombo_SelectedIndexChanged);
			// 
			// NewDataButton
			// 
			this.NewDataButton.Location = new System.Drawing.Point(9, 148);
			this.NewDataButton.Name = "NewDataButton";
			this.NewDataButton.Size = new System.Drawing.Size(162, 24);
			this.NewDataButton.TabIndex = 14;
			this.NewDataButton.Text = "New Data";
			this.NewDataButton.Click += new System.EventHandler(this.NewDataButton_Click);
			// 
			// NOverlappedLineUC
			// 
			this.Controls.Add(this.NewDataButton);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.LineStyleCombo);
			this.Controls.Add(this.Line2ColorButton);
			this.Controls.Add(this.Line1ColorButton1);
			this.Name = "NOverlappedLineUC";
			this.Size = new System.Drawing.Size(180, 179);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Overlapped Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 65;
			chart.Height = 40;
			chart.Axis(StandardAxis.Depth).Visible = false;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

            // add interlaced stripe to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            ((NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

			m_Line1 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			m_Line1.Name = "Line 1";
			m_Line1.DataLabelStyle.Visible = false;

			m_Line2 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			m_Line2.Name = "Line 2";
			m_Line2.MultiLineMode = MultiLineMode.Overlapped;
			m_Line2.DataLabelStyle.Visible = false;

			GenerateData();

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// form controls
			LineStyleCombo.FillFromEnum(typeof(LineSegmentShape));
			LineStyleCombo.SelectedIndex = 1;
		}


		private void Line1ColorButton1_Click(object sender, System.EventArgs e)
		{
			colorDlg.Color = m_Line1.BorderStyle.Color;

			if (colorDlg.ShowDialog() == DialogResult.Cancel)
				return;

			m_Line1.BorderStyle.Color = colorDlg.Color;
			m_Line1.FillStyle = new NColorFillStyle(colorDlg.Color);
			m_Line1.MarkerStyle.FillStyle = new NColorFillStyle(colorDlg.Color);
			m_Line1.MarkerStyle.BorderStyle.Color = colorDlg.Color;

			nChartControl1.Refresh();
		}

		private void Line2ColorButton_Click(object sender, System.EventArgs e)
		{
			colorDlg.Color = m_Line2.BorderStyle.Color;

			if (colorDlg.ShowDialog() == DialogResult.Cancel)
				return;

			m_Line2.BorderStyle.Color = colorDlg.Color;
			m_Line2.FillStyle = new NColorFillStyle(colorDlg.Color);
			m_Line2.MarkerStyle.FillStyle = new NColorFillStyle(colorDlg.Color);
			m_Line2.MarkerStyle.BorderStyle.Color = colorDlg.Color;

			nChartControl1.Refresh();
		}

		private void LineStyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LineSegmentShape style = (LineSegmentShape)LineStyleCombo.SelectedIndex;

			m_Line1.LineSegmentShape = style;
			m_Line2.LineSegmentShape = style;

			switch(style)
			{
				case LineSegmentShape.Line:
				case LineSegmentShape.Tape:
					m_Line1.MarkerStyle.PointShape = PointShape.Cylinder;
					m_Line2.MarkerStyle.PointShape = PointShape.Cylinder;
					m_Line1.MarkerStyle.Visible = true;
					m_Line2.MarkerStyle.Visible = true;
					m_Line1.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
					m_Line2.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
					m_Line1.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
					m_Line2.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
					m_Line1.DepthPercent = 50;
					m_Line2.DepthPercent = 50;
					break;

				case LineSegmentShape.Tube:
				case LineSegmentShape.Ellipsoid:
					m_Line1.MarkerStyle.PointShape = PointShape.Sphere;
					m_Line2.MarkerStyle.PointShape = PointShape.Sphere;
					m_Line1.MarkerStyle.Visible = true;
					m_Line2.MarkerStyle.Visible = true;
					m_Line1.MarkerStyle.Width = new NLength(2.5f, NRelativeUnit.ParentPercentage);
					m_Line2.MarkerStyle.Width = new NLength(2.5f, NRelativeUnit.ParentPercentage);
					m_Line1.MarkerStyle.Height = new NLength(2.5f, NRelativeUnit.ParentPercentage);
					m_Line2.MarkerStyle.Height = new NLength( 2.5f, NRelativeUnit.ParentPercentage);
					m_Line1.DepthPercent = 10;
					m_Line2.DepthPercent = 10;
					break;
			}

			nChartControl1.Refresh();
		}

		private void NewDataButton_Click(object sender, System.EventArgs e)
		{
			GenerateData();
			nChartControl1.Refresh();
		}

		private void GenerateData()
		{
			m_Line1.Values.Clear();
			m_Line2.Values.Clear();

			for(int i = 0; i < 9; i++)
			{
				m_Line1.Values.Add( Math.Sin(0.6 * i) + 0.5 * Random.NextDouble());
				m_Line2.Values.Add( Math.Cos(0.6 * i) + 0.5 * Random.NextDouble());
			}
		}
	}
}