Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Class NTreeListCustomHeaderRenderer
		Inherits NTreeListHeaderRenderer
		#Region "Constructor"

		Public Sub New()
		End Sub

		#End Region

		#Region "Overrides"

		Public Overrides Sub PaintColumnHeaderItem(ByVal context As NTreeListPaintContext, ByVal item As NTreeListColumnHeader)
			PaintCustomBackground(context, item)

			item.PaintContent(context)
			PaintSortGlyph(context, item)
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub PaintCustomBackground(ByVal context As NTreeListPaintContext, ByVal item As NTreeListColumnHeader)
			Dim bounds As NRectangle = context.PaintBounds
			bounds.Inflate(0, -1)

			Dim gdiRect As Rectangle = bounds.ToRectangle()

			Dim c1 As Color = Color.Empty
			Dim c2 As Color = Color.Empty

			Select Case item.VisualState
				Case ItemVisualState.Normal
					c1 = Color.FloralWhite
					c2 = Color.Chocolate
				Case ItemVisualState.Hot
					c1 = Color.Orange
					c2 = Color.Red
				Case ItemVisualState.Pressed
					c1 = Color.Red
					c2 = Color.Orange
			End Select

			Dim br As LinearGradientBrush = New LinearGradientBrush(gdiRect, c1, c2, 90F)

			context.Graphics.FillRectangle(br, gdiRect)

			br.Dispose()

			If item.Owner.VisibleIndex = 0 Then
				Return
			End If

			Dim p As Pen = New Pen(Color.Black)

			context.Graphics.DrawLine(p, bounds.X - 1, bounds.Y + 3, bounds.X - 1, bounds.Bottom - 4)
			p.Color = Color.Wheat
			context.Graphics.DrawLine(p, bounds.X, bounds.Y + 4, bounds.X, bounds.Bottom - 3)

			p.Dispose()
		End Sub

		#End Region
	End Class
End Namespace
