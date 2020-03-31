Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
    <ToolboxItem(False)> _
 Public Class NNumericDisplayUC
        Inherits NExampleBaseUC

        Private m_Counter As Integer = 0
        Private m_NumericDisplay1 As NNumericDisplayPanel
        Private m_NumericDisplay2 As NNumericDisplayPanel
        Private m_NumericDisplay3 As NNumericDisplayPanel
        Private m_Random As New Random()
        Private WithEvents LitFillStyleButton As Nevron.UI.WinForm.Controls.NButton
        Private WithEvents DimFillStyleButton As Nevron.UI.WinForm.Controls.NButton
        Private WithEvents StopStartTimerButton As Nevron.UI.WinForm.Controls.NButton
        Private WithEvents CellSizeComboBox As Nevron.UI.WinForm.Controls.NComboBox
        Private WithEvents DisplayStyleComboBox As Nevron.UI.WinForm.Controls.NComboBox
        Private WithEvents SignModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
        Private WithEvents ShowLeadingZerosCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
        Private WithEvents AttachSignToNumberCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
        Private label1 As System.Windows.Forms.Label
        Private label2 As System.Windows.Forms.Label
        Private label3 As System.Windows.Forms.Label
        Private WithEvents DataFeedTimer As System.Windows.Forms.Timer
        Private components As System.ComponentModel.IContainer

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
            Me.components = New System.ComponentModel.Container()
            Me.LitFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
            Me.DimFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
            Me.CellSizeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
            Me.label1 = New System.Windows.Forms.Label()
            Me.DataFeedTimer = New System.Windows.Forms.Timer(Me.components)
            Me.StopStartTimerButton = New Nevron.UI.WinForm.Controls.NButton()
            Me.label2 = New System.Windows.Forms.Label()
            Me.DisplayStyleComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
            Me.label3 = New System.Windows.Forms.Label()
            Me.SignModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
            Me.ShowLeadingZerosCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
            Me.AttachSignToNumberCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
            Me.SuspendLayout()
            ' 
            ' LitFillStyleButton
            ' 
            Me.LitFillStyleButton.Location = New System.Drawing.Point(8, 16)
            Me.LitFillStyleButton.Name = "LitFillStyleButton"
            Me.LitFillStyleButton.Size = New System.Drawing.Size(159, 23)
            Me.LitFillStyleButton.TabIndex = 0
            Me.LitFillStyleButton.Text = "Lit Fill Style"
            'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
            'ORIGINAL LINE: this.LitFillStyleButton.Click += new System.EventHandler(this.LitFillStyleButton_Click);
            ' 
            ' DimFillStyleButton
            ' 
            Me.DimFillStyleButton.Location = New System.Drawing.Point(8, 48)
            Me.DimFillStyleButton.Name = "DimFillStyleButton"
            Me.DimFillStyleButton.Size = New System.Drawing.Size(159, 23)
            Me.DimFillStyleButton.TabIndex = 1
            Me.DimFillStyleButton.Text = "Dim Fill Style"
            'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
            'ORIGINAL LINE: this.DimFillStyleButton.Click += new System.EventHandler(this.DimFillStyleButton_Click);
            ' 
            ' CellSizeComboBox
            ' 
            Me.CellSizeComboBox.ListProperties.CheckBoxDataMember = ""
            Me.CellSizeComboBox.ListProperties.DataSource = Nothing
            Me.CellSizeComboBox.ListProperties.DisplayMember = ""
            Me.CellSizeComboBox.Location = New System.Drawing.Point(8, 104)
            Me.CellSizeComboBox.Name = "CellSizeComboBox"
            Me.CellSizeComboBox.Size = New System.Drawing.Size(159, 21)
            Me.CellSizeComboBox.TabIndex = 3
            Me.CellSizeComboBox.Text = "CellSizeComboBox"
            'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
            'ORIGINAL LINE: this.CellSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.CellSizeComboBox_SelectedIndexChanged);
            ' 
            ' label1
            ' 
            Me.label1.Location = New System.Drawing.Point(8, 80)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(135, 23)
            Me.label1.TabIndex = 2
            Me.label1.Text = "Cell Size:"
            Me.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            ' 
            ' DataFeedTimer
            ' 
            Me.DataFeedTimer.Interval = 500
            'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
            'ORIGINAL LINE: this.DataFeedTimer.Tick += new System.EventHandler(this.DataFeedTimer_Tick);
            ' 
            ' StopStartTimerButton
            ' 
            Me.StopStartTimerButton.Location = New System.Drawing.Point(8, 300)
            Me.StopStartTimerButton.Name = "StopStartTimerButton"
            Me.StopStartTimerButton.Size = New System.Drawing.Size(159, 23)
            Me.StopStartTimerButton.TabIndex = 9
            Me.StopStartTimerButton.Text = "Stop Timer"
            'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
            'ORIGINAL LINE: this.StopStartTimerButton.Click += new System.EventHandler(this.StopStartTimerButton_Click);
            ' 
            ' label2
            ' 
            Me.label2.Location = New System.Drawing.Point(8, 124)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(135, 23)
            Me.label2.TabIndex = 4
            Me.label2.Text = "Display Style:"
            Me.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            ' 
            ' DisplayStyleComboBox
            ' 
            Me.DisplayStyleComboBox.ListProperties.CheckBoxDataMember = ""
            Me.DisplayStyleComboBox.ListProperties.DataSource = Nothing
            Me.DisplayStyleComboBox.ListProperties.DisplayMember = ""
            Me.DisplayStyleComboBox.Location = New System.Drawing.Point(8, 148)
            Me.DisplayStyleComboBox.Name = "DisplayStyleComboBox"
            Me.DisplayStyleComboBox.Size = New System.Drawing.Size(159, 21)
            Me.DisplayStyleComboBox.TabIndex = 5
            Me.DisplayStyleComboBox.Text = "nComboBox1"
            'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
            'ORIGINAL LINE: this.DisplayStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.DisplayStyleComboBox_SelectedIndexChanged);
            ' 
            ' label3
            ' 
            Me.label3.Location = New System.Drawing.Point(8, 168)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(135, 23)
            Me.label3.TabIndex = 6
            Me.label3.Text = "Sign Mode:"
            Me.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            ' 
            ' SignModeComboBox
            ' 
            Me.SignModeComboBox.ListProperties.CheckBoxDataMember = ""
            Me.SignModeComboBox.ListProperties.DataSource = Nothing
            Me.SignModeComboBox.ListProperties.DisplayMember = ""
            Me.SignModeComboBox.Location = New System.Drawing.Point(8, 192)
            Me.SignModeComboBox.Name = "SignModeComboBox"
            Me.SignModeComboBox.Size = New System.Drawing.Size(159, 21)
            Me.SignModeComboBox.TabIndex = 7
            Me.SignModeComboBox.Text = "SignModeComboBox"
            'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
            'ORIGINAL LINE: this.SignModeComboBox.SelectedIndexChanged += new System.EventHandler(this.SignModeComboBox_SelectedIndexChanged);
            ' 
            ' ShowLeadingZerosCheckBox
            ' 
            Me.ShowLeadingZerosCheckBox.AutoSize = True
            Me.ShowLeadingZerosCheckBox.ButtonProperties.BorderOffset = 2
            Me.ShowLeadingZerosCheckBox.Location = New System.Drawing.Point(8, 228)
            Me.ShowLeadingZerosCheckBox.Name = "ShowLeadingZerosCheckBox"
            Me.ShowLeadingZerosCheckBox.Size = New System.Drawing.Size(118, 17)
            Me.ShowLeadingZerosCheckBox.TabIndex = 8
            Me.ShowLeadingZerosCheckBox.Text = "Show leading zeros"
            Me.ShowLeadingZerosCheckBox.UseVisualStyleBackColor = True
            'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
            'ORIGINAL LINE: this.ShowLeadingZerosCheckBox.CheckedChanged += new System.EventHandler(this.ShowLeadingZerosCheckBox_CheckedChanged);
            ' 
            ' AttachSignToNumberCheckBox
            ' 
            Me.AttachSignToNumberCheckBox.AutoSize = True
            Me.AttachSignToNumberCheckBox.ButtonProperties.BorderOffset = 2
            Me.AttachSignToNumberCheckBox.Location = New System.Drawing.Point(8, 254)
            Me.AttachSignToNumberCheckBox.Name = "AttachSignToNumberCheckBox"
            Me.AttachSignToNumberCheckBox.Size = New System.Drawing.Size(137, 17)
            Me.AttachSignToNumberCheckBox.TabIndex = 10
            Me.AttachSignToNumberCheckBox.Text = "Attach Sign To Number"
            Me.AttachSignToNumberCheckBox.UseVisualStyleBackColor = True
            'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
            'ORIGINAL LINE: this.AttachSignToNumberCheckBox.CheckedChanged += new System.EventHandler(this.AttachSignToNumberCheckBox_CheckedChanged);
            ' 
            ' NNumericDisplayUC
            ' 
            Me.Controls.Add(Me.AttachSignToNumberCheckBox)
            Me.Controls.Add(Me.ShowLeadingZerosCheckBox)
            Me.Controls.Add(Me.label3)
            Me.Controls.Add(Me.SignModeComboBox)
            Me.Controls.Add(Me.label2)
            Me.Controls.Add(Me.DisplayStyleComboBox)
            Me.Controls.Add(Me.StopStartTimerButton)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.CellSizeComboBox)
            Me.Controls.Add(Me.DimFillStyleButton)
            Me.Controls.Add(Me.LitFillStyleButton)
            Me.Name = "NNumericDisplayUC"
            Me.Size = New System.Drawing.Size(180, 336)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
