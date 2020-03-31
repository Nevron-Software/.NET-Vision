using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Nevron.Examples.Chart.Wpf
{
	class NExampleTreeNode : NTreeNode
	{
		#region Constuctors

		/// <summary>
		/// Initializer constructor
		/// </summary>
		/// <param name="name"></param>
		/// <param name="userControlType"></param>
		public NExampleTreeNode(string name, Type userControlType)
			: base(name)
		{
			m_UserControlType = userControlType;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets the user control type
		/// </summary>
		public Type UserControlType
		{
			get
			{
				return m_UserControlType;
			}
		}

		#endregion

		#region Overrides

		protected override void UpdateImage()
		{
			if (base.IsSelected)
			{
				m_Image.Source = m_ChartImageSelected;
			}
			else
			{
				m_Image.Source = m_ChartImage;
			}
		}

		#endregion

		#region Fields

		Type m_UserControlType;

		#endregion

		#region Static Fields

		internal static BitmapImage m_ChartImage = new BitmapImage(new Uri("pack://application:,,/Resources/Images/Chart.png"));
		internal static BitmapImage m_ChartImageSelected = new BitmapImage(new Uri("pack://application:,,/Resources/Images/ChartSelected.png"));

		#endregion
	}
}
