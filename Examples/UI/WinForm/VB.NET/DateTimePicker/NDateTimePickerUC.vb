Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.Interop.Win32
Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for DateTimePickerUC.
	''' </summary>
	Public Class NDateTimePickerUC
		Inherits NExampleUserControl
		#Region "Constructor"

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
			MyBase.Initialize ()
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub borderBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles borderBtn.Click
			Me.dateTimePicker1.Border.ShowEditor()
		End Sub
		Private Sub nCheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nCheckBox1.CheckedChanged
			Me.dateTimePicker1.ShowUpDown = nCheckBox1.Checked
		End Sub
		Private Sub nCheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nCheckBox2.CheckedChanged
			Me.dateTimePicker1.EnableSkinning = nCheckBox2.Checked
			Me.borderBtn.Enabled = (nCheckBox2.Checked = False)
		End Sub

		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.dateTimePicker1 = New Nevron.UI.WinForm.Controls.NDateTimePicker()
			Me.borderBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox2 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' dateTimePicker1
			' 
			Me.dateTimePicker1.BackColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(255))))), (CInt(Fix((CByte(255))))), (CInt(Fix((CByte(255))))))
			Me.dateTimePicker1.CalendarForeColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(0))))), (CInt(Fix((CByte(0))))), (CInt(Fix((CByte(0))))))
			Me.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.FromArgb((CInt(Fix((CByte(235))))), (CInt(Fix((CByte(235))))), (CInt(Fix((CByte(235))))))
			Me.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(76))))), (CInt(Fix((CByte(76))))), (CInt(Fix((CByte(76))))))
			Me.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(242))))), (CInt(Fix((CByte(242))))), (CInt(Fix((CByte(242))))))
			Me.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(127))))), (CInt(Fix((CByte(127))))), (CInt(Fix((CByte(127))))))
			Me.dateTimePicker1.ForeColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(0))))), (CInt(Fix((CByte(0))))), (CInt(Fix((CByte(0))))))
			Me.dateTimePicker1.Location = New System.Drawing.Point(8, 8)
			Me.dateTimePicker1.Name = "dateTimePicker1"
			Me.dateTimePicker1.Size = New System.Drawing.Size(200, 21)
			Me.dateTimePicker1.TabIndex = 0
			' 
			' borderBtn
			' 
			Me.borderBtn.Enabled = False
			Me.borderBtn.Location = New System.Drawing.Point(8, 81)
			Me.borderBtn.Name = "borderBtn"
			Me.borderBtn.Size = New System.Drawing.Size(80, 24)
			Me.borderBtn.TabIndex = 1
			Me.borderBtn.Text = "Border..."
'			Me.borderBtn.Click += New System.EventHandler(Me.borderBtn_Click);
			' 
			' nCheckBox1
			' 
#If VS2005 Then
			Me.nCheckBox1.AutoSize = True
#End If
			Me.nCheckBox1.ButtonProperties.BorderOffset = 2
			Me.nCheckBox1.Location = New System.Drawing.Point(8, 35)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.Size = New System.Drawing.Size(98, 17)
			Me.nCheckBox1.TabIndex = 2
			Me.nCheckBox1.Text = "Show UpDown"
'			Me.nCheckBox1.CheckedChanged += New System.EventHandler(Me.nCheckBox1_CheckedChanged);
			' 
			' nCheckBox2
			' 
#If VS2005 Then
			Me.nCheckBox1.AutoSize = True
#End If
			Me.nCheckBox2.ButtonProperties.BorderOffset = 2
			Me.nCheckBox2.Checked = True
			Me.nCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox2.Location = New System.Drawing.Point(8, 58)
			Me.nCheckBox2.Name = "nCheckBox2"
			Me.nCheckBox2.Size = New System.Drawing.Size(103, 17)
			Me.nCheckBox2.TabIndex = 3
			Me.nCheckBox2.Text = "Enable Skinning"
'			Me.nCheckBox2.CheckedChanged += New System.EventHandler(Me.nCheckBox2_CheckedChanged);
			' 
			' NDateTimePickerUC
			' 
			Me.Controls.Add(Me.nCheckBox2)
			Me.Controls.Add(Me.nCheckBox1)
			Me.Controls.Add(Me.borderBtn)
			Me.Controls.Add(Me.dateTimePicker1)
			Me.Name = "NDateTimePickerUC"
			Me.Size = New System.Drawing.Size(336, 150)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents borderBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents nCheckBox1 As NCheckBox
		Private WithEvents nCheckBox2 As NCheckBox

		Private dateTimePicker1 As NDateTimePicker

		#End Region
	End Class
End Namespace
