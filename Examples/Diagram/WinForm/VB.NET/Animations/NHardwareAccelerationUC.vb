Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Globalization

Imports Nevron.Diagram
Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports System.Collections.Generic

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NHardwareAccelerationUC.
	''' </summary>
	Public Class NHardwareAccelerationUC
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
			Me.lblFps = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.RenderTechnologyComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.ShapeCountComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' lblFps
			' 
			Me.lblFps.Location = New System.Drawing.Point(5, 11)
			Me.lblFps.Name = "lblFps"
			Me.lblFps.Size = New System.Drawing.Size(235, 23)
			Me.lblFps.TabIndex = 1
			Me.lblFps.Text = "FPS:"
			Me.lblFps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(8, 69)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(104, 13)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Render Technology:"
			' 
			' RenderTechnologyComboBox
			' 
			Me.RenderTechnologyComboBox.ListProperties.CheckBoxDataMember = ""
			Me.RenderTechnologyComboBox.ListProperties.DataSource = Nothing
			Me.RenderTechnologyComboBox.ListProperties.DisplayMember = ""
			Me.RenderTechnologyComboBox.Location = New System.Drawing.Point(119, 61)
			Me.RenderTechnologyComboBox.Name = "RenderTechnologyComboBox"
			Me.RenderTechnologyComboBox.Size = New System.Drawing.Size(121, 21)
			Me.RenderTechnologyComboBox.TabIndex = 3
			'			Me.RenderTechnologyComboBox.SelectedIndexChanged += New System.EventHandler(Me.OnRenderTechnologyComboBoxSelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(8, 105)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(72, 13)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Shape Count:"
			' 
			' ShapeCountComboBox
			' 
			Me.ShapeCountComboBox.ListProperties.CheckBoxDataMember = ""
			Me.ShapeCountComboBox.ListProperties.DataSource = Nothing
			Me.ShapeCountComboBox.ListProperties.DisplayMember = ""
			Me.ShapeCountComboBox.Location = New System.Drawing.Point(119, 97)
			Me.ShapeCountComboBox.Name = "ShapeCountComboBox"
			Me.ShapeCountComboBox.Size = New System.Drawing.Size(121, 21)
			Me.ShapeCountComboBox.TabIndex = 5
			'			Me.ShapeCountComboBox.SelectedIndexChanged += New System.EventHandler(Me.OnShapeCountComboBoxSelectedIndexChanged);
			' 
			' NHardwareAccelerationUC
			' 
			Me.Controls.Add(Me.ShapeCountComboBox)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.RenderTechnologyComboBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.lblFps)
			Me.Name = "NHardwareAccelerationUC"
			Me.Size = New System.Drawing.Size(248, 384)
			Me.Controls.SetChildIndex(Me.lblFps, 0)
			Me.Controls.SetChildIndex(Me.label1, 0)
			Me.Controls.SetChildIndex(Me.RenderTechnologyComboBox, 0)
			Me.Controls.SetChildIndex(Me.label2, 0)
			Me.Controls.SetChildIndex(Me.ShapeCountComboBox, 0)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
#End Region

#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub AttachToEvents()
			MyBase.AttachToEvents()

			m_PreviousTickTime = DateTime.Now
			m_Timer = New NTimer()
			m_Timer.Interval = 10
			AddHandler m_Timer.Tick, AddressOf OnTimerTick
			m_Timer.Start()
		End Sub
		Protected Overrides Sub LoadExample()
			MyBase.DefaultGridOrigin = New NPointF(30, 30)
			MyBase.DefaultGridCellSize = New NSizeF(100, 50)
			MyBase.DefaultGridSpacing = New NSizeF(50, 40)

			m_Random = New Random()
			m_FrameSpansQueue = New Queue(Of TimeSpan)()

			' begin view init
			view.BeginInit()

			view.GlobalVisibility.ShowPorts = False
			view.Grid.Visible = False
			view.HorizontalRuler.Visible = False
			view.VerticalRuler.Visible = False
			view.ViewLayout = ViewLayout.Fit
			view.DocumentPadding = New Nevron.Diagram.NMargins(10)
			view.DocumentShadow = New NShadowStyle(Color.Gray)
			view.DocumentShadow.Offset = New NPointL(3, 3)

			' init document
			document.BeginInit()
			InitDocument()

			Me.RenderTechnologyComboBox.FillFromEnum(GetType(RenderTechnology))
			Me.RenderTechnologyComboBox.SelectedIndex = CInt(Fix(RenderTechnology.OpenGLHardware))

			Me.ShapeCountComboBox.Items.Add("200")
			Me.ShapeCountComboBox.Items.Add("500")
			Me.ShapeCountComboBox.Items.Add("1000")
			Me.ShapeCountComboBox.SelectedIndex = 0

			document.EndInit()

			' end view init
			view.EndInit()
		End Sub
		Protected Overrides Sub DetachFromEvents()
			MyBase.DetachFromEvents()

			m_Timer.Stop()
			RemoveHandler m_Timer.Tick, AddressOf OnTimerTick
		End Sub

#End Region

#Region "Implementation"

		Private Sub InitDocument()
			document.Style.StrokeStyle = New NStrokeStyle(0, Color.Empty)

			' Add some gradient fill style sheets
			Dim styleSheet As NStyleSheet = New NStyleSheet("Style1")
			NStyle.SetFillStyle(styleSheet, New NColorFillStyle(Color.Red))
			document.StyleSheets.AddChild(styleSheet)

			styleSheet = New NStyleSheet("Style2")
			NStyle.SetFillStyle(styleSheet, New NColorFillStyle(Color.Green))
			document.StyleSheets.AddChild(styleSheet)

			styleSheet = New NStyleSheet("Style3")
			NStyle.SetFillStyle(styleSheet, New NColorFillStyle(Color.Blue))
			document.StyleSheets.AddChild(styleSheet)
		End Sub

#End Region

#Region "Event Handlers"

		Private Sub OnTimerTick(ByVal sender As Object, ByVal e As EventArgs)
			If m_Shapes Is Nothing Then
				Return
			End If

			' Record the duration between this tick and the previous one
			Dim now As DateTime = DateTime.Now
			Dim timeSpan As TimeSpan = now.Subtract(m_PreviousTickTime)
			m_FrameSpansQueue.Enqueue(timeSpan)
			m_PreviousTickTime = now

			' Make FPS statistics
			If m_FrameSpansQueue.Count > 100 Then
				m_FrameSpansQueue.Dequeue()

				Dim totalSpan As TimeSpan = New TimeSpan(0)
				Dim iter As Queue(Of TimeSpan).Enumerator = m_FrameSpansQueue.GetEnumerator()
				Do While iter.MoveNext()
					totalSpan = totalSpan + iter.Current
				Loop

				Dim fps As Double = (CDbl(m_FrameSpansQueue.Count) / CDbl(totalSpan.TotalSeconds))
				lblFps.Text = "FPS: " & fps.ToString("0.00")
			End If

			' Move shapes
			Dim shapeCount As Integer = m_Shapes.Length

			Dim i As Integer = 0
			Do While i < shapeCount
				Dim shape As NShape = m_Shapes(i)

				' Generate new shape location
				Dim directionAngle As Single = CSng(shape.Tag)
				Dim x As Single = shape.Location.X + CSng(Math.Sin(directionAngle) * 2)
				Dim y As Single = shape.Location.Y + CSng(Math.Cos(directionAngle) * 2)

				' Clamp shape bounds to document area
				Dim changeDirection As Boolean = False
				If x < 0 OrElse (x + shape.Width) > document.Width Then
					x = Clamp(0, document.Width - shape.Width, x)
					changeDirection = True
				End If

				If y < 0 OrElse (y + shape.Height) > document.Height Then
					y = Clamp(0, document.Height - shape.Height, y)
					changeDirection = True
				End If

				' Change movement direction, if shape hit document area bounds
				If changeDirection Then
					shape.Tag = NMath.NormalizeRadians(directionAngle + m_Random.Next(80, 100) * NMath.Degree2Rad)
				End If

				' Move the shape
				shape.Location = New NPointF(x, y)
				i += 1
			Loop

			document.SmartRefreshAllViews()
		End Sub

		Private Sub OnRenderTechnologyComboBoxSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RenderTechnologyComboBox.SelectedIndexChanged
			Me.view.RenderTechnology = CType(RenderTechnologyComboBox.SelectedIndex, RenderTechnology)
		End Sub

		Private Sub OnShapeCountComboBoxSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShapeCountComboBox.SelectedIndexChanged
			' Create the shapes
			Dim shapeCount As Integer = 0
			document.ActiveLayer.RemoveAllChildren()

			Select Case ShapeCountComboBox.SelectedIndex
				Case 0
					shapeCount = 200
				Case 1
					shapeCount = 500
				Case 2
					shapeCount = 1000
			End Select

			m_Shapes = New NShape(shapeCount - 1) {}
			Dim xMax As Integer = CInt(Fix(document.Width)) - ShapeWidth
			Dim yMax As Integer = CInt(Fix(document.Height)) - ShapeHeight

			Dim i As Integer = 0
			Do While i < shapeCount
				' Create a rectangle shape
				Dim shape As NShape = New NRectangleShape(m_Random.Next(xMax), m_Random.Next(yMax), ShapeWidth, ShapeHeight)
				shape.StyleSheetName = "Style" & m_Random.Next(1, 4).ToString(CultureInfo.InvariantCulture)

				' Set its protections
				Dim protection As NAbilities = shape.Protection
				protection.All = True
				shape.Protection = protection

				' Generate a random direction angle
				shape.Tag = m_Random.Next(90) * NMath.Degree2Rad
				document.ActiveLayer.AddChild(shape)
				m_Shapes(i) = shape
				i += 1
			Loop

		End Sub

#End Region

#Region "Fields"

		Private m_Timer As NTimer
		Private m_Shapes As NShape()
		Private m_Random As Random
		Private m_PreviousTickTime As DateTime
		Private m_FrameSpansQueue As Queue(Of TimeSpan)

#End Region

#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private label1 As System.Windows.Forms.Label
		Private WithEvents RenderTechnologyComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As System.Windows.Forms.Label
		Private WithEvents ShapeCountComboBox As UI.WinForm.Controls.NComboBox
		Private lblFps As System.Windows.Forms.Label

#End Region

#Region "Static Methods"

		''' <summary>
		''' Clamps the value to the [min;max] range.
		''' </summary>
		''' <param name="min"></param>
		''' <param name="max"></param>
		''' <param name="value"></param>
		''' <returns></returns>
		Public Shared Function Clamp(ByVal min As Single, ByVal max As Single, ByVal value As Single) As Single
			If value < min Then
				Return min
			End If

			If value > max Then
				Return max
			End If

			Return value
		End Function

#End Region

#Region "Constants"

		Private Const ShapeWidth As Integer = 50
		Private Const ShapeHeight As Integer = 50

#End Region



	End Class
End Namespace