<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormPokemon.aspx.cs" Inherits="pokeweb.FormPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNumero" class="form-label">Numero</label>
                <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="ddTipo" class="form-label">Tipo</label>
                <asp:DropDownList ID="ddTipo" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="ddDebilidad" class="form-label">Debilidad</label>
                <asp:DropDownList ID="ddDebilidad" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary" Text="Aceptar" />
                <a href="PokemonLista.aspx">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>
