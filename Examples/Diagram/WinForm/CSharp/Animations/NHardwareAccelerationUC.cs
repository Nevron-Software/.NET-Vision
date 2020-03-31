using System;
using System.Drawing;
using System.Globalization;

using Nevron.Diagram;
using Nevron.GraphicsCore;
using Nevron.UI;
using System.Collections.Generic;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NHardwareAccelerationUC.
	/// </summary>
	public class NHardwareAccelerationUC : NDiagramExampleUC
	{
		#region Constructor

		public NHardwareAccelerationUC(NMainForm form)
			: base(form)
		{
			InitializeComponent();
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblFps = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.RenderTechnologyComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.ShapeCountComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// lblFps
			// 
			this.lblFps.Location = new System.Drawing.Point(5, 11);
			this.lblFps.Name = "lblFps";
			this.lblFps.Size = new System.Drawing.Size(235, 23);
			this.lblFps.TabIndex = 1;
			this.lblFps.Text = "FPS:";
			this.lblFps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 69);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Render Technology:";
			// 
			// RenderTechnologyComboBox
			// 
			this.RenderTechnologyComboBox.ListProperties.CheckBoxDataMember = "";
			this.RenderTechnologyComboBox.ListProperties.DataSource = null;
			this.RenderTechnologyComboBox.ListProperties.DisplayMember = "";
			this.RenderTechnologyComboBox.Location = new System.Drawing.Point(119, 61);
			this.RenderTechnologyComboBox.Name = "RenderTechnologyComboBox";
			this.RenderTechnologyComboBox.Size = new System.Drawing.Size(121, 21);
			this.RenderTechnologyComboBox.TabIndex = 3;
			this.RenderTechnologyComboBox.SelectedIndexChanged += new System.EventHandler(this.OnRenderTechnologyComboBoxSelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 105);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Shape Count:";
			// 
			// ShapeCountComboBox
			// 
			this.ShapeCountComboBox.ListProperties.CheckBoxDataMember = "";
			this.ShapeCountComboBox.ListProperties.DataSource = null;
			this.ShapeCountComboBox.ListProperties.DisplayMember = "";
			this.ShapeCountComboBox.Location = new System.Drawing.Point(119, 97);
			this.ShapeCountComboBox.Name = "ShapeCountComboBox";
			this.ShapeCountComboBox.Size = new System.Drawing.Size(121, 21);
			this.ShapeCountComboBox.TabIndex = 5;
			this.ShapeCountComboBox.SelectedIndexChanged += new System.EventHandler(this.OnShapeCountComboBoxSelectedIndexChanged);
			// 
			// NHardwareAccelerationUC
			// 
			this.Controls.Add(this.ShapeCountComboBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.RenderTechnologyComboBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblFps);
			this.Name = "NHardwareAccelerationUC";
			this.Size = new System.Drawing.Size(248, 384);
			this.Controls.SetChildIndex(this.lblFps, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.RenderTechnologyComboBox, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.ShapeCountComboBox, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void AttachToEvents()
		{
			base.AttachToEvents();

			m_PreviousTickTime = DateTime.Now;
			m_Timer = new NTimer();
			m_Timer.Interval = 10;
			m_Timer.Tick += new EventHandler(OnTimerTick);
			m_Timer.Start();
		}
		protected override void LoadExample()
		{
			base.DefaultGridOrigin = new NPointF(30, 30);
			base.DefaultGridCellSize = new NSizeF(100, 50);
			base.DefaultGridSpacing = new NSizeF(50, 40);

			m_Random = new Random();
			m_FrameSpansQueue = new Queue<TimeSpan>();

			// begin view init
			view.BeginInit();

			view.GlobalVisibility.ShowPorts = false;
			view.Grid.Visible = false;
			view.HorizontalRuler.Visible = false;
			view.VerticalRuler.Visible = false;
			view.ViewLayout = ViewLayout.Fit;
			view.DocumentPadding = new Nevron.Diagram.NMargins(10);
			view.DocumentShadow = new NShadowStyle(Color.Gray);
			view.DocumentShadow.Offset = new NPointL(3, 3);

			// init document
			document.BeginInit();
			InitDocument();

			this.RenderTechnologyComboBox.FillFromEnum(typeof(RenderTechnology));
			this.RenderTechnologyComboBox.SelectedIndex = (int)RenderTechnology.OpenGLHardware;

			this.ShapeCountComboBox.Items.Add("200");
			this.ShapeCountComboBox.Items.Add("500");
			this.ShapeCountComboBox.Items.Add("1000");
			this.ShapeCountComboBox.SelectedIndex = 0;

			document.EndInit();

			// end view init
			view.EndInit();
		}
		protected override void DetachFromEvents()
		{
			base.DetachFromEvents();

			m_Timer.Stop();
			m_Timer.Tick -= OnTimerTick;
		}

		#endregion

		#region Implementation

		private void InitDocument()
		{
			document.Style.StrokeStyle = new NStrokeStyle(0, Color.Empty);

			// Add some gradient fill style sheets
			NStyleSheet styleSheet = new NStyleSheet("Style1");
			NStyle.SetFillStyle(styleSheet, new NColorFillStyle(Color.Red));
			document.StyleSheets.AddChild(styleSheet);

			styleSheet = new NStyleSheet("Style2");
			NStyle.SetFillStyle(styleSheet, new NColorFillStyle(Color.Green));
			document.StyleSheets.AddChild(styleSheet);

			styleSheet = new NStyleSheet("Style3");
			NStyle.SetFillStyle(styleSheet, new NColorFillStyle(Color.Blue));
			document.StyleSheets.AddChild(styleSheet);
		}

		#endregion

		#region Event Handlers

		private void OnTimerTick(object sender, EventArgs e)
		{
			if (m_Shapes == null)
				return;

			// Record the duration between this tick and the previous one
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = now - m_PreviousTickTime;
			m_FrameSpansQueue.Enqueue(timeSpan);
			m_PreviousTickTime = now;

			// Make FPS statistics
			if (m_FrameSpansQueue.Count > 100)
			{
				m_FrameSpansQueue.Dequeue();

				TimeSpan totalSpan = new TimeSpan(0);
				Queue<TimeSpan>.Enumerator iter = m_FrameSpansQueue.GetEnumerator();
				while (iter.MoveNext())
				{
					totalSpan += iter.Current;
				}

				double fps = ((double)m_FrameSpansQueue.Count / (double)totalSpan.TotalSeconds);
				lblFps.Text = "FPS: " + fps.ToString("0.00");
			}

			// Move shapes
			int shapeCount = m_Shapes.Length;

			for (int i = 0; i < shapeCount; i++)
			{
				NShape shape = m_Shapes[i];

				// Generate new shape location
				float directionAngle = (float)shape.Tag;
				float x = shape.Location.X + (float)(Math.Sin(directionAngle) * 2);
				float y = shape.Location.Y + (float)(Math.Cos(directionAngle) * 2);

				// Clamp shape bounds to document area
				bool changeDirection = false;
				if (x < 0 || (x + shape.Width) > document.Width)
				{
					x = Clamp(0, document.Width - shape.Width, x);
					changeDirection = true;
				}

				if (y < 0 || (y + shape.Height) > document.Height)
				{
					y = Clamp(0, document.Height - shape.Height, y);
					changeDirection = true;
				}

				// Change movement direction, if shape hit document area bounds
				if (changeDirection)
				{
					shape.Tag = NMath.NormalizeRadians(directionAngle + m_Random.Next(80, 100) * NMath.Degree2Rad);
				}

				// Move the shape
				shape.Location = new NPointF(x, y);
			}

			document.SmartRefreshAllViews();
		}

		private void OnRenderTechnologyComboBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			this.view.RenderTechnology = (RenderTechnology)RenderTechnologyComboBox.SelectedIndex;
		}

		private void OnShapeCountComboBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			// Create the shapes
			int shapeCount = 0;
			document.ActiveLayer.RemoveAllChildren();

			switch (ShapeCountComboBox.SelectedIndex)
			{
				case 0:
					shapeCount = 200;
					break;
				case 1:
					shapeCount = 500;
					break;
				case 2:
					shapeCount = 1000;
					break;
			}

			m_Shapes = new NShape[shapeCount];
			int xMax = (int)document.Width - ShapeWidth;
			int yMax = (int)document.Height - ShapeHeight;

			for (int i = 0; i < shapeCount; i++)
			{
				// Create a rectangle shape
				NShape shape = new NRectangleShape(m_Random.Next(xMax), m_Random.Next(yMax), ShapeWidth, ShapeHeight);
				shape.StyleSheetName = "Style" + m_Random.Next(1, 4).ToString(CultureInfo.InvariantCulture);

				// Set its protections
				NAbilities protection = shape.Protection;
				protection.All = true;
				shape.Protection = protection;

				// Generate a random direction angle
				shape.Tag = m_Random.Next(90) * NMath.Degree2Rad;
				document.ActiveLayer.AddChild(shape);
				m_Shapes[i] = shape;
			}

		}

		#endregion

		#region Fields

		private NTimer m_Timer;
		private NShape[] m_Shapes;
		private Random m_Random;
		private DateTime m_PreviousTickTime;
		private Queue<TimeSpan> m_FrameSpansQueue;

		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox RenderTechnologyComboBox;
		private System.Windows.Forms.Label label2;
		private UI.WinForm.Controls.NComboBox ShapeCountComboBox;
		private System.Windows.Forms.Label lblFps;

		#endregion

		#region Static Methods

		/// <summary>
		/// Clamps the value to the [min;max] range.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		static public float Clamp(float min, float max, float value)
		{
			if (value < min)
				return min;

			if (value > max)
				return max;

			return value;
		}

		#endregion

		#region Constants

		private const int ShapeWidth = 50;
		private const int ShapeHeight = 50;

		#endregion

		

	}
}