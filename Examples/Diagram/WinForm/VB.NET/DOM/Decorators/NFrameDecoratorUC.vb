Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Filters
Imports Nevron.Editors
Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.Batches
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Templates
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.WinForm.Commands

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NFrameDecoratorUC.
	''' </summary>
	Public Class NFrameDecoratorUC
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
			Me.HeaderFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.HeaderStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.BackgroundStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.BackgroundFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShapeHitTestableCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.HitTestHeaderCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.HitTestBackgroundCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.HitTestFrameCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.HeaderSizeUpDown = New System.Windows.Forms.NumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			Me.HeaderTextStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShowHeaderCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowBackgroundCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			CType(Me.HeaderSizeUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' HeaderFillStyleButton
			' 
			Me.HeaderFillStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.HeaderFillStyleButton.Location = New System.Drawing.Point(6, 217)
			Me.HeaderFillStyleButton.Name = "HeaderFillStyleButton"
			Me.HeaderFillStyleButton.Size = New System.Drawing.Size(232, 23)
			Me.HeaderFillStyleButton.TabIndex = 8
			Me.HeaderFillStyleButton.Text = "Header Fill Style..."
			Me.HeaderFillStyleButton.UseVisualStyleBackColor = True
'			Me.HeaderFillStyleButton.Click += New System.EventHandler(Me.HeaderFillStyleButton_Click);
			' 
			' HeaderStrokeStyleButton
			' 
			Me.HeaderStrokeStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.HeaderStrokeStyleButton.Location = New System.Drawing.Point(6, 246)
			Me.HeaderStrokeStyleButton.Name = "HeaderStrokeStyleButton"
			Me.HeaderStrokeStyleButton.Size = New System.Drawing.Size(232, 23)
			Me.HeaderStrokeStyleButton.TabIndex = 9
			Me.HeaderStrokeStyleButton.Text = "Header Stroke Style..."
			Me.HeaderStrokeStyleButton.UseVisualStyleBackColor = True
'			Me.HeaderStrokeStyleButton.Click += New System.EventHandler(Me.HeaderStrokeStyleButton_Click);
			' 
			' BackgroundStrokeStyleButton
			' 
			Me.BackgroundStrokeStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.BackgroundStrokeStyleButton.Location = New System.Drawing.Point(6, 316)
			Me.BackgroundStrokeStyleButton.Name = "BackgroundStrokeStyleButton"
			Me.BackgroundStrokeStyleButton.Size = New System.Drawing.Size(232, 23)
			Me.BackgroundStrokeStyleButton.TabIndex = 11
			Me.BackgroundStrokeStyleButton.Text = "Background Stroke Style..."
			Me.BackgroundStrokeStyleButton.UseVisualStyleBackColor = True
'			Me.BackgroundStrokeStyleButton.Click += New System.EventHandler(Me.BackgroundStrokeStyleButton_Click);
			' 
			' BackgroundFillStyleButton
			' 
			Me.BackgroundFillStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.BackgroundFillStyleButton.Location = New System.Drawing.Point(6, 287)
			Me.BackgroundFillStyleButton.Name = "BackgroundFillStyleButton"
			Me.BackgroundFillStyleButton.Size = New System.Drawing.Size(232, 23)
			Me.BackgroundFillStyleButton.TabIndex = 10
			Me.BackgroundFillStyleButton.Text = "Background Fill Style..."
			Me.BackgroundFillStyleButton.UseVisualStyleBackColor = True
'			Me.BackgroundFillStyleButton.Click += New System.EventHandler(Me.BackgroundFillStyleButton_Click);
			' 
			' ShapeHitTestableCheck
			' 
			Me.ShapeHitTestableCheck.AutoSize = True
			Me.ShapeHitTestableCheck.ButtonProperties.BorderOffset = 2
			Me.ShapeHitTestableCheck.Location = New System.Drawing.Point(6, 51)
			Me.ShapeHitTestableCheck.Name = "ShapeHitTestableCheck"
			Me.ShapeHitTestableCheck.Size = New System.Drawing.Size(117, 17)
			Me.ShapeHitTestableCheck.TabIndex = 12
			Me.ShapeHitTestableCheck.Text = "Shape Hit Testable"
			Me.ShapeHitTestableCheck.UseVisualStyleBackColor = True
'			Me.ShapeHitTestableCheck.CheckedChanged += New System.EventHandler(Me.ShapeHitTestableCheck_CheckedChanged);
			' 
			' HitTestHeaderCheck
			' 
			Me.HitTestHeaderCheck.AutoSize = True
			Me.HitTestHeaderCheck.ButtonProperties.BorderOffset = 2
			Me.HitTestHeaderCheck.Location = New System.Drawing.Point(17, 74)
			Me.HitTestHeaderCheck.Name = "HitTestHeaderCheck"
			Me.HitTestHeaderCheck.Size = New System.Drawing.Size(101, 17)
			Me.HitTestHeaderCheck.TabIndex = 13
			Me.HitTestHeaderCheck.Text = "Hit Test Header"
			Me.HitTestHeaderCheck.UseVisualStyleBackColor = True
'			Me.HitTestHeaderCheck.CheckedChanged += New System.EventHandler(Me.HitTestHeaderCheck_CheckedChanged);
			' 
			' HitTestBackgroundCheck
			' 
			Me.HitTestBackgroundCheck.AutoSize = True
			Me.HitTestBackgroundCheck.ButtonProperties.BorderOffset = 2
			Me.HitTestBackgroundCheck.Location = New System.Drawing.Point(17, 97)
			Me.HitTestBackgroundCheck.Name = "HitTestBackgroundCheck"
			Me.HitTestBackgroundCheck.Size = New System.Drawing.Size(124, 17)
			Me.HitTestBackgroundCheck.TabIndex = 14
			Me.HitTestBackgroundCheck.Text = "Hit Test Background"
			Me.HitTestBackgroundCheck.UseVisualStyleBackColor = True
'			Me.HitTestBackgroundCheck.CheckedChanged += New System.EventHandler(Me.HitTestBackgroundCheck_CheckedChanged);
			' 
			' HitTestFrameCheck
			' 
			Me.HitTestFrameCheck.AutoSize = True
			Me.HitTestFrameCheck.ButtonProperties.BorderOffset = 2
			Me.HitTestFrameCheck.Location = New System.Drawing.Point(17, 120)
			Me.HitTestFrameCheck.Name = "HitTestFrameCheck"
			Me.HitTestFrameCheck.Size = New System.Drawing.Size(120, 17)
			Me.HitTestFrameCheck.TabIndex = 15
			Me.HitTestFrameCheck.Text = "HitTestFrameCheck"
			Me.HitTestFrameCheck.UseVisualStyleBackColor = True
'			Me.HitTestFrameCheck.CheckedChanged += New System.EventHandler(Me.HitTestFrameCheck_CheckedChanged);
			' 
			' HeaderSizeUpDown
			' 
			Me.HeaderSizeUpDown.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.HeaderSizeUpDown.AutoSize = True
			Me.HeaderSizeUpDown.Location = New System.Drawing.Point(79, 144)
			Me.HeaderSizeUpDown.Name = "HeaderSizeUpDown"
			Me.HeaderSizeUpDown.Size = New System.Drawing.Size(158, 20)
			Me.HeaderSizeUpDown.TabIndex = 16
'			Me.HeaderSizeUpDown.ValueChanged += New System.EventHandler(Me.HeaderSizeUpDown_ValueChanged);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(5, 151)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(68, 13)
			Me.label1.TabIndex = 17
			Me.label1.Text = "Header Size:"
			' 
			' HeaderTextStyleButton
			' 
			Me.HeaderTextStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.HeaderTextStyleButton.Location = New System.Drawing.Point(6, 188)
			Me.HeaderTextStyleButton.Name = "HeaderTextStyleButton"
			Me.HeaderTextStyleButton.Size = New System.Drawing.Size(232, 23)
			Me.HeaderTextStyleButton.TabIndex = 18
			Me.HeaderTextStyleButton.Text = "Header Text Style..."
			Me.HeaderTextStyleButton.UseVisualStyleBackColor = True
'			Me.HeaderTextStyleButton.Click += New System.EventHandler(Me.HeaderTextStyleButton_Click);
			' 
			' ShowHeaderCheck
			' 
			Me.ShowHeaderCheck.AutoSize = True
			Me.ShowHeaderCheck.ButtonProperties.BorderOffset = 2
			Me.ShowHeaderCheck.Location = New System.Drawing.Point(6, 5)
			Me.ShowHeaderCheck.Name = "ShowHeaderCheck"
			Me.ShowHeaderCheck.Size = New System.Drawing.Size(91, 17)
			Me.ShowHeaderCheck.TabIndex = 19
			Me.ShowHeaderCheck.Text = "Show Header"
			Me.ShowHeaderCheck.UseVisualStyleBackColor = True
'			Me.ShowHeaderCheck.CheckedChanged += New System.EventHandler(Me.ShowHeaderCheck_CheckedChanged);
			' 
			' ShowBackgroundCheck
			' 
			Me.ShowBackgroundCheck.AutoSize = True
			Me.ShowBackgroundCheck.ButtonProperties.BorderOffset = 2
			Me.ShowBackgroundCheck.Location = New System.Drawing.Point(6, 28)
			Me.ShowBackgroundCheck.Name = "ShowBackgroundCheck"
			Me.ShowBackgroundCheck.Size = New System.Drawing.Size(114, 17)
			Me.ShowBackgroundCheck.TabIndex = 20
			Me.ShowBackgroundCheck.Text = "Show Background"
			Me.ShowBackgroundCheck.UseVisualStyleBackColor = True
'			Me.ShowBackgroundCheck.CheckedChanged += New System.EventHandler(Me.ShowBackgroundCheck_CheckedChanged);
			' 
			' NFrameDecoratorUC
			' 
			Me.Controls.Add(Me.ShowBackgroundCheck)
			Me.Controls.Add(Me.ShowHeaderCheck)
			Me.Controls.Add(Me.HeaderTextStyleButton)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.HeaderSizeUpDown)
			Me.Controls.Add(Me.HitTestFrameCheck)
			Me.Controls.Add(Me.HitTestBackgroundCheck)
			Me.Controls.Add(Me.HitTestHeaderCheck)
			Me.Controls.Add(Me.ShapeHitTestableCheck)
			Me.Controls.Add(Me.BackgroundStrokeStyleButton)
			Me.Controls.Add(Me.BackgroundFillStyleButton)
			Me.Controls.Add(Me.HeaderStrokeStyleButton)
			Me.Controls.Add(Me.HeaderFillStyleButton)
			Me.Name = "NFrameDecoratorUC"
			Me.Size = New System.Drawing.Size(248, 501)
			Me.Controls.SetChildIndex(Me.HeaderFillStyleButton, 0)
			Me.Controls.SetChildIndex(Me.HeaderStrokeStyleButton, 0)
			Me.Controls.SetChildIndex(Me.BackgroundFillStyleButton, 0)
			Me.Controls.SetChildIndex(Me.BackgroundStrokeStyleButton, 0)
			Me.Controls.SetChildIndex(Me.ShapeHitTestableCheck, 0)
			Me.Controls.SetChildIndex(Me.HitTestHeaderCheck, 0)
			Me.Controls.SetChildIndex(Me.HitTestBackgroundCheck, 0)
			Me.Controls.SetChildIndex(Me.HitTestFrameCheck, 0)
			Me.Controls.SetChildIndex(Me.HeaderSizeUpDown, 0)
			Me.Controls.SetChildIndex(Me.label1, 0)
			Me.Controls.SetChildIndex(Me.HeaderTextStyleButton, 0)
			Me.Controls.SetChildIndex(Me.ShowHeaderCheck, 0)
			Me.Controls.SetChildIndex(Me.ShowBackgroundCheck, 0)
			CType(Me.HeaderSizeUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			view.ViewLayout = ViewLayout.Fit
			view.Grid.Visible = False
			view.HorizontalRuler.Visible = False
			view.VerticalRuler.Visible = False
			view.GlobalVisibility.ShowPorts = False
			view.TrackersManager.Enabled = False

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' end view init
			view.EndInit()

			' init the form controls
			PauseEventsHandling()
			InitFormControls()
			ResumeEventsHandling()
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			Dim basicShapesFactory As NBasicShapesFactory = New NBasicShapesFactory()
			basicShapesFactory.DefaultSize = New NSizeF(100, 100)

			' create groups and apply a frame decorator to each one of them
			For i As Integer = 0 To 3
				Dim shape1 As NShape = basicShapesFactory.CreateShape(BasicShapes.Octagon)
				shape1.Bounds = New NRectangleF(0, 0, 80, 80)

				Dim shape2 As NShape = basicShapesFactory.CreateShape(BasicShapes.Ellipse)
				shape2.Bounds = New NRectangleF(100, 100, 80, 80)

				Dim group As NGroup = New NGroup()
				group.Shapes.AddChild(shape1)
				group.Shapes.AddChild(shape2)
				group.Padding = New Nevron.Diagram.NMargins(30)
				group.UpdateModelBounds()

				Dim frameDecorator As NFrameDecorator = New NFrameDecorator()
				frameDecorator.StyleSheetName = "Decorators"
				frameDecorator.ShapeHitTestable = True
				frameDecorator.Header.Text = "Header"

				group.CreateShapeElements(ShapeElementsMask.Decorators)
				group.Decorators.AddChild(frameDecorator)

				document.ActiveLayer.AddChild(group)
			Next i

			' layout them with a table layout
			Dim layout As NTableLayout = New NTableLayout()
			layout.ConstrainMode = CellConstrainMode.Ordinal
			layout.MaxOrdinal = 2
			layout.HorizontalSpacing = 20
			layout.VerticalSpacing = 20
			layout.Layout(document.ActiveLayer.Children(Nothing), New NDrawingLayoutContext(document))

			' size document to content
			document.SizeToContent(NSizeF.Empty, document.AutoBoundsPadding)
		End Sub
		Private Sub InitFormControls()
			ShapeHitTestableCheck.Checked = False
			HitTestFrameCheck.Checked = True
			HitTestHeaderCheck.Checked = True
			HitTestBackgroundCheck.Checked = True
			HeaderSizeUpDown.Value = 20
			HeaderSizeUpDown.Minimum = 1
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub ShowHeaderCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowHeaderCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			For Each decorator As NFrameDecorator In document.Descendants(New NInstanceOfTypeFilter(GetType(NFrameDecorator)), -1)
				decorator.Header.Visible = ShowHeaderCheck.Checked
			Next decorator

			document.SmartRefreshAllViews()
		End Sub
		Private Sub ShowBackgroundCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowBackgroundCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			For Each decorator As NFrameDecorator In document.Descendants(New NInstanceOfTypeFilter(GetType(NFrameDecorator)), -1)
				decorator.Background.Visible = ShowBackgroundCheck.Checked
			Next decorator

			document.SmartRefreshAllViews()
		End Sub
		Private Sub ShapeHitTestableCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShapeHitTestableCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			For Each decorator As NFrameDecorator In document.Descendants(New NInstanceOfTypeFilter(GetType(NFrameDecorator)), -1)
				decorator.ShapeHitTestable = ShapeHitTestableCheck.Checked
			Next decorator
		End Sub
		Private Sub HitTestHeaderCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles HitTestHeaderCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			For Each decorator As NFrameDecorator In document.Descendants(New NInstanceOfTypeFilter(GetType(NFrameDecorator)), -1)
				decorator.HitTestHeader = HitTestHeaderCheck.Checked
			Next decorator
		End Sub
		Private Sub HitTestBackgroundCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles HitTestBackgroundCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			For Each decorator As NFrameDecorator In document.Descendants(New NInstanceOfTypeFilter(GetType(NFrameDecorator)), -1)
				decorator.HitTestBackground = HitTestBackgroundCheck.Checked
			Next decorator
		End Sub
		Private Sub HitTestFrameCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles HitTestFrameCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			For Each decorator As NFrameDecorator In document.Descendants(New NInstanceOfTypeFilter(GetType(NFrameDecorator)), -1)
				decorator.HitTestFrame = HitTestFrameCheck.Checked
			Next decorator
		End Sub
		Private Sub HeaderSizeUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles HeaderSizeUpDown.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			For Each decorator As NFrameDecorator In document.Descendants(New NInstanceOfTypeFilter(GetType(NFrameDecorator)), -1)
				decorator.Header.Size = CSng(HeaderSizeUpDown.Value)
			Next decorator

			document.SmartRefreshAllViews()
		End Sub
		Private Sub HeaderTextStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles HeaderTextStyleButton.Click
			Dim styleSheet As NStyleSheet = CType(document.StyleSheets.GetChildByName(NDR.NameFrameDecoratorHeadersStyleSheet), NStyleSheet)

			Dim textStyle As NTextStyle
			If NTextStyleTypeEditor.Edit(styleSheet.Style.TextStyle, textStyle) Then
				styleSheet.Style.TextStyle = textStyle
				document.SmartRefreshAllViews()
			End If
		End Sub
		Private Sub HeaderFillStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles HeaderFillStyleButton.Click
			Dim styleSheet As NStyleSheet = CType(document.StyleSheets.GetChildByName(NDR.NameFrameDecoratorHeadersStyleSheet), NStyleSheet)

			Dim fillStyle As NFillStyle
			If NFillStyleTypeEditor.Edit(styleSheet.Style.FillStyle, fillStyle) Then
				styleSheet.Style.FillStyle = fillStyle
				document.SmartRefreshAllViews()
			End If
		End Sub
		Private Sub HeaderStrokeStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles HeaderStrokeStyleButton.Click
			Dim styleSheet As NStyleSheet = CType(document.StyleSheets.GetChildByName(NDR.NameFrameDecoratorHeadersStyleSheet), NStyleSheet)

			Dim strokeStyle As NStrokeStyle
			If NStrokeStyleTypeEditor.Edit(styleSheet.Style.StrokeStyle, strokeStyle) Then
				styleSheet.Style.StrokeStyle = strokeStyle
				document.SmartRefreshAllViews()
			End If
		End Sub
		Private Sub BackgroundFillStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BackgroundFillStyleButton.Click
			Dim styleSheet As NStyleSheet = CType(document.StyleSheets.GetChildByName(NDR.NameFrameDecoratorBackgroundsStyleSheet), NStyleSheet)

			Dim fillStyle As NFillStyle
			If NFillStyleTypeEditor.Edit(styleSheet.Style.FillStyle, fillStyle) Then
				styleSheet.Style.FillStyle = fillStyle
				document.SmartRefreshAllViews()
			End If
		End Sub
		Private Sub BackgroundStrokeStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BackgroundStrokeStyleButton.Click
			Dim styleSheet As NStyleSheet = CType(document.StyleSheets.GetChildByName(NDR.NameFrameDecoratorBackgroundsStyleSheet), NStyleSheet)

			Dim strokeStyle As NStrokeStyle
			If NStrokeStyleTypeEditor.Edit(styleSheet.Style.StrokeStyle, strokeStyle) Then
				styleSheet.Style.StrokeStyle = strokeStyle
				document.SmartRefreshAllViews()
			End If
		End Sub

		#End Region

		#Region "Designer Fields"

		Private WithEvents HeaderFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents HeaderStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BackgroundStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BackgroundFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ShapeHitTestableCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents HitTestHeaderCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents HitTestBackgroundCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents HitTestFrameCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents HeaderSizeUpDown As System.Windows.Forms.NumericUpDown
		Private label1 As Label
		Private WithEvents HeaderTextStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ShowHeaderCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowBackgroundCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace