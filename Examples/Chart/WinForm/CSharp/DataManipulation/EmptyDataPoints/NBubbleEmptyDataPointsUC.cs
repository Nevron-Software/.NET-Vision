using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NBubbleEmptyDataPointsUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBubbleSeries m_Bubble;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowLabelsCheck;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox4;
		private Nevron.UI.WinForm.Controls.NComboBox AppearanceModeCombo;
		private Nevron.UI.WinForm.Controls.NButton BorderButton;
		private Nevron.UI.WinForm.Controls.NButton FillButton;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NComboBox MarkerModeCombo;
		private Nevron.UI.WinForm.Controls.NButton EDPMarkerButton;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NButton SeriesDataLabelButton;
		private Nevron.UI.WinForm.Controls.NButton ShadowStyleButton;
		private Nevron.UI.WinForm.Controls.NButton SeriesFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton SeriesStrokeStyleButton;
		private Nevron.UI.WinForm.Controls.NButton SeriesMarkerStyleButton;
		private Nevron.UI.WinForm.Controls.NButton NewDataButton;
		private System.ComponentModel.IContainer components = null;

		public NBubbleEmptyDataPointsUC()
		{
			InitializeComponent();

			AppearanceModeCombo.FillFromEnum(typeof(EmptyDataPointsAppearanceMode));
			MarkerModeCombo.FillFromEnum(typeof(EmptyDataPointsMarkerMode));
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NBubbleEmptyDataPointsUC));
			this.ShowLabelsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.groupBox4 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.AppearanceModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.BorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.FillButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.MarkerModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.EDPMarkerButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.SeriesDataLabelButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ShadowStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SeriesFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SeriesStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SeriesMarkerStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.NewDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.groupBox4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// ShowLabelsCheck
			// 
			this.ShowLabelsCheck.Location = new System.Drawing.Point(16, 238);
			this.ShowLabelsCheck.Name = "ShowLabelsCheck";
			this.ShowLabelsCheck.Size = new System.Drawing.Size(200, 21);
			this.ShowLabelsCheck.TabIndex = 20;
			this.ShowLabelsCheck.Text = "Show labels for empty data points";
			this.ShowLabelsCheck.CheckedChanged += new System.EventHandler(this.ShowLabelsCheck_CheckedChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.AppearanceModeCombo);
			this.groupBox4.Controls.Add(this.BorderButton);
			this.groupBox4.Controls.Add(this.FillButton);
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.ImageIndex = 0;
			this.groupBox4.Location = new System.Drawing.Point(8, 8);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(216, 104);
			this.groupBox4.TabIndex = 17;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Empty Data Points Apperance";
			// 
			// AppearanceModeCombo
			// 
			this.AppearanceModeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.AppearanceModeCombo.Location = new System.Drawing.Point(8, 43);
			this.AppearanceModeCombo.Name = "AppearanceModeCombo";
			this.AppearanceModeCombo.Size = new System.Drawing.Size(200, 21);
			this.AppearanceModeCombo.TabIndex = 3;
			this.AppearanceModeCombo.SelectedIndexChanged += new System.EventHandler(this.AppearanceModeCombo_SelectedIndexChanged);
			// 
			// BorderButton
			// 
			this.BorderButton.Location = new System.Drawing.Point(112, 74);
			this.BorderButton.Name = "BorderButton";
			this.BorderButton.Size = new System.Drawing.Size(93, 23);
			this.BorderButton.TabIndex = 10;
			this.BorderButton.Text = "Stroke Style...";
			this.BorderButton.Click += new System.EventHandler(this.BorderButton_Click);
			// 
			// FillButton
			// 
			this.FillButton.Location = new System.Drawing.Point(8, 74);
			this.FillButton.Name = "FillButton";
			this.FillButton.Size = new System.Drawing.Size(93, 23);
			this.FillButton.TabIndex = 9;
			this.FillButton.Text = "Fill Style...";
			this.FillButton.Click += new System.EventHandler(this.FillButton_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(188, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "Appearance Mode: ";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.MarkerModeCombo);
			this.groupBox1.Controls.Add(this.EDPMarkerButton);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(8, 128);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(216, 104);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Empty Data Points Marker";
			// 
			// MarkerModeCombo
			// 
			this.MarkerModeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.MarkerModeCombo.Location = new System.Drawing.Point(8, 40);
			this.MarkerModeCombo.Name = "MarkerModeCombo";
			this.MarkerModeCombo.Size = new System.Drawing.Size(197, 21);
			this.MarkerModeCombo.TabIndex = 3;
			this.MarkerModeCombo.SelectedIndexChanged += new System.EventHandler(this.MarkerModeCombo_SelectedIndexChanged);
			// 
			// EDPMarkerButton
			// 
			this.EDPMarkerButton.Location = new System.Drawing.Point(8, 72);
			this.EDPMarkerButton.Name = "EDPMarkerButton";
			this.EDPMarkerButton.Size = new System.Drawing.Size(93, 23);
			this.EDPMarkerButton.TabIndex = 9;
			this.EDPMarkerButton.Text = "Marker...";
			this.EDPMarkerButton.Click += new System.EventHandler(this.EDPMarkerButton_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(197, 19);
			this.label4.TabIndex = 2;
			this.label4.Text = "Marker Mode:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.SeriesDataLabelButton);
			this.groupBox2.Controls.Add(this.ShadowStyleButton);
			this.groupBox2.Controls.Add(this.SeriesFillStyleButton);
			this.groupBox2.Controls.Add(this.SeriesStrokeStyleButton);
			this.groupBox2.Controls.Add(this.SeriesMarkerStyleButton);
			this.groupBox2.ImageIndex = 0;
			this.groupBox2.Location = new System.Drawing.Point(8, 264);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(216, 120);
			this.groupBox2.TabIndex = 19;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Series Styles";
			// 
			// SeriesDataLabelButton
			// 
			this.SeriesDataLabelButton.Location = new System.Drawing.Point(112, 56);
			this.SeriesDataLabelButton.Name = "SeriesDataLabelButton";
			this.SeriesDataLabelButton.Size = new System.Drawing.Size(93, 23);
			this.SeriesDataLabelButton.TabIndex = 22;
			this.SeriesDataLabelButton.Text = "Data Label...";
			this.SeriesDataLabelButton.Click += new System.EventHandler(this.SeriesDataLabelButton_Click);
			// 
			// ShadowStyleButton
			// 
			this.ShadowStyleButton.Location = new System.Drawing.Point(8, 88);
			this.ShadowStyleButton.Name = "ShadowStyleButton";
			this.ShadowStyleButton.Size = new System.Drawing.Size(93, 23);
			this.ShadowStyleButton.TabIndex = 21;
			this.ShadowStyleButton.Text = "Shadow Style...";
			this.ShadowStyleButton.Click += new System.EventHandler(this.ShadowStyleButton_Click);
			// 
			// SeriesFillStyleButton
			// 
			this.SeriesFillStyleButton.Location = new System.Drawing.Point(8, 24);
			this.SeriesFillStyleButton.Name = "SeriesFillStyleButton";
			this.SeriesFillStyleButton.Size = new System.Drawing.Size(93, 23);
			this.SeriesFillStyleButton.TabIndex = 18;
			this.SeriesFillStyleButton.Text = "Fill Style...";
			this.SeriesFillStyleButton.Click += new System.EventHandler(this.SeriesFillStyleButton_Click);
			// 
			// SeriesStrokeStyleButton
			// 
			this.SeriesStrokeStyleButton.Location = new System.Drawing.Point(112, 24);
			this.SeriesStrokeStyleButton.Name = "SeriesStrokeStyleButton";
			this.SeriesStrokeStyleButton.Size = new System.Drawing.Size(93, 23);
			this.SeriesStrokeStyleButton.TabIndex = 19;
			this.SeriesStrokeStyleButton.Text = "Stroke Style...";
			this.SeriesStrokeStyleButton.Click += new System.EventHandler(this.SeriesStrokeStyleButton_Click);
			// 
			// SeriesMarkerStyleButton
			// 
			this.SeriesMarkerStyleButton.Location = new System.Drawing.Point(8, 56);
			this.SeriesMarkerStyleButton.Name = "SeriesMarkerStyleButton";
			this.SeriesMarkerStyleButton.Size = new System.Drawing.Size(93, 23);
			this.SeriesMarkerStyleButton.TabIndex = 20;
			this.SeriesMarkerStyleButton.Text = "Marker...";
			this.SeriesMarkerStyleButton.Click += new System.EventHandler(this.SeriesMarkerStyleButton_Click);
			// 
			// NewDataButton
			// 
			this.NewDataButton.Location = new System.Drawing.Point(16, 400);
			this.NewDataButton.Name = "NewDataButton";
			this.NewDataButton.Size = new System.Drawing.Size(200, 32);
			this.NewDataButton.TabIndex = 21;
			this.NewDataButton.Text = "New Data...";
			this.NewDataButton.Click += new System.EventHandler(this.NewDataButton_Click);
			// 
			// NBubbleEmptyDataPointsUC
			// 
			this.Controls.Add(this.NewDataButton);
			this.Controls.Add(this.ShowLabelsCheck);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Name = "NBubbleEmptyDataPointsUC";
			this.Size = new System.Drawing.Size(232, 440);
			this.groupBox4.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Bubble with Empty Data Points");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();

			m_Bubble = (NBubbleSeries)m_Chart.Series.Add(SeriesType.Bubble);
			m_Bubble.InflateMargins = true;
			m_Bubble.DataLabelStyle.Visible = false;
			m_Bubble.BubbleShape = PointShape.Sphere;
			m_Bubble.Legend.Format = "Size:<size>";
			m_Bubble.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Bubble.UseXValues = true;
			m_Bubble.UseZValues = false;

			m_Bubble.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			m_Bubble.Values.EmptyDataPoints.ValueMode = EmptyDataPointsValueMode.Average;

			m_Bubble.XValues.ValueFormatter = new NNumericValueFormatter("0.00");
			m_Bubble.XValues.EmptyDataPoints.ValueMode = EmptyDataPointsValueMode.Average;

			m_Bubble.Sizes.ValueFormatter = new NNumericValueFormatter("0.00");
			m_Bubble.Sizes.EmptyDataPoints.ValueMode = EmptyDataPointsValueMode.Average;

			GenerateData();

			AppearanceModeCombo.SelectedIndex = 0;
			MarkerModeCombo.SelectedIndex = 0;
			ShowLabelsCheck.Checked = false;
		}

		private void GenerateData()
		{
			m_Bubble.Values.Clear();
			m_Bubble.XValues.Clear();
			m_Bubble.Sizes.Clear();

			for(int i = 0; i < 8; i++)
			{
				if((i == 2) || (i == 5))
				{
					m_Bubble.Values.Add(DBNull.Value);
					m_Bubble.XValues.Add(DBNull.Value);
					m_Bubble.Sizes.Add(DBNull.Value);
				}
				else
				{
					m_Bubble.Values.Add(Random.NextDouble() * 5);
					m_Bubble.XValues.Add(Random.NextDouble() * 5);
					m_Bubble.Sizes.Add(Random.NextDouble());
				}
			}
		}

		private void AppearanceModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			series.EmptyDataPointsAppearance.AppearanceMode = (EmptyDataPointsAppearanceMode)AppearanceModeCombo.SelectedIndex;

			nChartControl1.Refresh();
		}

		private void MarkerModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			series.EmptyDataPointsAppearance.MarkerMode = (EmptyDataPointsMarkerMode)MarkerModeCombo.SelectedIndex;

			nChartControl1.Refresh();
		}

		private void FillButton_Click(object sender, System.EventArgs e)
		{
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];
			NFillStyle fillStyleResult;

			if(NFillStyleTypeEditor.Edit(series.EmptyDataPointsAppearance.FillStyle, out fillStyleResult))
			{
				series.EmptyDataPointsAppearance.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void BorderButton_Click(object sender, System.EventArgs e)
		{
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];
			NStrokeStyle strokeStyleResult;

			if(NStrokeStyleTypeEditor.Edit(series.EmptyDataPointsAppearance.BorderStyle, out strokeStyleResult))
			{
				series.EmptyDataPointsAppearance.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void ShowLabelsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if (ShowLabelsCheck.Checked)
			{
				series.EmptyDataPointsAppearance.DataLabelMode = EmptyDataPointsLabelMode.Normal;
			}
			else
			{
				series.EmptyDataPointsAppearance.DataLabelMode = EmptyDataPointsLabelMode.Special;
				series.EmptyDataPointsAppearance.DataLabelStyle.Visible = false;
			}

			nChartControl1.Refresh();
		}

		private void EDPMarkerButton_Click(object sender, System.EventArgs e)
		{
			NMarkerStyle markerStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if(NMarkerStyleTypeEditor.Edit(series.EmptyDataPointsAppearance.MarkerStyle, out markerStyleResult))
			{
				series.EmptyDataPointsAppearance.MarkerStyle = markerStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void SeriesFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];
			NFillStyle fillStyleResult;

			if(NFillStyleTypeEditor.Edit(series.FillStyle, out fillStyleResult))
			{
				series.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}		
		}

		private void SeriesStrokeStyleButton_Click(object sender, System.EventArgs e)
		{
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];
			NStrokeStyle strokeStyleResult;

			if(NStrokeStyleTypeEditor.Edit(series.BorderStyle, out strokeStyleResult))
			{
				series.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}		
		}

		private void SeriesMarkerStyleButton_Click(object sender, System.EventArgs e)
		{
			NMarkerStyle markerStyleResult;
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			if(NMarkerStyleTypeEditor.Edit(series.MarkerStyle, out markerStyleResult))
			{
				series.MarkerStyle = markerStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void SeriesDataLabelButton_Click(object sender, System.EventArgs e)
		{
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];
			NDataLabelStyle dataLabelStyleResult;

			if(NDataLabelStyleTypeEditor.Edit(series.DataLabelStyle, out dataLabelStyleResult))
			{
				series.DataLabelStyle = dataLabelStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void ShadowStyleButton_Click(object sender, System.EventArgs e)
		{
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];
			NShadowStyle shadowStyleResult;

			if(NShadowStyleTypeEditor.Edit(series.ShadowStyle, out shadowStyleResult))
			{
				series.ShadowStyle = shadowStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void NewDataButton_Click(object sender, System.EventArgs e)
		{
			GenerateData();
			nChartControl1.Refresh();
		}
	}
}

