<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AreaPessoal.aspx.cs" Inherits="SiteReceitas.AcessoRestrito.AreaPessoal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:ChangePassword ID="ChangePassword1" runat="server"></asp:ChangePassword>
    <br />
    <br />
     
    <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:Button ID="btnAlterarEmail" runat="server" Text="Atualizar Email" OnClick="btnAlterarEmail_Click1" />
    <br />
    <br />
     
  


</asp:Content>
