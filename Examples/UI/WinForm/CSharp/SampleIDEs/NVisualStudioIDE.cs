using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using Nevron.UI.WinForm.Docking;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NVSNET2003.
	/// </summary>
	public class NVisualStudioIDE : NForm
	{
		#region Constructor

		public NVisualStudioIDE(NIDELoadUC loader)
		{
			InitializeComponent();

			m_Loader = loader;
			m_SolutionExplorer.HideSelection = false;

			ResizeRedraw = false;

			m_SolutionExplorer.Dock = DockStyle.Fill;

			LoadDockingFramework();

			PopulateSolutionExplorer();
			LoadCommandBars();

			nStatusBar1.SendToBack();

			NUIManager.ApplyPalette(this);
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

				m_CommandBarsManager.Dispose();
				m_DockManager.Dispose();
			}
			base.Dispose( disposing );
		}


		#endregion

		#region Implementation

		internal void AddDocument(FileInfo fi, TreeNode node)
		{
		}
		internal NWebBrowser GetDocument()
		{
			NWebBrowser document = new NWebBrowser();
			document.Dock = DockStyle.Fill;

			return document;
		}

		internal void PopulateSolutionExplorer()		
		{
			try
			{
				m_SolutionExplorer.Font = m_DockManager.CaptionStyle.Font;
				m_SolutionExplorer.ImageList = NIDELoadUC.SolutionExplorerImageList;
				m_SolutionExplorer.ImageIndex = -1;
				m_SolutionExplorer.SelectedImageIndex = -1;

				m_SolutionExplorer.BeforeExpand += new TreeViewCancelEventHandler(m_SolutionExplorer_BeforeExpand);
				m_SolutionExplorer.BeforeCollapse += new TreeViewCancelEventHandler(m_SolutionExplorer_BeforeCollapse);
				m_SolutionExplorer.DoubleClick += new EventHandler(m_SolutionExplorer_DoubleClick);

				TreeNode project = m_SolutionExplorer.Nodes.Add("UserInterfaceExamples");
				project.ImageIndex = 5;
				project.SelectedImageIndex = 5;

				//references
				TreeNode references = project.Nodes.Add("References");
				references.ImageIndex = 2;
				references.SelectedImageIndex = 2;
				PopulateReferences(references);

				//DirectoryInfo dirInfo = new DirectoryInfo(Path.GetFullPath("../../"));
				//PopulateDirectory(project, dirInfo);
			}
			catch
			{
			}
		}

		internal void PopulateReferences(TreeNode parent)
		{
			Assembly assembly = GetType().Assembly;

			AssemblyName[] references = assembly.GetReferencedAssemblies();
			int length = references.Length;

			string[] keys = new string[length];
			for(int i = 0; i < length; i++)
			{
				keys[i] = references[i].Name;
			}

			Array.Sort(keys, references);

			AssemblyName name;
			TreeNode node;

			for(int i = 0; i < length; i++)
			{
				name = references[i];
				node = parent.Nodes.Add(name.Name);
				node.ImageIndex = 4;
				node.SelectedImageIndex = 4;
			}
		}

		internal void PopulateDirectory(TreeNode parent, DirectoryInfo dirInfo)
		{
			DirectoryInfo[] infos = dirInfo.GetDirectories();

			int length = infos.Length;
			DirectoryInfo info;
			TreeNode node;
			string name;

			for(int i = 0; i < length; i++)
			{
				info = infos[i];
				if(!NIDELoadUC.IsDirectoryBrowsable(info))
					continue;

				name = info.Name;

				node = parent.Nodes.Add(info.Name);
				node.ImageIndex = 0;
				node.SelectedImageIndex = 0;

				PopulateDirectory(node, info);
			}

			FileInfo[] fileInfos = dirInfo.GetFiles();
			FileInfo fi;
			length = fileInfos.Length;

			for(int i = 0; i < length; i++)
			{
				fi = fileInfos[i];
				if(!NIDELoadUC.IsFileBrowsable(fi))
					continue;

				name = fi.Name;
				node = parent.Nodes.Add(fi.Name);
				node.Tag = fi;

				name = name.Replace(fi.Extension, "");

				if(fi.Extension == ".cs")
				{
					if(name.EndsWith("UC"))
					{
						node.ImageIndex = 6;
						node.SelectedImageIndex = 6;
					}
					else
					{
						node.ImageIndex = 8;
						node.SelectedImageIndex = 8;
					}
					continue;
				}

				if(fi.Extension.EndsWith("ico"))
				{
					node.ImageIndex = 9;
					node.SelectedImageIndex = 9;
				}

				if(fi.Extension.EndsWith("bmp"))
				{
					node.ImageIndex = 10;
					node.SelectedImageIndex = 10;
				}
			}
		}


		#endregion

		#region Command Bars Initialization

		internal void LoadCommandBars()
		{
			InitCommandBarsManager();

			//ranges
			InitRanges();

			//contexts
			InitStandardContexts();
			InitMenuContexts();

			//command bars
			InitMainMenu();
			InitStandardCommandBar();
		}
		internal void InitCommandBarsManager()
		{
			m_CommandBarsManager = new NCommandBarsManager(this);
			m_CommandBarsManager.Contexts.UniqueIDOnly = false;
			m_CommandBarsManager.Palette.Copy(NUIManager.Palette);
		}

		internal void SetFadeImageAndImageShadow(ArrayList commands, bool fade, bool shadow)
		{
			Nevron.UI.WinForm.Controls.NCommand comm;
			int count = commands.Count;

			for(int i = 0; i < count; i++)
			{
				comm = (Nevron.UI.WinForm.Controls.NCommand)commands[i];
				comm.Properties.FadeImage = fade;
				comm.Properties.ImageShadow = shadow;
			}
		}
		internal void SetFadeImageAndImageShadow(NCommandContext parent, bool fade, bool shadow)
		{
			NCommandContext context;
			int count = parent.Contexts.Count;

			for(int i = 0; i < count; i++)
			{
				context = parent.Contexts[i];
				context.Properties.FadeImage = fade;
				context.Properties.ImageShadow = shadow;

				SetFadeImageAndImageShadow(context, fade, shadow);
			}
		}


		#region Command Ranges

		internal void InitRanges()
		{
			NRange r = new NRange();
			r.Name = "Standard";
			r.ID = (int)NIDELoadUC.RangeID.Standard;
			m_CommandBarsManager.Ranges.Add(r);

			r = new NRange();
			r.Name = "Menu Bar";
			r.ID = (int)NIDELoadUC.RangeID.MenuBar;
			m_CommandBarsManager.Ranges.Add(r);
		}


		#endregion

		#region Command Contexts

		internal void InitStandardContexts()
		{
			NCommandContext context1, context2;

			//new project context
			context1 = NCommandContext.CreateContext("New Project...", -1, NIDELoadUC.StandardImageList, 0, (int)NIDELoadUC.RangeID.Standard, null, false);
			m_CommandBarsManager.Contexts.Add(context1);

			context2 = NCommandContext.CreateContext("New Project...", (int)NIDELoadUC.CommandID.NewProject, NIDELoadUC.StandardImageList, 0, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.N, Keys.Control | Keys.Shift), false);
			context1.Contexts.Add(context2);
			m_CommandBarsManager.Contexts.Add(context2);

			context2 = NCommandContext.CreateContext("New Blank Solution...", (int)NIDELoadUC.CommandID.NewBlankSolution, NIDELoadUC.StandardImageList, 1, (int)NIDELoadUC.RangeID.Standard, null, false);
			context1.Contexts.Add(context2);
			m_CommandBarsManager.Contexts.Add(context2);

			//add new item context
			context1 = NCommandContext.CreateContext("Add Ne&w Item...", -1, NIDELoadUC.StandardImageList, 2, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.A, Keys.Control | Keys.Shift), false);
			m_CommandBarsManager.Contexts.Add(context1);

			context2 = NCommandContext.CreateContext("Add Ne&w Item...", (int)NIDELoadUC.CommandID.AddNewItem, NIDELoadUC.StandardImageList, 2, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.A, Keys.Control | Keys.Shift), false);
			context1.Contexts.Add(context2);
			m_CommandBarsManager.Contexts.Add(context2);

			context2 = NCommandContext.CreateContext("Add Existin&g Item...", (int)NIDELoadUC.CommandID.AddExistingItem, NIDELoadUC.StandardImageList, 3, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.A, Keys.Alt | Keys.Shift), false);
			context1.Contexts.Add(context2);
			m_CommandBarsManager.Contexts.Add(context2);

			context2 = NCommandContext.CreateContext("Add Windows &Form", (int)NIDELoadUC.CommandID.AddWindowsForm, NIDELoadUC.StandardImageList, 4, (int)NIDELoadUC.RangeID.Standard, null, true);
			context1.Contexts.Add(context2);
			m_CommandBarsManager.Contexts.Add(context2);

			context2 = NCommandContext.CreateContext("Add &Inherited Form", (int)NIDELoadUC.CommandID.AddInheritedForm, NIDELoadUC.StandardImageList, 4, (int)NIDELoadUC.RangeID.Standard, null, false);
			context1.Contexts.Add(context2);
			m_CommandBarsManager.Contexts.Add(context2);

			context2 = NCommandContext.CreateContext("Add &User Control", (int)NIDELoadUC.CommandID.AddUsercontrol, NIDELoadUC.StandardImageList, 5, (int)NIDELoadUC.RangeID.Standard, null, false);
			context1.Contexts.Add(context2);
			m_CommandBarsManager.Contexts.Add(context2);

			context2 = NCommandContext.CreateContext("Add Inherited Con&trol", (int)NIDELoadUC.CommandID.AddInheritedControl, NIDELoadUC.StandardImageList, 5, (int)NIDELoadUC.RangeID.Standard, null, false);
			context1.Contexts.Add(context2);
			m_CommandBarsManager.Contexts.Add(context2);

			context2 = NCommandContext.CreateContext("Add Compo&nent", (int)NIDELoadUC.CommandID.AddComponent, NIDELoadUC.StandardImageList, 6, (int)NIDELoadUC.RangeID.Standard, null, false);
			context1.Contexts.Add(context2);
			m_CommandBarsManager.Contexts.Add(context2);

			context2 = NCommandContext.CreateContext("Add &Class...", (int)NIDELoadUC.CommandID.AddClass, NIDELoadUC.StandardImageList, 7, (int)NIDELoadUC.RangeID.Standard, null, false);
			context1.Contexts.Add(context2);
			m_CommandBarsManager.Contexts.Add(context2);

			//open context
			context1 = NCommandContext.CreateContext("&Open...", (int)NIDELoadUC.CommandID.Open, NIDELoadUC.StandardImageList, 8, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.O, Keys.Control), true);
			m_CommandBarsManager.Contexts.Add(context1);

			//save context
			context1 = NCommandContext.CreateContext("Sa&ve", (int)NIDELoadUC.CommandID.Save, NIDELoadUC.StandardImageList, 9, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.S, Keys.Control), false);
			m_CommandBarsManager.Contexts.Add(context1);

			//save all context
			context1 = NCommandContext.CreateContext("Save A&ll", (int)NIDELoadUC.CommandID.SaveAll, NIDELoadUC.StandardImageList, 10, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.S, Keys.Control | Keys.Shift), false);
			m_CommandBarsManager.Contexts.Add(context1);

			//cut context
			context1 = NCommandContext.CreateContext("Cu&t", (int)NIDELoadUC.CommandID.Cut, NIDELoadUC.StandardImageList, 11, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.X, Keys.Control), true);
			m_CommandBarsManager.Contexts.Add(context1);

			//copy context
			context1 = NCommandContext.CreateContext("&Copy", (int)NIDELoadUC.CommandID.Copy, NIDELoadUC.StandardImageList, 12, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.C, Keys.Control), false);
			m_CommandBarsManager.Contexts.Add(context1);

			//paste context
			context1 = NCommandContext.CreateContext("&Paste", (int)NIDELoadUC.CommandID.Paste, NIDELoadUC.StandardImageList, 13, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.V, Keys.Control), false);
			m_CommandBarsManager.Contexts.Add(context1);

			//undo context
			context1 = new NUndoRedoCommandContext();
			context1.Properties.ImageIndex = 14;
			context1.Properties.ID = (int)NIDELoadUC.CommandID.Undo;
			context1.Properties.Text = "&Undo";
			context1.Properties.ImageList = NIDELoadUC.StandardImageList;
			context1.Properties.Shortcut = new NShortcut(Keys.Z, Keys.Control);
			context1.Properties.BeginGroup = true;
			context1.RangeID = (int)NIDELoadUC.RangeID.Standard;
			m_CommandBarsManager.Contexts.Add(context1);

			//redo context
			context1 = new NUndoRedoCommandContext();
			context1.Properties.ImageIndex = 15;
			context1.Properties.Text = "&Redo";
			context1.Properties.ID = (int)NIDELoadUC.CommandID.Redo;
			context1.Properties.ImageList = NIDELoadUC.StandardImageList;
			context1.Properties.Shortcut = new NShortcut(Keys.Y, Keys.Control);
			context1.RangeID = (int)NIDELoadUC.RangeID.Standard;
			m_CommandBarsManager.Contexts.Add(context1);

			//navigate backward context
			context1 = NCommandContext.CreateContext("N&avigate Backward", (int)NIDELoadUC.CommandID.NavigateBackward, NIDELoadUC.StandardImageList, 16, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.OemMinus, Keys.Control), false);
			m_CommandBarsManager.Contexts.Add(context1);

			//navigate forward context
			context1 = NCommandContext.CreateContext("Navigate &Forward", (int)NIDELoadUC.CommandID.NavigateForward, NIDELoadUC.StandardImageList, 17, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.OemMinus, Keys.Control | Keys.Shift), false);
			m_CommandBarsManager.Contexts.Add(context1);

			//start debug context
			context1 = NCommandContext.CreateContext("Start / Continue", (int)NIDELoadUC.CommandID.StartContinue, NIDELoadUC.StandardImageList, 18, (int)NIDELoadUC.RangeID.Standard, null, true);
			m_CommandBarsManager.Contexts.Add(context1);

			//solution configuration context
			NComboBoxCommandContext context3 = new NComboBoxCommandContext();
			context3.Properties.ID = (int)NIDELoadUC.CommandID.SolutionConfigurations;
			context3.ListProperties.ColumnOnLeft = false;
			context3.ListProperties.ItemHeight = 15;
			context3.ComboBox.DropDownWidth = 160;
			context3.Properties.Text = "Solution Configurations";
			context3.RangeID = (int)NIDELoadUC.RangeID.Standard;

			context3.Items.Add("Debug");
			context3.Items.Add("Release");
			context3.Items.Add("Configuration Manager...");
			context3.ComboBox.SelectedIndex = 0;
			m_CommandBarsManager.Contexts.Add(context3);

			//solution explorer context
			context1 = NCommandContext.CreateContext("Solution &Explorer", (int)NIDELoadUC.CommandID.SolutionExplorer, NIDELoadUC.StandardImageList, 19, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.L, Keys.Control | Keys.Alt), true);
			m_CommandBarsManager.Contexts.Add(context1);

			//properties window context
			context1 = NCommandContext.CreateContext("Properties &Window", (int)NIDELoadUC.CommandID.Properties, NIDELoadUC.StandardImageList, 20, (int)NIDELoadUC.RangeID.Standard, null, false);
			m_CommandBarsManager.Contexts.Add(context1);

			//object browser context
			context1 = NCommandContext.CreateContext("Ob&ject Browser", (int)NIDELoadUC.CommandID.ObjectBrowser, NIDELoadUC.StandardImageList, 21, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.J, Keys.Control | Keys.Alt), false);
			m_CommandBarsManager.Contexts.Add(context1);

			//toolbox context
			context1 = NCommandContext.CreateContext("Toolbo&x", (int)NIDELoadUC.CommandID.Toolbox, NIDELoadUC.StandardImageList, 22, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.X, Keys.Control | Keys.Alt), false);
			m_CommandBarsManager.Contexts.Add(context1);

			//class view context
			context1 = NCommandContext.CreateContext("Cl&ass View", -1, NIDELoadUC.StandardImageList, 23, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.C, Keys.Control | Keys.Shift), false);
			m_CommandBarsManager.Contexts.Add(context1);

			context2 = NCommandContext.CreateContext("Cl&ass View", (int)NIDELoadUC.CommandID.ClassView, NIDELoadUC.StandardImageList, 23, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.C, Keys.Control | Keys.Shift), false);
			context1.Contexts.Add(context2);
			m_CommandBarsManager.Contexts.Add(context2);

			context2 = NCommandContext.CreateContext("Ser&ver Explorer", (int)NIDELoadUC.CommandID.ServerExplorer, NIDELoadUC.StandardImageList, 24, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.S, Keys.Control | Keys.Alt), false);
			context1.Contexts.Add(context2);
			m_CommandBarsManager.Contexts.Add(context2);

			context2 = NCommandContext.CreateContext("&Resource View", (int)NIDELoadUC.CommandID.ResourceView, NIDELoadUC.StandardImageList, 25, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.E, Keys.Control | Keys.Shift), false);
			context1.Contexts.Add(context2);
			m_CommandBarsManager.Contexts.Add(context2);

			context2 = NCommandContext.CreateContext("&Task List", (int)NIDELoadUC.CommandID.TaskList, NIDELoadUC.StandardImageList, 26, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.K, Keys.Control | Keys.Alt), false);
			context1.Contexts.Add(context2);
			m_CommandBarsManager.Contexts.Add(context2);

			context2 = NCommandContext.CreateContext("Comma&nd Window", (int)NIDELoadUC.CommandID.CommandWindow, NIDELoadUC.StandardImageList, 27, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.A, Keys.Control | Keys.Alt), false);
			context1.Contexts.Add(context2);
			m_CommandBarsManager.Contexts.Add(context2);

			context2 = NCommandContext.CreateContext("&Output", (int)NIDELoadUC.CommandID.Output, NIDELoadUC.StandardImageList, 28, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.O, Keys.Control | Keys.Alt), false);
			context1.Contexts.Add(context2);
			m_CommandBarsManager.Contexts.Add(context2);

			context2 = NCommandContext.CreateContext("Find S&ymbol Results", (int)NIDELoadUC.CommandID.FindSymbolResults, NIDELoadUC.StandardImageList, 29, (int)NIDELoadUC.RangeID.Standard, new NShortcut(Keys.F12, Keys.Control | Keys.Alt), false);
			context1.Contexts.Add(context2);
			m_CommandBarsManager.Contexts.Add(context2);
		}

		internal void InitMenuContexts()
		{
			NCommandContext context1, context2, context3;

			//file 
			context1 = NCommandContext.CreateContext("&File", -1, null, -1, (int)NIDELoadUC.RangeID.MenuBar, null, false);
			m_CommandBarsManager.Contexts.Add(context1);

			context2 = NCommandContext.CreateContext("&New", -1, null, -1, (int)NIDELoadUC.RangeID.MenuBar, null, false);
			context2.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.NewProject));
			context2.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.NewBlankSolution));

			context1.Contexts.Add(context2);
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.AddNewItem));
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.AddExistingItem));

			context3 = m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.Open);
			context1.Contexts.Add((NCommandContext)context3.Clone());
			context3 = m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.Save);
			context1.Contexts.Add((NCommandContext)context3.Clone());
			context3 = m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.SaveAll);
			context1.Contexts.Add((NCommandContext)context3.Clone());

			//file->exit context
			context2 = NCommandContext.CreateContext("E&xit", (int)NIDELoadUC.CommandID.Exit, null, -1, (int)NIDELoadUC.RangeID.MenuBar, null, true);
			m_CommandBarsManager.Contexts.Add(context2);
			context1.Contexts.Add(context2);

			//edit context
			context1 = NCommandContext.CreateContext("&Edit", -1, null, -1, (int)NIDELoadUC.RangeID.MenuBar, null, false);
			m_CommandBarsManager.Contexts.Add(context1);

			context3 = m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.Undo);
			context1.Contexts.Add((NCommandContext)context3.Clone());
			context3 = m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.Redo);
			context1.Contexts.Add((NCommandContext)context3.Clone());

			context3 = m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.Cut);
			context1.Contexts.Add((NCommandContext)context3.Clone());
			context3 = m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.Copy);
			context1.Contexts.Add((NCommandContext)context3.Clone());
			context3 = m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.Paste);
			context1.Contexts.Add((NCommandContext)context3.Clone());

			//edit->selectall context
			context2 = NCommandContext.CreateContext("Select &All", (int)NIDELoadUC.CommandID.SelectAll, null, -1, (int)NIDELoadUC.RangeID.MenuBar, null, true);
			m_CommandBarsManager.Contexts.Add(context2);
			context1.Contexts.Add(context2);

			//view context
			context1 = NCommandContext.CreateContext("&View", -1, null, -1, (int)NIDELoadUC.RangeID.MenuBar, null, false);
			m_CommandBarsManager.Contexts.Add(context1);

			context3 = m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.SolutionExplorer);
			context1.Contexts.Add((NCommandContext)context3.Clone());
			context3 = m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.Properties);
			context1.Contexts.Add((NCommandContext)context3.Clone());
			context3 = m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.ObjectBrowser);
			context1.Contexts.Add((NCommandContext)context3.Clone());
			context3 = m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.Toolbox);
			context1.Contexts.Add((NCommandContext)context3.Clone());
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.ClassView));
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.ServerExplorer));
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.ResourceView));
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.TaskList));
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.CommandWindow));
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.Output));
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.FindSymbolResults));

			//project context
			context1 = NCommandContext.CreateContext("&Project", -1, null, -1, (int)NIDELoadUC.RangeID.MenuBar, null, false);
			m_CommandBarsManager.Contexts.Add(context1);

			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.AddNewItem));
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.AddExistingItem));
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.AddWindowsForm));
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.AddInheritedForm));
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.AddUsercontrol));
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.AddInheritedControl));
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.AddComponent));
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID((int)NIDELoadUC.CommandID.AddClass));
		}


		#endregion

		#region Command Bars

		internal void InitMainMenu()
		{
			NMenuBar menu = new NMenuBar();
			menu.Text = "Menu Bar";
			menu.AllowRename = false;
			menu.AllowHide = false;
			menu.DefaultRangeID = (int)NIDELoadUC.RangeID.MenuBar;

			m_CommandBarsManager.Toolbars.Add(menu);
			menu.Reset(false);
		}

		internal void InitStandardCommandBar()
		{
			NDockingToolbar tb = new NDockingToolbar(m_CommandBarsManager);
			tb.DefaultRangeID = (int)NIDELoadUC.RangeID.Standard;
			tb.Text = "Standard";

			m_CommandBarsManager.Toolbars.Add(tb);
			tb.Reset(false);
		}


		#endregion

		#endregion

		#region Docking Panels Initialization

		internal void LoadDockingFramework()
		{
			InitDockManager();
			LoadPanels();
		}
		internal void InitDockManager()
		{
			m_DockManager = new NDockManager();
			m_DockManager.Palette.Copy(NUIManager.Palette);
			m_DockManager.DocumentStyle.ImageList = NIDELoadUC.SolutionExplorerImageList;
			m_DockManager.Form = this;
			m_DockManager.ImageList = NIDELoadUC.StandardImageList;
			m_DockManager.Palette.PaletteChanged += new PaletteChangeEventHandler(Palette_PaletteChanged);
		}
		internal void LoadPanels()
		{
			NDockingPanel panel;

			INDockZone target;
			INDockZone root = m_DockManager.RootContainer.RootZone;
			INDockZone docHost = m_DockManager.DocumentManager.DocumentViewHost;

			panel = new NDockingPanel();
			panel.Text = "Solution Explorer";
			panel.Controls.Add(m_SolutionExplorer);
			panel.TabInfo.ImageIndex = 19;
			panel.PerformDock(root, DockStyle.Left);

			//output window
			panel = new NDockingPanel();
			panel.Text = "Output";
			//panel.Controls.Add(GetOutputWindow());
			panel.TabInfo.ImageIndex = 28;
			panel.PerformDock(docHost, DockStyle.Bottom);
			target = panel.ParentZone;

			//task list
			panel = new NDockingPanel();
			panel.Text = "Task List";
			panel.Controls.Add(GetTaskList());
			panel.TabInfo.ImageIndex = 26;
			panel.PerformDock(target, DockStyle.Fill);

			//toolbox
			panel = new NDockingPanel();
			panel.Text = "Toolbox";
			panel.Controls.Add(GetToolbox());
			panel.TabInfo.ImageIndex = 22;
			panel.PerformDock(root, DockStyle.Right);
			target = panel.ParentZone;

			panel = new NDockingPanel();
			panel.Text = "Properties";
			panel.Controls.Add(GetProperties());
			panel.TabInfo.ImageIndex = 20;
			panel.PerformDock(target, DockStyle.Fill);
		}


		internal NPanelBar GetToolbox()
		{
			NPanelBar bar = new NPanelBar();
			bar.Border.Style = BorderStyle3D.None;
			bar.Dock = DockStyle.Fill;

			NBand band;

			band = new NBand();
			band.Caption = "Data";
			bar.Bands.Add(band);

			band = new NBand();
			band.Caption = "Components";
			bar.Bands.Add(band);

			band = new NBand();
			band.Caption = "Windows Forms";
			bar.Bands.Add(band);

			return bar;
		}

		internal PropertyGrid GetProperties()
		{
			PropertyGrid grid = new PropertyGrid();
			grid.Dock = DockStyle.Fill;
			grid.ToolbarVisible = false;
			grid.SelectedObject = m_DockManager;

			return grid;
		}
		internal RichTextBox GetOutputWindow()
		{
			NRichTextBox tb = new NRichTextBox();
			tb.Dock = DockStyle.Fill;
			tb.Multiline = true;
			tb.WordWrap = false;
			tb.ScrollBars = RichTextBoxScrollBars.Both;

			return tb;
		}
		internal ListView GetTaskList()
		{
			ListView lv = new ListView();
			lv.View = View.Details;
			lv.GridLines = true;
			lv.FullRowSelect = true;
			lv.Dock = DockStyle.Fill;

			lv.Columns.Add("!", 20, HorizontalAlignment.Center);
			lv.Columns.Add("", 20, HorizontalAlignment.Center);
			lv.Columns.Add("", 20, HorizontalAlignment.Center);
			lv.Columns.Add("Description", 100, HorizontalAlignment.Left);

			return lv;
		}


		#endregion

		#region Event Handlers

		private void m_SolutionExplorer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			int imageIndex = e.Node.ImageIndex;
			int newIndex = -1;

			switch(imageIndex)
			{
				case 0:
					newIndex = 1;
					break;
				case 2:
					newIndex = 3;
					break;
			}

			if(newIndex == -1)
				return;

			e.Node.ImageIndex = newIndex;
			e.Node.SelectedImageIndex = newIndex;
		}
		private void m_SolutionExplorer_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
		{
			int imageIndex = e.Node.ImageIndex;
			int newIndex = -1;

			switch(imageIndex)
			{
				case 1:
					newIndex = 0;
					break;
				case 3:
					newIndex = 2;
					break;
			}

			if(newIndex == -1)
				return;

			e.Node.ImageIndex = newIndex;
			e.Node.SelectedImageIndex = newIndex;
		}

		private void m_SolutionExplorer_DoubleClick(object sender, EventArgs e)
		{
			TreeNode selected = m_SolutionExplorer.SelectedNode;
			if(selected == null)
				return;

			Point pt = m_SolutionExplorer.PointToClient(Control.MousePosition);
			if(!selected.Bounds.Contains(pt))
				return;

			FileInfo fi = selected.Tag as FileInfo;
			if(fi == null || fi.Extension.ToLower() != ".cs")
				return;

			AddDocument(fi, selected);
		}


		private void Palette_PaletteChanged(NPalette Palette, PaletteChangeEventArgs e)
		{
			m_CommandBarsManager.BeginUpdate();

			bool fade = Palette.Scheme == ColorScheme.Standard;
			SetFadeImageAndImageShadow(m_CommandBarsManager.CommandManager.GetAllCommands(false), fade, fade);

			NUIManager.ApplyPalette(this, Palette);
			m_CommandBarsManager.Palette.Copy(Palette);

			m_CommandBarsManager.EndUpdate(true);
		}


		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_SolutionExplorer = new Nevron.UI.WinForm.Controls.NTreeView();
			this.nStatusBar1 = new Nevron.UI.WinForm.Controls.NStatusBar();
			this.nStatusBarPanel1 = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
			this.nStatusBarPanel2 = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
			this.nStatusBarPanel3 = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
			this.nStatusBarPanel4 = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
			((System.ComponentModel.ISupportInitialize)(this.nStatusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nStatusBarPanel2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nStatusBarPanel3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nStatusBarPanel4)).BeginInit();
			this.SuspendLayout();
			// 
			// m_SolutionExplorer
			// 
			this.m_SolutionExplorer.Border.Style = Nevron.UI.BorderStyle3D.None;
			this.m_SolutionExplorer.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_SolutionExplorer.ImageIndex = -1;
			this.m_SolutionExplorer.Location = new System.Drawing.Point(8, 176);
			this.m_SolutionExplorer.Name = "m_SolutionExplorer";
			this.m_SolutionExplorer.SelectedImageIndex = -1;
			this.m_SolutionExplorer.Size = new System.Drawing.Size(200, 192);
			this.m_SolutionExplorer.TabIndex = 1;
			// 
			// nStatusBar1
			// 
			this.nStatusBar1.Location = new System.Drawing.Point(0, 507);
			this.nStatusBar1.Name = "nStatusBar1";
			this.nStatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						   this.nStatusBarPanel1,
																						   this.nStatusBarPanel2,
																						   this.nStatusBarPanel3,
																						   this.nStatusBarPanel4});
			this.nStatusBar1.Separators = true;
			this.nStatusBar1.ShowPanels = true;
			this.nStatusBar1.Size = new System.Drawing.Size(810, 20);
			this.nStatusBar1.TabIndex = 2;
			this.nStatusBar1.Text = "nStatusBar1";
			// 
			// nStatusBarPanel1
			// 
			this.nStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.nStatusBarPanel1.Text = "Ready";
			this.nStatusBarPanel1.Width = 688;
			// 
			// nStatusBarPanel2
			// 
			this.nStatusBarPanel2.Text = "INS";
			this.nStatusBarPanel2.Width = 30;
			// 
			// nStatusBarPanel3
			// 
			this.nStatusBarPanel3.Text = "CAPS";
			this.nStatusBarPanel3.Width = 39;
			// 
			// nStatusBarPanel4
			// 
			this.nStatusBarPanel4.Text = "NUM";
			this.nStatusBarPanel4.Width = 37;
			// 
			// NVisualStudioIDE
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(810, 527);
			this.Controls.Add(this.nStatusBar1);
			this.Controls.Add(this.m_SolutionExplorer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Name = "NVisualStudioIDE";
			this.Text = "Nevron User Interface - Sample Visual Studio IDE";
			((System.ComponentModel.ISupportInitialize)(this.nStatusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nStatusBarPanel2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nStatusBarPanel3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nStatusBarPanel4)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		internal NCommandBarsManager m_CommandBarsManager;
		internal NDockManager m_DockManager;
		internal NIDELoadUC m_Loader;

		private NTreeView m_SolutionExplorer;
		private Nevron.UI.WinForm.Controls.NStatusBar nStatusBar1;
		private Nevron.UI.WinForm.Controls.NStatusBarPanel nStatusBarPanel1;
		private Nevron.UI.WinForm.Controls.NStatusBarPanel nStatusBarPanel2;
		private Nevron.UI.WinForm.Controls.NStatusBarPanel nStatusBarPanel3;
		private Nevron.UI.WinForm.Controls.NStatusBarPanel nStatusBarPanel4;

		#endregion
	}
}
