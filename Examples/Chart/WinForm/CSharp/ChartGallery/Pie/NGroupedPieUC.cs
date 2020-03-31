using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NGroupedPieUC : NExampleBaseUC
	{
		private NPieSeries m_Pie;
		private NDataSeriesDouble m_Values;
		private NDataSeriesDouble m_Detachments;
		private NDataSeriesString m_Labels;
		private NIndexedAttributeSeries m_FillStyles;
		private NIndexedAttributeSeries m_BorderStyles;
		private Color m_GroupColor;
		private double m_dGroupValue;
		private string m_sGroupLabel;
		private bool m_bGroupedData;
		private Nevron.UI.WinForm.Controls.NButton ChangeDataButton;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NTextBox GroupValueText;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NButton GroupColorButton;
		private Nevron.UI.WinForm.Controls.NTextBox GroupLabel;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NColorDialog colorDlg;
		private Nevron.UI.WinForm.Controls.NButton GroupValues;
		private Nevron.UI.WinForm.Controls.NButton UngroupData;
		private System.ComponentModel.Container components = null;

		public NGroupedPieUC()
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NGroupedPieUC));
			this.ChangeDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label2 = new System.Windows.Forms.Label();
			this.GroupValueText = new Nevron.UI.WinForm.Controls.NTextBox();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.GroupLabel = new Nevron.UI.WinForm.Controls.NTextBox();
			this.GroupColorButton = new Nevron.UI.WinForm.Controls.NButton();
			this.colorDlg = new Nevron.UI.WinForm.Controls.NColorDialog();
			this.GroupValues = new Nevron.UI.WinForm.Controls.NButton();
			this.UngroupData = new Nevron.UI.WinForm.Controls.NButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ChangeDataButton
			// 
			this.ChangeDataButton.Location = new System.Drawing.Point(4, 9);
			this.ChangeDataButton.Name = "ChangeDataButton";
			this.ChangeDataButton.Size = new System.Drawing.Size(173, 24);
			this.ChangeDataButton.TabIndex = 0;
			this.ChangeDataButton.Text = "Change Data";
			this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 106);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(151, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Group Below Value:";
			// 
			// GroupValueText
			// 
			this.GroupValueText.Location = new System.Drawing.Point(5, 123);
			this.GroupValueText.Name = "GroupValueText";
			this.GroupValueText.Size = new System.Drawing.Size(60, 18);
			this.GroupValueText.TabIndex = 4;
			this.GroupValueText.TextChanged += new System.EventHandler(this.GroupValueText_TextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.GroupLabel);
			this.groupBox1.Controls.Add(this.GroupColorButton);
			this.groupBox1.Controls.Add(this.GroupValueText);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(6, 109);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(171, 156);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Grouped Slice Properties";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(5, 53);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(151, 16);
			this.label3.TabIndex = 1;
			this.label3.Text = "Label:";
			// 
			// GroupLabel
			// 
			this.GroupLabel.Location = new System.Drawing.Point(5, 73);
			this.GroupLabel.Name = "GroupLabel";
			this.GroupLabel.Size = new System.Drawing.Size(151, 18);
			this.GroupLabel.TabIndex = 2;
			this.GroupLabel.Text = "Other";
			this.GroupLabel.TextChanged += new System.EventHandler(this.GroupLabel_TextChanged);
			// 
			// GroupColorButton
			// 
			this.GroupColorButton.Location = new System.Drawing.Point(5, 20);
			this.GroupColorButton.Name = "GroupColorButton";
			this.GroupColorButton.Size = new System.Drawing.Size(151, 24);
			this.GroupColorButton.TabIndex = 0;
			this.GroupColorButton.Text = "Color...";
			this.GroupColorButton.Click += new System.EventHandler(this.GroupColorButton_Click);
			// 
			// colorDlg
			// 
			this.colorDlg.ClientSize = new System.Drawing.Size(398, 351);
			this.colorDlg.Color = System.Drawing.Color.Empty;
			this.colorDlg.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.colorDlg.Icon = ((System.Drawing.Icon)(resources.GetObject("colorDlg.Icon")));
			this.colorDlg.Location = new System.Drawing.Point(193, 207);
			this.colorDlg.MaximizeBox = false;
			this.colorDlg.MinimizeBox = false;
			this.colorDlg.Name = "colorDlg";
			this.colorDlg.ShowCaptionImage = false;
			this.colorDlg.ShowInTaskbar = false;
			this.colorDlg.Sizable = false;
			this.colorDlg.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.colorDlg.Text = "Edit Color";
			this.colorDlg.Visible = false;
			// 
			// GroupValues
			// 
			this.GroupValues.Location = new System.Drawing.Point(4, 41);
			this.GroupValues.Name = "GroupValues";
			this.GroupValues.Size = new System.Drawing.Size(173, 24);
			this.GroupValues.TabIndex = 1;
			this.GroupValues.Text = "Group Values Below Value";
			this.GroupValues.Click += new System.EventHandler(this.GroupValues_Click);
			// 
			// UngroupData
			// 
			this.UngroupData.Location = new System.Drawing.Point(4, 73);
			this.UngroupData.Name = "UngroupData";
			this.UngroupData.Size = new System.Drawing.Size(173, 24);
			this.UngroupData.TabIndex = 2;
			this.UngroupData.Text = "Ungroup Data";
			this.UngroupData.Click += new System.EventHandler(this.UngroupData_Click);
			// 
			// NGroupedPieUC
			// 
			this.Controls.Add(this.UngroupData);
			this.Controls.Add(this.GroupValues);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.ChangeDataButton);
			this.Name = "NGroupedPieUC";
			this.Size = new System.Drawing.Size(180, 276);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Grouped Pie Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			NChart m_Chart = new NPieChart();
			m_Chart.Enable3D = true;

			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(m_Chart);
			m_Chart.DisplayOnLegend = nChartControl1.Legends[0];
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.VividCameraLight);
			m_Chart.Location = new NPointL(new NLength(20, NRelativeUnit.ParentPercentage), new NLength(20, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(60, NRelativeUnit.ParentPercentage), new NLength(60, NRelativeUnit.ParentPercentage));

			// setup pie series
			m_Pie = (NPieSeries)m_Chart.Series.Add(SeriesType.Pie);
			m_Pie.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Pie.Legend.Format = "<label> <percent>";
			m_Pie.Legend.TextStyle.FontStyle.EmSize = new NLength(10, NGraphicsUnit.Pixel);
			m_Pie.ConnectorLength = new NLength(10);

			m_Pie.Labels.Add("Cars");
			m_Pie.Labels.Add("Trains");
			m_Pie.Labels.Add("Airplanes");
			m_Pie.Labels.Add("Buses");
			m_Pie.Labels.Add("Bikes");
			m_Pie.Labels.Add("Motorcycles");
			m_Pie.Labels.Add("Shuttles");
			m_Pie.Labels.Add("Rollers");
			m_Pie.Labels.Add("Ski");
			m_Pie.Labels.Add("Surf");

			// fill with random data
			m_Pie.Detachments.FillRandomRange(Random, 10, 0, 0);
			m_Pie.Values.FillRandomRange(Random, 10, 0, 100);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);

			// store the original data and styles
            m_Values = (NDataSeriesDouble)m_Pie.Values.Clone();
            m_Detachments = (NDataSeriesDouble)m_Pie.Detachments.Clone();
            m_Labels = (NDataSeriesString)m_Pie.Labels.Clone();
			m_FillStyles = (NIndexedAttributeSeries)m_Pie.FillStyles.Clone();
			m_BorderStyles = (NIndexedAttributeSeries)m_Pie.BorderStyles.Clone();
			m_bGroupedData = false;

			// init form controls
			GroupValueText.Text = "34";
			m_sGroupLabel = "Other";
			m_GroupColor = Color.Red;
		}

		private void ChangeDataButton_Click(object sender, System.EventArgs e)
		{
			// generate random values
			m_Pie.Values.FillRandomRange(Random, 10, 0, 100);

			// store the new values
            m_Values = (NDataSeriesDouble)m_Pie.Values.Clone();

			// restore other data series
            m_Pie.Detachments = (NDataSeriesDouble)m_Detachments.Clone();
            m_Pie.Labels = (NDataSeriesString)m_Labels.Clone();
			m_Pie.FillStyles = (NIndexedAttributeSeries)m_FillStyles.Clone();
			m_Pie.BorderStyles = (NIndexedAttributeSeries)m_BorderStyles.Clone();

			m_bGroupedData = false;
			nChartControl1.Refresh();
		}

		private void GroupValueText_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				m_dGroupValue = Double.Parse(GroupValueText.Text);
			}
			catch
			{
			}
		}

		private void GroupLabel_TextChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_sGroupLabel = GroupLabel.Text;

			if (m_bGroupedData)
			{
				m_Pie.Labels[m_Pie.Labels.Count -1] = m_sGroupLabel;
			}

			nChartControl1.Refresh();
		}

		private void GroupColorButton_Click(object sender, System.EventArgs e)
		{
			colorDlg.Color = m_GroupColor;

			if (colorDlg.ShowDialog() == DialogResult.Cancel)
				return;

			m_GroupColor = colorDlg.Color;

			if (m_bGroupedData)
			{
				int nIndex = m_Pie.Values.Count - 1;

				m_Pie.FillStyles[nIndex] = new NColorFillStyle(m_GroupColor);
				((NStrokeStyle)m_Pie.BorderStyles[nIndex]).Color = m_GroupColor;
			}

			nChartControl1.Refresh();
		}

		private void GroupValues_Click(object sender, System.EventArgs e)
		{
			if (m_bGroupedData)
			{
				MessageBox.Show("Click the ungroup button first");
				return;
			}

			// get a subset containing the pies which are smaller than the specified value
			NDataSeriesSubset smallerThanValue = m_Pie.Values.Filter(Nevron.Chart.CompareMethod.Less, m_dGroupValue);

			// determine the sum of the filtered pies
			double dOtherSliceValue = m_Pie.Values.Evaluate("SUM", smallerThanValue);

			// remove the data points contained in the 
			for (int i = m_Pie.GetDataPointCount(); i >= 0; i--)
			{
				if (smallerThanValue.Contains(i))
					m_Pie.RemoveDataPointAt(i);
			}

			// add a detached pie with the specified group label and color
			NDataPoint dp = new NDataPoint(dOtherSliceValue, m_sGroupLabel);
			dp[DataPointValue.PieDetachment] = 2;
			dp[DataPointValue.FillStyle] = new NColorFillStyle(m_GroupColor);
			dp[DataPointValue.StrokeStyle] = new NStrokeStyle(1, m_GroupColor);
			m_Pie.AddDataPoint(dp);

			m_bGroupedData = true;
			nChartControl1.Refresh();
		}

		private void UngroupData_Click(object sender, System.EventArgs e)
		{
			if (m_bGroupedData == false)
			{
				MessageBox.Show("Data is not grouped - click the Group Values button first");
				return;
			}

			// just restore with initial data
            m_Pie.Values = (NDataSeriesDouble)m_Values.Clone();
			m_Pie.Detachments = (NDataSeriesDouble)m_Detachments.Clone();
			m_Pie.Labels = (NDataSeriesString)m_Labels.Clone();
			m_Pie.FillStyles = (NIndexedAttributeSeries)m_FillStyles.Clone();
			m_Pie.BorderStyles = (NIndexedAttributeSeries)m_BorderStyles.Clone();

			m_bGroupedData = false;
			nChartControl1.Refresh();
		}
	}
}
