Imports Microsoft.VisualBasic
Imports System
Imports System.Globalization
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Templates
Imports Nevron.Dom

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NStressTestUC.
	''' </summary>
	Public Class NStressTestUC
		Inherits NDiagramExampleUC
		#Region "Constructor"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub

		#End Region

		#Region "Component Designer Generated Code"

		Private Sub InitializeComponent()
			Me.btnRandom2 = New Nevron.UI.WinForm.Controls.NButton()
			Me.btnRandom1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.cbLayout = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.txtResults = New System.Windows.Forms.TextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.btnLayout = New Nevron.UI.WinForm.Controls.NButton()
			Me.panel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' btnRandom2
			' 
			Me.btnRandom2.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnRandom2.Location = New System.Drawing.Point(8, 48)
			Me.btnRandom2.Name = "btnRandom2"
			Me.btnRandom2.Size = New System.Drawing.Size(244, 23)
			Me.btnRandom2.TabIndex = 8
			Me.btnRandom2.Text = "Random Graph (2400 vertices, 2600 edges)"
			Me.btnRandom2.UseVisualStyleBackColor = True
'			Me.btnRandom2.Click += New System.EventHandler(Me.btnRandom_Click);
			' 
			' btnRandom1
			' 
			Me.btnRandom1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnRandom1.Location = New System.Drawing.Point(8, 19)
			Me.btnRandom1.Name = "btnRandom1"
			Me.btnRandom1.Size = New System.Drawing.Size(244, 23)
			Me.btnRandom1.TabIndex = 7
			Me.btnRandom1.Text = "Random Graph (900 vertices, 1100 edges)"
			Me.btnRandom1.UseVisualStyleBackColor = True
'			Me.btnRandom1.Click += New System.EventHandler(Me.btnRandom_Click);
			' 
			' cbLayout
			' 
			Me.cbLayout.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cbLayout.Location = New System.Drawing.Point(8, 98)
			Me.cbLayout.Name = "cbLayout"
			Me.cbLayout.Size = New System.Drawing.Size(244, 21)
			Me.cbLayout.TabIndex = 9
			' 
			' panel1
			' 
			Me.panel1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.panel1.Controls.Add(Me.txtResults)
			Me.panel1.Controls.Add(Me.label1)
			Me.panel1.Font = New System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.panel1.Location = New System.Drawing.Point(8, 182)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(244, 171)
			Me.panel1.TabIndex = 10
			' 
			' txtResults
			' 
			Me.txtResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtResults.Dock = System.Windows.Forms.DockStyle.Fill
			Me.txtResults.Font = New System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.txtResults.Location = New System.Drawing.Point(0, 23)
			Me.txtResults.Multiline = True
			Me.txtResults.Name = "txtResults"
			Me.txtResults.ReadOnly = True
			Me.txtResults.Size = New System.Drawing.Size(244, 148)
			Me.txtResults.TabIndex = 1
			' 
			' label1
			' 
			Me.label1.Dock = System.Windows.Forms.DockStyle.Top
			Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.label1.ForeColor = System.Drawing.Color.Blue
			Me.label1.Location = New System.Drawing.Point(0, 0)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(244, 23)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Results"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' btnLayout
			' 
			Me.btnLayout.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnLayout.Location = New System.Drawing.Point(8, 125)
			Me.btnLayout.Name = "btnLayout"
			Me.btnLayout.Size = New System.Drawing.Size(244, 23)
			Me.btnLayout.TabIndex = 11
			Me.btnLayout.Text = "Layout"
			Me.btnLayout.UseVisualStyleBackColor = True
'			Me.btnLayout.Click += New System.EventHandler(Me.btnLayout_Click);
			' 
			' NStressTestUC
			' 
			Me.Controls.Add(Me.btnLayout)
			Me.Controls.Add(Me.panel1)
			Me.Controls.Add(Me.cbLayout)
			Me.Controls.Add(Me.btnRandom2)
			Me.Controls.Add(Me.btnRandom1)
			Me.Name = "NStressTestUC"
			Me.Controls.SetChildIndex(Me.btnRandom1, 0)
			Me.Controls.SetChildIndex(Me.btnRandom2, 0)
			Me.Controls.SetChildIndex(Me.cbLayout, 0)
			Me.Controls.SetChildIndex(Me.panel1, 0)
			Me.Controls.SetChildIndex(Me.btnLayout, 0)
			Me.panel1.ResumeLayout(False)
			Me.panel1.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' init form fields
			InitFormControls()
			view.BeginInit()
			view.Grid.Visible = False
			view.GlobalVisibility.HideAll()
			view.ViewLayout = ViewLayout.Fit

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' end view init
			view.EndInit()
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			' Create the layouts
			Dim layered As NLayeredGraphLayout = New NLayeredGraphLayout()
			layered.LayerSpacing = 100

			Dim singleCycle As NSingleCycleLayout = New NSingleCycleLayout()
			singleCycle.RingRadius = 1000

			Dim symmetrical As NSymmetricalLayout = New NSymmetricalLayout()

			cbLayout.Items.AddRange(New NLayout() { layered, singleCycle, symmetrical })

			cbLayout.SelectedIndex = 0

			ResumeEventsHandling()
		End Sub
		Private Sub InitDocument()
			document.BridgeManager.Enabled = False
			document.RoutingManager.Enabled = False
		End Sub
		Private Function LayoutShapes() As String
			Dim result As String = String.Empty

			Try
				Me.Cursor = Cursors.WaitCursor
				document.BeginInit()

				Dim nodes As NNodeList = document.ActiveLayer.Children(NFilters.Shape2D)
				Dim layoutContext As NLayoutContext = New NDrawingLayoutContext(document)
				Dim layout As NLayout = CType(cbLayout.SelectedItem, NLayout)
				layout.Layout(nodes, layoutContext)
				document.SizeToContent()

				document.EndInit()
				result = layout.PerformanceInfo
			Finally
				Me.Cursor = Cursors.Default
			End Try

			Return result
		End Function
		Private Function GetNumber(ByVal str As String, ByVal index As Integer) As Integer
			Dim digits As String = String.Empty
			Dim i As Integer = index
			Dim length As Integer = str.Length
			Do While i < length
				If Char.IsDigit(str.Chars(i)) = False Then
					If digits.Length > 0 Then
						Exit Do
					End If
				Else
					digits = digits & str.Chars(i)
				End If
				i += 1
			Loop

			If String.IsNullOrEmpty(digits) Then
				Return 0
			End If

			Return Int32.Parse(digits, CultureInfo.InvariantCulture)
		End Function

		#End Region

		#Region "Event Handlers"

		Private Sub btnRandom_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRandom2.Click, btnRandom1.Click
			Try
				Me.Cursor = Cursors.WaitCursor
				Dim start As DateTime = DateTime.Now

				view.BeginInit()

				Dim text As String = (CType(sender, Control)).Text
				Dim vertexCount As Integer = GetNumber(text, text.IndexOf("("c))
				Dim edgeCount As Integer = GetNumber(text, text.IndexOf(","c))

				Dim randomGraph As NRandomGraphTemplate = New NRandomGraphTemplate()
				randomGraph.EdgesStyleSheetName = "CustomConnectors"
				randomGraph.VertexCount = vertexCount
				randomGraph.EdgeCount = edgeCount

				document.Reset()
				document.BeginInit()

				document.ActiveLayer.AutoGenerateUniqueNames = False
				randomGraph.Create(document)
				document.SizeToContent()

				document.EndInit()

				Dim time As TimeSpan = DateTime.Now.Subtract(start)
				txtResults.Text = String.Format("Graph generated in {0:F3} ms." & Constants.vbLf, time.TotalMilliseconds)
			Finally
				Me.Cursor = Cursors.Default
				view.EndInit()
			End Try
		End Sub
		Private Sub btnLayout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLayout.Click
			view.BeginInit()
			txtResults.Text = LayoutShapes()
			view.EndInit()
		End Sub

		#End Region

		#Region "Designer Fields"

		Private WithEvents btnRandom2 As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents btnRandom1 As Nevron.UI.WinForm.Controls.NButton
		Private panel1 As Panel
		Private label1 As Label
		Private WithEvents btnLayout As Nevron.UI.WinForm.Controls.NButton
		Private txtResults As TextBox
		Private cbLayout As Nevron.UI.WinForm.Controls.NComboBox

		#End Region
	End Class
End Namespace