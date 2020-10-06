Public Class frmAtividadeDisciplina
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CarregarInfo()
    End Sub

    Private Sub CarregarInfo()
        Dim idEquipeDisciplina As Integer
        Try
            idEquipeDisciplina = Request.QueryString("idEquipeDisciplina")
        Catch ex As Exception
            Response.Redirect("frmEscola.aspx")
        End Try

        Dim objEquipeDisciplina As New EquipeDisciplina(idEquipeDisciplina)
        Dim objEquipeProfessor As New EquipeProfessor(objEquipeDisciplina.CodigoEquipeProfessor)
        Dim objEquipeEscola As New EquipeEscola(objEquipeProfessor.CodigoEquipeEscola)
        Dim objEscola As New Escola(objEquipeEscola.CodigoEscola)

        If (objEscola.Codigo > 0 And objEquipeEscola.Codigo > 0) Then
            ViewState("idEscola") = objEquipeEscola.CodigoEscola
            ViewState("idTurma") = objEquipeEscola.Codigo
            ViewState("idEquipeDisciplina") = idEquipeDisciplina
            txtNomeEscola.Text = objEscola.Nome
        Else
            Response.Redirect("frmEscola.aspx")
        End If


    End Sub

End Class