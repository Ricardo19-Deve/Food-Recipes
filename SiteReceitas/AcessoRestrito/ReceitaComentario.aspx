<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReceitaComentario.aspx.cs" Inherits="SiteReceitas.AcessoRestrito.ReceitaComentario" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="jumbotron text-center">
        <h1>Receitas</h1>
        <p>Avalia e Comenta aqui as tuas Receitas!</p>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-sm-4" style="top: 166px">
                <p>Receita</p>
                <asp:DropDownList ID="ddReceita" runat="server" AutoPostBack="true"></asp:DropDownList>
                <br />
                <br />
                <br />
                <br />
                <p>Como avalia esta receita?</p>
                <asp:DropDownList ID="ddClassificação" runat="server" AutoPostBack="true"></asp:DropDownList></p>
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnAdicionarAvaliacao_Click1" Width="133px" />
                <br />
                <br />
                <div class="form-group">
                    Comentário:<br />
                    <asp:TextBox ID="txtcomentario" runat="server" Text='<%# Bind("comentario") %>'
                        TextMode="MultiLine" Rows="4" Columns="50"></asp:TextBox><br />
                </div>

            </div>
            <div class="col-sm-4" style="top: 166px">
                <p>Quer guardar nas suas receitas favoritas?</p>
                <asp:Button ID="btnFavorito" runat="server" Text="Sim" OnClick="btnAdicionarFavorito_Click1" Width="133px" />
                <br />
                <br />
                <br />
                <br />
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
    <asp:Button ID="btnAdicionarReceita" runat="server" Text="Comenta Receita" OnClick="btnAdicionarReceita_Click1" />






</asp:Content>
