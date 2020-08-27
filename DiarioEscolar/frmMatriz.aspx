<%@ Page Title="Matriz" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmMatriz.aspx.vb" Inherits="DiarioEscolar.frmMatriz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0 text-dark">Matriz</h1>
                </div>
                <!-- /.col -->
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="/">Home</a></li>
                        <li class="breadcrumb-item"><a href="frmEscola.aspx">Escolas</a></li>
                        <li class="breadcrumb-item"><a href="infoEscola.aspx?idEscola=<%= ViewState("idEscola") %>">
                            <asp:Literal runat="server" ID="txtNomeEscola" EnableViewState="false"></asp:Literal></a></li>
                        <li class="breadcrumb-item active">Matriz</li>
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
                        <div class="col-sm-4">
                            <label>Etapa Ensino:</label>
                            <asp:DropDownList DataTextField="DESCRICAO" DataValueField="CODIGO" runat="server" required="required" ID="drpEtapaEnsino" class="form-control" name="Cidade">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4">
                            <label>Período Letivo:</label>
                            <asp:DropDownList DataTextField="DESCRICAO" DataValueField="CODIGO" runat="server" required="required" ID="drpPeriodoLetivo" class="form-control" name="Cidade">
                            </asp:DropDownList>
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
                <asp:GridView ID="grdMatriz" runat="server" CssClass="table table-bordered" PagerStyle-HorizontalAlign="Right" AllowPaging="True" PageSize="2" AutoGenerateColumns="False" DataKeyNames="EE14_ID_MATRIZ" AllowSorting="True">
                    <HeaderStyle CssClass="bg-white" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="EE14_ID_MATRIZ" SortExpression="EE14_ID_MATRIZ" HeaderText="Código" />
                        <asp:BoundField DataField="EE16_DS_ETAPA_ENSINO" SortExpression="EE16_DS_ETAPA_ENSINO" HeaderText="Etapa Ensino" />
                        <asp:BoundField DataField="EE00_NM_PERIODO_LETIVO" SortExpression="EE00_NM_PERIODO_LETIVO" HeaderText="Período Letivo" />

                        <asp:TemplateField HeaderText="" SortExpression="" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditarMatriz" runat="server" class="btn btn-md btn-info" CommandName="EDITAR" ToolTip="Editar Disciplina">
                                            <i runat="server" class="fa fa-pencil-alt"></i>
                                </asp:LinkButton>
                                <asp:LinkButton ID="lnkExcluirMatriz" runat="server" class="btn btn-md btn-danger" CommandName="EXCLUIR" ToolTip="Excluir Disciplina">
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
