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
	public class NDataZoomToolUC : NExampleBaseUC
	{
		private NDataZoomTool m_DataZoomTool;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NButton ResetAxesButton;
		private Nevron.UI.WinForm.Controls.NComboBox SampleChartComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox SelectionAxesComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox InteractivityToolComboBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NButton ZoomInFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton ZoomOutFillStyleButton;
		private Nevron.UI.WinForm.Controls.NCheckBox ZoomOutResetsAxesCheckBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NComboBox HorizontalAxisSnapModeComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox VerticalAxisSnapModeComboBox;
		private Nevron.UI.WinForm.Controls.NCheckBox AlwaysZoomInCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox PreserveAspectRatioCheckBox;
		private UI.WinForm.Controls.NCheckBox WheelZoomCheckBox;
		private System.ComponentModel.Container components = null;

		public NDataZoomToolUC()
		{
			InitializeComponent();

			m_DataZoomTool = new NDataZoomTool();
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
			this.ResetAxesButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.SampleChartComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SelectionAxesComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.InteractivityToolComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.ZoomInFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ZoomOutFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ZoomOutResetsAxesCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.HorizontalAxisSnapModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.VerticalAxisSnapModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.AlwaysZoomInCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.PreserveAspectRatioCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.WheelZoomCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// ResetAxesButton
			// 
			this.ResetAxesButton.Location = new System.Drawing.Point(8, 567);
			this.ResetAxesButton.Name = "ResetAxesButton";
			this.ResetAxesButton.Size = new System.Drawing.Size(160, 23);
			this.ResetAxesButton.TabIndex = 20;
			this.ResetAxesButton.Text = "Reset axes";
			this.ResetAxesButton.Click += new System.EventHandler(this.ResetAxesButton_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Sample chart:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SampleChartComboBox
			// 
			this.SampleChartComboBox.ListProperties.CheckBoxDataMember = "";
			this.SampleChartComboBox.ListProperties.DataSource = null;
			this.SampleChartComboBox.ListProperties.DisplayMember = "";
			this.SampleChartComboBox.Location = new System.Drawing.Point(8, 80);
			this.SampleChartComboBox.Name = "SampleChartComboBox";
			this.SampleChartComboBox.Size = new System.Drawing.Size(160, 21);
			this.SampleChartComboBox.TabIndex = 3;
			this.SampleChartComboBox.SelectedIndexChanged += new System.EventHandler(this.SampleChartComboBox_SelectedIndexChanged);
			// 
			// SelectionAxesComboBox
			// 
			this.SelectionAxesComboBox.ListProperties.CheckBoxDataMember = "";
			this.SelectionAxesComboBox.ListProperties.DataSource = null;
			this.SelectionAxesComboBox.ListProperties.DisplayMember = "";
			this.SelectionAxesComboBox.Location = new System.Drawing.Point(8, 120);
			this.SelectionAxesComboBox.Name = "SelectionAxesComboBox";
			this.SelectionAxesComboBox.Size = new System.Drawing.Size(160, 21);
			this.SelectionAxesComboBox.TabIndex = 5;
			this.SelectionAxesComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectionAxesComboBox_SelectedIndexChanged);
			// 
			// InteractivityToolComboBox
			// 
			this.InteractivityToolComboBox.ListProperties.CheckBoxDataMember = "";
			this.InteractivityToolComboBox.ListProperties.DataSource = null;
			this.InteractivityToolComboBox.ListProperties.DisplayMember = "";
			this.InteractivityToolComboBox.Location = new System.Drawing.Point(8, 32);
			this.InteractivityToolComboBox.Name = "InteractivityToolComboBox";
			this.InteractivityToolComboBox.Size = new System.Drawing.Size(160, 21);
			this.InteractivityToolComboBox.TabIndex = 1;
			this.InteractivityToolComboBox.SelectedIndexChanged += new System.EventHandler(this.InteractivityToolComboBox_SelectedIndexChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(160, 16);
			this.label8.TabIndex = 0;
			this.label8.Text = "Interactivity tool:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(160, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "Selection axes:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ZoomInFillStyleButton
			// 
			this.ZoomInFillStyleButton.Location = new System.Drawing.Point(8, 152);
			this.ZoomInFillStyleButton.Name = "ZoomInFillStyleButton";
			this.ZoomInFillStyleButton.Size = new System.Drawing.Size(160, 23);
			this.ZoomInFillStyleButton.TabIndex = 6;
			this.ZoomInFillStyleButton.Text = "Zoom In Fill Style...";
			this.ZoomInFillStyleButton.Click += new System.EventHandler(this.ZoomInFillStyleButton_Click);
			// 
			// ZoomOutFillStyleButton
			// 
			this.ZoomOutFillStyleButton.Location = new System.Drawing.Point(8, 184);
			this.ZoomOutFillStyleButton.Name = "ZoomOutFillStyleButton";
			this.ZoomOutFillStyleButton.Size = new System.Drawing.Size(160, 23);
			this.ZoomOutFillStyleButton.TabIndex = 7;
			this.ZoomOutFillStyleButton.Text = "Zoom Out Fill Style...";
			this.ZoomOutFillStyleButton.Click += new System.EventHandler(this.ZoomOutFillStyleButton_Click);
			// 
			// ZoomOutResetsAxesCheckBox
			// 
			this.ZoomOutResetsAxesCheckBox.ButtonProperties.BorderOffset = 2;
			this.ZoomOutResetsAxesCheckBox.Location = new System.Drawing.Point(8, 216);
			this.ZoomOutResetsAxesCheckBox.Name = "ZoomOutResetsAxesCheckBox";
			this.ZoomOutResetsAxesCheckBox.Size = new System.Drawing.Size(152, 24);
			this.ZoomOutResetsAxesCheckBox.TabIndex = 8;
			this.ZoomOutResetsAxesCheckBox.Text = "Zoom out resets axes";
			this.ZoomOutResetsAxesCheckBox.CheckedChanged += new System.EventHandler(this.ZoomOutResetsAxesCheckBox_CheckedChanged);
			// 
			// HorizontalAxisSnapModeComboBox
			// 
			this.HorizontalAxisSnapModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.HorizontalAxisSnapModeComboBox.ListProperties.DataSource = null;
			this.HorizontalAxisSnapModeComboBox.ListProperties.DisplayMember = "";
			this.HorizontalAxisSnapModeComboBox.Location = new System.Drawing.Point(8, 472);
			this.HorizontalAxisSnapModeComboBox.Name = "HorizontalAxisSnapModeComboBox";
			this.HorizontalAxisSnapModeComboBox.Size = new System.Drawing.Size(160, 21);
			this.HorizontalAxisSnapModeComboBox.TabIndex = 17;
			this.HorizontalAxisSnapModeComboBox.SelectedIndexChanged += new System.EventHandler(this.HorizontalAxisSnapModeComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 448);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(152, 23);
			this.label2.TabIndex = 16;
			this.label2.Text = "Horizontal axis snap mode:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 496);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 23);
			this.label3.TabIndex = 18;
			this.label3.Text = "Vertical axis snap mode:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// VerticalAxisSnapModeComboBox
			// 
			this.VerticalAxisSnapModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.VerticalAxisSnapModeComboBox.ListProperties.DataSource = null;
			this.VerticalAxisSnapModeComboBox.ListProperties.DisplayMember = "";
			this.VerticalAxisSnapModeComboBox.Location = new System.Drawing.Point(8, 520);
			this.VerticalAxisSnapModeComboBox.Name = "VerticalAxisSnapModeComboBox";
			this.VerticalAxisSnapModeComboBox.Size = new System.Drawing.Size(160, 21);
			this.VerticalAxisSnapModeComboBox.TabIndex = 19;
			this.VerticalAxisSnapModeComboBox.SelectedIndexChanged += new System.EventHandler(this.VerticalAxisSnapModeComboBox_SelectedIndexChanged);
			// 
			// AlwaysZoomInCheckBox
			// 
			this.AlwaysZoomInCheckBox.ButtonProperties.BorderOffset = 2;
			this.AlwaysZoomInCheckBox.Location = new System.Drawing.Point(8, 240);
			this.AlwaysZoomInCheckBox.Name = "AlwaysZoomInCheckBox";
			this.AlwaysZoomInCheckBox.Size = new System.Drawing.Size(152, 24);
			this.AlwaysZoomInCheckBox.TabIndex = 9;
			this.AlwaysZoomInCheckBox.Text = "Always zoom in";
			this.AlwaysZoomInCheckBox.CheckedChanged += new System.EventHandler(this.AlwaysZoomInCheckBox_CheckedChanged);
			// 
			// PreserveAspectRatioCheckBox
			// 
			this.PreserveAspectRatioCheckBox.ButtonProperties.BorderOffset = 2;
			this.PreserveAspectRatioCheckBox.Location = new System.Drawing.Point(8, 264);
			this.PreserveAspectRatioCheckBox.Name = "PreserveAspectRatioCheckBox";
			this.PreserveAspectRatioCheckBox.Size = new System.Drawing.Size(152, 24);
			this.PreserveAspectRatioCheckBox.TabIndex = 10;
			this.PreserveAspectRatioCheckBox.Text = "Preserve aspect ratio";
			this.PreserveAspectRatioCheckBox.CheckedChanged += new System.EventHandler(this.PreserveAspectRatioCheckBox_CheckedChanged);
			// 
			// WheelZoomCheckBox
			// 
			this.WheelZoomCheckBox.ButtonProperties.BorderOffset = 2;
			this.WheelZoomCheckBox.Location = new System.Drawing.Point(8, 288);
			this.WheelZoomCheckBox.Name = "WheelZoomCheckBox";
			this.WheelZoomCheckBox.Size = new System.Drawing.Size(152, 24);
			this.WheelZoomCheckBox.TabIndex = 21;
			this.WheelZoomCheckBox.Text = "Wheel Zoom";
			this.WheelZoomCheckBox.CheckedChanged += new System.EventHandler(this.WheelZoomCheckBox_CheckedChanged);
			// 
			// NDataZoomToolUC
			// 
			this.Controls.Add(this.WheelZoomCheckBox);
			this.Controls.Add(this.PreserveAspectRatioCheckBox);
			this.Controls.Add(this.AlwaysZoomInCheckBox);
			this.Controls.Add(this.VerticalAxisSnapModeComboBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.HorizontalAxisSnapModeComboBox);
			this.Controls.Add(this.ZoomOutResetsAxesCheckBox);
			this.Controls.Add(this.ZoomOutFillStyleButton);
			this.Controls.Add(this.ZoomInFillStyleButton);
			this.Controls.Add(this.InteractivityToolComboBox);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.SelectionAxesComboBox);
			this.Controls.Add(this.SampleChartComboBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ResetAxesButton);
			this.Controls.Add(this.label4);
			this.Name = "NDataZoomToolUC";
			this.Size = new System.Drawing.Size(180, 664);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

            SampleChartComboBox.Items.Add("XY Scatter Chart");
			SampleChartComboBox.Items.Add("XYZ Scatter Chart");

			SelectionAxesComboBox.Items.Add("Primary X - Primary Y");
			SelectionAxesComboBox.Items.Add("Primary Z - Primary Y");

			InteractivityToolComboBox.Items.Add("Data Zoom");
			InteractivityToolComboBox.Items.Add("Trackball");
			InteractivityToolComboBox.Items.Add("Zoom");
			InteractivityToolComboBox.Items.Add("Offset");

			HorizontalAxisSnapModeComboBox.Items.Add("None");
			HorizontalAxisSnapModeComboBox.Items.Add("Ruler");
			HorizontalAxisSnapModeComboBox.Items.Add("Major ticks");
			HorizontalAxisSnapModeComboBox.Items.Add("Minor ticks");
			HorizontalAxisSnapModeComboBox.Items.Add("Ruler Min/Max");

			VerticalAxisSnapModeComboBox.Items.Add("None");
			VerticalAxisSnapModeComboBox.Items.Add("Ruler");
			VerticalAxisSnapModeComboBox.Items.Add("Major ticks");
			VerticalAxisSnapModeComboBox.Items.Add("Minor ticks");
			VerticalAxisSnapModeComboBox.Items.Add("Ruler Min/Max");

			HorizontalAxisSnapModeComboBox.SelectedIndex = 0;
			VerticalAxisSnapModeComboBox.SelectedIndex = 0;

			SampleChartComboBox.SelectedIndex = 0;
			SelectionAxesComboBox.SelectedIndex = 0;
			InteractivityToolComboBox.SelectedIndex = 0;
			ZoomOutResetsAxesCheckBox.Checked = false;
			WheelZoomCheckBox.Checked = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Data Zoom Tool");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// update form controls
			UpdateDataZoomTool();
		}

		private NAxisValueSnapper GetAxisValueSnapperFromIndex(int index)
		{
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
			}

			return null;
		}

		private void UpdateDataZoomTool()
		{
			NCartesianChart chart = (NCartesianChart)(nChartControl1.Charts[0]);

			chart.RangeSelections.Clear();

			NRangeSelection rangeSelection = new NRangeSelection();

            rangeSelection.MinHorizontalPageSize = 0;
            rangeSelection.MinVerticalPageSize = 0;
			rangeSelection.ZoomOutResetsAxis = ZoomOutResetsAxesCheckBox.Checked;

			if (SelectionAxesComboBox.SelectedIndex == 0)
			{
				rangeSelection.HorizontalAxisId = (int)StandardAxis.PrimaryX;
				rangeSelection.VerticalAxisId = (int)StandardAxis.PrimaryY;
			}
			else
			{
				rangeSelection.HorizontalAxisId = (int)StandardAxis.Depth;
				rangeSelection.VerticalAxisId = (int)StandardAxis.PrimaryY;
			}

			rangeSelection.PreserveAspectRatio = PreserveAspectRatioCheckBox.Checked;
			rangeSelection.HorizontalValueSnapper = GetAxisValueSnapperFromIndex(HorizontalAxisSnapModeComboBox.SelectedIndex);
			rangeSelection.VerticalValueSnapper = GetAxisValueSnapperFromIndex(VerticalAxisSnapModeComboBox.SelectedIndex);
            rangeSelection.ZoomOutResetsAxis = ZoomOutResetsAxesCheckBox.Checked;

			chart.RangeSelections.Add(rangeSelection);

			m_DataZoomTool.AlwaysZoomIn = AlwaysZoomInCheckBox.Checked;

			if (WheelZoomCheckBox.Checked)
			{
				m_DataZoomTool.WheelZoomAtMouse = true;
				m_DataZoomTool.BeginDragMouseCommand = new NMouseCommand(MouseAction.Wheel, MouseButton.None, 0);
			}
			else
			{
				m_DataZoomTool.BeginDragMouseCommand = new NMouseCommand(MouseAction.Down, MouseButton.Left, 1);
			}
		}

		private void AddSeries(NChart chart)
		{
			// add point series
			chart.Series.Clear();
			NPointSeries point1 = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point1.Name = "Point 1";
			point1.PointShape = PointShape.Bar;
			point1.Size = new NLength(5, NGraphicsUnit.Point);
			point1.FillStyle = new NColorFillStyle(Color.Red);
			point1.BorderStyle.Color = Color.Pink;
			point1.DataLabelStyle.Visible = false;
			point1.UseXValues = true;
			point1.UseZValues = true;
			point1.InflateMargins = true;

			NPointSeries point2 = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point2.Name = "Point 2";
			point2.PointShape = PointShape.Bar;
			point2.Size = new NLength(5, NGraphicsUnit.Point);
			point2.FillStyle = new NColorFillStyle(Color.CornflowerBlue);
			point2.BorderStyle.Color = Color.LightCyan;
			point2.DataLabelStyle.Visible = false;
			point2.UseXValues = true;
			point2.UseZValues = true;
			point2.InflateMargins = true;

			NPointSeries point3 = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point3.Name = "Point 3";
			point3.PointShape = PointShape.Bar;
			point3.Size = new NLength(5, NGraphicsUnit.Point);
			point3.FillStyle = new NColorFillStyle(Color.Green);
			point3.BorderStyle.Color = Color.Chartreuse;
			point3.DataLabelStyle.Visible = false;
			point3.UseXValues = true;
			point3.UseZValues = true;
			point3.InflateMargins = true;

			// fill with random data
			point1.Values.FillRandomRange(Random, 10, 0, 50);
			point1.XValues.FillRandomRange(Random, 10, 0, 50);
			point1.ZValues.FillRandomRange(Random, 10, 0, 50);

			point2.Values.FillRandomRange(Random, 10, 25, 75);
			point2.XValues.FillRandomRange(Random, 10, 25, 75);
			point2.ZValues.FillRandomRange(Random, 10, 25, 75);

			point3.Values.FillRandomRange(Random, 10, 75, 125);
			point3.XValues.FillRandomRange(Random, 10, 75, 125);
			point3.ZValues.FillRandomRange(Random, 10, 75, 125);
		}

		private NLinearScaleConfigurator GetScaleConfigurator()
		{
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();

			linearScale.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific);
			linearScale.MinorTickCount = 4;

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			return linearScale;
		}

		private void ConfigureXYScatterChart()
		{
			// 2D line chart
			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.Depth).Visible = false;

            chart.Enable3D = false;
			chart.BoundsMode = BoundsMode.Stretch;

			chart.Location = new NPointL(
				new NLength(10, NRelativeUnit.ParentPercentage),
				new NLength(12, NRelativeUnit.ParentPercentage));

			chart.Size = new NSizeL(
				new NLength(80, NRelativeUnit.ParentPercentage),
				new NLength(78, NRelativeUnit.ParentPercentage));

			chart.Series.Clear();

            // configure axis pagin and set a mimimum range length on the axis
            // this will prevent the user from zooming too much
			chart.Axis(StandardAxis.PrimaryX).PagingView = new NNumericAxisPagingView();
            chart.Axis(StandardAxis.PrimaryX).PagingView.MinPageLength = 0.00001;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = GetScaleConfigurator();

			chart.Axis(StandardAxis.PrimaryY).PagingView = new NNumericAxisPagingView();
            chart.Axis(StandardAxis.PrimaryY).PagingView.MinPageLength = 0.00001f;
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = GetScaleConfigurator();

			AddSeries(chart);
		}

		private void ConfigureXYZScatterChart()
		{
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.BoundsMode = BoundsMode.Fit;

			chart.Location = new NPointL(new NLength(8, NRelativeUnit.ParentPercentage), new NLength(8, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(new NLength(84, NRelativeUnit.ParentPercentage), new NLength(84, NRelativeUnit.ParentPercentage));

			// set chart proportions
			chart.Depth = 55.0f;
			chart.Width = 55.0f;
			chart.Height = 55.0f;

			// configure the primary X axis
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = GetScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).PagingView = new NNumericAxisPagingView();

            // configure the primary Y axis
			chart.Axis(StandardAxis.PrimaryY).PagingView = new NNumericAxisPagingView();
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = GetScaleConfigurator();

			// configure the depth axis
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = GetScaleConfigurator();
			chart.Axis(StandardAxis.Depth).PagingView = new NNumericAxisPagingView();

			AddSeries(chart);
		}

		private void ResetAxesButton_Click(object sender, System.EventArgs e)
		{
			NChart chart = (NChart)(nChartControl1.Charts[0]);

			chart.Axis(StandardAxis.PrimaryX).PagingView.Enabled = false;
			chart.Axis(StandardAxis.PrimaryY).PagingView.Enabled = false;
			chart.Axis(StandardAxis.Depth).PagingView.Enabled = false;

			nChartControl1.Refresh();
		}

		private void SampleChartComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (SampleChartComboBox.SelectedIndex == 0)
			{
				ConfigureXYScatterChart();
				SelectionAxesComboBox.SelectedIndex = 0;
				SelectionAxesComboBox.Enabled = false;
			}
			else
			{
				ConfigureXYZScatterChart();
				SelectionAxesComboBox.Enabled = true;
			}

			ResetAxesButton_Click(null, null);
		}

		private void SelectionAxesComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateDataZoomTool();
		}

		private void InteractivityToolComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			nChartControl1.Controller.Tools.Clear();

			switch (InteractivityToolComboBox.SelectedIndex)
			{
				case 0:
					NPanelSelectorTool selector = new NPanelSelectorTool();
					selector.Focus = true;

					nChartControl1.Controller.Tools.Add(selector);
					nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
					nChartControl1.Controller.Tools.Add(m_DataZoomTool);
					break;
				case 1:
					nChartControl1.Controller.Tools.Add(new NTrackballTool());
					break;
				case 2:
					nChartControl1.Controller.Tools.Add(new NZoomTool());
					break;
				case 3:
					nChartControl1.Controller.Tools.Add(new NOffsetTool());
					break;
			}
		}

		private void ZoomInFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_DataZoomTool.ZoomInFillStyle, out fillStyleResult))
			{
				m_DataZoomTool.ZoomInFillStyle = fillStyleResult;
			}
		}

		private void ZoomOutFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_DataZoomTool.ZoomOutFillStyle, out fillStyleResult))
			{
				m_DataZoomTool.ZoomOutFillStyle = fillStyleResult;
			}
		}

		private void ZoomOutResetsAxesCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateDataZoomTool();
		}

		private void ClampValuesToRulerCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateDataZoomTool();
		}

		private void HorizontalAxisSnapModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateDataZoomTool();
		}

		private void VerticalAxisSnapModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateDataZoomTool();
		}

		private void PreserveAspectRatioCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateDataZoomTool();

			HorizontalAxisSnapModeComboBox.Enabled = !PreserveAspectRatioCheckBox.Checked;
			VerticalAxisSnapModeComboBox.Enabled = !PreserveAspectRatioCheckBox.Checked;
		}

		private void AlwaysZoomInCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateDataZoomTool();
		}
		
		private void WheelZoomCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateDataZoomTool();
		}
	}
}
