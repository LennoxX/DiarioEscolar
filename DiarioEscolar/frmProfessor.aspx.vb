Public Class frmProfessor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CarregarGrid()
        End If
        Validacao.Outros(txtEmail, True, "Email",, Validacao.eFormato.EMAIL)
        JavaScript.ExibirConfirmacao(btnSalvar, eTipoConfirmacao.SALVAR)
    End Sub

    Private Sub Salvar()
        Dim objProfessor As Professor
        If (Not ViewState("CodigoProfessor") Is Nothing) Then
            objProfessor = New Professor(ViewState("CodigoProfessor"))
        Else
            objProfessor = New Professor
        End If
        Try
            With objProfessor
                .Nome = txtNome.Text
                .NomeExibicao = txtNomeExibicao.Text
                .Matricula = txtMatricula.Text
                .Email = txtEmail.Text
                .Nascimento = dtNascimento.Text
                .Situacao = txtSituacao.Text
                .Salvar()
            End With
            MsgBox(eTipoMensagem.SALVAR_SUCESSO)
        Catch ex As Exception
            MsgBox(eTipoMensagem.SALVAR_ERRO)
        End Try


    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs)
        Salvar()
        LimparCampos()
        CarregarGrid()
    End Sub

    Private Sub CarregarGrid()
        Dim objProfessor As New Professor
        grdProfessor.DataSource = objProfessor.Pesquisar(ViewState("OrderBy"))
        grdProfessor.DataBind()
        lblRegistros.Text = DirectCast(grdProfessor.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub

    Private Sub LimparCampos()
        txtNome.Text = ""
        txtNomeExibicao.Text = ""
        txtMatricula.Text = ""
        txtEmail.Text = ""
        dtNascimento.Text = ""
        txtSituacao.Text = ""
        ViewState("CodigoProfessor") = Nothing
    End Sub


    Protected Sub grdProfessoro_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdProfessor.RowDataBound
        Select Case e.Row.RowType

            Case DataControlRowType.DataRow

                Dim lnkExcluirProfessor As New LinkButton
                lnkExcluirProfessor = DirectCast(e.Row.Cells(3).FindControl("lnkExcluirProfessor"), LinkButton)
                lnkExcluirProfessor.CommandArgument = e.Row.RowIndex

                Dim lnkEditarProfessor As New LinkButton
                lnkEditarProfessor = DirectCast(e.Row.Cells(3).FindControl("lnkEditarProfessor"), LinkButton)
                lnkEditarProfessor.CommandArgument = e.Row.RowIndex

        End Select
    End Sub

    Protected Sub grdProfessor_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdProfessor.RowCommand
        If e.CommandName = "" Then
            Response.Redirect(Request.Url.ToString)
        ElseIf e.CommandName = "EDITAR" Then
            Editar(grdProfessor.DataKeys(e.CommandArgument).Item(0))
        ElseIf e.CommandName = "EXCLUIR" Then
            Excluir(grdProfessor.DataKeys(e.CommandArgument).Item(0))
        End If
    End Sub

    Private Sub Excluir(CodigoProfessor As Object)
        Dim objProfessor As New Professor
        If objProfessor.Excluir(CodigoProfessor) > 0 Then
            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
        Else
            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
        End If
        LimparCampos()
        CarregarGrid()
    End Sub

    Private Sub Editar(CodigoProfessor As Object)
        ViewState("CodigoProfessor") = CodigoProfessor
        Dim objProfessor As New Professor(CodigoProfessor)
        txtNome.Text = objProfessor.Nome
        txtNomeExibicao.Text = objProfessor.NomeExibicao
        txtMatricula.Text = objProfessor.Matricula
        txtEmail.Text = objProfessor.Email
        dtNascimento.Text = Convert.ToDateTime(objProfessor.Nascimento).ToString("yyyy-MM-dd")
        txtSituacao.Text = objProfessor.Situacao
    End Sub

    Protected Sub grdProfessor_Sorting(sender As Object, e As GridViewSortEventArgs) Handles grdProfessor.Sorting
        ViewState("OrderByDirection") = IIf(ViewState("OrderByDirection") = "asc", "desc", "asc")
        ViewState("OrderBy") = e.SortExpression & " " & ViewState("OrderByDirection")
        CarregarGrid()
    End Sub
End Class