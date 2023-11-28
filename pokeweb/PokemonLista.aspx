<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PokemonLista.aspx.cs" Inherits="pokeweb.PokemonLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Pokemons</h1>
    <asp:GridView ID="dgvPokemons" runat="server" CssClass="table" AutoGenerateColumns="false">
        <%--Al no mostrar el tipo y debilidad por defecto, tenemos que manejar las columnas manualmente--%>

        <Columns>   
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" /> 
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" /> 
            <asp:BoundField HeaderText="Debilidad" DataField="Debilidad.Descripcion" />        
        </Columns>
    </asp:GridView>
</asp:Content>
