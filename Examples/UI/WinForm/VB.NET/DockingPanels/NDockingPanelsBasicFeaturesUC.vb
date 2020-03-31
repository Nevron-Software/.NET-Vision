Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.UI.WinForm.Docking
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NDockingPanelsUC.
	''' </summary>
	Public Class NDockingPanelsBasicFeaturesUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()
		End Sub
		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			m_ExampleFormType = GetType(NBasicFeaturesForm)
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub m_LaunchButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_LaunchButton.Click
			Dim f As Form = TryCast(Activator.CreateInstance(m_ExampleFormType), Form)
			If f Is Nothing Then
				Return
			End If

			f.Show()
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.m_LaunchButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' m_LaunchButton
			' 
			Me.m_LaunchButton.Location = New System.Drawing.Point(8, 8)
			Me.m_LaunchButton.Name = "m_LaunchButton"
			Me.m_LaunchButton.Size = New System.Drawing.Size(120, 32)
			Me.m_LaunchButton.TabIndex = 0
			Me.m_LaunchButton.Text = "Launch Example"
'			Me.m_LaunchButton.Click += New System.EventHandler(Me.m_LaunchButton_Click);
			' 
			' NDockingPanelsBasicFeaturesUC
			' 
			Me.Controls.Add(Me.m_LaunchButton)
			Me.Name = "NDockingPanelsBasicFeaturesUC"
			Me.Size = New System.Drawing.Size(136, 48)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private WithEvents m_LaunchButton As Nevron.UI.WinForm.Controls.NButton
		Private components As System.ComponentModel.Container = Nothing

		Friend m_ExampleFormType As Type

		#End Region
	End Class

	''' <summary>
	''' Summary description for NBasicFeatures.
	''' </summary>
	Public Class NBasicFeaturesForm
		Inherits NDockingPanelsExampleForm
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			' 
			' NBasicFeatures
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(800, 414)
			Me.Name = "NBasicFeatures"
			Me.Text = "Docking Panels Basic Features"

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
