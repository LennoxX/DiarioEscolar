Public Class frmProfessorTurma
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CarregarInfo()
        If Not Page.IsPostBack Then
            CarregarComboProfessores()
            CarregarGrid()
        End If
        JavaScript.ExibirConfirmacao(btnSalvar, eTipoConfirmacao.SALVAR)
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

    Private Sub CarregarGrid()
        Dim objProfessor As New EquipeProfessor()
        grdProfessores.DataSource = objProfessor.Pesquisar(ViewState("idTurma"), ViewState("OrderBy"))
        grdProfessores.DataBind()
        lblRegistros.Text = DirectCast(grdProfessores.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub

    Private Sub CarregarComboProfessores()
        Dim objProfessor As New Professor
        Dim objEquipeProfessor As New EquipeProfessor

        With drpProfessor
            .DataValueField = "CODIGO"
            .DataTextField = "DESCRICAO"
            .DataSource = objProfessor.ObterTabela()
            .DataBind()

            If TypeOf drpProfessor Is DropDownList Then
                .Items.Insert(0, New ListItem("Selecione...", 0))
            End If
        End With

        For Each row As DataRow In objEquipeProfessor.Pesquisar(ViewState("idTurma")).Rows

            drpProfessor.Items.Remove(drpProfessor.Items.FindByValue(row("EE02_ID_PROFESSOR")))
        Next


    End Sub

    Protected Sub drpProfessor_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim objProfessor As Professor
        If (drpProfessor.SelectedIndex <> 0) Then
            objProfessor = New Professor(drpProfessor.SelectedValue)
            lblNomeAluno.Visible = True
            txtNomeAluno.Text = objProfessor.Nome
            txtNomeAluno.Visible = True

            lblMatricula.Visible = True
            txtMatricula.Text = objProfessor.Matricula
            txtMatricula.Visible = True

            lblDtNascimento.Visible = True
            dtNascimento.Visible = True
            dtNascimento.Text = objProfessor.Nascimento

            btnSalvar.Enabled = True

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

        btnSalvar.Enabled = False
    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs)
        Salvar()
        LimparCampos()
        CarregarGrid()
        CarregarComboProfessores()
    End Sub

    Private Sub Salvar()
        Dim objEquipeProfessor As New EquipeProfessor


        With objEquipeProfessor
            .CodigoProfessor = drpProfessor.SelectedValue
            .CodigoEquipeEscola = ViewState("idTurma")
            .Salvar()
        End With
        MsgBox(eTipoMensagem.SALVAR_SUCESSO)


        objEquipeProfessor = Nothing
    End Sub

    Protected Sub grdProfessores_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdProfessores.RowCommand
        If e.CommandName = "" Then
            Response.Redirect(Request.Url.ToString)
        ElseIf e.CommandName = "EXCLUIR" Then
            Excluir(grdProfessores.DataKeys(e.CommandArgument).Item(0))
        End If
    End Sub

    Private Sub Excluir(CodigoEquipeProfessor As Object)

        Dim objEquipeProfessor As New EquipeProfessor
        If objEquipeProfessor.Excluir(CodigoEquipeProfessor) > 0 Then
            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
        Else
            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
        End If
        CarregarGrid()
        CarregarComboProfessores()
    End Sub

    Protected Sub grdProfessores_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdProfessores.RowDataBound
        Select Case e.Row.RowType

            Case DataControlRowType.DataRow

                Dim lnkExcluirProfessor As New LinkButton
                lnkExcluirProfessor = DirectCast(e.Row.Cells(2).FindControl("lnkExcluirProfessor"), LinkButton)
                lnkExcluirProfessor.CommandArgument = e.Row.RowIndex


        End Select
    End Sub

    Protected Sub grdProfessores_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdProfessores.PageIndexChanging
        grdProfessores.PageIndex = e.NewPageIndex
        CarregarGrid()
    End Sub

    Protected Sub grdProfessores_Sorting(sender As Object, e As GridViewSortEventArgs) Handles grdProfessores.Sorting
        ViewState("OrderByDirection") = IIf(ViewState("OrderByDirection") = "asc", "desc", "asc")
        ViewState("OrderBy") = e.SortExpression & " " & ViewState("OrderByDirection")
        CarregarGrid()
    End Sub
End Class