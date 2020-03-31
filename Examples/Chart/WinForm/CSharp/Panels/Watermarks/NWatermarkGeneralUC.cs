using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NWatermarkGeneralUC : NExampleBaseUC
	{
		private NDockPanel m_ContentPanel;
		private NLabel m_ReviewLabel;
		
		private Nevron.UI.WinForm.Controls.NHScrollBar TransparencyScrollBar;
		private System.Windows.Forms.Label label3;
		private System.ComponentModel.Container components = null;

		public NWatermarkGeneralUC()
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
			this.TransparencyScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// TransparencyScrollBar
			// 
			this.TransparencyScrollBar.Location = new System.Drawing.Point(7, 36);
			this.TransparencyScrollBar.Maximum = 110;
			this.TransparencyScrollBar.MinimumSize = new System.Drawing.Size(32, 16);
			this.TransparencyScrollBar.Name = "TransparencyScrollBar";
			this.TransparencyScrollBar.Size = new System.Drawing.Size(164, 16);
			this.TransparencyScrollBar.TabIndex = 1;
			this.TransparencyScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.TransparencyScrollBar_Scroll);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(155, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Transparency:";
			// 
			// NWatermarkGeneralUC
			// 
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TransparencyScrollBar);
			this.Name = "NWatermarkGeneralUC";
			this.Size = new System.Drawing.Size(180, 594);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			Nevron.UI.WinForm.Controls.NPalette palette = NUIManager.Palette;

			// remove all default panels
			nChartControl1.Panels.Clear();

			NLabel header = new NLabel("Watermarks");
			header.DockMode = PanelDockMode.Top;
			header.Padding = new NMarginsL(0, 10, 0, 10);
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			header.TextStyle.FillStyle = new NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Horizontal, GradientVariant.Variant1, Color.DarkKhaki, Color.White);
			header.ContentAlignment = ContentAlignment.BottomLeft;
			header.BackgroundFillStyle = new NGradientFillStyle(Color.White, Color.Black);
			nChartControl1.Panels.Add(header);

			// create the content panel (review + preview panels)
			m_ContentPanel = new NDockPanel();
			m_ContentPanel.DockMode = PanelDockMode.Fill;
			m_ContentPanel.BackgroundFillStyle = new NGradientFillStyle(Color.Black, Color.White);

			// create preview panels
			m_ContentPanel.ChildPanels.Add(CreateConceptCarPreviewPanel());

			// cretae review panel
			m_ContentPanel.ChildPanels.Add(CreateConceptCarReviewPanel());
			nChartControl1.Panels.Add(m_ContentPanel);
			nChartControl1.MouseDown += new MouseEventHandler(ChartControl_OnMouseDown);
			nChartControl1.MouseMove += new MouseEventHandler(ChartControl_OnMouseMove);

			TransparencyScrollBar.Maximum = 110;
			TransparencyScrollBar.Value = 50;
		}

		private NDockPanel CreateConceptCarPreviewPanel()
		{
			NDockPanel conceptCarPreviewPanel = new NDockPanel();
			conceptCarPreviewPanel.DockMode = PanelDockMode.Left;
			conceptCarPreviewPanel.Size = new NSizeL(new NLength(30, NRelativeUnit.ParentPercentage), new NLength(100, NRelativeUnit.ParentPercentage));

			CarData[] cars = new CarData[]
			{
				new CarData("ConceptCar1.png", "Sebastian Calamari", new double[]{ 60, 42, 76, 41 }),
				new CarData("ConceptCar2.png", "Oliver Dang", new double[]{ 40, 52, 46, 81 }),
				new CarData("ConceptCar3.png", "Zoran Sirotic", new double[]{ 76, 66, 24, 65 })
			};

			for (int i = 0; i < cars.Length; i++)
			{
				CreateConceptCarPanels(conceptCarPreviewPanel, cars[i]);
			}

			return conceptCarPreviewPanel;
		}
		private NDockPanel CreateConceptCarReviewPanel()
		{
			NDockPanel dockPanel = new NDockPanel();
			dockPanel.DockMode = PanelDockMode.Fill;

			m_ReviewLabel = new NLabel("Select concept car to review");
			m_ReviewLabel.DockMode = PanelDockMode.Top;
			m_ReviewLabel.TextStyle.ShadowStyle.Type = ShadowType.Solid;
			m_ReviewLabel.TextStyle.FontStyle = new NFontStyle("Times New Roman", 20, FontStyle.Italic);
			m_ReviewLabel.TextStyle.FillStyle = new NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Horizontal, GradientVariant.Variant1, Color.DarkKhaki, Color.White);
			m_ReviewLabel.BoundsMode = BoundsMode.None;
			m_ReviewLabel.ContentAlignment = ContentAlignment.MiddleCenter;
			m_ReviewLabel.UseAutomaticSize = false;
			m_ReviewLabel.Size = new NSizeL(
				new NLength(100, NRelativeUnit.ParentPercentage),
				new NLength(10, NRelativeUnit.ParentPercentage));
			dockPanel.ChildPanels.Add(m_ReviewLabel);

			// setup chart
			NChart chart = new NCartesianChart();
			chart.Enable3D = true;
			chart.DockMode = PanelDockMode.Fill;
			chart.BoundsMode = BoundsMode.Fit;
			chart.Padding = new NMarginsL(20, 20, 20, 20);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);

			chart.Axis(StandardAxis.Depth).Visible = false;

			NOrdinalScaleConfigurator scaleX = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleX.AutoLabels = false;
			scaleX.Labels.Add("Design");
			scaleX.Labels.Add("Functionality");
			scaleX.Labels.Add("Price");
			scaleX.Labels.Add("Speed");

			NBarSeries bar = new NBarSeries();
			chart.Series.Add(bar);
			bar.BarShape = BarShape.SmoothEdgeBar;
			bar.DataLabelStyle.Format = "<value>";
			bar.Values.AddRange(new double[] { 0, 0, 0, 0 });

            // apply predefined style sheet to the pie
            NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.CoolMultiColor).Apply(bar);

			dockPanel.ChildPanels.Add(chart);

			return dockPanel;
		}

		private void CreateConceptCarPanels(NDockPanel parentPanel, CarData car)
		{
			Bitmap conceptImage = NResourceHelper.BitmapFromResource(this.GetType(), car.ImageResourceName, "Nevron.Examples.Chart.WinForm.Resources");

			NLabel label = new NLabel(car.AuthorName);
			label.DockMode = PanelDockMode.Top;
			label.BoundsMode = BoundsMode.Fit;
			label.UseAutomaticSize = true;
			label.Padding = new NMarginsL(10, 0, 0, 0);
			label.TextStyle.FontStyle = new NFontStyle("Times New Roman", 20, FontStyle.Italic);
			label.TextStyle.FillStyle = new NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Horizontal, GradientVariant.Variant1, Color.DarkKhaki, Color.White);
            parentPanel.ChildPanels.Add(label);

			NWatermark watermark = new NWatermark();
			watermark.FillStyle = new NImageFillStyle(conceptImage);
			watermark.DockMode = PanelDockMode.Top;
            watermark.UseAutomaticSize = true;
			watermark.Padding = new NMarginsL(10, 0, 0, 0);
			watermark.Tag = car;
            parentPanel.ChildPanels.Add(watermark);
		}
		private bool SetWatermarkTransparency(byte alpha)
		{
			bool alphaChanged = false;

			for (int i = 0; i < nChartControl1.Watermarks.Count; i++)
			{
				NWatermark watermark = (NWatermark)nChartControl1.Watermarks[i];

				if (watermark.Tag != null)
				{
					NImageFillStyle imageFillStyle = watermark.FillStyle as NImageFillStyle;

					if (imageFillStyle != null)
					{
						if (imageFillStyle.Alpha != alpha)
						{
							imageFillStyle.Alpha = alpha;
							alphaChanged = true;
						}
					}
				}
			}

			return alphaChanged;
		}

		private void ChartControl_OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			NHitTestResult result = nChartControl1.HitTest(e.X, e.Y);

			NWatermark watermark = result.Object as NWatermark;
			if (watermark == null)
				return;

			CarData car = watermark.Tag as CarData;
			if (car == null)
				return;

			m_ReviewLabel.Text = "Concept car from " + car.AuthorName;

			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];
			series.Values.Clear();
			series.Values.AddRange(car.Values);

			nChartControl1.Refresh();
		}
		private void ChartControl_OnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (nChartControl1.Controller.ActiveTool != null)
				return;

			NHitTestResult result = nChartControl1.HitTest(e.X, e.Y);
			NWatermark watermark = result.Object as NWatermark;

			if (watermark == null || watermark.Tag == null)
			{
				if (SetWatermarkTransparency((byte)(TransparencyScrollBar.Value * 255 / 100)))
				{
					nChartControl1.Refresh();
				}
			}
			else
			{
				NImageFillStyle imageFillStyle = (NImageFillStyle)watermark.FillStyle;

				if (imageFillStyle.Alpha != 255)
				{
					SetWatermarkTransparency((byte)(TransparencyScrollBar.Value * 255 / 100));
					imageFillStyle.Alpha = 255;
					nChartControl1.Refresh();
				}
			}
		}
		private void TransparencyScrollBar_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			if (SetWatermarkTransparency((byte)(TransparencyScrollBar.Value * 255 / 100)))
			{
				nChartControl1.Refresh();
			}
		}

		[Serializable]
		class CarData
		{
			internal CarData(string imageResourceName, string authorName, double[] values)
			{
				this.ImageResourceName = imageResourceName;
				this.AuthorName = authorName;
				this.Values = values;
			}

			internal string ImageResourceName;
			internal string AuthorName;
			internal double[] Values;
		}
	}
}
