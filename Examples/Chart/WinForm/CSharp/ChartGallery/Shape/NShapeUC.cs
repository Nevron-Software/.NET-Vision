using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NShapeUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NShapeSeries m_Shape;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox ShapeCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox UseXValuesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox UseZValuesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox DifferentColorsCheck;
		private Nevron.UI.WinForm.Controls.NButton ShapesColorButton;
		private Nevron.UI.WinForm.Controls.NButton ShapesBorderButton;
		private System.ComponentModel.Container components = null;

		public NShapeUC()
		{
			InitializeComponent();

			ShapeCombo.FillFromEnum(typeof(BarShape));
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
			this.label1 = new System.Windows.Forms.Label();
			this.ShapeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.UseXValuesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.UseZValuesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShapesColorButton = new Nevron.UI.WinForm.Controls.NButton();
			this.DifferentColorsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShapesBorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(170, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Shape:";
			// 
			// ShapeCombo
			// 
			this.ShapeCombo.ListProperties.CheckBoxDataMember = "";
			this.ShapeCombo.ListProperties.DataSource = null;
			this.ShapeCombo.ListProperties.DisplayMember = "";
			this.ShapeCombo.Location = new System.Drawing.Point(5, 26);
			this.ShapeCombo.Name = "ShapeCombo";
			this.ShapeCombo.Size = new System.Drawing.Size(170, 21);
			this.ShapeCombo.TabIndex = 1;
			this.ShapeCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			// 
			// UseXValuesCheck
			// 
			this.UseXValuesCheck.ButtonProperties.BorderOffset = 2;
			this.UseXValuesCheck.Location = new System.Drawing.Point(5, 54);
			this.UseXValuesCheck.Name = "UseXValuesCheck";
			this.UseXValuesCheck.Size = new System.Drawing.Size(170, 21);
			this.UseXValuesCheck.TabIndex = 2;
			this.UseXValuesCheck.Text = "Use X Values";
			this.UseXValuesCheck.CheckedChanged += new System.EventHandler(this.UseXValuesCheck_CheckedChanged);
			// 
			// UseZValuesCheck
			// 
			this.UseZValuesCheck.ButtonProperties.BorderOffset = 2;
			this.UseZValuesCheck.Location = new System.Drawing.Point(5, 80);
			this.UseZValuesCheck.Name = "UseZValuesCheck";
			this.UseZValuesCheck.Size = new System.Drawing.Size(170, 19);
			this.UseZValuesCheck.TabIndex = 3;
			this.UseZValuesCheck.Text = "Use Z Values";
			this.UseZValuesCheck.CheckedChanged += new System.EventHandler(this.UseZValuesCheck_CheckedChanged);
			// 
			// ShapesColorButton
			// 
			this.ShapesColorButton.Location = new System.Drawing.Point(5, 136);
			this.ShapesColorButton.Name = "ShapesColorButton";
			this.ShapesColorButton.Size = new System.Drawing.Size(170, 23);
			this.ShapesColorButton.TabIndex = 5;
			this.ShapesColorButton.Text = "Shapes Fill Style...";
			this.ShapesColorButton.Click += new System.EventHandler(this.ShapesColorButton_Click);
			// 
			// DifferentColorsCheck
			// 
			this.DifferentColorsCheck.ButtonProperties.BorderOffset = 2;
			this.DifferentColorsCheck.Location = new System.Drawing.Point(5, 104);
			this.DifferentColorsCheck.Name = "DifferentColorsCheck";
			this.DifferentColorsCheck.Size = new System.Drawing.Size(170, 21);
			this.DifferentColorsCheck.TabIndex = 4;
			this.DifferentColorsCheck.Text = "Different Colors";
			this.DifferentColorsCheck.CheckedChanged += new System.EventHandler(this.DifferentColorsCheck_CheckedChanged);
			// 
			// ShapesBorderButton
			// 
			this.ShapesBorderButton.Location = new System.Drawing.Point(5, 166);
			this.ShapesBorderButton.Name = "ShapesBorderButton";
			this.ShapesBorderButton.Size = new System.Drawing.Size(170, 23);
			this.ShapesBorderButton.TabIndex = 6;
			this.ShapesBorderButton.Text = "Shapes Border...";
			this.ShapesBorderButton.Click += new System.EventHandler(this.ShapesBorderButton_Click);
			// 
			// NShapeUC
			// 
			this.Controls.Add(this.ShapesBorderButton);
			this.Controls.Add(this.DifferentColorsCheck);
			this.Controls.Add(this.ShapesColorButton);
			this.Controls.Add(this.UseZValuesCheck);
			this.Controls.Add(this.UseXValuesCheck);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ShapeCombo);
			this.Name = "NShapeUC";
			this.Size = new System.Drawing.Size(180, 227);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Shape Series");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
            m_Chart.Projection.Elevation -= 10;
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			m_Chart.Depth = 55.0f;
			m_Chart.Width = 55.0f;
			m_Chart.Height = 55.0f;

			// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back, ChartWallType.Floor };
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back, ChartWallType.Left };
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

            // add interlaced stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back, ChartWallType.Left };
            stripStyle.Interlaced = true;
            scaleY.StripStyles.Add(stripStyle);

			// setup Z axis
			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ;
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Left, ChartWallType.Floor };
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// setup shape series
			m_Shape = (NShapeSeries)m_Chart.Series.Add(SeriesType.Shape);
			m_Shape.FillStyle = new NColorFillStyle(Color.Red);
			m_Shape.BorderStyle.Color = Color.DarkRed;
			m_Shape.DataLabelStyle.Visible = false;
			m_Shape.UseXValues = true;
			m_Shape.UseZValues = true;

            // populate with random data
			m_Shape.Values.FillRandomRange(Random, 10, -100, 100);
			m_Shape.XValues.FillRandomRange(Random, 10, -100, 100);
			m_Shape.ZValues.FillRandomRange(Random, 10, -100, 100);

			m_Shape.YSizes.FillRandomRange(Random, 10, 5, 20);
			m_Shape.XSizes.FillRandomRange(Random, 10, 5, 20);
			m_Shape.ZSizes.FillRandomRange(Random, 10, 5, 20);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

			// init form controls
			ShapeCombo.SelectedIndex = 0;
			UseXValuesCheck.Checked = true;
			UseZValuesCheck.Checked = true;
            DifferentColorsCheck.Checked = true;
		}

		private void StyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Shape.Shape = (BarShape)ShapeCombo.SelectedIndex;
			nChartControl1.Refresh();
		}
		private void UseXValuesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (UseXValuesCheck.Checked)
			{
				m_Shape.UseXValues = true;
			}
			else
			{
				m_Shape.UseXValues = false;
			}

			nChartControl1.Refresh();
		}
		private void UseZValuesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (UseZValuesCheck.Checked)
			{
				m_Shape.UseZValues = true;
			}
			else
			{
				m_Shape.UseZValues = false;
			}

			nChartControl1.Refresh();
		}
		private void DifferentColorsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (DifferentColorsCheck.Checked)
			{
                // apply style sheet
				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
                styleSheet.Apply(nChartControl1.Document);

				ShapesColorButton.Enabled = false;
				ShapesBorderButton.Enabled = false;
			}
			else
			{
                // apply style sheet
                NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
                styleSheet.Apply(nChartControl1.Document);

				ShapesColorButton.Enabled = true;
				ShapesBorderButton.Enabled = true;
			}

			nChartControl1.Refresh();
		}
		private void ShapesColorButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_Shape.FillStyle, out fillStyleResult))
			{
				m_Shape.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void ShapesBorderButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Shape.BorderStyle, out strokeStyleResult))
			{
				m_Shape.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
	}
}
