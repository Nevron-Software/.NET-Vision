Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.Templates
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.WinForm.Commands

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NWizardUC.
	''' </summary>
	Public Class NWizardUC
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
			Me.showWizardButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' showWizardButton
			' 
			Me.showWizardButton.Location = New System.Drawing.Point(8, 8)
			Me.showWizardButton.Name = "showWizardButton"
			Me.showWizardButton.Size = New System.Drawing.Size(232, 32)
			Me.showWizardButton.TabIndex = 0
			Me.showWizardButton.Text = "Show Wizard..."
'			Me.showWizardButton.Click += New System.EventHandler(Me.showWizardButton_Click);
			' 
			' NWizardUC
			' 
			Me.Controls.Add(Me.showWizardButton)
			Me.Name = "NWizardUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.showWizardButton, 0)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		''' <summary>
		''' 
		''' </summary>
		Protected Overrides Sub LoadExample()

		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub showWizardButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles showWizardButton.Click
			Dim wizard As NWizard = New NWizard(document)

			Dim myTemplates As NTemplateCollection = New NTemplateCollection("My Templates")
			myTemplates.Add(New NMyTemplate())

			wizard.AddCategory(myTemplates)

			wizard.ShowDialog()
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents showWizardButton As Nevron.UI.WinForm.Controls.NButton

		#End Region
	End Class

	''' <summary>
	''' Summary description for NMyTemplate
	''' </summary>
	Public Class NMyTemplate
		Inherits NGraphTemplate
		#Region "Constructors"

		''' <summary>
		''' Default constructor
		''' </summary>
		Public Sub New()
			MyBase.New("My Template")
			m_nRimNodesCount = 6
			m_fRadiusY = 100
			m_fRadiusX = 100
		End Sub

		#End Region

		#Region "Interface implementations"

		#Region "INMeasurements overrides"

		''' <summary>
		''' Called when the measurement unit of the measurements stored in this template 
		''' have changed and all measurements must be converted to the new unit
		''' </summary>
		''' <remarks>
		''' Overriden to convert the X and Y radiuses
		''' </remarks>
		''' <param name="converter">measurement unit converter to use</param>
		''' <param name="from">from measurement unit</param>
		''' <param name="to">to measurement unit</param>
		Public Overrides Sub ConvertMeasurementUnit(ByVal converter As NMeasurementUnitConverter, ByVal from As NMeasurementUnit, ByVal [to] As NMeasurementUnit)
			MyBase.ConvertMeasurementUnit(converter, from, [to])

			m_fRadiusX = converter.ConvertX(from, [to], m_fRadiusX)
			m_fRadiusY = converter.ConvertY(from, [to], m_fRadiusY)
		End Sub


		#End Region

		#End Region

		#Region "Properties"

		''' <summary>
		''' Gets/sets the count of the nodes on the ellipse rim
		''' </summary>
		''' <remarks>
		''' By default set to 6
		''' </remarks>
		<Category("Grid"), Description("Gets/sets the count of the nodes on the ellipse rim"), DefaultValue(6)> _
		Public Property RimNodesCount() As Integer
			Get
				Return m_nRimNodesCount
			End Get
			Set
				If Value = m_nRimNodesCount Then
					Return
				End If

				If Value < 3 Then
					Throw New ArgumentOutOfRangeException("The value must be > 2.")
				End If

				m_nRimNodesCount = Value
				OnTemplateChanged()
			End Set
		End Property

		''' <summary>
		''' Controls the X radius of the ellipse
		''' </summary>		
		<Category("Ellipse"), Description("Controls the X radius of the ellipse")> _
		Public Property RadiusX() As Single
			Get
				Return m_fRadiusX
			End Get
			Set
				If Value = m_fRadiusX Then
					Return
				End If

				If Value <= 0 Then
					Throw New ArgumentOutOfRangeException("The value must be > 0.")
				End If

				m_fRadiusX = Value
				OnTemplateChanged()
			End Set
		End Property

		''' <summary>
		''' Controls the Y radius of the ellipse
		''' </summary>		
		<Category("Ellipse"), Description("Controls the Y radius of the ellipse")> _
		Public Property RadiusY() As Single
			Get
				Return m_fRadiusY
			End Get
			Set
				If Value = m_fRadiusY Then
					Return
				End If

				If Value <= 0 Then
					Throw New ArgumentOutOfRangeException("The value must be > 0.")
				End If

				m_fRadiusY = Value
				OnTemplateChanged()
			End Set
		End Property


		#End Region

		 #Region "Overrides"

		''' <summary>
		''' Overriden to return the description
		''' </summary>
		Public Overrides Function GetDescription() As String
			Dim description As String = "Fully connected graph with " & m_nRimNodesCount.ToString() & " nodes on the rim."
			Return description
		End Function


		#End Region

		#Region "Protected overrides"

		''' <summary>
		''' Overriden to create the fully connected graph template
		''' </summary>
		''' <param name="document">document in which to create the template</param>
		Protected Overrides Sub CreateTemplate(ByVal document As NDrawingDocument)
			Dim i As Integer
			Dim vertex As NShape
			Dim edge As NShape
			Dim pt As NPointF
			Dim vertices As ArrayList = New ArrayList()
			Dim layer As NLayer = document.ActiveLayer

			' create the ellipse vertices
			Dim curAngle As Single = 0, stepAngle As Single = (CSng(Math.PI) * 2) / m_nRimNodesCount
			Dim center As PointF = New PointF(Origin.X + m_fRadiusX + VerticesSize.Width / 2, Origin.Y + m_fRadiusY + VerticesSize.Height / 2)

			i = 0
			Do While i < m_nRimNodesCount
				pt = New NPointF(center.X + m_fRadiusX * CSng(Math.Cos(curAngle)) - VerticesSize.Width / 2, center.Y + m_fRadiusY * CSng(Math.Sin(curAngle)) - VerticesSize.Height / 2)

				vertex = CreateVertex(VerticesShape)
				vertex.Bounds = New NRectangleF(pt, VerticesSize)
				layer.AddChild(vertex)

				vertices.Add(vertex)
				curAngle += stepAngle
				i += 1
			Loop

			' connect them
			i = 0
			Do While i < vertices.Count
				Dim j As Integer = i + 1
				Do While j < vertices.Count
					edge = CreateEdge(ConnectorType.DynamicPolyline)
					layer.AddChild(edge)

					edge.FromShape = CType(vertices(i), NShape)
					edge.ToShape = CType(vertices(j), NShape)
					j += 1
				Loop
				i += 1
			Loop
		End Sub


		#End Region

		#Region "Fields"

		Friend m_nRimNodesCount As Integer
		Friend m_fRadiusY As Single
		Friend m_fRadiusX As Single

		#End Region
	End Class
End Namespace
