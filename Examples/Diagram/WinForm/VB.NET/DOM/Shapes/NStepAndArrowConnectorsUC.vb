Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Editors
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.Templates

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NStepAndArrowConnectorsUC.
	''' </summary>
	Public Class NStepAndArrowConnectorsUC
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
			Me.hvConnectorPropertiesGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.step3ConnectorPropertiesGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.offsetTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.percentTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.offsetRadio = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.percentRadio = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.firstVerticalCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.arrowConnectorPropertiesGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.arrowConnectorTypeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.commonConnectorOperationsGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.reflexButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.reverseButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.hvConnectorPropertiesGroup.SuspendLayout()
			Me.step3ConnectorPropertiesGroup.SuspendLayout()
			Me.arrowConnectorPropertiesGroup.SuspendLayout()
			Me.commonConnectorOperationsGroup.SuspendLayout()
			Me.SuspendLayout()
			' 
			' hvConnectorPropertiesGroup
			' 
			Me.hvConnectorPropertiesGroup.Controls.Add(Me.step3ConnectorPropertiesGroup)
			Me.hvConnectorPropertiesGroup.Controls.Add(Me.firstVerticalCheck)
			Me.hvConnectorPropertiesGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.hvConnectorPropertiesGroup.ImageIndex = 0
			Me.hvConnectorPropertiesGroup.Location = New System.Drawing.Point(0, 0)
			Me.hvConnectorPropertiesGroup.Name = "hvConnectorPropertiesGroup"
			Me.hvConnectorPropertiesGroup.Size = New System.Drawing.Size(248, 136)
			Me.hvConnectorPropertiesGroup.TabIndex = 0
			Me.hvConnectorPropertiesGroup.TabStop = False
			Me.hvConnectorPropertiesGroup.Text = "Selected step connector properties"
			' 
			' step3ConnectorPropertiesGroup
			' 
			Me.step3ConnectorPropertiesGroup.Controls.Add(Me.offsetTextBox)
			Me.step3ConnectorPropertiesGroup.Controls.Add(Me.percentTextBox)
			Me.step3ConnectorPropertiesGroup.Controls.Add(Me.offsetRadio)
			Me.step3ConnectorPropertiesGroup.Controls.Add(Me.percentRadio)
			Me.step3ConnectorPropertiesGroup.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.step3ConnectorPropertiesGroup.ImageIndex = 0
			Me.step3ConnectorPropertiesGroup.Location = New System.Drawing.Point(3, 53)
			Me.step3ConnectorPropertiesGroup.Name = "step3ConnectorPropertiesGroup"
			Me.step3ConnectorPropertiesGroup.Size = New System.Drawing.Size(242, 80)
			Me.step3ConnectorPropertiesGroup.TabIndex = 1
			Me.step3ConnectorPropertiesGroup.TabStop = False
			Me.step3ConnectorPropertiesGroup.Text = "Step 3 connector properties"
			' 
			' offsetTextBox
			' 
			Me.offsetTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.offsetTextBox.ErrorMessage = Nothing
			Me.offsetTextBox.Location = New System.Drawing.Point(80, 42)
			Me.offsetTextBox.Name = "offsetTextBox"
			Me.offsetTextBox.Size = New System.Drawing.Size(152, 20)
			Me.offsetTextBox.TabIndex = 3
			Me.offsetTextBox.Text = "textBox2"
'			Me.offsetTextBox.TextChanged += New System.EventHandler(Me.offsetTextBox_TextChanged);
			' 
			' percentTextBox
			' 
			Me.percentTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.percentTextBox.ErrorMessage = Nothing
			Me.percentTextBox.Location = New System.Drawing.Point(80, 18)
			Me.percentTextBox.Name = "percentTextBox"
			Me.percentTextBox.Size = New System.Drawing.Size(152, 20)
			Me.percentTextBox.TabIndex = 1
			Me.percentTextBox.Text = "textBox1"
'			Me.percentTextBox.TextChanged += New System.EventHandler(Me.percentTextBox_TextChanged);
			' 
			' offsetRadio
			' 
			Me.offsetRadio.Location = New System.Drawing.Point(8, 40)
			Me.offsetRadio.Name = "offsetRadio"
			Me.offsetRadio.Size = New System.Drawing.Size(64, 24)
			Me.offsetRadio.TabIndex = 2
			Me.offsetRadio.Text = "Offset"
'			Me.offsetRadio.CheckedChanged += New System.EventHandler(Me.offsetRadio_CheckedChanged);
			' 
			' percentRadio
			' 
			Me.percentRadio.Location = New System.Drawing.Point(8, 16)
			Me.percentRadio.Name = "percentRadio"
			Me.percentRadio.Size = New System.Drawing.Size(64, 24)
			Me.percentRadio.TabIndex = 0
			Me.percentRadio.Text = "Percent"
'			Me.percentRadio.CheckedChanged += New System.EventHandler(Me.percentRadio_CheckedChanged);
			' 
			' firstVerticalCheck
			' 
			Me.firstVerticalCheck.Location = New System.Drawing.Point(8, 24)
			Me.firstVerticalCheck.Name = "firstVerticalCheck"
			Me.firstVerticalCheck.Size = New System.Drawing.Size(144, 24)
			Me.firstVerticalCheck.TabIndex = 0
			Me.firstVerticalCheck.Text = "First step vertical"
'			Me.firstVerticalCheck.CheckedChanged += New System.EventHandler(Me.firstVerticalCheck_CheckedChanged);
			' 
			' arrowConnectorPropertiesGroup
			' 
			Me.arrowConnectorPropertiesGroup.Controls.Add(Me.arrowConnectorTypeCombo)
			Me.arrowConnectorPropertiesGroup.Controls.Add(Me.label1)
			Me.arrowConnectorPropertiesGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.arrowConnectorPropertiesGroup.ImageIndex = 0
			Me.arrowConnectorPropertiesGroup.Location = New System.Drawing.Point(0, 136)
			Me.arrowConnectorPropertiesGroup.Name = "arrowConnectorPropertiesGroup"
			Me.arrowConnectorPropertiesGroup.Size = New System.Drawing.Size(248, 64)
			Me.arrowConnectorPropertiesGroup.TabIndex = 1
			Me.arrowConnectorPropertiesGroup.TabStop = False
			Me.arrowConnectorPropertiesGroup.Text = "Selected Arrow connector properties"
			' 
			' arrowConnectorTypeCombo
			' 
			Me.arrowConnectorTypeCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.arrowConnectorTypeCombo.Location = New System.Drawing.Point(80, 24)
			Me.arrowConnectorTypeCombo.Name = "arrowConnectorTypeCombo"
			Me.arrowConnectorTypeCombo.Size = New System.Drawing.Size(152, 21)
			Me.arrowConnectorTypeCombo.TabIndex = 1
			Me.arrowConnectorTypeCombo.Text = "comboBox1"
'			Me.arrowConnectorTypeCombo.SelectedIndexChanged += New System.EventHandler(Me.arrowConnectorTypeCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 26)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(48, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Type:"
			' 
			' commonConnectorOperationsGroup
			' 
			Me.commonConnectorOperationsGroup.Controls.Add(Me.reflexButton)
			Me.commonConnectorOperationsGroup.Controls.Add(Me.reverseButton)
			Me.commonConnectorOperationsGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.commonConnectorOperationsGroup.ImageIndex = 0
			Me.commonConnectorOperationsGroup.Location = New System.Drawing.Point(0, 200)
			Me.commonConnectorOperationsGroup.Name = "commonConnectorOperationsGroup"
			Me.commonConnectorOperationsGroup.Size = New System.Drawing.Size(248, 96)
			Me.commonConnectorOperationsGroup.TabIndex = 2
			Me.commonConnectorOperationsGroup.TabStop = False
			Me.commonConnectorOperationsGroup.Text = "Common 1D shapes operations"
			' 
			' reflexButton
			' 
			Me.reflexButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.reflexButton.Location = New System.Drawing.Point(8, 56)
			Me.reflexButton.Name = "reflexButton"
			Me.reflexButton.Size = New System.Drawing.Size(232, 23)
			Me.reflexButton.TabIndex = 1
			Me.reflexButton.Text = "Reflex"
'			Me.reflexButton.Click += New System.EventHandler(Me.reflexButton_Click);
			' 
			' reverseButton
			' 
			Me.reverseButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.reverseButton.Location = New System.Drawing.Point(8, 24)
			Me.reverseButton.Name = "reverseButton"
			Me.reverseButton.Size = New System.Drawing.Size(232, 23)
			Me.reverseButton.TabIndex = 0
			Me.reverseButton.Text = "Reverse"
'			Me.reverseButton.Click += New System.EventHandler(Me.reverseButton_Click);
			' 
			' NStepAndArrowConnectorsUC
			' 
			Me.Controls.Add(Me.commonConnectorOperationsGroup)
			Me.Controls.Add(Me.arrowConnectorPropertiesGroup)
			Me.Controls.Add(Me.hvConnectorPropertiesGroup)
			Me.Name = "NStepAndArrowConnectorsUC"
			Me.Size = New System.Drawing.Size(248, 560)
			Me.Controls.SetChildIndex(Me.hvConnectorPropertiesGroup, 0)
			Me.Controls.SetChildIndex(Me.arrowConnectorPropertiesGroup, 0)
			Me.Controls.SetChildIndex(Me.commonConnectorOperationsGroup, 0)
			Me.hvConnectorPropertiesGroup.ResumeLayout(False)
			Me.step3ConnectorPropertiesGroup.ResumeLayout(False)
			Me.arrowConnectorPropertiesGroup.ResumeLayout(False)
			Me.commonConnectorOperationsGroup.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			view.Grid.Visible = False
			view.Selection.Mode = DiagramSelectionMode.Single
			view.InteractiveAppearance.SelectedStrokeStyle = New NStrokeStyle(2, Color.Blue)
			view.InteractiveAppearance.SelectedFillStyle = New NColorFillStyle(Color.FromArgb(80, Color.Blue))

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub

		Protected Overrides Sub AttachToEvents()
			AddHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_OnNodeSelected
			AddHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_OnNodeDeselected

			MyBase.AttachToEvents()
		End Sub

		Protected Overrides Sub DetachFromEvents()
			RemoveHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_OnNodeSelected
			RemoveHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_OnNodeDeselected

			MyBase.DetachFromEvents()
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			arrowConnectorTypeCombo.FillFromEnum(GetType(ArrowType))
			offsetTextBox.Text = ""
			percentTextBox.Text = ""

			hvConnectorPropertiesGroup.Enabled = False
			arrowConnectorPropertiesGroup.Enabled = False
			commonConnectorOperationsGroup.Enabled = False

			ResumeEventsHandling()
		End Sub

		Private Sub InitDocument()
			document.Style.TextStyle = New NTextStyle(New Font("Arial", 9), Color.Black)

			' modify the connectors style sheet
			Dim styleSheet As NStyleSheet = (TryCast(document.StyleSheets.GetChildByName(NDR.NameConnectorsStyleSheet, -1), NStyleSheet))

			Dim textStyle As NTextStyle = New NTextStyle()
			textStyle.BackplaneStyle.Visible = True
			textStyle.BackplaneStyle.StandardFrameStyle.InnerBorderWidth = New NLength(0)
			styleSheet.Style.TextStyle = textStyle

			styleSheet.Style.StrokeStyle = New NStrokeStyle(1, Color.Black)
			styleSheet.Style.StartArrowheadStyle.StrokeStyle = New NStrokeStyle(1, Color.Black)
			styleSheet.Style.EndArrowheadStyle.StrokeStyle = New NStrokeStyle(1, Color.Black)

			' create a stylesheet for the 2D Shapes
			styleSheet = New NStyleSheet("SHAPE2D")
			styleSheet.Style.FillStyle = New NColorFillStyle(Color.PapayaWhip)
			document.StyleSheets.AddChild(styleSheet)

			' create a stylesheet for the arrows, which inherits from the connectors stylesheet
			styleSheet = New NStyleSheet("ARROW", NDR.NameConnectorsStyleSheet)

			textStyle = New NTextStyle()
			textStyle.FontStyle.InitFromFont(New Font("Arial", 8))
			styleSheet.Style.TextStyle = textStyle

			document.StyleSheets.AddChild(styleSheet)

			' create shapes
			Dim shape1 As NShape = MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(150, 50, 50, 50), "1", "SHAPE2D")

			Dim shape2 As NShape = MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(150, 150, 50, 50), "2", "SHAPE2D")
			Dim shape3 As NShape = MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(325, 150, 50, 50), "3", "SHAPE2D")

			Dim shape4 As NShape = MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(50, 250, 50, 50), "4", "SHAPE2D")
			Dim shape5 As NShape = MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(250, 250, 50, 50), "5", "SHAPE2D")
			Dim shape6 As NShape = MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(400, 250, 50, 50), "6", "SHAPE2D")

			Dim shape7 As NShape = MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(250, 350, 50, 50), "7", "SHAPE2D")
			Dim shape8 As NShape = MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(400, 350, 50, 50), "8", "SHAPE2D")

			' create connectors
			Dim line As NLineShape = New NLineShape()
			line.StyleSheetName = NDR.NameConnectorsStyleSheet
			line.Text = "Line"
			document.ActiveLayer.AddChild(line)
			line.StartPlug.Connect(TryCast(shape1.Ports.GetChildByName("Bottom", 0), NPort))
			line.EndPlug.Connect(TryCast(shape2.Ports.GetChildByName("Top", 0), NPort))

			Dim hv As NStep2Connector = New NStep2Connector(False)
			hv.StyleSheetName = NDR.NameConnectorsStyleSheet
			hv.Text = "HV"
			document.ActiveLayer.AddChild(hv)
			hv.StartPlug.Connect(TryCast(shape1.Ports.GetChildByName("Right", 0), NPort))
			hv.EndPlug.Connect(TryCast(shape3.Ports.GetChildByName("Top", 0), NPort))

			Dim vh As NStep2Connector = New NStep2Connector(True)
			vh.StyleSheetName = NDR.NameConnectorsStyleSheet
			vh.Text = "VH"
			document.ActiveLayer.AddChild(vh)
			vh.StartPlug.Connect(TryCast(shape4.Ports.GetChildByName("Bottom", 0), NPort))
			vh.EndPlug.Connect(TryCast(shape7.Ports.GetChildByName("Left", 0), NPort))

			Dim vhv As NStep3Connector = New NStep3Connector(True, 50, 0, True)
			vhv.StyleSheetName = NDR.NameConnectorsStyleSheet
			vhv.Text = "VHV"
			document.ActiveLayer.AddChild(vhv)
			vhv.StartPlug.Connect(TryCast(shape2.Ports.GetChildByName("Bottom", 0), NPort))
			vhv.EndPlug.Connect(TryCast(shape4.Ports.GetChildByName("Top", 0), NPort))

			Dim hvh As NStep3Connector = New NStep3Connector(False, 50, 0, True)
			hvh.StyleSheetName = NDR.NameConnectorsStyleSheet
			hvh.Text = "HVH"
			document.ActiveLayer.AddChild(hvh)
			hvh.StartPlug.Connect(TryCast(shape2.Ports.GetChildByName("Right", 0), NPort))
			hvh.EndPlug.Connect(TryCast(shape5.Ports.GetChildByName("Left", 0), NPort))

			Dim doubleArrow As NArrowShape = New NArrowShape(ArrowType.DoubleArrow, New NPointF(0, 0), New NPointF(1, 1), 10, 45, 30)
			doubleArrow.StyleSheetName = "ARROW"
			doubleArrow.Text = "Double Arrow"
			document.ActiveLayer.AddChild(doubleArrow)
			doubleArrow.StartPlug.Connect(TryCast(shape5.Ports.GetChildByName("Right", 0), NPort))
			doubleArrow.EndPlug.Connect(TryCast(shape6.Ports.GetChildByName("Left", 0), NPort))

			Dim singleArrow As NArrowShape = New NArrowShape(ArrowType.SingleArrow, New NPointF(0, 0), New NPointF(1, 1), 10, 45, 30)
			singleArrow.StyleSheetName = "ARROW"
			singleArrow.Text = "Single Arrow"
			document.ActiveLayer.AddChild(singleArrow)
			singleArrow.StartPlug.Connect(TryCast(shape7.Ports.GetChildByName("Right", 0), NPort))
			singleArrow.EndPlug.Connect(TryCast(shape8.Ports.GetChildByName("Left", 0), NPort))

			Dim bezier As NBezierCurveShape = New NBezierCurveShape()
			bezier.StyleSheetName = NDR.NameConnectorsStyleSheet
			bezier.Text = "Bezier"
			bezier.StartPlug.Connect(TryCast(shape6.Ports.GetChildByName("Right", 0), NPort))
			bezier.EndPlug.Connect(TryCast(shape6.Ports.GetChildByName("Top", 0), NPort))
			bezier.Reflex()
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub EventSinkService_OnNodeSelected(ByVal args As NNodeEventArgs)
			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))

			If shape Is Nothing Then
				commonConnectorOperationsGroup.Enabled = False
				hvConnectorPropertiesGroup.Enabled = False
				arrowConnectorPropertiesGroup.Enabled = False
				Return
			End If

			PauseEventsHandling()

			' common group
			If shape.ShapeType = ShapeType.Shape1D Then
				commonConnectorOperationsGroup.Enabled = True
				reflexButton.Enabled = (TypeOf shape Is INReflexiveShape)
			Else
				commonConnectorOperationsGroup.Enabled = False
			End If

			' step connectors group
			If TypeOf shape Is NStepConnector Then
				hvConnectorPropertiesGroup.Enabled = True
				firstVerticalCheck.Checked = (TryCast(shape, NStepConnector)).FirstVertical

				If TypeOf shape Is NStep3Connector Then
					Dim step3Connector As NStep3Connector = (TryCast(shape, NStep3Connector))
					step3ConnectorPropertiesGroup.Enabled = True

					percentRadio.Checked = step3Connector.UseMiddleControlPointPercent
					percentTextBox.Text = step3Connector.MiddleControlPointPercent.ToString()
					offsetTextBox.Text = step3Connector.MiddleControlPointOffset.ToString()
				Else
					step3ConnectorPropertiesGroup.Enabled = False
				End If
			Else
				hvConnectorPropertiesGroup.Enabled = False
			End If

			' arrow group
			If TypeOf shape Is NArrowShape Then
				arrowConnectorPropertiesGroup.Enabled = True
				arrowConnectorTypeCombo.SelectedIndex = CInt(Fix((TryCast(shape, NArrowShape)).ArrowType))
			Else
				arrowConnectorPropertiesGroup.Enabled = False
			End If

			ResumeEventsHandling()
		End Sub

		Private Sub EventSinkService_OnNodeDeselected(ByVal args As NNodeEventArgs)
			hvConnectorPropertiesGroup.Enabled = False
			arrowConnectorPropertiesGroup.Enabled = False
			commonConnectorOperationsGroup.Enabled = False
		End Sub


		Private Sub firstVerticalCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles firstVerticalCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim connector As NStepConnector = (TryCast(view.Selection.AnchorNode, NStepConnector))
			If connector Is Nothing Then
				Return
			End If

			connector.FirstVertical = firstVerticalCheck.Checked
			document.SmartRefreshAllViews()
		End Sub

		Private Sub percentRadio_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles percentRadio.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim connector As NStep3Connector = (TryCast(view.Selection.AnchorNode, NStep3Connector))
			If connector Is Nothing Then
				Return
			End If

			connector.UseMiddleControlPointPercent = percentRadio.Checked
			document.SmartRefreshAllViews()
		End Sub

		Private Sub percentTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles percentTextBox.TextChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim connector As NStep3Connector = (TryCast(view.Selection.AnchorNode, NStep3Connector))
			If connector Is Nothing Then
				Return
			End If

			Dim percent As Single = 0
			Try
				percent = Single.Parse(percentTextBox.Text)
			Catch
				Return
			End Try

			connector.MiddleControlPointPercent = percent
			document.SmartRefreshAllViews()
		End Sub

		Private Sub offsetRadio_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles offsetRadio.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim connector As NStep3Connector = (TryCast(view.Selection.AnchorNode, NStep3Connector))
			If connector Is Nothing Then
				Return
			End If

			connector.UseMiddleControlPointPercent = Not offsetRadio.Checked
			document.SmartRefreshAllViews()
		End Sub

		Private Sub offsetTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles offsetTextBox.TextChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim connector As NStep3Connector = (TryCast(view.Selection.AnchorNode, NStep3Connector))
			If connector Is Nothing Then
				Return
			End If

			Dim offset As Single = 0
			Try
				offset = Single.Parse(offsetTextBox.Text)
			Catch
				Return
			End Try

			connector.MiddleControlPointOffset = offset
			document.SmartRefreshAllViews()
		End Sub

		Private Sub arrowConnectorTypeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles arrowConnectorTypeCombo.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim connector As NArrowShape = (TryCast(view.Selection.AnchorNode, NArrowShape))
			If connector Is Nothing Then
				Return
			End If

			connector.ArrowType = CType(arrowConnectorTypeCombo.SelectedIndex, ArrowType)
			document.SmartRefreshAllViews()
		End Sub

		Private Sub reverseButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles reverseButton.Click
			If EventsHandlingPaused Then
				Return
			End If

			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
			If shape Is Nothing OrElse shape.ShapeType <> ShapeType.Shape1D Then
				Return
			End If

			shape.Reverse()
			document.SmartRefreshAllViews()
		End Sub

		Private Sub reflexButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles reflexButton.Click
			If EventsHandlingPaused Then
				Return
			End If

			Dim reflexiveShape As INReflexiveShape = (TryCast(view.Selection.AnchorNode, INReflexiveShape))
			If reflexiveShape Is Nothing Then
				Return
			End If

			reflexiveShape.Reflex()
			document.SmartRefreshAllViews()
		End Sub


		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private hvConnectorPropertiesGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private arrowConnectorPropertiesGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private commonConnectorOperationsGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents reverseButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents reflexButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents firstVerticalCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private step3ConnectorPropertiesGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents percentRadio As Nevron.UI.WinForm.Controls.NRadioButton
		Private WithEvents offsetRadio As Nevron.UI.WinForm.Controls.NRadioButton
		Private WithEvents percentTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents offsetTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents arrowConnectorTypeCombo As Nevron.UI.WinForm.Controls.NComboBox

		#End Region
	End Class
End Namespace