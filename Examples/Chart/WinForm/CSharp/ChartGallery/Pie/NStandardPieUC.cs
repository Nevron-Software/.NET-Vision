using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NStandardPieUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private Nevron.UI.WinForm.Controls.NComboBox PieShapeCombo;
		private Nevron.UI.WinForm.Controls.NComboBox PieLabelModeCombo;
		private Nevron.UI.WinForm.Controls.NHScrollBar BeginAngleScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar TotalAngleScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar ArrowLengthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar ArrowPointerLengthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar EdgePercentScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar InnerRadiusScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar OuterRadiusScroll;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox3;
		private Label label10;
		private Nevron.UI.WinForm.Controls.NHScrollBar ConnectorLengthScroll;
		private Label label11;
		private Nevron.UI.WinForm.Controls.NHScrollBar LeadOffLengthScroll;
		private System.ComponentModel.Container components = null;

		public NStandardPieUC()
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
			this.label1 = new System.Windows.Forms.Label();
			this.PieShapeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.BeginAngleScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label5 = new System.Windows.Forms.Label();
			this.TotalAngleScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label6 = new System.Windows.Forms.Label();
			this.PieLabelModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.ArrowLengthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label8 = new System.Windows.Forms.Label();
			this.ArrowPointerLengthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.EdgePercentScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label3 = new System.Windows.Forms.Label();
			this.InnerRadiusScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.OuterRadiusScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.ConnectorLengthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label11 = new System.Windows.Forms.Label();
			this.LeadOffLengthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nGroupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.groupBox1.SuspendLayout();
			this.nGroupBox1.SuspendLayout();
			this.nGroupBox2.SuspendLayout();
			this.nGroupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(178, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Shape:";
			// 
			// PieShapeCombo
			// 
			this.PieShapeCombo.ListProperties.CheckBoxDataMember = "";
			this.PieShapeCombo.ListProperties.DataSource = null;
			this.PieShapeCombo.ListProperties.DisplayMember = "";
			this.PieShapeCombo.Location = new System.Drawing.Point(12, 37);
			this.PieShapeCombo.Name = "PieShapeCombo";
			this.PieShapeCombo.Size = new System.Drawing.Size(151, 21);
			this.PieShapeCombo.TabIndex = 1;
			this.PieShapeCombo.SelectedIndexChanged += new System.EventHandler(this.PieShapeCombo_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 20);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(178, 15);
			this.label4.TabIndex = 6;
			this.label4.Text = "Begin Angle:";
			// 
			// BeginAngleScroll
			// 
			this.BeginAngleScroll.Location = new System.Drawing.Point(12, 37);
			this.BeginAngleScroll.Maximum = 370;
			this.BeginAngleScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.BeginAngleScroll.Name = "BeginAngleScroll";
			this.BeginAngleScroll.Size = new System.Drawing.Size(151, 16);
			this.BeginAngleScroll.TabIndex = 7;
			this.BeginAngleScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BeginAngleScroll_Scroll);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 67);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(178, 15);
			this.label5.TabIndex = 8;
			this.label5.Text = "Total Angle:";
			// 
			// TotalAngleScroll
			// 
			this.TotalAngleScroll.Location = new System.Drawing.Point(12, 82);
			this.TotalAngleScroll.Maximum = 370;
			this.TotalAngleScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.TotalAngleScroll.Name = "TotalAngleScroll";
			this.TotalAngleScroll.Size = new System.Drawing.Size(151, 16);
			this.TotalAngleScroll.TabIndex = 9;
			this.TotalAngleScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.TotalAngleScroll_Scroll);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(12, 22);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(153, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "Label Mode:";
			// 
			// PieLabelModeCombo
			// 
			this.PieLabelModeCombo.ListProperties.CheckBoxDataMember = "";
			this.PieLabelModeCombo.ListProperties.DataSource = null;
			this.PieLabelModeCombo.ListProperties.DisplayMember = "";
			this.PieLabelModeCombo.Location = new System.Drawing.Point(12, 41);
			this.PieLabelModeCombo.Name = "PieLabelModeCombo";
			this.PieLabelModeCombo.Size = new System.Drawing.Size(153, 21);
			this.PieLabelModeCombo.TabIndex = 11;
			this.PieLabelModeCombo.SelectedIndexChanged += new System.EventHandler(this.PieLabelModeCombo_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(12, 69);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(153, 16);
			this.label7.TabIndex = 15;
			this.label7.Text = "Arrow Length:";
			// 
			// ArrowLengthScroll
			// 
			this.ArrowLengthScroll.LargeChange = 1;
			this.ArrowLengthScroll.Location = new System.Drawing.Point(12, 86);
			this.ArrowLengthScroll.Maximum = 20;
			this.ArrowLengthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.ArrowLengthScroll.Name = "ArrowLengthScroll";
			this.ArrowLengthScroll.Size = new System.Drawing.Size(153, 16);
			this.ArrowLengthScroll.TabIndex = 16;
			this.ArrowLengthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ArrowLengthScroll_Scroll);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(12, 112);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(153, 15);
			this.label8.TabIndex = 17;
			this.label8.Text = "Pointer Length:";
			// 
			// ArrowPointerLengthScroll
			// 
			this.ArrowPointerLengthScroll.LargeChange = 1;
			this.ArrowPointerLengthScroll.Location = new System.Drawing.Point(12, 127);
			this.ArrowPointerLengthScroll.Maximum = 20;
			this.ArrowPointerLengthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.ArrowPointerLengthScroll.Name = "ArrowPointerLengthScroll";
			this.ArrowPointerLengthScroll.Size = new System.Drawing.Size(153, 16);
			this.ArrowPointerLengthScroll.TabIndex = 18;
			this.ArrowPointerLengthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ArrowPointerLengthScroll_Scroll);
			// 
			// EdgePercentScroll
			// 
			this.EdgePercentScroll.Enabled = false;
			this.EdgePercentScroll.LargeChange = 1;
			this.EdgePercentScroll.Location = new System.Drawing.Point(12, 82);
			this.EdgePercentScroll.Maximum = 51;
			this.EdgePercentScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.EdgePercentScroll.Name = "EdgePercentScroll";
			this.EdgePercentScroll.Size = new System.Drawing.Size(151, 16);
			this.EdgePercentScroll.TabIndex = 23;
			this.EdgePercentScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.PieEdgeScrollBar_Scroll);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 66);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(178, 15);
			this.label3.TabIndex = 22;
			this.label3.Text = "Edge Percent:";
			// 
			// InnerRadiusScroll
			// 
			this.InnerRadiusScroll.LargeChange = 1;
			this.InnerRadiusScroll.Location = new System.Drawing.Point(12, 78);
			this.InnerRadiusScroll.Maximum = 60;
			this.InnerRadiusScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.InnerRadiusScroll.Name = "InnerRadiusScroll";
			this.InnerRadiusScroll.Size = new System.Drawing.Size(151, 16);
			this.InnerRadiusScroll.TabIndex = 27;
			this.InnerRadiusScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.InnerRadiusScroll_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(178, 15);
			this.label2.TabIndex = 26;
			this.label2.Text = "Inner Radius:";
			// 
			// OuterRadiusScroll
			// 
			this.OuterRadiusScroll.LargeChange = 1;
			this.OuterRadiusScroll.Location = new System.Drawing.Point(12, 39);
			this.OuterRadiusScroll.Maximum = 60;
			this.OuterRadiusScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.OuterRadiusScroll.Name = "OuterRadiusScroll";
			this.OuterRadiusScroll.Size = new System.Drawing.Size(151, 16);
			this.OuterRadiusScroll.TabIndex = 25;
			this.OuterRadiusScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.OuterRadiusScroll_ValueChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(12, 22);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(178, 16);
			this.label9.TabIndex = 24;
			this.label9.Text = "Outer Radius:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.OuterRadiusScroll);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.InnerRadiusScroll);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(3, 117);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(177, 101);
			this.groupBox1.TabIndex = 30;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Pie Dimensions";
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.label10);
			this.nGroupBox1.Controls.Add(this.ConnectorLengthScroll);
			this.nGroupBox1.Controls.Add(this.label11);
			this.nGroupBox1.Controls.Add(this.LeadOffLengthScroll);
			this.nGroupBox1.Controls.Add(this.PieLabelModeCombo);
			this.nGroupBox1.Controls.Add(this.label6);
			this.nGroupBox1.Controls.Add(this.label7);
			this.nGroupBox1.Controls.Add(this.ArrowLengthScroll);
			this.nGroupBox1.Controls.Add(this.label8);
			this.nGroupBox1.Controls.Add(this.ArrowPointerLengthScroll);
			this.nGroupBox1.Location = new System.Drawing.Point(3, 228);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(177, 241);
			this.nGroupBox1.TabIndex = 31;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Pie Labels";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(11, 155);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(153, 16);
			this.label10.TabIndex = 19;
			this.label10.Text = "Label Connector Length:";
			// 
			// ConnectorLengthScroll
			// 
			this.ConnectorLengthScroll.LargeChange = 1;
			this.ConnectorLengthScroll.Location = new System.Drawing.Point(11, 172);
			this.ConnectorLengthScroll.Maximum = 50;
			this.ConnectorLengthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.ConnectorLengthScroll.Name = "ConnectorLengthScroll";
			this.ConnectorLengthScroll.Size = new System.Drawing.Size(153, 16);
			this.ConnectorLengthScroll.TabIndex = 20;
			this.ConnectorLengthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ConnectorLengthScroll_ValueChanged);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(11, 198);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(153, 15);
			this.label11.TabIndex = 21;
			this.label11.Text = "Lead-off Arrow Length:";
			// 
			// LeadOffLengthScroll
			// 
			this.LeadOffLengthScroll.LargeChange = 1;
			this.LeadOffLengthScroll.Location = new System.Drawing.Point(11, 213);
			this.LeadOffLengthScroll.Maximum = 50;
			this.LeadOffLengthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.LeadOffLengthScroll.Name = "LeadOffLengthScroll";
			this.LeadOffLengthScroll.Size = new System.Drawing.Size(153, 16);
			this.LeadOffLengthScroll.TabIndex = 22;
			this.LeadOffLengthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeadOffLengthScroll_ValueChanged);
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.TotalAngleScroll);
			this.nGroupBox2.Controls.Add(this.label4);
			this.nGroupBox2.Controls.Add(this.BeginAngleScroll);
			this.nGroupBox2.Controls.Add(this.label5);
			this.nGroupBox2.Location = new System.Drawing.Point(3, 472);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(177, 105);
			this.nGroupBox2.TabIndex = 31;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Angles";
			// 
			// nGroupBox3
			// 
			this.nGroupBox3.Controls.Add(this.PieShapeCombo);
			this.nGroupBox3.Controls.Add(this.label1);
			this.nGroupBox3.Controls.Add(this.label3);
			this.nGroupBox3.Controls.Add(this.EdgePercentScroll);
			this.nGroupBox3.Location = new System.Drawing.Point(3, 3);
			this.nGroupBox3.Name = "nGroupBox3";
			this.nGroupBox3.Size = new System.Drawing.Size(177, 109);
			this.nGroupBox3.TabIndex = 32;
			this.nGroupBox3.TabStop = false;
			this.nGroupBox3.Text = "Pie Shape";
			// 
			// NStandardPieUC
			// 
			this.Controls.Add(this.nGroupBox3);
			this.Controls.Add(this.nGroupBox2);
			this.Controls.Add(this.nGroupBox1);
			this.Controls.Add(this.groupBox1);
			this.Name = "NStandardPieUC";
			this.Size = new System.Drawing.Size(180, 585);
			this.groupBox1.ResumeLayout(false);
			this.nGroupBox1.ResumeLayout(false);
			this.nGroupBox2.ResumeLayout(false);
			this.nGroupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Clear();
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("3D Pie Chart Shapes");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup the legend
			NLegend legend = nChartControl1.Legends[0];
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.BottomRight);

			NPieChart pieChart = new NPieChart();
			pieChart.Enable3D = true;

			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(pieChart);

			NPointLightSource ls = new NPointLightSource();
			ls.CoordinateMode = LightSourceCoordinateMode.Camera;
			ls.Position = new NVector3DF(0, 0, 50);
			ls.Ambient = Color.FromArgb(30, 30, 30);
			ls.Diffuse = Color.FromArgb(180, 180, 180);
			ls.Specular = Color.FromArgb(100, 100, 100);

			pieChart.LightModel.LightSources.Clear();
			pieChart.LightModel.LightSources.Add(ls);

			pieChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated);
			pieChart.Depth = 10;
			pieChart.DisplayOnLegend = nChartControl1.Legends[0];
			pieChart.Location = new NPointL(new NLength(20, NRelativeUnit.ParentPercentage), new NLength(20, NRelativeUnit.ParentPercentage));
			pieChart.Size = new NSizeL(new NLength(60, NRelativeUnit.ParentPercentage), new NLength(60, NRelativeUnit.ParentPercentage));
			pieChart.InnerRadius = new NLength(20, NRelativeUnit.ParentPercentage);

			NPieSeries pieSeries = (NPieSeries)pieChart.Series.Add(SeriesType.Pie);
			pieSeries.BorderStyle.Color = Color.LemonChiffon;
			
			pieSeries.DataLabelStyle.ArrowLength = new NLength(10, NGraphicsUnit.Point);
			pieSeries.DataLabelStyle.ArrowPointerLength = new NLength(0, NGraphicsUnit.Point);

			pieSeries.Legend.Mode = SeriesLegendMode.DataPoints;
			pieSeries.Legend.Format = "<label> <percent>";

			pieSeries.AddDataPoint(new NDataPoint(24, "Cars", new NColorFillStyle(Color.FromArgb(169, 121, 11))));
			pieSeries.AddDataPoint(new NDataPoint(18, "Airplanes", new NColorFillStyle(Color.FromArgb(157, 157, 92))));
			pieSeries.AddDataPoint(new NDataPoint(32, "Trains", new NColorFillStyle(Color.FromArgb(98, 152, 92))));
			pieSeries.AddDataPoint(new NDataPoint(23, "Ships", new NColorFillStyle(Color.FromArgb(111, 134, 181))));
			pieSeries.AddDataPoint(new NDataPoint(19, "Buses", new NColorFillStyle(Color.FromArgb(179, 63, 92))));

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);

			// init form controls
			PieShapeCombo.FillFromEnum(typeof(PieStyle));
			PieShapeCombo.SelectedIndex = (int)PieStyle.Ring;

			PieLabelModeCombo.FillFromEnum(typeof(PieLabelMode));
			PieLabelModeCombo.SelectedIndex = 0;

			EdgePercentScroll.Value = (int)pieSeries.PieEdgePercent;
			OuterRadiusScroll.Value = (int)pieChart.Radius.Value;
			InnerRadiusScroll.Value = (int)pieChart.InnerRadius.Value;

			ArrowLengthScroll.Value = (int)pieSeries.DataLabelStyle.ArrowLength.Value;
			ArrowPointerLengthScroll.Value = (int)pieSeries.DataLabelStyle.ArrowPointerLength.Value;
			ConnectorLengthScroll.Value = (int)pieSeries.ConnectorLength.Value;
			LeadOffLengthScroll.Value = (int)pieSeries.LeadOffArrowLength.Value;

			BeginAngleScroll.Value = (int)pieChart.BeginAngle;
			TotalAngleScroll.Value = (int)pieChart.TotalAngle;
		}

		private void PieShapeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NPieSeries pie = (NPieSeries)nChartControl1.Charts[0].Series[0];

			pie.PieStyle = (PieStyle)PieShapeCombo.SelectedIndex;

			switch(pie.PieStyle)
			{
				case PieStyle.Pie:
				case PieStyle.Ring:
				case PieStyle.Torus:
					EdgePercentScroll.Enabled = false;
					break;

				case PieStyle.SmoothEdgePie:
				case PieStyle.SmoothEdgeRing:
				case PieStyle.CutEdgePie:
				case PieStyle.CutEdgeRing:
					EdgePercentScroll.Enabled = true;
					break;

				default:
					Debug.Assert(false);
					break;
			}

			switch (pie.PieStyle)
			{
				case PieStyle.Pie:
				case PieStyle.SmoothEdgePie:
				case PieStyle.CutEdgePie:
					InnerRadiusScroll.Enabled = false;
					break;

				case PieStyle.Ring:
				case PieStyle.Torus:
				case PieStyle.SmoothEdgeRing:
				case PieStyle.CutEdgeRing:
					InnerRadiusScroll.Enabled = true;
					break;

				default:
					Debug.Assert(false);
					break;
			}

			nChartControl1.Refresh();
		}
		private void BeginAngleScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NPieChart pie = (NPieChart)nChartControl1.Charts[0];
			pie.BeginAngle = BeginAngleScroll.Value;		
			nChartControl1.Refresh();
		}
		private void TotalAngleScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NPieChart pie = (NPieChart)nChartControl1.Charts[0];
			pie.TotalAngle = TotalAngleScroll.Value;
			nChartControl1.Refresh();
		}
		private void PieLabelModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NPieSeries pie = (NPieSeries)nChartControl1.Charts[0].Series[0];

			pie.LabelMode = (PieLabelMode)PieLabelModeCombo.SelectedIndex;

			switch (pie.LabelMode)
			{
				case PieLabelMode.Center:
					ArrowLengthScroll.Enabled = false;
					ArrowPointerLengthScroll.Enabled = false;
					ConnectorLengthScroll.Enabled = false;
					LeadOffLengthScroll.Enabled = false;
					break;

				case PieLabelMode.Rim:
				case PieLabelMode.Spider:
					ArrowLengthScroll.Enabled = true;
					ArrowPointerLengthScroll.Enabled = true;
					ConnectorLengthScroll.Enabled = false;
					LeadOffLengthScroll.Enabled = false;
					break;

				case PieLabelMode.SpiderNoOverlap:
					ArrowLengthScroll.Enabled = false;
					ArrowPointerLengthScroll.Enabled = false;
					ConnectorLengthScroll.Enabled = true;
					LeadOffLengthScroll.Enabled = true;
					break;
			}

			nChartControl1.Refresh();
		}
		private void ArrowLengthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NPieSeries pie = (NPieSeries)nChartControl1.Charts[0].Series[0];
			pie.DataLabelStyle.ArrowLength = new NLength(ArrowLengthScroll.Value, NGraphicsUnit.Point);
			nChartControl1.Refresh();
		}
		private void ArrowPointerLengthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NPieSeries pie = (NPieSeries)nChartControl1.Charts[0].Series[0];
			pie.DataLabelStyle.ArrowPointerLength = new NLength(ArrowPointerLengthScroll.Value, NGraphicsUnit.Point);
			nChartControl1.Refresh();
		}
		private void ConnectorLengthScroll_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NPieSeries pie = (NPieSeries)nChartControl1.Charts[0].Series[0];
			pie.ConnectorLength = new NLength(ConnectorLengthScroll.Value, NGraphicsUnit.Point);
			nChartControl1.Refresh();
		}
		private void LeadOffLengthScroll_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NPieSeries pie = (NPieSeries)nChartControl1.Charts[0].Series[0];
			pie.LeadOffArrowLength = new NLength(LeadOffLengthScroll.Value, NGraphicsUnit.Point);
			nChartControl1.Refresh();
		}
		private void PieEdgeScrollBar_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NPieSeries pie = (NPieSeries)nChartControl1.Charts[0].Series[0];
			pie.PieEdgePercent = EdgePercentScroll.Value;
			nChartControl1.Refresh();
		}
		private void OuterRadiusScroll_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NPieChart pie = (NPieChart)nChartControl1.Charts[0];
			pie.Radius = new NLength(OuterRadiusScroll.Value, NRelativeUnit.ParentPercentage);
			nChartControl1.Refresh();
		}
		private void InnerRadiusScroll_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NPieChart pie = (NPieChart)nChartControl1.Charts[0];
			pie.InnerRadius = new NLength(InnerRadiusScroll.Value, NRelativeUnit.ParentPercentage);
			nChartControl1.Refresh();
		}
	}
}