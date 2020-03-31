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
	public class NAxisModelCrossingUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox LeftAxisAlignmentComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox BottomAxisAlignmentComboBox;
		private Nevron.Editors.NLengthEditorUC BottomAxisOffsetUC;
		private Nevron.Editors.NLengthEditorUC LeftAxisOffsetUC;
		private System.ComponentModel.Container components = null;
		private bool m_Updating;

		public NAxisModelCrossingUC()
		{
			m_Updating = true;
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
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.LeftAxisOffsetUC = new Nevron.Editors.NLengthEditorUC();
			this.LeftAxisAlignmentComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.BottomAxisAlignmentComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.BottomAxisOffsetUC = new Nevron.Editors.NLengthEditorUC();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.nGroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 15);
			this.label3.TabIndex = 0;
			this.label3.Text = "Alignment:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.LeftAxisAlignmentComboBox);
			this.groupBox1.Controls.Add(this.LeftAxisOffsetUC);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(7, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(268, 100);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Left Axis";
			// 
			// LeftAxisOffsetUC
			// 
			this.LeftAxisOffsetUC.Location = new System.Drawing.Point(5, 49);
			this.LeftAxisOffsetUC.Name = "LeftAxisOffsetUC";
			this.LeftAxisOffsetUC.Size = new System.Drawing.Size(256, 24);
			this.LeftAxisOffsetUC.TabIndex = 2;
			this.LeftAxisOffsetUC.LengthChanged += new System.EventHandler(this.LeftAxisOffsetUC_LengthChanged);
			// 
			// LeftAxisAlignmentComboBox
			// 
			this.LeftAxisAlignmentComboBox.Location = new System.Drawing.Point(89, 24);
			this.LeftAxisAlignmentComboBox.Name = "LeftAxisAlignmentComboBox";
			this.LeftAxisAlignmentComboBox.Size = new System.Drawing.Size(167, 22);
			this.LeftAxisAlignmentComboBox.TabIndex = 1;
			this.LeftAxisAlignmentComboBox.Text = "nComboBox1";
			this.LeftAxisAlignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.LeftAxisAlignmentComboBox_SelectedIndexChanged);
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.BottomAxisAlignmentComboBox);
			this.nGroupBox1.Controls.Add(this.BottomAxisOffsetUC);
			this.nGroupBox1.Controls.Add(this.label1);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(6, 125);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(268, 100);
			this.nGroupBox1.TabIndex = 1;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Bottom Axis";
			// 
			// BottomAxisAlignmentComboBox
			// 
			this.BottomAxisAlignmentComboBox.Location = new System.Drawing.Point(89, 24);
			this.BottomAxisAlignmentComboBox.Name = "BottomAxisAlignmentComboBox";
			this.BottomAxisAlignmentComboBox.Size = new System.Drawing.Size(167, 22);
			this.BottomAxisAlignmentComboBox.TabIndex = 1;
			this.BottomAxisAlignmentComboBox.Text = "nComboBox1";
			this.BottomAxisAlignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.BottomAxisAlignmentComboBox_SelectedIndexChanged);
			// 
			// BottomAxisOffsetUC
			// 
			this.BottomAxisOffsetUC.Location = new System.Drawing.Point(5, 48);
			this.BottomAxisOffsetUC.Name = "BottomAxisOffsetUC";
			this.BottomAxisOffsetUC.Size = new System.Drawing.Size(256, 24);
			this.BottomAxisOffsetUC.TabIndex = 2;
			this.BottomAxisOffsetUC.LengthChanged += new System.EventHandler(this.BottomAxisOffsetUC_LengthChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Alignment:";
			// 
			// NAxisModelCrossingUC
			// 
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.nGroupBox1);
			this.Name = "NAxisModelCrossingUC";
			this.Size = new System.Drawing.Size(276, 250);
			this.groupBox1.ResumeLayout(false);
			this.nGroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Axis Model Crossing <br/> <font size = '9pt'>Demonstrates how to use of the model cross anchor</font>");
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // no legends
            nChartControl1.Legends.Clear();

			m_Chart = nChartControl1.Charts[0];

            // configure scales
            NLinearScaleConfigurator yScaleConfigurator = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            NScaleStripStyle yStripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(40, Color.LightGray)), null, true, 0, 0, 1, 1);
            yStripStyle.SetShowAtWall(ChartWallType.Back, true);
            yStripStyle.Interlaced = true;
            yScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            yScaleConfigurator.StripStyles.Add(yStripStyle);

            NLinearScaleConfigurator xScaleConfigurator = new NLinearScaleConfigurator();
            NScaleStripStyle xStripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(40, Color.LightGray)), null, true, 0, 0, 1, 1);
            xStripStyle.SetShowAtWall(ChartWallType.Back, true);
            xStripStyle.Interlaced = true;
            xScaleConfigurator.StripStyles.Add(xStripStyle);
            xScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScaleConfigurator;

			// cross X and Y axes
			m_Chart.Axis(StandardAxis.PrimaryX).Anchor = new NCrossAxisAnchor(AxisOrientation.Horizontal, new NValueAxisCrossing(m_Chart.Axis(StandardAxis.PrimaryY), 0));
			m_Chart.Axis(StandardAxis.PrimaryX).Anchor.RulerOrientation = RulerOrientation.Right;

			m_Chart.Axis(StandardAxis.PrimaryY).Anchor = new NCrossAxisAnchor(AxisOrientation.Vertical, new NValueAxisCrossing(m_Chart.Axis(StandardAxis.PrimaryX), 0));

			m_Chart.Axis(StandardAxis.Depth).Visible = false;
			m_Chart.Wall(ChartWallType.Floor).Visible = false;
			m_Chart.Wall(ChartWallType.Left).Visible = false;
			
			// setup bubble series
			NBubbleSeries bubble = (NBubbleSeries)m_Chart.Series.Add(SeriesType.Bubble);
			bubble.Name = "Bubble Series";
			bubble.InflateMargins = true;
			bubble.DataLabelStyle.Visible = false;
			bubble.UseXValues = true;
			bubble.BubbleShape = PointShape.Sphere;

			// fill with random data
			bubble.Values.FillRandomRange(Random, 10, -20, 20);
			bubble.XValues.FillRandomRange(Random, 10, -20, 20);
			bubble.Sizes.FillRandomRange(Random, 10, 1, 6);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);
			
			// init form controls
			LeftAxisAlignmentComboBox.FillFromEnum(typeof(HorzAlign));
			LeftAxisAlignmentComboBox.SelectedIndex = (int)HorzAlign.Center;
			LeftAxisOffsetUC.Length = new NLength(0, NRelativeUnit.ParentPercentage);
			
			BottomAxisAlignmentComboBox.FillFromEnum(typeof(VertAlign));
			BottomAxisAlignmentComboBox.SelectedIndex = (int)HorzAlign.Center;
			BottomAxisOffsetUC.Length = new NLength(0, NRelativeUnit.ParentPercentage);

			m_Updating = false;

			UpdateCrossings();
		}

		private void UpdateCrossings()
		{
			if (m_Updating)
				return;

			NAxis xAxis = m_Chart.Axis(StandardAxis.PrimaryX);
			NAxis yAxis = m_Chart.Axis(StandardAxis.PrimaryY);

			NCrossAxisAnchor crossAnchor; 
			
			// update the x axis anchor
			crossAnchor = new NCrossAxisAnchor();
			xAxis.Anchor = crossAnchor;
			crossAnchor.AxisOrientation = AxisOrientation.Horizontal;
			crossAnchor.Crossings.Add(new NModelAxisCrossing(yAxis, (HorzAlign)this.BottomAxisAlignmentComboBox.SelectedIndex, BottomAxisOffsetUC.Length));
				
			// update the y axis anchor
			crossAnchor = new NCrossAxisAnchor();
			crossAnchor.AxisOrientation = AxisOrientation.Vertical;
			yAxis.Anchor = crossAnchor;
			crossAnchor.Crossings.Add(new NModelAxisCrossing(xAxis, (HorzAlign)this.LeftAxisAlignmentComboBox.SelectedIndex, LeftAxisOffsetUC.Length));

			nChartControl1.Refresh();
		}

		private void LeftAxisOffsetUC_LengthChanged(object sender, System.EventArgs e)
		{
			UpdateCrossings();		
		}

		private void BottomAxisOffsetUC_LengthChanged(object sender, System.EventArgs e)
		{
			UpdateCrossings();
		}

		private void LeftAxisAlignmentComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateCrossings();
		}

		private void BottomAxisAlignmentComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateCrossings();
		}
	}
}