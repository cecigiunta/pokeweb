<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormPokemon.aspx.cs" Inherits="pokeweb.FormPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--El ScriptManager es requerido para usar el Update Panel--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

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
                <asp:Button ID="btn_Aceptar" runat="server" CssClass="btn btn-primary" Text="Aceptar" OnClick="btn_Aceptar_Click" />
                <a href="PokemonLista.aspx">Cancelar</a>

                <%--DESACTIVAR POKE: AGREGO EL BOTON--%>
                <asp:Button ID="btnDesactivar" runat="server" CssClass="btn btn-outline-dark" Text="Desactivar" OnClick="btnDesactivar_Click" />

            </div>
        </div>

        <div class="col-6">
            <div class="mb-3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:Label ID="txtImagenUrl" runat="server" Text="Imagen"></asp:Label>
                            <asp:TextBox ID="txtUrlImagenUrl" runat="server" AutoPostBack="true" OnTextChanged="txtUrlImagenUrl_TextChanged" CssClass="form-control"></asp:TextBox>
                        </div>

                        <asp:Image ImageUrl="https://st3.depositphotos.com/6723736/12729/v/950/depositphotos_127297230-stock-illustration-download-sign-load-icon-load.jpg" ID="imgPokemon" runat="server" Width="60%" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

    </div>


    <%--ELIMINAR POKEMON--%>
    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>

                    <div class="mb-3">
                        <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" />
                    </div>

                    <% if (confirmaEliminacion){  %>
                    <div class="mb-3">
                        <asp:CheckBox ID="chkConfirmaEliminacion" Text="Confirmar eliminación" runat="server" />
                        <asp:Button ID="btnConfirmaEliminar" runat="server" CssClass="btn btn-outline-danger" Text="Confirmar" OnClick="btnConfirmaEliminar_Click" />
                    </div>

                    <% }   %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>



</asp:Content>
