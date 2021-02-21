<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="SiteReceitas.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Default.aspx">
</asp:Login>
    <br />

    Se ainda não está registado, registe-se <a href="RegistarUtilizador.aspx">aqui</a>



</asp:Content>
