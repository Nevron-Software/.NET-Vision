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
Imports Nevron.Diagram.Templates
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.WinForm.Commands

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NPanAndZoomControlUC.
	''' </summary>
	Public Class NPanAndZoomControlUC
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
			Me.panAndZoomControl = New Nevron.Diagram.WinForm.NPanAndZoomControl()
			Me.showZoomNavigatorCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.showViewportBandCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' panAndZoomControl
			' 
			Me.panAndZoomControl.Dock = System.Windows.Forms.DockStyle.Top
			' TODO: Code generation for 'this.panAndZoomControl.LargeZoomChangeFactor' failed because of Exception 'Invalid Primitive Type: System.UInt32. Only CLS compliant primitive types can be used. Consider using CodeObjectCreateExpression.'.
			Me.panAndZoomControl.Location = New System.Drawing.Point(0, 0)
			Me.panAndZoomControl.MasterView = Nothing
			Me.panAndZoomControl.Name = "panAndZoomControl"
			Me.panAndZoomControl.Size = New System.Drawing.Size(250, 240)
			Me.panAndZoomControl.TabIndex = 1
			' 
			' showZoomNavigatorCheck
			' 
			Me.showZoomNavigatorCheck.Location = New System.Drawing.Point(8, 248)
			Me.showZoomNavigatorCheck.Name = "showZoomNavigatorCheck"
			Me.showZoomNavigatorCheck.Size = New System.Drawing.Size(144, 24)
			Me.showZoomNavigatorCheck.TabIndex = 2
			Me.showZoomNavigatorCheck.Text = "Show Zoom Navigator"
'			Me.showZoomNavigatorCheck.CheckedChanged += New System.EventHandler(Me.showZoomNavigatorCheck_CheckedChanged);
			' 
			' showViewportBandCheck
			' 
			Me.showViewportBandCheck.Location = New System.Drawing.Point(8, 280)
			Me.showViewportBandCheck.Name = "showViewportBandCheck"
			Me.showViewportBandCheck.Size = New System.Drawing.Size(144, 24)
			Me.showViewportBandCheck.TabIndex = 3
			Me.showViewportBandCheck.Text = "Show Viewport Band"
'			Me.showViewportBandCheck.CheckedChanged += New System.EventHandler(Me.showViewportBandCheck_CheckedChanged);
			' 
			' NPanAndZoomControlUC
			' 
			Me.Controls.Add(Me.showViewportBandCheck)
			Me.Controls.Add(Me.showZoomNavigatorCheck)
			Me.Controls.Add(Me.panAndZoomControl)
			Me.Name = "NPanAndZoomControlUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.panAndZoomControl, 0)
			Me.Controls.SetChildIndex(Me.showZoomNavigatorCheck, 0)
			Me.Controls.SetChildIndex(Me.showViewportBandCheck, 0)
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

			' init form controls
			PauseEventsHandling()

			showZoomNavigatorCheck.Checked = True
			showViewportBandCheck.Checked = True

			ResumeEventsHandling()

			' end view init
			view.EndInit()

			' set the master view of the pan and zoom control
			panAndZoomControl.MasterView = view
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub showZoomNavigatorCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles showZoomNavigatorCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			panAndZoomControl.ShowZoomNavigator = showZoomNavigatorCheck.Checked
		End Sub

		Private Sub showViewportBandCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles showViewportBandCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			Me.panAndZoomControl.ViewportPreview.Band.Visible = showViewportBandCheck.Checked
			Me.panAndZoomControl.ViewportPreview.SmartRefresh()
		End Sub

		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private panAndZoomControl As Nevron.Diagram.WinForm.NPanAndZoomControl
		Private WithEvents showZoomNavigatorCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents showViewportBandCheck As Nevron.UI.WinForm.Controls.NCheckBox

		#End Region
	End Class
End Namespace