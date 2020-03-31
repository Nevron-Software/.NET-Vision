using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.Diagram.Extensions;
using Nevron.Diagram.Layout;
using Nevron.Diagram.WinForm;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;

namespace Nevron.Examples.Diagram.WinForm
{
    public class NClassDesignerUC : NDiagramExampleUC
    {
        #region Constructors

        public NClassDesignerUC(NMainForm form)
            : base(form)
        {
        }

        #endregion

        #region NDiagramExampleUC Overrides

        protected override void LoadExample()
        {
            // Init view and document
            view.BeginInit();
            view.VerticalRuler.Visible = false;
            view.HorizontalRuler.Visible = false;
            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;
            view.GlobalVisibility.ShowShadows = false;
            view.ViewLayout = ViewLayout.Fit;

            document.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent;

			// Create and add the UML style sheets to the drawing document
			NUmlShape.AddUmlStyleSheets(document);

            view.EndInit();

            // Init controls
            Panel panel = new Panel();
            panel.SetBounds(0, 0, this.Width, this.commonControlsPanel.Top);
            panel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Controls.Add(panel);

            NLibraryView libView = CreateLibrary();
            libView.Dock = DockStyle.Fill;
            panel.Controls.Add(libView);

            Panel buttonPanel = new Panel();
            buttonPanel.Height = 45;
            buttonPanel.Padding = new Padding(10);
            buttonPanel.Dock = DockStyle.Bottom;
            panel.Controls.Add(buttonPanel);

            NButton importButton = new NButton();
            importButton.Text = "Import Class Hierarchy";
            importButton.Dock = DockStyle.Fill;
            buttonPanel.Controls.Add(importButton);
            importButton.Click += OnImportButtonClick;
        }

        #endregion

        #region Implementation - Library

        private NLibraryView CreateLibrary()
        {
            NLibraryDocument libDocument = new NLibraryDocument();
            libDocument.BackgroundStyle = new NBackgroundStyle();
            libDocument.BackgroundStyle.FillStyle = new NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Vertical, GradientVariant.Variant1,
                Color.RoyalBlue, Color.LightSkyBlue);

            NLibraryView libView = new NLibraryView();
            libView.AllowDrop = false;
            libView.Document = libDocument;
            libView.ScrollBars = ScrollBars.None;
            libView.Selection.Mode = DiagramSelectionMode.Single;
            libView.Document = libDocument;

            NUmlShape shape = new NUmlShape(0, 0, 100, 25, true);
            NMaster master = new NMaster(shape, NGraphicsUnit.Pixel, "Class", "Drag me on the drawing");
            libDocument.AddChild(master);
            shape.Name = "Class";

            shape = new NUmlShape(0, 0, 100, 25, true);
            shape.Abstract = true;
            master = new NMaster(shape, NGraphicsUnit.Pixel, "Abstract Class", "Drag me on the drawing");
            libDocument.AddChild(master);
            shape.Name = "AbstractClass";

            // Connectors
            master = CreateGeneralizationMaster();
            libDocument.AddChild(master);

            master = CreateAssociationMaster();
            libDocument.AddChild(master);

            master = CreateAggregarionMaster();
            libDocument.AddChild(master);

            master = CreateCompositionMaster();
            libDocument.AddChild(master);

            return libView;
        }

