using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
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
	public class ViewportToScaleUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NPointSeries m_Point;
		private Nevron.UI.WinForm.Controls.NNumericUpDown XZPlaneValueNumericUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown XYPlaneValueNumericUpDown;
		private Nevron.UI.WinForm.Controls.NButton ResetPointsButton;
		private Nevron.UI.WinForm.Controls.NComboBox CreatePointAtPlaneComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox MouseModeComboBox;
		private Nevron.UI.WinForm.Controls.NCheckBox ClampValuesToRulerCheckBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.ComponentModel.Container components = null;

		public ViewportToScaleUC()
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
			this.CreatePointAtPlaneComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.XZPlaneValueNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.XYPlaneValueNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.ResetPointsButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label4 = new System.Windows.Forms.Label();
			this.MouseModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.ClampValuesToRulerCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.XZPlaneValueNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.XYPlaneValueNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// CreatePointAtPlaneComboBox
			// 
			this.CreatePointAtPlaneComboBox.ListProperties.CheckBoxDataMember = "";
			this.CreatePointAtPlaneComboBox.ListProperties.DataSource = null;
			this.CreatePointAtPlaneComboBox.ListProperties.DisplayMember = "";
			this.CreatePointAtPlaneComboBox.Location = new System.Drawing.Point(5, 79);
			this.CreatePointAtPlaneComboBox.Name = "CreatePointAtPlaneComboBox";
			this.CreatePointAtPlaneComboBox.Size = new System.Drawing.Size(171, 21);
			this.CreatePointAtPlaneComboBox.TabIndex = 0;
			this.CreatePointAtPlaneComboBox.SelectedIndexChanged += new System.EventHandler(this.CreatePointAtPlaneComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 57);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(171, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Create point at plane:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 106);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(171, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "XZ plane value:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(5, 154);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(171, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "XY plane value:";
			// 
			// XZPlaneValueNumericUpDown
			// 
			this.XZPlaneValueNumericUpDown.Location = new System.Drawing.Point(5, 128);
			this.XZPlaneValueNumericUpDown.Name = "XZPlaneValueNumericUpDown";
			this.XZPlaneValueNumericUpDown.Size = new System.Drawing.Size(171, 20);
			this.XZPlaneValueNumericUpDown.TabIndex = 4;
			this.XZPlaneValueNumericUpDown.ValueChanged += new System.EventHandler(this.XZPlaneValueNumericUpDown_ValueChanged);
			// 
			// XYPlaneValueNumericUpDown
			// 
			this.XYPlaneValueNumericUpDown.Location = new System.Drawing.Point(5, 176);
			this.XYPlaneValueNumericUpDown.Name = "XYPlaneValueNumericUpDown";
			this.XYPlaneValueNumericUpDown.Size = new System.Drawing.Size(171, 20);
			this.XYPlaneValueNumericUpDown.TabIndex = 5;
			this.XYPlaneValueNumericUpDown.ValueChanged += new System.EventHandler(this.XYPlaneValueNumericUpDown_ValueChanged);
			// 
			// ResetPointsButton
			// 
			this.ResetPointsButton.Location = new System.Drawing.Point(5, 232);
			this.ResetPointsButton.Name = "ResetPointsButton";
			this.ResetPointsButton.Size = new System.Drawing.Size(171, 23);
			this.ResetPointsButton.TabIndex = 6;
			this.ResetPointsButton.Text = "Reset points";
			this.ResetPointsButton.Click += new System.EventHandler(this.ResetPointsButton_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(5, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(171, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Mouse mode:";
			// 
			// MouseModeComboBox
			// 
			this.MouseModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.MouseModeComboBox.ListProperties.DataSource = null;
			this.MouseModeComboBox.ListProperties.DisplayMember = "";
			this.MouseModeComboBox.Location = new System.Drawing.Point(5, 30);
			this.MouseModeComboBox.Name = "MouseModeComboBox";
			this.MouseModeComboBox.Size = new System.Drawing.Size(171, 21);
			this.MouseModeComboBox.TabIndex = 8;
			this.MouseModeComboBox.SelectedIndexChanged += new System.EventHandler(this.MouseModeComboBox_SelectedIndexChanged);
			// 
			// ClampValuesToRulerCheckBox
			// 
			this.ClampValuesToRulerCheckBox.ButtonProperties.BorderOffset = 2;
			this.ClampValuesToRulerCheckBox.Checked = true;
			this.ClampValuesToRulerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ClampValuesToRulerCheckBox.Location = new System.Drawing.Point(5, 202);
			this.ClampValuesToRulerCheckBox.Name = "ClampValuesToRulerCheckBox";
			this.ClampValuesToRulerCheckBox.Size = new System.Drawing.Size(171, 24);
			this.ClampValuesToRulerCheckBox.TabIndex = 9;
			this.ClampValuesToRulerCheckBox.Text = "Clamp values to ruler";
			// 
			// ViewportToScaleUC
			// 
			this.Controls.Add(this.ClampValuesToRulerCheckBox);
			this.Controls.Add(this.MouseModeComboBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ResetPointsButton);
			this.Controls.Add(this.XYPlaneValueNumericUpDown);
			this.Controls.Add(this.XZPlaneValueNumericUpDown);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.CreatePointAtPlaneComboBox);
			this.Name = "ViewportToScaleUC";
			this.Size = new System.Drawing.Size(180, 494);
			((System.ComponentModel.ISupportInitialize)(this.XZPlaneValueNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.XYPlaneValueNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Converting from viewport to scale coordinates");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// configure a free xyz point chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.BoundsMode = BoundsMode.Fit;
			m_Chart.Location = new NPointL(new NLength(8, NRelativeUnit.ParentPercentage), new NLength(8, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(84, NRelativeUnit.ParentPercentage), new NLength(84, NRelativeUnit.ParentPercentage));

			m_Chart.Depth = 55.0f;
			m_Chart.Width = 55.0f;
			m_Chart.Height = 55.0f;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// configure x axis to scale in numeric linear mode
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// configure y axis to scale in numeric linear mode
			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale; 
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// configure depth axis to scale in numeric linear mode
			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale; 
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			nChartControl1.Controller.Selection.Clear();
			nChartControl1.Controller.Selection.Add(m_Chart);

			m_Point = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);
			m_Point.Name = "Point Series";
			m_Point.DataLabelStyle.Visible = false;
			m_Point.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Point.Legend.Format = "<label>";
			m_Point.PointShape = PointShape.Sphere;
			m_Point.FillStyle = new NColorFillStyle(Color.Red);
			m_Point.UseXValues = true;
			m_Point.UseZValues = true;

			// limit the axes to show the range [0, 100]
			m_Chart.Axis(StandardAxis.PrimaryX).View = new NRangeAxisView(new NRange1DD(0, 100));
			m_Chart.Axis(StandardAxis.PrimaryY).View = new NRangeAxisView(new NRange1DD(0, 100));
			m_Chart.Axis(StandardAxis.Depth).View = new NRangeAxisView(new NRange1DD(0, 100));

			// create the point creation planes
			NAxisConstLine xzPlane = new NAxisConstLine();
			xzPlane.Mode = ConstLineMode.Plane;
			xzPlane.FillStyle = new NColorFillStyle(Color.FromArgb(125, 255, 0, 0));
			xzPlane.Value = 0;
			m_Chart.Axis(StandardAxis.PrimaryY).ConstLines.Add(xzPlane);

			NAxisConstLine xyPlane = new NAxisConstLine();
			xyPlane.Mode = ConstLineMode.Plane;
			xyPlane.FillStyle = new NColorFillStyle(Color.FromArgb(125, 0, 0, 255));
			xyPlane.Value = 0;
			m_Chart.Axis(StandardAxis.Depth).ConstLines.Add(xyPlane);

			// init form controls
			CreatePointAtPlaneComboBox.Items.Add("XZ plane");
			CreatePointAtPlaneComboBox.Items.Add("XY plane");
			CreatePointAtPlaneComboBox.SelectedIndex = 0;

			MouseModeComboBox.Items.Add("Create Point");
			MouseModeComboBox.Items.Add("Trackball");
			MouseModeComboBox.Items.Add("Zoom");
			MouseModeComboBox.Items.Add("Offset");
			MouseModeComboBox.SelectedIndex = 0;

			XYPlaneValueNumericUpDown.Value = (decimal)50;
			XZPlaneValueNumericUpDown.Value = (decimal)50;

			// register for the mouse down event
			nChartControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(OnChartMouseDown);
		}

		private void XYPlaneValueNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			NAxisConstLine xyPlane = (NAxisConstLine)(m_Chart.Axis(StandardAxis.Depth).ConstLines[0]);
			xyPlane.Value = (double)(XYPlaneValueNumericUpDown.Value);		

			nChartControl1.Refresh();
		}

		private void XZPlaneValueNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			NAxisConstLine xzPlane = (NAxisConstLine)(m_Chart.Axis(StandardAxis.PrimaryY).ConstLines[0]);
			xzPlane.Value = (double)(XZPlaneValueNumericUpDown.Value);		

			nChartControl1.Refresh();
		}

		private void CreatePointAtPlaneComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NAxisConstLine xyPlane = (NAxisConstLine)(m_Chart.Axis(StandardAxis.Depth).ConstLines[0]);
			NAxisConstLine xzPlane = (NAxisConstLine)(m_Chart.Axis(StandardAxis.PrimaryY).ConstLines[0]);

			if (CreatePointAtPlaneComboBox.SelectedIndex == 0)
			{
				xzPlane.FillStyle = new NColorFillStyle(Color.FromArgb(125, 255, 0, 0));
				xyPlane.FillStyle = new NColorFillStyle(Color.FromArgb(125, 0, 0, 255));

				XZPlaneValueNumericUpDown.Enabled = true;
				XYPlaneValueNumericUpDown.Enabled = false;
			}
			else
			{
				xzPlane.FillStyle = new NColorFillStyle(Color.FromArgb(125, 0, 0, 255));
				xyPlane.FillStyle = new NColorFillStyle(Color.FromArgb(125, 255, 0, 0));

				XZPlaneValueNumericUpDown.Enabled = false;
				XYPlaneValueNumericUpDown.Enabled = true;
			}

			nChartControl1.Refresh();
		}

		private void ResetPointsButton_Click(object sender, System.EventArgs e)
		{
			m_Point.XValues.Clear();
			m_Point.ZValues.Clear();
			m_Point.Values.Clear();
			m_Point.Labels.Clear();

			nChartControl1.Refresh();
		}

		private void MouseModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NTool tool = null;
			bool bEnableCreatePointControls = false;

			switch (MouseModeComboBox.SelectedIndex)
			{
				// Create Point
				case 0:
					bEnableCreatePointControls = true;
					break;
				// Trackball
				case 1:
					tool = new NTrackballTool();
					break;
				// Zoom
				case 2:
					tool = new NZoomTool();
					break;
				// Offset
				case 3:
					tool = new NOffsetTool();
					break;
			}

			nChartControl1.Controller.Tools.Clear();

			if (tool != null)
			{
				nChartControl1.Controller.Tools.Add(tool);
			}

			CreatePointAtPlaneComboBox.Enabled = bEnableCreatePointControls;

			if (CreatePointAtPlaneComboBox.SelectedIndex == 0)
			{
				XZPlaneValueNumericUpDown.Enabled = bEnableCreatePointControls;
				XYPlaneValueNumericUpDown.Enabled = false;
			}
			else
			{
				XZPlaneValueNumericUpDown.Enabled = false;
				XYPlaneValueNumericUpDown.Enabled = bEnableCreatePointControls;
			}
		}
		private void OnChartMouseDown(object sender, MouseEventArgs e)
		{
			if (MouseModeComboBox.SelectedIndex != 0)
				return;

			NPointF ptViewPoint = new NPointF((float)e.X, (float)e.Y);
			NVector3DD vecScalePoint = new NVector3DD();
			NViewToScale3DTransformation viewToScale;

			NAxis xAxis = m_Chart.Axis(StandardAxis.PrimaryX);
			NAxis yAxis = m_Chart.Axis(StandardAxis.PrimaryY);
			NAxis zAxis = m_Chart.Axis(StandardAxis.Depth);

			if (CreatePointAtPlaneComboBox.SelectedIndex == 0)
			{
				viewToScale = new NViewToScale3DTransformation(m_Chart, (int)StandardAxis.PrimaryX, (int)StandardAxis.Depth, (int)StandardAxis.PrimaryY, (double)XZPlaneValueNumericUpDown.Value);

				if (viewToScale.Transform(ptViewPoint, ref vecScalePoint))
				{
					if (ClampValuesToRulerCheckBox.Checked)
					{
						vecScalePoint.X = xAxis.Scale.ViewRange.GetValueInRange(vecScalePoint.X);
						vecScalePoint.Z = yAxis.Scale.ViewRange.GetValueInRange(vecScalePoint.Z);
						vecScalePoint.Y = zAxis.Scale.ViewRange.GetValueInRange(vecScalePoint.Y);
					}

					m_Point.AddDataPoint(new NDataPoint(vecScalePoint.X, vecScalePoint.Z, vecScalePoint.Y, "Point" + m_Point.Values.Count.ToString()));
					nChartControl1.Refresh();
				}
			}
			else
			{
				viewToScale = new NViewToScale3DTransformation(m_Chart, (int)StandardAxis.PrimaryX, (int)StandardAxis.PrimaryY, (int)StandardAxis.Depth, (double)XYPlaneValueNumericUpDown.Value);

				if (viewToScale.Transform(ptViewPoint, ref vecScalePoint))
				{
					if (ClampValuesToRulerCheckBox.Checked)
					{
						vecScalePoint.X = xAxis.Scale.ViewRange.GetValueInRange(vecScalePoint.X);
						vecScalePoint.Y = yAxis.Scale.ViewRange.GetValueInRange(vecScalePoint.Y);
						vecScalePoint.Z = zAxis.Scale.ViewRange.GetValueInRange(vecScalePoint.Z);
					}

					m_Point.AddDataPoint(new NDataPoint(vecScalePoint.X, vecScalePoint.Y, vecScalePoint.Z, "Point" + m_Point.Values.Count.ToString()));
					nChartControl1.Refresh();
				}
			}
		}
	}
}
