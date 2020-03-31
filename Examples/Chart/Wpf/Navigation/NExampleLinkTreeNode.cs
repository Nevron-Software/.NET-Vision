
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// Represents a node that links to another node
	/// </summary>
	class NExampleLinkTreeNode : NTreeNode
	{
		#region Constuctors

		/// <summary>
		/// Initializer constructor
		/// </summary>
		/// <param name="name"></param>
		/// <param name="node"></param>
		public NExampleLinkTreeNode(string name, NExampleTreeNode node)
			: base(name)
		{
			m_ExampleNode = node;
			UpdateImage();
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
				return m_ExampleNode.UserControlType;
			}
		}

		#endregion

		#region Overrides

		protected override void UpdateImage()
		{
			if (base.IsSelected)
			{
				m_Image.Source = NExampleTreeNode.m_ChartImageSelected;
			}
			else
			{
				m_Image.Source = NExampleTreeNode.m_ChartImage;
			}
		}

		#endregion

		#region Fields

		NExampleTreeNode m_ExampleNode;

		#endregion
	}
}
