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
using Nevron.Dom;
using Nevron.Chart.WinForm;
using System.Collections.Generic;
using Nevron.Chart.Windows;
using Nevron.Chart.View;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NCustomToolUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBarSeries m_Bar1;
		private NBarSeries m_Bar2;
		private System.ComponentModel.Container components = null;

		public NCustomToolUC()
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
			this.SuspendLayout();
			// 
			// NCustomToolUC
			// 
			this.Name = "NCustomToolUC";
			this.Size = new System.Drawing.Size(180, 358);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Custom Interactivity Tool");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlace stripe
            NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// add a bar series
			m_Bar1 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar1.Name = "Bar1";
			m_Bar1.MultiBarMode = MultiBarMode.Series;
			m_Bar1.DataLabelStyle.Format = "<value>";

			// add another bar series
			m_Bar2 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar2.Name = "Bar2";
			m_Bar2.MultiBarMode = MultiBarMode.Clustered;
			m_Bar2.DataLabelStyle.Format = "<value>";

			// fill with random data
			m_Bar1.Values.FillRandomRange(Random, 5, 10, 100);
			m_Bar2.Values.FillRandomRange(Random, 5, 10, 500);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			nChartControl1.Controller.Tools.Add(new MyCustomTool());
		}

		[Serializable]
		public class MyCustomTool : NTool
		{
			#region Construcotrs

			public MyCustomTool()
			{
				m_MaxTransparencyPercent = 90;
				m_SeriesToPercents = new Dictionary<NSeries, float>();
			}

			#endregion

			#region Event handlers

			void OnTimerTick(object sender, EventArgs e)
			{
				NView view = GetView();

				if (view == null || view.Document == null)
					return;

				bool alphaChanged = false;

				foreach (NSeries series in m_SeriesToPercents.Keys)
				{
					if ((m_SelectedSeries == null) || (series == m_SelectedSeries))
					{
						//selected series or no selection.
						alphaChanged = UpdateAlpha(series, -m_TransparencyStep) || alphaChanged;
					}
					else
					{
						//not selected series when there is a selected series.
						alphaChanged = UpdateAlpha(series, m_TransparencyStep) || alphaChanged;
					}
				}

				if (alphaChanged)
				{
					this.Repaint();
				}
			}

			#endregion

			#region Overrides

			public override void UpdateReferences(INReferenceProvider provider)
			{
				base.UpdateReferences(provider);

				if (provider == null)
				{
					if (m_Timer != null)
					{
						m_Timer.Stop();
						m_Timer.Tick -= new EventHandler(OnTimerTick);
						m_Timer.Dispose();
						m_Timer = null;
					}
				}
				else
				{
					m_Timer = new Timer();
					m_Timer.Interval = 50;
					m_Timer.Tick += new EventHandler(OnTimerTick);
					m_Timer.Start();

					m_SeriesToPercents.Clear();

					NNodeTreeEnumerator enumerator = new NNodeTreeEnumerator(GetView().Document, TreeTraversalOrder.DepthFirstPreOrder);
					while (enumerator.MoveNext())
					{
						NSeries series = enumerator.Current as NSeries;
						if (series != null)
						{
							m_SeriesToPercents.Add(series, GetTransparencyPercent(series.FillStyle));
						}
					}
				}
			}

			public override void OnMouseMove(object sender, NMouseEventArgs e)
			{
				m_SelectedSeries = null;

				NHitTestCacheService hitTestService = GetView().GetServiceOfType(typeof(NHitTestCacheService)) as NHitTestCacheService;

				if (hitTestService == null)
					return;

				INNode node = hitTestService.HitTest(new NPointF(e.X, e.Y));

				if (node == null)
					return;

				NDataPoint dataPoint = node as NDataPoint;
				if (dataPoint != null)
				{
					m_SelectedSeries = dataPoint.ParentNode as NSeries;
				}
			}

			#endregion

			#region Implementation
			 
			/// <summary>
			/// Changes the transparency percent for a series FillStyle with a specified step.
			/// </summary>
			/// <param name="series"></param>
			/// <param name="step"></param>
			private bool UpdateAlpha(NSeries series, int step)
			{
				float curPercent = Math.Min(m_MaxTransparencyPercent, GetTransparencyPercent(series.FillStyle));
				float newPercent = curPercent + step;
				float orgPercent = m_SeriesToPercents[series];

				// clamp
				newPercent = Math.Max(orgPercent, newPercent);
				newPercent = Math.Min(m_MaxTransparencyPercent, newPercent);

				series.FillStyle.SetTransparencyPercent(newPercent);

				return newPercent != curPercent;
			}

			/// <summary>
			/// Gets the transparency percent depending on the type of the fillStyle.
			/// </summary>
			/// <param name="fillStyle"></param>
			/// <returns>The transparency percent.</returns>
			private float GetTransparencyPercent(NFillStyle fillStyle)
			{
				if (fillStyle == null)
					return 0;

				if (fillStyle is NColorFillStyle)
				{
					byte alpha = ((NColorFillStyle)fillStyle).Color.A;
					return PercentFromAlpha(alpha);
				}

				if (fillStyle is NGradientFillStyle)
				{
					byte alphaBeginColor = ((NGradientFillStyle)fillStyle).BeginColor.A;
					byte alphaEndColor = ((NGradientFillStyle)fillStyle).EndColor.A;
					return Math.Max(alphaBeginColor, alphaEndColor);
				}

				if (fillStyle is NHatchFillStyle)
				{
					byte foregroundAlpha = ((NHatchFillStyle)fillStyle).ForegroundColor.A;
					byte backgroundAlpha = ((NHatchFillStyle)fillStyle).BackgroundColor.A;
					return Math.Max(foregroundAlpha, backgroundAlpha);
				}

				if (fillStyle is NImageFillStyle)
				{
					byte alpha = ((NImageFillStyle)fillStyle).Alpha;
					return PercentFromAlpha(alpha);
				}

				if (fillStyle is NAdvancedGradientFillStyle)
				{
					byte alpha = ((NAdvancedGradientFillStyle)fillStyle).BackgroundColor.A;
					return PercentFromAlpha(alpha);
				}
				return 0;
			}

			private static float PercentFromAlpha(byte alpha)
			{
				return 100 - (alpha * 100 / 255);
			}

			private static byte AlphaFromPercent(float percent)
			{
				if (percent > 100)
				{
					percent = 100;
				}
				if (percent < 0)
				{
					percent = 0;
				}

				return (byte)(percent * 255 / 100);
			}

			#endregion

			#region Properties

			public float MaxTransparencyPercent
			{
				get
				{
					return m_MaxTransparencyPercent;
				}
				set
				{
					if (value > 100)
					{
						m_MaxTransparencyPercent = 100;
						return;
					}

					if (value < 0)
					{
						m_MaxTransparencyPercent = 0;
						return;
					}
					m_MaxTransparencyPercent = value;
				}
			}

			#endregion

			#region Fields

			internal Timer m_Timer;
			internal NSeries m_SelectedSeries;
			internal float m_MaxTransparencyPercent;
			internal Dictionary<NSeries, float> m_SeriesToPercents;

			#endregion

			#region Constants

			private const int m_TransparencyStep = 20;

			#endregion
		}
	}
}
