using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.GraphicsCore;
using Nevron.Diagram.WinForm;
using Nevron.Diagram.WinForm.Commands;
using Nevron.UI.WinForm.Controls;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NControllerUC.
	/// </summary>
	public class NControllerUC : NDiagramExampleUC
	{
		#region Constructor

		public NControllerUC(NMainForm form) : base(form)
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
			this.activeToolCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// activeToolCombo
			// 
			this.activeToolCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.activeToolCombo.Location = new System.Drawing.Point(8, 32);
			this.activeToolCombo.Name = "activeToolCombo";
			this.activeToolCombo.Size = new System.Drawing.Size(234, 21);
			this.activeToolCombo.TabIndex = 0;
			this.activeToolCombo.Text = "Click here to select a tool";
			this.activeToolCombo.SelectedIndexChanged += new System.EventHandler(this.activeToolCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Enabled tool:";
			// 
			// NControllerUC
			// 
			this.Controls.Add(this.label1);
			this.Controls.Add(this.activeToolCombo);
			this.Name = "NControllerUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.activeToolCombo, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

			// init document
			document.BeginInit();
			CreateDefaultFlowDiagram();
			document.EndInit();

			// add the custom tool to the controller
			view.Controller.Tools.Add(new NCustomTool());

			// init the controls
			InitFormControls();
			
			// end view init
			view.EndInit();
		}

		protected override void ResetExample()
		{
			base.ResetExample();
			view.Zoom(1, new NPointF(0, 0), true);
		}


		#endregion

		#region Implementation

		private void InitFormControls()
		{
			PauseEventsHandling();

			// init the active tool combo
			activeToolCombo.Items.Clear();
			
			NListBoxItem item;

			item = new NListBoxItem(0, "Pointer Tool", false);
			activeToolCombo.Items.Add(item);

			item = new NListBoxItem(2, "Create Ellipse", false);
			activeToolCombo.Items.Add(item);

			item = new NListBoxItem(16, "Pan Tool", false);
			activeToolCombo.Items.Add(item);

			item = new NListBoxItem(-1, "Custom Tool", false);
			activeToolCombo.Items.Add(item);

			// init the toolIndexToNamesMap 
			toolIndexToNamesMap.Clear();
			toolIndexToNamesMap[0] = new string[] {	NDWFR.ToolCreateGuideline,
													NDWFR.ToolHandle,
													NDWFR.ToolMove,
													NDWFR.ToolSelector,
													NDWFR.ToolContextMenu,
													NDWFR.ToolKeyboard,
													NDWFR.ToolInplaceEdit };


			
			toolIndexToNamesMap[1] = new string[] { NDWFR.ToolCreateEllipse };
			toolIndexToNamesMap[2] = new string[] { NDWFR.ToolPan };
			toolIndexToNamesMap[3] = new string[] { "Custom Tool"};


			// by default select the pointer tool
			activeToolCombo.SelectedIndex = 0;

			ResumeEventsHandling();
		}

		#endregion

		#region Event Handlers

		private void activeToolCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			string[] toolNames = (toolIndexToNamesMap[activeToolCombo.SelectedIndex] as string[]);
			if (toolNames == null)
				return;

			view.Controller.Tools.SingleEnableTools(toolNames);
		}


		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NComboBox activeToolCombo;
		private System.Windows.Forms.Label label1;

		#endregion
	
		#region Fields

		private Hashtable toolIndexToNamesMap = new Hashtable();

		#endregion
	}

	/// <summary>
	/// Demonstrates creating custom tool by deriving from NDrawingDragTool.
	/// </summary>
	public class NCustomTool : NDrawingDragTool
	{
		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		public NCustomTool()
			: base("Custom Tool")
		{
		}


		#endregion

		#region INMouseEventProcessor Overrides

		/// <summary>
		/// Processes the mouse move event
		/// </summary>
		/// <remarks>
		/// Overriden to update the zoom rect if the tool is active
		/// </remarks>
		/// <param name="e">mouse event arguments</param>
		public override bool ProcessMouseMove(MouseEventArgs e)
		{
			base.ProcessMouseMove(e);

			if (IsActive == false)
				return false;

			UpdateZoomRect();
			return true;
		}

		/// <summary>
		/// Processes the mouse double click event
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public override bool ProcessDoubleClick(EventArgs e)
		{
			base.ProcessDoubleClick(e);

			View.Zoom(1, Controller.MouseInfo.ScenePoint, true);
			return true;
		}


		#endregion

		#region INStatusBarInfo Overrides

		/// <summary>
		/// Updates the specified status bar info
		/// </summary>
		/// <remarks>
		/// Overriden to populate the secondary info with the zoom rect bounds if it is valid 
		/// and the secondary info is not yet populated.
		/// </remarks>
		/// <param name="info">status bar info</param>
		public override void UpdateStatusBarInfo(NStatusBarInfo info)
		{
			base.UpdateStatusBarInfo(info);

			// update secondary info with zoom rect
			if (info.Secondary == "" && m_ZoomRect != null)
			{
				StringBuilder sb = new StringBuilder(100);
				sb.Append("Zoom factor: ");
				sb.Append(ComputeZoomFactor());
				sb.Append(". ");

				NMeasurementUnit mu = Document.MeasurementUnit;
				string format = mu.DefaultValueFormat;
				NRectangleF bounds = m_ZoomRect.Bounds;

				sb.Append("Zoom rect: {");
				sb.Append(bounds.X.ToString(format));
				sb.Append(", ");
				sb.Append(bounds.Y.ToString(format));
				sb.Append(", ");
				sb.Append(bounds.Width.ToString(format));
				sb.Append(", ");
				sb.Append(bounds.Height.ToString(format));
				sb.Append("}");

				info.Secondary = sb.ToString();
			}
		}
        

		#endregion
		
		#region Implementation

		protected float ComputeZoomFactor()
		{
			NRectangleF zoomRect = m_ZoomRect.Bounds;
			float xScale = View.ScaleX * View.ViewportSize.Width / zoomRect.Width;
			float yScale = View.ScaleY * View.ViewportSize.Height / zoomRect.Height;
			return Math.Min(xScale, yScale);
		}
		
		
		#endregion

		#region Overrides

		/// <summary>
		/// Activates the tool
		/// </summary>
		/// <remarks>
		/// Overriden to create the zoom rect
		/// </remarks>
		public override void Activate()
		{
			base.Activate();

			CreateZoomRect();
		}

		/// <summary>
		/// Deactivates the tool
		/// </summary>
		/// <remarks>
		/// Overriden to perform zoom and destroy the zoom rect
		/// </remarks>
		public override void Deactivate()
		{
			ZoomToRect();
			DestroyZoomRect();

			base.Deactivate();
		}

		/// <summary>
		/// Aborts the tool if it is active
		/// </summary>
		/// <remarks>
		/// Overriden to destroy the zoom rect
		/// </remarks>
		public override void Abort()
		{
			DestroyZoomRect();

			base.Abort();
		}

		/// <summary>
		/// Overriden to return true
		/// </summary>
		public override bool NeedsSecondMouseButtonPass
		{
			get
			{
				return true;
			}
		}


		#endregion

		#region Protected overridables

		/// <summary>
		/// Zooms the view to the dragged zoom rect
		/// </summary>
		protected virtual void ZoomToRect()
		{
			NRectangleF zoomRect = m_ZoomRect.Bounds;
			if (zoomRect.Width != 0 || zoomRect.Height != 0)
			{
				float scaleFactor = ComputeZoomFactor();
				if (View.IsValidScaleFactor(scaleFactor))
				{
					NPointF viewportCenter = new NPointF(zoomRect.X + zoomRect.Width / 2, zoomRect.Y + zoomRect.Height / 2);
					View.Zoom(scaleFactor, viewportCenter, true);
				}
			}
		}

		/// <summary>
		/// Creates the zoom rect
		/// </summary>
		/// <remarks>
		/// This implementation will currently create a zoom rectangle and add it to the preview layer
		/// </remarks>
		protected virtual void CreateZoomRect()
		{
			// create the zoom rect 
			m_ZoomRect = new NRectanglePath();
			NStyle.SetFillStyle(m_ZoomRect, new NColorFillStyle(Color.FromArgb(0, 0, 0, 0)));
			NStyle.SetStrokeStyle(m_ZoomRect, new NStrokeStyle(1, Color.Black, LinePattern.Dash));
			View.PreviewLayer.AddChild(m_ZoomRect);

			// start dragging
			View.OnDraggingStarted();
		}

		/// <summary>
		/// Destroys the zoom region
		/// </summary>
		/// <remarks>
		/// This implementation will destory the zoom rectangle
		/// </remarks>
		protected virtual void DestroyZoomRect()
		{
			// destroy zoom rect
			View.PreviewLayer.RemoveChild(m_ZoomRect);
			m_ZoomRect = null;

			// stop dragging
			View.OnDraggingEnded();
		}

		/// <summary>
		/// Updates the zoom region
		/// </summary>
		/// <remarks>
		/// This implementation will update the zoom rectangle with the current and start mouse hit infos 
		/// and higight the nodes hit by it
		/// </remarks>
		protected virtual void UpdateZoomRect()
		{
			try
			{
				// update zoom rect
				m_ZoomRect.DefineModel(StartMouseInfo.ScenePoint, Controller.MouseInfo.ScenePoint);
				
				// inform the view to update the ruler highlights
				View.OnDragging(m_ZoomRect.Bounds);
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Failed to update zoom rect. Exception was: " + ex.Message);
			}
		}


		#endregion

		#region Fields

		// region select
		internal NRectanglePath m_ZoomRect;

		#endregion
	}
}