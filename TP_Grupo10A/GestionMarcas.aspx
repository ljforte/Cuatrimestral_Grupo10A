<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="GestionMarcas.aspx.cs" Inherits="TP_Grupo10A.GestionMarcas" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h3>MARCAS</h3>

    <div class="d-flex justify-content-center align-items-center" style="margin-top: 20px;">
        <div class="d-flex align-items-center">
            <asp:TextBox ID="txtNombre" runat="server" Placeholder="Nombre" CssClass="form-control mr-2" style="width: 300px; margin-right: 10px;"></asp:TextBox>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="Button1_Click" CssClass="btn btn-success" />
            <div>
                <asp:Label ID="lblDato" runat="server" Cssclass="mx-2" Text=""></asp:Label>
            </div>
        </div>
    </div>
    <br />
    <div style="display: flex; justify-content: center; align-items: center;">
        <div style="width: 50%;">
            <asp:GridView ID="dgvMarcas" runat="server" CssClass="table" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:ButtonField HeaderText="Modificar" Text="Modificar" ControlStyle-CssClass="btn btn-light" CommandName="btnModificar" />
                    <asp:ButtonField HeaderText="Eliminar" Text="Eliminar" ControlStyle-CssClass="btn btn-danger" CommandName="btnEliminar" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
