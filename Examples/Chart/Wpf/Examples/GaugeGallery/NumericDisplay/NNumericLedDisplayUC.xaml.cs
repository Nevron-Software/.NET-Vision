using System;
using System.Drawing;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using Nevron.Chart;
using Nevron.Editors;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{	
	public partial class NNumericLedDisplayUC : NExampleBaseUC
	{
		private int m_Counter = 0;
		private NNumericDisplayPanel m_NumericDisplay1;
		private NNumericDisplayPanel m_NumericDisplay2;
		private NNumericDisplayPanel m_NumericDisplay3;
		private Random m_Random = new Random();
		private Timer DataFeedTimer;

		public NNumericLedDisplayUC()
		{
			InitializeComponent();
			DataFeedTimer = new Timer(500);
			DataFeedTimer.Elapsed += DataFeedTimer_Elapsed;
		}

		/// <summary>
		/// Gets the title of this example
		/// </summary>
		public override string Title
		{
			get
			{
				return "Numeric Led Display";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates the functionality of the NNumericDisplayPanel.\r\n" +
					   "It can be very useful to display numeric information (values) in LED fashion with different styles.\r\n\r\n" +

						"You can use the controls on the right side to modify the appearance and style of the numeric display.\r\n" +
						"Press the Stop / Start Timer button to toggle automatic update of the chart and panels. \r\n" +
					"Use the controls on the right to modify some commonly used properties";
			}
		}

		public override void Create()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Numeric Display Panel");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			header.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			header.Location = new NPointL(
				new NLength(2, NRelativeUnit.ParentPercentage),
				new NLength(2, NRelativeUnit.ParentPercentage));
            nChartControl1.Panels.Add(header);

            NDockPanel dockPanel = new NDockPanel();
            dockPanel.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
            dockPanel.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
            dockPanel.ContentAlignment = ContentAlignment.MiddleCenter;

            nChartControl1.Panels.Add(dockPanel);

            m_NumericDisplay1 = CreateDisplayPanel();
            m_NumericDisplay2 = CreateDisplayPanel();
            m_NumericDisplay3 = CreateDisplayPanel();

            dockPanel.ChildPanels.Add(m_NumericDisplay1);
			dockPanel.ChildPanels.Add(m_NumericDisplay2);
            dockPanel.ChildPanels.Add(m_NumericDisplay3);

			nChartControl1.Refresh();

			// init form controls
			CellSizeComboBox.Items.Add("Small");
			CellSizeComboBox.Items.Add("Normal");
			CellSizeComboBox.Items.Add("Large");
			CellSizeComboBox.SelectedIndex = 1;
			NExampleHelpers.FillComboWithEnumValues(DisplayStyleComboBox, typeof(DisplayStyle));
            DisplayStyleComboBox.SelectedIndex = (int)DisplayStyle.SevenSegmentRounded;

			NExampleHelpers.FillComboWithEnumValues(SignModeComboBox, typeof(DisplaySignMode));
			SignModeComboBox.SelectedIndex = (int)DisplaySignMode.Never;
 
			DataFeedTimer.Start();
		}

		private NNumericDisplayPanel CreateDisplayPanel()
        {
            NNumericDisplayPanel numericDisplay = new NNumericDisplayPanel();

            numericDisplay.UseAutomaticSize = true;
            numericDisplay.DockMode = PanelDockMode.Top;
            numericDisplay.Value = 0;
            numericDisplay.CellCountMode = DisplayCellCountMode.Fixed;
            numericDisplay.CellCount = 7;
            numericDisplay.Margins = new NMarginsL(10, 10, 10, 10);
            numericDisplay.Padding = new NMarginsL(10, 10, 10, 10);
            numericDisplay.BackgroundFillStyle = new NColorFillStyle(NColor.ColorFromString("Black"));

            // adjust cell fill styles
            numericDisplay.LitFillStyle = new NColorFillStyle(NColor.ColorFromString("GreenYellow"));
            numericDisplay.DimFillStyle.SetTransparencyPercent(50);
			numericDisplay.DecimalLitFillStyle = new NColorFillStyle(NColor.ColorFromString("Red"));
            numericDisplay.DecimalDimFillStyle.SetTransparencyPercent(50);
            
            numericDisplay.BorderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);
            numericDisplay.PaintEffect = new NGelEffectStyle();

            return numericDisplay;
        }

		void DataFeedTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
			double value1 = -50 + m_Random.Next(10000) / 100.0;
			m_NumericDisplay1.Value = value1;

			double value2;
			if (m_Counter % 4 == 0)
			{
				value2 = -50 + m_Random.Next(10000) / 100.0;
				m_NumericDisplay2.Value = value2;
			}

			double value3;
			if (m_Counter % 8 == 0)
			{
				value3 = 200 + m_Random.Next(10000) / 100.0;
				m_NumericDisplay3.Value = value3;
			}

			m_Counter++;
			nChartControl1.Refresh();
		}

		private void LitFillStyleButton_Click(object sender, RoutedEventArgs e)
		{
			NFillStyle fillStyle = null;

			if (NFillStyleTypeEditorNoAutomatic.Edit(m_NumericDisplay1.LitFillStyle, false, out fillStyle))
			{
				m_NumericDisplay1.LitFillStyle = fillStyle;
				m_NumericDisplay2.LitFillStyle = fillStyle;
				m_NumericDisplay3.LitFillStyle = fillStyle;

				nChartControl1.Refresh();
			}

		}

		private void DimFillStyleButton_Click(object sender, RoutedEventArgs e)
		{
			NFillStyle fillStyle = null;

			if (NFillStyleTypeEditorNoAutomatic.Edit(m_NumericDisplay1.DimFillStyle, false, out fillStyle))
			{
				m_NumericDisplay1.DimFillStyle = fillStyle;
				m_NumericDisplay2.DimFillStyle = fillStyle;
				m_NumericDisplay3.DimFillStyle = fillStyle;

				nChartControl1.Refresh();
			}

		}

		private void CellSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			NLength segmentWidth = new NLength(0);
			NLength segmentGap = new NLength(0);
			NSizeL cellSize = new NSizeL(new NLength(0), new NLength(0));

			switch (CellSizeComboBox.SelectedIndex)
			{
				case 0: // small
					segmentWidth = new NLength(2, NGraphicsUnit.Point);
					segmentGap = new NLength(1, NGraphicsUnit.Point);
					cellSize = new NSizeL(new NLength(15, NGraphicsUnit.Point), new NLength(30, NGraphicsUnit.Point));
					break;
				case 1: // normal
					segmentWidth = new NLength(3, NGraphicsUnit.Point);
					segmentGap = new NLength(1, NGraphicsUnit.Point);
					cellSize = new NSizeL(new NLength(20, NGraphicsUnit.Point), new NLength(40, NGraphicsUnit.Point));
					break;
				case 2: // large
					segmentWidth = new NLength(4, NGraphicsUnit.Point);
					segmentGap = new NLength(2, NGraphicsUnit.Point);
					cellSize = new NSizeL(new NLength(25, NGraphicsUnit.Point), new NLength(50, NGraphicsUnit.Point));
					break;
			}

			m_NumericDisplay1.CellSize = cellSize;
			m_NumericDisplay2.CellSize = cellSize;
			m_NumericDisplay3.CellSize = cellSize;

			m_NumericDisplay1.DecimalCellSize = cellSize;
			m_NumericDisplay2.DecimalCellSize = cellSize;
			m_NumericDisplay3.DecimalCellSize = cellSize;

			m_NumericDisplay1.SegmentGap = segmentGap;
			m_NumericDisplay2.SegmentGap = segmentGap;
			m_NumericDisplay3.SegmentGap = segmentGap;

			m_NumericDisplay1.SegmentWidth = segmentWidth;
			m_NumericDisplay2.SegmentWidth = segmentWidth;
			m_NumericDisplay3.SegmentWidth = segmentWidth;

			nChartControl1.Refresh();
		}

		private void DisplayStyleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			m_NumericDisplay1.DisplayStyle = (DisplayStyle)DisplayStyleComboBox.SelectedIndex;
			m_NumericDisplay2.DisplayStyle = (DisplayStyle)DisplayStyleComboBox.SelectedIndex;
			m_NumericDisplay3.DisplayStyle = (DisplayStyle)DisplayStyleComboBox.SelectedIndex;

			nChartControl1.Refresh();
		}

		private void SignModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			m_NumericDisplay1.SignMode = (DisplaySignMode)SignModeComboBox.SelectedIndex;
			m_NumericDisplay2.SignMode = (DisplaySignMode)SignModeComboBox.SelectedIndex;
			m_NumericDisplay3.SignMode = (DisplaySignMode)SignModeComboBox.SelectedIndex;

			nChartControl1.Refresh();
		}

		private void ShowLeadingZerosCheckBox_Checked(object sender, RoutedEventArgs e)
		{
			m_NumericDisplay1.ShowLeadingZeros = ShowLeadingZerosCheckBox.IsChecked.Value;
			m_NumericDisplay2.ShowLeadingZeros = ShowLeadingZerosCheckBox.IsChecked.Value;
			m_NumericDisplay3.ShowLeadingZeros = ShowLeadingZerosCheckBox.IsChecked.Value;

			nChartControl1.Refresh();
		}

		private void AttachSignToNumberCheckBox_Checked(object sender, RoutedEventArgs e)
		{
			m_NumericDisplay1.AttachSignToNumber = AttachSignToNumberCheckBox.IsChecked.Value;
			m_NumericDisplay2.AttachSignToNumber = AttachSignToNumberCheckBox.IsChecked.Value;
			m_NumericDisplay3.AttachSignToNumber = AttachSignToNumberCheckBox.IsChecked.Value;

			nChartControl1.Refresh();
		}

		private void StopStartTimerButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.DataFeedTimer.Enabled)
			{
				this.DataFeedTimer.Stop();
				StopStartTimerButton.Content = "Start Timer";
			}
			else
			{
				this.DataFeedTimer.Start();
				StopStartTimerButton.Content = "Stop Timer";
			}
		}
	}
}
