using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NDraggingIndicatorsUC : NExampleBaseUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		NRangeIndicator m_RadialIndicator1;
		NNeedleValueIndicator m_RadialIndicator2;
		NMarkerValueIndicator m_RadialIndicator3;

		NRangeIndicator m_HorzLinearIndicator1;
		NMarkerValueIndicator m_HorzLinearIndicator2;

		NRangeIndicator m_VertLinearIndicator1;
		NMarkerValueIndicator m_VertLinearIndicator2;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox IndicatorsSnapModeComboBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NNumericUpDown OriginNumericUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown StepNumericUpDown;
		private Nevron.UI.WinForm.Controls.NCheckBox AllowDragRangeIndicatorsCheckBox;
		
		public NDraggingIndicatorsUC()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		public override void Initialize()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Dragging Gauge Indicators");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
            
            nChartControl1.Panels.Add(header);

			nChartControl1.Panels.Add(CreateHorizontalLinearGauge());
			nChartControl1.Panels.Add(CreateVerticalLinearGauge());
			nChartControl1.Panels.Add(CreateRadialGauge());

			nChartControl1.Controller.Tools.Add(new NSelectorTool());
			nChartControl1.Controller.Tools.Add(new NIndicatorDragTool());

			// Init form controls
			IndicatorsSnapModeComboBox.Items.Add("None");
			IndicatorsSnapModeComboBox.Items.Add("Ruler");
			IndicatorsSnapModeComboBox.Items.Add("Major ticks");
			IndicatorsSnapModeComboBox.Items.Add("Minor ticks");
			IndicatorsSnapModeComboBox.Items.Add("Ruler Min/Max");
			IndicatorsSnapModeComboBox.Items.Add("Numeric");

			IndicatorsSnapModeComboBox.SelectedIndex = 0;
			AllowDragRangeIndicatorsCheckBox_CheckedChanged(null, null);
		}

		private NRadialGaugePanel CreateRadialGauge()
		{
			// create the radial gauge
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();

            radialGauge.Location = new NPointL(new NLength(32, NRelativeUnit.ParentPercentage), new NLength(40, NRelativeUnit.ParentPercentage));
            radialGauge.Size = new NSizeL(new NLength(58, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
            radialGauge.BackgroundFillStyle = new NGradientFillStyle(Color.DarkGray, Color.Black);
            radialGauge.PaintEffect = new NGlassEffectStyle();
            radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);

            // configure the axis
			NGaugeAxis axis = (NGaugeAxis)radialGauge.Axes[0];
            ConfigureAxis(axis);

            // add some indicators
			m_RadialIndicator1 = new NRangeIndicator();
			m_RadialIndicator1.Value = 50;
			m_RadialIndicator1.FillStyle = new NGradientFillStyle(Color.LightBlue, Color.DarkBlue);
			m_RadialIndicator1.StrokeStyle.Color = Color.DarkBlue;
			m_RadialIndicator1.EndWidth = new NLength(20);
			radialGauge.Indicators.Add(m_RadialIndicator1);

			m_RadialIndicator2 = new NNeedleValueIndicator();
			m_RadialIndicator2.Value = 79;
			m_RadialIndicator2.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			m_RadialIndicator2.Shape.StrokeStyle.Color = Color.Red;
			radialGauge.Indicators.Add(m_RadialIndicator2);
			radialGauge.SweepAngle = 270;

			m_RadialIndicator3 = new NMarkerValueIndicator();
			m_RadialIndicator3.Value = 90;
			radialGauge.Indicators.Add(m_RadialIndicator3);

            return radialGauge;
		}

		private NLinearGaugePanel CreateHorizontalLinearGauge()
		{
			NLinearGaugePanel linearGauge = new NLinearGaugePanel();

            linearGauge.Location = new NPointL( new NLength(10, NRelativeUnit.ParentPercentage),
                                                new NLength(20, NRelativeUnit.ParentPercentage));
            linearGauge.Size = new NSizeL(  new NLength(80, NRelativeUnit.ParentPercentage),
                                            new NLength(60, NGraphicsUnit.Point));

            linearGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);
            linearGauge.BackgroundFillStyle = new NGradientFillStyle(Color.DarkGray, Color.Black);

			// add indicators
			m_HorzLinearIndicator1 = new NRangeIndicator();
			m_HorzLinearIndicator1.FillStyle = new NGradientFillStyle(Color.LightBlue, Color.DarkBlue);
			m_HorzLinearIndicator1.StrokeStyle.Color = Color.DarkBlue;
			m_HorzLinearIndicator1.Value = 10;
			linearGauge.Indicators.Add(m_HorzLinearIndicator1);

			m_HorzLinearIndicator2 = new NMarkerValueIndicator();
			m_HorzLinearIndicator2.Value = 50;
			linearGauge.Indicators.Add(m_HorzLinearIndicator2);

			NGaugeAxis axis = (NGaugeAxis)linearGauge.Axes[0];
			axis.Anchor = new NModelGaugeAxisAnchor();
			axis.Range = new NRange1DD(-100, 100);
            ConfigureAxis(axis);

            return linearGauge;
		}

		private NLinearGaugePanel CreateVerticalLinearGauge()
		{
			NLinearGaugePanel linearGauge = new NLinearGaugePanel();
			linearGauge.Orientation = LinearGaugeOrientation.Vertical;

            linearGauge.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(40, NRelativeUnit.ParentPercentage));
            linearGauge.Size = new NSizeL(new NLength(60, NGraphicsUnit.Point), new NLength(50, NRelativeUnit.ParentPercentage));
            linearGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);
            linearGauge.BackgroundFillStyle = new NGradientFillStyle(Color.DarkGray, Color.Black);

			// add indicators
			m_VertLinearIndicator1 = new NRangeIndicator();
			m_VertLinearIndicator1.Value = 10;
			m_VertLinearIndicator1.FillStyle = new NGradientFillStyle(Color.LightBlue, Color.DarkBlue);
			m_VertLinearIndicator1.StrokeStyle.Color = Color.DarkBlue;
			linearGauge.Indicators.Add(m_VertLinearIndicator1);

			m_VertLinearIndicator2 = new NMarkerValueIndicator();
			m_VertLinearIndicator2.Value = 50;
			linearGauge.Indicators.Add(m_VertLinearIndicator2);

			NGaugeAxis axis = (NGaugeAxis)linearGauge.Axes[0];
			axis.Anchor = new NModelGaugeAxisAnchor();

            ConfigureAxis(axis);

            return linearGauge;
		}

        private void ConfigureAxis(NGaugeAxis axis)
        {
            NStandardScaleConfigurator configurator = (NStandardScaleConfigurator)axis.ScaleConfigurator;
            configurator.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific);
            configurator.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
            configurator.LabelStyle.TextStyle.FontStyle = new NFontStyle("Times New Roman", 10, FontStyle.Italic | FontStyle.Bold);
            configurator.OuterMajorTickStyle.LineStyle.Color = Color.White;
            configurator.OuterMinorTickStyle.LineStyle.Color = Color.White;
            configurator.RulerStyle.BorderStyle.Color = Color.White;
            configurator.MinorTickCount = 4;
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
			this.IndicatorsSnapModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.AllowDragRangeIndicatorsCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.OriginNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.StepNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.OriginNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.StepNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// IndicatorsSnapModeComboBox
			// 
			this.IndicatorsSnapModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.IndicatorsSnapModeComboBox.ListProperties.DataSource = null;
			this.IndicatorsSnapModeComboBox.ListProperties.DisplayMember = "";
			this.IndicatorsSnapModeComboBox.Location = new System.Drawing.Point(8, 48);
			this.IndicatorsSnapModeComboBox.Name = "IndicatorsSnapModeComboBox";
			this.IndicatorsSnapModeComboBox.Size = new System.Drawing.Size(163, 21);
			this.IndicatorsSnapModeComboBox.TabIndex = 1;
			this.IndicatorsSnapModeComboBox.SelectedIndexChanged += new System.EventHandler(this.IndicatorsSnapModeComboBox_SelectedIndexChanged);
			// 
			// AllowDragRangeIndicatorsCheckBox
			// 
			this.AllowDragRangeIndicatorsCheckBox.ButtonProperties.BorderOffset = 2;
			this.AllowDragRangeIndicatorsCheckBox.Location = new System.Drawing.Point(8, 184);
			this.AllowDragRangeIndicatorsCheckBox.Name = "AllowDragRangeIndicatorsCheckBox";
			this.AllowDragRangeIndicatorsCheckBox.Size = new System.Drawing.Size(155, 24);
			this.AllowDragRangeIndicatorsCheckBox.TabIndex = 6;
			this.AllowDragRangeIndicatorsCheckBox.Text = "Allow Range Dragging";
			this.AllowDragRangeIndicatorsCheckBox.CheckedChanged += new System.EventHandler(this.AllowDragRangeIndicatorsCheckBox_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(139, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Indicators Snap Mode:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(111, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Origin:";
			// 
			// OriginNumericUpDown
			// 
			this.OriginNumericUpDown.Location = new System.Drawing.Point(8, 104);
			this.OriginNumericUpDown.Name = "OriginNumericUpDown";
			this.OriginNumericUpDown.Size = new System.Drawing.Size(163, 20);
			this.OriginNumericUpDown.TabIndex = 3;
			this.OriginNumericUpDown.ValueChanged += new System.EventHandler(this.OriginNumericUpDown_ValueChanged);
			// 
			// StepNumericUpDown
			// 
			this.StepNumericUpDown.Location = new System.Drawing.Point(8, 144);
			this.StepNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.StepNumericUpDown.Name = "StepNumericUpDown";
			this.StepNumericUpDown.Size = new System.Drawing.Size(163, 20);
			this.StepNumericUpDown.TabIndex = 5;
			this.StepNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.StepNumericUpDown.ValueChanged += new System.EventHandler(this.StepNumericUpDown_ValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(111, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Step:";
			// 
			// NDraggingIndicatorsUC
			// 
			this.Controls.Add(this.StepNumericUpDown);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.OriginNumericUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.AllowDragRangeIndicatorsCheckBox);
			this.Controls.Add(this.IndicatorsSnapModeComboBox);
			this.Name = "NDraggingIndicatorsUC";
			this.Size = new System.Drawing.Size(180, 264);
			((System.ComponentModel.ISupportInitialize)(this.OriginNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.StepNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void AllowDragRangeIndicatorsCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if (m_RadialIndicator1 != null)
			{
				bool allowDrag = AllowDragRangeIndicatorsCheckBox.Checked;

				m_RadialIndicator1.AllowDragging = allowDrag;
				m_HorzLinearIndicator1.AllowDragging = allowDrag;
				m_VertLinearIndicator1.AllowDragging = allowDrag;
			}
		}

		private NValueSnapper GetAxisValueSnapper()
		{
			int index = IndicatorsSnapModeComboBox.SelectedIndex;

			switch (index)
			{
				case 0: //None, snapping is disabled
					return null;
				case 1: // Ruler, values are constrained to the ruler begin and end values.
					return new NAxisRulerClampSnapper();
				case 2: // Major ticks, values are snapped to axis major ticks
					return new NAxisMajorTickSnapper();
				case 3: // Minor ticks, values are snapped to axis minor ticks
					return new NAxisMinorTickSnapper();
				case 4: // Ruler Min Max, values are snapped to the ruler min and max values
					return new NAxisRulerMinMaxSnapper();
				case 5:
					return new NNumericValueSnapper((double)OriginNumericUpDown.Value, (double)StepNumericUpDown.Value);
			}

			return null;
		}

		public void UpdateValueSnapper()
		{
			if (m_RadialIndicator1 != null)
			{
				m_RadialIndicator1.ValueSnapper = GetAxisValueSnapper();
				m_RadialIndicator2.ValueSnapper = GetAxisValueSnapper();
				m_RadialIndicator3.ValueSnapper = GetAxisValueSnapper();
				m_HorzLinearIndicator1.ValueSnapper = GetAxisValueSnapper();
				m_HorzLinearIndicator2.ValueSnapper = GetAxisValueSnapper();
				m_VertLinearIndicator1.ValueSnapper = GetAxisValueSnapper();
				m_VertLinearIndicator2.ValueSnapper = GetAxisValueSnapper();

				bool enableNumericControls = IndicatorsSnapModeComboBox.SelectedIndex == 5;

				OriginNumericUpDown.Enabled = enableNumericControls;
				StepNumericUpDown.Enabled = enableNumericControls;
			}
		}

		private void IndicatorsSnapModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateValueSnapper();
		}

		private void OriginNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateValueSnapper();
		}

		private void StepNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateValueSnapper();
		}
	}
}
