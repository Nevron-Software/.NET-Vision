using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.Functions;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NCustomPaintingUsingGDIPlusUC : NCustomPaintingBase
	{
		private Nevron.UI.WinForm.Controls.NButton ChangeDataButton;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowDownwardArrows;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowUpwardArrows;
        private Nevron.UI.WinForm.Controls.NCheckBox ShowEqualSignsCheckBox;
		private System.ComponentModel.Container components = null;

		public NCustomPaintingUsingGDIPlusUC()
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
			this.ChangeDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ShowDownwardArrows = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowUpwardArrows = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowEqualSignsCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// ChangeDataButton
			// 
			this.ChangeDataButton.Location = new System.Drawing.Point(6, 101);
			this.ChangeDataButton.Name = "ChangeDataButton";
			this.ChangeDataButton.Size = new System.Drawing.Size(170, 23);
			this.ChangeDataButton.TabIndex = 4;
			this.ChangeDataButton.Text = "Change data";
			this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
			// 
			// ShowDownwardArrows
			// 
			this.ShowDownwardArrows.ButtonProperties.BorderOffset = 2;
			this.ShowDownwardArrows.Location = new System.Drawing.Point(6, 5);
			this.ShowDownwardArrows.Name = "ShowDownwardArrows";
			this.ShowDownwardArrows.Size = new System.Drawing.Size(146, 24);
			this.ShowDownwardArrows.TabIndex = 0;
			this.ShowDownwardArrows.Text = "Show downward arrows";
			this.ShowDownwardArrows.CheckedChanged += new System.EventHandler(this.ShowDownwardArrows_CheckedChanged);
			// 
			// ShowUpwardArrows
			// 
			this.ShowUpwardArrows.ButtonProperties.BorderOffset = 2;
			this.ShowUpwardArrows.Location = new System.Drawing.Point(6, 37);
			this.ShowUpwardArrows.Name = "ShowUpwardArrows";
			this.ShowUpwardArrows.Size = new System.Drawing.Size(146, 24);
			this.ShowUpwardArrows.TabIndex = 1;
			this.ShowUpwardArrows.Text = "Show upward arrows";
			this.ShowUpwardArrows.CheckedChanged += new System.EventHandler(this.ShowUpwardArrows_CheckedChanged);
			// 
			// ShowEqualSignsCheckBox
			// 
			this.ShowEqualSignsCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowEqualSignsCheckBox.Location = new System.Drawing.Point(6, 69);
			this.ShowEqualSignsCheckBox.Name = "ShowEqualSignsCheckBox";
			this.ShowEqualSignsCheckBox.Size = new System.Drawing.Size(146, 24);
			this.ShowEqualSignsCheckBox.TabIndex = 2;
			this.ShowEqualSignsCheckBox.Text = "Show equal signs";
			this.ShowEqualSignsCheckBox.CheckedChanged += new System.EventHandler(this.ShowEqualSignsCheckBox_CheckedChanged);
			// 
			// NCustomPaintingUsingGDIPlusUC
			// 
			this.Controls.Add(this.ShowEqualSignsCheckBox);
			this.Controls.Add(this.ShowUpwardArrows);
			this.Controls.Add(this.ShowDownwardArrows);
			this.Controls.Add(this.ChangeDataButton);
			this.Name = "NCustomPaintingUsingGDIPlusUC";
			this.Size = new System.Drawing.Size(180, 432);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			ConfigureChart("Custom Painting with GDI+");

			// configure form controls
			ShowDownwardArrows.Checked = true;
			ShowUpwardArrows.Checked = true;
			ShowEqualSignsCheckBox.Checked = true;

			ChangeDataButton_Click(null, null);
		}

        /// <summary>
        /// Occurs after the panel is painted.
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="eventArgs"></param>
        public override void OnAfterPaint(NPanel panel, NPanelPaintEventArgs eventArgs)
		{
            if (eventArgs.Graphics == null || eventArgs.Graphics.DeviceGraphics == null)
                return;

            Graphics graphics = eventArgs.Graphics.DeviceGraphics;
			double dPreviousValue, dCurrentValue;

			NAxis horzAxis = m_Chart.Axis(StandardAxis.PrimaryX);
			NAxis vertAxis = m_Chart.Axis(StandardAxis.PrimaryY);

			NVector3DF vecClientPoint = new NVector3DF();
			NVector3DF vecModelPoint = new NVector3DF();

            int nBarSize = (int)(m_Chart.ContentArea.Width * (int)m_Bar.WidthPercent) / (m_nBarCount * 200);

			// init pens and brushes
			Pen penRectBorder = new Pen(Color.DarkBlue);
			SolidBrush brushRectFill = new SolidBrush(Color.FromArgb(125, Color.LightBlue));

			Pen penPositiveArrowBorder = new Pen(Color.DarkGreen);
			SolidBrush brushPositiveArrowFill = new SolidBrush(Color.Green);

			Pen penEqualSignBorder = new Pen(Color.DarkGray);
			SolidBrush brushEqualSignFill = new SolidBrush(Color.Gray);

			Pen penNegativeArrowBorder = new Pen(Color.DarkRed);
			SolidBrush brushNegativeArrowFill = new SolidBrush(Color.Red);
            
			for (int i = 1; i < m_Bar.Values.Count; i++)
			{
				dPreviousValue = (double)m_Bar.Values[i - 1];
				dCurrentValue = (double)m_Bar.Values[i];

				vecModelPoint.X = horzAxis.TransformScaleToModel(false, i);
				vecModelPoint.Y = vertAxis.TransformScaleToModel(false, (float)(double)m_Bar.Values[i]);
				vecModelPoint.Z = 0;

				if (!m_Chart.TransformModelToClient(vecModelPoint, ref vecClientPoint))
					continue;

				RectangleF rcArrowRect = new RectangleF(vecClientPoint.X - nBarSize, vecClientPoint.Y - nBarSize, 2* nBarSize, 2 * nBarSize);

				if (rcArrowRect.Width > 0 && rcArrowRect.Height > 0 && DisplayMark(dCurrentValue, dPreviousValue))
				{
					// draw arrow background
					GraphicsPath path = GetRoundRectanglePath(rcArrowRect);

					graphics.FillPath(brushRectFill, path);
					graphics.DrawPath(penRectBorder, path);

					path.Dispose();

					rcArrowRect.Inflate(-5, -5);

					// draw the arrow itself
					if (rcArrowRect.Width > 0 && rcArrowRect.Height > 0)
					{
						if (dCurrentValue < dPreviousValue)
						{
							// draw negative arrow
							path = GetArrowPath(rcArrowRect, false);

							graphics.FillPath(brushNegativeArrowFill, path);
							graphics.DrawPath(penNegativeArrowBorder, path);

							path.Dispose();
						}
						else if (dCurrentValue > dPreviousValue)
						{
							// draw positive arrow
							path = GetArrowPath(rcArrowRect, true);

							graphics.FillPath(brushPositiveArrowFill, path);
							graphics.DrawPath(penPositiveArrowBorder, path);

							path.Dispose();
						}
						else
						{
							// draw equal sign
							RectangleF rect = new RectangleF(rcArrowRect.Left, rcArrowRect.Top, rcArrowRect.Width, rcArrowRect.Height / 3.0f);

							graphics.FillRectangle(brushEqualSignFill, rect.Left, rect.Top, rect.Width, rect.Height);
							graphics.DrawRectangle(penEqualSignBorder, rect.Left, rect.Top, rect.Width, rect.Height);

							rect = new RectangleF(rcArrowRect.Left, rcArrowRect.Bottom - rect.Height, rcArrowRect.Width, rect.Height);

							graphics.FillRectangle(brushEqualSignFill, rect.Left, rect.Top, rect.Width, rect.Height);
							graphics.DrawRectangle(penEqualSignBorder, rect.Left, rect.Top, rect.Width, rect.Height);
						}
					}
				}
			}

			// dispose pens and brushes
			penPositiveArrowBorder.Dispose();
			brushPositiveArrowFill.Dispose();

			penNegativeArrowBorder.Dispose();
			brushNegativeArrowFill.Dispose();

			brushRectFill.Dispose();
			penRectBorder.Dispose();
		}

		private bool DisplayMark(double dCurrentValue, double dPreviousValue)
		{
			if (dCurrentValue < dPreviousValue)
			{
				return ShowDownwardArrows.Checked;
			}
			else if (dCurrentValue > dPreviousValue)
			{
				return ShowUpwardArrows.Checked;
			}
			else
			{
				return ShowEqualSignsCheckBox.Checked;
			}
		}

		private void ShowUpwardArrows_CheckedChanged(object sender, System.EventArgs e)
		{
			nChartControl1.Refresh();
		}

		private void ShowEqualSignsCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			nChartControl1.Refresh();
		}

		private void ShowDownwardArrows_CheckedChanged(object sender, System.EventArgs e)
		{
			nChartControl1.Refresh();
		}

		private void ChangeDataButton_Click(object sender, System.EventArgs e)
		{
			ChangeData();
		}
	}
}
