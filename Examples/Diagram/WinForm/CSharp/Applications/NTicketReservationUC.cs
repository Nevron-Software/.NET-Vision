using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.GraphicsCore;
using Nevron.UI;
using Nevron.UI.WinForm.Controls;

namespace Nevron.Examples.Diagram.WinForm
{
    public class NTicketReservationUC : NDiagramExampleUC
    {
        #region Constructors

        public NTicketReservationUC(NMainForm form)
            : base(form)
        {
        }

        #endregion

        #region NDiagramExampleUC Overrides

        protected override void LoadExample()
        {
            m_nFreeSeats = 0;
            m_nReservedSeats = 0;
            m_nRevenue = 0;

            view.BeginInit();
            view.GlobalVisibility.ShowPorts = false;
            view.HorizontalRuler.Visible = false;
            view.VerticalRuler.Visible = false;
            view.ScrollBars = ScrollBars.None;
            view.Grid.Visible = false;

            document.BeginInit();
            InitDocument();
            document.EndInit();

            view.EndInit();

            // Init controls
            NButton button = new NButton();
            button.Text = "Clear Reservations";
            button.SetBounds(5, 5, commonControlsPanel.Width - 10, 20);
            button.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button.Click += OnClearAllButtonClick;
            this.Controls.Add(button);
        }
        protected override void AttachToEvents()
        {
            base.AttachToEvents();

            document.EventSinkService.NodeMouseDown += OnNodeMouseDown;
        }
        protected override void DetachFromEvents()
        {
            base.DetachFromEvents();

            document.EventSinkService.NodeMouseDown -= OnNodeMouseDown;
        }

        #endregion

        #region Implementation

        private void InitDocument()
        {
            Bitmap bitmap = NResourceHelper.BitmapFromResource(GetType(), "Airplane.png", "Nevron.Examples.Diagram.WinForm.Resources");
            document.Width = bitmap.Width;
            document.Height = bitmap.Height + 62;

            document.BackgroundStyle.FillStyle = new NImageFillStyle(bitmap);

            // Create the style sheets
            NStyleSheet free = new NStyleSheet("free");
            NStyle.SetInteractivityStyle(free, new NInteractivityStyle(string.Empty, CursorType.Hand));
            NStyle.SetFillStyle(free, new NColorFillStyle(SEAT_COLOR));
            NStyle.SetStrokeStyle(free, new NStrokeStyle(1, Color.Black));
            NStyle.SetTextStyle(free, new NTextStyle(new Font(view.Font, FontStyle.Bold), Color.Blue));
            document.StyleSheets.AddChild(free);

            NStyleSheet reserved = new NStyleSheet("reserved");
            NHatchFillStyle hatch = new NHatchFillStyle(HatchStyle.LightUpwardDiagonal, Color.Red, SEAT_COLOR);
            hatch.TextureMappingStyle.MapMode = MapMode.RelativeToViewer;
            NStyle.SetFillStyle(reserved, hatch);
            NStyle.SetStrokeStyle(reserved, new NStrokeStyle(1, Color.Black));
            document.StyleSheets.AddChild(reserved);

            float x, y;
            float distance = DISTANCE;
            NShape shape;
            Point startPoint = LINE1_LEFT;
            m_Seats = new List<NShape>();

            // Draw the seats
            for (y = LINE1_LEFT.Y; y < 350; y += SEAT_SIZE.Height)
            {
                if (y > 260 && y < LINE2_LEFT.Y)
                {
                    y = LINE2_LEFT.Y;
                    startPoint = LINE2_LEFT;
                }

                if (y >= LINE2_LEFT.Y)
                    distance = 5.25f;

                for (x = startPoint.X; x < 970; x += SEAT_SIZE.Width + distance)
                {
                    if (x > 460 && x < LINE1_RIGHT.X)
                    {
                        x = LINE1_RIGHT.X;
                        distance = DISTANCE;
                    }

                    m_nFreeSeats++;
                    shape = new NRectangleShape(x, y, SEAT_SIZE.Width, SEAT_SIZE.Height);
                    shape.StyleSheetName = "free";
                    SetProtections(shape);
                    document.ActiveLayer.AddChild(shape);
                    m_Seats.Add(shape);
                }
            }

            // Free seats
            shape = new NRectangleShape(MARGINS, MARGINS, SEAT_SIZE.Width, SEAT_SIZE.Height);
            shape.StyleSheetName = "free";
            SetProtections(shape);
            document.ActiveLayer.AddChild(shape);

            CreateTextShape(ref m_FreeSeats);
            m_FreeSeats.Location = new NPointF(shape.Bounds.Right + MARGINS, shape.Bounds.Y);

            // Reserved seats
            shape = new NRectangleShape(MARGINS, 2 * MARGINS + SEAT_SIZE.Height, SEAT_SIZE.Width, SEAT_SIZE.Height);
            shape.StyleSheetName = "reserved";
            SetProtections(shape);
            document.ActiveLayer.AddChild(shape);

            CreateTextShape(ref m_ReservedSeats);
            m_ReservedSeats.Location = new NPointF(shape.Bounds.Right + MARGINS, shape.Bounds.Y);

            // Total revenue
            CreateTextShape(ref m_Revenue);
            m_Revenue.Location = new NPointF(shape.Bounds.Right + MARGINS, shape.Bounds.Bottom + MARGINS);
            m_Revenue.Style.TextStyle.FontStyle.Style = FontStyle.Bold;
            m_Revenue.Style.TextStyle.FillStyle = new NColorFillStyle(Color.MediumBlue);

            UpdateTexts();
        }
        private void SetProtections(NShape shape)
        {
            NAbilities protection = shape.Protection;
            protection.ResizeX = true;
            protection.ResizeY = true;
            protection.Rotate = true;
            protection.InplaceEdit = true;
            protection.TrackersEdit = true;
            protection.MoveX = true;
            protection.MoveY = true;
            protection.Select = true;
            shape.Protection = protection;
        }
        private void CreateTextShape(ref NShape shape)
        {
            shape = new NRectangleShape(0, 0, SEAT_SIZE.Width * 10, SEAT_SIZE.Height);
            NStyle.SetFillStyle(shape, new NColorFillStyle(Color.White));
            NStyle.SetStrokeStyle(shape, new NStrokeStyle(0, Color.White));
            NStyle.SetTextStyle(shape, new NTextStyle());
            shape.Style.TextStyle.StringFormatStyle = new NStringFormatStyle(StringFormatType.GenericTypographic, HorzAlign.Left, VertAlign.Center);
            SetProtections(shape);
            document.ActiveLayer.AddChild(shape);
        }
        private void UpdateTexts()
        {
            m_FreeSeats.Text = string.Format(FREE_SEATS, m_nFreeSeats);
            m_ReservedSeats.Text = string.Format(RESERVED_SEATS, m_nReservedSeats);
            m_Revenue.Text = string.Format(REVENUE, m_nRevenue);
        }

