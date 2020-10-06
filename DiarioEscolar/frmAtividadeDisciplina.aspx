<%@ Page Title="Atividades" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmAtividadeDisciplina.aspx.vb" Inherits="DiarioEscolar.frmAtividadeDisciplina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0 text-dark">Atividades</h1>
                </div>
                <!-- /.col -->
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="/">Home</a></li>
                        <li class="breadcrumb-item"><a href="frmEscola.aspx">Escolas</a></li>
                        <li class="breadcrumb-item"><a href="infoEscola.aspx?idEscola=<%= ViewState("idEscola") %>">
                            <asp:Literal runat="server" ID="txtNomeEscola" EnableViewState="false"></asp:Literal></a></li>
                        <li class="breadcrumb-item">
                            <a href="frmTurma.aspx?idEscola=<%= ViewState("idEscola") %>">Turmas</a>
                        </li>
                        <li class="breadcrumb-item">
                            <a href="frmDisciplinaTurma.aspx?idTurma=<%= ViewState("idTurma") %>">Disciplinas</a>
                        </li>
                        <li class="breadcrumb-item active">Atividades</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
