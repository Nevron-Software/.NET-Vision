using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NSortingDataUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBarSeries m_Bar;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox SortOrder;
		private Nevron.UI.WinForm.Controls.NButton ChangeData;
		private Nevron.UI.WinForm.Controls.NButton SortAllOnValues;
		private Nevron.UI.WinForm.Controls.NButton SortAllOnLabels;
		private Nevron.UI.WinForm.Controls.NButton SortValuesOnly;
		private Nevron.UI.WinForm.Controls.NButton SortFillStylesOnly;
		private System.ComponentModel.Container components = null;

		public NSortingDataUC()
		{
			InitializeComponent();

			SortOrder.FillFromEnum(typeof(DataSeriesSortOrder));
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
			this.ChangeData = new Nevron.UI.WinForm.Controls.NButton();
			this.SortValuesOnly = new Nevron.UI.WinForm.Controls.NButton();
			this.SortAllOnValues = new Nevron.UI.WinForm.Controls.NButton();
			this.SortAllOnLabels = new Nevron.UI.WinForm.Controls.NButton();
			this.SortOrder = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SortFillStylesOnly = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// ChangeData
			// 
			this.ChangeData.Location = new System.Drawing.Point(9, 9);
			this.ChangeData.Name = "ChangeData";
			this.ChangeData.Size = new System.Drawing.Size(160, 23);
			this.ChangeData.TabIndex = 0;
			this.ChangeData.Text = "Change Data";
			this.ChangeData.Click += new System.EventHandler(this.ChangeData_Click);
			// 
			// SortValuesOnly
			// 
			this.SortValuesOnly.Location = new System.Drawing.Point(9, 106);
			this.SortValuesOnly.Name = "SortValuesOnly";
			this.SortValuesOnly.Size = new System.Drawing.Size(160, 24);
			this.SortValuesOnly.TabIndex = 1;
			this.SortValuesOnly.Text = "Sort Values Only";
			this.SortValuesOnly.Click += new System.EventHandler(this.SortValuesOnly_Click);
			// 
			// SortAllOnValues
			// 
			this.SortAllOnValues.Location = new System.Drawing.Point(9, 166);
			this.SortAllOnValues.Name = "SortAllOnValues";
			this.SortAllOnValues.Size = new System.Drawing.Size(160, 24);
			this.SortAllOnValues.TabIndex = 2;
			this.SortAllOnValues.Text = "Sort All By Values";
			this.SortAllOnValues.Click += new System.EventHandler(this.SortAllOnValues_Click);
			// 
			// SortAllOnLabels
			// 
			this.SortAllOnLabels.Location = new System.Drawing.Point(9, 196);
			this.SortAllOnLabels.Name = "SortAllOnLabels";
			this.SortAllOnLabels.Size = new System.Drawing.Size(160, 24);
			this.SortAllOnLabels.TabIndex = 3;
			this.SortAllOnLabels.Text = "Sort All By Labels";
			this.SortAllOnLabels.Click += new System.EventHandler(this.SortAllOnLabels_Click);
			// 
			// SortOrder
			// 
			this.SortOrder.ListProperties.CheckBoxDataMember = "";
			this.SortOrder.ListProperties.DataSource = null;
			this.SortOrder.ListProperties.DisplayMember = "";
			this.SortOrder.Location = new System.Drawing.Point(9, 65);
			this.SortOrder.Name = "SortOrder";
			this.SortOrder.Size = new System.Drawing.Size(160, 21);
			this.SortOrder.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Sort Order:";
			// 
			// SortFillStylesOnly
			// 
			this.SortFillStylesOnly.Location = new System.Drawing.Point(9, 136);
			this.SortFillStylesOnly.Name = "SortFillStylesOnly";
			this.SortFillStylesOnly.Size = new System.Drawing.Size(160, 24);
			this.SortFillStylesOnly.TabIndex = 6;
			this.SortFillStylesOnly.Text = "Sort All By Fill Styles";
			this.SortFillStylesOnly.Click += new System.EventHandler(this.SortAllOnFillStyles_Click);
			// 
			// NSortingDataUC
			// 
			this.Controls.Add(this.SortFillStylesOnly);
			this.Controls.Add(this.SortOrder);
			this.Controls.Add(this.SortAllOnLabels);
			this.Controls.Add(this.SortAllOnValues);
			this.Controls.Add(this.SortValuesOnly);
			this.Controls.Add(this.ChangeData);
			this.Controls.Add(this.label1);
			this.Name = "NSortingDataUC";
			this.Size = new System.Drawing.Size(180, 236);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Sorting Data");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 20, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid;
			title.TextStyle.ShadowStyle.Color = Color.White;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// create a bar chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			m_Bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar.Legend.Mode = SeriesLegendMode.DataPoints;

			FillRandom(6);

			SortOrder.SelectedIndex = 0;
		}

		private void FillRandom(int nCount)
		{
			m_Bar.Values.FillRandom(Random, nCount);
			m_Bar.Labels.FillRandom(Random, nCount);

			for(int i = 0; i < nCount; i++)
			{
				m_Bar.FillStyles[i] = new NColorFillStyle(RandomColor());
			}
		}

		private void ChangeData_Click(object sender, System.EventArgs e)
		{
			FillRandom(6);
			nChartControl1.Refresh();
		}

		private void SortValuesOnly_Click(object sender, System.EventArgs e)
		{
			m_Bar.Values.Sort((DataSeriesSortOrder)SortOrder.SelectedIndex);
			nChartControl1.Refresh();
		}

		private void SortAllOnValues_Click(object sender, System.EventArgs e)
		{
			NDataSeriesCollection arrSeries = m_Bar.GetDataSeries(DataSeriesMask.Values | DataSeriesMask.Labels | DataSeriesMask.FillStyles, DataSeriesMask.None, false);

			int nMasterIndex = arrSeries.FindByMask(DataSeriesMask.Values);

			arrSeries.Sort(nMasterIndex, (DataSeriesSortOrder)SortOrder.SelectedIndex);

			nChartControl1.Refresh();
		}

		private void SortAllOnLabels_Click(object sender, System.EventArgs e)
		{
			NDataSeriesCollection arrSeries = m_Bar.GetDataSeries(DataSeriesMask.Values | DataSeriesMask.Labels | DataSeriesMask.FillStyles, DataSeriesMask.None, false);

			int nMasterIndex = arrSeries.FindByMask(DataSeriesMask.Labels);

			arrSeries.Sort(nMasterIndex, (DataSeriesSortOrder)SortOrder.SelectedIndex);

			nChartControl1.Refresh();
		}

		private void SortAllOnFillStyles_Click(object sender, System.EventArgs e)
		{
			// demonstration of the custom comparer support
			NCustomComparer customComparer = new NCustomComparer();

			NDataSeriesCollection arrSeries = m_Bar.GetDataSeries(DataSeriesMask.Values | DataSeriesMask.Labels | DataSeriesMask.FillStyles, DataSeriesMask.None, false);

			int nMasterIndex = arrSeries.FindByMask(DataSeriesMask.FillStyles);

			arrSeries.Sort(nMasterIndex, (DataSeriesSortOrder)SortOrder.SelectedIndex, customComparer);

			nChartControl1.Refresh();
		}
	}

	public class NCustomComparer : IComparer
	{
		public int Compare(object a, object b)
		{
			NFillStyle feA = (NFillStyle)a;
			NFillStyle feB = (NFillStyle)b;

			Color colorA = feA.GetPrimaryColor().ToColor();
			Color colorB = feB.GetPrimaryColor().ToColor();

			int aRGBSum = Convert.ToInt32(colorA.R) + Convert.ToInt32(colorA.G) + Convert.ToInt32(colorA.B);
            int bRGBSum = Convert.ToInt32(colorB.R) + Convert.ToInt32(colorB.G) + Convert.ToInt32(colorB.B);

			if (aRGBSum < bRGBSum)
				return -1;

			if (aRGBSum > bRGBSum)
				return +1;

			return 0;
		}
	}
}
