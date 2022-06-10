Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports System.Diagnostics

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NQuickPointUC
		Inherits NExampleBaseUC

		Private m_QuickPoint As NQuickPointSeries
		Private WithEvents UseHardwareAccelerationCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents ChangeDataButton As UI.WinForm.Controls.NButton
		Private label1 As Label
		Private WithEvents MaxPointCountCombo As UI.WinForm.Controls.NComboBox
		Private WithEvents Enable3DCheckBox As UI.WinForm.Controls.NCheckBox
		Private components As IContainer

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
			Me.UseHardwareAccelerationCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ChangeDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.MaxPointCountCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.Enable3DCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' UseHardwareAccelerationCheckBox
			' 
			Me.UseHardwareAccelerationCheckBox.ButtonProperties.BorderOffset = 2
			Me.UseHardwareAccelerationCheckBox.Location = New System.Drawing.Point(7, 88)
			Me.UseHardwareAccelerationCheckBox.Name = "UseHardwareAccelerationCheckBox"
			Me.UseHardwareAccelerationCheckBox.Size = New System.Drawing.Size(170, 24)
			Me.UseHardwareAccelerationCheckBox.TabIndex = 7
			Me.UseHardwareAccelerationCheckBox.Text = "Use Hardware Acceleration"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UseHardwareAccelerationCheckBox.CheckedChanged += new System.EventHandler(this.UseHardwareAccelerationCheckBox_CheckedChanged);
			' 
			' ChangeDataButton
			' 
			Me.ChangeDataButton.Location = New System.Drawing.Point(7, 58)
			Me.ChangeDataButton.Name = "ChangeDataButton"
			Me.ChangeDataButton.Size = New System.Drawing.Size(153, 23)
			Me.ChangeDataButton.TabIndex = 9
			Me.ChangeDataButton.Text = "Change Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(7, 15)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(172, 21)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Max Point Count:"
			' 
			' MaxPointCountCombo
			' 
			Me.MaxPointCountCombo.ListProperties.CheckBoxDataMember = ""
			Me.MaxPointCountCombo.ListProperties.DataSource = Nothing
			Me.MaxPointCountCombo.ListProperties.DisplayMember = ""
			Me.MaxPointCountCombo.Location = New System.Drawing.Point(7, 32)
			Me.MaxPointCountCombo.Name = "MaxPointCountCombo"
			Me.MaxPointCountCombo.Size = New System.Drawing.Size(153, 21)
			Me.MaxPointCountCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MaxPointCountCombo.SelectedIndexChanged += new System.EventHandler(this.MaxPointCountCombo_SelectedIndexChanged);
			' 
			' Enable3DCheckBox
			' 
			Me.Enable3DCheckBox.ButtonProperties.BorderOffset = 2
			Me.Enable3DCheckBox.Location = New System.Drawing.Point(7, 118)
			Me.Enable3DCheckBox.Name = "Enable3DCheckBox"
			Me.Enable3DCheckBox.Size = New System.Drawing.Size(170, 24)
			Me.Enable3DCheckBox.TabIndex = 10
			Me.Enable3DCheckBox.Text = "Enable 3D"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Enable3DCheckBox.CheckedChanged += new System.EventHandler(this.Enable3DCheckBox_CheckedChanged);
			' 
			' NQuickPointUC
			' 
			Me.Controls.Add(Me.Enable3DCheckBox)
			Me.Controls.Add(Me.ChangeDataButton)
			Me.Controls.Add(Me.UseHardwareAccelerationCheckBox)
			Me.Controls.Add(Me.MaxPointCountCombo)
			Me.Controls.Add(Me.label1)
			Me.Name = "NQuickPointUC"
			Me.Size = New System.Drawing.Size(180, 320)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Quick Point Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' setup chart
			Dim m_Chart As NChart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			m_Chart.Width = 50
			m_Chart.Height = 50
			m_Chart.Depth = 50
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)

			' add interlace stripe
			Dim s As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = CreateScale(New ChartWallType() { ChartWallType.Back, ChartWallType.Left })
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = CreateScale(New ChartWallType() { ChartWallType.Back, ChartWallType.Floor })
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = CreateScale(New ChartWallType() { ChartWallType.Left, ChartWallType.Floor })
			m_Chart.Axis(StandardAxis.Depth).Visible = True

			' setup point series
			m_QuickPoint = New NQuickPointSeries()
			m_Chart.Series.Add(m_QuickPoint)
			m_QuickPoint.Name = "Point Series"
			m_QuickPoint.InflateMargins = True
			m_QuickPoint.UseXValues = True
			m_QuickPoint.UseZValues = True
			m_QuickPoint.Size = New NLength(1)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			nChartControl1.Settings.RenderSurface = RenderSurface.Window

			MaxPointCountCombo.Items.Add("10K")
			MaxPointCountCombo.Items.Add("100K")
			MaxPointCountCombo.Items.Add("500K")
			MaxPointCountCombo.SelectedIndex = 1

			UseHardwareAccelerationCheckBox.Checked = True
			Enable3DCheckBox.Checked = True
		End Sub

		Private Function CreateScale(ByVal stripeWalls() As ChartWallType) As NLinearScaleConfigurator
			' add interlace stripe
			Dim linearScale As New NLinearScaleConfigurator()
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True

			For i As Integer = 0 To stripeWalls.Length - 1
				stripStyle.SetShowAtWall(stripeWalls(i), True)
			Next i

			linearScale.StripStyles.Add(stripStyle)

			Return linearScale
		End Function

		Private Function GetPointCount() As Integer
			Select Case MaxPointCountCombo.SelectedIndex
				Case 0
					Return 10000
				Case 1
					Return 100000
				Case 2
					Return 500000
				Case Else
					Debug.Assert(False)
					Return 1000
			End Select
		End Function

		Private Sub UseHardwareAccelerationCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles UseHardwareAccelerationCheckBox.CheckedChanged
			nChartControl1.Settings.RenderSurface = If(UseHardwareAccelerationCheckBox.Checked, RenderSurface.Window, RenderSurface.Bitmap)
		End Sub

		Private Sub MaxPointCountCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MaxPointCountCombo.SelectedIndexChanged
			ChangeDataButton_Click(Nothing, Nothing)
		End Sub

		Private Sub ChangeDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ChangeDataButton.Click
			Dim rand As Random = New System.Random()

			Dim pointCount As Integer = GetPointCount()

			m_QuickPoint.Values.Clear()
			m_QuickPoint.XValues.Clear()
			m_QuickPoint.ZValues.Clear()
			m_QuickPoint.Colors.Clear()

			Dim lastIndex As Integer = m_QuickPoint.Values.Count

			Dim groupCount As Integer = 20
			Dim groupPointCount As Integer = pointCount \ groupCount

			For group As Integer = 0 To groupCount - 1
				Dim centerX As Double = rand.Next(1000000) \ 1000
				Dim centerY As Double = rand.Next(1000000) \ 1000
				Dim centerZ As Double = rand.Next(1000000) \ 1000

				Dim radius As Integer = rand.Next(1000000) \ 1000 + 200
				Dim color As Color = System.Drawing.Color.FromArgb(CByte(rand.Next(255)), CByte(rand.Next(255)), CByte(rand.Next(255)))

				For i As Integer = 0 To groupPointCount - 1
					Dim pitch As Double = rand.Next(100000) / 100000.0 * Math.PI * 2
					Dim latitude As Double = rand.Next(100000) / 100000.0 * Math.PI * 2
					Dim res As Double = radius * Math.Sin(pitch)


					m_QuickPoint.XValues.Add(centerY + radius * Math.Cos(pitch))
					m_QuickPoint.Values.Add(centerX + res * Math.Cos(latitude))
					m_QuickPoint.ZValues.Add(centerZ + res * Math.Sin(latitude))

					m_QuickPoint.Colors(lastIndex) = color
					lastIndex += 1
				Next i
			Next group

			nChartControl1.Refresh()
		End Sub

		Private Sub Enable3DCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Enable3DCheckBox.CheckedChanged
			m_QuickPoint.Chart.Enable3D = Enable3DCheckBox.Checked
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace