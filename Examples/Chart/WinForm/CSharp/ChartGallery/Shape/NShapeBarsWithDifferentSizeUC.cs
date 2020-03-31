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
	public class NShapeBarsWithDifferentSizeUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NShapeSeries m_Shape;
		private Nevron.UI.WinForm.Controls.NButton Bar1FillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton Bar2FillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton Bar3FillStyleButton;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox StyleCombo;
		private System.ComponentModel.Container components = null;

		public NShapeBarsWithDifferentSizeUC()
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
			this.Bar1FillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.Bar2FillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.Bar3FillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.StyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// Bar1FillStyleButton
			// 
			this.Bar1FillStyleButton.Location = new System.Drawing.Point(5, 9);
			this.Bar1FillStyleButton.Name = "Bar1FillStyleButton";
			this.Bar1FillStyleButton.Size = new System.Drawing.Size(170, 26);
			this.Bar1FillStyleButton.TabIndex = 0;
			this.Bar1FillStyleButton.Text = "Bar1 Fill Style...";
			this.Bar1FillStyleButton.Click += new System.EventHandler(this.Bar1FillStyleButton_Click);
			// 
			// Bar2FillStyleButton
			// 
			this.Bar2FillStyleButton.Location = new System.Drawing.Point(5, 40);
			this.Bar2FillStyleButton.Name = "Bar2FillStyleButton";
			this.Bar2FillStyleButton.Size = new System.Drawing.Size(170, 26);
			this.Bar2FillStyleButton.TabIndex = 1;
			this.Bar2FillStyleButton.Text = "Bar2 Fill Style...";
			this.Bar2FillStyleButton.Click += new System.EventHandler(this.Bar2FillStyleButton_Click);
			// 
			// Bar3FillStyleButton
			// 
			this.Bar3FillStyleButton.Location = new System.Drawing.Point(5, 71);
			this.Bar3FillStyleButton.Name = "Bar3FillStyleButton";
			this.Bar3FillStyleButton.Size = new System.Drawing.Size(170, 26);
			this.Bar3FillStyleButton.TabIndex = 2;
			this.Bar3FillStyleButton.Text = "Bar3 Fill Style...";
			this.Bar3FillStyleButton.Click += new System.EventHandler(this.Bar3FillStyleButton_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 114);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(170, 18);
			this.label1.TabIndex = 3;
			this.label1.Text = "Bars Shape:";
			// 
			// StyleCombo
			// 
			this.StyleCombo.ListProperties.CheckBoxDataMember = "";
			this.StyleCombo.ListProperties.DataSource = null;
			this.StyleCombo.ListProperties.DisplayMember = "";
			this.StyleCombo.Location = new System.Drawing.Point(5, 132);
			this.StyleCombo.Name = "StyleCombo";
			this.StyleCombo.Size = new System.Drawing.Size(170, 21);
			this.StyleCombo.TabIndex = 4;
			this.StyleCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			// 
			// NShapeBarsWithDifferentSizeUC
			// 
			this.Controls.Add(this.StyleCombo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Bar3FillStyleButton);
			this.Controls.Add(this.Bar2FillStyleButton);
			this.Controls.Add(this.Bar1FillStyleButton);
			this.Name = "NShapeBarsWithDifferentSizeUC";
			this.Size = new System.Drawing.Size(180, 177);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Bars with different X and Z sizes");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Axis(StandardAxis.Depth).Visible = false;
            m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

            // add interlaced stripe 
            NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            linearScale.StripStyles.Add(stripStyle);
            m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;

			// create the shape series
			m_Shape = (NShapeSeries)m_Chart.Series.Add(SeriesType.Shape);			

			// show information about the data points in the legend
			m_Shape.Legend.Mode = SeriesLegendMode.DataPoints; 

			// show the Y size and label in the legend
			m_Shape.Legend.Format = "<ysize> <label>"; 

			// show the Y size and label in the data point labels
			m_Shape.DataLabelStyle.Format = "<ysize> <label>"; 

			// use default category positions
			m_Shape.UseXValues = false;
			m_Shape.UseZValues = false;

			// add the bars
			// add Bar1
			m_Shape.AddDataPoint(new NShapeDataPoint(
				10,		// Y center of bar -> half its Y size
				0,		// X position - not used since UseXValue is set to false
				0,		// Z position - not used since UseZValue is set to false
				0.5,	// X size - half category in width
				20,		// Y size of bar
				0.66,	// Z size - 2 thirds of series depth
				"Bar1"	// label
				));

			// add Bar2
			m_Shape.AddDataPoint(new NShapeDataPoint(
				20,		// Y center of bar -> half its Y size
				0,		// X position - not used since UseXValue is set to false
				0,		// Z position - not used since UseZValue is set to false
				0.33,	// X size - approximately 1 third of category width
				40,		// Y size of bar
				0.33,	// Z size - 1 third of series depth
				"Bar2"	// label
				));

			// add Bar3
			m_Shape.AddDataPoint(new NShapeDataPoint(
				15,		// Y center of bar -> half its Y size
				0,		// X position - not used since UseXValue is set to false
				0,		// Z position - not used since UseZValue is set to false
				0.5,	// X size - half category width
				30,		// Y size of bar
				0.5,	// Z size - half series depth
				"Bar3"	// label)
            ));

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			// init form controls
			StyleCombo.FillFromEnum(typeof(BarShape));
			StyleCombo.SelectedIndex = 0;
		}

		private void Bar1FillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult = null;

			if(NFillStyleTypeEditor.Edit((NFillStyle)m_Shape.FillStyles[0], out fillStyleResult))
			{
				m_Shape.FillStyles[0] = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void Bar2FillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult = null;

			if(NFillStyleTypeEditor.Edit((NFillStyle)m_Shape.FillStyles[1], out fillStyleResult))
			{
				m_Shape.FillStyles[1] = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void Bar3FillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult = null;

			if(NFillStyleTypeEditor.Edit((NFillStyle)m_Shape.FillStyles[2], out fillStyleResult))
			{
				m_Shape.FillStyles[2] = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void StyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Shape.Shape = (BarShape)StyleCombo.SelectedIndex;
			nChartControl1.Refresh();
		}
	}
}