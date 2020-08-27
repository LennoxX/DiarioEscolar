Public Class frmEscola
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CarregarGrid()
            Formulario.CarregarComboTabela(drpCidade, New Cidade, "Selecione...",)
            Formulario.CarregarComboTabela(drpSituacao, New TipoSituacao, "Selecione...",)
        End If
    End Sub

    Private Sub CarregarGrid()
        Dim objEscola As New Escola()
        grdEscolas.DataSource = objEscola.Pesquisar(ViewState("OrderBy"))
        grdEscolas.DataBind()
        lblRegistros.Text = DirectCast(grdEscolas.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub

    Private Sub Salvar()
        Dim objEscola As Escola
        If (Not ViewState("CodigoEscola") Is Nothing) Then
            objEscola = New Escola(ViewState("CodigoEscola"))
        Else
            objEscola = New Escola
        End If
        Try
            With objEscola
                .CodigoCidade = drpCidade.SelectedValue
                .CodigoSituacao = drpSituacao.SelectedValue
                .Nome = txtNomeEscola.Text
                .NrMec = txtMec.Text
                .Salvar()
            End With
            MsgBox(eTipoMensagem.SALVAR_SUCESSO)
        Catch ex As Exception
            MsgBox(eTipoMensagem.SALVAR_ERRO)
        End Try

        ViewState("CodigoEscola") = Nothing
        objEscola = Nothing
    End Sub

    Private Sub LimparCampos()
        drpCidade.ClearSelection()
        drpSituacao.ClearSelection()
        txtMec.Text = ""
        txtNomeEscola.Text = ""
    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs)
        Salvar()
        LimparCampos()
        CarregarGrid()
    End Sub

    Protected Sub grdEscolas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdEscolas.PageIndexChanging
        grdEscolas.PageIndex = e.NewPageIndex
        CarregarGrid()
    End Sub

    Protected Sub grdEscolas_Sorting(sender As Object, e As GridViewSortEventArgs) Handles grdEscolas.Sorting
        ViewState("OrderByDirection") = IIf(ViewState("OrderByDirection") = "asc", "desc", "asc")
        ViewState("OrderBy") = e.SortExpression & " " & ViewState("OrderByDirection")
        CarregarGrid()
    End Sub

    Protected Sub grdEscolas_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdEscolas.RowDataBound
        Select Case e.Row.RowType

            Case DataControlRowType.DataRow

                Dim lnkExcluirEscola As New LinkButton
                lnkExcluirEscola = DirectCast(e.Row.Cells(3).FindControl("lnkExcluirEscola"), LinkButton)
                lnkExcluirEscola.CommandArgument = e.Row.RowIndex

                Dim lnkInfoEscola As New LinkButton
                lnkExcluirEscola = DirectCast(e.Row.Cells(3).FindControl("lnkInfoEscola"), LinkButton)
                lnkExcluirEscola.CommandArgument = e.Row.RowIndex

                Dim lnkEditarEscola As New LinkButton
                lnkEditarEscola = DirectCast(e.Row.Cells(3).FindControl("lnkEditarEscola"), LinkButton)
                lnkEditarEscola.CommandArgument = e.Row.RowIndex

        End Select
    End Sub

    Protected Sub grdEscolas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdEscolas.RowCommand
        If e.CommandName = "" Then
            Response.Redirect(Request.Url.ToString)
        ElseIf e.CommandName = "EDITAR" Then
            Editar(grdEscolas.DataKeys(e.CommandArgument).Item(0))
        ElseIf e.CommandName = "EXCLUIR" Then
            Excluir(grdEscolas.DataKeys(e.CommandArgument).Item(0))
        ElseIf e.CommandName = "INFO" Then
            Response.Redirect("infoEscola.aspx?idEscola=" + (grdEscolas.DataKeys(e.CommandArgument).Item(0)).ToString())
        End If
    End Sub

    Private Sub Editar(CodigoEscola As Integer)
        ViewState("CodigoEscola") = CodigoEscola
        Dim objEscola As New Escola(CodigoEscola)
        txtNomeEscola.Text = objEscola.Nome
        txtMec.Text = objEscola.NrMec
        drpCidade.SelectedValue = objEscola.CodigoCidade
        drpSituacao.SelectedValue = objEscola.CodigoSituacao
    End Sub

    Private Sub Excluir(ByVal CodigoEscola As Integer)
        Dim objEscola As New Escola
        If objEscola.Excluir(CodigoEscola) > 0 Then
            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
        Else
            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
        End If
        objEscola = Nothing
        CarregarGrid()
    End Sub
End Class