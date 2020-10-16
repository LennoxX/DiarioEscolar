Public Class frmAlunoTurma
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CarregarInfo()
        If Not Page.IsPostBack Then
            CarregarComboAlunos()
            CarregarGrid()

        End If
        JavaScript.ExibirConfirmacao(btnSalvar, eTipoConfirmacao.SALVAR)
    End Sub

    Private Sub CarregarGrid()
        Dim objAluno As New EquipeAluno()
        grdAlunos.DataSource = objAluno.Pesquisar(ViewState("idTurma"), ViewState("OrderBy"))
        grdAlunos.DataBind()
        lblRegistros.Text = DirectCast(grdAlunos.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub

    Private Sub CarregarComboAlunos()
        Dim objAluno As New Aluno
        Dim objEquipeAluno As New EquipeAluno

        With drpAluno
            .DataValueField = "CODIGO"
            .DataTextField = "DESCRICAO"
            .DataSource = objAluno.ObterTabela()
            .DataBind()

            If TypeOf drpAluno Is DropDownList Then
                .Items.Insert(0, New ListItem("Selecione...", 0))
            End If
        End With

        For Each row As DataRow In objEquipeAluno.Pesquisar(ViewState("idTurma")).Rows

            drpAluno.Items.Remove(drpAluno.Items.FindByValue(row("EE03_ID_ALUNO")))
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

    Protected Sub drpAluno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpAluno.SelectedIndexChanged
        Dim objAluno As Aluno
        If (drpAluno.SelectedIndex <> 0) Then
            objAluno = New Aluno(drpAluno.SelectedValue)
            lblNomeAluno.Visible = True
            txtNomeAluno.Text = objAluno.Nome
            txtNomeAluno.Visible = True

            lblMatricula.Visible = True
            txtMatricula.Text = objAluno.Matricula
            txtMatricula.Visible = True

            lblDtNascimento.Visible = True
            dtNascimento.Visible = True
            dtNascimento.Text = objAluno.Nascimento

            btnSalvar.Enabled = True

        Else
            objAluno = Nothing
            LimparCampos()

        End If
    End Sub

    Protected Sub grdAlunos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdAlunos.RowCommand
        If e.CommandName = "" Then
            Response.Redirect(Request.Url.ToString)
        ElseIf e.CommandName = "EXCLUIR" Then
            Excluir(grdAlunos.DataKeys(e.CommandArgument).Item(0))
        End If
    End Sub

    Private Sub Excluir(CodigoEquipeAluno As Object)

        Dim objEquipeAluno As New EquipeAluno
        If objEquipeAluno.Excluir(CodigoEquipeAluno) > 0 Then
            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
        Else
            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
        End If
        CarregarGrid()
        CarregarComboAlunos()
    End Sub

    Protected Sub grdAlunos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdAlunos.RowDataBound
        Select Case e.Row.RowType

            Case DataControlRowType.DataRow

                Dim lnkExcluirAluno As New LinkButton
                lnkExcluirAluno = DirectCast(e.Row.Cells(2).FindControl("lnkExcluirAluno"), LinkButton)
                lnkExcluirAluno.CommandArgument = e.Row.RowIndex


        End Select
    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs)
        Salvar()
        LimparCampos()
        CarregarGrid()
        CarregarComboAlunos()

    End Sub

    Private Sub LimparCampos()
        drpAluno.ClearSelection()
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

    Private Sub Salvar()
        Dim objEquipeAluno As New EquipeAluno

        Try
            With objEquipeAluno
                .CodigoAluno = drpAluno.SelectedValue
                .CodigoEquipeEscola = ViewState("idTurma")
                .Salvar()
            End With
            MsgBox(eTipoMensagem.SALVAR_SUCESSO)
        Catch ex As Exception
            MsgBox(eTipoMensagem.SALVAR_ERRO)
        End Try

        objEquipeAluno = Nothing
    End Sub

    Protected Sub grdAlunos_Sorting(sender As Object, e As GridViewSortEventArgs) Handles grdAlunos.Sorting
        ViewState("OrderByDirection") = IIf(ViewState("OrderByDirection") = "asc", "desc", "asc")
        ViewState("OrderBy") = e.SortExpression & " " & ViewState("OrderByDirection")
        CarregarGrid()
    End Sub

    Protected Sub grdAlunos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdAlunos.PageIndexChanging
        grdAlunos.PageIndex = e.NewPageIndex
        CarregarGrid()
    End Sub
End Class