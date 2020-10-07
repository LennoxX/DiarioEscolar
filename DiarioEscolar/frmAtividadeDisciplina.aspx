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

    <section class="content">
        <div class="container-fluid">
            <div class="card card-outline card-info card-default">
                <div class="card-body">
                    <div class="form-group row">
                        <div class="col-sm-6">
                            <label>Tipo de Atividade</label>
                            <asp:DropDownList AutoPostBack="true" DataTextField="DESCRICAO" DataValueField="CODIGO" runat="server" required="required" ID="drpTipoAtividade" class="form-control" name="TipoAtividade">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-3">
                            <label>Data de Realização:</label>
                            <asp:TextBox runat="server" type="date" required="required" class="form-control" ID="dtRealizacao" name="dtRealizacao" placeholder="Ex.: 01/01/2000" />
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Button runat="server" ID="btnSalvar" OnClick="btnSalvar_Click" CssClass="btn btn-lg btn-success float-right" Text="Salvar" />
                </div>
            </div>
            <div class="card card-outline card-info mt-5">
                <div class="card-body">
                    <asp:Label ID="lblRegistros" runat="server" CssClass="badge bg-cyan" />
                    <asp:GridView ID="grdAtividades" runat="server" CssClass="table table-bordered" PagerStyle-HorizontalAlign="Right" AllowPaging="True" PageSize="2" AutoGenerateColumns="False" DataKeyNames="EE09_ID_ATIVIDADE" AllowSorting="True">
                        <HeaderStyle CssClass="bg-white" ForeColor="Black" />
                        <Columns>
                            <asp:BoundField DataField="EE10_DS_TIPO_ATIVIDADE" SortExpression="EE10_DS_TIPO_ATIVIDADE" HeaderText="Tipo de Atividade" />
                            <asp:BoundField DataField="EE09_DT_REALIZADA" SortExpression="EE09_DT_REALIZADA" HeaderText="Data"  DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:TemplateField HeaderText="" SortExpression="" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                     
                                     <asp:LinkButton ID="lnkNotasAtividade" runat="server" class="btn btn-md btn-warning" CommandName="NOTAS" ToolTip="Notas da Atividade">
                                           <i runat="server" class="fas fa-clipboard-check pr-1 pl-1"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkEditAtividade" runat="server" class="btn btn-md btn-info" CommandName="EDITAR" ToolTip="Editar Atividade">
                                            <i runat="server" class="fa fa-pencil-alt"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkExcluirAtividade" runat="server" class="btn btn-md btn-danger" CommandName="EXCLUIR" ToolTip="Excluir Atividade">
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
