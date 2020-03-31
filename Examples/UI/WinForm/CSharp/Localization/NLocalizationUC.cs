using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.Globalization;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;
using Nevron.Editors;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NLocalizationUC.
	/// </summary>
	public class NLocalizationUC : NExampleUserControl
	{
		#region Constructor

		public NLocalizationUC(MainForm f) : base(f)
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

				//NLocalizationManager.Instance.Dictionary = null;
			}
			base.Dispose( disposing );
		}

		public override void Initialize()
		{
			base.Initialize ();

			InitGermanTranslations();
			InitFrenchTranslations();
		}

		#endregion

		#region Implementation

        internal void InitGermanTranslations()
		{
            m_GermanDictionary = new NDictionary("German");

            m_GermanDictionary.Add("&Restore", "&Restaurieren");
            m_GermanDictionary.Add("&Move", "&Aufregen");
            m_GermanDictionary.Add("&Size", "&Schlichten");
            m_GermanDictionary.Add("Mi&nimize", "Mi&nimieren");
            m_GermanDictionary.Add("Ma&ximize", "Ma&ximieren");
            m_GermanDictionary.Add("&Close", "&Verwachsen");
		}
		internal void InitFrenchTranslations()
		{
            m_FrenchDictionary = new NDictionary("French");

            m_FrenchDictionary.Add("&Restore", "&Restaurer");
            m_FrenchDictionary.Add("&Move", "&Mouvoir");
            m_FrenchDictionary.Add("&Size", "&Ampleur");
            m_FrenchDictionary.Add("Mi&nimize", "Mi&nimiser");
            m_FrenchDictionary.Add("Ma&ximize", "Ma&ximiser");
            m_FrenchDictionary.Add("&Close", "&Fermer");
		}

		#endregion

		#region Event Handlers

		private void germanDictionaryBtn_Click(object sender, System.EventArgs e)
		{
            NLocalizationManager.Instance.GlobalDictionary.Clear();
            NLocalizationManager.Instance.GlobalDictionary.CombineWith(m_GermanDictionary);
		}

		private void frenchDictionaryBtn_Click(object sender, System.EventArgs e)
		{
            NLocalizationManager.Instance.GlobalDictionary.Clear();
            NLocalizationManager.Instance.GlobalDictionary.CombineWith(m_FrenchDictionary);
		}

		private void defaultDictionaryBtn_Click(object sender, System.EventArgs e)
		{
            NLocalizationManager.Instance.Clear();
		}
		private void editBtn_Click(object sender, System.EventArgs e)
		{
            NLocalizationManagerEditor editor = new NLocalizationManagerEditor();
            editor.ShowDialog();
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nRichTextLabel1 = new Nevron.UI.WinForm.Controls.NRichTextLabel();
			this.germanDictionaryBtn = new Nevron.UI.WinForm.Controls.NButton();
			this.frenchDictionaryBtn = new Nevron.UI.WinForm.Controls.NButton();
			this.defaultDictionaryBtn = new Nevron.UI.WinForm.Controls.NButton();
			this.editBtn = new Nevron.UI.WinForm.Controls.NButton();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel1)).BeginInit();
			this.SuspendLayout();
			// 
			// nRichTextLabel1
			// 
			this.nRichTextLabel1.ClientPadding = new Nevron.UI.NPadding(10, 10, 10, 10);
			this.nRichTextLabel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.nRichTextLabel1.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nRichTextLabel1.Item.Style.RichTextFormat = new Nevron.UI.NRichTextFormat(Nevron.GraphicsCore.LineTrimStyle.Word, Nevron.GraphicsCore.ParagraphAlignment.Justify, 0, 0, 0, 0, 0, 0, 0);
			this.nRichTextLabel1.Location = new System.Drawing.Point(5, 5);
			this.nRichTextLabel1.Name = "nRichTextLabel1";
			this.nRichTextLabel1.Size = new System.Drawing.Size(310, 139);
			this.nRichTextLabel1.StrokeInfo.PenWidth = 3;
			this.nRichTextLabel1.StrokeInfo.Rounding = 5;
			this.nRichTextLabel1.TabIndex = 0;
			this.nRichTextLabel1.Text = @"The Nevron <b>NLocalizationManager</b> provides simple yet elegant way for localization of all the internal strings in an application by specifying  custom Dictionaries. The example creates two dictionaries - German and French. Apply the desired dictionary and right-click on the Main Form's caption.";
			// 
			// germanDictionaryBtn
			// 
			this.germanDictionaryBtn.Location = new System.Drawing.Point(8, 192);
			this.germanDictionaryBtn.Name = "germanDictionaryBtn";
			this.germanDictionaryBtn.Size = new System.Drawing.Size(176, 32);
			this.germanDictionaryBtn.TabIndex = 1;
			this.germanDictionaryBtn.Text = "German Dictionary";
			this.germanDictionaryBtn.Click += new System.EventHandler(this.germanDictionaryBtn_Click);
			// 
			// frenchDictionaryBtn
			// 
			this.frenchDictionaryBtn.Location = new System.Drawing.Point(8, 232);
			this.frenchDictionaryBtn.Name = "frenchDictionaryBtn";
			this.frenchDictionaryBtn.Size = new System.Drawing.Size(176, 32);
			this.frenchDictionaryBtn.TabIndex = 2;
			this.frenchDictionaryBtn.Text = "French Dictionary";
			this.frenchDictionaryBtn.Click += new System.EventHandler(this.frenchDictionaryBtn_Click);
			// 
			// defaultDictionaryBtn
			// 
			this.defaultDictionaryBtn.Location = new System.Drawing.Point(8, 152);
			this.defaultDictionaryBtn.Name = "defaultDictionaryBtn";
			this.defaultDictionaryBtn.Size = new System.Drawing.Size(176, 32);
			this.defaultDictionaryBtn.TabIndex = 3;
			this.defaultDictionaryBtn.Text = "Default Dictionary";
			this.defaultDictionaryBtn.Click += new System.EventHandler(this.defaultDictionaryBtn_Click);
			// 
			// editBtn
			// 
			this.editBtn.Location = new System.Drawing.Point(8, 272);
			this.editBtn.Name = "editBtn";
			this.editBtn.Size = new System.Drawing.Size(176, 32);
			this.editBtn.TabIndex = 4;
			this.editBtn.Text = "Edit Localization Manager...";
			this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
			// 
			// NLocalizationUC
			// 
			this.Controls.Add(this.editBtn);
			this.Controls.Add(this.defaultDictionaryBtn);
			this.Controls.Add(this.frenchDictionaryBtn);
			this.Controls.Add(this.germanDictionaryBtn);
			this.Controls.Add(this.nRichTextLabel1);
			this.DockPadding.All = 5;
			this.Name = "NLocalizationUC";
			this.Size = new System.Drawing.Size(320, 312);
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		internal NDictionary m_FrenchDictionary;
		internal NDictionary m_GermanDictionary;

        #endregion

        #region Designer Fields

        private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NRichTextLabel nRichTextLabel1;
		private Nevron.UI.WinForm.Controls.NButton germanDictionaryBtn;
		private Nevron.UI.WinForm.Controls.NButton defaultDictionaryBtn;
		private Nevron.UI.WinForm.Controls.NButton editBtn;
		private Nevron.UI.WinForm.Controls.NButton frenchDictionaryBtn;

		#endregion
	}
}
