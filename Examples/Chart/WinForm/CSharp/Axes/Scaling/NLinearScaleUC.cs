using System;
using System.Resources;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Collections;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NLinearScaleUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NLineSeries m_Line;
		private bool m_Updating;
		private Nevron.UI.WinForm.Controls.NRadioButton AutoMaxCountRadioButton;
		private Nevron.UI.WinForm.Controls.NRadioButton AutoMinDistanceRadioButton;
		private Nevron.UI.WinForm.Controls.NRadioButton CustomStepRadioButton;
		private Nevron.UI.WinForm.Controls.NRadioButton CustomStepsRadioButton;
		private Nevron.UI.WinForm.Controls.NRadioButton CustomTicksRadioButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NNumericUpDown MaxCountUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown MinDistanceUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown CustomStepUpDown;
		private Nevron.UI.WinForm.Controls.NButton GenerateRandomDataButton;
		private System.ComponentModel.Container components = null;

		public NLinearScaleUC()
		{
			m_Updating = true;

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
			this.AutoMaxCountRadioButton = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.AutoMinDistanceRadioButton = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.CustomStepRadioButton = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.CustomStepsRadioButton = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.CustomTicksRadioButton = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.MaxCountUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.MinDistanceUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.CustomStepUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.GenerateRandomDataButton = new Nevron.UI.WinForm.Controls.NButton();
			((System.ComponentModel.ISupportInitialize)(this.MaxCountUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MinDistanceUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CustomStepUpDown)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// AutoMaxCountRadioButton
			// 
			this.AutoMaxCountRadioButton.Location = new System.Drawing.Point(11, 21);
			this.AutoMaxCountRadioButton.Name = "AutoMaxCountRadioButton";
			this.AutoMaxCountRadioButton.TabIndex = 0;
			this.AutoMaxCountRadioButton.Text = "AutoMaxCount";
			this.AutoMaxCountRadioButton.CheckedChanged += new System.EventHandler(this.AutoMaxCountRadioButton_CheckedChanged);
			// 
			// AutoMinDistanceRadioButton
			// 
			this.AutoMinDistanceRadioButton.Location = new System.Drawing.Point(9, 78);
			this.AutoMinDistanceRadioButton.Name = "AutoMinDistanceRadioButton";
			this.AutoMinDistanceRadioButton.Size = new System.Drawing.Size(135, 24);
			this.AutoMinDistanceRadioButton.TabIndex = 3;
			this.AutoMinDistanceRadioButton.Text = "AutoMinDistance";
			this.AutoMinDistanceRadioButton.CheckedChanged += new System.EventHandler(this.AutoMinDistanceRadioButton_CheckedChanged);
			// 
			// CustomStepRadioButton
			// 
			this.CustomStepRadioButton.Location = new System.Drawing.Point(7, 135);
			this.CustomStepRadioButton.Name = "CustomStepRadioButton";
			this.CustomStepRadioButton.Size = new System.Drawing.Size(135, 24);
			this.CustomStepRadioButton.TabIndex = 7;
			this.CustomStepRadioButton.Text = "Custom Step";
			this.CustomStepRadioButton.CheckedChanged += new System.EventHandler(this.CustomStepRadioButton_CheckedChanged);
			// 
			// CustomStepsRadioButton
			// 
			this.CustomStepsRadioButton.Location = new System.Drawing.Point(8, 196);
			this.CustomStepsRadioButton.Name = "CustomStepsRadioButton";
			this.CustomStepsRadioButton.Size = new System.Drawing.Size(135, 24);
			this.CustomStepsRadioButton.TabIndex = 10;
			this.CustomStepsRadioButton.Text = "Custom Steps";
			this.CustomStepsRadioButton.CheckedChanged += new System.EventHandler(this.CustomStepsRadioButton_CheckedChanged);
			// 
			// CustomTicksRadioButton
			// 
			this.CustomTicksRadioButton.Location = new System.Drawing.Point(7, 224);
			this.CustomTicksRadioButton.Name = "CustomTicksRadioButton";
			this.CustomTicksRadioButton.Size = new System.Drawing.Size(135, 24);
			this.CustomTicksRadioButton.TabIndex = 11;
			this.CustomTicksRadioButton.Text = "Custom Ticks";
			this.CustomTicksRadioButton.CheckedChanged += new System.EventHandler(this.CustomTicksRadioButton_CheckedChanged);
			// 
			// MaxCountUpDown
			// 
			this.MaxCountUpDown.Location = new System.Drawing.Point(103, 46);
			this.MaxCountUpDown.Minimum = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			this.MaxCountUpDown.Name = "MaxCountUpDown";
			this.MaxCountUpDown.Size = new System.Drawing.Size(66, 20);
			this.MaxCountUpDown.TabIndex = 2;
			this.MaxCountUpDown.Value = new System.Decimal(new int[] {
																		 1,
																		 0,
																		 0,
																		 0});
			this.MaxCountUpDown.ValueChanged += new System.EventHandler(this.MaxCountUpDown_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(11, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Max Count:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(11, 100);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(82, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Min Distance:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// MinDistanceUpDown
			// 
			this.MinDistanceUpDown.Location = new System.Drawing.Point(103, 105);
			this.MinDistanceUpDown.Minimum = new System.Decimal(new int[] {
																			  1,
																			  0,
																			  0,
																			  0});
			this.MinDistanceUpDown.Name = "MinDistanceUpDown";
			this.MinDistanceUpDown.Size = new System.Drawing.Size(66, 20);
			this.MinDistanceUpDown.TabIndex = 5;
			this.MinDistanceUpDown.Value = new System.Decimal(new int[] {
																			1,
																			0,
																			0,
																			0});
			this.MinDistanceUpDown.ValueChanged += new System.EventHandler(this.MinDistanceUpDown_ValueChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(173, 100);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(17, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "pt";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(11, 159);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(78, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "Custom Step:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// CustomStepUpDown
			// 
			this.CustomStepUpDown.Location = new System.Drawing.Point(103, 164);
			this.CustomStepUpDown.Minimum = new System.Decimal(new int[] {
																			 1,
																			 0,
																			 0,
																			 0});
			this.CustomStepUpDown.Name = "CustomStepUpDown";
			this.CustomStepUpDown.Size = new System.Drawing.Size(66, 20);
			this.CustomStepUpDown.TabIndex = 9;
			this.CustomStepUpDown.Value = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			this.CustomStepUpDown.ValueChanged += new System.EventHandler(this.CustomStepUpDown_ValueChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.CustomTicksRadioButton);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.CustomStepsRadioButton);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.CustomStepUpDown);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.CustomStepRadioButton);
			this.groupBox1.Controls.Add(this.AutoMinDistanceRadioButton);
			this.groupBox1.Controls.Add(this.AutoMaxCountRadioButton);
			this.groupBox1.Controls.Add(this.MinDistanceUpDown);
			this.groupBox1.Controls.Add(this.MaxCountUpDown);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(205, 260);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Major Tick Modes";
			// 
			// GenerateRandomDataButton
			// 
			this.GenerateRandomDataButton.Location = new System.Drawing.Point(4, 269);
			this.GenerateRandomDataButton.Name = "GenerateRandomDataButton";
			this.GenerateRandomDataButton.Size = new System.Drawing.Size(199, 23);
			this.GenerateRandomDataButton.TabIndex = 1;
			this.GenerateRandomDataButton.Text = "Generate Random Data";
			this.GenerateRandomDataButton.Click += new System.EventHandler(this.GenerateRandomDataButton_Click);
			// 
			// NLinearScaleUC
			// 
			this.Controls.Add(this.GenerateRandomDataButton);
			this.Controls.Add(this.groupBox1);
			this.Name = "NLinearScaleUC";
			this.Size = new System.Drawing.Size(205, 304);
			((System.ComponentModel.ISupportInitialize)(this.MaxCountUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MinDistanceUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CustomStepUpDown)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Linear Scale");
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

			m_Line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line.Legend.Mode = SeriesLegendMode.None;
			m_Line.InflateMargins = false;
			m_Line.MarkerStyle.Visible = true;
			m_Line.MarkerStyle.PointShape = PointShape.Ellipse;
			m_Line.MarkerStyle.Width = new NLength(5, NGraphicsUnit.Point);
			m_Line.MarkerStyle.Height = new NLength(5, NGraphicsUnit.Point);
			m_Line.MarkerStyle.AutoDepth = true;
			m_Line.DataLabelStyle.Format = "<value>";
			m_Line.DataLabelStyle.ArrowStrokeStyle.Color = Color.CornflowerBlue;

			m_Line.Values.FillRandomRange(Random, 10, 0, 100);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// update controls
			AutoMinDistanceRadioButton.Checked = true;
			MaxCountUpDown.Value = (decimal)linearScale.MaxTickCount;
			MinDistanceUpDown.Value = (decimal)linearScale.MinTickDistance.Value;
			CustomStepUpDown.Value = (decimal)linearScale.CustomStep;

			m_Updating = false;

			UpdateScale();
		}

		private void UpdateScale()
		{
			if (m_Updating)
				return;

			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;

			if (linearScale == null)
				return;

			linearScale.MaxTickCount = (int)MaxCountUpDown.Value;
			linearScale.MinTickDistance = new NLength((float)MinDistanceUpDown.Value, NGraphicsUnit.Point);
			linearScale.CustomStep = (double)CustomStepUpDown.Value;

			// update the custom ticks to match the values of the line series
			double[] values = new double[m_Line.Values.Count];
			m_Line.Values.CopyTo(values, 0);
			linearScale.CustomMajorTicks = new NDoubleList(values);

			linearScale.CustomSteps.Clear();
			linearScale.CustomSteps.Add(10);
			linearScale.CustomSteps.Add(20);

			if (AutoMaxCountRadioButton.Checked)
			{
				linearScale.MajorTickMode = MajorTickMode.AutoMaxCount;
			}
			else if (AutoMinDistanceRadioButton.Checked)
			{
				linearScale.MajorTickMode = MajorTickMode.AutoMinDistance;
			}
			else if (CustomStepRadioButton.Checked)
			{
				linearScale.MajorTickMode = MajorTickMode.CustomStep;
			}
			else if (CustomStepsRadioButton.Checked)
			{
				linearScale.MajorTickMode = MajorTickMode.CustomSteps;
			}
			else if (CustomTicksRadioButton.Checked)
			{
				linearScale.MajorTickMode = MajorTickMode.CustomTicks;
			}

			nChartControl1.Refresh();
		}

		private void MaxCountUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}

		private void MinDistanceUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}

		private void CustomStepUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateScale();		
		}

		private void AutoMaxCountRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}

		private void AutoMinDistanceRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateScale();		
		}

		private void CustomStepRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateScale();		
		}

		private void CustomStepsRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}

		private void CustomTicksRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}

		private void GenerateRandomDataButton_Click(object sender, System.EventArgs e)
		{
			m_Line.Values.FillRandomRange(Random, 10, 0, 100);

			UpdateScale();
		}
	}
}
