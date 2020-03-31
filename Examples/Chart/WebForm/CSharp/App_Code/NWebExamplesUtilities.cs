using System;
using System.Drawing;
using System.Web.UI.WebControls;
using Nevron.GraphicsCore;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WebForm
{
	public class WebExamplesUtilities
	{
		public WebExamplesUtilities()
		{
		}

	

		public static string GetXmlFormatString(string sFormatString)
		{
			sFormatString = sFormatString.Replace("[", "<");
			sFormatString = sFormatString.Replace("]", ">");

			return sFormatString;
		}

		public static void FillComboWithFontNames(DropDownList dropDownList, String fontToSelect)
		{
			dropDownList.Items.Clear();
			int currentIndex = 0, selectedFontIndex = -1;

			foreach (FontFamily fontFamily in FontFamily.Families)
			{
				dropDownList.Items.Add(fontFamily.Name);

				if (fontFamily.Name == fontToSelect)
				{
					selectedFontIndex = currentIndex;
				}
				currentIndex++;
			}

			if (currentIndex == 0)
				return;

			if (selectedFontIndex != -1)
			{
				dropDownList.SelectedIndex = selectedFontIndex;
			}
			else
			{
				dropDownList.SelectedIndex = 0;
			}
		}	

		public static void FillComboWithPredefinedProjections(DropDownList dropDownList)
		{
			dropDownList.Items.Clear();
			dropDownList.Items.Add("Orthogonal");
			dropDownList.Items.Add("Orthogonal Elevated");
			dropDownList.Items.Add("Orthogonal Horizontal Left");
			dropDownList.Items.Add("Orthogonal Horizontal Right");
			dropDownList.Items.Add("Orthogonal Half");
			dropDownList.Items.Add("Orthogonal Half Horizontal Left");
			dropDownList.Items.Add("Orthogonal Half Horizontal Right");
			dropDownList.Items.Add("Orthogonal Half Rotated");
			dropDownList.Items.Add("Orthogonal Half Elevated");
			dropDownList.Items.Add("Orthogonal Top");
			dropDownList.Items.Add("Perspective");
			dropDownList.Items.Add("Perspective Horizontal Left");
			dropDownList.Items.Add("Perspective Horizontal Right");
			dropDownList.Items.Add("Perspective Rotated");
			dropDownList.Items.Add("Perspective Elevated");
			dropDownList.Items.Add("Perspective Tilted");
		}

		public static void FillComboWithPercents(DropDownList dropDownList, int percentStep)
		{
			dropDownList.Items.Clear();

			for (int i = 0; i <= 100; i += percentStep)
			{
				dropDownList.Items.Add(i.ToString() + "%");
			}
		}

		public static void FillComboWithFloatValues(DropDownList dropDownList, float min, float max, float interval)
		{
			dropDownList.Items.Clear();

			for (float i = min; i <= max; i += interval)
			{
				dropDownList.Items.Add(i.ToString("0.00"));
			}
		}

		public static void FillComboWithValues(DropDownList dropDownList, int min, int max, int interval)
		{
			dropDownList.Items.Clear();

			for (int i = min; i <= max; i += interval)
			{
				dropDownList.Items.Add(i.ToString());
			}
		}

		public static int GetPercentFromCombo(DropDownList dropDownList, int percentStep)
		{
			return dropDownList.SelectedIndex * percentStep;
		}

		public static void FillComboWithColorNames(DropDownList dropDownList, KnownColor selectedColor)
		{
			int index = -1, currentIndex = 0;
			Color currentColor;

			dropDownList.Items.Clear();

			for (KnownColor enumValue = 0; enumValue <= KnownColor.YellowGreen; enumValue++)
			{
				currentColor = Color.FromKnownColor(enumValue);

				if (currentColor.IsSystemColor == false)
				{
					dropDownList.Items.Add(currentColor.ToString());
					if (selectedColor == enumValue)
					{
						index = currentIndex;
					}

					currentIndex++;
				}
			}

			if (index != -1)
			{
				dropDownList.SelectedIndex = index;
			}
		}

		public static void FillComboWithEnumValues(DropDownList dropDownList, Type enumType)
		{
			dropDownList.Items.Clear();

			foreach(object obj in Enum.GetValues(enumType))
			{
				dropDownList.Items.Add(TypeNameToName(obj.ToString(), true, false));
			}
		}

		public static void FillComboWithEnumNames(DropDownList dropDownList, Type enumType)
		{
			dropDownList.Items.Clear();

			foreach (object obj in Enum.GetNames(enumType))
			{
				dropDownList.Items.Add(obj.ToString());
			}
		}


		public static void FillComboWithColorNames(DropDownList dropDownList)
		{
			Color currentColor;

			dropDownList.Items.Clear();

			for (KnownColor enumValue = 0; enumValue <= KnownColor.YellowGreen; enumValue++)
			{
				currentColor = Color.FromKnownColor(enumValue);
				if (currentColor.IsSystemColor == false)
					dropDownList.Items.Add(currentColor.ToString());
			}
		}

		public static void FillComboWithBarShapes(DropDownList dropDownList)
		{
			dropDownList.Items.Add("Bar");
			dropDownList.Items.Add("Cylinder");
			dropDownList.Items.Add("Cone");
			dropDownList.Items.Add("Inverted Cone");
			dropDownList.Items.Add("Pyramid");
			dropDownList.Items.Add("Inverted Pyramid");
			dropDownList.Items.Add("Ellipsoid");
			dropDownList.Items.Add("Smooth Edge Bar");
			dropDownList.Items.Add("Cut Edge Bar");
		}

		public static Color ColorFromDropDownList(DropDownList dropDownList)
		{
			return ColorFromString(dropDownList.SelectedItem.Text);
		}

		public static Color ColorFromString(String stringColor)
		{
			Color currentColor;

			for (KnownColor enumValue = 0; enumValue <= KnownColor.YellowGreen; enumValue++)
			{
				currentColor = Color.FromKnownColor(enumValue);

				if (currentColor.ToString() == stringColor)
				{
					return currentColor;
				}
			}

			return Color.FromKnownColor(KnownColor.Blue);
		}

		public static Color RandomColor()
		{
			return Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
		}

		public static String TypeNameToName(String typeName, bool allowNPrefix, bool allowNamespace)
		{
			String caption = "";

			if (typeName.Length == 0)
				return caption;

			if (!allowNamespace)
			{
				int index = typeName.LastIndexOf(".");

				if (index != -1)
				{
					typeName = typeName.Substring(index + 1);
				}
			}
			
			if (allowNPrefix == false && typeName.StartsWith("N"))
			{
				typeName = typeName.Substring(1);
			}

			caption += typeName[0];

			for (int i = 1; i < typeName.Length; i++)
			{
				if (Char.IsUpper(typeName[i]))
					caption += " ";

				caption += typeName[i];
			}

			return caption;
		}

		public static void GenerateOHLCDataPoint(double dPrevClose, NRange1DD range, out double open, out double high, out double low, out double close)
		{
			open = dPrevClose;
			bool upward = false;

			if (range.Begin > dPrevClose)
			{
				upward = true;
			}
			else if (range.End < dPrevClose)
			{
				upward = false;
			}
			else
			{
				upward = rand.NextDouble() > 0.5;
			}
			
			if (upward)
			{
				// upward price change
				close = open + (2 + (rand.NextDouble() * 20));
				high = close + (rand.NextDouble() * 10);
				low = open - (rand.NextDouble() * 10);
			}
			else
			{
				// downward price change
				close = open - (2 + (rand.NextDouble() * 20));
				high = open + (rand.NextDouble() * 10);
				low = close - (rand.NextDouble() * 10);
			}

			if(low < 1)
			{ 
				low = 1; 
			}
		}

		public static void GenerateOHLCData(NStockSeries s, double dPrevClose, int nCount, NRange1DD range)
		{
			double open, high, low, close;

			s.ClearDataPoints();

			for (int nIndex = 0; nIndex < nCount; nIndex++)
			{
				GenerateOHLCDataPoint(dPrevClose, range, out open, out high, out low, out close);
				
				dPrevClose = close;

				s.OpenValues.Add(open);
				s.HighValues.Add(high);
				s.LowValues.Add(low);
				s.CloseValues.Add(close);
			}
		}

		public static void GenerateOHLCData(NStockSeries s, double dPrevClose, int nCount)
		{
			double open, high, low, close;

			s.ClearDataPoints();

			for(int nIndex = 0; nIndex < nCount; nIndex++)
			{
				open = dPrevClose;

				if(dPrevClose < 25 || rand.NextDouble()  > 0.5)
				{
					// upward price change
					close = open + (2 + (rand.NextDouble() * 20));
					high = close + (rand.NextDouble() * 10);
					low = open - (rand.NextDouble() * 10);
				}
				else
				{
					// downward price change
					close = open - (2 + (rand.NextDouble() * 20));
					high = open + (rand.NextDouble() * 10);
					low = close - (rand.NextDouble() * 10);
				}

				if(low < 1)
				{ 
					low = 1; 
				}

				dPrevClose = close;

				s.OpenValues.Add(open);
				s.HighValues.Add(high);
				s.LowValues.Add(low);
				s.CloseValues.Add(close);
			}
		}

        public static void GenerateDataPoint(double dPrev, NRange1DD range, out double aValue, ref int factor)
        {
            aValue = dPrev;
            bool upward = false;
            if (dPrev <= range.Begin)
            {
                upward = true;
            }
            else
            {
                if (dPrev >= range.End)
                {
                    upward = false;
                }
                else
                {
                    double u = rand.NextDouble();
                    if (Math.Abs(factor) > 30)
                    {
                        upward = u / Math.Abs(factor) > 0.1;
                    }
                    else
                    {
                        upward = u > 0.5;
                    }
                }
            }
            if (upward)
            {
                // upward value change
                aValue = aValue + (rand.NextDouble() * 10);
                factor++;
            }
            else
            {
                // downward value change
                aValue = aValue - (rand.NextDouble() * 10);
                factor--;
            }
        }


		public static Random rand = new Random();
	}
}
