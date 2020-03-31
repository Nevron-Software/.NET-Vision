Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.Globalization
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	#Region "Contexts IDS"

	Friend Enum Contexts
		NewFile = 0
		Open = 4
		Save
		Cut
		Copy
		Paste
		Delete
		Undo
		Redo
		Print
		PrintPreview

		BackgroundImage1
		CustomRegion
		LoadImage


		FlipHorizontal
		FlipVertical
		RotateLeft
		RotateRight
		BringToFront
		SendToBack
		BringForward
		SendBackward
		Group
		Ungroup
		NudgeLeft
		NudgeRight
		NudgeTop
		NudgeBottom

		AlignToGrid
		SizeToGrid
		AlignLefts
		AlignCenters
		AlignRights
		AlignTops
		AlignMiddles
		AlignBottoms
		MakeSameWidth
		MakeSameHeight
		MakeSameSize
		MakeHorizontalSpacingEqual
		IncreaseHorizontalSpacing
		DecreaseHorizontalSpacing
		RemoveHorizontalSpacing
		MakeVerticalSpacingEqual
		IncreaseVerticalSpacing
		DecreaseVerticalSpacing
		RemoveVerticalSpacing
		CenterHorizontally
		CenterVertically
		TreeLayout
		SymmetricalLayout
		TableLayout

		Pointer
		Rectangle
		Ellipse
		Line
		Arc
		Polyline
		Polygon
		Curve
		ClosedCurve
		Bezier
		BridgeablePolyline
		BridgeableHVPolyline
		SingleArrow
		DoubleArrow
		Text
		Pan

		ShowGrid
		GridStyle
		GridStyleMajorLines
		GridStyleMajorDots
		GridStyleMajorMinorLines
		GridStyleInterlaced
		GridStyleInterlacedHorizontally
		GridStyleInterlacedVertically
		ViewStyle
		ViewStyleNormal
		ViewStyleFit
		ViewStyleStretch
		ViewStyleStretchToWidth
		ViewStyleStretchToHeight
		ShowRulers
		ShowGuidelines
		ShowConnectionPoints
		ZoomIn
		ZoomOut
		SnapToGrid
		SnapToRulers
		SnapToGuidelines
		SnapRotation

		FormContext1
		FormContext2
		FormContext3
		FormContext4
		FormContext5
		FormContext6
		FormContext7
		FormContext8
		FormContext9
		FormContext10
		FormContext11
		FormContext12
		FormContext13
		FormContext14
		FormContext15
		FormContext16
		FormContext17
		FormContext18
		FormContext19
		FormContext20

		ComboBoxContext1
		ComboBoxContext2
		ComboBoxContext3

		FillStyle
		StrokeStyle
		ShadowStyle
		TextStyle
		StartArrowHeadStyle
		EndArrowHeadStyle
		BridgeStyle
		Bold
		Italic
		Underline
		TextAlignLeft
		TextAlignCenter
		TextAlignRight
		Reroute
		Reverse
		DocumentBackground
		DocumentLayers
	End Enum

	#End Region

	Public Class NDockingToolbarsUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			InitManager()
			InitRanges()
			InitContexts()
			InitToolbars()

			Dock = DockStyle.Fill

			m_State = New NCommandBarsState(m_Manager)
			m_State.PersistencyFlags = NCommandBarsStateFlags.All

			Me.nTabControl1.ShowFocusRect = False
		End Sub


		#End Region

		#Region "Implementation"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				m_Manager.Dispose()
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		Friend Sub InitManager()
			m_Manager = New NCommandBarsManager(Me)
			m_Manager.Palette.Copy(NUIManager.Palette)
			'register these imagelists as global for the manager
			m_Manager.ImageLists.Add(MainForm.ActionImages)
			m_Manager.ImageLists.Add(MainForm.LayoutImages)
			m_Manager.ImageLists.Add(MainForm.StandardImages)
			m_Manager.ImageLists.Add(MainForm.TestImages)
			m_Manager.ImageLists.Add(MainForm.ToolsImages)
			m_Manager.ImageLists.Add(MainForm.ViewImages)
			m_Manager.ImageLists.Add(MainForm.FormatImages)
			m_Manager.ImageLists.Add(MainForm.MiscImages)

			AddHandler m_Manager.CommandContextExecuted, AddressOf OnCommandContextExecuted
		End Sub


		#Region "Ranges"

		Friend Sub InitRanges()
			Dim r As NRange = New NRange()
			r.Name = "Standard"
			r.ID = 0
			m_Manager.Ranges.Add(r)

			r = New NRange()
			r.Name = "Action"
			r.ID = 1
			m_Manager.Ranges.Add(r)

			r = New NRange()
			r.Name = "Layout"
			r.ID = 2
			m_Manager.Ranges.Add(r)

			r = New NRange()
			r.Name = "Tools"
			r.ID = 3
			m_Manager.Ranges.Add(r)

			r = New NRange()
			r.Name = "View"
			r.ID = 4
			m_Manager.Ranges.Add(r)

			r = New NRange()
			r.Name = "Test"
			r.EditorBrowsable = False
			r.ID = 5
			m_Manager.Ranges.Add(r)

			r = New NRange()
			r.Name = "ComboBoxes"
			r.ID = 6
			m_Manager.Ranges.Add(r)

			r = New NRange()
			r.Name = "Format"
			r.ID = 7
			m_Manager.Ranges.Add(r)
		End Sub


		#End Region

		#Region "Contexts"

		Friend Sub InitContexts()
			InitStandardContexts()
			InitActionContexts()
			InitLayoutContexts()
			InitToolsContexts()
			InitViewContexts()
			InitMixedContexts()
			InitComboBoxContexts()
			InitFormatContexts()
		End Sub
		Friend Sub InitStandardContexts()
			CreateNewContext()
			CreateContext("&Open...", CInt(Fix(Contexts.Open)), MainForm.StandardImages, 1, 0, New NShortcut(Keys.O, Keys.Control), False)
			CreateContext("&Save", CInt(Fix(Contexts.Save)), MainForm.StandardImages, 2, 0, New NShortcut(Keys.S, Keys.Control), False)

			CreateContext("Cu&t", CInt(Fix(Contexts.Cut)), MainForm.StandardImages, 3, 0, New NShortcut(Keys.X, Keys.Control), True)
			CreateContext("&Copy", CInt(Fix(Contexts.Copy)), MainForm.StandardImages, 4, 0, New NShortcut(Keys.C, Keys.Control), False)
			CreateContext("&Paste", CInt(Fix(Contexts.Paste)), MainForm.StandardImages, 5, 0, New NShortcut(Keys.V, Keys.Control), False)
			CreateContext("&Delete", CInt(Fix(Contexts.Delete)), MainForm.StandardImages, 6, 0, New NShortcut(Keys.Delete, Keys.Control), False)

			'create the undo/redo contexts
			Dim c As NUndoRedoCommandContext = New NUndoRedoCommandContext()
			c.Properties.ImageIndex = 7
			c.Properties.ID = CInt(Fix(Contexts.Undo))
			c.Properties.Text = "&Undo"
			c.Properties.ImageList = MainForm.StandardImages
			c.Properties.Shortcut = New NShortcut(Keys.Z, Keys.Control)
			c.Properties.BeginGroup = True
			c.RangeID = 0
			c.Properties.ID = CInt(Fix(Contexts.Undo))
			m_Manager.Contexts.Add(c)

			c = New NUndoRedoCommandContext()
			c.Properties.ImageIndex = 8
			c.Properties.Text = "&Redo"
			c.Properties.ID = CInt(Fix(Contexts.Redo))
			c.Properties.ImageList = MainForm.StandardImages
			c.Properties.Shortcut = New NShortcut(Keys.Y, Keys.Control)
			c.RangeID = 0
			c.Properties.ID = CInt(Fix(Contexts.Redo))
			m_Manager.Contexts.Add(c)

			Dim c1 As NCommandContext = CreateContext("P&rint", CInt(Fix(Contexts.Print)), MainForm.StandardImages, 9, 0, New NShortcut(Keys.P, Keys.Control), True)
			'c1.Properties.Visible = false;
			CreateContext("Print Pre&view", CInt(Fix(Contexts.PrintPreview)), MainForm.StandardImages, 10, 0, New NShortcut(Keys.P, Keys.Control Or Keys.Shift), False)

		End Sub
		Friend Sub InitActionContexts()
			CreateContext("Flip &Horizontal", CInt(Fix(Contexts.FlipHorizontal)), MainForm.ActionImages, 0, 1, Nothing, False)
			CreateContext("Flip &Vertical", CInt(Fix(Contexts.FlipVertical)), MainForm.ActionImages, 1, 1, Nothing, False)

			CreateContext("Rotate &Left", CInt(Fix(Contexts.RotateLeft)), MainForm.ActionImages, 2, 1, Nothing, True)
			CreateContext("Rotate &Right", CInt(Fix(Contexts.RotateRight)), MainForm.ActionImages, 3, 1, Nothing, False)

			CreateContext("Bring To &Front", CInt(Fix(Contexts.BringToFront)), MainForm.ActionImages, 4, 1, Nothing, True)
			CreateContext("Send To &Back", CInt(Fix(Contexts.SendToBack)), MainForm.ActionImages, 5, 1, Nothing, False)
			CreateContext("Bring For&ward", CInt(Fix(Contexts.BringForward)), MainForm.ActionImages, 6, 1, Nothing, False)
			CreateContext("Send Bac&kward", CInt(Fix(Contexts.SendBackward)), MainForm.ActionImages, 7, 1, Nothing, False)

			CreateContext("&Group", CInt(Fix(Contexts.Group)), MainForm.ActionImages, 8, 1, Nothing, True)
			CreateContext("&Ungroup", CInt(Fix(Contexts.Ungroup)), MainForm.ActionImages, 9, 1, Nothing, False)

			CreateContext("Nudge Left", CInt(Fix(Contexts.NudgeLeft)), MainForm.ActionImages, 10, 1, Nothing, True)
			CreateContext("Nudge Right", CInt(Fix(Contexts.NudgeRight)), MainForm.ActionImages, 11, 1, Nothing, False)
			CreateContext("Nudge Top", CInt(Fix(Contexts.NudgeTop)), MainForm.ActionImages, 12, 1, Nothing, False)
			CreateContext("Nudge Bottom", CInt(Fix(Contexts.NudgeBottom)), MainForm.ActionImages, 13, 1, Nothing, False)
		End Sub
		Friend Sub InitLayoutContexts()
			CreateContext("Align To Grid", CInt(Fix(Contexts.AlignToGrid)), MainForm.LayoutImages, 0, 2, Nothing, False)
			CreateContext("Size To Grid", CInt(Fix(Contexts.SizeToGrid)), MainForm.LayoutImages, 1, 2, Nothing, False)

			CreateContext("Align Lefts", CInt(Fix(Contexts.AlignLefts)), MainForm.LayoutImages, 2, 2, Nothing, True)
			CreateContext("Align Centers", CInt(Fix(Contexts.AlignCenters)), MainForm.LayoutImages, 3, 2, Nothing, False)
			CreateContext("Align Rights", CInt(Fix(Contexts.AlignRights)), MainForm.LayoutImages, 4, 2, Nothing, False)

			CreateContext("Align Tops", CInt(Fix(Contexts.AlignTops)), MainForm.LayoutImages, 5, 2, Nothing, True)
			CreateContext("Align Middles", CInt(Fix(Contexts.AlignMiddles)), MainForm.LayoutImages, 6, 2, Nothing, False)
			CreateContext("Align Bottoms", CInt(Fix(Contexts.AlignBottoms)), MainForm.LayoutImages, 7, 2, Nothing, False)

			CreateContext("Make Same Width", CInt(Fix(Contexts.MakeSameWidth)), MainForm.LayoutImages, 8, 2, Nothing, True)
			CreateContext("Make Same Height", CInt(Fix(Contexts.MakeSameHeight)), MainForm.LayoutImages, 9, 2, Nothing, False)
			CreateContext("Make Same Size", CInt(Fix(Contexts.MakeSameSize)), MainForm.LayoutImages, 10, 2, Nothing, False)

			CreateContext("Make Horizontal Spacing Equal", CInt(Fix(Contexts.MakeHorizontalSpacingEqual)), MainForm.LayoutImages, 11, 2, Nothing, True)
			CreateContext("Increase Horizontal Spacing", CInt(Fix(Contexts.IncreaseHorizontalSpacing)), MainForm.LayoutImages, 12, 2, Nothing, False)
			CreateContext("Decrease Horizontal Spacing", CInt(Fix(Contexts.DecreaseHorizontalSpacing)), MainForm.LayoutImages, 13, 2, Nothing, False)
			CreateContext("Remove Horizontal Spacing", CInt(Fix(Contexts.RemoveHorizontalSpacing)), MainForm.LayoutImages, 14, 2, Nothing, False)

			CreateContext("Make Vertical Spacing Equal", CInt(Fix(Contexts.MakeVerticalSpacingEqual)), MainForm.LayoutImages, 15, 2, Nothing, True)
			CreateContext("Increase Vertical Spacing", CInt(Fix(Contexts.IncreaseVerticalSpacing)), MainForm.LayoutImages, 16, 2, Nothing, False)
			CreateContext("Decrease Vertical Spacing", CInt(Fix(Contexts.DecreaseVerticalSpacing)), MainForm.LayoutImages, 17, 2, Nothing, False)
			CreateContext("Remove Vertical Spacing", CInt(Fix(Contexts.RemoveVerticalSpacing)), MainForm.LayoutImages, 18, 2, Nothing, False)

			CreateContext("Center Horizontally", CInt(Fix(Contexts.CenterHorizontally)), MainForm.LayoutImages, 19, 2, Nothing, True)
			CreateContext("Center Vertically", CInt(Fix(Contexts.CenterVertically)), MainForm.LayoutImages, 20, 2, Nothing, False)

			CreateContext("Tree Layout", CInt(Fix(Contexts.TreeLayout)), MainForm.LayoutImages, 21, 2, Nothing, True)
			CreateContext("Symmetrical Layout", CInt(Fix(Contexts.SymmetricalLayout)), MainForm.LayoutImages, 22, 2, Nothing, False)
			CreateContext("Table Layout", CInt(Fix(Contexts.TableLayout)), MainForm.LayoutImages, 23, 2, Nothing, False)
		End Sub
		Friend Sub InitToolsContexts()
			CreateContext("Pointer", CInt(Fix(Contexts.Pointer)), MainForm.ToolsImages, 0, 3, Nothing, False)
			CreateContext("Rectangle", CInt(Fix(Contexts.Rectangle)), MainForm.ToolsImages, 1, 3, Nothing, False)
			CreateContext("Ellipse", CInt(Fix(Contexts.Ellipse)), MainForm.ToolsImages, 2, 3, Nothing, False)
			CreateContext("Line", CInt(Fix(Contexts.Line)), MainForm.ToolsImages, 3, 3, Nothing, False)
			CreateContext("Arc", CInt(Fix(Contexts.Arc)), MainForm.ToolsImages, 4, 3, Nothing, False)
			CreateContext("Polyline", CInt(Fix(Contexts.Polyline)), MainForm.ToolsImages, 5, 3, Nothing, False)
			CreateContext("Polygon", CInt(Fix(Contexts.Polygon)), MainForm.ToolsImages, 6, 3, Nothing, False)
			CreateContext("Curve", CInt(Fix(Contexts.Curve)), MainForm.ToolsImages, 7, 3, Nothing, False)
			CreateContext("Closed Curve", CInt(Fix(Contexts.ClosedCurve)), MainForm.ToolsImages, 8, 3, Nothing, False)
			CreateContext("Text", CInt(Fix(Contexts.Text)), MainForm.ToolsImages, 14, 3, Nothing, False)
			CreateContext("Pan", CInt(Fix(Contexts.Pan)), MainForm.ToolsImages, 15, 3, Nothing, False)
		End Sub
		Friend Sub InitViewContexts()
			CreateContext("Show Grid", CInt(Fix(Contexts.ShowGrid)), MainForm.ViewImages, 0, 4, Nothing, False)
			CreateContext("Show Rulers", CInt(Fix(Contexts.ShowRulers)), MainForm.ViewImages, 1, 4, Nothing, False)
			CreateContext("Show Guidelines", CInt(Fix(Contexts.ShowGuidelines)), MainForm.ViewImages, 2, 4, Nothing, False)
			CreateContext("Show Connection Points", CInt(Fix(Contexts.ShowConnectionPoints)), MainForm.ViewImages, 3, 4, Nothing, False)

			CreateGridStyleContext()
			CreateViewStyleContext()

			CreateContext("Zoom In", CInt(Fix(Contexts.ZoomIn)), MainForm.ViewImages, 18, 4, Nothing, True)
			CreateContext("Zoom Out", CInt(Fix(Contexts.ZoomOut)), MainForm.ViewImages, 19, 4, Nothing, False)

			CreateContext("Snap To Grid", CInt(Fix(Contexts.SnapToGrid)), MainForm.ViewImages, 20, 4, Nothing, True)
			CreateContext("Snap To Rulers", CInt(Fix(Contexts.SnapToRulers)), MainForm.ViewImages, 21, 4, Nothing, False)
			CreateContext("Snap To Guidelines", CInt(Fix(Contexts.SnapToGuidelines)), MainForm.ViewImages, 22, 4, Nothing, False)
			CreateContext("Snap Rotation", CInt(Fix(Contexts.SnapRotation)), MainForm.ViewImages, 23, 4, Nothing, False)
		End Sub
		Friend Sub InitMixedContexts()
			Dim c As NCommandContext
			c = CreateContext("Non-designable", CInt(Fix(Contexts.FormContext1)), MainForm.TestImages, 0, 5, Nothing, False)
			c.Properties.Designable = False
			c.Properties.Style = CommandStyle.ImageAndText

			CreateContext("NCommand 1", CInt(Fix(Contexts.FormContext2)), MainForm.TestImages, 1, 5, Nothing, True)
			CreateContext("NCommand 2", CInt(Fix(Contexts.FormContext3)), MainForm.TestImages, 2, 5, Nothing, False)
			CreateContext("NCommand 3", CInt(Fix(Contexts.FormContext4)), MainForm.TestImages, 3, 5, Nothing, False)
			CreateContext("NCommand 4", CInt(Fix(Contexts.FormContext5)), MainForm.TestImages, 4, 5, Nothing, False)

			c = CreateContext("Non-selectable", CInt(Fix(Contexts.FormContext6)), MainForm.TestImages, 5, 5, Nothing, True)
			c.Properties.Selectable = False
			c.Properties.Style = CommandStyle.ImageAndText

			CreateContext("NCommand 5", CInt(Fix(Contexts.FormContext7)), MainForm.TestImages, 6, 5, Nothing, True)
			CreateContext("NCommand 6", CInt(Fix(Contexts.FormContext8)), MainForm.TestImages, 7, 5, Nothing, False)
			CreateContext("NCommand 7", CInt(Fix(Contexts.FormContext9)), MainForm.TestImages, 8, 5, Nothing, False)
			CreateContext("NCommand 8", CInt(Fix(Contexts.FormContext10)), MainForm.TestImages, 9, 5, Nothing, False)

			CreateContext("NCommand 9", CInt(Fix(Contexts.FormContext11)), MainForm.TestImages, 10, 5, Nothing, False)
			CreateContext("NCommand 10", CInt(Fix(Contexts.FormContext12)), MainForm.TestImages, 11, 5, Nothing, False)
			CreateContext("NCommand 11", CInt(Fix(Contexts.FormContext13)), MainForm.TestImages, 12, 5, Nothing, False)
			CreateContext("NCommand 12", CInt(Fix(Contexts.FormContext14)), MainForm.TestImages, 13, 5, Nothing, False)
			CreateContext("NCommand 13", CInt(Fix(Contexts.FormContext15)), MainForm.TestImages, 14, 5, Nothing, False)
			CreateContext("NCommand 14", CInt(Fix(Contexts.FormContext16)), MainForm.TestImages, 15, 5, Nothing, False)
			CreateContext("NCommand 15", CInt(Fix(Contexts.FormContext17)), MainForm.TestImages, 16, 5, Nothing, False)
			CreateContext("NCommand 16", CInt(Fix(Contexts.FormContext18)), MainForm.TestImages, 17, 5, Nothing, False)
			CreateContext("NCommand 17", CInt(Fix(Contexts.FormContext19)), MainForm.TestImages, 18, 5, Nothing, False)
			CreateContext("NCommand 18", CInt(Fix(Contexts.FormContext20)), MainForm.TestImages, 19, 5, Nothing, False)
		End Sub
		Friend Sub InitComboBoxContexts()
			Dim c As NComboBoxCommandContext = New NComboBoxCommandContext()
			c.Properties.ImageList = MainForm.TestImages
			c.Properties.Text = "ComboBox"
			c.Properties.ID = CInt(Fix(Contexts.ComboBoxContext1))
			c.RangeID = 6
			c.PrefferedWidth = 150
			Dim item As NListBoxItem
			For i As Integer = 0 To 19
				item = New NListBoxItem(i, "NListBoxItem " & i, False)
				c.Items.Add(item)
			Next i

			m_Manager.Contexts.Add(c)

			c = New NComboBoxCommandContext()
			c.Properties.Text = "Editable ComboBox"
			c.Properties.ImageList = MainForm.TestImages
			c.Editable = True
			c.Properties.ID = CInt(Fix(Contexts.ComboBoxContext2))
			c.RangeID = 6
			c.PrefferedWidth = 150
			For i As Integer = 0 To 19
				item = New NListBoxItem(i, "NListBoxItem " & i, False)
				c.Items.Add(item)
			Next i

			m_Manager.Contexts.Add(c)

			c = New NFontComboBoxCommandContext()
			c.Properties.Text = "Font Combo"
			c.Properties.ID = CInt(Fix(Contexts.ComboBoxContext3))
			c.RangeID = 6
			c.PrefferedWidth = 200

			m_Manager.Contexts.Add(c)
		End Sub

		Friend Sub InitFormatContexts()
			CreateContext("Fill Style", CInt(Fix(Contexts.FillStyle)), MainForm.FormatImages, 0, 7, Nothing, False)
			CreateContext("Stroke Style", CInt(Fix(Contexts.StrokeStyle)), MainForm.FormatImages, 1, 7, Nothing, False)
			CreateContext("Shadow Style", CInt(Fix(Contexts.ShadowStyle)), MainForm.FormatImages, 2, 7, Nothing, False)
			CreateContext("Text Style", CInt(Fix(Contexts.TextStyle)), MainForm.FormatImages, 3, 7, Nothing, False)

			CreateContext("Start Arrow Head Style", CInt(Fix(Contexts.StartArrowHeadStyle)), MainForm.FormatImages, 4, 7, Nothing, True)
			CreateContext("End Arrow Head Style", CInt(Fix(Contexts.EndArrowHeadStyle)), MainForm.FormatImages, 5, 7, Nothing, False)
			CreateContext("Bridge Style", CInt(Fix(Contexts.BridgeStyle)), MainForm.FormatImages, 6, 7, Nothing, False)

			CreateContext("Bold", CInt(Fix(Contexts.Bold)), MainForm.FormatImages, 7, 7, Nothing, True)
			CreateContext("Italic", CInt(Fix(Contexts.Italic)), MainForm.FormatImages, 8, 7, Nothing, False)
			CreateContext("Underline", CInt(Fix(Contexts.Underline)), MainForm.FormatImages, 9, 7, Nothing, False)
			CreateContext("Text Align Left", CInt(Fix(Contexts.TextAlignLeft)), MainForm.FormatImages, 10, 7, Nothing, False)
			CreateContext("Text Align Center", CInt(Fix(Contexts.TextAlignCenter)), MainForm.FormatImages, 11, 7, Nothing, False)
			CreateContext("Text Align Right", CInt(Fix(Contexts.TextAlignRight)), MainForm.FormatImages, 12, 7, Nothing, False)

			CreateContext("Reroute", CInt(Fix(Contexts.Reroute)), MainForm.MiscImages, 0, 7, Nothing, True)
			CreateContext("Reverse", CInt(Fix(Contexts.Reverse)), MainForm.MiscImages, 1, 7, Nothing, False)
			CreateContext("Layers", CInt(Fix(Contexts.DocumentLayers)), MainForm.MiscImages, 2, 7, Nothing, False)
		End Sub

		Friend Function CreateContext(ByVal text As String, ByVal id As Integer, ByVal images As ImageList, ByVal imageIndex As Integer, ByVal rangeID As Integer, ByVal sc As NShortcut, ByVal beginGroup As Boolean) As NCommandContext
			Dim c As NCommandContext = New NCommandContext()
			c.RangeID = rangeID
			c.Properties.ID = id
			c.Properties.ImageList = images
			c.Properties.ImageIndex = imageIndex
			c.Properties.BeginGroup = beginGroup

			c.Properties.Text = text
			If Not sc Is Nothing Then
				c.Properties.Shortcut = sc
			End If

			m_Manager.Contexts.Add(c)

			Return c
		End Function


		Friend Sub CreateNewContext()
			Dim c, c1 As NCommandContext

			Dim context As Integer = CInt(Fix(Contexts.NewFile))

			c = New NCommandContext()
			c.RangeID = 0
			c.Properties.ID = context
			c.Properties.ImageList = MainForm.StandardImages
			c.Properties.Text = "New"
			c.Properties.MenuOptions.DisplayTooltips = True
			c.Properties.ImageIndex = 0
			m_Manager.Contexts.Add(c)

			c1 = New NCommandContext()
			c1.Properties.Text = "New Document"
			c1.Properties.TooltipText = "Creates a new document.<br/>"
			c1.Properties.ID = CInt(Fix(context)) + 1
			c1.Properties.Shortcut = New NShortcut(Keys.N, Keys.Control Or Keys.Shift)
			c1.RangeID = 0
			c1.Properties.ImageIndex = 0
			c.Contexts.Add(c1)
			m_Manager.Contexts.Add(c1)

			c1 = New NCommandContext()
			c1.Properties.Text = "New Diagram"
			c1.Properties.ID = context + 2
			c1.Properties.Shortcut = New NShortcut(Keys.D, Keys.Control Or Keys.Shift)
			c1.RangeID = 0
			c1.Properties.ImageIndex = 0
			c.Contexts.Add(c1)
			m_Manager.Contexts.Add(c1)

			c1 = New NCommandContext()
			c1.Properties.Text = "New Flow Chart"
			c1.Properties.ID = context + 3
			c1.Properties.Shortcut = New NShortcut(Keys.F, Keys.Control Or Keys.Shift)
			c1.RangeID = 0
			c1.Properties.ImageIndex = 0
			c.Contexts.Add(c1)
			m_Manager.Contexts.Add(c1)
		End Sub
		Friend Sub CreateGridStyleContext()
			Dim c, c1 As NCommandContext

			c = New NCommandContext()
			c.RangeID = 4
			c.Properties.BeginGroup = True
			c.Properties.ID = CInt(Fix(Contexts.GridStyle))
			c.Properties.ImageList = MainForm.ViewImages
			c.Properties.Text = "Grid Style"
			c.Properties.ImageIndex = 6
			m_Manager.Contexts.Add(c)

			c1 = New NCommandContext()
			c1.Properties.Text = "Major Lines"
			c1.Properties.ID = CInt(Fix(Contexts.GridStyleMajorLines))
			c1.RangeID = 4
			c1.Properties.ImageIndex = 6
			c.Contexts.Add(c1)
			m_Manager.Contexts.Add(c1)

			c1 = New NCommandContext()
			c1.Properties.Text = "Major Dots"
			c1.Properties.ID = CInt(Fix(Contexts.GridStyleMajorDots))
			c1.RangeID = 4
			c1.Properties.ImageIndex = 7
			c.Contexts.Add(c1)
			m_Manager.Contexts.Add(c1)

			c1 = New NCommandContext()
			c1.Properties.Text = "Major Minor Lines"
			c1.Properties.ID = CInt(Fix(Contexts.GridStyleMajorMinorLines))
			c1.RangeID = 4
			c1.Properties.ImageIndex = 8
			c.Contexts.Add(c1)
			m_Manager.Contexts.Add(c1)

			c1 = New NCommandContext()
			c1.Properties.Text = "Interlaced"
			c1.Properties.ID = CInt(Fix(Contexts.GridStyleInterlaced))
			c1.RangeID = 4
			c1.Properties.ImageIndex = 9
			c.Contexts.Add(c1)
			m_Manager.Contexts.Add(c1)

			c1 = New NCommandContext()
			c1.Properties.Text = "Interlaced Horizontally"
			c1.Properties.ID = CInt(Fix(Contexts.GridStyleInterlacedHorizontally))
			c1.RangeID = 4
			c1.Properties.ImageIndex = 10
			c.Contexts.Add(c1)
			m_Manager.Contexts.Add(c1)

			c1 = New NCommandContext()
			c1.Properties.Text = "Interlaced Vertically"
			c1.Properties.ID = CInt(Fix(Contexts.GridStyleInterlacedVertically))
			c1.RangeID = 4
			c1.Properties.ImageIndex = 11
			c.Contexts.Add(c1)
			m_Manager.Contexts.Add(c1)
		End Sub

		Friend Sub CreateViewStyleContext()
			Dim c, c1 As NCommandContext

			c = New NCommandContext()
			c.RangeID = 4
			c.Properties.ID = CInt(Fix(Contexts.ViewStyle))
			c.Properties.ImageList = MainForm.ViewImages
			c.Properties.Text = "View Style"
			c.Properties.ImageIndex = 12
			m_Manager.Contexts.Add(c)

			c1 = New NCommandContext()
			c1.Properties.Text = "Fit"
			c1.Properties.ID = CInt(Fix(Contexts.ViewStyleFit))
			c1.RangeID = 4
			c1.Properties.ImageIndex = 13
			c.Contexts.Add(c1)
			m_Manager.Contexts.Add(c1)

			c1 = New NCommandContext()
			c1.Properties.Text = "Stretch"
			c1.Properties.ID = CInt(Fix(Contexts.ViewStyleStretch))
			c1.RangeID = 4
			c1.Properties.ImageIndex = 14
			c.Contexts.Add(c1)
			m_Manager.Contexts.Add(c1)

			c1 = New NCommandContext()
			c1.Properties.Text = "Stretch To Width"
			c1.Properties.ID = CInt(Fix(Contexts.ViewStyleStretchToWidth))
			c1.RangeID = 4
			c1.Properties.ImageIndex = 15
			c.Contexts.Add(c1)
			m_Manager.Contexts.Add(c1)

			c1 = New NCommandContext()
			c1.Properties.Text = "Stretch To Height"
			c1.Properties.ID = CInt(Fix(Contexts.ViewStyleStretchToHeight))
			c1.RangeID = 4
			c1.Properties.ImageIndex = 16
			c.Contexts.Add(c1)
			m_Manager.Contexts.Add(c1)
		End Sub


		#End Region

		#Region "Toolbars"

		Friend Sub InitToolbars()
			InitStandandardToolbar()
			InitActionToolbar()
			InitLayoutToolbar()
			InitToolsToolbar()
			InitViewToolbar()
			InitTestToolbar()
			InitComboBoxesToolbar()
			InitFormatToolbar()
		End Sub

		Friend Sub InitStandandardToolbar()
			Dim tb As NDockingToolbar = New NDockingToolbar()
			tb.DefaultRangeID = 0
			tb.Text = "Standard"
			'tb.Dock = DockStyle.Left;

			m_Manager.Toolbars.Add(tb)
			tb.Reset(False)
		End Sub
		Friend Sub InitActionToolbar()
			Dim tb As NDockingToolbar = New NDockingToolbar()
			tb.DefaultRangeID = 1
			'tb.Dock = DockStyle.Left;
			tb.Text = "Action"
			tb.RowIndex = 0

			m_Manager.Toolbars.Add(tb)
			tb.Reset(False)
		End Sub
		Friend Sub InitLayoutToolbar()
			Dim tb As NDockingToolbar = New NDockingToolbar()
			tb.DefaultRangeID = 2
			'tb.Dock = DockStyle.Bottom;
			tb.Text = "Layout"
			tb.RowIndex = 0

			m_Manager.Toolbars.Add(tb)
			tb.Reset(False)
		End Sub

		Friend Sub InitToolsToolbar()
			Dim tb As NDockingToolbar = New NDockingToolbar()
			tb.DefaultRangeID = 3
			'tb.Dock = DockStyle.Right;
			tb.Text = "Tools"

			m_Manager.Toolbars.Add(tb)
			tb.Reset(False)
		End Sub

		Friend Sub InitViewToolbar()
			Dim tb As NDockingToolbar = New NDockingToolbar()
			tb.DefaultRangeID = 4
			tb.Text = "View"

			m_Manager.Toolbars.Add(tb)
			tb.Reset(False)
		End Sub

		Friend Sub InitTestToolbar()
			Dim tb As NDockingToolbar = New NDockingToolbar()
			tb.DefaultRangeID = 5
			tb.Text = "Test"

			tb.AllowRename = False
			tb.AllowDelete = False
			'tb.AllowHide = false;

			m_Manager.Toolbars.Add(tb)
			tb.Reset(False)
		End Sub

		Friend Sub InitComboBoxesToolbar()
			Dim tb As NDockingToolbar = New NDockingToolbar()
			tb.DefaultRangeID = 6
			tb.Text = "ComboBoxes"

			m_Manager.Toolbars.Add(tb)
			tb.Reset(False)
		End Sub

		Friend Sub InitFormatToolbar()
			Dim tb As NDockingToolbar = New NDockingToolbar()
			tb.DefaultRangeID = 7
			tb.Text = "Format"

			m_Manager.Toolbars.Add(tb)
			tb.Reset(False)
		End Sub


		#End Region

		#End Region

		#Region "Event Handlers"

		Private Sub OnCommandContextExecuted(ByVal sender As Object, ByVal e As CommandContextEventArgs)
			Select Case e.Context.Properties.ID
				Case CInt(Fix(Contexts.Open))
					m_State.Load()
				Case CInt(Fix(Contexts.Save))
					m_State.Save()
				Case CInt(Fix(Contexts.FillStyle))
					Dim c As NComboBoxCommandContext = CType(m_Manager.CommandManager.GetContext(CInt(Fix(Contexts.ComboBoxContext2))), NComboBoxCommandContext)
					Dim comm As NComboBoxCommand = CType(c.GetCommands()(0), NComboBoxCommand)

					comm.HostedControl.SuspendLayout()
					comm.Items.Clear()

					'NListBoxItem item;
					For i As Integer = 0 To 199
						'item = new NListBoxItem(i, "NListBoxItem " + i, false);
						comm.Items.Add("Item " & i)
					Next i

					comm.HostedControl.ResumeLayout()

			End Select
		End Sub

		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nTabControl1 = New Nevron.UI.WinForm.Controls.NTabControl()
			Me.nTabPage1 = New Nevron.UI.WinForm.Controls.NTabPage()
			Me.nRichTextBox1 = New Nevron.UI.WinForm.Controls.NRichTextBox()
			Me.nTabPage2 = New Nevron.UI.WinForm.Controls.NTabPage()
			Me.nTabPage3 = New Nevron.UI.WinForm.Controls.NTabPage()
			Me.nTabPage4 = New Nevron.UI.WinForm.Controls.NTabPage()
			Me.nTabControl1.SuspendLayout()
			Me.nTabPage1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nTabControl1
			' 
			Me.nTabControl1.Controls.Add(Me.nTabPage1)
			Me.nTabControl1.Controls.Add(Me.nTabPage2)
			Me.nTabControl1.Controls.Add(Me.nTabPage3)
			Me.nTabControl1.Controls.Add(Me.nTabPage4)
			Me.nTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.nTabControl1.Location = New System.Drawing.Point(0, 0)
			Me.nTabControl1.Name = "nTabControl1"
			Me.nTabControl1.Selectable = True
			Me.nTabControl1.SelectedIndex = 0
			Me.nTabControl1.Size = New System.Drawing.Size(368, 256)
			Me.nTabControl1.TabIndex = 0
			' 
			' nTabPage1
			' 
			Me.nTabPage1.Controls.Add(Me.nRichTextBox1)
			Me.nTabPage1.Name = "nTabPage1"
			Me.nTabPage1.TabIndex = 1
			Me.nTabPage1.Text = "NTabPage"
			' 
			' nRichTextBox1
			' 
			Me.nRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.nRichTextBox1.Location = New System.Drawing.Point(0, 0)
			Me.nRichTextBox1.Name = "nRichTextBox1"
			Me.nRichTextBox1.Size = New System.Drawing.Size(358, 221)
			Me.nRichTextBox1.TabIndex = 0
			Me.nRichTextBox1.Text = "nRichTextBox1"
			' 
			' nTabPage2
			' 
			Me.nTabPage2.Name = "nTabPage2"
			Me.nTabPage2.TabIndex = 2
			Me.nTabPage2.Text = "NTabPage"
			' 
			' nTabPage3
			' 
			Me.nTabPage3.Name = "nTabPage3"
			Me.nTabPage3.TabIndex = 3
			Me.nTabPage3.Text = "NTabPage"
			' 
			' nTabPage4
			' 
			Me.nTabPage4.Name = "nTabPage4"
			Me.nTabPage4.TabIndex = 4
			Me.nTabPage4.Text = "NTabPage"
			' 
			' NDockingToolbarsUC
			' 
			Me.Controls.Add(Me.nTabControl1)
			Me.Name = "NDockingToolbarsUC"
			Me.Size = New System.Drawing.Size(368, 256)
			Me.nTabControl1.ResumeLayout(False)
			Me.nTabPage1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nTabControl1 As Nevron.UI.WinForm.Controls.NTabControl
		Private nTabPage1 As Nevron.UI.WinForm.Controls.NTabPage
		Private nTabPage2 As Nevron.UI.WinForm.Controls.NTabPage
		Private nRichTextBox1 As Nevron.UI.WinForm.Controls.NRichTextBox
		Private nTabPage3 As Nevron.UI.WinForm.Controls.NTabPage
		Private nTabPage4 As Nevron.UI.WinForm.Controls.NTabPage

		Friend m_Manager As NCommandBarsManager
		Friend m_State As NCommandBarsState

		#End Region
	End Class

	Public Class NUndoRedoCommandContext
		Inherits NListBoxCommandContext
		#Region "Constructor"

		Public Sub New()
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Sub PopulateList(ByVal list As NListBox)
			Dim rand As Random = New Random()
			Dim [end] As Integer = rand.Next(21, 101)
			Dim i As Integer = 1
			Do While i < [end]
				list.Items.Add("Undo/Redo Action " & i)
				i += 1
			Loop
		End Sub
		Protected Overrides Sub OnSelectionCommited(ByVal selectionCount As Integer)
			MessageBox.Show("Undo/Redo " & selectionCount & " actions")
		End Sub


		#End Region
	End Class
End Namespace
