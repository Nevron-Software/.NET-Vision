Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NExportBaseUC.
	''' </summary>
	Public MustInherit Class NExportBaseUC
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
			Me.btnExport = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' btnGenerateDxf
			' 
			Me.btnExport.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnExport.Location = New System.Drawing.Point(8, 475)
			Me.btnExport.Name = "btnExport"
			Me.btnExport.Size = New System.Drawing.Size(234, 23)
			Me.btnExport.TabIndex = 5
			Me.btnExport.Text = "Export to ..."
			Me.btnExport.UseVisualStyleBackColor = True
'			Me.btnExport.Click += New System.EventHandler(Me.btnExport_Click);
			' 
			' NExporterBaseUC
			' 
			Me.Controls.Add(Me.btnExport)
			Me.Name = "NExportBaseUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.btnExport, 0)
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
			CreateDiagram()
			document.EndInit()

			' end view init
			view.EndInit()
		End Sub
		Protected Overrides Sub CreateDefaultFlowDiagram()
			MyBase.CreateDefaultFlowDiagram()

			' create a rectangle shape
			Dim rect As NRectangleShape = New NRectangleShape(New NRectangleF(10, 10, 100, 60))
			rect.Text = "Non-image exportable shape"
			rect.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(&Hff, &H55, &H55), Color.FromArgb(&H66, &H00, &H00))

			' protect from export
			Dim protection As NAbilities = rect.Protection
			protection.Export = True
			rect.Protection = protection

			' add it to the active layer
			document.ActiveLayer.AddChild(rect)
		End Sub

		#End Region

		#Region "Abstract"

		Protected MustOverride ReadOnly Property ErrorMessage() As String
		Protected MustOverride Function Export() As String

		#End Region

		#Region "Overridable"

		Protected Overridable Sub CreateDiagram()
			CreateDefaultFlowDiagram()
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
			Dim fileName As String = Export()

			Try
				Process.Start(fileName)
			Catch
				MessageBox.Show(ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Friend WithEvents btnExport As Nevron.UI.WinForm.Controls.NButton

		#End Region
	End Class
End Namespace