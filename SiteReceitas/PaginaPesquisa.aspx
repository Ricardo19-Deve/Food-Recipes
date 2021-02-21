<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaPesquisa.aspx.cs" Inherits="SiteReceitas.PaginaPesquisa" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




    <div class="jumbotron text-center">
        <h1>Pesquisa Receitas</h1>
        <p>Pesquisa as nossas receitas deliciosas!</p>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-sm-4" style="top: 166px">
                <p>Nome Receita</p>
                <asp:DropDownList ID="ddReceita" runat="server" AutoPostBack="true"></asp:DropDownList>
                <br />
                <br />
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" Text="Pesquisa Receita" OnClick="btnAdicionarReceita_Click1" />


            </div>
            <div class="col-sm-4" style="top: 166px">
                <p>Categoria</p>
                <asp:DropDownList ID="ddCategoria" runat="server" AutoPostBack="true"></asp:DropDownList>
                <br />
                <br />
                <br />
                <br />
                <asp:Button ID="btnAdicionarReceita" runat="server" Text="Pesquisa Receita por Categoria" OnClick="btnAdicionarReceita_Click2" />

            </div>
            <div class="col-sm-4" style="top: 166px">
                <p>Dificuldade</p>
                <asp:DropDownList ID="ddDificuldade" runat="server" AutoPostBack="true"></asp:DropDownList>
                <br />
                <br />
                <br />
                <br />
                <asp:Button ID="btnDificuldade" runat="server" Text="Pesquisa Receita Por Dificuldade" OnClick="btnAdicionarReceita_Click3" />
            </div>
        </div>
    </div>

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <div class="panel-body">
        <div class="col-xs-10">
        </div>
        <asp:BulletedList ID="lstReceitas" runat="server" DisplayMode="LinkButton" OnClick="lstReceitasPesquisa_Click"></asp:BulletedList>
       
    </div>


</asp:Content>
