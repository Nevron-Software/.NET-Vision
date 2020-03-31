using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.UI.WinForm.Docking;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NDockingPanelsUC.
	/// </summary>
	public class NDockingPanelsBasicFeaturesUC : NExampleUserControl
	{
		#region Constructor

		public NDockingPanelsBasicFeaturesUC()
		{
			InitializeComponent();
		}
		public NDockingPanelsBasicFeaturesUC(MainForm f) : base(f)
		{
			InitializeComponent();
		}


		#endregion

		#region Overrides

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public override void Initialize()
		{
			base.Initialize();

			m_ExampleFormType = typeof(NBasicFeaturesForm);
		}


		#endregion

		#region Event Handlers

		private void m_LaunchButton_Click(object sender, System.EventArgs e)
		{
			Form f = Activator.CreateInstance(m_ExampleFormType) as Form;
			if(f == null)
				return;

			f.Show();
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_LaunchButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// m_LaunchButton
			// 
			this.m_LaunchButton.Location = new System.Drawing.Point(8, 8);
			this.m_LaunchButton.Name = "m_LaunchButton";
			this.m_LaunchButton.Size = new System.Drawing.Size(120, 32);
			this.m_LaunchButton.TabIndex = 0;
			this.m_LaunchButton.Text = "Launch Example";
			this.m_LaunchButton.Click += new System.EventHandler(this.m_LaunchButton_Click);
			// 
			// NDockingPanelsBasicFeaturesUC
			// 
			this.Controls.Add(this.m_LaunchButton);
			this.Name = "NDockingPanelsBasicFeaturesUC";
			this.Size = new System.Drawing.Size(136, 48);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private Nevron.UI.WinForm.Controls.NButton m_LaunchButton;
		private System.ComponentModel.Container components = null;

		internal Type m_ExampleFormType;

		#endregion
	}

	/// <summary>
	/// Summary description for NBasicFeatures.
	/// </summary>
	public class NBasicFeaturesForm : NDockingPanelsExampleForm
	{
		#region Constructor

		public NBasicFeaturesForm()
		{
			InitializeComponent();
		}


		#endregion

		#region Overrides

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// NBasicFeatures
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(800, 414);
			this.Name = "NBasicFeatures";
			this.Text = "Docking Panels Basic Features";

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		#endregion
	}
}
