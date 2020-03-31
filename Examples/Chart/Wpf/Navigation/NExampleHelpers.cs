using System.Windows.Controls;
using System;
using System.Collections.Generic;

namespace Nevron.Examples.Chart.Wpf
{
	class NExampleHelpers
	{
		public static void FillComboWithEnumValues(ComboBox comboBox, Type enumType)
		{												  
			string[] names = Enum.GetNames(enumType);

			for (int i = 0; i < names.Length; i++)
			{
				comboBox.Items.Add(names[i]);
			}
		}

		public static void FillComboWithValues(ComboBox comboBox, int startValue, int endValue, int step)
		{
			for (int i = startValue; i <= endValue; i += step)
			{
				comboBox.Items.Add(i.ToString());
			}
		}

		public static void BindComboToItemSource(ComboBox comboBox, int startValue, int endValue, int step)
		{
			List<int> items = new List<int>();

			for (int i = startValue; i <= endValue; i += step)
			{
				items.Add(i);
			}
			comboBox.ItemsSource = items;
		}
	}
}