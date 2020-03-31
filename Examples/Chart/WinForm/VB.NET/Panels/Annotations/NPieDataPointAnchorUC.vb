Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NPieDataPointAnchorUC
		Inherits NExampleBaseUC

		Private label1 As Label
		Private label2 As Label
		Private WithEvents DataPointIndexUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents AnchorPositionUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.DataPointIndexUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.AnchorPositionUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.ChangeDataButton = New Nevron.UI.WinForm.Controls.NButton()
			DirectCast(Me.DataPointIndexUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.AnchorPositionUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(4, 61)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(171, 20)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Data Point Index:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' DataPointIndexUpDown
			' 
			Me.DataPointIndexUpDown.Location = New System.Drawing.Point(4, 84)
			Me.DataPointIndexUpDown.Maximum = New Decimal(New Integer() { 5, 0, 0, 0})
			Me.DataPointIndexUpDown.Name = "DataPointIndexUpDown"
			Me.DataPointIndexUpDown.Size = New System.Drawing.Size(171, 20)
			Me.DataPointIndexUpDown.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DataPointIndexUpDown.ValueChanged += new System.EventHandler(this.DataPointIndexUpDown_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(4, 127)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(171, 20)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Anchor Position:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' AnchorPositionUpDown
			' 
			Me.AnchorPositionUpDown.DecimalPlaces = 2
			Me.AnchorPositionUpDown.Increment = New Decimal(New Integer() { 1, 0, 0, 131072})
			Me.AnchorPositionUpDown.Location = New System.Drawing.Point(4, 150)
			Me.AnchorPositionUpDown.Maximum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.AnchorPositionUpDown.Name = "AnchorPositionUpDown"
			Me.AnchorPositionUpDown.Size = New System.Drawing.Size(171, 20)
			Me.AnchorPositionUpDown.TabIndex = 4
			Me.AnchorPositionUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 131072})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AnchorPositionUpDown.ValueChanged += new System.EventHandler(this.AnchorPositionUpDown_ValueChanged);
			' 
			' ChangeDataButton
			' 
			Me.ChangeDataButton.Location = New System.Drawing.Point(4, 12)
			Me.ChangeDataButton.Name = "ChangeDataButton"
			Me.ChangeDataButton.Size = New System.Drawing.Size(171, 24)
			Me.ChangeDataButton.TabIndex = 0
			Me.ChangeDataButton.Text = "Change Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
			' 
			' NPieDataPointAnchorUC
			' 
			Me.Controls.Add(Me.ChangeDataButton)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.AnchorPositionUpDown)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.DataPointIndexUpDown)
			Me.Name = "NPieDataPointAnchorUC"
			Me.Size = New System.Drawing.Size(180, 262)
			DirectCast(Me.DataPointIndexUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.AnchorPositionUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' Create title label
			Dim title As New NLabel("Pie Data Point Anchor")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' Create a pie chart
			Dim chart As New NPieChart()
			chart.Enable3D = False

			' Create a pie series with 6 data points
			Dim pieSeries As New NPieSeries()
			chart.Series.Add(pieSeries)
			pieSeries.DataLabelStyle.Visible = True
			pieSeries.LabelMode = PieLabelMode.SpiderNoOverlap
			GenerateData(pieSeries)

			' Create a rounded rect callout
			Dim callout As New NRoundedRectangularCallout()
			callout.ArrowLength = New NLength(20, NGraphicsUnit.Point)
			callout.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.LightGreen))
			callout.UseAutomaticSize = True
			callout.Orientation = 80
			callout.ContentAlignment = ContentAlignment.TopLeft
			callout.Text = "Annotation"
			callout.TextStyle.FontStyle.EmSize = New NLength(8)

			' Anchor the callout to pie data point #0
'INSTANT VB NOTE: The variable anchor was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim anchor_Renamed As New NPieDataPointAnchor(pieSeries, 0, 0.8F, StringAlignment.Near)
			callout.Anchor = anchor_Renamed

			' add title and chart panels
			ConfigureStandardLayout(chart, title, Nothing)

			' add the annotation panel
			nChartControl1.Panels.Add(callout)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' init form controla
			DataPointIndexUpDown.Value = anchor_Renamed.DataPointIndex
			AnchorPositionUpDown.Value = CDec(anchor_Renamed.RadialPosition)
		End Sub

		Private Sub GenerateData(ByVal pieSeries As NPieSeries)
			Dim rand As New Random()

			pieSeries.Values.FillRandomRange(rand, 6, 1, 5)
		End Sub

		Private Sub ChangeDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ChangeDataButton.Click
			Dim pieSeries As NPieSeries = CType(nChartControl1.Charts(0).Series(0), NPieSeries)

			GenerateData(pieSeries)

			nChartControl1.Refresh()
		End Sub
		Private Sub DataPointIndexUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataPointIndexUpDown.ValueChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim callout As NRoundedRectangularCallout = TryCast(nChartControl1.Panels(2), NRoundedRectangularCallout)
			If callout Is Nothing Then
				Return
			End If

'INSTANT VB NOTE: The variable anchor was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim anchor_Renamed As NPieDataPointAnchor = TryCast(callout.Anchor, NPieDataPointAnchor)
			If anchor_Renamed Is Nothing Then
				Return
			End If

			anchor_Renamed.DataPointIndex = CInt(Fix(DataPointIndexUpDown.Value))
			nChartControl1.Refresh()
		End Sub
		Private Sub AnchorPositionUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AnchorPositionUpDown.ValueChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim callout As NRoundedRectangularCallout = TryCast(nChartControl1.Panels(2), NRoundedRectangularCallout)
			If callout Is Nothing Then
				Return
			End If

'INSTANT VB NOTE: The variable anchor was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim anchor_Renamed As NPieDataPointAnchor = TryCast(callout.Anchor, NPieDataPointAnchor)
			If anchor_Renamed Is Nothing Then
				Return
			End If

			anchor_Renamed.RadialPosition = CSng(AnchorPositionUpDown.Value)
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
