Imports Nevron.Chart
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports System
Imports System.ComponentModel
Imports System.Drawing

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NBarConnectorLinesUC
		Inherits NExampleBaseUC

		Private WithEvents ConnectorLinesStrokeButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ShowConnectorLinesCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.IContainer = Nothing

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


		#Region "Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.ConnectorLinesStrokeButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShowConnectorLinesCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' ConnectorLinesStrokeButton
			' 
			Me.ConnectorLinesStrokeButton.Location = New System.Drawing.Point(6, 39)
			Me.ConnectorLinesStrokeButton.Name = "ConnectorLinesStrokeButton"
			Me.ConnectorLinesStrokeButton.Size = New System.Drawing.Size(163, 24)
			Me.ConnectorLinesStrokeButton.TabIndex = 8
			Me.ConnectorLinesStrokeButton.Text = "Connector Lines Stoke.."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ConnectorLinesStrokeButton.Click += new System.EventHandler(this.ConnectorLinesStrokeButton_Click);
			' 
			' ShowConnectorLinesCheckBox
			' 
			Me.ShowConnectorLinesCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowConnectorLinesCheckBox.Location = New System.Drawing.Point(6, 12)
			Me.ShowConnectorLinesCheckBox.Name = "ShowConnectorLinesCheckBox"
			Me.ShowConnectorLinesCheckBox.Size = New System.Drawing.Size(163, 21)
			Me.ShowConnectorLinesCheckBox.TabIndex = 4
			Me.ShowConnectorLinesCheckBox.Text = "Show Connector Lines"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowConnectorLinesCheckBox.CheckedChanged += new System.EventHandler(this.ShowConnectorLinesCheckBox_CheckedChanged);
			' 
			' NBarConnectorLinesUC
			' 
			Me.Controls.Add(Me.ConnectorLinesStrokeButton)
			Me.Controls.Add(Me.ShowConnectorLinesCheckBox)
			Me.Name = "NBarConnectorLinesUC"
			Me.Size = New System.Drawing.Size(180, 505)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' create a title
			Dim title As New NLabel("2D Bar Chart Connector Lines")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Axis(StandardAxis.Depth).Visible = False

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' setup a bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar Series"
			bar.ShadowStyle.Type = ShadowType.GaussianBlur
			bar.ShadowStyle.Offset = New NPointL(2, 2)
			bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0)
			bar.ShadowStyle.FadeLength = New NLength(5)
			bar.DataLabelStyle.Visible = False

			' add some data to the bar series
			bar.Values.Add(18)
			bar.Values.Add(15)
			bar.Values.Add(21)
			bar.Values.Add(23)
			bar.Values.Add(27)
			bar.Values.Add(29)
			bar.Values.Add(26)

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))
			ShowConnectorLinesCheckBox.Checked = True
		End Sub

		Private Sub ShowConnectorLinesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowConnectorLinesCheckBox.CheckedChanged
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			bar.ShowConnectorLines = ShowConnectorLinesCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub ConnectorLinesStrokeButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ConnectorLinesStrokeButton.Click
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(bar.ConnectorLineStrokeStyle, strokeStyleResult) Then
				bar.ConnectorLineStrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace