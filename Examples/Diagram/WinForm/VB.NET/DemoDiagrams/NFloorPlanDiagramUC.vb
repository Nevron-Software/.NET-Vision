Imports Microsoft.VisualBasic
Imports System
Imports System.Globalization
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.Batches

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NFloorPlanDiagramUC.
	''' </summary>
	Public Class NFloorPlanDiagramUC
		Inherits NDiagramExampleUC
		#Region "Constructor"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			initializingControls = True

			InitializeComponent()

			'	styles
			txMain = New NTextStyle()
			txMain.FontStyle = New NFontStyle("Arial", 9)
			txMain.BackplaneStyle.Visible = False
			txMain.Offset = New NPointL(0, 0)

			txLine = New NTextStyle()
			txLine.FontStyle = New NFontStyle("Arial", 9)
			txLine.BackplaneStyle.Visible = True
			txLine.BackplaneStyle.FillStyle = New NColorFillStyle(Color.FromArgb(128, Color.White))
			txLine.BackplaneStyle.StandardFrameStyle.Visible = False

			txLineSmall = New NTextStyle()
			txLineSmall.FontStyle = New NFontStyle("Arial", 5)
			txLineSmall.BackplaneStyle.Visible = True
			txLineSmall.BackplaneStyle.FillStyle = New NColorFillStyle(Color.FromArgb(128, Color.White))
			txLineSmall.BackplaneStyle.StandardFrameStyle.Visible = False

			sstOdd = New NStrokeStyle(1, Color.Black)
			sstEven = New NStrokeStyle(1, Color.LightGray)

			initializingControls = False
		End Sub

		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.showSizesCheckBox = New System.Windows.Forms.CheckBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.scaleComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.singleRoomComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' showSizesCheckBox
			' 
			Me.showSizesCheckBox.AutoSize = True
			Me.showSizesCheckBox.Checked = True
			Me.showSizesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
			Me.showSizesCheckBox.Location = New System.Drawing.Point(8, 12)
			Me.showSizesCheckBox.Name = "showSizesCheckBox"
			Me.showSizesCheckBox.Size = New System.Drawing.Size(81, 17)
			Me.showSizesCheckBox.TabIndex = 1
			Me.showSizesCheckBox.Text = "Show Sizes"
			Me.showSizesCheckBox.UseVisualStyleBackColor = True
'			Me.showSizesCheckBox.CheckedChanged += New System.EventHandler(Me.showSizesCheckBox_CheckedChanged);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(105, 13)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(37, 13)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Scale:"
			' 
			' scaleComboBox
			' 
			Me.scaleComboBox.Items.AddRange(New Object() { New Nevron.UI.WinForm.Controls.NListBoxItem("0.75", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("0.8", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("0.9", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("1", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("1.1", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("1.15", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("1.2", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("1.25", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("1.5", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("1.75", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("2", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("4", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("8", -1, False, 0, New System.Drawing.Size(0, 0))})
			Me.scaleComboBox.Location = New System.Drawing.Point(146, 10)
			Me.scaleComboBox.Name = "scaleComboBox"
			Me.scaleComboBox.Size = New System.Drawing.Size(94, 21)
			Me.scaleComboBox.TabIndex = 3
'			Me.scaleComboBox.SelectedIndexChanged += New System.EventHandler(Me.scaleComboBox_SelectedIndexChanged);
			' 
			' singleRoomComboBox
			' 
			Me.singleRoomComboBox.Items.AddRange(New Object() { New Nevron.UI.WinForm.Controls.NListBoxItem("-", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("LivingRoom", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("Hallway", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("Dresser", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("Toilet", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("Kitchen", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("BedRoom", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("InnerHallway", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("BathRoom", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("GuestRoom", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("Balcony1", -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem("Balcony2", -1, False, 0, New System.Drawing.Size(0, 0))})
			Me.singleRoomComboBox.Location = New System.Drawing.Point(81, 35)
			Me.singleRoomComboBox.Name = "singleRoomComboBox"
			Me.singleRoomComboBox.Size = New System.Drawing.Size(159, 21)
			Me.singleRoomComboBox.TabIndex = 3
'			Me.singleRoomComboBox.SelectedIndexChanged += New System.EventHandler(Me.singleRoomComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(5, 38)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(70, 13)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Single Room:"
			' 
			' NFloorPlanDiagramUC
			' 
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.singleRoomComboBox)
			Me.Controls.Add(Me.scaleComboBox)
			Me.Controls.Add(Me.showSizesCheckBox)
			Me.Name = "NFloorPlanDiagramUC"
			Me.Size = New System.Drawing.Size(248, 384)
			Me.Controls.SetChildIndex(Me.showSizesCheckBox, 0)
			Me.Controls.SetChildIndex(Me.scaleComboBox, 0)
			Me.Controls.SetChildIndex(Me.singleRoomComboBox, 0)
			Me.Controls.SetChildIndex(Me.label1, 0)
			Me.Controls.SetChildIndex(Me.label2, 0)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			scaleComboBox.SelectedIndex = scaleComboBox.FindStringExact("0.75")
			singleRoomComboBox.SelectedIndex = singleRoomComboBox.FindStringExact("-")

			' begin view init
			view.BeginInit()

			' init document
			document.BeginInit()

			SetupDocumentAndView()
			CreateDiagram(Nothing)

			document.EndInit()
			view.EndInit()
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub showSizesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles showSizesCheckBox.CheckedChanged
			singleRoomComboBox.SelectedIndex = singleRoomComboBox.FindStringExact("-")
			OnShowSizesChanged()
		End Sub

		Private Sub scaleComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles scaleComboBox.SelectedIndexChanged
			If scaleComboBox.SelectedItem Is Nothing Then
				Return
			End If

			document.HistoryService.Pause()
			document.CustomScale = Single.Parse(scaleComboBox.SelectedItem.ToString(), CultureInfo.InvariantCulture.NumberFormat)
			document.HistoryService.Resume()
			document.SmartRefreshAllViews()
		End Sub

		Private Sub singleRoomComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles singleRoomComboBox.SelectedIndexChanged
			If singleRoomComboBox.SelectedIndex = -1 Then
				Return
			End If

			CreateDiagram(singleRoomComboBox.SelectedItem.ToString())
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub SetupDocumentAndView()
			'	misc
			minNormalLineLength = 30

			lineTextOffset = New NPointL(0, -6)
			defaultRoomMargin = 25
			roomMargin = defaultRoomMargin
			displayLengths = True

			'	document
			document.MeasurementUnit = NMetricUnit.Centimeter
			document.DrawingScaleMode = DrawingScaleMode.CustomScale
			document.CustomWorldMeasurementUnit = NGraphicsUnit.Pixel

			document.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent
			document.AutoBoundsPadding = New Nevron.Diagram.NMargins(20)
			document.Style.StrokeStyle = New NStrokeStyle(0, Color.White)
			document.Style.FillStyle = New NHatchFillStyle(System.Drawing.Drawing2D.HatchStyle.DottedGrid, Color.LightGray, Color.White)

			'	view
			view.ViewLayout = ViewLayout.Normal
		End Sub

		Private Sub OnShowSizesChanged()
			If showSizesCheckBox.Checked Then
				roomMargin = defaultRoomMargin
				displayLengths = True
				CreateDiagram(Nothing)
				scaleComboBox.SelectedIndex = scaleComboBox.FindStringExact("0.75")
			Else
				roomMargin = 0
				displayLengths = False
				CreateDiagram(Nothing)
				scaleComboBox.SelectedIndex = scaleComboBox.FindStringExact("0.8")
			End If
		End Sub

		Private Sub CreateDiagram(ByVal roomName As String)
			If initializingControls Then
				Return
			End If

			document.BeginInit()
			document.ActiveLayer.RemoveAllChildren()

			If roomName Is Nothing Then
				CreateLivingRoom(New NPointF(0, 0))
				CreateHallway(New NPointF(LivingRoom.width + roomMargin, LivingRoom.b1))
				CreateDresser(New NPointF(LivingRoom.width + Hallway.a1 + 2 * roomMargin, LivingRoom.b1 - roomMargin))
				CreateToilet(New NPointF(LivingRoom.width + Hallway.a1 + Dresser.width + 3 * roomMargin, LivingRoom.b1 - roomMargin))
				CreateKitchen(New NPointF(LivingRoom.width + Hallway.width + 4 * roomMargin, 0))
				CreateBedRoom(New NPointF(LivingRoom.a5, LivingRoom.depth + roomMargin))
				CreateInnerHallway(New NPointF(LivingRoom.a5 + BedRoom.width + roomMargin, LivingRoom.depth + roomMargin))
				CreateBathRoom(New NPointF(LivingRoom.a5 + BedRoom.width + roomMargin, LivingRoom.depth + InnerHallway.depth + 2 * roomMargin))
				CreateGuestRoom(New NPointF(LivingRoom.a5 + BedRoom.width + BathRoom.width + 2 * roomMargin, LivingRoom.depth + roomMargin))
				CreateBalcony1(New NPointF(LivingRoom.width + Hallway.width + Kitchen.width + 5 * roomMargin, Kitchen.b0))
				CreateBalcony2(New NPointF(-roomMargin, LivingRoom.b7 + roomMargin))
			Else
				Select Case roomName
					Case "-"
						OnShowSizesChanged()
					Case "LivingRoom"
						CreateLivingRoom(New NPointF(0, 0))
					Case "Hallway"
						CreateHallway(New NPointF(0, 0))
					Case "Dresser"
						CreateDresser(New NPointF(0, 0))
					Case "Toilet"
						CreateToilet(New NPointF(0, 0))
					Case "Kitchen"
						CreateKitchen(New NPointF(0, 0))
					Case "BedRoom"
						CreateBedRoom(New NPointF(0, 0))
					Case "InnerHallway"
						CreateInnerHallway(New NPointF(0, 0))
					Case "BathRoom"
						CreateBathRoom(New NPointF(0, 0))
					Case "GuestRoom"
						CreateGuestRoom(New NPointF(0, 0))
					Case "Balcony1"
						CreateBalcony1(New NPointF(0, 0))
					Case "Balcony2"
						CreateBalcony2(New NPointF(0, 0))
				End Select
			End If

			document.SizeToContent()
			document.EndInit()
		End Sub

		Private Sub CreateLivingRoom(ByVal offset As NPointF)
			Dim points As NPointF() = ApplyOffset(LivingRoom.points, offset)

			Dim p As NPolygonShape = New NPolygonShape(points)
			p.Text = "Living Room, H=265"
			p.Style.TextStyle = txMain
			document.ActiveLayer.AddChild(p)

			Dim labels As NNodeList = New NNodeList()
			labels.Add(AddLabel(LivingRoom.section1Center, "H=240", False))
			labels.Add(AddLabel(LivingRoom.section2Center, "H=240", True))

			CreateLabeledPolyOutline(points, p, labels, "Living Room")
		End Sub

		Private Sub CreateHallway(ByVal offset As NPointF)
			Dim points As NPointF() = ApplyOffset(Hallway.points, offset)

			Dim p As NPolygonShape = New NPolygonShape(points)
			p.Text = "Hallway, H=270"
			p.Style.TextStyle = TryCast(txMain.Clone(), NTextStyle)
			p.Style.TextStyle.Offset = New NPointL(-60, 0)
			document.ActiveLayer.AddChild(p)

			Dim labels As NNodeList = New NNodeList()
			labels.Add(AddLabel(ApplyOffset(Hallway.section1Center, offset), "H=240", False))

			CreateLabeledPolyOutline(points, p, labels, "Hallway")
		End Sub

		Private Sub CreateDresser(ByVal offset As NPointF)
			Dim points As NPointF() = ApplyOffset(Dresser.points, offset)

			Dim p As NPolygonShape = New NPolygonShape(points)
			p.Text = "Dresser, H=270"
			p.Style.TextStyle = TryCast(txMain.Clone(), NTextStyle)
			document.ActiveLayer.AddChild(p)

			CreateLabeledPolyOutline(points, p, Nothing, "Dresser")
		End Sub

		Private Sub CreateToilet(ByVal offset As NPointF)
			Dim points As NPointF() = ApplyOffset(Toilet.points, offset)

			Dim p As NPolygonShape = New NPolygonShape(points)
			p.Text = "Toilet, H=270"
			p.Style.TextStyle = TryCast(txMain.Clone(), NTextStyle)
			document.ActiveLayer.AddChild(p)

			CreateLabeledPolyOutline(points, p, Nothing, "Toilet")
		End Sub

		Private Sub CreateKitchen(ByVal offset As NPointF)
			Dim points As NPointF() = ApplyOffset(Kitchen.points, offset)

			Dim p As NPolygonShape = New NPolygonShape(points)
			p.Text = "Kitchen, H=265"
			p.Style.TextStyle = TryCast(txMain.Clone(), NTextStyle)
			document.ActiveLayer.AddChild(p)

			CreateLabeledPolyOutline(points, p, Nothing, "Kitchen")
		End Sub

		Private Sub CreateBedRoom(ByVal offset As NPointF)
			Dim points As NPointF() = ApplyOffset(BedRoom.points, offset)

			Dim p As NPolygonShape = New NPolygonShape(points)
			p.Text = "Bedroom, H=265"
			p.Style.TextStyle = TryCast(txMain.Clone(), NTextStyle)
			document.ActiveLayer.AddChild(p)

			CreateLabeledPolyOutline(points, p, Nothing, "Bedroom")
		End Sub

		Private Sub CreateInnerHallway(ByVal offset As NPointF)
			Dim points As NPointF() = ApplyOffset(InnerHallway.points, offset)

			Dim p As NPolygonShape = New NPolygonShape(points)
			p.Text = "Inn.Hallway, H=270"
			p.Style.TextStyle = TryCast(txMain.Clone(), NTextStyle)
			document.ActiveLayer.AddChild(p)

			CreateLabeledPolyOutline(points, p, Nothing, "Inner Hallway")
		End Sub

		Private Sub CreateBathRoom(ByVal offset As NPointF)
			Dim points As NPointF() = ApplyOffset(BathRoom.points, offset)

			Dim p As NPolygonShape = New NPolygonShape(points)
			p.Text = "Bathroom, H=250"
			p.Style.TextStyle = TryCast(txMain.Clone(), NTextStyle)
			document.ActiveLayer.AddChild(p)

			CreateLabeledPolyOutline(points, p, Nothing, "Bathroom")
		End Sub

		Private Sub CreateGuestRoom(ByVal offset As NPointF)
			Dim points As NPointF() = ApplyOffset(GuestRoom.points, offset)

			Dim p As NPolygonShape = New NPolygonShape(points)
			p.Text = "Guest Room, H=270"
			p.Style.TextStyle = TryCast(txMain.Clone(), NTextStyle)
			document.ActiveLayer.AddChild(p)

			CreateLabeledPolyOutline(points, p, Nothing, "Guest Room")
		End Sub

		Private Sub CreateBalcony1(ByVal offset As NPointF)
			Dim points As NPointF() = ApplyOffset(Balcony1.points, offset)

			Dim p As NPolygonShape = New NPolygonShape(points)
			p.Text = "Kitchen Balcony"
			p.Style.TextStyle = TryCast(txMain.Clone(), NTextStyle)
			document.ActiveLayer.AddChild(p)

			CreateLabeledPolyOutline(points, p, Nothing, "Kitchen Balcony")
		End Sub

		Private Sub CreateBalcony2(ByVal offset As NPointF)
			Dim points As NPointF() = ApplyOffset(Balcony2.points, offset)

			Dim p As NPolygonShape = New NPolygonShape(points)
			p.Text = "Bedroom Balcony"
			p.Style.TextStyle = TryCast(txMain.Clone(), NTextStyle)
			document.ActiveLayer.AddChild(p)

			CreateLabeledPolyOutline(points, p, Nothing, "Bedroom Balcony")
		End Sub


		Private Function ApplyOffset(ByVal points As NPointF(), ByVal offset As NPointF) As NPointF()
			Dim length As Integer = points.Length
			Dim result As NPointF() = New NPointF(length - 1){}
			Dim i As Integer = 0
			Do While i < length
				result(i) = New NPointF(points(i).X + offset.X, points(i).Y + offset.Y)
				i += 1
			Loop
			Return result
		End Function

		Private Function ApplyOffset(ByVal point As NPointF, ByVal offset As NPointF) As NPointF
			Return New NPointF(point.X + offset.X, point.Y + offset.Y)
		End Function

		Private Sub CreateLabeledPolyOutline(ByVal points As NPointF(), ByVal polyShape As NPolygonShape, ByVal labels As NNodeList, ByVal title As String)
			Dim nodes As NNodeList = New NNodeList()
			nodes.Add(polyShape)
			If Not labels Is Nothing Then
				nodes.AddRange(labels)
			End If

			Dim length As Integer = points.Length - 1
			Dim vIndex As Integer = 0, hIndex As Integer = 0, index As Integer = 0
			Dim i As Integer = 0
			Do While i < length
				nodes.Add(ConnectPointsLabeled(points(i), points(i + 1), hIndex, vIndex, index))
				i += 1
			Loop
			nodes.Add(ConnectPointsLabeled(points(points.Length - 1), points(0), hIndex, vIndex, index))

			Dim g As NGroup
			Dim batchGroup As NBatchGroup = New NBatchGroup(document)
			batchGroup.Build(nodes)
			batchGroup.Group(document.ActiveLayer, True, g)
			g.Name = title & " Group"
		End Sub

		Private Function ConnectPointsLabeled(ByVal p1 As NPointF, ByVal p2 As NPointF, ByRef hIndex As Integer, ByRef vIndex As Integer, ByRef index As Integer) As NLineShape
			Dim dx As Single = p2.X - p1.X
			Dim dy As Single = p2.Y - p1.Y
			Dim distance As Single = CSng(Math.Sqrt(dx * dx + dy * dy))

			Dim letter As String
			If Math.Floor(dy) = 0 Then
				hIndex += 1
				letter = "a" & hIndex
			Else
				vIndex += 1
				letter = "b" & vIndex
			End If
			index += 1

			Dim line As NLineShape = New NLineShape(p1, p2)
			document.ActiveLayer.AddChild(line)

			If index Mod 2 = 0 Then
				line.Style.StrokeStyle = sstEven
			Else
				line.Style.StrokeStyle = sstOdd
			End If

			If displayLengths Then
				line.Style.TextStyle = TryCast(txLine.Clone(), NTextStyle)
				If distance < minNormalLineLength Then
					line.Text = distance.ToString()
					line.Style.TextStyle = txLineSmall
				Else
					line.Text = String.Format("{0}={1}", letter, distance.ToString())
				End If

				line.Style.TextStyle.Offset = lineTextOffset
			End If

			Return line
		End Function

		Private Function AddLabel(ByVal center As NPointF, ByVal text As String, ByVal small As Boolean) As NLineShape
			Dim line As NLineShape = New NLineShape(center, New NPointF(center.X + 0.01f, center.Y + 0.01f))
			document.ActiveLayer.AddChild(line)
			line.Style.StrokeStyle = New NStrokeStyle(0, Color.White)
			line.Text = text
			If small Then
				line.Style.TextStyle = txLineSmall
			Else
				line.Style.TextStyle = txLine
			End If
			Return line
		End Function

		#End Region

		#Region "Nested Classes"

		Private Class BathRoom
			'	lines
			Public Const a1 As Integer = InnerHallway.a5
			Public Const a2 As Integer = InnerHallway.a4
			Public Const a3 As Integer = 75
			Public Const a4 As Integer = 154

			Public Const b1 As Integer = 165

			'	calculated sizes
			Public Const width As Integer = a1 + a2 + a3
			Public Const depth As Integer = b1

			'	rim
			Public Shared points As NPointF() = New NPointF() { New NPointF(0, 0), New NPointF(a1, 0), New NPointF(a1 + a2, 0), New NPointF(a1 + a2 + a3, 0), New NPointF(a1 + a2 + a3, b1), New NPointF(a1 + a2 + a3 - a4, b1) }
		End Class

		Private Class BedRoom
			'	lines
			Public Const a1 As Integer = 437
			Public Const a2 As Integer = 437

			Public Const b1 As Integer = 95
			Public Const b2 As Integer = 226
			Public Const b3 As Integer = 18
			Public Const b4 As Integer = 286
			Public Const b5 As Integer = b1 + b2 - b3 - b4

			'	calculated sizes
			Public Const width As Integer = a1
			Public Const depth As Integer = b1 + b2

			'	rim
			Public Shared points As NPointF() = New NPointF() { New NPointF(0, 0), New NPointF(a1, 0), New NPointF(a1, b1), New NPointF(a1, b1 + b2), New NPointF(a1 - a2, b1 + b2), New NPointF(a1 - a2, b1 + b2 - b3), New NPointF(a1 - a2, b1 + b2 - b3 - b4) }
		End Class

		Private Class Dresser
			'	lines
			Public Const a1 As Integer = 81
			Public Const a2 As Integer = 81

			Public Const b1 As Integer = Hallway.b1 + Hallway.b2 - Hallway.b3

			'	calculated sizes
			Public Const width As Integer = a1
			Public Const depth As Integer = b1

			'	rim
			Public Shared points As NPointF() = New NPointF() { New NPointF(0, 0), New NPointF(a1, 0), New NPointF(a1, b1), New NPointF(a1 - a2, b1) }
		End Class

		Private Class GuestRoom
			'	lines
			Public Const a0 As Integer = 49
			Public Const a1 As Integer = 5
			Public Const a2 As Integer = 95
			Public Const a21 As Integer = 5
			Public Const a3 As Integer = 248
			Public Const a4 As Integer = 39
			Public Const a5 As Integer = 425
			Public Const a6 As Integer = 33

			Public Const b1 As Integer = 20
			Public Const b2 As Integer = 295
			Public Const b3 As Integer = 20
			Public Const b4 As Integer = 265

			'	calculated sizes
			Public Const width As Integer = a1
			Public Const depth As Integer = b1 + b2

			'	rim
			Public Shared points As NPointF() = New NPointF() { New NPointF(a0, 0), New NPointF(a0 + a1, 0), New NPointF(a0 + a1 + a2, 0), New NPointF(a0 + a1 + a2 + a21, 0), New NPointF(a0 + a1 + a2 + a21 + a3, 0), New NPointF(a0 + a1 + a2 + a21 + a3 + a4, 0), New NPointF(a0 + a1 + a2 + a21 + a3 + a4, b1), New NPointF(a0 + a1 + a2 + a21 + a3 + a4, b1 + b2), New NPointF(a0 + a1 + a2 + a21 + a3 + a4, b1 + b2 + b3), New NPointF(a0 + a1 + a2 + a21 + a3 + a4 - a5, b1 + b2 + b3), New NPointF(a0 + a1 + a2 + a21 + a3 + a4 - a5, b1 + b2 + b3 - b4), New NPointF(a0 + a1 + a2 + a21 + a3 + a4 - a5 + a6, b1 + b2 + b3 - b4) }
		End Class

		Private Class Hallway
			'	lines
			Public Const a1 As Integer = 147
			Public Const a2 As Integer = 14
			Public Const a3 As Integer = 70
			Public Const a4 As Integer = 72
			Public Const a5 As Integer = 5
			Public Const a6 As Integer = 5
			Public Const a7 As Integer = 95
			Public Const a8 As Integer = 117
			Public Const a9 As Integer = 86
			Public Const a10 As Integer = 5

			Public Const b1 As Integer = 26
			Public Const b2 As Integer = 181
			Public Const b3 As Integer = 5
			Public Const b4 As Integer = 5
			Public Const b5 As Integer = 95
			Public Const b6 As Integer = 5
			Public Const b7 As Integer = 38
			Public Const b8 As Integer = LivingRoom.b3
			Public Const b9 As Integer = b1 + b2 - b3 + b4 + b5 + b6 - b7 - b8

			'	calculated sizes
			Public Const width As Integer = a1 + a2 + a3 + a4 + a5
			Public Const depth As Integer = b1 + b2 - b3 + b4 + b5 + b6

			'	rim
			Public Shared points As NPointF() = New NPointF() { New NPointF(0, 0), New NPointF(a1, 0), New NPointF(a1, b1), New NPointF(a1, b1 + b2), New NPointF(a1 + a2, b1 + b2), New NPointF(a1 + a2, b1 + b2 - b3), New NPointF(a1 + a2 + a3, b1 + b2 - b3), New NPointF(a1 + a2 + a3 + a4, b1 + b2 - b3), New NPointF(a1 + a2 + a3 + a4 + a5, b1 + b2 - b3), New NPointF(a1 + a2 + a3 + a4 + a5, b1 + b2 - b3 + b4), New NPointF(a1 + a2 + a3 + a4 + a5, b1 + b2 - b3 + b4 + b5), New NPointF(a1 + a2 + a3 + a4 + a5, b1 + b2 - b3 + b4 + b5 + b6), New NPointF(a1 + a2 + a3 + a4 + a5 - a6, b1 + b2 - b3 + b4 + b5 + b6), New NPointF(a1 + a2 + a3 + a4 + a5 - a6 - a7, b1 + b2 - b3 + b4 + b5 + b6), New NPointF(a1 + a2 + a3 + a4 + a5 - a6 - a7 - a8, b1 + b2 - b3 + b4 + b5 + b6), New NPointF(a1 + a2 + a3 + a4 + a5 - a6 - a7 - a8 - a9, b1 + b2 - b3 + b4 + b5 + b6), New NPointF(a1 + a2 + a3 + a4 + a5 - a6 - a7 - a8 - a9 - a10, b1 + b2 - b3 + b4 + b5 + b6), New NPointF(a1 + a2 + a3 + a4 + a5 - a6 - a7 - a8 - a9 - a10, b1 + b2 - b3 + b4 + b5 + b6 - b7), New NPointF(a1 + a2 + a3 + a4 + a5 - a6 - a7 - a8 - a9 - a10, b9) }

			'	special points
			Public Shared section1Center As NPointF = New NPointF(a1 / 2, b1 / 2)
		End Class

		Private Class InnerHallway
			'	lines
			Public Const a1 As Integer = 86
			Public Const a11 As Integer = 5
			Public Const a2 As Integer = 55
			Public Const a3 As Integer = 67
			Public Const a4 As Integer = 74
			Public Const a5 As Integer = 5

			Public Const b1 As Integer = 114
			Public Const b2 As Integer = 19

			'	calculated sizes
			Public Const width As Integer = a1 + a2 + a3
			Public Const depth As Integer = b1

			'	rim
			Public Shared points As NPointF() = New NPointF() { New NPointF(0, 0), New NPointF(a11, 0), New NPointF(a11 + a1, 0), New NPointF(a11 + a1 + a2, 0), New NPointF(a11 + a1 + a2, b1), New NPointF(a11 + a1 + a2 - a3, b1), New NPointF(a11 + a1 + a2 - a3 - a4, b1), New NPointF(a11 + a1 + a2 - a3 - a4 - a5, b1), New NPointF(a11 + a1 + a2 - a3 - a4 - a5, b1 - b2) }
		End Class

		Private Class Kitchen
			'	lines
			Public Const a0 As Integer = 57
			Public Const a1 As Integer = 229
			Public Const a2 As Integer = 38
			Public Const a3 As Integer = 248
			Public Const a4 As Integer = 25
			Public Const a5 As Integer = 32

			Public Const b0 As Integer = -28
			Public Const b1 As Integer = 73
			Public Const b2 As Integer = 72
			Public Const b3 As Integer = 218
			Public Const b4 As Integer = 62
			Public Const b5 As Integer = Hallway.b6
			Public Const b6 As Integer = Hallway.b5
			Public Const b7 As Integer = 177
			Public Const b8 As Integer = 94

			'	calculated sizes
			Public Const width As Integer = a1 + a4 + a5
			Public Const depth As Integer = b1 + b2 + b3 + b4

			'	rim
			Public Shared points As NPointF() = New NPointF() { New NPointF(a0, b0), New NPointF(a0 + a1, b0), New NPointF(a0 + a1, b0 + b1), New NPointF(a0 + a1, b0 + b1 + b2), New NPointF(a0 + a1, b0 + b1 + b2 + b3), New NPointF(a0 + a1 - a2, b0 + b1 + b2 + b3), New NPointF(a0 + a1 - a2, b0 + b1 + b2 + b3 + b4), New NPointF(a0 + a1 - a2 - a3, b0 + b1 + b2 + b3 + b4), New NPointF(a0 + a1 - a2 - a3, b0 + b1 + b2 + b3 + b4 - b5), New NPointF(a0 + a1 - a2 - a3, b0 + b1 + b2 + b3 + b4 - b5 - b6), New NPointF(a0 + a1 - a2 - a3, b0 + b1 + b2 + b3 + b4 - b5 - b6 - b7), New NPointF(a0 + a1 - a2 - a3 + a4, b0 + b1 + b2 + b3 + b4 - b5 - b6 - b7), New NPointF(a0 + a1 - a2 - a3 + a4, b0 + b1 + b2 + b3 + b4 - b5 - b6 - b7 - b8), New NPointF(a0 + a1 - a2 - a3 + a4 + a5, b0 + b1 + b2 + b3 + b4 - b5 - b6 - b7 - b8) }
		End Class

		Private Class LivingRoom
			'	lines
			Public Const a1 As Integer = 553
			Public Const a2 As Integer = 13
			Public Const a3 As Integer = 131
			Public Const a4 As Integer = 306
			Public Const a5 As Integer = 129

			Public Const b1 As Integer = 90
			Public Const b2 As Integer = 174
			Public Const b3 As Integer = 95
			Public Const b4 As Integer = 5
			Public Const b5 As Integer = 33
			Public Const b6 As Integer = 67
			Public Const b7 As Integer = b1 + b2 + b3 + b4 + b5 - b6

			'	calculated sizes
			Public Const width As Integer = a1 + a2
			Public Const depth As Integer = b1 + b2 + b3 + b4 + b5

			'	rim
			Public Shared points As NPointF() = New NPointF() { New NPointF(0, 0), New NPointF(a1, 0), New NPointF(a1, b1), New NPointF(a1 + a2, b1), New NPointF(a1 + a2, b1 + b2), New NPointF(a1 + a2, b1 + b2 + b3), New NPointF(a1 + a2, b1 + b2 + b3 + b4), New NPointF(a1 + a2 - a3, b1 + b2 + b3 + b4), New NPointF(a1 + a2 - a3, b1 + b2 + b3 + b4 + b5), New NPointF(a1 + a2 - a3 - a4, b1 + b2 + b3 + b4 + b5), New NPointF(a1 + a2 - a3 - a4, b1 + b2 + b3 + b4 + b5 - b6), New NPointF(a1 + a2 - a3 - a4 - a5, b7) }

			'	special points
			Public Shared section1Center As NPointF = New NPointF(a5 / 2, b7 / 2)
			Public Shared section2Center As NPointF = New NPointF(a1 + a2 / 2, b1 + (b2 + b3 + b4) / 2)
		End Class

		Private Class Toilet
			'	lines
			Public Const a1 As Integer = 83
			Public Const a2 As Integer = 5
			Public Const a3 As Integer = 72
			Public Const a4 As Integer = 6

			Public Const b0 As Integer = 82
			Public Const b1 As Integer = 120

			'	rim
			Public Shared points As NPointF() = New NPointF() { New NPointF(0, b0), New NPointF(a1, b0), New NPointF(a1, b0 + b1), New NPointF(a1 - a2, b0 + b1), New NPointF(a1 - a2 - a3, b0 + b1), New NPointF(a1 - a2 - a3 - a4, b0 + b1) }
		End Class

		Private Class Balcony1
			'	lines
			Public Const a1 As Integer = 100
			Public Const a2 As Integer = 100

			Public Const b1 As Integer = 425
			Public Const b2 As Integer = 280
			Public Const b3 As Integer = 72

			'	rim
			Public Shared points As NPointF() = New NPointF() { New NPointF(0, 0), New NPointF(a1, 0), New NPointF(a1, b1), New NPointF(a1 - a2, b1), New NPointF(a1 - a2, b1 - b2), New NPointF(a1 - a2, b1 - b2 - b3) }
		End Class

		Private Class Balcony2
			'	lines
			Public Const a1 As Integer = LivingRoom.a5
			Public Const a2 As Integer = LivingRoom.a5

			Public Const b1 As Integer = LivingRoom.b6 + BedRoom.b5
			Public Const b2 As Integer = BedRoom.b4
			Public Const b3 As Integer = BedRoom.b3

			'	rim
			Public Shared points As NPointF() = New NPointF() { New NPointF(0, 0), New NPointF(a1, 0), New NPointF(a1, b1), New NPointF(a1, b1 + b2), New NPointF(a1, b1 + b2 + b3), New NPointF(a1 - a2, b1 + b2 + b3) }
		End Class

		#End Region

		#Region "Fields"

		Private txMain As NTextStyle
		Private txLine As NTextStyle
		Private txLineSmall As NTextStyle

		Private sstOdd As NStrokeStyle
		Private sstEven As NStrokeStyle

		Private minNormalLineLength As Integer
		Private lineTextOffset As NPointL
		Private defaultRoomMargin As Integer

		Private roomMargin As Integer
		Private displayLengths As Boolean
		Private initializingControls As Boolean

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents showSizesCheckBox As CheckBox
		Private label1 As Label
		Private WithEvents singleRoomComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As Label
		Private WithEvents scaleComboBox As Nevron.UI.WinForm.Controls.NComboBox

		#End Region
	End Class
End Namespace