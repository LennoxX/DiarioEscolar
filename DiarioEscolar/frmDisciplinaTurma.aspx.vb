Public Class frmDisciplinaTurma
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CarregarInfo()
        If Not Page.IsPostBack Then
            CarregarComboDisciplina()
            CarregarComboProfessores()
            CarregarGrid()

        End If
    End Sub

    Private Sub CarregarGrid()
        Dim objEquipeDisciplina As New EquipeDisciplina()
        grdDisciplinas.DataSource = objEquipeDisciplina.Pesquisar(ViewState("idTurma"), ViewState("OrderBy"))
        grdDisciplinas.DataBind()
        lblRegistros.Text = DirectCast(grdDisciplinas.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub

    Private Sub CarregarComboProfessores()
        Dim objProfessor As New Professor
        Dim objEquipeProfessor As New EquipeProfessor

        With drpProfessor
            .DataValueField = "CODIGO"
            .DataTextField = "DESCRICAO"
            .DataSource = objEquipeProfessor.ObterTabela(ViewState("idTurma"))
            .DataBind()
            If TypeOf drpProfessor Is DropDownList Then
                .Items.Insert(0, New ListItem("Selecione...", 0))
            End If
        End With




    End Sub
    Private Sub CarregarComboDisciplina()
        Formulario.CarregarComboTabela(drpDisciplina, New Disciplina, "Selecione...")
        Dim objEquipeDisciplina As New EquipeDisciplina



        For Each row As DataRow In objEquipeDisciplina.ObterPorTurma(ViewState("idTurma")).Rows

            drpDisciplina.Items.Remove(drpDisciplina.Items.FindByValue(row("EE11_ID_DISCIPLINA")))
        Next

    End Sub

    Private Sub CarregarInfo()
        Dim idTurma As Integer
        Try
            idTurma = Request.QueryString("idTurma")
        Catch ex As Exception
            Response.Redirect("frmEscola.aspx")
        End Try

        Dim objTurma As New EquipeEscola(idTurma)
        Dim objEscola As New Escola(objTurma.CodigoEscola)

        If (objEscola.Codigo > 0 And objTurma.Codigo > 0) Then
            ViewState("idEscola") = objTurma.CodigoEscola
            ViewState("idTurma") = idTurma
            txtNomeEscola.Text = objEscola.Nome
        Else
            Response.Redirect("frmEscola.aspx")
        End If


    End Sub

    Protected Sub drpProfessor_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim objProfessor As Professor

        If (drpProfessor.SelectedIndex <> 0) Then
            Dim objEquipeProfessor As New EquipeProfessor(drpProfessor.SelectedValue)
            objProfessor = New Professor(objEquipeProfessor.CodigoProfessor)
            lblNomeAluno.Visible = True
            txtNomeAluno.Text = objProfessor.Nome
            txtNomeAluno.Visible = True

            lblMatricula.Visible = True
            txtMatricula.Text = objProfessor.Matricula
            txtMatricula.Visible = True

            lblDtNascimento.Visible = True
            dtNascimento.Visible = True
            dtNascimento.Text = objProfessor.Nascimento

        Else
            objProfessor = Nothing
            LimparCampos()

        End If
    End Sub

    Private Sub LimparCampos()
        drpProfessor.ClearSelection()
        lblNomeAluno.Visible = False
        txtNomeAluno.Text = ""
        txtNomeAluno.Visible = False

        lblMatricula.Visible = False
        txtMatricula.Text = ""
        txtMatricula.Visible = False

        lblDtNascimento.Visible = False
        dtNascimento.Visible = False
        dtNascimento.Text = ""

    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs)
        Salvar()
        LimparCampos()
        CarregarGrid()
        CarregarComboProfessores()
        CarregarComboDisciplina()
    End Sub

    Private Sub Salvar()
        Dim objEquipeDisciplina As New EquipeDisciplina

        Try
            With objEquipeDisciplina
                .CodigoEquipeProfessor = drpProfessor.SelectedValue
                .CodigoDisciplina = drpDisciplina.SelectedValue
                .Salvar()
            End With
            MsgBox(eTipoMensagem.SALVAR_SUCESSO)
        Catch ex As Exception
            MsgBox(eTipoMensagem.SALVAR_ERRO)
        End Try



        objEquipeDisciplina = Nothing
    End Sub

    Protected Sub grdDisciplinas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdDisciplinas.RowCommand
        If e.CommandName = "" Then
            Response.Redirect(Request.Url.ToString)
        ElseIf e.CommandName = "EXCLUIR" Then
            Excluir(grdDisciplinas.DataKeys(e.CommandArgument).Item(0))
        End If
    End Sub

    Private Sub Excluir(CodigoEquipeDisciplina As Object)
        Dim objEquipeDisciplina As New EquipeDisciplina
        If objEquipeDisciplina.Excluir(CodigoEquipeDisciplina) > 0 Then
            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
        Else
            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
        End If
        CarregarGrid()
        CarregarComboProfessores()
        CarregarComboDisciplina()
    End Sub

    Protected Sub grdDisciplinas_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdDisciplinas.RowDataBound
        Select Case e.Row.RowType

            Case DataControlRowType.DataRow

                Dim lnkExcluirDisciplinaTurma As New LinkButton
                lnkExcluirDisciplinaTurma = DirectCast(e.Row.Cells(2).FindControl("lnkExcluirDisciplinaTurma"), LinkButton)
                lnkExcluirDisciplinaTurma.CommandArgument = e.Row.RowIndex


        End Select
    End Sub

    Protected Sub grdDisciplinas_Sorting(sender As Object, e As GridViewSortEventArgs) Handles grdDisciplinas.Sorting
        ViewState("OrderByDirection") = IIf(ViewState("OrderByDirection") = "asc", "desc", "asc")
        ViewState("OrderBy") = e.SortExpression & " " & ViewState("OrderByDirection")
        CarregarGrid()
    End Sub

    Protected Sub grdDisciplinas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdDisciplinas.PageIndexChanging
        grdDisciplinas.PageIndex = e.NewPageIndex
        CarregarGrid()
    End Sub
End Class