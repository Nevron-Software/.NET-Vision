using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Nevron.Examples.Chart.Wpf
{
	abstract class NTreeNode : TreeViewItem
	{
		#region Constuctors

		/// <summary>
		/// Initializer constructor
		/// </summary>
		/// <param name="name"></param>
		/// <param name="normalImage"></param>
		/// <param name="selectedImage"></param>
		/// <param name="expandedImage"></param>
		public NTreeNode(string name)
		{
			StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;

            m_Image = new Image();
            m_Image.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            m_Image.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            m_Image.Width = 16;
            m_Image.Height = 16;
            m_Image.Margin = new Thickness(2);

            stack.Children.Add(m_Image);

            m_TextBlock = new TextBlock();
			m_TextBlock.Text = name;
            m_TextBlock.Margin = new Thickness(2);
            m_TextBlock.VerticalAlignment = System.Windows.VerticalAlignment.Center;

            stack.Children.Add(m_TextBlock);

            Header = stack;

			UpdateImage();

			base.Selected += new RoutedEventHandler(OnSelected);
			base.Unselected += new RoutedEventHandler(OnUnselected);
			base.Expanded += new RoutedEventHandler(OnExpanded);
		}

		void OnUnselected(object sender, RoutedEventArgs e)
		{
			UpdateImage();
		}

		void OnSelected(object sender, RoutedEventArgs e)
		{
			UpdateImage();
		}

		void OnExpanded(object sender, RoutedEventArgs e)
		{
			UpdateImage();
		}

		#endregion

		protected abstract void UpdateImage();

		#region Fields

		TextBlock m_TextBlock;
		protected Image m_Image;

		#endregion
	}
}
