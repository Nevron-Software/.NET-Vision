using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NNumericDisplayUC : NExampleUC
	{
		private NNumericDisplayPanel m_NumericDisplay1;
		private NNumericDisplayPanel m_NumericDisplay2;
		private NNumericDisplayPanel m_NumericDisplay3;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Numeric Display");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(new NLength(3, NRelativeUnit.ParentPercentage),
                                            new NLength(2, NRelativeUnit.ParentPercentage));
            nChartControl1.Panels.Add(header);

			NDockPanel displayContainer = new NDockPanel();
			displayContainer.Location = new NPointL(
                new NLength(10, NRelativeUnit.ParentPercentage),
                new NLength(15, NRelativeUnit.ParentPercentage));
            displayContainer.Size = new NSizeL(
                new NLength(80, NRelativeUnit.ParentPercentage),
                new NLength(90, NRelativeUnit.ParentPercentage));

			Random rand = new Random();

            m_NumericDisplay1 = CreateDisplayPanel();
			m_NumericDisplay1.Value = rand.Next(100) - 50;
            m_NumericDisplay2 = CreateDisplayPanel();
			m_NumericDisplay2.Value = rand.Next(1000) - 500;
            m_NumericDisplay3 = CreateDisplayPanel();
			m_NumericDisplay3.Value = rand.Next(10000) - 5000;

			displayContainer.ChildPanels.Add(m_NumericDisplay1);

			displayContainer.ChildPanels.Add(m_NumericDisplay2);
			displayContainer.ChildPanels.Add(m_NumericDisplay3);
			nChartControl1.Panels.Add(displayContainer);

			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(DisplayStyleDropDownList, typeof(DisplayStyle));
                DisplayStyleDropDownList.SelectedIndex = (int)DisplayStyle.SevenSegmentRounded;

				WebExamplesUtilities.FillComboWithEnumValues(SignModeDropDownList, typeof(DisplaySignMode));
				SignModeDropDownList.SelectedIndex = (int)DisplaySignMode.Always;
			}

			m_NumericDisplay1.DisplayStyle = (DisplayStyle)DisplayStyleDropDownList.SelectedIndex;
			m_NumericDisplay2.DisplayStyle = (DisplayStyle)DisplayStyleDropDownList.SelectedIndex;
			m_NumericDisplay3.DisplayStyle = (DisplayStyle)DisplayStyleDropDownList.SelectedIndex;

			m_NumericDisplay1.SignMode = (DisplaySignMode)SignModeDropDownList.SelectedIndex;
			m_NumericDisplay2.SignMode = (DisplaySignMode)SignModeDropDownList.SelectedIndex;
			m_NumericDisplay3.SignMode = (DisplaySignMode)SignModeDropDownList.SelectedIndex;

			m_NumericDisplay1.ShowLeadingZeros = ShowLeadingZerosCheckBox.Checked;
			m_NumericDisplay2.ShowLeadingZeros = ShowLeadingZerosCheckBox.Checked;
			m_NumericDisplay3.ShowLeadingZeros = ShowLeadingZerosCheckBox.Checked;

			m_NumericDisplay1.AttachSignToNumber = AttachSignToNumberCheckBox.Checked;
			m_NumericDisplay2.AttachSignToNumber = AttachSignToNumberCheckBox.Checked;
			m_NumericDisplay3.AttachSignToNumber = AttachSignToNumberCheckBox.Checked;
		}
        private NNumericDisplayPanel CreateDisplayPanel()
        {
            NNumericDisplayPanel numericDisplay = new NNumericDisplayPanel();

            numericDisplay.UseAutomaticSize = true;
            numericDisplay.DockMode = PanelDockMode.Top;
            numericDisplay.Value = 0;
            numericDisplay.CellCountMode = DisplayCellCountMode.Fixed;
			numericDisplay.CellCount = 8;
            numericDisplay.Margins = new NMarginsL(10, 5, 10, 5);
            numericDisplay.Padding = new NMarginsL(7, 7, 7, 7);

            // apply border, background and paint effect
            numericDisplay.BackgroundFillStyle = new NColorFillStyle(Color.Black);
            NEdgeBorderStyle border = new NEdgeBorderStyle(BorderShape.RoundedRect);
            border.InnerBevelWidth = new NLength(1);
            border.OuterBevelWidth = new NLength(1);
            border.MiddleBevelWidth = new NLength(1);
            numericDisplay.BorderStyle = border;
            numericDisplay.PaintEffect = new NGelEffectStyle();

            // adjust cell fill styles
            numericDisplay.LitFillStyle = new NColorFillStyle(Color.GreenYellow);
            numericDisplay.DimFillStyle.SetTransparencyPercent(50);
            numericDisplay.DecimalLitFillStyle = new NColorFillStyle(Color.Red);
            numericDisplay.DecimalDimFillStyle.SetTransparencyPercent(50);

            // adjust cell sizes
            numericDisplay.CellSize = new NSizeL(new NLength(15), new NLength(30));
            numericDisplay.DecimalCellSize = new NSizeL(new NLength(15), new NLength(30));
            numericDisplay.SegmentGap = new NLength(1, NGraphicsUnit.Point);
            numericDisplay.SegmentWidth = new NLength(2.4f, NGraphicsUnit.Point);

            return numericDisplay;
        }
	}
}
