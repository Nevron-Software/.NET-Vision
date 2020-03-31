<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ExamplePage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ExampleContent" runat="server">
                    <%Html.RenderAction("Script", "NTrackballToolExample");%>
                    <%Html.RenderAction("Content", "NTrackballToolExample");%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ExampleDescription" runat="server">
    The NTrackballTool allows you to change the elevation and rotation of the currently active chart. Press the left mouse button over the chart and drag to change the elevation and rotation. 
</asp:Content>