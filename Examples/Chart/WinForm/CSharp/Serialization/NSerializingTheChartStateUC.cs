using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Serialization;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.Functions; 

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NSerializingTheChartStateUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox SerializationFormatComboBox;
		private Nevron.UI.WinForm.Controls.NButton SaveToFileButton;
		private Nevron.UI.WinForm.Controls.NButton LoadFromFileButton;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NComboBox SerializationContentComboBox;
		private Nevron.UI.WinForm.Controls.NButton ResetChartButton;
		private Nevron.UI.WinForm.Controls.NButton ModifyDataButton;
		private Nevron.UI.WinForm.Controls.NButton ModifyAppearanceButton;

		private NChart m_Chart;
		private NHighLowSeries m_HighLow;
		private NLineSeries m_LineSMA;
		private NStockSeries m_Stock;
		private const int nNumberOfWeeks = 20;
		private const int nWorkDaysInWeek = 5;
		private const int nDaysInWeek = 7;
		private const int nTotalWorkDays = nNumberOfWeeks * nWorkDaysInWeek;
		private const int nTotalDays = nNumberOfWeeks * nDaysInWeek;
		private System.ComponentModel.Container components = null;

		public NSerializingTheChartStateUC()
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
			this.SaveToFileButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SerializationFormatComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.LoadFromFileButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label2 = new System.Windows.Forms.Label();
			this.SerializationContentComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.ResetChartButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ModifyDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ModifyAppearanceButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Serialization format:";
			// 
			// SaveToFileButton
			// 
			this.SaveToFileButton.Location = new System.Drawing.Point(8, 112);
			this.SaveToFileButton.Name = "SaveToFileButton";
			this.SaveToFileButton.Size = new System.Drawing.Size(136, 23);
			this.SaveToFileButton.TabIndex = 1;
			this.SaveToFileButton.Text = "Save to File";
			this.SaveToFileButton.Click += new System.EventHandler(this.SaveToFileButton_Click);
			// 
			// SerializationFormatComboBox
			// 
			this.SerializationFormatComboBox.Location = new System.Drawing.Point(8, 24);
			this.SerializationFormatComboBox.Name = "SerializationFormatComboBox";
			this.SerializationFormatComboBox.Size = new System.Drawing.Size(136, 21);
			this.SerializationFormatComboBox.TabIndex = 2;
			this.SerializationFormatComboBox.SelectedIndexChanged += new System.EventHandler(this.SerializationFormatComboBox_SelectedIndexChanged);
			// 
			// LoadFromFileButton
			// 
			this.LoadFromFileButton.Location = new System.Drawing.Point(8, 144);
			this.LoadFromFileButton.Name = "LoadFromFileButton";
			this.LoadFromFileButton.Size = new System.Drawing.Size(136, 23);
			this.LoadFromFileButton.TabIndex = 3;
			this.LoadFromFileButton.Text = "LoadFromFile";
			this.LoadFromFileButton.Click += new System.EventHandler(this.LoadFromFileButton_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Serialization content:";
			// 
			// SerializationContentComboBox
			// 
			this.SerializationContentComboBox.Location = new System.Drawing.Point(8, 80);
			this.SerializationContentComboBox.Name = "SerializationContentComboBox";
			this.SerializationContentComboBox.Size = new System.Drawing.Size(136, 21);
			this.SerializationContentComboBox.TabIndex = 5;
			// 
			// ResetChartButton
			// 
			this.ResetChartButton.Location = new System.Drawing.Point(8, 224);
			this.ResetChartButton.Name = "ResetChartButton";
			this.ResetChartButton.Size = new System.Drawing.Size(136, 23);
			this.ResetChartButton.TabIndex = 6;
			this.ResetChartButton.Text = "Reset chart";
			this.ResetChartButton.Click += new System.EventHandler(this.ResetChartButton_Click);
			// 
			// ModifyDataButton
			// 
			this.ModifyDataButton.Location = new System.Drawing.Point(8, 256);
			this.ModifyDataButton.Name = "ModifyDataButton";
			this.ModifyDataButton.Size = new System.Drawing.Size(136, 23);
			this.ModifyDataButton.TabIndex = 7;
			this.ModifyDataButton.Text = "Modify data";
			this.ModifyDataButton.Click += new System.EventHandler(this.ModifyDataButton_Click);
			// 
			// ModifyAppearanceButton
			// 
			this.ModifyAppearanceButton.Location = new System.Drawing.Point(8, 288);
			this.ModifyAppearanceButton.Name = "ModifyAppearanceButton";
			this.ModifyAppearanceButton.Size = new System.Drawing.Size(136, 23);
			this.ModifyAppearanceButton.TabIndex = 8;
			this.ModifyAppearanceButton.Text = "Modify appearance";
			this.ModifyAppearanceButton.Click += new System.EventHandler(this.ModifyAppearanceButton_Click);
			// 
			// NSerializingTheChartState
			// 
			this.Controls.Add(this.ModifyAppearanceButton);
			this.Controls.Add(this.ModifyDataButton);
			this.Controls.Add(this.ResetChartButton);
			this.Controls.Add(this.SerializationContentComboBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.LoadFromFileButton);
			this.Controls.Add(this.SerializationFormatComboBox);
			this.Controls.Add(this.SaveToFileButton);
			this.Controls.Add(this.label1);
			this.Name = "NSerializingTheChartState";
			this.Size = new System.Drawing.Size(150, 440);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// Init form controls
			string[] arrPersistencyFormats = Enum.GetNames(typeof(PersistencyFormat));
			for (int i = 0; i < arrPersistencyFormats.Length; i++)
			{
				SerializationFormatComboBox.Items.Add(arrPersistencyFormats[i]);
			}

			SerializationContentComboBox.Items.Add("All");
			SerializationContentComboBox.Items.Add("Data");
			SerializationContentComboBox.Items.Add("Appearance");
			SerializationContentComboBox.SelectedIndex = 0;

			ResetChartButton_Click(null, null);
		}

		private void GenerateData(int nCount)
		{
			DateTime now = DateTime.Now;
			GenerateOHLCData(m_Stock, 300, nCount);
			TimeSpan day = new TimeSpan(1, 0, 0, 0, 0);

			for (int i = 0; i < nCount; i++)
			{
				m_Stock.XValues.Add(now);
				m_HighLow.XValues.Add(now);
				m_LineSMA.XValues.Add(now);

				now += day;
			}

			// create a function calculator
			NFunctionCalculator fc = new NFunctionCalculator();
			m_Stock.CloseValues.Name = "close";
			fc.Arguments.Add(m_Stock.CloseValues);

			// calculate the bollinger bands
			fc.Expression = "BOLLINGER(close; 20; 2)";
			m_HighLow.HighValues = fc.Calculate();

			fc.Expression = "BOLLINGER(close; 20; -2)";
			m_HighLow.LowValues = fc.Calculate();

			// calculate the simple moving average
			fc.Expression = "SMA(close; 20)";
			m_LineSMA.Values = fc.Calculate();

			// remove data that won't be charted
			m_Stock.HighValues.RemoveRange(0, 20);
			m_Stock.LowValues.RemoveRange(0, 20);
			m_Stock.OpenValues.RemoveRange(0, 20);
			m_Stock.CloseValues.RemoveRange(0, 20);
			m_HighLow.HighValues.RemoveRange(0, 20);
			m_HighLow.LowValues.RemoveRange(0, 20);
			m_LineSMA.Values.RemoveRange(0, 20);
		}

		private NSerializationFilter GetSeriazliationFilter()
		{
			PersistencyFormat format = (PersistencyFormat)SerializationFormatComboBox.SelectedIndex;

			if (format.Equals(PersistencyFormat.Binary) || format.Equals(PersistencyFormat.XML) || format.Equals(PersistencyFormat.SOAP))
			{
				return null;
			}

			NSerializationFilter filter = null;

			switch (SerializationContentComboBox.SelectedIndex)
			{
				case 0: // All
					filter = null;
					break;
				case 1: // Data
					filter = new NDataSerializationFilter();
					break;
				case 2: // Appearance
					filter = new NAppearanceSerializationFilter();
					break;
			}

			return filter;
		}

		private void SaveToFileButton_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Binary(*.bin)|*.bin|XML(*.xml)|*.xml|All files (*.*)|*.*";

			if (dlg.ShowDialog() != DialogResult.OK)
				return;

			try
			{
				NSerializationFilter filter = GetSeriazliationFilter();
				nChartControl1.Serializer.SaveControlStateToFile(dlg.FileName, (PersistencyFormat)SerializationFormatComboBox.SelectedIndex, filter);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void LoadFromFileButton_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Binary(*.bin)|*.bin|XML(*.xml)|*.xml|All files (*.*)|*.*";

			if (dlg.ShowDialog() != DialogResult.OK)
				return;

			try
			{
				NSerializationFilter filter = GetSeriazliationFilter();
				nChartControl1.Serializer.LoadControlStateFromFile(dlg.FileName, (PersistencyFormat)SerializationFormatComboBox.SelectedIndex, filter);

				// update form members
				if (nChartControl1.Charts.Count > 0)
				{
					m_Chart = nChartControl1.Charts[0];

					foreach (NSeriesBase series in m_Chart.Series)
					{
						if (series is NHighLowSeries)
						{
							m_HighLow = (NHighLowSeries)series;
						}
						else if (series is NLineSeries)
						{
							m_LineSMA = (NLineSeries)series;
						}
						else if (series is NStockSeries)
						{
							m_Stock = (NStockSeries)series;
						}
					}
				}

				nChartControl1.Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ResetChartButton_Click(object sender, System.EventArgs e)
		{
			nChartControl1.Clear();

			const int nNumberOfWeeks = 20;
			const int nWorkDaysInWeek = 5;
			const int nDaysInWeek = 7;
			const int nTotalWorkDays = nNumberOfWeeks * nWorkDaysInWeek;
			const int nTotalDays = nNumberOfWeeks * nDaysInWeek;

			NLabel title = nChartControl1.Labels.AddHeader("Financial Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Fit;

			m_Chart.Location = new NPointL(new NLength(7, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(86, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));

			m_Chart.Height = 30;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			m_Chart.Wall(ChartWallType.Floor).Visible = false;
			m_Chart.Wall(ChartWallType.Left).Visible = false;
			m_Chart.Wall(ChartWallType.Back).Width = 0;
			m_Chart.Wall(ChartWallType.Back).FillStyle = new NColorFillStyle(Color.FromArgb(239, 245, 239));
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// setup y axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.LineStyle.Color = Color.Gray;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, false);

			// setup x axis
			NAxis axisX1 = m_Chart.Axis(StandardAxis.PrimaryX);

			linearScale = new NLinearScaleConfigurator();
			axisX1.ScaleConfigurator = linearScale;

			linearScale.AutoLabels = false;

			linearScale.MinorTickCount = 4;
			linearScale.MajorTickMode = MajorTickMode.CustomStep;
			linearScale.CustomStep = 5;
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;
			linearScale.OuterMajorTickStyle.Length = new NLength(4, NGraphicsUnit.Point);
			linearScale.InnerMajorTickStyle.Visible = false;
			linearScale.InnerMinorTickStyle.Visible = false;
			linearScale.OuterMinorTickStyle.Length = new NLength(2, NGraphicsUnit.Point);
			linearScale.OuterMinorTickStyle.LineStyle.Color = Color.Brown;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, false);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.LabelStyle.ValueScale = 0.2;

			// create a line series for the simple moving average
			m_LineSMA = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_LineSMA.Name = "SMA(20)";
			m_LineSMA.DataLabelStyle.Visible = false;
			m_LineSMA.BorderStyle.Color = Color.DarkOrange;

			// create the stock series
			m_Stock = (NStockSeries)m_Chart.Series.Add(SeriesType.Stock);
			m_Stock.Name = "Stock Data";
			m_Stock.Legend.Mode = SeriesLegendMode.None;
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.CandleStyle = CandleStyle.Bar;
			m_Stock.CandleWidth = new NLength(5, NGraphicsUnit.Point);
			m_Stock.InflateMargins = false;
			m_Stock.DownFillStyle = new NColorFillStyle(Color.Maroon);
			m_Stock.UpFillStyle = new NColorFillStyle(Color.CornflowerBlue);
			m_Stock.DisplayOnAxis(StandardAxis.PrimaryX, true);
			m_Stock.UpStrokeStyle.Width = new NLength(1, NGraphicsUnit.Pixel);
			m_Stock.DownStrokeStyle.Width = new NLength(1, NGraphicsUnit.Pixel);
			m_Stock.UpStrokeStyle.Color = Color.Navy;
			m_Stock.DownStrokeStyle.Color = Color.Maroon;
			m_Stock.InflateMargins = true;

			// add the bollinger bands as high low area
			m_HighLow = (NHighLowSeries)m_Chart.Series.Add(SeriesType.HighLow);
			m_HighLow.Name = "BB(20, 2)";
			m_HighLow.DataLabelStyle.Visible = false;
			m_HighLow.HighFillStyle = new NColorFillStyle(Color.FromArgb(80, 130, 134, 168));
			m_HighLow.HighBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			m_HighLow.DisplayOnAxis(StandardAxis.SecondaryX, true);

			// generate some stock data
			GenerateData(nTotalWorkDays + 20);

			// create a function calculator
			NFunctionCalculator fc = new NFunctionCalculator();
			m_Stock.CloseValues.Name = "close";
			fc.Arguments.Add(m_Stock.CloseValues);

			// calculate the bollinger bands
			fc.Expression = "BOLLINGER(close; 20; 2)";
			m_HighLow.HighValues = fc.Calculate();

			fc.Expression = "BOLLINGER(close; 20; -2)";
			m_HighLow.LowValues = fc.Calculate();

			// calculate the simple moving average
			fc.Expression = "SMA(close; 20)";
			m_LineSMA.Values = fc.Calculate();

			// remove data that won't be charted
			m_Stock.HighValues.RemoveRange(0, 20);
			m_Stock.LowValues.RemoveRange(0, 20);
			m_Stock.OpenValues.RemoveRange(0, 20);
			m_Stock.CloseValues.RemoveRange(0, 20);
			m_HighLow.HighValues.RemoveRange(0, 20);
			m_HighLow.LowValues.RemoveRange(0, 20);
			m_LineSMA.Values.RemoveRange(0, 20);

			GenerateDateLabels(nTotalDays);
		
			nChartControl1.Refresh();
		}

		private void GenerateDateLabels(int nTotalDays)
		{
			// the chart starts with the first monday of june 2003
			DateTime dt = new DateTime(2003, 6, 2);
			TimeSpan daySpan = new TimeSpan(1, 0, 0, 0);
			NFontStyle labelFont = new NFontStyle("Arial", 9, FontStyle.Bold);
			NAxis axisX1 = m_Chart.Axis(StandardAxis.PrimaryX);
			NLinearScaleConfigurator linearScale = axisX1.ScaleConfigurator as NLinearScaleConfigurator;
			int nCurCategory = 0;
			m_Chart.ChildPanels.Clear();

			for(int i = 0; i < nTotalDays; i++)
			{
				// add a custom label for the first work day of the month
				if( (dt.Day == 1) ||
					((dt.DayOfWeek == DayOfWeek.Monday) && (dt.Day == 2 || dt.Day == 3)))
				{
					NRectangularCallout callout = new NRectangularCallout();
					callout.Anchor = new NAxisValueAnchor(axisX1, AxisValueAnchorMode.Clamp, nCurCategory);
					callout.Orientation = 270;

					callout.TextStyle.FontStyle = labelFont;
					callout.Text = dt.ToString("MMM yyyy");
					callout.StrokeStyle.Color = Color.DarkSeaGreen;
                    callout.StrokeStyle.Pattern = LinePattern.Dot;
					callout.ArrowBasePercent = 0;
					callout.UseAutomaticSize = true;

					m_Chart.ChildPanels.Add(callout);

					NAxisConstLine cl = axisX1.ConstLines.Add();
					cl.Value = nCurCategory;
					cl.StrokeStyle.Color = Color.DarkSeaGreen;

					
				}

				if(dt.DayOfWeek == DayOfWeek.Monday)
				{
					if((dt.Day == 1) || (dt.Day == 2) || (dt.Day == 3))
					{
						linearScale.Labels.Add("");
						nCurCategory++;
					}
					else
					{
						linearScale.Labels.Add(dt.Day.ToString());
						nCurCategory++;
					}
				}
				else if(dt.DayOfWeek == DayOfWeek.Saturday)
				{
				}
				else if(dt.DayOfWeek == DayOfWeek.Sunday)
				{
				}
				else
				{
					nCurCategory++;
				}

				dt += daySpan;
			}
		}

		private void ModifyDataButton_Click(object sender, System.EventArgs e)
		{
			GenerateData(nTotalWorkDays + 20);
			nChartControl1.Refresh();
		}

		private void ModifyAppearanceButton_Click(object sender, System.EventArgs e)
		{
			m_Chart.Wall(ChartWallType.Back).FillStyle = new NColorFillStyle(RandomColor());
			// create a line series for the simple moving average
			m_LineSMA.BorderStyle.Color = RandomColor();

			m_Stock.DownFillStyle = new NColorFillStyle(RandomColor());
			m_Stock.UpFillStyle = new NColorFillStyle(RandomColor());
			m_Stock.UpStrokeStyle.Color = RandomColor();
			m_Stock.DownStrokeStyle.Color = RandomColor();

			// add the bollinger bands as high low area
			m_HighLow.HighFillStyle = new NColorFillStyle(RandomColor());

			nChartControl1.Refresh();
		}

		private void SerializationFormatComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			PersistencyFormat format = (PersistencyFormat)SerializationFormatComboBox.SelectedIndex;

			if (format.Equals(PersistencyFormat.Binary) || format.Equals(PersistencyFormat.XML) || format.Equals(PersistencyFormat.SOAP))
			{
				SerializationContentComboBox.Enabled = false;
			}
			else
			{
				SerializationContentComboBox.Enabled = true;
			}
		}
	}
}
