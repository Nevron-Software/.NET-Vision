Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NVectorDirectionModeUC
		Inherits NExampleBaseUC

		Private WithEvents MinVectorLengthNumericUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label4 As Label
		Private WithEvents MaxVectorLengthNumericUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label1 As Label
		Private m_Vector As NVectorSeries
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
			Me.label4 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.MaxVectorLengthNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.MinVectorLengthNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			DirectCast(Me.MaxVectorLengthNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.MinVectorLengthNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(8, 10)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(97, 13)
			Me.label4.TabIndex = 8
			Me.label4.Text = "Min Vector Length:"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(11, 65)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(100, 13)
			Me.label1.TabIndex = 10
			Me.label1.Text = "Max Vector Length:"
			' 
			' MaxVectorLengthNumericUpDown
			' 
			Me.MaxVectorLengthNumericUpDown.Location = New System.Drawing.Point(11, 82)
			Me.MaxVectorLengthNumericUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.MaxVectorLengthNumericUpDown.Name = "MaxVectorLengthNumericUpDown"
			Me.MaxVectorLengthNumericUpDown.Size = New System.Drawing.Size(151, 20)
			Me.MaxVectorLengthNumericUpDown.TabIndex = 11
			Me.MaxVectorLengthNumericUpDown.Value = New Decimal(New Integer() { 50, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MaxVectorLengthNumericUpDown.ValueChanged += new System.EventHandler(this.MaxVectorLengthNumericUpDown_ValueChanged);
			' 
			' MinVectorLengthNumericUpDown
			' 
			Me.MinVectorLengthNumericUpDown.Location = New System.Drawing.Point(8, 27)
			Me.MinVectorLengthNumericUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.MinVectorLengthNumericUpDown.Name = "MinVectorLengthNumericUpDown"
			Me.MinVectorLengthNumericUpDown.Size = New System.Drawing.Size(151, 20)
			Me.MinVectorLengthNumericUpDown.TabIndex = 9
			Me.MinVectorLengthNumericUpDown.Value = New Decimal(New Integer() { 50, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MinVectorLengthNumericUpDown.ValueChanged += new System.EventHandler(this.MinVectorLengthNumericUpDown_ValueChanged);
			' 
			' NVectorDirectionModeUC
			' 
			Me.Controls.Add(Me.MaxVectorLengthNumericUpDown)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.MinVectorLengthNumericUpDown)
			Me.Controls.Add(Me.label4)
			Me.Name = "NVectorDirectionModeUC"
			Me.Size = New System.Drawing.Size(174, 303)
			DirectCast(Me.MaxVectorLengthNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.MinVectorLengthNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("Vector Direction Mode")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			'chart.Enable3D = true;
			chart.Width = 55.0F
			chart.Height = 55.0F

			' setup X axis
			Dim linearScale As New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.RoundToTickMin = False
			linearScale.RoundToTickMax = False
			linearScale.MajorGridStyle.ShowAtWalls = New ChartWallType() { }
			linearScale.InnerMajorTickStyle.Visible = False

			' setup Y axis
			linearScale = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.RoundToTickMin = False
			linearScale.RoundToTickMax = False
			linearScale.MajorGridStyle.ShowAtWalls = New ChartWallType() { }
			linearScale.InnerMajorTickStyle.Visible = False

			' setup shape series
			m_Vector = CType(chart.Series.Add(SeriesType.Vector), NVectorSeries)
			m_Vector.FillStyle = New NColorFillStyle(Color.Red)
			m_Vector.BorderStyle.Color = Color.DarkRed
			m_Vector.DataLabelStyle.Visible = False
			m_Vector.InflateMargins = True
			m_Vector.UseXValues = True
			'm_Vector.UseZValues = true;
			m_Vector.MinArrowHeadSize = New NSizeL(2, 3)
			m_Vector.MaxArrowHeadSize = New NSizeL(4, 6)
			m_Vector.MinVectorLength = New NLength(8)
			m_Vector.MaxVectorLength = New NLength(30)
			m_Vector.Mode = VectorSeriesMode.Direction

			' fill data
			FillData(m_Vector)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			MinVectorLengthNumericUpDown.Value = CDec(m_Vector.MinVectorLength.Value)
			MaxVectorLengthNumericUpDown.Value = CDec(m_Vector.MaxVectorLength.Value)
		End Sub

		Private Sub FillData(ByVal vectorSeries As NVectorSeries)
			Dim x As Double = 0, y As Double = 0
			Dim k As Integer = 0

			For i As Integer = 0 To 9
				x = 1
				y += 1

				For j As Integer = 0 To 9
					x += 1

					Dim dx As Double = Math.Sin(x / 3.0) * Math.Cos((x - y) / 4.0)
					Dim dy As Double = Math.Cos(y / 8.0) * Math.Cos(y / 4.0)

					vectorSeries.XValues.Add(x)
					vectorSeries.Values.Add(y)
					vectorSeries.X2Values.Add(dx)
					vectorSeries.Y2Values.Add(dy)

					vectorSeries.ZValues.Add(y)
					vectorSeries.Z2Values.Add(dy)

					vectorSeries.BorderStyles(k) = New NStrokeStyle(1, ColorFromVector(dx, dy))
					k += 1
				Next j
			Next i
		End Sub
		Private Function ColorFromVector(ByVal dx As Double, ByVal dy As Double) As Color
			Dim length As Double = Math.Sqrt(dx * dx + dy * dy)

			Dim sq2 As Double = Math.Sqrt(2)

			Dim r As Integer = CInt(Math.Truncate((255 / sq2) * length))
			Dim g As Integer = 20
			Dim b As Integer = CInt(Math.Truncate((255 / sq2) * (sq2 - length)))

			Return Color.FromArgb(r, g, b)
		End Function

        Private Sub MinVectorLengthNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MinVectorLengthNumericUpDown.ValueChanged
            If m_Vector Is Nothing Then
                Return
            End If
            m_Vector.MinVectorLength = New NLength(CSng(MinVectorLengthNumericUpDown.Value), NGraphicsUnit.Point)
            nChartControl1.Refresh()
        End Sub

        Private Sub MaxVectorLengthNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MaxVectorLengthNumericUpDown.ValueChanged
            If m_Vector Is Nothing Then
                Return
            End If

            m_Vector.MaxVectorLength = New NLength(CSng(MaxVectorLengthNumericUpDown.Value), NGraphicsUnit.Point)
            nChartControl1.Refresh()
        End Sub
	End Class
End Namespace
