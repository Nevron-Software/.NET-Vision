using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;
using Nevron.GraphicsCore;
using Nevron.GraphicsCore.Text;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NPopupNotifyUC.
	/// </summary>
	public class NPopupNotifyUC : NExampleUserControl
	{
		#region Constructor

		public NPopupNotifyUC(MainForm f) : base(f)
		{
			InitializeComponent();

			InitDefaultPopup();
			InitOffice2003Popup();
			InitMessengerPopup();
			InitShapedPopups();
		}


		#endregion

		#region Overrides

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}

				m_Office2003Popup.Dispose();
				m_MessengerPopup.Dispose();
				m_ShapedPopup1.Dispose();
				m_ShapedPopup2.Dispose();
				m_ShapedPopup3.Dispose();
			}
			base.Dispose( disposing );
		}

		public override void Initialize()
		{
			base.Initialize ();

			animationDirectionCombo.FillFromEnum(typeof(PopupAnimationDirection));
			animationDirectionCombo.SelectedItem = PopupAnimationDirection.Automatic;
		}


		#endregion

		#region Implementation

		internal void ShowPopup(NPopupNotify popup)
		{
			PopupAnimation animation = PopupAnimation.None;
			if(m_FadeCheck.Checked)
				animation |= PopupAnimation.Fade;
			if(m_SlideCheck.Checked)
				animation |= PopupAnimation.Slide;

			popup.AutoHide = m_AutoHideCheck.Checked;
			popup.VisibleSpan = (int)m_VisibleSpanNumeric.Value;
			popup.Opacity = (int)m_OpacityNumeric.Value;
			popup.Animation = animation;
			popup.AnimationDirection = (PopupAnimationDirection)animationDirectionCombo.SelectedItem;
			popup.VisibleOnMouseOver = m_StayVisibleCheck.Checked;
			popup.FullOpacityOnMouseOver = m_FullOpacityCheck.Checked;
			popup.AnimationInterval = (int)m_IntervalNumeric.Value;
			popup.AnimationSteps = (int)m_StepsNumeric.Value;

			popup.Palette.Copy(NUIManager.Palette);
			popup.Show();
		}

		internal void InitDefaultPopup()
		{
			m_SkinPopup = new NPopupNotify();
			m_SkinPopup.OptionsButton = true;
			m_SkinPopup.PredefinedStyle = PredefinedPopupStyle.Skinned;
			m_SkinPopup.Font = new Font("Tahoma", 8.0f);

			m_SkinPopup.Caption.Content.Text = "Skinnable Popup";

			NImageAndTextItem content = m_SkinPopup.Content;
			content.Image = imageList1.Images[1];
			content.ImageSize = new Nevron.GraphicsCore.NSize(28, 28);

			content.TextMargins = new NPadding(0, 4, 0, 0);
			content.Text = "<b>Peter Brown</b><br>Re: Thank you for purchasing Nevron UI</br><br><font color='navy'>See comments below</font></br>";
			content.Click += new EventHandler(OnContentClick);

			Nevron.UI.WinForm.Controls.NCommand comm;
			NCommandCollection coll = m_SkinPopup.OptionsCommands;

			for(int i = 1; i < 6; i++)
			{
				comm = new Nevron.UI.WinForm.Controls.NCommand();
				comm.Properties.Text = "Options command " + i.ToString();
				coll.Add(comm);
			}
		}
		internal void InitOffice2003Popup()
		{
			m_Office2003Popup = new NPopupNotify();
			m_Office2003Popup.PredefinedStyle = PredefinedPopupStyle.Office2003;
			m_Office2003Popup.Font = new Font("Tahoma", 8.0f);

			NImageAndTextItem content = m_Office2003Popup.Content;
			content.Image = imageList1.Images[1];
			content.ImageSize = new Nevron.GraphicsCore.NSize(28, 28);

			content.TextMargins = new NPadding(0, 4, 0, 0);
			content.Text = "<b>Peter Brown</b><br>Re: Thank you for purchasing Nevron UI</br><br><font color='navy'>See comments below</font></br>";
			content.Click += new EventHandler(OnContentClick);

			Nevron.UI.WinForm.Controls.NCommand comm;
			NCommandCollection coll = m_Office2003Popup.OptionsCommands;

			for(int i = 1; i < 6; i++)
			{
				comm = new Nevron.UI.WinForm.Controls.NCommand();
				comm.Properties.Text = "Options command " + i.ToString();
				coll.Add(comm);
			}
		}
		internal void InitMessengerPopup()
		{
			m_MessengerPopup = new NPopupNotify();
			m_MessengerPopup.PredefinedStyle = PredefinedPopupStyle.Messenger;
			m_MessengerPopup.Font = new Font("Tahoma", 8.0f);

			m_MessengerPopup.Caption.Content.Image = imageList2.Images[0];
			m_MessengerPopup.Caption.Content.Text = "<b><font color='Navy'>Messenger Style Popup</font></b><br/>";
			m_MessengerPopup.Content.ContentAlign = ContentAlignment.TopLeft;
			m_MessengerPopup.Content.Image = imageList1.Images[1];
			m_MessengerPopup.Content.ImageSize = new Nevron.GraphicsCore.NSize(28, 28);
			m_MessengerPopup.Content.Padding = new NPadding(4);
			m_MessengerPopup.Content.Text = "<b><u>Notification Content</u></b><br/>You have <u>complete</u> control over text <i>visualization!</i>";
			m_MessengerPopup.Content.Click += new EventHandler(OnContentClick);

			m_MessengerPopup.Content.TreatAsOneEntity = false;
			m_MessengerPopup.Content.ImageAlign = ContentAlignment.TopLeft;
			m_MessengerPopup.Content.TextAlign = ContentAlignment.TopLeft;
			//m_MessengerPopup.Content.TextMargins = new NPadding(5, 5, 0, 0);
		}

		internal void InitShapedPopups()
		{
			m_ShapedPopup1 = new NPopupNotify();
			m_ShapedPopup2 = new NPopupNotify();
			m_ShapedPopup3 = new NPopupNotify();

			m_ShapedPopup1.PredefinedStyle = PredefinedPopupStyle.Shaped;
			m_ShapedPopup2.PredefinedStyle = PredefinedPopupStyle.Shaped;
			m_ShapedPopup3.PredefinedStyle = PredefinedPopupStyle.Shaped;

			Type type = typeof(NPopupNotifyUC);
			string path = "Nevron.Examples.UI.WinForm.PopupNotify";

			m_ShapedPopup1.ShapeTransparentColor = Color.Magenta;
			m_ShapedPopup2.ShapeTransparentColor = Color.Magenta;
			m_ShapedPopup3.ShapeTransparentColor = Color.Magenta;

			m_ShapedPopup1.Shape = NResourceHelper.BitmapFromResource(type, "notification3.bmp", path);
			m_ShapedPopup1.Caption.ButtonSize = new NSize(20, 20);
			m_ShapedPopup1.Caption.ButtonsMargins = new NPadding(0, 4, 0, 6);
			m_ShapedPopup1.MoveableBounds = new Rectangle(100, 69, 226, 10);
			m_ShapedPopup1.CaptionBounds = new Rectangle(80, 69, 246, 30);
			m_ShapedPopup1.ContentBounds = new Rectangle(100, 79, 206, 46);

			m_ShapedPopup2.Shape = NResourceHelper.BitmapFromResource(type, "notification1.bmp", path);
			m_ShapedPopup2.Content.Padding = new NPadding(6, 0, 0, 0);
			m_ShapedPopup2.Caption.ButtonsMargins = new NPadding(0, 6, 0, 23);
			m_ShapedPopup2.Content.Text = "<font color='#606060' face='Tahoma'><b>Meet John!</b></font>";

			m_ShapedPopup3.Shape = NResourceHelper.BitmapFromResource(type, "notification2.bmp", path);
			m_ShapedPopup3.Caption.ButtonsMargins = new NPadding(0, 3, 0, 4);
			m_ShapedPopup3.Content.Text = "<font face='Trebuchet MS' color='brown' size='10'><b>Welcome to<br/>Nevron UI for .NET</b></font>";

			NImageAndTextItem item = m_ShapedPopup1.Content;
			item.Text = "<u><font face='Verdana' color='Red'><i>You have 1 <font color='Navy'>new</font> message(s)!</i></font></u>";

			ImageList list = NResourceHelper.ImageListFromBitmap(type, new Size(20, 20), Color.Magenta, "close.bmp", path);
			NUIItemImageSet imageSet = m_ShapedPopup1.CloseButtonImageSet;

			imageSet.NormalImage = list.Images[0];
			imageSet.HotImage = list.Images[1];
			imageSet.PressedImage = list.Images[2];
		}


		#endregion

		#region Event Handlers

		private void m_ShowOffice2003Button_Click(object sender, System.EventArgs e)
		{
			ShowPopup(m_Office2003Popup);
		}

		private void m_MessengerButton_Click(object sender, System.EventArgs e)
		{
			ShowPopup(m_MessengerPopup);
		}

		private void m_ShapedButton_Click(object sender, System.EventArgs e)
		{
		}
		private void m_ShapedButton1_Click(object sender, System.EventArgs e)
		{
			ShowPopup(m_ShapedPopup1);
		}
		private void m_ShapedButton2_Click(object sender, System.EventArgs e)
		{
			ShowPopup(m_ShapedPopup2);
		}
		private void m_ShapedButton3_Click(object sender, System.EventArgs e)
		{
			ShowPopup(m_ShapedPopup3);
		}
		private void OnContentClick(object sender, EventArgs e)
		{
			/*NUIItem item = (NUIItem)sender;

			object o = item.GetRenderCacheEntry(UIRenderCacheEntries.TextBounds);
			if(!(o is Rectangle))
				return;

			Rectangle r = (Rectangle)o;

			INUIElementHost host = item.Host;
			Point client = host.ClientMouse;

			if(r.Contains(client))
				MessageBox.Show("Content Text Was Clicked!");*/
		}

		private void defaultButton_Click(object sender, System.EventArgs e)
		{
			ShowPopup(m_SkinPopup);
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NPopupNotifyUC));
			this.label1 = new System.Windows.Forms.Label();
			this.m_OpacityNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.m_VisibleSpanNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.m_FadeCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_SlideCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_ShowOffice2003Button = new Nevron.UI.WinForm.Controls.NButton();
			this.m_AutoHideCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_StayVisibleCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.m_MessengerButton = new Nevron.UI.WinForm.Controls.NButton();
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.m_FullOpacityCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nGrouper1 = new Nevron.UI.WinForm.Controls.NGrouper();
			this.nGrouper2 = new Nevron.UI.WinForm.Controls.NGrouper();
			this.animationDirectionCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.m_StepsNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.m_IntervalNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.m_ShapedButton1 = new Nevron.UI.WinForm.Controls.NButton();
			this.m_ShapedButton2 = new Nevron.UI.WinForm.Controls.NButton();
			this.m_ShapedButton3 = new Nevron.UI.WinForm.Controls.NButton();
			this.defaultButton = new Nevron.UI.WinForm.Controls.NButton();
			((System.ComponentModel.ISupportInitialize)(this.m_OpacityNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_VisibleSpanNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nGrouper1)).BeginInit();
			this.nGrouper1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nGrouper2)).BeginInit();
			this.nGrouper2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_StepsNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_IntervalNumeric)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Opacity:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_OpacityNumeric
			// 
			this.m_OpacityNumeric.Location = new System.Drawing.Point(88, 32);
			this.m_OpacityNumeric.Maximum = new System.Decimal(new int[] {
																			 255,
																			 0,
																			 0,
																			 0});
			this.m_OpacityNumeric.Name = "m_OpacityNumeric";
			this.m_OpacityNumeric.Size = new System.Drawing.Size(80, 18);
			this.m_OpacityNumeric.TabIndex = 1;
			this.m_OpacityNumeric.Value = new System.Decimal(new int[] {
																		   255,
																		   0,
																		   0,
																		   0});
			// 
			// m_VisibleSpanNumeric
			// 
			this.m_VisibleSpanNumeric.CustomText = " ms";
			this.m_VisibleSpanNumeric.Increment = new System.Decimal(new int[] {
																				   10,
																				   0,
																				   0,
																				   0});
			this.m_VisibleSpanNumeric.Location = new System.Drawing.Point(88, 56);
			this.m_VisibleSpanNumeric.Maximum = new System.Decimal(new int[] {
																				 10000,
																				 0,
																				 0,
																				 0});
			this.m_VisibleSpanNumeric.Name = "m_VisibleSpanNumeric";
			this.m_VisibleSpanNumeric.Size = new System.Drawing.Size(80, 18);
			this.m_VisibleSpanNumeric.TabIndex = 3;
			this.m_VisibleSpanNumeric.Value = new System.Decimal(new int[] {
																			   5000,
																			   0,
																			   0,
																			   0});
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Visible Span:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_FadeCheck
			// 
			this.m_FadeCheck.ButtonProperties.BorderOffset = 2;
			this.m_FadeCheck.Checked = true;
			this.m_FadeCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_FadeCheck.Location = new System.Drawing.Point(80, 112);
			this.m_FadeCheck.Name = "m_FadeCheck";
			this.m_FadeCheck.Size = new System.Drawing.Size(72, 24);
			this.m_FadeCheck.TabIndex = 4;
			this.m_FadeCheck.Text = "Fade";
			this.m_FadeCheck.TransparentBackground = true;
			// 
			// m_SlideCheck
			// 
			this.m_SlideCheck.ButtonProperties.BorderOffset = 2;
			this.m_SlideCheck.Location = new System.Drawing.Point(80, 136);
			this.m_SlideCheck.Name = "m_SlideCheck";
			this.m_SlideCheck.Size = new System.Drawing.Size(72, 24);
			this.m_SlideCheck.TabIndex = 5;
			this.m_SlideCheck.Text = "Slide";
			this.m_SlideCheck.TransparentBackground = true;
			// 
			// m_ShowOffice2003Button
			// 
			this.m_ShowOffice2003Button.Location = new System.Drawing.Point(112, 192);
			this.m_ShowOffice2003Button.Name = "m_ShowOffice2003Button";
			this.m_ShowOffice2003Button.Size = new System.Drawing.Size(96, 24);
			this.m_ShowOffice2003Button.TabIndex = 6;
			this.m_ShowOffice2003Button.Text = "Office 2003";
			this.m_ShowOffice2003Button.Click += new System.EventHandler(this.m_ShowOffice2003Button_Click);
			// 
			// m_AutoHideCheck
			// 
			this.m_AutoHideCheck.ButtonProperties.BorderOffset = 2;
			this.m_AutoHideCheck.Checked = true;
			this.m_AutoHideCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_AutoHideCheck.Location = new System.Drawing.Point(88, 88);
			this.m_AutoHideCheck.Name = "m_AutoHideCheck";
			this.m_AutoHideCheck.Size = new System.Drawing.Size(120, 24);
			this.m_AutoHideCheck.TabIndex = 7;
			this.m_AutoHideCheck.Text = "Auto-hide";
			this.m_AutoHideCheck.TransparentBackground = true;
			// 
			// m_StayVisibleCheck
			// 
			this.m_StayVisibleCheck.ButtonProperties.BorderOffset = 2;
			this.m_StayVisibleCheck.Checked = true;
			this.m_StayVisibleCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_StayVisibleCheck.Location = new System.Drawing.Point(88, 112);
			this.m_StayVisibleCheck.Name = "m_StayVisibleCheck";
			this.m_StayVisibleCheck.Size = new System.Drawing.Size(160, 24);
			this.m_StayVisibleCheck.TabIndex = 8;
			this.m_StayVisibleCheck.Text = "Visible on mouse over";
			this.m_StayVisibleCheck.TransparentBackground = true;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(28, 28);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// m_MessengerButton
			// 
			this.m_MessengerButton.Location = new System.Drawing.Point(216, 192);
			this.m_MessengerButton.Name = "m_MessengerButton";
			this.m_MessengerButton.Size = new System.Drawing.Size(96, 24);
			this.m_MessengerButton.TabIndex = 9;
			this.m_MessengerButton.Text = "Messenger";
			this.m_MessengerButton.Click += new System.EventHandler(this.m_MessengerButton_Click);
			// 
			// imageList2
			// 
			this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
			this.imageList2.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// m_FullOpacityCheck
			// 
			this.m_FullOpacityCheck.ButtonProperties.BorderOffset = 2;
			this.m_FullOpacityCheck.Checked = true;
			this.m_FullOpacityCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_FullOpacityCheck.Location = new System.Drawing.Point(88, 136);
			this.m_FullOpacityCheck.Name = "m_FullOpacityCheck";
			this.m_FullOpacityCheck.Size = new System.Drawing.Size(160, 24);
			this.m_FullOpacityCheck.TabIndex = 10;
			this.m_FullOpacityCheck.Text = "Full opacity on mouse over";
			this.m_FullOpacityCheck.TransparentBackground = true;
			// 
			// nGrouper1
			// 
			this.nGrouper1.Controls.Add(this.m_VisibleSpanNumeric);
			this.nGrouper1.Controls.Add(this.label2);
			this.nGrouper1.Controls.Add(this.m_OpacityNumeric);
			this.nGrouper1.Controls.Add(this.label1);
			this.nGrouper1.Controls.Add(this.m_FullOpacityCheck);
			this.nGrouper1.Controls.Add(this.m_AutoHideCheck);
			this.nGrouper1.Controls.Add(this.m_StayVisibleCheck);
			this.nGrouper1.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.nGrouper1.FooterItem.Text = "Footer";
			this.nGrouper1.FooterItem.Visible = false;
			this.nGrouper1.HeaderItem.Style.FontInfo = new Nevron.UI.NThemeFontInfo("Tahoma", 10F, Nevron.GraphicsCore.FontStyleEx.Regular);
			this.nGrouper1.HeaderItem.Style.TextFillStyle = new Nevron.GraphicsCore.NColorFillStyle(new Nevron.GraphicsCore.NArgbColor(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))));
			this.nGrouper1.HeaderItem.Text = "Behaviour";
			this.nGrouper1.Location = new System.Drawing.Point(8, 8);
			this.nGrouper1.Name = "nGrouper1";
			this.nGrouper1.Size = new System.Drawing.Size(256, 176);
			this.nGrouper1.TabIndex = 13;
			this.nGrouper1.Text = "nGrouper1";
			// 
			// nGrouper2
			// 
			this.nGrouper2.Controls.Add(this.animationDirectionCombo);
			this.nGrouper2.Controls.Add(this.label5);
			this.nGrouper2.Controls.Add(this.m_StepsNumeric);
			this.nGrouper2.Controls.Add(this.label4);
			this.nGrouper2.Controls.Add(this.m_IntervalNumeric);
			this.nGrouper2.Controls.Add(this.label3);
			this.nGrouper2.Controls.Add(this.m_SlideCheck);
			this.nGrouper2.Controls.Add(this.m_FadeCheck);
			this.nGrouper2.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.nGrouper2.FooterItem.Text = "Footer";
			this.nGrouper2.FooterItem.Visible = false;
			this.nGrouper2.FooterStrokeInfo.PenWidth = 10;
			this.nGrouper2.HeaderItem.Style.FontInfo = new Nevron.UI.NThemeFontInfo("Tahoma", 10F, Nevron.GraphicsCore.FontStyleEx.Regular);
			this.nGrouper2.HeaderItem.Style.TextFillStyle = new Nevron.GraphicsCore.NColorFillStyle(new Nevron.GraphicsCore.NArgbColor(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))));
			this.nGrouper2.HeaderItem.Text = "Animation";
			this.nGrouper2.Location = new System.Drawing.Point(272, 8);
			this.nGrouper2.Name = "nGrouper2";
			this.nGrouper2.Size = new System.Drawing.Size(232, 176);
			this.nGrouper2.TabIndex = 14;
			this.nGrouper2.Text = "nGrouper2";
			// 
			// animationDirectionCombo
			// 
			this.animationDirectionCombo.Location = new System.Drawing.Point(80, 80);
			this.animationDirectionCombo.Name = "animationDirectionCombo";
			this.animationDirectionCombo.Size = new System.Drawing.Size(136, 22);
			this.animationDirectionCombo.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Location = new System.Drawing.Point(8, 80);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 24);
			this.label5.TabIndex = 10;
			this.label5.Text = "Direction:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_StepsNumeric
			// 
			this.m_StepsNumeric.Location = new System.Drawing.Point(80, 56);
			this.m_StepsNumeric.Minimum = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			this.m_StepsNumeric.Name = "m_StepsNumeric";
			this.m_StepsNumeric.Size = new System.Drawing.Size(64, 18);
			this.m_StepsNumeric.TabIndex = 9;
			this.m_StepsNumeric.Value = new System.Decimal(new int[] {
																		 20,
																		 0,
																		 0,
																		 0});
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Location = new System.Drawing.Point(8, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "Steps:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_IntervalNumeric
			// 
			this.m_IntervalNumeric.CustomText = " ms";
			this.m_IntervalNumeric.Location = new System.Drawing.Point(80, 32);
			this.m_IntervalNumeric.Minimum = new System.Decimal(new int[] {
																			  1,
																			  0,
																			  0,
																			  0});
			this.m_IntervalNumeric.Name = "m_IntervalNumeric";
			this.m_IntervalNumeric.Size = new System.Drawing.Size(64, 18);
			this.m_IntervalNumeric.TabIndex = 7;
			this.m_IntervalNumeric.Value = new System.Decimal(new int[] {
																			20,
																			0,
																			0,
																			0});
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Location = new System.Drawing.Point(8, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Interval:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_ShapedButton1
			// 
			this.m_ShapedButton1.Location = new System.Drawing.Point(8, 224);
			this.m_ShapedButton1.Name = "m_ShapedButton1";
			this.m_ShapedButton1.Size = new System.Drawing.Size(96, 24);
			this.m_ShapedButton1.TabIndex = 15;
			this.m_ShapedButton1.Text = "Shaped 1";
			this.m_ShapedButton1.Click += new System.EventHandler(this.m_ShapedButton1_Click);
			// 
			// m_ShapedButton2
			// 
			this.m_ShapedButton2.Location = new System.Drawing.Point(112, 224);
			this.m_ShapedButton2.Name = "m_ShapedButton2";
			this.m_ShapedButton2.Size = new System.Drawing.Size(96, 24);
			this.m_ShapedButton2.TabIndex = 16;
			this.m_ShapedButton2.Text = "Shaped 2";
			this.m_ShapedButton2.Click += new System.EventHandler(this.m_ShapedButton2_Click);
			// 
			// m_ShapedButton3
			// 
			this.m_ShapedButton3.Location = new System.Drawing.Point(216, 224);
			this.m_ShapedButton3.Name = "m_ShapedButton3";
			this.m_ShapedButton3.Size = new System.Drawing.Size(96, 24);
			this.m_ShapedButton3.TabIndex = 17;
			this.m_ShapedButton3.Text = "Shaped 3";
			this.m_ShapedButton3.Click += new System.EventHandler(this.m_ShapedButton3_Click);
			// 
			// defaultButton
			// 
			this.defaultButton.Location = new System.Drawing.Point(8, 192);
			this.defaultButton.Name = "defaultButton";
			this.defaultButton.Size = new System.Drawing.Size(96, 24);
			this.defaultButton.TabIndex = 18;
			this.defaultButton.Text = "Skinned";
			this.defaultButton.Click += new System.EventHandler(this.defaultButton_Click);
			// 
			// NPopupNotifyUC
			// 
			this.Controls.Add(this.defaultButton);
			this.Controls.Add(this.m_ShapedButton3);
			this.Controls.Add(this.m_ShapedButton2);
			this.Controls.Add(this.m_ShapedButton1);
			this.Controls.Add(this.nGrouper2);
			this.Controls.Add(this.nGrouper1);
			this.Controls.Add(this.m_MessengerButton);
			this.Controls.Add(this.m_ShowOffice2003Button);
			this.Name = "NPopupNotifyUC";
			this.Size = new System.Drawing.Size(512, 256);
			((System.ComponentModel.ISupportInitialize)(this.m_OpacityNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_VisibleSpanNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nGrouper1)).EndInit();
			this.nGrouper1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nGrouper2)).EndInit();
			this.nGrouper2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_StepsNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_IntervalNumeric)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		internal NPopupNotify m_SkinPopup;
		internal NPopupNotify m_Office2003Popup;
		internal NPopupNotify m_MessengerPopup;
		internal NPopupNotify m_ShapedPopup1;
		internal NPopupNotify m_ShapedPopup2;
		internal NPopupNotify m_ShapedPopup3;

		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NNumericUpDown m_OpacityNumeric;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown m_VisibleSpanNumeric;
		private Nevron.UI.WinForm.Controls.NCheckBox m_FadeCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox m_SlideCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox m_AutoHideCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox m_StayVisibleCheck;
		private Nevron.UI.WinForm.Controls.NButton m_ShowOffice2003Button;
		private Nevron.UI.WinForm.Controls.NButton m_MessengerButton;
		private System.Windows.Forms.ImageList imageList2;
		private Nevron.UI.WinForm.Controls.NCheckBox m_FullOpacityCheck;
		private Nevron.UI.WinForm.Controls.NGrouper nGrouper1;
		private Nevron.UI.WinForm.Controls.NGrouper nGrouper2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown m_IntervalNumeric;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NNumericUpDown m_StepsNumeric;
		private Nevron.UI.WinForm.Controls.NButton m_ShapedButton1;
		private Nevron.UI.WinForm.Controls.NButton m_ShapedButton2;
		private Nevron.UI.WinForm.Controls.NButton m_ShapedButton3;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NComboBox animationDirectionCombo;
		private Nevron.UI.WinForm.Controls.NButton defaultButton;
		private System.Windows.Forms.ImageList imageList1;

		#endregion
	}
}
