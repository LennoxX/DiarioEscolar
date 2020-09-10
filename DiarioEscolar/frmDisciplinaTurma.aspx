<%@ Page Title="Disciplinas da Turma" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmDisciplinaTurma.aspx.vb" Inherits="DiarioEscolar.frmDisciplinaTurma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0 text-dark">Disciplinas da Turma</h1>
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
                        <li class="breadcrumb-item active">Disciplinas</li>
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
                            <label>Disciplina</label>
                            <asp:DropDownList AutoPostBack="true" DataTextField="DESCRICAO" DataValueField="CODIGO" runat="server" required="true" ID="drpDisciplina" class="form-control" name="Matriz">
                              
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-6">
                            <label>Professor</label>
                            <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="drpProfessor_SelectedIndexChanged" DataTextField="DESCRICAO" DataValueField="CODIGO" runat="server" required="required" ID="drpProfessor" class="form-control" name="Matriz">
                            </asp:DropDownList>
                        </div>

                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3">
                            <label visible="false" runat="server" id="lblMatricula">Matrícula:</label>
                            <asp:TextBox runat="server" Visible="false" CssClass="form-control" type="text" ID="txtMatricula" name="Matricula" ReadOnly="true" />
                        </div>
                        <div class="col-sm-6">
                            <label visible="false" runat="server" id="lblNomeAluno">Nome:</label>
                            <asp:TextBox runat="server" Visible="false" CssClass="form-control" type="text" ID="txtNomeAluno" name="Nome" ReadOnly="true" />
                        </div>
                        <div class="col-sm-3">
                            <label visible="false" runat="server" id="lblDtNascimento">Nascimento:</label>
                            <asp:TextBox runat="server" Visible="false" CssClass="form-control" type="text" ID="dtNascimento" name="Nascimento" ReadOnly="true" />
                        </div>
                    </div>

                </div>
                <div class="card-footer">

                    <asp:Button runat="server" ID="btnSalvar" CssClass="btn btn-lg btn-success float-right" OnClick="btnSalvar_Click" Text="Salvar" />
                </div>
            </div>

            <div class="card card-outline card-info mt-5">
                <div class="card-body">

                    <asp:Label ID="lblRegistros" runat="server" CssClass="badge bg-cyan" />
                    <asp:GridView ID="grdDisciplinas" runat="server" CssClass="table table-bordered" PagerStyle-HorizontalAlign="Right" AllowPaging="True" PageSize="2" AutoGenerateColumns="False" DataKeyNames="EE13_ID_EQUIPE_DISCIPLINA" AllowSorting="True">
                        <HeaderStyle CssClass="bg-white" ForeColor="Black" />
                        <Columns>

                            <asp:BoundField DataField="EE11_DS_DISCIPLINA" SortExpression="EE11_DS_DISCIPLINA" HeaderText="Disciplina" />
                            <asp:BoundField DataField="EE02_NM_NOME" SortExpression="EE02_NM_NOME" HeaderText="Professor" />
                            <asp:TemplateField HeaderText="" SortExpression="" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                     <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-md btn-info" CommandName="EXCLUIR" ToolTip="Aulas">
                                            <i runat="server" class="fa fa-book-open"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkExcluirDisciplinaTurma" runat="server" class="btn btn-md btn-danger" CommandName="EXCLUIR" ToolTip="Excluir Aluno">
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
