<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inserir Receitas.aspx.cs" Inherits="SiteReceitas.AcessoRestrito.Inserir_Receitas"  MaintainScrollPositionOnPostback="true" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent" >

     

    <div class="jumbotron text-center">
        <h1>Insere Receitas</h1>
        <p>Insere aqui as tuas receitas!</p>
    </div>

    <div class="container" >
        <div class="row">
            <div class="col-sm-4" style="top: 166px">
                <p>Nome Receita</p>
                <asp:TextBox ID="txtReceita" runat="server"></asp:TextBox>
                <br />
                <br />
                <br />
                <br />
                <p>Ingrediente</p>
                <asp:DropDownList ID="ddIngrediente" runat="server" AutoPostBack="true"></asp:DropDownList>
                <br />
                <br />
                <div class="form-group">
                    Confecção:<br />
                    <asp:TextBox ID="txtConfeccao" runat="server" Text='<%# Bind("confeccao") %>'
                        TextMode="MultiLine" Rows="4" Columns="50"></asp:TextBox><br />
                </div>

            </div>
            <div class="col-sm-4" style="top: 166px">
                <p>Categoria</p>
                <asp:DropDownList ID="ddCategoria" runat="server" AutoPostBack="true"></asp:DropDownList>
                <br />
                <br />
                <br />
                <br />
                <p>Quantidade</p>
                <asp:TextBox ID="txtQuantidade" runat="server"></asp:TextBox>
                <br />
                <br />
                <br />
                <br />
               <p>Duração</p>
                <asp:TextBox ID="txtDuracao" runat="server" TextMode="Time"></asp:TextBox>

            </div>
            <div class="col-sm-4" style="top: 166px">
                <p>Dificuldade</p>
                <asp:DropDownList ID="ddDificuldade" runat="server" AutoPostBack="true"></asp:DropDownList>
                <br />
                <br />
                <br />
                <br />
                <p>Unidade</p>
                <asp:DropDownList ID="ddUnidade" runat="server" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:Button ID="btnAdicionar" runat="server" Text="Adicionar Ingrediente" OnClick="btnAdicionar_Click" />
                <br />
                <br />

                <asp:Label id="lblListaIngredientes" runat="server" />
                
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
    <asp:Button ID="btnAdicionarReceita" runat="server" Text="Salvar Receita" OnClick="btnAdicionarReceita_Click1" />



    
    

</asp:Content>



