using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NTrackingMouseEventsUC : NExampleBaseUC
	{
		private bool m_bMouseDownRegistered;
		private bool m_bMouseUpRegistered;
		private bool m_bMouseMoveRegistered;
		private bool m_bMouseLeaveRegistered;
		private bool m_bMouseEnterRegistered;
		private bool m_bMouseHoverRegistered;
        private bool m_bMouseWheelRegistered;
		private System.ComponentModel.Container components = null;

		public NTrackingMouseEventsUC()
		{
			InitializeComponent();

			m_bMouseDownRegistered = false;
			m_bMouseUpRegistered = false;
			m_bMouseMoveRegistered = false;
			m_bMouseLeaveRegistered = false;
			m_bMouseEnterRegistered = false;
			m_bMouseHoverRegistered = false;
			m_bMouseWheelRegistered = false;
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
            // NTrackingMouseEventsUC
            // 
            this.Name = "NTrackingMouseEventsUC";
            this.Size = new System.Drawing.Size(180, 579);
            this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

            CreateSampleChart();

			UpdateMouseEventsOperation();
		}

        private void CreateSampleChart()
        {
            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Tracking Mouse Events");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            NChart chart = nChartControl1.Charts[0];

            // add interlace stripe
            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

            // apply lighting and projection
			chart.Enable3D = true;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);
            
            // add line series
            NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
            line.Name = "Line";
            line.LineSegmentShape = LineSegmentShape.Tape;
            line.DataLabelStyle.Visible = false;
            line.Values.FillRandomRange(Random, 10, 10, 30);

			// add bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar";
			bar.DataLabelStyle.Visible = false;
            bar.Values.FillRandomRange(Random, 10, 40, 60);

            // add area series 			
            NAreaSeries area = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area.Name = "Area";
            area.DataLabelStyle.Visible = false;
            area.Values.FillRandomRange(Random, 10, 60, 100);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

            nChartControl1.Refresh();
        }

		private void UpdateMouseEventsOperation()
		{
			if (MouseDownCheckBox.Checked)
			{
				if (m_bMouseDownRegistered == false)
				{
					m_bMouseDownRegistered = true;
					nChartControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(OnChartMouseDown);
				}
			}
			else
			{
				if (m_bMouseDownRegistered == true)
				{
					nChartControl1.MouseDown -= new System.Windows.Forms.MouseEventHandler(OnChartMouseDown);
					m_bMouseDownRegistered = false;
				}
			}

			if (MouseUpCheckBox.Checked)
			{
				if (m_bMouseUpRegistered == false)
				{
					m_bMouseUpRegistered = true;
					nChartControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(OnChartMouseUp);
				}
			}
			else
			{
				if (m_bMouseUpRegistered == true)
				{
					m_bMouseUpRegistered = false;
					nChartControl1.MouseUp -= new System.Windows.Forms.MouseEventHandler(OnChartMouseUp);
				}
			}

			if (MouseWheelCheckBox.Checked)
			{
				if (m_bMouseWheelRegistered == false)
				{
					m_bMouseWheelRegistered = true;
					nChartControl1.MouseWheel += new System.Windows.Forms.MouseEventHandler(OnChartMouseWheel);
				}
			}
			else
			{
				if (m_bMouseWheelRegistered == true)
				{
					m_bMouseWheelRegistered = false;
					nChartControl1.MouseWheel -= new System.Windows.Forms.MouseEventHandler(OnChartMouseWheel);
				}
			}

			if (MouseMoveCheckBox.Checked)
			{
				if (m_bMouseMoveRegistered == false)
				{
					m_bMouseMoveRegistered = true;
					nChartControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(OnChartMouseMove);
				}
			}
			else
			{
				if (m_bMouseMoveRegistered == true)
				{
					m_bMouseMoveRegistered = false;
					nChartControl1.MouseMove -= new System.Windows.Forms.MouseEventHandler(OnChartMouseMove);
				}
			}

			if (MouseEnterCheckBox.Checked)
			{
				if (m_bMouseEnterRegistered == false)
				{
					m_bMouseEnterRegistered = true;
					nChartControl1.MouseEnter += new System.EventHandler(OnChartMouseEnter);
				}
			}
			else
			{
				if (m_bMouseEnterRegistered == true)
				{
					m_bMouseEnterRegistered = false;
					nChartControl1.MouseEnter -= new System.EventHandler(OnChartMouseEnter);
				}
			}

			if (MouseLeaveCheckBox.Checked)
			{
				if (m_bMouseLeaveRegistered == false)
				{
					m_bMouseLeaveRegistered = true;
					nChartControl1.MouseLeave += new System.EventHandler(OnChartMouseLeave);
				}
			}
			else
			{
				if (m_bMouseLeaveRegistered == true)
				{
					m_bMouseLeaveRegistered = false;
					nChartControl1.MouseLeave -= new System.EventHandler(OnChartMouseLeave);
				}
			}

			if (MouseHoverCheckBox.Checked)
			{
				if (m_bMouseHoverRegistered == false)
				{
					m_bMouseHoverRegistered = true;
					nChartControl1.MouseHover += new System.EventHandler(OnChartMouseHover);
				}
			}
			else
			{
				if (m_bMouseHoverRegistered == true)
				{
					m_bMouseHoverRegistered = false;
					nChartControl1.MouseHover -= new System.EventHandler(OnChartMouseHover);
				}
			}
		}

		protected void ProcessMouseEvent(String mouseEvent, object sender, MouseEventArgs e)
		{
			StringBuilder strBuild = new StringBuilder();
			MouseEventTextBox.Text = mouseEvent;
			ButtonTextBox.Text = e.Button.ToString();
			ChartObjectTextBox.Text = sender.GetType().ToString();

			strBuild.AppendFormat("{0}, ", e.X);
			strBuild.AppendFormat("{0}", e.Y);
			XYTextBox.Text = strBuild.ToString();
			strBuild.Remove(0, strBuild.Length);	

			strBuild.AppendFormat("{0}", e.Clicks);
			ClicksTextBox.Text = strBuild.ToString();

            string sInfo = GetResultDescription(nChartControl1.HitTest(e.X, e.Y));
            DescriptionTextBox.Text = sInfo;
		}

		protected void ProcessEvent(String mouseEvent, object sender, EventArgs e)
		{
			StringBuilder strBuild = new StringBuilder();
			MouseEventTextBox.Text = mouseEvent;
			ButtonTextBox.Text = "";
			ChartObjectTextBox.Text = sender.GetType().ToString();

			XYTextBox.Text = "";
			ClicksTextBox.Text = "";
		}

        private string GetResultDescription(NHitTestResult hitTestResult)
        {
            int nChartElement = (int)hitTestResult.ChartElement;
            string sInfo = "";
            ChartElementTextBox.Text = hitTestResult.ChartElement.ToString();

            switch (hitTestResult.ChartElement)
            {
                case ChartElement.Nothing:
                    sInfo = "Nothing";
                    break;
                case ChartElement.ControlBackground:
                    sInfo = "Control background";
                    break;
                case ChartElement.DataPoint:
                    sInfo = "Data point [" + hitTestResult.DataPointIndex.ToString() + "] from series [" + ((NSeriesBase)hitTestResult.Object.ParentNode).Name + "]";
                    break;
                case ChartElement.SurfaceDataPoint:
                    sInfo = "Surface data point [" + hitTestResult.SurfaceDataPointX.ToString() + ", " + hitTestResult.SurfaceDataPointZ.ToString();
                    break;
                case ChartElement.Axis:
                    sInfo = "Axis [" + hitTestResult.ObjectIndex + "]";
                    break;
                case ChartElement.ChartWall:
                    sInfo = "Wall [" + hitTestResult.ObjectIndex + "]";
                    break;
                case ChartElement.Legend:
                    sInfo = "Legend";
                    break;
                case ChartElement.LegendDataItem:
                    sInfo = "Legend data item [" + hitTestResult.ObjectIndex.ToString() + "]";
                    break;
                case ChartElement.LegendHeader:
                    sInfo = "Legend header";
                    break;
                case ChartElement.LegendFooter:
                    sInfo = "Legend footer";
                    break;
                case ChartElement.AxisStripe:
                    sInfo = "Axis stripe";
                    break;
                case ChartElement.Label:
                    sInfo = "Label";
                    break;
                case ChartElement.Watermark:
                    sInfo = "Watermark";
                    break;
                case ChartElement.Annotation:
                    sInfo = "Annotation";
                    break;
                case ChartElement.Chart:
                    sInfo = "Chart";
                    break;
                default:
                    Debug.Assert(false); // new chart element?
                    break;
            }

            return sInfo;
        }

		public void FillParamsList(NHitTestResult hitTestResult)
		{

		}

		public void OnChartMouseDown(object sender, MouseEventArgs e)
		{
			ProcessMouseEvent("MouseDown", sender, e);
		}

		public void OnChartMouseUp(object sender, MouseEventArgs e)
		{
			ProcessMouseEvent("MouseUp", sender, e);
		}

		public void OnChartMouseWheel(object sender, MouseEventArgs e)
		{
			ProcessMouseEvent("MouseWheel", sender, e);
		}

		public void OnChartMouseMove(object sender, MouseEventArgs e)
		{
			ProcessMouseEvent("MouseMove", sender, e);
		}

		public void OnChartMouseEnter(object sender, EventArgs e)
		{
			ProcessEvent("MouseEnter", sender, e);
		}

		public void OnChartMouseLeave(object sender, EventArgs e)
		{
			ProcessEvent("MouseLeave", sender, e);
		}

		public void OnChartMouseHover(object sender, EventArgs e)
		{
			ProcessEvent("MouseHover", sender, e);
		}

		private void MouseDownCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateMouseEventsOperation();
		}

		private void MouseUpCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateMouseEventsOperation();
		}

		private void MouseMoveCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateMouseEventsOperation();
		}

		private void MouseLeaveCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateMouseEventsOperation();
		}

		private void MouseEnterCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{	
			UpdateMouseEventsOperation();
		}

		private void MouseHoverCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateMouseEventsOperation();
		}

		private void MouseWheelCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateMouseEventsOperation();
		}

		private void UseWindowRenderSurfaceCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if(UseWindowRenderSurfaceCheckBox.Checked)
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			}
			else
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap;
			}
		}
	}
}

