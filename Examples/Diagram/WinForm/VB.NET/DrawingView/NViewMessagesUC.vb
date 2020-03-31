Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.WinForm.Commands
Imports Nevron.UI.WinForm.Controls

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NViewMessagesUC.
	''' </summary>
	Public Class NViewMessagesUC
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
			Me.customDesignerMessageButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' customDesignerMessageButton
			' 
			Me.customDesignerMessageButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.customDesignerMessageButton.Location = New System.Drawing.Point(8, 8)
			Me.customDesignerMessageButton.Name = "customDesignerMessageButton"
			Me.customDesignerMessageButton.Size = New System.Drawing.Size(232, 23)
			Me.customDesignerMessageButton.TabIndex = 30
			Me.customDesignerMessageButton.Text = "Show custom view message"
'			Me.customDesignerMessageButton.Click += New System.EventHandler(Me.customDesignerMessageButton_Click);
			' 
			' NViewMessagesUC
			' 
			Me.Controls.Add(Me.customDesignerMessageButton)
			Me.Name = "NViewMessagesUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.customDesignerMessageButton, 0)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' end view init
			view.EndInit()
		End Sub

		Protected Overrides Sub ResetExample()
			MyBase.ResetExample()
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			Dim rect1 As NRectangleShape = New NRectangleShape(New NRectangleF(10, 10, 100, 100))
			document.ActiveLayer.AddChild(rect1)
			rect1.Style.FillStyle = New NColorFillStyle(Color.Red)
			rect1.Protection = New NAbilities(rect1.Protection.Mask And (Not AbilitiesMask.ChangeStyle))

			Dim rect2 As NRectangleShape = New NRectangleShape (New NRectangleF(160, 160, 100, 100))
			document.ActiveLayer.AddChild(rect2)
			rect2.Style.FillStyle = New NColorFillStyle(Color.Green)

			view.Selection.SingleSelect(document.ActiveLayer.Children(NFilters.PermissionSelect))
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub customDesignerMessageButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles customDesignerMessageButton.Click
			view.ShowMessage("Custom view message. Click to hide this message.")
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents customDesignerMessageButton As Nevron.UI.WinForm.Controls.NButton

		#End Region

		#Region "Fields"
		Private toolsMap As Hashtable = New Hashtable()
		#End Region
	End Class
End Namespace