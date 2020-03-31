using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Nevron.Examples.Chart.Wpf
{
	class NFolderTreeNode : NTreeNode
	{
		#region Constuctors

		/// <summary>
		/// Initializer constructor
		/// </summary>
		/// <param name="name"></param>
		/// <param name="bitmap"></param>
		/// <param name="userControlType"></param>
		public NFolderTreeNode(string name)
			: base(name)
		{
		}

		#endregion

		#region Overrides

		protected override void UpdateImage()
		{
			if (base.IsExpanded)
			{
				m_Image.Source = m_FolderOpened;
			}
			else 
			{
				m_Image.Source = m_FolderClosed;
			}
		}

		#endregion

		internal NFolderTreeNode AddFolder(string name)
		{
			NFolderTreeNode folder = new NFolderTreeNode(name);
			this.Items.Add(folder);
			return folder;
		}

		internal void AddExample(string name, Type userControlType)
		{
			this.Items.Add(new NExampleTreeNode(name, userControlType));
		}

		#region Static Fields

		static BitmapImage m_FolderClosed = new BitmapImage(new Uri("pack://application:,,/Resources/Images/FolderClosed.png"));
		static BitmapImage m_FolderOpened = new BitmapImage(new Uri("pack://application:,,/Resources/Images/FolderOpened.png"));

		#endregion
	}
}
