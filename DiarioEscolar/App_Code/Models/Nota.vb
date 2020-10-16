Imports System.Data

Public Class Nota
    Private EE18_ID_NOTA As Integer
    Private EE09_ID_ATIVIDADE As Integer
    Private EE18_DS_NOTA As String
    Private EE05_ID_EQUIPE_ALUNO As Integer

    Public Sub New()
    End Sub

    Public Property Codigo() As Integer
        Get
            Return EE18_ID_NOTA
        End Get
        Set(value As Integer)
            EE18_ID_NOTA = value
        End Set
    End Property

    Public Property Atividade() As Integer
        Get
            Return EE09_ID_ATIVIDADE
        End Get
        Set(value As Integer)
            EE09_ID_ATIVIDADE = value
        End Set
    End Property

    Public Property Nota() As String
        Get
            Return EE18_DS_NOTA
        End Get
        Set(value As String)
            EE18_DS_NOTA = value
        End Set
    End Property

    Public Property CodigoEquipeAluno() As Integer
        Get
            Return EE05_ID_EQUIPE_ALUNO
        End Get
        Set(value As Integer)
            EE05_ID_EQUIPE_ALUNO = value
        End Set
    End Property

    Public Function Pesquisar(Optional ByVal Sort As String = "",
                           Optional ByVal Codigo As Integer = 0,
                           Optional ByVal CodigoAtividade As Integer = 0,
                           Optional ByVal Nota As String = "",
                           Optional ByVal CodigoEquipeAluno As Integer = 0
                          ) As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" Select * ")
        strSQL.Append(" from  EE18_NOTA")
        strSQL.Append(" where  EE18_ID_NOTA Is Not null")

        If Codigo > 0 Then
            strSQL.Append(" And EE18_ID_NOTA = " & Codigo)
        End If

        If CodigoAtividade > 0 Then
            strSQL.Append("  And EE09_ID_ATIVIDADE = " & CodigoAtividade)
        End If

        If Nota <> "" Then
            strSQL.Append(" and upper(EE18_DS_NOTA) like '%" & Nota.ToUpper & "%'")
        End If

        If CodigoEquipeAluno > 0 Then
            strSQL.Append("  And EE05_ID_EQUIPE_ALUNO = " & CodigoEquipeAluno)
        End If

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from EE18_NOTA")
        strSQL.Append(" where EE18_ID_NOTA = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("EE09_ID_ATIVIDADE") = ProBanco(EE09_ID_ATIVIDADE, eTipoValor.CHAVE)
        dr("EE05_ID_EQUIPE_ALUNO") = ProBanco(EE05_ID_EQUIPE_ALUNO, eTipoValor.CHAVE)
        dr("EE18_DS_NOTA") = ProBanco(EE18_DS_NOTA, eTipoValor.TEXTO_LIVRE)

        cnn.SalvarDataTable(dr)

        dt.Dispose()
        dt = Nothing

        cnn = Nothing
    End Sub
End Class
