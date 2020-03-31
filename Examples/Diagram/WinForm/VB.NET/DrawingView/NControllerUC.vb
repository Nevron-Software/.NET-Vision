Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Text
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.GraphicsCore
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.WinForm.Commands
Imports Nevron.UI.WinForm.Controls

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NControllerUC.
	''' </summary>
	Public Class NControllerUC
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
			Me.activeToolCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' activeToolCombo
			' 
			Me.activeToolCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.activeToolCombo.Location = New System.Drawing.Point(8, 32)
			Me.activeToolCombo.Name = "activeToolCombo"
			Me.activeToolCombo.Size = New System.Drawing.Size(234, 21)
			Me.activeToolCombo.TabIndex = 0
			Me.activeToolCombo.Text = "Click here to select a tool"
'			Me.activeToolCombo.SelectedIndexChanged += New System.EventHandler(Me.activeToolCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(128, 16)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Enabled tool:"
			' 
			' NControllerUC
			' 
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.activeToolCombo)
			Me.Name = "NControllerUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.activeToolCombo, 0)
			Me.Controls.SetChildIndex(Me.label1, 0)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			' init document
			document.BeginInit()
			CreateDefaultFlowDiagram()
			document.EndInit()

			' add the custom tool to the controller
			view.Controller.Tools.Add(New NCustomTool())

			' init the controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub

		Protected Overrides Sub ResetExample()
			MyBase.ResetExample()
			view.Zoom(1, New NPointF(0, 0), True)
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			' init the active tool combo
			activeToolCombo.Items.Clear()

			Dim item As NListBoxItem

			item = New NListBoxItem(0, "Pointer Tool", False)
			activeToolCombo.Items.Add(item)

			item = New NListBoxItem(2, "Create Ellipse", False)
			activeToolCombo.Items.Add(item)

			item = New NListBoxItem(16, "Pan Tool", False)
			activeToolCombo.Items.Add(item)

			item = New NListBoxItem(-1, "Custom Tool", False)
			activeToolCombo.Items.Add(item)

			' init the toolIndexToNamesMap 
			toolIndexToNamesMap.Clear()
			toolIndexToNamesMap(0) = New String() { NDWFR.ToolCreateGuideline, NDWFR.ToolHandle, NDWFR.ToolMove, NDWFR.ToolSelector, NDWFR.ToolContextMenu, NDWFR.ToolKeyboard, NDWFR.ToolInplaceEdit }



			toolIndexToNamesMap(1) = New String() { NDWFR.ToolCreateEllipse }
			toolIndexToNamesMap(2) = New String() { NDWFR.ToolPan }
			toolIndexToNamesMap(3) = New String() { "Custom Tool"}


			' by default select the pointer tool
			activeToolCombo.SelectedIndex = 0

			ResumeEventsHandling()
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub activeToolCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles activeToolCombo.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim toolNames As String() = (TryCast(toolIndexToNamesMap(activeToolCombo.SelectedIndex), String()))
			If toolNames Is Nothing Then
				Return
			End If

			view.Controller.Tools.SingleEnableTools(toolNames)
		End Sub


		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents activeToolCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label

		#End Region

		#Region "Fields"

		Private toolIndexToNamesMap As Hashtable = New Hashtable()

		#End Region
	End Class

	''' <summary>
	''' Demonstrates creating custom tool by deriving from NDrawingDragTool.
	''' </summary>
	Public Class NCustomTool
		Inherits NDrawingDragTool
		#Region "Constructor"

		''' <summary>
		''' Default constructor
		''' </summary>
		Public Sub New()
			MyBase.New("Custom Tool")
		End Sub


		#End Region

		#Region "INMouseEventProcessor Overrides"

		''' <summary>
		''' Processes the mouse move event
		''' </summary>
		''' <remarks>
		''' Overriden to update the zoom rect if the tool is active
		''' </remarks>
		''' <param name="e">mouse event arguments</param>
		Public Overrides Function ProcessMouseMove(ByVal e As MouseEventArgs) As Boolean
			MyBase.ProcessMouseMove(e)

			If IsActive = False Then
				Return False
			End If

			UpdateZoomRect()
			Return True
		End Function

		''' <summary>
		''' Processes the mouse double click event
		''' </summary>
		''' <param name="e"></param>
		''' <returns></returns>
		Public Overrides Function ProcessDoubleClick(ByVal e As EventArgs) As Boolean
			MyBase.ProcessDoubleClick(e)

			View.Zoom(1, Controller.MouseInfo.ScenePoint, True)
			Return True
		End Function


		#End Region

		#Region "INStatusBarInfo Overrides"

		''' <summary>
		''' Updates the specified status bar info
		''' </summary>
		''' <remarks>
		''' Overriden to populate the secondary info with the zoom rect bounds if it is valid 
		''' and the secondary info is not yet populated.
		''' </remarks>
		''' <param name="info">status bar info</param>
		Public Overrides Sub UpdateStatusBarInfo(ByVal info As NStatusBarInfo)
			MyBase.UpdateStatusBarInfo(info)

			' update secondary info with zoom rect
			If info.Secondary = "" AndAlso Not m_ZoomRect Is Nothing Then
				Dim sb As StringBuilder = New StringBuilder(100)
				sb.Append("Zoom factor: ")
				sb.Append(ComputeZoomFactor())
				sb.Append(". ")

				Dim mu As NMeasurementUnit = Document.MeasurementUnit
				Dim format As String = mu.DefaultValueFormat
				Dim bounds As NRectangleF = m_ZoomRect.Bounds

				sb.Append("Zoom rect: {")
				sb.Append(bounds.X.ToString(format))
				sb.Append(", ")
				sb.Append(bounds.Y.ToString(format))
				sb.Append(", ")
				sb.Append(bounds.Width.ToString(format))
				sb.Append(", ")
				sb.Append(bounds.Height.ToString(format))
				sb.Append("}")

				info.Secondary = sb.ToString()
			End If
		End Sub


		#End Region

		#Region "Implementation"

		Protected Function ComputeZoomFactor() As Single
			Dim zoomRect As NRectangleF = m_ZoomRect.Bounds
			Dim xScale As Single = View.ScaleX * View.ViewportSize.Width / zoomRect.Width
			Dim yScale As Single = View.ScaleY * View.ViewportSize.Height / zoomRect.Height
			Return Math.Min(xScale, yScale)
		End Function


		#End Region

		#Region "Overrides"

		''' <summary>
		''' Activates the tool
		''' </summary>
		''' <remarks>
		''' Overriden to create the zoom rect
		''' </remarks>
		Public Overrides Sub Activate()
			MyBase.Activate()

			CreateZoomRect()
		End Sub

		''' <summary>
		''' Deactivates the tool
		''' </summary>
		''' <remarks>
		''' Overriden to perform zoom and destroy the zoom rect
		''' </remarks>
		Public Overrides Sub Deactivate()
			ZoomToRect()
			DestroyZoomRect()

			MyBase.Deactivate()
		End Sub

		''' <summary>
		''' Aborts the tool if it is active
		''' </summary>
		''' <remarks>
		''' Overriden to destroy the zoom rect
		''' </remarks>
		Public Overrides Sub Abort()
			DestroyZoomRect()

			MyBase.Abort()
		End Sub

		''' <summary>
		''' Overriden to return true
		''' </summary>
		Public Overrides ReadOnly Property NeedsSecondMouseButtonPass() As Boolean
			Get
				Return True
			End Get
		End Property


		#End Region

		#Region "Protected overridables"

		''' <summary>
		''' Zooms the view to the dragged zoom rect
		''' </summary>
		Protected Overridable Sub ZoomToRect()
			Dim zoomRect As NRectangleF = m_ZoomRect.Bounds
			If zoomRect.Width <> 0 OrElse zoomRect.Height <> 0 Then
				Dim scaleFactor As Single = ComputeZoomFactor()
				If View.IsValidScaleFactor(scaleFactor) Then
					Dim viewportCenter As NPointF = New NPointF(zoomRect.X + zoomRect.Width / 2, zoomRect.Y + zoomRect.Height / 2)
					View.Zoom(scaleFactor, viewportCenter, True)
				End If
			End If
		End Sub

		''' <summary>
		''' Creates the zoom rect
		''' </summary>
		''' <remarks>
		''' This implementation will currently create a zoom rectangle and add it to the preview layer
		''' </remarks>
		Protected Overridable Sub CreateZoomRect()
			' create the zoom rect 
			m_ZoomRect = New NRectanglePath()
			NStyle.SetFillStyle(m_ZoomRect, New NColorFillStyle(Color.FromArgb(0, 0, 0, 0)))
			NStyle.SetStrokeStyle(m_ZoomRect, New NStrokeStyle(1, Color.Black, LinePattern.Dash))
			View.PreviewLayer.AddChild(m_ZoomRect)

			' start dragging
			View.OnDraggingStarted()
		End Sub

		''' <summary>
		''' Destroys the zoom region
		''' </summary>
		''' <remarks>
		''' This implementation will destory the zoom rectangle
		''' </remarks>
		Protected Overridable Sub DestroyZoomRect()
			' destroy zoom rect
			View.PreviewLayer.RemoveChild(m_ZoomRect)
			m_ZoomRect = Nothing

			' stop dragging
			View.OnDraggingEnded()
		End Sub

		''' <summary>
		''' Updates the zoom region
		''' </summary>
		''' <remarks>
		''' This implementation will update the zoom rectangle with the current and start mouse hit infos 
		''' and higight the nodes hit by it
		''' </remarks>
		Protected Overridable Sub UpdateZoomRect()
			Try
				' update zoom rect
				m_ZoomRect.DefineModel(StartMouseInfo.ScenePoint, Controller.MouseInfo.ScenePoint)

				' inform the view to update the ruler highlights
				View.OnDragging(m_ZoomRect.Bounds)
			Catch ex As Exception
				Debug.WriteLine("Failed to update zoom rect. Exception was: " & ex.Message)
			End Try
		End Sub


		#End Region

		#Region "Fields"

		' region select
		Friend m_ZoomRect As NRectanglePath

		#End Region
	End Class
End Namespace