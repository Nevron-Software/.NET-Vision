<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ExamplePage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ExampleContent" runat="server">
                    <%Html.RenderAction("Script", "NDataPanToolExample");%>
                    <%Html.RenderAction("Content", "NDataPanToolExample");%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ExampleDescription" runat="server">
    The NDataPanTool allows the user to drag the currently zoomed range of the chart. Press the left mouse button over the chart and drag to move the current range.
</asp:Content>