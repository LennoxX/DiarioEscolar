<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.vb" Inherits="DiarioEscolar.Contact" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- CABEÇALHO E BREADCRUMB -->
    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0 text-dark"><%: Title %></h1>
                </div>
                <!-- /.col -->
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item active">Contato</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>

    <!-- CONTEÚDO DA PÁGINA -->

    <section class="content">
        <div class="container-fluid">
            <p>Your contact page.</p>

            <address>
                One Microsoft Way<br />
                Redmond, WA 98052-6399<br />
                <abbr title="Phone">P:</abbr>
                425.555.0100
            </address>

            <address>
                <strong>Support:</strong><a href="mailto:Support@example.com">Support@example.com</a><br />
                <strong>Marketing:</strong><a href="mailto:Marketing@example.com">Marketing@example.com</a>
            </address>
        </div>
    </section>




</asp:Content>