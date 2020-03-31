<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ExamplePage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ExampleContent" runat="server">
                    <%Html.RenderAction("Script", "NDataZoomToolExample");%>
                    <%Html.RenderAction("Content", "NDataZoomToolExample");%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ExampleDescription" runat="server">
    The NDataZoomTool allows the user to zoom in / out a range on the chart. Press the left mouse button over the chart and select a region to zoom in. The control will automatically show scrollbars (if set to visible) on all zoomed axes.
</asp:Content>