#End Region

        Public Overrides Sub Initialize()
            nChartControl1.Panels.Clear()

            ' set a chart title
            Dim header As New NLabel("Numeric Display Panel")
            header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
            header.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
            header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
            nChartControl1.Panels.Add(header)

            Dim dockPanel As New NDockPanel()
            dockPanel.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
            dockPanel.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
            dockPanel.ContentAlignment = ContentAlignment.MiddleCenter

            nChartControl1.Panels.Add(dockPanel)

            m_NumericDisplay1 = CreateDisplayPanel()
            m_NumericDisplay2 = CreateDisplayPanel()
            m_NumericDisplay3 = CreateDisplayPanel()

            dockPanel.ChildPanels.Add(m_NumericDisplay1)
            dockPanel.ChildPanels.Add(m_NumericDisplay2)
            dockPanel.ChildPanels.Add(m_NumericDisplay3)

            nChartControl1.Refresh()

            ' init form controls
            CellSizeComboBox.Items.Add("Small")
            CellSizeComboBox.Items.Add("Normal")
            CellSizeComboBox.Items.Add("Large")
            CellSizeComboBox.SelectedIndex = 1
            DisplayStyleComboBox.FillFromEnum(GetType(DisplayStyle))
            DisplayStyleComboBox.SelectedIndex = CInt(DisplayStyle.SevenSegmentRounded)

            SignModeComboBox.FillFromEnum(GetType(DisplaySignMode))
            SignModeComboBox.SelectedIndex = CInt(DisplaySignMode.Never)

            DataFeedTimer.Start()
        End Sub

        Private Function CreateDisplayPanel() As NNumericDisplayPanel
            Dim numericDisplay As New NNumericDisplayPanel()

            numericDisplay.UseAutomaticSize = True
            numericDisplay.DockMode = PanelDockMode.Top
            numericDisplay.Value = 0
            numericDisplay.CellCountMode = DisplayCellCountMode.Fixed
            numericDisplay.CellCount = 7
            numericDisplay.Margins = New NMarginsL(10, 10, 10, 10)
            numericDisplay.Padding = New NMarginsL(10, 10, 10, 10)
            numericDisplay.BackgroundFillStyle = New NColorFillStyle(Color.Black)

            ' adjust cell fill styles
            numericDisplay.LitFillStyle = New NColorFillStyle(Color.GreenYellow)
            numericDisplay.DimFillStyle.SetTransparencyPercent(50)
            numericDisplay.DecimalLitFillStyle = New NColorFillStyle(Color.Red)
            numericDisplay.DecimalDimFillStyle.SetTransparencyPercent(50)

            numericDisplay.BorderStyle = New NEdgeBorderStyle(BorderShape.RoundedRect)
            numericDisplay.PaintEffect = New NGelEffectStyle()

            Return numericDisplay
        End Function

        Private Sub DataFeedTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataFeedTimer.Tick
            Dim value1 As Double = -50 + m_Random.Next(10000) / 100.0
            m_NumericDisplay1.Value = value1

            Dim value2 As Double
            If m_Counter Mod 4 = 0 Then
                value2 = -50 + m_Random.Next(10000) / 100.0
                m_NumericDisplay2.Value = value2
            End If

            Dim value3 As Double
            If m_Counter Mod 8 = 0 Then
                value3 = 200 + m_Random.Next(10000) / 100.0
                m_NumericDisplay3.Value = value3
            End If

            m_Counter += 1
            nChartControl1.Refresh()
        End Sub
        Private Sub LitFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LitFillStyleButton.Click
            Dim fillStyle As NFillStyle = Nothing

            If NFillStyleTypeEditorNoAutomatic.Edit(m_NumericDisplay1.LitFillStyle, False, fillStyle) Then
                m_NumericDisplay1.LitFillStyle = fillStyle
                m_NumericDisplay2.LitFillStyle = fillStyle
                m_NumericDisplay3.LitFillStyle = fillStyle

                nChartControl1.Refresh()
            End If
        End Sub
        Private Sub DimFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DimFillStyleButton.Click
            Dim fillStyle As NFillStyle = Nothing

            If NFillStyleTypeEditorNoAutomatic.Edit(m_NumericDisplay1.DimFillStyle, False, fillStyle) Then
                m_NumericDisplay1.DimFillStyle = fillStyle
                m_NumericDisplay2.DimFillStyle = fillStyle
                m_NumericDisplay3.DimFillStyle = fillStyle

                nChartControl1.Refresh()
            End If
        End Sub
        Private Sub CellSizeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CellSizeComboBox.SelectedIndexChanged
            Dim segmentWidth As New NLength(0)
            Dim segmentGap As New NLength(0)
            Dim cellSize As New NSizeL(New NLength(0), New NLength(0))

            Select Case CellSizeComboBox.SelectedIndex
                Case 0 ' small
                    segmentWidth = New NLength(2, NGraphicsUnit.Point)
                    segmentGap = New NLength(1, NGraphicsUnit.Point)
                    cellSize = New NSizeL(New NLength(15, NGraphicsUnit.Point), New NLength(30, NGraphicsUnit.Point))
                Case 1 ' normal
                    segmentWidth = New NLength(3, NGraphicsUnit.Point)
                    segmentGap = New NLength(1, NGraphicsUnit.Point)
                    cellSize = New NSizeL(New NLength(20, NGraphicsUnit.Point), New NLength(40, NGraphicsUnit.Point))
                Case 2 ' large
                    segmentWidth = New NLength(4, NGraphicsUnit.Point)
                    segmentGap = New NLength(2, NGraphicsUnit.Point)
                    cellSize = New NSizeL(New NLength(25, NGraphicsUnit.Point), New NLength(50, NGraphicsUnit.Point))
            End Select

            m_NumericDisplay1.CellSize = cellSize
            m_NumericDisplay2.CellSize = cellSize
            m_NumericDisplay3.CellSize = cellSize

            m_NumericDisplay1.DecimalCellSize = cellSize
            m_NumericDisplay2.DecimalCellSize = cellSize
            m_NumericDisplay3.DecimalCellSize = cellSize

            m_NumericDisplay1.SegmentGap = segmentGap
            m_NumericDisplay2.SegmentGap = segmentGap
            m_NumericDisplay3.SegmentGap = segmentGap

            m_NumericDisplay1.SegmentWidth = segmentWidth
            m_NumericDisplay2.SegmentWidth = segmentWidth
            m_NumericDisplay3.SegmentWidth = segmentWidth

            nChartControl1.Refresh()
        End Sub
        Private Sub StopStartTimerButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles StopStartTimerButton.Click
            If Me.DataFeedTimer.Enabled Then
                Me.DataFeedTimer.Stop()
                StopStartTimerButton.Text = "Start Timer"
            Else
                Me.DataFeedTimer.Start()
                StopStartTimerButton.Text = "Stop Timer"
            End If
        End Sub
        Private Sub DisplayStyleComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DisplayStyleComboBox.SelectedIndexChanged
            m_NumericDisplay1.DisplayStyle = CType(DisplayStyleComboBox.SelectedIndex, DisplayStyle)
            m_NumericDisplay2.DisplayStyle = CType(DisplayStyleComboBox.SelectedIndex, DisplayStyle)
            m_NumericDisplay3.DisplayStyle = CType(DisplayStyleComboBox.SelectedIndex, DisplayStyle)

            nChartControl1.Refresh()
        End Sub
        Private Sub SignModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SignModeComboBox.SelectedIndexChanged
            m_NumericDisplay1.SignMode = CType(SignModeComboBox.SelectedIndex, DisplaySignMode)
            m_NumericDisplay2.SignMode = CType(SignModeComboBox.SelectedIndex, DisplaySignMode)
            m_NumericDisplay3.SignMode = CType(SignModeComboBox.SelectedIndex, DisplaySignMode)

            nChartControl1.Refresh()
        End Sub
        Private Sub ShowLeadingZerosCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowLeadingZerosCheckBox.CheckedChanged
            m_NumericDisplay1.ShowLeadingZeros = ShowLeadingZerosCheckBox.Checked
            m_NumericDisplay2.ShowLeadingZeros = ShowLeadingZerosCheckBox.Checked
            m_NumericDisplay3.ShowLeadingZeros = ShowLeadingZerosCheckBox.Checked

            nChartControl1.Refresh()
        End Sub
        Private Sub AttachSignToNumberCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AttachSignToNumberCheckBox.CheckedChanged
            m_NumericDisplay1.AttachSignToNumber = AttachSignToNumberCheckBox.Checked
            m_NumericDisplay2.AttachSignToNumber = AttachSignToNumberCheckBox.Checked
            m_NumericDisplay3.AttachSignToNumber = AttachSignToNumberCheckBox.Checked

            nChartControl1.Refresh()
        End Sub
    End Class
End Namespace
