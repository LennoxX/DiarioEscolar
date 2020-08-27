Public Class frmAluno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CarregarGrid()
        End If
        Validacao.Outros(txtEmail, True, "Email",, Validacao.eFormato.EMAIL)

        JavaScript.ExibirConfirmacao(btnSalvar, eTipoConfirmacao.SALVAR)
    End Sub

    Private Sub CarregarGrid()
        Dim objAluno As New Aluno
        grdAluno.DataSource = objAluno.Pesquisar(ViewState("OrderBy"))
        grdAluno.DataBind()
        lblRegistros.Text = DirectCast(grdAluno.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs)
        Salvar()
        LimparCampos()
        CarregarGrid()
    End Sub

    Private Sub LimparCampos()
        txtNome.Text = ""
        txtNomeExibicao.Text = ""
        txtMatricula.Text = ""
        txtEmail.Text = ""
        dtNascimento.Text = ""
        txtSituacao.Text = ""
        ViewState("CodigoAluno") = Nothing
    End Sub

    Private Sub Salvar()
        Dim objAluno As Aluno
        If (Not ViewState("CodigoAluno") Is Nothing) Then
            objAluno = New Aluno(ViewState("CodigoAluno"))
        Else
            objAluno = New Aluno
        End If
        Try
            With objAluno
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

    Protected Sub grdAluno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdAluno.RowDataBound
        Select Case e.Row.RowType

            Case DataControlRowType.DataRow

                Dim lnkExluirAluno As New LinkButton
                lnkExluirAluno = DirectCast(e.Row.Cells(3).FindControl("lnkExcluirAluno"), LinkButton)
                lnkExluirAluno.CommandArgument = e.Row.RowIndex

                Dim lnkEditarAluno As New LinkButton
                lnkEditarAluno = DirectCast(e.Row.Cells(3).FindControl("lnkEditarAluno"), LinkButton)
                lnkEditarAluno.CommandArgument = e.Row.RowIndex

        End Select
    End Sub

    Protected Sub grdAluno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdAluno.RowCommand
        If e.CommandName = "" Then
            Response.Redirect(Request.Url.ToString)
        ElseIf e.CommandName = "EDITAR" Then
            Editar(grdAluno.DataKeys(e.CommandArgument).Item(0))
        ElseIf e.CommandName = "EXCLUIR" Then
            Excluir(grdAluno.DataKeys(e.CommandArgument).Item(0))
        End If
    End Sub

    Private Sub Excluir(CodigoAluno As Object)
        Dim objAluno As New Aluno
        If objAluno.Excluir(CodigoAluno) > 0 Then
            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
        Else
            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
        End If
        objAluno = Nothing
        CarregarGrid()
    End Sub

    Private Sub Editar(CodigoAluno As Object)
        ViewState("CodigoAluno") = CodigoAluno
        Dim objAluno As New Aluno(CodigoAluno)
        txtNome.Text = objAluno.Nome
        txtNomeExibicao.Text = objAluno.NomeExibicao
        txtMatricula.Text = objAluno.Matricula
        txtEmail.Text = objAluno.Email
        dtNascimento.Text = Convert.ToDateTime(objAluno.Nascimento).ToString("yyyy-MM-dd")
        txtSituacao.Text = objAluno.Situacao
    End Sub

    Protected Sub grdAluno_Sorting(sender As Object, e As GridViewSortEventArgs) Handles grdAluno.Sorting
        ViewState("OrderByDirection") = IIf(ViewState("OrderByDirection") = "asc", "desc", "asc")
        ViewState("OrderBy") = e.SortExpression & " " & ViewState("OrderByDirection")
        CarregarGrid()
    End Sub
End Class