Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports System.IO
Imports Nevron.Serialization
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NPrintedChartAppearanceUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Pie As NPieSeries

		Private WithEvents PrintPreviewButton As Nevron.UI.WinForm.Controls.NButton
		Private PrintButton As Nevron.UI.WinForm.Controls.NButton
		Private PrintBackgroundFrameCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private FillStyleGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private ConvertToGrayScaleRadioButton As Nevron.UI.WinForm.Controls.NRadioButton
		Private radioButton3 As Nevron.UI.WinForm.Controls.NRadioButton
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
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
			Me.PrintPreviewButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.PrintButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.PrintBackgroundFrameCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.FillStyleGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.radioButton3 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.ConvertToGrayScaleRadioButton = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.FillStyleGroupBox.SuspendLayout()
			Me.SuspendLayout()
			' 
			' PrintPreviewButton
			' 
			Me.PrintPreviewButton.Location = New System.Drawing.Point(8, 136)
			Me.PrintPreviewButton.Name = "PrintPreviewButton"
			Me.PrintPreviewButton.Size = New System.Drawing.Size(165, 23)
			Me.PrintPreviewButton.TabIndex = 2
			Me.PrintPreviewButton.Text = "Print Preview..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PrintPreviewButton.Click += new System.EventHandler(this.PrintPreviewButton_Click);
			' 
			' PrintButton
			' 
			Me.PrintButton.Location = New System.Drawing.Point(8, 168)
			Me.PrintButton.Name = "PrintButton"
			Me.PrintButton.Size = New System.Drawing.Size(165, 23)
			Me.PrintButton.TabIndex = 3
			Me.PrintButton.Text = "Print"
			' 
			' PrintBackgroundFrameCheckBox
			' 
			Me.PrintBackgroundFrameCheckBox.ButtonProperties.BorderOffset = 2
			Me.PrintBackgroundFrameCheckBox.Location = New System.Drawing.Point(8, 104)
			Me.PrintBackgroundFrameCheckBox.Name = "PrintBackgroundFrameCheckBox"
			Me.PrintBackgroundFrameCheckBox.Size = New System.Drawing.Size(144, 24)
			Me.PrintBackgroundFrameCheckBox.TabIndex = 1
			Me.PrintBackgroundFrameCheckBox.Text = "Print background frame"
			' 
			' FillStyleGroupBox
			' 
			Me.FillStyleGroupBox.Controls.Add(Me.radioButton3)
			Me.FillStyleGroupBox.Controls.Add(Me.ConvertToGrayScaleRadioButton)
			Me.FillStyleGroupBox.Location = New System.Drawing.Point(8, 8)
			Me.FillStyleGroupBox.Name = "FillStyleGroupBox"
			Me.FillStyleGroupBox.Size = New System.Drawing.Size(144, 88)
			Me.FillStyleGroupBox.TabIndex = 0
			Me.FillStyleGroupBox.TabStop = False
			Me.FillStyleGroupBox.Text = "Fill styles"
			' 
			' radioButton3
			' 
			Me.radioButton3.ButtonProperties.BorderOffset = 2
			Me.radioButton3.Checked = True
			Me.radioButton3.Location = New System.Drawing.Point(8, 56)
			Me.radioButton3.Name = "radioButton3"
			Me.radioButton3.Size = New System.Drawing.Size(112, 24)
			Me.radioButton3.TabIndex = 1
			Me.radioButton3.TabStop = True
			Me.radioButton3.Text = "Grayscale (hatch)"
			' 
			' ConvertToGrayScaleRadioButton
			' 
			Me.ConvertToGrayScaleRadioButton.ButtonProperties.BorderOffset = 2
			Me.ConvertToGrayScaleRadioButton.Location = New System.Drawing.Point(8, 24)
			Me.ConvertToGrayScaleRadioButton.Name = "ConvertToGrayScaleRadioButton"
			Me.ConvertToGrayScaleRadioButton.Size = New System.Drawing.Size(104, 24)
			Me.ConvertToGrayScaleRadioButton.TabIndex = 0
			Me.ConvertToGrayScaleRadioButton.Text = "Grayscale"
			' 
			' NPrintedChartAppearanceUC
			' 
			Me.Controls.Add(Me.FillStyleGroupBox)
			Me.Controls.Add(Me.PrintBackgroundFrameCheckBox)
			Me.Controls.Add(Me.PrintButton)
			Me.Controls.Add(Me.PrintPreviewButton)
			Me.Name = "NPrintedChartAppearanceUC"
			Me.Size = New System.Drawing.Size(180, 384)
			Me.FillStyleGroupBox.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Printed Chart Appearance")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.BottomRight)

			m_Chart = New NPieChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(m_Chart)
			m_Chart.Depth = 18
			m_Chart.DisplayOnLegend = nChartControl1.Legends(0)

			m_Pie = CType(m_Chart.Series.Add(SeriesType.Pie), NPieSeries)
			m_Pie.BorderStyle.Color = Color.LemonChiffon

			m_Pie.AddDataPoint(New NDataPoint(24, "Cars", New NColorFillStyle(Color.FromArgb(169,121,11))))
			m_Pie.AddDataPoint(New NDataPoint(18, "Airplanes", New NColorFillStyle(Color.FromArgb(157,157,92))))
			m_Pie.AddDataPoint(New NDataPoint(32, "Trains", New NColorFillStyle(Color.FromArgb(98,152,92))))
			m_Pie.AddDataPoint(New NDataPoint(23, "Ships", New NColorFillStyle(Color.FromArgb(111,134,181))))
			m_Pie.AddDataPoint(New NDataPoint(19, "Buses", New NColorFillStyle(Color.FromArgb(179,63,92))))

			m_Pie.Legend.Mode = SeriesLegendMode.DataPoints
			m_Pie.Legend.Format = "<label> <percent>"
		End Sub

		Private Function CreateModifiedChartControl() As NChartControl
			' create a duplicate of this chart control
			Dim memoryStream As New MemoryStream()
			nChartControl1.Serializer.SaveControlStateToStream(memoryStream, PersistencyFormat.Binary, Nothing)

			memoryStream.Seek(0, SeekOrigin.Begin)
			Dim chartControl As New NChartControl()
			chartControl.Serializer.LoadControlStateFromStream(memoryStream, PersistencyFormat.Binary, Nothing)

			Dim fillStyleConverter As INObjectConverter = Nothing

			' apply a chart attribute converter
			If ConvertToGrayScaleRadioButton.Checked Then
				fillStyleConverter = New NFillStyleToGrayScaleConverter()
			Else
				fillStyleConverter = New NFillStyleColorToHatchConverter()
			End If

			Dim converters() As INObjectConverter = { fillStyleConverter, New NStrokeStyleToGrayScaleConverter(), New NShadowStyleToGrayScaleConverter(), New NLightModelToGrayScaleConverter() }


			Dim grayScaleConverter As New NNodeTreeAttributeConverter()
			grayScaleConverter.Converters = converters
			grayScaleConverter.Convert(chartControl.Document)

			If PrintBackgroundFrameCheckBox.Checked = False Then
				Dim standardFrameStyle As New NStandardFrameStyle()
				standardFrameStyle.InnerBorderWidth = New NLength(0)

				chartControl.BackgroundStyle.FrameStyle = standardFrameStyle
			End If

			chartControl.Refresh()

			Return chartControl
		End Function

		Private Sub PrintPreviewButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrintPreviewButton.Click
			Dim chartControl As NChartControl = CreateModifiedChartControl()

			chartControl.PrintManager.ShowPrintPreview()
		End Sub
	End Class
End Namespace
