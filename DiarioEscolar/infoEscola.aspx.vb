Public Class infoEscola
    Inherits System.Web.UI.Page
    Dim objEscola As Escola

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If (Request.QueryString("idEscola") Is Nothing) Then
                Response.Redirect("frmEscola.aspx")
            End If
            Try

                Dim idEscola As Integer = Request.QueryString("idEscola")
                CarregarInfo(idEscola)

            Catch ex As Exception
                Response.Redirect("frmEscola.aspx")
            End Try

        End If
    End Sub

    Private Sub CarregarInfo(idEscola As Integer)
        ViewState("idEscola") = idEscola
        objEscola = New Escola(idEscola)
        Dim objSituacao As New TipoSituacao(objEscola.CodigoSituacao)
        Dim objCidade As New Cidade(objEscola.CodigoCidade)
        txtNomeEscola.Text = objEscola.Nome
        txtMec.Text = objEscola.NrMec
        txtNome.Text = objEscola.Nome
        txtCidade.Text = objCidade.Cidade
        txtSituacao.Text = objSituacao.Descricao
    End Sub


    Protected Sub btnPeriodoLetivo_Click(sender As Object, e As EventArgs)
        Response.Redirect("frmPeriodoLetivo.aspx?idEscola=" + ViewState("idEscola").ToString())
    End Sub


    Protected Sub btnMatriz_Click(sender As Object, e As EventArgs)
         Response.Redirect("frmMatriz.aspx?idEscola=" + ViewState("idEscola").ToString())
    End Sub

    Protected Sub btnTurma_Click(sender As Object, e As EventArgs)
        Response.Redirect("frmTurma.aspx?idEscola=" + ViewState("idEscola").ToString())
    End Sub
End Class