Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WinForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NRoutableConnectorsUC.
	''' </summary>
	Public Class NRoutableConnectorsUC
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
			Me.obstacleTypeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.obstacleGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.routeGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.rerouteButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.routeModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.reverseButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.routeTypeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.managerGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.routingMeshTypeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.routingGridTypeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.managerEnabledCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.obstacleGroup.SuspendLayout()
			Me.routeGroup.SuspendLayout()
			Me.managerGroup.SuspendLayout()
			Me.SuspendLayout()
			' 
			' obstacleTypeCombo
			' 
			Me.obstacleTypeCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.obstacleTypeCombo.Location = New System.Drawing.Point(104, 24)
			Me.obstacleTypeCombo.Name = "obstacleTypeCombo"
			Me.obstacleTypeCombo.Size = New System.Drawing.Size(136, 21)
			Me.obstacleTypeCombo.TabIndex = 1
'			Me.obstacleTypeCombo.SelectedIndexChanged += New System.EventHandler(Me.obstacleTypeCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 26)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(80, 16)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Obstacle type:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' obstacleGroup
			' 
			Me.obstacleGroup.Controls.Add(Me.obstacleTypeCombo)
			Me.obstacleGroup.Controls.Add(Me.label2)
			Me.obstacleGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.obstacleGroup.ImageIndex = 0
			Me.obstacleGroup.Location = New System.Drawing.Point(0, 0)
			Me.obstacleGroup.Name = "obstacleGroup"
			Me.obstacleGroup.Size = New System.Drawing.Size(250, 56)
			Me.obstacleGroup.TabIndex = 0
			Me.obstacleGroup.TabStop = False
			Me.obstacleGroup.Text = "2D shape obstacle properties"
			' 
			' routeGroup
			' 
			Me.routeGroup.Controls.Add(Me.rerouteButton)
			Me.routeGroup.Controls.Add(Me.routeModeCombo)
			Me.routeGroup.Controls.Add(Me.label3)
			Me.routeGroup.Controls.Add(Me.reverseButton)
			Me.routeGroup.Controls.Add(Me.routeTypeCombo)
			Me.routeGroup.Controls.Add(Me.label1)
			Me.routeGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.routeGroup.ImageIndex = 0
			Me.routeGroup.Location = New System.Drawing.Point(0, 56)
			Me.routeGroup.Name = "routeGroup"
			Me.routeGroup.Size = New System.Drawing.Size(250, 152)
			Me.routeGroup.TabIndex = 1
			Me.routeGroup.TabStop = False
			Me.routeGroup.Text = "Routable connector properties"
			' 
			' rerouteButton
			' 
			Me.rerouteButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.rerouteButton.Location = New System.Drawing.Point(8, 112)
			Me.rerouteButton.Name = "rerouteButton"
			Me.rerouteButton.Size = New System.Drawing.Size(232, 23)
			Me.rerouteButton.TabIndex = 5
			Me.rerouteButton.Text = "Reroute"
'			Me.rerouteButton.Click += New System.EventHandler(Me.rerouteButton_Click);
			' 
			' routeModeCombo
			' 
			Me.routeModeCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.routeModeCombo.Location = New System.Drawing.Point(104, 48)
			Me.routeModeCombo.Name = "routeModeCombo"
			Me.routeModeCombo.Size = New System.Drawing.Size(136, 21)
			Me.routeModeCombo.TabIndex = 3
'			Me.routeModeCombo.SelectedIndexChanged += New System.EventHandler(Me.routeModeCombo_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 50)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(104, 16)
			Me.label3.TabIndex = 2
			Me.label3.Text = "Auto reroute:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' reverseButton
			' 
			Me.reverseButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.reverseButton.Location = New System.Drawing.Point(8, 80)
			Me.reverseButton.Name = "reverseButton"
			Me.reverseButton.Size = New System.Drawing.Size(232, 23)
			Me.reverseButton.TabIndex = 4
			Me.reverseButton.Text = "Reverse"
'			Me.reverseButton.Click += New System.EventHandler(Me.reverseButton_Click);
			' 
			' routeTypeCombo
			' 
			Me.routeTypeCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.routeTypeCombo.Location = New System.Drawing.Point(104, 16)
			Me.routeTypeCombo.Name = "routeTypeCombo"
			Me.routeTypeCombo.Size = New System.Drawing.Size(136, 21)
			Me.routeTypeCombo.TabIndex = 1
'			Me.routeTypeCombo.SelectedIndexChanged += New System.EventHandler(Me.routeTypeCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 18)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(80, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Type:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' managerGroup
			' 
			Me.managerGroup.Controls.Add(Me.routingMeshTypeCombo)
			Me.managerGroup.Controls.Add(Me.label6)
			Me.managerGroup.Controls.Add(Me.routingGridTypeCombo)
			Me.managerGroup.Controls.Add(Me.label4)
			Me.managerGroup.Controls.Add(Me.managerEnabledCheck)
			Me.managerGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.managerGroup.ImageIndex = 0
			Me.managerGroup.Location = New System.Drawing.Point(0, 208)
			Me.managerGroup.Name = "managerGroup"
			Me.managerGroup.Size = New System.Drawing.Size(250, 112)
			Me.managerGroup.TabIndex = 2
			Me.managerGroup.TabStop = False
			Me.managerGroup.Text = "Routing Manager"
			' 
			' routingMeshTypeCombo
			' 
			Me.routingMeshTypeCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.routingMeshTypeCombo.Location = New System.Drawing.Point(104, 80)
			Me.routingMeshTypeCombo.Name = "routingMeshTypeCombo"
			Me.routingMeshTypeCombo.Size = New System.Drawing.Size(136, 21)
			Me.routingMeshTypeCombo.TabIndex = 5
'			Me.routingMeshTypeCombo.SelectedIndexChanged += New System.EventHandler(Me.routingMeshTypeCombo_SelectedIndexChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(8, 82)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(80, 16)
			Me.label6.TabIndex = 4
			Me.label6.Text = "Mesh type:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' routingGridTypeCombo
			' 
			Me.routingGridTypeCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.routingGridTypeCombo.Location = New System.Drawing.Point(104, 48)
			Me.routingGridTypeCombo.Name = "routingGridTypeCombo"
			Me.routingGridTypeCombo.Size = New System.Drawing.Size(136, 21)
			Me.routingGridTypeCombo.TabIndex = 3
'			Me.routingGridTypeCombo.SelectedIndexChanged += New System.EventHandler(Me.routingGridTypeCombo_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 50)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(80, 16)
			Me.label4.TabIndex = 2
			Me.label4.Text = "Grid type:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' managerEnabledCheck
			' 
			Me.managerEnabledCheck.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.managerEnabledCheck.Location = New System.Drawing.Point(8, 16)
			Me.managerEnabledCheck.Name = "managerEnabledCheck"
			Me.managerEnabledCheck.Size = New System.Drawing.Size(136, 21)
			Me.managerEnabledCheck.TabIndex = 1
			Me.managerEnabledCheck.Text = "Enabled"
'			Me.managerEnabledCheck.CheckedChanged += New System.EventHandler(Me.managerEnabledCheck_CheckedChanged);
			' 
			' NRoutableConnectorsUC
			' 
			Me.Controls.Add(Me.managerGroup)
			Me.Controls.Add(Me.routeGroup)
			Me.Controls.Add(Me.obstacleGroup)
			Me.Name = "NRoutableConnectorsUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.obstacleGroup, 0)
			Me.Controls.SetChildIndex(Me.routeGroup, 0)
			Me.Controls.SetChildIndex(Me.managerGroup, 0)
			Me.obstacleGroup.ResumeLayout(False)
			Me.routeGroup.ResumeLayout(False)
			Me.managerGroup.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			view.Grid.Visible = False
			view.Selection.Mode = DiagramSelectionMode.Single
			view.ViewLayout = ViewLayout.Fit
			view.GlobalVisibility.ShowPorts = False

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
			AddHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_NodeSelected
			AddHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_NodeDeselected

			MyBase.AttachToEvents()
		End Sub

		Protected Overrides Sub DetachFromEvents()
			RemoveHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_NodeSelected
			RemoveHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_NodeDeselected

			MyBase.DetachFromEvents()
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			obstacleGroup.Visible = False
			routeGroup.Visible = False

			obstacleTypeCombo.FillFromEnum(GetType(RouteObstacleType))
			obstacleTypeCombo.SelectedIndex = 0

			routeModeCombo.FillFromEnum(GetType(RerouteAutomatically))
			routeModeCombo.SelectedIndex = 0

			routeTypeCombo.FillFromEnum(GetType(RoutableConnectorType))
			routeTypeCombo.SelectedIndex = 0

			managerEnabledCheck.Checked = document.RoutingManager.Enabled

			routingGridTypeCombo.FillFromEnum(GetType(RoutingGridType))
			routingGridTypeCombo.SelectedIndex = CInt(Fix(document.RoutingManager.RoutingGridType))

			routingMeshTypeCombo.FillFromEnum(GetType(RoutingMeshType))
			routingMeshTypeCombo.SelectedIndex = CInt(Fix(document.RoutingManager.RoutingMeshType))

			ResumeEventsHandling()
		End Sub

		Private Sub InitDocument()
			' create a stylesheet for the first type of bricks
			Dim styleSheet As NStyleSheet = New NStyleSheet("BRICK1")
			styleSheet.Style.FillStyle = New NHatchFillStyle(HatchStyle.HorizontalBrick, Color.DarkOrange, Color.Gold)
			document.StyleSheets.AddChild(styleSheet)

			' create a stylesheet for the second type of bricks
			styleSheet = New NStyleSheet("BRICK2")
			styleSheet.Style.FillStyle = New NHatchFillStyle(HatchStyle.HorizontalBrick, Color.DarkRed, Color.Gold)
			document.StyleSheets.AddChild(styleSheet)

			' create a stylesheet for the start shapes
			styleSheet = New NStyleSheet("START")
			styleSheet.Style.FillStyle = New NColorFillStyle(Color.Red)
			document.StyleSheets.AddChild(styleSheet)

			' create a stylesheet for the end shapes
			styleSheet = New NStyleSheet("END")
			styleSheet.Style.FillStyle = New NColorFillStyle(Color.Green)
			document.StyleSheets.AddChild(styleSheet)

			' create the maze frame
			MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(50, 0, 700, 50), "", "BRICK1")
			MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(750, 0, 50, 800), "", "BRICK1")
			MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(50, 750, 700, 50), "", "BRICK1")
			MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(0, 0, 50, 800), "", "BRICK1")

			' create the maze obstacles
			MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(100, 200, 200, 50), "", "BRICK2")
			MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(300, 50, 50, 200), "", "BRICK2")
			MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(450, 50, 50, 200), "", "BRICK2")
			MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(500, 200, 200, 50), "", "BRICK2")

			MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(50, 300, 250, 50), "", "BRICK2")
			MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(500, 300, 250, 50), "", "BRICK2")

			MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(350, 350, 100, 100), "", "BRICK2")

			MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(50, 450, 250, 50), "", "BRICK2")
			MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(500, 450, 250, 50), "", "BRICK2")

			MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(100, 550, 200, 50), "", "BRICK2")
			MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(300, 550, 50, 200), "", "BRICK2")
			MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(450, 550, 50, 200), "", "BRICK2")
			MyBase.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(500, 550, 200, 50), "", "BRICK2")

			' create the first set of start/end shapes
			Dim start As NShape = MyBase.CreateBasicShape(BasicShapes.Ellipse, New NRectangleF(100, 100, 50, 50), "", "START")
			Dim [end] As NShape = MyBase.CreateBasicShape(BasicShapes.Ellipse, New NRectangleF(650, 650, 50, 50), "", "END")

			' connect them with a dynamic HV routable connector, 
			' which is rerouted whenever the obstacles have changed
			Dim routableConnector As NRoutableConnector = New NRoutableConnector(RoutableConnectorType.DynamicHV, RerouteAutomatically.Always)
			routableConnector.StyleSheetName = NDR.NameConnectorsStyleSheet
			routableConnector.Style.StrokeStyle = New NStrokeStyle(3, Color.Blue)
			document.ActiveLayer.AddChild(routableConnector)

			routableConnector.FromShape = start
			routableConnector.ToShape = [end]
			routableConnector.Reroute()

			' create the second set of start/end shapes 
			start = MyBase.CreateBasicShape(BasicShapes.Ellipse, New NRectangleF(600, 100, 50, 50), "", "END")
			[end] = MyBase.CreateBasicShape(BasicShapes.Ellipse, New NRectangleF(100, 650, 50, 50), "", "END")

			' connect them with a dynamic Polyline routable connector, 
			' which is rerouted whenever the obstacles have changed
			routableConnector = New NRoutableConnector(RoutableConnectorType.DynamicPolyline, RerouteAutomatically.Always)
			routableConnector.StyleSheetName = NDR.NameConnectorsStyleSheet
			routableConnector.Style.StrokeStyle = New NStrokeStyle(3, Color.Magenta)
			document.ActiveLayer.AddChild(routableConnector)

			routableConnector.FromShape = start
			routableConnector.ToShape = [end]
			routableConnector.Reroute()

			' size document to fit the maze
			document.SizeToContent()
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub EventSinkService_NodeSelected(ByVal args As NNodeEventArgs)
			PauseEventsHandling()

			If TypeOf view.Selection.AnchorNode Is NRoutableConnector Then
				obstacleGroup.Visible = False
				routeGroup.Visible = True

				Dim routableConnector As NRoutableConnector = (TryCast(view.Selection.AnchorNode, NRoutableConnector))
				routeTypeCombo.SelectedIndex = CInt(Fix(routableConnector.ConnectorType))
				routeModeCombo.SelectedIndex = CInt(Fix(routableConnector.RerouteAutomatically))
			ElseIf NFilters.Shape2D.Filter(view.Selection.AnchorNode) Then
				obstacleGroup.Visible = True
				routeGroup.Visible = False

				Dim obstacle As NShape = (TryCast(view.Selection.AnchorNode, NShape))
				obstacleTypeCombo.SelectedIndex = CInt(Fix(obstacle.RouteObstacleType))
			Else
				obstacleGroup.Visible = False
				routeGroup.Visible = False
			End If

			ResumeEventsHandling()
		End Sub

		Private Sub EventSinkService_NodeDeselected(ByVal args As NNodeEventArgs)
			obstacleGroup.Visible = False
			routeGroup.Visible = False
		End Sub

		Private Sub obstacleTypeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles obstacleTypeCombo.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
			If shape Is Nothing OrElse shape.ShapeType <> ShapeType.Shape1D Then
				Return
			End If

			shape.RouteObstacleType = CType(obstacleTypeCombo.SelectedIndex, RouteObstacleType)
		End Sub

		Private Sub routeTypeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles routeTypeCombo.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim connector As NRoutableConnector = (TryCast(view.Selection.AnchorNode, NRoutableConnector))
			If connector Is Nothing Then
				Return
			End If

			connector.ConnectorType = CType(routeTypeCombo.SelectedIndex, RoutableConnectorType)
		End Sub

		Private Sub routeModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles routeModeCombo.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim connector As NRoutableConnector = (TryCast(view.Selection.AnchorNode, NRoutableConnector))
			If connector Is Nothing Then
				Return
			End If

			connector.RerouteAutomatically = CType(routeModeCombo.SelectedIndex, RerouteAutomatically)
		End Sub

		Private Sub reverseButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles reverseButton.Click
			If EventsHandlingPaused Then
				Return
			End If

			Dim connector As NRoutableConnector = (TryCast(view.Selection.AnchorNode, NRoutableConnector))
			If connector Is Nothing Then
				Return
			End If

			connector.Reverse()
			document.SmartRefreshAllViews()
		End Sub

		Private Sub rerouteButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rerouteButton.Click
			If EventsHandlingPaused Then
				Return
			End If

			Dim connector As NRoutableConnector = (TryCast(view.Selection.AnchorNode, NRoutableConnector))
			If connector Is Nothing Then
				Return
			End If

			connector.Reroute()
			document.SmartRefreshAllViews()
		End Sub

		Private Sub managerEnabledCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles managerEnabledCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			document.RoutingManager.Enabled = managerEnabledCheck.Checked
		End Sub

		Private Sub routingGridTypeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles routingGridTypeCombo.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			document.RoutingManager.RoutingGridType = CType(routingGridTypeCombo.SelectedIndex, RoutingGridType)
		End Sub

		Private Sub routingMeshTypeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles routingMeshTypeCombo.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			document.RoutingManager.RoutingMeshType = CType(routingMeshTypeCombo.SelectedIndex, RoutingMeshType)
		End Sub


		#End Region

		#Region "Designer Fields"

		Private label2 As System.Windows.Forms.Label
		Private WithEvents obstacleTypeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private obstacleGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private routeGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents reverseButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents routeTypeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private WithEvents routeModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private managerGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents routingGridTypeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label4 As System.Windows.Forms.Label
		Private WithEvents managerEnabledCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private label6 As System.Windows.Forms.Label
		Private WithEvents routingMeshTypeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents rerouteButton As Nevron.UI.WinForm.Controls.NButton

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace