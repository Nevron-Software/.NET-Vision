using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NVolumeSelectionToolUC : NExampleBaseUC
	{
		private UI.WinForm.Controls.NComboBox ActiveToolComboBox;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.Container components = null;


		public NVolumeSelectionToolUC()
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
			this.ActiveToolComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ActiveToolComboBox
			// 
			this.ActiveToolComboBox.ListProperties.CheckBoxDataMember = "";
			this.ActiveToolComboBox.ListProperties.DataSource = null;
			this.ActiveToolComboBox.ListProperties.DisplayMember = "";
			this.ActiveToolComboBox.Location = new System.Drawing.Point(2, 27);
			this.ActiveToolComboBox.Name = "ActiveToolComboBox";
			this.ActiveToolComboBox.Size = new System.Drawing.Size(157, 21);
			this.ActiveToolComboBox.TabIndex = 5;
			this.ActiveToolComboBox.SelectedIndexChanged += new System.EventHandler(this.ActiveToolComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(2, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Active Tool:";
			// 
			// NVolumeSelectionToolUC
			// 
			this.Controls.Add(this.ActiveToolComboBox);
			this.Controls.Add(this.label1);
			this.Name = "NVolumeSelectionToolUC";
			this.Size = new System.Drawing.Size(180, 664);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("Volume Selection Tool");
            title.DockMode = PanelDockMode.Top;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
            nChartControl1.Panels.Add(title);

			NChart chart = nChartControl1.Charts[0];

			chart.Enable3D = true;
			chart.BoundsMode = BoundsMode.Fit;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = new NLinearScaleConfigurator();
			chart.Width = chart.Height = chart.Depth = 50;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);

			NPointSeries point = new NPointSeries();
			point.UseXValues = true;
			point.UseZValues = true;
			point.DataLabelStyle.Visible = false;
			point.InflateMargins = true;

			Random rand = new Random();

			for (int i = 0; i < 100; i++)
			{
				point.Values.Add(rand.Next(100));
				point.XValues.Add(rand.Next(100));
				point.ZValues.Add(rand.Next(100));
			}

			chart.Series.Add(point);

			ActiveToolComboBox.Items.Add("Trackball");
			ActiveToolComboBox.Items.Add("Volume Selector");
			ActiveToolComboBox.SelectedIndex = 1;
		}

		private void ActiveToolComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			nChartControl1.Controller.Selection.SelectedObjects.Clear();
			nChartControl1.Controller.Tools.Clear();

			switch (ActiveToolComboBox.SelectedIndex)
			{
				case 0:
					nChartControl1.Controller.Selection.SelectedObjects.Add(nChartControl1.Charts[0]);
					nChartControl1.Controller.Tools.Add(new NTrackballTool());
					break;
				case 1:
					NVolumeSelectorTool volumeSelectionTool = new NVolumeSelectorTool();
					volumeSelectionTool.EndDrag += VolumeSelectionTool_EndDrag;
					nChartControl1.Controller.Tools.Add(volumeSelectionTool);
					break;
			}
		}

		private void VolumeSelectionTool_EndDrag(object sender, EventArgs e)
		{
			NPointSeries point = (NPointSeries)nChartControl1.Charts[0].Series[0];
			NVolumeSelectorTool volumeTool = (NVolumeSelectorTool)sender;
			for (int i = 0; i < point.Values.Count; i++)
			{
				NVector3DD vec = new NVector3DD((float)(double)point.XValues[i], (float)(double)point.Values[i], (float)(double)point.ZValues[i]);
				if (volumeTool.TopPlane.Distance(ref vec) < 0 &&
					  volumeTool.RightPlane.Distance(ref vec) < 0 &&
					  volumeTool.BottomPlane.Distance(ref vec) < 0 &&
					  volumeTool.LeftPlane.Distance(ref vec) < 0)
				{
					// point is contained in the set
					point.FillStyles[i] = new NColorFillStyle(Color.Red);
				}
			}

			nChartControl1.Refresh();
		}
	}
}
