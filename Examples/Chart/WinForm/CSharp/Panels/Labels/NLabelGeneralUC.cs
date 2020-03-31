using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NLabelGeneralUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NGroupBox HeaderGroupBox;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NTextBox HeaderTextBox;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NGroupBox FooterGroupBox;
		private Nevron.UI.WinForm.Controls.NTextBox FooterTextBox;
		private Nevron.UI.WinForm.Controls.NButton FooterTextStyleButton;
		private Nevron.UI.WinForm.Controls.NButton HeaderTextStyleButton;
		private System.ComponentModel.Container components = null;
		private NLabel m_Footer;
		private NLabel m_Header;
		
		public NLabelGeneralUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.HeaderGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.HeaderTextStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.HeaderTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.FooterGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.FooterTextStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.FooterTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.HeaderGroupBox.SuspendLayout();
			this.FooterGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// HeaderGroupBox
			// 
			this.HeaderGroupBox.Controls.Add(this.HeaderTextStyleButton);
			this.HeaderGroupBox.Controls.Add(this.HeaderTextBox);
			this.HeaderGroupBox.Controls.Add(this.label1);
			this.HeaderGroupBox.ImageIndex = 0;
			this.HeaderGroupBox.Location = new System.Drawing.Point(5, 12);
			this.HeaderGroupBox.Name = "HeaderGroupBox";
			this.HeaderGroupBox.Size = new System.Drawing.Size(171, 114);
			this.HeaderGroupBox.TabIndex = 0;
			this.HeaderGroupBox.TabStop = false;
			this.HeaderGroupBox.Text = "Header";
			// 
			// HeaderTextStyleButton
			// 
			this.HeaderTextStyleButton.Location = new System.Drawing.Point(2, 72);
			this.HeaderTextStyleButton.Name = "HeaderTextStyleButton";
			this.HeaderTextStyleButton.Size = new System.Drawing.Size(160, 23);
			this.HeaderTextStyleButton.TabIndex = 2;
			this.HeaderTextStyleButton.Text = "Text Style";
			this.HeaderTextStyleButton.Click += new System.EventHandler(this.HeaderTextStyleButton_Click);
			// 
			// HeaderTextBox
			// 
			this.HeaderTextBox.Location = new System.Drawing.Point(1, 39);
			this.HeaderTextBox.Name = "HeaderTextBox";
			this.HeaderTextBox.Size = new System.Drawing.Size(160, 18);
			this.HeaderTextBox.TabIndex = 1;
			this.HeaderTextBox.TextChanged += new System.EventHandler(this.HeaderTextBox_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(1, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Text:";
			// 
			// FooterGroupBox
			// 
			this.FooterGroupBox.Controls.Add(this.FooterTextStyleButton);
			this.FooterGroupBox.Controls.Add(this.FooterTextBox);
			this.FooterGroupBox.Controls.Add(this.label2);
			this.FooterGroupBox.ImageIndex = 0;
			this.FooterGroupBox.Location = new System.Drawing.Point(6, 148);
			this.FooterGroupBox.Name = "FooterGroupBox";
			this.FooterGroupBox.Size = new System.Drawing.Size(171, 114);
			this.FooterGroupBox.TabIndex = 3;
			this.FooterGroupBox.TabStop = false;
			this.FooterGroupBox.Text = "Footer";
			// 
			// FooterTextStyleButton
			// 
			this.FooterTextStyleButton.Location = new System.Drawing.Point(2, 72);
			this.FooterTextStyleButton.Name = "FooterTextStyleButton";
			this.FooterTextStyleButton.Size = new System.Drawing.Size(160, 23);
			this.FooterTextStyleButton.TabIndex = 2;
			this.FooterTextStyleButton.Text = "Text Style";
			this.FooterTextStyleButton.Click += new System.EventHandler(this.FooterTextStyleButton_Click);
			// 
			// FooterTextBox
			// 
			this.FooterTextBox.Location = new System.Drawing.Point(1, 39);
			this.FooterTextBox.Name = "FooterTextBox";
			this.FooterTextBox.Size = new System.Drawing.Size(160, 18);
			this.FooterTextBox.TabIndex = 1;
			this.FooterTextBox.TextChanged += new System.EventHandler(this.FooterTextBox_TextChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(1, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(101, 19);
			this.label2.TabIndex = 0;
			this.label2.Text = "Text:";
			// 
			// NLabelGeneralUC
			// 
			this.Controls.Add(this.HeaderGroupBox);
			this.Controls.Add(this.FooterGroupBox);
			this.Name = "NLabelGeneralUC";
			this.Size = new System.Drawing.Size(180, 542);
			this.HeaderGroupBox.ResumeLayout(false);
			this.FooterGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NTrackballTool());
			nChartControl1.Panels.Clear();

			m_Header = new NLabel("Nevron Chart for .NET");
			m_Header.DockMode = PanelDockMode.Top;
			m_Header.ContentAlignment = ContentAlignment.MiddleCenter;
            m_Header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			m_Header.TextStyle.FillStyle = new NGradientFillStyle(Color.LightBlue, Color.DarkBlue);
			m_Header.TextStyle.BackplaneStyle.Visible = true;
			m_Header.TextStyle.BackplaneStyle.FillStyle.SetTransparencyPercent(50);
			m_Header.TextStyle.BorderStyle.Width = new NLength(1);
			m_Header.TextStyle.BorderStyle.Color = Color.LightBlue;
            m_Header.Margins = new NMarginsL(0, 10, 0, 10);
			nChartControl1.Panels.Add(m_Header);

			m_Footer = new NLabel("Copyright 1998 - 2011");
			m_Footer.DockMode = PanelDockMode.Bottom;
            m_Footer.TextStyle.FontStyle = new NFontStyle("Times New Roman", 12, FontStyle.Italic);
			m_Footer.ContentAlignment = ContentAlignment.MiddleLeft;
			m_Footer.TextStyle.FontStyle.EmSize = new NLength(9, NGraphicsUnit.Point);
			m_Footer.TextStyle.FillStyle = new NGradientFillStyle(Color.LightBlue, Color.DarkBlue);
			m_Footer.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            m_Footer.Margins = new NMarginsL(0, 10, 0, 10);
			nChartControl1.Panels.Add(m_Footer);

			NCartesianChart chart = new NCartesianChart();
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.DockMode = PanelDockMode.Fill;
			chart.DockMargins = new NMarginsL(20, 20, 20, 20);

			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.DarkRed, Color.Red);
			bar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			bar.DataLabelStyle.Visible = false;
			bar.ShadowStyle.Type = ShadowType.GaussianBlur;
			bar.ShadowStyle.Offset = new NPointL(3, 3);
			bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
			bar.ShadowStyle.FadeLength = new NLength(5);
			bar.Values.AddRange(monthValues);

            nChartControl1.Panels.Add(chart);

			HeaderTextBox.Text = m_Header.Text;
			FooterTextBox.Text = m_Footer.Text;

			nChartControl1.Refresh();
		}


		private void HeaderTextBox_TextChanged(object sender, System.EventArgs e)
		{
			m_Header.Text = HeaderTextBox.Text;
			nChartControl1.Refresh();
		}

		private void FooterTextStyleButton_Click(object sender, System.EventArgs e)
		{
			NTextStyle textStyle;

			if (NTextStyleTypeEditor.Edit(m_Footer.TextStyle, false, out textStyle))
			{
				m_Footer.TextStyle = textStyle;
				nChartControl1.Refresh();
			}		
		}

		private void HeaderTextStyleButton_Click(object sender, System.EventArgs e)
		{
			NTextStyle textStyle;

			if (NTextStyleTypeEditor.Edit(m_Header.TextStyle, false, out textStyle))
			{
				m_Header.TextStyle = textStyle;
				nChartControl1.Refresh();
			}
		}

		private void FooterTextBox_TextChanged(object sender, System.EventArgs e)
		{
			m_Footer.Text = FooterTextBox.Text;
			nChartControl1.Refresh();		
		}
	}
}
