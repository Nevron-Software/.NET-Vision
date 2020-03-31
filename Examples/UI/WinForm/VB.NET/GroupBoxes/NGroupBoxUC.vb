Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Class NGroupBoxUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
		End Sub


		#End Region

		#Region "Implementation"

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

			Dim counter As Integer = 0
			For Each box As NGroupBox In Controls
				box.ImageList = m_ImageList
				box.ImageIndex = counter
				counter += 1
			Next box
		End Sub




		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NGroupBoxUC))
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nLuminanceBar1 = New Nevron.UI.WinForm.Controls.NLuminanceBar()
			Me.nColorBar1 = New Nevron.UI.WinForm.Controls.NColorBar()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nColorPool1 = New Nevron.UI.WinForm.Controls.NColorPool()
			Me.nColorButton1 = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.nButton1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.nGroupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nRadioButton2 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nRadioButton1 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nhScrollBar1 = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.nGroupBox4 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nOptionButton1 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nComboBoxCommand1 = New Nevron.UI.WinForm.Controls.NComboBoxCommand()
			Me.m_ImageList = New System.Windows.Forms.ImageList(Me.components)
			Me.nCommand1 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nComboBoxCommand2 = New Nevron.UI.WinForm.Controls.NComboBoxCommand()
			Me.nCommand2 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nTextBox1 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.nGroupBox1.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			Me.nGroupBox3.SuspendLayout()
			Me.nGroupBox4.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.nLuminanceBar1)
			Me.nGroupBox1.Controls.Add(Me.nColorBar1)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(8, 8)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(240, 96)
			Me.nGroupBox1.TabIndex = 0
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Group Box with Style LineAtTop"
			' 
			' nLuminanceBar1
			' 
			Me.nLuminanceBar1.Color = System.Drawing.Color.Red
			Me.nLuminanceBar1.Location = New System.Drawing.Point(16, 56)
			Me.nLuminanceBar1.Mode = Nevron.UI.WinForm.Controls.ColorBarMode.Custom
			Me.nLuminanceBar1.Name = "nLuminanceBar1"
			Me.nLuminanceBar1.Size = New System.Drawing.Size(200, 25)
			Me.nLuminanceBar1.TabIndex = 1
			Me.nLuminanceBar1.Text = "nLuminanceBar1"
			' 
			' nColorBar1
			' 
			Me.nColorBar1.Location = New System.Drawing.Point(16, 24)
			Me.nColorBar1.Name = "nColorBar1"
			Me.nColorBar1.Size = New System.Drawing.Size(200, 24)
			Me.nColorBar1.TabIndex = 0
			Me.nColorBar1.Text = "nColorBar1"
			Me.nColorBar1.Value = 50
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.nColorPool1)
			Me.nGroupBox2.Controls.Add(Me.nColorButton1)
			Me.nGroupBox2.Controls.Add(Me.nButton1)
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(8, 112)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(240, 96)
			Me.nGroupBox2.TabIndex = 1
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Group Box with Style LineAtTop"
			Me.nGroupBox2.TextOrigin = 50
			' 
			' nColorPool1
			' 
			Me.nColorPool1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.nColorPool1.Color = System.Drawing.Color.Empty
			Me.nColorPool1.Location = New System.Drawing.Point(120, 16)
			Me.nColorPool1.Name = "nColorPool1"
			Me.nColorPool1.Size = New System.Drawing.Size(112, 72)
			Me.nColorPool1.TabIndex = 2
			' 
			' nColorButton1
			' 
			Me.nColorButton1.ArrowClickOptions = False
			Me.nColorButton1.Color = System.Drawing.Color.White
			Me.nColorButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nColorButton1.Location = New System.Drawing.Point(16, 56)
			Me.nColorButton1.Name = "nColorButton1"
			Me.nColorButton1.TabIndex = 1
			Me.nColorButton1.Text = "nColorButton1"
			' 
			' nButton1
			' 
			Me.nButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nButton1.Location = New System.Drawing.Point(16, 24)
			Me.nButton1.Name = "nButton1"
			Me.nButton1.TabIndex = 0
			Me.nButton1.Text = "nButton1"
			' 
			' nGroupBox3
			' 
			Me.nGroupBox3.Controls.Add(Me.nRadioButton2)
			Me.nGroupBox3.Controls.Add(Me.nRadioButton1)
			Me.nGroupBox3.Controls.Add(Me.nhScrollBar1)
			Me.nGroupBox3.ImageIndex = 0
			Me.nGroupBox3.Location = New System.Drawing.Point(8, 216)
			Me.nGroupBox3.Name = "nGroupBox3"
			Me.nGroupBox3.Size = New System.Drawing.Size(240, 96)
			Me.nGroupBox3.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default
			Me.nGroupBox3.TabIndex = 2
			Me.nGroupBox3.TabStop = False
			Me.nGroupBox3.Text = "nGroupBox3"
			' 
			' nRadioButton2
			' 
			Me.nRadioButton2.Location = New System.Drawing.Point(120, 56)
			Me.nRadioButton2.Name = "nRadioButton2"
			Me.nRadioButton2.TabIndex = 2
			Me.nRadioButton2.Text = "nRadioButton2"
			' 
			' nRadioButton1
			' 
			Me.nRadioButton1.Location = New System.Drawing.Point(8, 56)
			Me.nRadioButton1.Name = "nRadioButton1"
			Me.nRadioButton1.TabIndex = 1
			Me.nRadioButton1.Text = "nRadioButton1"
			' 
			' nhScrollBar1
			' 
			Me.nhScrollBar1.Location = New System.Drawing.Point(8, 24)
			Me.nhScrollBar1.Name = "nhScrollBar1"
			Me.nhScrollBar1.Size = New System.Drawing.Size(216, 17)
			Me.nhScrollBar1.TabIndex = 0
			Me.nhScrollBar1.Text = "nhScrollBar1"
			' 
			' nGroupBox4
			' 
			Me.nGroupBox4.Controls.Add(Me.nOptionButton1)
			Me.nGroupBox4.Controls.Add(Me.nTextBox1)
			Me.nGroupBox4.ImageIndex = 0
			Me.nGroupBox4.Location = New System.Drawing.Point(8, 328)
			Me.nGroupBox4.Name = "nGroupBox4"
			Me.nGroupBox4.Size = New System.Drawing.Size(240, 96)
			Me.nGroupBox4.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default
			Me.nGroupBox4.TabIndex = 3
			Me.nGroupBox4.TabStop = False
			Me.nGroupBox4.Text = "nGroupBox4"
			Me.nGroupBox4.TextOrigin = 50
			' 
			' nOptionButton1
			' 
			Me.nOptionButton1.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nComboBoxCommand1, Me.nCommand1})
			Me.nOptionButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nOptionButton1.ImageIndex = 16
			Me.nOptionButton1.ImageList = Me.m_ImageList
			Me.nOptionButton1.Location = New System.Drawing.Point(8, 56)
			Me.nOptionButton1.Name = "nOptionButton1"
			Me.nOptionButton1.Size = New System.Drawing.Size(160, 23)
			Me.nOptionButton1.TabIndex = 1
			Me.nOptionButton1.Text = "nOptionButton1"
			' 
			' nComboBoxCommand1
			' 
			Me.nComboBoxCommand1.ControlText = ""
			Me.nComboBoxCommand1.Properties.ImageList = Me.m_ImageList
			Me.nComboBoxCommand1.Properties.Text = "nComboBoxCommand1"
			Me.nComboBoxCommand1.Items.AddRange(New Nevron.UI.WinForm.Controls.NListBoxItem() { New Nevron.UI.WinForm.Controls.NListBoxItem(0, Nothing, False), New Nevron.UI.WinForm.Controls.NListBoxItem(1, Nothing, False), New Nevron.UI.WinForm.Controls.NListBoxItem(2, Nothing, False)})
			' 
			' m_ImageList
			' 
			Me.m_ImageList.ImageSize = New System.Drawing.Size(16, 16)
			Me.m_ImageList.ImageStream = (CType(resources.GetObject("m_ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.m_ImageList.TransparentColor = System.Drawing.Color.Transparent
			' 
			' nCommand1
			' 
			Me.nCommand1.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nComboBoxCommand2, Me.nCommand2})
			Me.nCommand1.Properties.Text = "nCommand1"
			' 
			' nComboBoxCommand2
			' 
			Me.nComboBoxCommand2.ControlText = ""
			Me.nComboBoxCommand2.Editable = True
			Me.nComboBoxCommand2.Properties.ImageList = Me.m_ImageList
			Me.nComboBoxCommand2.Properties.Text = "nComboBoxCommand2"
			Me.nComboBoxCommand2.Items.AddRange(New Nevron.UI.WinForm.Controls.NListBoxItem() { New Nevron.UI.WinForm.Controls.NListBoxItem(3, Nothing, False), New Nevron.UI.WinForm.Controls.NListBoxItem(4, Nothing, False), New Nevron.UI.WinForm.Controls.NListBoxItem(5, Nothing, False)})
			' 
			' nCommand2
			' 
			Me.nCommand2.Properties.ImageIndex = 0
			Me.nCommand2.Properties.ImageList = Me.m_ImageList
			Me.nCommand2.Properties.Text = "nCommand2"
			' 
			' nTextBox1
			' 
			Me.nTextBox1.Location = New System.Drawing.Point(8, 24)
			Me.nTextBox1.Name = "nTextBox1"
			Me.nTextBox1.TabIndex = 0
			Me.nTextBox1.Text = "nTextBox1"
			' 
			' NGroupBoxUC
			' 
			Me.Controls.Add(Me.nGroupBox4)
			Me.Controls.Add(Me.nGroupBox3)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Name = "NGroupBoxUC"
			Me.Size = New System.Drawing.Size(264, 440)
			Me.nGroupBox1.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			Me.nGroupBox3.ResumeLayout(False)
			Me.nGroupBox4.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox4 As Nevron.UI.WinForm.Controls.NGroupBox
		Friend m_ImageList As System.Windows.Forms.ImageList
		Private nhScrollBar1 As Nevron.UI.WinForm.Controls.NHScrollBar
		Private nRadioButton1 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nRadioButton2 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nTextBox1 As Nevron.UI.WinForm.Controls.NTextBox
		Private nOptionButton1 As Nevron.UI.WinForm.Controls.NOptionButton
		Private nComboBoxCommand1 As Nevron.UI.WinForm.Controls.NComboBoxCommand
		Private nCommand1 As Nevron.UI.WinForm.Controls.NCommand
		Private nComboBoxCommand2 As Nevron.UI.WinForm.Controls.NComboBoxCommand
		Private nColorBar1 As Nevron.UI.WinForm.Controls.NColorBar
		Private nButton1 As Nevron.UI.WinForm.Controls.NButton
		Private nColorButton1 As Nevron.UI.WinForm.Controls.NColorButton
		Private nColorPool1 As Nevron.UI.WinForm.Controls.NColorPool
		Private nCommand2 As Nevron.UI.WinForm.Controls.NCommand
		Private nLuminanceBar1 As Nevron.UI.WinForm.Controls.NLuminanceBar
		Private components As System.ComponentModel.IContainer

		#End Region
	End Class
End Namespace

