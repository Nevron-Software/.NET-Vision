using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.UI.WinForm.Controls;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NAxisTicksAppearanceUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private Nevron.UI.WinForm.Controls.NColorDialog colorDialog1;
		private Nevron.UI.WinForm.Controls.NButton TickFillStyleButton;
		private Label label4;
		private NComboBox TickShapeComboBox;
		private UI.WinForm.Controls.NButton TickStrokeStyleButton;
		private Label label5;
		private UI.WinForm.Controls.NHScrollBar TickWidthScrollBar;
		private Label label7;
		private UI.WinForm.Controls.NHScrollBar TickHeightScrollBar;
		private System.ComponentModel.Container components = null;

		public NAxisTicksAppearanceUC()
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NAxisTicksAppearanceUC));
			this.colorDialog1 = new Nevron.UI.WinForm.Controls.NColorDialog();
			this.TickFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label4 = new System.Windows.Forms.Label();
			this.TickShapeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.TickStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label5 = new System.Windows.Forms.Label();
			this.TickWidthScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label7 = new System.Windows.Forms.Label();
			this.TickHeightScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.SuspendLayout();
			// 
			// colorDialog1
			// 
			this.colorDialog1.ClientSize = new System.Drawing.Size(396, 324);
			this.colorDialog1.Color = System.Drawing.Color.Empty;
			this.colorDialog1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.colorDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("colorDialog1.Icon")));
			this.colorDialog1.Location = new System.Drawing.Point(88, 88);
			this.colorDialog1.MaximizeBox = false;
			this.colorDialog1.MinimizeBox = false;
			this.colorDialog1.Name = "colorDialog1";
			this.colorDialog1.ShowCaptionImage = false;
			this.colorDialog1.ShowInTaskbar = false;
			this.colorDialog1.Sizable = false;
			this.colorDialog1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.colorDialog1.Text = "Edit Color";
			this.colorDialog1.Visible = false;
			// 
			// TickFillStyleButton
			// 
			this.TickFillStyleButton.Location = new System.Drawing.Point(10, 70);
			this.TickFillStyleButton.Name = "TickFillStyleButton";
			this.TickFillStyleButton.Size = new System.Drawing.Size(125, 22);
			this.TickFillStyleButton.TabIndex = 3;
			this.TickFillStyleButton.Text = "Tick Fill Style...";
			this.TickFillStyleButton.Click += new System.EventHandler(this.TickFillStyleButton_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 19);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 13);
			this.label4.TabIndex = 20;
			this.label4.Text = "Tick Shape:";
			// 
			// TickShapeComboBox
			// 
			this.TickShapeComboBox.ListProperties.CheckBoxDataMember = "";
			this.TickShapeComboBox.ListProperties.DataSource = null;
			this.TickShapeComboBox.ListProperties.DisplayMember = "";
			this.TickShapeComboBox.Location = new System.Drawing.Point(10, 36);
			this.TickShapeComboBox.Name = "TickShapeComboBox";
			this.TickShapeComboBox.Size = new System.Drawing.Size(125, 21);
			this.TickShapeComboBox.TabIndex = 21;
			this.TickShapeComboBox.SelectedIndexChanged += new System.EventHandler(this.TickShapeComboBox_SelectedIndexChanged);
			// 
			// TickStrokeStyleButton
			// 
			this.TickStrokeStyleButton.Location = new System.Drawing.Point(10, 98);
			this.TickStrokeStyleButton.Name = "TickStrokeStyleButton";
			this.TickStrokeStyleButton.Size = new System.Drawing.Size(125, 22);
			this.TickStrokeStyleButton.TabIndex = 22;
			this.TickStrokeStyleButton.Text = "Tick Stroke Style...";
			this.TickStrokeStyleButton.Click += new System.EventHandler(this.TickStrokeStyleButton_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(10, 146);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(116, 19);
			this.label5.TabIndex = 23;
			this.label5.Text = "Tick Width:";
			// 
			// TickWidthScrollBar
			// 
			this.TickWidthScrollBar.LargeChange = 2;
			this.TickWidthScrollBar.Location = new System.Drawing.Point(10, 166);
			this.TickWidthScrollBar.Maximum = 20;
			this.TickWidthScrollBar.MinimumSize = new System.Drawing.Size(34, 17);
			this.TickWidthScrollBar.Name = "TickWidthScrollBar";
			this.TickWidthScrollBar.Size = new System.Drawing.Size(125, 17);
			this.TickWidthScrollBar.TabIndex = 24;
			this.TickWidthScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.TickWidthScrollBar_ValueChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(10, 190);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(116, 19);
			this.label7.TabIndex = 25;
			this.label7.Text = "Tick Height:";
			// 
			// TickHeightScrollBar
			// 
			this.TickHeightScrollBar.LargeChange = 2;
			this.TickHeightScrollBar.Location = new System.Drawing.Point(10, 211);
			this.TickHeightScrollBar.Maximum = 20;
			this.TickHeightScrollBar.MinimumSize = new System.Drawing.Size(34, 17);
			this.TickHeightScrollBar.Name = "TickHeightScrollBar";
			this.TickHeightScrollBar.Size = new System.Drawing.Size(125, 17);
			this.TickHeightScrollBar.TabIndex = 26;
			this.TickHeightScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.TickHeightScrollBar_ValueChanged);
			// 
			// NAxisTicksAppearanceUC
			// 
			this.Controls.Add(this.label7);
			this.Controls.Add(this.TickHeightScrollBar);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.TickWidthScrollBar);
			this.Controls.Add(this.TickStrokeStyleButton);
			this.Controls.Add(this.TickShapeComboBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.TickFillStyleButton);
			this.Name = "NAxisTicksAppearanceUC";
			this.Size = new System.Drawing.Size(150, 264);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Axis Ticks Appearance");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // turn off the legend
            nChartControl1.Legends[0].Mode = LegendMode.Disabled;

			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.OuterMajorTickStyle.FillStyle = new NColorFillStyle(Color.Red);

			// hide all tick except the outer major just to demonstrate the shape / fill / stroke control
			linearScale.InnerMajorTickStyle.Visible = false;
			linearScale.InnerMinorTickStyle.Visible = false;
			linearScale.OuterMinorTickStyle.Visible = false;

			// add interlaced stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            linearScale.StripStyles.Add(stripStyle);

			NBarSeries bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			bar.Values.FillRandom(Random, 5);
			bar.FillStyle = new NColorFillStyle(Color.DarkOrchid);
			bar.DataLabelStyle.Format = "<value>";
			bar.Name = "Bars";

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			TickShapeComboBox.FillFromEnum(typeof(ScaleTickShape));
			TickShapeComboBox.SelectedIndex = (int)ScaleTickShape.Triangle;

			TickWidthScrollBar.Value = 4;
			TickHeightScrollBar.Value = 8;
		}
		
		private void TickShapeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_Chart == null)
				return;

			NLinearScaleConfigurator scale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scale.OuterMajorTickStyle.Shape = (ScaleTickShape)TickShapeComboBox.SelectedIndex;

			nChartControl1.Refresh();
		}

		private void TickFillStyleButton_Click(object sender, EventArgs e)
		{
			if (m_Chart == null)
				return;

			NLinearScaleConfigurator scale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			NFillStyle fillStyle = null;

			if (NFillStyleTypeEditorNoAutomatic.Edit(scale.OuterMajorTickStyle.FillStyle, false, out fillStyle))
			{
				scale.OuterMajorTickStyle.FillStyle = fillStyle;
				nChartControl1.Refresh();
			}
		}

		private void TickStrokeStyleButton_Click(object sender, EventArgs e)
		{
			if (m_Chart == null)
				return;

			NLinearScaleConfigurator scale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			NStrokeStyle strokeStyle = null;

			if (NStrokeStyleTypeEditorNoAutomatic.Edit(scale.OuterMajorTickStyle.LineStyle, false, out strokeStyle))
			{
				scale.OuterMajorTickStyle.LineStyle = strokeStyle;
				nChartControl1.Refresh();
			}
		}

		private void TickWidthScrollBar_ValueChanged(object sender, ScrollBarEventArgs e)
		{
			if (m_Chart == null)
				return;

			NLinearScaleConfigurator scale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scale.OuterMajorTickStyle.Width = new NLength(TickWidthScrollBar.Value);

			nChartControl1.Refresh();
		}

		private void TickHeightScrollBar_ValueChanged(object sender, ScrollBarEventArgs e)
		{
			if (m_Chart == null)
				return;

			NLinearScaleConfigurator scale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scale.OuterMajorTickStyle.Length = new NLength(TickHeightScrollBar.Value);

			nChartControl1.Refresh();
		}
	}
}
