using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Editors;
using Nevron.SmartShapes;
using Nevron.GraphicsCore;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NRadialGaugeIndicatorsUC : NExampleBaseUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NComboBox RangeIndicatorOriginModeComboBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RangeIndicatorOriginUpDown;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RangeIndicatorValueUpDown;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ValueIndicatorUpDown;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NComboBox ValueIndicatorShapeComboBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private Nevron.UI.WinForm.Controls.NNumericUpDown BeginAngleUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown SweepAngleUpDown;

		NRadialGaugePanel m_RadialGauge;
		NRangeIndicator m_Indicator1;
		NNeedleValueIndicator m_Indicator2;
		private System.Windows.Forms.Label label8;
		private Nevron.UI.WinForm.Controls.NButton ShowNeedleEditorButton;
		private Nevron.UI.WinForm.Controls.NNumericUpDown NeedleWidthUpDown;
		NNumericDisplayPanel m_NumericDisplay;

		public NRadialGaugeIndicatorsUC()
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

		public override void Initialize()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Radial Gauge Indicators");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
            
            nChartControl1.Panels.Add(header);

			// create the radial gauge
			m_RadialGauge = new NRadialGaugePanel();
            m_RadialGauge.PaintEffect = new NGlassEffectStyle();
			NEdgeBorderStyle edgeBorder = new NEdgeBorderStyle(BorderShape.Auto);
			edgeBorder.OuterBevelWidth = new NLength(0);
			edgeBorder.MiddleBevelWidth = new NLength(0);
			edgeBorder.InnerBevelWidth = new NLength(0);
			m_RadialGauge.BorderStyle = edgeBorder;
			m_RadialGauge.ContentAlignment = ContentAlignment.MiddleCenter;
			m_RadialGauge.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(55, NRelativeUnit.ParentPercentage));
			m_RadialGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
            m_RadialGauge.BackgroundFillStyle = new NGradientFillStyle(Color.DarkGray, Color.Black);

			// configure scale
			NGaugeAxis axis = (NGaugeAxis)m_RadialGauge.Axes[0];
            NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;

            scale.SetPredefinedScaleStyle(PredefinedScaleStyle.Presentation);
            scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 12, FontStyle.Bold);
            scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
            scale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 90);
            scale.MinorTickCount = 4;
            scale.RulerStyle.BorderStyle.Width = new NLength(0);
            scale.RulerStyle.FillStyle = new NColorFillStyle(Color.DarkGray);

            // add radial gauge indicators
            m_Indicator1 = new NRangeIndicator();
            m_Indicator1.Value = 20;
            m_Indicator1.FillStyle = new NGradientFillStyle(GradientStyle.StartToEnd, GradientVariant.Variant1, Color.Yellow, Color.Red);
            m_Indicator1.StrokeStyle.Color = Color.DarkBlue;
            m_Indicator1.EndWidth = new NLength(20);
            m_RadialGauge.Indicators.Add(m_Indicator1);

            m_Indicator2 = new NNeedleValueIndicator();
            m_Indicator2.Value = 79;
            m_Indicator2.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
            m_Indicator2.Shape.StrokeStyle.Color = Color.Red;
            m_RadialGauge.Indicators.Add(m_Indicator2);
            m_RadialGauge.SweepAngle = 270;

            // add radial gauge
            nChartControl1.Panels.Add(m_RadialGauge);

            // create and configure a numeric display attached to the radial gauge
			m_NumericDisplay = new NNumericDisplayPanel();
			m_NumericDisplay.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));
			m_NumericDisplay.ContentAlignment = ContentAlignment.TopCenter; 
			m_NumericDisplay.SegmentWidth = new NLength(2, NGraphicsUnit.Point);
			m_NumericDisplay.SegmentGap = new NLength(1, NGraphicsUnit.Point);
			m_NumericDisplay.CellSize = new NSizeL(new NLength(15, NGraphicsUnit.Point), new NLength(30, NGraphicsUnit.Point));
			m_NumericDisplay.DecimalCellSize = new NSizeL(new NLength(10, NGraphicsUnit.Point), new NLength(20, NGraphicsUnit.Point));
			m_NumericDisplay.ShowDecimalSeparator = false;
			m_NumericDisplay.CellAlignment = VertAlign.Top;
            m_NumericDisplay.BackgroundFillStyle = new NColorFillStyle(Color.DimGray);
            m_NumericDisplay.LitFillStyle = new NGradientFillStyle(Color.Lime, Color.Green);
            m_NumericDisplay.CellCountMode = DisplayCellCountMode.Fixed;
            m_NumericDisplay.CellCount = 6;
            m_NumericDisplay.Padding = new NMarginsL(6, 3, 6, 3);
            m_RadialGauge.ChildPanels.Add(m_NumericDisplay);

            // create a sunken border around the display
            NEdgeBorderStyle borderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);
            borderStyle.OuterBevelWidth = new NLength(0);
            borderStyle.MiddleBevelWidth = new NLength(0);
            m_NumericDisplay.BorderStyle = borderStyle;

			// init form controls
			SweepAngleUpDown.Value = (decimal)m_RadialGauge.SweepAngle;
			BeginAngleUpDown.Value = (decimal)m_RadialGauge.BeginAngle;

			ValueIndicatorShapeComboBox.FillFromEnum(typeof(SmartShape1D));
			ValueIndicatorShapeComboBox.SelectedIndex = (int)SmartShape1D.Arrow2;

			ValueIndicatorUpDown.Value = (decimal)m_Indicator2.Value;
			RangeIndicatorValueUpDown.Value = (decimal)m_Indicator1.Value;

			RangeIndicatorOriginModeComboBox.FillFromEnum(typeof(OriginMode));
			RangeIndicatorOriginModeComboBox.SelectedIndex = 0;

			NeedleWidthUpDown.Value = (decimal)m_Indicator2.Width.Value;
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.RangeIndicatorOriginModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.RangeIndicatorOriginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.RangeIndicatorValueUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.ShowNeedleEditorButton = new Nevron.UI.WinForm.Controls.NButton();
			this.NeedleWidthUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.ValueIndicatorUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.ValueIndicatorShapeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.BeginAngleUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.SweepAngleUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.RangeIndicatorOriginUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RangeIndicatorValueUpDown)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NeedleWidthUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ValueIndicatorUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BeginAngleUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SweepAngleUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.RangeIndicatorOriginModeComboBox);
			this.groupBox2.Controls.Add(this.RangeIndicatorOriginUpDown);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.RangeIndicatorValueUpDown);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.ImageIndex = 0;
			this.groupBox2.Location = new System.Drawing.Point(0, 168);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(180, 144);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Range Indicator";
			// 
			// RangeIndicatorOriginModeComboBox
			// 
			this.RangeIndicatorOriginModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.RangeIndicatorOriginModeComboBox.ListProperties.DataSource = null;
			this.RangeIndicatorOriginModeComboBox.ListProperties.DisplayMember = "";
			this.RangeIndicatorOriginModeComboBox.Location = new System.Drawing.Point(95, 56);
			this.RangeIndicatorOriginModeComboBox.Name = "RangeIndicatorOriginModeComboBox";
			this.RangeIndicatorOriginModeComboBox.Size = new System.Drawing.Size(76, 21);
			this.RangeIndicatorOriginModeComboBox.TabIndex = 3;
			this.RangeIndicatorOriginModeComboBox.Text = "RangeIndicatorOriginModeComboBox";
			this.RangeIndicatorOriginModeComboBox.SelectedIndexChanged += new System.EventHandler(this.RangeIndicatorOriginModeComboBox_SelectedIndexChanged);
			// 
			// RangeIndicatorOriginUpDown
			// 
			this.RangeIndicatorOriginUpDown.Location = new System.Drawing.Point(96, 96);
			this.RangeIndicatorOriginUpDown.Name = "RangeIndicatorOriginUpDown";
			this.RangeIndicatorOriginUpDown.Size = new System.Drawing.Size(75, 20);
			this.RangeIndicatorOriginUpDown.TabIndex = 5;
			this.RangeIndicatorOriginUpDown.ValueChanged += new System.EventHandler(this.RangeIndicatorOriginUpDown_ValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 100);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Origin:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Origin Mode:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Value:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// RangeIndicatorValueUpDown
			// 
			this.RangeIndicatorValueUpDown.Location = new System.Drawing.Point(96, 16);
			this.RangeIndicatorValueUpDown.Name = "RangeIndicatorValueUpDown";
			this.RangeIndicatorValueUpDown.Size = new System.Drawing.Size(75, 20);
			this.RangeIndicatorValueUpDown.TabIndex = 1;
			this.RangeIndicatorValueUpDown.ValueChanged += new System.EventHandler(this.RangeIndicatorValueUpDown_ValueChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ShowNeedleEditorButton);
			this.groupBox1.Controls.Add(this.NeedleWidthUpDown);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.ValueIndicatorUpDown);
			this.groupBox1.Controls.Add(this.ValueIndicatorShapeComboBox);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(180, 168);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Value Indicator";
			// 
			// ShowNeedleEditorButton
			// 
			this.ShowNeedleEditorButton.Location = new System.Drawing.Point(12, 96);
			this.ShowNeedleEditorButton.Name = "ShowNeedleEditorButton";
			this.ShowNeedleEditorButton.Size = new System.Drawing.Size(159, 23);
			this.ShowNeedleEditorButton.TabIndex = 11;
			this.ShowNeedleEditorButton.Text = "Show Editor...";
			this.ShowNeedleEditorButton.Click += new System.EventHandler(this.ShowNeedleEditorButton_Click);
			// 
			// NeedleWidthUpDown
			// 
			this.NeedleWidthUpDown.Location = new System.Drawing.Point(100, 128);
			this.NeedleWidthUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.NeedleWidthUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
			this.NeedleWidthUpDown.Name = "NeedleWidthUpDown";
			this.NeedleWidthUpDown.Size = new System.Drawing.Size(75, 20);
			this.NeedleWidthUpDown.TabIndex = 10;
			this.NeedleWidthUpDown.ValueChanged += new System.EventHandler(this.NeedleWidthUpDown_ValueChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(12, 128);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 23);
			this.label8.TabIndex = 9;
			this.label8.Text = "Width: ";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueIndicatorUpDown
			// 
			this.ValueIndicatorUpDown.Location = new System.Drawing.Point(96, 32);
			this.ValueIndicatorUpDown.Name = "ValueIndicatorUpDown";
			this.ValueIndicatorUpDown.Size = new System.Drawing.Size(75, 20);
			this.ValueIndicatorUpDown.TabIndex = 1;
			this.ValueIndicatorUpDown.ValueChanged += new System.EventHandler(this.ValueIndicatorUpDown_ValueChanged);
			// 
			// ValueIndicatorShapeComboBox
			// 
			this.ValueIndicatorShapeComboBox.ListProperties.CheckBoxDataMember = "";
			this.ValueIndicatorShapeComboBox.ListProperties.DataSource = null;
			this.ValueIndicatorShapeComboBox.ListProperties.DisplayMember = "";
			this.ValueIndicatorShapeComboBox.Location = new System.Drawing.Point(96, 64);
			this.ValueIndicatorShapeComboBox.Name = "ValueIndicatorShapeComboBox";
			this.ValueIndicatorShapeComboBox.Size = new System.Drawing.Size(75, 21);
			this.ValueIndicatorShapeComboBox.TabIndex = 3;
			this.ValueIndicatorShapeComboBox.Text = "comboBox1";
			this.ValueIndicatorShapeComboBox.SelectedIndexChanged += new System.EventHandler(this.ValueIndicatorShapeComboBox_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 62);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 23);
			this.label5.TabIndex = 2;
			this.label5.Text = "Shape:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 29);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "Value:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 328);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 23);
			this.label6.TabIndex = 6;
			this.label6.Text = "Begin Angle:";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 360);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 23);
			this.label7.TabIndex = 7;
			this.label7.Text = "Sweep Angle:";
			// 
			// BeginAngleUpDown
			// 
			this.BeginAngleUpDown.Location = new System.Drawing.Point(96, 328);
			this.BeginAngleUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.BeginAngleUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
			this.BeginAngleUpDown.Name = "BeginAngleUpDown";
			this.BeginAngleUpDown.Size = new System.Drawing.Size(75, 20);
			this.BeginAngleUpDown.TabIndex = 8;
			this.BeginAngleUpDown.ValueChanged += new System.EventHandler(this.BeginAngleUpDown_ValueChanged);
			// 
			// SweepAngleUpDown
			// 
			this.SweepAngleUpDown.Location = new System.Drawing.Point(96, 360);
			this.SweepAngleUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.SweepAngleUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
			this.SweepAngleUpDown.Name = "SweepAngleUpDown";
			this.SweepAngleUpDown.Size = new System.Drawing.Size(75, 20);
			this.SweepAngleUpDown.TabIndex = 9;
			this.SweepAngleUpDown.ValueChanged += new System.EventHandler(this.SweepAngleUpDown_ValueChanged);
			// 
			// NRadialGaugeIndicatorsUC
			// 
			this.Controls.Add(this.SweepAngleUpDown);
			this.Controls.Add(this.BeginAngleUpDown);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "NRadialGaugeIndicatorsUC";
			this.Size = new System.Drawing.Size(180, 408);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.RangeIndicatorOriginUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RangeIndicatorValueUpDown)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.NeedleWidthUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ValueIndicatorUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BeginAngleUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SweepAngleUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void RangeIndicatorOriginModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Indicator1.OriginMode = (OriginMode)RangeIndicatorOriginModeComboBox.SelectedIndex;
			if (m_Indicator1.OriginMode != OriginMode.Custom)
			{
				RangeIndicatorOriginUpDown.Enabled = false;
			}
			else
			{
				RangeIndicatorOriginUpDown.Enabled = true;
			}

			nChartControl1.Refresh();
		}

		private void ValueIndicatorUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			m_Indicator2.Value = (double)ValueIndicatorUpDown.Value;
			m_NumericDisplay.Value = m_Indicator2.Value;
			nChartControl1.Refresh();
		}

		private void RangeIndicatorValueUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			m_Indicator1.Value = (double)RangeIndicatorValueUpDown.Value;
			nChartControl1.Refresh();
		}

		private void RangeIndicatorOriginUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			m_Indicator1.Origin = (double)RangeIndicatorOriginUpDown.Value;
			nChartControl1.Refresh();
		}

		private void BeginAngleUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			m_RadialGauge.BeginAngle = (float)BeginAngleUpDown.Value;
			nChartControl1.Refresh();		
		}

		private void SweepAngleUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			m_RadialGauge.SweepAngle = (float)SweepAngleUpDown.Value;
			nChartControl1.Refresh();
		}

		private void ValueIndicatorShapeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			N1DSmartShapeFactory factory = new N1DSmartShapeFactory(m_Indicator2.Shape.FillStyle, m_Indicator2.Shape.StrokeStyle, m_Indicator2.Shape.ShadowStyle);		
			m_Indicator2.Shape = factory.CreateShape((SmartShape1D)ValueIndicatorShapeComboBox.SelectedIndex);
			nChartControl1.Refresh();
		}

		private void ShowNeedleEditorButton_Click(object sender, System.EventArgs e)
		{
			NSmartShapeEditorUC editor2 = new NSmartShapeEditorUC();

			NSmartShapesCategory cat = new NSmartShapesCategory("Needle Shapes");
			N1DSmartShapeFactory factory = new N1DSmartShapeFactory(m_Indicator2.Shape.FillStyle, m_Indicator2.Shape.StrokeStyle, m_Indicator2.Shape.ShadowStyle);

			NSmartShape[] shapes = factory.CreateShapes();

			for (int i = 0; i < shapes.Length; i++)
			{
				cat.Add(shapes[i]);
			}

			editor2.PredefinedShapes = new NSmartShapesCategory[]{cat};
			editor2.Shape = (NSmartShape)(((ICloneable)m_Indicator2.Shape).Clone());

			if (editor2.ShowInHostForm() == DialogResult.OK)
			{
				m_Indicator2.Shape = editor2.Shape;
				nChartControl1.Refresh();
			}

			editor2.Dispose();
		}

		private void NeedleWidthUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			m_Indicator2.Width = new NLength((float)NeedleWidthUpDown.Value);
			nChartControl1.Refresh();
		}
	}
}
