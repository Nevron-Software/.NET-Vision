using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.Globalization;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	#region Contexts IDS

	internal enum Contexts
	{
		NewFile = 0,
		Open = 4,
		Save,
		Cut,
		Copy,
		Paste,
		Delete,
		Undo,
		Redo,
		Print,
		PrintPreview,

		BackgroundImage1,
		CustomRegion,
		LoadImage,


		FlipHorizontal,
		FlipVertical,
		RotateLeft,
		RotateRight,
		BringToFront,
		SendToBack,
		BringForward,
		SendBackward,
		Group,
		Ungroup,
		NudgeLeft,
		NudgeRight,
		NudgeTop,
		NudgeBottom,

		AlignToGrid,
		SizeToGrid,
		AlignLefts,
		AlignCenters,
		AlignRights,
		AlignTops,
		AlignMiddles,
		AlignBottoms,
		MakeSameWidth,
		MakeSameHeight,
		MakeSameSize,
		MakeHorizontalSpacingEqual,
		IncreaseHorizontalSpacing,
		DecreaseHorizontalSpacing,
		RemoveHorizontalSpacing,
		MakeVerticalSpacingEqual,
		IncreaseVerticalSpacing,
		DecreaseVerticalSpacing,
		RemoveVerticalSpacing,
		CenterHorizontally,
		CenterVertically,
		TreeLayout,
		SymmetricalLayout,
		TableLayout,

		Pointer,
		Rectangle,
		Ellipse,
		Line,
		Arc,
		Polyline,
		Polygon,
		Curve,
		ClosedCurve,
		Bezier,
		BridgeablePolyline,
		BridgeableHVPolyline,
		SingleArrow,
		DoubleArrow,
		Text,
		Pan,

		ShowGrid,
		GridStyle,
		GridStyleMajorLines,
		GridStyleMajorDots,
		GridStyleMajorMinorLines,
		GridStyleInterlaced,
		GridStyleInterlacedHorizontally,
		GridStyleInterlacedVertically,
		ViewStyle,
		ViewStyleNormal,
		ViewStyleFit,
		ViewStyleStretch,
		ViewStyleStretchToWidth,
		ViewStyleStretchToHeight,
		ShowRulers,
		ShowGuidelines,
		ShowConnectionPoints,
		ZoomIn,
		ZoomOut,
		SnapToGrid,
		SnapToRulers,
		SnapToGuidelines,
		SnapRotation,

		FormContext1,
		FormContext2,
		FormContext3,
		FormContext4,
		FormContext5,
		FormContext6,
		FormContext7,
		FormContext8,
		FormContext9,
		FormContext10,
		FormContext11,
		FormContext12,
		FormContext13,
		FormContext14,
		FormContext15,
		FormContext16,
		FormContext17,
		FormContext18,
		FormContext19,
		FormContext20,

		ComboBoxContext1,
		ComboBoxContext2,
		ComboBoxContext3,

		FillStyle,
		StrokeStyle,
		ShadowStyle,
		TextStyle,
		StartArrowHeadStyle,
		EndArrowHeadStyle,
		BridgeStyle,
		Bold,
		Italic,
		Underline,
		TextAlignLeft,
		TextAlignCenter,
		TextAlignRight,
		Reroute,
		Reverse,
		DocumentBackground,
		DocumentLayers
	}

	#endregion

	public class NDockingToolbarsUC : NExampleUserControl
	{
		#region Constructor

		public NDockingToolbarsUC(MainForm f) : base(f)
		{
			InitializeComponent();

			InitManager();
			InitRanges();
			InitContexts();
			InitToolbars();

			Dock = DockStyle.Fill;

			m_State = new NCommandBarsState(m_Manager);
			m_State.PersistencyFlags = NCommandBarsStateFlags.All;

			this.nTabControl1.ShowFocusRect = false;
		}


		#endregion

		#region Implementation

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				m_Manager.Dispose();
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		
		internal void InitManager()
		{
			m_Manager = new NCommandBarsManager(this);
			m_Manager.Palette.Copy(NUIManager.Palette);
			//register these imagelists as global for the manager
			m_Manager.ImageLists.Add(MainForm.ActionImages);
			m_Manager.ImageLists.Add(MainForm.LayoutImages);
			m_Manager.ImageLists.Add(MainForm.StandardImages);
			m_Manager.ImageLists.Add(MainForm.TestImages);
			m_Manager.ImageLists.Add(MainForm.ToolsImages);
			m_Manager.ImageLists.Add(MainForm.ViewImages);
			m_Manager.ImageLists.Add(MainForm.FormatImages);
			m_Manager.ImageLists.Add(MainForm.MiscImages);

			m_Manager.CommandContextExecuted += new CommandContextEventHandler(OnCommandContextExecuted);
		}


		#region Ranges

		internal void InitRanges()
		{
			NRange r = new NRange();
			r.Name = "Standard";
			r.ID = 0;
			m_Manager.Ranges.Add(r);

			r = new NRange();
			r.Name = "Action";
			r.ID = 1;
			m_Manager.Ranges.Add(r);

			r = new NRange();
			r.Name = "Layout";
			r.ID = 2;
			m_Manager.Ranges.Add(r);

			r = new NRange();
			r.Name = "Tools";
			r.ID = 3;
			m_Manager.Ranges.Add(r);

			r = new NRange();
			r.Name = "View";
			r.ID = 4;
			m_Manager.Ranges.Add(r);

			r = new NRange();
			r.Name = "Test";
			r.EditorBrowsable = false;
			r.ID = 5;
			m_Manager.Ranges.Add(r);

			r = new NRange();
			r.Name = "ComboBoxes";
			r.ID = 6;
			m_Manager.Ranges.Add(r);

			r = new NRange();
			r.Name = "Format";
			r.ID = 7;
			m_Manager.Ranges.Add(r);
		}


		#endregion

		#region Contexts

		internal void InitContexts()
		{
			InitStandardContexts();
			InitActionContexts();
			InitLayoutContexts();
			InitToolsContexts();
			InitViewContexts();
			InitMixedContexts();
			InitComboBoxContexts();
			InitFormatContexts();
		}
		internal void InitStandardContexts()
		{
			CreateNewContext();
			CreateContext("&Open...", (int)Contexts.Open, MainForm.StandardImages, 1, 0, new NShortcut(Keys.O, Keys.Control), false);
			CreateContext("&Save", (int)Contexts.Save, MainForm.StandardImages, 2, 0, new NShortcut(Keys.S, Keys.Control), false);

			CreateContext("Cu&t", (int)Contexts.Cut, MainForm.StandardImages, 3, 0, new NShortcut(Keys.X, Keys.Control), true);
			CreateContext("&Copy", (int)Contexts.Copy, MainForm.StandardImages, 4, 0, new NShortcut(Keys.C, Keys.Control), false);
			CreateContext("&Paste", (int)Contexts.Paste, MainForm.StandardImages, 5, 0, new NShortcut(Keys.V, Keys.Control), false);
			CreateContext("&Delete", (int)Contexts.Delete, MainForm.StandardImages, 6, 0, new NShortcut(Keys.Delete, Keys.Control), false);

			//create the undo/redo contexts
			NUndoRedoCommandContext c = new NUndoRedoCommandContext();
			c.Properties.ImageIndex = 7;
			c.Properties.ID = (int)Contexts.Undo;
			c.Properties.Text = "&Undo";
			c.LabelText = "Undo";
			c.Properties.ImageList = MainForm.StandardImages;
			c.Properties.Shortcut = new NShortcut(Keys.Z, Keys.Control);
			c.Properties.BeginGroup = true;
			c.RangeID = 0;
			c.Properties.ID = (int)Contexts.Undo;
			m_Manager.Contexts.Add(c);

			c = new NUndoRedoCommandContext();
			c.Properties.ImageIndex = 8;
			c.Properties.Text = "&Redo";
			c.LabelText = "Redo";
			c.Properties.ID = (int)Contexts.Redo;
			c.Properties.ImageList = MainForm.StandardImages;
			c.Properties.Shortcut = new NShortcut(Keys.Y, Keys.Control);
			c.RangeID = 0;
			c.Properties.ID = (int)Contexts.Redo;
			m_Manager.Contexts.Add(c);

			NCommandContext c1 = CreateContext("P&rint", (int)Contexts.Print, MainForm.StandardImages, 9, 0, new NShortcut(Keys.P, Keys.Control), true);
			//c1.Properties.Visible = false;
			CreateContext("Print Pre&view", (int)Contexts.PrintPreview, MainForm.StandardImages, 10, 0, new NShortcut(Keys.P, Keys.Control | Keys.Shift), false);
			
		}
		internal void InitActionContexts()
		{
			CreateContext("Flip &Horizontal", (int)Contexts.FlipHorizontal, MainForm.ActionImages, 0, 1, null, false);
			CreateContext("Flip &Vertical", (int)Contexts.FlipVertical, MainForm.ActionImages, 1, 1, null, false);

			CreateContext("Rotate &Left", (int)Contexts.RotateLeft, MainForm.ActionImages, 2, 1, null, true);
			CreateContext("Rotate &Right", (int)Contexts.RotateRight, MainForm.ActionImages, 3, 1, null, false);

			CreateContext("Bring To &Front", (int)Contexts.BringToFront, MainForm.ActionImages, 4, 1, null, true);
			CreateContext("Send To &Back", (int)Contexts.SendToBack, MainForm.ActionImages, 5, 1, null, false);
			CreateContext("Bring For&ward", (int)Contexts.BringForward, MainForm.ActionImages, 6, 1, null, false);
			CreateContext("Send Bac&kward", (int)Contexts.SendBackward, MainForm.ActionImages, 7, 1, null, false);

			CreateContext("&Group", (int)Contexts.Group, MainForm.ActionImages, 8, 1, null, true);
			CreateContext("&Ungroup", (int)Contexts.Ungroup, MainForm.ActionImages, 9, 1, null, false);

			CreateContext("Nudge Left", (int)Contexts.NudgeLeft, MainForm.ActionImages, 10, 1, null, true);
			CreateContext("Nudge Right", (int)Contexts.NudgeRight, MainForm.ActionImages, 11, 1, null, false);
			CreateContext("Nudge Top", (int)Contexts.NudgeTop, MainForm.ActionImages, 12, 1, null, false);
			CreateContext("Nudge Bottom", (int)Contexts.NudgeBottom, MainForm.ActionImages, 13, 1, null, false);
		}
		internal void InitLayoutContexts()
		{
			CreateContext("Align To Grid", (int)Contexts.AlignToGrid, MainForm.LayoutImages, 0, 2, null, false);
			CreateContext("Size To Grid", (int)Contexts.SizeToGrid, MainForm.LayoutImages, 1, 2, null, false);

			CreateContext("Align Lefts", (int)Contexts.AlignLefts, MainForm.LayoutImages, 2, 2, null, true);
			CreateContext("Align Centers", (int)Contexts.AlignCenters, MainForm.LayoutImages, 3, 2, null, false);
			CreateContext("Align Rights", (int)Contexts.AlignRights, MainForm.LayoutImages, 4, 2, null, false);

			CreateContext("Align Tops", (int)Contexts.AlignTops, MainForm.LayoutImages, 5, 2, null, true);
			CreateContext("Align Middles", (int)Contexts.AlignMiddles, MainForm.LayoutImages, 6, 2, null, false);
			CreateContext("Align Bottoms", (int)Contexts.AlignBottoms, MainForm.LayoutImages, 7, 2, null, false);

			CreateContext("Make Same Width", (int)Contexts.MakeSameWidth, MainForm.LayoutImages, 8, 2, null, true);
			CreateContext("Make Same Height", (int)Contexts.MakeSameHeight, MainForm.LayoutImages, 9, 2, null, false);
			CreateContext("Make Same Size", (int)Contexts.MakeSameSize, MainForm.LayoutImages, 10, 2, null, false);

			CreateContext("Make Horizontal Spacing Equal", (int)Contexts.MakeHorizontalSpacingEqual, MainForm.LayoutImages, 11, 2, null, true);
			CreateContext("Increase Horizontal Spacing", (int)Contexts.IncreaseHorizontalSpacing, MainForm.LayoutImages, 12, 2, null, false);
			CreateContext("Decrease Horizontal Spacing", (int)Contexts.DecreaseHorizontalSpacing, MainForm.LayoutImages, 13, 2, null, false);
			CreateContext("Remove Horizontal Spacing", (int)Contexts.RemoveHorizontalSpacing, MainForm.LayoutImages, 14, 2, null, false);

			CreateContext("Make Vertical Spacing Equal", (int)Contexts.MakeVerticalSpacingEqual, MainForm.LayoutImages, 15, 2, null, true);
			CreateContext("Increase Vertical Spacing", (int)Contexts.IncreaseVerticalSpacing, MainForm.LayoutImages, 16, 2, null, false);
			CreateContext("Decrease Vertical Spacing", (int)Contexts.DecreaseVerticalSpacing, MainForm.LayoutImages, 17, 2, null, false);
			CreateContext("Remove Vertical Spacing", (int)Contexts.RemoveVerticalSpacing, MainForm.LayoutImages, 18, 2, null, false);

			CreateContext("Center Horizontally", (int)Contexts.CenterHorizontally, MainForm.LayoutImages, 19, 2, null, true);
			CreateContext("Center Vertically", (int)Contexts.CenterVertically, MainForm.LayoutImages, 20, 2, null, false);

			CreateContext("Tree Layout", (int)Contexts.TreeLayout, MainForm.LayoutImages, 21, 2, null, true);
			CreateContext("Symmetrical Layout", (int)Contexts.SymmetricalLayout, MainForm.LayoutImages, 22, 2, null, false);
			CreateContext("Table Layout", (int)Contexts.TableLayout, MainForm.LayoutImages, 23, 2, null, false);
		}
		internal void InitToolsContexts()
		{
			CreateContext("Pointer", (int)Contexts.Pointer, MainForm.ToolsImages, 0, 3, null, false);
			CreateContext("Rectangle", (int)Contexts.Rectangle, MainForm.ToolsImages, 1, 3, null, false);
			CreateContext("Ellipse", (int)Contexts.Ellipse, MainForm.ToolsImages, 2, 3, null, false);
			CreateContext("Line", (int)Contexts.Line, MainForm.ToolsImages, 3, 3, null, false);
			CreateContext("Arc", (int)Contexts.Arc, MainForm.ToolsImages, 4, 3, null, false);
			CreateContext("Polyline", (int)Contexts.Polyline, MainForm.ToolsImages, 5, 3, null, false);
			CreateContext("Polygon", (int)Contexts.Polygon, MainForm.ToolsImages, 6, 3, null, false);
			CreateContext("Curve", (int)Contexts.Curve, MainForm.ToolsImages, 7, 3, null, false);
			CreateContext("Closed Curve", (int)Contexts.ClosedCurve, MainForm.ToolsImages, 8, 3, null, false);
			CreateContext("Text", (int)Contexts.Text, MainForm.ToolsImages, 14, 3, null, false);
			CreateContext("Pan", (int)Contexts.Pan, MainForm.ToolsImages, 15, 3, null, false);
		}
		internal void InitViewContexts()
		{
			CreateContext("Show Grid", (int)Contexts.ShowGrid, MainForm.ViewImages, 0, 4, null, false);
			CreateContext("Show Rulers", (int)Contexts.ShowRulers, MainForm.ViewImages, 1, 4, null, false);
			CreateContext("Show Guidelines", (int)Contexts.ShowGuidelines, MainForm.ViewImages, 2, 4, null, false);
			CreateContext("Show Connection Points", (int)Contexts.ShowConnectionPoints, MainForm.ViewImages, 3, 4, null, false);

			CreateGridStyleContext();
			CreateViewStyleContext();

			CreateContext("Zoom In", (int)Contexts.ZoomIn, MainForm.ViewImages, 18, 4, null, true);
			CreateContext("Zoom Out", (int)Contexts.ZoomOut, MainForm.ViewImages, 19, 4, null, false);

			CreateContext("Snap To Grid", (int)Contexts.SnapToGrid, MainForm.ViewImages, 20, 4, null, true);
			CreateContext("Snap To Rulers", (int)Contexts.SnapToRulers, MainForm.ViewImages, 21, 4, null, false);
			CreateContext("Snap To Guidelines", (int)Contexts.SnapToGuidelines, MainForm.ViewImages, 22, 4, null, false);
			CreateContext("Snap Rotation", (int)Contexts.SnapRotation, MainForm.ViewImages, 23, 4, null, false);
		}
		internal void InitMixedContexts()
		{
			NCommandContext c;
			c = CreateContext("Non-designable", (int)Contexts.FormContext1, MainForm.TestImages, 0, 5, null, false);
			c.Properties.Designable = false;
			c.Properties.Style = CommandStyle.ImageAndText;

			CreateContext("NCommand 1", (int)Contexts.FormContext2, MainForm.TestImages, 1, 5, null, true);
			CreateContext("NCommand 2", (int)Contexts.FormContext3, MainForm.TestImages, 2, 5, null, false);
			CreateContext("NCommand 3", (int)Contexts.FormContext4, MainForm.TestImages, 3, 5, null, false);
			CreateContext("NCommand 4", (int)Contexts.FormContext5, MainForm.TestImages, 4, 5, null, false);

			c = CreateContext("Non-selectable", (int)Contexts.FormContext6, MainForm.TestImages, 5, 5, null, true);
			c.Properties.Selectable = false;
			c.Properties.Style = CommandStyle.ImageAndText;

			CreateContext("NCommand 5", (int)Contexts.FormContext7, MainForm.TestImages, 6, 5, null, true);
			CreateContext("NCommand 6", (int)Contexts.FormContext8, MainForm.TestImages, 7, 5, null, false);
			CreateContext("NCommand 7", (int)Contexts.FormContext9, MainForm.TestImages, 8, 5, null, false);
			CreateContext("NCommand 8", (int)Contexts.FormContext10, MainForm.TestImages, 9, 5, null, false);

			CreateContext("NCommand 9", (int)Contexts.FormContext11, MainForm.TestImages, 10, 5, null, false);
			CreateContext("NCommand 10", (int)Contexts.FormContext12, MainForm.TestImages, 11, 5, null, false);
			CreateContext("NCommand 11", (int)Contexts.FormContext13, MainForm.TestImages, 12, 5, null, false);
			CreateContext("NCommand 12", (int)Contexts.FormContext14, MainForm.TestImages, 13, 5, null, false);
			CreateContext("NCommand 13", (int)Contexts.FormContext15, MainForm.TestImages, 14, 5, null, false);
			CreateContext("NCommand 14", (int)Contexts.FormContext16, MainForm.TestImages, 15, 5, null, false);
			CreateContext("NCommand 15", (int)Contexts.FormContext17, MainForm.TestImages, 16, 5, null, false);
			CreateContext("NCommand 16", (int)Contexts.FormContext18, MainForm.TestImages, 17, 5, null, false);
			CreateContext("NCommand 17", (int)Contexts.FormContext19, MainForm.TestImages, 18, 5, null, false);
			CreateContext("NCommand 18", (int)Contexts.FormContext20, MainForm.TestImages, 19, 5, null, false);
		}
		internal void InitComboBoxContexts()
		{
			NComboBoxCommandContext c = new NComboBoxCommandContext();
			c.Properties.ImageList = MainForm.TestImages;
			c.Properties.Text = "ComboBox";
			c.Properties.ID = (int)Contexts.ComboBoxContext1;
			c.RangeID = 6;
			c.PrefferedWidth = 150;
			NListBoxItem item;
			for(int i = 0; i < 20; i++)
			{
				item = new NListBoxItem(i, "NListBoxItem "+i, false);
				c.Items.Add(item);
			}

			m_Manager.Contexts.Add(c);

			c = new NComboBoxCommandContext();
			c.Properties.Text = "Editable ComboBox";
			c.Properties.ImageList = MainForm.TestImages;
			c.Editable = true;
			c.Properties.ID = (int)Contexts.ComboBoxContext2;
			c.RangeID = 6;
			c.PrefferedWidth = 150;
			for(int i = 0; i < 20; i++)
			{
				item = new NListBoxItem(i, "NListBoxItem "+i, false);
				c.Items.Add(item);
			}

			m_Manager.Contexts.Add(c);

			c = new NFontComboBoxCommandContext();
			c.Properties.Text = "Font Combo";
			c.Properties.ID = (int)Contexts.ComboBoxContext3;
			c.RangeID = 6;
			c.PrefferedWidth = 200;

			m_Manager.Contexts.Add(c);
		}

		internal void InitFormatContexts()
		{
			CreateContext("Fill Style", (int)Contexts.FillStyle, MainForm.FormatImages, 0, 7, null, false);
			CreateContext("Stroke Style", (int)Contexts.StrokeStyle, MainForm.FormatImages, 1, 7, null, false);
			CreateContext("Shadow Style", (int)Contexts.ShadowStyle, MainForm.FormatImages, 2, 7, null, false);
			CreateContext("Text Style", (int)Contexts.TextStyle, MainForm.FormatImages, 3, 7, null, false);

			CreateContext("Start Arrow Head Style", (int)Contexts.StartArrowHeadStyle, MainForm.FormatImages, 4, 7, null, true);
			CreateContext("End Arrow Head Style", (int)Contexts.EndArrowHeadStyle, MainForm.FormatImages, 5, 7, null, false);
			CreateContext("Bridge Style", (int)Contexts.BridgeStyle, MainForm.FormatImages, 6, 7, null, false);

			CreateContext("Bold", (int)Contexts.Bold, MainForm.FormatImages, 7, 7, null, true);
			CreateContext("Italic", (int)Contexts.Italic, MainForm.FormatImages, 8, 7, null, false);
			CreateContext("Underline", (int)Contexts.Underline, MainForm.FormatImages, 9, 7, null, false);
			CreateContext("Text Align Left", (int)Contexts.TextAlignLeft, MainForm.FormatImages, 10, 7, null, false);
			CreateContext("Text Align Center", (int)Contexts.TextAlignCenter, MainForm.FormatImages, 11, 7, null, false);
			CreateContext("Text Align Right", (int)Contexts.TextAlignRight, MainForm.FormatImages, 12, 7, null, false);

			CreateContext("Reroute", (int)Contexts.Reroute, MainForm.MiscImages, 0, 7, null, true);
			CreateContext("Reverse", (int)Contexts.Reverse, MainForm.MiscImages, 1, 7, null, false);
			CreateContext("Layers", (int)Contexts.DocumentLayers, MainForm.MiscImages, 2, 7, null, false);
		}

		internal NCommandContext CreateContext(string text, int id, ImageList images, int imageIndex, int rangeID, NShortcut sc, bool beginGroup)
		{
			NCommandContext c = new NCommandContext();
			c.RangeID = rangeID;
			c.Properties.ID = id;
			c.Properties.ImageList = images;
			c.Properties.ImageIndex = imageIndex;
			c.Properties.BeginGroup = beginGroup;

			c.Properties.Text = text;
			if(sc != null)
				c.Properties.Shortcut = sc;

			m_Manager.Contexts.Add(c);

			return c;
		}


		internal void CreateNewContext()
		{
			NCommandContext c, c1;

			int context = (int)Contexts.NewFile;

			c = new NCommandContext();
			c.RangeID = 0;
			c.Properties.ID = context;
			c.Properties.ImageList = MainForm.StandardImages;
			c.Properties.Text = "New";
			c.Properties.MenuOptions.DisplayTooltips = true;
			c.Properties.ImageIndex = 0;
			m_Manager.Contexts.Add(c);

			c1 = new NCommandContext();
			c1.Properties.Text = "New Document";
			c1.Properties.TooltipText = "Creates a new document.<br/>";
			c1.Properties.ID = (int)context + 1;
			c1.Properties.Shortcut = new NShortcut(Keys.N, Keys.Control | Keys.Shift);
			c1.RangeID = 0;
			c1.Properties.ImageIndex = 0;
			c.Contexts.Add(c1);
			m_Manager.Contexts.Add(c1);

			c1 = new NCommandContext();
			c1.Properties.Text = "New Diagram";
			c1.Properties.ID = context + 2;
			c1.Properties.Shortcut = new NShortcut(Keys.D, Keys.Control | Keys.Shift);
			c1.RangeID = 0;
			c1.Properties.ImageIndex = 0;
			c.Contexts.Add(c1);
			m_Manager.Contexts.Add(c1);

			c1 = new NCommandContext();
			c1.Properties.Text = "New Flow Chart";
			c1.Properties.ID = context + 3;
			c1.Properties.Shortcut = new NShortcut(Keys.F, Keys.Control | Keys.Shift);
			c1.RangeID = 0;
			c1.Properties.ImageIndex = 0;
			c.Contexts.Add(c1);
			m_Manager.Contexts.Add(c1);
		}
		internal void CreateGridStyleContext()
		{
			NCommandContext c, c1;

			c = new NCommandContext();
			c.RangeID = 4;
			c.Properties.BeginGroup = true;
			c.Properties.ID = (int)Contexts.GridStyle;
			c.Properties.ImageList = MainForm.ViewImages;
			c.Properties.Text = "Grid Style";
			c.Properties.ImageIndex = 6;
			m_Manager.Contexts.Add(c);

			c1 = new NCommandContext();
			c1.Properties.Text = "Major Lines";
			c1.Properties.ID = (int)Contexts.GridStyleMajorLines;
			c1.RangeID = 4;
			c1.Properties.ImageIndex = 6;
			c.Contexts.Add(c1);
			m_Manager.Contexts.Add(c1);

			c1 = new NCommandContext();
			c1.Properties.Text = "Major Dots";
			c1.Properties.ID = (int)Contexts.GridStyleMajorDots;
			c1.RangeID = 4;
			c1.Properties.ImageIndex = 7;
			c.Contexts.Add(c1);
			m_Manager.Contexts.Add(c1);

			c1 = new NCommandContext();
			c1.Properties.Text = "Major Minor Lines";
			c1.Properties.ID = (int)Contexts.GridStyleMajorMinorLines;
			c1.RangeID = 4;
			c1.Properties.ImageIndex = 8;
			c.Contexts.Add(c1);
			m_Manager.Contexts.Add(c1);

			c1 = new NCommandContext();
			c1.Properties.Text = "Interlaced";
			c1.Properties.ID = (int)Contexts.GridStyleInterlaced;
			c1.RangeID = 4;
			c1.Properties.ImageIndex = 9;
			c.Contexts.Add(c1);
			m_Manager.Contexts.Add(c1);

			c1 = new NCommandContext();
			c1.Properties.Text = "Interlaced Horizontally";
			c1.Properties.ID = (int)Contexts.GridStyleInterlacedHorizontally;
			c1.RangeID = 4;
			c1.Properties.ImageIndex = 10;
			c.Contexts.Add(c1);
			m_Manager.Contexts.Add(c1);

			c1 = new NCommandContext();
			c1.Properties.Text = "Interlaced Vertically";
			c1.Properties.ID = (int)Contexts.GridStyleInterlacedVertically;
			c1.RangeID = 4;
			c1.Properties.ImageIndex = 11;
			c.Contexts.Add(c1);
			m_Manager.Contexts.Add(c1);
		}

		internal void CreateViewStyleContext()
		{
			NCommandContext c, c1;

			c = new NCommandContext();
			c.RangeID = 4;
			c.Properties.ID = (int)Contexts.ViewStyle;
			c.Properties.ImageList = MainForm.ViewImages;
			c.Properties.Text = "View Style";
			c.Properties.ImageIndex = 12;
			m_Manager.Contexts.Add(c);

			c1 = new NCommandContext();
			c1.Properties.Text = "Fit";
			c1.Properties.ID = (int)Contexts.ViewStyleFit;
			c1.RangeID = 4;
			c1.Properties.ImageIndex = 13;
			c.Contexts.Add(c1);
			m_Manager.Contexts.Add(c1);

			c1 = new NCommandContext();
			c1.Properties.Text = "Stretch";
			c1.Properties.ID = (int)Contexts.ViewStyleStretch;
			c1.RangeID = 4;
			c1.Properties.ImageIndex = 14;
			c.Contexts.Add(c1);
			m_Manager.Contexts.Add(c1);

			c1 = new NCommandContext();
			c1.Properties.Text = "Stretch To Width";
			c1.Properties.ID = (int)Contexts.ViewStyleStretchToWidth;
			c1.RangeID = 4;
			c1.Properties.ImageIndex = 15;
			c.Contexts.Add(c1);
			m_Manager.Contexts.Add(c1);

			c1 = new NCommandContext();
			c1.Properties.Text = "Stretch To Height";
			c1.Properties.ID = (int)Contexts.ViewStyleStretchToHeight;
			c1.RangeID = 4;
			c1.Properties.ImageIndex = 16;
			c.Contexts.Add(c1);
			m_Manager.Contexts.Add(c1);
		}


		#endregion

		#region Toolbars

		internal void InitToolbars()
		{
			InitStandandardToolbar();
			InitActionToolbar();
			InitLayoutToolbar();
			InitToolsToolbar();
			InitViewToolbar();
			InitTestToolbar();
			InitComboBoxesToolbar();
			InitFormatToolbar();
		}

		internal void InitStandandardToolbar()
		{
			NDockingToolbar tb = new NDockingToolbar();
			tb.DefaultRangeID = 0;
			tb.Text = "Standard";
			//tb.Dock = DockStyle.Left;

			m_Manager.Toolbars.Add(tb);
			tb.Reset(false);
		}
		internal void InitActionToolbar()
		{
			NDockingToolbar tb = new NDockingToolbar();
			tb.DefaultRangeID = 1;
			//tb.Dock = DockStyle.Left;
			tb.Text = "Action";
			tb.RowIndex = 0;

			m_Manager.Toolbars.Add(tb);
			tb.Reset(false);
		}
		internal void InitLayoutToolbar()
		{
			NDockingToolbar tb = new NDockingToolbar();
			tb.DefaultRangeID = 2;
			//tb.Dock = DockStyle.Bottom;
			tb.Text = "Layout";
			tb.RowIndex = 0;

			m_Manager.Toolbars.Add(tb);
			tb.Reset(false);
		}

		internal void InitToolsToolbar()
		{
			NDockingToolbar tb = new NDockingToolbar();
			tb.DefaultRangeID = 3;
			//tb.Dock = DockStyle.Right;
			tb.Text = "Tools";

			m_Manager.Toolbars.Add(tb);
			tb.Reset(false);
		}

		internal void InitViewToolbar()
		{
			NDockingToolbar tb = new NDockingToolbar();
			tb.DefaultRangeID = 4;
			tb.Text = "View";

			m_Manager.Toolbars.Add(tb);
			tb.Reset(false);
		}

		internal void InitTestToolbar()
		{
			NDockingToolbar tb = new NDockingToolbar();
			tb.DefaultRangeID = 5;
			tb.Text = "Test";

			tb.AllowRename = false;
			tb.AllowDelete = false;
			//tb.AllowHide = false;

			m_Manager.Toolbars.Add(tb);
			tb.Reset(false);
		}

		internal void InitComboBoxesToolbar()
		{
			NDockingToolbar tb = new NDockingToolbar();
			tb.DefaultRangeID = 6;
			tb.Text = "ComboBoxes";

			m_Manager.Toolbars.Add(tb);
			tb.Reset(false);
		}

		internal void InitFormatToolbar()
		{
			NDockingToolbar tb = new NDockingToolbar();
			tb.DefaultRangeID = 7;
			tb.Text = "Format";

			m_Manager.Toolbars.Add(tb);
			tb.Reset(false);
		}


		#endregion

		#endregion

		#region Event Handlers

		private void OnCommandContextExecuted(object sender, CommandContextEventArgs e)
		{
			switch(e.Context.Properties.ID)
			{
				case (int)Contexts.Open:
					m_State.Load();
					break;
				case (int)Contexts.Save:
					m_State.Save();
					break;
                case (int)Contexts.FillStyle:
                    NComboBoxCommandContext c = (NComboBoxCommandContext)m_Manager.CommandManager.GetContext((int)Contexts.ComboBoxContext2);
                    NComboBoxCommand comm = (NComboBoxCommand)c.GetCommands()[0];

                    comm.HostedControl.SuspendLayout();
                    comm.Items.Clear();

                    //NListBoxItem item;
                    for (int i = 0; i < 200; i++)
                    {
                        //item = new NListBoxItem(i, "NListBoxItem " + i, false);
                        comm.Items.Add("Item " + i);
                    }

                    comm.HostedControl.ResumeLayout();

                    break;
			}
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nTabControl1 = new Nevron.UI.WinForm.Controls.NTabControl();
			this.nTabPage1 = new Nevron.UI.WinForm.Controls.NTabPage();
			this.nRichTextBox1 = new Nevron.UI.WinForm.Controls.NRichTextBox();
			this.nTabPage2 = new Nevron.UI.WinForm.Controls.NTabPage();
			this.nTabPage3 = new Nevron.UI.WinForm.Controls.NTabPage();
			this.nTabPage4 = new Nevron.UI.WinForm.Controls.NTabPage();
			this.nTabControl1.SuspendLayout();
			this.nTabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// nTabControl1
			// 
			this.nTabControl1.Controls.Add(this.nTabPage1);
			this.nTabControl1.Controls.Add(this.nTabPage2);
			this.nTabControl1.Controls.Add(this.nTabPage3);
			this.nTabControl1.Controls.Add(this.nTabPage4);
			this.nTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nTabControl1.Location = new System.Drawing.Point(0, 0);
			this.nTabControl1.Name = "nTabControl1";
			this.nTabControl1.Selectable = true;
			this.nTabControl1.SelectedIndex = 0;
			this.nTabControl1.Size = new System.Drawing.Size(368, 256);
			this.nTabControl1.TabIndex = 0;
			// 
			// nTabPage1
			// 
			this.nTabPage1.Controls.Add(this.nRichTextBox1);
			this.nTabPage1.Name = "nTabPage1";
			this.nTabPage1.TabIndex = 1;
			this.nTabPage1.Text = "NTabPage";
			// 
			// nRichTextBox1
			// 
			this.nRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nRichTextBox1.Location = new System.Drawing.Point(0, 0);
			this.nRichTextBox1.Name = "nRichTextBox1";
			this.nRichTextBox1.Size = new System.Drawing.Size(358, 221);
			this.nRichTextBox1.TabIndex = 0;
			this.nRichTextBox1.Text = "nRichTextBox1";
			// 
			// nTabPage2
			// 
			this.nTabPage2.Name = "nTabPage2";
			this.nTabPage2.TabIndex = 2;
			this.nTabPage2.Text = "NTabPage";
			// 
			// nTabPage3
			// 
			this.nTabPage3.Name = "nTabPage3";
			this.nTabPage3.TabIndex = 3;
			this.nTabPage3.Text = "NTabPage";
			// 
			// nTabPage4
			// 
			this.nTabPage4.Name = "nTabPage4";
			this.nTabPage4.TabIndex = 4;
			this.nTabPage4.Text = "NTabPage";
			// 
			// NDockingToolbarsUC
			// 
			this.Controls.Add(this.nTabControl1);
			this.Name = "NDockingToolbarsUC";
			this.Size = new System.Drawing.Size(368, 256);
			this.nTabControl1.ResumeLayout(false);
			this.nTabPage1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NTabControl nTabControl1;
		private Nevron.UI.WinForm.Controls.NTabPage nTabPage1;
		private Nevron.UI.WinForm.Controls.NTabPage nTabPage2;
		private Nevron.UI.WinForm.Controls.NRichTextBox nRichTextBox1;
		private Nevron.UI.WinForm.Controls.NTabPage nTabPage3;
		private Nevron.UI.WinForm.Controls.NTabPage nTabPage4;

		internal NCommandBarsManager m_Manager;
		internal NCommandBarsState m_State;

		#endregion
	}

	public class NUndoRedoCommandContext : NListBoxCommandContext
	{
		#region Constructor

		public NUndoRedoCommandContext()
		{
		}


		#endregion

		#region Overrides

		protected override void PopulateList(NListBox list)
		{
			Random rand = new Random();
			int end = rand.Next(21, 101);
			for(int i = 1; i < end; i++)
			{
				list.Items.Add("Undo/Redo Action "+i);
			}
		}

		protected override void HandleListSelectedIndexChanged(NListBox list)
		{
			int count = list.SelectedItems.Count;
			string actions = " Actions";
			if (count == 1)
			{
				actions = " Action";
			}
			
			Description = LabelText + " " + count + actions;
		}

		protected override void OnSelectionCommited(int selectionCount)
		{			
			MessageBox.Show("Undo/Redo "+selectionCount+" actions");
		}
		
		#endregion

		#region Properties

		public string LabelText
		{
			get
			{
				return m_LabelText;
			}
			set
			{
				m_LabelText = value;
				Description = value;
			}
		}

		#endregion

		#region Fields

		string m_LabelText;

		#endregion
	}
}
