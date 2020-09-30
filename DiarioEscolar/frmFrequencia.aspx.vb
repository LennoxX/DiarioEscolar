Public Class frmFrequencia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CarregarInfo()
            CarregarGrid()
        End If

    End Sub

    Private Sub CarregarGrid()
        Dim objAluno As New Aluno
        grdAluno.DataSource = objAluno.ObterPorTurma(ViewState("idAula"))
        grdAluno.DataBind()
    End Sub

    Private Sub CarregarInfo()
        Dim idAula As Integer = Request.QueryString("idAula")
        ViewState("idAula") = idAula


    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs)
        Salvar()
        'CarregarGrid()

    End Sub

    Private Sub Salvar()
        For Each row As GridViewRow In grdAluno.Rows

            ' RECUPERA O ESTADO (AUSENTE, PRESENTE)
            Dim drpStatus As DropDownList = grdAluno.Rows(row.RowIndex).Cells(2).FindControl("drpStatus")
            Debug.Write(drpStatus)
            Debug.Write(drpStatus.SelectedValue)
            Dim objFalta As New Falta
            Try
                With objFalta
                    .CodigoAula = ViewState("idAula")
                    .CodigoEquipeAluno = row.Cells(0).Text
                    .Falta = drpStatus.SelectedValue
                    .Salvar()
                End With
                MsgBox(eTipoMensagem.SALVAR_SUCESSO)
            Catch ex As Exception
                MsgBox(eTipoMensagem.SALVAR_ERRO)
            End Try


            '     Debug.Write(grdAluno.DataKeys(row.RowIndex)(0))
            drpStatus = Nothing
        Next
    End Sub
End Class