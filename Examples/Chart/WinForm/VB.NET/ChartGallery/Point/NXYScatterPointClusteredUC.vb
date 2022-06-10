﻿Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NXYScatterPointClusteredUC
		Inherits NExampleBaseUC

		Private m_Point As NPointSeries
		Private DataPointCountTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private label6 As Label
		Private WithEvents ClearDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents Add40KDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents Add20KDataButton As Nevron.UI.WinForm.Controls.NButton
		Private m_Updating As Boolean
		Public Sub New()
			InitializeComponent()
		End Sub

		Private WithEvents ClusterModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As Label
		Private WithEvents DistanceNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label4 As Label

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
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
			Me.ClusterModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.DistanceNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.DataPointCountTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.ClearDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.Add40KDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.Add20KDataButton = New Nevron.UI.WinForm.Controls.NButton()
			DirectCast(Me.DistanceNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' ClusterModeComboBox
			' 
			Me.ClusterModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.ClusterModeComboBox.ListProperties.DataSource = Nothing
			Me.ClusterModeComboBox.ListProperties.DisplayMember = ""
			Me.ClusterModeComboBox.Location = New System.Drawing.Point(5, 27)
			Me.ClusterModeComboBox.Name = "ClusterModeComboBox"
			Me.ClusterModeComboBox.Size = New System.Drawing.Size(170, 21)
			Me.ClusterModeComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ClusterModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ClusterModeComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(5, 11)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(170, 21)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Cluster Mode:"
			' 
			' DistanceNumericUpDown
			' 
			Me.DistanceNumericUpDown.DecimalPlaces = 5
			Me.DistanceNumericUpDown.Increment = New Decimal(New Integer() { 1, 0, 0, 196608})
			Me.DistanceNumericUpDown.Location = New System.Drawing.Point(5, 74)
			Me.DistanceNumericUpDown.Maximum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.DistanceNumericUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 327680})
			Me.DistanceNumericUpDown.Name = "DistanceNumericUpDown"
			Me.DistanceNumericUpDown.Size = New System.Drawing.Size(170, 20)
			Me.DistanceNumericUpDown.TabIndex = 3
			Me.DistanceNumericUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DistanceNumericUpDown.ValueChanged += new System.EventHandler(this.DistanceNumericUpDown_ValueChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(5, 58)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(146, 20)
			Me.label4.TabIndex = 2
			Me.label4.Text = "Distance Factor:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' DataPointCountTextBox
			' 
			Me.DataPointCountTextBox.Location = New System.Drawing.Point(5, 200)
			Me.DataPointCountTextBox.Name = "DataPointCountTextBox"
			Me.DataPointCountTextBox.ReadOnly = True
			Me.DataPointCountTextBox.Size = New System.Drawing.Size(170, 18)
			Me.DataPointCountTextBox.TabIndex = 7
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(5, 176)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(170, 21)
			Me.label6.TabIndex = 6
			Me.label6.Text = "Data Point Count:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' ClearDataButton
			' 
			Me.ClearDataButton.Location = New System.Drawing.Point(5, 274)
			Me.ClearDataButton.Name = "ClearDataButton"
			Me.ClearDataButton.Size = New System.Drawing.Size(170, 23)
			Me.ClearDataButton.TabIndex = 8
			Me.ClearDataButton.Text = "Clear Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ClearDataButton.Click += new System.EventHandler(this.ClearDataButton_Click);
			' 
			' Add40KDataButton
			' 
			Me.Add40KDataButton.Location = New System.Drawing.Point(5, 150)
			Me.Add40KDataButton.Name = "Add40KDataButton"
			Me.Add40KDataButton.Size = New System.Drawing.Size(170, 23)
			Me.Add40KDataButton.TabIndex = 5
			Me.Add40KDataButton.Text = "Add 40,000 Data Points"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Add40KDataButton.Click += new System.EventHandler(this.Add40KDataButton_Click);
			' 
			' Add20KDataButton
			' 
			Me.Add20KDataButton.Location = New System.Drawing.Point(5, 121)
			Me.Add20KDataButton.Name = "Add20KDataButton"
			Me.Add20KDataButton.Size = New System.Drawing.Size(170, 23)
			Me.Add20KDataButton.TabIndex = 4
			Me.Add20KDataButton.Text = "Add 20,000 Data Points"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Add20KDataButton.Click += new System.EventHandler(this.Add20KDataButton_Click);
			' 
			' NXYScatterPointClusteredUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.DataPointCountTextBox)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.ClearDataButton)
			Me.Controls.Add(Me.Add40KDataButton)
			Me.Controls.Add(Me.Add20KDataButton)
			Me.Controls.Add(Me.DistanceNumericUpDown)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.ClusterModeComboBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NXYScatterPointClusteredUC"
			Me.Size = New System.Drawing.Size(180, 450)
			DirectCast(Me.DistanceNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XY Scatter Point Clustered Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			Dim chart As NChart = nChartControl1.Charts(0)

			' setup X axis
			Dim scaleX As New NLinearScaleConfigurator()
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' setup Y axis
			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' setup point series
			m_Point = New NPointSeries()
			chart.Series.Add(m_Point)
			m_Point.DataLabelStyle.Visible = False
			m_Point.PointShape = PointShape.Bar
			m_Point.BorderStyle.Width = New NLength(0)
			m_Point.Size = New NLength(1.5F)
			m_Point.UseXValues = True
			m_Point.FillStyle = New NColorFillStyle(DarkOrange)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' Update controls 
			m_Updating = True

			ClusterModeComboBox.FillFromEnum(GetType(ClusterMode))
			ClusterModeComboBox.SelectedIndex = CInt(ClusterMode.Enabled)
			DistanceNumericUpDown.Value = CDec(0.01)

			m_Updating = False

			UpdateCluster()

			' start with 100,000 data point
			Add20KDataButton_Click(Nothing, Nothing)
		End Sub

		Private Sub UpdateCluster()
			If m_Updating Then
				Return
			End If

			m_Updating = True

			If m_Point IsNot Nothing Then
				m_Point.ClusterMode = CType(ClusterModeComboBox.SelectedIndex, ClusterMode)
				m_Point.ClusterDistanceFactor = CDbl(DistanceNumericUpDown.Value)
			End If

			If nChartControl1 IsNot Nothing Then
				nChartControl1.Refresh()
			End If

			m_Updating = False
		End Sub

		Private Sub AddNewData(ByVal count As Integer)
			Dim rand As New Random()
			Dim pointSeries As NPointSeries = m_Point

			Dim xValues(count - 1) As Double
			Dim yValues(count - 1) As Double

			Dim centerX As Double = rand.Next(20)
			Dim centerY As Double = rand.Next(20)

			For i As Integer = 0 To count - 1
				Dim u1 As Double = rand.NextDouble()
				Dim u2 As Double = rand.NextDouble()

				If u1 = 0 Then
					u1 += 0.0001
				End If

				If u2 = 0 Then
					u2 += 0.0001
				End If

				Dim z0 As Double = Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2)
				Dim z1 As Double = Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2)

				xValues(i) = centerX + z0
				yValues(i) = centerY + z1
			Next i

			pointSeries.XValues.AddRange(xValues)
			pointSeries.Values.AddRange(yValues)

			UpdateCounter()

			nChartControl1.Refresh()
		End Sub

		Private Sub UpdateCounter()
			Dim count As Integer = m_Point.Values.Count
			DataPointCountTextBox.Text = (count \ 1000).ToString() & "K"

			If count > 1000000 Then
				Add20KDataButton.Enabled = False
				Add40KDataButton.Enabled = False
			Else
				Add20KDataButton.Enabled = True
				Add40KDataButton.Enabled = True
			End If
		End Sub

		Private Sub ClusterModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ClusterModeComboBox.SelectedIndexChanged
			UpdateCluster()
		End Sub

		Private Sub DistanceNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DistanceNumericUpDown.ValueChanged
			UpdateCluster()
		End Sub

		Private Sub SampleCountNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			UpdateCluster()
		End Sub

		Private Sub SampleFactorUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			UpdateCluster()
		End Sub

		Private Sub ClusterFactorModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			UpdateCluster()
		End Sub


		Private Sub Add20KDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Add20KDataButton.Click
			AddNewData(20000)
		End Sub

		Private Sub Add40KDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Add40KDataButton.Click
			AddNewData(40000)
		End Sub

		Private Sub ClearDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ClearDataButton.Click
			m_Point.Values.Clear()
			m_Point.XValues.Clear()
			UpdateCounter()
			nChartControl1.Refresh()
		End Sub

	End Class
End Namespace
