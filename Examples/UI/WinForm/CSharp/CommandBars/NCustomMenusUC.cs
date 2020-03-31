using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.IO;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	public class NCustomMenusUC : NExampleUserControl
	{
		#region Constructor

		public NCustomMenusUC(MainForm f) : base(f)
		{
			InitializeComponent();
			m_iContextID = 1;
			Dock = DockStyle.Fill;

			Init();

			NUIManager.MenuOptions.DefaultMenuType = typeof(NCustomMenu);
			NUIManager.MenuOptions.HasShadow = false;
		}


		#endregion

		#region Implementation

		protected override void Dispose( bool disposing )
		{
			NUIManager.MenuOptions.DefaultMenuType = typeof(NMenuWindow);
			NUIManager.MenuOptions.HasShadow = true;

			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
				if(m_Manager != null)
					m_Manager.Dispose();
			}
			base.Dispose( disposing );
		}


		internal void Init()
		{
			InitManager();
			InitRanges();
			InitContexts();
			InitToolbars();
		}
		internal void InitManager()
		{
			m_Manager = new NCommandBarsManager(this);
			m_Manager.Palette.Copy(NUIManager.Palette);
			m_Manager.Contexts.UniqueIDOnly = false;
		}

		internal void InitRanges()
		{
			NRange r = new NRange();
			r.Name = "Standard";
			r.ID = 0;
			m_Manager.Ranges.Add(r);
		}


		#region Contexts

		internal void InitContexts()
		{
			Image img = NResourceHelper.BitmapFromResource(GetType(), "orang021.jpg", "Nevron.Examples.UI.WinForm.Resources.Backgrounds");
			InitBackgroundImageContext(img, Contexts.BackgroundImage1);
		}

		internal void InitBackgroundImageContext(Image img, Contexts contextID)
		{
			NCommandContext c1, c2;
			int i;

			//create first context
			c1 = CreateContext("Background Image", (int)contextID, MainForm.TestImages, -1, -1, null, false);
			c1.Properties.DropDownBehavior = DropDownBehavior.AlwaysDropDown;

			//create three examples for ImageDrawMode.Normal
			c2 = CreateContext("DrawMode Normal, No Column On Left", -1, MainForm.TestImages, -1, -1, null, false);
			c2.Properties.MenuOptions.BackgroundImageInfo.Image = img;
			c2.Properties.MenuOptions.ColumnOnLeft = false;
			for(i = 0; i < 15; i++)
				c2.Contexts.Add(CreateContext("Long text test item "+(i+1), -1, MainForm.TestImages, i, -1, new NShortcut(Keys.A, Keys.Control | Keys.Shift | Keys.Alt), false));

			c1.Contexts.Add(c2);

			c2 = CreateContext("DrawMode Normal, Column On Left", -1, MainForm.TestImages, -1, -1, null, false);
			c2.Properties.MenuOptions.BackgroundImageInfo.Image = img;
			for(i = 0; i < 11; i++)
				c2.Contexts.Add(CreateContext("Long text test item "+(i+1), -1, MainForm.TestImages, i, -1, new NShortcut(Keys.A, Keys.Control | Keys.Shift | Keys.Alt), false));
			c1.Contexts.Add(c2);

			c2 = CreateContext("DrawMode Normal, Column On Left, Alpha 0.5", -1, MainForm.TestImages, -1, -1, null, false);
			c2.Properties.MenuOptions.BackgroundImageInfo.Image = img;
			c2.Properties.MenuOptions.BackgroundImageInfo.Alpha = 0.5f;
			for(i = 0; i < 11; i++)
				c2.Contexts.Add(CreateContext("Long text test item "+(i+1), -1, MainForm.TestImages, i, -1, new NShortcut(Keys.A, Keys.Control | Keys.Shift | Keys.Alt), false));
			c1.Contexts.Add(c2);


			//create three examples for ImageDrawMode.Stretch
			c2 = CreateContext("DrawMode Stretch, No Column On Left", -1, MainForm.TestImages, -1, -1, null, true);
			c2.Properties.MenuOptions.BackgroundImageInfo.Image = img;
			c2.Properties.MenuOptions.BackgroundImageInfo.DrawMode = ImageDrawMode.Stretch;
			c2.Properties.MenuOptions.ColumnOnLeft = false;
			for(i = 0; i < 11; i++)
				c2.Contexts.Add(CreateContext("Long text test item "+(i+1), -1, MainForm.TestImages, i, -1, new NShortcut(Keys.A, Keys.Control | Keys.Shift | Keys.Alt), false));
			c1.Contexts.Add(c2);

			c2 = CreateContext("DrawMode Stretch, Column On Left", -1, MainForm.TestImages, -1, -1, null, false);
			c2.Properties.MenuOptions.BackgroundImageInfo.Image = img;
			c2.Properties.MenuOptions.BackgroundImageInfo.DrawMode = ImageDrawMode.Stretch;
			for(i = 0; i < 11; i++)
				c2.Contexts.Add(CreateContext("Long text test item "+(i+1), -1, MainForm.TestImages, i, -1, new NShortcut(Keys.A, Keys.Control | Keys.Shift | Keys.Alt), false));
			c1.Contexts.Add(c2);

			c2 = CreateContext("DrawMode Stretch, Column On Left, Alpha 0.3", -1, MainForm.TestImages, -1, -1, null, false);
			c2.Properties.MenuOptions.BackgroundImageInfo.Image = img;
			c2.Properties.MenuOptions.BackgroundImageInfo.DrawMode = ImageDrawMode.Stretch;
			c2.Properties.MenuOptions.BackgroundImageInfo.Alpha = 0.3f;
			for(i = 0; i < 11; i++)
				c2.Contexts.Add(CreateContext("Long text test item "+(i+1), -1, MainForm.TestImages, i, -1, new NShortcut(Keys.A, Keys.Control | Keys.Shift | Keys.Alt), false));
			c1.Contexts.Add(c2);

			//create three examples for ImageDrawMode.Tile
			c2 = CreateContext("DrawMode Tile, No Column On Left", -1, MainForm.TestImages, -1, -1, null, true);
			c2.Properties.MenuOptions.BackgroundImageInfo.Image = img;
			c2.Properties.MenuOptions.BackgroundImageInfo.DrawMode = ImageDrawMode.Tile;
			c2.Properties.MenuOptions.ColumnOnLeft = false;
			for(i = 0; i < 11; i++)
				c2.Contexts.Add(CreateContext("Long text test item "+(i+1), -1, MainForm.TestImages, i, -1, new NShortcut(Keys.A, Keys.Control | Keys.Shift | Keys.Alt), false));
			c1.Contexts.Add(c2);

			c2 = CreateContext("DrawMode Tile, Column On Left", -1, MainForm.TestImages, -1, -1, null, false);
			c2.Properties.MenuOptions.BackgroundImageInfo.Image = img;
			c2.Properties.MenuOptions.BackgroundImageInfo.DrawMode = ImageDrawMode.Tile;
			for(i = 0; i < 11; i++)
				c2.Contexts.Add(CreateContext("Long text test item "+(i+1), -1, MainForm.TestImages, i, -1, new NShortcut(Keys.A, Keys.Control | Keys.Shift | Keys.Alt), false));
			c1.Contexts.Add(c2);

			c2 = CreateContext("DrawMode Tile, Column On Left, Alpha 0.4", -1, MainForm.TestImages, -1, -1, null, false);
			c2.Properties.MenuOptions.BackgroundImageInfo.Image = img;
			c2.Properties.MenuOptions.BackgroundImageInfo.DrawMode = ImageDrawMode.Tile;
			c2.Properties.MenuOptions.BackgroundImageInfo.Alpha = 0.4f;
			for(i = 0; i < 11; i++)
				c2.Contexts.Add(CreateContext("Long text test item "+(i+1), -1, MainForm.TestImages, i, -1, new NShortcut(Keys.A, Keys.Control | Keys.Shift | Keys.Alt), false));
			c1.Contexts.Add(c2);

			c2 = CreateContext("&Load Image", (int)Contexts.LoadImage, null, -1, -1, null, true);
			c2.Executed += new CommandContextEventHandler(OnLoadImage);
			c1.Contexts.Add(c2);
		}

		internal NCommandContext CreateContext(string text, int id, ImageList images, int imageIndex, int rangeID, NShortcut sc, bool beginGroup)
		{
			NCommandContext c = new NCommandContext();
			c.RangeID = rangeID;
			if(id != -1)
			{
				c.Properties.ID = id;
				m_iContextID = id + 1;
			}
			else
				c.Properties.ID = m_iContextID;
			c.Properties.ImageList = images;
			c.Properties.ImageIndex = imageIndex;
			c.Properties.BeginGroup = beginGroup;

			c.Properties.Text = text;
			if(sc != null)
				c.Properties.Shortcut = sc;

			m_Manager.Contexts.Add(c);
			m_iContextID++;

			return c;
		}


		#endregion

		#region Toolbars

		internal void InitToolbars()
		{
			InitStandandardToolbar();
		}

		internal void InitStandandardToolbar()
		{
			NDockingToolbar tb = new NDockingToolbar();
			tb.DefaultRangeID = 0;
			tb.AllowReset = false;
			tb.Text = "Standard";
			tb.DefaultCommandStyle = CommandStyle.Text;

			tb.Commands.Add(Nevron.UI.WinForm.Controls.NCommand.FromContext(m_Manager.Contexts.ContextFromID((int)Contexts.BackgroundImage1)));

			Nevron.UI.WinForm.Controls.NCommand comm, comm1, comm2, comm3;

			comm = new Nevron.UI.WinForm.Controls.NCommand();
			//specify the custom menu type
			comm.Properties.Text = "Custom Region Menu";
			comm.Properties.DropDownBehavior = DropDownBehavior.AlwaysDropDown;
			tb.Commands.Add(comm);

			for(int i = 0; i < 10; i++)
			{
				comm1 = new Nevron.UI.WinForm.Controls.NCommand();
				comm1.Properties.Text = "Nested Command " + i.ToString();
				comm.Commands.Add(comm1);

				for(int j = 0; j < 10; j++)
				{
					comm2 = new Nevron.UI.WinForm.Controls.NCommand();
					comm2.Properties.Text = "Nested Command " + j.ToString();
					comm1.Commands.Add(comm2);

					for(int k = 0; k < 10; k++)
					{
						comm3 = new Nevron.UI.WinForm.Controls.NCommand();
						comm3.Properties.Text = "Nested Command " + k.ToString();
						comm2.Commands.Add(comm3);
					}
				}
			}

			m_Manager.Toolbars.Add(tb);
		}


		#endregion

		internal void SetImage(Image img)
		{
			NCommandContext c = m_Manager.Contexts.ContextFromID((int)Contexts.BackgroundImage1);
			foreach(NCommandContext c1 in c.Contexts)
			{
				Nevron.UI.WinForm.Controls.NCommand[] commands = c1.GetCommands();
				foreach(Nevron.UI.WinForm.Controls.NCommand comm in commands)
					comm.Properties.MenuOptions.BackgroundImageInfo.Image = img;
				
			}
		}

		internal string GetInitalDirectory()
		{
			string path = Application.StartupPath;
			int index;
			int count;

			string dirSeparator = new string(System.IO.Path.DirectorySeparatorChar, 1);

			index = path.LastIndexOf(dirSeparator);
			count = path.Length - index;

			path = path.Remove(index, count);

			index = path.LastIndexOf(dirSeparator);
			count = path.Length - index;
			path = path.Remove(index, count);

			return path + "\\Resources\\Backgrounds";
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// NCustomMenusUC
			// 
			this.Name = "NCustomMenusUC";

		}
		#endregion

		#region Event Handlers

		private void OnLoadImage(object sender, CommandContextEventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select Image:";
			ofd.Filter = NUIManager.AllImageFilesFilter;
			ofd.RestoreDirectory = true;

			ofd.InitialDirectory = "..\\..\\Resources\\Backgrounds";
			ofd.Multiselect = false;

			if(ofd.ShowDialog() != DialogResult.OK)
				return;

			Image img = Image.FromFile(ofd.FileName);
			SetImage(img);
		}


		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		internal NCommandBarsManager m_Manager;
		internal int m_iContextID;

		#endregion
	}

	/// <summary>
	/// Summary description for NCustomMenu.
	/// </summary>
	public class NCustomMenu : NMenuWindow
	{
		#region Constructor

		public NCustomMenu()
		{
		}


		#endregion

		#region Implementation

		protected override void ShowWindow(bool animate)
		{
			//apply new region first
			UpdateRegion();
			//do not allow shadow
			MenuOptions.Shadow = false;

			base.ShowWindow(animate);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			Rectangle client = ClientRectangle;
			client.Inflate(-1, -1);
			client.Width -= 1;
			client.Height -= 1;

			GraphicsPath path = GetRoundedRectanglePath(client, 16);
			Pen p = Renderer.Pen;
			p.Width = 4;
			p.Color = Palette.Border;

			Graphics g = e.Graphics;

			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.DrawPath(p, path);

			path.Dispose();

			p.Width = 1;
		}


		void UpdateRegion()
		{
			Rectangle client = ClientRectangle;
			GraphicsPath path = GetRoundedRectanglePath(client, 16);

			Region = new Region(path);
			path.Dispose();
		}

		internal static GraphicsPath GetRoundedRectanglePath(Rectangle client, int arcWidth)
		{
			GraphicsPath path = new GraphicsPath();

			int left = client.Left;
			int right = client.Right;
			int top = client.Top;
			int bottom = client.Bottom;

			int width = client.Width;
			int height = client.Height;

			int arcRectWidth = 2 * arcWidth;

			Rectangle arc;

			//topleft arc
			arc = new Rectangle(left, top, arcRectWidth, arcRectWidth);
			path.AddArc(arc, 180, 90);

			//top line
			path.AddLine(left + arcWidth, top, right - arcWidth, top);

			//topright arc
			arc = new Rectangle(right - arcRectWidth - 1, top, arcRectWidth + 1, arcRectWidth + 1);
			path.AddArc(arc, -90, 90);

			//right line
			path.AddLine(right, top + arcWidth, right, bottom - arcWidth);

			//bottomright arc
			arc = new Rectangle(right - arcRectWidth - 1, bottom - arcRectWidth - 1, arcRectWidth + 1, arcRectWidth + 1);
			path.AddArc(arc, 0, 90);

			//bottom line
			path.AddLine(right - arcWidth, bottom, left + arcWidth, bottom);

			//bottomleft arc
			arc = new Rectangle(left, bottom - arcRectWidth, arcRectWidth, arcRectWidth);
			path.AddArc(arc, 90, 90);

			//left line
			path.AddLine(left, bottom - arcWidth, left, top + arcWidth);

			path.CloseAllFigures();

			return path;
		}


		#endregion
	}
}
