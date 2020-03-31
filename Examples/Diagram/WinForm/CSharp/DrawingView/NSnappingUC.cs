using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Editors; 
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NSnappingUC.
	/// </summary>
	public class NSnappingUC : NDiagramExampleUC
	{
		#region Constructor

		public NSnappingUC(NMainForm form) : base(form)
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
            this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.snapStrengthButton = new Nevron.UI.WinForm.Controls.NButton();
            this.snapToButton = new Nevron.UI.WinForm.Controls.NButton();
            this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.snapRotatorsToButton = new Nevron.UI.WinForm.Controls.NButton();
            this.snapPinPointsToButton = new Nevron.UI.WinForm.Controls.NButton();
            this.snapShapePortsToButton = new Nevron.UI.WinForm.Controls.NButton();
            this.snapShapePlugsToButton = new Nevron.UI.WinForm.Controls.NButton();
            this.snapShapeControlPointsToButton = new Nevron.UI.WinForm.Controls.NButton();
            this.snapGeometryMidPointsToButton = new Nevron.UI.WinForm.Controls.NButton();
            this.snapGeometryControlPointsToButton = new Nevron.UI.WinForm.Controls.NButton();
            this.snapGeometryBasePointsToButton = new Nevron.UI.WinForm.Controls.NButton();
            this.nGroupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rotationStepTextBox = new System.Windows.Forms.TextBox();
            this.rotationDeviationTextBox = new System.Windows.Forms.TextBox();
            this.snapRotationCheck = new System.Windows.Forms.CheckBox();
            this.nGroupBox1.SuspendLayout();
            this.nGroupBox2.SuspendLayout();
            this.nGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // nGroupBox1
            // 
            this.nGroupBox1.Controls.Add(this.snapStrengthButton);
            this.nGroupBox1.Controls.Add(this.snapToButton);
            this.nGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.nGroupBox1.ImageIndex = 0;
            this.nGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.nGroupBox1.Name = "nGroupBox1";
            this.nGroupBox1.Size = new System.Drawing.Size(250, 88);
            this.nGroupBox1.TabIndex = 0;
            this.nGroupBox1.TabStop = false;
            this.nGroupBox1.Text = "General";
            // 
            // snapStrengthButton
            // 
            this.snapStrengthButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.snapStrengthButton.Location = new System.Drawing.Point(16, 56);
            this.snapStrengthButton.Name = "snapStrengthButton";
            this.snapStrengthButton.Size = new System.Drawing.Size(216, 23);
            this.snapStrengthButton.TabIndex = 1;
            this.snapStrengthButton.Text = "Snap strength...";
            this.snapStrengthButton.Click += new System.EventHandler(this.snapStrengthButton_Click);
            // 
            // snapToButton
            // 
            this.snapToButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.snapToButton.Location = new System.Drawing.Point(16, 24);
            this.snapToButton.Name = "snapToButton";
            this.snapToButton.Size = new System.Drawing.Size(216, 23);
            this.snapToButton.TabIndex = 0;
            this.snapToButton.Text = "Snap to...";
            this.snapToButton.Click += new System.EventHandler(this.snapToButton_Click);
            // 
            // nGroupBox2
            // 
            this.nGroupBox2.Controls.Add(this.snapRotatorsToButton);
            this.nGroupBox2.Controls.Add(this.snapPinPointsToButton);
            this.nGroupBox2.Controls.Add(this.snapShapePortsToButton);
            this.nGroupBox2.Controls.Add(this.snapShapePlugsToButton);
            this.nGroupBox2.Controls.Add(this.snapShapeControlPointsToButton);
            this.nGroupBox2.Controls.Add(this.snapGeometryMidPointsToButton);
            this.nGroupBox2.Controls.Add(this.snapGeometryControlPointsToButton);
            this.nGroupBox2.Controls.Add(this.snapGeometryBasePointsToButton);
            this.nGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.nGroupBox2.ImageIndex = 0;
            this.nGroupBox2.Location = new System.Drawing.Point(0, 88);
            this.nGroupBox2.Name = "nGroupBox2";
            this.nGroupBox2.Size = new System.Drawing.Size(250, 282);
            this.nGroupBox2.TabIndex = 1;
            this.nGroupBox2.TabStop = false;
            this.nGroupBox2.Text = "Points snapping";
            // 
            // snapRotatorsToButton
            // 
            this.snapRotatorsToButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.snapRotatorsToButton.Location = new System.Drawing.Point(16, 245);
            this.snapRotatorsToButton.Name = "snapRotatorsToButton";
            this.snapRotatorsToButton.Size = new System.Drawing.Size(216, 23);
            this.snapRotatorsToButton.TabIndex = 8;
            this.snapRotatorsToButton.Text = "Snap rotators to...";
            this.snapRotatorsToButton.Click += new System.EventHandler(this.snapRotatorsToButton_Click);
            // 
            // snapPinPointsToButton
            // 
            this.snapPinPointsToButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.snapPinPointsToButton.Location = new System.Drawing.Point(15, 213);
            this.snapPinPointsToButton.Name = "snapPinPointsToButton";
            this.snapPinPointsToButton.Size = new System.Drawing.Size(216, 23);
            this.snapPinPointsToButton.TabIndex = 7;
            this.snapPinPointsToButton.Text = "Snap pins to...";
            this.snapPinPointsToButton.Click += new System.EventHandler(this.snapPinPointsToButton_Click);
            // 
            // snapShapePortsToButton
            // 
            this.snapShapePortsToButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.snapShapePortsToButton.Location = new System.Drawing.Point(15, 149);
            this.snapShapePortsToButton.Name = "snapShapePortsToButton";
            this.snapShapePortsToButton.Size = new System.Drawing.Size(216, 23);
            this.snapShapePortsToButton.TabIndex = 5;
            this.snapShapePortsToButton.Text = "Snap ports to...";
            this.snapShapePortsToButton.Click += new System.EventHandler(this.snapShapePortsToButton_Click);
            // 
            // snapShapePlugsToButton
            // 
            this.snapShapePlugsToButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.snapShapePlugsToButton.Location = new System.Drawing.Point(15, 181);
            this.snapShapePlugsToButton.Name = "snapShapePlugsToButton";
            this.snapShapePlugsToButton.Size = new System.Drawing.Size(216, 23);
            this.snapShapePlugsToButton.TabIndex = 6;
            this.snapShapePlugsToButton.Text = "Snap plugs to...";
            this.snapShapePlugsToButton.Click += new System.EventHandler(this.snapShapePlugsToButton_Click);
            // 
            // snapShapeControlPointsToButton
            // 
            this.snapShapeControlPointsToButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.snapShapeControlPointsToButton.Location = new System.Drawing.Point(15, 117);
            this.snapShapeControlPointsToButton.Name = "snapShapeControlPointsToButton";
            this.snapShapeControlPointsToButton.Size = new System.Drawing.Size(216, 23);
            this.snapShapeControlPointsToButton.TabIndex = 4;
            this.snapShapeControlPointsToButton.Text = "Snap start end points to...";
            this.snapShapeControlPointsToButton.Click += new System.EventHandler(this.snapShapeControlPointsToButton_Click);
            // 
            // snapGeometryMidPointsToButton
            // 
            this.snapGeometryMidPointsToButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.snapGeometryMidPointsToButton.Location = new System.Drawing.Point(16, 85);
            this.snapGeometryMidPointsToButton.Name = "snapGeometryMidPointsToButton";
            this.snapGeometryMidPointsToButton.Size = new System.Drawing.Size(216, 23);
            this.snapGeometryMidPointsToButton.TabIndex = 3;
            this.snapGeometryMidPointsToButton.Text = "Snap mid points to...";
            this.snapGeometryMidPointsToButton.Click += new System.EventHandler(this.snapGeometryMidPointsToButton_Click);
            // 
            // snapGeometryControlPointsToButton
            // 
            this.snapGeometryControlPointsToButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.snapGeometryControlPointsToButton.Location = new System.Drawing.Point(16, 53);
            this.snapGeometryControlPointsToButton.Name = "snapGeometryControlPointsToButton";
            this.snapGeometryControlPointsToButton.Size = new System.Drawing.Size(216, 23);
            this.snapGeometryControlPointsToButton.TabIndex = 2;
            this.snapGeometryControlPointsToButton.Text = "Snap control points to...";
            this.snapGeometryControlPointsToButton.Click += new System.EventHandler(this.snapGeometryControlPointsToButton_Click);
            // 
            // snapGeometryBasePointsToButton
            // 
            this.snapGeometryBasePointsToButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.snapGeometryBasePointsToButton.Location = new System.Drawing.Point(15, 21);
            this.snapGeometryBasePointsToButton.Name = "snapGeometryBasePointsToButton";
            this.snapGeometryBasePointsToButton.Size = new System.Drawing.Size(216, 23);
            this.snapGeometryBasePointsToButton.TabIndex = 1;
            this.snapGeometryBasePointsToButton.Text = "Snap base points to...";
            this.snapGeometryBasePointsToButton.Click += new System.EventHandler(this.snapGeometryBasePointsToButton_Click);
            // 
            // nGroupBox3
            // 
            this.nGroupBox3.Controls.Add(this.label2);
            this.nGroupBox3.Controls.Add(this.label1);
            this.nGroupBox3.Controls.Add(this.rotationStepTextBox);
            this.nGroupBox3.Controls.Add(this.rotationDeviationTextBox);
            this.nGroupBox3.Controls.Add(this.snapRotationCheck);
            this.nGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.nGroupBox3.ImageIndex = 0;
            this.nGroupBox3.Location = new System.Drawing.Point(0, 370);
            this.nGroupBox3.Name = "nGroupBox3";
            this.nGroupBox3.Size = new System.Drawing.Size(250, 112);
            this.nGroupBox3.TabIndex = 2;
            this.nGroupBox3.TabStop = false;
            this.nGroupBox3.Text = "Rotation snapping";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rotation step:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rotation deviation:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rotationStepTextBox
            // 
            this.rotationStepTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rotationStepTextBox.Location = new System.Drawing.Point(128, 80);
            this.rotationStepTextBox.Name = "rotationStepTextBox";
            this.rotationStepTextBox.Size = new System.Drawing.Size(100, 20);
            this.rotationStepTextBox.TabIndex = 4;
            this.rotationStepTextBox.Text = "textBox2";
            this.rotationStepTextBox.TextChanged += new System.EventHandler(this.rotationStepTextBox_TextChanged);
            // 
            // rotationDeviationTextBox
            // 
            this.rotationDeviationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rotationDeviationTextBox.Location = new System.Drawing.Point(128, 48);
            this.rotationDeviationTextBox.Name = "rotationDeviationTextBox";
            this.rotationDeviationTextBox.Size = new System.Drawing.Size(100, 20);
            this.rotationDeviationTextBox.TabIndex = 2;
            this.rotationDeviationTextBox.Text = "textBox1";
            this.rotationDeviationTextBox.TextChanged += new System.EventHandler(this.rotationDeviationTextBox_TextChanged);
            // 
            // snapRotationCheck
            // 
            this.snapRotationCheck.Location = new System.Drawing.Point(16, 16);
            this.snapRotationCheck.Name = "snapRotationCheck";
            this.snapRotationCheck.Size = new System.Drawing.Size(104, 24);
            this.snapRotationCheck.TabIndex = 0;
            this.snapRotationCheck.Text = "Snap rotation";
            this.snapRotationCheck.CheckedChanged += new System.EventHandler(this.snapRotationCheck_CheckedChanged);
            // 
            // NSnappingUC
            // 
            this.Controls.Add(this.nGroupBox3);
            this.Controls.Add(this.nGroupBox2);
            this.Controls.Add(this.nGroupBox1);
            this.Name = "NSnappingUC";
            this.Size = new System.Drawing.Size(250, 571);
            this.Controls.SetChildIndex(this.nGroupBox1, 0);
            this.Controls.SetChildIndex(this.nGroupBox2, 0);
            this.Controls.SetChildIndex(this.nGroupBox3, 0);
            this.nGroupBox1.ResumeLayout(false);
            this.nGroupBox2.ResumeLayout(false);
            this.nGroupBox3.ResumeLayout(false);
            this.nGroupBox3.PerformLayout();
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

			// init form controls
			InitFormControls();

			// end view init
			view.EndInit();
		}

		protected override void ResetExample()
		{
			view.Reset();
			base.ResetExample();
		}

		
		#endregion

		#region Implementation

		private void InitFormControls()
		{
			PauseEventsHandling();

			snapRotationCheck.Checked = view.SnapManager.SnapRotation;
			rotationStepTextBox.Text = view.SnapManager.RotationStep.ToString();
			rotationDeviationTextBox.Text = view.SnapManager.RotationDeviation.ToString();

			ResumeEventsHandling();
		}
		
		private void InitDocument()
		{
			document.ActiveLayer.AddChild(new NRectangleShape(10, 10, 50, 50));
			document.ActiveLayer.AddChild(new NRectangleShape(100, 100, 50, 50));
			document.ActiveLayer.AddChild(new NRectangleShape(100, 10, 50, 50));
			document.ActiveLayer.AddChild(new NRectangleShape(10, 100, 50, 50));
		}

		
		#endregion

		#region Event Handlers

		private void snapToButton_Click(object sender, System.EventArgs e)
		{
			NSnapTargets targets;
			if (NSnapTargetsTypeEditor.Edit(view.SnapManager.SnapTo, out targets))
            {
				view.SnapManager.SnapTo = targets;
			}
		}
		private void snapStrengthButton_Click(object sender, System.EventArgs e)
		{
			NSnapStrength strength;
			if (NSnapStrengthTypeEditor.Edit(view.SnapManager.SnapStrength, out strength))
			{
				view.SnapManager.SnapStrength = strength;
			}
		}
		
		private void snapGeometryBasePointsToButton_Click(object sender, System.EventArgs e)
		{
			NSnapTargets targets;
			if (NSnapTargetsTypeEditor.Edit(view.SnapManager.SnapGeometryBasePointsTo, out targets))
			{
				view.SnapManager.SnapGeometryBasePointsTo = targets;
			}
		}
		private void snapGeometryMidPointsToButton_Click(object sender, System.EventArgs e)
		{
			NSnapTargets targets;
			if (NSnapTargetsTypeEditor.Edit(view.SnapManager.SnapGeometryMidPointsTo, out targets))
			{
				view.SnapManager.SnapGeometryMidPointsTo = targets;
			}		
		}
		private void snapGeometryControlPointsToButton_Click(object sender, System.EventArgs e)
		{
			NSnapTargets targets;
			if (NSnapTargetsTypeEditor.Edit(view.SnapManager.SnapGeometryControlPointsTo, out targets))
			{
				view.SnapManager.SnapGeometryControlPointsTo = targets;
			}		
		}
		private void snapShapeControlPointsToButton_Click(object sender, System.EventArgs e)
		{
			NSnapTargets targets;
			if (NSnapTargetsTypeEditor.Edit(view.SnapManager.SnapShapeControlPointsTo, out targets))
			{
				view.SnapManager.SnapShapeControlPointsTo = targets;
			}		
		}
		private void snapShapePortsToButton_Click(object sender, System.EventArgs e)
		{
			NSnapTargets targets;
			if (NSnapTargetsTypeEditor.Edit(view.SnapManager.SnapShapePortsTo, out targets))
			{
				view.SnapManager.SnapShapePortsTo = targets;
			}		
		}
		private void snapShapePlugsToButton_Click(object sender, System.EventArgs e)
		{
			NSnapTargets targets;
			if (NSnapTargetsTypeEditor.Edit(view.SnapManager.SnapShapePlugsTo, out targets))
			{
				view.SnapManager.SnapShapePlugsTo = targets;
			}		
		}
		private void snapPinPointsToButton_Click(object sender, System.EventArgs e)
		{
			NSnapTargets targets;
			if (NSnapTargetsTypeEditor.Edit(view.SnapManager.SnapPinPointsTo, out targets))
			{
				view.SnapManager.SnapPinPointsTo = targets;
			}				
		}
		private void snapRotatorsToButton_Click(object sender, System.EventArgs e)
		{
			NSnapTargets targets;
			if (NSnapTargetsTypeEditor.Edit(view.SnapManager.SnapRotatorsTo, out targets))
			{
				view.SnapManager.SnapRotatorsTo = targets;
			}						
		}
		private void snapRotationCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			view.SnapManager.SnapRotation = snapRotationCheck.Checked;
		}
		private void rotationDeviationTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			float deviation = 0;
			try
			{
				deviation = Single.Parse(rotationDeviationTextBox.Text);
			}
			catch 
			{
				return;
			}
		
			view.SnapManager.RotationDeviation = deviation;
		}
		private void rotationStepTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			float step = 0;
			try
			{
				step = Single.Parse(rotationStepTextBox.Text);
			}
			catch 
			{
				return;
			}
		
			view.SnapManager.RotationStep = step;		
		}	

		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NButton snapToButton;
		private Nevron.UI.WinForm.Controls.NButton snapStrengthButton;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
        private Nevron.UI.WinForm.Controls.NButton snapGeometryBasePointsToButton;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox3;
		private Nevron.UI.WinForm.Controls.NButton snapGeometryControlPointsToButton;
		private Nevron.UI.WinForm.Controls.NButton snapGeometryMidPointsToButton;
		private Nevron.UI.WinForm.Controls.NButton snapShapeControlPointsToButton;
		private Nevron.UI.WinForm.Controls.NButton snapShapePlugsToButton;
		private Nevron.UI.WinForm.Controls.NButton snapShapePortsToButton;
		private Nevron.UI.WinForm.Controls.NButton snapPinPointsToButton;
		private Nevron.UI.WinForm.Controls.NButton snapRotatorsToButton;
		private System.Windows.Forms.CheckBox snapRotationCheck;
		private System.Windows.Forms.TextBox rotationDeviationTextBox;
		private System.Windows.Forms.TextBox rotationStepTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;

		#endregion

	}
}