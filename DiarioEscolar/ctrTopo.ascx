<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrTopo.ascx.vb" Inherits="DiarioEscolar.WebUserControl1" %>

<nav class="main-header navbar navbar-expand navbar-white navbar-light">

    <ul class="navbar-nav">
        <li class="nav-item">
            <a class="nav-link" data-widget="pushmenu" href="#" role="button"><i class="fas fa-bars"></i></a>
        </li>
        <li class="nav-item d-none d-sm-inline-block">
            <a class="nav-link" href="/">Home</a>
        </li>
    </ul>

    <ul class="navbar-nav ml-auto">
        <li class="nav-item dropdown">
            <a class="nav-link" data-toggle="dropdown" href="#">
                <i class="far fa-user"></i>
            </a>
            <div class="dropdown-menu dropdown-menu-lg dropdown-menu-right">
                <span class="dropdown-header">Menu de Opções</span>
                <div class="dropdown-divider"></div>
                <a class="dropdown-item">
                    <i class="fas fa-cogs mr-2"></i>Configurações de Usuário
                </a>
                <div class="dropdown-divider"></div>
                <asp:LinkButton runat="server" ID="btnLogout" class="dropdown-item">
                            <i class="fas fa-sign-out-alt mr-2"></i>Sair
                </asp:LinkButton>
            </div>
        </li>
    </ul>
</nav>
