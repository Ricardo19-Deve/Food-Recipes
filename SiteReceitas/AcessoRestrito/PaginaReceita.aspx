<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaReceita.aspx.cs" Inherits="SiteReceitas.AcessoRestrito.PaginaReceita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron text-center">
        <h1>Receitas Favoritas</h1>
        <p>Mostra as tuas receitas Favoritas!</p>
    </div>

    <asp:Button ID="btnAdicionarReceita" runat="server" Text="Mostrar Receitas" OnClick="btnAdicionarReceita_Click1" />

    <br />
    <br />
    <br />
    <br />

     <div class="panel-body">
        <div class="col-xs-10">
        </div>
                   
    <asp:BulletedList ID="lstReceitasFavoritas" runat="server" DisplayMode="LinkButton"  OnClick="lstReceitasFavoritas_Click"></asp:BulletedList>

    </div>


</asp:Content>
