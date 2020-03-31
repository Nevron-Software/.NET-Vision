using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.UI;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NLabelImageEmbeddingUC : NExampleBaseUC
    {
        private System.ComponentModel.Container components = null;
        		
		public NLabelImageEmbeddingUC()
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

                // IMPORTANT! - you have to clear the repository once done with the control in order to 
                // prevent memory leaks from images stored in it
                NImageRepository.Instance.Clear();
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
			this.SuspendLayout();
			// 
			// NLabelImageEmbeddingUC
			// 
			this.Name = "NLabelImageEmbeddingUC";
			this.Size = new System.Drawing.Size(180, 542);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

            nChartControl1.Panels.Clear();

            // create chart title
            NLabel label = new NLabel();
            nChartControl1.Panels.Add(label);

            label.Text = "Verified CO<sub>2</sub> Emissions for 2005<br/>Proposed and Allowed Emissions Caps for 2008-2012";
            label.TextStyle.FontStyle = new NFontStyle("Sylfaen", 13);
            label.TextStyle.TextFormat = TextFormat.XML;
            label.TextStyle.ShadowStyle.Type = ShadowType.GaussianBlur;
            label.TextStyle.ShadowStyle.FadeLength = new NLength(4);
            label.TextStyle.ShadowStyle.Offset = new NPointL(
                new NLength(1, NGraphicsUnit.Pixel),
                new NLength(1, NGraphicsUnit.Pixel));
            label.ContentAlignment = ContentAlignment.BottomCenter;
            label.Location = new NPointL(
                new NLength(50, NRelativeUnit.ParentPercentage),
                new NLength(1, NRelativeUnit.ParentPercentage));

            // create a legend
            NLegend legend = new NLegend();
            nChartControl1.Panels.Add(legend);

            legend.ContentAlignment = ContentAlignment.TopRight;
            legend.Location = new NPointL(
                new NLength(0.8f, NRelativeUnit.ParentPercentage),
                new NLength(99, NRelativeUnit.ParentPercentage));
            legend.Data.MarkSize = new NSizeL(
                new NLength(4, NGraphicsUnit.Point),
                new NLength(4, NGraphicsUnit.Point));

            NChart chart = new NCartesianChart();
            nChartControl1.Charts.Add(chart);

            chart.BoundsMode = BoundsMode.Stretch;
            chart.DisplayOnLegend = legend;

            NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();

            // setup title
            scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
            scaleY.Title.Text = "MMTCO<sub>2</sub> Eq.";
            scaleY.Title.TextStyle.TextFormat = TextFormat.XML;
            scaleY.Title.Angle = new NScaleLabelAngle(90);

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            scaleY.StripStyles.Add(stripStyle);

            chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

            DataTable table = CreateDataTable();

            NOrdinalScaleConfigurator scaleX = new NOrdinalScaleConfigurator();
            scaleX.AutoLabels = false;

            // register images in the repository. You can later access the image
            // from it's alias in XML formatted text
            string[] countlyFlagResourceName = new string[] { "Austria.png", "Finland.png", "France.png", "Germany.png", "Greece.png", "Italy.png", "Poland.png", "Spain.png", "Sweden.png", "UK.png" };
            string[] countlyFlagAlias = new string[] { "Austria", "Finland", "France", "Germany", "Greece", "Italy", "Poland", "Spain", "Sweden", "UK" };

            for (int i = 0; i < countlyFlagResourceName.Length; i++)
            {
                Bitmap bmp = GetCountrlyFlagImage(countlyFlagResourceName[i]);
                NImageRepository.Instance.RegisterImage(countlyFlagAlias[i], bmp);
            }

            scaleX.LabelStyle.TextStyle.TextFormat = TextFormat.XML;

            // add labels from data table
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                scaleX.Labels.Add(row[0]);
            }

            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

            CreateClusterBars(chart, table);

            // apply layout
            ConfigureStandardLayout(chart, label, legend);

			nChartControl1.Refresh();
		}

        private void CreateClusterBars(NChart chart, DataTable table)
        {
            NBarSeries electricEmissions = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            electricEmissions.Name = "2005 Emissions - Electric Power";
            electricEmissions.FillStyle = new NColorFillStyle(Color.FromArgb(195, 193, 27));
            electricEmissions.MultiBarMode = MultiBarMode.Series;
            electricEmissions.DataLabelStyle.Visible = false;
            electricEmissions.BorderStyle.Width = new NLength(0);

            NBarSeries transportationEmissions = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            transportationEmissions.Name = "2005 Emissions - Transportation";
            transportationEmissions.FillStyle = new NColorFillStyle(Color.FromArgb(182, 98, 17));
            transportationEmissions.MultiBarMode = MultiBarMode.Stacked;
            transportationEmissions.DataLabelStyle.Visible = false;
            transportationEmissions.BorderStyle.Width = new NLength(0);

            NBarSeries industrialEmissions = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            industrialEmissions.Name = "2005 Emissions - Industrial & Other";
            industrialEmissions.FillStyle = new NColorFillStyle(Color.FromArgb(144, 47, 79));
            industrialEmissions.MultiBarMode = MultiBarMode.Stacked;
            industrialEmissions.DataLabelStyle.Visible = false;
            industrialEmissions.BorderStyle.Width = new NLength(0);

            NBarSeries proposed = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            proposed.Name = "Proposed Cap 2008-2012";
            proposed.FillStyle = new NColorFillStyle(Color.FromArgb(94, 129, 179));
            proposed.MultiBarMode = MultiBarMode.Clustered;
            proposed.DataLabelStyle.Visible = false;
            proposed.BorderStyle.Width = new NLength(0);

            NBarSeries allowed = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            allowed.Name = "Allowed Cap 2008-2012";
            allowed.FillStyle = new NColorFillStyle(Color.FromArgb(141, 77, 232));
            allowed.MultiBarMode = MultiBarMode.Clustered;
            allowed.DataLabelStyle.Visible = false;
            allowed.BorderStyle.Width = new NLength(0);

            // fill the data
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];

                proposed.Labels.Add(row[0]);

                electricEmissions.Values.Add(row[3]);
                transportationEmissions.Values.Add(row[4]);
                industrialEmissions.Values.Add(row[5]);
                proposed.Values.Add(row[6]);
                allowed.Values.Add(row[7]);
            }
        }

        private Bitmap GetCountrlyFlagImage(string countryFlag)
        {
            return NResourceHelper.BitmapFromResource(this.GetType(), countryFlag, "Nevron.Examples.Chart.WinForm.Resources");
        }

        private DataTable CreateDataTable()
        {
            DataTable table = new DataTable();

            DataColumnCollection cols = table.Columns;
            DataRowCollection rows = table.Rows;

            cols.Add("Country", typeof(string));
            cols.Add("Longitude", typeof(double));
            cols.Add("Latitude", typeof(double));
            cols.Add("2005 Electric", typeof(double));
            cols.Add("2005 Transport", typeof(double));
            cols.Add("2005 Industrial", typeof(double));
            cols.Add("ProposedCap", typeof(double));
            cols.Add("AllowedCap", typeof(double));

            rows.Add("Austria <br/> <img size = '40, 20' alias ='Austria' />", 14.3, 47.3, 18.5, 10.1, 4.8, 25.2, 22.8);
            rows.Add("Finland <br/> <img size = '40, 20' alias ='Finland' />", 20.0, 63.0, 16.9, 9.5, 6.7, 39.6, 37.6);
            rows.Add("France <br/> <img size = '40, 20' alias ='France' />", 4.0, 46.0, 55.8, 38.1, 37.4, 132.8, 132.8);
            rows.Add("Germany <br/> <img size = '40, 20' alias ='Germany' />", 10.5, 50.5, 212.4, 140.4, 121.2, 482, 453.1);
            rows.Add("Greece <br/> <img size = '40, 20' alias ='Greece' />", 22.5, 39.9, 30.7, 23, 17.6, 75.5, 69.1);
            rows.Add("Italy <br/> <img size = '40, 20' alias ='Italy' />", 12.0, 43.0, 98.9, 69.7, 56.9, 209, 195.8);
            rows.Add("Poland <br/> <img size = '40, 20' alias ='Poland' />", 17.3, 51.8, 101.3, 64.2, 37.6, 284.6, 208.5);
            rows.Add("Spain <br/> <img size = '40, 20' alias ='Spain' />", -3.0, 40.0, 97.1, 52.8, 33, 152.7, 152.3);
            rows.Add("Sweden <br/> <img size = '40, 20' alias ='Sweden' />", 13.3, 62.0, 9.2, 6.1, 4, 25.2, 22.8);
            rows.Add("UK <br/> <img size = '40, 20' alias ='UK' />", 1.2, 52.0, 114.4, 71.3, 56.7, 246.2, 246.2);

            return table;
        }
	}
}
