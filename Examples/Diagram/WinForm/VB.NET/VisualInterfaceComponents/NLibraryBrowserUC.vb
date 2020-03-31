Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.Templates
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.WinForm.Commands

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NLibraryBrowserUC.
	''' </summary>
	Public Class NLibraryBrowserUC
		Inherits NDiagramExampleUC
		#Region "Constructor"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub

		#End Region

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.libraryBrowser = New Nevron.Diagram.WinForm.NLibraryBrowser()
			Me.openButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.saveButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.newButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.closeButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.viewStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' libraryBrowser
			' 
			Me.libraryBrowser.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.libraryBrowser.ContextMenuGroup = Nothing
			Me.libraryBrowser.Location = New System.Drawing.Point(8, 160)
			Me.libraryBrowser.Name = "libraryBrowser"
			Me.libraryBrowser.Size = New System.Drawing.Size(234, 352)
			Me.libraryBrowser.TabIndex = 29
			Me.libraryBrowser.ViewStyle = Nevron.Diagram.WinForm.LibraryViewStyle.IconsAndDetails
			' 
			' openButton
			' 
			Me.openButton.Location = New System.Drawing.Point(8, 56)
			Me.openButton.Name = "openButton"
			Me.openButton.Size = New System.Drawing.Size(112, 23)
			Me.openButton.TabIndex = 30
			Me.openButton.Text = "Open..."
'			Me.openButton.Click += New System.EventHandler(Me.openButton_Click);
			' 
			' saveButton
			' 
			Me.saveButton.Location = New System.Drawing.Point(128, 24)
			Me.saveButton.Name = "saveButton"
			Me.saveButton.Size = New System.Drawing.Size(112, 23)
			Me.saveButton.TabIndex = 31
			Me.saveButton.Text = "Save..."
'			Me.saveButton.Click += New System.EventHandler(Me.saveButton_Click);
			' 
			' newButton
			' 
			Me.newButton.Location = New System.Drawing.Point(8, 24)
			Me.newButton.Name = "newButton"
			Me.newButton.Size = New System.Drawing.Size(112, 23)
			Me.newButton.TabIndex = 32
			Me.newButton.Text = "New"
'			Me.newButton.Click += New System.EventHandler(Me.newButton_Click);
			' 
			' closeButton
			' 
			Me.closeButton.Location = New System.Drawing.Point(128, 56)
			Me.closeButton.Name = "closeButton"
			Me.closeButton.Size = New System.Drawing.Size(112, 23)
			Me.closeButton.TabIndex = 33
			Me.closeButton.Text = "Close"
'			Me.closeButton.Click += New System.EventHandler(Me.closeButton_Click);
			' 
			' viewStyleCombo
			' 
			Me.viewStyleCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.viewStyleCombo.Location = New System.Drawing.Point(80, 24)
			Me.viewStyleCombo.Name = "viewStyleCombo"
			Me.viewStyleCombo.Size = New System.Drawing.Size(160, 21)
			Me.viewStyleCombo.TabIndex = 34
			Me.viewStyleCombo.Text = "comboBox1"
'			Me.viewStyleCombo.SelectedIndexChanged += New System.EventHandler(Me.viewStyleCombo_SelectedIndexChanged);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.newButton)
			Me.groupBox1.Controls.Add(Me.saveButton)
			Me.groupBox1.Controls.Add(Me.closeButton)
			Me.groupBox1.Controls.Add(Me.openButton)
			Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox1.Location = New System.Drawing.Point(0, 0)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(250, 96)
			Me.groupBox1.TabIndex = 35
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Library browser operations"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.label1)
			Me.groupBox2.Controls.Add(Me.viewStyleCombo)
			Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox2.Location = New System.Drawing.Point(0, 96)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(250, 56)
			Me.groupBox2.TabIndex = 36
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Library browser appearance"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(64, 23)
			Me.label1.TabIndex = 35
			Me.label1.Text = "View style:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' NLibraryBrowserUC
			' 
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.libraryBrowser)
			Me.Name = "NLibraryBrowserUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.libraryBrowser, 0)
			Me.Controls.SetChildIndex(Me.groupBox1, 0)
			Me.Controls.SetChildIndex(Me.groupBox2, 0)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' attach the library browser to the command bars manager, 
			' in order so that it can display context menus
			Form.CommandBarsManager.LibraryBrowser = libraryBrowser

			' clear all bands (library groups)
			libraryBrowser.ClearBands()

			' create a new library
			Dim library As NLibraryDocument = New NLibraryDocument()
			library.Info.Title = "My first library"

			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)

			' add several masters in the library
			Dim shape As NShape = factory.CreateShape(CInt(Fix(BasicShapes.Pentagram)))
			shape.Width = 130
			shape.Height = 130
			library.AddChild(New NMaster(shape, NGraphicsUnit.Pixel, "Star", "My star"))

			shape = factory.CreateShape(CInt(Fix(BasicShapes.Octagram)))
			shape.Width = 130
			shape.Height = 130
			library.AddChild(New NMaster(shape, NGraphicsUnit.Pixel, "Octagon", "My octagon"))

			' create a new library group hosting the library
			libraryBrowser.OpenLibraryGroup(library)

			' start view init
			view.BeginInit()

			document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None
			document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None
			view.AllowDrop = True

			' init document
			document.BeginInit()
			CreateCustomOpenFigureShape()
			CreateCustomClosedFigureShape()
			document.EndInit()

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				' detach the library browser from the command bars manager
				Form.CommandBarsManager.LibraryBrowser = Nothing
			End If

			MyBase.Dispose(disposing)
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			viewStyleCombo.FillFromEnum(GetType(LibraryViewStyle))
			viewStyleCombo.SelectedIndex = CInt(Fix(libraryBrowser.ViewStyle))

			ResumeEventsHandling()
		End Sub

		Private Sub CreateCustomClosedFigureShape()
			' create the coffee cup shape
			Dim graphicsPath As GraphicsPath = New GraphicsPath()

			AddFilledCup(graphicsPath)
			AddFilledCupHandle(graphicsPath)
			AddFilledSteam(graphicsPath)

			graphicsPath.CloseAllFigures()

			Dim shape As NCompositeShape = New NCompositeShape()
			shape.Primitives.AddChild(New NCustomPath(graphicsPath, PathType.ClosedFigure))
			shape.UpdateModelBounds()

			shape.Style.FillStyle = New NColorFillStyle(Color.FromArgb(50, 0, 0, &H88))
			shape.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(0, 0, &H88))

			document.ActiveLayer.AddChild(shape)

			' describe the shape
			Dim text As NTextShape = New NTextShape("Custom Shape 1", 35, 340, 120, 50)
			text.Style.FillStyle = New NColorFillStyle(Color.Black)
			text.Style.TextStyle = New NTextStyle()
			text.Style.TextStyle.FontStyle = New NFontStyle(New Font("Arial", 9))
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreateCustomOpenFigureShape()
			' create the coffee cup shape
			Dim graphicsPath As GraphicsPath = New GraphicsPath()

			AddStrokeCup(graphicsPath)
			AddStrokeCupHandle(graphicsPath)
			AddStrokeSteam(graphicsPath)

			Dim shape As NCompositeShape = New NCompositeShape()
			shape.Primitives.AddChild(New NCustomPath(graphicsPath, PathType.OpenFigure))
			shape.UpdateModelBounds()

			shape.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(0, 0, &Haa))
			document.ActiveLayer.AddChild(shape)

			' describe the shape
			Dim text As NTextShape = New NTextShape("Custom Shape 2", 195, 340, 120, 50)
			text.Style.FillStyle = New NColorFillStyle(Color.Black)
			text.Style.TextStyle = New NTextStyle()
			text.Style.TextStyle.FontStyle = New NFontStyle(New Font("Arial", 9))
			document.ActiveLayer.AddChild(text)
		End Sub


		Private Sub AddFilledCup(ByVal graphicsPath As GraphicsPath)
			Dim points As PointF() = New PointF() { New PointF(45, 268), New PointF(63, 331), New PointF(121, 331), New PointF(140, 268) }

			graphicsPath.AddPolygon(points)
		End Sub

		Private Sub AddFilledCupHandle(ByVal graphicsPath As GraphicsPath)
			Dim points As PointF() = New PointF() { New PointF(175, 295), New PointF(171, 278), New PointF(140, 283), New PointF(170, 290), New PointF(128, 323) }

			graphicsPath.AddClosedCurve(points, 1)
		End Sub

		Private Sub AddFilledSteam(ByVal graphicsPath As GraphicsPath)
			Dim points As PointF() = New PointF() { New PointF(92, 258), New PointF(53, 163), New PointF(145, 160), New PointF(86, 50), New PointF(138, 194), New PointF(45, 145), New PointF(92, 258) }

			graphicsPath.AddBeziers(points)
		End Sub

		Private Sub AddStrokeCup(ByVal graphicsPath As GraphicsPath)
			graphicsPath.StartFigure()
			Dim points As PointF() = New PointF() { New PointF(205, 268), New PointF(223, 331), New PointF(281, 331), New PointF(300, 268) }

			graphicsPath.AddLines(points)
		End Sub

		Private Sub AddStrokeCupHandle(ByVal graphicsPath As GraphicsPath)
			graphicsPath.StartFigure()
			Dim points As PointF() = New PointF() { New PointF(300, 283), New PointF(330, 290), New PointF(288, 323) }

			graphicsPath.AddCurve(points, 1)
		End Sub

		Private Sub AddStrokeSteam(ByVal graphicsPath As GraphicsPath)
			graphicsPath.StartFigure()
			Dim points As PointF() = New PointF() { New PointF(252, 258), New PointF(213, 163), New PointF(305, 160), New PointF(246, 50) }

			graphicsPath.AddBeziers(points)
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub saveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles saveButton.Click
			If Not libraryBrowser.ExpandedGroup Is Nothing Then
				libraryBrowser.ExpandedGroup.SaveLibrary()
			End If
		End Sub

		Private Sub openButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles openButton.Click
			libraryBrowser.OpenLibraryGroup()
		End Sub

		Private Sub newButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles newButton.Click
			libraryBrowser.NewEmptyLibraryGroup("New library")
		End Sub

		Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click
			If Not libraryBrowser.ExpandedGroup Is Nothing Then
				libraryBrowser.CloseLibraryGroup(libraryBrowser.ExpandedGroup)
			End If
		End Sub

		Private Sub viewStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles viewStyleCombo.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			libraryBrowser.ViewStyle = CType(viewStyleCombo.SelectedIndex, LibraryViewStyle)
		End Sub


		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents saveButton As Nevron.UI.WinForm.Controls.NButton

		Private WithEvents openButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents newButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents closeButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents viewStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label1 As System.Windows.Forms.Label

		#End Region

		#Region "Fields"

		Private libraryGroup As NLibraryGroup = Nothing
		Private libraryBrowser As NLibraryBrowser

		#End Region
	End Class
End Namespace