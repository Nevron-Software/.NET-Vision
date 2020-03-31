using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Resources;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.Functions;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NAnnotationsGeneralUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NLegend m_Legend;
		private NBarSeries m_Bar;
		private NLineSeries m_Line;
		private NRectangularCallout m_RectangularCallout;
		private NRoundedRectangularCallout m_RoundedRectangularCallout;
		private NCutEdgeRectangularCallout m_CutEdgeRectangularCallout;
		private NOvalCallout m_OvalCallout;
		private NArrowAnnotation m_ArrowAnnotation;

		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NComboBox CurrentAnnotationComboBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PropertyGrid AnnotationPropertyGrid;
		private System.ComponentModel.Container components = null;

		public NAnnotationsGeneralUC()
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
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.AnnotationPropertyGrid = new System.Windows.Forms.PropertyGrid();
			this.label2 = new System.Windows.Forms.Label();
			this.CurrentAnnotationComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.AnnotationPropertyGrid);
			this.groupBox1.Location = new System.Drawing.Point(8, 64);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(296, 496);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Annotation properties";
			// 
			// AnnotationPropertyGrid
			// 
			this.AnnotationPropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.AnnotationPropertyGrid.Location = new System.Drawing.Point(8, 16);
			this.AnnotationPropertyGrid.Name = "AnnotationPropertyGrid";
			this.AnnotationPropertyGrid.Size = new System.Drawing.Size(280, 472);
			this.AnnotationPropertyGrid.TabIndex = 0;
			this.AnnotationPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.AnnotationPropertyGrid_PropertyValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Current annotation:";
			// 
			// CurrentAnnotationComboBox
			// 
			this.CurrentAnnotationComboBox.ListProperties.CheckBoxDataMember = "";
			this.CurrentAnnotationComboBox.ListProperties.DataSource = null;
			this.CurrentAnnotationComboBox.ListProperties.DisplayMember = "";
			this.CurrentAnnotationComboBox.Location = new System.Drawing.Point(8, 32);
			this.CurrentAnnotationComboBox.Name = "CurrentAnnotationComboBox";
			this.CurrentAnnotationComboBox.Size = new System.Drawing.Size(296, 21);
			this.CurrentAnnotationComboBox.TabIndex = 4;
			this.CurrentAnnotationComboBox.SelectedIndexChanged += new System.EventHandler(this.CurrentAnnotationComboBox_SelectedIndexChanged);
			// 
			// NAnnotationsGeneralUC
			// 
			this.Controls.Add(this.CurrentAnnotationComboBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox1);
			this.Name = "NAnnotationsGeneralUC";
			this.Size = new System.Drawing.Size(312, 658);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			ConfigureChart();
			ConfigureAnnotations();

			CurrentAnnotationComboBox.Items.Add("RectangularCallout");
			CurrentAnnotationComboBox.Items.Add("RoundedRectangularCallout");
			CurrentAnnotationComboBox.Items.Add("CutEdgeRectangularCallout");
			CurrentAnnotationComboBox.Items.Add("OvalCallout");
			CurrentAnnotationComboBox.Items.Add("ArrowAnnotation");
			CurrentAnnotationComboBox.SelectedIndex = 0;
		}

		private void ConfigureChart()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Annotations");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.TextStyle.TextFormat = TextFormat.XML;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			m_Legend = nChartControl1.Legends[0];

			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// add the line series
			m_Line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line.Name = "Cumulative";
			m_Line.DataLabelStyle.Visible = false;
			m_Line.MarkerStyle.Visible = true;
			m_Line.MarkerStyle.PointShape = PointShape.Cylinder;
			m_Line.MarkerStyle.FillStyle = new NColorFillStyle(Color.LimeGreen);
			m_Line.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			m_Line.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			m_Line.ShadowStyle.Type = ShadowType.GaussianBlur;
			m_Line.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
			m_Line.ShadowStyle.Offset = new NPointL(2, 2);
			m_Line.ShadowStyle.FadeLength = new NLength(4);

			// add the bar series
			m_Bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar.Name = "Bar Series";
			m_Bar.DataLabelStyle.Visible = false;
			m_Bar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			m_Bar.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.DarkBlue, Color.CornflowerBlue);
			m_Bar.ShadowStyle.Type = ShadowType.GaussianBlur;
			m_Bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
			m_Bar.ShadowStyle.Offset = new NPointL(3, 3);
			m_Bar.ShadowStyle.FadeLength = new NLength(4);

			// fill with random data and sort in descending order
			m_Bar.Values.FillRandom(Random, 10);
			m_Bar.Values.Sort(DataSeriesSortOrder.Descending);

			// generate a data series cumulative sum of the bar values
			NFunctionCalculator fc = new NFunctionCalculator();
			fc.Expression = "CUMSUM(Value)";
			fc.Arguments.Add(m_Bar.Values);
			m_Line.Values = fc.Calculate();
		}
		private String GetTextForAnnotation(NAnchorPanel annotation)
		{
			String sText = "";

			if (annotation is NRectangularCallout)
			{
				sText = "This is a rectangular callout panel \r\n";
			}
			else if (annotation is NRoundedRectangularCallout)
			{
				sText = "This is a rounded rectangular callout panel \r\n";
			}
			else if (annotation is NCutEdgeRectangularCallout)
			{
				sText = "This is a cut edge rectangular callout panel \r\n";
			}
			else if (annotation is NOvalCallout)
			{
				sText = "This is an oval callout panel \r\n";
			}
			else if (annotation is NArrowAnnotation)
			{
				sText = "This is an arrow annotation \r\n";
			}
            else if (annotation is NArrowCallout)
            {
                sText = "This is an arrow callout";
            }
            else
            {
                Debug.Assert(false);
            }

			return sText + GetTextForAnchor(annotation.Anchor);
		}
		private string GetTextForAnchor(NAnchor anchor)
		{
			String sText = "attached to ";

			if (anchor is NAxisValueAnchor)
			{
				sText += "an axis value.";
			}
			else if (anchor is NDataPointAnchor)
			{
				sText += "a chart data point.";
			}
			else if (anchor is NLegendDataItemAnchor)
			{
				sText += "a legend data point.";
			}
			else if (anchor is NModelPointAnchor)
			{
				sText += "a model point.";
			}
			else if (anchor is NScalePointAnchor)
			{
				sText += "a scale point.";
			}
			else 
			{
				Debug.Assert(false);
			}

			return sText;
		}
		private void ConfigureAnnotations()
		{
            m_RectangularCallout = new NRectangularCallout();
			m_RectangularCallout.ArrowLength = new NLength(15, NRelativeUnit.ParentPercentage);
			m_RectangularCallout.FillStyle = new NGradientFillStyle(Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.CadetBlue));
			m_RectangularCallout.UseAutomaticSize = true;
			m_RectangularCallout.Orientation = 225;
			m_RectangularCallout.Anchor = new NDataPointAnchor(m_Bar, 2, ContentAlignment.MiddleCenter, StringAlignment.Center);
			m_RectangularCallout.Text = GetTextForAnnotation(m_RectangularCallout);
			nChartControl1.Panels.Add(m_RectangularCallout);

			m_RoundedRectangularCallout = new NRoundedRectangularCallout();
			m_RoundedRectangularCallout.ArrowLength = new NLength(15, NRelativeUnit.ParentPercentage);
			m_RoundedRectangularCallout.FillStyle = new NGradientFillStyle(Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.LightGreen));
			m_RoundedRectangularCallout.UseAutomaticSize = true;
			m_RoundedRectangularCallout.Orientation = 135;
			m_RoundedRectangularCallout.Anchor = new NModelPointAnchor(m_Chart, new NVector3DF(0, 0, 0));
			m_RoundedRectangularCallout.Text = GetTextForAnnotation(m_RoundedRectangularCallout);
			nChartControl1.Panels.Add(m_RoundedRectangularCallout);

			m_CutEdgeRectangularCallout = new NCutEdgeRectangularCallout();
			m_CutEdgeRectangularCallout.FillStyle = new NGradientFillStyle(Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.LightBlue));
			m_CutEdgeRectangularCallout.ArrowLength = new NLength(40, NRelativeUnit.ParentPercentage);
			m_CutEdgeRectangularCallout.UseAutomaticSize = true;
			m_CutEdgeRectangularCallout.Orientation = 190;
			m_CutEdgeRectangularCallout.Anchor = new NLegendDataItemAnchor(m_Legend, 1);
			m_CutEdgeRectangularCallout.Text = GetTextForAnnotation(m_CutEdgeRectangularCallout);
			nChartControl1.Panels.Add(m_CutEdgeRectangularCallout);

			m_OvalCallout = new NOvalCallout();
			m_OvalCallout.FillStyle = new NColorFillStyle(Color.FromArgb(200, Color.AliceBlue));
			m_OvalCallout.ArrowLength = new NLength(15, NRelativeUnit.ParentPercentage);
			m_OvalCallout.UseAutomaticSize = true;
			m_OvalCallout.Orientation = 315;
			m_OvalCallout.Anchor = new NScalePointAnchor(	m_Chart, 
															(int)StandardAxis.PrimaryX, 
															(int)StandardAxis.PrimaryY,
															(int)StandardAxis.Depth,
															AxisValueAnchorMode.Clip, new NVector3DD(7, 100, 0));

			m_OvalCallout.Text = GetTextForAnnotation(m_OvalCallout);
			nChartControl1.Panels.Add(m_OvalCallout);

    	    m_ArrowAnnotation = new NArrowAnnotation();
			m_ArrowAnnotation.UseAutomaticSize = true;
			m_ArrowAnnotation.ArrowHeadWidthPercent = 30;
			m_ArrowAnnotation.TextStyle.FontStyle.EmSize = new NLength(11, NGraphicsUnit.Point);
			m_ArrowAnnotation.TextStyle.FontStyle.Style |= FontStyle.Bold;
			m_ArrowAnnotation.Orientation = 45;
			m_ArrowAnnotation.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant1, Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.Orange));
			m_ArrowAnnotation.Anchor = new NDataPointAnchor(m_Bar, 4, ContentAlignment.MiddleCenter, StringAlignment.Center);
			m_ArrowAnnotation.Text = GetTextForAnnotation(m_ArrowAnnotation);
			nChartControl1.Panels.Add(m_ArrowAnnotation);

            nChartControl1.Controller.Selection.Clear();
			nChartControl1.Controller.Selection.Add(m_Chart);

			nChartControl1.Controller.Tools.Add(new NTrackballTool());
		}

		private void CurrentAnnotationComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch (CurrentAnnotationComboBox.SelectedIndex)
			{
				case 0: // RectangularCallout
					AnnotationPropertyGrid.SelectedObject = m_RectangularCallout;
					break;
				case 1: // RoundedRectangularCallout
					AnnotationPropertyGrid.SelectedObject = m_RoundedRectangularCallout;
					break;
				case 2: // CutEdgeRectangularCallout
					AnnotationPropertyGrid.SelectedObject = m_CutEdgeRectangularCallout;
					break;
				case 3: // OvalCallout
					AnnotationPropertyGrid.SelectedObject = m_OvalCallout;
					break;
				case 4: // ArrowAnnotation
					AnnotationPropertyGrid.SelectedObject = m_ArrowAnnotation;
					break;
			}
		}
		private void AnnotationPropertyGrid_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
		{
			nChartControl1.Refresh();
		}
	}
}
