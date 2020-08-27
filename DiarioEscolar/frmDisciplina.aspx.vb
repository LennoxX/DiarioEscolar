Public Class frmDisciplina
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CarregarGrid()
        End If
    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs)
        Salvar()
        LimparCampos()
        CarregarGrid()
    End Sub

    Private Sub CarregarGrid()
        Dim objDisciplina As New Disciplina()
        grdDisciplina.DataSource = objDisciplina.Pesquisar(ViewState("OrderBy"))
        grdDisciplina.DataBind()
        lblRegistros.Text = DirectCast(grdDisciplina.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub

    Private Sub Salvar()
        Dim objDisciplina As Disciplina
        If (Not ViewState("CodigoDisciplina") Is Nothing) Then
            objDisciplina = New Disciplina(ViewState("CodigoDisciplina"))
        Else
            objDisciplina = New Disciplina
        End If
        Try
            With objDisciplina
                .Disciplina = txtDisciplina.Text
                .Salvar()
            End With
            MsgBox(eTipoMensagem.SALVAR_SUCESSO)
        Catch ex As Exception
            MsgBox(eTipoMensagem.SALVAR_ERRO)
        End Try

        ViewState("CodigoDisciplina") = Nothing
        objDisciplina = Nothing
    End Sub

    Private Sub LimparCampos()
        txtDisciplina.Text = ""
    End Sub

    Protected Sub grdDisciplina_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdDisciplina.RowCommand
        If e.CommandName = "" Then
            Response.Redirect(Request.Url.ToString)
        ElseIf e.CommandName = "EDITAR" Then
            Editar(grdDisciplina.DataKeys(e.CommandArgument).Item(0))
        ElseIf e.CommandName = "EXCLUIR" Then
            Excluir(grdDisciplina.DataKeys(e.CommandArgument).Item(0))
        End If
    End Sub

    Private Sub Excluir(CodigoDisciplina As Object)
        Dim objDisciplina As New Disciplina
        If objDisciplina.Excluir(CodigoDisciplina) > 0 Then
            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
        Else
            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
        End If
        objDisciplina = Nothing
        CarregarGrid()
    End Sub

    Private Sub Editar(CodigoDisciplina As Object)
        ViewState("CodigoDisciplina") = CodigoDisciplina
        Dim objDisciplina As New Disciplina(CodigoDisciplina)
        txtDisciplina.Text = objDisciplina.Disciplina

    End Sub

    Protected Sub grdDisciplina_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdDisciplina.RowDataBound
        Select Case e.Row.RowType

            Case DataControlRowType.DataRow

                Dim lnkExluirDisciplina As New LinkButton
                lnkExluirDisciplina = DirectCast(e.Row.Cells(2).FindControl("lnkExcluirDisciplina"), LinkButton)
                lnkExluirDisciplina.CommandArgument = e.Row.RowIndex

                Dim lnkEditarDisciplina As New LinkButton
                lnkEditarDisciplina = DirectCast(e.Row.Cells(2).FindControl("lnkEditarDisciplina"), LinkButton)
                lnkEditarDisciplina.CommandArgument = e.Row.RowIndex

        End Select
    End Sub

    Protected Sub grdDisciplina_Sorting(sender As Object, e As GridViewSortEventArgs) Handles grdDisciplina.Sorting
        ViewState("OrderByDirection") = IIf(ViewState("OrderByDirection") = "asc", "desc", "asc")
        ViewState("OrderBy") = e.SortExpression & " " & ViewState("OrderByDirection")
        CarregarGrid()
    End Sub
End Class