<%@ Page Title="Turmas" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmTurma.aspx.vb" Inherits="DiarioEscolar.frmTurma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0 text-dark">Formulário de Turmas</h1>
                </div>
                <!-- /.col -->
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="/">Home</a></li>
                        <li class="breadcrumb-item"><a href="frmEscola.aspx">Escolas</a></li>
                        <li class="breadcrumb-item"><a href="infoEscola.aspx?idEscola=<%= ViewState("idEscola") %>">
                            <asp:Literal runat="server" ID="txtNomeEscola" EnableViewState="false"></asp:Literal></a></li>
                        <li class="breadcrumb-item active">Turmas</li>
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
                            <label>Matriz (Período - Etapa):</label>
                            <asp:DropDownList DataTextField="DESCRICAO" DataValueField="CODIGO" runat="server" required="required" ID="drpMatriz" class="form-control" name="Matriz">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-6">
                            <label>Descrição:</label>
                            <asp:TextBox runat="server" CssClass="form-control" required="required" type="text" ID="txtDescricao" name="DescricaoTurma" placeholder="Ex.: Turma A do Primeiro Ano" />
                        </div>
                    </div>

                </div>
                <div class="card-footer">
                    <asp:Button type="reset" runat="server" ID="btnCancelar" CssClass="btn btn-lg btn-danger float-left" OnClick="btnCancelar_Click" Text="Cancelar" />
                    <asp:Button runat="server" OnClick="btnSalvar_Click" ID="btnSalvar" CssClass="btn btn-lg btn-success float-right" Text="Salvar" />
                </div>
            </div>

            <div class="card card-outline card-info mt-5">
                <div class="card-body">

                    <asp:Label ID="lblRegistros" runat="server" CssClass="badge bg-cyan" />
                    <asp:GridView ID="grdTurmas" runat="server" CssClass="table table-bordered" PagerStyle-HorizontalAlign="Right" AllowPaging="True" PageSize="2" AutoGenerateColumns="False" DataKeyNames="EE06_ID_EQUIPE_ESCOLA" AllowSorting="True">
                        <HeaderStyle CssClass="bg-white" ForeColor="Black" />
                        <Columns>
                            <asp:BoundField DataField="EE06_ID_EQUIPE_ESCOLA" SortExpression="EE06_ID_EQUIPE_ESCOLA" HeaderText="Código" />
                            <asp:BoundField DataField="EE06_DS_EQUIPE_ESCOLA" SortExpression="EE06_DS_EQUIPE_ESCOLA" HeaderText="Descrição" />
                            <asp:TemplateField HeaderText="" SortExpression="" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>

                                    <asp:LinkButton ID="lnkProfessoresTurma" runat="server" class="btn btn-md btn-info" CommandName="PROFESSORES" ToolTip="Editar Turma">
                                           <i runat="server" class="fa fa-chalkboard-teacher"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkAlunosTurma" runat="server" class="btn btn-md btn-secondary" CommandName="ALUNOS" ToolTip="Alunos da Turma">
                                            <i runat="server" class="fa fa-user-graduate"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkEditarTurma" runat="server" class="btn btn-md btn-info" CommandName="EDITAR" ToolTip="Editar Turma">
                                            <i runat="server" class="fa fa-pencil-alt"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkExcluirTurma" runat="server" class="btn btn-md btn-danger" CommandName="EXCLUIR" ToolTip="Excluir Turma">
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
