using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;

using Nevron.Serialization;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;
using Nevron.Editors;
using Nevron.Diagram;
using Nevron.Diagram.Extensions;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NPersistencyManagerUC.
	/// </summary>
	public class NPersistencyManagerUC : NDiagramExampleUC
	{
		#region Constructor

		public NPersistencyManagerUC(NMainForm form) : base(form)
		{
			InitializeComponent();
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.loadFromFileButton = new Nevron.UI.WinForm.Controls.NButton();
			this.saveToFileButton = new Nevron.UI.WinForm.Controls.NButton();
			this.loadFromStreamButton = new Nevron.UI.WinForm.Controls.NButton();
			this.saveToStreamButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.persistencyFormatCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.filePersistanceGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.memoryPersistanceGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.filePersistanceGroupBox.SuspendLayout();
			this.memoryPersistanceGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// loadFromFileButton
			// 
			this.loadFromFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.loadFromFileButton.Location = new System.Drawing.Point(8, 48);
			this.loadFromFileButton.Name = "loadFromFileButton";
			this.loadFromFileButton.Size = new System.Drawing.Size(234, 24);
			this.loadFromFileButton.TabIndex = 1;
			this.loadFromFileButton.Text = "Load from file...";
			this.loadFromFileButton.Click += new System.EventHandler(this.loadFromFileButton_Click);
			// 
			// saveToFileButton
			// 
			this.saveToFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.saveToFileButton.Location = new System.Drawing.Point(8, 16);
			this.saveToFileButton.Name = "saveToFileButton";
			this.saveToFileButton.Size = new System.Drawing.Size(234, 24);
			this.saveToFileButton.TabIndex = 0;
			this.saveToFileButton.Text = "Save to file...";
			this.saveToFileButton.Click += new System.EventHandler(this.saveToFileButton_Click);
			// 
			// loadFromStreamButton
			// 
			this.loadFromStreamButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.loadFromStreamButton.Location = new System.Drawing.Point(8, 104);
			this.loadFromStreamButton.Name = "loadFromStreamButton";
			this.loadFromStreamButton.Size = new System.Drawing.Size(234, 24);
			this.loadFromStreamButton.TabIndex = 3;
			this.loadFromStreamButton.Text = "Load from stream";
			this.loadFromStreamButton.Click += new System.EventHandler(this.loadFromStreamButton_Click);
			// 
			// saveToStreamButton
			// 
			this.saveToStreamButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.saveToStreamButton.Location = new System.Drawing.Point(8, 72);
			this.saveToStreamButton.Name = "saveToStreamButton";
			this.saveToStreamButton.Size = new System.Drawing.Size(234, 24);
			this.saveToStreamButton.TabIndex = 2;
			this.saveToStreamButton.Text = "Save to stream";
			this.saveToStreamButton.Click += new System.EventHandler(this.saveToStreamButton_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Persistency format:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// persistencyFormatCombo
			// 
			this.persistencyFormatCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.persistencyFormatCombo.Location = new System.Drawing.Point(8, 40);
			this.persistencyFormatCombo.Name = "persistencyFormatCombo";
			this.persistencyFormatCombo.Size = new System.Drawing.Size(234, 21);
			this.persistencyFormatCombo.TabIndex = 1;
			this.persistencyFormatCombo.SelectedIndexChanged += new System.EventHandler(this.persistencyFormatCombo_SelectedIndexChanged);
			// 
			// filePersistanceGroupBox
			// 
			this.filePersistanceGroupBox.Controls.Add(this.loadFromFileButton);
			this.filePersistanceGroupBox.Controls.Add(this.saveToFileButton);
			this.filePersistanceGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.filePersistanceGroupBox.ImageIndex = 0;
			this.filePersistanceGroupBox.Location = new System.Drawing.Point(0, 0);
			this.filePersistanceGroupBox.Name = "filePersistanceGroupBox";
			this.filePersistanceGroupBox.Size = new System.Drawing.Size(250, 80);
			this.filePersistanceGroupBox.TabIndex = 0;
			this.filePersistanceGroupBox.TabStop = false;
			this.filePersistanceGroupBox.Text = "File persistency";
			// 
			// memoryPersistanceGroupBox
			// 
			this.memoryPersistanceGroupBox.Controls.Add(this.label1);
			this.memoryPersistanceGroupBox.Controls.Add(this.persistencyFormatCombo);
			this.memoryPersistanceGroupBox.Controls.Add(this.saveToStreamButton);
			this.memoryPersistanceGroupBox.Controls.Add(this.loadFromStreamButton);
			this.memoryPersistanceGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.memoryPersistanceGroupBox.ImageIndex = 0;
			this.memoryPersistanceGroupBox.Location = new System.Drawing.Point(0, 80);
			this.memoryPersistanceGroupBox.Name = "memoryPersistanceGroupBox";
			this.memoryPersistanceGroupBox.Size = new System.Drawing.Size(250, 144);
			this.memoryPersistanceGroupBox.TabIndex = 1;
			this.memoryPersistanceGroupBox.TabStop = false;
			this.memoryPersistanceGroupBox.Text = "Memory persistency";
			// 
			// NPersistencyManagerUC
			// 
			this.Controls.Add(this.memoryPersistanceGroupBox);
			this.Controls.Add(this.filePersistanceGroupBox);
			this.Name = "NPersistencyManagerUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.filePersistanceGroupBox, 0);
			this.Controls.SetChildIndex(this.memoryPersistanceGroupBox, 0);
			this.filePersistanceGroupBox.ResumeLayout(false);
			this.memoryPersistanceGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// init form fields
			persistencyManager = new NPersistencyManager();

			// IMPORTANT: custom types added to the DOM must be registered 
			// in the persistency manager if you intend to save/load in XML format
			persistencyManager.Serializer.XmlExtraTypes = new Type[] {typeof(NCustomShape)};

			// begin view init
			view.BeginInit();
            
            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;

			// init document
			document.BeginInit();
			CreateDefaultFlowDiagram();
			document.EndInit();

			// init form controls
			InitFormControls();

			// end desigenr init
			view.EndInit();

			UpdateControlsState();
		}

		protected override void ResetExample()
		{
			MemoryStream = null;
			MemoryStreamFormat = PersistencyFormat.Binary;
			persistencyFormatCombo.SelectedItem = PersistencyFormat.Binary;

			base.ResetExample();
		}

		protected override void CreateDefaultFlowDiagram()
		{
			base.CreateDefaultFlowDiagram();

			NCustomShape cs = new NCustomShape();
			cs.Bounds = new NRectangleF(10, 10, 100, 60);
			document.ActiveLayer.AddChild(cs);
		}

		#endregion

		#region Implementation

		private void InitFormControls()
		{
			PauseEventsHandling();

			persistencyFormatCombo.FillFromEnum(typeof(PersistencyFormat));
			persistencyFormatCombo.SelectedItem = PersistencyFormat.Binary;

			ResumeEventsHandling();
		}

		private void UpdateControlsState()
		{
			PersistencyFormat format = (PersistencyFormat)persistencyFormatCombo.SelectedIndex; 
			loadFromStreamButton.Enabled = MemoryStreamFormat == format && MemoryStream != null && MemoryStream.Length > 0;

		}
		#endregion
		
		#region Event Handlers

		private void saveToStreamButton_Click(object sender, System.EventArgs e)
		{
			MemoryStream = new MemoryStream();
			MemoryStreamFormat = (PersistencyFormat)persistencyFormatCombo.SelectedIndex; 

			Cursor saveCursor = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;

			try
			{
				persistencyManager.PersistentDocument.Sections.Clear();
				persistencyManager.PersistentDocument.Sections.Add(new NPersistentSection("DOC", document));

				if (persistencyManager.SaveToStream(MemoryStream, MemoryStreamFormat, null) == false)
				{
					MemoryStream = null;
				}
			}
			finally
			{
				Cursor.Current = saveCursor;
			}

			UpdateControlsState();
		}

		private void loadFromStreamButton_Click(object sender, System.EventArgs e)
		{
			MemoryStream.Seek(0, SeekOrigin.Begin);

			Cursor saveCursor = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;

			try
			{
				persistencyManager.LoadFromStream(MemoryStream, MemoryStreamFormat, null);
				document = (persistencyManager.PersistentDocument.Sections[0].Object as NDrawingDocument);

				Form.Document = document;
				view.Document = document;
			}
			finally
			{
				Cursor.Current = saveCursor;
				if (document == null)
				{
					document = view.Document as NDrawingDocument;
				}
			}
			
			view.SmartRefresh();
		}

		private void saveToFileButton_Click(object sender, System.EventArgs e)
		{
			persistencyManager.SaveDrawingToFile(document);
		}

		private void loadFromFileButton_Click(object sender, System.EventArgs e)
		{
			document = persistencyManager.LoadDrawingFromFile();
			if (document != null)
			{
				view.Document = document;
				Form.Document = document;
			}
			else
			{
				document = view.Document as NDrawingDocument;
			}
			
			view.SmartRefresh();
		}
		
		private void persistencyFormatCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateControlsState();
		}

		#endregion

		#region Designer Fields

		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NButton loadFromFileButton;
		private Nevron.UI.WinForm.Controls.NGroupBox filePersistanceGroupBox;
		private Nevron.UI.WinForm.Controls.NGroupBox memoryPersistanceGroupBox;
		private Nevron.UI.WinForm.Controls.NButton loadFromStreamButton;
		private Nevron.UI.WinForm.Controls.NButton saveToStreamButton;
		private Nevron.UI.WinForm.Controls.NButton saveToFileButton;
		private Nevron.UI.WinForm.Controls.NComboBox persistencyFormatCombo;

		private System.ComponentModel.Container components = null;

		#endregion

		#region Fields

		private NPersistencyManager persistencyManager;
		private MemoryStream MemoryStream;
		private PersistencyFormat MemoryStreamFormat;

		#endregion
	}

	[Serializable]
	public class NCustomShape : NCompositeShape
	{
		/// <summary>
		/// Default constructor
		/// </summary>
		public NCustomShape()
		{
			Primitives.AddChild(new NRectanglePath(new NRectangleF(0, 0, 1, 1)));
			UpdateModelBounds();

			Style.FillStyle = new NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Horizontal,
				GradientVariant.Variant1,
				Color.FromArgb(0xff, 0x55, 0x55),
				Color.FromArgb(0x66, 0x00, 0x00));

			Text = "Custom serializable shape";

			m_boolProperty = false;
		}

		/// <summary>
		/// Serializable and history aware custom boolean property
		/// </summary>
		[XmlAttribute, DefaultValue(false)]
		public bool BoolProperty
		{
			get
			{
				return m_boolProperty;
			}
			set
			{
				if (m_boolProperty == value)
					return;

				if (OnPropertyChanging("m_boolProperty", value) == false)
					return;

				RecordProperty("BoolProperty");
				m_boolProperty = value;

				OnPropertyChanged("BoolProperty");
			}
		}

		/// <summary>
		/// bool property value
		/// </summary>
		internal bool m_boolProperty;
	}
}