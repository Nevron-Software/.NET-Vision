using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Nevron.Serialization;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NSerializingChartObjectsUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NComboBox SerializationContentComboBox;
		private Nevron.UI.WinForm.Controls.NButton ModifyFirstChartDataButton;
		private Nevron.UI.WinForm.Controls.NButton LoadSecondChartButton;
		private NChart m_Chart1;
		private NChart m_Chart2;
		private Nevron.UI.WinForm.Controls.NButton ModifySecondChartDataButton;
		private Nevron.UI.WinForm.Controls.NButton ModifySecondChartAppearanceButton;
		private Nevron.UI.WinForm.Controls.NButton ModifyFirstChartAppearanceButton;
		private System.ComponentModel.Container components = null;

		public NSerializingChartObjectsUC()
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
			this.label2 = new System.Windows.Forms.Label();
			this.SerializationContentComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.LoadSecondChartButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ModifyFirstChartDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ModifyFirstChartAppearanceButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ModifySecondChartAppearanceButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ModifySecondChartDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(176, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "Serialization content:";
			// 
			// SerializationContentComboBox
			// 
			this.SerializationContentComboBox.Location = new System.Drawing.Point(8, 96);
			this.SerializationContentComboBox.Name = "SerializationContentComboBox";
			this.SerializationContentComboBox.Size = new System.Drawing.Size(176, 21);
			this.SerializationContentComboBox.TabIndex = 3;
			// 
			// LoadSecondChartButton
			// 
			this.LoadSecondChartButton.Location = new System.Drawing.Point(8, 120);
			this.LoadSecondChartButton.Name = "LoadSecondChartButton";
			this.LoadSecondChartButton.Size = new System.Drawing.Size(176, 32);
			this.LoadSecondChartButton.TabIndex = 4;
			this.LoadSecondChartButton.Text = "Load second chart from first chart";
			this.LoadSecondChartButton.Click += new System.EventHandler(this.LoadSecondChartButton_Click);
			// 
			// ModifyFirstChartDataButton
			// 
			this.ModifyFirstChartDataButton.Location = new System.Drawing.Point(8, 40);
			this.ModifyFirstChartDataButton.Name = "ModifyFirstChartDataButton";
			this.ModifyFirstChartDataButton.Size = new System.Drawing.Size(176, 23);
			this.ModifyFirstChartDataButton.TabIndex = 1;
			this.ModifyFirstChartDataButton.Text = "Modify first chart data";
			this.ModifyFirstChartDataButton.Click += new System.EventHandler(this.ModifyFirstChartDataButton_Click);
			// 
			// ModifyFirstChartAppearanceButton
			// 
			this.ModifyFirstChartAppearanceButton.Location = new System.Drawing.Point(8, 8);
			this.ModifyFirstChartAppearanceButton.Name = "ModifyFirstChartAppearanceButton";
			this.ModifyFirstChartAppearanceButton.Size = new System.Drawing.Size(176, 23);
			this.ModifyFirstChartAppearanceButton.TabIndex = 0;
			this.ModifyFirstChartAppearanceButton.Text = "Modify first chart appearance";
			this.ModifyFirstChartAppearanceButton.Click += new System.EventHandler(this.ModifyFirstChartAppearanceButton_Click);
			// 
			// ModifySecondChartAppearanceButton
			// 
			this.ModifySecondChartAppearanceButton.Location = new System.Drawing.Point(8, 208);
			this.ModifySecondChartAppearanceButton.Name = "ModifySecondChartAppearanceButton";
			this.ModifySecondChartAppearanceButton.Size = new System.Drawing.Size(176, 23);
			this.ModifySecondChartAppearanceButton.TabIndex = 6;
			this.ModifySecondChartAppearanceButton.Text = "Modify second chart appearance";
			this.ModifySecondChartAppearanceButton.Click += new System.EventHandler(this.ModifySecondChartAppearanceButton_Click);
			// 
			// ModifySecondChartDataButton
			// 
			this.ModifySecondChartDataButton.Location = new System.Drawing.Point(8, 176);
			this.ModifySecondChartDataButton.Name = "ModifySecondChartDataButton";
			this.ModifySecondChartDataButton.Size = new System.Drawing.Size(176, 23);
			this.ModifySecondChartDataButton.TabIndex = 5;
			this.ModifySecondChartDataButton.Text = "Modify second chart data";
			this.ModifySecondChartDataButton.Click += new System.EventHandler(this.ModifySecondChartDataButton_Click);
			// 
			// NSerializingChartObjects
			// 
			this.Controls.Add(this.ModifySecondChartAppearanceButton);
			this.Controls.Add(this.ModifySecondChartDataButton);
			this.Controls.Add(this.ModifyFirstChartAppearanceButton);
			this.Controls.Add(this.ModifyFirstChartDataButton);
			this.Controls.Add(this.LoadSecondChartButton);
			this.Controls.Add(this.SerializationContentComboBox);
			this.Controls.Add(this.label2);
			this.Name = "NSerializingChartObjects";
			this.Size = new System.Drawing.Size(192, 359);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Using serialization to clone Chart object");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup the chart
			m_Chart1 = nChartControl1.Charts[0];
			m_Chart1.Enable3D = true;
			m_Chart1.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf); 
			m_Chart1.Axis(StandardAxis.Depth).Visible = false;

			m_Chart1.Location = new NPointL(new NLength(10, NRelativeUnit.RootPercentage),
				new NLength(10, NRelativeUnit.RootPercentage));

			m_Chart1.Size = new NSizeL(new NLength(80, NRelativeUnit.RootPercentage),
				new NLength(35, NRelativeUnit.RootPercentage));

			m_Chart1.BoundsMode = BoundsMode.Fit;

			// add the first bar
			NBarSeries bar1 = (NBarSeries)m_Chart1.Series.Add(SeriesType.Bar);
			bar1.Name = "Bar1";
			bar1.MultiBarMode = MultiBarMode.Series;
			bar1.DataLabelStyle.Format = "<value>";

			// add the second bar
			NBarSeries bar2 = (NBarSeries)m_Chart1.Series.Add(SeriesType.Bar);
			bar2.Name = "Bar2";
			bar2.MultiBarMode = MultiBarMode.Clustered;
			bar2.DataLabelStyle.Format = "<value>";

			// add the third bar
			NBarSeries bar3 = (NBarSeries)m_Chart1.Series.Add(SeriesType.Bar);
			bar3.Name = "Bar2";
			bar3.MultiBarMode = MultiBarMode.Stacked;
			bar3.DataLabelStyle.Format = "<value>";

			bar2.DataLabelStyle.VertAlign = VertAlign.Center;
			bar3.DataLabelStyle.VertAlign = VertAlign.Center;

			// fill with random data
			bar1.Values.FillRandomRange(Random, 5, 10, 100);
			bar2.Values.FillRandomRange(Random, 5, 10, 500);
			bar3.Values.FillRandomRange(Random, 5, 10, 500);

			// change the color of the bars
			bar1.FillStyle = new NColorFillStyle(Color.PaleVioletRed);
			bar2.FillStyle = new NColorFillStyle(Color.CornflowerBlue);
			bar3.FillStyle = new NColorFillStyle(Color.LimeGreen);

			// init form controls
			SerializationContentComboBox.Items.Add("All");
			SerializationContentComboBox.Items.Add("Data");
			SerializationContentComboBox.Items.Add("Appearance");
			SerializationContentComboBox.SelectedIndex = 0;

			// copy the first chart state into the second chart
			LoadSecondChartButton_Click(null, null);
		}

		private void ModifyFirstChartDataButton_Click(object sender, System.EventArgs e)
		{
			foreach (NBarSeries bar in m_Chart1.Series)
			{
				bar.Values.FillRandomRange(Random, 5, -100, 100);
			}

			nChartControl1.Refresh();
		}

		private void ModifyFirstChartAppearanceButton_Click(object sender, System.EventArgs e)
		{
			foreach (NBarSeries bar in m_Chart1.Series)
			{
				bar.FillStyle = new NColorFillStyle(RandomColor());
			}

			nChartControl1.Refresh();
		}

		private void ModifySecondChartDataButton_Click(object sender, System.EventArgs e)
		{
			foreach (NBarSeries bar in m_Chart2.Series)
			{
				bar.Values.FillRandomRange(Random, 5, -100, 100);
			}

			nChartControl1.Refresh();		
		}

		private void ModifySecondChartAppearanceButton_Click(object sender, System.EventArgs e)
		{
			foreach (NBarSeries bar in m_Chart2.Series)
			{
				bar.FillStyle = new NColorFillStyle(RandomColor());
			}

			nChartControl1.Refresh();
		}

		private void LoadSecondChartButton_Click(object sender, System.EventArgs e)
		{
//			MemoryStream stream = new MemoryStream();
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
			
			if (m_Chart2 != null)
			{
				nChartControl1.Panels.Remove(m_Chart2);
			}

			// clone the first chart
			m_Chart2 = (NChart)(nChartControl1.Charts[0].CloneWithNewUniqueId(null));

			// filter elements
			m_Chart2 = (NChart)nChartControl1.Serializer.DeepClone(m_Chart2, filter);
			m_Chart2.Location = new NPointL(
				new NLength(10, NRelativeUnit.RootPercentage),
				new NLength(55, NRelativeUnit.RootPercentage));

			// add to panels collection
			nChartControl1.Panels.Add(m_Chart2);
			nChartControl1.Refresh();
		}
	}
}
