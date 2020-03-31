Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.WebForm
Imports Nevron.Diagram.Shapes
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls
Imports Nevron.Diagram.Filters

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	''' Summary description for NSimpleNetworkRenderPage.
	''' </summary>
	Public Partial Class NSimpleNetworkRenderPage
		Inherits NDrawingViewHostPage
		#Region "Constructors"

		''' <summary>
		''' Default constructor.
		''' </summary>
		Public Sub New()
			DrawingView = New NDrawingView()
			DrawingView.ViewLayout = CanvasLayout.Stretch

			Dim swfResponse As NImageResponse = New NImageResponse()
			swfResponse.ImageFormat = New NSwfImageFormat()
			swfResponse.StreamImageToBrowser = True
			DrawingView.ServerSettings.BrowserResponseSettings.DefaultResponse = swfResponse

			' init document
			Dim document As NDrawingDocument = Me.DrawingView.Document
			document.BeginInit()
			CreateScene(document)
			document.EndInit()

			Me.DrawingView.SizeToContent()
		End Sub

		#End Region

		#Region "Private Methods"

		Private Sub CreateScene(ByVal document As NDrawingDocument)
			document.BackgroundStyle.FrameStyle.Visible = False
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

			' resize document to fit all shapes
			document.SizeToContent()
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
				move.StartOffset = move.EndOffset

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