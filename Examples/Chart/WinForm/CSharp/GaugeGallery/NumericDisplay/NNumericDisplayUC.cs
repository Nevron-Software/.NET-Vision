using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NNumericDisplayUC : NExampleBaseUC
	{
		private int m_Counter = 0;
		private NNumericDisplayPanel m_NumericDisplay1;
		private NNumericDisplayPanel m_NumericDisplay2;
		private NNumericDisplayPanel m_NumericDisplay3;
		private Random m_Random = new Random();
		private Nevron.UI.WinForm.Controls.NButton LitFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton DimFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton StopStartTimerButton;
		private Nevron.UI.WinForm.Controls.NComboBox CellSizeComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox DisplayStyleComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox SignModeComboBox;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowLeadingZerosCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox AttachSignToNumberCheckBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Timer DataFeedTimer;
		private System.ComponentModel.IContainer components;

		public NNumericDisplayUC()
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
			this.components = new System.ComponentModel.Container();
			this.LitFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.DimFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.CellSizeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.DataFeedTimer = new System.Windows.Forms.Timer(this.components);
			this.StopStartTimerButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label2 = new System.Windows.Forms.Label();
			this.DisplayStyleComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SignModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.ShowLeadingZerosCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.AttachSignToNumberCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// LitFillStyleButton
			// 
			this.LitFillStyleButton.Location = new System.Drawing.Point(8, 16);
			this.LitFillStyleButton.Name = "LitFillStyleButton";
			this.LitFillStyleButton.Size = new System.Drawing.Size(159, 23);
			this.LitFillStyleButton.TabIndex = 0;
			this.LitFillStyleButton.Text = "Lit Fill Style";
			this.LitFillStyleButton.Click += new System.EventHandler(this.LitFillStyleButton_Click);
			// 
			// DimFillStyleButton
			// 
			this.DimFillStyleButton.Location = new System.Drawing.Point(8, 48);
			this.DimFillStyleButton.Name = "DimFillStyleButton";
			this.DimFillStyleButton.Size = new System.Drawing.Size(159, 23);
			this.DimFillStyleButton.TabIndex = 1;
			this.DimFillStyleButton.Text = "Dim Fill Style";
			this.DimFillStyleButton.Click += new System.EventHandler(this.DimFillStyleButton_Click);
			// 
			// CellSizeComboBox
			// 
			this.CellSizeComboBox.ListProperties.CheckBoxDataMember = "";
			this.CellSizeComboBox.ListProperties.DataSource = null;
			this.CellSizeComboBox.ListProperties.DisplayMember = "";
			this.CellSizeComboBox.Location = new System.Drawing.Point(8, 104);
			this.CellSizeComboBox.Name = "CellSizeComboBox";
			this.CellSizeComboBox.Size = new System.Drawing.Size(159, 21);
			this.CellSizeComboBox.TabIndex = 3;
			this.CellSizeComboBox.Text = "CellSizeComboBox";
			this.CellSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.CellSizeComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(135, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Cell Size:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// DataFeedTimer
			// 
			this.DataFeedTimer.Interval = 500;
			this.DataFeedTimer.Tick += new System.EventHandler(this.DataFeedTimer_Tick);
			// 
			// StopStartTimerButton
			// 
			this.StopStartTimerButton.Location = new System.Drawing.Point(8, 300);
			this.StopStartTimerButton.Name = "StopStartTimerButton";
			this.StopStartTimerButton.Size = new System.Drawing.Size(159, 23);
			this.StopStartTimerButton.TabIndex = 9;
			this.StopStartTimerButton.Text = "Stop Timer";
			this.StopStartTimerButton.Click += new System.EventHandler(this.StopStartTimerButton_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 124);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(135, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Display Style:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// DisplayStyleComboBox
			// 
			this.DisplayStyleComboBox.ListProperties.CheckBoxDataMember = "";
			this.DisplayStyleComboBox.ListProperties.DataSource = null;
			this.DisplayStyleComboBox.ListProperties.DisplayMember = "";
			this.DisplayStyleComboBox.Location = new System.Drawing.Point(8, 148);
			this.DisplayStyleComboBox.Name = "DisplayStyleComboBox";
			this.DisplayStyleComboBox.Size = new System.Drawing.Size(159, 21);
			this.DisplayStyleComboBox.TabIndex = 5;
			this.DisplayStyleComboBox.Text = "nComboBox1";
			this.DisplayStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.DisplayStyleComboBox_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 168);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(135, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Sign Mode:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// SignModeComboBox
			// 
			this.SignModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.SignModeComboBox.ListProperties.DataSource = null;
			this.SignModeComboBox.ListProperties.DisplayMember = "";
			this.SignModeComboBox.Location = new System.Drawing.Point(8, 192);
			this.SignModeComboBox.Name = "SignModeComboBox";
			this.SignModeComboBox.Size = new System.Drawing.Size(159, 21);
			this.SignModeComboBox.TabIndex = 7;
			this.SignModeComboBox.Text = "SignModeComboBox";
			this.SignModeComboBox.SelectedIndexChanged += new System.EventHandler(this.SignModeComboBox_SelectedIndexChanged);
			// 
			// ShowLeadingZerosCheckBox
			// 
			this.ShowLeadingZerosCheckBox.AutoSize = true;
			this.ShowLeadingZerosCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowLeadingZerosCheckBox.Location = new System.Drawing.Point(8, 228);
			this.ShowLeadingZerosCheckBox.Name = "ShowLeadingZerosCheckBox";
			this.ShowLeadingZerosCheckBox.Size = new System.Drawing.Size(118, 17);
			this.ShowLeadingZerosCheckBox.TabIndex = 8;
			this.ShowLeadingZerosCheckBox.Text = "Show leading zeros";
			this.ShowLeadingZerosCheckBox.UseVisualStyleBackColor = true;
			this.ShowLeadingZerosCheckBox.CheckedChanged += new System.EventHandler(this.ShowLeadingZerosCheckBox_CheckedChanged);
			// 
			// AttachSignToNumberCheckBox
			// 
			this.AttachSignToNumberCheckBox.AutoSize = true;
			this.AttachSignToNumberCheckBox.ButtonProperties.BorderOffset = 2;
			this.AttachSignToNumberCheckBox.Location = new System.Drawing.Point(8, 254);
			this.AttachSignToNumberCheckBox.Name = "AttachSignToNumberCheckBox";
			this.AttachSignToNumberCheckBox.Size = new System.Drawing.Size(137, 17);
			this.AttachSignToNumberCheckBox.TabIndex = 10;
			this.AttachSignToNumberCheckBox.Text = "Attach Sign To Number";
			this.AttachSignToNumberCheckBox.UseVisualStyleBackColor = true;
			this.AttachSignToNumberCheckBox.CheckedChanged += new System.EventHandler(this.AttachSignToNumberCheckBox_CheckedChanged);
			// 
			// NNumericDisplayUC
			// 
			this.Controls.Add(this.AttachSignToNumberCheckBox);
			this.Controls.Add(this.ShowLeadingZerosCheckBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.SignModeComboBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.DisplayStyleComboBox);
			this.Controls.Add(this.StopStartTimerButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.CellSizeComboBox);
			this.Controls.Add(this.DimFillStyleButton);
			this.Controls.Add(this.LitFillStyleButton);
			this.Name = "NNumericDisplayUC";
			this.Size = new System.Drawing.Size(180, 336);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Numeric Display Panel");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			header.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			header.Location = new NPointL(
				new NLength(2, NRelativeUnit.ParentPercentage),
				new NLength(2, NRelativeUnit.ParentPercentage));
            nChartControl1.Panels.Add(header);

            NDockPanel dockPanel = new NDockPanel();
            dockPanel.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
            dockPanel.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
            dockPanel.ContentAlignment = ContentAlignment.MiddleCenter;

            nChartControl1.Panels.Add(dockPanel);

            m_NumericDisplay1 = CreateDisplayPanel();
            m_NumericDisplay2 = CreateDisplayPanel();
            m_NumericDisplay3 = CreateDisplayPanel();

            dockPanel.ChildPanels.Add(m_NumericDisplay1);
			dockPanel.ChildPanels.Add(m_NumericDisplay2);
            dockPanel.ChildPanels.Add(m_NumericDisplay3);

			nChartControl1.Refresh();

			// init form controls
			CellSizeComboBox.Items.Add("Small");
			CellSizeComboBox.Items.Add("Normal");
			CellSizeComboBox.Items.Add("Large");
			CellSizeComboBox.SelectedIndex = 1;
			DisplayStyleComboBox.FillFromEnum(typeof(DisplayStyle));
            DisplayStyleComboBox.SelectedIndex = (int)DisplayStyle.SevenSegmentRounded;

			SignModeComboBox.FillFromEnum(typeof(DisplaySignMode));
			SignModeComboBox.SelectedIndex = (int)DisplaySignMode.Never;
 
			DataFeedTimer.Start();
		}

        private NNumericDisplayPanel CreateDisplayPanel()
        {
            NNumericDisplayPanel numericDisplay = new NNumericDisplayPanel();

            numericDisplay.UseAutomaticSize = true;
            numericDisplay.DockMode = PanelDockMode.Top;
            numericDisplay.Value = 0;
            numericDisplay.CellCountMode = DisplayCellCountMode.Fixed;
            numericDisplay.CellCount = 7;
            numericDisplay.Margins = new NMarginsL(10, 10, 10, 10);
            numericDisplay.Padding = new NMarginsL(10, 10, 10, 10);
            numericDisplay.BackgroundFillStyle = new NColorFillStyle(Color.Black);

            // adjust cell fill styles
            numericDisplay.LitFillStyle = new NColorFillStyle(Color.GreenYellow);
            numericDisplay.DimFillStyle.SetTransparencyPercent(50);
            numericDisplay.DecimalLitFillStyle = new NColorFillStyle(Color.Red);
            numericDisplay.DecimalDimFillStyle.SetTransparencyPercent(50);
            
            numericDisplay.BorderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);
            numericDisplay.PaintEffect = new NGelEffectStyle();

            return numericDisplay;
        }

		private void DataFeedTimer_Tick(object sender, System.EventArgs e)
		{
			double value1 = -50 + m_Random.Next(10000) / 100.0;
			m_NumericDisplay1.Value = value1;

			double value2;
			if (m_Counter % 4 == 0)
			{
				value2 = -50 + m_Random.Next(10000) / 100.0;
				m_NumericDisplay2.Value = value2;
			}

			double value3;
			if (m_Counter % 8 == 0)
			{
				value3 = 200 + m_Random.Next(10000) / 100.0;
				m_NumericDisplay3.Value = value3;
			}

			m_Counter++;
			nChartControl1.Refresh();
		}
		private void LitFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyle = null;

			if (NFillStyleTypeEditorNoAutomatic.Edit(m_NumericDisplay1.LitFillStyle, false, out fillStyle))
			{
				m_NumericDisplay1.LitFillStyle = fillStyle;
				m_NumericDisplay2.LitFillStyle = fillStyle;
				m_NumericDisplay3.LitFillStyle = fillStyle;

				nChartControl1.Refresh();
			}
		}
		private void DimFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyle = null;

			if (NFillStyleTypeEditorNoAutomatic.Edit(m_NumericDisplay1.DimFillStyle, false, out fillStyle))
			{
				m_NumericDisplay1.DimFillStyle = fillStyle;
				m_NumericDisplay2.DimFillStyle = fillStyle;
				m_NumericDisplay3.DimFillStyle = fillStyle;

				nChartControl1.Refresh();
			}
		}
		private void CellSizeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NLength segmentWidth = new NLength(0);
			NLength segmentGap = new NLength(0);
			NSizeL cellSize = new NSizeL(new NLength(0), new NLength(0));

			switch (CellSizeComboBox.SelectedIndex)
			{
				case 0: // small
					segmentWidth = new NLength(2, NGraphicsUnit.Point);
					segmentGap = new NLength(1, NGraphicsUnit.Point);
					cellSize = new NSizeL(new NLength(15, NGraphicsUnit.Point), new NLength(30, NGraphicsUnit.Point));
					break;
				case 1: // normal
					segmentWidth = new NLength(3, NGraphicsUnit.Point);
					segmentGap = new NLength(1, NGraphicsUnit.Point);
					cellSize = new NSizeL(new NLength(20, NGraphicsUnit.Point), new NLength(40, NGraphicsUnit.Point));
					break;
				case 2: // large
					segmentWidth = new NLength(4, NGraphicsUnit.Point);
					segmentGap = new NLength(2, NGraphicsUnit.Point);
					cellSize = new NSizeL(new NLength(25, NGraphicsUnit.Point), new NLength(50, NGraphicsUnit.Point));
					break;
			}

			m_NumericDisplay1.CellSize = cellSize;
			m_NumericDisplay2.CellSize = cellSize;
			m_NumericDisplay3.CellSize = cellSize;

			m_NumericDisplay1.DecimalCellSize = cellSize;
			m_NumericDisplay2.DecimalCellSize = cellSize;
			m_NumericDisplay3.DecimalCellSize = cellSize;

			m_NumericDisplay1.SegmentGap = segmentGap;
			m_NumericDisplay2.SegmentGap = segmentGap;
			m_NumericDisplay3.SegmentGap = segmentGap;

			m_NumericDisplay1.SegmentWidth = segmentWidth;
			m_NumericDisplay2.SegmentWidth = segmentWidth;
			m_NumericDisplay3.SegmentWidth = segmentWidth;

			nChartControl1.Refresh();
		}
		private void StopStartTimerButton_Click(object sender, System.EventArgs e)
		{
			if (this.DataFeedTimer.Enabled)
			{
				this.DataFeedTimer.Stop();
				StopStartTimerButton.Text = "Start Timer";
			}
			else
			{
				this.DataFeedTimer.Start();
				StopStartTimerButton.Text = "Stop Timer";
			}
		}
		private void DisplayStyleComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_NumericDisplay1.DisplayStyle = (DisplayStyle)DisplayStyleComboBox.SelectedIndex;
			m_NumericDisplay2.DisplayStyle = (DisplayStyle)DisplayStyleComboBox.SelectedIndex;
			m_NumericDisplay3.DisplayStyle = (DisplayStyle)DisplayStyleComboBox.SelectedIndex;

			nChartControl1.Refresh();
		}
		private void SignModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_NumericDisplay1.SignMode = (DisplaySignMode)SignModeComboBox.SelectedIndex;
			m_NumericDisplay2.SignMode = (DisplaySignMode)SignModeComboBox.SelectedIndex;
			m_NumericDisplay3.SignMode = (DisplaySignMode)SignModeComboBox.SelectedIndex;

			nChartControl1.Refresh();
		}
		private void ShowLeadingZerosCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_NumericDisplay1.ShowLeadingZeros = ShowLeadingZerosCheckBox.Checked;
			m_NumericDisplay2.ShowLeadingZeros = ShowLeadingZerosCheckBox.Checked;
			m_NumericDisplay3.ShowLeadingZeros = ShowLeadingZerosCheckBox.Checked;

			nChartControl1.Refresh();
		}
		private void AttachSignToNumberCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_NumericDisplay1.AttachSignToNumber = AttachSignToNumberCheckBox.Checked;
			m_NumericDisplay2.AttachSignToNumber = AttachSignToNumberCheckBox.Checked;
			m_NumericDisplay3.AttachSignToNumber = AttachSignToNumberCheckBox.Checked;

			nChartControl1.Refresh();
		}
	}
}
