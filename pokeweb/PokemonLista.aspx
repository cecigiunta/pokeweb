﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PokemonLista.aspx.cs" Inherits="pokeweb.PokemonLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Pokemons</h1>
    <asp:GridView ID="dgvPokemons" runat="server" DataKeyNames="Id"
        CssClass="table" AutoGenerateColumns="false"
        OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged"
        OnPageIndexChanging="dgvPokemons_PageIndexChanging"
        AllowPaging="true" PageSize="5">

        <%--Al no mostrar el tipo y debilidad por defecto, tenemos que manejar las columnas manualmente--%>
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
            <asp:BoundField HeaderText="Debilidad" DataField="Debilidad.Descripcion" />

            <%--NUEVO--%>
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="EDITAR" />

        </Columns>
    </asp:GridView>

    <a href="FormPokemon.aspx" cssclass="btn btn-primary">Agregar</a>

</asp:Content>
