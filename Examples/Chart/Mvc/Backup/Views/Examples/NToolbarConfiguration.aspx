<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ExamplePage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ExampleContent" runat="server">
    <%Html.RenderAction("Script", "NToolbarConfigurationExample");%>
    <%Html.RenderAction("Content", "NToolbarConfigurationExample");%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ExampleDescription" runat="server">
    The example demonstrates the built-in toolbar functionality.
</asp:Content>