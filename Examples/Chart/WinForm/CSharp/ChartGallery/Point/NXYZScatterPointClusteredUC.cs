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

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NXYZScatterPointClusteredUC : NExampleBaseUC
	{
		NPointSeries m_Point;
		private Nevron.UI.WinForm.Controls.NTextBox DataPointCountTextBox;
		private Label label6;
		private Nevron.UI.WinForm.Controls.NButton ClearDataButton;
		private Nevron.UI.WinForm.Controls.NButton Add40KDataButton;
		private Nevron.UI.WinForm.Controls.NButton Add20KDataButton;
		bool m_Updating;
		public NXYZScatterPointClusteredUC()
		{
			InitializeComponent();
		}
		private Nevron.UI.WinForm.Controls.NNumericUpDown DistanceNumericUpDown;
		private Label label4;
		private Nevron.UI.WinForm.Controls.NComboBox ClusterModeComboBox;
		private Label label1;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.DistanceNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.ClusterModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.DataPointCountTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.ClearDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.Add40KDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.Add20KDataButton = new Nevron.UI.WinForm.Controls.NButton();
			((System.ComponentModel.ISupportInitialize)(this.DistanceNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// DistanceNumericUpDown
			// 
			this.DistanceNumericUpDown.DecimalPlaces = 5;
			this.DistanceNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.DistanceNumericUpDown.Location = new System.Drawing.Point(4, 74);
			this.DistanceNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.DistanceNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            327680});
			this.DistanceNumericUpDown.Name = "DistanceNumericUpDown";
			this.DistanceNumericUpDown.Size = new System.Drawing.Size(171, 20);
			this.DistanceNumericUpDown.TabIndex = 20;
			this.DistanceNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.DistanceNumericUpDown.ValueChanged += new System.EventHandler(this.DistanceNumericUpDown_ValueChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(4, 58);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(147, 20);
			this.label4.TabIndex = 19;
			this.label4.Text = "Distance Factor:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ClusterModeComboBox
			// 
			this.ClusterModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.ClusterModeComboBox.ListProperties.DataSource = null;
			this.ClusterModeComboBox.ListProperties.DisplayMember = "";
			this.ClusterModeComboBox.Location = new System.Drawing.Point(4, 27);
			this.ClusterModeComboBox.Name = "ClusterModeComboBox";
			this.ClusterModeComboBox.Size = new System.Drawing.Size(171, 21);
			this.ClusterModeComboBox.TabIndex = 16;
			this.ClusterModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ClusterModeComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(171, 21);
			this.label1.TabIndex = 15;
			this.label1.Text = "Cluster Mode:";
			// 
			// DataPointCountTextBox
			// 
			this.DataPointCountTextBox.Location = new System.Drawing.Point(4, 200);
			this.DataPointCountTextBox.Name = "DataPointCountTextBox";
			this.DataPointCountTextBox.ReadOnly = true;
			this.DataPointCountTextBox.Size = new System.Drawing.Size(171, 18);
			this.DataPointCountTextBox.TabIndex = 28;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(4, 176);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(171, 21);
			this.label6.TabIndex = 27;
			this.label6.Text = "Data Point Count:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// ClearDataButton
			// 
			this.ClearDataButton.Location = new System.Drawing.Point(4, 274);
			this.ClearDataButton.Name = "ClearDataButton";
			this.ClearDataButton.Size = new System.Drawing.Size(171, 23);
			this.ClearDataButton.TabIndex = 29;
			this.ClearDataButton.Text = "Clear Data";
			this.ClearDataButton.Click += new System.EventHandler(this.ClearDataButton_Click);
			// 
			// Add40KDataButton
			// 
			this.Add40KDataButton.Location = new System.Drawing.Point(4, 150);
			this.Add40KDataButton.Name = "Add40KDataButton";
			this.Add40KDataButton.Size = new System.Drawing.Size(171, 23);
			this.Add40KDataButton.TabIndex = 26;
			this.Add40KDataButton.Text = "Add 40,000 Data Points";
			this.Add40KDataButton.Click += new System.EventHandler(this.Add40KDataButton_Click);
			// 
			// Add20KDataButton
			// 
			this.Add20KDataButton.Location = new System.Drawing.Point(4, 121);
			this.Add20KDataButton.Name = "Add20KDataButton";
			this.Add20KDataButton.Size = new System.Drawing.Size(171, 23);
			this.Add20KDataButton.TabIndex = 25;
			this.Add20KDataButton.Text = "Add 20,000 Data Points";
			this.Add20KDataButton.Click += new System.EventHandler(this.Add20KDataButton_Click);
			// 
			// NXYZScatterPointClusteredUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.DataPointCountTextBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.ClearDataButton);
			this.Controls.Add(this.Add40KDataButton);
			this.Controls.Add(this.Add20KDataButton);
			this.Controls.Add(this.DistanceNumericUpDown);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ClusterModeComboBox);
			this.Controls.Add(this.label1);
			this.Name = "NXYZScatterPointClusteredUC";
			this.Size = new System.Drawing.Size(180, 450);
			((System.ComponentModel.ISupportInitialize)(this.DistanceNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XYZ Scatter Point Clustered Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// setup the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 50;
			chart.Height = 50;
			chart.Depth = 50;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);

			// add interlace stripe to left and back walls
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
			// add scale strip
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Left, ChartWallType.Back };
			scaleY.StripStyles.Add(stripStyle);

			// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back, ChartWallType.Floor };

			// setup Z axis
			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ;
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Floor, ChartWallType.Left };

			m_Point = new NPointSeries();
			chart.Series.Add(m_Point);
			m_Point.DataLabelStyle.Visible = false;
			m_Point.BorderStyle.Width = new NLength(0);
			m_Point.PointShape = PointShape.Bar;
			m_Point.SphereDetail = LevelOfDetail.Low;
			m_Point.Size = new NLength(1);
			m_Point.UseXValues = true;
			m_Point.UseZValues = true;
			m_Point.FillStyle = new NColorFillStyle(DarkOrange);
			m_Point.ClusterMode = ClusterMode.Enabled;

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// Update controls 
			m_Updating = true;

			ClusterModeComboBox.FillFromEnum(typeof(ClusterMode));
			ClusterModeComboBox.SelectedIndex = (int)ClusterMode.Enabled;

			DistanceNumericUpDown.Value = (decimal)0.0001;

			m_Updating = false;

			Add20KDataButton_Click(null, null);
		}

		private void UpdateCounter()
		{
			int count = m_Point.Values.Count;
			DataPointCountTextBox.Text = (count / 1000).ToString() + "K";

			if (count > 1000000)
			{
				Add20KDataButton.Enabled = false;
				Add40KDataButton.Enabled = false;
			}
			else
			{
				Add20KDataButton.Enabled = true;
				Add40KDataButton.Enabled = true;
			}
		}

		private void UpdateCluster()
		{
			if (m_Updating)
				return;

			m_Updating = true;

            if (m_Point != null)
            {
                m_Point.ClusterMode = (ClusterMode)ClusterModeComboBox.SelectedIndex;
                m_Point.ClusterDistanceFactor = (double)DistanceNumericUpDown.Value;
            }

            if (nChartControl1 != null)
            {
                nChartControl1.Refresh();
            }

			m_Updating = false;
		}

		private void AddNewData(int count)
		{
			NPointSeries pointSeries = m_Point;
			Random rand = new Random();

			double[] xValues = new double[count];
			double[] yValues = new double[count];
			double[] zValues = new double[count];

			double centerX = rand.Next(20);
			double centerY = rand.Next(20);
			double centerZ = rand.Next(20);

			for (int i = 0; i < count; i++)
			{
				double u1 = rand.NextDouble();
				double u2 = rand.NextDouble();
				double u3 = rand.NextDouble();

				if (u1 == 0)
					u1 += 0.0001;

				if (u2 == 0)
					u2 += 0.0001;

				if (u3 == 0)
					u3 += 0.0001;

				double z0 = centerX + Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2);
				double z1 = centerY + Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2);
				double z2 = centerZ + Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u3);

				xValues[i] = z0;
				yValues[i]= z1;
				zValues[i] = z2;	
			}

			pointSeries.XValues.AddRange(xValues);
			pointSeries.Values.AddRange(yValues);
			pointSeries.ZValues.AddRange(zValues);

			UpdateCounter();

			nChartControl1.Refresh();
		}

		private void ClusterModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateCluster();
		}

		private void DistanceNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateCluster();
		}

		private void Add20KDataButton_Click(object sender, EventArgs e)
		{
			AddNewData(20000);
		}

		private void Add40KDataButton_Click(object sender, EventArgs e)
		{
			AddNewData(40000);
		}

		private void ClearDataButton_Click(object sender, EventArgs e)
		{
			m_Point.Values.Clear();
			m_Point.XValues.Clear();
			m_Point.ZValues.Clear();

			nChartControl1.Refresh();
		}
	}
}
