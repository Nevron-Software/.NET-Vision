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

		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NTextBox ButtonTextBox;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NTextBox ClicksTextBox;
		private Nevron.UI.WinForm.Controls.NCheckBox MouseDownCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox MouseUpCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox MouseMoveCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox MouseLeaveCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox MouseEnterCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox MouseHoverCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox MouseWheelCheckBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NTextBox ChartObjectTextBox;
        private Nevron.UI.WinForm.Controls.NTextBox MouseEventTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox XYTextBox;
		private Nevron.UI.WinForm.Controls.NCheckBox UseWindowRenderSurfaceCheckBox;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox3;
		private Nevron.UI.WinForm.Controls.NTextBox ChartElementTextBox;
		private System.Windows.Forms.Label label8;
		private Nevron.UI.WinForm.Controls.NTextBox textBox1;
		private Nevron.UI.WinForm.Controls.NTextBox DescriptionTextBox;
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
			this.MouseDownCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.MouseUpCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.MouseMoveCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.MouseLeaveCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.MouseEnterCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.MouseHoverCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.MouseWheelCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.XYTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.ButtonTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.ClicksTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.ChartObjectTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.MouseEventTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.UseWindowRenderSurfaceCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.DescriptionTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.ChartElementTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.textBox1 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// MouseDownCheckBox
			// 
			this.MouseDownCheckBox.ButtonProperties.BorderOffset = 2;
			this.MouseDownCheckBox.Location = new System.Drawing.Point(7, 16);
			this.MouseDownCheckBox.Name = "MouseDownCheckBox";
			this.MouseDownCheckBox.Size = new System.Drawing.Size(96, 20);
			this.MouseDownCheckBox.TabIndex = 0;
			this.MouseDownCheckBox.Text = "Mouse down";
			this.MouseDownCheckBox.CheckedChanged += new System.EventHandler(this.MouseDownCheckBox_CheckedChanged);
			// 
			// MouseUpCheckBox
			// 
			this.MouseUpCheckBox.ButtonProperties.BorderOffset = 2;
			this.MouseUpCheckBox.Location = new System.Drawing.Point(7, 35);
			this.MouseUpCheckBox.Name = "MouseUpCheckBox";
			this.MouseUpCheckBox.Size = new System.Drawing.Size(96, 20);
			this.MouseUpCheckBox.TabIndex = 1;
			this.MouseUpCheckBox.Text = "Mouse up";
			this.MouseUpCheckBox.CheckedChanged += new System.EventHandler(this.MouseUpCheckBox_CheckedChanged);
			// 
			// MouseMoveCheckBox
			// 
			this.MouseMoveCheckBox.ButtonProperties.BorderOffset = 2;
			this.MouseMoveCheckBox.Location = new System.Drawing.Point(7, 54);
			this.MouseMoveCheckBox.Name = "MouseMoveCheckBox";
			this.MouseMoveCheckBox.Size = new System.Drawing.Size(96, 20);
			this.MouseMoveCheckBox.TabIndex = 2;
			this.MouseMoveCheckBox.Text = "Mouse move";
			this.MouseMoveCheckBox.CheckedChanged += new System.EventHandler(this.MouseMoveCheckBox_CheckedChanged);
			// 
			// MouseLeaveCheckBox
			// 
			this.MouseLeaveCheckBox.ButtonProperties.BorderOffset = 2;
			this.MouseLeaveCheckBox.Location = new System.Drawing.Point(7, 73);
			this.MouseLeaveCheckBox.Name = "MouseLeaveCheckBox";
			this.MouseLeaveCheckBox.Size = new System.Drawing.Size(96, 20);
			this.MouseLeaveCheckBox.TabIndex = 3;
			this.MouseLeaveCheckBox.Text = "Mouse leave";
			this.MouseLeaveCheckBox.CheckedChanged += new System.EventHandler(this.MouseLeaveCheckBox_CheckedChanged);
			// 
			// MouseEnterCheckBox
			// 
			this.MouseEnterCheckBox.ButtonProperties.BorderOffset = 2;
			this.MouseEnterCheckBox.Location = new System.Drawing.Point(7, 92);
			this.MouseEnterCheckBox.Name = "MouseEnterCheckBox";
			this.MouseEnterCheckBox.Size = new System.Drawing.Size(96, 20);
			this.MouseEnterCheckBox.TabIndex = 4;
			this.MouseEnterCheckBox.Text = "Mouse enter";
			this.MouseEnterCheckBox.CheckedChanged += new System.EventHandler(this.MouseEnterCheckBox_CheckedChanged);
			// 
			// MouseHoverCheckBox
			// 
			this.MouseHoverCheckBox.ButtonProperties.BorderOffset = 2;
			this.MouseHoverCheckBox.Location = new System.Drawing.Point(7, 111);
			this.MouseHoverCheckBox.Name = "MouseHoverCheckBox";
			this.MouseHoverCheckBox.Size = new System.Drawing.Size(96, 20);
			this.MouseHoverCheckBox.TabIndex = 5;
			this.MouseHoverCheckBox.Text = "Mouse hover";
			this.MouseHoverCheckBox.CheckedChanged += new System.EventHandler(this.MouseHoverCheckBox_CheckedChanged);
			// 
			// MouseWheelCheckBox
			// 
			this.MouseWheelCheckBox.ButtonProperties.BorderOffset = 2;
			this.MouseWheelCheckBox.Location = new System.Drawing.Point(7, 130);
			this.MouseWheelCheckBox.Name = "MouseWheelCheckBox";
			this.MouseWheelCheckBox.Size = new System.Drawing.Size(96, 20);
			this.MouseWheelCheckBox.TabIndex = 6;
			this.MouseWheelCheckBox.Text = "Mouse wheel";
			this.MouseWheelCheckBox.CheckedChanged += new System.EventHandler(this.MouseWheelCheckBox_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.MouseWheelCheckBox);
			this.groupBox1.Controls.Add(this.MouseLeaveCheckBox);
			this.groupBox1.Controls.Add(this.MouseMoveCheckBox);
			this.groupBox1.Controls.Add(this.MouseEnterCheckBox);
			this.groupBox1.Controls.Add(this.MouseHoverCheckBox);
			this.groupBox1.Controls.Add(this.MouseDownCheckBox);
			this.groupBox1.Controls.Add(this.MouseUpCheckBox);
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(5, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(172, 153);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Track mouse events";
			// 
			// XYTextBox
			// 
			this.XYTextBox.Location = new System.Drawing.Point(95, 41);
			this.XYTextBox.Name = "XYTextBox";
			this.XYTextBox.ReadOnly = true;
			this.XYTextBox.Size = new System.Drawing.Size(72, 18);
			this.XYTextBox.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 41);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 16);
			this.label3.TabIndex = 12;
			this.label3.Text = "XY:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(7, 65);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 13;
			this.label4.Text = "Button:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ButtonTextBox
			// 
			this.ButtonTextBox.Location = new System.Drawing.Point(95, 65);
			this.ButtonTextBox.Name = "ButtonTextBox";
			this.ButtonTextBox.ReadOnly = true;
			this.ButtonTextBox.Size = new System.Drawing.Size(72, 18);
			this.ButtonTextBox.TabIndex = 14;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(7, 89);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 16);
			this.label5.TabIndex = 15;
			this.label5.Text = "Clicks:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ClicksTextBox
			// 
			this.ClicksTextBox.Location = new System.Drawing.Point(95, 89);
			this.ClicksTextBox.Name = "ClicksTextBox";
			this.ClicksTextBox.ReadOnly = true;
			this.ClicksTextBox.Size = new System.Drawing.Size(72, 18);
			this.ClicksTextBox.TabIndex = 16;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(7, 113);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 16);
			this.label6.TabIndex = 17;
			this.label6.Text = "Sender:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ChartObjectTextBox
			// 
			this.ChartObjectTextBox.Location = new System.Drawing.Point(71, 113);
			this.ChartObjectTextBox.Name = "ChartObjectTextBox";
			this.ChartObjectTextBox.ReadOnly = true;
			this.ChartObjectTextBox.Size = new System.Drawing.Size(96, 18);
			this.ChartObjectTextBox.TabIndex = 18;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(7, 17);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 16);
			this.label7.TabIndex = 19;
			this.label7.Text = "Mouse event:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MouseEventTextBox
			// 
			this.MouseEventTextBox.Location = new System.Drawing.Point(95, 17);
			this.MouseEventTextBox.Name = "MouseEventTextBox";
			this.MouseEventTextBox.ReadOnly = true;
			this.MouseEventTextBox.Size = new System.Drawing.Size(72, 18);
			this.MouseEventTextBox.TabIndex = 20;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.XYTextBox);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.ButtonTextBox);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.ClicksTextBox);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.ChartObjectTextBox);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.MouseEventTextBox);
			this.groupBox2.ImageIndex = 0;
			this.groupBox2.Location = new System.Drawing.Point(5, 162);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(172, 142);
			this.groupBox2.TabIndex = 21;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Last mouse event";
			// 
			// UseWindowRenderSurfaceCheckBox
			// 
			this.UseWindowRenderSurfaceCheckBox.ButtonProperties.BorderOffset = 2;
			this.UseWindowRenderSurfaceCheckBox.Location = new System.Drawing.Point(12, 485);
			this.UseWindowRenderSurfaceCheckBox.Name = "UseWindowRenderSurfaceCheckBox";
			this.UseWindowRenderSurfaceCheckBox.Size = new System.Drawing.Size(120, 24);
			this.UseWindowRenderSurfaceCheckBox.TabIndex = 26;
			this.UseWindowRenderSurfaceCheckBox.Text = "Render to window";
			this.UseWindowRenderSurfaceCheckBox.CheckedChanged += new System.EventHandler(this.UseWindowRenderSurfaceCheckBox_CheckedChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(117, 17);
			this.label2.TabIndex = 26;
			this.label2.Text = "Chart element name:";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.DescriptionTextBox);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.ChartElementTextBox);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.ImageIndex = 0;
			this.groupBox3.Location = new System.Drawing.Point(6, 299);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(171, 187);
			this.groupBox3.TabIndex = 27;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Hit test results";
			// 
			// DescriptionTextBox
			// 
			this.DescriptionTextBox.Location = new System.Drawing.Point(9, 78);
			this.DescriptionTextBox.Multiline = true;
			this.DescriptionTextBox.Name = "DescriptionTextBox";
			this.DescriptionTextBox.Size = new System.Drawing.Size(152, 102);
			this.DescriptionTextBox.TabIndex = 29;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(9, 58);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(147, 17);
			this.label8.TabIndex = 28;
			this.label8.Text = "Chart element description:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ChartElementTextBox
			// 
			this.ChartElementTextBox.Location = new System.Drawing.Point(9, 33);
			this.ChartElementTextBox.Name = "ChartElementTextBox";
			this.ChartElementTextBox.Size = new System.Drawing.Size(153, 18);
			this.ChartElementTextBox.TabIndex = 27;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(0, 0);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 0;
			// 
			// NTrackingMouseEventsUC
			// 
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.UseWindowRenderSurfaceCheckBox);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "NTrackingMouseEventsUC";
			this.Size = new System.Drawing.Size(180, 579);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
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

