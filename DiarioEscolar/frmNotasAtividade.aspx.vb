Public Class frmNotasAtividade
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CarregarInfo()
        If Not Page.IsPostBack Then
            CarregarGrid()
        End If
    End Sub

    Private Sub CarregarGrid()
        Dim objAluno As New Aluno
        grdAluno.DataSource = objAluno.ObterPorTurma(ViewState("idTurma"))
        grdAluno.DataBind()
        For Each item As GridViewRow In grdAluno.Rows
            Dim tmpTextBox As TextBox
            Dim objFrequencia As New Falta()
            Dim objNota As New Nota()
            Dim nota As String
            objNota.CodigoEquipeAluno = grdAluno.DataKeys(item.RowIndex).Item(0)
            tmpTextBox = item.FindControl("txtNota")
            With objNota.Pesquisar(,, ViewState("idAtividade"),, objNota.CodigoEquipeAluno)
                If .Rows.Count > 0 Then
                    Dim dr As DataRow = .Rows(0)
                    nota = dr("EE18_DS_NOTA")
                    tmpTextBox.Text = nota
                End If
            End With
        Next

    End Sub

    Private Sub CarregarInfo()
        Dim idAtividade As Integer
        Try
            idAtividade = Request.QueryString("idAtividade")
        Catch ex As Exception
            Response.Redirect("frmEscola.aspx")
        End Try

        Dim objAtividade As New Atividade(idAtividade)
        Dim objEquipeDisciplina As New EquipeDisciplina(objAtividade.EquipeDisciplina)
        Dim objEquipeProfessor As New EquipeProfessor(objEquipeDisciplina.CodigoEquipeProfessor)
        Dim objEquipeEscola As New EquipeEscola(objEquipeProfessor.CodigoEquipeEscola)
        Dim objEscola As New Escola(objEquipeEscola.CodigoEscola)

        If (objAtividade.Codigo > 0) Then
            ViewState("idEscola") = objEquipeEscola.CodigoEscola
            ViewState("idTurma") = objEquipeEscola.Codigo
            ViewState("idEquipeDisciplina") = objAtividade.EquipeDisciplina
            ViewState("idAtividade") = idAtividade
            txtNomeEscola.Text = objEscola.Nome
        Else
            Response.Redirect("frmEscola.aspx")
        End If


    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs)
        Salvar()
        CarregarGrid()
    End Sub

    Private Sub Salvar()
        For Each row As GridViewRow In grdAluno.Rows

            Dim txtNota As TextBox = grdAluno.Rows(row.RowIndex).Cells(2).FindControl("txtNota")
            Dim objNota As New Nota
            Try
                With objNota.Pesquisar(,, ViewState("idAtividade"),, row.Cells(0).Text)
                    If .Rows.Count > 0 Then
                        Dim dr As DataRow = .Rows(0)
                        objNota.Codigo = dr("EE18_ID_NOTA")
                        objNota.Atividade = dr("EE09_ID_ATIVIDADE")
                        objNota.CodigoEquipeAluno = dr("EE05_ID_EQUIPE_ALUNO")
                        objNota.Nota = txtNota.Text 'VALIDAR A NOTA ANTES DISSO
                    Else
                        objNota.CodigoEquipeAluno = row.Cells(0).Text
                        objNota.Atividade = ViewState("idAtividade")
                        objNota.Nota = txtNota.Text
                    End If
                    objNota.Salvar()
                End With
                MsgBox(eTipoMensagem.SALVAR_SUCESSO)
            Catch ex As Exception
                MsgBox(eTipoMensagem.SALVAR_ERRO)
            End Try
            objNota = Nothing

        Next
    End Sub
End Class