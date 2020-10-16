<%@ Page Title="Frequência" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmFrequencia.aspx.vb" Inherits="DiarioEscolar.frmFrequencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0 text-dark">Frequência - 
                        <asp:Literal runat="server" ID="txtNomeDisciplina"></asp:Literal></h1>
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
                        <li class="breadcrumb-item active">Aulas</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
    <section class="content">
        <div class="container-fluid">
            <div class="card card-outline card-info card-default">
                <div class="card-body">

                    <asp:GridView ID="grdAluno" runat="server" CssClass="table table-bordered" DataKeyNames="EE05_ID_EQUIPE_ALUNO" AutoGenerateColumns="False">
                        <HeaderStyle CssClass="bg-white" ForeColor="Black" />
                        <Columns>

                            <asp:BoundField ItemStyle-CssClass="d-none" HeaderStyle-CssClass="d-none" DataField="EE05_ID_EQUIPE_ALUNO" HeaderText="ID_EQUIPE_ALUNO" />

                            <asp:BoundField DataField="EE03_NM_NOME" HeaderText="Nome" />


                            <asp:TemplateField HeaderText="Presença" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>

                                    <asp:DropDownList AutoPostBack="true" ID="drpStatus" class="form-control" runat="server">
                                        <asp:ListItem Text="Presente" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Ausente" Value="0"></asp:ListItem>

                                    </asp:DropDownList>

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>                   
                </div>
                <div class="card-footer">
                    <asp:Button runat="server" OnClick="btnSalvar_Click" ID="btnSalvar" CssClass="btn btn-lg btn-success float-right" Text="Salvar" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