        private NMaster CreateGeneralizationMaster()
        {
            NStep3Connector c = new NStep3Connector(new NPointF(0, 0), new NPointF(100, 50), true);
            c.Name = "UML Generalization";

            NStrokeStyle strokeStyle = (NStrokeStyle)document.ComposeStrokeStyle().Clone();
            NArrowheadStyle arrowheadStyle = new NArrowheadStyle(ArrowheadShape.Arrow, string.Empty, ArrowSize, ConFillStyle, strokeStyle);
            NStyle.SetStartArrowheadStyle(c, arrowheadStyle);

            return new NMaster(c, NGraphicsUnit.Pixel, c.Name, "Drag me on the drawing");
        }
        private NMaster CreateAssociationMaster()
        {
            NStep3Connector c = new NStep3Connector(new NPointF(0, 0), new NPointF(100, 50), true);
            c.Name = "UML Association";

            NStrokeStyle strokeStyle = (NStrokeStyle)document.ComposeStrokeStyle().Clone();
            NArrowheadStyle arrowheadStyle = new NArrowheadStyle(ArrowheadShape.OpenedArrow, string.Empty, ArrowSize, ConFillStyle, (NStrokeStyle)strokeStyle.Clone());
            NStyle.SetEndArrowheadStyle(c, arrowheadStyle);

            strokeStyle.Pattern = LinePattern.Dash;
            NStyle.SetStrokeStyle(c, strokeStyle);

            return new NMaster(c, NGraphicsUnit.Pixel, c.Name, "Drag me on the drawing");
        }
        private NMaster CreateAggregarionMaster()
        {
            NStep3Connector c = new NStep3Connector(new NPointF(0, 0), new NPointF(100, 50), true);
            c.Name = "UML Aggregation";

            NStrokeStyle strokeStyle = (NStrokeStyle)document.ComposeStrokeStyle().Clone();
            NArrowheadStyle arrowheadStyle = new NArrowheadStyle(ArrowheadShape.Losangle, string.Empty, LosangleSize, ConFillStyle, (NStrokeStyle)strokeStyle.Clone());
            NStyle.SetStartArrowheadStyle(c, arrowheadStyle);

            arrowheadStyle = new NArrowheadStyle(ArrowheadShape.OpenedArrow, string.Empty, ArrowSize, ConFillStyle, (NStrokeStyle)strokeStyle.Clone());
            NStyle.SetEndArrowheadStyle(c, arrowheadStyle);

            return new NMaster(c, NGraphicsUnit.Pixel, c.Name, "Drag me on the drawing");
        }
        private NMaster CreateCompositionMaster()
        {
            NStep3Connector c = new NStep3Connector(new NPointF(0, 0), new NPointF(100, 50), true);
            c.Name = "UML Composition";

            NStrokeStyle strokeStyle = (NStrokeStyle)document.ComposeStrokeStyle().Clone();
            NArrowheadStyle arrowheadStyle = new NArrowheadStyle(ArrowheadShape.Losangle, string.Empty, LosangleSize, new NColorFillStyle(Color.Silver), (NStrokeStyle)strokeStyle.Clone());
            NStyle.SetStartArrowheadStyle(c, arrowheadStyle);

            arrowheadStyle = new NArrowheadStyle(ArrowheadShape.OpenedArrow, string.Empty, ArrowSize, ConFillStyle, (NStrokeStyle)strokeStyle.Clone());
            NStyle.SetEndArrowheadStyle(c, arrowheadStyle);

            return new NMaster(c, NGraphicsUnit.Pixel, c.Name, "Drag me on the drawing");
        }

        #endregion

        #region Event Handlers

        private void OnImportButtonClick(object sender, EventArgs e)
        {
            if (m_ClassSelectorForm == null)
            {
                m_ClassSelectorForm = new NClassSelectorForm();
            }

            if (m_ClassSelectorForm.ShowDialog() == DialogResult.OK)
            {
                Type selectedType = m_ClassSelectorForm.SelectedType;
                if (selectedType == null)
                    return;

                // Remove all shapes from the active layer
                document.ActiveLayer.RemoveAllChildren();

                // Import the selected class hierarchy
                NClassImporter classImporter = new NClassImporter(document);
                classImporter.ImportInActiveLayer = true;
                classImporter.ImportMembers = m_ClassSelectorForm.ImportClassMembers;
                ((NLayeredTreeLayout)classImporter.Layout).Direction = m_ClassSelectorForm.Direction;
                classImporter.Import(selectedType);
            }
        }

        #endregion

        #region Fields

        private NClassSelectorForm m_ClassSelectorForm;

        #endregion

        #region Constants

        private static readonly NFillStyle ConFillStyle = new NColorFillStyle(KnownArgbColorValue.White);
        private static readonly NSizeL ArrowSize = new NSizeL(4, 4);
        private static readonly NSizeL LosangleSize = new NSizeL(8, 6);

        #endregion

        #region Nested Types

        private class NClassSelectorForm : NForm
        {
            #region Constructors

            public NClassSelectorForm()
            {
                Initialize();
            }

            #endregion

            #region Properties

            public Type SelectedType
            {
                get
                {
                    return m_TypesCombo.SelectedItem as Type;
                }
            }
            public bool ImportClassMembers
            {
                get
                {
                    return m_ImportMembersCheckBox.Checked;
                }
            }
            public LayoutDirection Direction
            {
                get
                {
                    return (LayoutDirection)m_DirectionComboBox.SelectedItem;
                }
            }

