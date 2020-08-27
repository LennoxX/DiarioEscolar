<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctrMenu.ascx.vb" Inherits="DiarioEscolar.ctrMenu" %>


<aside class="main-sidebar sidebar-dark-primary elevation-4">
    <a href="#" class="brand-link">
        <img src="Content/Imagens/governo.png" class="brand-image img-circle elevation-3" style="opacity: .8" />
        <span class="brand-text font-weight-light">Diário Escolar</span>
    </a>
    <div class="sidebar">
        <div class="user-panel mt-3 pb-3 mb-3 d-flex">
            <div class="image">
                <img src="Content/Imagens/avatar7.png" class="img-circle elevation-2" alt="User Image">
            </div>
            <div class="info">
                <a href="#" class="d-block">Usuário

                </a>
            </div>
        </div>
        <nav class="mt-2">
            <ul class="nav nav-pills nav-sidebar flex-column nav-legacy nav-child-indent" data-widget="treeview" role="menu"
                data-accordion="false">

                <!-- DEFINE ACTIVE NO ITEM PELA ROTA -->
                <li class="nav-item">
                    <a href="frmEscola.aspx" class="nav-link">
                        <i class="nav-icon fas fa-home"></i>
                        <p>
                            Escolas
                        </p>
                    </a>
                </li>
                 <li class="nav-item">
                    <a href="frmProfessor.aspx" class="nav-link">
                        <i class="nav-icon fas fa-users"></i>
                        <p>
                            Professores
                        </p>
                    </a>
                </li>
                  <li class="nav-item">
                    <a href="frmAluno.aspx" class="nav-link">
                        <i class="nav-icon fas fa-user-graduate"></i>
                        <p>
                            Alunos
                        </p>
                    </a>
                </li>
                  <li class="nav-item">
                    <a href="frmDisciplina.aspx" class="nav-link">
                        <i class="nav-icon fas fa-book"></i>
                        <p>
                            Disciplinas
                        </p>
                    </a>
                </li>
                

            </ul>
        </nav>
        <!-- /.sidebar-menu -->
    </div>
    <!-- /.sidebar -->
</aside>
