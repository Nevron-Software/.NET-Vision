using System.Windows.Controls;
using System.Windows.Threading;
using Nevron.Chart.Wpf;
using Nevron.Chart;
using System;
using System.Diagnostics;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// Interaction logic for NRealTimeExampleBase.xaml
	/// </summary>
	public class NRealTimeExampleBaseUC : NExampleBaseUC
	{
		#region Constructors

		/// <summary>
		/// Initializer constructor
		/// </summary>
		public NRealTimeExampleBaseUC()
		{
			m_CpuUsage = new float[10];

			m_PerformanceCounter = new PerformanceCounter();
			m_PerformanceCounter.CategoryName = "Processor";
			m_PerformanceCounter.CounterName = "% Processor Time";
			m_PerformanceCounter.InstanceName = "_Total";

			m_Timer = new System.Windows.Threading.DispatcherTimer();
			m_Timer.Tick += new EventHandler(OnTimerTick);
			m_Timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
			m_Timer.Start();
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets the CPU usage
		/// </summary>
		internal float CPUUsage
		{
			get
			{
				// record the current cpu usage
				if (m_ReadCPUUsage == 0)
				{
					m_CpuUsage[m_CpuUsageIndex] = m_PerformanceCounter.NextValue();

					m_CpuUsageIndex++;
					m_CpuUsageCount = Math.Min(m_CpuUsage.Length, m_CpuUsageCount + 1);

					if (m_CpuUsageIndex >= m_CpuUsage.Length)
					{
						m_CpuUsageIndex = 0;
					}

					m_ReadCPUUsage = 5;
				}

				m_ReadCPUUsage--;

				float cpuUsage = 0;
				for (int i = 0; i < m_CpuUsageCount; i++)
				{
					cpuUsage += m_CpuUsage[i];
				}

				return cpuUsage / m_CpuUsageCount;
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Returns true if the timer is running
		/// </summary>
		/// <returns></returns>
		protected bool IsTimerRunning()
		{
			return m_Timer.IsEnabled;
		}
		/// <summary>
		/// Starts the timer
		/// </summary>
		/// <param name="sender"></param>
		protected void StartTimer()
		{
			if (!m_Timer.IsEnabled)
			{
				m_Timer.Start();
			}
		}
		/// <summary>
		/// Toggles the timer
		/// </summary>
		/// <param name="sender"></param>
		protected void ToggleTimer()
		{
			if (m_Timer.IsEnabled)
			{
				m_Timer.Stop();

				UpdateTitle(false, 0);
				nChartControl1.Refresh();
			}
			else
			{
				m_Timer.Start();
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="working"></param>
		/// <param name="cpuUsage"></param>
		/// <returns></returns>
		protected virtual void UpdateTitle(bool working, float cpuUsage)
		{
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnTimerTick(object sender, EventArgs e)
		{
			try
			{
				UpdateTitle(true, CPUUsage);
			}
			catch 
			{
			}
		}

		#endregion

		#region Overrides

		/// <summary>
		/// Called to destroy the example
		/// </summary>
		public override void Destroy()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
				m_Timer.Tick -= new EventHandler(OnTimerTick);
				m_Timer = null;
			}

			if (m_PerformanceCounter != null)
			{
				m_PerformanceCounter.Dispose();
				m_PerformanceCounter = null;
			}

			base.Destroy();
		}

		#endregion

		#region Fields

		private float[] m_CpuUsage;
		private int m_CpuUsageIndex;
		private int m_CpuUsageCount;

		private int m_ReadCPUUsage;
		protected DispatcherTimer m_Timer;
		protected PerformanceCounter m_PerformanceCounter;

		#endregion
	}
}
