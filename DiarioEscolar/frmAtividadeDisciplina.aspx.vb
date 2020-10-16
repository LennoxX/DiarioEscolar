Public Class frmAtividadeDisciplina
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CarregarInfo()
        If Not Page.IsPostBack Then
            CarregarGrid()
            CarregarComboTipoAtividade()
        End If
        JavaScript.ExibirConfirmacao(btnSalvar, eTipoConfirmacao.SALVAR)
    End Sub

    Private Sub CarregarComboTipoAtividade()
        CarregarComboTabela(drpTipoAtividade, New TipoAtividade(), "Selecione...",)
    End Sub

    Private Sub CarregarGrid()
        Dim objAtividade As New Atividade()
        grdAtividades.DataSource = objAtividade.Pesquisar(ViewState("idEquipeDisciplina"), ViewState("OrderBy"))
        grdAtividades.DataBind()
        lblRegistros.Text = DirectCast(grdAtividades.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub

    Private Sub CarregarInfo()
        Dim idEquipeDisciplina As Integer
        Try
            idEquipeDisciplina = Request.QueryString("idEquipeDisciplina")
        Catch ex As Exception
            Response.Redirect("frmEscola.aspx")
        End Try

        Dim objEquipeDisciplina As New EquipeDisciplina(idEquipeDisciplina)
        Dim objEquipeProfessor As New EquipeProfessor(objEquipeDisciplina.CodigoEquipeProfessor)
        Dim objEquipeEscola As New EquipeEscola(objEquipeProfessor.CodigoEquipeEscola)
        Dim objEscola As New Escola(objEquipeEscola.CodigoEscola)

        If (objEscola.Codigo > 0 And objEquipeEscola.Codigo > 0) Then
            ViewState("idEscola") = objEquipeEscola.CodigoEscola
            ViewState("idTurma") = objEquipeEscola.Codigo
            ViewState("idEquipeDisciplina") = idEquipeDisciplina
            txtNomeEscola.Text = objEscola.Nome
        Else
            Response.Redirect("frmEscola.aspx")
        End If


    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs)
        Salvar()
        LimparCampos()
        CarregarGrid()

    End Sub

    Private Sub LimparCampos()
        ViewState("CodigoAtividade") = Nothing
        drpTipoAtividade.ClearSelection()
        dtRealizacao.Text = ""
    End Sub

    Private Sub Salvar()

        Dim objAtividade As Atividade

        If (Not ViewState("CodigoAtividade") Is Nothing) Then
            objAtividade = New Atividade(ViewState("CodigoAtividade"))
        Else
            objAtividade = New Atividade()
            objAtividade.DataCadastro = DateTime.Now
        End If


        With objAtividade
            .DataRealizada = dtRealizacao.Text
            .EquipeDisciplina = ViewState("idEquipeDisciplina")
            .TipoAtividade = drpTipoAtividade.SelectedValue
            .Salvar()
        End With
        MsgBox(eTipoMensagem.SALVAR_SUCESSO)


        objAtividade = Nothing
    End Sub

    Protected Sub grdAtividades_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdAtividades.RowDataBound
        Select Case e.Row.RowType

            Case DataControlRowType.DataRow

                Dim lnkEditAtividade As New LinkButton
                lnkEditAtividade = DirectCast(e.Row.Cells(2).FindControl("lnkEditAtividade"), LinkButton)
                lnkEditAtividade.CommandArgument = e.Row.RowIndex

                Dim lnkExcluirAtividade As New LinkButton
                lnkExcluirAtividade = DirectCast(e.Row.Cells(2).FindControl("lnkExcluirAtividade"), LinkButton)
                lnkExcluirAtividade.CommandArgument = e.Row.RowIndex

                Dim lnkNotasAtividade As New LinkButton
                lnkNotasAtividade = DirectCast(e.Row.Cells(2).FindControl("lnkNotasAtividade"), LinkButton)
                lnkNotasAtividade.CommandArgument = e.Row.RowIndex


        End Select
    End Sub

    Protected Sub grdAtividades_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdAtividades.RowCommand
        If e.CommandName = "" Then
            Response.Redirect(Request.Url.ToString)
        ElseIf e.CommandName = "EDITAR" Then
            Editar(grdAtividades.DataKeys(e.CommandArgument).Item(0))
        ElseIf e.CommandName = "EXCLUIR" Then
            Excluir(grdAtividades.DataKeys(e.CommandArgument).Item(0))
        ElseIf e.CommandName = "NOTAS" Then
            Response.Redirect("frmNotasAtividade.aspx?idAtividade=" + grdAtividades.DataKeys(e.CommandArgument).Item(0).ToString())
        End If
    End Sub

    Private Sub Excluir(CodigoAtividade As Object)
        Dim objAtividade As New Atividade
        If objAtividade.Excluir(CodigoAtividade) > 0 Then
            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
        Else
            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
        End If
        CarregarGrid()
    End Sub

    Private Sub Editar(CodigoAtividade As Object)
        ViewState("CodigoAtividade") = CodigoAtividade
        Dim objAtividade As New Atividade(CodigoAtividade)
        drpTipoAtividade.SelectedValue = objAtividade.Codigo
        dtRealizacao.Text = Convert.ToDateTime(objAtividade.DataRealizada).ToString("yyyy-MM-dd")

    End Sub
End Class