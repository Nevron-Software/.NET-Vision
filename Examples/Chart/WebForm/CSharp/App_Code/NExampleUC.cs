using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NExampleUC : System.Web.UI.UserControl
	{
		#region Overrides

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
		}

		protected override void LoadViewState(object savedState)
		{
			base.LoadViewState(savedState);

			LoadExample();
		}

		protected override void OnInit(EventArgs e)
		{
			EnableViewState = true;
			this.Session.Timeout = 20;

			base.OnInit(e);
		}

		#endregion

		#region Overridables

		protected virtual void LoadExample()
		{
		}


		#endregion

		#region Operations

		protected void ApplyLayoutTemplate(int template, INChartControl control, NDockPanel chart, NLabel title, NLegend legend)
		{
			control.Panels.Clear();

			if (title != null)
			{
				control.Panels.Add(title);

				title.DockMode = PanelDockMode.Top;
				title.Padding = new NMarginsL(4, 6, 4, 6);
			}

			if (legend != null)
			{
				control.Panels.Add(legend);

				legend.DockMode = PanelDockMode.Right;
				legend.Padding = new NMarginsL(1, 1, 3, 3);
			}

			if (chart != null)
			{
				control.Panels.Add(chart);

				float topPad = (title == null) ? 3 : 3;
				float rightPad = (legend == null) ? 3 : 3;

				if (chart.BoundsMode == BoundsMode.None)
				{
					if (((chart is NChart) && (((NChart)chart).Enable3D)) || !(chart is NCartesianChart))
					{
						chart.BoundsMode = BoundsMode.Fit;
					}
					else
					{
						chart.BoundsMode = BoundsMode.Stretch;
					}
				}

				chart.DockMode = PanelDockMode.Fill;

				// fit axes if chart is Cartesian 3D
				NCartesianChart cartesianChart = chart as NCartesianChart;
				if (cartesianChart != null)
				{
					cartesianChart.Fit3DAxisContent = true;
				}

				chart.Padding = new NMarginsL(
					new NLength(3, NRelativeUnit.ParentPercentage),
					new NLength(topPad, NRelativeUnit.ParentPercentage),
					new NLength(rightPad, NRelativeUnit.ParentPercentage),
					new NLength(3, NRelativeUnit.ParentPercentage));
			}
		}
		protected void FillStockDates(NStockSeries stock, int count)
		{
			FillStockDates(stock, count, new DateTime(2009, 1, 5));
		}
		protected void FillStockDates(NStockSeries stock, int count, DateTime startDate)
		{
			stock.XValues.Clear();

			DateTime dt = startDate;

			for (int i = 0; i < count; )
			{
				if (dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday)
				{
					stock.XValues.Add(dt.ToOADate());
					i++;
				}

				dt = dt.AddDays(1);
			}
		}

		#endregion

		#region Fields

		protected static readonly Random Random = new Random();

		protected static readonly double[] monthValues = new double[] { 16, 19, 16, 15, 18, 19, 24, 21, 22, 17, 19, 15 };
		protected static readonly string[] monthLetters = new string[] { "J", "F", "M", "A", "M", "J", "J", "A", "S", "O", "N", "D" };
		protected static readonly string[] weekDays = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

        protected static readonly Color DarkOrange = Color.FromArgb(238, 66, 14);
        protected static readonly Color LightOrange = Color.FromArgb(254, 181, 25);
        protected static readonly Color LightGreen = Color.FromArgb(126, 190, 58);
        protected static readonly Color Turqoise = Color.FromArgb(2, 138, 122);
        protected static readonly Color Blue = Color.FromArgb(2, 90, 156);
        protected static readonly Color Purple = Color.FromArgb(78, 46, 134);
        protected static readonly Color BeautifulRed = Color.FromArgb(170, 30, 96);
        protected static readonly Color Red = Color.FromArgb(225, 7, 24);
        protected static readonly Color Gold = Color.FromArgb(253, 202, 25);
        protected static readonly Color LimeGreen = Color.FromArgb(206, 222, 62);
        protected static readonly Color Green = Color.FromArgb(1, 157, 96);
        protected static readonly Color SeaBlue = Color.FromArgb(2, 117, 137);
        protected static readonly Color LightPurple = Color.FromArgb(69, 72, 165);
        protected static readonly Color DarkFuchsia = Color.FromArgb(123, 22, 98);
        protected static readonly Color GreyBlue = Color.FromArgb(68, 90, 108);


		protected static readonly Color[] arrCustomColors1 = new Color[]
		{
			Color.Firebrick,
			Color.Tomato,
			Color.Orange,
			Color.Gold,
			Color.GreenYellow,
			Color.LimeGreen,
			Color.MediumAquamarine,
			Color.CadetBlue,
			Color.SlateBlue,
			Color.MediumPurple
		};

		protected static Color[] arrCustomColors2 = new Color[]
		{
			Color.IndianRed,
			Color.Peru,
			Color.DarkKhaki,
			Color.OliveDrab,
			Color.DarkSeaGreen,
			Color.MediumSeaGreen,
			Color.SteelBlue,
			Color.SlateBlue,
			Color.MediumOrchid,
			Color.HotPink
		};

		protected static Color[] arrCustomColors3 = new Color[]
		{
			Color.Snow,
			Color.PaleGoldenrod,
			Color.White,
			Color.Silver,
			Color.WhiteSmoke,
			Color.Khaki,
			Color.Azure,
			Color.AntiqueWhite,
			Color.AliceBlue,
			Color.Wheat,
		};


		#endregion

		#region Protected classes

		protected class NStockDataGenerator
        {
            private Random m_Rand;
            private NRange1DD m_Range;
            private int m_nDirection;
            private int m_nStepsInCurrentTrend;
            private double m_dValue;
            private double m_dReversalPorbability;
            private double m_dReversalFactor;
            private double m_dValueScale;

            public NStockDataGenerator(NRange1DD range, double reversalFactor, double valueScale)
            {
                m_Rand = new Random();
                m_Range = range;
                m_nDirection = 1;
                m_nStepsInCurrentTrend = 0;
                m_dValue = 0;
                m_dReversalPorbability = 0;
                m_dReversalFactor = reversalFactor;
                m_dValueScale = valueScale;
            }

            public void Reset()
            {
                m_nDirection = 1;
                m_nStepsInCurrentTrend = 0;
                m_dValue = (m_Range.Begin + m_Range.End) / 2;
                m_dReversalPorbability = 0;
            }

            public double GetNextValue()
            {
                int nNewValueDirection = 0;

                if (m_dValue <= m_Range.Begin)
                {
                    if (m_nDirection == -1)
                    {
                        m_dReversalPorbability = 1.0;
                    }
                    else
                    {
                        m_dReversalPorbability = 0.0;
                    }

                    nNewValueDirection = 1;
                }
                else if (m_dValue >= m_Range.End)
                {
                    if (m_nDirection == 1)
                    {
                        m_dReversalPorbability = 1.0;
                    }
                    else
                    {
                        m_dReversalPorbability = 0.0;
                    }

                    nNewValueDirection = -1;
                }
                else
                {
                    if (m_Rand.NextDouble() < 0.80)
                    {
                        nNewValueDirection = m_nDirection;
                    }
                    else
                    {
                        nNewValueDirection = -m_nDirection;
                    }

                    m_dReversalPorbability += m_nStepsInCurrentTrend * m_dReversalFactor;
                }

                if (m_Rand.NextDouble() < m_dReversalPorbability)
                {
                    m_nDirection = -m_nDirection;
                    m_dReversalPorbability = 0;
                    m_nStepsInCurrentTrend = 0;
                }
                else
                {
                    m_nStepsInCurrentTrend++;
                }

                m_dValue += nNewValueDirection * m_Rand.NextDouble() * m_dValueScale;

                return m_dValue;
            }
        }

        #endregion
    }
}
