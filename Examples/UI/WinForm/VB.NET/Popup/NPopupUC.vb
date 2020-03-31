Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm
Imports Nevron.GraphicsCore
Imports Nevron.GraphicsCore.Text

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NPopupUC.
	''' </summary>
	Public Class NPopupUC
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

				m_Popup.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		Public Overrides Sub Initialize()
			MyBase.Initialize ()

			m_Popup = New NPopup()
			m_Popup.Owner = m_MainForm
			m_Popup.Size = New NSize(250, 220)
			m_Popup.SizeStyle = PopupSizeStyle.BottomRight
			m_Popup.Padding = New NPadding(4)

			propertyGrid.SelectedObject = m_Popup
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub showBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles showBtn.Click
			If nRadioButton1.Checked Then
				m_Popup.PlacementTarget = nRadioButton1
			Else
				m_Popup.PlacementTarget = nRadioButton2
			End If

			If Me.nCheckBox1.Checked Then
				Dim calc As NCalculator = New NCalculator()
				calc.Dock = DockStyle.Fill
				calc.BackColor = Color.Transparent
				m_Popup.HostedControl = calc
			Else
				m_Popup.HostedControl = Nothing
			End If

			m_Popup.Display()
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.propertyGrid = New System.Windows.Forms.PropertyGrid()
			Me.showBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.nRadioButton1 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nRadioButton2 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nGroupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' propertyGrid
			' 
			Me.propertyGrid.CommandsVisibleIfAvailable = True
			Me.propertyGrid.Cursor = System.Windows.Forms.Cursors.HSplit
			Me.propertyGrid.HelpBackColor = System.Drawing.Color.FromArgb((CByte(230)), (CByte(230)), (CByte(230)))
			Me.propertyGrid.HelpForeColor = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(0)))
			Me.propertyGrid.LargeButtons = False
			Me.propertyGrid.LineColor = System.Drawing.Color.FromArgb((CByte(230)), (CByte(230)), (CByte(230)))
			Me.propertyGrid.Location = New System.Drawing.Point(248, 8)
			Me.propertyGrid.Name = "propertyGrid"
			Me.propertyGrid.Size = New System.Drawing.Size(271, 312)
			Me.propertyGrid.TabIndex = 5
			Me.propertyGrid.Text = "propertyGrid1"
			Me.propertyGrid.ToolbarVisible = False
			Me.propertyGrid.ViewBackColor = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.propertyGrid.ViewForeColor = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(0)))
			' 
			' showBtn
			' 
			Me.showBtn.ButtonProperties.WrapText = True
			Me.showBtn.Location = New System.Drawing.Point(248, 328)
			Me.showBtn.Name = "showBtn"
			Me.showBtn.Size = New System.Drawing.Size(272, 32)
			Me.showBtn.TabIndex = 3
			Me.showBtn.Text = "Show"
'			Me.showBtn.Click += New System.EventHandler(Me.showBtn_Click);
			' 
			' nRadioButton1
			' 
			Me.nRadioButton1.Appearance = System.Windows.Forms.Appearance.Button
			Me.nRadioButton1.ButtonProperties.BorderOffset = 2
			Me.nRadioButton1.Checked = True
			Me.nRadioButton1.Location = New System.Drawing.Point(16, 24)
			Me.nRadioButton1.Name = "nRadioButton1"
			Me.nRadioButton1.Size = New System.Drawing.Size(192, 128)
			Me.nRadioButton1.TabIndex = 5
			Me.nRadioButton1.TabStop = True
			Me.nRadioButton1.Text = "Placement Target 1"
			Me.nRadioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' nRadioButton2
			' 
			Me.nRadioButton2.Appearance = System.Windows.Forms.Appearance.Button
			Me.nRadioButton2.ButtonProperties.BorderOffset = 2
			Me.nRadioButton2.Location = New System.Drawing.Point(16, 168)
			Me.nRadioButton2.Name = "nRadioButton2"
			Me.nRadioButton2.Size = New System.Drawing.Size(192, 128)
			Me.nRadioButton2.TabIndex = 6
			Me.nRadioButton2.Text = "Placement Target 2"
			Me.nRadioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.nRadioButton1)
			Me.nGroupBox1.Controls.Add(Me.nRadioButton2)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(8, 8)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(224, 312)
			Me.nGroupBox1.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default
			Me.nGroupBox1.TabIndex = 8
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Placement Targets"
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.ButtonProperties.BorderOffset = 2
			Me.nCheckBox1.Location = New System.Drawing.Point(24, 328)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.Size = New System.Drawing.Size(192, 24)
			Me.nCheckBox1.TabIndex = 9
			Me.nCheckBox1.Text = "Host Calculator"
			' 
			' NPopupUC
			' 
			Me.Controls.Add(Me.nCheckBox1)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.showBtn)
			Me.Controls.Add(Me.propertyGrid)
			Me.Name = "NPopupUC"
			Me.Size = New System.Drawing.Size(528, 368)
			Me.nGroupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Friend m_Popup As NPopup

		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents showBtn As Nevron.UI.WinForm.Controls.NButton
		Private nRadioButton1 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nRadioButton2 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private propertyGrid As System.Windows.Forms.PropertyGrid

		#End Region
	End Class
End Namespace
