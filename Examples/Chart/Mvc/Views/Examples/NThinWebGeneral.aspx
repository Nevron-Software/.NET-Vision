<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ExamplePage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ExampleContent" runat="server">
                    <%Html.RenderAction("Script", "NGeneralExample");%>
                    <%Html.RenderAction("Content", "NGeneralExample");%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ExampleDescription" runat="server">
    The example demonstrates general ThinWeb Chart control funcionality. 
</asp:Content>