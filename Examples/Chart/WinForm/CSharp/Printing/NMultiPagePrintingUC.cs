using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NMultiPagePrintingUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NFloatBarSeries m_FloatBar;
		private bool m_Updating;
		private NPrintManager m_PrintManager;

		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NButton PrintPreviewButton;
		private Nevron.UI.WinForm.Controls.NButton PrintButton;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NComboBox VerticalPageSizeComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox HorizontalPageSizeComboBox;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableHorizontalPagingCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableVerticalPagingCheckBox;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NMultiPagePrintingUC()
		{
			m_Updating = true;

			// This call is required by the Windows.Forms Form Designer.
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
			this.PrintPreviewButton = new Nevron.UI.WinForm.Controls.NButton();
			this.PrintButton = new Nevron.UI.WinForm.Controls.NButton();
			this.HorizontalPageSizeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.VerticalPageSizeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.EnableHorizontalPagingCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.EnableVerticalPagingCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Horizontal page size:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PrintPreviewButton
			// 
			this.PrintPreviewButton.Location = new System.Drawing.Point(6, 240);
			this.PrintPreviewButton.Name = "PrintPreviewButton";
			this.PrintPreviewButton.Size = new System.Drawing.Size(168, 23);
			this.PrintPreviewButton.TabIndex = 6;
			this.PrintPreviewButton.Text = "Print Preview...";
			this.PrintPreviewButton.Click += new System.EventHandler(this.PrintPreviewButton_Click);
			// 
			// PrintButton
			// 
			this.PrintButton.Location = new System.Drawing.Point(6, 272);
			this.PrintButton.Name = "PrintButton";
			this.PrintButton.Size = new System.Drawing.Size(168, 23);
			this.PrintButton.TabIndex = 7;
			this.PrintButton.Text = "Print";
			this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
			// 
			// HorizontalPageSizeComboBox
			// 
			this.HorizontalPageSizeComboBox.ListProperties.CheckBoxDataMember = "";
			this.HorizontalPageSizeComboBox.ListProperties.DataSource = null;
			this.HorizontalPageSizeComboBox.ListProperties.DisplayMember = "";
			this.HorizontalPageSizeComboBox.Location = new System.Drawing.Point(6, 56);
			this.HorizontalPageSizeComboBox.Name = "HorizontalPageSizeComboBox";
			this.HorizontalPageSizeComboBox.Size = new System.Drawing.Size(168, 21);
			this.HorizontalPageSizeComboBox.TabIndex = 2;
			this.HorizontalPageSizeComboBox.Text = "comboBox1";
			this.HorizontalPageSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.HorizontalPageSizeComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 123);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Vertical page size:";
			// 
			// VerticalPageSizeComboBox
			// 
			this.VerticalPageSizeComboBox.ListProperties.CheckBoxDataMember = "";
			this.VerticalPageSizeComboBox.ListProperties.DataSource = null;
			this.VerticalPageSizeComboBox.ListProperties.DisplayMember = "";
			this.VerticalPageSizeComboBox.Location = new System.Drawing.Point(6, 139);
			this.VerticalPageSizeComboBox.Name = "VerticalPageSizeComboBox";
			this.VerticalPageSizeComboBox.Size = new System.Drawing.Size(168, 21);
			this.VerticalPageSizeComboBox.TabIndex = 5;
			this.VerticalPageSizeComboBox.Text = "comboBox1";
			this.VerticalPageSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.VerticalPageSizeComboBox_SelectedIndexChanged);
			// 
			// EnableHorizontalPagingCheckBox
			// 
			this.EnableHorizontalPagingCheckBox.ButtonProperties.BorderOffset = 2;
			this.EnableHorizontalPagingCheckBox.Location = new System.Drawing.Point(6, 16);
			this.EnableHorizontalPagingCheckBox.Name = "EnableHorizontalPagingCheckBox";
			this.EnableHorizontalPagingCheckBox.Size = new System.Drawing.Size(168, 24);
			this.EnableHorizontalPagingCheckBox.TabIndex = 0;
			this.EnableHorizontalPagingCheckBox.Text = "Enable horizontal paging";
			this.EnableHorizontalPagingCheckBox.CheckedChanged += new System.EventHandler(this.EnableHorizontalPagingCheckBox_CheckedChanged);
			// 
			// EnableVerticalPagingCheckBox
			// 
			this.EnableVerticalPagingCheckBox.ButtonProperties.BorderOffset = 2;
			this.EnableVerticalPagingCheckBox.Location = new System.Drawing.Point(6, 99);
			this.EnableVerticalPagingCheckBox.Name = "EnableVerticalPagingCheckBox";
			this.EnableVerticalPagingCheckBox.Size = new System.Drawing.Size(168, 24);
			this.EnableVerticalPagingCheckBox.TabIndex = 3;
			this.EnableVerticalPagingCheckBox.Text = "Enable vertical paging";
			this.EnableVerticalPagingCheckBox.CheckedChanged += new System.EventHandler(this.EnableVerticalPagingCheckBox_CheckedChanged);
			// 
			// NMultiPagePrintingUC
			// 
			this.Controls.Add(this.EnableVerticalPagingCheckBox);
			this.Controls.Add(this.EnableHorizontalPagingCheckBox);
			this.Controls.Add(this.VerticalPageSizeComboBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.HorizontalPageSizeComboBox);
			this.Controls.Add(this.PrintButton);
			this.Controls.Add(this.PrintPreviewButton);
			this.Controls.Add(this.label1);
			this.Name = "NMultiPagePrintingUC";
			this.Size = new System.Drawing.Size(180, 304);
			this.ResumeLayout(false);

		}
		#endregion

		private void InitChart()
		{
			m_Chart = nChartControl1.Charts[0];

			nChartControl1.Controller.Selection.Add(m_Chart);

			nChartControl1.Controller.Tools.Add(new NDataPanTool());
			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Multi Page Printing");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.MiddleCenter;
			title.DockMargins = new NMarginsL(5, 5, 5, 5);
			title.DockMode = PanelDockMode.Top;

			nChartControl1.Legends[0].Mode = LegendMode.Disabled;

			// setup chart
			m_Chart.BoundsMode = BoundsMode.Stretch;
			m_Chart.DockMode = PanelDockMode.Fill;
			m_Chart.DockMargins = new NMarginsL(15, 20, 30, 20);

			m_Chart.Axis(StandardAxis.PrimaryY).ScrollBar.Visible = true;
			m_Chart.Axis(StandardAxis.PrimaryY).ScrollBar.ResetButton.Visible = false;

			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();
			dateTimeScale.LabelGenerationMode = LabelGenerationMode.Stagger2;
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale;
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true;
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.ResetButton.Visible = false;
			m_Chart.BringToFront();

			// create the float bar series
			m_FloatBar = (NFloatBarSeries)m_Chart.Series.Add(SeriesType.FloatBar);
			m_FloatBar.UseXValues = true;
			m_FloatBar.UseZValues = false;
			m_FloatBar.InflateMargins = true;
			m_FloatBar.DataLabelStyle.Visible = false;

			// bar appearance
			m_FloatBar.BorderStyle.Color = Color.Bisque;
			m_FloatBar.FillStyle = new NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Horizontal, GradientVariant.Variant1, Color.LightGray, Color.DarkBlue);
			m_FloatBar.ShadowStyle.Type = ShadowType.Solid;
			m_FloatBar.ShadowStyle.Color = Color.FromArgb(30, 0, 0, 0);

			m_FloatBar.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			m_FloatBar.EndValues.ValueFormatter = new NNumericValueFormatter("0.00");

			// show the begin end values in the legend
			m_FloatBar.Legend.Format = "<begin> - <end>";
			m_FloatBar.Legend.Mode = SeriesLegendMode.DataPoints;

			GenerateData();

			m_PrintManager = new NPrintManager(nChartControl1.Document);
		}

		private void GenerateData()
		{
			const int nCount = 12;

			m_FloatBar.Values.Clear();
			m_FloatBar.EndValues.Clear();
			m_FloatBar.XValues.Clear();

			// generate Y values
			for(int i = 0; i < nCount; i++)
			{
				double dBeginValue = Random.NextDouble() * 5;
				double dEndValue = dBeginValue + 2 + Random.NextDouble();
				m_FloatBar.Values.Add(dBeginValue);
				m_FloatBar.EndValues.Add(dEndValue);
			}

			// generate X values
			DateTime dt = new DateTime(2005, 5, 24, 11, 0, 0);

			for(int i = 0; i < nCount; i++)
			{
				dt = dt.AddDays(Random.NextDouble() * 15);
				m_FloatBar.XValues.Add(dt);
			}
		}

		public override void Initialize()
		{
			InitChart();

			m_PrintManager.PrintDocumentController = new NAxisPagingDocumentController();

			// update form controls
			HorizontalPageSizeComboBox.Items.Add("3 Months");
			HorizontalPageSizeComboBox.Items.Add("4 Months");
			HorizontalPageSizeComboBox.Items.Add("5 Months");
			HorizontalPageSizeComboBox.SelectedIndex = 0;

			VerticalPageSizeComboBox.Items.Add("3");
			VerticalPageSizeComboBox.Items.Add("4");
			VerticalPageSizeComboBox.Items.Add("5");
			VerticalPageSizeComboBox.SelectedIndex = 0;

			EnableHorizontalPagingCheckBox.Checked = true;
			EnableVerticalPagingCheckBox.Checked = true;
			m_Updating = false;

			UpdateAxisPaging();
		}

		private void UpdateAxisPaging()
		{
			if (m_Updating)
				return;

			NAxis axis;

			axis = m_Chart.Axis(StandardAxis.PrimaryX);
			axis.PagingView = GetHorizontalAxisPagingView();
			axis.PagingView.Enabled = EnableHorizontalPagingCheckBox.Checked;
			HorizontalPageSizeComboBox.Enabled = EnableHorizontalPagingCheckBox.Checked;

			axis = m_Chart.Axis(StandardAxis.PrimaryY);
			axis.PagingView = GetVerticalAxisPagingView();
			axis.PagingView.Enabled = EnableVerticalPagingCheckBox.Checked;
			VerticalPageSizeComboBox.Enabled = EnableVerticalPagingCheckBox.Checked;

			nChartControl1.Refresh();
		}

		private NDateTimeAxisPagingView GetHorizontalAxisPagingView()
		{
			NDateTimeAxisPagingView view = null;
			DateTime dt = new DateTime(2005, 5, 24, 11, 0, 0);

			switch (HorizontalPageSizeComboBox.SelectedIndex)
			{
				case 0:
					view = new NDateTimeAxisPagingView(dt, new NDateTimeSpan(1, NDateTimeUnit.Month));
					break;
				case 1:
					view = new NDateTimeAxisPagingView(dt, new NDateTimeSpan(2, NDateTimeUnit.Month));
					break;
				case 2:
					view = new NDateTimeAxisPagingView(dt, new NDateTimeSpan(3, NDateTimeUnit.Month));
					break;
				default:
					Debug.Assert(false);
					break;
			}

			return view;
		}

		private NNumericAxisPagingView GetVerticalAxisPagingView()
		{
			NNumericAxisPagingView view = null;

			switch (VerticalPageSizeComboBox.SelectedIndex)
			{
				case 0:
					view = new NNumericAxisPagingView(new NRange1DD(0, 3));
					break;
				case 1:
					view = new NNumericAxisPagingView(new NRange1DD(0, 4));
					break;
				case 2:
					view = new NNumericAxisPagingView(new NRange1DD(0, 5));
					break;
				default:
					Debug.Assert(false);
					break;
			}

			return view;
		}

		private void PrintPreviewButton_Click(object sender, System.EventArgs e)
		{
			m_PrintManager.ShowPrintPreview();
		}

		private void PrintButton_Click(object sender, System.EventArgs e)
		{
			m_PrintManager.Print();
		}

		private void HorizontalPageSizeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateAxisPaging();
		}

		private void VerticalPageSizeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateAxisPaging();
		}

		private void EnableVerticalPagingCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateAxisPaging();
		}

		private void EnableHorizontalPagingCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateAxisPaging();
		}
	}
}
