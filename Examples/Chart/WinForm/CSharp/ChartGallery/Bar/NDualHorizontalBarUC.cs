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
	public class NDualHorizontalBarUC : NExampleBaseUC
	{
		private NChart m_ChartFemale;
		private NChart m_ChartMale;
		private NBarSeries m_barF;
		private NBarSeries m_barM;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NComboBox MaleStyleCombo;
		private Nevron.UI.WinForm.Controls.NComboBox FemaleStyleCombo;
		private Nevron.UI.WinForm.Controls.NButton MaleFEButton;
		private Nevron.UI.WinForm.Controls.NButton FemaleFEButton;

		private string[] AgeLabels = new string[]
		{
			"0 - 4",
			"5 - 9",
			"10 - 14",
			"15 - 19",
			"20 - 24",
			"25 - 29",
			"30 - 34",
			"35 - 39",
			"40 - 44",
			"45 - 49",
			"50 - 54",
			"55 - 59",
			"60 - 64",
			"65 - 69",
			"70 - 74",
			"75 - 79",
			"80 +"
		};

		public NDualHorizontalBarUC()
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
			this.MaleStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.FemaleStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.MaleFEButton = new Nevron.UI.WinForm.Controls.NButton();
			this.FemaleFEButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(159, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Male Bar Style:";
			// 
			// MaleStyleCombo
			// 
			this.MaleStyleCombo.ListProperties.CheckBoxDataMember = "";
			this.MaleStyleCombo.ListProperties.DataSource = null;
			this.MaleStyleCombo.ListProperties.DisplayMember = "";
			this.MaleStyleCombo.Location = new System.Drawing.Point(7, 31);
			this.MaleStyleCombo.Name = "MaleStyleCombo";
			this.MaleStyleCombo.Size = new System.Drawing.Size(159, 21);
			this.MaleStyleCombo.TabIndex = 1;
			this.MaleStyleCombo.SelectedIndexChanged += new System.EventHandler(this.MaleStyleCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 65);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(159, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Female Bar Style:";
			// 
			// FemaleStyleCombo
			// 
			this.FemaleStyleCombo.ListProperties.CheckBoxDataMember = "";
			this.FemaleStyleCombo.ListProperties.DataSource = null;
			this.FemaleStyleCombo.ListProperties.DisplayMember = "";
			this.FemaleStyleCombo.Location = new System.Drawing.Point(7, 81);
			this.FemaleStyleCombo.Name = "FemaleStyleCombo";
			this.FemaleStyleCombo.Size = new System.Drawing.Size(159, 21);
			this.FemaleStyleCombo.TabIndex = 3;
			this.FemaleStyleCombo.SelectedIndexChanged += new System.EventHandler(this.FemaleStyleCombo_SelectedIndexChanged);
			// 
			// MaleFEButton
			// 
			this.MaleFEButton.Location = new System.Drawing.Point(7, 118);
			this.MaleFEButton.Name = "MaleFEButton";
			this.MaleFEButton.Size = new System.Drawing.Size(159, 28);
			this.MaleFEButton.TabIndex = 4;
			this.MaleFEButton.Text = "Male Bars Fill Style...";
			this.MaleFEButton.Click += new System.EventHandler(this.MaleFEButton_Click);
			// 
			// FemaleFEButton
			// 
			this.FemaleFEButton.Location = new System.Drawing.Point(7, 159);
			this.FemaleFEButton.Name = "FemaleFEButton";
			this.FemaleFEButton.Size = new System.Drawing.Size(159, 28);
			this.FemaleFEButton.TabIndex = 5;
			this.FemaleFEButton.Text = "Female Bars Fill Style...";
			this.FemaleFEButton.Click += new System.EventHandler(this.FemaleFEButton_Click);
			// 
			// NDualHorizontalBarUC
			// 
			this.Controls.Add(this.FemaleFEButton);
			this.Controls.Add(this.MaleFEButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.FemaleStyleCombo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.MaleStyleCombo);
			this.Name = "NDualHorizontalBarUC";
			this.Size = new System.Drawing.Size(180, 206);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

			// top panel
			NDockPanel topPanel = new NDockPanel();
			topPanel.DockMode = PanelDockMode.Top;
			topPanel.Size = new NSizeL(new NLength(0), new NLength(8, NRelativeUnit.ParentPercentage));

			// bottom panel
			NDockPanel bottomPanel = new NDockPanel();
			bottomPanel.DockMode = PanelDockMode.Bottom;
			bottomPanel.Size = new NSizeL(new NLength(0), new NLength(8, NRelativeUnit.ParentPercentage));

			// left panel
			NDockPanel leftPanel = new NDockPanel();
			leftPanel.DockMode = PanelDockMode.Left;
			leftPanel.Size = new NSizeL(new NLength(47.0f, NRelativeUnit.ParentPercentage), new NLength(0));

			// right panel
			NDockPanel rightPanel = new NDockPanel();
			rightPanel.DockMode = PanelDockMode.Right;
			rightPanel.Size = new NSizeL(new NLength(47.0f, NRelativeUnit.ParentPercentage), new NLength(0));

			// middle panel
			NDockPanel middlePanel = new NDockPanel();
			middlePanel.DockMode = PanelDockMode.Fill;

			// left label panel
			NDockPanel leftLabelPanel = new NDockPanel();
			leftLabelPanel.DockMode = PanelDockMode.Left;
			leftLabelPanel.Size = new NSizeL(new NLength(15, NRelativeUnit.ParentPercentage), new NLength(0));

			// left chart panel
			NDockPanel leftChartPanel = new NDockPanel();
			leftChartPanel.DockMode = PanelDockMode.Fill;

			// right label panel
			NDockPanel rightLabelPanel = new NDockPanel();
			rightLabelPanel.DockMode = PanelDockMode.Right;
			rightLabelPanel.Size = new NSizeL(new NLength(15, NRelativeUnit.ParentPercentage), new NLength(0));

			// right chart panel
			NDockPanel rightChartPanel = new NDockPanel();
			rightChartPanel.DockMode = PanelDockMode.Fill;

			// header label
			NLabel headerLabel = new NLabel("Population structure of New York for 2001");
			headerLabel.ContentAlignment = ContentAlignment.MiddleCenter;
			headerLabel.TextStyle.FontStyle.Name = "Times New Roman";
			headerLabel.TextStyle.FontStyle.Style = FontStyle.Italic;
			headerLabel.BoundsMode = BoundsMode.Fit;
			headerLabel.UseAutomaticSize = false;
			headerLabel.Size = new NSizeL(
				new NLength(70, NRelativeUnit.ParentPercentage),
				new NLength(80, NRelativeUnit.ParentPercentage));
			headerLabel.Location = new NPointL(
				new NLength(50, NRelativeUnit.ParentPercentage),
				new NLength(50, NRelativeUnit.ParentPercentage));

			// footer label
			NLabel footerLabel = new NLabel("Population (in thousands)");
			footerLabel.ContentAlignment = ContentAlignment.MiddleCenter;
            footerLabel.TextStyle.FontStyle.Name = "Times New Roman";
			footerLabel.TextStyle.FontStyle.Style = FontStyle.Italic;
			footerLabel.BoundsMode = BoundsMode.Fit;
			footerLabel.UseAutomaticSize = false;
			footerLabel.Size = new NSizeL(
				new NLength(70, NRelativeUnit.ParentPercentage),
				new NLength(80, NRelativeUnit.ParentPercentage));
			footerLabel.Location = new NPointL(
				new NLength(50, NRelativeUnit.ParentPercentage),
				new NLength(50, NRelativeUnit.ParentPercentage));

			// middle label (vertical)
			NLabel midLabel = new NLabel("Age range");
			midLabel.BoundsMode = BoundsMode.Fit;
			midLabel.ContentAlignment = ContentAlignment.MiddleCenter;
			midLabel.UseAutomaticSize = false;
			midLabel.Location = new NPointL(
				new NLength(50, NRelativeUnit.ParentPercentage),
				new NLength(50, NRelativeUnit.ParentPercentage));
			midLabel.Size = new NSizeL(
				new NLength(50, NRelativeUnit.ParentPercentage),
				new NLength(80, NRelativeUnit.ParentPercentage));
			midLabel.TextStyle.FontStyle = new NFontStyle("Verdana", 12);
			midLabel.TextStyle.BackplaneStyle.Visible = false;
			midLabel.TextStyle.Orientation = 90;

			// label (male)
			NLabel mlabel = new NLabel("Male");
			mlabel.ContentAlignment = ContentAlignment.MiddleCenter;
            mlabel.TextStyle.FontStyle.Name = "Times New Roman";
			mlabel.TextStyle.FontStyle.Style = FontStyle.Italic;
			mlabel.TextStyle.FillStyle = new NColorFillStyle(Blue);
			mlabel.TextStyle.BackplaneStyle.Visible = false;
			mlabel.TextStyle.Orientation = 90;
			mlabel.BoundsMode = BoundsMode.Fit;
			mlabel.UseAutomaticSize = false;
			mlabel.Location = new NPointL(
				new NLength(50, NRelativeUnit.ParentPercentage),
				new NLength(50, NRelativeUnit.ParentPercentage));
			mlabel.Size = new NSizeL(
				new NLength(70, NRelativeUnit.ParentPercentage),
				new NLength(70, NRelativeUnit.ParentPercentage));

			// label (female)
			NLabel flabel = new NLabel("Female");
			flabel.ContentAlignment = ContentAlignment.MiddleCenter;
            flabel.TextStyle.FontStyle.Name = "Times New Roman";
			flabel.TextStyle.FontStyle.Style = FontStyle.Italic;
			flabel.TextStyle.FillStyle = new NColorFillStyle(BeautifulRed);
			flabel.TextStyle.BackplaneStyle.Visible = false;
			flabel.TextStyle.Orientation = 270;
			flabel.BoundsMode = BoundsMode.Fit;
			flabel.UseAutomaticSize = false;
			flabel.Location = new NPointL(
				new NLength(50, NRelativeUnit.ParentPercentage),
				new NLength(50, NRelativeUnit.ParentPercentage));
			flabel.Size = new NSizeL(
				new NLength(70, NRelativeUnit.ParentPercentage),
				new NLength(100, NRelativeUnit.ParentPercentage));

			// create male chart
			m_ChartMale = new NCartesianChart();
			m_ChartMale.BoundsMode = BoundsMode.Stretch;
			m_ChartMale.ContentAlignment  = ContentAlignment.MiddleCenter;
			m_ChartMale.DockMode = PanelDockMode.Fill;
			SetupMaleChart();

			// create female chart
			m_ChartFemale = new NCartesianChart();
			m_ChartFemale.BoundsMode = BoundsMode.Stretch;
			m_ChartFemale.ContentAlignment  = ContentAlignment.MiddleCenter;
			m_ChartFemale.DockMode = PanelDockMode.Fill;
			SetupFemaleChart();

			// arrange panels
			nChartControl1.Panels.Add(topPanel);
			nChartControl1.Panels.Add(bottomPanel);
			nChartControl1.Panels.Add(leftPanel);
			nChartControl1.Panels.Add(rightPanel);
			nChartControl1.Panels.Add(middlePanel);

			leftPanel.ChildPanels.Add(leftLabelPanel);
			leftPanel.ChildPanels.Add(leftChartPanel);
			rightPanel.ChildPanels.Add(rightLabelPanel);
			rightPanel.ChildPanels.Add(rightChartPanel);

			topPanel.ChildPanels.Add(headerLabel);
			bottomPanel.ChildPanels.Add(footerLabel);
			middlePanel.ChildPanels.Add(midLabel);
			leftLabelPanel.ChildPanels.Add(mlabel);
			rightLabelPanel.ChildPanels.Add(flabel);
			leftChartPanel.ChildPanels.Add(m_ChartMale);
			rightChartPanel.ChildPanels.Add(m_ChartFemale);

			FemaleStyleCombo.FillFromEnum(typeof(BarShape));
			FemaleStyleCombo.SelectedIndex = 0;

			MaleStyleCombo.FillFromEnum(typeof(BarShape));
			MaleStyleCombo.SelectedIndex = 0;
		}

		private void SetupFemaleChart()
		{
			// female chart setup
			m_ChartFemale.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalLeft);
			m_ChartFemale.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHorizontalLeft);

			// setup Y axis
			NAxis axisY = m_ChartFemale.Axis(StandardAxis.PrimaryY);
			axisY.ScaleConfigurator.InnerMajorTickStyle.Visible = false;
			axisY.Anchor = new NDockAxisAnchor(AxisDockZone.FrontRight, false, 0, 100);

			// add manual labels to the female chart
			NAxis axisX = m_ChartFemale.Axis(StandardAxis.PrimaryX);
			NOrdinalScaleConfigurator scaleX = axisX.ScaleConfigurator as NOrdinalScaleConfigurator;
			scaleX.Invert = true;
			scaleX.InnerMajorTickStyle.Visible = false;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleX.LabelFitModes = new LabelFitMode[] { LabelFitMode.AutoScale };
			scaleX.AutoLabels = false;
			scaleX.Labels.AddRange(AgeLabels);

			// populate the female chart
			m_barF = (NBarSeries)m_ChartFemale.Series.Add(SeriesType.Bar);
			m_barF.FillStyle = new NGradientFillStyle(BeautifulRed, Color.White);
			m_barF.BorderStyle.Color = BeautifulRed;
			m_barF.DataLabelStyle.Format = "<value>";
			m_barF.DataLabelStyle.VertAlign = VertAlign.Center;
			m_barF.DataLabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 7);
			m_barF.Values.Add(210);// 0 - 4
			m_barF.Values.Add(215);// 5 - 9
			m_barF.Values.Add(219);// 10 - 14
			m_barF.Values.Add(225);// 15 - 19
			m_barF.Values.Add(245);// 20 - 24
			m_barF.Values.Add(289);// 25 - 29
			m_barF.Values.Add(355);// 30 - 34
			m_barF.Values.Add(355);// 35 - 39
			m_barF.Values.Add(380);// 40 - 44
			m_barF.Values.Add(320);// 45 - 49
			m_barF.Values.Add(250);// 50 - 54
			m_barF.Values.Add(190);// 55 - 59
			m_barF.Values.Add(112);// 60 - 64
			m_barF.Values.Add(110);// 65 - 69
			m_barF.Values.Add(90);// 70 - 74
			m_barF.Values.Add(55);// 75 - 79
			m_barF.Values.Add(45);// 80 +
		}

		private void SetupMaleChart()
		{
			// chart setup
			m_ChartMale.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalRight);
			m_ChartMale.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHorizontalRight); 

			// setup Y axis
			NAxis axisY = m_ChartMale.Axis(StandardAxis.PrimaryY);
			axisY.ScaleConfigurator.InnerMajorTickStyle.Visible = false;

			// add labels to the male chart X axis
			NAxis axisX = m_ChartMale.Axis(StandardAxis.PrimaryX);
			NOrdinalScaleConfigurator scaleX = axisX.ScaleConfigurator as NOrdinalScaleConfigurator;
			scaleX.InnerMajorTickStyle.Visible = false;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleX.LabelFitModes = new LabelFitMode[] { LabelFitMode.AutoScale };
			scaleX.AutoLabels = false;
			scaleX.Labels.AddRange(AgeLabels);

			// populate the male chart
			m_barM = (NBarSeries)m_ChartMale.Series.Add(SeriesType.Bar);
			m_barM.FillStyle = new NGradientFillStyle(Blue, Color.White);
			m_barM.BorderStyle.Color = Blue;
			m_barM.DataLabelStyle.Format = "<value>";
			m_barM.DataLabelStyle.VertAlign = VertAlign.Center;
			m_barM.DataLabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 7);
			m_barM.Values.Add(200);// 0 - 4
			m_barM.Values.Add(210);// 5 - 9
			m_barM.Values.Add(205);// 10 - 14
			m_barM.Values.Add(225);// 15 - 19
			m_barM.Values.Add(250);// 20 - 24
			m_barM.Values.Add(290);// 25 - 29
			m_barM.Values.Add(340);// 30 - 34
			m_barM.Values.Add(340);// 35 - 39
			m_barM.Values.Add(370);// 40 - 44
			m_barM.Values.Add(310);// 45 - 49
			m_barM.Values.Add(260);// 50 - 54
			m_barM.Values.Add(180);// 55 - 59
			m_barM.Values.Add(120);// 60 - 64
			m_barM.Values.Add(115);// 65 - 69
			m_barM.Values.Add(100);// 70 - 74
			m_barM.Values.Add(50);// 75 - 79
			m_barM.Values.Add(35);// 80 +
		}

		private void MaleFEButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_barM.FillStyle, out fillStyleResult))
			{
				m_barM.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void FemaleFEButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_barF.FillStyle, out fillStyleResult))
			{
				m_barF.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void MaleStyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_barM.BarShape = (BarShape)MaleStyleCombo.SelectedIndex;
			nChartControl1.Refresh();
		}
		private void FemaleStyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_barF.BarShape = (BarShape)FemaleStyleCombo.SelectedIndex;
			nChartControl1.Refresh();
		}
	}
}