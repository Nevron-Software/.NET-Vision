Imports Microsoft.VisualBasic
Imports System
Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NSystemImagesUC
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (Not components Is Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.smallImages = New Nevron.UI.WinForm.Controls.NGalleryPanel()
			Me.label1 = New System.Windows.Forms.Label()
			Me.largeImages = New Nevron.UI.WinForm.Controls.NGalleryPanel()
			Me.label2 = New System.Windows.Forms.Label()
			CType(Me.smallImages, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.largeImages, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' smallImages
			' 
			Me.smallImages.Location = New System.Drawing.Point(3, 26)
			Me.smallImages.Name = "smallImages"
			Me.smallImages.Size = New System.Drawing.Size(300, 300)
			Me.smallImages.TabIndex = 0
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(0, 5)
			Me.label1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(72, 13)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Small Images:"
			' 
			' largeImages
			' 
			Me.largeImages.Location = New System.Drawing.Point(309, 26)
			Me.largeImages.Name = "largeImages"
			Me.largeImages.Size = New System.Drawing.Size(300, 300)
			Me.largeImages.TabIndex = 2
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(306, 5)
			Me.label2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(74, 13)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Large Images:"
			' 
			' NSystemImagesUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.largeImages)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.smallImages)
			Me.Name = "NSystemImagesUC"
			Me.Size = New System.Drawing.Size(628, 343)
			CType(Me.smallImages, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.largeImages, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private smallImages As Nevron.UI.WinForm.Controls.NGalleryPanel
		Private label1 As System.Windows.Forms.Label
		Private largeImages As Nevron.UI.WinForm.Controls.NGalleryPanel
		Private label2 As System.Windows.Forms.Label
	End Class
End Namespace
