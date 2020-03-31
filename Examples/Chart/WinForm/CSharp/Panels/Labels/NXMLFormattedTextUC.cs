using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.UI;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NXMLFormattedTextUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton TextFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton TextBorderbutton;
		private Nevron.UI.WinForm.Controls.NButton TextShadowButton;
		private Nevron.UI.WinForm.Controls.NButton TextFontButton;
		private Nevron.UI.WinForm.Controls.NComboBox PredefinedSampleTextComboBox;
		private System.Windows.Forms.FontDialog TextDefaultFontDialog;
		private Nevron.UI.WinForm.Controls.NTextBox TextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.ComponentModel.Container components = null;

		public NXMLFormattedTextUC()
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
			this.TextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.PredefinedSampleTextComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TextFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.TextBorderbutton = new Nevron.UI.WinForm.Controls.NButton();
			this.TextShadowButton = new Nevron.UI.WinForm.Controls.NButton();
			this.TextFontButton = new Nevron.UI.WinForm.Controls.NButton();
			this.TextDefaultFontDialog = new System.Windows.Forms.FontDialog();
			this.SuspendLayout();
			// 
			// TextBox
			// 
			this.TextBox.Location = new System.Drawing.Point(5, 29);
			this.TextBox.Multiline = true;
			this.TextBox.Name = "TextBox";
			this.TextBox.Size = new System.Drawing.Size(170, 162);
			this.TextBox.TabIndex = 0;
			this.TextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 195);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(170, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Load sample text:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PredefinedSampleTextComboBox
			// 
			this.PredefinedSampleTextComboBox.ListProperties.CheckBoxDataMember = "";
			this.PredefinedSampleTextComboBox.ListProperties.DataSource = null;
			this.PredefinedSampleTextComboBox.ListProperties.DisplayMember = "";
			this.PredefinedSampleTextComboBox.Location = new System.Drawing.Point(5, 222);
			this.PredefinedSampleTextComboBox.Name = "PredefinedSampleTextComboBox";
			this.PredefinedSampleTextComboBox.Size = new System.Drawing.Size(170, 21);
			this.PredefinedSampleTextComboBox.TabIndex = 2;
			this.PredefinedSampleTextComboBox.SelectedIndexChanged += new System.EventHandler(this.PredefinedSampleTextComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(170, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Label text:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TextFillStyleButton
			// 
			this.TextFillStyleButton.Location = new System.Drawing.Point(5, 259);
			this.TextFillStyleButton.Name = "TextFillStyleButton";
			this.TextFillStyleButton.Size = new System.Drawing.Size(170, 23);
			this.TextFillStyleButton.TabIndex = 4;
			this.TextFillStyleButton.Text = "Fill Style...";
			this.TextFillStyleButton.Click += new System.EventHandler(this.TextFillStyleButton_Click);
			// 
			// TextBorderbutton
			// 
			this.TextBorderbutton.Location = new System.Drawing.Point(5, 294);
			this.TextBorderbutton.Name = "TextBorderbutton";
			this.TextBorderbutton.Size = new System.Drawing.Size(170, 23);
			this.TextBorderbutton.TabIndex = 5;
			this.TextBorderbutton.Text = "Border...";
			this.TextBorderbutton.Click += new System.EventHandler(this.TextBorderbutton_Click);
			// 
			// TextShadowButton
			// 
			this.TextShadowButton.Location = new System.Drawing.Point(5, 330);
			this.TextShadowButton.Name = "TextShadowButton";
			this.TextShadowButton.Size = new System.Drawing.Size(170, 23);
			this.TextShadowButton.TabIndex = 6;
			this.TextShadowButton.Text = "Shadow...";
			this.TextShadowButton.Click += new System.EventHandler(this.TextShadowButton_Click);
			// 
			// TextFontButton
			// 
			this.TextFontButton.Location = new System.Drawing.Point(5, 364);
			this.TextFontButton.Name = "TextFontButton";
			this.TextFontButton.Size = new System.Drawing.Size(170, 23);
			this.TextFontButton.TabIndex = 7;
			this.TextFontButton.Text = "Font...";
			this.TextFontButton.Click += new System.EventHandler(this.TextFontButton_Click);
			// 
			// NXMLFormattedTextUC
			// 
			this.Controls.Add(this.TextFontButton);
			this.Controls.Add(this.TextShadowButton);
			this.Controls.Add(this.TextBorderbutton);
			this.Controls.Add(this.TextFillStyleButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.PredefinedSampleTextComboBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TextBox);
			this.Name = "NXMLFormattedTextUC";
			this.Size = new System.Drawing.Size(180, 408);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("");
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.BackplaneStyle.Visible = true;
			title.TextStyle.BackplaneStyle.FillStyle = new NColorFillStyle(Color.FromArgb(125, 255, 255, 255));
			title.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderWidth = new NLength(0, NGraphicsUnit.Pixel);
			title.TextStyle.FillStyle = new NColorFillStyle(Color.Black);
			title.TextStyle.FontStyle = new NFontStyle("Arial", 16);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			nChartControl1.Charts.Clear();

			PredefinedSampleTextComboBox.Items.Add("Font size and color");
			PredefinedSampleTextComboBox.Items.Add("Font style control");
			PredefinedSampleTextComboBox.Items.Add("Subscript and superscript");
            PredefinedSampleTextComboBox.Items.Add("Shapes");
			PredefinedSampleTextComboBox.Items.Add("Bullets");
			PredefinedSampleTextComboBox.Items.Add("Fill Styles");
			PredefinedSampleTextComboBox.Items.Add("Border Styles");
			PredefinedSampleTextComboBox.Items.Add("Shadows Styles");
            PredefinedSampleTextComboBox.Items.Add("Text Background");
			PredefinedSampleTextComboBox.SelectedIndex = 8;
		}

		private String GetBulletText(String sBulletType)
		{
			return sBulletType + " bullets <ul liststyletype = '" + sBulletType + "'>" + 
					"<li color = 'red'>" + sBulletType + " Bullet 1" + "</li>" + 
					"<li color = 'blue'>" + sBulletType + " Bullet 2" + "</li>" +
					"</ul><br/>";
		}

		private void PredefinedSampleTextComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			String sText = "";

			switch (PredefinedSampleTextComboBox.SelectedIndex)
			{
				case 0:
					// Font size and color 
					sText = "<font size = '19' color = 'red'>XML formatted</font> texts allow you to mix<br/>" + 
							"texts with different <font color = 'blue' size = '24' face = 'Balthazar'>font</font> and <font face = 'Arial black' color = 'green' size = '24'>size</font>";
					break;
				case 1:
					// Font style control
					sText = "Demonstrates how to use <font color = 'red'><b>bold</b></font>, <font color = 'green'><i>italic</i></font>, <br/><font color = 'blue'><u>underline</u></font> and <font color = 'darkorange'><strike>strikeout</strike></font> tags";
					break;
				case 2:
					// Subscript and superscript
					sText = "World's most famous formula : <font size = '25' color = 'red'><b>E = MC<sup>2</sup></b></font> <br/>This text uses <sup>sup</sup> and <sub>sub</sub> tags";
					break;
                case 3:
                    // Shapes
                    Array values = Enum.GetValues(typeof(MarkerShape));
                    string[] names = Enum.GetNames(typeof(MarkerShape));
					Color[] lightColors = new Color[] { Color.Red, Color.Green, Color.Blue } ;
					Color[] darkColors = new Color[] { Color.DarkRed, Color.DarkGreen, Color.DarkBlue };

                    for (int i = 0; i < names.Length; i++)
                    {
						sText += names[i] + " Shape <shape shape='" + names[i].ToLower() + "' size = '20pt, 20pt' color = '" + lightColors[i % 3].ToKnownColor().ToString() + "' bordercolor = '" + darkColors[i % 3].ToKnownColor().ToString() + "'/><br/>";
                    }
                    break;
                case 4:
					// Bullets 
						sText = "XML formatted texts support several bullet list styles<br/><font size = '12'>";

						String[] arrEnumNames = Enum.GetNames(typeof(ListStyleType));

						for (int i = 0; i < arrEnumNames.Length; i++)
						{
							sText += GetBulletText(arrEnumNames[i]);
						}

						sText += "</font>";
					break;
				case 5:
					// Fill Styles
					sText = "XML formatted texts support: <br/><font color = 'red'>- Solid color</font><br/><font gradient = '0, 0, white, navy'>- Simple (two color) gradient</font><br/><font pattern = '25, white, navy'>- Pattern (hatch)</font><br/>filling types";
					break;
				case 6: 
					// Border Styles
					sText = "Text borders can be with different <br/><font face = 'Impact' gradient = '0, 1, White, Navy' size = '33'> <font border = '2' bordercolor = 'red'>WIDTH</font> and <font bordercolor = 'magenta' border = '1'>COLOR</font></font>";
					break;
				case 7:
					// Shadow Styles
					sText = "There are several types of shadows: <br/>" + 
							" <font shadowoffset = '10, 10' shadowfadelength = '8' face = 'Impact' gradient = '0, 1, White, Navy' size = '33'>" + 
							"- <font shadowtype = 'solid'>Solid Shadow</font> <br/>" + 
							"- <font shadowtype = 'linearblur'>Linear Blur Shadow</font> <br/>" + 
							"- <font shadowtype = 'radialblur'>Radial Blur Shadow</font> <br/>" + 
							"- <font shadowtype = 'gaussianblur'>Gaussian Blur Shadow</font> <br/>" + 
							"</font>" + 
							"You can also use shadows to <font face = 'Impact' gradient = '0, 1, White, DarkOrange' size = '33' shadowtype = 'gaussianblur' shadowcolor = 'yellow' shadowfadelength = '8' shadowoffset = '0, 0'>HIGHLIGHT TEXT</font>";
					break;
                case 8:
                    // Text background
                    sText = "XML Formatted text allow you to control the text background.<br/>" +
                            "This is <font color = 'black' back-color = 'orange'>BLACK TEXT ON AN ORANGE BACKGROUND</font><br/>" +
                            "This is <font color = 'white' back-gradient = '0,0,white,navy'>WHITE TEXT ON A GRADIENT BACKGROUND</font><br/>" +

                            "This is <font color = 'black' back-color = 'orange' back-bordercolor = 'red' back-borderwidth = '1pt'>BLACK TEXT ON AN ORANGE BACKGROUND, WITH RED OUTLINE</font><br/>" +
                            "This is <font color = 'white' back-color = 'black' back-bordercolor = 'red' back-borderwidth = '1pt'>WHITE TEXT ON A BLACK BACKGROUND</font><br/>";
                    break;
			}

			TextBox.Text = sText;
		}

		private void TextBox_TextChanged(object sender, System.EventArgs e)
		{
			NLabel label = nChartControl1.Labels[0];
			label.Text = TextBox.Text;
			nChartControl1.Refresh();
		}

		private void TextFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NLabel label = nChartControl1.Labels[0];
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(label.TextStyle.FillStyle, out fillStyleResult))
			{
				label.TextStyle.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void TextBorderbutton_Click(object sender, System.EventArgs e)
		{
			NLabel label = nChartControl1.Labels[0];
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(label.TextStyle.BorderStyle, out strokeStyleResult))
			{
				label.TextStyle.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void TextShadowButton_Click(object sender, System.EventArgs e)
		{
			NLabel label = nChartControl1.Labels[0];
			NShadowStyle shadowStyleResult;

			if (NShadowStyleTypeEditor.Edit(label.TextStyle.ShadowStyle, out shadowStyleResult))
			{
				label.TextStyle.ShadowStyle = shadowStyleResult;
				nChartControl1.Refresh();		
			}
		}

		private void TextFontButton_Click(object sender, System.EventArgs e)
		{
			NLabel label = nChartControl1.Labels[0];

			TextDefaultFontDialog = new FontDialog();
			TextDefaultFontDialog.Font = new Font(label.TextStyle.FontStyle.Name, label.TextStyle.FontStyle.EmSize.Value, label.TextStyle.FontStyle.Style);

			if (TextDefaultFontDialog.ShowDialog() == DialogResult.OK)
			{
				label.TextStyle.FontStyle.Name = TextDefaultFontDialog.Font.Name;
				label.TextStyle.FontStyle.EmSize = new NLength(TextDefaultFontDialog.Font.SizeInPoints, NGraphicsUnit.Point);
				label.TextStyle.FontStyle.Style = TextDefaultFontDialog.Font.Style;

				nChartControl1.Refresh();
			}
		}

	}
}