        #endregion

        #region Event Handlers

        private void OnNodeMouseDown(NNodeMouseEventArgs args)
        {
            NShape shape = args.Node as NShape;
            if (shape == null)
                return;

            if (shape.StyleSheetName == "reserved")
            {
                shape.Tag = false;
                shape.StyleSheetName = "free";
                m_nFreeSeats++;
                m_nReservedSeats--;
                m_nRevenue -= 50;
            }
            else
            {
                shape.StyleSheetName = "reserved";
                m_nFreeSeats--;
                m_nReservedSeats++;
                m_nRevenue += 50;
            }

            UpdateTexts();
            view.Refresh();
        }
        private void OnClearAllButtonClick(object sender, EventArgs e)
        {
            int i, seatCount = m_Seats.Count;
            for (i = 0; i < seatCount; i++)
            {
                NShape shape = m_Seats[i];
                if (shape.StyleSheetName == "reserved")
                {
                    shape.StyleSheetName = "free";
                }
            }

            m_nFreeSeats += m_nReservedSeats;
            m_nReservedSeats = 0;
            m_nRevenue = 0;
            UpdateTexts();
            view.Refresh();
        }

        #endregion

        #region Fields

        private NShape m_FreeSeats;
        private NShape m_ReservedSeats;
        private NShape m_Revenue;
        private List<NShape> m_Seats;

        private int m_nFreeSeats;
        private int m_nReservedSeats;
        private int m_nRevenue;

        #endregion

        #region Constants

        private const int MARGINS = 5;
        private const float DISTANCE = 4.25f;
        private static readonly Color SEAT_COLOR = Color.LemonChiffon;
        private static readonly Size SEAT_SIZE = new Size(21, 22);
        private static readonly Point LINE1_LEFT = new Point(299, 209);
        private static readonly Point LINE1_RIGHT = new Point(587, 209);
        private static readonly Point LINE2_LEFT = new Point(291, 296);
        private static readonly Point LINE2_RIGHT = new Point(587, 296);

        private const string FREE_SEATS = "Free seats: {0}";
        private const string RESERVED_SEATS = "Reserved seats: {0}";
        private const string REVENUE = "Total revenue: ${0}";

        #endregion
    }
}