Public Class frmProfessorTurma
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CarregarInfo()
        If Not Page.IsPostBack Then
            CarregarComboProfessores()
            CarregarGrid()

        End If
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

        With drpAluno
            .DataValueField = "CODIGO"
            .DataTextField = "DESCRICAO"
            .DataSource = objProfessor.ObterTabela()
            .DataBind()

            If TypeOf drpAluno Is DropDownList Then
                .Items.Insert(0, New ListItem("Selecione...", 0))
            End If
        End With

        For Each row As DataRow In objEquipeProfessor.Pesquisar(ViewState("idTurma")).Rows

            drpAluno.Items.Remove(drpAluno.Items.FindByValue(row("EE03_ID_ALUNO")))
        Next


    End Sub

    Protected Sub drpAluno_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim objProfessor As Professor
        If (drpAluno.SelectedIndex <> 0) Then
            objProfessor = New Professor(drpAluno.SelectedValue)
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
End Class