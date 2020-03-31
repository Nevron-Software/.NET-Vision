using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NRealTimeExampleBaseUC : NExampleBaseUC
	{
		private IContainer components;
		private PerformanceCounter m_PerformanceCounter;

		private float[] m_CpuUsage;
		private int m_CpuUsageIndex;
		private int m_CpuUsageCount;

		private int m_ReadCPUUsage;

		private bool m_TimerRunning;
		private Timer m_Timer;

		public NRealTimeExampleBaseUC()
		{
			m_CpuUsage = new float[10];

			m_TimerRunning = false;
			m_Timer = new System.Windows.Forms.Timer();
			m_Timer.Interval = 25;
			m_Timer.Tick += new EventHandler(OnTimerTick);

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

                if (m_Timer != null)
                {
                    m_Timer.Stop();
                    m_Timer.Tick -= new EventHandler(OnTimerTick);
                    m_Timer.Dispose();
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
			this.components = new System.ComponentModel.Container();
			this.SuspendLayout();
			// 
			// NRealTimeExampleBaseUC
			// 
			this.Name = "NRealTimeExampleBaseUC";
			this.Size = new System.Drawing.Size(192, 266);
			this.Load += new System.EventHandler(this.NRealTimeExampleBaseUC_Load);
			this.ResumeLayout(false);

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
					m_CpuUsageCount =  Math.Min(m_CpuUsage.Length, m_CpuUsageCount + 1);

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
			return m_TimerRunning;
		}
		/// <summary>
		/// Starts the timer
		/// </summary>
		/// <param name="sender"></param>
		protected void StartTimer()
		{
			if (!m_TimerRunning)
			{
				m_Timer.Start();
				m_TimerRunning = true;
			}
		}
		/// <summary>
		/// Toggles the timer
		/// </summary>
		/// <param name="sender"></param>
		protected void ToggleTimer()
		{
			if (m_TimerRunning)
			{
				m_Timer.Stop();
				m_TimerRunning = false;

                UpdateTitle(false, 0);
                nChartControl1.Refresh();
			}
			else
			{
				m_Timer.Start();
				m_TimerRunning = true;
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
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NRealTimeExampleBaseUC_Load(object sender, EventArgs e)
		{
			m_PerformanceCounter = new PerformanceCounter();
			m_PerformanceCounter.CategoryName = "Processor";
			m_PerformanceCounter.CounterName = "% Processor Time";
			m_PerformanceCounter.InstanceName = "_Total";
		}

		#endregion
	}
}
