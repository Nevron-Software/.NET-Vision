<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ExamplePage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ExampleContent" runat="server">
                    <%Html.RenderAction("Script", "NServerSideEventsToolExample");%>
                    <%Html.RenderAction("Content", "NServerSideEventsToolExample");%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ExampleDescription" runat="server">
    The example shows how to intercept server side events. 
</asp:Content>