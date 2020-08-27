Public Class frmMatriz
    Inherits System.Web.UI.Page

    Dim objEscola As Escola
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim idEscola As Integer = Request.QueryString("idEscola")
        CarregarInfo(idEscola)
        If Not Page.IsPostBack Then
            Formulario.CarregarComboTabela(drpEtapaEnsino, New EtapaEnsino, "Selecione...")
            Formulario.CarregarComboTabela(drpPeriodoLetivo, New PeriodoLetivo, "Selecione...")
            CarregarGrid()
        End If
    End Sub

    Private Sub CarregarInfo(idEscola As Integer)
        ViewState("idEscola") = idEscola
        objEscola = New Escola(idEscola)
        ' Dim objSituacao As New TipoSituacao(objEscola.CodigoSituacao)
        ' Dim objCidade As New Cidade(objEscola.CodigoCidade)
        txtNomeEscola.Text = objEscola.Nome
        ' txtMec.Text = objEscola.NrMec
        ' txtNome.Text = objEscola.Nome
        ' txtCidade.Text = objCidade.Cidade
        ' txtSituacao.Text = objSituacao.Descricao
    End Sub

    Private Sub CarregarGrid()
        Dim objMatriz As New Matriz()
        grdMatriz.DataSource = objMatriz.Pesquisar(ViewState("idEscola"), ViewState("OrderBy"))
        grdMatriz.DataBind()
        lblRegistros.Text = DirectCast(grdMatriz.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub

    Protected Sub grdMatriz_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdMatriz.RowDataBound
        Select Case e.Row.RowType

            Case DataControlRowType.DataRow

                Dim lnkExcluirMatriz As New LinkButton
                lnkExcluirMatriz = DirectCast(e.Row.Cells(3).FindControl("lnkExcluirMatriz"), LinkButton)
                lnkExcluirMatriz.CommandArgument = e.Row.RowIndex

                Dim lnkEditarMatriz As New LinkButton
                lnkEditarMatriz = DirectCast(e.Row.Cells(3).FindControl("lnkEditarMatriz"), LinkButton)
                lnkEditarMatriz.CommandArgument = e.Row.RowIndex

        End Select
    End Sub

    Protected Sub grdMatriz_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdMatriz.RowCommand
        If e.CommandName = "" Then
            Response.Redirect(Request.Url.ToString)
        ElseIf e.CommandName = "EDITAR" Then
            Editar(grdMatriz.DataKeys(e.CommandArgument).Item(0))
        ElseIf e.CommandName = "EXCLUIR" Then
            Excluir(grdMatriz.DataKeys(e.CommandArgument).Item(0))
        End If
    End Sub

    Private Sub Excluir(CodigoMatriz As Object)
        Dim objMatriz As New Matriz
        If objMatriz.Excluir(CodigoMatriz) > 0 Then
            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
        Else
            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
        End If
        objMatriz = Nothing
        CarregarGrid()
    End Sub

    Private Sub Editar(CodigoMatriz As Object)
        ViewState("CodigoMatriz") = CodigoMatriz
        Dim objMatriz As New Matriz(CodigoMatriz)
        drpEtapaEnsino.SelectedValue = objMatriz.IdEtapaEnsino
        drpPeriodoLetivo.SelectedValue = objMatriz.IdPeriodoLetivo
    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs)
        Salvar()
        LimparCampos()
        CarregarGrid()
    End Sub

    Private Sub LimparCampos()
        drpPeriodoLetivo.ClearSelection()
        drpEtapaEnsino.ClearSelection()
    End Sub

    Private Sub Salvar()
        Dim objMatriz As Matriz
        If (Not ViewState("CodigoMatriz") Is Nothing) Then
            objMatriz = New Matriz(ViewState("CodigoMatriz"))
        Else
            objMatriz = New Matriz
        End If
        Try
            With objMatriz
                .IdEtapaEnsino = drpEtapaEnsino.SelectedValue
                .IdPeriodoLetivo = drpPeriodoLetivo.SelectedValue
                .Salvar()
            End With
            MsgBox(eTipoMensagem.SALVAR_SUCESSO)
        Catch ex As Exception
            MsgBox(eTipoMensagem.SALVAR_ERRO)
        End Try

        ViewState("CodigoMatriz") = Nothing
        objMatriz = Nothing
    End Sub

    Protected Sub grdMatriz_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdMatriz.PageIndexChanging
        grdMatriz.PageIndex = e.NewPageIndex
        CarregarGrid()
    End Sub

    Protected Sub grdMatriz_Sorting(sender As Object, e As GridViewSortEventArgs) Handles grdMatriz.Sorting
        ViewState("OrderByDirection") = IIf(ViewState("OrderByDirection") = "asc", "desc", "asc")
        ViewState("OrderBy") = e.SortExpression & " " & ViewState("OrderByDirection")
        CarregarGrid()
    End Sub
End Class