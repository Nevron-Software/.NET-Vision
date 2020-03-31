<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ExamplePage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ExampleContent" runat="server">
        <%Html.RenderAction("Script", "NImageMapToolsExample");%>
        <%Html.RenderAction("Content", "NImageMapToolsExample");%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ExampleDescription" runat="server">
    The NTooltipTool, NCursorTool and NBrowserRedirectTool tools are used to achieve image map functionality. 
</asp:Content>