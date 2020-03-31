using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NDataPointDragToolUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox ChartTypeComboBox;
		private System.ComponentModel.Container components = null;
		private NChart m_Chart;
		private Nevron.UI.WinForm.Controls.NCheckBox AllowHorizontalDraggingCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox AllowVerticalDraggingCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox Drag2D3DCheckBox;
		private UI.WinForm.Controls.NCheckBox AllowDraggingOutsideAxisRangeCheckBox;
		private NDataPointDragTool m_DataPointDragTool;

		public NDataPointDragToolUC()
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
			this.ChartTypeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.AllowHorizontalDraggingCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.AllowVerticalDraggingCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.Drag2D3DCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.AllowDraggingOutsideAxisRangeCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(111, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Chart type:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ChartTypeComboBox
			// 
			this.ChartTypeComboBox.ListProperties.CheckBoxDataMember = "";
			this.ChartTypeComboBox.ListProperties.DataSource = null;
			this.ChartTypeComboBox.ListProperties.DisplayMember = "";
			this.ChartTypeComboBox.Location = new System.Drawing.Point(11, 27);
			this.ChartTypeComboBox.Name = "ChartTypeComboBox";
			this.ChartTypeComboBox.Palette.Border = System.Drawing.SystemColors.ControlDarkDark;
			this.ChartTypeComboBox.Palette.Caption = System.Drawing.SystemColors.ControlDarkDark;
			this.ChartTypeComboBox.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(151)))), ((int)(((byte)(184)))));
			this.ChartTypeComboBox.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(151)))), ((int)(((byte)(184)))));
			this.ChartTypeComboBox.Palette.Control = System.Drawing.SystemColors.Control;
			this.ChartTypeComboBox.Palette.ControlBorder = System.Drawing.SystemColors.ControlDarkDark;
			this.ChartTypeComboBox.Palette.ControlDark = System.Drawing.SystemColors.Control;
			this.ChartTypeComboBox.Palette.ControlLight = System.Drawing.SystemColors.Control;
			this.ChartTypeComboBox.Palette.Highlight = System.Drawing.SystemColors.Highlight;
			this.ChartTypeComboBox.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(169)))), ((int)(((byte)(196)))));
			this.ChartTypeComboBox.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(169)))), ((int)(((byte)(196)))));
			this.ChartTypeComboBox.Palette.HighlightText = System.Drawing.SystemColors.HighlightText;
			this.ChartTypeComboBox.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(228)))));
			this.ChartTypeComboBox.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(117)))), ((int)(((byte)(161)))));
			this.ChartTypeComboBox.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(117)))), ((int)(((byte)(161)))));
			this.ChartTypeComboBox.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(12)))), ((int)(((byte)(35)))));
			this.ChartTypeComboBox.Palette.Window = System.Drawing.SystemColors.Window;
			this.ChartTypeComboBox.Size = new System.Drawing.Size(156, 21);
			this.ChartTypeComboBox.TabIndex = 1;
			this.ChartTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ChartTypeComboBox_SelectedIndexChanged);
			// 
			// AllowHorizontalDraggingCheckBox
			// 
			this.AllowHorizontalDraggingCheckBox.ButtonProperties.BorderOffset = 2;
			this.AllowHorizontalDraggingCheckBox.Location = new System.Drawing.Point(11, 49);
			this.AllowHorizontalDraggingCheckBox.Name = "AllowHorizontalDraggingCheckBox";
			this.AllowHorizontalDraggingCheckBox.Palette.Border = System.Drawing.SystemColors.ControlDarkDark;
			this.AllowHorizontalDraggingCheckBox.Palette.Caption = System.Drawing.SystemColors.ControlDarkDark;
			this.AllowHorizontalDraggingCheckBox.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(151)))), ((int)(((byte)(184)))));
			this.AllowHorizontalDraggingCheckBox.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(151)))), ((int)(((byte)(184)))));
			this.AllowHorizontalDraggingCheckBox.Palette.Control = System.Drawing.SystemColors.Control;
			this.AllowHorizontalDraggingCheckBox.Palette.ControlBorder = System.Drawing.SystemColors.ControlDarkDark;
			this.AllowHorizontalDraggingCheckBox.Palette.ControlDark = System.Drawing.SystemColors.Control;
			this.AllowHorizontalDraggingCheckBox.Palette.ControlLight = System.Drawing.SystemColors.Control;
			this.AllowHorizontalDraggingCheckBox.Palette.Highlight = System.Drawing.SystemColors.Highlight;
			this.AllowHorizontalDraggingCheckBox.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(169)))), ((int)(((byte)(196)))));
			this.AllowHorizontalDraggingCheckBox.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(169)))), ((int)(((byte)(196)))));
			this.AllowHorizontalDraggingCheckBox.Palette.HighlightText = System.Drawing.SystemColors.HighlightText;
			this.AllowHorizontalDraggingCheckBox.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(228)))));
			this.AllowHorizontalDraggingCheckBox.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(117)))), ((int)(((byte)(161)))));
			this.AllowHorizontalDraggingCheckBox.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(117)))), ((int)(((byte)(161)))));
			this.AllowHorizontalDraggingCheckBox.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(12)))), ((int)(((byte)(35)))));
			this.AllowHorizontalDraggingCheckBox.Palette.Window = System.Drawing.SystemColors.Window;
			this.AllowHorizontalDraggingCheckBox.Size = new System.Drawing.Size(156, 24);
			this.AllowHorizontalDraggingCheckBox.TabIndex = 2;
			this.AllowHorizontalDraggingCheckBox.Text = "Allow horizontal dragging";
			this.AllowHorizontalDraggingCheckBox.CheckedChanged += new System.EventHandler(this.AllowHorizontalDraggingCheckBox_CheckedChanged);
			// 
			// AllowVerticalDraggingCheckBox
			// 
			this.AllowVerticalDraggingCheckBox.ButtonProperties.BorderOffset = 2;
			this.AllowVerticalDraggingCheckBox.Location = new System.Drawing.Point(11, 74);
			this.AllowVerticalDraggingCheckBox.Name = "AllowVerticalDraggingCheckBox";
			this.AllowVerticalDraggingCheckBox.Palette.Border = System.Drawing.SystemColors.ControlDarkDark;
			this.AllowVerticalDraggingCheckBox.Palette.Caption = System.Drawing.SystemColors.ControlDarkDark;
			this.AllowVerticalDraggingCheckBox.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(151)))), ((int)(((byte)(184)))));
			this.AllowVerticalDraggingCheckBox.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(151)))), ((int)(((byte)(184)))));
			this.AllowVerticalDraggingCheckBox.Palette.Control = System.Drawing.SystemColors.Control;
			this.AllowVerticalDraggingCheckBox.Palette.ControlBorder = System.Drawing.SystemColors.ControlDarkDark;
			this.AllowVerticalDraggingCheckBox.Palette.ControlDark = System.Drawing.SystemColors.Control;
			this.AllowVerticalDraggingCheckBox.Palette.ControlLight = System.Drawing.SystemColors.Control;
			this.AllowVerticalDraggingCheckBox.Palette.Highlight = System.Drawing.SystemColors.Highlight;
			this.AllowVerticalDraggingCheckBox.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(169)))), ((int)(((byte)(196)))));
			this.AllowVerticalDraggingCheckBox.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(169)))), ((int)(((byte)(196)))));
			this.AllowVerticalDraggingCheckBox.Palette.HighlightText = System.Drawing.SystemColors.HighlightText;
			this.AllowVerticalDraggingCheckBox.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(228)))));
			this.AllowVerticalDraggingCheckBox.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(117)))), ((int)(((byte)(161)))));
			this.AllowVerticalDraggingCheckBox.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(117)))), ((int)(((byte)(161)))));
			this.AllowVerticalDraggingCheckBox.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(12)))), ((int)(((byte)(35)))));
			this.AllowVerticalDraggingCheckBox.Palette.Window = System.Drawing.SystemColors.Window;
			this.AllowVerticalDraggingCheckBox.Size = new System.Drawing.Size(156, 24);
			this.AllowVerticalDraggingCheckBox.TabIndex = 3;
			this.AllowVerticalDraggingCheckBox.Text = "Allow vertical dragging";
			this.AllowVerticalDraggingCheckBox.CheckedChanged += new System.EventHandler(this.AllowVerticalDraggingCheckBox_CheckedChanged);
			// 
			// Drag2D3DCheckBox
			// 
			this.Drag2D3DCheckBox.ButtonProperties.BorderOffset = 2;
			this.Drag2D3DCheckBox.Location = new System.Drawing.Point(11, 124);
			this.Drag2D3DCheckBox.Name = "Drag2D3DCheckBox";
			this.Drag2D3DCheckBox.Palette.Border = System.Drawing.SystemColors.ControlDarkDark;
			this.Drag2D3DCheckBox.Palette.Caption = System.Drawing.SystemColors.ControlDarkDark;
			this.Drag2D3DCheckBox.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(151)))), ((int)(((byte)(184)))));
			this.Drag2D3DCheckBox.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(151)))), ((int)(((byte)(184)))));
			this.Drag2D3DCheckBox.Palette.Control = System.Drawing.SystemColors.Control;
			this.Drag2D3DCheckBox.Palette.ControlBorder = System.Drawing.SystemColors.ControlDarkDark;
			this.Drag2D3DCheckBox.Palette.ControlDark = System.Drawing.SystemColors.Control;
			this.Drag2D3DCheckBox.Palette.ControlLight = System.Drawing.SystemColors.Control;
			this.Drag2D3DCheckBox.Palette.Highlight = System.Drawing.SystemColors.Highlight;
			this.Drag2D3DCheckBox.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(169)))), ((int)(((byte)(196)))));
			this.Drag2D3DCheckBox.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(169)))), ((int)(((byte)(196)))));
			this.Drag2D3DCheckBox.Palette.HighlightText = System.Drawing.SystemColors.HighlightText;
			this.Drag2D3DCheckBox.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(228)))));
			this.Drag2D3DCheckBox.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(117)))), ((int)(((byte)(161)))));
			this.Drag2D3DCheckBox.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(117)))), ((int)(((byte)(161)))));
			this.Drag2D3DCheckBox.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(12)))), ((int)(((byte)(35)))));
			this.Drag2D3DCheckBox.Palette.Window = System.Drawing.SystemColors.Window;
			this.Drag2D3DCheckBox.Size = new System.Drawing.Size(156, 24);
			this.Drag2D3DCheckBox.TabIndex = 5;
			this.Drag2D3DCheckBox.Text = "3D data point dragging";
			this.Drag2D3DCheckBox.CheckedChanged += new System.EventHandler(this.Drag2D3DCheckBox_CheckedChanged);
			// 
			// AllowDraggingOutsideAxisRangeCheckBox
			// 
			this.AllowDraggingOutsideAxisRangeCheckBox.ButtonProperties.BorderOffset = 2;
			this.AllowDraggingOutsideAxisRangeCheckBox.Location = new System.Drawing.Point(11, 99);
			this.AllowDraggingOutsideAxisRangeCheckBox.Name = "AllowDraggingOutsideAxisRangeCheckBox";
			this.AllowDraggingOutsideAxisRangeCheckBox.Palette.Border = System.Drawing.SystemColors.ControlDarkDark;
			this.AllowDraggingOutsideAxisRangeCheckBox.Palette.Caption = System.Drawing.SystemColors.ControlDarkDark;
			this.AllowDraggingOutsideAxisRangeCheckBox.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(151)))), ((int)(((byte)(184)))));
			this.AllowDraggingOutsideAxisRangeCheckBox.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(151)))), ((int)(((byte)(184)))));
			this.AllowDraggingOutsideAxisRangeCheckBox.Palette.Control = System.Drawing.SystemColors.Control;
			this.AllowDraggingOutsideAxisRangeCheckBox.Palette.ControlBorder = System.Drawing.SystemColors.ControlDarkDark;
			this.AllowDraggingOutsideAxisRangeCheckBox.Palette.ControlDark = System.Drawing.SystemColors.Control;
			this.AllowDraggingOutsideAxisRangeCheckBox.Palette.ControlLight = System.Drawing.SystemColors.Control;
			this.AllowDraggingOutsideAxisRangeCheckBox.Palette.Highlight = System.Drawing.SystemColors.Highlight;
			this.AllowDraggingOutsideAxisRangeCheckBox.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(169)))), ((int)(((byte)(196)))));
			this.AllowDraggingOutsideAxisRangeCheckBox.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(169)))), ((int)(((byte)(196)))));
			this.AllowDraggingOutsideAxisRangeCheckBox.Palette.HighlightText = System.Drawing.SystemColors.HighlightText;
			this.AllowDraggingOutsideAxisRangeCheckBox.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(228)))));
			this.AllowDraggingOutsideAxisRangeCheckBox.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(117)))), ((int)(((byte)(161)))));
			this.AllowDraggingOutsideAxisRangeCheckBox.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(117)))), ((int)(((byte)(161)))));
			this.AllowDraggingOutsideAxisRangeCheckBox.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(12)))), ((int)(((byte)(35)))));
			this.AllowDraggingOutsideAxisRangeCheckBox.Palette.Window = System.Drawing.SystemColors.Window;
			this.AllowDraggingOutsideAxisRangeCheckBox.Size = new System.Drawing.Size(199, 24);
			this.AllowDraggingOutsideAxisRangeCheckBox.TabIndex = 4;
			this.AllowDraggingOutsideAxisRangeCheckBox.Text = "Allow dragging outside axis range";
			this.AllowDraggingOutsideAxisRangeCheckBox.CheckedChanged += new System.EventHandler(this.AllowDraggingOutsideAxisRangeCheckBox_CheckedChanged);
			// 
			// NDataPointDragToolUC
			// 
			this.Controls.Add(this.AllowDraggingOutsideAxisRangeCheckBox);
			this.Controls.Add(this.Drag2D3DCheckBox);
			this.Controls.Add(this.AllowVerticalDraggingCheckBox);
			this.Controls.Add(this.AllowHorizontalDraggingCheckBox);
			this.Controls.Add(this.ChartTypeComboBox);
			this.Controls.Add(this.label1);
			this.Name = "NDataPointDragToolUC";
			this.Size = new System.Drawing.Size(218, 182);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// Configure device and background
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Data Point Drag Tool");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			m_Chart = (NChart)nChartControl1.Charts[0];

			nChartControl1.Controller.Tools.Add(new NSelectorTool());

			m_DataPointDragTool = new NDataPointDragTool();
			m_DataPointDragTool.DepthAxisValue = 0;
			nChartControl1.Controller.Tools.Add(m_DataPointDragTool);

			nChartControl1.Controller.Selection.Add(m_Chart);
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();

			ChartTypeComboBox.Items.Add("Point");
			ChartTypeComboBox.Items.Add("Line");
			ChartTypeComboBox.Items.Add("Smooth Line");
			ChartTypeComboBox.Items.Add("Bar");
			ChartTypeComboBox.SelectedIndex = 0;

			AllowHorizontalDraggingCheckBox.Checked = true;
			AllowVerticalDraggingCheckBox.Checked = true;
			AllowDraggingOutsideAxisRangeCheckBox.Checked = true;
			Drag2D3DCheckBox.Checked = false;
		}

		private void ChartTypeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Chart.Series.Clear();

			NXYScatterSeries series = null;

			switch (ChartTypeComboBox.SelectedIndex)
			{
				case 0: // point
					series = (NXYScatterSeries)m_Chart.Series.Add(SeriesType.Point);
					series.Name = "Point series";
					break;

				case 1: // line 
					series = (NXYScatterSeries)m_Chart.Series.Add(SeriesType.Line);
					series.Name = "Line series";
					series.MarkerStyle.Visible = true;
					break;

				case 2: // smooth line
					series = (NXYScatterSeries)m_Chart.Series.Add(SeriesType.SmoothLine);
					series.Name = "Smooth line series";
					series.MarkerStyle.Visible = true;
					((NSmoothLineSeries)series).Use1DInterpolationForXYScatter = false;
					break;

				case 3: // bar
					series = (NXYScatterSeries)m_Chart.Series.Add(SeriesType.Bar);
					series.Name = "Bar series";
					series.MarkerStyle.Visible = false;
					break;

				default:
					Debug.Assert(false);
					break;
			}

			series.DataLabelStyle.Visible = false;
			NDataPoint dp = new NDataPoint();

			series.UseXValues = true;

			for (int i = 0; i < 10; i++)
			{
				dp[DataPointValue.Y] = Random.Next(100);
				dp[DataPointValue.X] = Random.Next(100);
				dp[DataPointValue.Label] = "Item" + i.ToString();
				series.AddDataPoint(dp);
			}

			nChartControl1.Refresh();
		}

		private void AllowHorizontalDraggingCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			m_DataPointDragTool.AllowHorizontalDragging = AllowHorizontalDraggingCheckBox.Checked;
		}

		private void AllowVerticalDraggingCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			m_DataPointDragTool.AllowVerticalDragging = AllowVerticalDraggingCheckBox.Checked;
		}

		private void Drag2D3DCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = (NChart)nChartControl1.Charts[0];
			if (Drag2D3DCheckBox.Checked)
			{
				chart.Enable3D = true;
				chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			}
			else
			{
				chart.Enable3D = false;
			}

			nChartControl1.Refresh();
		}

		private void AllowDraggingOutsideAxisRangeCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_DataPointDragTool.DragOutsideAxisRangeMode = AllowDraggingOutsideAxisRangeCheckBox.Checked ? DragOutsideAxisRangeMode.Enabled : DragOutsideAxisRangeMode.Disabled;
		}
	}
}
