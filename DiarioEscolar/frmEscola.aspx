<%@ Page Title="Escolas" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmEscola.aspx.vb" Inherits="DiarioEscolar.frmEscola" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0 text-dark">Formulário de Escolas</h1>
                </div>
                <!-- /.col -->
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="/">Home</a></li>
                        <li class="breadcrumb-item active">Escolas</li>
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
                            <asp:TextBox runat="server" CssClass="form-control" required="required" type="text" ID="txtNomeEscola" name="NomeEscola" placeholder="Ex.: Escola A" MaxLength="250" />
                        </div>
                        <div class="col-sm-6">
                            <label>MEC:</label>
                            <asp:TextBox runat="server" CssClass="form-control" required="required" type="text" ID="txtMec" name="Mec" placeholder="Ex.: Nº do MEC" MaxLength="250" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-6">
                            <label for="Cidade">Cidade:</label>
                            <asp:DropDownList DataTextField="DESCRICAO" DataValueField="CODIGO" runat="server" required="required" ID="drpCidade" class="form-control" name="Cidade">
                            </asp:DropDownList>
                        </div>

                        <div class="col-sm-6">
                            <label for="Situacao">Situacao:</label>
                            <asp:DropDownList DataTextField="DESCRICAO" DataValueField="CODIGO" runat="server" required="required" ID="drpSituacao" class="form-control" name="Situacao">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Button OnClick="btnSalvar_Click" runat="server" ID="btnSalvar" CssClass="btn btn-lg btn-success float-right" Text="Salvar" />
                </div>
            </div>

            <div class="card card-outline card-info mt-5">
                <div class="card-body">

                    <asp:Label ID="lblRegistros" runat="server" CssClass="badge bg-cyan" />
                    <asp:GridView ID="grdEscolas" runat="server" CssClass="table table-bordered" PagerStyle-HorizontalAlign="Right" AllowPaging="True" PageSize="2" AutoGenerateColumns="False" DataKeyNames="EE01_ID_ESCOLA" AllowSorting="True">
                        <HeaderStyle CssClass="bg-white" ForeColor="Black" />
                        <Columns>
                            <asp:BoundField DataField="EE01_ID_ESCOLA" SortExpression="EE01_ID_ESCOLA" HeaderText="Código" />
                            <asp:BoundField DataField="EE01_NM_NOME" SortExpression="EE01_NM_NOME" HeaderText="Nome" />
                            <asp:BoundField DataField="EE01_NR_MEC" SortExpression="EE01_NR_MEC" HeaderText="Mec" />
                            <asp:TemplateField HeaderText="" SortExpression="" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton  ID="lnkInfoEscola" runat="server" CommandName="INFO" CssClass="btn btn-md btn-primary" ToolTip="Informações da Escola">
                                        <i runat="server" class="fa fa-school"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkEditarEscola" runat="server" class="btn btn-md btn-info" CommandName="EDITAR" ToolTip="Editar Escola">
                                            <i runat="server" class="fa fa-pencil-alt"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkExcluirEscola" runat="server" class="btn btn-md btn-danger" CommandName="EXCLUIR" ToolTip="Excluir Escola">
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
