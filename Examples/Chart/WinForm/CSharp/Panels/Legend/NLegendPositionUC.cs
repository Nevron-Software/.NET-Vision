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
	public class NLegendPositionUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label TransparencyLabel;
		private Nevron.UI.WinForm.Controls.NHScrollBar TransparencyScrollBar;
		private Nevron.UI.WinForm.Controls.NCheckBox HasShadowCheckBox;
		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowLegendGridCheckBox;
		private System.Windows.Forms.Label ContentAlignmentLabel;
		private Nevron.UI.WinForm.Controls.NCheckBox UseAutomaticSizeCheckBox;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NComboBox ContentAlignmentComboBox;
		private Nevron.Editors.NPointEditorUC LocationEditorUC;
		private Nevron.Editors.NSizeLEditorUC SizeEditorUC;
		private NLegend m_Legend;

		public NLegendPositionUC()
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
			this.ContentAlignmentLabel = new System.Windows.Forms.Label();
			this.TransparencyLabel = new System.Windows.Forms.Label();
			this.TransparencyScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.HasShadowCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowLegendGridCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.UseAutomaticSizeCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.LocationEditorUC = new Nevron.Editors.NPointEditorUC();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.SizeEditorUC = new Nevron.Editors.NSizeLEditorUC();
			this.ContentAlignmentComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// ContentAlignmentLabel
			// 
			this.ContentAlignmentLabel.Location = new System.Drawing.Point(8, 162);
			this.ContentAlignmentLabel.Name = "ContentAlignmentLabel";
			this.ContentAlignmentLabel.Size = new System.Drawing.Size(266, 22);
			this.ContentAlignmentLabel.TabIndex = 3;
			this.ContentAlignmentLabel.Text = "ContentAlignment:";
			this.ContentAlignmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TransparencyLabel
			// 
			this.TransparencyLabel.Location = new System.Drawing.Point(8, 266);
			this.TransparencyLabel.Name = "TransparencyLabel";
			this.TransparencyLabel.Size = new System.Drawing.Size(266, 16);
			this.TransparencyLabel.TabIndex = 7;
			this.TransparencyLabel.Text = "Transparency:";
			this.TransparencyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TransparencyScrollBar
			// 
			this.TransparencyScrollBar.Location = new System.Drawing.Point(8, 288);
			this.TransparencyScrollBar.Maximum = 110;
			this.TransparencyScrollBar.Name = "TransparencyScrollBar";
			this.TransparencyScrollBar.Size = new System.Drawing.Size(266, 16);
			this.TransparencyScrollBar.TabIndex = 8;
			this.TransparencyScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.TransparencyScrollBar_ValueChanged);
			// 
			// HasShadowCheckBox
			// 
			this.HasShadowCheckBox.Location = new System.Drawing.Point(8, 210);
			this.HasShadowCheckBox.Name = "HasShadowCheckBox";
			this.HasShadowCheckBox.Size = new System.Drawing.Size(266, 25);
			this.HasShadowCheckBox.TabIndex = 5;
			this.HasShadowCheckBox.Text = "Has shadow";
			this.HasShadowCheckBox.CheckedChanged += new System.EventHandler(this.HasShadowCheckBox_CheckedChanged);
			// 
			// ShowLegendGridCheckBox
			// 
			this.ShowLegendGridCheckBox.Location = new System.Drawing.Point(8, 236);
			this.ShowLegendGridCheckBox.Name = "ShowLegendGridCheckBox";
			this.ShowLegendGridCheckBox.Size = new System.Drawing.Size(266, 25);
			this.ShowLegendGridCheckBox.TabIndex = 6;
			this.ShowLegendGridCheckBox.Text = "Show legend grid";
			this.ShowLegendGridCheckBox.CheckedChanged += new System.EventHandler(this.ShowLegendGridCheckBox_CheckedChanged);
			// 
			// UseAutomaticSizeCheckBox
			// 
			this.UseAutomaticSizeCheckBox.Location = new System.Drawing.Point(8, 69);
			this.UseAutomaticSizeCheckBox.Name = "UseAutomaticSizeCheckBox";
			this.UseAutomaticSizeCheckBox.Size = new System.Drawing.Size(266, 24);
			this.UseAutomaticSizeCheckBox.TabIndex = 1;
			this.UseAutomaticSizeCheckBox.Text = "Use automatic size";
			this.UseAutomaticSizeCheckBox.CheckedChanged += new System.EventHandler(this.UseAutomaticSizeCheckBox_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.LocationEditorUC);
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(8, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(266, 68);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Location";
			// 
			// LocationEditorUC
			// 
			this.LocationEditorUC.Location = new System.Drawing.Point(7, 16);
			this.LocationEditorUC.Name = "LocationEditorUC";
			this.LocationEditorUC.Size = new System.Drawing.Size(252, 45);
			this.LocationEditorUC.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.SizeEditorUC);
			this.groupBox2.ImageIndex = 0;
			this.groupBox2.Location = new System.Drawing.Point(8, 93);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(266, 68);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Size";
			// 
			// SizeEditorUC
			// 
			this.SizeEditorUC.Location = new System.Drawing.Point(7, 16);
			this.SizeEditorUC.Name = "SizeEditorUC";
			this.SizeEditorUC.Size = new System.Drawing.Size(252, 45);
			this.SizeEditorUC.TabIndex = 0;
			// 
			// ContentAlignmentComboBox
			// 
			this.ContentAlignmentComboBox.Location = new System.Drawing.Point(8, 184);
			this.ContentAlignmentComboBox.Name = "ContentAlignmentComboBox";
			this.ContentAlignmentComboBox.Size = new System.Drawing.Size(266, 21);
			this.ContentAlignmentComboBox.TabIndex = 4;
			this.ContentAlignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.ContentAlignmentComboBox_SelectedIndexChanged);
			// 
			// NLegendPositioningUC
			// 
			this.Controls.Add(this.ShowLegendGridCheckBox);
			this.Controls.Add(this.HasShadowCheckBox);
			this.Controls.Add(this.TransparencyScrollBar);
			this.Controls.Add(this.TransparencyLabel);
			this.Controls.Add(this.ContentAlignmentComboBox);
			this.Controls.Add(this.ContentAlignmentLabel);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.UseAutomaticSizeCheckBox);
			this.Controls.Add(this.groupBox1);
			this.Name = "NLegendPositioningUC";
			this.Size = new System.Drawing.Size(280, 578);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			InitChartAndLegend();

			// init form controls
			LocationEditorUC.Point = m_Legend.Location;

			UseAutomaticSizeCheckBox.Checked = m_Legend.UseAutomaticSize;
			SizeEditorUC.SizeL = m_Legend.Size;

			string[] names = Enum.GetNames(typeof(ContentAlignment));
			for (int i = 0; i < names.Length; i++)
			{
				ContentAlignmentComboBox.Items.Add(names[i]);
			}
		
			ContentAlignmentComboBox.SelectedItem = m_Legend.ContentAlignment.ToString();
			HasShadowCheckBox.Checked = (m_Legend.ShadowStyle.Type != ShadowType.None);
			TransparencyScrollBar.Value = 100 - (int)(m_Legend.FillStyle.GetPrimaryColor().ToColor().A * 100.0f / 255.0f);
			ShowLegendGridCheckBox.Checked = true;

			LocationEditorUC.PointChanged += new EventHandler(OnLegendLocationChanged);
			SizeEditorUC.SizeLChanged += new EventHandler(OnLegendSizeChanged);
		}

		private void InitChartAndLegend()
		{
            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Legend Position");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // there is one legend by default when the chart is initialized
			m_Legend = (NLegend)nChartControl1.Legends[0];

			// switch the legend to manual mode
			m_Legend.Data.ExpandMode = LegendExpandMode.RowsFixed;
			m_Legend.Data.RowCount = 4;

			m_Legend.Header.Text = "EU Parliament Election";
			m_Legend.Footer.Text = "Number of seats for 2004";
            m_Legend.ShadowStyle.Offset = new NPointL(3, 3);

			// now configure the chart to display some information
            NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.Enable3D = true;
            chart.Axis(StandardAxis.Depth).Visible = false;
            chart.Axis(StandardAxis.PrimaryX).Visible = false;

            // apply predefined projection and lighting
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight);

            // add interlace stripe
            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

            // add bar and change bar color
            NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            bar.Name = "Bar Series";
            bar.DataLabelStyle.Visible = true;
            bar.Legend.Mode = SeriesLegendMode.DataPoints;

            bar.AddDataPoint(new NDataPoint(39, "EUL"));
            bar.AddDataPoint(new NDataPoint(200, "PES"));
            bar.AddDataPoint(new NDataPoint(42, "EFA"));
            bar.AddDataPoint(new NDataPoint(15, "EDD"));
            bar.AddDataPoint(new NDataPoint(67, "ELDR"));
            bar.AddDataPoint(new NDataPoint(276, "EPP"));
            bar.AddDataPoint(new NDataPoint(27, "UEN"));
            bar.AddDataPoint(new NDataPoint(66, "Other"));

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.NevronMultiColor);
            styleSheet.Apply(nChartControl1.Document);
        }

		private void HasShadowCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if (HasShadowCheckBox.Checked)
			{
				m_Legend.ShadowStyle.Type = ShadowType.Solid;
			}
			else
			{
				m_Legend.ShadowStyle.Type = ShadowType.None;
			}

			nChartControl1.Refresh();
		}

		private void LegendHeaderFontButton_Click(object sender, System.EventArgs e)
		{
			NTextStyle textStyleResult;

			if (NTextStyleTypeEditor.Edit(m_Legend.Header.TextStyle, out textStyleResult))
			{
				m_Legend.Header.TextStyle = textStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void LegendFooterFontButton_Click(object sender, System.EventArgs e)
		{
			NTextStyle textStyleResult;

			if (NTextStyleTypeEditor.Edit(m_Legend.Footer.TextStyle, out textStyleResult))
			{
				m_Legend.Footer.TextStyle = textStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void ShowLegendGridCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			int nWidht;

			if (ShowLegendGridCheckBox.Checked == true)
			{
				nWidht = 1;
			}
			else
			{
				nWidht = 0;
			}

			m_Legend.VerticalBorderStyle.Width = new NLength(nWidht, NGraphicsUnit.Pixel);
			m_Legend.HorizontalBorderStyle.Width = new NLength(nWidht, NGraphicsUnit.Pixel);

			nChartControl1.Refresh();
		}

		private void OnLegendLocationChanged(object sender, System.EventArgs e)
		{
			m_Legend.Location = LocationEditorUC.Point;

			nChartControl1.Refresh();
		}

		private void OnLegendSizeChanged(object sender, System.EventArgs e)
		{
			m_Legend.Size = SizeEditorUC.SizeL;

			nChartControl1.Refresh();
		}

		private void UseAutomaticSizeCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Legend.UseAutomaticSize = UseAutomaticSizeCheckBox.Checked;
			SizeEditorUC.Enabled = !UseAutomaticSizeCheckBox.Checked;

			nChartControl1.Refresh();
		}

		private void ContentAlignmentComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Array values = Enum.GetValues(typeof(ContentAlignment));
			m_Legend.ContentAlignment = (ContentAlignment)values.GetValue(ContentAlignmentComboBox.SelectedIndex);

			nChartControl1.Refresh();
		}

		private void TransparencyScrollBar_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Legend.FillStyle.SetTransparencyPercent(TransparencyScrollBar.Value);
			nChartControl1.Refresh();
		}
	}
}
