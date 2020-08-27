<%@ Page Title="Informações da Escola" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="infoEscola.aspx.vb" Inherits="DiarioEscolar.infoEscola" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0 text-dark"> Informações da Escola</h1>
                </div>
                <!-- /.col -->
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="/">Home</a></li>
                        <li class="breadcrumb-item"><a href="frmEscola.aspx">Escolas</a></li>
                        <li class="breadcrumb-item active"><asp:Literal runat="server" id="txtNomeEscola" EnableViewState="false"></asp:Literal></li>
                    </ol>
                </div>
            </div>
        </div>
    </div>

     <section class="content">
        <div class="container-fluid">
            <div class="card card-outline card-info card-default">
                <div class="card-header">
                    Informações da Escola
                </div>
                <div class="card-body">
                    <div class="form-group row">
                        <div class="col-sm-6">
                            <label>Nome:</label>
                            <asp:TextBox ReadOnly="true" runat="server" CssClass="form-control" required="required" type="text" ID="txtNome" name="NomeEscola"/>
                        </div>
                        <div class="col-sm-6">
                            <label>MEC:</label>
                            <asp:TextBox  ReadOnly="true"  runat="server" CssClass="form-control" required="required" type="text" ID="txtMec" name="Mec" placeholder="Ex.: Nº do MEC" MaxLength="250" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-6">
                            <label for="Cidade">Cidade:</label>
                            <asp:TextBox ReadOnly="true"  DataTextField="DESCRICAO" DataValueField="CODIGO" runat="server" required="required" ID="txtCidade" class="form-control" name="Cidade">
                            </asp:TextBox>
                        </div>

                        <div class="col-sm-6">
                            <label for="Situacao">Situacao:</label>
                            <asp:TextBox ReadOnly="true"  DataTextField="DESCRICAO" DataValueField="CODIGO" runat="server" required="required" ID="txtSituacao" class="form-control" name="Situacao">
                            </asp:TextBox>
                        </div>
                    </div>
                </div>                
            </div>

            <div class="row">
          <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-info">
              <div class="inner">
                <h3>Períodos Letivos</h3>

                <p><br /></p>
              </div>
              <div class="icon">
                <i class="fa fa-calendar-day"></i>
              </div>
              <asp:LinkButton runat="server" ID="btnPeriodoLetivo" OnClick="btnPeriodoLetivo_Click" class="small-box-footer">Mais Informações  <i class="fas fa-arrow-circle-right"></i></asp:LinkButton>
            </div>
          </div>
                 <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-danger">
              <div class="inner">
                <h3>Matrizes</h3>

                <p><br /></p>
              </div>
              <div class="icon">
                <i class="fas fa-scroll"></i>
              </div>
              <asp:LinkButton runat="server" ID="btnMatriz" OnClick="btnMatriz_Click" class="small-box-footer">Mais Informações  <i class="fas fa-arrow-circle-right"></i></asp:LinkButton>
            </div>
          </div>
          <!-- ./col -->
          <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-success">
              <div class="inner">
                <h3>Turmas</h3>

                <p><br /></p>
              </div>
              <div class="icon">
                <i class="fa fa-people-arrows"></i>
              </div>
              <asp:LinkButton runat="server" ID="btnTurma" OnClick="btnTurma_Click" class="small-box-footer">Mais Informações  <i class="fas fa-arrow-circle-right"></i></asp:LinkButton>
            </div>
          </div>
        </div>

        </div>

     </section>

</asp:Content>
