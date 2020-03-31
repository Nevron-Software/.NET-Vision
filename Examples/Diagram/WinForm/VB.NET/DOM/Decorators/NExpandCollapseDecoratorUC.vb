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
	''' Summary description for NExpandCollapseDecoratorUC.
	''' </summary>
	Public Class NExpandCollapseDecoratorUC
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
			Me.SymbolCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.BackgroundCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.LeftRadio = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.RightRadio = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.label3 = New System.Windows.Forms.Label()
			Me.SymbolFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SymbolStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.BackgroundStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.BackgroundFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' SymbolCombo
			' 
			Me.SymbolCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.SymbolCombo.Location = New System.Drawing.Point(8, 31)
			Me.SymbolCombo.Name = "SymbolCombo"
			Me.SymbolCombo.Size = New System.Drawing.Size(232, 21)
			Me.SymbolCombo.TabIndex = 1
'			Me.SymbolCombo.SelectedIndexChanged += New System.EventHandler(Me.SymbolCombo_SelectedIndexChanged);
			' 
			' BackgroundCombo
			' 
			Me.BackgroundCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.BackgroundCombo.Location = New System.Drawing.Point(8, 83)
			Me.BackgroundCombo.Name = "BackgroundCombo"
			Me.BackgroundCombo.Size = New System.Drawing.Size(232, 21)
			Me.BackgroundCombo.TabIndex = 2
'			Me.BackgroundCombo.SelectedIndexChanged += New System.EventHandler(Me.BackgroundCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(78, 13)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Symbol Shape:"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(8, 62)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(102, 13)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Background Shape:"
			' 
			' LeftRadio
			' 
			Me.LeftRadio.AutoSize = True
			Me.LeftRadio.Checked = True
			Me.LeftRadio.Location = New System.Drawing.Point(11, 134)
			Me.LeftRadio.Name = "LeftRadio"
			Me.LeftRadio.Size = New System.Drawing.Size(43, 17)
			Me.LeftRadio.TabIndex = 5
			Me.LeftRadio.TabStop = True
			Me.LeftRadio.Text = "Left"
			Me.LeftRadio.UseVisualStyleBackColor = True
'			Me.LeftRadio.CheckedChanged += New System.EventHandler(Me.LeftRadio_CheckedChanged);
			' 
			' RightRadio
			' 
			Me.RightRadio.AutoSize = True
			Me.RightRadio.Location = New System.Drawing.Point(11, 157)
			Me.RightRadio.Name = "RightRadio"
			Me.RightRadio.Size = New System.Drawing.Size(50, 17)
			Me.RightRadio.TabIndex = 6
			Me.RightRadio.Text = "Right"
			Me.RightRadio.UseVisualStyleBackColor = True
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(11, 115)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(47, 13)
			Me.label3.TabIndex = 7
			Me.label3.Text = "Position:"
			' 
			' SymbolFillStyleButton
			' 
			Me.SymbolFillStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.SymbolFillStyleButton.Location = New System.Drawing.Point(8, 181)
			Me.SymbolFillStyleButton.Name = "SymbolFillStyleButton"
			Me.SymbolFillStyleButton.Size = New System.Drawing.Size(232, 23)
			Me.SymbolFillStyleButton.TabIndex = 8
			Me.SymbolFillStyleButton.Text = "Symbol Fill Style..."
			Me.SymbolFillStyleButton.UseVisualStyleBackColor = True
'			Me.SymbolFillStyleButton.Click += New System.EventHandler(Me.SymbolFillStyleButton_Click);
			' 
			' SymbolStrokeStyleButton
			' 
			Me.SymbolStrokeStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.SymbolStrokeStyleButton.Location = New System.Drawing.Point(8, 210)
			Me.SymbolStrokeStyleButton.Name = "SymbolStrokeStyleButton"
			Me.SymbolStrokeStyleButton.Size = New System.Drawing.Size(232, 23)
			Me.SymbolStrokeStyleButton.TabIndex = 9
			Me.SymbolStrokeStyleButton.Text = "Symbol Stroke Style..."
			Me.SymbolStrokeStyleButton.UseVisualStyleBackColor = True
