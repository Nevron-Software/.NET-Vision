<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ExamplePage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ExampleContent" runat="server">
                    <%Html.RenderAction("Script", "NIndicatorDragToolExample");%>
                    <%Html.RenderAction("Content", "NIndicatorDragToolExample");%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ExampleDescription" runat="server">
    The NIndicatorDrag tool allows you to interactively change indicator values by pressing an indicator and then dragging the mouse.
</asp:Content>