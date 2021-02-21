<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApresentaReceita.aspx.cs" Inherits="SiteReceitas.teste" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblTeste" runat="server" />
    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="lblNomeReceita" runat="server" Text="Nome da Receita"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtNomeReceita" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblConfeccao" runat="server" Text="Confecção"></asp:Label>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TxtConfeccao" runat="server" Height="230px" Width="380px"></asp:TextBox>
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
    <asp:Label ID="lblDuracao" runat="server" Text="Duração"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtDuracao" runat="server" placeholder ="hora" Width="177px"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Label ID="lblCategoria" runat="server" Text="Categoria"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtCategoria" runat="server"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Label ID="lblDificuldade" runat="server" Text="Dificuldade"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtDificuldade" runat="server"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Label ID="lblLinhaIngrediente" runat="server" Text=""></asp:Label>

    <br />
    <br />
    <br />
    <br />
    <br />

</asp:Content>
