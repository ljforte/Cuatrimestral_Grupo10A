<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="GestionMarcas.aspx.cs" Inherits="TP_Grupo10A.GestionMarcas" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>MARCAS</h3>
    <div class="d-flex justify-content-center align-items-center" style="margin-top: 20px;">
        <div class="d-flex align-items-center">
            <asp:TextBox ID="txtNombre" runat="server" Placeholder="Nombre" CssClass="form-control mr-2" Style="width: 300px; margin-right: 10px;"></asp:TextBox>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="Button1_Click" CssClass="btn btn-success" />
            <div>
                <asp:Label ID="lblDato" runat="server" CssClass="mx-2" Text=""></asp:Label>
            </div>
        </div>
    </div>
    <br />
    <div style="display: flex; justify-content: center; align-items: center;">
        <div style="width: 50%;">
            <asp:GridView ID="dgvMarcas" runat="server" CssClass="table" DataKeyNames="MarcaID" AutoGenerateColumns="false"
                OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged" OnRowDeleting="dgvMarcas_RowDeleting">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="MarcaID" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Modificar" />
                    <asp:CommandField HeaderText="Eliminar" ShowDeleteButton="true" DeleteText="Eliminar" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

