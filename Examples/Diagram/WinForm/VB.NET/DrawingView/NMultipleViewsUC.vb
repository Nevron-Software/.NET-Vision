Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Diagram
Imports Nevron.Diagram.Editors
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NMultipleViewsUC.
	''' </summary>
	Public Class NMultipleViewsUC
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
			Me.nNumericUpDown1 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			CType(Me.nNumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
			' 
			' nNumericUpDown1
			' 
			Me.nNumericUpDown1.Location = New System.Drawing.Point(0, 0)
			Me.nNumericUpDown1.Name = "nNumericUpDown1"
			Me.nNumericUpDown1.Size = New System.Drawing.Size(120, 22)
			Me.nNumericUpDown1.TabIndex = 0
			' 
			' NMultipleViewsUC
			' 
			Me.Name = "NMultipleViewsUC"
			Me.Size = New System.Drawing.Size(240, 576)
			CType(Me.nNumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			view.DocumentPadding = New Nevron.Diagram.NMargins(20)
			view.ViewportOrigin = New NPointF(-12, -12)
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False

			' init document
			document.BeginInit()
			CreateDefaultFlowDiagram()
			document.EndInit()

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			' create the second view and attach it to the document
			Dim secondView As NDrawingView = New NDrawingView()
			secondView.Grid.Visible = False
			secondView.GlobalVisibility.ShowPorts = False
			secondView.Size = New Size(300, Me.Height / 2)
			secondView.Dock = DockStyle.Top
			secondView.Document = document

			' create the third view and attach it to the document
			Dim thirdView As NDrawingView = New NDrawingView()
			thirdView.Grid.Visible = False
			thirdView.GlobalVisibility.ShowPorts = False
			thirdView.Dock = DockStyle.Fill
			thirdView.Document = document

			' create a splitter
			Dim splitter As Splitter = New Splitter()
			splitter.Dock = DockStyle.Top

			' update the form controls
			Controls.Clear()
			Controls.Add(thirdView)
			Controls.Add(splitter)
			Controls.Add(secondView)
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nNumericUpDown1 As Nevron.UI.WinForm.Controls.NNumericUpDown

		#End Region
	End Class
End Namespace