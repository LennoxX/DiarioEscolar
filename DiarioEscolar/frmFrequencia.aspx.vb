Public Class frmFrequencia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CarregarInfo()
        If Not Page.IsPostBack Then
            CarregarGrid()
        End If

    End Sub

    Private Sub CarregarGrid()
        Dim objAluno As New Aluno
        grdAluno.DataSource = objAluno.ObterPorTurma(ViewState("idAula"))
        grdAluno.DataBind()

        For Each item As GridViewRow In grdAluno.Rows
            Dim tmpDropDown As DropDownList
            Dim objFrequencia As New Falta()
            Dim falta As Integer

            objFrequencia.CodigoEquipeAluno = grdAluno.DataKeys(item.RowIndex).Item(0) ' SETAR VALOR DA FALTA

            tmpDropDown = item.FindControl("drpStatus")
            With objFrequencia.Pesquisar(,, ViewState("idAula"),, objFrequencia.CodigoEquipeAluno)
                If .Rows.Count > 0 Then
                    Dim dr As DataRow = .Rows(0)
                    falta = dr("EE17_NR_FALTA")
                    tmpDropDown.SelectedValue = falta
                End If
            End With
        Next

    End Sub

    Private Sub CarregarInfo()
        Dim idAula As Integer
        Try
            idAula = Request.QueryString("idAula")
        Catch ex As Exception
            Response.Redirect("frmEscola.aspx")
        End Try
        Dim objAula As New Aula(idAula)
        Dim objEquipeDisciplina As New EquipeDisciplina(objAula.IdEquipeDisciplina)
        Dim objEquipeProfessor As New EquipeProfessor(objEquipeDisciplina.CodigoEquipeProfessor)
        Dim objTurma As New EquipeEscola(objEquipeProfessor.CodigoEquipeEscola)
        Dim objEscola As New Escola(objTurma.CodigoEscola)

        If (objEscola.Codigo > 0) Then
            ViewState("idAula") = idAula
            ViewState("idEscola") = objEscola.Codigo
            ViewState("idTurma") = objTurma.Codigo
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
            Dim drpStatus As DropDownList = grdAluno.Rows(row.RowIndex).Cells(2).FindControl("drpStatus")
            Debug.Write(drpStatus)
            Debug.Write(drpStatus.SelectedValue)
            Dim objFalta As New Falta
            Try
                With objFalta.Pesquisar(,, ViewState("idAula"),, row.Cells(0).Text)
                    If .Rows.Count > 0 Then
                        Dim dr As DataRow = .Rows(0)
                        objFalta.Codigo = dr("EE17_ID_FALTA")
                        objFalta.CodigoAula = dr("EE08_ID_AULA")
                        objFalta.CodigoEquipeAluno = dr("EE05_ID_EQUIPE_ALUNO")
                        objFalta.Falta = drpStatus.SelectedValue

                    Else
                        objFalta.CodigoAula = ViewState("idAula")
                        objFalta.CodigoEquipeAluno = row.Cells(0).Text
                        objFalta.Falta = drpStatus.SelectedValue
                    End If
                    objFalta.Salvar()
                End With
                MsgBox(eTipoMensagem.SALVAR_SUCESSO)
            Catch ex As Exception
                MsgBox(eTipoMensagem.SALVAR_ERRO)
            End Try
            drpStatus = Nothing
        Next
    End Sub

End Class