'			Me.SymbolStrokeStyleButton.Click += New System.EventHandler(Me.SymbolStrokeStyleButton_Click);
			' 
			' BackgroundStrokeStyleButton
			' 
			Me.BackgroundStrokeStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.BackgroundStrokeStyleButton.Location = New System.Drawing.Point(8, 275)
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
			Me.BackgroundFillStyleButton.Location = New System.Drawing.Point(8, 246)
			Me.BackgroundFillStyleButton.Name = "BackgroundFillStyleButton"
			Me.BackgroundFillStyleButton.Size = New System.Drawing.Size(232, 23)
			Me.BackgroundFillStyleButton.TabIndex = 10
			Me.BackgroundFillStyleButton.Text = "Background Fill Style..."
			Me.BackgroundFillStyleButton.UseVisualStyleBackColor = True
'			Me.BackgroundFillStyleButton.Click += New System.EventHandler(Me.BackgroundFillStyleButton_Click);
			' 
			' NExpandCollapseDecoratorUC
			' 
			Me.Controls.Add(Me.BackgroundStrokeStyleButton)
			Me.Controls.Add(Me.BackgroundFillStyleButton)
			Me.Controls.Add(Me.SymbolStrokeStyleButton)
			Me.Controls.Add(Me.SymbolFillStyleButton)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.RightRadio)
			Me.Controls.Add(Me.LeftRadio)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.BackgroundCombo)
			Me.Controls.Add(Me.SymbolCombo)
			Me.Name = "NExpandCollapseDecoratorUC"
			Me.Size = New System.Drawing.Size(248, 456)
			Me.Controls.SetChildIndex(Me.SymbolCombo, 0)
			Me.Controls.SetChildIndex(Me.BackgroundCombo, 0)
			Me.Controls.SetChildIndex(Me.label1, 0)
			Me.Controls.SetChildIndex(Me.label2, 0)
			Me.Controls.SetChildIndex(Me.LeftRadio, 0)
			Me.Controls.SetChildIndex(Me.RightRadio, 0)
			Me.Controls.SetChildIndex(Me.label3, 0)
			Me.Controls.SetChildIndex(Me.SymbolFillStyleButton, 0)
			Me.Controls.SetChildIndex(Me.SymbolStrokeStyleButton, 0)
			Me.Controls.SetChildIndex(Me.BackgroundFillStyleButton, 0)
			Me.Controls.SetChildIndex(Me.BackgroundStrokeStyleButton, 0)
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
			Dim networkShapes As NSimpleNetworkShapesFactory = New NSimpleNetworkShapesFactory()
			networkShapes.DefaultSize = New NSizeF(50, 50)
			Dim i As Integer

			' create computers
			For i = 0 To 8
				Dim computer As NShape = networkShapes.CreateShape(SimpleNetworkShapes.Computer)
				Select Case i Mod 3
					Case 0
						computer.Location = New NPointF(10, 10)
					Case 1
						computer.Location = New NPointF(110, 10)
					Case 2
						computer.Location = New NPointF(75, 110)
				End Select

				document.ActiveLayer.AddChild(computer)
			Next i

			' link the computers
			For i = 0 To 2
				Dim link As NLineShape = New NLineShape()
				link.StyleSheetName = NDR.NameConnectorsStyleSheet
				document.ActiveLayer.AddChild(link)

				If i = 0 Then
					link.FromShape = CType(document.ActiveLayer.GetChildAt(8), NShape)
					link.ToShape = CType(document.ActiveLayer.GetChildAt(0), NShape)
				Else
					link.FromShape = CType(document.ActiveLayer.GetChildAt(i * 3 - 1), NShape)
					link.ToShape = CType(document.ActiveLayer.GetChildAt(i * 3), NShape)
				End If
			Next i

			' create three groups
			Dim groupNodes1 As NNodeList = New NNodeList()
			Dim batchGroup1 As NBatchGroup = New NBatchGroup(document)
			groupNodes1.Add(document.ActiveLayer.GetChildAt(0))
			groupNodes1.Add(document.ActiveLayer.GetChildAt(1))
			groupNodes1.Add(document.ActiveLayer.GetChildAt(2))
			batchGroup1.Build(groupNodes1)

			Dim groupNodes2 As NNodeList = New NNodeList()
			Dim batchGroup2 As NBatchGroup = New NBatchGroup(document)
			groupNodes2.Add(document.ActiveLayer.GetChildAt(3))
			groupNodes2.Add(document.ActiveLayer.GetChildAt(4))
			groupNodes2.Add(document.ActiveLayer.GetChildAt(5))
			batchGroup2.Build(groupNodes2)

			Dim groupNodes3 As NNodeList = New NNodeList()
			Dim batchGroup3 As NBatchGroup = New NBatchGroup(document)
			groupNodes3.Add(document.ActiveLayer.GetChildAt(6))
			groupNodes3.Add(document.ActiveLayer.GetChildAt(7))
			groupNodes3.Add(document.ActiveLayer.GetChildAt(8))
			batchGroup3.Build(groupNodes3)

			Dim groups As NGroup() = New NGroup(2){}
			batchGroup1.Group(document.ActiveLayer, False, groups(0))
			batchGroup2.Group(document.ActiveLayer, False, groups(1))
			batchGroup3.Group(document.ActiveLayer, False, groups(2))

			' add expand-collapse decorator and frame decorator to each group
			i = 0
			Do While i < groups.Length
				Dim group As NGroup = groups(i)

				' because groups are created after the link we want to ensure
				' that they are behind so that the links are not obscured
				group.SendToBack()

				' create the decorators collection
				group.CreateShapeElements(ShapeElementsMask.Decorators)

				' create a frame decorator
				' we want the user to be able to select the shape when the frame is hit
				Dim frameDecorator As NFrameDecorator = New NFrameDecorator()
				frameDecorator.ShapeHitTestable = True
				frameDecorator.Header.Text = "Network " & i.ToString()
				group.Decorators.AddChild(frameDecorator)

				' create an expand collapse decorator
				Dim expandCollapseDecorator As NExpandCollapseDecorator = New NExpandCollapseDecorator()
				group.Decorators.AddChild(expandCollapseDecorator)

				' update the model bounds so that the computeres 
				' are inside the specified padding
				group.Padding = New Nevron.Diagram.NMargins(5, 5, 30, 5)
				group.UpdateModelBounds()
				group.AutoUpdateModelBounds = True
				i += 1
			Loop

			' layout them with a table layout
			Dim context As NLayoutContext = New NLayoutContext()
			context.GraphAdapter = New NShapeGraphAdapter()
			context.BodyAdapter = New NShapeBodyAdapter(document)
			context.BodyContainerAdapter = New NDrawingBodyContainerAdapter(document)

			Dim layout As NTableLayout = New NTableLayout()
			layout.ConstrainMode = CellConstrainMode.Ordinal
			layout.MaxOrdinal = 2
			layout.HorizontalSpacing = 50
			layout.VerticalSpacing = 50
			layout.Layout(document.ActiveLayer.Children(Nothing), context)

			document.SizeToContent(NSizeF.Empty, document.AutoBoundsPadding)
			document.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent
		End Sub
		Private Sub InitFormControls()
			' fill the expand-collapse symbol combo
			SymbolCombo.Items.Clear()
			For Each member As Object In System.Enum.GetValues(GetType(ToggleDecoratorSymbolShape))
				SymbolCombo.Items.Add(member)
			Next member
			SymbolCombo.SelectedItem = ToggleDecoratorSymbolShape.PlusMinus

			' fill the expand-collapse background combo
			BackgroundCombo.Items.Clear()
			For Each member As Object In System.Enum.GetValues(GetType(ToggleDecoratorBackgroundShape))
				BackgroundCombo.Items.Add(member)
			Next member
			BackgroundCombo.SelectedItem = ToggleDecoratorBackgroundShape.Rectangle
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub SymbolCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SymbolCombo.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim shape As ToggleDecoratorSymbolShape = CType(SymbolCombo.SelectedItem, ToggleDecoratorSymbolShape)
			For Each decorator As NExpandCollapseDecorator In document.Descendants(New NInstanceOfTypeFilter(GetType(NExpandCollapseDecorator)), -1)
				decorator.Symbol.Shape = shape
			Next decorator

			document.SmartRefreshAllViews()
		End Sub
		Private Sub BackgroundCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BackgroundCombo.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim shape As ToggleDecoratorBackgroundShape = CType(BackgroundCombo.SelectedItem, ToggleDecoratorBackgroundShape)
			For Each decorator As NExpandCollapseDecorator In document.Descendants(New NInstanceOfTypeFilter(GetType(NExpandCollapseDecorator)), -1)
				decorator.Background.Shape = shape
			Next decorator

			document.SmartRefreshAllViews()
		End Sub
		Private Sub LeftRadio_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LeftRadio.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim shape As ToggleDecoratorSymbolShape = CType(SymbolCombo.SelectedItem, ToggleDecoratorSymbolShape)
			For Each decorator As NExpandCollapseDecorator In document.Descendants(New NInstanceOfTypeFilter(GetType(NExpandCollapseDecorator)), -1)
				If LeftRadio.Checked Then
					decorator.Offset = New NSizeF(11, 11)
					decorator.Alignment = New NContentAlignment(ContentAlignment.TopLeft)
				Else
					decorator.Offset = New NSizeF(-11, 11)
					decorator.Alignment = New NContentAlignment(ContentAlignment.TopRight)
				End If
			Next decorator

			document.SmartRefreshAllViews()
		End Sub
		Private Sub SymbolFillStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SymbolFillStyleButton.Click
			Dim styleSheet As NStyleSheet = CType(document.StyleSheets.GetChildByName(NDR.NameToggleDecoratorSymbolsStyleSheet), NStyleSheet)

			Dim fillStyle As NFillStyle
			If NFillStyleTypeEditor.Edit(styleSheet.Style.FillStyle, fillStyle) Then
				styleSheet.Style.FillStyle = fillStyle
				document.SmartRefreshAllViews()
			End If
		End Sub
		Private Sub SymbolStrokeStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SymbolStrokeStyleButton.Click
			Dim styleSheet As NStyleSheet = CType(document.StyleSheets.GetChildByName(NDR.NameToggleDecoratorSymbolsStyleSheet), NStyleSheet)

			Dim strokeStyle As NStrokeStyle
			If NStrokeStyleTypeEditor.Edit(styleSheet.Style.StrokeStyle, strokeStyle) Then
				styleSheet.Style.StrokeStyle = strokeStyle
				document.SmartRefreshAllViews()
			End If
		End Sub
		Private Sub BackgroundFillStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BackgroundFillStyleButton.Click
			Dim styleSheet As NStyleSheet = CType(document.StyleSheets.GetChildByName(NDR.NameToggleDecoratorBackgroundsStyleSheet), NStyleSheet)

			Dim fillStyle As NFillStyle
			If NFillStyleTypeEditor.Edit(styleSheet.Style.FillStyle, fillStyle) Then
				styleSheet.Style.FillStyle = fillStyle
				document.SmartRefreshAllViews()
			End If
		End Sub
		Private Sub BackgroundStrokeStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BackgroundStrokeStyleButton.Click
			Dim styleSheet As NStyleSheet = CType(document.StyleSheets.GetChildByName(NDR.NameToggleDecoratorBackgroundsStyleSheet), NStyleSheet)

			Dim strokeStyle As NStrokeStyle
			If NStrokeStyleTypeEditor.Edit(styleSheet.Style.StrokeStyle, strokeStyle) Then
				styleSheet.Style.StrokeStyle = strokeStyle
				document.SmartRefreshAllViews()
			End If
		End Sub

		#End Region

		#Region "Designer Fields"

		Private WithEvents SymbolCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents BackgroundCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As Label
		Private label2 As Label
		Private WithEvents LeftRadio As Nevron.UI.WinForm.Controls.NRadioButton
		Private RightRadio As Nevron.UI.WinForm.Controls.NRadioButton
		Private label3 As Label
		Private WithEvents SymbolFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents SymbolStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BackgroundStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BackgroundFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace