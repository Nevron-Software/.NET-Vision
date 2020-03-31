using System;

using Nevron.Diagram;
using Nevron.Diagram.Extensions;
using Nevron.Diagram.Layout;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.WinForm
{
    /// <summary>
    /// Summary description for NDiagramClassHierarchyUC.
    /// </summary>
    public class NDiagramClassHierarchyUC : NDiagramExampleUC
    {
        #region Constructor

        public NDiagramClassHierarchyUC(NMainForm form)
            : base(form)
        {
            InitializeComponent();
        }
        static NDiagramClassHierarchyUC()
        {
            TYPES = new Type[] {
                typeof(NLayout),
                typeof(NPrimitiveShape),
                typeof(NShapePoint)
            };
        }

        #endregion

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbBaseClass = new Nevron.UI.WinForm.Controls.NComboBox();
            this.cbFormatStyle = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Base Class:";
            // 
            // cbBaseClass
            // 
            this.cbBaseClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBaseClass.ListProperties.ColumnOnLeft = false;
            this.cbBaseClass.Location = new System.Drawing.Point(73, 4);
            this.cbBaseClass.Name = "cbBaseClass";
            this.cbBaseClass.Size = new System.Drawing.Size(179, 21);
            this.cbBaseClass.TabIndex = 2;
            // 
            // cbFormatStyle
            // 
            this.cbFormatStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFormatStyle.ListProperties.ColumnOnLeft = false;
            this.cbFormatStyle.Location = new System.Drawing.Point(73, 37);
            this.cbFormatStyle.Name = "cbFormatStyle";
            this.cbFormatStyle.Size = new System.Drawing.Size(179, 21);
            this.cbFormatStyle.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Format Style:";
            // 
            // NClassImporterUC
            // 
            this.Controls.Add(this.cbFormatStyle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbBaseClass);
            this.Controls.Add(this.label1);
            this.Name = "NClassImporterUC";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cbBaseClass, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cbFormatStyle, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region NDiagramExampleUC Overrides

        protected override void LoadExample()
        {
            // begin view init
            view.BeginInit();

            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;

            // init form controls
            InitFormControls();

            // end view init
            view.EndInit();
        }
        protected override void AttachToEvents()
        {
            base.AttachToEvents();

            cbFormatStyle.SelectedIndexChanged += new System.EventHandler(this.cbFormatStyle_SelectedIndexChanged);
            cbBaseClass.SelectedIndexChanged += new System.EventHandler(this.cbBaseClass_SelectedIndexChanged);
        }

        #endregion

        #region Implementation

        private void CreateDiagram(Type type)
        {
            document.BeginInit();

            document.Layers.RemoveAllChildren();
            NClassImporter importer = new NClassImporter(document);
            if (cbFormatStyle.SelectedIndex != -1)
            {
                importer.MemberFormatStyle = (MemberFormatStyle)cbFormatStyle.SelectedItem;
            }

            NLayer layer = importer.Import(type);
            document.ActiveLayerUniqueId = layer.UniqueId;
            document.SizeToContent();

            document.EndInit();

            NShape shape = (NShape)layer.GetChildByName(type.Name);
            view.ViewportOrigin = new NPointF(shape.Center.X - view.ViewportSize.Width / 2, 0);
        }
        private void InitFormControls()
        {
            cbFormatStyle.Items.Add(MemberFormatStyle.NameOnly);
            cbFormatStyle.Items.Add(MemberFormatStyle.CSharp);
            cbFormatStyle.Items.Add(MemberFormatStyle.CSharp_Short);
            cbFormatStyle.Items.Add(MemberFormatStyle.Pascal);
            cbFormatStyle.Items.Add(MemberFormatStyle.Pascal_Short);

            int i, count = TYPES.Length;
            for (i = 0; i < count; i++)
            {
                cbBaseClass.Items.Add(TYPES[i].Name);
            }

            cbFormatStyle.SelectedIndex = 0;
            cbBaseClass.SelectedIndex = 1;

            CreateDiagram(TYPES[cbBaseClass.SelectedIndex]);
        }

        #endregion

        #region Event Handlers

        private void cbBaseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBaseClass.SelectedIndex == -1)
                return;

            CreateDiagram(TYPES[cbBaseClass.SelectedIndex]);
        }
        private void cbFormatStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFormatStyle.SelectedIndex == -1)
                return;

            CreateDiagram(TYPES[cbBaseClass.SelectedIndex]);
        }

        #endregion

        #region Designer Fields

        private Nevron.UI.WinForm.Controls.NComboBox cbBaseClass;
        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NComboBox cbFormatStyle;
        private System.Windows.Forms.Label label2;

        #endregion

        #region Fields

        private static readonly Type[] TYPES;

        #endregion
    }
}