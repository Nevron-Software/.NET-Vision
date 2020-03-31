using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NLabelsFormattedUC : NExampleUC
	{
		protected HtmlForm LabelsGeneral;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SampleFormattedLabelDropDownList.Items.Add("Font size and color");
                SampleFormattedLabelDropDownList.Items.Add("Font style control");
                SampleFormattedLabelDropDownList.Items.Add("Subscript and superscript");
				SampleFormattedLabelDropDownList.Items.Add("Shapes");
                SampleFormattedLabelDropDownList.Items.Add("Bullets");
                SampleFormattedLabelDropDownList.Items.Add("Fill Effects");
                SampleFormattedLabelDropDownList.Items.Add("Borders");
                SampleFormattedLabelDropDownList.Items.Add("Shadows");
				SampleFormattedLabelDropDownList.Items.Add("Background Fill and Stroke");
                SampleFormattedLabelDropDownList.SelectedIndex = 8;

                WebExamplesUtilities.FillComboWithFontNames(FontDropDownList, "Arial");
                WebExamplesUtilities.FillComboWithValues(FontSizeDropDownList, 8, 52, 1);

                WebExamplesUtilities.FillComboWithColorNames(FontColorDropDownList, KnownColor.Black);

                HasBackplaneCheckBox.Checked = true;
            }

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
            nChartControl1.Panels.Clear();
            NLabel label = new NLabel();

            try
            {
                label.TextStyle.FontStyle = new NFontStyle(FontDropDownList.SelectedItem.Text, FontSizeDropDownList.SelectedIndex + 8);
            }
            catch
            {
            }

            label.Text = GetFormattedString((int)label.TextStyle.FontStyle.EmSize.Value);

            label.TextStyle.FillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(FontColorDropDownList));
            label.TextStyle.TextFormat = TextFormat.XML;
            label.TextStyle.BackplaneStyle.Visible = HasBackplaneCheckBox.Checked;
            label.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left;
            label.TextStyle.StringFormatStyle.VertAlign = VertAlign.Top;
            label.TextStyle.TextFormat = TextFormat.XML;
            label.Location = new NPointL(new NLength(5, NRelativeUnit.ParentPercentage),
                                        new NLength(5, NRelativeUnit.ParentPercentage));

            nChartControl1.Panels.Add(label);
        }

		private String GetBulletText(String bulletType)
		{
			return bulletType + " bullets <ul liststyletype = '" + bulletType + "'>" + 
				"<li color = 'red'>" + bulletType + " Bullet 1" + "</li>" + 
				"<li color = 'blue'>" + bulletType + " Bullet 2" + "</li>" +
				"</ul><br/>";
		}

		private String GetFormattedString(int nBaseSize)
		{
			String sText = "";

			switch (SampleFormattedLabelDropDownList.SelectedIndex)
			{
				case 0:
					// Font size and color 
					sText = "<font size = '" + (nBaseSize + 4).ToString() + "' color = 'red'>XML formatted</font> texts allow you to mix<br/>" + 
						"texts with different <font color = 'blue' size = '" + (nBaseSize + 4).ToString() + "' face = 'Balthazar'>font</font> and <font face = 'Arial black' color = 'green' size = '" + (nBaseSize + 4).ToString() + "'>size</font>";
					break;
				case 1:
					// Font style control
					sText = "Demonstrates how to use <font color = 'red'><b>bold</b></font>, <font color = 'green'><i>italic</i></font>, <br/><font color = 'blue'><u>underline</u></font> and <font color = 'darkorange'><strike>strikeout</strike></font> tags";
					break;
				case 2:
					// Subscript and superscript
					sText = "World's most famous formula : <font size = '" + (nBaseSize + 4).ToString() + "' color = 'red'><b>E = MC<sup>2</sup></b></font> <br/>This text uses <sup>sup</sup> and <sub>sub</sub> tags";
					break;
				case 3:
					// Shapes
					Array values = Enum.GetValues(typeof(MarkerShape));
					string[] names = Enum.GetNames(typeof(MarkerShape));
					Color[] lightColors = new Color[] { Color.Red, Color.Green, Color.Blue };
					Color[] darkColors = new Color[] { Color.DarkRed, Color.DarkGreen, Color.DarkBlue };

					for (int i = 0; i < names.Length; i++)
					{
						sText += names[i] + " Shape <shape shape='" + names[i].ToLower() + "' size = '10pt, 10pt' color = '" + lightColors[i % 3].ToKnownColor().ToString() + "' bordercolor = '" + darkColors[i % 3].ToKnownColor().ToString() + "'/><br/>";
					}
					break;
				case 4:
					// Bullets 
					sText = "XML formatted texts support several bullet list styles<br/><font size = '" + (nBaseSize ).ToString() + "'>";

					String[] arrEnumNames = Enum.GetNames(typeof(ListStyleType));

					for (int i = 0; i < arrEnumNames.Length; i++)
					{
						sText += GetBulletText(arrEnumNames[i]);
					}

					sText += "</font>";
					break;
				case 5:
					// Fill Effects
					sText = "XML formatted texts support: <br/><font color = 'red'>- Solid color</font><br/><font gradient = '0, 0, white, navy'>- Simple (two color) gradient</font><br/><font pattern = '25, white, navy'>- Pattern (hatch)</font><br/>filling types";
					break;
				case 6: 
					// Borders
					sText = "Text borders can be with different <br/><font face = 'Ariel Black' gradient = '0, 1, White, Navy' size = '" + (nBaseSize + 4).ToString() + "'> <font border = '2' bordercolor = 'red'>WIDTH</font> and <font bordercolor = 'magenta' border = '1'>COLOR</font></font>";
					break;
				case 7:
					// Shadows
					sText = "There are several types of shadows: <br/>" + 
						" <font shadowoffset = '5, 5' shadowfadearea = '5' face = 'Impact' gradient = '0, 1, White, Navy' size = '" + (nBaseSize + 4).ToString() + "'>" + 
						"- <font shadowtype = 'solid'>Solid ShadowStyle</font> <br/>" + 
						"- <font shadowtype = 'linearblur'>Linear Blur ShadowStyle</font> <br/>" + 
						"- <font shadowtype = 'radialblur'>Radial Blur ShadowStyle</font> <br/>" + 
						"- <font shadowtype = 'gaussianblur'>Gaussian Blur ShadowStyle</font> <br/>" + 
						"</font>" + 
						"You can also use shadows to: <br/><font face = 'Impact' gradient = '0, 1, White, DarkOrange' size = '" + (nBaseSize + 4).ToString() +"' shadowtype = 'gaussianblur' shadowcolor = 'yellow' shadowfadearea = '5' shadowoffset = '0, 0'>HIGHLIGHT TEXT</font>";
					break;
				case 8:
					// backgrounf fill & stroke
					sText = "XML Formatted text allow you to control the text background.<br/>This is <font color = 'black' back-color = 'orange'>BLACK TEXT ON AN ORANGE BACKGROUND</font><br/>This is <font color = 'white' back-gradient = '0,0,white,navy'>WHITE TEXT ON A GRADIENT BACKGROUND</font><br/>This is <font color = 'black' back-color = 'orange' back-bordercolor = 'red' back-borderwidth = '1pt'>BLACK TEXT ON AN ORANGE BACKGROUND (RED OUTLINE)</font><br/>This is <font color = 'white' back-color = 'black' back-bordercolor = 'red' back-borderwidth = '1pt'>WHITE TEXT ON A BLACK BACKGROUND</font><br/>";
						break;
			}

			return sText;
		}
	}
}
