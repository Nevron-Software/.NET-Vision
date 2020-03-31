Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.Functions

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NCustomPaintingUsingGDIPlusUC
		Inherits NCustomPaintingBase

		Private WithEvents ChangeDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ShowDownwardArrows As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowUpwardArrows As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowEqualSignsCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub


		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.ChangeDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShowDownwardArrows = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowUpwardArrows = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowEqualSignsCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' ChangeDataButton
			' 
			Me.ChangeDataButton.Location = New System.Drawing.Point(6, 101)
			Me.ChangeDataButton.Name = "ChangeDataButton"
			Me.ChangeDataButton.Size = New System.Drawing.Size(170, 23)
			Me.ChangeDataButton.TabIndex = 4
			Me.ChangeDataButton.Text = "Change data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
			' 
			' ShowDownwardArrows
			' 
			Me.ShowDownwardArrows.ButtonProperties.BorderOffset = 2
			Me.ShowDownwardArrows.Location = New System.Drawing.Point(6, 5)
			Me.ShowDownwardArrows.Name = "ShowDownwardArrows"
			Me.ShowDownwardArrows.Size = New System.Drawing.Size(146, 24)
			Me.ShowDownwardArrows.TabIndex = 0
			Me.ShowDownwardArrows.Text = "Show downward arrows"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowDownwardArrows.CheckedChanged += new System.EventHandler(this.ShowDownwardArrows_CheckedChanged);
			' 
			' ShowUpwardArrows
			' 
			Me.ShowUpwardArrows.ButtonProperties.BorderOffset = 2
			Me.ShowUpwardArrows.Location = New System.Drawing.Point(6, 37)
			Me.ShowUpwardArrows.Name = "ShowUpwardArrows"
			Me.ShowUpwardArrows.Size = New System.Drawing.Size(146, 24)
			Me.ShowUpwardArrows.TabIndex = 1
			Me.ShowUpwardArrows.Text = "Show upward arrows"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowUpwardArrows.CheckedChanged += new System.EventHandler(this.ShowUpwardArrows_CheckedChanged);
			' 
			' ShowEqualSignsCheckBox
			' 
			Me.ShowEqualSignsCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowEqualSignsCheckBox.Location = New System.Drawing.Point(6, 69)
			Me.ShowEqualSignsCheckBox.Name = "ShowEqualSignsCheckBox"
			Me.ShowEqualSignsCheckBox.Size = New System.Drawing.Size(146, 24)
			Me.ShowEqualSignsCheckBox.TabIndex = 2
			Me.ShowEqualSignsCheckBox.Text = "Show equal signs"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowEqualSignsCheckBox.CheckedChanged += new System.EventHandler(this.ShowEqualSignsCheckBox_CheckedChanged);
			' 
			' NCustomPaintingUsingGDIPlusUC
			' 
			Me.Controls.Add(Me.ShowEqualSignsCheckBox)
			Me.Controls.Add(Me.ShowUpwardArrows)
			Me.Controls.Add(Me.ShowDownwardArrows)
			Me.Controls.Add(Me.ChangeDataButton)
			Me.Name = "NCustomPaintingUsingGDIPlusUC"
			Me.Size = New System.Drawing.Size(180, 432)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			ConfigureChart("Custom Painting with GDI+")

			' configure form controls
			ShowDownwardArrows.Checked = True
			ShowUpwardArrows.Checked = True
			ShowEqualSignsCheckBox.Checked = True

			ChangeDataButton_Click(Nothing, Nothing)
		End Sub

		''' <summary>
		''' Occurs after the panel is painted.
		''' </summary>
		''' <param name="panel"></param>
		''' <param name="eventArgs"></param>
		Public Overrides Sub OnAfterPaint(ByVal panel As NPanel, ByVal eventArgs As NPanelPaintEventArgs)
			If eventArgs.Graphics Is Nothing OrElse eventArgs.Graphics.DeviceGraphics Is Nothing Then
				Return
			End If

			Dim graphics As Graphics = eventArgs.Graphics.DeviceGraphics
			Dim dPreviousValue, dCurrentValue As Double

			Dim horzAxis As NAxis = m_Chart.Axis(StandardAxis.PrimaryX)
			Dim vertAxis As NAxis = m_Chart.Axis(StandardAxis.PrimaryY)

			Dim vecClientPoint As New NVector3DF()
			Dim vecModelPoint As New NVector3DF()

			Dim nBarSize As Integer = CInt(m_Chart.ContentArea.Width * CInt(Fix(m_Bar.WidthPercent))) \ (m_nBarCount * 200)

			' init pens and brushes
			Dim penRectBorder As New Pen(Color.DarkBlue)
			Dim brushRectFill As New SolidBrush(Color.FromArgb(125, Color.LightBlue))

			Dim penPositiveArrowBorder As New Pen(Color.DarkGreen)
			Dim brushPositiveArrowFill As New SolidBrush(Color.Green)

			Dim penEqualSignBorder As New Pen(Color.DarkGray)
			Dim brushEqualSignFill As New SolidBrush(Color.Gray)

			Dim penNegativeArrowBorder As New Pen(Color.DarkRed)
			Dim brushNegativeArrowFill As New SolidBrush(Color.Red)

			For i As Integer = 1 To m_Bar.Values.Count - 1
				dPreviousValue = DirectCast(m_Bar.Values(i - 1), Double)
				dCurrentValue = DirectCast(m_Bar.Values(i), Double)

				vecModelPoint.X = horzAxis.TransformScaleToModel(False, i)
				vecModelPoint.Y = vertAxis.TransformScaleToModel(False, CSng(DirectCast(m_Bar.Values(i), Double)))
				vecModelPoint.Z = 0

                If Not m_Chart.TransformModelToClient(vecModelPoint, vecClientPoint) Then
                    Continue For
                End If

				Dim rcArrowRect As New RectangleF(vecClientPoint.X - nBarSize, vecClientPoint.Y - nBarSize, 2* nBarSize, 2 * nBarSize)

				If rcArrowRect.Width > 0 AndAlso rcArrowRect.Height > 0 AndAlso DisplayMark(dCurrentValue, dPreviousValue) Then
					' draw arrow background
					Dim path As GraphicsPath = GetRoundRectanglePath(rcArrowRect)

					graphics.FillPath(brushRectFill, path)
					graphics.DrawPath(penRectBorder, path)

					path.Dispose()

					rcArrowRect.Inflate(-5, -5)

					' draw the arrow itself
					If rcArrowRect.Width > 0 AndAlso rcArrowRect.Height > 0 Then
						If dCurrentValue < dPreviousValue Then
							' draw negative arrow
							path = GetArrowPath(rcArrowRect, False)

							graphics.FillPath(brushNegativeArrowFill, path)
							graphics.DrawPath(penNegativeArrowBorder, path)

							path.Dispose()
						ElseIf dCurrentValue > dPreviousValue Then
							' draw positive arrow
							path = GetArrowPath(rcArrowRect, True)

							graphics.FillPath(brushPositiveArrowFill, path)
							graphics.DrawPath(penPositiveArrowBorder, path)

							path.Dispose()
						Else
							' draw equal sign
							Dim rect As New RectangleF(rcArrowRect.Left, rcArrowRect.Top, rcArrowRect.Width, rcArrowRect.Height / 3.0F)

							graphics.FillRectangle(brushEqualSignFill, rect.Left, rect.Top, rect.Width, rect.Height)
							graphics.DrawRectangle(penEqualSignBorder, rect.Left, rect.Top, rect.Width, rect.Height)

							rect = New RectangleF(rcArrowRect.Left, rcArrowRect.Bottom - rect.Height, rcArrowRect.Width, rect.Height)

							graphics.FillRectangle(brushEqualSignFill, rect.Left, rect.Top, rect.Width, rect.Height)
							graphics.DrawRectangle(penEqualSignBorder, rect.Left, rect.Top, rect.Width, rect.Height)
						End If
					End If
				End If
			Next i

			' dispose pens and brushes
			penPositiveArrowBorder.Dispose()
			brushPositiveArrowFill.Dispose()

			penNegativeArrowBorder.Dispose()
			brushNegativeArrowFill.Dispose()

			brushRectFill.Dispose()
			penRectBorder.Dispose()
		End Sub

		Private Function DisplayMark(ByVal dCurrentValue As Double, ByVal dPreviousValue As Double) As Boolean
			If dCurrentValue < dPreviousValue Then
				Return ShowDownwardArrows.Checked
			ElseIf dCurrentValue > dPreviousValue Then
				Return ShowUpwardArrows.Checked
			Else
				Return ShowEqualSignsCheckBox.Checked
			End If
		End Function

		Private Sub ShowUpwardArrows_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowUpwardArrows.CheckedChanged
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowEqualSignsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowEqualSignsCheckBox.CheckedChanged
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowDownwardArrows_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowDownwardArrows.CheckedChanged
			nChartControl1.Refresh()
		End Sub

		Private Sub ChangeDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeDataButton.Click
			ChangeData()
		End Sub
	End Class
End Namespace
