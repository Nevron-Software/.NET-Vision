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
	Public Class NCustomPaintingUsingNevronDeviceUC
		Inherits NCustomPaintingBase

		Private WithEvents ShowEqualSignsCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowUpwardArrows As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowDownwardArrows As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ChangeDataButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.ShowEqualSignsCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowUpwardArrows = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowDownwardArrows = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ChangeDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' ShowEqualSignsCheckBox
			' 
			Me.ShowEqualSignsCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowEqualSignsCheckBox.Location = New System.Drawing.Point(6, 69)
			Me.ShowEqualSignsCheckBox.Name = "ShowEqualSignsCheckBox"
			Me.ShowEqualSignsCheckBox.Size = New System.Drawing.Size(144, 24)
			Me.ShowEqualSignsCheckBox.TabIndex = 2
			Me.ShowEqualSignsCheckBox.Text = "Show equal signs"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowEqualSignsCheckBox.CheckedChanged += new System.EventHandler(this.ShowEqualSignsCheckBox_CheckedChanged);
			' 
			' ShowUpwardArrows
			' 
			Me.ShowUpwardArrows.ButtonProperties.BorderOffset = 2
			Me.ShowUpwardArrows.Location = New System.Drawing.Point(6, 37)
			Me.ShowUpwardArrows.Name = "ShowUpwardArrows"
			Me.ShowUpwardArrows.Size = New System.Drawing.Size(144, 24)
			Me.ShowUpwardArrows.TabIndex = 1
			Me.ShowUpwardArrows.Text = "Show upward arrows"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowUpwardArrows.CheckedChanged += new System.EventHandler(this.ShowUpwardArrows_CheckedChanged);
			' 
			' ShowDownwardArrows
			' 
			Me.ShowDownwardArrows.ButtonProperties.BorderOffset = 2
			Me.ShowDownwardArrows.Location = New System.Drawing.Point(6, 5)
			Me.ShowDownwardArrows.Name = "ShowDownwardArrows"
			Me.ShowDownwardArrows.Size = New System.Drawing.Size(144, 24)
			Me.ShowDownwardArrows.TabIndex = 0
			Me.ShowDownwardArrows.Text = "Show downward arrows"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowDownwardArrows.CheckedChanged += new System.EventHandler(this.ShowDownwardArrows_CheckedChanged);
			' 
			' ChangeDataButton
			' 
			Me.ChangeDataButton.Location = New System.Drawing.Point(6, 101)
			Me.ChangeDataButton.Name = "ChangeDataButton"
			Me.ChangeDataButton.Size = New System.Drawing.Size(168, 23)
			Me.ChangeDataButton.TabIndex = 3
			Me.ChangeDataButton.Text = "Change data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
			' 
			' NCustomPaintingUsingNevronDeviceUC
			' 
			Me.Controls.Add(Me.ShowEqualSignsCheckBox)
			Me.Controls.Add(Me.ShowUpwardArrows)
			Me.Controls.Add(Me.ShowDownwardArrows)
			Me.Controls.Add(Me.ChangeDataButton)
			Me.Name = "NCustomPaintingUsingNevronDeviceUC"
			Me.Size = New System.Drawing.Size(180, 432)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			ConfigureChart("Custom Painting with Nevron Device")

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
			Dim graphics As NGraphics = eventArgs.Graphics
			Dim dPreviousValue, dCurrentValue As Double

			Dim horzAxis As NAxis = m_Chart.Axis(StandardAxis.PrimaryX)
			Dim vertAxis As NAxis = m_Chart.Axis(StandardAxis.PrimaryY)

			Dim vecClientPoint As New NVector3DF()
			Dim vecModelPoint As New NVector3DF()

			Dim nBarSize As Integer = CInt(m_Chart.ContentArea.Width * CInt(Fix(m_Bar.WidthPercent))) \ (m_nBarCount * 200)

			' init pens and brushes
			Dim rectStrokeStyle As New NStrokeStyle(1, Color.DarkBlue)
			Dim rectFillStyle As NFillStyle = New NGradientFillStyle(Color.FromArgb(125, Color.LightBlue), Color.FromArgb(125, Color.DarkBlue))

			Dim lightingImageFilter As New NLightingImageFilter()

			Dim positiveArrowStrokeStyle As New NStrokeStyle(1, Color.DarkGreen)
			Dim positiveArrowFillStyle As NFillStyle = New NGradientFillStyle(Color.Green, Color.DarkGreen)
			positiveArrowFillStyle.ImageFiltersStyle.Filters.Add(lightingImageFilter)

			Dim equalSignStrokeStyle As New NStrokeStyle(1, Color.DarkGray)
			Dim equalSignFillStyle As NFillStyle = New NGradientFillStyle(Color.Gray, Color.DarkGray)
			positiveArrowFillStyle.ImageFiltersStyle.Filters.Add(lightingImageFilter)

			Dim negativeArrowStrokeStyle As New NStrokeStyle(1, Color.DarkRed)
			Dim negativeArrowFillStyle As NFillStyle = New NGradientFillStyle(Color.Red, Color.DarkRed)
			positiveArrowFillStyle.ImageFiltersStyle.Filters.Add(lightingImageFilter)

			For i As Integer = 1 To m_Bar.Values.Count - 1
				dPreviousValue = DirectCast(m_Bar.Values(i - 1), Double)
				dCurrentValue = DirectCast(m_Bar.Values(i), Double)

				vecModelPoint.X = horzAxis.TransformScaleToModel(False, i)
				vecModelPoint.Y = vertAxis.TransformScaleToModel(False, CSng(DirectCast(m_Bar.Values(i), Double)))
				vecModelPoint.Z = 0

                If m_Chart.TransformModelToClient(vecModelPoint, vecClientPoint) Then
                    Dim rcArrowRect As New RectangleF(vecClientPoint.X - nBarSize, vecClientPoint.Y - nBarSize, 2 * nBarSize, 2 * nBarSize)

                    If rcArrowRect.Width > 0 AndAlso rcArrowRect.Height > 0 AndAlso DisplayMark(dCurrentValue, dPreviousValue) Then
                        ' draw arrow background
                        Dim path As GraphicsPath = GetRoundRectanglePath(rcArrowRect)

                        graphics.PaintPath(rectFillStyle, rectStrokeStyle, path)

                        path.Dispose()

                        rcArrowRect.Inflate(-5, -5)

                        ' draw the arrow itself
                        If rcArrowRect.Width > 0 AndAlso rcArrowRect.Height > 0 Then
                            If dCurrentValue < dPreviousValue Then
                                ' draw negative arrow
                                path = GetArrowPath(rcArrowRect, False)

                                graphics.PaintPath(negativeArrowFillStyle, negativeArrowStrokeStyle, path)

                                path.Dispose()
                            ElseIf dCurrentValue > dPreviousValue Then
                                ' draw positive arrow
                                path = GetArrowPath(rcArrowRect, True)

                                graphics.PaintPath(positiveArrowFillStyle, positiveArrowStrokeStyle, path)

                                path.Dispose()
                            Else
                                ' draw equal sign
                                Dim rect As New NRectangleF(rcArrowRect.Left, rcArrowRect.Top, rcArrowRect.Width, rcArrowRect.Height / 3.0F)

                                graphics.PaintRectangle(equalSignFillStyle, equalSignStrokeStyle, rect)

                                rect = New NRectangleF(rcArrowRect.Left, rcArrowRect.Bottom - rect.Height, rcArrowRect.Width, rect.Height)

                                graphics.PaintRectangle(equalSignFillStyle, equalSignStrokeStyle, rect)
                            End If
                        End If
                    End If
                End If
			Next i
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

		Private Sub ShowDownwardArrows_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowDownwardArrows.CheckedChanged
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowUpwardArrows_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowUpwardArrows.CheckedChanged
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowEqualSignsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowEqualSignsCheckBox.CheckedChanged
			nChartControl1.Refresh()
		End Sub

		Private Sub ChangeDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeDataButton.Click
			ChangeData()
		End Sub
	End Class
End Namespace
