Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.Extensions
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NSimpleNetworkUC.
	''' </summary>
	Public Class NSimpleNetworkUC
		Inherits NDiagramExampleUC
		#Region "Constructors"

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
			Me.btnGenerateSwf = New Nevron.UI.WinForm.Controls.NButton()
			Me.btnGenerateXaml = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' btnGenerateSwf
			' 
			Me.btnGenerateSwf.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnGenerateSwf.Location = New System.Drawing.Point(8, 51)
			Me.btnGenerateSwf.Name = "btnGenerateSwf"
			Me.btnGenerateSwf.Size = New System.Drawing.Size(232, 23)
			Me.btnGenerateSwf.TabIndex = 4
			Me.btnGenerateSwf.Text = "Generate SWF"
			Me.btnGenerateSwf.UseVisualStyleBackColor = True
'			Me.btnGenerateSwf.Click += New System.EventHandler(Me.btnGenrateSwf_Click);
			' 
			' btnGenerateXaml
			' 
			Me.btnGenerateXaml.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnGenerateXaml.Location = New System.Drawing.Point(8, 20)
			Me.btnGenerateXaml.Name = "btnGenerateXaml"
			Me.btnGenerateXaml.Size = New System.Drawing.Size(232, 23)
			Me.btnGenerateXaml.TabIndex = 5
			Me.btnGenerateXaml.Text = "Generate XAML"
			Me.btnGenerateXaml.UseVisualStyleBackColor = True
'			Me.btnGenerateXaml.Click += New System.EventHandler(Me.btnGenerateXaml_Click);
			' 
			' NSimpleNetworkUC
			' 
			Me.Controls.Add(Me.btnGenerateXaml)
			Me.Controls.Add(Me.btnGenerateSwf)
			Me.Name = "NSimpleNetworkUC"
			Me.Size = New System.Drawing.Size(248, 160)
			Me.Controls.SetChildIndex(Me.btnGenerateSwf, 0)
			Me.Controls.SetChildIndex(Me.btnGenerateXaml, 0)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' end view init
			view.EndInit()
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			document.Style.TextStyle.FontStyle.InitFromFont(New Font("Arial Narrow", 8))

			Dim factory As NNetworkShapesFactory = New NNetworkShapesFactory(document)
			factory.DefaultSize = New NSizeF(240, 180)

			Dim server As NShape = factory.CreateShape(NetworkShapes.Server)
			Dim computer As NShape = factory.CreateShape(NetworkShapes.Computer)
			Dim laptop As NShape = factory.CreateShape(NetworkShapes.Laptop)

			document.ActiveLayer.AddChild(server)
			document.ActiveLayer.AddChild(computer)
			document.ActiveLayer.AddChild(laptop)

			Dim link1 As NRoutableConnector = New NRoutableConnector()
			document.ActiveLayer.AddChild(link1)
			link1.FromShape = server
			link1.ToShape = computer

			Dim link2 As NRoutableConnector = New NRoutableConnector()
			document.ActiveLayer.AddChild(link2)
			link2.FromShape = server
			link2.ToShape = laptop

			' layout the shapes in the active layer using a table layout
			Dim layout As NLayeredGraphLayout = New NLayeredGraphLayout()

			' get the shapes to layout
			Dim shapes As NNodeList = document.ActiveLayer.Children(NFilters.Shape2D)

			' layout the shapes
			layout.Layout(shapes, New NDrawingLayoutContext(document))

			' resize document to fit all shapes
			document.SizeToContent()

			' add the data shape
			Const shapeSize As Single = 10
			Dim data As NEllipseShape = New NEllipseShape(link2.EndPoint.X - shapeSize / 2, link2.EndPoint.Y - shapeSize, shapeSize, shapeSize)
			document.ActiveLayer.AddChild(data)
			NStyle.SetStrokeStyle(data, New NStrokeStyle(0, KnownArgbColorValue.Transparent))
			NStyle.SetFillStyle(data, New NColorFillStyle(KnownArgbColorValue.Red))

			' set the animations style
			SetAnimationsStyle(data, link1, link2)
		End Sub
		Private Sub SetAnimationsStyle(ByVal data As NShape, ByVal link1 As NRoutableConnector, ByVal link2 As NRoutableConnector)
			Dim pathAnimator As NPathAnimator = New NPathAnimator(data)
			pathAnimator.Animate(link1.Points, True)
			pathAnimator.SetPause(link1.StartPoint, 1)
			pathAnimator.SetPause(link2.StartPoint, 1)

			Dim points As NPointF() = link2.Points
			points(points.Length - 1) = data.PinPoint
			pathAnimator.Animate(points, False)
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub btnGenrateSwf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerateSwf.Click
			Dim flashExporter As NFlashExporter = New NFlashExporter(document)
			Dim fileName As String = Path.Combine(Application.StartupPath, "test.swf")
			flashExporter.SaveToFile(fileName)
			Process.Start(fileName)
		End Sub
		Private Sub btnGenerateXaml_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerateXaml.Click
			Dim flashExporter As NXamlExporter = New NXamlExporter(document)
			Dim fileName As String = Path.Combine(Application.StartupPath, "test.xaml")
			flashExporter.SaveToFile(fileName)
			Process.Start(fileName)
		End Sub

		#End Region

		#Region "Designer Fields"

		Private WithEvents btnGenerateSwf As NButton
		Private WithEvents btnGenerateXaml As NButton

		#End Region

		#Region "Nested Types"

		Private Class NPathAnimator
			#Region "Constructors"

			Public Sub New(ByVal shape As NShape)
				m_Shape = shape
				m_CurrentTime = 0
				m_Speed = 50
			End Sub

			#End Region

			#Region "Properties"

			''' <summary>
			''' The distance in pixels which the animated shape passes for 1 second.
			''' </summary>
			Public Property Speed() As Single
				Get
					Return m_Speed
				End Get
				Set
					m_Speed = Value
				End Set
			End Property

			#End Region

			#Region "Public Methods"

			Public Sub Animate(ByVal path As IList(Of NPointF))
				Animate(path, False)
			End Sub
			Public Sub Animate(ByVal path As IList(Of NPointF), ByVal reversed As Boolean)
				Dim pinOffset As NPointF = m_Shape.PinPoint - m_Shape.Location
				Dim points As NPointFList = New NPointFList(path)
				If reversed Then
					points.Reverse()
				End If

				Dim i As Integer, count As Integer = points.Count - 1
				i = 0
				Do While i < count
					' Determine the start and end point
					Dim p1 As NPointF = points(i) - pinOffset
					Dim p2 As NPointF = points(i + 1) - pinOffset

					' Create the animation
					Dim distance As Single = p1.Distance(p2)
					Dim duration As Single = distance / m_Speed

					Dim move As NTranslateAnimation = New NTranslateAnimation(m_CurrentTime, duration)
					move.StartOffset = p1 - m_Shape.Location
					move.EndOffset = p2 - m_Shape.Location

					If m_Shape.Style.AnimationsStyle Is Nothing Then
						m_Shape.Style.AnimationsStyle = New NAnimationsStyle()
					End If

					m_Shape.Style.AnimationsStyle.Animations.Add(move)
					m_CurrentTime += duration
					i += 1
				Loop
			End Sub

			Public Sub SetPause(ByVal location As NPointF, ByVal duration As Single)
				Dim move As NTranslateAnimation = New NTranslateAnimation(m_CurrentTime, duration)

				move.EndOffset = location - m_Shape.PinPoint
				move.StartOffset = location - m_Shape.PinPoint

				If m_Shape.Style.AnimationsStyle Is Nothing Then
					m_Shape.Style.AnimationsStyle = New NAnimationsStyle()
				End If

				m_Shape.Style.AnimationsStyle.Animations.Add(move)
				m_CurrentTime += duration
			End Sub

			#End Region

			#Region "Fields"

			Private m_Shape As NShape
			Private m_CurrentTime As Single
			Private m_Speed As Single

			#End Region
		End Class

		#End Region

	End Class
End Namespace