            #endregion

            #region Implementation

            private void Initialize()
            {
                this.Text = "Import Class Hierarchy";
                this.Width = 400;
                this.Height = 400;
                this.StartPosition = FormStartPosition.CenterScreen;

                this.SuspendLayout();
                m_TypesCombo = new ComboBox();
                m_TypesCombo.DropDownStyle = ComboBoxStyle.Simple;
                m_TypesCombo.Sorted = true;
                m_TypesCombo.Dock = DockStyle.Fill;
                this.Controls.Add(m_TypesCombo);

                Panel topPanel = new Panel();
                topPanel.Padding = new Padding(0, 5, 0, 5);
                topPanel.Height = 40;
                topPanel.Dock = DockStyle.Top;
                this.Controls.Add(topPanel);

                m_AssemblyLabel = new Label();
                m_AssemblyLabel.TextAlign = ContentAlignment.MiddleLeft;
                m_AssemblyLabel.Text = "Click <Browse> to select an assembly";
                m_AssemblyLabel.Dock = DockStyle.Fill;
                topPanel.Controls.Add(m_AssemblyLabel);

                NButton browseButton = new NButton();
                browseButton.Text = "Browse";
                browseButton.Dock = DockStyle.Right;
                browseButton.Click += OnBrowseButtonClick;
                topPanel.Controls.Add(browseButton);

                m_ImportMembersCheckBox = new CheckBox();
                m_ImportMembersCheckBox.Checked = true;
                m_ImportMembersCheckBox.Text = "Import class members";
                m_ImportMembersCheckBox.Dock = DockStyle.Bottom;
                this.Controls.Add(m_ImportMembersCheckBox);

                FlowLayoutPanel directionPanel = new FlowLayoutPanel();
                directionPanel.Height = 30;
                directionPanel.Dock = DockStyle.Bottom;
                this.Controls.Add(directionPanel);

                Label directionLabel = new Label();
                directionLabel.TextAlign = ContentAlignment.MiddleLeft;
                directionLabel.Text = "Layout Direction:";
                directionPanel.Controls.Add(directionLabel);

                m_DirectionComboBox = new ComboBox();
                m_DirectionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                m_DirectionComboBox.DataSource = Enum.GetValues(typeof(LayoutDirection));
                m_DirectionComboBox.SelectedItem = LayoutDirection.TopToBottom;
                directionPanel.Controls.Add(m_DirectionComboBox);

                NButton importButton = new NButton();
                importButton.Text = "Import";
                importButton.Dock = DockStyle.Bottom;
                importButton.Click += OnImportButtonClick;
                this.Controls.Add(importButton);
                this.ResumeLayout(false);

                m_OpenAssemblyDialog = new OpenFileDialog();
                m_OpenAssemblyDialog.Title = "Open assembly";
                m_OpenAssemblyDialog.Filter = "Assemblies (*.dll)|*.dll";
            }
            private void FillClasses(Assembly assembly)
            {
                m_TypesCombo.DataSource = null;

                Type[] types = assembly.GetTypes();
                List<Type> classes = new List<Type>();
                int i, count = types.Length;
                for (i = 0; i < count; i++)
                {
                    if (types[i].IsClass && types[i].IsPublic)
                    {
                        classes.Add(types[i]);
                    }
                }

                m_TypesCombo.DataSource = classes;
                m_TypesCombo.DisplayMember = "Name";
            }

            #endregion

            #region Event Handlers

            private void OnBrowseButtonClick(object sender, EventArgs e)
            {
                if (m_OpenAssemblyDialog.ShowDialog() != DialogResult.OK)
                    return;

                Assembly assembly = null;
                string fileName = m_OpenAssemblyDialog.FileName;
                try
                {
                    assembly = Assembly.LoadFrom(fileName);
                    m_AssemblyLabel.Text = fileName;
                    FillClasses(assembly);
                }
                catch
                {
                    MessageBox.Show("'" + fileName + "' is not a valid .NET assembly.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            private void OnImportButtonClick(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.OK;
            }

            #endregion

            #region Fields

            private ComboBox m_TypesCombo;
            private Label m_AssemblyLabel;
            private CheckBox m_ImportMembersCheckBox;
            private ComboBox m_DirectionComboBox;
            private OpenFileDialog m_OpenAssemblyDialog;

            #endregion
        }

        #endregion
    }
}