<%@ Page Title="Período Letivo" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmPeriodoLetivo.aspx.vb" Inherits="DiarioEscolar.frmPeriodoLetivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0 text-dark">Períodos Letivos</h1>
                </div>
                <!-- /.col -->
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="/">Home</a></li>
                        <li class="breadcrumb-item"><a href="frmEscola.aspx">Escolas</a></li>
                        <li class="breadcrumb-item"><a href="infoEscola.aspx?idEscola=<%= ViewState("idEscola") %>">
                            <asp:Literal runat="server" ID="txtNomeEscola" EnableViewState="false"></asp:Literal></a></li>
                        <li class="breadcrumb-item active">Período Letivo</li>
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
                            <label>Período:</label>
                            <asp:TextBox runat="server" CssClass="form-control" required="required" type="text" ID="txtNomePeriodo" name="NomePeriodo" placeholder="Ex.: Escola A" />
                        </div>
                        <div class="col-sm-6">
                            <label>Descrição:</label>
                            <asp:TextBox runat="server" CssClass="form-control" required="required" type="text" ID="txtDescricaoPeriodo" name="DescricaoPeriodo" placeholder="Ex.: Nº do MEC" />
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
                    <asp:GridView ID="grdPeriodos" runat="server" CssClass="table table-bordered" PagerStyle-HorizontalAlign="Right" AllowPaging="True" PageSize="2" AutoGenerateColumns="False" DataKeyNames="EE00_ID_PERIODO_LETIVO" AllowSorting="True">
                        <HeaderStyle CssClass="bg-white" ForeColor="Black" />
                        <Columns>
                            <asp:BoundField DataField="EE00_ID_PERIODO_LETIVO" SortExpression="EE00_ID_PERIODO_LETIVO" HeaderText="Código" />
                            <asp:BoundField DataField="EE00_NM_PERIODO_LETIVO" SortExpression="EE00_NM_PERIODO_LETIVO" HeaderText="Nome" />
                            <asp:BoundField DataField="EE00_DS_PERIODO_LETIVO" SortExpression="EE00_DS_PERIODO_LETIVO" HeaderText="Descrição" />
                            <asp:TemplateField HeaderText="" SortExpression="" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                   
                                    <asp:LinkButton ID="lnkEditarPeriodo" runat="server" class="btn btn-md btn-info" CommandName="EDITAR" ToolTip="Editar Período">
                                            <i runat="server" class="fa fa-pencil-alt"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkExcluirPeriodo" runat="server" class="btn btn-md btn-danger" CommandName="EXCLUIR" ToolTip="Excluir Período">
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
