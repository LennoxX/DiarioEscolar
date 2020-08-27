<%@ Page Title="Alunos da Turma" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmAlunoTurma.aspx.vb" Inherits="DiarioEscolar.frmAlunoTurma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0 text-dark">Alunos da Turma</h1>
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
                            <label>Aluno</label>
                            <asp:DropDownList AutoPostBack="true" DataTextField="DESCRICAO" OnSelectedIndexChanged="drpAluno_SelectedIndexChanged" DataValueField="CODIGO" runat="server" required="required" ID="drpAluno" class="form-control" name="Matriz">
                            </asp:DropDownList>
                        </div>
                      
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3">
                           <label  visible="false" runat="server" id="lblMatricula">Matrícula:</label>
                            <asp:TextBox runat="server" Visible="false"  CssClass="form-control" type="text" ID="txtMatricula" name="Matricula" ReadOnly="true" />
                        </div>
                        <div class="col-sm-6">
                            <label  visible="false" runat="server" id="lblNomeAluno">Nome:</label>
                            <asp:TextBox runat="server" Visible="false"  CssClass="form-control" type="text" ID="txtNomeAluno" name="Nome" ReadOnly="true" />
                        </div>
                         <div class="col-sm-3">
                            <label visible="false" runat="server" id="lblDtNascimento">Nascimento:</label>
                            <asp:TextBox runat="server" Visible="false"  CssClass="form-control" type="text" ID="dtNascimento" name="Nascimento" ReadOnly="true" />
                        </div>
                    </div>

                </div>
                <div class="card-footer">
                    
                    <asp:Button runat="server" OnClick="btnSalvar_Click" ID="btnSalvar" CssClass="btn btn-lg btn-success float-right" Enabled="false" Text="Salvar" />
                </div>
            </div>

            <div class="card card-outline card-info mt-5">
                <div class="card-body">

                    <asp:Label ID="lblRegistros" runat="server" CssClass="badge bg-cyan" />
                    <asp:GridView ID="grdAlunos" runat="server" CssClass="table table-bordered" PagerStyle-HorizontalAlign="Right" AllowPaging="True" PageSize="2" AutoGenerateColumns="False" DataKeyNames="EE05_ID_EQUIPE_ALUNO" AllowSorting="True">
                        <HeaderStyle CssClass="bg-white" ForeColor="Black" />
                        <Columns>
                                                    
                            <asp:BoundField DataField="EE03_DS_MATRICULA" SortExpression="EE03_DS_MATRICULA" HeaderText="Matrícula" />
                            <asp:BoundField DataField="EE03_NM_NOME" SortExpression="EE03_NM_NOME" HeaderText="Nome" />
                            <asp:TemplateField HeaderText="" SortExpression="" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>                                                                       
                                    <asp:LinkButton ID="lnkExcluirAluno" runat="server" class="btn btn-md btn-danger" CommandName="EXCLUIR" ToolTip="Excluir Turma">
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
