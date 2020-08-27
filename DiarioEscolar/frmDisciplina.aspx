<%@ Page Title="Disciplinas" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmDisciplina.aspx.vb" Inherits="DiarioEscolar.frmDisciplina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0 text-dark">Formulário de Disciplinas</h1>
                </div>
                <!-- /.col -->
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="/">Home</a></li>
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
                        <div class="col-sm-4">
                            <label>Disciplina:</label>
                            <asp:TextBox runat="server" CssClass="form-control" required="required" type="text" ID="txtDisciplina" name="Disciplina" placeholder="Ex.: Matemática" MaxLength="100" />
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
                   <asp:GridView ID="grdDisciplina" runat="server" CssClass="table table-bordered" PagerStyle-HorizontalAlign="Right" AllowPaging="True" PageSize="2" AutoGenerateColumns="False" DataKeyNames="EE11_ID_DISCIPLINA" AllowSorting="True">
                        <HeaderStyle CssClass="bg-white" ForeColor="Black" />
                        <Columns>
                            <asp:BoundField DataField="EE11_ID_DISCIPLINA" SortExpression="EE11_ID_DISCIPLINA" HeaderText="Código" />
                            <asp:BoundField DataField="EE11_DS_DISCIPLINA" SortExpression="EE11_DS_DISCIPLINA" HeaderText="Nome" />
                           
                            <asp:TemplateField HeaderText="" SortExpression="" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEditarDisciplina" runat="server" class="btn btn-md btn-info" CommandName="EDITAR" ToolTip="Editar Disciplina">
                                            <i runat="server" class="fa fa-pencil-alt"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkExcluirDisciplina" runat="server" class="btn btn-md btn-danger" CommandName="EXCLUIR" ToolTip="Excluir Disciplina">
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
