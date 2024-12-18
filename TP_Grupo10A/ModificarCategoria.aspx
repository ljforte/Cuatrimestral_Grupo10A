﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="ModificarCategoria.aspx.cs" Inherits="TP_Grupo10A.ModificarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Gestion" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center" style="margin-top: 50px;">
            <div class="col-md-6 col-lg-4 text-center">
                <asp:Label ID="lblTitulo" runat="server" Text="Modificar Categoria " CssClass="h3"></asp:Label>
                <div>
                    <div class="row justify-content-center" style="margin-top: 25px;">
                        <asp:Label ID="lblCategoria" runat="server" Text=" " CssClass="form-label text-primary"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

        <div class="row justify-content-center" style="margin-top: 25px;">
            <div class="col-md-6 col-lg-4">
                <div class="form-group row mb-3">
                    <label for="lblNombre" class="col-sm-4 col-form-label">
                        <asp:Label ID="lblNombre" runat="server" Text="Nuevo Nombre: " CssClass="col-form-label"></asp:Label>
                    </label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtNombre" runat="server" Style="width: 850px;" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group row mb-3">
                    <label for="lblDescripcion" class="col-sm-4 col-form-label">
                        <asp:Label ID="lblDescripcion" runat="server" Text="Nueva Descripcion: " CssClass="col-form-label"></asp:Label>
                    </label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Style="width: 850px; height: 150px;" />
                    </div>
                </div>
                <div class="form-group row mb-3">
                    <label for="lblDato" class="col-sm-4 col-form-label">
                        <asp:Label ID="lblDato" runat="server" Text=" " CssClass="col-form-label"></asp:Label>
                    </label>
                </div>
                <div class="row justify-content-center" style="margin-top: 25px;">
                    <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-success" Text="Modificar" OnClick="btnModificar_Click" Style="margin-top: 25px;" />
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" OnClick="btnCancelar_Click1" Style="margin-top: 25px;" />

                </div>
            </div>
        </div>
    </div>
</asp:Content>
