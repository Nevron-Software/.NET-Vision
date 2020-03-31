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


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NAnnotationDragToolUC : NExampleBaseUC
	{
		private System.ComponentModel.Container components = null;
		private NRectangularCallout m_Callout1;
		private UI.WinForm.Controls.NCheckBox AllowDragAnnotation1CheckBox;
		private UI.WinForm.Controls.NCheckBox AllowDragAnnotation2CheckBox;
		private NRectangularCallout m_Callout2;

		public NAnnotationDragToolUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.AllowDragAnnotation1CheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.AllowDragAnnotation2CheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// AllowDragAnnotation1CheckBox
			// 
			this.AllowDragAnnotation1CheckBox.ButtonProperties.BorderOffset = 2;
			this.AllowDragAnnotation1CheckBox.Location = new System.Drawing.Point(3, 0);
			this.AllowDragAnnotation1CheckBox.Name = "AllowDragAnnotation1CheckBox";
			this.AllowDragAnnotation1CheckBox.Size = new System.Drawing.Size(152, 24);
			this.AllowDragAnnotation1CheckBox.TabIndex = 12;
			this.AllowDragAnnotation1CheckBox.Text = "Allow Drag Annotation 1";
			this.AllowDragAnnotation1CheckBox.CheckedChanged += new System.EventHandler(this.AllowDragAnnotation1CheckBox_CheckedChanged);
			// 
			// AllowDragAnnotation2CheckBox
			// 
			this.AllowDragAnnotation2CheckBox.ButtonProperties.BorderOffset = 2;
			this.AllowDragAnnotation2CheckBox.Location = new System.Drawing.Point(3, 30);
			this.AllowDragAnnotation2CheckBox.Name = "AllowDragAnnotation2CheckBox";
			this.AllowDragAnnotation2CheckBox.Size = new System.Drawing.Size(152, 24);
			this.AllowDragAnnotation2CheckBox.TabIndex = 13;
			this.AllowDragAnnotation2CheckBox.Text = "Allow Drag Annotation 2";
			this.AllowDragAnnotation2CheckBox.CheckedChanged += new System.EventHandler(this.AllowDragAnnotation2CheckBox_CheckedChanged);
			// 
			// NAnnotationDragToolUC
			// 
			this.Controls.Add(this.AllowDragAnnotation2CheckBox);
			this.Controls.Add(this.AllowDragAnnotation1CheckBox);
			this.Name = "NAnnotationDragToolUC";
			this.Size = new System.Drawing.Size(180, 358);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Annotation Drag Tool");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// configure the x scale
			NLinearScaleConfigurator xScale = new NLinearScaleConfigurator();
			xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale;

			// configure the y scale
			NLinearScaleConfigurator yScale = new NLinearScaleConfigurator();

			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			yScale.StripStyles.Add(stripStyle);

			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = yScale;

			// Create a point series
			NPointSeries point = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point.InflateMargins = true;
			point.UseXValues = true;
			point.Name = "Series 1";
			point.DataLabelStyle.Visible = false;

			// Add some data
			point.Values.Add(31);
			point.Values.Add(67);
			point.Values.Add(12);
			point.Values.Add(84);
			point.Values.Add(90);

			point.XValues.Add(5);
			point.XValues.Add(36);
			point.XValues.Add(51);
			point.XValues.Add(76);
			point.XValues.Add(93);

			m_Callout1 = new NRectangularCallout();
			m_Callout1.UseAutomaticSize = true;
			m_Callout1.Text = "Annotation 1";
			m_Callout1.Orientation = 125;
			m_Callout1.ArrowLength = new NLength(40, NGraphicsUnit.Point);
			m_Callout1.Anchor = new NScalePointAnchor(chart, (int)StandardAxis.PrimaryX, (int)StandardAxis.PrimaryY, (int)StandardAxis.Depth, AxisValueAnchorMode.Clip, new Nevron.GraphicsCore.NVector3DD(36, 67, 0));
			chart.ChildPanels.Add(m_Callout1);

			m_Callout2 = new NRectangularCallout();
			m_Callout2.UseAutomaticSize = true;
			m_Callout2.Text = "Annotation 2";
			m_Callout1.Orientation = 45;
			m_Callout2.ArrowLength = new NLength(40, NGraphicsUnit.Point);
			m_Callout2.Anchor = new NScalePointAnchor(chart, (int)StandardAxis.PrimaryX, (int)StandardAxis.PrimaryY, (int)StandardAxis.Depth, AxisValueAnchorMode.Clip, new Nevron.GraphicsCore.NVector3DD(76, 84, 0));
			chart.ChildPanels.Add(m_Callout2);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			nChartControl1.Controller.Tools.Add(new NSelectorTool());
			nChartControl1.Controller.Tools.Add(new NCalloutDragTool());

			AllowDragAnnotation1CheckBox.Checked = true;
			AllowDragAnnotation2CheckBox.Checked = true;
		}

		private void AllowDragAnnotation1CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_Callout1.AllowDragging = AllowDragAnnotation1CheckBox.Checked;
		}

		private void AllowDragAnnotation2CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_Callout2.AllowDragging = AllowDragAnnotation2CheckBox.Checked;
		}
	}
}
