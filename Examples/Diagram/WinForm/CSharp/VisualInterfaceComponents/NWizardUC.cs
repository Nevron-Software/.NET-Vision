using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.Templates;
using Nevron.Diagram.WinForm;
using Nevron.Diagram.WinForm.Commands;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NWizardUC.
	/// </summary>
	public class NWizardUC : NDiagramExampleUC
	{
		#region Constructors

		public NWizardUC(NMainForm form) : base(form)
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
			this.showWizardButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// showWizardButton
			// 
			this.showWizardButton.Location = new System.Drawing.Point(8, 8);
			this.showWizardButton.Name = "showWizardButton";
			this.showWizardButton.Size = new System.Drawing.Size(232, 32);
			this.showWizardButton.TabIndex = 0;
			this.showWizardButton.Text = "Show Wizard...";
			this.showWizardButton.Click += new System.EventHandler(this.showWizardButton_Click);
			// 
			// NWizardUC
			// 
			this.Controls.Add(this.showWizardButton);
			this.Name = "NWizardUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.showWizardButton, 0);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		/// <summary>
		/// 
		/// </summary>
		protected override void LoadExample()
		{
			
		}

		#endregion

		#region Event Handlers

		private void showWizardButton_Click(object sender, System.EventArgs e)
		{
			NWizard wizard = new NWizard(document);
			
			NTemplateCollection myTemplates = new NTemplateCollection("My Templates");
			myTemplates.Add(new NMyTemplate());

			wizard.AddCategory(myTemplates);

			wizard.ShowDialog();
		}

		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NButton showWizardButton;

		#endregion
	}

	/// <summary>
	/// Summary description for NMyTemplate
	/// </summary>
	public class NMyTemplate : NGraphTemplate
	{
		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		public NMyTemplate()
			: base("My Template")
		{
			m_nRimNodesCount = 6;
			m_fRadiusY = 100;
			m_fRadiusX = 100;
		}

		#endregion

		#region Interface implementations

		#region INMeasurements overrides

		/// <summary>
		/// Called when the measurement unit of the measurements stored in this template 
		/// have changed and all measurements must be converted to the new unit
		/// </summary>
		/// <remarks>
		/// Overriden to convert the X and Y radiuses
		/// </remarks>
		/// <param name="converter">measurement unit converter to use</param>
		/// <param name="from">from measurement unit</param>
		/// <param name="to">to measurement unit</param>
		public override void ConvertMeasurementUnit(NMeasurementUnitConverter converter, NMeasurementUnit from, NMeasurementUnit to)
		{
			base.ConvertMeasurementUnit(converter, from, to);
 
			m_fRadiusX = converter.ConvertX(from, to, m_fRadiusX);
			m_fRadiusY = converter.ConvertY(from, to, m_fRadiusY);
		}


		#endregion

		#endregion

		#region Properties

		/// <summary>
		/// Gets/sets the count of the nodes on the ellipse rim
		/// </summary>
		/// <remarks>
		/// By default set to 6
		/// </remarks>
		[Category("Grid"), 
		Description("Gets/sets the count of the nodes on the ellipse rim"),
		DefaultValue(6)]
		public int RimNodesCount
		{
			get
			{
				return m_nRimNodesCount;
			}
			set
			{
				if (value == m_nRimNodesCount)
					return;

				if (value < 3)
					throw new ArgumentOutOfRangeException("The value must be > 2.");

				m_nRimNodesCount = value;
				OnTemplateChanged();
			}
		}

		/// <summary>
		/// Controls the X radius of the ellipse
		/// </summary>		
		[Category("Ellipse"), 
		Description("Controls the X radius of the ellipse")]
		public float RadiusX
		{
			get
			{
				return m_fRadiusX;
			}
			set
			{
				if (value == m_fRadiusX)
					return;

				if (value <= 0)
					throw new ArgumentOutOfRangeException("The value must be > 0.");

				m_fRadiusX = value;
				OnTemplateChanged();
			}
		}

		/// <summary>
		/// Controls the Y radius of the ellipse
		/// </summary>		
		[Category("Ellipse"), 
		Description("Controls the Y radius of the ellipse")]
		public float RadiusY
		{
			get
			{
				return m_fRadiusY;
			}
			set
			{
				if (value == m_fRadiusY)
					return;

				if (value <= 0)
					throw new ArgumentOutOfRangeException("The value must be > 0.");

				m_fRadiusY = value;
				OnTemplateChanged();
			}
		}


		#endregion

 		#region Overrides

		/// <summary>
		/// Overriden to return the description
		/// </summary>
		public override string GetDescription()
		{
			string description = "Fully connected graph with " + m_nRimNodesCount.ToString() + " nodes on the rim.";
			return  description;
		}


		#endregion

		#region Protected overrides

		/// <summary>
		/// Overriden to create the fully connected graph template
		/// </summary>
		/// <param name="document">document in which to create the template</param>
		protected override void CreateTemplate(NDrawingDocument document)
		{
			int i;
			NShape vertex;
			NShape edge;
			NPointF pt;
			ArrayList vertices = new ArrayList();
			NLayer layer = document.ActiveLayer;

			// create the ellipse vertices
			float curAngle = 0, stepAngle = ((float)Math.PI * 2) / m_nRimNodesCount;
			PointF center = new PointF(	Origin.X + m_fRadiusX + VerticesSize.Width / 2, 
										Origin.Y + m_fRadiusY + VerticesSize.Height / 2);

			for (i = 0; i < m_nRimNodesCount; i++)
			{
				pt = new NPointF(	center.X + m_fRadiusX * (float)Math.Cos(curAngle) - VerticesSize.Width / 2,
									center.Y + m_fRadiusY * (float)Math.Sin(curAngle) - VerticesSize.Height / 2);

				vertex = CreateVertex(VerticesShape);
				vertex.Bounds = new NRectangleF(pt, VerticesSize);
				layer.AddChild(vertex);

				vertices.Add(vertex);
				curAngle += stepAngle;
			}

			// connect them
			for (i = 0; i < vertices.Count; i++)
			{
				for (int j = i + 1; j < vertices.Count; j++)
				{
					edge = CreateEdge(ConnectorType.DynamicPolyline);
					layer.AddChild(edge);

					edge.FromShape = (NShape)vertices[i];
					edge.ToShape = (NShape)vertices[j];
				}
			}
		}


		#endregion

		#region Fields

		internal int m_nRimNodesCount;
		internal float m_fRadiusY;
		internal float m_fRadiusX;

		#endregion
	}
}
