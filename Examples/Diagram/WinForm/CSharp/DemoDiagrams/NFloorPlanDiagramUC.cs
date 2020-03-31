using System;
using System.Globalization;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WinForm;
using Nevron.Diagram.Batches;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NFloorPlanDiagramUC.
	/// </summary>
	public class NFloorPlanDiagramUC : NDiagramExampleUC
	{
		#region Constructor

		public NFloorPlanDiagramUC(NMainForm form)
			: base(form)
		{
			initializingControls = true;

			InitializeComponent();

			//	styles
			txMain = new NTextStyle();
			txMain.FontStyle = new NFontStyle("Arial", 9);
			txMain.BackplaneStyle.Visible = false;
			txMain.Offset = new NPointL(0, 0);

			txLine = new NTextStyle();
			txLine.FontStyle = new NFontStyle("Arial", 9);
			txLine.BackplaneStyle.Visible = true;
			txLine.BackplaneStyle.FillStyle = new NColorFillStyle(Color.FromArgb(128, Color.White));
			txLine.BackplaneStyle.StandardFrameStyle.Visible = false;

			txLineSmall = new NTextStyle();
			txLineSmall.FontStyle = new NFontStyle("Arial", 5);
			txLineSmall.BackplaneStyle.Visible = true;
			txLineSmall.BackplaneStyle.FillStyle = new NColorFillStyle(Color.FromArgb(128, Color.White));
			txLineSmall.BackplaneStyle.StandardFrameStyle.Visible = false;

			sstOdd = new NStrokeStyle(1, Color.Black);
			sstEven = new NStrokeStyle(1, Color.LightGray);

			initializingControls = false;
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.showSizesCheckBox = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.scaleComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.singleRoomComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// showSizesCheckBox
			// 
			this.showSizesCheckBox.AutoSize = true;
			this.showSizesCheckBox.Checked = true;
			this.showSizesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showSizesCheckBox.Location = new System.Drawing.Point(8, 12);
			this.showSizesCheckBox.Name = "showSizesCheckBox";
			this.showSizesCheckBox.Size = new System.Drawing.Size(81, 17);
			this.showSizesCheckBox.TabIndex = 1;
			this.showSizesCheckBox.Text = "Show Sizes";
			this.showSizesCheckBox.UseVisualStyleBackColor = true;
			this.showSizesCheckBox.CheckedChanged += new System.EventHandler(this.showSizesCheckBox_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(105, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Scale:";
			// 
			// scaleComboBox
			// 
			this.scaleComboBox.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("0.75", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("0.8", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("0.9", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("1", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("1.1", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("1.15", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("1.2", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("1.25", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("1.5", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("1.75", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("2", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("4", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("8", -1, false, 0, new System.Drawing.Size(0, 0))});
			this.scaleComboBox.Location = new System.Drawing.Point(146, 10);
			this.scaleComboBox.Name = "scaleComboBox";
			this.scaleComboBox.Size = new System.Drawing.Size(94, 21);
			this.scaleComboBox.TabIndex = 3;
			this.scaleComboBox.SelectedIndexChanged += new System.EventHandler(this.scaleComboBox_SelectedIndexChanged);
			// 
			// singleRoomComboBox
			// 
			this.singleRoomComboBox.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("-", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("LivingRoom", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Hallway", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Dresser", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Toilet", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Kitchen", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("BedRoom", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("InnerHallway", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("BathRoom", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("GuestRoom", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Balcony1", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Balcony2", -1, false, 0, new System.Drawing.Size(0, 0))});
			this.singleRoomComboBox.Location = new System.Drawing.Point(81, 35);
			this.singleRoomComboBox.Name = "singleRoomComboBox";
			this.singleRoomComboBox.Size = new System.Drawing.Size(159, 21);
			this.singleRoomComboBox.TabIndex = 3;
			this.singleRoomComboBox.SelectedIndexChanged += new System.EventHandler(this.singleRoomComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Single Room:";
			// 
			// NFloorPlanDiagramUC
			// 
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.singleRoomComboBox);
			this.Controls.Add(this.scaleComboBox);
			this.Controls.Add(this.showSizesCheckBox);
			this.Name = "NFloorPlanDiagramUC";
			this.Size = new System.Drawing.Size(248, 384);
			this.Controls.SetChildIndex(this.showSizesCheckBox, 0);
			this.Controls.SetChildIndex(this.scaleComboBox, 0);
			this.Controls.SetChildIndex(this.singleRoomComboBox, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			scaleComboBox.SelectedIndex = scaleComboBox.FindStringExact("0.75");
			singleRoomComboBox.SelectedIndex = singleRoomComboBox.FindStringExact("-");
			
			// begin view init
			view.BeginInit();

			// init document
			document.BeginInit();

			SetupDocumentAndView();
			CreateDiagram(null);
			
			document.EndInit();
			view.EndInit();
		}

		#endregion

		#region Event Handlers

		private void showSizesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			singleRoomComboBox.SelectedIndex = singleRoomComboBox.FindStringExact("-");
			OnShowSizesChanged();
		}

		private void scaleComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (scaleComboBox.SelectedItem == null)
				return;

			document.HistoryService.Pause();
			document.CustomScale = float.Parse(scaleComboBox.SelectedItem.ToString(), CultureInfo.InvariantCulture.NumberFormat);
			document.HistoryService.Resume();
			document.SmartRefreshAllViews();
		}

		private void singleRoomComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (singleRoomComboBox.SelectedIndex == -1)
				return;

			CreateDiagram(singleRoomComboBox.SelectedItem.ToString());
		}

		#endregion

		#region Implementation

		void SetupDocumentAndView()
		{
			//	misc
			minNormalLineLength = 30;
			
			lineTextOffset = new NPointL(0, -6);
			defaultRoomMargin = 25;
			roomMargin = defaultRoomMargin;
			displayLengths = true;

			//	document
			document.MeasurementUnit = NMetricUnit.Centimeter;
			document.DrawingScaleMode = DrawingScaleMode.CustomScale;
			document.CustomWorldMeasurementUnit = NGraphicsUnit.Pixel;

			document.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent;
			document.AutoBoundsPadding = new Nevron.Diagram.NMargins(20);
			document.Style.StrokeStyle = new NStrokeStyle(0, Color.White);
			document.Style.FillStyle = new NHatchFillStyle(System.Drawing.Drawing2D.HatchStyle.DottedGrid, Color.LightGray, Color.White);

			//	view
			view.ViewLayout = ViewLayout.Normal;
		}

		void OnShowSizesChanged()
		{
			if (showSizesCheckBox.Checked)
			{
				roomMargin = defaultRoomMargin;
				displayLengths = true;
				CreateDiagram(null);
				scaleComboBox.SelectedIndex = scaleComboBox.FindStringExact("0.75");
			}
			else
			{
				roomMargin = 0;
				displayLengths = false;
				CreateDiagram(null);
				scaleComboBox.SelectedIndex = scaleComboBox.FindStringExact("0.8");
			}
		}

		void CreateDiagram(string roomName)
		{
			if (initializingControls)
				return;

			document.BeginInit();
			document.ActiveLayer.RemoveAllChildren();

			if (roomName == null)
			{
				CreateLivingRoom(new NPointF(0, 0));
				CreateHallway(new NPointF(LivingRoom.width + roomMargin, LivingRoom.b1));
				CreateDresser(new NPointF(LivingRoom.width + Hallway.a1 + 2 * roomMargin, LivingRoom.b1 - roomMargin));
				CreateToilet(new NPointF(LivingRoom.width + Hallway.a1 + Dresser.width + 3 * roomMargin, LivingRoom.b1 - roomMargin));
				CreateKitchen(new NPointF(LivingRoom.width + Hallway.width + 4 * roomMargin, 0));
				CreateBedRoom(new NPointF(LivingRoom.a5, LivingRoom.depth + roomMargin));
				CreateInnerHallway(new NPointF(LivingRoom.a5 + BedRoom.width + roomMargin, LivingRoom.depth + roomMargin));
				CreateBathRoom(new NPointF(LivingRoom.a5 + BedRoom.width + roomMargin, LivingRoom.depth + InnerHallway.depth + 2 * roomMargin));
				CreateGuestRoom(new NPointF(LivingRoom.a5 + BedRoom.width + BathRoom.width + 2 * roomMargin, LivingRoom.depth + roomMargin));
				CreateBalcony1(new NPointF(LivingRoom.width + Hallway.width + Kitchen.width + 5 * roomMargin, Kitchen.b0));
				CreateBalcony2(new NPointF(-roomMargin, LivingRoom.b7 + roomMargin));
			}
			else
			{
				switch (roomName)
				{
					case "-":
						OnShowSizesChanged();
						break;
					case "LivingRoom":
						CreateLivingRoom(new NPointF(0, 0));
						break;
					case "Hallway":
						CreateHallway(new NPointF(0, 0));
						break;
					case "Dresser":
						CreateDresser(new NPointF(0, 0));
						break;
					case "Toilet":
						CreateToilet(new NPointF(0, 0));
						break;
					case "Kitchen":
						CreateKitchen(new NPointF(0, 0));
						break;
					case "BedRoom":
						CreateBedRoom(new NPointF(0, 0));
						break;
					case "InnerHallway":
						CreateInnerHallway(new NPointF(0, 0));
						break;
					case "BathRoom":
						CreateBathRoom(new NPointF(0, 0));
						break;
					case "GuestRoom":
						CreateGuestRoom(new NPointF(0, 0));
						break;
					case "Balcony1":
						CreateBalcony1(new NPointF(0, 0));
						break;
					case "Balcony2":
						CreateBalcony2(new NPointF(0, 0));
						break;
				}
			}

			document.SizeToContent();
			document.EndInit();
		}

		void CreateLivingRoom(NPointF offset)
		{
			NPointF[] points = ApplyOffset(LivingRoom.points, offset);

			NPolygonShape p = new NPolygonShape(points);
			p.Text = "Living Room, H=265";
			p.Style.TextStyle = txMain;
			document.ActiveLayer.AddChild(p);

			NNodeList labels = new NNodeList();
			labels.Add(AddLabel(LivingRoom.section1Center, "H=240", false));
			labels.Add(AddLabel(LivingRoom.section2Center, "H=240", true));

			CreateLabeledPolyOutline(points, p, labels, "Living Room");
		}

		void CreateHallway(NPointF offset)
		{
			NPointF[] points = ApplyOffset(Hallway.points, offset);

			NPolygonShape p = new NPolygonShape(points);
			p.Text = "Hallway, H=270";
			p.Style.TextStyle = txMain.Clone() as NTextStyle;
			p.Style.TextStyle.Offset = new NPointL(-60, 0);
			document.ActiveLayer.AddChild(p);

			NNodeList labels = new NNodeList();
			labels.Add(AddLabel(ApplyOffset(Hallway.section1Center, offset), "H=240", false));

			CreateLabeledPolyOutline(points, p, labels, "Hallway");
		}

		void CreateDresser(NPointF offset)
		{
			NPointF[] points = ApplyOffset(Dresser.points, offset);

			NPolygonShape p = new NPolygonShape(points);
			p.Text = "Dresser, H=270";
			p.Style.TextStyle = txMain.Clone() as NTextStyle;
			document.ActiveLayer.AddChild(p);

			CreateLabeledPolyOutline(points, p, null, "Dresser");
		}

		void CreateToilet(NPointF offset)
		{
			NPointF[] points = ApplyOffset(Toilet.points, offset);

			NPolygonShape p = new NPolygonShape(points);
			p.Text = "Toilet, H=270";
			p.Style.TextStyle = txMain.Clone() as NTextStyle;
			document.ActiveLayer.AddChild(p);

			CreateLabeledPolyOutline(points, p, null, "Toilet");
		}

		void CreateKitchen(NPointF offset)
		{
			NPointF[] points = ApplyOffset(Kitchen.points, offset);

			NPolygonShape p = new NPolygonShape(points);
			p.Text = "Kitchen, H=265";
			p.Style.TextStyle = txMain.Clone() as NTextStyle;
			document.ActiveLayer.AddChild(p);

			CreateLabeledPolyOutline(points, p, null, "Kitchen");
		}

		void CreateBedRoom(NPointF offset)
		{
			NPointF[] points = ApplyOffset(BedRoom.points, offset);

			NPolygonShape p = new NPolygonShape(points);
			p.Text = "Bedroom, H=265";
			p.Style.TextStyle = txMain.Clone() as NTextStyle;
			document.ActiveLayer.AddChild(p);

			CreateLabeledPolyOutline(points, p, null, "Bedroom");
		}

		void CreateInnerHallway(NPointF offset)
		{
			NPointF[] points = ApplyOffset(InnerHallway.points, offset);

			NPolygonShape p = new NPolygonShape(points);
			p.Text = "Inn.Hallway, H=270";
			p.Style.TextStyle = txMain.Clone() as NTextStyle;
			document.ActiveLayer.AddChild(p);

			CreateLabeledPolyOutline(points, p, null, "Inner Hallway");
		}

		void CreateBathRoom(NPointF offset)
		{
			NPointF[] points = ApplyOffset(BathRoom.points, offset);

			NPolygonShape p = new NPolygonShape(points);
			p.Text = "Bathroom, H=250";
			p.Style.TextStyle = txMain.Clone() as NTextStyle;
			document.ActiveLayer.AddChild(p);

			CreateLabeledPolyOutline(points, p, null, "Bathroom");
		}

		void CreateGuestRoom(NPointF offset)
		{
			NPointF[] points = ApplyOffset(GuestRoom.points, offset);

			NPolygonShape p = new NPolygonShape(points);
			p.Text = "Guest Room, H=270";
			p.Style.TextStyle = txMain.Clone() as NTextStyle;
			document.ActiveLayer.AddChild(p);

			CreateLabeledPolyOutline(points, p, null, "Guest Room");
		}

		void CreateBalcony1(NPointF offset)
		{
			NPointF[] points = ApplyOffset(Balcony1.points, offset);

			NPolygonShape p = new NPolygonShape(points);
			p.Text = "Kitchen Balcony";
			p.Style.TextStyle = txMain.Clone() as NTextStyle;
			document.ActiveLayer.AddChild(p);

			CreateLabeledPolyOutline(points, p, null, "Kitchen Balcony");
		}

		void CreateBalcony2(NPointF offset)
		{
			NPointF[] points = ApplyOffset(Balcony2.points, offset);

			NPolygonShape p = new NPolygonShape(points);
			p.Text = "Bedroom Balcony";
			p.Style.TextStyle = txMain.Clone() as NTextStyle;
			document.ActiveLayer.AddChild(p);

			CreateLabeledPolyOutline(points, p, null, "Bedroom Balcony");
		}


		NPointF[] ApplyOffset(NPointF[] points, NPointF offset)
		{
			int length = points.Length;
			NPointF[] result = new NPointF[length];
			for (int i = 0; i < length; i++)
			{
				result[i] = new NPointF(points[i].X + offset.X, points[i].Y + offset.Y);
			}
			return result;
		}

		NPointF ApplyOffset(NPointF point, NPointF offset)
		{
			return new NPointF(point.X + offset.X, point.Y + offset.Y);
		}

		void CreateLabeledPolyOutline(NPointF[] points, NPolygonShape polyShape, NNodeList labels, string title)
		{
			NNodeList nodes = new NNodeList();
			nodes.Add(polyShape);
			if(labels != null)
				nodes.AddRange(labels);

			int length = points.Length - 1;
			int vIndex = 0, hIndex = 0, index = 0;
			for (int i = 0; i < length; i++)
			{
				nodes.Add(ConnectPointsLabeled(points[i], points[i + 1], ref hIndex, ref vIndex, ref index));
			}
			nodes.Add(ConnectPointsLabeled(points[points.Length - 1], points[0], ref hIndex, ref vIndex, ref index));

			NGroup g;
			NBatchGroup batchGroup = new NBatchGroup(document);
			batchGroup.Build(nodes);
			batchGroup.Group(document.ActiveLayer, true, out g);
			g.Name = title + " Group";
		}

		NLineShape ConnectPointsLabeled(NPointF p1, NPointF p2, ref int hIndex, ref int vIndex, ref int index)
		{
			float dx = p2.X - p1.X;
			float dy = p2.Y - p1.Y;
			float distance = (float)Math.Sqrt(dx * dx + dy * dy);

			string letter;
			if (Math.Floor(dy) == 0)
			{
				hIndex++;
				letter = "a" + hIndex;
			}
			else
			{
				vIndex++;
				letter = "b" + vIndex;
			}
			index++;

			NLineShape line = new NLineShape(p1, p2);
			document.ActiveLayer.AddChild(line);

			if (index % 2 == 0)
				line.Style.StrokeStyle = sstEven;
			else
				line.Style.StrokeStyle = sstOdd;

			if (displayLengths)
			{
				line.Style.TextStyle = txLine.Clone() as NTextStyle;
				if (distance < minNormalLineLength)
				{
					line.Text = distance.ToString();
					line.Style.TextStyle = txLineSmall;
				}
				else
				{
					line.Text = string.Format("{0}={1}", letter, distance.ToString());
				}

				line.Style.TextStyle.Offset = lineTextOffset;
			}

			return line;
		}

		NLineShape AddLabel(NPointF center, string text, bool small)
		{
			NLineShape line = new NLineShape(center, new NPointF(center.X + 0.01f, center.Y + 0.01f));
			document.ActiveLayer.AddChild(line);
			line.Style.StrokeStyle = new NStrokeStyle(0, Color.White);
			line.Text = text;
			if (small)
				line.Style.TextStyle = txLineSmall;
			else
				line.Style.TextStyle = txLine;
			return line;
		}

		#endregion

		#region Nested Classes

		static class BathRoom
		{
			//	lines
			public const int a1 = InnerHallway.a5;
			public const int a2 = InnerHallway.a4;
			public const int a3 = 75;
			public const int a4 = 154;

			public const int b1 = 165;

			//	calculated sizes
			public const int width = a1 + a2 + a3;
			public const int depth = b1;

			//	rim
			public static NPointF[] points = new NPointF[]
			{
				new NPointF(0, 0),
				new NPointF(a1, 0),
				new NPointF(a1 + a2, 0),
				new NPointF(a1 + a2 + a3, 0),
				new NPointF(a1 + a2 + a3, b1),
				new NPointF(a1 + a2 + a3 - a4, b1),
			};
		}

		static class BedRoom
		{
			//	lines
			public const int a1 = 437;
			public const int a2 = 437;

			public const int b1 = 95;
			public const int b2 = 226;
			public const int b3 = 18;
			public const int b4 = 286;
			public const int b5 = b1 + b2 - b3 - b4;

			//	calculated sizes
			public const int width = a1;
			public const int depth = b1 + b2;

			//	rim
			public static NPointF[] points = new NPointF[]
			{
				new NPointF(0, 0),
				new NPointF(a1, 0),
				new NPointF(a1, b1),
				new NPointF(a1, b1 + b2),
				new NPointF(a1 - a2, b1 + b2),
				new NPointF(a1 - a2, b1 + b2 - b3),
				new NPointF(a1 - a2, b1 + b2 - b3 - b4),
			};
		}

		static class Dresser
		{
			//	lines
			public const int a1 = 81;
			public const int a2 = 81;

			public const int b1 = Hallway.b1 + Hallway.b2 - Hallway.b3;

			//	calculated sizes
			public const int width = a1;
			public const int depth = b1;

			//	rim
			public static NPointF[] points = new NPointF[]
			{
				new NPointF(0, 0),
				new NPointF(a1, 0),
				new NPointF(a1, b1),
				new NPointF(a1 - a2, b1),
			};
		}

		static class GuestRoom
		{
			//	lines
			public const int a0 = 49;
			public const int a1 = 5;
			public const int a2 = 95;
			public const int a21 = 5;
			public const int a3 = 248;
			public const int a4 = 39;
			public const int a5 = 425;
			public const int a6 = 33;

			public const int b1 = 20;
			public const int b2 = 295;
			public const int b3 = 20;
			public const int b4 = 265;

			//	calculated sizes
			public const int width = a1;
			public const int depth = b1 + b2;

			//	rim
			public static NPointF[] points = new NPointF[]
			{
				new NPointF(a0, 0),
				new NPointF(a0 + a1, 0),
				new NPointF(a0 + a1 + a2, 0),
				new NPointF(a0 + a1 + a2 + a21, 0),
				new NPointF(a0 + a1 + a2 + a21 + a3, 0),
				new NPointF(a0 + a1 + a2 + a21 + a3 + a4, 0),
				new NPointF(a0 + a1 + a2 + a21 + a3 + a4, b1),
				new NPointF(a0 + a1 + a2 + a21 + a3 + a4, b1 + b2),
				new NPointF(a0 + a1 + a2 + a21 + a3 + a4, b1 + b2 + b3),
				new NPointF(a0 + a1 + a2 + a21 + a3 + a4 - a5, b1 + b2 + b3),
				new NPointF(a0 + a1 + a2 + a21 + a3 + a4 - a5, b1 + b2 + b3 - b4),
				new NPointF(a0 + a1 + a2 + a21 + a3 + a4 - a5 + a6, b1 + b2 + b3 - b4),
			};
		}

		static class Hallway
		{
			//	lines
			public const int a1 = 147;
			public const int a2 = 14;
			public const int a3 = 70;
			public const int a4 = 72;
			public const int a5 = 5;
			public const int a6 = 5;
			public const int a7 = 95;
			public const int a8 = 117;
			public const int a9 = 86;
			public const int a10 = 5;

			public const int b1 = 26;
			public const int b2 = 181;
			public const int b3 = 5;
			public const int b4 = 5;
			public const int b5 = 95;
			public const int b6 = 5;
			public const int b7 = 38;
			public const int b8 = LivingRoom.b3;
			public const int b9 = b1 + b2 - b3 + b4 + b5 + b6 - b7 - b8;

			//	calculated sizes
			public const int width = a1 + a2 + a3 + a4 + a5;
			public const int depth = b1 + b2 - b3 + b4 + b5 + b6;

			//	rim
			public static NPointF[] points = new NPointF[]
			{
				new NPointF(0, 0),
				new NPointF(a1, 0),
				new NPointF(a1, b1),
				new NPointF(a1, b1 + b2),
				new NPointF(a1 + a2, b1 + b2),
				new NPointF(a1 + a2, b1 + b2 - b3),
				new NPointF(a1 + a2 + a3, b1 + b2 - b3),
				new NPointF(a1 + a2 + a3 + a4, b1 + b2 - b3),
				new NPointF(a1 + a2 + a3 + a4 + a5, b1 + b2 - b3),
				new NPointF(a1 + a2 + a3 + a4 + a5, b1 + b2 - b3 + b4),
				new NPointF(a1 + a2 + a3 + a4 + a5, b1 + b2 - b3 + b4 + b5),
				new NPointF(a1 + a2 + a3 + a4 + a5, b1 + b2 - b3 + b4 + b5 + b6),
				new NPointF(a1 + a2 + a3 + a4 + a5 - a6, b1 + b2 - b3 + b4 + b5 + b6),
				new NPointF(a1 + a2 + a3 + a4 + a5 - a6 - a7, b1 + b2 - b3 + b4 + b5 + b6),
				new NPointF(a1 + a2 + a3 + a4 + a5 - a6 - a7 - a8, b1 + b2 - b3 + b4 + b5 + b6),
				new NPointF(a1 + a2 + a3 + a4 + a5 - a6 - a7 - a8 - a9, b1 + b2 - b3 + b4 + b5 + b6),
				new NPointF(a1 + a2 + a3 + a4 + a5 - a6 - a7 - a8 - a9 - a10, b1 + b2 - b3 + b4 + b5 + b6),
				new NPointF(a1 + a2 + a3 + a4 + a5 - a6 - a7 - a8 - a9 - a10, b1 + b2 - b3 + b4 + b5 + b6 - b7),
				new NPointF(a1 + a2 + a3 + a4 + a5 - a6 - a7 - a8 - a9 - a10, b9),
			};

			//	special points
			public static NPointF section1Center = new NPointF(a1 / 2, b1 / 2);
		}

		static class InnerHallway
		{
			//	lines
			public const int a1 = 86;
			public const int a11 = 5;
			public const int a2 = 55;
			public const int a3 = 67;
			public const int a4 = 74;
			public const int a5 = 5;

			public const int b1 = 114;
			public const int b2 = 19;

			//	calculated sizes
			public const int width = a1 + a2 + a3;
			public const int depth = b1;

			//	rim
			public static NPointF[] points = new NPointF[]
			{
				new NPointF(0, 0),
				new NPointF(a11, 0),
				new NPointF(a11 + a1, 0),
				new NPointF(a11 + a1 + a2, 0),
				new NPointF(a11 + a1 + a2, b1),
				new NPointF(a11 + a1 + a2 - a3, b1),
				new NPointF(a11 + a1 + a2 - a3 - a4, b1),
				new NPointF(a11 + a1 + a2 - a3 - a4 - a5, b1),
				new NPointF(a11 + a1 + a2 - a3 - a4 - a5, b1 - b2),
			};
		}

		static class Kitchen
		{
			//	lines
			public const int a0 = 57;
			public const int a1 = 229;
			public const int a2 = 38;
			public const int a3 = 248;
			public const int a4 = 25;
			public const int a5 = 32;

			public const int b0 = -28;
			public const int b1 = 73;
			public const int b2 = 72;
			public const int b3 = 218;
			public const int b4 = 62;
			public const int b5 = Hallway.b6;
			public const int b6 = Hallway.b5;
			public const int b7 = 177;
			public const int b8 = 94;

			//	calculated sizes
			public const int width = a1 + a4 + a5;
			public const int depth = b1 + b2 + b3 + b4;

			//	rim
			public static NPointF[] points = new NPointF[]
			{
				new NPointF(a0, b0),
				new NPointF(a0 + a1, b0),
				new NPointF(a0 + a1, b0 + b1),
				new NPointF(a0 + a1, b0 + b1 + b2),
				new NPointF(a0 + a1, b0 + b1 + b2 + b3),
				new NPointF(a0 + a1 - a2, b0 + b1 + b2 + b3),
				new NPointF(a0 + a1 - a2, b0 + b1 + b2 + b3 + b4),
				new NPointF(a0 + a1 - a2 - a3, b0 + b1 + b2 + b3 + b4),
				new NPointF(a0 + a1 - a2 - a3, b0 + b1 + b2 + b3 + b4 - b5),
				new NPointF(a0 + a1 - a2 - a3, b0 + b1 + b2 + b3 + b4 - b5 - b6),
				new NPointF(a0 + a1 - a2 - a3, b0 + b1 + b2 + b3 + b4 - b5 - b6 - b7),
				new NPointF(a0 + a1 - a2 - a3 + a4, b0 + b1 + b2 + b3 + b4 - b5 - b6 - b7),
				new NPointF(a0 + a1 - a2 - a3 + a4, b0 + b1 + b2 + b3 + b4 - b5 - b6 - b7 - b8),
				new NPointF(a0 + a1 - a2 - a3 + a4 + a5, b0 + b1 + b2 + b3 + b4 - b5 - b6 - b7 - b8),
			};
		}

		static class LivingRoom
		{
			//	lines
			public const int a1 = 553;
			public const int a2 = 13;
			public const int a3 = 131;
			public const int a4 = 306;
			public const int a5 = 129;

			public const int b1 = 90;
			public const int b2 = 174;
			public const int b3 = 95;
			public const int b4 = 5;
			public const int b5 = 33;
			public const int b6 = 67;
			public const int b7 = b1 + b2 + b3 + b4 + b5 - b6;

			//	calculated sizes
			public const int width = a1 + a2;
			public const int depth = b1 + b2 + b3 + b4 + b5;

			//	rim
			public static NPointF[] points = new NPointF[]
			{
				new NPointF(0, 0),
				new NPointF(a1, 0),
				new NPointF(a1, b1),
				new NPointF(a1 + a2, b1),
				new NPointF(a1 + a2, b1 + b2),
				new NPointF(a1 + a2, b1 + b2 + b3),
				new NPointF(a1 + a2, b1 + b2 + b3 + b4),
				new NPointF(a1 + a2 - a3, b1 + b2 + b3 + b4),
				new NPointF(a1 + a2 - a3, b1 + b2 + b3 + b4 + b5),
				new NPointF(a1 + a2 - a3 - a4, b1 + b2 + b3 + b4 + b5),
				new NPointF(a1 + a2 - a3 - a4, b1 + b2 + b3 + b4 + b5 - b6),
				new NPointF(a1 + a2 - a3 - a4 - a5, b7),
			};

			//	special points
			public static NPointF section1Center = new NPointF(a5 / 2, b7 / 2);
			public static NPointF section2Center = new NPointF(a1 + a2 / 2, b1 + (b2 + b3 + b4) / 2);
		}

		static class Toilet
		{
			//	lines
			public const int a1 = 83;
			public const int a2 = 5;
			public const int a3 = 72;
			public const int a4 = 6;

			public const int b0 = 82;
			public const int b1 = 120;

			//	rim
			public static NPointF[] points = new NPointF[]
			{
				new NPointF(0, b0),
				new NPointF(a1, b0),
				new NPointF(a1, b0 + b1),
				new NPointF(a1 - a2, b0 + b1),
				new NPointF(a1 - a2 - a3, b0 + b1),
				new NPointF(a1 - a2 - a3 - a4, b0 + b1),
			};
		}

		static class Balcony1
		{
			//	lines
			public const int a1 = 100;
			public const int a2 = 100;

			public const int b1 = 425;
			public const int b2 = 280;
			public const int b3 = 72;

			//	rim
			public static NPointF[] points = new NPointF[]
			{
				new NPointF(0, 0),
				new NPointF(a1, 0),
				new NPointF(a1, b1),
				new NPointF(a1 - a2, b1),
				new NPointF(a1 - a2, b1 - b2),
				new NPointF(a1 - a2, b1 - b2 - b3),
			};
		}

		static class Balcony2
		{
			//	lines
			public const int a1 = LivingRoom.a5;
			public const int a2 = LivingRoom.a5;

			public const int b1 = LivingRoom.b6 + BedRoom.b5;
			public const int b2 = BedRoom.b4;
			public const int b3 = BedRoom.b3;

			//	rim
			public static NPointF[] points = new NPointF[]
			{
				new NPointF(0, 0),
				new NPointF(a1, 0),
				new NPointF(a1, b1),
				new NPointF(a1, b1 + b2),
				new NPointF(a1, b1 + b2 + b3),
				new NPointF(a1 - a2, b1 + b2 + b3),
			};
		}

		#endregion

		#region Fields

		NTextStyle txMain;
		NTextStyle txLine;
		NTextStyle txLineSmall;

		NStrokeStyle sstOdd;
		NStrokeStyle sstEven;

		int minNormalLineLength;
		NPointL lineTextOffset;
		int defaultRoomMargin;

		int roomMargin;
		bool displayLengths;
		bool initializingControls;

		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private CheckBox showSizesCheckBox;
		private Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox singleRoomComboBox;
		private Label label2;
		private Nevron.UI.WinForm.Controls.NComboBox scaleComboBox;

		#endregion
	}
}