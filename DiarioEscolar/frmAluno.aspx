<%@ Page Title="Alunos" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmAluno.aspx.vb" Inherits="DiarioEscolar.frmAluno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0 text-dark">Formulário de Alunos</h1>
                </div>
                <!-- /.col -->
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="/">Home</a></li>
                        <li class="breadcrumb-item active">Alunos</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>

    <section class="content">
        <div class="container-fluid">
            <div class="card card-outline card-info card-default">
                <div class="card-body">
                    <div class="form-group row">
                        <div class="col-sm-6">
                            <label>Nome:</label>
                            <asp:TextBox runat="server" CssClass="form-control" required="required" type="text" ID="txtNome" name="Nome" placeholder="Ex.: João da Silva" MaxLength="100" />
                        </div>
                        <div class="col-sm-6">
                            <label>Nome Exibição:</label>
                            <asp:TextBox runat="server" CssClass="form-control" required="required" type="text" ID="txtNomeExibicao" name="NomeExibicao" placeholder="Ex.: João" MaxLength="50" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-6">
                            <label>Matrícula:</label>
                            <asp:TextBox runat="server" CssClass="form-control" required="required" type="text" ID="txtMatricula" name="Matricula" placeholder="Ex.: 123456789" MaxLength="20" />

                        </div>
                        <div class="col-sm-6">
                            <label>Email:</label>
                            <asp:TextBox runat="server" CssClass="form-control" required="required" type="text" ID="txtEmail" name="Email" placeholder="Ex.: joao@mail.com" MaxLength="250" />

                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3">
                            <label>Data de Nascimento:</label>
                            <asp:TextBox runat="server" type="date" required="required" class="form-control" ID="dtNascimento" name="dtNascimento" placeholder="Ex.: 01/01/2000" />
                        </div>
                        <div class="col-sm-3">
                            <label>Situação:</label>
                            <asp:TextBox runat="server" type="text" required="required" CssClass="form-control" ID="txtSituacao" name="Situacao" MaxLength="10"/>
                        </div>                        
                    </div>

                </div>
                <div class="card-footer">
                    <asp:Button runat="server" OnClick="btnSalvar_Click" ID="btnSalvar" CssClass="btn btn-lg btn-success float-right" Text="Salvar" />
                </div>
            </div>

             <div class="card card-outline card-info mt-5">
                <div class="card-body">

                    <asp:Label ID="lblRegistros" runat="server" CssClass="badge bg-cyan" />
                    <asp:GridView ID="grdAluno" runat="server" CssClass="table table-bordered" PagerStyle-HorizontalAlign="Right" AllowPaging="True" PageSize="2" AutoGenerateColumns="False" DataKeyNames="EE03_ID_ALUNO" AllowSorting="True">
                        <HeaderStyle CssClass="bg-white" ForeColor="Black" />
                        <Columns>
                            <asp:BoundField DataField="EE05_EQUIPE_ALUNO.EE05_ID_EQUIPE_ALUNO" SortExpression="EE05_EQUIPE_ALUNO.EE05_ID_EQUIPE_ALUNO" HeaderText="Código" />
                            <asp:BoundField DataField="EE03_NM_NOME" SortExpression="EE03_NM_NOME" HeaderText="Nome" />
                            <asp:BoundField DataField="EE03_DS_MATRICULA" SortExpression="EE03_DS_MATRICULA" HeaderText="Matrícula" />
                            <asp:TemplateField HeaderText="" SortExpression="" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEditarAluno" runat="server" class="btn btn-md btn-info" CommandName="EDITAR" ToolTip="Editar Aluno">
                                            <i runat="server" class="fa fa-pencil-alt"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkExcluirAluno" runat="server" class="btn btn-md btn-danger" CommandName="EXCLUIR" ToolTip="Excluir Aluno">
                                            <i runat="server" class="fa fa-trash-alt"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
