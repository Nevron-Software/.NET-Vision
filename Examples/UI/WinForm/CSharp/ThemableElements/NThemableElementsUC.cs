using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NThemableElementsUC.
	/// </summary>
	public class NThemableElementsUC : NExampleUserControl
	{
		#region Constructor

		public NThemableElementsUC(MainForm f) : base(f)
		{
			InitializeComponent();

			Dock = DockStyle.Fill;

			NRectShape shape = new NRectShape();
			shape.StrokeStyle = new NStrokeStyle(3, Color.Brown);

			m_Host = new NUIElementHost();
			m_ElementContainer = new NUIElementContainer();
			m_ElementContainer.Style.Background = shape;
			m_Host.Bounds = new Rectangle(10, 10, 250, 250);

			//add one button
			NPushButtonElement button = new NPushButtonElement();
			button.Text = "Push Button";
			button.Bounds = new NRectangle(10, 10, 100, 24);
			m_ElementContainer.AddChild(button);

			//add one checkbox
			NCheckBoxElement checkBox = new NCheckBoxElement();
			checkBox.Text = "Check Box";
			checkBox.ThreeStates = true;
			checkBox.Bounds = new NRectangle(10, 36, 100, 24);
			m_ElementContainer.AddChild(checkBox);

			//add one radiobox
			NRadioBoxElement radioBox = new NRadioBoxElement();
			radioBox.Text = "Radio Box 1";
			radioBox.Bounds = new NRectangle(10, 62, 100, 24);
			m_ElementContainer.AddChild(radioBox);

			radioBox = new NRadioBoxElement();
			radioBox.Text = "Radio Box 2";
			radioBox.Bounds = new NRectangle(120, 62, 100, 24);
			m_ElementContainer.AddChild(radioBox);

			NCheckButtonElement checkButton = new NCheckButtonElement();
			checkButton.Text = "Check Button";
			checkButton.Bounds = new NRectangle(10, 88, 100, 24);
			m_ElementContainer.AddChild(checkButton);

			NRadioButtonElement radioButton = new NRadioButtonElement();
			radioButton.Text = "Radio Button 1";
			radioButton.Bounds = new NRectangle(10, 116, 100, 24);
			m_ElementContainer.AddChild(radioButton);

			radioButton = new NRadioButtonElement();
			radioButton.Text = "Radio Button 2";
			radioButton.Bounds = new NRectangle(120, 116, 100, 24);
			m_ElementContainer.AddChild(radioButton);

			m_Host.Element = m_ElementContainer;
			m_Host.Parent = this;
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
			base.Initialize ();

			m_iSuspendUpdate++;

			this.themeCombo.Items.Add("System");
			this.themeCombo.Items.Add("Office 2003");
			this.themeCombo.Items.Add("Office 2007");
			this.themeCombo.SelectedIndex = 1;

			m_iSuspendUpdate--;
		}


		#endregion

		#region Implementation

		internal NTheme LoadResourceTheme(string themeName)
		{
			Type t = GetType();
			Assembly assembly = t.Assembly;

			string path = "Nevron.Examples.UI.WinForm.Resources.Themes.";

			Stream stream;

			if(NExamplesForm.IsVBContext)
				stream = assembly.GetManifestResourceStream(themeName);
			else
				stream = assembly.GetManifestResourceStream(path + themeName);

			NTheme theme = NTheme.FromStream(stream, typeof(NTheme));

			stream.Close();

			return theme;
		}


		#endregion

		#region Event Handlers

		private void themeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate > 0)
				return;

			int index = themeCombo.SelectedIndex;
			if(index == -1)
				return;

			NTheme theme = null;

			switch(index)
			{
				case 0:
					theme = new Nevron.UI.Themes.System.NSystemTheme();
					break;
				case 1:
					theme = new Nevron.UI.Themes.Office2003.NOffice2003Theme();
					break;
				case 2:
					theme = LoadResourceTheme("Office2007Blue.xml");
					break;
			}

			if(theme == null)
				return;

			INTheme oldTheme = NThemeManager.Instance.CurrentTheme;
            NThemeManager.Instance.CurrentTheme = theme;

			oldTheme.Dispose();
		}

		private void toggleEnabledButton_Click(object sender, System.EventArgs e)
		{
			m_ElementContainer.Enabled ^= true;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.themeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.toggleEnabledButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// themeCombo
			// 
			this.themeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.themeCombo.Location = new System.Drawing.Point(80, 264);
			this.themeCombo.Name = "themeCombo";
			this.themeCombo.Size = new System.Drawing.Size(200, 22);
			this.themeCombo.TabIndex = 0;
			this.themeCombo.Text = "nComboBox1";
			this.themeCombo.SelectedIndexChanged += new System.EventHandler(this.themeCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.Location = new System.Drawing.Point(8, 264);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Theme:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// toggleEnabledButton
			// 
			this.toggleEnabledButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.toggleEnabledButton.Location = new System.Drawing.Point(80, 232);
			this.toggleEnabledButton.Name = "toggleEnabledButton";
			this.toggleEnabledButton.Size = new System.Drawing.Size(120, 24);
			this.toggleEnabledButton.TabIndex = 2;
			this.toggleEnabledButton.Text = "Toggle Enabled";
			this.toggleEnabledButton.Click += new System.EventHandler(this.toggleEnabledButton_Click);
			// 
			// NThemableElementsUC
			// 
			this.Controls.Add(this.toggleEnabledButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.themeCombo);
			this.Name = "NThemableElementsUC";
			this.Size = new System.Drawing.Size(400, 296);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		internal NUIElementHost m_Host;
		internal NUIElementContainer m_ElementContainer;
		private Nevron.UI.WinForm.Controls.NComboBox themeCombo;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NButton toggleEnabledButton;
		private System.ComponentModel.Container components = null;

		#endregion
	}
}
