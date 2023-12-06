<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdatePanel.aspx.cs" Inherits="pokeweb.UpdatePanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--El ScriptManager es requerido para usar el Update Panel--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <h1>Update Panel</h1>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="form-group">
                <div class="row">
                    <div class="col">
                        <asp:Label ID="lblNombreUP" runat="server" Text="texto"></asp:Label>
                    </div>
                    <div class="col">
                        <asp:TextBox ID="txtNombreUP" runat="server" AutoPostBack="true" OnTextChanged="txtNombre_TextChanged" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col">
                        <asp:Button ID="btnAceptarUP" runat="server" Text="Aceptar" OnClick="btnAceptarUP_Click" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <h1>Imagen con UpdatePanel</h1>
        <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="form-group">
                <div class="row">
                    <div class="col">
                        <asp:TextBox ID="txtUrlImagenUP" runat="server" AutoPostBack="true" OnTextChanged="txtUrlImagenUP_TextChanged" CssClass="form-control"></asp:TextBox>
                        
                    </div>
                    <div class="col">
                        <asp:Button ID="btnImagenUP" runat="server" Text="Cargar" OnClick="btnImagenUP_Click" />
                    </div>
                    <div class="col">
                        <img src="<% = urlImagen %>" alt="Alternate Text" width="50%" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>




</asp:Content>
