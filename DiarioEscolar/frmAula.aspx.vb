Public Class frmAula
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CarregarInfo()
        If Not Page.IsPostBack Then
            CarregarGrid()
        End If
    End Sub

    Private Sub CarregarInfo()
        Dim idTurma As Integer
        Dim idEquipeDisciplina As Integer
        Try
            idEquipeDisciplina = Request.QueryString("idEquipeDisciplina")
            ViewState("idEquipeDisciplina") = idEquipeDisciplina
        Catch ex As Exception
            Response.Redirect("frmEscola.aspx")
        End Try

        Dim objEquipeDisciplina As New EquipeDisciplina(idEquipeDisciplina)

        If (objEquipeDisciplina.Codigo > 0) Then
            Dim objDisciplina As New Disciplina(objEquipeDisciplina.CodigoDisciplina())
            Dim objEquipeProfessor As New EquipeProfessor(objEquipeDisciplina.CodigoEquipeProfessor())

            Dim objTurma As New EquipeEscola(objEquipeProfessor.CodigoEquipeEscola())
            idTurma = objTurma.Codigo()
            ViewState("idTurma") = idTurma
            Dim objEscola As New Escola(objTurma.CodigoEscola())

            txtNomeEscola.Text = objEscola.Nome
            txtNomeDisciplina.Text = objDisciplina.Disciplina()
        Else
            Response.Redirect("frmEscola.aspx")
        End If
    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs)
        Salvar()
        LimparCampos()
        CarregarGrid()
    End Sub

    Private Sub CarregarGrid()
        Dim objAula As New Aula
        grdAulas.DataSource = objAula.Pesquisar(ViewState("idEquipeDisciplina"), ViewState("OrderBy"))
        grdAulas.DataBind()
        lblRegistros.Text = DirectCast(grdAulas.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub

    Private Sub LimparCampos()
        txtConteudo.Text = ""
        dtAula.Text = ""

    End Sub

    Private Sub Salvar()
        Dim objAula As Aula
        If (Not ViewState("CodigoAula") Is Nothing) Then
            objAula = New Aula(ViewState("CodigoAula"))
        Else
            objAula = New Aula
        End If

        With objAula
            .Conteudo = txtConteudo.Text
            .DataCadastro = dtAula.Text
            .IdEquipeDisciplina = ViewState("idEquipeDisciplina")
            .Salvar()
        End With
        MsgBox(eTipoMensagem.SALVAR_SUCESSO)


        ViewState("CodigoAula") = Nothing
        objAula = Nothing
    End Sub

    Protected Sub grdAulas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdAulas.PageIndexChanging
        grdAulas.PageIndex = e.NewPageIndex
        CarregarGrid()
    End Sub

    Protected Sub grdAulas_Sorting(sender As Object, e As GridViewSortEventArgs) Handles grdAulas.Sorting
        ViewState("OrderByDirection") = IIf(ViewState("OrderByDirection") = "asc", "desc", "asc")
        ViewState("OrderBy") = e.SortExpression & " " & ViewState("OrderByDirection")
        CarregarGrid()
    End Sub

    Protected Sub grdAulas_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdAulas.RowDataBound
        Select Case e.Row.RowType

            Case DataControlRowType.DataRow

                Dim lnkEditarAula As New LinkButton
                lnkEditarAula = DirectCast(e.Row.Cells(2).FindControl("lnkEditarAula"), LinkButton)
                lnkEditarAula.CommandArgument = e.Row.RowIndex

                Dim lnkFrequenciaAula As New LinkButton
                lnkFrequenciaAula = DirectCast(e.Row.Cells(2).FindControl("lnkFrequenciaAula"), LinkButton)
                lnkFrequenciaAula.CommandArgument = e.Row.RowIndex


        End Select
    End Sub

    Protected Sub grdAulas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdAulas.RowCommand
        If e.CommandName = "" Then
            Response.Redirect(Request.Url.ToString)
        ElseIf e.CommandName = "FREQUENCIA" Then
            Response.Redirect("frmAula.aspx?idEquipeDisciplina=" + grdAulas.DataKeys(e.CommandArgument).Item(0).ToString())
        ElseIf e.CommandName = "EDITAR" Then
            Editar(grdAulas.DataKeys(e.CommandArgument).Item(0))
        End If
    End Sub

    Private Sub Editar(CodigoAula As Object)
        ViewState("CodigoAula") = CodigoAula
        Dim objAula As New Aula(CodigoAula)
        txtConteudo.Text = objAula.Conteudo
        dtAula.Text = objAula.DataCadastro
        dtAula.Text = Convert.ToDateTime(objAula.DataCadastro).ToString("yyyy-MM-dd")
    End Sub
End Class