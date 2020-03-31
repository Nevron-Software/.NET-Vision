using System;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NDataCursorToolUC : NExampleBaseUC
	{
		private NAxisCursor m_HorizontalAxisCursor;
		private NAxisCursor m_VerticalAxisCursor;
		private NChart m_Chart;
        private NDataCursorTool m_DataCursorTool;
		private Nevron.UI.WinForm.Controls.NComboBox VerticalAxisSnapModeComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox HorizontalAxisSnapModeComboBox;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NCheckBox MouseDownCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox MouseUpCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox MouseMoveCheckBox;
		private Nevron.UI.WinForm.Controls.NTextBox XAxisTextBox;
        private Nevron.UI.WinForm.Controls.NTextBox YAxisTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private NCheckBox Enable3DCheckBox;
		private System.ComponentModel.Container components = null;

		public NDataCursorToolUC()
		{
			InitializeComponent();

			m_DataCursorTool = new NDataCursorTool();
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.XAxisTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
            this.YAxisTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
            this.VerticalAxisSnapModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.HorizontalAxisSnapModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.MouseMoveCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.MouseUpCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.MouseDownCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.Enable3DCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Axis coordinates:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "X Axis:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Y Axis:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // XAxisTextBox
            // 
            this.XAxisTextBox.Location = new System.Drawing.Point(78, 260);
            this.XAxisTextBox.Name = "XAxisTextBox";
            this.XAxisTextBox.ReadOnly = true;
            this.XAxisTextBox.Size = new System.Drawing.Size(88, 18);
            this.XAxisTextBox.TabIndex = 8;
            // 
            // YAxisTextBox
            // 
            this.YAxisTextBox.Location = new System.Drawing.Point(78, 284);
            this.YAxisTextBox.Name = "YAxisTextBox";
            this.YAxisTextBox.ReadOnly = true;
            this.YAxisTextBox.Size = new System.Drawing.Size(88, 18);
            this.YAxisTextBox.TabIndex = 10;
            // 
            // VerticalAxisSnapModeComboBox
            // 
            this.VerticalAxisSnapModeComboBox.ListProperties.CheckBoxDataMember = "";
            this.VerticalAxisSnapModeComboBox.ListProperties.DataSource = null;
            this.VerticalAxisSnapModeComboBox.ListProperties.DisplayMember = "";
            this.VerticalAxisSnapModeComboBox.Location = new System.Drawing.Point(9, 100);
            this.VerticalAxisSnapModeComboBox.Name = "VerticalAxisSnapModeComboBox";
            this.VerticalAxisSnapModeComboBox.Size = new System.Drawing.Size(160, 21);
            this.VerticalAxisSnapModeComboBox.TabIndex = 4;
            this.VerticalAxisSnapModeComboBox.SelectedIndexChanged += new System.EventHandler(this.VerticalAxisSnapModeComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Vertical axis snap mode:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(9, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "Horizontal axis snap mode:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // HorizontalAxisSnapModeComboBox
            // 
            this.HorizontalAxisSnapModeComboBox.ListProperties.CheckBoxDataMember = "";
            this.HorizontalAxisSnapModeComboBox.ListProperties.DataSource = null;
            this.HorizontalAxisSnapModeComboBox.ListProperties.DisplayMember = "";
            this.HorizontalAxisSnapModeComboBox.Location = new System.Drawing.Point(9, 52);
            this.HorizontalAxisSnapModeComboBox.Name = "HorizontalAxisSnapModeComboBox";
            this.HorizontalAxisSnapModeComboBox.Size = new System.Drawing.Size(160, 21);
            this.HorizontalAxisSnapModeComboBox.TabIndex = 2;
            this.HorizontalAxisSnapModeComboBox.SelectedIndexChanged += new System.EventHandler(this.HorizontalAxisSnapModeComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MouseMoveCheckBox);
            this.groupBox1.Controls.Add(this.MouseUpCheckBox);
            this.groupBox1.Controls.Add(this.MouseDownCheckBox);
            this.groupBox1.ImageIndex = 0;
            this.groupBox1.Location = new System.Drawing.Point(6, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Synchronize with:";
            // 
            // MouseMoveCheckBox
            // 
            this.MouseMoveCheckBox.ButtonProperties.BorderOffset = 2;
            this.MouseMoveCheckBox.Location = new System.Drawing.Point(8, 64);
            this.MouseMoveCheckBox.Name = "MouseMoveCheckBox";
            this.MouseMoveCheckBox.Size = new System.Drawing.Size(104, 24);
            this.MouseMoveCheckBox.TabIndex = 2;
            this.MouseMoveCheckBox.Text = "MouseMove";
            this.MouseMoveCheckBox.CheckedChanged += new System.EventHandler(this.MouseMoveCheckBox_CheckedChanged);
            // 
            // MouseUpCheckBox
            // 
            this.MouseUpCheckBox.ButtonProperties.BorderOffset = 2;
            this.MouseUpCheckBox.Location = new System.Drawing.Point(8, 40);
            this.MouseUpCheckBox.Name = "MouseUpCheckBox";
            this.MouseUpCheckBox.Size = new System.Drawing.Size(104, 24);
            this.MouseUpCheckBox.TabIndex = 1;
            this.MouseUpCheckBox.Text = "Mouse Up";
            this.MouseUpCheckBox.CheckedChanged += new System.EventHandler(this.MouseUpCheckBox_CheckedChanged);
            // 
            // MouseDownCheckBox
            // 
            this.MouseDownCheckBox.ButtonProperties.BorderOffset = 2;
            this.MouseDownCheckBox.Location = new System.Drawing.Point(8, 16);
            this.MouseDownCheckBox.Name = "MouseDownCheckBox";
            this.MouseDownCheckBox.Size = new System.Drawing.Size(104, 24);
            this.MouseDownCheckBox.TabIndex = 0;
            this.MouseDownCheckBox.Text = "Mouse down";
            this.MouseDownCheckBox.CheckedChanged += new System.EventHandler(this.MouseDownCheckBox_CheckedChanged);
            // 
            // Enable3DCheckBox
            // 
            this.Enable3DCheckBox.ButtonProperties.BorderOffset = 2;
            this.Enable3DCheckBox.Location = new System.Drawing.Point(9, 8);
            this.Enable3DCheckBox.Name = "Enable3DCheckBox";
            this.Enable3DCheckBox.Size = new System.Drawing.Size(104, 24);
            this.Enable3DCheckBox.TabIndex = 0;
            this.Enable3DCheckBox.Text = "Enable 3D";
            this.Enable3DCheckBox.CheckedChanged += new System.EventHandler(this.Enable3DCheckBox_CheckedChanged);
            // 
            // NDataCursorToolUC
            // 
            this.Controls.Add(this.Enable3DCheckBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.VerticalAxisSnapModeComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.HorizontalAxisSnapModeComboBox);
            this.Controls.Add(this.YAxisTextBox);
            this.Controls.Add(this.XAxisTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "NDataCursorToolUC";
            this.Size = new System.Drawing.Size(180, 432);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.AutoRefresh = false;

			HorizontalAxisSnapModeComboBox.Items.Add("None");
			HorizontalAxisSnapModeComboBox.Items.Add("Ruler");
			HorizontalAxisSnapModeComboBox.Items.Add("Major ticks");
			HorizontalAxisSnapModeComboBox.Items.Add("Minor ticks");
			HorizontalAxisSnapModeComboBox.Items.Add("Ruler Min/Max");
            HorizontalAxisSnapModeComboBox.Items.Add("Nearest Value");

			VerticalAxisSnapModeComboBox.Items.Add("None");
			VerticalAxisSnapModeComboBox.Items.Add("Ruler");
			VerticalAxisSnapModeComboBox.Items.Add("Major ticks");
			VerticalAxisSnapModeComboBox.Items.Add("Minor ticks");
			VerticalAxisSnapModeComboBox.Items.Add("Ruler Min/Max");
            VerticalAxisSnapModeComboBox.Items.Add("Nearest Value");

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Data Cursor Tool");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // configure chart
			m_Chart = nChartControl1.Charts[0];
            m_Chart.Series.Clear();
            m_Chart.BoundsMode = BoundsMode.Stretch;

            m_Chart.Depth = 55.0f;
            m_Chart.Width = 55.0f;
            m_Chart.Height = 55.0f;

            m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = GetScaleConfigurator();
            m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = GetScaleConfigurator();
            m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = GetScaleConfigurator();

            m_Chart.Location = new NPointL(
                new NLength(10, NRelativeUnit.ParentPercentage),
                new NLength(12, NRelativeUnit.ParentPercentage));
            m_Chart.Size = new NSizeL(
                new NLength(80, NRelativeUnit.ParentPercentage),
                new NLength(78, NRelativeUnit.ParentPercentage));

            // add point series
            NPointSeries point1 = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);
            point1.Name = "Point 1";
            point1.PointShape = PointShape.Bar;
            point1.Size = new NLength(5, NGraphicsUnit.Point);
            point1.FillStyle = new NColorFillStyle(Color.Red);
            point1.BorderStyle.Color = Color.Pink;
            point1.DataLabelStyle.Visible = false;
            point1.UseXValues = true;
            point1.UseZValues = true;
            point1.InflateMargins = true;

            // fill with random data
            int itemCount = 70;
            point1.Values.FillRandomRange(Random, itemCount, 0, 50);
            point1.XValues.FillRandomRange(Random, itemCount, 0, 50);
            point1.ZValues.FillRandomRange(Random, itemCount, 0, 50);

            // add cursors
			m_HorizontalAxisCursor = new NAxisCursor();
			m_HorizontalAxisCursor.BeginEndAxis = (int)StandardAxis.PrimaryY;
			m_HorizontalAxisCursor.ValueChanged  += new EventHandler(OnValueChanged);

			m_VerticalAxisCursor = new NAxisCursor();
			m_VerticalAxisCursor.BeginEndAxis = (int)StandardAxis.PrimaryX;
			m_VerticalAxisCursor.ValueChanged  += new EventHandler(OnValueChanged);

            NAxis primaryXAxis = m_Chart.Axis(StandardAxis.PrimaryX);
            NAxis primaryYAxis = m_Chart.Axis(StandardAxis.PrimaryY);
            NAxis depthAxis = m_Chart.Axis(StandardAxis.Depth);

            primaryXAxis.Cursors.Add(m_HorizontalAxisCursor);
            primaryYAxis.Cursors.Add(m_VerticalAxisCursor);

            m_HorizontalAxisCursor.SynchronizeOnMouseAction = MouseAction.None;
            m_VerticalAxisCursor.SynchronizeOnMouseAction = MouseAction.None;

            nChartControl1.Controller.Selection.Add(m_Chart);
            nChartControl1.Controller.Tools.Add(new NDataCursorTool());

			MouseMoveCheckBox.Checked = true;
			HorizontalAxisSnapModeComboBox.SelectedIndex = 0;
			VerticalAxisSnapModeComboBox.SelectedIndex = 0;
		}

		private NLinearScaleConfigurator GetScaleConfigurator()
		{
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();

			linearScale.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific);
			linearScale.MinorTickCount = 4;

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			return linearScale;
		}

		//private NAxisValueSnapper GetAxisValueSnapperFromIndex(int index, NDataSeriesDouble dataSeries)
        private NAxisValueSnapper GetAxisValueSnapperFromIndex(int index, bool xValues)
		{
			switch (index)
			{
				case 0: //None, snapping is disabled
					return null;
				case 1: // Ruler, values are constrained to the ruler begin and end values.
					return new NAxisRulerClampSnapper();
				case 2: // Major ticks, values are snapped to axis major ticks
					return new NAxisMajorTickSnapper();
				case 3: // Minor ticks, values are snapped to axis minor ticks
					return new NAxisMinorTickSnapper();
				case 4: // Ruler Min Max, values are snapped to the ruler min and max values
					return new NAxisRulerMinMaxSnapper();
                case 5: // Neasest value snapper
                    NDataSeriesDouble dataSeries;
                    if (xValues)
                    {
                        dataSeries = ((NPointSeries)m_Chart.Series[0]).XValues;
                    }
                    else
                    {
                        dataSeries = ((NPointSeries)m_Chart.Series[0]).Values;
                    }

                    return new NNearestSeriesValueSnapper(dataSeries, false);
			}

			return null;
		}

		private void UpdateCursorFromControls()
		{
			m_HorizontalAxisCursor.ValueSnapper = GetAxisValueSnapperFromIndex(HorizontalAxisSnapModeComboBox.SelectedIndex, true);
			m_VerticalAxisCursor.ValueSnapper = GetAxisValueSnapperFromIndex(VerticalAxisSnapModeComboBox.SelectedIndex, false);

			if (MouseDownCheckBox.Checked)
			{
				m_HorizontalAxisCursor.SynchronizeOnMouseAction |= MouseAction.Down;
				m_VerticalAxisCursor.SynchronizeOnMouseAction |= MouseAction.Down;
			}

			if (MouseUpCheckBox.Checked)
			{
				m_HorizontalAxisCursor.SynchronizeOnMouseAction |= MouseAction.Up;
				m_VerticalAxisCursor.SynchronizeOnMouseAction |= MouseAction.Up;
			}

			if (MouseMoveCheckBox.Checked)
			{
				m_HorizontalAxisCursor.SynchronizeOnMouseAction |= MouseAction.Move;
				m_VerticalAxisCursor.SynchronizeOnMouseAction |= MouseAction.Move;
			}
		}

		private void OnValueChanged(object sender, EventArgs e)
		{
			XAxisTextBox.Text = m_HorizontalAxisCursor.Value.ToString();
			YAxisTextBox.Text = m_VerticalAxisCursor.Value.ToString();
		}

		private void HorizontalAxisSnapModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateCursorFromControls();
		}

		private void VerticalAxisSnapModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateCursorFromControls();
		}

		private void MouseDownCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateCursorFromControls();
		}

		private void MouseUpCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateCursorFromControls();
		}

		private void MouseMoveCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateCursorFromControls();
		}

        private void Enable3DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_Chart.Enable3D = Enable3DCheckBox.Checked;

            if (m_Chart.Enable3D)
            {
                m_Chart.BoundsMode = BoundsMode.Fit;
            }
            else
            {
                m_Chart.BoundsMode = BoundsMode.Stretch;
            }

            nChartControl1.Refresh();
        }
	}
}
