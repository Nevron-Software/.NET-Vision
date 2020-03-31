using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.Maps;
using Nevron.Diagram.WebForm;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
    /// Summary description for NMapLegendRenderPage.
	/// </summary>
	public partial class NMapLegendRenderPage : NDrawingViewHostPage
	{
        public NMapLegendRenderPage()
		{
			this.DrawingView = new NDrawingView();
			this.DrawingView.ViewLayout = CanvasLayout.Stretch;

			NDrawingDocument document = this.DrawingView.Document;

			// init document
			document.BeginInit();
			CreateScene(document);
			document.EndInit();

			this.DrawingView.SizeToContent();
		}

		private void CreateScene(NDrawingDocument document)
		{
			document.BackgroundStyle.FrameStyle.Visible = false;
			document.BackgroundStyle.FillStyle = new NColorFillStyle(BackgroundColor);

            if (MapLegend != null)
            {
                NTableShape tableShape = MapLegend.Create(document.ActiveLayer);
				NTableColumn colorColumn = (NTableColumn)tableShape.Columns.GetChildAt(0);
				colorColumn.SizeMode = TableColumnSizeMode.Fixed;
				colorColumn.Width = 24;

				NTableColumn textColumn = (NTableColumn)tableShape.Columns.GetChildAt(1);
				textColumn.SizeMode = TableColumnSizeMode.Fixed;
				textColumn.Width = 180;
            }
		}

        public static NMapLegend MapLegend = null;
		public static Color BackgroundColor = Color.FromArgb(0xF4, 0xF2, 0xF4);
	}
}