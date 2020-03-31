using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			this.Loaded +=new RoutedEventHandler(MainWindow_Loaded);
		}

		void  MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			NFolderTreeNode realTimeExamples = new NFolderTreeNode("Realtime");
			ExamplesTreeView.Items.Add(realTimeExamples);

			{
				realTimeExamples.AddExample("Real Time Polar", typeof(NRealTimePolarUC));
				realTimeExamples.AddExample("Real Time Line", typeof(NRealTimeLineUC));
				realTimeExamples.AddExample("Real Time Area", typeof(NRealTimeAreaUC));
				realTimeExamples.AddExample("Real Time Bar", typeof(NRealTimeBarUC));
				realTimeExamples.AddExample("Real Time Point", typeof(NRealTimePointUC));
				realTimeExamples.AddExample("Real Time Stock", typeof(NRealTimeStockUC));
				realTimeExamples.AddExample("Real Time Surface", typeof(NRealTimeSurfaceUC));
			}

			NFolderTreeNode chartGallery = new NFolderTreeNode("Chart Gallery");
			ExamplesTreeView.Items.Add(chartGallery);

			{
				NFolderTreeNode areaExamples = chartGallery.AddFolder("Area");
				areaExamples.AddExample("Standard 2D Area", typeof(NStandardArea2DUC));
				areaExamples.AddExample("Standard 3D Area", typeof(NStandardArea3DUC));
				areaExamples.AddExample("Stacked Area", typeof(NStackedAreaUC));
                areaExamples.AddExample("Area Palette", typeof(NAreaPaletteUC));
				areaExamples.AddExample("Multiple Area Series", typeof(NMultiSeriesAreaUC));
				//areaExamples.AddExample("XY Area", typeof(NXYScatterAreaUC));
				//areaExamples.AddExample("Sampled 2D Area", typeof(NSampledArea2DUC));

				NFolderTreeNode barExamples = chartGallery.AddFolder("Bar");
				barExamples.AddExample("Standard 2D Bar", typeof(NStandardBar2DUC));
				barExamples.AddExample("Standard 3D Bar", typeof(NStandardBar3DUC));
				barExamples.AddExample("Cluster Bar", typeof(NClusterBarUC));
				barExamples.AddExample("Stacked Bar", typeof(NStackedBarUC));
				barExamples.AddExample("XYZ Scatter Cluster Bar", typeof(NXYZScattterClusterBarUC));
				barExamples.AddExample("XYZ Scatter Stack Bar", typeof(NXYZScattterStackBarUC));
				barExamples.AddExample("Bar Palette", typeof(NBarPaletteUC));
				barExamples.AddExample("Error Bar ", typeof(NErrorBarUC));
				barExamples.AddExample("Manhattan Bar", typeof(NManhattanBarUC));
				//barExamples.AddExample("Horizontal Bar", typeof(NHorizontalBarUC));
				//barExamples.AddExample("Dual Horizontal Bar", typeof(NDualHorizontalBarUC));
				//barExamples.AddExample("Cluster Stack Combination", typeof(NClusterStackCombinationUC));
				//barExamples.AddExample("DateTime Bars", typeof(NDateTimeBarUC));

				NFolderTreeNode boxAndWhiskersExamples = chartGallery.AddFolder("Box And Whiskers");
				boxAndWhiskersExamples.AddExample("Standard Box and Whiskers", typeof(NBoxAndWhiskers2DUC));
				boxAndWhiskersExamples.AddExample("Point Chart and Box Plot", typeof(NPointChartAndBoxPlotUC));
				//boxAndWhiskersExamples.AddExample("DateTime Box and Whiskers", typeof(NDateTimeBoxAndWhiskers2DUC));

				NFolderTreeNode bubbleExamples = chartGallery.AddFolder("Bubble");
				bubbleExamples.AddExample("Standard Bubble", typeof(NStandardBubbleUC));
				bubbleExamples.AddExample("XY Scatter Bubble", typeof(NXYScatterBubbleUC));
				bubbleExamples.AddExample("XYZ Scatter Bubble", typeof(NXYZScatterBubbleUC));
				bubbleExamples.AddExample("Bubble Palette", typeof(NBubblePaletteUC));
				bubbleExamples.AddExample("Bubble Legend Scale", typeof(NBubbleLegendScaleUC));

				NFolderTreeNode comboChartsExamples = chartGallery.AddFolder("Combo Charts");
				comboChartsExamples.AddExample("Financial Chart", typeof(NFinancialChartUC));
				comboChartsExamples.AddExample("Pareto", typeof(NParetoUC));

				NFolderTreeNode customSeriesExamples = chartGallery.AddFolder("Custom Series");
				customSeriesExamples.AddExample("Custom Series", typeof(NCustomSeriesUC));

				NFolderTreeNode errorBarExamples = chartGallery.AddFolder("Error Bar");
				errorBarExamples.AddExample("Y Error Bar", typeof(NYErrorBarUC));
				errorBarExamples.AddExample("XY Error Bar", typeof(NXYErrorBarUC));
				errorBarExamples.AddExample("XYZ Error Bar", typeof(NXYZErrorBarUC));
				
				NFolderTreeNode floatBarExamples = chartGallery.AddFolder("Float Bar");
				floatBarExamples.AddExample("2D Float Bar", typeof(NStandardFloatBar2DUC));
				floatBarExamples.AddExample("3D Float Bar", typeof(NStandardFloatBar3DUC));
                floatBarExamples.AddExample("Float Bar Palette", typeof(NFloatBarPaletteUC));
				floatBarExamples.AddExample("Horizontal Float Bar", typeof(NHorizontalFloatBarUC));
				floatBarExamples.AddExample("DateTime Float Bar", typeof(NDateTimeFloatBarUC));
				floatBarExamples.AddExample("Cluster Float Bar", typeof(NClusterFloatBarUC));
				floatBarExamples.AddExample("Stack Float Bar", typeof(NStackFloatBarUC));
				floatBarExamples.AddExample("DateTime Stack Float Bar", typeof(NDateTimeStackFloatBarUC));

				NFolderTreeNode funnelExamples = chartGallery.AddFolder("Funnel");
				funnelExamples.AddExample("Standard 2D Funnel", typeof(NStandardFunnel2DUC));
				funnelExamples.AddExample("Standard 3D Funnel", typeof(NStandardFunnel3DUC));
				funnelExamples.AddExample("Advanced 2D Funnel", typeof(NAdvancedFunnel2DUC));
				funnelExamples.AddExample("Advanced 3D Funnel", typeof(NAdvancedFunnel3DUC));

				NFolderTreeNode graphicsPathExamples = chartGallery.AddFolder("Graphics Path");
                graphicsPathExamples.AddExample("Graphics Path", typeof(NGraphicsPathSeriesUC));

				NFolderTreeNode gridSurfaceExamples = chartGallery.AddFolder("Grid Surface");
				gridSurfaceExamples.AddExample("General", typeof(NGridSurfaceUC));
				gridSurfaceExamples.AddExample("Large Surface", typeof(NLargeSurfaceUC));
				gridSurfaceExamples.AddExample("Custom Colors", typeof(NGridSurfaceCustomColorsUC));
				gridSurfaceExamples.AddExample("Wireframe", typeof(NGridSurfaceWireframeUC));
				gridSurfaceExamples.AddExample("Contour", typeof(NGridSurfaceContourUC));
				gridSurfaceExamples.AddExample("Projected Contour", typeof(NGridSurfaceProjectedContourUC));
				gridSurfaceExamples.AddExample("Empty Data Points", typeof(NGridSurfaceEmptyDataPointsUC));
				gridSurfaceExamples.AddExample("Horizontal Cross Section", typeof(NGridSurfaceHorizontalCrossSectionUC));
				gridSurfaceExamples.AddExample("Vertical Cross Section", typeof(NGridSurfaceVerticalCrossSectionUC));
				gridSurfaceExamples.AddExample("Isolines", typeof(NGridSurfaceIsolinesUC));
				//gridSurfaceExamples.AddExample("Fill Style", typeof(NGridFillStyleUC));
				//gridSurfaceExamples.AddExample("Waves", typeof(NWavesUC));
				//gridSurfaceExamples.AddExample("Texture Zoning", typeof(NGridSurfaceTextureZoningUC));

				NFolderTreeNode heatMapExamples = chartGallery.AddFolder("Heat Map");
				heatMapExamples.AddExample("Heat Map", typeof(NHeatMapUC));
                heatMapExamples.AddExample("Heat Map Contour", typeof(NHeatMapContourUC));
				heatMapExamples.AddExample("Heat Map Contour Labels", typeof(NHeatMapContourLabelsUC));
				heatMapExamples.AddExample("Heat Map Cross Section", typeof(NHeatMapCrossSectionUC));
				heatMapExamples.AddExample("Wafer Chart", typeof(NHeatMapWaferChartUC));

				NFolderTreeNode highLowExamples = chartGallery.AddFolder("High Low");
				highLowExamples.AddExample("2D High Low", typeof(NStandardHighLow2DUC));
				highLowExamples.AddExample("3D High Low", typeof(NStandardHighLow3DUC));
                highLowExamples.AddExample("High Low Palette", typeof(NHighLowPaletteUC));
				highLowExamples.AddExample("Advanced High Low", typeof(NAdvancedHighLow2DUC));

				NFolderTreeNode kagiExamples = chartGallery.AddFolder("Kagi");
				kagiExamples.AddExample("Kagi", typeof(NKagiUC));

				NFolderTreeNode lineExamples = chartGallery.AddFolder("Line");
				lineExamples.AddExample("Standard 2D Line", typeof(NStandardLine2DUC));
				lineExamples.AddExample("Standard 3D Line", typeof(NStandardLine3DUC));
				lineExamples.AddExample("Sampled 2D Line", typeof(NSampledLine2DUC));
				lineExamples.AddExample("Sampled 3D Line", typeof(NSampledLine3DUC));
				lineExamples.AddExample("Overlapped Line", typeof(NOverlappedLine3DUC));
				lineExamples.AddExample("Stacked Line", typeof(NStackedLineUC));
				lineExamples.AddExample("Multiseries Line", typeof(NMultiSeriesLineUC));
				lineExamples.AddExample("XY Scatter Line", typeof(NXYScatterLine2DUC));
				lineExamples.AddExample("XYZ Scatter Line", typeof(NXYZScatterLine3DUC));
				lineExamples.AddExample("Intersect with X/Y Value", typeof(NIntersectLineWithXYValueUC));

				NFolderTreeNode meshSurfaceExamples = chartGallery.AddFolder("Mesh Surface");
				meshSurfaceExamples.AddExample("General", typeof(NMeshSurfaceUC));
				//meshSurfaceExamples.AddExample("Intersected Surfaces", typeof(NMeshIntersectedUC));
				meshSurfaceExamples.AddExample("Empty Data Points", typeof(NMeshSurfaceEmptyDataPointsUC));
				//meshSurfaceExamples.AddExample("Fill Style", typeof(NMeshFillStyleUC));
				meshSurfaceExamples.AddExample("Texture Zoning", typeof(NMeshSurfaceTextureZoningUC));
				meshSurfaceExamples.AddExample("Custom Colors", typeof(NMeshSurfaceCustomColorsUC));
				meshSurfaceExamples.AddExample("Large Mesh Surface", typeof(NMeshSurfaceLargeSurfaceUC));

				NFolderTreeNode pieExamples = chartGallery.AddFolder("Pie");
				pieExamples.AddExample("3D Pie Chart", typeof(NStandardPieUC));
				pieExamples.AddExample("Exploded Pie", typeof(NExplodedPieUC));
				//pieExamples.AddExample("Sorted Pie", typeof(NSortedPieUC));
				//pieExamples.AddExample("Grouped Pie", typeof(NGroupedPieUC));
				pieExamples.AddExample("Non-overlapping Labels", typeof(NNonoverlappingLabelsUC));
				pieExamples.AddExample("Doughnut Pie", typeof(NDoughnutPieUC));
				pieExamples.AddExample("Pie Slice Radius", typeof(NPieSliceRadiusUC));
				//pieExamples.AddExample("Multiple Pies", typeof(NMultiplePiesUC));

				NFolderTreeNode pointExamples = chartGallery.AddFolder("Point");
				pointExamples.AddExample("Standard Point", typeof(NStandardPointUC));
				pointExamples.AddExample("XY Scatter Point", typeof(NXYScatterPointUC));
				//pointExamples.AddExample("XYZ Scatter Point", typeof(NXYZScatterPointUC));
				//pointExamples.AddExample("XY Scatter Point Cluster", typeof(NXYScatterPointClusteredUC));
				//pointExamples.AddExample("XYZ Scatter Point Cluster", typeof(NXYZScatterPointClusteredUC));
				//pointExamples.AddExample("Multi Series XYZ Scatter Point", typeof(NXYZMultiSeriesPointUC));

				NFolderTreeNode pointAndFigureExamples = chartGallery.AddFolder("Point and Figure");
				pointAndFigureExamples.AddExample("Point and Figure", typeof(NPointAndFigureUC));

				NFolderTreeNode polarExamples = chartGallery.AddFolder("Polar");
				polarExamples.AddExample("Polar Area", typeof(NPolarAreaUC));
				polarExamples.AddExample("Polar Line", typeof(NPolarLineUC));
				polarExamples.AddExample("Polar Point", typeof(NPolarPointUC));
                polarExamples.AddExample("Polar Range", typeof(NPolarRangeUC));
                polarExamples.AddExample("Polar Vector", typeof(NPolarVectorUC));
				//polarExamples.AddExample("Value Axis Position", typeof(NPolarValueAxisPositionUC));
				//polarExamples.AddExample("Angle Axis Position", typeof(NPolarAngleAxisPositionUC));

                NFolderTreeNode quickPointExamples = chartGallery.AddFolder("Quick Point");
				quickPointExamples.AddExample("Quick Point", typeof(NQuickPointUC));

				NFolderTreeNode radarExamples = chartGallery.AddFolder("Radar");
				radarExamples.AddExample("Radar Line", typeof(NRadarLineUC));
				radarExamples.AddExample("Radar Area", typeof(NRadarAreaUC));
				radarExamples.AddExample("Stacked Radar Area", typeof(NStackedRadarAreaUC));
                radarExamples.AddExample("Multi Measure Radar", typeof(NMultiMeasureRadarUC));
                radarExamples.AddExample("Custom Radar Axis Angles", typeof(NCustomRadarAxisAnglesUC));
				//radarExamples.AddExample("Multi Measure Radar", typeof(NMultiMeasureRadarUC));
				//radarExamples.AddExample("Radar Axis Titles", typeof(NRadarAxisTitlesUC));

				NFolderTreeNode rangeExamples = chartGallery.AddFolder("Range");
				rangeExamples.AddExample("2D Range Series", typeof(NRange2DUC));
				rangeExamples.AddExample("3D Range Series", typeof(NRange3DUC));

				NFolderTreeNode renkoExamples = chartGallery.AddFolder("Renko");
				renkoExamples.AddExample("Renko", typeof(NRenkoUC));

				NFolderTreeNode shapeExamples = chartGallery.AddFolder("Shape");
				shapeExamples.AddExample("3D Shapes", typeof(NShapeUC));
				//shapeExamples.AddExample("3D Modeling with Shapes", typeof(NShapeHomeUC));
				//shapeExamples.AddExample("Bars with Different Size", typeof(NShapeBarsWithDifferentSizeUC));
				//shapeExamples.AddExample("XY Scatter Bars", typeof(NShapeXYScatterBarsUC));
				//shapeExamples.AddExample("XYZ Scatter Bars", typeof(NShapeXYZScatterBarsUC));
				//shapeExamples.AddExample("XYZ Scatter Bubble", typeof(NShapeXYZScatterBubbleUC));

				NFolderTreeNode smoothAreaExamples = chartGallery.AddFolder("Smooth Area");
				smoothAreaExamples.AddExample("Smooth Area", typeof(NSmoothArea3DUC));
				smoothAreaExamples.AddExample("XY Smooth Area", typeof(NXYSmoothAreaUC));
                smoothAreaExamples.AddExample("Smooth Area Palette", typeof(NSmoothAreaPaletteUC));
				//smoothAreaExamples.AddExample("Date-Time Smooth Area", typeof(NDateTimeSmoothAreaUC));

				NFolderTreeNode smoothLineExamples = chartGallery.AddFolder("Smooth Line");
				smoothLineExamples.AddExample("Standard Smooth Line", typeof(NStandardSmoothLineUC));
				smoothLineExamples.AddExample("XY Smooth Line", typeof(NXYScatterSmoothLineUC));
				//smoothLineExamples.AddExample("DateTime Smooth Line", typeof(NDateTimeSmoothLineUC));
				//smoothLineExamples.AddExample("XYZ Smooth Line", typeof(NXYZScatterSmoothLineUC));

				NFolderTreeNode stepLineExamples = chartGallery.AddFolder("Step Line");
				stepLineExamples.AddExample("2D Step Line", typeof(NStandardStepLine2DUC));
				stepLineExamples.AddExample("3D Step Line", typeof(NStandardStepLineUC));
				//stepLineExamples.AddExample("2D Sampled Step Line", typeof(NSampledStepLine2DUC));
				//stepLineExamples.AddExample("DateTime Step Line", typeof(NDateTimeStepLineUC));

				NFolderTreeNode stockExamples = chartGallery.AddFolder("Stock");
				stockExamples.AddExample("Candle", typeof(NStockCandleUC));
				stockExamples.AddExample("Stick", typeof(NStockStickUC));
				stockExamples.AddExample("Stock Data Grouping", typeof(NStockDataGroupingUC));

				NFolderTreeNode ternaryExamples = chartGallery.AddFolder("Ternary");
				ternaryExamples.AddExample("Ternary Point", typeof(NTernaryPointUC));
				ternaryExamples.AddExample("Ternary Bubble", typeof(NTernaryBubbleUC));

				NFolderTreeNode threeLineBreakExamples = chartGallery.AddFolder("Three Line Break");
				threeLineBreakExamples.AddExample("Three Line Break", typeof(NThreeLineBreakUC));

				NFolderTreeNode treeMapExamples = chartGallery.AddFolder("Tree Map");
				treeMapExamples.AddExample("Tree Map", typeof(NTreeMapUC));

				NFolderTreeNode triangulatedHeatMapExamples = chartGallery.AddFolder("Triangulated Heat Map");
				triangulatedHeatMapExamples.AddExample("Triangulated HeatMap", typeof(NTriangulatedHeatMapUC));
				triangulatedHeatMapExamples.AddExample("Triangulated HeatMap Contour", typeof(NTriangulatedHeatMapContourUC));

				NFolderTreeNode triangulatedSurfaceExamples = chartGallery.AddFolder("Triangulated Surface");
				triangulatedSurfaceExamples.AddExample("Triangulated Surface", typeof(NTriangulatedSurfaceUC));
				triangulatedSurfaceExamples.AddExample("Custom Colors", typeof(NSurfaceWithCustomColorsUC));
				triangulatedSurfaceExamples.AddExample("Surface Simplification", typeof(NTriangulatedSurfaceSimplificationUC));
				//triangulatedSurfaceExamples.AddExample("Texture Zoning", typeof(NTriangulatedSurfaceTextureZoningUC));

				NFolderTreeNode vectorExamples = chartGallery.AddFolder("Vector");
				vectorExamples.AddExample("2D Vector Series", typeof(NVector2DUC));
				vectorExamples.AddExample("3D Vector Series", typeof(NVector3DUC));
				vectorExamples.AddExample("Vector Direction Mode", typeof(NVectorDirectionModeUC));
				vectorExamples.AddExample("Vector Legend Scale", typeof(NVectorLegendScaleUC));
			}

			NFolderTreeNode gaugeGallery = new NFolderTreeNode("Gauge Gallery");
			ExamplesTreeView.Items.Add(gaugeGallery);

			{
				NFolderTreeNode numericDisplay = gaugeGallery.AddFolder("Numeric Display");
				numericDisplay.AddExample("Numeric Led Display", typeof(NNumericLedDisplayUC));

				NFolderTreeNode gauges = gaugeGallery.AddFolder("Gauges");
				NFolderTreeNode indicators = gauges.AddFolder("Indicators");
				indicators.AddExample("Linear Gauge Indicators", typeof(NLinearGaugeIndicatorsUC));
				indicators.AddExample("Radial Gauge Indicators", typeof(NRadialGaugeIndicatorsUC));
				indicators.AddExample("Radial Gauge Knob Indicators", typeof(NRadialGaugeKnobsUC));
				indicators.AddExample("State Indicators", typeof(NStateIndicatorsUC));
				indicators.AddExample("Value Dampening", typeof(NIndicatorValueDampeningUC));
				indicators.AddExample("Indicator Palette", typeof(NIndicatorPaletteUC));

				NFolderTreeNode axes = gauges.AddFolder("Axes");
				axes.AddExample("Axis Ruler Size", typeof(NGaugeAxisRulerSizeUC));
				axes.AddExample("Axis Sections", typeof(NGaugeAxisSectionsUC));
				axes.AddExample("Scale Appearance", typeof(NGaugeScaleAppearanceUC));
				axes.AddExample("Custom Labels", typeof(NGaugeCustomLabelsUC));
				axes.AddExample("Custom Range Labels", typeof(NGaugeCustomRangeLabelsUC));
				axes.AddExample("Label Orientation", typeof(NGaugeScaleLabelsOrientationUC));

				NFolderTreeNode interactivity = gauges.AddFolder("Interactivity");
				interactivity.AddExample("Tooltips", typeof(NGaugeTooltipsUC));
				interactivity.AddExample("Hit Testing", typeof(NGaugeHitTestingUC));
				interactivity.AddExample("Dragging Indicators", typeof(NDraggingIndicatorsUC));

				NFolderTreeNode effects = gauges.AddFolder("Effects");
				effects.AddExample("Borders", typeof(NGaugeBordersUC));
				effects.AddExample("Glass and Gell Effects", typeof(NGaugeGelAndGlassEffectsUC));
				effects.AddExample("Background Adorner", typeof(NGaugeBackgroundAdornerUC));
				
				NFolderTreeNode clocks = gauges.AddFolder("Clocks");
				clocks.AddExample("Digital Clock", typeof(NDigitalClockUC)); 
				clocks.AddExample("Analog Clock", typeof(NAnalogClockUC));

			}

			ExamplesTreeView.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(ExamplesTreeView_SelectedItemChanged);
		}

		void ExamplesTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			NExampleTreeNode treeNode = ExamplesTreeView.SelectedItem as NExampleTreeNode;

			nChartControl.Document.Clear();
			nChartControl.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl.Controller.Tools.Clear();
			nChartControl.Controller.Selection.Clear();
			ExampleUCPlaceHolder.Children.Clear();
			DescriptionPlaceHolder.Children.Clear();

			if (m_PrevExample != null)
			{
				m_PrevExample.Destroy();
				m_PrevExample = null;
			}

			if (treeNode == null || treeNode.UserControlType == null)
			{
				return;
			}

			NExampleBaseUC exampleUC = (NExampleBaseUC)Activator.CreateInstance(treeNode.UserControlType);

			ExampleUCPlaceHolder.Children.Add(exampleUC);

			exampleUC.nChartControl1 = nChartControl;
//			exampleUC.Create();
			m_PrevExample = exampleUC;

			CreateDescriptionTextBox(exampleUC.Title, Color.FromArgb(255, 255, 158, 0), 16);
			CreateDescriptionTextBox(exampleUC.Description, Color.FromArgb(255, 255, 255, 255), 14);
		}

		private void CreateDescriptionTextBox(string text, Color backColor, double fontSize)
		{
			TextBox textBox = new TextBox();
			textBox.BorderThickness = new Thickness(0);
			textBox.IsReadOnly = true;
			textBox.Background = new SolidColorBrush(backColor);
			textBox.Text = text;
			textBox.TextWrapping = TextWrapping.WrapWithOverflow;
			textBox.FontSize = fontSize;
			DockPanel.SetDock(textBox, Dock.Top);
			DescriptionPlaceHolder.Children.Add(textBox);
		}

		private NExampleBaseUC m_PrevExample;
	}
}
