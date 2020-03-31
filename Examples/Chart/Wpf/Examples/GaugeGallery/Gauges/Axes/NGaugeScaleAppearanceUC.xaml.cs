using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.Editors;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// Interaction logic for NGaugeScaleAppearanceUC.xaml
	/// </summary>
	public partial class NGaugeScaleAppearanceUC : NExampleBaseUC
	{
		NGaugeAxis m_Axis;
		bool m_Updating;

		public NGaugeScaleAppearanceUC()
		{
			InitializeComponent();
		}

		public override string Title
		{
			get
			{
				return "Scale Appearance";
			}
		}

		public override string Description
		{
			get
			{
				return "This example demonstrates the built in scale configurations of the gauge axis.\r\n" +
						"Use the controls on the right panel to adjust the properties of the different scale elemements";
			}
		}

		public override void Create()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Gauge Axis Scale Appearance");
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			nChartControl1.Panels.Add(header);

			// create the radial gauge
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();

			radialGauge.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			radialGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
			radialGauge.BackgroundFillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Gray);
			radialGauge.PaintEffect = new NGlassEffectStyle();
			radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
			radialGauge.PositionChildPanelsInContentBounds = true;

			nChartControl1.Panels.Add(radialGauge);

			m_Axis = (NGaugeAxis)radialGauge.Axes[0];
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Axis.ScaleConfigurator;
			scale.MinorTickCount = 3;

			NRangeIndicator indicator1 = new NRangeIndicator();
			indicator1.Value = 80;
			indicator1.OriginMode = OriginMode.ScaleMax;
			indicator1.FillStyle = new NColorFillStyle(Color.Red);
			indicator1.StrokeStyle.Color = Color.DarkRed;
			radialGauge.Indicators.Add(indicator1);

			NNeedleValueIndicator indicator2 = new NNeedleValueIndicator();
			indicator2.Value = 79;
			indicator2.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			indicator2.Shape.StrokeStyle.Color = Color.Red;
			radialGauge.Indicators.Add(indicator2);
			radialGauge.SweepAngle = 270;

			m_Updating = true;

			NExampleHelpers.FillComboWithEnumValues(MinorTickShapeComboBox, typeof(ScaleTickShape));
			NExampleHelpers.FillComboWithEnumValues(MajorTickShapeComboBox, typeof(ScaleTickShape));
			NExampleHelpers.FillComboWithEnumValues(PredefinedScaleStyleComboBox, typeof(PredefinedScaleStyle));
			PredefinedScaleStyleComboBox.SelectedIndex = (int)PredefinedScaleStyle.Standard;

			NExampleHelpers.BindComboToItemSource(RulerOffsetComboBox, 0, 20, 1);
			RulerOffsetComboBox.SelectedItem = 0;

			NExampleHelpers.BindComboToItemSource(RulerLengthComboBox, 0, 20, 1);
			RulerLengthComboBox.SelectedItem = 2;

			NExampleHelpers.BindComboToItemSource(MajorTicksLengthComboBox, 0, 20, 1);
			MajorTicksLengthComboBox.SelectedItem = 3;

			NExampleHelpers.BindComboToItemSource(MajorTicksWidthComboBox, 0, 20, 1);
			MajorTicksWidthComboBox.SelectedItem = 2;

			NExampleHelpers.BindComboToItemSource(MajorTicksOffsetComboBox, 0, 20, 1);
			MajorTicksOffsetComboBox.SelectedItem = 0;

			NExampleHelpers.BindComboToItemSource(MinorTicksLengthComboBox, 0, 20, 1);
			MinorTicksLengthComboBox.SelectedItem = 3;

			NExampleHelpers.BindComboToItemSource(MinorTicksWidthComboBox, 0, 20, 1);
			MinorTicksWidthComboBox.SelectedItem = 2;

			NExampleHelpers.BindComboToItemSource(MinorTicksOffsetComboBox, 0, 20, 1);
			MinorTicksOffsetComboBox.SelectedItem = 0;


			m_Updating = false;

			InitFormControls();
		}

		private void InitFormControls()
		{
			if (m_Updating)
				return;

			m_Updating = true;

			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Axis.ScaleConfigurator;
			RulerLengthComboBox.SelectedItem = (int)scale.RulerStyle.Height.Value;
			RulerOffsetComboBox.SelectedItem = (int)scale.RulerStyle.Offset.Value;

			MajorTicksOffsetComboBox.SelectedItem = (int)scale.OuterMajorTickStyle.Offset.Value;
			MajorTicksLengthComboBox.SelectedItem = (int)scale.OuterMajorTickStyle.Length.Value;
			MajorTicksWidthComboBox.SelectedItem = (int)scale.OuterMajorTickStyle.Width.Value;
			MajorTickShapeComboBox.SelectedIndex = (int)scale.OuterMajorTickStyle.Shape;

			MinorTicksOffsetComboBox.SelectedItem = (int)scale.OuterMinorTickStyle.Offset.Value;
			MinorTicksWidthComboBox.SelectedItem = (int)scale.OuterMinorTickStyle.Width.Value;
			MinorTicksLengthComboBox.SelectedItem = (int)scale.OuterMinorTickStyle.Length.Value;
			MinorTickShapeComboBox.SelectedIndex = (int)scale.OuterMinorTickStyle.Shape;

			m_Updating = false;
		}

		private void UpdateScale()
		{
			if (m_Updating)
				return;

			m_Updating = true;

			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Axis.ScaleConfigurator;
			scale.RulerStyle.Height = new NLength((int)RulerLengthComboBox.SelectedItem);
			scale.RulerStyle.Offset = new NLength((int)RulerOffsetComboBox.SelectedItem);

			scale.OuterMajorTickStyle.Offset = new NLength((int)MajorTicksOffsetComboBox.SelectedItem);
			scale.OuterMajorTickStyle.Length = new NLength((int)MajorTicksLengthComboBox.SelectedItem);
			scale.OuterMajorTickStyle.Width = new NLength((int)MajorTicksWidthComboBox.SelectedItem);
			scale.OuterMajorTickStyle.Shape = (ScaleTickShape)MajorTickShapeComboBox.SelectedIndex;

			scale.OuterMinorTickStyle.Offset = new NLength((int)MinorTicksOffsetComboBox.SelectedItem);
			scale.OuterMinorTickStyle.Width = new NLength((int)MinorTicksWidthComboBox.SelectedItem);
			scale.OuterMinorTickStyle.Length = new NLength((int)MinorTicksLengthComboBox.SelectedItem);
			scale.OuterMinorTickStyle.Shape = (ScaleTickShape)MinorTickShapeComboBox.SelectedIndex;

			m_Updating = false;

			nChartControl1.Refresh();
		}

		private void PredefinedScaleStyleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateScale();
		}

		private void RulerOffset_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateScale();
		}

		private void RulerLength_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateScale();
		}

		private void RulerLengthComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateScale();
		}

		private void RulerOffsetComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateScale();
		}

		private void MajorTickShapeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateScale();
		}

		private void MajorTicksWidthComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateScale();
		}

		private void MajorTicksLengthComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateScale();
		}

		private void MajorTicksOffsetComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateScale();
		}

		private void MinorTicksWidthComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateScale();
		}

		private void MinorTicksLengthComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateScale();
		}

		private void MinorTicksOffsetComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateScale();
		}

		private void MinorTickShapeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateScale();
		}

		private void RulerFillStyleButton_Click(object sender, RoutedEventArgs e)
		{
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Axis.ScaleConfigurator;
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(scale.RulerStyle.FillStyle, out fillStyleResult))
			{
				scale.RulerStyle.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void RulerStrokeStyleButton_Click(object sender, RoutedEventArgs e)
		{
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Axis.ScaleConfigurator;
			NStrokeStyle stokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(scale.RulerStyle.BorderStyle, out stokeStyleResult))
			{
				scale.RulerStyle.BorderStyle = stokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void MajorTicksFillStyleButton_Click(object sender, RoutedEventArgs e)
		{
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Axis.ScaleConfigurator;
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(scale.OuterMajorTickStyle.FillStyle, out fillStyleResult))
			{
				scale.OuterMajorTickStyle.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void MajorTicksStrokeStyleButton_Click(object sender, RoutedEventArgs e)
		{
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Axis.ScaleConfigurator;
			NStrokeStyle stokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(scale.OuterMajorTickStyle.LineStyle, out stokeStyleResult))
			{
				scale.OuterMajorTickStyle.LineStyle = stokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void MinorTicksFillStyleButton_Click(object sender, RoutedEventArgs e)
		{
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Axis.ScaleConfigurator;
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(scale.OuterMinorTickStyle.FillStyle, out fillStyleResult))
			{
				scale.OuterMinorTickStyle.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void MinorTicksStrokeStyleButton_Click(object sender, RoutedEventArgs e)
		{
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Axis.ScaleConfigurator;
			NStrokeStyle stokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(scale.OuterMinorTickStyle.LineStyle, out stokeStyleResult))
			{
				scale.OuterMinorTickStyle.LineStyle = stokeStyleResult;
				nChartControl1.Refresh();
			}
		}
	}
}
