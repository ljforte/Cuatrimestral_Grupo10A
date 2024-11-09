<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="GestionCategoria.aspx.cs" Inherits="TP_Grupo10A.GestionCategoria" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Categorias</h3>

    <div class="d-flex flex-column align-items-center" style="margin-top: 20px;">
        <div class="form-group">
            <asp:TextBox ID="txtNombre" runat="server" Placeholder="Nombre" CssClass="form-control mb-2" Style="width: 300px;"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtDescripcion" runat="server" Placeholder="Descripcion" TextMode="MultiLine" CssClass="form-control mb-2" Style="width: 800px; height: 150px;"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn btn-success" />
        </div>
        <div>
            <asp:Label ID="lblDato" runat="server" CssClass="mx-2" Text=""></asp:Label>
        </div>
    </div>
    <br />
    <div style="display: flex; justify-content: center; align-items: center;">
        <div style="width: 50%;">
            <asp:GridView ID="dgvCategoria" runat="server" DataKeyNames="CategoriaID" CssClass="table" AutoGenerateColumns="false"
                OnSelectedIndexChanged="dgvCategoria_SelectedIndexChanged">

                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="CategoriaID" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />

                    <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Modificar" />
                    <asp:CommandField HeaderText="Eliminar" ShowSelectButton="true" SelectText="Eliminar" />

                </Columns>

            </asp:GridView>
        </div>
        <div>
            <asp:Button ID="btnConfirmarEliminacion" runat="server" OnClick="btnConfirmarEliminacion_Click"  CssClass="btn btn-danger" Text="Eliminar" visibility="false" />
        </div>

    </div>
</asp:Content>
