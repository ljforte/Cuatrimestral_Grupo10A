<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="GestionPedidos.aspx.cs" Inherits="TP_Grupo10A.GestionPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Gestion" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container d-flex flex-column justify-content-center align-items-center mt-5">
        <h2 class="mb-4 text-center">Pedidos</h2>

        <div class="row w-100 justify-content-center">
            <div class="col-md-8 col-lg-6 mb-3 d-flex">
                <div class="form-group mr-3 flex-grow-1">
                    <asp:TextBox ID="txtBuscar" CssClass="form-control" Placeholder="Ingrese número de pedido" runat="server"></asp:TextBox>
                </div>
                <div class="form-group mr-3 flex-grow-1">
                    <asp:DropDownList ID="ddlEstadosPedido" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnBuscarPorEstado" CssClass="btn btn-outline-primary ml-2" Text="Buscar" runat="server" />
                </div>
            </div>
        </div>

        <br />

        <div class="row w-100 justify-content-center">
            <div class="col-12">
                <asp:GridView ID="dgvPedidos" CssClass="table table-striped mx-auto" DataKeyNames="PedidoID" AutoGenerateColumns="false" runat="server"
                    OnSelectedIndexChanged="dgvPedidos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="PedidoID" />
                        <asp:BoundField HeaderText="Nombre" DataField="NombreCliente" />
                        <asp:BoundField HeaderText="Estado" DataField="Estado" />
                        <asp:CommandField HeaderText="Detalle" ShowSelectButton="true" SelectText="Ver" />
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>

</asp:Content>
