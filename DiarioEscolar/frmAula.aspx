<%@ Page Title="Aula" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmAula.aspx.vb" Inherits="DiarioEscolar.frmAula" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0 text-dark">Aulas da Disciplina -
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
                    <div class="form-group row">
                        <div class="col-sm-9">
                            <label>Conteúdo</label>
                            <asp:TextBox runat="server" required="true" ID="txtConteudo" class="form-control" name="Conteudo">
                              
                            </asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <label>Data da Aula:</label>
                            <asp:TextBox runat="server" type="date" required="required" class="form-control" ID="dtAula" name="dtAula" placeholder="Ex.: 01/01/2000" />
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
                    <asp:GridView ID="grdAulas" runat="server" CssClass="table table-bordered" PagerStyle-HorizontalAlign="Right" AllowPaging="True" PageSize="2" AutoGenerateColumns="False" DataKeyNames="EE08_ID_AULA" AllowSorting="True">
                        <HeaderStyle CssClass="bg-white" ForeColor="Black" />
                        <Columns>
                            <asp:BoundField DataField="EE08_DS_CONTEUDO" SortExpression="EE08_DS_CONTEUDO" HeaderText="Conteúdo" />
                            <asp:BoundField DataField="EE08_DT_CADASTRO" SortExpression="EE08_DT_CADASTRO" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:TemplateField HeaderText="" SortExpression="" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEditarAula" runat="server" class="btn btn-md btn-info" CommandName="EDITAR" ToolTip="Editar Aula">
                                            <i runat="server" class="fa fa-pencil-alt"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkFrequenciaAula" runat="server" class="btn btn-md btn-success" CommandName="FREQUENCIA" ToolTip="Frequência">
                                            <i runat="server" class="fa fa-list-alt"></i>
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
