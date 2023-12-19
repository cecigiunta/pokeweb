<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EjDropDown.aspx.cs" Inherits="pokeweb.EjDropDown" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>EJEMPLOS DROP DOWN</h1>


    <%--EJEMPLO DROPDOWN LIST, estático con clases de bootstrap--%>
    <asp:DropDownList runat="server" CssClass="btn btn-outline-dark dropdown-toggle">
        <asp:ListItem Text="Rojo" />
        <asp:ListItem Text="Azul" />
    </asp:DropDownList>

    <%--EJEMPLO DESDE BD, a diferencia del anterior, le elimino los items, le pongo un ID       
    --%>
    <h4>ejemplo desde BD</h4>
    <asp:DropDownList runat="server" ID="dropPokemon" CssClass="btn btn-outline-dark dropdown-toggle">
    </asp:DropDownList>

    <%--DROPDOWN ENLAZADOS: Si selecciono uno, que sobrecargue el resto--%>

    <div class="row">
        <asp:Label ID="labelTipo" runat="server" Text="Tipos"></asp:Label>
        <asp:DropDownList runat="server" ID="dropTipos" CssClass="btn btn-outline-dark dropdown-toggle"
            AutoPostBack="true" OnSelectedIndexChanged="dropTipos_SelectedIndexChanged">
        </asp:DropDownList>

        <asp:Label ID="labelDropPokemon" runat="server" Text="Pokemon"></asp:Label>
        <asp:DropDownList runat="server" ID="dropPokemonFiltrados" CssClass="btn btn-outline-dark dropdown-toggle">
        </asp:DropDownList>
    </div>


    <%--DROPDOWN PRESELECCIONADOS--%>
    <div class="row">
        <div class="col">
            <asp:Label runat="server" Text="ID" CssClass="form-label"></asp:Label>
        </div>
        <div class="col">
            <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col">
             <asp:Label runat="server" Text="Tipo Preseleccionado" CssClass="form-label"></asp:Label>
            <asp:DropDownList runat="server" ID="DropTipoPreseleccionado" CssClass="btn btn-outline-dark dropdown-toggle">
            </asp:DropDownList>
            <asp:Button ID="btnSeleccionar" runat="server" Text="Aceptar" OnClick="btnSeleccionar_Click" />
        </div>
    </div>
</asp:Content>
