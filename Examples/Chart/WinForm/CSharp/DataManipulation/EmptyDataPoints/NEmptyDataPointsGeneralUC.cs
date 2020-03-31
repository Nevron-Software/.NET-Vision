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
	public class NEmptyDataPointsGeneralUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox3;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox4;
		private Nevron.UI.WinForm.Controls.NTextBox CustomValue;
		private Nevron.UI.WinForm.Controls.NComboBox ValueModeCombo;
		private Nevron.UI.WinForm.Controls.NComboBox AppearanceModeCombo;
		private Nevron.UI.WinForm.Controls.NComboBox MarkerModeCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowLabelsCheck;
		private Nevron.UI.WinForm.Controls.NButton BorderButton;
		private Nevron.UI.WinForm.Controls.NButton FillButton;
		private Nevron.UI.WinForm.Controls.NButton SeriesStrokeStyleButton;
		private Nevron.UI.WinForm.Controls.NButton SeriesFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton SeriesMarkerStyleButton;
		private Nevron.UI.WinForm.Controls.NButton EDPMarkerButton;
		private Nevron.UI.WinForm.Controls.NButton ShadowStyleButton;
		private Nevron.UI.WinForm.Controls.NComboBox SeriesTypeCombo;
		private Nevron.UI.WinForm.Controls.NButton SeriesDataLabelButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.ComponentModel.IContainer components = null;

		public NEmptyDataPointsGeneralUC()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NEmptyDataPointsGeneralUC));
			this.groupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.CustomValue = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.ValueModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.groupBox4 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.AppearanceModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.BorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.FillButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.MarkerModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.EDPMarkerButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label4 = new System.Windows.Forms.Label();
			this.ShowLabelsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SeriesStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SeriesFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SeriesMarkerStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.SeriesDataLabelButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ShadowStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SeriesTypeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.CustomValue);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.ValueModeCombo);
			this.groupBox3.ImageIndex = 0;
			this.groupBox3.Location = new System.Drawing.Point(8, 48);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(216, 120);
			this.groupBox3.TabIndex = 13;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Empty Data Point Analisys";
			// 
			// CustomValue
			// 
			this.CustomValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.CustomValue.Enabled = false;
			this.CustomValue.Location = new System.Drawing.Point(8, 88);
			this.CustomValue.Name = "CustomValue";
			this.CustomValue.Size = new System.Drawing.Size(197, 20);
			this.CustomValue.TabIndex = 3;
			this.CustomValue.Text = "0";
			this.CustomValue.TextChanged += new System.EventHandler(this.CustomValue_TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Custom Value:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(166, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "Empty Data Points Value Mode:";
			// 
			// ValueModeCombo
			// 
			this.ValueModeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ValueModeCombo.Location = new System.Drawing.Point(8, 40);
			this.ValueModeCombo.Name = "ValueModeCombo";
			this.ValueModeCombo.Size = new System.Drawing.Size(197, 21);
			this.ValueModeCombo.TabIndex = 1;
			this.ValueModeCombo.SelectedIndexChanged += new System.EventHandler(this.ValueModeCombo_SelectedIndexChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.AppearanceModeCombo);
			this.groupBox4.Controls.Add(this.BorderButton);
			this.groupBox4.Controls.Add(this.FillButton);
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.ImageIndex = 0;
			this.groupBox4.Location = new System.Drawing.Point(8, 184);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(216, 104);
			this.groupBox4.TabIndex = 14;
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
			this.groupBox1.Location = new System.Drawing.Point(8, 304);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(216, 104);
			this.groupBox1.TabIndex = 15;
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
			// ShowLabelsCheck
			// 
			this.ShowLabelsCheck.Location = new System.Drawing.Point(16, 416);
			this.ShowLabelsCheck.Name = "ShowLabelsCheck";
			this.ShowLabelsCheck.Size = new System.Drawing.Size(200, 19);
			this.ShowLabelsCheck.TabIndex = 16;
			this.ShowLabelsCheck.Text = "Show labels for empty data points";
			this.ShowLabelsCheck.CheckedChanged += new System.EventHandler(this.ShowLabelsCheck_CheckedChanged);
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
			// SeriesFillStyleButton
			// 
			this.SeriesFillStyleButton.Location = new System.Drawing.Point(8, 24);
			this.SeriesFillStyleButton.Name = "SeriesFillStyleButton";
			this.SeriesFillStyleButton.Size = new System.Drawing.Size(93, 23);
			this.SeriesFillStyleButton.TabIndex = 18;
			this.SeriesFillStyleButton.Text = "Fill Style...";
			this.SeriesFillStyleButton.Click += new System.EventHandler(this.SeriesFillStyleButton_Click);
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
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.SeriesDataLabelButton);
			this.groupBox2.Controls.Add(this.ShadowStyleButton);
			this.groupBox2.Controls.Add(this.SeriesFillStyleButton);
			this.groupBox2.Controls.Add(this.SeriesStrokeStyleButton);
			this.groupBox2.Controls.Add(this.SeriesMarkerStyleButton);
			this.groupBox2.ImageIndex = 0;
			this.groupBox2.Location = new System.Drawing.Point(8, 440);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(216, 120);
			this.groupBox2.TabIndex = 16;
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
			// SeriesTypeCombo
			// 
			this.SeriesTypeCombo.Location = new System.Drawing.Point(16, 16);
			this.SeriesTypeCombo.Name = "SeriesTypeCombo";
			this.SeriesTypeCombo.Size = new System.Drawing.Size(200, 21);
			this.SeriesTypeCombo.TabIndex = 17;
			this.SeriesTypeCombo.SelectedIndexChanged += new System.EventHandler(this.SeriesTypeCombo_SelectedIndexChanged);
			// 
			// NEmptyDataPointsGeneralUC
			// 
			this.Controls.Add(this.SeriesTypeCombo);
			this.Controls.Add(this.ShowLabelsCheck);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Name = "NEmptyDataPointsGeneralUC";
			this.Size = new System.Drawing.Size(232, 568);
			this.groupBox3.ResumeLayout(false);
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
			NLabel title = nChartControl1.Labels.AddHeader("Empty Data Points");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
            

			SeriesTypeCombo.Items.Add("Bar");
			SeriesTypeCombo.Items.Add("Line");
			SeriesTypeCombo.Items.Add("Area");
			SeriesTypeCombo.Items.Add("SmoothLine");
			SeriesTypeCombo.Items.Add("Point");

			ValueModeCombo.FillFromEnum(typeof(EmptyDataPointsValueMode));
			AppearanceModeCombo.FillFromEnum(typeof(EmptyDataPointsAppearanceMode));
			MarkerModeCombo.FillFromEnum(typeof(EmptyDataPointsMarkerMode));

			SeriesTypeCombo.SelectedIndex = 0;
		}

		private void GenerateData(NSeries series, int nTotalCount, int nMaxEmptyCount)
		{
			SortedList arrEmptyIndices = new SortedList();

			for(int i = 0; i < nMaxEmptyCount; i++)
			{
				int nEmptyIndex = Random.Next(0, nTotalCount);
				arrEmptyIndices[nEmptyIndex] = null;
			}

			for(int k = 0; k < nTotalCount; k++)
			{
				if(arrEmptyIndices.ContainsKey(k))
				{
					series.Values.Add(DBNull.Value);
				}
				else
				{
					series.Values.Add(Random.NextDouble() * 10);
				}
			}
		}

		private void SeriesTypeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			SeriesType seriesType = SeriesType.Bar;

			switch(SeriesTypeCombo.SelectedIndex)
			{
				case 0:
					seriesType = SeriesType.Bar;
					break;
				case 1:
					seriesType = SeriesType.Line;
					break;
				case 2:
					seriesType = SeriesType.Area;
					break;
				case 3:
					seriesType = SeriesType.SmoothLine;
					break;
				case 4:
					seriesType = SeriesType.Point;
					break;
			}

			NChart chart = nChartControl1.Charts[0];

			chart.Series.Clear();

			NSeries series = (NSeries)chart.Series.Add(seriesType);
			series.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			series.Legend.Mode = SeriesLegendMode.DataPoints;
			series.EmptyDataPointsAppearance.MarkerMode = EmptyDataPointsMarkerMode.Normal;

			GenerateData(series, 10, 3);

			nChartControl1.Refresh();

			ValueModeCombo.SelectedIndex = 0;
			AppearanceModeCombo.SelectedIndex = 0;
			MarkerModeCombo.SelectedIndex = 0;
			ShowLabelsCheck.Checked = false;
			CustomValue.Text = "0";
		}

		private void ValueModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 != null)
			{
				CustomValue.Enabled = (ValueModeCombo.SelectedIndex == 2);

				NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];
				series.Values.EmptyDataPoints.ValueMode = (EmptyDataPointsValueMode)ValueModeCombo.SelectedIndex;

				nChartControl1.Refresh();
			}
		}

		private void CustomValue_TextChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			double dValue = 0;

			try
			{
				dValue = Double.Parse(CustomValue.Text);
			}
			catch
			{
				return;
			}

			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];
			series.Values.EmptyDataPoints.CustomValue = dValue;

			nChartControl1.Refresh();
		}

		private void AppearanceModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

			series.EmptyDataPointsAppearance.AppearanceMode = (EmptyDataPointsAppearanceMode)AppearanceModeCombo.SelectedIndex;

			nChartControl1.Refresh();
		}

		private void MarkerModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 != null)
			{
				NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];

				series.EmptyDataPointsAppearance.MarkerMode = (EmptyDataPointsMarkerMode)MarkerModeCombo.SelectedIndex;

				nChartControl1.Refresh();
			}
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
			if (nChartControl1 != null)
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
	}
}

