Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NVectorLegendScaleUC
		Inherits NExampleBaseUC

		Private m_Vector As NVectorSeries
		Private WithEvents VectorLengthScaleModeComboBox As UI.WinForm.Controls.NComboBox
		Private label1 As Label
		Private WithEvents VectorLengthScaleStepsNumericUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label2 As Label
		Private WithEvents TextOffsetNumericUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label3 As Label
		Private WithEvents TableCellOffsetNumericUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label4 As Label
		Private WithEvents RoundValuesCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents StrokeStyleButton As UI.WinForm.Controls.NButton
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
			Me.VectorLengthScaleModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.VectorLengthScaleStepsNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.TextOffsetNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.TableCellOffsetNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.RoundValuesCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.StrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			DirectCast(Me.VectorLengthScaleStepsNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.TextOffsetNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.TableCellOffsetNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' BubbleScaleModeCombo
			' 
			Me.VectorLengthScaleModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.VectorLengthScaleModeComboBox.ListProperties.DataSource = Nothing
			Me.VectorLengthScaleModeComboBox.ListProperties.DisplayMember = ""
			Me.VectorLengthScaleModeComboBox.Location = New System.Drawing.Point(10, 20)
			Me.VectorLengthScaleModeComboBox.Name = "BubbleScaleModeCombo"
			Me.VectorLengthScaleModeComboBox.Size = New System.Drawing.Size(150, 21)
			Me.VectorLengthScaleModeComboBox.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.VectorLengthScaleModeComboBox.SelectedIndexChanged += new System.EventHandler(this.VectorLengthScaleModeCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(10, 3)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(150, 16)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Bubble Scale Mode:"
			' 
			' BubbleScaleStepsUpDown
			' 
			Me.VectorLengthScaleStepsNumericUpDown.Location = New System.Drawing.Point(10, 193)
			Me.VectorLengthScaleStepsNumericUpDown.Maximum = New Decimal(New Integer() { 10, 0, 0, 0})
			Me.VectorLengthScaleStepsNumericUpDown.Minimum = New Decimal(New Integer() { 2, 0, 0, 0})
			Me.VectorLengthScaleStepsNumericUpDown.Name = "BubbleScaleStepsUpDown"
			Me.VectorLengthScaleStepsNumericUpDown.Size = New System.Drawing.Size(150, 20)
			Me.VectorLengthScaleStepsNumericUpDown.TabIndex = 5
			Me.VectorLengthScaleStepsNumericUpDown.Value = New Decimal(New Integer() { 10, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.VectorLengthScaleStepsNumericUpDown.ValueChanged += new System.EventHandler(this.VectorLengthScaleStepsUpDown_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(10, 175)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(150, 16)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Bubble Scale Steps:"
			' 
			' TextOffsetNumericUpDown
			' 
			Me.TextOffsetNumericUpDown.Location = New System.Drawing.Point(10, 76)
			Me.TextOffsetNumericUpDown.Name = "TextOffsetNumericUpDown"
			Me.TextOffsetNumericUpDown.Size = New System.Drawing.Size(150, 20)
			Me.TextOffsetNumericUpDown.TabIndex = 7
			Me.TextOffsetNumericUpDown.Value = New Decimal(New Integer() { 70, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TextOffsetNumericUpDown.ValueChanged += new System.EventHandler(this.TextOffsetNumericUpDown_ValueChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(10, 58)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(147, 16)
			Me.label3.TabIndex = 6
			Me.label3.Text = "Text Offset:"
			' 
			' TableCellOffsetNumericUpDown
			' 
			Me.TableCellOffsetNumericUpDown.Location = New System.Drawing.Point(12, 131)
			Me.TableCellOffsetNumericUpDown.Name = "TableCellOffsetNumericUpDown"
			Me.TableCellOffsetNumericUpDown.Size = New System.Drawing.Size(150, 20)
			Me.TableCellOffsetNumericUpDown.TabIndex = 9
			Me.TableCellOffsetNumericUpDown.Value = New Decimal(New Integer() { 70, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TableCellOffsetNumericUpDown.ValueChanged += new System.EventHandler(this.TableCellOffsetNumericUpDown_ValueChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(12, 113)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(147, 16)
			Me.label4.TabIndex = 8
			Me.label4.Text = "Table Cell Offset:"
			' 
			' RoundValuesCheckBox
			' 
			Me.RoundValuesCheckBox.ButtonProperties.BorderOffset = 2
			Me.RoundValuesCheckBox.Location = New System.Drawing.Point(10, 219)
			Me.RoundValuesCheckBox.Name = "RoundValuesCheckBox"
			Me.RoundValuesCheckBox.Size = New System.Drawing.Size(150, 21)
			Me.RoundValuesCheckBox.TabIndex = 38
			Me.RoundValuesCheckBox.Text = "Round Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RoundValuesCheckBox.CheckedChanged += new System.EventHandler(this.RoundValuesCheckBox_CheckedChanged);
			' 
			' StrokeStyleButton
			' 
			Me.StrokeStyleButton.Location = New System.Drawing.Point(10, 322)
			Me.StrokeStyleButton.Name = "StrokeStyleButton"
			Me.StrokeStyleButton.Size = New System.Drawing.Size(154, 24)
			Me.StrokeStyleButton.TabIndex = 39
			Me.StrokeStyleButton.Text = "Stroke Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StrokeStyleButton.Click += new System.EventHandler(this.StrokeStyleButton_Click);
			' 
			' NVectorLegendScaleUC
			' 
			Me.Controls.Add(Me.StrokeStyleButton)
			Me.Controls.Add(Me.RoundValuesCheckBox)
			Me.Controls.Add(Me.TableCellOffsetNumericUpDown)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.TextOffsetNumericUpDown)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.VectorLengthScaleStepsNumericUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.VectorLengthScaleModeComboBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NVectorLegendScaleUC"
			Me.Size = New System.Drawing.Size(180, 389)
			DirectCast(Me.VectorLengthScaleStepsNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.TextOffsetNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.TableCellOffsetNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("Vector Direction Mode")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)


			nChartControl1.Legends(0).Header.Text = "Vector Length"

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
			m_Vector.Legend.Mode = SeriesLegendMode.SeriesLogic

			' fill data
			FillData(m_Vector)

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			VectorLengthScaleModeComboBox.FillFromEnum(GetType(VectorLengthScaleMode))
			VectorLengthScaleModeComboBox.SelectedIndex = CInt(m_Vector.VectorLengthScale.Mode)
			TextOffsetNumericUpDown.Value = CDec(m_Vector.VectorLengthScale.TextOffset.Value)
			TableCellOffsetNumericUpDown.Value = CDec(m_Vector.VectorLengthScale.TableCellOffset.Value)
			VectorLengthScaleStepsNumericUpDown.Value = CDec(m_Vector.VectorLengthScale.Steps)
			RoundValuesCheckBox.Checked = m_Vector.VectorLengthScale.RoundValues

			VectorLengthScaleModeCombo_SelectedIndexChanged(Nothing, Nothing)
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


        Private Sub VectorLengthScaleModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles VectorLengthScaleModeComboBox.SelectedIndexChanged
            If m_Vector Is Nothing Then
                Return
            End If

            m_Vector.VectorLengthScale.Mode = CType(VectorLengthScaleModeComboBox.SelectedIndex, VectorLengthScaleMode)

            Select Case m_Vector.VectorLengthScale.Mode
                Case VectorLengthScaleMode.LeftToRight, VectorLengthScaleMode.RightToLeft
                    m_Vector.VectorLengthScale.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center
                    m_Vector.VectorLengthScale.TextStyle.StringFormatStyle.VertAlign = VertAlign.Top
                Case VectorLengthScaleMode.TopToBottom, VectorLengthScaleMode.BottomToTop
                    m_Vector.VectorLengthScale.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Right
                    m_Vector.VectorLengthScale.TextStyle.StringFormatStyle.VertAlign = VertAlign.Center
            End Select

            nChartControl1.Refresh()
        End Sub

        Private Sub TextOffsetNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextOffsetNumericUpDown.ValueChanged
            If m_Vector Is Nothing Then
                Return
            End If

            m_Vector.VectorLengthScale.TextOffset = New NLength(CInt(Math.Truncate(TextOffsetNumericUpDown.Value)))
            nChartControl1.Refresh()
        End Sub

        Private Sub TableCellOffsetNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TableCellOffsetNumericUpDown.ValueChanged
            If m_Vector Is Nothing Then
                Return
            End If

            m_Vector.VectorLengthScale.TableCellOffset = New NLength(CInt(Math.Truncate(TableCellOffsetNumericUpDown.Value)))
            nChartControl1.Refresh()
        End Sub

        Private Sub VectorLengthScaleStepsUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles VectorLengthScaleStepsNumericUpDown.ValueChanged
            If m_Vector Is Nothing Then
                Return
            End If

            m_Vector.VectorLengthScale.Steps = CInt(Math.Truncate(VectorLengthScaleStepsNumericUpDown.Value))
            nChartControl1.Refresh()
        End Sub

        Private Sub RoundValuesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RoundValuesCheckBox.CheckedChanged
            If m_Vector Is Nothing Then
                Return
            End If

            m_Vector.VectorLengthScale.RoundValues = RoundValuesCheckBox.Checked
            nChartControl1.Refresh()
        End Sub

		Private Sub StrokeStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StrokeStyleButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Vector.VectorLengthScale.StrokeStyle, strokeStyleResult) Then
				m_Vector.VectorLengthScale.StrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
