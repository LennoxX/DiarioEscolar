Public Class frmTurma
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CarregarInfo()
        If Not Page.IsPostBack Then
            CarregarCombo(drpMatriz, New Matriz, "Selecione...")
            CarregarGrid()
        End If
        JavaScript.ExibirConfirmacao(btnSalvar, eTipoConfirmacao.SALVAR)
    End Sub

    Public Sub CarregarCombo(ByRef Controle As Object, ByRef objClasse As Object,
                                   Optional ByVal PrimeiroItem As String = "", Optional ByVal CondicaoDeBusca As String = "")

        With Controle
            .DataValueField = "EE14_ID_MATRIZ"
            .DataSource = objClasse.Pesquisar(ViewState("idEscola"))
            .DataBind()
            If TypeOf Controle Is DropDownList Then
                .Items.Insert(0, New ListItem(PrimeiroItem, 0))
            End If
        End With

        'objClasse.Encerrar()
        objClasse = Nothing
    End Sub

    Private Sub CarregarGrid()
        Dim objEquipeEscola As New EquipeEscola()
        grdTurmas.DataSource = objEquipeEscola.Pesquisar(ViewState("idEscola"), ViewState("OrderBy"))
        grdTurmas.DataBind()
        lblRegistros.Text = DirectCast(grdTurmas.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub

    Private Sub CarregarInfo()

        Dim idEscola As Integer
        Try
            idEscola = Request.QueryString("idEscola")
            ViewState("idEscola") = idEscola
        Catch ex As Exception
            Response.Redirect("frmEscola.aspx")
        End Try

        Dim objEscola As New Escola(idEscola)

        If (objEscola.Codigo > 0) Then
            txtNomeEscola.Text = objEscola.Nome
        Else
            Response.Redirect("frmEscola.aspx")
        End If
    End Sub

    Private Sub Salvar()
        Dim objEquipeEscola As New EquipeEscola

        If (Not ViewState("CodigoEscola") Is Nothing) Then
            objEquipeEscola = New EquipeEscola(ViewState("CodigoTurma"))
        Else
            objEquipeEscola = New EquipeEscola
            objEquipeEscola.Data = DateTime.Now
        End If
        Try
            With objEquipeEscola
                .CodigoEscola = ViewState("idEscola")
                .Matriz = drpMatriz.SelectedValue
                .Descricao = txtDescricao.Text

                .Salvar()
            End With
            MsgBox(eTipoMensagem.SALVAR_SUCESSO)
        Catch ex As Exception
            MsgBox(eTipoMensagem.SALVAR_ERRO)
        End Try

        ViewState("CodigoTurma") = Nothing
        objEquipeEscola = Nothing

    End Sub

    Private Sub LimparCampos()
        drpMatriz.ClearSelection()
        txtDescricao.Text = ""
        ViewState("CodigoTurma") = Nothing

    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs)
        Salvar()
        LimparCampos()
        CarregarGrid()
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        LimparCampos()
    End Sub

    Protected Sub grdTurmas_Sorting(sender As Object, e As GridViewSortEventArgs) Handles grdTurmas.Sorting
        ViewState("OrderByDirection") = IIf(ViewState("OrderByDirection") = "asc", "desc", "asc")
        ViewState("OrderBy") = e.SortExpression & " " & ViewState("OrderByDirection")
        CarregarGrid()
    End Sub

    Protected Sub grdTurmas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdTurmas.PageIndexChanging
        grdTurmas.PageIndex = e.NewPageIndex
        CarregarGrid()
    End Sub

    Protected Sub grdTurmas_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdTurmas.RowDataBound
        Select Case e.Row.RowType

            Case DataControlRowType.DataRow

                Dim lnkDisciplinaTurma As New LinkButton
                lnkDisciplinaTurma = DirectCast(e.Row.Cells(2).FindControl("lnkDisciplinaTurma"), LinkButton)
                lnkDisciplinaTurma.CommandArgument = e.Row.RowIndex

                Dim lnkExcluirTurma As New LinkButton
                lnkExcluirTurma = DirectCast(e.Row.Cells(2).FindControl("lnkExcluirTurma"), LinkButton)
                lnkExcluirTurma.CommandArgument = e.Row.RowIndex

                Dim lnkEditarTurma As New LinkButton
                lnkEditarTurma = DirectCast(e.Row.Cells(2).FindControl("lnkEditarTurma"), LinkButton)
                lnkEditarTurma.CommandArgument = e.Row.RowIndex

                Dim lnkProfessorTurma As New LinkButton
                lnkProfessorTurma = DirectCast(e.Row.Cells(2).FindControl("lnkProfessoresTurma"), LinkButton)
                lnkProfessorTurma.CommandArgument = e.Row.RowIndex

                Dim lnkAlunoTurma As New LinkButton
                lnkAlunoTurma = DirectCast(e.Row.Cells(2).FindControl("lnkAlunosTurma"), LinkButton)
                lnkAlunoTurma.CommandArgument = e.Row.RowIndex



        End Select
    End Sub

    Protected Sub grdTurmas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdTurmas.RowCommand
        If e.CommandName = "" Then
            Response.Redirect(Request.Url.ToString)
        ElseIf e.CommandName = "DISCIPLINAS" Then
            Response.Redirect("frmDisciplinaTurma.aspx?idTurma=" + (grdTurmas.DataKeys(e.CommandArgument).Item(0)).ToString())
        ElseIf e.CommandName = "PROFESSORES" Then
            Response.Redirect("frmProfessorTurma.aspx?idTurma=" + (grdTurmas.DataKeys(e.CommandArgument).Item(0)).ToString())
        ElseIf e.CommandName = "ALUNOS" Then
            Response.Redirect("frmAlunoTurma.aspx?idTurma=" + (grdTurmas.DataKeys(e.CommandArgument).Item(0)).ToString())
        ElseIf e.CommandName = "EDITAR" Then
            Editar(grdTurmas.DataKeys(e.CommandArgument).Item(0))
        ElseIf e.CommandName = "EXCLUIR" Then
            Excluir(grdTurmas.DataKeys(e.CommandArgument).Item(0))
        End If
    End Sub

    Private Sub Excluir(CodigoTurma As Object)
        Dim objTurma As New EquipeEscola
        If objTurma.Excluir(CodigoTurma) > 0 Then
            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
        Else
            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
        End If
        CarregarGrid()
    End Sub

    Private Sub Editar(CodigoTurma As Object)
        ViewState("CodigoTurma") = CodigoTurma
        Dim objTurma As New EquipeEscola(CodigoTurma)
        drpMatriz.SelectedValue = objTurma.Matriz
        txtDescricao.Text = objTurma.Descricao
    End Sub
End Class