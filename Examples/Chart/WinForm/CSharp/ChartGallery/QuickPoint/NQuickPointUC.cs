using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using System.Diagnostics;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NQuickPointUC : NExampleBaseUC
	{
        NQuickPointSeries m_QuickPoint;
        private UI.WinForm.Controls.NCheckBox UseHardwareAccelerationCheckBox;
        private UI.WinForm.Controls.NButton ChangeDataButton;
        private Label label1;
        private UI.WinForm.Controls.NComboBox MaxPointCountCombo;
        private UI.WinForm.Controls.NCheckBox Enable3DCheckBox;
        private IContainer components;

		public NQuickPointUC()
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
            this.UseHardwareAccelerationCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ChangeDataButton = new Nevron.UI.WinForm.Controls.NButton();
            this.label1 = new System.Windows.Forms.Label();
            this.MaxPointCountCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.Enable3DCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.SuspendLayout();
            // 
            // UseHardwareAccelerationCheckBox
            // 
            this.UseHardwareAccelerationCheckBox.ButtonProperties.BorderOffset = 2;
            this.UseHardwareAccelerationCheckBox.Location = new System.Drawing.Point(7, 88);
            this.UseHardwareAccelerationCheckBox.Name = "UseHardwareAccelerationCheckBox";
            this.UseHardwareAccelerationCheckBox.Size = new System.Drawing.Size(170, 24);
            this.UseHardwareAccelerationCheckBox.TabIndex = 7;
            this.UseHardwareAccelerationCheckBox.Text = "Use Hardware Acceleration";
            this.UseHardwareAccelerationCheckBox.CheckedChanged += new System.EventHandler(this.UseHardwareAccelerationCheckBox_CheckedChanged);
            // 
            // ChangeDataButton
            // 
            this.ChangeDataButton.Location = new System.Drawing.Point(7, 58);
            this.ChangeDataButton.Name = "ChangeDataButton";
            this.ChangeDataButton.Size = new System.Drawing.Size(153, 23);
            this.ChangeDataButton.TabIndex = 9;
            this.ChangeDataButton.Text = "Change Data";
            this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Max Point Count:";
            // 
            // MaxPointCountCombo
            // 
            this.MaxPointCountCombo.ListProperties.CheckBoxDataMember = "";
            this.MaxPointCountCombo.ListProperties.DataSource = null;
            this.MaxPointCountCombo.ListProperties.DisplayMember = "";
            this.MaxPointCountCombo.Location = new System.Drawing.Point(7, 32);
            this.MaxPointCountCombo.Name = "MaxPointCountCombo";
            this.MaxPointCountCombo.Size = new System.Drawing.Size(153, 21);
            this.MaxPointCountCombo.TabIndex = 1;
            this.MaxPointCountCombo.SelectedIndexChanged += new System.EventHandler(this.MaxPointCountCombo_SelectedIndexChanged);
            // 
            // Enable3DCheckBox
            // 
            this.Enable3DCheckBox.ButtonProperties.BorderOffset = 2;
            this.Enable3DCheckBox.Location = new System.Drawing.Point(7, 118);
            this.Enable3DCheckBox.Name = "Enable3DCheckBox";
            this.Enable3DCheckBox.Size = new System.Drawing.Size(170, 24);
            this.Enable3DCheckBox.TabIndex = 10;
            this.Enable3DCheckBox.Text = "Enable 3D";
            this.Enable3DCheckBox.CheckedChanged += new System.EventHandler(this.Enable3DCheckBox_CheckedChanged);
            // 
            // NQuickPointUC
            // 
            this.Controls.Add(this.Enable3DCheckBox);
            this.Controls.Add(this.ChangeDataButton);
            this.Controls.Add(this.UseHardwareAccelerationCheckBox);
            this.Controls.Add(this.MaxPointCountCombo);
            this.Controls.Add(this.label1);
            this.Name = "NQuickPointUC";
            this.Size = new System.Drawing.Size(180, 320);
            this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Quick Point Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// setup chart
			NChart m_Chart = nChartControl1.Charts[0];
            m_Chart.Enable3D = true;
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

            m_Chart.Width = 50;
            m_Chart.Height = 50;
            m_Chart.Depth = 50;
            m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);

            // add interlace stripe
            NLinearScaleConfigurator s = new NLinearScaleConfigurator();
            m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = CreateScale(new ChartWallType[] { ChartWallType.Back, ChartWallType.Left } );
            m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = CreateScale(new ChartWallType[] { ChartWallType.Back, ChartWallType.Floor });
            m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = CreateScale(new ChartWallType[] { ChartWallType.Left, ChartWallType.Floor });
            m_Chart.Axis(StandardAxis.Depth).Visible = true;

			// setup point series
            m_QuickPoint = new NQuickPointSeries();
            m_Chart.Series.Add(m_QuickPoint);
            m_QuickPoint.Name = "Point Series";
            m_QuickPoint.InflateMargins = true;
            m_QuickPoint.UseXValues = true;
            m_QuickPoint.UseZValues = true;
            m_QuickPoint.Size = new NLength(1);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

            nChartControl1.Settings.RenderSurface = RenderSurface.Window;

            MaxPointCountCombo.Items.Add("10K");
            MaxPointCountCombo.Items.Add("100K");
            MaxPointCountCombo.Items.Add("500K");
            MaxPointCountCombo.SelectedIndex = 1;

            UseHardwareAccelerationCheckBox.Checked = true;
            Enable3DCheckBox.Checked = true;
		}

        private NLinearScaleConfigurator CreateScale(ChartWallType[] stripeWalls)
        {
            // add interlace stripe
            NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;

            for (int i = 0; i < stripeWalls.Length; i++)
            {
                stripStyle.SetShowAtWall(stripeWalls[i], true);
            }

            linearScale.StripStyles.Add(stripStyle);

            return linearScale;
        }

        private int GetPointCount()
        {
            switch (MaxPointCountCombo.SelectedIndex)
            {
                case 0:
                    return 10000;
                case 1:
                    return 100000;
                case 2:
                    return 500000;
                default:
                    Debug.Assert(false);
                    return 1000;
            }
        }

        private void UseHardwareAccelerationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            nChartControl1.Settings.RenderSurface = UseHardwareAccelerationCheckBox.Checked ? RenderSurface.Window : RenderSurface.Bitmap;
        }

        private void MaxPointCountCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDataButton_Click(null, null);
        }

        private void ChangeDataButton_Click(object sender, EventArgs e)
        {
            Random rand = new System.Random();

            int pointCount = GetPointCount();

            m_QuickPoint.Values.Clear();
            m_QuickPoint.XValues.Clear();
            m_QuickPoint.ZValues.Clear();
            m_QuickPoint.Colors.Clear();

            int lastIndex = m_QuickPoint.Values.Count;

            int groupCount = 20;
            int groupPointCount = pointCount / groupCount;

            for (int group = 0; group < groupCount; group++)
            {
                double centerX = rand.Next(1000000) / 1000;
                double centerY = rand.Next(1000000) / 1000;
                double centerZ = rand.Next(1000000) / 1000;

                int radius = rand.Next(1000000) / 1000 + 200;
                Color color = Color.FromArgb((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));

                for (int i = 0; i < groupPointCount; i++)
                {
                    double pitch = rand.Next(100000) / 100000.0 * Math.PI * 2;
                    double latitude = rand.Next(100000) / 100000.0 * Math.PI * 2;
                    double res = radius * Math.Sin(pitch);


                    m_QuickPoint.XValues.Add(centerY + radius * Math.Cos(pitch));
                    m_QuickPoint.Values.Add(centerX + res * Math.Cos(latitude));
                    m_QuickPoint.ZValues.Add(centerZ + res * Math.Sin(latitude));

                    m_QuickPoint.Colors[lastIndex] = color;
                    lastIndex++;
                }
            }

            nChartControl1.Refresh();
        }

        private void Enable3DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_QuickPoint.Chart.Enable3D = Enable3DCheckBox.Checked;
            nChartControl1.Refresh();
        }
	}
}