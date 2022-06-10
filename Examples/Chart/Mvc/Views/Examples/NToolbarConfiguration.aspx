<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ExamplePage.Master" Inherits="System.Web.Mvc.ViewPage" %>

@section ExampleContent {
    @{ Html.RenderAction("Script", "NToolbarConfigurationExample");}
    @{ Html.RenderAction("Content", "NToolbarConfigurationExample");}
}
@section ExampleDescription {
    The example demonstrates the built-in toolbar functionality.
}