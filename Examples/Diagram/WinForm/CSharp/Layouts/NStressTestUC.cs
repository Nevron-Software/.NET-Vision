using System;
using System.Globalization;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Templates;
using Nevron.Dom;

namespace Nevron.Examples.Diagram.WinForm
{
    /// <summary>
    /// Summary description for NStressTestUC.
    /// </summary>
    public class NStressTestUC : NDiagramExampleUC
    {
        #region Constructor

        public NStressTestUC(NMainForm form)
            : base(form)
		{
			InitializeComponent();
		}

		#endregion

        #region Component Designer Generated Code

        private void InitializeComponent()
        {
            this.btnRandom2 = new Nevron.UI.WinForm.Controls.NButton();
            this.btnRandom1 = new Nevron.UI.WinForm.Controls.NButton();
            this.cbLayout = new Nevron.UI.WinForm.Controls.NComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLayout = new Nevron.UI.WinForm.Controls.NButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRandom2
            // 
            this.btnRandom2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRandom2.Location = new System.Drawing.Point(8, 48);
            this.btnRandom2.Name = "btnRandom2";
            this.btnRandom2.Size = new System.Drawing.Size(244, 23);
            this.btnRandom2.TabIndex = 8;
            this.btnRandom2.Text = "Random Graph (2400 vertices, 2600 edges)";
            this.btnRandom2.UseVisualStyleBackColor = true;
            this.btnRandom2.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnRandom1
            // 
            this.btnRandom1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRandom1.Location = new System.Drawing.Point(8, 19);
            this.btnRandom1.Name = "btnRandom1";
            this.btnRandom1.Size = new System.Drawing.Size(244, 23);
            this.btnRandom1.TabIndex = 7;
            this.btnRandom1.Text = "Random Graph (900 vertices, 1100 edges)";
            this.btnRandom1.UseVisualStyleBackColor = true;
            this.btnRandom1.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // cbLayout
            // 
            this.cbLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLayout.Location = new System.Drawing.Point(8, 98);
            this.cbLayout.Name = "cbLayout";
            this.cbLayout.Size = new System.Drawing.Size(244, 21);
            this.cbLayout.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.txtResults);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(8, 182);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 171);
            this.panel1.TabIndex = 10;
            // 
            // txtResults
            // 
            this.txtResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResults.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtResults.Location = new System.Drawing.Point(0, 23);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.Size = new System.Drawing.Size(244, 148);
            this.txtResults.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Results";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLayout
            // 
            this.btnLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLayout.Location = new System.Drawing.Point(8, 125);
            this.btnLayout.Name = "btnLayout";
            this.btnLayout.Size = new System.Drawing.Size(244, 23);
            this.btnLayout.TabIndex = 11;
            this.btnLayout.Text = "Layout";
            this.btnLayout.UseVisualStyleBackColor = true;
            this.btnLayout.Click += new System.EventHandler(this.btnLayout_Click);
            // 
            // NStressTestUC
            // 
            this.Controls.Add(this.btnLayout);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbLayout);
            this.Controls.Add(this.btnRandom2);
            this.Controls.Add(this.btnRandom1);
            this.Name = "NStressTestUC";
            this.Controls.SetChildIndex(this.btnRandom1, 0);
            this.Controls.SetChildIndex(this.btnRandom2, 0);
            this.Controls.SetChildIndex(this.cbLayout, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnLayout, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #region NDiagramExampleUC Overrides

        protected override void LoadExample()
        {
            // init form fields
            InitFormControls();
            view.BeginInit();
            view.Grid.Visible = false;
			view.GlobalVisibility.HideAll();
            view.ViewLayout = ViewLayout.Fit;

            // init document
            document.BeginInit();
            InitDocument();
            document.EndInit();

            // end view init
            view.EndInit();
        }

        #endregion

        #region Implementation

        private void InitFormControls()
        {
            PauseEventsHandling();

            // Create the layouts
            NLayeredGraphLayout layered = new NLayeredGraphLayout();
            layered.LayerSpacing = 100;

            NSingleCycleLayout singleCycle = new NSingleCycleLayout();
            singleCycle.RingRadius = 1000;

            NSymmetricalLayout symmetrical = new NSymmetricalLayout();

            cbLayout.Items.AddRange(new NLayout[]
            {
                layered,
                singleCycle,
                symmetrical
            });

            cbLayout.SelectedIndex = 0;

            ResumeEventsHandling();
        }
        private void InitDocument()
        {
			document.BridgeManager.Enabled = false;
			document.RoutingManager.Enabled = false;
        }
        private string LayoutShapes()
        {
			string result = String.Empty;

			try
			{
				this.Cursor = Cursors.WaitCursor;
				document.BeginInit();

				NNodeList nodes = document.ActiveLayer.Children(NFilters.Shape2D);
				NLayoutContext layoutContext = new NDrawingLayoutContext(document);
				NLayout layout = (NLayout)cbLayout.SelectedItem;
				layout.Layout(nodes, layoutContext);
				document.SizeToContent();

				document.EndInit();
				result = layout.PerformanceInfo;
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}

			return result;
        }
        private int GetNumber(string str, int index)
        {
			string digits = string.Empty;
            for (int i = index, length = str.Length; i < length; i++)
            {
				if (Char.IsDigit(str[i]) == false)
				{
					if (digits.Length > 0)
						break;
				}
				else
				{
					digits = digits + str[i];
				}
            }

			if (String.IsNullOrEmpty(digits))
				return 0;

            return Int32.Parse(digits, CultureInfo.InvariantCulture);
        }

        #endregion

        #region Event Handlers

        private void btnRandom_Click(object sender, EventArgs e)
        {
			try
			{
				this.Cursor = Cursors.WaitCursor;
				DateTime start = DateTime.Now;

				view.BeginInit();

				string text = ((Control)sender).Text;
				int vertexCount = GetNumber(text, text.IndexOf('('));
				int edgeCount = GetNumber(text, text.IndexOf(','));

				NRandomGraphTemplate randomGraph = new NRandomGraphTemplate();
				randomGraph.EdgesStyleSheetName = "CustomConnectors";
				randomGraph.VertexCount = vertexCount;
				randomGraph.EdgeCount = edgeCount;

				document.Reset();
				document.BeginInit();

				document.ActiveLayer.AutoGenerateUniqueNames = false;
				randomGraph.Create(document);
				document.SizeToContent();

				document.EndInit();

				TimeSpan time = DateTime.Now - start;
				txtResults.Text = String.Format("Graph generated in {0:F3} ms.\n", time.TotalMilliseconds);
			}
			finally
			{
				this.Cursor = Cursors.Default;
				view.EndInit();
			}
        }
        private void btnLayout_Click(object sender, EventArgs e)
        {
			view.BeginInit();
            txtResults.Text = LayoutShapes();
			view.EndInit();
        }

        #endregion

        #region Designer Fields

        private Nevron.UI.WinForm.Controls.NButton btnRandom2;
        private Nevron.UI.WinForm.Controls.NButton btnRandom1;
        private Panel panel1;
        private Label label1;
        private Nevron.UI.WinForm.Controls.NButton btnLayout;
        private TextBox txtResults;
        private Nevron.UI.WinForm.Controls.NComboBox cbLayout;

        #endregion
    }
}