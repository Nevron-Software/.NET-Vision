Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Reflection
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NThemableElementsUC.
	''' </summary>
	Public Class NThemableElementsUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			Dock = DockStyle.Fill

			Dim shape As NRectShape = New NRectShape()
			shape.StrokeStyle = New NStrokeStyle(3, Color.Brown)

			m_Host = New NUIElementHost()
			m_ElementContainer = New NUIElementContainer()
			m_ElementContainer.Style.Background = shape
			m_Host.Bounds = New Rectangle(10, 10, 250, 250)

			'add one button
			Dim button As NPushButtonElement = New NPushButtonElement()
			button.Text = "Push Button"
			button.Bounds = New NRectangle(10, 10, 100, 24)
			m_ElementContainer.AddChild(button)

			'add one checkbox
			Dim checkBox As NCheckBoxElement = New NCheckBoxElement()
			checkBox.Text = "Check Box"
			checkBox.ThreeStates = True
			checkBox.Bounds = New NRectangle(10, 36, 100, 24)
			m_ElementContainer.AddChild(checkBox)

			'add one radiobox
			Dim radioBox As NRadioBoxElement = New NRadioBoxElement()
			radioBox.Text = "Radio Box 1"
			radioBox.Bounds = New NRectangle(10, 62, 100, 24)
			m_ElementContainer.AddChild(radioBox)

			radioBox = New NRadioBoxElement()
			radioBox.Text = "Radio Box 2"
			radioBox.Bounds = New NRectangle(120, 62, 100, 24)
			m_ElementContainer.AddChild(radioBox)

			Dim checkButton As NCheckButtonElement = New NCheckButtonElement()
			checkButton.Text = "Check Button"
			checkButton.Bounds = New NRectangle(10, 88, 100, 24)
			m_ElementContainer.AddChild(checkButton)

			Dim radioButton As NRadioButtonElement = New NRadioButtonElement()
			radioButton.Text = "Radio Button 1"
			radioButton.Bounds = New NRectangle(10, 116, 100, 24)
			m_ElementContainer.AddChild(radioButton)

			radioButton = New NRadioButtonElement()
			radioButton.Text = "Radio Button 2"
			radioButton.Bounds = New NRectangle(120, 116, 100, 24)
			m_ElementContainer.AddChild(radioButton)

			m_Host.Element = m_ElementContainer
			m_Host.Parent = Me
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
			MyBase.Initialize ()

			m_iSuspendUpdate += 1

			Me.themeCombo.Items.Add("System")
			Me.themeCombo.Items.Add("Office 2003")
			Me.themeCombo.Items.Add("Office 2007")
			Me.themeCombo.SelectedIndex = 1

			m_iSuspendUpdate -= 1
		End Sub


		#End Region

		#Region "Implementation"

		Friend Function LoadResourceTheme(ByVal themeName As String) As NTheme
			Dim t As Type = Me.GetType()
			Dim [assembly] As System.Reflection.Assembly = t.Assembly

			Dim path As String = "Nevron.Examples.UI.WinForm.Resources.Themes."

			Dim stream As Stream

			If NExamplesForm.IsVBContext Then
				stream = [assembly].GetManifestResourceStream(themeName)
			Else
				stream = [assembly].GetManifestResourceStream(path & themeName)
			End If

			Dim theme As NTheme = NTheme.FromStream(stream, GetType(NTheme))

			stream.Close()

			Return theme
		End Function


		#End Region

		#Region "Event Handlers"

		Private Sub themeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles themeCombo.SelectedIndexChanged
			If m_iSuspendUpdate > 0 Then
				Return
			End If

			Dim index As Integer = themeCombo.SelectedIndex
			If index = -1 Then
				Return
			End If

			Dim theme As NTheme = Nothing

			Select Case index
				Case 0
					theme = New Nevron.UI.Themes.System.NSystemTheme()
				Case 1
					theme = New Nevron.UI.Themes.Office2003.NOffice2003Theme()
				Case 2
					theme = LoadResourceTheme("Office2007Blue.xml")
			End Select

			If theme Is Nothing Then
				Return
			End If

			Dim oldTheme As INTheme = NThemeManager.Instance.CurrentTheme
			NThemeManager.Instance.CurrentTheme = theme

			oldTheme.Dispose()
		End Sub

		Private Sub toggleEnabledButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toggleEnabledButton.Click
			m_ElementContainer.Enabled = m_ElementContainer.Enabled Xor True
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.themeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.toggleEnabledButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' themeCombo
			' 
			Me.themeCombo.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.themeCombo.Location = New System.Drawing.Point(80, 264)
			Me.themeCombo.Name = "themeCombo"
			Me.themeCombo.Size = New System.Drawing.Size(200, 22)
			Me.themeCombo.TabIndex = 0
			Me.themeCombo.Text = "nComboBox1"
'			Me.themeCombo.SelectedIndexChanged += New System.EventHandler(Me.themeCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.label1.Location = New System.Drawing.Point(8, 264)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(64, 23)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Theme:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' toggleEnabledButton
			' 
			Me.toggleEnabledButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.toggleEnabledButton.Location = New System.Drawing.Point(80, 232)
			Me.toggleEnabledButton.Name = "toggleEnabledButton"
			Me.toggleEnabledButton.Size = New System.Drawing.Size(120, 24)
			Me.toggleEnabledButton.TabIndex = 2
			Me.toggleEnabledButton.Text = "Toggle Enabled"
'			Me.toggleEnabledButton.Click += New System.EventHandler(Me.toggleEnabledButton_Click);
			' 
			' NThemableElementsUC
			' 
			Me.Controls.Add(Me.toggleEnabledButton)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.themeCombo)
			Me.Name = "NThemableElementsUC"
			Me.Size = New System.Drawing.Size(400, 296)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Friend m_Host As NUIElementHost
		Friend m_ElementContainer As NUIElementContainer
		Private WithEvents themeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents toggleEnabledButton As Nevron.UI.WinForm.Controls.NButton
		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
