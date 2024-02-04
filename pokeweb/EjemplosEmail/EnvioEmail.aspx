<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EnvioEmail.aspx.cs" Inherits="pokeweb.EjemplosEmail.EnvioEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <label class="form-control">Email</label>
                <asp:TextBox runat="server" id="txtEmail" cssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-control">Asunto</label>
                <asp:TextBox runat="server" id="txtAsunto" cssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-control">Mensaje</label>
                <asp:TextBox textMode="multiline" runat="server" id="txtMensaje" cssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button runat="server" Text="Aceptar" cssClass="btn btn-primary" ID="btnAceptar" OnClick="btnAceptar_Click" />

        </div>
        <div class="col"></div>

    </div>



</asp:Content>
