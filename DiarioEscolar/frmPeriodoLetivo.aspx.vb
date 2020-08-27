Public Class frmPeriodoLetivo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If (Request.QueryString("idEscola") Is Nothing) Then
                Response.Redirect("frmEscola.aspx")
            End If
            Try
                Dim idEscola As Integer = Request.QueryString("idEscola")
                CarregarInfo(idEscola)
            Catch ex As Exception
                Response.Redirect("frmEscola.aspx")
            End Try
            CarregarGrid()
        End If
    End Sub

    Private Sub CarregarInfo(idEscola As Integer)
        ViewState("idEscola") = idEscola
        Dim objEscola = New Escola(idEscola)
        txtNomeEscola.Text = objEscola.Nome
        Dim objSituacao As New TipoSituacao(objEscola.CodigoSituacao)
        Dim objCidade As New Cidade(objEscola.CodigoCidade)
    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs)
        Salvar()
        LimparCampos()
        CarregarGrid()
    End Sub

    Private Sub CarregarGrid()
        Dim objPeriodoLetivo As New PeriodoLetivo
        grdPeriodos.DataSource = objPeriodoLetivo.Pesquisar(ViewState("OrderBy"), Escola:=ViewState("idEscola"))
        grdPeriodos.DataBind()
        lblRegistros.Text = DirectCast(grdPeriodos.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub

    Private Sub LimparCampos()
        txtNomePeriodo.Text = ""
        txtDescricaoPeriodo.Text = ""
        ViewState("CodigoPeriodoLetivo") = Nothing
    End Sub

    Private Sub Salvar()
        Dim objPeriodoLetivo As PeriodoLetivo
        If (Not ViewState("CodigoPeriodoLetivo") Is Nothing) Then
            objPeriodoLetivo = New PeriodoLetivo(ViewState("CodigoPeriodoLetivo"))
        Else
            objPeriodoLetivo = New PeriodoLetivo
        End If
        Try
            With objPeriodoLetivo
                .Descricao = txtDescricaoPeriodo.Text
                .Nome = txtNomePeriodo.Text
                .CodigoEscola = ViewState("idEscola")
                .Salvar()
            End With
            MsgBox(eTipoMensagem.SALVAR_SUCESSO)
        Catch ex As Exception
            MsgBox(eTipoMensagem.SALVAR_ERRO)
        End Try
    End Sub

    Protected Sub grdPeriodos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdPeriodos.RowDataBound
        Select Case e.Row.RowType

            Case DataControlRowType.DataRow

                Dim lnkExcluirPeriodo As New LinkButton
                lnkExcluirPeriodo = DirectCast(e.Row.Cells(3).FindControl("lnkExcluirPeriodo"), LinkButton)
                lnkExcluirPeriodo.CommandArgument = e.Row.RowIndex


                Dim lnkEditarPeriodo As New LinkButton
                lnkEditarPeriodo = DirectCast(e.Row.Cells(3).FindControl("lnkEditarPeriodo"), LinkButton)
                lnkEditarPeriodo.CommandArgument = e.Row.RowIndex

        End Select
    End Sub

    Protected Sub grdPeriodos_Sorting(sender As Object, e As GridViewSortEventArgs) Handles grdPeriodos.Sorting
        ViewState("OrderByDirection") = IIf(ViewState("OrderByDirection") = "asc", "desc", "asc")
        ViewState("OrderBy") = e.SortExpression & " " & ViewState("OrderByDirection")
        CarregarGrid()
    End Sub

    Protected Sub grdPeriodos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdPeriodos.PageIndexChanging
        grdPeriodos.PageIndex = e.NewPageIndex
        CarregarGrid()
    End Sub

    Protected Sub grdPeriodos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdPeriodos.RowCommand
        If e.CommandName = "" Then
            Response.Redirect(Request.Url.ToString)
        ElseIf e.CommandName = "EDITAR" Then
            Editar(grdPeriodos.DataKeys(e.CommandArgument).Item(0))
        ElseIf e.CommandName = "EXCLUIR" Then
            Excluir(grdPeriodos.DataKeys(e.CommandArgument).Item(0))
        End If
    End Sub

    Private Sub Excluir(CodigoPeriodoLetivo As Object)
        Dim objPeriodoLetivo As New PeriodoLetivo
        If objPeriodoLetivo.Excluir(CodigoPeriodoLetivo) > 0 Then
            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
        Else
            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
        End If
        objPeriodoLetivo = Nothing
        CarregarGrid()
    End Sub

    Private Sub Editar(CodigoPeriodoLetivo As Object)
        ViewState("CodigoPeriodoLetivo") = CodigoPeriodoLetivo
        Dim objPeriodoLetivo As New PeriodoLetivo(CodigoPeriodoLetivo)
        txtNomePeriodo.Text = objPeriodoLetivo.Nome
        txtDescricaoPeriodo.Text = objPeriodoLetivo.Descricao
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        LimparCampos()
    End Sub
End Class