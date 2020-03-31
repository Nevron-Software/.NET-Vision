using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NRangeSelectionMoveResizeToolUC2 : NExampleBaseUC
    {
		private System.ComponentModel.Container components = null;
        private UI.WinForm.Controls.NCheckBox AllowPanCheckBox;
        private UI.WinForm.Controls.NCheckBox AllowVerticalResizeCheckBox;
        private UI.WinForm.Controls.NCheckBox AllowHorizontalResizeCheckBox;
        private Label label2;
        private UI.WinForm.Controls.NTextBox HorizontalRangeTextBox;
        private Label label1;
        private UI.WinForm.Controls.NTextBox VerticalRangeTextBox;
        private UI.WinForm.Controls.NCheckBox PaintInvertedCheckBox;

        NRangeSelection m_RangeSelection;

		public NRangeSelectionMoveResizeToolUC2()
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
            this.AllowPanCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.AllowVerticalResizeCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.AllowHorizontalResizeCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.HorizontalRangeTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.VerticalRangeTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
            this.PaintInvertedCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.SuspendLayout();
            // 
            // AllowPanCheckBox
            // 
            this.AllowPanCheckBox.ButtonProperties.BorderOffset = 2;
            this.AllowPanCheckBox.Location = new System.Drawing.Point(6, 48);
            this.AllowPanCheckBox.Name = "AllowPanCheckBox";
            this.AllowPanCheckBox.Size = new System.Drawing.Size(120, 24);
            this.AllowPanCheckBox.TabIndex = 2;
            this.AllowPanCheckBox.Text = "Allow Pan";
            this.AllowPanCheckBox.CheckedChanged += new System.EventHandler(this.AllowPanCheckBox_CheckedChanged);
            // 
            // AllowVerticalResizeCheckBox
            // 
            this.AllowVerticalResizeCheckBox.ButtonProperties.BorderOffset = 2;
            this.AllowVerticalResizeCheckBox.Location = new System.Drawing.Point(6, 27);
            this.AllowVerticalResizeCheckBox.Name = "AllowVerticalResizeCheckBox";
            this.AllowVerticalResizeCheckBox.Size = new System.Drawing.Size(143, 24);
            this.AllowVerticalResizeCheckBox.TabIndex = 1;
            this.AllowVerticalResizeCheckBox.Text = "Allow Vertical Resize";
            this.AllowVerticalResizeCheckBox.CheckedChanged += new System.EventHandler(this.AllowVerticalResizeCheckBox_CheckedChanged);
            // 
            // AllowHorizontalResizeCheckBox
            // 
            this.AllowHorizontalResizeCheckBox.ButtonProperties.BorderOffset = 2;
            this.AllowHorizontalResizeCheckBox.Location = new System.Drawing.Point(6, 6);
            this.AllowHorizontalResizeCheckBox.Name = "AllowHorizontalResizeCheckBox";
            this.AllowHorizontalResizeCheckBox.Size = new System.Drawing.Size(158, 24);
            this.AllowHorizontalResizeCheckBox.TabIndex = 0;
            this.AllowHorizontalResizeCheckBox.Text = "Allow Horizontal Resize";
            this.AllowHorizontalResizeCheckBox.CheckedChanged += new System.EventHandler(this.AllowHorizontalResizeCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Horizontal Range:";
            // 
            // HorizontalRangeTextBox
            // 
            this.HorizontalRangeTextBox.Location = new System.Drawing.Point(6, 116);
            this.HorizontalRangeTextBox.Name = "HorizontalRangeTextBox";
            this.HorizontalRangeTextBox.ReadOnly = true;
            this.HorizontalRangeTextBox.Size = new System.Drawing.Size(157, 18);
            this.HorizontalRangeTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Vertical Range:";
            // 
            // VerticalRangeTextBox
            // 
            this.VerticalRangeTextBox.Location = new System.Drawing.Point(6, 157);
            this.VerticalRangeTextBox.Name = "VerticalRangeTextBox";
            this.VerticalRangeTextBox.ReadOnly = true;
            this.VerticalRangeTextBox.Size = new System.Drawing.Size(157, 18);
            this.VerticalRangeTextBox.TabIndex = 7;
            // 
            // PaintInvertedCheckBox
            // 
            this.PaintInvertedCheckBox.ButtonProperties.BorderOffset = 2;
            this.PaintInvertedCheckBox.Location = new System.Drawing.Point(6, 69);
            this.PaintInvertedCheckBox.Name = "PaintInvertedCheckBox";
            this.PaintInvertedCheckBox.Size = new System.Drawing.Size(120, 24);
            this.PaintInvertedCheckBox.TabIndex = 3;
            this.PaintInvertedCheckBox.Text = "Paint Inverted";
            this.PaintInvertedCheckBox.CheckedChanged += new System.EventHandler(this.PaintInvertedCheckBox_CheckedChanged);
            // 
            // NRangeSelectionMoveResizeToolUC2
            // 
            this.Controls.Add(this.PaintInvertedCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VerticalRangeTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HorizontalRangeTextBox);
            this.Controls.Add(this.AllowHorizontalResizeCheckBox);
            this.Controls.Add(this.AllowVerticalResizeCheckBox);
            this.Controls.Add(this.AllowPanCheckBox);
            this.Name = "NRangeSelectionMoveResizeToolUC2";
            this.Size = new System.Drawing.Size(180, 664);
            this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("Range Selection Resize and Panning");
            title.DockMode = PanelDockMode.Top;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
            nChartControl1.Panels.Add(title);

			// configure chart
            NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];

            // switch the x to linear scale
            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator ();

            // create the range selection
            m_RangeSelection = new NRangeSelection();

            m_RangeSelection.AllowHorizontalResize = true;
            m_RangeSelection.AllowVerticalResize = true;
            m_RangeSelection.AllowPan = true;

            m_RangeSelection.PaintInverted = true;
            m_RangeSelection.HorizontalAxisRange = new Nevron.GraphicsCore.NRange1DD(20, 40);
            m_RangeSelection.VerticalAxisRange = new Nevron.GraphicsCore.NRange1DD(20, 40);
            m_RangeSelection.Visible = true;
            m_RangeSelection.ShowGrippers = true;

            chart.RangeSelections.Add(m_RangeSelection);

            m_RangeSelection.HorizontalAxisRangeChanged += new EventHandler(OnRangeSelectionHorizontalAxisRangeChanged);
            m_RangeSelection.VerticalAxisRangeChanged += new EventHandler(OnRangeSelectionVerticalAxisRangeChanged);

            NPointSeries point = new NPointSeries();
            point.UseXValues = true;
            point.InflateMargins = true;
            point.Size = new NLength(5);
            point.DataLabelStyle.Visible = false;

            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                point.Values.Add(random.Next(100));
                point.XValues.Add(random.Next(100));
            }

            chart.Series.Add(point);

            nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
            nChartControl1.Controller.Tools.Add(new NRangeSelectionMoveResizeTool());

            AllowHorizontalResizeCheckBox.Checked = m_RangeSelection.AllowHorizontalResize;
            AllowVerticalResizeCheckBox.Checked = m_RangeSelection.AllowVerticalResize;
            AllowPanCheckBox.Checked = m_RangeSelection.AllowPan;
            PaintInvertedCheckBox.Checked = m_RangeSelection.PaintInverted;
		}

        void OnRangeSelectionVerticalAxisRangeChanged(object sender, EventArgs e)
        {
            VerticalRangeTextBox.Text = "Begin:" + m_RangeSelection.VerticalAxisRange.Begin.ToString() + ", End:" + m_RangeSelection.VerticalAxisRange.End.ToString();
        }

        void OnRangeSelectionHorizontalAxisRangeChanged(object sender, EventArgs e)
        {
            HorizontalRangeTextBox.Text = "Begin:" + m_RangeSelection.HorizontalAxisRange.Begin.ToString() + ", End:" + m_RangeSelection.HorizontalAxisRange.End.ToString();
        }

        private void AllowHorizontalResizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_RangeSelection.AllowHorizontalResize = AllowHorizontalResizeCheckBox.Checked;
            nChartControl1.RefreshOverlay();
        }

        private void AllowVerticalResizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_RangeSelection.AllowVerticalResize = AllowVerticalResizeCheckBox.Checked;
            nChartControl1.RefreshOverlay();
        }

        private void AllowPanCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_RangeSelection.AllowPan = AllowPanCheckBox.Checked;
            nChartControl1.RefreshOverlay();
        }

        private void PaintInvertedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_RangeSelection.PaintInverted = PaintInvertedCheckBox.Checked;
            nChartControl1.RefreshOverlay();
        }
	}
}
